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
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.Utilities.CommonTools;
using System.IO;
using AxHWPenSignLib;
using System.Configuration;

namespace FocusGroup
{
    public partial class PTBInfoForm : Form, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<ChronicLungerFirstVisitModel> bindingManager;
        private ChronicLungerFirstVisitBLL ptb_oper;
        public ChronicLungerFirstVisitModel chronicLungerFirstVisitModel { get; set; }
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private ManyCheckboxs<ChronicLungerFirstVisitModel> zhengzhuang;
        private ManyCheckboxs<ChronicLungerFirstVisitModel> drugType;
        private string visitdate;
        private string SignS = "";
        private string SignDoc = "";//医生签名
        private int HW_eOk = 0;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/PTBVisit/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "PTBVisit//"; //签名保存路径
        
        public PTBInfoForm()
        {
            InitializeComponent();
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("PatientType", 1));
            this.inputrange_str.Add(new InputRangeStr("Sputumfungs", 1));
            this.inputrange_str.Add(new InputRangeStr("DrugFast", 1));
            this.inputrange_str.Add(new InputRangeStr("Symptom", 30));
            this.inputrange_str.Add(new InputRangeStr("SymptomEx", 100));
            this.inputrange_str.Add(new InputRangeStr("ChemotherapyScheme", 100));
            this.inputrange_str.Add(new InputRangeStr("MedicationCompliance", 1));
            this.inputrange_str.Add(new InputRangeStr("DrugType", 30));
            this.inputrange_str.Add(new InputRangeStr("Supervisor", 1));
            this.inputrange_str.Add(new InputRangeStr("StandaloneRoom", 1));
            this.inputrange_str.Add(new InputRangeStr("Ventilation", 1));
            this.inputrange_str.Add(new InputRangeStr("Supervisor", 1));
            this.inputrange_str.Add(new InputRangeStr("MediclineReceivePlace", 100));
            this.inputrange_str.Add(new InputRangeStr("RecordcardWrite", 1));
            this.inputrange_str.Add(new InputRangeStr("PharmacyWayDeposit", 1));
            this.inputrange_str.Add(new InputRangeStr("Therapies", 1));
            this.inputrange_str.Add(new InputRangeStr("IndisciplineHarm", 1));
            this.inputrange_str.Add(new InputRangeStr("AdrsHandle", 1));
            this.inputrange_str.Add(new InputRangeStr("SubsequentVisit", 1));
            this.inputrange_str.Add(new InputRangeStr("InsistPharmacy", 1));
            this.inputrange_str.Add(new InputRangeStr("LivingHabit", 1));
            this.inputrange_str.Add(new InputRangeStr("ChecktouchPerson", 1));

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
                PTBInfoForm follow = this;
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
            if (string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.VisitDoctor))
            {
                this.chronicLungerFirstVisitModel.VisitDoctor = ConfigHelper.GetNode("doctorName");
            }
            this.bindingManager.SimpleBinding(this.tbDoctor, "VisitDoctor", false);

            string followupWay = chronicLungerFirstVisitModel.FollowupWay.ToString();
            if (followupWay == "" || followupWay == "1")
            {
                radMZ.Checked = true;
            }
            else if (followupWay == "2")
            {
                radFamily.Checked = true;
            }
            string patientType = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.PatientType) ? "" : this.chronicLungerFirstVisitModel.PatientType.ToString();
            if (patientType == "" || patientType == "1")
            {
                rdoPatientType1.Checked = true;
            }
            else if (patientType == "2")
            {
                rdoPatientType2.Checked = true;
            }
            string sputumfungs =string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.Sputumfungs) ?  "" : chronicLungerFirstVisitModel.Sputumfungs.ToString();
            if (sputumfungs == "1")
            {
                rdoSputumfungs1.Checked = true;
            }
            else if (sputumfungs == "2")
            {
                rdoSputumfungs2.Checked = true;
            }
            else if (sputumfungs == "3")
            {
                rdoSputumfungs3.Checked = true;
            }
            string drugFast = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.DrugFast) ? "" : chronicLungerFirstVisitModel.DrugFast.ToString();
            if (drugFast == "1")
            {
                rdoDrugFast1.Checked = true;
            }
            else if (drugFast == "2")
            {
                rdoDrugFast2.Checked = true;
            }
            else if (drugFast == "3")
            {
                rdoDrugFast3.Checked = true;
            }
            this.zhengzhuang = new ManyCheckboxs<ChronicLungerFirstVisitModel>(this.chronicLungerFirstVisitModel);
            this.zhengzhuang.oneVetoChecked = (Action<bool>)Delegate.Combine(this.zhengzhuang.oneVetoChecked, new Action<bool>(this.SetOther));
            this.zhengzhuang.AddCk(this.ckGroup0, true);
            this.zhengzhuang.AddCk(new CheckBox[] { this.ckGroup1, this.ckGroup2, this.ckGroup3, this.ckGroup4, this.ckGroup5, this.ckGroup6, this.ckGroup7, this.ckGroup8, this.ckGroup9 });
            this.zhengzhuang.BindingProperty("Symptom", "");
            this.bindingManager.SimpleBinding(this.tbZzOther, "SymptomEx", false);

            this.bindingManager.SimpleBinding(this.txtChemotherapyScheme, "ChemotherapyScheme", false);
            string medicationCompliance = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.MedicationCompliance) ? "" : this.chronicLungerFirstVisitModel.MedicationCompliance.ToString();
            if (medicationCompliance == "1")
            {
                rdoMedicationCompliance1.Checked = true;
            }
            else if (medicationCompliance == "2")
            {
                rdoMedicationCompliance2.Checked = true;
            }
            this.drugType = new ManyCheckboxs<ChronicLungerFirstVisitModel>(this.chronicLungerFirstVisitModel);
            this.drugType.AddCk(new CheckBox[] {this.chkDrugType1,this.chkDrugType2,this.chkDrugType3,this.chkDrugType4  });
            this.drugType.BindingProperty("DrugType", "");
            string supervisor = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.Supervisor) ? "" : this.chronicLungerFirstVisitModel.Supervisor.ToString();
            if (supervisor == "1")
            {
                rdoSupervisor1.Checked = true;
            }
            else if (supervisor == "2")
            {
                rdoSupervisor2.Checked = true;
            }
            else if (supervisor == "3")
            {
                rdoSupervisor3.Checked = true;
            }
            else if (supervisor == "4")
            {
                rdoSupervisor4.Checked = true;
            }
            string standaloneRoom = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.StandaloneRoom) ? "" : this.chronicLungerFirstVisitModel.StandaloneRoom.ToString();
            if (standaloneRoom == "1")
            {
                this.rdoStandaloneRoom1.Checked = true;
            }
            else if (standaloneRoom == "2")
            {
                this.rdoStandaloneRoom2.Checked = true;
            }

            string ventilation = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.Ventilation) ? "" : this.chronicLungerFirstVisitModel.Ventilation.ToString();
            if (ventilation == "1")
            {
                this.rdoVentilation1.Checked = true;
            }
            else if (ventilation == "2")
            {
                this.rdoVentilation2.Checked = true;
            }
            else if (ventilation == "3")
            {
                this.rdoVentilation3.Checked = true;
            }

            this.bindingManager.SimpleBinding(this.txtSmokeDayNum, "SmokeDayNum", true);
            this.bindingManager.SimpleBinding(this.txtDayDrinkVolume, "DayDrinkVolume", true);
            this.bindingManager.SimpleBinding(this.txtNextSmokeDayNum, "NextSmokeDayNum", true);
            this.bindingManager.SimpleBinding(this.txtNextDayDrinkVolume, "NextDayDrinkVolume", true);
            this.bindingManager.SimpleBinding(this.txtMediclineReceivePlace, "MediclineReceivePlace", false);
            if (this.chronicLungerFirstVisitModel.MediclineReceiveTime.HasValue)
            {
                this.txtMediclineReceiveTime.Value = this.chronicLungerFirstVisitModel.MediclineReceiveTime.Value;
            }

            string recordcardWrite = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.RecordcardWrite) ? "" : this.chronicLungerFirstVisitModel.RecordcardWrite.ToString();
            if (recordcardWrite == "1")
            {
                this.rdoRecordcardWrite1.Checked = true;
            }
            else if (recordcardWrite == "2")
            {
                this.rdoRecordcardWrite2.Checked = true;
            }

            string pharmacyWayDeposit = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.PharmacyWayDeposit) ? "" : this.chronicLungerFirstVisitModel.PharmacyWayDeposit.ToString();
            if (pharmacyWayDeposit == "1")
            {
                this.rdoPharmacyWayDeposit1.Checked = true;
            }
            else if (pharmacyWayDeposit == "2")
            {
                this.rdoPharmacyWayDeposit2.Checked = true;
            }

            string therapies = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.Therapies) ? "" : this.chronicLungerFirstVisitModel.Therapies.ToString();
            if (therapies == "1")
            {
                this.rdoTherapies1.Checked = true;
            }
            else if (therapies == "2")
            {
                this.rdoTherapies2.Checked = true;
            }
            string indisciplineHarm = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.IndisciplineHarm) ? "" : this.chronicLungerFirstVisitModel.IndisciplineHarm.ToString();
            if (indisciplineHarm == "1")
            {
                this.rdoIndisciplineHarm1.Checked = true;
            }
            else if (indisciplineHarm == "2")
            {
                this.rdoIndisciplineHarm2.Checked = true;
            }
            string adrsHandle = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.AdrsHandle) ? "" : this.chronicLungerFirstVisitModel.AdrsHandle.ToString();
            if (adrsHandle == "1")
            {
                this.rdoAdrsHandle1.Checked = true;
            }
            else if (adrsHandle == "2")
            {
                this.rdoAdrsHandle2.Checked = true;
            }
            string subsequentVisit = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.SubsequentVisit) ? "" : this.chronicLungerFirstVisitModel.SubsequentVisit.ToString();
            if (subsequentVisit == "1")
            {
                this.rdoSubsequentVisit1.Checked = true;
            }
            else if (subsequentVisit == "2")
            {
                this.rdoSubsequentVisit2.Checked = true;
            }
            string insistPharmacy = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.InsistPharmacy) ? "" : this.chronicLungerFirstVisitModel.InsistPharmacy.ToString();
            if (insistPharmacy == "1")
            {
                this.rdoInsistPharmacy1.Checked = true;
            }
            else if (insistPharmacy == "2")
            {
                this.rdoInsistPharmacy2.Checked = true;
            }
            string livingHabit = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.LivingHabit) ? "" : this.chronicLungerFirstVisitModel.LivingHabit.ToString();
            if (livingHabit == "1")
            {
                this.rdoLivingHabit1.Checked = true;
            }
            else if (livingHabit == "2")
            {
                this.rdoLivingHabit2.Checked = true;
            }

            string checktouchPerson = string.IsNullOrEmpty(this.chronicLungerFirstVisitModel.ChecktouchPerson) ? "" : this.chronicLungerFirstVisitModel.ChecktouchPerson.ToString();
            if (checktouchPerson == "1")
            {
                this.rdoChecktouchPerson1.Checked = true;
            }
            else if (checktouchPerson == "2")
            {
                this.rdoChecktouchPerson2.Checked = true;
            }

            this.bindingManager.SimpleBinding(this.txtChecktouchPerson, "EstimateDoctor", false);

            if (this.chronicLungerFirstVisitModel.NextVisitDate.HasValue)
            {
                this.dtpNextVisitDate.Value = this.chronicLungerFirstVisitModel.NextVisitDate.Value;
            }

            //签名初始化
            this.SignS = string.Format("{0}{1}_{2}.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpFollowupDate.Value).ToString("yyyyMMdd"));
            if (File.Exists(this.SignS))
            {
                Image imgeb = Image.FromFile(SignS);
                picSignJs.Image = imgeb;
                picSignJs.Show();
                this.lkJs.Enabled = true;
                picSignJs.BackColor = Color.White;
            }
            this.SignDoc = string.Format("{0}{1}_{2}_Doc.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpFollowupDate.Value).ToString("yyyyMMdd"));
            if (File.Exists(this.SignDoc))
            {
                Image imgeb = Image.FromFile(SignDoc);
                picSignYs.Image = imgeb;
                picSignYs.Show();
                this.lkYs.Enabled = true;
                picSignYs.BackColor = Color.White;
            }


            this.EveryThingIsOk = true;
        }

        private void IniPenSignByContrl(AxHWPenSignLib.AxHWPenSign axHWPenSign)
        {
            const UInt32 intColor = 0xC8F8DE;
            axHWPenSign.HWSetBkColor(intColor);
            axHWPenSign.HWSetCtlFrame(2, 0x000000);
            axHWPenSign.HWSetExtWndHandle(this.Handle.ToInt32());
            axHWPenSign.HWSetPenWidth(1);
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
            this.ptb_oper = new ChronicLungerFirstVisitBLL();
            if (PTBFactory.ID == 0)
            {
                PTBFactory.NewAdd = true; //新增一笔数据标志
                this.chronicLungerFirstVisitModel = this.ptb_oper.GetModel(this.Model.IDCardNo);
                this.dtpFollowupDate.Value = DateTime.Today.Date;
            }
            else
            {
                this.chronicLungerFirstVisitModel = this.ptb_oper.GetModelByID(PTBFactory.ID);
                if (this.chronicLungerFirstVisitModel.FollowupDate.HasValue)
                {
                    this.dtpFollowupDate.Value = this.chronicLungerFirstVisitModel.FollowupDate.Value;
                    this.visitdate = this.chronicLungerFirstVisitModel.FollowupDate.ToString();
                }
                PTBFactory.NewAdd = false;
            }
            if (this.chronicLungerFirstVisitModel == null)
            {
                ChronicLungerFirstVisitModel chronicLungerFirstVisit = new ChronicLungerFirstVisitModel
                {
                    IDCardNo = this.Model.IDCardNo,
                    FollowupWay = "1"
                };
                this.chronicLungerFirstVisitModel = chronicLungerFirstVisit;
                this.chronicLungerFirstVisitModel.CreatedBy = ConfigHelper.GetNode("doctor");
                this.chronicLungerFirstVisitModel.CreatedDate = new DateTime?(DateTime.Today);
            }
            else
            {
                PTBFactory.ID = this.chronicLungerFirstVisitModel.ID;
                this.chronicLungerFirstVisitModel.LastUpdateBy = ConfigHelper.GetNode("doctor");
                this.chronicLungerFirstVisitModel.LastUpdateDate = new DateTime?(DateTime.Today);
            }
            this.bindingManager = new SimpleBindingManager<ChronicLungerFirstVisitModel>(this.inputRanges, this.inputrange_str, this.chronicLungerFirstVisitModel);
        }
        private void PTBInfoForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.SignPath))
            {
                Directory.CreateDirectory(this.SignPath);
            }
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
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
            this.chronicLungerFirstVisitModel.FollowupDate = this.dtpFollowupDate.Value;
            this.chronicLungerFirstVisitModel.MediclineReceiveTime = this.txtMediclineReceiveTime.Value;
            this.chronicLungerFirstVisitModel.NextVisitDate = this.dtpNextVisitDate.Value;
            ChronicLungerFirstVisitBLL chronicLungerFirstVisitBLL = new ChronicLungerFirstVisitBLL();
            string strWhere=string.Format("IDCardNo='{0}' and FollowupDate='{1}' ", this.chronicLungerFirstVisitModel.IDCardNo, this.dtpFollowupDate.Value.Date);
            ChronicLungerFirstVisitModel ChronicModel = chronicLungerFirstVisitBLL.CheckModel(strWhere);
            if (ChronicModel != null)
            {
                if (PTBFactory.ID > 0 && this.visitdate == this.chronicLungerFirstVisitModel.FollowupDate.ToString())
                {
                    this.chronicLungerFirstVisitModel.ID = ChronicModel.ID;
                    PTBFactory.ID = ChronicModel.ID;
                    chronicLungerFirstVisitBLL.Update(this.chronicLungerFirstVisitModel);
                }
                else
                {
                    DialogResult result = DialogResult.OK;
                    result = MessageBox.Show("此日期下已有随访信息，是否进行修改？", "提示", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        if (!PTBFactory.NewAdd)
                        {
                            chronicLungerFirstVisitBLL.Delete(this.chronicLungerFirstVisitModel.ID);
                        }
                        this.chronicLungerFirstVisitModel.ID = ChronicModel.ID;
                        PTBFactory.ID = ChronicModel.ID;
                        chronicLungerFirstVisitBLL.Update(this.chronicLungerFirstVisitModel);
                    }
                    else
                    {
                        PTBFactory.ID = -1;
                        return true;
                    }
                }

            }
            else
            {
                if (!PTBFactory.NewAdd)
                {
                    chronicLungerFirstVisitBLL.Delete(this.chronicLungerFirstVisitModel.ID);
                }
                PTBFactory.ID = chronicLungerFirstVisitBLL.Add(this.chronicLungerFirstVisitModel);
            }

            string NewSign = string.Format("{0}{1}_{2}.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpFollowupDate.Value).ToString("yyyyMMdd"));
            string NewSignDoc = string.Format("{0}{1}_{2}_Doc.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpFollowupDate.Value).ToString("yyyyMMdd"));
     
            return true;
        }
        private void savepicture(AxHWPenSign axHWPenSign, PictureBox pBoxImg, string OldSign, string NewSign)
        {
            try
            {
                if (pBoxImg.Image == null)
                {
                    if (File.Exists(OldSign))
                    {
                        File.Delete(OldSign);//删除原有的签名
                    }
                    if (File.Exists(NewSign))
                    {
                        File.Delete(NewSign);//删除原有的签名
                    }

                    axHWPenSign.HWSetFilePath(NewSign);//签名
                    long result1 = axHWPenSign.HWSaveFile();
                }
                else
                {
                    if (pBoxImg.Image != null)
                    {
                        pBoxImg.Image.Dispose();
                    }
                    if (NewSign != OldSign)
                    {
                        if (File.Exists(OldSign))
                        {
                            File.Copy(OldSign, NewSign);
                            File.Delete(OldSign);//删除原来的图片
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void NotisfyChildStatus()
        {

        }

        public void UpdataToModel()
        {
            this.chronicLungerFirstVisitModel.CustomerName = this.Model.CustomerName;
            this.chronicLungerFirstVisitModel.RecordID = this.Model.RecordID;
            this.chronicLungerFirstVisitModel.CustomerID = this.Model.CustomerID;
            if (this.radMZ.Checked )
            {
                this.chronicLungerFirstVisitModel.FollowupWay = "1";
            }
            if(this.radFamily.Checked)
            {
                this.chronicLungerFirstVisitModel.FollowupWay = "2";
            }
            if(this.rdoPatientType1.Checked)
            {
                this.chronicLungerFirstVisitModel.PatientType = "1";
            }
            if (this.rdoPatientType2.Checked)
            {
                this.chronicLungerFirstVisitModel.PatientType = "2";
            }
            if(this.rdoSputumfungs1.Checked )
            {
                this.chronicLungerFirstVisitModel.Sputumfungs = "1";
            }
            if (this.rdoSputumfungs2.Checked)
            {
                this.chronicLungerFirstVisitModel.Sputumfungs = "2";
            }
            if (this.rdoSputumfungs3.Checked)
            {
                this.chronicLungerFirstVisitModel.Sputumfungs = "3";
            }
            if(this.rdoDrugFast1.Checked)
            {
                this.chronicLungerFirstVisitModel.DrugFast = "1";
            }
            if (this.rdoDrugFast2.Checked)
            {
                this.chronicLungerFirstVisitModel.DrugFast = "2";
            }
            if (this.rdoDrugFast3.Checked)
            {
                this.chronicLungerFirstVisitModel.DrugFast = "3";
            }
            if(this.rdoMedicationCompliance1.Checked )
            {
                this.chronicLungerFirstVisitModel.MedicationCompliance = "1";
            }
            if (this.rdoMedicationCompliance2.Checked)
            {
                this.chronicLungerFirstVisitModel.MedicationCompliance = "2";
            }
            if(this.rdoSupervisor1.Checked)
            {
                this.chronicLungerFirstVisitModel.Supervisor = "1";
            }
            if (this.rdoSupervisor2.Checked)
            {
                this.chronicLungerFirstVisitModel.Supervisor = "2";
            }
            if (this.rdoSupervisor3.Checked)
            {
                this.chronicLungerFirstVisitModel.Supervisor = "3";
            }
            if (this.rdoSupervisor4.Checked)
            {
                this.chronicLungerFirstVisitModel.Supervisor = "4";
            }
            if(rdoStandaloneRoom1.Checked)
            {
                this.chronicLungerFirstVisitModel.StandaloneRoom = "1";
            }
            if (rdoStandaloneRoom2.Checked)
            {
                this.chronicLungerFirstVisitModel.StandaloneRoom = "2";
            }
            if(this.rdoVentilation1.Checked)
            {
                this.chronicLungerFirstVisitModel.Ventilation = "1";
            }
            if (this.rdoVentilation2.Checked)
            {
                this.chronicLungerFirstVisitModel.Ventilation = "2";
            }
            if (this.rdoVentilation3.Checked)
            {
                this.chronicLungerFirstVisitModel.Ventilation = "3";
            }
            if(rdoRecordcardWrite1.Checked)
            {
                this.chronicLungerFirstVisitModel.RecordcardWrite = "1";
            }
            if (rdoRecordcardWrite2.Checked)
            {
                this.chronicLungerFirstVisitModel.RecordcardWrite = "2";
            }
            if(rdoPharmacyWayDeposit1.Checked)
            {
                this.chronicLungerFirstVisitModel.PharmacyWayDeposit = "1";
            }
            if (rdoPharmacyWayDeposit2.Checked)
            {
                this.chronicLungerFirstVisitModel.PharmacyWayDeposit = "2";
            }
            if(rdoTherapies1.Checked)
            {
                this.chronicLungerFirstVisitModel.Therapies = "1";
            }
            if (rdoTherapies2.Checked)
            {
                this.chronicLungerFirstVisitModel.Therapies = "2";
            }
            if(rdoIndisciplineHarm1.Checked)
            {
                this.chronicLungerFirstVisitModel.IndisciplineHarm = "1";
            }
            if (rdoIndisciplineHarm2.Checked)
            {
                this.chronicLungerFirstVisitModel.IndisciplineHarm = "2";
            }
            if(rdoAdrsHandle1.Checked)
            {
                this.chronicLungerFirstVisitModel.AdrsHandle = "1";
            }
            if (rdoAdrsHandle2.Checked)
            {
                this.chronicLungerFirstVisitModel.AdrsHandle = "2";
            }
            if(rdoSubsequentVisit1.Checked )
            {
                this.chronicLungerFirstVisitModel.SubsequentVisit = "1";
            }
            if (rdoSubsequentVisit2.Checked)
            {
                this.chronicLungerFirstVisitModel.SubsequentVisit = "2";
            }
            if(rdoInsistPharmacy1.Checked)
            {
                this.chronicLungerFirstVisitModel.InsistPharmacy = "1";
            }
            if (rdoInsistPharmacy2.Checked)
            {
                this.chronicLungerFirstVisitModel.InsistPharmacy = "2";
            }
            if(rdoLivingHabit1.Checked)
            {
                this.chronicLungerFirstVisitModel.LivingHabit = "1";
            }
            if (rdoLivingHabit2.Checked)
            {
                this.chronicLungerFirstVisitModel.LivingHabit = "2";
            }
            if(rdoChecktouchPerson1.Checked)
            {
                this.chronicLungerFirstVisitModel.ChecktouchPerson = "1";
            }
            if (rdoChecktouchPerson2.Checked)
            {
                this.chronicLungerFirstVisitModel.ChecktouchPerson = "2";
            }
        }
        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }
        public int IDPerson { get; set; }
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("", picSignJs);
        }
       

        private void lkYs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_Doc", picSignYs);
        }

        private void picSignYs_Click(object sender, EventArgs e)
        {
            Sign("_Doc", picSignYs);
        }

        private void picSignJs_Click(object sender, EventArgs e)
        {
            Sign("", picSignJs);
        }

        private void Sign(string DaySign, PictureBox picture)
        {
            FingerPrint.SignForm loadForm = new FingerPrint.SignForm();
            string date = dtpFollowupDate.Value.ToString("yyyyMMdd");
            if (!Directory.Exists(SignPath + date))
            {
                Directory.CreateDirectory(SignPath + date);
            }
            loadForm.IDCardNo = Model.IDCardNo + "_" + date;
            loadForm.SignPath = SignPath;
            loadForm.SignName = DaySign;
            if (loadForm.ShowDialog() == DialogResult.OK)
            {
                if (picture.Image != null)
                {
                    picture.Image.Dispose();
                    picture.Image = null;
                }
                string path = string.Format("{0}{1}{2}.png", SignPath, Model.IDCardNo + "_" + date, DaySign);
                Image imgeb = Image.FromFile(path);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picture.Image = bmp;
                imgeb.Dispose();
                picture.BackColor = Color.White;
            }
        }
        private void Clear(string DaySign, PictureBox picture)
        {
            try
            {
                if (picture.Image != null)
                {
                    picture.Image.Dispose();
                    picture.Image = null;
                    string date = dtpFollowupDate.Value.ToString("yyyyMMdd");
                    string path = SignPath + Model.IDCardNo + "_" + date + DaySign + ".png";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    picture.BackColor = Color.FromArgb(222, 248, 200);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
