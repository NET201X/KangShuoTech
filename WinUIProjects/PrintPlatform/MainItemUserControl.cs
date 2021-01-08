using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace PrintPlatform
{
    public class MainItemUserControl : UserControl
    {
        private IContainer components;
        private PictureBox pictureBox1;
        private PictureBox pbxPregnant;
        private PictureBox ECGpictureBox;
        private PictureBox pictureBox2;
        public Process SingleProcess;

        public MainItemUserControl()
        {
            this.InitializeComponent();
        }

        public string IDCardNo { get; set; }

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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ECGpictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbxPregnant = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ECGpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPregnant)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::PrintPlatform.Properties.Resources.B_超打印;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(727, 163);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(210, 210);
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // ECGpictureBox
            // 
            this.ECGpictureBox.BackgroundImage = global::PrintPlatform.Properties.Resources.心电打印;
            this.ECGpictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ECGpictureBox.Location = new System.Drawing.Point(495, 163);
            this.ECGpictureBox.Name = "ECGpictureBox";
            this.ECGpictureBox.Size = new System.Drawing.Size(210, 210);
            this.ECGpictureBox.TabIndex = 36;
            this.ECGpictureBox.TabStop = false;
            this.ECGpictureBox.Click += new System.EventHandler(this.ECGpictureBox_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PrintPlatform.Properties.Resources.批量打印;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(264, 163);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pbxPregnant
            // 
            this.pbxPregnant.BackgroundImage = global::PrintPlatform.Properties.Resources.单人打印;
            this.pbxPregnant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxPregnant.Location = new System.Drawing.Point(32, 163);
            this.pbxPregnant.Name = "pbxPregnant";
            this.pbxPregnant.Size = new System.Drawing.Size(210, 210);
            this.pbxPregnant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxPregnant.TabIndex = 34;
            this.pbxPregnant.TabStop = false;
            this.pbxPregnant.Click += new System.EventHandler(this.pbxPregnant_Click);
            // 
            // MainItemUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ECGpictureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbxPregnant);
            this.Name = "MainItemUserControl";
            this.Size = new System.Drawing.Size(1042, 535);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ECGpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPregnant)).EndInit();
            this.ResumeLayout(false);

        }

        private void pbxPregnant_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            SingleProcess = new Process { StartInfo = { FileName = @"NewPrint.exe", Arguments = IDCardNo } };
            SingleProcess.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Controler(new MDIParentForm(IDCardNo), new BatchPrintFactory()).IParentFrm.IShowDialog();
        }

        private void ECGpictureBox_Click(object sender, EventArgs e)
        {
            new Controler(new MDIParentForm(IDCardNo), new ECGPrintFactory()).IParentFrm.IShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new Controler(new MDIParentForm(IDCardNo), new TypeBPrintFactory()).IParentFrm.IShowDialog();
        }
    }
}

