using System;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
    public class KidsThreeToSixYearOldModel
    {
        public int ID { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? VisitDate { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public decimal? TcnLeft { get; set; }
        public decimal? TdcnRight { get; set; }
        public decimal? TraumatismFrequen { get; set; }
        public decimal? Weight { get; set; }
        public decimal? CreateBy { get; set; }
        public decimal? DiarrhoeaFrequen { get; set; }
        public decimal? HemoglobinValue { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public decimal? PneumoniaFrequen { get; set; }
        public decimal? Sight { get; set; }
        public decimal? Stature { get; set; }
		public string CustomerID { get; set; }
		public string RecordID { get; set; }
		public string IDCardNo { get; set; }
		public string Name { get; set; }
		public string Listening { get; set; }
		public string WeightAnalysis { get; set; }
		public string StatureAnalysis { get; set; }
		public string PhysicalAuxeEvaluat { get; set; }
		public string HeartLung { get; set; }
		public string Stomach { get; set; }
		public string Other { get; set; }
		public string AmongTwoFolloNone { get; set; }
		public string AmongTwoFolloOther { get; set; }
		public string ReferralReason { get; set; }
        public string ReferralAdvice { get; set; }
		public string AgenciesDepartments { get; set; }
		public string Guidance { get; set; }
		public string GuidanceOther { get; set; }
		public string VisitDoctorSign { get; set; }
		public string Flag { get; set; }
        public string IsDel { get; set; }

        public string Kindergarten { get; set; }//幼儿园
        public string ManagerContact { get; set; }//健康管理联系人
        public string ManagerContactTel { get; set; }//健康管理联系电话
        public string BodyInstitution { get; set; }//查体机构
        public string InstitutionOther { get; set; }//查体机构其他
        public decimal? WeightVsHeight { get; set; }//身高/体重
        public string WeightVsHeightAnalysis { get; set; }//身高/体重分析
        public string Chest { get; set; }//胸部
        public string ReferraContacts { get; set; }//转诊联系人
        public string ReferralContactsTel { get; set; }//转诊联系人电话
        public string ReferralResult { get; set; }//转诊结果时
        public string AuxeEstimate { get; set; }//发育评估

    }
}

