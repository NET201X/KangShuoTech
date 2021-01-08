using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    public class HealthGuidanceModel
    {
        public int? ID { get; set; }
        public string Title { get; set; }
        public string GreaterThanRecom { get; set; }
        public string LessThanRecom { get; set; }
        public string MiddleThanRecom { get; set; }
        public int? GuidanceID { get; set; }
        public string Code { get; set; }
        public string Sex { get; set; }
        public int? Type { get; set; }
    }
}
