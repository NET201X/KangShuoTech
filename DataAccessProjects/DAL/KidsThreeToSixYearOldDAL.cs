namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class KidsThreeToSixYearOldDAL
    {
        public int Add(KidsThreeToSixYearOldModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_kidsthreetosixyearold(");
            builder.Append("CustomerID,RecordID,IDCardNo,Name,VisitDate,Weight,WeightAnalysis,Stature,StatureAnalysis,PhysicalAuxeEvaluat,Sight,Listening,TcnLeft,TdcnRight,HeartLung,Stomach,HemoglobinValue,Other,AmongTwoFolloNone,PneumoniaFrequen,DiarrhoeaFrequen,TraumatismFrequen,AmongTwoFolloOther,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,GuidanceOther,NextVisitDate,VisitDoctorSign,Flag,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,IsDel,");
            builder.Append("Kindergarten,ManagerContact,ManagerContactTel,BodyInstitution,InstitutionOther,WeightVsHeight,WeightVsHeightAnalysis,Chest,ReferraContacts,ReferralContactsTel,ReferralResult,AuxeEstimate) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Name,@VisitDate,@Weight,@WeightAnalysis,@Stature,@StatureAnalysis,@PhysicalAuxeEvaluat,@Sight,@Listening,@TcnLeft,@TdcnRight,@HeartLung,@Stomach,@HemoglobinValue,@Other,@AmongTwoFolloNone,@PneumoniaFrequen,@DiarrhoeaFrequen,@TraumatismFrequen,@AmongTwoFolloOther,@ReferralAdvice,@ReferralReason,@AgenciesDepartments,@Guidance,@GuidanceOther,@NextVisitDate,@VisitDoctorSign,@Flag,@CreateBy,@CreateDate,@LastUpdateBy,@LastUpdateDate,@IsDel,");
            builder.Append("@Kindergarten,@ManagerContact,@ManagerContactTel,@BodyInstitution,@InstitutionOther,@WeightVsHeight,@WeightVsHeightAnalysis,@Chest,@ReferraContacts,@ReferralContactsTel,@ReferralResult,@AuxeEstimate) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String, 30),
                new MySqlParameter("@VisitDate", MySqlDbType.Date), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@WeightAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@Stature", MySqlDbType.Decimal), 
                new MySqlParameter("@StatureAnalysis", MySqlDbType.String, 1), 
                new MySqlParameter("@PhysicalAuxeEvaluat", MySqlDbType.String, 1),
                new MySqlParameter("@Sight", MySqlDbType.Decimal),
                new MySqlParameter("@Listening", MySqlDbType.String, 1),
                new MySqlParameter("@TcnLeft", MySqlDbType.Decimal),
                new MySqlParameter("@TdcnRight", MySqlDbType.Decimal),
                new MySqlParameter("@HeartLung", MySqlDbType.String, 1), 
                new MySqlParameter("@Stomach", MySqlDbType.String, 1), 
                new MySqlParameter("@HemoglobinValue", MySqlDbType.Decimal), 
                new MySqlParameter("@Other", MySqlDbType.String, 100), 
                new MySqlParameter("@AmongTwoFolloNone", MySqlDbType.String, 1),
                new MySqlParameter("@PneumoniaFrequen", MySqlDbType.Decimal),
                new MySqlParameter("@DiarrhoeaFrequen", MySqlDbType.Decimal), 
                new MySqlParameter("@TraumatismFrequen", MySqlDbType.Decimal),
                new MySqlParameter("@AmongTwoFolloOther", MySqlDbType.String, 200), 
                new MySqlParameter("@ReferralAdvice", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500),
                new MySqlParameter("@AgenciesDepartments", MySqlDbType.String, 80),
                new MySqlParameter("@Guidance", MySqlDbType.String, 30), 
                new MySqlParameter("@GuidanceOther", MySqlDbType.String, 100),
                new MySqlParameter("@NextVisitDate", MySqlDbType.Date),
                new MySqlParameter("@VisitDoctorSign", MySqlDbType.String, 30),
                new MySqlParameter("@Flag", MySqlDbType.String, 1), 
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@Kindergarten", MySqlDbType.String, 50),
                new MySqlParameter("@ManagerContact", MySqlDbType.String, 50),
                new MySqlParameter("@ManagerContactTel", MySqlDbType.String, 50),
                new MySqlParameter("@BodyInstitution", MySqlDbType.String, 50),
                new MySqlParameter("@InstitutionOther", MySqlDbType.String, 50),
                new MySqlParameter("@WeightVsHeight", MySqlDbType.Decimal),
                new MySqlParameter("@WeightVsHeightAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1),
                new MySqlParameter("@AuxeEstimate",MySqlDbType.String,1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.VisitDate;
            cmdParms[5].Value = model.Weight;
            cmdParms[6].Value = model.WeightAnalysis;
            cmdParms[7].Value = model.Stature;
            cmdParms[8].Value = model.StatureAnalysis;
            cmdParms[9].Value = model.PhysicalAuxeEvaluat;
            cmdParms[10].Value = model.Sight;
            cmdParms[11].Value = model.Listening;
            cmdParms[12].Value = model.TcnLeft;
            cmdParms[13].Value = model.TdcnRight;
            cmdParms[14].Value = model.HeartLung;
            cmdParms[15].Value = model.Stomach;
            cmdParms[16].Value = model.HemoglobinValue;
            cmdParms[17].Value = model.Other;
            cmdParms[18].Value = model.AmongTwoFolloNone;
            cmdParms[19].Value = model.PneumoniaFrequen;
            cmdParms[20].Value = model.DiarrhoeaFrequen;
            cmdParms[21].Value = model.TraumatismFrequen;
            cmdParms[22].Value = model.AmongTwoFolloOther;
            cmdParms[23].Value = model.ReferralAdvice;
            cmdParms[24].Value = model.ReferralReason;
            cmdParms[25].Value = model.AgenciesDepartments;
            cmdParms[26].Value = model.Guidance;
            cmdParms[27].Value = model.GuidanceOther;
            cmdParms[28].Value = model.NextVisitDate;
            cmdParms[29].Value = model.VisitDoctorSign;
            cmdParms[30].Value = model.Flag;
            cmdParms[31].Value = model.CreateBy;
            cmdParms[32].Value = model.CreateDate;
            cmdParms[33].Value = model.LastUpdateBy;
            cmdParms[34].Value = model.LastUpdateDate;
            cmdParms[35].Value = model.IsDel;
            cmdParms[36].Value = model.Kindergarten;          
            cmdParms[37].Value = model.ManagerContact;          
            cmdParms[38].Value = model.ManagerContactTel;     
            cmdParms[39].Value = model.BodyInstitution;        
            cmdParms[40].Value = model.InstitutionOther ;     
            cmdParms[41].Value = model.WeightVsHeight;         
            cmdParms[42].Value = model.WeightVsHeightAnalysis;
            cmdParms[43].Value = model.Chest;                  
            cmdParms[44].Value = model.ReferraContacts;       
            cmdParms[45].Value = model.ReferralContactsTel;
            cmdParms[46].Value = model.ReferralResult;
            cmdParms[47].Value = model.AuxeEstimate;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(KidsThreeToSixYearOldModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_kidsthreetosixyearold(");
            builder.Append("CustomerID,RecordID,IDCardNo,Name,VisitDate,Weight,WeightAnalysis,Stature,StatureAnalysis,PhysicalAuxeEvaluat,Sight,Listening,TcnLeft,TdcnRight,HeartLung,Stomach,HemoglobinValue,Other,AmongTwoFolloNone,PneumoniaFrequen,DiarrhoeaFrequen,TraumatismFrequen,AmongTwoFolloOther,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,GuidanceOther,NextVisitDate,VisitDoctorSign,Flag,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,IsDel,");
            builder.Append("Kindergarten,ManagerContact,ManagerContactTel,BodyInstitution,InstitutionOther,WeightVsHeight,WeightVsHeightAnalysis,Chest,ReferraContacts,ReferralContactsTel,ReferralResult,AuxeEstimate) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Name,@VisitDate,@Weight,@WeightAnalysis,@Stature,@StatureAnalysis,@PhysicalAuxeEvaluat,@Sight,@Listening,@TcnLeft,@TdcnRight,@HeartLung,@Stomach,@HemoglobinValue,@Other,@AmongTwoFolloNone,@PneumoniaFrequen,@DiarrhoeaFrequen,@TraumatismFrequen,@AmongTwoFolloOther,@ReferralAdvice,@ReferralReason,@AgenciesDepartments,@Guidance,@GuidanceOther,@NextVisitDate,@VisitDoctorSign,@Flag,@CreateBy,@CreateDate,@LastUpdateBy,@LastUpdateDate,@IsDel,");
            builder.Append("@Kindergarten,@ManagerContact,@ManagerContactTel,@BodyInstitution,@InstitutionOther,@WeightVsHeight,@WeightVsHeightAnalysis,@Chest,@ReferraContacts,@ReferralContactsTel,@ReferralResult,@AuxeEstimate) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String, 30),
                new MySqlParameter("@VisitDate", MySqlDbType.Date), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@WeightAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@Stature", MySqlDbType.Decimal), 
                new MySqlParameter("@StatureAnalysis", MySqlDbType.String, 1), 
                new MySqlParameter("@PhysicalAuxeEvaluat", MySqlDbType.String, 1),
                new MySqlParameter("@Sight", MySqlDbType.Decimal),
                new MySqlParameter("@Listening", MySqlDbType.String, 1),
                new MySqlParameter("@TcnLeft", MySqlDbType.Decimal),
                new MySqlParameter("@TdcnRight", MySqlDbType.Decimal),
                new MySqlParameter("@HeartLung", MySqlDbType.String, 1), 
                new MySqlParameter("@Stomach", MySqlDbType.String, 1), 
                new MySqlParameter("@HemoglobinValue", MySqlDbType.Decimal), 
                new MySqlParameter("@Other", MySqlDbType.String, 100), 
                new MySqlParameter("@AmongTwoFolloNone", MySqlDbType.String, 1),
                new MySqlParameter("@PneumoniaFrequen", MySqlDbType.Decimal),
                new MySqlParameter("@DiarrhoeaFrequen", MySqlDbType.Decimal), 
                new MySqlParameter("@TraumatismFrequen", MySqlDbType.Decimal),
                new MySqlParameter("@AmongTwoFolloOther", MySqlDbType.String, 200), 
                new MySqlParameter("@ReferralAdvice", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500),
                new MySqlParameter("@AgenciesDepartments", MySqlDbType.String, 80),
                new MySqlParameter("@Guidance", MySqlDbType.String, 30), 
                new MySqlParameter("@GuidanceOther", MySqlDbType.String, 100),
                new MySqlParameter("@NextVisitDate", MySqlDbType.Date),
                new MySqlParameter("@VisitDoctorSign", MySqlDbType.String, 30),
                new MySqlParameter("@Flag", MySqlDbType.String, 1), 
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@Kindergarten", MySqlDbType.String, 50),
                new MySqlParameter("@ManagerContact", MySqlDbType.String, 50),
                new MySqlParameter("@ManagerContactTel", MySqlDbType.String, 50),
                new MySqlParameter("@BodyInstitution", MySqlDbType.String, 50),
                new MySqlParameter("@InstitutionOther", MySqlDbType.String, 50),
                new MySqlParameter("@WeightVsHeight", MySqlDbType.Decimal),
                new MySqlParameter("@WeightVsHeightAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1),
                new MySqlParameter("@AuxeEstimate",MySqlDbType.String,1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.VisitDate;
            cmdParms[5].Value = model.Weight;
            cmdParms[6].Value = model.WeightAnalysis;
            cmdParms[7].Value = model.Stature;
            cmdParms[8].Value = model.StatureAnalysis;
            cmdParms[9].Value = model.PhysicalAuxeEvaluat;
            cmdParms[10].Value = model.Sight;
            cmdParms[11].Value = model.Listening;
            cmdParms[12].Value = model.TcnLeft;
            cmdParms[13].Value = model.TdcnRight;
            cmdParms[14].Value = model.HeartLung;
            cmdParms[15].Value = model.Stomach;
            cmdParms[16].Value = model.HemoglobinValue;
            cmdParms[17].Value = model.Other;
            cmdParms[18].Value = model.AmongTwoFolloNone;
            cmdParms[19].Value = model.PneumoniaFrequen;
            cmdParms[20].Value = model.DiarrhoeaFrequen;
            cmdParms[21].Value = model.TraumatismFrequen;
            cmdParms[22].Value = model.AmongTwoFolloOther;
            cmdParms[23].Value = model.ReferralAdvice;
            cmdParms[24].Value = model.ReferralReason;
            cmdParms[25].Value = model.AgenciesDepartments;
            cmdParms[26].Value = model.Guidance;
            cmdParms[27].Value = model.GuidanceOther;
            cmdParms[28].Value = model.NextVisitDate;
            cmdParms[29].Value = model.VisitDoctorSign;
            cmdParms[30].Value = model.Flag;
            cmdParms[31].Value = model.CreateBy;
            cmdParms[32].Value = model.CreateDate;
            cmdParms[33].Value = model.LastUpdateBy;
            cmdParms[34].Value = model.LastUpdateDate;
            cmdParms[35].Value = model.IsDel;
            cmdParms[36].Value = model.Kindergarten;
            cmdParms[37].Value = model.ManagerContact;
            cmdParms[38].Value = model.ManagerContactTel;
            cmdParms[39].Value = model.BodyInstitution;
            cmdParms[40].Value = model.InstitutionOther;
            cmdParms[41].Value = model.WeightVsHeight;
            cmdParms[42].Value = model.WeightVsHeightAnalysis;
            cmdParms[43].Value = model.Chest;
            cmdParms[44].Value = model.ReferraContacts;
            cmdParms[45].Value = model.ReferralContactsTel;
            cmdParms[46].Value = model.ReferralResult;
            cmdParms[47].Value = model.AuxeEstimate; 
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public KidsThreeToSixYearOldModel DataRowToModel(DataRow row)
        {
            KidsThreeToSixYearOldModel kidsThreeToSixYearOldModel = new KidsThreeToSixYearOldModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Name"] != null) && (row["Name"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.Name = row["Name"].ToString();
                }
                if (((row["VisitDate"] != null) && (row["VisitDate"] != DBNull.Value)) && (row["VisitDate"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.VisitDate = new DateTime?(DateTime.Parse(row["VisitDate"].ToString()));
                }
                if (((row["Weight"] != null) && (row["Weight"] != DBNull.Value)) && (row["Weight"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.Weight = new decimal?(decimal.Parse(row["Weight"].ToString()));
                }
                if ((row["WeightAnalysis"] != null) && (row["WeightAnalysis"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.WeightAnalysis = row["WeightAnalysis"].ToString();
                }
                if (((row["Stature"] != null) && (row["Stature"] != DBNull.Value)) && (row["Stature"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.Stature = new decimal?(decimal.Parse(row["Stature"].ToString()));
                }
                if ((row["StatureAnalysis"] != null) && (row["StatureAnalysis"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.StatureAnalysis = row["StatureAnalysis"].ToString();
                }
                if ((row["PhysicalAuxeEvaluat"] != null) && (row["PhysicalAuxeEvaluat"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.PhysicalAuxeEvaluat = row["PhysicalAuxeEvaluat"].ToString();
                }
                if (((row["Sight"] != null) && (row["Sight"] != DBNull.Value)) && (row["Sight"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.Sight = new decimal?(decimal.Parse(row["Sight"].ToString()));
                }
                if ((row["Listening"] != null) && (row["Listening"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.Listening = row["Listening"].ToString();
                }
                if (((row["TcnLeft"] != null) && (row["TcnLeft"] != DBNull.Value)) && (row["TcnLeft"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.TcnLeft = new decimal?(decimal.Parse(row["TcnLeft"].ToString()));
                }
                if (((row["TdcnRight"] != null) && (row["TdcnRight"] != DBNull.Value)) && (row["TdcnRight"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.TdcnRight = new decimal?(decimal.Parse(row["TdcnRight"].ToString()));
                }
                if ((row["HeartLung"] != null) && (row["HeartLung"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.HeartLung = row["HeartLung"].ToString();
                }
                if ((row["Stomach"] != null) && (row["Stomach"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.Stomach = row["Stomach"].ToString();
                }
                if (((row["HemoglobinValue"] != null) && (row["HemoglobinValue"] != DBNull.Value)) && (row["HemoglobinValue"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.HemoglobinValue = new decimal?(decimal.Parse(row["HemoglobinValue"].ToString()));
                }
                if ((row["Other"] != null) && (row["Other"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.Other = row["Other"].ToString();
                }
                if ((row["AmongTwoFolloNone"] != null) && (row["AmongTwoFolloNone"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.AmongTwoFolloNone = row["AmongTwoFolloNone"].ToString();
                }
                if (((row["PneumoniaFrequen"] != null) && (row["PneumoniaFrequen"] != DBNull.Value)) && (row["PneumoniaFrequen"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.PneumoniaFrequen = new decimal?(decimal.Parse(row["PneumoniaFrequen"].ToString()));
                }
                if (((row["DiarrhoeaFrequen"] != null) && (row["DiarrhoeaFrequen"] != DBNull.Value)) && (row["DiarrhoeaFrequen"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.DiarrhoeaFrequen = new decimal?(decimal.Parse(row["DiarrhoeaFrequen"].ToString()));
                }
                if (((row["TraumatismFrequen"] != null) && (row["TraumatismFrequen"] != DBNull.Value)) && (row["TraumatismFrequen"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.TraumatismFrequen = new decimal?(decimal.Parse(row["TraumatismFrequen"].ToString()));
                }
                if ((row["AmongTwoFolloOther"] != null) && (row["AmongTwoFolloOther"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.AmongTwoFolloOther = row["AmongTwoFolloOther"].ToString();
                }
                if ((row["ReferralAdvice"] != null) && (row["ReferralAdvice"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.ReferralAdvice = row["ReferralAdvice"].ToString();
                }
                if ((row["ReferralReason"] != null) && (row["ReferralReason"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.ReferralReason = row["ReferralReason"].ToString();
                }
                if ((row["AgenciesDepartments"] != null) && (row["AgenciesDepartments"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.AgenciesDepartments = row["AgenciesDepartments"].ToString();
                }
                if ((row["Guidance"] != null) && (row["Guidance"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.Guidance = row["Guidance"].ToString();
                }
                if ((row["GuidanceOther"] != null) && (row["GuidanceOther"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.GuidanceOther = row["GuidanceOther"].ToString();
                }
                if (((row["NextVisitDate"] != null) && (row["NextVisitDate"] != DBNull.Value)) && (row["NextVisitDate"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.NextVisitDate = new DateTime?(DateTime.Parse(row["NextVisitDate"].ToString()));
                }
                if ((row["VisitDoctorSign"] != null) && (row["VisitDoctorSign"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.VisitDoctorSign = row["VisitDoctorSign"].ToString();
                }
                if ((row["Flag"] != null) && (row["Flag"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.Flag = row["Flag"].ToString();
                }
                if (((row["CreateBy"] != null) && (row["CreateBy"] != DBNull.Value)) && (row["CreateBy"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.CreateBy = decimal.Parse(row["CreateBy"].ToString());
                }
                if (((row["CreateDate"] != null) && (row["CreateDate"] != DBNull.Value)) && (row["CreateDate"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.LastUpdateBy = decimal.Parse(row["LastUpdateBy"].ToString());
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.LastUpdateDate = DateTime.Parse(row["LastUpdateDate"].ToString());
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.IsDel = row["IsDel"].ToString();
                }
                if ((row["Kindergarten"] != null) && (row["Kindergarten"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.Kindergarten = row["Kindergarten"].ToString();
                }
                if ((row["ManagerContact"] != null) && (row["ManagerContact"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.ManagerContact = row["ManagerContact"].ToString();
                }
                if ((row["ManagerContactTel"] != null) && (row["ManagerContactTel"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.ManagerContactTel = row["ManagerContactTel"].ToString();
                }
                if ((row["BodyInstitution"] != null) && (row["BodyInstitution"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.BodyInstitution = row["BodyInstitution"].ToString();
                }
                if ((row["InstitutionOther"] != null) && (row["InstitutionOther"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.InstitutionOther = row["InstitutionOther"].ToString();
                }
                if (((row["WeightVsHeight"] != null) && (row["WeightVsHeight"] != DBNull.Value)) && (row["WeightVsHeight"].ToString() != ""))
                {
                    kidsThreeToSixYearOldModel.WeightVsHeight = decimal.Parse(row["WeightVsHeight"].ToString());
                }
                if ((row["WeightVsHeightAnalysis"] != null) && (row["WeightVsHeightAnalysis"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.WeightVsHeightAnalysis = row["WeightVsHeightAnalysis"].ToString();
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.IsDel = row["IsDel"].ToString();
                }
                if ((row["Chest"] != null) && (row["Chest"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.Chest = row["Chest"].ToString();
                }
                if ((row["ReferraContacts"] != null) && (row["ReferraContacts"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.ReferraContacts = row["ReferraContacts"].ToString();
                }
                if ((row["ReferralContactsTel"] != null) && (row["ReferralContactsTel"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.ReferralContactsTel = row["ReferralContactsTel"].ToString();
                }
                if ((row["ReferralResult"] != null) && (row["ReferralResult"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.ReferralResult = row["ReferralResult"].ToString();
                }
                if ((row["AuxeEstimate"] != null) && (row["AuxeEstimate"] != DBNull.Value))
                {
                    kidsThreeToSixYearOldModel.AuxeEstimate = row["AuxeEstimate"].ToString();
                }
            }
            return kidsThreeToSixYearOldModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_kidsthreetosixyearold ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_kidsthreetosixyearold ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_kidsthreetosixyearold");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,Name,VisitDate,Weight,WeightAnalysis,Stature,StatureAnalysis,PhysicalAuxeEvaluat,Sight,Listening,TcnLeft,TdcnRight,HeartLung,Stomach,HemoglobinValue,Other,AmongTwoFolloNone,PneumoniaFrequen,DiarrhoeaFrequen,TraumatismFrequen,AmongTwoFolloOther,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,GuidanceOther,NextVisitDate,VisitDoctorSign,Flag,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,IsDel, ");
            builder.Append("Kindergarten,ManagerContact,ManagerContactTel,BodyInstitution,InstitutionOther,WeightVsHeight,WeightVsHeightAnalysis,Chest,ReferraContacts,ReferralContactsTel,ReferralResult,AuxeEstimate ");
            builder.Append(" FROM tbl_kidsthreetosixyearold ");
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
            builder.Append(")AS Row, T.*  from tbl_kidsthreetosixyearold T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_kidsthreetosixyearold");
        }

        public KidsThreeToSixYearOldModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,Name,VisitDate,Weight,WeightAnalysis,Stature,StatureAnalysis,PhysicalAuxeEvaluat,Sight,Listening,TcnLeft,TdcnRight,HeartLung,Stomach,HemoglobinValue,Other,AmongTwoFolloNone,PneumoniaFrequen,DiarrhoeaFrequen,TraumatismFrequen,AmongTwoFolloOther,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,GuidanceOther,NextVisitDate,VisitDoctorSign,Flag,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,IsDel ,");
            builder.Append("Kindergarten,ManagerContact,ManagerContactTel,BodyInstitution,InstitutionOther,WeightVsHeight,WeightVsHeightAnalysis,Chest,ReferraContacts,ReferralContactsTel,ReferralResult,AuxeEstimate ");
            builder.Append(" FROM tbl_kidsthreetosixyearold ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new KidsThreeToSixYearOldModel();
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
            builder.Append("select count(1) FROM tbl_kidsthreetosixyearold ");
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

        public bool Update(KidsThreeToSixYearOldModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_kidsthreetosixyearold set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Name=@Name,");
            builder.Append("VisitDate=@VisitDate,");
            builder.Append("Weight=@Weight,");
            builder.Append("WeightAnalysis=@WeightAnalysis,");
            builder.Append("Stature=@Stature,");
            builder.Append("StatureAnalysis=@StatureAnalysis,");
            builder.Append("PhysicalAuxeEvaluat=@PhysicalAuxeEvaluat,");
            builder.Append("Sight=@Sight,");
            builder.Append("Listening=@Listening,");
            builder.Append("TcnLeft=@TcnLeft,");
            builder.Append("TdcnRight=@TdcnRight,");
            builder.Append("HeartLung=@HeartLung,");
            builder.Append("Stomach=@Stomach,");
            builder.Append("HemoglobinValue=@HemoglobinValue,");
            builder.Append("Other=@Other,");
            builder.Append("AmongTwoFolloNone=@AmongTwoFolloNone,");
            builder.Append("PneumoniaFrequen=@PneumoniaFrequen,");
            builder.Append("DiarrhoeaFrequen=@DiarrhoeaFrequen,");
            builder.Append("TraumatismFrequen=@TraumatismFrequen,");
            builder.Append("AmongTwoFolloOther=@AmongTwoFolloOther,");
            builder.Append("ReferralAdvice=@ReferralAdvice,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("AgenciesDepartments=@AgenciesDepartments,");
            builder.Append("Guidance=@Guidance,");
            builder.Append("GuidanceOther=@GuidanceOther,");
            builder.Append("NextVisitDate=@NextVisitDate,");
            builder.Append("VisitDoctorSign=@VisitDoctorSign,");
            builder.Append("Flag=@Flag,");
            builder.Append("CreateBy=@CreateBy,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("Kindergarten=@Kindergarten,");
            builder.Append("ManagerContact=@ManagerContact,");
            builder.Append("ManagerContactTel=@ManagerContactTel,");
            builder.Append("BodyInstitution=@BodyInstitution,");
            builder.Append("InstitutionOther=@InstitutionOther,");
            builder.Append("WeightVsHeight=@WeightVsHeight,");
            builder.Append("WeightVsHeightAnalysis=@WeightVsHeightAnalysis,");
            builder.Append("Chest=@Chest,");
            builder.Append("ReferraContacts=@ReferraContacts,");
            builder.Append("ReferralContactsTel=@ReferralContactsTel,");
            builder.Append("ReferralResult=@ReferralResult, ");
            builder.Append("AuxeEstimate=@AuxeEstimate ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String, 30), 
                new MySqlParameter("@VisitDate", MySqlDbType.Date), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@WeightAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@Stature", MySqlDbType.Decimal), 
                new MySqlParameter("@StatureAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@PhysicalAuxeEvaluat", MySqlDbType.String, 1),
                new MySqlParameter("@Sight", MySqlDbType.Decimal), 
                new MySqlParameter("@Listening", MySqlDbType.String, 1),
                new MySqlParameter("@TcnLeft", MySqlDbType.Decimal), 
                new MySqlParameter("@TdcnRight", MySqlDbType.Decimal), 
                new MySqlParameter("@HeartLung", MySqlDbType.String, 1), 
                new MySqlParameter("@Stomach", MySqlDbType.String, 1), 
                new MySqlParameter("@HemoglobinValue", MySqlDbType.Decimal), 
                new MySqlParameter("@Other", MySqlDbType.String, 100), 
                new MySqlParameter("@AmongTwoFolloNone", MySqlDbType.String, 1),
                new MySqlParameter("@PneumoniaFrequen", MySqlDbType.Decimal), 
                new MySqlParameter("@DiarrhoeaFrequen", MySqlDbType.Decimal), 
                new MySqlParameter("@TraumatismFrequen", MySqlDbType.Decimal),
                new MySqlParameter("@AmongTwoFolloOther", MySqlDbType.String, 200),
                new MySqlParameter("@ReferralAdvice", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@AgenciesDepartments", MySqlDbType.String, 80),
                new MySqlParameter("@Guidance", MySqlDbType.String, 30), 
                new MySqlParameter("@GuidanceOther", MySqlDbType.String, 100), 
                new MySqlParameter("@NextVisitDate", MySqlDbType.Date), 
                new MySqlParameter("@VisitDoctorSign", MySqlDbType.String, 30), 
                new MySqlParameter("@Flag", MySqlDbType.String, 1), 
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@Kindergarten", MySqlDbType.String, 50),
                new MySqlParameter("@ManagerContact", MySqlDbType.String, 50),
                new MySqlParameter("@ManagerContactTel", MySqlDbType.String, 50),
                new MySqlParameter("@BodyInstitution", MySqlDbType.String, 50),
                new MySqlParameter("@InstitutionOther", MySqlDbType.String, 50),
                new MySqlParameter("@WeightVsHeight", MySqlDbType.Decimal),
                new MySqlParameter("@WeightVsHeightAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1),
                new MySqlParameter("@AuxeEstimate",MySqlDbType.String,1),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.VisitDate;
            cmdParms[5].Value = model.Weight;
            cmdParms[6].Value = model.WeightAnalysis;
            cmdParms[7].Value = model.Stature;
            cmdParms[8].Value = model.StatureAnalysis;
            cmdParms[9].Value = model.PhysicalAuxeEvaluat;
            cmdParms[10].Value = model.Sight;
            cmdParms[11].Value = model.Listening;
            cmdParms[12].Value = model.TcnLeft;
            cmdParms[13].Value = model.TdcnRight;
            cmdParms[14].Value = model.HeartLung;
            cmdParms[15].Value = model.Stomach;
            cmdParms[16].Value = model.HemoglobinValue;
            cmdParms[17].Value = model.Other;
            cmdParms[18].Value = model.AmongTwoFolloNone;
            cmdParms[19].Value = model.PneumoniaFrequen;
            cmdParms[20].Value = model.DiarrhoeaFrequen;
            cmdParms[21].Value = model.TraumatismFrequen;
            cmdParms[22].Value = model.AmongTwoFolloOther;
            cmdParms[23].Value = model.ReferralAdvice;
            cmdParms[24].Value = model.ReferralReason;
            cmdParms[25].Value = model.AgenciesDepartments;
            cmdParms[26].Value = model.Guidance;
            cmdParms[27].Value = model.GuidanceOther;
            cmdParms[28].Value = model.NextVisitDate;
            cmdParms[29].Value = model.VisitDoctorSign;
            cmdParms[30].Value = model.Flag;
            cmdParms[31].Value = model.CreateBy;
            cmdParms[32].Value = model.CreateDate;
            cmdParms[33].Value = model.LastUpdateBy;
            cmdParms[34].Value = model.LastUpdateDate;
            cmdParms[35].Value = model.IsDel;
            cmdParms[36].Value = model.Kindergarten;
            cmdParms[37].Value = model.ManagerContact;
            cmdParms[38].Value = model.ManagerContactTel;
            cmdParms[39].Value = model.BodyInstitution;
            cmdParms[40].Value = model.InstitutionOther;
            cmdParms[41].Value = model.WeightVsHeight;
            cmdParms[42].Value = model.WeightVsHeightAnalysis;
            cmdParms[43].Value = model.Chest;
            cmdParms[44].Value = model.ReferraContacts;
            cmdParms[45].Value = model.ReferralContactsTel;
            cmdParms[46].Value = model.ReferralResult;
            cmdParms[47].Value = model.AuxeEstimate;
            cmdParms[48].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(KidsThreeToSixYearOldModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_kidsthreetosixyearold set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Name=@Name,");
            builder.Append("VisitDate=@VisitDate,");
            builder.Append("Weight=@Weight,");
            builder.Append("WeightAnalysis=@WeightAnalysis,");
            builder.Append("Stature=@Stature,");
            builder.Append("StatureAnalysis=@StatureAnalysis,");
            builder.Append("PhysicalAuxeEvaluat=@PhysicalAuxeEvaluat,");
            builder.Append("Sight=@Sight,");
            builder.Append("Listening=@Listening,");
            builder.Append("TcnLeft=@TcnLeft,");
            builder.Append("TdcnRight=@TdcnRight,");
            builder.Append("HeartLung=@HeartLung,");
            builder.Append("Stomach=@Stomach,");
            builder.Append("HemoglobinValue=@HemoglobinValue,");
            builder.Append("Other=@Other,");
            builder.Append("AmongTwoFolloNone=@AmongTwoFolloNone,");
            builder.Append("PneumoniaFrequen=@PneumoniaFrequen,");
            builder.Append("DiarrhoeaFrequen=@DiarrhoeaFrequen,");
            builder.Append("TraumatismFrequen=@TraumatismFrequen,");
            builder.Append("AmongTwoFolloOther=@AmongTwoFolloOther,");
            builder.Append("ReferralAdvice=@ReferralAdvice,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("AgenciesDepartments=@AgenciesDepartments,");
            builder.Append("Guidance=@Guidance,");
            builder.Append("GuidanceOther=@GuidanceOther,");
            builder.Append("NextVisitDate=@NextVisitDate,");
            builder.Append("VisitDoctorSign=@VisitDoctorSign,");
            builder.Append("Flag=@Flag,");
            builder.Append("CreateBy=@CreateBy,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("Kindergarten=@Kindergarten,");
            builder.Append("ManagerContact=@ManagerContact,");
            builder.Append("ManagerContactTel=@ManagerContactTel,");
            builder.Append("BodyInstitution=@BodyInstitution,");
            builder.Append("InstitutionOther=@InstitutionOther,");
            builder.Append("WeightVsHeight=@WeightVsHeight,");
            builder.Append("WeightVsHeightAnalysis=@WeightVsHeightAnalysis,");
            builder.Append("Chest=@Chest,");
            builder.Append("ReferraContacts=@ReferraContacts,");
            builder.Append("ReferralContactsTel=@ReferralContactsTel,");
            builder.Append("ReferralResult=@ReferralResult, ");
            builder.Append("AuxeEstimate=@AuxeEstimate ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String, 30), 
                new MySqlParameter("@VisitDate", MySqlDbType.Date), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@WeightAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@Stature", MySqlDbType.Decimal), 
                new MySqlParameter("@StatureAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@PhysicalAuxeEvaluat", MySqlDbType.String, 1),
                new MySqlParameter("@Sight", MySqlDbType.Decimal), 
                new MySqlParameter("@Listening", MySqlDbType.String, 1),
                new MySqlParameter("@TcnLeft", MySqlDbType.Decimal), 
                new MySqlParameter("@TdcnRight", MySqlDbType.Decimal), 
                new MySqlParameter("@HeartLung", MySqlDbType.String, 1), 
                new MySqlParameter("@Stomach", MySqlDbType.String, 1), 
                new MySqlParameter("@HemoglobinValue", MySqlDbType.Decimal), 
                new MySqlParameter("@Other", MySqlDbType.String, 100), 
                new MySqlParameter("@AmongTwoFolloNone", MySqlDbType.String, 1),
                new MySqlParameter("@PneumoniaFrequen", MySqlDbType.Decimal), 
                new MySqlParameter("@DiarrhoeaFrequen", MySqlDbType.Decimal), 
                new MySqlParameter("@TraumatismFrequen", MySqlDbType.Decimal),
                new MySqlParameter("@AmongTwoFolloOther", MySqlDbType.String, 200),
                new MySqlParameter("@ReferralAdvice", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@AgenciesDepartments", MySqlDbType.String, 80),
                new MySqlParameter("@Guidance", MySqlDbType.String, 30), 
                new MySqlParameter("@GuidanceOther", MySqlDbType.String, 100), 
                new MySqlParameter("@NextVisitDate", MySqlDbType.Date), 
                new MySqlParameter("@VisitDoctorSign", MySqlDbType.String, 30), 
                new MySqlParameter("@Flag", MySqlDbType.String, 1), 
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@Kindergarten", MySqlDbType.String, 50),
                new MySqlParameter("@ManagerContact", MySqlDbType.String, 50),
                new MySqlParameter("@ManagerContactTel", MySqlDbType.String, 50),
                new MySqlParameter("@BodyInstitution", MySqlDbType.String, 50),
                new MySqlParameter("@InstitutionOther", MySqlDbType.String, 50),
                new MySqlParameter("@WeightVsHeight", MySqlDbType.Decimal),
                new MySqlParameter("@WeightVsHeightAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1),
                new MySqlParameter("@AuxeEstimate",MySqlDbType.String,1)
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.VisitDate;
            cmdParms[5].Value = model.Weight;
            cmdParms[6].Value = model.WeightAnalysis;
            cmdParms[7].Value = model.Stature;
            cmdParms[8].Value = model.StatureAnalysis;
            cmdParms[9].Value = model.PhysicalAuxeEvaluat;
            cmdParms[10].Value = model.Sight;
            cmdParms[11].Value = model.Listening;
            cmdParms[12].Value = model.TcnLeft;
            cmdParms[13].Value = model.TdcnRight;
            cmdParms[14].Value = model.HeartLung;
            cmdParms[15].Value = model.Stomach;
            cmdParms[16].Value = model.HemoglobinValue;
            cmdParms[17].Value = model.Other;
            cmdParms[18].Value = model.AmongTwoFolloNone;
            cmdParms[19].Value = model.PneumoniaFrequen;
            cmdParms[20].Value = model.DiarrhoeaFrequen;
            cmdParms[21].Value = model.TraumatismFrequen;
            cmdParms[22].Value = model.AmongTwoFolloOther;
            cmdParms[23].Value = model.ReferralAdvice;
            cmdParms[24].Value = model.ReferralReason;
            cmdParms[25].Value = model.AgenciesDepartments;
            cmdParms[26].Value = model.Guidance;
            cmdParms[27].Value = model.GuidanceOther;
            cmdParms[28].Value = model.NextVisitDate;
            cmdParms[29].Value = model.VisitDoctorSign;
            cmdParms[30].Value = model.Flag;
            cmdParms[31].Value = model.CreateBy;
            cmdParms[32].Value = model.CreateDate;
            cmdParms[33].Value = model.LastUpdateBy;
            cmdParms[34].Value = model.LastUpdateDate;
            cmdParms[35].Value = model.IsDel;
            cmdParms[36].Value = model.Kindergarten;
            cmdParms[37].Value = model.ManagerContact;
            cmdParms[38].Value = model.ManagerContactTel;
            cmdParms[39].Value = model.BodyInstitution;
            cmdParms[40].Value = model.InstitutionOther;
            cmdParms[41].Value = model.WeightVsHeight;
            cmdParms[42].Value = model.WeightVsHeightAnalysis;
            cmdParms[43].Value = model.Chest;
            cmdParms[44].Value = model.ReferraContacts;
            cmdParms[45].Value = model.ReferralContactsTel;
            cmdParms[46].Value = model.ReferralResult;
            cmdParms[47].Value = model.AuxeEstimate;
           // cmdParms[36].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

