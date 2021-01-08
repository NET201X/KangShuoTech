namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonDAL;
    using CommonModel;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// ���򲡻�����ü�¼��
    /// </summary>
    public class ChronicDiadetesVisitBLL 
    {
        private readonly ChronicDiadetesVisitDAL dal = new ChronicDiadetesVisitDAL();
        
        public int Add(ChronicDiabetesBaseInfoModel model, string Version = "V2.0")
        {
            return this.dal.Add(model, Version);
        }

        public int Add(ChronicDiadetesVisitModel model, string Version = "V2.0")
        {
            return this.dal.Add(model, Version);
        }

        public List<ChronicDiadetesVisitModel> GetList(string IDCardNo, string CheckDate)
        {
            DataSet ds = dal.GetList(IDCardNo, CheckDate);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicDiadetesVisitModel> list = ModelConvertHelper<ChronicDiadetesVisitModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list;
            }

            return null;
        }
        
        public ChronicDiadetesVisitModel GetModel(string IDCardNo, string CheckDate)
        {
            DataSet ds = dal.GetModel(IDCardNo, CheckDate);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicDiadetesVisitModel> list = ModelConvertHelper<ChronicDiadetesVisitModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// ȡ���һ�����
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public ChronicDiadetesVisitModel GetMaxModel(string IDCardNo)
        {
            DataSet ds = dal.GetMaxModel(IDCardNo);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicDiadetesVisitModel> list = ModelConvertHelper<ChronicDiadetesVisitModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// �Ƿ�����û�����Ϣ
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetBaseDataCount(string IDCardNo)
        {
            return this.dal.GetBaseDataCount(IDCardNo);
        }

        /// <summary>
        /// �������Ƿ������
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetDataCount(string IDCardNo)
        {
            return this.dal.GetDataCount(IDCardNo);
        }

        public bool UpdateDate(ChronicDiadetesVisitModel model)
        {
            return dal.UpdateDate(model);
        }
    }
}

