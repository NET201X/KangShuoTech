using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;
using System.IO;

namespace RecordManagement
{
    public partial class frmTumorReport : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<RecordsTumorModel> bindingManager;
        private List<InputRangeDec> inputRanges = new List<InputRangeDec>();
        private List<InputRangeStr> inputRange_str = new List<InputRangeStr>();
        private List<CheckBox> zdyjs = new List<CheckBox>();
        public frmTumorReport()
        {
            InitializeComponent();
            zdyjs.Add(ckblc);
            zdyjs.Add(ckbxx);
            zdyjs.Add(ckbss);
            zdyjs.Add(ckbsh);
            zdyjs.Add(ckbxb);
            zdyjs.Add(ckbbljf);
            zdyjs.Add(ckbblyf);
            zdyjs.Add(ckbsj);
            zdyjs.Add(ckbbx);
            zdyjs.Add(ckbsw);

          
        }
        public ChildFormStatus CheckErrorInput()
        {
            if (this.dtpyzddate.Value > DateTime.Now) //原诊断日期
            {
                MessageBox.Show("原诊断日期大于当前时间。");
                return ChildFormStatus.HasErrorInput;
            }
            if (this.dtpzddate.Value < this.dtpyzddate.Value) 
            {
                MessageBox.Show("诊断日期大于原诊断日期。");
                return ChildFormStatus.HasErrorInput;
            }
            if (this.dtpzddate.Value > DateTime.Now)
            {
                MessageBox.Show("诊断日期大于当前时间。");
                return ChildFormStatus.HasErrorInput;
            }
            if (this.dtReportDate.Value > DateTime.Now)
            {
                MessageBox.Show("报告时间大于当前时间。");
                return ChildFormStatus.HasErrorInput;
            }
            if (!string.IsNullOrEmpty(this.dieUC.txtTime.Text))
            {
                if (Convert.ToDateTime(this.dieUC.txtTime.Text) > DateTime.Now)
                {
                    MessageBox.Show("死亡日期大于当前日期。");
                    return ChildFormStatus.HasErrorInput;
                }
            }
            return ChildFormStatus.NoErrorInput;
        }

