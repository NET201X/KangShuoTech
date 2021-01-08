namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class OlderMedicineCnDAL
    {
        public int Add(OlderMedicineCnModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_oldermedicinecn(");
            builder.Append("RecordID,IDCardNo,CustomerID,PhysicalID,Energy,Tired,Breath,Voice,Emotion,Spirit,Alone,Fear,");
            builder.Append("Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal,Snore,Allergy,Urticaria,Skin,Scratch,Mouth,");
            builder.Append("Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood,Defecate,Defecatedry,Tongue,Vein,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,FollowUpDoctor,RecordDate,IsDel,OUTkey)");
            builder.Append(" values (");
            builder.Append("@RecordID,@IDCardNo,@CustomerID,@PhysicalID,@Energy,@Tired,@Breath,@Voice,@Emotion,@Spirit,@Alone,@Fear,");
            builder.Append("@Weight,@Eye,@FootHand,@Stomach,@Cold,@Influenza,@Nasal,@Snore,@Allergy,@Urticaria,@Skin,@Scratch,@Mouth,");
            builder.Append("@Arms,@Greasy,@Spot,@Eczema,@Thirsty,@Smell,@Abdomen,@Coolfood,@Defecate,@Defecatedry,@Tongue,@Vein,");
            builder.Append("@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@FollowUpDoctor,@RecordDate,@IsDel,@OUTkey)");
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
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@OUTkey", MySqlDbType.Int32, 11)
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
            cmdParms[44].Value = model.OUTkey;
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

            builder.Append("INSERT INTO tbl_oldermedicinecn(");
            builder.Append("RecordID,IDCardNo,CustomerID,PhysicalID,Energy,Tired,Breath,Voice,Emotion,Spirit,Alone,Fear,");
            builder.Append("Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal,Snore,Allergy,Urticaria,Skin,Scratch,Mouth,");
            builder.Append("Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood,Defecate,Defecatedry,Tongue,Vein,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,FollowUpDoctor,RecordDate,IsDel,OUTkey)");
            builder.Append(" VALUES (");
            builder.Append("@RecordID,@IDCardNo,@CustomerID,@PhysicalID,@Energy,@Tired,@Breath,@Voice,@Emotion,@Spirit,@Alone,@Fear,");
            builder.Append("@Weight,@Eye,@FootHand,@Stomach,@Cold,@Influenza,@Nasal,@Snore,@Allergy,@Urticaria,@Skin,@Scratch,@Mouth,");
            builder.Append("@Arms,@Greasy,@Spot,@Eczema,@Thirsty,@Smell,@Abdomen,@Coolfood,@Defecate,@Defecatedry,@Tongue,@Vein,");
            builder.Append("@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@FollowUpDoctor,@RecordDate,@IsDel,@OUTkey)");
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
                new MySqlParameter("@OUTkey", MySqlDbType.Int32, 11)
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

        public bool DelOUTkey(int OUTkey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_oldermedicinecn ");
            builder.Append(" where OUTkey=@OUTkey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OUTkey", MySqlDbType.Int32, 11) };
            cmdParms[0].Value = OUTkey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool ExistOutKey(int OUTkey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_oldermedicinecn");
            builder.Append(" where OUTkey=@OUTkey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OUTkey", MySqlDbType.Int32, 11) };
            cmdParms[0].Value = OUTkey;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,IDCardNo,CustomerID,PhysicalID,OUTkey,Energy,Tired,Breath,Voice,Emotion,");
            builder.Append("Spirit,Alone,Fear,Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal,Snore,Allergy,Urticaria,");
            builder.Append("Skin,Scratch,Mouth,Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood,Defecate,Defecatedry,");
            builder.Append("Tongue,Vein,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,FollowUpDoctor,RecordDate,IsDel");
            builder.Append(" FROM tbl_oldermedicinecn ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by ID desc limit 0,1");
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetModel(string IDCardNo, int OUTKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,IDCardNo,CustomerID,PhysicalID,OUTkey,Energy,Tired,Breath,Voice,Emotion,Spirit,");
            builder.Append("Alone,Fear,Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal,Snore,Allergy,Urticaria,Skin,Scratch,");
            builder.Append("Mouth,Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood,Defecate,Defecatedry,Tongue,Vein,CreatedBy,");
            builder.Append("CreatedDate,LastUpdateBy,LastUpdateDate,FollowUpDoctor,RecordDate,IsDel from tbl_oldermedicinecn ");
            builder.Append(" where IDCardNo=@IDCardNo and OUTkey = @OUTkey ");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@OUTkey", MySqlDbType.Int32 ,11)
            };
            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = OUTKey;
            return MySQLHelper.Query(builder.ToString(), cmdParms);

        }

        public DataSet GetModelOUTKey(int OUtkey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,IDCardNo,CustomerID,PhysicalID,Energy,Tired,Breath,Voice,Emotion,Spirit,");
            builder.Append("Alone,Fear,Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal,Snore,Allergy,Urticaria,Skin,Scratch,");
            builder.Append("Mouth,Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood,Defecate,Defecatedry,Tongue,Vein,CreatedBy,");
            builder.Append("CreatedDate,LastUpdateBy,LastUpdateDate,FollowUpDoctor,RecordDate,IsDel,OUTkey ");
            builder.Append("from tbl_oldermedicinecn ");
            builder.Append(" where OUTkey=@OUTkey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OUTkey", MySqlDbType.Int32, 11) };
            cmdParms[0].Value = OUtkey;
            return MySQLHelper.Query(builder.ToString(), cmdParms);

        }

        public bool Update(OlderMedicineCnModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_oldermedicinecn set ");
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
            builder.Append(" where OUTkey=@OUTkey");
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
                new MySqlParameter("@OUTkey", MySqlDbType.Int32, 8)
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
            cmdParms[44].Value = model.OUTkey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Update(MedicineModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE tbl_oldermedicinecn SET ");
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
                new MySqlParameter("@Outkey", MySqlDbType.Int32, 11)
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

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

