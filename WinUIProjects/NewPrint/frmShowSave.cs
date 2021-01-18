
using printClass;
using ReportPrint;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.BLL;

namespace NewPrint
{
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class frmShowSave : Window, IComponentConnector
    {
        public delegate void MergeInvokeDelegate();
        private Thread th;
        private static int count;
        internal ProgressBar progressBar1;
        internal Label lbMsg;
        private bool _contentLoaded;
        private string area = ConfigHelper.GetSetNode("area");
        
        public string Path { get; set; }

        public bool IsHaveReport
        {
            get;
            set;
        }

        public string CardID
        {
            get;
            set;
        }

        public bool IsPrintBlood
        {
            get;
            set;
        }

        public RecordsBaseInfoModel BaseModel
        {
            get;
            set;
        }

        public frmShowSave()
        {
            this.InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.progressBar1.Maximum = 50.0;
            this.th = new Thread(new ThreadStart(this.saveFun));
            this.th.Start();
            base.Topmost = true;
        }

        public void saveFun()
        {
            //if (File.Exists("printtemp\\xpsShow.xps"))
            //{
            //    File.Delete("printtemp\\xpsShow.xps");
            //}

            //string[] files = Directory.GetFiles("printTemp");
            //for (int i = 0; i < files.Length; i++)
            //{
            //    string path = files[i];
            //    File.Delete(path);
            //}

            frmShowSave.count = 0;
            IGetReport igp;
            int no = 1;
            IsHaveReport = false;

            string[] idCardsStrings = CardID.Split(';');

            foreach (string idCardNo in idCardsStrings)
            {
                if (area.Equals("济南"))
                {
                    igp = new OldHealthReport();
                    this.saveInvoke(igp, idCardNo, no.ToString(),0);
                }
                igp = new HealthCoverCard();
                this.saveInvoke(igp, idCardNo, no.ToString(), 1);
                igp = new ArchivePhysical();
                this.saveInvoke(igp, idCardNo, no.ToString(), 2);
                //igp = new HealthReport();
                //this.saveInvoke(igp, idCardNo, no.ToString());
                igp = new Physical_OldSelfCare();
                this.saveInvoke(igp, idCardNo, no.ToString(), 3);
                igp = new Old_Medicine_CN();
                this.saveInvoke(igp, idCardNo, no.ToString(), 4);

                if (area.Equals("禹城"))
                {
                    igp = new TypeBchao();
                    igp.CardID = idCardNo;
                    if (!igp.hasData()) igp = null;
                    else this.saveInvoke(igp, idCardNo, no.ToString(), 6);

                    string ecgType = DrawItems.GetECGConfig();

                    if (ecgType == "2")
                    {
                        igp = new ElectroCardioGramcs();
                        igp.CardID = idCardNo;
                        if (!igp.hasData()) igp = null;
                        else this.saveInvoke(igp, idCardNo, no.ToString(), 7);
                    }

                    igp = new OldHealthFeedback();
                    this.saveInvoke(igp, idCardNo, no.ToString(), 6);
                }

                if (IsPrintBlood)
                {
                    igp = new Blood_Urine();
                    this.saveInvoke(igp, idCardNo, no.ToString(), 5);
                }
                no++;
            }

            Thread.Sleep(1000);

            if (!IsHaveReport)
            {
                System.Windows.Forms.MessageBox.Show("无打印资料！", "提示",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

                CloseWin("test");

                return;
            }

            this.setMsg("开始生成合并文档");
            this.MergeInvoke();
            this.CloseWin("test");
        }

        public void saveInvoke(IGetReport igp, string idCardNo, string no)
        {
            Thread.Sleep(300);
            Action<IGetReport, String, String> tt = new Action<IGetReport, String, String>(SaveTo);
            IsHaveReport = true;
            this.Dispatcher.BeginInvoke(tt, igp, idCardNo, no);
        }

        public void saveInvoke(IGetReport igp, string idCardNo, string no, int sortNo)
        {
            Thread.Sleep(300);
            Action<IGetReport, String, String, int> tt = new Action<IGetReport, String, String, int>(SaveTo);
            IsHaveReport = true;
            this.Dispatcher.BeginInvoke(tt, igp, idCardNo, no, sortNo);
        }

        public void MergeInvoke()
        {
            base.Dispatcher.BeginInvoke(new frmShowSave.MergeInvokeDelegate(this.MergeDocument), new object[0]);
        }

        public void SaveTo(IGetReport igp, string idCardNo, string no)
        {
            igp.BaseModel = new RecordsBaseInfoBLL().GetModel(idCardNo);
            igp.CardID = idCardNo;

            if (igp.hasData())
            {
                this.setMsg("正在处理：" + igp.PrintName);
                DrawItems.SaveReport(Path + no + igp.PrintName.Replace(".xps", "") + idCardNo + ".xps", igp.getReport());
            }

            if (frmShowSave.count < 50)
            {
                this.setProcess(frmShowSave.count);
                frmShowSave.count += 2;
            }
        }
        public void SaveTo(IGetReport igp, string idCardNo, string no, int sortNo)
        {
            igp.BaseModel = new RecordsBaseInfoBLL().GetModel(idCardNo);
            igp.CardID = idCardNo;

            if (igp.hasData())
            {
                this.setMsg("正在处理：" + igp.PrintName);
                DrawItems.SaveReport(Path + no + sortNo.ToString() + igp.PrintName.Replace(".xps", "") + idCardNo + ".xps", igp.getReport());
            }

            if (frmShowSave.count < 50)
            {
                this.setProcess(frmShowSave.count);
                frmShowSave.count += 2;
            }
        }

        public void setMsg(string strmsg)
        {
            string.Format("{0}", strmsg);
            if (this.lbMsg.Dispatcher.Thread != Thread.CurrentThread)
            {
                Action<string> method = new Action<string>(this.setMsg);
                this.lbMsg.Dispatcher.Invoke(method, new object[]
				{
					strmsg
				});
                return;
            }
            this.lbMsg.Content = strmsg;
        }

        public void CloseWin(string val)
        {
            if (base.Dispatcher.Thread != Thread.CurrentThread)
            {
                Action<string> method = new Action<string>(this.CloseWin);
                base.Dispatcher.Invoke(method, new object[]
				{
					val
				});
                return;
            }
            base.Close();
        }

        public void setProcess(int strmsg)
        {
            if (this.lbMsg.Dispatcher.Thread == Thread.CurrentThread)
            {
                this.progressBar1.Value = (double)strmsg;
                return;
            }
            Action<int> method = new Action<int>(this.setProcess);
            this.progressBar1.Dispatcher.Invoke(method, new object[]
			{
				strmsg
			});
        }

        public void MergeDocument()
        {
            string path = Path + "xpsShow.xps";
            List<string> list = new List<string>();
            List<string> lstName = new List<string>();
            list.AddRange(Directory.GetFiles(Path));
            list.Sort();
            string[] idCardsStrings = CardID.Split(';');

            foreach (string idCardNo in idCardsStrings)
            {
                foreach (var item in list)
                {
                    if (!string.IsNullOrEmpty(item) && item.Contains(idCardNo))
                    {
                        lstName.Add(item);
                    }
                }
            }
            FixedDocumentSequence fixedDocumentSequence = new FixedDocumentSequence();

            foreach (string current in lstName)
            {
                if (frmShowSave.count < 50)
                {
                    this.setProcess(frmShowSave.count);
                    frmShowSave.count++;
                }
                if (current != "xpsShow.xps" && current.Contains(".xps"))   //&& !current.ToUpper().Contains(".PNG")
                {
                    DocumentReference item = this.AddPage(current);
                    fixedDocumentSequence.References.Add(item);
                }
            }

            File.Delete(path);
            this.setProcess(46);
            XpsDocument xpsDocument = new XpsDocument(path, FileAccess.ReadWrite);
            XpsDocumentWriter xpsDocumentWriter = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
            this.setProcess(47);
            xpsDocumentWriter.Write(fixedDocumentSequence);
            xpsDocument.Close();
        }

        public DocumentReference AddPage(string fileName)
        {
            DocumentReference documentReference = new DocumentReference();
            FixedDocument fixedDocument = new FixedDocument();
            XpsDocument xpsDocument = new XpsDocument(fileName, FileAccess.Read);
            FixedDocumentSequence fixedDocumentSequence = xpsDocument.GetFixedDocumentSequence();
            int page = 0;
            foreach (DocumentReference current in fixedDocumentSequence.References)
            {
                FixedDocument document = current.GetDocument(false);
                page = document.Pages.Count;
                foreach (PageContent current2 in document.Pages)
                {
                    Uri source = current2.Source;
                    Uri baseUri = ((IUriContext)current2).BaseUri;
                    PageContent pageContent = new PageContent();
                    pageContent.GetPageRoot(false);
                    pageContent.Source = source;
                    ((IUriContext)pageContent).BaseUri = baseUri;
                    fixedDocument.Pages.Add(pageContent);
                }
            }
            if (page % 2 != 0 && ConfigHelper.GetSetNode("Dprint") == "Y") //双面打印机增加空白页
            {
                FrameworkElement FE = new FrameworkElement();
                FixedPage FP = new FixedPage();
                FP.Width = 793.76;
                FP.Height = 1122.56;
                FP.Children.Add(FE);
                PageContent pageContent = new PageContent();
                pageContent.Child = FP;
                fixedDocument.Pages.Add(pageContent);
            }
            documentReference.SetDocument(fixedDocument);
            xpsDocument.Close();
            return documentReference;
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (this._contentLoaded)
            {
                return;
            }
            this._contentLoaded = true;
            Uri resourceLocator = new Uri("/NewPrint;component/frmshowsave.xaml", UriKind.Relative);
            Application.LoadComponent(this, resourceLocator);
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        void IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    ((frmShowSave)target).Loaded += new RoutedEventHandler(this.Window_Loaded);
                    return;
                case 2:
                    this.progressBar1 = (ProgressBar)target;
                    return;
                case 3:
                    this.lbMsg = (Label)target;
                    return;
                default:
                    this._contentLoaded = true;
                    return;
            }
        }
    }
}
