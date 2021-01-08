namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    public class ReferraBaseInfoBLL : InterfaceDataList
    {
        private readonly ReferraBaseInfoDAL dal = new ReferraBaseInfoDAL();

        public int Add(ReferraBaseInfoModel model)
        {
            return this.dal.Add(model);
        }
        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }
        public ReferraBaseInfoModel GetModel(int ID)
        {
            return this.dal.GetModel(ID);
        }
        public bool Update(ReferraBaseInfoModel model)
        {
            return this.dal.Update(model);
        }
        public ReferraBaseInfoModel GetMaxModel(string IDCard)
        {
            return this.dal.GetMaxModel(IDCard);
        }
        public DataSet GetList(string IDCard)
        {
            return this.dal.GetList(IDCard);
        }
    }
}
