using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class HealthSelfCareabilityBLL
    {
        private readonly HealthSelfCareabilityDAL dal = new HealthSelfCareabilityDAL();
        public int Add(HealthSelfCareabilityModel model)
        {
            return this.dal.Add(model);
        }
        public HealthSelfCareabilityModel GetModel(int PID)
        {
            return this.dal.GetModel(PID);
        }
        public bool ExistsPID(string IDCardNo, int PID)
        {
            return this.dal.ExistsPID(IDCardNo,PID);
        }
        public bool Update(HealthSelfCareabilityModel model)
        {
            return this.dal.Update(model);
        }
    }
}
