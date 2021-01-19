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
using System.Text.RegularExpressions;
using KangShuoTech.DataAccessProjects.BLL;

namespace ArchiveInfo
{
    public partial class FamilyListQueryForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
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

        public FamilyListQueryForm()
        {
            InitializeComponent();
            this.dgvData.AutoGenerateColumns = false;
            EveryThingIsOk = false;
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
                str2 = str2 + string.Format(" and C.CreatedDate between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.ckxCreatedDate.Checked)
            {
                str2 = str2 + string.Format(" and T.CreatedDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.cbxUser.Text != "不限")
            {
                str2 = str2 + string.Format(" and T.CreateMenName = '{0}' ", this.cbxUser.Text.ToString()); ;
            }

            return str2;
        }
        //private DataTable TransDs(DataSet ds)
        //{
        //    DataTable dt = new DataTable();

        //    dt.Columns.Add("CustomerName");
        //    dt.Columns.Add("Sex");
        //    dt.Columns.Add("IDCardNo");
        //    dt.Columns.Add("baseinfocount");//封面信息
        //    dt.Columns.Add("Nation");
        //    dt.Columns.Add("Birthday");
        //    dt.Columns.Add("Phone");
        //    dt.Columns.Add("recordinfocount"); //详细信息
        //    dt.Columns.Add("healthinfocount"); //健康信息
        //    dt.Columns.Add("Sum");
        //    foreach (DataRow row in ds.Tables[0].Rows)
        //    {
        //        string str = "";
        //        int baseinfocount = 0, recordinfocount = 0, healthinfocount = 0, Sum = 0;
        //        row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
        //        RecordsBaseInfoModel Models = new RecordsBaseInfoBLL().GetModel(row["IDCardNo"].ToString());
        //        RecordsEnvironmentModel LifeEnvironments = new RecordsEnvironmentBLL().GetModel(row["IDCardNo"].ToString());
               
        //    }
        //    return dt;
        //}
     
        
        private void TransDs(DataSet ds)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
                row["Birthday"] = DateTime.Parse(row["Birthday"].ToString()).ToString("yyyy-MM-dd");
                if (row["HouseRelation"].ToString() == "1")
                {
                    row["HouseRelation"] = "户主";
                }
                else if (row["HouseRelation"].ToString() == "2")
                {
                    row["HouseRelation"] = "配偶";
                }
                else if (row["HouseRelation"].ToString() == "3")
                {
                    row["HouseRelation"] = "父亲";
                }
                else if (row["HouseRelation"].ToString() == "4")
                {
                    row["HouseRelation"] = "母亲";
                }
                else if (row["HouseRelation"].ToString() == "5")
                {
                    row["HouseRelation"] = "兄弟";
                }
                else if (row["HouseRelation"].ToString() == "6")
                {
                    row["HouseRelation"] = "姐妹";
                }
                else if (row["HouseRelation"].ToString() == "7")
                {
                    row["HouseRelation"] = "儿子";
                }
                else if (row["HouseRelation"].ToString() == "8")
                {
                    row["HouseRelation"] = "女儿";
                }
                else if (row["HouseRelation"].ToString() == "9")
                {
                    row["HouseRelation"] = "儿媳";
                }
                else if (row["HouseRelation"].ToString() == "10")
                {
                    row["HouseRelation"] = "女婿";
                }
                else if (row["HouseRelation"].ToString() == "11")
                {
                    row["HouseRelation"] = "孙子";
                }
                else if (row["HouseRelation"].ToString() == "12")
                {
                    row["HouseRelation"] = "孙女";
                }
                else if (row["HouseRelation"].ToString() == "13")
                {
                    row["HouseRelation"] = "外孙";
                }
                else if (row["HouseRelation"].ToString() == "14")
                {
                    row["HouseRelation"] = "外孙女";
                }
                else if (row["HouseRelation"].ToString() == "15")
                {
                    row["HouseRelation"] = "其他";
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
                dtpCreatedDateSt.Text = "";
                dtpCreatedDateEd.Text = "";
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
        
                    RecordsFamilyInfoBLL archive_baseinfo = new RecordsFamilyInfoBLL();
                    this.totalCount = archive_baseinfo.GetFamilyRecordCount(where);
                    this.totalPages = (this.totalCount <= this.pageCount) ? 1 : ((this.totalCount / this.pageCount) + (((this.totalCount % this.pageCount) > 0) ? 1 : 0));
                    this.currentPage = 0;
                    this.lbTotalCount.Text = string.Format("共计{0}条", this.totalCount.ToString());
                    DataSet ds = archive_baseinfo.GetFamilyListByPage(where, "FamilyIDCardNo DESC", 0, this.pageCount);
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
        }

        private void FamilyListQueryForm_Load(object sender, EventArgs e)
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
                    using (Controler controler = new Controler(new MDIParentForm(view.Row["IDCardNo"].ToString()), new FamilyFactory()))
                    {
                        controler.IParentFrm.IShowDialog();
                    }
                    GC.Collect();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.currentPage < (this.totalPages - 1))
            {
                this.lbPages.Text = string.Format("{0}/{1}页", ++this.currentPage + 1, this.totalPages);
                DataSet ds = new RecordsFamilyInfoBLL().GetFamilyListByPage(this.GetWhere(), "FamilyIDCardNo DESC", this.currentPage * this.pageCount, this.pageCount);
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
                DataSet ds = new RecordsFamilyInfoBLL().GetFamilyListByPage(this.GetWhere(), "FamilyIDCardNo DESC", this.currentPage * this.pageCount, this.pageCount);
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
