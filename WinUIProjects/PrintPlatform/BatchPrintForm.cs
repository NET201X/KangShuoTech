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
    public partial class BatchPrintForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        public BatchPrintForm()
        {
            InitializeComponent();
            this.dgvData.AutoGenerateColumns = false;
            this.EveryThingIsOk = false;
            this.HaveToSave = false;
        }

        private List<RecordsBaseInfoModel> findModels { get; set; }
        private BindingSource bds;
        private DataTable dt_user;
        public Process BatchProcess;
        private int totalCount;
        private int totalPages;
        private int currentPage;
        private int pageCount = 10;

        public string IDCardNo { get; set; }

        public RecordsBaseInfoModel Model
        {
            get;
            set;
        }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        public void InitEveryThing()
        {
            this.findModels = new List<RecordsBaseInfoModel>();
            this.bds = new BindingSource();
            //string node = ConfigHelper.GetNode("orgCode");
            //if (node.Length == 12)
            //{
            //    this.dt_user = new SysUserBLL().GetList(" VillageID = " + new SysOrgVillangBLL().GetModel(node).ID).Tables[0];
            //}
            //else if (node.Length == 9)
            //{
            //    this.dt_user = new SysUserBLL().GetList(" TownID = " + new SysOrgTownBLL().GetModel(node).ID).Tables[0];
            //}
            //else if (node.Length == 6)
            //{
            //    this.dt_user = new SysOrgDistrictBLL().GetList(" DistrictID = " + new SysOrgDistrictBLL().GetModel(node).ID).Tables[0];
            //}
            //DataRow row = this.dt_user.NewRow();
            //row.ItemArray = new object[] { -1, "ph", "不限" };
            //this.dt_user.Rows.InsertAt(row, 0);
            //this.cbxUser.ValueMember = "ID";
            //this.cbxUser.DisplayMember = "USERNAME";
            //this.cbxUser.DataSource = this.dt_user;
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
            DataTable dt_Town=new RecordsCustomerBaseInfoBLL().GetTownList().Tables[0];
            if (dt_Town.Rows.Count > 0)
            {
                DataRow row = dt_Town.NewRow();
                row.ItemArray = new object[] { "不限" };
                dt_Town.Rows.InsertAt(row, 0);
                this.cbxTown.DisplayMember = "TownName";
                this.cbxTown.DataSource = dt_Town;
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

        private void BatchPrintForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string idCardNo = "";

            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                if ((bool)dgvData.Rows[i].Cells[0].EditedFormattedValue)
                {
                    idCardNo += dgvData.Rows[i].Cells[7].Value + ";";
                }
            }

            if (idCardNo.Length > 0)
            {
                idCardNo = idCardNo.Substring(0, idCardNo.Length - 1);

                BatchProcess = new Process { StartInfo = { FileName = @"NewPrint.exe", Arguments = idCardNo } };
                BatchProcess.Start();
            }
            else
            {
                MessageBox.Show("请选择要打印档案资料！");
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
                if (string.IsNullOrEmpty(where))
                {
                    MessageBox.Show("请选择查询条件！", "查询条件", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.btnQuery.Enabled = true;
                }
                else
                {
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
                str2 = str2 + string.Format(" and T.CreateMenName = '{0}' ", this.cbxUser.Text.ToString());
            }
            if (this.cbxTown.Text != "不限")
            {
                str2 = str2 + string.Format(" and T.TownName  LIKE '%{0}%' ", this.cbxTown.Text.ToString());
            }
            if (this.cbxVillage.Text != "不限"&&this.cbxVillage.Text!="")
            {
                str2 = str2 + string.Format(" and T.VillageName  LIKE '%{0}%' ", this.cbxVillage.Text.ToString());
            }
            return str2;
        }

        private void TransDs(DataSet ds)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
                row["Nation"] = !(row["Nation"].ToString() == "1") ? row["MINORITY"] : "汉";
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((bool)dgvData.Rows[e.RowIndex].Cells[0].EditedFormattedValue == true)
            {
                dgvData.Rows[e.RowIndex].Cells[0].Value = false;
            }
            else
            {
                dgvData.Rows[e.RowIndex].Cells[0].Value = true;
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                //设置设置每一行的选择框为选中，第一列为checkbox
                dgvData.Rows[i].Cells[0].Value = true;
            }
        }

        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                //设置设置每一行的选择框为选中，第一列为checkbox
                dgvData.Rows[i].Cells[0].Value = false;
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

        private void cbxTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbxTown.Text))
            {
                string strwhere = string.Format("and TownName LIKE '%{0}%'", cbxTown.Text);
                DataTable dt_Village = new RecordsCustomerBaseInfoBLL().GetVillageList(strwhere).Tables[0];
                if (dt_Village.Rows.Count > 0)
                {
                    DataRow row = dt_Village.NewRow();
                    row.ItemArray = new object[] { "不限" };
                    dt_Village.Rows.InsertAt(row, 0);
                    this.cbxVillage.DisplayMember = "VillageName";
                    this.cbxVillage.DataSource = dt_Village;
                }
                else
                {
                    this.cbxVillage.DataSource = null;
                }
            }
        }
    }
}
