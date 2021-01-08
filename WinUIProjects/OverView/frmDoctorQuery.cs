using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonUI;

namespace OverView
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    public partial class frmDoctorQuery : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private BindingSource bds;
        private int currentPage;
        private DataTable dt_user;
        private int totalCount;
        private int totalPages;
        private int pageCount = 10;
        private BindingSource bds_arcity;
        private BindingSource bds_ardistrict;
        private BindingSource bds_arprovince;
        private BindingSource bds_artown;
        private BindingSource bds_arvillage;
        private DataTable dt_city;
        private DataTable dt_district;
        private DataTable dt_province;
        private DataTable dt_town;
        private DataTable dt_village;
        private string stradress = "";
        private string provinceCode = "";
        private string cityCode = "";
        private string districtCode = "";
        private string townCode = "";
        private string villageCode = "";
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/" : ConfigurationManager.AppSettings["SignPath"].ToString(); //签名保存路径

        public frmDoctorQuery()
        {
            InitializeComponent();
            this.dgvData.AutoGenerateColumns = false;
            this.EveryThingIsOk = false;
            this.HaveToSave = false;
        }
        private void btnQuery_Click(object sender, EventArgs e) //查询
        {
            if (this.btnQuery.Text == "重置条件")
            {
                this.groupBox1.Enabled = true;
                this.btnQuery.Text = "查询";
                txtIdNum.Text = "";
               // tbAddr.Text = "";
                dtpSt.Text = "";
                dtpEd.Text = "";
                dtpCreatedDateSt.Text = "";
                dtpCreatedDateEd.Text = "";
            }
            else if (this.ckCheckDate.Checked && (this.dtpSt.Value.Date > this.dtpEd.Value.Date))
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
                this.btnQuery.Enabled = false;
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
                    this.groupBox1.Enabled = false;
                    this.btnQuery.Enabled = true;
                    this.btnQuery.Text = "重置条件";
                }
            }
        }

        private void btnFront_Click(object sender, EventArgs e) //上一页
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

        private void btnNext_Click(object sender, EventArgs e) //下一页
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
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.bds.Position >= 0)
            {
                DataRowView view = this.bds.List[this.bds.Position] as DataRowView;
                if (view != null)
                {
                    DataRow row = view.Row;
                    if (row["HouseRelation"].ToString() == "1")
                    {
                        string str = "？当前人员为户主且有相应的家庭档案信息，是否删除现家庭档案和所有家庭成员的关联关系？";
                        if (MessageBox.Show("确定删除:" + row["CustomerName"].ToString() + str + "删除之后的信息将无法恢复!", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
                            foreach (RecordsBaseInfoModel archive_baseinfo2 in archive_baseinfo.GetModelList(string.Format(" and FamilyIDCardNo = '{0}' ", row["IDCardNo"].ToString())))
                            {
                                archive_baseinfo2.RecordID = null;
                                archive_baseinfo2.HouseRelation = null;
                                archive_baseinfo2.HouseRealOther = null;
                                archive_baseinfo.Update(archive_baseinfo2);
                            }
                            RecordsFamilyInfoBLL archive_family_info = new RecordsFamilyInfoBLL();
                            RecordsFamilyInfoModel model = archive_family_info.GetModel(row["IDCardNo"].ToString());

                            if (model != null)
                            {
                                archive_family_info.Delete(model.ID);
                            }

                            //删除签名
                            DeteSign(SignPath, row["IDCardNo"].ToString());

                            new RecordsBaseInfoBLL().DelTheMan(row["IDCardNo"].ToString());
                            row.Delete();
                            row.Table.AcceptChanges();
                        }
                    }
                    else if (MessageBox.Show("确定删除:" + row["CustomerName"].ToString() + "？删除之后的信息将无法恢复!", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        //删除签名
                        DeteSign(SignPath, row["IDCardNo"].ToString());

                        new RecordsBaseInfoBLL().DelTheMan(row["IDCardNo"].ToString());
                        row.Delete();
                        row.Table.AcceptChanges();
                    }
                }
            }
        }

        //删除签名
        public void DeteSign(string signPath, string IDCardNo)
        {
            try
            {
                if (!Directory.Exists(signPath))
                {
                    return;
                }
                DirectoryInfo dir = new DirectoryInfo(signPath);
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo fi in files)
                {
                    if (fi.Name.Contains(IDCardNo))
                    {
                        File.Delete(fi.FullName);
                    }
                }

                DirectoryInfo[] dirInfo = dir.GetDirectories();
                foreach (DirectoryInfo dr in dirInfo)
                {
                    DeteSign(dr.FullName, IDCardNo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void DatatableToCSVFile(Dictionary<string, string> fgt, DataTable dt, string fileName)
        {
            try
            {
                string str = "";
                foreach (KeyValuePair<string, string> pair in fgt)
                {
                    str = str + pair.Value + ',';
                }
                string str2 = str.TrimEnd(new char[] { ',' });
                StreamWriter writer = new StreamWriter(File.Create(fileName), Encoding.Default);
                writer.WriteLine(str2);
                foreach (DataRow row in dt.Rows)
                {
                    string str3 = "";
                    foreach (KeyValuePair<string, string> pair2 in fgt)
                    {
                        DateTime time;
                        if ((pair2.Key == "Birthday") || (pair2.Key == "CreateDate") || (pair2.Key == "CheckDate"))
                        {
                            if (!DateTime.TryParse(row[pair2.Key].ToString(), out time))
                                str3 = str3 + row[pair2.Key].ToString() + ",";
                            else
                                str3 = str3 + time.ToShortDateString() + ",";
                        }
                        else if (pair2.Key == "IDCardNo")
                        {
                            str3 = str3 + "\t" + row[pair2.Key].ToString() + ",";
                        }
                        else
                        {
                            str3 = str3 + row[pair2.Key].ToString() + ",";
                        }
                        //str3 = (((pair2.Key == "Birthday") || (pair2.Key == "CreateDate")) || (pair2.Key == "LastUpdateDate")) ?
                        //    (!DateTime.TryParse(row[pair2.Key].ToString(), out time) ? (str3 + row[pair2.Key].ToString() + ",") :
                        //    (str3 + time.ToShortDateString() + ",")) : (str3 + row[pair2.Key].ToString() + ",");
                    }
                    string str4 = str3.TrimEnd(new char[] { ',' });
                    writer.WriteLine(str4);
                }
                writer.Flush();
                writer.Close();
                MessageBox.Show("导出文件至" + fileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                LogHelper.LogError(exception);
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            DataSet list = new RecordsBaseInfoBLL().GetListDT(this.GetWhere(), " b.CheckDate DESC,b.IDCardNo");
            if (list.Tables.Count == 0)
            {
                MessageBox.Show("统计结果为空!!");
            }
            else if (list.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("统计结果为空!!");
            }
            else
            {
                this.TransDs(list);
                Dictionary<string, string> fgt = new Dictionary<string, string>();
                fgt.Add("CustomerName", "姓名");
                fgt.Add("IDCardNo", "身份证");
                fgt.Add("Sex", "性别");
                fgt.Add("Birthday", "生日");
                fgt.Add("Phone", "电话");
                fgt.Add("HouseHoldAddress", "住址");
                fgt.Add("CreateDate", "建档日期");
                fgt.Add("CheckDate", "体检日期");
                this.DatatableToCSVFile(fgt, list.Tables[0], @"d:\" + string.Format(@"\人员列表{0}.csv", DateTime.Now.ToString("yyyyMMddHHmmss")));
            }
        }
        private string GetWhere()
        {
            string input = this.txtIdNum.Text.Trim();
            string str2 = "",stradress1="";
            if (this.ckbAddr.Checked)
            {
                if (this.cbxDistrict.SelectedIndex != -1)
                {
                    this.districtCode = this.dt_district.Rows[cbxDistrict.SelectedIndex]["Code"].ToString();
                    str2 = str2 + string.Format(" and T.DistrictID = '{0}' ", this.districtCode);
                }

                if (this.cbxTown.SelectedIndex != -1 && this.cbxTown.Text != "")
                {
                    str2 = str2 + string.Format(" and T.TownName = '{0}' ", this.cbxTown.Text);
                }

                if (this.cbxVillage.SelectedIndex != -1 && this.cbxVillage.Text != "")
                {
                    str2 = str2 + string.Format(" and T.VillageName = '{0}' ", this.cbxVillage.Text);
                }
            }

            if (input != "")
            {
                str2 = !Regex.IsMatch(input, "^[0-9]*$") ? string.Format(" and T.CustomerName like '%{0}%'", input) : ("and T.IDCardNo LIKE '%" + input + "%'");
            }

            if (!string.IsNullOrEmpty(this.stradress))
            {
                str2 = str2 + string.Format(" and ( T.HouseHoldAddress LIKE '%{0}%' or T.HouseHoldAddress LIKE '%{1}%' )", this.stradress, stradress1);
            }
            if (this.ckCheckDate.Checked)
            {
                str2 = str2 + string.Format(" and B.CheckDate between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.ckxCreatedDate.Checked)
            {
                str2 = str2 + string.Format(" and T.LastUpdateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
            }

            if(this.ckBVisitPerson.Checked)
            {
                if (this.ckBKids.Checked) //儿童
                {
                    str2 = str2 + string.Format(" and T.PopulationType like '%2%'");
                }

                if (this.ckBGravid.Checked) //孕妇
                {
                    str2 = str2 + string.Format(" and T.PopulationType like '%3%' ");
                }

                if (this.ckBOlder.Checked) //老人
                {
                    str2 = str2 + string.Format(" and T.PopulationType like '%4%' ");
                }

                if (this.ckBMentaldisease.Checked)//精神病
                {
                    str2 = str2 + string.Format(" and T.PopulationType like '%5%' ");
                }

                if (this.ckBHypertension.Checked)//高血压
                {
                    str2 = str2 + string.Format(" and T.PopulationType like '%6%' ");
                }

                if (this.ckBDiabetes.Checked) //糖尿病
                {
                    str2 = str2 + string.Format(" and T.PopulationType like '%7%' ");
                }

                if (this.ckBChd.Checked) //冠心病
                {
                    str2 = str2 + string.Format(" and T.PopulationType like '%8%' ");
                }

                if(this.ckBStroke.Checked) //脑卒中
                {
                    str2 = str2 + string.Format(" and T.PopulationType like '%9%' ");
                }
                if (this.cklunger.Checked) //肺结核
                {
                    str2 = str2 + string.Format(" and T.PopulationType like '%10%' ");
                }
            }

            if (this.cbxUser.Text != "不限")
            {
                str2 = str2 + string.Format(" and T.CreateMenName = '{0}' ", this.cbxUser.Text.ToString());
            }

          
            return str2;
        }
        private void TransDs(DataSet ds)
        {
            ds.Tables[0].Columns.Add("BlueToothRecord");
            DeviceInfoBLL tbl_deviceinfo = new DeviceInfoBLL();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
                row["Nation"] = !(row["Nation"].ToString() == "1") ? row["MINORITY"] : "汉";
                if (tbl_deviceinfo.GetRecordCount(string.Format(" IDCardNo = '{0}'", row["IDCardNo"])) > 0)
                {
                    row["BlueToothRecord"] = "检测数据";
                }
            }
        }
        private void frmDoctorQuery_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
            try
            {
                if (this.checkTableExist())
                {
                    this.GetArea();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void BindArea(ComboBox cbx, BindingSource bds, decimal id)
        {
            Action<ComboBox, BindingSource, decimal> method = new Action<ComboBox, BindingSource, decimal>(this.BindArea);

            if (cbx.InvokeRequired)
            {
                cbx.Invoke(method, new object[] { cbx, bds });
            }
            else
            {
                //cbx.ValueMember = "ID";
                cbx.ValueMember = "Name";
                cbx.DataSource = bds;
                cbx.SelectedValue = id;
            }
        }
        private void GetArea()
        {
            decimal num = 0;
            decimal num2 = 0;
            decimal num3 = 0;
            string orgCode = ConfigHelper.GetNode("archiveid");
            this.dt_province = new RecordsProvinceBLL().GetList("Code='" + orgCode.Substring(0, 2) + "'").Tables[0];
            string cityID = "";
            DataRow provincerow = dt_province.Rows[0];
            provinceCode = provincerow["Name"].ToString();
            this.dt_city = new RecordsCityBLL().GetList("Code='" + orgCode.Substring(0, 4) + "'").Tables[0];
            DataRow cityrow = dt_city.Rows[0];
            cityID = cityrow["ID"].ToString();
            cityCode = cityrow["Name"].ToString();
            this.dt_district = new RecordsDistrictBLL().GetList("CityID='" + cityID + "'").Tables[0];
            this.bds_ardistrict = new BindingSource();
            this.bds_ardistrict.DataSource = this.dt_district;
            this.BindArea(this.cbxDistrict, this.bds_ardistrict, num3);
        }
        private void cbxDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtT = new DataTable();
            dtT.Columns.Add("TownName");
            dtT.Columns.Add("VillageName");
            cbxTown.DataSource = dtT;
            cbxVillage.DataSource = dtT.Clone();

            if (cbxDistrict.SelectedIndex != -1)
            {
                string districtid = this.dt_district.Rows[cbxDistrict.SelectedIndex][1].ToString();
                this.dt_town = new RecordsBaseInfoBLL().GetList(" and DistrictId='" + districtid + "' group by TownName  ").Tables[0];
                this.dt_town.Rows.Add(dt_town.NewRow());
                this.cbxTown.ValueMember = "TownName";
                this.cbxTown.DataSource = this.dt_town;
            }
        }
        private void cbxTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTown.SelectedIndex != -1 && cbxDistrict.SelectedIndex != -1)
            {
                string districtid = this.dt_district.Rows[cbxDistrict.SelectedIndex][1].ToString();
                this.dt_village = new RecordsBaseInfoBLL().GetList(" and DistrictId='" + districtid + "' and TownName = '" + cbxTown.Text + "' group by VillageName ").Tables[0];
                this.dt_village.Rows.Add(dt_village.NewRow());
                this.cbxVillage.ValueMember = "VillageName";
                this.cbxVillage.DataSource = this.dt_village;
            }
        }
        private bool checkTableExist()
        {
            return new DataOperationBLL().TableExist(new string[] { "tbl_recordscity", "tbl_recordsdistrict", "tbl_recordsprovince", 
                "tbl_recordstown", "tbl_recordsvillage" });
        }
        private void ckCheckDate_CheckedChanged(object sender, EventArgs e) //出生日期
        {
            this.dtpSt.Enabled = this.ckCheckDate.Checked;
            this.dtpEd.Enabled = this.ckCheckDate.Checked;
        }
        private void ckBVisitPerson_CheckedChanged(object sender, EventArgs e) //随访人群
        {
            this.panelVisit.Enabled = this.ckBVisitPerson.Checked;
        }
        private void ckxCreatedDate_CheckedChanged(object sender, EventArgs e) //建档日期
        {
            this.dtpCreatedDateSt.Enabled = this.ckxCreatedDate.Checked;
            this.dtpCreatedDateEd.Enabled = this.ckxCreatedDate.Checked;
        }
        private void ckBOlder_CheckedChanged(object sender, EventArgs e) //老年人
        {
            if (this.ckBOlder.Checked)
            {
                this.ckBGravid.Enabled = false;
                this.ckBKids.Enabled = false;
            }
            else
            {
                this.ckBGravid.Enabled = true;
                this.ckBKids.Enabled = true;
            }
        }
        private void ckBKids_CheckedChanged(object sender, EventArgs e) //儿童
        {
            if (this.ckBKids.Checked)
            {
                this.ckBGravid.Enabled = false;
                this.ckBOlder.Enabled = false;
            }
            else
            {
                this.ckBGravid.Enabled = true;
                this.ckBOlder.Enabled = true;
            }
        }
        private void ckBGravid_CheckedChanged(object sender, EventArgs e)//孕产妇
        {
            if (this.ckBGravid.Checked)
            {
                this.ckBKids.Enabled = false;
                this.ckBOlder.Enabled = false;
            }
            else
            {
                this.ckBKids.Enabled = true;
                this.ckBOlder.Enabled = true;
            }
        }
        private void ckbAddr_CheckedChanged(object sender, EventArgs e) //住址
        {
            this.panelAddr.Enabled = this.ckbAddr.Checked;
            if (!this.ckbAddr.Checked)
            {
                this.cbxDistrict.SelectedIndex = -1;
                this.cbxTown.Text = string.Empty;
                this.cbxVillage.Text = string.Empty;
            }
        }
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((this.dgvData.Columns[e.ColumnIndex].HeaderText == "体检数据") && (this.bds.Position >= 0)) && (e.RowIndex >= 0))
            {
                DataRowView view = (DataRowView)this.bds.List[this.bds.Position];
                if (this.dgvData[e.ColumnIndex, this.bds.Position].Value.ToString() == "检测数据")
                {
                    FrmBT_Data data = new FrmBT_Data
                    {
                        IDCardNo = view.Row["IDCardNo"].ToString()
                    };
                    data.StartPosition = FormStartPosition.CenterParent;
                    data.ShowDialog();
                }
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
        private List<RecordsBaseInfoModel> findModels { get; set; }
        public RecordsBaseInfoModel Model { get; set; }
        public bool EveryThingIsOk { get; set; }
        public bool HaveToSave { get; set; }
        public string SaveDataInfo { get; set; }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            DataSet list = new RecordsBaseInfoBLL().GetListDT(this.GetWhere(), "");
            if (list.Tables.Count == 0)
            {
                MessageBox.Show("统计结果为空!!");
            }
            else if (list.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("统计结果为空!!");
            }
            else
            {
                this.TransReportDs(list);
                Dictionary<string, string> fgt = new Dictionary<string, string>();
                fgt.Add("No", "序号");
                fgt.Add("CustomerName", "姓名");
                fgt.Add("HouseHoldAddress", "住址");
                fgt.Add("isFloatPop", "是否流动人口");
                fgt.Add("isHousePop", "是否为户籍人口");
                fgt.Add("CheckDate", "签约时间");
                fgt.Add("Phone", "电话号码");
                this.DatatableToCSVFile(fgt, list.Tables[0], @"d:\" + string.Format(@"\人群周报表{0}.csv", DateTime.Now.ToString("yyyyMMddHHmmss")));
            }
        }


        private void TransReportDs(DataSet ds)
        {
            ds.Tables[0].Columns.Add("No");
            ds.Tables[0].Columns.Add("isFloatPop");
            ds.Tables[0].Columns.Add("isHousePop");
            DeviceInfoBLL tbl_deviceinfo = new DeviceInfoBLL();
            int i = 1;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row["No"] = i.ToString();
                if (!string.IsNullOrEmpty(row["LiveType"].ToString()))
                {
                    if (row["LiveType"].ToString() == "1")
                    {
                        row["isHousePop"] = "√";
                    }
                    else
                    {
                        row["isFloatPop"] = "√";
                    }
                }
                i++;
            }
        }
     
    }
}
