using System;
using System.Windows.Forms;
using System.Configuration;

namespace PrintPlatform
{
    public partial class ECGShow : Form
    {
        string ECGReport = ConfigurationManager.AppSettings["ECGReport"] == null ? @"D:\QCSoft\ECGPDF\outFile" : ConfigurationManager.AppSettings["ECGReport"].ToString();

        public ECGShow()
        {
            InitializeComponent();
        }

        private void axAcroPDF1_OnError(object sender, EventArgs e)
        {

        }
        //public AidExamUserControl aid = new AidExamUserControl();
        private void ECGShow_Load(object sender, EventArgs e)
        {
            try 
            {
                string fileName1 = ECGReport + "\\" + this.MID + ".pdf ";

                axAcroPDF1.LoadFile(fileName1);
            }
            catch (Exception ex )
            { 
              throw ex;
            }           
        }

        public string MID { get; set; }
    }
}
