using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BTQCATF
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string idNo = args[0];

            //string idNo = "370103198107310012";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(idNo));
        }
    }
}
