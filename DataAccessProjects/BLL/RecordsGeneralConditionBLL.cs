namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System.Collections.Generic;
    using System.Data;

    public class RecordsGeneralConditionBLL
    {
        private readonly RecordsGeneralConditionDAL dal = new RecordsGeneralConditionDAL();

        public int Add(RecordsGeneralConditionModel model)
        {
            return this.dal.Add(model);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet Getrecordsgeneralconditiondt(string IDCardNo, int OutKey)
        {
            return this.dal.Getrecordsgeneralconditiondt(IDCardNo, OutKey);
        }

        public RecordsGeneralConditionModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }

        public bool Update(RecordsGeneralConditionModel model)
        {
            return this.dal.Update(model);
        }

        public RecordsGeneralConditionModel GetModelByOutKey(int ID)
        {
            return this.dal.GetModelByOutKey(ID);
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

        #region 新同步方式

        public bool UpdateByMiniPad(RecordsGeneralConditionModel model, string checkDate) //血压更新
        {
            return this.dal.UpdateByMiniPad(model, checkDate);
        }

        public bool UpdateByMiniTTPad(RecordsGeneralConditionModel model, string checkDate)
        {
            return this.dal.UpdateByMiniTTPad(model, checkDate);
        }

        public bool UpdateByMiniSTPad(RecordsGeneralConditionModel model, string checkDate)
        {
            return this.dal.UpdateByMiniSTPad(model, checkDate);
        }

        public bool UpdateByMiniTWPad(RecordsGeneralConditionModel model, string checkDate)
        {
            return this.dal.UpdateByMiniTWPad(model, checkDate);
        }
        
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

        public bool UpdateBMI(int outKey, decimal? bMI)
        {
            return this.dal.UpdateBMI(outKey, bMI);
        }

        #endregion
    }
}

