﻿namespace ArchiveInfo
{
    partial class frmFollowDataUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFollowDataUpdate));
            this.labUploadnum = new System.Windows.Forms.Label();
            this.labCountnum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btndataupload = new System.Windows.Forms.Button();
            this.datePn = new System.Windows.Forms.Panel();
            this.dtpend = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpstart = new System.Windows.Forms.DateTimePicker();
            this.ckbcheckdate = new System.Windows.Forms.CheckBox();
            this.datePn.SuspendLayout();
            this.SuspendLayout();
            // 
            // labUploadnum
            // 
            this.labUploadnum.AutoSize = true;
            this.labUploadnum.Location = new System.Drawing.Point(139, 81);
            this.labUploadnum.Name = "labUploadnum";
            this.labUploadnum.Size = new System.Drawing.Size(17, 18);
            this.labUploadnum.TabIndex = 33;
            this.labUploadnum.Text = "0";
            // 
            // labCountnum
            // 
            this.labCountnum.AutoSize = true;
            this.labCountnum.Location = new System.Drawing.Point(139, 52);
            this.labCountnum.Name = "labCountnum";
            this.labCountnum.Size = new System.Drawing.Size(17, 18);
            this.labCountnum.TabIndex = 34;
            this.labCountnum.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 32;
            this.label2.Text = "已刷新条数：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 18);
            this.label5.TabIndex = 31;
            this.label5.Text = "共有数据：";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 111);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(464, 20);
            this.progressBar1.TabIndex = 30;
            this.progressBar1.Visible = false;
            // 
            // btndataupload
            // 
            this.btndataupload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndataupload.BackgroundImage")));
            this.btndataupload.Location = new System.Drawing.Point(3, 136);
            this.btndataupload.Name = "btndataupload";
            this.btndataupload.Size = new System.Drawing.Size(467, 100);
            this.btndataupload.TabIndex = 29;
            this.btndataupload.UseVisualStyleBackColor = true;
            this.btndataupload.Click += new System.EventHandler(this.btndataupload_Click);
            // 
            // datePn
            // 
            this.datePn.Controls.Add(this.dtpend);
            this.datePn.Controls.Add(this.label1);
            this.datePn.Controls.Add(this.dtpstart);
            this.datePn.Location = new System.Drawing.Point(115, 3);
            this.datePn.Name = "datePn";
            this.datePn.Size = new System.Drawing.Size(355, 32);
            this.datePn.TabIndex = 28;
            // 
            // dtpend
            // 
            this.dtpend.Enabled = false;
            this.dtpend.Location = new System.Drawing.Point(193, 3);
            this.dtpend.Name = "dtpend";
            this.dtpend.Size = new System.Drawing.Size(160, 27);
            this.dtpend.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "-";
            // 
            // dtpstart
            // 
            this.dtpstart.Enabled = false;
            this.dtpstart.Location = new System.Drawing.Point(2, 3);
            this.dtpstart.Name = "dtpstart";
            this.dtpstart.Size = new System.Drawing.Size(162, 27);
            this.dtpstart.TabIndex = 0;
            // 
            // ckbcheckdate
            // 
            this.ckbcheckdate.AutoSize = true;
            this.ckbcheckdate.Location = new System.Drawing.Point(12, 11);
            this.ckbcheckdate.Name = "ckbcheckdate";
            this.ckbcheckdate.Size = new System.Drawing.Size(117, 22);
            this.ckbcheckdate.TabIndex = 27;
            this.ckbcheckdate.Text = "体检时间：";
            this.ckbcheckdate.UseVisualStyleBackColor = true;
            this.ckbcheckdate.CheckedChanged += new System.EventHandler(this.ckbcheckdate_CheckedChanged);
            // 
            // frmFollowDataUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 239);
            this.Controls.Add(this.labUploadnum);
            this.Controls.Add(this.labCountnum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btndataupload);
            this.Controls.Add(this.datePn);
            this.Controls.Add(this.ckbcheckdate);
            this.Font = new System.Drawing.Font("宋体", 13F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFollowDataUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "随访同步";
            this.datePn.ResumeLayout(false);
            this.datePn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labUploadnum;
        private System.Windows.Forms.Label labCountnum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Button btndataupload;
        private System.Windows.Forms.Panel datePn;
        private System.Windows.Forms.DateTimePicker dtpend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpstart;
        private System.Windows.Forms.CheckBox ckbcheckdate;
    }
}