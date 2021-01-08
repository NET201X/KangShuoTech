namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class OlderMedicineResultBLL
    {
        private readonly OlderMedicineResultDAL dal = new OlderMedicineResultDAL();

        public int Add(OlderMedicineResultModel model)
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

        public bool ExistOUTKey(int ID)
        {
            return this.dal.ExistOUTKey(ID);
        }

        public OlderMedicineResultModel GetModel(string IDCardNo,int OUTKey)
        {
            DataSet ds = this.dal.GetModel(IDCardNo, OUTKey);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<OlderMedicineResultModel> list = ModelConvertHelper<OlderMedicineResultModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public OlderMedicineResultModel GetModelOUTKey(int ID)
        {
            DataSet ds = this.dal.GetModelOUTKey(ID);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<OlderMedicineResultModel> list = ModelConvertHelper<OlderMedicineResultModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return new OlderMedicineResultModel();
        }

        public bool Update(OlderMedicineResultModel model)
        {
            return this.dal.Update(model);
        }

        public bool Update(MedicineModel model)
        {
            return this.dal.Update(model);
        }
    }
}

