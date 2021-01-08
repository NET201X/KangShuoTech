using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Management;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Reflection;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;

    public class GlbTools
    {
        public static bool DatatableCompareModel<M>(M model, DataTable dt)
        {
            bool flag = true;
            BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance;
            foreach (PropertyInfo info in model.GetType().GetProperties(bindingAttr))
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["dbColumn"].ToString() == info.Name)
                    {
                        object obj2 = row["result"];
                        object obj3 = info.GetValue(model, null);
                        if ((obj3 != null) && (obj2 != null))
                        {
                            if (obj2.ToString() != obj3.ToString())
                            {
                                flag = false;
                            }
                        }
                        else if ((obj3 == null) && (obj2 != null))
                        {
                            if (!string.IsNullOrEmpty(obj2.ToString()))
                            {
                                flag = false;
                            }
                        }
                        else if ((obj3 != null) && (obj2 == null))
                        {
                            flag = false;
                        }
                    }
                }
            }
            return flag;
        }

        public static void DatatableFillModel<M>(M model, DataTable dt)
        {
            BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance;
            foreach (PropertyInfo info in model.GetType().GetProperties(bindingAttr))
            {
                foreach (DataRow row in dt.Rows)
                {
                    decimal num;
                    if ((row["dbColumn"].ToString() == info.Name) && decimal.TryParse(row["result"].ToString(), out num))
                    {
                        info.SetValue(model, new decimal?(num), null);
                    }
                }
            }
        }

        public static object DeepCopy(object mo)
        {
            MemoryStream serializationStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(serializationStream, mo);
            serializationStream.Position = 0L;
            return formatter.Deserialize(serializationStream);
        }

        public static DateTime? GetBirthdayFromIDCardNo(string idcard)
        {
            if (!string.IsNullOrEmpty(idcard))
            {
                string str;
                DateTime time;
                if (idcard.Length == 15)
                {
                    string str2 = idcard.Substring(6, 6);
                    int num = DateTime.Now.Year - 0x7d0;
                    str = (int.Parse(str2.Substring(0, 2)) <= num) ? ("20" + str2) : ("19" + str2);
                }
                else
                {
                    if (idcard.Length != 0x12)
                    {
                        return null;
                    }
                    str = idcard.Substring(6, 8);
                }
                if (DateTime.TryParse(str.Substring(0, 4) + "-" + str.Substring(4, 2) + "-" + str.Substring(6, 2), out time) && ((time > DateTime.MinValue) && (time < DateTime.MaxValue)))
                {
                    return new DateTime?(time);
                }
            }
            return null;
        }

        public static bool GetFtpServer(string versionID, out string ftp, out string user, out string pwd)
        {
            bool flag2;
            bool flag = true;
            new DataSet();
            new DataTable();
            try
            {
                WebRequest request = WebRequest.Create("" + versionID);
                request.Timeout = 5000;
                Stream responseStream = request.GetResponse().GetResponseStream();
                DataSet set = new DataSet();

                set.ReadXml(responseStream);

                DataTable table = set.Tables[0];

                ftp = (string)table.Rows[0][1];
                user = (string)table.Rows[0][2];
                pwd = (string)table.Rows[0][3];

                return flag;
            }
            catch (Exception exception)
            {
                ftp = "";
                user = "";
                pwd = "";
                flag2 = false;
                LogHelper.LogError(exception);
            }

            return flag2;
        }

        private static string GetGateWay()
        {
            string str = "";
            foreach (ManagementObject obj2 in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
            {
                if (Convert.ToBoolean(obj2["ipEnabled"]))
                {
                    obj2["Caption"].ToString();
                    string[] strArray = obj2["DefaultIPGateway"] as string[];
                    if (strArray != null)
                    {
                        str = strArray[0];
                    }
                }
            }
            return str;
        }

        public static string GetPrinterDeviceID()
        {
            string str = "";
            foreach (ManagementObject obj2 in new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity ").Get())
            {
                try
                {
                    if (obj2["Name"].ToString() == "USB Device Driver for POS/KangShuoTech Printers")
                    {
                        //using (PropertyDataCollection.PropertyDataEnumerator enumerator2 = obj2.Properties.GetEnumerator())
                        //{
                        //    while (enumerator2.MoveNext())
                        //    {
                        //        string name = enumerator2.Current.Name;
                        //        if (name.ToUpper() == "PNPDeviceID")
                        //        {
                        //            str = obj2[name].ToString();
                        //        }
                        //    }
                        //}
                    }
                }
                catch (Exception exception)
                {
                    LogHelper.LogError(exception);
                }
            }
            return str;
        }

        public static bool IsChanged(object a, object b, params string[] iitts)
        {
            BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance;
            PropertyInfo[] properties = a.GetType().GetProperties(bindingAttr);
            PropertyInfo[] infoArray2 = b.GetType().GetProperties(bindingAttr);
            foreach (PropertyInfo info in infoArray2)
            {
                Func<string, bool> predicate = null;
                PropertyInfo item = info;
                foreach (PropertyInfo info2 in properties)
                {
                    if ((item.Name == info2.Name) && item.PropertyType.Equals(info2.PropertyType))
                    {
                        if (predicate == null)
                        {
                            predicate = sj => sj == item.Name;
                        }
                        if (((IEnumerable<string>)iitts).Count<string>(predicate) > 0)
                        {
                            break;
                        }
                        object obj2 = item.GetValue(a, null);
                        object obj3 = info2.GetValue(b, null);
                        if ((obj2 != null) && (obj3 != null))
                        {
                            if (obj2.ToString() != obj3.ToString())
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if ((obj2 == null) && (obj3 != null))
                            {
                                return true;
                            }
                            if ((obj2 != null) && (obj3 == null))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static void M1_TO_M2<M1, M2>(M1 m1, M2 m2)
        {
            BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance;
            PropertyInfo[] properties = m1.GetType().GetProperties(bindingAttr);
            foreach (PropertyInfo info in m2.GetType().GetProperties(bindingAttr))
            {
                foreach (PropertyInfo info2 in properties)
                {
                    if ((info.Name == info2.Name) && info.PropertyType.Equals(info2.PropertyType))
                    {
                        if (info.Name != "ID")
                        {
                            info.SetValue(m2, info2.GetValue(m1, null), null);
                        }
                        break;
                    }
                }
            }
        }

        public static void ModelFillDatatabel<M>(M model, DataTable dt)
        {
            BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance;
            foreach (PropertyInfo info in model.GetType().GetProperties(bindingAttr))
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["dbColumn"].ToString() == info.Name)
                    {
                        object value = info.GetValue(model, null);

                        if (value == null || value.ToString() == "0")
                            row["result"] = null;
                        else
                            row["result"] = info.GetValue(model, null);
                    }
                }
            }
        }

        private static void UpdateEarlierDB()
        {
            string str7;
            string pValue = "";
            bool node = ConfigHelper.GetNode("ftpUpAddress", ref pValue);
            string str2 = "";
            bool flag2 = ConfigHelper.GetNode("ftpUser", ref str2);
            string ftpUserID = ConfigHelper.EncryptCode(str2, 1);
            string str4 = "";
            bool flag3 = ConfigHelper.GetNode("ftpPwd", ref str4);
            string ftpPassword = ConfigHelper.EncryptCode(str4, 1);
            Ping ping = new Ping();
            try
            {
                if (ping.Send("www.baidu.com").Status == IPStatus.Success)
                {
                    goto Label_010B;
                }
            }
            catch (Exception exception)
            {
                ErrorLog.WriterLog("ping 百度 失败!" + exception.Message);
                LogHelper.LogError(exception);
            }
            string gateWay = GetGateWay();
            if (string.IsNullOrWhiteSpace(gateWay))
            {
                ErrorLog.WriterLog("没有获取到有效的网关!");
                return;
            }
            if ((!node && !flag2) && !flag3)
            {
                ErrorLog.WriterLog("远程服务器地址不正确!");
                return;
            }
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                ErrorLog.WriterLog("无有效的网络连接!");
                return;
            }
            try
            {
                if (ping.Send(gateWay).Status != IPStatus.Success)
                {
                    ErrorLog.WriterLog("无法登录到远程服务器!");
                    return;
                }
            }
            catch (Exception exception2)
            {
                ErrorLog.WriterLog("登录到远程服务器错误!");
                LogHelper.LogError(exception2);
                return;
            }
            Label_010B:
            str7 = Environment.CurrentDirectory + @"\SQlite\QCDB.db";
            string str8 = str7.Substring(0, str7.LastIndexOf(@"\"));
            string str9 = AtapiDevice.GetHddInfo(0).SerialNumber.Trim();
            if (!Directory.Exists(str8 + @"\BackUp"))
            {
                Directory.CreateDirectory(str8 + @"\BackUp");
            }
            string str10 = "";
            ConfigHelper.GetNode("orgCode", ref str10);
            string str11 = string.Format("{0}_{1}_{2}_qcdb.db", str10, str9, DateTime.Now.ToString("yyyyMMddHHmmss"));
            string destFileName = string.Format(str8 + @"\BackUp\{0}", str11);
            System.IO.File.Copy(str7, destFileName);
            if (System.IO.File.Exists(str7))
            {
                try
                {
                    int num = FtpOper.UploadFtp(str7, pValue, ftpUserID, ftpPassword, null, str11);
                    GC.Collect();
                    ErrorLog.WriterLog("FtpOper.UploadFtp:" + str7 + " ftpAddr:" + pValue + " _fileName");
                    if (num == -2)
                    {
                        ErrorLog.WriterLog("网络不通，将无法完成数据同步!");
                    }
                    else
                    {
                        Thread.Sleep(0x3e8);
                        System.IO.File.Move(str7, str7 + ".bk");
                        ErrorLog.WriterLog("删除数据库!" + str7);
                    }
                }
                catch (Exception exception3)
                {
                    LogHelper.LogInfo(exception3);
                }
            }
        }
    }
}

