
namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class RecordsMedicationSqliteBLL
    {
        private readonly RecordsMedicationSqliteDAL dal = new RecordsMedicationSqliteDAL();
        
        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet GetMaxList(string strWhere)
        {
            return this.dal.GetMaxList(strWhere);
        }

        public List<RecordsMedicationModel> GetMaxModelList(string strWhere)
        {
            DataSet ds = this.dal.GetMaxList(strWhere);

            if (ds == null) return null;

            return ModelConvertHelper<RecordsMedicationModel>.ToList(ds.Tables[0]);
        }

        public List<RecordsMedicationModel> GetModelList(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetList(strWhere, conn);

            List<RecordsMedicationModel> list = new List<RecordsMedicationModel>();
            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                // 将DataTable转为List
                list = ModelConvertHelper<RecordsMedicationModel>.ToList(ds.Tables[0]);
            }

            return list;
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }
    }
}
