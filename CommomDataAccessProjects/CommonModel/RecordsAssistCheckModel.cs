namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;

    [Serializable]
    public class RecordsAssistCheckModel
    {
        public string PhysicalID { get; set; }
        public decimal? HB { get; set; }
        public decimal? WBC { get; set; }
        public decimal? PLT { get; set; }
        public string BloodOther { get; set; }
        public string PRO { get; set; }
        public string GLU { get; set; }
        public string KET { get; set; }
        public string BLD { get; set; }
        public string UrineOther { get; set; }
        public decimal? FPGL { get; set; }
        public decimal? FPGDL { get; set; }
        public string ECG { get; set; }
        public string ECGEx { get; set; }
        public decimal? ALBUMIN { get; set; }
        public string FOB { get; set; }
        public decimal? HBALC { get; set; }
        public string HBSAG { get; set; }
        public decimal? SGPT { get; set; }
        public decimal? GOT { get; set; }
        public decimal? BP { get; set; }
        public decimal? TBIL { get; set; }
        public decimal? CB { get; set; }
        public decimal? SCR { get; set; }
        public decimal? BUN { get; set; }
        public decimal? PC { get; set; }
        public decimal? HYPE { get; set; }
        public decimal? TC { get; set; }
        public decimal? TG { get; set; }
        public decimal? LowCho { get; set; }
        public decimal? HeiCho { get; set; }
        public string CHESTX { get; set; }
        public string CHESTXEx { get; set; }
        public string BCHAO { get; set; }
        public string BCHAOEx { get; set; }
        public string CERVIX { get; set; }
        public string CERVIXEx { get; set; }
        public string Other { get; set; }
        public decimal? GT { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public int OutKey { get; set; }
        public string BCHAOther { get; set; } //B超其他
        public string BCHAOtherEx { get; set; }//B超异常其他
        public string ProstBladBChao { get; set; }
        public string ProstBladBChaoEx { get; set; }
        public string BreastBChao { get; set; }
        public string BreastBChaoEx { get; set; }

        //新增字段
        public string UA { get; set; }
        public string BloodType { get; set; }
        public string RH { get; set; }
        public decimal? HCY { get; set; }
        public decimal? TP { get; set; }
        public decimal? GLB { get; set; }
        public decimal? AG { get; set; }
        public decimal? IBIL { get; set; }
        public decimal? PPGL { get; set; }
        public string AFPR { get; set; }
        public decimal? AFP { get; set; }
        public string AntigenR { get; set; }
        public decimal? Antigen { get; set; }
        public string OtherType { get; set; }
        public decimal? FPGDL2 { get; set; }
        public decimal? PPGL2 { get; set; }
        public decimal? Uric { get; set; }
        public string RoutineCheck { get; set; }
        public string UrineCheck { get; set; }
        public string SugarCheck { get; set; }
        public string LiverCheck { get; set; }
        public string KidneyCheck { get; set; }
        public string FatCheck { get; set; }
        public string ASTALT { get; set; }
        public string ALP { get; set; }
        public string RecordDate { get; set; }
        public string TestTime { get; set; }
    }
}