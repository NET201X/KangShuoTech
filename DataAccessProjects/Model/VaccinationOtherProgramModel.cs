namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class VaccinationOtherProgramModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal ProvinceID { get; set; }
        public decimal? CityID { get; set; }
        public decimal? DistrictID { get; set; }
        public decimal? TownID { get; set; }
        public decimal? VillageID { get; set; }
        public decimal? Times { get; set; }

    }
}

