namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsHealthQuestionModel
    {
        public string BrainDis { get; set; }
        public string BrainOther { get; set; }
        public string ElseDis { get; set; }
        public string ElseOther { get; set; }
        public string EyeDis { get; set; }
        public string EyeOther { get; set; }
        public string HeartDis { get; set; }
        public string HeartOther { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string NerveDis { get; set; }
        public string NerveOther { get; set; }
        public string PhysicalID { get; set; }
        public string RenalDis { get; set; }
        public string RenalOther { get; set; }
        public string VesselDis { get; set; }
        public string VesselOther { get; set; }
        public int OutKey { get; set; }
    }
}