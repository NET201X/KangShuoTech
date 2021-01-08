using System;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    [Serializable]
    public class ChronicHypertensionVisitModel
    {
        public string Adr { get; set; }
        public string AdrEx { get; set; }
        public string RecordID { get; set; }
        public string AssistantExam { get; set; }
        public decimal? BMI { get; set; }
        public decimal? BMITarGet { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public decimal? DailyDrinkNum { get; set; }
        public decimal? DailyDrinkNumTarget { get; set; }
        public decimal? DailySmokeNum { get; set; }
        public decimal? DailySmokeNumTarget { get; set; }
        public string EatSaltTarGet { get; set; }
        public string EatSaltType { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string FollowUpDoctor { get; set; }
        public string FollowUpType { get; set; }
        public string FollowUpWay { get; set; }
        public string HeartRate { get; set; }
        public decimal? Hypertension { get; set; }
        public decimal? Hypotension { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string IsDel { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string MedicationCompliance { get; set; }
        public DateTime? NextFollowUpDate { get; set; }
        public string ObeyDoctorBehavior { get; set; }
        public string PhysicalSympToMother { get; set; }
        public string PsyChoadJustMent { get; set; }
        public string ReferralOrg { get; set; }
        public string ReferralReason { get; set; }
        public decimal? SportPerMinutesTimeTarget { get; set; }
        public decimal? SportPerMinuteTime { get; set; }
        public decimal? SportTimePerWeek { get; set; }
        public decimal? SportTimeSperWeekTarget { get; set; }
        public string Symptom { get; set; }
        public string SympToMother { get; set; }
        public decimal? Weight { get; set; }
        public decimal? WeightTarGet { get; set; }
        public decimal? Height { get; set; }//身高
        public string DoctorView { get; set; }//此次随访医生建议
        public string IsReferral { get; set; }//转诊情况是否：1：是，2：否
        public string NextMeasures { get; set; }//下一步管理措施
        public string ReferralContacts { get; set; }//转诊联系人及电话
        public string ReferralResult { get; set; }//转诊结果
        public string Remarks { get; set; }//备注
        public DateTime? VisitDate { get; set; }
        public string VisitType { get; set; }
        public string VisitWay { get; set; }
        public string VisitDoctor { get; set; }
        public DateTime? NextVisitDate { get; set; }
    }

    [Serializable]
    public class ChronicStrokeVisitModel
    {
        public string Adr { get; set; }
        public string AdrEx { get; set; }
        public string RecordID { get; set; }
        public string AssistantExam { get; set; }
        public decimal? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CustomerID { get; set; }
        public string EatSaltAttention { get; set; }
        public string EatingDrug { get; set; }
        public DateTime? FollowupDate { get; set; }
        public string FollowUpDoctor { get; set; }
        public string FollowupType { get; set; }
        public string FollowupWay { get; set; }
        public decimal? Hypertension { get; set; }
        public decimal? Hypotension { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string IsDel { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string MedicationCompliance { get; set; }
        public DateTime? NextFollowupDate { get; set; }
        public string ObeyDoctorBehavio { get; set; }
        public string PsychicAdjust { get; set; }
        public string ReferralOrg { get; set; }
        public string ReferralReason { get; set; }
        public string SignOther { get; set; }
        public string SmokeDrinkAttention { get; set; }
        public string SportAttention { get; set; }
        public string Symptom { get; set; }
        public string SymptomOther { get; set; }
        public decimal? Weight { get; set; }

        //添加字段：Strokelocation,StrokeType,MedicalHistory,Syndrome,SyndromeOther,NewSymptom,NewSymptomOther,SmokeDay,DrinkDay,SportWeek,
        //SportMinute,FPGL,Height,BMI,Waistline,LifeSelfCare,LimbRecover,RecoveryCure,RecoveryCureOther,DoctorView,IsReferral --共21个
        public string Strokelocation { get; set; } //脑卒中部位
        public string StrokeType { get; set; } //脑卒中类型
        public string MedicalHistory { get; set; } //个人病史
        public string Syndrome { get; set; } //脑卒中并发症情况
        public string SyndromeOther { get; set; } //脑卒中并发症其他
        public string NewSymptom { get; set; } //新发卒中症状
        public string NewSymptomOther { get; set; } //新发卒中症状其他
        public decimal? SmokeDay { get; set; }
        public decimal? DrinkDay { get; set; }
        public decimal? SportWeek { get; set; }
        public decimal? SportMinute { get; set; }
        public decimal? FPGL { get; set; } //空腹血糖L
        public decimal? Height { get; set; }
        public decimal? BMI { get; set; }
        public decimal? Waistline { get; set; }
        public string LifeSelfCare { get; set; } //生活能否自理
        public string LimbRecover { get; set; } //肢体功能恢复情况
        public string RecoveryCure { get; set; } //康复治疗的方式
        public string RecoveryCureOther { get; set; } //康复治疗的方式其他
        public string DoctorView { get; set; } //本次随访医生建议
        public string IsReferral { get; set; } //是否转诊：1是，2否
        public string FollowupTypeOther { get; set; } //此次随访分类其他
        public DateTime? VisitDate { get; set; }
        public string VisitType { get; set; }
        public string VisitTypeOther { get; set; } //此次随访分类其他
        public string VisitWay { get; set; }
    }

    [Serializable]
    public class ChronicChdVisitModel
    {
        public string Action { get; set; }
        public string AfterPill { get; set; }
        public string Apex { get; set; }
        public string RecordID { get; set; }
        public string AssistCheck { get; set; }
        public string Compliance { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CustomerID { get; set; }
        public decimal? Diastolic { get; set; }
        public DateTime? VisitDate { get; set; }
        public string VisitDoctor { get; set; }
        public string VisitType { get; set; }
        public string HeartRate { get; set; }
        public string HearVoice { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string IsDelete { get; set; }
        public decimal? LastUpDateBy { get; set; }
        public DateTime? LastUpDateDate { get; set; }
        public string FollowType { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public string ReferralDepart { get; set; }
        public string ReferralReason { get; set; }
        public string Salt { get; set; }
        public string Smoking { get; set; }
        public string Sports { get; set; }
        public string Symptom { get; set; }
        public string SymptomEx { get; set; }
        public decimal? Systolic { get; set; }
        public string Untoward { get; set; }
        public string UntowardEx { get; set; }
        public decimal? Weight { get; set; }

        //添加字段 ChdType,Height,BMI,FPGL,TC,TG,LowCho,HeiCho,EcgCheckResult,EcgExerciseResult,CAG,EnzymesResult,HeartCheckResult,SmokeDay,DrinkDay,
        //SportWeek,SportMinute,SpecialTreated,NondrugTreat,Syndromeother,DoctorView,IsReferral
        public string ChdType { get; set; } //冠心病类型 
        public decimal? Height { get; set; } //身高
        public decimal? BMI { get; set; } //体质指数
        /// <summary>
        /// 空腹血糖
        /// </summary>
        public decimal? FPGL { get; set; }
        /// <summary>
        /// TC总胆固醇
        /// </summary>
        public decimal? TC { get; set; }
        /// <summary>
        /// TG甘油三酯
        /// </summary>
        public decimal? TG { get; set; }
        /// <summary>
        /// 血清低密度脂蛋白胆固醇
        /// </summary>
        public decimal? LowCho { get; set; }

        /// <summary>
        /// 血清高密度脂蛋白胆固醇
        /// </summary>
        public decimal? HeiCho { get; set; }

        /// <summary>
        /// 心电图检查结果
        /// </summary>
        public string EcgCheckResult { get; set; }

        /// <summary>
        /// 心电图运动负荷试验结果
        /// </summary>
        public string EcgExerciseResult { get; set; }

        /// <summary>
        /// 冠状动脉造影结果
        /// </summary>
        public string CAG { get; set; }

        /// <summary>
        /// 心肌酶学检查结果
        /// </summary>
        public string EnzymesResult { get; set; }

        /// <summary>
        /// 心脏彩超检查结果
        /// </summary>
        public string HeartCheckResult { get; set; }

        public decimal? SmokeDay { get; set; }
        public decimal? DrinkDay { get; set; }
        public decimal? SportWeek { get; set; }
        public decimal? SportMinute { get; set; }
        public string SpecialTreated { get; set; }
        public string NondrugTreat { get; set; }
        public string Syndromeother { get; set; }
        public string DoctorView { get; set; }
        public string IsReferral { get; set; }
    }

    [Serializable]
    public class ChronicHypertensionBaseInfoModel
    {
        public string RecordID { get; set; }
        public string CaseOurce { get; set; }
        public decimal? CreateUnit { get; set; }
        public decimal? CreatedBy { get; set; }
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
        public string HypType { get; set; }
        public string DiagnoseHospital { get; set; }
        public string TreatPlace { get; set; }
        public string TreatPlaceOther { get; set; }
        public DateTime? DiagnoseDate { get; set; }
        public string Medication { get; set; }
        public string MedicationAdvise { get; set; }
        public string DietAdvise { get; set; }
        public string PhysicalAdvise { get; set; }
        public string DrinkAdvise { get; set; }
        public string CureOther { get; set; }
        public string DepressurizationEffect { get; set; }
        public string BadLifeImprove { get; set; }
        public decimal? BloodHeight { get; set; }
        public decimal? BloodPre { get; set; }
        public string EateHabits { get; set; }
        public string MentalState { get; set; }
    }

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
        public int OutKey { get; set; }
    }
}