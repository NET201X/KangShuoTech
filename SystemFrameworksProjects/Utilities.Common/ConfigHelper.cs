using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;

namespace KangShuoTech.Utilities.Common
{
    public class ConfigHelper
    {
        public static string cfgFileName;
        public static string cfgMustChooseFileName;
        private static Mutex myMutex = new Mutex();
        private static Mutex myMustChooseMutex = new Mutex();

        public static string EncryptCode(string str, int flag)
        {
            byte num4;
            byte[] buffer = new byte[] { 0x41, 0x72, 0x65, 0x79, 0x6f, 0x75, 0x6d, 0x79, 0x53, 110, 0x6f, 0x77, 0x6d, 0x61, 110, 0x3f };
            int length = str.Length;
            byte num2 = 15;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                num2 = (byte)(num2 ^ buffer[i]);
            }
            if (flag == 1)
            {
                num4 = num2;
            }
            else
            {
                num4 = (byte)(num2 ^ 15);
                num2 = num4;
            }
            for (int j = 0; (j < length) && (str[j] != '\0'); j++)
            {
                builder.Append((char)(str[j] ^ num2));
                if (num4 > 7)
                {
                    num2 = (byte)(num2 - 2);
                }
                else
                {
                    num2 = (byte)(num2 + 2);
                }
                if ((num2 < 0) || (num2 > 15))
                {
                    num2 = num4;
                }
            }
            return builder.ToString();
        }

        public static bool GetConfigBool(string key)
        {
            bool flag = false;
            string configString = GetConfigString(key);
            if ((configString != null) && (string.Empty != configString))
            {
                try
                {
                    flag = bool.Parse(configString);
                }
                catch (FormatException exception)
                {
                    LogHelper.LogError(exception);
                }
            }
            return flag;
        }

        public static decimal GetConfigDecimal(string key)
        {
            decimal num = new decimal(0);
            string configString = GetConfigString(key);
            if ((configString != null) && (string.Empty != configString))
            {
                try
                {
                    num = decimal.Parse(configString);
                }
                catch (FormatException exception)
                {
                    LogHelper.LogError(exception);
                }
            }
            return num;
        }

        public static int GetConfigInt(string key)
        {
            int num = 0;
            string configString = GetConfigString(key);
            if ((configString != null) && (string.Empty != configString))
            {
                try
                {
                    num = int.Parse(configString);
                }
                catch (FormatException exception)
                {
                    LogHelper.LogError(exception);
                }
            }
            return num;
        }

