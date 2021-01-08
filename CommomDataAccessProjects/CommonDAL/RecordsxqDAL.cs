using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommonUtilities.SQL;
using System;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsxqDAL
    {
        public int AddRow(DataModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_recordsxq ( ");
            builder.Append(" IDCardNo,NEU_B,LYMPH_B,MON_B,EOS_B,BAS_B,NEU_N,LYMPH_N,MON_N,EOS_N,BAS_N,");
            builder.Append(" RBC,HCT,MCV,MCH,MCHC,RDW_CV,RDW_SD,MPV,PDW,PCT,TestTime,MID_B,MID_N,P_LCR,");
            builder.Append(" CL,CA,ASTALT,HLR_B,HLR_N,ALY_B,ALY_N,P_LCC");

            string table = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'tbl_recordsxq' AND TABLE_SCHEMA='qcpaddb' AND COLUMN_NAME='NRBC_N'";

            object single = MySQLHelper.GetSingle(table);
            int count = 0;

            if (single != null) count = int.Parse(single.ToString());

            if (count > 0) builder.Append(",NRBC_N,NRBC_B,HGB");

            builder.Append(" )VALUES (");
            builder.Append(" @IDCardNo,@NEU_B,@LYMPH_B,@MON_B,@EOS_B,@BAS_B,@NEU_N,@LYMPH_N,@MON_N,@EOS_N,");
            builder.Append(" @BAS_N,@RBC,@HCT,@MCV,@MCH,@MCHC,@RDW_CV,@RDW_SD,@MPV,@PDW,@PCT,");
            builder.Append(" @TestTime,@MID_B,@MID_N,@P_LCR,@CL,@CA,@ASTALT,@HLR_B,@HLR_N,@ALY_B,@ALY_N,@P_LCC");

            if (count > 0) builder.Append(",@NRBC_N,@NRBC_B,@HGB");

            builder.Append(");SELECT @@IDENTITY");

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
                new MySqlParameter("@P_LCR",MySqlDbType.String),
                new MySqlParameter("@CL",MySqlDbType.String),
                new MySqlParameter("@CA",MySqlDbType.String),
                new MySqlParameter("@ASTALT",MySqlDbType.String),
                new MySqlParameter("@HLR_B",MySqlDbType.String),
                new MySqlParameter("@HLR_N",MySqlDbType.String),
                new MySqlParameter("@ALY_B",MySqlDbType.String),
                new MySqlParameter("@ALY_N",MySqlDbType.String),
                new MySqlParameter("@P_LCC",MySqlDbType.String),
                new MySqlParameter("@NRBC_N",MySqlDbType.String),
                new MySqlParameter("@NRBC_B",MySqlDbType.String),
                new MySqlParameter("@HGB",MySqlDbType.String)
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
            cmdParms[35].Value = model.CL;
            cmdParms[36].Value = model.CA;
            cmdParms[37].Value = model.ASTALT;
            cmdParms[38].Value = model.HLR_B;
            cmdParms[39].Value = model.HLR_N;
            cmdParms[40].Value = model.ALY_B;
            cmdParms[41].Value = model.ALY_N;
            cmdParms[42].Value = model.P_LCC;
            cmdParms[43].Value = model.NRBC_N;
            cmdParms[44].Value = model.NRBC_B;
            cmdParms[45].Value = model.HGB;

            single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public int AddRowNew(DataModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_recordsxq ( ");
            builder.Append(" NEU_B,LYMPH_B,MON_B,EOS_B,BAS_B,NEU_N,LYMPH_N,MON_N,EOS_N,BAS_N,");
            builder.Append(" RBC,HCT,MCV,MCH,MCHC,RDW_CV,RDW_SD,MPV,PDW,PCT,TestTime,MID_B,MID_N,P_LCR,");
            builder.Append(" CL,CA,ASTALT,HLR_B,HLR_N,ALY_B,ALY_N,P_LCC,IDCardNo");

            string table = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'tbl_recordsxq' AND TABLE_SCHEMA='qcpaddb' AND COLUMN_NAME='BarCode'";

            object single = MySQLHelper.GetSingle(table);
            int count = 0;

            if (single != null) count = int.Parse(single.ToString());

            if (count > 0) builder.Append(",BarCode ");

            table = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'tbl_recordsxq' AND TABLE_SCHEMA='qcpaddb' AND COLUMN_NAME='NRBC_N'";

            single = MySQLHelper.GetSingle(table);
            count = 0;

            if (single != null) count = int.Parse(single.ToString());

            if (count > 0) builder.Append(",NRBC_N,NRBC_B,HGB");

            builder.Append(" )VALUES (");
            builder.Append(" @NEU_B,@LYMPH_B,@MON_B,@EOS_B,@BAS_B,@NEU_N,@LYMPH_N,@MON_N,@EOS_N,");
            builder.Append(" @BAS_N,@RBC,@HCT,@MCV,@MCH,@MCHC,@RDW_CV,@RDW_SD,@MPV,@PDW,@PCT,");
            builder.Append(" @TestTime,@MID_B,@MID_N,@P_LCR,@CL,@CA,@ASTALT,@HLR_B,@HLR_N,@ALY_B,@ALY_N,@P_LCC, ");

            if (count > 0)
            {
                builder.Append("(SELECT IDCardNo FROM tbl_RecordsCustomerBaseInfo WHERE CustomerID=@BarCode ORDER BY CheckDate DESC LIMIT 0,1) ");
                builder.Append(",@BarCode ");
            }
            else builder.Append("@IDCardNo ");

            if (count > 0) builder.Append(",@NRBC_N,@NRBC_B,@HGB");

            builder.Append(");SELECT @@IDENTITY");

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
                new MySqlParameter("@P_LCR",MySqlDbType.String),
                new MySqlParameter("@CL",MySqlDbType.String),
                new MySqlParameter("@CA",MySqlDbType.String),
                new MySqlParameter("@ASTALT",MySqlDbType.String),
                new MySqlParameter("@HLR_B",MySqlDbType.String),
                new MySqlParameter("@HLR_N",MySqlDbType.String),
                new MySqlParameter("@ALY_B",MySqlDbType.String),
                new MySqlParameter("@ALY_N",MySqlDbType.String),
                new MySqlParameter("@BarCode", MySqlDbType.String),
                new MySqlParameter("@P_LCC", MySqlDbType.String),
                new MySqlParameter("@NRBC_N",MySqlDbType.String),
                new MySqlParameter("@NRBC_B",MySqlDbType.String),
                new MySqlParameter("@HGB",MySqlDbType.String)
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
            cmdParms[35].Value = model.CL;
            cmdParms[36].Value = model.CA;
            cmdParms[37].Value = model.ASTALT;
            cmdParms[38].Value = model.HLR_B;
            cmdParms[39].Value = model.HLR_N;
            cmdParms[40].Value = model.ALY_B;
            cmdParms[41].Value = model.ALY_N;
            cmdParms[42].Value = model.BarCode;
            cmdParms[43].Value = model.P_LCC;
            cmdParms[43].Value = model.NRBC_N;
            cmdParms[44].Value = model.NRBC_B;
            cmdParms[45].Value = model.HGB;

            single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetData(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_RecordsXQ ");

            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(" WHERE " + strWhere);
            }

            return MySQLHelper.Query(builder.ToString());
        }
    }
}
