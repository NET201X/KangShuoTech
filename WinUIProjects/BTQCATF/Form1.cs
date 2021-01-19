using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.Utilities.CommunicationData;
using System.Threading;
using System.IO.Ports;
using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using KangShuoTech.CommomDataAccessProjects.CommonBLL;
using KangShuoTech.Utilities.CommonControl;

namespace BTQCATF
{
    public partial class Form1 : Form
    {
        private ClsTransInfoTF clsTrans;
        private bool m_IsLogIn = true;
        private Guid g_bt;
        public static bool ComVisiable = false;
        private SerialPort port1 = new SerialPort();
        public static string idNo = "";
        public static int BU_FirstInsert;
        private RecordsBaseInfoModel baseInfo;

        public Form1(string idCardNo)
        {
            InitializeComponent();
            idNo = idCardNo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.Location = new Point(-this.Width, -this.Height);
                this.ShowInTaskbar = false;
                this.Hide();

                baseInfo = new RecordsBaseInfoBLL().GetModel(idNo);
                
                ConfigHelper.cfgFileName = Environment.CurrentDirectory + @"\config.xml";            

                this.clsTrans = new ClsTransInfoTF("BLUE");
                ClsTransInfoTF.ReadMode = true;
                this.clsTrans.SendMsg += new TransMessageHandle(this.clsTrans_SendMsgNt);
                this.clsTrans.InitListener();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }

        private void run_notify_window(string tile, string content)
        {
            NotifyWindow window = new NotifyWindow(tile, content);
            window.SetDimensions(300, 200);
            window.Notify();
        }

        private void WriteComPort(string str)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(":" + str + "?");
            try
            {
                if (ComVisiable && this.port1.IsOpen)
                {
                    this.port1.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                throw;
            }
        }

        private void notify_save()
        {
            DeviceInfoModel devInfo = new DeviceInfoModel
            {
                IDCardNo = idNo
            };

            devInfo.UpdateData = DateTime.Now.ToString();
            bool flag = TranslateClsResult.TranslateToModel(devInfo, this.baseInfo);
            DeviceInfoBLL deviceinfo2 = new DeviceInfoBLL();

            if (!flag)
            {
                try
                {
                    if (deviceinfo2.Add(devInfo) != 0)
                    {
                        TranslateClsResult.set_tj_content(devInfo);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        private void clsTrans_SendMsgNt(string msg)
        {
            if (!this.m_IsLogIn)
            {
                if (msg.Contains("TRANSEND") || (msg == "ERROR"))
                {
                    new MessageForm("非会员用户测量数据无效") { StartPosition = FormStartPosition.CenterScreen }.ShowDialog();
                    Thread.Sleep(500);
                }
            }
            else
            {
                bool flag1 = msg == "UNKNOWN";
                if (msg.Contains("CONNECT"))
                {
                    this.g_bt = Guid.NewGuid();
                    this.WriteComPort(string.Format("{0} reading", msg.Substring(msg.Length - 2, 2)));
                }
                if (msg == "ERROR")
                {
                    base.Invoke(new Action<string, string>(this.run_notify_window), new object[] { ClsResult.DeviceName, "接收数据失败!" });
                }
                if ((msg == "TRANSEND") && ClsResult.ResultFlag)
                {
                    try
                    {
                        string str = !(ClsResult.DeviceName == "QCTBE") ? TranslateClsResult.TranslateToStr() : "(查看)";

                        //LogHelper.WriteLog(str);

                        ClsMsgWindow.SendDeviceInfo(ClsResult.DeviceName + ";BT");

                        base.Invoke(new Action<string, string>(this.run_notify_window), new object[] { TranslateClsResult.GetDeviceCName(ClsResult.DeviceName), str });
                        this.notify_save();
                        this.WriteComPort(string.Format("{0} successed", ClsResult.DeviceName.Substring(3, 2)));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
        }
    }
}
