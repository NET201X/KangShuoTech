namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class WomenGravidaBaseInfoDAL
    {
        public int Add(WomenGravidaBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into GRAVIDA_BASEINFO(");
            builder.Append("CustomerID,RecordID,IDCardNo,Name,Age,Culture,Job,Address,Nation,Birthday,Living,Phone,HealthResot, ");
            builder.Append("TownName,VillageName,PwPhone,HusbandName,HusbandPhone,CurrentUnit,CreateUnit,CreatedBy,CreatedDate, ");
            builder.Append("LastUpdateBy,LastUpdateDate,IsDel,HouseholdTown,HouseholdVillage,AddrTown,AddrVillage,AddrPhone, ");
            builder.Append("WorkUnit,UnitPhone,HusbandAge,HusbandCulture,HusbandNation,HusbandUnit,HbUnitPhone,HusbandJob,CardNum,CreatePhone,CreateDate)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Name,@Age,@Culture,@Job,@Address,@Nation,@Birthday,@Living,@Phone,@HealthResot, ");
            builder.Append("@TownName,@VillageName,@PwPhone,@HusbandName,@HusbandPhone,@CurrentUnit,@CreateUnit,@CreatedBy,@CreatedDate, ");
            builder.Append("@LastUpdateBy,@LastUpdateDate,@IsDel,@HouseholdTown,@HouseholdVillage,@AddrTown,@AddrVillage,@AddrPhone, ");
            builder.Append("@WorkUnit,@UnitPhone,@HusbandAge,@HusbandCulture,@HusbandNation,@HusbandUnit,@HbUnitPhone,@HusbandJob,@CardNum,@CreatePhone,@CreateDate )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String), 
                new MySqlParameter("@Age", MySqlDbType.Decimal), 
                new MySqlParameter("@Culture", MySqlDbType.String, 1), 
                new MySqlParameter("@Job", MySqlDbType.String, 1), 
                new MySqlParameter("@Address", MySqlDbType.String), 
                new MySqlParameter("@Nation", MySqlDbType.String, 1), 
                new MySqlParameter("@Birthday", MySqlDbType.Date), 
                new MySqlParameter("@Living", MySqlDbType.String), 
                new MySqlParameter("@Phone", MySqlDbType.String), 
                new MySqlParameter("@HealthResot", MySqlDbType.String), 
                new MySqlParameter("@TownName", MySqlDbType.String), 
                new MySqlParameter("@VillageName", MySqlDbType.String),
                new MySqlParameter("@PwPhone", MySqlDbType.String), 
                new MySqlParameter("@HusbandName", MySqlDbType.String),
                new MySqlParameter("@HusbandPhone", MySqlDbType.String),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@HouseholdTown", MySqlDbType.String),
                new MySqlParameter("@HouseholdVillage", MySqlDbType.String),
                new MySqlParameter("@AddrTown", MySqlDbType.String), 
                new MySqlParameter( "@AddrVillage",MySqlDbType.String),
                new MySqlParameter("@AddrPhone", MySqlDbType.String),
                new MySqlParameter("@WorkUnit", MySqlDbType.String), 
                new MySqlParameter("@UnitPhone", MySqlDbType.String), 
                new MySqlParameter("@HusbandAge", MySqlDbType.Decimal), 
                new MySqlParameter("@HusbandCulture", MySqlDbType.String),
                new MySqlParameter("@HusbandNation", MySqlDbType.String), 
                new MySqlParameter("@HusbandUnit", MySqlDbType.String), 
                new MySqlParameter("@HbUnitPhone", MySqlDbType.String), 
                new MySqlParameter("@HusbandJob", MySqlDbType.String, 2), 
                new MySqlParameter("@CardNum", MySqlDbType.String), 
                new MySqlParameter("@CreatePhone", MySqlDbType.String), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.Age;
            cmdParms[5].Value = model.Culture;
            cmdParms[6].Value = model.Job;
            cmdParms[7].Value = model.Address;
            cmdParms[8].Value = model.Nation;
            cmdParms[9].Value = model.Birthday;
            cmdParms[10].Value = model.Living;
            cmdParms[11].Value = model.Phone;
            cmdParms[12].Value = model.HealthResot;
            cmdParms[13].Value = model.TownName;
            cmdParms[14].Value = model.VillageName;
            cmdParms[15].Value = model.PwPhone;
            cmdParms[16].Value = model.HusbandName;
            cmdParms[17].Value = model.HusbandPhone;
            cmdParms[18].Value = model.CurrentUnit;
            cmdParms[19].Value = model.CreateUnit;
            cmdParms[20].Value = model.CreatedBy;
            cmdParms[21].Value = model.CreatedDate;
            cmdParms[22].Value = model.LastUpdateBy;
            cmdParms[23].Value = model.LastUpdateDate;
            cmdParms[24].Value = model.IsDel;
            cmdParms[25].Value = model.HouseholdTown;
            cmdParms[26].Value = model.HouseholdVillage;
            cmdParms[27].Value = model.AddrTown;
            cmdParms[28].Value = model.AddrVillage;
            cmdParms[29].Value = model.AddrPhone;
            cmdParms[30].Value = model.WorkUnit;
            cmdParms[31].Value = model.UnitPhone;
            cmdParms[32].Value = model.HusbandAge;
            cmdParms[33].Value = model.HusbandCulture;
            cmdParms[34].Value = model.HusbandNation;
            cmdParms[35].Value = model.HusbandUnit;
            cmdParms[36].Value = model.HbUnitPhone;
            cmdParms[37].Value = model.HusbandJob;
            cmdParms[38].Value = model.CardNum;
            cmdParms[39].Value = model.CreatePhone;
            cmdParms[40].Value = model.CreateDate;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(WomenGravidaBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into GRAVIDA_BASEINFO(");
            builder.Append("CustomerID,RecordID,IDCardNo,Name,Age,Culture,Job,Address,Nation,Birthday,Living,Phone,HealthResot, ");
            builder.Append("TownName,VillageName,PwPhone,HusbandName,HusbandPhone,CurrentUnit,CreateUnit,CreatedBy,CreatedDate, ");
            builder.Append("LastUpdateBy,LastUpdateDate,IsDel,HouseholdTown,HouseholdVillage,AddrTown,AddrVillage,AddrPhone, ");
            builder.Append("WorkUnit,UnitPhone,HusbandAge,HusbandCulture,HusbandNation,HusbandUnit,HbUnitPhone,HusbandJob,CardNum,CreatePhone,CreateDate)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Name,@Age,@Culture,@Job,@Address,@Nation,@Birthday,@Living,@Phone,@HealthResot, ");
            builder.Append("@TownName,@VillageName,@PwPhone,@HusbandName,@HusbandPhone,@CurrentUnit,@CreateUnit,@CreatedBy,@CreatedDate, ");
            builder.Append("@LastUpdateBy,@LastUpdateDate,@IsDel,@HouseholdTown,@HouseholdVillage,@AddrTown,@AddrVillage,@AddrPhone, ");
            builder.Append("@WorkUnit,@UnitPhone,@HusbandAge,@HusbandCulture,@HusbandNation,@HusbandUnit,@HbUnitPhone,@HusbandJob,@CardNum,@CreatePhone,@CreateDate )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String), 
                new MySqlParameter("@Age", MySqlDbType.Decimal), 
                new MySqlParameter("@Culture", MySqlDbType.String, 1), 
                new MySqlParameter("@Job", MySqlDbType.String, 1), 
                new MySqlParameter("@Address", MySqlDbType.String), 
                new MySqlParameter("@Nation", MySqlDbType.String, 1), 
                new MySqlParameter("@Birthday", MySqlDbType.Date), 
                new MySqlParameter("@Living", MySqlDbType.String), 
                new MySqlParameter("@Phone", MySqlDbType.String), 
                new MySqlParameter("@HealthResot", MySqlDbType.String), 
                new MySqlParameter("@TownName", MySqlDbType.String), 
                new MySqlParameter("@VillageName", MySqlDbType.String),
                new MySqlParameter("@PwPhone", MySqlDbType.String), 
                new MySqlParameter("@HusbandName", MySqlDbType.String),
                new MySqlParameter("@HusbandPhone", MySqlDbType.String),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@HouseholdTown", MySqlDbType.String),
                new MySqlParameter("@HouseholdVillage", MySqlDbType.String),
                new MySqlParameter("@AddrTown", MySqlDbType.String), 
                new MySqlParameter( "@AddrVillage",MySqlDbType.String),
                new MySqlParameter("@AddrPhone", MySqlDbType.String),
                new MySqlParameter("@WorkUnit", MySqlDbType.String), 
                new MySqlParameter("@UnitPhone", MySqlDbType.String), 
                new MySqlParameter("@HusbandAge", MySqlDbType.Decimal), 
                new MySqlParameter("@HusbandCulture", MySqlDbType.String),
                new MySqlParameter("@HusbandNation", MySqlDbType.String), 
                new MySqlParameter("@HusbandUnit", MySqlDbType.String), 
                new MySqlParameter("@HbUnitPhone", MySqlDbType.String), 
                new MySqlParameter("@HusbandJob", MySqlDbType.String, 2), 
                new MySqlParameter("@CardNum", MySqlDbType.String), 
                new MySqlParameter("@CreatePhone", MySqlDbType.String), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.Age;
            cmdParms[5].Value = model.Culture;
            cmdParms[6].Value = model.Job;
            cmdParms[7].Value = model.Address;
            cmdParms[8].Value = model.Nation;
            cmdParms[9].Value = model.Birthday;
            cmdParms[10].Value = model.Living;
            cmdParms[11].Value = model.Phone;
            cmdParms[12].Value = model.HealthResot;
            cmdParms[13].Value = model.TownName;
            cmdParms[14].Value = model.VillageName;
            cmdParms[15].Value = model.PwPhone;
            cmdParms[16].Value = model.HusbandName;
            cmdParms[17].Value = model.HusbandPhone;
            cmdParms[18].Value = model.CurrentUnit;
            cmdParms[19].Value = model.CreateUnit;
            cmdParms[20].Value = model.CreatedBy;
            cmdParms[21].Value = model.CreatedDate;
            cmdParms[22].Value = model.LastUpdateBy;
            cmdParms[23].Value = model.LastUpdateDate;
            cmdParms[24].Value = model.IsDel;
            cmdParms[25].Value = model.HouseholdTown;
            cmdParms[26].Value = model.HouseholdVillage;
            cmdParms[27].Value = model.AddrTown;
            cmdParms[28].Value = model.AddrVillage;
            cmdParms[29].Value = model.AddrPhone;
            cmdParms[30].Value = model.WorkUnit;
            cmdParms[31].Value = model.UnitPhone;
            cmdParms[32].Value = model.HusbandAge;
            cmdParms[33].Value = model.HusbandCulture;
            cmdParms[34].Value = model.HusbandNation;
            cmdParms[35].Value = model.HusbandUnit;
            cmdParms[36].Value = model.HbUnitPhone;
            cmdParms[37].Value = model.HusbandJob;
            cmdParms[38].Value = model.CardNum;
            cmdParms[39].Value = model.CreatePhone;
            cmdParms[40].Value = model.CreateDate;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public void CheckColumns()
        {
            foreach (DataRow row in MySQLHelper.Query(string.Format("PRAGMA table_info([{0}])", "GRAVIDA_BASEINFO")).Tables[0].Rows)
            {
                bool flag1 = row["name"].ToString() == "HouseholdTown";
            }
        }

        public WomenGravidaBaseInfoModel DataRowToModel(DataRow row)
        {
            WomenGravidaBaseInfoModel gravida_baseinfo = new WomenGravidaBaseInfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    gravida_baseinfo.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    gravida_baseinfo.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    gravida_baseinfo.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    gravida_baseinfo.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Name"] != null) && (row["Name"] != DBNull.Value))
                {
                    gravida_baseinfo.Name = row["Name"].ToString();
                }
                if (((row["Age"] != null) && (row["Age"] != DBNull.Value)) && (row["Age"].ToString() != ""))
                {
                    gravida_baseinfo.Age = new decimal?(decimal.Parse(row["Age"].ToString()));
                }
                if ((row["Culture"] != null) && (row["Culture"] != DBNull.Value))
                {
                    gravida_baseinfo.Culture = row["Culture"].ToString();
                }
                if ((row["Job"] != null) && (row["Job"] != DBNull.Value))
                {
                    gravida_baseinfo.Job = row["Job"].ToString();
                }
                if ((row["Address"] != null) && (row["Address"] != DBNull.Value))
                {
                    gravida_baseinfo.Address = row["Address"].ToString();
                }
                if ((row["Nation"] != null) && (row["Nation"] != DBNull.Value))
                {
                    gravida_baseinfo.Nation = row["Nation"].ToString();
                }
                if (((row["Birthday"] != null) && (row["Birthday"] != DBNull.Value)) && (row["Birthday"].ToString() != ""))
                {
                    gravida_baseinfo.Birthday = new DateTime?(DateTime.Parse(row["Birthday"].ToString()));
                }
                if ((row["Living"] != null) && (row["Living"] != DBNull.Value))
                {
                    gravida_baseinfo.Living = row["Living"].ToString();
                }
                if ((row["Phone"] != null) && (row["Phone"] != DBNull.Value))
                {
                    gravida_baseinfo.Phone = row["Phone"].ToString();
                }
                if ((row["HealthResot"] != null) && (row["HealthResot"] != DBNull.Value))
                {
                    gravida_baseinfo.HealthResot = row["HealthResot"].ToString();
                }
                if ((row["TownName"] != null) && (row["TownName"] != DBNull.Value))
                {
                    gravida_baseinfo.TownName = row["TownName"].ToString();
                }
                if ((row["VillageName"] != null) && (row["VillageName"] != DBNull.Value))
                {
                    gravida_baseinfo.VillageName = row["VillageName"].ToString();
                }
                if ((row["PwPhone"] != null) && (row["PwPhone"] != DBNull.Value))
                {
                    gravida_baseinfo.PwPhone = row["PwPhone"].ToString();
                }
                if ((row["HusbandName"] != null) && (row["HusbandName"] != DBNull.Value))
                {
                    gravida_baseinfo.HusbandName = row["HusbandName"].ToString();
                }
                if ((row["HusbandPhone"] != null) && (row["HusbandPhone"] != DBNull.Value))
                {
                    gravida_baseinfo.HusbandPhone = row["HusbandPhone"].ToString();
                }
                if (((row["CurrentUnit"] != null) && (row["CurrentUnit"] != DBNull.Value)) && (row["CurrentUnit"].ToString() != ""))
                {
                    gravida_baseinfo.CurrentUnit = new decimal?(decimal.Parse(row["CurrentUnit"].ToString()));
                }
                if (((row["CreateUnit"] != null) && (row["CreateUnit"] != DBNull.Value)) && (row["CreateUnit"].ToString() != ""))
                {
                    gravida_baseinfo.CreateUnit = new decimal?(decimal.Parse(row["CreateUnit"].ToString()));
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    gravida_baseinfo.CreatedBy = new decimal?(decimal.Parse(row["CreatedBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    gravida_baseinfo.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    gravida_baseinfo.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    gravida_baseinfo.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    gravida_baseinfo.IsDel = row["IsDel"].ToString();
                }
                if ((row["HouseholdTown"] != null) && (row["HouseholdTown"] != DBNull.Value))
                {
                    gravida_baseinfo.HouseholdTown = row["HouseholdTown"].ToString();
                }
                if ((row["HouseholdVillage"] != null) && (row["HouseholdVillage"] != DBNull.Value))
                {
                    gravida_baseinfo.HouseholdVillage = row["HouseholdVillage"].ToString();
                }
                if ((row["AddrTown"] != null) && (row["AddrTown"] != DBNull.Value))
                {
                    gravida_baseinfo.AddrTown = row["AddrTown"].ToString();
                }
                if ((row["AddrVillage"] != null) && (row["AddrVillage"] != DBNull.Value))
                {
                    gravida_baseinfo.AddrVillage = row["AddrVillage"].ToString();
                }
                if ((row["AddrPhone"] != null) && (row["AddrPhone"] != DBNull.Value))
                {
                    gravida_baseinfo.AddrPhone = row["AddrPhone"].ToString();
                }
                if ((row["WorkUnit"] != null) && (row["WorkUnit"] != DBNull.Value))
                {
                    gravida_baseinfo.WorkUnit = row["WorkUnit"].ToString();
                }
                if ((row["UnitPhone"] != null) && (row["UnitPhone"] != DBNull.Value))
                {
                    gravida_baseinfo.UnitPhone = row["UnitPhone"].ToString();
                }
                if (((row["HusbandAge"] != null) && (row["HusbandAge"] != DBNull.Value)) && (row["HusbandAge"].ToString() != ""))
                {
                    gravida_baseinfo.HusbandAge = new decimal?(decimal.Parse(row["HusbandAge"].ToString()));
                }
                if ((row["HusbandCulture"] != null) && (row["HusbandCulture"] != DBNull.Value))
                {
                    gravida_baseinfo.HusbandCulture = row["HusbandCulture"].ToString();
                }
                if ((row["HusbandNation"] != null) && (row["HusbandNation"] != DBNull.Value))
                {
                    gravida_baseinfo.HusbandNation = row["HusbandNation"].ToString();
                }
                if ((row["HusbandUnit"] != null) && (row["HusbandUnit"] != DBNull.Value))
                {
                    gravida_baseinfo.HusbandUnit = row["HusbandUnit"].ToString();
                }
                if ((row["HbUnitPhone"] != null) && (row["HbUnitPhone"] != DBNull.Value))
                {
                    gravida_baseinfo.HbUnitPhone = row["HbUnitPhone"].ToString();
                }
                if ((row["HusbandJob"] != null) && (row["HusbandJob"] != DBNull.Value))
                {
                    gravida_baseinfo.HusbandJob = row["HusbandJob"].ToString();
                }
                if ((row["CardNum"] != null) && (row["CardNum"] != DBNull.Value))
                {
                    gravida_baseinfo.CardNum = row["CardNum"].ToString();
                }
                if ((row["CreatePhone"] != null) && (row["CreatePhone"] != DBNull.Value))
                {
                    gravida_baseinfo.CreatePhone = row["CreatePhone"].ToString();
                }
                if (((row["CreateDate"] != null) && (row["CreateDate"] != DBNull.Value)) && (row["CreateDate"].ToString() != ""))
                {
                    gravida_baseinfo.CreateDate = new DateTime?(DateTime.Parse(row["CreateDate"].ToString()));
                }
            }
            return gravida_baseinfo;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from GRAVIDA_BASEINFO ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from GRAVIDA_BASEINFO ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from GRAVIDA_BASEINFO");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,Name,Age,Culture,Job,Address,Nation,Birthday,Living,Phone,HealthResot,TownName,VillageName,PwPhone,HusbandName,HusbandPhone,CurrentUnit,CreateUnit,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,HouseholdTown,HouseholdVillage,AddrTown,AddrVillage,AddrPhone,WorkUnit,UnitPhone,HusbandAge,HusbandCulture,HusbandNation,HusbandUnit,HbUnitPhone,HusbandJob,CardNum,CreatePhone,CreateDate ");
            builder.Append(" FROM GRAVIDA_BASEINFO ");
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
            builder.Append(")AS Row, T.*  from GRAVIDA_BASEINFO T ");
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
            return MySQLHelper.GetMaxID("ID", "GRAVIDA_BASEINFO");
        }

        public WomenGravidaBaseInfoModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,Name,Age,Culture,Job,Address,Nation,Birthday,Living,Phone,HealthResot,TownName,VillageName,PwPhone,HusbandName,HusbandPhone,CurrentUnit,CreateUnit,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,HouseholdTown,HouseholdVillage,AddrTown,AddrVillage,AddrPhone,WorkUnit,UnitPhone,HusbandAge,HusbandCulture,HusbandNation,HusbandUnit,HbUnitPhone,HusbandJob,CardNum,CreatePhone,CreateDate from GRAVIDA_BASEINFO ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new WomenGravidaBaseInfoModel();
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
            builder.Append("select count(1) FROM GRAVIDA_BASEINFO ");
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

        public bool Update(WomenGravidaBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update GRAVIDA_BASEINFO set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Name=@Name,");
            builder.Append("Age=@Age,");
            builder.Append("Culture=@Culture,");
            builder.Append("Job=@Job,");
            builder.Append("Address=@Address,");
            builder.Append("Nation=@Nation,");
            builder.Append("Birthday=@Birthday,");
            builder.Append("Living=@Living,");
            builder.Append("Phone=@Phone,");
            builder.Append("HealthResot=@HealthResot,");
            builder.Append("TownName=@TownName,");
            builder.Append("VillageName=@VillageName,");
            builder.Append("PwPhone=@PwPhone,");
            builder.Append("HusbandName=@HusbandName,");
            builder.Append("HusbandPhone=@HusbandPhone,");
            builder.Append("CurrentUnit=@CurrentUnit,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("HouseholdTown=@HouseholdTown,");
            builder.Append("HouseholdVillage=@HouseholdVillage,");
            builder.Append("AddrTown=@AddrTown,");
            builder.Append("AddrVillage=@AddrVillage,");
            builder.Append("AddrPhone=@AddrPhone,");
            builder.Append("WorkUnit=@WorkUnit,");
            builder.Append("UnitPhone=@UnitPhone,");
            builder.Append("HusbandAge=@HusbandAge,");
            builder.Append("HusbandCulture=@HusbandCulture,");
            builder.Append("HusbandNation=@HusbandNation,");
            builder.Append("HusbandUnit=@HusbandUnit,");
            builder.Append("HbUnitPhone=@HbUnitPhone,");
            builder.Append("HusbandJob=@HusbandJob,");
            builder.Append("CardNum=@CardNum,");
            builder.Append("CreatePhone=@CreatePhone,");
            builder.Append("CreateDate=@CreateDate");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                 new MySqlParameter("@CustomerID", MySqlDbType.String), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String), 
                new MySqlParameter("@Age", MySqlDbType.Decimal), 
                new MySqlParameter("@Culture", MySqlDbType.String, 1), 
                new MySqlParameter("@Job", MySqlDbType.String, 1), 
                new MySqlParameter("@Address", MySqlDbType.String), 
                new MySqlParameter("@Nation", MySqlDbType.String, 1), 
                new MySqlParameter("@Birthday", MySqlDbType.Date), 
                new MySqlParameter("@Living", MySqlDbType.String), 
                new MySqlParameter("@Phone", MySqlDbType.String), 
                new MySqlParameter("@HealthResot", MySqlDbType.String), 
                new MySqlParameter("@TownName", MySqlDbType.String), 
                new MySqlParameter("@VillageName", MySqlDbType.String),
                new MySqlParameter("@PwPhone", MySqlDbType.String), 
                new MySqlParameter("@HusbandName", MySqlDbType.String),
                new MySqlParameter("@HusbandPhone", MySqlDbType.String),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@HouseholdTown", MySqlDbType.String),
                new MySqlParameter("@HouseholdVillage", MySqlDbType.String),
                new MySqlParameter("@AddrTown", MySqlDbType.String), 
                new MySqlParameter( "@AddrVillage",MySqlDbType.String),
                new MySqlParameter("@AddrPhone", MySqlDbType.String),
                new MySqlParameter("@WorkUnit", MySqlDbType.String), 
                new MySqlParameter("@UnitPhone", MySqlDbType.String), 
                new MySqlParameter("@HusbandAge", MySqlDbType.Decimal), 
                new MySqlParameter("@HusbandCulture", MySqlDbType.String),
                new MySqlParameter("@HusbandNation", MySqlDbType.String), 
                new MySqlParameter("@HusbandUnit", MySqlDbType.String), 
                new MySqlParameter("@HbUnitPhone", MySqlDbType.String), 
                new MySqlParameter("@HusbandJob", MySqlDbType.String, 2), 
                new MySqlParameter("@CardNum", MySqlDbType.String), 
                new MySqlParameter("@CreatePhone", MySqlDbType.String), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.Age;
            cmdParms[5].Value = model.Culture;
            cmdParms[6].Value = model.Job;
            cmdParms[7].Value = model.Address;
            cmdParms[8].Value = model.Nation;
            cmdParms[9].Value = model.Birthday;
            cmdParms[10].Value = model.Living;
            cmdParms[11].Value = model.Phone;
            cmdParms[12].Value = model.HealthResot;
            cmdParms[13].Value = model.TownName;
            cmdParms[14].Value = model.VillageName;
            cmdParms[15].Value = model.PwPhone;
            cmdParms[16].Value = model.HusbandName;
            cmdParms[17].Value = model.HusbandPhone;
            cmdParms[18].Value = model.CurrentUnit;
            cmdParms[19].Value = model.CreateUnit;
            cmdParms[20].Value = model.CreatedBy;
            cmdParms[21].Value = model.CreatedDate;
            cmdParms[22].Value = model.LastUpdateBy;
            cmdParms[23].Value = model.LastUpdateDate;
            cmdParms[24].Value = model.IsDel;
            cmdParms[25].Value = model.HouseholdTown;
            cmdParms[26].Value = model.HouseholdVillage;
            cmdParms[27].Value = model.AddrTown;
            cmdParms[28].Value = model.AddrVillage;
            cmdParms[29].Value = model.AddrPhone;
            cmdParms[30].Value = model.WorkUnit;
            cmdParms[31].Value = model.UnitPhone;
            cmdParms[32].Value = model.HusbandAge;
            cmdParms[33].Value = model.HusbandCulture;
            cmdParms[34].Value = model.HusbandNation;
            cmdParms[35].Value = model.HusbandUnit;
            cmdParms[36].Value = model.HbUnitPhone;
            cmdParms[37].Value = model.HusbandJob;
            cmdParms[38].Value = model.CardNum;
            cmdParms[39].Value = model.CreatePhone;
            cmdParms[40].Value = model.CreateDate;
            cmdParms[41].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(WomenGravidaBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update GRAVIDA_BASEINFO set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Name=@Name,");
            builder.Append("Age=@Age,");
            builder.Append("Culture=@Culture,");
            builder.Append("Job=@Job,");
            builder.Append("Address=@Address,");
            builder.Append("Nation=@Nation,");
            builder.Append("Birthday=@Birthday,");
            builder.Append("Living=@Living,");
            builder.Append("Phone=@Phone,");
            builder.Append("HealthResot=@HealthResot,");
            builder.Append("TownName=@TownName,");
            builder.Append("VillageName=@VillageName,");
            builder.Append("PwPhone=@PwPhone,");
            builder.Append("HusbandName=@HusbandName,");
            builder.Append("HusbandPhone=@HusbandPhone,");
            builder.Append("CurrentUnit=@CurrentUnit,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("HouseholdTown=@HouseholdTown,");
            builder.Append("HouseholdVillage=@HouseholdVillage,");
            builder.Append("AddrTown=@AddrTown,");
            builder.Append("AddrVillage=@AddrVillage,");
            builder.Append("AddrPhone=@AddrPhone,");
            builder.Append("WorkUnit=@WorkUnit,");
            builder.Append("UnitPhone=@UnitPhone,");
            builder.Append("HusbandAge=@HusbandAge,");
            builder.Append("HusbandCulture=@HusbandCulture,");
            builder.Append("HusbandNation=@HusbandNation,");
            builder.Append("HusbandUnit=@HusbandUnit,");
            builder.Append("HbUnitPhone=@HbUnitPhone,");
            builder.Append("HusbandJob=@HusbandJob,");
            builder.Append("CardNum=@CardNum,");
            builder.Append("CreatePhone=@CreatePhone,");
            builder.Append("CreateDate=@CreateDate");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                 new MySqlParameter("@CustomerID", MySqlDbType.String), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String), 
                new MySqlParameter("@Age", MySqlDbType.Decimal), 
                new MySqlParameter("@Culture", MySqlDbType.String, 1), 
                new MySqlParameter("@Job", MySqlDbType.String, 1), 
                new MySqlParameter("@Address", MySqlDbType.String), 
                new MySqlParameter("@Nation", MySqlDbType.String, 1), 
                new MySqlParameter("@Birthday", MySqlDbType.Date), 
                new MySqlParameter("@Living", MySqlDbType.String), 
                new MySqlParameter("@Phone", MySqlDbType.String), 
                new MySqlParameter("@HealthResot", MySqlDbType.String), 
                new MySqlParameter("@TownName", MySqlDbType.String), 
                new MySqlParameter("@VillageName", MySqlDbType.String),
                new MySqlParameter("@PwPhone", MySqlDbType.String), 
                new MySqlParameter("@HusbandName", MySqlDbType.String),
                new MySqlParameter("@HusbandPhone", MySqlDbType.String),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@HouseholdTown", MySqlDbType.String),
                new MySqlParameter("@HouseholdVillage", MySqlDbType.String),
                new MySqlParameter("@AddrTown", MySqlDbType.String), 
                new MySqlParameter( "@AddrVillage",MySqlDbType.String),
                new MySqlParameter("@AddrPhone", MySqlDbType.String),
                new MySqlParameter("@WorkUnit", MySqlDbType.String), 
                new MySqlParameter("@UnitPhone", MySqlDbType.String), 
                new MySqlParameter("@HusbandAge", MySqlDbType.Decimal), 
                new MySqlParameter("@HusbandCulture", MySqlDbType.String),
                new MySqlParameter("@HusbandNation", MySqlDbType.String), 
                new MySqlParameter("@HusbandUnit", MySqlDbType.String), 
                new MySqlParameter("@HbUnitPhone", MySqlDbType.String), 
                new MySqlParameter("@HusbandJob", MySqlDbType.String, 2), 
                new MySqlParameter("@CardNum", MySqlDbType.String), 
                new MySqlParameter("@CreatePhone", MySqlDbType.String), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date),
               // new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.Age;
            cmdParms[5].Value = model.Culture;
            cmdParms[6].Value = model.Job;
            cmdParms[7].Value = model.Address;
            cmdParms[8].Value = model.Nation;
            cmdParms[9].Value = model.Birthday;
            cmdParms[10].Value = model.Living;
            cmdParms[11].Value = model.Phone;
            cmdParms[12].Value = model.HealthResot;
            cmdParms[13].Value = model.TownName;
            cmdParms[14].Value = model.VillageName;
            cmdParms[15].Value = model.PwPhone;
            cmdParms[16].Value = model.HusbandName;
            cmdParms[17].Value = model.HusbandPhone;
            cmdParms[18].Value = model.CurrentUnit;
            cmdParms[19].Value = model.CreateUnit;
            cmdParms[20].Value = model.CreatedBy;
            cmdParms[21].Value = model.CreatedDate;
            cmdParms[22].Value = model.LastUpdateBy;
            cmdParms[23].Value = model.LastUpdateDate;
            cmdParms[24].Value = model.IsDel;
            cmdParms[25].Value = model.HouseholdTown;
            cmdParms[26].Value = model.HouseholdVillage;
            cmdParms[27].Value = model.AddrTown;
            cmdParms[28].Value = model.AddrVillage;
            cmdParms[29].Value = model.AddrPhone;
            cmdParms[30].Value = model.WorkUnit;
            cmdParms[31].Value = model.UnitPhone;
            cmdParms[32].Value = model.HusbandAge;
            cmdParms[33].Value = model.HusbandCulture;
            cmdParms[34].Value = model.HusbandNation;
            cmdParms[35].Value = model.HusbandUnit;
            cmdParms[36].Value = model.HbUnitPhone;
            cmdParms[37].Value = model.HusbandJob;
            cmdParms[38].Value = model.CardNum;
            cmdParms[39].Value = model.CreatePhone;
            cmdParms[40].Value = model.CreateDate;
           // cmdParms[41].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

