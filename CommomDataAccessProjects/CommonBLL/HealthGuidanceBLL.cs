using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class HealthGuidanceBLL
    {
        private readonly HealthGuidanceBussiness dal = new HealthGuidanceBussiness();

        /// <summary>
        /// 添加建议指导
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(HealthGuidanceModel model)
        {
            return dal.Insert(model);
        }

        /// <summary>
        /// 修改建议指导
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(HealthGuidanceModel model)
        {
            return dal.Update(model);
        }

        public int UpdateID(string id, string GuidanceId)
        {
            return dal.UpdateID(id, GuidanceId);
        }

        public int GetNum(string id)
        {
            return dal.GetNum(id);
        }

        /// <summary>
        /// 删除建议指导
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            return dal.Delete(id);
        }

        public int DeleteWhere(string where)
        {
            return dal.DeleteWhere(where);
        }

        /// <summary>
        /// 根据主键获取健康指导
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetInfo(string id)
        {
            return dal.GetInfo(id);
        }

        /// <summary>
        /// 获取健康指导列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetListInfo()
        {
            return dal.GetListInfo();
        }

        public DataTable GetInfoGui(string GuidanceId)
        {
            return dal.GetInfoGui(GuidanceId);
        }

        public List<HealthGuidanceModel> GetModelList(string where)
        {
            DataSet ds = dal.GetModelList(where);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<HealthGuidanceModel> list = ModelConvertHelper<HealthGuidanceModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list;
            }

            return null;
        }
    }
}
