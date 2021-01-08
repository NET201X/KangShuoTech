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
    
    public partial class DiaRequiredForm : Form
    {
        private DataSet ds_whatsup;
        private string input = "";

        public DiaRequiredForm()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void DiaRequiredForm_Load(object sender, EventArgs e)
        {
            this.ds_whatsup = new DataSet();
            //this.ds_whatsup.ReadXml(Application.StartupPath + @"\requiredDia.xml");
            //this.dataGridView1.DataSource = this.ds_whatsup.Tables[0];
            this.ds_whatsup = new RequireBLL().GetList("TabName = '糖尿病随访' ");
            this.dataGridView1.DataSource = TransDs(this.ds_whatsup);
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    this.ds_whatsup.WriteXml(Application.StartupPath + @"\requiredDia.xml");
        //    string mustchoosenode = ConfigHelper.GetMustChooseNode("DiaRequiredchoose");
        //    if (string.IsNullOrEmpty(mustchoosenode))
        //    {
        //        mustchoosenode = "00000000000000000000000000000000000";
        //        ConfigHelper.WriteNode("DiaRequiredchoose", "00000000000000000000000000000000000");
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
        //        if (item["COMMENT"].ToString() == "基本信息，糖尿病类型")
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
        //        if (item["COMMENT"].ToString() == "基本信息，确诊时间")
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
        //        if (item["COMMENT"].ToString() == "基本信息，确诊单位")
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
        //        if (item["COMMENT"].ToString() == "基本信息，是否使用胰岛素")
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
        //        if (item["COMMENT"].ToString() == "基本信息，胰岛素用量")
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
        //        if (item["COMMENT"].ToString() == "基本信息，是否使用口服降糖药")
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
        //        if (item["COMMENT"].ToString() == "基本信息，目前症状")
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

        //        if (item["COMMENT"].ToString() == "随访信息，症状")
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

        //        if (item["COMMENT"].ToString() == "随访信息，血压")
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
        //        if (item["COMMENT"].ToString() == "随访信息，体质指数")
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
        //        if (item["COMMENT"].ToString() == "随访信息，体质指数下次随访目标")
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
        //        if (item["COMMENT"].ToString() == "随访信息，足背动脉搏动")
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
        //        if (item["COMMENT"].ToString() == "随访信息，体重")
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
        //        if (item["COMMENT"].ToString() == "随访信息，体重下次随访目标")
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
        //        if (item["COMMENT"].ToString() == "随访信息，日吸烟量")
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
        //        if (item["COMMENT"].ToString() == "随访信息，日吸烟量下次随访目标")
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
        //        if (item["COMMENT"].ToString() == "随访信息，日饮酒量")
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
        //        if (item["COMMENT"].ToString() == "随访信息，日饮酒量下次随访目标")
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
        //        if (item["COMMENT"].ToString() == "随访信息，运动")
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
        //        if (item["COMMENT"].ToString() == "随访信息，运动下次随访目标")
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
        //        if (item["COMMENT"].ToString() == "随访信息，主食")
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
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，主食下次随访目标")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[22] = '1';
        //            }
        //            else
        //            {
        //                chrArray[22] = '0';
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
        //                chrArray[23] = '1';
        //            }
        //            else
        //            {
        //                chrArray[23] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，遵医行为")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[24] = '1';
        //            }
        //            else
        //            {
        //                chrArray[24] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，空腹血糖值")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[25] = '1';
        //            }
        //            else
        //            {
        //                chrArray[25] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，糖化血红蛋白")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[26] = '1';
        //            }
        //            else
        //            {
        //                chrArray[26] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，检查日期")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[27] = '1';
        //            }
        //            else
        //            {
        //                chrArray[27] = '0';
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
        //                chrArray[28] = '1';
        //            }
        //            else
        //            {
        //                chrArray[28] = '0';
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
        //                chrArray[29] = '1';
        //            }
        //            else
        //            {
        //                chrArray[29] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，低血糖反应")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[30] = '1';
        //            }
        //            else
        //            {
        //                chrArray[30] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，随访分类")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[31] = '1';
        //            }
        //            else
        //            {
        //                chrArray[31] = '0';
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
        //                chrArray[32] = '1';
        //            }
        //            else
        //            {
        //                chrArray[32] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，胰岛素种类")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[33] = '1';
        //            }
        //            else
        //            {
        //                chrArray[33] = '0';
        //            }
        //            break;
        //        }
        //    }
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "随访信息，用法与用量")
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1")
        //            {
        //                chrArray[34] = '1';
        //            }
        //            else
        //            {
        //                chrArray[34] = '0';
        //            }
        //            break;
        //        }
        //    }
           
        //    string str = new string(chrArray);
        //    ConfigHelper.WriteMustChooseNode("DiaRequiredchoose", str);
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
