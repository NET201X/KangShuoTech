using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsMedicineCnBLL
    {
        private readonly RecordsMedicineCnDAL dal = new RecordsMedicineCnDAL();

        /// <summary>
        /// 更新中医体质辨识33个问题项
        /// </summary>
        /// <param name="model"></param>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public bool UpdateByMiniPad(MedicineModel model, string customerID)
        {
            return this.dal.UpdateByMiniPad(model, customerID);
        }

        public int Add(MedicineModel model)
        {
            return this.dal.Add(model);
        }

        /// <summary>
        /// 更新体检中 中医体质辨识Key
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool UpdateMediphysDist(string customerID, int ID)
        {
            return this.dal.UpdateMediphysDist(customerID, ID);
        }

        public RecordsMediPhysDistModel GetModelByOutKey(int OutKey)
        {
            DataSet ds = this.dal.GetModelByOutKey(OutKey);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsMediPhysDistModel> list = ModelConvertHelper<RecordsMediPhysDistModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list[0];
            }

            return new RecordsMediPhysDistModel();
        }
    }

    public class RecordsSignatureBLL
    {
        private readonly RecordsSignatureDAL dal = new RecordsSignatureDAL();

        public RecordsSignatureModel GetModelByOutKey(int OutKey, string IdCardNo)
        {
            DataSet ds = this.dal.GetModelByOutKey(OutKey, IdCardNo);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsSignatureModel> list = ModelConvertHelper<RecordsSignatureModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list[0];
            }

            return new RecordsSignatureModel();
        }
    }
}
