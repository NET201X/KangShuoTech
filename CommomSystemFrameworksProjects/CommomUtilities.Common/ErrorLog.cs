namespace CommomUtilities.Common
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

        /// <summary>
        /// 記錄Log
        /// </summary>
        /// <param name="messageInfo">Log資料</param>
        public static void WriteLog(string messageInfo)
        {
            // 排程發佈路徑下查詢是否有Log.txt文檔
            string p_logFilePath = "D:\\ScheduleLog\\" + DateTime.Now.ToString("yyyyMMdd");

            if (p_logFilePath != null)
            {
                if (!Directory.Exists(p_logFilePath))
                {
                    Directory.CreateDirectory(p_logFilePath);
                }

                // Log文件存在時
                if (!File.Exists(p_logFilePath + "\\ScheduleLog.txt"))
                {
                    FileStream cFile;
                    cFile = File.Create(p_logFilePath + "\\ScheduleLog.txt");
                    cFile.Dispose();
                    cFile.Close();
                }

                // 記錄相關信息
                FileStream p_FS = new FileStream(p_logFilePath + "\\ScheduleLog.txt", FileMode.Append);

                StreamWriter p_SW = new StreamWriter(p_FS, System.Text.Encoding.GetEncoding("UTF-8"));

                // 第一行:打印當前時間
                p_SW.WriteLine(DateTime.Now.ToString());

                // 第二行:打印重要標題和詳細信息
                p_SW.WriteLine(messageInfo);

                // 第三行:打印"*"
                p_SW.WriteLine("***********************************************************************");

                // 第四行:打印空行,分隔下一筆Log資料
                p_SW.WriteLine("");

                // 關閉資料流
                p_SW.Close();
                p_FS.Dispose();
                p_FS.Close();
            }
        }
    }
}

