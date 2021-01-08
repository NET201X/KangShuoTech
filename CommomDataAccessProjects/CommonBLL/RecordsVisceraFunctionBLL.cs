namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
	using CommonDAL;
	using CommonModel;
	using System.Collections.Generic;
	using System.Data;
	using CommomUtilities.Common;

    public class RecordsVisceraFunctionBLL
    {
        private readonly RecordsVisceraFunctionDAL dal = new RecordsVisceraFunctionDAL();

        public int Add(RecordsVisceraFunctionModel model)
        {
            return this.dal.Add(model);
        }

        public RecordsVisceraFunctionModel GetModelByOutKey(int OutKey)
        {
            DataSet ds = this.dal.GetModelByOutKey(OutKey);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsVisceraFunctionModel> list = ModelConvertHelper<RecordsVisceraFunctionModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public bool UpdateVsiual(RecordsVisceraFunctionModel model)
        {
            return dal.UpdateVsiual(model);
        }
    }
}

