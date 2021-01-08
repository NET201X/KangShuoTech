using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.DataAccessProjects.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ChronicLungerVisitBLL :InterfaceDataList
    {
        private readonly ChronicLungerVisitDAL dal = new ChronicLungerVisitDAL();

        public int Add(ChronicLungerVisitModel model)
        {
            return this.dal.Add(model);
        }

        public List<ChronicLungerVisitModel> DataTableToList(DataTable dt)
        {
            List<ChronicLungerVisitModel> list = new List<ChronicLungerVisitModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    ChronicLungerVisitModel item = this.dal.DataRowToModel(dt.Rows[i]);
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

        public ChronicLungerVisitModel GetModel(string IDCardNo,string Count)
        {
            return this.dal.GetModel(IDCardNo,Count);
        }

        public ChronicLungerVisitModel GetModelByCache(string IDCardNo,string count)
        {
            string cacheKey = "CD_DIABETESFOLLOWUPModel-" + IDCardNo;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel(IDCardNo,count);
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
            return (ChronicLungerVisitModel)cache;
        }

        public List<ChronicLungerVisitModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(ChronicLungerVisitModel model)
        {
            return this.dal.Update(model);
        }
        public ChronicLungerVisitModel GetModelByOutKey(int OutKey, string Count)
        {
            return this.dal.GetModelByOutKey(OutKey,Count);
        }
        public bool ExistsOutKey(string IDCardNo, int OutKey, int VisitCount)
        {
            return this.dal.ExistsOutKey(IDCardNo, OutKey, VisitCount); 
        }
    }
}
