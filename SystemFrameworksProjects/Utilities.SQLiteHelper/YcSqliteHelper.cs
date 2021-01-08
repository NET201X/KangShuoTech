using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;
using System.Data;
using System.Threading;
using KangShuoTech.Utilities.Common;
using System.Configuration;
using System.Data.OleDb;

namespace KangShuoTech.Utilities.SQLiteHelper
{
    public static class YcSqliteHelper
    {
        //public static string connectstr { get; set; } //app.config文件中连接的远程地址
        //private static string connectionString = System.Configuration.ConfigurationSettings.AppSettings["sqlite"];
        private static string connectionString = ConfigurationManager.ConnectionStrings["BPsqlite"].ToString();
        //执行单条插入语句，并返回id，不需要返回id的用ExceuteNonQuery执行。
        public static int ExecuteInsert(string sql, SQLiteParameter[] parameters)
        {
            //Debug.WriteLine(sql);
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                try
                {
                    connection.Open();
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"select @@identity";
                    int value = Int32.Parse(cmd.ExecuteScalar().ToString());
                    return value;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public static int ExecuteInsert(string sql)
        {
            return ExecuteInsert(sql, null);
        }

        //执行带参数的sql语句,返回影响的记录数（insert,update,delete)
        public static int ExecuteNonQuery(string sql, SQLiteParameter[] parameters)
        {
            //Debug.WriteLine(sql);
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
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
        //执行不带参数的sql语句，返回影响的记录数
        //不建议使用拼出来SQL
        public static int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, null);
        }

        //执行单条语句返回第一行第一列,可以用来返回count(*)
        public static int ExecuteScalar(string sql, SQLiteParameter[] parameters)
        {
            //Debug.WriteLine(sql);
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                try
                {
                    connection.Open();
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    int value = Int32.Parse(cmd.ExecuteScalar().ToString());
                    return value;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public static int ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, null);
        }

        //执行事务
        public static void ExecuteTrans(List<string> sqlList, List<OleDbParameter[]> paraList)
        {
            //Debug.WriteLine(sql);
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                OleDbTransaction transaction = null;
                cmd.Connection = connection;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    cmd.Transaction = transaction;

                    for (int i = 0; i < sqlList.Count; i++)
                    {
                        cmd.CommandText = sqlList[i];
                        if (paraList != null && paraList[i] != null)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddRange(paraList[i]);
                        }
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();

                }
                catch (Exception e)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    throw e;
                }

            }
        }
        public static void ExecuteTrans(List<string> sqlList)
        {
            ExecuteTrans(sqlList, null);
        }

        //执行查询语句，返回dataset
        public static DataSet ExecuteQuery(string sql, SQLiteParameter[] parameters)
        {
            //Debug.WriteLine(sql);
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();

                    SQLiteDataAdapter da = new SQLiteDataAdapter(sql, connection);
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
        public static DataSet ExecuteQuery(string sql)
        {
            return ExecuteQuery(sql, null);
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

        public static bool Exists(string strSql)
        {
            object single = GetSingle(strSql);
            return (((object.Equals(single, null) || object.Equals(single, DBNull.Value)) ? 0 : int.Parse(single.ToString())) != 0);
        }

        public static bool Exists(string strSql, List<SQLiteParameter> cmdParms)
        {
            object single = GetSingle(strSql, cmdParms);
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
     
        public static int GetInt(string sql)
        {
            string s = GetString(sql);
            if (s == "")
            {
                s = "0";
            }
            return int.Parse(s);
        }

        public static List<string> GetList(string sql)
        {
            DataTable datatable = GetDataTable(sql);
            List<string> list = new List<string>();
            foreach (DataRow row in datatable.Rows)
            {
                list.Add(row[0].ToString());
            }
            return list;
        }

        public static int GetMaxID(string FieldName, string TableName)
        {
            object single = GetSingle("select max(" + FieldName + ")+1 from " + TableName);
            if (single == null)
            {
                return 1;
            }
            return int.Parse(single.ToString());
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

        public static DataSet Query(string strSql, List<SQLiteParameter> cmdParms)
        {
            DataSet set2;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand();
                PrepareCommand(connection, null, cmd, CommandType.Text, strSql, cmdParms);
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataSet dataSet = new DataSet();
                    try
                    {
                        adapter.Fill(dataSet, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (SQLiteException exception)
                    {
                        throw new Exception(exception.Message);
                    }
                    set2 = dataSet;
                }
            }
            return set2;
        }
        #endregion

        public static bool ISconnectOpen()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SQLiteException exception)
                {
                    return false;
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }
            return false ;
        }

        public static object GetSingle(string strSql, string conn = "")
        {
            object obj3;
            if (conn == "") conn = connectionString;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
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

        public static object GetSingle(string strSql, List<SQLiteParameter> cmdParms)
        {
            object obj3;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand();
                try
                {
                    PrepareCommand(connection, null, cmd, CommandType.Text, strSql, cmdParms);
                    object objA = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                    {
                        return null;
                    }
                    obj3 = objA;
                }
                catch (SQLiteException exception)
                {
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
            return obj3;
        }

        //执行查询语句返回datareader，使用后要注意close
        //这个函数在AccessPageUtils中使用，执行其它查询时最好不要用
        public static OleDbDataReader ExecuteReader(string sql)
        {
            //Debug.WriteLine(sql);
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            try
            {
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }
        }
    }
}
