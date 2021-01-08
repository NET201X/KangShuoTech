﻿using FocusGroup.OldPeople;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonUI;

namespace RecordManagement.OverView
{
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Management;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using FocusGroup.ChronicDisease;

    public partial class frmOutDiabete : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private int currentPage, totalPages, totalCount, pageCount = 10;
        private BindingSource bds;
        private DataTable dt_user;
        private DataTable dt_doctor;
        private RequireBLL RequireBLL = new RequireBLL();
        private DataTable requireBaseDt;
        private DataTable requireVisitDt;
        private string reqWhere = "";
        private string reqBaseCol = ", '0' AS BaseCount", reqVisitCol = ", '0' AS VisitCount";
        private string reqBaseTipCol = ", '' AS BaseInfo", reqVisitTipCol = ", '' AS VisitInfo";
        RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
        private int toolTipX = 0, toolTipX2 = 0;

        // 取得屏幕分辨率的宽高
        private int SH = Screen.PrimaryScreen.Bounds.Height;
        private int SW = Screen.PrimaryScreen.Bounds.Width;

        public frmOutDiabete()
        {
            InitializeComponent();

            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.ShowCellToolTips = false;

            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipTitle = "";
            this.toolTip1.UseAnimation = true;
            this.toolTip1.UseFading = true;

            this.dgvData.CellMouseLeave += new DataGridViewCellEventHandler(dgvData_CellMouseLeave);
            this.dgvData.CellMouseEnter += new DataGridViewCellEventHandler(dgvData_CellMouseEnter);
            this.EveryThingIsOk = false;
            this.HaveToSave = false;

            #region 取得必填项设置的内容

            requireBaseDt = RequireBLL.GetList(" TabName = '糖尿病随访' AND Comment = '糖尿病基本信息' AND IsRequired='1' ").Tables[0];
            requireVisitDt = RequireBLL.GetList(" TabName = '糖尿病随访' AND Comment = '糖尿病随访信息' AND IsRequired='1' ").Tables[0];

            DataView dvBase = requireBaseDt.DefaultView;
            dvBase.RowFilter = "ISNULL(OptionName,'') <>'' ";
            DataTable dtBase = dvBase.ToTable();
            DataView dvVisit = requireVisitDt.DefaultView;
            dvVisit.RowFilter = "ISNULL(OptionName,'') <>'' ";
            DataTable dtVisit = dvVisit.ToTable();

            #region 基本信息

            // 一般情况
            if (dtBase.Rows.Count > 0)
            {
                reqWhere = "AND (1=1";
                reqBaseCol = " \r\n,CONCAT(0+";
                reqBaseTipCol = " \r\n,CONCAT('  基本信息未填写项：\\r\\n',";

                for (int i = 0; i < dtBase.Rows.Count; i++)
                {
                    string col = dtBase.Rows[i]["OptionName"].ToString();
                    string colName = dtBase.Rows[i]["ChinName"].ToString();
                    string tableName = "DiabeteBase.";

                    // 拼接必输栏位非空白条件
                    reqWhere += " OR IFNULL(" + tableName + col + ", '')='' ";

                    // sum必输栏位空白的笔数
                    reqBaseCol += " (CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN 1 ELSE 0 END) +";
                    reqBaseTipCol += " CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN '" + colName + "\\r\\n' ELSE '' END,";
                }

                reqBaseCol = reqBaseCol.TrimEnd('+') + ") AS BaseCount";
                reqBaseTipCol = reqBaseTipCol.TrimEnd(',') + ") AS BaseInfo";
            }

            #endregion

            #region 随访信息

            // 生活方式
            if (dtVisit.Rows.Count > 0)
            {
                reqWhere += reqWhere.Length > 0 ? "" : " AND (1=1";
                reqVisitCol = " \r\n,CONCAT(0+";
                reqVisitTipCol = " \r\n,CONCAT('  随访信息未填写项：\\r\\n',";

                for (int i = 0; i < dtVisit.Rows.Count; i++)
                {
                    string col = dtVisit.Rows[i]["OptionName"].ToString();
                    string colName = dtVisit.Rows[i]["ChinName"].ToString();
                    string tableName = "Visit.";

                    string[] value = col.Split(new string[] { "、" }, StringSplitOptions.RemoveEmptyEntries);

                    if (colName.Contains("签名") || colName.Contains("签字")) continue;

                    // 用药
                    if (colName.Equals("用药情况"))
                    {
                        // sum必输栏位空白的笔数
                        reqVisitCol += " SUM(CASE WHEN IFNULL(Conditions.IDCardNo, '')='' THEN 1 ELSE 0 END) +";
                        reqVisitTipCol += " CASE WHEN IFNULL(Conditions.IDCardNo, '')='' THEN '" + colName + "\\r\\n' ELSE '' END,";
                    }
                    else if (colName.Equals("用药调整意见"))
                    {
                        // sum必输栏位空白的笔数
                        reqVisitCol += " SUM(CASE WHEN IFNULL(ConditionChange.IDCardNo, '')='' THEN 1 ELSE 0 END) +";
                        reqVisitTipCol += " CASE WHEN IFNULL(ConditionChange.IDCardNo, '')='' THEN '" + colName + "\\r\\n' ELSE '' END,";
                    }
                    else
                    {
                        for (int j = 0; j < value.Length; j++)
                        {
                            // 拼接必输栏位非空白条件
                            reqWhere += " OR IFNULL(" + tableName + value[j] + ", '')='' ";

                            // sum必输栏位空白的笔数
                            reqVisitCol += " (CASE WHEN IFNULL(" + tableName + value[j] + ", '')='' THEN 1 ELSE 0 END) +";
                            reqVisitTipCol += " CASE WHEN IFNULL(" + tableName + value[j] + ", '')='' THEN '" + colName + "\\r\\n' ELSE '' END,";
                        }
                    }
                }

                reqVisitCol = reqVisitCol.TrimEnd('+') + ") AS VisitCount";
                reqVisitTipCol = reqVisitTipCol.TrimEnd(',') + ") AS VisitInfo";
            }

            #endregion

            reqWhere += ")";

            #endregion
        }

