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
using System.Data;
using System.Collections;

namespace NewPrint
{
    /// <summary>
    /// frmShowBatch.xaml 的交互逻辑
    /// </summary>
    public partial class frmShowBatchExport : Window
    {
        public frmShowBatchExport()
        {
            InitializeComponent();
        }

        public bool IsHaveReport { get; set; }

        public string CardID { get; set; }

        public string PrintType { get; set; }

        public string PrintWhere { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

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
        ArrayList IDCard = new ArrayList();
        List<List<string>> list = new List<List<string>>();
        string date = DateTime.Now.ToString("yyyyMMddHHmm");
        string area = ConfigHelper.GetSetNode("area");
        string community = ConfigHelper.GetSetNode("community");

        public void saveFun()
        {
            if (File.Exists("printtemp\\xpsShow.xps"))
            {
                File.Delete("printtemp\\xpsShow.xps");
            }

            foreach (string strFile in Directory.GetFiles("printTemp"))
            {
                File.Delete(strFile);
            }

            if (!Directory.Exists(@"D:\汇出打印文件\" + date))
            {
                //foreach (string strFile in Directory.GetFiles(@"D:\汇出打印文件"))
                //{
                //    File.Delete(strFile);
                //}
                Directory.CreateDirectory(@"D:\汇出打印文件\" + date);
            }
            //else Directory.CreateDirectory(@"D:\汇出打印文件");

            RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();

            count = 0;
            IsHaveReport = false;
            IGetReport igp;
            string[] SelectName = PrintType.Split(';');
            int no = 1;

            // 取得资料笔数
            DataTable dtData = archive_baseinfo.GetList(PrintWhere, "").Tables[0];
            DataTable dt = dtData.DefaultView.ToTable("IDCardNo", true, "IDCardNo");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i += 10)
                {
                    CardID = "";

                    for (int j = i; j < i + 10; j++)
                    {
                        if (j < dt.Rows.Count) CardID += dt.Rows[j]["IDCardNo"].ToString() + ";";
                        else break;
                    }

                    IDCard.Add(CardID);

                    #region 生成文件

                    string[] idCardsStrings = CardID.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string idCardNo in idCardsStrings)
                    {
                        foreach (string name in SelectName)
                        {
                            switch (name)
                            {
                                case "封面":
                                    if (area == "淄博") igp = new HealthReport();
                                    else igp = new ArchiveCover();

                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "基本信息":
                                    igp = new ArchiveBase();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "健康体检表":
                                    igp = new ArchivePhysical();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "高血压随访":
                                    igp = new Hypertension_Followup();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "糖尿病随访":
                                    igp = new Diabetes_Followup();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "精神病信息补充":
                                    igp = new Mentaldisease_Baseinfo();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "精神病随访":
                                    igp = new Mentaldisease_Followup();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "居民健康档案卡":
                                    igp = new ArchiveCard();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "老年人中医健康":
                                    igp = new Old_Medicine_CN();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "新生儿家庭访视":
                                    igp = new Child_With_NEW();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "1岁内儿童健康检查":
                                    igp = new Child_With_ONE();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "1-2岁内儿童健康检查":
                                    igp = new Child_With_TWO();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "3-6岁内儿童健康检查":
                                    igp = new Child_With_THREE();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "第1次产前随访":
                                    igp = new GRAVIDA_FRIST();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "第2-5次产前随访":
                                    igp = new GRAVIDA_TWO();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "产后访视记录":
                                    igp = new GRAVIDA_Postpartum();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "产后42天健康检查":
                                    igp = new GRAVIDA_Postpartum42();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "脑卒中随访记录":
                                    igp = new Stroke_Followup();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "冠心病随访记录":
                                    igp = new CHD_Follow();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "6-18月龄儿童中医健康":
                                    igp = new Child_CN_ONE();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "24-36月龄儿童中医健康":
                                    igp = new Child_CN_TWO();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "3-6岁内儿童中医健康":
                                    igp = new Child_CN_THREE();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "第1次肺结核随访":
                                    igp = new LungerFirstVisit();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "肺结核随访":
                                    igp = new ChronicLungerVisit();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "健康教育":
                                    igp = new HealthEducation();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "接诊记录":
                                    igp = new Medical_Receive();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "会诊记录":
                                    igp = new Medical_Consulation();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "双向转诊":
                                    igp = new Medical_Refferral();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "健康体检反馈单":
                                    igp = new HealthFeedback();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "老年人自理能力":
                                    igp = new Physical_OldSelfCare();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "65岁以上老年人健康体检反馈单":
                                    if (area.Equals("淄博"))
                                    {
                                        igp = new OldHealthFeedback();
                                    }
                                    else if (community.Equals("日照街道社区"))
                                    {
                                        igp = new OldHealthFeedbackRiZhao();
                                    }
                                    else igp = new OldHealthFeedbackYuCheng();

                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "档案封面":
                                    igp = new HealthCoverCard();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "血生化、血常规、尿液数据":
                                    igp = new Blood_Urine();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "心电":
                                    string ecgType = DrawItems.GetECGConfig();

                                    if (ecgType == "2")
                                    {
                                        igp = new ElectroCardioGramcs();
                                        igp.CardID = idCardNo;
                                        if (!igp.hasData()) igp = null;
                                        else this.saveInvoke(igp, idCardNo, no.ToString());
                                    }
                                    break;
                                case "B超":
                                    igp = new TypeBchao();
                                    igp.CardID = idCardNo;
                                    if (!igp.hasData()) igp = null;
                                    else this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                case "体检报告":
                                    igp = new PhyicalReport();
                                    this.saveInvoke(igp, idCardNo, no.ToString());
                                    break;
                                default:
                                    igp = null;
                                    break;
                            }
                        }

                        no++;

                        if (no % 10 == 0) Thread.Sleep(1000);
                    }

                    #endregion
                }

                Thread.Sleep(1000);

                if (!IsHaveReport)
                {
                    System.Windows.Forms.MessageBox.Show("无可汇出资料!", "提示",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

                    CloseWin("none");

                    return;
                }

                this.setMsg("开始生成合并文档");
                this.MergeInvoke();
                this.CloseWin("test");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("无可汇出资料!", "提示",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

                CloseWin("none");

                return;
            }
        }

        public void saveInvoke(IGetReport igp, string idCardNo, string no)
        {
            Thread.Sleep(300);
            Action<IGetReport, String, String> tt = new Action<IGetReport, String, String>(SaveTo);

            this.Dispatcher.BeginInvoke(tt, igp, idCardNo, no);
        }

        public delegate void MergeInvokeDelegate();

        public void MergeInvoke()
        {
            this.Dispatcher.BeginInvoke(new MergeInvokeDelegate(MergeDocument));
        }

        public void SaveTo(IGetReport igp, string idCardNo, string no)
        {
            if (igp != null)
            {
                igp.BaseModel = new RecordsBaseInfoBLL().GetModel(idCardNo);
                igp.CardID = idCardNo;

                if (igp.hasData())
                {
                    IsHaveReport = true;
                    setMsg("正在处理：" + igp.PrintName);
                    no = Convert.ToInt32(no).ToString("000000");
                    DrawItems.SaveReport("printtemp\\" + no + igp.PrintName.Replace(".xps", "") + idCardNo + ".xps", igp.getReport());
                }
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

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            else
            {
                if (val.Equals("test"))
                {
                    System.Windows.Forms.MessageBox.Show("汇出完成!", "提示",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

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
            string newFile = "printtemp\\xpsShow.xps";

            try
            {
                List<string> lsFileName = new List<string>();
                lsFileName.AddRange(Directory.GetFiles("printtemp"));

                if (lsFileName.Count == 0)
                {
                    IsHaveReport = false;
                    return;
                }

                lsFileName.Sort();

                for (int i = 0; i < IDCard.Count; i++)
                {
                    List<string> lstName = new List<string>();

                    foreach (var item in lsFileName)
                    {
                        if (item != "xpsShow.xps" && item.ToUpper().Contains(".XPS"))
                        {
                            string file = item.Split('.')[0].Substring(item.Split('.')[0].Length - 18, 18);

                            if (!string.IsNullOrEmpty(item) && IDCard[i].ToString().Contains(file))
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

                    setProcess(46);

                    //xps写入新文件
                    XpsDocument NewXpsDocument = new XpsDocument(newFile, System.IO.FileAccess.ReadWrite);
                    XpsDocumentWriter xpsDocumentWriter = XpsDocument.CreateXpsDocumentWriter(NewXpsDocument);
                    setProcess(47);
                    xpsDocumentWriter.Write(newFds);

                    NewXpsDocument.Close();

                    File.Copy(@"printtemp\xpsShow.xps", @"D:\汇出打印文件\" + date + "\\xpsShow" + i.ToString() + ".xps", true);

                    File.Delete(newFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
