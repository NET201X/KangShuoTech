namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class RecordsMedicineCnSqliteBLL
    {
        private readonly RecordsMedicineCnSqliteDAL dal = new RecordsMedicineCnSqliteDAL();

        public List<RecordsMedicineCnModel> DataTableToList(DataTable dt)
        {
            List<RecordsMedicineCnModel> list = ModelConvertHelper<RecordsMedicineCnModel>.ToList(dt);

            return list;
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet GetMaxList(string strWhere, string conn = "")
        {
            return this.dal.GetMaxList(strWhere, conn);
        }

        public List<OlderMedicineCnModel> GetMaxModelList(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetMaxList(strWhere,conn);

            if (ds == null) return null;

            return CommonExtensions.ToList<OlderMedicineCnModel>(ds.Tables[0]);
        }

        public List<RecordsMedicineCnModel> GetMaxModelLists(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetMaxList(strWhere, conn);

            if (ds == null) return null;

            return CommonExtensions.ToList<RecordsMedicineCnModel>(ds.Tables[0]);
        }

        public List<OlderMedicineCnModel> GetModelList(string strWhere)
        {
            return CommonExtensions.ToList<OlderMedicineCnModel>(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }
    }
}


