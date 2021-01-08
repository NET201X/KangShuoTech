using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using System.Data;
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class OldMedGuideBLL 
    {
        OldMedGuideDAL dal = new OldMedGuideDAL();

        public int Add(OldMedGuideModel model)
        {
            return this.dal.Add(model);
        }

        public bool Update(OldMedGuideModel model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateByUpload(OldMedGuideModel model)
        {
            return this.dal.UpdateByUpload(model);
        }

        public OldMedGuideModel ExistByWhere(string strWhere)
        {
            DataSet ds = this.dal.ExistByWhere(strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<OldMedGuideModel> list = ModelConvertHelper<OldMedGuideModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return new OldMedGuideModel();
        }
    }
}
