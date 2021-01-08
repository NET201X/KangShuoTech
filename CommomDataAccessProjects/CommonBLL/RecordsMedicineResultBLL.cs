using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsMedicineResultBLL
    {
        private readonly RecordsMedicineResultDAL dal = new RecordsMedicineResultDAL();

        /// <summary>
        /// 更新中医体质结果
        /// </summary>
        /// <param name="model"></param>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public bool UpdateByMiniPad(MedicineModel model, string customerID)
        {
            return this.dal.UpdateByMiniPad(model, customerID);
        }

        /// <summary>
        /// 更新体检中 中医体质辨识
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public bool UpdateMediphysDist(MedicineModel model, string customerID)
        {
            return this.dal.UpdateMediphysDist(model, customerID);
        }

        /// <summary>
        /// 更新体检中 中医体质辨识得分Key
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="ID"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMediphysDist(string customerID, int ID, MedicineModel model)
        {
            return this.dal.UpdateMediphysDist(customerID, ID, model);
        }

        public int Add(MedicineModel model)
        {
            return this.dal.Add(model);
        }
    }
}
