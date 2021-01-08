using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.DataAccessProjects.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ChronicChdVisitBLL : InterfaceDataList
    {
        private readonly ChronicChdVisitDAL dal = new ChronicChdVisitDAL();

        public int Add(ChronicChdVisitModel model)
        {
            return this.dal.Add(model);
        }

        public int AddServer(ChronicChdVisitModel model)
        {
            return this.dal.AddServer(model);
        }

        public List<ChronicChdVisitModel> DataTableToList(DataTable dt)
        {
            List<ChronicChdVisitModel> list = new List<ChronicChdVisitModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    ChronicChdVisitModel item = this.dal.DataRowToModel(dt.Rows[i]);
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

        public bool DeleteList(string IDlist)
        {
            return this.dal.DeleteList(IDlist);
        }

        public bool Exists(int ID)
        {
            return this.dal.Exists(ID);
        }
        public bool ExistVisitdate(string visitdate, string IDCardNo)
        {
            return this.dal.ExistVisitdate(visitdate, IDCardNo);
        }
        public ChronicChdVisitModel ExistsCheckDate(ChronicChdVisitModel model)
        {
            return this.dal.ExistsCheckDate(model);
        }
        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public ChronicChdVisitModel GetModel(string IDCard)
        {
            return this.dal.GetModel(IDCard);
        }

        public ChronicChdVisitModel GetModelFollowUpDate(ChronicChdVisitModel model)
        {
            return this.dal.GetModelFollowUpDate(model);
        }

        public ChronicChdVisitModel GetModelID(int ID)
        {
            return this.dal.GetModelID(ID);
        }

        public ChronicChdVisitModel GetModelByCache(int ID)
        {
            string cacheKey = "CD_CHD_FOLLOWUPModel-" + ID;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel(ID.ToString());
                    if (cache != null)
                    {
                        int configInt = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(cacheKey, cache, DateTime.Now.AddMinutes((double)configInt), TimeSpan.Zero);
                    }
                }
                catch
                {
                }
            }
            return (ChronicChdVisitModel)cache;
        }

        public List<ChronicChdVisitModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(ChronicChdVisitModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateServer(ChronicChdVisitModel model)
        {
            return this.dal.UpdateServer(model);
        }

        public DataSet DtChdCount()
        {
            return this.dal.DtChdCount();
        }
    }
}

