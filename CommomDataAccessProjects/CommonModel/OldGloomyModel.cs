using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    [Serializable]
    public class OldGloomyModel
    {
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string Satisfied { get; set; }
        public string Hobby { get; set; }
        public string Emptiness { get; set; }
        public string Boring { get; set; }
        public string Hope { get; set; }
        public string Annoyance { get; set; }
        public string Spirit { get; set; }
        public string Fair { get; set; }
        public string Happy { get; set; }
        public string Helpless { get; set; }
        public string Calm { get; set; }
        public string Lazy { get; set; }
        public string Future { get; set; }
        public string Memory { get; set; }
        public string Life { get; set; }
        public string Mood { get; set; }
        public string Useless { get; set; }
        public string Worry { get; set; }
        public string Excitement { get; set; }
        public string Study { get; set; }
        public string Energy { get; set; }
        public string Present { get; set; }
        public string Feel { get; set; }
        public string Doing { get; set; }
        public string Cry { get; set; }
        public string Focus { get; set; }
        public string Morning { get; set; }
        public string Activity { get; set; }
        public string Decision { get; set; }
        public string Brain { get; set; }
        public string TotalScore { get; set; }
        public string RecordDate { get; set; }
        public string OldHealthStaus { get; set; }

        public DateTime? VisitDate { get; set; }
        public string VisitDoctor { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastUpDateBy { get; set; }
        public DateTime? LastUpDateDate { get; set; }
        public int OutKey { get; set; }
    }
}