        public static string GetConfigString(string key)
        {
            string cacheKey = "AppSettings-" + key;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = ConfigurationManager.AppSettings[key];
                    if (cache != null)
                    {
                        DataCache.SetCache(cacheKey, cache, DateTime.Now.AddMinutes(180.0), TimeSpan.Zero);
                    }
                }
                catch (Exception exception)
                {
                    LogHelper.LogError(exception);
                }
            }
            return cache.ToString();
        }

        public static string GetNode(string pNode)
        {
            myMutex.WaitOne();
            XmlDocument document = new XmlDocument();
            if (string.IsNullOrEmpty(cfgFileName))
            {
                cfgFileName = Environment.CurrentDirectory + @"\config.xml";
            }
            document.Load(cfgFileName);
            XmlNode node = document.SelectSingleNode("config/" + pNode);
            string str = (node == null) ? "" : node.InnerText;
            myMutex.ReleaseMutex();
            return str;
        }
        public static string GetMustChooseNode(string pNode)
        {
            GetMustChooseXmlDoc();
            myMustChooseMutex.WaitOne();
            XmlDocument document = new XmlDocument();
            document.Load(cfgMustChooseFileName);
            XmlNode node = document.SelectSingleNode("config/" + pNode);
            string str = (node == null) ? "" : node.InnerText;
            myMustChooseMutex.ReleaseMutex();
            return str;
        }
        public static bool GetNode(string pNode, ref string pValue)
        {
            myMutex.WaitOne();
            bool flag = true;
            string filename = Environment.CurrentDirectory + @"\config.xml";
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode node = document.SelectSingleNode("config/" + pNode);
            pValue = (node == null) ? "" : node.InnerText;
            if (node == null)
            {
                flag = false;
            }
            else if (string.IsNullOrEmpty(pValue))
            {
                flag = false;
            }
            myMutex.ReleaseMutex();
            return flag;
        }

        public static decimal GetNodeDec(string pNode)
        {
            XmlDocument document = new XmlDocument();
            if (string.IsNullOrEmpty(cfgFileName))
            {
                cfgFileName = Environment.CurrentDirectory + @"\config.xml";
            }
            document.Load(cfgFileName);
            XmlNode node = document.SelectSingleNode("config/" + pNode);
            string str = (node == null) ? "" : node.InnerText;
            if (string.IsNullOrEmpty(str))
            {
                return 0M;
            }
            return decimal.Parse(str);
        }
        public static decimal GetMustChooseNodeDec(string pNode)
        {
            GetMustChooseXmlDoc();
            XmlDocument document = new XmlDocument();
            document.Load(cfgMustChooseFileName);
            XmlNode node = document.SelectSingleNode("config/" + pNode);
            string str = (node == null) ? "" : node.InnerText;
            if (string.IsNullOrEmpty(str))
            {
                return 0M;
            }
            return decimal.Parse(str);
        }

        public static XmlDocument GetXmlDoc()
        {
            myMutex.WaitOne();
            XmlDocument document = new XmlDocument();
            if (string.IsNullOrEmpty(cfgFileName))
            {
                cfgFileName = Environment.CurrentDirectory + @"\config.xml";
            }
            document.Load(cfgFileName);
            myMutex.ReleaseMutex();
            return document;
        }
        public static XmlDocument GetMustChooseXmlDoc()
        {
            myMustChooseMutex.WaitOne();
            XmlDocument document = new XmlDocument();
            cfgMustChooseFileName = Environment.CurrentDirectory + @"\MustChoose.xml";
            document.Load(cfgMustChooseFileName);
            myMustChooseMutex.ReleaseMutex();
            return document;
        }
        public static void Init()
        {
            cfgFileName = Environment.CurrentDirectory + @"\config.xml";
        }
        public static void MustChooseInit()
        {
            cfgMustChooseFileName = Environment.CurrentDirectory + @"\MustChoose.xml";
        }
        public static void WriteNode(string p_node, string p_value)
        {
            XmlDocument document = new XmlDocument();
            if (string.IsNullOrEmpty(cfgFileName))
            {
                cfgFileName = Environment.CurrentDirectory + @"\config.xml";
            }
            document.Load(cfgFileName);
            XmlNode node = document.SelectSingleNode("config");
            XmlNode newChild = node.SelectSingleNode(p_node);
            if (newChild == null)
            {
                newChild = document.CreateNode("element", p_node, "");
                node.AppendChild(newChild);
            }
            newChild.InnerText = p_value;
            document.Save(cfgFileName);
        }
        public static void WriteMustChooseNode(string p_node, string p_value)
        {
            GetMustChooseXmlDoc();
            XmlDocument document = new XmlDocument();
            document.Load(cfgMustChooseFileName);
            XmlNode node = document.SelectSingleNode("config");
            XmlNode newChild = node.SelectSingleNode(p_node);
            if (newChild == null)
            {
                newChild = document.CreateNode("element", p_node, "");
                node.AppendChild(newChild);
            }
            newChild.InnerText = p_value;
            document.Save(cfgMustChooseFileName);
        }

        public static string GetSetNode(string pNode)
        {
            string filename = Environment.CurrentDirectory + @"\setting.xml";

            if (!File.Exists(filename)) return "";

            XmlDocument document = new XmlDocument();
            document.Load(filename);

            XmlNode node = document.SelectSingleNode("setting/" + pNode);

            string str = (node == null) ? "" : node.InnerText;

            return str;
        }
    }
}

