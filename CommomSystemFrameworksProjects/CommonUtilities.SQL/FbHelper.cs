using FirebirdSql.Data.FirebirdClient;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CommonUtilities.SQL
{
    public class FbHelper
    {
        public static string connectionString
        {
            get
            {
                if (File.Exists(Application.StartupPath + @"\PadPlatform.exe.config"))
                {
                    ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                    map.ExeConfigFilename = Application.StartupPath + @"\PadPlatform.exe.config";
                    Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                    string connectionString =
                    config.ConnectionStrings.ConnectionStrings["firebird"].ConnectionString.ToString();

                    return connectionString;
                }

                return "";
            }
        }

        //执行查询语句，返回dataset
        public static DataSet ExecuteQuery(string sql, FbParameter[] parameters, string conn)
        {
            if (string.IsNullOrEmpty(conn)) conn = connectionString;

            //Debug.WriteLine(sql);
            using (FbConnection connection = new FbConnection(conn))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();

                    FbDataAdapter da = new FbDataAdapter(sql, connection);
                    if (parameters != null) da.SelectCommand.Parameters.AddRange(parameters);
                    da.Fill(ds, "ds");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
        }

        //执行带参数的sql语句,返回影响的记录数（insert,update,delete)
        public static int ExecuteNonQuery(string sql, FbParameter[] parameters)
        {
            using (FbConnection connection = new FbConnection(connectionString))
            {
                FbCommand cmd = new FbCommand(sql, connection);
                try
                {
                    connection.Open();
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        
        public static object GetSingle(string sql, FbParameter[] parameters, string conn)
        {
            if (string.IsNullOrEmpty(conn)) conn = connectionString;

            using (FbConnection connection = new FbConnection(conn))
            {
                FbCommand cmd = new FbCommand(sql, connection);
                try
                {
                    connection.Open();
                    if (parameters != null) cmd.Parameters.AddRange(parameters);

                    object rows = cmd.ExecuteScalar();

                    if (object.Equals(rows, null) || object.Equals(rows, DBNull.Value))
                    {
                        return null;
                    }

                    return rows;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
