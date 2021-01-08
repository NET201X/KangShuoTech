using KangShuoTech.Utilities.Common;

namespace FocusGroup.ChronicDisease
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

    public partial class HyperRequiredForm : Form
    {
        private DataSet ds_whatsup;
        private string input = "";

        public HyperRequiredForm()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;

        }
        private void HyperRequiredForm_Load(object sender, EventArgs e)
        {
            this.ds_whatsup = new DataSet();
            //this.ds_whatsup.ReadXml(Application.StartupPath + @"\requiredHyper.xml");
            //this.dataGridView1.DataSource = this.ds_whatsup.Tables[0];
            this.ds_whatsup = new RequireBLL().GetList("TabName = '高血压随访' ");
            this.dataGridView1.DataSource = TransDs(this.ds_whatsup);
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    this.ds_whatsup.WriteXml(Application.StartupPath + @"\requiredHyper.xml");
        //    string mustchoosenode = ConfigHelper.GetMustChooseNode("HyperRequiredchoose");
        //    if (string.IsNullOrEmpty(mustchoosenode))
        //    {
        //        mustchoosenode = "0000000000000000000000";
        //        ConfigHelper.WriteNode("HyperRequiredchoose", "0000000000000000000000");
        //    }
        //    char[] chrArray = mustchoosenode.ToCharArray();
        //    DataTable dt = ds_whatsup.Tables[0];
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "基本信息，家族史")
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
        //        if (item["COMMENT"].ToString() == "基本信息，目前症状")
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
        //        if (item["COMMENT"].ToString() == "基本信息，是否使用降压药")
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
        //        if (item["COMMENT"].ToString() == "随访信息，症状")
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
        //        if (item["COMMENT"].ToString() == "随访信息，血压")
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
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，心率")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[5] = '1';
        //            }
        //            else
        //            {
        //                chrArray[5] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，体质指数")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[6] = '1';
        //            }
        //            else
        //            {
        //                chrArray[6] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，体质指数下次随访目标")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[7] = '1';
        //            }
        //            else
        //            {
        //                chrArray[7] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {

        //        if (item["COMMENT"].ToString() == "随访信息，体重")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[8] = '1';
        //            }
        //            else
        //            {
        //                chrArray[8] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {

        //        if (item["COMMENT"].ToString() == "随访信息，体重下次随访目标")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[10] = '1';
        //            }
        //            else
        //            {
        //                chrArray[10] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，日吸烟量")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[9] = '1';
        //            }
        //            else
        //            {
        //                chrArray[9] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，日吸烟量下次随访目标")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[11] = '1';
        //            }
        //            else
        //            {
        //                chrArray[11] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，日饮酒量")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[12] = '1';
        //            }
        //            else
        //            {
        //                chrArray[12] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，饮酒量下次随访目标")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[13] = '1';
        //            }
        //            else
        //            {
        //                chrArray[13] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，运动")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[14] = '1';
        //            }
        //            else
        //            {
        //                chrArray[14] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，运动下次随访目标")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[15] = '1';
        //            }
        //            else
        //            {
        //                chrArray[15] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，摄盐情况")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[16] = '1';
        //            }
        //            else
        //            {
        //                chrArray[16] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，摄盐情况下次随访目标")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[17] = '1';
        //            }
        //            else
        //            {
        //                chrArray[17] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，心里调整")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[18] = '1';
        //            }
        //            else
        //            {
        //                chrArray[18] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，服药依从性")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[19] = '1';
        //            }
        //            else
        //            {
        //                chrArray[19] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，药物不良反应")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[20] = '1';
        //            }
        //            else
        //            {
        //                chrArray[20] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，用药情况")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[21] = '1';
        //            }
        //            else
        //            {
        //                chrArray[21] = '0';
        //            }
        //            break;
        //        }
        //    }
          
        //    string str = new string(chrArray);
        //    ConfigHelper.WriteMustChooseNode("HyperRequiredchoose", str);
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
