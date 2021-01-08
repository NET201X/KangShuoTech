using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.BLL
{
    using Utilities.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class RecordsHyperFoodsBLL
    {
        private readonly RecordsHyperFoodsDAL dal = new RecordsHyperFoodsDAL();
        public DataSet GetAllList()
        {
            return this.GetList("");
        }
        public int Add(RecordsHyperFoodsModel model)
        {
            return this.dal.Add(model);
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
        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }
        public RecordsHyperFoodsModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }
        public List<RecordsHyperFoodsModel> DataTableToList(DataTable dt)
        {
            List<RecordsHyperFoodsModel> list = new List<RecordsHyperFoodsModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    RecordsHyperFoodsModel item = this.dal.DataRowToModel(dt.Rows[i]);
                    if (item != null)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public List<RecordsHyperFoodsModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public bool Update(RecordsHyperFoodsModel model)
        {
            return this.dal.Update(model);
        }
        public bool ExistsOutKey(string IDCardNo, string FoodName, int OutKey)
        {
            return this.dal.ExistsOutKey(IDCardNo, FoodName,OutKey);
        }
    }
}
