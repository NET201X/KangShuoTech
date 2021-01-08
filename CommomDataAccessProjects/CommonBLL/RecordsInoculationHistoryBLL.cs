using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CommomUtilities.Common;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsInoculationHistoryBLL
    {
        private readonly RecordsInoculationHistoryDAL dal = new RecordsInoculationHistoryDAL();

        public bool Add(RecordsInoculationHistoryModel model)
        {
            return this.dal.Add(model);
        }
        
        /// <summary>
         /// 增加一条数据
         /// </summary>
        public bool AddList(List<RecordsInoculationHistoryModel> modelList)
        {
            foreach (RecordsInoculationHistoryModel a in modelList)
            {
                if (string.IsNullOrEmpty(a.PillName)) continue;

                if (!dal.Add(a)) return false;
            }

            return true;
        }

        public bool DeleteByOutKey(int OutKey)
        {
            return this.dal.DeleteByOutKey(OutKey);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public List<RecordsInoculationHistoryModel> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsInoculationHistoryModel> list = ModelConvertHelper<RecordsInoculationHistoryModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list;
            }

            return null;
        }        
    }
}
