
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class WomenGravidaPreAssistCheckDAL
    {
        public int Add(WomenGravidaPreAssistCheckModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_womengravidapreassistcheck(");
            builder.Append("CustomerID,RecordID,IDCardNo,HB,WBC,PLT,BloodOther,PRO,GLU,KET,BLD,UrineOthers,BloodType,RH,FPGL,SGPT,GOT,BP,TBIL,CB,SCR,BUN,VaginalSecretions,VaginalSecretionSothers,VaginalCleaess,HBSAG,HBSAB,HBEAG,HBEAB,HBCAB,LUES,HIV,BCHAO,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,AssistOther)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@HB,@WBC,@PLT,@BloodOther,@PRO,@GLU,@KET,@BLD,@UrineOthers,@BloodType,@RH,@FPGL,@SGPT,@GOT,@BP,@TBIL,@CB,@SCR,@BUN,@VaginalSecretions,@VaginalSecretionSothers,@VaginalCleaess,@HBSAG,@HBSAB,@HBEAG,@HBEAB,@HBCAB,@LUES,@HIV,@BCHAO,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,@AssistOther)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@HB", MySqlDbType.Decimal),
                new MySqlParameter("@WBC", MySqlDbType.Decimal), 
                new MySqlParameter("@PLT", MySqlDbType.Decimal), 
                new MySqlParameter("@BloodOther", MySqlDbType.String, 100),
                new MySqlParameter("@PRO", MySqlDbType.String, 10), 
                new MySqlParameter("@GLU", MySqlDbType.String, 10),
                new MySqlParameter("@KET", MySqlDbType.String, 10),
                new MySqlParameter("@BLD", MySqlDbType.String, 10), 
                new MySqlParameter("@UrineOthers", MySqlDbType.String, 100), 
                new MySqlParameter("@BloodType", MySqlDbType.String, 1),
                new MySqlParameter("@RH", MySqlDbType.String, 1), 
                new MySqlParameter("@FPGL", MySqlDbType.Decimal), 
                new MySqlParameter("@SGPT", MySqlDbType.Decimal), 
                new MySqlParameter("@GOT", MySqlDbType.Decimal), 
                new MySqlParameter("@BP", MySqlDbType.Decimal), 
                new MySqlParameter("@TBIL", MySqlDbType.Decimal), 
                new MySqlParameter("@CB", MySqlDbType.Decimal),
                new MySqlParameter("@SCR", MySqlDbType.Decimal), 
                new MySqlParameter("@BUN", MySqlDbType.Decimal),
                new MySqlParameter("@VaginalSecretions", MySqlDbType.String, 30),
                new MySqlParameter("@VaginalSecretionSothers", MySqlDbType.String, 100), 
                new MySqlParameter("@VaginalCleaess", MySqlDbType.String, 1), 
                new MySqlParameter("@HBSAG", MySqlDbType.String, 8), 
                new MySqlParameter("@HBSAB", MySqlDbType.String, 8), 
                new MySqlParameter("@HBEAG", MySqlDbType.String, 8), 
                new MySqlParameter("@HBEAB", MySqlDbType.String, 8), 
                new MySqlParameter("@HBCAB", MySqlDbType.String, 8), 
                new MySqlParameter("@LUES", MySqlDbType.String, 1), 
                new MySqlParameter("@HIV", MySqlDbType.String, 1), 
                new MySqlParameter("@BCHAO", MySqlDbType.String, 200),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@AssistOther", MySqlDbType.String, 500)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.HB;
            cmdParms[4].Value = model.WBC;
            cmdParms[5].Value = model.PlT;
            cmdParms[6].Value = model.BloodOther;
            cmdParms[7].Value = model.PRO;
            cmdParms[8].Value = model.GLU;
            cmdParms[9].Value = model.KET;
            cmdParms[10].Value = model.BLD;
            cmdParms[11].Value = model.UrineOthers;
            cmdParms[12].Value = model.BloodType;
            cmdParms[13].Value = model.RH;
            cmdParms[14].Value = model.FPGL;
            cmdParms[15].Value = model.SGPT;
            cmdParms[16].Value = model.GOT;
            cmdParms[17].Value = model.BP;
            cmdParms[18].Value = model.TBIL;
            cmdParms[19].Value = model.CB;
            cmdParms[20].Value = model.SCR;
            cmdParms[21].Value = model.BUN;
            cmdParms[22].Value = model.VaginalSecretions;
            cmdParms[23].Value = model.VaginalSecretionSothers;
            cmdParms[24].Value = model.VaginalCleaess;
            cmdParms[25].Value = model.HBSAG;
            cmdParms[26].Value = model.HBSAB;
            cmdParms[27].Value = model.HBEAG;
            cmdParms[28].Value = model.HBEAB;
            cmdParms[29].Value = model.HBCAB;
            cmdParms[30].Value = model.LUES;
            cmdParms[31].Value = model.HIV;
            cmdParms[32].Value = model.BCHAO;
            cmdParms[33].Value = model.CreatedBy;
            cmdParms[34].Value = model.CreatedDate;
            cmdParms[35].Value = model.LastUpdateBy;
            cmdParms[36].Value = model.LastUpdateDate;
            cmdParms[37].Value = model.IsDel;
            cmdParms[38].Value = model.AssistOther;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(WomenGravidaPreAssistCheckModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_womengravidapreassistcheck(");
            builder.Append("CustomerID,RecordID,IDCardNo,HB,WBC,PLT,BloodOther,PRO,GLU,KET,BLD,UrineOthers,BloodType,RH,FPGL,SGPT,GOT,BP,TBIL,CB,SCR,BUN,VaginalSecretions,VaginalSecretionSothers,VaginalCleaess,HBSAG,HBSAB,HBEAG,HBEAB,HBCAB,LUES,HIV,BCHAO,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,AssistOther)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@HB,@WBC,@PLT,@BloodOther,@PRO,@GLU,@KET,@BLD,@UrineOthers,@BloodType,@RH,@FPGL,@SGPT,@GOT,@BP,@TBIL,@CB,@SCR,@BUN,@VaginalSecretions,@VaginalSecretionSothers,@VaginalCleaess,@HBSAG,@HBSAB,@HBEAG,@HBEAB,@HBCAB,@LUES,@HIV,@BCHAO,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,@AssistOther)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@HB", MySqlDbType.Decimal),
                new MySqlParameter("@WBC", MySqlDbType.Decimal), 
                new MySqlParameter("@PLT", MySqlDbType.Decimal), 
                new MySqlParameter("@BloodOther", MySqlDbType.String, 100),
                new MySqlParameter("@PRO", MySqlDbType.String, 10), 
                new MySqlParameter("@GLU", MySqlDbType.String, 10),
                new MySqlParameter("@KET", MySqlDbType.String, 10),
                new MySqlParameter("@BLD", MySqlDbType.String, 10), 
                new MySqlParameter("@UrineOthers", MySqlDbType.String, 100), 
                new MySqlParameter("@BloodType", MySqlDbType.String, 1),
                new MySqlParameter("@RH", MySqlDbType.String, 1), 
                new MySqlParameter("@FPGL", MySqlDbType.Decimal), 
                new MySqlParameter("@SGPT", MySqlDbType.Decimal), 
                new MySqlParameter("@GOT", MySqlDbType.Decimal), 
                new MySqlParameter("@BP", MySqlDbType.Decimal), 
                new MySqlParameter("@TBIL", MySqlDbType.Decimal), 
                new MySqlParameter("@CB", MySqlDbType.Decimal),
                new MySqlParameter("@SCR", MySqlDbType.Decimal), 
                new MySqlParameter("@BUN", MySqlDbType.Decimal),
                new MySqlParameter("@VaginalSecretions", MySqlDbType.String, 30),
                new MySqlParameter("@VaginalSecretionSothers", MySqlDbType.String, 100), 
                new MySqlParameter("@VaginalCleaess", MySqlDbType.String, 1), 
                new MySqlParameter("@HBSAG", MySqlDbType.String, 8), 
                new MySqlParameter("@HBSAB", MySqlDbType.String, 8), 
                new MySqlParameter("@HBEAG", MySqlDbType.String, 8), 
                new MySqlParameter("@HBEAB", MySqlDbType.String, 8), 
                new MySqlParameter("@HBCAB", MySqlDbType.String, 8), 
                new MySqlParameter("@LUES", MySqlDbType.String, 1), 
                new MySqlParameter("@HIV", MySqlDbType.String, 1), 
                new MySqlParameter("@BCHAO", MySqlDbType.String, 200),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@AssistOther", MySqlDbType.String, 500)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.HB;
            cmdParms[4].Value = model.WBC;
            cmdParms[5].Value = model.PlT;
            cmdParms[6].Value = model.BloodOther;
            cmdParms[7].Value = model.PRO;
            cmdParms[8].Value = model.GLU;
            cmdParms[9].Value = model.KET;
            cmdParms[10].Value = model.BLD;
            cmdParms[11].Value = model.UrineOthers;
            cmdParms[12].Value = model.BloodType;
            cmdParms[13].Value = model.RH;
            cmdParms[14].Value = model.FPGL;
            cmdParms[15].Value = model.SGPT;
            cmdParms[16].Value = model.GOT;
            cmdParms[17].Value = model.BP;
            cmdParms[18].Value = model.TBIL;
            cmdParms[19].Value = model.CB;
            cmdParms[20].Value = model.SCR;
            cmdParms[21].Value = model.BUN;
            cmdParms[22].Value = model.VaginalSecretions;
            cmdParms[23].Value = model.VaginalSecretionSothers;
            cmdParms[24].Value = model.VaginalCleaess;
            cmdParms[25].Value = model.HBSAG;
            cmdParms[26].Value = model.HBSAB;
            cmdParms[27].Value = model.HBEAG;
            cmdParms[28].Value = model.HBEAB;
            cmdParms[29].Value = model.HBCAB;
            cmdParms[30].Value = model.LUES;
            cmdParms[31].Value = model.HIV;
            cmdParms[32].Value = model.BCHAO;
            cmdParms[33].Value = model.CreatedBy;
            cmdParms[34].Value = model.CreatedDate;
            cmdParms[35].Value = model.LastUpdateBy;
            cmdParms[36].Value = model.LastUpdateDate;
            cmdParms[37].Value = model.IsDel;
            cmdParms[38].Value = model.AssistOther;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public WomenGravidaPreAssistCheckModel DataRowToModel(DataRow row)
        {
            WomenGravidaPreAssistCheckModel gravida_pre_assistcheck = new WomenGravidaPreAssistCheckModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    gravida_pre_assistcheck.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["HB"] != null) && (row["HB"] != DBNull.Value)) && (row["HB"].ToString() != ""))
                {
                    gravida_pre_assistcheck.HB = new decimal?(decimal.Parse(row["HB"].ToString()));
                }
                if (((row["WBC"] != null) && (row["WBC"] != DBNull.Value)) && (row["WBC"].ToString() != ""))
                {
                    gravida_pre_assistcheck.WBC = new decimal?(decimal.Parse(row["WBC"].ToString()));
                }
                if (((row["PLT"] != null) && (row["PLT"] != DBNull.Value)) && (row["PLT"].ToString() != ""))
                {
                    gravida_pre_assistcheck.PlT = new decimal?(decimal.Parse(row["PLT"].ToString()));
                }
                if ((row["BloodOther"] != null) && (row["BloodOther"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.BloodOther = row["BloodOther"].ToString();
                }
                if ((row["PRO"] != null) && (row["PRO"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.PRO = row["PRO"].ToString();
                }
                if ((row["GLU"] != null) && (row["GLU"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.GLU = row["GLU"].ToString();
                }
                if ((row["KET"] != null) && (row["KET"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.KET = row["KET"].ToString();
                }
                if ((row["BLD"] != null) && (row["BLD"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.BLD = row["BLD"].ToString();
                }
                if ((row["UrineOthers"] != null) && (row["UrineOthers"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.UrineOthers = row["UrineOthers"].ToString();
                }
                if ((row["BloodType"] != null) && (row["BloodType"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.BloodType = row["BloodType"].ToString();
                }
                if ((row["RH"] != null) && (row["RH"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.RH = row["RH"].ToString();
                }
                if (((row["FPGL"] != null) && (row["FPGL"] != DBNull.Value)) && (row["FPGL"].ToString() != ""))
                {
                    gravida_pre_assistcheck.FPGL = new decimal?(decimal.Parse(row["FPGL"].ToString()));
                }
                if (((row["SGPT"] != null) && (row["SGPT"] != DBNull.Value)) && (row["SGPT"].ToString() != ""))
                {
                    gravida_pre_assistcheck.SGPT = new decimal?(decimal.Parse(row["SGPT"].ToString()));
                }
                if (((row["GOT"] != null) && (row["GOT"] != DBNull.Value)) && (row["GOT"].ToString() != ""))
                {
                    gravida_pre_assistcheck.GOT = new decimal?(decimal.Parse(row["GOT"].ToString()));
                }
                if (((row["BP"] != null) && (row["BP"] != DBNull.Value)) && (row["BP"].ToString() != ""))
                {
                    gravida_pre_assistcheck.BP = new decimal?(decimal.Parse(row["BP"].ToString()));
                }
                if (((row["TBIL"] != null) && (row["TBIL"] != DBNull.Value)) && (row["TBIL"].ToString() != ""))
                {
                    gravida_pre_assistcheck.TBIL = new decimal?(decimal.Parse(row["TBIL"].ToString()));
                }
                if (((row["CB"] != null) && (row["CB"] != DBNull.Value)) && (row["CB"].ToString() != ""))
                {
                    gravida_pre_assistcheck.CB = new decimal?(decimal.Parse(row["CB"].ToString()));
                }
                if (((row["SCR"] != null) && (row["SCR"] != DBNull.Value)) && (row["SCR"].ToString() != ""))
                {
                    gravida_pre_assistcheck.SCR = new decimal?(decimal.Parse(row["SCR"].ToString()));
                }
                if (((row["BUN"] != null) && (row["BUN"] != DBNull.Value)) && (row["BUN"].ToString() != ""))
                {
                    gravida_pre_assistcheck.BUN = new decimal?(decimal.Parse(row["BUN"].ToString()));
                }
                if ((row["VaginalSecretions"] != null) && (row["VaginalSecretions"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.VaginalSecretions = row["VaginalSecretions"].ToString();
                }
                if ((row["VaginalSecretionSothers"] != null) && (row["VaginalSecretionSothers"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.VaginalSecretionSothers = row["VaginalSecretionSothers"].ToString();
                }
                if ((row["VaginalCleaess"] != null) && (row["VaginalCleaess"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.VaginalCleaess = row["VaginalCleaess"].ToString();
                }
                if ((row["HBSAG"] != null) && (row["HBSAG"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.HBSAG = row["HBSAG"].ToString();
                }
                if ((row["HBSAB"] != null) && (row["HBSAB"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.HBSAB = row["HBSAB"].ToString();
                }
                if ((row["HBEAG"] != null) && (row["HBEAG"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.HBEAG = row["HBEAG"].ToString();
                }
                if ((row["HBEAB"] != null) && (row["HBEAB"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.HBEAB = row["HBEAB"].ToString();
                }
                if ((row["HBCAB"] != null) && (row["HBCAB"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.HBCAB = row["HBCAB"].ToString();
                }
                if ((row["LUES"] != null) && (row["LUES"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.LUES = row["LUES"].ToString();
                }
                if ((row["HIV"] != null) && (row["HIV"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.HIV = row["HIV"].ToString();
                }
                if ((row["BCHAO"] != null) && (row["BCHAO"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.BCHAO = row["BCHAO"].ToString();
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    gravida_pre_assistcheck.CreatedBy = new decimal?(decimal.Parse(row["CreatedBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    gravida_pre_assistcheck.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    gravida_pre_assistcheck.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    gravida_pre_assistcheck.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.IsDel = row["IsDel"].ToString();
                }
                if ((row["AssistOther"] != null) && (row["AssistOther"] != DBNull.Value))
                {
                    gravida_pre_assistcheck.AssistOther = row["AssistOther"].ToString();
                }
            }
            return gravida_pre_assistcheck;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_womengravidapreassistcheck ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_womengravidapreassistcheck ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_womengravidapreassistcheck");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,HB,WBC,PLT,BloodOther,PRO,GLU,KET,BLD,UrineOthers,BloodType,RH,FPGL,SGPT,GOT,BP,TBIL,CB,SCR,BUN,VaginalSecretions,VaginalSecretionSothers,VaginalCleaess,HBSAG,HBSAB,HBEAG,HBEAB,HBCAB,LUES,HIV,BCHAO,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,AssistOther ");
            builder.Append(" FROM tbl_womengravidapreassistcheck ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM ( ");
            builder.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }
            builder.Append(")AS Row, T.*  from tbl_womengravidapreassistcheck T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("ID", "tbl_womengravidapreassistcheck");
        }

        public WomenGravidaPreAssistCheckModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,HB,WBC,PLT,BloodOther,PRO,GLU,KET,BLD,UrineOthers,BloodType,RH,FPGL,SGPT,GOT,BP,TBIL,CB,SCR,BUN,VaginalSecretions,VaginalSecretionSothers,VaginalCleaess,HBSAG,HBSAB,HBEAG,HBEAB,HBCAB,LUES,HIV,BCHAO,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,AssistOther from tbl_womengravidapreassistcheck ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new WomenGravidaPreAssistCheckModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM tbl_womengravidapreassistcheck ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public bool Update(WomenGravidaPreAssistCheckModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_womengravidapreassistcheck set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("HB=@HB,");
            builder.Append("WBC=@WBC,");
            builder.Append("PLT=@PLT,");
            builder.Append("BloodOther=@BloodOther,");
            builder.Append("PRO=@PRO,");
            builder.Append("GLU=@GLU,");
            builder.Append("KET=@KET,");
            builder.Append("BLD=@BLD,");
            builder.Append("UrineOthers=@UrineOthers,");
            builder.Append("BloodType=@BloodType,");
            builder.Append("RH=@RH,");
            builder.Append("FPGL=@FPGL,");
            builder.Append("SGPT=@SGPT,");
            builder.Append("GOT=@GOT,");
            builder.Append("BP=@BP,");
            builder.Append("TBIL=@TBIL,");
            builder.Append("CB=@CB,");
            builder.Append("SCR=@SCR,");
            builder.Append("BUN=@BUN,");
            builder.Append("VaginalSecretions=@VaginalSecretions,");
            builder.Append("VaginalSecretionSothers=@VaginalSecretionSothers,");
            builder.Append("VaginalCleaess=@VaginalCleaess,");
            builder.Append("HBSAG=@HBSAG,");
            builder.Append("HBSAB=@HBSAB,");
            builder.Append("HBEAG=@HBEAG,");
            builder.Append("HBEAB=@HBEAB,");
            builder.Append("HBCAB=@HBCAB,");
            builder.Append("LUES=@LUES,");
            builder.Append("HIV=@HIV,");
            builder.Append("BCHAO=@BCHAO,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("AssistOther=@AssistOther ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                 new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@HB", MySqlDbType.Decimal),
                new MySqlParameter("@WBC", MySqlDbType.Decimal), 
                new MySqlParameter("@PLT", MySqlDbType.Decimal), 
                new MySqlParameter("@BloodOther", MySqlDbType.String, 100),
                new MySqlParameter("@PRO", MySqlDbType.String, 10), 
                new MySqlParameter("@GLU", MySqlDbType.String, 10),
                new MySqlParameter("@KET", MySqlDbType.String, 10),
                new MySqlParameter("@BLD", MySqlDbType.String, 10), 
                new MySqlParameter("@UrineOthers", MySqlDbType.String, 100), 
                new MySqlParameter("@BloodType", MySqlDbType.String, 1),
                new MySqlParameter("@RH", MySqlDbType.String, 1), 
                new MySqlParameter("@FPGL", MySqlDbType.Decimal), 
                new MySqlParameter("@SGPT", MySqlDbType.Decimal), 
                new MySqlParameter("@GOT", MySqlDbType.Decimal), 
                new MySqlParameter("@BP", MySqlDbType.Decimal), 
                new MySqlParameter("@TBIL", MySqlDbType.Decimal), 
                new MySqlParameter("@CB", MySqlDbType.Decimal),
                new MySqlParameter("@SCR", MySqlDbType.Decimal), 
                new MySqlParameter("@BUN", MySqlDbType.Decimal),
                new MySqlParameter("@VaginalSecretions", MySqlDbType.String, 30),
                new MySqlParameter("@VaginalSecretionSothers", MySqlDbType.String, 100), 
                new MySqlParameter("@VaginalCleaess", MySqlDbType.String, 1), 
                new MySqlParameter("@HBSAG", MySqlDbType.String, 8), 
                new MySqlParameter("@HBSAB", MySqlDbType.String, 8), 
                new MySqlParameter("@HBEAG", MySqlDbType.String, 8), 
                new MySqlParameter("@HBEAB", MySqlDbType.String, 8), 
                new MySqlParameter("@HBCAB", MySqlDbType.String, 8), 
                new MySqlParameter("@LUES", MySqlDbType.String, 1), 
                new MySqlParameter("@HIV", MySqlDbType.String, 1), 
                new MySqlParameter("@BCHAO", MySqlDbType.String, 200),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@AssistOther", MySqlDbType.String, 500),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.HB;
            cmdParms[4].Value = model.WBC;
            cmdParms[5].Value = model.PlT;
            cmdParms[6].Value = model.BloodOther;
            cmdParms[7].Value = model.PRO;
            cmdParms[8].Value = model.GLU;
            cmdParms[9].Value = model.KET;
            cmdParms[10].Value = model.BLD;
            cmdParms[11].Value = model.UrineOthers;
            cmdParms[12].Value = model.BloodType;
            cmdParms[13].Value = model.RH;
            cmdParms[14].Value = model.FPGL;
            cmdParms[15].Value = model.SGPT;
            cmdParms[16].Value = model.GOT;
            cmdParms[17].Value = model.BP;
            cmdParms[18].Value = model.TBIL;
            cmdParms[19].Value = model.CB;
            cmdParms[20].Value = model.SCR;
            cmdParms[21].Value = model.BUN;
            cmdParms[22].Value = model.VaginalSecretions;
            cmdParms[23].Value = model.VaginalSecretionSothers;
            cmdParms[24].Value = model.VaginalCleaess;
            cmdParms[25].Value = model.HBSAG;
            cmdParms[26].Value = model.HBSAB;
            cmdParms[27].Value = model.HBEAG;
            cmdParms[28].Value = model.HBEAB;
            cmdParms[29].Value = model.HBCAB;
            cmdParms[30].Value = model.LUES;
            cmdParms[31].Value = model.HIV;
            cmdParms[32].Value = model.BCHAO;
            cmdParms[33].Value = model.CreatedBy;
            cmdParms[34].Value = model.CreatedDate;
            cmdParms[35].Value = model.LastUpdateBy;
            cmdParms[36].Value = model.LastUpdateDate;
            cmdParms[37].Value = model.IsDel;
            cmdParms[38].Value = model.AssistOther;
            cmdParms[39].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(WomenGravidaPreAssistCheckModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_womengravidapreassistcheck set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("HB=@HB,");
            builder.Append("WBC=@WBC,");
            builder.Append("PLT=@PLT,");
            builder.Append("BloodOther=@BloodOther,");
            builder.Append("PRO=@PRO,");
            builder.Append("GLU=@GLU,");
            builder.Append("KET=@KET,");
            builder.Append("BLD=@BLD,");
            builder.Append("UrineOthers=@UrineOthers,");
            builder.Append("BloodType=@BloodType,");
            builder.Append("RH=@RH,");
            builder.Append("FPGL=@FPGL,");
            builder.Append("SGPT=@SGPT,");
            builder.Append("GOT=@GOT,");
            builder.Append("BP=@BP,");
            builder.Append("TBIL=@TBIL,");
            builder.Append("CB=@CB,");
            builder.Append("SCR=@SCR,");
            builder.Append("BUN=@BUN,");
            builder.Append("VaginalSecretions=@VaginalSecretions,");
            builder.Append("VaginalSecretionSothers=@VaginalSecretionSothers,");
            builder.Append("VaginalCleaess=@VaginalCleaess,");
            builder.Append("HBSAG=@HBSAG,");
            builder.Append("HBSAB=@HBSAB,");
            builder.Append("HBEAG=@HBEAG,");
            builder.Append("HBEAB=@HBEAB,");
            builder.Append("HBCAB=@HBCAB,");
            builder.Append("LUES=@LUES,");
            builder.Append("HIV=@HIV,");
            builder.Append("BCHAO=@BCHAO,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("AssistOther=@AssistOther ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                 new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@HB", MySqlDbType.Decimal),
                new MySqlParameter("@WBC", MySqlDbType.Decimal), 
                new MySqlParameter("@PLT", MySqlDbType.Decimal), 
                new MySqlParameter("@BloodOther", MySqlDbType.String, 100),
                new MySqlParameter("@PRO", MySqlDbType.String, 10), 
                new MySqlParameter("@GLU", MySqlDbType.String, 10),
                new MySqlParameter("@KET", MySqlDbType.String, 10),
                new MySqlParameter("@BLD", MySqlDbType.String, 10), 
                new MySqlParameter("@UrineOthers", MySqlDbType.String, 100), 
                new MySqlParameter("@BloodType", MySqlDbType.String, 1),
                new MySqlParameter("@RH", MySqlDbType.String, 1), 
                new MySqlParameter("@FPGL", MySqlDbType.Decimal), 
                new MySqlParameter("@SGPT", MySqlDbType.Decimal), 
                new MySqlParameter("@GOT", MySqlDbType.Decimal), 
                new MySqlParameter("@BP", MySqlDbType.Decimal), 
                new MySqlParameter("@TBIL", MySqlDbType.Decimal), 
                new MySqlParameter("@CB", MySqlDbType.Decimal),
                new MySqlParameter("@SCR", MySqlDbType.Decimal), 
                new MySqlParameter("@BUN", MySqlDbType.Decimal),
                new MySqlParameter("@VaginalSecretions", MySqlDbType.String, 30),
                new MySqlParameter("@VaginalSecretionSothers", MySqlDbType.String, 100), 
                new MySqlParameter("@VaginalCleaess", MySqlDbType.String, 1), 
                new MySqlParameter("@HBSAG", MySqlDbType.String, 8), 
                new MySqlParameter("@HBSAB", MySqlDbType.String, 8), 
                new MySqlParameter("@HBEAG", MySqlDbType.String, 8), 
                new MySqlParameter("@HBEAB", MySqlDbType.String, 8), 
                new MySqlParameter("@HBCAB", MySqlDbType.String, 8), 
                new MySqlParameter("@LUES", MySqlDbType.String, 1), 
                new MySqlParameter("@HIV", MySqlDbType.String, 1), 
                new MySqlParameter("@BCHAO", MySqlDbType.String, 200),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@AssistOther", MySqlDbType.String, 500)
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.HB;
            cmdParms[4].Value = model.WBC;
            cmdParms[5].Value = model.PlT;
            cmdParms[6].Value = model.BloodOther;
            cmdParms[7].Value = model.PRO;
            cmdParms[8].Value = model.GLU;
            cmdParms[9].Value = model.KET;
            cmdParms[10].Value = model.BLD;
            cmdParms[11].Value = model.UrineOthers;
            cmdParms[12].Value = model.BloodType;
            cmdParms[13].Value = model.RH;
            cmdParms[14].Value = model.FPGL;
            cmdParms[15].Value = model.SGPT;
            cmdParms[16].Value = model.GOT;
            cmdParms[17].Value = model.BP;
            cmdParms[18].Value = model.TBIL;
            cmdParms[19].Value = model.CB;
            cmdParms[20].Value = model.SCR;
            cmdParms[21].Value = model.BUN;
            cmdParms[22].Value = model.VaginalSecretions;
            cmdParms[23].Value = model.VaginalSecretionSothers;
            cmdParms[24].Value = model.VaginalCleaess;
            cmdParms[25].Value = model.HBSAG;
            cmdParms[26].Value = model.HBSAB;
            cmdParms[27].Value = model.HBEAG;
            cmdParms[28].Value = model.HBEAB;
            cmdParms[29].Value = model.HBCAB;
            cmdParms[30].Value = model.LUES;
            cmdParms[31].Value = model.HIV;
            cmdParms[32].Value = model.BCHAO;
            cmdParms[33].Value = model.CreatedBy;
            cmdParms[34].Value = model.CreatedDate;
            cmdParms[35].Value = model.LastUpdateBy;
            cmdParms[36].Value = model.LastUpdateDate;
            cmdParms[37].Value = model.IsDel;
            cmdParms[38].Value = model.AssistOther;
            //cmdParms[38].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

