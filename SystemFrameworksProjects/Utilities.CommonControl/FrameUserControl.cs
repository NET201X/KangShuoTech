namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class FrameUserControl : UserControl
    {
        private const int Band = 6;
        private Control baseControl;
        private Rectangle ControlRect;
        private Point cPoint;
        private Graphics g;
        private Point[] linePoints = new Point[5];
        private int MinHeight = 20;
        private int MinWidth = 20;
        private MousePosOnCtrl mpoc;
        private Point pPoint;
        private Rectangle[] sideRects = new Rectangle[4];
        private Rectangle[] smallRects = new Rectangle[8];
        private Size square = new Size(6, 6);

        public FrameUserControl(Control ctrl)
        {
            this.baseControl = ctrl;
            this.BackColor = Color.Transparent;
            this.AddEvents();
            this.CreateBounds();
        }

        private void AddEvents()
        {
            base.Name = "FrameUserControl" + this.baseControl.Name;
            base.MouseDown += new MouseEventHandler(this.FrameUserControl_MouseDown);
            base.MouseMove += new MouseEventHandler(this.FrameUserControl_MouseMove);
            base.MouseUp += new MouseEventHandler(this.FrameUserControl_MouseUp);
            base.KeyUp += new KeyEventHandler(this.FrameUserControl_KeyUp);
            base.Leave += new EventHandler(this.FrameUserControl_Leave);
            base.LostFocus += new EventHandler(this.FrameUserControl_LostFocus);
        }

        private GraphicsPath BuildFrame()
        {
            GraphicsPath path = new GraphicsPath();
            this.sideRects[0] = new Rectangle(0, 0, (base.Width - this.square.Width) - 1, this.square.Height + 1);
            this.sideRects[1] = new Rectangle(0, this.square.Height + 1, this.square.Width + 1, (base.Height - this.square.Height) - 1);
            this.sideRects[2] = new Rectangle(this.square.Width + 1, (base.Height - this.square.Height) - 1, (base.Width - this.square.Width) - 1, this.square.Height + 1);
            this.sideRects[3] = new Rectangle((base.Width - this.square.Width) - 1, 0, this.square.Width + 1, (base.Height - this.square.Height) - 1);
            path.AddRectangle(this.sideRects[0]);
            path.AddRectangle(this.sideRects[1]);
            path.AddRectangle(this.sideRects[2]);
            path.AddRectangle(this.sideRects[3]);
            return path;
        }

        private void ControlMove()
        {
            this.cPoint = Cursor.Position;
            int num = this.cPoint.X - this.pPoint.X;
            int num2 = this.cPoint.Y - this.pPoint.Y;
            switch (this.mpoc)
            {
                case MousePosOnCtrl.TOP:
                    if ((this.baseControl.Height - num2) <= this.MinHeight)
                    {
                        this.baseControl.Top -= this.MinHeight - this.baseControl.Height;
                        this.baseControl.Height = this.MinHeight;
                    }
                    else
                    {
                        this.baseControl.Top += num2;
                        this.baseControl.Height -= num2;
                    }
                    goto Label_04B2;

                case MousePosOnCtrl.RIGHT:
                    if ((this.baseControl.Width + num) <= this.MinWidth)
                    {
                        this.baseControl.Width = this.MinWidth;
                    }
                    else
                    {
                        this.baseControl.Width += num;
                    }
                    goto Label_04B2;

                case MousePosOnCtrl.BOTTOM:
                    if ((this.baseControl.Height + num2) <= this.MinHeight)
                    {
                        this.baseControl.Height = this.MinHeight;
                    }
                    else
                    {
                        this.baseControl.Height += num2;
                    }
                    goto Label_04B2;

                case MousePosOnCtrl.LEFT:
                    if ((this.baseControl.Width - num) <= this.MinWidth)
                    {
                        this.baseControl.Left -= this.MinWidth - this.baseControl.Width;
                        this.baseControl.Width = this.MinWidth;
                    }
                    else
                    {
                        this.baseControl.Left += num;
                        this.baseControl.Width -= num;
                    }
                    goto Label_04B2;

                case MousePosOnCtrl.TOPLEFT:
                    if ((this.baseControl.Height - num2) <= this.MinHeight)
                    {
                        this.baseControl.Top -= this.MinHeight - this.baseControl.Height;
                        this.baseControl.Height = this.MinHeight;
                        break;
                    }
                    this.baseControl.Top += num2;
                    this.baseControl.Height -= num2;
                    break;

                case MousePosOnCtrl.TOPRIGHT:
                    if ((this.baseControl.Height - num2) <= this.MinHeight)
                    {
                        this.baseControl.Top -= this.MinHeight - this.baseControl.Height;
                        this.baseControl.Height = this.MinHeight;
                    }
                    else
                    {
                        this.baseControl.Top += num2;
                        this.baseControl.Height -= num2;
                    }
                    if ((this.baseControl.Width + num) > this.MinWidth)
                    {
                        this.baseControl.Width += num;
                    }
                    else
                    {
                        this.baseControl.Width = this.MinWidth;
                    }
                    goto Label_04B2;

                case MousePosOnCtrl.BOTTOMLEFT:
                    if ((this.baseControl.Height + num2) <= this.MinHeight)
                    {
                        this.baseControl.Height = this.MinHeight;
                    }
                    else
                    {
                        this.baseControl.Height += num2;
                    }
                    if ((this.baseControl.Width - num) > this.MinWidth)
                    {
                        this.baseControl.Left += num;
                        this.baseControl.Width -= num;
                    }
                    else
                    {
                        this.baseControl.Left -= this.MinWidth - this.baseControl.Width;
                        this.baseControl.Width = this.MinWidth;
                    }
                    goto Label_04B2;

                case MousePosOnCtrl.BOTTOMRIGHT:
                    if ((this.baseControl.Height + num2) <= this.MinHeight)
                    {
                        this.baseControl.Height = this.MinHeight;
                    }
                    else
                    {
                        this.baseControl.Height += num2;
                    }
                    if ((this.baseControl.Width + num) > this.MinWidth)
                    {
                        this.baseControl.Width += num;
                    }
                    else
                    {
                        this.baseControl.Width = this.MinWidth;
                    }
                    goto Label_04B2;

                default:
                    goto Label_04B2;
            }
            if ((this.baseControl.Width - num) > this.MinWidth)
            {
                this.baseControl.Left += num;
                this.baseControl.Width -= num;
            }
            else
            {
                this.baseControl.Left -= this.MinWidth - this.baseControl.Width;
                this.baseControl.Width = this.MinWidth;
            }
        Label_04B2:
            this.pPoint = Cursor.Position;
        }

        private void CreateBounds()
        {
            int x = (this.baseControl.Bounds.X - this.square.Width) - 1;
            int y = (this.baseControl.Bounds.Y - this.square.Height) - 1;
            int height = (this.baseControl.Bounds.Height + (this.square.Height * 2)) + 2;
            int width = (this.baseControl.Bounds.Width + (this.square.Width * 2)) + 2;
            base.Bounds = new Rectangle(x, y, width, height);
            base.BringToFront();
            this.SetRectangles();
            base.Region = new Region(this.BuildFrame());
            this.g = base.CreateGraphics();
        }

        public void Draw()
        {
            base.BringToFront();
            Pen pen = new Pen(Color.Black) {
                DashStyle = DashStyle.Dot
            };
            this.g.DrawLines(pen, this.linePoints);
            this.g.FillRectangles(Brushes.White, this.smallRects);
            foreach (Rectangle rectangle in this.smallRects)
            {
                this.g.DrawEllipse(Pens.Black, rectangle);
            }
        }

        private void FrameUserControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down)) || ((e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Left)))
            {
                base.Visible = false;
                Point location = this.baseControl.Location;
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        this.baseControl.Location = new Point(location.X - 1, location.Y);
                        return;

                    case Keys.Up:
                        this.baseControl.Location = new Point(location.X, location.Y - 1);
                        return;

                    case Keys.Right:
                        this.baseControl.Location = new Point(location.X + 1, location.Y);
                        return;

                    case Keys.Down:
                        this.baseControl.Location = new Point(location.X, location.Y + 1);
                        return;
                }
            }
        }

        private void FrameUserControl_Leave(object sender, EventArgs e)
        {
        }

        private void FrameUserControl_LostFocus(object sender, EventArgs e)
        {
        }

        private void FrameUserControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.pPoint = Cursor.Position;
        }

        private void FrameUserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                base.Visible = false;
                MoveControl.DrawDragBound(this.baseControl);
                this.ControlMove();
            }
            else
            {
                base.Visible = true;
                this.SetCursorShape(e.X, e.Y);
            }
        }

        private void FrameUserControl_MouseUp(object sender, MouseEventArgs e)
        {
            this.baseControl.Refresh();
            base.Visible = true;
            this.CreateBounds();
            this.Draw();
        }

        public bool SetCursorShape(int x, int y)
        {
            Point pt = new Point(x, y);
            if (!this.ControlRect.Contains(pt))
            {
                Cursor.Current = Cursors.Arrow;
                return false;
            }
            if (this.smallRects[0].Contains(pt))
            {
                Cursor.Current = Cursors.SizeNWSE;
                this.mpoc = MousePosOnCtrl.TOPLEFT;
            }
            else if (this.smallRects[1].Contains(pt))
            {
                Cursor.Current = Cursors.SizeNESW;
                this.mpoc = MousePosOnCtrl.TOPRIGHT;
            }
            else if (this.smallRects[2].Contains(pt))
            {
                Cursor.Current = Cursors.SizeNESW;
                this.mpoc = MousePosOnCtrl.BOTTOMLEFT;
            }
            else if (this.smallRects[3].Contains(pt))
            {
                Cursor.Current = Cursors.SizeNWSE;
                this.mpoc = MousePosOnCtrl.BOTTOMRIGHT;
            }
            else if (this.sideRects[0].Contains(pt))
            {
                Cursor.Current = Cursors.SizeNS;
                this.mpoc = MousePosOnCtrl.TOP;
            }
            else if (this.sideRects[1].Contains(pt))
            {
                Cursor.Current = Cursors.SizeWE;
                this.mpoc = MousePosOnCtrl.LEFT;
            }
            else if (this.sideRects[2].Contains(pt))
            {
                Cursor.Current = Cursors.SizeNS;
                this.mpoc = MousePosOnCtrl.BOTTOM;
            }
            else if (this.sideRects[3].Contains(pt))
            {
                Cursor.Current = Cursors.SizeWE;
                this.mpoc = MousePosOnCtrl.RIGHT;
            }
            else
            {
                Cursor.Current = Cursors.Arrow;
            }
            return true;
        }

        private void SetRectangles()
        {
            this.smallRects[0] = new Rectangle(new Point(0, 0), this.square);
            this.smallRects[1] = new Rectangle(new Point((base.Width - this.square.Width) - 1, 0), this.square);
            this.smallRects[2] = new Rectangle(new Point(0, (base.Height - this.square.Height) - 1), this.square);
            this.smallRects[3] = new Rectangle(new Point((base.Width - this.square.Width) - 1, (base.Height - this.square.Height) - 1), this.square);
            this.smallRects[4] = new Rectangle(new Point((base.Width / 2) - 1, 0), this.square);
            this.smallRects[5] = new Rectangle(new Point((base.Width / 2) - 1, (base.Height - this.square.Height) - 1), this.square);
            this.smallRects[6] = new Rectangle(new Point(0, (base.Height / 2) - 1), this.square);
            this.smallRects[7] = new Rectangle(new Point((this.square.Width + this.baseControl.Width) + 1, (base.Height / 2) - 1), this.square);
            this.linePoints[0] = new Point(this.square.Width / 2, this.square.Height / 2);
            this.linePoints[1] = new Point((base.Width - (this.square.Width / 2)) - 1, this.square.Height / 2);
            this.linePoints[2] = new Point((base.Width - (this.square.Width / 2)) - 1, base.Height - (this.square.Height / 2));
            this.linePoints[3] = new Point(this.square.Width / 2, (base.Height - (this.square.Height / 2)) - 1);
            this.linePoints[4] = new Point(this.square.Width / 2, this.square.Height / 2);
            this.ControlRect = new Rectangle(new Point(0, 0), base.Bounds.Size);
        }

        private enum MousePosOnCtrl
        {
            NONE,
            TOP,
            RIGHT,
            BOTTOM,
            LEFT,
            TOPLEFT,
            TOPRIGHT,
            BOTTOMLEFT,
            BOTTOMRIGHT
        }
    }
}

