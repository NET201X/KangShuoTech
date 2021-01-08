using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommomUtilities.Common;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsMedicineResultSqliteBLL
    {
        private readonly RecordsMedicineResultSqliteDAL dal = new RecordsMedicineResultSqliteDAL();

        public DataSet GetMaxList(string strWhere, string conn = "")
        {
            return this.dal.GetMaxList(strWhere, conn);
        }

        public List<MedicineModel> GetMaxModelList(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetMaxList(strWhere, conn);

            if (ds == null) return null;

            return ModelConvertHelper<MedicineModel>.ToList(ds.Tables[0]);
        }

        public List<MedicineModel> DataTableToList(DataTable dt)
        {
            List<MedicineModel> list = ModelConvertHelper<MedicineModel>.ToList(dt);

            return list;
        }
    }
}
