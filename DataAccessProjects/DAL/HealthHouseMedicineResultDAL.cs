using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.Model;
using MySql.Data.MySqlClient;
using KangShuoTech.Utilities.MySQLHelper;
using System.Data;

namespace KangShuoTech.DataAccessProjects.DAL
{
    public class HealthHouseMedicineResultDAL
    {
        public int Add(HealthHouseMedicineResultModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_hhmedicineresult(");
            builder.Append("Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QIconStraint,Characteristic,");
            builder.Append("MildScore,FaintScore,YangsCore,YinScore,PhlegmdampScore,MuggyScore,BloodStasisScore,QiConstraintScore,");
            builder.Append("CharacteristicScore,MildAdvising,FaintAdvising,YangAdvising,YinAdvising,PhlegmdampAdvising,MuggyAdvising,");
            builder.Append("BloodStasisAdvising,QiconstraintAdvising,CharacteristicAdvising,MildAdvisingEx,FaintAdvisingEx,YangadvisingEx,");
            builder.Append("YinAdvisingEx,PhlegmdampAdvisingEx,MuggyAdvisingEx,BloodStasisAdvisingEx,QiconstraintAdvisingEx,");
            builder.Append("CharacteristicAdvisingEx,IDCardNo)");
            builder.Append(" values (");
            builder.Append("@Mild,@Faint,@Yang,@Yin,@PhlegmDamp,@Muggy,@BloodStasis,@QIconStraint,@Characteristic,");
            builder.Append("@MildScore,@FaintScore,@YangsCore,@YinScore,@PhlegmdampScore,@MuggyScore,@BloodStasisScore,@QiConstraintScore,");
            builder.Append("@CharacteristicScore,@MildAdvising,@FaintAdvising,@YangAdvising,@YinAdvising,@PhlegmdampAdvising,@MuggyAdvising,");
            builder.Append("@BloodStasisAdvising,@QiconstraintAdvising,@CharacteristicAdvising,@MildAdvisingEx,@FaintAdvisingEx,@YangadvisingEx,");
            builder.Append("@YinAdvisingEx,@PhlegmdampAdvisingEx,@MuggyAdvisingEx,@BloodStasisAdvisingEx,@QiconstraintAdvisingEx,");
            builder.Append("@CharacteristicAdvisingEx,@IDCardNo)");
            builder.Append(" ;select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@Mild", MySqlDbType.String, 1), 
                new MySqlParameter("@Faint", MySqlDbType.String, 1), 
                new MySqlParameter("@Yang", MySqlDbType.String, 1), 
                new MySqlParameter("@Yin", MySqlDbType.String, 1), 
                new MySqlParameter("@PhlegmDamp", MySqlDbType.String, 1), 
                new MySqlParameter("@Muggy", MySqlDbType.String, 1), 
                new MySqlParameter("@BloodStasis", MySqlDbType.String, 1), 
                new MySqlParameter("@QIconStraint", MySqlDbType.String, 1), 
                new MySqlParameter("@Characteristic", MySqlDbType.String, 1), 
                new MySqlParameter("@MildScore", MySqlDbType.Decimal), 
                new MySqlParameter("@FaintScore", MySqlDbType.Decimal), 
                new MySqlParameter("@YangsCore", MySqlDbType.Decimal),
                new MySqlParameter("@YinScore", MySqlDbType.Decimal),
                new MySqlParameter("@PhlegmdampScore", MySqlDbType.Decimal), 
                new MySqlParameter("@MuggyScore", MySqlDbType.Decimal),
                new MySqlParameter("@BloodStasisScore", MySqlDbType.Decimal),
                new MySqlParameter("@QiConstraintScore", MySqlDbType.Decimal),
                new MySqlParameter("@CharacteristicScore", MySqlDbType.Decimal),
                new MySqlParameter("@MildAdvising", MySqlDbType.String, 18), 
                new MySqlParameter("@FaintAdvising", MySqlDbType.String, 18), 
                new MySqlParameter("@YangAdvising", MySqlDbType.String, 18), 
                new MySqlParameter("@YinAdvising", MySqlDbType.String, 18),
                new MySqlParameter("@PhlegmdampAdvising", MySqlDbType.String, 18),
                new MySqlParameter("@MuggyAdvising", MySqlDbType.String, 18),
                new MySqlParameter("@BloodStasisAdvising", MySqlDbType.String, 18),
                new MySqlParameter("@QiconstraintAdvising", MySqlDbType.String, 18),
                new MySqlParameter("@CharacteristicAdvising", MySqlDbType.String, 18),
                new MySqlParameter("@MildAdvisingEx", MySqlDbType.String, 200), 
                new MySqlParameter("@FaintAdvisingEx", MySqlDbType.String, 200), 
                new MySqlParameter("@YangadvisingEx", MySqlDbType.String, 200), 
                new MySqlParameter("@YinAdvisingEx", MySqlDbType.String, 200),
                new MySqlParameter("@PhlegmdampAdvisingEx", MySqlDbType.String, 200),
                new MySqlParameter("@MuggyAdvisingEx", MySqlDbType.String, 200),
                new MySqlParameter("@BloodStasisAdvisingEx", MySqlDbType.String, 200),
                new MySqlParameter("@QiconstraintAdvisingEx", MySqlDbType.String, 200), 
                new MySqlParameter("@CharacteristicAdvisingEx", MySqlDbType.String, 200),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21)
             };
            cmdParms[0].Value = model.Mild;
            cmdParms[1].Value = model.Faint;
            cmdParms[2].Value = model.Yang;
            cmdParms[3].Value = model.Yin;
            cmdParms[4].Value = model.PhlegmDamp;
            cmdParms[5].Value = model.Muggy;
            cmdParms[6].Value = model.BloodStasis;
            cmdParms[7].Value = model.QiConstraint;
            cmdParms[8].Value = model.Characteristic;
            cmdParms[9].Value = model.MildScore;
            cmdParms[10].Value = model.FaintScore;
            cmdParms[11].Value = model.YangsCore;
            cmdParms[12].Value = model.YinScore;
            cmdParms[13].Value = model.PhlegmdampScore;
            cmdParms[14].Value = model.MuggyScore;
            cmdParms[15].Value = model.BloodStasisScore;
            cmdParms[16].Value = model.QiConstraintScore;
            cmdParms[17].Value = model.CharacteristicScore;
            cmdParms[18].Value = model.MildAdvising;
            cmdParms[19].Value = model.FaintAdvising;
            cmdParms[20].Value = model.YangAdvising;
            cmdParms[21].Value = model.YinAdvising;
            cmdParms[22].Value = model.PhlegmdampAdvising;
            cmdParms[23].Value = model.MuggyAdvising;
            cmdParms[24].Value = model.BloodStasisAdvising;
            cmdParms[25].Value = model.QiconstraintAdvising;
            cmdParms[26].Value = model.CharacteristicAdvising;
            cmdParms[27].Value = model.MildAdvisingEx;
            cmdParms[28].Value = model.FaintAdvisingEx;
            cmdParms[29].Value = model.YangadvisingEx;
            cmdParms[30].Value = model.YinAdvisingEx;
            cmdParms[31].Value = model.PhlegmdampAdvisingEx;
            cmdParms[32].Value = model.MuggyAdvisingEx;
            cmdParms[33].Value = model.BloodStasisAdvisingEx;
            cmdParms[34].Value = model.QiconstraintAdvisingEx;
            cmdParms[35].Value = model.CharacteristicAdvisingEx;
            cmdParms[36].Value = model.IDCardNo;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public HealthHouseMedicineResultModel DataRowToModel(DataRow row)
        {
            HealthHouseMedicineResultModel medicine_result = new HealthHouseMedicineResultModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    medicine_result.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["Mild"] != null) && (row["Mild"] != DBNull.Value))
                {
                    medicine_result.Mild = row["Mild"].ToString();
                }
                if ((row["Faint"] != null) && (row["Faint"] != DBNull.Value))
                {
                    medicine_result.Faint = row["Faint"].ToString();
                }
                if ((row["Yang"] != null) && (row["Yang"] != DBNull.Value))
                {
                    medicine_result.Yang = row["Yang"].ToString();
                }
                if ((row["Yin"] != null) && (row["Yin"] != DBNull.Value))
                {
                    medicine_result.Yin = row["Yin"].ToString();
                }
                if ((row["PhlegmDamp"] != null) && (row["PhlegmDamp"] != DBNull.Value))
                {
                    medicine_result.PhlegmDamp = row["PhlegmDamp"].ToString();
                }
                if ((row["Muggy"] != null) && (row["Muggy"] != DBNull.Value))
                {
                    medicine_result.Muggy = row["Muggy"].ToString();
                }
                if ((row["BloodStasis"] != null) && (row["BloodStasis"] != DBNull.Value))
                {
                    medicine_result.BloodStasis = row["BloodStasis"].ToString();
                }
                if ((row["QIconStraint"] != null) && (row["QIconStraint"] != DBNull.Value))
                {
                    medicine_result.QiConstraint = row["QIconStraint"].ToString();
                }
                if ((row["Characteristic"] != null) && (row["Characteristic"] != DBNull.Value))
                {
                    medicine_result.Characteristic = row["Characteristic"].ToString();
                }
                if (((row["MildScore"] != null) && (row["MildScore"] != DBNull.Value)) && (row["MildScore"].ToString() != ""))
                {
                    medicine_result.MildScore = new decimal?(decimal.Parse(row["MildScore"].ToString()));
                }
                if (((row["FaintScore"] != null) && (row["FaintScore"] != DBNull.Value)) && (row["FaintScore"].ToString() != ""))
                {
                    medicine_result.FaintScore = new decimal?(decimal.Parse(row["FaintScore"].ToString()));
                }
                if (((row["YangsCore"] != null) && (row["YangsCore"] != DBNull.Value)) && (row["YangsCore"].ToString() != ""))
                {
                    medicine_result.YangsCore = new decimal?(decimal.Parse(row["YangsCore"].ToString()));
                }
                if (((row["YinScore"] != null) && (row["YinScore"] != DBNull.Value)) && (row["YinScore"].ToString() != ""))
                {
                    medicine_result.YinScore = new decimal?(decimal.Parse(row["YinScore"].ToString()));
                }
                if (((row["PhlegmdampScore"] != null) && (row["PhlegmdampScore"] != DBNull.Value)) && (row["PhlegmdampScore"].ToString() != ""))
                {
                    medicine_result.PhlegmdampScore = new decimal?(decimal.Parse(row["PhlegmdampScore"].ToString()));
                }
                if (((row["MuggyScore"] != null) && (row["MuggyScore"] != DBNull.Value)) && (row["MuggyScore"].ToString() != ""))
                {
                    medicine_result.MuggyScore = new decimal?(decimal.Parse(row["MuggyScore"].ToString()));
                }
                if (((row["BloodStasisScore"] != null) && (row["BloodStasisScore"] != DBNull.Value)) && (row["BloodStasisScore"].ToString() != ""))
                {
                    medicine_result.BloodStasisScore = new decimal?(decimal.Parse(row["BloodStasisScore"].ToString()));
                }
                if (((row["QiConstraintScore"] != null) && (row["QiConstraintScore"] != DBNull.Value)) && (row["QiConstraintScore"].ToString() != ""))
                {
                    medicine_result.QiConstraintScore = new decimal?(decimal.Parse(row["QiConstraintScore"].ToString()));
                }
                if (((row["CharacteristicScore"] != null) && (row["CharacteristicScore"] != DBNull.Value)) && (row["CharacteristicScore"].ToString() != ""))
                {
                    medicine_result.CharacteristicScore = new decimal?(decimal.Parse(row["CharacteristicScore"].ToString()));
                }
                if ((row["MildAdvising"] != null) && (row["MildAdvising"] != DBNull.Value))
                {
                    medicine_result.MildAdvising = row["MildAdvising"].ToString();
                }
                if ((row["FaintAdvising"] != null) && (row["FaintAdvising"] != DBNull.Value))
                {
                    medicine_result.FaintAdvising = row["FaintAdvising"].ToString();
                }
                if ((row["YangAdvising"] != null) && (row["YangAdvising"] != DBNull.Value))
                {
                    medicine_result.YangAdvising = row["YangAdvising"].ToString();
                }
                if ((row["YinAdvising"] != null) && (row["YinAdvising"] != DBNull.Value))
                {
                    medicine_result.YinAdvising = row["YinAdvising"].ToString();
                }
                if ((row["PhlegmdampAdvising"] != null) && (row["PhlegmdampAdvising"] != DBNull.Value))
                {
                    medicine_result.PhlegmdampAdvising = row["PhlegmdampAdvising"].ToString();
                }
                if ((row["MuggyAdvising"] != null) && (row["MuggyAdvising"] != DBNull.Value))
                {
                    medicine_result.MuggyAdvising = row["MuggyAdvising"].ToString();
                }
                if ((row["BloodStasisAdvising"] != null) && (row["BloodStasisAdvising"] != DBNull.Value))
                {
                    medicine_result.BloodStasisAdvising = row["BloodStasisAdvising"].ToString();
                }
                if ((row["QiconstraintAdvising"] != null) && (row["QiconstraintAdvising"] != DBNull.Value))
                {
                    medicine_result.QiconstraintAdvising = row["QiconstraintAdvising"].ToString();
                }
                if ((row["CharacteristicAdvising"] != null) && (row["CharacteristicAdvising"] != DBNull.Value))
                {
                    medicine_result.CharacteristicAdvising = row["CharacteristicAdvising"].ToString();
                }
                if ((row["MildAdvisingEx"] != null) && (row["MildAdvisingEx"] != DBNull.Value))
                {
                    medicine_result.MildAdvisingEx = row["MildAdvisingEx"].ToString();
                }
                if ((row["FaintAdvisingEx"] != null) && (row["FaintAdvisingEx"] != DBNull.Value))
                {
                    medicine_result.FaintAdvisingEx = row["FaintAdvisingEx"].ToString();
                }
                if ((row["YangadvisingEx"] != null) && (row["YangadvisingEx"] != DBNull.Value))
                {
                    medicine_result.YangadvisingEx = row["YangadvisingEx"].ToString();
                }
                if ((row["YinAdvisingEx"] != null) && (row["YinAdvisingEx"] != DBNull.Value))
                {
                    medicine_result.YinAdvisingEx = row["YinAdvisingEx"].ToString();
                }
                if ((row["PhlegmdampAdvisingEx"] != null) && (row["PhlegmdampAdvisingEx"] != DBNull.Value))
                {
                    medicine_result.PhlegmdampAdvisingEx = row["PhlegmdampAdvisingEx"].ToString();
                }
                if ((row["MuggyAdvisingEx"] != null) && (row["MuggyAdvisingEx"] != DBNull.Value))
                {
                    medicine_result.MuggyAdvisingEx = row["MuggyAdvisingEx"].ToString();
                }
                if ((row["BloodStasisAdvisingEx"] != null) && (row["BloodStasisAdvisingEx"] != DBNull.Value))
                {
                    medicine_result.BloodStasisAdvisingEx = row["BloodStasisAdvisingEx"].ToString();
                }
                if ((row["QiconstraintAdvisingEx"] != null) && (row["QiconstraintAdvisingEx"] != DBNull.Value))
                {
                    medicine_result.QiconstraintAdvisingEx = row["QiconstraintAdvisingEx"].ToString();
                }
                if ((row["CharacteristicAdvisingEx"] != null) && (row["CharacteristicAdvisingEx"] != DBNull.Value))
                {
                    medicine_result.CharacteristicAdvisingEx = row["CharacteristicAdvisingEx"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    medicine_result.IDCardNo = row["IDCardNo"].ToString();
                }
            }
            return medicine_result;
        }
        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_hhmedicineresult ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public HealthHouseMedicineResultModel GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *");
            builder.Append("from tbl_hhmedicineresult ");
            builder.Append(" where ID = @ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@ID", MySqlDbType.String) 
            };
            cmdParms[0].Value = ID;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public bool Update(HealthHouseMedicineResultModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_hhmedicineresult set ");
            builder.Append("Mild=@Mild,");
            builder.Append("Faint=@Faint,");
            builder.Append("Yang=@Yang,");
            builder.Append("Yin=@Yin,");
            builder.Append("PhlegmDamp=@PhlegmDamp,");
            builder.Append("Muggy=@Muggy,");
            builder.Append("BloodStasis=@BloodStasis,");
            builder.Append("QiConstraint=@QiConstraint,");
            builder.Append("Characteristic=@Characteristic,");
            builder.Append("MildScore=@MildScore,");
            builder.Append("FaintScore=@FaintScore,");
            builder.Append("YangsCore=@YangsCore,");
            builder.Append("YinScore=@YinScore,");
            builder.Append("PhlegmdampScore=@PhlegmdampScore,");
            builder.Append("MuggyScore=@MuggyScore,");
            builder.Append("BloodStasisScore=@BloodStasisScore,");
            builder.Append("QiConstraintScore=@QiConstraintScore,");
            builder.Append("CharacteristicScore=@CharacteristicScore,");
            builder.Append("MildAdvising=@MildAdvising,");
            builder.Append("FaintAdvising=@FaintAdvising,");
            builder.Append("YangAdvising=@YangAdvising,");
            builder.Append("YinAdvising=@YinAdvising,");
            builder.Append("PhlegmdampAdvising=@PhlegmdampAdvising,");
            builder.Append("MuggyAdvising=@MuggyAdvising,");
            builder.Append("BloodStasisAdvising=@BloodStasisAdvising,");
            builder.Append("QiconstraintAdvising=@QiconstraintAdvising,");
            builder.Append("CharacteristicAdvising=@CharacteristicAdvising,");
            builder.Append("MildAdvisingEx=@MildAdvisingEx,");
            builder.Append("FaintAdvisingEx=@FaintAdvisingEx,");
            builder.Append("YangadvisingEx=@YangadvisingEx,");
            builder.Append("YinAdvisingEx=@YinAdvisingEx,");
            builder.Append("PhlegmdampAdvisingEx=@PhlegmdampAdvisingEx,");
            builder.Append("MuggyAdvisingEx=@MuggyAdvisingEx,");
            builder.Append("BloodStasisAdvisingEx=@BloodStasisAdvisingEx,");
            builder.Append("QiconstraintAdvisingEx=@QiconstraintAdvisingEx,");
            builder.Append("CharacteristicAdvisingEx=@CharacteristicAdvisingEx,");
            builder.Append("IDCardNo=@IDCardNo ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@Mild", MySqlDbType.String, 1), 
                new MySqlParameter("@Faint", MySqlDbType.String, 1), 
                new MySqlParameter("@Yang", MySqlDbType.String, 1), 
                new MySqlParameter("@Yin", MySqlDbType.String, 1),
                new MySqlParameter("@PhlegmDamp", MySqlDbType.String, 1),
                new MySqlParameter("@Muggy", MySqlDbType.String, 1), 
                new MySqlParameter("@BloodStasis", MySqlDbType.String, 1),
                new MySqlParameter("@QiConstraint", MySqlDbType.String, 1), 
                new MySqlParameter("@Characteristic", MySqlDbType.String, 1), 
                new MySqlParameter("@MildScore", MySqlDbType.Decimal), 
                new MySqlParameter("@FaintScore", MySqlDbType.Decimal),
                new MySqlParameter("@YangsCore", MySqlDbType.Decimal),
                new MySqlParameter("@YinScore", MySqlDbType.Decimal), 
                new MySqlParameter("@PhlegmdampScore", MySqlDbType.Decimal), 
                new MySqlParameter("@MuggyScore", MySqlDbType.Decimal),
                new MySqlParameter("@BloodStasisScore", MySqlDbType.Decimal),
                new MySqlParameter("@QiConstraintScore", MySqlDbType.Decimal),
                new MySqlParameter("@CharacteristicScore", MySqlDbType.Decimal),
                new MySqlParameter("@MildAdvising", MySqlDbType.String, 18),
                new MySqlParameter("@FaintAdvising", MySqlDbType.String, 18),
                new MySqlParameter("@YangAdvising", MySqlDbType.String, 18),
                new MySqlParameter("@YinAdvising", MySqlDbType.String, 18),
                new MySqlParameter("@PhlegmdampAdvising", MySqlDbType.String, 18),
                new MySqlParameter("@MuggyAdvising", MySqlDbType.String, 18),
                new MySqlParameter("@BloodStasisAdvising", MySqlDbType.String, 18),
                new MySqlParameter("@QiconstraintAdvising", MySqlDbType.String, 18),
                new MySqlParameter("@CharacteristicAdvising", MySqlDbType.String, 18), 
                new MySqlParameter("@MildAdvisingEx", MySqlDbType.String, 200), 
                new MySqlParameter("@FaintAdvisingEx", MySqlDbType.String, 200), 
                new MySqlParameter("@YangadvisingEx", MySqlDbType.String, 200), 
                new MySqlParameter("@YinAdvisingEx", MySqlDbType.String, 200), 
                new MySqlParameter("@PhlegmdampAdvisingEx", MySqlDbType.String, 200),
                new MySqlParameter("@MuggyAdvisingEx", MySqlDbType.String, 200),
                new MySqlParameter("@BloodStasisAdvisingEx", MySqlDbType.String, 200), 
                new MySqlParameter("@QiconstraintAdvisingEx", MySqlDbType.String, 200),
                new MySqlParameter("@CharacteristicAdvisingEx", MySqlDbType.String, 200),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.Mild;
            cmdParms[1].Value = model.Faint;
            cmdParms[2].Value = model.Yang;
            cmdParms[3].Value = model.Yin;
            cmdParms[4].Value = model.PhlegmDamp;
            cmdParms[5].Value = model.Muggy;
            cmdParms[6].Value = model.BloodStasis;
            cmdParms[7].Value = model.QiConstraint;
            cmdParms[8].Value = model.Characteristic;
            cmdParms[9].Value = model.MildScore;
            cmdParms[10].Value = model.FaintScore;
            cmdParms[11].Value = model.YangsCore;
            cmdParms[12].Value = model.YinScore;
            cmdParms[13].Value = model.PhlegmdampScore;
            cmdParms[14].Value = model.MuggyScore;
            cmdParms[15].Value = model.BloodStasisScore;
            cmdParms[16].Value = model.QiConstraintScore;
            cmdParms[17].Value = model.CharacteristicScore;
            cmdParms[18].Value = model.MildAdvising;
            cmdParms[19].Value = model.FaintAdvising;
            cmdParms[20].Value = model.YangAdvising;
            cmdParms[21].Value = model.YinAdvising;
            cmdParms[22].Value = model.PhlegmdampAdvising;
            cmdParms[23].Value = model.MuggyAdvising;
            cmdParms[24].Value = model.BloodStasisAdvising;
            cmdParms[25].Value = model.QiconstraintAdvising;
            cmdParms[26].Value = model.CharacteristicAdvising;
            cmdParms[27].Value = model.MildAdvisingEx;
            cmdParms[28].Value = model.FaintAdvisingEx;
            cmdParms[29].Value = model.YangadvisingEx;
            cmdParms[30].Value = model.YinAdvisingEx;
            cmdParms[31].Value = model.PhlegmdampAdvisingEx;
            cmdParms[32].Value = model.MuggyAdvisingEx;
            cmdParms[33].Value = model.BloodStasisAdvisingEx;
            cmdParms[34].Value = model.QiconstraintAdvisingEx;
            cmdParms[35].Value = model.CharacteristicAdvisingEx;
            cmdParms[36].Value = model.IDCardNo;
            cmdParms[37].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
