namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonDAL;
    using CommonModel;
    using System.Collections.Generic;
    using System.Data;

    public class ChronicLungerFirstVisitBLL
    {
        private readonly ChronicLungerFirstVisitDAL dal = new ChronicLungerFirstVisitDAL();

        public int Add(ChronicLungerFirstVisitModel model, string Version = "V2.0")
        {
            return this.dal.Add(model, Version);
        }

        public int Add(ChronicLungerVisitModel model, string Version = "V2.0")
        {
            return this.dal.Add(model, Version);
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

        /// <summary>
        /// 取第一次随访信息
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public ChronicLungerFirstVisitModel GetFirstMaxModel(string IDCardNo, string Version = "V2.0")
        {
            DataSet ds = dal.GetFirstMaxModel(IDCardNo, Version);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicLungerFirstVisitModel> list = ModelConvertHelper<ChronicLungerFirstVisitModel>.ToList(ds.Tables[0]);

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
        public ChronicLungerVisitModel GetMaxModel(string IDCardNo, string Version = "V2.0")
        {
            DataSet ds = dal.GetMaxModel(IDCardNo, Version);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicLungerVisitModel> list = ModelConvertHelper<ChronicLungerVisitModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }
    }
}