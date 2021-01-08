
namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonDAL;
    using CommonModel;
    using System.Collections.Generic;
    using System.Data;

    public class RequireBLL
    {
        private readonly RequireDAL dal = new RequireDAL();

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet GetDecimalData(string TabName, string Comment, string ChinName)
        {
            return this.dal.GetDecimalData(TabName, Comment, ChinName);
        }

        public bool UpdateID(int id, string Isrequired, string IsDecimalPlace, int DecimalPlace, string IsOdevity, string SetValue, string isSetValue, string ItemValue)
        {
            return this.dal.UpdateID(id,Isrequired,IsDecimalPlace,DecimalPlace,IsOdevity,SetValue,isSetValue,ItemValue);
        }

        public List<RequireModel> GetModel(string TabName, string Comment, string ChinName)
        {
            DataSet ds = this.dal.GetData(TabName, Comment, ChinName);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                List<RequireModel> list = ModelConvertHelper<RequireModel>.ToList(ds.Tables[0]);

               return list;
            }

            return null;
        }

        public void UpdateTable(string TableName, string OpitonName, string DecimalPlace)
        {
            dal.UpdateTable(TableName, OpitonName, DecimalPlace);
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
