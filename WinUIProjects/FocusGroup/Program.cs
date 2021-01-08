namespace FocusGroup
{
    using KangShuoTech.Utilities.Common;
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogHelper.InitLog();
            ConfigHelper.Init();
            Application.Run(new Form1());
        }
    }
}

