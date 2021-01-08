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
    public class HealthAssessDAL
    {
        public int Add(HealthAssessModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" insert into tbl_hhhealthassess(");
            builder.Append("PID,IDCardNo,BasicTest,Blood,PulseRate,Oxygen,Urine,ChestX,BSuper,ECG,Cardiovascular,Lung,Bone,TCMConstitution,Overview,CreateDate,CreateBy,UpdateDate,UpdataBy,CheckDate)");
            builder.Append(" values( ");
            builder.Append("@PID,@IDCardNo,@BasicTest,@Blood,@PulseRate,@Oxygen,@Urine,@ChestX,@BSuper,@ECG,@Cardiovascular,@Lung,@Bone,@TCMConstitution,@Overview,@CreateDate,@CreateBy,@UpdateDate,@UpdataBy,@CheckDate)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                    new MySqlParameter("@PID",MySqlDbType.Int32),
                    new MySqlParameter("@IDCardNo",MySqlDbType.String),
                    new MySqlParameter("@BasicTest",MySqlDbType.String),
                    new MySqlParameter("@Blood",MySqlDbType.String),
                    new MySqlParameter("@PulseRate",MySqlDbType.String),
                    new MySqlParameter("@Oxygen",MySqlDbType.String),
                    new MySqlParameter("@Urine",MySqlDbType.String),
                    new MySqlParameter("@ChestX",MySqlDbType.String),
                    new MySqlParameter("@BSuper",MySqlDbType.String),
                    new MySqlParameter("@ECG",MySqlDbType.String),
                    new MySqlParameter("@Cardiovascular",MySqlDbType.String),
                    new MySqlParameter("@Lung",MySqlDbType.String),
                    new MySqlParameter("@Bone",MySqlDbType.String),
                    new MySqlParameter("@TCMConstitution",MySqlDbType.String),
                    new MySqlParameter("@Overview",MySqlDbType.String),
                    new MySqlParameter("@CreateDate",MySqlDbType.Date),
                    new MySqlParameter("@CreateBy",MySqlDbType.String),
                    new MySqlParameter("@UpdateDate",MySqlDbType.Date),
                    new MySqlParameter("@UpdataBy",MySqlDbType.String),
                    new MySqlParameter("@CheckDate",MySqlDbType.Date)
                    };
            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.BasicTest;
            cmdParms[3].Value = model.Blood;
            cmdParms[4].Value = model.PulseRate;
            cmdParms[5].Value = model.Oxygen;
            cmdParms[6].Value = model.Urine;
            cmdParms[7].Value = model.ChestX;
            cmdParms[8].Value = model.BSuper;
            cmdParms[9].Value = model.ECG;
            cmdParms[10].Value = model.Cardiovascular;
            cmdParms[11].Value = model.Lung;
            cmdParms[12].Value = model.Bone;
            cmdParms[13].Value = model.TCMConstitution;
            cmdParms[14].Value = model.Overview;
            cmdParms[15].Value = model.CreateDate;
            cmdParms[16].Value = model.CreateBy;
            cmdParms[17].Value = model.UpdateDate;
            cmdParms[18].Value = model.UpdataBy;
            cmdParms[19].Value = model.CheckDate;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public HealthAssessModel GetModel(int PID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" select * ");
            builder.Append(" from tbl_hhhealthassess ");
            builder.Append(" where PID=@PID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@PID", PID)
            };
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set != null)
            {
                // 将DataTable转为List
                IList<HealthAssessModel> list = CommonExtensions.DataTableToList<HealthAssessModel>(set.Tables[0]);

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
            builder.Append("select count(1) from tbl_hhhealthassess");
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
        public bool Update(HealthAssessModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" update tbl_hhhealthassess set ");
            builder.Append("PID=@PID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("BasicTest=@BasicTest,");
            builder.Append("Blood=@Blood,");
            builder.Append("PulseRate=@PulseRate,");
            builder.Append("Oxygen=@Oxygen,");
            builder.Append("Urine=@Urine,");
            builder.Append("ChestX=@ChestX,");
            builder.Append("BSuper=@BSuper,");
            builder.Append("ECG=@ECG,");
            builder.Append("Cardiovascular=@Cardiovascular,");
            builder.Append("Lung=@Lung,");
            builder.Append("Bone=@Bone,");
            builder.Append("TCMConstitution=@TCMConstitution,");
            builder.Append("Overview=@Overview,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("CreateBy=@CreateBy,");
            builder.Append("UpdateDate=@UpdateDate,");
            builder.Append("UpdataBy=@UpdataBy,");
            builder.Append("CheckDate=@CheckDate");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                    new MySqlParameter("@PID",MySqlDbType.Int32),
                    new MySqlParameter("@IDCardNo",MySqlDbType.String),
                    new MySqlParameter("@BasicTest",MySqlDbType.String),
                    new MySqlParameter("@Blood",MySqlDbType.String),
                    new MySqlParameter("@PulseRate",MySqlDbType.String),
                    new MySqlParameter("@Oxygen",MySqlDbType.String),
                    new MySqlParameter("@Urine",MySqlDbType.String),
                    new MySqlParameter("@ChestX",MySqlDbType.String),
                    new MySqlParameter("@BSuper",MySqlDbType.String),
                    new MySqlParameter("@ECG",MySqlDbType.String),
                    new MySqlParameter("@Cardiovascular",MySqlDbType.String),
                    new MySqlParameter("@Lung",MySqlDbType.String),
                    new MySqlParameter("@Bone",MySqlDbType.String),
                    new MySqlParameter("@TCMConstitution",MySqlDbType.String),
                    new MySqlParameter("@Overview",MySqlDbType.String),
                    new MySqlParameter("@CreateDate",MySqlDbType.Date),
                    new MySqlParameter("@CreateBy",MySqlDbType.String),
                    new MySqlParameter("@UpdateDate",MySqlDbType.Date),
                    new MySqlParameter("@UpdataBy",MySqlDbType.String),
                    new MySqlParameter("@CheckDate",MySqlDbType.Date),
                    new MySqlParameter("@ID",MySqlDbType.Int32)
                    
                    };
            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.BasicTest;
            cmdParms[3].Value = model.Blood;
            cmdParms[4].Value = model.PulseRate;
            cmdParms[5].Value = model.Oxygen;
            cmdParms[6].Value = model.Urine;
            cmdParms[7].Value = model.ChestX;
            cmdParms[8].Value = model.BSuper;
            cmdParms[9].Value = model.ECG;
            cmdParms[10].Value = model.Cardiovascular;
            cmdParms[11].Value = model.Lung;
            cmdParms[12].Value = model.Bone;
            cmdParms[13].Value = model.TCMConstitution;
            cmdParms[14].Value = model.Overview;
            cmdParms[15].Value = model.CreateDate;
            cmdParms[16].Value = model.CreateBy;
            cmdParms[17].Value = model.UpdateDate;
            cmdParms[18].Value = model.UpdataBy;
            cmdParms[19].Value = model.CheckDate;
            cmdParms[20].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
