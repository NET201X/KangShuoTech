using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class HealthGuidanceBussiness
    {
        /// <summary>
        /// 添加建议指导
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(HealthGuidanceModel model)
        {
            string sql = @"INSERT INTO tbl_HealthGuidance
                            ( 
                                GreaterThanRecom
                                ,LessThanRecom
                                ,MiddleThanRecom
                                ,Title
                                ,Code
                                ,Sex
                                ,Type
                            ) 
                            VALUES 
                            ( 
                                @GreaterThanRecom
                                ,@LessThanRecom
                                ,@MiddleThanRecom
                                ,@Title
                                ,@Code
                                ,@Sex
                                ,@Type
                            )";

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@GreaterThanRecom", MySqlDbType.Text),
                 new MySqlParameter("@LessThanRecom", MySqlDbType.Text),
                 new MySqlParameter("@MiddleThanRecom", MySqlDbType.Text),
                 new MySqlParameter("@Title", MySqlDbType.String, 50),
                 new MySqlParameter("@Code",MySqlDbType.String,50),
                 new MySqlParameter("@Sex",MySqlDbType.String,1),
                 new MySqlParameter("@Type",MySqlDbType.Int32)
            };

            cmdParms[0].Value = model.GreaterThanRecom;
            cmdParms[1].Value = model.LessThanRecom;
            cmdParms[2].Value = model.MiddleThanRecom;
            cmdParms[3].Value = model.Title;
            cmdParms[4].Value = model.Code;
            cmdParms[5].Value = model.Sex;
            cmdParms[6].Value = model.Type;

            return MySQLHelper.ExecuteSql(sql, cmdParms);
        }

        /// <summary>
        /// 修改建议指导
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(HealthGuidanceModel model)
        {
            string sql = @"UPDATE tbl_HealthGuidance 
                            SET 
                                GreaterThanRecom = @GreaterThanRecom 
                                ,LessThanRecom = @LessThanRecom 
                                ,MiddleThanRecom = @MiddleThanRecom 
                                ,Title = @Title 
                                ,Code=@Code
                                ,Sex=@Sex
                                ,Type=@Type
                            WHERE ID = @ID";

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@ID", MySqlDbType.Int32),
                 new MySqlParameter("@GreaterThanRecom", MySqlDbType.Text),
                 new MySqlParameter("@LessThanRecom", MySqlDbType.Text),
                 new MySqlParameter("@MiddleThanRecom", MySqlDbType.Text),
                 new MySqlParameter("@Title", MySqlDbType.String, 50),
                 new MySqlParameter("@Code",MySqlDbType.String,50),
                 new MySqlParameter("@Sex",MySqlDbType.String,1),
                 new MySqlParameter("@Type",MySqlDbType.Int32)
            };

            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.GreaterThanRecom;
            cmdParms[2].Value = model.LessThanRecom;
            cmdParms[3].Value = model.MiddleThanRecom;
            cmdParms[4].Value = model.Title;
            cmdParms[5].Value = model.Code;
            cmdParms[5].Value = model.Sex;
            cmdParms[6].Value = model.Type;

            return MySQLHelper.ExecuteSql(sql, cmdParms);
        }

        public int UpdateID(string id, string GuidanceId)
        {
            string sql = "UPDATE tbl_HealthGuidance SET GuidanceId=@GuidanceId WHERE id=@id";

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@ID", id),
                 new MySqlParameter("@GuidanceId", GuidanceId)
            };

            return MySQLHelper.ExecuteSql(sql, cmdParms);
        }

        public int GetNum(string id)
        {
            string sql = "SELECT COUNT(*) AS num FROM tbl_HealthGuidance WHERE (GuidanceId IS NOT NULL AND GuidanceId!='') AND id=" + id;

            return Int32.Parse(MySQLHelper.GetDataTable(sql).Rows[0]["num"].ToString());
        }

        /// <summary>
        /// 删除建议指导
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            string sql = "DELETE FROM tbl_HealthGuidance WHERE id=" + id;

            return MySQLHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除建议指导
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DeleteWhere(string where)
        {
            string sql = $"DELETE FROM tbl_HealthGuidance WHERE 1=1 {where}";

            return MySQLHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 根据主键获取健康指导
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetInfo(string id)
        {
            string sql = "SELECT * FROM tbl_HealthGuidance WHERE id=" + id;

            return MySQLHelper.GetDataTable(sql);
        }

        /// <summary>
        /// 获取健康指导列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetListInfo()
        {
            string sql = "SELECT id,title AS 标题,GuidanceId FROM tbl_HealthGuidance";

            return MySQLHelper.GetDataTable(sql);
        }

        public DataTable GetInfoGui(string GuidanceId)
        {
            string sql = "SELECT * FROM tbl_HealthGuidance WHERE GuidanceId=" + GuidanceId;

            return MySQLHelper.GetDataTable(sql);
        }

        public DataSet GetModelList(string where)
        {
            string sql = "SELECT * FROM tbl_HealthGuidance WHERE 1=1 " + where;

            return MySQLHelper.Query(sql);
        }
    }
}
