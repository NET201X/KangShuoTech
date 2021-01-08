namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ChronicMentalDiseaseVisitBLL : InterfaceDataList
    {
        private readonly ChronicMentalDiseaseVisitDAL dal = new ChronicMentalDiseaseVisitDAL();

        public int Add(ChronicMentalDiseaseVisitModel model)
        {
            return this.dal.Add(model);
        }

        public int AddServer(ChronicMentalDiseaseVisitModel model)
        {
            return this.dal.AddServer(model);
        }

        public List<ChronicMentalDiseaseVisitModel> DataTableToList(DataTable dt)
        {
            List<ChronicMentalDiseaseVisitModel> list = new List<ChronicMentalDiseaseVisitModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    ChronicMentalDiseaseVisitModel item = this.dal.DataRowToModel(dt.Rows[i]);
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
        public bool ExistVisitdate(string visitdate, string IDCardNo)
        {
            return this.dal.ExistVisitdate(visitdate, IDCardNo);
        }
        public ChronicMentalDiseaseVisitModel ExistsCheckDate(ChronicMentalDiseaseVisitModel model)
        {
            return this.dal.ExistsCheckDate(model);
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

        public ChronicMentalDiseaseVisitModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }

        public ChronicMentalDiseaseVisitModel GetModelFollowUpDate(ChronicMentalDiseaseVisitModel model)
        {
            return this.dal.GetModelFollowUpDate(model);
        }

        public ChronicMentalDiseaseVisitModel GetModelID(int ID)
        {
            return this.dal.GetModelID(ID);
        }

        public ChronicMentalDiseaseVisitModel GetModelByCache(string IDCardNo)
        {
            string cacheKey = "CD_MENTALDISEASE_FOLLOWUPModel-" + IDCardNo;
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
            return (ChronicMentalDiseaseVisitModel) cache;
        }

        public List<ChronicMentalDiseaseVisitModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(ChronicMentalDiseaseVisitModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateServer(ChronicMentalDiseaseVisitModel model)
        {
            return this.dal.UpdateServer(model);
        }
        public DataSet DtMentaldiseaseCount()
        {
            return this.dal.DtMentaldiseaseCount();
        }
    }
}

