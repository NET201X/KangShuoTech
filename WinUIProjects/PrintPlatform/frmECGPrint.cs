using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonUI;

namespace PrintPlatform
{
    public partial class frmECGPrint : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private List<RecordsBaseInfoModel> findModels { get; set; }
        private BindingSource bds;
        private DataTable dt_user;
        public Process BatchProcess;
        private int totalCount;
        private int totalPages;
        private int currentPage;
        private int pageCount = 18;

        public frmECGPrint()
        {
            InitializeComponent();
            this.dgvData.AutoGenerateColumns = false;
            this.EveryThingIsOk = false;
            this.HaveToSave = false;
        }
     
        public RecordsBaseInfoModel Model
        {
            get;
            set;
        }

        public ChildFormStatus CheckErrorInput()
        {
            throw new NotImplementedException();
        }
        private void btnFront_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 0)
            {
                this.lbPages.Text = string.Format("{0}/{1}页", --this.currentPage + 1, this.totalPages);
                DataSet ds = new RecordsEcgBLL().GetListByPage(this.GetWhere(), "", this.currentPage * this.pageCount, this.pageCount);
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
                DataSet ds = new RecordsEcgBLL().GetListByPage(this.GetWhere(), "", this.currentPage * this.pageCount, this.pageCount);
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
                this.btnQuery.Enabled = false;
                string where = this.GetWhere();
                this.lbTotalCount.Text = "";
                if (string.IsNullOrEmpty(where))
                {
                    MessageBox.Show("请选择查询条件！", "查询条件", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.btnQuery.Enabled = true;
                }
                else
                {
                    RecordsEcgBLL archive_baseinfo = new RecordsEcgBLL();
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
        }
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
                // str2 = !(this.dtpSt.Value.Date == this.dtpEd.Value.Date) ? (str2 + string.Format(" and Birthday between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"))) : (str2 + string.Format(" and Birthday between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpSt.Value.Date.AddDays(1.0).ToString("yyyy-MM-dd")));
                str2 = str2 + string.Format(" and  B.CheckDate between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.ckxCreatedDate.Checked)
            {
                // str2 = !(this.dtpCreatedDateSt.Value.Date == this.dtpCreatedDateEd.Value.Date) ? (str2 + string.Format(" and CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"))) : (str2 + string.Format(" and CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateSt.Value.Date.AddDays(1.0).ToString("yyyy-MM-dd")));
                str2 = str2 + string.Format(" and T.CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
            }

            if (this.cbxUser.Text != "不限")
            {
                if (string.IsNullOrEmpty(this.cbxUser.Text.ToString()))
                {
                    str2 = str2 + string.Format(" and T.CreateMenName is null ");
                }
                else
                {
                    str2 = str2 + string.Format(" and T.CreateMenName = '{0}' ", this.cbxUser.Text.ToString());
                }
            }
            return str2;
        }
        private void TransDs(DataSet ds)
        {
            ds.Tables[0].Columns.Add("MIDName");
            RecordsEcgBLL recordsEcgBll = new RecordsEcgBLL();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row["CustomerName"] = row["CustomerName"].ToString().Trim();
                row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
                row["Nation"] = !(row["Nation"].ToString() == "1") ? row["MINORITY"] : "汉";
                if (recordsEcgBll.GetMIDCount(row["IDCardNo"].ToString()) > 0)
                {
                    row["MIDName"] = "心电图";
                }
            }
        }
        public void InitEveryThing()
        {
            this.bds = new BindingSource();
            this.dt_user = new RecordsEcgBLL().GetUserDt("").Tables[0];
            if (this.dt_user.Rows.Count > 0)
            {
                DataRow row = this.dt_user.NewRow();
                row.ItemArray = new object[] { "不限" };
                this.dt_user.Rows.InsertAt(row, 0);
                this.cbxUser.ValueMember = "ID";
                this.cbxUser.DisplayMember = "CreateMenName";
                this.cbxUser.DataSource = this.dt_user;
            }
            this.EveryThingIsOk = true;
        }
        private void frmECGPrint_Load(object sender, EventArgs e)
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

        public bool EveryThingIsOk
        {
            get;
            set;
        }

        public bool HaveToSave
        {
            get;
            set;
        }

        public string SaveDataInfo
        {
            get;
            set;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((this.dgvData.Columns[e.ColumnIndex].HeaderText == "心电图") && (this.bds.Position >= 0)) && (e.RowIndex >= 0))
            {
                DataRowView view = (DataRowView)this.bds.List[this.bds.Position];
                if (this.dgvData[e.ColumnIndex, this.bds.Position].Value.ToString() == "心电图")
                {
                    ECGShow data = new ECGShow
                    {
                        MID = view.Row["MID"].ToString()
                    };
                    data.StartPosition = FormStartPosition.CenterParent;
                    data.ShowDialog();
                }
            }
        }
      
    }
}
