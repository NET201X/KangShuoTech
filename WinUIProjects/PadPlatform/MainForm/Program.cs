using System.Windows.Forms;

namespace PadPlatform
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.IO;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            if (File.Exists(Application.StartupPath + "\\Register.exe"))
            {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                psi.UseShellExecute = false;
                psi.FileName = "Register.exe";
                psi.Arguments = "Register";
                Process process = System.Diagnostics.Process.Start(psi);

                StreamReader outputStreamReader = process.StandardOutput;
                StreamReader errStreamReader = process.StandardError;

                process.WaitForExit();

                if (process.HasExited)
                {
                    string output = outputStreamReader.ReadToEnd();
                    string error = errStreamReader.ReadToEnd();

                    if (output != "" || error != "")
                    {
                        MessageBox.Show("注册失败！请重新注册！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }

                File.Delete(Application.StartupPath + "\\Register.exe");
            }

            ProgramStart.Start();
        }
    }
}