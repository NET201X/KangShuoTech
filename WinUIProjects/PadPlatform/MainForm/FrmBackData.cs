using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace KangShuo
{
    public partial class FrmBackData : Form
    {
        string strPath = "D:\\QCSoft\\BackData\\";
        public FrmBackData()
        {
            InitializeComponent();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            try
            {
                this.lbMess.Text = "正在备份，请稍后..........";
                string name = DateTime.Now.DayOfWeek.ToString();
                string strWeek = "";
                switch (name)
                {
                    case "Sunday":
                        strWeek = "星期日";
                        break;
                    case "Monday":
                        strWeek = "星期一";
                        break;
                    case "Tuesday":
                        strWeek = "星期二";
                        break;
                    case "Wednesday":
                        strWeek = "星期三";
                        break;
                    case "Thursday":
                        strWeek = "星期四";
                        break;
                    case "Friday":
                        strWeek = "星期五";
                        break;
                    case "Saturday":
                        strWeek = "星期六";
                        break;
                    default:
                        break;
                }
                string DataName = strPath + "KangShuo_db" + strWeek + ".sql";
                //string DataName = strPath + "KangShuo_db" + Convert.ToDateTime(DateTime.Now.Date).ToString("yyyyMMdd")+".sql"; 
                string command = string.Format("mysqldump -h {0} -u {1} -p{2} {3} > {4}", "localhost", "root", "qckj", "KangShuo_db", DataName);
                StartCmd(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public string Path()
        {
            string location = "";
            var registerLocation = @"Software\MySQL AB\MySQL Server 5.6";
            var key = Registry.LocalMachine.OpenSubKey(registerLocation);
            if (key != null)
            {
                location = key.GetValue("Location").ToString();
            }
            return location;
        }
        public void StartCmd(String command)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.WorkingDirectory = Path() + @"bin";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine(command);
                p.StandardInput.WriteLine("exit");

                p.WaitForExit();
                //string output = p.StandardError.ReadToEnd();
                p.Close();
                this.lbMess.Text = "备份成功!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FrmBackData_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.strPath))
            {
                Directory.CreateDirectory(this.strPath);
            }
        }  
    }
}
