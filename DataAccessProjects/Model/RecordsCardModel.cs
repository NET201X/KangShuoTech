namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsCardModel
    {

        public string AllergicHistory { get; set; }
        public string RecordID { get; set; }
        public DateTime? Birthday { get; set; }
        public string BloodType { get; set; }
        public string ChronicDiseases { get; set; }
        public string ChronicDiseasesOther { get; set; }
        public string CustomerID { get; set; }
        public string Doctor { get; set; }
        public string DoctorPhone { get; set; }
        public string HomeAddr { get; set; }
        public string HomePhone { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string Name { get; set; }
        public string OrgName { get; set; }
        public string OrgPhone { get; set; }
        public string Other { get; set; }
        public string RH { get; set; }
        public string Sex { get; set; }
        public string UrgentName { get; set; }
        public string UrgentPhone { get; set; }

    }
}