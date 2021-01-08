namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class WomenGravidaFirstVisitModel
    {
        public int ID { get; set; }
        public string CustomerID { get; set; }
        public string RecordID { get; set; }
        public string IDCardNo { get; set; }
        public DateTime? RecordDate { get; set; }
        public int? PregancyWeeks { get; set; }
        public int? CustomerAge { get; set; }
        public string HusbandName { get; set; }
        public int? HusbandAge { get; set; }
        public string HusbandPhone { get; set; }
        public int? PregancyCount { get; set; }
        public int? NatrualChildBirthCount { get; set; }
        public int? CaeSareanCount { get; set; }
        public string LastMenStruation { get; set; }
        public DateTime? LastMenStruationDate { get; set; }
        public DateTime? ExpectedDueDate { get; set; }
        public string CustomerHistory { get; set; }
        public string CustomerHistoryEx { get; set; }
        public string FamilyHistory { get; set; }
        public string FamilyHistoryEx { get; set; }
        public string PersonalHistory { get; set; }
        public string PersonalHistoryEx { get; set; }
        public string GyNecoloGyHistory { get; set; }
        public string AbortionInfo { get; set; }
        public string Deadfetus { get; set; }
        public string StillBirthInfo { get; set; }
        public string NewBornDead { get; set; }
        public string NewBornDefect { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Bmi { get; set; }
        public decimal? HBloodpressure { get; set; }
        public decimal? LBloodpressure { get; set; }
        public string Heart { get; set; }
        public string Heartex { get; set; }
        public string Lung { get; set; }
        public string Lungex { get; set; }
        public string Vulva { get; set; }
        public string VulvaEx { get; set; }
        public string Vagina { get; set; }
        public string VaginaEx { get; set; }
        public string CervixuTeri { get; set; }
        public string CervixuTeriex { get; set; }
        public string Corpus { get; set; }
        public string CorpusEx { get; set; }
        public string Attach { get; set; }
        public string AttachEx { get; set; }
        public string OverAlassessMent { get; set; }
        public string HealthZhiDao { get; set; }
        public string HealthZhiDaoOthers { get; set; }
        public string Referral { get; set; }
        public string ReferralReason { get; set; }
        public string ReferralOrg { get; set; }
        public DateTime? NextfollowupDate { get; set; }
        public string FollowUpDoctor { get; set; }
        public decimal? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string IsDel { get; set; }
        public string GynecologyHistoryEx { get; set; }
        public string OverAlassessmentEx { get; set; }
        public string ArtificialAbortion { get; set; }//人工流产
        public string BooksInfo { get;set;}//是否建册
        public string BooksInstitution{get;set;}//其他建册机构
        public string ReferralContacts{get;set;}//转诊联系人
        public string ReferralContactsTel { get; set; }//转诊联系人电话
        public string ReferralResult { get; set; }//转诊结果

    }
}

