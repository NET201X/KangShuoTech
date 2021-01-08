
namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsHyperFoodsModel
    {
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string FoodName { get; set; }
        public string EatYesNo { get; set; }
        public decimal? DayBeats { get; set; }
        public decimal? WeekBeats { get; set; }
        public decimal? MouthBeats { get; set; }
        public decimal? SaltSumBeats { get; set; }

        public RecordsStateModel ModelState { get; set; }
        public int OutKey { get; set; }
    }
}
