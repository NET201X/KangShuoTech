namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsBaseInfoModel
    {
        public string RecordID { get; set; }
        public string IDCardNo { get; set; }
        public string CustomerID { get; set; }
        public decimal? OrgProvinceID { get; set; }
        public decimal? OrgCityID { get; set; }
        public decimal? OrgDistrictID { get; set; }
        public decimal? OrgTownID { get; set; }
        public decimal? OrgVillageID { get; set; }
        public decimal? ProvinceID { get; set; }
        public decimal? CityID { get; set; }
        public decimal? TownID { get; set; }
        public decimal? VillageID { get; set; }
        public string WorkUnit { get; set; }
        public string LiveType { get; set; }
        public string Nation { get; set; }
        public string Minority { get; set; }
        public string RH { get; set; }
        public string Culture { get; set; }
        public string Job { get; set; }
        public string MaritalStatus { get; set; }
        public string MedicalPayType { get; set; }
        public string MedicalPayTypeOther { get; set; }
        public string DrugAllergic { get; set; }
        public string DrugAllergicOther { get; set; }
        public string Disease { get; set; }
        public string DiseaseEx { get; set; }
        public string DiseasEndition { get; set; }
        public string DiseasEnditionEx { get; set; }
        public string CustomerName { get; set; }
        public string Doctor { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string BloodType { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string HouseHoldAddress { get; set; }
        public decimal? CreateUnit { get; set; }
        public string Exposure { get; set; }
        public string PopulationType { get; set; }
        public string FamilyIDCardNo { get; set; }
        public string HouseRelation { get; set; }
        public string HouseRealOther { get; set; }
        public string Email { get; set; }
        public string TownName { get; set; }
        public string VillageName { get; set; }
        public string CreateUnitName { get; set; }
        public string CreateMenName { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string IsUpdate { get; set; }
        public string IsDelete { get; set; }
        public decimal? DistrictID { get; set; }
        public string HouseID { get; set; }
        public string HouseName { get; set; }
        public int ID { get; set; }

        public string TownMedicalCard { get; set; }//城镇医保卡
        public string ResidentMedicalCard { get; set; }//居民医保卡
        public string PovertyReliefMedicalCard { get; set; }//贫困救助卡
        public string LiveCondition { get; set; }//居住情况
        public decimal? FamilyNum { get; set; }//家庭人口数
        public string FamilyStructure { get; set; }//家庭结构
        public string FamilyName { get; set; }//户主姓名

        public string PreSituation { get; set; }//孕产情况
        public string PreNum { get; set; }//孕次
        public string YieldNum { get; set; }//产次
        public string Chemical { get; set; }//化学品
        public string Poison { get; set; }//毒物
        public string Radial { get; set; }//射线

        public string ViewState { get; set; }// 健康指导查看状态

        public string PhysicalClass { get; set; }

    }
}