using System;

namespace KangShuoTech.DataAccessProjects.Model
{
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
}

