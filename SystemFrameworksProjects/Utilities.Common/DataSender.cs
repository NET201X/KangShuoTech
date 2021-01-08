namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;

    public static class DataSender
    {
        public static string formalOrTest;
        public static string m_FtpIP = "";
        public static string m_FtpPass = "";
        public static string m_FtpUser = "";
        public static string SessionID = "";
        public static string UserID = "";
        public static string UserName = "";

        public static string CheckVersionVisiable(string ver)
        {
            string str;
            try
            {
                string str2 = HardDiskVal.HDVal(Directory.GetDirectoryRoot(ConfigHelper.GetNode("anyview")).Substring(0, 1));
                string requestUriString = string.Format(!(formalOrTest == "test") ? "" : "", ver, str2);
                str = new StreamReader(WebRequest.Create(requestUriString).GetResponse().GetResponseStream()).ReadToEnd();
                ErrorLog.WriterLog(str + " 版本适用性查询: " + requestUriString);
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                return "error";
            }
            return str;
        }

        public static bool DeownloadFile(string strFileName, string Province, string city, string district, string town, string village, string file)
        {
            FileStream stream;
            long length;
            if (System.IO.File.Exists(strFileName))
            {
                stream = System.IO.File.OpenWrite(strFileName);
                length = stream.Length;
                stream.Seek(length, SeekOrigin.Current);
            }
            else
            {
                stream = new FileStream(strFileName, FileMode.Create);
                length = 0L;
            }
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(string.Format("", new object[] { Province, city, district, town, village }));
                if (length > 0L)
                {
                    request.AddRange((int) length);
                }
                Stream responseStream = request.GetResponse().GetResponseStream();
                byte[] buffer = new byte[0x200];
                for (int i = responseStream.Read(buffer, 0, 0x200); i > 0; i = responseStream.Read(buffer, 0, 0x200))
                {
                    stream.Write(buffer, 0, i);
                }
                stream.Close();
                responseStream.Close();
                return true;
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                stream.Close();
                return false;
            }
        }

        public static string GetFtpServer(string versionID)
        {
            string str = "true";
            new DataSet();
            new DataTable();
            try
            {
                string requestUriString = "" + versionID;
                if (formalOrTest == "test")
                {
                    requestUriString = requestUriString.Replace("", "");
                }
                WebRequest request = WebRequest.Create(requestUriString);
                request.Timeout = 0x1388;
                Stream responseStream = request.GetResponse().GetResponseStream();
                DataSet set = new DataSet();
                set.ReadXml(responseStream);
                DataTable table = set.Tables[0];
                m_FtpIP = (string) table.Rows[0][1];
                m_FtpUser = (string) table.Rows[0][2];
                m_FtpPass = (string) table.Rows[0][3];
                return str;
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                return "false";
            }
        }

        public static void GetOrgAndAreaData()
        {
        }

        public static string GetServerInfo()
        {
            new DataSet();
            new DataTable();
            try
            {
                WebRequest request = WebRequest.Create("");
                request.Timeout = 0x1388;
                Stream responseStream = request.GetResponse().GetResponseStream();
                DataSet set = new DataSet();
                set.ReadXml(responseStream);
                return (string) set.Tables[0].Rows[0][0];
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                return "false";
            }
        }

        public static Hashtable LoginInfo(string data)
        {
            Hashtable hashtable = new Hashtable();
            XmlTextReader reader = new XmlTextReader(new StringReader(data)) {
                WhitespaceHandling = WhitespaceHandling.All
            };
            bool flag = false;
            string name = "";
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (((reader.Name == "UserId") || (reader.Name == "ReadingType")) || 
                        (((reader.Name == "ReadingValue1") || (reader.Name == "ReadingValue2")) || (reader.Name == "ReadingValue3")))
                    {
                        flag = true;
                        name = reader.Name;
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Text) || (reader.NodeType == XmlNodeType.CDATA))
                {
                    if (flag)
                    {
                        hashtable[name] = reader.Value;
                    }
                    flag = false;
                }
            }
            return hashtable;
        }

        public static string StringToUnicode(string srcText)
        {
            srcText = srcText + " ";
            string str = "";
            foreach (char ch in srcText.ToCharArray())
            {
                byte[] bytes = Encoding.Unicode.GetBytes(ch.ToString());
                string str2 = @"\u" + bytes[1].ToString("x2") + bytes[0].ToString("x2");
                str = str + str2;
            }
            return str;
        }

        public static string UnicodeToString(string srcText)
        {
            string str = "";
            string str2 = srcText;
            int num = srcText.Length / 6;
            for (int i = 0; i <= (num - 1); i++)
            {
                string str3 = str2.Substring(0, 6).Substring(2);
                str2 = str2.Substring(6);
                byte[] buffer2 = new byte[2];
                buffer2[1] = byte.Parse(int.Parse(str3.Substring(0, 2), NumberStyles.HexNumber).ToString());
                byte[] bytes = buffer2;
                bytes[0] = byte.Parse(int.Parse(str3.Substring(2, 2), NumberStyles.HexNumber).ToString());
                str = str + Encoding.Unicode.GetString(bytes);
            }
            return str;
        }
    }
}

