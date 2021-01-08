using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.Model;
using MySql.Data.MySqlClient;
using KangShuoTech.Utilities.MySQLHelper;
using System.Data;
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.DataAccessProjects.DAL
{
    public class HealthSelfCareabilityDAL
    {
        public int Add(HealthSelfCareabilityModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" insert into tbl_hhselfcareability(");
            builder.Append("PID,IDCardNo,Dine,Groming,Dressing,Tolet,Activity,TotalScore,CreatedBy,CreatedDate,LastUpDateBy,LastUpDateDate)");
            builder.Append(" values (");
            builder.Append("@PID,@IDCardNo,@Dine,@Groming,@Dressing,@Tolet,@Activity,@TotalScore,@CreatedBy,@CreatedDate,@LastUpDateBy,@LastUpDateDate)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
            new MySqlParameter("@PID",MySqlDbType.Int32),
            new MySqlParameter("@IDCardNo",MySqlDbType.String),
            new MySqlParameter("@Dine",MySqlDbType.Decimal),
            new MySqlParameter("@Groming",MySqlDbType.Decimal),
            new MySqlParameter("@Dressing",MySqlDbType.Decimal),
            new MySqlParameter("@Tolet",MySqlDbType.Decimal),
            new MySqlParameter("@Activity",MySqlDbType.Decimal),
            new MySqlParameter("@TotalScore",MySqlDbType.Decimal),
            new MySqlParameter("@CreatedBy",MySqlDbType.String),
            new MySqlParameter("@CreatedDate",MySqlDbType.Date),
            new MySqlParameter("@LastUpDateBy",MySqlDbType.String),
            new MySqlParameter("@LastUpDateDate",MySqlDbType.Date)
            };
            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Dine;
            cmdParms[3].Value = model.Groming;
            cmdParms[4].Value = model.Dressing;
            cmdParms[5].Value = model.Tolet;
            cmdParms[6].Value = model.Activity;
            cmdParms[7].Value = model.TotalScore;
            cmdParms[8].Value = model.CreatedBy;
            cmdParms[9].Value = model.CreatedDate;
            cmdParms[10].Value = model.LastUpDateBy;
            cmdParms[11].Value = model.LastUpDateDate;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public HealthSelfCareabilityModel GetModel(int PID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" select * ");
            builder.Append(" from tbl_hhselfcareability ");
            builder.Append(" where PID=@PID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@PID", PID)
            };
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set != null)
            {
                // 将DataTable转为List
                IList<HealthSelfCareabilityModel> list = CommonExtensions.DataTableToList<HealthSelfCareabilityModel>(set.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }
        /// <summary>
        /// 根据PID判断肺功能资料是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsPID(string IDCardNo, int PID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_hhselfcareability");
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
        public bool Update(HealthSelfCareabilityModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" update tbl_hhselfcareability set ");
            //builder.Append("PID=@PID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Dine=@Dine,");
            builder.Append("Groming=@Groming,");
            builder.Append("Dressing=@Dressing,");
            builder.Append("Tolet=@Tolet,");
            builder.Append("Activity=@Activity,");
            builder.Append("TotalScore=@TotalScore,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpDateBy=@LastUpDateBy,");
            builder.Append("LastUpDateDate=@LastUpDateDate");
            builder.Append(" where PID=@PID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
            new MySqlParameter("@PID",MySqlDbType.Int32),
            new MySqlParameter("@IDCardNo",MySqlDbType.String),
            new MySqlParameter("@Dine",MySqlDbType.Decimal),
            new MySqlParameter("@Groming",MySqlDbType.Decimal),
            new MySqlParameter("@Dressing",MySqlDbType.Decimal),
            new MySqlParameter("@Tolet",MySqlDbType.Decimal),
            new MySqlParameter("@Activity",MySqlDbType.Decimal),
            new MySqlParameter("@TotalScore",MySqlDbType.Decimal),
            new MySqlParameter("@CreatedBy",MySqlDbType.String),
            new MySqlParameter("@CreatedDate",MySqlDbType.Date),
            new MySqlParameter("@LastUpDateBy",MySqlDbType.String),
            new MySqlParameter("@LastUpDateDate",MySqlDbType.Date)
            };
            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Dine;
            cmdParms[3].Value = model.Groming;
            cmdParms[4].Value = model.Dressing;
            cmdParms[5].Value = model.Tolet;
            cmdParms[6].Value = model.Activity;
            cmdParms[7].Value = model.TotalScore;
            cmdParms[8].Value = model.CreatedBy;
            cmdParms[9].Value = model.CreatedDate;
            cmdParms[10].Value = model.LastUpDateBy;
            cmdParms[11].Value = model.LastUpDateDate;
            //cmdParms[12].Value = model.PID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
