namespace FocusGroup
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class Form1 : Form
    {
        private IContainer components;
        private MainItemUserControl ucMainItem1;

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
            //ComponentResourceManager manager = new ComponentResourceManager(typeof(Form1));
            this.ucMainItem1 = new MainItemUserControl();
            base.SuspendLayout();
            this.ucMainItem1.BackgroundImage = (Image)resources.GetObject("ucMainItem1.BackgroundImage");
            this.ucMainItem1.BorderStyle = BorderStyle.FixedSingle;
            this.ucMainItem1.IDCardNo = "370101199211111111";
            this.ucMainItem1.Location = new Point(0x4c, 0x30);
            this.ucMainItem1.Name = "ucMainItem1";
            this.ucMainItem1.Size = new Size(0x3eb, 510);
            this.ucMainItem1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x455, 0x26b);
            base.Controls.Add(this.ucMainItem1);
            base.Name = "Form1";
            this.Text = "Form1";
            base.ResumeLayout(false);
        }
    }
}

