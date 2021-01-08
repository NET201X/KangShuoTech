namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class WomenGravidaPostpartumModel
    {
        public int ID { get; set; }
        public string CustomerID { get; set; }
        public string RecordID { get; set; }
        public string IDCardNo { get; set; }
        public DateTime? FollowupDate { get; set; }
        public decimal? Tem { get; set; }
        public string HealthCondition { get; set; }
        public string Mentalcondition { get; set; }
        public decimal? HBbloodPressure { get; set; }
        public decimal? LBloodPressure { get; set; }
        public string Breast { get; set; }
        public string BreastEx { get; set; }
        public string Lochia { get; set; }
        public string LochiaEx { get; set; }
        public string Uterus { get; set; }
        public string UterusEx { get; set; }
        public string Wound { get; set; }
        public string WoundEx { get; set; }
        public string Other { get; set; }
        public string Classification { get; set; }
        public string ClassificationEx { get; set; }
        public string Advising { get; set; }
        public string AdvisingOther { get; set; }
        public string Referral { get; set; }
        public string ReferralReason { get; set; }
        public string ReferralOrg { get; set; }
        public DateTime? NextFollowupDate { get; set; }
        public string FollowupDoctor { get; set; }
        public decimal? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string IsDel { get; set; }

        public DateTime? DeliveryDate { get; set; }//分娩日期
        public DateTime? LeaveHospitalDate { get; set; }//出院日期
        public string ReferralContacts { get; set; }//转诊联系人
        public string ReferralContactsTel { get; set; }//转诊联系人电话
        public string ReferralResult { get; set; }//转诊结果

    }
}

