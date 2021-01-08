namespace RecordManagement
{
    partial class ShowHW
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbDevGuid = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.lbDevName = new System.Windows.Forms.Label();
            this.gpDev = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnDrop = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gpDev.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtResult);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.lbDevGuid);
            this.groupBox1.Controls.Add(this.lbMessage);
            this.groupBox1.Controls.Add(this.lbDevName);
            this.groupBox1.Location = new System.Drawing.Point(5, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(698, 330);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测量结果";
            // 
            // txtResult
            // 
            this.txtResult.Enabled = false;
            this.txtResult.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtResult.Location = new System.Drawing.Point(11, 59);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(681, 246);
            this.txtResult.TabIndex = 7;
            this.txtResult.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(298, 26);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(394, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // lbDevGuid
            // 
            this.lbDevGuid.AutoSize = true;
            this.lbDevGuid.Location = new System.Drawing.Point(184, 28);
            this.lbDevGuid.Name = "lbDevGuid";
            this.lbDevGuid.Size = new System.Drawing.Size(0, 12);
            this.lbDevGuid.TabIndex = 1;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(64, 342);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(0, 16);
            this.lbMessage.TabIndex = 0;
            // 
            // lbDevName
            // 
            this.lbDevName.AutoSize = true;
            this.lbDevName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDevName.ForeColor = System.Drawing.Color.Blue;
            this.lbDevName.Location = new System.Drawing.Point(199, 28);
            this.lbDevName.Name = "lbDevName";
            this.lbDevName.Size = new System.Drawing.Size(93, 16);
            this.lbDevName.TabIndex = 0;
            this.lbDevName.Text = "身高体重仪";
            // 
            // gpDev
            // 
            this.gpDev.Controls.Add(this.button3);
            this.gpDev.Controls.Add(this.btnDrop);
            this.gpDev.Controls.Add(this.btnSave);
            this.gpDev.Location = new System.Drawing.Point(16, -1);
            this.gpDev.Name = "gpDev";
            this.gpDev.Size = new System.Drawing.Size(687, 88);
            this.gpDev.TabIndex = 3;
            this.gpDev.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Image = global::RecordManagement.Properties.Resources.ComTest;
            this.button3.Location = new System.Drawing.Point(21, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(68, 68);
            this.button3.TabIndex = 0;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnDrop
            // 
            this.btnDrop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDrop.Image = global::RecordManagement.Properties.Resources.ComExit;
            this.btnDrop.Location = new System.Drawing.Point(580, 14);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(68, 68);
            this.btnDrop.TabIndex = 6;
            this.btnDrop.UseVisualStyleBackColor = true;
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Image = global::RecordManagement.Properties.Resources.ComSave;
            this.btnSave.Location = new System.Drawing.Point(480, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 68);
            this.btnSave.TabIndex = 5;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ShowHW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 423);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpDev);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowHW";
            this.Text = "ShowHW";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpDev.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbDevGuid;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label lbDevName;
        private System.Windows.Forms.GroupBox gpDev;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnDrop;
        private System.Windows.Forms.Button btnSave;
    }
}