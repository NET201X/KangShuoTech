using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;
using System.Text.RegularExpressions;

namespace MedicalService
{
    public partial class Referral : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        public Referral()
        {
            InitializeComponent();
            lbTransOrgID.Text = "";
            this.EveryThingIsOk = false;
            this.HaveToSave = false;
        }
        public ChildFormStatus CheckErrorInput()
        {
            if ((this.tbSickPhone.BackColor == Color.Salmon))
            {
                this.SaveDataInfo = "患者电话输入有误！";
                return ChildFormStatus.HasErrorInput;

            }
            if ((this.tbtbRefDoctorPhone.BackColor == Color.Salmon))
            {
                this.SaveDataInfo = "转诊医生电话输入有误！";
                return ChildFormStatus.HasErrorInput;
               
            }
            return ChildFormStatus.NoErrorInput;
        }
        public void InitEveryThing()
        {
            this.lbStubName.Text = this.Model.CustomerName;
            this.lbName.Text = this.Model.CustomerName;
            this.tbCreateMenName.Text = this.Model.Doctor;
            this.dtpCreateDate.Text = this.Model.CreateDate.ToString();
            this.tbCreateUnitName.Text = this.Model.CreateUnitName;
            this.tbCreateMenName.Text = this.Model.CreateMenName;
            this.dtpCreateDate.Text = this.Model.CreateDate.ToString();
            this.lbOrgID2.Text = this.Model.CreateUnitName;
            if (this.Model.Sex == "1")
            {
                this.lbSex.Text = "男";
                this.lbStubSex.Text = "男";
            }
            else if (this.Model.Sex == "2")
            {
                this.lbSex.Text = "男";
                this.lbStubSex.Text = "男";
            }
            int age = DateTime.Now.Year - Convert.ToInt32(this.Model.IDCardNo.Substring(6, 4));
            this.lbStubAge.Text = age.ToString();
            this.lbAge.Text = age.ToString();

            RefModel = new ReferraBaseInfoModel();

            this.EveryThingIsOk = true;
        }
        public bool SaveModelToDB()
        {
            ReferraBaseInfoBLL refbll = new ReferraBaseInfoBLL();
            int result=refbll.Add(RefModel);
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        public void NotisfyChildStatus()
        {

        }
      
        public void UpdataToModel()
        {
           
            this.RefModel.IDCardNo = Model.IDCardNo;
            this.RefModel.SickPhone = this.tbSickPhone.Text.Trim();
            this.RefModel.IllnessDate = this.dtpIllDate.Value;
            this.RefModel.NewDepartName = this.tbNewDepartment.Text.Trim();
            this.RefModel.NewDoctor = this.tbNewDoctor.Text.Trim();
            this.RefModel.NewUnitName = this.tbNewUnitName.Text.Trim();
            this.RefModel.TranseDate = this.dtpTranseDate.Value;
            this.RefModel.FirstImpress = this.tbFirstImpress.Text.Trim();
            this.RefModel.TransReason = this.tbTransReason.Text.Trim();
            this.RefModel.HistoryIllness = this.tbHistoryIllness.Text.Trim();
            this.RefModel.Retrospectively = this.tbRetrospectively.Text.Trim();
            this.RefModel.RefDoctor = this.tbRefDoctor.Text.Trim();
            this.RefModel.RefDoctorPhone = this.tbtbRefDoctorPhone.Text.Trim();
            this.RefModel.Address = this.tbAddress.Text.Trim();

        }

        private void tbNewUnitName_TextChanged(object sender, EventArgs e)
        {
            lbTransOrgID.Text = tbNewUnitName.Text;
        }

        private void tbStubRefDoctor_TextChanged(object sender, EventArgs e)
        {
            this.tbRefDoctor.Text =this.tbStusRefDoctor.Text;
        }

        private void tbRefDoctor_TextChanged(object sender, EventArgs e)
        {
            this.tbStusRefDoctor.Text = this.tbRefDoctor.Text;
        }

        private void dtpStubRefDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpTranseDate.Text = this.dtpStubTranseDate.Text;
        }

        private void dtpRefDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpStubTranseDate.Text = this.dtpTranseDate.Text;
        }
        private void Referral_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }
        public bool IsHandset(string str_handset)
        {
            return Regex.IsMatch(str_handset, @"^[1]+[0-9]+\d{9}");
        }

        public bool IsTelephone(string str_telephone)
        {
            if (!Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$"))
            {
                return Regex.IsMatch(str_telephone, @"^(\d{3,4})?\d{6,8}$");
            }
            return true;
        }
        private void tbtbRefDoctorPhone_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if ((string.IsNullOrEmpty(box.Text) || this.IsTelephone(box.Text)) || this.IsHandset(box.Text))
            {
                box.BackColor = Color.WhiteSmoke;
                box.Tag = 0;
            }
            else
            {
                box.BackColor = Color.Salmon;
                box.Tag = 1;
            }
        }
        private void tbSickPhone_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if ((string.IsNullOrEmpty(box.Text) || this.IsTelephone(box.Text)) || this.IsHandset(box.Text))
            {
                box.BackColor = Color.WhiteSmoke;
                box.Tag = 0;
            }
            else
            {
                box.BackColor = Color.Salmon;
                box.Tag = 1;
            }
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }
        private ReferraBaseInfoModel RefModel { get; set; }
        public string IDNumber { get; set; }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

 
       
    }
}
