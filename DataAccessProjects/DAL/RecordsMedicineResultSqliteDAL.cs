namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    using KangShuoTech.Utilities.SQLiteHelper;

    public class RecordsMedicineResultSqliteDAL 
    {        
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QIconStraint,Characteristic,MildScore,FaintScore,YangsCore,YinScore,PhlegmdampScore,MuggyScore,BloodStasisScore,QiConstraintScore,CharacteristicScore,MildAdvising,FaintAdvising,YangAdvising,YinAdvising,PhlegmdampAdvising,MuggyAdvising,BloodStasisAdvising,QiconstraintAdvising,CharacteristicAdvising,MildAdvisingEx,FaintAdvisingEx,YangadvisingEx,YinAdvisingEx,PhlegmdampAdvisingEx,MuggyAdvisingEx,BloodStasisAdvisingEx,QiconstraintAdvisingEx,CharacteristicAdvisingEx,IDCardNo,EffectAssess,Satisfy,RecordDate ");
            builder.Append(" FROM OLD_MEDICINE_RESULT ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return YcSqliteHelper.Query(builder.ToString());
        }

        public DataSet GetMaxList(string strWhere, string conn)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QIconStraint,Characteristic, ");
            builder.Append("MildScore,FaintScore,YangsCore,YinScore,PhlegmdampScore,MuggyScore,BloodStasisScore, ");
            builder.Append("QiConstraintScore,CharacteristicScore,MildAdvising,FaintAdvising,YangAdvising,YinAdvising, ");
            builder.Append("PhlegmdampAdvising,MuggyAdvising,BloodStasisAdvising,QiconstraintAdvising,CharacteristicAdvising, ");
            builder.Append("MildAdvisingEx,FaintAdvisingEx,YangadvisingEx,YinAdvisingEx,PhlegmdampAdvisingEx,MuggyAdvisingEx, ");
            builder.Append("BloodStasisAdvisingEx,QiconstraintAdvisingEx,CharacteristicAdvisingEx, ");
            builder.Append("Medicinecn.RecordDate,Medicinecn.IDCardNo, ");
            builder.Append("Energy,Tired,Breath,Voice,Emotion,Spirit,Alone,Fear,Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal, ");
            builder.Append("Snore,Allergy,Urticaria,Skin,Scratch,Mouth,Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood, ");
            builder.Append("Defecate,Defecatedry,Tongue,Vein ");
            builder.Append("FROM OLD_MEDICINE_CN Medicinecn ");
            builder.Append("LEFT JOIN OLD_MEDICINE_RESULT Result ");
            builder.Append("ON Result.IDCardNo=Medicinecn.IDCardNo ");
            builder.Append("AND Result.RecordDate=Medicinecn.RecordDate ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY Medicinecn.IDCardNo,DATE(Medicinecn.RecordDate) ");

            return YcSqliteHelper.Query(builder.ToString(), conn);
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM OLD_MEDICINE_RESULT ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            } 
            object single = YcSqliteHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
          
        }      
    }
}

