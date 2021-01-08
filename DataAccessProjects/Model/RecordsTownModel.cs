namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsTownModel
    {
        public string Code { get; set; }
        public int DistrictId { get; set; }
        public int ID { get; set; }
        public int IsDelete { get; set; }
        public string Name { get; set; }
    }
}

