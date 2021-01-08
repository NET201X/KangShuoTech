namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class RecordsFamilyBedHistoryBLL
    {
        private readonly RecordsFamilyBedHistoryDAL dal = new RecordsFamilyBedHistoryDAL();

        public int Add(RecordsFamilyBedHistoryModel model)
        {
            return this.dal.Add(model);
        }

        public int AddServer(RecordsFamilyBedHistoryModel model)
        {
            return this.dal.AddServer(model);
        }

        public List<RecordsFamilyBedHistoryModel> DataTableToList(DataTable dt)
        {
            List<RecordsFamilyBedHistoryModel> list = new List<RecordsFamilyBedHistoryModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    RecordsFamilyBedHistoryModel item = this.dal.DataRowToModel(dt.Rows[i]);
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

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public RecordsFamilyBedHistoryModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }

        public RecordsFamilyBedHistoryModel GetModelByCache(string IDCardNo)
        {
            string cacheKey = "ARCHIVE_FAMILYBEDHISTORYModel-" + IDCardNo;
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
            return (RecordsFamilyBedHistoryModel)cache;
        }

        public List<RecordsFamilyBedHistoryModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(RecordsFamilyBedHistoryModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateServer(RecordsFamilyBedHistoryModel model)
        {
            return this.dal.UpdateServer(model);
        }
        public bool DeleteByOutKey(int OutKey)
        {
            return this.dal.DeleteByOutKey(OutKey);
        }
    }
}

