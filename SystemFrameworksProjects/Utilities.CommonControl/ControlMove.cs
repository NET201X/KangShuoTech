namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class ControlMove
    {
        private Cursor[] _arrArrow = new Cursor[] { Cursors.SizeNWSE, Cursors.SizeNS, Cursors.SizeNESW, Cursors.SizeWE, Cursors.SizeNWSE, Cursors.SizeNS, Cursors.SizeNESW, Cursors.SizeWE };
        private bool _dragging;
        public bool _IsCtrlKey;
        private bool _IsMouseDown;
        private Label[] _lbl = new Label[8];
        private Control _MControl;
        private Point _oPointClicked;
        private int _starth;
        private int _startl;
        private int _startt;
        private int _startw;
        private TextBox _textbox;
        public Rectangle actArea;
        private Color BOX_COLOR = Color.White;
        private const int BOX_SIZE = 7;
        private const int MIN_SIZE = 10;

        public ControlMove(Control moveControl, bool canResize)
        {
            this._MControl = moveControl;
            this._MControl.MouseDown += new MouseEventHandler(this.Control_MouseDown);
            this._MControl.MouseUp += new MouseEventHandler(this.Control_MouseUp);
            this._MControl.MouseMove += new MouseEventHandler(this.Control_MouseMove);
            this._MControl.Click += new EventHandler(this.Control_Click);
            for (int i = 0; i < 8; i++)
            {
                this._lbl[i] = new Label();
                this._lbl[i].TabIndex = i;
                this._lbl[i].FlatStyle = FlatStyle.Flat;
                this._lbl[i].BorderStyle = BorderStyle.FixedSingle;
                this._lbl[i].BackColor = this.BOX_COLOR;
                this._lbl[i].Cursor = this._arrArrow[i];
                this._lbl[i].Text = "";
                this._lbl[i].BringToFront();
                this._lbl[i].MouseDown += new MouseEventHandler(this.handle_MouseDown);
                if (canResize)
                {
                    this._lbl[i].MouseMove += new MouseEventHandler(this.handle_MouseMove);
                }
                this._lbl[i].MouseUp += new MouseEventHandler(this.handle_MouseUp);
            }
            this.CreateTextBox();
            this.Create();
            this.actArea = this._MControl.Parent.ClientRectangle;
        }

        private void Control_Click(object sender, EventArgs e)
        {
            this._textbox.Focus();
            this._MControl = sender as Control;
            this.MoveHandles();
            if (!this._IsCtrlKey)
            {
                for (int i = 0; i < this._MControl.Parent.Controls.Count; i++)
                {
                    if ((this._MControl.Parent.Controls[i].Text.Trim().Length == 0) && (this._MControl.Parent.Controls[i] is Label))
                    {
                        this._MControl.Parent.Controls[i].Visible = false;
                    }
                }
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            this._IsMouseDown = true;
            this._oPointClicked = new Point(e.X, e.Y);
            for (int i = 0; i < 8; i++)
            {
                this._MControl.Parent.Controls.Add(this._lbl[i]);
                this._lbl[i].BringToFront();
            }
            this.HideHandles();
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._IsMouseDown)
            {
                int num = (this._MControl.Left + e.X) - this._oPointClicked.X;
                int num2 = (this._MControl.Top + e.Y) - this._oPointClicked.Y;
                int width = this._MControl.Width;
                int height = this._MControl.Height;
                int num5 = (num < this.actArea.X) ? this.actArea.X : (((num + width) > (this.actArea.Width + this.actArea.X)) ? ((this.actArea.Width + this.actArea.X) - width) : num);
                int num6 = (num2 < this.actArea.Y) ? this.actArea.Y : (((num2 + height) > (this.actArea.Height + this.actArea.Y)) ? ((this.actArea.Height + this.actArea.Y) - height) : num2);
                this._MControl.Left = num5;
                this._MControl.Top = num6;
                this.ControlLocality();
            }
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            this._IsMouseDown = false;
            this.MoveHandles();
            this.ShowHandles();
            this._MControl.Visible = true;
        }

        private void ControlLocality()
        {
            if (this._MControl.Location.X < this.actArea.X)
            {
                this._MControl.Visible = false;
                this._MControl.Left = this.actArea.X;
            }
            if (this._MControl.Location.Y < this.actArea.Y)
            {
                this._MControl.Visible = false;
                this._MControl.Top = this.actArea.Y;
            }
            if ((this._MControl.Location.X + this._MControl.Width) > (this.actArea.X + this.actArea.Width))
            {
                this._MControl.Visible = false;
                this._MControl.Left = (this.actArea.Width - this._MControl.Width) + this.actArea.X;
            }
            if ((this._MControl.Location.Y + this._MControl.Height) > (this.actArea.Height + this.actArea.Y))
            {
                this._MControl.Visible = false;
                this._MControl.Top = (this.actArea.Height - this._MControl.Height) + this.actArea.Y;
            }
        }

        private void Create()
        {
            for (int i = 0; i < 8; i++)
            {
                this._MControl.Parent.Controls.Add(this._lbl[i]);
                this._lbl[i].BringToFront();
            }
            this.HideHandles();
        }

        private void CreateTextBox()
        {
            this._textbox = new TextBox();
            this._textbox.CreateControl();
            this._textbox.Parent = this._MControl.Parent;
            this._textbox.Width = 0;
            this._textbox.Height = 0;
            this._textbox.TabStop = true;
            this._textbox.KeyDown += new KeyEventHandler(this.textBox_KeyDown);
        }

        private void handle_MouseDown(object sender, MouseEventArgs e)
        {
            this._dragging = true;
            this._startl = this._MControl.Left;
            this._startt = this._MControl.Top;
            this._startw = this._MControl.Width;
            this._starth = this._MControl.Height;
            this.HideHandles();
        }

        private void handle_MouseMove(object sender, MouseEventArgs e)
        {
            int left = this._MControl.Left;
            int width = this._MControl.Width;
            int top = this._MControl.Top;
            int height = this._MControl.Height;
            if (this._dragging)
            {
                Control control = sender as Control;
                Point point = new Point(control.Location.X + e.X, control.Location.Y + e.Y);
                if (((point.X >= this.actArea.X) && (point.X <= ((this.actArea.X + this.actArea.Width) - 3))) && ((point.Y >= this.actArea.Y) && (point.Y <= ((this.actArea.Y + this.actArea.Height) - 3))))
                {
                    switch (((Control) sender).TabIndex)
                    {
                        case 0:
                            left = ((this._startl + e.X) < ((this._startl + this._startw) - 10)) ? (this._startl + e.X) : ((this._startl + this._startw) - 10);
                            top = ((this._startt + e.Y) < ((this._startt + this._starth) - 10)) ? (this._startt + e.Y) : ((this._startt + this._starth) - 10);
                            width = (this._startl + this._startw) - this._MControl.Left;
                            height = (this._startt + this._starth) - this._MControl.Top;
                            break;

                        case 1:
                            top = ((this._startt + e.Y) < ((this._startt + this._starth) - 10)) ? (this._startt + e.Y) : ((this._startt + this._starth) - 10);
                            height = (this._startt + this._starth) - this._MControl.Top;
                            break;

                        case 2:
                            width = ((this._startw + e.X) > 10) ? (this._startw + e.X) : 10;
                            top = ((this._startt + e.Y) < ((this._startt + this._starth) - 10)) ? (this._startt + e.Y) : ((this._startt + this._starth) - 10);
                            height = (this._startt + this._starth) - this._MControl.Top;
                            break;

                        case 3:
                            width = ((this._startw + e.X) > 10) ? (this._startw + e.X) : 10;
                            break;

                        case 4:
                            width = ((this._startw + e.X) > 10) ? (this._startw + e.X) : 10;
                            height = ((this._starth + e.Y) > 10) ? (this._starth + e.Y) : 10;
                            break;

                        case 5:
                            height = ((this._starth + e.Y) > 10) ? (this._starth + e.Y) : 10;
                            break;

                        case 6:
                            left = ((this._startl + e.X) < ((this._startl + this._startw) - 10)) ? (this._startl + e.X) : ((this._startl + this._startw) - 10);
                            width = (this._startl + this._startw) - this._MControl.Left;
                            height = ((this._starth + e.Y) > 10) ? (this._starth + e.Y) : 10;
                            break;

                        case 7:
                            left = ((this._startl + e.X) < ((this._startl + this._startw) - 10)) ? (this._startl + e.X) : ((this._startl + this._startw) - 10);
                            width = (this._startl + this._startw) - this._MControl.Left;
                            break;
                    }
                    this._MControl.SetBounds((left < 0) ? 0 : left, (top < 0) ? 0 : top, width, height);
                }
            }
        }

        private void handle_MouseUp(object sender, MouseEventArgs e)
        {
            this._dragging = false;
            this.MoveHandles();
            this.ShowHandles();
        }

        private void HideHandles()
        {
            for (int i = 0; i < 8; i++)
            {
                this._lbl[i].Visible = false;
            }
        }

        private void MoveHandles()
        {
            int num = this._MControl.Left - 7;
            int num2 = this._MControl.Top - 7;
            int num3 = this._MControl.Width + 7;
            int num4 = this._MControl.Height + 7;
            int num5 = 3;
            int[] numArray = new int[] { num + num5, num + (num3 / 2), (num + num3) - num5, (num + num3) - num5, (num + num3) - num5, num + (num3 / 2), num + num5, num + num5 };
            int[] numArray2 = new int[] { num2 + num5, num2 + num5, num2 + num5, num2 + (num4 / 2), (num2 + num4) - num5, (num2 + num4) - num5, (num2 + num4) - num5, num2 + (num4 / 2) };
            for (int i = 0; i < 8; i++)
            {
                this._lbl[i].SetBounds(numArray[i], numArray2[i], 7, 7);
            }
        }

        private void ShowHandles()
        {
            if (this._MControl != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    this._lbl[i].Visible = true;
                }
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (((e.KeyValue == 0x25) || (e.KeyValue == 0x26)) || ((e.KeyValue == 0x27) || (e.KeyValue == 40)))
            {
                if (e.KeyValue == 0x25)
                {
                    this._MControl.Left--;
                }
                if (e.KeyValue == 0x26)
                {
                    this._MControl.Top--;
                }
                if (e.KeyValue == 0x27)
                {
                    this._MControl.Left++;
                }
                if (e.KeyValue == 40)
                {
                    this._MControl.Top++;
                }
                this.MoveHandles();
                this.ControlLocality();
                this._MControl.Visible = true;
            }
            int keyValue = e.KeyValue;
            if (e.KeyValue == 0x11)
            {
                this._IsCtrlKey = true;
            }
        }
    }
}

