namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class DataUploadSqliteBLL
    {
        private readonly DataUploadSqliteDAL dal = new DataUploadSqliteDAL();

        public List<DataUploadModel> GetMaxModelList(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetMaxList(strWhere, conn);

            if (ds == null) return null;

            return ModelConvertHelper<DataUploadModel>.ToList(ds.Tables[0]);
        }        

        /// <summary>
        /// 住院、免疫接种史
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public List<History> GetHistoryModel(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetHistoryList(strWhere, conn);

            List<History> list = new List<History>();
            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                // 将DataTable转为List
                list = ModelConvertHelper<History>.ToList(ds.Tables[0]);
            }

            return list;
        }

        /// <summary>
        /// 心电
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public List<EcgDataModel> GetECGList(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetECGList(strWhere, conn);

            List<EcgDataModel> list = new List<EcgDataModel>();
            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                // 将DataTable转为List
                list = ModelConvertHelper<EcgDataModel>.ToList(ds.Tables[0]);
            }

            return list;
        }

        #region X光

        /// <summary>
        /// 取得对应条件的X光资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<RecordsAssistCheckModel> GetChestXList(string strWhere)
        {
            // 取得X光资料
            DataTable dt = this.dal.GetChestXList(strWhere).Tables[0];

            // 将DataTable转为List
            List<RecordsAssistCheckModel> list = ModelConvertHelper<RecordsAssistCheckModel>.ToList(dt);

            return list;
        }

        /// <summary>
        /// 更新终端资料库中的查体资料--X光
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public bool UpdateByChestX(RecordsAssistCheckModel model, string RecordDate)
        {
            return this.dal.UpdateByChestX(model, RecordDate);
        }

        /// <summary>
        /// 新增终端资料库中的查体资料--X光
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public void InsertByChestX(RecordsAssistCheckModel model)
        {
            this.dal.InsertByChestX(model);
        }

        #endregion
    }
}
