namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsVillageModel
    {
        public string Code { get; set; }
        public string ID { get; set; }
        public int IsDelete { get; set; }
        public string Name { get; set; }
        public int TownID { get; set; }

    }
}

