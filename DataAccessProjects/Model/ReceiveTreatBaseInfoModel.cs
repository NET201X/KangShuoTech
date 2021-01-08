
namespace KangShuoTech.DataAccessProjects.Model
{
    using System;
    [Serializable]
    public class ReceiveTreatBaseInfoModel
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string Sex { get; set; }
        public string IDCardNo { get; set; }
        public string Address { get; set; }
        public string CreateUnitName { get; set; }
        public string Doctor { get; set; }
        public string SubjectiveData { get; set; }
        public string ObjectiveData { get; set; }
        public string Assessment { get; set; }
        public string ManagePlane { get; set; }
        public string CreateMenName { get; set; }
        public string UpdateUnitName { set; get; }
        public string UpdatePerson { set; get; }
        public DateTime? UpdateDate { set; get; }
        public DateTime? ReceiveDate { get; set; }
        public DateTime? CreateDate { get; set;}
 

    }
}
