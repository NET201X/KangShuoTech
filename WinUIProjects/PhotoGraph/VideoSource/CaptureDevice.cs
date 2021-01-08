namespace VideoSource
{
    using dshow;
    using dshow.Core;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Threading;

    public class CaptureDevice : IVideoSource
    {
        private int framesReceived;
        private string source;
        private ManualResetEvent stopEvent;
        private Thread thread;
        private object userData;

        public event CameraEventHandler NewFrame;

        private void Free()
        {
            this.thread = null;
            this.stopEvent.Close();
            this.stopEvent = null;
        }

        protected void OnNewFrame(Bitmap image)
        {
            this.framesReceived++;
            if (!this.stopEvent.WaitOne(0, true) && (this.NewFrame != null))
            {
                this.NewFrame(this, new CameraEventArgs(image));
            }
        }

        public void SignalToStop()
        {
            if (this.thread != null)
            {
                this.stopEvent.Set();
            }
        }

        public void Start()
        {
            if (this.thread == null)
            {
                this.framesReceived = 0;
                this.stopEvent = new ManualResetEvent(false);
                this.thread = new Thread(new ThreadStart(this.WorkerThread));
                this.thread.Name = this.source;
                this.thread.Start();
            }
        }

        public void Stop()
        {
            if (this.Running)
            {
                this.thread.Abort();
            }
        }

        public void WaitForStop()
        {
            if (this.thread != null)
            {
                this.thread.Join();
                this.Free();
            }
        }

        public void WorkerThread()
        {
            Grabber pCallback = new Grabber(this);
            object o = null;
            object ppvResult = null;
            object obj4 = null;
            IGraphBuilder builder = null;
            IBaseFilter pFilter = null;
            IBaseFilter filter2 = null;
            ISampleGrabber grabber2 = null;
            IMediaControl control = null;
            try
            {
                Type typeFromCLSID = Type.GetTypeFromCLSID(Clsid.FilterGraph);
                if (typeFromCLSID == null)
                {
                    throw new ApplicationException("Failed creating filter graph");
                }
                o = Activator.CreateInstance(typeFromCLSID);
                builder = (IGraphBuilder) o;
                UCOMIBindCtx ppbc = null;
                UCOMIMoniker ppmk = null;
                int pchEaten = 0;
                if (Win32.CreateBindCtx(0, out ppbc) == 0)
                {
                    if (Win32.MkParseDisplayName(ppbc, this.source, ref pchEaten, out ppmk) == 0)
                    {
                        Guid gUID = typeof(IBaseFilter).GUID;
                        ppmk.BindToObject(null, null, ref gUID, out ppvResult);
                        Marshal.ReleaseComObject(ppmk);
                        ppmk = null;
                    }
                    Marshal.ReleaseComObject(ppbc);
                    ppbc = null;
                }
                if (ppvResult == null)
                {
                    throw new ApplicationException("Failed creating device object for moniker");
                }
                pFilter = (IBaseFilter) ppvResult;
                typeFromCLSID = Type.GetTypeFromCLSID(Clsid.SampleGrabber);
                if (typeFromCLSID == null)
                {
                    throw new ApplicationException("Failed creating sample grabber");
                }
                obj4 = Activator.CreateInstance(typeFromCLSID);
                grabber2 = (ISampleGrabber) obj4;
                filter2 = (IBaseFilter) obj4;
                builder.AddFilter(pFilter, "source");
                builder.AddFilter(filter2, "grabber");
                AMMediaType pmt = new AMMediaType {
                    majorType = MediaType.Video,
                    subType = MediaSubType.RGB24
                };
                grabber2.SetMediaType(pmt);
                if (builder.Connect(DSTools.GetOutPin(pFilter, 0), DSTools.GetInPin(filter2, 0)) < 0)
                {
                    throw new ApplicationException("Failed connecting filters");
                }
                if (grabber2.GetConnectedMediaType(pmt) == 0)
                {
                    VideoInfoHeader header = (VideoInfoHeader) Marshal.PtrToStructure(pmt.formatPtr, typeof(VideoInfoHeader));
                    pCallback.Width = header.BmiHeader.Width;
                    pCallback.Height = header.BmiHeader.Height;
                    pmt.Dispose();
                }
                builder.Render(DSTools.GetOutPin(filter2, 0));
                grabber2.SetBufferSamples(false);
                grabber2.SetOneShot(false);
                grabber2.SetCallback(pCallback, 1);
                ((IVideoWindow) o).put_AutoShow(false);
                control = (IMediaControl) o;
                control.Run();
                while (!this.stopEvent.WaitOne(0, true))
                {
                    Thread.Sleep(100);
                }
                control.StopWhenReady();
            }
            catch (Exception)
            {
            }
            finally
            {
                control = null;
                builder = null;
                pFilter = null;
                filter2 = null;
                grabber2 = null;
                if (o != null)
                {
                    Marshal.ReleaseComObject(o);
                    o = null;
                }
                if (ppvResult != null)
                {
                    Marshal.ReleaseComObject(ppvResult);
                    ppvResult = null;
                }
                if (obj4 != null)
                {
                    Marshal.ReleaseComObject(obj4);
                    obj4 = null;
                }
            }
        }

        public int BytesReceived
        {
            get
            {
                return 0;
            }
        }

        public int FramesReceived
        {
            get
            {
                int framesReceived = this.framesReceived;
                this.framesReceived = 0;
                return framesReceived;
            }
        }

        public string Login
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        public string Password
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        public bool Running
        {
            get
            {
                if (this.thread != null)
                {
                    if (!this.thread.Join(0))
                    {
                        return true;
                    }
                    this.Free();
                }
                return false;
            }
        }

        public object UserData
        {
            get
            {
                return this.userData;
            }
            set
            {
                this.userData = value;
            }
        }

        public virtual string VideoSource
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
            }
        }

        private class Grabber : ISampleGrabberCB
        {
            private int height;
            private CaptureDevice parent;
            private int width;

            public Grabber(CaptureDevice parent)
            {
                this.parent = parent;
            }

            public int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
            {
                Bitmap image = new Bitmap(this.width, this.height, PixelFormat.Format24bppRgb);
                BitmapData bitmapdata = image.LockBits(new Rectangle(0, 0, this.width, this.height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int stride = bitmapdata.Stride;
                int num2 = bitmapdata.Stride;
                int dst = bitmapdata.Scan0.ToInt32() + (num2 * (this.height - 1));
                int src = pBuffer.ToInt32();
                for (int i = 0; i < this.height; i++)
                {
                    Win32.memcpy(dst, src, stride);
                    dst -= num2;
                    src += stride;
                }
                image.UnlockBits(bitmapdata);
                this.parent.OnNewFrame(image);
                image.Dispose();
                return 0;
            }

            public int SampleCB(double SampleTime, IntPtr pSample)
            {
                return 0;
            }

            public int Height
            {
                get
                {
                    return this.height;
                }
                set
                {
                    this.height = value;
                }
            }

            public int Width
            {
                get
                {
                    return this.width;
                }
                set
                {
                    this.width = value;
                }
            }
        }
    }
}

