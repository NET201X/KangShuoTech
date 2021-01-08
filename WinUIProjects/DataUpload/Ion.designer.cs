namespace DataUpload
{
    partial class Ion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BloodSugar));
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
            this.rbWebsite = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.datePn.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.progressBar1.Location = new System.Drawing.Point(3, 143);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(488, 25);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            // 
            // labUploadnum
            // 
            this.labUploadnum.AutoSize = true;
            this.labUploadnum.Location = new System.Drawing.Point(101, 118);
            this.labUploadnum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUploadnum.Name = "labUploadnum";
            this.labUploadnum.Size = new System.Drawing.Size(15, 15);
            this.labUploadnum.TabIndex = 15;
            this.labUploadnum.Text = "0";
            // 
            // labCountnum
            // 
            this.labCountnum.AutoSize = true;
            this.labCountnum.Location = new System.Drawing.Point(101, 89);
            this.labCountnum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labCountnum.Name = "labCountnum";
            this.labCountnum.Size = new System.Drawing.Size(15, 15);
            this.labCountnum.TabIndex = 18;
            this.labCountnum.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "已经上传：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 89);
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
            this.btnDataUpload.Location = new System.Drawing.Point(3, 172);
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
            this.panel1.Controls.Add(this.rbWebsite);
            this.panel1.Location = new System.Drawing.Point(117, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 32);
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
            // rbWebsite
            // 
            this.rbWebsite.AutoSize = true;
            this.rbWebsite.Location = new System.Drawing.Point(81, 6);
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
            // BloodSugar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 268);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labUploadnum);
            this.Controls.Add(this.labCountnum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnDataUpload);
            this.Controls.Add(this.datePn);
            this.Controls.Add(this.ckbCheckDate);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Ion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "离子同步";
            this.datePn.ResumeLayout(false);
            this.datePn.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}