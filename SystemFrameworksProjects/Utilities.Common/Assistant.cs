namespace KangShuoTech.Utilities.Common
{
    using System;

    public sealed class Assistant
    {
        private string GetRandomCode(string allChar, int CodeCount)
        {
            string[] strArray = allChar.Split(new char[] { ',' });
            string str = "";
            int num = -1;
            Random random = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (num != -1)
                {
                    random = new Random((num * i) * ((int) DateTime.Now.Ticks));
                }
                int index = random.Next(strArray.Length - 1);
                while (num == index)
                {
                    index = random.Next(strArray.Length - 1);
                }
                num = index;
                str = str + strArray[index];
            }
            return str;
        }
    }
}

