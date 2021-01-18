namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class SysUserDAL
    {
        public bool Add(SysUserModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into SYS_USER(");
            builder.Append("ID,UserID,UserName,PassWord,Addr,Tel,Status,Remark,ResetPassword,Isuk,Email,Sex,ProvinceID,CityID,DistrictID,TownID,VillageID)");
            builder.Append(" values (");
            builder.Append("@ID,@UserID,@UserName,@PassWord,@Addr,@Tel,@Status,@Remark,@ResetPassword,@Isuk,@Email,@Sex,@ProvinceID,@CityID,@DistrictID,@TownID,@VillageID)");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@ID", MySqlDbType.Int32, 4), 
                new MySqlParameter("@UserID", MySqlDbType.String), 
                new MySqlParameter("@UserName", MySqlDbType.String),
                new MySqlParameter("@PassWord", MySqlDbType.String), 
                new MySqlParameter("@Addr", MySqlDbType.String), 
                new MySqlParameter("@Tel", MySqlDbType.String), 
                new MySqlParameter("@Status", MySqlDbType.String),
                new MySqlParameter("@Remark", MySqlDbType.String),
                new MySqlParameter("@ResetPassword", MySqlDbType.String), 
                new MySqlParameter("@Isuk", MySqlDbType.String), 
                new MySqlParameter("@Email", MySqlDbType.String),
                new MySqlParameter("@Sex", MySqlDbType.String), 
                new MySqlParameter("@ProvinceID", MySqlDbType.String), 
                new MySqlParameter("@CityID", MySqlDbType.String), 
                new MySqlParameter("@DistrictID", MySqlDbType.String), 
                new MySqlParameter("@TownID", MySqlDbType.String), 
                new MySqlParameter("@VillageID", MySqlDbType.String)
             };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.UserID;
            cmdParms[2].Value = model.UserName;
            cmdParms[3].Value = model.PassWord;
            cmdParms[4].Value = model.Addr;
            cmdParms[5].Value = model.Tel;
            cmdParms[6].Value = model.Status;
            cmdParms[7].Value = model.Remark;
            cmdParms[8].Value = model.ResetPassword;
            cmdParms[9].Value = model.Isuk;
            cmdParms[10].Value = model.Email;
            cmdParms[11].Value = model.Sex;
            cmdParms[12].Value = model.ProvinceID;
            cmdParms[13].Value = model.CityID;
            cmdParms[14].Value = model.DistrictID;
            cmdParms[15].Value = model.TownID;
            cmdParms[16].Value = model.VillageID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public SysUserModel DataRowToModel(DataRow row)
        {
            SysUserModel sysUserModel = new SysUserModel();
            if (row != null)
            {
                sysUserModel.ID = row["ID"].ToString();
                if ((row["UserID"] != null) && (row["UserID"] != DBNull.Value))
                {
                    sysUserModel.UserID = row["UserID"].ToString();
                }
                if ((row["UserName"] != null) && (row["UserName"] != DBNull.Value))
                {
                    sysUserModel.UserName = row["UserName"].ToString();
                }
                if ((row["PassWord"] != null) && (row["PassWord"] != DBNull.Value))
                {
                    sysUserModel.PassWord = row["PassWord"].ToString();
                }
                if ((row["Addr"] != null) && (row["Addr"] != DBNull.Value))
                {
                    sysUserModel.Addr = row["Addr"].ToString();
                }
                if ((row["Tel"] != null) && (row["Tel"] != DBNull.Value))
                {
                    sysUserModel.Tel = row["Tel"].ToString();
                }
                if ((row["Status"] != null) && (row["Status"] != DBNull.Value))
                {
                    sysUserModel.Status = row["Status"].ToString();
                }
                if ((row["Remark"] != null) && (row["Remark"] != DBNull.Value))
                {
                    sysUserModel.Remark = row["Remark"].ToString();
                }
                if ((row["ResetPassword"] != null) && (row["ResetPassword"] != DBNull.Value))
                {
                    sysUserModel.ResetPassword = row["ResetPassword"].ToString();
                }
                if ((row["Isuk"] != null) && (row["Isuk"] != DBNull.Value))
                {
                    sysUserModel.Isuk = row["Isuk"].ToString();
                }
                if ((row["Email"] != null) && (row["Email"] != DBNull.Value))
                {
                    sysUserModel.Email = row["Email"].ToString();
                }
                if ((row["Sex"] != null) && (row["Sex"] != DBNull.Value))
                {
                    sysUserModel.Sex = row["Sex"].ToString();
                }
                sysUserModel.ProvinceID = row["ProvinceID"].ToString();
                sysUserModel.CityID = row["CityID"].ToString();
                sysUserModel.DistrictID = row["DistrictID"].ToString();
                sysUserModel.TownID = row["TownID"].ToString();
                sysUserModel.VillageID = row["VillageID"].ToString();
            }
            return sysUserModel;
        }

        public bool Delete()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from SYS_USER ");
            builder.Append(" where ");
            MySqlParameter[] cmdParms = new MySqlParameter[0];
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,UserID,UserName,PassWord,Addr,Tel,Status,Remark,ResetPassword,Isuk,Email,Sex,\n(case ProvinceID when '' then null else ProvinceID end)ProvinceID,\n(case CityID when '' then null when 'null' then NULL ELSE CityID end)CityID,DistrictID,(case TownID when 'null' then NULL else TownID end)TownID,\n(case VillageID when 'null' then NULL else VillageID end)VillageID ");
            builder.Append(" FROM SYS_USER ");
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
                builder.Append("order by T." + orderby);
            }
            else
            {
                builder.Append("order by T. desc");
            }
            builder.Append(")AS Row, T.*  from SYS_USER T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public SysUserModel GetModel(string id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,UserID,UserName,PassWord,Addr,Tel,Status,Remark,ResetPassword,Isuk,Email,Sex,\n(case ProvinceID when '' then null else ProvinceID end)ProvinceID,CityID,DistrictID,(case TownID when '' then null else TownID end)TownID,\n(case VillageID when '' then null else VillageID end)VillageID from SYS_USER ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.String) };
            cmdParms[0].Value = id;
            new SysUserModel();
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
            builder.Append("select count(1) FROM SYS_USER ");
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

        public bool Update(SysUserModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update SYS_USER set ");
            builder.Append("UserID=@UserID,");
            builder.Append("UserName=@UserName,");
            builder.Append("PassWord=@PassWord,");
            builder.Append("Addr=@Addr,");
            builder.Append("Tel=@Tel,");
            builder.Append("Status=@Status,");
            builder.Append("Remark=@Remark,");
            builder.Append("ResetPassword=@ResetPassword,");
            builder.Append("Isuk=@Isuk,");
            builder.Append("Email=@Email,");
            builder.Append("Sex=@Sex,");
            builder.Append("ProvinceID=@ProvinceID,");
            builder.Append("CityID=@CityID,");
            builder.Append("DistrictID=@DistrictID,");
            builder.Append("TownID=@TownID,");
            builder.Append("VillageID=@VillageID");
            builder.Append(" where ID=@ID ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@UserID", MySqlDbType.String), 
                new MySqlParameter("@UserName", MySqlDbType.String),
                new MySqlParameter("@PassWord", MySqlDbType.String), 
                new MySqlParameter("@Addr", MySqlDbType.String), 
                new MySqlParameter("@Tel", MySqlDbType.String), 
                new MySqlParameter("@Status", MySqlDbType.String),
                new MySqlParameter("@Remark", MySqlDbType.String),
                new MySqlParameter("@ResetPassword", MySqlDbType.String), 
                new MySqlParameter("@Isuk", MySqlDbType.String), 
                new MySqlParameter("@Email", MySqlDbType.String),
                new MySqlParameter("@Sex", MySqlDbType.String), 
                new MySqlParameter("@ProvinceID", MySqlDbType.String), 
                new MySqlParameter("@CityID", MySqlDbType.String), 
                new MySqlParameter("@DistrictID", MySqlDbType.String), 
                new MySqlParameter("@TownID", MySqlDbType.String), 
                new MySqlParameter("@VillageID", MySqlDbType.String), 
                 new MySqlParameter("@ID", MySqlDbType.String), 
             };
            cmdParms[0].Value = model.UserID;        
            cmdParms[1].Value = model.UserName;      
            cmdParms[2].Value = model.PassWord;      
            cmdParms[3].Value = model.Addr;          
            cmdParms[4].Value = model.Tel;           
            cmdParms[5].Value = model.Status;        
            cmdParms[6].Value = model.Remark;        
            cmdParms[7].Value = model.ResetPassword; 
            cmdParms[8].Value = model.Isuk;          
            cmdParms[9].Value =  model.Email;        
            cmdParms[10].Value = model.Sex;          
            cmdParms[11].Value = model.ProvinceID;   
            cmdParms[12].Value = model.CityID;       
            cmdParms[13].Value = model.DistrictID;   
            cmdParms[14].Value = model.TownID;       
            cmdParms[15].Value = model.VillageID;
            cmdParms[16].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        /// <summary>
        /// 获取医生信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDoctorList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" Select  UserID,UserName FROM SYS_USER ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" Where " + strWhere);
            }

            return MySQLHelper.Query(builder.ToString());
        }
    }
}

