namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;

    [Serializable]
    public class OlderMedicineCnModel
    {
        public int ID { get; set; }
        public int OutKey { get; set; }
        public string RecordID { get; set; }
        public string IDCardNo { get; set; }
        public string CustomerID { get; set; }
        public string PhysicalID { get; set; }
        public decimal? Energy { get; set; }
        public decimal? Tired { get; set; }
        public decimal? Breath { get; set; }
        public decimal? Voice { get; set; }
        public decimal? Emotion { get; set; }
        public decimal? Spirit { get; set; }
        public decimal? Alone { get; set; }
        public decimal? Fear { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Eye { get; set; }
        public decimal? FootHand { get; set; }
        public decimal? Stomach { get; set; }
        public decimal? Cold { get; set; }
        public decimal? Influenza { get; set; }
        public decimal? Nasal { get; set; }
        public decimal? Snore { get; set; }
        public decimal? Allergy { get; set; }
        public decimal? Urticaria { get; set; }
        public decimal? Skin { get; set; }
        public decimal? Scratch { get; set; }
        public decimal? Mouth { get; set; }
        public decimal? Arms { get; set; }
        public decimal? Greasy { get; set; }
        public decimal? Spot { get; set; }
        public decimal? Eczema { get; set; }
        public decimal? Thirsty { get; set; }
        public decimal? Smell { get; set; }
        public decimal? Abdomen { get; set; }
        public decimal? Coolfood { get; set; }
        public decimal? Defecate { get; set; }
        public decimal? Defecatedry { get; set; }
        public decimal? Tongue { get; set; }
        public decimal? Vein { get; set; }
        public decimal? CreatedBy { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public string FollowUpDoctor { get; set; }
        public string IsDel { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? RecordDate { get; set; }      
    }

    public class OlderMedicineResultModel
    {
        public int ID { get; set; }
        public int OUTkey { get; set; }
        public string PhysicalID { get; set; }
        public decimal? MedicineID { get; set; }
        public string Mild { get; set; }
        public string Faint { get; set; }
        public string Yang { get; set; }
        public string Yin { get; set; }
        public string PhlegmDamp { get; set; }
        public string Muggy { get; set; }
        public string BloodStasis { get; set; }
        public string QiConstraint { get; set; }
        public string Characteristic { get; set; }
        public decimal? MildScore { get; set; }
        public decimal? FaintScore { get; set; }
        public decimal? YangsCore { get; set; }
        public decimal? YinScore { get; set; }
        public decimal? PhlegmdampScore { get; set; }
        public decimal? MuggyScore { get; set; }
        public decimal? BloodStasisScore { get; set; }
        public decimal? QiConstraintScore { get; set; }
        public decimal? CharacteristicScore { get; set; }
        public string MildAdvising { get; set; }
        public string FaintAdvising { get; set; }
        public string YangAdvising { get; set; }
        public string YinAdvising { get; set; }
        public string PhlegmdampAdvising { get; set; }
        public string MuggyAdvising { get; set; }
        public string BloodStasisAdvising { get; set; }
        public string QiconstraintAdvising { get; set; }
        public string CharacteristicAdvising { get; set; }
        public string MildAdvisingEx { get; set; }
        public string FaintAdvisingEx { get; set; }
        public string YangadvisingEx { get; set; }
        public string YinAdvisingEx { get; set; }
        public string PhlegmdampAdvisingEx { get; set; }
        public string MuggyAdvisingEx { get; set; }
        public string BloodStasisAdvisingEx { get; set; }
        public string QiconstraintAdvisingEx { get; set; }
        public string CharacteristicAdvisingEx { get; set; }
        public string IsDel { get; set; }
        public string IDCardNo { get; set; }
        public DateTime? RecordDate { get; set; }

        //新增字段
        public string EffectAssess { get; set; }
        public string Satisfy { get; set; }
    }
}