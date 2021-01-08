namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class ChronicDiadetesVisitModel
    {
        public string Adr { get; set; }
        public string AdrEx { get; set; }
        public string RecordID { get; set; }
        public string AssistantExam { get; set; }
        public decimal? BMI { get; set; }
        public decimal? BMITarget { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public decimal? DailyDrinkNum { get; set; }        
        public decimal? DailyDrinkNumTarget { get; set; }
        public decimal? DailySmokeNum { get; set; }
        public decimal? DailySmokeNumTarget { get; set; }
        public decimal? DorsalisPedispulse { get; set; }
        public DateTime? ExamDate { get; set; }
        public DateTime? VisitDate { get; set; }
        public string VisitDoctor { get; set; }
        public string VisitType { get; set; }
        public string VisitWay { get; set; }
        public decimal? FPG { get; set; }
        public decimal? HbAlc { get; set; }
        public decimal? Hypertension { get; set; }
        public string HypoglyceMiarreAction { get; set; }
        public decimal? Hypotension { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string InsulinType { get; set; }
        public string InsulinUsage { get; set; }
        public string IsDelete { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string MedicationCompliance { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public string ObeyDoctorBehavior { get; set; }
        public string PhysicalSymptomMother { get; set; } //体征其他
        public string PsychoAdjustment { get; set; }
        public string ReferralOrg { get; set; }
        public string ReferralReason { get; set; }
        public decimal? SportPerMinuteTimeTarget { get; set; }
        public decimal? SportPerMinuteTime { get; set; }
        public decimal? SportTimePerWeek { get; set; }
        public decimal? SportTimePerWeekTarget { get; set; }
        public decimal? MyProperty { get; set; }
        public decimal? StapleFooddailyg { get; set; }
        public decimal? StapleFooddailygTarget { get; set; }
        public string Symptom { get; set; }
        public string SymptomOther { get; set; }
        public decimal? Weight { get; set; }
        public decimal? TargetWeight { get; set; }

        public decimal? Hight { get; set; }//身高
        public string DoctorView { get; set; }//此次随访医生建议
        public string IsReferral { get; set; }//转诊情况是否：1：是，2：否
        public decimal? RBG { get; set; }//随机血糖
        public decimal? PBG { get; set; }//餐后2小时血糖

        public string NextMeasures { get; set; }//下一步管理措施
        public string ReferralContacts { get; set; }//转诊联系人及电话
        public string ReferralResult { get; set; }//转诊结果
        public string Remarks { get; set; }//备注
        public string DorsalisPedispulseType { get; set; }//足背动脉类型
        public string InsulinAdjustType { get; set; }//胰岛素调整类型
        public string InsulinAdjustUsage { get; set; }//胰岛素调整用量
    }
}

