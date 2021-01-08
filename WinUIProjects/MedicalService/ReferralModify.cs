using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.Utilities.CommonTools;
using KangShuoTech.Utilities.CommonUI;
using System.Text.RegularExpressions;

namespace MedicalService
{
    public partial class ReferralModify: ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        public int ID;
        public ReferraBaseInfoModel referrModel;
        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }
        public ReferralModify()
        {
            InitializeComponent();
            this.EveryThingIsOk = false;
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
        public bool SaveModelToDB()
        {
            try
            {
                bool result = new ReferraBaseInfoBLL().Update(referrModel);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public void NotisfyChildStatus()
        {

        }

        public void UpdataToModel()
        {
            referrModel.UpdateUnitName = tbUpdatUnitName.Text;
            referrModel.UpdatePerson = tbUpdatName.Text;
            referrModel.UpdateDate = dtpUpdatTime.Value;
            referrModel.TranseDate = dtpTranseDate.Value;
            referrModel.IllnessDate = dtpIllDate.Value;

        }
        private void ReferralModify_Load(object sender, EventArgs e)
        {
            referrModel = new ReferraBaseInfoBLL().GetModel(this.ID);
            if (!EveryThingIsOk)
            {
                InitEveryThing();
            }
            
        }
        public void InitEveryThing()
        {
            this.lbStubName.Text = this.referrModel.CustomerName;
            this.lbName.Text = this.referrModel.CustomerName;
            this.tbCreateMenName.Text = this.referrModel.CreateMenName;
            this.dtpCreateDate.Text = this.referrModel.CreateTime.ToString();
            this.tbCreateUnitName.Text = this.referrModel.CreateUnitName;
            this.tbCreateMenName.Text = this.referrModel.CreateMenName;
            this.dtpCreateDate.Text = this.referrModel.CreateTime.ToString();
            this.lbOrgID2.Text = this.referrModel.CreateUnitName;
            this.dtpStubTranseDate.Text = this.referrModel.TranseDate.ToString();
            this.dtpTranseDate.Text = this.referrModel.TranseDate.ToString();
            this.dtpIllDate.Text = this.referrModel.IllnessDate.ToString();
            this.lbTransOrgID.Text = this.referrModel.NewDepartName.ToString();
            this.tbUpdatName.Text = this.Model.Doctor;
            this.tbUpdatUnitName.Text = ConfigHelper.GetNode("orgName");
            this.dtpUpdatTime.Text = DateTime.Now.ToString();
            if (this.referrModel.Sex == "1")
            {
                this.lbSex.Text = "男";
                this.lbStubSex.Text = "男";
            }
            else if (this.referrModel.Sex == "2")
            {
                this.lbSex.Text = "男";
                this.lbStubSex.Text = "男";
            }
            int age = DateTime.Now.Year - Convert.ToInt32(this.referrModel.IDCardNo.Substring(6, 4));
            this.lbStubAge.Text = age.ToString();
            this.lbAge.Text = age.ToString();
            this.tbSickPhone.DataBindings.Add("Text", this.referrModel, "SickPhone", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbNewUnitName.DataBindings.Add("Text", this.referrModel, "NewUnitName", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbNewDepartment.DataBindings.Add("Text", this.referrModel, "NewDepartName", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbNewDoctor.DataBindings.Add("Text", this.referrModel, "NewDoctor", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbAddress.DataBindings.Add("Text", this.referrModel, "Address", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbStusRefDoctor.DataBindings.Add("Text", this.referrModel, "RefDoctor", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbFirstImpress.DataBindings.Add("Text", this.referrModel, "FirstImpress", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbTransReason.DataBindings.Add("Text", this.referrModel, "TransReason", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbHistoryIllness.DataBindings.Add("Text", this.referrModel, "HistoryIllness", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbRetrospectively.DataBindings.Add("Text", this.referrModel, "Retrospectively", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbRefDoctor.DataBindings.Add("Text", this.referrModel, "RefDoctor", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbtbRefDoctorPhone.DataBindings.Add("Text", this.referrModel, "RefDoctorPhone", false, DataSourceUpdateMode.OnPropertyChanged);
            EveryThingIsOk = true;
        }
        private void dtpStubTranseDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpTranseDate.Text = this.dtpStubTranseDate.Text;
        }

        private void dtpTranseDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpStubTranseDate.Text = this.dtpTranseDate.Text;
        }
        private void tbNewUnitName_TextChanged(object sender, EventArgs e)
        {
            lbTransOrgID.Text = tbNewUnitName.Text;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
