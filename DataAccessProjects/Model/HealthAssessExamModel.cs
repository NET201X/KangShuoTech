using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
    public class HealthAssessExamModel
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string IDCardNo { get; set; }
        public string MedicalHistory { get; set; }
        public string FamilyHistory { get; set; }
        public string HospitalHistory { get; set; }
        public string TakingMedicine { get; set; }
        public string DietaryHabit { get; set; }
        public string DietaryNum { get; set; }
        public string DietaryLaw { get; set; }
        public string DietaryOther { get; set; }
        public string ExerciseExistense { get; set; }
        public string IsSmoke { get; set; }
        public string IsDrink { get; set; }
        public string ExerciseExistenseOther { get; set; }
        public string ExerciseRate { get; set; }
        public decimal? ExerciseTimes { get; set; }
        public string OldSelfCareability { get; set; }
        public decimal? GloomyScore { get; set; }
        public string MedicalOther { get; set; }
        public string FamilyOther { get; set; }
    }
}
