﻿namespace KangShuoTech.Utilities.CommonTools
{
    using System.Data;
    using System.Data.OleDb;

    public class AccessDbClass
    {
        public OleDbConnection Conn;
        public string ConnString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";

        public AccessDbClass(string Dbpath)
        {
            this.ConnString = this.ConnString + Dbpath;
            this.Conn = new OleDbConnection(this.ConnString);
            this.Conn.Open();
        }

        public void Close()
        {
            this.Conn.Close();
        }

        public OleDbConnection DbConn()
        {
            this.Conn.Open();
            return this.Conn;
        }

        public bool ExecuteSQLNonquery(string SQL)
        {
            OleDbCommand command = new OleDbCommand(SQL, this.Conn);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataSet SelectToDataSet(string SQL, string subtableName)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, this.Conn);
            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(subtableName);
            adapter.Fill(dataSet, subtableName);
            return dataSet;
        }

        public DataSet SelectToDataSet(string SQL, string subtableName, DataSet DataSetName)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, this.Conn);
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            DataSet set = new DataSet();
            set = DataSetName;
            adapter.Fill(DataSetName, subtableName);
            return set;
        }

        public DataTable SelectToDataTable(string SQL)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, this.Conn);
            adapter.SelectCommand = command;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public OleDbDataAdapter SelectToOleDbDataAdapter(string SQL)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, this.Conn);
            adapter.SelectCommand = command;
            return adapter;
        }
    }
}

