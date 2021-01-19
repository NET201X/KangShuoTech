namespace KangShuo
{
    partial class FrmBackData
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
            this.lbMess = new System.Windows.Forms.Label();
            this.btnData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMess
            // 
            this.lbMess.AutoSize = true;
            this.lbMess.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lbMess.Location = new System.Drawing.Point(16, 27);
            this.lbMess.Name = "lbMess";
            this.lbMess.Size = new System.Drawing.Size(14, 14);
            this.lbMess.TabIndex = 0;
            this.lbMess.Text = " ";
            // 
            // btnData
            // 
            this.btnData.Font = new System.Drawing.Font("宋体", 11F);
            this.btnData.Location = new System.Drawing.Point(12, 64);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(260, 77);
            this.btnData.TabIndex = 1;
            this.btnData.Text = "数据备份";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // FrmBackData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 145);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.lbMess);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBackData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据备份";
            this.Load += new System.EventHandler(this.FrmBackData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMess;
        private System.Windows.Forms.Button btnData;
    }
}