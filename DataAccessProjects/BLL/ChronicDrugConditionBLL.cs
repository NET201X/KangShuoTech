using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.BLL
{
    using Utilities.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ChronicDrugConditionBLL
    {
        private readonly ChronicDrugconditionDAL dal = new ChronicDrugconditionDAL();

        public int Add(ChronicDrugConditionModel model)
        {
            return this.dal.Add(model);
        }

        public List<ChronicDrugConditionModel> DataTableToList(DataTable dt)
        {
            List<ChronicDrugConditionModel> list = new List<ChronicDrugConditionModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    ChronicDrugConditionModel item = this.dal.DataRowToModel(dt.Rows[i]);
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
        public bool DeleteOUTKey(int OUTKey, string drugType)
        {
            return this.dal.DeleteOUTKey(OUTKey, drugType);
        }
        public bool DeleteList(string IDlist)
        {
            return this.dal.DeleteList(IDlist);
        }

        public bool Exists(int ID)
        {
            return this.dal.Exists(ID);
        }

        public bool ExistOUTKey(int OUTKey, int ID, string drugType)
        {
            return this.dal.ExistOUTKey(OUTKey,ID, drugType);
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

        public ChronicDrugConditionModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }

        public ChronicDrugConditionModel GetModelByCache(string IDCardNo)
        {
            string cacheKey = "ChronicDrugConditionModel-" + IDCardNo;
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
            return (ChronicDrugConditionModel)cache;
        }

        public List<ChronicDrugConditionModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(ChronicDrugConditionModel model)
        {
            return this.dal.Update(model);
        }
        public bool UpdateOUTKey(ChronicDrugConditionModel model)
        {
            return this.dal.UpdateOUTKey(model);
        }
    }
}

