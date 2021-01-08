namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonDAL;
    using CommonModel;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// 健康评价血压设置
    /// </summary>
    public class BloodAssessSetBLL
    {
        private readonly BloodAssessSetDAL dal = new BloodAssessSetDAL();

        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(BloodAssessSetModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BloodAssessSetModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public BloodAssessSetModel GetModel(string where="")
        {
            DataSet ds = dal.GetList(where);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<BloodAssessSetModel> list = ModelConvertHelper<BloodAssessSetModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }
    }
}
