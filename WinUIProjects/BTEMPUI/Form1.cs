using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.Utilities.CommunicationData;
using System.Threading;
using System.IO.Ports;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using KangShuoTech.CommomDataAccessProjects.CommonBLL;
using System.Configuration;
using CommomUtilities.Common;
using KangShuoTech.Utilities.CommonControl;

namespace BTEMPUI
{
    public partial class Form1 : Form
    {
        private ClsTransInfoUI clsTrans;
        private bool m_IsLogIn = true;
        private Guid g_bt;
        public static bool ComVisiable = false;
        private SerialPort port1 = new SerialPort();
        private SerialPort comm = new SerialPort();
        public static string idNo = "";
        public static int BU_FirstInsert;
        private RecordsBaseInfoModel baseInfo;
        string Type = ConfigurationManager.AppSettings["Type"] == null ? "EMP" : ConfigurationManager.AppSettings["Type"].ToString();    // 尿机类型

        public Form1(string idCardNo)
        {
            InitializeComponent();
            idNo = idCardNo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(-this.Width, -this.Height);
            this.ShowInTaskbar = false;
            this.Hide();

            baseInfo = new RecordsBaseInfoBLL().GetModel(idNo);

            ConfigHelper.cfgFileName = Environment.CurrentDirectory + @"\config.xml";

            //  新尿机
            if (Type.ToUpper().Equals("EMP_NEW"))
            {
                if (comm == null || !this.comm.IsOpen)
                {
                    comm = new SerialPort();

                    comm.PortName = ConfigurationManager.AppSettings["EMPUI"].ToString();
                    comm.BaudRate = 9600;

                    try
                    {
                        this.comm.Open();
                        this.comm.DataReceived += new SerialDataReceivedEventHandler(this.comm_DataReceived);

                        Thread.Sleep(200);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                this.clsTrans = new ClsTransInfoUI("BLUE");
                ClsTransInfoUI.ReadMode = true;
                this.clsTrans.SendMsg += new TransMessageHandle(this.clsTrans_SendMsgNt);
                this.clsTrans.InitListener();
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
                if (deviceinfo2.Add(devInfo) != 0)
                {
                    TranslateClsResult.set_tj_content(devInfo);
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
                    string str = !(ClsResult.DeviceName == "QCTBE") ? TranslateClsResult.TranslateToStr() : "(查看)";

                    ClsMsgWindow.SendDeviceInfo(ClsResult.DeviceName + ";BT");
                    base.Invoke(new Action<string, string>(this.run_notify_window), new object[] { TranslateClsResult.GetDeviceCName(ClsResult.DeviceName), str });

                    this.notify_save();
                    this.WriteComPort(string.Format("{0} successed", ClsResult.DeviceName.Substring(3, 2)));
                }
            }
        }
        
        #region 新尿机

        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(2000);

                int n = comm.BytesToRead;
                byte[] buf = new byte[n];

                while (buf.Length < 325)
                {
                    n = comm.BytesToRead;
                    buf = new byte[n];
                }

                comm.Read(buf, 0, n);

                string str = System.Text.Encoding.ASCII.GetString(buf);

                byte[] STX = new byte[] { 0x02 };   // 开始符
                byte[] EXT = new byte[] { 0x03 };   // 结束符
                string start = System.Text.Encoding.ASCII.GetString(STX);
                string end = System.Text.Encoding.ASCII.GetString(EXT);

                string[] value = str.Split(new String[] { end }, StringSplitOptions.RemoveEmptyEntries);

                DeviceInfoModel saveDeviceModel = new DeviceInfoModel
                {
                    IDCardNo = baseInfo.IDCardNo,
                    UpdateData = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };

                saveDeviceModel.DeviceName = "尿液信息";
                saveDeviceModel.DeviceType = "33";
                saveDeviceModel.FirstName = "EMPUI";

                for (int i = 0; i < value.Length; i++)
                {
                    string value2 = value[i].Replace(start, "");

                    string[] empValue = value2.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                    if (empValue.Length > 13)
                    {
                        saveDeviceModel.Value9 = empValue[4].Substring(5, 2).Replace(" ", "");  //  尿白细胞 LEU
                        saveDeviceModel.Value4 = empValue[5].Substring(5, 2).Replace(" ", "");           //  尿酮体 KET
                        saveDeviceModel.Value8 = empValue[6].Substring(5, 2).Replace(" ", "");          //  亚硝酸盐 NIT
                        saveDeviceModel.Value1 = empValue[7].Substring(5, 2).Replace(" ", "");         //  尿胆原 URO
                        saveDeviceModel.Value6 = empValue[8].Substring(5, 2).Replace(" ", "");      // 尿蛋白 PRO
                        saveDeviceModel.Value3 = empValue[9].Substring(5, 2).Replace(" ", "");           //  胆红素 BIL  
                        saveDeviceModel.Value5 = empValue[10].Substring(5, 2).Replace(" ", "");      // 尿糖 GLU
                        saveDeviceModel.Value10 = empValue[11].Substring(5).Replace(" ", "");              // 比重 SG
                        saveDeviceModel.Value2 = empValue[12].Substring(5, 2).Replace(" ", "");             // 尿潜血 BLD
                        saveDeviceModel.Value7 = empValue[13].Substring(5).Replace(" ", "");                  //  酸碱度 PH
                        saveDeviceModel.Value11 = empValue[14].Substring(5, 2).Replace(" ", "");          //  抗坏血酸 VC
                    }
                }

                if (saveDeviceModel.Value6 == "" || saveDeviceModel.Value5 == "")
                {
                    MessageBox.Show("测量错误，请重新测量！");
                    return;
                }

                string appInfo = string.Format("LEU:白细胞  {0}       BLD:尿潜血  {1}\nNIT:亚硝酸盐  {2}       KET:酮体  {3}\nUBG:尿胆原  {4}       BIL:胆红素  {5}\nPRO:蛋白质  {6}       GLU:葡萄糖  {7}\np H  {8}      V C:维生素C  {9}\nS G:尿比重  {10}\n              {11}"
                    , saveDeviceModel.Value9.PadLeft(2, ' ')
                    , saveDeviceModel.Value2.PadLeft(2, ' ')
                    , saveDeviceModel.Value8.PadLeft(2, ' ')
                    , saveDeviceModel.Value4.PadLeft(2, ' ')
                    , saveDeviceModel.Value1.PadLeft(2, ' ')
                    , saveDeviceModel.Value3.PadLeft(2, ' ')
                    , saveDeviceModel.Value6.PadLeft(2, ' ')
                    , saveDeviceModel.Value5.PadLeft(2, ' ')
                    , saveDeviceModel.Value7.PadLeft(2, ' ')
                    , saveDeviceModel.Value11.PadLeft(2, ' ')
                    , saveDeviceModel.Value10, "尚未保存"
                );

                ClsMsgWindow.SendDeviceInfo("EMPUI" + ";BT");
                base.Invoke(new Action<string, string>(this.run_notify_window), new object[] { TranslateClsResult.GetDeviceCName("EMPUI"), appInfo });

                DeviceInfoBLL deviceInfo = new DeviceInfoBLL();

                if (deviceInfo.Add(saveDeviceModel) != 0)
                {
                    TranslateClsResult.set_tj_content(saveDeviceModel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            StopRead();
        }

        public void StopRead()
        {
            try
            {
                if (this.comm != null)
                {
                    this.comm.DataReceived -= new SerialDataReceivedEventHandler(this.comm_DataReceived);

                    if (this.comm.IsOpen)
                    {
                        this.comm.Close();
                    }

                    this.comm.Dispose();
                    this.comm = null;
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion
    }
}
