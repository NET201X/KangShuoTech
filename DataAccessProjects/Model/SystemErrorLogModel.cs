namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class SystemErrorLogModel
    {
        public DateTime? CreateDate { get; set; }
        
        public int ID { get; set; }

        public string IDCardNo { get; set; }

        public string LogData { get; set; }

        public string Message { get; set; }

        public DateTime? SendDate { get; set; }

        public string SendEd { get; set; }

        public string StackTrace { get; set; }

        public string TargetSite { get; set; }
    }
}

