namespace BTCHITBM
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    public class NotifyWindow : Form
    {
        public int ActualHeight;
        public int ActualWidth;
        public BackgroundStyles BackgroundStyle;
        public System.Drawing.Drawing2D.Blend Blend;
        private Button btnGiveup;
        private Button btnSave;
        protected const int CBS_HOT = 2;
        protected const int CBS_NORMAL = 1;
        protected const int CBS_PUSHED = 3;
        public ClockStates ClockState;
        protected bool closeHot;
        protected bool closePressed;
        public Color GradientColor;
        public Font HoverFont;
        protected const int HWND_TOPMOST = -1;
        public Color PressedColor;
        protected Rectangle rClose;
        protected Rectangle rDisplay;
        protected Rectangle rGlobClose;
        protected Rectangle rGlobDisplay;
        protected Rectangle rGlobText;
        protected Rectangle rGlobTitle;
        protected Rectangle rScreen;
        protected Rectangle rText;
        protected Rectangle rTitle;
        public System.Drawing.StringFormat StringFormat;
        protected const int SW_SHOWNOACTIVATE = 4;
        protected const int SWP_NOACTIVATE = 0x10;
        public Color TextColor;
        protected bool textHot;
        protected bool textPressed;
        public string Title;
        public Color TitleColor;
        public Font TitleFont;
        protected bool titleHot;
        public Font TitleHoverFont;
        protected bool titlePressed;
        protected System.Windows.Forms.Timer viewClock;
        public bool WaitOnMouseOver;
        public int WaitTime;
        protected const int WP_CLOSEBUTTON = 0x12;

        public event EventHandler TextClicked;

        public event EventHandler TitleClicked;

        public NotifyWindow()
        {
            base.SetStyle(ControlStyles.UserMouse, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            base.ShowInTaskbar = false;
            base.FormBorderStyle = FormBorderStyle.None;
            base.StartPosition = FormStartPosition.Manual;
            this.BackgroundStyle = BackgroundStyles.VerticalGradient;
            this.ClockState = ClockStates.None;
            this.BackColor = Color.SteelBlue;
            this.GradientColor = Color.WhiteSmoke;
            this.PressedColor = Color.Gray;
            this.TitleColor = SystemColors.ControlText;
            this.TextColor = SystemColors.ControlText;
            this.WaitOnMouseOver = true;
            this.ActualWidth = 130;
            this.ActualHeight = 110;
            this.WaitTime = 0x2af8;
        }

        public NotifyWindow(string text) : this()
        {
            this.Text = text;
        }

        public NotifyWindow(string title, string text) : this()
        {
            this.Title = title;
            this.Text = text;
        }

        [DllImport("UxTheme.dll")]
        protected static extern void CloseThemeData(IntPtr hTheme);
        protected virtual void drawBorder(Graphics fx)
        {
            fx.DrawRectangle(Pens.Silver, 2, 2, base.Width - 4, this.ActualHeight - 4);
            fx.DrawLine(Pens.Silver, 0, 0, base.Width, 0);
            fx.DrawLine(Pens.White, 0, 1, base.Width, 1);
            fx.DrawLine(Pens.DarkGray, 3, 3, base.Width - 4, 3);
            fx.DrawLine(Pens.DimGray, 4, 4, base.Width - 5, 4);
            fx.DrawLine(Pens.Silver, 0, 0, 0, this.ActualHeight);
            fx.DrawLine(Pens.White, 1, 1, 1, this.ActualHeight);
            fx.DrawLine(Pens.DarkGray, 3, 3, 3, this.ActualHeight - 4);
            fx.DrawLine(Pens.DimGray, 4, 4, 4, this.ActualHeight - 5);
            fx.DrawLine(Pens.DarkGray, 1, this.ActualHeight - 1, base.Width - 1, this.ActualHeight - 1);
            fx.DrawLine(Pens.White, 3, this.ActualHeight - 3, base.Width - 3, this.ActualHeight - 3);
            fx.DrawLine(Pens.Silver, 4, this.ActualHeight - 4, base.Width - 4, this.ActualHeight - 4);
            fx.DrawLine(Pens.DarkGray, base.Width - 1, 1, base.Width - 1, this.ActualHeight - 1);
            fx.DrawLine(Pens.White, base.Width - 3, 3, base.Width - 3, this.ActualHeight - 3);
            fx.DrawLine(Pens.Silver, base.Width - 4, 4, base.Width - 4, this.ActualHeight - 4);
        }

        protected virtual void drawCloseButton(Graphics fx)
        {
            if (this.visualStylesEnabled())
            {
                this.drawThemeCloseButton(fx);
            }
            else
            {
                this.drawLegacyCloseButton(fx);
            }
        }

        protected void drawLegacyCloseButton(Graphics fx)
        {
            ButtonState state = !this.closePressed ? ButtonState.Normal : ButtonState.Pushed;
            ControlPaint.DrawCaptionButton(fx, this.rClose, CaptionButton.Close, state);
        }

        [DllImport("UxTheme.dll")]
        protected static extern void DrawThemeBackground(IntPtr hTheme, IntPtr hDC, int partId, int stateId, ref RECT rect, ref RECT clipRect);
        protected void drawThemeCloseButton(Graphics fx)
        {
            IntPtr hTheme = OpenThemeData(base.Handle, "Window");
            if (hTheme == IntPtr.Zero)
            {
                this.drawLegacyCloseButton(fx);
            }
            else
            {
                int stateId = !this.closePressed ? (!this.closeHot ? 1 : 2) : 3;
                RECT rect = new RECT(this.rClose);
                RECT clipRect = rect;
                IntPtr hdc = fx.GetHdc();
                DrawThemeBackground(hTheme, hdc, 0x12, stateId, ref rect, ref clipRect);
                fx.ReleaseHdc(hdc);
                CloseThemeData(hTheme);
            }
        }

        private void init_rcv()
        {
            this.btnSave = new Button();
            this.btnSave.BackColor = Color.Transparent;
            this.btnSave.FlatAppearance.BorderColor = Color.Black;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.ImageAlign = ContentAlignment.MiddleRight;
            this.btnSave.Location = new Point(0xd6, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x4c, 0x1b);
            this.btnSave.TabIndex = 80;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
        }

        [DllImport("UxTheme.dll")]
        protected static extern int IsThemeActive();
        public void Notify()
        {
            int num;
            if ((this.Text == null) || (this.Text.Length < 1))
            {
                throw new Exception("You must set NotifyWindow.Text before calling Notify()");
            }
            base.Width = this.ActualWidth;
            this.rScreen = Screen.GetWorkingArea(Screen.PrimaryScreen.Bounds);
            base.Height = 0;
            base.Top = this.rScreen.Bottom;
            base.Left = (this.rScreen.Width - base.Width) - 11;
            if (this.HoverFont == null)
            {
                this.HoverFont = new Font(this.Font, this.Font.Style | FontStyle.Underline);
            }
            if (this.TitleFont == null)
            {
                this.TitleFont = this.Font;
            }
            if (this.TitleHoverFont == null)
            {
                this.TitleHoverFont = new Font(this.TitleFont, this.TitleFont.Style | FontStyle.Underline);
            }
            if (this.StringFormat == null)
            {
                this.StringFormat = new System.Drawing.StringFormat();
                this.StringFormat.Alignment = StringAlignment.Center;
                this.StringFormat.LineAlignment = StringAlignment.Center;
                this.StringFormat.Trimming = StringTrimming.EllipsisWord;
            }
            this.rDisplay = new Rectangle(0, 0, base.Width, this.ActualHeight);
            this.rClose = new Rectangle(base.Width - 0x15, 10, 13, 13);
            if (this.Title != null)
            {
                using (Graphics graphics = base.CreateGraphics())
                {
                    SizeF ef = graphics.MeasureString(this.Title, this.TitleFont, (int) ((this.ActualWidth - this.rClose.Width) - 0x16), this.StringFormat);
                    this.rTitle = new Rectangle(11, 12, (int) Math.Ceiling((double) ef.Width), (int) Math.Ceiling((double) ef.Height));
                    num = (int) Math.Max(Math.Ceiling((double) ((ef.Height + this.rTitle.Top) + 2.0)), (double) (this.rClose.Bottom + 5));
                    goto Label_020C;
                }
            }
            num = this.rClose.Bottom + 1;
            this.rTitle = new Rectangle(-1, -1, 1, 1);
        Label_020C:
            this.rText = new Rectangle(11, num, this.ActualWidth - 0x16, this.ActualHeight - ((int) (num * 1.5)));
            this.rGlobClose = this.rClose;
            this.rGlobClose.Offset(base.Left, this.rScreen.Bottom - this.ActualHeight);
            this.rGlobText = this.rText;
            this.rGlobText.Offset(base.Left, this.rScreen.Bottom - this.ActualHeight);
            this.rGlobTitle = this.rTitle;
            if (this.Title != null)
            {
                this.rGlobTitle.Offset(base.Left, this.rScreen.Bottom - this.ActualHeight);
            }
            this.rGlobDisplay = this.rDisplay;
            this.rGlobDisplay.Offset(base.Left, this.rScreen.Bottom - this.ActualHeight);
            this.rGlobClose = this.rClose;
            this.rGlobClose.Offset(base.Left, this.rScreen.Bottom - this.ActualHeight);
            this.rGlobDisplay = this.rDisplay;
            this.rGlobDisplay.Offset(base.Left, this.rScreen.Bottom - this.ActualHeight);
            ShowWindow(base.Handle, 4);
            SetWindowPos(base.Handle, -1, (this.rScreen.Width - this.ActualWidth) - 11, this.rScreen.Bottom, this.ActualWidth, 0, 0x10);
            this.viewClock = new System.Windows.Forms.Timer();
            this.viewClock.Tick += new EventHandler(this.viewTimer);
            this.viewClock.Interval = 1;
            this.viewClock.Start();
            this.ClockState = ClockStates.Opening;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.rGlobClose.Contains(Cursor.Position))
                {
                    this.closePressed = true;
                    this.closeHot = false;
                    base.Invalidate();
                }
                else if (this.rGlobText.Contains(Cursor.Position))
                {
                    this.textPressed = true;
                    base.Invalidate();
                }
                else if ((this.Title != null) && this.rGlobTitle.Contains(Cursor.Position))
                {
                    this.titlePressed = true;
                    base.Invalidate();
                }
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (((this.Title != null) && this.rGlobTitle.Contains(Cursor.Position)) && (!this.textPressed && !this.closePressed))
            {
                this.Cursor = Cursors.Hand;
                this.titleHot = true;
                this.textHot = false;
                this.closeHot = false;
                base.Invalidate();
            }
            else if ((this.rGlobText.Contains(Cursor.Position) && !this.titlePressed) && !this.closePressed)
            {
                this.Cursor = Cursors.Hand;
                this.textHot = true;
                this.titleHot = false;
                this.closeHot = false;
                base.Invalidate();
            }
            else if ((this.rGlobClose.Contains(Cursor.Position) && !this.titlePressed) && !this.textPressed)
            {
                this.Cursor = Cursors.Hand;
                this.closeHot = true;
                this.titleHot = false;
                this.textHot = false;
                base.Invalidate();
            }
            else if (((this.textHot || this.titleHot) || this.closeHot) && ((!this.titlePressed && !this.textPressed) && !this.closePressed))
            {
                this.Cursor = Cursors.Default;
                this.titleHot = false;
                this.textHot = false;
                this.closeHot = false;
                base.Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.closePressed)
                {
                    this.Cursor = Cursors.Default;
                    this.closePressed = false;
                    this.closeHot = false;
                    base.Invalidate();
                    if (this.rGlobClose.Contains(Cursor.Position))
                    {
                        base.Close();
                    }
                }
                else if (this.textPressed)
                {
                    this.Cursor = Cursors.Default;
                    this.textPressed = false;
                    this.textHot = false;
                    base.Invalidate();
                    if (this.rGlobText.Contains(Cursor.Position))
                    {
                        base.Close();
                        if (this.TextClicked != null)
                        {
                            this.TextClicked(this, new EventArgs());
                        }
                    }
                }
                else if (this.titlePressed)
                {
                    this.Cursor = Cursors.Default;
                    this.titlePressed = false;
                    this.titleHot = false;
                    base.Invalidate();
                    if (this.rGlobTitle.Contains(Cursor.Position))
                    {
                        base.Close();
                        if (this.TitleClicked != null)
                        {
                            this.TitleClicked(this, new EventArgs());
                        }
                    }
                }
            }
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.drawCloseButton(e.Graphics);
            if (this.Title != null)
            {
                Font font = !this.titleHot ? this.TitleFont : this.TitleHoverFont;
                using (SolidBrush brush = new SolidBrush(!this.titlePressed ? this.TitleColor : this.PressedColor))
                {
                    e.Graphics.DrawString(this.Title, font, brush, this.rTitle, this.StringFormat);
                }
            }
            if (!this.textHot)
            {
                Font font1 = this.Font;
            }
            using (SolidBrush brush2 = new SolidBrush(!this.textPressed ? this.TextColor : this.PressedColor))
            {
                Font font2 = new Font("宋体", 12f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
                e.Graphics.DrawString(this.Text, font2, brush2, this.rText, this.StringFormat);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            LinearGradientMode backwardDiagonal;
            if (this.BackgroundStyle == BackgroundStyles.Solid)
            {
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillRectangle(brush, this.rDisplay);
                    goto Label_00A7;
                }
            }
            switch (this.BackgroundStyle)
            {
                case BackgroundStyles.BackwardDiagonalGradient:
                    backwardDiagonal = LinearGradientMode.BackwardDiagonal;
                    break;

                case BackgroundStyles.ForwardDiagonalGradient:
                    backwardDiagonal = LinearGradientMode.ForwardDiagonal;
                    break;

                case BackgroundStyles.HorizontalGradient:
                    backwardDiagonal = LinearGradientMode.Horizontal;
                    break;

                default:
                    backwardDiagonal = LinearGradientMode.Vertical;
                    break;
            }
            using (LinearGradientBrush brush2 = new LinearGradientBrush(this.rDisplay, this.GradientColor, this.BackColor, backwardDiagonal))
            {
                if (this.Blend != null)
                {
                    brush2.Blend = this.Blend;
                }
                e.Graphics.FillRectangle(brush2, this.rDisplay);
            }
        Label_00A7:
            this.drawBorder(e.Graphics);
        }

        [DllImport("UxTheme.dll")]
        protected static extern IntPtr OpenThemeData(IntPtr hWnd, [MarshalAs(UnmanagedType.LPTStr)] string classList);
        public void SetDimensions(int width, int height)
        {
            this.ActualWidth = width;
            this.ActualHeight = height;
        }

        [DllImport("user32.dll")]
        protected static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        protected static extern bool ShowWindow(IntPtr hWnd, int flags);
        protected void viewTimer(object sender, EventArgs e)
        {
            switch (this.ClockState)
            {
                case ClockStates.Opening:
                    if ((base.Top - 2) > (this.rScreen.Height - this.ActualHeight))
                    {
                        base.Top -= 2;
                        base.Height += 2;
                        return;
                    }
                    base.Top = this.rScreen.Height - this.ActualHeight;
                    base.Height = this.ActualHeight;
                    this.ClockState = ClockStates.Showing;
                    this.viewClock.Interval = this.WaitTime;
                    return;

                case ClockStates.Closing:
                    base.Top += 2;
                    base.Height -= 2;
                    if (base.Top >= this.rScreen.Height)
                    {
                        this.ClockState = ClockStates.None;
                        this.viewClock.Stop();
                        this.viewClock.Dispose();
                        base.Close();
                        return;
                    }
                    return;

                case ClockStates.Showing:
                    if (!this.WaitOnMouseOver || !this.rGlobDisplay.Contains(Cursor.Position))
                    {
                        this.viewClock.Interval = 1;
                        this.ClockState = ClockStates.Closing;
                        return;
                    }
                    return;
            }
        }

        protected bool visualStylesEnabled()
        {
            try
            {
                return (IsThemeActive() == 1);
            }
            catch (DllNotFoundException)
            {
                return false;
            }
        }

        public enum BackgroundStyles
        {
            BackwardDiagonalGradient,
            ForwardDiagonalGradient,
            HorizontalGradient,
            VerticalGradient,
            Solid
        }

        public enum ClockStates
        {
            Opening,
            Closing,
            Showing,
            None
        }

        [StructLayout(LayoutKind.Explicit)]
        protected struct RECT
        {
            [FieldOffset(12)]
            public int Bottom;
            [FieldOffset(0)]
            public int Left;
            [FieldOffset(8)]
            public int Right;
            [FieldOffset(4)]
            public int Top;

            public RECT(Rectangle bounds)
            {
                this.Left = bounds.Left;
                this.Top = bounds.Top;
                this.Right = bounds.Right;
                this.Bottom = bounds.Bottom;
            }
        }
    }
}

