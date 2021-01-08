namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    using System.Text.RegularExpressions;

    public class RecordsAssistCheckDAL
    {
        public int Add(RecordsAssistCheckModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordsassistcheck(");
            builder.Append("PhysicalID,IDCardNo,HB,WBC,PLT,PRO,GLU,KET,BLD,FPGL,ECG,ALBUMIN,FOB,HBALC,HBSAG,SGPT,GOT,BP,TBIL,CB,SCR,BUN,PC,HYPE,TC,TG,LowCho,HeiCho,CHESTX,BCHAO,BloodOther,UrineOther,Other,CERVIX,GT,ECGEx,CHESTXEx,BCHAOEx,CERVIXEx,FPGDL,OutKey,UA,HCY,BCHAOther,BCHAOtherEx,BloodType,RH,TP,GLB,AG,IBIL)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@HB,@WBC,@PLT,@PRO,@GLU,@KET,@BLD,@FPGL,@ECG,@ALBUMIN,@FOB,@HBALC,@HBSAG,@SGPT,@GOT,@BP,@TBIL,@CB,@SCR,@BUN,@PC,@HYPE,@TC,@TG,@LowCho,@HeiCho,@CHESTX,@BCHAO,@BloodOther,@UrineOther,@Other,@CERVIX,@GT,@ECGEx,@CHESTXEx,@BCHAOEx,@CERVIXEx,@FPGDL,@OutKey,@UA,@HCY,@BCHAOther,@BCHAOtherEx,@BloodType,@RH,@TP,@GLB,@AG,@IBIL)");
            builder.Append(";select @@IDENTITY");
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
                new MySqlParameter("@HCY", MySqlDbType.Decimal),
                new MySqlParameter("@BCHAOther", MySqlDbType.String, 500),
                new MySqlParameter("@BCHAOtherEx", MySqlDbType.String, 500),
                new MySqlParameter("@BloodType", MySqlDbType.String, 1),
                new MySqlParameter("@RH", MySqlDbType.String, 1),
                new MySqlParameter("@TP", MySqlDbType.Decimal), 
                new MySqlParameter("@GLB", MySqlDbType.Decimal), 
                new MySqlParameter("@AG", MySqlDbType.Decimal), 
                new MySqlParameter("@IBIL", MySqlDbType.Decimal)
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
            cmdParms[42].Value = model.HCY;
            cmdParms[43].Value = model.BCHAOther;
            cmdParms[44].Value = model.BCHAOtherEx;
            cmdParms[45].Value = model.BloodType;
            cmdParms[46].Value = model.RH;
            cmdParms[47].Value = model.TP;
            cmdParms[48].Value = model.GLB;
            cmdParms[49].Value = model.AG;
            cmdParms[50].Value = model.IBIL;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * ");
            builder.Append(" FROM tbl_recordsassistcheck ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public bool Update(RecordsAssistCheckModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordsassistcheck set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("HB=@HB,");
            builder.Append("WBC=@WBC,");
            builder.Append("PLT=@PLT,");
            builder.Append("PRO=@PRO,");
            builder.Append("GLU=@GLU,");
            builder.Append("KET=@KET,");
            builder.Append("BLD=@BLD,");
            builder.Append("FPGL=@FPGL,");
            builder.Append("ECG=@ECG,");
            builder.Append("ALBUMIN=@ALBUMIN,");
            builder.Append("FOB=@FOB,");
            builder.Append("HBALC=@HBALC,");
            builder.Append("HBSAG=@HBSAG,");
            builder.Append("SGPT=@SGPT,");
            builder.Append("GOT=@GOT,");
            builder.Append("BP=@BP,");
            builder.Append("TBIL=@TBIL,");
            builder.Append("CB=@CB,");
            builder.Append("SCR=@SCR,");
            builder.Append("BUN=@BUN,");
            builder.Append("PC=@PC,");
            builder.Append("HYPE=@HYPE,");
            builder.Append("TC=@TC,");
            builder.Append("TG=@TG,");
            builder.Append("LowCho=@LowCho,");
            builder.Append("HeiCho=@HeiCho,");
            builder.Append("CHESTX=@CHESTX,");
            builder.Append("BCHAO=@BCHAO,");
            builder.Append("BloodOther=@BloodOther,");
            builder.Append("UrineOther=@UrineOther,");
            builder.Append("Other=@Other,");
            builder.Append("CERVIX=@CERVIX,");
            builder.Append("GT=@GT,");
            builder.Append("ECGEx=@ECGEx,");
            builder.Append("CHESTXEx=@CHESTXEx,");
            builder.Append("BCHAOEx=@BCHAOEx,");
            builder.Append("CERVIXEx=@CERVIXEx,");
            builder.Append("FPGDL=@FPGDL,UA=@UA,HCY=@HCY,BCHAOther=@BCHAOther,BCHAOtherEx=@BCHAOtherEx,");
            builder.Append("BloodType=@BloodType,");
            builder.Append("RH=@RH,");
            builder.Append("TP=@TP,");
            builder.Append("GLB=@GLB,");
            builder.Append("AG=@AG,");
            builder.Append("IBIL=@IBIL ");
            builder.Append(" where OutKey=@OutKey");
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
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 8),
                new MySqlParameter("@UA", MySqlDbType.String, 500),
                
                new MySqlParameter("@HCY", MySqlDbType.Decimal),
                new MySqlParameter("@BCHAOther", MySqlDbType.String, 500),
                new MySqlParameter("@BCHAOtherEx", MySqlDbType.String, 500),
                new MySqlParameter("@BloodType", MySqlDbType.String, 1),
                new MySqlParameter("@RH", MySqlDbType.String, 1),
                new MySqlParameter("@TP", MySqlDbType.Decimal),
                new MySqlParameter("@GLB", MySqlDbType.Decimal), 
                new MySqlParameter("@AG", MySqlDbType.Decimal), 
                new MySqlParameter("@IBIL", MySqlDbType.Decimal)
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
            cmdParms[40].Value = model.OutKey;
            cmdParms[41].Value = model.UA;
            //HCY,BCHAOther,BCHAOtherEx
            cmdParms[42].Value = model.HCY;
            cmdParms[43].Value = model.BCHAOther;
            cmdParms[44].Value = model.BCHAOtherEx;
            cmdParms[45].Value = model.BloodType;
            cmdParms[46].Value = model.RH;
            cmdParms[47].Value = model.TP;
            cmdParms[48].Value = model.GLB;
            cmdParms[49].Value = model.AG;
            cmdParms[50].Value = model.IBIL;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet GetModelByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_recordsassistcheck ");
            builder.Append(" WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.String) };
            cmdParms[0].Value = OutKey;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        public bool ExistsOutKey(string IDCardNo, int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_recordsassistcheck");
            builder.Append(" where IDCardNo=@IDCardNo ");
            builder.Append(" and OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String) ,
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) 
            };
            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = OutKey;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
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
                                         tbl_recordsassistcheck  D
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
                                        tbl_recordscustomerbaseinfo M
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
        /// 血糖同步
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByMiniSTPad(RecordsAssistCheckModel model, string checkDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"UPDATE 
                                    tbl_recordsassistcheck  D
                             SET 
                                    FPGL=@FPGL
                               
                             WHERE
                                    EXISTS
                                    (
                                        SELECT 
                                            ID 
                                        FROM
                                        tbl_recordscustomerbaseinfo M
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

        /// <summary>
        /// 判断是数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNum(string value)
        {
            value = string.IsNullOrEmpty(value) ? "" : value;
            return Regex.IsMatch(value, @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$");
        }

        /// <summary>
        /// 更新辅助检查
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

                sb.Append("UPDATE tbl_recordsassistcheck D SET ");

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
                    else
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

                // 尿白细胞
                if (model.LEU != "") sb.Append("UrineOther='" + model.LEU + "',");

                #endregion

                if (sb.ToString() != "UPDATE tbl_recordsassistcheck D SET ")
                {
                    string upStr = sb.ToString().Substring(0, sb.ToString().Length - 1);
                    upStr += " WHERE D.OutKey = (SELECT M.ID FROM tbl_recordscustomerbaseinfo M ";
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

                sb.Append("UPDATE tbl_recordsassistcheck D SET ");

                if (model.PRO != "") sb.Append("PRO='" + model.PRO + "',");
                if (model.GLU != "") sb.Append("GLU='" + model.GLU + "',");
                if (model.KET != "") sb.Append("KET='" + model.KET + "',");
                if (model.BLD != "") sb.Append("BLD='" + model.BLD + "',");
                if (model.LEU != "") sb.Append("UrineOther='" + model.LEU + "',");

                #endregion

                if (sb.ToString() != "UPDATE tbl_recordsassistcheck D SET ")
                {
                    string upStr = sb.ToString().Substring(0, sb.ToString().Length - 1);
                    upStr += " WHERE D.OutKey = (SELECT M.ID FROM tbl_recordscustomerbaseinfo M ";
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

                sb.Append("UPDATE tbl_recordsgeneralcondition D SET ");

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

                if (sb.ToString() != "UPDATE tbl_recordsgeneralcondition D SET ")
                {
                    string upStr = sb.ToString().Substring(0, sb.ToString().Length - 1);
                    upStr += " WHERE D.OutKey = (SELECT M.ID FROM tbl_recordscustomerbaseinfo M ";
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
        /// 更新血球
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateXQ(DataModel model)
        {
            int successNum = 0;

            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE tbl_recordsxq SET ");

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

            if (sb.ToString() != "UPDATE tbl_recordsxq SET ")
            {
                string str = sb.ToString().Trim().TrimEnd(',');
                str += " WHERE IDCardNo='" + model.IDCardNo + "' AND TestTime='" + model.TestTime + "'";

                successNum = MySQLHelper.ExecuteSql(str);
            }
            else successNum = -2;

            return successNum;
        }
    }
}