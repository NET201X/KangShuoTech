namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
	using CommonDAL;
	using CommonModel;
	using System.Collections.Generic;
	using System.Data;
	using CommomUtilities.Common;

    public class RecordsLifeStyleBLL
    {
        private readonly RecordsLifeStyleDAL dal = new RecordsLifeStyleDAL();

        public int Add(RecordsLifeStyleModel model)
        {
            return this.dal.Add(model);
        }
        
        public RecordsLifeStyleModel GetModelByOutKey(int outKey)
        {
            DataSet ds = this.dal.GetModelByOutKey(outKey);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsLifeStyleModel> list = ModelConvertHelper<RecordsLifeStyleModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list[0];
            }

            return null;
        }
    }
}

