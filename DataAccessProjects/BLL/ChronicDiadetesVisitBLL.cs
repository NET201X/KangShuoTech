
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.BLL
{
    using System.Collections.Generic;
    using System.Data;
    using Utilities.Common;

    public class ChronicDiadetesVisitBLL : InterfaceDataList 
    {
        private readonly ChronicDiadetesVisitDAL dal = new ChronicDiadetesVisitDAL();

        public int Add(ChronicDiadetesVisitModel model)
        {
            return this.dal.Add(model);
        }
        
        public List<ChronicDiadetesVisitModel> DataTableToList(DataTable dt)
        {
            List<ChronicDiadetesVisitModel> list = new List<ChronicDiadetesVisitModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    ChronicDiadetesVisitModel item = this.dal.DataRowToModel(dt.Rows[i]);
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

        public ChronicDiadetesVisitModel ExistsCheckDate(ChronicDiadetesVisitModel model)
        {
            return this.dal.ExistsCheckDate(model);
        }
        
        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        
        public ChronicDiadetesVisitModel GetModels(string IDCardNo)
        {
            return this.dal.GetModels(IDCardNo);
        }

        public ChronicDiadetesVisitModel GetModelID(int ID)
        {
            return this.dal.GetModelID(ID);
        }

        /// <summary>
        /// 取最后一次随访
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

        public List<ChronicDiadetesVisitModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(ChronicDiadetesVisitModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateDate(ChronicDiadetesVisitModel model)
        {
            return dal.UpdateDate(model);
        }
        
        public DataSet DtDiadetesCount()
        {
            return this.dal.DtDiadetesCount();
        }
    }
}