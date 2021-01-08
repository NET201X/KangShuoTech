using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using System.Data;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class HealthHouseBCHAOBLL
    {
        private readonly HealthHouseBCHAODAL dal = new HealthHouseBCHAODAL();

        public int Add(HealthHouseBCHAOModel model)
        {
            return this.dal.Add(model);
        }

        public HealthHouseBCHAOModel GetModel(int PID)
        {
            DataSet ds = this.dal.GetModel(PID);

            if (ds.Tables[0].Rows.Count > 0)
            {
                // 将DataTable转为List
                IList<HealthHouseBCHAOModel> list = CommonExtensions.DataTableToList<HealthHouseBCHAOModel>(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public bool ExistsPID(string IDCardNo, int PID)
        {
            return this.dal.ExistsPID(IDCardNo,PID);
        }

        public bool Update(HealthHouseBCHAOModel model)
        {
            return this.dal.Update(model);
        }
    }
}
