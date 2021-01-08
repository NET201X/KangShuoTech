namespace KangShuoTech.DataAccessProjects.Model
{
    using System;
    [Serializable]
    public class ConsulationDoctorsModel
    {
        public int ID { set; get; }
        public int OutKey { set; get; }
        public string ConsultationUnitName { set; get; }
        public string ConsultationDoctor1 { set; get; }
        public string ConsultationDoctor2 { set; get; }
        public string ConsultationDoctor3 { set; get; }
    }
}
