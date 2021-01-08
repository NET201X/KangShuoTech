namespace KangShuoTech.Utilities.CommonControl
{
    partial class YesNoControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel30 = new System.Windows.Forms.Panel();
            this.CkbNo = new System.Windows.Forms.CheckBox();
            this.CkbYes = new System.Windows.Forms.CheckBox();
            this.txbWeek = new System.Windows.Forms.TextBox();
            this.txbMouth = new System.Windows.Forms.TextBox();
            this.txbSalt = new System.Windows.Forms.TextBox();
            this.labName = new System.Windows.Forms.Label();
            this.txbDay = new System.Windows.Forms.TextBox();
            this.panel30.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.CkbNo);
            this.panel30.Controls.Add(this.CkbYes);
            this.panel30.Location = new System.Drawing.Point(0, 3);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(96, 21);
            this.panel30.TabIndex = 0;
            // 
            // CkbNo
            // 
            this.CkbNo.AutoSize = true;
            this.CkbNo.Location = new System.Drawing.Point(56, 2);
            this.CkbNo.Name = "CkbNo";
            this.CkbNo.Size = new System.Drawing.Size(36, 16);
            this.CkbNo.TabIndex = 1;
            this.CkbNo.Text = "否";
            this.CkbNo.UseVisualStyleBackColor = true;
            this.CkbNo.CheckedChanged += new System.EventHandler(this.CkbNo_CheckedChanged);
            // 
            // CkbYes
            // 
            this.CkbYes.AutoSize = true;
            this.CkbYes.Location = new System.Drawing.Point(15, 2);
            this.CkbYes.Name = "CkbYes";
            this.CkbYes.Size = new System.Drawing.Size(36, 16);
            this.CkbYes.TabIndex = 0;
            this.CkbYes.Text = "是";
            this.CkbYes.UseVisualStyleBackColor = true;
            this.CkbYes.CheckedChanged += new System.EventHandler(this.CkbYes_CheckedChanged);
            // 
            // txbWeek
            // 
            this.txbWeek.Location = new System.Drawing.Point(201, 3);
            this.txbWeek.Name = "txbWeek";
            this.txbWeek.ReadOnly = true;
            this.txbWeek.Size = new System.Drawing.Size(94, 21);
            this.txbWeek.TabIndex = 3;
            // 
            // txbMouth
            // 
            this.txbMouth.Location = new System.Drawing.Point(300, 3);
            this.txbMouth.Name = "txbMouth";
            this.txbMouth.ReadOnly = true;
            this.txbMouth.Size = new System.Drawing.Size(95, 21);
            this.txbMouth.TabIndex = 4;
            // 
            // txbSalt
            // 
            this.txbSalt.Location = new System.Drawing.Point(399, 3);
            this.txbSalt.Name = "txbSalt";
            this.txbSalt.ReadOnly = true;
            this.txbSalt.Size = new System.Drawing.Size(155, 21);
            this.txbSalt.TabIndex = 5;
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(119, 9);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(41, 12);
            this.labName.TabIndex = 2;
            this.labName.Text = "label1";
            this.labName.Visible = false;
            // 
            // txbDay
            // 
            this.txbDay.Location = new System.Drawing.Point(100, 3);
            this.txbDay.Name = "txbDay";
            this.txbDay.ReadOnly = true;
            this.txbDay.Size = new System.Drawing.Size(94, 21);
            this.txbDay.TabIndex = 1;
            // 
            // YesNoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txbDay);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.txbSalt);
            this.Controls.Add(this.txbMouth);
            this.Controls.Add(this.txbWeek);
            this.Controls.Add(this.panel30);
            this.Name = "YesNoControl";
            this.Size = new System.Drawing.Size(568, 29);
            this.panel30.ResumeLayout(false);
            this.panel30.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel30;
        public System.Windows.Forms.CheckBox CkbNo;
        public System.Windows.Forms.CheckBox CkbYes;
        private System.Windows.Forms.TextBox txbWeek;
        private System.Windows.Forms.TextBox txbMouth;
        private System.Windows.Forms.TextBox txbSalt;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.TextBox txbDay;
    }
}
