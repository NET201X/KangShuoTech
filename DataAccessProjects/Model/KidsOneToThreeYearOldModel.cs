using System;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
    public class KidsOneToThreeYearOldModel
    {
        public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? FollowupDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? NextFollowupDate { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public decimal? HemoglobinValue { get; set; }
        public decimal? BregmaLeft { get; set; }
        public decimal? BregmaRight { get; set; }
        public decimal? CreatedBy { get; set; }
        public decimal? Stature { get; set; }
        public decimal? TakingVitaminsd { get; set; }
        public decimal? TeethDcnLeft { get; set; }
        public decimal? TeethDcnRight { get; set; }
        public decimal? Weight { get; set; }
        public decimal? OutdoorActivities { get; set; }
        public string CustomerID { get; set; }
        public string RecordID { get; set; }
        public string IDCardNo { get; set; }
        public string Name { get; set; }
        public string WeightAnalysis { get; set; }
        public string StatureAnalysis { get; set; }
        public string ColourFace { get; set; }
        public string Skin { get; set; }
        public string Bregma { get; set; }
        public string EyeAppearance { get; set; }
        public string EarAppearance { get; set; }
        public string Listening { get; set; }
        public string HeartLung { get; set; }
        public string Stomach { get; set; }
        public string FourLimb { get; set; }
        public string Gait { get; set; }
        public string SuspiciousRickets { get; set; }
        public string AuxeEstimate { get; set; }
        public string AmongTwoFollowup { get; set; }
        public string Other { get; set; }
        public string ReferralAdvice { get; set; }
        public string ReferralReason { get; set; }
        public string AgenciesDepartments { get; set; }
        public string Guidance { get; set; }
        public string GuidanceOther { get; set; }
        public string FollowUpDoctorSign { get; set; }
        public string Flag { get; set; }
        public string IsDel { get; set; }

        public string Chest { get; set; }//胸部
        public string SickNone { get; set; }//无患病
        public decimal? PneumoniaCounts { get; set; }//肺炎次数
        public decimal? DiarrheaCounts { get; set; }//腹泻次数
        public decimal? TraumaCounts { get; set; }//外伤次数
        public string SickOther { get; set; }//患病其他
        public string ReferraContacts { get; set; }//转诊联系人
        public string ReferralContactsTel { get; set; }//转诊联系人电话
        public string ReferralResult { get; set; }//转诊结果时
    }
}

