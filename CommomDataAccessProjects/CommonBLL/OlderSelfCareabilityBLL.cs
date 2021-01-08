using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommomUtilities.Common;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class OlderSelfCareabilityBLL
    {
        private readonly OlderSelfCareabilityDAL dal = new OlderSelfCareabilityDAL();

        public int Add(OlderSelfCareabilityModel model, string Version = "V2.0")
        {
            return this.dal.Add(model, Version);
        }

        /// <summary>
        /// 数据同步自理能力存档
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateByUpload(OlderSelfCareabilityModel model)
        {
            return this.dal.UpdateByUpload(model);
        }

        public OlderSelfCareabilityModel CheckModel(string strWhere)
        {
            DataSet ds = this.dal.CheckModel(strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<OlderSelfCareabilityModel> list = ModelConvertHelper<OlderSelfCareabilityModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public OlderSelfCareabilityModel GetMaxModel(string IDCardNo, string CheckDate, string Version = "V2.0")
        {
            DataSet ds = this.dal.GetMaxModel(IDCardNo, CheckDate, Version);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<OlderSelfCareabilityModel> list = ModelConvertHelper<OlderSelfCareabilityModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// 本季度是否有随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetDataCount(string IDCardNo, string Version = "V2.0")
        {
            return this.dal.GetDataCount(IDCardNo, Version);
        }
    }
}
