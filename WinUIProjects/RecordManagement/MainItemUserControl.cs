using System;
using System.ComponentModel;
using System.Windows.Forms;
using KangShuoTech.Utilities.CommonUI;
using OverView;
using ArchiveInfo.OverView;

namespace ArchiveInfo
{
    public class MainItemUserControl : UserControl
    {
        private IContainer components;
        private PictureBox pbxDoctor;
        private PictureBox pbxList;
        private PictureBox pbxOut;
        private PictureBox pbxVisit;
        private PictureBox pbxPregnant;

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
            this.pbxVisit = new System.Windows.Forms.PictureBox();
            this.pbxOut = new System.Windows.Forms.PictureBox();
            this.pbxList = new System.Windows.Forms.PictureBox();
            this.pbxDoctor = new System.Windows.Forms.PictureBox();
            this.pbxPregnant = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxVisit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDoctor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPregnant)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxVisit
            // 
            this.pbxVisit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxVisit.Image = global::ArchiveInfo.Properties.Resources.随访提醒;
            this.pbxVisit.Location = new System.Drawing.Point(686, 191);
            this.pbxVisit.Name = "pbxVisit";
            this.pbxVisit.Size = new System.Drawing.Size(210, 210);
            this.pbxVisit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxVisit.TabIndex = 38;
            this.pbxVisit.TabStop = false;
            this.pbxVisit.Click += new System.EventHandler(this.pbxVisit_Click);
            // 
            // pbxOut
            // 
            this.pbxOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxOut.Image = global::ArchiveInfo.Properties.Resources.漏项统计;
            this.pbxOut.Location = new System.Drawing.Point(470, 191);
            this.pbxOut.Name = "pbxOut";
            this.pbxOut.Size = new System.Drawing.Size(210, 210);
            this.pbxOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxOut.TabIndex = 37;
            this.pbxOut.TabStop = false;
            this.pbxOut.Click += new System.EventHandler(this.pbxOut_Click);
            // 
            // pbxList
            // 
            this.pbxList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxList.Image = global::ArchiveInfo.Properties.Resources.列表统计;
            this.pbxList.Location = new System.Drawing.Point(902, 191);
            this.pbxList.Name = "pbxList";
            this.pbxList.Size = new System.Drawing.Size(210, 210);
            this.pbxList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxList.TabIndex = 36;
            this.pbxList.TabStop = false;
            this.pbxList.Click += new System.EventHandler(this.pbxList_Click);
            // 
            // pbxDoctor
            // 
            this.pbxDoctor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxDoctor.Image = global::ArchiveInfo.Properties.Resources.医生查询;
            this.pbxDoctor.Location = new System.Drawing.Point(254, 191);
            this.pbxDoctor.Name = "pbxDoctor";
            this.pbxDoctor.Size = new System.Drawing.Size(210, 210);
            this.pbxDoctor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxDoctor.TabIndex = 35;
            this.pbxDoctor.TabStop = false;
            this.pbxDoctor.Click += new System.EventHandler(this.pbxDoctor_Click);
            // 
            // pbxPregnant
            // 
            this.pbxPregnant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxPregnant.Image = global::ArchiveInfo.Properties.Resources.本地查询;
            this.pbxPregnant.Location = new System.Drawing.Point(38, 191);
            this.pbxPregnant.Name = "pbxPregnant";
            this.pbxPregnant.Size = new System.Drawing.Size(210, 210);
            this.pbxPregnant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPregnant.TabIndex = 34;
            this.pbxPregnant.TabStop = false;
            this.pbxPregnant.Click += new System.EventHandler(this.pbxPregnant_Click);
            // 
            // MainItemUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pbxVisit);
            this.Controls.Add(this.pbxOut);
            this.Controls.Add(this.pbxList);
            this.Controls.Add(this.pbxDoctor);
            this.Controls.Add(this.pbxPregnant);
            this.Name = "MainItemUserControl";
            this.Size = new System.Drawing.Size(1186, 595);
            ((System.ComponentModel.ISupportInitialize)(this.pbxVisit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDoctor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPregnant)).EndInit();
            this.ResumeLayout(false);

        }

        private void pbxPregnant_Click(object sender, EventArgs e)
        {
            new Controler(new MDIParentForm(IDCardNo), new OverViewFactory()).IParentFrm.IShowDialog();
        }

        private void pbxVisit_Click(object sender, EventArgs e)
        {
            new Controler(new MDIParentForm(IDCardNo), new VisitRemindFactory()).IParentFrm.IShowDialog();
        }

        private void pbxDoctor_Click(object sender, EventArgs e)
        {
            new Controler(new MDIParentForm(IDCardNo), new DoctorQueryFactory()).IParentFrm.IShowDialog();
        }

        private void pbxList_Click(object sender, EventArgs e)
        {
            new Controler(new MDIParentForm(IDCardNo), new ListInfoFactory()).IParentFrm.IShowDialog();
        }

        private void pbxOut_Click(object sender, EventArgs e)
        {
            new Controler(new MDIParentForm(IDCardNo), new LeaveOutInfoFactory()).IParentFrm.IShowDialog();
        }
    }
}

