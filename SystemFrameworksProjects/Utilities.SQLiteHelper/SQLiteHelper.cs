using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;
using System.Data;
using System.Threading;
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.Utilities.SQLiteHelper
{
    /// <summary>
    /// SQLiteHelper Kevin 2013-09-03
    /// </summary>
    public static class SQLiteHelper
    {
        public static SQLiteConnectionStringBuilder sqlconn_sb = new SQLiteConnectionStringBuilder();

        public static void AddPassword(string pwd)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + sqlconn_sb.DataSource))
            {
                connection.Open();
                connection.ChangePassword(pwd);
            }
        }

        public static void CheckPassword(string pwd)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                }
                if (connection.State != ConnectionState.Open)
                {
                    AddPassword(pwd);
                }
            }
        }

        public static void CreateDB(string file)
        {
            string connectionString = SQLiteHelper.connectionString;
            string dataSource = sqlconn_sb.DataSource;
            string path = dataSource.Substring(0, dataSource.LastIndexOf(@"\"));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (SQLiteConnection connection = new SQLiteConnection(SQLiteHelper.connectionString))
            {
                connection.Open();
                connection.ChangePassword(sqlconn_sb.Password);
            }
        }

        public static bool CreateDB(string file, string pwd = null)
        {
            SQLiteConnection.CreateFile(file);
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = new SQLiteConnectionStringBuilder { DataSource = file, Password = pwd }.ToString();
                connection.Open();
            }
            return true;
        }

        public static SQLiteDataReader ExecuteReader(string strSQL)
        {
            SQLiteDataReader reader;
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            SQLiteCommand command = new SQLiteCommand(strSQL, connection);
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (SQLiteException exception)
            {
                throw new Exception(exception.Message);
            }
            return reader;
        }

        public static SQLiteDataReader ExecuteReader(string SQLString, params SQLiteParameter[] cmdParms)
        {
            SQLiteDataReader reader2;
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                PrepareCommand(cmd, conn, null, SQLString, cmdParms);
                SQLiteDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                reader2 = reader;
            }
            catch (SQLiteException exception)
            {
                throw new Exception(exception.Message);
            }
            return reader2;
        }

        public static int ExecuteSql(string SQLString)
        {
            int num;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(SQLString, connection);
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

        public static int ExecuteSql(string SQLString, params SQLiteParameter[] cmdParms)
        {
            int num2;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand();
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    int num = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    num2 = num;
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
            return num2;
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

        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand
                {
                    Connection = connection
                };
                SQLiteTransaction transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                try
                {
                    for (int i = 0; i < SQLStringList.Count; i++)
                    {
                        string str = SQLStringList[i].ToString();
                        if (str.Trim().Length > 1)
                        {
                            command.CommandText = str;
                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
                catch (SQLiteException exception)
                {
                    transaction.Rollback();
                    throw new Exception(exception.Message);
                }
            }
        }

        public static void ExecuteSqlTran(List<string> SQLStringList)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand
                {
                    Connection = connection
                };
                SQLiteTransaction transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                try
                {
                    for (int i = 0; i < SQLStringList.Count; i++)
                    {
                        string str = SQLStringList[i];
                        if (str.Trim().Length > 1)
                        {
                            command.CommandText = str;
                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
                catch (SQLiteException exception)
                {
                    transaction.Rollback();
                    throw new Exception(exception.Message);
                }
            }
        }

        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    SQLiteCommand cmd = new SQLiteCommand();
                    try
                    {
                        foreach (DictionaryEntry entry in SQLStringList)
                        {
                            string cmdText = entry.Key.ToString();
                            SQLiteParameter[] cmdParms = (SQLiteParameter[])entry.Value;
                            PrepareCommand(cmd, connection, transaction, cmdText, cmdParms);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            transaction.Commit();
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static void ExecuteSqlTran(ArrayList SQLStringList, int cnt_tran)
        {
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < SQLStringList.Count; i++)
            {
                if ((i != 0) && ((i % cnt_tran) == 0))
                {
                    ArrayList range = SQLStringList.GetRange(num * cnt_tran, cnt_tran);
                    num++;
                    num2 += range.Count;
                    ExecuteSqlTran(range);
                    Thread.Sleep(50);
                }
            }
            ExecuteSqlTran(SQLStringList.GetRange(num * cnt_tran, SQLStringList.Count - num2));
            Thread.Sleep(50);
        }

        public static bool Exists(string strSql)
        {
            object single = GetSingle(strSql);
            return (((object.Equals(single, null) || object.Equals(single, DBNull.Value)) ? 0 : int.Parse(single.ToString())) != 0);
        }

        public static bool Exists(string strSql, params SQLiteParameter[] cmdParms)
        {
            object single = GetSingle(strSql, cmdParms);
            return (((object.Equals(single, null) || object.Equals(single, DBNull.Value)) ? 0 : int.Parse(single.ToString())) != 0);
        }

        public static DataTable GetDatatable(string sql)
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
            DataTable datatable = GetDatatable(sql);
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

        public static object GetSingle(string SQLString)
        {
            object obj3;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(SQLString, connection);
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
            return obj3;
        }

        public static object GetSingle(string SQLString, params SQLiteParameter[] cmdParms)
        {
            object obj3;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand();
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
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

        public static string GetString(string sql)
        {
            string str;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = sql;
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

        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, string cmdText, SQLiteParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (SQLiteParameter parameter in cmdParms)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        public static DataSet Query(string SQLString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new SQLiteDataAdapter(SQLString, connection).Fill(dataSet, "ds");
                }
                catch (SQLiteException exception)
                {
                    throw new Exception(exception.Message);
                }
                return dataSet;
            }
        }

        public static DataSet Query(string SQLString, params SQLiteParameter[] cmdParms)
        {
            DataSet set2;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
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

        public static void ResetPassword(string pwd)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                connection.ChangePassword(pwd);
            }
        }

        public static string connectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(sqlconn_sb.ConnectionString))
                {
                    string pValue = "";
                    if (!ConfigHelper.GetNode("anyview", ref pValue))
                    {
                        ConfigHelper.WriteNode("anyview", @"\Data\QCDB.db");
                        pValue = @"\Data\QCDB.db";
                    }

                    string str2 = "";
                    if (!ConfigHelper.GetNode("poe", ref str2))
                    {
                        ConfigHelper.WriteNode("poe", "ksxyh");
                        str2 = "ksxyh";
                    }

                    sqlconn_sb.DataSource = pValue;
                    sqlconn_sb.Password = str2;
                }

                return sqlconn_sb.ConnectionString;
            }
        }
    }
}
