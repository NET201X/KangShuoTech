namespace KangShuoTech.Utilities.CommonTools
{
    using System;
    using System.Xml;

    public class ConfigHelper
    {
        public static string GetNode(string pNode)
        {
            string filename = Environment.CurrentDirectory + @"\config.xml";
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode node = document.SelectSingleNode("config/" + pNode);
            return ((node == null) ? "" : node.InnerText);
        }

        public static bool GetNode(string pNode, ref string pValue)
        {
            bool flag = true;
            string filename = Environment.CurrentDirectory + @"\config.xml";
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode node = document.SelectSingleNode("config/" + pNode);
            pValue = (node == null) ? "" : node.InnerText;
            if (node == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(pValue))
            {
                flag = false;
            }
            return flag;
        }

        public static decimal GetNodeDec(string pNode)
        {
            string filename = Environment.CurrentDirectory + @"\config.xml";
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode node = document.SelectSingleNode("config/" + pNode);
            string str2 = (node == null) ? "" : node.InnerText;
            if (string.IsNullOrEmpty(str2))
            {
                return 0M;
            }
            return decimal.Parse(str2);
        }

        public static void WriteNode(string p_node, string p_value)
        {
            string filename = Environment.CurrentDirectory + @"\config.xml";
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode node = document.SelectSingleNode("config");
            XmlNode newChild = node.SelectSingleNode(p_node);
            if (newChild == null)
            {
                newChild = document.CreateNode("element", p_node, "");
            }
            newChild.InnerText = p_value;
            node.AppendChild(newChild);
            document.Save(filename);
        }
    }
}

