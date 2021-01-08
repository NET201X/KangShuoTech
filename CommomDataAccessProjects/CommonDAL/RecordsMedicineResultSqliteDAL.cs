using CommonUtilities.SQL;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsMedicineResultSqliteDAL
    {
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
            builder.Append("Defecate,Defecatedry,Medicinecn.Tongue,Vein ");

            string table = "SELECT COUNT(0) FROM sqlite_master WHERE NAME = 'tbl_oldermedicineresult' AND SQL LIKE '%Tongue%'";

            object single = YcSqliteHelper.GetSingle(table, conn);
            int count = 0;

            if (single != null) count = int.Parse(single.ToString());

            if (count > 0) builder.Append(",Result.Tongue AS TongueM,TongueColor,TongueFur,Pulse ");

            builder.Append("FROM tbl_oldermedicinecn Medicinecn ");
            builder.Append("LEFT JOIN tbl_oldermedicineresult Result ");
            builder.Append("ON Result.IDCardNo=Medicinecn.IDCardNo ");
            builder.Append("AND Result.RecordDate=Medicinecn.RecordDate ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY Medicinecn.IDCardNo,DATE(Medicinecn.RecordDate) ");

            return YcSqliteHelper.Query(builder.ToString(), conn);
        }
    }
}
