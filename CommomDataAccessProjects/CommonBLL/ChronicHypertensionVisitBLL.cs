namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonDAL;
    using CommonModel;
    using System.Collections.Generic;
    using System.Data;
    
    /// <summary>
    /// 高血压患者随访记录表
    /// </summary>
    public class ChronicHypertensionVisitBLL
    {
        private readonly ChronicHypertensionVisitDAL dal = new ChronicHypertensionVisitDAL();

        public int Add(ChronicHypertensionBaseInfoModel model, string Version = "V2.0")
        {
            return this.dal.Add(model, Version);
        }

        public int Add(ChronicHypertensionVisitModel model, string Version = "V2.0")
        {
            return this.dal.Add(model, Version);
        }

        public List<ChronicHypertensionVisitModel> GetList(string IDCardNo, string CheckDate, string Version = "V2.0")
        {
            DataSet ds = dal.GetList(IDCardNo, CheckDate, Version);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicHypertensionVisitModel> list = ModelConvertHelper<ChronicHypertensionVisitModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list;
            }

            return null;
        }

        public ChronicHypertensionVisitModel GetModel(string IDCardNo, string CheckDate, string Version = "V2.0")
        {
            DataSet ds = dal.GetModel(IDCardNo, CheckDate, Version);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicHypertensionVisitModel> list = ModelConvertHelper<ChronicHypertensionVisitModel>.ToList(ds.Tables[0]);

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
        public ChronicHypertensionVisitModel GetMaxModel(string IDCardNo, string Version = "V2.0")
        {
            DataSet ds = dal.GetMaxModel(IDCardNo, Version);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicHypertensionVisitModel> list = ModelConvertHelper<ChronicHypertensionVisitModel>.ToList(ds.Tables[0]);

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

        /// <summary>
        /// 本季度是否有随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetDataCount(string IDCardNo, string Version = "V2.0")
        {
            return this.dal.GetDataCount(IDCardNo, Version);
        }

        public bool UpdateDate(ChronicHypertensionVisitModel model, string Version = "V2.0")
        {
            return dal.UpdateDate(model, Version);
        }
    }

    /// <summary>
    /// 脑卒中随访记录表
    /// </summary>
    public class ChronicStrokeVisitBLL
    {
        private readonly ChronicStrokeVisitDAL dal = new ChronicStrokeVisitDAL();

        public int Add(ChronicStrokeBaseInfoModel model)
        {
            return this.dal.Add(model);
        }

        public int Add(ChronicStrokeVisitModel model, string Version = "V2.0")
        {
            return this.dal.Add(model, Version);
        }

        public ChronicStrokeVisitModel GetList(string IDCardNo, string CheckDate, string Version = "V2.0")
        {
            DataSet ds = dal.GetList(IDCardNo, CheckDate, Version);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicStrokeVisitModel> list = ModelConvertHelper<ChronicStrokeVisitModel>.ToList(ds.Tables[0]);

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
        public ChronicStrokeVisitModel GetMaxModel(string IDCardNo, string Version = "V2.0")
        {
            DataSet ds = dal.GetMaxModel(IDCardNo, Version);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicStrokeVisitModel> list = ModelConvertHelper<ChronicStrokeVisitModel>.ToList(ds.Tables[0]);

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

    /// <summary>
    /// 冠心病患者随访表
    /// </summary>
    public class ChronicChdVisitBLL
    {
        private readonly ChronicChdVisitDAL dal = new ChronicChdVisitDAL();

        public int Add(ChronicChdBaseInfoModel model, string Version = "V2.0")
        {
            return this.dal.Add(model, Version);
        }

        public int Add(ChronicChdVisitModel model, string Version = "V2.0")
        {
            return this.dal.Add(model, Version);
        }

        public ChronicChdVisitModel GetList(string IDCardNo, string CheckDate)
        {
            DataSet ds = dal.GetList(IDCardNo, CheckDate);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicChdVisitModel> list = ModelConvertHelper<ChronicChdVisitModel>.ToList(ds.Tables[0]);

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
        public ChronicChdVisitModel GetMaxModel(string IDCardNo)
        {
            DataSet ds = dal.GetMaxModel(IDCardNo);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicChdVisitModel> list = ModelConvertHelper<ChronicChdVisitModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// 是否有随访基本信息
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetBaseDataCount(string IDCardNo)
        {
            return this.dal.GetBaseDataCount(IDCardNo);
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