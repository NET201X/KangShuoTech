using System;
using System.ComponentModel;
using System.Windows.Forms;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace MedicalService
{
    public class MainItemUserControl : UserControl
    {
        private IContainer components;
        private PictureBox pbxConsultation;
        private PictureBox pbxReferral;
        private PictureBox pbxSearch;
        private PictureBox pbxClinicalReception;

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
            this.pbxSearch = new System.Windows.Forms.PictureBox();
            this.pbxReferral = new System.Windows.Forms.PictureBox();
            this.pbxClinicalReception = new System.Windows.Forms.PictureBox();
            this.pbxConsultation = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReferral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClinicalReception)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxConsultation)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxSearch
            // 
            this.pbxSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxSearch.Image = global::MedicalService.Properties.Resources.列表查询;
            this.pbxSearch.Location = new System.Drawing.Point(646, 163);
            this.pbxSearch.Name = "pbxSearch";
            this.pbxSearch.Size = new System.Drawing.Size(150, 180);
            this.pbxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxSearch.TabIndex = 0;
            this.pbxSearch.TabStop = false;
            this.pbxSearch.Click += new System.EventHandler(this.pbxSearch_Click);
            // 
            // pbxReferral
            // 
            this.pbxReferral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxReferral.Image = global::MedicalService.Properties.Resources.双向转诊;
            this.pbxReferral.Location = new System.Drawing.Point(464, 163);
            this.pbxReferral.Name = "pbxReferral";
            this.pbxReferral.Size = new System.Drawing.Size(150, 180);
            this.pbxReferral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxReferral.TabIndex = 0;
            this.pbxReferral.TabStop = false;
            this.pbxReferral.Click += new System.EventHandler(this.pbxReferral_Click);
            // 
            // pbxClinicalReception
            // 
            this.pbxClinicalReception.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxClinicalReception.Image = global::MedicalService.Properties.Resources.接诊;
            this.pbxClinicalReception.Location = new System.Drawing.Point(106, 163);
            this.pbxClinicalReception.Name = "pbxClinicalReception";
            this.pbxClinicalReception.Size = new System.Drawing.Size(150, 180);
            this.pbxClinicalReception.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxClinicalReception.TabIndex = 0;
            this.pbxClinicalReception.TabStop = false;
            this.pbxClinicalReception.Click += new System.EventHandler(this.pbxClinicalReception_Click);
            // 
            // pbxConsultation
            // 
            this.pbxConsultation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxConsultation.Image = global::MedicalService.Properties.Resources.会诊;
            this.pbxConsultation.Location = new System.Drawing.Point(285, 163);
            this.pbxConsultation.Name = "pbxConsultation";
            this.pbxConsultation.Size = new System.Drawing.Size(150, 180);
            this.pbxConsultation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxConsultation.TabIndex = 0;
            this.pbxConsultation.TabStop = false;
            this.pbxConsultation.Click += new System.EventHandler(this.pbxConsultation_Click);
            // 
            // MainItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pbxSearch);
            this.Controls.Add(this.pbxReferral);
            this.Controls.Add(this.pbxClinicalReception);
            this.Controls.Add(this.pbxConsultation);
            this.Name = "MainItemUserControl";
            this.Size = new System.Drawing.Size(1027, 567);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReferral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClinicalReception)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxConsultation)).EndInit();
            this.ResumeLayout(false);

        }

        private void pbxClinicalReception_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            new Controler(new MDIParentForm(IDCardNo), new ReceiveTreatFactory()).IParentFrm.IShowDialog();
        }
        private void pbxConsultation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            new Controler(new MDIParentForm(IDCardNo), new ConsulationFactory()).IParentFrm.IShowDialog();
        }
        private void pbxReferral_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            new Controler(new MDIParentForm(IDCardNo), new ReferralFactory()).IParentFrm.IShowDialog();
        }

        private void pbxSearch_Click(object sender, EventArgs e)
        {
            new Controler(new MDIParentForm(IDCardNo), new DataListSeachFactory()).IParentFrm.IShowDialog();
        }

    }
}

