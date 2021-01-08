using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup.OldPeople
{
    using KangShuoTech.Utilities.Common;
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.IO;
    using System.Data;
    using System.Drawing;
    using AxHWPenSignLib;
    using System.Configuration;

    public class OldPeopleInfoForm : Form, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        public decimal account;
        private Button btnCancel;
        private Button btnOK;
        private ComboBox cbAct;
        private ComboBox cbDinner;
        private ComboBox cbDressing;
        private ComboBox cbGromming;
        private ComboBox cbTolet;
        private IContainer components;
        private object cp_elderSelf;
        private OlderSelfCareabilityModel elderSelf;
        private GroupBox groupBox1;
        private Label label1;
        private Label label10;
        private Label label13;
        private Label label16;
        private Label label19;
        private Label label2;
        private Label label4;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tbActivity;
        private TextBox tbDinner;
        private TextBox tbDoctor;
        private TextBox tbDressing;
        private TextBox tbGroming;
        private TextBox tbTolet;
        private DateTimePicker dtpNextF;
        private Label label3;
        private Label label6;
        private DateTimePicker dtpCheckdate;
        private TextBox tbTotal;
        private bool flagdelte = true;
        private TextBox txbNextVisitAim;
        private Label label7;
        private LinkLabel lkYs;
        private PictureBox picSignYs;
        private Label label69;
        private string visitdate;
        private string SignDoc = "";//医生签名
        private int HW_eOk = 0;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/OldVisit/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "OldVisit//"; //签名保存路径

        public OldPeopleInfoForm()
        {
            this.InitializeComponent();
            this.InitCombox();

            this.EveryThingIsOk = false;
        }

        public OldPeopleInfoForm(RecordsBaseInfoModel p_model)
        {
            this.InitializeComponent();
            this.InitCombox();
            this.EveryThingIsOk = false;
            this.Model = p_model;
            this.btnOK.Visible = true;
            this.btnCancel.Visible = true;
            OldPeopleInfoFactory.ID = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.elderSelf.FollowUpDate = new DateTime?(this.dtpCheckdate.Value.Date);
            this.elderSelf.NextFollowUpDate = new DateTime?(this.dtpNextF.Value.Date);
            this.UpdataToModel();
            if (this.elderSelf.TotalScore.HasValue)
            {
                this.account = this.elderSelf.TotalScore.Value;
            }
            if (GlbTools.IsChanged(this.cp_elderSelf, this.elderSelf, new string[] { "VisitDate", "NextfollowupDate" }))
            {
                OlderSelfCareabilityBLL olderSelfCareabilityBLL = new OlderSelfCareabilityBLL();
                string strWhere = string.Format("IDCardNo='{0}' and FollowupDate='{1}' ", this.Model.IDCardNo, this.dtpCheckdate.Value.ToString());
                OlderSelfCareabilityModel selfModel = olderSelfCareabilityBLL.CheckModel(strWhere);
                if (selfModel != null)
                {
                    this.elderSelf.ID = selfModel.ID;
                    olderSelfCareabilityBLL.Update(this.elderSelf);
                }
                else
                {
                    olderSelfCareabilityBLL.Add(this.elderSelf);
                }
            }
            base.DialogResult = DialogResult.OK;
        }

        private void cb_SelectedValueChanged(object sender, EventArgs e)
        {
            //0M;
            decimal num = (((((decimal) this.cbAct.SelectedValue) + ((this.cbDinner.SelectedValue.ToString() == "2") ? 0M : ((decimal) this.cbDinner.SelectedValue))) + 
                ((this.cbDressing.SelectedValue.ToString() == "2") ? 0M : ((decimal) this.cbDressing.SelectedValue))) + ((decimal) this.cbGromming.SelectedValue)) + ((decimal) this.cbTolet.SelectedValue);
            this.elderSelf.Activity = new decimal?((decimal) this.cbAct.SelectedValue);
            this.elderSelf.Dine = new decimal?((decimal) this.cbDinner.SelectedValue);
            this.elderSelf.Dressing = new decimal?((decimal) this.cbDressing.SelectedValue);
            this.elderSelf.Groming = new decimal?((decimal) this.cbGromming.SelectedValue);
            this.elderSelf.Tolet = new decimal?((decimal) this.cbTolet.SelectedValue);
            this.account = num;
            this.tbTotal.Text = num.ToString();
        }

        private void CbSimpleBind(ComboBox cb, string member)
        {
            cb.DataBindings.Add("SelectedValue", this.elderSelf, member, true, DataSourceUpdateMode.Never);
            cb.SelectedValueChanged += new EventHandler(this.cb_SelectedValueChanged);
        }

        public ChildFormStatus CheckErrorInput()
        {
            this.SaveDataInfo = "";
            bool flag = false;
            if (this.dtpNextF.Value.Date < this.dtpCheckdate.Value.Date)
            {
                flag = true;
                this.SaveDataInfo = "下次随访日期不能小于当前的随访日期！\r\n";
            }
            if (this.dtpCheckdate.Value.Date > DateTime.Today)
            {
                flag = true;
                this.SaveDataInfo = "随访日期不能晚于当前日期!\r\n";
            }
            if (!flag)
            {
                return ChildFormStatus.NoErrorInput;
            }
            return ChildFormStatus.HasErrorInput;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmElerInfo_Load(object sender, EventArgs e)
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

        private void InitCombox()
        {
            this.tbDinner.Text = "进餐：使用餐具将饭菜送入口、咀嚼、吞咽等活动。\r\n程度等级：\r\n1.\t可自理：独立完成，评分0\r\n2.\t轻度依赖：-----，评分0\r\n3.\t中度依赖：需要协助，如切碎、搅拌食物等，评分3\r\n4.\t不能自理：完全需要帮助，评分5";
            BindingList<ItemDictonaryModel<decimal>> list = new BindingList<ItemDictonaryModel<decimal>> {
                new ItemDictonaryModel<decimal>("可自理", 0M),
                new ItemDictonaryModel<decimal>("轻度依赖", 2M),
                new ItemDictonaryModel<decimal>("中度依赖", 3M),
                new ItemDictonaryModel<decimal>("不能自理", 5M)
            };
            this.cbDinner.DisplayMember = "DISPLAYMEMBER";
            this.cbDinner.ValueMember = "VALUEMEMBER";
            this.cbDinner.DataSource = list;
            this.tbGroming.Text = "梳洗：梳头、洗脸、刷牙、剃须洗澡等活动\r\n程度等级：\r\n1.\t可自理：独立完成，评分0\r\n2.\t轻度依赖：能独立地洗头、梳头、洗脸、刷牙、剃须等；洗澡需要协助，评分1\r\n3.\t中度依赖：在协助下和适当的时间内，能完成部分梳洗活动，评分3\r\n4.\t不能自理：完全需要帮助，评分7";
            BindingList<ItemDictonaryModel<decimal>> list2 = new BindingList<ItemDictonaryModel<decimal>> {
                new ItemDictonaryModel<decimal>("可自理", 0M),
                new ItemDictonaryModel<decimal>("轻度依赖", 1M),
                new ItemDictonaryModel<decimal>("中度依赖", 3M),
                new ItemDictonaryModel<decimal>("不能自理", 7M)
            };
            this.cbGromming.DisplayMember = "DISPLAYMEMBER";
            this.cbGromming.ValueMember = "VALUEMEMBER";
            this.cbGromming.DataSource = list2;
            this.tbDressing.Text = "穿衣：穿衣裤、袜子、鞋子等活动\r\n程度等级：\r\n1.\t可自理：独立完成，评分0\r\n2.\t轻度依赖：----，评分0\r\n3.\t中度依赖：需要协助，在适当的时间内完成部分穿衣，评分3\r\n4.\t不能自理：完全需要帮助，评分5";
            BindingList<ItemDictonaryModel<decimal>> list3 = new BindingList<ItemDictonaryModel<decimal>> {
                new ItemDictonaryModel<decimal>("可自理", 0M),
                new ItemDictonaryModel<decimal>("轻度依赖", 2M),
                new ItemDictonaryModel<decimal>("中度依赖", 3M),
                new ItemDictonaryModel<decimal>("不能自理", 5M)
            };
            this.cbDressing.DisplayMember = "DISPLAYMEMBER";
            this.cbDressing.ValueMember = "VALUEMEMBER";
            this.cbDressing.DataSource = list3;
            this.tbTolet.Text = "如厕：小便、大便等活动及自控\r\n程度等级：\r\n1.\t可自理：不需协助，可自控，评分0\r\n2.\t轻度依赖：偶尔失禁，但基本上能如厕或使用便具，评分1\r\n3.\t中度依赖：经常失禁，在很多提示和协助下尚能如厕或使用便具，评分5\r\n4.\t不能自理：完全失禁，完全需要帮助，评分10";
            BindingList<ItemDictonaryModel<decimal>> list4 = new BindingList<ItemDictonaryModel<decimal>> {
                new ItemDictonaryModel<decimal>("可自理", 0M),
                new ItemDictonaryModel<decimal>("轻度依赖", 1M),
                new ItemDictonaryModel<decimal>("中度依赖", 5M),
                new ItemDictonaryModel<decimal>("不能自理", 10M)
            };
            this.cbTolet.DisplayMember = "DISPLAYMEMBER";
            this.cbTolet.ValueMember = "VALUEMEMBER";
            this.cbTolet.DataSource = list4;
            this.tbActivity.Text = "活动：站立、室内行走、上下楼梯、户外活动\r\n程度等级：\r\n1.\t可自理：独立完成所有活动，评分0\r\n2.\t轻度依赖：借助较小的外力或辅助装置能完成站立、行走、上下楼梯等，评分1\r\n3.\t中度依赖：借助较大的外力才能完成站立、行走，不能上下楼梯，评分5\r\n4.\t不能自理：卧床不起，活动完全需要帮助，评分10";
            BindingList<ItemDictonaryModel<decimal>> list5 = new BindingList<ItemDictonaryModel<decimal>> {
                new ItemDictonaryModel<decimal>("可自理", 0M),
                new ItemDictonaryModel<decimal>("轻度依赖", 1M),
                new ItemDictonaryModel<decimal>("中度依赖", 5M),
                new ItemDictonaryModel<decimal>("不能自理", 10M)
            };
            this.cbAct.DisplayMember = "DISPLAYMEMBER";
            this.cbAct.ValueMember = "VALUEMEMBER";
            this.cbAct.DataSource = list5;
        }

        public void InitEveryThing()
        {
            if (OldPeopleInfoFactory.ID == 0)
            {
                this.flagdelte = false;
                this.elderSelf = new OlderSelfCareabilityBLL().GetModel(this.Model.IDCardNo);
                this.dtpCheckdate.Value = DateTime.Today.Date;
                this.dtpNextF.Value = DateTime.Today.AddYears(1);
            }
            else
            {
                this.elderSelf = new OlderSelfCareabilityBLL().GetModelID(OldPeopleInfoFactory.ID);
                if (this.elderSelf.FollowUpDate.HasValue)
                {
                    this.dtpCheckdate.Value = this.elderSelf.FollowUpDate.Value;
                    this.visitdate = this.elderSelf.FollowUpDate.ToString();
                }
                if (this.elderSelf.NextFollowUpDate.HasValue)
                {
                    this.dtpNextF.Value = this.elderSelf.NextFollowUpDate.Value;
                }
                else
                {
                    this.dtpNextF.Value = DateTime.Today.AddYears(1);
                }
            }
            if (this.elderSelf == null)
            {
                OlderSelfCareabilityModel olderSelfCareabilityModel = new OlderSelfCareabilityModel
                {
                    IDCardNo = this.Model.IDCardNo,
                    RecordID = this.Model.RecordID,
                    FollowUpDoctor = this.Model.Doctor,
                    Dine = 0,
                    Groming = 0,
                    Dressing = 0,
                    Tolet = 0,
                    Activity = 0,
                    CreatedDate = new DateTime?(DateTime.Today),
                    TotalScore=0
                };
                this.elderSelf = olderSelfCareabilityModel;
                this.elderSelf.CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
            }
            else
            {
                OldPeopleInfoFactory.ID = elderSelf.ID;
                this.elderSelf.LastUpDateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.elderSelf.LastUpDateDate = new DateTime?(DateTime.Today);
            }
            this.cp_elderSelf = GlbTools.DeepCopy(this.elderSelf);
            if (string.IsNullOrEmpty(this.elderSelf.FollowUpDoctor))
            {
                this.elderSelf.FollowUpDoctor = ConfigHelper.GetNode("doctorName");
            }
            this.tbDoctor.DataBindings.Add("TEXT", this.elderSelf, "FollowUpDoctor", false, DataSourceUpdateMode.OnPropertyChanged);

            if (string.IsNullOrEmpty(this.elderSelf.NextVisitAim))
            {
                this.elderSelf.NextVisitAim = "低盐饮食，预防高血压";
            }
            this.txbNextVisitAim.DataBindings.Add("TEXT", this.elderSelf, "NextVisitAim", false, DataSourceUpdateMode.OnPropertyChanged);
            this.CbSimpleBind(this.cbDinner, "DINE");
            this.CbSimpleBind(this.cbGromming, "Groming");
            this.CbSimpleBind(this.cbDressing, "Dressing");
            this.CbSimpleBind(this.cbTolet, "Tolet");
            this.CbSimpleBind(this.cbAct, "Activity");
            if (this.elderSelf.TotalScore.HasValue)
            {
                this.tbTotal.Text = this.elderSelf.TotalScore.Value.ToString();
            }

            //签名初始化
            this.SignDoc = string.Format("{0}{1}_{2}_Asses.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpCheckdate.Value).ToString("yyyyMMdd"));
            if (File.Exists(this.SignDoc))
            {
                Image imgeb = Image.FromFile(SignDoc);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picSignYs.Image = bmp;
                picSignYs.Show();
                imgeb.Dispose();
                this.lkYs.Enabled = true;
                picSignYs.BackColor = Color.White;
            }

            MustChoose();
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

        private void MustChoose()
        {
            DataSet dsrequire = new DataSet();
            dsrequire = new RequireBLL().GetList("TabName = '老年人随访' and Comment = '健康评估' ");
            DataTable dt = dsrequire.Tables[0];
            DataTable older = new OlderSelfCareabilityBLL().GetList("IDCardNo ='" + Model.IDCardNo + "'").Tables[0];
            bool flag = (older.Rows.Count > 0) ? true : false;
            if (flag)
            {
                DataRow row = older.Rows[0];
                foreach (DataRow item in dt.Rows)
                {
                    if (item["Isrequired"].ToString() == "1")
                    {
                        switch (item["ChinName"].ToString())
                        {
                            case "进餐":
                                if (string.IsNullOrEmpty(row["Dine"].ToString()))
                                {
                                    this.label10.Text = "*进    餐:";
                                    this.label10.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label10.Text = "进    餐:";
                                    this.label10.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                                break;
                            case "梳洗":
                                if (string.IsNullOrEmpty(row["Groming"].ToString()))
                                {
                                    this.label13.Text = "*梳    洗:";
                                    this.label13.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label13.Text = "梳    洗:";
                                    this.label13.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "穿衣":
                                if (string.IsNullOrEmpty(row["Dressing"].ToString()))
                                {
                                    this.label16.Text = "*穿    衣:";
                                    this.label16.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label16.Text = "穿    衣:";
                                    this.label16.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "如厕":
                                if (string.IsNullOrEmpty(row["Tolet"].ToString()))
                                {
                                    this.label19.Text = "*如    厕:";
                                    this.label19.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label19.Text = "如    厕:";
                                    this.label19.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "活动":
                                if (string.IsNullOrEmpty(row["Activity"].ToString()))
                                {
                                    this.label1.Text = "*活    动:";
                                    this.label1.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label1.Text = "活    动:";
                                    this.label1.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "随访医生":
                                if (string.IsNullOrEmpty(row["FollowUpDoctor"].ToString()))
                                {
                                    this.label4.Text = "*随访医生:";
                                    this.label4.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label4.Text = "随访医生:";
                                    this.label4.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "总得分":
                                if (string.IsNullOrEmpty(row["TotalScore"].ToString()))
                                {
                                    this.label2.Text = "*总得分:";
                                    this.label2.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label2.Text = "总得分:";
                                    this.label2.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "随访日期":
                                if (string.IsNullOrEmpty(row["FollowUpDate"].ToString()))
                                {
                                    this.label6.Text = "*随访日期:";
                                    this.label6.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label6.Text = "随访日期:";
                                    this.label6.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "下次随访目标":
                                if (string.IsNullOrEmpty(row["NextVisitAim"].ToString()))
                                {
                                    this.label7.Text = "*下次随访目标:";
                                    this.label7.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label7.Text = "下次随访目标:";
                                    this.label7.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "下次随访日期":
                                if (string.IsNullOrEmpty(row["NextfollowUpDate"].ToString()))
                                {
                                    this.label3.Text = "*下次随访日期:";
                                    this.label3.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label3.Text = "下次随访日期:";
                                    this.label3.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "医生签名":
                                if (!File.Exists(this.SignDoc))
                                {
                                    this.label69.Text = "*医生签名:";
                                    this.label69.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label69.Text = "医生签名:";
                                    this.label69.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            default: break;
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (item["Isrequired"].ToString() == "1")
                    {
                        switch (item["ChinName"].ToString())
                        {
                            case "进餐":
                                this.label10.Text = "*进    餐:";
                                this.label10.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "梳洗":
                                this.label13.Text = "*梳    洗:";
                                this.label13.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "穿衣":
                                this.label16.Text = "*穿    衣:";
                                this.label16.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "如厕":
                                this.label19.Text = "*如    厕:";
                                this.label19.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "活动":
                                this.label1.Text = "*活    动:";
                                this.label1.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "随访医生":
                                this.label4.Text = "*随访医生:";
                                this.label4.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "总得分":
                                this.label2.Text = "*总得分:";
                                this.label2.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "随访日期":
                                this.label6.Text = "*随访日期:";
                                this.label6.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "下次随访目标":
                                this.label7.Text = "*下次随访目标:";
                                this.label7.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "下次随访日期":
                                this.label3.Text = "*下次随访日期:";
                                this.label3.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "医生签名":
                                if (!File.Exists(this.SignDoc))
                                {
                                    this.label69.Text = "*医生签名:";
                                    this.label69.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label69.Text = "医生签名:";
                                    this.label69.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            default: break;
                        }
                    }
                }
            }

        }
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lkYs = new System.Windows.Forms.LinkLabel();
            this.picSignYs = new System.Windows.Forms.PictureBox();
            this.label69 = new System.Windows.Forms.Label();
            this.txbNextVisitAim = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpCheckdate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNextF = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTolet = new System.Windows.Forms.TextBox();
            this.tbDressing = new System.Windows.Forms.TextBox();
            this.tbGroming = new System.Windows.Forms.TextBox();
            this.cbTolet = new System.Windows.Forms.ComboBox();
            this.cbDinner = new System.Windows.Forms.ComboBox();
            this.cbDressing = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbGromming = new System.Windows.Forms.ComboBox();
            this.tbDinner = new System.Windows.Forms.TextBox();
            this.cbAct = new System.Windows.Forms.ComboBox();
            this.tbActivity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lkYs);
            this.groupBox1.Controls.Add(this.picSignYs);
            this.groupBox1.Controls.Add(this.label69);
            this.groupBox1.Controls.Add(this.txbNextVisitAim);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpCheckdate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.tbDoctor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpNextF);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbTotal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(70, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1393, 656);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lkYs
            // 
            this.lkYs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lkYs.AutoSize = true;
            this.lkYs.Location = new System.Drawing.Point(1203, 527);
            this.lkYs.Name = "lkYs";
            this.lkYs.Size = new System.Drawing.Size(89, 20);
            this.lkYs.TabIndex = 256;
            this.lkYs.TabStop = true;
            this.lkYs.Text = "重置签名";
            this.lkYs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkYs_LinkClicked);
            // 
            // picSignYs
            // 
            this.picSignYs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignYs.Location = new System.Drawing.Point(1003, 512);
            this.picSignYs.Name = "picSignYs";
            this.picSignYs.Size = new System.Drawing.Size(192, 54);
            this.picSignYs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignYs.TabIndex = 254;
            this.picSignYs.TabStop = false;
            this.picSignYs.Click += new System.EventHandler(this.picSignYs_Click);
            // 
            // label69
            // 
            this.label69.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(898, 531);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(99, 20);
            this.label69.TabIndex = 253;
            this.label69.Text = "医生签名:";
            // 
            // txbNextVisitAim
            // 
            this.txbNextVisitAim.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txbNextVisitAim.ForeColor = System.Drawing.Color.Black;
            this.txbNextVisitAim.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txbNextVisitAim.Location = new System.Drawing.Point(156, 576);
            this.txbNextVisitAim.MaxLength = 20;
            this.txbNextVisitAim.Name = "txbNextVisitAim";
            this.txbNextVisitAim.Size = new System.Drawing.Size(339, 30);
            this.txbNextVisitAim.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F);
            this.label7.Location = new System.Drawing.Point(12, 583);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 20);
            this.label7.TabIndex = 140;
            this.label7.Text = "下次随访目标:";
            // 
            // dtpCheckdate
            // 
            this.dtpCheckdate.Location = new System.Drawing.Point(666, 531);
            this.dtpCheckdate.Name = "dtpCheckdate";
            this.dtpCheckdate.Size = new System.Drawing.Size(180, 30);
            this.dtpCheckdate.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F);
            this.label6.Location = new System.Drawing.Point(561, 539);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 138;
            this.label6.Text = "随访日期:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1181, 608);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 34);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1068, 608);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 34);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "完成";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbDoctor
            // 
            this.tbDoctor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDoctor.ForeColor = System.Drawing.Color.Black;
            this.tbDoctor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbDoctor.Location = new System.Drawing.Point(156, 535);
            this.tbDoctor.MaxLength = 20;
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(172, 30);
            this.tbDoctor.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F);
            this.label4.Location = new System.Drawing.Point(52, 541);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 133;
            this.label4.Text = "随访医生:";
            // 
            // dtpNextF
            // 
            this.dtpNextF.Location = new System.Drawing.Point(666, 570);
            this.dtpNextF.Name = "dtpNextF";
            this.dtpNextF.Size = new System.Drawing.Size(180, 30);
            this.dtpNextF.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(521, 579);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 131;
            this.label3.Text = "下次随访日期:";
            // 
            // tbTotal
            // 
            this.tbTotal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTotal.ForeColor = System.Drawing.Color.Black;
            this.tbTotal.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbTotal.Location = new System.Drawing.Point(414, 535);
            this.tbTotal.MaxLength = 3;
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(81, 30);
            this.tbTotal.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(337, 539);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 129;
            this.label2.Text = "总得分:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.40888F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.33259F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.03118F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.12448F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.90042F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.06639F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbTolet, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbDressing, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbGroming, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbTolet, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbDinner, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbDressing, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label19, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbGromming, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbDinner, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbAct, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbActivity, 2, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 49);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1348, 452);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(52, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 128;
            this.label1.Text = "活    动:";
            // 
            // tbTolet
            // 
            this.tbTolet.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.tbTolet, 4);
            this.tbTolet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTolet.Font = new System.Drawing.Font("宋体", 12F);
            this.tbTolet.ForeColor = System.Drawing.Color.Black;
            this.tbTolet.Location = new System.Drawing.Point(378, 274);
            this.tbTolet.Multiline = true;
            this.tbTolet.Name = "tbTolet";
            this.tbTolet.ReadOnly = true;
            this.tbTolet.Size = new System.Drawing.Size(966, 83);
            this.tbTolet.TabIndex = 126;
            // 
            // tbDressing
            // 
            this.tbDressing.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.tbDressing, 4);
            this.tbDressing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDressing.Font = new System.Drawing.Font("宋体", 12F);
            this.tbDressing.ForeColor = System.Drawing.Color.Black;
            this.tbDressing.Location = new System.Drawing.Point(378, 184);
            this.tbDressing.Multiline = true;
            this.tbDressing.Name = "tbDressing";
            this.tbDressing.ReadOnly = true;
            this.tbDressing.Size = new System.Drawing.Size(966, 83);
            this.tbDressing.TabIndex = 125;
            // 
            // tbGroming
            // 
            this.tbGroming.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.tbGroming, 4);
            this.tbGroming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbGroming.Font = new System.Drawing.Font("宋体", 12F);
            this.tbGroming.ForeColor = System.Drawing.Color.Black;
            this.tbGroming.Location = new System.Drawing.Point(378, 94);
            this.tbGroming.Multiline = true;
            this.tbGroming.Name = "tbGroming";
            this.tbGroming.ReadOnly = true;
            this.tbGroming.Size = new System.Drawing.Size(966, 83);
            this.tbGroming.TabIndex = 124;
            // 
            // cbTolet
            // 
            this.cbTolet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbTolet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTolet.FormattingEnabled = true;
            this.cbTolet.Location = new System.Drawing.Point(158, 305);
            this.cbTolet.Name = "cbTolet";
            this.cbTolet.Size = new System.Drawing.Size(183, 28);
            this.cbTolet.TabIndex = 3;
            // 
            // cbDinner
            // 
            this.cbDinner.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDinner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDinner.FormattingEnabled = true;
            this.cbDinner.Location = new System.Drawing.Point(158, 35);
            this.cbDinner.Name = "cbDinner";
            this.cbDinner.Size = new System.Drawing.Size(183, 28);
            this.cbDinner.TabIndex = 0;
            // 
            // cbDressing
            // 
            this.cbDressing.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDressing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDressing.FormattingEnabled = true;
            this.cbDressing.Location = new System.Drawing.Point(158, 215);
            this.cbDressing.Name = "cbDressing";
            this.cbDressing.Size = new System.Drawing.Size(183, 28);
            this.cbDressing.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 15F);
            this.label19.Location = new System.Drawing.Point(52, 305);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(99, 20);
            this.label19.TabIndex = 111;
            this.label19.Text = "如    厕:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 15F);
            this.label16.Location = new System.Drawing.Point(52, 215);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 20);
            this.label16.TabIndex = 111;
            this.label16.Text = "穿    衣:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F);
            this.label10.Location = new System.Drawing.Point(52, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "进    餐:";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F);
            this.label13.Location = new System.Drawing.Point(52, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 20);
            this.label13.TabIndex = 100;
            this.label13.Text = "梳    洗:";
            // 
            // cbGromming
            // 
            this.cbGromming.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbGromming.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGromming.FormattingEnabled = true;
            this.cbGromming.Location = new System.Drawing.Point(158, 125);
            this.cbGromming.Name = "cbGromming";
            this.cbGromming.Size = new System.Drawing.Size(183, 28);
            this.cbGromming.TabIndex = 1;
            // 
            // tbDinner
            // 
            this.tbDinner.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.tbDinner, 4);
            this.tbDinner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDinner.Font = new System.Drawing.Font("宋体", 12F);
            this.tbDinner.ForeColor = System.Drawing.Color.Black;
            this.tbDinner.Location = new System.Drawing.Point(378, 4);
            this.tbDinner.Multiline = true;
            this.tbDinner.Name = "tbDinner";
            this.tbDinner.ReadOnly = true;
            this.tbDinner.Size = new System.Drawing.Size(966, 83);
            this.tbDinner.TabIndex = 97;
            // 
            // cbAct
            // 
            this.cbAct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbAct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAct.FormattingEnabled = true;
            this.cbAct.Location = new System.Drawing.Point(158, 396);
            this.cbAct.Name = "cbAct";
            this.cbAct.Size = new System.Drawing.Size(183, 28);
            this.cbAct.TabIndex = 4;
            // 
            // tbActivity
            // 
            this.tbActivity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.tbActivity, 4);
            this.tbActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbActivity.Font = new System.Drawing.Font("宋体", 12F);
            this.tbActivity.Location = new System.Drawing.Point(378, 364);
            this.tbActivity.Multiline = true;
            this.tbActivity.Name = "tbActivity";
            this.tbActivity.ReadOnly = true;
            this.tbActivity.Size = new System.Drawing.Size(966, 84);
            this.tbActivity.TabIndex = 129;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F);
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1379, 20);
            this.label5.TabIndex = 137;
            this.label5.Text = "该表为自评表,根据下表中5个方面进行评估,将各方面判断评分汇总后,0～3分者为可自理;4～8分者为轻度依赖;9～18分者为中度依赖;>19分者为不能自理。";
            // 
            // OldPeopleInfoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OldPeopleInfoForm";
            this.Text = "FrmElerInfo";
            this.Load += new System.EventHandler(this.FrmElerInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {

        }

        public bool SaveModelToDB()
        {
            this.elderSelf.FollowUpDate = new DateTime?(this.dtpCheckdate.Value.Date);
            this.elderSelf.NextFollowUpDate = new DateTime?(this.dtpNextF.Value.Date);
            if (GlbTools.IsChanged(this.cp_elderSelf, this.elderSelf, new string[] { "VisitDate", "NextfollowupDate" }))
            {
                OlderSelfCareabilityBLL older_selfcareability = new OlderSelfCareabilityBLL();
                OlderSelfCareabilityModel selfModel = older_selfcareability.CheckModel(string.Format("IDCardNo='{0}' and FollowUpDate='{1}'", this.elderSelf.IDCardNo, this.dtpCheckdate.Value.ToString()));
                if (selfModel != null)
                {
                    if (OldPeopleInfoFactory.ID > 0 && this.visitdate == this.elderSelf.FollowUpDate.ToString())
                    {
                        OldPeopleInfoFactory.ID = selfModel.ID;
                        this.elderSelf.ID = selfModel.ID;
                        older_selfcareability.Update(this.elderSelf);
                    }
                    else
                    {
                        DialogResult result = DialogResult.OK;
                        result = MessageBox.Show("此日期下已有评估信息，是否进行修改？", "提示", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            if (this.flagdelte)
                            {
                                older_selfcareability.Delete(this.elderSelf.ID);
                            }
                            OldPeopleInfoFactory.ID = selfModel.ID;
                            this.elderSelf.ID = selfModel.ID;
                            older_selfcareability.Update(this.elderSelf);
                        }
                        else
                        {
                            OldPeopleInfoFactory.ID = -1;
                            return true;
                        }
                    }

                }
                else
                {
                    if (this.flagdelte)//随访查询中修改的随访日期不存在时，需要删除当前这笔数据
                    {
                        older_selfcareability.Delete(this.elderSelf.ID);
                    }
                    OldPeopleInfoFactory.ID = older_selfcareability.Add(this.elderSelf);
                }
            }
            string NewSignDoc = string.Format("{0}{1}_{2}_Asses.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpCheckdate.Value).ToString("yyyyMMdd"));

            return true;
        }
        private void savepicture(AxHWPenSign axHWPenSign, PictureBox pBoxImg, string OldSign, string NewSign)
        {
            try
            {
                if (pBoxImg.Image==null)
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
                        //pBoxImg.Image = null;
                    }
                    if (NewSign != OldSign)
                    {
                        if (File.Exists(OldSign))
                        {
                            File.Copy(OldSign, NewSign, true);
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
        public void UpdataToModel()
        {
            decimal num;
            if (!string.IsNullOrEmpty(this.tbTotal.Text) && decimal.TryParse(this.tbTotal.Text, out num))
            {
                this.elderSelf.TotalScore = new decimal?(decimal.Parse(this.tbTotal.Text));
            }
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }
        public int IDPerson { get; set; }
        
        private void lkYs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_Asses", picSignYs);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void picSignYs_Click(object sender, EventArgs e)
        {
            Sign("_Asses", picSignYs);
        }
        private void Sign(string DaySign, PictureBox picture)
        {
            FingerPrint.SignForm loadForm = new FingerPrint.SignForm();
            string date = dtpCheckdate.Value.ToString("yyyyMMdd");
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
                    string date = dtpCheckdate.Value.ToString("yyyyMMdd");
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

