using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;

namespace CommomUtilities.Common
{
    public class ConfigHelper
    {
        public static string cfgFileName;
        public static string cfgMustChooseFileName;

        public static string GetNode(string pNode)
        {
            XmlDocument document = new XmlDocument();

            if (string.IsNullOrEmpty(cfgFileName))
            {
                cfgFileName = Environment.CurrentDirectory + @"\config.xml";
            }

            document.Load(cfgFileName);
            XmlNode node = document.SelectSingleNode("config/" + pNode);

            string str = (node == null) ? "" : node.InnerText;

            return str;
        }

        public static decimal GetNodeDec(string pNode, string path = "")
        {
            if (path == "") path = Environment.CurrentDirectory;

            XmlDocument document = new XmlDocument();

            if (string.IsNullOrEmpty(cfgFileName)) cfgFileName = path + @"\config.xml";

            document.Load(cfgFileName);

            XmlNode node = document.SelectSingleNode("config/" + pNode);

            string str = (node == null) ? "" : node.InnerText;

            if (string.IsNullOrEmpty(str)) return 0M;

            return decimal.Parse(str);
        }

        public static void Init()
        {
            cfgFileName = Environment.CurrentDirectory + @"\config.xml";
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

        public static string GetSetNode(string pNode, string path = "")
        {
            if (path == "") path = Environment.CurrentDirectory;

            string filename = path + @"\setting.xml";

            if (!File.Exists(filename)) return "";

            XmlDocument document = new XmlDocument();
            document.Load(filename);

            XmlNode node = document.SelectSingleNode("setting/" + pNode);

            string str = (node == null) ? "" : node.InnerText.Replace("\r", "").Replace("\n", "").Replace(" ", "");

            return str;
        }
    }
}