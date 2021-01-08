
namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    public class RecordsEcgBLL
    {
        private readonly RecordsEcgDAL dal = new RecordsEcgDAL() ;
        public DataSet GetConclusion(string IDCardNo)
        {
            return this.dal.GetConclusion(IDCardNo);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public DataSet GetUserDt(string strWhere)
        {
            return this.dal.GetUserDt(strWhere);
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public int GetMIDCount(string strWhere)
        {
            return this.dal.GetMIDCount(strWhere);
        }
        public DataSet GetData(string IDCardNo)
        {
            return this.dal.GetData(IDCardNo);
        }
        public DataSet GetList(string IDCardNo)
        {
            return this.dal.GetData(IDCardNo);
        }
        public RecordsEcgModel GetModel(string IDCardNo)
        {
            DataSet ds = this.dal.GetData(IDCardNo);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsEcgModel> list = ModelConvertHelper<RecordsEcgModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return new RecordsEcgModel();
        }
        public RecordsEcgModel GetModelByWhere(string strWhere)
        {
           DataSet set = this.dal.GetList(strWhere);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.dal.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
    }
}
