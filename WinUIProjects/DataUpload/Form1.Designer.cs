namespace DataUpload
{
    partial class Form1
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
            this.mainControl21 = new DataUpload.MainControl();
            this.SuspendLayout();
            // 
            // mainControl21
            // 
            this.mainControl21.Location = new System.Drawing.Point(1, 2);
            this.mainControl21.Name = "mainControl21";
            this.mainControl21.Size = new System.Drawing.Size(1500, 800);
            this.mainControl21.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 800);
            this.Controls.Add(this.mainControl21);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "数据同步";
            this.Text = "数据同步";
            this.ResumeLayout(false);

        }

        #endregion

        private MainControl mainControl21;
    }
}