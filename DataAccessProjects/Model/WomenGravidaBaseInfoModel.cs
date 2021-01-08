namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class WomenGravidaBaseInfoModel
    {
        public int ID { get; set; }
        public string CustomerID { get; set; }
        public string RecordID { get; set; }
        public string IDCardNo { get; set; }
        public string Name { get; set; }
        public decimal? Age { get; set; }
        public string Culture { get; set; }
        public string Job { get; set; }
        public string Address { get; set; }
        public string Nation { get; set; } 
        public DateTime? Birthday { get; set; }
        public string Living { get; set; }
        public string Phone { get; set; }
        public string HealthResot { get; set; }
        public string TownName { get; set; }
        public string VillageName { get; set; }
        public string PwPhone { get; set; }
        public string HusbandName { get; set; }
        public string HusbandPhone { get; set; } 
        public decimal? CurrentUnit { get; set; }
        public decimal? CreateUnit { get; set; }
        public decimal? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string IsDel { get; set; }
        public string HouseholdTown { get; set; }
        public string HouseholdVillage { get; set; }
        public string AddrTown { get; set; }
        public string AddrVillage { get; set; }
        public string AddrPhone { get; set; }
        public string WorkUnit { get; set; }
        public string UnitPhone { get; set; }
        public decimal? HusbandAge { get; set; }
        public string HusbandCulture { get; set; }
        public string HusbandNation { get; set; }
        public string HusbandUnit { get; set; }
        public string HbUnitPhone { get; set; }
        public string HusbandJob { get; set; }
        public string CardNum { get; set; }
        public string CreatePhone { get; set; }
        public DateTime? CreateDate { get; set; }   
    }
}

