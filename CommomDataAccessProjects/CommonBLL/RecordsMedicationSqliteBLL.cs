using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommomUtilities.Common;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsMedicationSqliteBLL
    {
        private readonly RecordsMedicationSqliteDAL dal = new RecordsMedicationSqliteDAL();

        public List<RecordsMedicationModel> GetModelList(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetList(strWhere, conn);

            List<RecordsMedicationModel> list = new List<RecordsMedicationModel>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                // 将DataTable转为List
                list = ModelConvertHelper<RecordsMedicationModel>.ToList(ds.Tables[0]);
            }

            return list;
        }
    }
}
