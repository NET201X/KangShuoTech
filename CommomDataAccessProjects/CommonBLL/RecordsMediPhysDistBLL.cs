namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
	using CommonDAL;
	using CommonModel;
	using System.Collections.Generic;
	using System.Data;
	using CommomUtilities.Common;

    public class RecordsMediPhysDistBLL
    {
        private readonly RecordsMediPhysDistDAL dal = new RecordsMediPhysDistDAL();

        public int Add(RecordsMediPhysDistModel model)
        {
            return dal.Add(model);
        }

        public RecordsMediPhysDistModel GetModelByOutKey(int OutKey)
        {
            DataSet ds = this.dal.GetModelByOutKey(OutKey);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsMediPhysDistModel> list = ModelConvertHelper<RecordsMediPhysDistModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public RecordsMedicineCnModel GetModel(int ID)
        {
            DataSet ds = this.dal.GetModel(ID);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsMedicineCnModel> list = ModelConvertHelper<RecordsMedicineCnModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list[0];
            }

            return new RecordsMedicineCnModel();
        }

        public RecordsMedicineResultModel GetResultModel(int ID)
        {
            DataSet ds = this.dal.GetResultModel(ID);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsMedicineResultModel> list = ModelConvertHelper<RecordsMedicineResultModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list[0];
            }

            return new RecordsMedicineResultModel();
        }
    }
}

