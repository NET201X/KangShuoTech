using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace ArchiveInfo
{
    using CommonControl;
    
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class FamilyInfoForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<RecordsFamilyInfoModel> bindMgr;
        private IContainer components;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private Panel panel1;
        private Button btnCancel;
        private GroupBox groupBox2;
        private Button btnDel;
        private DataGridView dgv_User;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private TextBox tbRelation;
        private TextBox tbLeaderName;
        private ComboBox cbLiveStatus;
        private Panel panel7;
        private RadioButton rdNoDBL;
        private RadioButton rdYesDBH;
        private Panel panel6;
        private Label label25;
        private TextBox tbSalt;
        private Label label24;
        private Panel panel5;
        private Label label23;
        private TextBox tbOil;
        private Panel panel4;
        private Label label22;
        private TextBox tbIncomeMonth;
        private Panel panel3;
        private Label label21;
        private TextBox tbLiveAreage;
        private ComboBox cbHouse;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label10;
        private TextBox tbHomeLeader;
        private Label label13;
        private ComboBox cbToilt;
        private Label label11;
        private TextBox tbLiveAddr;
        private Label label12;
        private TextBox tbDetailAdr;
        private Label label1;
        private Button btnOK;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private List<ItemDictonaryModel<string>> relation;

        public FamilyInfoForm()
        {
            this.InitializeComponent();
            this.dgv_User.AutoGenerateColumns = false;
            this.InitComobox();
            this.EveryThingIsOk = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.UpdataToModel();
            if (!this.SaveModelToDB())
            {
                MessageBox.Show("存储失败！");
            }
            base.DialogResult = DialogResult.OK;
        }

        public ChildFormStatus CheckErrorInput()
        {
            if (!base.Enabled)
            {
                return ChildFormStatus.Invalid;
            }
            if (this.bindMgr.ErrorInput)
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
            base.Dispose(disposing);
        }

        private void FamilyInfoForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void InitComobox()
        {
            List<ItemDictonaryModel<string>> list = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("坐式抽水式马桶", "1"),
                new ItemDictonaryModel<string>("蹲式冲水式马桶", "2"),
                new ItemDictonaryModel<string>("公共厕所", "3"),
                new ItemDictonaryModel<string>("其他", "4")
            };
            this.cbToilt.DisplayMember = "DISPLAYMEMBER";
            this.cbToilt.ValueMember = "VALUEMEMBER";
            this.cbToilt.DataSource = list;
            List<ItemDictonaryModel<string>> list2 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("平房", "1"),
                new ItemDictonaryModel<string>("楼房", "2")
            };
            this.cbHouse.DisplayMember = "DISPLAYMEMBER";
            this.cbHouse.ValueMember = "VALUEMEMBER";
            this.cbHouse.DataSource = list2;
            List<ItemDictonaryModel<string>> list3 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("本地户籍常住", "1"),
                new ItemDictonaryModel<string>("本地户籍不常住", "2"),
                new ItemDictonaryModel<string>("外地户籍常住", "3"),
                new ItemDictonaryModel<string>("不详", "4")
            };
            this.cbLiveStatus.DisplayMember = "DISPLAYMEMBER";
            this.cbLiveStatus.ValueMember = "VALUEMEMBER";
            this.cbLiveStatus.DataSource = list3;
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("HouseArea", 10000M));
            this.inputRanges.Add(new InputRangeDec("IncomeAvg", 100000000M));
            this.inputRanges.Add(new InputRangeDec("HouseArea", 100000000M));
            this.inputRanges.Add(new InputRangeDec("Monthoil", 1000M));
            this.inputRanges.Add(new InputRangeDec("MonthSalt", 1000M));
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("HomeAddr", 200));
            this.inputrange_str.Add(new InputRangeStr("HomeAddrInfo", 200));
            this.relation = new List<ItemDictonaryModel<string>>();
            this.relation.Add(new ItemDictonaryModel<string>("户主", "1"));
            this.relation.Add(new ItemDictonaryModel<string>("配偶", "2"));
            this.relation.Add(new ItemDictonaryModel<string>("父亲", "3"));
            this.relation.Add(new ItemDictonaryModel<string>("母亲", "4"));
            this.relation.Add(new ItemDictonaryModel<string>("兄弟", "5"));
            this.relation.Add(new ItemDictonaryModel<string>("姐妹", "6"));
            this.relation.Add(new ItemDictonaryModel<string>("儿子", "7"));
            this.relation.Add(new ItemDictonaryModel<string>("女儿", "8"));
            this.relation.Add(new ItemDictonaryModel<string>("儿媳", "9"));
            this.relation.Add(new ItemDictonaryModel<string>("女婿", "10"));
            this.relation.Add(new ItemDictonaryModel<string>("孙子", "11"));
            this.relation.Add(new ItemDictonaryModel<string>("孙女", "12"));
            this.relation.Add(new ItemDictonaryModel<string>("外孙", "13"));
            this.relation.Add(new ItemDictonaryModel<string>("外孙女", "14"));
            this.relation.Add(new ItemDictonaryModel<string>("其他", "15"));
        }

        public void InitEveryThing()
        {
            Func<ItemDictonaryModel<string>, bool> predicate = null;
            if (!string.IsNullOrEmpty(this.Model.FamilyIDCardNo))
            {
                this.familyInfo = new RecordsFamilyInfoBLL().GetModel(this.Model.FamilyIDCardNo);
            }
            if (this.familyInfo == null)
            {
               RecordsFamilyInfoModel archive_family_info = new RecordsFamilyInfoModel
                {
                    RecordID = this.Model.RecordID,
                    IDCardNo = this.Model.IDCardNo,
                    ToiletType = "1",
                    HouseType = "1",
                    LiveStatus = "1",
                    CreatedDate = new DateTime?(DateTime.Today)
                };
                this.familyInfo = archive_family_info;
                this.familyInfo.FamilyRecordID = this.Model.IDCardNo;
                this.familyInfo.CreatedDate = new DateTime?(DateTime.Today);
                this.familyInfo.CreateBy = ConfigHelper.GetNode("doctor");
                this.familyInfo.CreateUnit = ConfigHelper.GetNode("orgCode");
                this.familyInfo.CustomerName = this.Model.CustomerName;
                this.tbRelation.Text = "本人";
                this.familypeople = new List<RecordsBaseInfoModel>();
            }
            else
            {
                if (!string.IsNullOrEmpty(this.Model.HouseRelation))
                {
                    if (predicate == null)
                    {
                        predicate = a => a.VALUEMEMBER == this.Model.HouseRelation;
                    }
                    ItemDictonaryModel<string> item_dictonary = this.relation.Single<ItemDictonaryModel<string>>(predicate);
                    if (item_dictonary.DISPLAYMEMBER == "其他")
                    {
                        this.tbRelation.Text = this.Model.HouseRealOther;
                    }
                    else
                    {
                        this.tbRelation.Text = item_dictonary.DISPLAYMEMBER;
                    }
                }
                this.tbLeaderName.Text = this.familyInfo.CustomerName;
                this.familyInfo.LastUpDateBy = ConfigHelper.GetNode("doctor");
                this.familyInfo.LastUpdateDate = new DateTime?(DateTime.Today);
                this.familypeople = new RecordsBaseInfoBLL().GetModelList(string.Format(" and FamilyIDCardNo = '{0}' ", this.familyInfo.IDCardNo));

                using (List<RecordsBaseInfoModel>.Enumerator enumerator = this.familypeople.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        RecordsBaseInfoModel item = enumerator.Current;
                        if (item.Sex == "1")
                        {
                            item.Sex = "男";
                        }
                        else if (item.Sex == "2")
                        {
                            item.Sex = "女";
                        }
                        else if (item.Sex == "0")
                        {
                            item.Sex = "未知的性别";
                        }
                        else if (item.Sex == "9")
                        {
                            item.Sex = "未说明的性别";
                        }
                        IEnumerable<ItemDictonaryModel<string>> source = from f in this.relation
                            where f.VALUEMEMBER == item.HouseRelation
                            select f;
                        if (source.Count<ItemDictonaryModel<string>>() > 0)
                        {
                            item.HouseRelation = source.First<ItemDictonaryModel<string>>().DISPLAYMEMBER;
                        }
                    }
                }
            }
            this.bindMgr = new SimpleBindingManager<RecordsFamilyInfoModel>(this.inputRanges, this.inputrange_str, this.familyInfo);
            this.bindMgr.SimpleBinding(this.tbLeaderName, "CustomerName", false);
            this.bindMgr.SimpleBinding(this.tbHomeLeader, "IDCardNo", false);
            this.bindMgr.SimpleBinding(this.tbLiveAddr, "HomeAddr", false);
            this.bindMgr.SimpleBinding(this.tbDetailAdr, "HomeAddrInfo", false);
            this.bindMgr.SimpleBinding(this.cbHouse, "HouseType");
            this.bindMgr.SimpleBinding(this.cbLiveStatus, "LiveStatus");
            this.bindMgr.SimpleBinding(this.cbToilt, "ToiletType");
            this.bindMgr.SimpleBinding(this.tbIncomeMonth, "IncomeAvg", true);
            this.bindMgr.SimpleBinding(this.tbLiveAreage, "HouseArea", true);
            this.bindMgr.SimpleBinding(this.tbOil, "Monthoil", true);
            this.bindMgr.SimpleBinding(this.tbSalt, "MonthSalt", true);
            this.dgv_User.DataSource = this.familypeople;
            for (int i = 0; i < this.dgv_User.Rows.Count; i++)
            {
                if ((this.dgv_User.Rows[i].Cells["Column3"].Value != null) && (this.dgv_User.Rows[i].Cells["Column3"].Value.ToString() == "1"))
                {
                    this.dgv_User.Rows[i].Cells["Column3"].ReadOnly = true;
                }
            }
            if (this.familyInfo.IsPoorfy == "1")
            {
                this.rdYesDBH.Checked = true;
            }
            else if (this.familyInfo.IsPoorfy == "0")
            {
                this.rdNoDBL.Checked = true;
            }
            this.EveryThingIsOk = true;
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.dgv_User = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRelation = new System.Windows.Forms.TextBox();
            this.tbLeaderName = new System.Windows.Forms.TextBox();
            this.cbLiveStatus = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rdNoDBL = new System.Windows.Forms.RadioButton();
            this.rdYesDBH = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.tbSalt = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.tbOil = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.tbIncomeMonth = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.tbLiveAreage = new System.Windows.Forms.TextBox();
            this.cbHouse = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbHomeLeader = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbToilt = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbLiveAddr = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbDetailAdr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_User)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Location = new System.Drawing.Point(46, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1423, 630);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 15F);
            this.btnCancel.Location = new System.Drawing.Point(1219, 583);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 34);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.dgv_User);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox2.Location = new System.Drawing.Point(65, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1269, 299);
            this.groupBox2.TabIndex = 98;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "家庭成员列表";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(78, 251);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(86, 34);
            this.btnDel.TabIndex = 0;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Visible = false;
            // 
            // dgv_User
            // 
            this.dgv_User.AllowUserToAddRows = false;
            this.dgv_User.AllowUserToDeleteRows = false;
            this.dgv_User.AllowUserToResizeColumns = false;
            this.dgv_User.AllowUserToResizeRows = false;
            this.dgv_User.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgv_User.ColumnHeadersHeight = 47;
            this.dgv_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_User.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column2,
            this.Column3});
            this.dgv_User.Location = new System.Drawing.Point(78, 28);
            this.dgv_User.Name = "dgv_User";
            this.dgv_User.RowTemplate.Height = 23;
            this.dgv_User.Size = new System.Drawing.Size(1114, 194);
            this.dgv_User.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CustomerName";
            this.Column1.HeaderText = "姓名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Sex";
            this.Column4.HeaderText = "性别";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Birthday";
            this.Column5.HeaderText = "出生日期";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 120;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Phone";
            this.Column6.HeaderText = "电话";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "HouseHoldAddress";
            this.Column7.HeaderText = "户籍住址";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "IDCardNo";
            this.Column2.HeaderText = "身份证号码";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "HouseRelation";
            this.Column3.HeaderText = "与户主关系";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox1.Location = new System.Drawing.Point(65, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1269, 241);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "家庭基本信息";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.87152F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.85625F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.09434F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.68014F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.18059F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbRelation, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbLeaderName, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbLiveStatus, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label24, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbHouse, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label19, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label18, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label15, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label14, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbHomeLeader, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbToilt, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbLiveAddr, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbDetailAdr, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label17, 2, 3);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 15F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(78, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.40796F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.39303F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1114, 202);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(730, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 124;
            this.label2.Text = "与户主关系:";
            // 
            // tbRelation
            // 
            this.tbRelation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbRelation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbRelation.ForeColor = System.Drawing.Color.Black;
            this.tbRelation.Location = new System.Drawing.Point(856, 4);
            this.tbRelation.MaxLength = 20;
            this.tbRelation.Name = "tbRelation";
            this.tbRelation.ReadOnly = true;
            this.tbRelation.Size = new System.Drawing.Size(183, 30);
            this.tbRelation.TabIndex = 2;
            // 
            // tbLeaderName
            // 
            this.tbLeaderName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbLeaderName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbLeaderName.ForeColor = System.Drawing.Color.Black;
            this.tbLeaderName.Location = new System.Drawing.Point(514, 4);
            this.tbLeaderName.MaxLength = 20;
            this.tbLeaderName.Name = "tbLeaderName";
            this.tbLeaderName.ReadOnly = true;
            this.tbLeaderName.Size = new System.Drawing.Size(183, 30);
            this.tbLeaderName.TabIndex = 1;
            // 
            // cbLiveStatus
            // 
            this.cbLiveStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbLiveStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLiveStatus.FormattingEnabled = true;
            this.cbLiveStatus.Location = new System.Drawing.Point(125, 130);
            this.cbLiveStatus.Name = "cbLiveStatus";
            this.cbLiveStatus.Size = new System.Drawing.Size(202, 28);
            this.cbLiveStatus.TabIndex = 8;
            // 
            // panel7
            // 
            this.panel7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel7.Controls.Add(this.rdNoDBL);
            this.panel7.Controls.Add(this.rdYesDBH);
            this.panel7.Font = new System.Drawing.Font("宋体", 15F);
            this.panel7.Location = new System.Drawing.Point(856, 84);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 33);
            this.panel7.TabIndex = 7;
            // 
            // rdNoDBL
            // 
            this.rdNoDBL.AutoSize = true;
            this.rdNoDBL.Location = new System.Drawing.Point(97, 4);
            this.rdNoDBL.Name = "rdNoDBL";
            this.rdNoDBL.Size = new System.Drawing.Size(47, 24);
            this.rdNoDBL.TabIndex = 101;
            this.rdNoDBL.TabStop = true;
            this.rdNoDBL.Text = "否";
            this.rdNoDBL.UseVisualStyleBackColor = true;
            // 
            // rdYesDBH
            // 
            this.rdYesDBH.AutoSize = true;
            this.rdYesDBH.Location = new System.Drawing.Point(8, 4);
            this.rdYesDBH.Name = "rdYesDBH";
            this.rdYesDBH.Size = new System.Drawing.Size(47, 24);
            this.rdYesDBH.TabIndex = 100;
            this.rdYesDBH.TabStop = true;
            this.rdYesDBH.Text = "是";
            this.rdYesDBH.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel6.Controls.Add(this.label25);
            this.panel6.Controls.Add(this.tbSalt);
            this.panel6.Location = new System.Drawing.Point(514, 164);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(198, 34);
            this.panel6.TabIndex = 12;
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(161, 10);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 20);
            this.label25.TabIndex = 110;
            this.label25.Text = "克";
            // 
            // tbSalt
            // 
            this.tbSalt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbSalt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSalt.ForeColor = System.Drawing.Color.Black;
            this.tbSalt.Location = new System.Drawing.Point(3, 2);
            this.tbSalt.MaxLength = 5;
            this.tbSalt.Name = "tbSalt";
            this.tbSalt.Size = new System.Drawing.Size(150, 30);
            this.tbSalt.TabIndex = 113;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(408, 171);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(99, 20);
            this.label24.TabIndex = 119;
            this.label24.Text = "月食用盐:";
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel5.Controls.Add(this.label23);
            this.panel5.Controls.Add(this.tbOil);
            this.panel5.Location = new System.Drawing.Point(125, 164);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(202, 33);
            this.panel5.TabIndex = 11;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(168, 7);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 20);
            this.label23.TabIndex = 110;
            this.label23.Text = "斤";
            // 
            // tbOil
            // 
            this.tbOil.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbOil.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbOil.ForeColor = System.Drawing.Color.Black;
            this.tbOil.Location = new System.Drawing.Point(3, 1);
            this.tbOil.MaxLength = 3;
            this.tbOil.Name = "tbOil";
            this.tbOil.Size = new System.Drawing.Size(150, 30);
            this.tbOil.TabIndex = 113;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.tbIncomeMonth);
            this.panel4.Location = new System.Drawing.Point(514, 124);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(198, 33);
            this.panel4.TabIndex = 9;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(161, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 20);
            this.label22.TabIndex = 110;
            this.label22.Text = "元";
            // 
            // tbIncomeMonth
            // 
            this.tbIncomeMonth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbIncomeMonth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbIncomeMonth.ForeColor = System.Drawing.Color.Black;
            this.tbIncomeMonth.Location = new System.Drawing.Point(3, 2);
            this.tbIncomeMonth.MaxLength = 8;
            this.tbIncomeMonth.Name = "tbIncomeMonth";
            this.tbIncomeMonth.Size = new System.Drawing.Size(150, 30);
            this.tbIncomeMonth.TabIndex = 113;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.tbLiveAreage);
            this.panel3.Location = new System.Drawing.Point(856, 124);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 33);
            this.panel3.TabIndex = 10;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(171, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 20);
            this.label21.TabIndex = 110;
            this.label21.Text = "㎡";
            // 
            // tbLiveAreage
            // 
            this.tbLiveAreage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbLiveAreage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbLiveAreage.Font = new System.Drawing.Font("宋体", 15F);
            this.tbLiveAreage.ForeColor = System.Drawing.Color.Black;
            this.tbLiveAreage.Location = new System.Drawing.Point(3, 1);
            this.tbLiveAreage.MaxLength = 5;
            this.tbLiveAreage.Name = "tbLiveAreage";
            this.tbLiveAreage.Size = new System.Drawing.Size(150, 30);
            this.tbLiveAreage.TabIndex = 0;
            // 
            // cbHouse
            // 
            this.cbHouse.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbHouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHouse.FormattingEnabled = true;
            this.cbHouse.Location = new System.Drawing.Point(514, 90);
            this.cbHouse.Name = "cbHouse";
            this.cbHouse.Size = new System.Drawing.Size(184, 28);
            this.cbHouse.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(19, 171);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(99, 20);
            this.label19.TabIndex = 111;
            this.label19.Text = "月食用油:";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(750, 130);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 20);
            this.label18.TabIndex = 111;
            this.label18.Text = "住房面积:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(19, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 20);
            this.label16.TabIndex = 111;
            this.label16.Text = "居住状况:";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(750, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 20);
            this.label15.TabIndex = 111;
            this.label15.Text = "低 保 户:";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(408, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 20);
            this.label14.TabIndex = 111;
            this.label14.Text = "住房类型:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(19, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 94;
            this.label10.Text = "户主编号:";
            // 
            // tbHomeLeader
            // 
            this.tbHomeLeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHomeLeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHomeLeader.ForeColor = System.Drawing.Color.Black;
            this.tbHomeLeader.Location = new System.Drawing.Point(125, 4);
            this.tbHomeLeader.Name = "tbHomeLeader";
            this.tbHomeLeader.ReadOnly = true;
            this.tbHomeLeader.Size = new System.Drawing.Size(202, 30);
            this.tbHomeLeader.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(19, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 20);
            this.label13.TabIndex = 100;
            this.label13.Text = "厕所类型:";
            // 
            // cbToilt
            // 
            this.cbToilt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbToilt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbToilt.FormattingEnabled = true;
            this.cbToilt.Location = new System.Drawing.Point(125, 90);
            this.cbToilt.Name = "cbToilt";
            this.cbToilt.Size = new System.Drawing.Size(202, 28);
            this.cbToilt.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(19, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 96;
            this.label11.Text = "居住住址:";
            // 
            // tbLiveAddr
            // 
            this.tbLiveAddr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbLiveAddr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbLiveAddr.ForeColor = System.Drawing.Color.Black;
            this.tbLiveAddr.Location = new System.Drawing.Point(125, 44);
            this.tbLiveAddr.MaxLength = 20;
            this.tbLiveAddr.Name = "tbLiveAddr";
            this.tbLiveAddr.Size = new System.Drawing.Size(202, 30);
            this.tbLiveAddr.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(408, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 20);
            this.label12.TabIndex = 98;
            this.label12.Text = "详细地址:";
            // 
            // tbDetailAdr
            // 
            this.tbDetailAdr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDetailAdr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDetailAdr.ForeColor = System.Drawing.Color.Black;
            this.tbDetailAdr.Location = new System.Drawing.Point(514, 44);
            this.tbDetailAdr.MaxLength = 20;
            this.tbDetailAdr.Name = "tbDetailAdr";
            this.tbDetailAdr.Size = new System.Drawing.Size(184, 30);
            this.tbDetailAdr.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(408, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 123;
            this.label1.Text = "户主姓名:";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(348, 130);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(159, 20);
            this.label17.TabIndex = 111;
            this.label17.Text = "家庭人均月收入:";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 15F);
            this.btnOK.Location = new System.Drawing.Point(1105, 583);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 34);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "完成";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            // 
            // FamilyInfoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "FamilyInfoForm";
            this.Text = "FamilyInfoForm";
            this.Load += new System.EventHandler(this.FamilyInfoForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_User)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            RecordsFamilyInfoBLL recordsFamilyInfoBLL = new RecordsFamilyInfoBLL();
            if (recordsFamilyInfoBLL.Exists(this.familyInfo.ID))
            {
                recordsFamilyInfoBLL.Update(this.familyInfo);
            }
            else
            {
                recordsFamilyInfoBLL.Add(this.familyInfo);
            }
            if (string.IsNullOrEmpty(this.Model.FamilyIDCardNo))
            {
                RecordsBaseInfoBLL recordsBaseInfoBLL = new RecordsBaseInfoBLL();
                this.Model.FamilyIDCardNo = this.familyInfo.IDCardNo;
                this.Model.HouseID = this.familyInfo.IDCardNo;
                this.Model.HouseName = this.familyInfo.CustomerName;
                this.Model.HouseRelation = "1";
                recordsBaseInfoBLL.Update(this.Model);
            }
            return true;
        }

        public void SetBtnVisiable()
        {
            this.btnCancel.Visible = true;
            this.btnOK.Visible = true;
        }

        public void UpdataToModel()
        {
            this.familyInfo.CreatedDate = new DateTime?(DateTime.Today);
            if (this.rdYesDBH.Checked)
            {
                this.familyInfo.IsPoorfy = "1";
            }
            else if (this.rdNoDBL.Checked)
            {
                this.familyInfo.IsPoorfy = "0";
            }
        }

        public bool EveryThingIsOk { get; set; }

        public RecordsFamilyInfoModel familyInfo { get; set; }

        private List<RecordsBaseInfoModel> familypeople { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

