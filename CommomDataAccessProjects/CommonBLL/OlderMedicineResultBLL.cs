using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class OlderMedicineResultBLL
    {
        private readonly OlderMedicineResultDAL dal = new OlderMedicineResultDAL();

        public int Add(MedicineModel model, string Version = "V2.0")
        {
            return this.dal.Add(model, Version);
        }

        public bool Update(MedicineModel model, string Version = "V2.0")
        {
            return this.dal.Update(model, Version);
        }

        public OlderMedicineResultModel GetModel(int outKey)
        {
            DataSet ds = this.dal.GetModel(outKey);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<OlderMedicineResultModel> list = ModelConvertHelper<OlderMedicineResultModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return new OlderMedicineResultModel();
        }        
    }
}
