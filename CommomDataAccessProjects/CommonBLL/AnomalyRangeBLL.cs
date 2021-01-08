using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class AnomalyRangeBLL
    {
        private readonly AnomalyRangeBussiness dal = new AnomalyRangeBussiness();

        /// <summary>
        /// 添加异常范围及指导建议
        /// </summary>
        /// <returns></returns>
        public int AddAnomaly(AnomalyRangeModel model)
        {
            return dal.AddAnomaly(model);
        }

        /// <summary>
        /// 修改异常范围及指导建议
        /// </summary>
        /// <param name="anomal"></param>
        /// <returns></returns>
        public int UpdateAnomaly(AnomalyRangeModel model)
        {
            return dal.UpdateAnomaly(model);
        }

        /// <summary>
        /// 获取异常值及范围设置
        /// </summary>
        /// <returns></returns>
        public DataTable GetAnomaly(string PreinstallId)
        {
            return dal.GetAnomaly(PreinstallId);
        }
    }
}
