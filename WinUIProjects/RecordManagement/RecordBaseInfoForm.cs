using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace RecordManagement
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Data;
    using System.IO;
    using KangShuoTech.Utilities.CommonControl;
    using System.Reflection;
    using System.Configuration;

    public class RecordBaseInfoForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private IContainer components;
        private DateTimePicker dtpBuildDate;
        private GroupBox groupBox1;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lbNo;
        private TextBox tbAddr;
        private TextBox tbName;
        private TextBox tbNowAddr;
        private TextBox tbPhone;
        private TextBox tbTown;
        private PictureBox pictureBox1;
        private ComboBox cmbVillage;
        private TextBox tbVillage;
        private DataTable dt_village;
        private TextBox tbRecordID;
        private GroupBox groupBox2;
        private TextBox tbJtyqt;
        private Label label21;
        private TextBox tbWsrydh;
        private Label label19;
        private TextBox tbWsry;
        private Label label20;
        private TextBox tbHsdh;
        private Label label17;
        private TextBox tbHs;
        private Label lbHs;
        private TextBox tbJtysdh;
        private Label lbJtysdh;
        private TextBox tbJtys;
        private Label label15;
        private Label label14;
        private TextBox tbJglxfs;
        private Label label13;
        private TextBox tbqita;
        private CheckBox ckhb8;
        private CheckBox ckhb7;
        private CheckBox ckhb6;
        private CheckBox ckhb5;
        private CheckBox ckhb4;
        private CheckBox ckhb3;
        private CheckBox ckhb2;
        private CheckBox ckhb1;
        private Label label12;
        private BindingSource bds_arvillage;
        private Button btnPhoto;
        private ComboBox cbmBuildUnit;
        private ComboBox cbmDoctor;
        private ComboBox cmbBuildMan;
        private ManyCheckboxs<HealthRecordsinfoModel> huanbing;
        private DataTable dt_Orgdistrict;
        private DataTable dt_Orgvillage;
        private BindingSource bds_Orgvillage;
        private DataTable dt_SysUser;
        private BindingSource bds_SysUser;
        private DataTable dt_Doctor;
        private BindingSource bds_Doctor;
        private string PhotosPath = ConfigurationManager.AppSettings["PhotosPath"] == null ? @"D:/QCSoft/photos/" : ConfigurationManager.AppSettings["PhotosPath"].ToString(); //拍照照片路径
        private string PhotoPath = ConfigurationManager.AppSettings["PhotoPath"] == null ? @"photo/" : ConfigurationManager.AppSettings["PhotoPath"].ToString(); //身份证照片路径

        public RecordBaseInfoForm()
        {
            this.InitializeComponent();
            this.EveryThingIsOk = false;
        }

        public ChildFormStatus CheckErrorInput()
        {
            //if (string.IsNullOrEmpty(this.Model.Phone))
            //{
            //    this.SaveDataInfo = "联系电话不能为空！";
            //    return ChildFormStatus.HasErrorInput;
            //}
            if (!(this.tbPhone.BackColor == Color.Salmon))
            {
                return ChildFormStatus.NoErrorInput;
            }
            this.SaveDataInfo = "联系电话输入有误！";
            return ChildFormStatus.HasErrorInput;
        }

        public bool CheckRequiredInput(ref string judgeInfo)
        {
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void RecordBaseInfoForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void BindArea(ComboBox cbx, BindingSource bds)
        {
            Action<ComboBox, BindingSource> method = new Action<ComboBox, BindingSource>(this.BindArea);

            if (cbx.InvokeRequired)
            {
                cbx.Invoke(method, new object[] { cbx, bds });
            }
            else
            {
                if (cbx.Name == this.cmbBuildMan.Name || cbx.Name == this.cbmDoctor.Name)
                {
                    cbx.DisplayMember = "UserName";
                }
                else
                {
                    cbx.DisplayMember = "Name";
                }
                cbx.ValueMember = "ID";
                cbx.DataSource = bds;
            }
        }

        public void GetOrg()
        {
            string strVillage = "", strOrgvillage = "";
            if (this.Model.TownID.HasValue)
            {
                strVillage = string.Format(" code like '{0}%' ", this.Model.TownID);
            }
            this.dt_village = new RecordsVillageBLL().GetList(strVillage).Tables[0];//行政机构五级-村
            DataRow row = this.dt_village.NewRow();
            this.bds_arvillage = new BindingSource();
            this.bds_arvillage.DataSource = this.dt_village;
            this.BindArea(this.cmbVillage, this.bds_arvillage);

            if (this.Model.OrgTownID.HasValue)
            {
                strOrgvillage = string.Format(" code like '{0}%' ", this.Model.OrgTownID);
            }
            this.dt_Orgvillage = new SysOrgVillangBLL().GetList(strOrgvillage).Tables[0];//组织机构五级-村
            DataRow roworg = this.dt_Orgvillage.NewRow();
            this.bds_Orgvillage = new BindingSource();
            this.bds_Orgvillage.DataSource = this.dt_Orgvillage;
            this.BindArea(this.cbmBuildUnit, this.bds_Orgvillage);

            this.dt_Orgdistrict = new SysOrgDistrictBLL().GetList(string.Format(" code = '{0}' ", this.Model.OrgDistrictID)).Tables[0];
            string str = "-1";
            if (this.dt_Orgdistrict.Rows.Count > 0)
            {
                str = this.dt_Orgdistrict.Rows[0]["ID"].ToString();
            }

            this.dt_SysUser = new SysUserBLL().GetList(string.Format(" DistrictID = {0} ", str)).Tables[0];
            this.bds_SysUser = new BindingSource();
            this.bds_SysUser.DataSource = this.dt_SysUser;
            this.BindArea(this.cmbBuildMan, this.bds_SysUser);

            this.dt_Doctor = this.dt_SysUser;
            this.bds_Doctor = new BindingSource();
            this.bds_Doctor.DataSource = this.dt_Doctor;
            this.BindArea(this.cbmDoctor, this.bds_Doctor);
        }

        public void InitEveryThing()
        {
            GetOrg();
            this.HealthModel = new HealthRecordsinfoBLL().GetModel(this.Model.IDCardNo);
            if (this.HealthModel == null)
            {
                HealthRecordsinfoModel healthRecords = new HealthRecordsinfoModel
                {
                    IDCardNo = this.Model.IDCardNo
                };
                this.HealthModel = healthRecords;
            }
            this.PresetValue();//默认项设置
            this.tbName.DataBindings.Add("Text", this.Model, "CustomerName", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbNowAddr.DataBindings.Add("Text", this.Model, "Address", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbAddr.DataBindings.Add("Text", this.Model, "HouseHoldAddress", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbPhone.DataBindings.Add("Text", this.Model, "Phone", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbTown.DataBindings.Add("Text", this.Model, "TownName", false, DataSourceUpdateMode.OnPropertyChanged);
          
            this.tbVillage.Visible = false;
            if (this.Model.VillageName == null && this.dt_village.Rows.Count > 0) //组织机构村
            {
                this.cmbVillage.SelectedIndex = 0;
            }
            else
            {
                this.cmbVillage.Text = this.Model.VillageName;
            }
            if (this.Model.CreateUnitName == null && dt_Orgvillage.Rows.Count > 0) //建档单位
            {
                this.cbmBuildUnit.SelectedIndex = 0;
            }
            else
            {
                this.cbmBuildUnit.Text = this.Model.CreateUnitName;
            }
            if (this.Model.CreateMenName == null && this.dt_SysUser.Rows.Count > 0) //建档人
            {

                this.cmbBuildMan.SelectedIndex = 0;
            }
            else
            {
                this.cmbBuildMan.Text = this.Model.CreateMenName;
            }
            if (this.Model.Doctor == null && this.dt_Doctor.Rows.Count > 0) //责任医生
            {
                this.cbmDoctor.SelectedIndex = 0;
            }
            else
            {
                this.cbmDoctor.Text = this.Model.Doctor;
            }
            if (this.Model.CreateDate.HasValue)
            {
                this.dtpBuildDate.Value= this.Model.CreateDate.Value;
            }

            this.huanbing = new ManyCheckboxs<HealthRecordsinfoModel>(this.HealthModel);
            this.huanbing.AddCk(this.ckhb1, true);
            this.huanbing.AddCk(new CheckBox[] { this.ckhb2, this.ckhb3, this.ckhb4, this.ckhb5, this.ckhb6, this.ckhb7 });
            this.huanbing.AddCk(this.ckhb8, this.tbqita);
            this.huanbing.BindingProperty("Prevalence", "PrevalenceOther");
            this.tbJglxfs.DataBindings.Add("Text", this.HealthModel, "OrgTelphone", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbJtys.DataBindings.Add("Text", this.HealthModel, "FamilyDoctor", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbJtysdh.DataBindings.Add("Text", this.HealthModel, "FamilyDoctorTel", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbHs.DataBindings.Add("Text", this.HealthModel, "Nurses", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbHsdh.DataBindings.Add("Text", this.HealthModel, "NursesTel", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbWsry.DataBindings.Add("Text", this.HealthModel, "HealthPersonnel", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbWsrydh.DataBindings.Add("Text", this.HealthModel, "HealthPersonnelTel", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbJtyqt.DataBindings.Add("Text", this.HealthModel, "Others", false, DataSourceUpdateMode.OnPropertyChanged);

            //this.lbNo.Text = string.Format("编号:{0}", this.Model.RecordID);
            this.tbRecordID.DataBindings.Add("Text", this.Model, "RecordID", false, DataSourceUpdateMode.OnPropertyChanged);

            string path = PhotoPath + this.Model.IDCardNo + "_" + this.Model.CustomerName + ".bmp";

            if (File.Exists(path))
            {
                this.pictureBox1.Image = Image.FromFile(path);
            }         
            
            MustChoose();
            this.EveryThingIsOk = true;
        }

        //默认项设置
        private void PresetValue()
        {
            DataSet dsre = new DataSet();
            dsre = new RequireBLL().GetList("TabName = '个人档案' and Comment = '封面信息' and IsSetValue='是' ");
            DataTable dt = dsre.Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                string str = item["ChinName"].ToString();
                switch (str)
                {
                    case "现住址":
                        if (string.IsNullOrEmpty(this.Model.Address))
                            this.Model.Address = item["ItemValue"].ToString();
                        break;
                    case "联系电话":
                        if (string.IsNullOrEmpty(this.Model.Phone))
                            this.Model.Phone = item["ItemValue"].ToString();
                        break;
                    case "责任医生":
                        if (string.IsNullOrEmpty(this.Model.Doctor))
                            this.Model.Doctor = item["ItemValue"].ToString();
                        break;
                    case "建档人":
                        if (string.IsNullOrEmpty(this.Model.CreateMenName))
                            this.Model.CreateMenName = item["ItemValue"].ToString();
                        break;
                    case "建档单位":
                        if (string.IsNullOrEmpty(this.Model.CreateUnitName))
                            this.Model.CreateUnitName = item["ItemValue"].ToString();
                        break;
                    case "村(居委会名称)":
                        if (string.IsNullOrEmpty(this.Model.VillageName))
                            this.Model.VillageName = item["ItemValue"].ToString();
                        break;
                    case "乡镇(街道名称)":
                        if (string.IsNullOrEmpty(this.Model.TownName))
                            this.Model.TownName = item["ItemValue"].ToString();
                        break;
                    case "户籍地址":
                        if (string.IsNullOrEmpty(this.Model.HouseHoldAddress))
                            this.Model.HouseHoldAddress = item["ItemValue"].ToString();
                        break;
                    case "编号":
                        if (string.IsNullOrEmpty(this.Model.RecordID))
                            this.Model.RecordID = item["ItemValue"].ToString();
                        break;
                    case "患病情况":
                        if (string.IsNullOrEmpty(this.HealthModel.Prevalence))
                            this.HealthModel.Prevalence = item["ItemValue"].ToString();
                        break;
                    case "建档机构联系电话":
                        if (string.IsNullOrEmpty(this.HealthModel.OrgTelphone))
                            this.HealthModel.OrgTelphone = item["ItemValue"].ToString();
                        break;
                    case "家庭(责任)医生":
                        if (string.IsNullOrEmpty(this.HealthModel.FamilyDoctor))
                            this.HealthModel.FamilyDoctor = item["ItemValue"].ToString();
                        break;
                    case "家庭(责任)医生电话":
                        if (string.IsNullOrEmpty(this.HealthModel.FamilyDoctorTel))
                            this.HealthModel.FamilyDoctorTel = item["ItemValue"].ToString();
                        break;
                    case "社区(责任)护士":
                        if (string.IsNullOrEmpty(this.HealthModel.Nurses))
                            this.HealthModel.Nurses = item["ItemValue"].ToString();
                        break;
                    case "社区(责任)护士电话":
                        if (string.IsNullOrEmpty(this.HealthModel.NursesTel))
                            this.HealthModel.NursesTel = item["ItemValue"].ToString();
                        break;
                    case "公共卫生人员":
                        if (string.IsNullOrEmpty(this.HealthModel.HealthPersonnel))
                            this.HealthModel.HealthPersonnel = item["ItemValue"].ToString();
                        break;
                    case "公共卫生人员电话":
                        if (string.IsNullOrEmpty(this.HealthModel.HealthPersonnelTel))
                            this.HealthModel.HealthPersonnelTel = item["ItemValue"].ToString();
                        break;
                    case "其他说明":
                        if (string.IsNullOrEmpty(this.HealthModel.Others))
                            this.HealthModel.Others = item["ItemValue"].ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void MustChoose()
        {
            DataSet dsrequire = new DataSet();
            dsrequire = new RequireBLL().GetList("TabName = '个人档案' and Comment = '封面信息' ");
            RecordsBaseInfoModel Models = new RecordsBaseInfoBLL().GetModel(Model.IDCardNo.ToString());
            HealthRecordsinfoModel HealthModelTemp = new HealthRecordsinfoBLL().GetModel(this.Model.IDCardNo);
            if (HealthModelTemp == null) HealthModelTemp = new HealthRecordsinfoModel();
            DataTable dt = dsrequire.Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                if (item["Isrequired"].ToString() == "1")
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "现住址":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.Address)))
                            {
                                this.label3.Text = "*现 住 址:";
                                this.label3.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label3.Text = "现 住 址:";
                                this.label3.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "联系电话":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.Phone)))
                            {
                                this.label5.Text = "*联系电话:";
                                this.label5.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label5.Text = "联系电话:";
                                this.label5.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "户籍地址":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.HouseHoldAddress)))
                            {
                                this.label4.Text = "*户籍地址:";
                                this.label4.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label4.Text = "户籍地址:";
                                this.label4.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "乡镇(街道名称)":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.TownName)))
                            {
                                this.label7.Text = "*乡镇(街道名称):";
                                this.label7.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label7.Text = "乡镇(街道名称):";
                                this.label7.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "村(居委会名称)":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.VillageName)))
                            {
                                this.label6.Text = "*村(居委会名称):";
                                this.label6.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label6.Text = "村(居委会名称):";
                                this.label6.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "建档单位":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.CreateUnitName)))
                            {
                                this.label11.Text = "*建档单位:";
                                this.label11.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label11.Text = "建档单位:";
                                this.label11.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "建档人":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.CreateMenName)))
                            {
                                this.label10.Text = "*建档人:";
                                this.label10.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label10.Text = "建档人:";
                                this.label10.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "责任医生":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.Doctor)))
                            {
                                this.label8.Text = "*责任医生:";
                                this.label8.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label8.Text = "责任医生:";
                                this.label8.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "建档日期":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.CreateDate)))
                            {
                                this.label9.Text = "*建档日期:";
                                this.label9.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label9.Text = "建档日期:";
                                this.label9.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "编号":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.RecordID)))
                            {
                                this.lbNo.Text = "*编号:";
                                this.lbNo.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.lbNo.Text = "编号:";
                                this.lbNo.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "患病情况":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthModelTemp.Prevalence)))
                            {
                                this.label12.Text = "*患病情况:";
                                this.label12.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label12.Text = "患病情况:";
                                this.label12.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "建档机构联系电话":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthModelTemp.OrgTelphone)))
                            {
                                this.label13.Text = "*建档机构联系电话:";
                                this.label13.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label13.Text = "建档机构联系电话:";
                                this.label13.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "家庭(责任)医生":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthModelTemp.FamilyDoctor)))
                            {
                                this.label15.Text = "*家庭(责任)医生:";
                                this.label15.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label15.Text = "家庭(责任)医生:";
                                this.label15.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "家庭(责任)医生电话":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthModelTemp.FamilyDoctorTel)))
                            {
                                this.lbJtysdh.Text = "*联系电话:";
                                this.lbJtysdh.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.lbJtysdh.Text = "联系电话:";
                                this.lbJtysdh.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "社区(责任)护士":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthModelTemp.Nurses)))
                            {
                                this.lbHs.Text = "*社区(责任)护士:";
                                this.lbHs.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.lbHs.Text = "社区(责任)护士:";
                                this.lbHs.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "社区(责任)护士电话":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthModelTemp.NursesTel)))
                            {
                                this.label17.Text = "*联系电话:";
                                this.label17.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label17.Text = "联系电话:";
                                this.label17.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "公共卫生人员":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthModelTemp.HealthPersonnel)))
                            {
                                this.label20.Text = "*公共卫生人员:";
                                this.label20.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label20.Text = "公共卫生人员:";
                                this.label20.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "公共卫生人员电话":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthModelTemp.HealthPersonnelTel)))
                            {
                                this.label19.Text = "*联系电话:";
                                this.label19.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label19.Text = "联系电话:";
                                this.label19.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "其他说明":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthModelTemp.Others)))
                            {
                                this.label21.Text = "*其他说明:";
                                this.label21.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label21.Text = "其他说明:";
                                this.label21.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        default: break;
                    }
                }
            }

        }

        private void InitializeComponent()
        {
            this.lbNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbmBuildUnit = new System.Windows.Forms.ComboBox();
            this.cbmDoctor = new System.Windows.Forms.ComboBox();
            this.cmbBuildMan = new System.Windows.Forms.ComboBox();
            this.cmbVillage = new System.Windows.Forms.ComboBox();
            this.dtpBuildDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbTown = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbVillage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAddr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNowAddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbRecordID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbJtyqt = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbWsrydh = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbWsry = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbHsdh = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbHs = new System.Windows.Forms.TextBox();
            this.lbHs = new System.Windows.Forms.Label();
            this.tbJtysdh = new System.Windows.Forms.TextBox();
            this.lbJtysdh = new System.Windows.Forms.Label();
            this.tbJtys = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbJglxfs = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbqita = new System.Windows.Forms.TextBox();
            this.ckhb8 = new System.Windows.Forms.CheckBox();
            this.ckhb7 = new System.Windows.Forms.CheckBox();
            this.ckhb6 = new System.Windows.Forms.CheckBox();
            this.ckhb5 = new System.Windows.Forms.CheckBox();
            this.ckhb4 = new System.Windows.Forms.CheckBox();
            this.ckhb3 = new System.Windows.Forms.CheckBox();
            this.ckhb2 = new System.Windows.Forms.CheckBox();
            this.ckhb1 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnPhoto = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNo
            // 
            this.lbNo.AutoSize = true;
            this.lbNo.BackColor = System.Drawing.Color.Transparent;
            this.lbNo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNo.Location = new System.Drawing.Point(985, 77);
            this.lbNo.Name = "lbNo";
            this.lbNo.Size = new System.Drawing.Size(59, 20);
            this.lbNo.TabIndex = 48;
            this.lbNo.Text = "编号:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(592, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 29);
            this.label1.TabIndex = 25;
            this.label1.Text = "居民健康档案";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbmBuildUnit);
            this.groupBox1.Controls.Add(this.cbmDoctor);
            this.groupBox1.Controls.Add(this.cmbBuildMan);
            this.groupBox1.Controls.Add(this.cmbVillage);
            this.groupBox1.Controls.Add(this.dtpBuildDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbTown);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbVillage);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbPhone);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbAddr);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbNowAddr);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(73, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1178, 270);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cbmBuildUnit
            // 
            this.cbmBuildUnit.FormattingEnabled = true;
            this.cbmBuildUnit.Location = new System.Drawing.Point(735, 34);
            this.cbmBuildUnit.Name = "cbmBuildUnit";
            this.cbmBuildUnit.Size = new System.Drawing.Size(300, 28);
            this.cbmBuildUnit.TabIndex = 70;
            this.cbmBuildUnit.SelectedIndexChanged += new System.EventHandler(this.cbmBuildUnit_SelectedIndexChanged);
            // 
            // cbmDoctor
            // 
            this.cbmDoctor.FormattingEnabled = true;
            this.cbmDoctor.Location = new System.Drawing.Point(735, 108);
            this.cbmDoctor.Name = "cbmDoctor";
            this.cbmDoctor.Size = new System.Drawing.Size(300, 28);
            this.cbmDoctor.TabIndex = 69;
            // 
            // cmbBuildMan
            // 
            this.cmbBuildMan.FormattingEnabled = true;
            this.cmbBuildMan.Location = new System.Drawing.Point(735, 71);
            this.cmbBuildMan.Name = "cmbBuildMan";
            this.cmbBuildMan.Size = new System.Drawing.Size(300, 28);
            this.cmbBuildMan.TabIndex = 68;
            // 
            // cmbVillage
            // 
            this.cmbVillage.FormattingEnabled = true;
            this.cmbVillage.Location = new System.Drawing.Point(232, 222);
            this.cmbVillage.Name = "cmbVillage";
            this.cmbVillage.Size = new System.Drawing.Size(300, 28);
            this.cmbVillage.TabIndex = 9;
            // 
            // dtpBuildDate
            // 
            this.dtpBuildDate.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBuildDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBuildDate.Location = new System.Drawing.Point(735, 146);
            this.dtpBuildDate.Name = "dtpBuildDate";
            this.dtpBuildDate.Size = new System.Drawing.Size(300, 30);
            this.dtpBuildDate.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(621, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 55;
            this.label11.Text = "建档单位:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(621, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 53;
            this.label8.Text = "责任医生:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(621, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 52;
            this.label9.Text = "建档日期:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(621, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 50;
            this.label10.Text = "建 档 人:";
            // 
            // tbTown
            // 
            this.tbTown.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbTown.Location = new System.Drawing.Point(232, 184);
            this.tbTown.MaxLength = 100;
            this.tbTown.Name = "tbTown";
            this.tbTown.Size = new System.Drawing.Size(300, 30);
            this.tbTown.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(41, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 20);
            this.label7.TabIndex = 48;
            this.label7.Text = "乡镇(街道名称):";
            // 
            // tbVillage
            // 
            this.tbVillage.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbVillage.Location = new System.Drawing.Point(232, 222);
            this.tbVillage.MaxLength = 100;
            this.tbVillage.Name = "tbVillage";
            this.tbVillage.ReadOnly = true;
            this.tbVillage.Size = new System.Drawing.Size(300, 30);
            this.tbVillage.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(41, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 20);
            this.label6.TabIndex = 46;
            this.label6.Text = "村(居委会名称):";
            // 
            // tbPhone
            // 
            this.tbPhone.BackColor = System.Drawing.SystemColors.Window;
            this.tbPhone.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPhone.Location = new System.Drawing.Point(232, 147);
            this.tbPhone.MaxLength = 15;
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(300, 30);
            this.tbPhone.TabIndex = 6;
            this.tbPhone.TextChanged += new System.EventHandler(this.tbPhone_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(101, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 44;
            this.label5.Text = "联系电话:";
            // 
            // tbAddr
            // 
            this.tbAddr.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbAddr.Location = new System.Drawing.Point(232, 109);
            this.tbAddr.MaxLength = 100;
            this.tbAddr.Name = "tbAddr";
            this.tbAddr.Size = new System.Drawing.Size(300, 30);
            this.tbAddr.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(101, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 42;
            this.label4.Text = "户籍地址:";
            // 
            // tbNowAddr
            // 
            this.tbNowAddr.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbNowAddr.Location = new System.Drawing.Point(232, 72);
            this.tbNowAddr.MaxLength = 100;
            this.tbNowAddr.Name = "tbNowAddr";
            this.tbNowAddr.Size = new System.Drawing.Size(300, 30);
            this.tbNowAddr.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(101, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "现 住 址:";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.SystemColors.Control;
            this.tbName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbName.Location = new System.Drawing.Point(232, 35);
            this.tbName.MaxLength = 20;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(300, 30);
            this.tbName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(101, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "姓    名:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1274, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // tbRecordID
            // 
            this.tbRecordID.Location = new System.Drawing.Point(1061, 74);
            this.tbRecordID.Name = "tbRecordID";
            this.tbRecordID.Size = new System.Drawing.Size(190, 30);
            this.tbRecordID.TabIndex = 51;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbJtyqt);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.tbWsrydh);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.tbWsry);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.tbHsdh);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.tbHs);
            this.groupBox2.Controls.Add(this.lbHs);
            this.groupBox2.Controls.Add(this.tbJtysdh);
            this.groupBox2.Controls.Add(this.lbJtysdh);
            this.groupBox2.Controls.Add(this.tbJtys);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.tbJglxfs);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbqita);
            this.groupBox2.Controls.Add(this.ckhb8);
            this.groupBox2.Controls.Add(this.ckhb7);
            this.groupBox2.Controls.Add(this.ckhb6);
            this.groupBox2.Controls.Add(this.ckhb5);
            this.groupBox2.Controls.Add(this.ckhb4);
            this.groupBox2.Controls.Add(this.ckhb3);
            this.groupBox2.Controls.Add(this.ckhb2);
            this.groupBox2.Controls.Add(this.ckhb1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(73, 379);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1178, 249);
            this.groupBox2.TabIndex = 148;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "居民健康档案信息卡 ";
            // 
            // tbJtyqt
            // 
            this.tbJtyqt.Location = new System.Drawing.Point(233, 206);
            this.tbJtyqt.Name = "tbJtyqt";
            this.tbJtyqt.Size = new System.Drawing.Size(798, 30);
            this.tbJtyqt.TabIndex = 45;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(92, 204);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(109, 20);
            this.label21.TabIndex = 44;
            this.label21.Text = "其他说明 :";
            // 
            // tbWsrydh
            // 
            this.tbWsrydh.Location = new System.Drawing.Point(831, 172);
            this.tbWsrydh.Name = "tbWsrydh";
            this.tbWsrydh.Size = new System.Drawing.Size(200, 30);
            this.tbWsrydh.TabIndex = 43;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(716, 176);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 20);
            this.label19.TabIndex = 42;
            this.label19.Text = "联系电话 :";
            // 
            // tbWsry
            // 
            this.tbWsry.Location = new System.Drawing.Point(404, 172);
            this.tbWsry.Name = "tbWsry";
            this.tbWsry.Size = new System.Drawing.Size(200, 30);
            this.tbWsry.TabIndex = 41;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(249, 175);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(149, 20);
            this.label20.TabIndex = 40;
            this.label20.Text = "公共卫生人员 :";
            // 
            // tbHsdh
            // 
            this.tbHsdh.Location = new System.Drawing.Point(831, 140);
            this.tbHsdh.Name = "tbHsdh";
            this.tbHsdh.Size = new System.Drawing.Size(200, 30);
            this.tbHsdh.TabIndex = 39;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(716, 144);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(109, 20);
            this.label17.TabIndex = 38;
            this.label17.Text = "联系电话 :";
            // 
            // tbHs
            // 
            this.tbHs.Location = new System.Drawing.Point(404, 140);
            this.tbHs.Name = "tbHs";
            this.tbHs.Size = new System.Drawing.Size(200, 30);
            this.tbHs.TabIndex = 37;
            // 
            // lbHs
            // 
            this.lbHs.AutoSize = true;
            this.lbHs.Location = new System.Drawing.Point(229, 143);
            this.lbHs.Name = "lbHs";
            this.lbHs.Size = new System.Drawing.Size(169, 20);
            this.lbHs.TabIndex = 36;
            this.lbHs.Text = "社区(责任)护士 :";
            // 
            // tbJtysdh
            // 
            this.tbJtysdh.Location = new System.Drawing.Point(831, 105);
            this.tbJtysdh.Name = "tbJtysdh";
            this.tbJtysdh.Size = new System.Drawing.Size(200, 30);
            this.tbJtysdh.TabIndex = 35;
            // 
            // lbJtysdh
            // 
            this.lbJtysdh.AutoSize = true;
            this.lbJtysdh.Location = new System.Drawing.Point(716, 109);
            this.lbJtysdh.Name = "lbJtysdh";
            this.lbJtysdh.Size = new System.Drawing.Size(109, 20);
            this.lbJtysdh.TabIndex = 34;
            this.lbJtysdh.Text = "联系电话 :";
            // 
            // tbJtys
            // 
            this.tbJtys.Location = new System.Drawing.Point(404, 105);
            this.tbJtys.Name = "tbJtys";
            this.tbJtys.Size = new System.Drawing.Size(200, 30);
            this.tbJtys.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(229, 108);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(169, 20);
            this.label15.TabIndex = 32;
            this.label15.Text = "家庭(责任)医生 :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(52, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(149, 20);
            this.label14.TabIndex = 31;
            this.label14.Text = "家庭医生团队 :";
            // 
            // tbJglxfs
            // 
            this.tbJglxfs.Location = new System.Drawing.Point(233, 69);
            this.tbJglxfs.Name = "tbJglxfs";
            this.tbJglxfs.Size = new System.Drawing.Size(240, 30);
            this.tbJglxfs.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(179, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "建档机构联系电话:";
            // 
            // tbqita
            // 
            this.tbqita.Location = new System.Drawing.Point(989, 29);
            this.tbqita.Name = "tbqita";
            this.tbqita.ReadOnly = true;
            this.tbqita.Size = new System.Drawing.Size(148, 30);
            this.tbqita.TabIndex = 27;
            // 
            // ckhb8
            // 
            this.ckhb8.AutoSize = true;
            this.ckhb8.Location = new System.Drawing.Point(872, 33);
            this.ckhb8.Name = "ckhb8";
            this.ckhb8.Size = new System.Drawing.Size(108, 24);
            this.ckhb8.TabIndex = 26;
            this.ckhb8.Text = "其他疾病";
            this.ckhb8.UseVisualStyleBackColor = true;
            // 
            // ckhb7
            // 
            this.ckhb7.AutoSize = true;
            this.ckhb7.Location = new System.Drawing.Point(773, 32);
            this.ckhb7.Name = "ckhb7";
            this.ckhb7.Size = new System.Drawing.Size(88, 24);
            this.ckhb7.TabIndex = 25;
            this.ckhb7.Text = "职业病";
            this.ckhb7.UseVisualStyleBackColor = true;
            // 
            // ckhb6
            // 
            this.ckhb6.AutoSize = true;
            this.ckhb6.Location = new System.Drawing.Point(692, 33);
            this.ckhb6.Name = "ckhb6";
            this.ckhb6.Size = new System.Drawing.Size(68, 24);
            this.ckhb6.TabIndex = 24;
            this.ckhb6.Text = "哮喘";
            this.ckhb6.UseVisualStyleBackColor = true;
            // 
            // ckhb5
            // 
            this.ckhb5.AutoSize = true;
            this.ckhb5.Location = new System.Drawing.Point(594, 32);
            this.ckhb5.Name = "ckhb5";
            this.ckhb5.Size = new System.Drawing.Size(88, 24);
            this.ckhb5.TabIndex = 23;
            this.ckhb5.Text = "冠心病";
            this.ckhb5.UseVisualStyleBackColor = true;
            // 
            // ckhb4
            // 
            this.ckhb4.AutoSize = true;
            this.ckhb4.Location = new System.Drawing.Point(494, 33);
            this.ckhb4.Name = "ckhb4";
            this.ckhb4.Size = new System.Drawing.Size(88, 24);
            this.ckhb4.TabIndex = 22;
            this.ckhb4.Text = "脑卒中";
            this.ckhb4.UseVisualStyleBackColor = true;
            // 
            // ckhb3
            // 
            this.ckhb3.AutoSize = true;
            this.ckhb3.Location = new System.Drawing.Point(398, 33);
            this.ckhb3.Name = "ckhb3";
            this.ckhb3.Size = new System.Drawing.Size(88, 24);
            this.ckhb3.TabIndex = 21;
            this.ckhb3.Text = "糖尿病";
            this.ckhb3.UseVisualStyleBackColor = true;
            // 
            // ckhb2
            // 
            this.ckhb2.AutoSize = true;
            this.ckhb2.Location = new System.Drawing.Point(298, 33);
            this.ckhb2.Name = "ckhb2";
            this.ckhb2.Size = new System.Drawing.Size(88, 24);
            this.ckhb2.TabIndex = 20;
            this.ckhb2.Text = "高血压";
            this.ckhb2.UseVisualStyleBackColor = true;
            // 
            // ckhb1
            // 
            this.ckhb1.AutoSize = true;
            this.ckhb1.Location = new System.Drawing.Point(233, 33);
            this.ckhb1.Name = "ckhb1";
            this.ckhb1.Size = new System.Drawing.Size(48, 24);
            this.ckhb1.TabIndex = 19;
            this.ckhb1.Text = "无";
            this.ckhb1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(102, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "患病情况:";
            // 
            // btnPhoto
            // 
            this.btnPhoto.Location = new System.Drawing.Point(1274, 251);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.Size = new System.Drawing.Size(113, 41);
            this.btnPhoto.TabIndex = 149;
            this.btnPhoto.Text = "拍照";
            this.btnPhoto.UseVisualStyleBackColor = true;
            this.btnPhoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // RecordBaseInfoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1460, 680);
            this.Controls.Add(this.btnPhoto);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tbRecordID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "RecordBaseInfoForm";
            this.Text = "RecordBaseInfoForm";
            this.Load += new System.EventHandler(this.RecordBaseInfoForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            this.Model.CreateDate = this.dtpBuildDate.Value ;
            new RecordsBaseInfoBLL().Update(this.Model);

            HealthRecordsinfoBLL HealthBLL = new HealthRecordsinfoBLL();
            if (!HealthBLL.Exists(this.HealthModel.ID))
            {
                HealthBLL.Add(this.HealthModel);
            }
            else
            {
                HealthBLL.Update(this.HealthModel);
            }
    
            return true;
        }

        private void tbPhone_TextChanged(object sender, EventArgs e)
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

        public void UpdataToModel()
        {
            if (!string.IsNullOrEmpty(this.cmbVillage.Text)) //村
            {
                this.Model.VillageName = this.cmbVillage.Text;
            }
            if (!string.IsNullOrEmpty(this.cbmBuildUnit.Text)) //建档单位
            {
                this.Model.CreateUnitName = this.cbmBuildUnit.Text;
            }
            if (!string.IsNullOrEmpty(this.cmbBuildMan.Text)) //建档人
            {
                this.Model.CreateMenName = this.cmbBuildMan.Text;
            }
            if (!string.IsNullOrEmpty(this.cbmDoctor.Text)) //责任医生
            {
                this.Model.Doctor = this.cbmDoctor.Text;
            }
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public HealthRecordsinfoModel HealthModel { get; set; }

        public string SaveDataInfo { get; set; }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            Assembly sampleAssembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + @"\" + "PhotoGraph.exe");

            if (sampleAssembly != null)
            {
                Form loadForm = (Form)sampleAssembly.CreateInstance("PhotoGraph.FrmCameraB");
                string path = PhotosPath + "Base//";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path=path+ this.Model.IDCardNo +  ".jpg";
                PropertyInfo property = loadForm.GetType().GetProperty("SavePath", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if (property != null)
                {
                    property.SetValue(loadForm, path, null);
                }

                loadForm.ShowDialog();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbmBuildUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.bds_SysUser != null)
            {
                this.bds_SysUser.Filter = "VillageID = " + cbmBuildUnit.SelectedValue.ToString();
            }
            if (this.bds_Doctor != null)
            {
                this.bds_Doctor.Filter = "VillageID = " + cbmBuildUnit.SelectedValue.ToString();
            }
        }
    }
}

