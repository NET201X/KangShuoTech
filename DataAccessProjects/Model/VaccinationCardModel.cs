namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class VaccinationCardModel
    {
        public int ID { get; set; }
        public string CustomerID { get; set; }
        public string RecordID { get; set; }
        public string IDCardNo { get; set; }
        public string VaccinationCardID { get; set; }
        public string Guardian { get; set; }
        public string Relation { get; set; }
        public string Phone { get; set; }
        public string HomeAddress { get; set; }
        public string HouseHoldAddress { get; set; }
        public DateTime? VaccinationInTime { get; set; }
        public DateTime? VaccinationOutTime { get; set; }
        public string VaccinationOutReason { get; set; }
        public string VaccinationReaction { get; set; }
        public string VaccinationTaboo { get; set; }
        public string VaccinationIllHistory { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string IsDelete { get; set; }
        public string VaccinationExpHistory { get; set; }


    }
}

