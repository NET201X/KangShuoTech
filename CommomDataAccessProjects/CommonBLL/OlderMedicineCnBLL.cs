using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class OlderMedicineCnBLL
    {
        private readonly OlderMedicineCnDAL dal = new OlderMedicineCnDAL();

        public int Add(MedicineModel model, string Version = "V2.0")
        {
            return this.dal.Add(model, Version);
        }

        public bool Update(MedicineModel model, string Version = "V2.0")
        {
            return this.dal.Update(model,Version);
        }

        public OlderMedicineCnModel GetModel(int outKey,string IDCardNo="",string RecordDate="",string Version="V2.0")
        {
            DataSet ds = this.dal.GetModel(outKey, IDCardNo, RecordDate, Version);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<OlderMedicineCnModel> list = ModelConvertHelper<OlderMedicineCnModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return new OlderMedicineCnModel();
        }

        public OlderMedicineCnModel GetMaxModel(string IDCardNo, string CheckDate = "")
        {
            DataSet ds = this.dal.GetMaxModel(IDCardNo, CheckDate);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<OlderMedicineCnModel> list = ModelConvertHelper<OlderMedicineCnModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }
        
        /// <summary>
        /// 2.0版本取中医体质及体质结果
        /// </summary>
        /// <param name="outKey"></param>
        /// <returns></returns>
        public MedicineModel GetModelByKey(int outKey)
        {
            DataSet ds = this.dal.GetModelByKey(outKey);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<MedicineModel> list = ModelConvertHelper<MedicineModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// 3.0版本取最后一次中医体质及体质结果
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <returns></returns>
        public MedicineModel GetAllModel(string IDCardNo, string CheckDate = "")
        {
            DataSet ds = this.dal.GetAllModel(IDCardNo, CheckDate);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<MedicineModel> list = ModelConvertHelper<MedicineModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// 本季度是否有随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetDataCount(string IDCardNo)
        {
            return this.dal.GetDataCount(IDCardNo);
        }
    }
}
