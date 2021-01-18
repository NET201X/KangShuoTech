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
    public class HealthHousePhysicalAssistCheckDAL
    {
        public int Add(HealthHousePhysicalAssistCheckModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("insert into HEALTHHOUSE_PHYSICAL_ASSIST_CHECK(");
            builder.Append("IDCardNo,PRO,GLU,KET,BLD,UBG,BIL,PH,NIT,LEU,SG,VC,");
            builder.Append("CHESTX,CHESTXEx,PID)");
            builder.Append("values(");
            builder.Append("@IDCardNo,@PRO,@GLU,@KET,@BLD,@UBG,@BIL,@PH,@NIT,@LEU,@SG,@VC,");
            builder.Append("@CHESTX,@CHESTXEx,@PID)");
            builder.Append(";select @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {            
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),  
                new MySqlParameter("@PRO", MySqlDbType.String, 100),  
                new MySqlParameter("@GLU", MySqlDbType.String, 100),  
                new MySqlParameter("@KET", MySqlDbType.String, 100),  
                new MySqlParameter("@BLD", MySqlDbType.String, 100),  
                new MySqlParameter("@UBG", MySqlDbType.String, 100),  
                new MySqlParameter("@BIL", MySqlDbType.String, 100),  
                new MySqlParameter("@PH", MySqlDbType.String, 100),  
                new MySqlParameter("@NIT", MySqlDbType.String, 100),  
                new MySqlParameter("@LEU", MySqlDbType.String, 100),  
                new MySqlParameter("@SG", MySqlDbType.String, 100),  
                new MySqlParameter("@VC", MySqlDbType.String, 100),  
                new MySqlParameter("@CHESTX", MySqlDbType.String, 1), 
                new MySqlParameter("@CHESTXEx", MySqlDbType.String, 100),  
                new MySqlParameter("@PID", MySqlDbType.String, 21)
            };

            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.PRO;
            cmdParms[2].Value = model.GLU;
            cmdParms[3].Value = model.KET;
            cmdParms[4].Value = model.BLD;
            cmdParms[5].Value = model.UBG;
            cmdParms[6].Value = model.BIL;
            cmdParms[7].Value = model.PH;
            cmdParms[8].Value = model.NIT;
            cmdParms[9].Value = model.LEU;
            cmdParms[10].Value = model.SG;
            cmdParms[11].Value = model.VC;
            cmdParms[12].Value = model.CHESTX;
            cmdParms[13].Value = model.CHESTXEx;
            cmdParms[14].Value = model.PID;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetModel(int PID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" select * ");
            builder.Append(" from HEALTHHOUSE_PHYSICAL_ASSIST_CHECK ");
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

        public bool Update(HealthHousePhysicalAssistCheckModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("update HEALTHHOUSE_PHYSICAL_ASSIST_CHECK set ");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("PRO=@PRO,");
            builder.Append("GLU=@GLU,");
            builder.Append("KET=@KET,");
            builder.Append("BLD=@BLD,");
            builder.Append("UBG=@UBG,");
            builder.Append("BIL=@BIL,");
            builder.Append("PH=@PH,");
            builder.Append("NIT=@NIT,");
            builder.Append("LEU=@LEU,");
            builder.Append("SG=@SG,");
            builder.Append("VC=@VC,");
            builder.Append("CHESTX=@CHESTX,");
            builder.Append("CHESTXEx=@CHESTXEx,");
            builder.Append("PID=@PID ");
            builder.Append(" where ID=@ID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {            
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),  
                new MySqlParameter("@PRO", MySqlDbType.String, 100),  
                new MySqlParameter("@GLU", MySqlDbType.String, 100),  
                new MySqlParameter("@KET", MySqlDbType.String, 100),  
                new MySqlParameter("@BLD", MySqlDbType.String, 100),  
                new MySqlParameter("@UBG", MySqlDbType.String, 100),  
                new MySqlParameter("@BIL", MySqlDbType.String, 100),  
                new MySqlParameter("@PH", MySqlDbType.String, 100),  
                new MySqlParameter("@NIT", MySqlDbType.String, 100),  
                new MySqlParameter("@LEU", MySqlDbType.String, 100),  
                new MySqlParameter("@SG", MySqlDbType.String, 100),  
                new MySqlParameter("@VC", MySqlDbType.String, 100),  
                new MySqlParameter("@CHESTX", MySqlDbType.String, 1), 
                new MySqlParameter("@CHESTXEx", MySqlDbType.String, 100),  
                new MySqlParameter("@PID", MySqlDbType.String, 21),
                new MySqlParameter("@ID",MySqlDbType.Int32,11)
            };

            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.PRO;
            cmdParms[2].Value = model.GLU;
            cmdParms[3].Value = model.KET;
            cmdParms[4].Value = model.BLD;
            cmdParms[5].Value = model.UBG;
            cmdParms[6].Value = model.BIL;
            cmdParms[7].Value = model.PH;
            cmdParms[8].Value = model.NIT;
            cmdParms[9].Value = model.LEU;
            cmdParms[10].Value = model.SG;
            cmdParms[11].Value = model.VC;
            cmdParms[12].Value = model.CHESTX;
            cmdParms[13].Value = model.CHESTXEx;
            cmdParms[14].Value = model.PID;
            cmdParms[15].Value = model.ID;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool ExistsPID(string IDCardNo, int PID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("select count(1) from HEALTHHOUSE_PHYSICAL_ASSIST_CHECK");
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
    }
}
