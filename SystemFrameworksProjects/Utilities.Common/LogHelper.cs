namespace KangShuoTech.Utilities.Common
{
    using log4net;
    using log4net.Config;
    using System;
    using System.IO;

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
    }
}