        public void InitEveryThing()
        {
            this.Tumors = new RecordsTumorBLL().GetModel(PhysicalInfoFactory.ID);
            if(this.Tumors==null)
            {
                this.Tumors=new RecordsTumorModel();
            }
            this.bindingManager = new SimpleBindingManager<RecordsTumorModel>(this.inputRanges, this.inputRange_str, this.Tumors);
            this.bindingManager.SimpleBinding(this.tbNum, "RecordID", false);
            this.bindingManager.SimpleBinding(this.tbICD10num, "ICD", false);
            this.bindingManager.SimpleBinding(this.tbICD3num, "ICDO", false);
            this.bindingManager.SimpleBinding(this.tbZYnum, "HospitalizationID", false);
            this.bindingManager.SimpleBinding(this.tbMZnum, "ClinicID", false);
            if(Model.Birthday!=null)
            {
                this.tbAge.Text = (DateTime.Now.Year - Model.Birthday.Value.Year).ToString();
            }
            this.tbPhone.Text = Model.Phone;
            this.bindingManager.SimpleBindingInt(this.tbHealthCard, "MedicareCardID", true);
            this.bindingManager.SimpleBinding(this.tbOldZd, "OrigDiagnose", false);
            if(this.Tumors.OrigDiagnoseDate.HasValue)
            {
                this.dtpyzddate.Value = this.Tumors.OrigDiagnoseDate.Value;
            }
            else
            {
                this.dtpyzddate.Value = DateTime.Now;
            }
            if (string.IsNullOrEmpty(this.Tumors.HouseholtDistict) && !string.IsNullOrEmpty(Model.DistrictID.ToString()))
            {
                DataTable dtdistict = new RecordsDistrictBLL().GetList(string.Format("Code={0}", Model.DistrictID)).Tables[0];
                if (dtdistict.Rows.Count > 0)
                {
                    DataRow rowdistict = dtdistict.Rows[0];
                    this.tbAdddistrict.Text = rowdistict["Name"].ToString();
                }
            }
            else
            {
                this.tbAdddistrict.Text = this.Tumors.HouseholtDistict;
            }

            if (string.IsNullOrEmpty(this.Tumors.HouseholtTown) && !string.IsNullOrEmpty(Model.TownID.ToString()))
            {
                DataTable dtTown = new RecordsTownBLL().GetList(string.Format("Code={0}", Model.TownID)).Tables[0];
                if (dtTown.Rows.Count > 0)
                {
                    DataRow rowTown = dtTown.Rows[0];
                    this.tbAddtown.Text = rowTown["Name"].ToString();
                }
            }
            else
            {
                this.tbAddtown.Text = this.Tumors.HouseholtTown;
            }

            if (string.IsNullOrEmpty(this.Tumors.HouseholtVillage) && !string.IsNullOrEmpty(Model.VillageID.ToString()))
            {
                DataTable dtVillage = new RecordsVillageBLL().GetList(string.Format("Code={0}", Model.VillageID)).Tables[0];
                if (dtVillage.Rows.Count > 0)
                {
                    DataRow rowVillage = dtVillage.Rows[0];
                    this.tbAddvillage.Text = rowVillage["Name"].ToString();
                }
            }
            else
            {
                this.tbAddvillage.Text = this.Tumors.HouseholtVillage;
            }

            if (string.IsNullOrEmpty(this.Tumors.PresentDistict) && !string.IsNullOrEmpty(Model.DistrictID.ToString()) )
            {
                DataTable dtdistict1 = new RecordsDistrictBLL().GetList(string.Format("Code={0}", Model.DistrictID)).Tables[0];
                if (dtdistict1.Rows.Count > 0)
                {
                    DataRow rowdistict1 = dtdistict1.Rows[0];
                    this.tbAdddistrict2.Text = rowdistict1["Name"].ToString();
                }
            }
            else
            {
                this.tbAdddistrict2.Text = this.Tumors.PresentDistict;
            }

            if (string.IsNullOrEmpty(this.Tumors.PresentTown) && !string.IsNullOrEmpty(Model.TownID.ToString()))
            {
                DataTable dtTown1 = new RecordsTownBLL().GetList(string.Format("Code={0}", Model.TownID)).Tables[0];
                if (dtTown1.Rows.Count > 0)
                {
                    DataRow rowTown1 = dtTown1.Rows[0];
                    this.tbAddtown2.Text = rowTown1["Name"].ToString();
                }
            }
            else
            {
                this.tbAddtown2.Text = this.Tumors.PresentTown;
            }

            if (string.IsNullOrEmpty(this.Tumors.PresentVillage) && !string.IsNullOrEmpty(Model.VillageID.ToString()))
            {
                DataTable dtVillage1 = new RecordsVillageBLL().GetList(string.Format("Code={0}", Model.VillageID)).Tables[0];
                if (dtVillage1.Rows.Count > 0)
                {
                    DataRow rowVillage1 = dtVillage1.Rows[0];
                    this.tbAddvillage2.Text = rowVillage1["Name"].ToString();
                }
            }
            else
            {
                this.tbAddvillage2.Text = this.Tumors.PresentVillage;
            }
            this.bindingManager.SimpleBinding(this.tbAddNum, "HouseholtNum", false);
            this.bindingManager.SimpleBinding(this.tbAddNum2, "PresentNum", false);
            this.bindingManager.SimpleBinding(this.tbZD, "Diagnose", false);
            this.bindingManager.SimpleBinding(this.tbType, "PathologyType", false);
            this.bindingManager.SimpleBinding(this.tbLocation, "PrimaryParts", false);
            this.bindingManager.SimpleBinding(this.tbTNMt, "StageT", false);
            this.bindingManager.SimpleBinding(this.tbTNMn, "StageN", false);
            this.bindingManager.SimpleBinding(this.tbTNMm, "StageM", false);
            if(this.Tumors.DiagnoseDate.HasValue)
            {
                this.dtpzddate.Value = this.Tumors.DiagnoseDate.Value;

            }
            else
            {
                this.dtpzddate.Value = DateTime.Now;
            }
            this.bindingManager.SimpleBinding(this.tbUnit, "ReportsUnit", false);
            this.bindingManager.SimpleBinding(this.tbDoctor, "ReportsDoctor", false);
            if (this.Tumors.ReportDate.HasValue)
            {
                this.dtReportDate.Value = this.Tumors.ReportDate.Value;
            }
            else
            {
                this.dtReportDate.Value = DateTime.Now;
            }
            if (this.Tumors.DieDate.HasValue)
            {
                this.dieUC.txtTime.Text = this.Tumors.DieDate.Value.ToLongDateString();
            }
          
            this.bindingManager.SimpleBinding(this.tbDieReason, "DieReason", false);
            if (!string.IsNullOrEmpty(this.Tumors.Judgment))
            {
                string zhendyj = this.Tumors.Judgment;
                foreach (string zd in zhendyj.Split(','))
                {
                    int nums;
                    if(int.TryParse(zd,out nums))
                    {
                        this.zdyjs[nums - 1].Checked = true;
                    }
                }
            }
            this.EveryThingIsOk = true;
        }

