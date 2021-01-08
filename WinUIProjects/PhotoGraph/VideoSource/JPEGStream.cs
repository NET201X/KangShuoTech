namespace VideoSource
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Threading;

    public class JPEGStream : IVideoSource
    {
        private const int bufSize = 0x80000;
        private int bytesReceived;
        private int frameInterval;
        private int framesReceived;
        private string login;
        private string password;
        private bool preventCaching;
        private const int readSize = 0x400;
        private string source;
        private ManualResetEvent stopEvent;
        private Thread thread;
        private object userData;
        private bool useSeparateConnectionGroup;

        public event CameraEventHandler NewFrame;

        private void Free()
        {
            this.thread = null;
            this.stopEvent.Close();
            this.stopEvent = null;
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
                this.bytesReceived = 0;
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
                this.WaitForStop();
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
            byte[] buffer = new byte[0x80000];
            HttpWebRequest request = null;
            WebResponse response = null;
            Stream responseStream = null;
            Random random = new Random((int) DateTime.Now.Ticks);
            do
            {
                int offset = 0;
                try
                {
                    DateTime now = DateTime.Now;
                    if (!this.preventCaching)
                    {
                        request = (HttpWebRequest) WebRequest.Create(this.source);
                    }
                    else
                    {
                        request = (HttpWebRequest) WebRequest.Create(string.Concat(new object[] { this.source, (this.source.IndexOf('?') == -1) ? '?' : '&', "fake=", random.Next().ToString() }));
                    }
                    if (((this.login != null) && (this.password != null)) && (this.login != ""))
                    {
                        request.Credentials = new NetworkCredential(this.login, this.password);
                    }
                    if (this.useSeparateConnectionGroup)
                    {
                        request.ConnectionGroupName = this.GetHashCode().ToString();
                    }
                    response = request.GetResponse();
                    responseStream = response.GetResponseStream();
                    while (!this.stopEvent.WaitOne(0, true))
                    {
                        if (offset > 0x7fc00)
                        {
                            offset = 0;
                        }
                        int num = responseStream.Read(buffer, offset, 0x400);
                        if (num == 0)
                        {
                            break;
                        }
                        offset += num;
                        this.bytesReceived += num;
                    }
                    if (!this.stopEvent.WaitOne(0, true))
                    {
                        this.framesReceived++;
                        if (this.NewFrame != null)
                        {
                            Bitmap bmp = (Bitmap) Image.FromStream(new MemoryStream(buffer, 0, offset));
                            this.NewFrame(this, new CameraEventArgs(bmp));
                            bmp.Dispose();
                            bmp = null;
                        }
                    }
                    if (this.frameInterval > 0)
                    {
                        TimeSpan span = DateTime.Now.Subtract(now);
                        for (int i = this.frameInterval - ((int) span.TotalMilliseconds); (i > 0) && !this.stopEvent.WaitOne(0, true); i -= 100)
                        {
                            Thread.Sleep((i < 100) ? i : 100);
                        }
                    }
                }
                catch (WebException)
                {
                    Thread.Sleep(250);
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (request != null)
                    {
                        request.Abort();
                        request = null;
                    }
                    if (responseStream != null)
                    {
                        responseStream.Close();
                        responseStream = null;
                    }
                    if (response != null)
                    {
                        response.Close();
                        response = null;
                    }
                }
            }
            while (!this.stopEvent.WaitOne(0, true));
        }

        public int BytesReceived
        {
            get
            {
                int bytesReceived = this.bytesReceived;
                this.bytesReceived = 0;
                return bytesReceived;
            }
        }

        public int FrameInterval
        {
            get
            {
                return this.frameInterval;
            }
            set
            {
                this.frameInterval = value;
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
                return this.login;
            }
            set
            {
                this.login = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public bool PreventCaching
        {
            get
            {
                return this.preventCaching;
            }
            set
            {
                this.preventCaching = value;
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

        public bool SeparateConnectionGroup
        {
            get
            {
                return this.useSeparateConnectionGroup;
            }
            set
            {
                this.useSeparateConnectionGroup = value;
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
    }
}

