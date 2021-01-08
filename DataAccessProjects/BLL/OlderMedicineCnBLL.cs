namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class OlderMedicineCnBLL
    {
        private readonly OlderMedicineCnDAL dal = new OlderMedicineCnDAL();

        public int Add(OlderMedicineCnModel model)
        {
            return this.dal.Add(model);
        }

        public int Add(MedicineModel model)
        {
            return this.dal.Add(model);
        }

        public bool DelOUTkey(int OUTkey)
        {
            return this.dal.DelOUTkey(OUTkey);
        }

        public bool ExistOutKey(int OUTkey)
        {
            return this.dal.ExistOutKey(OUTkey);
        }
    
        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public OlderMedicineCnModel GetModel(string IDCardNo, int OUTKey)
        {
            DataSet ds = this.dal.GetModel(IDCardNo, OUTKey);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<OlderMedicineCnModel> list = ModelConvertHelper<OlderMedicineCnModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public OlderMedicineCnModel GetModelOUTKey(int ID)
        {
            DataSet ds = this.dal.GetModelOUTKey(ID);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<OlderMedicineCnModel> list = ModelConvertHelper<OlderMedicineCnModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return new OlderMedicineCnModel();
        }

        public bool Update(OlderMedicineCnModel model)
        {
            return this.dal.Update(model);
        }

        public bool Update(MedicineModel model)
        {
            return this.dal.Update(model);
        }
    }
}

