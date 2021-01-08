using KangShuoTech.Utilities.SQLHelper;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;
using System;
using MySql.Data.MySqlClient;

namespace KangShuoTech.DataAccessProjects.DAL
{
    public class HHLungDAL
    {
        /// <summary>
        /// 新增肺功能资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(HHLungModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"INSERT INTO tbl_HHLung
                                     (
                                         IDCardNo
                                        ,CheckDate
                                        ,PID
                                        ,Result
                                        ,ResultEx
                                    )
                                    VALUES
                                     (
                                        @IDCardNo
                                        ,@CheckDate
                                        ,@PID
                                        ,@Result
                                        ,@ResultEx
                                     ) ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@IDCardNo", MySqlDbType.String, 18),
                 new MySqlParameter("@CheckDate", MySqlDbType.Date),
                 new MySqlParameter("@PID", MySqlDbType.Int32),
                 new MySqlParameter("@Result", MySqlDbType.String, 1),
                 new MySqlParameter("@ResultEx", MySqlDbType.String, 500)
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.CheckDate;
            cmdParms[2].Value = model.PID;
            cmdParms[3].Value = model.Result;
            cmdParms[4].Value = model.ResultEx;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 修改肺功能资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(HHLungModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE tbl_HHLung
                                     SET
                                        CheckDate = @CheckDate 
                                        ,Result = @Result 
                                        ,ResultEx = @ResultEx
                                       WHERE PID=@PID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@PID", MySqlDbType.Int32),
                 new MySqlParameter("@CheckDate", MySqlDbType.Date),
                 new MySqlParameter("@Result", MySqlDbType.String, 1),
                 new MySqlParameter("@ResultEx", MySqlDbType.String, 500)
            };
            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.CheckDate;
            cmdParms[2].Value = model.Result;
            cmdParms[3].Value = model.ResultEx;

            object single = MySQLHelper.ExecuteSql(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }
        /// <summary>
        /// 根据PID判断肺功能资料是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsPID(string IDCardNo, int PID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_HHLung");
            builder.Append(" where IDCardNo=@IDCardNo ");
            builder.Append(" and PID=@PID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String) ,
                new MySqlParameter("@PID", MySqlDbType.Int32, 4) 
            };
            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = PID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据ID取得资料
        /// </summary>
        public HHLungModel GetData(string IDCardNo, int PID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"SELECT * from  tbl_HHLung ");
            builder.Append(" where IDCardNo=@IDCardNo ");
            builder.Append(" and PID=@PID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String) ,
                new MySqlParameter("@PID", MySqlDbType.Int32, 4) 
            };
            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = PID;
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public HHLungModel DataRowToModel(DataRow row)
        {
            HHLungModel LungModel = new HHLungModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    LungModel.ID = int.Parse(row["ID"].ToString());
                }
                if (((row["PID"] != null) && (row["PID"] != DBNull.Value)) && (row["PID"].ToString() != ""))
                {
                    LungModel.PID = int.Parse(row["PID"].ToString());
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    LungModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["ResultEx"] != null) && (row["ResultEx"] != DBNull.Value))
                {
                    LungModel.ResultEx = row["ResultEx"].ToString();
                }
                if ((row["Result"] != null) && (row["Result"] != DBNull.Value))
                {
                    LungModel.Result = row["Result"].ToString();
                }
                if ((row["ImgPath"] != null) && (row["ImgPath"] != DBNull.Value))
                {
                    LungModel.ImgPath = row["ImgPath"].ToString();
                }
                if (((row["CheckDate"] != null) && (row["CheckDate"] != DBNull.Value)) && (row["CheckDate"].ToString() != ""))
                {
                    LungModel.CheckDate = new DateTime?(DateTime.Parse(row["CheckDate"].ToString()));
                }
            }
            return LungModel;
        }
    }
}
