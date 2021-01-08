namespace KangShuoTech.DataAccessProjects.Model
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class RecordsInoculationHistoryModel
    {
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public DateTime? InoculationDate { get; set; }
        public string InoculationHistory { get; set; }
        public string PhysicalID { get; set; }
        public string PillName { get; set; }
        public int OutKey { get; set; }
        public RecordsStateModel ModelState { get; set; }
    }
}