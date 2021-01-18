namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class WomenGravidaPostpartumDAL
    {
        public int Add(WomenGravidaPostpartumModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into GRAVIDA_POSTPARTUM(");
            builder.Append("CustomerID,RecordID,IDCardNo,FollowupDate,Tem,HealthCondition,Mentalcondition,HBbloodPressure,LBloodPressure,Breast,BreastEx,Lochia,LochiaEx,Uterus,UterusEx,Wound,WoundEx,Other,Classification,ClassificationEx,Advising,AdvisingOther,Referral,ReferralReason,ReferralOrg,NextFollowUpDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,");
            builder.Append("DeliveryDate,LeaveHospitalDate,ReferralContacts,ReferralContactsTel,ReferralResult)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@FollowupDate,@Tem,@HealthCondition,@Mentalcondition,@HBbloodPressure,@LBloodPressure,@Breast,@BreastEx,@Lochia,@LochiaEx,@Uterus,@UterusEx,@Wound,@WoundEx,@Other,@Classification,@ClassificationEx,@Advising,@AdvisingOther,@Referral,@ReferralReason,@ReferralOrg,@NextFollowUpDate,@FollowUpDoctor,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,");
            builder.Append("@DeliveryDate,@LeaveHospitalDate,@ReferralContacts,@ReferralContactsTel,@ReferralResult)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@Tem", MySqlDbType.Decimal), 
                new MySqlParameter("@HealthCondition", MySqlDbType.String, 200),
                new MySqlParameter("@Mentalcondition", MySqlDbType.String, 200), 
                new MySqlParameter("@HBbloodPressure", MySqlDbType.Decimal),
                new MySqlParameter("@LBloodPressure", MySqlDbType.Decimal),
                new MySqlParameter("@Breast", MySqlDbType.String, 1), 
                new MySqlParameter("@BreastEx", MySqlDbType.String, 200),
                new MySqlParameter("@Lochia", MySqlDbType.String, 1),
                new MySqlParameter("@LochiaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Uterus", MySqlDbType.String, 1), 
                new MySqlParameter("@UterusEx", MySqlDbType.String, 200),
                new MySqlParameter("@Wound", MySqlDbType.String, 1), 
                new MySqlParameter("@WoundEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Other", MySqlDbType.String, 500),
                new MySqlParameter("@Classification", MySqlDbType.String, 1),
                new MySqlParameter("@ClassificationEx", MySqlDbType.String, 200),
                new MySqlParameter("@Advising", MySqlDbType.String, 30),
                new MySqlParameter("@AdvisingOther", MySqlDbType.String, 200), 
                new MySqlParameter("@Referral", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@DeliveryDate", MySqlDbType.Date),
                new MySqlParameter("@LeaveHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContactsTel", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.FollowupDate;
            cmdParms[4].Value = model.Tem;
            cmdParms[5].Value = model.HealthCondition;
            cmdParms[6].Value = model.Mentalcondition;
            cmdParms[7].Value = model.HBbloodPressure;
            cmdParms[8].Value = model.LBloodPressure;
            cmdParms[9].Value = model.Breast;
            cmdParms[10].Value = model.BreastEx;
            cmdParms[11].Value = model.Lochia;
            cmdParms[12].Value = model.LochiaEx;
            cmdParms[13].Value = model.Uterus;
            cmdParms[14].Value = model.UterusEx;
            cmdParms[15].Value = model.Wound;
            cmdParms[16].Value = model.WoundEx;
            cmdParms[17].Value = model.Other;
            cmdParms[18].Value = model.Classification;
            cmdParms[19].Value = model.ClassificationEx;
            cmdParms[20].Value = model.Advising;
            cmdParms[21].Value = model.AdvisingOther;
            cmdParms[22].Value = model.Referral;
            cmdParms[23].Value = model.ReferralReason;
            cmdParms[24].Value = model.ReferralOrg;
            cmdParms[25].Value = model.NextFollowupDate;
            cmdParms[26].Value = model.FollowupDoctor;
            cmdParms[27].Value = model.CreatedBy;
            cmdParms[28].Value = model.CreatedDate;
            cmdParms[29].Value = model.LastUpdateBy;
            cmdParms[30].Value = model.LastUpdateDate;
            cmdParms[31].Value = model.IsDel;
            cmdParms[32].Value = model.DeliveryDate;
            cmdParms[33].Value = model.LeaveHospitalDate;
            cmdParms[34].Value = model.ReferralContacts;
            cmdParms[35].Value = model.ReferralContactsTel;
            cmdParms[36].Value = model.ReferralResult;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(WomenGravidaPostpartumModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into GRAVIDA_POSTPARTUM(");
            builder.Append("CustomerID,RecordID,IDCardNo,FollowupDate,Tem,HealthCondition,Mentalcondition,HBbloodPressure,LBloodPressure,Breast,BreastEx,Lochia,LochiaEx,Uterus,UterusEx,Wound,WoundEx,Other,Classification,ClassificationEx,Advising,AdvisingOther,Referral,ReferralReason,ReferralOrg,NextFollowUpDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,");
            builder.Append("DeliveryDate,LeaveHospitalDate,ReferralContacts,ReferralContactsTel,ReferralResult)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@FollowupDate,@Tem,@HealthCondition,@Mentalcondition,@HBbloodPressure,@LBloodPressure,@Breast,@BreastEx,@Lochia,@LochiaEx,@Uterus,@UterusEx,@Wound,@WoundEx,@Other,@Classification,@ClassificationEx,@Advising,@AdvisingOther,@Referral,@ReferralReason,@ReferralOrg,@NextFollowUpDate,@FollowUpDoctor,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,");
            builder.Append("@DeliveryDate,@LeaveHospitalDate,@ReferralContacts,@ReferralContactsTel,@ReferralResult)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@Tem", MySqlDbType.Decimal), 
                new MySqlParameter("@HealthCondition", MySqlDbType.String, 200),
                new MySqlParameter("@Mentalcondition", MySqlDbType.String, 200), 
                new MySqlParameter("@HBbloodPressure", MySqlDbType.Decimal),
                new MySqlParameter("@LBloodPressure", MySqlDbType.Decimal),
                new MySqlParameter("@Breast", MySqlDbType.String, 1), 
                new MySqlParameter("@BreastEx", MySqlDbType.String, 200),
                new MySqlParameter("@Lochia", MySqlDbType.String, 1),
                new MySqlParameter("@LochiaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Uterus", MySqlDbType.String, 1), 
                new MySqlParameter("@UterusEx", MySqlDbType.String, 200),
                new MySqlParameter("@Wound", MySqlDbType.String, 1), 
                new MySqlParameter("@WoundEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Other", MySqlDbType.String, 500),
                new MySqlParameter("@Classification", MySqlDbType.String, 1),
                new MySqlParameter("@ClassificationEx", MySqlDbType.String, 200),
                new MySqlParameter("@Advising", MySqlDbType.String, 30),
                new MySqlParameter("@AdvisingOther", MySqlDbType.String, 200), 
                new MySqlParameter("@Referral", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@DeliveryDate", MySqlDbType.Date),
                new MySqlParameter("@LeaveHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContactsTel", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.FollowupDate;
            cmdParms[4].Value = model.Tem;
            cmdParms[5].Value = model.HealthCondition;
            cmdParms[6].Value = model.Mentalcondition;
            cmdParms[7].Value = model.HBbloodPressure;
            cmdParms[8].Value = model.LBloodPressure;
            cmdParms[9].Value = model.Breast;
            cmdParms[10].Value = model.BreastEx;
            cmdParms[11].Value = model.Lochia;
            cmdParms[12].Value = model.LochiaEx;
            cmdParms[13].Value = model.Uterus;
            cmdParms[14].Value = model.UterusEx;
            cmdParms[15].Value = model.Wound;
            cmdParms[16].Value = model.WoundEx;
            cmdParms[17].Value = model.Other;
            cmdParms[18].Value = model.Classification;
            cmdParms[19].Value = model.ClassificationEx;
            cmdParms[20].Value = model.Advising;
            cmdParms[21].Value = model.AdvisingOther;
            cmdParms[22].Value = model.Referral;
            cmdParms[23].Value = model.ReferralReason;
            cmdParms[24].Value = model.ReferralOrg;
            cmdParms[25].Value = model.NextFollowupDate;
            cmdParms[26].Value = model.FollowupDoctor;
            cmdParms[27].Value = model.CreatedBy;
            cmdParms[28].Value = model.CreatedDate;
            cmdParms[29].Value = model.LastUpdateBy;
            cmdParms[30].Value = model.LastUpdateDate;
            cmdParms[31].Value = model.IsDel;
            cmdParms[32].Value = model.DeliveryDate;
            cmdParms[33].Value = model.LeaveHospitalDate;
            cmdParms[34].Value = model.ReferralContacts;
            cmdParms[35].Value = model.ReferralContactsTel;
            cmdParms[36].Value = model.ReferralResult;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public WomenGravidaPostpartumModel DataRowToModel(DataRow row)
        {
            WomenGravidaPostpartumModel gravida_postpartum = new WomenGravidaPostpartumModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    gravida_postpartum.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    gravida_postpartum.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    gravida_postpartum.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    gravida_postpartum.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["FollowupDate"] != null) && (row["FollowupDate"] != DBNull.Value)) && (row["FollowupDate"].ToString() != ""))
                {
                    gravida_postpartum.FollowupDate = new DateTime?(DateTime.Parse(row["FollowupDate"].ToString()));
                }
                if (((row["Tem"] != null) && (row["Tem"] != DBNull.Value)) && (row["Tem"].ToString() != ""))
                {
                    gravida_postpartum.Tem = new decimal?(decimal.Parse(row["Tem"].ToString()));
                }
                if ((row["HealthCondition"] != null) && (row["HealthCondition"] != DBNull.Value))
                {
                    gravida_postpartum.HealthCondition = row["HealthCondition"].ToString();
                }
                if ((row["Mentalcondition"] != null) && (row["Mentalcondition"] != DBNull.Value))
                {
                    gravida_postpartum.Mentalcondition = row["Mentalcondition"].ToString();
                }
                if (((row["HBbloodPressure"] != null) && (row["HBbloodPressure"] != DBNull.Value)) && (row["HBbloodPressure"].ToString() != ""))
                {
                    gravida_postpartum.HBbloodPressure = new decimal?(decimal.Parse(row["HBbloodPressure"].ToString()));
                }
                if (((row["LBloodPressure"] != null) && (row["LBloodPressure"] != DBNull.Value)) && (row["LBloodPressure"].ToString() != ""))
                {
                    gravida_postpartum.LBloodPressure = new decimal?(decimal.Parse(row["LBloodPressure"].ToString()));
                }
                if ((row["Breast"] != null) && (row["Breast"] != DBNull.Value))
                {
                    gravida_postpartum.Breast = row["Breast"].ToString();
                }
                if ((row["BreastEx"] != null) && (row["BreastEx"] != DBNull.Value))
                {
                    gravida_postpartum.BreastEx = row["BreastEx"].ToString();
                }
                if ((row["Lochia"] != null) && (row["Lochia"] != DBNull.Value))
                {
                    gravida_postpartum.Lochia = row["Lochia"].ToString();
                }
                if ((row["LochiaEx"] != null) && (row["LochiaEx"] != DBNull.Value))
                {
                    gravida_postpartum.LochiaEx = row["LochiaEx"].ToString();
                }
                if ((row["Uterus"] != null) && (row["Uterus"] != DBNull.Value))
                {
                    gravida_postpartum.Uterus = row["Uterus"].ToString();
                }
                if ((row["UterusEx"] != null) && (row["UterusEx"] != DBNull.Value))
                {
                    gravida_postpartum.UterusEx = row["UterusEx"].ToString();
                }
                if ((row["Wound"] != null) && (row["Wound"] != DBNull.Value))
                {
                    gravida_postpartum.Wound = row["Wound"].ToString();
                }
                if ((row["WoundEx"] != null) && (row["WoundEx"] != DBNull.Value))
                {
                    gravida_postpartum.WoundEx = row["WoundEx"].ToString();
                }
                if ((row["Other"] != null) && (row["Other"] != DBNull.Value))
                {
                    gravida_postpartum.Other = row["Other"].ToString();
                }
                if ((row["Classification"] != null) && (row["Classification"] != DBNull.Value))
                {
                    gravida_postpartum.Classification = row["Classification"].ToString();
                }
                if ((row["ClassificationEx"] != null) && (row["ClassificationEx"] != DBNull.Value))
                {
                    gravida_postpartum.ClassificationEx = row["ClassificationEx"].ToString();
                }
                if ((row["Advising"] != null) && (row["Advising"] != DBNull.Value))
                {
                    gravida_postpartum.Advising = row["Advising"].ToString();
                }
                if ((row["AdvisingOther"] != null) && (row["AdvisingOther"] != DBNull.Value))
                {
                    gravida_postpartum.AdvisingOther = row["AdvisingOther"].ToString();
                }
                if ((row["Referral"] != null) && (row["Referral"] != DBNull.Value))
                {
                    gravida_postpartum.Referral = row["Referral"].ToString();
                }
                if ((row["ReferralReason"] != null) && (row["ReferralReason"] != DBNull.Value))
                {
                    gravida_postpartum.ReferralReason = row["ReferralReason"].ToString();
                }
                if ((row["ReferralOrg"] != null) && (row["ReferralOrg"] != DBNull.Value))
                {
                    gravida_postpartum.ReferralOrg = row["ReferralOrg"].ToString();
                }
                if (((row["NextFollowUpDate"] != null) && (row["NextFollowUpDate"] != DBNull.Value)) && (row["NextFollowUpDate"].ToString() != ""))
                {
                    gravida_postpartum.NextFollowupDate = new DateTime?(DateTime.Parse(row["NextFollowUpDate"].ToString()));
                }
                if ((row["FollowUpDoctor"] != null) && (row["FollowUpDoctor"] != DBNull.Value))
                {
                    gravida_postpartum.FollowupDoctor = row["FollowUpDoctor"].ToString();
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    gravida_postpartum.CreatedBy = new decimal?(decimal.Parse(row["CreatedBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    gravida_postpartum.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    gravida_postpartum.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    gravida_postpartum.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    gravida_postpartum.IsDel = row["IsDel"].ToString();
                }
                if (((row["DeliveryDate"] != null) && (row["DeliveryDate"] != DBNull.Value)) && (row["DeliveryDate"].ToString() != ""))
                {
                    gravida_postpartum.DeliveryDate = new DateTime?(DateTime.Parse(row["DeliveryDate"].ToString()));
                }
                if (((row["LeaveHospitalDate"] != null) && (row["LeaveHospitalDate"] != DBNull.Value)) && (row["LeaveHospitalDate"].ToString() != ""))
                {
                    gravida_postpartum.LeaveHospitalDate = new DateTime?(DateTime.Parse(row["LeaveHospitalDate"].ToString()));
                }
                if ((row["ReferralContacts"] != null) && (row["ReferralContacts"] != DBNull.Value))
                {
                    gravida_postpartum.ReferralContacts = row["ReferralContacts"].ToString();
                }
                if ((row["ReferralContactsTel"] != null) && (row["ReferralContactsTel"] != DBNull.Value))
                {
                    gravida_postpartum.ReferralContactsTel = row["ReferralContactsTel"].ToString();
                }
                if ((row["ReferralResult"] != null) && (row["ReferralResult"] != DBNull.Value))
                {
                    gravida_postpartum.ReferralResult = row["ReferralResult"].ToString();
                }
            }
            return gravida_postpartum;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from GRAVIDA_POSTPARTUM ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from GRAVIDA_POSTPARTUM ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from GRAVIDA_POSTPARTUM");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,FollowupDate,Tem,HealthCondition,Mentalcondition,HBbloodPressure,LBloodPressure,Breast,BreastEx,Lochia,LochiaEx,Uterus,UterusEx,Wound,WoundEx,Other,Classification,ClassificationEx,Advising,AdvisingOther,Referral,ReferralReason,ReferralOrg,NextFollowUpDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel, ");
            builder.Append("DeliveryDate,LeaveHospitalDate,ReferralContacts,ReferralContactsTel,ReferralResult ");
            builder.Append(" FROM GRAVIDA_POSTPARTUM ");
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
            builder.Append(")AS Row, T.*  from GRAVIDA_POSTPARTUM T ");
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
            return MySQLHelper.GetMaxID("ID", "GRAVIDA_POSTPARTUM");
        }

        public WomenGravidaPostpartumModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,FollowupDate,Tem,HealthCondition,Mentalcondition,HBbloodPressure,LBloodPressure,Breast,BreastEx,Lochia,LochiaEx,Uterus,UterusEx,Wound,WoundEx,Other,Classification,ClassificationEx,Advising,AdvisingOther,Referral,ReferralReason,ReferralOrg,NextFollowUpDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,  ");
            builder.Append("DeliveryDate,LeaveHospitalDate,ReferralContacts,ReferralContactsTel,ReferralResult ");
            builder.Append("from GRAVIDA_POSTPARTUM ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new WomenGravidaPostpartumModel();
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
            builder.Append("select count(1) FROM GRAVIDA_POSTPARTUM ");
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

        public bool Update(WomenGravidaPostpartumModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update GRAVIDA_POSTPARTUM set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("Tem=@Tem,");
            builder.Append("HealthCondition=@HealthCondition,");
            builder.Append("Mentalcondition=@Mentalcondition,");
            builder.Append("HBbloodPressure=@HBbloodPressure,");
            builder.Append("LBloodPressure=@LBloodPressure,");
            builder.Append("Breast=@Breast,");
            builder.Append("BreastEx=@BreastEx,");
            builder.Append("Lochia=@Lochia,");
            builder.Append("LochiaEx=@LochiaEx,");
            builder.Append("Uterus=@Uterus,");
            builder.Append("UterusEx=@UterusEx,");
            builder.Append("Wound=@Wound,");
            builder.Append("WoundEx=@WoundEx,");
            builder.Append("Other=@Other,");
            builder.Append("Classification=@Classification,");
            builder.Append("ClassificationEx=@ClassificationEx,");
            builder.Append("Advising=@Advising,");
            builder.Append("AdvisingOther=@AdvisingOther,");
            builder.Append("Referral=@Referral,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralOrg=@ReferralOrg,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("DeliveryDate=@DeliveryDate,");
            builder.Append("LeaveHospitalDate=@LeaveHospitalDate,");
            builder.Append("ReferralContacts=@ReferralContacts,");
            builder.Append("ReferralContactsTel=@ReferralContactsTel,");
            builder.Append("ReferralResult=@ReferralResult ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                  new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@Tem", MySqlDbType.Decimal), 
                new MySqlParameter("@HealthCondition", MySqlDbType.String, 200),
                new MySqlParameter("@Mentalcondition", MySqlDbType.String, 200), 
                new MySqlParameter("@HBbloodPressure", MySqlDbType.Decimal),
                new MySqlParameter("@LBloodPressure", MySqlDbType.Decimal),
                new MySqlParameter("@Breast", MySqlDbType.String, 1), 
                new MySqlParameter("@BreastEx", MySqlDbType.String, 200),
                new MySqlParameter("@Lochia", MySqlDbType.String, 1),
                new MySqlParameter("@LochiaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Uterus", MySqlDbType.String, 1), 
                new MySqlParameter("@UterusEx", MySqlDbType.String, 200),
                new MySqlParameter("@Wound", MySqlDbType.String, 1), 
                new MySqlParameter("@WoundEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Other", MySqlDbType.String, 500),
                new MySqlParameter("@Classification", MySqlDbType.String, 1),
                new MySqlParameter("@ClassificationEx", MySqlDbType.String, 200),
                new MySqlParameter("@Advising", MySqlDbType.String, 30),
                new MySqlParameter("@AdvisingOther", MySqlDbType.String, 200), 
                new MySqlParameter("@Referral", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@DeliveryDate", MySqlDbType.Date),
                new MySqlParameter("@LeaveHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContactsTel", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
           cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.FollowupDate;
            cmdParms[4].Value = model.Tem;
            cmdParms[5].Value = model.HealthCondition;
            cmdParms[6].Value = model.Mentalcondition;
            cmdParms[7].Value = model.HBbloodPressure;
            cmdParms[8].Value = model.LBloodPressure;
            cmdParms[9].Value = model.Breast;
            cmdParms[10].Value = model.BreastEx;
            cmdParms[11].Value = model.Lochia;
            cmdParms[12].Value = model.LochiaEx;
            cmdParms[13].Value = model.Uterus;
            cmdParms[14].Value = model.UterusEx;
            cmdParms[15].Value = model.Wound;
            cmdParms[16].Value = model.WoundEx;
            cmdParms[17].Value = model.Other;
            cmdParms[18].Value = model.Classification;
            cmdParms[19].Value = model.ClassificationEx;
            cmdParms[20].Value = model.Advising;
            cmdParms[21].Value = model.AdvisingOther;
            cmdParms[22].Value = model.Referral;
            cmdParms[23].Value = model.ReferralReason;
            cmdParms[24].Value = model.ReferralOrg;
            cmdParms[25].Value = model.NextFollowupDate;
            cmdParms[26].Value = model.FollowupDoctor;
            cmdParms[27].Value = model.CreatedBy;
            cmdParms[28].Value = model.CreatedDate;
            cmdParms[29].Value = model.LastUpdateBy;
            cmdParms[30].Value = model.LastUpdateDate;
            cmdParms[31].Value = model.IsDel;
            cmdParms[32].Value = model.DeliveryDate;
            cmdParms[33].Value = model.LeaveHospitalDate;
            cmdParms[34].Value = model.ReferralContacts;
            cmdParms[35].Value = model.ReferralContactsTel;
            cmdParms[36].Value = model.ReferralResult;
            cmdParms[37].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(WomenGravidaPostpartumModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update GRAVIDA_POSTPARTUM set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("Tem=@Tem,");
            builder.Append("HealthCondition=@HealthCondition,");
            builder.Append("Mentalcondition=@Mentalcondition,");
            builder.Append("HBbloodPressure=@HBbloodPressure,");
            builder.Append("LBloodPressure=@LBloodPressure,");
            builder.Append("Breast=@Breast,");
            builder.Append("BreastEx=@BreastEx,");
            builder.Append("Lochia=@Lochia,");
            builder.Append("LochiaEx=@LochiaEx,");
            builder.Append("Uterus=@Uterus,");
            builder.Append("UterusEx=@UterusEx,");
            builder.Append("Wound=@Wound,");
            builder.Append("WoundEx=@WoundEx,");
            builder.Append("Other=@Other,");
            builder.Append("Classification=@Classification,");
            builder.Append("ClassificationEx=@ClassificationEx,");
            builder.Append("Advising=@Advising,");
            builder.Append("AdvisingOther=@AdvisingOther,");
            builder.Append("Referral=@Referral,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralOrg=@ReferralOrg,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("DeliveryDate=@DeliveryDate,");
            builder.Append("LeaveHospitalDate=@LeaveHospitalDate,");
            builder.Append("ReferralContacts=@ReferralContacts,");
            builder.Append("ReferralContactsTel=@ReferralContactsTel,");
            builder.Append("ReferralResult=@ReferralResult ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                  new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@Tem", MySqlDbType.Decimal), 
                new MySqlParameter("@HealthCondition", MySqlDbType.String, 200),
                new MySqlParameter("@Mentalcondition", MySqlDbType.String, 200), 
                new MySqlParameter("@HBbloodPressure", MySqlDbType.Decimal),
                new MySqlParameter("@LBloodPressure", MySqlDbType.Decimal),
                new MySqlParameter("@Breast", MySqlDbType.String, 1), 
                new MySqlParameter("@BreastEx", MySqlDbType.String, 200),
                new MySqlParameter("@Lochia", MySqlDbType.String, 1),
                new MySqlParameter("@LochiaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Uterus", MySqlDbType.String, 1), 
                new MySqlParameter("@UterusEx", MySqlDbType.String, 200),
                new MySqlParameter("@Wound", MySqlDbType.String, 1), 
                new MySqlParameter("@WoundEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Other", MySqlDbType.String, 500),
                new MySqlParameter("@Classification", MySqlDbType.String, 1),
                new MySqlParameter("@ClassificationEx", MySqlDbType.String, 200),
                new MySqlParameter("@Advising", MySqlDbType.String, 30),
                new MySqlParameter("@AdvisingOther", MySqlDbType.String, 200), 
                new MySqlParameter("@Referral", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@DeliveryDate", MySqlDbType.Date),
                new MySqlParameter("@LeaveHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContactsTel", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1)
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.FollowupDate;
            cmdParms[4].Value = model.Tem;
            cmdParms[5].Value = model.HealthCondition;
            cmdParms[6].Value = model.Mentalcondition;
            cmdParms[7].Value = model.HBbloodPressure;
            cmdParms[8].Value = model.LBloodPressure;
            cmdParms[9].Value = model.Breast;
            cmdParms[10].Value = model.BreastEx;
            cmdParms[11].Value = model.Lochia;
            cmdParms[12].Value = model.LochiaEx;
            cmdParms[13].Value = model.Uterus;
            cmdParms[14].Value = model.UterusEx;
            cmdParms[15].Value = model.Wound;
            cmdParms[16].Value = model.WoundEx;
            cmdParms[17].Value = model.Other;
            cmdParms[18].Value = model.Classification;
            cmdParms[19].Value = model.ClassificationEx;
            cmdParms[20].Value = model.Advising;
            cmdParms[21].Value = model.AdvisingOther;
            cmdParms[22].Value = model.Referral;
            cmdParms[23].Value = model.ReferralReason;
            cmdParms[24].Value = model.ReferralOrg;
            cmdParms[25].Value = model.NextFollowupDate;
            cmdParms[26].Value = model.FollowupDoctor;
            cmdParms[27].Value = model.CreatedBy;
            cmdParms[28].Value = model.CreatedDate;
            cmdParms[29].Value = model.LastUpdateBy;
            cmdParms[30].Value = model.LastUpdateDate;
            cmdParms[31].Value = model.IsDel;
            cmdParms[32].Value = model.DeliveryDate;
            cmdParms[33].Value = model.LeaveHospitalDate;
            cmdParms[34].Value = model.ReferralContacts;
            cmdParms[35].Value = model.ReferralContactsTel;
            cmdParms[36].Value = model.ReferralResult;
            //cmdParms[0x20].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

