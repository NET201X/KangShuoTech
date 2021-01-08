using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.Utilities.Common;
using System.Data;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class RecordsMedicineResultBLL
    {
        private readonly RecordsMedicineResultDAL dal = new RecordsMedicineResultDAL();

        public int Add(RecordsMedicineResultModel model)
        {
            return this.dal.Add(model);
        }

        public int Add(MedicineModel model)
        {
            return this.dal.Add(model);
        }

        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }

        public bool Update(RecordsMedicineResultModel model)
        {
            return this.dal.Update(model);
        }
    
        public RecordsMedicineResultModel GetModel(int ID)
        {
            DataSet ds = this.dal.GetModel(ID);

            if (ds != null && ds.Tables.Count > 0) 
            {
                List<RecordsMedicineResultModel> list = ModelConvertHelper<RecordsMedicineResultModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

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
    }
}
