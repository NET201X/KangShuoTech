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

namespace MedicalService
{
    public partial class DataListSearch : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private int currentPage;
        private int totalPages;
        private int totalCount;
        private int pageCount = 10;
        private BindingSource bds;
        private DataTable dt_user;
        private DataTable dtTmp;
        private string RecordsName;
        InterfaceDataList archive_baseinfo = new ReceiveTreatBaseInfoBLL();
        public DataListSearch(string str)
        {
            InitializeComponent();
            RecordsName = str;
            if (this.RecordsName == "接诊记录")
            {
                archive_baseinfo = new ReceiveTreatBaseInfoBLL();
                this.ckCheckDate.Text = "接诊日期";
                this.dgvData.Columns[7].HeaderText = "接诊日期";
            }
            else if (this.RecordsName == "会诊记录")
            {
                archive_baseinfo = new ConsulationBaseInfoBLL();
                this.ckCheckDate.Text = "会诊日期";
                this.dgvData.Columns[7].HeaderText = "会诊日期";
            }
            else if (this.RecordsName == "转诊记录")
            {
                archive_baseinfo = new ReferraBaseInfoBLL();
                this.ckCheckDate.Text = "转诊日期";
                this.dgvData.Columns[7].HeaderText = "转诊日期";
            }
            this.dgvData.AutoGenerateColumns = false;
           
            this.EveryThingIsOk = false;
        }
        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
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
                string where = this.GetWhere();
                if (string.IsNullOrEmpty(where))
                {
                    MessageBox.Show("请选择查询条件！", "查询条件", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
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
                    this.groupBox1.Enabled = false;
                    this.btnQuery.Text = "重置条件";
                }
            }
        }

        private void btnFront_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 0)
            {
                this.lbPages.Text = string.Format("{0}/{1}页", --this.currentPage + 1, this.totalPages);
                DataSet ds = archive_baseinfo.GetListByPage(this.GetWhere(), "", this.currentPage * this.pageCount, this.pageCount);
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
                DataSet ds = archive_baseinfo.GetListByPage(this.GetWhere(), "", this.currentPage * this.pageCount, this.pageCount);
                if (ds.Tables.Count > 0)
                {
                    this.TransDs(ds);
                    this.bds.DataSource = ds.Tables[0];
                    this.dgvData.DataSource = this.bds;
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.bds.Position >= 0)
            {
                DataRowView view = this.bds.List[this.bds.Position] as DataRowView;
                if (view != null)
                {
                    DataRow row = view.Row;
                    if (MessageBox.Show("确定删除:" + row["CustomerName"].ToString() + "？删除之后的信息将无法恢复!", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        archive_baseinfo.Delete(Convert.ToInt32(row["ID"].ToString()));
                        
                        row.Delete();
                        row.Table.AcceptChanges();
                    }
                }
            }
        }
        private void DataListSearch_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
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
        private void TransDs(DataSet ds)
        {
            ds.Tables[0].Columns.Add("UpdateData");
            DeviceInfoBLL ARCHIVE_DEVICEINFO = new DeviceInfoBLL();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
                row["UpdateData"] = "修改";
                //if (ARCHIVE_DEVICEINFO.GetRecordCount(string.Format(" IDCardNo = '{0}'", row["IDCardNo"])) > 0)
                //{
                //    row["BlueToothRecord"] = this.RecordsName;
                //}
            }
        }
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.bds.Position >= 0) && (e.RowIndex >= 0))
            {
                DataRowView view = (DataRowView)this.bds.List[this.bds.Position];
                
                if (((this.dgvData.Columns[e.ColumnIndex].HeaderText == "修改") && (this.bds.Position >= 0)) && (e.RowIndex >= 0))
                {

                    new Controler(new MDIParentForm(view.Row["IDCardNo"].ToString()), new ModifyFactory(int.Parse(view.Row["ID"].ToString()), RecordsName)).IParentFrm.IShowDialog();
                }
            }
        }
        private string GetWhere()
        {
            string input = this.txtIdNum.Text.Trim();
            string str2 = "";
            if (input != "")
            {
                str2 = !Regex.IsMatch(input, "^[0-9]*$") ? string.Format(" and T.CustomerName like '%{0}%'", input) : ("and T.IDCardNo LIKE '%" + input + "%'");
            }
            if (!string.IsNullOrEmpty(this.tbAddr.Text.Trim()))
            {
                str2 = str2 + string.Format(" and T.HouseHoldAddress LIKE '%{0}%' ", this.tbAddr.Text.Trim());
            }
            if (this.ckCheckDate.Checked)
            {
                if (this.RecordsName == "接诊记录")
                {
                    str2 = str2 + string.Format(" and C.ReceiveDate between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
                }
                else if (this.RecordsName == "会诊记录")
                {
                    str2 = str2 + string.Format(" and C.ConsultationDate between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
                }
                else if (this.RecordsName == "转诊记录")
                {
                    str2 = str2 + string.Format(" and R.TranseDate between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
                }
            }
            if (this.ckxCreatedDate.Checked)
            {
                str2 = str2 + string.Format(" and T.CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.cbxUser.Text != "不限")
            {
                str2 = str2 + string.Format(" and T.CreateMenName = '{0}' ", this.cbxUser.Text.ToString());
            }

            return str2;
        }
        public void InitEveryThing()
        {
            this.findModels = new List<RecordsBaseInfoModel>();
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
            return true;
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

        public RecordsBaseInfoModel Model { get; set; }

        private List<RecordsBaseInfoModel> findModels { get; set; }


    }
}
