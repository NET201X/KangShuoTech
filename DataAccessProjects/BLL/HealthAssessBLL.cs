using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class HealthAssessBLL
    {
        private readonly HealthAssessDAL dal = new HealthAssessDAL();
        public int Add(HealthAssessModel model)
        {
            return this.dal.Add(model);
        }
        public HealthAssessModel GetModel(int PID)
        {
            return this.dal.GetModel(PID);
        }
        public bool ExistsPID(string IDCardNo, int PID)
        {
            return this.dal.ExistsPID(IDCardNo,PID);
        }
        public bool Update(HealthAssessModel model)
        {
            return this.dal.Update(model);
        }
    }
}
