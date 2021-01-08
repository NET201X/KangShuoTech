namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class RecordsMediPhysDistBLL
    {
        private readonly RecordsMediPhysDistDAL dal = new RecordsMediPhysDistDAL();

        public int Add(RecordsMediPhysDistModel model)
        {
            return this.dal.Add(model);
        }

        public int AddServer(RecordsMediPhysDistModel model)
        {
            return this.dal.AddServer(model);
        }

        public List<RecordsMediPhysDistModel> DataTableToList(DataTable dt)
        {
            List<RecordsMediPhysDistModel> list = new List<RecordsMediPhysDistModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    RecordsMediPhysDistModel item = this.dal.DataRowToModel(dt.Rows[i]);
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

        public RecordsMediPhysDistModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }

        public RecordsMediPhysDistModel GetModelByCache(string IDCardNo)
        {
            string cacheKey = "ARCHIVE_MEDI_PHYS_DISTModel-" + IDCardNo;
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
            return (RecordsMediPhysDistModel)cache;
        }

        public List<RecordsMediPhysDistModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(RecordsMediPhysDistModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateServer(RecordsMediPhysDistModel model)
        {
            return this.dal.UpdateServer(model);
        }
        public RecordsMediPhysDistModel GetModelByOutKey(int OutKey)
        {
            return this.dal.GetModelByOutKey(OutKey);
        }
        public bool ExistsOutKey(string IDCardNo, int OutKey)
        {
            return this.dal.ExistsOutKey(IDCardNo, OutKey);
        }
    }
}

