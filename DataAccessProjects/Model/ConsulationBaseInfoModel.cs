
namespace KangShuoTech.DataAccessProjects.Model
{
    using System;
    [Serializable]

    public class ConsulationBaseInfoModel
    {
        public int ID { set; get; }
        public string CustomerName { set; get; }
        public string Sex { set; get; }
        public string IDCardNo { set; get; }
        public string Address { set; get; }
        public string Reason { set; get; }
        public string View { set; get; }
        public string ResponsibilityDoctor { set; get; }
        public string CreateMenName { set; get; }
        public string CreateUnitName { set; get; }
        public string UpdateUnitName { set; get; }
        public string UpdatePerson { set; get; }
        public DateTime? UpdateDate { set; get; }
        public DateTime? ConsultationDate { set; get; }
        public DateTime? CreateTime { set; get; }
    }
}
