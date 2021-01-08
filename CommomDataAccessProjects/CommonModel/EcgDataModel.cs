namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;

    [Serializable]
    public class EcgDataModel
    {
        public string RecordID { get; set; }

        public string CustomerID { get; set; }

        public byte[] ECG { get; set; }

        public int ID { get; set; }

        public string IDCardNo { get; set; }
        public string IDCard { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string CreateDate { get; set; }
        public string ECGResult { get; set; }
        public string ECGResultEx { get; set; }
        public string ECGDate { get; set; }
        public string examno { get; set; }
        public int PID { get; set; }
        public string HeartRate { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }

        public string MID { get; set; }
        public string Conclusion { get; set; }
        public DateTime? CreateTime { get; set; }
        public string newIndex { get; set; }
        public string patientno { get; set; }
        public string cardNumber { get; set; }        
        public string Picture { get; set; }
    }
}

