namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class RecordsSignatureBLL
    {
        private readonly RecordsSignatureDAL dal = new RecordsSignatureDAL();

        public int Add(RecordsSignatureModel model)
        {
            return this.dal.Add(model);
        }

        public RecordsSignatureModel GetModelByOutKey(int OutKey, string IdCardNo)
        {
            DataSet ds = this.dal.GetModelByOutKey(OutKey, IdCardNo);

            RecordsSignatureModel model = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsSignatureModel> list = CommonExtensions.ToList<RecordsSignatureModel>(ds.Tables[0]);

                if (list.Count > 0) model = list[0];
            }

            return model;
        }

        public RecordsSignatureModel GetModel(string IDCardNo)
        {
            DataSet ds = this.dal.GetModel(IDCardNo);
            RecordsSignatureModel model = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsSignatureModel> list = CommonExtensions.ToList<RecordsSignatureModel>(ds.Tables[0]);

                if (list.Count > 0) model = list[0];
            }

            return model;
        }

        public bool ExistsOutKey(string IDCardNo, int OutKey)
        {
            return this.dal.ExistsOutKey(IDCardNo, OutKey);
        }

        public bool Update(RecordsSignatureModel model)
        {
            return this.dal.Update(model);
        }
    }
}