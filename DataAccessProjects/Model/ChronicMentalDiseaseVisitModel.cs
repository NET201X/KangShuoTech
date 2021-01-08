using System;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
    public class ChronicMentalDiseaseVisitModel
    {
        public string AdnerDruReact { get; set; }       
        public string AdverDruReactHave { get; set; }
        public string RecordID { get; set; }
        public int AttemptSuicFrequen { get; set; }
        public string AttemptSuicideNone { get; set; }
        public int AutolesionFrequen { get; set; }
        public int CauseAccidFrequen { get; set; }
        public int CreateDistuFrequen { get; set; }
        public decimal? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CustomerID { get; set; }
        public string Diet { get; set; }
        public string Fatalness { get; set; }
        public string FollowupClassificat { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string FollowUpDoctor { get; set; }
        public string HospitalizatiStatus { get; set; }
        public string Housework { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string Insight { get; set; }
        public string IsDel { get; set; }
        public string LaborExaminati { get; set; }
        public string LaborExaminatiHave { get; set; }
        public DateTime? LastLeaveHospTime { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LearningAbility { get; set; }
        public string LockCondition { get; set; }
        public string MedicatioCompliance { get; set; }
        public int MildTroubleFrequen { get; set; }
        public DateTime? NextFollowUpDate { get; set; }
        public string PersonalCare { get; set; }
        public string PresentSymptoOther { get; set; }
        public string PresentSymptom { get; set; }
        public string ProductLaborWork { get; set; }
        public string ReferralAgencDepar { get; set; }
        public string ReferralReason { get; set; }
        public string RehabiliMeasu { get; set; }
        public string RehabiliMeasuOther { get; set; }
        public string SleepQuality { get; set; }
        public string SocialInterIntera { get; set; }
        public string TreatmentEffect { get; set; }
        public string WhetherReferral { get; set; }
        public string NoVisitReason { get; set; }//失访原因
        public DateTime? DeathDate { get; set; }//死亡日期
        public string IllReason { get; set; }//躯体疾病原因
        public string DeathReason { get; set; }//死亡原因
        public int OtherDangerFrequen { get; set; }//其他危害行为
        public string FollowUpType { get; set; }//随访方式
        public string JointPartFlag { get; set; }//是否通知联席部门
        public string PoliceAgent { get; set; }//公安部门受理人姓名
        public string PoliceAgentTel { get; set; }//公安部门受理电话
        public string CommunityAgent { get; set; }//社区综合中心受理人姓名
        public string CommunityAgentTel { get; set; }//社区综合中心电话
        public string ReferralResult { get; set; }//转诊是否成功
        public string ReferralOrgan { get; set; }//转诊机构
        public string ReferraContacts { get; set; }//转诊联系人
        public string ReferralContactsTel { get; set; }//转诊联系人电话
        public string ContactSpecialist { get; set; }//是否联系精神专科医师
        public string SpecialistName { get; set; }//精神专家姓名
        public string SpecialistTel { get; set; }//精神专家电话
        public string DisposalResult { get; set; }//处置结果
    }

}


