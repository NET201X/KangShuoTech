using KangShuoTech.Utilities.Common;

namespace FocusGroup.OldPeople
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using KangShuoTech.DataAccessProjects.BLL;

    public partial class OldPeopleRequiredForm : Form
    {
        private DataSet ds_whatsup;
        private string input = "";

        public OldPeopleRequiredForm()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void OldPeopleRequiredForm_Load(object sender, EventArgs e)
        {
            this.ds_whatsup = new DataSet();
            //this.ds_whatsup.ReadXml(Application.StartupPath + @"\requiredOldPeople.xml");
            //this.dataGridView1.DataSource = this.ds_whatsup.Tables[0];
            this.ds_whatsup = new RequireBLL().GetList("TabName = '老年人随访' ");
            this.dataGridView1.DataSource = TransDs(this.ds_whatsup);
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    this.ds_whatsup.WriteXml(Application.StartupPath + @"\requiredOldPeople.xml");
        //    string mustchoosenode = ConfigHelper.GetMustChooseNode("OldPeopleRequiredchoose");
        //    if (string.IsNullOrEmpty(mustchoosenode))
        //    {
        //        mustchoosenode = "00000";
        //        ConfigHelper.WriteNode("OldPeopleRequiredchoose", "00000");
        //    }
        //    char[] chrArray = mustchoosenode.ToCharArray();
        //    DataTable dt = ds_whatsup.Tables[0];
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "健康评估，进餐")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[0] = '1';
        //            }
        //            else
        //            {
        //                chrArray[0] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "健康评估，梳洗")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[1] = '1';
        //            }
        //            else
        //            {
        //                chrArray[1] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "健康评估，穿衣")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[2] = '1';
        //            }
        //            else
        //            {
        //                chrArray[2] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "健康评估，如厕")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[3] = '1';
        //            }
        //            else
        //            {
        //                chrArray[3] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "健康评估，活动")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[4] = '1';
        //            }
        //            else
        //            {
        //                chrArray[4] = '0';
        //            }
        //            break;
        //        }
        //    }
          
        //    string str = new string(chrArray);
        //    ConfigHelper.WriteMustChooseNode("OldPeopleRequiredchoose", str);
        //    base.DialogResult = DialogResult.OK;
        //}
        private void btnSave_Click(object sender, EventArgs e)
        {
            int k = 0;
            foreach (DataRow item in ds_whatsup.Tables[0].Rows)
            {
                string str = this.dataGridView1.Rows[k].Cells[2].Value.ToString();
                if (item["Isrequired"].ToString() != str)
                {
                    int id = int.Parse(item["ID"].ToString());
                    new RequireBLL().UpdateID(id, str);
                }
                k++;
            }
            base.DialogResult = DialogResult.OK;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }
        private DataTable TransDs(DataSet ds)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID");
            dt.Columns.Add("COMMENT");
            dt.Columns.Add("ISREQUIRED");
            int id = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id++;
                DataRow dr = dt.NewRow();
                dr["ID"] = Convert.ToString(id);
                dr["COMMENT"] = row["Comment"].ToString() + ":" + row["ChinName"].ToString();
                dr["ISREQUIRED"] = row["Isrequired"];
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
