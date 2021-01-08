namespace KangShuoTech.Utilities.SQLiteHelper
{
    using System;
    using System.Data.Common;
    using System.Data.SqlClient;

    public class CommandInfo
    {
        public string CommandText;
        public EffentNextType EffentNextType;
        public object OriginalData;
        public DbParameter[] Parameters;
        public object ShareObject;

        private event EventHandler _solicitationEvent;

        public event EventHandler SolicitationEvent
        {
            add
            {
                this._solicitationEvent += value;
            }
            remove
            {
                this._solicitationEvent -= value;
            }
        }

        public CommandInfo()
        {
        }

        public CommandInfo(string sqlText, SqlParameter[] para)
        {
            this.CommandText = sqlText;
            this.Parameters = (DbParameter[]) para;
        }

        public CommandInfo(string sqlText, SqlParameter[] para, EffentNextType type)
        {
            this.CommandText = sqlText;
            this.Parameters = (DbParameter[]) para;
            this.EffentNextType = type;
        }

        public void OnSolicitationEvent()
        {
            if (this._solicitationEvent != null)
            {
                this._solicitationEvent(this, new EventArgs());
            }
        }
    }
}

