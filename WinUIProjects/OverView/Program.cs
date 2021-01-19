
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonUI;

namespace OverView
{
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ConfigHelper.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run((Form) new Controler(new MDIParentForm("36050219360726464X"), new OverViewFactory()).IParentFrm);
        }
    }
}

