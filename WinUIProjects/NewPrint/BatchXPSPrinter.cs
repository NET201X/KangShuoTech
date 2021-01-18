using System;
using System.IO;
using System.Printing;
using System.Windows;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace NewPrint
{
    public class BatchXPSPrinter
    {
        public static void PrintXPS1(object sender)
        {
            string text = sender.ToString();
            LocalPrintServer localPrintServer = new LocalPrintServer();
            PrintQueue defaultPrintQueue = LocalPrintServer.GetDefaultPrintQueue();
            bool arg_19_0 = defaultPrintQueue.IsXpsDevice;
            FileInfo fileInfo = new FileInfo(text);

            try
            {
                defaultPrintQueue.AddJob(fileInfo.Name, text, false);
                MessageBox.Show("打印完成");
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
        public static void PrintXPS(object sender)
        {
            string text = sender.ToString();
            LocalPrintServer localPrintServer = new LocalPrintServer();
            PrintQueue defaultPrintQueue = LocalPrintServer.GetDefaultPrintQueue();
            bool arg_19_0 = defaultPrintQueue.IsXpsDevice;
            FileInfo fileInfo = new FileInfo(text);

            try
            {
                defaultPrintQueue.AddJob(fileInfo.Name, text, false);
                MessageBox.Show("打印完成");
            }
            catch (PrintJobException ex)
            {
                MessageBox.Show(string.Format("\n\t{0} 无法加入打印队列，请查看打印机设置.", fileInfo.Name));
                if (ex.InnerException.Message == "File contains corrupted data.")
                {
                    MessageBox.Show("\t文档结构出错，请重试");
                }
            }

            //LocalPrintServer ps = new LocalPrintServer();

            //// Get the default print queue
            //PrintQueue pq = ps.DefaultPrintQueue;

            //// Get an XpsDocumentWriter for the default print queue
            //XpsDocument xpsDocument = new XpsDocument(text, FileAccess.ReadWrite);
            //XpsDocumentWriter xpsdw = PrintQueue.CreateXpsDocumentWriter(pq);

            //return xpsdw;
        }
    }
}
