namespace KangShuoTech.DataAccessProjects.Model
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class RecordsRequiredModel
    {
        public string BTable { get; set; }
        public string Comment { get; set; }
        public int ID { get; set; }
        public decimal? IsRequired { get; set; }
        public decimal? Number { get; set; }
        public string Name { get; set; }
        public RecordsStateModel RcdState { get; set; }
    }
}