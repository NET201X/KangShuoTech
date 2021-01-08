using FocusGroup.OldPeople;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonUI;

namespace OverView
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

    public partial class frmVisitPercent : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private DataTable dt_user;

        public frmVisitPercent()
        {
            InitializeComponent();
            this.dgvData.AutoGenerateColumns = false;
            this.EveryThingIsOk = false;
            this.HaveToSave = false;
            
        }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        public void InitEveryThing()
        {
            this.dt_user = new RecordsBaseInfoBLL().GetUserDt("").Tables[0];

            DataRow row = this.dt_user.NewRow();
            row.ItemArray = new object[] { "", -1, "" };

            this.dt_user.Rows.InsertAt(row, 0);

            if (this.dt_user.Rows.Count > 0)
            {
                this.cbxUser.ValueMember = "ID";
                this.cbxUser.DisplayMember = "CreateMenName";
                this.cbxUser.DataSource = this.dt_user;
            }
            //DataSet ds = new RecordsBaseInfoBLL().GetVisitPercentDt(GetWhere());
            //this.dgvData.DataSource = ds.Tables[0];

            this.EveryThingIsOk = true;
        }

        private void TransDs(DataSet ds)
        {
            ds.Tables[0].Columns.Add("OldPersent");
            ds.Tables[0].Columns.Add("HyperPersent");
            ds.Tables[0].Columns.Add("DiaPersent");
            ds.Tables[0].Columns.Add("MentalPersent");
            ds.Tables[0].Columns.Add("LungerPersent");
            ds.Tables[0].Columns.Add("StrokePersent");
            ds.Tables[0].Columns.Add("ChdPersent");
            DataRow row = ds.Tables[0].Rows[0];
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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.btnQuery.Text == "重置条件")
            {
                this.groupBox1.Enabled = true;
                this.btnQuery.Text = "查询";
            }
            else
            {
                string where = this.GetWhere();
                this.btnQuery.Enabled = false;
                DataSet ds = new RecordsBaseInfoBLL().GetVisitPercentDt(where);
                this.dgvData.DataSource = ds.Tables[0];
                this.btnQuery.Enabled = true;
            }
        }

        private string GetWhere()
        {
            string str2 = "";

            if (!string.IsNullOrEmpty(this.cbxUser.Text.ToString()))
            {
                str2 = string.Format(" and CreateMenName = '{0}' ", this.cbxUser.Text); ;
            }

            return str2;
        }

        private void frmVisitPercent_Load(object sender, EventArgs e)
        {
            InitEveryThing();
        }
    }
}
