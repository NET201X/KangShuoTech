using System;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    [Serializable]
    public class ChronicLungerFirstVisitModel
    {
        public int ID { get; set; }
        public int OUTKey { get; set; }
        public string RecordID { get; set; }
        public string IDCardNo { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime? FollowupDate { get; set; }
        public string VisitDoctor { get; set; }
        public string EstimateDoctor { get; set; }
        public string FollowupWay { get; set; }
        public string PatientType { get; set; }
        public string Sputumfungs { get; set; }
        public string DrugFast { get; set; }
        public string Symptom { get; set; }
        public string SymptomEx { get; set; }
        public string MedicationCompliance { get; set; }
        public string ChemotherapyScheme { get; set; }
        public string DrugType { get; set; }
        public string Supervisor { get; set; }
        public string StandaloneRoom { get; set; }
        public string Ventilation { get; set; }
        public decimal? SmokeDayNum { get; set; }
        public decimal? NextSmokeDayNum { get; set; }
        public decimal? DayDrinkVolume { get; set; }
        public decimal? NextDayDrinkVolume { get; set; }
        public DateTime? MediclineReceiveTime { get; set; }
        public string MediclineReceivePlace { get; set; }
        public string RecordcardWrite { get; set; }
        public string PharmacyWayDeposit { get; set; }
        public string Therapies { get; set; }
        public string IndisciplineHarm { get; set; }
        public string AdrsHandle { get; set; }
        public string SubsequentVisit { get; set; }
        public string InsistPharmacy { get; set; }
        public string LivingHabit { get; set; }
        public string ChecktouchPerson { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string IsDel { get; set; }
        public DateTime? VisitDate { get; set; }
        public string VisitWay { get; set; }
    }

    [Serializable]
    public class ChronicLungerVisitModel
    {
        public int ID { get; set; }
        public string RecordID { get; set; }
        public string IDCardNo { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime? FollowupDate { get; set; }
        public string VisitDoctor { get; set; }
        public string CureMonth { get; set; }
        public string Supervisor { get; set; }
        public string FollowupWay { get; set; }
        public string Symptom { get; set; }
        public string SymptomEx { get; set; }
        public decimal? SmokeDayNum { get; set; }
        public decimal? NextSmokeDayNum { get; set; }
        public decimal? DayDrinkVolume { get; set; }
        public decimal? NextDayDrinkVolume { get; set; }
        public string ChemotherapyScheme { get; set; }
        public string MedicationCompliance { get; set; }
        public string DrugType { get; set; }
        public int OmissiveTimes { get; set; }
        public string Adr { get; set; }
        public string AdrEx { get; set; }
        public string Complication { get; set; }
        public string ComplicationEx { get; set; }
        public string ReferralOrg { get; set; }
        public string ReferralReason { get; set; }
        public string ReferralResult { get; set; }
        public string HandleView { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public DateTime? StopCureDate { get; set; }
        public string StopCureReason { get; set; }
        public int ShouldVisitTimes { get; set; }
        public int VisitTimes { get; set; }
        public int ShouldPharmacyTimes { get; set; }
        public int PharmacyTimes { get; set; }
        public string EstimateDoctor { get; set; }
        public decimal? PharmacyRate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string IsDel { get; set; }
        public int VisitCount { get; set; }
        public int OutKey { get; set; }
        public DateTime? VisitDate { get; set; }
        public string VisitWay { get; set; }
    }
}
