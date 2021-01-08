namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonDAL;
    using CommonModel;
    using System.Collections.Generic;
    using System.Data;

    public class ChronicDrugConditionBLL
    {
        private readonly ChronicDrugConditionDAL dal = new ChronicDrugConditionDAL();

        public int Add(ChronicDrugConditionModel model)
        {
            return this.dal.Add(model);
        }

        /// <summary>
        /// 用药
        /// </summary>
        public List<ChronicDrugConditionModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicDrugConditionModel> list = ModelConvertHelper<ChronicDrugConditionModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list;
            }

            return null;
        }
    }

    /// <summary>
    /// 重性精神疾病患者个人信息表
    /// </summary>
    public class ChronicMentalDiseaseBaseInfoBLL
    {
        private readonly ChronicMentalDiseaseBaseInfoDAL dal = new ChronicMentalDiseaseBaseInfoDAL();

        public int Add(ChronicMentalDiseaseBaseInfoModel model)
        {
            return this.dal.Add(model);
        }

        public ChronicMentalDiseaseBaseInfoModel GetModel(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicMentalDiseaseBaseInfoModel> list = ModelConvertHelper<ChronicMentalDiseaseBaseInfoModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// 是否有随访基本信息
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetDataCount(string IDCardNo)
        {
            return this.dal.GetDataCount(IDCardNo);
        }
    }

    /// <summary>
    /// 重性精神疾病患者随访服务记录表
    /// </summary>
    public class ChronicMentalDiseaseVisitBLL
    {
        private readonly ChronicMentalDiseaseVisitDAL dal = new ChronicMentalDiseaseVisitDAL();

        public int Add(ChronicMentalDiseaseVisitModel model, string Version = "V2.0")
        {
            return this.dal.Add(model, Version);
        }

        public ChronicMentalDiseaseVisitModel GetMaxModel(string IDCardNo, string CheckDate, string Version = "V2.0")
        {
            DataSet ds = dal.GetMaxModel(IDCardNo, CheckDate, Version);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicMentalDiseaseVisitModel> list = ModelConvertHelper<ChronicMentalDiseaseVisitModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// 取最后一次随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public ChronicMentalDiseaseVisitModel GetMaxModel(string IDCardNo, string Version = "V2.0")
        {
            DataSet ds = dal.GetMaxModel(IDCardNo, Version);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicMentalDiseaseVisitModel> list = ModelConvertHelper<ChronicMentalDiseaseVisitModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// 本季度是否有随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetDataCount(string IDCardNo, string Version = "V2.0")
        {
            return this.dal.GetDataCount(IDCardNo, Version);
        }
    }
}