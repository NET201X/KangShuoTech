using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    public class PrintALLModel
    {
        public int ID { get; set; }
        public int PrintID { get; set; }
        public string FileButtonName { get; set; }
        public string IsDouble { get; set; }
        public int? PrintOrders { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
    }

    public class SysOrgTownModel
    {
        public string Code { get; set; }
        public int DistrictID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
