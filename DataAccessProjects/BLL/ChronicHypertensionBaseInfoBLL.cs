namespace KangShuoTech.DataAccessProjects.BLL
{
    using Utilities.Common;
    using DAL;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ChronicHypertensionBaseInfoBLL
    {
        private readonly ChronicHypertensionBaseInfoDAL dal = new ChronicHypertensionBaseInfoDAL();

        public int Add(ChronicHypertensionBaseInfoModel model)
        {
            return this.dal.Add(model);
        }

        public int AddServer(ChronicHypertensionBaseInfoModel model)
        {
            return this.dal.AddServer(model);
        }

        public List<ChronicHypertensionBaseInfoModel> DataTableToList(DataTable dt)
        {
            List<ChronicHypertensionBaseInfoModel> list = new List<ChronicHypertensionBaseInfoModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    ChronicHypertensionBaseInfoModel item = this.dal.DataRowToModel(dt.Rows[i]);
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
        public bool ExistIDCardNo(string IDCardNo)
        {
            return this.dal.ExistIDCardNo(IDCardNo);
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

        public ChronicHypertensionBaseInfoModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }
      
        public ChronicHypertensionBaseInfoModel GetModelByCache(string IDCardNo)
        {
            string cacheKey = "CD_HYPERTENSION_BASEINFOModel-" + IDCardNo;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel(IDCardNo);
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
            return (ChronicHypertensionBaseInfoModel) cache;
        }

        public List<ChronicHypertensionBaseInfoModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(ChronicHypertensionBaseInfoModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateServer(ChronicHypertensionBaseInfoModel model)
        {
            return this.dal.UpdateServer(model);
        }
    }
}

