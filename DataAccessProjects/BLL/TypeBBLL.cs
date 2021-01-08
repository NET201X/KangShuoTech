
namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class TypeBBLL
    {
        private readonly TypeBDAL dal = new TypeBDAL();
        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet GetModel(string strWhere)
        {
            return this.dal.GetModel(strWhere);
        }
        public DataSet GetByWhere(string strWhere)
        {
            return this.dal.GetByWhere(strWhere);
        }
    }
}
