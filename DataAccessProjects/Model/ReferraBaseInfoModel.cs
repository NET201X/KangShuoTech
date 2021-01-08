namespace KangShuoTech.DataAccessProjects.Model
{
    using System;
    [Serializable]
    public class ReferraBaseInfoModel
    {
        public int ID { set; get; }
        public string CustomerName { set; get; }
        public string Sex { set; get; }
        public int Age { set; get; }
        public string RecordID { set; get; }
        public string IDCardNo { set; get; }
        public string CreateUnitName { set; get; }
        public string Address { set; get; }
        public string SickPhone { set; get; }
        public DateTime? IllnessDate { set; get; }
        public string NewUnitName { set; get; }
        public string NewDepartName { set; get; }
        public string NewDoctor { set; get; }
        public string FirstImpress { set; get; }
        public string TransReason { set; get; }
        public string HistoryIllness { set; get; }
        public string Retrospectively { set; get; }
        public string RefDoctor { set; get; }
        public string RefDoctorPhone { set; get; }
        public DateTime? TranseDate { set; get; }
        public DateTime? CreateTime { set; get; }
        public string CreateMenName { set; get; }
        public string UpdateUnitName { set; get; }
        public string UpdatePerson { set; get; }
        public DateTime? UpdateDate { set; get; }
    }
}
