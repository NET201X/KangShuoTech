namespace KangShuoTech.DataAccessProjects.Model
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class RecordsFamilyInfoModel
    {
        public string RecordID { get; set; }
        public string CustomerName { get; set; }
        public string CreateUnit { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string FamilyRecordID { get; set; }
        public string HomeAddr { get; set; }
        public string HomeAddrInfo { get; set; }
        public decimal? HouseArea { get; set; }
        public string HouseType { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public decimal? IncomeAvg { get; set; }
        public string IsPoorfy { get; set; }
        public string LastUpDateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LiveStatus { get; set; }
        public decimal? Monthoil { get; set; }
        public decimal? MonthSalt { get; set; }
        public string ToiletType { get; set; }
    }
}