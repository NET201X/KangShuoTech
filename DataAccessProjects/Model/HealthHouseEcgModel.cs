using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
    public class HealthHouseEcgModel
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string MID { get; set; }
        public string IDCardNo { get; set; }
        public string Name { get; set; }
        public string Conclusion { get; set; }
        public DateTime? CreateTime { get; set; }
        public string ECG { get; set; }
        public string ECGEx { get; set; }
        public string ImgPath { get; set; }
    }
}
