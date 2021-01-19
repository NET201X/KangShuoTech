using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace ArchiveInfo.OverView
{
    using System;
    using System.Data;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Drawing;
    using KangShuoTech.Utilities.CommonTools;

    public partial class frmOutInfoQuery : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private int currentPage, totalPages, totalCount, pageCount = 10;
        private BindingSource bds;
        private DataTable dt_user;
        private DataTable dt_doctor;
        private DataTable requireGerneralDt;
        private DataTable requireLifeDt;
        private DataTable requirePhysicalDt;
        private DataTable requireCheckDt;
        private DataTable requireFunctionDt;
        private DataTable requireHealthDt;
        private DataTable requireAssessmentDt;
        private RequireBLL RequireBLL = new RequireBLL();
        private string reqWhere = "";
        private string reqGerneralCol = ", '0' AS NormalCount", reqLifeCol = ", '0' AS LifeCount";
        private string reqPhysicalCol = ", '0' AS PhysicalCount", reqCheckCol = ", '0' AS CheckCount";
        private string reqFunctionCol = ", '0' AS FunctionCount", reqHealthCol = ", '0' AS HealthCount";
        private string reqAssessCol = ", '0' AS AssessCount";
        private string reqGerneralTipCol = ", '' AS NormalInfo", reqLifeTipCol = ", '' AS LifeInfo";
        private string reqPhysicalTipCol = ", '' AS PhysicalInfo", reqCheckTipCol = ", '' AS CheckInfo";
        private string reqFunctionTipCol = ", '' AS FunctionInfo", reqHealthTipCol = ", '' AS HealthInfo";
        private string reqAssessTipCol = ", '' AS AssessInfo";
        RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
        private int toolTipX = 0, toolTipX2 = 0, toolTipX3 = 0, toolTipX4 = 0, toolTipX5 = 0, toolTipX6 = 0, toolTipX7 = 0;

        // 取得屏幕分辨率的宽高
        private int SH = Screen.PrimaryScreen.Bounds.Height;
        private int SW = Screen.PrimaryScreen.Bounds.Width;

        public frmOutInfoQuery()
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

            requireGerneralDt = RequireBLL.GetList(" TabName = '健康体检' AND Comment = '一般状况'  AND IsRequired='1' ").Tables[0];
            requireLifeDt = RequireBLL.GetList(" TabName = '健康体检' AND Comment = '生活方式' AND IsRequired='1' ").Tables[0];
            requirePhysicalDt = RequireBLL.GetList(" TabName = '健康体检' AND Comment = '查体信息' AND IsRequired='1' ").Tables[0];
            requireCheckDt = RequireBLL.GetList(" TabName = '健康体检' AND Comment = '辅助检查' AND IsRequired='1' ").Tables[0];
            requireFunctionDt = RequireBLL.GetList(" TabName = '健康体检' AND Comment = '脏器功能' AND IsRequired='1' ").Tables[0];
            requireHealthDt = RequireBLL.GetList(" TabName = '健康体检' AND Comment = '健康问题' AND IsRequired='1' ").Tables[0];
            requireAssessmentDt = RequireBLL.GetList(" TabName = '健康体检' AND Comment = '健康评价' AND IsRequired='1' ").Tables[0];

            DataView dvGerneral = requireGerneralDt.DefaultView;
            dvGerneral.RowFilter = "ISNULL(OptionName,'') <>'' ";
            DataTable dtGerneral = dvGerneral.ToTable();
            DataView dvLife = requireLifeDt.DefaultView;
            dvLife.RowFilter = "ISNULL(OptionName,'') <>'' ";
            DataTable dtLife = dvLife.ToTable();
            DataView dvPhysical = requirePhysicalDt.DefaultView;
            dvPhysical.RowFilter = "ISNULL(OptionName,'') <>'' ";
            DataTable dtPhysical = dvPhysical.ToTable();
            DataView dvCheck = requireCheckDt.DefaultView;
            dvCheck.RowFilter = "ISNULL(OptionName,'') <>'' ";
            DataTable dtCheck = dvCheck.ToTable();
            DataView dvFunction = requireFunctionDt.DefaultView;
            dvFunction.RowFilter = "ISNULL(OptionName,'') <>'' ";
            DataTable dtFunction = dvFunction.ToTable();
            DataView dvHealth = requireHealthDt.DefaultView;
            dvHealth.RowFilter = "ISNULL(OptionName,'') <>'' ";
            DataTable dtHealth = dvHealth.ToTable();
            DataView dvAssessment = requireAssessmentDt.DefaultView;
            dvAssessment.RowFilter = "ISNULL(OptionName,'') <>'' ";
            DataTable dtAssessment = dvAssessment.ToTable();

            #region 一般情况

            // 一般情况
            if (dtGerneral.Rows.Count > 0)
            {
                reqWhere = "AND (1=1";
                reqGerneralCol = " \r\n,CONCAT(0+";
                reqGerneralTipCol = " \r\n,CONCAT('  一般情况未填写项：\\r\\n',";

                for (int i = 0; i < dtGerneral.Rows.Count; i++)
                {
                    string col = dtGerneral.Rows[i]["OptionName"].ToString();
                    string colName = dtGerneral.Rows[i]["ChinName"].ToString();
                    string tableName = "General.";

                    if (col.Equals("Symptom")) tableName = "Customer.";

                    // 拼接必输栏位非空白条件
                    reqWhere += " OR IFNULL(" + tableName + col + ", '')='' ";

                    // sum必输栏位空白的笔数
                    reqGerneralCol += " (CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN 1 ELSE 0 END) +";
                    reqGerneralTipCol += " CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN '" + colName + "\\r\\n' ELSE '' END,";
                }

                reqGerneralCol = reqGerneralCol.TrimEnd('+') + ") AS NormalCount";
                reqGerneralTipCol = reqGerneralTipCol.TrimEnd(',') + ") AS NormalInfo";
            }

            #endregion

            #region 生活方式

            // 生活方式
            if (dtLife.Rows.Count > 0)
            {
                reqWhere += reqWhere.Length > 0 ? "" : " AND (1=1";
                reqLifeCol = " \r\n,CONCAT(0+";
                reqLifeTipCol = " \r\n,CONCAT('  生活方式未填写项：\\r\\n',";

                for (int i = 0; i < dtLife.Rows.Count; i++)
                {
                    string col = dtLife.Rows[i]["OptionName"].ToString();
                    string colName = dtLife.Rows[i]["ChinName"].ToString();
                    string tableName = "Life.";

                    // 拼接必输栏位非空白条件
                    reqWhere += " OR IFNULL(" + tableName + col + ", '')='' ";

                    // sum必输栏位空白的笔数
                    reqLifeCol += " (CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN 1 ELSE 0 END) +";
                    reqLifeTipCol += " CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN '" + colName + "\\r\\n' ELSE '' END,";
                }

                reqLifeCol = reqLifeCol.TrimEnd('+') + ") AS LifeCount";
                reqLifeTipCol = reqLifeTipCol.TrimEnd(',') + ") AS LifeInfo";
            }

            #endregion

            #region 查体信息

            // 查体信息
            if (dtPhysical.Rows.Count > 0)
            {
                reqWhere += reqWhere.Length > 0 ? "" : " AND (1=1";
                reqPhysicalCol = " \r\n,CONCAT(0+";
                reqPhysicalTipCol = " \r\n,CONCAT('  一般情况未填写项：\\r\\n',";

                for (int i = 0; i < dtPhysical.Rows.Count; i++)
                {
                    string col = dtPhysical.Rows[i]["OptionName"].ToString();
                    string colName = dtPhysical.Rows[i]["ChinName"].ToString();
                    string tableName = "Physical.";

                    // 拼接必输栏位非空白条件
                    reqWhere += " OR IFNULL(" + tableName + col + ", '')='' ";

                    // sum必输栏位空白的笔数
                    reqPhysicalCol += " (CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN 1 ELSE 0 END) +";
                    reqPhysicalTipCol += " CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN '" + colName + "\\r\\n' ELSE '' END,";
                }

                reqPhysicalCol = reqPhysicalCol.TrimEnd('+') + ") AS PhysicalCount";
                reqPhysicalTipCol = reqPhysicalTipCol.TrimEnd(',') + ") AS PhysicalInfo";
            }

            #endregion

            #region 辅助检查

            // 辅助检查
            if (dtCheck.Rows.Count > 0)
            {
                reqWhere += reqWhere.Length > 0 ? "" : " AND (1=1";
                reqCheckCol = " \r\n,CONCAT(0+";
                reqCheckTipCol = " \r\n,CONCAT('  辅助检查未填写项：\\r\\n',";

                for (int i = 0; i < dtCheck.Rows.Count; i++)
                {
                    string col = dtCheck.Rows[i]["OptionName"].ToString();
                    string colName = dtCheck.Rows[i]["ChinName"].ToString();
                    string tableName = "Checks.";

                    // 拼接必输栏位非空白条件
                    reqWhere += " OR IFNULL(" + tableName + col + ", '')='' ";

                    // sum必输栏位空白的笔数
                    reqCheckCol += " (CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN 1 ELSE 0 END) +";
                    reqCheckTipCol += " CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN '" + colName + "\\r\\n' ELSE '' END,";
                }

                reqCheckCol = reqCheckCol.TrimEnd('+') + ") AS CheckCount";
                reqCheckTipCol = reqCheckTipCol.TrimEnd(',') + ") AS CheckInfo";
            }

            #endregion

            #region 脏器功能

            // 脏器功能
            if (dtFunction.Rows.Count > 0)
            {
                reqWhere += reqWhere.Length > 0 ? "" : " AND (1=1";
                reqFunctionCol = " \r\n,CONCAT(0+";
                reqFunctionTipCol = " \r\n,CONCAT('  脏器功能未填写项：\\r\\n',";

                for (int i = 0; i < dtFunction.Rows.Count; i++)
                {
                    string col = dtFunction.Rows[i]["OptionName"].ToString();
                    string colName = dtFunction.Rows[i]["ChinName"].ToString();
                    string tableName = "Function.";

                    // 拼接必输栏位非空白条件
                    reqWhere += " OR IFNULL(" + tableName + col + ", '')='' ";

                    // sum必输栏位空白的笔数
                    reqFunctionCol += " (CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN 1 ELSE 0 END) +";
                    reqFunctionTipCol += " CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN '" + colName + "\\r\\n' ELSE '' END,";
                }

                reqFunctionCol = reqFunctionCol.TrimEnd('+') + ") AS FunctionCount";
                reqFunctionTipCol = reqFunctionTipCol.TrimEnd(',') + ") AS FunctionInfo";
            }

            #endregion

            #region 健康问题

            // 健康问题
            if (dtHealth.Rows.Count > 0)
            {
                reqWhere += reqWhere.Length > 0 ? "" : " AND (1=1";
                reqHealthCol = " \r\n,CONCAT(0+";
                reqHealthTipCol = " \r\n,CONCAT(' 健康问题未填写项：\\r\\n',";

                for (int i = 0; i < dtHealth.Rows.Count; i++)
                {
                    string col = dtHealth.Rows[i]["OptionName"].ToString();
                    string colName = dtHealth.Rows[i]["ChinName"].ToString();
                    string tableName = "Health.";

                    // 拼接必输栏位非空白条件
                    reqWhere += " OR IFNULL(" + tableName + col + ", '')='' ";

                    // sum必输栏位空白的笔数
                    reqHealthCol += " (CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN 1 ELSE 0 END) +";
                    reqHealthTipCol += " CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN '" + colName + "\\r\\n' ELSE '' END,";
                }

                reqHealthCol = reqHealthCol.TrimEnd('+') + ") AS HealthCount";
                reqHealthTipCol = reqHealthTipCol.TrimEnd(',') + ") AS HealthInfo";
            }

            #endregion

            #region 健康评价

            // 健康评价
            if (dtAssessment.Rows.Count > 0)
            {
                reqWhere += reqWhere.Length > 0 ? "" : " AND (1=1";
                reqAssessCol = "\r\n,CONCAT(0+";
                reqAssessTipCol = " \r\n,CONCAT('  健康评价未填写项：\\r\\n',";

                for (int i = 0; i < dtAssessment.Rows.Count; i++)
                {
                    string col = dtAssessment.Rows[i]["OptionName"].ToString();
                    string colName = dtAssessment.Rows[i]["ChinName"].ToString();
                    string tableName = "Assess.";

                    // 非免疫预防接种史
                    if (col.ToLower().Equals("inoculationhistory"))
                    {
                        // sum必输栏位空白的笔数
                        reqAssessCol += " SUM(CASE WHEN IFNULL(Inocula.IDCardNo, '')='' THEN 1 ELSE 0 END) +";
                        reqAssessTipCol += " CASE WHEN IFNULL(Inocula.IDCardNo, '')='' THEN '" + colName + "\\r\\n' ELSE '' END,";
                    }
                    else
                    {
                        // 拼接必输栏位非空白条件
                        reqWhere += " OR IFNULL(" + tableName + col + ", '')='' ";

                        // sum必输栏位空白的笔数
                        reqAssessCol += " (CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN 1 ELSE 0 END) +";
                        reqAssessTipCol += " CASE WHEN IFNULL(" + tableName + col + ", '')='' THEN '" + colName + "\\r\\n' ELSE '' END,";
                    }
                }

                reqAssessCol = reqAssessCol.TrimEnd('+') + ") AS AssessCount";
                reqAssessTipCol = reqAssessTipCol.TrimEnd(',') + ") AS AssessInfo";
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

                DataTable dt = archive_baseinfo.GetHealthData(reqGerneralCol + reqLifeCol + reqPhysicalCol +
                    reqCheckCol + reqFunctionCol + reqHealthCol + reqAssessCol + reqGerneralTipCol + reqLifeTipCol +
                    reqPhysicalTipCol + reqCheckTipCol + reqFunctionTipCol + reqHealthTipCol + reqAssessTipCol,
                    this.GetWhere() + reqWhere, "", this.currentPage * this.pageCount, this.pageCount
                );

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

                DataTable dt = archive_baseinfo.GetHealthData(reqGerneralCol + reqLifeCol + reqPhysicalCol +
                    reqCheckCol + reqFunctionCol + reqHealthCol + reqAssessCol + reqGerneralTipCol + reqLifeTipCol +
                    reqPhysicalTipCol + reqCheckTipCol + reqFunctionTipCol + reqHealthTipCol + reqAssessTipCol,
                    this.GetWhere() + reqWhere, "", this.currentPage * this.pageCount, this.pageCount
                );

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
                this.totalCount = archive_baseinfo.GetHealthCount(reqGerneralCol + reqLifeCol + reqPhysicalCol +
                    reqCheckCol + reqFunctionCol + reqHealthCol + reqAssessCol, where + reqWhere);

                this.totalPages = (this.totalCount <= this.pageCount) ? 1 : ((this.totalCount / this.pageCount) +
                    (((this.totalCount % this.pageCount) > 0) ? 1 : 0));
                this.lbTotalCount.Text = string.Format("共计{0}条", this.totalCount.ToString());

                if (this.currentPage > totalPages - 1) this.currentPage--;

                // 清单资料
                DataTable dt = archive_baseinfo.GetHealthData(reqGerneralCol + reqLifeCol + reqPhysicalCol +
                    reqCheckCol + reqFunctionCol + reqHealthCol + reqAssessCol + reqGerneralTipCol + reqLifeTipCol +
                    reqPhysicalTipCol + reqCheckTipCol + reqFunctionTipCol + reqHealthTipCol + reqAssessTipCol,
                    where + reqWhere, "", this.currentPage * this.pageCount, this.pageCount
                );

                this.TransDs(dt);

                this.lbPages.Text = string.Format("{0}/{1}页", this.currentPage + 1, this.totalPages);

                this.bds.DataSource = dt;
                this.dgvData.DataSource = this.bds;

                if (dt != null && dt.Rows.Count > 0)
                {
                    toolTipX = this.dgvData.GetCellDisplayRectangle(3, 0, false).X;
                    toolTipX2 = this.dgvData.GetCellDisplayRectangle(4, 0, false).X;
                    toolTipX3 = this.dgvData.GetCellDisplayRectangle(5, 0, false).X;
                    toolTipX4 = this.dgvData.GetCellDisplayRectangle(6, 0, false).X;
                    toolTipX5 = this.dgvData.GetCellDisplayRectangle(7, 0, false).X;
                    toolTipX6 = this.dgvData.GetCellDisplayRectangle(8, 0, false).X;
                    toolTipX7 = this.dgvData.GetCellDisplayRectangle(9, 0, false).X;
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
                MessageBox.Show(" 体检日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        private void frmOutInfoQuery_Load(object sender, EventArgs e)
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
                str2 = !Regex.IsMatch(input, @"^\d{15}") ? string.Format(" and Base.CustomerName LIKE '%{0}%'", input) : ("and Base.IDCardNo LIKE '%" + input + "%'");
            }
            if (!string.IsNullOrEmpty(this.tbAddr.Text.Trim()))
            {
                str2 = str2 + string.Format(" AND Base.HouseHoldAddress LIKE '%{0}%' ", this.tbAddr.Text.Trim());
            }
            if (this.ckCheckDate.Checked)
            {
                str2 = str2 + string.Format(" AND Customer.CheckDate BETWEEN '{0}' AND '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.ckxCreatedDate.Checked)
            {
                str2 = str2 + string.Format(" AND Base.CreateDate BETWEEN '{0}' AND '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.cbxUser.Text != "不限")
            {
                str2 = str2 + string.Format(" AND Base.CreateMenName = '{0}' ", this.cbxUser.Text.ToString()); ;
            }
            if (this.cboDoctor.Text != "不限")
            {
                str2 = str2 + string.Format(" AND Customer.Doctor = '{0}' ", this.cboDoctor.Text.ToString()); ;
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

                if (!string.IsNullOrEmpty(view.Row["CustomerID"].ToString()))
                {
                    PhysicalInfoFactory.ID = int.Parse(view.Row["CustomerID"].ToString());
                }

                //一般情况
                if (e.ColumnIndex == dgvData.Columns[3].Index)
                {
                    using (Controler controler = new Controler(new PhysicalForm(idNo), new PhysicalInfoFactory(1)))
                    {
                        controler.IParentFrm.IShowDialog();
                        GetData();
                        return;
                    }
                }

                //生活方式
                if (e.ColumnIndex == dgvData.Columns[4].Index)
                {
                    using (Controler controler = new Controler(new MDIParentForm(idNo), new PhysicalInfoFactory(2)))
                    {
                        controler.IParentFrm.IShowDialog();
                        GetData();
                        return;
                    }
                }

                //查体信息
                if (e.ColumnIndex == dgvData.Columns[5].Index)
                {
                    using (Controler controler = new Controler(new MDIParentForm(idNo), new PhysicalInfoFactory(3)))
                    {
                        controler.IParentFrm.IShowDialog();
                        GetData();
                        return;
                    }
                }

                //辅助检查
                if (e.ColumnIndex == dgvData.Columns[6].Index)
                {
                    using (Controler controler = new Controler(new MDIParentForm(idNo), new PhysicalInfoFactory(4)))
                    {
                        controler.IParentFrm.IShowDialog();
                        GetData();
                        return;
                    }
                }

                //脏器功能
                if (e.ColumnIndex == dgvData.Columns[7].Index)
                {
                    using (Controler controler = new Controler(new MDIParentForm(idNo), new PhysicalInfoFactory(5)))
                    {
                        controler.IParentFrm.IShowDialog();
                        GetData();
                        return;
                    }
                }

                //健康问题
                if (e.ColumnIndex == dgvData.Columns[8].Index)
                {
                    using (Controler controler = new Controler(new MDIParentForm(idNo), new PhysicalInfoFactory(6)))
                    {
                        controler.IParentFrm.IShowDialog();
                        GetData();
                        return;
                    }
                }

                //健康评价
                if (e.ColumnIndex == dgvData.Columns[9].Index)
                {
                    using (Controler controler = new Controler(new MDIParentForm(idNo), new PhysicalInfoFactory(8)))
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
            // 一般情况
            if (dgvData["Column1", e.RowIndex].Value.ToString() == "0")
            {
                dgvData["Column1", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["Column1", e.RowIndex].Value = "";
            }

            // 生活方式
            if (dgvData["Column2", e.RowIndex].Value.ToString() == "0")
            {
                dgvData["Column2", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["Column2", e.RowIndex].Value = "";
            }

            // 查体信息
            if (dgvData["Column3", e.RowIndex].Value.ToString() == "0")
            {
                dgvData["Column3", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["Column3", e.RowIndex].Value = "";
            }

            // 辅助检查
            if (dgvData["Column4", e.RowIndex].Value.ToString() == "0")
            {
                dgvData["Column4", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["Column4", e.RowIndex].Value = "";
            }

            // 脏器功能
            if (dgvData["Column5", e.RowIndex].Value.ToString() == "0")
            {
                dgvData["Column5", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["Column5", e.RowIndex].Value = "";
            }

            // 健康问题
            if (dgvData["Column6", e.RowIndex].Value.ToString() == "0")
            {
                dgvData["Column6", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["Column6", e.RowIndex].Value = "";
            }

            // 健康评价
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

            if (e.ColumnIndex == 3 && dgvData["Column1", e.RowIndex].Value.ToString() != "")
            {
                toolTipValue = (dgvData.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString() +
                    dgvData.Rows[e.RowIndex].Cells["NormalInfo"].Value.ToString() ?? string.Empty).ToString();

                this.toolTip1.Show(toolTipValue, this.dgvData, new Point(toolTipX - 160, e.RowIndex * 50)); //在指定位置显示提示框
            }
            else if (e.ColumnIndex == 4 && dgvData["Column2", e.RowIndex].Value.ToString() != "")
            {
                toolTipValue = (dgvData.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString() +
                   dgvData.Rows[e.RowIndex].Cells["LifeInfo"].Value.ToString() ?? string.Empty).ToString();

                this.toolTip1.Show(toolTipValue, this.dgvData, new Point(toolTipX2 - 160, e.RowIndex * 50));//在指定位置显示提示框
            }
            else if (e.ColumnIndex == 5 && dgvData["Column3", e.RowIndex].Value.ToString() != "")
            {
                toolTipValue = (dgvData.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString() +
                   dgvData.Rows[e.RowIndex].Cells["PhysicalInfo"].Value.ToString() ?? string.Empty).ToString();

                this.toolTip1.Show(toolTipValue, this.dgvData, new Point(toolTipX3 - 160, e.RowIndex * 50));//在指定位置显示提示框
            }
            else if (e.ColumnIndex == 6 && dgvData["Column4", e.RowIndex].Value.ToString() != "")
            {
                toolTipValue = (dgvData.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString() +
                   dgvData.Rows[e.RowIndex].Cells["CheckInfo"].Value.ToString() ?? string.Empty).ToString();

                this.toolTip1.Show(toolTipValue, this.dgvData, new Point(toolTipX4 - 160, e.RowIndex * 50));//在指定位置显示提示框
            }
            else if (e.ColumnIndex == 7 && dgvData["Column5", e.RowIndex].Value.ToString() != "")
            {
                toolTipValue = (dgvData.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString() +
                   dgvData.Rows[e.RowIndex].Cells["FunctionInfo"].Value.ToString() ?? string.Empty).ToString();

                this.toolTip1.Show(toolTipValue, this.dgvData, new Point(toolTipX5 - 160, e.RowIndex * 50));//在指定位置显示提示框
            }
            else if (e.ColumnIndex == 8 && dgvData["Column6", e.RowIndex].Value.ToString() != "")
            {
                toolTipValue = (dgvData.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString() +
                   dgvData.Rows[e.RowIndex].Cells["HealthInfo"].Value.ToString() ?? string.Empty).ToString();

                this.toolTip1.Show(toolTipValue, this.dgvData, new Point(toolTipX6 - 160, e.RowIndex * 50));//在指定位置显示提示框
            }
            else if (e.ColumnIndex == 9 && dgvData["Column8", e.RowIndex].Value.ToString() != "")
            {
                toolTipValue = (dgvData.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString() +
                   dgvData.Rows[e.RowIndex].Cells["AssessInfo"].Value.ToString() ?? string.Empty).ToString();

                this.toolTip1.Show(toolTipValue, this.dgvData, new Point(toolTipX7 - 160, e.RowIndex * 50));//在指定位置显示提示框
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