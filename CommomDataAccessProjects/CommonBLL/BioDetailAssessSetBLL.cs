namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonDAL;
    using CommonModel;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    public class BioDetailAssessSetBLL
    {
        private readonly BioDetailAssessSetDAL dal = new BioDetailAssessSetDAL();

        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(BioDetailAssessSetModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BioDetailAssessSetModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public BioDetailAssessSetModel GetMaxModel(string where = "")
        {
            DataSet ds = dal.GetList(where);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<BioDetailAssessSetModel> list = ModelConvertHelper<BioDetailAssessSetModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public List<BioDetailAssessSetModel> GetModelList(string where)
        {
            DataSet ds = dal.GetList(where);
            if (ds != null && ds.Tables.Count > 0)
            {
                List<BioDetailAssessSetModel> list = ModelConvertHelper<BioDetailAssessSetModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list;
            }

            return null;
        }

        public DataTable GetTable(string where)
        {
            return dal.GetList(where).Tables[0];
        }

        public bool Delete(int ID)
        {
            return dal.Delete(ID);
        }
        public List<BioDetailAssessSetModel> GetDistinctCode(int type)
        {
            DataTable dt = dal.GetDistinctCode(type);
            if (dt.Rows.Count > 0)
            {
                List<BioDetailAssessSetModel> list = ModelConvertHelper<BioDetailAssessSetModel>.ToList(dt);

                if (list.Count > 0) return list;
            }

            return null;
        }
        public bool InserBio(ArrayList list)
        {
           return dal.InserBio(list);
        }
    }
}
