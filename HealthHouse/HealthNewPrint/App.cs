using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Reflection;
namespace HealthNewPrint
{
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public class App : Application
	{
		public string IDCard
		{
			get;
			set;
		}
        public string PrintType
        {
            get;
            set;
        }
		protected override void OnStartup(StartupEventArgs e)
		{
            try
            {
                string args = e.Args[0];
                //string args = "370101199211111111";
                if (args.Contains("&"))
                {
                    string[] temp = args.Split('&');
                    this.IDCard = temp[0].ToString();
                    this.PrintType = temp[1].ToString();
                }
                else
                {
                    this.IDCard = args;
                    this.PrintType ="";
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            if (string.IsNullOrEmpty(this.IDCard))
            {
                MessageBox.Show("身份证号不能为空");
                //MessageBox.Show(IDCard);
                return;
            }
            new MainWindow
            {
                IDCard = this.IDCard,
                PrintType=this.PrintType
            }.ShowDialog();
          
		}

		[DebuggerNonUserCode, STAThread]
		public static void Main()
		{
			App app = new App();
			app.Run();
		}
	}
}
