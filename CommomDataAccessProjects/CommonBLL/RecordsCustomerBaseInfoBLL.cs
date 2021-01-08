using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommomUtilities.Common;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsCustomerBaseInfoBLL
    {
        private readonly RecordsCustomerBaseInfoDAL dal = new RecordsCustomerBaseInfoDAL();

        public int Add(RecordsCustomerBaseInfoModel model)
        {
            return this.dal.Add(model);
        }

        public bool Update(int ID, string barCode)
        {
            return this.dal.Update(ID, barCode);
        }

        public DataSet GetVillageList(string strWhere)
        {
            return this.dal.GetVillageList(strWhere);
        }

        /// <summary>
        /// 同步时取得年度的最后一次体检资料
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public RecordsCustomerBaseInfoModel GetModelByCheckDate(string IDCardNo, string checkDate)
        {
            DataSet ds = this.dal.GetModelByCheckDate(IDCardNo, checkDate);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsCustomerBaseInfoModel> list = ModelConvertHelper<RecordsCustomerBaseInfoModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return new RecordsCustomerBaseInfoModel();
        }

        public RecordsCustomerBaseInfoModel GetModelByWhere(string strWhere)
        {
            DataSet ds = this.dal.GetModelByWhere(strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsCustomerBaseInfoModel> list = ModelConvertHelper<RecordsCustomerBaseInfoModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// 获取最近一条体检记录
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <returns></returns>
        public RecordsCustomerBaseInfoModel GetMaxModel(string IDCardNo, string CheckDate = "")
        {
            DataSet ds = dal.GetMaxModel(IDCardNo, CheckDate);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsCustomerBaseInfoModel> list = ModelConvertHelper<RecordsCustomerBaseInfoModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// 获取化验单最近一次体检
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <returns></returns>
        public RecordsCustomerBaseInfoModel GetBiochemical(string IDCardNo, string CheckDate = "")
        {
            DataSet ds = dal.GetBiochemical(IDCardNo, CheckDate);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsCustomerBaseInfoModel> list = ModelConvertHelper<RecordsCustomerBaseInfoModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public RecordsCustomerBaseInfoModel GetModelByID(int ID)
        {
            DataSet ds = this.dal.GetModelByID(ID);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsCustomerBaseInfoModel> list = ModelConvertHelper<RecordsCustomerBaseInfoModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public int GetCustomerRecordCount(string strWhere)
        {
            return this.dal.GetCustomerRecordCount(strWhere);
        }

        public DataSet GetCustomerListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetCustomerListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 体检问询更新体检
        /// </summary>
        /// <param name="customerBaseInfoModel"></param>
        /// <param name="deciveModel"></param>
        /// <param name="MedicationModel"></param>
        /// <param name="HistoryModel"></param>
        /// <param name="area"></param>
        /// <param name="versionNo"></param>
        /// <returns></returns>
        public bool Update(RecordsCustomerBaseInfoModel customerBaseInfoModel, DataUploadModel deciveModel, 
            List<RecordsMedicationModel> MedicationModel, List<History> HistoryModel, string area, string versionNo)
        {
            return dal.Update(customerBaseInfoModel, deciveModel, MedicationModel, HistoryModel, area, versionNo);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }
    }
}
