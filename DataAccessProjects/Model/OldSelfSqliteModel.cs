using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
    public class OldSelfSqliteModel
    {
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public decimal? Dine { get; set; }
        public decimal? Groming { get; set; }
        public decimal? Dressing { get; set; }
        public decimal? Tolet { get; set; }
        public decimal? Activity { get; set; }
        public decimal? TotalScore { get; set; }
        public DateTime? RecordDate { get; set; }
    }
}
