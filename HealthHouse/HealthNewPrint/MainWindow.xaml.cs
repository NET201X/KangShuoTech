
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

using printClass;
using ReportPrint;
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.BLL;
using System.IO;

namespace HealthNewPrint
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
            else
            {
                switch (btnName)
                {
                    case "btnHousePhysical":
                        igp = new HousePhysical();
                        break;
                    case "btnTypeBUI":
                        igp = new TypeBchao();
                        igp.CardID = IDCard;
                        break;
                    case "btnECG":
                        string ecgType = DrawItems.GetECGConfig();

                        if (ecgType == "2")
                        {
                            igp = new ElectroCardioGramcs();
                            igp.CardID = IDCard;
                        }
                        else igp = null;
                        break;
                    case "btnTypeBone":
                        igp = new HouseBone();
                        break;
                    case "btnVascular":
                        igp = new HealthVascular();
                        break;
                    case "btnLung":
                        igp = new HealthLung();
                        break;
                    case "btnAssess":
                        igp = new HealthAssess();
                        break;
                    case "btnGuide":
                        igp = new HealthGuide();
                        break;
                    default:
                        igp = null;
                        break;
                }
                if (igp == null) return;
               
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
                        frm.DocName =path + igp.PrintName;
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
        public string PrintType { get; set; }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrawItems.DeleteDir("printTemp");
            if (string.IsNullOrEmpty(IDCard))
            {
                MessageBox.Show("打印输入的身份证号错误");
            }
            else
            {
                this.Title = "健康小屋打印报告";
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
                frm.Path = path;
                frm.ShowDialog();

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
    }
}
