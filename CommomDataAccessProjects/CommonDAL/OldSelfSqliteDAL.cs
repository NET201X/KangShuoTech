using CommonUtilities.SQL;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class OldSelfSqliteDAL
    {
        public DataSet GetMaxList(string strWhere, string conn = "")
        {
            StringBuilder builder = new StringBuilder();

            string table = "SELECT COUNT(0) FROM sqlite_master WHERE TYPE='table' AND NAME = 'tbl_olderselfcareability' ";

            object single = YcSqliteHelper.GetSingle(table, conn);
            int count = 0;

            if (single != null) count = int.Parse(single.ToString());

            if (count == 0) return null;

            builder.Append("SELECT * FROM tbl_olderselfcareability Medicinecn ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY IDCardNo,date(RecordDate) ");

            return YcSqliteHelper.Query(builder.ToString(), conn);
        }
    }
}
