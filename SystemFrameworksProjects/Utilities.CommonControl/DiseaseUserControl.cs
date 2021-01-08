namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class DiseaseUserControl : UserControl
    {
        public CheckBox checkBox1;
        private IContainer components;
        private DateTimePicker dtpTime;
        private string inputStr;
        private Label label213;

        public DiseaseUserControl()
        {
            this.InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.dtpTime.Enabled = true;
            }
            else
            {
                this.dtpTime.Enabled = false;
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

        private void InitializeComponent()
        {
            this.dtpTime = new DateTimePicker();
            this.label213 = new Label();
            this.checkBox1 = new CheckBox();
            base.SuspendLayout();
            this.dtpTime.CalendarFont = new Font("宋体", 10f);
            this.dtpTime.Enabled = false;
            this.dtpTime.Format = DateTimePickerFormat.Custom;
            this.dtpTime.Location = new Point(0xdf, 2);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new Size(150, 0x17);
            this.dtpTime.TabIndex = 30;
            this.label213.AutoSize = true;
            this.label213.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label213.Location = new Point(0x93, 8);
            this.label213.Name = "label213";
            this.label213.Size = new Size(70, 14);
            this.label213.TabIndex = 0x1d;
            this.label213.Text = "确诊时间:";
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new Font("宋体", 10f);
            this.checkBox1.Location = new Point(3, 7);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(0x8a, 0x12);
            this.checkBox1.TabIndex = 0x1f;
            this.checkBox1.Text = "慢性阻塞性肺疾病";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
            base.AutoScaleDimensions = new SizeF(7f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.checkBox1);
            base.Controls.Add(this.dtpTime);
            base.Controls.Add(this.label213);
            this.Font = new Font("宋体", 10f);
            base.Name = "UCDisease";
            base.Size = new Size(0x180, 0x1b);
            base.Load += new EventHandler(this.UCDisease_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void UCDisease_Load(object sender, EventArgs e)
        {
            this.dtpTime.MaxDate = DateTime.Today;
        }

        public string CCaption
        {
            get
            {
                return this.checkBox1.Text;
            }
            set
            {
                this.checkBox1.Text = value;
            }
        }

        public bool HasValue
        {
            get
            {
                return this.checkBox1.Checked;
            }
        }

        public string InputStr
        {
            get
            {
                return this.inputStr;
            }
            set
            {
                if (value != null)
                {
                    this.inputStr = value;
                    this.checkBox1.Text = string.Format("其他({0})", this.inputStr);
                }
            }
        }

        public string occurTime
        {
            get
            {
                if (!this.checkBox1.Checked)
                {
                    return string.Empty;
                }
                return this.dtpTime.Text;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    DateTime time;
                    this.checkBox1.Checked = true;
                    if (DateTime.TryParse(value, out time))
                    {
                        this.dtpTime.Value = time.Date;
                    }
                }
            }
        }
    }
}

