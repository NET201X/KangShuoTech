namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ConsulationDoctorsBLL
    {
        private readonly ConsulationDoctorsDAL cdDAL = new ConsulationDoctorsDAL();
        public int Add(List< ConsulationDoctorsModel>cdModel)
        {
            return this.cdDAL.Add(cdModel);
        }
        public int AddServer(List<ConsulationDoctorsModel> model)
        {
            return this.cdDAL.AddServer(model);
        }
        public DataSet GetList(string strWhere)
        {
            return this.cdDAL.GetList(strWhere);
        }
        public bool Update(List<ConsulationDoctorsModel> cdModel)
        {
            return this.cdDAL.Update(cdModel);
        }
        public bool DeleteList(string IDlist)
        {
            return this.cdDAL.DeleteList(IDlist);
        }
    }
}
