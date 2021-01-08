
namespace KangShuoTech.DataAccessProjects.Model
{
    using System;
    [Serializable]
    public class RecordsEcgModel
    {
        public int ID { get; set; }
        public string MID { get; set; }
        public string IDCardNo { get; set; }
        public string Name { get; set; }
        public string Conclusion { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
