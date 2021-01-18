using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsMediPhysDistDAL
    {
        public int Add(RecordsMediPhysDistModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO ARCHIVE_MEDI_PHYS_DIST(");
            builder.Append("PhysicalID,IDCardNo,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QiConstraint,Characteristic,OutKey,MedicineID,MedicineResultID)");
            builder.Append(" VALUES (");
            builder.Append("@PhysicalID,@IDCardNo,@Mild,@Faint,@Yang,@Yin,@PhlegmDamp,@Muggy,@BloodStasis,@QiConstraint,@Characteristic,@OutKey,@MedicineID,@MedicineResultID)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Mild", MySqlDbType.String, 1),
                new MySqlParameter("@Faint", MySqlDbType.String, 1),
                new MySqlParameter("@Yang", MySqlDbType.String, 1),
                new MySqlParameter("@Yin", MySqlDbType.String, 1),
                new MySqlParameter("@PhlegmDamp", MySqlDbType.String, 1),
                new MySqlParameter("@Muggy", MySqlDbType.String, 1),
                new MySqlParameter("@BloodStasis", MySqlDbType.String, 1),
                new MySqlParameter("@QiConstraint", MySqlDbType.String, 1),
                new MySqlParameter("@Characteristic", MySqlDbType.String, 1),
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4),
                new MySqlParameter("@MedicineID", MySqlDbType.Int32, 4),
                new MySqlParameter("@MedicineResultID", MySqlDbType.Int32, 11)
            };

            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Mild;
            cmdParms[3].Value = model.Faint;
            cmdParms[4].Value = model.Yang;
            cmdParms[5].Value = model.Yin;
            cmdParms[6].Value = model.PhlegmDamp;
            cmdParms[7].Value = model.Muggy;
            cmdParms[8].Value = model.BloodStasis;
            cmdParms[9].Value = model.QiConstraint;
            cmdParms[10].Value = model.Characteristic;
            cmdParms[11].Value = model.OutKey;
            cmdParms[12].Value = model.MedicineID;
            cmdParms[13].Value = model.MedicineResultID;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetModelByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_MEDI_PHYS_DIST ");
            builder.Append(" WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32) };
            cmdParms[0].Value = OutKey;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            
            return set;
        }

        public DataSet GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_MEDICINE_CN ");
            builder.Append(" WHERE ID=@ID");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@ID", MySqlDbType.String)
            };
            cmdParms[0].Value = ID;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }

        public DataSet GetResultModel(int ID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM OLD_MEDICINE_RESULT ");
            builder.Append(" WHERE ID=@ID");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@ID", MySqlDbType.String)
            };
            cmdParms[0].Value = ID;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }
    }
}

