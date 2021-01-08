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
    public class HealthHouseEcgBLL
    {
        private readonly HealthHouseEcgDAL dal = new HealthHouseEcgDAL();

        public int Add(HealthHouseEcgModel model)
        {
            return this.dal.Add(model);
        }

        public HealthHouseEcgModel GetModel(int PID)
        {
            DataSet ds = this.dal.GetModel(PID);

            if (ds != null)
            {
                // 将DataTable转为List
                IList<HealthHouseEcgModel> list = CommonExtensions.DataTableToList<HealthHouseEcgModel>(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public bool ExistsPID(string IDCardNo, int PID)
        {
            return this.dal.ExistsPID(IDCardNo,PID);
        }

        public bool Update(HealthHouseEcgModel model)
        {
            return this.dal.Update(model);
        }
    }
}
