using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.BLL
{
    using System.Data;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    public class RecordsChdStrokeReportBLL
    {
        private readonly RecordsChdStrokeReportDAL dal=new RecordsChdStrokeReportDAL();
        public int Add(RecordsChdStrokeReportModel model)
        {
            return dal.Add(model);
        }

        public bool Update(RecordsChdStrokeReportModel model)
        {
            return dal.Update(model);
        }

        public RecordsChdStrokeReportModel GetModel(int OutKey)
        {
            return dal.GetModel(OutKey);
        }

        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }
        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }
        public DataSet GetAllList()
        {
            return this.GetList("");
        }
        public bool ExistsOutKey(string IDCardNo, int OutKey)
        {
            return this.dal.ExistsOutKey(IDCardNo, OutKey);
        }
    }
}
