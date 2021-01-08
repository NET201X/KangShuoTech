namespace KangShuoTech.Utilities.Common
{
    public class ConvertDBCAndSBC
    {
        public string DBCToSBC(string input)
        {
            char[] chArray = input.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == ' ')
                {
                    chArray[i] = '　';
                }
                else if ((chArray[i] < '\x007f') && (chArray[i] > ' '))
                {
                    chArray[i] = (char) (chArray[i] + 0xfee0);
                }
            }
            return new string(chArray);
        }

        public string SBCToDBC(string input)
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
                    chArray[i] = (char) (chArray[i] - 0xfee0);
                }
            }
            return new string(chArray);
        }

        /// <summary>
        /// 字串Null转换为空白
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string toString(object value)
        {
            if (value == null) return "";
            else return value.ToString();
        }
    }
}

