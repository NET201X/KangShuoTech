namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class ChronicDiabetesBaseInfoModel
    {
        public string RecordID { get; set; }      
        public string CaseSource { get; set; }      
        public string CerebrovascularTime { get; set; }      
        public decimal? CreateUnit { get; set; }      
        public decimal? CreateBy { get; set; }      
        public DateTime? CreateDate { get; set; }      
        public decimal? CurrentUnit { get; set; }      
        public string CustomerID { get; set; }      
        public DateTime? DiabetesTime { get; set; }      
        public string DiabetesType { get; set; }      
        public string DiabetesWork { get; set; }      
        public string EnalaprilMelete { get; set; }      
        public string EndManage { get; set; }      
        public DateTime? EndTime { get; set; }      
        public string EndWhy { get; set; }              
        public string FamilyHistory { get; set; }      
        public string FootLesionsTime { get; set; }      
        public DateTime? HappnTime { get; set; }      
        public string HeartDiseaseTime { get; set; }      
        public int ID { get; set; }
        public string IDCardNo { get; set; }      
        public string Insulin { get; set; }      
        public string InsulinWeight { get; set; }      
        public string IsDelete { get; set; }      
        public decimal? LastUpdateBy { get; set; }       
        public DateTime? LastUpdateDate { get; set; }      
        public string Lesions { get; set; }      
        public string LesionsOther { get; set; }      
        public string LesionsOtherTime { get; set; }      
        public string ManagementGroup { get; set; }  
        public string NeuropathyTime { get; set; }      
        public string RenalLesionsTime { get; set; }      
        public string RetinopathyTime { get; set; }      
        public string Symptom { get; set; }
    }
}

