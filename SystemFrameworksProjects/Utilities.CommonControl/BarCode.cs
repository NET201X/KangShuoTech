namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class BarCode
    {
        public class Code128
        {
            private DataTable m_Code128 = new DataTable();
            private uint m_Height = 40;
            private byte m_Magnify;
            private Font m_ValueFont;

            public Code128()
            {
                this.m_Code128.Columns.Add("ID");
                this.m_Code128.Columns.Add("Code128A");
                this.m_Code128.Columns.Add("Code128B");
                this.m_Code128.Columns.Add("Code128C");
                this.m_Code128.Columns.Add("BandCode");
                this.m_Code128.CaseSensitive = true;
                this.m_Code128.Rows.Add(new object[] { "0", " ", " ", "00", "212222" });
                this.m_Code128.Rows.Add(new object[] { "1", "!", "!", "01", "222122" });
                this.m_Code128.Rows.Add(new object[] { "2", "\"", "\"", "02", "222221" });
                this.m_Code128.Rows.Add(new object[] { "3", "#", "#", "03", "121223" });
                this.m_Code128.Rows.Add(new object[] { "4", "$", "$", "04", "121322" });
                this.m_Code128.Rows.Add(new object[] { "5", "%", "%", "05", "131222" });
                this.m_Code128.Rows.Add(new object[] { "6", "&", "&", "06", "122213" });
                this.m_Code128.Rows.Add(new object[] { "7", "'", "'", "07", "122312" });
                this.m_Code128.Rows.Add(new object[] { "8", "(", "(", "08", "132212" });
                this.m_Code128.Rows.Add(new object[] { "9", ")", ")", "09", "221213" });
                this.m_Code128.Rows.Add(new object[] { "10", "*", "*", "10", "221312" });
                this.m_Code128.Rows.Add(new object[] { "11", "+", "+", "11", "231212" });
                this.m_Code128.Rows.Add(new object[] { "12", ",", ",", "12", "112232" });
                this.m_Code128.Rows.Add(new object[] { "13", "-", "-", "13", "122132" });
                this.m_Code128.Rows.Add(new object[] { "14", ".", ".", "14", "122231" });
                this.m_Code128.Rows.Add(new object[] { "15", "/", "/", "15", "113222" });
                this.m_Code128.Rows.Add(new object[] { "16", "0", "0", "16", "123122" });
                this.m_Code128.Rows.Add(new object[] { "17", "1", "1", "17", "123221" });
                this.m_Code128.Rows.Add(new object[] { "18", "2", "2", "18", "223211" });
                this.m_Code128.Rows.Add(new object[] { "19", "3", "3", "19", "221132" });
                this.m_Code128.Rows.Add(new object[] { "20", "4", "4", "20", "221231" });
                this.m_Code128.Rows.Add(new object[] { "21", "5", "5", "21", "213212" });
                this.m_Code128.Rows.Add(new object[] { "22", "6", "6", "22", "223112" });
                this.m_Code128.Rows.Add(new object[] { "23", "7", "7", "23", "312131" });
                this.m_Code128.Rows.Add(new object[] { "24", "8", "8", "24", "311222" });
                this.m_Code128.Rows.Add(new object[] { "25", "9", "9", "25", "321122" });
                this.m_Code128.Rows.Add(new object[] { "26", ":", ":", "26", "321221" });
                this.m_Code128.Rows.Add(new object[] { "27", ";", ";", "27", "312212" });
                this.m_Code128.Rows.Add(new object[] { "28", "<", "<", "28", "322112" });
                this.m_Code128.Rows.Add(new object[] { "29", "=", "=", "29", "322211" });
                this.m_Code128.Rows.Add(new object[] { "30", ">", ">", "30", "212123" });
                this.m_Code128.Rows.Add(new object[] { "31", "?", "?", "31", "212321" });
                this.m_Code128.Rows.Add(new object[] { "32", "@", "@", "32", "232121" });
                this.m_Code128.Rows.Add(new object[] { "33", "A", "A", "33", "111323" });
                this.m_Code128.Rows.Add(new object[] { "34", "B", "B", "34", "131123" });
                this.m_Code128.Rows.Add(new object[] { "35", "C", "C", "35", "131321" });
                this.m_Code128.Rows.Add(new object[] { "36", "D", "D", "36", "112313" });
                this.m_Code128.Rows.Add(new object[] { "37", "E", "E", "37", "132113" });
                this.m_Code128.Rows.Add(new object[] { "38", "F", "F", "38", "132311" });
                this.m_Code128.Rows.Add(new object[] { "39", "G", "G", "39", "211313" });
                this.m_Code128.Rows.Add(new object[] { "40", "H", "H", "40", "231113" });
                this.m_Code128.Rows.Add(new object[] { "41", "I", "I", "41", "231311" });
                this.m_Code128.Rows.Add(new object[] { "42", "J", "J", "42", "112133" });
                this.m_Code128.Rows.Add(new object[] { "43", "K", "K", "43", "112331" });
                this.m_Code128.Rows.Add(new object[] { "44", "L", "L", "44", "132131" });
                this.m_Code128.Rows.Add(new object[] { "45", "M", "M", "45", "113123" });
                this.m_Code128.Rows.Add(new object[] { "46", "N", "N", "46", "113321" });
                this.m_Code128.Rows.Add(new object[] { "47", "O", "O", "47", "133121" });
                this.m_Code128.Rows.Add(new object[] { "48", "P", "P", "48", "313121" });
                this.m_Code128.Rows.Add(new object[] { "49", "Q", "Q", "49", "211331" });
                this.m_Code128.Rows.Add(new object[] { "50", "R", "R", "50", "231131" });
                this.m_Code128.Rows.Add(new object[] { "51", "S", "S", "51", "213113" });
                this.m_Code128.Rows.Add(new object[] { "52", "T", "T", "52", "213311" });
                this.m_Code128.Rows.Add(new object[] { "53", "U", "U", "53", "213131" });
                this.m_Code128.Rows.Add(new object[] { "54", "V", "V", "54", "311123" });
                this.m_Code128.Rows.Add(new object[] { "55", "W", "W", "55", "311321" });
                this.m_Code128.Rows.Add(new object[] { "56", "X", "X", "56", "331121" });
                this.m_Code128.Rows.Add(new object[] { "57", "Y", "Y", "57", "312113" });
                this.m_Code128.Rows.Add(new object[] { "58", "Z", "Z", "58", "312311" });
                this.m_Code128.Rows.Add(new object[] { "59", "[", "[", "59", "332111" });
                this.m_Code128.Rows.Add(new object[] { "60", @"\", @"\", "60", "314111" });
                this.m_Code128.Rows.Add(new object[] { "61", "]", "]", "61", "221411" });
                this.m_Code128.Rows.Add(new object[] { "62", "^", "^", "62", "431111" });
                this.m_Code128.Rows.Add(new object[] { "63", "_", "_", "63", "111224" });
                this.m_Code128.Rows.Add(new object[] { "64", "NUL", "`", "64", "111422" });
                this.m_Code128.Rows.Add(new object[] { "65", "SOH", "a", "65", "121124" });
                this.m_Code128.Rows.Add(new object[] { "66", "STX", "b", "66", "121421" });
                this.m_Code128.Rows.Add(new object[] { "67", "ETX", "c", "67", "141122" });
                this.m_Code128.Rows.Add(new object[] { "68", "EOT", "d", "68", "141221" });
                this.m_Code128.Rows.Add(new object[] { "69", "ENQ", "e", "69", "112214" });
                this.m_Code128.Rows.Add(new object[] { "70", "ACK", "f", "70", "112412" });
                this.m_Code128.Rows.Add(new object[] { "71", "BEL", "g", "71", "122114" });
                this.m_Code128.Rows.Add(new object[] { "72", "BS", "h", "72", "122411" });
                this.m_Code128.Rows.Add(new object[] { "73", "HT", "i", "73", "142112" });
                this.m_Code128.Rows.Add(new object[] { "74", "LF", "j", "74", "142211" });
                this.m_Code128.Rows.Add(new object[] { "75", "VT", "k", "75", "241211" });
                this.m_Code128.Rows.Add(new object[] { "76", "FF", "I", "76", "221114" });
                this.m_Code128.Rows.Add(new object[] { "77", "CR", "m", "77", "413111" });
                this.m_Code128.Rows.Add(new object[] { "78", "SO", "n", "78", "241112" });
                this.m_Code128.Rows.Add(new object[] { "79", "SI", "o", "79", "134111" });
                this.m_Code128.Rows.Add(new object[] { "80", "DLE", "p", "80", "111242" });
                this.m_Code128.Rows.Add(new object[] { "81", "DC1", "q", "81", "121142" });
                this.m_Code128.Rows.Add(new object[] { "82", "DC2", "r", "82", "121241" });
                this.m_Code128.Rows.Add(new object[] { "83", "DC3", "s", "83", "114212" });
                this.m_Code128.Rows.Add(new object[] { "84", "DC4", "t", "84", "124112" });
                this.m_Code128.Rows.Add(new object[] { "85", "NAK", "u", "85", "124211" });
                this.m_Code128.Rows.Add(new object[] { "86", "SYN", "v", "86", "411212" });
                this.m_Code128.Rows.Add(new object[] { "87", "ETB", "w", "87", "421112" });
                this.m_Code128.Rows.Add(new object[] { "88", "CAN", "x", "88", "421211" });
                this.m_Code128.Rows.Add(new object[] { "89", "EM", "y", "89", "212141" });
                this.m_Code128.Rows.Add(new object[] { "90", "SUB", "z", "90", "214121" });
                this.m_Code128.Rows.Add(new object[] { "91", "ESC", "{", "91", "412121" });
                this.m_Code128.Rows.Add(new object[] { "92", "FS", "|", "92", "111143" });
                this.m_Code128.Rows.Add(new object[] { "93", "GS", "}", "93", "111341" });
                this.m_Code128.Rows.Add(new object[] { "94", "RS", "~", "94", "131141" });
                this.m_Code128.Rows.Add(new object[] { "95", "US", "DEL", "95", "114113" });
                this.m_Code128.Rows.Add(new object[] { "96", "FNC3", "FNC3", "96", "114311" });
                this.m_Code128.Rows.Add(new object[] { "97", "FNC2", "FNC2", "97", "411113" });
                this.m_Code128.Rows.Add(new object[] { "98", "SHIFT", "SHIFT", "98", "411311" });
                this.m_Code128.Rows.Add(new object[] { "99", "CODEC", "CODEC", "99", "113141" });
                this.m_Code128.Rows.Add(new object[] { "100", "CODEB", "FNC4", "CODEB", "114131" });
                this.m_Code128.Rows.Add(new object[] { "101", "FNC4", "CODEA", "CODEA", "311141" });
                this.m_Code128.Rows.Add(new object[] { "102", "FNC1", "FNC1", "FNC1", "411131" });
                this.m_Code128.Rows.Add(new object[] { "103", "StartA", "StartA", "StartA", "211412" });
                this.m_Code128.Rows.Add(new object[] { "104", "StartB", "StartB", "StartB", "211214" });
                this.m_Code128.Rows.Add(new object[] { "105", "StartC", "StartC", "StartC", "211232" });
                this.m_Code128.Rows.Add(new object[] { "106", "Stop", "Stop", "Stop", "2331112" });
            }

            public void Draw(Graphics _Garphics, string p_Text, string show_Text, Encode p_Code)
            {
                string str = p_Text;
                _Garphics.SmoothingMode = SmoothingMode.HighSpeed;
                GraphicsState gstate = _Garphics.Save();
                p_Text = this.GetP_Text(p_Text, p_Code);
                char[] chArray = p_Text.ToCharArray();
                int num = 0;
                for (int i = 0; i != chArray.Length; i++)
                {
                    num += int.Parse(chArray[i].ToString()) * (this.m_Magnify + 1);
                }
                _Garphics.FillRectangle(Brushes.White, new Rectangle(0, 0, (int) this.Width, (int) this.Height));
                int x = CommonSettings.MillimeterConvertPixel(15f);
                int height = ((int) this.Height) - CommonSettings.MillimeterConvertPixel(5f);
                for (int j = 0; j != chArray.Length; j++)
                {
                    int width = int.Parse(chArray[j].ToString()) * (this.m_Magnify + 1);
                    if ((j & 1) != 0)
                    {
                        _Garphics.FillRectangle(Brushes.White, new Rectangle(x, 2, width, height));
                    }
                    else
                    {
                        _Garphics.FillRectangle(Brushes.Black, new Rectangle(x, 2, width, height));
                    }
                    x += width;
                }
                show_Text = str + show_Text;
                SizeF ef = _Garphics.MeasureString(show_Text, this.m_ValueFont);
                int num7 = 0;
                if (ef.Width < this.Width)
                {
                    num7 = CommonSettings.MillimeterConvertPixel(15f);
                }
                int num8 = ((int) this.Height) - ((int) ef.Height);
                _Garphics.DrawString(show_Text, this.m_ValueFont, Brushes.Black, (float) num7, (float) num8);
                _Garphics.Restore(gstate);
            }

            internal Image GetCodeImage(string p)
            {
                throw new NotImplementedException();
            }

            public Bitmap GetCodeImage(string p_Text, string appendTxt, Encode p_Code)
            {
                int num;
                string str = p_Text;
                string str2 = "";
                IList<int> list = new List<int>();
                switch (p_Code)
                {
                    case Encode.Code128A:
                        num = 0x67;
                        break;

                    case Encode.Code128C:
                        num = 0x69;
                        if ((p_Text.Length & 1) != 0)
                        {
                            throw new Exception("128C长度必须是偶数");
                        }
                        while (p_Text.Length != 0)
                        {
                            int num2 = 0;
                            try
                            {
                                int.Parse(p_Text.Substring(0, 2));
                            }
                            catch
                            {
                                throw new Exception("128C必须是数字！");
                            }
                            str2 = str2 + this.GetValue(p_Code, p_Text.Substring(0, 2), ref num2);
                            list.Add(num2);
                            p_Text = p_Text.Remove(0, 2);
                        }
                        goto Label_0185;

                    case Encode.EAN128:
                        num = 0x69;
                        if ((p_Text.Length & 1) != 0)
                        {
                            throw new Exception("EAN128长度必须是偶数");
                        }
                        list.Add(0x66);
                        str2 = str2 + "411131";
                        while (p_Text.Length != 0)
                        {
                            int num3 = 0;
                            try
                            {
                                int.Parse(p_Text.Substring(0, 2));
                            }
                            catch
                            {
                                throw new Exception("128C必须是数字！");
                            }
                            str2 = str2 + this.GetValue(Encode.Code128C, p_Text.Substring(0, 2), ref num3);
                            list.Add(num3);
                            p_Text = p_Text.Remove(0, 2);
                        }
                        goto Label_0185;

                    default:
                        num = 0x68;
                        break;
                }
                while (p_Text.Length != 0)
                {
                    int num4 = 0;
                    string str3 = this.GetValue(p_Code, p_Text.Substring(0, 1), ref num4);
                    if (str3.Length == 0)
                    {
                        throw new Exception("无效的字符集!" + p_Text.Substring(0, 1).ToString());
                    }
                    str2 = str2 + str3;
                    list.Add(num4);
                    p_Text = p_Text.Remove(0, 1);
                }
            Label_0185:
                if (list.Count == 0)
                {
                    throw new Exception("错误的编码,无数据");
                }
                string str4 = str2.Insert(0, this.GetValue(num));
                for (int i = 0; i != list.Count; i++)
                {
                    num += list[i] * (i + 1);
                }
                int num6 = num % 0x67;
                Bitmap image = this.GetImage(str4 + this.GetValue(num6) + "2331112");
                this.GetViewText(image, str + appendTxt);
                return image;
            }

            private Bitmap GetImage(string p_Text)
            {
                char[] chArray = p_Text.ToCharArray();
                int num = 0;
                for (int i = 0; i != chArray.Length; i++)
                {
                    num += int.Parse(chArray[i].ToString()) * (this.m_Magnify + 1);
                }
                Bitmap image = new Bitmap(0x87, 0x39);
                this.m_Height = (uint) CommonSettings.MillimeterConvertPixel(10f);
                Graphics graphics = Graphics.FromImage(image);
                graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, image.Width, image.Height));
                int x = CommonSettings.MillimeterConvertPixel(5f);
                for (int j = 0; j != chArray.Length; j++)
                {
                    int width = int.Parse(chArray[j].ToString()) * (this.m_Magnify + 1);
                    if ((j & 1) != 0)
                    {
                        graphics.FillRectangle(Brushes.White, new Rectangle(x, 2, width, (int) this.m_Height));
                    }
                    else
                    {
                        graphics.FillRectangle(Brushes.Black, new Rectangle(x, 2, width, (int) this.m_Height));
                    }
                    x += width;
                }
                graphics.Dispose();
                return image;
            }

            private string GetP_Text(string p_Text, Encode p_Code)
            {
                int num;
                string str = "";
                IList<int> list = new List<int>();
                switch (p_Code)
                {
                    case Encode.Code128A:
                        num = 0x67;
                        break;

                    case Encode.Code128C:
                        num = 0x69;
                        if ((p_Text.Length & 1) != 0)
                        {
                            throw new Exception("128C长度必须是偶数");
                        }
                        while (p_Text.Length != 0)
                        {
                            int num2 = 0;
                            try
                            {
                                int.Parse(p_Text.Substring(0, 2));
                            }
                            catch
                            {
                                throw new Exception("128C必须是数字！");
                            }
                            str = str + this.GetValue(p_Code, p_Text.Substring(0, 2), ref num2);
                            list.Add(num2);
                            p_Text = p_Text.Remove(0, 2);
                        }
                        goto Label_0181;

                    case Encode.EAN128:
                        num = 0x69;
                        if ((p_Text.Length & 1) != 0)
                        {
                            throw new Exception("EAN128长度必须是偶数");
                        }
                        list.Add(0x66);
                        str = str + "411131";
                        while (p_Text.Length != 0)
                        {
                            int num3 = 0;
                            try
                            {
                                int.Parse(p_Text.Substring(0, 2));
                            }
                            catch
                            {
                                throw new Exception("128C必须是数字！");
                            }
                            str = str + this.GetValue(Encode.Code128C, p_Text.Substring(0, 2), ref num3);
                            list.Add(num3);
                            p_Text = p_Text.Remove(0, 2);
                        }
                        goto Label_0181;

                    default:
                        num = 0x68;
                        break;
                }
                while (p_Text.Length != 0)
                {
                    int num4 = 0;
                    string str2 = this.GetValue(p_Code, p_Text.Substring(0, 1), ref num4);
                    if (str2.Length == 0)
                    {
                        throw new Exception("无效的字符集!" + p_Text.Substring(0, 1).ToString());
                    }
                    str = str + str2;
                    list.Add(num4);
                    p_Text = p_Text.Remove(0, 1);
                }
            Label_0181:
                if (list.Count == 0)
                {
                    throw new Exception("错误的编码,无数据");
                }
                string str3 = str.Insert(0, this.GetValue(num));
                for (int i = 0; i != list.Count; i++)
                {
                    num += list[i] * (i + 1);
                }
                int num6 = num % 0x67;
                return (str3 + this.GetValue(num6) + "2331112");
            }

            private string GetValue(int p_CodeId)
            {
                DataRow[] rowArray = this.m_Code128.Select("ID='" + p_CodeId.ToString() + "'");
                if (rowArray.Length != 1)
                {
                    throw new Exception("验效位的编码错误" + p_CodeId.ToString());
                }
                return rowArray[0]["BandCode"].ToString();
            }

            private string GetValue(Encode p_Code, string p_Value, ref int p_SetID)
            {
                if (this.m_Code128 == null)
                {
                    return "";
                }
                DataRow[] rowArray = this.m_Code128.Select(p_Code.ToString() + "='" + p_Value + "'");
                if (rowArray.Length != 1)
                {
                    throw new Exception("错误的编码" + p_Value.ToString());
                }
                p_SetID = int.Parse(rowArray[0]["ID"].ToString());
                return rowArray[0]["BandCode"].ToString();
            }

            private void GetViewText(Bitmap p_Bitmap, string p_ViewText)
            {
                if (this.m_ValueFont != null)
                {
                    Graphics graphics = Graphics.FromImage(p_Bitmap);
                    SizeF ef = graphics.MeasureString(p_ViewText, this.m_ValueFont);
                    int num = 0;
                    if (ef.Width < p_Bitmap.Width)
                    {
                        num = CommonSettings.MillimeterConvertPixel(5f);
                    }
                    else
                    {
                        int num2 = 1 + ((((int) ef.Width) - p_Bitmap.Width) / 10);
                        p_ViewText = p_ViewText.Substring(0, p_ViewText.Length - num2);
                    }
                    int num3 = p_Bitmap.Height - ((int) ef.Height);
                    graphics.DrawString(p_ViewText, this.m_ValueFont, Brushes.Black, (float) num, (float) num3);
                }
            }

            public uint Height
            {
                get
                {
                    return this.m_Height;
                }
                set
                {
                    this.m_Height = value;
                }
            }

            public byte Magnify
            {
                get
                {
                    return this.m_Magnify;
                }
                set
                {
                    this.m_Magnify = value;
                }
            }

            public Font ValueFont
            {
                get
                {
                    return this.m_ValueFont;
                }
                set
                {
                    this.m_ValueFont = value;
                }
            }

            public uint Width { get; set; }

            public enum Encode
            {
                Code128A,
                Code128B,
                Code128C,
                EAN128
            }
        }
    }
}

