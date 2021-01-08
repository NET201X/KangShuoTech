using KangShuoTech.Utilities.Common;

namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public class ClsMsgWindow
    {
        public const int MSG_BT_BH = 0x598;
        public const int MSG_CARD_CLOSE = 0x594;
        public const int MSG_CARD_INIT = 0x591;
        public const int MSG_CARD_INIT_FAIL = 0x596;
        public const int MSG_CARD_INIT_SUCCESS = 0x595;
        public const int MSG_CARD_READ = 0x592;
        public const int MSG_CARD_STOP = 0x593;
        public static readonly int WM_COPYDATA = 0x4a;

        [DllImport("User32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        public static string GetMsgStr(IntPtr lparam)
        {
            if (lparam != IntPtr.Zero)
            {
                return Marshal.PtrToStringUni(((CommonControl.COPYDATASTRUCT) Marshal.PtrToStructure(lparam, typeof(CommonControl.COPYDATASTRUCT))).lpData);
            }
            return null;
        }

        public static string GetMsgStr(Message m)
        {
            System.Type cls = new CommonControl.COPYDATASTRUCT().GetType();
            CommonControl.COPYDATASTRUCT lParam = (CommonControl.COPYDATASTRUCT) m.GetLParam(cls);
            int dwData = (int) lParam.dwData;
            byte[] destination = new byte[lParam.cbData];
            Marshal.Copy(lParam.lpData, destination, 0, destination.Length);
            return Encoding.Default.GetString(destination);
        }

        [DllImport("User32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, ref CommonControl.COPYDATASTRUCT lParam);
        [DllImport("User32.dll")]
        public static extern int PostMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        public static bool postMsgToWnd(string wnd, int msg)
        {
            if (wnd.Equals(string.Empty))
            {
                return false;
            }
            IntPtr hwnd = FindWindow(null, wnd);
            return (!(hwnd == IntPtr.Zero) && (PostMessage(hwnd, msg, IntPtr.Zero, IntPtr.Zero) == 0));
        }

        public static bool postMsgToWnd(string mdi, string child, int msg)
        {
            if (mdi.Equals(string.Empty))
            {
                return false;
            }
            IntPtr hwndParent = FindWindow(null, mdi);
            IntPtr zero = IntPtr.Zero;
            int num = 0;
            if (hwndParent == IntPtr.Zero)
            {
                return false;
            }
            IntPtr ptr3 = FindWindowEx(hwndParent, IntPtr.Zero, "MDIClient", null);
            if (ptr3 != IntPtr.Zero)
            {
                zero = FindWindowEx(ptr3, IntPtr.Zero, child, null);
            }
            if (zero != IntPtr.Zero)
            {
                num = PostMessage(hwndParent, msg, IntPtr.Zero, IntPtr.Zero);
            }
            return (num == 0);
        }

        public static bool PostString(string destWindow, uint flag, string str)
        {
            if (destWindow.Equals(string.Empty))
            {
                return false;
            }
            IntPtr hWnd = FindWindow(null, destWindow);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                CommonControl.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(str);
                copydatastruct.dwData = (IntPtr) flag;
                copydatastruct.cbData = bytes.Length;
                copydatastruct.lpData = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.lpData, bytes.Length);
                PostMessage(hWnd, WM_COPYDATA, (int) flag, ref copydatastruct);
                return true;
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                return false;
            }
        }

        public static bool SendDeviceInfo(string str)
        {
            string node = ConfigHelper.GetNode("archiveid");
            string str3 = ConfigHelper.GetNode("orgCode");
            string str4 = ConfigHelper.GetNode("doctor");
            str = str + ";" + node + ";" + str3 + ";" + str4;
            return SendString("", 1, str);
        }

        [DllImport("User32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref CommonControl.COPYDATASTRUCT lParam);
        public static bool SendString(string destWindow, uint flag, string str)
        {
            if (destWindow.Equals(string.Empty))
            {
                return false;
            }
            IntPtr hWnd = FindWindow(null, destWindow);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                CommonControl.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(str);
                copydatastruct.dwData = (IntPtr) flag;
                copydatastruct.cbData = bytes.Length;
                copydatastruct.lpData = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.lpData, bytes.Length);
                SendMessage(hWnd, WM_COPYDATA, (int) flag, ref copydatastruct);
                return true;
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                return false;
            }
        }

        public enum MSG_BT
        {
            BG = 0x599,
            BH = 0x598,
            BP = 0x597,
            BT = 0x59a,
            BU = 0x59b,
            BW = 0x59c,
            TF = 0x59d,
            UI = 0x59e,
            ZQ = 0x59f
        }
    }
}

