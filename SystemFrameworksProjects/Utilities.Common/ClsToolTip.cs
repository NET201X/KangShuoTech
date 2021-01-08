namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public static class ClsToolTip
    {
        private static string CancelMessage = "取消";
        private static string EnterManualReadingMsg = "手动输入读取数据";
        private static string ExitMessage = "退出";
        public static readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        public static string Language = "chinese";
        private static string m_log = "";
        private static string MessageBox_CannotCancel = "数据传输到服务器，不能取消";
        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        private static string TakeAReadingMsg = "读取测量数据";
        private static string TitleNameMsg = "健康管理";
        private static string ViewReadingsMsg = "测量数据";
        private static string Waiting_FoundDevice = "找到管理器";
        private static string Waiting_scanning = "扫描蓝牙设备";
        private static string Waiting_Transmitting = "传送数据中";
        private static string Waiting_Unassigned = "错误：管理器没有指定设备";
        private static string Welcome_BadCard = "请确认您使用正确的磁卡，然后重试";
        private static string Welcome_Loading = "加载信息，请等待";
        private static string Welcome_ManagerActivated = "管理器激活，请测试其他项目";
        private static string Welcome_PleaseSwipe = "请刷卡";
        private static string Welcome_Welcome = "欢迎";

        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);
        [DllImport("kernel32.dll")]
        public static extern IntPtr CloseHandle(IntPtr hObject);
        public static void FreshLog()
        {
            if (m_log.Length > 0)
            {
                try
                {
                    FileStream stream = new FileStream(@"c:\KangShuoTechLog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                    if (stream.Length > 0x16e360L)
                    {
                        stream.Close();
                        File.Delete(@"c:\KangShuoTechLog.txt");
                        stream = new FileStream(@"c:\KangShuoTechLog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                        stream.Flush();
                        stream.Close();
                    }
                    stream.Close();
                    StreamWriter writer = File.AppendText(@"c:\KangShuoTechLog.txt");
                    writer.Write(m_log);
                    writer.Flush();
                    writer.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void WriteLog(string log)
        {
            lock (typeof(ClsToolTip))
            {
                if (m_log.Length > 0xc350)
                {
                    m_log.Remove(0, 0x61a8);
                }
                log = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss  ") + log + "\r\n";
                m_log = m_log + log;
            }
        }

        public static string BadCard
        {
            get
            {
                Welcome_BadCard = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Please ensure you are using the correct card." : "Вы используете неверную карту ") : "Aseg\x00farese de estar usando la tarjeta correcta e intente nuevamente.") : "V\x00e9rifiez la carte et essayez \x00e0 nouveau") : "请确认您使用正确的磁卡，然后重试";
                return Welcome_BadCard;
            }
        }

        public static string CancelMsg
        {
            get
            {
                CancelMessage = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Cancel" : "Отмена") : "Cancelar") : "Annuler ") : "取消  ";
                return CancelMessage;
            }
        }

        public static string CannotCancel
        {
            get
            {
                MessageBox_CannotCancel = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Reading is being transmitted to server. Cannot cancel." : "Данные переданы на сервер. Отмена невозможна") : "La lectura se esta transmitiendo al servidor. No se puede cancelar.") : "Transmission au serveur en cours. Impossible d'annuler.") : "数据传输到服务器，不能取消";
                return MessageBox_CannotCancel;
            }
        }

        public static string EnterManualReading
        {
            get
            {
                EnterManualReadingMsg = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Enter a manual~reading" : "Введите данные~вручную") : "Ingrese una lectura~manual") : "Saisir manuellement~la lecture ") : "手动输入读取数据";
                return EnterManualReadingMsg;
            }
        }

        public static string ExitMsg
        {
            get
            {
                ExitMessage = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Exit" : "Выход ") : "Salir") : "Quitter. ") : "退出  ";
                return ExitMessage;
            }
        }

        public static string FoundDevice
        {
            get
            {
                Waiting_FoundDevice = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Found manager..." : "Прибор найден...") : "El manager ha sido encontrado...") : "Appareil trouv\x00e9...") : "找到管理器  ";
                return Waiting_FoundDevice;
            }
        }

        public static string Loading
        {
            get
            {
                Welcome_Loading = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Loading information. Please wait..." : "Информация загружается. Пожалуйста подождите... ") : "Cargando informaci\x00f3n. Por favor, espere... ") : "Chargement de l'information en cours. Veuillez patienter. ") : "加载信息，请等待  ";
                return Welcome_Loading;
            }
        }

        public static string ManagerActivated
        {
            get
            {
                Welcome_ManagerActivated = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Manager activated. Please take another reading" : "Прибор активизирован. Пожалуйста сделайте ещё одно измерение.") : "El manager ha sido activado. Por favor, tome otra lectura ") : "Appareil activ\x00e9. Veuillez ex\x00e9cuter une autre lecture.") : "管理器激活，请测试其他项目 ";
                return Welcome_ManagerActivated;
            }
        }

        public static string PleaseSwipe
        {
            get
            {
                Welcome_PleaseSwipe = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Please swipe your card " : "Пожалуйста проведите карточкой ") : "Por favor, pase su tarjeta ") : "Veuillez glisser votre carte. ") : "请刷卡  ";
                return Welcome_PleaseSwipe;
            }
        }

        public static string scanning
        {
            get
            {
                Waiting_scanning = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Scanning for a Manager..." : "Идёт поиск прибора ") : "Explorando en busca del manager") : "Recherche de connexion \x00e0 votre appareil en cours…") : "扫描蓝牙设备... ";
                return Waiting_scanning;
            }
        }

        public static string TakeAReading
        {
            get
            {
                TakeAReadingMsg = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Take a new~reading" : "Сделайте~измерение") : "Tome una nueva~manual") : "Ex\x00e9cutez une~lecture") : "读取测量数据";
                return TakeAReadingMsg;
            }
        }

        public static string TitleName
        {
            get
            {
                TitleNameMsg = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Health Management" : "Health Management") : "Health Management") : "Health Management") : "健康管理";
                return TitleNameMsg;
            }
        }

        public static string Transmitting
        {
            get
            {
                Waiting_Transmitting = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Transmitting reading..." : "Данные передаются... ") : "Transmitiendo lectura...") : "R\x00e9sultat en cours de transmission...") : "传送数据中  ";
                return Waiting_Transmitting;
            }
        }

        public static string Unassigned
        {
            get
            {
                Waiting_Unassigned = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Error: Manager not assigned to kiosk." : "Ошибка:Прибор не закреплён за Kиоском") : "Error: El Manager no ha sido asignado al quiosco.") : "Erreur : Votre appareil n'appartient pas \x00e0 ce Kiosque.") : "错误：管理器没有指定设备 ";
                return Waiting_Unassigned;
            }
        }

        public static string ViewReadings
        {
            get
            {
                ViewReadingsMsg = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "My last~readings" : "Мои последние~измерения") : "Mis \x00faltimas~lecturas ") : "Mes derni\x00e8res~lectures") : "测量数据";
                return ViewReadingsMsg;
            }
        }

        public static string Welcome
        {
            get
            {
                Welcome_Welcome = !(Language == "chinese") ? (!(Language == "french") ? (!(Language == "spanish") ? (!(Language == "russian") ? "Welcom " : "Добро Пожаловать ") : "Bienvenido ") : "Bienvenue ") : "您  好  ";
                return Welcome_Welcome;
            }
        }
    }
}

