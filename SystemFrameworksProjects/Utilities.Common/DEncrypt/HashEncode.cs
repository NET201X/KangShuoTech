namespace KangShuoTech.Utilities.Common.DEncrypt
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class HashEncode
    {
        public static string GetRandomValue()
        {
            return new Random().Next(1, 0x7fffffff).ToString();
        }

        public static string GetSecurity()
        {
            return HashEncoding(GetRandomValue());
        }

        public static string HashEncoding(string Security)
        {
            byte[] buffer = new SHA512Managed().ComputeHash(new UnicodeEncoding().GetBytes(Security));
            Security = "";
            foreach (byte num in buffer)
            {
                Security = Security + ((int) num) + "O";
            }
            return Security;
        }
    }
}

