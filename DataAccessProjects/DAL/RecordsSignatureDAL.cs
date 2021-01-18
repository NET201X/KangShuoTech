
namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsSignatureDAL
    {
        public int Add(RecordsSignatureModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("INSERT INTO ARCHIVE_SIGNATURE(");
            builder.Append("PhysicalID,IDCardNo,SymptomSn,GeneralConditionSn,LifeStyleSn,OrgansFunctionSn,PEyebseSn,PSkinSn,");
            builder.Append("PDigtalExamSn,PBreastSn,PGynecologySn,PhysicalQtSn,ABloodRoutineSn,AMAUSn,AECGSn,AChestXraySn,");
            builder.Append("ABtypeUltrasonicSn,ABtypeQtSn,ASmearSn,AssistQtSn,InpatientCareSn,DrugNonimmunitySn,HealthAssessmentSn,");
            builder.Append("HealthGuidanceSn,SelfSn,DependentSn,PersonalFb,DoctorSn,FeedbackDate,OutKey,BloodLiverKidneySn,ExamineDoctor,ECGExamineDoctor,PhysiqueSn)");
            builder.Append(" VALUES (");
            builder.Append("@PhysicalID,@IDCardNo,@SymptomSn,@GeneralConditionSn,@LifeStyleSn,@OrgansFunctionSn,@PEyebseSn,");
            builder.Append("@PSkinSn,@PDigtalExamSn,@PBreastSn,@PGynecologySn,@PhysicalQtSn,@ABloodRoutineSn,@AMAUSn,@AECGSn,");
            builder.Append("@AChestXraySn,@ABtypeUltrasonicSn,@ABtypeQtSn,@ASmearSn,@AssistQtSn,@InpatientCareSn,");
            builder.Append("@DrugNonimmunitySn,@HealthAssessmentSn,@HealthGuidanceSn,@SelfSn,@DependentSn,@PersonalFb,");
            builder.Append("@DoctorSn,@FeedbackDate,@OutKey,@BloodLiverKidneySn,@ExamineDoctor,@ECGExamineDoctor,@PhysiqueSn)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@SymptomSn", MySqlDbType.String,100),
                new MySqlParameter("@GeneralConditionSn", MySqlDbType.String,100),
                new MySqlParameter("@LifeStyleSn", MySqlDbType.String,100),
                new MySqlParameter("@OrgansFunctionSn", MySqlDbType.String,100),
                new MySqlParameter("@PEyebseSn", MySqlDbType.String, 100),
                new MySqlParameter("@PSkinSn", MySqlDbType.String, 100),
                new MySqlParameter("@PDigtalExamSn", MySqlDbType.String, 100),
                new MySqlParameter("@PBreastSn", MySqlDbType.String, 100),
                new MySqlParameter("@PGynecologySn", MySqlDbType.String,100),
                new MySqlParameter("@PhysicalQtSn", MySqlDbType.String, 100),
                new MySqlParameter("@ABloodRoutineSn", MySqlDbType.String,100),
                new MySqlParameter("@AMAUSn", MySqlDbType.String, 100),
                new MySqlParameter("@AECGSn", MySqlDbType.String,100),
                new MySqlParameter("@AChestXraySn", MySqlDbType.String, 100),
                new MySqlParameter("@ABtypeUltrasonicSn", MySqlDbType.String,100),
                new MySqlParameter("@ABtypeQtSn", MySqlDbType.String,100),
                new MySqlParameter("@ASmearSn", MySqlDbType.String,100),
                new MySqlParameter("@AssistQtSn", MySqlDbType.String,100),
                new MySqlParameter("@InpatientCareSn", MySqlDbType.String,100),
                new MySqlParameter("@DrugNonimmunitySn", MySqlDbType.String,100),
                new MySqlParameter("@HealthAssessmentSn", MySqlDbType.String,100),
                new MySqlParameter("@HealthGuidanceSn", MySqlDbType.String,100),
                new MySqlParameter("@SelfSn", MySqlDbType.String,100),
                new MySqlParameter("@DependentSn", MySqlDbType.String,100),
                new MySqlParameter("@PersonalFb", MySqlDbType.String),
                new MySqlParameter("@DoctorSn", MySqlDbType.String),
                new MySqlParameter("@FeedbackDate", MySqlDbType.Date),
                new MySqlParameter("@BloodLiverKidneySn",MySqlDbType.String),
                new MySqlParameter("@OutKey",MySqlDbType.Int32,4),
                new MySqlParameter("@ExamineDoctor",MySqlDbType.VarChar,20),
                new MySqlParameter("@ECGExamineDoctor",MySqlDbType.VarChar,20),
                new MySqlParameter("@PhysiqueSn",MySqlDbType.VarChar,20)
            };

            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.SymptomSn;
            cmdParms[3].Value = model.GeneralConditionSn;
            cmdParms[4].Value = model.LifeStyleSn;
            cmdParms[5].Value = model.OrgansFunctionSn;
            cmdParms[6].Value = model.PEyebseSn;
            cmdParms[7].Value = model.PSkinSn;
            cmdParms[8].Value = model.PDigtalExamSn;
            cmdParms[9].Value = model.PBreastSn;
            cmdParms[10].Value = model.PGynecologySn;
            cmdParms[11].Value = model.PhysicalQtSn;
            cmdParms[12].Value = model.ABloodRoutineSn;
            cmdParms[13].Value = model.AMAUSn;
            cmdParms[14].Value = model.AECGSn;
            cmdParms[15].Value = model.AChestXraySn;
            cmdParms[16].Value = model.ABtypeUltrasonicSn;
            cmdParms[17].Value = model.ABtypeQtSn;
            cmdParms[18].Value = model.ASmearSn;
            cmdParms[19].Value = model.AssistQtSn;
            cmdParms[20].Value = model.InpatientCareSn;
            cmdParms[21].Value = model.DrugNonimmunitySn;
            cmdParms[22].Value = model.HealthAssessmentSn;
            cmdParms[23].Value = model.HealthGuidanceSn;
            cmdParms[24].Value = model.SelfSn;
            cmdParms[25].Value = model.DependentSn;
            cmdParms[26].Value = model.PersonalFb;
            cmdParms[27].Value = model.DoctorSn;
            cmdParms[28].Value = model.FeedbackDate;
            cmdParms[29].Value = model.BloodLiverKidneySn;
            cmdParms[30].Value = model.ExamineDoctor;
            cmdParms[31].Value = model.ECGExamineDoctor;
            cmdParms[32].Value = model.PhysiqueSn;

            if (model.OutKey == 0) cmdParms[0].Value = DBNull.Value;
            else cmdParms[30].Value = model.OutKey;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_SIGNATURE ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_SIGNATURE ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_SIGNATURE");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,SymptomSn,GeneralConditionSn,LifeStyleSn,OrgansFunctionSn,PEyebseSn,PSkinSn,PDigtalExamSn,PBreastSn, ");
            builder.Append("PGynecologySn,PhysicalQtSn,ABloodRoutineSn,AMAUSn,AECGSn,AChestXraySn,ABtypeUltrasonicSn,ABtypeQtSn,ASmearSn,AssistQtSn,");
            builder.Append("InpatientCareSn,DrugNonimmunitySn,HealthAssessmentSn,HealthGuidanceSn,SelfSn,DependentSn,PersonalFb,FeedbackDate,OutKey,BloodLiverKidneySn,ExamineDoctor,ECGExamineDoctor,PhysiqueSn ");
            builder.Append(" FROM ARCHIVE_SIGNATURE ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM ( ");
            builder.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }
            builder.Append(")AS Row, T.*  from ARCHIVE_SIGNATURE T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("ID", "ARCHIVE_SIGNATURE");
        }

        public DataSet GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT ID,PhysicalID,IDCardNo,SymptomSn,GeneralConditionSn,LifeStyleSn,OrgansFunctionSn,PEyebseSn, ");
            builder.Append("PSkinSn,PDigtalExamSn,PBreastSn,PGynecologySn,PhysicalQtSn,ABloodRoutineSn,AMAUSn,AECGSn,AChestXraySn,");
            builder.Append("ABtypeUltrasonicSn,ABtypeQtSn,ASmearSn,AssistQtSn,InpatientCareSn,DrugNonimmunitySn,HealthAssessmentSn, ");
            builder.Append("HealthGuidanceSn,SelfSn,DependentSn,PersonalFb,DoctorSn,FeedbackDate,OutKey,BloodLiverKidneySn,ExamineDoctor,ECGExamineDoctor,PhysiqueSn ");
            builder.Append(" FROM ARCHIVE_SIGNATURE ");
            builder.Append(" WHERE IDCardNo=@IDCardNo");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM ARCHIVE_SIGNATURE ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public DataSet GetModelByOutKey(int OutKey, string IdCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT ID,PhysicalID,IDCardNo,SymptomSn,GeneralConditionSn,LifeStyleSn,OrgansFunctionSn,PEyebseSn, ");
            builder.Append("PSkinSn,PDigtalExamSn,PBreastSn,PGynecologySn,PhysicalQtSn,ABloodRoutineSn,AMAUSn,AECGSn,AChestXraySn,");
            builder.Append("ABtypeUltrasonicSn,ABtypeQtSn,ASmearSn,AssistQtSn,InpatientCareSn,DrugNonimmunitySn,HealthAssessmentSn, ");
            builder.Append("HealthGuidanceSn,SelfSn,DependentSn,PersonalFb,DoctorSn,FeedbackDate,OutKey,BloodLiverKidneySn,ExamineDoctor,ECGExamineDoctor,PhysiqueSn ");
            builder.Append("FROM ARCHIVE_SIGNATURE ");
            builder.Append("WHERE IdCardNo=@IdCardNo ");

            if (OutKey == 0) builder.Append(" AND OutKey IS NULL ");
            else builder.Append(" AND OutKey=@OutKey ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@OutKey", MySqlDbType.String),
                new MySqlParameter("@IdCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = OutKey;
            cmdParms[1].Value = IdCardNo;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }

        public bool ExistsOutKey(string IDCardNo, int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_SIGNATURE");
            builder.Append(" where IDCardNo=@IDCardNo ");
            builder.Append(" and OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String) ,
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4)
            };
            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = OutKey;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public bool Update(RecordsSignatureModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_SIGNATURE set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("SymptomSn=@SymptomSn,");
            builder.Append("GeneralConditionSn=@GeneralConditionSn,");
            builder.Append("LifeStyleSn=@LifeStyleSn,");
            builder.Append("OrgansFunctionSn=@OrgansFunctionSn,");
            builder.Append("PEyebseSn=@PEyebseSn,");
            builder.Append("PSkinSn=@PSkinSn,");
            builder.Append("PDigtalExamSn=@PDigtalExamSn,");
            builder.Append("PBreastSn=@PBreastSn,");
            builder.Append("PGynecologySn=@PGynecologySn,");
            builder.Append("PhysicalQtSn=@PhysicalQtSn,");
            builder.Append("ABloodRoutineSn=@ABloodRoutineSn,");
            builder.Append("AMAUSn=@AMAUSn,");
            builder.Append("AECGSn=@AECGSn,");
            builder.Append("AChestXraySn=@AChestXraySn,");
            builder.Append("ABtypeUltrasonicSn=@ABtypeUltrasonicSn,");
            builder.Append("ABtypeQtSn=@ABtypeQtSn,");
            builder.Append("ASmearSn=@ASmearSn,");
            builder.Append("AssistQtSn=@AssistQtSn,");
            builder.Append("InpatientCareSn=@InpatientCareSn,");
            builder.Append("DrugNonimmunitySn=@DrugNonimmunitySn,");
            builder.Append("HealthAssessmentSn=@HealthAssessmentSn,");
            builder.Append("HealthGuidanceSn=@HealthGuidanceSn,");
            builder.Append("SelfSn=@SelfSn,");
            builder.Append("DependentSn=@DependentSn,");
            builder.Append("PersonalFb=@PersonalFb,");
            builder.Append("DoctorSn=@DoctorSn,");
            builder.Append("FeedbackDate=@FeedbackDate, ");
            builder.Append("BloodLiverKidneySn=@BloodLiverKidneySn, ");
            builder.Append("ExamineDoctor=@ExamineDoctor,");
            builder.Append("ECGExamineDoctor=@ECGExamineDoctor,");
            builder.Append("PhysiqueSn=@PhysiqueSn");

            if (model.OutKey == 0) builder.Append(" WHERE OutKey IS NULL ");
            else builder.Append(" WHERE OutKey=@OutKey ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@SymptomSn", MySqlDbType.String,100),
                new MySqlParameter("@GeneralConditionSn", MySqlDbType.String,100),
                new MySqlParameter("@LifeStyleSn", MySqlDbType.String,100),
                new MySqlParameter("@OrgansFunctionSn", MySqlDbType.String,100),
                new MySqlParameter("@PEyebseSn", MySqlDbType.String, 100),
                new MySqlParameter("@PSkinSn", MySqlDbType.String, 100),
                new MySqlParameter("@PDigtalExamSn", MySqlDbType.String, 100),
                new MySqlParameter("@PBreastSn", MySqlDbType.String, 100),
                new MySqlParameter("@PGynecologySn", MySqlDbType.String,100),
                new MySqlParameter("@PhysicalQtSn", MySqlDbType.String, 100),
                new MySqlParameter("@ABloodRoutineSn", MySqlDbType.String,100),
                new MySqlParameter("@AMAUSn", MySqlDbType.String, 100),
                new MySqlParameter("@AECGSn", MySqlDbType.String,100),
                new MySqlParameter("@AChestXraySn", MySqlDbType.String, 100),
                new MySqlParameter("@ABtypeUltrasonicSn", MySqlDbType.String,100),
                new MySqlParameter("@ABtypeQtSn", MySqlDbType.String,100),
                new MySqlParameter("@ASmearSn", MySqlDbType.String,100),
                new MySqlParameter("@AssistQtSn", MySqlDbType.String,100),
                new MySqlParameter("@InpatientCareSn", MySqlDbType.String,100),
                new MySqlParameter("@DrugNonimmunitySn", MySqlDbType.String,100),
                new MySqlParameter("@HealthAssessmentSn", MySqlDbType.String,100),
                new MySqlParameter("@HealthGuidanceSn", MySqlDbType.String,100),
                new MySqlParameter("@SelfSn", MySqlDbType.String,100),
                new MySqlParameter("@DependentSn", MySqlDbType.String,100),
                new MySqlParameter("@PersonalFb", MySqlDbType.String),
                new MySqlParameter("@DoctorSn", MySqlDbType.String),
                new MySqlParameter("@FeedbackDate", MySqlDbType.Date),
                new MySqlParameter("@BloodLiverKidneySn",MySqlDbType.String),
                new MySqlParameter("@ExamineDoctor",MySqlDbType.String,20),
                new MySqlParameter("@ECGExamineDoctor",MySqlDbType.String,20),
                new MySqlParameter("@PhysiqueSn",MySqlDbType.String,20),
                new MySqlParameter("@OutKey",MySqlDbType.Int32,4)
            };

            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.SymptomSn;
            cmdParms[3].Value = model.GeneralConditionSn;
            cmdParms[4].Value = model.LifeStyleSn;
            cmdParms[5].Value = model.OrgansFunctionSn;
            cmdParms[6].Value = model.PEyebseSn;
            cmdParms[7].Value = model.PSkinSn;
            cmdParms[8].Value = model.PDigtalExamSn;
            cmdParms[9].Value = model.PBreastSn;
            cmdParms[10].Value = model.PGynecologySn;
            cmdParms[11].Value = model.PhysicalQtSn;
            cmdParms[12].Value = model.ABloodRoutineSn;
            cmdParms[13].Value = model.AMAUSn;
            cmdParms[14].Value = model.AECGSn;
            cmdParms[15].Value = model.AChestXraySn;
            cmdParms[16].Value = model.ABtypeUltrasonicSn;
            cmdParms[17].Value = model.ABtypeQtSn;
            cmdParms[18].Value = model.ASmearSn;
            cmdParms[19].Value = model.AssistQtSn;
            cmdParms[20].Value = model.InpatientCareSn;
            cmdParms[21].Value = model.DrugNonimmunitySn;
            cmdParms[22].Value = model.HealthAssessmentSn;
            cmdParms[23].Value = model.HealthGuidanceSn;
            cmdParms[24].Value = model.SelfSn;
            cmdParms[25].Value = model.DependentSn;
            cmdParms[26].Value = model.PersonalFb;
            cmdParms[27].Value = model.DoctorSn;
            cmdParms[28].Value = model.FeedbackDate;
            cmdParms[29].Value = model.BloodLiverKidneySn;
            cmdParms[30].Value = model.ExamineDoctor;
            cmdParms[31].Value = model.ECGExamineDoctor;
            cmdParms[32].Value = model.PhysiqueSn;
            cmdParms[33].Value = model.OutKey;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
