using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class HealthHouseMedicineCnBLL
    {
        public readonly HealthHouseMedicineCnDAL dal = new HealthHouseMedicineCnDAL();

        public int Add(HealthHouseMedicineCnModel model)
        {
            return this.dal.Add(model);
        }
        public HealthHouseMedicineCnModel GetModel(int ID)
        {
            return this.dal.GetModel(ID);
        }
        public bool Update(HealthHouseMedicineCnModel model)
        {
            return this.dal.Update(model);
        }
        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }
    }
}
