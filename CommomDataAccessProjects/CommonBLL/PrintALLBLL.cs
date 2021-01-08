using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class PrintALLBLL
    {
        private readonly PrintALLDAL dal = new PrintALLDAL();

        public int Add(PrintALLModel model)
        {
            return dal.Add(model);
        }
        public bool Update(PrintALLModel model)
        {
            return dal.Update(model);
        }
        public bool Delete(int ID)
        {
            return dal.Delete(ID);
        }
    }
}
