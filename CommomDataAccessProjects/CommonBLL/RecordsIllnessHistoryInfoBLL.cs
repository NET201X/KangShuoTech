using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommomUtilities.Common;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsIllnessHistoryInfoBLL
    {
        private readonly RecordsIllnessHistoryInfoDAL dal = new RecordsIllnessHistoryInfoDAL();

        public int Add(RecordsIllnessHistoryInfoModel model)
        {
            return this.dal.Add(model);
        }

        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public List<RecordsIllnessHistoryInfoModel> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);
            if (ds == null) return null;

            return ModelConvertHelper<RecordsIllnessHistoryInfoModel>.ToList(ds.Tables[0]);
        }

        public bool Update(RecordsIllnessHistoryInfoModel model)
        {
            return this.dal.Update(model);
        }
    }
}
