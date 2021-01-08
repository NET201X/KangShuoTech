namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsCustomerBaseInfoModel
    {
        public DateTime? CheckDate { get; set; }
        public decimal? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CustomerID { get; set; }
        public string Doctor { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string IsDel { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string Other { get; set; }
        public string PhysicalID { get; set; }
        public string Symptom { get; set; }

        //ÐÂÔö×Ö¶Î
        public string PhysicalType { get; set; }
        public string PhysicalStyle { get; set; }
        public string PhysicalClass { get; set; }
        public string CheckType { get; set; }
        public DateTime? NextDate { get; set; }
        public string TDataSource { get; set; }
        public string PhyNo { get; set; }
    }
}