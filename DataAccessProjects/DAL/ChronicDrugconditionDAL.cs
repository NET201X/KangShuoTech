using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ChronicDrugconditionDAL
    {
        public int Add(ChronicDrugConditionModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CD_DRUGCONDITION(");
            builder.Append("IDCardNo,Type,Name,DailyTime,EveryTimeMg,drugtype,factory,DosAge,OUTKey )");
            builder.Append(" values (");
            builder.Append("@IDCardNo,@Type,@Name,@DailyTime,@EveryTimeMg,@drugtype,@factory,@DosAge,@OUTKey )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Type", MySqlDbType.String, 1), 
                new MySqlParameter("@Name", MySqlDbType.String, 100), 
                new MySqlParameter("@DailyTime", MySqlDbType.Decimal), 
                new MySqlParameter("@EveryTimeMg", MySqlDbType.String,100),
                new MySqlParameter("@drugtype", MySqlDbType.String,100),
                new MySqlParameter("@factory", MySqlDbType.String,100),
                new MySqlParameter("@DosAge", MySqlDbType.String,100),
                new MySqlParameter("@OUTKey", MySqlDbType.Int32,11)
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Type;
            cmdParms[2].Value = model.Name;
            cmdParms[3].Value = model.DailyTime;
            cmdParms[4].Value = model.EveryTimeMg;
            cmdParms[5].Value = model.drugtype;
            cmdParms[6].Value = model.factory;
            cmdParms[7].Value = model.DosAge;
            cmdParms[8].Value = model.OUTKey;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public ChronicDrugConditionModel DataRowToModel(DataRow row)
        {
            ChronicDrugConditionModel cd_drugcondition = new ChronicDrugConditionModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    cd_drugcondition.ID = int.Parse(row["ID"].ToString());
                }
                if (((row["OUTKey"] != null) && (row["OUTKey"] != DBNull.Value)) && (row["OUTKey"].ToString() != ""))
                {
                    cd_drugcondition.OUTKey = int.Parse(row["OUTKey"].ToString());
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    cd_drugcondition.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Type"] != null) && (row["Type"] != DBNull.Value))
                {
                    cd_drugcondition.Type = row["Type"].ToString();
                }
                if ((row["Name"] != null) && (row["Name"] != DBNull.Value))
                {
                    cd_drugcondition.Name = row["Name"].ToString();
                }

                if (((row["DailyTime"] != null) && (row["DailyTime"] != DBNull.Value)) && (row["DailyTime"].ToString() != ""))
                {
                    cd_drugcondition.DailyTime = new decimal?(decimal.Parse(row["DailyTime"].ToString()));
                }
                
                if ((row["EveryTimeMg"] != null) && (row["EveryTimeMg"] != DBNull.Value))
                {
                    cd_drugcondition.EveryTimeMg = row["EveryTimeMg"].ToString();
                }
                if ((row["drugtype"] != null) && (row["drugtype"] != DBNull.Value))
                {
                    cd_drugcondition.drugtype = row["drugtype"].ToString();
                }
                if ((row["factory"] != null) && (row["factory"] != DBNull.Value))
                {
                    cd_drugcondition.factory = row["factory"].ToString();
                }
                if ((row["DosAge"] != null) && (row["DosAge"] != DBNull.Value))
                {
                    cd_drugcondition.DosAge = row["DosAge"].ToString();
                }
            }
            return cd_drugcondition;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_DRUGCONDITION ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteOUTKey(int OUTKey ,string drugType)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_DRUGCONDITION ");
            builder.Append(" where OUTKey=@OUTKey and Type =@Type ");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@OUTKey", MySqlDbType.Int32, 4) ,
                new MySqlParameter("@Type", MySqlDbType.String, 1) 
            };
            cmdParms[0].Value = OUTKey;
            cmdParms[1].Value = drugType;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_DRUGCONDITION ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CD_DRUGCONDITION");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public bool ExistOUTKey(int OUTKey ,int ID, string drugType)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CD_DRUGCONDITION");
            builder.Append(" where OUTKey=@OUTKey and ID =@ID and Type = @Type ");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@OUTKey", MySqlDbType.Int32, 11),
                new MySqlParameter("@ID", MySqlDbType.Int32, 4),
                new MySqlParameter("@Type", MySqlDbType.String, 50)
            };
            cmdParms[0].Value = OUTKey;
            cmdParms[1].Value = ID;
            cmdParms[2].Value = drugType;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,IDCardNo,Type,Name,DailyTime,EveryTimeMg,drugtype,factory,DosAge,OUTKey ");
            builder.Append(" FROM CD_DRUGCONDITION ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere + " order by id limit 4");
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM ( ");
            builder.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append("order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }
            builder.Append(")AS Row, T.*  from CD_DRUGCONDITION T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("ID", "CD_DRUGCONDITION");
        }

        public ChronicDrugConditionModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,IDCardNo,Type,Name,DailyTime,EveryTimeMg,drugtype,factory,DosAge,OUTKey from CD_DRUGCONDITION ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new ChronicDrugConditionModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM CD_DRUGCONDITION ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public bool Update(ChronicDrugConditionModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CD_DRUGCONDITION set ");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Type=@TYPE,");
            builder.Append("Name=@NAME,");
            builder.Append("DailyTime=@DAILYTIME,");
            builder.Append("EveryTimeMg=@EVERYTIMEMG,");
            builder.Append("drugtype = @drugtype,");
            builder.Append("factory = @factory,");
            builder.Append("DosAge = @DosAge, ");
            builder.Append("OUTKey = @OUTKey ");
            builder.Append(" where ID=@ID ");
            MySqlParameter[] cmdParms = new MySqlParameter[] 
            {new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@TYPE", MySqlDbType.String, 1), 
                new MySqlParameter("@NAME", MySqlDbType.String, 100), 
                new MySqlParameter("@DAILYTIME", MySqlDbType.Decimal), 
                new MySqlParameter("@EVERYTIMEMG", MySqlDbType.String,100),
                new MySqlParameter("@drugtype", MySqlDbType.String,100),
                new MySqlParameter("@factory", MySqlDbType.String,100),
                new MySqlParameter("@DosAge", MySqlDbType.String,100),
                new MySqlParameter("@OUTKey", MySqlDbType.Int32, 8),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8) };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Type;
            cmdParms[2].Value = model.Name;
            cmdParms[3].Value = model.DailyTime;
            cmdParms[4].Value = model.EveryTimeMg;
            cmdParms[5].Value = model.drugtype;
            cmdParms[6].Value = model.factory;
            cmdParms[7].Value = model.DosAge;
            cmdParms[8].Value = model.OUTKey;
            cmdParms[9].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateOUTKey(ChronicDrugConditionModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CD_DRUGCONDITION set ");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Type=@TYPE,");
            builder.Append("Name=@NAME,");
            builder.Append("DailyTime=@DAILYTIME,");
            builder.Append("EveryTimeMg=@EVERYTIMEMG,");
            builder.Append("drugtype = @drugtype,");
            builder.Append("factory = @factory,");
            builder.Append("DosAge = @DosAge ");
            builder.Append(" where ID=@ID and OUTKey = @OUTKey ");
            MySqlParameter[] cmdParms = new MySqlParameter[] 
            {new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@TYPE", MySqlDbType.String, 1), 
                new MySqlParameter("@NAME", MySqlDbType.String, 100), 
                new MySqlParameter("@DAILYTIME", MySqlDbType.Decimal), 
                new MySqlParameter("@EVERYTIMEMG", MySqlDbType.Decimal),
                new MySqlParameter("@drugtype", MySqlDbType.String,100),
                new MySqlParameter("@factory", MySqlDbType.String,100),
                new MySqlParameter("@DosAge", MySqlDbType.String,100),
                new MySqlParameter("@OUTKey", MySqlDbType.Int32, 8),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8) };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Type;
            cmdParms[2].Value = model.Name;
            cmdParms[3].Value = model.DailyTime;
            cmdParms[4].Value = model.EveryTimeMg;
            cmdParms[5].Value = model.drugtype;
            cmdParms[6].Value = model.factory;
            cmdParms[7].Value = model.DosAge;
            cmdParms[8].Value = model.OUTKey;
            cmdParms[9].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

