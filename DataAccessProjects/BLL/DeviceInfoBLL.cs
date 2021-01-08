using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.DataAccessProjects.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class DeviceInfoBLL
    {
        private readonly DeviceInfoDAL dal = new DeviceInfoDAL();

        public int Add(DeviceInfoModel model)
        {
            return this.dal.Add(model);
        }

        public int AddRow(DataRow row)
        {
            return this.dal.AddRow(row);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public List<DeviceInfoModel> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);

            if (ds == null) return null;

            return ModelConvertHelper<DeviceInfoModel>.ToList(ds.Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }
        
        public bool Update(DeviceInfoModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateRow(DataRow row)
        {
            return this.dal.UpdateRow(row);
        }

        public bool Update(string column, string p_value, int ID)
        {
            return this.dal.Update(column, p_value, ID);
        }
    }
}

