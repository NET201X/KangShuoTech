using System;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
    public class ChronicHypertensionBaseInfoModel
    {
        public string RecordID { get; set; }
        public string CaseOurce { get; set; }
        public decimal? CreateUnit { get; set; }
        public decimal? CreateoBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? CurrentUnit { get; set; }
        public string CustomerID { get; set; }        
        public string FatherHistory { get; set; }
        public string HypertensionComplication { get; set; }
        public string Hypotensor { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string IsDel { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string ManagementGroup { get; set; }
        public string Symptom { get; set; }
        public string TerminateExcuse { get; set; }
        public string TerminateManagemen { get; set; }
        public DateTime? TerminateTime { get; set; }
    }
}

