namespace VideoSource
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading;

    public class MJPEGStream : IVideoSource
    {
        private const int bufSize = 0x80000;
        private int bytesReceived;
        private int framesReceived;
        private string login;
        private string password;
        private const int readSize = 0x400;
        private ManualResetEvent reloadEvent;
        private string source;
        private ManualResetEvent stopEvent;
        private Thread thread;
        private object userData;
        private bool useSeparateConnectionGroup = true;

        public event CameraEventHandler NewFrame;

        private void Free()
        {
            this.thread = null;
            this.stopEvent.Close();
            this.stopEvent = null;
            this.reloadEvent.Close();
            this.reloadEvent = null;
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
                this.reloadEvent = new ManualResetEvent(false);
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
            do
            {
                this.reloadEvent.Reset();
                HttpWebRequest request = null;
                WebResponse response = null;
                Stream responseStream = null;
                byte[] needle = null;
                byte[] bytes = null;
                int num2 = 0;
                int num3 = 0;
                int count = 0;
                int offset = 0;
                int startIndex = 0;
                int num8 = 1;
                int index = 0;
                int num10 = 0;
                try
                {
                    request = (HttpWebRequest) WebRequest.Create(this.source);
                    if (((this.login != null) && (this.password != null)) && (this.login != ""))
                    {
                        request.Credentials = new NetworkCredential(this.login, this.password);
                    }
                    if (this.useSeparateConnectionGroup)
                    {
                        request.ConnectionGroupName = this.GetHashCode().ToString();
                    }
                    response = request.GetResponse();
                    string contentType = response.ContentType;
                    if (contentType.IndexOf("multipart/x-mixed-replace") == -1)
                    {
                        throw new ApplicationException("Invalid URL");
                    }
                    bytes = new ASCIIEncoding().GetBytes(contentType.Substring(contentType.IndexOf("boundary=", 0) + 9));
                    int length = bytes.Length;
                    responseStream = response.GetResponseStream();
                    while (!this.stopEvent.WaitOne(0, true) && !this.reloadEvent.WaitOne(0, true))
                    {
                        if (offset > 0x7fc00)
                        {
                            offset = startIndex = count = 0;
                        }
                        int num4 = responseStream.Read(buffer, offset, 0x400);
                        if (num4 == 0)
                        {
                            throw new ApplicationException();
                        }
                        offset += num4;
                        count += num4;
                        this.bytesReceived += num4;
                        if (needle == null)
                        {
                            startIndex = ByteArrayUtils.Find(buffer, bytes, startIndex, count);
                            if (startIndex == -1)
                            {
                                count = length - 1;
                                startIndex = offset - count;
                                continue;
                            }
                            count = offset - startIndex;
                            if (count < 2)
                            {
                                continue;
                            }
                            if (buffer[startIndex + length] == 10)
                            {
                                num2 = 2;
                                needle = new byte[] { 10, 10 };
                                num3 = 1;
                            }
                            else
                            {
                                num2 = 4;
                                needle = new byte[] { 13, 10, 13, 10 };
                                num3 = 2;
                            }
                            startIndex += length + num3;
                            count = offset - startIndex;
                        }
                        if (num8 == 1)
                        {
                            index = ByteArrayUtils.Find(buffer, needle, startIndex, count);
                            if (index != -1)
                            {
                                index += num2;
                                startIndex = index;
                                count = offset - startIndex;
                                num8 = 2;
                            }
                            else
                            {
                                count = num2 - 1;
                                startIndex = offset - count;
                            }
                        }
                        while ((num8 == 2) && (count >= length))
                        {
                            num10 = ByteArrayUtils.Find(buffer, bytes, startIndex, count);
                            if (num10 != -1)
                            {
                                startIndex = num10;
                                count = offset - startIndex;
                                this.framesReceived++;
                                if (this.NewFrame != null)
                                {
                                    Bitmap bmp = (Bitmap) Image.FromStream(new MemoryStream(buffer, index, num10 - index));
                                    this.NewFrame(this, new CameraEventArgs(bmp));
                                    bmp.Dispose();
                                    bmp = null;
                                }
                                startIndex = num10 + length;
                                count = offset - startIndex;
                                Array.Copy(buffer, startIndex, buffer, 0, count);
                                offset = count;
                                startIndex = 0;
                                num8 = 1;
                            }
                            else
                            {
                                count = length - 1;
                                startIndex = offset - count;
                            }
                        }
                    }
                }
                catch (WebException)
                {
                    Thread.Sleep(250);
                }
                catch (ApplicationException)
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

        public string VideoSource
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
                if (this.thread != null)
                {
                    this.reloadEvent.Set();
                }
            }
        }
    }
}

