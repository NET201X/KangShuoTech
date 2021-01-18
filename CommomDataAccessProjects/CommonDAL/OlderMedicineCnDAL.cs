using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class OlderMedicineCnDAL
    {
        public int Add(MedicineModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO OLD_MEDICINE_CN(");
            builder.Append("RecordID,IDCardNo,CustomerID,PhysicalID,Energy,Tired,Breath,Voice,Emotion,Spirit,Alone,Fear,");
            builder.Append("Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal,Snore,Allergy,Urticaria,Skin,Scratch,Mouth,");
            builder.Append("Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood,Defecate,Defecatedry,Tongue,Vein,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,RecordDate,IsDel");

            if (VersionNo.Contains("3.0")) builder.Append(" ,VisitDoctor)");
            else builder.Append(" ,FollowUpDoctor,Outkey)");

            builder.Append(" VALUES (");
            builder.Append("@RecordID,@IDCardNo,@CustomerID,@PhysicalID,@Energy,@Tired,@Breath,@Voice,@Emotion,@Spirit,@Alone,@Fear,");
            builder.Append("@Weight,@Eye,@FootHand,@Stomach,@Cold,@Influenza,@Nasal,@Snore,@Allergy,@Urticaria,@Skin,@Scratch,@Mouth,");
            builder.Append("@Arms,@Greasy,@Spot,@Eczema,@Thirsty,@Smell,@Abdomen,@Coolfood,@Defecate,@Defecatedry,@Tongue,@Vein,");
            builder.Append("@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@RecordDate,@IsDel,@FollowUpDoctor");

            if (VersionNo.Contains("3.0")) builder.Append(" )");
            else builder.Append(" ,@Outkey)");

            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@CustomerID", MySqlDbType.String, 17),
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 17),
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
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 20),
                new MySqlParameter("@RecordDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@Outkey", MySqlDbType.Int32, 11)
            };

            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.CustomerID;
            cmdParms[3].Value = model.PhysicalID;
            cmdParms[4].Value = model.Energy;
            cmdParms[5].Value = model.Tired;
            cmdParms[6].Value = model.Breath;
            cmdParms[7].Value = model.Voice;
            cmdParms[8].Value = model.Emotion;
            cmdParms[9].Value = model.Spirit;
            cmdParms[10].Value = model.Alone;
            cmdParms[11].Value = model.Fear;
            cmdParms[12].Value = model.Weight;
            cmdParms[13].Value = model.Eye;
            cmdParms[14].Value = model.FootHand;
            cmdParms[15].Value = model.Stomach;
            cmdParms[16].Value = model.Cold;
            cmdParms[17].Value = model.Influenza;
            cmdParms[18].Value = model.Nasal;
            cmdParms[19].Value = model.Snore;
            cmdParms[20].Value = model.Allergy;
            cmdParms[21].Value = model.Urticaria;
            cmdParms[22].Value = model.Skin;
            cmdParms[23].Value = model.Scratch;
            cmdParms[24].Value = model.Mouth;
            cmdParms[25].Value = model.Arms;
            cmdParms[26].Value = model.Greasy;
            cmdParms[27].Value = model.Spot;
            cmdParms[28].Value = model.Eczema;
            cmdParms[29].Value = model.Thirsty;
            cmdParms[30].Value = model.Smell;
            cmdParms[31].Value = model.Abdomen;
            cmdParms[32].Value = model.Coolfood;
            cmdParms[33].Value = model.Defecate;
            cmdParms[34].Value = model.Defecatedry;
            cmdParms[35].Value = model.Tongue;
            cmdParms[36].Value = model.Vein;
            cmdParms[37].Value = model.CreatedBy;
            cmdParms[38].Value = model.CreatedDate;
            cmdParms[39].Value = model.LastUpdateBy;
            cmdParms[40].Value = model.LastUpdateDate;
            cmdParms[41].Value = model.FollowUpDoctor;
            cmdParms[42].Value = model.RecordDate;
            cmdParms[43].Value = model.IsDel;
            cmdParms[44].Value = model.OutKey;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public bool Update(MedicineModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE OLD_MEDICINE_CN SET ");
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
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate");
            if (VersionNo.Contains("V3.0"))
            {
                builder.Append(" WHERE RecordDate=@RecordDate");
                builder.Append(" AND IDCardNo=@IDCardNo");
            }
            else
                builder.Append(" WHERE Outkey=@Outkey");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
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
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@Outkey", MySqlDbType.Int32, 11),
                new MySqlParameter("@RecordDate", MySqlDbType.Date),
                new MySqlParameter("@IDCardNo", MySqlDbType.VarChar, 100)
            };

            cmdParms[0].Value = model.Energy;
            cmdParms[1].Value = model.Tired;
            cmdParms[2].Value = model.Breath;
            cmdParms[3].Value = model.Voice;
            cmdParms[4].Value = model.Emotion;
            cmdParms[5].Value = model.Spirit;
            cmdParms[6].Value = model.Alone;
            cmdParms[7].Value = model.Fear;
            cmdParms[8].Value = model.Weight;
            cmdParms[9].Value = model.Eye;
            cmdParms[10].Value = model.FootHand;
            cmdParms[11].Value = model.Stomach;
            cmdParms[12].Value = model.Cold;
            cmdParms[13].Value = model.Influenza;
            cmdParms[14].Value = model.Nasal;
            cmdParms[15].Value = model.Snore;
            cmdParms[16].Value = model.Allergy;
            cmdParms[17].Value = model.Urticaria;
            cmdParms[18].Value = model.Skin;
            cmdParms[19].Value = model.Scratch;
            cmdParms[20].Value = model.Mouth;
            cmdParms[21].Value = model.Arms;
            cmdParms[22].Value = model.Greasy;
            cmdParms[23].Value = model.Spot;
            cmdParms[24].Value = model.Eczema;
            cmdParms[25].Value = model.Thirsty;
            cmdParms[26].Value = model.Smell;
            cmdParms[27].Value = model.Abdomen;
            cmdParms[28].Value = model.Coolfood;
            cmdParms[29].Value = model.Defecate;
            cmdParms[30].Value = model.Defecatedry;
            cmdParms[31].Value = model.Tongue;
            cmdParms[32].Value = model.Vein;
            cmdParms[33].Value = model.LastUpdateBy;
            cmdParms[34].Value = model.LastUpdateDate;
            cmdParms[35].Value = model.OutKey;
            cmdParms[36].Value = model.RecordDate;
            cmdParms[37].Value = model.IDCardNo;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet GetModel(int OutKey, string IDCardNo, string RecordDate, string Version)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM OLD_MEDICINE_CN ");
            builder.Append(" WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@OutKey", MySqlDbType.Int32)
            };

            cmdParms[0].Value = OutKey;

            if (Version.Contains("V3.0"))
            {
                builder.Clear();
                builder.Append("SELECT * FROM OLD_MEDICINE_CN ");
                builder.Append(" WHERE RecordDate=@RecordDate AND IDCardNo=@IDCardNo");

                cmdParms = new MySqlParameter[] {
                     new MySqlParameter("@RecordDate", MySqlDbType.Date),
                     new MySqlParameter("@IDCardNo", MySqlDbType.VarChar,100)
                };

                cmdParms[0].Value = RecordDate;
                cmdParms[1].Value = IDCardNo;
            }

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        public DataSet GetMaxModel(string IDCardNo, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM OLD_MEDICINE_CN ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            if (CheckDate != "") builder.Append("AND RecordDate=@RecordDate");

            builder.Append(" ORDER BY RecordDate DESC LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@RecordDate", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = CheckDate;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 2.0版本取中医体质及体质结果
        /// </summary>
        /// <param name="outKey"></param>
        /// <returns></returns>
        public DataSet GetModelByKey(int outKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM OLD_MEDICINE_CN Cn ");
            builder.Append("LEFT JOIN OLD_MEDICINE_RESULT Result ");
            builder.Append("ON Result.OutKey=Cn.OutKey ");
            builder.Append("AND Result.IDCardNo=Cn.IDCardNo ");
            builder.Append(" WHERE Cn.OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@OutKey", MySqlDbType.Int32)
            };

            cmdParms[0].Value = outKey;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 3.0版本取最后一次中医体质及体质结果
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <returns></returns>
        public DataSet GetAllModel(string IDCardNo, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM OLD_MEDICINE_CN Cn ");
            builder.Append(" LEFT JOIN OLD_MEDICINE_RESULT Result ");
            builder.Append(" ON Result.MedicineID=Cn.ID ");
            builder.Append(" AND Result.IDCardNo=Cn.IDCardNo ");
            builder.Append(" WHERE Cn.IDCardNo=@IDCardNo ");

            if (CheckDate != "") builder.Append("AND Cn.RecordDate=@RecordDate");

            builder.Append(" ORDER BY Cn.RecordDate DESC LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@RecordDate", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = CheckDate;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 本季度是否有随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetDataCount(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT COUNT(0) FROM OLD_MEDICINE_CN ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");
            builder.Append(" AND YEAR(RecordDate)=YEAR(NOW())");
            builder.Append(" AND QUARTER(RecordDate) = QUARTER(NOW())");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }
    }
}
