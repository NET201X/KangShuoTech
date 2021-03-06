﻿using System;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
    public class KidsTcmhmOneModel
    {
        public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? FollowupDate { get; set; }
        public DateTime? NextFollowDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public decimal? CreatedBy { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public string CustomerID { get; set; }
        public string RecordID { get; set; }
        public string FollowupType { get; set; }
        public string Tcmhm { get; set; }
        public string TcmhmOther { get; set; }
        public string FollowDoctor { get; set; }
        public string IsDel { get; set; }
        public string IDCardNo { get; set; }
        public RecordsStateModel ModelState { get; set; }
    }
}

