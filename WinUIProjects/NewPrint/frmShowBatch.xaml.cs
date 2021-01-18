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
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.BLL;

namespace NewPrint
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

        public bool IsHaveReport
        {
            get;
            set;
        }

        public string CardID { get; set; }

        public string PrintType { get; set; }

        public string Path { get; set; }

        string community = ConfigHelper.GetSetNode("community");
        string area = ConfigHelper.GetSetNode("area");
        public RecordsBaseInfoModel BaseModel
        {
            set;
            get;
        }

        Thread th;
        object senders;
        RoutedEventArgs es;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.senders = sender;
            this.es = e;
            this.progressBar1.Maximum = 50;
            th = new Thread(saveFun);
            th.Start();
            this.Topmost = true;
        }

        static int count = 0;

        public void saveFun()
        {
            //if (File.Exists("printtemp\\xpsShow.xps"))
            //{
            //    File.Delete("printtemp\\xpsShow.xps");
            //}

            //foreach (string strFile in Directory.GetFiles("printTemp"))
            //{
            //    File.Delete(strFile);
            //}

            string[] idCardsStrings = CardID.Split(';');

            count = 0;
            IsHaveReport = false;

            IGetReport igp;

            //int i = 0;
            //int n = 0;

            foreach (string idCardNo in idCardsStrings)
            {
                //n ++;

                //if (n != idCardsStrings.Length)
                //{
                //    if (PrintType == "btnOLDMEDICINECN")
                //    {
                //        RecordsCustomerBaseInfoModel modelc = new RecordsCustomerBaseInfoDAL().GetMaxModel(idCardNo);
                //        if (modelc == null )
                //        {
                //            continue;
                //        }
                //        RecordsMediPhysDistModel modelMdist = new RecordsMediPhysDistDAL().GetModelByOutKey(modelc.ID);
                //        if (modelMdist != null)
                //        {
                //            RecordsMedicineCnModel model2 = new RecordsMedicineCnBLL().GetModel(modelMdist.MedicineID);

                //            if (model2 == null || model2.FollowUpDoctor == "")
                //            {
                //                continue;
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    if (i != 0)
                //    {
                //        if (PrintType == "btnOLDMEDICINECN")
                //        {
                //            RecordsCustomerBaseInfoModel modelc = new RecordsCustomerBaseInfoDAL().GetMaxModel(idCardNo);
                //            if (modelc == null)
                //            {
                //                continue;
                //            }
                //            RecordsMediPhysDistModel modelMdist = new RecordsMediPhysDistDAL().GetModelByOutKey(modelc.ID);
                //            if (modelMdist != null)
                //            {
                //                RecordsMedicineCnModel model2 = new RecordsMedicineCnBLL().GetModel(modelMdist.MedicineID);

                //                if (model2 == null || model2.FollowUpDoctor == "")
                //                {
                //                    continue;
                //                }
                //            }
                //        }
                //    }
                //}

                //i++;

                switch (PrintType)
                {
                    case "btnFengmian":
                        if (area == "淄博")
                        {
                            igp = new HealthReport();
                            saveInvoke(igp, idCardNo);
                        }
                        else
                        {

                            igp = new ArchiveCover();
                            saveInvoke(igp, idCardNo);
                        }
                        break;
                    case "btnBaseInfo":
                        igp = new ArchiveBase();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnHyper":
                        igp = new Hypertension_Followup();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnDiabetes":
                        igp = new Diabetes_Followup();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnMentaldisease_Baseinfo":
                        igp = new Mentaldisease_Baseinfo();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnMentalFollow":
                        igp = new Mentaldisease_Followup();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnPhysical":
                        igp = new ArchivePhysical();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnArchiveCard":
                        igp = new ArchiveCard();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnChildInOne":
                        igp = new Child_With_ONE();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnChildNEW":
                        igp = new Child_With_NEW();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnChildTWO":
                        igp = new Child_With_TWO();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnChildTHREE":
                        igp = new Child_With_THREE();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnGRAVIDA_FRIST":
                        igp = new GRAVIDA_FRIST();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnGRAVIDA_TWO":
                        igp = new GRAVIDA_TWO();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnGRAVIDA_POST":
                        igp = new GRAVIDA_Postpartum();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnGRAVIDA_POST42":
                        igp = new GRAVIDA_Postpartum42();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnOLDMEDICINECN":

                        igp = new Old_Medicine_CN();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnChildCNOne":
                        igp = new Child_CN_ONE();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnChildCNOne2Three":
                        igp = new Child_CN_TWO();
                        saveInvoke(igp, idCardNo);
                        break;
                    //case "btnChildCNThree2Six":
                    //    igp = new Child_CN_THREE();
                    //    saveInvoke(igp, idCardNo);
                    //    break;
                    case "btnChd":
                        igp = new CHD_Follow();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btStroke":
                        igp = new Stroke_Followup();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnOnePTBVisit":
                        igp = new LungerFirstVisit();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnPTBVisit":
                        igp = new ChronicLungerVisit();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnHealth":
                        igp = new HealthEducation();
                        //igp = new HealthExamination();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnHealthFeedback":
                        igp = new HealthFeedback();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnMReceiveTreat":
                        igp = new Medical_Receive();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnMConsulation":
                        igp = new Medical_Consulation();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnMReferral":
                        igp = new Medical_Refferral();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnPhyOLDSelf":
                        igp = new Physical_OldSelfCare();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnOldHealthFeedback":
                        if (area.Equals("淄博"))
                        {
                            igp = new OldHealthFeedback();
                        }
                        else if (community.Equals("日照街道社区"))
                        {
                            igp = new OldHealthFeedbackRiZhao();
                        }
                        else igp = new OldHealthFeedbackYuCheng();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnCoverCard":
                        igp = new HealthCoverCard();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnBloodUrine":
                        igp = new Blood_Urine();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnCoverCard_2":
                        igp = new HealthCoverCard_Colour();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnECG":
                        string ecgType = DrawItems.GetECGConfig();

                        if (ecgType == "2")
                        {
                            igp = new ElectroCardioGramcs();
                            igp.CardID = idCardNo;
                            if (!igp.hasData()) igp = null;
                            else this.saveInvoke(igp, idCardNo);
                        }
                        break;
                    case "btnTypeBUI":
                        igp = new TypeBchao();
                        igp.CardID = idCardNo;
                        if (!igp.hasData()) igp = null;
                        else this.saveInvoke(igp, idCardNo);
                        break;
                    case "btnPhyicalRe":
                        igp = new PhyicalReport();
                        saveInvoke(igp, idCardNo);
                        break;
                    case "btnOldCover":
                        igp = new OldHealthReport();
                        saveInvoke(igp, idCardNo);
                        break;
                    default:
                        igp = null;
                        break;
                }
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

            setMsg("开始生成合并文档");
            MergeInvoke();
            CloseWin("test");
        }

        public void saveInvoke(IGetReport igp, string idCardNo)
        {
            Thread.Sleep(300);
            Action<IGetReport, String> tt = new Action<IGetReport, String>(SaveTo);
            IsHaveReport = true;

            this.Dispatcher.BeginInvoke(tt, igp, idCardNo);
        }

        public delegate void MergeInvokeDelegate();

        public void MergeInvoke()
        {
            this.Dispatcher.BeginInvoke(
            new MergeInvokeDelegate(MergeDocument)
            );
        }

        public void SaveTo(IGetReport igp, string idCardNo)
        {
            if (igp != null)
            {
                igp.BaseModel = new RecordsBaseInfoBLL().GetModel(idCardNo);
                igp.CardID = idCardNo;

                //if (igp.hasData())
                //{
                setMsg("正在处理：" + igp.PrintName);
                DrawItems.SaveReport(Path + igp.PrintName.Replace(".xps", "") + idCardNo + ".xps", igp.getReport());
                //}
            }

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
            string newFile = Path+ "xpsShow.xps";

            List<string> lsFileName = new List<string>();
            List<string> lstName = new List<string>();
            lsFileName.AddRange(Directory.GetFiles(Path));

            if (lsFileName.Count == 0)
            {
                IsHaveReport = false;
                return;
            }

            lsFileName.Sort();

            string[] idCardsStrings = CardID.Split(';');

            foreach (string idCardNo in idCardsStrings)
            {
                foreach (var item in lsFileName)
                {
                    if (!string.IsNullOrEmpty(item) && item.Contains(idCardNo))
                    {
                        lstName.Add(item);
                    }
                }
            }
            FixedDocumentSequence newFds = new FixedDocumentSequence();//创建一个新的文档结构

            foreach (var item in lstName)
            {
                if (count < 50)
                {
                    setProcess(count);
                    count++;
                }

                if (item != "xpsShow.xps" && item.ToUpper().Contains(".XPS"))
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
            int page = 0;
            foreach (DocumentReference docRef in docSeq.References)
            {
                FixedDocument fd = docRef.GetDocument(false);
                page = fd.Pages.Count;
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

            if (page % 2 != 0 && ConfigHelper.GetSetNode("Dprint") == "Y") //双面打印机增加空白页
            {
                FrameworkElement FE = new FrameworkElement();
                FixedPage FP = new FixedPage();
                FP.Width = 793.76;
                FP.Height = 1122.56;
                FP.Children.Add(FE);
                PageContent pageContent = new PageContent();
                pageContent.Child = FP;
                newFd.Pages.Add(pageContent);
            }
            newDocRef.SetDocument(newFd);
            xpsDocument.Close();
            return newDocRef;
        }


    }
}
