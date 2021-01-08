namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

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

        //v2.0添加字段 ChdType,Height,BMI,FPGL,TC,TG,LowCho,HeiCho,EcgCheckResult,EcgExerciseResult,CAG,EnzymesResult,HeartCheckResult,SmokeDay,DrinkDay,
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
}

