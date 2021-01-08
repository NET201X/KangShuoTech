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
using System.Diagnostics;

namespace HealthHouse
{
    public partial class GuideQueryForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private int currentPage;
        private int totalPages;
        private int totalCount;
        private int pageCount = 10;
        private BindingSource bds;
        private DataTable dt_user;

        // 取得屏幕分辨率的宽高
        private int SW = Screen.PrimaryScreen.Bounds.Width;
        private int SH = Screen.PrimaryScreen.Bounds.Height;

        public GuideQueryForm()
        {
            InitializeComponent();
            this.dgvData.AutoGenerateColumns = false;
        }

        private void GuideQueryForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
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
                CheckData();
            }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string input = this.txtIdNum.Text.Trim();
            string str2 = "";

            if (input != "")
            {
                str2 = !Regex.IsMatch(input, @"^\d{15}") ? string.Format(" and c.CustomerName like '%{0}%'", input) : ("and c.IDCardNo LIKE '%" + input + "%'");
            }
            if (!string.IsNullOrEmpty(this.tbAddr.Text.Trim()))
            {
                str2 = str2 + string.Format(" and c.HouseHoldAddress LIKE '%{0}%' ", this.tbAddr.Text.Trim());
            }
            if (this.ckCheckDate.Checked)
            {
                str2 = str2 + string.Format(" and b.CheckDate between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"),
                            this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.ckxCreatedDate.Checked)
            {
                str2 = str2 + string.Format(" and a.CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"),
                            this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.cbxUser.Text != "不限")
            {
                str2 = str2 + string.Format(" and a.CreateBy = '{0}' ", this.cbxUser.Text.ToString()); ;
            }

            return str2;
        }

        private void CheckData()
        {
            string where = this.GetWhere();
            if (string.IsNullOrEmpty(where))
            {
                MessageBox.Show("请选择查询条件！", "查询条件", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.btnQuery.Enabled = false;
                HealthHouseGuideBLL guide = new HealthHouseGuideBLL();
                this.totalCount = guide.GetHealthGuideRecordCount(where);
                this.totalPages = (this.totalCount <= this.pageCount) ? 1 : ((this.totalCount / this.pageCount) + (((this.totalCount % this.pageCount) > 0) ? 1 : 0));
                this.currentPage = 0;
                this.lbTotalCount.Text = string.Format("共计{0}条", this.totalCount.ToString());
                DataSet ds = guide.GetHealthGuideListByPage(where, "a.ID Desc", 0, this.pageCount);
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

        /// <summary>
        /// 性别显示
        /// </summary>
        /// <param name="ds"></param>
        private void TransDs(DataSet ds)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
            }
        }

        public Process BatchProcess;
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // 选中所有人身份证号
            string idCardNo = "";
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                if ((bool)dgvData.Rows[i].Cells[0].EditedFormattedValue)
                {
                    idCardNo += dgvData.Rows[i].Cells[3].Value + ";";
                }
            }

            if (idCardNo.Length > 0)
            {
                idCardNo = idCardNo.Substring(0, idCardNo.Length - 1);

                BatchProcess = new Process { StartInfo = { FileName = @"HealthNewPrint.exe", Arguments = idCardNo } };
                BatchProcess.Start();
            }
            else
            {
                MessageBox.Show("请选择要打印档案资料！");
            }
        }

        /// <summary>
        /// 体检日期是否可选(根据是否勾选)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckCheckDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpSt.Enabled = this.ckCheckDate.Checked;
            this.dtpEd.Enabled = this.ckCheckDate.Checked;
        }

        /// <summary>
        /// 建档日期是否可选(根据是否勾选)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                DataSet ds = new HealthHouseBLL().GetHouseListByPage(this.GetWhere(), "CheckDate desc ,B.ID ASC", this.currentPage * this.pageCount, this.pageCount);
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
                DataSet ds = new HealthHouseBLL().GetHouseListByPage(this.GetWhere(), "CheckDate desc ,B.ID ASC", this.currentPage * this.pageCount, this.pageCount);
                if (ds.Tables.Count > 0)
                {
                    this.TransDs(ds);
                    this.bds.DataSource = ds.Tables[0];
                    this.dgvData.DataSource = this.bds;
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                dgvData.Rows[i].Cells[0].Value = true;
            }
        }

        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                dgvData.Rows[i].Cells[0].Value = false;
            }
        }

        /// <summary>
        /// 点击某行查看/删除/勾选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.bds.Position >= 0) && (e.RowIndex >= 0))
            {
                DataRowView view = (DataRowView)this.bds.List[this.bds.Position];

                if (((this.dgvData.Columns[e.ColumnIndex].HeaderText == "修改") && (this.bds.Position >= 0)) && (e.RowIndex >= 0))
                {
                    HealthGuideFactory.ID = Convert.ToInt32(view.Row["ID"].ToString()); // 主键
                    HealthGuideFactory.PID = Convert.ToInt32(view.Row["PID"]); // 体检ID
                    HealthGuideFactory.ViewState = "修改"; 
                    using (Controler controler = new Controler(new MDIParentForm(view.Row["IDCardNo"].ToString()), new HealthGuideFactory()))
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
                        int BaseID = int.Parse(view.Row["ID"].ToString());
                        if (MessageBox.Show("确定删除:" + row["CustomerName"].ToString() + "？删除之后的信息将无法恢复!", "删除", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            new HealthHouseGuideBLL().Delete(BaseID);
                            //row.Delete();
                            //row.Table.AcceptChanges();
                            CheckData();
                        }
                    }
                }
            }

            if ((this.bds.Position >= 0) && (e.RowIndex >= 0))
            {
                // 勾选/取消复选框
                if ((bool)dgvData.Rows[e.RowIndex].Cells[0].EditedFormattedValue == true)
                {
                    dgvData.Rows[e.RowIndex].Cells[0].Value = false;
                }
                else
                {
                    dgvData.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }
        }

        public RecordsBaseInfoModel Model { get; set; }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
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

    }
}
