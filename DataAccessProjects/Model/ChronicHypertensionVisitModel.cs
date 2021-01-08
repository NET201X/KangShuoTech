using System;

namespace KangShuoTech.DataAccessProjects.Model
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
        public decimal? HeartRate { get; set; }
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
        public decimal? Hight { get; set; }//身高
        public string DoctorView { get; set; }//此次随访医生建议
        public string IsReferral { get; set; }//转诊情况是否：1：是，2：否
        public string NextMeasures { get; set; }//下一步管理措施
        public string ReferralContacts { get; set; }//转诊联系人及电话
        public string ReferralResult { get; set; }//转诊结果
        public string Remarks { get; set; }//备注

    }

}

