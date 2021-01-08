namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    using KangShuoTech.Utilities.SQLiteHelper;

    public class RecordsMedicineCnSqliteDAL
    {
     
        public OlderMedicineCnModel DataRowToModel(DataRow row)
        {
            OlderMedicineCnModel records_medicine_cn = new OlderMedicineCnModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    records_medicine_cn.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    records_medicine_cn.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["Energy"] != null) && (row["Energy"] != DBNull.Value)) && (row["Energy"].ToString() != ""))
                {
                    records_medicine_cn.Energy = new decimal?(decimal.Parse(row["Energy"].ToString()));
                }
                if (((row["Tired"] != null) && (row["Tired"] != DBNull.Value)) && (row["Tired"].ToString() != ""))
                {
                    records_medicine_cn.Tired = new decimal?(decimal.Parse(row["Tired"].ToString()));
                }
                if (((row["Breath"] != null) && (row["Breath"] != DBNull.Value)) && (row["Breath"].ToString() != ""))
                {
                    records_medicine_cn.Breath = new decimal?(decimal.Parse(row["Breath"].ToString()));
                }
                if (((row["Voice"] != null) && (row["Voice"] != DBNull.Value)) && (row["Voice"].ToString() != ""))
                {
                    records_medicine_cn.Voice = new decimal?(decimal.Parse(row["Voice"].ToString()));
                }
                if (((row["Emotion"] != null) && (row["Emotion"] != DBNull.Value)) && (row["Emotion"].ToString() != ""))
                {
                    records_medicine_cn.Emotion = new decimal?(decimal.Parse(row["Emotion"].ToString()));
                }
                if (((row["Spirit"] != null) && (row["Spirit"] != DBNull.Value)) && (row["Spirit"].ToString() != ""))
                {
                    records_medicine_cn.Spirit = new decimal?(decimal.Parse(row["Spirit"].ToString()));
                }
                if (((row["Alone"] != null) && (row["Alone"] != DBNull.Value)) && (row["Alone"].ToString() != ""))
                {
                    records_medicine_cn.Alone = new decimal?(decimal.Parse(row["Alone"].ToString()));
                }
                if (((row["Fear"] != null) && (row["Fear"] != DBNull.Value)) && (row["Fear"].ToString() != ""))
                {
                    records_medicine_cn.Fear = new decimal?(decimal.Parse(row["Fear"].ToString()));
                }
                if (((row["Weight"] != null) && (row["Weight"] != DBNull.Value)) && (row["Weight"].ToString() != ""))
                {
                    records_medicine_cn.Weight = new decimal?(decimal.Parse(row["Weight"].ToString()));
                }
                if (((row["Eye"] != null) && (row["Eye"] != DBNull.Value)) && (row["Eye"].ToString() != ""))
                {
                    records_medicine_cn.Eye = new decimal?(decimal.Parse(row["Eye"].ToString()));
                }
                if (((row["FootHand"] != null) && (row["FootHand"] != DBNull.Value)) && (row["FootHand"].ToString() != ""))
                {
                    records_medicine_cn.FootHand = new decimal?(decimal.Parse(row["FootHand"].ToString()));
                }
                if (((row["Stomach"] != null) && (row["Stomach"] != DBNull.Value)) && (row["Stomach"].ToString() != ""))
                {
                    records_medicine_cn.Stomach = new decimal?(decimal.Parse(row["Stomach"].ToString()));
                }
                if (((row["Cold"] != null) && (row["Cold"] != DBNull.Value)) && (row["Cold"].ToString() != ""))
                {
                    records_medicine_cn.Cold = new decimal?(decimal.Parse(row["Cold"].ToString()));
                }
                if (((row["Influenza"] != null) && (row["Influenza"] != DBNull.Value)) && (row["Influenza"].ToString() != ""))
                {
                    records_medicine_cn.Influenza = new decimal?(decimal.Parse(row["Influenza"].ToString()));
                }
                if (((row["Nasal"] != null) && (row["Nasal"] != DBNull.Value)) && (row["Nasal"].ToString() != ""))
                {
                    records_medicine_cn.Nasal = new decimal?(decimal.Parse(row["Nasal"].ToString()));
                }
                if (((row["Snore"] != null) && (row["Snore"] != DBNull.Value)) && (row["Snore"].ToString() != ""))
                {
                    records_medicine_cn.Snore = new decimal?(decimal.Parse(row["Snore"].ToString()));
                }
                if (((row["Allergy"] != null) && (row["Allergy"] != DBNull.Value)) && (row["Allergy"].ToString() != ""))
                {
                    records_medicine_cn.Allergy = new decimal?(decimal.Parse(row["Allergy"].ToString()));
                }
                if (((row["Urticaria"] != null) && (row["Urticaria"] != DBNull.Value)) && (row["Urticaria"].ToString() != ""))
                {
                    records_medicine_cn.Urticaria = new decimal?(decimal.Parse(row["Urticaria"].ToString()));
                }
                if (((row["Skin"] != null) && (row["Skin"] != DBNull.Value)) && (row["Skin"].ToString() != ""))
                {
                    records_medicine_cn.Skin = new decimal?(decimal.Parse(row["Skin"].ToString()));
                }
                if (((row["Scratch"] != null) && (row["Scratch"] != DBNull.Value)) && (row["Scratch"].ToString() != ""))
                {
                    records_medicine_cn.Scratch = new decimal?(decimal.Parse(row["Scratch"].ToString()));
                }
                if (((row["Mouth"] != null) && (row["Mouth"] != DBNull.Value)) && (row["Mouth"].ToString() != ""))
                {
                    records_medicine_cn.Mouth = new decimal?(decimal.Parse(row["Mouth"].ToString()));
                }
                if (((row["Arms"] != null) && (row["Arms"] != DBNull.Value)) && (row["Arms"].ToString() != ""))
                {
                    records_medicine_cn.Arms = new decimal?(decimal.Parse(row["Arms"].ToString()));
                }
                if (((row["Greasy"] != null) && (row["Greasy"] != DBNull.Value)) && (row["Greasy"].ToString() != ""))
                {
                    records_medicine_cn.Greasy = new decimal?(decimal.Parse(row["Greasy"].ToString()));
                }
                if (((row["Spot"] != null) && (row["Spot"] != DBNull.Value)) && (row["Spot"].ToString() != ""))
                {
                    records_medicine_cn.Spot = new decimal?(decimal.Parse(row["Spot"].ToString()));
                }
                if (((row["Eczema"] != null) && (row["Eczema"] != DBNull.Value)) && (row["Eczema"].ToString() != ""))
                {
                    records_medicine_cn.Eczema = new decimal?(decimal.Parse(row["Eczema"].ToString()));
                }
                if (((row["Thirsty"] != null) && (row["Thirsty"] != DBNull.Value)) && (row["Thirsty"].ToString() != ""))
                {
                    records_medicine_cn.Thirsty = new decimal?(decimal.Parse(row["Thirsty"].ToString()));
                }
                if (((row["Smell"] != null) && (row["Smell"] != DBNull.Value)) && (row["Smell"].ToString() != ""))
                {
                    records_medicine_cn.Smell = new decimal?(decimal.Parse(row["Smell"].ToString()));
                }
                if (((row["Abdomen"] != null) && (row["Abdomen"] != DBNull.Value)) && (row["Abdomen"].ToString() != ""))
                {
                    records_medicine_cn.Abdomen = new decimal?(decimal.Parse(row["Abdomen"].ToString()));
                }
                if (((row["Coolfood"] != null) && (row["Coolfood"] != DBNull.Value)) && (row["Coolfood"].ToString() != ""))
                {
                    records_medicine_cn.Coolfood = new decimal?(decimal.Parse(row["Coolfood"].ToString()));
                }
                if (((row["Defecate"] != null) && (row["Defecate"] != DBNull.Value)) && (row["Defecate"].ToString() != ""))
                {
                    records_medicine_cn.Defecate = new decimal?(decimal.Parse(row["Defecate"].ToString()));
                }
                if (((row["Defecatedry"] != null) && (row["Defecatedry"] != DBNull.Value)) && (row["Defecatedry"].ToString() != ""))
                {
                    records_medicine_cn.Defecatedry = new decimal?(decimal.Parse(row["Defecatedry"].ToString()));
                }
                if (((row["Tongue"] != null) && (row["Tongue"] != DBNull.Value)) && (row["Tongue"].ToString() != ""))
                {
                    records_medicine_cn.Tongue = new decimal?(decimal.Parse(row["Tongue"].ToString()));
                }
                if (((row["Vein"] != null) && (row["Vein"] != DBNull.Value)) && (row["Vein"].ToString() != ""))
                {
                    records_medicine_cn.Vein = new decimal?(decimal.Parse(row["Vein"].ToString()));
                }
                if (((row["RecordDate"] != null) && (row["RecordDate"] != DBNull.Value)) && (row["RecordDate"].ToString() != ""))
                {
                    records_medicine_cn.RecordDate = new DateTime?(DateTime.Parse(row["RecordDate"].ToString()));
                }
               
            }
            return records_medicine_cn;
        }
        public RecordsMedicineCnModel RecordDataRowToModel(DataRow row)
        {
            RecordsMedicineCnModel records_medicine_cn = new RecordsMedicineCnModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    records_medicine_cn.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    records_medicine_cn.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["Energy"] != null) && (row["Energy"] != DBNull.Value)) && (row["Energy"].ToString() != ""))
                {
                    records_medicine_cn.Energy = new decimal?(decimal.Parse(row["Energy"].ToString()));
                }
                if (((row["Tired"] != null) && (row["Tired"] != DBNull.Value)) && (row["Tired"].ToString() != ""))
                {
                    records_medicine_cn.Tired = new decimal?(decimal.Parse(row["Tired"].ToString()));
                }
                if (((row["Breath"] != null) && (row["Breath"] != DBNull.Value)) && (row["Breath"].ToString() != ""))
                {
                    records_medicine_cn.Breath = new decimal?(decimal.Parse(row["Breath"].ToString()));
                }
                if (((row["Voice"] != null) && (row["Voice"] != DBNull.Value)) && (row["Voice"].ToString() != ""))
                {
                    records_medicine_cn.Voice = new decimal?(decimal.Parse(row["Voice"].ToString()));
                }
                if (((row["Emotion"] != null) && (row["Emotion"] != DBNull.Value)) && (row["Emotion"].ToString() != ""))
                {
                    records_medicine_cn.Emotion = new decimal?(decimal.Parse(row["Emotion"].ToString()));
                }
                if (((row["Spirit"] != null) && (row["Spirit"] != DBNull.Value)) && (row["Spirit"].ToString() != ""))
                {
                    records_medicine_cn.Spirit = new decimal?(decimal.Parse(row["Spirit"].ToString()));
                }
                if (((row["Alone"] != null) && (row["Alone"] != DBNull.Value)) && (row["Alone"].ToString() != ""))
                {
                    records_medicine_cn.Alone = new decimal?(decimal.Parse(row["Alone"].ToString()));
                }
                if (((row["Fear"] != null) && (row["Fear"] != DBNull.Value)) && (row["Fear"].ToString() != ""))
                {
                    records_medicine_cn.Fear = new decimal?(decimal.Parse(row["Fear"].ToString()));
                }
                if (((row["Weight"] != null) && (row["Weight"] != DBNull.Value)) && (row["Weight"].ToString() != ""))
                {
                    records_medicine_cn.Weight = new decimal?(decimal.Parse(row["Weight"].ToString()));
                }
                if (((row["Eye"] != null) && (row["Eye"] != DBNull.Value)) && (row["Eye"].ToString() != ""))
                {
                    records_medicine_cn.Eye = new decimal?(decimal.Parse(row["Eye"].ToString()));
                }
                if (((row["FootHand"] != null) && (row["FootHand"] != DBNull.Value)) && (row["FootHand"].ToString() != ""))
                {
                    records_medicine_cn.FootHand = new decimal?(decimal.Parse(row["FootHand"].ToString()));
                }
                if (((row["Stomach"] != null) && (row["Stomach"] != DBNull.Value)) && (row["Stomach"].ToString() != ""))
                {
                    records_medicine_cn.Stomach = new decimal?(decimal.Parse(row["Stomach"].ToString()));
                }
                if (((row["Cold"] != null) && (row["Cold"] != DBNull.Value)) && (row["Cold"].ToString() != ""))
                {
                    records_medicine_cn.Cold = new decimal?(decimal.Parse(row["Cold"].ToString()));
                }
                if (((row["Influenza"] != null) && (row["Influenza"] != DBNull.Value)) && (row["Influenza"].ToString() != ""))
                {
                    records_medicine_cn.Influenza = new decimal?(decimal.Parse(row["Influenza"].ToString()));
                }
                if (((row["Nasal"] != null) && (row["Nasal"] != DBNull.Value)) && (row["Nasal"].ToString() != ""))
                {
                    records_medicine_cn.Nasal = new decimal?(decimal.Parse(row["Nasal"].ToString()));
                }
                if (((row["Snore"] != null) && (row["Snore"] != DBNull.Value)) && (row["Snore"].ToString() != ""))
                {
                    records_medicine_cn.Snore = new decimal?(decimal.Parse(row["Snore"].ToString()));
                }
                if (((row["Allergy"] != null) && (row["Allergy"] != DBNull.Value)) && (row["Allergy"].ToString() != ""))
                {
                    records_medicine_cn.Allergy = new decimal?(decimal.Parse(row["Allergy"].ToString()));
                }
                if (((row["Urticaria"] != null) && (row["Urticaria"] != DBNull.Value)) && (row["Urticaria"].ToString() != ""))
                {
                    records_medicine_cn.Urticaria = new decimal?(decimal.Parse(row["Urticaria"].ToString()));
                }
                if (((row["Skin"] != null) && (row["Skin"] != DBNull.Value)) && (row["Skin"].ToString() != ""))
                {
                    records_medicine_cn.Skin = new decimal?(decimal.Parse(row["Skin"].ToString()));
                }
                if (((row["Scratch"] != null) && (row["Scratch"] != DBNull.Value)) && (row["Scratch"].ToString() != ""))
                {
                    records_medicine_cn.Scratch = new decimal?(decimal.Parse(row["Scratch"].ToString()));
                }
                if (((row["Mouth"] != null) && (row["Mouth"] != DBNull.Value)) && (row["Mouth"].ToString() != ""))
                {
                    records_medicine_cn.Mouth = new decimal?(decimal.Parse(row["Mouth"].ToString()));
                }
                if (((row["Arms"] != null) && (row["Arms"] != DBNull.Value)) && (row["Arms"].ToString() != ""))
                {
                    records_medicine_cn.Arms = new decimal?(decimal.Parse(row["Arms"].ToString()));
                }
                if (((row["Greasy"] != null) && (row["Greasy"] != DBNull.Value)) && (row["Greasy"].ToString() != ""))
                {
                    records_medicine_cn.Greasy = new decimal?(decimal.Parse(row["Greasy"].ToString()));
                }
                if (((row["Spot"] != null) && (row["Spot"] != DBNull.Value)) && (row["Spot"].ToString() != ""))
                {
                    records_medicine_cn.Spot = new decimal?(decimal.Parse(row["Spot"].ToString()));
                }
                if (((row["Eczema"] != null) && (row["Eczema"] != DBNull.Value)) && (row["Eczema"].ToString() != ""))
                {
                    records_medicine_cn.Eczema = new decimal?(decimal.Parse(row["Eczema"].ToString()));
                }
                if (((row["Thirsty"] != null) && (row["Thirsty"] != DBNull.Value)) && (row["Thirsty"].ToString() != ""))
                {
                    records_medicine_cn.Thirsty = new decimal?(decimal.Parse(row["Thirsty"].ToString()));
                }
                if (((row["Smell"] != null) && (row["Smell"] != DBNull.Value)) && (row["Smell"].ToString() != ""))
                {
                    records_medicine_cn.Smell = new decimal?(decimal.Parse(row["Smell"].ToString()));
                }
                if (((row["Abdomen"] != null) && (row["Abdomen"] != DBNull.Value)) && (row["Abdomen"].ToString() != ""))
                {
                    records_medicine_cn.Abdomen = new decimal?(decimal.Parse(row["Abdomen"].ToString()));
                }
                if (((row["Coolfood"] != null) && (row["Coolfood"] != DBNull.Value)) && (row["Coolfood"].ToString() != ""))
                {
                    records_medicine_cn.Coolfood = new decimal?(decimal.Parse(row["Coolfood"].ToString()));
                }
                if (((row["Defecate"] != null) && (row["Defecate"] != DBNull.Value)) && (row["Defecate"].ToString() != ""))
                {
                    records_medicine_cn.Defecate = new decimal?(decimal.Parse(row["Defecate"].ToString()));
                }
                if (((row["Defecatedry"] != null) && (row["Defecatedry"] != DBNull.Value)) && (row["Defecatedry"].ToString() != ""))
                {
                    records_medicine_cn.Defecatedry = new decimal?(decimal.Parse(row["Defecatedry"].ToString()));
                }
                if (((row["Tongue"] != null) && (row["Tongue"] != DBNull.Value)) && (row["Tongue"].ToString() != ""))
                {
                    records_medicine_cn.Tongue = new decimal?(decimal.Parse(row["Tongue"].ToString()));
                }
                if (((row["Vein"] != null) && (row["Vein"] != DBNull.Value)) && (row["Vein"].ToString() != ""))
                {
                    records_medicine_cn.Vein = new decimal?(decimal.Parse(row["Vein"].ToString()));
                }
                //if (((row["RecordDate"] != null) && (row["RecordDate"] != DBNull.Value)) && (row["RecordDate"].ToString() != ""))
                //{
                //    records_medicine_cn.RecordDate = new DateTime?(DateTime.Parse(row["RecordDate"].ToString()));
                //}
                if ((row["RecordDate"] != null) && (row["RecordDate"] != DBNull.Value))
                {
                    records_medicine_cn.RecordDate = row["RecordDate"].ToString();
                }

            }
            return records_medicine_cn;
        }
        public bool ISconnectOpen()
        {
            return YcSqliteHelper.ISconnectOpen();
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,IDCardNo,Energy,Tired,Breath,Voice,Emotion,");
            builder.Append("Spirit,Alone,Fear,Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal,Snore,Allergy,Urticaria,");
            builder.Append("Skin,Scratch,Mouth,Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood,Defecate,Defecatedry,");
            builder.Append("Tongue,Vein,RecordDate");
            builder.Append(" FROM tbl_oldermedicinecn ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            return YcSqliteHelper.Query(builder.ToString());

        }
        public DataSet GetMaxList(string strWhere,string conn="")
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,IDCardNo,Energy,Tired,Breath,Voice,Emotion,");
            builder.Append("Spirit,Alone,Fear,Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal,Snore,Allergy,Urticaria,");
            builder.Append("Skin,Scratch,Mouth,Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood,Defecate,Defecatedry,");
            builder.Append("Tongue,Vein,RecordDate");
            builder.Append(" FROM tbl_oldermedicinecn ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append(" GROUP BY IDCardNo,date(RecordDate) ");

            return YcSqliteHelper.Query(builder.ToString(),conn);
        }
        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM tbl_oldermedicinecn ");
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

