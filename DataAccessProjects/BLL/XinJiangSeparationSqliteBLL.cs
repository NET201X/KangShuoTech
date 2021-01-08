namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class XinJiangSeparationSqliteBLL
    {
        private readonly XinJiangSeparationSqliteDAL dal = new XinJiangSeparationSqliteDAL();

        #region 五官

        /// <summary>
        /// 取得对应条件的五官科资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<RecordsVisceraFunctionModel> GetModelList(string strWhere, string conn = "")
        {
            // 取得五官资料
            DataTable dt = this.dal.GetList(strWhere, conn).Tables[0];

            // 将DataTable转为List
            List<RecordsVisceraFunctionModel> list = ModelConvertHelper<RecordsVisceraFunctionModel>.ToList(dt);

            return list;
        }

        /// <summary>
        /// 更新终端资料库中的脏器资料--五官
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public bool UpdateByMouth(RecordsVisceraFunctionModel model, string RecordDate)
        {
            return this.dal.UpdateByMouth(model, RecordDate);
        }

        /// <summary>
        /// 新增终端资料库中的脏器资料--五官
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public void InsertByMouth(RecordsVisceraFunctionModel model)
        {
            this.dal.InsertByMouth(model);
        }

        #endregion

        #region 外科

        /// <summary>
        /// 取得对应条件的外科资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<RecordsPhysicalExamModel> GetSurgicalList(string strWhere, string conn = "")
        {
            // 取得外科资料
            DataTable dt = this.dal.GetSurgicalList(strWhere, conn).Tables[0];

            // 将DataTable转为List
            List<RecordsPhysicalExamModel> list = ModelConvertHelper<RecordsPhysicalExamModel>.ToList(dt);

            return list;
        }

        /// <summary>
        /// 更新终端资料库中的查体资料--外科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public bool UpdateBySurgical(RecordsPhysicalExamModel model, string RecordDate)
        {
            return this.dal.UpdateBySurgical(model, RecordDate);
        }

        /// <summary>
        /// 更新终端资料库中的脏器资料--外科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public bool UpdateVisceraBySurgical(RecordsPhysicalExamModel model, string RecordDate)
        {
            return dal.UpdateVisceraBySurgical(model, RecordDate);
        }

        /// <summary>
        /// 更新终端资料库中的健康资料--外科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public bool UpdateHealthBySurgical(RecordsPhysicalExamModel model, string RecordDate)
        {
            return dal.UpdateHealthBySurgical(model, RecordDate);
        }

        /// <summary>
        /// 新增终端资料库中的脏器资料--外科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public void InsertVisceraBySurgical(RecordsPhysicalExamModel model)
        {
            dal.InsertVisceraBySurgical(model);
        }

        /// <summary>
        /// 新增终端资料库中的健康资料--外科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public void InsertHealthBySurgical(RecordsPhysicalExamModel model)
        {
            dal.InsertHealthBySurgical(model);
        }

        #endregion

        #region 内科

        /// <summary>
        /// 取得对应条件的内科资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<RecordsPhysicalExamModel> GetInternalMedicineList(string strWhere, string conn = "")
        {
            // 取得内科资料
            DataTable dt = this.dal.GetInternalMedicineList(strWhere, conn).Tables[0];

            // 将DataTable转为List
            List<RecordsPhysicalExamModel> list = ModelConvertHelper<RecordsPhysicalExamModel>.ToList(dt);

            return list;
        }

        /// <summary>
        /// 更新终端资料库中的查体资料--内科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public bool UpdateByInternalMedicine(RecordsPhysicalExamModel model, string RecordDate)
        {
            return this.dal.UpdateByInternalMedicine(model, RecordDate);
        }

        /// <summary>
        /// 新增终端资料库中的查体资料--内科,外科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public void Insert(RecordsPhysicalExamModel model)
        {
            this.dal.Insert(model);
        }

        #endregion

        #region X光

        /// <summary>
        /// 取得对应条件的X光资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<RecordsAssistCheckModel> GetChestXList(string strWhere, string conn = "")
        {
            // 取得X光资料
            DataTable dt = this.dal.GetChestXList(strWhere, conn).Tables[0];

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

