namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonDAL;
    using CommonModel;
    using System.Collections.Generic;
    using System.Data;

    public class SysOrgTownBLL
    {
        private readonly SysOrgTownDAL dal = new SysOrgTownDAL();
        
        public SysOrgTownModel GetModel(string code)
        {
            DataSet ds = this.dal.GetModel(code);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<SysOrgTownModel> list = ModelConvertHelper<SysOrgTownModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list[0];
            }

            return new SysOrgTownModel();
        }        
    }
}

