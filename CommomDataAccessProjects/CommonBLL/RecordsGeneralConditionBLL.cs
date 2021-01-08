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
    public class RecordsGeneralConditionBLL
    {
        private readonly RecordsGeneralConditionDAL dal = new RecordsGeneralConditionDAL();

        public int Add(RecordsGeneralConditionModel model, string Version = "V2.0")
        {
            return this.dal.Add(model, Version);
        }

        /// <summary>
        /// 同步取得最后一次体检资料
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public RecordsGeneralConditionModel GetModelByCheckDate(string IDCardNo, string checkDate)
        {
            DataSet ds = this.dal.GetModelByCheckDate(IDCardNo, checkDate);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsGeneralConditionModel> list = ModelConvertHelper<RecordsGeneralConditionModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return new RecordsGeneralConditionModel();
        }

        /// <summary>
        /// 身高体重的更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByMiniSTPad(RecordsGeneralConditionModel model, string OutKey)
        {
            return this.dal.UpdateByMiniSTPad(model, OutKey);
        }

        /// <summary>
        /// 体温体重-体重体质指数的更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByMiniTTPad(RecordsGeneralConditionModel model, string checkDate)
        {
            return this.dal.UpdateByMiniTTPad(model, checkDate);
        }

        /// <summary>
        /// 体温体重-体温更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByMiniTWPad(RecordsGeneralConditionModel model, string checkDate)
        {
            return this.dal.UpdateByMiniTWPad(model, checkDate);
        }

        /// <summary>
        /// 血压同步更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByMiniPad(RecordsGeneralConditionModel model, string checkDate)
        {
            return this.dal.UpdateByMiniPad(model, checkDate);
        }

        /// <summary>
        /// 心电同步更新脉率
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="OutKey"></param>
        /// <param name="PulseRate"></param>
        /// <param name="BreathRate"></param>
        /// <returns></returns>
        public bool UpdateByEcg(string IDCardNo, string OutKey, string PulseRate, string BreathRate)
        {
            return this.dal.UpdateByEcg(IDCardNo, OutKey, PulseRate, BreathRate);
        }

        /// <summary>
        /// 抑郁评估的更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByGloomy(RecordsGeneralConditionModel model, string OutKey)
        {
            return this.dal.UpdateByGloomy(model, OutKey);
        }

        /// <summary>
        /// 智力评估的更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByIntelligence(RecordsGeneralConditionModel model, string OutKey)
        {
            return this.dal.UpdateByIntelligence(model, OutKey);
        }

        /// <summary>
        /// 根据体检外键取得资料
        /// </summary>
        /// <param name="OutKey"></param>
        /// <returns></returns>
        public RecordsGeneralConditionModel GetModelByOutKey(int OutKey)
        {
            DataSet ds = dal.GetModelByOutKey(OutKey);
            List<RecordsGeneralConditionModel> list = ModelConvertHelper<RecordsGeneralConditionModel>.ToList((ds.Tables[0]));

            if (list.Count > 0) return list[0];

            return new RecordsGeneralConditionModel();
        }

        /// <summary>
        /// 共用二维码取身高体重
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public RecordsGeneralConditionModel GetMaxDateModel(string IDCardNo)
        {
            DataTable dt = this.dal.GetMaxDateModel(IDCardNo);

            if (dt == null) return null;

            List<RecordsGeneralConditionModel> list = CommonExtensions.ToList<RecordsGeneralConditionModel>(dt);

            if (list.Count > 0) return list[0];

            return null;
        }

        #region 辽宁抑郁、智力表存档

        /// <summary>
        /// 抑郁评估的新增
        /// </summary>
        /// <param name="model"></param>
        /// <param name="OutKey"></param>
        /// <returns></returns>
        public int Add(OldGloomyModel model, string OutKey)
        {
            return this.dal.Add(model, OutKey);
        }

        /// <summary>
        /// 抑郁评估的删除
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="OutKey"></param>
        /// <returns></returns>
        public bool Delete(string IDCardNo, string OutKey)
        {
            return this.dal.Delete(IDCardNo, OutKey);
        }

        /// <summary>
        /// 智力评估的新增
        /// </summary>
        /// <param name="model"></param>
        /// <param name="OutKey"></param>
        /// <returns></returns>
        public int Add(OldIntelligenceModel model, string OutKey)
        {
            return this.dal.Add(model, OutKey);
        }

        /// <summary>
        /// 智力评估的删除
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="OutKey"></param>
        /// <returns></returns>
        public bool DeleteByOldIntelligence(string IDCardNo, string OutKey)
        {
            return this.dal.DeleteByOldIntelligence(IDCardNo, OutKey);
        }

        #endregion
    }
}
