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
using KangShuoTech.Utilities.CommonUI;
using FocusGroup;

namespace OverView
{
    public partial class frmNeverVisit : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private int pageCount = 9;
        private int totalCount;
        private int totalPages;
        private int currentPage;
        private BindingSource bds;
        private List<RecordsBaseInfoModel> findModels { get; set; }
        private DataTable dt_user;
        private string Restriction = ConfigurationManager.AppSettings["Restriction"];
        private DataTable dtTmp;

        public frmNeverVisit()
        {
            InitializeComponent();
            this.dgvData.AutoGenerateColumns = false;
            this.EveryThingIsOk = false;
            this.HaveToSave = false;
        }

        public ChildFormStatus CheckErrorInput()
        {
            throw new NotImplementedException();
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

        public RecordsBaseInfoModel Model
        {
            get;
            set;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.currentPage < (this.totalPages - 1))
            {
                this.lbPages.Text = string.Format("{0}/{1}页", ++this.currentPage + 1, this.totalPages);
                if (dtTmp.Rows.Count > 0)
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
            }
        }

        private void btnFront_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 0)
            {
                this.lbPages.Text = string.Format("{0}/{1}页", --this.currentPage + 1, this.totalPages);
                if (dtTmp.Rows.Count > 0)
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
                string CheckDate = "";
                if (this.ckCheckDate.Checked)
                {
                    CheckDate = string.Format(" and T.CheckDate between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
                }
                if (string.IsNullOrEmpty(where) && string.IsNullOrEmpty(CheckDate))
                {
                    MessageBox.Show("请选择查询条件！", "查询条件", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    this.btnQuery.Enabled = false;
                    RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();

                    DataSet ds = archive_baseinfo.GetNoVistRecordCount(where, CheckDate, "");
                    if (ds.Tables.Count > 0)
                    {
                        dtTmp = TransDs(ds);
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

                    lblOldManCount.Text = archive_baseinfo.GetOLDNoVisitCount(where, CheckDate) + " 人";
                    lblHypCount.Text = archive_baseinfo.GetHyperNoVisitCount(where, CheckDate) + " 人";
                    lblDiaCount.Text = archive_baseinfo.GetDiaNoVisitCount(where, CheckDate) + " 人";
                    lblPsyCount.Text = archive_baseinfo.GetMentalNoVisitCount(where, CheckDate) + " 人";
                    lblTbCount.Text = archive_baseinfo.GetLungerNoVisitCount(where, CheckDate) + " 人";
                    lblNczCount.Text = archive_baseinfo.GetStrokeNoVisitCount(where, CheckDate) + " 人";
                    lblHeaCount.Text = archive_baseinfo.GetChdNoVisitCount(where, CheckDate) + " 人";

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

            if (this.ckxCreatedDate.Checked)
            {
                str2 = str2 + string.Format(" and T.CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
            }

            //DataRowView selectedItem = this.cbxUser.SelectedItem as DataRowView;
            //if (selectedItem == null)
            //{
            //    return str2;
            //}

            //DataRow row = selectedItem.Row;
            //if (row["ID"].ToString() == "-1")
            //{
            //    return str2;
            //}

            //return (str2 + " and CreateBy = " + row["ID"].ToString() + " ");

            if (this.cbxUser.Text != "不限" && this.cbxUser.Text != "")
            {
                str2 = str2 + string.Format(" and T.CreateMenName = '{0}' ", this.cbxUser.Text.ToString()); ;
            }

            return str2;
        }
        private DataTable TransDs(DataSet ds)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("CustomerName");
            dt.Columns.Add("IDCardNo");
            dt.Columns.Add("OLDVisit");
            dt.Columns.Add("HyperVisit");
            dt.Columns.Add("DiaVisit");
            dt.Columns.Add("MentalVisit");
            dt.Columns.Add("LungerVisit");
            dt.Columns.Add("StrokeVisit");
            dt.Columns.Add("ChdVisit");
            foreach (DataRow row in ds.Tables[0].Rows)
            {

                string populationType = row["PopulationType"].ToString();

                if (populationType.IndexOf("4") >= 0 && row["OLDVisit"].ToString() == "")
                {
                    row["OLDVisit"] = "未访视";
                }
                else
                {
                    row["OLDVisit"] = "";
                }

                if (populationType.IndexOf("6") >= 0 && row["HyperVisit"].ToString() == "")
                {
                    row["HyperVisit"] = "未访视";
                }
                else
                {
                    row["HyperVisit"] = "";
                }

                if (populationType.IndexOf("7") >= 0 && row["DiaVisit"].ToString() == "")
                {
                    row["DiaVisit"] = "未访视";
                }
                else
                {
                    row["DiaVisit"] = "";
                }

                if (populationType.IndexOf("5") >= 0 && row["MentalVisit"].ToString() == "")
                {
                    row["MentalVisit"] = "未访视";
                }
                else
                {
                    row["MentalVisit"] = "";
                }

                if (populationType.IndexOf("10") >= 0 && row["LungerVisit"].ToString() == "")
                {
                    row["LungerVisit"] = "未访视";
                }
                else
                {
                    row["LungerVisit"] = "";
                }

                if (populationType.IndexOf("9") >= 0 && row["StrokeVisit"].ToString() == "")
                {
                    row["StrokeVisit"] = "未访视";
                }
                else
                {
                    row["StrokeVisit"] = "";
                }

                if (populationType.IndexOf("8") >= 0 && row["ChdVisit"].ToString() == "")
                {
                    row["ChdVisit"] = "未访视";
                }
                else
                {
                    row["ChdVisit"] = "";
                }

                DataRow dr = dt.NewRow();
                dr["CustomerName"] = row["CustomerName"].ToString().Trim();
                dr["IDCardNo"] = row["IDCardNo"].ToString().Trim();
                dr["OLDVisit"] = row["OLDVisit"].ToString().Trim();
                dr["HyperVisit"] = row["HyperVisit"].ToString().Trim();
                dr["DiaVisit"] = row["DiaVisit"].ToString().Trim();
                dr["MentalVisit"] = row["MentalVisit"].ToString().Trim();
                dr["LungerVisit"] = row["LungerVisit"].ToString().Trim();
                dr["StrokeVisit"] = row["StrokeVisit"].ToString().Trim();
                dr["ChdVisit"] = row["ChdVisit"].ToString().Trim();
                dt.Rows.Add(dr);
            }

            return dt;
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //老年人
            if (dgvData["oldMan", e.RowIndex].Value.ToString() == "")
            {
                dgvData["oldMan", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["oldMan", e.RowIndex].Value = "";

            }

            //高血压
            if (dgvData["hyp", e.RowIndex].Value.ToString() == "")
            {
                dgvData["hyp", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["hyp", e.RowIndex].Value = "";
            }

            //糖尿病
            if (dgvData["dia", e.RowIndex].Value.ToString() == "")
            {
                dgvData["dia", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["dia", e.RowIndex].Value = "";
            }

            //精神疾病
            if (dgvData["psy", e.RowIndex].Value.ToString() == "")
            {
                dgvData["psy", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["psy", e.RowIndex].Value = "";
            }

            //肺结核
            if (dgvData["tb", e.RowIndex].Value.ToString() == "")
            {
                dgvData["tb", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["tb", e.RowIndex].Value = "";
            }

            //脑卒中
            if (dgvData["ncz", e.RowIndex].Value.ToString() == "")
            {
                dgvData["ncz", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["ncz", e.RowIndex].Value = "";
            }

            //冠心病
            if (dgvData["hea", e.RowIndex].Value.ToString() == "")
            {
                dgvData["hea", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["hea", e.RowIndex].Value = "";
            }
        }


        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView view = (DataRowView)this.bds.List[this.bds.Position];
            string idNo = view.Row["IDCardNo"].ToString();

            //老年人
            if (e.ColumnIndex == dgvData.Columns[2].Index)
            {
                if (this.Restriction == "on")
                {
                    if (new RecordsBaseInfoBLL().GetModel(idNo).PopulationType.Contains("4"))
                    {
                        using (Controler controler = new Controler(new MDIParentForm(idNo), new OldPeopleInfoFactory()))
                        {
                            controler.IParentFrm.IShowDialog();
                            return;
                        }
                    }
                    MessageBox.Show("非老年人，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    using (Controler controler2 = new Controler(new MDIParentForm(idNo), new OldPeopleInfoFactory()))
                    {
                        controler2.IParentFrm.IShowDialog();
                    }
                }
            }

            //高血压
            if (e.ColumnIndex == dgvData.Columns[3].Index)
            {
                if (this.Restriction == "on")
                {
                    if (new RecordsBaseInfoBLL().GetModel(idNo).PopulationType.Contains("6"))
                    {
                        using (Controler controler = new Controler(new HypForm(idNo), new HypFactory()))
                        {
                            controler.IParentFrm.IShowDialog();
                            return;
                        }
                    }

                    MessageBox.Show("非高血压人群，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    using (Controler controler2 = new Controler(new HypForm(idNo), new HypFactory()))
                    {
                        controler2.IParentFrm.IShowDialog();
                    }
                }
            }

            //糖尿病
            if (e.ColumnIndex == dgvData.Columns[4].Index)
            {
                if (this.Restriction == "on")
                {
                    if (new RecordsBaseInfoBLL().GetModel(idNo).PopulationType.Contains("7"))
                    {
                        using (Controler controler = new Controler(new MDIParentForm(idNo), new DiaFactory()))
                        {
                            controler.IParentFrm.IShowDialog();
                            return;
                        }
                    }
                    MessageBox.Show("非糖尿病人群，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    using (Controler controler2 = new Controler(new MDIParentForm(idNo), new DiaFactory()))
                    {
                        controler2.IParentFrm.IShowDialog();
                    }
                }
            }

            //精神疾病
            if (e.ColumnIndex == dgvData.Columns[5].Index)
            {
                if (this.Restriction == "on")
                {
                    if (new RecordsBaseInfoBLL().GetModel(idNo).PopulationType.Contains("5"))
                    {
                        using (Controler controler = new Controler(new MDIParentForm(idNo), new MentalFactory()))
                        {
                            controler.IParentFrm.IShowDialog();
                            return;
                        }
                    }
                    MessageBox.Show("非重精神病人群，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    using (Controler controler2 = new Controler(new MDIParentForm(idNo), new MentalFactory()))
                    {
                        controler2.IParentFrm.IShowDialog();
                    }
                }
            }

            //肺结核
            if (e.ColumnIndex == dgvData.Columns[6].Index)
            {
                if (this.Restriction == "on")
                {
                    if (new RecordsBaseInfoBLL().GetModel(idNo).PopulationType.Contains("10"))
                    {
                        using (Controler controler = new Controler(new MDIParentForm(idNo), new PTBFactory()))
                        {
                            controler.IParentFrm.IShowDialog();
                            return;
                        }
                    }

                    MessageBox.Show("非肺结核人群，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    using (Controler controler2 = new Controler(new MDIParentForm(idNo), new DiaFactory()))
                    {
                        controler2.IParentFrm.IShowDialog();
                    }
                }
            }

            //脑卒中
            if (e.ColumnIndex == dgvData.Columns[7].Index)
            {
                if (this.Restriction == "on")
                {
                    if (new RecordsBaseInfoBLL().GetModel(idNo).PopulationType.Contains("9"))
                    {
                        using (Controler controler = new Controler(new MDIParentForm(idNo), new StrokeFactory()))
                        {
                            controler.IParentFrm.IShowDialog();
                            return;
                        }
                    }
                    MessageBox.Show("非脑卒中人群，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    using (Controler controler2 = new Controler(new MDIParentForm(idNo), new StrokeFactory()))
                    {
                        controler2.IParentFrm.IShowDialog();
                    }
                }

            }

            //冠心病
            if (e.ColumnIndex == dgvData.Columns[8].Index)
            {
                if (this.Restriction == "on")
                {
                    if (new RecordsBaseInfoBLL().GetModel(idNo).PopulationType.Contains("8"))
                    {
                        using (Controler controler = new Controler(new MDIParentForm(idNo), new CHDFactory()))
                        {
                            controler.IParentFrm.IShowDialog();
                            return;
                        }
                    }
                    MessageBox.Show("非冠心病人群，不能进入!", "随访人群", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    using (Controler controler2 = new Controler(new MDIParentForm(idNo), new CHDFactory()))
                    {
                        controler2.IParentFrm.IShowDialog();
                    }
                }
            }
        }

        private void frmNeverVisit_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void ckCheckDate_CheckedChanged_1(object sender, EventArgs e)
        {
            this.dtpSt.Enabled = this.ckCheckDate.Checked;
            this.dtpEd.Enabled = this.ckCheckDate.Checked;
        }

        private void ckxCreatedDate_CheckedChanged_1(object sender, EventArgs e)
        {
            this.dtpCreatedDateSt.Enabled = this.ckxCreatedDate.Checked;
            this.dtpCreatedDateEd.Enabled = this.ckxCreatedDate.Checked;
        }
    }
}
