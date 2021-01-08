using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;


namespace HealthNewPrint
{
    /// <summary>
    /// frmPrint.xaml 的交互逻辑
    /// </summary>
    public partial class frmPrint : Window, IComponentConnector
    {
        public FixedDocumentSequence pFixDocument
        {
            get;
            set;
        }

        public string DocName
        {
            get;
            set;
        }

        public frmPrint()
        {
            InitializeComponent();

            if (!Directory.Exists("printtemp"))
            {
                Directory.CreateDirectory("printtemp");
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.DocName))
            {
                Thread thread = new Thread(new ParameterizedThreadStart(BatchXPSPrinter.PrintXPS));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start(this.DocName);
                MessageBox.Show("打印完成");
            }
            else
            {
                MessageBox.Show("无打印文件，请重试");
            }
            base.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            base.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            base.ShowActivated = true;
            base.Topmost = true;
            if (!string.IsNullOrEmpty(this.DocName))
            {
                XpsDocument xpsDocument = new XpsDocument(this.DocName, FileAccess.Read);
                FixedDocumentSequence fixedDocumentSequence = xpsDocument.GetFixedDocumentSequence();
                this.docView.Document = fixedDocumentSequence;
                xpsDocument.Close();
            }
        }
    }
}
