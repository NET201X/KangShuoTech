namespace KangShuoTech.DataAccessProjects.Model
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class RecordsMedicationModel
    {
        public int ID { get; set; }
        public string PhysicalID { get; set; }
        public string IDCardNo { get; set; }
        public string UseAge { get; set; }
        public string UseNum { get; set; }
        public string Num { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string PillDependence { get; set; }
        public string MedicinalName { get; set; }
        public string DrugType { get; set; }
        public string Factory { get; set; }
        public int OutKey { get; set; }
        public string Frequency { get; set; }
        public string UseNumUnit { get; set; }
        public string UseYear { get; set; }
        public string UseYearUnit { get; set; }
        public string OtherExplain { get; set; }
        public string NumUnit { get; set; }
        public string Remark { get; set; }
        public string DrugYear { get; set; }
        public string DrugMonth { get; set; }
        public string DrugDay { get; set; }
        public string FreUseNum { get; set; }
        public string FreUseDay { get; set; }
        public string UseDay { get; set; }
        public string Effect { get; set; }
        public string EffectDes { get; set; } 
        public string EachNum { get; set; }

        public RecordsStateModel ModelState { get; set; }

    }
}