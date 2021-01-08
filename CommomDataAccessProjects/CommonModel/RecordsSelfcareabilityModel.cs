using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    [Serializable]
    public class RecordsSelfcareabilityModel
    {
        public int ID { get; set; }
        public string CustomerID { get; set; }
        public string RecordID { get; set; }
        public string IDCardNo { get; set; }
        public decimal? Dine { get; set; }
        public decimal? Groming { get; set; }
        public decimal? Dressing { get; set; }
        public decimal? Tolet { get; set; }
        public decimal? Activity { get; set; }
        public decimal? TotalScore { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string FollowUpDoctor { get; set; }
        public DateTime? NextFollowUpDate { get; set; }
        public decimal? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? LastUpDateBy { get; set; }
        public DateTime? LastUpDateDate { get; set; }
        public string NextVisitAim { get; set; } 
        public string OutKey { get; set; }
    }
}
