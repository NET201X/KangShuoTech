using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FocusGroup.ChronicDisease;
using FocusGroup.OldPeople;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonUI;
using FocusGroup;

namespace OverView
{
    public partial class frmNoVisit : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private int pageCount = 10;
        private int totalCount;
        private int totalPages;
        private int currentPage;
        private BindingSource bds;
        private List<RecordsBaseInfoModel> findModels { get; set; }
        private DataTable dt_user;
        private string restrict = ConfigurationManager.AppSettings["Restrict"];
        private DataTable dtTmp;

        public frmNoVisit()
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


        private void frmNoVisit_Load(object sender, EventArgs e)
        {

            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.currentPage < (this.totalPages - 1))
            {
                this.lbPages.Text = string.Format("{0}/{1}页", ++this.currentPage + 1, this.totalPages);
                DataSet ds = new RecordsBaseInfoBLL().GetNoVisitListByPage(this.GetWhere(), "", this.currentPage * this.pageCount, this.pageCount);

                if (ds.Tables.Count > 0)
                {
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
                DataSet ds = new RecordsBaseInfoBLL().GetNoVisitListByPage(this.GetWhere(), "", this.currentPage * this.pageCount, this.pageCount);
                if (ds.Tables.Count > 0)
                {
                    this.bds.DataSource = ds.Tables[0];
                    this.dgvData.DataSource = this.bds;
                }
            }
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
                RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
                DataSet ds = archive_baseinfo.GetNoVistRecordCount(where, "", "");
                if (ds.Tables.Count > 0)
                {
                    dtTmp = ds.Tables[0];
                }
                this.totalCount = dtTmp.Rows.Count;
                this.totalPages = (this.totalCount <= this.pageCount) ? 1 : ((this.totalCount / this.pageCount) + (((this.totalCount % this.pageCount) > 0) ? 1 : 0));
                this.currentPage = 0;
                this.lbTotalCount.Text = string.Format("共计{0}条", this.totalCount.ToString());

                this.lbPages.Text = string.Format("{0}/{1}页", this.currentPage + 1, this.totalPages);

                if (ds.Tables.Count > 0)
                {

                    DataTable dtTemp = dtTmp.Clone();
                    int nextV = (this.currentPage + 1) * this.pageCount;

                    if (nextV > this.totalCount)
                    {
                        nextV = this.totalCount;
                    }

                    for (int i = (this.currentPage) * this.pageCount; i < nextV; i++)
                    {
                        dtTemp.ImportRow(dtTmp.Rows[i]);
                    }

                    this.bds.DataSource = dtTemp;
                    this.dgvData.DataSource = this.bds;
                }

                this.groupBox1.Enabled = false;
                this.btnQuery.Text = "重置条件";

                lblOldManCount.Text = archive_baseinfo.GetOLDNoVisitCount(where, "") + " 人";
                lblHypCount.Text = archive_baseinfo.GetHyperNoVisitCount(where, "") + " 人";
                lblDiaCount.Text = archive_baseinfo.GetDiaNoVisitCount(where, "") + " 人";
                lblPsyCount.Text = archive_baseinfo.GetMentalNoVisitCount(where, "") + " 人";
                lblTbCount.Text = archive_baseinfo.GetLungerNoVisitCount(where, "") + " 人";
                lblNczCount.Text = archive_baseinfo.GetStrokeNoVisitCount(where, "") + " 人";
                lblHeaCount.Text = archive_baseinfo.GetChdNoVisitCount(where, "") + " 人";
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

            if (this.ckBirthday.Checked)
            {
                str2 = str2 + string.Format(" and T.Birthday between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
            }

            if (this.ckxCreatedDate.Checked)
            {
                str2 = str2 + string.Format(" and T.CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
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

            return (str2 + " and T.CreateBy = " + row["ID"].ToString() + " ");
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView view = (DataRowView)this.bds.List[this.bds.Position];
            string idNo = view.Row["IDCardNo"].ToString();

            //老年人
            if (e.ColumnIndex == dgvData.Columns[1].Index)
            {
                using (Controler controler2 = new Controler(new MDIParentForm(idNo), new OldPeopleInfoFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }

            //高血压
            else if (e.ColumnIndex == dgvData.Columns[2].Index)
            {
                using (Controler controler2 = new Controler(new HypForm(idNo), new HypFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }

            //糖尿病
            else if (e.ColumnIndex == dgvData.Columns[3].Index)
            {

                using (Controler controler2 = new Controler(new MDIParentForm(idNo), new DiaFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }

            }

            //精神疾病
            else if (e.ColumnIndex == dgvData.Columns[4].Index)
            {
                using (Controler controler2 = new Controler(new MDIParentForm(idNo), new MentalFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }

            //肺结核
            else if (e.ColumnIndex == dgvData.Columns[5].Index)
            {
                using (Controler controler2 = new Controler(new MDIParentForm(idNo), new DiaFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }

            //脑卒中
            else if (e.ColumnIndex == dgvData.Columns[6].Index)
            {
                using (Controler controler2 = new Controler(new MDIParentForm(idNo), new StrokeFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }

            //冠心病
            else if (e.ColumnIndex == dgvData.Columns[7].Index)
            {
                using (Controler controler2 = new Controler(new MDIParentForm(idNo), new CHDFactory()))
                {
                    controler2.IParentFrm.IShowDialog();
                }
            }
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataRowView view = (DataRowView)this.bds.List[e.RowIndex];
            string populationType = view.Row["PopulationType"].ToString();

            //老年人
            if ((dgvData["oldMan", e.RowIndex].Value.ToString() == "" && populationType.IndexOf("4") < 0))
            {
                dgvData["oldMan", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["oldMan", e.RowIndex].Value = "";
            }

            //高血压
            if ((dgvData["hyp", e.RowIndex].Value.ToString() == "" && populationType.IndexOf("6") < 0))
            {
                dgvData["hyp", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["hyp", e.RowIndex].Value = "";
            }

            //糖尿病
            if ((dgvData["dia", e.RowIndex].Value.ToString() == "" && populationType.IndexOf("7") < 0))
            {
                dgvData["dia", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["dia", e.RowIndex].Value = "";
            }

            //精神疾病
            if ((dgvData["psy", e.RowIndex].Value.ToString() == "" && populationType.IndexOf("5") < 0))
            {
                dgvData["psy", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["psy", e.RowIndex].Value = "";
            }

            //肺结核
            if ((dgvData["tb", e.RowIndex].Value.ToString() == "" && populationType.IndexOf("10") < 0))
            {
                dgvData["tb", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["tb", e.RowIndex].Value = "";
            }

            //脑卒中
            if ((dgvData["ncz", e.RowIndex].Value.ToString() == "" && populationType.IndexOf("9") < 0))
            {
                dgvData["ncz", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["ncz", e.RowIndex].Value = "";
            }

            //冠心病
            if ((dgvData["hea", e.RowIndex].Value.ToString() == "" && populationType.IndexOf("8") < 0))
            {
                dgvData["hea", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["hea", e.RowIndex].Value = "";
            }
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }
    }
}
