using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class RecordsSelfcareabilityBLL
    {
        private readonly RecordsSelfcareabilityDAL dal = new RecordsSelfcareabilityDAL();

        public int Add(RecordsSelfcareabilityModel model)
        {
            return this.dal.Add(model);
        }

        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }
        
        public RecordsSelfcareabilityModel GetModelID(int ID)
        {
            DataSet ds = this.dal.GetModelID(ID);
            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsSelfcareabilityModel> list = ModelConvertHelper<RecordsSelfcareabilityModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list[0];

            }
            return null;
        }

        public bool Update(RecordsSelfcareabilityModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateByMiniPad(RecordsSelfcareabilityModel model, string RecordDate, string oldSelf)
        {
            return this.dal.UpdateByMiniPad(model, RecordDate, oldSelf);
        }
        
        public bool UpdateGeneral(string IDCardNo, string RecordDate, int ID, string oldSelf)
        {
            return this.dal.UpdateGeneral(IDCardNo, RecordDate, ID, oldSelf);
        }
    }
}
