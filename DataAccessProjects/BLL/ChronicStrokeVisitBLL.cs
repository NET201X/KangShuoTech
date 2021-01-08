﻿namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ChronicStrokeVisitBLL :InterfaceDataList
    {
        private readonly ChronicStrokeVisitDAL dal = new ChronicStrokeVisitDAL();

        public int Add(ChronicStrokeVisitModel model)
        {
            return this.dal.Add(model);
        }

        public int AddServer(ChronicStrokeVisitModel model)
        {
            return this.dal.AddServer(model);
        }

        public List<ChronicStrokeVisitModel> DataTableToList(DataTable dt)
        {
            List<ChronicStrokeVisitModel> list = new List<ChronicStrokeVisitModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    ChronicStrokeVisitModel item = this.dal.DataRowToModel(dt.Rows[i]);
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
        public ChronicStrokeVisitModel ExistsCheckDate(ChronicStrokeVisitModel model)
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

        public ChronicStrokeVisitModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }
        public ChronicStrokeVisitModel GetModelFollowUpDate(ChronicStrokeVisitModel model)
        {
            return this.dal.GetModelFollowUpDate(model);
        }
        public ChronicStrokeVisitModel GetModelID(int ID)
        {
            return this.dal.GetModelID(ID);
        }

        public ChronicStrokeVisitModel GetModelByCache(int ID)
        {
            string cacheKey = "CD_STROKE_FOLLOWUPModel-" + ID;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel(ID.ToString());
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
            return (ChronicStrokeVisitModel) cache;
        }

        public List<ChronicStrokeVisitModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(ChronicStrokeVisitModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateServer(ChronicStrokeVisitModel model)
        {
            return this.dal.UpdateServer(model);
        }


        public DataSet DtStrokeCount()
        {
            return this.dal.DtStrokeCount();
        }
    }
}

