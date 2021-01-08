

namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsHyperSurveyModel
    {
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public decimal? EatPersonSum { get; set; }
        public decimal? EatChildSum { get; set; }
        public decimal? EatSaltQuantity { get; set; }
        public decimal? EatSoyQuntity { get; set; }
        public int OutKey { get; set; }
    }
}
