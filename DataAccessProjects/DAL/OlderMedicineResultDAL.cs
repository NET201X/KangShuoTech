namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class OlderMedicineResultDAL
    {
        public int Add(OlderMedicineResultModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into OLD_MEDICINE_RESULT(");
            builder.Append("PhysicalID,MedicineID,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QIconStraint,Characteristic,");
            builder.Append("MildScore,FaintScore,YangsCore,YinScore,PhlegmdampScore,MuggyScore,BloodStasisScore,QiConstraintScore,");
            builder.Append("CharacteristicScore,MildAdvising,FaintAdvising,YangAdvising,YinAdvising,PhlegmdampAdvising,MuggyAdvising,");
            builder.Append("BloodStasisAdvising,QiconstraintAdvising,CharacteristicAdvising,MildAdvisingEx,FaintAdvisingEx,YangadvisingEx,");
            builder.Append("YinAdvisingEx,PhlegmdampAdvisingEx,MuggyAdvisingEx,BloodStasisAdvisingEx,QiconstraintAdvisingEx,");
            builder.Append("CharacteristicAdvisingEx,IsDel,IDCardNo,OUTkey,RecordDate,EffectAssess,Satisfy)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@MedicineID,@Mild,@Faint,@Yang,@Yin,@PhlegmDamp,@Muggy,@BloodStasis,@QIconStraint,@Characteristic,");
            builder.Append("@MildScore,@FaintScore,@YangsCore,@YinScore,@PhlegmdampScore,@MuggyScore,@BloodStasisScore,@QiConstraintScore,");
            builder.Append("@CharacteristicScore,@MildAdvising,@FaintAdvising,@YangAdvising,@YinAdvising,@PhlegmdampAdvising,@MuggyAdvising,");
            builder.Append("@BloodStasisAdvising,@QiconstraintAdvising,@CharacteristicAdvising,@MildAdvisingEx,@FaintAdvisingEx,@YangadvisingEx,");
            builder.Append("@YinAdvisingEx,@PhlegmdampAdvisingEx,@MuggyAdvisingEx,@BloodStasisAdvisingEx,@QiconstraintAdvisingEx,");
            builder.Append("@CharacteristicAdvisingEx,@IsDel,@IDCardNo,@OUTkey,@RecordDate,@EffectAssess,@Satisfy)");
            builder.Append(" ;select @@IDENTITY");
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
                new MySqlParameter("@OUTkey", MySqlDbType.Int32, 11),
                //新增字段
                new MySqlParameter("@RecordDate", MySqlDbType.Date),
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
            cmdParms[40].Value = model.OUTkey;
            //新增字段
            cmdParms[41].Value = model.RecordDate;
            cmdParms[42].Value = model.EffectAssess;
            cmdParms[43].Value = model.Satisfy;
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

            builder.Append("INSERT INTO OLD_MEDICINE_RESULT(");
            builder.Append("PhysicalID,MedicineID,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QIconStraint,Characteristic,");
            builder.Append("MildScore,FaintScore,YangsCore,YinScore,PhlegmdampScore,MuggyScore,BloodStasisScore,QiConstraintScore,");
            builder.Append("CharacteristicScore,MildAdvising,FaintAdvising,YangAdvising,YinAdvising,PhlegmdampAdvising,MuggyAdvising,");
            builder.Append("BloodStasisAdvising,QiconstraintAdvising,CharacteristicAdvising,MildAdvisingEx,FaintAdvisingEx,YangadvisingEx,");
            builder.Append("YinAdvisingEx,PhlegmdampAdvisingEx,MuggyAdvisingEx,BloodStasisAdvisingEx,QiconstraintAdvisingEx,");
            builder.Append("CharacteristicAdvisingEx,IsDel,IDCardNo,OUTkey)");
            builder.Append(" VALUES (");
            builder.Append("@PhysicalID,@MedicineID,@Mild,@Faint,@Yang,@Yin,@PhlegmDamp,@Muggy,@BloodStasis,@QIconStraint,@Characteristic,");
            builder.Append("@MildScore,@FaintScore,@YangsCore,@YinScore,@PhlegmdampScore,@MuggyScore,@BloodStasisScore,@QiConstraintScore,");
            builder.Append("@CharacteristicScore,@MildAdvising,@FaintAdvising,@YangAdvising,@YinAdvising,@PhlegmdampAdvising,@MuggyAdvising,");
            builder.Append("@BloodStasisAdvising,@QiconstraintAdvising,@CharacteristicAdvising,@MildAdvisingEx,@FaintAdvisingEx,@YangadvisingEx,");
            builder.Append("@YinAdvisingEx,@PhlegmdampAdvisingEx,@MuggyAdvisingEx,@BloodStasisAdvisingEx,@QiconstraintAdvisingEx,");
            builder.Append("@CharacteristicAdvisingEx,@IsDel,@IDCardNo,@OutKey)");
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
            cmdParms[40].Value = model.OutKey;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }
        
        public bool DelOUTkey(int OUTkey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from OLD_MEDICINE_RESULT ");
            builder.Append(" where OUTkey=@OUTkey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OUTkey", MySqlDbType.Int32, 11) };
            cmdParms[0].Value = OUTkey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        
        public bool ExistOUTKey(int OUTkey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from OLD_MEDICINE_RESULT");
            builder.Append(" where OUTkey=@OUTkey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OUTkey", MySqlDbType.Int32, 11) };
            cmdParms[0].Value = OUTkey;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetModel(string IDCardNo, int OUTKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,MedicineID,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QIconStraint,Characteristic,");
            builder.Append("MildScore,FaintScore,YangsCore,YinScore,PhlegmdampScore,MuggyScore,BloodStasisScore,QiConstraintScore,");
            builder.Append("CharacteristicScore,MildAdvising,FaintAdvising,YangAdvising,YinAdvising,PhlegmdampAdvising,MuggyAdvising,");
            builder.Append("BloodStasisAdvising,QiconstraintAdvising,CharacteristicAdvising,MildAdvisingEx,FaintAdvisingEx,");
            builder.Append("YangadvisingEx,YinAdvisingEx,PhlegmdampAdvisingEx,MuggyAdvisingEx,BloodStasisAdvisingEx,");
            builder.Append("QiconstraintAdvisingEx,CharacteristicAdvisingEx,IsDel,IDCardNo,OUTkey,OUTkey,RecordDate,EffectAssess,Satisfy ");
            builder.Append("from OLD_MEDICINE_RESULT ");
            builder.Append(" where IDCardNo=@IDCardNo and  OUTKey = @OUTKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String) ,
                new MySqlParameter("@OUTKey", MySqlDbType.Int32,11)
            };
            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = OUTKey;
            return MySQLHelper.Query(builder.ToString(), cmdParms);

        }

        public DataSet GetModelOUTKey(int OUTkey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,MedicineID,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QIconStraint,Characteristic,");
            builder.Append("MildScore,FaintScore,YangsCore,YinScore,PhlegmdampScore,MuggyScore,BloodStasisScore,QiConstraintScore,");
            builder.Append("CharacteristicScore,MildAdvising,FaintAdvising,YangAdvising,YinAdvising,PhlegmdampAdvising,MuggyAdvising,");
            builder.Append("BloodStasisAdvising,QiconstraintAdvising,CharacteristicAdvising,MildAdvisingEx,FaintAdvisingEx,");
            builder.Append("YangadvisingEx,YinAdvisingEx,PhlegmdampAdvisingEx,MuggyAdvisingEx,BloodStasisAdvisingEx,");
            builder.Append("QiconstraintAdvisingEx,CharacteristicAdvisingEx,IsDel,IDCardNo,OUTkey,RecordDate,EffectAssess,Satisfy ");
            builder.Append("from OLD_MEDICINE_RESULT ");
            builder.Append(" where OUTkey=@OUTkey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OUTkey", MySqlDbType.Int32, 11) };
            cmdParms[0].Value = OUTkey;
            return MySQLHelper.Query(builder.ToString(), cmdParms);

        }
        
        public bool Update(OlderMedicineResultModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update OLD_MEDICINE_RESULT set ");
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
            builder.Append("IDCardNo=@IDCardNo,");
            //新增字段
            builder.Append("RecordDate=@RecordDate,");
            builder.Append("EffectAssess=@EffectAssess,");
            builder.Append("Satisfy=@Satisfy ");
            builder.Append(" where OUTkey=@OUTkey");
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
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@OUTkey", MySqlDbType.Int32, 8),
                //新增字段
                new MySqlParameter("@RecordDate", MySqlDbType.Date),
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
            cmdParms[40].Value = model.OUTkey;
            //新增字段
            cmdParms[41].Value = model.RecordDate;
            cmdParms[42].Value = model.EffectAssess;
            cmdParms[43].Value = model.Satisfy;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Update(MedicineModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE OLD_MEDICINE_RESULT SET ");
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
            builder.Append("CharacteristicAdvisingEx=@CharacteristicAdvisingEx	");
            builder.Append(" WHERE Outkey=@Outkey");

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
                new MySqlParameter("@Outkey", MySqlDbType.Int32, 11)
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
            cmdParms[36].Value = model.OutKey;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

