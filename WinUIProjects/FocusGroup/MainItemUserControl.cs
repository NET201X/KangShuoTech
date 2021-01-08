using FocusGroup.ChronicDisease;
using FocusGroup.Gravida;
using FocusGroup.Kids;
using FocusGroup.OldPeople;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Configuration;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Data;
    using FocusGroup.Query;
    using KangShuoTech.Utilities.CommonControl;

    public class MainItemUserControl : UserControl
    {
        private IContainer components;
        private string idcard = "";
        private PictureBox GrivaPictureBox;
        private PictureBox KidsPictureBox;
        private PictureBox OldPeoplePictureBox;
        private PictureBox HypPictureBox;
        private PictureBox MentalPictureBox;
        private PictureBox StrokePictureBox;
        private PictureBox CHDPictureBox;
        private PictureBox DiaPictureBox;
        private PictureBox POTPictureBox;
        private PictureBox pictureBox1;
        private string restrict = ConfigurationManager.AppSettings["Restrict"];

        public event EventHandler Cancel_Click;

        public MainItemUserControl()
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.POTPictureBox = new System.Windows.Forms.PictureBox();
            this.DiaPictureBox = new System.Windows.Forms.PictureBox();
            this.CHDPictureBox = new System.Windows.Forms.PictureBox();
            this.StrokePictureBox = new System.Windows.Forms.PictureBox();
            this.MentalPictureBox = new System.Windows.Forms.PictureBox();
            this.HypPictureBox = new System.Windows.Forms.PictureBox();
            this.OldPeoplePictureBox = new System.Windows.Forms.PictureBox();
            this.KidsPictureBox = new System.Windows.Forms.PictureBox();
            this.GrivaPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.POTPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiaPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CHDPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrokePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MentalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HypPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OldPeoplePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KidsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrivaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::FocusGroup.Properties.Resources.suifangchaxun;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(874, 334);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 210);
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // POTPictureBox
            // 
            this.POTPictureBox.BackgroundImage = global::FocusGroup.Properties.Resources.feijiehe;
            this.POTPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.POTPictureBox.Location = new System.Drawing.Point(224, 334);
            this.POTPictureBox.Name = "POTPictureBox";
            this.POTPictureBox.Size = new System.Drawing.Size(210, 210);
            this.POTPictureBox.TabIndex = 58;
            this.POTPictureBox.TabStop = false;
            this.POTPictureBox.Click += new System.EventHandler(this.POTPictureBox_Click);
            // 
            // DiaPictureBox
            // 
            this.DiaPictureBox.BackgroundImage = global::FocusGroup.Properties.Resources.tangniaobing;
            this.DiaPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DiaPictureBox.Location = new System.Drawing.Point(440, 103);
            this.DiaPictureBox.Name = "DiaPictureBox";
            this.DiaPictureBox.Size = new System.Drawing.Size(210, 210);
            this.DiaPictureBox.TabIndex = 57;
            this.DiaPictureBox.TabStop = false;
            this.DiaPictureBox.Click += new System.EventHandler(this.DiaPictureBox_Click);
            // 
            // CHDPictureBox
            // 
            this.CHDPictureBox.BackgroundImage = global::FocusGroup.Properties.Resources.CHD;
            this.CHDPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CHDPictureBox.Location = new System.Drawing.Point(874, 103);
            this.CHDPictureBox.Name = "CHDPictureBox";
            this.CHDPictureBox.Size = new System.Drawing.Size(210, 210);
            this.CHDPictureBox.TabIndex = 56;
            this.CHDPictureBox.TabStop = false;
            this.CHDPictureBox.Click += new System.EventHandler(this.CHDPictureBox_Click);
            // 
            // StrokePictureBox
            // 
            this.StrokePictureBox.BackgroundImage = global::FocusGroup.Properties.Resources.Stroke;
            this.StrokePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StrokePictureBox.Location = new System.Drawing.Point(8, 334);
            this.StrokePictureBox.Name = "StrokePictureBox";
            this.StrokePictureBox.Size = new System.Drawing.Size(210, 210);
            this.StrokePictureBox.TabIndex = 55;
            this.StrokePictureBox.TabStop = false;
            this.StrokePictureBox.Click += new System.EventHandler(this.StrokePictureBox_Click);
            // 
            // MentalPictureBox
            // 
            this.MentalPictureBox.BackgroundImage = global::FocusGroup.Properties.Resources.Mental;
            this.MentalPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MentalPictureBox.Location = new System.Drawing.Point(656, 103);
            this.MentalPictureBox.Name = "MentalPictureBox";
            this.MentalPictureBox.Size = new System.Drawing.Size(210, 210);
            this.MentalPictureBox.TabIndex = 54;
            this.MentalPictureBox.TabStop = false;
            this.MentalPictureBox.Click += new System.EventHandler(this.MentalPictureBox_Click);
            // 
            // HypPictureBox
            // 
            this.HypPictureBox.BackgroundImage = global::FocusGroup.Properties.Resources.gaoxueya;
            this.HypPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HypPictureBox.Location = new System.Drawing.Point(224, 103);
            this.HypPictureBox.Name = "HypPictureBox";
            this.HypPictureBox.Size = new System.Drawing.Size(210, 210);
            this.HypPictureBox.TabIndex = 53;
            this.HypPictureBox.TabStop = false;
            this.HypPictureBox.Click += new System.EventHandler(this.HypPictureBox_Click);
            // 
            // OldPeoplePictureBox
            // 
            this.OldPeoplePictureBox.BackgroundImage = global::FocusGroup.Properties.Resources.OldPeople;
            this.OldPeoplePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OldPeoplePictureBox.Location = new System.Drawing.Point(8, 103);
            this.OldPeoplePictureBox.Name = "OldPeoplePictureBox";
            this.OldPeoplePictureBox.Size = new System.Drawing.Size(210, 210);
            this.OldPeoplePictureBox.TabIndex = 52;
            this.OldPeoplePictureBox.TabStop = false;
            this.OldPeoplePictureBox.Click += new System.EventHandler(this.OldPeoplePictureBox_Click);
            // 
            // KidsPictureBox
            // 
            this.KidsPictureBox.BackgroundImage = global::FocusGroup.Properties.Resources.Kids;
            this.KidsPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.KidsPictureBox.Location = new System.Drawing.Point(440, 334);
            this.KidsPictureBox.Name = "KidsPictureBox";
            this.KidsPictureBox.Size = new System.Drawing.Size(210, 210);
            this.KidsPictureBox.TabIndex = 51;
            this.KidsPictureBox.TabStop = false;
            this.KidsPictureBox.Click += new System.EventHandler(this.KidsPictureBox_Click);
            // 
            // GrivaPictureBox
            // 
            this.GrivaPictureBox.BackgroundImage = global::FocusGroup.Properties.Resources.Griva;
            this.GrivaPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GrivaPictureBox.Location = new System.Drawing.Point(656, 334);
            this.GrivaPictureBox.Name = "GrivaPictureBox";
            this.GrivaPictureBox.Size = new System.Drawing.Size(210, 210);
            this.GrivaPictureBox.TabIndex = 50;
            this.GrivaPictureBox.TabStop = false;
            this.GrivaPictureBox.Click += new System.EventHandler(this.GrivaPictureBox_Click);
            // 
            // MainItemUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.POTPictureBox);
            this.Controls.Add(this.DiaPictureBox);
            this.Controls.Add(this.CHDPictureBox);
            this.Controls.Add(this.StrokePictureBox);
            this.Controls.Add(this.MentalPictureBox);
            this.Controls.Add(this.HypPictureBox);
            this.Controls.Add(this.OldPeoplePictureBox);
            this.Controls.Add(this.KidsPictureBox);
            this.Controls.Add(this.GrivaPictureBox);
            this.Name = "MainItemUserControl";
            this.Size = new System.Drawing.Size(1369, 709);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.POTPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiaPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CHDPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrokePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MentalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HypPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OldPeoplePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KidsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrivaPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        public string IDCardNo { get; set; }

        private void GrivaPictureBox_Click(object sender, EventArgs e) //孕产妇随访
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            if (this.restrict == "on")
            {
                if (new RecordsBaseInfoBLL().GetModel(this.IDCardNo).PopulationType.Contains("3"))
                {
                    //新增标志
                    GravidaFactory.ID = 0;
                    using (Controler controler = new Controler(new GravidaForm(this.IDCardNo), new GravidaFactory()))
                    {
                        controler.IParentFrm.IShowDialog();
                        return;
                    }
                }
                MessageBox.Show("非孕妇，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                using (Controler controler2 = new Controler(new GravidaForm(this.IDCardNo), new GravidaFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }
        }

        private void KidsPictureBox_Click(object sender, EventArgs e) //儿童随访
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            if (this.restrict == "on")
            {
                if (new RecordsBaseInfoBLL().GetModel(this.IDCardNo).PopulationType.Contains("2"))
                {
                    //新增标志
                    KidsFactory.ID = 0;
                    using (Controler controler = new Controler(new MDIParentForm(this.IDCardNo), new KidsFactory()))
                    {
                        controler.IParentFrm.IShowDialog();
                        return;
                    }
                }
                MessageBox.Show("非儿童，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                using (Controler controler2 = new Controler(new MDIParentForm(this.IDCardNo), new KidsFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }
        }

        private void OldPeoplePictureBox_Click(object sender, EventArgs e) //老年人随访
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            if (this.restrict == "on")
            {
                if (new RecordsBaseInfoBLL().GetModel(this.IDCardNo).PopulationType.Contains("4"))
                {
                    DataSet OldData = new OlderSelfCareabilityBLL().GetList(string.Format(" IDCardNo='{0}' and FollowUpDate between '{1}' and '{2}'  order by  FollowUpDate Desc ", this.IDCardNo, DateTime.Today.ToString("yyyy-01-01"), DateTime.Today.Date.ToString("yyyy-12-31")));
                   if (OldData.Tables[0].Rows.Count > 0)
                   {
                       DataRow row = OldData.Tables[0].Rows[0];
                       string strchekdate = DateTime.Parse(row["FollowUpDate"].ToString()).ToString("yyyy-MM-dd");
                       if (MessageBox.Show("此人于'" + strchekdate + "'已随访，是否继续随访", "继续随访", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                       {
                           return;
                       }
                   }
                    OldPeopleInfoFactory.ID = 0;
                    using (Controler controler = new Controler(new OldPeopleForm(this.IDCardNo), new OldPeopleInfoFactory()))
                    {
                        controler.IParentFrm.IShowDialog();
                        return;
                    }
                }
                MessageBox.Show("非老年人，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                using (Controler controler2 = new Controler(new OldPeopleForm(this.IDCardNo), new OldPeopleInfoFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }
        }

        private void HypPictureBox_Click(object sender, EventArgs e)//高血压随访
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            if (this.restrict == "on")
            {
                if (new RecordsBaseInfoBLL().GetModel(this.IDCardNo).PopulationType.Contains("6"))
                {
                    DataSet HypData = new ChronicHypertensionVisitBLL().GetList(string.Format(" IDCardNo='{0}' and FollowUpDate between '{1}' and '{2}' order by FollowUpDate Desc ", this.IDCardNo, DateTime.Today.ToString("yyyy-01-01"), DateTime.Today.Date.ToString("yyyy-12-31")));
                    if (HypData.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = HypData.Tables[0].Rows[0];
                        string strchekdate = DateTime.Parse(row["FollowUpDate"].ToString()).ToString("yyyy-MM-dd");
                        if (MessageBox.Show("此人于'" + strchekdate + "'已随访，是否继续随访", "继续随访", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    //新增标志
                    HypFactory.ID = 0;
                    using (Controler controler = new Controler(new HyperParentForm(this.IDCardNo), new HypFactory()))
                    {
                        controler.IParentFrm.IShowDialog();
                        return;
                    }
                }

                MessageBox.Show("非高血压人群，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                using (Controler controler2 = new Controler(new HyperParentForm(this.IDCardNo), new HypFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }
        }

        private void MentalPictureBox_Click(object sender, EventArgs e) //精神病随访
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            if (this.restrict == "on")
            {
                if (new RecordsBaseInfoBLL().GetModel(this.IDCardNo).PopulationType.Contains("5"))
                {
                    DataSet MentalData = new ChronicMentalDiseaseVisitBLL().GetList(string.Format(" IDCardNo='{0}' and FollowUpDate between '{1}' and '{2}' order by FollowUpDate Desc ", this.IDCardNo, DateTime.Today.ToString("yyyy-01-01"), DateTime.Today.Date.ToString("yyyy-12-31")));
                    if (MentalData.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = MentalData.Tables[0].Rows[0];
                        string strchekdate = DateTime.Parse(row["FollowUpDate"].ToString()).ToString("yyyy-MM-dd");
                        if (MessageBox.Show("此人于'" + strchekdate + "'已随访，是否继续随访", "继续随访", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        {
                            return;
                        }
                    }

                    //新增标志
                    MentalFactory.ID = 0;
                    using (Controler controler = new Controler(new MDIParentForm(this.IDCardNo), new MentalFactory()))
                    {
                        controler.IParentFrm.IShowDialog();
                        return;
                    }
                }
                MessageBox.Show("非重精神病人群，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                using (Controler controler2 = new Controler(new MDIParentForm(this.IDCardNo), new MentalFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }
        }

        private void StrokePictureBox_Click(object sender, EventArgs e) //脑卒中随访
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            if (this.restrict == "on")
            {
                if (new RecordsBaseInfoBLL().GetModel(this.IDCardNo).PopulationType.Contains("9"))
                {
                    DataSet StrokeData = new ChronicStrokeVisitBLL().GetList(string.Format(" IDCardNo='{0}' and FollowUpDate between '{1}' and '{2}' order by FollowUpDate Desc ", this.IDCardNo, DateTime.Today.ToString("yyyy-01-01"), DateTime.Today.Date.ToString("yyyy-12-31")));
                    if (StrokeData.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = StrokeData.Tables[0].Rows[0];
                        string strchekdate = DateTime.Parse(row["FollowUpDate"].ToString()).ToString("yyyy-MM-dd");
                        if (MessageBox.Show("此人于'" + strchekdate + "'已随访，是否继续随访", "继续随访", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    //新增标志
                    StrokeFactory.ID = 0;
                    using (Controler controler = new Controler(new MDIParentForm(this.IDCardNo), new StrokeFactory()))
                    {
                        controler.IParentFrm.IShowDialog();
                        return;
                    }
                }
                MessageBox.Show("非脑卒中人群，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                using (Controler controler2 = new Controler(new MDIParentForm(this.IDCardNo), new StrokeFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }
        }

        private void CHDPictureBox_Click(object sender, EventArgs e) //冠心病随访
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            if (this.restrict == "on")
            {
                if (new RecordsBaseInfoBLL().GetModel(this.IDCardNo).PopulationType.Contains("8"))
                {
                    DataSet ChdData = new ChronicChdVisitBLL().GetList(string.Format(" IDCardNo='{0}' and VisitDate between '{1}' and '{2}' order by VisitDate Desc ", this.IDCardNo, DateTime.Today.ToString("yyyy-01-01"), DateTime.Today.Date.ToString("yyyy-12-31")));
                    if (ChdData.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = ChdData.Tables[0].Rows[0];
                        string strchekdate = DateTime.Parse(row["VisitDate"].ToString()).ToString("yyyy-MM-dd");
                        if (MessageBox.Show("此人于'" + strchekdate + "'已随访，是否继续随访", "继续随访", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    //新增标志
                    CHDFactory.ID = 0;
                    using (Controler controler = new Controler(new MDIParentForm(this.IDCardNo), new CHDFactory()))
                    {
                        controler.IParentFrm.IShowDialog();
                        return;
                    }
                }
                MessageBox.Show("非冠心病人群，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                using (Controler controler2 = new Controler(new MDIParentForm(this.IDCardNo), new CHDFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }
        }

        private void DiaPictureBox_Click(object sender, EventArgs e) //糖尿病随访
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            if (this.restrict == "on")
            {
                if (new RecordsBaseInfoBLL().GetModel(this.IDCardNo).PopulationType.Contains("7"))
                {
                    DataSet DiaData = new ChronicDiadetesVisitBLL().GetList(string.Format(" IDCardNo='{0}' and VisitDate between '{1}' and '{2}' order by VisitDate Desc ", this.IDCardNo, DateTime.Today.ToString("yyyy-01-01"), DateTime.Today.Date.ToString("yyyy-12-31")));
                    if (DiaData.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = DiaData.Tables[0].Rows[0];
                        string strchekdate = DateTime.Parse(row["VisitDate"].ToString()).ToString("yyyy-MM-dd");
                        if (MessageBox.Show("此人于'" + strchekdate + "'已随访，是否继续随访", "继续随访", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    //新增标志
                    DiaFactory.ID = 0;
                    using (Controler controler = new Controler(new DiaParentForm(this.IDCardNo), new DiaFactory()))
                    {
                        controler.IParentFrm.IShowDialog();
                        return;
                    }
                }
                MessageBox.Show("非糖尿病人群，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                using (Controler controler2 = new Controler(new MDIParentForm(this.IDCardNo), new DiaFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }
        }

        private void POTPictureBox_Click(object sender, EventArgs e)  //肺结核随访
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            if (this.restrict == "on")
            {
                PTBFactory.ID = 0;
                if (new RecordsBaseInfoBLL().GetModel(this.IDCardNo).PopulationType.Contains("10"))
                {
                    DataSet LungData = new ChronicLungerFirstVisitBLL().GetList(string.Format(" IDCardNo='{0}' and FollowupDate between '{1}' and '{2}' order by FollowupDate Desc ", this.IDCardNo, DateTime.Today.ToString("yyyy-01-01"), DateTime.Today.Date.ToString("yyyy-12-31")));
                    if (LungData.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = LungData.Tables[0].Rows[0];
                        string strchekdate = DateTime.Parse(row["FollowupDate"].ToString()).ToString("yyyy-MM-dd");
                        if (MessageBox.Show("此人于'" + strchekdate + "'已随访，是否继续随访", "继续随访", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        {
                            return;
                        }
                    }

                    using (Controler controler = new Controler(new MDIParentForm(this.IDCardNo), new PTBFactory()))
                    {
                        controler.IParentFrm.IShowDialog();
                        return;
                    }
                }
                MessageBox.Show("非病人群，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                using (Controler controler2 = new Controler(new MDIParentForm(this.IDCardNo), new DiaFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) //随访查询
        {
            using (Controler controler = new Controler(new MDIParentForm(this.IDCardNo), new GroupDataListsSearchFactory()))
            {
                controler.IParentFrm.IShowDialog();
            }

            GC.Collect();
        }
    }

    public class OldPeopleForm : MDIParentForm
    {
        public RecordsBaseInfoModel RecordBaseInfo { get; set; }
        private LinkLabel lklbRequired;
        public List<RecordsRequiredModel> Archive_requireds { get; set; }

        public OldPeopleForm(string idcard)
            : base(idcard)
        {
            RecordBaseInfo = new RecordsBaseInfoBLL().GetModel(this.Model.IDCardNo);


            if (RecordBaseInfo == null)
            {
                RecordBaseInfo = new RecordsBaseInfoModel { IDCardNo = this.Model.IDCardNo };
            }

            lklbRequired = new LinkLabel();


            this.lklbRequired.BackColor = Color.Transparent;
            this.lklbRequired.ForeColor = Color.Red;
            this.lklbRequired.Font = new Font("宋体", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.lklbRequired.FlatStyle = FlatStyle.Flat;
            this.lklbRequired.ImageAlign = ContentAlignment.MiddleRight;
            this.lklbRequired.Location = new Point(0xd6, 3);
            this.lklbRequired.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lklbRequired.Name = "lklbRequired";
            this.lklbRequired.AutoSize = true;
            this.lklbRequired.TabIndex = 80;
            this.lklbRequired.Text = "必填项设置";
            this.lklbRequired.Click += new EventHandler(this.btnBtx_Click);
            base.flowLayoutPanel1.Controls.Add(this.lklbRequired);
        }

        private void btnBtx_Click(object sender, EventArgs e)
        {
            OldPeopleRequiredForm personfilerequire = new OldPeopleRequiredForm
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (personfilerequire.ShowDialog() == DialogResult.OK)
            {
                DataSet set = new DataSet();
                set.ReadXml(Application.StartupPath + @"\requiredOldPeople.xml");
                this.Archive_requireds = new RecordsRequiredBLL().DataTableToList(set.Tables[0]);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataSet set = new DataSet();
            set.ReadXml(Application.StartupPath + @"\requiredOldPeople.xml");
            this.Archive_requireds = new RecordsRequiredBLL().DataTableToList(set.Tables[0]);
        }

    }

    public class HyperParentForm : MDIParentForm
    {
        public RecordsBaseInfoModel RecordBaseInfo { get; set; }
        private LinkLabel lklbRequired;
        public List<RecordsRequiredModel> Archive_requireds { get; set; }

        public HyperParentForm(string idcard)
            : base(idcard)
        {
            RecordBaseInfo = new RecordsBaseInfoBLL().GetModel(this.Model.IDCardNo);

            if (RecordBaseInfo == null)
            {
                RecordBaseInfo = new RecordsBaseInfoModel { IDCardNo = this.Model.IDCardNo };
            }

            lklbRequired = new LinkLabel();

            this.lklbRequired.BackColor = Color.Transparent;
            this.lklbRequired.ForeColor = Color.Red;
            this.lklbRequired.Font = new Font("宋体", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.lklbRequired.FlatStyle = FlatStyle.Flat;
            this.lklbRequired.ImageAlign = ContentAlignment.MiddleRight;
            this.lklbRequired.Location = new Point(0xd6, 3);
            this.lklbRequired.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lklbRequired.Name = "lklbRequired";
            this.lklbRequired.AutoSize = true;
            this.lklbRequired.TabIndex = 80;
            this.lklbRequired.Text = "必填项设置";
            this.lklbRequired.Click += new EventHandler(this.btnBtx_Click);
            base.flowLayoutPanel1.Controls.Add(this.lklbRequired);
        }

        private void btnBtx_Click(object sender, EventArgs e)
        {
            HyperRequiredForm personfilerequire = new HyperRequiredForm
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (personfilerequire.ShowDialog() == DialogResult.OK)
            {
                DataSet set = new DataSet();
                set.ReadXml(Application.StartupPath + @"\requiredHyper.xml");
                this.Archive_requireds = new RecordsRequiredBLL().DataTableToList(set.Tables[0]);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataSet set = new DataSet();
            set.ReadXml(Application.StartupPath + @"\requiredHyper.xml");
            this.Archive_requireds = new RecordsRequiredBLL().DataTableToList(set.Tables[0]);
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x597:
                    (base.IMDIControler.IChildrens["随访信息"] as ChildContentForm).UpdateDeviceinfoContent(0x597);//血压
                    return;

                case 0x599:
                    (base.IMDIControler.IChildrens["随访信息"] as ChildContentForm).UpdateDeviceinfoContent(0x599);//血糖
                    return;

                case 0x59c:
                    (base.IMDIControler.IChildrens["随访信息"] as ChildContentForm).UpdateDeviceinfoContent(0x59c);//体重
                    return;
            }
            base.DefWndProc(ref m);
        }
    }

    public class DiaParentForm : MDIParentForm
    {
        public RecordsBaseInfoModel RecordBaseInfo { get; set; }
        private LinkLabel lklbRequired;
        public List<RecordsRequiredModel> Archive_requireds { get; set; }

        public DiaParentForm(string idcard)
            : base(idcard)
        {
            RecordBaseInfo = new RecordsBaseInfoBLL().GetModel(this.Model.IDCardNo);


            if (RecordBaseInfo == null)
            {
                RecordBaseInfo = new RecordsBaseInfoModel { IDCardNo = this.Model.IDCardNo };
            }

            lklbRequired = new LinkLabel();

            this.lklbRequired.BackColor = Color.Transparent;
            this.lklbRequired.ForeColor = Color.Red;
            this.lklbRequired.Font = new Font("宋体", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.lklbRequired.FlatStyle = FlatStyle.Flat;
            this.lklbRequired.ImageAlign = ContentAlignment.MiddleRight;
            this.lklbRequired.Location = new Point(0xd6, 3);
            this.lklbRequired.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lklbRequired.Name = "lklbRequired";
            this.lklbRequired.AutoSize = true;
            this.lklbRequired.TabIndex = 80;
            this.lklbRequired.Text = "必填项设置";
            this.lklbRequired.Click += new EventHandler(this.btnBtx_Click);
            base.flowLayoutPanel1.Controls.Add(this.lklbRequired);
        }

        private void btnBtx_Click(object sender, EventArgs e)
        {
            DiaRequiredForm personfilerequire = new DiaRequiredForm
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (personfilerequire.ShowDialog() == DialogResult.OK)
            {
                DataSet set = new DataSet();
                set.ReadXml(Application.StartupPath + @"\requiredDia.xml");
                this.Archive_requireds = new RecordsRequiredBLL().DataTableToList(set.Tables[0]);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataSet set = new DataSet();
            set.ReadXml(Application.StartupPath + @"\requiredDia.xml");
            this.Archive_requireds = new RecordsRequiredBLL().DataTableToList(set.Tables[0]);
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x597:
                    (base.IMDIControler.IChildrens["随访信息"] as ChildContentForm).UpdateDeviceinfoContent(0x597);//血压
                    return;

                case 0x599:
                    (base.IMDIControler.IChildrens["随访信息"] as ChildContentForm).UpdateDeviceinfoContent(0x599);//血糖
                    return;

                case 0x59c:
                    (base.IMDIControler.IChildrens["随访信息"] as ChildContentForm).UpdateDeviceinfoContent(0x59c);//体重
                    return;
            }
            base.DefWndProc(ref m);
        }

    }

}

