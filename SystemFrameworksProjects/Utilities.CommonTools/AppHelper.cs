using System.Text;

namespace KangShuoTech.Utilities.CommonTools
{
    public class AppHelper
    {
        public static string EncryptCode(string str, int flag)
        {
            int num;
            byte num4;
            byte[] buffer = new byte[] { 0x41, 0x72, 0x65, 0x79, 0x6f, 0x75, 0x6d, 0x79, 0x53, 110, 0x6f, 0x77, 0x6d, 0x61, 110, 0x3f };
            int length = str.Length;
            byte num3 = 15;
            StringBuilder builder = new StringBuilder();
            for (num = 0; num < buffer.Length; num++)
            {
                num3 = (byte) (num3 ^ buffer[num]);
            }
            if (flag == 1)
            {
                num4 = num3;
            }
            else
            {
                num4 = (byte) (num3 ^ 15);
                num3 = num4;
            }
            for (num = 0; num < length; num++)
            {
                if (str[num] == '\0')
                {
                    break;
                }
                builder.Append((char) (str[num] ^ num3));
                if (num4 > 7)
                {
                    num3 = (byte) (num3 - 2);
                }
                else
                {
                    num3 = (byte) (num3 + 2);
                }
                if ((num3 < 0) || (num3 > 15))
                {
                    num3 = num4;
                }
            }
            return builder.ToString();
        }

        public static string ShiftDecrypt(string Input)
        {
            try
            {
                string str = "";
                char[] chArray = Input.ToCharArray();
                for (int i = 0; i < chArray.Length; i++)
                {
                    int num = chArray[i] - '\x0001';
                    chArray[i] = (char) num;
                    str = str + chArray[i];
                }
                return str;
            }
            catch
            {
                return Input.ToString();
            }
        }

        public static string ShiftEncrypt(string Input)
        {
            try
            {
                string str = "";
                char[] chArray = Input.ToCharArray();
                for (int i = 0; i < chArray.Length; i++)
                {
                    int num = chArray[i] + '\x0001';
                    chArray[i] = (char) num;
                    str = str + chArray[i];
                }
                return str;
            }
            catch
            {
                return Input.ToString();
            }
        }
    }
}

