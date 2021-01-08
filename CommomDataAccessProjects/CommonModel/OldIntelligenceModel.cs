using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    [Serializable]
    public class OldIntelligenceModel
    {
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string DirectionalOne { get; set; }
        public string DirectionalTwo { get; set; }
        public string Memory { get; set; }
        public string Attention { get; set; }
        public string RecallAbility { get; set; }
        public string NamingAbility { get; set; }
        public string RetellAbility { get; set; }
        public string Comprehension { get; set; }
        public string ReadAbility { get; set; }
        public string WriteAbility { get; set; }
        public string StructureAbility { get; set; }
        public string TotalScore { get; set; }
        public string RecordDate { get; set; }

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
