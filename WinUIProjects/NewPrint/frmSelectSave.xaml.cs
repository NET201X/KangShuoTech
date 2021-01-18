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
using KangShuoTech.Utilities.Common;

namespace NewPrint
{
    /// <summary>
    /// frmSelectSave.xaml 的交互逻辑
    /// </summary>
    public partial class frmSelectSave : Window
    {
        public frmSelectSave()
        {
            InitializeComponent();
        }

        public string CardID { get; set; }

        public string PrintType { get; set; }

        string area = ConfigHelper.GetSetNode("area");
        string community = ConfigHelper.GetSetNode("community");

        public bool IsHaveReport { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

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

            File.Delete("printtemp\\xpsShow.xps");
            
            string[] files = Directory.GetFiles("printTemp");
            for (int i = 0; i < files.Length; i++)
            {
                string path = files[i];
                File.Delete(path);
            }

            frmSelectSave.count = 0;
            IGetReport igp;
            IsHaveReport = false;
            int no = 1;

            string[] idCardsStrings = CardID.Split(';');
            string[] SelectName = PrintType.Split(';');

            foreach (string idCardNo in idCardsStrings)
            {
                foreach (string name in SelectName)
                {
                    try
                    {
                        switch (name)
                        {
                            case "封面":
                                if (area == "淄博")
                                {
                                    igp = new HealthReport();
                                }
                                else
                                {
                                    igp = new ArchiveCover();
                                }
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
                            case "老年人中医健康(随访)":
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
                            case "老年人自理能力(体检)":
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
                            case "心电打印":
                                string ecgType = DrawItems.GetECGConfig();

                                if (ecgType == "2")
                                {
                                    igp = new ElectroCardioGramcs();
                                    igp.CardID = idCardNo;
                                    if (!igp.hasData()) igp = null;
                                    else this.saveInvoke(igp, idCardNo, no.ToString());
                                }
                                break;
                            case "B超打印":
                                igp = new TypeBchao();
                                igp.CardID = idCardNo;
                                if (!igp.hasData()) igp = null;
                                else this.saveInvoke(igp, idCardNo, no.ToString());
                                break;
                            default:
                                igp = null;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                no++;
            }

            Thread.Sleep(1000);

            if(!IsHaveReport)
            {
                System.Windows.Forms.MessageBox.Show("无打印资料!","提示",
                    System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Asterisk,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1,System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

                CloseWin("test");

                return;
            }

            this.setMsg("开始生成合并文档");
            this.MergeInvoke();
            this.CloseWin("test");
        }

        public void saveInvoke(IGetReport igp, string idCardNo, string no)
        {
            try
            {
                Thread.Sleep(300);
                Action<IGetReport, String, String> tt = new Action<IGetReport, String, String>(SaveTo);
                IsHaveReport = true;

                this.Dispatcher.BeginInvoke(tt, igp, idCardNo, no);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public delegate void MergeInvokeDelegate();

        public void MergeInvoke()
        {
            this.Dispatcher.BeginInvoke(
            new MergeInvokeDelegate(MergeDocument)
            );
        }

        public void SaveTo(IGetReport igp, string idCardNo, string no)
        {
            igp.BaseModel = new RecordsBaseInfoBLL().GetModel(idCardNo);
            igp.CardID = idCardNo;

            if (igp.hasData())
            {
            setMsg("正在处理：" + igp.PrintName);
            DrawItems.SaveReport("printtemp\\" + no + igp.PrintName.Replace(".xps", "") + idCardNo + ".xps", igp.getReport());

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
            string newFile = "printtemp\\xpsShow.xps";

            List<string> lsFileName = new List<string>();

            lsFileName.AddRange(Directory.GetFiles("printtemp"));
            lsFileName.Sort();

            FixedDocumentSequence newFds = new FixedDocumentSequence();//创建一个新的文档结构

            foreach (var item in lsFileName)
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
