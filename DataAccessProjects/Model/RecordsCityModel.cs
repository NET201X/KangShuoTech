namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsCityModel
    {

        public string Code { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int ProvinceID { get; set; }
    }
}