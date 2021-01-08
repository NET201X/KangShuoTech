using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsHospitalHistoryBLL
    {
        private readonly RecordsHospitalHistoryDAL dal = new RecordsHospitalHistoryDAL();

        public bool Add(RecordsHospitalHistoryModel model)
        {
            return this.dal.Add(model);
        }

        public bool DeleteByOutKey(int OutKey)
        {
            return this.dal.DeleteByOutKey(OutKey);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddList(List<RecordsHospitalHistoryModel> modelList)
        {
            foreach (RecordsHospitalHistoryModel model in modelList)
            {
                if (!string.IsNullOrEmpty(model.HospitalName))
                {
                    if (!dal.Add(model)) return false;
                }
            }

            return true;
        }

        public List<RecordsHospitalHistoryModel> GetModelList(string strWhere)
		{
            DataSet ds = this.dal.GetList(strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsHospitalHistoryModel> list = ModelConvertHelper<RecordsHospitalHistoryModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list;
            }

            return null;
		}
    }
}
