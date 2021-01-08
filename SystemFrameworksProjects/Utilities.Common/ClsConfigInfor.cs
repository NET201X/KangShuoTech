namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml;

    public class ClsConfigInfor
    {
        public List<string> Device_id_list;
        public string idCardType = "";
        public string idcardUrl = "";
        public bool m_IdCard;
        public string m_PassWord;
        public bool m_Promiscuous;
        public string m_TimeZone;
        public string m_title = "健康管理";
        public string m_UserName;
        public string m_version;
        public string m_versionID = "2";
        public string qmjkdnUrl = "";
        public string upUrl = "";

        public ClsConfigInfor()
        {
            this.LoadConfigFile();
        }

        private string Decrypt(string cipherText, string Password)
        {
            byte[] cipherData = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 110, 0x20, 0x4d, 0x65, 100, 0x76, 0x65, 100, 0x65, 0x76 });
            return Encoding.Unicode.GetString(this.Decrypt(cipherData, bytes.GetBytes(0x20), bytes.GetBytes(0x10)));
        }

        private byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream stream = new MemoryStream();
            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = Key;
            rijndael.IV = IV;
            CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(cipherData, 0, cipherData.Length);
            stream2.Close();
            return stream.ToArray();
        }

        public bool GetNode(string pNode, ref string pValue)
        {
            bool flag = true;
            string filename = Path.GetDirectoryName(Assembly.GetAssembly(base.GetType()).CodeBase) + @"\config.xml";
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

        private void LoadConfigFile()
        {
            string filename = Path.GetDirectoryName(Assembly.GetAssembly(base.GetType()).CodeBase) + @"\config.xml";
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            this.m_UserName = document.SelectSingleNode("config/webservices").Attributes.GetNamedItem("username").Value;
            this.m_PassWord = this.Decrypt(document.SelectSingleNode("config/webservices").Attributes.GetNamedItem("password").Value, "scott");
            this.m_TimeZone = document.SelectSingleNode("config/timezone").Attributes.GetNamedItem("id").Value;
            this.idCardType = document.SelectSingleNode("config/IdCardType").InnerText;
            this.qmjkdnUrl = document.SelectSingleNode("config/qmjkdaUrl").InnerText;
            this.upUrl = document.SelectSingleNode("config/upUrl").InnerText;
            this.idcardUrl = document.SelectSingleNode("config/idcardUrl").InnerText;
            this.m_IdCard = !(this.m_IdCard = document.SelectSingleNode("config/IdCard") == null) && (document.SelectSingleNode("config/IdCard").InnerText == "True");
            this.m_Promiscuous = (document.SelectSingleNode("config/promiscuous") != null) && (document.SelectSingleNode("config/promiscuous").InnerText == "True");
            this.m_title = (document.SelectSingleNode("config/title") != null) ? document.SelectSingleNode("config/title").InnerText : "健康管理";
            this.m_versionID = (document.SelectSingleNode("config/versionID") != null) ? document.SelectSingleNode("config/versionID").InnerText : "2";
            if (!this.m_Promiscuous)
            {
                this.Device_id_list = new List<string>();
                XmlNodeList list = document.SelectNodes("config/device");
                for (int i = 0; i < list.Count; i++)
                {
                    this.Device_id_list.Add(list[i].Attributes.GetNamedItem("id").Value.Replace("-", ""));
                }
            }
        }

        public void WriteNode(string p_node, string p_value)
        {
            string filename = Environment.CurrentDirectory + @"\config.xml";
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode node = document.SelectSingleNode("config");
            XmlNode newChild = node.SelectSingleNode(p_node) ?? document.CreateNode("element", p_node, "");
            newChild.InnerText = p_value;
            node.AppendChild(newChild);
            document.Save(filename);
        }
    }
}

