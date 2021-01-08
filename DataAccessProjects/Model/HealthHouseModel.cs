namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class HealthHouseModel
    {
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public DateTime? CheckDate { get; set; }
        public string BloodOxygen { get; set; }
        public decimal? PulseRate { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public decimal? BMI { get; set; }
        public decimal? LeftPre { get; set; }
        public decimal? LeftHeight { get; set; }
        public decimal? RightPre { get; set; }
        public decimal? RightHeight { get; set; }
        public decimal? LeftView { get; set; }
        public decimal? RightView { get; set; }
        public decimal? LeftEyecorrect { get; set; }
        public decimal? RightEyecorrect { get; set; }
        public decimal? Fat { get; set; }
        public decimal? Water { get; set; }
        public decimal? Muscle { get; set; }
        public decimal? Skeleton { get; set; }
        public decimal? Calorie { get; set; }
        public string Doctor { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdataBy { get; set; }
        public string ResultEx { get; set; }
        public string Result { get; set; }
        public string ImgPath { get; set; }
        public string CResultEx { get; set; }
        public string CResult { get; set; }
        public string CImgPath { get; set; }
        public string LResultEx { get; set; }
        public string LResult { get; set; }
        public string LImgPath { get; set; }
        public string CustomerName { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public string CHESTX { get; set; }
        public string CHESTXEx { get; set; }
        public string PRO { get; set; }
        public string GLU { get; set; }
        public string KET { get; set; }
        public string BLD { get; set; }
        public string ECG { get; set; }
        public string ECGEx { get; set; }
        public string BCHAO { get; set; }
        public string BCHAOEx { get; set; }
        public string BCHAOther { get; set; }
        public string BCHAOtherEx { get; set; }
    }
}

