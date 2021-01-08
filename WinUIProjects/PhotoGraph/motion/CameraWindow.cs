namespace motion
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Timers;
    using System.Windows.Forms;

    public class CameraWindow : Control
    {
        private bool autosize;
        private motion.Camera camera;
        private bool firstFrame = true;
        private int flash;
        private bool needSizeUpdate;
        private Color rectColor = Color.Black;
        private System.Timers.Timer timer;

        public CameraWindow()
        {
            this.InitializeComponent();
            base.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        private void camera_Alarm(object sender, EventArgs e)
        {
            this.flash = (int) (2.0 * (1000.0 / this.timer.Interval));
        }

        private void camera_NewFrame(object sender, EventArgs e)
        {
            base.Invalidate();
        }

        private void InitializeComponent()
        {
            this.timer = new System.Timers.Timer();
            this.timer.BeginInit();
            this.timer.Interval = 250.0;
            this.timer.SynchronizingObject = this;
            this.timer.Elapsed += new ElapsedEventHandler(this.timer_Elapsed);
            this.timer.EndInit();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (this.needSizeUpdate || this.firstFrame)
            {
                this.UpdatePosition();
                this.needSizeUpdate = false;
            }
            Monitor.Enter(this);
            Graphics graphics = pe.Graphics;
            Rectangle clientRectangle = base.ClientRectangle;
            Pen pen = new Pen(this.rectColor, 1f);
            graphics.DrawRectangle(pen, clientRectangle.X, clientRectangle.Y, clientRectangle.Width - 1, clientRectangle.Height - 1);
            if (this.camera != null)
            {
                try
                {
                    this.camera.Lock();
                    if (this.camera.LastFrame != null)
                    {
                        graphics.DrawImage(this.camera.LastFrame, (int) (clientRectangle.X + 1), (int) (clientRectangle.Y + 1), (int) (clientRectangle.Width - 2), (int) (clientRectangle.Height - 2));
                        this.firstFrame = false;
                    }
                    else
                    {
                        Font font = new Font("Arial", 12f);
                        SolidBrush brush = new SolidBrush(Color.White);
                        graphics.DrawString("Connecting ...", font, brush, new PointF(5f, 5f));
                        brush.Dispose();
                        font.Dispose();
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    this.camera.Unlock();
                }
            }
            pen.Dispose();
            Monitor.Exit(this);
            base.OnPaint(pe);
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.flash > 0)
            {
                if (--this.flash == 0)
                {
                    this.rectColor = Color.Black;
                }
                else
                {
                    this.rectColor = (this.rectColor == Color.Red) ? Color.Black : Color.Red;
                }
                if (!this.needSizeUpdate)
                {
                    Graphics graphics = base.CreateGraphics();
                    Rectangle clientRectangle = base.ClientRectangle;
                    Pen pen = new Pen(this.rectColor, 1f);
                    graphics.DrawRectangle(pen, clientRectangle.X, clientRectangle.Y, clientRectangle.Width - 1, clientRectangle.Height - 1);
                    graphics.Dispose();
                    pen.Dispose();
                }
            }
        }

        public void UpdatePosition()
        {
            Monitor.Enter(this);
            if (this.autosize && (base.Parent != null))
            {
                Rectangle clientRectangle = base.Parent.ClientRectangle;
                int width = 320;
                int height = 240;
                if (this.camera != null)
                {
                    this.camera.Lock();
                    if (this.camera.LastFrame != null)
                    {
                        width = this.camera.LastFrame.Width;
                        height = this.camera.LastFrame.Height;
                    }
                    this.camera.Unlock();
                }
                base.SuspendLayout();
                base.Location = new Point(((clientRectangle.Width - width) - 2) / 2, ((clientRectangle.Height - height) - 2) / 2);
                base.Size = new Size(width + 2, height + 2);
                base.ResumeLayout();
            }
            Monitor.Exit(this);
        }

        [DefaultValue(false)]
        public bool AutoSize
        {
            get
            {
                return this.autosize;
            }
            set
            {
                this.autosize = value;
                this.UpdatePosition();
            }
        }

        [Browsable(false)]
        public motion.Camera Camera
        {
            get
            {
                return this.camera;
            }
            set
            {
                Monitor.Enter(this);
                if (this.camera != null)
                {
                    this.camera.NewFrame -= new EventHandler(this.camera_NewFrame);
                    this.camera.Alarm -= new EventHandler(this.camera_Alarm);
                    this.timer.Stop();
                }
                this.camera = value;
                this.needSizeUpdate = true;
                this.firstFrame = true;
                this.flash = 0;
                if (this.camera != null)
                {
                    this.camera.NewFrame += new EventHandler(this.camera_NewFrame);
                    this.camera.Alarm += new EventHandler(this.camera_Alarm);
                    this.timer.Start();
                }
                Monitor.Exit(this);
            }
        }
    }
}

