namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System.Data;
    using System.Collections.Generic;

    public class RecordsAssistCheckBLL
    {
        private readonly RecordsAssistCheckDAL dal = new RecordsAssistCheckDAL();

        public int Add(RecordsAssistCheckModel model)
        {
            return this.dal.Add(model);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public bool Update(RecordsAssistCheckModel model)
        {
            return this.dal.Update(model);
        }

        public RecordsAssistCheckModel GetModelByOutKey(int OutKey)
        {
            DataSet ds = this.dal.GetModelByOutKey(OutKey);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsAssistCheckModel> list = ModelConvertHelper<RecordsAssistCheckModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public bool ExistsOutKey(string IDCardNo, int OutKey)
        {
            return this.dal.ExistsOutKey(IDCardNo,OutKey);
        }

        #region 新同步方式

        public bool UpdateByMiniPad(RecordsAssistCheckModel model, string checkDate)
        {
            return this.dal.UpdateByMiniPad(model, checkDate);
        }

        public bool UpdateByMiniSTPad(RecordsAssistCheckModel model, string checkDate)
        {
            return this.dal.UpdateByMiniSTPad(model, checkDate);
        }

        /// <summary>
        /// 更新辅助检查
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateAssistCheck(DataModel model)
        {
            return this.dal.UpdateAssistCheck(model);
        }

        /// <summary>
        /// 更新辅助检查
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateAssistCheckNJ(DataModel model)
        {
            return this.dal.UpdateAssistCheckNJ(model);
        }

        /// <summary>
        /// 更新身高体重
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateWeight(DataModel model)
        {
            return this.dal.UpdateWeight(model);
        }

        /// <summary>
        /// 更新血球
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateXQ(DataModel model)
        {
            return this.dal.UpdateXQ(model);
        }

        #endregion
    }
}

