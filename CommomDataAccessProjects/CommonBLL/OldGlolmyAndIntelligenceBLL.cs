
using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class OldGlolmyAndIntelligenceBLL
    {
        private readonly OldGlolmyAndIntelligenceDAL dal = new OldGlolmyAndIntelligenceDAL();

        /// <summary>
        /// 判断某表是否存在
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public bool ExistTable(string TableName, string conn = "")
        {
            return this.dal.ExistTable(TableName,conn);
        }

        public List<OldGloomyModel> Getoldgloomy(string strWhere, string conn = "")
        {
            DataSet ds= this.dal.Getoldgloomy(strWhere, conn);
            if (ds == null) return null;
            return CommonExtensions.ToList<OldGloomyModel>(ds.Tables[0]);
        }

        /// <summary>
        /// 获取智力评估表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public List<OldIntelligenceModel> GetOldIntelligence(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetOldIntelligence(strWhere, conn);
            if (ds == null) return null;
            return CommonExtensions.ToList<OldIntelligenceModel>(ds.Tables[0]);
        }
    }
}
