namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;

    [Serializable]
    public class RecordsFamilyHistoryInfoModel
    {
        public RecordsFamilyHistoryInfoModel() { }

        public string RecordID { get; set; }
        public string BrotherSisterHistory { get; set; }
        public string BrotherSisterHistoryOther { get; set; }
        public string ChildrenHistory { get; set; }
        public string ChildrenHistoryOther { get; set; }
        public string FamilyType { get; set; }
        public string FatherHistory { get; set; }
        public string FatherHistoryOther { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string MotherHistory { get; set; }
        public string MotherHistoryOther { get; set; }
       
        //ÐÂÔö×Ö¶Î
        public string GrandparentHistory { get; set; }
        public string GrandparentHistoryOther { get; set; }
        public DateTime? DiagnoseTime { get; set; }
        public string SickerName { get; set; }
        public string Remarks { get; set; }
        public string IllnessName { get; set; }
        public string AncestorsHistory { get; set; }
        public string AncestorsHistoryOther { get; set; }
    }
}