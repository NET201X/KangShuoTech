using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class PrintALLDAL
    {
        public int Add(PrintALLModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" INSERT INTO tbl_printall(");
            builder.Append("PrintID,FileButtonName,IsDouble,PrintOrders,Col2,Col3)");
            builder.Append(" VALUES (");
            builder.Append("@PrintID,@FileButtonName,@IsDouble,@PrintOrders,@Col2,@Col3)");
            builder.Append(";SELECT @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                            new MySqlParameter("@PrintID",MySqlDbType.Int32),
                            new MySqlParameter("@FileButtonName",MySqlDbType.String),
                            new MySqlParameter("@IsDouble",MySqlDbType.String),
                            new MySqlParameter("@PrintOrders",MySqlDbType.Int32),
                            new MySqlParameter("@Col2",MySqlDbType.String),
                            new MySqlParameter("@Col3",MySqlDbType.String)
                            };
            cmdParms[0].Value = model.PrintID;
            cmdParms[1].Value = model.FileButtonName;
            cmdParms[2].Value = model.IsDouble;
            cmdParms[3].Value = model.PrintOrders;
            cmdParms[4].Value = model.Col2;
            cmdParms[5].Value = model.Col3;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public bool Update(PrintALLModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" UPDATE tbl_printall SET ");
            builder.Append("PrintID=@PrintID,");
            builder.Append("FileButtonName=@FileButtonName,");
            builder.Append("IsDouble=@IsDouble,");
            builder.Append("PrintOrders=@PrintOrders,");
            builder.Append("Col2=@Col2,");
            builder.Append("Col3=@Col3");
            builder.Append(" WHERE ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                            new MySqlParameter("@PrintID",MySqlDbType.Int32),
                            new MySqlParameter("@FileButtonName",MySqlDbType.String),
                            new MySqlParameter("@IsDouble",MySqlDbType.String),
                            new MySqlParameter("@PrintOrders",MySqlDbType.Int32),
                            new MySqlParameter("@Col2",MySqlDbType.String),
                            new MySqlParameter("@Col3",MySqlDbType.String),
                            new MySqlParameter("ID",MySqlDbType.Int32)
                            };
            cmdParms[0].Value = model.PrintID;
            cmdParms[1].Value = model.FileButtonName;
            cmdParms[2].Value = model.IsDouble;
            cmdParms[3].Value = model.PrintOrders;
            cmdParms[4].Value = model.Col2;
            cmdParms[5].Value = model.Col3;
            cmdParms[6].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("DELETE FROM tbl_printall ");
            builder.Append(" WHERE ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

    }
}
