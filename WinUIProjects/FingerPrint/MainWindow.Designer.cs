namespace FingerPrint
{
    partial class MainWindow
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
            this.edtRC_Result = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReConc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // edtRC_Result
            // 
            this.edtRC_Result.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(179)))), ((int)(((byte)(224)))));
            this.edtRC_Result.Font = new System.Drawing.Font("宋体", 16F);
            this.edtRC_Result.ForeColor = System.Drawing.Color.White;
            this.edtRC_Result.Location = new System.Drawing.Point(16, 16);
            this.edtRC_Result.Multiline = true;
            this.edtRC_Result.Name = "edtRC_Result";
            this.edtRC_Result.Size = new System.Drawing.Size(612, 274);
            this.edtRC_Result.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 18F);
            this.btnClose.Location = new System.Drawing.Point(687, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 86);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 18F);
            this.btnSave.Location = new System.Drawing.Point(687, 207);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 86);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "录入";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReConc
            // 
            this.btnReConc.Font = new System.Drawing.Font("宋体", 18F);
            this.btnReConc.Location = new System.Drawing.Point(687, 108);
            this.btnReConc.Name = "btnReConc";
            this.btnReConc.Size = new System.Drawing.Size(140, 86);
            this.btnReConc.TabIndex = 10;
            this.btnReConc.Text = "重试";
            this.btnReConc.UseVisualStyleBackColor = true;
            this.btnReConc.Visible = false;
            this.btnReConc.Click += new System.EventHandler(this.btnReConc_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(862, 330);
            this.ControlBox = false;
            this.Controls.Add(this.btnReConc);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.edtRC_Result);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "指纹登录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox edtRC_Result;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReConc;
    }
}