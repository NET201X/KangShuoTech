using KangShuoTech.Utilities.Common;
namespace ArchiveInfo
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

    public partial class PersonFileRequiredForm : Form
    {
        private DataSet ds_whatsup;
        private string input = "";

        public PersonFileRequiredForm()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void PersonFileRequiredForm_Load(object sender, EventArgs e)
        {
            this.ds_whatsup = new DataSet();
            //this.ds_whatsup.ReadXml(Application.StartupPath + @"\requiredPersonFile.xml");
            //this.dataGridView1.DataSource = this.ds_whatsup.Tables[0];
            this.ds_whatsup = new RequireBLL().GetList("TabName = '个人档案' ");
            this.dataGridView1.DataSource = TransDs(this.ds_whatsup);
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    this.ds_whatsup.WriteXml(Application.StartupPath + @"\requiredPersonFile.xml");
        //    string mustchoosenode = ConfigHelper.GetMustChooseNode("PersonFilechoose");
        //    if (string.IsNullOrEmpty(mustchoosenode))
        //    {
        //        mustchoosenode = "000000000000000";
        //        ConfigHelper.WriteNode("PersonFilechoose", "000000000000000");
        //    }
        //    char[] chrArray = mustchoosenode.ToCharArray();
        //    DataTable dt = ds_whatsup.Tables[0];
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (item["COMMENT"].ToString() == "封面信息，现住址")
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
        //        if (item["COMMENT"].ToString() == "封面信息，联系电话")
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
        //        if (item["COMMENT"].ToString() == "详细信息，联系人姓名")
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
        //        if (item["COMMENT"].ToString() == "详细信息，联系人电话")
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
        //        if (item["COMMENT"].ToString() == "详细信息，遗传病史")
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
        //        if (item["COMMENT"].ToString() == "详细信息，支付方式")
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
        //        if (item["COMMENT"].ToString() == "详细信息，药物过敏史")
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
        //        if (item["COMMENT"].ToString() == "详细信息，暴露史")
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
        //        if (item["COMMENT"].ToString() == "详细信息，残疾情况")
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
        //        if (item["COMMENT"].ToString() == "健康信息，疾病")
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
        //        if (item["COMMENT"].ToString() == "健康信息，厨房排风设施")
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
        //        if (item["COMMENT"].ToString() == "健康信息，燃料类型")
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
        //        if (item["COMMENT"].ToString() == "健康信息，饮水")
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
        //        if (item["COMMENT"].ToString() == "健康信息，厕所")
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
        //        if (item["COMMENT"].ToString() == "健康信息，禽兽类")
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

        //    string str = new string(chrArray);
        //    ConfigHelper.WriteMustChooseNode("PersonFilechoose", str);
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
