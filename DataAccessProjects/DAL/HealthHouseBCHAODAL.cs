using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.Model;
using MySql.Data.MySqlClient;
using KangShuoTech.Utilities.MySQLHelper;
using System.Data;

namespace KangShuoTech.DataAccessProjects.DAL
{
    public class HealthHouseBCHAODAL
    {
        public int Add(HealthHouseBCHAOModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"INSERT INTO HEALTHHOUSE_ULTRASONICB_RESULT
                                    ( 
                                        ID
                                        ,PID
                                        ,IDCardNo
                                        ,BCHAO
                                        ,BCHAOEx
                                        ,BCHAOther
                                        ,BCHAOtherEx
                                        ,ImgPath
                                    ) 
                                    VALUES 
                                     ( 
                                         @ID
                                        ,@PID
                                        ,@IDCardNo
                                        ,@BCHAO
                                        ,@BCHAOEx
                                        ,@BCHAOther
                                        ,@BCHAOtherEx
                                        ,@ImgPath
                                     ) ");

            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@ID", MySqlDbType.String, 32), 
                new MySqlParameter("@PID", MySqlDbType.String, 32), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 50), 
                new MySqlParameter("@BCHAO", MySqlDbType.String, 255), 
                new MySqlParameter("@BCHAOEx", MySqlDbType.String, 100), 
                new MySqlParameter("@BCHAOther", MySqlDbType.Int32 ), 
                new MySqlParameter("@BCHAOtherEx", MySqlDbType.String, 32), 
                new MySqlParameter("@ImgPath", MySqlDbType.DateTime), 
            };

            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.PID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.BCHAO;
            cmdParms[4].Value = model.BCHAOEx;
            cmdParms[5].Value = model.BCHAOther;
            cmdParms[6].Value = model.BCHAOtherEx;
            cmdParms[7].Value = model.ImgPath;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetModel(int PID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" select * ");
            builder.Append(" from HEALTHHOUSE_ULTRASONICB_RESULT ");
            builder.Append(" where PID=@PID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@PID", PID)
            };

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            return set;
        }

        /// <summary>
        /// 根据PID判断心电图资料是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsPID(string IDCardNo, int PID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from HEALTHHOUSE_ULTRASONICB_RESULT");
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
        public bool Update(HealthHouseBCHAOModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"UPDATE HEALTHHOUSE_ULTRASONICB_RESULT 
                                     SET 
                                         PID = @PID 
                                        ,IDCardNo = @IDCardNo 
                                        ,BCHAO = @BCHAO 
                                        ,BCHAOEx = @BCHAOEx 
                                        ,BCHAOther = @BCHAOther 
                                        ,BCHAOtherEx = @BCHAOtherEx 
                                        ,ImgPath = @ImgPath 
                                      WHERE ID = @ID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@ID", MySqlDbType.Int32), 
                new MySqlParameter("@PID", MySqlDbType.String, 32), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 50), 
                new MySqlParameter("@BCHAO", MySqlDbType.String, 255), 
                new MySqlParameter("@BCHAOEx", MySqlDbType.String, 100), 
                new MySqlParameter("@BCHAOther", MySqlDbType.Int32), 
                new MySqlParameter("@BCHAOtherEx", MySqlDbType.String, 32), 
                new MySqlParameter("@ImgPath", MySqlDbType.String), 
            };

            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.PID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.BCHAO;
            cmdParms[4].Value = model.BCHAOEx;
            cmdParms[5].Value = model.BCHAOther;
            cmdParms[6].Value = model.BCHAOtherEx;
            cmdParms[7].Value = model.ImgPath;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
