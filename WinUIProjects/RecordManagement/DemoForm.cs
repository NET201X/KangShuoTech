namespace ArchiveInfo
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class Form1 : Form
    {
        private IContainer components;
        private MainFormUserControl MainFormUserControl1;
        private MainItemUserControl mainItemUserControl;

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
            this.mainItemUserControl = new ArchiveInfo.MainItemUserControl();
            this.SuspendLayout();
            // 
            // MainFormUserControl1
            // 
            this.mainItemUserControl.BackColor = System.Drawing.Color.White;
            this.mainItemUserControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainFormUserControl1.BackgroundImage")));
            this.mainItemUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainItemUserControl.IDCardNo = "36050219360726464X";
            this.mainItemUserControl.Location = new System.Drawing.Point(5, 5);
            this.mainItemUserControl.Name = "MainFormUserControl1";
            this.mainItemUserControl.Size = new System.Drawing.Size(1200, 534);
            this.mainItemUserControl.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1264, 600);
            this.Controls.Add(this.mainItemUserControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }
    }
}

