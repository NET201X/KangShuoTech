namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class SysOrgTownModel
    {
        public string Code { get; set; }
        public int DistrictID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}