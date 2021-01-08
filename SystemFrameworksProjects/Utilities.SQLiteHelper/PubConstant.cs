namespace KangShuoTech.Utilities.SQLiteHelper
{
    using System;
    using System.Configuration;

    public class PubConstant
    {
        public static string GetConnectionString(string configName)
        {
            string text = ConfigurationManager.AppSettings[configName];
            if (ConfigurationManager.AppSettings["ConStringEncrypt"] == "true")
            {
                text = DESEncrypt.Decrypt(text);
            }
            return text;
        }

        public static string ConnectionString
        {
            get
            {
                string text = ConfigurationManager.AppSettings["ConnectionString"];
                if (ConfigurationManager.AppSettings["ConStringEncrypt"] == "true")
                {
                    text = DESEncrypt.Decrypt(text);
                }
                return text;
            }
        }
    }
}

