using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
    public class HealthHouseMedicineCnModel
    {
        public int ID { get; set; }
        public string IDCardNo { get; set; }
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
        public string FollowUpDoctor { get; set; }
        public DateTime? RecordDate { get; set; }    
    }
}
