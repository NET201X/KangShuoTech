using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
    public class HealthAssessModel
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string IDCardNo { get; set; }
        public string BasicTest { get; set; }
        public string Blood { get; set; }
        public string PulseRate { get; set; }
        public string Oxygen { get; set; }
        public string Urine { get; set; }
        public string ChestX { get; set; }
        public string BSuper { get; set; }
        public string ECG { get; set; }
        public string Cardiovascular { get; set; }
        public string Lung { get; set; }
        public string Bone { get; set; }
        public string TCMConstitution { get; set; }
        public string Overview { get; set; }
        public string CreateBy { get; set; }
        public string UpdataBy { get; set; }
        public DateTime? CheckDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
