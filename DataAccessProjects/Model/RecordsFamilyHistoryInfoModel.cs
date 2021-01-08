namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsFamilyHistoryInfoModel
    {
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


    }
}