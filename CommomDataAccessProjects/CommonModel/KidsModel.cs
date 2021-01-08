namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;

    [Serializable]
    public class KidsTcmhmOneModel
    {
        public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? VisitDate { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public string CustomerID { get; set; }
        public string RecordID { get; set; }
        public string VisitType { get; set; }
        public string Tcmhm { get; set; }
        public string TcmhmOther { get; set; }
        public string VisitDoctor { get; set; }
        public string IsDel { get; set; }
        public string IDCardNo { get; set; }
        public string FollowupType { get; set; }
        public string FollowDoctor { get; set; }
        public DateTime? FollowupDate { get; set; }
        public DateTime? NextFollowDate { get; set; }
    }

    [Serializable]
    public class KidsTcmhmOneToThreeModel
    {
        public int ID { get; set; }
        public string RecordID { get; set; }
        public DateTime? FollowupDate { get; set; }
        public DateTime? NextFollowupDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public decimal? CreatedBy { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public string CustomerID { get; set; }
        public string FollowupType { get; set; }
        public string Tcmhm { get; set; }
        public string TcmhmOther { get; set; }
        public string FollowUpDoctor { get; set; }
        public string IsDel { get; set; }
        public string IDCardNo { get; set; }
        public DateTime? VisitDate { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public string VisitDoctor { get; set; }
        public string VisitType { get; set; }
    }

    [Serializable]
    public class KidsTcmhmThreeToSixModel
    {
        public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? FollowupDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? NextFollowupDate { get; set; }
        public decimal? CreatedBy { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public string CustomerID { get; set; }
        public string RecordID { get; set; }
        public string FollowupType { get; set; }
        public string Tcmhm { get; set; }
        public string TcmhmOther { get; set; }
        public string FollowUpDoctor { get; set; }
        public string IsDel { get; set; }
        public string IDCardNo { get; set; }
        public DateTime? VisitDate { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public string VisitDoctor { get; set; }
        public string VisitType { get; set; }
    }
    
    [Serializable]
    public class KidsWithinOneYearOldModel
    {
        public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? VisitDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? NextFollowupDate { get; set; }
        public decimal? Weight { get; set; }
        public decimal? BregmaLeft { get; set; }
        public decimal? BregmaRight { get; set; }
        public decimal? TakingVitaminsd { get; set; }
        public decimal? TeethNum { get; set; }
        public decimal? Stature { get; set; }
        public decimal? OutdoorActivities { get; set; }
        public decimal? HemoglobinValue { get; set; }
        public decimal? HeadCircumference { get; set; }
        public string HeartLung { get; set; }
        public string OralCavity { get; set; }
        public string Listening { get; set; }
        public string EarAppearance { get; set; }
        public string EyeAppearance { get; set; }
        public string NeckMass { get; set; }
        public string Bregma { get; set; }
        public string Skin { get; set; }
        public string ColorFace { get; set; }
        public string StatureAnalysis { get; set; }
        public string WeightAnalysis { get; set; }
        public string Name { get; set; }
        public string IDCardNo { get; set; }
        public string RecordID { get; set; }
        public string CustomerID { get; set; }
        public string Flag { get; set; }
        public string FollowUpDoctorSign { get; set; }
        public string Guidance { get; set; }
        public string AgenciesDepartments { get; set; }
        public string ReferralReason { get; set; }
        public string ReferralAdvice { get; set; }
        public string Other { get; set; }
        public string AmongTwoFollowup { get; set; }
        public string AuxeEstimate { get; set; }
        public string AnusExternalGenita { get; set; }
        public string RicketsSign { get; set; }
        public string RicketsSympotom { get; set; }
        public string FourLimb { get; set; }
        public string UmbilicalRegion { get; set; }
        public string Stomach { get; set; }
        public string IsDel { get; set; }
        public string LastUpdateBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
