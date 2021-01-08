namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class KidsTcmhmOneBLL
    {
        private readonly KidsTcmhmOneDAL dal = new KidsTcmhmOneDAL();

        public int Add(KidsTcmhmOneModel model)
        {
            return this.dal.Add(model);
        }

        public int AddServer(KidsTcmhmOneModel model)
        {
            return this.dal.AddServer(model);
        }

        public List<KidsTcmhmOneModel> DataTableToList(DataTable dt)
        {
            List<KidsTcmhmOneModel> list = new List<KidsTcmhmOneModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    KidsTcmhmOneModel item = this.dal.DataRowToModel(dt.Rows[i]);
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

        public KidsTcmhmOneModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }

        public KidsTcmhmOneModel GetModelByCache(int ID)
        {
            string cacheKey = "CHILD_TCMHM_ONEModel-" + ID;
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
            return (KidsTcmhmOneModel)cache;
        }

        public List<KidsTcmhmOneModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(KidsTcmhmOneModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateServer(KidsTcmhmOneModel model)
        {
            return this.dal.UpdateServer(model);
        }
    }
}

