namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using System.Data;
    using System.Collections.Generic;
    using CommonDAL;
    using CommonModel;

    public class RecordsEnvironmentBLL
    {
        private readonly RecordsEnvironmentDAL dal = new RecordsEnvironmentDAL();
        
        public RecordsEnvironmentModel GetModel(string IDCardNo)
        {
            DataSet ds= this.dal.GetModel(IDCardNo);

            if (ds != null && ds.Tables.Count > 0) 
            {
                List<RecordsEnvironmentModel> list = ModelConvertHelper<RecordsEnvironmentModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return new RecordsEnvironmentModel();
        }
    }
}

