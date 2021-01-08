namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;

    [Serializable]
    public class RecordsGeneralConditionModel
    {
        public decimal? BMI { get; set; }
        public decimal? BreathRate { get; set; }
        public decimal? GloomyScore { get; set; }
        public decimal? Height { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public decimal? InterScore { get; set; }
        public decimal? LeftHeight { get; set; }
        public decimal? LeftPre { get; set; }
        public string OldEmotion { get; set; }
        public string OldHealthStaus { get; set; }
        public string OldRecognise { get; set; }
        public string OldSelfCareability { get; set; }
        public string PhysicalID { get; set; }
        public decimal? PulseRate { get; set; }

        //public int? RightHeight { get; set; }
        public decimal? RightHeight { get; set; }
        public decimal? RightPre { get; set; }
        public decimal? AnimalHeat { get; set; }
        public decimal? WaistIp { get; set; }
        public decimal? Waistline { get; set; }
        public decimal? Weight { get; set; }
        public decimal? OutKey { get; set; }
        public int SelfID { get; set; }
        public string CheckDate { get; set; }

        //ÐÂÔö×Ö¶Î
        public decimal? Tem { get; set; }
        public string RightReason { get; set; }
        public string LeftReason { get; set; }
        public string OldMange { get; set; }
        public decimal? Hipline { get; set; }
    }
}