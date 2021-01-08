using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class HealthHouseMediPhyBLL
    {
        public readonly HealthHouseMediPhyDAL dal = new HealthHouseMediPhyDAL();
        public int Add(HealthHouseMediPhyModel model)
        {
            return this.dal.Add(model);
        }
        public HealthHouseMediPhyModel GetModel(int PID)
        {
            return this.dal.GetModel(PID);
        }
        public bool Update(HealthHouseMediPhyModel model)
        {
            return this.dal.Update(model);
        }
    }
}
