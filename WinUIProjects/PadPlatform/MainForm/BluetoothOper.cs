using KangShuoTech.Utilities.Common;

namespace KangShuo
{
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.ServiceProcess;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Timers;
    using System.Windows.Forms;

    public class BluetoothOper
    {
        private static BluetoothOper _instance;
        private const int BLUETOOTH_KEEP_TIMES = 60;
        private List<string> btfiles = new List<string>();
        public BluePeiduiStatus currentStatus = BluePeiduiStatus.Close;
        private int n_minute = 60;
        private Process p_bt;
        private System.Timers.Timer t_end_bt;
        public Action<string> WhatsUp;

        public BluetoothOper()
        {
            object powerStatus = BTPowerManager.GetPowerStatus();
            if (powerStatus != null)
            {
                if (powerStatus.ToString() == "0")
                {
                    LogHelper.LogInfo("节电模式关闭\r\n");
                }
                else
                {
                    LogHelper.LogInfo("节电模式开启\r\n");
                    BTPowerManager.SetPowerState();
                    LogHelper.LogInfo("关闭节电模式，重启电脑生效!\r\n");
                }
            }
            else
            {
                BTPowerManager.SetPowerState();
                LogHelper.LogInfo("******关闭节电模式，重启生效!\r\n");
            }
            Action action1 = new Action(this.SetBthService);
            if (Directory.Exists(Application.StartupPath + @"\authInfo"))
            {
                string[] files = Directory.GetFiles(Application.StartupPath + @"\authInfo");
                this.btfiles.AddRange((IEnumerable<string>) files);
                foreach (string str in files)
                {
                    Match match = new Regex(@"CHIT\D{2}|CHIT\D{3}").Match(str);
                    if (match != null)
                    {
                        string text1 = match.Value;
                    }
                    LogHelper.LogInfo("配对蓝牙设备:" + str);
                }
            }
            else
            {
                Directory.CreateDirectory(Application.StartupPath + @"\authInfo");
            }
            this.t_end_bt = new System.Timers.Timer(60000.0);
            this.t_end_bt.Elapsed += new ElapsedEventHandler(this.t_end_bt_Elapsed);
            this.t_end_bt.Enabled = false;
        }

        public void Close()
        {
            if ((this.currentStatus == BluePeiduiStatus.Open) && (this.p_bt != null))
            {
                LogHelper.LogInfo("关闭蓝牙配对程式");
                if (this.WhatsUp != null)
                {
                    this.WhatsUp("蓝牙配对(已结束)");
                }
                this.p_bt.Kill();
                this.t_end_bt.Stop();
                this.currentStatus = BluePeiduiStatus.Close;
            }
        }

        public static BluetoothOper CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new BluetoothOper();
            }
            return _instance;
        }

        private void SetBthService()
        {
            string name = @"SYSTEM\CurrentControlSet\Services\BthServ";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(name, true);
            int result = -1;
            if (int.TryParse(key.GetValue("Start").ToString(), out result) && (result != 2))
            {
                key.SetValue("Start", 2);
            }
            ServiceController controller = new ServiceController("Bluetooth Support Service");
            if (controller.Status == ServiceControllerStatus.Stopped)
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(5000.0);
                LogHelper.LogInfo("启动蓝牙服务.....");
                controller.Start();
                controller.WaitForStatus(ServiceControllerStatus.Running, timeout);
                Thread.Sleep(500);
            }
        }

        public void Start()
        {
            this.p_bt = new Process();
            bool flag = false;
            if (BTPowerManager.GetOs() == "WIN7")
            {
                if (File.Exists(Application.StartupPath + @"\BlueAuthTool7.exe"))
                {
                    this.p_bt.StartInfo.FileName = Application.StartupPath + @"\BlueAuthTool7.exe";
                    flag = true;
                }
            }
            else if (File.Exists(Application.StartupPath + @"\BlueAuthTool.exe"))
            {
                this.p_bt.StartInfo.FileName = Application.StartupPath + @"\BlueAuthTool.exe";
                flag = true;
            }
            if (flag)
            {
                if (this.p_bt.Start())
                {
                    this.currentStatus = BluePeiduiStatus.Open;
                    this.n_minute = 60;
                    this.t_end_bt.Start();
                    LogHelper.LogInfo("开启配对!\r\n");
                    LogHelper.LogInfo("蓝牙配对.....");
                }
                else
                {
                    this.currentStatus = BluePeiduiStatus.Error;
                }
            }
            else
            {
                this.currentStatus = BluePeiduiStatus.Error;
                LogHelper.LogInfo("未找到蓝牙配对程式!\r\n");
                LogHelper.LogInfo("未找到蓝牙配对程式.....");
            }
        }

        private void t_end_bt_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.n_minute == 0)
            {
                this.t_end_bt.Stop();
                if (this.WhatsUp != null)
                {
                    this.WhatsUp("蓝牙配对(已结束)");
                }
            }
            else
            {
                this.n_minute--;
                if (this.WhatsUp != null)
                {
                    this.WhatsUp("蓝牙配对(已打开" + this.n_minute + ")");
                }
            }
        }
    }
}

