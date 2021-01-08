using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsSelfcareabilityBLL
    {
        private readonly RecordsSelfcareabilityDAL dal = new RecordsSelfcareabilityDAL();

        public int Add(RecordsSelfcareabilityModel model)
        {
            return this.dal.Add(model);
        }

        public bool UpdateByMiniPad(RecordsSelfcareabilityModel model, string RecordDate, string oldSelf)
        {
            return this.dal.UpdateByMiniPad(model, RecordDate, oldSelf);
        }

        public bool UpdateGeneral(string IDCardNo, string RecordDate, int ID, string oldSelf)
        {
            return this.dal.UpdateGeneral(IDCardNo, RecordDate, ID, oldSelf);
        }

        public RecordsSelfcareabilityModel GetModel(int outKey)
        {
            DataSet ds = this.dal.GetModel(outKey);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsSelfcareabilityModel> list = ModelConvertHelper<RecordsSelfcareabilityModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list[0];
            }

            return null;
        }
    }
}
