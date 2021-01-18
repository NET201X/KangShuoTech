using KangShuoTech.Utilities.Common;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
namespace NewPrint
{
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class App : Application
    {
        public string IDCard { get; set; }

        public string PrintType { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigHelper.Init();
            string args = e.Args[0];
            //string args = "370101195008158899;370101199211111111";
            //string args = "汇出&体检报告&AND B.CheckDate BETWEEN '2020-04-20' AND '2020-04-20'";

            if (args.Contains("&"))
            {
                string[] temp = args.Split('&');
                this.IDCard = temp[0].ToString();
                this.PrintType = temp[1].ToString();

                if (IDCard.Equals("汇出"))
                {
                    frmShowBatchExport frm = new frmShowBatchExport();
                    frm.CardID = IDCard;
                    frm.PrintType = temp[1].ToString();
                    frm.PrintWhere = temp[2].ToString().Replace("#", " ");
                    frm.ShowDialog();

                    base.OnStartup(e);
                    return;
                }
            }
            else
            {
                this.IDCard = args;
                this.PrintType = "";
            }
            new MainWindow
            {
                IDCard = this.IDCard
            }.ShowDialog();

            base.OnStartup(e);
        }

        [DebuggerNonUserCode, STAThread]
        public static void Main()
        {
            App app = new App();
            app.Run();
        }
    }
}
