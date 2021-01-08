using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using printClass;
using KangShuoTech.DataAccessProjects.Model;
using ReportPrint;
using KangShuoTech.DataAccessProjects.BLL;

namespace HealthNewPrint
{
    /// <summary>
    /// frmShowBatch.xaml 的交互逻辑
    /// </summary>
    public partial class frmShowBatch : Window
    {
        public frmShowBatch()
        {
            InitializeComponent();
        }

        public string CardID { get; set; }

        public string PrintType { get; set; }

        public RecordsBaseInfoModel BaseModel
        {
            set;
            get;
        }
        public string Path { get; set; }

        Thread th;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.progressBar1.Maximum = 50;
            th = new Thread(saveFun);
            th.Start();
            this.Topmost = true;
        }

        static int count = 0;

        public void saveFun()
        {
            string[] idCardsStrings = CardID.Split(';');

            count = 0;
            IGetReport igp;
            foreach (string idCardNo in idCardsStrings)
            {
                switch (PrintType)
                {
                    case "btnHousePhysical":
                        igp = new HousePhysical();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnTypeBUI":
                        igp = new TypeBchao();
                        igp.CardID = idCardNo;
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnECG":
                        string ecgType = DrawItems.GetECGConfig();

                        if (ecgType == "2")
                        {
                            igp = new ElectroCardioGramcs();
                            igp.CardID = idCardNo;
                            saveInvoke(igp, idCardNo);
                        }
                        else igp = null;
                        break;
                    default:
                        igp = null;
                        break;
                }
            }

            Thread.Sleep(1000);
            setMsg("开始生成合并文档");
            MergeInvoke();
            CloseWin("test");
        }

        public void saveInvoke(IGetReport igp, string idCardNo)
        {
            Thread.Sleep(300);
            Action<IGetReport, String> tt = new Action<IGetReport, String>(SaveTo);

            this.Dispatcher.BeginInvoke(tt, igp, idCardNo);
        }

        public delegate void MergeInvokeDelegate();

        public void MergeInvoke()
        {
            this.Dispatcher.BeginInvoke(new MergeInvokeDelegate(MergeDocument));
        }

        public void SaveTo(IGetReport igp, string idCardNo)
        {
            igp.BaseModel = new RecordsBaseInfoBLL().GetModel(idCardNo);
            igp.CardID = idCardNo;

            //if (igp.hasData())
            //{
            setMsg("正在处理：" + igp.PrintName);
            DrawItems.SaveReport(Path + igp.PrintName.Replace(".xps", "") + idCardNo + ".xps", igp.getReport());
            //}

            if (count < 50)
            {
                setProcess(count);
                count = count + 2;
            }
        }

        #region 设置异步

        public void setMsg(string strmsg)
        {
            string Msg = string.Format("{0}", strmsg);
            if (this.lbMsg.Dispatcher.Thread != Thread.CurrentThread)
            {
                Action<string> ashow = new Action<string>(setMsg);
                lbMsg.Dispatcher.Invoke(ashow, strmsg);
            }
            else
            {
                this.lbMsg.Content = strmsg;
            }

        }

        public void CloseWin(string val)
        {
            if (this.Dispatcher.Thread != Thread.CurrentThread)
            {
                Action<string> ashow = new Action<string>(CloseWin);
                this.Dispatcher.Invoke(ashow, val);
            }
            else
            {
                this.Close();
            }
        }

        public void setProcess(int strmsg)
        {
            if (this.lbMsg.Dispatcher.Thread == Thread.CurrentThread)
            {
                this.progressBar1.Value = strmsg;
            }
            else
            {
                Action<int> ashow = new Action<int>(setProcess);
                this.progressBar1.Dispatcher.Invoke(ashow, strmsg);
            }

        }

        #endregion

        //合并文档，将文档合并到xpsShow.xps里面
        public void MergeDocument()
        {
            string newFile = Path+"xpsShow.xps";

            List<string> lsFileName = new List<string>();

            lsFileName.AddRange(Directory.GetFiles(Path));
            lsFileName.Sort();

            FixedDocumentSequence newFds = new FixedDocumentSequence();//创建一个新的文档结构

            foreach (var item in lsFileName)
            {
                if (count < 50)
                {
                    setProcess(count);
                    count++;
                }

                if (item != "xpsShow.xps" && !item.Contains(".xps"))
                {
                    DocumentReference newDocRef = AddPage(item);
                    newFds.References.Add(newDocRef);
                }
            }

            File.Delete(newFile);
            setProcess(46);
            //xps写入新文件
            XpsDocument NewXpsDocument = new XpsDocument(newFile, System.IO.FileAccess.ReadWrite);
            XpsDocumentWriter xpsDocumentWriter = XpsDocument.CreateXpsDocumentWriter(NewXpsDocument);
            setProcess(47);
            xpsDocumentWriter.Write(newFds);

            NewXpsDocument.Close();
        }

        public DocumentReference AddPage(string fileName)
        {
            DocumentReference newDocRef = new DocumentReference();
            FixedDocument newFd = new FixedDocument();

            XpsDocument xpsDocument = new XpsDocument(fileName, FileAccess.Read);
            FixedDocumentSequence docSeq = xpsDocument.GetFixedDocumentSequence();

            foreach (DocumentReference docRef in docSeq.References)
            {
                FixedDocument fd = docRef.GetDocument(false);

                foreach (PageContent oldPC in fd.Pages)
                {
                    Uri uSource = oldPC.Source;//读取源地址
                    Uri uBase = (oldPC as IUriContext).BaseUri;//读取目标页面地址
                    PageContent newPageContent = new PageContent();
                    newPageContent.GetPageRoot(false);//这个地方应当是把文档解压成一个包放到内存中我们再去读取
                    newPageContent.Source = uSource;
                    (newPageContent as IUriContext).BaseUri = uBase;
                    newFd.Pages.Add(newPageContent);//将新文档追加到新的documentRefences中
                }
            }
            newDocRef.SetDocument(newFd);
            xpsDocument.Close();
            return newDocRef;
        }
    }
}
