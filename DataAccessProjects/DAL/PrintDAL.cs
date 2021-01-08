using System.Data;
using System.Text;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;
using MySql.Data.MySqlClient;

namespace KangShuoTech.DataAccessProjects.DAL
{
    public class PrintDAL
    {
        /// <summary>
        /// 取得资料
        /// </summary>
        public DataSet GetData(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"SELECT * FROM tbl_print ");
            builder.Append(" WHERE 1=1 ");

            if (strWhere.Length > 0) builder.AppendFormat(" {0} ", strWhere);

            builder.Append(" ORDER BY Orders ");

            return MySQLHelper.Query(builder.ToString(), null);
        }

        public bool Update(PrintModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"
                                    UPDATE tbl_print 
                                     SET
                                        ButtonName = @ButtonName
                                        ,Orders = @Orders
                                        ,StyleName = @StyleName
                                        ,IsDisplay = @IsDisplay
                                        ,IsPrint = @IsPrint
                                        ,Col2 = @Col2
                                        ,Col3 = @Col3
                                      WHERE ID = @ID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@ButtonName", model.ButtonName),
                new MySqlParameter("@Orders", model.Orders),
                new MySqlParameter("@StyleName", model.StyleName),
                new MySqlParameter("@IsDisplay", model.IsDisplay),
                new MySqlParameter("@IsPrint", model.IsPrint),
                new MySqlParameter("@Col2", model.Col2),
                new MySqlParameter("@Col3", model.Col3),
                new MySqlParameter("@ID", model.ID)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
