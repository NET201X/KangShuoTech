namespace KangShuoTech.Utilities.CommonControl
{
    using Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class DuWuUserControl : UserControl
    {
        private IContainer components;
        private Label label67;
        private Label lbCaption;
        private bool MState;
        private Panel panel3;
        private RadioButton rdNo;
        private RadioButton rdYes;
        private TextBox tbMothed;
        private TextBox tbName;
        private bool UState;
        string IDCardType = ConfigHelper.GetNode("IdCardType");
        public DuWuUserControl()
        {
            this.InitializeComponent();
            if (IDCardType.Equals("3"))//二代机
            {
                SetFont(this);
            }
        }
        private void SetFont(Control controls)
        {
            controls.Font = new System.Drawing.Font("宋体", 15F);
            foreach (Control ct in controls.Controls)
            {
                ct.Font = new System.Drawing.Font("宋体", 15F);
                SetFont(ct);
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbCaption = new System.Windows.Forms.Label();
            this.tbMothed = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdYes = new System.Windows.Forms.RadioButton();
            this.rdNo = new System.Windows.Forms.RadioButton();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbName.Location = new System.Drawing.Point(86, 2);
            this.tbName.MaxLength = 20;
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(120, 23);
            this.tbName.TabIndex = 1;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // lbCaption
            // 
            this.lbCaption.AutoSize = true;
            this.lbCaption.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCaption.Location = new System.Drawing.Point(3, 6);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(77, 14);
            this.lbCaption.TabIndex = 0;
            this.lbCaption.Text = "放射性物质";
            // 
            // tbMothed
            // 
            this.tbMothed.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMothed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMothed.Location = new System.Drawing.Point(448, 2);
            this.tbMothed.MaxLength = 20;
            this.tbMothed.Name = "tbMothed";
            this.tbMothed.ReadOnly = true;
            this.tbMothed.Size = new System.Drawing.Size(242, 23);
            this.tbMothed.TabIndex = 4;
            this.tbMothed.TextChanged += new System.EventHandler(this.tbMothed_TextChanged);
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label67.Location = new System.Drawing.Point(212, 6);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(70, 14);
            this.label67.TabIndex = 2;
            this.label67.Text = "防护措施:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdYes);
            this.panel3.Controls.Add(this.rdNo);
            this.panel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel3.Location = new System.Drawing.Point(310, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(132, 24);
            this.panel3.TabIndex = 3;
            // 
            // rdYes
            // 
            this.rdYes.AutoSize = true;
            this.rdYes.Enabled = false;
            this.rdYes.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdYes.Location = new System.Drawing.Point(74, 5);
            this.rdYes.Name = "rdYes";
            this.rdYes.Size = new System.Drawing.Size(39, 18);
            this.rdYes.TabIndex = 1;
            this.rdYes.TabStop = true;
            this.rdYes.Text = "有";
            this.rdYes.UseVisualStyleBackColor = true;
            // 
            // rdNo
            // 
            this.rdNo.AutoSize = true;
            this.rdNo.Enabled = false;
            this.rdNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdNo.Location = new System.Drawing.Point(7, 5);
            this.rdNo.Name = "rdNo";
            this.rdNo.Size = new System.Drawing.Size(39, 18);
            this.rdNo.TabIndex = 0;
            this.rdNo.TabStop = true;
            this.rdNo.Text = "无";
            this.rdNo.UseVisualStyleBackColor = true;
            this.rdNo.CheckedChanged += new System.EventHandler(this.rdNo_CheckedChanged);
            // 
            // DuWuUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbCaption);
            this.Controls.Add(this.tbMothed);
            this.Controls.Add(this.label67);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.Name = "DuWuUserControl";
            this.Size = new System.Drawing.Size(701, 27);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void rdNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdNo.Checked)
            {
                this.tbMothed.Clear();
            }
        }

        private void SetCdEnabled(bool _enabled)
        {
            if (this.MState != _enabled)
            {
                if (!_enabled)
                {
                    this.tbMothed.Text = "";
                }
                this.tbMothed.ReadOnly = !_enabled;
                this.rdYes.Enabled = _enabled;
                this.rdNo.Enabled = _enabled;
                this.rdNo.Checked = false;
                this.rdYes.Checked = false;
                this.MState = _enabled;
            }
        }

        private void SetEnabled(bool p_enabled)
        {
            if (this.UState != p_enabled)
            {
                if (p_enabled)
                {
                    this.rdYes.Checked = true;
                }
                else
                {
                    this.rdNo.Checked = true;
                }
                this.UState = p_enabled;
            }
        }

        public void SetPanelEnabled(bool p_enable)
        {
            if (!p_enable)
            {
                this.tbMothed.Text = "";
                this.tbName.Text = "";
            }
            this.tbName.ReadOnly = !p_enable;
        }

        private void tbMothed_TextChanged(object sender, EventArgs e)
        {
            this.SetEnabled((sender as TextBox).Text != "");
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            this.SetCdEnabled((sender as TextBox).Text != "");
        }

        public string CCaption
        {
            get
            {
                return this.lbCaption.Text;
            }
            set
            {
                this.lbCaption.Text = value;
            }
        }

        public string IsProject
        {
            get
            {
                if (this.rdYes.Checked)
                {
                    return "2";
                }
                return "1";
            }
            set
            {
                if (value == "1")
                {
                    this.rdNo.Checked = true;
                }
                else if (value == "2")
                {
                    this.rdYes.Checked = true;
                }
            }
        }

        public string ProtectMothed
        {
            get
            {
                return this.tbMothed.Text.Trim();
            }
            set
            {
                this.tbMothed.Text = value;
            }
        }

        public string TypeName
        {
            get
            {
                return this.tbName.Text;
            }
            set
            {
                this.tbName.Text = value;
            }
        }
    }
}

