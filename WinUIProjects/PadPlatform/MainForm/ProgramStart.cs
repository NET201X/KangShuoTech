using System.Windows.Forms;
using KangShuoTech.Utilities.Common;

namespace KangShuo
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.IO;

    internal static class ProgramStart
    {
        private const int WS_SHOWNORMAL = 1;

        public static void HandleRunningInstance(Process instance)
        {
            try
            {
                ShowWindowAsync(instance.MainWindowHandle, 1);
                SetForegroundWindow(instance.MainWindowHandle);
                LogHelper.LogInfo("instance.MainWindowHandle 放到前端");
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
            }
        }

        [STAThread]
        public static void Start()
        {
            LogHelper.LogInfo("Release version");
            try
            {
                Application.ThreadException += (sender, e) => LogHelper.LogError(e.Exception);
                AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs e)
                {
                    LogHelper.LogInfo("未捕获的异常");
                    LogHelper.LogInfo(e);
                };
            }
            catch (Exception exception)
            {
                LogHelper.LogInfo("标准异常");
                LogHelper.LogError(exception);
                new ShowErrorMessageForm { exp = exception, StartPosition = FormStartPosition.CenterScreen, ecInfo = exception.ToString() }.ShowDialog();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process instance = RunningInstance();
            if (instance == null)
            {
                string str;
                LogHelper.InitLog();
                ConfigHelper.Init();
                bool flag = true;
                if (CheckRegister.GetRegisterCodeFromConfig(out str))
                {
                    PadForm.orgid = str;

                    // 取得注册信息
                    string regValue = "";

                    string softDirectory = "C:\\Windows\\KangShuo\\client.key";

                    if (File.Exists(softDirectory))
                    {
                        StreamReader sr = new StreamReader(softDirectory);

                        regValue = sr.ReadLine();

                        sr.Close();
                    }

                    // 根据CPU、硬盘、主板信息生成注册码
                    string deviceId = CheckRegister.GetDeviceId();

                    // 判断注册信息是否一致
                    if (!regValue.Equals(deviceId))
                    {
                        MessageBox.Show("错误的注册码！请重新注册！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                SystemDetectionForm diagnostics = new SystemDetectionForm();
                if (diagnostics.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                PadForm form2 = new PadForm
                {
                    readCard = diagnostics.ck
                };
                using (PadForm form = form2)
                {
                    form.FormClosed += (sender, e) => Environment.Exit(0);
                    Application.Run(form);
                    return;
                }
            }
            HandleRunningInstance(instance);
        }

        public static Process RunningInstance()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] processesByName = Process.GetProcessesByName(currentProcess.ProcessName);
            LogHelper.LogInfo(string.Concat(new object[] { "获取进程数", currentProcess.ProcessName, ":", processesByName.Length }));
            foreach (Process process2 in processesByName)
            {
                if ((process2.Id != currentProcess.Id) && (Assembly.GetExecutingAssembly().Location.Replace("/", @"\") == currentProcess.MainModule.FileName))
                {
                    LogHelper.LogInfo("获取到进程：" + process2.Id);
                    return process2;
                }
            }
            return null;
        }

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
    }
}

