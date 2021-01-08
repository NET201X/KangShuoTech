namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class Ruler : Control, IMessageFilter
    {
        private Pen backPen;
        private IContainer components;
        private Graphics g;
        private float height_mm;
        private float percent;
        private int referLine = 15;
        private Pen referLinePen;
        private Orientation rulerOrientation = Orientation.Vertical;
        private Font scaleLabel = new Font("Verdana", 7f);
        private int start = 20;
        private int startValue;
        private Point trackOld;
        private float width_mm;

        public Ruler()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.InitializeComponent();
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.referLinePen = new Pen(this.ForeColor);
            this.backPen = new Pen(this.BackColor);
            this.g = base.CreateGraphics();
            this.Initialize();
            if (base.Visible)
            {
                Application.AddMessageFilter(this);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DrawScale(Graphics g, int whidth)
        {
            for (int i = 0; i < whidth; i++)
            {
                if (i >= this.startValue)
                {
                    int num2;
                    PointF tf2;
                    PointF tf3;
                    if ((i % 10) == 0)
                    {
                        string text = (i / 10).ToString();
                        SizeF ef = g.MeasureString(text, this.scaleLabel);
                        num2 = 15;
                        PointF point = (this.rulerOrientation != Orientation.Horizontal) ? new PointF(((base.Width - num2) - ef.Width) - this.referLine, (this.start + ((i - this.startValue) * this.percent)) - ((float) (((double) ef.Height) / 2.0))) : new PointF((this.start + ((i - this.startValue) * this.percent)) - ((float) (((double) ef.Width) / 2.0)), ((base.Height - num2) - ef.Height) - this.referLine);
                        g.DrawString(text, this.scaleLabel, Brushes.Blue, point);
                    }
                    else
                    {
                        num2 = ((i % 5) != 0) ? 5 : 10;
                    }
                    if (this.rulerOrientation == Orientation.Horizontal)
                    {
                        tf2 = new PointF(this.start + ((i - this.startValue) * this.percent), (float) (base.Height - this.referLine));
                        tf3 = new PointF(this.start + ((i - this.startValue) * this.percent), (float) ((base.Height - num2) - this.referLine));
                    }
                    else
                    {
                        tf2 = new PointF((float) (base.Width - this.referLine), this.start + ((i - this.startValue) * this.percent));
                        tf3 = new PointF((float) ((base.Width - num2) - this.referLine), this.start + ((i - this.startValue) * this.percent));
                    }
                    g.DrawLine(Pens.Blue, tf2, tf3);
                }
            }
        }

        ~Ruler()
        {
            this.referLinePen.Dispose();
            this.backPen.Dispose();
            Application.RemoveMessageFilter(this);
        }

        internal void Initialize()
        {
            this.width_mm = CommonSettings.PixelConvertMillimeter((float) base.Width);
            this.height_mm = CommonSettings.PixelConvertMillimeter((float) base.Height);
            if (this.rulerOrientation == Orientation.Horizontal)
            {
                this.percent = ((float) base.Width) / this.width_mm;
            }
            else
            {
                this.percent = ((float) base.Height) / this.height_mm;
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.rulerOrientation == Orientation.Horizontal)
            {
                e.Graphics.DrawLine(this.referLinePen, 0, base.Height - this.referLine, base.Width, base.Height - this.referLine);
                this.DrawScale(e.Graphics, ((int) this.width_mm) + this.startValue);
            }
            else
            {
                e.Graphics.DrawLine(this.referLinePen, base.Width - this.referLine, 0, base.Width - this.referLine, base.Height);
                this.DrawScale(e.Graphics, ((int) this.height_mm) + this.startValue);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Initialize();
            base.Invalidate();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x200)
            {
                int x = 0;
                int y = 0;
                Point mousePosition = Control.MousePosition;
                Point point2 = base.PointToScreen(new Point(x, y));
                if ((this.rulerOrientation != Orientation.Horizontal) ? ((mousePosition.Y >= point2.Y) && (mousePosition.Y <= (point2.Y + base.Height))) : ((mousePosition.X >= point2.X) && (mousePosition.X <= (point2.X + base.Width))))
                {
                    int num3 = mousePosition.X - point2.X;
                    int num4 = mousePosition.Y - point2.Y;
                    using (this.g = base.CreateGraphics())
                    {
                        if (this.rulerOrientation == Orientation.Horizontal)
                        {
                            this.g.DrawLine(this.backPen, this.trackOld.X, base.Height, this.trackOld.X, (base.Height - this.referLine) + 1);
                            this.g.DrawLine(Pens.Blue, num3, base.Height, num3, base.Height - this.referLine);
                        }
                        else
                        {
                            this.g.DrawLine(this.backPen, base.Width, this.trackOld.Y, (base.Width - this.referLine) + 1, this.trackOld.Y);
                            this.g.DrawLine(Pens.Blue, base.Width, num4, (base.Width - this.referLine) + 1, num4);
                        }
                        this.trackOld = new Point(num3, num4);
                    }
                }
            }
            return false;
        }

        [DisplayName("标尺方向")]
        public Orientation RulerOrientation
        {
            get
            {
                return this.rulerOrientation;
            }
            set
            {
                this.rulerOrientation = value;
                this.Initialize();
                base.Invalidate();
            }
        }

        [DisplayName("起始位置")]
        public int StartPosition
        {
            get
            {
                return this.start;
            }
            set
            {
                this.start = value;
                this.Initialize();
                base.Invalidate();
            }
        }

        [DisplayName("起始刻度")]
        public int StartValue
        {
            get
            {
                return this.startValue;
            }
            set
            {
                this.startValue = value;
                base.Invalidate();
            }
        }

        internal enum Msg
        {
            WM_MOUSELEAVE = 0x2a3,
            WM_MOUSEMOVE = 0x200,
            WM_NCMOUSELEAVE = 0x2a2
        }
    }
}

