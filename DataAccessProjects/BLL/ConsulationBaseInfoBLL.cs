namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ConsulationBaseInfoBLL : InterfaceDataList
    {
        private readonly ConsulationBaseInfoDAL dal = new ConsulationBaseInfoDAL();
        public int Add(ConsulationBaseInfoModel model)
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
        public ConsulationBaseInfoModel GetModel(int ID)
        {
            return this.dal.GetModel(ID);
        }
        public bool Update(ConsulationBaseInfoModel model)
        {
            return this.dal.Update(model);
        }
        public ConsulationBaseInfoModel GetMaxModel(string IDCard)
        {
            return this.dal.GetMaxModel(IDCard);
        }
        public DataSet GetList(string IDCard)
        {
            return this.dal.GetList(IDCard);
        }

    }
}
