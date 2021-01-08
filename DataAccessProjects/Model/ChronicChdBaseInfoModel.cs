namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class ChronicChdBaseInfoModel
    {
        public string RecordID { get; set; }
        public string Artery { get; set; }
        public decimal? BMI { get; set; }
        public DateTime? CheckDate { get; set; }
        public decimal? Chole { get; set; }
        public string CoroType { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CurrenStatus { get; set; }
        public string CustomerID { get; set; }
        public string Drinking { get; set; }
        public string ECGColor { get; set; }
        public string ECGResult { get; set; }
        public string ECGSports { get; set; }
        public DateTime? EndDate { get; set; }
        public string EndReason { get; set; }
        public string Exercise { get; set; }
        public string FamilyHistory { get; set; }
        public decimal? FPG { get; set; }
        public decimal? Glycerate { get; set; }
        public string GroupLevel { get; set; }
        public decimal? HeatRate { get; set; }
        public decimal? Height { get; set; }
        public string History { get; set; }
        public decimal? HLIP { get; set; }
        public decimal? Hypertension { get; set; }
        public decimal? Hypotension { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string IsDelete { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string Life { get; set; }
        public decimal? LLIP { get; set; }
        public string Medical { get; set; }
        public string Myocardial { get; set; }
        public string Smoking { get; set; }
        public string Source { get; set; }
        public string Status { get; set; }
        public DateTime? SureDate { get; set; }
        public string SureUnit { get; set; }
        public decimal? Waistline { get; set; }
        public decimal? Weight { get; set; }
        public int OUTKey { get; set; }
    }
}

