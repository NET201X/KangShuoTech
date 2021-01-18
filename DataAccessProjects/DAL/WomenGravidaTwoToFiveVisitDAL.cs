using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class WomenGravidaTwoToFiveVisitDAL
    {
        public int Add(WomenGravidaTwoToFiveVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into GRAVIDA_TWO2FIVE_FOLLOWUP(");
            builder.Append("CustomerID,RecordID,IDCardNo,Times,FollowupDate,PregancyWeeks,ChiefComPlaint,Weight,UteruslowHeight,AbdominalCirumference,FetusPosition,FHR,HBloodPressure,LBloodPressure,HB,AssistanTexam,Classification,ClassificationEx,Advising,AdvisingOther,Referral,ReferralReason,ReferralOrg,PRO,NextFollowUpDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,");
            builder.Append("FollowupWay,PrenatalOrg,ReferralContacts,ReferralContactsTel,ReferralResult,FreeSerumCheck,SerumCheckResult) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Times,@FollowupDate,@PregancyWeeks,@ChiefComPlaint,@Weight,@UteruslowHeight,@AbdominalCirumference,@FetusPosition,@FHR,@HBloodPressure,@LBloodPressure,@HB,@AssistanTexam,@Classification,@ClassificationEx,@Advising,@AdvisingOther,@Referral,@ReferralReason,@ReferralOrg,@PRO,@NextFollowUpDate,@FollowUpDoctor,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,");
            builder.Append("@FollowupWay,@PrenatalOrg,@ReferralContacts,@ReferralContactsTel,@ReferralResult,@FreeSerumCheck,@SerumCheckResult) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Times", MySqlDbType.Decimal),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date),
                new MySqlParameter("@PregancyWeeks", MySqlDbType.Decimal), 
                new MySqlParameter("@ChiefComPlaint", MySqlDbType.String, 200), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@UteruslowHeight", MySqlDbType.Decimal), 
                new MySqlParameter("@AbdominalCirumference", MySqlDbType.Decimal), 
                new MySqlParameter("@FetusPosition", MySqlDbType.String, 100),
                new MySqlParameter("@FHR", MySqlDbType.Decimal), 
                new MySqlParameter("@HBloodPressure", MySqlDbType.Decimal),
                new MySqlParameter("@LBloodPressure", MySqlDbType.Decimal), 
                new MySqlParameter("@HB", MySqlDbType.Decimal), 
                new MySqlParameter("@AssistanTexam", MySqlDbType.String, 200), 
                new MySqlParameter("@Classification", MySqlDbType.String, 1), 
                new MySqlParameter("@ClassificationEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Advising", MySqlDbType.String, 30), 
                new MySqlParameter("@AdvisingOther", MySqlDbType.String, 200), 
                new MySqlParameter("@Referral", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@PRO", MySqlDbType.String, 10), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@FollowupWay", MySqlDbType.String, 1),
                new MySqlParameter("@PrenatalOrg", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContactsTel", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1),
                new MySqlParameter("@FreeSerumCheck", MySqlDbType.String, 1),
                new MySqlParameter("@SerumCheckResult", MySqlDbType.String, 20)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Times;
            cmdParms[4].Value = model.FollowupDate;
            cmdParms[5].Value = model.PregancyWeeks;
            cmdParms[6].Value = model.ChiefComPlaint;
            cmdParms[7].Value = model.Weight;
            cmdParms[8].Value = model.UteruslowHeight;
            cmdParms[9].Value = model.AbdominalCirumference;
            cmdParms[10].Value = model.FetusPosition;
            cmdParms[11].Value = model.FHR;
            cmdParms[12].Value = model.HBloodPressure;
            cmdParms[13].Value = model.LBloodPressure;
            cmdParms[14].Value = model.HB;
            cmdParms[15].Value = model.AssistanTexam;
            cmdParms[16].Value = model.Classification;
            cmdParms[17].Value = model.ClassificationEx;
            cmdParms[18].Value = model.Advising;
            cmdParms[19].Value = model.AdvisingOther;
            cmdParms[20].Value = model.Referral;
            cmdParms[21].Value = model.ReferralReason;
            cmdParms[22].Value = model.ReferralOrg;
            cmdParms[23].Value = model.PRO;
            cmdParms[24].Value = model.NextFollowupDate;
            cmdParms[25].Value = model.FollowUpDoctor;
            cmdParms[26].Value = model.CreatedBy;
            cmdParms[27].Value = model.CreatedDate;
            cmdParms[28].Value = model.LastUpdateBy;
            cmdParms[29].Value = model.LastUpdateDate;
            cmdParms[30].Value = model.IsDel;
            cmdParms[31].Value = model.FollowupWay;
            cmdParms[32].Value = model.PrenatalOrg;
            cmdParms[33].Value = model.ReferralContacts;
            cmdParms[34].Value = model.ReferralContactsTel;
            cmdParms[35].Value = model.ReferralResult;
            cmdParms[36].Value = model.FreeSerumCheck;
            cmdParms[37].Value = model.SerumCheckResult;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(WomenGravidaTwoToFiveVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into GRAVIDA_TWO2FIVE_FOLLOWUP(");
            builder.Append("CustomerID,RecordID,IDCardNo,Times,FollowupDate,PregancyWeeks,ChiefComPlaint,Weight,UteruslowHeight,AbdominalCirumference,FetusPosition,FHR,HBloodPressure,LBloodPressure,HB,AssistanTexam,Classification,ClassificationEx,Advising,AdvisingOther,Referral,ReferralReason,ReferralOrg,PRO,NextFollowUpDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,");
            builder.Append("FollowupWay,PrenatalOrg,ReferralContacts,ReferralContactsTel,ReferralResult,FreeSerumCheck,SerumCheckResult) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Times,@FollowupDate,@PregancyWeeks,@ChiefComPlaint,@Weight,@UteruslowHeight,@AbdominalCirumference,@FetusPosition,@FHR,@HBloodPressure,@LBloodPressure,@HB,@AssistanTexam,@Classification,@ClassificationEx,@Advising,@AdvisingOther,@Referral,@ReferralReason,@ReferralOrg,@PRO,@NextFollowUpDate,@FollowUpDoctor,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,");
            builder.Append("@FollowupWay,@PrenatalOrg,@ReferralContacts,@ReferralContactsTel,@ReferralResult,@FreeSerumCheck,@SerumCheckResult) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Times", MySqlDbType.Decimal),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date),
                new MySqlParameter("@PregancyWeeks", MySqlDbType.Decimal), 
                new MySqlParameter("@ChiefComPlaint", MySqlDbType.String, 200), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@UteruslowHeight", MySqlDbType.Decimal), 
                new MySqlParameter("@AbdominalCirumference", MySqlDbType.Decimal), 
                new MySqlParameter("@FetusPosition", MySqlDbType.String, 100),
                new MySqlParameter("@FHR", MySqlDbType.Decimal), 
                new MySqlParameter("@HBloodPressure", MySqlDbType.Decimal),
                new MySqlParameter("@LBloodPressure", MySqlDbType.Decimal), 
                new MySqlParameter("@HB", MySqlDbType.Decimal), 
                new MySqlParameter("@AssistanTexam", MySqlDbType.String, 200), 
                new MySqlParameter("@Classification", MySqlDbType.String, 1), 
                new MySqlParameter("@ClassificationEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Advising", MySqlDbType.String, 30), 
                new MySqlParameter("@AdvisingOther", MySqlDbType.String, 200), 
                new MySqlParameter("@Referral", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@PRO", MySqlDbType.String, 10), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@FollowupWay", MySqlDbType.String, 1),
                new MySqlParameter("@PrenatalOrg", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContactsTel", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1),
                new MySqlParameter("@FreeSerumCheck", MySqlDbType.String, 1),
                new MySqlParameter("@SerumCheckResult", MySqlDbType.String, 20)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Times;
            cmdParms[4].Value = model.FollowupDate;
            cmdParms[5].Value = model.PregancyWeeks;
            cmdParms[6].Value = model.ChiefComPlaint;
            cmdParms[7].Value = model.Weight;
            cmdParms[8].Value = model.UteruslowHeight;
            cmdParms[9].Value = model.AbdominalCirumference;
            cmdParms[10].Value = model.FetusPosition;
            cmdParms[11].Value = model.FHR;
            cmdParms[12].Value = model.HBloodPressure;
            cmdParms[13].Value = model.LBloodPressure;
            cmdParms[14].Value = model.HB;
            cmdParms[15].Value = model.AssistanTexam;
            cmdParms[16].Value = model.Classification;
            cmdParms[17].Value = model.ClassificationEx;
            cmdParms[18].Value = model.Advising;
            cmdParms[19].Value = model.AdvisingOther;
            cmdParms[20].Value = model.Referral;
            cmdParms[21].Value = model.ReferralReason;
            cmdParms[22].Value = model.ReferralOrg;
            cmdParms[23].Value = model.PRO;
            cmdParms[24].Value = model.NextFollowupDate;
            cmdParms[25].Value = model.FollowUpDoctor;
            cmdParms[26].Value = model.CreatedBy;
            cmdParms[27].Value = model.CreatedDate;
            cmdParms[28].Value = model.LastUpdateBy;
            cmdParms[29].Value = model.LastUpdateDate;
            cmdParms[30].Value = model.IsDel;
            cmdParms[31].Value = model.FollowupWay;
            cmdParms[32].Value = model.PrenatalOrg;
            cmdParms[33].Value = model.ReferralContacts;
            cmdParms[34].Value = model.ReferralContactsTel;
            cmdParms[35].Value = model.ReferralResult;
            cmdParms[36].Value = model.FreeSerumCheck;
            cmdParms[37].Value = model.SerumCheckResult;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public WomenGravidaTwoToFiveVisitModel DataRowToModel(DataRow row)
        {
            WomenGravidaTwoToFiveVisitModel gravida_twofive_followup = new WomenGravidaTwoToFiveVisitModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    gravida_twofive_followup.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    gravida_twofive_followup.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    gravida_twofive_followup.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    gravida_twofive_followup.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["Times"] != null) && (row["Times"] != DBNull.Value)) && (row["Times"].ToString() != ""))
                {
                    gravida_twofive_followup.Times = decimal.Parse(row["Times"].ToString());
                }
                if (((row["FollowupDate"] != null) && (row["FollowupDate"] != DBNull.Value)) && (row["FollowupDate"].ToString() != ""))
                {
                    gravida_twofive_followup.FollowupDate = new DateTime?(DateTime.Parse(row["FollowupDate"].ToString()));
                }
                if (((row["PregancyWeeks"] != null) && (row["PregancyWeeks"] != DBNull.Value)) && (row["PregancyWeeks"].ToString() != ""))
                {
                    gravida_twofive_followup.PregancyWeeks = new decimal?(decimal.Parse(row["PregancyWeeks"].ToString()));
                }
                if ((row["ChiefComPlaint"] != null) && (row["ChiefComPlaint"] != DBNull.Value))
                {
                    gravida_twofive_followup.ChiefComPlaint = row["ChiefComPlaint"].ToString();
                }
                if (((row["Weight"] != null) && (row["Weight"] != DBNull.Value)) && (row["Weight"].ToString() != ""))
                {
                    gravida_twofive_followup.Weight = new decimal?(decimal.Parse(row["Weight"].ToString()));
                }
                if (((row["UteruslowHeight"] != null) && (row["UteruslowHeight"] != DBNull.Value)) && (row["UteruslowHeight"].ToString() != ""))
                {
                    gravida_twofive_followup.UteruslowHeight = new decimal?(decimal.Parse(row["UteruslowHeight"].ToString()));
                }
                if (((row["AbdominalCirumference"] != null) && (row["AbdominalCirumference"] != DBNull.Value)) && (row["AbdominalCirumference"].ToString() != ""))
                {
                    gravida_twofive_followup.AbdominalCirumference = new decimal?(decimal.Parse(row["AbdominalCirumference"].ToString()));
                }
                if ((row["FetusPosition"] != null) && (row["FetusPosition"] != DBNull.Value))
                {
                    gravida_twofive_followup.FetusPosition = row["FetusPosition"].ToString();
                }
                if (((row["FHR"] != null) && (row["FHR"] != DBNull.Value)) && (row["FHR"].ToString() != ""))
                {
                    gravida_twofive_followup.FHR = new decimal?(decimal.Parse(row["FHR"].ToString()));
                }
                if (((row["HBloodPressure"] != null) && (row["HBloodPressure"] != DBNull.Value)) && (row["HBloodPressure"].ToString() != ""))
                {
                    gravida_twofive_followup.HBloodPressure = new decimal?(decimal.Parse(row["HBloodPressure"].ToString()));
                }
                if (((row["LBloodPressure"] != null) && (row["LBloodPressure"] != DBNull.Value)) && (row["LBloodPressure"].ToString() != ""))
                {
                    gravida_twofive_followup.LBloodPressure = new decimal?(decimal.Parse(row["LBloodPressure"].ToString()));
                }
                if (((row["HB"] != null) && (row["HB"] != DBNull.Value)) && (row["HB"].ToString() != ""))
                {
                    gravida_twofive_followup.HB = new decimal?(decimal.Parse(row["HB"].ToString()));
                }
                if ((row["AssistanTexam"] != null) && (row["AssistanTexam"] != DBNull.Value))
                {
                    gravida_twofive_followup.AssistanTexam = row["AssistanTexam"].ToString();
                }
                if ((row["Classification"] != null) && (row["Classification"] != DBNull.Value))
                {
                    gravida_twofive_followup.Classification = row["Classification"].ToString();
                }
                if ((row["ClassificationEx"] != null) && (row["ClassificationEx"] != DBNull.Value))
                {
                    gravida_twofive_followup.ClassificationEx = row["ClassificationEx"].ToString();
                }
                if ((row["Advising"] != null) && (row["Advising"] != DBNull.Value))
                {
                    gravida_twofive_followup.Advising = row["Advising"].ToString();
                }
                if ((row["AdvisingOther"] != null) && (row["AdvisingOther"] != DBNull.Value))
                {
                    gravida_twofive_followup.AdvisingOther = row["AdvisingOther"].ToString();
                }
                if ((row["Referral"] != null) && (row["Referral"] != DBNull.Value))
                {
                    gravida_twofive_followup.Referral = row["Referral"].ToString();
                }
                if ((row["ReferralReason"] != null) && (row["ReferralReason"] != DBNull.Value))
                {
                    gravida_twofive_followup.ReferralReason = row["ReferralReason"].ToString();
                }
                if ((row["ReferralOrg"] != null) && (row["ReferralOrg"] != DBNull.Value))
                {
                    gravida_twofive_followup.ReferralOrg = row["ReferralOrg"].ToString();
                }
                if ((row["PRO"] != null) && (row["PRO"] != DBNull.Value))
                {
                    gravida_twofive_followup.PRO = row["PRO"].ToString();
                }
                if (((row["NextFollowUpDate"] != null) && (row["NextFollowUpDate"] != DBNull.Value)) && (row["NextFollowUpDate"].ToString() != ""))
                {
                    gravida_twofive_followup.NextFollowupDate = new DateTime?(DateTime.Parse(row["NextFollowUpDate"].ToString()));
                }
                if ((row["FollowUpDoctor"] != null) && (row["FollowUpDoctor"] != DBNull.Value))
                {
                    gravida_twofive_followup.FollowUpDoctor = row["FollowUpDoctor"].ToString();
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    gravida_twofive_followup.CreatedBy = new decimal?(decimal.Parse(row["CreatedBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    gravida_twofive_followup.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    gravida_twofive_followup.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    gravida_twofive_followup.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    gravida_twofive_followup.IsDel = row["IsDel"].ToString();
                }
                if ((row["FollowupWay"] != null) && (row["FollowupWay"] != DBNull.Value))
                {
                    gravida_twofive_followup.FollowupWay = row["FollowupWay"].ToString();
                }
                if ((row["ReferralContacts"] != null) && (row["ReferralContacts"] != DBNull.Value))
                {
                    gravida_twofive_followup.ReferralContacts = row["ReferralContacts"].ToString();
                }
                if ((row["ReferralContactsTel"] != null) && (row["ReferralContactsTel"] != DBNull.Value))
                {
                    gravida_twofive_followup.ReferralContactsTel = row["ReferralContactsTel"].ToString();
                }
                if ((row["ReferralResult"] != null) && (row["ReferralResult"] != DBNull.Value))
                {
                    gravida_twofive_followup.ReferralResult = row["ReferralResult"].ToString();
                }
                if ((row["FreeSerumCheck"] != null) && (row["FreeSerumCheck"] != DBNull.Value))
                {
                    gravida_twofive_followup.FreeSerumCheck = row["FreeSerumCheck"].ToString();
                }
                if ((row["SerumCheckResult"] != null) && (row["SerumCheckResult"] != DBNull.Value))
                {
                    gravida_twofive_followup.SerumCheckResult = row["SerumCheckResult"].ToString();
                }
                if ((row["PrenatalOrg"] != null) && (row["PrenatalOrg"] != DBNull.Value))
                {
                    gravida_twofive_followup.PrenatalOrg = row["PrenatalOrg"].ToString();
                }
            }
            return gravida_twofive_followup;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from GRAVIDA_TWO2FIVE_FOLLOWUP ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from GRAVIDA_TWO2FIVE_FOLLOWUP ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from GRAVIDA_TWO2FIVE_FOLLOWUP");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public bool Exists(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from GRAVIDA_TWO2FIVE_FOLLOWUP");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = IDCardNo;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,Times,FollowupDate,PregancyWeeks,ChiefComPlaint,Weight,UteruslowHeight,AbdominalCirumference,FetusPosition,FHR,HBloodPressure,LBloodPressure,HB,AssistanTexam,Classification,ClassificationEx,Advising,AdvisingOther,Referral,ReferralReason,ReferralOrg,PRO,NextFollowUpDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel, ");
            builder.Append("FollowupWay,PrenatalOrg,ReferralContacts,ReferralContactsTel,ReferralResult,FreeSerumCheck,SerumCheckResult ");
            builder.Append(" FROM GRAVIDA_TWO2FIVE_FOLLOWUP ");
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
            builder.Append(")AS Row, T.*  from GRAVIDA_TWO2FIVE_FOLLOWUP T ");
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
            return MySQLHelper.GetMaxID("ID", "GRAVIDA_TWO2FIVE_FOLLOWUP");
        }

        public WomenGravidaTwoToFiveVisitModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,Times,FollowupDate,PregancyWeeks,ChiefComPlaint,Weight,UteruslowHeight,AbdominalCirumference,FetusPosition,FHR,HBloodPressure,LBloodPressure,HB,AssistanTexam,Classification,ClassificationEx,Advising,AdvisingOther,Referral,ReferralReason,ReferralOrg,NextFollowUpDate,FollowUpDoctor,CreatedBy,PRO,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel, ");
            builder.Append("FollowupWay,PrenatalOrg,ReferralContacts,ReferralContactsTel,ReferralResult,FreeSerumCheck,SerumCheckResult ");
            builder.Append(" from GRAVIDA_TWO2FIVE_FOLLOWUP");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new WomenGravidaTwoToFiveVisitModel();
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
            builder.Append("select count(1) FROM GRAVIDA_TWO2FIVE_FOLLOWUP ");
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

        public bool Update(WomenGravidaTwoToFiveVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update GRAVIDA_TWO2FIVE_FOLLOWUP set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Times=@Times,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("PregancyWeeks=@PregancyWeeks,");
            builder.Append("ChiefComPlaint=@ChiefComPlaint,");
            builder.Append("Weight=@Weight,");
            builder.Append("UteruslowHeight=@UteruslowHeight,");
            builder.Append("AbdominalCirumference=@AbdominalCirumference,");
            builder.Append("FetusPosition=@FetusPosition,");
            builder.Append("FHR=@FHR,");
            builder.Append("HBloodPressure=@HBloodPressure,");
            builder.Append("LBloodPressure=@LBloodPressure,");
            builder.Append("HB=@HB,");
            builder.Append("AssistanTexam=@AssistanTexam,");
            builder.Append("Classification=@Classification,");
            builder.Append("ClassificationEx=@ClassificationEx,");
            builder.Append("Advising=@Advising,");
            builder.Append("AdvisingOther=@AdvisingOther,");
            builder.Append("Referral=@Referral,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralOrg=@ReferralOrg,");
            builder.Append("PRO=@PRO,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("FollowupWay=@FollowupWay,");
            builder.Append("PrenatalOrg=@PrenatalOrg,");
            builder.Append("ReferralContacts=@ReferralContacts,");
            builder.Append("ReferralContactsTel=@ReferralContactsTel,");
            builder.Append("ReferralResult=@ReferralResult,");
            builder.Append("FreeSerumCheck=@FreeSerumCheck,");
            builder.Append("SerumCheckResult=@SerumCheckResult ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
               new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Times", MySqlDbType.Decimal),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date),
                new MySqlParameter("@PregancyWeeks", MySqlDbType.Decimal), 
                new MySqlParameter("@ChiefComPlaint", MySqlDbType.String, 200), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@UteruslowHeight", MySqlDbType.Decimal), 
                new MySqlParameter("@AbdominalCirumference", MySqlDbType.Decimal), 
                new MySqlParameter("@FetusPosition", MySqlDbType.String, 100),
                new MySqlParameter("@FHR", MySqlDbType.Decimal), 
                new MySqlParameter("@HBloodPressure", MySqlDbType.Decimal),
                new MySqlParameter("@LBloodPressure", MySqlDbType.Decimal), 
                new MySqlParameter("@HB", MySqlDbType.Decimal), 
                new MySqlParameter("@AssistanTexam", MySqlDbType.String, 200), 
                new MySqlParameter("@Classification", MySqlDbType.String, 1), 
                new MySqlParameter("@ClassificationEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Advising", MySqlDbType.String, 30), 
                new MySqlParameter("@AdvisingOther", MySqlDbType.String, 200), 
                new MySqlParameter("@Referral", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@PRO", MySqlDbType.String, 10), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@FollowupWay", MySqlDbType.String, 1),
                new MySqlParameter("@PrenatalOrg", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContactsTel", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1),
                new MySqlParameter("@FreeSerumCheck", MySqlDbType.String, 1),
                new MySqlParameter("@SerumCheckResult", MySqlDbType.String, 20),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Times;
            cmdParms[4].Value = model.FollowupDate;
            cmdParms[5].Value = model.PregancyWeeks;
            cmdParms[6].Value = model.ChiefComPlaint;
            cmdParms[7].Value = model.Weight;
            cmdParms[8].Value = model.UteruslowHeight;
            cmdParms[9].Value = model.AbdominalCirumference;
            cmdParms[10].Value = model.FetusPosition;
            cmdParms[11].Value = model.FHR;
            cmdParms[12].Value = model.HBloodPressure;
            cmdParms[13].Value = model.LBloodPressure;
            cmdParms[14].Value = model.HB;
            cmdParms[15].Value = model.AssistanTexam;
            cmdParms[16].Value = model.Classification;
            cmdParms[17].Value = model.ClassificationEx;
            cmdParms[18].Value = model.Advising;
            cmdParms[19].Value = model.AdvisingOther;
            cmdParms[20].Value = model.Referral;
            cmdParms[21].Value = model.ReferralReason;
            cmdParms[22].Value = model.ReferralOrg;
            cmdParms[23].Value = model.PRO;
            cmdParms[24].Value = model.NextFollowupDate;
            cmdParms[25].Value = model.FollowUpDoctor;
            cmdParms[26].Value = model.CreatedBy;
            cmdParms[27].Value = model.CreatedDate;
            cmdParms[28].Value = model.LastUpdateBy;
            cmdParms[29].Value = model.LastUpdateDate;
            cmdParms[30].Value = model.IsDel;
            cmdParms[31].Value = model.FollowupWay;
            cmdParms[32].Value = model.PrenatalOrg;
            cmdParms[33].Value = model.ReferralContacts;
            cmdParms[34].Value = model.ReferralContactsTel;
            cmdParms[35].Value = model.ReferralResult;
            cmdParms[36].Value = model.FreeSerumCheck;
            cmdParms[37].Value = model.SerumCheckResult;
            cmdParms[38].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(WomenGravidaTwoToFiveVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update GRAVIDA_TWO2FIVE_FOLLOWUP set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Times=@Times,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("PregancyWeeks=@PregancyWeeks,");
            builder.Append("ChiefComPlaint=@ChiefComPlaint,");
            builder.Append("Weight=@Weight,");
            builder.Append("UteruslowHeight=@UteruslowHeight,");
            builder.Append("AbdominalCirumference=@AbdominalCirumference,");
            builder.Append("FetusPosition=@FetusPosition,");
            builder.Append("FHR=@FHR,");
            builder.Append("HBloodPressure=@HBloodPressure,");
            builder.Append("LBloodPressure=@LBloodPressure,");
            builder.Append("HB=@HB,");
            builder.Append("AssistanTexam=@AssistanTexam,");
            builder.Append("Classification=@Classification,");
            builder.Append("ClassificationEx=@ClassificationEx,");
            builder.Append("Advising=@Advising,");
            builder.Append("AdvisingOther=@AdvisingOther,");
            builder.Append("Referral=@Referral,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralOrg=@ReferralOrg,");
            builder.Append("PRO=@PRO,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("FollowupWay=@FollowupWay,");
            builder.Append("PrenatalOrg=@PrenatalOrg,");
            builder.Append("ReferralContacts=@ReferralContacts,");
            builder.Append("ReferralContactsTel=@ReferralContactsTel,");
            builder.Append("ReferralResult=@ReferralResult,");
            builder.Append("FreeSerumCheck=@FreeSerumCheck,");
            builder.Append("SerumCheckResult=@SerumCheckResult ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
               new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Times", MySqlDbType.Decimal),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date),
                new MySqlParameter("@PregancyWeeks", MySqlDbType.Decimal), 
                new MySqlParameter("@ChiefComPlaint", MySqlDbType.String, 200), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@UteruslowHeight", MySqlDbType.Decimal), 
                new MySqlParameter("@AbdominalCirumference", MySqlDbType.Decimal), 
                new MySqlParameter("@FetusPosition", MySqlDbType.String, 100),
                new MySqlParameter("@FHR", MySqlDbType.Decimal), 
                new MySqlParameter("@HBloodPressure", MySqlDbType.Decimal),
                new MySqlParameter("@LBloodPressure", MySqlDbType.Decimal), 
                new MySqlParameter("@HB", MySqlDbType.Decimal), 
                new MySqlParameter("@AssistanTexam", MySqlDbType.String, 200), 
                new MySqlParameter("@Classification", MySqlDbType.String, 1), 
                new MySqlParameter("@ClassificationEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Advising", MySqlDbType.String, 30), 
                new MySqlParameter("@AdvisingOther", MySqlDbType.String, 200), 
                new MySqlParameter("@Referral", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@PRO", MySqlDbType.String, 10), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@FollowupWay", MySqlDbType.String, 1),
                new MySqlParameter("@PrenatalOrg", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContactsTel", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1),
                new MySqlParameter("@FreeSerumCheck", MySqlDbType.String, 1),
                new MySqlParameter("@SerumCheckResult", MySqlDbType.String, 20)
               // new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Times;
            cmdParms[4].Value = model.FollowupDate;
            cmdParms[5].Value = model.PregancyWeeks;
            cmdParms[6].Value = model.ChiefComPlaint;
            cmdParms[7].Value = model.Weight;
            cmdParms[8].Value = model.UteruslowHeight;
            cmdParms[9].Value = model.AbdominalCirumference;
            cmdParms[10].Value = model.FetusPosition;
            cmdParms[11].Value = model.FHR;
            cmdParms[12].Value = model.HBloodPressure;
            cmdParms[13].Value = model.LBloodPressure;
            cmdParms[14].Value = model.HB;
            cmdParms[15].Value = model.AssistanTexam;
            cmdParms[16].Value = model.Classification;
            cmdParms[17].Value = model.ClassificationEx;
            cmdParms[18].Value = model.Advising;
            cmdParms[19].Value = model.AdvisingOther;
            cmdParms[20].Value = model.Referral;
            cmdParms[21].Value = model.ReferralReason;
            cmdParms[22].Value = model.ReferralOrg;
            cmdParms[23].Value = model.PRO;
            cmdParms[24].Value = model.NextFollowupDate;
            cmdParms[25].Value = model.FollowUpDoctor;
            cmdParms[26].Value = model.CreatedBy;
            cmdParms[27].Value = model.CreatedDate;
            cmdParms[28].Value = model.LastUpdateBy;
            cmdParms[29].Value = model.LastUpdateDate;
            cmdParms[30].Value = model.IsDel;
            cmdParms[31].Value = model.FollowupWay;
            cmdParms[32].Value = model.PrenatalOrg;
            cmdParms[33].Value = model.ReferralContacts;
            cmdParms[34].Value = model.ReferralContactsTel;
            cmdParms[35].Value = model.ReferralResult;
            cmdParms[36].Value = model.FreeSerumCheck;
            cmdParms[37].Value = model.SerumCheckResult;
            //cmdParms[0x1f].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

