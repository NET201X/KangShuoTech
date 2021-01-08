using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.DataAccessProjects.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ChronicLungerFirstVisitBLL : InterfaceDataList
    {
        private readonly ChronicLungerFirstVisitDAL dal = new ChronicLungerFirstVisitDAL();

        public int Add(ChronicLungerFirstVisitModel model)
        {
            return this.dal.Add(model);
        }

        public List<ChronicLungerFirstVisitModel> DataTableToList(DataTable dt)
        {
            List<ChronicLungerFirstVisitModel> list = new List<ChronicLungerFirstVisitModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    ChronicLungerFirstVisitModel item = this.dal.DataRowToModel(dt.Rows[i]);
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
        public bool DelOUTkey(int ID)
        {
            return this.dal.DelOUTkey(ID);
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

        public ChronicLungerFirstVisitModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }

        public ChronicLungerFirstVisitModel GetModelByCache(string IDCardNo)
        {
            string cacheKey = "CD_DIABETESFOLLOWUPModel-" + IDCardNo;
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
            return (ChronicLungerFirstVisitModel)cache;
        }

        public List<ChronicLungerFirstVisitModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(ChronicLungerFirstVisitModel model)
        {
            return this.dal.Update(model);
        }
        public ChronicLungerFirstVisitModel GetModelByID(int ID)
        {
            return this.dal.GetModelByID(ID);
        }
        public ChronicLungerFirstVisitModel CheckModel(string strWhere)
        {
            return this.dal.CheckModel(strWhere);
        }
    }
}
