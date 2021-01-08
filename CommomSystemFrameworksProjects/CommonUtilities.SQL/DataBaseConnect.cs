namespace CommonUtilities.SQL
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Windows.Forms;
    using System.Configuration;

    public class DataBaseConnect
    {
        private OleDbConnection connection;
        private string connectionString = "";//ConfigurationManager.AppSettings["connectionString"].ToString();

        /// <summary>
        /// 构造函数 
        /// </summary>
        public DataBaseConnect(string con)
        {
            connectionString = con;
            this.connection = new OleDbConnection(this.connectionString);
        }
       

        public void CloseDatabase()
        {
            try
            {
                this.connection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public int InsertAndUpdateAndDeleteDatabase(string sql, OleDbParameter[] parameters)
        {
            OleDbCommand command = new OleDbCommand(sql, this.connection);
            OpenDatabase();
            try
            {
                command.Parameters.AddRange(parameters);
                return command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show("数据库插入、更新或删除操作异常！");
            }
            finally {
                CloseDatabase();
            }
            return 0;
        }

        public void OpenDatabase()
        {
            try
            {
                this.connection.Open();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show("数据库连接不上！");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet QueryDatabase(string sql)
        {
            DataSet dataSet = new DataSet();
            try
            {
                OleDbCommand command = new OleDbCommand(sql, this.connection);
                new OleDbDataAdapter(sql, this.connection).Fill(dataSet, "ds");
            }
            catch(Exception ee)
            {
                MessageBox.Show("数据库查询异常！"+ee.ToString());
            }
            return dataSet;
        }

    }
}

