namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class RecordsLifeStyleBLL
    {
        private readonly RecordsLifeStyleDAL dal = new RecordsLifeStyleDAL();

        public int Add(RecordsLifeStyleModel model)
        {
            return this.dal.Add(model);
        }
        public int AddServer(RecordsLifeStyleModel model)
        {
            return this.dal.AddServer(model);
        }

        public List<RecordsLifeStyleModel> DataTableToList(DataTable dt)
        {
            List<RecordsLifeStyleModel> list = new List<RecordsLifeStyleModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    RecordsLifeStyleModel item = this.dal.DataRowToModel(dt.Rows[i]);
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

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }
        public DataSet GetRecordslifestyledt(string IDCardNo, int OutKey)
        {
            return this.dal.GetRecordslifestyledt(IDCardNo, OutKey);
        }
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public RecordsLifeStyleModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }

        public RecordsLifeStyleModel GetModelByCache(string IDCardNo)
        {
            string cacheKey = "ARCHIVE_LIFESTYLEModel-" + IDCardNo;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel(IDCardNo);
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
            return (RecordsLifeStyleModel)cache;
        }

        public List<RecordsLifeStyleModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(RecordsLifeStyleModel model)
        {
            return this.dal.Update(model);
        }
        public bool UpdateServer(RecordsLifeStyleModel model)
        {
            return this.dal.UpdateServer(model);
        }
        public RecordsLifeStyleModel GetModelByOutKey(int outKey)
        {
            return this.dal.GetModelByOutKey(outKey);
        }
        public bool ExistsOutKey(string IDCardNo, int OutKey)
        {
            return this.dal.ExistsOutKey(IDCardNo,OutKey);
        }
        public bool UpdateByTJMiniPad(RecordsLifeStyleModel model, string checkDate)
        {
            return this.dal.UpdateByTJMiniPad(model, checkDate);
        }
    }
}

