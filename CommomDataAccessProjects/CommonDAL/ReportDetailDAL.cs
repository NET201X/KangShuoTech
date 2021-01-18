using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommonUtilities.SQL;
using System;
using System.Text;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class ReportDetailDAL
    {
        /// <summary>
        /// 按照文件名删除报表明细
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        public bool DeleteReportDetail(string reportName)
        {
            string sql = $"DELETE FROM ARCHIVE_REPORT_DETAIL WHERE ReportName='{reportName}'";
            return MySQLHelper.ExecuteSql(sql) > 0 ? true : false;
        }        

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public bool AddReportDetail(ReportDetailModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO ARCHIVE_REPORT_DETAIL(");
            strSql.Append("ReportID,ReportName,ExportType,ColumnName,ColumnValue,Seq,Col1,Col2,Col3)");
            strSql.Append(" VALUES (");
            strSql.Append("@ReportID,@ReportName,@ExportType,@ColumnName,@ColumnValue,@Seq,@Col1,@Col2,@Col3)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ReportID", MySqlDbType.Int32,11),
                    new MySqlParameter("@ReportName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ExportType", MySqlDbType.VarChar,1),
                    new MySqlParameter("@ColumnName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ColumnValue", MySqlDbType.VarChar,500),
                    new MySqlParameter("@Seq", MySqlDbType.Int32,11),
                    new MySqlParameter("@Col1", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Col2", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Col3", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.ReportID;
            parameters[1].Value = model.ReportName;
            parameters[2].Value = model.ExportType;
            parameters[3].Value = model.ColumnName;
            parameters[4].Value = model.ColumnValue;
            parameters[5].Value = model.Seq;
            parameters[6].Value = model.Col1;
            parameters[7].Value = model.Col2;
            parameters[8].Value = model.Col3;

            return MySQLHelper.ExecuteSql(strSql.ToString(), parameters) > 0 ? true : false;
        }


        /// <summary>
        /// 获取所有报表名称
        /// </summary>
        /// <returns></returns>
        public DataSet GetReportName()
        {
            string sql = "SELECT distinct ReportName FROM ARCHIVE_REPORT_DETAIL";
            return MySQLHelper.Query(sql);
        }

        /// <summary>
        /// 根据报表名称获取报表详细信息
        /// </summary>
        /// <param name="ReportName"></param>
        /// <returns></returns>
        public DataSet GetModelList(string ReportName)
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("SELECT * FROM ((SELECT a.ID TblReportID,a.TableName,a.AnotherName,a.OptionName,a.ChinaName,");
            //sb.Append("b.ID,b.ReportID,b.ReportName,b.ExportType,b.ColumnName,b.ColumnValue,b.Seq,b.Col1,b.Col2,b.Col3");
            //sb.Append(" FROM ARCHIVE_REPORT a left join ARCHIVE_REPORT_DETAIL b on a.id =b.ReportID or b.ReportID is null WHERE b.ReportName=@ReportName or b.ReportName is null");
            //sb.Append(" ) union all (SELECT 0 TblReportID,'' TableName,'' AnotherName,'' OptionName,'' ChinaName,c.ID,-1 ReportID,c.ReportName,c.ExportType,c.ColumnName,c.ColumnValue,c.Seq,c.Col1,c.Col2,c.Col3 FROM ARCHIVE_REPORT_DETAIL c WHERE ReportName =@ReportName AND ReportID is null)) f");
            //sb.Append(" order by ISNULL(Seq),seq asc,TblReportID asc");

            sb.Append("SELECT * FROM (SELECT a.ID TblReportID,a.TableName,a.AnotherName,a.OptionName,a.ChinaName,b.ID,b.ReportID,b.ReportName,b.ExportType,b.ColumnName,b.ColumnValue,b.Seq,b.Col1,b.Col2,b.Col3 FROM ARCHIVE_REPORT a RIGHT JOIN ARCHIVE_REPORT_DETAIL b ON a.ID = b.ReportID WHERE b.ReportName = @ReportName ");
            sb.Append("union ");
            sb.Append("SELECT ID TblReportID,TableName,AnotherName,OptionName,ChinaName, null ID,null ReportID,null ReportName,null ExportType,null ColumnName,null ColumnValue,null Seq,null Col1,null Col2,null Col3 FROM ARCHIVE_REPORT WHERE id not in (SELECT a.ID FROM ARCHIVE_REPORT a LEFT JOIN ARCHIVE_REPORT_DETAIL b ON a.ID = b.ReportID WHERE b.ReportName = @ReportName)) t");
            sb.Append(" order by ISNULL(Seq),seq asc,TblReportID asc");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@ReportName", MySqlDbType.String)
            };

            cmdParms[0].Value = ReportName;

            return MySQLHelper.Query(sb.ToString(), cmdParms);
        }
    }
}
