﻿namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class WomenGravidaPostpartum42DayBLL
    {
        private readonly WomenGravidaPostpartum42DayDAL dal = new WomenGravidaPostpartum42DayDAL();

        public int Add(WomenGravidaPostpartum42DayModel model)
        {
            return this.dal.Add(model);
        }

        public int AddServer(WomenGravidaPostpartum42DayModel model)
        {
            return this.dal.AddServer(model);
        }

        public List<WomenGravidaPostpartum42DayModel> DataTableToList(DataTable dt)
        {
            List<WomenGravidaPostpartum42DayModel> list = new List<WomenGravidaPostpartum42DayModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    WomenGravidaPostpartum42DayModel item = this.dal.DataRowToModel(dt.Rows[i]);
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

        public WomenGravidaPostpartum42DayModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }

        public WomenGravidaPostpartum42DayModel GetModelByCache(string IDCardNo)
        {
            string cacheKey = "GRAVIDA_POSTPARTUM_42DAYModel-" + IDCardNo;
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
            return (WomenGravidaPostpartum42DayModel) cache;
        }

        public List<WomenGravidaPostpartum42DayModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(WomenGravidaPostpartum42DayModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateServer(WomenGravidaPostpartum42DayModel model)
        {
            return this.dal.UpdateServer(model);
        }
    }
}

