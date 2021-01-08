namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsVisceraFunctionModel
    {
        public int? ID { get; set; }
        public string PhysicalID { get; set; }
        public string IDCardNo { get; set; }
        public string Lips { get; set; }
        public string ToothResides { get; set; }
        public string Pharyngeal { get; set; }
        public decimal? LeftView { get; set; }
        public string Listen { get; set; }
        public decimal? RightView { get; set; }
        public string SportFunction { get; set; }
        public decimal? LeftEyecorrect { get; set; }
        public decimal? RightEyecorrect { get; set; }
        public int OutKey { get; set; }
        public string HypodontiaEx { get; set; }
        public string SaprodontiaEx { get; set; }
        public string DentureEx { get; set; }
        public string LipsEx { get; set; }
        public string PharyngealEx { get; set; }
        public string LeftViewEx { get; set; }
        public string RightViewEx { get; set; }
        public string LeftEye { get; set; }
        public string RightEye { get; set; }
        public string ToothResidesOther { get; set; }
        // ¼ì²éÈÕÆÚ
        public string RecordDate { get; set; }

    }
}