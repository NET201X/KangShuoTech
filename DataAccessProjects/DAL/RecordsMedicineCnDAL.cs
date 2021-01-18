using System;
using System.Text;
using MySql.Data.MySqlClient;
using KangShuoTech.Utilities.MySQLHelper;
using System.Data;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.DAL
{
    public class RecordsMedicineCnDAL
    {
        public int Add(RecordsMedicineCnModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_MEDICINE_CN(");
            builder.Append("RecordID,IDCardNo,CustomerID,PhysicalID,Energy,Tired,Breath,Voice,Emotion,Spirit,Alone,Fear,");
            builder.Append("Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal,Snore,Allergy,Urticaria,Skin,Scratch,Mouth,");
            builder.Append("Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood,Defecate,Defecatedry,Tongue,Vein,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,FollowUpDoctor,RecordDate,IsDel)");
            builder.Append(" values (");
            builder.Append("@RecordID,@IDCardNo,@CustomerID,@PhysicalID,@Energy,@Tired,@Breath,@Voice,@Emotion,@Spirit,@Alone,@Fear,");
            builder.Append("@Weight,@Eye,@FootHand,@Stomach,@Cold,@Influenza,@Nasal,@Snore,@Allergy,@Urticaria,@Skin,@Scratch,@Mouth,");
            builder.Append("@Arms,@Greasy,@Spot,@Eczema,@Thirsty,@Smell,@Abdomen,@Coolfood,@Defecate,@Defecatedry,@Tongue,@Vein,");
            builder.Append("@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@FollowUpDoctor,@RecordDate,@IsDel)");
            builder.Append(";select @@IDENTITY");
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
                new MySqlParameter("@IsDel", MySqlDbType.String, 1)
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

            builder.Append("INSERT INTO ARCHIVE_MEDICINE_CN(");
            builder.Append("RecordID,IDCardNo,CustomerID,PhysicalID,Energy,Tired,Breath,Voice,Emotion,Spirit,Alone,Fear,");
            builder.Append("Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal,Snore,Allergy,Urticaria,Skin,Scratch,Mouth,");
            builder.Append("Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood,Defecate,Defecatedry,Tongue,Vein,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,FollowUpDoctor,RecordDate,IsDel)");
            builder.Append(" VALUES (");
            builder.Append("@RecordID,@IDCardNo,@CustomerID,@PhysicalID,@Energy,@Tired,@Breath,@Voice,@Emotion,@Spirit,@Alone,@Fear,");
            builder.Append("@Weight,@Eye,@FootHand,@Stomach,@Cold,@Influenza,@Nasal,@Snore,@Allergy,@Urticaria,@Skin,@Scratch,@Mouth,");
            builder.Append("@Arms,@Greasy,@Spot,@Eczema,@Thirsty,@Smell,@Abdomen,@Coolfood,@Defecate,@Defecatedry,@Tongue,@Vein,");
            builder.Append("@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@FollowUpDoctor,@RecordDate,@IsDel)");
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
                new MySqlParameter("@IsDel", MySqlDbType.String, 1)
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

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_MEDICINE_CN ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,IDCardNo,CustomerID,PhysicalID,Energy,Tired,Breath,Voice,Emotion,Spirit,");
            builder.Append("Alone,Fear,Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal,Snore,Allergy,Urticaria,Skin,Scratch,");
            builder.Append("Mouth,Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood,Defecate,Defecatedry,Tongue,Vein,CreatedBy,");
            builder.Append("CreatedDate,LastUpdateBy,LastUpdateDate,FollowUpDoctor,RecordDate,IsDel from ARCHIVE_MEDICINE_CN ");
            builder.Append(" where ID=@ID  ");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@ID", MySqlDbType.Int32,4)
            };
            cmdParms[0].Value = ID;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }

        public bool Update(RecordsMedicineCnModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_MEDICINE_CN set ");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("PhysicalID=@PhysicalID,");
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
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("RecordDate=@RecordDate,");
            builder.Append("IsDel=@IsDel");
            builder.Append(" where ID=@ID");
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
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
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
            cmdParms[44].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 更新中医体质辨识33个问题项
        /// </summary>
        /// <param name="model"></param>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public bool UpdateByMiniPad(MedicineModel model, string customerID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE ARCHIVE_MEDICINE_CN D SET ");
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
            builder.Append("Vein=@Vein ");
            builder.Append(@" WHERE 
                                EXISTS
                                (
                                    SELECT 
                                        D.ID 
                                    FROM
                                        ARCHIVE_MEDI_PHYS_DIST med 
                                    WHERE D.ID=med.MedicineID
                                        AND med.OutKey=@OutKey
                                ); ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@Energy", model.Energy),
                new MySqlParameter("@Tired", model.Tired),
                new MySqlParameter("@Breath", model.Breath),
                new MySqlParameter("@Voice", model.Voice),
                new MySqlParameter("@Emotion", model.Emotion),
                new MySqlParameter("@Spirit", model.Spirit),
                new MySqlParameter("@Alone", model.Alone),
                new MySqlParameter("@Fear", model.Fear),
                new MySqlParameter("@Weight", model.Weight),
                new MySqlParameter("@Eye", model.Eye),
                new MySqlParameter("@FootHand", model.FootHand),
                new MySqlParameter("@Stomach",model.Stomach),
                new MySqlParameter("@Cold", model.Cold),
                new MySqlParameter("@Influenza", model.Influenza),
                new MySqlParameter("@Nasal", model.Nasal),
                new MySqlParameter("@Snore", model.Snore),
                new MySqlParameter("@Allergy", model.Allergy),
                new MySqlParameter("@Urticaria",model.Urticaria),
                new MySqlParameter("@Skin", model.Skin),
                new MySqlParameter("@Scratch", model.Scratch),
                new MySqlParameter("@Mouth", model.Mouth),
                new MySqlParameter("@Arms", model.Arms),
                new MySqlParameter("@Greasy", model.Greasy),
                new MySqlParameter("@Spot",model.Spot),
                new MySqlParameter("@Eczema", model.Eczema),
                new MySqlParameter("@Thirsty", model.Thirsty),
                new MySqlParameter("@Smell", model.Smell),
                new MySqlParameter("@Abdomen", model.Abdomen),
                new MySqlParameter("@Coolfood", model.Coolfood),
                new MySqlParameter("@Defecate", model.Defecate),
                new MySqlParameter("@Defecatedry", model.Defecatedry),
                new MySqlParameter("@Tongue", model.Tongue),
                new MySqlParameter("@Vein", model.Vein),
                new MySqlParameter("@OutKey", customerID)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 更新体检中 中医体质辨识Key
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool UpdateMediphysDist(string customerID, int ID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE ARCHIVE_MEDI_PHYS_DIST D SET ");
            builder.Append("MedicineID=@MedicineID ");
            builder.Append("WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@MedicineID", ID),
                new MySqlParameter("@OutKey", customerID)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
