using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsHyperSurveyDAL
    {
        public int Add(RecordsHyperSurveyModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_HYPER_SURVEY(");
            builder.Append("IDCardNo,EatPersonSum,EatChildSum,EatSaltQuantity,EatSoyQuntity,OutKey )");
            builder.Append(" values (");
            builder.Append("@IDCardNo,@EatPersonSum,@EatChildSum,@EatSaltQuantity,@EatSoyQuntity,@OutKey )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 18), 
                new MySqlParameter("@EatPersonSum", MySqlDbType.Int32), 
                new MySqlParameter("@EatChildSum", MySqlDbType.Int32), 
                new MySqlParameter("@EatSaltQuantity", MySqlDbType.Decimal), 
                new MySqlParameter("@EatSoyQuntity", MySqlDbType.Decimal),
                new MySqlParameter("@OutKey",MySqlDbType.Int32,4)
               
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.EatPersonSum;
            cmdParms[2].Value = model.EatChildSum;
            cmdParms[3].Value = model.EatSaltQuantity;
            cmdParms[4].Value = model.EatSoyQuntity;
            cmdParms[5].Value = model.OutKey;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsHyperSurveyModel DataRowToModel(DataRow row)
        {
            RecordsHyperSurveyModel HyperSurveyModel = new RecordsHyperSurveyModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    HyperSurveyModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    HyperSurveyModel.IDCardNo = row["IDCardNo"].ToString();
                }

                if (((row["EatPersonSum"] != null) && (row["EatPersonSum"] != DBNull.Value)) && (row["EatPersonSum"].ToString() != ""))
                {
                    HyperSurveyModel.EatPersonSum = new int?(int.Parse(row["EatPersonSum"].ToString()));
                }
                if (((row["EatChildSum"] != null) && (row["EatChildSum"] != DBNull.Value)) && (row["EatChildSum"].ToString() != ""))
                {
                    HyperSurveyModel.EatChildSum = new int?(int.Parse(row["EatChildSum"].ToString()));
                }

                if (((row["EatSaltQuantity"] != null) && (row["EatSaltQuantity"] != DBNull.Value)) && (row["EatSaltQuantity"].ToString() != ""))
                {
                    HyperSurveyModel.EatSaltQuantity = new decimal?(decimal.Parse(row["EatSaltQuantity"].ToString()));
                }
                if (((row["EatSoyQuntity"] != null) && (row["EatSoyQuntity"] != DBNull.Value)) && (row["EatSoyQuntity"].ToString() != ""))
                {
                    HyperSurveyModel.EatSoyQuntity = new decimal?(decimal.Parse(row["EatSoyQuntity"].ToString()));
                }
                if (((row["OutKey"] != null) && (row["OutKey"] != DBNull.Value)) && (row["OutKey"].ToString() != ""))
                {
                    HyperSurveyModel.OutKey = int.Parse(row["OutKey"].ToString());
                }

            }
            return HyperSurveyModel;
        }
        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_HYPER_SURVEY ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_HYPER_SURVEY ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_HYPER_SURVEY ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,IDCardNo,EatPersonSum,EatChildSum,EatSaltQuantity,EatSoyQuntity,OutKey ");
            builder.Append(" FROM ARCHIVE_HYPER_SURVEY ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }
        public RecordsHyperSurveyModel GetModel(int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,IDCardNo,EatPersonSum,EatChildSum,EatSaltQuantity,EatSoyQuntity,OutKey ");
            builder.Append(" from ARCHIVE_HYPER_SURVEY where OutKey=@OutKey ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32) };
            cmdParms[0].Value = OutKey;
            new RecordsHyperSurveyModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public bool Update(RecordsHyperSurveyModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_HYPER_SURVEY set ");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("EatPersonSum=@EatPersonSum,");
            builder.Append("EatChildSum=@EatChildSum,");
            builder.Append("EatSaltQuantity=@EatSaltQuantity,");
            builder.Append("EatSoyQuntity=@EatSoyQuntity, ");
            builder.Append("OutKey=@OutKey ");
            builder.Append(" where ID=@ID ");
            MySqlParameter[] cmdParms = new MySqlParameter[] 
            {new MySqlParameter("@IDCardNo", MySqlDbType.String, 18), 
                new MySqlParameter("@EatPersonSum", MySqlDbType.Int32), 
                new MySqlParameter("@EatChildSum", MySqlDbType.Int32), 
                new MySqlParameter("@EatSaltQuantity", MySqlDbType.Decimal), 
                new MySqlParameter("@EatSoyQuntity", MySqlDbType.Decimal),
                new MySqlParameter("@OutKey",MySqlDbType.Int32,4),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8) 
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.EatPersonSum;
            cmdParms[2].Value = model.EatChildSum;
            cmdParms[3].Value = model.EatSaltQuantity;
            cmdParms[4].Value = model.EatSoyQuntity;
            cmdParms[5].Value = model.OutKey;
            cmdParms[6].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool ExistsOutKey(string IDCardNo, int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_HYPER_SURVEY");
            builder.Append(" where IDCardNo=@IDCardNo ");
            builder.Append(" and OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String) ,
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) 
            };
            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = OutKey;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
    }
}
