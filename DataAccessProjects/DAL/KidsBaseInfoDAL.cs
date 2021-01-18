namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class KidsBaseInfoDAL
    {
        public int Add(KidsBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CHILD_BASEINFO(");
            builder.Append("IDCardNo,CustomerID,RecordID,FatherID,MotherID,PostalCode,MotherIdcard,");
            builder.Append("CreateUnitPhone,Childcare,ChildcarePhone,OccurrenceTime,CreateUnit,CurrentUnit,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,Sex,Birthday,Guardstatus,");
            builder.Append("FatherAge,FatherUnit,FatherPhone,MotherAge,MotherUnit,MotherPhone,");
            builder.Append("GuarderName,GuarderAge,GuarderUnit,GuarderPhone,Addr,CardNum,IsDel,FatherName,MotherName)");
            builder.Append(" values (");
            builder.Append("@IDCardNo,@CustomerID,@RecordID,@FatherID,@MotherID,@PostalCode,@MotherIdcard,@CreateUnitPhone,@Childcare,@ChildcarePhone,@OccurrenceTime,@CreateUnit,@CurrentUnit,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@Sex,@Birthday,@Guardstatus,@FatherAge,@FatherUnit,@FatherPhone,@MotherAge,@MotherUnit,@MotherPhone,@GuarderName,@GuarderAge,@GuarderUnit,@GuarderPhone,@Addr,@CardNum,@IsDel,@FatherName,@MotherName)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FatherID", MySqlDbType.String), 
                new MySqlParameter("@MotherID", MySqlDbType.String),
                new MySqlParameter("@PostalCode", MySqlDbType.String, 6),
                new MySqlParameter("@MotherIdcard", MySqlDbType.String, 18), 
                new MySqlParameter("@CreateUnitPhone", MySqlDbType.String, 15),
                new MySqlParameter("@Childcare", MySqlDbType.String, 200),
                new MySqlParameter("@ChildcarePhone", MySqlDbType.String, 15), 
                new MySqlParameter("@OccurrenceTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.String, 200),
                new MySqlParameter("@CurrentUnit", MySqlDbType.String, 200),
                new MySqlParameter("@CreatedBy", MySqlDbType.String),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@Sex", MySqlDbType.String, 1), 
                new MySqlParameter("@Birthday", MySqlDbType.Date), 
                new MySqlParameter("@Guardstatus", MySqlDbType.String),
                new MySqlParameter("@FatherAge", MySqlDbType.Int32),
                new MySqlParameter("@FatherUnit", MySqlDbType.String),
                new MySqlParameter("@FatherPhone", MySqlDbType.String),
                new MySqlParameter("@MotherAge", MySqlDbType.Int32), 
                new MySqlParameter("@MotherUnit", MySqlDbType.String), 
                new MySqlParameter("@MotherPhone", MySqlDbType.String),
                new MySqlParameter("@GuarderName", MySqlDbType.String),
                new MySqlParameter("@GuarderAge", MySqlDbType.Int32),
                new MySqlParameter("@GuarderUnit", MySqlDbType.String),
                new MySqlParameter("@GuarderPhone", MySqlDbType.String), 
                new MySqlParameter("@Addr", MySqlDbType.String), 
                new MySqlParameter("@CardNum", MySqlDbType.String),
                new MySqlParameter("@IsDel", MySqlDbType.String, 2),
                new MySqlParameter("@FatherName", MySqlDbType.String, 30), 
                new MySqlParameter("@MotherName", MySqlDbType.String, 30)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.FatherID;
            cmdParms[4].Value = model.MotherID;
            cmdParms[5].Value = model.PostalCode;
            cmdParms[6].Value = model.MotherIdcard;
            cmdParms[7].Value = model.CreateUnitPhone;
            cmdParms[8].Value = model.Childcare;
            cmdParms[9].Value = model.ChildcarePhone;
            cmdParms[10].Value = model.OccurrenceTime;
            cmdParms[11].Value = model.CreateUnit;
            cmdParms[12].Value = model.CurrentUnit;
            cmdParms[13].Value = model.CreatedBy;
            cmdParms[14].Value = model.CreatedDate;
            cmdParms[15].Value = model.LastUpdateBy;
            cmdParms[16].Value = model.LastUpdateDate;
            cmdParms[17].Value = model.Sex;
            cmdParms[18].Value = model.Birthday;
            cmdParms[19].Value = model.Guardstatus;
            cmdParms[20].Value = model.FatherAge;
            cmdParms[21].Value = model.FatherUnit;
            cmdParms[22].Value = model.FatherPhone;
            cmdParms[23].Value = model.MotherAge;
            cmdParms[24].Value = model.MotherUnit;
            cmdParms[25].Value = model.MotherPhone;
            cmdParms[26].Value = model.GuarderName;
            cmdParms[27].Value = model.GuarderAge;
            cmdParms[28].Value = model.GuarderUnit;
            cmdParms[29].Value = model.GuarderPhone;
            cmdParms[30].Value = model.Addr;
            cmdParms[31].Value = model.CardNum;
            cmdParms[32].Value = model.IsDel;
            cmdParms[33].Value = model.FatherName;
            cmdParms[34].Value = model.MotherName;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(KidsBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CHILD_BASEINFO(");
            builder.Append("IDCardNo,CustomerID,RecordID,FatherID,MotherID,PostalCode,MotherIdcard,");
            builder.Append("CreateUnitPhone,Childcare,ChildcarePhone,OccurrenceTime,CreateUnit,CurrentUnit,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,Sex,Birthday,Guardstatus,");
            builder.Append("FatherAge,FatherUnit,FatherPhone,MotherAge,MotherUnit,MotherPhone,");
            builder.Append("GuarderName,GuarderAge,GuarderUnit,GuarderPhone,Addr,CardNum,IsDel,FatherName,MotherName)");
            builder.Append(" values (");
            builder.Append("@IDCardNo,@CustomerID,@RecordID,@FatherID,@MotherID,@PostalCode,@MotherIdcard,@CreateUnitPhone,@Childcare,@ChildcarePhone,@OccurrenceTime,@CreateUnit,@CurrentUnit,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@Sex,@Birthday,@Guardstatus,@FatherAge,@FatherUnit,@FatherPhone,@MotherAge,@MotherUnit,@MotherPhone,@GuarderName,@GuarderAge,@GuarderUnit,@GuarderPhone,@Addr,@CardNum,@IsDel,@FatherName,@MotherName)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FatherID", MySqlDbType.String), 
                new MySqlParameter("@MotherID", MySqlDbType.String),
                new MySqlParameter("@PostalCode", MySqlDbType.String, 6),
                new MySqlParameter("@MotherIdcard", MySqlDbType.String, 18), 
                new MySqlParameter("@CreateUnitPhone", MySqlDbType.String, 15),
                new MySqlParameter("@Childcare", MySqlDbType.String, 200),
                new MySqlParameter("@ChildcarePhone", MySqlDbType.String, 15), 
                new MySqlParameter("@OccurrenceTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.String, 200),
                new MySqlParameter("@CurrentUnit", MySqlDbType.String, 200),
                new MySqlParameter("@CreatedBy", MySqlDbType.String),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@Sex", MySqlDbType.String, 1), 
                new MySqlParameter("@Birthday", MySqlDbType.Date), 
                new MySqlParameter("@Guardstatus", MySqlDbType.String),
                new MySqlParameter("@FatherAge", MySqlDbType.Int32),
                new MySqlParameter("@FatherUnit", MySqlDbType.String),
                new MySqlParameter("@FatherPhone", MySqlDbType.String),
                new MySqlParameter("@MotherAge", MySqlDbType.Int32), 
                new MySqlParameter("@MotherUnit", MySqlDbType.String), 
                new MySqlParameter("@MotherPhone", MySqlDbType.String),
                new MySqlParameter("@GuarderName", MySqlDbType.String),
                new MySqlParameter("@GuarderAge", MySqlDbType.Int32),
                new MySqlParameter("@GuarderUnit", MySqlDbType.String),
                new MySqlParameter("@GuarderPhone", MySqlDbType.String), 
                new MySqlParameter("@Addr", MySqlDbType.String), 
                new MySqlParameter("@CardNum", MySqlDbType.String),
                new MySqlParameter("@IsDel", MySqlDbType.String, 2),
                new MySqlParameter("@FatherName", MySqlDbType.String, 30), 
                new MySqlParameter("@MotherName", MySqlDbType.String, 30)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.FatherID;
            cmdParms[4].Value = model.MotherID;
            cmdParms[5].Value = model.PostalCode;
            cmdParms[6].Value = model.MotherIdcard;
            cmdParms[7].Value = model.CreateUnitPhone;
            cmdParms[8].Value = model.Childcare;
            cmdParms[9].Value = model.ChildcarePhone;
            cmdParms[10].Value = model.OccurrenceTime;
            cmdParms[11].Value = model.CreateUnit;
            cmdParms[12].Value = model.CurrentUnit;
            cmdParms[13].Value = model.CreatedBy;
            cmdParms[14].Value = model.CreatedDate;
            cmdParms[15].Value = model.LastUpdateBy;
            cmdParms[16].Value = model.LastUpdateDate;
            cmdParms[17].Value = model.Sex;
            cmdParms[18].Value = model.Birthday;
            cmdParms[19].Value = model.Guardstatus;
            cmdParms[20].Value = model.FatherAge;
            cmdParms[21].Value = model.FatherUnit;
            cmdParms[22].Value = model.FatherPhone;
            cmdParms[23].Value = model.MotherAge;
            cmdParms[24].Value = model.MotherUnit;
            cmdParms[25].Value = model.MotherPhone;
            cmdParms[26].Value = model.GuarderName;
            cmdParms[27].Value = model.GuarderAge;
            cmdParms[28].Value = model.GuarderUnit;
            cmdParms[29].Value = model.GuarderPhone;
            cmdParms[30].Value = model.Addr;
            cmdParms[31].Value = model.CardNum;
            cmdParms[32].Value = model.IsDel;
            cmdParms[33].Value = model.FatherName;
            cmdParms[34].Value = model.MotherName;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }


        public KidsBaseInfoModel DataRowToModel(DataRow row)
        {
            KidsBaseInfoModel kidsBaseInfoModel = new KidsBaseInfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    kidsBaseInfoModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    kidsBaseInfoModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    kidsBaseInfoModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    kidsBaseInfoModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["FatherID"] != null) && (row["FatherID"] != DBNull.Value)) && (row["FatherID"].ToString() != ""))
                {
                    kidsBaseInfoModel.FatherID = new decimal?(decimal.Parse(row["FatherID"].ToString()));
                }
                if (((row["MotherID"] != null) && (row["MotherID"] != DBNull.Value)) && (row["MotherID"].ToString() != ""))
                {
                    kidsBaseInfoModel.MotherID = new decimal?(decimal.Parse(row["MotherID"].ToString()));
                }
                if ((row["PostalCode"] != null) && (row["PostalCode"] != DBNull.Value))
                {
                    kidsBaseInfoModel.PostalCode = row["PostalCode"].ToString();
                }
                if ((row["MotherIdcard"] != null) && (row["MotherIdcard"] != DBNull.Value))
                {
                    kidsBaseInfoModel.MotherIdcard = row["MotherIdcard"].ToString();
                }
               
                if ((row["CreateUnitPhone"] != null) && (row["CreateUnitPhone"] != DBNull.Value))
                {
                    kidsBaseInfoModel.CreateUnitPhone = row["CreateUnitPhone"].ToString();
                }
                if ((row["Childcare"] != null) && (row["Childcare"] != DBNull.Value))
                {
                    kidsBaseInfoModel.Childcare = row["Childcare"].ToString();
                }
                if ((row["ChildcarePhone"] != null) && (row["ChildcarePhone"] != DBNull.Value))
                {
                    kidsBaseInfoModel.ChildcarePhone = row["ChildcarePhone"].ToString();
                }
                if (((row["OccurrenceTime"] != null) && (row["OccurrenceTime"] != DBNull.Value)) && (row["OccurrenceTime"].ToString() != ""))
                {
                    kidsBaseInfoModel.OccurrenceTime = new DateTime?(DateTime.Parse(row["OccurrenceTime"].ToString()));
                }
                if ((row["CreateUnit"] != null) && (row["CreateUnit"] != DBNull.Value))
                {
                    kidsBaseInfoModel.CreateUnit = row["CreateUnit"].ToString();
                }
                if ((row["CurrentUnit"] != null) && (row["CurrentUnit"] != DBNull.Value))
                {
                    kidsBaseInfoModel.CurrentUnit = row["CurrentUnit"].ToString();
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    kidsBaseInfoModel.CreatedBy = new decimal?(decimal.Parse(row["CreatedBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    kidsBaseInfoModel.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    kidsBaseInfoModel.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    kidsBaseInfoModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["Sex"] != null) && (row["Sex"] != DBNull.Value))
                {
                    kidsBaseInfoModel.Sex = row["Sex"].ToString();
                }
                if (((row["Birthday"] != null) && (row["Birthday"] != DBNull.Value)) && (row["Birthday"].ToString() != ""))
                {
                    kidsBaseInfoModel.Birthday = new DateTime?(DateTime.Parse(row["Birthday"].ToString()));
                }
                if ((row["Guardstatus"] != null) && (row["Guardstatus"] != DBNull.Value))
                {
                    kidsBaseInfoModel.Guardstatus = row["Guardstatus"].ToString();
                }
                if (((row["FatherAge"] != null) && (row["FatherAge"] != DBNull.Value)) && (row["FatherAge"].ToString() != ""))
                {
                    kidsBaseInfoModel.FatherAge = new decimal?(int.Parse(row["FatherAge"].ToString()));
                }
                if ((row["FatherUnit"] != null) && (row["FatherUnit"] != DBNull.Value))
                {
                    kidsBaseInfoModel.FatherUnit = row["FatherUnit"].ToString();
                }
                if ((row["FatherPhone"] != null) && (row["FatherPhone"] != DBNull.Value))
                {
                    kidsBaseInfoModel.FatherPhone = row["FatherPhone"].ToString();
                }
                if (((row["MotherAge"] != null) && (row["MotherAge"] != DBNull.Value)) && (row["MotherAge"].ToString() != ""))
                {
                    kidsBaseInfoModel.MotherAge = new decimal?(int.Parse(row["MotherAge"].ToString()));
                }
                if ((row["MotherUnit"] != null) && (row["MotherUnit"] != DBNull.Value))
                {
                    kidsBaseInfoModel.MotherUnit = row["MotherUnit"].ToString();
                }
                if ((row["MotherPhone"] != null) && (row["MotherPhone"] != DBNull.Value))
                {
                    kidsBaseInfoModel.MotherPhone = row["MotherPhone"].ToString();
                }
                if ((row["GuarderName"] != null) && (row["GuarderName"] != DBNull.Value))
                {
                    kidsBaseInfoModel.GuarderName = row["GuarderName"].ToString();
                }
                if (((row["GuarderAge"] != null) && (row["GuarderAge"] != DBNull.Value)) && (row["GuarderAge"].ToString() != ""))
                {
                    kidsBaseInfoModel.GuarderAge = new decimal?(int.Parse(row["GuarderAge"].ToString()));
                }
                if ((row["GuarderUnit"] != null) && (row["GuarderUnit"] != DBNull.Value))
                {
                    kidsBaseInfoModel.GuarderUnit = row["GuarderUnit"].ToString();
                }
                if ((row["GuarderPhone"] != null) && (row["GuarderPhone"] != DBNull.Value))
                {
                    kidsBaseInfoModel.GuarderPhone = row["GuarderPhone"].ToString();
                }
                if ((row["Addr"] != null) && (row["Addr"] != DBNull.Value))
                {
                    kidsBaseInfoModel.Addr = row["Addr"].ToString();
                }
                if ((row["CardNum"] != null) && (row["CardNum"] != DBNull.Value))
                {
                    kidsBaseInfoModel.CardNum = row["CardNum"].ToString();
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    kidsBaseInfoModel.IsDel = row["IsDel"].ToString();
                }
                if ((row["FatherName"] != null) && (row["FatherName"] != DBNull.Value))
                {
                    kidsBaseInfoModel.FatherName = row["FatherName"].ToString();
                }
                if ((row["MotherName"] != null) && (row["MotherName"] != DBNull.Value))
                {
                    kidsBaseInfoModel.MotherName = row["MotherName"].ToString();
                }
            }
            return kidsBaseInfoModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CHILD_BASEINFO ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CHILD_BASEINFO ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CHILD_BASEINFO");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,IDCardNo,CustomerID,RecordID,FatherID,MotherID,PostalCode,MotherIdcard,CreateUnitPhone,Childcare,ChildcarePhone,OccurrenceTime,CreateUnit,CurrentUnit,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,Sex,Birthday,Guardstatus,FatherAge,FatherUnit,FatherPhone,MotherAge,MotherUnit,MotherPhone,GuarderName,GuarderAge,GuarderUnit,GuarderPhone,Addr,CardNum,IsDel,FatherName,MotherName ");
            builder.Append(" FROM CHILD_BASEINFO ");
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
            builder.Append(")AS Row, T.*  from CHILD_BASEINFO T ");
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
            return MySQLHelper.GetMaxID("ID", "CHILD_BASEINFO");
        }

        public KidsBaseInfoModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,IDCardNo,CustomerID,RecordID,FatherID,MotherID,PostalCode,MotherIdcard,CreateUnitPhone,Childcare,ChildcarePhone,OccurrenceTime,CreateUnit,CurrentUnit,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,Sex,Birthday,Guardstatus,FatherAge,FatherUnit,FatherPhone,MotherAge,MotherUnit,MotherPhone,GuarderName,GuarderAge,GuarderUnit,GuarderPhone,Addr,CardNum,IsDel,FatherName,MotherName from CHILD_BASEINFO ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new KidsBaseInfoModel();
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
            builder.Append("select count(1) FROM CHILD_BASEINFO ");
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

        public bool Update(KidsBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CHILD_BASEINFO set ");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("FatherID=@FatherID,");
            builder.Append("MotherID=@MotherID,");
            builder.Append("PostalCode=@PostalCode,");
            builder.Append("MotherIdcard=@MotherIdcard,");
            builder.Append("CreateUnitPhone=@CreateUnitPhone,");
            builder.Append("Childcare=@Childcare,");
            builder.Append("ChildcarePhone=@ChildcarePhone,");
            builder.Append("OccurrenceTime=@OccurrenceTime,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("CurrentUnit=@CurrentUnit,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("Sex=@Sex,");
            builder.Append("Birthday=@Birthday,");
            builder.Append("Guardstatus=@Guardstatus,");
            builder.Append("FatherAge=@FatherAge,");
            builder.Append("FatherUnit=@FatherUnit,");
            builder.Append("FatherPhone=@FatherPhone,");
            builder.Append("MotherAge=@MotherAge,");
            builder.Append("MotherUnit=@MotherUnit,");
            builder.Append("MotherPhone=@MotherPhone,");
            builder.Append("GuarderName=@GuarderName,");
            builder.Append("GuarderAge=@GuarderAge,");
            builder.Append("GuarderUnit=@GuarderUnit,");
            builder.Append("GuarderPhone=@GuarderPhone,");
            builder.Append("Addr=@Addr,");
            builder.Append("CardNum=@CardNum,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("FatherName=@FatherName,");
            builder.Append("MotherName=@MotherName");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@FatherID", MySqlDbType.Decimal),
                new MySqlParameter("@MotherID", MySqlDbType.Decimal),
                new MySqlParameter("@PostalCode", MySqlDbType.String, 6),
                new MySqlParameter("@MotherIdcard", MySqlDbType.String, 18),
                //new MySqlParameter("@CurrentUnit", MySqlDbType.String, 200),
                new MySqlParameter("@CreateUnitPhone", MySqlDbType.String, 15),
                new MySqlParameter("@Childcare", MySqlDbType.String, 200),
                new MySqlParameter("@ChildcarePhone", MySqlDbType.String, 15),
                new MySqlParameter("@OccurrenceTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.String, 200),
                new MySqlParameter("@CurrentUnit", MySqlDbType.String, 200),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@Sex", MySqlDbType.String, 1), 
                new MySqlParameter("@Birthday", MySqlDbType.Date),
                new MySqlParameter("@Guardstatus",MySqlDbType.String,300), 
                new MySqlParameter("@FatherAge", MySqlDbType.Decimal),
                new MySqlParameter("@FatherUnit", MySqlDbType.String, 300),
                new MySqlParameter("@FatherPhone", MySqlDbType.String, 12),
                new MySqlParameter("@MotherAge", MySqlDbType.Decimal),
                new MySqlParameter("@MotherUnit", MySqlDbType.String, 300),
                new MySqlParameter("@MotherPhone", MySqlDbType.String, 12), 
                new MySqlParameter("@GuarderName", MySqlDbType.String, 30),
                new MySqlParameter("@GuarderAge", MySqlDbType.Decimal),
                new MySqlParameter("@GuarderUnit", MySqlDbType.String, 300),
                new MySqlParameter("@GuarderPhone", MySqlDbType.String, 12), 
                new MySqlParameter("@Addr", MySqlDbType.String, 500), 
                new MySqlParameter("@CardNum", MySqlDbType.String, 10),
                new MySqlParameter("@IsDel", MySqlDbType.String, 2), 
                new MySqlParameter("@FatherName", MySqlDbType.String, 30),
                new MySqlParameter("@MotherName", MySqlDbType.String, 30),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.CustomerID;
            cmdParms[2].Value = model.RecordID;
            cmdParms[3].Value = model.FatherID;
            cmdParms[4].Value = model.MotherID;
            cmdParms[5].Value = model.PostalCode;
            cmdParms[6].Value = model.MotherIdcard;
            cmdParms[7].Value = model.CreateUnitPhone;
            cmdParms[8].Value = model.Childcare;
            cmdParms[9].Value = model.ChildcarePhone;
            cmdParms[10].Value = model.OccurrenceTime;
            cmdParms[11].Value = model.CreateUnit;
            cmdParms[12].Value = model.CurrentUnit;
            cmdParms[13].Value = model.CreatedBy;
            cmdParms[14].Value = model.CreatedDate;
            cmdParms[15].Value = model.LastUpdateBy;
            cmdParms[16].Value = model.LastUpdateDate;
            cmdParms[17].Value = model.Sex;
            cmdParms[18].Value = model.Birthday;
            cmdParms[19].Value = model.Guardstatus;
            cmdParms[20].Value = model.FatherAge;
            cmdParms[21].Value = model.FatherUnit;
            cmdParms[22].Value = model.FatherPhone;
            cmdParms[23].Value = model.MotherAge;
            cmdParms[24].Value = model.MotherUnit;
            cmdParms[25].Value = model.MotherPhone;
            cmdParms[26].Value = model.GuarderName;
            cmdParms[27].Value = model.GuarderAge;
            cmdParms[28].Value = model.GuarderUnit;
            cmdParms[29].Value = model.GuarderPhone;
            cmdParms[30].Value = model.Addr;
            cmdParms[31].Value = model.CardNum;
            cmdParms[32].Value = model.IsDel;
            cmdParms[33].Value = model.FatherName;
            cmdParms[34].Value = model.MotherName;
            cmdParms[35].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(KidsBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CHILD_BASEINFO set ");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("FatherID=@FatherID,");
            builder.Append("MotherID=@MotherID,");
            builder.Append("PostalCode=@PostalCode,");
            builder.Append("MotherIdcard=@MotherIdcard,");
            builder.Append("CreateUnitPhone=@CreateUnitPhone,");
            builder.Append("Childcare=@Childcare,");
            builder.Append("ChildcarePhone=@ChildcarePhone,");
            builder.Append("OccurrenceTime=@OccurrenceTime,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("CurrentUnit=@CurrentUnit,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("Sex=@Sex,");
            builder.Append("Birthday=@Birthday,");
            builder.Append("Guardstatus=@Guardstatus,");
            builder.Append("FatherAge=@FatherAge,");
            builder.Append("FatherUnit=@FatherUnit,");
            builder.Append("FatherPhone=@FatherPhone,");
            builder.Append("MotherAge=@MotherAge,");
            builder.Append("MotherUnit=@MotherUnit,");
            builder.Append("MotherPhone=@MotherPhone,");
            builder.Append("GuarderName=@GuarderName,");
            builder.Append("GuarderAge=@GuarderAge,");
            builder.Append("GuarderUnit=@GuarderUnit,");
            builder.Append("GuarderPhone=@GuarderPhone,");
            builder.Append("Addr=@Addr,");
            builder.Append("CardNum=@CardNum,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("FatherName=@FatherName,");
            builder.Append("MotherName=@MotherName");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@FatherID", MySqlDbType.Decimal),
                new MySqlParameter("@MotherID", MySqlDbType.Decimal),
                new MySqlParameter("@PostalCode", MySqlDbType.String, 6),
                new MySqlParameter("@MotherIdcard", MySqlDbType.String, 18),
                //new MySqlParameter("@CurrentUnit", MySqlDbType.String, 100),
                new MySqlParameter("@CreateUnitPhone", MySqlDbType.String, 15),
                new MySqlParameter("@Childcare", MySqlDbType.String, 200),
                new MySqlParameter("@ChildcarePhone", MySqlDbType.String, 15),
                new MySqlParameter("@OccurrenceTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.String, 200),
                new MySqlParameter("@CurrentUnit", MySqlDbType.String, 200),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@Sex", MySqlDbType.String, 1), 
                new MySqlParameter("@Birthday", MySqlDbType.Date),
                new MySqlParameter("@Guardstatus",MySqlDbType.String,300), 
                new MySqlParameter("@FatherAge", MySqlDbType.Decimal),
                new MySqlParameter("@FatherUnit", MySqlDbType.String, 300),
                new MySqlParameter("@FatherPhone", MySqlDbType.String, 12),
                new MySqlParameter("@MotherAge", MySqlDbType.Decimal),
                new MySqlParameter("@MotherUnit", MySqlDbType.String, 300),
                new MySqlParameter("@MotherPhone", MySqlDbType.String, 12), 
                new MySqlParameter("@GuarderName", MySqlDbType.String, 30),
                new MySqlParameter("@GuarderAge", MySqlDbType.Decimal),
                new MySqlParameter("@GuarderUnit", MySqlDbType.String, 300),
                new MySqlParameter("@GuarderPhone", MySqlDbType.String, 12), 
                new MySqlParameter("@Addr", MySqlDbType.String, 500), 
                new MySqlParameter("@CardNum", MySqlDbType.String, 10),
                new MySqlParameter("@IsDel", MySqlDbType.String, 2), 
                new MySqlParameter("@FatherName", MySqlDbType.String, 30),
                new MySqlParameter("@MotherName", MySqlDbType.String, 30),
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.CustomerID;
            cmdParms[2].Value = model.RecordID;
            cmdParms[3].Value = model.FatherID;
            cmdParms[4].Value = model.MotherID;
            cmdParms[5].Value = model.PostalCode;
            cmdParms[6].Value = model.MotherIdcard;
            cmdParms[7].Value = model.CreateUnitPhone;
            cmdParms[8].Value = model.Childcare;
            cmdParms[9].Value = model.ChildcarePhone;
            cmdParms[10].Value = model.OccurrenceTime;
            cmdParms[11].Value = model.CreateUnit;
            cmdParms[12].Value = model.CurrentUnit;
            cmdParms[13].Value = model.CreatedBy;
            cmdParms[14].Value = model.CreatedDate;
            cmdParms[15].Value = model.LastUpdateBy;
            cmdParms[16].Value = model.LastUpdateDate;
            cmdParms[17].Value = model.Sex;
            cmdParms[18].Value = model.Birthday;
            cmdParms[19].Value = model.Guardstatus;
            cmdParms[20].Value = model.FatherAge;
            cmdParms[21].Value = model.FatherUnit;
            cmdParms[22].Value = model.FatherPhone;
            cmdParms[23].Value = model.MotherAge;
            cmdParms[24].Value = model.MotherUnit;
            cmdParms[25].Value = model.MotherPhone;
            cmdParms[26].Value = model.GuarderName;
            cmdParms[27].Value = model.GuarderAge;
            cmdParms[28].Value = model.GuarderUnit;
            cmdParms[29].Value = model.GuarderPhone;
            cmdParms[30].Value = model.Addr;
            cmdParms[31].Value = model.CardNum;
            cmdParms[32].Value = model.IsDel;
            cmdParms[33].Value = model.FatherName;
            cmdParms[34].Value = model.MotherName;
            //cmdParms[35].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