        private void btnFront_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 0)
            {
                this.lbPages.Text = string.Format("{0}/{1}页", --this.currentPage + 1, this.totalPages);

                DataTable dt = archive_baseinfo.GetDiabeteData(reqBaseCol + reqVisitCol + reqBaseTipCol + reqVisitTipCol,
                    this.GetWhere() + reqWhere, "", this.currentPage * this.pageCount, this.pageCount);

                this.TransDs(dt);
                this.bds.DataSource = dt;
                this.dgvData.DataSource = this.bds;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.currentPage < (this.totalPages - 1))
            {
                this.lbPages.Text = string.Format("{0}/{1}页", ++this.currentPage + 1, this.totalPages);

                DataTable dt = archive_baseinfo.GetDiabeteData(reqBaseCol + reqVisitCol + reqBaseTipCol + reqVisitTipCol,
                    this.GetWhere() + reqWhere, "", this.currentPage * this.pageCount, this.pageCount);

                this.TransDs(dt);
                this.bds.DataSource = dt;
                this.dgvData.DataSource = this.bds;
            }
        }

        private void GetData()
        {
            string where = this.GetWhere();

            if (string.IsNullOrEmpty(where))
            {
                MessageBox.Show("请选择查询条件！", "查询条件", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.btnQuery.Enabled = false;

                // 取得清单总笔数
                this.totalCount = archive_baseinfo.GetDiabeteDataCount(reqBaseCol + reqVisitCol, where + reqWhere);

                this.totalPages = (this.totalCount <= this.pageCount) ? 1 : ((this.totalCount / this.pageCount) +
                    (((this.totalCount % this.pageCount) > 0) ? 1 : 0));
                this.lbTotalCount.Text = string.Format("共计{0}条", this.totalCount.ToString());

                if (this.currentPage > totalPages - 1) this.currentPage--;

                // 清单资料
                DataTable dt = archive_baseinfo.GetDiabeteData(reqBaseCol + reqVisitCol + reqBaseTipCol + reqVisitTipCol,
                    where + reqWhere, "", this.currentPage * this.pageCount, this.pageCount);

                this.TransDs(dt);

                this.lbPages.Text = string.Format("{0}/{1}页", this.currentPage + 1, this.totalPages);

                this.bds.DataSource = dt;
                this.dgvData.DataSource = this.bds;

                if (dt != null && dt.Rows.Count > 0)
                {
                    toolTipX = this.dgvData.GetCellDisplayRectangle(8, 0, false).X;
                    toolTipX2 = this.dgvData.GetCellDisplayRectangle(9, 0, false).X;
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
                this.cboDoctor.Enabled = true;
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
                MessageBox.Show(" 随访日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.ckxCreatedDate.Checked && (this.dtpCreatedDateSt.Value.Date > this.dtpCreatedDateEd.Value.Date))
            {
                MessageBox.Show(" 建档日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                GetData();
            }
        }

        private void frmOutDiabete_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

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

            // 体检医生
            this.dt_doctor = new SysUserBLL().GetDoctorList("").Tables[0];
            if (this.dt_doctor.Rows.Count > 0)
            {
                DataRow row = this.dt_doctor.NewRow();
                row.ItemArray = new object[] { 0, "不限" };
                this.dt_doctor.Rows.InsertAt(row, 0);
                this.cboDoctor.ValueMember = "UserID";
                this.cboDoctor.DisplayMember = "UserName";
                this.cboDoctor.DataSource = this.dt_doctor;
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

        private string GetWhere()
        {
            string input = this.txtIdNum.Text.Trim();
            string str2 = "";

            if (input != "")
            {
                str2 = !Regex.IsMatch(input, @"^\d{15}") ? string.Format(" AND Base.CustomerName like '%{0}%'", input) :
                    ("AND Base.IDCardNo LIKE '%" + input + "%'");
            }
            if (!string.IsNullOrEmpty(this.tbAddr.Text.Trim()))
            {
                str2 = str2 + string.Format(" AND Base.HouseHoldAddress LIKE '%{0}%' ", this.tbAddr.Text.Trim());
            }
            str2 = str2 + string.Format("AND Base.PopulationType LIKE '%{0}%' ", "7");
            if (this.ckCheckDate.Checked)
            {
                str2 = str2 + string.Format(" AND Visit.VisitDate BETWEEN '{0}' AND '{1}' ",
                    this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.ckxCreatedDate.Checked)
            {
                str2 = str2 + string.Format(" AND Base.CreateDate BETWEEN '{0}' AND '{1}' ",
                    this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.cbxUser.Text != "不限")
            {
                str2 = str2 + string.Format(" AND Base.CreateMenName = '{0}' ", this.cbxUser.Text.ToString());
            }
            if (this.cboDoctor.Text != "不限")
            {
                str2 = str2 + string.Format(" AND Visit.VisitDoctor = '{0}' ", this.cboDoctor.Text.ToString()); ;
            }

            return str2;
        }

        private void TransDs(DataTable dtInfo)
        {
            foreach (DataRow row in dtInfo.Rows)
            {
                row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
                row["Nation"] = !(row["Nation"].ToString() == "1") ? row["Minority"] : "汉";
            }
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

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.bds.Position >= 0) && (e.RowIndex >= 0))
            {
                DataRowView view = (DataRowView)this.bds.List[this.bds.Position];
                string idNo = view.Row["IDCardNo"].ToString();

                //基本信息
                if (e.ColumnIndex == dgvData.Columns[8].Index)
                {
                    using (Controler controler = new Controler(new MDIParentForm(idNo), new DiaFactory(1)))
                    {
                        controler.IParentFrm.IShowDialog();
                        GetData();
                        return;
                    }
                }
                //随访信息
                else if (e.ColumnIndex == dgvData.Columns[9].Index)
                {
                    using (Controler controler = new Controler(new MDIParentForm(idNo), new DiaFactory(2)))
                    {
                        controler.IParentFrm.IShowDialog();
                        GetData();
                        return;
                    }
                }
            }
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvData["Column5", e.RowIndex].Value.ToString() == "0")
            {
                dgvData["Column5", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["Column5", e.RowIndex].Value = "";
            }

            if (dgvData["Column8", e.RowIndex].Value.ToString() == "0")
            {
                dgvData["Column8", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["Column8", e.RowIndex].Value = "";
            }
        }

        private void dgvData_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.toolTip1.Hide(this.dgvData);//鼠标移出单元格后隐藏提示      
        }

        /// <summary>
        /// 鼠标移到单元格时,设置当前单元格的ToolTipText属性内容为当前单元格内容
        /// 解决tip内容显示不全的问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dgvData_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || dgvData.Rows.Count <= 0) return;

            this.toolTip1.Hide(this.dgvData);
            Point mousePos = PointToClient(MousePosition);  // 获取鼠标当前的位置
            string toolTipValue = "";

            if (e.ColumnIndex == 8 && dgvData["Column5", e.RowIndex].Value.ToString() != "")
            {
                toolTipValue = (dgvData.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString() +
                    dgvData.Rows[e.RowIndex].Cells["BaseInfo"].Value.ToString() ?? string.Empty).ToString();

                this.toolTip1.Show(toolTipValue, this.dgvData, new Point(toolTipX - 160, e.RowIndex * 50)); //在指定位置显示提示框
            }
            else if (e.ColumnIndex == 9 && dgvData["Column8", e.RowIndex].Value.ToString() != "")
            {
                toolTipValue = (dgvData.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString() +
                   dgvData.Rows[e.RowIndex].Cells["VisitInfo"].Value.ToString() ?? string.Empty).ToString();

                this.toolTip1.Show(toolTipValue, this.dgvData, new Point(toolTipX2 - 160, e.RowIndex * 50));//在指定位置显示提示框
            }
        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);
            e.Graphics.DrawRectangle(Pens.Chocolate, new Rectangle(0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1));

            Font f = new Font("微软雅黑", 10, FontStyle.Bold);

            e.Graphics.DrawString(this.toolTip1.ToolTipTitle + e.ToolTipText, f, Brushes.Crimson, e.Bounds);
        }
    }
}
