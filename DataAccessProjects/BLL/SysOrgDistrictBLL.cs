namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class SysOrgDistrictBLL
    {
        private readonly SysOrgDistrictDAL dal = new SysOrgDistrictDAL();

        public bool Add(SysOrgDistrictModel model)
        {
            return this.dal.Add(model);
        }

        public List<SysOrgDistrictModel> DataTableToList(DataTable dt)
        {
            List<SysOrgDistrictModel> list = new List<SysOrgDistrictModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    SysOrgDistrictModel item = this.dal.DataRowToModel(dt.Rows[i]);
                    if (item != null)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public bool Delete()
        {
            return this.dal.Delete();
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

        public SysOrgDistrictModel GetModel(string code)
        {
            return this.dal.GetModel(code);
        }

        public SysOrgDistrictModel GetModelByCache(string code)
        {
            string cacheKey = "SYS_ORG_DISTRICTModel-";
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel(code);
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
            return (SysOrgDistrictModel)cache;
        }

        public List<SysOrgDistrictModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(SysOrgDistrictModel model)
        {
            return this.dal.Update(model);
        }
    }
}

