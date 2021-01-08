using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.BLL
{
    using Utilities.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class SystemErrorLogBLL
    {
        private readonly SystemErrorLogDAL dal = new SystemErrorLogDAL();

        public int Add(SystemErrorLogModel model)
        {
            return this.dal.Add(model);
        }

        public void CheckTable(string tables)
        {
            this.dal.CheckTable(tables);
        }

        public List<SystemErrorLogModel> DataTableToList(DataTable dt)
        {
            List<SystemErrorLogModel> list = new List<SystemErrorLogModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    SystemErrorLogModel item = this.dal.DataRowToModel(dt.Rows[i]);
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

        public SystemErrorLogModel GetModel(int ID)
        {
            return this.dal.GetModel(ID);
        }

        public SystemErrorLogModel GetModelByCache(int ID)
        {
            string cacheKey = "SystemErrorLog-" + ID;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel(ID);
                    if (cache != null)
                    {
                        int configInt = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(cacheKey, cache, DateTime.Now.AddMinutes((double) configInt), TimeSpan.Zero);
                    }
                }
                catch
                {
                }
            }
            return (SystemErrorLogModel) cache;
        }

        public List<SystemErrorLogModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(SystemErrorLogModel model)
        {
            return this.dal.Update(model);
        }
    }
}

