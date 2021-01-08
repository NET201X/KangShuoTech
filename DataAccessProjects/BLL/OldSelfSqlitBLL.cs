using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using System.Data;
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class OldSelfSqlitBLL
    {
        private readonly OldSelfSqliteDAL dal = new OldSelfSqliteDAL();

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public List<OldSelfSqliteModel> GetMaxList(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetMaxList(strWhere, conn);

            if (ds == null) return null;

            return CommonExtensions.ToList<OldSelfSqliteModel>(ds.Tables[0]);
        }
    }
}
