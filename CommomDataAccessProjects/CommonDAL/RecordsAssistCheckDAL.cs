using CommomUtilities.Common;
using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsAssistCheckDAL
    {
        string versionNo = ConfigHelper.GetSetNode("versionNo");

        // 区域
        string area = ConfigHelper.GetSetNode("area");

        // 医院名称
        string community = ConfigHelper.GetSetNode("community");

        public int Add(RecordsAssistCheckModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO ARCHIVE_ASSISTCHECK(");
            builder.Append("PhysicalID,IDCardNo,HB,WBC,PLT,PRO,GLU,KET,BLD,FPGL,ECG,ALBUMIN,FOB,HBALC,HBSAG,SGPT,GOT,BP,TBIL,CB,SCR,BUN,PC,HYPE,TC,TG,LowCho,HeiCho,");
            builder.Append("CHESTX,BCHAO,BloodOther,UrineOther,Other,CERVIX,GT,ECGEx,CHESTXEx,BCHAOEx,CERVIXEx,FPGDL,OutKey,UA,BCHAOther,BCHAOtherEx,BloodType,RH,TP,AG,IBIL");

            string table = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'ARCHIVE_ASSISTCHECK' AND TABLE_SCHEMA='kangshuo_db' AND COLUMN_NAME='ALP'";

            object single = MySQLHelper.GetSingle(table);
            int count = 0;

            if (single != null) count = int.Parse(single.ToString());

            if (count > 0) builder.Append(",ALP");

            builder.Append(" )VALUES (");
            builder.Append("@PhysicalID,@IDCardNo,@HB,@WBC,@PLT,@PRO,@GLU,@KET,@BLD,@FPGL,@ECG,@ALBUMIN,@FOB,@HBALC,@HBSAG,@SGPT,@GOT,@BP,@TBIL,@CB,@SCR,");
            builder.Append("@BUN,@PC,@HYPE,@TC,@TG,@LowCho,@HeiCho,@CHESTX,@BCHAO,@BloodOther,@UrineOther,@Other,@CERVIX,@GT,@ECGEx,@CHESTXEx,@BCHAOEx,@CERVIXEx,");
            builder.Append("@FPGDL,@OutKey,@UA,@BCHAOther,@BCHAOtherEx,@BloodType,@RH,@TP,@AG,@IBIL");

            if (count > 0) builder.Append(",@ALP");

            builder.Append(");SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@HB", MySqlDbType.Decimal),
                new MySqlParameter("@WBC", MySqlDbType.Decimal),
                new MySqlParameter("@PLT", MySqlDbType.Decimal),
                new MySqlParameter("@PRO", MySqlDbType.String, 10),
                new MySqlParameter("@GLU", MySqlDbType.String, 10),
                new MySqlParameter("@KET", MySqlDbType.String, 10),
                new MySqlParameter("@BLD", MySqlDbType.String, 10),
                new MySqlParameter("@FPGL", MySqlDbType.Decimal),
                new MySqlParameter("@ECG", MySqlDbType.String, 100),
                new MySqlParameter("@ALBUMIN", MySqlDbType.Decimal),
                new MySqlParameter("@FOB", MySqlDbType.String, 1),
                new MySqlParameter("@HBALC", MySqlDbType.Decimal),
                new MySqlParameter("@HBSAG", MySqlDbType.String, 1),
                new MySqlParameter("@SGPT", MySqlDbType.Decimal),
                new MySqlParameter("@GOT", MySqlDbType.Decimal),
                new MySqlParameter("@BP", MySqlDbType.Decimal),
                new MySqlParameter("@TBIL", MySqlDbType.Decimal),
                new MySqlParameter("@CB", MySqlDbType.Decimal),
                new MySqlParameter("@SCR", MySqlDbType.Decimal),
                new MySqlParameter("@BUN", MySqlDbType.Decimal),
                new MySqlParameter("@PC", MySqlDbType.Decimal),
                new MySqlParameter("@HYPE", MySqlDbType.Decimal),
                new MySqlParameter("@TC", MySqlDbType.Decimal),
                new MySqlParameter("@TG", MySqlDbType.Decimal),
                new MySqlParameter("@LowCho", MySqlDbType.Decimal),
                new MySqlParameter("@HeiCho", MySqlDbType.Decimal),
                new MySqlParameter("@CHESTX", MySqlDbType.String, 1),
                new MySqlParameter("@BCHAO", MySqlDbType.String, 1),
                new MySqlParameter("@BloodOther", MySqlDbType.String, 50),
                new MySqlParameter("@UrineOther", MySqlDbType.String, 50),
                new MySqlParameter("@Other", MySqlDbType.String, 50),
                new MySqlParameter("@CERVIX", MySqlDbType.String, 1),
                new MySqlParameter("@GT", MySqlDbType.Decimal),
                new MySqlParameter("@ECGEx", MySqlDbType.String, 500),
                new MySqlParameter("@CHESTXEx", MySqlDbType.String, 500),
                new MySqlParameter("@BCHAOEx", MySqlDbType.String, 500),
                new MySqlParameter("@CERVIXEx", MySqlDbType.String, 500),
                new MySqlParameter("@FPGDL", MySqlDbType.Decimal),
                new MySqlParameter("@OutKey",MySqlDbType.Int32,4),
                new MySqlParameter("@UA", MySqlDbType.String, 500),
                new MySqlParameter("@BCHAOther", MySqlDbType.String, 500),
                new MySqlParameter("@BCHAOtherEx", MySqlDbType.String, 500),
                new MySqlParameter("@BloodType", MySqlDbType.String, 1),
                new MySqlParameter("@RH", MySqlDbType.String, 1),
                new MySqlParameter("@TP", MySqlDbType.Decimal),
                new MySqlParameter("@AG", MySqlDbType.Decimal),
                new MySqlParameter("@IBIL", MySqlDbType.Decimal),
                new MySqlParameter("@ALP", MySqlDbType.Decimal)
            };

            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.HB;
            cmdParms[3].Value = model.WBC;
            cmdParms[4].Value = model.PLT;
            cmdParms[5].Value = model.PRO;
            cmdParms[6].Value = model.GLU;
            cmdParms[7].Value = model.KET;
            cmdParms[8].Value = model.BLD;
            cmdParms[9].Value = model.FPGL;
            cmdParms[10].Value = model.ECG;
            cmdParms[11].Value = model.ALBUMIN;
            cmdParms[12].Value = model.FOB;
            cmdParms[13].Value = model.HBALC;
            cmdParms[14].Value = model.HBSAG;
            cmdParms[15].Value = model.SGPT;
            cmdParms[16].Value = model.GOT;
            cmdParms[17].Value = model.BP;
            cmdParms[18].Value = model.TBIL;
            cmdParms[19].Value = model.CB;
            cmdParms[20].Value = model.SCR;
            cmdParms[21].Value = model.BUN;
            cmdParms[22].Value = model.PC;
            cmdParms[23].Value = model.HYPE;
            cmdParms[24].Value = model.TC;
            cmdParms[25].Value = model.TG;
            cmdParms[26].Value = model.LowCho;
            cmdParms[27].Value = model.HeiCho;
            cmdParms[28].Value = model.CHESTX;
            cmdParms[29].Value = model.BCHAO;
            cmdParms[30].Value = model.BloodOther;
            cmdParms[31].Value = model.UrineOther;
            cmdParms[32].Value = model.Other;
            cmdParms[33].Value = model.CERVIX;
            cmdParms[34].Value = model.GT;
            cmdParms[35].Value = model.ECGEx;
            cmdParms[36].Value = model.CHESTXEx;
            cmdParms[37].Value = model.BCHAOEx;
            cmdParms[38].Value = model.CERVIXEx;
            cmdParms[39].Value = model.FPGDL;
            cmdParms[40].Value = model.OutKey;//UA
            cmdParms[41].Value = model.UA;
            cmdParms[42].Value = model.BCHAOther;
            cmdParms[43].Value = model.BCHAOtherEx;
            cmdParms[44].Value = model.BloodType;
            cmdParms[45].Value = model.RH;
            cmdParms[46].Value = model.TP;
            cmdParms[47].Value = model.AG;
            cmdParms[48].Value = model.IBIL;
            cmdParms[49].Value = model.ALP;

            single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_ASSISTCHECK ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE " + strWhere);
            }

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 判断是数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNum(string value)
        {
            value = string.IsNullOrEmpty(value) ? "" : value;
            return Regex.IsMatch(value, @"^(-)?\d+(\.\d+)?$");
        }

        /// <summary>
        /// 更新血球
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateXQ(DataModel model)
        {
            int successNum = 0;

            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE ARCHIVE_BLOODTEST SET ");

            //百分比
            //中性粒细胞百分比
            if (model.NEU_B != "" && IsNum(model.NEU_B))
            {
                sb.Append("NEU_B='" + model.NEU_B + "', ");
            }
            //淋巴细胞百分比
            if (model.LYMPH_B != "" && IsNum(model.LYMPH_B))
            {
                sb.Append("LYMPH_B='" + model.LYMPH_B + "', ");
            }
            //单核细胞百分比
            if (model.MON_B != "" && IsNum(model.MON_B))
            {
                sb.Append("MON_B='" + model.MON_B + "', ");
            }
            //嗜酸性粒细胞百分比
            if (model.EOS_B != "" && IsNum(model.EOS_B))
            {
                sb.Append("EOS_B='" + model.EOS_B + "', ");
            }
            //嗜碱性粒细胞百分比
            if (model.BAS_B != "" && IsNum(model.BAS_B))
            {
                sb.Append("BAS_B='" + model.BAS_B + "', ");
            }
            //数目
            //中性粒细胞数目
            if (model.NEU_N != "" && IsNum(model.NEU_N))
            {
                sb.Append("NEU_N='" + model.NEU_N + "', ");
            }
            //淋巴细胞数目
            if (model.LYMPH_N != "" && IsNum(model.LYMPH_N))
            {
                sb.Append("LYMPH_N='" + model.LYMPH_N + "', ");
            }
            //单核细胞数目
            if (model.MON_N != "" && IsNum(model.MON_N))
            {
                sb.Append("MON_N='" + model.MON_N + "', ");
            }
            //嗜酸性粒细胞数目
            if (model.EOS_N != "" && IsNum(model.EOS_N))
            {
                sb.Append("EOS_N='" + model.EOS_N + "', ");
            }
            //嗜碱性粒细胞数目
            if (model.BAS_N != "" && IsNum(model.BAS_N))
            {
                sb.Append("BAS_N='" + model.BAS_N + "', ");
            }
            //红细胞数目
            if (model.RBC != "" && IsNum(model.RBC))
            {
                sb.Append("RBC='" + model.RBC + "', ");
            }
            //红细胞压积
            if (model.HCT != "" && IsNum(model.HCT))
            {
                sb.Append("HCT='" + model.HCT + "', ");
            }
            //平均红细胞体积
            if (model.MCV != "" && IsNum(model.MCV))
            {
                sb.Append("MCV='" + model.MCV + "', ");
            }
            //平均红细胞血红蛋白含量
            if (model.MCH != "" && IsNum(model.MCH))
            {
                sb.Append("MCH='" + model.MCH + "', ");
            }
            //平均红细胞血红蛋白浓度
            if (model.MCHC != "" && IsNum(model.MCHC))
            {
                sb.Append("MCHC='" + model.MCHC + "', ");
            }
            //红细胞分布宽度变异系数
            if (model.RDW_CV != "" && IsNum(model.RDW_CV))
            {
                sb.Append("RDW_CV='" + model.RDW_CV + "', ");
            }
            //红细胞分布宽度标准差
            if (model.RDW_SD != "" && IsNum(model.RDW_SD))
            {
                sb.Append("RDW_SD='" + model.RDW_SD + "', ");
            }
            //平均血小板体积
            if (model.MPV != "" && IsNum(model.MPV))
            {
                sb.Append("MPV='" + model.MPV + "', ");
            }
            //血小板分布宽度
            if (model.PDW != "" && IsNum(model.PDW))
            {
                sb.Append("PDW='" + model.PDW + "', ");
            }
            //血小板压积
            if (model.PCT != "" && IsNum(model.PCT))
            {
                sb.Append("PCT='" + model.PCT + "',");
            }
            //中间细胞百分比
            if (model.MID_B != "" && IsNum(model.MID_B))
            {
                sb.Append("MID_B='" + model.MID_B + "',");
            }
            //中间细胞数目
            if (model.MID_N != "" && IsNum(model.MID_N))
            {
                sb.Append("MID_N='" + model.MID_N + "',");
            }
            //大血小板比率
            if (model.P_LCR != "" && IsNum(model.P_LCR))
            {
                sb.Append("P_LCR='" + model.P_LCR + "',");
            }
            //大血小板数目
            if (model.P_LCC != "" && IsNum(model.P_LCC))
            {
                sb.Append("P_LCC='" + model.P_LCC + "',");
            }
            //巨大未成熟细胞百分比
            if (model.HLR_B != "" && IsNum(model.HLR_B))
            {
                sb.Append("HLR_B='" + model.HLR_B + "',");
            }
            //巨大未成熟细胞数目
            if (model.HLR_N != "" && IsNum(model.HLR_N))
            {
                sb.Append("HLR_N='" + model.HLR_N + "',");
            }
            //异常淋巴细胞百分比
            if (model.ALY_B != "" && IsNum(model.ALY_B))
            {
                sb.Append("ALY_B='" + model.ALY_B + "',");
            }
            //异常淋巴细胞数目
            if (model.ALY_N != "" && IsNum(model.ALY_N))
            {
                sb.Append("ALY_N='" + model.ALY_N + "',");
            }

            string table = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'ARCHIVE_BLOODTEST' AND TABLE_SCHEMA='kangshuo_db' AND COLUMN_NAME='NRBC_N'";

            object single = MySQLHelper.GetSingle(table);
            int count = 0;

            if (single != null) count = int.Parse(single.ToString());

            if (count > 0)
            {
                // 有核红细胞数目
                if (model.NRBC_N != "" && IsNum(model.NRBC_N))
                {
                    sb.Append("NRBC_N='" + model.NRBC_N + "',");
                }
                // 有核红细胞百分比
                if (model.NRBC_B != "" && IsNum(model.NRBC_B))
                {
                    sb.Append("NRBC_B='" + model.NRBC_B + "',");
                }
                // 血红蛋白浓度
                if (model.HGB != "" && IsNum(model.HGB))
                {
                    sb.Append("HGB='" + model.HGB + "',");
                }
            }

            if (sb.ToString() != "UPDATE ARCHIVE_BLOODTEST SET ")
            {
                string str = sb.ToString().Trim().TrimEnd(',');
                str += " WHERE IDCardNo='" + model.IDCardNo + "' AND DATE_FORMAT(TestTime,'%Y-%m-%d') ='" +
                    model.TestTime.ToString("yyyy-MM-dd") + "'";

                successNum = MySQLHelper.ExecuteSql(str);
            }
            else successNum = -2;

            return successNum;
        }

        /// <summary>
        /// 更新血球-依条码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateXQNew(DataModel model)
        {
            int successNum = 0;

            StringBuilder sb = new StringBuilder();

            string table = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'ARCHIVE_BLOODTEST' AND TABLE_SCHEMA='kangshuo_db' AND COLUMN_NAME='BarCode'";

            object single = MySQLHelper.GetSingle(table);

            if (single != null && int.Parse(single.ToString()) < 1) return 0;

            sb.Append("UPDATE ARCHIVE_BLOODTEST SET ");

            //百分比
            //中性粒细胞百分比
            if (model.NEU_B != "" && IsNum(model.NEU_B))
            {
                sb.Append("NEU_B='" + model.NEU_B + "', ");
            }
            //淋巴细胞百分比
            if (model.LYMPH_B != "" && IsNum(model.LYMPH_B))
            {
                sb.Append("LYMPH_B='" + model.LYMPH_B + "', ");
            }
            //单核细胞百分比
            if (model.MON_B != "" && IsNum(model.MON_B))
            {
                sb.Append("MON_B='" + model.MON_B + "', ");
            }
            //嗜酸性粒细胞百分比
            if (model.EOS_B != "" && IsNum(model.EOS_B))
            {
                sb.Append("EOS_B='" + model.EOS_B + "', ");
            }
            //嗜碱性粒细胞百分比
            if (model.BAS_B != "" && IsNum(model.BAS_B))
            {
                sb.Append("BAS_B='" + model.BAS_B + "', ");
            }
            //数目
            //中性粒细胞数目
            if (model.NEU_N != "" && IsNum(model.NEU_N))
            {
                sb.Append("NEU_N='" + model.NEU_N + "', ");
            }
            //淋巴细胞数目
            if (model.LYMPH_N != "" && IsNum(model.LYMPH_N))
            {
                sb.Append("LYMPH_N='" + model.LYMPH_N + "', ");
            }
            //单核细胞数目
            if (model.MON_N != "" && IsNum(model.MON_N))
            {
                sb.Append("MON_N='" + model.MON_N + "', ");
            }
            //嗜酸性粒细胞数目
            if (model.EOS_N != "" && IsNum(model.EOS_N))
            {
                sb.Append("EOS_N='" + model.EOS_N + "', ");
            }
            //嗜碱性粒细胞数目
            if (model.BAS_N != "" && IsNum(model.BAS_N))
            {
                sb.Append("BAS_N='" + model.BAS_N + "', ");
            }
            //红细胞数目
            if (model.RBC != "" && IsNum(model.RBC))
            {
                sb.Append("RBC='" + model.RBC + "', ");
            }
            //红细胞压积
            if (model.HCT != "" && IsNum(model.HCT))
            {
                sb.Append("HCT='" + model.HCT + "', ");
            }
            //平均红细胞体积
            if (model.MCV != "" && IsNum(model.MCV))
            {
                sb.Append("MCV='" + model.MCV + "', ");
            }
            //平均红细胞血红蛋白含量
            if (model.MCH != "" && IsNum(model.MCH))
            {
                sb.Append("MCH='" + model.MCH + "', ");
            }
            //平均红细胞血红蛋白浓度
            if (model.MCHC != "" && IsNum(model.MCHC))
            {
                sb.Append("MCHC='" + model.MCHC + "', ");
            }
            //红细胞分布宽度变异系数
            if (model.RDW_CV != "" && IsNum(model.RDW_CV))
            {
                sb.Append("RDW_CV='" + model.RDW_CV + "', ");
            }
            //红细胞分布宽度标准差
            if (model.RDW_SD != "" && IsNum(model.RDW_SD))
            {
                sb.Append("RDW_SD='" + model.RDW_SD + "', ");
            }
            //平均血小板体积
            if (model.MPV != "" && IsNum(model.MPV))
            {
                sb.Append("MPV='" + model.MPV + "', ");
            }
            //血小板分布宽度
            if (model.PDW != "" && IsNum(model.PDW))
            {
                sb.Append("PDW='" + model.PDW + "', ");
            }
            //血小板压积
            if (model.PCT != "" && IsNum(model.PCT))
            {
                sb.Append("PCT='" + model.PCT + "',");
            }
            //白细胞
            if (model.WBC != "" && IsNum(model.WBC))
            {
                sb.Append("WBC='" + model.WBC + "',");
            }
            //中间细胞百分比
            if (model.MID_B != "" && IsNum(model.MID_B))
            {
                sb.Append("MID_B='" + model.MID_B + "',");
            }
            //中间细胞数目
            if (model.MID_N != "" && IsNum(model.MID_N))
            {
                sb.Append("MID_N='" + model.MID_N + "',");
            }
            //大血小板比率
            if (model.P_LCR != "" && IsNum(model.P_LCR))
            {
                sb.Append("P_LCR='" + model.P_LCR + "',");
            }
            //巨大未成熟细胞百分比
            if (model.HLR_B != "" && IsNum(model.HLR_B))
            {
                sb.Append("HLR_B='" + model.HLR_B + "',");
            }
            //巨大未成熟细胞数目
            if (model.HLR_N != "" && IsNum(model.HLR_N))
            {
                sb.Append("HLR_N='" + model.HLR_N + "',");
            }
            //异常淋巴细胞百分比
            if (model.ALY_B != "" && IsNum(model.ALY_B))
            {
                sb.Append("ALY_B='" + model.ALY_B + "',");
            }
            //异常淋巴细胞数目
            if (model.ALY_N != "" && IsNum(model.ALY_N))
            {
                sb.Append("ALY_N='" + model.ALY_N + "',");
            }

            table = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'ARCHIVE_BLOODTEST' AND TABLE_SCHEMA='kangshuo_db' AND COLUMN_NAME='NRBC_N'";

            single = MySQLHelper.GetSingle(table);
            int count = 0;

            if (single != null) count = int.Parse(single.ToString());

            if (count > 0)
            {
                // 有核红细胞数目
                if (model.NRBC_N != "" && IsNum(model.NRBC_N))
                {
                    sb.Append("NRBC_N='" + model.NRBC_N + "',");
                }
                // 有核红细胞百分比
                if (model.NRBC_B != "" && IsNum(model.NRBC_B))
                {
                    sb.Append("NRBC_B='" + model.NRBC_B + "',");
                }
                // 血红蛋白浓度
                if (model.HGB != "" && IsNum(model.HGB))
                {
                    sb.Append("HGB='" + model.HGB + "',");
                }
            }

            if (sb.ToString() != "UPDATE ARCHIVE_BLOODTEST SET ")
            {
                sb.AppendFormat("IDCardNo=(");
                sb.AppendFormat("    SELECT IDCardNo FROM ARCHIVE_CUSTOMERBASEINFO WHERE CustomerID='{0}' ORDER BY CheckDate DESC LIMIT 0,1) ", model.BarCode);

                string str = sb.ToString().Trim().TrimEnd(',');
                str += " WHERE BarCode='" + model.BarCode + "' AND DATE_FORMAT(TestTime,'%Y-%m-%d') ='" +
                    model.TestTime.ToString("yyyy-MM-dd") + "'";

                successNum = MySQLHelper.ExecuteSql(str);
            }
            else successNum = -2;

            return successNum;
        }

        /// <summary>
        /// 更新辅助检查,生化血球同步
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateAssistCheck(DataModel model)
        {
            int successNum = 0;

            try
            {
                #region 更新

                StringBuilder sb = new StringBuilder();

                sb.Append("UPDATE ARCHIVE_ASSISTCHECK SET ");

                if (model.HB != "" && IsNum(model.HB))
                {
                    sb.Append("HB='" + model.HB + "',");
                }
                if (model.WBC != "" && IsNum(model.WBC))
                {
                    sb.Append("WBC='" + model.WBC + "',");
                }
                if (model.PLT != "" && IsNum(model.PLT))
                {
                    sb.Append("PLT='" + model.PLT + "',");
                }

                if (model.PRO != "") sb.Append("PRO='" + model.PRO + "',");
                if (model.GLU != "") sb.Append("GLU='" + model.GLU + "',");
                if (model.KET != "") sb.Append("KET='" + model.KET + "',");
                if (model.BLD != "") sb.Append("BLD='" + model.BLD + "',");

                if (model.FPGL != "" && IsNum(model.FPGL))
                {
                    sb.Append("FPGL='" + model.FPGL + "',");
                }
                if (model.ALBUMIN != "" && IsNum(model.ALBUMIN))
                {
                    sb.Append("ALBUMIN='" + model.ALBUMIN + "',");
                }
                if (model.HBALC != "" && IsNum(model.HBALC))
                {
                    sb.Append("HBALC='" + model.HBALC + "',");
                }
                if (model.SGPT != "" && IsNum(model.SGPT))
                {
                    sb.Append("SGPT='" + model.SGPT + "',");
                }
                if (model.GOT != "" && IsNum(model.GOT))
                {
                    sb.Append("GOT='" + model.GOT + "',");
                }
                if (model.BP != "" && IsNum(model.BP))
                {
                    sb.Append("BP='" + model.BP + "',");
                }
                if (model.TBIL != "" && IsNum(model.TBIL))
                {
                    sb.Append("TBIL='" + model.TBIL + "',");
                }
                if (model.CB != "" && IsNum(model.CB))
                {
                    sb.Append("CB='" + model.CB + "',");
                }
                if (model.SCR != "" && IsNum(model.SCR))
                {
                    sb.Append("SCR='" + model.SCR + "',");
                }
                if (model.BUN != "" && IsNum(model.BUN))
                {
                    sb.Append("BUN='" + model.BUN + "',");
                }
                if (model.PC != "" && IsNum(model.PC))
                {
                    sb.Append("PC='" + model.PC + "',");
                }
                if (model.HYPE != "" && IsNum(model.HYPE))
                {
                    sb.Append("HYPE='" + model.HYPE + "',");
                }
                if (model.TC != "" && IsNum(model.TC))
                {
                    sb.Append("TC='" + model.TC + "',");
                }
                if (model.TG != "" && IsNum(model.TG))
                {
                    sb.Append("TG='" + model.TG + "',");
                }
                if (model.LDL_C != "" && IsNum(model.LDL_C))
                {
                    sb.Append("LowCho='" + model.LDL_C + "',");
                }
                if (model.HDL_C != "" && IsNum(model.HDL_C))
                {
                    sb.Append("HeiCho='" + model.HDL_C + "',");
                }
                if (model.GT != "" && IsNum(model.GT))
                {
                    sb.Append("GT='" + model.GT + "',");
                }
                if (model.TP != "" && IsNum(model.TP))
                {
                    sb.Append("TP='" + model.TP + "',");
                }
                if (model.GLB != "" && IsNum(model.GLB))
                {
                    sb.Append("GLB='" + model.GLB + "',");
                }
                if (model.AG != "" && IsNum(model.AG))
                {
                    sb.Append("AG='" + model.AG + "',");
                }
                if (model.IBIL != "" && IsNum(model.IBIL))
                {
                    sb.Append("IBIL='" + model.IBIL + "',");
                }

                if (!string.IsNullOrEmpty(model.HBSAG))   //乙型肝炎表面抗原1:阴性,2:阳性
                {
                    if (model.HBSAG.Trim() == ("+") || model.HBSAG.Contains("2")) model.HBSAG = "2";
                    else if (model.HBSAG.Trim() == ("-") || model.HBSAG.Contains("1")) model.HBSAG = "1";
                    else if (model.HBSAG.Trim() == ("+-") || model.HBSAG.Contains("3")) model.HBSAG = "3";

                    string t = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'ARCHIVE_ASSISTCHECK' AND TABLE_SCHEMA='kangshuo_db' AND COLUMN_NAME='HBSAG'";

                    object s = MySQLHelper.GetSingle(t);
                    int c = 0;

                    if (s != null) c = int.Parse(s.ToString());

                    if (c > 0 && model.HBSAG != "" && IsNum(model.HBSAG))// 乙肝e抗原
                    {
                        sb.Append("HBSAG='" + model.HBSAG + "',");
                    }
                }
                if (!string.IsNullOrEmpty(model.HBEAG))   //乙肝e抗原1:阴性,2:阳性
                {
                    if (model.HBEAG.Trim()==("+") || model.HBEAG.Contains("2")) model.HBEAG = "2";
                    else if (model.HBEAG.Trim() == ("-") || model.HBEAG.Contains("1")) model.HBEAG = "1";
                    else if (model.HBEAG.Trim() == ("+-") || model.HBEAG.Contains("3")) model.HBEAG = "3";

                    string t = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'ARCHIVE_ASSISTCHECK' AND TABLE_SCHEMA='kangshuo_db' AND COLUMN_NAME='HBEAG'";

                    object s = MySQLHelper.GetSingle(t);
                    int c = 0;

                    if (s != null) c = int.Parse(s.ToString());

                    if (c > 0 && model.HBEAG != "" && IsNum(model.HBEAG))// 乙肝e抗原
                    {
                        sb.Append("HBEAG='" + model.HBEAG + "',");
                    }
                    
                }
                if (!string.IsNullOrEmpty(model.HBEAB))   //乙肝e抗体1:阴性,2:阳性
                {
                    if (model.HBEAB.Trim() == ("+") || model.HBEAB.Contains("2")) model.HBEAB = "2";
                    else if (model.HBEAB.Trim() == ("-") || model.HBEAB.Contains("1")) model.HBEAB = "1";
                    else if (model.HBEAB.Trim() == ("+-") || model.HBEAB.Contains("3")) model.HBEAB = "3";

                    string t = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'ARCHIVE_ASSISTCHECK' AND TABLE_SCHEMA='kangshuo_db' AND COLUMN_NAME='HBEAB'";

                    object s = MySQLHelper.GetSingle(t);
                    int c = 0;

                    if (s != null) c = int.Parse(s.ToString());

                    if (c > 0 && model.HBEAB != "" && IsNum(model.HBEAB))// 乙肝e抗体
                    {
                        sb.Append("HBEAB='" + model.HBEAB + "',");
                    }
                }
                if (!string.IsNullOrEmpty(model.HBCAB))   //乙肝核心抗体1:阴性,2:阳性
                {
                    if (model.HBCAB.Trim() == ("+") || model.HBCAB.Contains("2")) model.HBCAB = "2";
                    else if (model.HBCAB.Trim() == ("-") || model.HBCAB.Contains("1")) model.HBCAB = "1";
                    else if (model.HBCAB.Trim() == ("+-") || model.HBCAB.Contains("3")) model.HBCAB = "3";

                    string t = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'ARCHIVE_ASSISTCHECK' AND TABLE_SCHEMA='kangshuo_db' AND COLUMN_NAME='HBCAB'";

                    object s = MySQLHelper.GetSingle(t);
                    int c = 0;

                    if (s != null) c = int.Parse(s.ToString());

                    if (c > 0 && model.HBCAB != "" && IsNum(model.HBCAB))// 乙肝e抗体
                    {
                        sb.Append("HBCAB='" + model.HBCAB + "',");
                    }
                }
                if (!string.IsNullOrEmpty(model.HBSAB))   //乙肝表面抗体1:阴性,2:阳性
                {
                    if (model.HBSAB.Trim() == ("+") || model.HBSAB.Contains("2")) model.HBSAB = "2";
                    else if (model.HBSAB.Trim() == ("-") || model.HBSAB.Contains("1")) model.HBSAB = "1";
                    else if (model.HBSAB.Trim() == ("+-") || model.HBSAB.Contains("3")) model.HBSAB = "3";

                    string t = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'ARCHIVE_ASSISTCHECK' AND TABLE_SCHEMA='kangshuo_db' AND COLUMN_NAME='HBSAB'";

                    object s = MySQLHelper.GetSingle(t);
                    int c = 0;

                    if (s != null) c = int.Parse(s.ToString());

                    if (c > 0 && model.HBSAB != "" && IsNum(model.HBSAB))// 乙肝e抗体
                    {
                        sb.Append("HBSAB='" + model.HBSAB + "',");
                    }
                }

                if (model.UA != "") // 血清尿酸
                {
                    sb.Append("UA='" + model.UA + "',");
                }
                if (model.HCY != "") // 同型半胱氨酸
                {
                    sb.Append("HCY='" + model.HCY + "',");
                }
                if (!string.IsNullOrEmpty(model.BloodType))
                {
                    sb.Append("BloodType='" + model.BloodType + "',");
                }
                if (model.FPGDL != "" && IsNum(model.FPGDL))
                {
                    sb.Append("FPGDL='" + model.FPGDL + "',");
                }
                if (model.ASTALT != "" && IsNum(model.ASTALT))
                {
                    sb.Append("ASTALT='" + model.ASTALT + "',");
                }
                //氯
                if (model.CL != "" && IsNum(model.CL))
                {
                    sb.Append("CL='" + model.CL + "',");
                }
                //钙
                if (model.CA != "" && IsNum(model.CA))
                {
                    sb.Append("CA='" + model.CA + "',");
                }

                string table = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'ARCHIVE_ASSISTCHECK' AND TABLE_SCHEMA='kangshuo_db' AND COLUMN_NAME='ALP'";

                object single = MySQLHelper.GetSingle(table);
                int count = 0;

                if (single != null) count = int.Parse(single.ToString());

                if (count > 0 && model.ALP != "" && IsNum(model.ALP))// 碱性磷酸酶
                {
                    sb.Append("ALP='" + model.ALP + "',");
                }

                if (versionNo.Contains("福建"))
                {
                    if (community.Contains("福清惠铭医院"))
                    {
                        if (!string.IsNullOrEmpty(model.BloodOther))
                        {
                            sb.Append("BloodOther= '" + model.BloodOther + "',");
                        }
                    }

                    if (model.UA != "" && IsNum(model.UA))
                    {
                        sb.Append("Other='尿酸:" + model.UA + "μmol/L。',");
                    }
                }
                else if (versionNo.Contains("四川"))
                {
                    if (model.HCY != "" && IsNum(model.HCY))
                    {
                        string strTs = "";
                        decimal value = decimal.Round(decimal.Parse(model.HCY), 1);

                        if (value > 15) strTs = "阳性";
                        else strTs = "阴性";

                        sb.Append("Other='同型半胱氨酸" + value.ToString() + "μmol/L，" + strTs + "。',");
                    }

                    if (model.UA != "" && IsNum(model.UA))
                    {
                        sb.Append("UrineOther='尿酸" + model.UA + "μmol/L。',");
                    }
                }
                else if (area.Equals("梧州市"))  // 广西梧州市
                {
                    // 尿白细胞
                    if (model.LEU != "") sb.Append("UrineOther='白细胞(" + model.LEU + ")',");

                    // 红细胞压积
                    if (model.HCT != "") sb.Append("BloodOther='红细胞压积(" + model.HCT + ")',");
                }
                else if (community.Equals("小孟镇"))  // 山东济宁小孟镇
                {
                    // 红细胞数目
                    if (model.RBC != "" && !string.IsNullOrEmpty(model.BloodOther) && model.BloodOther.Contains("红细胞数目"))
                        sb.Append("BloodOther='红细胞数目:" + model.RBC + "x10^12/L',");
                }
                else
                {
                    // 尿白细胞
                    if (model.LEU != "") sb.Append("UrineOther='" + model.LEU + "',");
                }

                #endregion

                if (sb.ToString() != "UPDATE ARCHIVE_ASSISTCHECK SET ")
                {
                    string upStr = sb.ToString().Substring(0, sb.ToString().Length - 1);
                    upStr += " WHERE OutKey =  '" + model.PersonID + "' ";

                    successNum = MySQLHelper.ExecuteSql(upStr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return successNum;
        }

        /// <summary>
        /// 更新辅助检查,生化血球同步
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateAssistCheckNew(DataModel model)
        {
            int successNum = 0;

            try
            {
                #region 更新

                StringBuilder sb = new StringBuilder();

                sb.Append("UPDATE ARCHIVE_ASSISTCHECK D SET ");

                if (model.HB != "" && IsNum(model.HB))
                {
                    sb.Append("HB='" + model.HB + "',");
                }
                if (model.WBC != "" && IsNum(model.WBC))
                {
                    sb.Append("WBC='" + model.WBC + "',");
                }
                if (model.PLT != "" && IsNum(model.PLT))
                {
                    sb.Append("PLT='" + model.PLT + "',");
                }

                if (model.PRO != "") sb.Append("PRO='" + model.PRO + "',");
                if (model.GLU != "") sb.Append("GLU='" + model.GLU + "',");
                if (model.KET != "") sb.Append("KET='" + model.KET + "',");
                if (model.BLD != "") sb.Append("BLD='" + model.BLD + "',");

                if (model.FPGL != "" && IsNum(model.FPGL))
                {
                    sb.Append("FPGL='" + model.FPGL + "',");
                }
                if (model.ALBUMIN != "" && IsNum(model.ALBUMIN))
                {
                    sb.Append("ALBUMIN='" + model.ALBUMIN + "',");
                }
                if (model.HBALC != "" && IsNum(model.HBALC))
                {
                    sb.Append("HBALC='" + model.HBALC + "',");
                }
                if (model.SGPT != "" && IsNum(model.SGPT))
                {
                    sb.Append("SGPT='" + model.SGPT + "',");
                }
                if (model.GOT != "" && IsNum(model.GOT))
                {
                    sb.Append("GOT='" + model.GOT + "',");
                }
                if (model.BP != "" && IsNum(model.BP))
                {
                    sb.Append("BP='" + model.BP + "',");
                }
                if (model.TBIL != "" && IsNum(model.TBIL))
                {
                    sb.Append("TBIL='" + model.TBIL + "',");
                }
                if (model.CB != "" && IsNum(model.CB))
                {
                    sb.Append("CB='" + model.CB + "',");
                }
                if (model.SCR != "" && IsNum(model.SCR))
                {
                    sb.Append("SCR='" + model.SCR + "',");
                }
                if (model.BUN != "" && IsNum(model.BUN))
                {
                    sb.Append("BUN='" + model.BUN + "',");
                }
                if (model.PC != "" && IsNum(model.PC))
                {
                    sb.Append("PC='" + model.PC + "',");
                }
                if (model.HYPE != "" && IsNum(model.HYPE))
                {
                    sb.Append("HYPE='" + model.HYPE + "',");
                }
                if (model.TC != "" && IsNum(model.TC))
                {
                    sb.Append("TC='" + model.TC + "',");
                }
                if (model.TG != "" && IsNum(model.TG))
                {
                    sb.Append("TG='" + model.TG + "',");
                }
                if (model.LDL_C != "" && IsNum(model.LDL_C))
                {
                    sb.Append("LowCho='" + model.LDL_C + "',");
                }
                if (model.HDL_C != "" && IsNum(model.HDL_C))
                {
                    sb.Append("HeiCho='" + model.HDL_C + "',");
                }
                if (model.GT != "" && IsNum(model.GT))
                {
                    sb.Append("GT='" + model.GT + "',");
                }
                if (model.TP != "" && IsNum(model.TP))
                {
                    sb.Append("TP='" + model.TP + "',");
                }
                if (model.GLB != "" && IsNum(model.GLB))
                {
                    sb.Append("GLB='" + model.GLB + "',");
                }
                if (model.AG != "" && IsNum(model.AG))
                {
                    sb.Append("AG='" + model.AG + "',");
                }
                if (model.IBIL != "" && IsNum(model.IBIL))
                {
                    sb.Append("IBIL='" + model.IBIL + "',");
                }

                if (!string.IsNullOrEmpty(model.HBSAG))   //乙型肝炎表面抗原1:阴性,2:阳性
                {
                    if (model.HBSAG.Contains("+") || model.HBSAG.Contains("2"))
                    {
                        sb.Append("HBSAG='2',");
                    }
                    else if (model.HBSAG.Contains("-") || model.HBSAG.Contains("1"))
                    {
                        sb.Append("HBSAG='1',");
                    }
                }

                if (model.UA != "") //血清尿酸
                {
                    sb.Append("UA='" + model.UA + "',");
                }
                if (model.HCY != "") //同型半胱氨酸
                {
                    sb.Append("HCY='" + model.HCY + "',");
                }
                if (!string.IsNullOrEmpty(model.BloodType))
                {
                    sb.Append("BloodType='" + model.BloodType + "',");
                }
                if (model.FPGDL != "" && IsNum(model.FPGDL))
                {
                    sb.Append("FPGDL='" + model.FPGDL + "',");
                }
                if (model.ASTALT != "" && IsNum(model.ASTALT))
                {
                    sb.Append("ASTALT='" + model.ASTALT + "',");
                }
                if (model.CL != "" && IsNum(model.CL))
                {
                    sb.Append("CL='" + model.CL + "',");
                }
                if (model.CA != "" && IsNum(model.CA))
                {
                    sb.Append("CA='" + model.CA + "',");
                }

                string table = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'ARCHIVE_ASSISTCHECK' AND TABLE_SCHEMA='kangshuo_db' AND COLUMN_NAME='ALP'";

                object single = MySQLHelper.GetSingle(table);
                int count = 0;

                if (single != null) count = int.Parse(single.ToString());

                if (count > 0 && model.ALP != "" && IsNum(model.ALP))// 碱性磷酸酶
                {
                    sb.Append("ALP='" + model.ALP + "',");
                }

                if (versionNo.Contains("福建"))
                {
                    if (community.Contains("福清惠铭医院"))
                    {
                        if (!string.IsNullOrEmpty(model.BloodOther))
                        {
                            sb.Append("BloodOther= '" + model.BloodOther + "',");
                        }
                    }

                    if (model.UA != "" && IsNum(model.UA))
                    {
                        sb.Append("Other='尿酸:" + model.UA + "μmol/L。',");
                    }
                }
                else if (versionNo.Contains("四川"))
                {
                    if (model.HCY != "" && IsNum(model.HCY))
                    {
                        string strTs = "";
                        decimal value = decimal.Round(decimal.Parse(model.HCY), 1);

                        if (value > 15) strTs = "阳性";
                        else strTs = "阴性";

                        sb.Append("Other='同型半胱氨酸" + value.ToString() + "μmol/L，" + strTs + "。',");
                    }

                    if (model.UA != "" && IsNum(model.UA))
                    {
                        sb.Append("UrineOther='尿酸" + model.UA + "μmol/L。',");
                    }
                }
                else if (area.Equals("梧州市"))  // 广西梧州市
                {
                    // 尿白细胞
                    if (model.LEU != "") sb.Append("UrineOther='白细胞(" + model.LEU + ")',");

                    // 红细胞压积
                    if (model.HCT != "") sb.Append("BloodOther='红细胞压积(" + model.HCT + ")',");
                }
                else if (community.Equals("小孟镇"))  // 山东济宁小孟镇
                {
                    // 红细胞数目
                    if (model.RBC != "" && !string.IsNullOrEmpty(model.BloodOther) && model.BloodOther.Contains("红细胞数目")) sb.Append("BloodOther='红细胞数目:" + model.RBC + "x10^12/L',");
                }
                else
                {
                    // 尿白细胞
                    if (model.LEU != "") sb.Append("UrineOther='" + model.LEU + "',");
                }

                #endregion

                if (sb.ToString() != "UPDATE ARCHIVE_ASSISTCHECK D SET ")
                {
                    string upStr = sb.ToString().Substring(0, sb.ToString().Length - 1);
                    upStr += " WHERE D.OutKey = (SELECT M.ID FROM ARCHIVE_CUSTOMERBASEINFO M ";
                    upStr += " WHERE M.CustomerID = '" + model.BarCode + "' ";
                    upStr += " ORDER BY M.CheckDate DESC LIMIT 0,1);";

                    successNum = MySQLHelper.ExecuteSql(upStr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return successNum;
        }

        /// <summary>
        /// 更新身高体重
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateWeight(DataModel model)
        {
            int successNum = 0;

            try
            {
                #region 更新

                StringBuilder sb = new StringBuilder();

                sb.Append("UPDATE ARCHIVE_GENERALCONDITION D SET ");

                if (model.Height != "" && IsNum(model.Height))
                {
                    sb.Append("Height='" + model.Height + "',");
                }
                if (model.Weight != "" && IsNum(model.Weight))
                {
                    sb.Append("Weight='" + model.Weight + "',");
                }
                if (model.BMI != "" && IsNum(model.BMI))
                {
                    sb.Append("BMI='" + model.BMI + "',");
                }
                if (model.Waist != "" && IsNum(model.Waist))
                {
                    sb.Append("Waistline='" + model.Waist + "',");
                }

                #endregion

                if (sb.ToString() != "UPDATE ARCHIVE_GENERALCONDITION D SET ")
                {
                    string upStr = sb.ToString().Substring(0, sb.ToString().Length - 1);
                    upStr += " WHERE D.OutKey = (SELECT M.ID FROM ARCHIVE_CUSTOMERBASEINFO M ";
                    upStr += " WHERE M.IDCardNo = '" + model.IDCardNo + "' ";
                    upStr += " ORDER BY M.CheckDate DESC LIMIT 0,1);";

                    successNum = MySQLHelper.ExecuteSql(upStr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return successNum;
        }

        /// <summary>
        /// 更新辅助检查
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateAssistCheckNJ(DataModel model)
        {
            int successNum = 0;

            try
            {
                #region 更新

                StringBuilder sb = new StringBuilder();

                sb.Append("UPDATE ARCHIVE_ASSISTCHECK D SET ");

                if (model.PRO != "") sb.Append("PRO='" + model.PRO + "',");
                if (model.GLU != "") sb.Append("GLU='" + model.GLU + "',");
                if (model.KET != "") sb.Append("KET='" + model.KET + "',");
                if (model.BLD != "") sb.Append("BLD='" + model.BLD + "',");
                if (model.UrineOther != "") sb.Append("UrineOther='" + model.UrineOther + "',");

                #endregion

                if (sb.ToString() != "UPDATE ARCHIVE_ASSISTCHECK D SET ")
                {
                    string upStr = sb.ToString().Substring(0, sb.ToString().Length - 1);
                    upStr += " WHERE D.OutKey = (SELECT M.ID FROM ARCHIVE_CUSTOMERBASEINFO M ";
                    upStr += " WHERE M.IDCardNo = '" + model.IDCardNo + "' ";
                    upStr += " ORDER BY M.CheckDate DESC LIMIT 0,1);";

                    successNum = MySQLHelper.ExecuteSql(upStr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return successNum;
        }

        /// <summary>
        /// 血糖同步
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByMiniSTPad(RecordsAssistCheckModel model, string checkDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"UPDATE 
                                    ARCHIVE_ASSISTCHECK  D
                             SET 
                                    FPGL=@FPGL
                               
                             WHERE
                                    EXISTS
                                    (
                                        SELECT 
                                            ID 
                                        FROM
                                        ARCHIVE_CUSTOMERBASEINFO M
                                        WHERE M.ID = D.OutKey
                                        AND M.IDCardNo = @IDCardNo
                                        AND M.CheckDate = @CheckDate
                                    )
                            ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@CheckDate",checkDate),
                new MySqlParameter("@FPGL", model.FPGL)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet GetModelByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_ASSISTCHECK ");
            builder.Append(" WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@OutKey", MySqlDbType.String)
            };
            cmdParms[0].Value = OutKey;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }

        /// <summary>
        /// 尿常规同步
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByMiniPad(RecordsAssistCheckModel model, string checkDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                         ARCHIVE_ASSISTCHECK  D
                                       SET 
                                         BLD=@BLD
                                        ,KET=@KET
                                        ,GLU=@GLU
                                        ,PRO=@PRO ");

            if (!string.IsNullOrEmpty(model.UrineOther)) builder.Append(",UrineOther=@UrineOther");
            else if (!string.IsNullOrEmpty(model.UrineOther) && model.UrineOther.Equals("陕西")) builder.Append(",UrineOther=REPLACE(UrineOther,'未配合检查','')");

            builder.Append(@" WHERE
                                    EXISTS
                                    (
                                        SELECT 
                                            ID 
                                        FROM
                                        ARCHIVE_CUSTOMERBASEINFO M
                                        WHERE M.ID = D.OutKey
                                        AND M.IDCardNo = @IDCardNo
                                        AND M.CheckDate = @CheckDate
                                    )
                            ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@CheckDate",checkDate),
                new MySqlParameter("@BLD", model.BLD),
                new MySqlParameter("@KET", model.KET),
                new MySqlParameter("@GLU", model.GLU),
                new MySqlParameter("@PRO", model.PRO),
                new MySqlParameter("@UrineOther", model.UrineOther)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 新尿常规同步
        /// </summary>
        /// <param name="model"></param>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public bool Update(RecordsAssistCheckModel model, string barCode)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                         ARCHIVE_ASSISTCHECK  D
                                       SET 
                                         BLD=@BLD
                                        ,KET=@KET
                                        ,GLU=@GLU
                                        ,PRO=@PRO ");

            if (!string.IsNullOrEmpty(model.UrineOther)) builder.Append(",UrineOther=@UrineOther");
            else if (!string.IsNullOrEmpty(model.UrineOther) && model.UrineOther.Equals("陕西")) builder.Append(",UrineOther=REPLACE(UrineOther,'未配合检查','')");

            builder.Append(@" WHERE
                                    EXISTS
                                    (
                                        SELECT 
                                            ID 
                                        FROM
                                            ARCHIVE_CUSTOMERBASEINFO M
                                        WHERE M.ID = D.OutKey  ");

            if (string.IsNullOrEmpty(barCode)) builder.Append("AND M.IDCardNo = @IDCardNo) ");
            else builder.Append("AND M.CustomerID = @BarCode) ");            

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@BarCode",barCode),
                new MySqlParameter("@BLD", model.BLD),
                new MySqlParameter("@KET", model.KET),
                new MySqlParameter("@GLU", model.GLU),
                new MySqlParameter("@PRO", model.PRO),
                new MySqlParameter("@UrineOther", model.UrineOther),
                new MySqlParameter("@IDCardNo", model.IDCardNo)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 心电B超同步更新辅助检查
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="OutKey"></param>
        /// <param name="ECG"></param>
        /// <param name="ECGEx"></param>
        /// <param name="BChao"></param>
        /// <param name="BChaoEx"></param>
        /// <returns></returns>
        public bool UpdateByEcg(string IDCardNo, string OutKey, string ECG, string ECGEx, string BChao, string BChaoEx)
        {
            StringBuilder builder = new StringBuilder();
            string sql = "";

            builder.Append("UPDATE ARCHIVE_ASSISTCHECK SET ");

            if (ECG != "") sql += "ECG=@ECG, ECGEx=@ECGEx,";
            if (BChao != "") sql += "BChao=@BChao, BChaoEx=@BChaoEx,";

            builder.Append(sql.TrimEnd(','));

            if (builder.ToString() != "UPDATE ARCHIVE_ASSISTCHECK SET ")
            {
                builder.Append(@" WHERE IDCardNo = @IDCardNo
                                            AND OutKey = @OutKey ");
            }

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", IDCardNo),
                new MySqlParameter("@OutKey",OutKey),
                new MySqlParameter("@ECG", ECG),
                new MySqlParameter("@ECGEx", ECGEx),
                new MySqlParameter("@BChao", BChao),
                new MySqlParameter("@BChaoEx", BChaoEx)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// B超正常异常信息更新到健康体检中
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBC(RecordsAssistCheckModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                    ARCHIVE_ASSISTCHECK
                             SET 
                                     BCHAO=@BCHAO
                                    ,BCHAOEx=@BCHAOEx");

            if (model.BCHAOther != null && model.BCHAOther != "")
            {
                builder.Append(@"
                                    ,BCHAOther=@BCHAOther
                                    ,BCHAOtherEx=@BCHAOtherEx");
            }

            if (model.Other != null && model.Other != "")
            {
                builder.Append(@"
                                    ,Other=@Other");
            }

            builder.Append(@" WHERE
                                    OutKey = @OutKey ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@OutKey", model.OutKey),
                new MySqlParameter("@BCHAO", model.BCHAO),
                new MySqlParameter("@BCHAOEx", model.BCHAOEx),
                new MySqlParameter("@BCHAOther", model.BCHAOther),
                new MySqlParameter("@BCHAOtherEx", model.BCHAOtherEx),
                new MySqlParameter("@Other", model.Other)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 妇科B超更新查体其他
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBC(RecordsPhysicalExamModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                            ARCHIVE_PHYSICALEXAM
                                        SET 
                                            Other=@Other
                                        WHERE
                                            OutKey = @OutKey ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@OutKey", model.OutKey),
                new MySqlParameter("@Other", model.Other)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 双肾更新健康问题肾脏其他
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBC(RecordsHealthQuestionModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                            ARCHIVE_HEALTHQUESTION
                                        SET 
                                                RenalDis=(
                                                    CASE WHEN IFNULL(RenalDis,'')='' OR RenalDis='1' THEN '6'
	                                                    ELSE REPLACE(RenalDis,',6',',6') END
                                                )
                                                ,RenalOther=@RenalOther
                                        WHERE
                                            OutKey = @OutKey ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@OutKey", model.OutKey),
                new MySqlParameter("@RenalDis", model.RenalDis),
                new MySqlParameter("@RenalOther", model.RenalOther)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 其他系统疾病
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateQT(RecordsHealthQuestionModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                            ARCHIVE_HEALTHQUESTION D
                                        SET 
                                                ElseDis=(
                                                    CASE WHEN IFNULL(ElseDis,'')='' OR ElseDis='1' THEN '2'
	                                                    ELSE REPLACE(ElseDis,',2',',2') END
                                                )
                                                ,ElseOther=@ElseOther
                                        WHERE
                                            OutKey = @OutKey ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@OutKey", model.OutKey),
                new MySqlParameter("@ElseDis", model.ElseDis),
                new MySqlParameter("@ElseOther", model.ElseOther)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 更新既往史
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <param name="illOther"></param>
        /// <param name="diagnoseTime"></param>
        /// <returns></returns>
        public bool UpdateIllHistory(string idCardNo, string illOther, string diagnoseTime)
        {
            bool result = false;
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                    ARCHIVE_ILLNESSHISTORYINFO
                             SET 
                                     IllnessOther=@IllnessOther
                                     ,DiagnoseTime=@DiagnoseTime
                             WHERE
                                IDCardNo = @IDCardNo 
                                AND IllnessType='1'
                                AND IllnessName='13'");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", idCardNo),
                new MySqlParameter("@IllnessOther", illOther),
                new MySqlParameter("@DiagnoseTime", diagnoseTime)
            };

            result = (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);

            // 更新不到则新增
            if (!result)
            {
                builder.Clear();
                builder.Append(@"INSERT INTO
                                    ARCHIVE_ILLNESSHISTORYINFO
                                    (
                                        IDCardNo
                                        ,IllnessType
                                        ,IllnessName
                                        ,IllnessOther
                                        ,DiagnoseTime
                                    )
                                    VALUES
                                    (
                                        @IDCardNo
                                        ,'1'
                                        ,'13'
                                        ,@IllnessOther
                                        ,@DiagnoseTime
                                    ) ");

                result = (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
            }

            return result;
        }
    }
}
