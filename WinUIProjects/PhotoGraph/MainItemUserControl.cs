
using CommomUtilities.Common;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;
using System;
using System.Configuration;
using System.Reflection;
using System.Windows.Forms;

namespace PhotoGraph
{
    public partial class MainItemUserControl : UserControl
    {
        // 取得屏幕分辨率的宽高
        private int SH = Screen.PrimaryScreen.Bounds.Height;
        private int SW = Screen.PrimaryScreen.Bounds.Width;

        private string PhotosPath = ConfigurationManager.AppSettings["PhotosPath"] == null ? @"D:\QCSoft\photos\" :
            ConfigurationManager.AppSettings["PhotosPath"].ToString();

        public string IDCardNo { get; set; }

        public MainItemUserControl()
        {
            InitializeComponent();
            ConfigHelper.Init();
        }

        private void pictureBoxPrint_Click(object sender, EventArgs e)
        {
           // this.IDCardNo = "370101199211111111";

            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }

            Assembly sampleAssembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + @"\" + "PhotoGraph.exe");

            if (sampleAssembly != null)
            {
                Form loadForm = (Form)sampleAssembly.CreateInstance("PhotoGraph.FrmCamera");

                PropertyInfo[] properties = loadForm.GetType().GetProperties();

                properties[0].SetValue(loadForm, IDCardNo, null);
                properties[1].SetValue(loadForm, PhotosPath, null);

                loadForm.ShowDialog();
            }
        }

        private void pictureBoxQuery_Click(object sender, EventArgs e)
        {
            using (Controler controler = new Controler(new MDIParentForm(this.IDCardNo), new PhotoGraph.QueryInfoFactory()))
            {
                controler.IParentFrm.IShowDialog();
            }

            GC.Collect();
        }
    }
}