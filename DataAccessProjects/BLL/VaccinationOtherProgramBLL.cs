namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class VaccinationOtherProgramBLL
    {
        private readonly VaccinationOtherProgramDAL dal = new VaccinationOtherProgramDAL();

        public int Add(VaccinationOtherProgramModel model)
        {
            return this.dal.Add(model);
        }

        public List<VaccinationOtherProgramModel> DataTableToList(DataTable dt)
        {
            List<VaccinationOtherProgramModel> list = new List<VaccinationOtherProgramModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    VaccinationOtherProgramModel item = this.dal.DataRowToModel(dt.Rows[i]);
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

        public VaccinationOtherProgramModel GetModel(int ID)
        {
            return this.dal.GetModel(ID);
        }

        public VaccinationOtherProgramModel GetModelByCache(int ID)
        {
            string cacheKey = "INOCULATION_OTHERPROGRAMModel-" + ID;
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
            return (VaccinationOtherProgramModel) cache;
        }

        public List<VaccinationOtherProgramModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(VaccinationOtherProgramModel model)
        {
            return this.dal.Update(model);
        }
    }
}

