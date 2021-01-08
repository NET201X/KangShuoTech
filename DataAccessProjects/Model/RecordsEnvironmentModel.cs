namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsEnvironmentModel
    {
        public int ID { get; set; }
        public string RecordID { get; set; }
        public string BlowMeasure { get; set; }
        public string DrinkWater { get; set; }
        public string FuelType { get; set; }
        public string IDCardNo { get; set; }
        public string LiveStockRail { get; set; }
        public string Toilet { get; set; }

        public DateTime? SignDate { get; set; }//Ç©×ÖÈÕÆÚ

    }
}