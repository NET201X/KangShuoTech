using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
    public class HealthHouseBCHAOModel
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string IDCardNo { get; set; }
        public string BCHAO { get; set; }
        public string BCHAOEx { get; set; }
        public string BCHAOther { get; set; }
        public string BCHAOtherEx { get; set; }
        public string ImgPath { get; set; }
    }
}
