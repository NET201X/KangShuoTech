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
    public class HealthHousePhysicalAssistCheckBLL
    {
        public readonly HealthHousePhysicalAssistCheckDAL dal = new HealthHousePhysicalAssistCheckDAL();

        public int Add(HealthHousePhysicalAssistCheckModel model)
        {
            return this.dal.Add(model);
        }

        public HealthHousePhysicalAssistCheckModel GetModel(int OutKey)
        {
            DataSet ds = this.dal.GetModel(OutKey);

            if (ds != null)
            {
                // 将DataTable转为List
                IList<HealthHousePhysicalAssistCheckModel> list = CommonExtensions.DataTableToList<HealthHousePhysicalAssistCheckModel>(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public bool Update(HealthHousePhysicalAssistCheckModel model)
        {
            return this.dal.Update(model);
        }

        public bool ExistsPID(string IDCardNo, int PID)
        {
            return this.dal.ExistsPID(IDCardNo, PID);
        }
    }
}
