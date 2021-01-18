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
    public class HealthHouseMedicineCnDAL
    {
        public int Add(HealthHouseMedicineCnModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into HEALTHHOUSE_MEDICINE_CN(");
            builder.Append("IDCardNo,Energy,Tired,Breath,Voice,Emotion,Spirit,Alone,Fear,");
            builder.Append("Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal,Snore,Allergy,Urticaria,Skin,Scratch,Mouth,");
            builder.Append("Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood,Defecate,Defecatedry,Tongue,Vein,");
            builder.Append("FollowUpDoctor,RecordDate)");
            builder.Append(" values (");
            builder.Append("@IDCardNo,@Energy,@Tired,@Breath,@Voice,@Emotion,@Spirit,@Alone,@Fear,");
            builder.Append("@Weight,@Eye,@FootHand,@Stomach,@Cold,@Influenza,@Nasal,@Snore,@Allergy,@Urticaria,@Skin,@Scratch,@Mouth,");
            builder.Append("@Arms,@Greasy,@Spot,@Eczema,@Thirsty,@Smell,@Abdomen,@Coolfood,@Defecate,@Defecatedry,@Tongue,@Vein,");
            builder.Append("@FollowUpDoctor,@RecordDate)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Energy", MySqlDbType.Decimal), 
                new MySqlParameter("@Tired", MySqlDbType.Decimal), 
                new MySqlParameter("@Breath", MySqlDbType.Decimal), 
                new MySqlParameter("@Voice", MySqlDbType.Decimal),
                new MySqlParameter("@Emotion", MySqlDbType.Decimal), 
                new MySqlParameter("@Spirit", MySqlDbType.Decimal), 
                new MySqlParameter("@Alone", MySqlDbType.Decimal), 
                new MySqlParameter("@Fear", MySqlDbType.Decimal), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@Eye", MySqlDbType.Decimal), 
                new MySqlParameter("@FootHand", MySqlDbType.Decimal), 
                new MySqlParameter("@Stomach", MySqlDbType.Decimal), 
                new MySqlParameter("@Cold", MySqlDbType.Decimal), 
                new MySqlParameter("@Influenza", MySqlDbType.Decimal), 
                new MySqlParameter("@Nasal", MySqlDbType.Decimal), 
                new MySqlParameter("@Snore", MySqlDbType.Decimal), 
                new MySqlParameter("@Allergy", MySqlDbType.Decimal), 
                new MySqlParameter("@Urticaria", MySqlDbType.Decimal), 
                new MySqlParameter("@Skin", MySqlDbType.Decimal), 
                new MySqlParameter("@Scratch", MySqlDbType.Decimal), 
                new MySqlParameter("@Mouth", MySqlDbType.Decimal), 
                new MySqlParameter("@Arms", MySqlDbType.Decimal), 
                new MySqlParameter("@Greasy", MySqlDbType.Decimal), 
                new MySqlParameter("@Spot", MySqlDbType.Decimal), 
                new MySqlParameter("@Eczema", MySqlDbType.Decimal), 
                new MySqlParameter("@Thirsty", MySqlDbType.Decimal), 
                new MySqlParameter("@Smell", MySqlDbType.Decimal), 
                new MySqlParameter("@Abdomen", MySqlDbType.Decimal), 
                new MySqlParameter("@Coolfood", MySqlDbType.Decimal), 
                new MySqlParameter("@Defecate", MySqlDbType.Decimal), 
                new MySqlParameter("@Defecatedry", MySqlDbType.Decimal), 
                new MySqlParameter("@Tongue", MySqlDbType.Decimal), 
                new MySqlParameter("@Vein", MySqlDbType.Decimal), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 20), 
                new MySqlParameter("@RecordDate", MySqlDbType.Date)
             };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Energy;
            cmdParms[2].Value = model.Tired;
            cmdParms[3].Value = model.Breath;
            cmdParms[4].Value = model.Voice;
            cmdParms[5].Value = model.Emotion;
            cmdParms[6].Value = model.Spirit;
            cmdParms[7].Value = model.Alone;
            cmdParms[8].Value = model.Fear;
            cmdParms[9].Value = model.Weight;
            cmdParms[10].Value = model.Eye;
            cmdParms[11].Value = model.FootHand;
            cmdParms[12].Value = model.Stomach;
            cmdParms[13].Value = model.Cold;
            cmdParms[14].Value = model.Influenza;
            cmdParms[15].Value = model.Nasal;
            cmdParms[16].Value = model.Snore;
            cmdParms[17].Value = model.Allergy;
            cmdParms[18].Value = model.Urticaria;
            cmdParms[19].Value = model.Skin;
            cmdParms[20].Value = model.Scratch;
            cmdParms[21].Value = model.Mouth;
            cmdParms[22].Value = model.Arms;
            cmdParms[23].Value = model.Greasy;
            cmdParms[24].Value = model.Spot;
            cmdParms[25].Value = model.Eczema;
            cmdParms[26].Value = model.Thirsty;
            cmdParms[27].Value = model.Smell;
            cmdParms[28].Value = model.Abdomen;
            cmdParms[29].Value = model.Coolfood;
            cmdParms[30].Value = model.Defecate;
            cmdParms[31].Value = model.Defecatedry;
            cmdParms[32].Value = model.Tongue;
            cmdParms[33].Value = model.Vein;
            cmdParms[34].Value = model.FollowUpDoctor;
            cmdParms[35].Value = model.RecordDate; 

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public HealthHouseMedicineCnModel GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,IDCardNo,Energy,Tired,Breath,Voice,Emotion,Spirit,");
            builder.Append("Alone,Fear,Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal,Snore,Allergy,Urticaria,Skin,Scratch,");
            builder.Append("Mouth,Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood,Defecate,Defecatedry,Tongue,Vein,");
            builder.Append("FollowUpDoctor,RecordDate from HEALTHHOUSE_MEDICINE_CN ");
            builder.Append(" where ID=@ID  ");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@ID", MySqlDbType.Int32,4)
            };
            cmdParms[0].Value = ID;
            new RecordsMedicineCnModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public HealthHouseMedicineCnModel DataRowToModel(DataRow row)
        {
            HealthHouseMedicineCnModel hhmedicine = new HealthHouseMedicineCnModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    hhmedicine.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    hhmedicine.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["Energy"] != null) && (row["Energy"] != DBNull.Value)) && (row["Energy"].ToString() != ""))
                {
                    hhmedicine.Energy = new decimal?(decimal.Parse(row["Energy"].ToString()));
                }
                if (((row["Tired"] != null) && (row["Tired"] != DBNull.Value)) && (row["Tired"].ToString() != ""))
                {
                    hhmedicine.Tired = new decimal?(decimal.Parse(row["Tired"].ToString()));
                }
                if (((row["Breath"] != null) && (row["Breath"] != DBNull.Value)) && (row["Breath"].ToString() != ""))
                {
                    hhmedicine.Breath = new decimal?(decimal.Parse(row["Breath"].ToString()));
                }
                if (((row["Voice"] != null) && (row["Voice"] != DBNull.Value)) && (row["Voice"].ToString() != ""))
                {
                    hhmedicine.Voice = new decimal?(decimal.Parse(row["Voice"].ToString()));
                }
                if (((row["Emotion"] != null) && (row["Emotion"] != DBNull.Value)) && (row["Emotion"].ToString() != ""))
                {
                    hhmedicine.Emotion = new decimal?(decimal.Parse(row["Emotion"].ToString()));
                }
                if (((row["Spirit"] != null) && (row["Spirit"] != DBNull.Value)) && (row["Spirit"].ToString() != ""))
                {
                    hhmedicine.Spirit = new decimal?(decimal.Parse(row["Spirit"].ToString()));
                }
                if (((row["Alone"] != null) && (row["Alone"] != DBNull.Value)) && (row["Alone"].ToString() != ""))
                {
                    hhmedicine.Alone = new decimal?(decimal.Parse(row["Alone"].ToString()));
                }
                if (((row["Fear"] != null) && (row["Fear"] != DBNull.Value)) && (row["Fear"].ToString() != ""))
                {
                    hhmedicine.Fear = new decimal?(decimal.Parse(row["Fear"].ToString()));
                }
                if (((row["Weight"] != null) && (row["Weight"] != DBNull.Value)) && (row["Weight"].ToString() != ""))
                {
                    hhmedicine.Weight = new decimal?(decimal.Parse(row["Weight"].ToString()));
                }
                if (((row["Eye"] != null) && (row["Eye"] != DBNull.Value)) && (row["Eye"].ToString() != ""))
                {
                    hhmedicine.Eye = new decimal?(decimal.Parse(row["Eye"].ToString()));
                }
                if (((row["FootHand"] != null) && (row["FootHand"] != DBNull.Value)) && (row["FootHand"].ToString() != ""))
                {
                    hhmedicine.FootHand = new decimal?(decimal.Parse(row["FootHand"].ToString()));
                }
                if (((row["Stomach"] != null) && (row["Stomach"] != DBNull.Value)) && (row["Stomach"].ToString() != ""))
                {
                    hhmedicine.Stomach = new decimal?(decimal.Parse(row["Stomach"].ToString()));
                }
                if (((row["Cold"] != null) && (row["Cold"] != DBNull.Value)) && (row["Cold"].ToString() != ""))
                {
                    hhmedicine.Cold = new decimal?(decimal.Parse(row["Cold"].ToString()));
                }
                if (((row["Influenza"] != null) && (row["Influenza"] != DBNull.Value)) && (row["Influenza"].ToString() != ""))
                {
                    hhmedicine.Influenza = new decimal?(decimal.Parse(row["Influenza"].ToString()));
                }
                if (((row["Nasal"] != null) && (row["Nasal"] != DBNull.Value)) && (row["Nasal"].ToString() != ""))
                {
                    hhmedicine.Nasal = new decimal?(decimal.Parse(row["Nasal"].ToString()));
                }
                if (((row["Snore"] != null) && (row["Snore"] != DBNull.Value)) && (row["Snore"].ToString() != ""))
                {
                    hhmedicine.Snore = new decimal?(decimal.Parse(row["Snore"].ToString()));
                }
                if (((row["Allergy"] != null) && (row["Allergy"] != DBNull.Value)) && (row["Allergy"].ToString() != ""))
                {
                    hhmedicine.Allergy = new decimal?(decimal.Parse(row["Allergy"].ToString()));
                }
                if (((row["Urticaria"] != null) && (row["Urticaria"] != DBNull.Value)) && (row["Urticaria"].ToString() != ""))
                {
                    hhmedicine.Urticaria = new decimal?(decimal.Parse(row["Urticaria"].ToString()));
                }
                if (((row["Skin"] != null) && (row["Skin"] != DBNull.Value)) && (row["Skin"].ToString() != ""))
                {
                    hhmedicine.Skin = new decimal?(decimal.Parse(row["Skin"].ToString()));
                }
                if (((row["Scratch"] != null) && (row["Scratch"] != DBNull.Value)) && (row["Scratch"].ToString() != ""))
                {
                    hhmedicine.Scratch = new decimal?(decimal.Parse(row["Scratch"].ToString()));
                }
                if (((row["Mouth"] != null) && (row["Mouth"] != DBNull.Value)) && (row["Mouth"].ToString() != ""))
                {
                    hhmedicine.Mouth = new decimal?(decimal.Parse(row["Mouth"].ToString()));
                }
                if (((row["Arms"] != null) && (row["Arms"] != DBNull.Value)) && (row["Arms"].ToString() != ""))
                {
                    hhmedicine.Arms = new decimal?(decimal.Parse(row["Arms"].ToString()));
                }
                if (((row["Greasy"] != null) && (row["Greasy"] != DBNull.Value)) && (row["Greasy"].ToString() != ""))
                {
                    hhmedicine.Greasy = new decimal?(decimal.Parse(row["Greasy"].ToString()));
                }
                if (((row["Spot"] != null) && (row["Spot"] != DBNull.Value)) && (row["Spot"].ToString() != ""))
                {
                    hhmedicine.Spot = new decimal?(decimal.Parse(row["Spot"].ToString()));
                }
                if (((row["Eczema"] != null) && (row["Eczema"] != DBNull.Value)) && (row["Eczema"].ToString() != ""))
                {
                    hhmedicine.Eczema = new decimal?(decimal.Parse(row["Eczema"].ToString()));
                }
                if (((row["Thirsty"] != null) && (row["Thirsty"] != DBNull.Value)) && (row["Thirsty"].ToString() != ""))
                {
                    hhmedicine.Thirsty = new decimal?(decimal.Parse(row["Thirsty"].ToString()));
                }
                if (((row["Smell"] != null) && (row["Smell"] != DBNull.Value)) && (row["Smell"].ToString() != ""))
                {
                    hhmedicine.Smell = new decimal?(decimal.Parse(row["Smell"].ToString()));
                }
                if (((row["Abdomen"] != null) && (row["Abdomen"] != DBNull.Value)) && (row["Abdomen"].ToString() != ""))
                {
                    hhmedicine.Abdomen = new decimal?(decimal.Parse(row["Abdomen"].ToString()));
                }
                if (((row["Coolfood"] != null) && (row["Coolfood"] != DBNull.Value)) && (row["Coolfood"].ToString() != ""))
                {
                    hhmedicine.Coolfood = new decimal?(decimal.Parse(row["Coolfood"].ToString()));
                }
                if (((row["Defecate"] != null) && (row["Defecate"] != DBNull.Value)) && (row["Defecate"].ToString() != ""))
                {
                    hhmedicine.Defecate = new decimal?(decimal.Parse(row["Defecate"].ToString()));
                }
                if (((row["Defecatedry"] != null) && (row["Defecatedry"] != DBNull.Value)) && (row["Defecatedry"].ToString() != ""))
                {
                    hhmedicine.Defecatedry = new decimal?(decimal.Parse(row["Defecatedry"].ToString()));
                }
                if (((row["Tongue"] != null) && (row["Tongue"] != DBNull.Value)) && (row["Tongue"].ToString() != ""))
                {
                    hhmedicine.Tongue = new decimal?(decimal.Parse(row["Tongue"].ToString()));
                }
                if (((row["Vein"] != null) && (row["Vein"] != DBNull.Value)) && (row["Vein"].ToString() != ""))
                {
                    hhmedicine.Vein = new decimal?(decimal.Parse(row["Vein"].ToString()));
                }
                if ((row["FollowUpDoctor"] != null) && (row["FollowUpDoctor"] != DBNull.Value))
                {
                    hhmedicine.FollowUpDoctor = row["FollowUpDoctor"].ToString();
                }
                if (((row["RecordDate"] != null) && (row["RecordDate"] != DBNull.Value)) && (row["RecordDate"].ToString() != ""))
                {
                    hhmedicine.RecordDate = new DateTime?(DateTime.Parse(row["RecordDate"].ToString()));
                }
            }
            return hhmedicine;
        }
        public bool Update(HealthHouseMedicineCnModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update HEALTHHOUSE_MEDICINE_CN set ");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Energy=@Energy,");
            builder.Append("Tired=@Tired,");
            builder.Append("Breath=@Breath,");
            builder.Append("Voice=@Voice,");
            builder.Append("Emotion=@Emotion,");
            builder.Append("Spirit=@Spirit,");
            builder.Append("Alone=@Alone,");
            builder.Append("Fear=@Fear,");
            builder.Append("Weight=@Weight,");
            builder.Append("Eye=@Eye,");
            builder.Append("FootHand=@FootHand,");
            builder.Append("Stomach=@Stomach,");
            builder.Append("Cold=@Cold,");
            builder.Append("Influenza=@Influenza,");
            builder.Append("Nasal=@Nasal,");
            builder.Append("Snore=@Snore,");
            builder.Append("Allergy=@Allergy,");
            builder.Append("Urticaria=@Urticaria,");
            builder.Append("Skin=@Skin,");
            builder.Append("Scratch=@Scratch,");
            builder.Append("Mouth=@Mouth,");
            builder.Append("Arms=@Arms,");
            builder.Append("Greasy=@Greasy,");
            builder.Append("Spot=@Spot,");
            builder.Append("Eczema=@Eczema,");
            builder.Append("Thirsty=@Thirsty,");
            builder.Append("Smell=@Smell,");
            builder.Append("Abdomen=@Abdomen,");
            builder.Append("Coolfood=@Coolfood,");
            builder.Append("Defecate=@Defecate,");
            builder.Append("Defecatedry=@Defecatedry,");
            builder.Append("Tongue=@Tongue,");
            builder.Append("Vein=@Vein,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("RecordDate=@RecordDate ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Energy", MySqlDbType.Decimal),
                new MySqlParameter("@Tired", MySqlDbType.Decimal),
                new MySqlParameter("@Breath", MySqlDbType.Decimal),
                new MySqlParameter("@Voice", MySqlDbType.Decimal),
                new MySqlParameter("@Emotion", MySqlDbType.Decimal),
                new MySqlParameter("@Spirit", MySqlDbType.Decimal),
                new MySqlParameter("@Alone", MySqlDbType.Decimal),
                new MySqlParameter("@Fear", MySqlDbType.Decimal),
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@Eye", MySqlDbType.Decimal),
                new MySqlParameter("@FootHand", MySqlDbType.Decimal), 
                new MySqlParameter("@Stomach", MySqlDbType.Decimal), 
                new MySqlParameter("@Cold", MySqlDbType.Decimal),
                new MySqlParameter("@Influenza", MySqlDbType.Decimal),
                new MySqlParameter("@Nasal", MySqlDbType.Decimal),
                new MySqlParameter("@Snore", MySqlDbType.Decimal), 
                new MySqlParameter("@Allergy", MySqlDbType.Decimal),
                new MySqlParameter("@Urticaria", MySqlDbType.Decimal),
                new MySqlParameter("@Skin", MySqlDbType.Decimal),
                new MySqlParameter("@Scratch", MySqlDbType.Decimal), 
                new MySqlParameter("@Mouth", MySqlDbType.Decimal),
                new MySqlParameter("@Arms", MySqlDbType.Decimal), 
                new MySqlParameter("@Greasy", MySqlDbType.Decimal), 
                new MySqlParameter("@Spot", MySqlDbType.Decimal), 
                new MySqlParameter("@Eczema", MySqlDbType.Decimal), 
                new MySqlParameter("@Thirsty", MySqlDbType.Decimal),
                new MySqlParameter("@Smell", MySqlDbType.Decimal),
                new MySqlParameter("@Abdomen", MySqlDbType.Decimal), 
                new MySqlParameter("@Coolfood", MySqlDbType.Decimal),
                new MySqlParameter("@Defecate", MySqlDbType.Decimal),
                new MySqlParameter("@Defecatedry", MySqlDbType.Decimal),
                new MySqlParameter("@Tongue", MySqlDbType.Decimal), 
                new MySqlParameter("@Vein", MySqlDbType.Decimal),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 20),
                new MySqlParameter("@RecordDate", MySqlDbType.Date), 
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Energy;
            cmdParms[2].Value = model.Tired;
            cmdParms[3].Value = model.Breath;
            cmdParms[4].Value = model.Voice;
            cmdParms[5].Value = model.Emotion;
            cmdParms[6].Value = model.Spirit;
            cmdParms[7].Value = model.Alone;
            cmdParms[8].Value = model.Fear;
            cmdParms[9].Value = model.Weight;
            cmdParms[10].Value = model.Eye;
            cmdParms[11].Value = model.FootHand;
            cmdParms[12].Value = model.Stomach;
            cmdParms[13].Value = model.Cold;
            cmdParms[14].Value = model.Influenza;
            cmdParms[15].Value = model.Nasal;
            cmdParms[16].Value = model.Snore;
            cmdParms[17].Value = model.Allergy;
            cmdParms[18].Value = model.Urticaria;
            cmdParms[19].Value = model.Skin;
            cmdParms[20].Value = model.Scratch;
            cmdParms[21].Value = model.Mouth;
            cmdParms[22].Value = model.Arms;
            cmdParms[23].Value = model.Greasy;
            cmdParms[24].Value = model.Spot;
            cmdParms[25].Value = model.Eczema;
            cmdParms[26].Value = model.Thirsty;
            cmdParms[27].Value = model.Smell;
            cmdParms[28].Value = model.Abdomen;
            cmdParms[29].Value = model.Coolfood;
            cmdParms[30].Value = model.Defecate;
            cmdParms[31].Value = model.Defecatedry;
            cmdParms[32].Value = model.Tongue;
            cmdParms[33].Value = model.Vein;
            cmdParms[34].Value = model.FollowUpDoctor;
            cmdParms[35].Value = model.RecordDate;
            cmdParms[36].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from HEALTHHOUSE_MEDICINE_CN ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
