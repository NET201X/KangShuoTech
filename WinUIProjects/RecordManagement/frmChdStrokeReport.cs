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
    public partial class frmChdStrokeReport : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<RecordsChdStrokeReportModel> bindingManager;
        private List<InputRangeDec> inputRanges=new List<InputRangeDec>();
        private List<InputRangeStr> inputRange_str=new List<InputRangeStr>();
        private List<CheckBox> gxbzd=new List<CheckBox>();
        private List<CheckBox> nczzd=new List<CheckBox>();
        private List<CheckBox> zdyj=new List<CheckBox>();
        public frmChdStrokeReport()
        {
            InitializeComponent();
            gxbzd.Add(this.cbjxxjgs);
            gxbzd.Add(this.cbgxbcs);
            nczzd.Add(this.cbzwmxqcx);
            nczzd.Add(cbncx);
            nczzd.Add(cbnxsxc);
            nczzd.Add(cbnss);
            nczzd.Add(cbqxxngs);
            nczzd.Add(cbfslngs);
            nczzd.Add(cbwfl);
            zdyj.Add(cbLczd);
            zdyj.Add(cbXdt);
            zdyj.Add(cbXgzy);
            zdyj.Add(cbCT);
            zdyj.Add(cbCgz);
            zdyj.Add(cbSh);
            zdyj.Add(cbSj);
        }

        public ChildFormStatus CheckErrorInput()
        {
            if (this.fabDate.Value > DateTime.Now)//发病日期
            {
                MessageBox.Show("发病日期大于当前日期");
                return ChildFormStatus.HasErrorInput;
            }
            if (this.fabDate.Value > quezDate.Value)
            {
                MessageBox.Show("确诊日期大于发病日期");
                return ChildFormStatus.HasErrorInput;
            }
            if (!string.IsNullOrEmpty(this.deathUC.txtTime.Text))
            {
                if (Convert.ToDateTime(this.deathUC.txtTime.Text) > DateTime.Now)
                {
                    MessageBox.Show("死亡日期大于当前日期");
                    return ChildFormStatus.HasErrorInput;
                }
            }
            return ChildFormStatus.NoErrorInput;
        }

        public void InitEveryThing()
        {
            this.ChdStroke = new RecordsChdStrokeReportBLL().GetModel(PhysicalInfoFactory.ID);
            if(ChdStroke==null)
            {
                this.ChdStroke =new RecordsChdStrokeReportModel();
            }
            this.bindingManager=new SimpleBindingManager<RecordsChdStrokeReportModel>(this.inputRanges,this.inputRange_str,this.ChdStroke);
            this.bindingManager.SimpleBinding(this.tbPatientNo, "PatientNo",false);
            this.bindingManager.SimpleBinding(this.tbADnum, "AdmissionNo",false);
            this.bindingManager.SimpleBinding(this.tbCardNum, "CardNo",false);
            this.bindingManager.SimpleBinding(this.tbICDnum, "ICD10Code",false);
            int age = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd")) - Convert.ToInt32(Convert.ToDateTime( Model.Birthday).ToString("yyyyMMdd"));
            if (age.ToString().Length == 6)
            {
                age = Convert.ToInt32(age.ToString().Substring(0, 2));
            }
            else if (age.ToString().Length == 7)
            {
                age = Convert.ToInt32(age.ToString().Substring(0, 3));
            }
            else if (age.ToString().Length == 5)
            {
                age = Convert.ToInt32(age.ToString().Substring(0, 1));
            }
            else
            {
                age = 0;
            }
            this.tbAge.Text =age.ToString();
            this.tbPhoneNum.Text = Model.Phone;
            if (string.IsNullOrEmpty(this.ChdStroke.AddDistrict) && !string.IsNullOrEmpty(Model.DistrictID.ToString()))
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
                this.tbAdddistrict.Text = this.ChdStroke.AddDistrict;
            }

            if (string.IsNullOrEmpty(this.ChdStroke.AddTown) && !string.IsNullOrEmpty(Model.TownID.ToString()))
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
                this.tbAddtown.Text = this.ChdStroke.AddTown;
            }

            if (string.IsNullOrEmpty(this.ChdStroke.AddVillage) && !string.IsNullOrEmpty(Model.VillageID.ToString()))
            {
                DataTable dtVillage = new RecordsVillageBLL().GetList(string.Format("Code={0}", Model.VillageID)).Tables[0];
                if (dtVillage.Rows.Count > 0)
                {
                    DataRow rowVillage = dtVillage.Rows[0];
                    this.tbAddVillage.Text = rowVillage["Name"].ToString();
                }
            }
            else
            {
                this.tbAddVillage.Text = this.ChdStroke.AddVillage;
            }

            if (string.IsNullOrEmpty(this.ChdStroke.HouesAddDistrict) && !string.IsNullOrEmpty(Model.DistrictID.ToString()))
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
                this.tbAdddistrict2.Text = this.ChdStroke.HouesAddDistrict;
            }

            if (string.IsNullOrEmpty(this.ChdStroke.HouesAddTown) && !string.IsNullOrEmpty(Model.TownID.ToString()))
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
                this.tbAddtown2.Text = this.ChdStroke.HouesAddTown;
            }

            if (string.IsNullOrEmpty(this.ChdStroke.HouseAddVillage) && !string.IsNullOrEmpty(Model.VillageID.ToString()))
            {
                DataTable dtVillage1 = new RecordsVillageBLL().GetList(string.Format("Code={0}", Model.VillageID)).Tables[0];
                if (dtVillage1.Rows.Count > 0)
                {
                    DataRow rowVillage1 = dtVillage1.Rows[0];
                    this.tbAddVillage2.Text = rowVillage1["Name"].ToString();
                }
            }
            else
            {
                this.tbAddVillage2.Text = this.ChdStroke.HouseAddVillage;
            }
           
            this.bindingManager.SimpleBinding(tbAddNum, "AddNum", false);
            this.bindingManager.SimpleBinding(tbAddNum2, "HouseAddNum", false);
            if(!string.IsNullOrEmpty(this.ChdStroke.AcuteMI))
            {
                string guanxinb = this.ChdStroke.AcuteMI;
                foreach (string jb in guanxinb.Split(','))
                {
                    int nums;
                    if(int.TryParse(jb,out nums))
                    {
                        this.gxbzd[nums - 1].Checked = true;
                    }
                }
            }

            if(!string.IsNullOrEmpty(this.ChdStroke.SAH))
            {
                string naocuz = this.ChdStroke.SAH;
                foreach (string jb in naocuz.Split(','))
                {
                    int nums;
                    if(int.TryParse(jb,out nums))
                    {
                        this.nczzd[nums - 1].Checked = true;
                    }
                }
            }

            if(!string.IsNullOrEmpty(this.ChdStroke.Diagnosis))
            {
                string linchuanzd = this.ChdStroke.Diagnosis;
                foreach (string jb in linchuanzd.Split(','))
                {
                    int nums;
                    if(int.TryParse(jb,out nums))
                    {
                        this.zdyj[nums - 1].Checked = true;
                    }
                }
            }

            if (this.ChdStroke.DiseaseTime.HasValue)
            {
                this.fabDate.Value = this.ChdStroke.DiagnosisTime.Value;
            }
            else
            {
                this.fabDate.Value = DateTime.Now;
            }

            if (this.ChdStroke.DiagnosisTime.HasValue)
            {
                this.quezDate.Value = this.ChdStroke.DiagnosisTime.Value;
            }
            else
            {
                this.quezDate.Value = DateTime.Now;
            }
            if(this.ChdStroke.FirstOnset=="1")
            {
                this.rbyes.Checked = true;
            }
            else if(this.ChdStroke.FirstOnset=="2")
            {
                this.rbNo.Checked = true;
            }
            else
            {
                this.rbyes.Checked = false;
                this.rbNo.Checked = false;
            }
            if (!string.IsNullOrEmpty(this.ChdStroke.ConfirmedUnit))
            {
                switch (this.ChdStroke.ConfirmedUnit)
                {
                    case "1": this.rdprovinceh.Checked = true; break;
                    case "2": this.rdcityh.Checked = true; break;
                    case "3": this.rddistircth.Checked = true; break;
                    case "4": this.rdtownh.Checked = true; break;
                    case "5": this.rdotherh.Checked = true; break;
                    case "9": this.rdbuxingh.Checked = true; break;
                    default: break;
                }
            }
            this.bindingManager.SimpleBinding(this.tbBkUnit, "CardUnit",false);
            this.bindingManager.SimpleBinding(this.tbBkdoctor,"CardDoctor",false);
            if (this.ChdStroke.CardDate.HasValue)
            {
                this.baokDate.Value = this.ChdStroke.CardDate.Value;
            }
            else
            {
                this.baokDate.Value = DateTime.Now;
            }
            if(this.ChdStroke.DeathDate.HasValue)
            {
                this.deathUC.txtTime.Text = Convert.ToDateTime(this.ChdStroke.DeathDate).ToLongDateString();
            }
            this.bindingManager.SimpleBinding(this.tbReason, "DeathReason", false);
            this.bindingManager.SimpleBindingInt(this.tbDieNum, "DeathCode", true);
            this.EveryThingIsOk = true;
        }

        private void frmChdStrokeReport_Load(object sender, EventArgs e)
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
            if (PhysicalInfoFactory.ID == -1)
            {
                return true;
            }
            RecordsChdStrokeReportBLL bll=new RecordsChdStrokeReportBLL();
            this.ChdStroke.OutKey= PhysicalInfoFactory.ID;
            if (!bll.ExistsOutKey(this.ChdStroke.IDCardNo,PhysicalInfoFactory.ID))
            {
                bll.Add(this.ChdStroke);
            }
            else
            {
                bll.Update(this.ChdStroke);
            }
            return true;
        }
        public void UpdataToModel()
        {
            this.ChdStroke.PatientNo = this.tbPatientNo.Text;
            this.ChdStroke.AdmissionNo = this.tbADnum.Text;
            this.ChdStroke.Age = this.tbAge.Text;
            this.ChdStroke.CardNo = this.tbCardNum.Text;
            this.ChdStroke.IDCardNo = this.Model.IDCardNo;
            this.ChdStroke.ICD10Code = this.tbICDnum.Text;
            this.ChdStroke.Phone = this.Model.Phone;
            this.ChdStroke.AddDistrict = this.tbAdddistrict.Text;
            this.ChdStroke.AddTown = this.tbAddtown.Text;
            this.ChdStroke.AddVillage = this.tbAddVillage.Text;
            this.ChdStroke.AddNum = this.tbAddNum.Text;
            this.ChdStroke.HouesAddDistrict = this.tbAdddistrict2.Text;
            this.ChdStroke.HouesAddTown = this.tbAddtown2.Text;
            this.ChdStroke.HouseAddVillage = this.tbAddVillage2.Text;
            this.ChdStroke.HouseAddNum = this.tbAddNum2.Text;
            
            string guanxb = "";
            for (int i = 0; i < gxbzd.Count; i++)
            {
                if(gxbzd[i].Checked)
                {
                    guanxb = guanxb + string.Format("{0},", i + 1);
                }
            }
            this.ChdStroke.AcuteMI = guanxb.Trim(new char[] {','});

            string naocz = "";
            for (int i = 0; i < nczzd.Count; i++)
            {
                if(nczzd[i].Checked)
                {
                    naocz = naocz + string.Format("{0},", i + 1);
                }
            }
            this.ChdStroke.SAH = naocz.Trim(new char[]{','});

            string zhendyj = "";
            for (int i = 0; i < zdyj.Count; i++)
            {
                if(zdyj[i].Checked)
                {
                    zhendyj = zhendyj + string.Format("{0},", i + 1);
                }
            }
            this.ChdStroke.Diagnosis = zhendyj.Trim(new char[] {','});
            this.ChdStroke.DiseaseTime = this.fabDate.Value;
            this.ChdStroke.DiagnosisTime = this.quezDate.Value;
            if(this.rbyes.Checked)
            {
                this.ChdStroke.FirstOnset = "1";
            }
            else if (this.rbNo.Checked)
            {
                this.ChdStroke.FirstOnset = "2";
            }
            else
            {
                this.ChdStroke.FirstOnset = "";
            }

            if(this.rdprovinceh.Checked)
            {
                this.ChdStroke.ConfirmedUnit = "1";
            }
            else if(this.rdcityh.Checked)
            {
                this.ChdStroke.ConfirmedUnit = "2";
            }
            else if (this.rddistircth.Checked)
            {
                this.ChdStroke.ConfirmedUnit = "3";
            }
            else if (this.rdtownh.Checked)
            {
                this.ChdStroke.ConfirmedUnit = "4";
            }
            else if (this.rdotherh.Checked)
            {
                this.ChdStroke.ConfirmedUnit = "5";
            }
            else if (this.rdbuxingh.Checked)
            {
                this.ChdStroke.ConfirmedUnit = "9";
            }
          
            this.ChdStroke.CardUnit = this.tbBkUnit.Text;
            this.ChdStroke.CardDoctor = this.tbBkdoctor.Text;
            this.ChdStroke.CardDate = this.baokDate.Value;
            if (!string.IsNullOrEmpty(this.deathUC.txtTime.Text))
            {
                this.ChdStroke.DeathDate = Convert.ToDateTime(this.deathUC.txtTime.Text);
            }
            else
            {
                this.ChdStroke.DeathDate = null;
            }
            this.ChdStroke.DeathReason = this.tbReason.Text;
            this.ChdStroke.DeathCode = this.tbDieNum.Text;
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsChdStrokeReportModel ChdStroke { get; set; }

        public string GetJobCodeName(string num)
        {
            switch (num)
            {
                case "1":
                    return "国家机关、党群组织、企业、事业单位负责人";
                    break;
                case "2":
                    return "专业技术人员";
                    break;
                case "3":
                    return "办事人员和有关人";
                    break;
                case "4":
                    return "商业、服务人员";
                    break;
                case "5":
                    return "农、林、牧、渔、水利生产人员";
                    break;
                case "6":
                    return "生产运输设备操作人员及有关人员";
                    break;
                case "7":
                    return "军人";
                    break;
                case "8":
                    return "不便分类的其他从业人员";
                    break;
                default:
                    break;
            }
            return "";
        }

        private void rbyes_CheckedChanged(object sender, EventArgs e)
        {
            if(rbyes.Checked)
            {
                rbNo.Checked = false;
            }
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if(rbNo.Checked)
            {
                rbyes.Checked = false;
            }
        }
       
    }
}
