using System;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
    public class KidsBaseInfoModel
    {
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string CreateUnit { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Guardstatus { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? OccurrenceTime { get; set; }
        public decimal? GuarderAge { get; set; }
        public decimal? CreatedBy { get; set; }
        public decimal? FatherAge { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public decimal? MotherAge { get; set; }
        public string MotherIdcard { get; set; }
        public string RecordID { get; set; }
        public string CardNum { get; set; }
        public string Childcare { get; set; }
        public string ChildcarePhone { get; set; }
        public string CreateUnitPhone { get; set; }
        public string CurrentUnit { get; set; }
        public string CustomerID { get; set; }
        public string FatherPhone { get; set; }
        public string FatherUnit { get; set; }
        public string GuarderName { get; set; }
        public string GuarderPhone { get; set; }
        public string MotherPhone { get; set; }
        public string GuarderUnit { get; set; }
        public string IsDel { get; set; }
        public decimal? MotherID { get; set; }
        public decimal? FatherID { get; set; }
        public string MotherName { get; set; }
        public string Addr { get; set; }
        public string FatherName { get; set; }
        public string MotherUnit { get; set; }
        public string Sex{ get; set; }
        public string PostalCode { get; set; }
    }
}

