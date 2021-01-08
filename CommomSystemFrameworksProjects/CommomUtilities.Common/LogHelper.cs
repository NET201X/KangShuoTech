namespace CommomUtilities.Common
{
    using log4net;
    using log4net.Config;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;

    public class LogHelper
    {
        private static readonly ILog log = LogManager.GetLogger("Global");

        public static void EndLog()
        {
            log.Info("Pad 停止");
        }

        public static void InitLog()
        {
            XmlConfigurator.Configure(new FileInfo(Environment.CurrentDirectory + @"\log4net.xml"));
            log.Info("Pad 启动");
        }

        public static void LogDebug(string de)
        {
            log.Debug(de);
        }

        public static void LogError(Exception er)
        {
            log.Error(er);
        }

        public static void LogInfo(object message)
        {
            log.Info(message);
        }

        /// <summary>
        /// 記錄Log
        /// </summary>
        /// <param name="messageInfo">Log資料</param>
        public static void WriteLog(string messageInfo)
        {
            // 排程發佈路徑下查詢是否有Log.txt文檔
            string p_logFilePath = ConfigurationManager.AppSettings["LogFilePath"] != null ? ConfigurationManager.AppSettings["LogFilePath"].ToString().ToString() + "\\" :
                "D:\\DataUploadLog\\";
            string file = DateTime.Now.ToString("yyyyMMdd") + ".txt";

            if (p_logFilePath != null)
            {
                if (!Directory.Exists(p_logFilePath))
                {
                    Directory.CreateDirectory(p_logFilePath);
                }

                // Log文件存在時
                if (!File.Exists(p_logFilePath + file))
                {
                    FileStream cFile;
                    cFile = File.Create(p_logFilePath + file);
                    cFile.Dispose();
                    cFile.Close();
                }

                // 記錄相關信息
                FileStream p_FS = new FileStream(p_logFilePath + file, FileMode.Append);

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

        /// <summary>
        /// 删除Log记录
        /// </summary>
        public static void DeleteLog()
        {
            #region 删除Log记录

            // LogError路径
            string p_logFilePath = ConfigurationManager.AppSettings["LogFilePath"] != null ? ConfigurationManager.AppSettings["LogFilePath"].ToString().ToString() + "\\" :
                "D:\\DataUploadLog\\";

            // 删除LogError中日志
            if (Directory.Exists(p_logFilePath))
            {
                // 获取文件夹下面的文件
                List<FileInfo> files = new DirectoryInfo(p_logFilePath).GetFiles().OrderByDescending(p => p.LastWriteTime).ToList();

                // 遍历删除文件名
                for (int i = 7; i < files.Count; i++)
                {
                    files[i].Delete();
                }
            }

            #endregion
        }
    }
}

