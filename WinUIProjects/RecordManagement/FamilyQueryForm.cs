using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;

namespace RecordManagement
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class FamilyQueryForm : Form
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

        public FamilyQueryForm()
        {
            this.InitializeComponent();
        }

        public FamilyQueryForm(List<RecordsFamilyInfoModel> fas)
        {
            this.InitializeComponent();
            this.familys = fas;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.GetFam();
            int count = this.familys.Count;
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

        private void FamilyQueryForm_Load(object sender, EventArgs e)
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
                builder.AppendFormat("AND b.CustomerName LIKE '%{0}%' ", this.txthuzhuName.Text);
            }
            if (!string.IsNullOrEmpty(this.txthuzhuNo.Text.Trim()))
            {
                builder.AppendFormat("AND b.IDCardNo LIKE '%{0}%' ", this.txthuzhuNo.Text);
            }
            this.familys = new RecordsFamilyInfoBLL().GetModelList(builder.ToString());
            foreach (RecordsFamilyInfoModel recordsFamilyInfoModel in this.familys)
            {
                ListViewItem item = new ListViewItem(recordsFamilyInfoModel.RecordID.ToString());
                item.SubItems.Add(recordsFamilyInfoModel.CustomerName);
                item.SubItems.Add(recordsFamilyInfoModel.IDCardNo);
                item.SubItems.Add(recordsFamilyInfoModel.HomeAddr);
                this.listView1.Items.Add(item);
            }
            if (this.familys.Count == 0)
            {
                MessageBox.Show("未找到家庭记录!", "查找结果", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void InitializeComponent()
        {
            this.listView1 = new ListView();
            this.columnHeader3 = new ColumnHeader();
            this.columnHeader1 = new ColumnHeader();
            this.columnHeader2 = new ColumnHeader();
            this.columnHeader4 = new ColumnHeader();
            this.btnCancel = new Button();
            this.groupBox1 = new GroupBox();
            this.btnFind = new Button();
            this.label174 = new Label();
            this.txthuzhuNo = new TextBox();
            this.txthuzhuName = new TextBox();
            this.label172 = new Label();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.listView1.Activation = ItemActivation.TwoClick;
            this.listView1.Columns.AddRange(new ColumnHeader[] { this.columnHeader3, this.columnHeader1, this.columnHeader2, this.columnHeader4 });
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new Point(14, 0x3e);
            this.listView1.Name = "listView1";
            this.listView1.Size = new Size(0x27b, 0xcd);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = View.Details;
            this.listView1.ItemActivate += new EventHandler(this.listView1_ItemActivate);
            this.columnHeader3.Text = "档案编号";
            this.columnHeader3.Width = 0x7f;
            this.columnHeader1.Text = "户主姓名";
            this.columnHeader1.Width = 0x67;
            this.columnHeader2.Text = "户主身份证";
            this.columnHeader2.Width = 0xa3;
            this.columnHeader4.Text = "居住地址";
            this.columnHeader4.Width = 0xcf;
            this.btnCancel.Location = new Point(0x232, 0x111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x57, 0x21);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "返回";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.label174);
            this.groupBox1.Controls.Add(this.txthuzhuNo);
            this.groupBox1.Controls.Add(this.txthuzhuName);
            this.groupBox1.Controls.Add(this.label172);
            this.groupBox1.Location = new Point(14, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x27b, 50);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "家庭信息";
            this.btnFind.Location = new Point(0x21e, 15);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new Size(0x57, 0x1b);
            this.btnFind.TabIndex = 0x1b;
            this.btnFind.Tag = "";
            this.btnFind.Text = "查找";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new EventHandler(this.btnFind_Click);
            this.label174.AutoSize = true;
            this.label174.Location = new Point(0xe7, 0x15);
            this.label174.Name = "label174";
            this.label174.Size = new Size(0x62, 14);
            this.label174.TabIndex = 0x1a;
            this.label174.Text = "户主身份证号:";
            this.txthuzhuNo.BackColor = Color.WhiteSmoke;
            this.txthuzhuNo.ForeColor = Color.Black;
            this.txthuzhuNo.Location = new Point(0x14f, 0x12);
            this.txthuzhuNo.MaxLength = 0x12;
            this.txthuzhuNo.Name = "txthuzhuNo";
            this.txthuzhuNo.Size = new Size(0xc9, 0x17);
            this.txthuzhuNo.TabIndex = 0x19;
            this.txthuzhuName.BackColor = Color.WhiteSmoke;
            this.txthuzhuName.ForeColor = Color.Black;
            this.txthuzhuName.Location = new Point(0x52, 0x12);
            this.txthuzhuName.Name = "txthuzhuName";
            this.txthuzhuName.Size = new Size(0x74, 0x17);
            this.txthuzhuName.TabIndex = 0x18;
            this.label172.AutoSize = true;
            this.label172.Location = new Point(6, 0x15);
            this.label172.Name = "label172";
            this.label172.Size = new Size(70, 14);
            this.label172.TabIndex = 0x17;
            this.label172.Text = "户主姓名:";
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.ClientSize = new Size(0x295, 0x13e);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.listView1);
            this.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FamilyQueryForm";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            this.Text = "查找家庭档案";
            base.Load += new EventHandler(this.FamilyQueryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            Predicate<RecordsFamilyInfoModel> match = null;
            this.FamilyArcID = this.listView1.FocusedItem.SubItems[0].Text;
            if (this.FamilyArcID != "无")
            {
                if (match == null)
                {
                    match = c => c.RecordID.ToString() == this.FamilyArcID;
                }
                RecordsFamilyInfoModel recordsFamilyInfoModel = this.familys.Find(match);
                if (recordsFamilyInfoModel != null)
                {
                    this.Model.FamilyIDCardNo = recordsFamilyInfoModel.IDCardNo;
                    this.Model.HouseID = recordsFamilyInfoModel.IDCardNo;
                    this.Model.HouseName = recordsFamilyInfoModel.CustomerName;
                }
                base.DialogResult = DialogResult.OK;
            }
            else if (this.Model.HouseRelation == "1")
            {
                if (MessageBox.Show("当前人员为户主且有相应的家庭档案信息，此操作将会将人员的家庭关系删除，是否继续？\r\n（注意：这样将会删除现家庭档案的所有信息和家庭中所有对应的人员关系!）", "家庭档案", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    RecordsBaseInfoBLL recordsBaseInfoBLL = new RecordsBaseInfoBLL();
                    foreach (RecordsBaseInfoModel recordsBaseInfoModel in recordsBaseInfoBLL.GetModelList(string.Format(" and FY_ARCHIVEID = '{0}' ", this.Model.FamilyIDCardNo)))
                    {
                        recordsBaseInfoModel.FamilyIDCardNo = null;
                        recordsBaseInfoModel.HouseRelation = null;
                        recordsBaseInfoModel.HouseRealOther = null;
                        recordsBaseInfoBLL.Update(recordsBaseInfoModel);
                    }
                    new RecordsFamilyInfoBLL();
                    this.Model.FamilyIDCardNo = null;
                    this.Model.HouseID = null;
                    this.Model.HouseName = null;
                    this.Model.HouseRelation = null;
                    this.Model.HouseRealOther = null;
                    base.DialogResult = DialogResult.OK;
                }
            }
            else if (MessageBox.Show("此操作将会将人员的家庭关系删除，是否继续?", "家庭档案", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Model.FamilyIDCardNo = null;
                this.Model.HouseID = null;
                this.Model.HouseName = null;
                this.Model.HouseRelation = null;
                this.Model.HouseRealOther = null;
                base.DialogResult = DialogResult.OK;
            }
        }

        public string FamilyArcID { get; set; }

        public List<RecordsFamilyInfoModel> familys { get; set; }

        public RecordsBaseInfoModel Model { get; set; }
    }
}

