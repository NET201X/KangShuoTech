using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.Utilities.MySQLHelper;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;


namespace HealthHouse
{
    public partial class ECGShow : Form
    {
        public ECGShow()
        {
            InitializeComponent();
        }
        //展示心电图
        public PhysicalAssistCheck aid = new PhysicalAssistCheck();
        private void ECGShow_Load(object sender, EventArgs e)
        {

            string id = this.IDCardNo;
            string strtest = "select max(MID),IDCardNo,Name,Conclusion,CreateTime FROM ARCHIVE_ECG WHERE IDCardNo='" + id + "' GROUP BY IDCardNo ";
            DataSet testSet = MySQLHelper.Query(strtest);
            DataTable dtTable = testSet.Tables[0];
            if (dtTable.Rows.Count>0)
            {
                ////插入结论
                //string conclusion = "update ARCHIVE_ASSISTCHECK set ECG='2', ECGEx='" + dtTable.Rows[0][3] + "'where IDCardNo=" + dtTable.Rows[0][1];
                //DataSet updataECG = MySQLHelper.Query(conclusion);

                string fileName1 = "D:\\QCSoft\\ECGPDF\\outFile\\" + dtTable.Rows[0][0] + ".pdf ";
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
