using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsHyperFoodsDAL
    {
        public int Add(RecordsHyperFoodsModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_HYPER_FOOD(");
            builder.Append("IDCardNo,FoodName,EatYesNo,DayBeats,WeekBeats,MouthBeats,SaltSumBeats,OutKey )");
            builder.Append(" values (");
            builder.Append("@IDCardNo,@FoodName,@EatYesNo,@DayBeats,@WeekBeats,@MouthBeats,@SaltSumBeats,@OutKey )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 18), 
                new MySqlParameter("@FoodName", MySqlDbType.String, 100), 
                new MySqlParameter("@EatYesNo", MySqlDbType.String, 1), 
                new MySqlParameter("@DayBeats", MySqlDbType.Decimal), 
                new MySqlParameter("@WeekBeats", MySqlDbType.Decimal),
                new MySqlParameter("@MouthBeats", MySqlDbType.Decimal),
                new MySqlParameter("@SaltSumBeats", MySqlDbType.Decimal),
                new MySqlParameter("@OutKey",MySqlDbType.Int32,4)
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.FoodName;
            cmdParms[2].Value = model.EatYesNo;
            cmdParms[3].Value = model.DayBeats;
            cmdParms[4].Value = model.WeekBeats;
            cmdParms[5].Value = model.MouthBeats;
            cmdParms[6].Value = model.SaltSumBeats;
            cmdParms[7].Value = model.OutKey;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public RecordsHyperFoodsModel DataRowToModel(DataRow row)
        {
            RecordsHyperFoodsModel HyperFoodsModel = new RecordsHyperFoodsModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    HyperFoodsModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    HyperFoodsModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["FoodName"] != null) && (row["FoodName"] != DBNull.Value))
                {
                    HyperFoodsModel.FoodName = row["FoodName"].ToString();
                }
                if ((row["EatYesNo"] != null) && (row["EatYesNo"] != DBNull.Value))
                {
                    HyperFoodsModel.EatYesNo = row["EatYesNo"].ToString();
                }
                if (((row["DayBeats"] != null) && (row["DayBeats"] != DBNull.Value)) && (row["DayBeats"].ToString() != ""))
                {
                    HyperFoodsModel.DayBeats = new decimal?(decimal.Parse(row["DayBeats"].ToString()));
                }
                if (((row["WeekBeats"] != null) && (row["WeekBeats"] != DBNull.Value)) && (row["WeekBeats"].ToString() != ""))
                {
                    HyperFoodsModel.WeekBeats = new decimal?(decimal.Parse(row["WeekBeats"].ToString()));
                }
                if (((row["MouthBeats"] != null) && (row["MouthBeats"] != DBNull.Value)) && (row["MouthBeats"].ToString() != ""))
                {
                    HyperFoodsModel.MouthBeats = new decimal?(decimal.Parse(row["MouthBeats"].ToString()));
                }
                if (((row["SaltSumBeats"] != null) && (row["SaltSumBeats"] != DBNull.Value)) && (row["SaltSumBeats"].ToString() != ""))
                {
                    HyperFoodsModel.SaltSumBeats = new decimal?(decimal.Parse(row["SaltSumBeats"].ToString()));
                }
                if (((row["OutKey"] != null) && (row["OutKey"] != DBNull.Value)) && (row["OutKey"].ToString() != ""))
                {
                    HyperFoodsModel.OutKey = int.Parse(row["OutKey"].ToString());
                }
              
            }
            return HyperFoodsModel;
        }
        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_HYPER_FOOD ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_HYPER_FOOD ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_HYPER_FOOD");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,IDCardNo,FoodName,EatYesNo,DayBeats,WeekBeats,MouthBeats,SaltSumBeats,OutKey ");
            builder.Append(" FROM ARCHIVE_HYPER_FOOD ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }
        public RecordsHyperFoodsModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,IDCardNo,FoodName,EatYesNo,DayBeats,WeekBeats,MouthBeats,SaltSumBeats from ARCHIVE_HYPER_FOOD,OutKey ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsHyperFoodsModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public bool Update(RecordsHyperFoodsModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_HYPER_FOOD set ");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("FoodName=@FoodName,");
            builder.Append("EatYesNo=@EatYesNo,");
            builder.Append("DayBeats=@DayBeats,");
            builder.Append("WeekBeats=@WeekBeats,");
            builder.Append("MouthBeats = @MouthBeats,");
            builder.Append("SaltSumBeats = @SaltSumBeats, ");
            builder.Append("OutKey=@OutKey ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] 
            {new MySqlParameter("@IDCardNo", MySqlDbType.String, 18), 
                new MySqlParameter("@FoodName", MySqlDbType.String, 100), 
                new MySqlParameter("@EatYesNo", MySqlDbType.String, 1), 
                new MySqlParameter("@DayBeats", MySqlDbType.Decimal), 
                new MySqlParameter("@WeekBeats", MySqlDbType.Decimal),
                new MySqlParameter("@MouthBeats", MySqlDbType.Decimal),
                new MySqlParameter("@SaltSumBeats", MySqlDbType.Decimal),
                new MySqlParameter("@OutKey",MySqlDbType.Int32,4),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8) };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.FoodName;
            cmdParms[2].Value = model.EatYesNo;
            cmdParms[3].Value = model.DayBeats;
            cmdParms[4].Value = model.WeekBeats;
            cmdParms[5].Value = model.MouthBeats;
            cmdParms[6].Value = model.SaltSumBeats;
            cmdParms[7].Value = model.OutKey;
            cmdParms[8].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool ExistsOutKey(string IDCardNo, string FoodName, int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_HYPER_FOOD");
            builder.Append(" where IDCardNo=@IDCardNo ");
            builder.Append(" and OutKey=@OutKey and FoodName=@FoodName ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String) ,
                new MySqlParameter("@FoodName", MySqlDbType.String) ,
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) 
            };
            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = FoodName;
            cmdParms[2].Value = OutKey;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

    }
}
