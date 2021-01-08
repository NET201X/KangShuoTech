namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.Globalization;

    public class TimeParser
    {
        public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string str = null;
            try
            {
                TimeSpan span = (TimeSpan)(DateTime2 - DateTime1);
                str = (span.Days < 1) ? ((span.Hours <= 1) ? (span.Minutes.ToString() + "分钟前") : (span.Hours.ToString() + "小时前")) : (DateTime1.Month.ToString() + "月" + DateTime1.Day.ToString() + "日");
            }
            catch
            {
            }
            return str;
        }

        public static int GetMonthLastDate(int year, int month)
        {
            DateTime time = new DateTime(year, month, new GregorianCalendar().GetDaysInMonth(year, month));
            return time.Day;
        }

        public static int SecondToMinute(int Second)
        {
            return Convert.ToInt32(Math.Ceiling((decimal)(Second / 60M)));
        }

        /// <summary>
        /// 把数字转换为大写
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string NumToUpper(int num)
        {
            String str = num.ToString();
            string rstr = "";
            int n;

            for (int i = 0; i < str.Length; i++)
            {
                n = Convert.ToInt16(str[i].ToString());//char转数字,转换为字符串，再转数字

                switch (n)
                {
                    case 0: rstr = rstr + "〇"; break;
                    case 1: rstr = rstr + "一"; break;
                    case 2: rstr = rstr + "二"; break;
                    case 3: rstr = rstr + "三"; break;
                    case 4: rstr = rstr + "四"; break;
                    case 5: rstr = rstr + "五"; break;
                    case 6: rstr = rstr + "六"; break;
                    case 7: rstr = rstr + "七"; break;
                    case 8: rstr = rstr + "八"; break;
                    default: rstr = rstr + "九"; break;
                }
            }

            return rstr;
        }

        /// <summary>
        /// 月转化为大写
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public string MonthToUpper(int month)
        {
            if (month < 10)
            {
                return NumToUpper(month);
            }
            else
                if (month == 10) { return "十"; }

            else
            {
                return "十" + NumToUpper(month - 10);
            }
        }

        /// <summary>
        /// 日转化为大写
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public string DayToUpper(int day)
        {
            if (day < 20)
            {
                return MonthToUpper(day);
            }
            else
            {
                String str = day.ToString();
                if (str[1] == '0')
                {
                    return NumToUpper(Convert.ToInt16(str[0].ToString())) + "十";
                }
                else
                {
                    return NumToUpper(Convert.ToInt16(str[0].ToString())) + "十"
                        + NumToUpper(Convert.ToInt16(str[1].ToString()));
                }
            }
        }

        /// <summary>
        /// 日期转换为大写
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string DateToUpper(System.DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            return NumToUpper(year) + "年" + MonthToUpper(month) + "月" + DayToUpper(day) + "日";
        }

        /// <summary>
        /// 根据年计算年龄
        /// </summary>
        /// <param name="Birthday"></param>
        /// <returns></returns>
        public string GetAge(object Birthday)
        {
            //decimal dNow = 0, dAge = 0;
            //string strAge = "0";

            //if (Birthday != null)
            //{
            //    dNow = Convert.ToDecimal(DateTime.Today.ToString("yyyyMMdd"));
            //    dAge = Convert.ToDecimal(Convert.ToDateTime(Birthday).ToString("yyyyMMdd"));
            //    strAge = Convert.ToString(dNow - dAge).ToString();

            //    switch (strAge.Length)
            //    {
            //        case 1:
            //        case 2:
            //        case 3:
            //        case 4: strAge = "0"; break;
            //        case 5: strAge = strAge.Substring(0, 1); break;
            //        case 6: strAge = strAge.Substring(0, 2); break;
            //        case 7: strAge = strAge.Substring(0, 3); break;
            //        default: break;
            //    }
            //}
            int dNow = 0, dAge = 0;
            string strAge = "0";

            if (Birthday != null)
            {
                dNow = DateTime.Today.Year;
                dAge = Convert.ToInt32(Convert.ToString(Birthday).Substring(0, 4));
                strAge = Convert.ToString(dNow - dAge);
            }

            return strAge;
        }

        /// <summary>
        /// 根据生日年计算年龄
        /// </summary>
        /// <param name="Birthday"></param>
        /// <returns></returns>
        public string GetYearAge(object Birthday)
        {
            int dNow = 0, dAge = 0;
            string strAge = "0";

            if (Birthday != null)
            {
                dNow = DateTime.Today.Year;
                dAge = Convert.ToInt32(Convert.ToString(Birthday).Substring(0, 4));
                strAge = Convert.ToString(dNow - dAge);
            }

            return strAge;
        }

        /// <summary>
        /// 日期格式转换
        /// </summary>
        /// <param name="dateValue"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static string StrToDate(object dateValue, int flag)
        {
            if (dateValue == null || dateValue is DBNull)
            {
                return "";
            }

            string result;
            DateTime dt = Convert.ToDateTime(dateValue);

            try
            {
                if (flag == 1)
                {
                    result = dt.ToString("yyyy年MM月dd日");
                }
                else if (flag == 2)
                {
                    result = dt.ToString("yyyy-MM-dd");
                }
                else if (flag == 3)
                {
                    result = dt.ToString("yyyy年MM月");
                }
                else if (flag == 4)
                {
                    result = dt.ToString("MM月dd日");
                }
                else if (flag == 5)
                {
                    result = dt.ToString("yyyyMMdd");
                }
                else
                {
                    result = dt.ToString("yyyy-MM-dd");
                }
            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }
		
        /// <summary>
        /// 比较value1 与Vaule2的大小
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="Vaule2"></param>
        /// <returns>若value1大于Vaule2，返回H；若value1小于Vaule2，返回L；若value1等于Vaule2，返回E</returns>
        public string CompareValue(object value1, object Vaule2)
        {
            if (value1 == null || Vaule2 == null || value1.ToString() == "" || Vaule2.ToString() == "") return " ";

            if (Convert.ToDouble(value1) > Convert.ToDouble(Vaule2)) return "H";
            else if (Convert.ToDouble(value1) == Convert.ToDouble(Vaule2)) return "E";
            else return "L";
        }
    }
}

