namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ChronicHypertensionVisitBLL : InterfaceDataList
    {
        private readonly ChronicHypertensionVisitDAL dal = new ChronicHypertensionVisitDAL();

        public int Add(ChronicHypertensionVisitModel model)
        {
            return this.dal.Add(model);
        }

        public List<ChronicHypertensionVisitModel> DataTableToList(DataTable dt)
        {
            List<ChronicHypertensionVisitModel> list = new List<ChronicHypertensionVisitModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    ChronicHypertensionVisitModel item = this.dal.DataRowToModel(dt.Rows[i]);
                    if (item != null)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }
        
        public ChronicHypertensionVisitModel ExistsCheckDate(ChronicHypertensionVisitModel model)
        {
            return this.dal.ExistsCheckDate(model);
        }
        
        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet GetChypertensionvisitdt(string IDCardNo)
        {
            return this.dal.GetChypertensionvisitdt(IDCardNo);
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public ChronicHypertensionVisitModel GetModelID(int ID)
        {
            return this.dal.GetModelID(ID);
        }

        public ChronicHypertensionVisitModel GetModels(string IDCardNo)
        {
            return this.dal.GetModels(IDCardNo);
        }

        /// <summary>
        /// 取最后一次随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public ChronicHypertensionVisitModel GetMaxModel(string IDCardNo)
        {
            DataSet ds = dal.GetMaxModel(IDCardNo);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<ChronicHypertensionVisitModel> list = ModelConvertHelper<ChronicHypertensionVisitModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public List<ChronicHypertensionVisitModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(ChronicHypertensionVisitModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateDate(ChronicHypertensionVisitModel model)
        {
            return dal.UpdateDate(model);
        }
        
        public DataSet DtPertensionCount()
        {
            return this.dal.DtPertensionCount();
        }
    }
}

