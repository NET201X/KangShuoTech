namespace KangShuoTech.DataAccessProjects.Model
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class VaccinationProgramModel
    {
        public int ID { get; set; }
        public string CustomerID { get; set; }
        public string RecordID { get; set; }
        public string IDCardNo { get; set; }
        public string VaccinationName { get; set; }
        public string VaccinationChild { get; set; }
        public decimal? VaccinationTimes { get; set; }
        public string VaccinationPart { get; set; } 
        public string VaccinationDoes { get; set; }
        public string Remark { get; set; }
        public string VaccineBatchNumber { get; set; }
        public string VaccinationDoctor { get; set; }
        public DateTime? VaccinationTime { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public RecordsStateModel ModelStatus { get; set; }
       
    }
}

