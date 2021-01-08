using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
    public class HealthSelfCareabilityModel
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string IDCardNo { get; set; }
        public decimal? Dine { get; set; }
        public decimal? Groming { get; set; }
        public decimal? Dressing { get; set; }
        public decimal? Tolet { get; set; }
        public decimal? Activity { get; set; }
        public string CreatedBy { get; set; }
        public decimal? TotalScore { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastUpDateBy { get; set; }
        public DateTime? LastUpDateDate { get; set; }
    }
}
