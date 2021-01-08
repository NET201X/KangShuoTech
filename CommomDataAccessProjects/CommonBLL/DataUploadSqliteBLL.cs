using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommomUtilities.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class DataUploadSqliteBLL
    {
        private readonly DataUploadSqliteDAL dal = new DataUploadSqliteDAL();

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

        /// <summary>
        /// 一代心电
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public List<EcgDataModel> GetFirstECGList(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetFirstECGList(strWhere, conn);

            List<EcgDataModel> list = new List<EcgDataModel>();
            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                // 将DataTable转为List
                list = ModelConvertHelper<EcgDataModel>.ToList(ds.Tables[0]);
            }

            return list;
        }

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

            if (ds.Tables.Count > 0)
            {
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    // 将DataTable转为List
                    list = ModelConvertHelper<History>.ToList(ds.Tables[0]);
                }
            }

            return list;
        }
    }
}
