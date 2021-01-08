using System;
using System.IO;
using System.Printing;
using System.Windows;
namespace HealthNewPrint
{
	public class BatchXPSPrinter
	{
		public static void PrintXPS(object sender)
		{
			string text = sender.ToString();
			new LocalPrintServer();
			PrintQueue defaultPrintQueue = LocalPrintServer.GetDefaultPrintQueue();
			bool arg_19_0 = defaultPrintQueue.IsXpsDevice;
			FileInfo fileInfo = new FileInfo(text);
			try
			{
				defaultPrintQueue.AddJob(fileInfo.Name, text, false);
			}
			catch (PrintJobException ex)
			{
				MessageBox.Show(string.Format("\n\t{0} 无法加入打印队列，请查看打印机设置.", fileInfo.Name));
				if (ex.InnerException.Message == "File contains corrupted data.")
				{
					MessageBox.Show("\t文档结构出错，请重试");
				}
			}
		}
	}
}
