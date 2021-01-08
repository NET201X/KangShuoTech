using KangShuoTech.Utilities.Common;

namespace RecordManagement
{
    
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigHelper.Init();
            Application.Run(new frmHealthRefresh());
            //Application.Run(new Form1());
        }
    }
}

