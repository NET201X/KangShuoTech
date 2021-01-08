namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ChronicMentalDiseaseBaseInfoBLL
    {
        private readonly ChronicMentalDiseaseBaseInfoDAL dal = new ChronicMentalDiseaseBaseInfoDAL();

        public int Add(ChronicMentalDiseaseBaseInfoModel model)
        {
            return this.dal.Add(model);
        }

        public int AddServer(ChronicMentalDiseaseBaseInfoModel model)
        {
            return this.dal.AddServer(model);
        }

        public List<ChronicMentalDiseaseBaseInfoModel> DataTableToList(DataTable dt)
        {
            List<ChronicMentalDiseaseBaseInfoModel> list = new List<ChronicMentalDiseaseBaseInfoModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    ChronicMentalDiseaseBaseInfoModel item = this.dal.DataRowToModel(dt.Rows[i]);
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

        public ChronicMentalDiseaseBaseInfoModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }
      
        public ChronicMentalDiseaseBaseInfoModel GetModelByCache(string IDCardNo)
        {
            string cacheKey = "CD_MENTALDISEASE_BASEINFOModel-" + IDCardNo;
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
            return (ChronicMentalDiseaseBaseInfoModel) cache;
        }

        public List<ChronicMentalDiseaseBaseInfoModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(ChronicMentalDiseaseBaseInfoModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateServer(ChronicMentalDiseaseBaseInfoModel model)
        {
            return this.dal.UpdateServer(model);
        }
    }
}

