using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
    public class HealthHousePhysicalAssistCheckModel
    {
        public int? ID { get; set; }
        public string IDCardNo { get; set; }
        public string PRO { get; set; }
        public string GLU { get; set; }
        public string KET { get; set; }
        public string BLD { get; set; }
        public string UBG { get; set; }
        public string BIL { get; set; }
        public string PH { get; set; }
        public string NIT { get; set; }
        public string LEU { get; set; }
        public string SG { get; set; }
        public string VC { get; set; }
        public string ECG { get; set; }
        public string ECGEx { get; set; }
        public string CHESTX { get; set; }
        public string CHESTXEx { get; set; }
        public int PID { get; set; }
    }
}
