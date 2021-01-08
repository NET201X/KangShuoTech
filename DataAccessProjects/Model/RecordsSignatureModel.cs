using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
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
        /// 责任医生签字
        /// </summary>
        public string DoctorSn { get; set; }

        /// <summary>
        /// 反馈时间
        /// </summary>
        public DateTime? FeedbackDate { get; set; }
        public int OutKey { get; set; }
        /// <summary>
        /// 血型，肝肾功能医生签字
        /// </summary>
        public string BloodLiverKidneySn { get; set; }

        /// <summary>
        /// 检查医生
        /// </summary>
        public string ExamineDoctor { get; set; }

        /// <summary>
        /// 心电图检查医生
        /// </summary>
        public string ECGExamineDoctor { get; set; }

        /// <summary>
        /// 中医体质辨识签字
        /// </summary>
        public string PhysiqueSn { get; set; }
    }
}
