using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommomUtilities.Common;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsHealthQuestionBLL
    {
        private readonly RecordsHealthQuestionDAL dal = new RecordsHealthQuestionDAL();

		public int Add(RecordsHealthQuestionModel model)
		{
			return this.dal.Add(model);
		}

        public RecordsHealthQuestionModel GetModelByOutKey(int OutKey)
        {
            DataSet ds = this.dal.GetModelByOutKey(OutKey);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsHealthQuestionModel> list = ModelConvertHelper<RecordsHealthQuestionModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public bool Update(RecordsHealthQuestionModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateOtherDis(RecordsHealthQuestionModel model, string outKey)
        {
            return this.dal.UpdateOtherDis(model, outKey);
        }
    }
}
