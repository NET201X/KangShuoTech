using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommomUtilities.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class DeviceInfoSqliteBLL
    {
        private readonly DeviceInfoSqliteDAL dal = new DeviceInfoSqliteDAL();
        public DataSet GetList(string strWhere, string conn = "")
        {
            return this.dal.GetList(strWhere,conn);
        }
        public DataSet GetMaxList(string strWhere, string conn = "")
        {
           return this.dal.GetMaxList(strWhere, conn);
        }

        public List<DeviceInfoModel> GetMaxModelList(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetMaxList(strWhere, conn);

            if (ds == null) return null;

            return ModelConvertHelper<DeviceInfoModel>.ToList(ds.Tables[0]);
        }
    }
}
