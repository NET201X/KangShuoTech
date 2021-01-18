namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class VaccinationOtherProgramDAL
    {
        public int Add(VaccinationOtherProgramModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into INOCULATION_OTHERPROGRAM(");
            builder.Append("Name,ProvinceID,CityID,DistrictID,TownID,VillageID,Times)");
            builder.Append(" values (");
            builder.Append("@Name,@ProvinceID,@CityID,@DistrictID,@TownID,@VillageID,@Times)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@Name", MySqlDbType.String, 30), 
                new MySqlParameter("@ProvinceID", MySqlDbType.Decimal), 
                new MySqlParameter("@CityID", MySqlDbType.Decimal), 
                new MySqlParameter("@DistrictID", MySqlDbType.Decimal), 
                new MySqlParameter("@TownID", MySqlDbType.Decimal), 
                new MySqlParameter("@VillageID", MySqlDbType.Decimal), 
                new MySqlParameter("@Times", MySqlDbType.Decimal)
            };
            cmdParms[0].Value = model.Name;
            cmdParms[1].Value = model.ProvinceID;
            cmdParms[2].Value = model.CityID;
            cmdParms[3].Value = model.DistrictID;
            cmdParms[4].Value = model.TownID;
            cmdParms[5].Value = model.VillageID;
            cmdParms[6].Value = model.Times;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public VaccinationOtherProgramModel DataRowToModel(DataRow row)
        {
            VaccinationOtherProgramModel inoculation_otherprogram = new VaccinationOtherProgramModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    inoculation_otherprogram.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["Name"] != null) && (row["Name"] != DBNull.Value))
                {
                    inoculation_otherprogram.Name = row["Name"].ToString();
                }
                if (((row["ProvinceID"] != null) && (row["ProvinceID"] != DBNull.Value)) && (row["ProvinceID"].ToString() != ""))
                {
                    inoculation_otherprogram.ProvinceID = decimal.Parse(row["ProvinceID"].ToString());
                }
                if (((row["CityID"] != null) && (row["CityID"] != DBNull.Value)) && (row["CityID"].ToString() != ""))
                {
                    inoculation_otherprogram.CityID = new decimal?(decimal.Parse(row["CityID"].ToString()));
                }
                if (((row["DistrictID"] != null) && (row["DistrictID"] != DBNull.Value)) && (row["DistrictID"].ToString() != ""))
                {
                    inoculation_otherprogram.DistrictID = new decimal?(decimal.Parse(row["DistrictID"].ToString()));
                }
                if (((row["TownID"] != null) && (row["TownID"] != DBNull.Value)) && (row["TownID"].ToString() != ""))
                {
                    inoculation_otherprogram.TownID = new decimal?(decimal.Parse(row["TownID"].ToString()));
                }
                if (((row["VillageID"] != null) && (row["VillageID"] != DBNull.Value)) && (row["VillageID"].ToString() != ""))
                {
                    inoculation_otherprogram.VillageID = new decimal?(decimal.Parse(row["VillageID"].ToString()));
                }
                if (((row["Times"] != null) && (row["Times"] != DBNull.Value)) && (row["Times"].ToString() != ""))
                {
                    inoculation_otherprogram.Times = new decimal?(decimal.Parse(row["Times"].ToString()));
                }
            }
            return inoculation_otherprogram;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from INOCULATION_OTHERPROGRAM ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from INOCULATION_OTHERPROGRAM ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from INOCULATION_OTHERPROGRAM");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,Name,ProvinceID,CityID,DistrictID,TownID,VillageID,Times ");
            builder.Append(" FROM INOCULATION_OTHERPROGRAM ");
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
            builder.Append(")AS Row, T.*  from INOCULATION_OTHERPROGRAM T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public VaccinationOtherProgramModel GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,Name,ProvinceID,CityID,DistrictID,TownID,VillageID,Times from INOCULATION_OTHERPROGRAM ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            new VaccinationOtherProgramModel();
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
            builder.Append("select count(1) FROM INOCULATION_OTHERPROGRAM ");
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

        public bool Update(VaccinationOtherProgramModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update INOCULATION_OTHERPROGRAM set ");
            builder.Append("Name=@Name,");
            builder.Append("ProvinceID=@ProvinceID,");
            builder.Append("CityID=@CityID,");
            builder.Append("DistrictID=@DistrictID,");
            builder.Append("TownID=@TownID,");
            builder.Append("VillageID=@VillageID,");
            builder.Append("Times=@Times");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@Name", MySqlDbType.String, 30), 
                new MySqlParameter("@ProvinceID", MySqlDbType.Decimal), 
                new MySqlParameter("@CityID", MySqlDbType.Decimal), 
                new MySqlParameter("@DistrictID", MySqlDbType.Decimal), 
                new MySqlParameter("@TownID", MySqlDbType.Decimal),
                new MySqlParameter("@VillageID", MySqlDbType.Decimal), 
                new MySqlParameter("@Times", MySqlDbType.Decimal), 
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.Name;
            cmdParms[1].Value = model.ProvinceID;
            cmdParms[2].Value = model.CityID;
            cmdParms[3].Value = model.DistrictID;
            cmdParms[4].Value = model.TownID;
            cmdParms[5].Value = model.VillageID;
            cmdParms[6].Value = model.Times;
            cmdParms[7].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

