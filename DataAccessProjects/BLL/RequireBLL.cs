
namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class RequireBLL
    {
        private readonly RequireDAL dal = new RequireDAL();
        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }
        public RequireModel GetModel(int ID)
        {
            return this.dal.GetModel(ID);
        }
        public RequireModel GetModel(string TabName, string Comment, string ChinName)
        {
            return dal.GetModel(TabName,Comment,ChinName);
        }
        public List<RequireModel> GetModelList()
        {
            return dal.GetModelList();
        }
        public bool UpdateID(int id, string Isrequired, string SetValue = "", string isSetValue = "", string ItemValue = "")
        {
            return this.dal.UpdateID(id, Isrequired, SetValue, isSetValue, ItemValue);
        }
        public bool UpdateID(int id, string Isrequired, string IsDecimalPlace, int DecimalPlace, string IsOdevity, string SetValue, string isSetValue, string ItemValue)
        {
            return this.dal.UpdateID(id, Isrequired, IsDecimalPlace, DecimalPlace, IsOdevity, SetValue, isSetValue, ItemValue);
        }
        public void UpdateTable(string TableName, string OpitonName, string DecimalPlace)
        {
            dal.UpdateTable(TableName, OpitonName, DecimalPlace);
        }
        public DataSet GetOutBaseInfoDt(string strWhere)
        {
            return this.dal.GetOutBaseInfoDt(strWhere);
        }
        public DataSet GetTabName()
        {
            return this.dal.GetTabName();
        }
        public DataSet GetComment()
        {
            return this.dal.GetComment();
        }
    }
}
