namespace KangShuoTech.Utilities.CommonUI
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ChildContentForm : Form
    {
        private IContainer components;
        public Action<string> upStateInfo;

        public ChildContentForm()
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
            this.SuspendLayout();
            // 
            // ChildContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 700);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChildContentForm";
            this.Text = "ChildContent";
            this.ResumeLayout(false);

        }

        public virtual void SetControlRequired(params TextBox[] controls)
        {
            foreach (TextBox box in controls)
            {
                box.BackColor = SystemColors.Info;
                box.BorderStyle = BorderStyle.FixedSingle;
                box.ForeColor = Color.DarkBlue;
            }
        }

        public virtual void UpdateDeviceinfoContent(int msg)
        {
        }
    }
}

