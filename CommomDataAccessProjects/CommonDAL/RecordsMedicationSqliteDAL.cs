using CommonUtilities.SQL;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsMedicationSqliteDAL
    {
        /// <summary>
        /// 获取体检问询用药资料内容
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere, string conn = "")
        {
            StringBuilder builder = new StringBuilder();

            // 体检问询用药
            builder.Append(@"SELECT * FROM tbl_recordsmedication WHERE EXISTS 
                                (
                                    SELECT ID FROM tbl_recordscustomerinfo
                                    WHERE ID = OutKey ");

            if (strWhere.Trim() != "")
            {
                builder.Append(strWhere);
            }

            builder.Append(" GROUP BY IDCardNo,DATE(RecordDate)");
            builder.Append(")");

            return YcSqliteHelper.Query(builder.ToString(), conn);
        }
    }
}
