namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class MoveControl
    {
        private Point cPoint;
        private Control currentControl;
        public FrameUserControl fc;
        private Point pPoint;
        public Rectangle workSpaceRec;

        public MoveControl(Control ctrl)
        {
            this.currentControl = ctrl;
            this.AddEvents();
        }

        private void AddEvents()
        {
            this.currentControl.MouseClick += new MouseEventHandler(this.MouseClick);
            this.currentControl.MouseDown += new MouseEventHandler(this.MouseDown);
            this.currentControl.MouseMove += new MouseEventHandler(this.MouseMove);
            this.currentControl.MouseUp += new MouseEventHandler(this.MouseUp);
            this.currentControl.KeyUp += new KeyEventHandler(this.currentControl_KeyUp);
            this.currentControl.Leave += new EventHandler(this.currentControl_Leave);
        }

        private void currentControl_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void currentControl_Leave(object sender, EventArgs e)
        {
            if (this.fc != null)
            {
                this.fc.Visible = false;
            }
        }

        public static void DrawDragBound(Control ctrl)
        {
            ctrl.Refresh();
            Graphics graphics = ctrl.CreateGraphics();
            int width = ctrl.Width;
            int height = ctrl.Height;
            Point[] points = new Point[] { new Point(0, 0), new Point(width - 1, 0), new Point(width - 1, height - 1), new Point(0, height - 1), new Point(0, 0) };
            graphics.DrawLines(new Pen(Color.Black), points);
        }

        protected void MouseClick(object sender, MouseEventArgs e)
        {
            this.currentControl.BringToFront();
            this.fc = new FrameUserControl(this.currentControl);
            this.currentControl.Parent.Controls.Add(this.fc);
            this.fc.Visible = true;
            this.fc.Draw();
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            this.pPoint = Cursor.Position;
            this.currentControl.Focus();
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.SizeAll;
            if (e.Button == MouseButtons.Left)
            {
                Rectangle rect = new Rectangle {
                    X = this.currentControl.Location.X,
                    Y = this.currentControl.Location.Y,
                    Width = this.currentControl.Width,
                    Height = this.currentControl.Height
                };
                if (this.workSpaceRec.Contains(rect))
                {
                    DrawDragBound(this.currentControl);
                    if (this.fc != null)
                    {
                        this.fc.Visible = false;
                    }
                    this.cPoint = Cursor.Position;
                    this.currentControl.Location = new Point(this.currentControl.Location.X + (this.cPoint.X - this.pPoint.X), this.currentControl.Location.Y + (this.cPoint.Y - this.pPoint.Y));
                    this.pPoint = this.cPoint;
                }
            }
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            this.currentControl.Refresh();
            if (this.fc != null)
            {
                this.fc.Visible = true;
                this.fc.Draw();
            }
        }
    }
}

