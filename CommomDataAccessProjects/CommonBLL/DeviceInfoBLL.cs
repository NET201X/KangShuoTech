using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class DeviceInfoBLL
    {
        private readonly DeviceInfoDAL dal = new DeviceInfoDAL();

        public int Add(DeviceInfoModel model)
        {
            return this.dal.Add(model);
        }

        public int AddNew(DeviceInfoModel model)
        {
            return this.dal.AddNew(model);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public bool Update(DeviceInfoModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateNew(DeviceInfoModel model)
        {
            return this.dal.UpdateNew(model);
        }

        public List<DeviceInfoModel> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<DeviceInfoModel> list = ModelConvertHelper<DeviceInfoModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list;
            }

            return null;
        }
    }
}
