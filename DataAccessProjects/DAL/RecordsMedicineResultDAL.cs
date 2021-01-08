using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using KangShuoTech.Utilities.MySQLHelper;
using System.Data;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.DAL
{
    public class RecordsMedicineResultDAL
    {
        public int Add(RecordsMedicineResultModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordsmedicineresult(");
            builder.Append("PhysicalID,MedicineID,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QIconStraint,Characteristic,");
            builder.Append("MildScore,FaintScore,YangsCore,YinScore,PhlegmdampScore,MuggyScore,BloodStasisScore,QiConstraintScore,");
            builder.Append("CharacteristicScore,MildAdvising,FaintAdvising,YangAdvising,YinAdvising,PhlegmdampAdvising,MuggyAdvising,");
            builder.Append("BloodStasisAdvising,QiconstraintAdvising,CharacteristicAdvising,MildAdvisingEx,FaintAdvisingEx,YangadvisingEx,");
            builder.Append("YinAdvisingEx,PhlegmdampAdvisingEx,MuggyAdvisingEx,BloodStasisAdvisingEx,QiconstraintAdvisingEx,");
            builder.Append("CharacteristicAdvisingEx,IsDel,IDCardNo,EffectAssess,Satisfy)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@MedicineID,@Mild,@Faint,@Yang,@Yin,@PhlegmDamp,@Muggy,@BloodStasis,@QIconStraint,@Characteristic,");
            builder.Append("@MildScore,@FaintScore,@YangsCore,@YinScore,@PhlegmdampScore,@MuggyScore,@BloodStasisScore,@QiConstraintScore,");
            builder.Append("@CharacteristicScore,@MildAdvising,@FaintAdvising,@YangAdvising,@YinAdvising,@PhlegmdampAdvising,@MuggyAdvising,");
            builder.Append("@BloodStasisAdvising,@QiconstraintAdvising,@CharacteristicAdvising,@MildAdvisingEx,@FaintAdvisingEx,@YangadvisingEx,");
            builder.Append("@YinAdvisingEx,@PhlegmdampAdvisingEx,@MuggyAdvisingEx,@BloodStasisAdvisingEx,@QiconstraintAdvisingEx,");
            builder.Append("@CharacteristicAdvisingEx,@IsDel,@IDCardNo,EffectAssess,Satisfy)");
            builder.Append(" ;select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 100),
                new MySqlParameter("@MedicineID", MySqlDbType.Decimal),
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
                new MySqlParameter("@MildAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@FaintAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@YangAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@YinAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@PhlegmdampAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@MuggyAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@BloodStasisAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@QiconstraintAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@CharacteristicAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@MildAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@FaintAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@YangadvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@YinAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@PhlegmdampAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@MuggyAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@BloodStasisAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@QiconstraintAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@CharacteristicAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@EffectAssess", MySqlDbType.String, 10),
                new MySqlParameter("@Satisfy", MySqlDbType.String, 10)

             };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.MedicineID;
            cmdParms[2].Value = model.Mild;
            cmdParms[3].Value = model.Faint;
            cmdParms[4].Value = model.Yang;
            cmdParms[5].Value = model.Yin;
            cmdParms[6].Value = model.PhlegmDamp;
            cmdParms[7].Value = model.Muggy;
            cmdParms[8].Value = model.BloodStasis;
            cmdParms[9].Value = model.QiConstraint;
            cmdParms[10].Value = model.Characteristic;
            cmdParms[11].Value = model.MildScore;
            cmdParms[12].Value = model.FaintScore;
            cmdParms[13].Value = model.YangsCore;
            cmdParms[14].Value = model.YinScore;
            cmdParms[15].Value = model.PhlegmdampScore;
            cmdParms[16].Value = model.MuggyScore;
            cmdParms[17].Value = model.BloodStasisScore;
            cmdParms[18].Value = model.QiConstraintScore;
            cmdParms[19].Value = model.CharacteristicScore;
            cmdParms[20].Value = model.MildAdvising;
            cmdParms[21].Value = model.FaintAdvising;
            cmdParms[22].Value = model.YangAdvising;
            cmdParms[23].Value = model.YinAdvising;
            cmdParms[24].Value = model.PhlegmdampAdvising;
            cmdParms[25].Value = model.MuggyAdvising;
            cmdParms[26].Value = model.BloodStasisAdvising;
            cmdParms[27].Value = model.QiconstraintAdvising;
            cmdParms[28].Value = model.CharacteristicAdvising;
            cmdParms[29].Value = model.MildAdvisingEx;
            cmdParms[30].Value = model.FaintAdvisingEx;
            cmdParms[31].Value = model.YangadvisingEx;
            cmdParms[32].Value = model.YinAdvisingEx;
            cmdParms[33].Value = model.PhlegmdampAdvisingEx;
            cmdParms[34].Value = model.MuggyAdvisingEx;
            cmdParms[35].Value = model.BloodStasisAdvisingEx;
            cmdParms[36].Value = model.QiconstraintAdvisingEx;
            cmdParms[37].Value = model.CharacteristicAdvisingEx;
            cmdParms[38].Value = model.IsDel;
            cmdParms[39].Value = model.IDCardNo;
            cmdParms[40].Value = model.EffectAssess;
            cmdParms[41].Value = model.Satisfy;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int Add(MedicineModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_recordsmedicineresult(");
            builder.Append("PhysicalID,MedicineID,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QIconStraint,Characteristic,");
            builder.Append("MildScore,FaintScore,YangsCore,YinScore,PhlegmdampScore,MuggyScore,BloodStasisScore,QiConstraintScore,");
            builder.Append("CharacteristicScore,MildAdvising,FaintAdvising,YangAdvising,YinAdvising,PhlegmdampAdvising,MuggyAdvising,");
            builder.Append("BloodStasisAdvising,QiconstraintAdvising,CharacteristicAdvising,MildAdvisingEx,FaintAdvisingEx,YangadvisingEx,");
            builder.Append("YinAdvisingEx,PhlegmdampAdvisingEx,MuggyAdvisingEx,BloodStasisAdvisingEx,QiconstraintAdvisingEx,");
            builder.Append("CharacteristicAdvisingEx,IsDel,IDCardNo,EffectAssess,Satisfy)");
            builder.Append(" VALUES (");
            builder.Append("@PhysicalID,@MedicineID,@Mild,@Faint,@Yang,@Yin,@PhlegmDamp,@Muggy,@BloodStasis,@QIconStraint,@Characteristic,");
            builder.Append("@MildScore,@FaintScore,@YangsCore,@YinScore,@PhlegmdampScore,@MuggyScore,@BloodStasisScore,@QiConstraintScore,");
            builder.Append("@CharacteristicScore,@MildAdvising,@FaintAdvising,@YangAdvising,@YinAdvising,@PhlegmdampAdvising,@MuggyAdvising,");
            builder.Append("@BloodStasisAdvising,@QiconstraintAdvising,@CharacteristicAdvising,@MildAdvisingEx,@FaintAdvisingEx,@YangadvisingEx,");
            builder.Append("@YinAdvisingEx,@PhlegmdampAdvisingEx,@MuggyAdvisingEx,@BloodStasisAdvisingEx,@QiconstraintAdvisingEx,");
            builder.Append("@CharacteristicAdvisingEx,@IsDel,@IDCardNo,@EffectAssess,@Satisfy)");
            builder.Append(" ;SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@MedicineID", MySqlDbType.Decimal),
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
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@EffectAssess", MySqlDbType.String, 10),
                new MySqlParameter("@Satisfy", MySqlDbType.String, 10)
            };

            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.MedicineID;
            cmdParms[2].Value = model.Mild;
            cmdParms[3].Value = model.Faint;
            cmdParms[4].Value = model.Yang;
            cmdParms[5].Value = model.Yin;
            cmdParms[6].Value = model.PhlegmDamp;
            cmdParms[7].Value = model.Muggy;
            cmdParms[8].Value = model.BloodStasis;
            cmdParms[9].Value = model.QiConstraint;
            cmdParms[10].Value = model.Characteristic;
            cmdParms[11].Value = model.MildScore;
            cmdParms[12].Value = model.FaintScore;
            cmdParms[13].Value = model.YangsCore;
            cmdParms[14].Value = model.YinScore;
            cmdParms[15].Value = model.PhlegmdampScore;
            cmdParms[16].Value = model.MuggyScore;
            cmdParms[17].Value = model.BloodStasisScore;
            cmdParms[18].Value = model.QiConstraintScore;
            cmdParms[19].Value = model.CharacteristicScore;
            cmdParms[20].Value = model.MildAdvising;
            cmdParms[21].Value = model.FaintAdvising;
            cmdParms[22].Value = model.YangAdvising;
            cmdParms[23].Value = model.YinAdvising;
            cmdParms[24].Value = model.PhlegmdampAdvising;
            cmdParms[25].Value = model.MuggyAdvising;
            cmdParms[26].Value = model.BloodStasisAdvising;
            cmdParms[27].Value = model.QiconstraintAdvising;
            cmdParms[28].Value = model.CharacteristicAdvising;
            cmdParms[29].Value = model.MildAdvisingEx;
            cmdParms[30].Value = model.FaintAdvisingEx;
            cmdParms[31].Value = model.YangadvisingEx;
            cmdParms[32].Value = model.YinAdvisingEx;
            cmdParms[33].Value = model.PhlegmdampAdvisingEx;
            cmdParms[34].Value = model.MuggyAdvisingEx;
            cmdParms[35].Value = model.BloodStasisAdvisingEx;
            cmdParms[36].Value = model.QiconstraintAdvisingEx;
            cmdParms[37].Value = model.CharacteristicAdvisingEx;
            cmdParms[38].Value = model.IsDel;
            cmdParms[39].Value = model.IDCardNo;
            cmdParms[40].Value = model.EffectAssess;
            cmdParms[41].Value = model.Satisfy;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsmedicineresult ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,MedicineID,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QIconStraint,Characteristic,");
            builder.Append("MildScore,FaintScore,YangsCore,YinScore,PhlegmdampScore,MuggyScore,BloodStasisScore,QiConstraintScore,");
            builder.Append("CharacteristicScore,MildAdvising,FaintAdvising,YangAdvising,YinAdvising,PhlegmdampAdvising,MuggyAdvising,");
            builder.Append("BloodStasisAdvising,QiconstraintAdvising,CharacteristicAdvising,MildAdvisingEx,FaintAdvisingEx,");
            builder.Append("YangadvisingEx,YinAdvisingEx,PhlegmdampAdvisingEx,MuggyAdvisingEx,BloodStasisAdvisingEx,");
            builder.Append("QiconstraintAdvisingEx,CharacteristicAdvisingEx,IsDel,IDCardNo ");
            builder.Append("from tbl_recordsmedicineresult ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@ID", MySqlDbType.String)
            };
            cmdParms[0].Value = ID;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            return set;
        }

        public bool Update(RecordsMedicineResultModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordsmedicineresult set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("MedicineID=@MedicineID,");
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
            builder.Append("CharacteristicAdvisingEx=@CharacteristicAdvisingEx		,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("IDCardNo=@IDCardNo, ");
            builder.Append("EffectAssess=@EffectAssess, ");
            builder.Append("Satisfy=@Satisfy  ");

            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
              new MySqlParameter("@PhysicalID", MySqlDbType.String, 100),
                new MySqlParameter("@MedicineID", MySqlDbType.Decimal),
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
                new MySqlParameter("@MildAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@FaintAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@YangAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@YinAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@PhlegmdampAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@MuggyAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@BloodStasisAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@QiconstraintAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@CharacteristicAdvising", MySqlDbType.String, 100),
                new MySqlParameter("@MildAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@FaintAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@YangadvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@YinAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@PhlegmdampAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@MuggyAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@BloodStasisAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@QiconstraintAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@CharacteristicAdvisingEx", MySqlDbType.String, 100),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@EffectAssess", MySqlDbType.String, 10),
                new MySqlParameter("@Satisfy", MySqlDbType.String, 10),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.MedicineID;
            cmdParms[2].Value = model.Mild;
            cmdParms[3].Value = model.Faint;
            cmdParms[4].Value = model.Yang;
            cmdParms[5].Value = model.Yin;
            cmdParms[6].Value = model.PhlegmDamp;
            cmdParms[7].Value = model.Muggy;
            cmdParms[8].Value = model.BloodStasis;
            cmdParms[9].Value = model.QiConstraint;
            cmdParms[10].Value = model.Characteristic;
            cmdParms[11].Value = model.MildScore;
            cmdParms[12].Value = model.FaintScore;
            cmdParms[13].Value = model.YangsCore;
            cmdParms[14].Value = model.YinScore;
            cmdParms[15].Value = model.PhlegmdampScore;
            cmdParms[16].Value = model.MuggyScore;
            cmdParms[17].Value = model.BloodStasisScore;
            cmdParms[18].Value = model.QiConstraintScore;
            cmdParms[19].Value = model.CharacteristicScore;
            cmdParms[20].Value = model.MildAdvising;
            cmdParms[21].Value = model.FaintAdvising;
            cmdParms[22].Value = model.YangAdvising;
            cmdParms[23].Value = model.YinAdvising;
            cmdParms[24].Value = model.PhlegmdampAdvising;
            cmdParms[25].Value = model.MuggyAdvising;
            cmdParms[26].Value = model.BloodStasisAdvising;
            cmdParms[27].Value = model.QiconstraintAdvising;
            cmdParms[28].Value = model.CharacteristicAdvising;
            cmdParms[29].Value = model.MildAdvisingEx;
            cmdParms[30].Value = model.FaintAdvisingEx;
            cmdParms[31].Value = model.YangadvisingEx;
            cmdParms[32].Value = model.YinAdvisingEx;
            cmdParms[33].Value = model.PhlegmdampAdvisingEx;
            cmdParms[34].Value = model.MuggyAdvisingEx;
            cmdParms[35].Value = model.BloodStasisAdvisingEx;
            cmdParms[36].Value = model.QiconstraintAdvisingEx;
            cmdParms[37].Value = model.CharacteristicAdvisingEx;
            cmdParms[38].Value = model.IsDel;
            cmdParms[39].Value = model.IDCardNo;
            cmdParms[40].Value = model.EffectAssess;
            cmdParms[41].Value = model.Satisfy;
            cmdParms[42].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 更新中医体质结果
        /// </summary>
        /// <param name="model"></param>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public bool UpdateByMiniPad(MedicineModel model, string customerID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"
                            UPDATE tbl_recordsmedicineresult D SET                             
                                Mild=@Mild,Faint=@Faint,Yang=@Yang,
                                Yin=@Yin, PhlegmDamp=@PhlegmDamp,
                                Muggy=@Muggy,BloodStasis=@BloodStasis,
                                QiConstraint=@QiConstraint,
                                Characteristic=@Characteristic,
                                MildScore=@MildScore,
                                FaintScore=@FaintScore,
                                YangsCore=@YangsCore,
                                YinScore=@YinScore,
                                PhlegmdampScore=@PhlegmdampScore,
                                MuggyScore=@MuggyScore,
                                BloodStasisScore=@BloodStasisScore,
                                QiConstraintScore=@QiConstraintScore,
                                CharacteristicScore=@CharacteristicScore,
                                MildAdvising=@MildAdvising,
                                FaintAdvising=@FaintAdvising,
                                YangAdvising=@YangAdvising,
                                YinAdvising=@YinAdvising,
                                PhlegmdampAdvising=@PhlegmdampAdvising,
                                MuggyAdvising=@MuggyAdvising,
                                BloodStasisAdvising=@BloodStasisAdvising,
                                QiconstraintAdvising=@QiconstraintAdvising,
                                CharacteristicAdvising=@CharacteristicAdvising,
                                MildAdvisingEx=@MildAdvisingEx,
                                FaintAdvisingEx=@FaintAdvisingEx,
                                YangadvisingEx=@YangadvisingEx,
                                YinAdvisingEx=@YinAdvisingEx,
                                PhlegmdampAdvisingEx=@PhlegmdampAdvisingEx,
                                MuggyAdvisingEx=@MuggyAdvisingEx,
                                BloodStasisAdvisingEx=@BloodStasisAdvisingEx,
                                QiconstraintAdvisingEx=@QiconstraintAdvisingEx,
                                CharacteristicAdvisingEx=@CharacteristicAdvisingEx
                             WHERE 
                                EXISTS
                                (
                                    SELECT 
                                        D.ID 
                                    FROM
                                        tbl_recordsmediphysdist med
                                    WHERE D.ID= med.MedicineResultID
                                        AND med.OutKey=@OutKey
                                ) ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@Mild", model.Mild),
                new MySqlParameter("@Faint", model.Faint),
                new MySqlParameter("@Yang", model.Yang),
                new MySqlParameter("@Yin", model.Yin),
                new MySqlParameter("@PhlegmDamp", model.PhlegmDamp),
                new MySqlParameter("@Muggy",model.Muggy),
                new MySqlParameter("@BloodStasis", model.BloodStasis),
                new MySqlParameter("@QiConstraint", model.QiConstraint),
                new MySqlParameter("@Characteristic",model.Characteristic),
                new MySqlParameter("@MildScore", model.MildScore),
                new MySqlParameter("@FaintScore", model.FaintScore),
                new MySqlParameter("@YangsCore", model.YangsCore),
                new MySqlParameter("@YinScore", model.YinScore),
                new MySqlParameter("@PhlegmdampScore", model.PhlegmdampScore),
                new MySqlParameter("@MuggyScore", model.MuggyScore),
                new MySqlParameter("@BloodStasisScore", model.BloodStasisScore),
                new MySqlParameter("@QiConstraintScore", model.QiConstraintScore),
                new MySqlParameter("@CharacteristicScore", model.CharacteristicScore),
                new MySqlParameter("@MildAdvising", model.MildAdvising),
                new MySqlParameter("@FaintAdvising",model.FaintAdvising),
                new MySqlParameter("@YangAdvising", model.YangAdvising),
                new MySqlParameter("@YinAdvising", model.YinAdvising),
                new MySqlParameter("@PhlegmdampAdvising", model.PhlegmdampAdvising),
                new MySqlParameter("@MuggyAdvising", model.MuggyAdvising),
                new MySqlParameter("@BloodStasisAdvising", model.BloodStasisAdvising),
                new MySqlParameter("@QiconstraintAdvising", model.QiconstraintAdvising),
                new MySqlParameter("@CharacteristicAdvising",model.QiconstraintAdvising),
                new MySqlParameter("@MildAdvisingEx",model.MildAdvisingEx),
                new MySqlParameter("@FaintAdvisingEx", model.FaintAdvisingEx),
                new MySqlParameter("@YangadvisingEx", model.YangadvisingEx),
                new MySqlParameter("@YinAdvisingEx", model.YinAdvisingEx),
                new MySqlParameter("@PhlegmdampAdvisingEx", model.PhlegmdampAdvisingEx),
                new MySqlParameter("@MuggyAdvisingEx",model.MuggyAdvisingEx),
                new MySqlParameter("@BloodStasisAdvisingEx", model.BloodStasisAdvisingEx),
                new MySqlParameter("@QiconstraintAdvisingEx", model.QiconstraintAdvisingEx),
                new MySqlParameter("@CharacteristicAdvisingEx", model.CharacteristicAdvisingEx),
                new MySqlParameter("@OutKey", customerID)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 更新体检中 中医体质辨识
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public bool UpdateMediphysDist(MedicineModel model, string customerID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE tbl_recordsmediphysdist D SET ");
            builder.Append("Mild=@Mild,Faint=@Faint,");
            builder.Append("Yang=@Yang,Yin=@Yin,");
            builder.Append("PhlegmDamp=@PhlegmDamp,Muggy=@Muggy,");
            builder.Append("BloodStasis=@BloodStasis,QiConstraint=@QiConstraint,");
            builder.Append("Characteristic=@Characteristic ");
            builder.Append("WHERE OutKey=@OutKey ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@OutKey", customerID),
                new MySqlParameter("@Mild", model.Mild),
                new MySqlParameter("@Faint", model.Faint),
                new MySqlParameter("@Yang", model.Yang),
                new MySqlParameter("@Yin", model.Yin),
                new MySqlParameter("@PhlegmDamp", model.PhlegmDamp),
                new MySqlParameter("@Muggy", model.Muggy),
                new MySqlParameter("@BloodStasis", model.BloodStasis),
                new MySqlParameter("@QiConstraint", model.QiConstraint),
                new MySqlParameter("@Characteristic", model.Characteristic)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        ///  更新体检中 中医体质辨识得分Key
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="ID"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMediphysDist(string customerID, int ID, MedicineModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE tbl_recordsmediphysdist D SET ");
            builder.Append("MedicineResultID=@MedicineResultID, ");
            builder.Append("Mild=@Mild,Faint=@Faint,");
            builder.Append("Yang=@Yang,Yin=@Yin,");
            builder.Append("PhlegmDamp=@PhlegmDamp,Muggy=@Muggy,");
            builder.Append("BloodStasis=@BloodStasis,QiConstraint=@QiConstraint,");
            builder.Append("Characteristic=@Characteristic ");
            builder.Append("WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@OutKey", customerID),
                new MySqlParameter("@MedicineResultID",ID),
                new MySqlParameter("@Mild", model.Mild),
                new MySqlParameter("@Faint", model.Faint),
                new MySqlParameter("@Yang", model.Yang),
                new MySqlParameter("@Yin", model.Yin),
                new MySqlParameter("@PhlegmDamp", model.PhlegmDamp),
                new MySqlParameter("@Muggy", model.Muggy),
                new MySqlParameter("@BloodStasis", model.BloodStasis),
                new MySqlParameter("@QiConstraint", model.QiConstraint),
                new MySqlParameter("@Characteristic", model.Characteristic)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
