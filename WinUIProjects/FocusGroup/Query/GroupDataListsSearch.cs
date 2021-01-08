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
using System.IO;
using System.Configuration;

namespace FocusGroup
{
    public partial class GroupDataListsSearch : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private int currentPage;
        private int totalPages;
        private int totalCount;
        private int pageCount = 10;
        private BindingSource bds;
        private DataTable dt_user;
        private DataTable dtTmp;
        private string RecordsName;
        private string strcheckdate = "FollowUpDate";
        private string drugType = "";
        private string strorderby = "";
        InterfaceDataList archive_baseinfo = new OlderSelfCareabilityBLL();
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/" : ConfigurationManager.AppSettings["SignPath"].ToString(); //签名保存路径

        public GroupDataListsSearch(string str)
        {
            InitializeComponent();
            RecordsName = str;

            switch (RecordsName)
            {
                case "老年人记录":
                    archive_baseinfo = new OlderSelfCareabilityBLL();
                    this.strcheckdate = "FollowUpDate";
                    break;
                case "高血压记录":
                    archive_baseinfo = new ChronicHypertensionVisitBLL();
                    this.strcheckdate = "FollowUpDate";
                    break;
                case "糖尿病记录":
                    archive_baseinfo = new ChronicDiadetesVisitBLL();
                    this.strcheckdate = "VisitDate";
                    break;
                case "冠心病记录":
                    archive_baseinfo = new ChronicChdVisitBLL();
                    this.strcheckdate = "VisitDate";
                    break;
                case "脑卒中记录":
                    archive_baseinfo = new ChronicStrokeVisitBLL();
                    this.strcheckdate = "FollowupDate";
                    break;
                case "精神病记录":
                    archive_baseinfo = new ChronicMentalDiseaseVisitBLL();
                    this.strcheckdate = "FollowUpDate";
                    break;
                case "肺结核记录":
                    archive_baseinfo = new ChronicLungerFirstVisitBLL();
                    this.strcheckdate = "FollowupDate";
                    break;
                case "":
                    break;
                default: break;
            }
            this.strorderby = this.strcheckdate + " desc,C.ID ASC ";
            this.dgvData.AutoGenerateColumns = false;
            this.EveryThingIsOk = false;
            this.HaveToSave = false;
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
                    this.GetDataView();
                }
            }
        }
        private void GetDataView()
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
                DataSet ds = archive_baseinfo.GetListByPage(where, this.strorderby, 0, this.pageCount);
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
        private void btnFront_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 0)
            {
                this.lbPages.Text = string.Format("{0}/{1}页", --this.currentPage + 1, this.totalPages);
                DataSet ds = archive_baseinfo.GetListByPage(this.GetWhere(), this.strorderby, this.currentPage * this.pageCount, this.pageCount);
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
                DataSet ds = archive_baseinfo.GetListByPage(this.GetWhere(), this.strorderby, this.currentPage * this.pageCount, this.pageCount);
                if (ds.Tables.Count > 0)
                {
                    this.TransDs(ds);
                    this.bds.DataSource = ds.Tables[0];
                    this.dgvData.DataSource = this.bds;
                }
            }
        }

        private void GroupDataListsSearch_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
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
            if (this.Model != null)
            {
                this.txtIdNum.Text = this.Model.IDCardNo;
                this.tbAddr.Text = this.Model.HouseHoldAddress;
                this.cbxUser.Text = Model.CreateMenName;
            }
            this.EveryThingIsOk = true;
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
            ds.Tables[0].Columns.Add("DelData");
            ds.Tables[0].Columns.Add("CheckDate");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
                if (!string.IsNullOrEmpty(row[this.strcheckdate].ToString()))
                {
                    row["CheckDate"] = Convert.ToDateTime(row[this.strcheckdate].ToString()).ToShortDateString();
                }
                row["UpdateData"] = "修改";
                row["DelData"] = "删除";
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.bds.Position >= 0) && (e.RowIndex >= 0))
            {
                DataRowView view = (DataRowView)this.bds.List[this.bds.Position];

                if (((this.dgvData.Columns[e.ColumnIndex].HeaderText == "修改") && (this.bds.Position >= 0)) && (e.RowIndex >= 0))
                {
                    if (view != null)
                    {
                        DataRow row = view.Row;
                        new Controler(new MDIParentForm(view.Row["IDCardNo"].ToString()), new FocusQueryInfoFactory(Convert.ToInt32(row["ID"].ToString()), RecordsName)).IParentFrm.IShowDialog();
                        //this.GetDataView();
                    }
                }
                if (((this.dgvData.Columns[e.ColumnIndex].HeaderText == "删除") && (this.bds.Position >= 0)) && (e.RowIndex >= 0))
                {
                    if (view != null)
                    {
                        DataRow row = view.Row;
                        string Sign = "", SignDoc = "";
                        if (MessageBox.Show("确定删除:" + row["CustomerName"].ToString() + "？删除之后的信息将无法恢复!", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            ChronicDrugConditionBLL drugbll = new ChronicDrugConditionBLL();
                            switch (this.RecordsName)
                            {
                                case "老年人记录":
                                    OlderMedicineResultBLL oldMedicineResultbll = new OlderMedicineResultBLL();
                                    oldMedicineResultbll.DelOUTkey(Convert.ToInt32(row["ID"].ToString()));
                                    OlderMedicineCnBLL OlderMedicineCnbll = new OlderMedicineCnBLL();
                                    OlderMedicineCnModel MedResultModel = OlderMedicineCnbll.GetModelOUTKey(Convert.ToInt32(row["ID"].ToString()));
                                    OlderMedicineCnbll.DelOUTkey(Convert.ToInt32(row["ID"].ToString()));

                                    //删除签名
                                    Sign = string.Format("{0}{1}_{2}_Asses.png", SignPath + "OldVisit//", row["IDCardNo"].ToString(), Convert.ToDateTime(row["CheckDate"]).ToString("yyyyMMdd"));
                                    DeletSign(Sign);

                                    if (MedResultModel != null)
                                    {
                                        SignDoc = string.Format("{0}{1}_{2}_MeC.png", SignPath + "OldVisit//", row["IDCardNo"].ToString(), Convert.ToDateTime(MedResultModel.RecordDate).ToString("yyyyMMdd"));
                                        DeletSign(SignDoc);
                                    }

                                    break;
                                case "高血压记录":
                                    this.drugType = "1";

                                    //删除签名
                                    Sign = string.Format("{0}{1}_{2}.png", SignPath + "HypVisit//", row["IDCardNo"].ToString(), Convert.ToDateTime(row["CheckDate"]).ToString("yyyyMMdd"));
                                    SignDoc = string.Format("{0}{1}_{2}_Doc.png", SignPath + "HypVisit//", row["IDCardNo"].ToString(), Convert.ToDateTime(row["CheckDate"]).ToString("yyyyMMdd"));
                                    DeletSign(Sign);
                                    DeletSign(SignDoc);

                                    drugbll.DeleteOUTKey(Convert.ToInt32(row["ID"].ToString()), drugType);
                                    break;
                                case "糖尿病记录":
                                    this.drugType = "2";
                                    drugbll.DeleteOUTKey(Convert.ToInt32(row["ID"].ToString()), drugType);

                                    //删除签名
                                    Sign = string.Format("{0}{1}_{2}.png", SignPath + "DiaVisit//", row["IDCardNo"].ToString(), Convert.ToDateTime(row["CheckDate"]).ToString("yyyyMMdd"));
                                    SignDoc = string.Format("{0}{1}_{2}_Doc.png", SignPath + "DiaVisit//", row["IDCardNo"].ToString(), Convert.ToDateTime(row["CheckDate"]).ToString("yyyyMMdd"));
                                    DeletSign(Sign);
                                    DeletSign(SignDoc);
                                    break;
                                case "冠心病记录":
                                    this.drugType = "4";
                                    drugbll.DeleteOUTKey(Convert.ToInt32(row["ID"].ToString()), drugType);
                                    break;
                                case "脑卒中记录":
                                    this.drugType = "5";
                                    drugbll.DeleteOUTKey(Convert.ToInt32(row["ID"].ToString()), drugType);
                                    break;
                                case "精神病记录":
                                    this.drugType = "3";
                                    drugbll.DeleteOUTKey(Convert.ToInt32(row["ID"].ToString()), drugType);

                                    //删除签名
                                    Sign = string.Format("{0}{1}_{2}.png", SignPath + "MentalVisit//", row["IDCardNo"].ToString(), Convert.ToDateTime(row["CheckDate"]).ToString("yyyyMMdd"));
                                    SignDoc = string.Format("{0}{1}_{2}_Doc.png", SignPath + "MentalVisit//", row["IDCardNo"].ToString(), Convert.ToDateTime(row["CheckDate"]).ToString("yyyyMMdd"));
                                    DeletSign(Sign);
                                    DeletSign(SignDoc);
                                    break;
                                case "肺结核记录":
                                    ChronicLungerVisitBLL lungerVisit = new ChronicLungerVisitBLL();
                                    //删除签名
                                    DataSet ds = lungerVisit.GetList(" OutKey=" + Convert.ToInt32(row["ID"].ToString()));
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        string VisitCount = ds.Tables[0].Rows[i]["VisitCount"].ToString();
                                        string strDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["FollowupDate"]).ToString("yyyyMMdd");

                                        Sign = string.Format("{0}{1}_{2}_{3}.png", SignPath + "PTBVisit//", row["IDCardNo"].ToString(), VisitCount, strDate);
                                        SignDoc = string.Format("{0}{1}_{2}_{3}_Doc.png", SignPath + "PTBVisit//", row["IDCardNo"].ToString(), VisitCount, strDate);

                                        DeletSign(Sign);
                                        DeletSign(SignDoc);
                                    }

                                    break;
                                case "":
                                    break;
                                default: break;
                            }

                            archive_baseinfo.Delete(Convert.ToInt32(row["ID"].ToString()));
                            string where = this.GetWhere();
                            this.totalCount = archive_baseinfo.GetRecordCount(where);
                            this.lbTotalCount.Text = string.Format("共计{0}条", this.totalCount.ToString());

                            row.Delete();
                            row.Table.AcceptChanges();
                        }
                    }
                }
            }
        }

        public void DeletSign(string strPath)
        {
            try
            {
                if (File.Exists(strPath))
                {
                    File.Delete(strPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                str2 = str2 + string.Format(" and {0} between '{1}' and '{2}' ", this.strcheckdate, this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
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
