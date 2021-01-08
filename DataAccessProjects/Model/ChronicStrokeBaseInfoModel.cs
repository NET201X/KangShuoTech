using System;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
    public class ChronicStrokeBaseInfoModel
    {
        public string RecordID { get; set; }   
        public decimal CreateUnit { get; set; } 
        public decimal? CreatedBy { get; set; } 
        public DateTime? CreatedDate { get; set; } 
        public string CT { get; set; } 
        public decimal CurrentUnit { get; set; } 
        public string CustomerID { get; set; } 
        public string DangerousElement { get; set; } 
        public string DgrElementOther { get; set; } 
        public string DiagnosisHource { get; set; } 
        public string DrugsRely { get; set; } 
        public string Familyhistory { get; set; } 
        public string GroupLevel { get; set; } 
        public string HosState { get; set; } 
        public int ID { get; set; } 
        public string IDCardNo { get; set; } 
        public string IllSource { get; set; } 
        public DateTime? IllTime { get; set; } 
        public string IsDel { get; set; } 
        public decimal? LastUpdateBy { get; set; } 
        public DateTime? LastUpdateDate { get; set; } 
        public string Mri { get; set; } 
        public decimal? Mrs { get; set; } 
        public DateTime? OccurTime { get; set; } 
        public string OtherTreatment { get; set; } 
        public string SelfAbility { get; set; } 
        public string SpecialTreatment { get; set; } 
        public string StopManager { get; set; } 
        public string StopReason { get; set; } 
        public DateTime? StopTime { get; set; } 
        public string StrokePosition { get; set; } 
        public string StrokeType { get; set; }

    }

}

