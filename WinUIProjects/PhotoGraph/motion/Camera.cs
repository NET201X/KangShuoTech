namespace motion
{
    using CommomUtilities.Common;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Threading;
    using System.Windows.Forms;
    using VideoSource;
    public class Camera
    {
        private double alarmLevel = 0.005;
        private int height = -1;
        private Bitmap lastFrame;
        private IVideoSource videoSource;
        private int width = -1;
        private string community = ConfigHelper.GetSetNode("community");
        // 取得屏幕分辨率的宽高
        private int SW = Screen.PrimaryScreen.Bounds.Width;

        public event EventHandler Alarm;

        public event EventHandler NewFrame;

        public Camera(IVideoSource source)
        {
            this.videoSource = source;
            this.videoSource.NewFrame += new CameraEventHandler(this.video_NewFrame);
        }

        private void DrawCatchArea(ref Bitmap image)
        {
            Graphics graphics = Graphics.FromImage(image);
            Pen pen = new Pen(Color.Red, 0.2f)
            {
                DashStyle = DashStyle.Dash
            };

            if (SW > 1400) graphics.DrawRectangle(pen, (float)200f, (float)20f, (float)340f, (float)400f);
            else graphics.DrawRectangle(pen, (float)200f, (float)20f, (float)240f, (float)300f);

            float num = 200f;
            float num2 = 20f;
            graphics.DrawLine(pen, new PointF(42.5f + num, 7f + num2), new PointF(197.5f + num, 7f + num2));
            graphics.DrawLine(pen, new PointF(42.5f + num, 21f + num2), new PointF(197.5f + num, 21f + num2));
            graphics.DrawLine(pen, new PointF(0f + num, 250f + num2), new PointF(25f + num, 250f + num2));
            graphics.DrawLine(pen, new PointF(240f + num, 250f + num2), new PointF(215f + num, 250f + num2));
            graphics.DrawLine(pen, new PointF(120f + num, 28f + num2), new PointF(120f + num, 178f + num2));
          
        }

        public Bitmap GetImageByArea()
        {
            Bitmap image = null;
            this.Lock();
            if (this.lastFrame != null)
            {
                image = new Bitmap(340, 400);
                Graphics graphics = Graphics.FromImage(image);
              
                Rectangle srcRect = new Rectangle(200, 20, 340, 400);
                Rectangle destRect = new Rectangle(0, 0, 340, 400);
                Bitmap image2 = new Bitmap(this.lastFrame, 730, 610);
                graphics.DrawImage(image2, destRect, srcRect, GraphicsUnit.Pixel);
                if (community.Equals("凤凰镇社区卫生服务中心"))
                {
                    //水印内容
                    string waterText = DateTime.Now.ToString();
                    Font font = new Font("宋体", 12);
                    //用于确定水印的大小
                    SizeF zisizeF = new SizeF();
                    zisizeF = graphics.MeasureString(waterText, font);
                    //亮度，红色，绿色，蓝色
                    SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
                    //水印
                    graphics.DrawString(waterText, font, solidBrush, new PointF(image.Width / 2, image.Height / 2 - zisizeF.Height / 2 + 165));
                }
            }
            this.Unlock();
            return image;
        }

        public void Lock()
        {
            Monitor.Enter(this);
        }

        public void SignalToStop()
        {
            if (this.videoSource != null)
            {
                this.videoSource.SignalToStop();
            }
        }

        public void Start()
        {
            if (this.videoSource != null)
            {
                this.videoSource.Start();
            }
        }

        public void Stop()
        {
            Monitor.Enter(this);
            if (this.videoSource != null)
            {
                this.videoSource.Stop();
            }
            Monitor.Exit(this);
        }

        public void Unlock()
        {
            Monitor.Exit(this);
        }

        private void video_NewFrame(object sender, CameraEventArgs e)
        {
            try
            {
                Monitor.Enter(this);
                if (this.lastFrame != null)
                {
                    this.lastFrame.Dispose();
                }
                this.lastFrame = (Bitmap)e.Bitmap.Clone();
                this.width = this.lastFrame.Width;
                this.height = this.lastFrame.Height;
            }
            catch (Exception)
            {
            }
            finally
            {
                Monitor.Exit(this);
            }
            if (this.NewFrame != null)
            {
                this.NewFrame(this, new EventArgs());
            }
        }

        public void WaitForStop()
        {
            Monitor.Enter(this);
            if (this.videoSource != null)
            {
                this.videoSource.WaitForStop();
            }
            Monitor.Exit(this);
        }

        public int BytesReceived
        {
            get
            {
                if (this.videoSource != null)
                {
                    return this.videoSource.BytesReceived;
                }
                return 0;
            }
        }

        public int FramesReceived
        {
            get
            {
                if (this.videoSource != null)
                {
                    return this.videoSource.FramesReceived;
                }
                return 0;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
        }

        public Bitmap LastFrame
        {
            get
            {
                return this.lastFrame;
            }
        }

        public bool Running
        {
            get
            {
                return ((this.videoSource != null) && this.videoSource.Running);
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
        }
    }
}

