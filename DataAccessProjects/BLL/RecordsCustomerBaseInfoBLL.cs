namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System.Collections.Generic;
    using System.Data;

    public class RecordsCustomerBaseInfoBLL
    {
        private readonly RecordsCustomerBaseInfoDAL dal = new RecordsCustomerBaseInfoDAL();

        public int Add(RecordsCustomerBaseInfoModel model)
        {
            return this.dal.Add(model);
        }

        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public RecordsCustomerBaseInfoModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }

        public bool Update(RecordsCustomerBaseInfoModel model)
        {
            return this.dal.Update(model);
        }

        public int GetCustomerRecordCount(string strWhere)
        {
            return this.dal.GetCustomerRecordCount(strWhere);        
        }

        public DataSet GetCustomerListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetCustomerListByPage(strWhere, orderby,startIndex,endIndex);
        }

        public RecordsCustomerBaseInfoModel GetMaxModel(string IDCardNo)
        {
            return this.dal.GetMaxModel(IDCardNo);
        }

        public RecordsCustomerBaseInfoModel GetModelByID(int ID)
        {
            return this.dal.GetModelByID(ID);
        }

        public RecordsCustomerBaseInfoModel GetModelByWhere(string strWhere)
        {
            return this.dal.GetModelByWhere(strWhere);
        }

        public DataSet GetTownList()
        {
            return this.dal.GetTownList();
        }

        public DataSet GetVillageList(string strWhere)
        {
            return this.dal.GetVillageList(strWhere);
        }

        public RecordsCustomerBaseInfoModel GetModelByCheckDate(string IDCardNo, string checkDate)
        {
            DataSet ds = this.dal.GetModelByCheckDate(IDCardNo, checkDate);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsCustomerBaseInfoModel> list = ModelConvertHelper<RecordsCustomerBaseInfoModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return new RecordsCustomerBaseInfoModel();
        }
    }
}

