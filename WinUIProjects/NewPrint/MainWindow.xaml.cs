
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

using printClass;
using ReportPrint;
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.BLL;
using System.IO;

namespace NewPrint
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConfigHelper.Init();
        }

        string community = ConfigHelper.GetSetNode("community");
        string area = ConfigHelper.GetSetNode("area");

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Button btnShow = (Button)sender;
            string btnName = btnShow.Name;
            IGetReport igp;
            string path = "printtemp\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\\";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string[] idCardStrings = IDCard.Split(';');

            if (idCardStrings.Length > 1)
            {
                try
                {
                    frmShowBatch frm = new frmShowBatch();
                    frm.CardID = IDCard;
                    frm.PrintType = btnName;
                    frm.Path = path;
                    frm.ShowDialog();
                    if (!frm.IsHaveReport) return;

                    frmPrint frmShow = new frmPrint();
                    frmShow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    frmShow.WindowState = WindowState.Maximized;
                    frmShow.DocName = path + "xpsShow.xps";
                    frmShow.ShowDialog();
                }
                catch (Exception d)
                {
                    MessageBox.Show(d.ToString());
                }
         
            }
            else
            {
                switch (btnName)
                {
                    case "btnFengmian":
                        if (area == "淄博")
                        {
                            igp = new HealthReport();
                        }
                        else
                        {
                            igp = new ArchiveCover();
                        }
                        break;
                    case "btnBaseInfo":
                        igp = new ArchiveBase();
                        break;
                    case "btnHyper":
                        igp = new Hypertension_Followup();
                        break;
                    case "btnDiabetes":
                        igp = new Diabetes_Followup();
                        break;
                    case "btnMentaldisease_Baseinfo":
                        igp = new Mentaldisease_Baseinfo();
                        break;
                    case "btnMentalFollow":
                        igp = new Mentaldisease_Followup();
                        break;
                    case "btnPhysical":
                        igp = new ArchivePhysical();
                        break;
                    case "btnArchiveCard":
                        igp = new ArchiveCard();
                        break;
                    case "btnChildInOne":
                        igp = new Child_With_ONE();
                        break;
                    case "btnChildNEW":
                        igp = new Child_With_NEW();
                        break;
                    case "btnChildTWO":
                        igp = new Child_With_TWO();
                        break;
                    case "btnChildTHREE":
                        igp = new Child_With_THREE();
                        break;

                    case "btnGRAVIDA_FRIST":
                        igp = new GRAVIDA_FRIST();
                        break;

                    case "btnGRAVIDA_TWO":
                        igp = new GRAVIDA_TWO();
                        break;

                    case "btnGRAVIDA_POST":
                        igp = new GRAVIDA_Postpartum();
                        break;
                    case "btnGRAVIDA_POST42":
                        igp = new GRAVIDA_Postpartum42();
                        break;

                    case "btnOLDMEDICINECN":
                        igp = new Old_Medicine_CN();
                        break;
                    case "btnChildCNOne":
                        igp = new Child_CN_ONE();
                        break;
                    case "btnChildCNOne2Three":
                        igp = new Child_CN_TWO();
                        break;
                    //case "btnChildCNThree2Six":
                    //    igp = new Child_CN_THREE();
                    //    break;
                    case "btnChd":
                        igp = new CHD_Follow();
                        break;
                    case "btStroke":
                        igp = new Stroke_Followup();
                        break;
                    case "btnOnePTBVisit":
                        igp = new LungerFirstVisit();
                        break;
                    case "btnPTBVisit":
                        igp = new ChronicLungerVisit();
                        break;
                    case "btnHealth":
                        igp = new HealthEducation();
                       //igp = new HealthExamination();
                        break;
                    case "btnMReceiveTreat":
                        igp = new Medical_Receive();
                        break;
                    case "btnMConsulation":
                        igp = new Medical_Consulation();
                        break;
                    case "btnMReferral":
                        igp = new Medical_Refferral();
                        break;
                    case "btnHealthFeedback":
                        igp = new HealthFeedback();
                        break;
                    case "btnPhyOLDSelf":
                        igp = new Physical_OldSelfCare();
                        break;
                    //case "btnPhyMedicine":
                    //    igp = new Physical_MedicineCN();
                    //    break;
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
                        break;
                    case "btnCoverCard":
                        igp = new HealthCoverCard();
                        break;
                    case "btnBloodUrine":
                        igp = new Blood_Urine();
                        break;
                    case"btnCoverCard_2":
                        igp = new HealthCoverCard_Colour();
                        break;
                    case "btnECG":
                        string ecgType = DrawItems.GetECGConfig();

                        if (ecgType == "2")
                        {
                            igp = new ElectroCardioGramcs();
                            igp.CardID = IDCard;

                            if (!igp.hasData()) igp = null;
                        }
                        else igp = null;
                        break;
                    case "btnTypeBUI":
                        igp = new TypeBchao();
                        igp.CardID = IDCard;

                        if (!igp.hasData()) igp = null;
                        break;
                    case "btnPhyicalRe":
                        igp = new PhyicalReport();
                        break;
                    case "btnOldCover":
                        igp = new OldHealthReport();
                        break;
                    default:
                        igp = null;
                        break;
                }

                if (igp == null)
                {
                    MessageBox.Show("无打印资料！");
                    return;
                }

                igp.CardID = IDCard;
                igp.BaseModel = new RecordsBaseInfoBLL().GetModel(IDCard);

                if (igp.BaseModel == null)
                {
                    MessageBox.Show("无此人个人档案，身份证号：" + IDCard);
                    return;
                }

                try
                {
                    frmPrint frm = new frmPrint();
                    FixedDocumentSequence fsq = igp.getReport();

                    if (!DrawItems.SaveReport(path + igp.PrintName, fsq))
                    {
                        MessageBox.Show("打印文件正在被占用，请稍后重试");
                    }
                    else
                    {
                        frm.DocName = path + igp.PrintName;
                        frm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        frm.WindowState = WindowState.Maximized;
                        frm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        public string IDCard { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrawItems.DeleteDir("printTemp");
            if (string.IsNullOrEmpty(IDCard))
            {
                MessageBox.Show("打印输入的身份证号错误");
            }
            else
            {
                this.Title = "居民健康档案打印";
            }
           // this.Topmost = true;                   
        }
                                                                                
        private void btn_PrintAll(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = "printtemp\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\\";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                frmShowSave frm = new frmShowSave();
                frm.CardID = IDCard;
                frm.IsPrintBlood = true;
                frm.Path = path;
                frm.ShowDialog();
                if (!frm.IsHaveReport) return;

                frmPrint frmShow = new frmPrint();
                frmShow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                frmShow.WindowState = WindowState.Maximized;
                frmShow.DocName = path+"xpsShow.xps";
                frmShow.ShowDialog();
            }
            catch (Exception d)
            {
                MessageBox.Show(d.ToString());
            }         
        }

        /// <summary>
        /// 一键列印不含化验单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_PrintAllNo(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = "printtemp\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\\";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                frmShowSave frm = new frmShowSave();
                frm.CardID = IDCard;
                frm.Path = path;
                frm.IsPrintBlood = false;
                frm.ShowDialog();

                frmPrint frmShow = new frmPrint();
                frmShow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                frmShow.WindowState = WindowState.Maximized;
                frmShow.DocName = path + "xpsShow.xps";
                frmShow.ShowDialog();
            }
            catch (Exception d)
            {
                MessageBox.Show(d.ToString());
            }
        }
    }
}
