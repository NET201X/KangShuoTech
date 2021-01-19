using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;

namespace ArchiveInfo
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using KangShuoTech.Utilities.CommonTools;

    public class HomeQueryForm : Form
    {
        private Button btnCancel;
        private Button btnFind;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private IContainer components;
        private GroupBox groupBox1;
        private Label label172;
        private Label label174;
        private ListView listView1;
        private TextBox txthuzhuName;
        private TextBox txthuzhuNo;

        public HomeQueryForm()
        {
            this.InitializeComponent();
        }

        public HomeQueryForm(List<RecordsBaseInfoModel> fas)
        {
            this.InitializeComponent();
            this.ModelList = fas;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.GetFam();
        }

        private void CreateFamInfo()
        {
            FamilyInfoForm info = new FamilyInfoForm {
                FormBorderStyle = FormBorderStyle.FixedSingle,
                ShowIcon = false,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false,
                Model = this.Model,
                Text = "创建家庭信息"
            };
            info.SetBtnVisiable();
            if (info.ShowDialog() == DialogResult.OK)
            {
                this.txthuzhuName.Text = this.Model.CustomerName;
                this.txthuzhuNo.Text = this.Model.FamilyIDCardNo;
                this.GetFam();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void HomeQueryForm_Load(object sender, EventArgs e)
        {
            this.txthuzhuNo.Text = this.Model.FamilyIDCardNo;
            this.txthuzhuName.Text = this.Model.HouseName;
        }

        private void GetFam()
        {
            this.listView1.Items.Clear();
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(this.txthuzhuName.Text.Trim()))
            {
                builder.AppendFormat("AND CustomerName LIKE '%{0}%' ", this.txthuzhuName.Text);
            }
            if (!string.IsNullOrEmpty(this.txthuzhuNo.Text.Trim()))
            {
                builder.AppendFormat("AND IDCardNo LIKE '%{0}%' ", this.txthuzhuNo.Text);
            }
            if (string.IsNullOrEmpty(builder.ToString()))
            {
                MessageBox.Show("请输入查询条件！", "查询条件", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            this.ModelList = new RecordsBaseInfoBLL().GetModelList(builder.ToString());
            foreach (RecordsBaseInfoModel BaseInfoModel in this.ModelList)
            {
                ListViewItem item = new ListViewItem(BaseInfoModel.RecordID.ToString());
                item.SubItems.Add(BaseInfoModel.CustomerName);
                item.SubItems.Add(BaseInfoModel.IDCardNo);
                item.SubItems.Add(BaseInfoModel.HouseHoldAddress);
                this.listView1.Items.Add(item);
            }
            if (this.ModelList.Count == 0)
            {
                MessageBox.Show("未找到户主信息!", "查找结果", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.label174 = new System.Windows.Forms.Label();
            this.txthuzhuNo = new System.Windows.Forms.TextBox();
            this.txthuzhuName = new System.Windows.Forms.TextBox();
            this.label172 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(21, 68);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(606, 216);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "档案编号";
            this.columnHeader3.Width = 127;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "户主姓名";
            this.columnHeader1.Width = 103;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "户主身份证";
            this.columnHeader2.Width = 163;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "居住地址";
            this.columnHeader4.Width = 207;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(540, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 33);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "返回";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.label174);
            this.groupBox1.Controls.Add(this.txthuzhuNo);
            this.groupBox1.Controls.Add(this.txthuzhuName);
            this.groupBox1.Controls.Add(this.label172);
            this.groupBox1.Location = new System.Drawing.Point(14, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 50);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "家庭信息";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(548, 15);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(81, 29);
            this.btnFind.TabIndex = 27;
            this.btnFind.Tag = "";
            this.btnFind.Text = "查找";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label174
            // 
            this.label174.AutoSize = true;
            this.label174.Location = new System.Drawing.Point(218, 19);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(139, 20);
            this.label174.TabIndex = 26;
            this.label174.Text = "户主身份证号:";
            // 
            // txthuzhuNo
            // 
            this.txthuzhuNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txthuzhuNo.ForeColor = System.Drawing.Color.Black;
            this.txthuzhuNo.Location = new System.Drawing.Point(361, 15);
            this.txthuzhuNo.MaxLength = 18;
            this.txthuzhuNo.Name = "txthuzhuNo";
            this.txthuzhuNo.Size = new System.Drawing.Size(181, 30);
            this.txthuzhuNo.TabIndex = 25;
            // 
            // txthuzhuName
            // 
            this.txthuzhuName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txthuzhuName.ForeColor = System.Drawing.Color.Black;
            this.txthuzhuName.Location = new System.Drawing.Point(99, 15);
            this.txthuzhuName.Name = "txthuzhuName";
            this.txthuzhuName.Size = new System.Drawing.Size(116, 30);
            this.txthuzhuName.TabIndex = 24;
            // 
            // label172
            // 
            this.label172.AutoSize = true;
            this.label172.Location = new System.Drawing.Point(6, 21);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(99, 20);
            this.label172.TabIndex = 23;
            this.label172.Text = "户主姓名:";
            // 
            // HomeQueryForm
            // 
            this.ClientSize = new System.Drawing.Size(658, 335);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HomeQueryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "查找家庭档案";
            this.Load += new System.EventHandler(this.HomeQueryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            Predicate<RecordsBaseInfoModel> match = null;
            this.FamilyArcID = this.listView1.FocusedItem.SubItems[2].Text;
            if (this.FamilyArcID != "")
            {
                if (match == null)
                {
                    match = c => c.IDCardNo.ToString() == this.FamilyArcID;
                }
                RecordsBaseInfoModel HouseModel = new RecordsBaseInfoModel();
                HouseModel = this.ModelList.Find(match);
                RecordsFamilyInfoModel FamilyModel = new RecordsFamilyInfoBLL().GetModel(HouseModel.IDCardNo);
                if (FamilyModel == null)
                {
                    RecordsFamilyInfoModel archive_family_info = new RecordsFamilyInfoModel
                    {
                        RecordID = HouseModel.RecordID,
                        IDCardNo = HouseModel.IDCardNo,
                        ToiletType = "1",
                        HouseType = "1",
                        LiveStatus = "1",
                        CreatedDate = new DateTime?(DateTime.Today)
                    };
                    FamilyModel = archive_family_info;
                    FamilyModel.FamilyRecordID = HouseModel.IDCardNo;
                    FamilyModel.CreatedDate = new DateTime?(DateTime.Today);
                    FamilyModel.CreateBy = ConfigHelper.GetNode("doctor");
                    FamilyModel.CreateUnit = ConfigHelper.GetNode("orgCode");
                    FamilyModel.CustomerName = HouseModel.CustomerName;
                    //增加户主信息
                    new RecordsFamilyInfoBLL().Add(archive_family_info);

                    RecordsBaseInfoBLL recordsBaseInfoBLL = new RecordsBaseInfoBLL();
                    HouseModel.FamilyIDCardNo = FamilyModel.IDCardNo;
                    HouseModel.HouseID = FamilyModel.IDCardNo;
                    HouseModel.HouseName = FamilyModel.CustomerName;
                    HouseModel.HouseRelation = "1";
                    HouseModel.HouseRealOther = "本人";
                    recordsBaseInfoBLL.Update(HouseModel);
                }
                this.Model.FamilyIDCardNo = FamilyModel.IDCardNo;
                this.Model.HouseID = FamilyModel.IDCardNo;
                this.Model.HouseName = FamilyModel.CustomerName;
                base.DialogResult = DialogResult.OK;
            }
        }

        public string FamilyArcID { get; set; }

        //public List<RecordsFamilyInfoModel> familys { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public List<RecordsBaseInfoModel> ModelList { get; set; }
    }
}

