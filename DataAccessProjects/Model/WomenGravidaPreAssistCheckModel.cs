namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class WomenGravidaPreAssistCheckModel
    {

        public int ID { get; set; }
        public string CustomerID { get; set; }
        public string RecordID { get; set; }
        public string IDCardNo { get; set; }
        public decimal? HB { get; set; }
        public decimal? WBC { get; set; }
        public decimal? PlT { get; set; }
        public string BloodOther { get; set; }
        public string PRO { get; set; }
        public string GLU { get; set; }
        public string KET { get; set; }
        public string BLD { get; set; }
        public string UrineOthers { get; set; }
        public string BloodType { get; set; }
        public string RH { get; set; }
        public decimal? FPGL { get; set; }
        public decimal? SGPT { get; set; }
        public decimal? GOT { get; set; }
        public decimal? BP { get; set; }
        public decimal? TBIL { get; set; }
        public decimal? CB { get; set; }
        public decimal? SCR { get; set; }
        public decimal? BUN { get; set; }
        public string VaginalSecretions { get; set; }
        public string VaginalSecretionSothers { get; set; }
        public string VaginalCleaess { get; set; }
        public string HBSAG { get; set; }
        public string HBSAB { get; set; }
        public string HBEAG { get; set; }
        public string HBEAB { get; set; }
        public string HBCAB { get; set; }
        public string LUES { get; set; }
        public string HIV { get; set; }
        public string BCHAO { get; set; }
        public decimal? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string IsDel { get; set; }
        public string AssistOther { get; set; }//辅助检查其他
    }
}

