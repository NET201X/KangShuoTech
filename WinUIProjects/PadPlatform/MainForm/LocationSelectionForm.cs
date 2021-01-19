using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.Utilities.Common;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace KangShuo
{
    public class LocationSelectionForm : Form
    {
        private BindingSource bds_arcity;
        private BindingSource bds_ardistrict;
        private BindingSource bds_arprovince;
        private BindingSource bds_artown;
        private BindingSource bds_arvillage;
        private BindingSource bds_Orgcity;
        private BindingSource bds_Orgdistrict;
        private BindingSource bds_Orgprovince;
        private BindingSource bds_Orgtown;
        private BindingSource bds_Orgvillage;
        private BindingSource bds_SysUser;
        private Button btnOk;
        private Button btnQuit;
        private ComboBox cbxOrgCity;
        private ComboBox cbxOrgDistrict;
        private ComboBox cbxOrgProvince;
        private ComboBox cbxOrgTown;
        private ComboBox cbxOrgVillage;
        private ComboBox cbxSysUser;
        private IContainer components;
        private DataTable dt_city;
        private DataTable dt_district;
        private DataTable dt_Orgcity;
        private DataTable dt_Orgdistrict;
        private DataTable dt_Orgprovince;
        private DataTable dt_Orgtown;
        private DataTable dt_Orgvillage;
        private DataTable dt_province;
        private DataTable dt_SysUser;
        private DataTable dt_town;
        private DataTable dt_village;
        private bool goClose;
        private GroupBox groupBox2;
        private Label label5;
        private MaskedTextBox mtbHBDep;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private ComboBox cbxProvince;
        private ComboBox cbxCity;
        private ComboBox cbxDistrict;
        private ComboBox cbxTown;
        private ComboBox cbxVillage;
        private MaskedTextBox mtbArchiveID;
        private GroupBox groupBox1;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtPassWord;
        private TextBox tbDoctorID;
        private Button btnConfigBack;
        private Button btnUpdate;
        private string PassWord;

        public LocationSelectionForm()
        {
            this.InitializeComponent();
            this.areaOrg = new AreaOrg();
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
                if (cbx.Name == this.cbxSysUser.Name)
                {
                    cbx.DisplayMember = "UserName";
                }
                else
                {
                    cbx.DisplayMember = "Name";
                }

                cbx.ValueMember = "ID";
                cbx.DataSource = bds;
                cbx.SelectedValueChanged += new EventHandler(this.cbx_SelectedIndexChanged);
                cbx.SelectedValue = id;
               
            }
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!this.mtbArchiveID.MaskCompleted)
            {
                MessageBox.Show("行政区域编号输入不正确！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (this.mtbHBDep.Text.Length < 6)
            {
                MessageBox.Show("所属组织机构编号输入不正确！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (string.IsNullOrEmpty(this.tbDoctorID.Text))
            {
                MessageBox.Show("医生编号不能为空！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtPassWord.Visible&&PassWord!=this.txtPassWord.Text.ToString())
            {
                MessageBox.Show("医生密码输入错误！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.areaOrg.archiveid = this.mtbArchiveID.Text;
                this.areaOrg.doctor = this.tbDoctorID.Text;
                this.areaOrg.TownName = this.cbxTown.Text;
                this.areaOrg.VillageName = this.cbxVillage.Text;
                this.areaOrg.OrgCode = this.mtbHBDep.Text;
                if ((this.cbxOrgVillage.Text != "") && (this.cbxOrgVillage.Text != "--空--"))
                {
                    this.areaOrg.OrgName = this.cbxOrgVillage.Text;
                }
                else
                {
                    if (MessageBox.Show("组织机构未选择至村级，是否继续", "选择组织机构", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                    {
                        return;
                    }
                    if ((this.cbxOrgTown.Text != "") && (this.cbxOrgTown.Text != "--空--"))
                    {
                        this.areaOrg.OrgName = this.cbxOrgTown.Text;
                    }
                    else if ((this.cbxOrgDistrict.Text != "") && (this.cbxOrgDistrict.Text != "--空--"))
                    {
                        this.areaOrg.OrgName = this.cbxOrgDistrict.Text;
                    }
                }
                this.areaOrg.doctorName = this.cbxSysUser.Text;
                this.goClose = true;
                base.DialogResult = DialogResult.OK;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        
        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;

            if (box.SelectedValue == null)
            {
                if (box.Name == this.cbxSysUser.Name)
                {
                    this.tbDoctorID.Text = "";
                }
                if (box.Name == this.cbxProvince.Name)
                {
                    this.bds_arcity.Filter = "ProvinceID = -1";
                }
                if (box.Name == this.cbxCity.Name)
                {
                    this.bds_ardistrict.Filter = "CityID = -1";
                }
                if (box.Name == this.cbxDistrict.Name)
                {
                    this.bds_artown.Filter = "DistrictID = -1";
                }
                if (box.Name == this.cbxTown.Name)
                {
                    this.bds_arvillage.Filter = "TownID = -1";
                }
                if (box.Name == this.cbxVillage.Name)
                {
                    this.mtbArchiveID.Text = "";
                }
                if (box.Name == this.cbxOrgProvince.Name)
                {
                    this.bds_Orgcity.Filter = "ProvinceID = -1";
                }
                if (box.Name == this.cbxOrgCity.Name)
                {
                    this.bds_Orgdistrict.Filter = "CityID = -1";
                }
                if (box.Name == this.cbxOrgDistrict.Name)
                {
                    this.bds_Orgtown.Filter = "DistrictID = -1";
                }
                if (box.Name == this.cbxOrgTown.Name)
                {
                    this.bds_Orgvillage.Filter = "TownID = -1";
                }
                if (box.Name == this.cbxOrgVillage.Name)
                {
                    this.bds_SysUser.Filter = "VillageID = -1";
                    DataRowView selectedItem = this.cbxOrgTown.SelectedItem as DataRowView;
                    if (selectedItem != null)
                    {
                        DataRow row = selectedItem.Row;
                        if (row["CODE"].ToString().Length == 9)
                        {
                            this.mtbHBDep.Text = row["CODE"].ToString();
                            this.bds_SysUser.Filter = "TownID = " + row["ID"].ToString();
                        }
                    }
                    else
                    {
                        DataRowView view2 = this.cbxOrgDistrict.SelectedItem as DataRowView;
                        if (view2 != null)
                        {
                            DataRow row2 = view2.Row;
                            if (row2["CODE"].ToString().Length == 6)
                            {
                                this.mtbHBDep.Text = row2["CODE"].ToString();
                                this.bds_SysUser.Filter = "DistrictID = " + row2["ID"].ToString();
                            }
                        }
                        else
                        {
                            this.mtbHBDep.Text = "";
                        }
                    }
                }
                if (box.Name == this.cbxSysUser.Name)
                {
                    this.tbDoctorID.Text = "";
                }
            }
            else
            {
                if (box.Name == this.cbxOrgProvince.Name)
                {
                    this.bds_Orgcity.Filter = "ProvinceID = " + box.SelectedValue.ToString() + " OR ProvinceID = -1";
                }
                if (box.Name == this.cbxOrgCity.Name)
                {
                    this.bds_Orgdistrict.Filter = "CityID = " + box.SelectedValue.ToString() + " OR CityID = -1";
                }
                if ((box.Name == this.cbxOrgDistrict.Name) && ((box.SelectedItem as DataRowView).Row["CODE"].ToString().Length == 6))
                {
                    this.bds_Orgtown.Filter = "DistrictID = " + box.SelectedValue.ToString() + " OR DistrictID = -1";
                    this.bds_SysUser.Filter = (this.cbxOrgTown.SelectedItem is DataRowView) ? ("DistrictID = " + box.SelectedValue.ToString()) : ("DistrictID = " + box.SelectedValue.ToString() + " and TownID is null");
                }
                if (box.Name == this.cbxOrgTown.Name)
                {
                    DataRow row3 = (box.SelectedItem as DataRowView).Row;
                    if (row3["CODE"].ToString().Length == 9)
                    {
                        this.mtbHBDep.Text = row3["CODE"].ToString();
                        this.bds_SysUser.Filter = "TownID = " + box.SelectedValue.ToString();
                    }
                    else
                    {
                        DataRowView view3 = this.cbxOrgDistrict.SelectedItem as DataRowView;
                        if (view3 != null)
                        {
                            DataRow row4 = view3.Row;
                            if (row4["CODE"].ToString().Length == 6)
                            {
                                this.mtbHBDep.Text = row4["CODE"].ToString();
                                this.bds_SysUser.Filter = "DistrictID = " + row4["ID"].ToString() + " and TownID is null";
                            }
                        }
                        else
                        {
                            this.mtbHBDep.Text = "";
                        }
                    }
                    this.bds_Orgvillage.Filter = "TownID = " + box.SelectedValue.ToString() + " OR TownID = -1";
                }
                if (box.Name == this.cbxOrgVillage.Name)
                {
                    this.bds_SysUser.Filter = "VillageID = " + box.SelectedValue.ToString();
                    DataRow row5 = (box.SelectedItem as DataRowView).Row;
                    if (row5["CODE"].ToString().Length == 12)
                    {
                        this.mtbHBDep.Text = row5["CODE"].ToString();
                    }
                    else
                    {
                        DataRowView view4 = this.cbxOrgTown.SelectedItem as DataRowView;
                        if (view4 != null)
                        {
                            DataRow row6 = view4.Row;
                            if (row6["CODE"].ToString().Length == 9)
                            {
                                this.mtbHBDep.Text = row6["CODE"].ToString();
                                this.bds_SysUser.Filter = "TownID = " + row6["ID"].ToString() + " and VillageID is null";
                            }
                            else
                            {
                                DataRowView view5 = this.cbxOrgDistrict.SelectedItem as DataRowView;
                                if (view5 != null)
                                {
                                    DataRow row7 = view5.Row;
                                    if (row7["CODE"].ToString().Length == 6)
                                    {
                                        this.mtbHBDep.Text = row7["CODE"].ToString();
                                        this.bds_SysUser.Filter = "DistrictID = " + row7["ID"].ToString() + " and TownID is null";
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.mtbHBDep.Text = "";
                        }
                    }
                }
                if (box.Name == this.cbxSysUser.Name)
                {
                    this.tbDoctorID.Text = (box.SelectedItem as DataRowView).Row["ID"].ToString();
                    PassWord = (box.SelectedItem as DataRowView).Row["PassWord"].ToString();
                }
                if (box.Name == this.cbxProvince.Name)
                {
                    this.bds_arcity.Filter = "ProvinceID = " + box.SelectedValue.ToString();
                }
                if (box.Name == this.cbxCity.Name)
                {
                    this.bds_ardistrict.Filter = "CityID = " + box.SelectedValue.ToString();
                }
                if (box.Name == this.cbxDistrict.Name)
                {
                    this.bds_artown.Filter = "DistrictID = " + box.SelectedValue.ToString();
                }
                if (box.Name == this.cbxTown.Name)
                {
                    this.bds_arvillage.Filter = "TownID = " + box.SelectedValue.ToString();
                }
                if (box.Name == this.cbxVillage.Name)
                {
                    this.mtbArchiveID.Text = (box.SelectedItem as DataRowView).Row["CODE"].ToString();
                }
            }
        }

        private bool checkTableExist()
        {
            return new DataOperationBLL().TableExist(new string[] { "ARCHIVE_CITY", "ARCHIVE_DISTRICT", "ARCHIVE_PROVINCE", 
                "ARCHIVE_TOWN", "ARCHIVE_VILLAGE", "SYS_ORG_CITY", "SYS_ORG_DISTRICT", "SYS_ORG_PROVINCE", "SYS_ORG_TOWN", 
                "SYS_ORG_VILLAGE", "SYS_USER" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FillAreaAndOthers()
        {
            if (!string.IsNullOrEmpty(this.areaOrg.OrgCode) && (this.areaOrg.OrgCode.Length >= 6))
            {
                this.areaOrg.ProvinceHB = this.areaOrg.OrgCode.Substring(0, 2);
                this.areaOrg.CityHB = this.areaOrg.OrgCode.Substring(0, 4);
                this.areaOrg.DistrictHB = this.areaOrg.OrgCode.Substring(0, 6);
                this.areaOrg.TownHB = (this.areaOrg.OrgCode.Length < 9) ? "" : this.areaOrg.OrgCode.Substring(0, 9);
                this.areaOrg.VillageHB = (this.areaOrg.OrgCode.Length != 12) ? "" : this.areaOrg.OrgCode.Substring(0, 12);
            }
            if (!string.IsNullOrEmpty(this.areaOrg.OrgCode) && (this.areaOrg.OrgCode.Length >= 6))
            {
                decimal num;
                if (this.GetAreaIDFromCode(this.areaOrg.ProvinceHB, this.dt_Orgprovince, out num))
                {
                    this.areaOrg.ProvinceHB = num.ToString();
                }
                if (this.GetAreaIDFromCode(this.areaOrg.CityHB, this.dt_Orgcity, out num))
                {
                    this.areaOrg.CityHB = num.ToString();
                }
                if (this.GetAreaIDFromCode(this.areaOrg.DistrictHB, this.dt_Orgdistrict, out num))
                {
                    this.mtbHBDep.Text = this.areaOrg.DistrictHB;
                    this.areaOrg.DistrictHB = num.ToString();
                }
                if (this.GetAreaIDFromCode(this.areaOrg.TownHB, this.dt_Orgtown, out num))
                {
                    this.mtbHBDep.Text = this.areaOrg.TownHB;
                    this.areaOrg.TownHB = num.ToString();
                }
                if (this.GetAreaIDFromCode(this.areaOrg.VillageHB, this.dt_Orgvillage, out num))
                {
                    this.mtbHBDep.Text = this.areaOrg.VillageHB;
                    this.areaOrg.VillageHB = num.ToString();
                }
            }
        }

        private void Find_xingzhengquyu()
        {
            if (!string.IsNullOrEmpty(this.areaOrg.archiveid) && (this.areaOrg.archiveid.Length == 12))
            {
                this.areaOrg.Province = this.areaOrg.archiveid.Substring(0, 2);
                this.areaOrg.City = this.areaOrg.archiveid.Substring(0, 4);
                this.areaOrg.District = this.areaOrg.archiveid.Substring(0, 6);
                this.areaOrg.Town = this.areaOrg.archiveid.Substring(0, 9);
            }
            if (!string.IsNullOrEmpty(this.areaOrg.archiveid) && (this.areaOrg.archiveid.Length == 12))
            {
                decimal num;
                if (this.GetAreaIDFromCode(this.areaOrg.Province, this.dt_province, out num))
                {
                    this.areaOrg.Province = num.ToString();
                }
                if (this.GetAreaIDFromCode(this.areaOrg.City, this.dt_city, out num))
                {
                    this.areaOrg.City = num.ToString();
                }
                if (this.GetAreaIDFromCode(this.areaOrg.District, this.dt_district, out num))
                {
                    this.areaOrg.District = num.ToString();
                }
                if (this.GetAreaIDFromCode(this.areaOrg.Town, this.dt_town, out num))
                {
                    this.areaOrg.Town = num.ToString();
                }
                if (this.GetAreaIDFromCode(this.areaOrg.archiveid, this.dt_village, out num))
                {
                    this.areaOrg.Village = num.ToString();
                    this.mtbArchiveID.Text = this.areaOrg.archiveid;
                }
            }
        }

        private void FrmHAArea_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.goClose)
            {
                e.Cancel = true;
            }
        }

        private void LocationSelectionForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 复制安装目录文件夹
                string path = Application.StartupPath;
                string copyPath = "D:\\QCSoft\\配置文件备份";

                if (!System.IO.Directory.Exists(copyPath))
                {
                    System.IO.Directory.CreateDirectory(copyPath);

                    if (Directory.GetFileSystemEntries(copyPath).Length == 0) CopyDir(path, copyPath);
                }

                if (this.checkTableExist())
                {
                    this.GetOrg();
                    this.GetArea();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void GetArea()
        {
            decimal num;
            decimal num2;
            decimal num3;
            decimal num4;
            decimal num5;
            this.dt_province = new RecordsProvinceBLL().GetList("").Tables[0];
            this.dt_city = new RecordsCityBLL().GetList("").Tables[0];
            this.dt_district = new RecordsDistrictBLL().GetList("").Tables[0];
            this.dt_town = new RecordsTownBLL().GetList("").Tables[0];
            this.dt_village = new RecordsVillageBLL().GetList("").Tables[0];
            this.bds_arprovince = new BindingSource();
            this.bds_arprovince.DataSource = this.dt_province;
            this.bds_arcity = new BindingSource();
            this.bds_arcity.DataSource = this.dt_city;
            this.bds_ardistrict = new BindingSource();
            this.bds_ardistrict.DataSource = this.dt_district;
            this.bds_artown = new BindingSource();
            this.bds_artown.DataSource = this.dt_town;
            this.bds_arvillage = new BindingSource();
            this.bds_arvillage.DataSource = this.dt_village;
            this.Find_xingzhengquyu();
            decimal.TryParse(this.areaOrg.Province, out num);
            this.BindArea(this.cbxProvince, this.bds_arprovince, num);
            this.bds_arcity.Filter = "ProvinceID = " + num;
            decimal.TryParse(this.areaOrg.City, out num2);
            this.BindArea(this.cbxCity, this.bds_arcity, num2);
            this.bds_ardistrict.Filter = "CityID = " + num2;
            decimal.TryParse(this.areaOrg.District, out num3);
            this.BindArea(this.cbxDistrict, this.bds_ardistrict, num3);
            this.bds_artown.Filter = "DistrictID = " + num3;
            decimal.TryParse(this.areaOrg.Town, out num4);
            this.BindArea(this.cbxTown, this.bds_artown, num4);
            this.bds_arvillage.Filter = "TownID = " + num4;
            decimal.TryParse(this.areaOrg.Village, out num5);
            this.BindArea(this.cbxVillage, this.bds_arvillage, num5);
            this.cbx_SelectedIndexChanged(this.cbxProvince, null);
        }

        private bool GetAreaIDFromCode(string code, DataTable dt, out decimal id)
        {
            id = 0M;
            foreach (DataRow row in dt.Rows)
            {
                if (row["CODE"].ToString() == code)
                {
                    id = decimal.Parse(row["ID"].ToString());
                    return true;
                }
            }
            return false;
        }

        private void GetOrg()
        {
            decimal num;
            decimal num2;
            decimal num3;
            decimal num4;
            decimal num6;

            this.dt_Orgprovince = new SysOrgProvinceBLL().GetList(string.Format(" code = '{0}' ", PadForm.orgid.Substring(0, 2))).Tables[0];
            this.dt_Orgcity = new SysOrgCityBLL().GetList(string.Format(" code = '{0}' ", PadForm.orgid.Substring(0, 4))).Tables[0];
            this.dt_Orgdistrict = new SysOrgDistrictBLL().GetList(string.Format(" code = '{0}' ", PadForm.orgid.Substring(0, 6))).Tables[0];
            this.dt_Orgtown = new SysOrgTownBLL().GetList(string.Format(" code like '{0}%' ", PadForm.orgid.Substring(0, 6))).Tables[0];
            this.dt_Orgvillage = new SysOrgVillangBLL().GetList(string.Format(" code like '{0}%' ", PadForm.orgid.Substring(0, 6))).Tables[0];

            string str = "-1";
            if (this.dt_Orgdistrict.Rows.Count > 0)
            {
                str = this.dt_Orgdistrict.Rows[0]["ID"].ToString();
            }
            this.dt_SysUser = new SysUserBLL().GetList(string.Format(" DistrictID = {0} ", str)).Tables[0];
            DataRow row = this.dt_Orgprovince.NewRow();
            row.ItemArray = new object[] { -1, "-1", "--空--" };
            this.dt_Orgprovince.Rows.InsertAt(row, 0);
            DataRow row2 = this.dt_Orgcity.NewRow();
            row2.ItemArray = new object[] { -1, "-1", "--空--", -1 };
            this.dt_Orgcity.Rows.InsertAt(row2, 0);
            DataRow row3 = this.dt_Orgdistrict.NewRow();
            row3.ItemArray = new object[] { -1, "-1", "--空--", -1 };
            this.dt_Orgdistrict.Rows.InsertAt(row3, 0);
            DataRow row4 = this.dt_Orgtown.NewRow();
            row4.ItemArray = new object[] { -1, "-1", "--空--", -1 };
            this.dt_Orgtown.Rows.InsertAt(row4, 0);
            DataRow row5 = this.dt_Orgvillage.NewRow();
            row5.ItemArray = new object[] { -1, "-1", "--空--", -1 };
            this.dt_Orgvillage.Rows.InsertAt(row5, 0);
            this.bds_Orgprovince = new BindingSource();
            this.bds_Orgprovince.DataSource = this.dt_Orgprovince;
            this.bds_Orgcity = new BindingSource();
            this.bds_Orgcity.DataSource = this.dt_Orgcity;
            this.bds_Orgdistrict = new BindingSource();
            this.bds_Orgdistrict.DataSource = this.dt_Orgdistrict;
            this.bds_Orgtown = new BindingSource();
            this.bds_Orgtown.DataSource = this.dt_Orgtown;
            this.bds_Orgvillage = new BindingSource();
            this.bds_Orgvillage.DataSource = this.dt_Orgvillage;
            this.bds_SysUser = new BindingSource();
            this.bds_SysUser.DataSource = this.dt_SysUser;
            this.FillAreaAndOthers();
            decimal.TryParse(this.areaOrg.ProvinceHB, out num);
            this.BindArea(this.cbxOrgProvince, this.bds_Orgprovince, num);
            //this.cbxOrgProvince.Enabled = false;
            decimal.TryParse(this.areaOrg.CityHB, out num2);
            this.BindArea(this.cbxOrgCity, this.bds_Orgcity, num2);
            //this.cbxOrgCity.Enabled = false;
            decimal.TryParse(this.areaOrg.DistrictHB, out num3);
            this.BindArea(this.cbxOrgDistrict, this.bds_Orgdistrict, num3);
            //this.cbxOrgDistrict.Enabled = false;
            if (!decimal.TryParse(this.areaOrg.TownHB, out num4))
            {
                num4 = -1M;
            }
            this.BindArea(this.cbxOrgTown, this.bds_Orgtown, num4);
            decimal result = -1M;
            if (!decimal.TryParse(this.areaOrg.VillageHB, out result))
            {
                result = -1M;
            }
            this.BindArea(this.cbxOrgVillage, this.bds_Orgvillage, result);
            decimal.TryParse(this.areaOrg.doctor, out num6);
            this.BindArea(this.cbxSysUser, this.bds_SysUser, num6);
            PassWord = (cbxSysUser.SelectedItem as DataRowView).Row["PassWord"].ToString();
            if (!string.IsNullOrEmpty(this.areaOrg.doctor) && (this.cbxSysUser.SelectedValue != null))
            {
                this.tbDoctorID.Text = this.cbxSysUser.SelectedValue.ToString();
            }
            string input= ConfigHelper.GetNode("inputPassWord").ToString();
            if (input.ToLower() == "true")
            {
                tbDoctorID.Location = new System.Drawing.Point(344, 101);
                txtPassWord.Visible = true;
       
            }
            else
            {
                tbDoctorID.Location = new System.Drawing.Point(344, 61);
                txtPassWord.Visible = false;
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationSelectionForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConfigBack = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbDoctorID = new System.Windows.Forms.TextBox();
            this.cbxSysUser = new System.Windows.Forms.ComboBox();
            this.cbxOrgVillage = new System.Windows.Forms.ComboBox();
            this.cbxOrgTown = new System.Windows.Forms.ComboBox();
            this.cbxOrgDistrict = new System.Windows.Forms.ComboBox();
            this.cbxOrgCity = new System.Windows.Forms.ComboBox();
            this.cbxOrgProvince = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mtbHBDep = new System.Windows.Forms.MaskedTextBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.cbxProvince = new System.Windows.Forms.ComboBox();
            this.cbxCity = new System.Windows.Forms.ComboBox();
            this.cbxDistrict = new System.Windows.Forms.ComboBox();
            this.cbxTown = new System.Windows.Forms.ComboBox();
            this.cbxVillage = new System.Windows.Forms.ComboBox();
            this.mtbArchiveID = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Image = global::KangShuo.Properties.Resources.btndenglu;
            this.btnOk.Location = new System.Drawing.Point(223, 342);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(97, 46);
            this.btnOk.TabIndex = 45;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnConfigBack);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.txtPassWord);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbDoctorID);
            this.groupBox2.Controls.Add(this.cbxSysUser);
            this.groupBox2.Controls.Add(this.cbxOrgVillage);
            this.groupBox2.Controls.Add(this.cbxOrgTown);
            this.groupBox2.Controls.Add(this.cbxOrgDistrict);
            this.groupBox2.Controls.Add(this.cbxOrgCity);
            this.groupBox2.Controls.Add(this.cbxOrgProvince);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.mtbHBDep);
            this.groupBox2.Location = new System.Drawing.Point(326, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(527, 256);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "组织机构";
            // 
            // btnConfigBack
            // 
            this.btnConfigBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigBack.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfigBack.Location = new System.Drawing.Point(310, 204);
            this.btnConfigBack.Name = "btnConfigBack";
            this.btnConfigBack.Size = new System.Drawing.Size(104, 46);
            this.btnConfigBack.TabIndex = 113;
            this.btnConfigBack.Text = "配置备份";
            this.btnConfigBack.UseVisualStyleBackColor = true;
            this.btnConfigBack.Click += new System.EventHandler(this.btnConfigBack_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.Location = new System.Drawing.Point(420, 204);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 46);
            this.btnUpdate.TabIndex = 112;
            this.btnUpdate.Text = "程序升级";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(344, 61);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(159, 23);
            this.txtPassWord.TabIndex = 111;
            this.txtPassWord.Text = "123456";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(6, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 109;
            this.label7.Text = "村居：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(6, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 108;
            this.label8.Text = "村镇：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(6, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 107;
            this.label9.Text = "县区：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(6, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 106;
            this.label10.Text = "城市：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(6, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 14);
            this.label11.TabIndex = 105;
            this.label11.Text = "省份：";
            // 
            // tbDoctorID
            // 
            this.tbDoctorID.Location = new System.Drawing.Point(344, 101);
            this.tbDoctorID.Name = "tbDoctorID";
            this.tbDoctorID.ReadOnly = true;
            this.tbDoctorID.Size = new System.Drawing.Size(159, 23);
            this.tbDoctorID.TabIndex = 104;
            // 
            // cbxSysUser
            // 
            this.cbxSysUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSysUser.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxSysUser.FormattingEnabled = true;
            this.cbxSysUser.ItemHeight = 16;
            this.cbxSysUser.Location = new System.Drawing.Point(344, 21);
            this.cbxSysUser.Name = "cbxSysUser";
            this.cbxSysUser.Size = new System.Drawing.Size(159, 24);
            this.cbxSysUser.TabIndex = 103;
            // 
            // cbxOrgVillage
            // 
            this.cbxOrgVillage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrgVillage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxOrgVillage.FormattingEnabled = true;
            this.cbxOrgVillage.ItemHeight = 16;
            this.cbxOrgVillage.Location = new System.Drawing.Point(56, 182);
            this.cbxOrgVillage.Name = "cbxOrgVillage";
            this.cbxOrgVillage.Size = new System.Drawing.Size(220, 24);
            this.cbxOrgVillage.TabIndex = 102;
            // 
            // cbxOrgTown
            // 
            this.cbxOrgTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrgTown.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxOrgTown.FormattingEnabled = true;
            this.cbxOrgTown.ItemHeight = 16;
            this.cbxOrgTown.Location = new System.Drawing.Point(56, 142);
            this.cbxOrgTown.Name = "cbxOrgTown";
            this.cbxOrgTown.Size = new System.Drawing.Size(220, 24);
            this.cbxOrgTown.TabIndex = 101;
            // 
            // cbxOrgDistrict
            // 
            this.cbxOrgDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrgDistrict.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxOrgDistrict.FormattingEnabled = true;
            this.cbxOrgDistrict.ItemHeight = 16;
            this.cbxOrgDistrict.Location = new System.Drawing.Point(56, 101);
            this.cbxOrgDistrict.Name = "cbxOrgDistrict";
            this.cbxOrgDistrict.Size = new System.Drawing.Size(220, 24);
            this.cbxOrgDistrict.TabIndex = 100;
            // 
            // cbxOrgCity
            // 
            this.cbxOrgCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrgCity.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxOrgCity.FormattingEnabled = true;
            this.cbxOrgCity.ItemHeight = 16;
            this.cbxOrgCity.Location = new System.Drawing.Point(56, 61);
            this.cbxOrgCity.Name = "cbxOrgCity";
            this.cbxOrgCity.Size = new System.Drawing.Size(220, 24);
            this.cbxOrgCity.TabIndex = 99;
            // 
            // cbxOrgProvince
            // 
            this.cbxOrgProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrgProvince.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxOrgProvince.FormattingEnabled = true;
            this.cbxOrgProvince.ItemHeight = 16;
            this.cbxOrgProvince.Location = new System.Drawing.Point(56, 21);
            this.cbxOrgProvince.Name = "cbxOrgProvince";
            this.cbxOrgProvince.Size = new System.Drawing.Size(220, 24);
            this.cbxOrgProvince.TabIndex = 98;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(296, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 76;
            this.label5.Text = "医生:";
            // 
            // mtbHBDep
            // 
            this.mtbHBDep.Location = new System.Drawing.Point(56, 222);
            this.mtbHBDep.Mask = "00-00-00-000-000";
            this.mtbHBDep.Name = "mtbHBDep";
            this.mtbHBDep.ReadOnly = true;
            this.mtbHBDep.Size = new System.Drawing.Size(121, 23);
            this.mtbHBDep.TabIndex = 81;
            this.mtbHBDep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Image = global::KangShuo.Properties.Resources.btntuichu;
            this.btnQuit.Location = new System.Drawing.Point(466, 342);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(97, 46);
            this.btnQuit.TabIndex = 82;
            this.btnQuit.UseMnemonic = false;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // cbxProvince
            // 
            this.cbxProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProvince.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxProvince.FormattingEnabled = true;
            this.cbxProvince.ItemHeight = 16;
            this.cbxProvince.Location = new System.Drawing.Point(56, 22);
            this.cbxProvince.Name = "cbxProvince";
            this.cbxProvince.Size = new System.Drawing.Size(220, 24);
            this.cbxProvince.TabIndex = 93;
            // 
            // cbxCity
            // 
            this.cbxCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCity.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxCity.FormattingEnabled = true;
            this.cbxCity.ItemHeight = 16;
            this.cbxCity.Location = new System.Drawing.Point(56, 62);
            this.cbxCity.Name = "cbxCity";
            this.cbxCity.Size = new System.Drawing.Size(220, 24);
            this.cbxCity.TabIndex = 94;
            // 
            // cbxDistrict
            // 
            this.cbxDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDistrict.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxDistrict.FormattingEnabled = true;
            this.cbxDistrict.ItemHeight = 16;
            this.cbxDistrict.Location = new System.Drawing.Point(56, 102);
            this.cbxDistrict.Name = "cbxDistrict";
            this.cbxDistrict.Size = new System.Drawing.Size(220, 24);
            this.cbxDistrict.TabIndex = 95;
            // 
            // cbxTown
            // 
            this.cbxTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTown.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxTown.FormattingEnabled = true;
            this.cbxTown.ItemHeight = 16;
            this.cbxTown.Location = new System.Drawing.Point(56, 143);
            this.cbxTown.Name = "cbxTown";
            this.cbxTown.Size = new System.Drawing.Size(220, 24);
            this.cbxTown.TabIndex = 96;
            // 
            // cbxVillage
            // 
            this.cbxVillage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVillage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxVillage.FormattingEnabled = true;
            this.cbxVillage.ItemHeight = 16;
            this.cbxVillage.Location = new System.Drawing.Point(56, 183);
            this.cbxVillage.Name = "cbxVillage";
            this.cbxVillage.Size = new System.Drawing.Size(220, 24);
            this.cbxVillage.TabIndex = 97;
            // 
            // mtbArchiveID
            // 
            this.mtbArchiveID.Location = new System.Drawing.Point(58, 223);
            this.mtbArchiveID.Mask = "00-00-00-000-000";
            this.mtbArchiveID.Name = "mtbArchiveID";
            this.mtbArchiveID.ReadOnly = true;
            this.mtbArchiveID.Size = new System.Drawing.Size(123, 23);
            this.mtbArchiveID.TabIndex = 98;
            this.mtbArchiveID.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.mtbArchiveID);
            this.groupBox1.Controls.Add(this.cbxVillage);
            this.groupBox1.Controls.Add(this.cbxTown);
            this.groupBox1.Controls.Add(this.cbxDistrict);
            this.groupBox1.Controls.Add(this.cbxCity);
            this.groupBox1.Controls.Add(this.cbxProvince);
            this.groupBox1.Location = new System.Drawing.Point(13, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 257);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "行政区";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(6, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 103;
            this.label6.Text = "村居：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 102;
            this.label4.Text = "村镇：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 101;
            this.label3.Text = "县区：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 100;
            this.label2.Text = "城市：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 99;
            this.label1.Text = "省份：";
            // 
            // LocationSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::KangShuo.Properties.Resources.logindialogbg;
            this.ClientSize = new System.Drawing.Size(870, 422);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnQuit);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocationSelectionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHAArea_FormClosing);
            this.Load += new System.EventHandler(this.LocationSelectionForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        public AreaOrg areaOrg { get; set; }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "\\UpdateVersion.exe");
            Process newProcess = Process.Start(startInfo);

            Application.Exit();
            Environment.Exit(0);
        }

        private void btnConfigBack_Click(object sender, EventArgs e)
        {
            // 复制安装目录文件夹
            string path = Application.StartupPath;
            string copyPath = "D:\\QCSoft\\配置文件备份";
            bool result = false;

            if (System.IO.Directory.Exists(copyPath) && Directory.GetFileSystemEntries(copyPath).Length > 0)
            {
                if ((MessageBox.Show("已备份过文件。是否重新备份？", "备份",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                {
                    CopyDir(path, copyPath);
                    result = true;
                }
            }
            else
            {
                CopyDir(path, copyPath);
                result = true;
            }

            if (result) MessageBox.Show("备份完成！目录：" + copyPath);
        }

        /// <summary>
        /// 复制安装目录文件夹
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="aimPath"></param>
        public void CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // 如果不存在目标路径，则创建之
                if (!System.IO.Directory.Exists(aimPath))
                {
                    System.IO.Directory.CreateDirectory(aimPath);
                }

                // 令目标路径为aimPath\srcPath
                string srcdir = aimPath;

                // 如果源路径是文件夹，则令目标目录为aimPath\srcPath\
                if (Directory.Exists(srcPath))
                    srcdir += Path.DirectorySeparatorChar;

                // 如果目标路径不存在,则创建目标路径
                if (!System.IO.Directory.Exists(srcdir))
                {
                    System.IO.Directory.CreateDirectory(srcdir);
                }

                // 获取源文件下所有的文件
                string[] files = Directory.GetFileSystemEntries(srcPath);

                foreach (string element in files)
                {
                    // 如果是文件夹，循环
                    if (Directory.Exists(element))
                        CopyDir(element, aimPath + "\\" + Path.GetFileName(element));
                    else if (element.Contains(".xml") || element.Contains(".config"))
                    {
                        File.Copy(element, srcdir + Path.GetFileName(element), true);
                    }
                }
            }
            catch
            {
                MessageBox.Show("无法复制");
            }
        }
    }
}