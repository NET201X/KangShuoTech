namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsMediPhysDistModel
    {
        public string BloodStasis { get; set; }
        public string Characteristic { get; set; }
        public string Faint { get; set; }
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string Mild { get; set; }
        public string Muggy { get; set; }
        public string PhlegmDamp { get; set; }
        public string PhysicalID { get; set; }
        public string QiConstraint { get; set; }
        public string Yang { get; set; }
        public string Yin { get; set; }
        public int OutKey { get; set; }
        public int MedicineID { get; set; }
        public int MedicineResultID { get; set; }

    }
}