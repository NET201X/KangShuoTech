namespace KangShuoTech.CommomDataAccessProjects.CommonModel
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
        public string Unite { get; set; }
        public string OccurTime { get; set; }
        public string EndTime { get; set; }
        public string Remarks { get; set; }
        public string DateSorce { get; set; }
        public string Dose { get; set; }
        public string IllnessResult { get; set; }
        public string IllDescription { get; set; }
        public RecordsStateModel RecordState { get; set; }

    }
}