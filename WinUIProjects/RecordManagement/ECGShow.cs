using System;
using System.Data;
using System.Windows.Forms;
using KangShuoTech.Utilities.MySQLHelper;
using System.Configuration;

namespace RecordManagement
{
    public partial class ECGShow : Form
    {
        string ECGReport = ConfigurationManager.AppSettings["ECGReport"] == null ? @"D:\QCSoft\ECGPDF\outFile" : ConfigurationManager.AppSettings["ECGReport"].ToString();

        public ECGShow()
        {
            InitializeComponent();
        }

        //展示心电图
        public AidExamUserControl aid=new AidExamUserControl();
        private void ECGShow_Load(object sender, EventArgs e)
        {

            string id = this.IDCardNo;
            string strtest = "select max(MID),IDCardNo,Name,Conclusion,CreateTime FROM tbl_recordsecg WHERE IDCardNo='" + id + "' GROUP BY IDCardNo ";
            DataSet testSet = MySQLHelper.Query(strtest);
            DataTable dtTable = testSet.Tables[0];
            if (dtTable.Rows.Count>0)
            {
                ////插入结论
                //string conclusion = "update tbl_recordsassistcheck set ECG='2', ECGEx='" + dtTable.Rows[0][3] + "'where IDCardNo=" + dtTable.Rows[0][1];
                //DataSet updataECG = MySQLHelper.Query(conclusion);

                string fileName1 = ECGReport + "\\" + dtTable.Rows[0][0] + ".pdf ";

                axAcroPDF1.LoadFile(fileName1);
            }
            else
            {
                MessageBox.Show("此用户没有心电图！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }            
        }

        public string IDCardNo { get; set; }
    }
}
