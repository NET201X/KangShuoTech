using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonUI;

namespace OverView
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public class FrmViewData : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private BindingSource bds;
        private Button btnDel;
        private Button btnExport;
        private Button btnFront;
        private Button btnNext;
        private Button btnQuery;
        private ComboBox cbxUser;
        private CheckBox ckBirthday;
        private CheckBox ckxCreatedDate;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewLinkColumn Column9;
        private IContainer components;
        private int currentPage;
        private DataGridView dgvData;
        private DataTable dt_user;
        private DateTimePicker dtpCreatedDateEd;
        private DateTimePicker dtpCreatedDateSt;
        private DateTimePicker dtpEd;
        private DateTimePicker dtpSt;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lbPages;
        private Label lbTotalCount;
        private int pageCount = 0x12;
        private TextBox tbAddr;
        private int totalCount;
        private int totalPages;
        private TextBox txtIdNum;
        private Button btnChdCount;
        private Button btnDiadetesCount;
        private Button btnPertension;
        private Button btnStrokeCount;
        private Button btnMentaldisease;
        private DataGridViewTextBoxColumn 身份证;

        public FrmViewData()
        {
            this.InitializeComponent();
            this.dgvData.AutoGenerateColumns = false;
            this.EveryThingIsOk = false;
            this.HaveToSave = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.bds.Position >= 0)
            {
                DataRowView view = this.bds.List[this.bds.Position] as DataRowView;
                if (view != null)
                {
                    DataRow row = view.Row;
                    if (row["HouseRelation"].ToString() == "1")
                    {
                        string str = "？当前人员为户主且有相应的家庭档案信息，是否删除现家庭档案和所有家庭成员的关联关系？";
                        if (MessageBox.Show("确定删除:" + row["CustomerName"].ToString() + str + "删除之后的信息将无法恢复!", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
                            foreach (RecordsBaseInfoModel archive_baseinfo2 in archive_baseinfo.GetModelList(string.Format(" and FamilyIDCardNo = '{0}' ", this.Model.RecordID)))
                            {
                                archive_baseinfo2.RecordID = null;
                                archive_baseinfo2.HouseRelation = null;
                                archive_baseinfo2.HouseRealOther = null;
                                archive_baseinfo.Update(archive_baseinfo2);
                            }
                            RecordsFamilyInfoBLL archive_family_info = new RecordsFamilyInfoBLL();
                            RecordsFamilyInfoModel model = archive_family_info.GetModel(this.Model.IDCardNo);
                            if (model != null)
                            {
                                archive_family_info.Delete(model.ID);
                            }
                            new RecordsBaseInfoBLL().DelTheMan(row["IDCardNo"].ToString());
                            row.Delete();
                            row.Table.AcceptChanges();
                        }
                    }
                    else if (MessageBox.Show("确定删除:" + row["CustomerName"].ToString() + "？删除之后的信息将无法恢复!", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        new RecordsBaseInfoBLL().DelTheMan(row["IDCardNo"].ToString());
                        row.Delete();
                        row.Table.AcceptChanges();
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataSet list = new RecordsBaseInfoBLL().GetList(this.GetWhere());
            if (list.Tables.Count == 0)
            {
                MessageBox.Show("统计结果为空!!");
            }
            else if (list.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("统计结果为空!!");
            }
            else
            {
                this.TransDs(list);
                Dictionary<string, string> fgt = new Dictionary<string, string>();
                fgt.Add("CustomerName", "姓名");
                fgt.Add("IDCardNo", "身份证");
                fgt.Add("Sex", "性别");
                fgt.Add("Birthday", "生日");
                fgt.Add("Phone", "电话");
                fgt.Add("HouseHoldAddress", "住址");
                fgt.Add("CreateDate", "建档日期");
                fgt.Add("LastUpdateDate", "最后更新日期");
                this.DatatableToCSVFile(fgt, list.Tables[0], @"d:\" + string.Format(@"\人员列表{0}.csv", DateTime.Now.ToString("yyyyMMddHHmmss")));
            }
        }

        private void btnFront_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 0)
            {
                this.lbPages.Text = string.Format("{0}/{1}页", --this.currentPage + 1, this.totalPages);
                DataSet ds = new RecordsBaseInfoBLL().GetListByPage(this.GetWhere(), "", this.currentPage * this.pageCount, this.pageCount);
                if (ds.Tables.Count > 0)
                {
                    this.TransDs(ds);
                    this.bds.DataSource = ds.Tables[0];
                    this.dgvData.DataSource = this.bds;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.currentPage < (this.totalPages - 1))
            {
                this.lbPages.Text = string.Format("{0}/{1}页", ++this.currentPage + 1, this.totalPages);
                DataSet ds = new RecordsBaseInfoBLL().GetListByPage(this.GetWhere(), "", this.currentPage * this.pageCount, this.pageCount);
                if (ds.Tables.Count > 0)
                {
                    this.TransDs(ds);
                    this.bds.DataSource = ds.Tables[0];
                    this.dgvData.DataSource = this.bds;
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.btnQuery.Text == "重置条件")
            {
                this.groupBox1.Enabled = true;
                this.btnQuery.Text = "查询";
                txtIdNum.Text = "";
                tbAddr.Text = "";
                dtpSt.Text = "";
                dtpEd.Text = "";
                dtpCreatedDateSt.Text = "";
                dtpCreatedDateEd.Text = "";
            }
            else if (this.ckBirthday.Checked && (this.dtpSt.Value.Date > this.dtpEd.Value.Date))
            {
                MessageBox.Show(" 出生日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.ckxCreatedDate.Checked && (this.dtpCreatedDateSt.Value.Date > this.dtpCreatedDateEd.Value.Date))
            {
                MessageBox.Show(" 建档日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                string where = this.GetWhere();
                this.btnQuery.Enabled = false;
                RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
                this.totalCount = archive_baseinfo.GetRecordCount(where);
                this.totalPages = (this.totalCount <= this.pageCount) ? 1 : ((this.totalCount / this.pageCount) + (((this.totalCount % this.pageCount) > 0) ? 1 : 0));
                this.currentPage = 0;
                this.lbTotalCount.Text = string.Format("共计{0}条", this.totalCount.ToString());
                DataSet ds = archive_baseinfo.GetListByPage(where, "", 0, this.pageCount);
                this.lbPages.Text = string.Format("{0}/{1}页", this.currentPage + 1, this.totalPages);
                if (ds.Tables.Count > 0)
                {
                    this.TransDs(ds);
                    this.bds.DataSource = ds.Tables[0];
                    this.dgvData.DataSource = this.bds;
                }
                else
                {
                    this.dgvData.DataSource = null;
                }
                this.groupBox1.Enabled = false;
                this.btnQuery.Enabled = true;
                this.btnQuery.Text = "重置条件";
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        private void ckBirthday_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpSt.Enabled = this.ckBirthday.Checked;
            this.dtpEd.Enabled = this.ckBirthday.Checked;
        }

        private void ckxCreatedDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpCreatedDateSt.Enabled = this.ckxCreatedDate.Checked;
            this.dtpCreatedDateEd.Enabled = this.ckxCreatedDate.Checked;
        }

        //public void DatatableToCSVFile(Dictionary<string, string> fgt, DataTable dt, string fileName)
        //{
        //    try
        //    {
        //        string str = "";
        //        foreach (KeyValuePair<string, string> pair in fgt)
        //        {
        //            str = str + pair.Value + ",";
        //        }
        //        string str2 = str.TrimEnd(new char[] { ',' });
        //        StreamWriter writer = new StreamWriter(File.Create(fileName), Encoding.Default);
        //        writer.WriteLine(str2);
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            string str3 = "";
        //            foreach (KeyValuePair<string, string> pair2 in fgt)
        //            {
        //                DateTime time;
        //                str3 = (((pair2.Key == "Birthday") || (pair2.Key == "CreateDate")) || (pair2.Key == "LastUpdateDate")) ? (!DateTime.TryParse(row[pair2.Key].ToString(), out time) ? (str3 + row[pair2.Key].ToString() + ",") : (str3 + time.ToShortDateString() + ",")) : (str3 + row[pair2.Key].ToString() + ",");
        //            }
        //            string str4 = str3.TrimEnd(new char[] { ',' });
        //            writer.WriteLine(str4);
        //        }
        //        writer.Flush();
        //        writer.Close();
        //        MessageBox.Show("导出文件至" + fileName);
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //        LogHelper.LogError(exception);
        //    }
        //}

        public void DatatableToCSVFile(Dictionary<string, string> fgt, DataTable dt, string fileName)
        {
            try
            {
                string str = "";
                foreach (KeyValuePair<string, string> pair in fgt)
                {
                    str = str + pair.Value + ',';
                }
                string str2 = str.TrimEnd(new char[] { ',' });
                StreamWriter writer = new StreamWriter(File.Create(fileName), Encoding.Default);
                writer.WriteLine(str2);
                foreach (DataRow row in dt.Rows)
                {
                    string str3 = "";
                    foreach (KeyValuePair<string, string> pair2 in fgt)
                    {
                        DateTime time;
                        if ((pair2.Key == "Birthday") || (pair2.Key == "CreateDate") || (pair2.Key == "LastUpdateDate"))
                        {
                            if (!DateTime.TryParse(row[pair2.Key].ToString(), out time))
                                str3 = str3 + row[pair2.Key].ToString() + ",";
                            else
                                str3 = str3 + time.ToShortDateString() + ",";
                        }
                        else if (pair2.Key == "IDCardNo")
                        {
                            str3 = str3 + "\t" + row[pair2.Key].ToString() + ",";
                        }
                        else
                        {
                            str3 = str3 + row[pair2.Key].ToString() + ",";
                        }
                        //str3 = (((pair2.Key == "Birthday") || (pair2.Key == "CreateDate")) || (pair2.Key == "LastUpdateDate")) ?
                        //    (!DateTime.TryParse(row[pair2.Key].ToString(), out time) ? (str3 + row[pair2.Key].ToString() + ",") :
                        //    (str3 + time.ToShortDateString() + ",")) : (str3 + row[pair2.Key].ToString() + ",");
                    }
                    string str4 = str3.TrimEnd(new char[] { ',' });
                    writer.WriteLine(str4);
                }
                writer.Flush();
                writer.Close();
                MessageBox.Show("导出文件至" + fileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                LogHelper.LogError(exception);
            }
        }

        public void DatatableToCSVFile(DataTable dt, string xbkPath, string SavePath, ref string err)
        {
            try
            {
                StreamReader reader = new StreamReader(xbkPath);
                string str = reader.ReadLine();
                reader.Close();
                StreamWriter writer = new StreamWriter(File.Create(SavePath));
                writer.WriteLine(str);
                foreach (DataRow row in dt.Rows)
                {
                    string str2 = "";
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (i != (dt.Columns.Count - 1))
                        {
                            string str3 = row[i].ToString().Trim().Replace(",", " ");
                            str2 = str2 + str3 + ",";
                        }
                        else
                        {
                            string str4 = row[i].ToString().Trim().Replace(",", ".");
                            str2 = str2 + str4;
                        }
                    }
                    writer.WriteLine(str2);
                }
                writer.Flush();
                writer.Close();
            }
            catch (Exception exception)
            {
                err = exception.ToString();
                LogHelper.LogError(exception);
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((this.dgvData.Columns[e.ColumnIndex].HeaderText == "体检数据") && (this.bds.Position >= 0)) && (e.RowIndex >= 0))
            {
                DataRowView view = (DataRowView) this.bds.List[this.bds.Position];
                if (this.dgvData[e.ColumnIndex, this.bds.Position].Value.ToString() == "检测数据")
                {
                    FrmBT_Data data = new FrmBT_Data {
                        IDCardNo = view.Row["IDCardNo"].ToString()
                    };
                    data.StartPosition = FormStartPosition.CenterParent;
                    data.ShowDialog();
                }
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

        public void ExportToSvc(DataTable dt, string strName)
        {
            string path = Path.GetTempPath() + strName + ".csv";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            try
            {
                StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.CreateNew), Encoding.GetEncoding("GB2312"));
                for (int i = 0; i <= (dt.Columns.Count - 1); i++)
                {
                    builder.Append(dt.Columns[i].ColumnName);
                    builder.Append(",");
                }
                builder.Remove(builder.Length - 1, 1);
                writer.WriteLine(builder);
                foreach (DataRow row in dt.Rows)
                {
                    builder2.Remove(0, builder2.Length);
                    for (int j = 0; j <= (dt.Columns.Count - 1); j++)
                    {
                        builder2.Append(row[j].ToString());
                        builder2.Append(",");
                    }
                    builder2.Remove(builder2.Length - 1, 1);
                    writer.WriteLine(builder2);
                }
                writer.Close();
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                MessageBox.Show(exception.Message);
            }
            Process.Start(path);
        }

        private void FrmViewData_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private string GetWhere()
        {
            string input = this.txtIdNum.Text.Trim();
            string str2 = "";
            if (input != "")
            {
                str2 = !Regex.IsMatch(input, "^[0-9]*$") ? string.Format(" and CustomerName like '%{0}%'", input) : ("and IDCardNo LIKE '%" + input + "%'");
            }
            if (!string.IsNullOrEmpty(this.tbAddr.Text.Trim()))
            {
                str2 = str2 + string.Format(" and HouseHoldAddress LIKE '%{0}%' ", this.tbAddr.Text.Trim());
            }
            if (this.ckBirthday.Checked)
            {
               // str2 = !(this.dtpSt.Value.Date == this.dtpEd.Value.Date) ? (str2 + string.Format(" and Birthday between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"))) : (str2 + string.Format(" and Birthday between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpSt.Value.Date.AddDays(1.0).ToString("yyyy-MM-dd")));
                str2 = str2 + string.Format(" and Birthday between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.ckxCreatedDate.Checked)
            {
               // str2 = !(this.dtpCreatedDateSt.Value.Date == this.dtpCreatedDateEd.Value.Date) ? (str2 + string.Format(" and CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"))) : (str2 + string.Format(" and CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateSt.Value.Date.AddDays(1.0).ToString("yyyy-MM-dd")));
                str2 = str2 + string.Format(" and CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            DataRowView selectedItem = this.cbxUser.SelectedItem as DataRowView;
            if (selectedItem == null)
            {
                return str2;
            }
            DataRow row = selectedItem.Row;
            if (row["ID"].ToString() == "-1")
            {
                return str2;
            }
            return (str2 + " and CreateBy = " + row["ID"].ToString() + " ");
        }

        public void InitEveryThing()
        {
            this.findModels = new List<RecordsBaseInfoModel>();
            this.bds = new BindingSource();
            string node = ConfigHelper.GetNode("orgCode");
            if (node.Length == 12)
            {
                this.dt_user = new SysUserBLL().GetList(" VillageID = " + new SysOrgVillangBLL().GetModel(node).ID).Tables[0];
            }
            else if (node.Length == 9)
            {
                this.dt_user = new SysUserBLL().GetList(" TownID = " + new SysOrgTownBLL().GetModel(node).ID).Tables[0];
            }
            else if (node.Length == 6)
            {
                this.dt_user = new SysOrgDistrictBLL().GetList(" DistrictID = " + new SysOrgDistrictBLL().GetModel(node).ID).Tables[0];
            }

            DataRow row = this.dt_user.NewRow();
            row.ItemArray = new object[] { -1, "ph", "不限" };
            this.dt_user.Rows.InsertAt(row, 0);
            this.cbxUser.ValueMember = "ID";
            this.cbxUser.DisplayMember = "USERNAME";
            this.cbxUser.DataSource = this.dt_user;
            this.EveryThingIsOk = true;
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpCreatedDateEd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ckxCreatedDate = new System.Windows.Forms.CheckBox();
            this.dtpCreatedDateSt = new System.Windows.Forms.DateTimePicker();
            this.cbxUser = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckBirthday = new System.Windows.Forms.CheckBox();
            this.dtpEd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpSt = new System.Windows.Forms.DateTimePicker();
            this.tbAddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdNum = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.身份证 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnFront = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lbPages = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lbTotalCount = new System.Windows.Forms.Label();
            this.btnChdCount = new System.Windows.Forms.Button();
            this.btnDiadetesCount = new System.Windows.Forms.Button();
            this.btnPertension = new System.Windows.Forms.Button();
            this.btnStrokeCount = new System.Windows.Forms.Button();
            this.btnMentaldisease = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dtpCreatedDateEd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ckxCreatedDate);
            this.groupBox1.Controls.Add(this.dtpCreatedDateSt);
            this.groupBox1.Controls.Add(this.cbxUser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ckBirthday);
            this.groupBox1.Controls.Add(this.dtpEd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpSt);
            this.groupBox1.Controls.Add(this.tbAddr);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIdNum);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(119, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // dtpCreatedDateEd
            // 
            this.dtpCreatedDateEd.Enabled = false;
            this.dtpCreatedDateEd.Location = new System.Drawing.Point(668, 68);
            this.dtpCreatedDateEd.Name = "dtpCreatedDateEd";
            this.dtpCreatedDateEd.Size = new System.Drawing.Size(135, 23);
            this.dtpCreatedDateEd.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(647, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "—";
            // 
            // ckxCreatedDate
            // 
            this.ckxCreatedDate.AutoSize = true;
            this.ckxCreatedDate.Location = new System.Drawing.Point(417, 70);
            this.ckxCreatedDate.Name = "ckxCreatedDate";
            this.ckxCreatedDate.Size = new System.Drawing.Size(89, 18);
            this.ckxCreatedDate.TabIndex = 6;
            this.ckxCreatedDate.Text = "建档日期:";
            this.ckxCreatedDate.UseVisualStyleBackColor = true;
            this.ckxCreatedDate.CheckedChanged += new System.EventHandler(this.ckxCreatedDate_CheckedChanged);
            // 
            // dtpCreatedDateSt
            // 
            this.dtpCreatedDateSt.Enabled = false;
            this.dtpCreatedDateSt.Location = new System.Drawing.Point(512, 68);
            this.dtpCreatedDateSt.Name = "dtpCreatedDateSt";
            this.dtpCreatedDateSt.Size = new System.Drawing.Size(135, 23);
            this.dtpCreatedDateSt.TabIndex = 7;
            // 
            // cbxUser
            // 
            this.cbxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUser.FormattingEnabled = true;
            this.cbxUser.Location = new System.Drawing.Point(715, 26);
            this.cbxUser.Name = "cbxUser";
            this.cbxUser.Size = new System.Drawing.Size(170, 22);
            this.cbxUser.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(653, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "建档人:";
            // 
            // ckBirthday
            // 
            this.ckBirthday.AutoSize = true;
            this.ckBirthday.Location = new System.Drawing.Point(15, 70);
            this.ckBirthday.Name = "ckBirthday";
            this.ckBirthday.Size = new System.Drawing.Size(89, 18);
            this.ckBirthday.TabIndex = 3;
            this.ckBirthday.Text = "出生日期:";
            this.ckBirthday.UseVisualStyleBackColor = true;
            this.ckBirthday.CheckedChanged += new System.EventHandler(this.ckBirthday_CheckedChanged);
            // 
            // dtpEd
            // 
            this.dtpEd.Enabled = false;
            this.dtpEd.Location = new System.Drawing.Point(266, 68);
            this.dtpEd.Name = "dtpEd";
            this.dtpEd.Size = new System.Drawing.Size(135, 23);
            this.dtpEd.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "—";
            // 
            // dtpSt
            // 
            this.dtpSt.Enabled = false;
            this.dtpSt.Location = new System.Drawing.Point(110, 68);
            this.dtpSt.Name = "dtpSt";
            this.dtpSt.Size = new System.Drawing.Size(135, 23);
            this.dtpSt.TabIndex = 4;
            // 
            // tbAddr
            // 
            this.tbAddr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbAddr.Location = new System.Drawing.Point(385, 25);
            this.tbAddr.MaxLength = 20;
            this.tbAddr.Name = "tbAddr";
            this.tbAddr.Size = new System.Drawing.Size(262, 23);
            this.tbAddr.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(337, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "住址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名或身份证:";
            // 
            // txtIdNum
            // 
            this.txtIdNum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIdNum.Location = new System.Drawing.Point(110, 26);
            this.txtIdNum.MaxLength = 18;
            this.txtIdNum.Name = "txtIdNum";
            this.txtIdNum.Size = new System.Drawing.Size(212, 23);
            this.txtIdNum.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(1029, 33);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(86, 82);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5,
            this.身份证,
            this.Column8,
            this.Column7,
            this.Column9});
            this.dgvData.Location = new System.Drawing.Point(119, 121);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(996, 465);
            this.dgvData.TabIndex = 102;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CustomerName";
            this.Column1.FillWeight = 42.90895F;
            this.Column1.HeaderText = "姓名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Sex";
            this.Column2.FillWeight = 40F;
            this.Column2.HeaderText = "性别";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Nation";
            this.Column3.FillWeight = 40F;
            this.Column3.HeaderText = "民族";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Birthday";
            this.Column4.FillWeight = 60F;
            this.Column4.HeaderText = "生日";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Phone";
            this.Column6.FillWeight = 80F;
            this.Column6.HeaderText = "电话";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "HouseHoldAddress";
            this.Column5.FillWeight = 95.36802F;
            this.Column5.HeaderText = "住址";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // 身份证
            // 
            this.身份证.DataPropertyName = "IDCardNo";
            this.身份证.FillWeight = 80F;
            this.身份证.HeaderText = "身份证";
            this.身份证.Name = "身份证";
            this.身份证.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "CreateDate";
            this.Column8.FillWeight = 70F;
            this.Column8.HeaderText = "建档日期";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "LastUpdateDate";
            this.Column7.FillWeight = 70F;
            this.Column7.HeaderText = "最后更新日期";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "BlueToothRecord";
            this.Column9.FillWeight = 50F;
            this.Column9.HeaderText = "体检数据";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // btnFront
            // 
            this.btnFront.Location = new System.Drawing.Point(921, 594);
            this.btnFront.Name = "btnFront";
            this.btnFront.Size = new System.Drawing.Size(94, 36);
            this.btnFront.TabIndex = 4;
            this.btnFront.Text = "上一页";
            this.btnFront.UseVisualStyleBackColor = true;
            this.btnFront.Click += new System.EventHandler(this.btnFront_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1021, 594);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(94, 36);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbPages
            // 
            this.lbPages.AutoSize = true;
            this.lbPages.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPages.Location = new System.Drawing.Point(820, 605);
            this.lbPages.Name = "lbPages";
            this.lbPages.Size = new System.Drawing.Size(58, 19);
            this.lbPages.TabIndex = 105;
            this.lbPages.Text = "1/1页";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(119, 594);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(94, 30);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(219, 594);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(94, 30);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lbTotalCount
            // 
            this.lbTotalCount.AutoSize = true;
            this.lbTotalCount.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTotalCount.Location = new System.Drawing.Point(705, 601);
            this.lbTotalCount.Name = "lbTotalCount";
            this.lbTotalCount.Size = new System.Drawing.Size(59, 19);
            this.lbTotalCount.TabIndex = 108;
            this.lbTotalCount.Text = "     ";
            // 
            // btnChdCount
            // 
            this.btnChdCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChdCount.Location = new System.Drawing.Point(1148, 121);
            this.btnChdCount.Name = "btnChdCount";
            this.btnChdCount.Size = new System.Drawing.Size(87, 42);
            this.btnChdCount.TabIndex = 109;
            this.btnChdCount.Text = "冠心病患者查询";
            this.btnChdCount.UseVisualStyleBackColor = true;
            this.btnChdCount.Click += new System.EventHandler(this.btnChdCount_Click);
            // 
            // btnDiadetesCount
            // 
            this.btnDiadetesCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDiadetesCount.Location = new System.Drawing.Point(1148, 193);
            this.btnDiadetesCount.Name = "btnDiadetesCount";
            this.btnDiadetesCount.Size = new System.Drawing.Size(87, 42);
            this.btnDiadetesCount.TabIndex = 110;
            this.btnDiadetesCount.Text = "糖尿病患者查询";
            this.btnDiadetesCount.UseVisualStyleBackColor = true;
            this.btnDiadetesCount.Click += new System.EventHandler(this.btnDiadetesCount_Click);
            // 
            // btnPertension
            // 
            this.btnPertension.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPertension.Location = new System.Drawing.Point(1148, 268);
            this.btnPertension.Name = "btnPertension";
            this.btnPertension.Size = new System.Drawing.Size(87, 42);
            this.btnPertension.TabIndex = 111;
            this.btnPertension.Text = "高血压患者查询";
            this.btnPertension.UseVisualStyleBackColor = true;
            this.btnPertension.Click += new System.EventHandler(this.btnPertension_Click);
            // 
            // btnStrokeCount
            // 
            this.btnStrokeCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStrokeCount.Location = new System.Drawing.Point(1148, 353);
            this.btnStrokeCount.Name = "btnStrokeCount";
            this.btnStrokeCount.Size = new System.Drawing.Size(87, 42);
            this.btnStrokeCount.TabIndex = 112;
            this.btnStrokeCount.Text = "脑卒中患者查询";
            this.btnStrokeCount.UseVisualStyleBackColor = true;
            this.btnStrokeCount.Click += new System.EventHandler(this.btnStrokeCount_Click);
            // 
            // btnMentaldisease
            // 
            this.btnMentaldisease.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMentaldisease.Location = new System.Drawing.Point(1148, 429);
            this.btnMentaldisease.Name = "btnMentaldisease";
            this.btnMentaldisease.Size = new System.Drawing.Size(87, 57);
            this.btnMentaldisease.TabIndex = 113;
            this.btnMentaldisease.Text = "重性精神疾病患者查询";
            this.btnMentaldisease.UseVisualStyleBackColor = true;
            this.btnMentaldisease.Click += new System.EventHandler(this.btnMentaldisease_Click);
            // 
            // FrmViewData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 640);
            this.Controls.Add(this.btnMentaldisease);
            this.Controls.Add(this.btnStrokeCount);
            this.Controls.Add(this.btnPertension);
            this.Controls.Add(this.btnDiadetesCount);
            this.Controls.Add(this.btnChdCount);
            this.Controls.Add(this.lbTotalCount);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lbPages);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFront);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmViewData";
            this.Text = "FrmViewData";
            this.Load += new System.EventHandler(this.FrmViewData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            return true;
        }

        private void TransDs(DataSet ds)
        {
            ds.Tables[0].Columns.Add("BlueToothRecord");
            DeviceInfoBLL ARCHIVE_DEVICEINFO = new DeviceInfoBLL();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
                row["Nation"] = !(row["Nation"].ToString() == "1") ? row["MINORITY"] : "汉";
                if (ARCHIVE_DEVICEINFO.GetRecordCount(string.Format(" IDCardNo = '{0}'", row["IDCardNo"])) > 0)
                {
                    row["BlueToothRecord"] = "检测数据";
                }
            }
        }
        private void btnChdCount_Click(object sender, EventArgs e) //冠心病患者查询
        {
            this.dgvData.DataSource = null;
            ChronicChdVisitBLL chronicChdVisit = new ChronicChdVisitBLL();
            DataTable dt = chronicChdVisit.DtChdCount().Tables[0];
            getDisease(dt);
        }

        private void btnDiadetesCount_Click(object sender, EventArgs e) //糖尿病患者查询
        {
            this.dgvData.DataSource = null;
            ChronicDiadetesVisitBLL chronicDiadetesVisit = new ChronicDiadetesVisitBLL();
            DataTable dt = chronicDiadetesVisit.DtDiadetesCount().Tables[0];
            getDisease(dt);
        }

        private void btnPertension_Click(object sender, EventArgs e) //高血压患者查询
        {
            this.dgvData.DataSource = null;
            ChronicHypertensionVisitBLL chronicHypertensionVisit = new ChronicHypertensionVisitBLL();
            DataTable dt = chronicHypertensionVisit.DtPertensionCount().Tables[0];
            getDisease(dt);
        }

        private void btnStrokeCount_Click(object sender, EventArgs e) //脑卒中患者查询
        {
            this.dgvData.DataSource = null;
            ChronicStrokeVisitBLL chronicStrokeVisit = new ChronicStrokeVisitBLL();
            DataTable dt = chronicStrokeVisit.DtStrokeCount().Tables[0];
            getDisease(dt);
        }

        private void btnMentaldisease_Click(object sender, EventArgs e) //重性精神疾病患者查询
        {
            this.dgvData.DataSource = null;
            ChronicMentalDiseaseVisitBLL chronicMentalDiseaseVisit = new ChronicMentalDiseaseVisitBLL();
            DataTable dt = chronicMentalDiseaseVisit.DtMentaldiseaseCount().Tables[0];
            getDisease(dt);
        }
        private void getDisease(DataTable dt)
        {
            if (this.ckBirthday.Checked && (this.dtpSt.Value.Date > this.dtpEd.Value.Date))
            {
                MessageBox.Show(" 出生日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.ckxCreatedDate.Checked && (this.dtpCreatedDateSt.Value.Date > this.dtpCreatedDateEd.Value.Date))
            {
                MessageBox.Show(" 建档日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                totalCount = 0;
                string where = "";
                DataTable dtbaseinfo = new RecordsBaseInfoBLL().dtbaseinfo().Tables[0];
                DataSet ds = new DataSet();
                DataSet dss = new DataSet();
                RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
                int count = dt.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    foreach (DataRow r in dtbaseinfo.Rows)
                    {
                        string idCardNo = r["IDCardNo"].ToString();
                        if (dt.Rows[i][0].ToString() == idCardNo)
                        {
                            Model.IDCardNo = idCardNo;
                            string str1 = this.GetWhere();
                            string str2 = "and IDCardNo = '" + Model.IDCardNo + "'";
                            where = str1 + str2;
                            this.totalCount = totalCount + archive_baseinfo.GetRecordCount(where);
                            ds = archive_baseinfo.GetListByPage(where, "", 0, this.pageCount);
                            dss.Merge(ds);
                        }
                    }
                }

                this.totalPages = (this.totalCount <= this.pageCount) ? 1 : ((this.totalCount / this.pageCount) + (((this.totalCount % this.pageCount) > 0) ? 1 : 0));
                this.currentPage = 0;
                this.lbTotalCount.Text = string.Format("共计{0}条", this.totalCount.ToString());
                this.lbPages.Text = string.Format("{0}/{1}页", this.currentPage + 1, this.totalPages);
                if (dss.Tables.Count > 0)
                {
                    this.TransDs(dss);
                    this.bds.DataSource = dss.Tables[0];
                    this.dgvData.DataSource = this.bds;
                }
                this.groupBox1.Enabled = false;
            }
        }
        public void UpdataToModel()
        {
        }

        public bool EveryThingIsOk { get; set; }

        private List<RecordsBaseInfoModel> findModels { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

     

      
    }
}

