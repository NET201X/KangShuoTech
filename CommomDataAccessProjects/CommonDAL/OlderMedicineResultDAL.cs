using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommonUtilities.SQL;
using System;
using System.Text;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class OlderMedicineResultDAL
    {
        public int Add(MedicineModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_OlderMedicineResult(");
            builder.Append("PhysicalID,MedicineID,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QIconStraint,Characteristic,");
            builder.Append("MildScore,FaintScore,YangsCore,YinScore,PhlegmdampScore,MuggyScore,BloodStasisScore,QiConstraintScore,");
            builder.Append("CharacteristicScore,MildAdvising,FaintAdvising,YangAdvising,YinAdvising,PhlegmdampAdvising,MuggyAdvising,");
            builder.Append("BloodStasisAdvising,QiconstraintAdvising,CharacteristicAdvising,MildAdvisingEx,FaintAdvisingEx,YangadvisingEx,");
            builder.Append("YinAdvisingEx,PhlegmdampAdvisingEx,MuggyAdvisingEx,BloodStasisAdvisingEx,QiconstraintAdvisingEx,");
            builder.Append("CharacteristicAdvisingEx,IsDel,IDCardNo");

            string table = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'tbl_oldermedicineresult' AND TABLE_SCHEMA='qcpaddb' AND COLUMN_NAME='Tongue'";

            object single = MySQLHelper.GetSingle(table);
            int count = 0;

            if (single != null) count = int.Parse(single.ToString());

            if (count > 0) builder.Append(",Tongue,TongueColor,TongueFur,Pulse,PulseOther");

            if (VersionNo.Contains("3.0")) builder.Append(" )");
            else builder.Append(" ,Outkey)");

            builder.Append(" VALUES (");
            builder.Append("@PhysicalID,@MedicineID,@Mild,@Faint,@Yang,@Yin,@PhlegmDamp,@Muggy,@BloodStasis,@QIconStraint,@Characteristic,");
            builder.Append("@MildScore,@FaintScore,@YangsCore,@YinScore,@PhlegmdampScore,@MuggyScore,@BloodStasisScore,@QiConstraintScore,");
            builder.Append("@CharacteristicScore,@MildAdvising,@FaintAdvising,@YangAdvising,@YinAdvising,@PhlegmdampAdvising,@MuggyAdvising,");
            builder.Append("@BloodStasisAdvising,@QiconstraintAdvising,@CharacteristicAdvising,@MildAdvisingEx,@FaintAdvisingEx,@YangadvisingEx,");
            builder.Append("@YinAdvisingEx,@PhlegmdampAdvisingEx,@MuggyAdvisingEx,@BloodStasisAdvisingEx,@QiconstraintAdvisingEx,");
            builder.Append("@CharacteristicAdvisingEx,@IsDel,@IDCardNo");

            if (count > 0) builder.Append(",@TongueM,@TongueColor,@TongueFur,@Pulse,@PulseOther");

            if (VersionNo.Contains("3.0")) builder.Append(" )");
            else builder.Append(" ,@Outkey)");

            builder.Append(";SELECT @@IDENTITY");

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
                new MySqlParameter("@TongueM", MySqlDbType.String, 50),
                new MySqlParameter("@TongueColor", MySqlDbType.String, 50),
                new MySqlParameter("@TongueFur", MySqlDbType.String, 50),
                new MySqlParameter("@Pulse", MySqlDbType.String, 50),
                new MySqlParameter("@PulseOther", MySqlDbType.String, 50),
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 11)
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
            cmdParms[40].Value = model.TongueM;
            cmdParms[41].Value = model.TongueColor;
            cmdParms[42].Value = model.TongueFur;
            cmdParms[43].Value = model.Pulse;
            cmdParms[44].Value = model.PulseOther;
            cmdParms[45].Value = model.OutKey;

            single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public bool Update(MedicineModel model, string Version)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE tbl_OlderMedicineResult SET ");
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
            builder.Append("CharacteristicAdvisingEx=@CharacteristicAdvisingEx ");

            string table = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'tbl_oldermedicineresult' AND TABLE_SCHEMA='qcpaddb' AND COLUMN_NAME='Tongue'";

            object single = MySQLHelper.GetSingle(table);
            int count = 0;

            if (single != null) count = int.Parse(single.ToString());

            if (count > 0) builder.Append(",Tongue=@TongueM,TongueColor=@TongueColor,TongueFur=@TongueFur,Pulse=@Pulse,PulseOther=@PulseOther");

            if (Version.Contains("V3.0")) builder.Append(" WHERE MedicineID=@MedicineID");
            else builder.Append(" WHERE Outkey=@Outkey");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@MedicineID", MySqlDbType.Int32),
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
                new MySqlParameter("@TongueM", MySqlDbType.String, 50),
                new MySqlParameter("@TongueColor", MySqlDbType.String, 50),
                new MySqlParameter("@TongueFur", MySqlDbType.String, 50),
                new MySqlParameter("@Pulse", MySqlDbType.String, 50),
                new MySqlParameter("@PulseOther", MySqlDbType.String, 50),
                new MySqlParameter("@Outkey", MySqlDbType.Int32, 11)
            };

            cmdParms[0].Value = model.MedicineID;
            cmdParms[1].Value = model.Mild;
            cmdParms[2].Value = model.Faint;
            cmdParms[3].Value = model.Yang;
            cmdParms[4].Value = model.Yin;
            cmdParms[5].Value = model.PhlegmDamp;
            cmdParms[6].Value = model.Muggy;
            cmdParms[7].Value = model.BloodStasis;
            cmdParms[8].Value = model.QiConstraint;
            cmdParms[9].Value = model.Characteristic;
            cmdParms[10].Value = model.MildScore;
            cmdParms[11].Value = model.FaintScore;
            cmdParms[12].Value = model.YangsCore;
            cmdParms[13].Value = model.YinScore;
            cmdParms[14].Value = model.PhlegmdampScore;
            cmdParms[15].Value = model.MuggyScore;
            cmdParms[16].Value = model.BloodStasisScore;
            cmdParms[17].Value = model.QiConstraintScore;
            cmdParms[18].Value = model.CharacteristicScore;
            cmdParms[19].Value = model.MildAdvising;
            cmdParms[20].Value = model.FaintAdvising;
            cmdParms[21].Value = model.YangAdvising;
            cmdParms[22].Value = model.YinAdvising;
            cmdParms[23].Value = model.PhlegmdampAdvising;
            cmdParms[24].Value = model.MuggyAdvising;
            cmdParms[25].Value = model.BloodStasisAdvising;
            cmdParms[26].Value = model.QiconstraintAdvising;
            cmdParms[27].Value = model.CharacteristicAdvising;
            cmdParms[28].Value = model.MildAdvisingEx;
            cmdParms[29].Value = model.FaintAdvisingEx;
            cmdParms[30].Value = model.YangadvisingEx;
            cmdParms[31].Value = model.YinAdvisingEx;
            cmdParms[32].Value = model.PhlegmdampAdvisingEx;
            cmdParms[33].Value = model.MuggyAdvisingEx;
            cmdParms[34].Value = model.BloodStasisAdvisingEx;
            cmdParms[35].Value = model.QiconstraintAdvisingEx;
            cmdParms[36].Value = model.CharacteristicAdvisingEx;
            cmdParms[37].Value = model.TongueM;
            cmdParms[38].Value = model.TongueColor;
            cmdParms[39].Value = model.TongueFur;
            cmdParms[40].Value = model.Pulse;
            cmdParms[41].Value = model.PulseOther;
            cmdParms[42].Value = model.OutKey;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet GetModel(int outKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_OlderMedicineResult ");
            builder.Append(" WHERE MedicineID=@MedicineID");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@MedicineID", MySqlDbType.Int32)
            };

            cmdParms[0].Value = outKey;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }
    }
}
