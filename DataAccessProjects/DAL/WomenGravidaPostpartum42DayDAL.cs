namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class WomenGravidaPostpartum42DayDAL
    {
        public int Add(WomenGravidaPostpartum42DayModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_womengravidapostpartum42day(");
            builder.Append("CustomerID,RecordID,IDCardNo,FollowupDate,Healthcondition,Mentalcondition,Hbloodpressure,LBloodPressure,Breast,BreastEx,Lochia,LochiaEx,Uterus,UterusEx,Wound,WoundEx,Other,Classification,ClassificationEx,Advising,AdvisingOther,Treat,ReferralReason,ReferralOrg,NextFollowUpDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpDate,IsDel,");
            builder.Append("DeliveryDate,LeaveHospitalDate,CheckOrg,ReferralContacts,ReferralResult)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@FollowupDate,@Healthcondition,@Mentalcondition,@Hbloodpressure,@LBloodPressure,@Breast,@BreastEx,@Lochia,@LochiaEx,@Uterus,@UterusEx,@Wound,@WoundEx,@Other,@Classification,@ClassificationEx,@Advising,@AdvisingOther,@Treat,@ReferralReason,@ReferralOrg,@NextFollowUpDate,@FollowUpDoctor,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpDate,@IsDel,");
            builder.Append("@DeliveryDate,@LeaveHospitalDate,@CheckOrg,@ReferralContacts,@ReferralResult)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 0x20), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 0x11), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@Healthcondition", MySqlDbType.String, 200),
                new MySqlParameter("@Mentalcondition", MySqlDbType.String, 200),
                new MySqlParameter("@Hbloodpressure", MySqlDbType.Decimal, 0x7fffffff), 
                new MySqlParameter("@LBloodPressure", MySqlDbType.Decimal, 0x7fffffff),
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
                new MySqlParameter("@Treat", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500),
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal, 0x7fffffff), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal, 0x7fffffff), 
                new MySqlParameter("@LastUpDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@DeliveryDate", MySqlDbType.Date),
                new MySqlParameter("@LeaveHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@CheckOrg", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.FollowupDate;
            cmdParms[4].Value = model.Healthcondition;
            cmdParms[5].Value = model.Mentalcondition;
            cmdParms[6].Value = model.Hbloodpressure;
            cmdParms[7].Value = model.LBloodPressure;
            cmdParms[8].Value = model.Breast;
            cmdParms[9].Value = model.BreastEx;
            cmdParms[10].Value = model.Lochia;
            cmdParms[11].Value = model.LochiaEx;
            cmdParms[12].Value = model.Uterus;
            cmdParms[13].Value = model.UterusEx;
            cmdParms[14].Value = model.Wound;
            cmdParms[15].Value = model.WoundEx;
            cmdParms[16].Value = model.Other;
            cmdParms[17].Value = model.Classification;
            cmdParms[18].Value = model.ClassificationEx;
            cmdParms[19].Value = model.Advising;
            cmdParms[20].Value = model.AdvisingOther;
            cmdParms[21].Value = model.Treat;
            cmdParms[22].Value = model.ReferralReason;
            cmdParms[23].Value = model.ReferralOrg;
            cmdParms[24].Value = model.NextFollowUpDate;
            cmdParms[25].Value = model.FollowUpDoctor;
            cmdParms[26].Value = model.CreatedBy;
            cmdParms[27].Value = model.CreatedDate;
            cmdParms[28].Value = model.LastUpdateBy;
            cmdParms[29].Value = model.LastUpDate;
            cmdParms[30].Value = model.IsDel;
            cmdParms[31].Value = model.DeliveryDate;
            cmdParms[32].Value = model.LeaveHospitalDate;
            cmdParms[33].Value = model.CheckOrg;
            cmdParms[34].Value = model.ReferralContacts;
            cmdParms[35].Value = model.ReferralResult;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(WomenGravidaPostpartum42DayModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_womengravidapostpartum42day(");
            builder.Append("CustomerID,RecordID,IDCardNo,FollowupDate,Healthcondition,Mentalcondition,Hbloodpressure,LBloodPressure,Breast,BreastEx,Lochia,LochiaEx,Uterus,UterusEx,Wound,WoundEx,Other,Classification,ClassificationEx,Advising,AdvisingOther,Treat,ReferralReason,ReferralOrg,NextFollowUpDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpDate,IsDel,");
            builder.Append("DeliveryDate,LeaveHospitalDate,CheckOrg,ReferralContacts,ReferralResult)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@FollowupDate,@Healthcondition,@Mentalcondition,@Hbloodpressure,@LBloodPressure,@Breast,@BreastEx,@Lochia,@LochiaEx,@Uterus,@UterusEx,@Wound,@WoundEx,@Other,@Classification,@ClassificationEx,@Advising,@AdvisingOther,@Treat,@ReferralReason,@ReferralOrg,@NextFollowUpDate,@FollowUpDoctor,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpDate,@IsDel,");
            builder.Append("@DeliveryDate,@LeaveHospitalDate,@CheckOrg,@ReferralContacts,@ReferralResult)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 0x20), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 0x11), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@Healthcondition", MySqlDbType.String, 200),
                new MySqlParameter("@Mentalcondition", MySqlDbType.String, 200),
                new MySqlParameter("@Hbloodpressure", MySqlDbType.Decimal, 0x7fffffff), 
                new MySqlParameter("@LBloodPressure", MySqlDbType.Decimal, 0x7fffffff),
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
                new MySqlParameter("@Treat", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500),
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal, 0x7fffffff), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal, 0x7fffffff), 
                new MySqlParameter("@LastUpDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@DeliveryDate", MySqlDbType.Date),
                new MySqlParameter("@LeaveHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@CheckOrg", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.FollowupDate;
            cmdParms[4].Value = model.Healthcondition;
            cmdParms[5].Value = model.Mentalcondition;
            cmdParms[6].Value = model.Hbloodpressure;
            cmdParms[7].Value = model.LBloodPressure;
            cmdParms[8].Value = model.Breast;
            cmdParms[9].Value = model.BreastEx;
            cmdParms[10].Value = model.Lochia;
            cmdParms[11].Value = model.LochiaEx;
            cmdParms[12].Value = model.Uterus;
            cmdParms[13].Value = model.UterusEx;
            cmdParms[14].Value = model.Wound;
            cmdParms[15].Value = model.WoundEx;
            cmdParms[16].Value = model.Other;
            cmdParms[17].Value = model.Classification;
            cmdParms[18].Value = model.ClassificationEx;
            cmdParms[19].Value = model.Advising;
            cmdParms[20].Value = model.AdvisingOther;
            cmdParms[21].Value = model.Treat;
            cmdParms[22].Value = model.ReferralReason;
            cmdParms[23].Value = model.ReferralOrg;
            cmdParms[24].Value = model.NextFollowUpDate;
            cmdParms[25].Value = model.FollowUpDoctor;
            cmdParms[26].Value = model.CreatedBy;
            cmdParms[27].Value = model.CreatedDate;
            cmdParms[28].Value = model.LastUpdateBy;
            cmdParms[29].Value = model.LastUpDate;
            cmdParms[30].Value = model.IsDel;
            cmdParms[31].Value = model.DeliveryDate;
            cmdParms[32].Value = model.LeaveHospitalDate;
            cmdParms[33].Value = model.CheckOrg;
            cmdParms[34].Value = model.ReferralContacts;
            cmdParms[35].Value = model.ReferralResult;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public WomenGravidaPostpartum42DayModel DataRowToModel(DataRow row)
        {
            WomenGravidaPostpartum42DayModel gravida_postpartum_day = new WomenGravidaPostpartum42DayModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    gravida_postpartum_day.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    gravida_postpartum_day.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    gravida_postpartum_day.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    gravida_postpartum_day.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["FollowupDate"] != null) && (row["FollowupDate"] != DBNull.Value)) && (row["FollowupDate"].ToString() != ""))
                {
                    gravida_postpartum_day.FollowupDate = new DateTime?(DateTime.Parse(row["FollowupDate"].ToString()));
                }
                if ((row["Healthcondition"] != null) && (row["Healthcondition"] != DBNull.Value))
                {
                    gravida_postpartum_day.Healthcondition = row["Healthcondition"].ToString();
                }
                if ((row["Mentalcondition"] != null) && (row["Mentalcondition"] != DBNull.Value))
                {
                    gravida_postpartum_day.Mentalcondition = row["Mentalcondition"].ToString();
                }
                if (((row["Hbloodpressure"] != null) && (row["Hbloodpressure"] != DBNull.Value)) && (row["Hbloodpressure"].ToString() != ""))
                {
                    gravida_postpartum_day.Hbloodpressure = new decimal?(decimal.Parse(row["Hbloodpressure"].ToString()));
                }
                if (((row["LBloodPressure"] != null) && (row["LBloodPressure"] != DBNull.Value)) && (row["LBloodPressure"].ToString() != ""))
                {
                    gravida_postpartum_day.LBloodPressure = new decimal?(decimal.Parse(row["LBloodPressure"].ToString()));
                }
                if ((row["Breast"] != null) && (row["Breast"] != DBNull.Value))
                {
                    gravida_postpartum_day.Breast = row["Breast"].ToString();
                }
                if ((row["BreastEx"] != null) && (row["BreastEx"] != DBNull.Value))
                {
                    gravida_postpartum_day.BreastEx = row["BreastEx"].ToString();
                }
                if ((row["Lochia"] != null) && (row["Lochia"] != DBNull.Value))
                {
                    gravida_postpartum_day.Lochia = row["Lochia"].ToString();
                }
                if ((row["LochiaEx"] != null) && (row["LochiaEx"] != DBNull.Value))
                {
                    gravida_postpartum_day.LochiaEx = row["LochiaEx"].ToString();
                }
                if ((row["Uterus"] != null) && (row["Uterus"] != DBNull.Value))
                {
                    gravida_postpartum_day.Uterus = row["Uterus"].ToString();
                }
                if ((row["UterusEx"] != null) && (row["UterusEx"] != DBNull.Value))
                {
                    gravida_postpartum_day.UterusEx = row["UterusEx"].ToString();
                }
                if ((row["Wound"] != null) && (row["Wound"] != DBNull.Value))
                {
                    gravida_postpartum_day.Wound = row["Wound"].ToString();
                }
                if ((row["WoundEx"] != null) && (row["WoundEx"] != DBNull.Value))
                {
                    gravida_postpartum_day.WoundEx = row["WoundEx"].ToString();
                }
                if ((row["Other"] != null) && (row["Other"] != DBNull.Value))
                {
                    gravida_postpartum_day.Other = row["Other"].ToString();
                }
                if ((row["Classification"] != null) && (row["Classification"] != DBNull.Value))
                {
                    gravida_postpartum_day.Classification = row["Classification"].ToString();
                }
                if ((row["ClassificationEx"] != null) && (row["ClassificationEx"] != DBNull.Value))
                {
                    gravida_postpartum_day.ClassificationEx = row["ClassificationEx"].ToString();
                }
                if ((row["Advising"] != null) && (row["Advising"] != DBNull.Value))
                {
                    gravida_postpartum_day.Advising = row["Advising"].ToString();
                }
                if ((row["AdvisingOther"] != null) && (row["AdvisingOther"] != DBNull.Value))
                {
                    gravida_postpartum_day.AdvisingOther = row["AdvisingOther"].ToString();
                }
                if ((row["Treat"] != null) && (row["Treat"] != DBNull.Value))
                {
                    gravida_postpartum_day.Treat = row["Treat"].ToString();
                }
                if ((row["ReferralReason"] != null) && (row["ReferralReason"] != DBNull.Value))
                {
                    gravida_postpartum_day.ReferralReason = row["ReferralReason"].ToString();
                }
                if ((row["ReferralOrg"] != null) && (row["ReferralOrg"] != DBNull.Value))
                {
                    gravida_postpartum_day.ReferralOrg = row["ReferralOrg"].ToString();
                }
                if (((row["NextFollowUpDate"] != null) && (row["NextFollowUpDate"] != DBNull.Value)) && (row["NextFollowUpDate"].ToString() != ""))
                {
                    gravida_postpartum_day.NextFollowUpDate = new DateTime?(DateTime.Parse(row["NextFollowUpDate"].ToString()));
                }
                if ((row["FollowUpDoctor"] != null) && (row["FollowUpDoctor"] != DBNull.Value))
                {
                    gravida_postpartum_day.FollowUpDoctor = row["FollowUpDoctor"].ToString();
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    gravida_postpartum_day.CreatedBy = new decimal?(decimal.Parse(row["CreatedBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    gravida_postpartum_day.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    gravida_postpartum_day.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpDate"] != null) && (row["LastUpDate"] != DBNull.Value)) && (row["LastUpDate"].ToString() != ""))
                {
                    gravida_postpartum_day.LastUpDate = new DateTime?(DateTime.Parse(row["LastUpDate"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    gravida_postpartum_day.IsDel = row["IsDel"].ToString();
                }
                if (((row["DeliveryDate"] != null) && (row["DeliveryDate"] != DBNull.Value)) && (row["DeliveryDate"].ToString() != ""))
                {
                    gravida_postpartum_day.DeliveryDate = new DateTime?(DateTime.Parse(row["DeliveryDate"].ToString()));
                }
                if (((row["LeaveHospitalDate"] != null) && (row["LeaveHospitalDate"] != DBNull.Value)) && (row["LeaveHospitalDate"].ToString() != ""))
                {
                    gravida_postpartum_day.LeaveHospitalDate = new DateTime?(DateTime.Parse(row["LeaveHospitalDate"].ToString()));
                }
                if ((row["CheckOrg"] != null) && (row["CheckOrg"] != DBNull.Value))
                {
                    gravida_postpartum_day.CheckOrg = row["CheckOrg"].ToString();
                }
                if ((row["ReferralContacts"] != null) && (row["ReferralContacts"] != DBNull.Value))
                {
                    gravida_postpartum_day.ReferralContacts = row["ReferralContacts"].ToString();
                }
                if ((row["ReferralResult"] != null) && (row["ReferralResult"] != DBNull.Value))
                {
                    gravida_postpartum_day.ReferralResult = row["ReferralResult"].ToString();
                }
            }
            return gravida_postpartum_day;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_womengravidapostpartum42day ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_womengravidapostpartum42day ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_womengravidapostpartum42day");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,FollowupDate,Healthcondition,Mentalcondition,Hbloodpressure,LBloodPressure,Breast,BreastEx,Lochia,LochiaEx,Uterus,UterusEx,Wound,WoundEx,Other,Classification,ClassificationEx,Advising,AdvisingOther,Treat,ReferralReason,ReferralOrg,NextFollowUpDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpDate,IsDel, ");
            builder.Append("DeliveryDate,LeaveHospitalDate,CheckOrg,ReferralContacts,ReferralResult ");
            builder.Append(" FROM tbl_womengravidapostpartum42day ");
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
            builder.Append(")AS Row, T.*  from tbl_womengravidapostpartum42day T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_womengravidapostpartum42day");
        }

        public WomenGravidaPostpartum42DayModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,FollowupDate,Healthcondition,Mentalcondition,Hbloodpressure,LBloodPressure,Breast,BreastEx,Lochia,LochiaEx,Uterus,UterusEx,Wound,WoundEx,Other,Classification,ClassificationEx,Advising,AdvisingOther,Treat,ReferralReason,ReferralOrg,NextFollowUpDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpDate,IsDel, ");
            builder.Append("DeliveryDate,LeaveHospitalDate,CheckOrg,ReferralContacts,ReferralResult ");
            builder.Append(" FROM tbl_womengravidapostpartum42day ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new WomenGravidaPostpartum42DayModel();
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
            builder.Append("select count(1) FROM tbl_womengravidapostpartum42day ");
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

        public bool Update(WomenGravidaPostpartum42DayModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_womengravidapostpartum42day set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("Healthcondition=@Healthcondition,");
            builder.Append("Mentalcondition=@Mentalcondition,");
            builder.Append("Hbloodpressure=@Hbloodpressure,");
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
            builder.Append("Treat=@Treat,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralOrg=@ReferralOrg,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpDate=@LastUpDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("DeliveryDate=@DeliveryDate,");
            builder.Append("LeaveHospitalDate=@LeaveHospitalDate,");
            builder.Append("CheckOrg=@CheckOrg,");
            builder.Append("ReferralContacts=@ReferralContacts,");
            builder.Append("ReferralResult=@ReferralResult ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@Healthcondition", MySqlDbType.String, 200),
                new MySqlParameter("@Mentalcondition", MySqlDbType.String, 200),
                new MySqlParameter("@Hbloodpressure", MySqlDbType.Decimal), 
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
                new MySqlParameter("@Treat", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30), 
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@DeliveryDate", MySqlDbType.Date),
                new MySqlParameter("@LeaveHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@CheckOrg", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.FollowupDate;
            cmdParms[4].Value = model.Healthcondition;
            cmdParms[5].Value = model.Mentalcondition;
            cmdParms[6].Value = model.Hbloodpressure;
            cmdParms[7].Value = model.LBloodPressure;
            cmdParms[8].Value = model.Breast;
            cmdParms[9].Value = model.BreastEx;
            cmdParms[10].Value = model.Lochia;
            cmdParms[11].Value = model.LochiaEx;
            cmdParms[12].Value = model.Uterus;
            cmdParms[13].Value = model.UterusEx;
            cmdParms[14].Value = model.Wound;
            cmdParms[15].Value = model.WoundEx;
            cmdParms[16].Value = model.Other;
            cmdParms[17].Value = model.Classification;
            cmdParms[18].Value = model.ClassificationEx;
            cmdParms[19].Value = model.Advising;
            cmdParms[20].Value = model.AdvisingOther;
            cmdParms[21].Value = model.Treat;
            cmdParms[22].Value = model.ReferralReason;
            cmdParms[23].Value = model.ReferralOrg;
            cmdParms[24].Value = model.NextFollowUpDate;
            cmdParms[25].Value = model.FollowUpDoctor;
            cmdParms[26].Value = model.CreatedBy;
            cmdParms[27].Value = model.CreatedDate;
            cmdParms[28].Value = model.LastUpdateBy;
            cmdParms[29].Value = model.LastUpDate;
            cmdParms[30].Value = model.IsDel;
            cmdParms[31].Value = model.DeliveryDate;
            cmdParms[32].Value = model.LeaveHospitalDate;
            cmdParms[33].Value = model.CheckOrg;
            cmdParms[34].Value = model.ReferralContacts;
            cmdParms[35].Value = model.ReferralResult;
            cmdParms[36].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(WomenGravidaPostpartum42DayModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_womengravidapostpartum42day set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("Healthcondition=@Healthcondition,");
            builder.Append("Mentalcondition=@Mentalcondition,");
            builder.Append("Hbloodpressure=@Hbloodpressure,");
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
            builder.Append("Treat=@Treat,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralOrg=@ReferralOrg,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpDate=@LastUpDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("DeliveryDate=@DeliveryDate,");
            builder.Append("LeaveHospitalDate=@LeaveHospitalDate,");
            builder.Append("CheckOrg=@CheckOrg,");
            builder.Append("ReferralContacts=@ReferralContacts,");
            builder.Append("ReferralResult=@ReferralResult ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@Healthcondition", MySqlDbType.String, 200),
                new MySqlParameter("@Mentalcondition", MySqlDbType.String, 200),
                new MySqlParameter("@Hbloodpressure", MySqlDbType.Decimal), 
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
                new MySqlParameter("@Treat", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30), 
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@DeliveryDate", MySqlDbType.Date),
                new MySqlParameter("@LeaveHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@CheckOrg", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1)
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.FollowupDate;
            cmdParms[4].Value = model.Healthcondition;
            cmdParms[5].Value = model.Mentalcondition;
            cmdParms[6].Value = model.Hbloodpressure;
            cmdParms[7].Value = model.LBloodPressure;
            cmdParms[8].Value = model.Breast;
            cmdParms[9].Value = model.BreastEx;
            cmdParms[10].Value = model.Lochia;
            cmdParms[11].Value = model.LochiaEx;
            cmdParms[12].Value = model.Uterus;
            cmdParms[13].Value = model.UterusEx;
            cmdParms[14].Value = model.Wound;
            cmdParms[15].Value = model.WoundEx;
            cmdParms[16].Value = model.Other;
            cmdParms[17].Value = model.Classification;
            cmdParms[18].Value = model.ClassificationEx;
            cmdParms[19].Value = model.Advising;
            cmdParms[20].Value = model.AdvisingOther;
            cmdParms[21].Value = model.Treat;
            cmdParms[22].Value = model.ReferralReason;
            cmdParms[23].Value = model.ReferralOrg;
            cmdParms[24].Value = model.NextFollowUpDate;
            cmdParms[25].Value = model.FollowUpDoctor;
            cmdParms[26].Value = model.CreatedBy;
            cmdParms[27].Value = model.CreatedDate;
            cmdParms[28].Value = model.LastUpdateBy;
            cmdParms[29].Value = model.LastUpDate;
            cmdParms[30].Value = model.IsDel;
            cmdParms[31].Value = model.DeliveryDate;
            cmdParms[32].Value = model.LeaveHospitalDate;
            cmdParms[33].Value = model.CheckOrg;
            cmdParms[34].Value = model.ReferralContacts;
            cmdParms[35].Value = model.ReferralResult;
            //cmdParms[31].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

