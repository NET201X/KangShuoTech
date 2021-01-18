namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsLifeStyleDAL
    {
        public int Add(RecordsLifeStyleModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_LIFESTYLE(");
            builder.Append("PhysicalID,IDCardNo,SmokeDayNum,SmokeAgeStart,SmokeAgeForbiddon,ExerciseRate,ExerciseTimes,DietaryHabit,ExerciseExistense,ExcisepersistTime,SmokeCondition,DrinkRate,DayDrinkVolume,IsDrinkForbiddon,ForbiddonAge,DrinkStartAge,DrinkThisYear,DrinkType,CareerHarmFactorHistory,Dust,DustProtect,Radiogen,RadiogenProtect,Physical,PhysicalProtect,Chem,ChemProtect,Other,OtherProtect,WorkType,WorkTime,DustProtectEx,RadiogenProtectEx,PhysicalProtectEx,ChemProtectEx,OtherProtectEx,DrinkTypeOther,OutKey,ExerciseExistenseOther)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@SmokeDayNum,@SmokeAgeStart,@SmokeAgeForbiddon,@ExerciseRate,@ExerciseTimes,@DietaryHabit,@ExerciseExistense,@ExcisepersistTime,@SmokeCondition,@DrinkRate,@DayDrinkVolume,@IsDrinkForbiddon,@ForbiddonAge,@DrinkStartAge,@DrinkThisYear,@DrinkType,@CareerHarmFactorHistory,@Dust,@DustProtect,@Radiogen,@RadiogenProtect,@Physical,@PhysicalProtect,@Chem,@ChemProtect,@Other,@OtherProtect,@WorkType,@WorkTime,@DustProtectEx,@RadiogenProtectEx,@PhysicalProtectEx,@ChemProtectEx,@OtherProtectEx,@DrinkTypeOther,@OutKey,@ExerciseExistenseOther)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@SmokeDayNum", MySqlDbType.Decimal), 
                new MySqlParameter("@SmokeAgeStart", MySqlDbType.Decimal),
                new MySqlParameter("@SmokeAgeForbiddon", MySqlDbType.Decimal),
                new MySqlParameter("@ExerciseRate", MySqlDbType.String, 1), 
                new MySqlParameter("@ExerciseTimes", MySqlDbType.Decimal),
                new MySqlParameter("@DietaryHabit", MySqlDbType.String, 30),
                new MySqlParameter("@ExerciseExistense", MySqlDbType.String, 50),
                new MySqlParameter("@ExcisepersistTime", MySqlDbType.Decimal),
                new MySqlParameter("@SmokeCondition", MySqlDbType.String, 1),
                new MySqlParameter("@DrinkRate", MySqlDbType.String, 1),
                new MySqlParameter("@DayDrinkVolume", MySqlDbType.Decimal),
                new MySqlParameter("@IsDrinkForbiddon", MySqlDbType.String, 1), 
                new MySqlParameter("@ForbiddonAge", MySqlDbType.Decimal),
                new MySqlParameter("@DrinkStartAge", MySqlDbType.Decimal), 
                new MySqlParameter("@DrinkThisYear", MySqlDbType.String, 1), 
                new MySqlParameter("@DrinkType", MySqlDbType.String, 13), 
                new MySqlParameter("@CareerHarmFactorHistory", MySqlDbType.String, 1), 
                new MySqlParameter("@Dust", MySqlDbType.String, 30), 
                new MySqlParameter("@DustProtect", MySqlDbType.String, 1),
                new MySqlParameter("@Radiogen", MySqlDbType.String, 50), 
                new MySqlParameter("@RadiogenProtect", MySqlDbType.String, 1), 
                new MySqlParameter("@Physical", MySqlDbType.String, 50), 
                new MySqlParameter("@PhysicalProtect", MySqlDbType.String, 1),
                new MySqlParameter("@Chem", MySqlDbType.String, 50), 
                new MySqlParameter("@ChemProtect", MySqlDbType.String, 1), 
                new MySqlParameter("@Other", MySqlDbType.String, 200), 
                new MySqlParameter("@OtherProtect", MySqlDbType.String, 1), 
                new MySqlParameter("@WorkType", MySqlDbType.String, 30), 
                new MySqlParameter("@WorkTime", MySqlDbType.Decimal),
                new MySqlParameter("@DustProtectEx", MySqlDbType.String, 500), 
                new MySqlParameter("@RadiogenProtectEx", MySqlDbType.String, 500),
                new MySqlParameter("@PhysicalProtectEx", MySqlDbType.String, 500),
                new MySqlParameter("@ChemProtectEx", MySqlDbType.String, 500), 
                new MySqlParameter("@OtherProtectEx", MySqlDbType.String, 500),
                new MySqlParameter("@DrinkTypeOther", MySqlDbType.String, 20),
                new MySqlParameter("@OutKey",MySqlDbType.Int32,4), 
                new MySqlParameter("@ExerciseExistenseOther", MySqlDbType.String, 500)
             };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.SmokeDayNum;
            cmdParms[3].Value = model.SmokeAgeStart;
            cmdParms[4].Value = model.SmokeAgeForbiddon;
            cmdParms[5].Value = model.ExerciseRate;
            cmdParms[6].Value = model.ExerciseTimes;
            cmdParms[7].Value = model.DietaryHabit;
            cmdParms[8].Value = model.ExerciseExistense;
            cmdParms[9].Value = model.ExcisepersistTime;
            cmdParms[10].Value = model.SmokeCondition;
            cmdParms[11].Value = model.DrinkRate;
            cmdParms[12].Value = model.DayDrinkVolume;
            cmdParms[13].Value = model.IsDrinkForbiddon;
            cmdParms[14].Value = model.ForbiddonAge;
            cmdParms[15].Value = model.DrinkStartAge;
            cmdParms[16].Value = model.DrinkThisYear;
            cmdParms[17].Value = model.DrinkType;
            cmdParms[18].Value = model.CareerHarmFactorHistory;
            cmdParms[19].Value = model.Dust;
            cmdParms[20].Value = model.DustProtect;
            cmdParms[21].Value = model.Radiogen;
            cmdParms[22].Value = model.RadiogenProtect;
            cmdParms[23].Value = model.Physical;
            cmdParms[24].Value = model.PhysicalProtect;
            cmdParms[25].Value = model.Chem;
            cmdParms[26].Value = model.ChemProtect;
            cmdParms[27].Value = model.Other;
            cmdParms[28].Value = model.OtherProtect;
            cmdParms[29].Value = model.WorkType;
            cmdParms[30].Value = model.WorkTime;
            cmdParms[31].Value = model.DustProtectEx;
            cmdParms[32].Value = model.RadiogenProtectEx;
            cmdParms[33].Value = model.PhysicalProtectEx;
            cmdParms[34].Value = model.ChemProtectEx;
            cmdParms[35].Value = model.OtherProtectEx;
            cmdParms[36].Value = model.DrinkTypeOther;
            cmdParms[37].Value = model.OutKey;
            cmdParms[38].Value = model.ExerciseExistenseOther;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(RecordsLifeStyleModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_LIFESTYLE(");
            builder.Append("PhysicalID,IDCardNo,SmokeDayNum,SmokeAgeStart,SmokeAgeForbiddon,ExerciseRate,ExerciseTimes,DietaryHabit,ExerciseExistense,ExcisepersistTime,SmokeCondition,DrinkRate,DayDrinkVolume,IsDrinkForbiddon,ForbiddonAge,DrinkStartAge,DrinkThisYear,DrinkType,CareerHarmFactorHistory,Dust,DustProtect,Radiogen,RadiogenProtect,Physical,PhysicalProtect,Chem,ChemProtect,Other,OtherProtect,WorkType,WorkTime,DustProtectEx,RadiogenProtectEx,PhysicalProtectEx,ChemProtectEx,OtherProtectEx,DrinkTypeOther,OutKey,ExerciseExistenseOther)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@SmokeDayNum,@SmokeAgeStart,@SmokeAgeForbiddon,@ExerciseRate,@ExerciseTimes,@DietaryHabit,@ExerciseExistense,@ExcisepersistTime,@SmokeCondition,@DrinkRate,@DayDrinkVolume,@IsDrinkForbiddon,@ForbiddonAge,@DrinkStartAge,@DrinkThisYear,@DrinkType,@CareerHarmFactorHistory,@Dust,@DustProtect,@Radiogen,@RadiogenProtect,@Physical,@PhysicalProtect,@Chem,@ChemProtect,@Other,@OtherProtect,@WorkType,@WorkTime,@DustProtectEx,@RadiogenProtectEx,@PhysicalProtectEx,@ChemProtectEx,@OtherProtectEx,@DrinkTypeOther,@OutKey,@ExerciseExistenseOther)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@SmokeDayNum", MySqlDbType.Decimal), 
                new MySqlParameter("@SmokeAgeStart", MySqlDbType.Decimal),
                new MySqlParameter("@SmokeAgeForbiddon", MySqlDbType.Decimal),
                new MySqlParameter("@ExerciseRate", MySqlDbType.String, 1), 
                new MySqlParameter("@ExerciseTimes", MySqlDbType.Decimal),
                new MySqlParameter("@DietaryHabit", MySqlDbType.String, 30),
                new MySqlParameter("@ExerciseExistense", MySqlDbType.String, 50),
                new MySqlParameter("@ExcisepersistTime", MySqlDbType.Decimal),
                new MySqlParameter("@SmokeCondition", MySqlDbType.String, 1),
                new MySqlParameter("@DrinkRate", MySqlDbType.String, 1),
                new MySqlParameter("@DayDrinkVolume", MySqlDbType.Decimal),
                new MySqlParameter("@IsDrinkForbiddon", MySqlDbType.String, 1), 
                new MySqlParameter("@ForbiddonAge", MySqlDbType.Decimal),
                new MySqlParameter("@DrinkStartAge", MySqlDbType.Decimal), 
                new MySqlParameter("@DrinkThisYear", MySqlDbType.String, 1), 
                new MySqlParameter("@DrinkType", MySqlDbType.String, 13), 
                new MySqlParameter("@CareerHarmFactorHistory", MySqlDbType.String, 1), 
                new MySqlParameter("@Dust", MySqlDbType.String, 30), 
                new MySqlParameter("@DustProtect", MySqlDbType.String, 1),
                new MySqlParameter("@Radiogen", MySqlDbType.String, 50), 
                new MySqlParameter("@RadiogenProtect", MySqlDbType.String, 1), 
                new MySqlParameter("@Physical", MySqlDbType.String, 50), 
                new MySqlParameter("@PhysicalProtect", MySqlDbType.String, 1),
                new MySqlParameter("@Chem", MySqlDbType.String, 50), 
                new MySqlParameter("@ChemProtect", MySqlDbType.String, 1), 
                new MySqlParameter("@Other", MySqlDbType.String, 200), 
                new MySqlParameter("@OtherProtect", MySqlDbType.String, 1), 
                new MySqlParameter("@WorkType", MySqlDbType.String, 30), 
                new MySqlParameter("@WorkTime", MySqlDbType.Decimal),
                new MySqlParameter("@DustProtectEx", MySqlDbType.String, 500), 
                new MySqlParameter("@RadiogenProtectEx", MySqlDbType.String, 500),
                new MySqlParameter("@PhysicalProtectEx", MySqlDbType.String, 500),
                new MySqlParameter("@ChemProtectEx", MySqlDbType.String, 500), 
                new MySqlParameter("@OtherProtectEx", MySqlDbType.String, 500),
                new MySqlParameter("@DrinkTypeOther", MySqlDbType.String, 20),
                new MySqlParameter("@OutKey",MySqlDbType.Int32,4), 
                new MySqlParameter("@ExerciseExistenseOther", MySqlDbType.String, 500)
             };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.SmokeDayNum;
            cmdParms[3].Value = model.SmokeAgeStart;
            cmdParms[4].Value = model.SmokeAgeForbiddon;
            cmdParms[5].Value = model.ExerciseRate;
            cmdParms[6].Value = model.ExerciseTimes;
            cmdParms[7].Value = model.DietaryHabit;
            cmdParms[8].Value = model.ExerciseExistense;
            cmdParms[9].Value = model.ExcisepersistTime;
            cmdParms[10].Value = model.SmokeCondition;
            cmdParms[11].Value = model.DrinkRate;
            cmdParms[12].Value = model.DayDrinkVolume;
            cmdParms[13].Value = model.IsDrinkForbiddon;
            cmdParms[14].Value = model.ForbiddonAge;
            cmdParms[15].Value = model.DrinkStartAge;
            cmdParms[16].Value = model.DrinkThisYear;
            cmdParms[17].Value = model.DrinkType;
            cmdParms[18].Value = model.CareerHarmFactorHistory;
            cmdParms[19].Value = model.Dust;
            cmdParms[20].Value = model.DustProtect;
            cmdParms[21].Value = model.Radiogen;
            cmdParms[22].Value = model.RadiogenProtect;
            cmdParms[23].Value = model.Physical;
            cmdParms[24].Value = model.PhysicalProtect;
            cmdParms[25].Value = model.Chem;
            cmdParms[26].Value = model.ChemProtect;
            cmdParms[27].Value = model.Other;
            cmdParms[28].Value = model.OtherProtect;
            cmdParms[29].Value = model.WorkType;
            cmdParms[30].Value = model.WorkTime;
            cmdParms[31].Value = model.DustProtectEx;
            cmdParms[32].Value = model.RadiogenProtectEx;
            cmdParms[33].Value = model.PhysicalProtectEx;
            cmdParms[34].Value = model.ChemProtectEx;
            cmdParms[35].Value = model.OtherProtectEx;
            cmdParms[36].Value = model.DrinkTypeOther;
            cmdParms[37].Value = model.OutKey;
            cmdParms[38].Value = model.ExerciseExistenseOther;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsLifeStyleModel DataRowToModel(DataRow row)
        {
            RecordsLifeStyleModel recordsLifeStyleModel = new RecordsLifeStyleModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsLifeStyleModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["PhysicalID"] != null) && (row["PhysicalID"] != DBNull.Value))
                {
                    recordsLifeStyleModel.PhysicalID = row["PhysicalID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsLifeStyleModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["SmokeDayNum"] != null) && (row["SmokeDayNum"] != DBNull.Value)) && (row["SmokeDayNum"].ToString() != ""))
                {
                    recordsLifeStyleModel.SmokeDayNum = new decimal?(decimal.Parse(row["SmokeDayNum"].ToString()));
                }
                if (((row["SmokeAgeStart"] != null) && (row["SmokeAgeStart"] != DBNull.Value)) && (row["SmokeAgeStart"].ToString() != ""))
                {
                    recordsLifeStyleModel.SmokeAgeStart = new decimal?(decimal.Parse(row["SmokeAgeStart"].ToString()));
                }
                if (((row["SmokeAgeForbiddon"] != null) && (row["SmokeAgeForbiddon"] != DBNull.Value)) && (row["SmokeAgeForbiddon"].ToString() != ""))
                {
                    recordsLifeStyleModel.SmokeAgeForbiddon = new decimal?(decimal.Parse(row["SmokeAgeForbiddon"].ToString()));
                }
                if ((row["ExerciseRate"] != null) && (row["ExerciseRate"] != DBNull.Value))
                {
                    recordsLifeStyleModel.ExerciseRate = row["ExerciseRate"].ToString();
                }
                if (((row["ExerciseTimes"] != null) && (row["ExerciseTimes"] != DBNull.Value)) && (row["ExerciseTimes"].ToString() != ""))
                {
                    recordsLifeStyleModel.ExerciseTimes = new decimal?(decimal.Parse(row["ExerciseTimes"].ToString()));
                }
                if ((row["DietaryHabit"] != null) && (row["DietaryHabit"] != DBNull.Value))
                {
                    recordsLifeStyleModel.DietaryHabit = row["DietaryHabit"].ToString();
                }
                if ((row["ExerciseExistense"] != null) && (row["ExerciseExistense"] != DBNull.Value))
                {
                    recordsLifeStyleModel.ExerciseExistense = row["ExerciseExistense"].ToString();
                }
                if (((row["ExcisepersistTime"] != null) && (row["ExcisepersistTime"] != DBNull.Value)) && (row["ExcisepersistTime"].ToString() != ""))
                {
                    recordsLifeStyleModel.ExcisepersistTime = new decimal?(decimal.Parse(row["ExcisepersistTime"].ToString()));
                }
                if ((row["SmokeCondition"] != null) && (row["SmokeCondition"] != DBNull.Value))
                {
                    recordsLifeStyleModel.SmokeCondition = row["SmokeCondition"].ToString();
                }
                if ((row["DrinkRate"] != null) && (row["DrinkRate"] != DBNull.Value))
                {
                    recordsLifeStyleModel.DrinkRate = row["DrinkRate"].ToString();
                }
                if (((row["DayDrinkVolume"] != null) && (row["DayDrinkVolume"] != DBNull.Value)) && (row["DayDrinkVolume"].ToString() != ""))
                {
                    recordsLifeStyleModel.DayDrinkVolume = new decimal?(decimal.Parse(row["DayDrinkVolume"].ToString()));
                }
                if ((row["IsDrinkForbiddon"] != null) && (row["IsDrinkForbiddon"] != DBNull.Value))
                {
                    recordsLifeStyleModel.IsDrinkForbiddon = row["IsDrinkForbiddon"].ToString();
                }
                if (((row["ForbiddonAge"] != null) && (row["ForbiddonAge"] != DBNull.Value)) && (row["ForbiddonAge"].ToString() != ""))
                {
                    recordsLifeStyleModel.ForbiddonAge = new decimal?(decimal.Parse(row["ForbiddonAge"].ToString()));
                }
                if (((row["DrinkStartAge"] != null) && (row["DrinkStartAge"] != DBNull.Value)) && (row["DrinkStartAge"].ToString() != ""))
                {
                    recordsLifeStyleModel.DrinkStartAge = new decimal?(decimal.Parse(row["DrinkStartAge"].ToString()));
                }
                if ((row["DrinkThisYear"] != null) && (row["DrinkThisYear"] != DBNull.Value))
                {
                    recordsLifeStyleModel.DrinkThisYear = row["DrinkThisYear"].ToString();
                }
                if ((row["DrinkType"] != null) && (row["DrinkType"] != DBNull.Value))
                {
                    recordsLifeStyleModel.DrinkType = row["DrinkType"].ToString();
                }
                if ((row["CareerHarmFactorHistory"] != null) && (row["CareerHarmFactorHistory"] != DBNull.Value))
                {
                    recordsLifeStyleModel.CareerHarmFactorHistory = row["CareerHarmFactorHistory"].ToString();
                }
                if ((row["Dust"] != null) && (row["Dust"] != DBNull.Value))
                {
                    recordsLifeStyleModel.Dust = row["Dust"].ToString();
                }
                if ((row["DustProtect"] != null) && (row["DustProtect"] != DBNull.Value))
                {
                    recordsLifeStyleModel.DustProtect = row["DustProtect"].ToString();
                }
                if ((row["Radiogen"] != null) && (row["Radiogen"] != DBNull.Value))
                {
                    recordsLifeStyleModel.Radiogen = row["Radiogen"].ToString();
                }
                if ((row["RadiogenProtect"] != null) && (row["RadiogenProtect"] != DBNull.Value))
                {
                    recordsLifeStyleModel.RadiogenProtect = row["RadiogenProtect"].ToString();
                }
                if ((row["Physical"] != null) && (row["Physical"] != DBNull.Value))
                {
                    recordsLifeStyleModel.Physical = row["Physical"].ToString();
                }
                if ((row["PhysicalProtect"] != null) && (row["PhysicalProtect"] != DBNull.Value))
                {
                    recordsLifeStyleModel.PhysicalProtect = row["PhysicalProtect"].ToString();
                }
                if ((row["Chem"] != null) && (row["Chem"] != DBNull.Value))
                {
                    recordsLifeStyleModel.Chem = row["Chem"].ToString();
                }
                if ((row["ChemProtect"] != null) && (row["ChemProtect"] != DBNull.Value))
                {
                    recordsLifeStyleModel.ChemProtect = row["ChemProtect"].ToString();
                }
                if ((row["Other"] != null) && (row["Other"] != DBNull.Value))
                {
                    recordsLifeStyleModel.Other = row["Other"].ToString();
                }
                if ((row["OtherProtect"] != null) && (row["OtherProtect"] != DBNull.Value))
                {
                    recordsLifeStyleModel.OtherProtect = row["OtherProtect"].ToString();
                }
                if ((row["WorkType"] != null) && (row["WorkType"] != DBNull.Value))
                {
                    recordsLifeStyleModel.WorkType = row["WorkType"].ToString();
                }
                if (((row["WorkTime"] != null) && (row["WorkTime"] != DBNull.Value)) && (row["WorkTime"].ToString() != ""))
                {
                    recordsLifeStyleModel.WorkTime = new decimal?(decimal.Parse(row["WorkTime"].ToString()));
                }
                if ((row["DustProtectEx"] != null) && (row["DustProtectEx"] != DBNull.Value))
                {
                    recordsLifeStyleModel.DustProtectEx = row["DustProtectEx"].ToString();
                }
                if ((row["RadiogenProtectEx"] != null) && (row["RadiogenProtectEx"] != DBNull.Value))
                {
                    recordsLifeStyleModel.RadiogenProtectEx = row["RadiogenProtectEx"].ToString();
                }
                if ((row["PhysicalProtectEx"] != null) && (row["PhysicalProtectEx"] != DBNull.Value))
                {
                    recordsLifeStyleModel.PhysicalProtectEx = row["PhysicalProtectEx"].ToString();
                }
                if ((row["ChemProtectEx"] != null) && (row["ChemProtectEx"] != DBNull.Value))
                {
                    recordsLifeStyleModel.ChemProtectEx = row["ChemProtectEx"].ToString();
                }
                if ((row["OtherProtectEx"] != null) && (row["OtherProtectEx"] != DBNull.Value))
                {
                    recordsLifeStyleModel.OtherProtectEx = row["OtherProtectEx"].ToString();
                }
                if ((row["DrinkTypeOther"] != null) && (row["DrinkTypeOther"] != DBNull.Value)) 
                {
                    recordsLifeStyleModel.DrinkTypeOther = row["DrinkTypeOther"].ToString();
                }
                if ((row["ExerciseExistenseOther"] != null) && (row["ExerciseExistenseOther"] != DBNull.Value)) //ExerciseExistenseOther
                {
                    recordsLifeStyleModel.ExerciseExistenseOther = row["ExerciseExistenseOther"].ToString();
                }
            }
            return recordsLifeStyleModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_LIFESTYLE ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_LIFESTYLE ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_LIFESTYLE");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,SmokeDayNum,SmokeAgeStart,SmokeAgeForbiddon,ExerciseRate,ExerciseTimes,DietaryHabit,ExerciseExistense,ExcisepersistTime,SmokeCondition,DrinkRate,DayDrinkVolume,IsDrinkForbiddon,ForbiddonAge,DrinkStartAge,DrinkThisYear,DrinkType,CareerHarmFactorHistory,Dust,DustProtect,Radiogen,RadiogenProtect,Physical,PhysicalProtect,Chem,ChemProtect,Other,OtherProtect,WorkType,WorkTime,DustProtectEx,RadiogenProtectEx,PhysicalProtectEx,ChemProtectEx,OtherProtectEx,DrinkTypeOther,ExerciseExistenseOther ");
            builder.Append(" FROM ARCHIVE_LIFESTYLE ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }
        public DataSet GetRecordslifestyledt(string IDCardNo ,int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,SmokeDayNum,SmokeAgeStart,SmokeAgeForbiddon,ExerciseRate,ExerciseTimes,DietaryHabit,");
            builder.Append("ExerciseExistense,ExcisepersistTime,SmokeCondition,DrinkRate,DayDrinkVolume,IsDrinkForbiddon,ForbiddonAge,");
            builder.Append("DrinkStartAge,DrinkThisYear,DrinkType,CareerHarmFactorHistory,Dust,DustProtect,Radiogen,RadiogenProtect,Physical,");
            builder.Append("PhysicalProtect,Chem,ChemProtect,Other,OtherProtect,WorkType,WorkTime,DustProtectEx,RadiogenProtectEx,");
            builder.Append("PhysicalProtectEx,ChemProtectEx,OtherProtectEx,DrinkTypeOther,ExerciseExistenseOther  ");
            builder.Append("from ARCHIVE_LIFESTYLE where IDCardNo= '" + IDCardNo + "' and OutKey = '"+OutKey+"'");
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
            builder.Append(")AS Row, T.*  from ARCHIVE_LIFESTYLE T ");
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
            return MySQLHelper.GetMaxID("ID", "ARCHIVE_LIFESTYLE");
        }

        public RecordsLifeStyleModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,SmokeDayNum,SmokeAgeStart,SmokeAgeForbiddon,ExerciseRate,ExerciseTimes,DietaryHabit,ExerciseExistense,ExcisepersistTime,SmokeCondition,DrinkRate,DayDrinkVolume,IsDrinkForbiddon,ForbiddonAge,DrinkStartAge,DrinkThisYear,DrinkType,CareerHarmFactorHistory,Dust,DustProtect,Radiogen,RadiogenProtect,Physical,PhysicalProtect,Chem,ChemProtect,Other,OtherProtect,WorkType,WorkTime,DustProtectEx,RadiogenProtectEx,PhysicalProtectEx,ChemProtectEx,OtherProtectEx,DrinkTypeOther,ExerciseExistenseOther from ARCHIVE_LIFESTYLE ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsLifeStyleModel();
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
            builder.Append("select count(1) FROM ARCHIVE_LIFESTYLE ");
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

        public bool Update(RecordsLifeStyleModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_LIFESTYLE set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("SmokeDayNum=@SmokeDayNum,");
            builder.Append("SmokeAgeStart=@SmokeAgeStart,");
            builder.Append("SmokeAgeForbiddon=@SmokeAgeForbiddon,");
            builder.Append("ExerciseRate=@ExerciseRate,");
            builder.Append("ExerciseTimes=@ExerciseTimes,");
            builder.Append("DietaryHabit=@DietaryHabit,");
            builder.Append("ExerciseExistense=@ExerciseExistense,");
            builder.Append("ExcisepersistTime=@ExcisepersistTime,");
            builder.Append("SmokeCondition=@SmokeCondition,");
            builder.Append("DrinkRate=@DrinkRate,");
            builder.Append("DayDrinkVolume=@DayDrinkVolume,");
            builder.Append("IsDrinkForbiddon=@IsDrinkForbiddon,");
            builder.Append("ForbiddonAge=@ForbiddonAge,");
            builder.Append("DrinkStartAge=@DrinkStartAge,");
            builder.Append("DrinkThisYear=@DrinkThisYear,");
            builder.Append("DrinkType=@DrinkType,");
            builder.Append("CareerHarmFactorHistory=@CareerHarmFactorHistory,");
            builder.Append("Dust=@Dust,");
            builder.Append("DustProtect=@DustProtect,");
            builder.Append("Radiogen=@Radiogen,");
            builder.Append("RadiogenProtect=@RadiogenProtect,");
            builder.Append("Physical=@Physical,");
            builder.Append("PhysicalProtect=@PhysicalProtect,");
            builder.Append("Chem=@Chem,");
            builder.Append("ChemProtect=@ChemProtect,");
            builder.Append("Other=@Other,");
            builder.Append("OtherProtect=@OtherProtect,");
            builder.Append("WorkType=@WorkType,");
            builder.Append("WorkTime=@WorkTime,");
            builder.Append("DustProtectEx=@DustProtectEx,");
            builder.Append("RadiogenProtectEx=@RadiogenProtectEx,");
            builder.Append("PhysicalProtectEx=@PhysicalProtectEx,");
            builder.Append("ChemProtectEx=@ChemProtectEx,");
            builder.Append("OtherProtectEx=@OtherProtectEx,");
            builder.Append("DrinkTypeOther=@DrinkTypeOther, "); //ExerciseExistenseOther
            builder.Append("ExerciseExistenseOther=@ExerciseExistenseOther");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@SmokeDayNum", MySqlDbType.Decimal), 
                new MySqlParameter("@SmokeAgeStart", MySqlDbType.Decimal), 
                new MySqlParameter("@SmokeAgeForbiddon", MySqlDbType.Decimal),
                new MySqlParameter("@ExerciseRate", MySqlDbType.String, 1),
                new MySqlParameter("@ExerciseTimes", MySqlDbType.Decimal),
                new MySqlParameter("@DietaryHabit", MySqlDbType.String, 30),
                new MySqlParameter("@ExerciseExistense", MySqlDbType.String, 50), 
                new MySqlParameter("@ExcisepersistTime", MySqlDbType.Decimal), 
                new MySqlParameter("@SmokeCondition", MySqlDbType.String, 1), 
                new MySqlParameter("@DrinkRate", MySqlDbType.String, 1),
                new MySqlParameter("@DayDrinkVolume", MySqlDbType.Decimal),
                new MySqlParameter("@IsDrinkForbiddon", MySqlDbType.String, 1), 
                new MySqlParameter("@ForbiddonAge", MySqlDbType.Decimal), 
                new MySqlParameter("@DrinkStartAge", MySqlDbType.Decimal), 
                new MySqlParameter("@DrinkThisYear", MySqlDbType.String, 1),
                new MySqlParameter("@DrinkType", MySqlDbType.String, 13), 
                new MySqlParameter("@CareerHarmFactorHistory", MySqlDbType.String, 1), 
                new MySqlParameter("@Dust", MySqlDbType.String, 30), 
                new MySqlParameter("@DustProtect", MySqlDbType.String, 1),
                new MySqlParameter("@Radiogen", MySqlDbType.String, 50),
                new MySqlParameter("@RadiogenProtect", MySqlDbType.String, 1), 
                new MySqlParameter("@Physical", MySqlDbType.String, 50),
                new MySqlParameter("@PhysicalProtect", MySqlDbType.String, 1),
                new MySqlParameter("@Chem", MySqlDbType.String, 50), 
                new MySqlParameter("@ChemProtect", MySqlDbType.String, 1), 
                new MySqlParameter("@Other", MySqlDbType.String, 200),
                new MySqlParameter("@OtherProtect", MySqlDbType.String, 1),
                new MySqlParameter("@WorkType", MySqlDbType.String, 30), 
                new MySqlParameter("@WorkTime", MySqlDbType.Decimal),
                new MySqlParameter("@DustProtectEx", MySqlDbType.String, 500), 
                new MySqlParameter("@RadiogenProtectEx", MySqlDbType.String, 500),
                new MySqlParameter("@PhysicalProtectEx", MySqlDbType.String, 500),
                new MySqlParameter("@ChemProtectEx", MySqlDbType.String, 500), 
                new MySqlParameter("@OtherProtectEx", MySqlDbType.String, 500), 
                new MySqlParameter("@DrinkTypeOther", MySqlDbType.String, 20),
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 8),
                new MySqlParameter("@ExerciseExistenseOther", MySqlDbType.String, 500)
             };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.SmokeDayNum;
            cmdParms[3].Value = model.SmokeAgeStart;
            cmdParms[4].Value = model.SmokeAgeForbiddon;
            cmdParms[5].Value = model.ExerciseRate;
            cmdParms[6].Value = model.ExerciseTimes;
            cmdParms[7].Value = model.DietaryHabit;
            cmdParms[8].Value = model.ExerciseExistense;
            cmdParms[9].Value = model.ExcisepersistTime;
            cmdParms[10].Value = model.SmokeCondition;
            cmdParms[11].Value = model.DrinkRate;
            cmdParms[12].Value = model.DayDrinkVolume;
            cmdParms[13].Value = model.IsDrinkForbiddon;
            cmdParms[14].Value = model.ForbiddonAge;
            cmdParms[15].Value = model.DrinkStartAge;
            cmdParms[16].Value = model.DrinkThisYear;
            cmdParms[17].Value = model.DrinkType;
            cmdParms[18].Value = model.CareerHarmFactorHistory;
            cmdParms[19].Value = model.Dust;
            cmdParms[20].Value = model.DustProtect;
            cmdParms[21].Value = model.Radiogen;
            cmdParms[22].Value = model.RadiogenProtect;
            cmdParms[23].Value = model.Physical;
            cmdParms[24].Value = model.PhysicalProtect;
            cmdParms[25].Value = model.Chem;
            cmdParms[26].Value = model.ChemProtect;
            cmdParms[27].Value = model.Other;
            cmdParms[28].Value = model.OtherProtect;
            cmdParms[29].Value = model.WorkType;
            cmdParms[30].Value = model.WorkTime;
            cmdParms[31].Value = model.DustProtectEx;
            cmdParms[32].Value = model.RadiogenProtectEx;
            cmdParms[33].Value = model.PhysicalProtectEx;
            cmdParms[34].Value = model.ChemProtectEx;
            cmdParms[35].Value = model.OtherProtectEx;
            cmdParms[36].Value = model.DrinkTypeOther;
            cmdParms[37].Value = model.OutKey;
            cmdParms[38].Value = model.ExerciseExistenseOther;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(RecordsLifeStyleModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_LIFESTYLE set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("SmokeDayNum=@SmokeDayNum,");
            builder.Append("SmokeAgeStart=@SmokeAgeStart,");
            builder.Append("SmokeAgeForbiddon=@SmokeAgeForbiddon,");
            builder.Append("ExerciseRate=@ExerciseRate,");
            builder.Append("ExerciseTimes=@ExerciseTimes,");
            builder.Append("DietaryHabit=@DietaryHabit,");
            builder.Append("ExerciseExistense=@ExerciseExistense,");
            builder.Append("ExcisepersistTime=@ExcisepersistTime,");
            builder.Append("SmokeCondition=@SmokeCondition,");
            builder.Append("DrinkRate=@DrinkRate,");
            builder.Append("DayDrinkVolume=@DayDrinkVolume,");
            builder.Append("IsDrinkForbiddon=@IsDrinkForbiddon,");
            builder.Append("ForbiddonAge=@ForbiddonAge,");
            builder.Append("DrinkStartAge=@DrinkStartAge,");
            builder.Append("DrinkThisYear=@DrinkThisYear,");
            builder.Append("DrinkType=@DrinkType,");
            builder.Append("CareerHarmFactorHistory=@CareerHarmFactorHistory,");
            builder.Append("Dust=@Dust,");
            builder.Append("DustProtect=@DustProtect,");
            builder.Append("Radiogen=@Radiogen,");
            builder.Append("RadiogenProtect=@RadiogenProtect,");
            builder.Append("Physical=@Physical,");
            builder.Append("PhysicalProtect=@PhysicalProtect,");
            builder.Append("Chem=@Chem,");
            builder.Append("ChemProtect=@ChemProtect,");
            builder.Append("Other=@Other,");
            builder.Append("OtherProtect=@OtherProtect,");
            builder.Append("WorkType=@WorkType,");
            builder.Append("WorkTime=@WorkTime,");
            builder.Append("DustProtectEx=@DustProtectEx,");
            builder.Append("RadiogenProtectEx=@RadiogenProtectEx,");
            builder.Append("PhysicalProtectEx=@PhysicalProtectEx,");
            builder.Append("ChemProtectEx=@ChemProtectEx,");
            builder.Append("OtherProtectEx=@OtherProtectEx,");
            builder.Append("DrinkTypeOther=@DrinkTypeOther,"); 
            builder.Append("ExerciseExistenseOther=@ExerciseExistenseOther ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@SmokeDayNum", MySqlDbType.Decimal), 
                new MySqlParameter("@SmokeAgeStart", MySqlDbType.Decimal), 
                new MySqlParameter("@SmokeAgeForbiddon", MySqlDbType.Decimal),
                new MySqlParameter("@ExerciseRate", MySqlDbType.String, 1),
                new MySqlParameter("@ExerciseTimes", MySqlDbType.Decimal),
                new MySqlParameter("@DietaryHabit", MySqlDbType.String, 30),
                new MySqlParameter("@ExerciseExistense", MySqlDbType.String, 50), 
                new MySqlParameter("@ExcisepersistTime", MySqlDbType.Decimal), 
                new MySqlParameter("@SmokeCondition", MySqlDbType.String, 1), 
                new MySqlParameter("@DrinkRate", MySqlDbType.String, 1),
                new MySqlParameter("@DayDrinkVolume", MySqlDbType.Decimal),
                new MySqlParameter("@IsDrinkForbiddon", MySqlDbType.String, 1), 
                new MySqlParameter("@ForbiddonAge", MySqlDbType.Decimal), 
                new MySqlParameter("@DrinkStartAge", MySqlDbType.Decimal), 
                new MySqlParameter("@DrinkThisYear", MySqlDbType.String, 1),
                new MySqlParameter("@DrinkType", MySqlDbType.String, 13), 
                new MySqlParameter("@CareerHarmFactorHistory", MySqlDbType.String, 1), 
                new MySqlParameter("@Dust", MySqlDbType.String, 30), 
                new MySqlParameter("@DustProtect", MySqlDbType.String, 1),
                new MySqlParameter("@Radiogen", MySqlDbType.String, 50),
                new MySqlParameter("@RadiogenProtect", MySqlDbType.String, 1), 
                new MySqlParameter("@Physical", MySqlDbType.String, 50),
                new MySqlParameter("@PhysicalProtect", MySqlDbType.String, 1),
                new MySqlParameter("@Chem", MySqlDbType.String, 50), 
                new MySqlParameter("@ChemProtect", MySqlDbType.String, 1), 
                new MySqlParameter("@Other", MySqlDbType.String, 200),
                new MySqlParameter("@OtherProtect", MySqlDbType.String, 1),
                new MySqlParameter("@WorkType", MySqlDbType.String, 30), 
                new MySqlParameter("@WorkTime", MySqlDbType.Decimal),
                new MySqlParameter("@DustProtectEx", MySqlDbType.String, 500), 
                new MySqlParameter("@RadiogenProtectEx", MySqlDbType.String, 500),
                new MySqlParameter("@PhysicalProtectEx", MySqlDbType.String, 500),
                new MySqlParameter("@ChemProtectEx", MySqlDbType.String, 500), 
                new MySqlParameter("@OtherProtectEx", MySqlDbType.String, 500), 
                new MySqlParameter("@DrinkTypeOther", MySqlDbType.String, 20),
                new MySqlParameter("@ExerciseExistenseOther", MySqlDbType.String, 500)
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.SmokeDayNum;
            cmdParms[3].Value = model.SmokeAgeStart;
            cmdParms[4].Value = model.SmokeAgeForbiddon;
            cmdParms[5].Value = model.ExerciseRate;
            cmdParms[6].Value = model.ExerciseTimes;
            cmdParms[7].Value = model.DietaryHabit;
            cmdParms[8].Value = model.ExerciseExistense;
            cmdParms[9].Value = model.ExcisepersistTime;
            cmdParms[10].Value = model.SmokeCondition;
            cmdParms[11].Value = model.DrinkRate;
            cmdParms[12].Value = model.DayDrinkVolume;
            cmdParms[13].Value = model.IsDrinkForbiddon;
            cmdParms[14].Value = model.ForbiddonAge;
            cmdParms[15].Value = model.DrinkStartAge;
            cmdParms[16].Value = model.DrinkThisYear;
            cmdParms[17].Value = model.DrinkType;
            cmdParms[18].Value = model.CareerHarmFactorHistory;
            cmdParms[19].Value = model.Dust;
            cmdParms[20].Value = model.DustProtect;
            cmdParms[21].Value = model.Radiogen;
            cmdParms[22].Value = model.RadiogenProtect;
            cmdParms[23].Value = model.Physical;
            cmdParms[24].Value = model.PhysicalProtect;
            cmdParms[25].Value = model.Chem;
            cmdParms[26].Value = model.ChemProtect;
            cmdParms[27].Value = model.Other;
            cmdParms[28].Value = model.OtherProtect;
            cmdParms[29].Value = model.WorkType;
            cmdParms[30].Value = model.WorkTime;
            cmdParms[31].Value = model.DustProtectEx;
            cmdParms[32].Value = model.RadiogenProtectEx;
            cmdParms[33].Value = model.PhysicalProtectEx;
            cmdParms[34].Value = model.ChemProtectEx;
            cmdParms[35].Value = model.OtherProtectEx;
            cmdParms[36].Value = model.DrinkTypeOther;
            cmdParms[37].Value = model.ExerciseExistenseOther;
            //cmdParms[37].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
        public RecordsLifeStyleModel GetModelByOutKey(int outKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,SmokeDayNum,SmokeAgeStart,SmokeAgeForbiddon,ExerciseRate,ExerciseTimes,DietaryHabit,ExerciseExistense,ExcisepersistTime,SmokeCondition,DrinkRate,DayDrinkVolume,IsDrinkForbiddon,ForbiddonAge,DrinkStartAge,DrinkThisYear,DrinkType,CareerHarmFactorHistory,Dust,DustProtect,Radiogen,RadiogenProtect,Physical,PhysicalProtect,Chem,ChemProtect,Other,OtherProtect,WorkType,WorkTime,DustProtectEx,RadiogenProtectEx,PhysicalProtectEx,ChemProtectEx,OtherProtectEx,DrinkTypeOther,ExerciseExistenseOther from ARCHIVE_LIFESTYLE ");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32,4) };
            cmdParms[0].Value = outKey;
            new RecordsLifeStyleModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public bool ExistsOutKey(string IDCardNo,int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_LIFESTYLE");
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
        public bool UpdateByTJMiniPad(RecordsLifeStyleModel model, string checkDate) //体检问询同步
        {
            StringBuilder builder = new StringBuilder();
          
            builder.Append(@"UPDATE 
                                    ARCHIVE_LIFESTYLE  D
                             SET 
                                     ExerciseRate=@ExerciseRate,ExerciseTimes=@ExerciseTimes,ExcisepersistTime=@ExcisepersistTime,
                                     ExerciseExistense=@ExerciseExistense,DietaryHabit=@DietaryHabit,SmokeCondition=@SmokeCondition,SmokeDayNum=@SmokeDayNum,
                                     SmokeAgeStart=@SmokeAgeStart,SmokeAgeForbiddon=@SmokeAgeForbiddon,DrinkRate=@DrinkRate,
                                     DayDrinkVolume=@DayDrinkVolume,IsDrinkForbiddon=@IsDrinkForbiddon,DrinkStartAge=@DrinkStartAge,
                                     DrinkThisYear=@DrinkThisYear,DrinkType=@DrinkType,ExerciseExistenseOther=@ExerciseExistenseOther,
                                     DrinkTypeOther=@DrinkTypeOther,ForbiddonAge=@ForbiddonAge  
                             WHERE
                                    EXISTS
                                    (
                                        SELECT 
                                            ID 
                                        FROM
                                        ARCHIVE_CUSTOMERBASEINFO M
                                        WHERE M.ID = D.OutKey
                                        AND M.IDCardNo = @IDCardNo
                                        AND M.CheckDate = @CheckDate
                                    )
                            ");

                MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@CheckDate",checkDate),
                new MySqlParameter("@ExerciseRate", model.ExerciseRate),
                new MySqlParameter("@ExerciseTimes", model.ExerciseTimes),
                new MySqlParameter("@ExcisepersistTime", model.ExcisepersistTime),
                new MySqlParameter("@ExerciseExistense", model.ExerciseExistense),
                new MySqlParameter("@DietaryHabit", model.DietaryHabit),
                new MySqlParameter("@SmokeCondition", model.SmokeCondition),
                new MySqlParameter("@SmokeDayNum", model.SmokeDayNum),
                new MySqlParameter("@SmokeAgeStart", model.SmokeAgeStart),
                new MySqlParameter("@SmokeAgeForbiddon", model.SmokeAgeForbiddon),
                new MySqlParameter("@DrinkRate", model.DrinkRate),
                new MySqlParameter("@DayDrinkVolume", model.DayDrinkVolume),
                new MySqlParameter("@IsDrinkForbiddon", model.IsDrinkForbiddon),
                new MySqlParameter("@DrinkStartAge", model.DrinkStartAge),
                new MySqlParameter("@DrinkThisYear", model.DrinkThisYear),
                new MySqlParameter("@DrinkType", model.DrinkType),
                new MySqlParameter("@ExerciseExistenseOther",model.ExerciseExistenseOther),
                new MySqlParameter("@DrinkTypeOther",model.DrinkTypeOther),
                new MySqlParameter("@ForbiddonAge",model.ForbiddonAge)

             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

