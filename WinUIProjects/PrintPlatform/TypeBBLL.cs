using KangShuoTech.Utilities.MySQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PrintPlatform
{
    public class TypeBBLL
    {
        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"SELECT
                               Count(0)
                            FROM
                            (                       
                            SELECT
                            MAX(ID) as ID
                            FROM ARCHIVE_ULTRASONICB_RESULT
                            GROUP BY PTNIDNO  
                            ) TypeB
                            INNER JOIN
                            ARCHIVE_ULTRASONICB_RESULT E 
                            ON TypeB.ID = E.ID
                            inner join ARCHIVE_BASEINFO T  on T.IDCardNo = E.PTNIDNO 
                            left join ARCHIVE_CUSTOMERBASEINFO B on T.IDCardNo = B.IDCardNo ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"SELECT
                                E.PTNIDNO as IDCardNo,T.CustomerName,T.Sex,T.Nation,T.Birthday,T.Phone,T.HouseHoldAddress
                                ,E.DIAG as Conclusion
                                ,CONCAT(left(E.DIAGTM,10),'_',E.PTNIDNO) as    MID
                                ,T.Minority
                            FROM
                            (                       
                            SELECT
                              PTNIDNO
                              , MAX(DIAGTM) AS DIAGTM
                            FROM ARCHIVE_ULTRASONICB_RESULT
                            WHERE PTNIDNO <> ''
                            GROUP BY PTNIDNO
                            ) TypeB
                            INNER JOIN
                            ARCHIVE_ULTRASONICB_RESULT E 
                            ON TypeB.PTNIDNO = E.PTNIDNO
                            AND TypeB.DIAGTM = E.DIAGTM
                            inner join ARCHIVE_BASEINFO T  on T.IDCardNo = E.PTNIDNO 
                            left join ARCHIVE_CUSTOMERBASEINFO B on T.IDCardNo = B.IDCardNo  ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            //builder.Append(" GROUP BY E.IDCardNo");

            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }

            builder.Append(string.Format(" limit {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }
    }
}
