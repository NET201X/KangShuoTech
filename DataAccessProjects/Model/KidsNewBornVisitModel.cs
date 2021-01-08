using System;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
    public class KidsNewBornVisitModel
    {
        public int ID { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? FatherBirthday { get; set; }
        public DateTime? InterviewDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? MotherBirthday { get; set; }
        public DateTime? NextFollowupDate { get; set; }
        public decimal? InfantFrequen { get; set; }
        public decimal? GestationalWeek { get; set; }
        public decimal? BregmaLeft { get; set; }
        public decimal? BregmaRight { get; set; }
        public decimal? BirthStature { get; set; }
        public decimal? BirthWeight { get; set; }
        public decimal? BreathingRate { get; set; }
        public decimal? PresentWeight { get; set; }
        public decimal? NursingQuantity { get; set; }
        public decimal? PulseRate { get; set; }
        public decimal? StoolFrequen { get; set; }
        public decimal? Temperature { get; set; }
        public string Sex { get; set; }
        public string CustomerID { get; set; }
        public string RecordID { get; set; }
        public string IDCardNo { get; set; }
        public string HomeAddr { get; set; }
        public string FatherName { get; set; }
        public string FatherJob { get; set; }
        public string FatherTel { get; set; }
        public string MotherName { get; set; }
        public string MotherJob { get; set; }
        public string MotherTel { get; set; }
        public string PregnancPreva { get; set; }
        public string PregnancPrevaOther { get; set; }
        public string MidwifOrganizaName { get; set; }
        public string BirthInforma { get; set; }
        public string BirthInformaOther { get; set; }
        public string Aasphyxia { get; set; }
        public string Apgar { get; set; }
        public string WhetherAbnorma { get; set; }
        public string WhetherAbnormaHave { get; set; }
        public string HearingScreen { get; set; }
        public string DiseaseScreen { get; set; }
        public string DiseaseScreenOther { get; set; }
        public string FeedingPattern { get; set; }
        public string Vomit { get; set; }
        public string Stool { get; set; }
        public string ColourFace { get; set; }
        public string ColourFaceOther { get; set; }
        public string Jaundice { get; set; }
        public string Bregma { get; set; }
        public string BregmaOther { get; set; }
        public string EyeAppearance { get; set; }
        public string EyeAppearanceEx { get; set; }
        public string LimbsActivity { get; set; }
        public string LimbsActivityEx { get; set; }
        public string EarAppearance { get; set; }
        public string EarAppearanceEx { get; set; }
        public string NeckMass { get; set; }
        public string NeckMassHave { get; set; }
        public string Nose { get; set; }
        public string NoseEx { get; set; }
        public string Skin { get; set; }
        public string SkinOther { get; set; }
        public string MouthCavity { get; set; }
        public string MouthCavityEx { get; set; }
        public string Anus { get; set; }
        public string AnusEx { get; set; }
        public string HeartLungAuscul { get; set; }
        public string HeartLungAusculEx { get; set; }
        public string Aedea { get; set; }
        public string AedeaEx { get; set; }
        public string AbdominalTouch { get; set; }
        public string AbdominalTouchEx { get; set; }
        public string Spine { get; set; }
        public string SpineEx { get; set; }
        public string UmbilicalCord { get; set; }
        public string UmbilicalCordOther { get; set; }
        public string ReferralAdvice { get; set; }
        public string ReferralReason { get; set; }
        public string AgenciesDepartments { get; set; }
        public string Guidance { get; set; }
        public string NextFollowupPlace { get; set; }
        public string FollowUpDoctorSign { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public string IsDel { get; set; }
        //山东v2.0添加字段
        public decimal? Apgar1 { get; set; }
        public decimal? Apgar5 { get; set; }
        public string FatherID { get; set; }//父亲身份证号
        public string MotherID { get; set; }//母亲身份证号
        public string Chest { get; set; }//胸部
        public string ChestEx { get; set; }//胸部其他
        public string GuidanceOther { get; set; }//指导其他
        public string ReferralOrgan { get; set; }//转诊机构
        public string ReferraContacts { get; set; }//转诊联系人
        public string ReferralContactsTel { get; set; }//转诊联系人电话
        public string ReferralResult { get; set; }//转诊结果时
    }
}

