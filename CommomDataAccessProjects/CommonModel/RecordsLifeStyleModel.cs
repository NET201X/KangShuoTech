namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;

    [Serializable]
    public class RecordsLifeStyleModel
    {
        public string CareerHarmFactorHistory { get; set; }
        public string Chem { get; set; }
        public string ChemProtect { get; set; }
        public string ChemProtectEx { get; set; }
        public decimal? DayDrinkVolume { get; set; }
        public string DrinkRate { get; set; }
        public decimal? DrinkStartAge { get; set; }
        public string DrinkThisYear { get; set; }
        public string DrinkType { get; set; }
        public string DrinkTypeOther { get; set; }
        public string Dust { get; set; }
        public string DustProtect { get; set; }
        public string DustProtectEx { get; set; }
        public string DietaryHabit { get; set; }
        public decimal? ExcisepersistTime { get; set; }
        public string ExerciseExistense { get; set; }
        public string ExerciseRate { get; set; }
        public decimal? ExerciseTimes { get; set; }
        public string Radiogen { get; set; }
        public string RadiogenProtect { get; set; }
        public string RadiogenProtectEx { get; set; }
        public decimal? ForbiddonAge { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string IsDrinkForbiddon { get; set; }
        public string Other { get; set; }
        public string OtherProtect { get; set; }
        public string OtherProtectEx { get; set; }
        public string Physical { get; set; }
        public string PhysicalID { get; set; }
        public string PhysicalProtect { get; set; }
        public string PhysicalProtectEx { get; set; }
        public decimal? SmokeAgeForbiddon { get; set; }
        public decimal? SmokeAgeStart { get; set; }
        public string SmokeCondition { get; set; }
        public decimal? SmokeDayNum { get; set; }
        public decimal? WorkTime { get; set; }
        public string WorkType { get; set; }
        public int OutKey { get; set; }
        public string ExerciseExistenseOther { get; set; } 
    }
}