        private void frmTumorReport_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        public void NotisfyChildStatus()
        {

        }

        public bool SaveModelToDB()
        {
            RecordsTumorBLL bll=new RecordsTumorBLL();
            this.Tumors.OutKey = PhysicalInfoFactory.ID;
            if(!bll.Exists(this.Tumors.ID))
            {
                bll.Add(this.Tumors);
            }
            else
            {
                bll.Update(this.Tumors);
            }
            return true;
        }
        public void UpdataToModel()
        {
            this.Tumors.RecordID = this.tbNum.Text;
            this.Tumors.IDCardNo = this.Model.IDCardNo;
            this.Tumors.ClinicID = this.tbMZnum.Text;
            this.Tumors.ICD = this.tbICD10num.Text;
            this.Tumors.ICDO = this.tbICD3num.Text;
            this.Tumors.HospitalizationID = this.tbZYnum.Text;
            this.Tumors.Age = this.tbAge.Text;
            this.Tumors.Phone = this.tbPhone.Text;
            this.Tumors.HouseholtDistict = this.tbAdddistrict.Text;
            this.Tumors.HouseholtTown = this.tbAddtown.Text;
            this.Tumors.HouseholtVillage = this.tbAddvillage.Text;
            this.Tumors.HouseholtNum = this.tbAddNum.Text;
            this.Tumors.PresentDistict = this.tbAdddistrict2.Text;
            this.Tumors.PresentTown = this.tbAddtown2.Text;
            this.Tumors.PresentVillage = this.tbAddvillage2.Text;
            this.Tumors.PresentNum = this.tbAddNum2.Text;
            this.Tumors.OrigDiagnose = this.tbOldZd.Text;
            this.Tumors.OrigDiagnoseDate = this.dtpyzddate.Value;
            this.Tumors.MedicareCardID = this.tbHealthCard.Text;
            this.Tumors.Diagnose = this.tbZD.Text;
            this.Tumors.PathologyType = this.tbType.Text;
            this.Tumors.PrimaryParts = this.tbLocation.Text;
            this.Tumors.StageT = this.tbTNMt.Text;
            this.Tumors.StageN = this.tbTNMn.Text;
            this.Tumors.StageM = this.tbTNMm.Text;
            this.Tumors.DiagnoseDate = this.dtpzddate.Value;
            this.Tumors.ReportsUnit = this.tbUnit.Text;
            this.Tumors.ReportsDoctor = this.tbDoctor.Text;
            this.Tumors.ReportDate = this.dtReportDate.Value;

            if (!string.IsNullOrEmpty(this.dieUC.txtTime.Text))
            {
                this.Tumors.DieDate = Convert.ToDateTime(this.dieUC.txtTime.Text);
            }
            else
            {
                this.Tumors.DieDate = null;
            }
            this.Tumors.DieReason = this.tbDieReason.Text;

            string zhendyj = "";
            for (int i = 0; i < this.zdyjs.Count; i++)
            {
                if (this.zdyjs[i].Checked )
                {
                    zhendyj = zhendyj + string.Format("{0},", i + 1);
                }
            }
            this.Tumors.Judgment = zhendyj.Trim(new char[] { ',' });
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsTumorModel Tumors { get; set; }

     
    }
}
