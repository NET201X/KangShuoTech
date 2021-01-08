namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class SysOrgProvinceBLL
    {
        private readonly SysOrgProvinceDAL dal = new SysOrgProvinceDAL();

        public bool Add(SysOrgProvinceModel model)
        {
            return this.dal.Add(model);
        }

        public List<SysOrgProvinceModel> DataTableToList(DataTable dt)
        {
            List<SysOrgProvinceModel> list = new List<SysOrgProvinceModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    SysOrgProvinceModel item = this.dal.DataRowToModel(dt.Rows[i]);
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

        public SysOrgProvinceModel GetModel()
        {
            return this.dal.GetModel();
        }

        public SysOrgProvinceModel GetModelByCache()
        {
            string cacheKey = "SYS_ORG_PROVINCEModel-";
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel();
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
            return (SysOrgProvinceModel)cache;
        }

        public List<SysOrgProvinceModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(SysOrgProvinceModel model)
        {
            return this.dal.Update(model);
        }
    }
}

