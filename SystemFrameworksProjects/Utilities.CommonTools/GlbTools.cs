namespace KangShuoTech.Utilities.CommonTools
{
    using System;
    using System.Data;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public class GlbTools
    {
        public static bool GetFtpServer(string versionID, out string ftp, out string user, out string pwd)
        {
            bool flag = true;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            try
            {
                WebRequest request = WebRequest.Create("" + versionID);
                request.Timeout = 0x1388;
                Stream responseStream = request.GetResponse().GetResponseStream();
                set = new DataSet();
                set.ReadXml(responseStream);
                table = set.Tables[0];
                ftp = (string) table.Rows[0][1];
                user = (string) table.Rows[0][2];
                pwd = (string) table.Rows[0][3];
                return flag;
            }
            catch (Exception)
            {
                ftp = "";
                user = "";
                pwd = "";
                flag = false;
            }
            return flag;
        }

        public static void M1_TO_M2<M1, M2>(M1 m1, M2 m2)
        {
            BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance;
            PropertyInfo[] properties = m1.GetType().GetProperties(bindingAttr);
            PropertyInfo[] infoArray2 = m2.GetType().GetProperties(bindingAttr);
            foreach (PropertyInfo info in infoArray2)
            {
                foreach (PropertyInfo info2 in properties)
                {
                    if ((info.Name == info2.Name) && info.PropertyType.Equals(info2.PropertyType))
                    {
                        info.SetValue(m2, info2.GetValue(m1, null), null);
                        break;
                    }
                }
            }
        }
    }
}

