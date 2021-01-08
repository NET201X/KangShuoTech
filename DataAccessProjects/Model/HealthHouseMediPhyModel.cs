using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
     [Serializable]
    public class HealthHouseMediPhyModel
    {
        public string BloodStasis { get; set; }
        public string Characteristic { get; set; }
        public string Faint { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string Mild { get; set; }
        public string Muggy { get; set; }
        public string PhlegmDamp { get; set; }
        public string QiConstraint { get; set; }
        public string Yang { get; set; }
        public string Yin { get; set; }
        public int PID { get; set; }
        public int MedicineID { get; set; }
        public int MedicineResultID { get; set; }
    }
}
