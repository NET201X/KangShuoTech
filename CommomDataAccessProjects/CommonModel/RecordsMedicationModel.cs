namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class RecordsMedicationModel
    {
        public int ID { get; set; }
        public string PhysicalID { get; set; }
        public string IDCardNo { get; set; }
        public string UseAge { get; set; }
        public string UseNum { get; set; }
        public string Num { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string PillDependence { get; set; }
        public string MedicinalName { get; set; }
        public string DrugType { get; set; }
        public string Factory { get; set; }
        public int OutKey { get; set; }
        public string Frequency { get; set; }
        public string UseNumUnit { get; set; }
        public string UseYear { get; set; }
        public string UseYearUnit { get; set; }
        public string OtherExplain { get; set; }
        public string NumUnit { get; set; }
        public string Remark { get; set; }
        public string DrugYear { get; set; }
        public string DrugMonth { get; set; }
        public string DrugDay { get; set; }
        public string FreUseNum { get; set; }
        public string FreUseDay { get; set; }
        public string UseDay { get; set; }
        public string Effect { get; set; }
        public string EffectDes { get; set; } 
        public string EachNum { get; set; }

        public RecordsStateModel ModelState { get; set; }
    }

    public class RecordsMediPhysDistModel
    {
        public int ID { get; set; }
        public string PhysicalID { get; set; }
        public string IDCardNo { get; set; }
        public string Mild { get; set; }
        public string Faint { get; set; }
        public string Yang { get; set; }
        public string Yin { get; set; }
        public string PhlegmDamp { get; set; }
        public string Muggy { get; set; }
        public string BloodStasis { get; set; }
        public string QiConstraint { get; set; }
        public string Characteristic { get; set; }
        public int OutKey { get; set; }
        public int MedicineID { get; set; }
        public int MedicineResultID { get; set; }
        public string MildOther { get; set; }
        public string FaintOther { get; set; }
        public string YangOther { get; set; }
        public string YinOther { get; set; }
        public string PhlegmDampOther { get; set; }
        public string MuggyOther { get; set; }
        public string BloodStasisOther { get; set; }
        public string QiConstraintOther { get; set; }
        public string CharacteristicOther { get; set; }
        public string ServerType { get; set; }

    }

    public class RecordsSignatureModel
    {
        public int ID { get; set; }
        public string PhysicalID { get; set; }
        public string IDCardNo { get; set; }
        /// <summary>
        /// 症状医师签名
        /// </summary>
        public string SymptomSn { get; set; }
        /// <summary>
        /// 一般情况医师签名
        /// </summary>
        public string GeneralConditionSn { get; set; }
        /// <summary>
        /// 生活方式医师签名
        /// </summary>
        public string LifeStyleSn { get; set; }
        /// <summary>
        /// 脏器功能医师签名
        /// </summary>
        public string OrgansFunctionSn { get; set; }
        /// <summary>
        /// 查体_眼底医师签名
        /// </summary>
        public string PEyebseSn { get; set; }
        /// <summary>
        /// 查体_皮肤、巩膜、淋巴结、肺、心脏、腹部、下肢水肿、足背动脉搏动医师签名
        /// </summary>
        public string PSkinSn { get; set; }
        /// <summary>
        /// 查体_肛门指诊医师签名
        /// </summary>
        public string PDigtalExamSn { get; set; }
        /// <summary>
        /// 查体_乳腺医师签名
        /// </summary>
        public string PBreastSn { get; set; }
        /// <summary>
        /// 查体_妇科医师签名
        /// </summary>
        public string PGynecologySn { get; set; }
        /// <summary>
        /// 查体_其他医师签名
        /// </summary>
        public string PhysicalQtSn { get; set; }
        /// <summary>
        /// 辅助检查_血型、血常规*、尿常规*、空腹血糖*、同型半胱氨酸*医师签名
        /// </summary>
        public string ABloodRoutineSn { get; set; }
        /// <summary>
        /// 辅助检查_尿微量白蛋白*、大便潜血*、糖化血红蛋白*、乙型肝炎表面抗原*肝功能*肾功能*血脂*医师签名
        /// </summary>
        public string AMAUSn { get; set; }
        /// <summary>
        /// 辅助检查_心电图*医师签名
        /// </summary>
        public string AECGSn { get; set; }
        /// <summary>
        /// 辅助检查_胸部X线片*医师签名
        /// </summary>
        public string AChestXraySn { get; set; }
        /// <summary>
        /// 辅助检查_腹部B超医师签名
        /// </summary>
        public string ABtypeUltrasonicSn { get; set; }
        /// <summary>
        /// 辅助检查_B超其他医师签名
        /// </summary>
        public string ABtypeQtSn { get; set; }
        /// <summary>
        /// 辅助检查_宫颈涂片*医师签名
        /// </summary>
        public string ASmearSn { get; set; }
        /// <summary>
        /// 辅助检查_其他医师签名
        /// </summary>
        public string AssistQtSn { get; set; }
        /// <summary>
        /// 现存主要健康问题与住院治疗情况医师签名
        /// </summary>
        public string InpatientCareSn { get; set; }
        /// <summary>
        /// 主要用药情况与非免疫规划预防接种史医师签名
        /// </summary>
        public string DrugNonimmunitySn { get; set; }
        /// <summary>
        /// 健康评价医师签名
        /// </summary>
        public string HealthAssessmentSn { get; set; }

        /// <summary>
        /// 健康指导医师签名
        /// </summary>
        public string HealthGuidanceSn { get; set; }
        /// <summary>
        /// 本人签字
        /// </summary>
        public string SelfSn { get; set; }
        /// <summary>
        /// 家属签字
        /// </summary>
        public string DependentSn { get; set; }
        /// <summary>
        /// 反馈人签字
        /// </summary>
        public string PersonalFb { get; set; }

        /// <summary>
        /// 反馈时间
        /// </summary>
        public DateTime? FeedbackDate { get; set; }
        public int OutKey { get; set; }
    }
}