using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.Model;
using MySql.Data.MySqlClient;
using KangShuoTech.Utilities.MySQLHelper;
using System.Data;
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.DataAccessProjects.DAL
{
    public class HealthAssessExamDAL
    {
        public int Add(HealthAssessExamModel model)
        {
           StringBuilder builder = new StringBuilder();
           builder.Append(" insert into tbl_hhhealthinquiry(");
           builder.Append( "PID,IDCardNo,MedicalHistory,FamilyHistory,HospitalHistory,TakingMedicine,DietaryHabit,DietaryNum,DietaryLaw,DietaryOther,ExerciseExistense,IsSmoke,IsDrink,ExerciseExistenseOther,ExerciseRate,ExerciseTimes,OldSelfCareability,GloomyScore,MedicalOther,FamilyOther)");
           builder.Append(" values (");
           builder.Append("@PID,@IDCardNo,@MedicalHistory,@FamilyHistory,@HospitalHistory,@TakingMedicine,@DietaryHabit,@DietaryNum,@DietaryLaw,@DietaryOther,@ExerciseExistense,@IsSmoke,@IsDrink,@ExerciseExistenseOther,@ExerciseRate,@ExerciseTimes,@OldSelfCareability,@GloomyScore,@MedicalOther,@FamilyOther)");
           builder.Append(";select @@IDENTITY");
           MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@PID",MySqlDbType.Int32),
                new MySqlParameter("@IDCardNo",MySqlDbType.String),
                new MySqlParameter("@MedicalHistory",MySqlDbType.String),
                new MySqlParameter("@FamilyHistory",MySqlDbType.String),
                new MySqlParameter("@HospitalHistory",MySqlDbType.String),
                new MySqlParameter("@TakingMedicine",MySqlDbType.String),
                new MySqlParameter("@DietaryHabit",MySqlDbType.String),
                new MySqlParameter("@DietaryNum",MySqlDbType.String),
                new MySqlParameter("@DietaryLaw",MySqlDbType.String),
                new MySqlParameter("@DietaryOther",MySqlDbType.String),
                new MySqlParameter("@ExerciseExistense",MySqlDbType.String),
                new MySqlParameter("@IsSmoke",MySqlDbType.String),
                new MySqlParameter("@IsDrink",MySqlDbType.String),
                new MySqlParameter("@ExerciseExistenseOther",MySqlDbType.String),
                new MySqlParameter("@ExerciseRate",MySqlDbType.String),
                new MySqlParameter("@ExerciseTimes",MySqlDbType.Decimal),
                new MySqlParameter("@OldSelfCareability",MySqlDbType.String),
                new MySqlParameter("@GloomyScore",MySqlDbType.Decimal),
                new MySqlParameter("@MedicalOther",MySqlDbType.String),
                new MySqlParameter("@FamilyOther",MySqlDbType.String)
                };
           cmdParms[0].Value = model.PID;
           cmdParms[1].Value = model.IDCardNo;
           cmdParms[2].Value = model.MedicalHistory;
           cmdParms[3].Value = model.FamilyHistory;
           cmdParms[4].Value = model.HospitalHistory;
           cmdParms[5].Value = model.TakingMedicine;
           cmdParms[6].Value = model.DietaryHabit;
           cmdParms[7].Value = model.DietaryNum;
           cmdParms[8].Value = model.DietaryLaw;
           cmdParms[9].Value = model.DietaryOther;
           cmdParms[10].Value = model.ExerciseExistense;
           cmdParms[11].Value = model.IsSmoke;
           cmdParms[12].Value = model.IsDrink;
           cmdParms[13].Value = model.ExerciseExistenseOther;
           cmdParms[14].Value = model.ExerciseRate;
           cmdParms[15].Value = model.ExerciseTimes;
           cmdParms[16].Value = model.OldSelfCareability;
           cmdParms[17].Value = model.GloomyScore;
           cmdParms[18].Value = model.MedicalOther;
           cmdParms[19].Value = model.FamilyOther;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public HealthAssessExamModel GetModel(int PID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" select * ");
            builder.Append(" from tbl_hhhealthinquiry ");
            builder.Append(" where PID=@PID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@PID", PID)
            };
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set != null)
            {
                // 将DataTable转为List
                IList<HealthAssessExamModel> list = CommonExtensions.DataTableToList<HealthAssessExamModel>(set.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }
        /// <summary>
        /// 根据PID判断肺功能资料是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsPID(string IDCardNo, int PID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_hhhealthinquiry");
            builder.Append(" where IDCardNo=@IDCardNo ");
            builder.Append(" and PID=@PID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String) ,
                new MySqlParameter("@PID", MySqlDbType.Int32, 4) 
            };
            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = PID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public bool Update(HealthAssessExamModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" update tbl_hhhealthinquiry set ");
            builder.Append("PID=@PID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("MedicalHistory=@MedicalHistory,");
            builder.Append("FamilyHistory=@FamilyHistory,");
            builder.Append("HospitalHistory=@HospitalHistory,");
            builder.Append("TakingMedicine=@TakingMedicine,");
            builder.Append("DietaryHabit=@DietaryHabit,");
            builder.Append("DietaryNum=@DietaryNum,");
            builder.Append("DietaryLaw=@DietaryLaw,");
            builder.Append("DietaryOther=@DietaryOther,");
            builder.Append("ExerciseExistense=@ExerciseExistense,");
            builder.Append("IsSmoke=@IsSmoke,");
            builder.Append("IsDrink=@IsDrink,");
            builder.Append("ExerciseExistenseOther=@ExerciseExistenseOther,");
            builder.Append("ExerciseRate=@ExerciseRate,");
            builder.Append("ExerciseTimes=@ExerciseTimes,");
            builder.Append("OldSelfCareability=@OldSelfCareability,");
            builder.Append("GloomyScore=@GloomyScore,");
            builder.Append("MedicalOther=@MedicalOther,");
            builder.Append("FamilyOther=@FamilyOther");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@PID",MySqlDbType.Int32),
                new MySqlParameter("@IDCardNo",MySqlDbType.String),
                new MySqlParameter("@MedicalHistory",MySqlDbType.String),
                new MySqlParameter("@FamilyHistory",MySqlDbType.String),
                new MySqlParameter("@HospitalHistory",MySqlDbType.String),
                new MySqlParameter("@TakingMedicine",MySqlDbType.String),
                new MySqlParameter("@DietaryHabit",MySqlDbType.String),
                new MySqlParameter("@DietaryNum",MySqlDbType.String),
                new MySqlParameter("@DietaryLaw",MySqlDbType.String),
                new MySqlParameter("@DietaryOther",MySqlDbType.String),
                new MySqlParameter("@ExerciseExistense",MySqlDbType.String),
                new MySqlParameter("@IsSmoke",MySqlDbType.String),
                new MySqlParameter("@IsDrink",MySqlDbType.String),
                new MySqlParameter("@ExerciseExistenseOther",MySqlDbType.String),
                new MySqlParameter("@ExerciseRate",MySqlDbType.String),
                new MySqlParameter("@ExerciseTimes",MySqlDbType.Decimal),
                new MySqlParameter("@OldSelfCareability",MySqlDbType.String),
                new MySqlParameter("@GloomyScore",MySqlDbType.Decimal),
                new MySqlParameter("@MedicalOther",MySqlDbType.String),
                new MySqlParameter("@FamilyOther",MySqlDbType.String),
                new MySqlParameter("@ID",MySqlDbType.Int32)
                };
            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.MedicalHistory;
            cmdParms[3].Value = model.FamilyHistory;
            cmdParms[4].Value = model.HospitalHistory;
            cmdParms[5].Value = model.TakingMedicine;
            cmdParms[6].Value = model.DietaryHabit;
            cmdParms[7].Value = model.DietaryNum;
            cmdParms[8].Value = model.DietaryLaw;
            cmdParms[9].Value = model.DietaryOther;
            cmdParms[10].Value = model.ExerciseExistense;
            cmdParms[11].Value = model.IsSmoke;
            cmdParms[12].Value = model.IsDrink;
            cmdParms[13].Value = model.ExerciseExistenseOther;
            cmdParms[14].Value = model.ExerciseRate;
            cmdParms[15].Value = model.ExerciseTimes;
            cmdParms[16].Value = model.OldSelfCareability;
            cmdParms[17].Value = model.GloomyScore;
            cmdParms[18].Value = model.MedicalOther;
            cmdParms[19].Value = model.FamilyOther;
            cmdParms[20].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        #region

        /// <summary>
        /// 查询问询信息笔数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetHealthInquiryRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT COUNT(1)");
            builder.Append(" From tbl_HHHealthInquiry a ");
            builder.Append(" Left Join tbl_recordsbaseinfo b ON a.IDCardNo = b.IDCardNo");

            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 查询问询信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetHealthInquiryListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"select a.ID
                                                ,PID
                                                ,a.IDCardNo
                                                ,MedicalHistory
                                                ,FamilyHistory
                                                ,HospitalHistory
                                                ,TakingMedicine
                                                ,DietaryHabit
                                                ,DietaryNum
                                                ,DietaryLaw
                                                ,DietaryOther
                                                ,ExerciseExistense
                                                ,IsSmoke
                                                ,IsDrink
                                                ,ExerciseExistenseOther
                                                ,ExerciseRate
                                                ,ExerciseTimes
                                                ,MedicalOther
                                                ,FamilyOther
                                                ,OldSelfCareability
                                                ,GloomyScore
                                                ,b.CustomerName
                                                ,b.Sex
                                                ,b.CreateMenName
                                                ,b.CreateDate");

            builder.Append(" from tbl_HHHealthInquiry a");
            builder.Append(" Left Join tbl_recordsbaseinfo b on a.IDCardNo = b.IDCardNo");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by " + orderby);
            }
            else
            {
                builder.Append(" order by ID desc");
            }

            builder.Append(string.Format(" limit {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_HHHealthInquiry ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        #endregion
        /// <summary>
        /// 获取最新一笔体检的体检问询
        /// </summary>
        /// <param name="IDCardNo">身份证</param>
        /// <returns></returns>
        public HealthAssessExamModel GetMaxModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"SELECT a.PID,a.IDCardNo,
                                    a.MedicalHistory,
                                    a.FamilyHistory,
                                    a.HospitalHistory,
                                    a.TakingMedicine,
                                    a.DietaryHabit,
                                    a.DietaryNum,
                                    a.DietaryLaw,
                                    a.DietaryOther,
                                    a.ExerciseExistense,
                                    a.IsSmoke,
                                    a.IsDrink,
                                    a.ExerciseExistenseOther,
                                    a.ExerciseRate,
                                    a.ExerciseTimes,
                                    a.OldSelfCareability,
                                    a.GloomyScore,
                                    a.MedicalOther,
                                    a.FamilyOther ");
            builder.Append(" From tbl_HHHealthInquiry a ");
            builder.Append(" Left Join tbl_RecordsHealthHouse b ON a.IDCardNo = b.IDCardNo and a.PID=b.ID ");
            builder.Append(" where a.IDCardNo=@IDCardNo ");
            builder.Append(" order by b.CheckDate DESC LIMIT 0,1  ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@IDCardNo", IDCardNo)
            };
            cmdParms[0].Value = IDCardNo;
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set != null)
            {
                // 将DataTable转为List
                IList<HealthAssessExamModel> list = CommonExtensions.DataTableToList<HealthAssessExamModel>(set.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }
    }
}
