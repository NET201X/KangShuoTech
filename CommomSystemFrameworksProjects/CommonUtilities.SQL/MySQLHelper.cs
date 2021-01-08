using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using MySql.Data.MySqlClient;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using CommomUtilities.Common;
using System.Security.Cryptography;

namespace CommonUtilities.SQL
{
    /// <summary>
    /// 基于MySQL的数据层基类
    /// </summary>
    public abstract class MySQLHelper
    {
        #region 数据库连接字符串

        public static string ConnectionString
        {
            get
            {
                string connectionString = "";
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = Application.StartupPath + @"\PadPlatform.exe.config";
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
               
                if (!File.Exists(map.ExeConfigFilename)) connectionString = DESDecrypt(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString(), "89779855", "45665422"); 
                else connectionString = DESDecrypt(config.ConnectionStrings.ConnectionStrings["DBConnectionString"].ConnectionString.ToString(), "89779855", "45665422");

                return connectionString;
            }
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="data">解密数据</param>
        /// <param name="key">8位字符的密钥字符串(需要和加密时相同)</param>
        /// <param name="iv">8位字符的初始化向量字符串(需要和加密时相同)</param>
        /// <returns></returns>
        public static string DESDecrypt(string data, string key, string iv)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }


        public static string ServerConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionString"].ToString();
            }
        }

        #endregion

        #region PrepareCommand

        /// <summary>
        /// Command预处理
        /// </summary>
        /// <param name="conn">MySqlConnection对象</param>
        /// <param name="trans">MySqlTransaction对象，可为null</param>
        /// <param name="cmd">MySqlCommand对象</param>
        /// <param name="cmdType">CommandType，存储过程或命令行</param>
        /// <param name="cmdText">SQL语句或存储过程名</param>
        /// <param name="cmdParms">MySqlCommand参数数组，可为null</param>
        private static void PrepareCommand(MySqlConnection conn, MySqlTransaction trans, MySqlCommand cmd, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (MySqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        #endregion

        #region ExecuteNonQuery

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">命令类型（存储过程或SQL语句）</param>
        /// <param name="cmdText">SQL语句或存储过程名</param>
        /// <param name="cmdParms">MySqlCommand参数数组</param>
        /// <returns>返回受引响的记录行数</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
        {
            MySqlCommand cmd = new MySqlCommand();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                PrepareCommand(conn, null, cmd, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                return val;
            }
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="conn">Connection对象</param>
        /// <param name="cmdType">命令类型（存储过程或SQL语句）</param>
        /// <param name="cmdText">SQL语句或存储过程名</param>
        /// <param name="cmdParms">MySqlCommand参数数组</param>
        /// <returns>返回受引响的记录行数</returns>
        public static int ExecuteNonQuery(MySqlConnection conn, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
        {
            MySqlCommand cmd = new MySqlCommand();

            PrepareCommand(conn, null, cmd, cmdType, cmdText, cmdParms);

            int val = cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();

            return val;

        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="trans">MySqlTransaction对象</param>
        /// <param name="cmdType">命令类型（存储过程或SQL语句）</param>
        /// <param name="cmdText">SQL语句或存储过程名</param>
        /// <param name="cmdParms">MySqlCommand参数数组</param>
        /// <returns>返回受引响的记录行数</returns>
        public static int ExecuteNonQuery(MySqlTransaction trans, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
        {
            MySqlCommand cmd = new MySqlCommand();

            PrepareCommand(trans.Connection, trans, cmd, cmdType, cmdText, cmdParms);

            int val = cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();

            return val;
        }

        #endregion

        #region ExecuteScalar

        /// <summary>
        /// 执行命令，返回第一行第一列的值
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">命令类型（存储过程或SQL语句）</param>
        /// <param name="cmdText">SQL语句或存储过程名</param>
        /// <param name="cmdParms">MySqlCommand参数数组</param>
        /// <returns>返回Object对象</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
        {
            MySqlCommand cmd = new MySqlCommand();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                PrepareCommand(connection, null, cmd, cmdType, cmdText, cmdParms);

                object val = cmd.ExecuteScalar();

                cmd.Parameters.Clear();

                return val;

            }
        }

        /// <summary>
        /// 执行命令，返回第一行第一列的值
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">命令类型（存储过程或SQL语句）</param>
        /// <param name="cmdText">SQL语句或存储过程名</param>
        /// <param name="cmdParms">MySqlCommand参数数组</param>
        /// <returns>返回Object对象</returns>
        public static object ExecuteScalar(MySqlConnection conn, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
        {
            MySqlCommand cmd = new MySqlCommand();

            PrepareCommand(conn, null, cmd, cmdType, cmdText, cmdParms);

            object val = cmd.ExecuteScalar();

            cmd.Parameters.Clear();

            return val;
        }

        public static object ExecuteScalar(string strSql, string conn, params MySqlParameter[] cmdParms)
        {
            if (conn == "") conn = ConnectionString;
            object val;

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand cmd = new MySqlCommand();
                PrepareCommand(connection, null, cmd, CommandType.Text, strSql, cmdParms);

                val = cmd.ExecuteScalar();
            }

            return val;
        }

        #endregion

        #region ExecuteReader

        /// <summary>
        /// 执行命令或存储过程，返回MySqlDataReader对象
        /// 注意MySqlDataReader对象使用完后必须Close以释放MySqlConnection资源
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">命令类型（存储过程或SQL语句）</param>
        /// <param name="cmdText">SQL语句或存储过程名</param>
        /// <param name="cmdParms">MySqlCommand参数数组</param>
        /// <returns></returns>
        public static MySqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                PrepareCommand(conn, null, cmd, cmdType, cmdText, cmdParms);
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();

                return dr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        public static MySqlDataReader ExecuteReader(string strSql)
        {
            MySqlDataReader reader;
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            MySqlCommand command = new MySqlCommand(strSql, connection);

            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (MySqlException exception)
            {
                throw new Exception(exception.Message);
            }

            return reader;
        }

        public static MySqlDataReader ExecuteReader(string strSql, params MySqlParameter[] cmdParms)
        {
            MySqlDataReader reader;
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            MySqlCommand command = new MySqlCommand(strSql, connection);
            try
            {
                PrepareCommand(connection, null, command, CommandType.Text, strSql, cmdParms);
                reader = command.ExecuteReader();
                command.Parameters.Clear();
            }
            catch (MySqlException exception)
            {
                throw new Exception(exception.Message);
            }

            return reader;
        }

        #endregion

        #region ExecuteSql

        public static int ExecuteSql(string strSql)
        {
            int num;

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(strSql, connection);

                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (SqlException exception)
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

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(SQLString, connection);
                MySqlParameter parameter = new MySqlParameter("@content", DbType.String)
                {
                    Value = content
                };

                command.Parameters.Add(parameter);

                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (SqlException exception)
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

        public static int ExecuteSql(string strSql, params MySqlParameter[] cmdParms)
        {
            int num;

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand();

                try
                {
                    PrepareCommand(connection, null, command, CommandType.Text, strSql, cmdParms);
                    num = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                catch (MySqlException exception)
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

        public static int ExecuteSql(string strSql, string conn = "", params MySqlParameter[] cmdParms)
        {
            int num;
            if (conn == "") conn = ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command = new MySqlCommand();

                try
                {
                    PrepareCommand(connection, null, command, CommandType.Text, strSql, cmdParms);
                    num = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                catch (MySqlException exception)
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

        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            int num;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(strSQL, connection);
                MySqlParameter parameter = new MySqlParameter("@fs", DbType.Binary)
                {
                    Value = fs
                };
                command.Parameters.Add(parameter);
                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (SqlException exception)
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

        #endregion

        #region ExecuteTran

        public static bool ExecuteSqlTran(ArrayList strArrayList, string conn = "")
        {
            if (conn == "") conn = ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand
                {
                    Connection = connection
                };

                MySqlTransaction transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                try
                {
                    for (int i = 0; i < strArrayList.Count; i++)
                    {
                        string str = strArrayList[i].ToString();
                        if (str.Trim().Length > 1)
                        {
                            command.CommandText = str;
                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    return true;
                }
                catch (MySqlException exception)
                {
                    transaction.Rollback();
                    throw new Exception(exception.Message);
                }
            }
        }

        public static void ExecuteSqlTran(List<string> list)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand
                {
                    Connection = connection
                };

                MySqlTransaction transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                try
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        string str = list[i];
                        if (str.Trim().Length > 1)
                        {
                            command.CommandText = str;
                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
                catch (MySqlException exception)
                {
                    transaction.Rollback();
                    throw new Exception(exception.Message);
                }
            }
        }

        public static void ExecuteSqlTran(Hashtable hashtable)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    MySqlCommand command = new MySqlCommand();

                    try
                    {
                        foreach (DictionaryEntry entry in hashtable)
                        {
                            string cmdText = entry.Key.ToString();
                            MySqlParameter[] cmdParms = (MySqlParameter[])entry.Value;
                            PrepareCommand(connection, transaction, command, CommandType.Text, cmdText, cmdParms);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
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

        public static void ExecuteSqlTran(ArrayList arrayList, int trans)
        {
            int num = 0;
            int num2 = 0;

            for (int i = 0; i < arrayList.Count; i++)
            {
                if ((i != 0) && ((i % trans) == 0))
                {
                    ArrayList range = arrayList.GetRange(num * trans, trans);
                    num++;
                    num2 += range.Count;
                    ExecuteSqlTran(range);
                    Thread.Sleep(50);
                }
            }

            ExecuteSqlTran(arrayList.GetRange(num * trans, arrayList.Count - num2));
            Thread.Sleep(50);
        }

        #endregion

        #region Exist

        public static bool Exists(string strSql)
        {
            object single = GetSingle(strSql);
            return (((object.Equals(single, null) || object.Equals(single, DBNull.Value)) ? 0 : int.Parse(single.ToString())) != 0);
        }

        public static bool Exists(string strSql, params MySqlParameter[] cmdParms)
        {
            object single = GetSingle(strSql, cmdParms);
            return (((object.Equals(single, null) || object.Equals(single, DBNull.Value)) ? 0 : int.Parse(single.ToString())) != 0);
        }

        public static DataTable GetDataTable(string sql, string conn = "")
        {
            if (conn == "") conn = ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    new MySqlDataAdapter(sql, connection).Fill(dataTable);
                }
                catch (MySqlException exception)
                {
                    throw new Exception(exception.Message);
                }
                return dataTable;
            }
        }

        public static DataTable GetDataTable(string strSql, params MySqlParameter[] cmdParms)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                DataTable dataTable = new DataTable();

                MySqlCommand cmd = new MySqlCommand();
                PrepareCommand(connection, null, cmd, CommandType.Text, strSql, cmdParms);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    try
                    {
                        adapter.Fill(dataTable);
                        cmd.Parameters.Clear();
                    }
                    catch (MySqlException exception)
                    {
                        throw new Exception(exception.Message);
                    }
                }

                return dataTable;
            }
        }

        public static DataTable GetDataTable2(string sql)
        {
            using (MySqlConnection connection = new MySqlConnection(ServerConnectionString))
            {
                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    new MySqlDataAdapter(sql, connection).Fill(dataTable);
                }
                catch (MySqlException exception)
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

        public static object GetSingle(string strSql)
        {
            object obj3;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(strSql, connection);
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
                catch (MySqlException exception)
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

        public static object GetSingle(string strSql, params MySqlParameter[] cmdParms)
        {
            object obj3;

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand();
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
                catch (MySqlException exception)
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

        public static object GetSingleServer(string strSql, params MySqlParameter[] cmdParms)
        {
            object obj3;

            using (MySqlConnection connection = new MySqlConnection(ServerConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand();
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
                catch (MySqlException exception)
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

        public static string GetString(string strSql)
        {
            string str;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(strSql))
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
            if (conn == "") conn = ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                DataSet dataSet = new DataSet();

                try
                {
                    connection.Open();
                    new MySqlDataAdapter(strSql, connection).Fill(dataSet, "ds");
                }
                catch (MySqlException exception)
                {
                    throw new Exception(exception.Message);
                }

                return dataSet;
            }
        }

        public static DataSet Query(string strSql, params MySqlParameter[] cmdParms)
        {
            DataSet set2;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand();
                PrepareCommand(connection, null, cmd, CommandType.Text, strSql, cmdParms);
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataSet dataSet = new DataSet();
                    try
                    {
                        adapter.Fill(dataSet, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (MySqlException exception)
                    {
                        throw new Exception(exception.Message);
                    }
                    set2 = dataSet;
                }
            }
            return set2;
        }

        #endregion

        #region ExecuteDataSet

        /// <summary>
        /// 执行命令或存储过程，返回DataSet对象
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">命令类型(存储过程或SQL语句)</param>
        /// <param name="cmdText">SQL语句或存储过程名</param>
        /// <param name="cmdParms">MySqlCommand参数数组(可为null值)</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
        {

            MySqlCommand cmd = new MySqlCommand();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {

                PrepareCommand(conn, null, cmd, cmdType, cmdText, cmdParms);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);

                conn.Close();

                cmd.Parameters.Clear();

                return ds;

            }

        }

        #endregion

        public static DataSet ServerQuery(string strSql)
        {
            // 数据库名称
            string BackData = ConfigHelper.GetSetNode("BackData");

            if (BackData == "") BackData = "qcpaddb";

            String connetStr = "Server=124.128.220.82;Database=" + BackData + ";Uid=root;Pwd=qckj;port=3306;";

            using (MySqlConnection connection = new MySqlConnection(connetStr))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new MySqlDataAdapter(strSql, connection).Fill(dataSet, "ds");
                }
                catch (MySqlException exception)
                {
                    throw new Exception(exception.Message);
                }
                return dataSet;
            }
        }
    }
}