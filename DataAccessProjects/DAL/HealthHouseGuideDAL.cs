using KangShuoTech.Utilities.SQLHelper;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;
using System;
using MySql.Data.MySqlClient;
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.DataAccessProjects.DAL
{
    public class HealthHouseGuideDAL
    {
        #region 健康指导

        /// <summary>
        /// 健康指导 根据身份证取得资料
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <returns></returns>
        public DataSet GetGuideData(string idCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"SELECT a.*
                                                ,b.CustomerName
                                                ,b.Sex
                                                ,b.Birthday
                                                ,c.CheckDate 
                                                FROM tbl_HHHealthGuid a
                                        LEFT JOIN tbl_recordsbaseinfo b
                                        ON  a.IDCardNo=b.IDCardNo
                                        LEFT JOIN tbl_recordscustomerbaseinfo c
                                        ON a.IDCardNo=c.IDCardNo
                                        WHERE a.IDCardNo=@IDCardNo");

            List<MySqlParameter> cmdParms = new List<MySqlParameter>();

            cmdParms.Add(new MySqlParameter("@IDCardNo", idCardNo));

            return MySQLHelper.Query(builder.ToString(), cmdParms.ToArray());
        }

        /// <summary>
        /// 健康指导 是否已存在
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <returns></returns>
        public bool ExistsPID(string idCardNo, int pId)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"SELECT Count(1)
                                                FROM tbl_HHHealthGuid a
                                        LEFT JOIN tbl_recordsbaseinfo b
                                        ON  a.IDCardNo=b.IDCardNo
                                        LEFT JOIN tbl_recordscustomerbaseinfo c
                                        ON a.IDCardNo=c.IDCardNo
                                        WHERE a.IDCardNo=@IDCardNo
                                        And a.PID=@PID ");

            List<MySqlParameter> cmdParms = new List<MySqlParameter>();

            cmdParms.Add(new MySqlParameter("@IDCardNo", idCardNo));
            cmdParms.Add(new MySqlParameter("@PID", pId));

            return MySQLHelper.Exists(builder.ToString(), cmdParms.ToArray());
        }

        /// <summary>
        /// 新增健康指导信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(HealthHouseGuideModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"INSERT INTO tbl_HHHealthGuid
                                                                                     (
                                                                                         PID
                                                                                        ,IDCardNo
                                                                                        ,Summary
                                                                                        ,HealthGuid
                                                                                        ,MedGuid
                                                                                        ,CreateDate
                                                                                        ,CreateBy
                                                                                        ,UpdateDate
                                                                                        ,UpdateBy
                                                                                    )
                                                                        VALUES
                                                                                     (
                                                                                         @PID
                                                                                        ,@IDCardNo
                                                                                        ,@Summary
                                                                                        ,@HealthGuid
                                                                                        ,@MedGuid
                                                                                        ,@CreateDate
                                                                                        ,@CreateBy
                                                                                        ,@UpdateDate
                                                                                        ,@UpdateBy
                                                                                     ) ");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@PID", MySqlDbType.Int32),
                 new MySqlParameter("@IDCardNo", MySqlDbType.String, 18),
                 new MySqlParameter("@Summary", MySqlDbType.String, 500),
                 new MySqlParameter("@HealthGuid", MySqlDbType.String, 500),
                 new MySqlParameter("@MedGuid", MySqlDbType.String,500),
                 new MySqlParameter("@CreateDate", MySqlDbType.Date),
                 new MySqlParameter("@CreateBy", MySqlDbType.String, 100),
                 new MySqlParameter("@UpdateDate", MySqlDbType.Date),
                 new MySqlParameter("@UpdateBy", MySqlDbType.String, 100)
            };

            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Summary;
            cmdParms[3].Value = model.HealthGuid;
            cmdParms[4].Value = model.MedGuid;
            cmdParms[5].Value = model.CreateDate;
            cmdParms[6].Value = model.CreateBy;
            cmdParms[7].Value = model.UpdateDate;
            cmdParms[8].Value = model.UpdateBy;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 修改健康指导信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(HealthHouseGuideModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@" UPDATE tbl_HHHealthGuid
                                    SET
                                         Summary=@Summary
                                        ,HealthGuid = @HealthGuid 
                                        ,MedGuid = @MedGuid 
                                        ,UpdateDate=@UpdateDate
                                        ,UpdateBy=@UpdateBy
                                    WHERE ID=@ID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@ID", MySqlDbType.Int32),
                 new MySqlParameter("@Summary", MySqlDbType.String, 500),
                 new MySqlParameter("@HealthGuid", MySqlDbType.String, 500),
                 new MySqlParameter("@MedGuid", MySqlDbType.String, 500),
                 new MySqlParameter("@UpdateDate", MySqlDbType.Date),
                 new MySqlParameter("@UpdateBy", MySqlDbType.String, 100)
            };

            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Summary;
            cmdParms[2].Value = model.HealthGuid;
            cmdParms[3].Value = model.MedGuid;
            cmdParms[4].Value = model.UpdateDate;
            cmdParms[5].Value = model.UpdateBy;

            object single = MySQLHelper.ExecuteSql(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        #endregion

        #region 健康指导查询

        /// <summary>
        /// 查询健康指导信息总笔数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetHealthGuideRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"SELECT COUNT(*)
                                        FROM tbl_hhhealthguid a
                                        LEFT JOIN tbl_recordscustomerbaseinfo b
                                        ON a.IDCardNo=b.IDCardNo
                                        LEFT JOIN tbl_recordsbaseinfo c
                                        ON a.IDCardNo=c.IDCardNo");

            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(" Where 1=1 " + strWhere);
            }

            object single = MySQLHelper.GetSingle(builder.ToString());

            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 查询健康指导信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetHealthGuideListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"SELECT  a.ID
                                                    ,a.PID
                                                    ,c.CustomerName
                                                    ,c.Sex
                                                    ,c.HouseHoldAddress
                                                    ,c.IDCardNo
                                                    ,a.Summary
                                                    ,a.HealthGuid
                                                    ,a.MedGuid
                                                    ,a.CreateBy
                                                    ,c.CreateMenName
                                                    ,a.CreateDate
                                                    ,b.CheckDate 
                                        FROM tbl_hhhealthguid a
                                        LEFT JOIN tbl_recordscustomerbaseinfo b
                                        ON a.IDCardNo=b.IDCardNo
                                        LEFT JOIN tbl_recordsbaseinfo c
                                        ON a.IDCardNo=c.IDCardNo");

            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(" Where 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby))
            {
                builder.Append(" order by " + orderby);
            }
            else
            {
                builder.Append("order by a.ID DESC");
            }

            builder.Append(string.Format(" limit {0},{1} ", startIndex, endIndex));

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 获取健康指导 - 根据身份证号
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <returns></returns>
        public HealthHouseGuideModel GetHealthGuideByIdCardNo(int ID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"SELECT b.CustomerName
				                                    ,b.Sex
				                                    ,b.Birthday
				                                    ,c.CheckDate
				                                    ,a.Summary
				                                    ,a.HealthGuid
				                                    ,a.MedGuid 
                                    FROM tbl_HHHealthGuid a
                                    LEFT JOIN tbl_recordsbaseinfo b
                                    ON a.IDCardNo=b.IDCardNo
                                    LEFT JOIN tbl_recordscustomerbaseinfo c
                                    ON a.IDCardNo=c.IDCardNo
                                    Where a.ID=@ID");

            List<MySqlParameter> cmdParms = new List<MySqlParameter>();
            cmdParms.Add(new MySqlParameter("@ID", ID));

            DataSet ds = MySQLHelper.Query(builder.ToString(), cmdParms.ToArray());

            if (ds != null)
            {
                IList<HealthHouseGuideModel> list = CommonExtensions.DataTableToList<HealthHouseGuideModel>(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// 删除健康指导信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_HHHealthGuid ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        #endregion
    }
}
