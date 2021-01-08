using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;
using System.Data;
using System.Threading;
using System.Configuration;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Dynamic;

namespace CommonUtilities.SQL
{
    public static class YcSqliteHelper
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
                    string connectionString = config.ConnectionStrings.ConnectionStrings["BPsqlite"].ConnectionString.ToString();

                    return connectionString;
                }

                return "";
            }
        }

        private static void PrepareCommand(SQLiteConnection conn, SQLiteTransaction trans, SQLiteCommand cmd, CommandType cmdType, string cmdText, List<SQLiteParameter> cmdParms)
        {
            //List<SQLiteParameter> cmdParms = new List<SQLiteParameter>();
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SQLiteParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        #region ExecuteSql

        public static int ExecuteSql(string strSql, List<SQLiteParameter> cmdParms)
        {
            int num;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand();

                try
                {
                    PrepareCommand(connection, null, command, CommandType.Text, strSql, cmdParms);
                    num = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                catch (SQLiteException exception)
                {
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }

            return num;
        }

        public static int ExecuteSql(string strSql)
        {
            int num;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(strSql, connection);

                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (SQLiteException exception)
                {
                    connection.Close();
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }

            return num;
        }

        public static int ExecuteSql(string SQLString, string content)
        {
            int num;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(SQLString, connection);
                SQLiteParameter parameter = new SQLiteParameter("@content", DbType.String)
                {
                    Value = content
                };

                command.Parameters.Add(parameter);

                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (SQLiteException exception)
                {
                    throw new Exception(exception.Message);
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
            return num;
        }

        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            int num;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(strSQL, connection);
                SQLiteParameter parameter = new SQLiteParameter("@fs", DbType.Binary)
                {
                    Value = fs
                };
                command.Parameters.Add(parameter);
                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (SQLiteException exception)
                {
                    throw new Exception(exception.Message);
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }

            return num;
        }

        //连接地址可变
        public static int ExecuteSqlConnect(string strSql, string conn = "")
        {
            int num;
            if (conn == "") conn = connectionString;

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                SQLiteCommand command = new SQLiteCommand(strSql, connection);

                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (SQLiteException exception)
                {
                    connection.Close();
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }

            return num;
        }

        #endregion

        #region Exist

        public static bool Exists(string strSql, string conn = "")
        {
            object single = GetSingle(strSql, conn);
            return (((object.Equals(single, null) || object.Equals(single, DBNull.Value)) ? 0 : int.Parse(single.ToString())) != 0);
        }

        public static DataTable GetDataTable(string sql)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    new SQLiteDataAdapter(sql, connection).Fill(dataTable);
                }
                catch (SQLiteException exception)
                {
                    throw new Exception(exception.Message);
                }
                return dataTable;
            }
        }

        public static string GetString(string strSql)
        {
            string str;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(strSql))
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = strSql;
                        object obj2 = command.ExecuteScalar();
                        str = (obj2 == null) ? "" : obj2.ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public static DataSet Query(string strSql, string conn = "")
        {
            if (conn == "") conn = connectionString;

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                DataSet dataSet = new DataSet();

                try
                {
                    connection.DefaultTimeout = 3;

                    connection.Open();
                    new SQLiteDataAdapter(strSql, connection).Fill(dataSet, "ds");
                }
                catch (SQLiteException exception)
                {
                    throw exception;
                }
                return dataSet;
            }
        }

        public static DataSet Query(string strSql, List<SQLiteParameter> cmdParms, string conn = "")
        {
            if (conn == "") conn = connectionString;

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                DataSet dataSet = new DataSet();
                SQLiteCommand command = new SQLiteCommand(strSql, connection);

                try
                {
                    PrepareCommand(connection, null, command, CommandType.Text, strSql, cmdParms);
                    connection.DefaultTimeout = 300;

                    new SQLiteDataAdapter(command).Fill(dataSet, "ds");
                }
                catch (SQLiteException exception)
                {
                    throw exception;
                }
                return dataSet;
            }
        }

        #endregion

        public static object GetSingle(string strSql, string conn = "")
        {
            object obj3;
            if (conn == "") conn = connectionString;

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                SQLiteCommand command = new SQLiteCommand(strSql, connection);
                try
                {
                    connection.Open();
                    object objA = command.ExecuteScalar();
                    if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                    {
                        return null;
                    }
                    obj3 = objA;
                }
                catch (SQLiteException exception)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    return null;
                    //throw new Exception(exception.Message);
                }

                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }

            return obj3;
        }

        public static object GetSingle(string strSql, List<SQLiteParameter> cmdParms, string conn = "")
        {
            object obj3;

            if (conn == "") conn = connectionString;

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                SQLiteCommand command = new SQLiteCommand(strSql, connection);

                try
                {
                    PrepareCommand(connection, null, command, CommandType.Text, strSql, cmdParms);
                    object objA = command.ExecuteScalar();

                    if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                    {
                        return null;
                    }

                    obj3 = objA;
                }
                catch (SQLiteException exception)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }

            return obj3;
        }
    }
}
