namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonDAL;
    using CommonModel;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// BMI
    /// </summary>
    public class BMIAssessSetBLL
    {
        private readonly BMIAssessSetDAL dal = new BMIAssessSetDAL();

        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(BMIAssessSetModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BMIAssessSetModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public BMIAssessSetModel GetModel(string where = "")
        {
            DataSet ds = dal.GetList(where);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<BMIAssessSetModel> list = ModelConvertHelper<BMIAssessSetModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }
    }
}
