namespace KangShuoTech.CommomDataAccessProjects.CommonModel
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

        //新增字段
        public string Exception5 { get; set; }
        public string Exception6 { get; set; }
        public string HealthGuideOther { get; set; }
        public string GuideOther { get; set; }
        public string VacciNum { get; set; }
        public string TCMGuide { get; set; }
        public string TCMGuideOther { get; set; }
        public string Referral { get; set; }
        public string Remark { get; set; }
        public string ReviewRecord { get; set; }
        public string WaistlineArm { get; set; }//减腰围目标值
    }
}

