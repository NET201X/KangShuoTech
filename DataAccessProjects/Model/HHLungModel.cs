﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
    public class HHLungModel
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string IDCardNo { get; set; }
        public DateTime? CheckDate { get; set; }
        public string ResultEx { get; set; }
        public string Result { get; set; }
        public string ImgPath { get; set; }
    }
}
