using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class PrintDAL
    {
        public int Add(PrintModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" INSERT INTO SYS_PRINT(");
            builder.Append("ButtonName,ButtonID,Orders,StyleName,IsDisplay,IsDouble,PrintFile,PrintType,FileName,Col2,Col3)");
            builder.Append(" VALUES (");
            builder.Append("@ButtonName,@ButtonID,@Orders,@StyleName,@IsDisplay,@IsDouble,@PrintFile,@PrintType,@FileName,@Col2,@Col3)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@ButtonName",MySqlDbType.String),
                new MySqlParameter("@ButtonID",MySqlDbType.String),
                new MySqlParameter("@Orders",MySqlDbType.Int32),
                new MySqlParameter("@StyleName",MySqlDbType.String),
                new MySqlParameter("@IsDisplay",MySqlDbType.String),
                new MySqlParameter("@IsDouble",MySqlDbType.String),
                new MySqlParameter("@PrintFile",MySqlDbType.String),
                new MySqlParameter("@PrintType",MySqlDbType.String),
                new MySqlParameter("@FileName",MySqlDbType.String),
                new MySqlParameter("@Col2",MySqlDbType.String),
                new MySqlParameter("@Col3",MySqlDbType.String)
             };

            cmdParms[0].Value = model.ButtonName;
            cmdParms[1].Value = model.ButtonID;
            cmdParms[2].Value = model.Orders;
            cmdParms[3].Value = model.StyleName;
            cmdParms[4].Value = model.IsDisplay;
            cmdParms[5].Value = model.IsDouble;
            cmdParms[6].Value = model.PrintFile;
            cmdParms[7].Value = model.PrintType;
            cmdParms[8].Value = model.FileName;
            cmdParms[9].Value = model.Col2;
            cmdParms[10].Value = model.Col3;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 取得资料
        /// </summary>
        public DataSet GetData(string strPrint, string strPrintAll)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT B.*,C.ID AS AID,C.PrintID,C.FileButtonName,C.IsDouble,C.PrintOrders,C.IsPrint ");
            builder.Append(" FROM SYS_PRINT B LEFT JOIN  ");
            builder.Append(" (SELECT *,'Y' AS IsPrint FROM SYS_PRINT_ALL WHERE 1=1 ");
            builder.Append(strPrintAll);
            builder.Append(" ) C");
            builder.Append(" ON B.ID=C.PrintID ");
            builder.Append(" WHERE 1=1 ");

            if (strPrint.Length > 0) builder.AppendFormat(" {0} ", strPrint);

            builder.Append(" ORDER BY IsDisplay DESC,Orders ");

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 获取一键打印类型
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllPrint()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" SELECT ButtonName FROM SYS_PRINT ");
            builder.Append(" WHERE ButtonID='btnPrintAll' AND IsDisplay='Y' ");
            builder.Append(" GROUP BY ButtonName ");

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Exist(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" SELECT COUNT(*) FROM SYS_PRINT WHERE 1=1 ");

            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }

            return MySQLHelper.Exists(builder.ToString());
        }

        public bool Update(PrintModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"
                                    UPDATE SYS_PRINT 
                                     SET
                                         Orders = @Orders
                                        ,IsDisplay = @IsDisplay
                                        ,ButtonName=@ButtonName
                                        ,FileName=@FileName
                                        ,Col2 = @Col2
                                        ,Col3 = @Col3
                                      WHERE ID = @ID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@Orders", model.Orders),
                new MySqlParameter("@IsDisplay", model.IsDisplay),
                new MySqlParameter("@ButtonName", model.ButtonName),
                new MySqlParameter("@FileName", model.FileName),
                new MySqlParameter("@Col2", model.Col2),
                new MySqlParameter("@Col3", model.Col3),
                new MySqlParameter("@ID", model.ID)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 获取最大按钮排列序号
        /// </summary>
        /// <returns></returns>
        public int GetMaxOrders()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" SELECT MAX(Orders) FROM SYS_PRINT ");

            return MySQLHelper.GetInt(builder.ToString());
        }

        /// <summary>
        /// 获取Print表中内容
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataSet GetPrintData(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT *  FROM SYS_PRINT  ");
            builder.Append(" WHERE 1=1 ");

            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }

            builder.Append(" ORDER BY Orders ");

            return MySQLHelper.Query(builder.ToString());
        }
    }
}
