
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;

namespace RecordManagement
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

    public partial class RequiredForm : Form
    {
        private DataSet ds_whatsup;
        private string input = "";

        public RequiredForm()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void RequiredForm_Load(object sender, EventArgs e)
        {
            this.ds_whatsup = new DataSet();
            //this.ds_whatsup.ReadXml(Application.StartupPath + @"\required.xml");
            this.ds_whatsup = new RequireBLL().GetList("TabName = '健康体检' ");
            //this.dataGridView1.DataSource = this.ds_whatsup.Tables[0];
            this.dataGridView1.DataSource = TransDs(this.ds_whatsup);
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    //this.ds_whatsup.WriteXml(Application.StartupPath + @"\required.xml");
        //    //string mustchoosenode = ConfigHelper.GetMustChooseNode("mustchoose");
        //    //if (string.IsNullOrEmpty(mustchoosenode))
        //    //{
        //    //    mustchoosenode = "0000000000000000000000000000000000000000000000000";
        //    //    ConfigHelper.WriteNode("mustchoose", "0000000000000000000000000000000000000000000000000");
        //    //}
        //    //char[] chrArray = mustchoosenode.ToCharArray();
        //    //DataTable dt = ds_whatsup.Tables[0];
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "一般状况，体温")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[1] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[1] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "一般状况，症状")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[0] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[0] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "一般状况，呼吸频率")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[2] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[2] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "一般状况，腰围")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[3] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[3] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "一般状况，身高")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[4] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[4] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "一般状况，脉率")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[5] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[5] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "一般状况，体重")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[6] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[6] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "一般状况，体质指数")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[7] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[7] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{

        //    //    if (item["COMMENT"].ToString() == "一般状况，左侧低血压")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[8] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[8] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{

        //    //    if (item["COMMENT"].ToString() == "一般状况，左侧高血压")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[10] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[10] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "一般状况，右侧低血压")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[9] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[9] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "一般状况，右侧高血压")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[11] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[11] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "生活方式，饮食习惯")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[12] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[12] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "生活方式，职业病危害因素接触史")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[13] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[13] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，皮肤")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[14] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[14] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，巩膜")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[15] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[15] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，淋巴结")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[16] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[16] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，桶状胸")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[17] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[17] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，呼吸音")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[18] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[18] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，罗音")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[19] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[19] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，心率")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[20] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[20] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，心律")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[21] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[21] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，杂音")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[22] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[22] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，包块")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[23] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[23] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，下肢水肿")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[24] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[24] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，足背动脉搏动")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[25] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[25] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，肛门指诊")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[26] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[26] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，乳腺")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[27] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[27] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，压痛")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[28] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[28] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，肝大")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[29] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[29] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，脾大")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[30] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[30] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，移动性浊音")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[31] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[31] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "查体信息，眼底")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[32] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[32] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "辅助检查，空腹血糖DL")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[33] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[33] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "脏器功能，口唇")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[34] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[34] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "脏器功能，齿列")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[35] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[35] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "脏器功能，咽部")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[36] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[36] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "脏器功能，听力")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[37] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[37] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "脏器功能，运动功能")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[38] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[38] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "健康问题，脑血管疾病")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[39] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[39] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "健康问题，肾脏疾病")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[40] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[40] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "健康问题，心脏疾病")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[41] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[41] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "健康问题，血管疾病")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[42] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[42] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "健康问题，眼部疾病")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[43] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[43] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "健康问题，神经系统疾病")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[44] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[44] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "健康问题，其他系统疾病")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[45] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[45] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "健康评价，是否正常1:体检无异常2:有异常")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[46] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[46] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "健康评价，健康指导")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[47] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[47] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    if (item["COMMENT"].ToString() == "健康评价，危险因素控制(以英文逗号分隔)")
        //    //    {
        //    //        if (item["ISREQUIRED"].ToString() == "1")
        //    //        {
        //    //            chrArray[48] = '1';
        //    //        }
        //    //        else
        //    //        {
        //    //            chrArray[48] = '0';
        //    //        }
        //    //        break;
        //    //    }
        //    //}
        //    //string str = new string(chrArray);
        //    //ConfigHelper.WriteMustChooseNode("mustchoose", str);
        //    //base.DialogResult = DialogResult.OK;
           
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
                  new RequireBLL().UpdateID(id,str);
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
                dr["ID"] = Convert.ToString (id);
                dr["COMMENT"] = row["Comment"].ToString() + ":" + row["ChinName"].ToString();
                dr["ISREQUIRED"] = row["Isrequired"];
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public RequireModel requiremodel { get; set; }
    }
}
