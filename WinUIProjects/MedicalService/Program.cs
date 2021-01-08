using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonUI;

namespace MedicalService
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
            Application.Run((Form)new Controler(new MDIParentForm("130925201108107018"), new DataListSeachFactory()).IParentFrm);
        }
    }
}
