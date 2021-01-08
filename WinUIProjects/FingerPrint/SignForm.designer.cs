namespace FingerPrint
{
    partial class SignForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignForm));
            this.btnClose = new System.Windows.Forms.Button();
            this.axHWPenSign1 = new AxHWPenSignLib.AxHWPenSign();
            this.btnDefine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axHWPenSign1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 18F);
            this.btnClose.Location = new System.Drawing.Point(162, 150);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 49);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // axHWPenSign1
            // 
            this.axHWPenSign1.Enabled = true;
            this.axHWPenSign1.Location = new System.Drawing.Point(22, 12);
            this.axHWPenSign1.Name = "axHWPenSign1";
            this.axHWPenSign1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axHWPenSign1.OcxState")));
            this.axHWPenSign1.Size = new System.Drawing.Size(264, 120);
            this.axHWPenSign1.TabIndex = 144;
            this.axHWPenSign1.Enter += new System.EventHandler(this.axHWPenSign1_Enter);
            this.axHWPenSign1.Leave += new System.EventHandler(this.axHWPenSign1_Leave);
            // 
            // btnDefine
            // 
            this.btnDefine.Font = new System.Drawing.Font("宋体", 18F);
            this.btnDefine.Location = new System.Drawing.Point(53, 150);
            this.btnDefine.Margin = new System.Windows.Forms.Padding(2);
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(93, 49);
            this.btnDefine.TabIndex = 145;
            this.btnDefine.Text = "确定";
            this.btnDefine.UseVisualStyleBackColor = true;
            this.btnDefine.Click += new System.EventHandler(this.btnDefine_Click);
            // 
            // SignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(308, 215);
            this.ControlBox = false;
            this.Controls.Add(this.btnDefine);
            this.Controls.Add(this.axHWPenSign1);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SignForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "签字";
            ((System.ComponentModel.ISupportInitialize)(this.axHWPenSign1)).EndInit();
            this.Load += new System.EventHandler(this.SignForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private AxHWPenSignLib.AxHWPenSign axHWPenSign1;
        private System.Windows.Forms.Button btnDefine;
    }
}