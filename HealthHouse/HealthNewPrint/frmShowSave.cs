
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
using KangShuoTech.DataAccessProjects.BLL;

namespace HealthNewPrint
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

        public string CardID
        {
            get;
            set;
        }

        public RecordsBaseInfoModel BaseModel
        {
            get;
            set;
        }
        public string Path { get; set; }

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
           
            frmShowSave.count = 0;
            IGetReport igp;
            int no = 1;

            string[] idCardsStrings = CardID.Split(';');

            foreach (string idCardNo in idCardsStrings)
            {
                igp = new HousePhysical();
                this.saveInvoke(igp, idCardNo, no.ToString());
                igp = new TypeBchao();
                this.saveInvoke(igp, idCardNo, no.ToString());
                igp = new HouseBone();
                this.saveInvoke(igp, idCardNo, no.ToString());
                igp = new HealthVascular();
                this.saveInvoke(igp, idCardNo, no.ToString());
                igp = new HealthLung();
                this.saveInvoke(igp, idCardNo, no.ToString());
                igp = new HealthAssess();
                this.saveInvoke(igp, idCardNo, no.ToString());
                igp = new HealthGuide();
                this.saveInvoke(igp, idCardNo, no.ToString());
                string ecgType = DrawItems.GetECGConfig();
                if (ecgType == "2")
                {
                    igp = new ElectroCardioGramcs();
                    this.saveInvoke(igp, idCardNo, no.ToString());
                }
                no++;
            }

            Thread.Sleep(1000);
            this.setMsg("开始生成合并文档");
            this.MergeInvoke();
            this.CloseWin("test");
        }

        public void saveInvoke(IGetReport igp, string idCardNo, string no)
        {
            Thread.Sleep(300);
            Action<IGetReport, String, String> tt = new Action<IGetReport, String, String>(SaveTo);
            this.Dispatcher.BeginInvoke(tt, igp, idCardNo, no);
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
            string path = Path+"xpsShow.xps";
            List<string> list = new List<string>();
            list.AddRange(Directory.GetFiles(Path));
            list.Sort();
            FixedDocumentSequence fixedDocumentSequence = new FixedDocumentSequence();

            foreach (string current in list)
            {
                if (frmShowSave.count < 50)
                {
                    this.setProcess(frmShowSave.count);
                    frmShowSave.count++;
                }
                if (current != "xpsShow.xps"&&current.Contains(".xps"))
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
            foreach (DocumentReference current in fixedDocumentSequence.References)
            {
                FixedDocument document = current.GetDocument(false);
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
            Uri resourceLocator = new Uri("/HealthNewPrint;component/frmshowsave.xaml", UriKind.Relative);
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
