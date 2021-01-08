namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.IO;
    using System.Text;

    public static class ErrorLog
    {
        public static void ClearLog()
        {
            if (!Directory.Exists(Environment.CurrentDirectory + @"\RunLog"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\RunLog");
            }
            foreach (string str in Directory.GetFiles(Environment.CurrentDirectory + @"\RunLog", "*.txt"))
            {
                FileInfo info = new FileInfo(str);
                TimeSpan span = (TimeSpan) (DateTime.Now.Date - info.CreationTime.Date);
                if (span.TotalDays > 7.0)
                {
                    info.Delete();
                }
            }
        }

        public static void WriterLog(string er)
        {
            LogHelper.LogInfo(er);
        }

        public static void WriterLog(byte[] buff)
        {
            string fileName = string.Format(@"{0}\RunLog\{1}_SerialPort.txt", Environment.CurrentDirectory, DateTime.Today.ToString("yyyyMMdd"));
            FileInfo info = new FileInfo(fileName);
            if (!info.Exists)
            {
                using (StreamWriter writer = info.CreateText())
                {
                    string str2 = "";
                    foreach (byte num in buff)
                    {
                        string str3 = num.ToString("x") + " ";
                        str2 = str2 + str3;
                    }
                    writer.Write(str2 + "\r\n");
                    return;
                }
            }
            StreamWriter writer2 = new StreamWriter(fileName, true, Encoding.Default);
            writer2.Write("");
            string str4 = "";
            foreach (byte num2 in buff)
            {
                string str5 = num2.ToString("x") + " ";
                str4 = str4 + str5;
            }
            writer2.Write(str4 + "\r\n");
            writer2.Close();
        }
    }
}

