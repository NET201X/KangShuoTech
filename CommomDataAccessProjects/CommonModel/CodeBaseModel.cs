using System;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    [Serializable]
    public class CodeBaseModel
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public string CodeNo { get; set; }
        public string CodeName { get; set; }
        public string CodeRemark { get; set; }
        public int CodeSeq { get; set; }
        public int CodeValue { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
    }
}

