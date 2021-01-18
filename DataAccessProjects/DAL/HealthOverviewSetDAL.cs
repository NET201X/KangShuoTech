using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.Model;
using MySql.Data.MySqlClient;
using KangShuoTech.Utilities.MySQLHelper;
using KangShuoTech.Utilities.Common;
using System.Data;

namespace KangShuoTech.DataAccessProjects.DAL
{
    public class HealthOverviewSetDAL
    {
        public int Add(HealthOverviewSetModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" insert into HEALTHHOUSE_OVERVIEW_SET(");
            builder.Append("Type,maxValues,minValues,MaxEx,MinEx,Content,Col2,Col3,CreateDate,CreateBy,UpdateDate,UpdateBy)");
            builder.Append(" values (");
            builder.Append("@Type,@maxValues,@minValues,@MaxEx,@MinEx,@Content,@Col2,@Col3,@CreateDate,@CreateBy,@UpdateDate,@UpdateBy)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@Type",MySqlDbType.Int32),
                new MySqlParameter("@maxValues",MySqlDbType.String),
                new MySqlParameter("@minValues",MySqlDbType.String),
                new MySqlParameter("@MaxEx",MySqlDbType.String),
                new MySqlParameter("@MinEx",MySqlDbType.String),
                new MySqlParameter("@Content",MySqlDbType.String),
                new MySqlParameter("@Col2",MySqlDbType.String),
                new MySqlParameter("@Col3",MySqlDbType.String),
                new MySqlParameter("@CreateDate",MySqlDbType.Date),
                new MySqlParameter("@CreateBy",MySqlDbType.String),
                new MySqlParameter("@UpdateDate",MySqlDbType.Date),
                new MySqlParameter("@UpdateBy",MySqlDbType.String)
                };
            cmdParms[0].Value = model.Type;
            cmdParms[1].Value = model.maxValues;
            cmdParms[2].Value = model.minValues;
            cmdParms[3].Value = model.MaxEx;
            cmdParms[4].Value = model.MinEx;
            cmdParms[5].Value = model.Content;
            cmdParms[6].Value = model.Col2;
            cmdParms[7].Value = model.Col3;
            cmdParms[8].Value = model.CreateDate;
            cmdParms[9].Value = model.CreateBy;
            cmdParms[10].Value = model.UpdateDate;
            cmdParms[11].Value = model.UpdateBy;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public HealthOverviewSetModel GetModel(int PID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" select * ");
            builder.Append(" from HEALTHHOUSE_OVERVIEW_SET ");
            builder.Append(" where PID=@PID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@PID", PID)
            };
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set != null)
            {
                // 将DataTable转为List
                IList<HealthOverviewSetModel> list = CommonExtensions.DataTableToList<HealthOverviewSetModel>(set.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }
        public List<HealthOverviewSetModel> GetList(string strwhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" select * ");
            builder.Append(" from HEALTHHOUSE_OVERVIEW_SET ");
            builder.Append(" where 1=1  ");
            if (!string.IsNullOrEmpty(strwhere))
            {
                builder.Append(strwhere);
            }
            DataSet set = MySQLHelper.Query(builder.ToString());
            if (set != null)
            {
                // 将DataTable转为List
                List<HealthOverviewSetModel> list = CommonExtensions.ToList<HealthOverviewSetModel>(set.Tables[0]);

                if (list.Count > 0) return list;
            }
            return null;
        }
        public bool Update(HealthOverviewSetModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" update HEALTHHOUSE_OVERVIEW_SET set ");
            builder.Append("Type=@Type,");
            builder.Append("maxValues=@maxValues,");
            builder.Append("minValues=@minValues,");
            builder.Append("MaxEx=@MaxEx,");
            builder.Append("MinEx=@MinEx,");
            builder.Append("Content=@Content,");
            builder.Append("Col2=@Col2,");
            builder.Append("Col3=@Col3,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("CreateBy=@CreateBy,");
            builder.Append("UpdateDate=@UpdateDate,");
            builder.Append("UpdateBy=@UpdateBy");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@Type",MySqlDbType.Int32),
                new MySqlParameter("@maxValues",MySqlDbType.String),
                new MySqlParameter("@minValues",MySqlDbType.String),
                new MySqlParameter("@MaxEx",MySqlDbType.String),
                new MySqlParameter("@MinEx",MySqlDbType.String),
                new MySqlParameter("@Content",MySqlDbType.String),
                new MySqlParameter("@Col2",MySqlDbType.String),
                new MySqlParameter("@Col3",MySqlDbType.String),
                new MySqlParameter("@CreateDate",MySqlDbType.Date),
                new MySqlParameter("@CreateBy",MySqlDbType.String),
                new MySqlParameter("@UpdateDate",MySqlDbType.Date),
                new MySqlParameter("@UpdateBy",MySqlDbType.String),
                new MySqlParameter("@ID",MySqlDbType.Int32),
                };
            cmdParms[0].Value = model.Type;
            cmdParms[1].Value = model.maxValues;
            cmdParms[2].Value = model.minValues;
            cmdParms[3].Value = model.MaxEx;
            cmdParms[4].Value = model.MinEx;
            cmdParms[5].Value = model.Content;
            cmdParms[6].Value = model.Col2;
            cmdParms[7].Value = model.Col3;
            cmdParms[8].Value = model.CreateDate;
            cmdParms[9].Value = model.CreateBy;
            cmdParms[10].Value = model.UpdateDate;
            cmdParms[11].Value = model.UpdateBy;
            cmdParms[12].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 获取体检数据类型的异常信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public HealthOverviewSetModel GetModel(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" select * ");
            builder.Append(" from HEALTHHOUSE_OVERVIEW_SET ");
            builder.Append(" where 1=1 ");

            if(!string.IsNullOrEmpty(strWhere))
            {
                 builder.Append(strWhere);
            }
           
            DataSet set = MySQLHelper.Query(builder.ToString());
            if (set != null)
            {
                // 将DataTable转为List
                IList<HealthOverviewSetModel> list = CommonExtensions.DataTableToList<HealthOverviewSetModel>(set.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }
    }
}
