namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class HealthHouseGuideModel
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string IDCardNo { get; set; }
        public string Summary { get; set; }
        public string HealthGuid { get; set; }
        public string MedGuid { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public string CustomerName { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? CheckDate { get; set; }
    }
}
