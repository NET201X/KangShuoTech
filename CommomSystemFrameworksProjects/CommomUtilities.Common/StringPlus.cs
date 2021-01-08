namespace CommomUtilities.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StringPlus
    {
        public static string DelLastChar(string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }

        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }

        public static string GetArrayStr(List<string> list, string speater)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == (list.Count - 1))
                {
                    builder.Append(list[i]);
                }
                else
                {
                    builder.Append(list[i]);
                    builder.Append(speater);
                }
            }
            return builder.ToString();
        }

        public static string GetCleanStyle(string StrList, string SplitString)
        {
            if (StrList == null)
            {
                return "";
            }
            return StrList.Replace(SplitString, "");
        }

        public static string GetNewStyle(string StrList, string NewStyle, string SplitString, out string Error)
        {
            string str;
            if (StrList == null)
            {
                str = "";
                Error = "请输入需要划分格式的字符串";
                return str;
            }
            if (StrList.Length != GetCleanStyle(NewStyle, SplitString).Length)
            {
                str = "";
                Error = "样式格式的长度与输入的字符长度不符，请重新输入";
                return str;
            }
            string str2 = "";
            for (int i = 0; i < NewStyle.Length; i++)
            {
                if (NewStyle.Substring(i, 1) == SplitString)
                {
                    str2 = str2 + "," + i;
                }
            }
            if (str2 != "")
            {
                str2 = str2.Substring(1);
            }
            string str3 = str2;
            char[] separator = new char[] { ',' };
            foreach (string str4 in str3.Split(separator))
            {
                StrList = StrList.Insert(int.Parse(str4), SplitString);
            }
            str = StrList;
            Error = "";
            return str;
        }

        public static string[] GetStrArray(string str)
        {
            return str.Split(new char[0x2c]);
        }

        public static List<string> GetStrArray(string str, char speater, bool toLower)
        {
            List<string> list = new List<string>();
            string str2 = str;
            char[] separator = new char[] { speater };
            foreach (string str3 in str2.Split(separator))
            {
                if (!string.IsNullOrEmpty(str3) && (str3 != speater.ToString()))
                {
                    string item = str3;
                    if (toLower)
                    {
                        item = str3.ToLower();
                    }
                    list.Add(item);
                }
            }
            return list;
        }

        public static List<string> GetSubStringList(string o_str, char sepeater)
        {
            List<string> list = new List<string>();
            string str = o_str;
            char[] separator = new char[] { sepeater };
            foreach (string str2 in str.Split(separator))
            {
                if (!string.IsNullOrEmpty(str2) && (str2 != sepeater.ToString()))
                {
                    list.Add(str2);
                }
            }
            return list;
        }

        public static string ToDBC(string input)
        {
            char[] chArray = input.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == '　')
                {
                    chArray[i] = ' ';
                }
                else if ((chArray[i] > 0xff00) && (chArray[i] < 0xff5f))
                {
                    chArray[i] = (char)(chArray[i] - 0xfee0);
                }
            }
            return new string(chArray);
        }

        public static string ToSBC(string input)
        {
            char[] chArray = input.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == ' ')
                {
                    chArray[i] = '　';
                }
                else if (chArray[i] < '\x007f')
                {
                    chArray[i] = (char)(chArray[i] + 0xfee0);
                }
            }
            return new string(chArray);
        }

        /// <summary>
        /// 字串Null转换为空白
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string toString(object value)
        {
            if (value == null) return "";
            else return value.ToString();
        }

        /// <summary>
        /// 取得性别
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public static string GetSex(string sex)
        {
            if (sex != null)
            {
                switch (sex)
                {
                    case "0": sex = "未知"; break;
                    case "1": sex = "男"; break;
                    case "2": sex = "女"; break;
                    case "9": sex = "未说明"; break;
                    default: break;
                }
            }

            return sex;
        }

        /// <summary>
        /// 取得职业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public static string GetJob(string job)
        {
            if (job != null)
            {
                switch (job)
                {
                    case "1": job = "国家机关、党群组织、企业、事业单位负责人"; break;
                    case "2": job = "专业技术人员"; break;
                    case "3": job = "办事人员和有关人"; break;
                    case "4": job = "商业、服务人员"; break;
                    case "5": job = "农、林、牧、渔、水利生产人员"; break;
                    case "6": job = "生产运输设备操作人员及有关人员"; break;
                    case "7": job = "军人"; break;
                    case "8": job = "不便分类的其他从业人员"; break;
                    default: break;
                }
            }

            return job;
        }

        /// <summary>
        /// 取得血型
        /// </summary>
        /// <param name="bloodType"></param>
        /// <returns></returns>
        public static string GetBloodType(string bloodType)
        {
            if (bloodType != null)
            {
                switch (bloodType)
                {
                    case "1": bloodType = "A型"; break;
                    case "2": bloodType = "B型"; break;
                    case "3": bloodType = "O型"; break;
                    case "4": bloodType = "AB型"; break;
                    case "5": bloodType = "不祥"; break;
                    default: break;
                }
            }

            return bloodType;
        }

        /// <summary>
        /// 格式化数字字串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="i">小数位</param>
        /// <param name="isZero">空白时是否返回0</param>
        /// <returns></returns>
        public static string ObjToNumStr(object obj, int i, bool isZero = false)
        {
            string value = "";

            if (isZero && toString(obj) == "") value = "0";
            else if (toString(obj) == "" || toString(obj) == "0") value = "";
            else if (IsNum(toString(obj)))
            {
                value = Convert.ToDecimal(obj).ToString("#0." + "".PadRight(i, '0'));
            }

            return value;
        }

        /// <summary>
        /// 判断是数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNum(string value)
        {
            return Regex.IsMatch(value, @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$");
        }

        /// <summary>
        /// 心电
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EcgRes(string str)
        {
            string res = "";

            if (!string.IsNullOrEmpty(str)) res += str;

            return res;
        }

        /// <summary>
        /// 尿常规
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string NiaoRes(string str)
        {
            string res = "";

            switch (str)
            {
                case "Normal":
                    res = "-";
                    break;
                case "Neg":
                    res = "-";
                    break;
                case "Trace":
                    res = "+-";
                    break;
                default:
                    res = str;
                    break;
            }

            return res;
        }

        /// <summary>
        /// 转换15位身份证号码为18位
        /// </summary>
        /// <param name="oldIDCard">15位的身份证</param>
        /// <returns>返回18位的身份证</returns>
        public static string IDCard15To18(string oldIDCard)
        {
            int iS = 0;

            //加权因子常数
            int[] iW = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };

            //校验码常数
            string LastCode = "10X98765432";

            //新身份证号
            string newIDCard;

            newIDCard = oldIDCard.Substring(0, 6);

            //填在第6位及第7位上填上‘1’，‘9’两个数字
            newIDCard += "19";

            newIDCard += oldIDCard.Substring(6, 9);

            //进行加权求和
            for (int i = 0; i < 17; i++)
            {
                iS += int.Parse(newIDCard.Substring(i, 1)) * iW[i];
            }

            //取模运算，得到模值
            int iY = iS % 11;

            //从LastCode中取得以模为索引号的值，加到身份证的最后一位，即为新身份证号。
            newIDCard += LastCode.Substring(iY, 1);
            return newIDCard;
        }
    }
}