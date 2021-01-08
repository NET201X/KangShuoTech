namespace KangShuoTech.DataAccessProjects.Model
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class ChronicDrugConditionModel
    {
        public decimal? DailyTime { get; set; }

        public string DosAge { get; set; } //用法用量

        public string EveryTimeMg { get; set; }
   
        public int ID { get; set; }

        public string IDCardNo{get; set;}

        public RecordsStateModel ModelState { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string drugtype { get; set; }

        public string factory { get; set; }

        public int OUTKey { get; set; }
    }
}

