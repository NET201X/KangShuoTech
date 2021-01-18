namespace RecordManagement
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class Form1 : Form
    {
        private IContainer components;
        private MainFormUserControl MainFormUserControl1;

        public Form1()
        {
            this.InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MainFormUserControl1 = new RecordManagement.MainFormUserControl();
            this.SuspendLayout();
            // 
            // MainFormUserControl1
            // 
            this.MainFormUserControl1.BackColor = System.Drawing.Color.White;
            this.MainFormUserControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainFormUserControl1.BackgroundImage")));
            this.MainFormUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainFormUserControl1.IDCardNo = "36050219360726464X";
            this.MainFormUserControl1.Location = new System.Drawing.Point(5, 5);
            this.MainFormUserControl1.Name = "MainFormUserControl1";
            this.MainFormUserControl1.Size = new System.Drawing.Size(1200, 534);
            this.MainFormUserControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1264, 600);
            this.Controls.Add(this.MainFormUserControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }
    }
}

