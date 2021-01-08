using FocusGroup.OldPeople;
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
    using RecordManagement;

    public partial class frmOutOldMen : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private int currentPage;
        private int totalPages;
        private int totalCount;
        private int pageCount = 10;
        private BindingSource bds;
        private DataTable dt_user;
        private DataTable dtTmp;
        private RequireBLL RequireBLL = new RequireBLL();
        private DataTable requiredt;
        public frmOutOldMen()
        {
            InitializeComponent();
            this.dgvData.AutoGenerateColumns = false;
            this.EveryThingIsOk = false;
            this.HaveToSave = false;
            requiredt = RequireBLL.GetList(" TabName = '老年人随访' ").Tables[0];
        }

        /// <summary>
        /// 检核栏位输入
        /// </summary>
        private void ChackDate()
        {
            string where = this.GetWhere();

            if (string.IsNullOrEmpty(where))
            {
                MessageBox.Show("请选择查询条件！", "查询条件", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.btnQuery.Enabled = false;
                RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
                DataSet ds = archive_baseinfo.GetListDT(where, "");

                if (ds.Tables.Count > 0)
                {
                    dtTmp = this.TransDs(ds);
                }

                this.totalCount = dtTmp.Rows.Count;
                this.totalPages = (this.totalCount <= this.pageCount) ? 1 : ((this.totalCount / this.pageCount) + (((this.totalCount % this.pageCount) > 0) ? 1 : 0));

                if (this.currentPage > totalPages - 1) this.currentPage--;

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
                this.btnQuery.Enabled = true;
                this.btnQuery.Text = "重置条件";
            }
        }
        private void btnFront_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 0)
            {
                this.lbPages.Text = string.Format("{0}/{1}页", --this.currentPage + 1, this.totalPages);

                DataTable dtTemp = dtTmp.Clone();
                int nextV = (this.currentPage + 1) * this.pageCount;

                for (int i = (this.currentPage) * this.pageCount; i < nextV; i++)
                {
                    dtTemp.ImportRow(dtTmp.Rows[i]);
                }
                this.bds.DataSource = dtTemp;
                this.dgvData.DataSource = this.bds;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.currentPage < (this.totalPages - 1))
            {
                this.lbPages.Text = string.Format("{0}/{1}页", ++this.currentPage + 1, this.totalPages);

                DataSet ds = new RecordsBaseInfoBLL().GetListByPage(this.GetWhere(), "", this.currentPage * this.pageCount, this.pageCount);

                DataTable dtTemp = dtTmp.Clone();
                int nextV = (this.currentPage + 1) * this.pageCount;
                if (nextV > this.totalCount)
                {
                    nextV = this.totalCount;
                }
                for (int i = this.currentPage * this.pageCount; i < nextV; i++)
                {
                    dtTemp.ImportRow(dtTmp.Rows[i]);
                }

                this.bds.DataSource = dtTemp;
                this.dgvData.DataSource = this.bds;
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
                ChackDate();

            }
        }

        private void frmOutOldMen_Load(object sender, EventArgs e)
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

            this.EveryThingIsOk = true;
        }

        private DataTable SetDate(DataTable dt)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "oldercount != 0";
            return dv.ToTable(true);
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
                str2 = !Regex.IsMatch(input, "^[0-9]*$") ? string.Format(" and T.CustomerName like '%{0}%'", input) : ("and T.IDCardNo LIKE '%" + input + "%'");
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

            str2 = str2 + string.Format("and T.PopulationType LIKE '%{0}%' ", "4");

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
            if (this.cbxUser.Text != "不限")
            {
                str2 = str2 + string.Format(" and T.CreateMenName = '{0}' ", this.cbxUser.Text.ToString()); ;
            }
           
            return str2;
        }

        private DataTable TransDs(DataSet ds)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("CustomerName");
            dt.Columns.Add("Sex");
            dt.Columns.Add("IDCardNo");
            dt.Columns.Add("oldercount");
            dt.Columns.Add("SelfCount");
            dt.Columns.Add("Nation");
            dt.Columns.Add("Birthday");
            dt.Columns.Add("Phone");
            dt.Columns.Add("CreateDate");
            dt.Columns.Add("LastUpdateDate");
            dt.Columns.Add("PID");
            dt.Columns.Add("SID");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string data = "";
                if (!string.IsNullOrEmpty(row["CheckDate"].ToString()))
                {
                    data = row["CheckDate"].ToString().Substring(0,4);
                }
               
                int oldercount = 0;
                row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
                string selfID ="";
                DataTable olderdt = new OlderSelfCareabilityBLL().GetList(string.Format("IDCardNo = '{0}'and Left(FollowUpDate,4)='{1}'", row["IDCardNo"], data)).Tables[0];
                if (olderdt.Rows.Count == 0)
                {
                    oldercount++;
                   
                    //foreach (DataRow item in requiredt.Rows)
                    //{
                    //    if (item["Isrequired"].ToString() == "1")
                    //    {
                    //        oldercount++;
                    //    }
                    //}
                }
                //else
                //{
                //    DataRow rows = olderdt.Rows[0];
                      //selfID = olderdt.Rows[0]["ID"].ToString();
                //    foreach (DataRow item in requiredt.Rows)
                //    {
                //        if (item["Isrequired"].ToString() == "1")
                //        {
                //            switch (item["ChinName"].ToString())
                //            {
                //                case "进餐":
                //                    if (string.IsNullOrEmpty(rows["Dine"].ToString()))
                //                    {
                //                        oldercount++;
                //                    }
                //                    break;
                //                case "梳洗":
                //                    if (string.IsNullOrEmpty(rows["Groming"].ToString()))
                //                    {
                //                        oldercount++;
                //                    }
                //                    break;
                //                case "穿衣":
                //                    if (string.IsNullOrEmpty(rows["Dressing"].ToString()))
                //                    {
                //                        oldercount++;
                //                    }
                //                    break;
                //                case "如厕":
                //                    if (string.IsNullOrEmpty(rows["Tolet"].ToString()))
                //                    {
                //                        oldercount++;
                //                    }
                //                    break;
                //                case "活动":
                //                    if (string.IsNullOrEmpty(rows["Activity"].ToString()))
                //                    {
                //                        oldercount++;
                //                    }
                //                    break;
                //                case "随访医生":
                //                    if (string.IsNullOrEmpty(rows["FollowUpDoctor"].ToString()))
                //                    {
                //                        oldercount++;
                //                    }
                //                    break;
                //                case "总得分":
                //                    if (string.IsNullOrEmpty(rows["TotalScore"].ToString()))
                //                    {
                //                        oldercount++;
                //                    }
                //                    break;
                //                case "随访日期":
                //                    if (string.IsNullOrEmpty(rows["FollowUpDate"].ToString()))
                //                    {
                //                        oldercount++;
                //                    }
                //                    break;
                //                case "下次随访日期":
                //                    if (string.IsNullOrEmpty(rows["NextfollowUpDate"].ToString()))
                //                    {
                //                        oldercount++;
                //                    }
                //                    break;
                //                case "下次随访目标":
                //                    if (string.IsNullOrEmpty(rows["NextVisitAim"].ToString()))
                //                    {
                //                        oldercount++;
                //                    }

                //                    break;
                //                default: break;
                //            }
                //        }
                //    }
                //}
                int OutKey = 0;
                int SelfCount = 0;
                if (row["PID"].ToString() != "" && row["PID"].ToString() != "0")
                {
                    OutKey = int.Parse(row["PID"].ToString());
                }
                RecordsGeneralConditionModel GenerModel = new RecordsGeneralConditionBLL().GetModelByOutKey(OutKey);
                if(GenerModel!=null)
                {
                    if (GenerModel.SelfID == 0)
                        SelfCount++;
                }
                if (!(oldercount == 0)||SelfCount!=0)
                {
                    DataRow dr = dt.NewRow();
                    dr["CustomerName"] = row["CustomerName"].ToString().Trim();
                    dr["Sex"] = row["Sex"].ToString().Trim();
                    dr["IDCardNo"] = row["IDCardNo"].ToString().Trim();
                    dr["oldercount"] = Convert.ToString(oldercount);
                    dr["SelfCount"] = Convert.ToString(SelfCount);
                    dr["Nation"] = !(row["Nation"].ToString() == "1") ? row["MINORITY"] : "汉";
                    if (!string.IsNullOrEmpty(row["Birthday"].ToString()))
                    {
                        dr["Birthday"] = DateTime.Parse(row["Birthday"].ToString()).ToString("yyyy-MM-dd");
                    }
                    dr["Phone"] = row["Phone"].ToString().Trim();
                    if (!string.IsNullOrEmpty(row["CreateDate"].ToString()))
                    {
                        dr["CreateDate"] = DateTime.Parse(row["CreateDate"].ToString()).ToString("yyyy-MM-dd");
                    }
                    if (!string.IsNullOrEmpty(row["LastUpdateDate"].ToString()))
                    {
                        dr["LastUpdateDate"] = DateTime.Parse(row["LastUpdateDate"].ToString()).ToShortDateString();
                    }
                    dr["PID"] = row["PID"].ToString().Trim();
                    dr["SID"] = selfID;
                    dt.Rows.Add(dr);
                }
            }

            return dt;
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
        private List<RecordsBaseInfoModel> findModels { get; set; }
        public bool HaveToSave { get; set; }
        public RecordsBaseInfoModel Model { get; set; }
        public string SaveDataInfo { get; set; }
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if ((this.bds.Position >= 0) && (e.RowIndex >= 0))
            {

                DataRowView view = (DataRowView)this.bds.List[this.bds.Position];
                string idNo = view.Row["IDCardNo"].ToString();
                
                if (!string.IsNullOrEmpty(view.Row["PID"].ToString()))
                {
                    PhysicalInfoFactory.ID = int.Parse(view.Row["PID"].ToString());
                    PhysicalInfoFactory.falgID = int.Parse(view.Row["PID"].ToString());
                }
                else
                {
                    PhysicalInfoFactory.ID = 0;
                    PhysicalInfoFactory.falgID = 0;
                }
                if (!string.IsNullOrEmpty(view.Row["SID"].ToString()))
                {
                    OldPeopleInfoFactory.ID = int.Parse(view.Row["SID"].ToString());
                }
                else
                {
                    OldPeopleInfoFactory.ID = 0;
                }
                //老年人基本信息
                if (e.ColumnIndex == dgvData.Columns[9].Index)
                {
                    using (Controler controler = new Controler(new MDIParentForm(idNo), new OldPeopleInfoFactory()))
                    {
                        controler.IParentFrm.IShowDialog();
                        ChackDate();
                        return;
                    }
                }
                //一般情况 自理能力
                if (e.ColumnIndex == dgvData.Columns[8].Index)
                {
                    using (Controler controler = new Controler(new PhysicalForm(idNo), new PhysicalInfoFactory(1)))
                    {
                        controler.IParentFrm.IShowDialog();
                        ChackDate();
                        return;
                    }
                }
            }
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvData["Column8", e.RowIndex].Value.ToString() == "0")
            {
                dgvData["Column8", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["Column8", e.RowIndex].Value = "";
            }
            if (dgvData["Column7", e.RowIndex].Value.ToString() == "0")
            {
                dgvData["Column7", e.RowIndex] = new DataGridViewTextBoxCell();
                dgvData["Column7", e.RowIndex].Value = "";
            }
        }
    }
}
