namespace DataUpload
{
    partial class DataUploadUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataUploadUI));
            this.ckbCheckDate = new System.Windows.Forms.CheckBox();
            this.datePn = new System.Windows.Forms.Panel();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labUploadnum = new System.Windows.Forms.Label();
            this.labCountnum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDataUpload = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbShared = new System.Windows.Forms.RadioButton();
            this.rbSocket = new System.Windows.Forms.RadioButton();
            this.rbWebsite = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.chkNewUrine = new System.Windows.Forms.CheckBox();
            this.btnDataUpload2 = new System.Windows.Forms.Button();
            this.btnDataUpload3 = new System.Windows.Forms.Button();
            this.panTotal = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.rbTwo = new System.Windows.Forms.RadioButton();
            this.rbOne = new System.Windows.Forms.RadioButton();
            this.panDeviceType = new System.Windows.Forms.Panel();
            this.datePn.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panTotal.SuspendLayout();
            this.panDeviceType.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckbCheckDate
            // 
            this.ckbCheckDate.AutoSize = true;
            this.ckbCheckDate.Checked = true;
            this.ckbCheckDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbCheckDate.Location = new System.Drawing.Point(9, 18);
            this.ckbCheckDate.Margin = new System.Windows.Forms.Padding(4);
            this.ckbCheckDate.Name = "ckbCheckDate";
            this.ckbCheckDate.Size = new System.Drawing.Size(101, 19);
            this.ckbCheckDate.TabIndex = 1;
            this.ckbCheckDate.Text = "体检时间：";
            this.ckbCheckDate.UseVisualStyleBackColor = true;
            this.ckbCheckDate.CheckedChanged += new System.EventHandler(this.ckbCheckDate_CheckedChanged);
            // 
            // datePn
            // 
            this.datePn.Controls.Add(this.dtpEnd);
            this.datePn.Controls.Add(this.label1);
            this.datePn.Controls.Add(this.dtpStart);
            this.datePn.Location = new System.Drawing.Point(117, 8);
            this.datePn.Margin = new System.Windows.Forms.Padding(4);
            this.datePn.Name = "datePn";
            this.datePn.Size = new System.Drawing.Size(373, 40);
            this.datePn.TabIndex = 2;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(192, 8);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(167, 24);
            this.dtpEnd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "-";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(3, 8);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(164, 24);
            this.dtpStart.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.Location = new System.Drawing.Point(3, 158);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(488, 25);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            // 
            // labUploadnum
            // 
            this.labUploadnum.AutoSize = true;
            this.labUploadnum.Location = new System.Drawing.Point(380, 8);
            this.labUploadnum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUploadnum.Name = "labUploadnum";
            this.labUploadnum.Size = new System.Drawing.Size(15, 15);
            this.labUploadnum.TabIndex = 15;
            this.labUploadnum.Text = "0";
            // 
            // labCountnum
            // 
            this.labCountnum.AutoSize = true;
            this.labCountnum.Location = new System.Drawing.Point(98, 8);
            this.labCountnum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labCountnum.Name = "labCountnum";
            this.labCountnum.Size = new System.Drawing.Size(15, 15);
            this.labCountnum.TabIndex = 18;
            this.labCountnum.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "已经上传：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "共有数据：";
            // 
            // btnDataUpload
            // 
            this.btnDataUpload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDataUpload.BackgroundImage")));
            this.btnDataUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDataUpload.Location = new System.Drawing.Point(3, 187);
            this.btnDataUpload.Margin = new System.Windows.Forms.Padding(4);
            this.btnDataUpload.Name = "btnDataUpload";
            this.btnDataUpload.Size = new System.Drawing.Size(488, 94);
            this.btnDataUpload.TabIndex = 7;
            this.btnDataUpload.UseVisualStyleBackColor = true;
            this.btnDataUpload.Click += new System.EventHandler(this.btnDataUpload_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbShared);
            this.panel1.Controls.Add(this.rbSocket);
            this.panel1.Controls.Add(this.rbWebsite);
            this.panel1.Location = new System.Drawing.Point(117, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 32);
            this.panel1.TabIndex = 24;
            // 
            // rbShared
            // 
            this.rbShared.AutoSize = true;
            this.rbShared.Checked = true;
            this.rbShared.Location = new System.Drawing.Point(5, 6);
            this.rbShared.Name = "rbShared";
            this.rbShared.Size = new System.Drawing.Size(55, 19);
            this.rbShared.TabIndex = 19;
            this.rbShared.TabStop = true;
            this.rbShared.Text = "共享";
            this.rbShared.UseVisualStyleBackColor = true;
            // 
            // rbSocket
            // 
            this.rbSocket.AutoSize = true;
            this.rbSocket.Location = new System.Drawing.Point(179, 6);
            this.rbSocket.Name = "rbSocket";
            this.rbSocket.Size = new System.Drawing.Size(55, 19);
            this.rbSocket.TabIndex = 21;
            this.rbSocket.Text = "通信";
            this.rbSocket.UseVisualStyleBackColor = true;
            this.rbSocket.Visible = false;
            this.rbSocket.CheckedChanged += new System.EventHandler(this.rbSocket_CheckedChanged);
            // 
            // rbWebsite
            // 
            this.rbWebsite.AutoSize = true;
            this.rbWebsite.Location = new System.Drawing.Point(92, 6);
            this.rbWebsite.Name = "rbWebsite";
            this.rbWebsite.Size = new System.Drawing.Size(55, 19);
            this.rbWebsite.TabIndex = 21;
            this.rbWebsite.Text = "网站";
            this.rbWebsite.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "同步方式：";
            // 
            // chkNewUrine
            // 
            this.chkNewUrine.AutoSize = true;
            this.chkNewUrine.Location = new System.Drawing.Point(376, 60);
            this.chkNewUrine.Name = "chkNewUrine";
            this.chkNewUrine.Size = new System.Drawing.Size(101, 19);
            this.chkNewUrine.TabIndex = 44;
            this.chkNewUrine.Text = "是否新尿机";
            this.chkNewUrine.UseVisualStyleBackColor = true;
            this.chkNewUrine.Visible = false;
            this.chkNewUrine.CheckedChanged += new System.EventHandler(this.chkNewUrine_CheckedChanged);
            // 
            // btnDataUpload2
            // 
            this.btnDataUpload2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDataUpload2.BackgroundImage")));
            this.btnDataUpload2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDataUpload2.Location = new System.Drawing.Point(3, 281);
            this.btnDataUpload2.Margin = new System.Windows.Forms.Padding(4);
            this.btnDataUpload2.Name = "btnDataUpload2";
            this.btnDataUpload2.Size = new System.Drawing.Size(488, 94);
            this.btnDataUpload2.TabIndex = 47;
            this.btnDataUpload2.UseVisualStyleBackColor = true;
            this.btnDataUpload2.Visible = false;
            this.btnDataUpload2.Click += new System.EventHandler(this.btnDataUpload2_Click);
            // 
            // btnDataUpload3
            // 
            this.btnDataUpload3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDataUpload3.BackgroundImage")));
            this.btnDataUpload3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDataUpload3.Location = new System.Drawing.Point(3, 376);
            this.btnDataUpload3.Margin = new System.Windows.Forms.Padding(4);
            this.btnDataUpload3.Name = "btnDataUpload3";
            this.btnDataUpload3.Size = new System.Drawing.Size(488, 94);
            this.btnDataUpload3.TabIndex = 47;
            this.btnDataUpload3.UseVisualStyleBackColor = true;
            this.btnDataUpload3.Visible = false;
            this.btnDataUpload3.Click += new System.EventHandler(this.btnDataUpload3_Click);
            // 
            // panTotal
            // 
            this.panTotal.Controls.Add(this.label5);
            this.panTotal.Controls.Add(this.label2);
            this.panTotal.Controls.Add(this.labCountnum);
            this.panTotal.Controls.Add(this.labUploadnum);
            this.panTotal.Location = new System.Drawing.Point(3, 127);
            this.panTotal.Name = "panTotal";
            this.panTotal.Size = new System.Drawing.Size(487, 27);
            this.panTotal.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 46;
            this.label4.Text = "设备类型：";
            // 
            // rbTwo
            // 
            this.rbTwo.AutoSize = true;
            this.rbTwo.Location = new System.Drawing.Point(207, 6);
            this.rbTwo.Name = "rbTwo";
            this.rbTwo.Size = new System.Drawing.Size(55, 19);
            this.rbTwo.TabIndex = 21;
            this.rbTwo.Text = "二代";
            this.rbTwo.UseVisualStyleBackColor = true;
            // 
            // rbOne
            // 
            this.rbOne.AutoSize = true;
            this.rbOne.Checked = true;
            this.rbOne.Location = new System.Drawing.Point(119, 6);
            this.rbOne.Name = "rbOne";
            this.rbOne.Size = new System.Drawing.Size(55, 19);
            this.rbOne.TabIndex = 19;
            this.rbOne.TabStop = true;
            this.rbOne.Text = "一代";
            this.rbOne.UseVisualStyleBackColor = true;
            // 
            // panDeviceType
            // 
            this.panDeviceType.Controls.Add(this.rbOne);
            this.panDeviceType.Controls.Add(this.rbTwo);
            this.panDeviceType.Controls.Add(this.label4);
            this.panDeviceType.Location = new System.Drawing.Point(3, 90);
            this.panDeviceType.Name = "panDeviceType";
            this.panDeviceType.Size = new System.Drawing.Size(430, 32);
            this.panDeviceType.TabIndex = 45;
            this.panDeviceType.Visible = false;
            // 
            // DataUploadUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 469);
            this.Controls.Add(this.panTotal);
            this.Controls.Add(this.btnDataUpload3);
            this.Controls.Add(this.btnDataUpload2);
            this.Controls.Add(this.panDeviceType);
            this.Controls.Add(this.chkNewUrine);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnDataUpload);
            this.Controls.Add(this.datePn);
            this.Controls.Add(this.ckbCheckDate);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataUploadUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据同步";
            this.Load += new System.EventHandler(this.DataUploadUI_Load);
            this.datePn.ResumeLayout(false);
            this.datePn.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panTotal.ResumeLayout(false);
            this.panTotal.PerformLayout();
            this.panDeviceType.ResumeLayout(false);
            this.panDeviceType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbCheckDate;
        private System.Windows.Forms.Panel datePn;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Button btnDataUpload;
        private System.Windows.Forms.Label labUploadnum;
        private System.Windows.Forms.Label labCountnum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbShared;
        private System.Windows.Forms.RadioButton rbWebsite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkNewUrine;
        public System.Windows.Forms.Button btnDataUpload2;
        public System.Windows.Forms.Button btnDataUpload3;
        private System.Windows.Forms.Panel panTotal;
        private System.Windows.Forms.RadioButton rbSocket;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbTwo;
        private System.Windows.Forms.RadioButton rbOne;
        private System.Windows.Forms.Panel panDeviceType;
    }
}