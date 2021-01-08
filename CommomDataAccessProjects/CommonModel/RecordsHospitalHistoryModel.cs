namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;

    [Serializable]
    public class RecordsHospitalHistoryModel
    {
        public string HospitalName { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string IllcaseNum { get; set; }
        public DateTime? InHospitalDate { get; set; }
        public DateTime? OutHospitalDate { get; set; }
        public string PhysicalID { get; set; }
        public string Reason { get; set; }

        public RecordsStateModel ModelState { get; set; }
        public int OutKey { get; set; }
    }
}