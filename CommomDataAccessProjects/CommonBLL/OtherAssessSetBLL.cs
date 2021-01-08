namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonDAL;
    using CommonModel;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    public class OtherAssessSetBLL
    {
        private readonly OtherAssessSetDAL dal = new OtherAssessSetDAL();

        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(OtherAssessSetModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(OtherAssessSetModel model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            return dal.Delete(ID);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public OtherAssessSetModel GetModel(string where = "")
        {
            DataSet ds = dal.GetList(where);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<OtherAssessSetModel> list = ModelConvertHelper<OtherAssessSetModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }
    }
}
