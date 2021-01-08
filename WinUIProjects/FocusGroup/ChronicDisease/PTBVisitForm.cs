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
using KangShuoTech.Utilities.CommonTools;
using KangShuoTech.Utilities.CommonControl;

namespace FocusGroup
{
    public partial class PTBVisitForm : Form,  IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        string visitCount;
        private SimpleBindingManager<ChronicLungerVisitModel> bindingManager;
        private ChronicLungerVisitBLL ptb_oper;
        public ChronicLungerVisitModel chronicLungerVisitModel { get; set; }
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private ManyCheckboxs<ChronicLungerVisitModel> zhengzhuang;
        private ManyCheckboxs<ChronicLungerVisitModel> drugType;
        private ManyCheckboxs<ChronicLungerVisitModel> stopCureReason;

        public PTBVisitForm(string visit)
        {
            InitializeComponent();
            visitCount = visit;
            if(visitCount == "4")
            {
                this.GBoxManager.Visible = true;
                this.GBoxStopCure.Visible = true;
            }
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("Symptom", 30));
            this.inputrange_str.Add(new InputRangeStr("SymptomEx", 100));
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("SmokeDayNum", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("DayDrinkVolume", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("NextSmokeDayNum", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("NextDayDrinkVolume", 1000M, false));
            this.EveryThingIsOk = false;
        }

        public ChildFormStatus CheckErrorInput()
        {
            bool flag = false;
            if (this.dtpNextVisitDate.Value.Date < this.dtpFollowupDate.Value.Date)
            {
                flag = true;
                this.SaveDataInfo = "下次随访日期不能小于当前的随访日期！\r\n";
            }

            if (this.dtpFollowupDate.Value.Date > DateTime.Today)
            {
                PTBVisitForm follow = this;
                string str = follow.SaveDataInfo + "随访日期不能晚于当前日期!\r\n";
                follow.SaveDataInfo = str;
                flag = true;
            }

            if ((!this.bindingManager.ErrorInput && !flag))
            {
                return ChildFormStatus.NoErrorInput;
            }

            return ChildFormStatus.HasErrorInput;
        }

        public void InitEveryThing()
        {
            int num;
            this.GetModel();

            if (string.IsNullOrEmpty(this.chronicLungerVisitModel.VisitDoctor))
            {
                this.chronicLungerVisitModel.VisitDoctor = this.Model.Doctor;
            }

            if (this.chronicLungerVisitModel.FollowupDate.HasValue)
            {
                this.dtpFollowupDate.Value = this.chronicLungerVisitModel.FollowupDate.Value;
            }

            this.bindingManager.SimpleBinding(this.tbDoctor, "VisitDoctor", false);

            string followupWay = chronicLungerVisitModel.FollowupWay.ToString();

            if (followupWay == "" || followupWay == "1")  radMZ.Checked = true;
            else if (followupWay == "2")  radFamily.Checked = true;
            else if(followupWay == "3") this.radPhone.Checked = true;

            this.bindingManager.SimpleBinding(this.txtCureMonth, "CureMonth", false);
            string supervisor = string.IsNullOrEmpty(this.chronicLungerVisitModel.Supervisor) ? "" : this.chronicLungerVisitModel.Supervisor.ToString();

            if (supervisor == "1") rdoSupervisor1.Checked = true;
            else if (supervisor == "2") rdoSupervisor2.Checked = true;
            else if (supervisor == "3") rdoSupervisor3.Checked = true;
            else if (supervisor == "4") rdoSupervisor4.Checked = true;

            this.zhengzhuang = new ManyCheckboxs<ChronicLungerVisitModel>(this.chronicLungerVisitModel);
            this.zhengzhuang.oneVetoChecked = (Action<bool>)Delegate.Combine(this.zhengzhuang.oneVetoChecked, new Action<bool>(this.SetOther));
            this.zhengzhuang.AddCk(this.ckGroup0, true);
            this.zhengzhuang.AddCk(new CheckBox[] { this.ckGroup1, this.ckGroup2, this.ckGroup3, this.ckGroup4, this.ckGroup5, this.ckGroup6, this.ckGroup7, this.ckGroup8, this.ckGroup9 });
            this.zhengzhuang.BindingProperty("Symptom", "");
            this.bindingManager.SimpleBinding(this.tbZzOther, "SymptomEx", false);
            this.bindingManager.SimpleBinding(this.txtSmokeDayNum, "SmokeDayNum", true);
            this.bindingManager.SimpleBinding(this.txtDayDrinkVolume, "DayDrinkVolume", true);
            this.bindingManager.SimpleBinding(this.txtNextSmokeDayNum, "NextSmokeDayNum", true);
            this.bindingManager.SimpleBinding(this.txtNextDayDrinkVolume, "NextDayDrinkVolume", true);
            this.bindingManager.SimpleBinding(this.txtChemotherapyScheme, "ChemotherapyScheme", false);
            string medicationCompliance = string.IsNullOrEmpty(this.chronicLungerVisitModel.MedicationCompliance) ? "" : this.chronicLungerVisitModel.MedicationCompliance.ToString();

            if (medicationCompliance == "1")
            {
                rdoMedicationCompliance1.Checked = true;
            }
            else if (medicationCompliance == "2")
            {
                rdoMedicationCompliance2.Checked = true;
            }

            this.bindingManager.SimpleBindingInt(this.txtOmissiveTimes, "OmissiveTimes", true);
            this.drugType = new ManyCheckboxs<ChronicLungerVisitModel>(this.chronicLungerVisitModel);
            this.drugType.AddCk(new CheckBox[] { this.chkDrugType1, this.chkDrugType2, this.chkDrugType3, this.chkDrugType4 });
            this.drugType.BindingProperty("DrugType", "");
            string adr = string.IsNullOrEmpty(this.chronicLungerVisitModel.Adr) ? "" : this.chronicLungerVisitModel.Adr.ToString();

            if(adr == "1")  this.rdoAdr1 .Checked =true ;
            else if(adr == "2") this.rdoAdr2.Checked = true;

            string complication = string.IsNullOrEmpty(this.chronicLungerVisitModel.Complication) ? "" : this.chronicLungerVisitModel.Complication.ToString();

            if(complication == "1") this.rdoComplication1.Checked = true;
            else if(complication =="2") this.rdoComplication2.Checked = true;

            this.bindingManager.SimpleBinding(this.txtAdrEx, "AdrEx", false);
            this.bindingManager.SimpleBinding(this.txtComplicationEx, "ComplicationEx", false);
            this.bindingManager.SimpleBinding(this.txtReferralReason, "ReferralReason", false);
            this.bindingManager.SimpleBinding(this.txtReferralOrg, "ReferralOrg", false);
            this.bindingManager.SimpleBinding(this.txtReferralResult, "ReferralResult", false);
            this.bindingManager.SimpleBinding(this.txtHandleView, "HandleView", false);

            if (this.chronicLungerVisitModel.NextVisitDate.HasValue)
            {
                this.dtpNextVisitDate.Value = this.chronicLungerVisitModel.NextVisitDate.Value;
            }

            this.stopCureReason = new ManyCheckboxs<ChronicLungerVisitModel>(this.chronicLungerVisitModel);
            this.stopCureReason.AddCk(new CheckBox[] {this.chbStopCureReason1 ,this.chbStopCureReason2 ,this.chbStopCureReason3 ,this.chbStopCureReason4} );
            this.stopCureReason.BindingProperty("StopCureReason", "");

            if(this.chronicLungerVisitModel.StopCureDate.HasValue)
            {
                this.dtpStopCureDate.Value = this.chronicLungerVisitModel.StopCureDate.Value;
            }

            this.bindingManager.SimpleBindingInt (this.txtShouldVisitTimes, "ShouldVisitTimes", false);
            this.bindingManager.SimpleBindingInt(this.txtVisitTimes, "VisitTimes", false);
            this.bindingManager.SimpleBindingInt(this.txtShouldPharmacyTimes, "ShouldPharmacyTimes", false);
            this.bindingManager.SimpleBindingInt(this.txtPharmacyTimes, "PharmacyTimes", false);
            this.bindingManager.SimpleBinding(this.txtEstimateDoctor, "EstimateDoctor", false);
            this.bindingManager.SimpleBinding(this.txtPharmacyRate, "PharmacyRate", false);

            this.EveryThingIsOk = true;
        }

        public void SetOther(bool v)
        {
            this.tbZzOther.ReadOnly = v;
            if (v)
            {
                this.tbZzOther.Text = "";
            }
        }

        private void GetModel()
        {
            this.ptb_oper = new ChronicLungerVisitBLL();
            this.chronicLungerVisitModel = this.ptb_oper.GetModelByOutKey(PTBFactory.ID,this.visitCount);

            if (this.chronicLungerVisitModel == null)
            {
                ChronicLungerVisitModel chronicLungerVisit = new ChronicLungerVisitModel
                {
                    IDCardNo = this.Model.IDCardNo,
                    FollowupWay = "1"
                };

                this.chronicLungerVisitModel = chronicLungerVisit;
                this.chronicLungerVisitModel.CreatedBy = ConfigHelper.GetNode("doctor");
                this.chronicLungerVisitModel.CreatedDate = new DateTime?(DateTime.Today);
            }
            else
            {
                this.chronicLungerVisitModel.LastUpdateBy = ConfigHelper.GetNode("doctor");
                this.chronicLungerVisitModel.LastUpdateDate = new DateTime?(DateTime.Today);
            }

            this.bindingManager = new SimpleBindingManager<ChronicLungerVisitModel>(this.inputRanges, this.inputrange_str, this.chronicLungerVisitModel);
        }     

        private void txtPharmacyTimes_TextChanged(object sender, EventArgs e)
        {
            if (txtPharmacyTimes.Text.Length == 1 || txtPharmacyTimes.Text.Length == 2)
            {
                if (txtPharmacyTimes.Text != "" && txtShouldPharmacyTimes.Text != "")
                {
                    decimal num1 = Convert.ToDecimal(txtPharmacyTimes.Text);
                    decimal num2 = Convert.ToDecimal(txtShouldPharmacyTimes.Text);
                    if (Convert.ToDecimal(txtShouldPharmacyTimes.Text) != 0)
                    {
                        this.txtPharmacyRate.Text = string.Format("{0:##0.00}", Math.Round((decimal)((num1 / num2) * 100), 0));
                        this.chronicLungerVisitModel.PharmacyRate = Convert.ToDecimal(this.txtPharmacyRate.Text);

                    }
                }
            }
        }

        private void txtShouldPharmacyTimes_TextChanged(object sender, EventArgs e)
        {

            if (txtShouldPharmacyTimes.Text.Length == 1 || txtShouldPharmacyTimes.Text.Length == 2)
            {
                if (txtPharmacyTimes.Text != "" && txtShouldPharmacyTimes.Text != "")
                {
                    decimal num1 = Convert.ToDecimal(txtPharmacyTimes.Text);
                    decimal num2 = Convert.ToDecimal(txtShouldPharmacyTimes.Text);
                    if (this.chronicLungerVisitModel.ShouldPharmacyTimes != 0)
                    {
                        this.txtPharmacyRate.Text = string.Format("{0:##0.00}", Math.Round((decimal)((num1 / num2) * 100), 0));
                        this.chronicLungerVisitModel.PharmacyRate = Convert.ToDecimal(this.txtPharmacyRate.Text);

                    }
                }
            }
        }

        private void PTBVisitForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void rdoAdr1_CheckedChanged(object sender, EventArgs e)
        {
            this.txtAdrEx.ReadOnly = false;
        }

        private void rdoAdr2_CheckedChanged(object sender, EventArgs e)
        {
            this.txtAdrEx.Clear();
            this.txtAdrEx.ReadOnly = true;
        }

        private void rdoComplication1_CheckedChanged(object sender, EventArgs e)
        {
            this.txtComplicationEx.ReadOnly = false;
        }

        private void rdoComplication2_CheckedChanged(object sender, EventArgs e)
        {
            this.txtComplicationEx.Clear();
            this.txtComplicationEx.ReadOnly = true;
        }

        private void btnNoSmoke_Click(object sender, EventArgs e)
        {
            txtNextSmokeDayNum.Text = "0";
        }

        private void btnNoDrink_Click(object sender, EventArgs e)
        {
            txtNextDayDrinkVolume.Text = "0";
        }

        public bool SaveModelToDB()
        {
            if (PTBFactory.ID == -1)
            {
                return true;
            }
            ChronicLungerVisitBLL chronicLungerVisitBLL = new ChronicLungerVisitBLL();
            this.chronicLungerVisitModel.OUTKey = PTBFactory.ID;
            if (chronicLungerVisitBLL.ExistsOutKey(this.chronicLungerVisitModel.IDCardNo, PTBFactory.ID, this.chronicLungerVisitModel.VisitCount))
            {
                chronicLungerVisitBLL.Update(this.chronicLungerVisitModel);
            }
            else
            {
                chronicLungerVisitBLL.Add(this.chronicLungerVisitModel);
            }
            return true;
        }

        public void NotisfyChildStatus()
        {
            
        }

        public void UpdataToModel()
        {
            this.chronicLungerVisitModel.CustomerName = this.Model.CustomerName;
            this.chronicLungerVisitModel.RecordID = this.Model.RecordID;
            this.chronicLungerVisitModel.CustomerID = this.Model.CustomerID;
            this.chronicLungerVisitModel.VisitCount =Convert.ToInt32 (this.visitCount.ToString ());
            this.chronicLungerVisitModel.FollowupDate  = this.dtpFollowupDate.Value;
            this.chronicLungerVisitModel.NextVisitDate = this.dtpNextVisitDate.Value;
            this.chronicLungerVisitModel.StopCureDate = this.dtpStopCureDate.Value;
            if (this.rdoSupervisor1.Checked)
            {
                this.chronicLungerVisitModel.Supervisor = "1";
            }
            if (this.rdoSupervisor2.Checked)
            {
                this.chronicLungerVisitModel.Supervisor = "2";
            }
            if (this.rdoSupervisor3.Checked)
            {
                this.chronicLungerVisitModel.Supervisor = "3";
            }
            if (this.rdoSupervisor4.Checked)
            {
                this.chronicLungerVisitModel.Supervisor = "4";
            }
            if (this.radMZ.Checked)
            {
                this.chronicLungerVisitModel.FollowupWay = "1";
            }
            if (this.radFamily.Checked)
            {
                this.chronicLungerVisitModel.FollowupWay = "2";
            }
            if(this.radPhone.Checked)
            {
                this.chronicLungerVisitModel.FollowupWay = "3";
            }
            if (this.rdoMedicationCompliance1.Checked)
            {
                this.chronicLungerVisitModel.MedicationCompliance = "1";
            }
            if (this.rdoMedicationCompliance2.Checked)
            {
                this.chronicLungerVisitModel.MedicationCompliance = "2";
            }
            if(this.rdoAdr1.Checked)
            {
                this.chronicLungerVisitModel.Adr = "1";
            }
            if (this.rdoAdr2.Checked)
            {
                this.chronicLungerVisitModel.Adr = "2";
            }
            if(this.rdoComplication1.Checked)
            {
                this.chronicLungerVisitModel.Complication = "1";
            }
            if (this.rdoComplication2.Checked)
            {
                this.chronicLungerVisitModel.Complication = "2";
            }

        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public int IDPerson { get; set; }
    }
}
