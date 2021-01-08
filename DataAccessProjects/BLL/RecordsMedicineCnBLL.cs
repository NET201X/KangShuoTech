using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class RecordsMedicineCnBLL
    {
        private readonly RecordsMedicineCnDAL dal = new RecordsMedicineCnDAL();

        public int Add(RecordsMedicineCnModel model)
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

        public bool Update(RecordsMedicineCnModel model)
        {
            return this.dal.Update(model);
        }
  
        public RecordsMedicineCnModel GetModel(int ID)
        {
            DataSet ds = this.dal.GetModel(ID);

            if (ds != null && ds.Tables.Count > 0) 
            {
                List<RecordsMedicineCnModel> list = ModelConvertHelper<RecordsMedicineCnModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

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
    }
}
