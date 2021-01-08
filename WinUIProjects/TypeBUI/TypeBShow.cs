using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TypeBUI
{
    public partial class TypeBShow : Form
    {
        string BChaoReport = ConfigurationManager.AppSettings["BChaoReport"] == null ? @"D:\QCSoft\TypeB" : ConfigurationManager.AppSettings["BChaoReport"].ToString();

        public TypeBShow()
        {
            InitializeComponent();
        }

        public TypeBShow(string strPath, string IDCardNo)
        {
            InitializeComponent();

            FilePath = strPath;
            this.CardNoID = IDCardNo;
        }

        public string FilePath { get; set; }
        public string CardNoID { get; set; }
        private void TypeBShow_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FilePath) && File.Exists(FilePath))
            {
                pboxBShow.Image = Image.FromFile(FilePath);
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(BChaoReport + @"\");
                FileInfo[] files = dir.GetFiles(string.Format("*_{0}.jpg", this.CardNoID));

                SortAsFileNameDesc(ref files);

                if (files.Length > 0)
                {
                    pboxBShow.Image = Image.FromFile(files[0].FullName);
                }
                else
                {
                    btnPrint.Visible = false;
                }


            }
        }

        /// <summary>
        /// C#按名称排序（倒序）
        /// </summary>
        /// <param name="arrFi">待排序数组</param>
        private void SortAsFileNameDesc(ref FileInfo[] arrFi)
        {
            Array.Sort(arrFi, delegate(FileInfo x, FileInfo y) { return y.Name.CompareTo(x.Name); });
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            /*  Process pr = new Process();
              pr.StartInfo.FileName = FilePath;
              pr.StartInfo.CreateNoWindow = true;
              pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
              pr.StartInfo.Verb = "Print";
              pr.Start();

              pr.WaitForExit();

              MessageBox.Show("打印完成");*/

            PrintDialog MyPrintDg = new PrintDialog();
            MyPrintDg.Document = printDocument1;
            if (MyPrintDg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument1.Print();
                }
                catch
                {   //停止打印
                    printDocument1.PrintController.OnEndPrint(printDocument1, new System.Drawing.Printing.PrintEventArgs());
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Image.FromFile(FilePath), 0, 0);
        }
    }
}
