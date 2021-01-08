using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.DAL;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class HealthHouseMedicineResultBLL
    {
        private readonly HealthHouseMedicineResultDAL dal = new HealthHouseMedicineResultDAL();
        public int Add(HealthHouseMedicineResultModel model)
        {
            return this.dal.Add(model);
        }
        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }
        public HealthHouseMedicineResultModel GetModel(int ID)
        {
            return this.dal.GetModel(ID);
        }
        public bool Update(HealthHouseMedicineResultModel model)
        {
            return this.dal.Update(model);
        }
    }
}
