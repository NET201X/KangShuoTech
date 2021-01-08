using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.DataAccessProjects.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ChronicChdBaseInfoBLL
    {
        private readonly ChronicChdBaseInfoDAL dal = new ChronicChdBaseInfoDAL();

        public int Add(ChronicChdBaseInfoModel model)
        {
            return this.dal.Add(model);
        }

        public int AddServer(ChronicChdBaseInfoModel model)
        {
            return this.dal.AddServer(model);
        }

        public List<ChronicChdBaseInfoModel> DataTableToList(DataTable dt)
        {
            List<ChronicChdBaseInfoModel> list = new List<ChronicChdBaseInfoModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    ChronicChdBaseInfoModel item = this.dal.DataRowToModel(dt.Rows[i]);
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
        public bool DelOUTkey(int OUTkey)
        {
            return this.dal.DelOUTkey(OUTkey);
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

        public ChronicChdBaseInfoModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }

        public ChronicChdBaseInfoModel GetModelByCache(int ID)
        {
            string cacheKey = "CD_CHD_BASEINFOModel-" + ID;
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
            return (ChronicChdBaseInfoModel)cache;
        }

        public List<ChronicChdBaseInfoModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(ChronicChdBaseInfoModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateServer(ChronicChdBaseInfoModel model)
        {
            return this.dal.UpdateServer(model);
        }
    }
}

