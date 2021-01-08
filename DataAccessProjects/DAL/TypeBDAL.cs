namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class TypeBDAL
    {
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"SELECT
                               *
                            FROM
                            (                       
                            SELECT
                            MAX(ID) as ID
                            FROM tbl_ptntbl
                            GROUP BY PTNIDNO  
                            ) TypeB
                            INNER JOIN
                            tbl_ptntbl E 
                            ON TypeB.ID = E.ID
                            inner join tbl_recordsbaseinfo T  on T.IDCardNo = E.PTNIDNO 
                            left join tbl_recordscustomerbaseinfo B on T.IDCardNo = B.IDCardNo ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetModel(string strWhere)
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
                            FROM tbl_ptntbl
                            WHERE PTNIDNO <> ''
                            GROUP BY PTNIDNO
                            ) TypeB
                            INNER JOIN
                            tbl_ptntbl E 
                            ON TypeB.PTNIDNO = E.PTNIDNO
                            AND TypeB.DIAGTM = E.DIAGTM
                            inner join tbl_recordsbaseinfo T  on T.IDCardNo = E.PTNIDNO 
                            left join tbl_recordscustomerbaseinfo B on T.IDCardNo = B.IDCardNo  ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" where " + strWhere);
            }

            //builder.Append(" GROUP BY E.IDCardNo");

            return MySQLHelper.Query(builder.ToString());
        }
        public DataSet GetByWhere(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" SELECT PTNIDNO, CLNCDIAG,DIAG, CONCAT(left(DIAGTM,10),'_',PTNIDNO) as    MID from tbl_ptntbl");
            builder.Append(" where PTNIDNO!='' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }
    }
}
