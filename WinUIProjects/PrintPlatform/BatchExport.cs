using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;
using System.IO;
using System.Threading;
using System.ComponentModel;
using KangShuoTech.Utilities.Common;

namespace PrintPlatform
{
    public partial class BatchExport : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        public BatchExport()
        {
            InitializeComponent();
            this.EveryThingIsOk = false;
            this.HaveToSave = false;
        }

        private DataTable dt_user;
        public Process BatchProcess;
        private List<CheckBox> ChekType;

        public string IDCardNo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        public void InitEveryThing()
        {
            ChekType = new List<CheckBox> { this.cktype1, this.cktype2, this.cktype3, this.cktype4, this.cktype5, this.cktype6, this.cktype8,
                this.cktype9, this.cktype10,this.cktype11, this.cktype12, this.cktype13, this.cktype14, this.cktype15, this.cktype16, this.cktype17,
                this.cktype18, this.cktype19,this.cktype21, this.cktype22, this.cktype24, this.cktype25, this.cktype26, this.cktype27, this.cktype28,
                this.cktype30,this.cktype31, this.cktype32, this.cktype33, this.cktype34, this.cktype37, this.cbOldFeed, this.cbECG, this.cbTypeB, this.cbPhyicalReport
            };

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
            DataTable dt_Town = new RecordsCustomerBaseInfoBLL().GetTownList().Tables[0];
            if (dt_Town.Rows.Count > 0)
            {
                DataRow row = dt_Town.NewRow();
                row.ItemArray = new object[] { "不限" };
                dt_Town.Rows.InsertAt(row, 0);
                this.cbxTown.DisplayMember = "TownName";
                this.cbxTown.DataSource = dt_Town;
            }

            this.EveryThingIsOk = true;
        }

        public bool SaveModelToDB()
        {
            return true;
        }

        public void NotisfyChildStatus() { }

        public void UpdataToModel() { }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        private void BatchExport_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string idCardNo = "汇出";
            string PrintName = "";
            string args = "";

            if (this.ckCheckDate.Checked && (this.dtpSt.Value.Date > this.dtpEd.Value.Date))
            {
                MessageBox.Show(" 体检日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.ckxCreatedDate.Checked && (this.dtpCreatedDateSt.Value.Date > this.dtpCreatedDateEd.Value.Date))
            {
                MessageBox.Show(" 建档日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if ((this.dtpEd.Value.Subtract(this.dtpSt.Value).Days + 1) > 31)
            {
                MessageBox.Show(" 体检日期区间不可大于31天!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if ((this.dtpCreatedDateEd.Value.Subtract(this.dtpCreatedDateSt.Value).Days + 1) > 31)
            {
                MessageBox.Show(" 建档日期间不可大于31天!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                    foreach (CheckBox cb in ChekType)
                    {
                        if (cb.Checked)
                        {
                            PrintName += cb.Text.ToString() + ";";
                        }
                    }

                    if (PrintName.Length > 0)
                    {
                        if (!string.IsNullOrEmpty(PrintName))
                        {
                            PrintName = PrintName.Substring(0, PrintName.Length - 1);
                        }

                        args = idCardNo + "&" + PrintName + "&" + where;

                        BatchProcess = new Process { StartInfo = { FileName = @"NewPrint.exe", Arguments = args } };
                        BatchProcess.Start();
                    }
                    else
                    {
                        MessageBox.Show("请选择要汇出的档案资料！");
                    }
                }
            }
        }

        private string GetWhere()
        {
            string input = this.txtIdNum.Text.Trim();
            string str2 = "";
            if (input != "")
            {
                str2 = !Regex.IsMatch(input, @"^\d{15}") ? string.Format("#AND#T.CustomerName#LIKE#'%{0}%'", input) : ("#AND#T.IDCardNo#LIKE#'%" + input + "%'");
            }
            if (!string.IsNullOrEmpty(this.tbAddr.Text.Trim()))
            {
                str2 = str2 + string.Format("#AND#T.HouseHoldAddress#LIKE#'%{0}%'", this.tbAddr.Text.Trim());
            }
            if (this.ckCheckDate.Checked)
            {
                str2 = str2 + string.Format("#AND#B.CheckDate#BETWEEN#'{0}'#AND#'{1}'", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.ckxCreatedDate.Checked)
            {
                str2 = str2 + string.Format("#AND#T.CreateDate#BETWEEN#'{0}'#AND#'{1}'", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
            }

            if (this.cbxUser.Text != "不限")
            {
                str2 = str2 + string.Format("#AND#T.CreateMenName='{0}'", this.cbxUser.Text.ToString());
            }
            if (this.cbxTown.Text != "不限")
            {
                str2 = str2 + string.Format("#AND#T.TownName#LIKE#'%{0}%'", this.cbxTown.Text.ToString());
            }
            if (this.cbxVillage.Text != "不限" && this.cbxVillage.Text != "")
            {
                str2 = str2 + string.Format("#AND#T.VillageName#LIKE#'%{0}%'", this.cbxVillage.Text.ToString());
            }
            return str2;
        }

        private void ckCheckDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpSt.Enabled = this.ckCheckDate.Checked;
            this.dtpEd.Enabled = this.ckCheckDate.Checked;

            if (this.ckCheckDate.Checked)
            {
                this.dtpSt.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01"));
                this.dtpEd.Value = Convert.ToDateTime(this.dtpSt.Value.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"));
            }
        }

        private void ckxCreatedDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpCreatedDateSt.Enabled = this.ckxCreatedDate.Checked;
            this.dtpCreatedDateEd.Enabled = this.ckxCreatedDate.Checked;

            if (this.ckxCreatedDate.Checked)
            {
                this.dtpCreatedDateSt.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01"));
                this.dtpCreatedDateEd.Value = Convert.ToDateTime(this.dtpSt.Value.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"));
            }
        }

        private void cbxTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbxTown.Text))
            {
                string strwhere = string.Format("AND TownName LIKE '%{0}%'", cbxTown.Text);
                DataTable dt_Village = new RecordsCustomerBaseInfoBLL().GetVillageList(strwhere).Tables[0];
                if (dt_Village.Rows.Count > 0)
                {
                    DataRow row = dt_Village.NewRow();
                    row.ItemArray = new object[] { "不限" };
                    dt_Village.Rows.InsertAt(row, 0);
                    this.cbxVillage.DisplayMember = "VillageName";
                    this.cbxVillage.DataSource = dt_Village;
                }
                else
                {
                    this.cbxVillage.DataSource = null;
                }
            }
        }
    }
}
