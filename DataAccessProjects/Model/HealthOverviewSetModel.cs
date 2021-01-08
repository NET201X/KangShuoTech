using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
    public class HealthOverviewSetModel
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string maxValues { get; set; }
        public string minValues { get; set; }
        public string MaxEx { get; set; }
        public string MinEx { get; set; }
        public string Content { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }

    }
}
