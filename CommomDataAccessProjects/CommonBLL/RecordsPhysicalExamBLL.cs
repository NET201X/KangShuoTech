namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
	using CommonDAL;
	using CommonModel;
	using System.Collections.Generic;
	using System.Data;
	using CommomUtilities.Common;

    public class RecordsPhysicalExamBLL
    {
        private readonly RecordsPhysicalExamDAL dal = new RecordsPhysicalExamDAL();

        public int Add(RecordsPhysicalExamModel model)
        {
            return this.dal.Add(model);
        }

        public  RecordsPhysicalExamModel GetModelByOutKey(int OutKey)
        {
            DataSet ds = this.dal.GetModelByOutKey(OutKey);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsPhysicalExamModel> list = ModelConvertHelper<RecordsPhysicalExamModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// 心电更新查体心律、心率
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="OutKey"></param>
        /// <param name="HeartRhythm"></param>
        /// <param name="HeartRate"></param>
        /// <returns></returns>
        public bool Update(string IDCardNo, string OutKey, string HeartRhythm, string HeartRate)
        {
            return this.dal.Update(IDCardNo, OutKey, HeartRhythm, HeartRate);
        }
    }
}

