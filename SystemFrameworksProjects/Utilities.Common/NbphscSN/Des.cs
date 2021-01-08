namespace KangShuoTech.Utilities.Common.NbphscSN
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class Des
    {
        private static string byteArr2HexStr(byte[] arrB)
        {
            StringBuilder builder = new StringBuilder(arrB.Length * 2);
            for (int i = 0; i < 8; i++)
            {
                int num2 = arrB[i];
                while (num2 < 0)
                {
                    num2 -= 0x100;
                }
                if (num2 < 0x10)
                {
                    builder.Append("0");
                }
                builder.Append(Convert.ToString(num2, 0x10));
            }
            return builder.ToString();
        }

        public static bool Decode(string decryptString, string decryptKey, out string ret_code)
        {
            bool flag = true;
            decryptString = decryptString.ToLower().Replace("-", "");
            string str = "";
            ret_code = "";
            try
            {
                for (int i = 0; i < (decryptString.Length / 0x10); i++)
                {
                    string strIn = decryptString.Substring(i * 0x10, 0x10);
                    byte[] rgbKey = new byte[8];
                    byte[] bytes = Encoding.UTF8.GetBytes(decryptKey);
                    for (int j = 0; j < 8; j++)
                    {
                        rgbKey[j] = bytes[j];
                    }
                    byte[] buffer = hexStr2ByteArr(strIn);
                    DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                    MemoryStream stream = new MemoryStream();
                    CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, new byte[8]), CryptoStreamMode.Write);
                    stream2.Write(buffer, 0, buffer.Length);
                    stream2.FlushFinalBlock();
                    ret_code = str = str + Encoding.Default.GetString(stream.ToArray());
                }
            }
            catch (Exception exception)
            {
                ret_code = "Error:" + exception.Message;
                flag = false;
                LogHelper.LogError(exception);
            }
            return flag;
        }

        public static string Encryptor(string encryptorString, string decryptKey)
        {
            string str = "";
            for (int i = 0; i < encryptorString.Length; i++)
            {
                string s = encryptorString.Substring(i, 1);
                byte[] rgbKey = new byte[8];
                byte[] bytes = Encoding.Default.GetBytes(s);
                byte[] buffer3 = Encoding.Default.GetBytes(decryptKey);
                for (int k = 0; k < 8; k++)
                {
                    rgbKey[k] = buffer3[k];
                }
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(rgbKey, new byte[8]), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                stream.GetBuffer();
                str = str + byteArr2HexStr(stream.GetBuffer());
            }
            string str3 = "";
            for (int j = 0; j < str.Length; j++)
            {
                string str4 = str.Substring(j, 1);
                string str5 = "";
                if ((j < (str.Length - 1)) && (((j + 1) % 4) == 0))
                {
                    str5 = str5 + "-";
                }
                str3 = str3 + str4 + str5;
            }
            return str3.ToUpper();
        }

        private static byte[] hexStr2ByteArr(string strIn)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(strIn);
            int length = bytes.Length;
            byte[] buffer2 = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                int num3 = int.Parse(Encoding.UTF8.GetString(bytes, i, 2), NumberStyles.AllowHexSpecifier);
                buffer2[i / 2] = (byte) num3;
            }
            return buffer2;
        }
    }
}

