namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class MoreIllnessUserControl : UserControl
    {
        private string[] citems;
        private IContainer components;
        private FlowLayoutPanel FLPanel;
        private string gCaption;
        private GroupBox groupBox1;
        private bool groupBoxVisiable = true;
        private List<CheckBox> list_ckx = new List<CheckBox>();
        private int maxBytesCount;
        private TextBox tbOther;

        public MoreIllnessUserControl()
        {
            this.InitializeComponent();
            this.MaxBytesCount = 500;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public string GetResult()
        {
            string str = "";
            for (int i = 0; i < this.list_ckx.Count; i++)
            {
                if ((this.list_ckx[i].CheckState != CheckState.Indeterminate) && this.list_ckx[i].Checked)
                {
                    str = str + string.Format("{0},", i + 1);
                }
            }
            return str.TrimEnd(new char[] { ',' });
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.FLPanel = new FlowLayoutPanel();
            this.tbOther = new TextBox();
            this.groupBox1.SuspendLayout();
            this.FLPanel.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.FLPanel);
            this.groupBox1.Dock = DockStyle.Fill;
            this.groupBox1.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.groupBox1.Location = new Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x17e, 0x73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.FLPanel.Controls.Add(this.tbOther);
            this.FLPanel.Dock = DockStyle.Fill;
            this.FLPanel.Location = new Point(3, 0x13);
            this.FLPanel.Name = "FLPanel";
            this.FLPanel.Size = new Size(0x178, 0x5d);
            this.FLPanel.TabIndex = 1;
            this.tbOther.Location = new Point(3, 3);
            this.tbOther.Name = "tbOther";
            this.tbOther.ReadOnly = true;
            this.tbOther.Size = new Size(0x74, 0x17);
            this.tbOther.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.groupBox1);
            this.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.Name = "UCMoreIllness";
            base.Size = new Size(0x17e, 0x73);
            this.groupBox1.ResumeLayout(false);
            this.FLPanel.ResumeLayout(false);
            this.FLPanel.PerformLayout();
            base.ResumeLayout(false);
        }

        private void Other_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.GetEncoding("GB2312").GetByteCount(this.tbOther.Text) > this.MaxBytesCount)
            {
                this.ErrorInput = true;
                this.tbOther.BackColor = Color.Salmon;
            }
            else
            {
                this.ErrorInput = false;
                this.tbOther.BackColor = Color.WhiteSmoke;
            }
        }

        private void temp_CheckedChanged(object sender, EventArgs e)
        {
            CheckState @unchecked;
            bool flag;
            CheckBox box = sender as CheckBox;
            if (box.Checked)
            {
                @unchecked = CheckState.Unchecked;
                flag = false;
            }
            else
            {
                @unchecked = CheckState.Unchecked;
                flag = true;
                this.tbOther.Clear();
            }
            for (int i = 0; i < this.list_ckx.Count; i++)
            {
                if (this.list_ckx[i] != box)
                {
                    this.list_ckx[i].CheckState = @unchecked;
                    this.list_ckx[i].Enabled = flag;
                }
            }
        }

        private void temp_other_checkedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                this.tbOther.ReadOnly = false;
            }
            else
            {
                this.tbOther.Clear();
                this.tbOther.ReadOnly = true;
            }
        }

        public void TransInfo(string info, string other)
        {
            if (!string.IsNullOrEmpty(info))
            {
                string str = info;
                char[] separator = new char[] { ',' };
                foreach (string str2 in str.Split(separator))
                {
                    int num;
                    if (int.TryParse(str2, out num))
                    {
                        this.list_ckx[num - 1].Checked = true;
                    }
                }
                if (!string.IsNullOrEmpty(other))
                {
                    this.list_ckx[this.list_ckx.Count - 1].Checked = true;
                    this.tbOther.Text = other;
                }
            }
        }

        public string[] CItems
        {
            get
            {
                return this.citems;
            }
            set
            {
                this.citems = value;
                this.FLPanel.SuspendLayout();
                for (int i = 0; i < this.citems.Length; i++)
                {
                    CheckBox item = new CheckBox {
                        Size = new Size(120, 0x17),
                        Text = this.citems[i]
                    };
                    this.list_ckx.Add(item);
                    this.FLPanel.Controls.Add(item);
                    if ((item.Text == "未发现") || (item.Text == "无症状"))
                    {
                        item.CheckedChanged += new EventHandler(this.temp_CheckedChanged);
                    }
                    else if (item.Text == "其他")
                    {
                        item.CheckedChanged += new EventHandler(this.temp_other_checkedChanged);
                    }
                }
                this.FLPanel.Controls.SetChildIndex(this.tbOther, this.FLPanel.Controls.Count - 1);
                this.FLPanel.ResumeLayout(false);
                this.Refresh();
            }
        }

        public bool ErrorInput { get; set; }

        public string GCaption
        {
            get
            {
                return this.gCaption;
            }
            set
            {
                this.gCaption = value;
                this.groupBox1.Text = value;
            }
        }

        public bool GroupBoxVisiable
        {
            set
            {
                this.groupBoxVisiable = value;
                base.SuspendLayout();
                this.groupBox1.Controls.Clear();
                this.groupBox1.Visible = false;
                base.ResumeLayout();
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
                    this.tbOther.TextChanged += new EventHandler(this.Other_TextChanged);
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GroupBox MyGroupBox
        {
            get
            {
                return this.groupBox1;
            }
        }

        public string Other
        {
            get
            {
                return this.tbOther.Text;
            }
        }

        public bool OtherVisiable
        {
            get
            {
                return this.tbOther.Visible;
            }
            set
            {
                this.tbOther.Visible = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TextBox TbOther
        {
            get
            {
                return this.tbOther;
            }
        }
    }
}

