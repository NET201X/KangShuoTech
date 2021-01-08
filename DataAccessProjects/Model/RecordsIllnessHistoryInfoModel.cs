namespace KangShuoTech.DataAccessProjects.Model
{
    using System;
    
    [Serializable]
    public class RecordsIllnessHistoryInfoModel
    {
        public string RecordID { get; set; }
        public DateTime? DiagnoseTime { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string IllnessOther { get; set; }
        public string IllnessName { get; set; }
        public string IllnessNameOther { get; set; }
        public string IllnessType { get; set; }
        public string JobIllness { get; set; }
        public string Therioma { get; set; }
        public RecordsStateModel RecordState { get; set; }

    }
}