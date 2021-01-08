namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;

    [Serializable]
    public class ChronicDrugConditionModel
    {
        public string DailyTime { get; set; }

        public string DosAge { get; set; } //用法用量

        public string EveryTimeMg { get; set; }
   
        public int ID { get; set; }

        public string IDCardNo{get; set;}
        
        public string Name { get; set; }

        public string Type { get; set; }

        public string DrugType { get; set; }

        public string Factory { get; set; }

        public int OutKey { get; set; }
    }

    [Serializable]
    public class ChronicMentalDiseaseBaseInfoModel
    {
        public string AgreeManagement { get; set; }
        public string AgreeSignature { get; set; }
        public DateTime? AgreeTime { get; set; }
        public string RecordID { get; set; }
        public int AttemptSuicFrequen { get; set; }
        public string AttemptSuicideNone { get; set; }
        public int AutolesionFrequen { get; set; }
        public int CauseAccidFrequen { get; set; }
        public int CreateDistuFrequen { get; set; }
        public decimal? CreateUnit { get; set; }
        public decimal? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? CurrentUnit { get; set; }
        public string CustomerID { get; set; }
        public string DiagnosisHospital { get; set; }
        public string DiagnosisInfo { get; set; }
        public DateTime? DiagnosisTime { get; set; }
        public string DoctorMark { get; set; }
        public string Economy { get; set; }
        public DateTime? FillformTime { get; set; }
        public DateTime? FirstTime { get; set; }
        public DateTime? FirstTreatmenTTime { get; set; }
        public string GuardianRecordID { get; set; }
        public string GuardianName { get; set; }
        public string GuradianAddr { get; set; }
        public string GuradianPhone { get; set; }
        public int HospitalCount { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string IsDel { get; set; }
        public string LastCure { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public DateTime? LastUpDateDate { get; set; }
        public string LockInfo { get; set; }
        public int MildTroubleFrequen { get; set; }
        public string OutPatien { get; set; }
        public string Ralation { get; set; }
        public string SpecialistProposal { get; set; }
        public string Symptom { get; set; }
        public string SymptomOther { get; set; }
        public string VillageContacts { get; set; }
        public string VillageTel { get; set; }
        public string Professional { get; set; }//职业

        public int OtherDangerFrequen { get; set; }//其他危害行为
        public string HouseType { get; set; }//户别
    }

    [Serializable]
    public class ChronicMentalDiseaseVisitModel
    {
        public string AdnerDruReact { get; set; }
        public string AdverDruReactHave { get; set; }
        public string RecordID { get; set; }
        public int AttemptSuicFrequen { get; set; }
        public string AttemptSuicideNone { get; set; }
        public int AutolesionFrequen { get; set; }
        public int CauseAccidFrequen { get; set; }
        public int CreateDistuFrequen { get; set; }
        public decimal? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CustomerID { get; set; }
        public string Diet { get; set; }
        public string Fatalness { get; set; }
        public string FollowupClassificat { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string FollowUpDoctor { get; set; }
        public string HospitalizatiStatus { get; set; }
        public string Housework { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string Insight { get; set; }
        public string IsDel { get; set; }
        public string LaborExaminati { get; set; }
        public string LaborExaminatiHave { get; set; }
        public DateTime? LastLeaveHospTime { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LearningAbility { get; set; }
        public string LockCondition { get; set; }
        public string MedicatioCompliance { get; set; }
        public int MildTroubleFrequen { get; set; }
        public DateTime? NextFollowUpDate { get; set; }
        public string PersonalCare { get; set; }
        public string PresentSymptoOther { get; set; }
        public string PresentSymptom { get; set; }
        public string ProductLaborWork { get; set; }
        public string ReferralAgencDepar { get; set; }
        public string ReferralReason { get; set; }
        public string RehabiliMeasu { get; set; }
        public string RehabiliMeasuOther { get; set; }
        public string SleepQuality { get; set; }
        public string SocialInterIntera { get; set; }
        public string TreatmentEffect { get; set; }
        public string WhetherReferral { get; set; }
        public string NoVisitReason { get; set; }//失访原因
        public DateTime? DeathDate { get; set; }//死亡日期
        public string IllReason { get; set; }//躯体疾病原因
        public string DeathReason { get; set; }//死亡原因
        public int OtherDangerFrequen { get; set; }//其他危害行为
        public string FollowUpType { get; set; }//随访方式
        public DateTime? VisitDate { get; set; }
        public string VisitType { get; set; }//随访方式
        public string VisitDoctor { get; set; }
        public DateTime? NextVisitDate { get; set; }
    }
}