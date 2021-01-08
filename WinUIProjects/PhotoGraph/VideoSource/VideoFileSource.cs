namespace VideoSource
{
    using System;
    using System.Threading;

    public class VideoFileSource : IVideoSource
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
    }
}

