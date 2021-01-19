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
using System.Text.RegularExpressions;

namespace ArchiveInfo
{
    public partial class RecordQueryForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private int currentPage;
        private int totalPages;
        private int totalCount;
        private int pageCount = 10;
        private BindingSource bds;
        private DataTable dt_user;

        public RecordQueryForm()
        {
            InitializeComponent();
            this.dgvData.AutoGenerateColumns = false;
            this.EveryThingIsOk = false;
            this.HaveToSave = false;
        }

        public RecordsBaseInfoModel Model { get; set; }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        public void InitEveryThing()
        {

            this.bds = new BindingSource();
            this.dt_user = new RecordsBaseInfoBLL().GetUserDt("").Tables[0];
            if (this.dt_user.Rows.Count > 0)
            {
                DataRow row = this.dt_user.NewRow();
                row.ItemArray = new object[] { "不限", 0, "" };
                this.dt_user.Rows.InsertAt(row, 0);
                this.cbxUser.ValueMember = "ID";
                this.cbxUser.DisplayMember = "CreateMenName";
                this.cbxUser.DataSource = this.dt_user;
            }
            this.EveryThingIsOk = true;
        }

        public bool SaveModelToDB()
        {
            return false;
        }

        public void NotisfyChildStatus()
        {

        }

        public void UpdataToModel()
        {

        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }
        public List<RecordsIllnessHistoryInfoModel> IllnessHistoryInfo { get; set; }

        private string GetWhere()
        {
            string input = this.txtIdNum.Text.Trim();
            string str2 = "";
            if (input != "")
            {
                str2 = !Regex.IsMatch(input, @"^\d{15}") ? string.Format(" and T.CustomerName like '%{0}%'", input) : ("and T.IDCardNo LIKE '%" + input + "%'");
            }
            if (!string.IsNullOrEmpty(this.tbAddr.Text.Trim()))
            {
                str2 = str2 + string.Format(" and T.HouseHoldAddress LIKE '%{0}%' ", this.tbAddr.Text.Trim());
            }
            if (this.ckCheckDate.Checked)
            {
                str2 = str2 + string.Format(" and B.CheckDate between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.ckxCreatedDate.Checked)
            {
                str2 = str2 + string.Format(" and T.CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.cbxUser.Text != "不限")
            {
                str2 = str2 + string.Format(" and T.CreateMenName = '{0}' ", this.cbxUser.Text.ToString()); 
            }
            if (this.cmbxx.Text != "不限")
            {
                if (this.cmbxx.Text == "不详")
                {
                    str2 = str2 + string.Format(" and (T.BloodType is null or T.BloodType='' )");
                }
                else
                {
                    str2 = str2 + string.Format(" and T.BloodType = '{0}' ", this.cmbxx.SelectedIndex.ToString()); 
                }
            }
            return str2;
        }
        private void TransDs(DataSet ds)
        {

            DeviceInfoBLL ARCHIVE_DEVICEINFO = new DeviceInfoBLL();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
                row["Nation"] = !(row["Nation"].ToString() == "1") ? row["MINORITY"] : "汉族";
            }
        }
        private void ChackDate()
        {
            string where = this.GetWhere();
            this.btnQuery.Enabled = false;
            if (string.IsNullOrEmpty(where))
            {
                MessageBox.Show("请选择查询条件！", "查询条件", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.btnQuery.Enabled = true;
            }
            else
            {
                RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
                this.totalCount = archive_baseinfo.GetRecordCount(where);
                this.totalPages = (this.totalCount <= this.pageCount) ? 1 : ((this.totalCount / this.pageCount) +
                   (((this.totalCount % this.pageCount) > 0) ? 1 : 0));
                this.lbTotalCount.Text = string.Format("共计{0}条", this.totalCount.ToString());
                if (this.currentPage > totalPages - 1) this.currentPage--;

                DataSet ds = archive_baseinfo.GetListByPage(where, "", this.currentPage * this.pageCount, this.pageCount);
                this.lbPages.Text = string.Format("{0}/{1}页", this.currentPage + 1, this.totalPages);
                if (ds.Tables.Count > 0)
                {
                    this.TransDs(ds);
                    this.bds.DataSource = ds.Tables[0];
                    this.dgvData.DataSource = this.bds;
                }
                this.groupBox1.Enabled = false;
                this.btnQuery.Enabled = true;
                this.btnQuery.Text = "重置条件";
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
            else if (this.ckCheckDate.Checked && (this.dtpSt.Value.Date > this.dtpEd.Value.Date))
            {
                MessageBox.Show(" 体检日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.ckxCreatedDate.Checked && (this.dtpCreatedDateSt.Value.Date > this.dtpCreatedDateEd.Value.Date))
            {
                MessageBox.Show(" 建档日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.currentPage = 0;
                ChackDate();
            }
        }

        private void RecordQueryForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.cmbxx.SelectedIndex = 0;
                this.InitEveryThing();
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.bds.Position >= 0) && (e.RowIndex >= 0))
            {
                DataRowView view = (DataRowView)this.bds.List[this.bds.Position];
                if (((this.dgvData.Columns[e.ColumnIndex].HeaderText == "修改") && (this.bds.Position >= 0)) && (e.RowIndex >= 0))
                {
                    using (PBControler controler = new PBControler(new PersonForm(view.Row["IDCardNo"].ToString()), new PersonInfoFactory()))
                    {
                        controler.IParentFrm.IShowDialog();
                        ChackDate();
                    }
                    GC.Collect();
                }
                else if (((this.dgvData.Columns[e.ColumnIndex].HeaderText == "删除") && (this.bds.Position >= 0)) && (e.RowIndex >= 0))
                {
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
                               // row.Delete();
                               // row.Table.AcceptChanges();
                               ChackDate();
                            }
                        }
                        else if (MessageBox.Show("确定删除:" + row["CustomerName"].ToString() + "？删除之后的信息将无法恢复!", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            new RecordsBaseInfoBLL().DelTheMan(row["IDCardNo"].ToString());
                            row.Delete();
                            row.Table.AcceptChanges();
                            ChackDate();
                        }
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.currentPage < (this.totalPages - 1))
            {
                this.lbPages.Text = string.Format("{0}/{1}页", ++this.currentPage + 1, this.totalPages);
                DataSet ds = new RecordsBaseInfoBLL().GetListByPage(this.GetWhere(), "B.CheckDate desc ,B.ID ASC", this.currentPage * this.pageCount, this.pageCount);
                if (ds.Tables.Count > 0)
                {
                    this.TransDs(ds);
                    this.bds.DataSource = ds.Tables[0];
                    this.dgvData.DataSource = this.bds;
                }
            }
        }

        private void btnFront_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 0)
            {
                this.lbPages.Text = string.Format("{0}/{1}页", --this.currentPage + 1, this.totalPages);
                DataSet ds = new RecordsBaseInfoBLL().GetListByPage(this.GetWhere(), "B.CheckDate desc ,B.ID ASC", this.currentPage * this.pageCount, this.pageCount);
                if (ds.Tables.Count > 0)
                {
                    this.TransDs(ds);
                    this.bds.DataSource = ds.Tables[0];
                    this.dgvData.DataSource = this.bds;
                }
            }
        }

        private void ckCheckDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpSt.Enabled = this.ckCheckDate.Checked;
            this.dtpEd.Enabled = this.ckCheckDate.Checked;
        }

        private void ckxCreatedDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpCreatedDateSt.Enabled = this.ckxCreatedDate.Checked;
            this.dtpCreatedDateEd.Enabled = this.ckxCreatedDate.Checked;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
