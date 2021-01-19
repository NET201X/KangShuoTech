using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BTCHITBP
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
            //string idNo = "370101195008158899";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(idNo));
        }
    }
}
