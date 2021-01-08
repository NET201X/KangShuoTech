using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.Model;
using MySql.Data.MySqlClient;
using System.Data;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    public class HealthHouseEcgDAL
    {
        public int Add(HealthHouseEcgModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_hhrecordsecg(");
            builder.Append("PID,MID,IDCardNo,Name,Conclusion,CreateTime,ECG,ECGEx,ImgPath) ");
            builder.Append("values( ");
            builder.Append("@PID,@MID,@IDCardNo,@Name,@Conclusion,@CreateTime,@ECG,@ECGEx,@ImgPath) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] {            
                new MySqlParameter("@PID", MySqlDbType.Int32, 11  ),  
                new MySqlParameter("@MID", MySqlDbType.String, 20  ),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 18  ),
                new MySqlParameter("@Name", MySqlDbType.String, 100 ),
                new MySqlParameter("@Conclusion", MySqlDbType.String, 9999),
                new MySqlParameter("@CreateTime", MySqlDbType.Date),
                new MySqlParameter("@ECG", MySqlDbType.String, 1   ),
                new MySqlParameter("@ECGEx", MySqlDbType.String, 100 ),
                new MySqlParameter("@ImgPath", MySqlDbType.String, 100 )
             };
            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.MID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.Conclusion;
            cmdParms[5].Value = model.CreateTime;
            cmdParms[6].Value = model.ECG;
            cmdParms[7].Value = model.ECGEx;
            cmdParms[8].Value = model.ImgPath;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public DataSet GetModel(int PID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" select * ");
            builder.Append(" from tbl_hhrecordsecg ");
            builder.Append(" where PID=@PID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@PID", PID)
            };

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return set;
            }

            return null;
        }
        
        /// <summary>
        /// 根据PID判断心电图资料是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsPID(string IDCardNo, int PID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_hhrecordsecg");
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

        public bool Update(HealthHouseEcgModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_hhrecordsecg set ");
            builder.Append("PID=@PID,");
            builder.Append("MID=@MID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Name=@Name,");
            builder.Append("Conclusion=@Conclusion,");
            builder.Append("CreateTime=@CreateTime,");
            builder.Append("ECG=@ECG,");
            builder.Append("ECGEx=@ECGEx,");
            builder.Append("ImgPath=@ImgPath   ");
            builder.Append("where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] {            
                new MySqlParameter("@PID", MySqlDbType.Int32, 11  ),  
                new MySqlParameter("@MID", MySqlDbType.String, 20  ),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 18  ),
                new MySqlParameter("@Name", MySqlDbType.String, 100 ),
                new MySqlParameter("@Conclusion", MySqlDbType.String, 9999),
                new MySqlParameter("@CreateTime", MySqlDbType.Date),
                new MySqlParameter("@ECG", MySqlDbType.String, 1   ),
                new MySqlParameter("@ECGEx", MySqlDbType.String, 100 ),
                new MySqlParameter("@ImgPath", MySqlDbType.String, 100 ),
                new MySqlParameter("@ID", MySqlDbType.Int32, 11  ),  
             };
            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.MID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.Conclusion;
            cmdParms[5].Value = model.CreateTime;
            cmdParms[6].Value = model.ECG;
            cmdParms[7].Value = model.ECGEx;
            cmdParms[8].Value = model.ImgPath;
            cmdParms[9].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
