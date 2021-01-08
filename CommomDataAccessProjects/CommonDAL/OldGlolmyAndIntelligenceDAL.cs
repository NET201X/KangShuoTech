using CommonUtilities.SQL;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class OldGlolmyAndIntelligenceDAL
    {
        /// <summary>
        /// 判断某表是否存在
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public bool ExistTable(string TableName, string conn = "")
        {
            StringBuilder bulider = new StringBuilder();

            bulider.Append(" SELECT COUNT(*) FROM sqlite_master WHERE TYPE = 'table' AND NAME = '");

            bulider.Append(TableName);
            bulider.Append("'");

            return YcSqliteHelper.Exists(bulider.ToString(), conn);
        }

        /// <summary>
        /// 获取抑郁评估表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet Getoldgloomy(string strWhere, string conn = "")
        {
            StringBuilder bulider = new StringBuilder();

            bulider.Append(" SELECT * FROM tbl_oldgloomy ");
            bulider.Append(" WHERE 1=1  ");

            if (!string.IsNullOrEmpty(strWhere)) bulider.Append(strWhere);

            bulider.Append("ORDER BY DATE(RecordDate)  ");

            return YcSqliteHelper.Query(bulider.ToString(), conn);
        }

        /// <summary>
        /// 获取智力评估表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetOldIntelligence(string strWhere, string conn = "")
        {
            StringBuilder bulider = new StringBuilder();

            bulider.Append(" SELECT * FROM tbl_oldintelligence ");
            bulider.Append(" WHERE 1=1  ");

            if (!string.IsNullOrEmpty(strWhere)) bulider.Append(strWhere);

            bulider.Append("ORDER BY DATE(RecordDate)  ");

            return YcSqliteHelper.Query(bulider.ToString(), conn);
        }
    }
}
