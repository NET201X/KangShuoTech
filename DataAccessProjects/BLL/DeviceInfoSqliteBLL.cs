using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.DataAccessProjects.BLL
{
    using System.Collections.Generic;
    using System.Data;

    public class DeviceInfoSqliteBLL
    {
        private readonly DeviceInfoSqliteDAL dal = new DeviceInfoSqliteDAL();

        public DataSet GetList(string strWhere, string conn = "")
        {
            return this.dal.GetList(strWhere, conn);
        }
        
        public List<DeviceInfoModel> GetMaxModelList(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetMaxList(strWhere, conn);

            if (ds == null) return null;

            return ModelConvertHelper<DeviceInfoModel>.ToList(ds.Tables[0]);
        }

        public void Update(string failedInfo, string conn = "")
        {
            this.dal.Update(failedInfo, conn);
        }
    }
}
