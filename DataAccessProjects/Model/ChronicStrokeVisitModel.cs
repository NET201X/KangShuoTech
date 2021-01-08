using System;

namespace KangShuoTech.DataAccessProjects.Model
{
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

        //山东v2.0添加字段：Strokelocation,StrokeType,MedicalHistory,Syndrome,SyndromeOther,NewSymptom,NewSymptomOther,SmokeDay,DrinkDay,SportWeek,
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
        public string FollowupTypeOther { get; set; } //此次随访分类其

    }
}

