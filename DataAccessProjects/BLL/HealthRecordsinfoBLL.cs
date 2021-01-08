using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using System.Data;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class HealthRecordsinfoBLL
    {
        private readonly HealthRecordsinfoDAL dal = new HealthRecordsinfoDAL();
        public int Add(HealthRecordsinfoModel model)
        {
            return this.dal.Add(model);
        }
        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }
        public bool Exists(int ID)
        {
            return this.dal.Exists(ID);
        }
        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }
        public HealthRecordsinfoModel GetModel(string IDCardNo)
        {
            return this.dal.GetModel(IDCardNo);
        }
        public bool Update(HealthRecordsinfoModel model)
        {
            return this.dal.Update(model);
        }
    }
}
