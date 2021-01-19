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

namespace ArchiveInfo
{
    public partial class PhysicalQueryForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private int currentPage;
        private int totalPages;
        private int totalCount;
        private int pageCount = 10;
        private BindingSource bds;
        private DataTable dt_user;
        private DataTable dtTmp;
        private RequireBLL RequireBLL = new RequireBLL();
        private DataTable requirebasedt;
        private DataTable requireilldt;
        private DataTable requireenvironmentdt;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/" : ConfigurationManager.AppSettings["SignPath"].ToString(); //签名保存路径

        public PhysicalQueryForm()
        {
            InitializeComponent();
            this.dgvData.AutoGenerateColumns = false;
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
            if (Model != null)
            {
                this.txtIdNum.Text = this.Model.IDCardNo.ToString();
                this.tbAddr.Text = this.Model.HouseHoldAddress.ToString();
                this.cbxUser.Text = this.Model.CreateMenName.ToString();
                CheckData();
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

            return str2;
        }

        private void TransDs(DataSet ds)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
            }
        }
        private void CheckData()
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
                RecordsCustomerBaseInfoBLL archive_baseinfo = new RecordsCustomerBaseInfoBLL();
                this.totalCount = archive_baseinfo.GetCustomerRecordCount(where);
                this.totalPages = (this.totalCount <= this.pageCount) ? 1 : ((this.totalCount / this.pageCount) +
                    (((this.totalCount % this.pageCount) > 0) ? 1 : 0));
                this.lbTotalCount.Text = string.Format("共计{0}条", this.totalCount.ToString());
                if (this.currentPage > totalPages - 1) this.currentPage--;

                DataSet ds = archive_baseinfo.GetCustomerListByPage(where, "CheckDate desc ,B.ID ASC", this.currentPage * this.pageCount, this.pageCount);
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
                CheckData();
            }
        }

        private void PhysicalQueryForm_Load(object sender, EventArgs e)
        {

            if (!this.EveryThingIsOk)
            {
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
                    PhysicalInfoFactory.ID = int.Parse(view.Row["ID"].ToString());
                    PhysicalInfoFactory.NewAdd = false;
                    using (PEControler controler = new PEControler(new PhysicalForm(view.Row["IDCardNo"].ToString()), new PhysicalInfoFactory()))
                    {
                        controler.IParentFrm.IShowDialog();
                        CheckData();
                    }
                    GC.Collect();
                }
                else if (((this.dgvData.Columns[e.ColumnIndex].HeaderText == "删除") && (this.bds.Position >= 0)) && (e.RowIndex >= 0))
                {
                    if (view != null)
                    {
                        DataRow row = view.Row;
                        if (MessageBox.Show("确定删除:" + row["CustomerName"].ToString() + "？删除之后的信息将无法恢复!", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            int BaseID = Convert.ToInt32(row["ID"].ToString());
                            RecordsGeneralConditionModel GerneralCondition = new RecordsGeneralConditionBLL().GetModelByOutKey(BaseID);
                            if (GerneralCondition != null)
                            {
                                RecordsSelfcareabilityBLL RecordsSelfcareabilityBLL = new RecordsSelfcareabilityBLL();
                                RecordsSelfcareabilityBLL.Delete(GerneralCondition.SelfID);
                            }

                            RecordsMediPhysDistModel MediPhys = new RecordsMediPhysDistBLL().GetModelByOutKey(BaseID);
                            if (MediPhys != null)
                            {
                                RecordsMedicineCnBLL MedicineCnBLL = new RecordsMedicineCnBLL();
                                RecordsMedicineResultBLL MedicineResultBLL = new RecordsMedicineResultBLL();
                                MedicineCnBLL.Delete(MediPhys.MedicineID);
                                MedicineResultBLL.Delete(MediPhys.MedicineResultID);
                            }
                            RecordsSignatureModel Signature = new RecordsSignatureBLL().GetModelByOutKey(BaseID, row["IDCardNo"].ToString());
                            if (Signature != null)
                            {
                                if (Signature.FeedbackDate.HasValue)
                                {
                                    string strfbDate = Convert.ToDateTime(Signature.FeedbackDate).ToString("yyyyMMdd");
                                    string strSign1_Self = String.Format("{0}{1}_{2}_B.png", SignPath, Signature.IDCardNo, strfbDate);
                                    if (File.Exists(strSign1_Self))  //如果存在则删除图片
                                    {
                                        File.Delete(strSign1_Self);
                                    }
                                    string strSign1_Js = String.Format("{0}{1}_{2}_J.png", SignPath, Signature.IDCardNo, strfbDate);
                                    if (File.Exists(strSign1_Js)) //如果存在则删除图片
                                    {
                                        File.Delete(strSign1_Js);
                                    }
                                    string strSign1_Fkr = String.Format("{0}{1}_{2}_F.png", SignPath, Signature.IDCardNo, strfbDate);
                                    if (File.Exists(strSign1_Fkr)) //如果存在则删除图片
                                    {
                                        File.Delete(strSign1_Fkr);
                                    }
                                    string strSign1_Ys = String.Format("{0}{1}_{2}_Doc.png", SignPath, Signature.IDCardNo, strfbDate);
                                    if (File.Exists(strSign1_Ys)) //如果存在则删除图片
                                    {
                                        File.Delete(strSign1_Ys);
                                    }
                                }
                            }
                            new RecordsCustomerBaseInfoBLL().Delete(BaseID);
                            row.Delete();
                            row.Table.AcceptChanges();
                            CheckData();
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
                DataSet ds = new RecordsCustomerBaseInfoBLL().GetCustomerListByPage(this.GetWhere(), "CheckDate desc ,B.ID ASC", this.currentPage * this.pageCount, this.pageCount);
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
                DataSet ds = new RecordsCustomerBaseInfoBLL().GetCustomerListByPage(this.GetWhere(), "CheckDate desc ,B.ID ASC", this.currentPage * this.pageCount, this.pageCount);
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
    }
}
