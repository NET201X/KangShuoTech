using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommomUtilities.Common;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class OldSelfSqlitBLL
    {
        private readonly OldSelfSqliteDAL dal = new OldSelfSqliteDAL();

        public List<OldSelfSqliteModel> GetMaxList(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetMaxList(strWhere, conn);

            if (ds == null) return null;

            return CommonExtensions.ToList<OldSelfSqliteModel>(ds.Tables[0]);
        }
    }
}
