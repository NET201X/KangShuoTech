namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class InputFormEx : Form
    {
        private Button btnCancel;
        private Button btnOk;
        public bool CanBeNull = true;
        private string caption = "";
        private IContainer components;
        private string input = "";
        private Label lbResult;
        private int maxBytesCount;
        private TextBox textBox1;

        public InputFormEx()
        {
            this.InitializeComponent();
            this.ErrorInput = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!this.CanBeNull && (this.textBox1.Text.Trim() == ""))
            {
                this.lbResult.Text = "不能为空!";
                this.lbResult.ForeColor = Color.Red;
            }
            else if (this.ErrorInput)
            {
                this.lbResult.Text = "输入有误!";
            }
            else
            {
                this.input = this.textBox1.Text;
                base.DialogResult = DialogResult.OK;
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

        private void InputFormEx_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = this.input;
        }

        private void InitializeComponent()
        {
            this.textBox1 = new TextBox();
            this.btnOk = new Button();
            this.btnCancel = new Button();
            this.lbResult = new Label();
            base.SuspendLayout();
            this.textBox1.Location = new Point(0x55, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x102, 90);
            this.textBox1.TabIndex = 0;
            this.btnOk.Location = new Point(0x5d, 0xa5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(90, 0x21);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new EventHandler(this.btnOk_Click);
            this.btnCancel.Location = new Point(0xf6, 0xa5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(90, 0x21);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.lbResult.BackColor = SystemColors.Control;
            this.lbResult.Font = new Font("宋体", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.lbResult.ForeColor = Color.Black;
            this.lbResult.Location = new Point(0x12d, 9);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new Size(0x74, 0x26);
            this.lbResult.TabIndex = 0x5e;
            this.lbResult.TextAlign = ContentAlignment.MiddleCenter;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x1ad, 0xe0);
            base.Controls.Add(this.lbResult);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOk);
            base.Controls.Add(this.textBox1);
            this.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "InputFormEx";
            base.ShowIcon = false;
            this.Text = "输入:";
            base.Load += new EventHandler(this.InputFormEx_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void Other_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.GetEncoding("GB2312").GetByteCount(this.textBox1.Text) > this.MaxBytesCount)
            {
                this.ErrorInput = true;
                this.textBox1.BackColor = Color.Salmon;
            }
            else
            {
                this.ErrorInput = false;
                this.textBox1.BackColor = Color.WhiteSmoke;
            }
        }

        public bool ErrorInput { get; set; }

        public string InputString
        {
            get
            {
                return this.input;
            }
            set
            {
                this.input = value;
            }
        }

        public int MaxBytesCount
        {
            get
            {
                return this.maxBytesCount;
            }
            set
            {
                if (value > 0)
                {
                    this.maxBytesCount = value;
                    this.textBox1.TextChanged += new EventHandler(this.Other_TextChanged);
                }
            }
        }

        public string MCaption
        {
            get
            {
                return this.caption;
            }
            set
            {
                this.caption = value;
                this.Text = this.caption;
            }
        }
    }
}

