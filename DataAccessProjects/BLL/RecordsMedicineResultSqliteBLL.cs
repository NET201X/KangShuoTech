namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class RecordsMedicineResultSqliteBLL
    {
        private readonly RecordsMedicineResultSqliteDAL dal = new RecordsMedicineResultSqliteDAL();

        public List<MedicineModel> DataTableToList(DataTable dt)
        {
            List<MedicineModel> list = ModelConvertHelper<MedicineModel>.ToList(dt);

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

        public List<OlderMedicineResultModel> GetMaxModelList(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetMaxList(strWhere,conn);

            if (ds == null) return null;

            return CommonExtensions.ToList<OlderMedicineResultModel>(ds.Tables[0]);
        }

        public List<RecordsMedicineResultModel> GetMaxModelLists(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetMaxList(strWhere, conn);

            if (ds == null) return null;

            return CommonExtensions.ToList<RecordsMedicineResultModel>(ds.Tables[0]);
        }

        public List<OlderMedicineResultModel> GetModelList(string strWhere)
        {
            return CommonExtensions.ToList<OlderMedicineResultModel>(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }
    }
}


