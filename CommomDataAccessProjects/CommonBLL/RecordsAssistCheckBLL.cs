using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommomUtilities.Common;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
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

        public int UpdateXQ(DataModel model)
        {
            return this.dal.UpdateXQ(model);
        }

        public int UpdateXQNew(DataModel model)
        {
            return this.dal.UpdateXQNew(model);
        }

        public int UpdateAssistCheck(DataModel model)
        {
            return this.dal.UpdateAssistCheck(model);
        }

        public int UpdateAssistCheckNew(DataModel model)
        {
            return this.dal.UpdateAssistCheckNew(model);
        }

        public int UpdateWeight(DataModel model)
        {
            return this.dal.UpdateWeight(model);
        }

        public int UpdateAssistCheckNJ(DataModel model)
        {
            return this.dal.UpdateAssistCheckNJ(model);
        }

        public bool UpdateByMiniSTPad(RecordsAssistCheckModel model, string checkDate)
        {
            return this.dal.UpdateByMiniSTPad(model, checkDate);
        }

        public RecordsAssistCheckModel GetModelByOutKey(int OutKey)
        {
            DataSet ds = this.dal.GetModelByOutKey(OutKey);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsAssistCheckModel> list = ModelConvertHelper<RecordsAssistCheckModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return new RecordsAssistCheckModel();
        }

        public bool UpdateByMiniPad(RecordsAssistCheckModel model, string checkDate)
        {
            return this.dal.UpdateByMiniPad(model, checkDate);
        }

        /// <summary>
        /// 新尿常规同步
        /// </summary>
        /// <param name="model"></param>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public bool Update(RecordsAssistCheckModel model, string barCode)
        {
            return this.dal.Update(model, barCode);
        }

        /// <summary>
        /// 心电B超同步更新辅助检查
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="OutKey"></param>
        /// <param name="ECG"></param>
        /// <param name="ECGEx"></param>
        /// <param name="BChao"></param>
        /// <param name="BChaoEx"></param>
        /// <returns></returns>
        public bool UpdateByEcg(string IDCardNo, string OutKey, string ECG, string ECGEx, string BChao, string BChaoEx)
        {
            return this.dal.UpdateByEcg(IDCardNo, OutKey, ECG, ECGEx, BChao, BChaoEx);
        }

        /// <summary>
        /// B超正常异常信息更新到健康体检中
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBC(RecordsAssistCheckModel model)
        {
            return this.dal.UpdateBC(model);
        }

        /// <summary>
        /// 妇科B超更新查体其他
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBC(RecordsPhysicalExamModel model)
        {
            return this.dal.UpdateBC(model);
        }

        /// <summary>
        /// 双肾更新健康问题肾脏其他
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBC(RecordsHealthQuestionModel model)
        {
            return this.dal.UpdateBC(model);
        }

        /// <summary>
        /// 其他系统疾病
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateQT(RecordsHealthQuestionModel model)
        {
            return this.dal.UpdateQT(model);
        }

        /// <summary>
        /// 更新既往史
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <param name="illOther"></param>
        /// <param name="diagnoseTime"></param>
        /// <returns></returns>
        public bool UpdateIllHistory(string idCardNo, string illOther, string diagnoseTime)
        {
            return this.dal.UpdateIllHistory(idCardNo, illOther, diagnoseTime);
        }
    }
}
