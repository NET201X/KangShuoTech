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
    public class RecordsxqDAL
    {
        public int AddRow(DataModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_recordsxq ( ");
            builder.Append(" IDCardNo,NEU_B,LYMPH_B,MON_B,EOS_B,BAS_B,NEU_N,LYMPH_N,MON_N,EOS_N,BAS_N,");
            builder.Append(" RBC,HCT,MCV,MCH,MCHC,RDW_CV,RDW_SD,MPV,PDW,PCT,TestTime,MID_B,MID_N,P_LCR )");
            builder.Append(" VALUES (");
            builder.Append(" @IDCardNo,@NEU_B,@LYMPH_B,@MON_B,@EOS_B,@BAS_B,@NEU_N,@LYMPH_N,@MON_N,@EOS_N,");
            builder.Append(" @BAS_N,@RBC,@HCT,@MCV,@MCH,@MCHC,@RDW_CV,@RDW_SD,@MPV,@PDW,@PCT,");
            builder.Append(" @TestTime,@MID_B,@MID_N,@P_LCR )");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@NEU_B", MySqlDbType.String),
                new MySqlParameter("@LYMPH_B", MySqlDbType.String),
                new MySqlParameter("@MON_B", MySqlDbType.String),
                new MySqlParameter("@EOS_B", MySqlDbType.String),
                new MySqlParameter("@BAS_B", MySqlDbType.String),
                new MySqlParameter("@NEU_N", MySqlDbType.String),
                new MySqlParameter("@LYMPH_N", MySqlDbType.String),
                new MySqlParameter("@MON_N", MySqlDbType.String),
                new MySqlParameter("@EOS_N", MySqlDbType.String),
                new MySqlParameter("@BAS_N", MySqlDbType.String),
                new MySqlParameter("@RBC", MySqlDbType.String),
                new MySqlParameter("@HCT", MySqlDbType.String),
                new MySqlParameter("@MCV", MySqlDbType.String),
                new MySqlParameter("@MCH", MySqlDbType.String),
                new MySqlParameter("@MCHC", MySqlDbType.String),
                new MySqlParameter("@RDW_CV", MySqlDbType.String),
                new MySqlParameter("@RDW_SD", MySqlDbType.String),
                new MySqlParameter("@MPV", MySqlDbType.String),
                new MySqlParameter("@PDW", MySqlDbType.String),
                new MySqlParameter("@PCT", MySqlDbType.String),
                new MySqlParameter("@TBIL", MySqlDbType.String),
                new MySqlParameter("@GOT", MySqlDbType.String),
                new MySqlParameter("@SGPT", MySqlDbType.String),
                new MySqlParameter("@TC", MySqlDbType.String),
                new MySqlParameter("@TG", MySqlDbType.String),
                new MySqlParameter("@LDL_C", MySqlDbType.String),
                new MySqlParameter("@HDL_C", MySqlDbType.String),
                new MySqlParameter("@SCR", MySqlDbType.String),
                new MySqlParameter("@BUN", MySqlDbType.String),
                new MySqlParameter("@FPGL", MySqlDbType.String),
                new MySqlParameter("@TestTime", MySqlDbType.Date),
                new MySqlParameter("@MID_B",MySqlDbType.String),
                new MySqlParameter("@MID_N",MySqlDbType.String),
                new MySqlParameter("@P_LCR",MySqlDbType.String)
            };

            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.NEU_B;
            cmdParms[2].Value = model.LYMPH_B;
            cmdParms[3].Value = model.MON_B;
            cmdParms[4].Value = model.EOS_B;
            cmdParms[5].Value = model.BAS_B;
            cmdParms[6].Value = model.NEU_N;
            cmdParms[7].Value = model.LYMPH_N;
            cmdParms[8].Value = model.MON_N;
            cmdParms[9].Value = model.EOS_N;
            cmdParms[10].Value = model.BAS_N;
            cmdParms[11].Value = model.RBC;
            cmdParms[12].Value = model.HCT;
            cmdParms[13].Value = model.MCV;
            cmdParms[14].Value = model.MCH;
            cmdParms[15].Value = model.MCHC;
            cmdParms[16].Value = model.RDW_CV;
            cmdParms[17].Value = model.RDW_SD;
            cmdParms[18].Value = model.MPV;
            cmdParms[19].Value = model.PDW;
            cmdParms[20].Value = model.PCT;
            cmdParms[21].Value = model.TBIL;
            cmdParms[22].Value = model.GOT;
            cmdParms[23].Value = model.SGPT;
            cmdParms[24].Value = model.TC;
            cmdParms[25].Value = model.TG;
            cmdParms[26].Value = model.LDL_C;
            cmdParms[27].Value = model.HDL_C;
            cmdParms[28].Value = model.SCR;
            cmdParms[29].Value = model.BUN;
            cmdParms[30].Value = model.FPGL;
            cmdParms[31].Value = model.TestTime;
            cmdParms[32].Value = model.MID_B;
            cmdParms[33].Value = model.MID_N;
            cmdParms[34].Value = model.P_LCR;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetDT(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from tbl_recordsxq ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }
    }
}
