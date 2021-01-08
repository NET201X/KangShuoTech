using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using System.Data;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class RecordsxqBLL
    {
        private readonly RecordsxqDAL dal = new RecordsxqDAL();
        
        public DataSet GetDT(string strWhere)
        {
            return this.dal.GetDT(strWhere);
        }

        public int AddRow(DataModel model)
        {
            return this.dal.AddRow(model);
        }
    }
}
