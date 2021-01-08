namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsEducationActivitiesModel
    {
        public string Activity { get; set; }
        public string ActivityAddress { get; set; }
        public string ActivityContent { get; set; }
        public DateTime? ActivityDate { get; set; }
        public string ActivityTheme { get; set; }
        public string ActivityType { get; set; }
        public string RecordID { get; set; }
        public string AttachmentType { get; set; }
        public decimal CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CustomerID { get; set; }
        public string DataFileNumber { get; set; }
        public string EducationClasses { get; set; }
        public decimal? EducationNumber { get; set; }
        public DateTime? FillformTime { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string InformationPerson { get; set; }
        public decimal LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Planner { get; set; }
        public string ResponsiblePerson { get; set; }


    }
}