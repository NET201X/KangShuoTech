namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsAssessmentGuideModel
    {

        public int ID { get; set; }
        public string PhysicalID { get; set; }
        public string IDCardNo { get; set; }
        public string IsNormal { get; set; }
        public string Exception1 { get; set; }
        public string Exception2 { get; set; }
        public string Exception3 { get; set; }
        public string Exception4 { get; set; }
        public string HealthGuide { get; set; }
        public string DangerControl { get; set; }
        public string Arm { get; set; }
        public string VaccineAdvice { get; set; }
        public string Other { get; set; }
        public int OutKey { get; set; }
        public string Exception5 { get; set; }
        public string Exception6 { get; set; }
        public string WaistlineArm { get; set; }//¼õÑüÎ§Ä¿±êÖµ

    }
}

