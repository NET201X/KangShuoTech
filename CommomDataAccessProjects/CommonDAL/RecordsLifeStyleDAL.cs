namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
	using MySql.Data.MySqlClient;
	using KangShuoTech.CommomDataAccessProjects.CommonModel;
	using CommonUtilities.SQL;
	using System;
	using System.Data;
	using System.Text;

    public class RecordsLifeStyleDAL
    {
        public int Add(RecordsLifeStyleModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO ARCHIVE_LIFESTYLE(");
            builder.Append("PhysicalID,IDCardNo,SmokeDayNum,SmokeAgeStart,SmokeAgeForbiddon,ExerciseRate,ExerciseTimes,DietaryHabit,ExerciseExistense,ExcisepersistTime,SmokeCondition,DrinkRate,DayDrinkVolume,IsDrinkForbiddon,ForbiddonAge,DrinkStartAge,DrinkThisYear,DrinkType,CareerHarmFactorHistory,Dust,DustProtect,Radiogen,RadiogenProtect,Physical,PhysicalProtect,Chem,ChemProtect,Other,OtherProtect,WorkType,WorkTime,DustProtectEx,RadiogenProtectEx,PhysicalProtectEx,ChemProtectEx,OtherProtectEx,DrinkTypeOther,OutKey,ExerciseExistenseOther)");
            builder.Append(" VALUES (");
            builder.Append("@PhysicalID,@IDCardNo,@SmokeDayNum,@SmokeAgeStart,@SmokeAgeForbiddon,@ExerciseRate,@ExerciseTimes,@DietaryHabit,@ExerciseExistense,@ExcisepersistTime,@SmokeCondition,@DrinkRate,@DayDrinkVolume,@IsDrinkForbiddon,@ForbiddonAge,@DrinkStartAge,@DrinkThisYear,@DrinkType,@CareerHarmFactorHistory,@Dust,@DustProtect,@Radiogen,@RadiogenProtect,@Physical,@PhysicalProtect,@Chem,@ChemProtect,@Other,@OtherProtect,@WorkType,@WorkTime,@DustProtectEx,@RadiogenProtectEx,@PhysicalProtectEx,@ChemProtectEx,@OtherProtectEx,@DrinkTypeOther,@OutKey,@ExerciseExistenseOther)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 100), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@SmokeDayNum", MySqlDbType.Decimal), 
                new MySqlParameter("@SmokeAgeStart", MySqlDbType.Decimal),
                new MySqlParameter("@SmokeAgeForbiddon", MySqlDbType.Decimal),
                new MySqlParameter("@ExerciseRate", MySqlDbType.String, 1), 
                new MySqlParameter("@ExerciseTimes", MySqlDbType.Decimal),
                new MySqlParameter("@DietaryHabit", MySqlDbType.String, 100),
                new MySqlParameter("@ExerciseExistense", MySqlDbType.String, 100),
                new MySqlParameter("@ExcisepersistTime", MySqlDbType.Decimal),
                new MySqlParameter("@SmokeCondition", MySqlDbType.String, 1),
                new MySqlParameter("@DrinkRate", MySqlDbType.String, 1),
                new MySqlParameter("@DayDrinkVolume", MySqlDbType.Decimal),
                new MySqlParameter("@IsDrinkForbiddon", MySqlDbType.String, 1), 
                new MySqlParameter("@ForbiddonAge", MySqlDbType.Decimal),
                new MySqlParameter("@DrinkStartAge", MySqlDbType.Decimal), 
                new MySqlParameter("@DrinkThisYear", MySqlDbType.String, 1), 
                new MySqlParameter("@DrinkType", MySqlDbType.String, 100), 
                new MySqlParameter("@CareerHarmFactorHistory", MySqlDbType.String, 1), 
                new MySqlParameter("@Dust", MySqlDbType.String, 100), 
                new MySqlParameter("@DustProtect", MySqlDbType.String, 1),
                new MySqlParameter("@Radiogen", MySqlDbType.String, 100), 
                new MySqlParameter("@RadiogenProtect", MySqlDbType.String, 1), 
                new MySqlParameter("@Physical", MySqlDbType.String, 100), 
                new MySqlParameter("@PhysicalProtect", MySqlDbType.String, 1),
                new MySqlParameter("@Chem", MySqlDbType.String, 100), 
                new MySqlParameter("@ChemProtect", MySqlDbType.String, 1), 
                new MySqlParameter("@Other", MySqlDbType.String, 100), 
                new MySqlParameter("@OtherProtect", MySqlDbType.String, 1), 
                new MySqlParameter("@WorkType", MySqlDbType.String, 100), 
                new MySqlParameter("@WorkTime", MySqlDbType.Decimal),
                new MySqlParameter("@DustProtectEx", MySqlDbType.String, 100), 
                new MySqlParameter("@RadiogenProtectEx", MySqlDbType.String, 100),
                new MySqlParameter("@PhysicalProtectEx", MySqlDbType.String, 100),
                new MySqlParameter("@ChemProtectEx", MySqlDbType.String, 100), 
                new MySqlParameter("@OtherProtectEx", MySqlDbType.String, 100),
                new MySqlParameter("@DrinkTypeOther", MySqlDbType.String, 100),
                new MySqlParameter("@OutKey",MySqlDbType.Int32,11),
                new MySqlParameter("@ExerciseExistenseOther",MySqlDbType.Int32,100)
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

        public DataSet GetModelByOutKey(int outKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_LIFESTYLE ");
            builder.Append(" WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32,4) };
            cmdParms[0].Value = outKey;

            DataSet SET = MySQLHelper.Query(builder.ToString(), cmdParms);

            return SET;
        }
    }
}

