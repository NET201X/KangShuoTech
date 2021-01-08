using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.BLL
{
    using Utilities.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class RecordsHyperSurveyBLL
    {
        private readonly RecordsHyperSurveyDAL dal = new RecordsHyperSurveyDAL();
        public int Add(RecordsHyperSurveyModel model)
        {
            return this.dal.Add(model);
        }
        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }

        public bool DeleteList(string IDlist)
        {
            return this.dal.DeleteList(IDlist);
        }

        public bool Exists(int ID)
        {
            return this.dal.Exists(ID);
        }
        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }
        public RecordsHyperSurveyModel GetModel(int OutKey)
        {
            return this.dal.GetModel(OutKey);
        }
        public List<RecordsHyperSurveyModel> DataTableToList(DataTable dt)
        {
            List<RecordsHyperSurveyModel> list = new List<RecordsHyperSurveyModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    RecordsHyperSurveyModel item = this.dal.DataRowToModel(dt.Rows[i]);
                    if (item != null)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public List<RecordsHyperSurveyModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public bool Update(RecordsHyperSurveyModel model)
        {
            return this.dal.Update(model);
        }
        public bool ExistsOutKey(string IDCardNo, int OutKey)
        {
            return this.dal.ExistsOutKey(IDCardNo,OutKey);
        }
    }
}
