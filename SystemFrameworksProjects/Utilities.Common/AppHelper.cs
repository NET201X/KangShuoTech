namespace KangShuoTech.Utilities.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AppHelper
    {
        public static string EncryptCode(string str, int flag)
        {
            byte num4;
            byte[] buffer = new byte[] { 0x41, 0x72, 0x65, 0x79, 0x6f, 0x75, 0x6d, 0x79, 0x53, 110, 0x6f, 0x77, 0x6d, 0x61, 110, 0x3f };
            int length = str.Length;
            byte num2 = 15;
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < buffer.Length; i++)
            {
                num2 = (byte) (num2 ^ buffer[i]);
            }
            if (flag == 1)
            {
                num4 = num2;
            }
            else
            {
                num4 = (byte) (num2 ^ 15);
                num2 = num4;
            }
            for (int j = 0; (j < length) && (str[j] != '\0'); j++)
            {
                builder.Append((char) (str[j] ^ num2));
                if (num4 > 7)
                {
                    num2 = (byte) (num2 - 2);
                }
                else
                {
                    num2 = (byte) (num2 + 2);
                }
                if ((num2 < 0) || (num2 > 15))
                {
                    num2 = num4;
                }
            }
            return builder.ToString();
        }

        public static string EncryptCode(string str, string keys, int flag)
        {
            byte num4;
            LinkedList<char> source = new LinkedList<char>((IEnumerable<char>) str.ToCharArray());
            LinkedListNode<char> first = new LinkedList<char>((IEnumerable<char>) keys.ToCharArray()).First;
            LinkedListNode<char> node = source.First;
            while ((first != null) && (node != null))
            {
                source.AddBefore(node, first.Value);
                first = first.Next;
                node = node.Next;
                if (node != null)
                {
                    node = node.Next;
                }
            }
            str = new string(source.ToArray<char>());
            byte[] bytes = Encoding.Default.GetBytes(keys);
            int length = str.Length;
            byte num2 = 15;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                num2 = (byte) (num2 ^ bytes[i]);
            }
            if (flag == 1)
            {
                num4 = num2;
            }
            else
            {
                num4 = (byte) (num2 ^ 15);
                num2 = num4;
            }
            for (int j = 0; (j < length) && (str[j] != '\0'); j++)
            {
                builder.Append((char) (str[j] ^ num2));
                if (num4 > 7)
                {
                    num2 = (byte) (num2 - 2);
                }
                else
                {
                    num2 = (byte) (num2 + 2);
                }
                if ((num2 < 0) || (num2 > 15))
                {
                    num2 = num4;
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
                    int num2 = chArray[i] - '\x0001';
                    chArray[i] = (char) num2;
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
                    int num2 = chArray[i] + '\x0001';
                    chArray[i] = (char) num2;
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

