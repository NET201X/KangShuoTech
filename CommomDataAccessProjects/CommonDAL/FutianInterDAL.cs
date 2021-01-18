using CommonUtilities.SQL;
using System;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class FutFutianInterDAL
    {
        public DataSet GetData(string TJBH, string TJCS)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" SELECT A.TJXM,A.JG FROM view_tj_tjjlmxb_jk A INNER JOIN view_tj_tjjlb_jk B  ");
            builder.Append(" ON A.XH=B.XH ");
            builder.Append(" WHERE B.TJBH="+ TJBH );
            builder.Append(" AND B.TJCS=" + TJCS );

            return SQLServerHelper.Query(builder.ToString());
        }

        public DataSet GetTjdjb(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" SELECT MAX(TJCS)AS TJCS,SFZH,TJBH,XB ");
            builder.Append(" FROM view_tj_tjdjb_jk ");
            builder.Append(" WHERE SFZH IS NOT NULL AND SFZH!=''  ");

            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }

            builder.Append(" GROUP BY SFZH,TJBH,XB ");

            return SQLServerHelper.Query(builder.ToString());
        }

        public int Save(StringBuilder sql, string IDCardNo)
        {
            string upStr = sql.ToString().Substring(0, sql.ToString().Length - 1);

            upStr += " WHERE D.OutKey = (SELECT M.ID FROM ARCHIVE_CUSTOMERBASEINFO M ";
            upStr += " WHERE M.IDCardNo = '" + IDCardNo + "' AND Left(M.CheckDate,4)= " + DateTime.Now.Year.ToString();
            upStr += " ORDER BY M.CheckDate DESC LIMIT 0,1  );";

            return MySQLHelper.ExecuteSql(upStr);
        }
    }
}
