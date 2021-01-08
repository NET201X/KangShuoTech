using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommonUtilities.SQL;
using System;
using System.Text;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsMedicationDAL
    {
        public bool DeleteByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("DELETE FROM tbl_recordsmedication ");
            builder.Append(" WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4)
            };
            cmdParms[0].Value = OutKey;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Add(RecordsMedicationModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("INSERT INTO tbl_RecordsMedication(");
            strSql.Append("PhysicalID,IDCardNo,UseAge,UseNum,StartTime,EndTime,PillDependence,MedicinalName,drugtype,factory,");
            strSql.Append("OutKey,Num,Frequency,UseNumUnit,UseYear,UseYearUnit,OtherExplain,NumUnit,Remark,DrugYear,DrugMonth,");
            strSql.Append("DrugDay,FreUseNum,FreUseDay,UseDay,Effect,EffectDes,EachNum)");
            strSql.Append(" VALUES (");
            strSql.Append("@PhysicalID,@IDCardNo,@UseAge,@UseNum,@StartTime,@EndTime,@PillDependence,@MedicinalName,");
            strSql.Append("@drugtype,@factory,@OutKey,@Num,@Frequency,@UseNumUnit,@UseYear,@UseYearUnit,@OtherExplain,");
            strSql.Append("@NumUnit,@Remark,@DrugYear,@DrugMonth,@DrugDay,@FreUseNum,@FreUseDay,@UseDay,@Effect,@EffectDes,@EachNum)");

            MySqlParameter[] parameters = {
                new MySqlParameter("@PhysicalID", MySqlDbType.VarChar,100),
                new MySqlParameter("@IDCardNo", MySqlDbType.VarChar,21),
                new MySqlParameter("@UseAge", MySqlDbType.VarChar,100),
                new MySqlParameter("@UseNum", MySqlDbType.VarChar,100),
                new MySqlParameter("@StartTime", MySqlDbType.VarChar,100),
                new MySqlParameter("@EndTime", MySqlDbType.VarChar,100),
                new MySqlParameter("@PillDependence", MySqlDbType.VarChar,100),
                new MySqlParameter("@MedicinalName", MySqlDbType.VarChar,100),
                new MySqlParameter("@drugtype", MySqlDbType.VarChar,100),
                new MySqlParameter("@factory", MySqlDbType.VarChar,100),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,11),
                new MySqlParameter("@Num", MySqlDbType.VarChar,100),
                new MySqlParameter("@Frequency", MySqlDbType.VarChar,100),
                new MySqlParameter("@UseNumUnit", MySqlDbType.VarChar,100),
                new MySqlParameter("@UseYear", MySqlDbType.VarChar,100),
                new MySqlParameter("@UseYearUnit", MySqlDbType.VarChar,100),
                new MySqlParameter("@OtherExplain", MySqlDbType.VarChar,100),
                new MySqlParameter("@NumUnit", MySqlDbType.VarChar,10),
                new MySqlParameter("@Remark", MySqlDbType.VarChar,100),
                new MySqlParameter("@DrugYear", MySqlDbType.VarChar,10),
                new MySqlParameter("@DrugMonth", MySqlDbType.VarChar,10),
                new MySqlParameter("@DrugDay", MySqlDbType.VarChar,10),
                new MySqlParameter("@FreUseNum", MySqlDbType.VarChar,10),
                new MySqlParameter("@FreUseDay", MySqlDbType.VarChar,10),
                new MySqlParameter("@UseDay", MySqlDbType.VarChar,50),
                new MySqlParameter("@Effect", MySqlDbType.VarChar,1),
                new MySqlParameter("@EffectDes", MySqlDbType.VarChar,100),
                new MySqlParameter("@EachNum", MySqlDbType.VarChar,10)
            };

            parameters[0].Value = model.PhysicalID;
            parameters[1].Value = model.IDCardNo;
            parameters[2].Value = model.UseAge;
            parameters[3].Value = model.UseNum;
            parameters[4].Value = model.StartTime;
            parameters[5].Value = model.EndTime;
            parameters[6].Value = model.PillDependence;
            parameters[7].Value = model.MedicinalName;
            parameters[8].Value = model.DrugType;
            parameters[9].Value = model.Factory;
            parameters[10].Value = model.OutKey;
            parameters[11].Value = model.Num;
            parameters[12].Value = model.Frequency;
            parameters[13].Value = model.UseNumUnit;
            parameters[14].Value = model.UseYear;
            parameters[15].Value = model.UseYearUnit;
            parameters[16].Value = model.OtherExplain;
            parameters[17].Value = model.NumUnit;
            parameters[18].Value = model.Remark;
            parameters[19].Value = model.DrugYear;
            parameters[20].Value = model.DrugMonth;
            parameters[21].Value = model.DrugDay;
            parameters[22].Value = model.FreUseNum;
            parameters[23].Value = model.FreUseDay;
            parameters[24].Value = model.UseDay;
            parameters[25].Value = model.Effect;
            parameters[26].Value = model.EffectDes;
            parameters[27].Value = model.EachNum;

            int rows = MySQLHelper.ExecuteSql(strSql.ToString(), parameters);

            if (rows > 0) return true;
            else return false;
        }

		public DataSet GetList(string strWhere)
		{
			StringBuilder builder = new StringBuilder();

			builder.Append("SELECT * FROM tbl_RecordsMedication ");

			if (strWhere.Trim() != "")
			{
				builder.Append(" WHERE " + strWhere + " ORDER BY id LIMIT 6");
			}

			return MySQLHelper.Query(builder.ToString());
		}
    }
}