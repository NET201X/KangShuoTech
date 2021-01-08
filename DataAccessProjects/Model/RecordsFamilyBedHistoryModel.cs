namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsFamilyBedHistoryModel
    {
        public string HospitalName { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string IllcaseNums { get; set; }
        public DateTime? InHospitalDate { get; set; }
        public DateTime? OutHospitalDate { get; set; }
        public string PhysicalID { get; set; }
        public string Reasons { get; set; }

        public RecordsStateModel ModelState { get; set; }
        public int OutKey { get; set; }
    }
}