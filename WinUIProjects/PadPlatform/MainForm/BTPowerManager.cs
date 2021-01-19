using KangShuoTech.Utilities.Common;

namespace KangShuo
{
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.Management;
    using System.Text;

    public class BTPowerManager
    {
        private static void ChangePowerManage(string keynames)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Enum\" + keynames + @"\Device Parameters", true);
                bool flag = false;
                bool flag2 = false;
                bool flag3 = false;
                bool flag4 = false;
                if (key != null)
                {
                    foreach (string str in key.GetValueNames())
                    {
                        if (str.ToUpper() == "SELECTIVESUSPENDENABLED")
                        {
                            key.SetValue(str, 0);
                            flag = true;
                        }
                        if (str.ToUpper() == "ENABLESELECTIVESUSPEND")
                        {
                            key.SetValue(str, 0);
                            flag2 = true;
                        }
                    }
                    if (!flag)
                    {
                        key.CreateSubKey("SelectiveSuspendEnabled");
                        key.SetValue("SelectiveSuspendEnabled", 0);
                    }
                    if (!flag2)
                    {
                        key.CreateSubKey("EnableSelectiveSuspend");
                        key.SetValue("EnableSelectiveSuspend", 0);
                    }
                }
                RegistryKey key2 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\" + keynames + @"\Device Parameters", true);
                if (key2 != null)
                {
                    foreach (string str2 in key2.GetValueNames())
                    {
                        if (str2.ToUpper() == "SELECTIVESUSPENDENABLED")
                        {
                            flag3 = true;
                            key2.SetValue(str2, 0);
                        }
                        if (str2.ToUpper() == "ENABLESELECTIVESUSPEND")
                        {
                            flag4 = true;
                            key2.SetValue(str2, 0);
                        }
                    }
                    if (!flag3)
                    {
                        key2.CreateSubKey("SelectiveSuspendEnabled");
                        key2.SetValue("SelectiveSuspendEnabled", 0);
                    }
                    if (!flag4)
                    {
                        key2.CreateSubKey("EnableSelectiveSuspend");
                        key2.SetValue("EnableSelectiveSuspend", 0);
                    }
                }
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
            }
        }

        public static string GetOs()
        {
            Version version = Environment.OSVersion.Version;
            if ((version.Major == 5) && (version.Minor == 1))
            {
                return "XP";
            }
            if ((version.Major == 6) && (version.Minor == 0))
            {
                return "VISTA";
            }
            if ((version.Major == 6) && (version.Minor == 1))
            {
                return "WIN7";
            }
            if ((version.Major == 5) && (version.Minor == 0))
            {
                return "WIN2000";
            }
            return "NONE";
        }

        public static object GetPowerStatus()
        {
            object status = null;
            string keynames = "";
            StringBuilder sbDevHst = new StringBuilder();
            List<string> portsList = new List<string>();

            System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");

            foreach (System.Management.ManagementObject mgt in searcher.Get())
            {
                try
                {
                    string Devicename = mgt["Name"].ToString();
                    if (Devicename == "Generic Bluetooth Radio")
                    {
                        foreach (PropertyData property in mgt.Properties)
                        {
                            string Propernames = property.Name;
                            if (Propernames.ToUpper() == "DEVICEID")
                            {
                                keynames = mgt[Propernames].ToString();
                                goto FindPowerManger;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    ClsToolTip.WriteLog("Common 类" + ex.Message);
                }
            }

        FindPowerManger:
            if (/*GetOs() == "WIN7" &&*/ !string.IsNullOrEmpty(keynames))
            {
                try
                {
                    Microsoft.Win32.RegistryKey registrykey;
                    ////////////////////////////////////
                    registrykey = Registry.LocalMachine;
                    registrykey = registrykey.OpenSubKey("SYSTEM\\ControlSet001\\Enum\\" + keynames + "\\Device Parameters", true);
                    if (registrykey != null)
                    {
                        string[] keys = new string[1024];
                        keys = registrykey.GetValueNames();
                        foreach (string key in keys)
                        {
                            if (key.ToUpper() == "SELECTIVESUSPENDENABLED")
                            {
                                //registrykey.SetValue(key, (object)0);
                                status = registrykey.GetValue(key);
                            }
                        }
                    }
                    ////////////////////////////////////
                    registrykey = Registry.LocalMachine;
                    registrykey = registrykey.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\" + keynames + "\\Device Parameters", true);
                    if (registrykey != null)
                    {
                        string[] keys = new string[1024];
                        keys = registrykey.GetValueNames();
                        foreach (string key in keys)
                        {
                            if (key.ToUpper() == "SELECTIVESUSPENDENABLED")
                            {
                                //registrykey.SetValue(key, (object)0);
                                status = registrykey.GetValue(key);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ClsToolTip.WriteLog("更改电源设置错误:" + ex.Message);
                }

            }

            return status;
        }

        public static void SetPowerState()
        {
            //修改连接请求
            Microsoft.Win32.RegistryKey registrykey;
            registrykey = Registry.CurrentUser;
            registrykey = registrykey.OpenSubKey("Software\\Microsoft\\BluetoothAuthenticationAgent", true);
            if (registrykey != null)
            {
                string[] keys = new string[1024];
                keys = registrykey.GetValueNames();
                foreach (string key in keys)
                {
                    if (key.ToUpper() == "ACCEPTINCOMINGREQUESTS")
                    {
                        registrykey.SetValue(key, (object)0);
                    }
                }
            }
            else
            {
                registrykey = Registry.CurrentUser;
                registrykey = registrykey.OpenSubKey("Software\\Microsoft", true);
                if (registrykey != null)
                {
                    registrykey = registrykey.CreateSubKey("BluetoothAuthenticationAgent", RegistryKeyPermissionCheck.ReadWriteSubTree);
                    if (registrykey != null)
                    {
                        registrykey.SetValue("AcceptIncomingRequests", (object)0);
                    }
                }

            }
            if (GetOs() != "WIN7")
            {
                //return;
            }
            StringBuilder sbDevHst = new StringBuilder();
            List<string> portsList = new List<string>();

            System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");

            foreach (System.Management.ManagementObject mgt in searcher.Get())
            {
                try
                {
                    string Devicename = mgt["Name"].ToString();
                    if (Devicename == "Generic Bluetooth Radio")
                    {
                        foreach (PropertyData property in mgt.Properties)
                        {
                            string Propernames = property.Name;
                            if (Propernames.ToUpper() == "DEVICEID")
                            {
                                ChangePowerManage(mgt[Propernames].ToString());
                            }
                        }
                    }
                    if (Devicename == "Generic USB Hub")
                    {
                        foreach (PropertyData property in mgt.Properties)
                        {
                            string Propernames = property.Name;
                            if (Propernames.ToUpper() == "DEVICEID")
                            {
                                ChangePowerManage(mgt[Propernames].ToString());
                            }
                        }
                    }
                    if (Devicename == "USB Root Hub")
                    {
                        foreach (PropertyData property in mgt.Properties)
                        {
                            string Propernames = property.Name;
                            if (Propernames.ToUpper() == "DEVICEID")
                            {
                                ChangePowerManage(mgt[Propernames].ToString());
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    ClsToolTip.WriteLog("Common 类" + ex.Message);
                }
            }

        }
    }
}

