namespace KangShuoTech.Utilities.Common
{
    using System;

    public class Rmb
    {
        public static string CmycurD(decimal num)
        {
            string str = "零壹贰叁肆伍陆柒捌玖";
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分";
            string str3 = "";
            string str4 = "";
            int num2 = 0;
            num = Math.Round(Math.Abs(num), 2);
            string str5 = (num * 100M).ToString();
            int length = str5.Length;
            if (length > 15)
            {
                return "溢出";
            }
            string str6 = str2.Substring(15 - length);
            for (int i = 0; i < length; i++)
            {
                string str8;
                string str7 = str5.Substring(i, 1);
                int startIndex = Convert.ToInt32(str7);
                if (((i != (length - 3)) && (i != (length - 7))) && ((i != (length - 11)) && (i != (length - 15))))
                {
                    if (str7 == "0")
                    {
                        str8 = "";
                        str4 = "";
                        num2++;
                    }
                    else if ((str7 != "0") && (num2 != 0))
                    {
                        str8 = "零" + str.Substring(startIndex, 1);
                        str4 = str6.Substring(i, 1);
                        num2 = 0;
                    }
                    else
                    {
                        str8 = str.Substring(startIndex, 1);
                        str4 = str6.Substring(i, 1);
                        num2 = 0;
                    }
                }
                else if ((str7 != "0") && (num2 != 0))
                {
                    str8 = "零" + str.Substring(startIndex, 1);
                    str4 = str6.Substring(i, 1);
                    num2 = 0;
                }
                else if ((str7 != "0") && (num2 == 0))
                {
                    str8 = str.Substring(startIndex, 1);
                    str4 = str6.Substring(i, 1);
                    num2 = 0;
                }
                else if ((str7 == "0") && (num2 >= 3))
                {
                    str8 = "";
                    str4 = "";
                    num2++;
                }
                else if (length >= 11)
                {
                    str8 = "";
                    num2++;
                }
                else
                {
                    str8 = "";
                    str4 = str6.Substring(i, 1);
                    num2++;
                }
                if ((i == (length - 11)) || (i == (length - 3)))
                {
                    str4 = str6.Substring(i, 1);
                }
                str3 = str3 + str8 + str4;
                if ((i == (length - 1)) && (str7 == "0"))
                {
                    str3 = str3 + '整';
                }
            }
            if (num == 0M)
            {
                str3 = "零元整";
            }
            return str3;
        }

        public static string CmycurD(string numstr)
        {
            try
            {
                return CmycurD(Convert.ToDecimal(numstr));
            }
            catch
            {
                return "非数字形式！";
            }
        }
    }
}

