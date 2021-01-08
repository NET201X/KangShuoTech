using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace RecordManagement
{
    using CommonControl;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Data;
    using System.IO;
    using System.Threading;
    using KangShuoTech.Utilities.Common;
    using System.Configuration;

    public class HealthInfoForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private IContainer components;
        private CMoreChange fuqin;
        private List<CMoreChange> morechanges;
        private CMoreChange muqin;
        private List<ItemDictonaryModel<string>> pfss;
        private List<ItemDictonaryModel<string>> qcl;
        private List<ItemDictonaryModel<string>> rllx;
        private List<ItemDictonaryModel<string>> tolit;
        private CMoreChange xiongmei;
        private List<ItemDictonaryModel<string>> ys;
        private Panel panel1;
        private GroupBox groupBox46;
        private OtherIllnessUserControl uc_otherillness_shuxue;
        private OtherIllnessUserControl uc_otherillness_waishang;
        private OtherIllnessUserControl uc_otherillness_shoushu;
        private GroupBox groupBox2;
        private Label label4;
        private ComboBox cmbys;
        private Label label3;
        private ComboBox cmbqcl;
        private Label label2;
        private ComboBox cmbcs;
        private Label label1;
        private ComboBox cmbrllx;
        private Label label182;
        private ComboBox cmbCfpfss;
        private Label label209;
        private Label label204;
        private Label label195;
        private IllnessHisUserControl ucIllnessHis1;
        private TabControl PageBrotherDisease;
        private TabPage tabPage1;
        private TextBox tbFatherDisease;
        private CheckedListBox chjiazufuqin;
        private TabPage tabPage3;
        private TextBox tbMotherDisease;
        private CheckedListBox chjiazumuqin;
        private TabPage tabPage2;
        private TextBox tbBrotherDisease;
        private CheckedListBox chjiazuxiongmei;
        private TabPage tabPage4;
        private TextBox tbSonDisease;
        private CheckedListBox chjiazuzinv;
        private Label label210;
        private Label label212;
        private DateTimePicker dtSignDate;
        private Label label7;
        private Label label6;
        private Label label5;
        private CMoreChange zinv;
        private int HW_eOk = 0;
        private PictureBox picSign1_B;
        private PictureBox picSign1_J;
        private LinkLabel linkLabel1;      //success
        private TextBox txtDependent;
        private Label label8;
        private Panel panel2;
        private Label lblResult;
        private PictureBox pictureFinger;
        private Button btnFingerPrint;
        private PictureBox pictureBox1;
        Thread m_WorkerThread = null;
        bool m_bStop = false;
        FTRSCAN_IMAGE_SIZE m_ImageSize;
        byte[] m_pImage = null;
        private string FingerInfo = "";// 指纹信息
        byte[] m_pTemplate = null;
        byte m_byFingerPosition = 0;
        BioneFPAPILib.FPAPICtrlClass fp;
        string sb1, sb2;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/" : ConfigurationManager.AppSettings["SignPath"].ToString(); //签名保存路径
        private string FingerPath = ConfigurationManager.AppSettings["FingerPath"] == null ? @"Finger/" : ConfigurationManager.AppSettings["FingerPath"].ToString(); //指纹采集路径
        private string area = ConfigHelper.GetSetNode("area");
        private GroupBox groupBox1;
        private CheckBox checkBox20;
        private CheckBox checkBox19;
        private CheckBox checkBox18;
        private CheckBox checkBox17;
        private CheckBox checkBox16;
        private CheckBox checkBox15;
        private CheckBox checkBox14;
        private CheckBox checkBox13;
        private CheckBox checkBox12;
        private CheckBox checkBox11;
        private CheckBox checkBox10;
        private CheckBox checkBox9;
        private CheckBox checkBox8;
        private CheckBox checkBox7;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private CheckBox checkBox21;
        private CheckBox checkBox22;
        private CheckBox checkBox23;
        private CheckBox checkBox24;
        private CheckBox checkBox25;
        private CheckBox checkBox26;
        private List<CheckBox> ckzdgllx = new List<CheckBox>();
        

        public HealthInfoForm()
        {
          
            this.InitializeComponent();
            this.InitLifeEnv();
            if (area == "威海")
            {
                label7.Location = new Point(38, 798);
                dtSignDate.Location = new Point(143, 788);
                label5.Location = new Point(43, 850);
                txtDependent.Location = new Point(710, 788);
                label8.Location = new Point(584, 793);
                picSign1_B.Location = new Point(141, 838);
                linkLabel1.Location = new Point(398, 859);
                label6.Location = new System.Drawing.Point(584, 863);
                picSign1_J.Location = new System.Drawing.Point(713, 838);
            }
            else
            {
                groupBox1.Visible = false;
            }
            this.EveryThingIsOk = false;
            ckzdgllx = new List<CheckBox>();
            ckzdgllx.Add(checkBox1);
            ckzdgllx.Add(checkBox2);
            ckzdgllx.Add(checkBox3);
            ckzdgllx.Add(checkBox4);
            ckzdgllx.Add(checkBox5);
            ckzdgllx.Add(checkBox6);
            ckzdgllx.Add(checkBox7);
            ckzdgllx.Add(checkBox8);
            ckzdgllx.Add(checkBox9);
            ckzdgllx.Add(checkBox10);
            ckzdgllx.Add(checkBox11);
            ckzdgllx.Add(checkBox12);
            ckzdgllx.Add(checkBox13);
            ckzdgllx.Add(checkBox14);
            ckzdgllx.Add(checkBox15);
            ckzdgllx.Add(checkBox16);
            ckzdgllx.Add(checkBox17);
            ckzdgllx.Add(checkBox19);
            ckzdgllx.Add(checkBox18);
            ckzdgllx.Add(checkBox20);
            ckzdgllx.Add(checkBox21);
            ckzdgllx.Add(checkBox22);
            ckzdgllx.Add(checkBox23);
            ckzdgllx.Add(checkBox24);
            ckzdgllx.Add(checkBox25);
            ckzdgllx.Add(checkBox26);
        }

        private bool archive_illnessoper(RecordsIllnessHistoryInfoBLL oper, List<OtherDisease> others)
        {
            bool flag = true;
            if (others == null)
            {
                return false;
            }
            foreach (OtherDisease disease in others)
            {
                RecordsIllnessHistoryInfoModel source = disease.Source;
                source.RecordID = this.Model.RecordID;
                source.IDCardNo = this.Model.IDCardNo;
                if (source.RecordState == RecordsStateModel.AddToDB)
                {
                    if (oper.Add(source) <= 0)
                    {
                        flag = false;
                    }
                }
                else if (source.RecordState == RecordsStateModel.DeleteInDB)
                {
                    if (!oper.Delete(source.ID))
                    {
                        flag = false;
                    }
                }
                else if ((source.RecordState == RecordsStateModel.UpdateInDB) && !oper.Update(source))
                {
                    flag = false;
                }
            }
            return flag;
        }

        private bool archive_illnessoper(RecordsIllnessHistoryInfoBLL oper, List<RecordsIllnessHistoryInfoModel> items)
        {
            bool flag = true;
            if (items == null)
            {
                return false;
            }
            foreach (RecordsIllnessHistoryInfoModel recordsIllnessHistoryInfoModel in items)
            {
                recordsIllnessHistoryInfoModel.RecordID = this.Model.RecordID;
                recordsIllnessHistoryInfoModel.IDCardNo = this.Model.IDCardNo;
                if (recordsIllnessHistoryInfoModel.RecordState == RecordsStateModel.AddToDB)
                {
                    if (oper.Add(recordsIllnessHistoryInfoModel) <= 0)
                    {
                        flag = false;
                    }
                }
                else if (recordsIllnessHistoryInfoModel.RecordState == RecordsStateModel.DeleteInDB)
                {
                    if (!oper.Delete(recordsIllnessHistoryInfoModel.ID))
                    {
                        flag = false;
                    }
                }
                else if ((recordsIllnessHistoryInfoModel.RecordState == RecordsStateModel.UpdateInDB) && !oper.Update(recordsIllnessHistoryInfoModel))
                {
                    flag = false;
                }
            }
            return flag;
        }

        public ChildFormStatus CheckErrorInput()
        {
            bool errorInput = this.uc_otherillness_shoushu.ErrorInput;
            bool flag2 = this.uc_otherillness_waishang.ErrorInput;
            bool flag3 = this.uc_otherillness_shuxue.ErrorInput;
            bool flag4 = (((this.morechanges.Count<CMoreChange>(c => c.ErrorInput) > 0) || errorInput) || flag2) || flag3;
            if (flag4)
            {
                this.SaveDataInfo = "健康信息有误!";
            }
            if (flag4)
            {
                return ChildFormStatus.HasErrorInput;
            }
            return ChildFormStatus.NoErrorInput;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            if (m_WorkerThread != null) //关闭指纹设备
            {
                try
                {
                    m_WorkerThread.Abort();
                    m_WorkerThread.Join();
                }
                catch (Exception ex)
                {
                    Thread.ResetAbort();
                }
            }

            if (fp != null)//关闭指纹设备
            {
                fp.StopGetTemplate();
                fp.CloseDevice();
                fp.UnInitDevice();
            }
            base.Dispose(disposing);
        }

        private void HealthInfoForm_Load(object sender, EventArgs e)
        {
            this.uc_otherillness_shoushu.Model = this.Model;
            this.uc_otherillness_waishang.Model = this.Model;
            this.uc_otherillness_shuxue.Model = this.Model;
            this.uc_otherillness_shoushu.Init(this.Model.IDCardNo, "2");
            this.uc_otherillness_waishang.Init(this.Model.IDCardNo, "3");
            this.uc_otherillness_shuxue.Init(this.Model.IDCardNo, "4");
            this.uc_otherillness_shoushu.MaxBytesCount = 200;
            this.uc_otherillness_waishang.MaxBytesCount = 200;
            this.uc_otherillness_shuxue.MaxBytesCount = 200;
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
           
        }

        public void InitEveryThing()
        {
            this.SignModel = new RecordsSignatureBLL().GetModelByOutKey(0, "签字维护");
            if (this.SignModel == null) this.SignModel = new RecordsSignatureModel();
            this.SignModel.IDCardNo = "签字维护";
            this.SignModel.ID = 0;

            if (!Directory.Exists(SignPath))
            {
                Directory.CreateDirectory(SignPath);
            }
            if (!Directory.Exists(FingerPath))
            {
                Directory.CreateDirectory(FingerPath);
            }

            this.txtDependent.DataBindings.Add("Text", this.SignModel, "DependentSn", false, DataSourceUpdateMode.OnPropertyChanged);

            this.IllnessHistoryInfo = new RecordsIllnessHistoryInfoBLL().GetModelList(string.Format(" IDCardNo = '{0}' AND IllnessType = '{1}' ", this.Model.IDCardNo, 1));
            this.FamilyHistoryInfo = new RecordsFamilyHistoryInfoBLL().GetModel(this.Model.IDCardNo);
            this.LifeEnvironment = new RecordsEnvironmentBLL().GetModel(this.Model.IDCardNo);
           
            if (this.FamilyHistoryInfo == null)
            {
                RecordsFamilyHistoryInfoModel recordsFamilyHistoryInfoModel = new RecordsFamilyHistoryInfoModel
                {
                    RecordID = this.Model.RecordID,
                    IDCardNo = this.Model.IDCardNo
                };
                this.FamilyHistoryInfo = recordsFamilyHistoryInfoModel;
            }
            if (this.LifeEnvironment == null)
            {
                RecordsEnvironmentModel recordsEnvironmentModel = new RecordsEnvironmentModel
                {
                    RecordID = this.Model.IDCardNo,
                    IDCardNo = this.Model.IDCardNo
                };
                this.LifeEnvironment = recordsEnvironmentModel;
            }
            this.PresetValue();//默认项设置
            this.ucIllnessHis1.Source = this.IllnessHistoryInfo;
            this.ucIllnessHis1.ArchiveID = this.Model.RecordID;
            this.ucIllnessHis1.IDCard = this.Model.IDCardNo;
            this.ucIllnessHis1.baseinfo = this.Model;
          
            CMoreChange change = new CMoreChange
            {
                Name = "父亲",
                MoreChange = this.chjiazufuqin,
                Unusual = "无",
                Other = this.tbFatherDisease,
                MaxBytesCount = 200
            };
            this.fuqin = change;
            this.fuqin.TransInfo(this.FamilyHistoryInfo.FatherHistory, this.FamilyHistoryInfo.FatherHistoryOther);
            CMoreChange change2 = new CMoreChange
            {
                Name = "母亲",
                MoreChange = this.chjiazumuqin,
                Unusual = "无",
                Other = this.tbMotherDisease,
                MaxBytesCount = 200
            };
            this.muqin = change2;
            this.muqin.TransInfo(this.FamilyHistoryInfo.MotherHistory, this.FamilyHistoryInfo.MotherHistoryOther);
            CMoreChange change3 = new CMoreChange
            {
                Name = "兄弟姐妹",
                MoreChange = this.chjiazuxiongmei,
                Unusual = "无",
                Other = this.tbBrotherDisease,
                MaxBytesCount = 200
            };
            this.xiongmei = change3;
            this.xiongmei.TransInfo(this.FamilyHistoryInfo.BrotherSisterHistory, this.FamilyHistoryInfo.BrotherSisterHistoryOther);
            CMoreChange change4 = new CMoreChange
            {
                Name = "子女",
                MoreChange = this.chjiazuzinv,
                Unusual = "无",
                Other = this.tbSonDisease,
                MaxBytesCount = 200
            };
            this.zinv = change4;
            this.zinv.TransInfo(this.FamilyHistoryInfo.ChildrenHistory, this.FamilyHistoryInfo.ChildrenHistoryOther);
            if (this.LifeEnvironment == null)
            {
                RecordsEnvironmentModel archive_environment2 = new RecordsEnvironmentModel
                {
                    RecordID = this.Model.RecordID,
                    IDCardNo = this.Model.IDCardNo
                };
                this.LifeEnvironment = archive_environment2;
            }
            this.SimpleBinding(this.cmbCfpfss, this.LifeEnvironment, "BlowMeasure");
            this.SimpleBinding(this.cmbrllx, this.LifeEnvironment, "FuelType");
            this.SimpleBinding(this.cmbys, this.LifeEnvironment, "DrinkWater");
            this.SimpleBinding(this.cmbcs, this.LifeEnvironment, "Toilet");
            this.SimpleBinding(this.cmbqcl, this.LifeEnvironment, "LiveStockRail");
            this.morechanges = new List<CMoreChange> { this.fuqin, this.muqin, this.xiongmei, this.zinv };
            if (this.LifeEnvironment.SignDate.HasValue)
            {
                this.dtSignDate.Value = this.LifeEnvironment.SignDate.Value;
            }
            
            string strSign1_B = String.Format("{0}{1}_B.png", SignPath, this.Model.IDCardNo);
            string strSign1_J = String.Format("{0}{1}_J.png", SignPath, this.Model.IDCardNo);
            if (File.Exists(strSign1_B))
            {
                Image imgeb= Image.FromFile(strSign1_B);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picSign1_B.Image = bmp;
                picSign1_B.Show();
                imgeb.Dispose();
                this.linkLabel1.Enabled = true;
                picSign1_B.BackColor = Color.White;
            }

            if (File.Exists(strSign1_J))
            {
                Image imgej = Image.FromFile(strSign1_J);
                Image bmp = new System.Drawing.Bitmap(imgej);
                picSign1_J.Image = bmp;
                picSign1_J.Show();
                imgej.Dispose();
                this.linkLabel1.Enabled = true;
                picSign1_J.BackColor = Color.White;
            }
            string strFingerPath = string.Format("{0}{1}_Finger.png", FingerPath, this.Model.IDCardNo);

            if (File.Exists(strFingerPath))
            {
                Image imgFinger = Image.FromFile(strFingerPath);
                Image bmp = new System.Drawing.Bitmap(imgFinger);
                pictureFinger.Image = bmp;
                pictureFinger.Show();
                imgFinger.Dispose();
            }
            MustChoose();
            if (!string.IsNullOrEmpty(Model.PhysicalClass)) {
                string[] a = Model.PhysicalClass.Split(',');
                foreach (string b in a)
                {
                    foreach (CheckBox ck in ckzdgllx)
                    {
                        if (b == ck.Name.Replace("checkBox", ""))
                            ck.Checked = true;
                    }
                }
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

        private void PresetValue()
        {
            DataSet dsre = new DataSet();
            dsre = new RequireBLL().GetList("TabName = '个人档案' and Comment = '健康信息'  and IsSetValue='是'  ");
            DataTable dt = dsre.Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                switch (item["ChinName"].ToString())
                {
                    case "手术":
                        if (this.uc_otherillness_shoushu.illnesshistoryinfo == null || this.uc_otherillness_shoushu.illnesshistoryinfo.Count == 0)
                        {
                            this.uc_otherillness_shoushu.SetDefault(item["ItemValue"].ToString());
                        }
                        break;
                    case "外伤":
                        if (this.uc_otherillness_waishang.illnesshistoryinfo == null || this.uc_otherillness_waishang.illnesshistoryinfo.Count == 0)
                        {
                            this.uc_otherillness_waishang.SetDefault(item["ItemValue"].ToString());
                        }
                        break;
                    case "输血":
                        if (this.uc_otherillness_shuxue.illnesshistoryinfo == null || this.uc_otherillness_shuxue.illnesshistoryinfo.Count == 0)
                        {
                            this.uc_otherillness_shuxue.SetDefault(item["ItemValue"].ToString());
                        }
                        break;
                    case "疾病":
                        if (this.IllnessHistoryInfo == null || this.IllnessHistoryInfo.Count == 0)
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))  //已有设置的默认项内容
                            {

                                string[] reslist = item["ItemValue"].ToString().Split('&');
                                foreach (string st in reslist)
                                {
                                    if (!string.IsNullOrEmpty(st))
                                    {
                                        string[] strRow = st.Split(';');
                                        RecordsIllnessHistoryInfoModel hmodel = new RecordsIllnessHistoryInfoModel();
                                        if (strRow[0] == "无")
                                        {
                                            hmodel.IllnessName = "1";
                                        }
                                        else
                                        {
                                            hmodel.DiagnoseTime = Convert.ToDateTime(strRow[0].ToString());
                                            hmodel.IllnessName = strRow[1].ToString();
                                            hmodel.Therioma = strRow[2].ToString();
                                            hmodel.IllnessOther = strRow[3].ToString();
                                            hmodel.JobIllness = strRow[4].ToString();
                                            hmodel.RecordState = RecordsStateModel.AddToDB;


                                        }
                                        hmodel.IllnessType = "1";
                                        this.IllnessHistoryInfo.Add(hmodel);
                                    }
                                }
                            }
                        }
                        break;
                    case "家族史父亲":
                        if (string.IsNullOrEmpty(this.FamilyHistoryInfo.FatherHistory))
                        {
                            this.FamilyHistoryInfo.FatherHistory = item["ItemValue"].ToString();
                        }
                        break;
                    case "家族史母亲":
                        if (string.IsNullOrEmpty(this.FamilyHistoryInfo.MotherHistory))
                        {
                            this.FamilyHistoryInfo.MotherHistory = item["ItemValue"].ToString();
                        }
                        break;
                    case "家族史兄弟姐妹":
                        if (string.IsNullOrEmpty(this.FamilyHistoryInfo.BrotherSisterHistory))
                        {
                            this.FamilyHistoryInfo.BrotherSisterHistory = item["ItemValue"].ToString();
                        }
                        break;
                    case "家族史子女":
                        if (string.IsNullOrEmpty(this.FamilyHistoryInfo.ChildrenHistory))
                        {
                            this.FamilyHistoryInfo.ChildrenHistory = item["ItemValue"].ToString();
                        }
                        break;
                    case "厨房排风设施":
                        if (string.IsNullOrEmpty(this.LifeEnvironment.BlowMeasure))
                        {
                            this.LifeEnvironment.BlowMeasure = item["ItemValue"].ToString();
                        }
                        break;
                    case "燃料类型":
                        if (string.IsNullOrEmpty(this.LifeEnvironment.FuelType))
                        {
                            this.LifeEnvironment.FuelType = item["ItemValue"].ToString();
                        }
                        break;
                    case "饮水":
                        if (string.IsNullOrEmpty(this.LifeEnvironment.DrinkWater))
                        {
                            this.LifeEnvironment.DrinkWater = item["ItemValue"].ToString();
                        }
                        break;
                    case "厕所":
                        if (string.IsNullOrEmpty(this.LifeEnvironment.Toilet))
                        {
                            this.LifeEnvironment.Toilet = item["ItemValue"].ToString();
                        }
                        break;
                    case "禽兽栏":
                        if (string.IsNullOrEmpty(this.LifeEnvironment.LiveStockRail))
                        {
                            this.LifeEnvironment.LiveStockRail = item["ItemValue"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void MustChoose()
        {
            DataSet dsrequire = new DataSet();
            dsrequire = new RequireBLL().GetList("TabName = '个人档案' and Comment = '健康信息' ");
            RecordsEnvironmentModel LifeEnvironments = new RecordsEnvironmentBLL().GetModel(Model.IDCardNo.ToString());
            //家族史
            RecordsFamilyHistoryInfoModel FamilyHistoryInfos = new RecordsFamilyHistoryInfoBLL().GetModel(this.Model.IDCardNo);
            //疾病史
            List<RecordsIllnessHistoryInfoModel> IllnessHistoryInfoTem = new RecordsIllnessHistoryInfoBLL().GetModelList(string.Format(" IDCardNo = '{0}'", this.Model.IDCardNo));

            string strSign1_B = String.Format("{0}{1}_B.png", SignPath, this.Model.IDCardNo);
            string strSign1_J = String.Format("{0}{1}_J.png", SignPath, this.Model.IDCardNo);
            if (LifeEnvironments == null) LifeEnvironments = new RecordsEnvironmentModel();
            this.label210.Text = "家族史";
            this.label210.ForeColor = System.Drawing.Color.Black;
            DataTable dt = dsrequire.Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                if (item["Isrequired"].ToString() == "1")
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "疾病":
                            if (IllnessHistoryInfoTem == null || IllnessHistoryInfoTem.Count == 0)
                            {
                                this.label212.Text = "*疾  病:";
                                this.label212.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                if (!IllnessHistoryInfoTem.Exists(c => c.IllnessType.Equals("1")))
                                {
                                    this.label212.Text = "*疾  病:";
                                    this.label212.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label212.Text = "疾  病:";
                                    this.label212.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;
                        case "手术":
                            if (IllnessHistoryInfoTem == null || IllnessHistoryInfoTem.Count == 0)
                            {
                                this.label195.Text = "*手 术:";
                                this.label195.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                if (!IllnessHistoryInfoTem.Exists(c => c.IllnessType.Equals("2")))
                                {
                                    this.label195.Text = "*手 术:";
                                    this.label195.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label195.Text = "手 术:";
                                    this.label195.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;
                        case "外伤":
                            if (IllnessHistoryInfoTem == null || IllnessHistoryInfoTem.Count == 0)
                            {
                                this.label204.Text = "*外 伤:";
                                this.label204.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                if (!IllnessHistoryInfoTem.Exists(c => c.IllnessType.Equals("3")))
                                {
                                    this.label204.Text = "*外 伤:";
                                    this.label204.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label204.Text = "外 伤:";
                                    this.label204.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;
                        case "输血":
                            if (IllnessHistoryInfoTem == null || IllnessHistoryInfoTem.Count == 0)
                            {
                                this.label209.Text = "*输 血:";
                                this.label209.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                if (!IllnessHistoryInfoTem.Exists(c => c.IllnessType.Equals("3")))
                                {
                                    this.label209.Text = "*输 血:";
                                    this.label209.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label209.Text = "输 血:";
                                    this.label209.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;
                        case "家族史父亲":
                            if (FamilyHistoryInfos == null || string.IsNullOrEmpty(FamilyHistoryInfos.FatherHistory))
                            {
                                this.label210.Text = "*家族史";
                                this.label210.ForeColor = System.Drawing.Color.Red;
                            }

                            break;
                        case "家族史母亲":
                            if (FamilyHistoryInfos == null || string.IsNullOrEmpty(FamilyHistoryInfos.MotherHistory))
                            {
                                this.label210.Text = "*家族史";
                                this.label210.ForeColor = System.Drawing.Color.Red;
                            }
                            break;
                        case "家族史兄弟姐妹":
                            if (FamilyHistoryInfos == null || string.IsNullOrEmpty(FamilyHistoryInfos.BrotherSisterHistory))
                            {
                                this.label210.Text = "*家族史";
                                this.label210.ForeColor = System.Drawing.Color.Red;
                            }
                            break;
                        case "家族史子女":
                            if (FamilyHistoryInfos == null || string.IsNullOrEmpty(FamilyHistoryInfos.ChildrenHistory))
                            {
                                this.label210.Text = "*家族史";
                                this.label210.ForeColor = System.Drawing.Color.Red;
                            }

                            break;
                        case "厨房排风设施":
                            if (string.IsNullOrEmpty(Convert.ToString(LifeEnvironments.BlowMeasure)))
                            {
                                this.label182.Text = "*厨房排风设施:";
                                this.label182.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label182.Text = "厨房排风设施:";
                                this.label182.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "燃料类型":
                            if (string.IsNullOrEmpty(Convert.ToString(LifeEnvironments.FuelType)))
                            {
                                this.label1.Text = "*燃料类型:";
                                this.label1.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label1.Text = "燃料类型:";
                                this.label1.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "饮水":
                            if (string.IsNullOrEmpty(Convert.ToString(LifeEnvironments.DrinkWater)))
                            {
                                this.label4.Text = "*饮水:";
                                this.label4.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label4.Text = "饮水:";
                                this.label4.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "厕所":
                            if (string.IsNullOrEmpty(Convert.ToString(LifeEnvironments.Toilet)))
                            {
                                this.label2.Text = "*厕所:";
                                this.label2.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label2.Text = "厕所:";
                                this.label2.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "禽兽栏":
                            if (string.IsNullOrEmpty(Convert.ToString(LifeEnvironments.LiveStockRail)))
                            {
                                this.label3.Text = "*禽畜栏:";
                                this.label3.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label3.Text = "禽畜栏:";
                                this.label3.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "本人签字":
                            if (File.Exists(strSign1_B))
                            {
                                this.label5.Text = "本人签字";
                                this.label5.ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                this.label5.Text = "*本人签字";
                                this.label5.ForeColor = System.Drawing.Color.Red;
                            }
                            break;
                        case "家属签字":
                            if (File.Exists(strSign1_J))
                            {
                                this.label6.Text = "家属签字";
                                this.label6.ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                this.label6.Text = "*家属签字";
                                this.label6.ForeColor = System.Drawing.Color.Red;
                            }
                            break;
                        case "签字日期":
                            if (string.IsNullOrEmpty(Convert.ToString(LifeEnvironments.SignDate)))
                            {
                                this.label7.Text = "*签字日期";
                                this.label7.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label7.Text = "签字日期";
                                this.label7.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        default: break;
                    }
                }
            }

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HealthInfoForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox46 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblResult = new System.Windows.Forms.Label();
            this.pictureFinger = new System.Windows.Forms.PictureBox();
            this.btnFingerPrint = new System.Windows.Forms.Button();
            this.txtDependent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.picSign1_J = new System.Windows.Forms.PictureBox();
            this.picSign1_B = new System.Windows.Forms.PictureBox();
            this.dtSignDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uc_otherillness_shuxue = new OtherIllnessUserControl();
            this.uc_otherillness_waishang = new OtherIllnessUserControl();
            this.uc_otherillness_shoushu = new OtherIllnessUserControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbys = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbqcl = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbcs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbrllx = new System.Windows.Forms.ComboBox();
            this.label182 = new System.Windows.Forms.Label();
            this.cmbCfpfss = new System.Windows.Forms.ComboBox();
            this.label209 = new System.Windows.Forms.Label();
            this.label204 = new System.Windows.Forms.Label();
            this.label195 = new System.Windows.Forms.Label();
            this.ucIllnessHis1 = new KangShuoTech.Utilities.CommonControl.IllnessHisUserControl();
            this.PageBrotherDisease = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbFatherDisease = new System.Windows.Forms.TextBox();
            this.chjiazufuqin = new System.Windows.Forms.CheckedListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbMotherDisease = new System.Windows.Forms.TextBox();
            this.chjiazumuqin = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbBrotherDisease = new System.Windows.Forms.TextBox();
            this.chjiazuxiongmei = new System.Windows.Forms.CheckedListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbSonDisease = new System.Windows.Forms.TextBox();
            this.chjiazuzinv = new System.Windows.Forms.CheckedListBox();
            this.label210 = new System.Windows.Forms.Label();
            this.label212 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.checkBox21 = new System.Windows.Forms.CheckBox();
            this.checkBox22 = new System.Windows.Forms.CheckBox();
            this.checkBox23 = new System.Windows.Forms.CheckBox();
            this.checkBox24 = new System.Windows.Forms.CheckBox();
            this.checkBox25 = new System.Windows.Forms.CheckBox();
            this.checkBox26 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox46.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFinger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSign1_J)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSign1_B)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.PageBrotherDisease.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox46);
            this.panel1.Location = new System.Drawing.Point(60, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1437, 670);
            this.panel1.TabIndex = 0;
            // 
            // groupBox46
            // 
            this.groupBox46.BackColor = System.Drawing.Color.Transparent;
            this.groupBox46.Controls.Add(this.groupBox1);
            this.groupBox46.Controls.Add(this.panel2);
            this.groupBox46.Controls.Add(this.txtDependent);
            this.groupBox46.Controls.Add(this.label8);
            this.groupBox46.Controls.Add(this.linkLabel1);
            this.groupBox46.Controls.Add(this.picSign1_J);
            this.groupBox46.Controls.Add(this.picSign1_B);
            this.groupBox46.Controls.Add(this.dtSignDate);
            this.groupBox46.Controls.Add(this.label7);
            this.groupBox46.Controls.Add(this.label6);
            this.groupBox46.Controls.Add(this.label5);
            this.groupBox46.Controls.Add(this.uc_otherillness_shuxue);
            this.groupBox46.Controls.Add(this.uc_otherillness_waishang);
            this.groupBox46.Controls.Add(this.uc_otherillness_shoushu);
            this.groupBox46.Controls.Add(this.groupBox2);
            this.groupBox46.Controls.Add(this.label209);
            this.groupBox46.Controls.Add(this.label204);
            this.groupBox46.Controls.Add(this.label195);
            this.groupBox46.Controls.Add(this.ucIllnessHis1);
            this.groupBox46.Controls.Add(this.PageBrotherDisease);
            this.groupBox46.Controls.Add(this.label210);
            this.groupBox46.Controls.Add(this.label212);
            this.groupBox46.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox46.Location = new System.Drawing.Point(10, 3);
            this.groupBox46.Name = "groupBox46";
            this.groupBox46.Size = new System.Drawing.Size(1368, 1000);
            this.groupBox46.TabIndex = 0;
            this.groupBox46.TabStop = false;
            this.groupBox46.Text = "个人信息";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblResult);
            this.panel2.Controls.Add(this.pictureFinger);
            this.panel2.Controls.Add(this.btnFingerPrint);
            this.panel2.Location = new System.Drawing.Point(1219, 525);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(139, 231);
            this.panel2.TabIndex = 190;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResult.Location = new System.Drawing.Point(26, 3);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(80, 18);
            this.lblResult.TabIndex = 188;
            this.lblResult.Text = "指纹采集";
            // 
            // pictureFinger
            // 
            this.pictureFinger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureFinger.Location = new System.Drawing.Point(9, 30);
            this.pictureFinger.Name = "pictureFinger";
            this.pictureFinger.Size = new System.Drawing.Size(118, 144);
            this.pictureFinger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureFinger.TabIndex = 186;
            this.pictureFinger.TabStop = false;
            // 
            // btnFingerPrint
            // 
            this.btnFingerPrint.Location = new System.Drawing.Point(21, 181);
            this.btnFingerPrint.Name = "btnFingerPrint";
            this.btnFingerPrint.Size = new System.Drawing.Size(102, 36);
            this.btnFingerPrint.TabIndex = 187;
            this.btnFingerPrint.Text = "开始采集";
            this.btnFingerPrint.UseVisualStyleBackColor = true;
            this.btnFingerPrint.Click += new System.EventHandler(this.btnFingerPrint_Click);
            // 
            // txtDependent
            // 
            this.txtDependent.Location = new System.Drawing.Point(710, 638);
            this.txtDependent.Name = "txtDependent";
            this.txtDependent.Size = new System.Drawing.Size(247, 30);
            this.txtDependent.TabIndex = 156;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(584, 643);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 155;
            this.label8.Text = "家属姓名";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 15F);
            this.linkLabel1.Location = new System.Drawing.Point(398, 709);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(89, 20);
            this.linkLabel1.TabIndex = 146;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "重置签字";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);

            // 
            // picSign1_J
            // 
            this.picSign1_J.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSign1_J.Location = new System.Drawing.Point(713, 688);
            this.picSign1_J.Name = "picSign1_J";
            this.picSign1_J.Size = new System.Drawing.Size(236, 70);
            this.picSign1_J.TabIndex = 143;
            this.picSign1_J.SizeMode = PictureBoxSizeMode.Zoom;
            this.picSign1_J.TabStop = false;
            this.picSign1_J.Visible = true;
            this.picSign1_J.Click += new System.EventHandler(this.picSign1_J_Click);
            // 
            // picSign1_B
            // 
            this.picSign1_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSign1_B.Location = new System.Drawing.Point(141, 687);
            this.picSign1_B.Name = "picSign1_B";
            this.picSign1_B.Size = new System.Drawing.Size(236, 70);
            this.picSign1_B.TabIndex = 142;
            this.picSign1_B.TabStop = false;
            this.picSign1_B.Visible = true;
            this.picSign1_B.SizeMode = PictureBoxSizeMode.Zoom;
            this.picSign1_B.Click += new System.EventHandler(this.picSign1_B_Click);
            // 
            // dtSignDate
            // 
            this.dtSignDate.Location = new System.Drawing.Point(143, 638);
            this.dtSignDate.Name = "dtSignDate";
            this.dtSignDate.Size = new System.Drawing.Size(200, 30);
            this.dtSignDate.TabIndex = 139;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 648);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 138;
            this.label7.Text = "签字日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(584, 713);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 137;
            this.label6.Text = "家属签字";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 700);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 136;
            this.label5.Text = "本人签字";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox21);
            this.groupBox1.Controls.Add(this.checkBox22);
            this.groupBox1.Controls.Add(this.checkBox23);
            this.groupBox1.Controls.Add(this.checkBox24);
            this.groupBox1.Controls.Add(this.checkBox25);
            this.groupBox1.Controls.Add(this.checkBox26);
            this.groupBox1.Controls.Add(this.checkBox20);
            this.groupBox1.Controls.Add(this.checkBox19);
            this.groupBox1.Controls.Add(this.checkBox18);
            this.groupBox1.Controls.Add(this.checkBox17);
            this.groupBox1.Controls.Add(this.checkBox16);
            this.groupBox1.Controls.Add(this.checkBox15);
            this.groupBox1.Controls.Add(this.checkBox14);
            this.groupBox1.Controls.Add(this.checkBox13);
            this.groupBox1.Controls.Add(this.checkBox12);
            this.groupBox1.Controls.Add(this.checkBox11);
            this.groupBox1.Controls.Add(this.checkBox10);
            this.groupBox1.Controls.Add(this.checkBox9);
            this.groupBox1.Controls.Add(this.checkBox8);
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(14, 638);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1196, 136);
            this.groupBox1.TabIndex = 192;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "重点管理类型";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "高血压";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(116, 35);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(88, 24);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "糖尿病";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(220, 35);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(88, 24);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "脑卒中";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(324, 35);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(88, 24);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "冠心病";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(537, 37);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(88, 24);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "孕产妇";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(641, 37);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(88, 24);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "老年人";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(745, 37);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(148, 24);
            this.checkBox7.TabIndex = 6;
            this.checkBox7.Text = "重性精神疾病";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(909, 37);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(88, 24);
            this.checkBox8.TabIndex = 7;
            this.checkBox8.Text = "新生儿";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(12, 68);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(68, 24);
            this.checkBox9.TabIndex = 8;
            this.checkBox9.Text = "满月";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(93, 68);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(58, 24);
            this.checkBox10.TabIndex = 9;
            this.checkBox10.Text = "3月";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(164, 68);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(58, 24);
            this.checkBox11.TabIndex = 10;
            this.checkBox11.Text = "6月";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(235, 68);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(58, 24);
            this.checkBox12.TabIndex = 11;
            this.checkBox12.Text = "8月";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(306, 68);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(68, 24);
            this.checkBox13.TabIndex = 12;
            this.checkBox13.Text = "12月";
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(387, 68);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(68, 24);
            this.checkBox14.TabIndex = 13;
            this.checkBox14.Text = "18月";
            this.checkBox14.UseVisualStyleBackColor = true;
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(468, 68);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(68, 24);
            this.checkBox15.TabIndex = 14;
            this.checkBox15.Text = "24月";
            this.checkBox15.UseVisualStyleBackColor = true;
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(549, 68);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(68, 24);
            this.checkBox16.TabIndex = 15;
            this.checkBox16.Text = "30月";
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.Location = new System.Drawing.Point(630, 68);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(58, 24);
            this.checkBox17.TabIndex = 16;
            this.checkBox17.Text = "3岁";
            this.checkBox17.UseVisualStyleBackColor = true;
            // 
            // checkBox18
            // 
            this.checkBox18.AutoSize = true;
            this.checkBox18.Location = new System.Drawing.Point(701, 68);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(58, 24);
            this.checkBox18.TabIndex = 17;
            this.checkBox18.Text = "4岁";
            this.checkBox18.UseVisualStyleBackColor = true;
            // 
            // checkBox19
            // 
            this.checkBox19.AutoSize = true;
            this.checkBox19.Location = new System.Drawing.Point(843, 68);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(58, 24);
            this.checkBox19.TabIndex = 18;
            this.checkBox19.Text = "6岁";
            this.checkBox19.UseVisualStyleBackColor = true;
            // 
            // checkBox20
            // 
            this.checkBox20.AutoSize = true;
            this.checkBox20.Location = new System.Drawing.Point(772, 68);
            this.checkBox20.Name = "checkBox20";
            this.checkBox20.Size = new System.Drawing.Size(58, 24);
            this.checkBox20.TabIndex = 19;
            this.checkBox20.Text = "5岁";
            this.checkBox20.UseVisualStyleBackColor = true;
            // 
            // checkBox21
            // 
            this.checkBox21.AutoSize = true;
            this.checkBox21.Location = new System.Drawing.Point(681, 98);
            this.checkBox21.Name = "checkBox21";
            this.checkBox21.Size = new System.Drawing.Size(128, 24);
            this.checkBox21.TabIndex = 25;
            this.checkBox21.Text = "高危糖尿病";
            this.checkBox21.UseVisualStyleBackColor = true;
            // 
            // checkBox22
            // 
            this.checkBox22.AutoSize = true;
            this.checkBox22.Location = new System.Drawing.Point(537, 98);
            this.checkBox22.Name = "checkBox22";
            this.checkBox22.Size = new System.Drawing.Size(128, 24);
            this.checkBox22.TabIndex = 24;
            this.checkBox22.Text = "高危高血压";
            this.checkBox22.UseVisualStyleBackColor = true;
            // 
            // checkBox23
            // 
            this.checkBox23.AutoSize = true;
            this.checkBox23.Location = new System.Drawing.Point(375, 98);
            this.checkBox23.Name = "checkBox23";
            this.checkBox23.Size = new System.Drawing.Size(108, 24);
            this.checkBox23.TabIndex = 23;
            this.checkBox23.Text = "视力残疾";
            this.checkBox23.UseVisualStyleBackColor = true;
            // 
            // checkBox24
            // 
            this.checkBox24.AutoSize = true;
            this.checkBox24.Location = new System.Drawing.Point(267, 98);
            this.checkBox24.Name = "checkBox24";
            this.checkBox24.Size = new System.Drawing.Size(108, 24);
            this.checkBox24.TabIndex = 22;
            this.checkBox24.Text = "智力残疾";
            this.checkBox24.UseVisualStyleBackColor = true;
            // 
            // checkBox25
            // 
            this.checkBox25.AutoSize = true;
            this.checkBox25.Location = new System.Drawing.Point(159, 98);
            this.checkBox25.Name = "checkBox25";
            this.checkBox25.Size = new System.Drawing.Size(108, 24);
            this.checkBox25.TabIndex = 21;
            this.checkBox25.Text = "肢体残疾";
            this.checkBox25.UseVisualStyleBackColor = true;
            // 
            // checkBox26
            // 
            this.checkBox26.AutoSize = true;
            this.checkBox26.Location = new System.Drawing.Point(11, 98);
            this.checkBox26.Name = "checkBox26";
            this.checkBox26.Size = new System.Drawing.Size(148, 24);
            this.checkBox26.TabIndex = 20;
            this.checkBox26.Text = "听力语言残疾";
            this.checkBox26.UseVisualStyleBackColor = true;
            // 
            // uc_otherillness_shuxue
            // 
            this.uc_otherillness_shuxue.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uc_otherillness_shuxue.Location = new System.Drawing.Point(99, 111);
            this.uc_otherillness_shuxue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uc_otherillness_shuxue.MaxBytesCount = 0;
            this.uc_otherillness_shuxue.Model = null;
            this.uc_otherillness_shuxue.Name = "uc_otherillness_shuxue";
            this.uc_otherillness_shuxue.Name1 = "原因1:";
            this.uc_otherillness_shuxue.Name2 = "原因2:";
            this.uc_otherillness_shuxue.Size = new System.Drawing.Size(1300, 36);
            this.uc_otherillness_shuxue.TabIndex = 2;
            // 
            // uc_otherillness_waishang
            // 
            this.uc_otherillness_waishang.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uc_otherillness_waishang.Location = new System.Drawing.Point(99, 72);
            this.uc_otherillness_waishang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uc_otherillness_waishang.MaxBytesCount = 0;
            this.uc_otherillness_waishang.Model = null;
            this.uc_otherillness_waishang.Name = "uc_otherillness_waishang";
            this.uc_otherillness_waishang.Name1 = "名称1:";
            this.uc_otherillness_waishang.Name2 = "名称2:";
            this.uc_otherillness_waishang.Size = new System.Drawing.Size(1300, 40);
            this.uc_otherillness_waishang.TabIndex = 1;
            // 
            // uc_otherillness_shoushu
            // 
            this.uc_otherillness_shoushu.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uc_otherillness_shoushu.Location = new System.Drawing.Point(99, 33);
            this.uc_otherillness_shoushu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uc_otherillness_shoushu.MaxBytesCount = 0;
            this.uc_otherillness_shoushu.Model = null;
            this.uc_otherillness_shoushu.Name = "uc_otherillness_shoushu";
            this.uc_otherillness_shoushu.Name1 = "名称1:";
            this.uc_otherillness_shoushu.Name2 = "名称2:";
            this.uc_otherillness_shoushu.Size = new System.Drawing.Size(1300, 41);
            this.uc_otherillness_shoushu.TabIndex = 0;
            this.uc_otherillness_shoushu.Load += new System.EventHandler(this.uc_otherillness_shoushu_Load);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbys);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbqcl);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbcs);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbrllx);
            this.groupBox2.Controls.Add(this.label182);
            this.groupBox2.Controls.Add(this.cmbCfpfss);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(13, 513);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1197, 119);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "生活环境*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(783, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "饮水:";
            // 
            // cmbys
            // 
            this.cmbys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbys.FormattingEnabled = true;
            this.cmbys.Location = new System.Drawing.Point(853, 26);
            this.cmbys.Name = "cmbys";
            this.cmbys.Size = new System.Drawing.Size(196, 28);
            this.cmbys.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(433, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "禽畜栏:";
            // 
            // cmbqcl
            // 
            this.cmbqcl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbqcl.FormattingEnabled = true;
            this.cmbqcl.Location = new System.Drawing.Point(527, 64);
            this.cmbqcl.Name = "cmbqcl";
            this.cmbqcl.Size = new System.Drawing.Size(196, 28);
            this.cmbqcl.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(89, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "厕所:";
            // 
            // cmbcs
            // 
            this.cmbcs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcs.FormattingEnabled = true;
            this.cmbcs.Location = new System.Drawing.Point(164, 65);
            this.cmbcs.Name = "cmbcs";
            this.cmbcs.Size = new System.Drawing.Size(196, 28);
            this.cmbcs.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(416, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "燃料类型:";
            // 
            // cmbrllx
            // 
            this.cmbrllx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbrllx.FormattingEnabled = true;
            this.cmbrllx.Location = new System.Drawing.Point(527, 24);
            this.cmbrllx.Name = "cmbrllx";
            this.cmbrllx.Size = new System.Drawing.Size(196, 28);
            this.cmbrllx.TabIndex = 1;
            // 
            // label182
            // 
            this.label182.AutoSize = true;
            this.label182.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label182.Location = new System.Drawing.Point(9, 29);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(139, 20);
            this.label182.TabIndex = 19;
            this.label182.Text = "厨房排风设施:";
            // 
            // cmbCfpfss
            // 
            this.cmbCfpfss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCfpfss.FormattingEnabled = true;
            this.cmbCfpfss.Location = new System.Drawing.Point(164, 25);
            this.cmbCfpfss.Name = "cmbCfpfss";
            this.cmbCfpfss.Size = new System.Drawing.Size(196, 28);
            this.cmbCfpfss.TabIndex = 0;
            // 
            // label209
            // 
            this.label209.AutoSize = true;
            this.label209.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label209.Location = new System.Drawing.Point(10, 116);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(79, 20);
            this.label209.TabIndex = 135;
            this.label209.Text = "输　血:";
            // 
            // label204
            // 
            this.label204.AutoSize = true;
            this.label204.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label204.Location = new System.Drawing.Point(10, 78);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(79, 20);
            this.label204.TabIndex = 128;
            this.label204.Text = "外　伤:";
            // 
            // label195
            // 
            this.label195.AutoSize = true;
            this.label195.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label195.Location = new System.Drawing.Point(10, 41);
            this.label195.Name = "label195";
            this.label195.Size = new System.Drawing.Size(79, 20);
            this.label195.TabIndex = 121;
            this.label195.Text = "手　术:";
            // 
            // ucIllnessHis1
            // 
            this.ucIllnessHis1.ArchiveID = null;
            this.ucIllnessHis1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucIllnessHis1.Font = new System.Drawing.Font("宋体", 15F);
            this.ucIllnessHis1.IDCard = null;
            this.ucIllnessHis1.Location = new System.Drawing.Point(109, 154);
            this.ucIllnessHis1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucIllnessHis1.Name = "ucIllnessHis1";
            this.ucIllnessHis1.Size = new System.Drawing.Size(1182, 208);
            this.ucIllnessHis1.TabIndex = 3;
            // 
            // PageBrotherDisease
            // 
            this.PageBrotherDisease.Controls.Add(this.tabPage1);
            this.PageBrotherDisease.Controls.Add(this.tabPage3);
            this.PageBrotherDisease.Controls.Add(this.tabPage2);
            this.PageBrotherDisease.Controls.Add(this.tabPage4);
            this.PageBrotherDisease.Location = new System.Drawing.Point(118, 370);
            this.PageBrotherDisease.Name = "PageBrotherDisease";
            this.PageBrotherDisease.SelectedIndex = 0;
            this.PageBrotherDisease.Size = new System.Drawing.Size(1244, 137);
            this.PageBrotherDisease.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbFatherDisease);
            this.tabPage1.Controls.Add(this.chjiazufuqin);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1236, 103);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "父亲";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbFatherDisease
            // 
            this.tbFatherDisease.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFatherDisease.Location = new System.Drawing.Point(429, 55);
            this.tbFatherDisease.MaxLength = 20;
            this.tbFatherDisease.Name = "tbFatherDisease";
            this.tbFatherDisease.ReadOnly = true;
            this.tbFatherDisease.Size = new System.Drawing.Size(263, 30);
            this.tbFatherDisease.TabIndex = 1;
            // 
            // chjiazufuqin
            // 
            this.chjiazufuqin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chjiazufuqin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chjiazufuqin.CheckOnClick = true;
            this.chjiazufuqin.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chjiazufuqin.FormattingEnabled = true;
            this.chjiazufuqin.Items.AddRange(new object[] {
            "无",
            "高血压",
            "糖尿病",
            "冠心病",
            "慢性阻塞性肺疾病",
            "恶性肿瘤",
            "脑卒中",
            "重性精神疾病",
            "结核病",
            "肝炎",
            "先天畸形",
            "其他"});
            this.chjiazufuqin.Location = new System.Drawing.Point(8, 9);
            this.chjiazufuqin.MultiColumn = true;
            this.chjiazufuqin.Name = "chjiazufuqin";
            this.chjiazufuqin.Size = new System.Drawing.Size(1080, 75);
            this.chjiazufuqin.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbMotherDisease);
            this.tabPage3.Controls.Add(this.chjiazumuqin);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1236, 103);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "母亲";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbMotherDisease
            // 
            this.tbMotherDisease.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMotherDisease.Location = new System.Drawing.Point(429, 47);
            this.tbMotherDisease.MaxLength = 20;
            this.tbMotherDisease.Name = "tbMotherDisease";
            this.tbMotherDisease.ReadOnly = true;
            this.tbMotherDisease.Size = new System.Drawing.Size(263, 30);
            this.tbMotherDisease.TabIndex = 32;
            // 
            // chjiazumuqin
            // 
            this.chjiazumuqin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chjiazumuqin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chjiazumuqin.CheckOnClick = true;
            this.chjiazumuqin.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chjiazumuqin.FormattingEnabled = true;
            this.chjiazumuqin.Items.AddRange(new object[] {
            "无",
            "高血压",
            "糖尿病",
            "冠心病",
            "慢性阻塞性肺疾病",
            "恶性肿瘤",
            "脑卒中",
            "重性精神疾病",
            "结核病",
            "肝炎",
            "先天畸形",
            "其他"});
            this.chjiazumuqin.Location = new System.Drawing.Point(3, 3);
            this.chjiazumuqin.MultiColumn = true;
            this.chjiazumuqin.Name = "chjiazumuqin";
            this.chjiazumuqin.Size = new System.Drawing.Size(1080, 75);
            this.chjiazumuqin.TabIndex = 31;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbBrotherDisease);
            this.tabPage2.Controls.Add(this.chjiazuxiongmei);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1236, 103);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "兄弟姐妹";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbBrotherDisease
            // 
            this.tbBrotherDisease.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBrotherDisease.Location = new System.Drawing.Point(429, 47);
            this.tbBrotherDisease.MaxLength = 20;
            this.tbBrotherDisease.Name = "tbBrotherDisease";
            this.tbBrotherDisease.ReadOnly = true;
            this.tbBrotherDisease.Size = new System.Drawing.Size(264, 30);
            this.tbBrotherDisease.TabIndex = 32;
            // 
            // chjiazuxiongmei
            // 
            this.chjiazuxiongmei.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chjiazuxiongmei.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chjiazuxiongmei.CheckOnClick = true;
            this.chjiazuxiongmei.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chjiazuxiongmei.FormattingEnabled = true;
            this.chjiazuxiongmei.Items.AddRange(new object[] {
            "无",
            "高血压",
            "糖尿病",
            "冠心病",
            "慢性阻塞性肺疾病",
            "恶性肿瘤",
            "脑卒中",
            "重性精神疾病",
            "结核病",
            "肝炎",
            "先天畸形",
            "其他"});
            this.chjiazuxiongmei.Location = new System.Drawing.Point(3, 3);
            this.chjiazuxiongmei.MultiColumn = true;
            this.chjiazuxiongmei.Name = "chjiazuxiongmei";
            this.chjiazuxiongmei.Size = new System.Drawing.Size(1080, 75);
            this.chjiazuxiongmei.TabIndex = 32;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbSonDisease);
            this.tabPage4.Controls.Add(this.chjiazuzinv);
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1236, 103);
            this.tabPage4.TabIndex = 5;
            this.tabPage4.Text = "子女";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tbSonDisease
            // 
            this.tbSonDisease.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSonDisease.Location = new System.Drawing.Point(427, 47);
            this.tbSonDisease.MaxLength = 20;
            this.tbSonDisease.Name = "tbSonDisease";
            this.tbSonDisease.ReadOnly = true;
            this.tbSonDisease.Size = new System.Drawing.Size(264, 30);
            this.tbSonDisease.TabIndex = 33;
            // 
            // chjiazuzinv
            // 
            this.chjiazuzinv.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chjiazuzinv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chjiazuzinv.CheckOnClick = true;
            this.chjiazuzinv.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chjiazuzinv.FormattingEnabled = true;
            this.chjiazuzinv.Items.AddRange(new object[] {
            "无",
            "高血压",
            "糖尿病",
            "冠心病",
            "慢性阻塞性肺疾病",
            "恶性肿瘤",
            "脑卒中",
            "重性精神疾病",
            "结核病",
            "肝炎",
            "先天畸形",
            "其他"});
            this.chjiazuzinv.Location = new System.Drawing.Point(3, 3);
            this.chjiazuzinv.MultiColumn = true;
            this.chjiazuzinv.Name = "chjiazuzinv";
            this.chjiazuzinv.Size = new System.Drawing.Size(1080, 75);
            this.chjiazuzinv.TabIndex = 32;
            // 
            // label210
            // 
            this.label210.AutoSize = true;
            this.label210.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label210.Location = new System.Drawing.Point(10, 377);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(99, 20);
            this.label210.TabIndex = 29;
            this.label210.Text = "家 族 史:";
            // 
            // label212
            // 
            this.label212.AutoSize = true;
            this.label212.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label212.Location = new System.Drawing.Point(10, 161);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(79, 20);
            this.label212.TabIndex = 18;
            this.label212.Text = "疾  病:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(9, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 186;
            this.pictureBox1.TabStop = false;
            // 
            // HealthInfoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1460, 680);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "HealthInfoForm";
            this.Text = "HealthInfoForm";
            this.Load += new System.EventHandler(this.HealthInfoForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox46.ResumeLayout(false);
            this.groupBox46.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFinger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSign1_J)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSign1_B)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.PageBrotherDisease.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void InitLifeEnv()
        {
            this.pfss = new List<ItemDictonaryModel<string>>();
            this.pfss.Add(new ItemDictonaryModel<string>("无", "1"));
            this.pfss.Add(new ItemDictonaryModel<string>("油烟机", "2"));
            this.pfss.Add(new ItemDictonaryModel<string>("换气扇", "3"));
            this.pfss.Add(new ItemDictonaryModel<string>("烟囱", "4"));
            this.cmbCfpfss.DisplayMember = "DISPLAYMEMBER";
            this.cmbCfpfss.ValueMember = "VALUEMEMBER";
            this.cmbCfpfss.DataSource = this.pfss;
            this.rllx = new List<ItemDictonaryModel<string>>();
            this.rllx.Add(new ItemDictonaryModel<string>("液化气", "1"));
            this.rllx.Add(new ItemDictonaryModel<string>("煤", "2"));
            this.rllx.Add(new ItemDictonaryModel<string>("天燃气", "3"));
            this.rllx.Add(new ItemDictonaryModel<string>("沼气", "4"));
            this.rllx.Add(new ItemDictonaryModel<string>("柴火", "5"));
            this.rllx.Add(new ItemDictonaryModel<string>("其他", "6"));
            this.cmbrllx.DisplayMember = "DISPLAYMEMBER";
            this.cmbrllx.ValueMember = "VALUEMEMBER";
            this.cmbrllx.DataSource = this.rllx;
            this.ys = new List<ItemDictonaryModel<string>>();
            this.ys.Add(new ItemDictonaryModel<string>("自来水", "1"));
            this.ys.Add(new ItemDictonaryModel<string>("经净化过滤的水", "2"));
            this.ys.Add(new ItemDictonaryModel<string>("井水", "3"));
            this.ys.Add(new ItemDictonaryModel<string>("河湖水", "4"));
            this.ys.Add(new ItemDictonaryModel<string>("塘水", "5"));
            this.ys.Add(new ItemDictonaryModel<string>("其他", "6"));
            this.cmbys.DisplayMember = "DISPLAYMEMBER";
            this.cmbys.ValueMember = "VALUEMEMBER";
            this.cmbys.DataSource = this.ys;
            this.tolit = new List<ItemDictonaryModel<string>>();
            this.tolit.Add(new ItemDictonaryModel<string>("卫生厕所", "1"));
            this.tolit.Add(new ItemDictonaryModel<string>("一格或两格粪池式", "2"));
            this.tolit.Add(new ItemDictonaryModel<string>("马桶", "3"));
            this.tolit.Add(new ItemDictonaryModel<string>("露天粪坑", "4"));
            this.tolit.Add(new ItemDictonaryModel<string>("简易棚厕", "5"));
            this.cmbcs.DisplayMember = "DISPLAYMEMBER";
            this.cmbcs.ValueMember = "VALUEMEMBER";
            this.cmbcs.DataSource = this.tolit;
            this.qcl = new List<ItemDictonaryModel<string>>();
            this.qcl.Add(new ItemDictonaryModel<string>("无", "1"));
            this.qcl.Add(new ItemDictonaryModel<string>("单设", "2"));
            this.qcl.Add(new ItemDictonaryModel<string>("室内", "3"));
            this.qcl.Add(new ItemDictonaryModel<string>("室外", "4"));
            this.cmbqcl.DisplayMember = "DISPLAYMEMBER";
            this.cmbqcl.ValueMember = "VALUEMEMBER";
            this.cmbqcl.DataSource = this.qcl;
        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            RecordsSignatureBLL SignatureBLL = new RecordsSignatureBLL();

            if (!SignatureBLL.Update(this.SignModel))
            {
                SignatureBLL.Add(this.SignModel);
            }

            long result1 = 0, result2 = 0;
            
         
            //保存指纹
            if (pictureFinger.Image != null)
            {
                Image img = pictureFinger.Image;
                img.Save(String.Format("{0}{1}_Finger.png", FingerPath, this.Model.IDCardNo));
            }


            if (result1 != 0 && result2 != 0)
            {
                this.LifeEnvironment.SignDate = null;
            }
            else
            {
                this.LifeEnvironment.SignDate = this.dtSignDate.Value;
            }

            bool flag = this.archive_illnessoper(new RecordsIllnessHistoryInfoBLL(), this.IllnessHistoryInfo);
            if (this.FamilyHistoryInfo == null)
            {
                flag = false;
            }
            this.uc_otherillness_shoushu.SavetoDB();
            this.uc_otherillness_waishang.SavetoDB();
            this.uc_otherillness_shuxue.SavetoDB();
            RecordsFamilyHistoryInfoBLL recordsFamilyHistoryInfoBLL = new RecordsFamilyHistoryInfoBLL();
            if (!recordsFamilyHistoryInfoBLL.Exists(this.FamilyHistoryInfo.ID))
            {
                if (recordsFamilyHistoryInfoBLL.Add(this.FamilyHistoryInfo) <= 0)
                {
                }
            }
            else if (!recordsFamilyHistoryInfoBLL.Update(this.FamilyHistoryInfo))
            {
                flag = false;
            }
            string PhysicalClass = "";
            foreach (CheckBox ck in ckzdgllx)
            {
                if(ck.Checked)
                PhysicalClass+= ck.Name.Replace("checkBox", "")+","; 
            }
            if (!string.IsNullOrEmpty(PhysicalClass))
            {
                PhysicalClass = PhysicalClass.Substring(0,PhysicalClass.Length-1);
            }
            new RecordsBaseInfoBLL().UpdatePhysicalClass(Model.IDCardNo,PhysicalClass); 
            
            RecordsEnvironmentBLL recordsEnvironmentBLL = new RecordsEnvironmentBLL();
            if (!recordsEnvironmentBLL.Exists(this.LifeEnvironment.ID))
            {
                recordsEnvironmentBLL.Add(this.LifeEnvironment);
                return flag;
            }
            recordsEnvironmentBLL.Update(this.LifeEnvironment);
    

            return flag;
        }

        public void SimpleBinding(ComboBox cb, object src, string member)
        {
            Binding binding = new Binding("SelectedValue", src, member, false, DataSourceUpdateMode.OnValidation)
            {
                DataSourceNullValue = string.Empty
            };
            cb.DataBindings.Add(binding);
        }

        public void UpdataToModel()
        {
            this.FamilyHistoryInfo.RecordID = this.Model.RecordID;
            this.FamilyHistoryInfo.IDCardNo = this.Model.IDCardNo;
            this.FamilyHistoryInfo.FatherHistory = this.fuqin.FinalResult;
            this.FamilyHistoryInfo.FatherHistoryOther = this.fuqin.FinalResultEX;
            this.FamilyHistoryInfo.MotherHistory = this.muqin.FinalResult;
            this.FamilyHistoryInfo.MotherHistoryOther = this.muqin.FinalResultEX;
            this.FamilyHistoryInfo.BrotherSisterHistory = this.xiongmei.FinalResult;
            this.FamilyHistoryInfo.BrotherSisterHistoryOther = this.xiongmei.FinalResultEX;
            this.FamilyHistoryInfo.ChildrenHistory = this.zinv.FinalResult;
            this.FamilyHistoryInfo.ChildrenHistoryOther = this.zinv.FinalResultEX;
            this.ucIllnessHis1.UpdateSource();
        }

        public bool EveryThingIsOk { get; set; }

        public RecordsFamilyHistoryInfoModel FamilyHistoryInfo { get; set; }

        public bool HaveToSave { get; set; }

        public List<RecordsIllnessHistoryInfoModel> IllnessHistoryInfo { get; set; }

        public RecordsEnvironmentModel LifeEnvironment { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public RecordsSignatureModel SignModel { get; set; }
        
        public string SaveDataInfo { get; set; }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_B", picSign1_B);
            Clear("_J", picSign1_J);
        }

        private void uc_otherillness_shoushu_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 指纹采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFingerPrint_Click(object sender, EventArgs e)
        {
            string FingerType= ConfigHelper.GetSetNode("IsNewFinger");
            if (FingerType.Equals("N"))
            {
                OldFinger();
            }
            else
            {
                NewFinger();
            }
       
        }

        /// <summary>
        /// 旧指纹机
        /// </summary>
        private void OldFinger()
        {
            if (fp != null)//关闭指纹设备
            {
                fp.StopGetTemplate();
                fp.CloseDevice();
                fp.UnInitDevice();
            }

            IniFingerPrint();

            lblResult.Text = "请刷取指纹";
            lblResult.Left = 16;

            int r = fp.StartGetTemplate();

            btnFingerPrint.Enabled = false;
        }

        /// <summary>
        /// 新指纹机
        /// </summary>
        private void NewFinger()
        {
            if (m_WorkerThread != null) //关闭设备
            {
                try
                {
                    m_WorkerThread.Abort();
                    m_WorkerThread.Join();
                }
                catch (Exception ex)
                {
                    Thread.ResetAbort();
                }
            }
            StartThread(true);
            lblResult.Left = 16;
            btnFingerPrint.Enabled = false;
        }

        private void StartThread(bool isLogin)
        {
            m_WorkerThread = new Thread(new ThreadStart(delegate
            {
                ReadThreadProc(isLogin);
            }));
            m_WorkerThread.SetApartmentState(ApartmentState.STA);
            m_WorkerThread.Start();
        }

        private void ReadThreadProc(bool isLogin)
        {
            m_bStop = false;

            while (!m_bStop)
            {
                IntPtr hDevice = OpenDevice();

                if (hDevice != IntPtr.Zero)
                {
                    if (DoScan(hDevice))
                    {
                        // 为录入指纹状态时
                        if (!isLogin)
                        {
                            lblResult.Text = "注册成功";
                            FingerInfo = Convert.ToBase64String(m_pTemplate);

                            this.DialogResult = DialogResult.OK;
                        }

                        m_bStop = true;
                    }

                    ftrNativeLib.ftrScanCloseDevice(hDevice);
                    hDevice = IntPtr.Zero;
                }
            }
        }

        /// <summary>
        /// 开启设备
        /// </summary>
        /// <returns></returns>
        private IntPtr OpenDevice()
        {
            IntPtr hDevice = IntPtr.Zero;

            // 开启设备
            hDevice = ftrNativeLib.ftrScanOpenDevice();

            if (hDevice == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }

            m_ImageSize = new FTRSCAN_IMAGE_SIZE();

            if (!ftrNativeLib.ftrScanGetImageSize(hDevice, ref m_ImageSize))
            {
                ftrNativeLib.ftrScanCloseDevice(hDevice);
                return IntPtr.Zero;
            }

            m_pImage = new byte[m_ImageSize.nImageSize];

            for (int i = 0; i < m_pImage.Length; i++)
            {
                m_pImage[i] = (byte)(255 - m_pImage[i]);
            }

            return hDevice;
        }

        private bool DoScan(IntPtr hDevice)
        {
            bool bRC = false;
            int nOutTemplateSize = 0;

            byte[] pbyBaseTemplate = null;

            pbyBaseTemplate = new byte[ftrNativeLib.ftrAnsiSdkGetMaxTemplateSize()];

            // 取得指纹机中按下指纹
            bRC = ftrNativeLib.ftrAnsiSdkCreateTemplate(hDevice, m_byFingerPosition, m_pImage, pbyBaseTemplate, ref nOutTemplateSize);

            if (bRC)
            {
                for (int i = 0; i < m_pImage.Length; i++)
                {
                    m_pImage[i] = (byte)(255 - m_pImage[i]);
                }
            }

            // Update finger image
            if (m_pImage != null)
            {
                MyBitmapFile myFile = new MyBitmapFile(m_ImageSize.nWidth, m_ImageSize.nHeight, m_pImage);
                MemoryStream BmpStream = new MemoryStream(myFile.BitmatFileData);
                Bitmap Bmp = new Bitmap(BmpStream);
                pictureFinger.Image = Bmp;
            }
            else pictureFinger.Image = null;

            return bRC;
        }

        private void IniFingerPrint()
        {
            // 实例化指纹接口
            fp = new BioneFPAPILib.FPAPICtrlClass();
            // 指纹比对取特征的时候，当特征抽取成功后调用次回调
            fp.FeatureCallbackOfBae64 += new BioneFPAPILib._IFPAPICtrlEvents_FeatureCallbackOfBae64EventHandler(aa_FeatureCallbackOfBae64);
            // 刷取每一幅图像过程中，进行指纹特征抽取的回调
            fp.FingerPrintStateOfBae64 += new BioneFPAPILib._IFPAPICtrlEvents_FingerPrintStateOfBae64EventHandler(aa_FingerPrintStateOfBae64);
            // 指纹注册取模板的时候，当模板合成成功后调用此回调
            fp.TemplateCallbackOfBae64 += new BioneFPAPILib._IFPAPICtrlEvents_TemplateCallbackOfBae64EventHandler(aa_TemplateCallbackOfBae64);
            // 自动选取一个设备
            int result = fp.AutoSelectDevice();

            if (result != 0)
            {
                MessageBox.Show("指纹机连接异常！");
                return;
            }

            // 初始化设备
            result = fp.InitDevice();
            if (result != 0)
            {
                MessageBox.Show("指纹机连接异常！");
                return;
            }
            // 打开设备
            result = fp.OpenDevice();
            if (result != 0)
            {
                MessageBox.Show("指纹机连接异常！");
                return;
            }
        }

        /// <summary>
        /// 指纹比对取特征的时候，当特征抽取成功后调用次回调
        /// </summary>
        /// <param name="featureDataBuf"></param>
        /// <param name="featureSize"></param>
        /// <param name="pressTimes"></param>
        /// <param name="featureNum"></param>
        /// <param name="gType"></param>
        void aa_FeatureCallbackOfBae64(string featureDataBuf, short featureSize, short pressTimes, short featureNum, short gType)
        {
            sb2 = featureDataBuf;
            MessageBox.Show(" 获取到了要比对的特征");
        }

        /// <summary>
        /// 刷取每一幅图像过程中，进行指纹特征抽取的回调
        /// </summary>
        /// <param name="imgDataBuf"></param>
        /// <param name="imgDataBufLength"></param>
        /// <param name="imgWidth"></param>
        /// <param name="imgHeight"></param>
        /// <param name="nowStep"></param>
        /// <param name="nowState"></param>
        void aa_FingerPrintStateOfBae64(string imgDataBuf, uint imgDataBufLength, short imgWidth, short imgHeight, short nowStep, short nowState)
        {
            if (nowStep != -1)
            {
                char[] charBuffer = imgDataBuf.ToCharArray();
                byte[] bytes = Convert.FromBase64CharArray(charBuffer, 0, charBuffer.Length);

                Bitmap bmp = CreateBitmap(bytes, imgWidth, imgHeight);
                pictureFinger.Image = bmp;

                lblResult.Invoke(new MethodInvoker(delegate
                {
                    lblResult.Text = "请再按一次";
                }));
            }
        }

        /// <summary>
        /// 指纹注册取模板的时候，当模板合成成功后调用此回调
        /// </summary>
        /// <param name="featureDataBuf"></param>
        /// <param name="featureSize"></param>
        /// <param name="pressTimes"></param>
        /// <param name="featureNum"></param>
        /// <param name="gType"></param>
        void aa_TemplateCallbackOfBae64(string featureDataBuf, short featureSize, short pressTimes, short featureNum, short gType)
        {
            sb1 = featureDataBuf;

            lblResult.Invoke(new MethodInvoker(delegate
            {
                lblResult.Text = "注册成功";
            }));
        }

        /// <summary>
        /// 使用byte[]数据，生成256色灰度　BMP 位图
        /// </summary>
        /// <param name="originalImageData"></param>
        /// <param name="originalWidth"></param>
        /// <param name="originalHeight"></param>
        /// <returns></returns>
        public static Bitmap CreateBitmap(byte[] originalImageData, int originalWidth, int originalHeight)
        {
            //指定8位格式，即256色
            Bitmap resultBitmap = new Bitmap(originalWidth, originalHeight, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

            //将该位图存入内存中
            MemoryStream curImageStream = new MemoryStream();
            resultBitmap.Save(curImageStream, System.Drawing.Imaging.ImageFormat.Bmp);
            curImageStream.Flush();

            //由于位图数据需要DWORD对齐（4byte倍数），计算需要补位的个数
            int curPadNum = ((originalWidth * 8 + 31) / 32 * 4) - originalWidth;

            //最终生成的位图数据大小
            int bitmapDataSize = ((originalWidth * 8 + 31) / 32 * 4) * originalHeight;

            //数据部分相对文件开始偏移，具体可以参考位图文件格式
            int dataOffset = ReadData(curImageStream, 10, 4);


            //改变调色板，因为默认的调色板是32位彩色的，需要修改为256色的调色板
            int paletteStart = 54;
            int paletteEnd = dataOffset;
            int color = 0;

            for (int i = paletteStart; i < paletteEnd; i += 4)
            {
                byte[] tempColor = new byte[4];
                tempColor[0] = (byte)color;
                tempColor[1] = (byte)color;
                tempColor[2] = (byte)color;
                tempColor[3] = (byte)0;
                color++;

                curImageStream.Position = i;
                curImageStream.Write(tempColor, 0, 4);
            }

            //最终生成的位图数据，以及大小，高度没有变，宽度需要调整
            byte[] destImageData = new byte[bitmapDataSize];
            int destWidth = originalWidth + curPadNum;

            //生成最终的位图数据，注意的是，位图数据 从左到右，从下到上，所以需要颠倒
            for (int originalRowIndex = originalHeight - 1; originalRowIndex >= 0; originalRowIndex--)
            {
                int destRowIndex = originalHeight - originalRowIndex - 1;

                for (int dataIndex = 0; dataIndex < originalWidth; dataIndex++)
                {
                    //同时还要注意，新的位图数据的宽度已经变化destWidth，否则会产生错位
                    destImageData[destRowIndex * destWidth + dataIndex] = originalImageData[originalRowIndex * originalWidth + dataIndex];
                }
            }


            //将流的Position移到数据段   
            curImageStream.Position = dataOffset;

            //将新位图数据写入内存中
            curImageStream.Write(destImageData, 0, bitmapDataSize);

            curImageStream.Flush();

            //将内存中的位图写入Bitmap对象
            try
            {
                resultBitmap = new Bitmap(curImageStream);
                return resultBitmap;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 从内存流中指定位置，读取数据
        /// </summary>
        /// <param name="curStream"></param>
        /// <param name="startPosition"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static int ReadData(MemoryStream curStream, int startPosition, int length)
        {
            int result = -1;

            byte[] tempData = new byte[length];
            curStream.Position = startPosition;
            curStream.Read(tempData, 0, length);
            result = BitConverter.ToInt32(tempData, 0);

            return result;
        }
        private void picSign1_B_Click(object sender, EventArgs e)
        {
            Sign("_B", picSign1_B);
        }

        private void picSign1_J_Click(object sender, EventArgs e)
        {
            Sign("_J", picSign1_J);
        }

        private void Sign(string DaySign, PictureBox picture)
        {
            FingerPrint.SignForm loadForm = new FingerPrint.SignForm();
            if (!Directory.Exists(SignPath))
            {
                Directory.CreateDirectory(SignPath);
            }
            loadForm.IDCardNo = Model.IDCardNo;
            loadForm.SignPath = SignPath;
            loadForm.SignName = DaySign;
            if (loadForm.ShowDialog() == DialogResult.OK)
            {
                if (picture.Image != null)
                {
                    picture.Image.Dispose();
                    picture.Image = null;
                }
                string path = string.Format("{0}{1}{2}.png", SignPath, Model.IDCardNo, DaySign);
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
                    string path = SignPath + Model.IDCardNo + DaySign + ".png";
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

