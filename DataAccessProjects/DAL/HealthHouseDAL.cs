using KangShuoTech.Utilities.SQLHelper;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;
using System;
using MySql.Data.MySqlClient;

namespace KangShuoTech.DataAccessProjects.DAL
{
    public class HealthHouseDAL
    {
        /// <summary>
        /// 新增骨密度检测记录表
        /// </summary>
        /// <param name="dtInfo"></param>
        /// <returns></returns>
        public int AddBoneBaseInfo(HealthHouseModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"INSERT INTO 
                            [kr_patient_table]
                            (
                                [PatientID]
                                ,[Name]
                                ,[Gender]
                                ,[BirthDay]
                                ,[Phone]
                                ,[DeleteFlag]
                                ,[Reservation]
                                ,[IdentityType]
                                ,[IdentityNumber]
                                ,[Race]
                                ,[Nation]
                            ) 
                            VALUES
                            (
                                @PatientID
                                ,@Name
                                ,@Gender
                                ,@BirthDay
                                ,@Phone
                                ,'0'
                                ,'0'
                                ,'1'
                                ,@IdentityNumber
                                ,'0'
                                ,'0'   
                            ) ");

            model.Sex = model.Sex.Equals("1") ? "0" : "1";

            // 判断病历号是否已存在
            if (!CheckBoneBaseInfo(model.ID.ToString()))
            {
                return -1;
            }

            List<SqlParameter> cmdParms = new List<SqlParameter>();

            cmdParms.Add(new SqlParameter("@PatientID", model.ID));
            cmdParms.Add(new SqlParameter("@Name", model.CustomerName));
            cmdParms.Add(new SqlParameter("@Gender", model.Sex));
            cmdParms.Add(new SqlParameter("@BirthDay", model.Birthday));
            cmdParms.Add(new SqlParameter("@Phone", model.Phone));
            cmdParms.Add(new SqlParameter("@IdentityNumber", model.IDCardNo));

            return SQLHelper.ExecuteNonQuery(builder.ToString(), cmdParms.ToArray());
        }

        /// <summary>
        /// 检测是否存在
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public bool CheckBoneBaseInfo(string strID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"SELECT ID FROM kr_patient_table WHERE PatientID=@PatientID");

            List<SqlParameter> cmdParms = new List<SqlParameter>();
            cmdParms.Add(new SqlParameter("@PatientID", strID));

            DataSet ds = SQLHelper.ExecuteQuery(builder.ToString(), cmdParms.ToArray());

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 新增健康小屋基本信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(HealthHouseModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"INSERT INTO ARCHIVE_HEALTH_HOUSE
                                     (
                                         IDCardNo
                                        ,CheckDate
                                        ,BloodOxygen
                                        ,PulseRate
                                        ,Height
                                        ,Weight
                                        ,BMI
                                        ,LeftPre
                                        ,LeftHeight
                                        ,RightPre
                                        ,RightHeight
                                        ,Doctor
                                        ,CreateDate
                                        ,CreateBy
                                        ,UpdateDate
                                        ,UpdataBy
                                        ,LeftView
                                        ,RightView
                                        ,LeftEyecorrect
                                        ,RightEyecorrect
                                        ,Fat
                                        ,Water
                                        ,Muscle
                                        ,Skeleton
                                        ,Calorie
                                    )
                                    VALUES
                                     (
                                        @IDCardNo
                                        ,@CheckDate
                                        ,@BloodOxygen
                                        ,@PulseRate
                                        ,@Height
                                        ,@Weight
                                        ,@BMI
                                        ,@LeftPre
                                        ,@LeftHeight
                                        ,@RightPre
                                        ,@RightHeight
                                        ,@Doctor
                                        ,@CreateDate
                                        ,@CreateBy
                                        ,@UpdateDate
                                        ,@UpdataBy
                                        ,@LeftView
                                        ,@RightView
                                        ,@LeftEyecorrect
                                        ,@RightEyecorrect
                                        ,@Fat
                                        ,@Water
                                        ,@Muscle
                                        ,@Skeleton
                                        ,@Calorie
                                     ) ");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@IDCardNo", MySqlDbType.String, 18),
                 new MySqlParameter("@CheckDate", MySqlDbType.Date),
                 new MySqlParameter("@BloodOxygen", MySqlDbType.String, 100),
                 new MySqlParameter("@PulseRate", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@Height", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@Weight", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@BMI", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@LeftPre", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@LeftHeight", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@RightPre", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@RightHeight", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@Doctor", MySqlDbType.String, 100),
                 new MySqlParameter("@CreateDate", MySqlDbType.Date),
                 new MySqlParameter("@CreateBy", MySqlDbType.String, 100),
                 new MySqlParameter("@UpdateDate", MySqlDbType.Date),
                 new MySqlParameter("@UpdataBy", MySqlDbType.String, 100),
                 new MySqlParameter("@LeftView", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@RightView", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@LeftEyecorrect", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@RightEyecorrect", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@Fat", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@Water", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@Muscle", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@Skeleton", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@Calorie", MySqlDbType.Decimal, 20)
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.CheckDate;
            cmdParms[2].Value = model.BloodOxygen;
            cmdParms[3].Value = model.PulseRate;
            cmdParms[4].Value = model.Height;
            cmdParms[5].Value = model.Weight;
            cmdParms[6].Value = model.BMI;
            cmdParms[7].Value = model.LeftPre;
            cmdParms[8].Value = model.LeftHeight;
            cmdParms[9].Value = model.RightPre;
            cmdParms[10].Value = model.RightHeight;
            cmdParms[11].Value = model.Doctor;
            cmdParms[12].Value = model.CreateDate;
            cmdParms[13].Value = model.CreateBy;
            cmdParms[14].Value = model.UpdateDate;
            cmdParms[15].Value = model.UpdataBy;
            cmdParms[16].Value = model.LeftView;
            cmdParms[17].Value = model.RightView;
            cmdParms[18].Value = model.LeftEyecorrect;
            cmdParms[19].Value = model.RightEyecorrect;
            cmdParms[20].Value = model.Fat;
            cmdParms[21].Value = model.Water;
            cmdParms[22].Value = model.Muscle;
            cmdParms[23].Value = model.Skeleton;
            cmdParms[24].Value = model.Calorie;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 修改健康小屋基本信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(HealthHouseModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE ARCHIVE_HEALTH_HOUSE
                                     SET                                         
                                        CheckDate = @CheckDate 
                                        ,BloodOxygen = @BloodOxygen 
                                        ,PulseRate = @PulseRate 
                                        ,Height = @Height 
                                        ,Weight = @Weight 
                                        ,BMI = @BMI 
                                        ,LeftPre = @LeftPre 
                                        ,LeftHeight = @LeftHeight 
                                        ,RightPre = @RightPre 
                                        ,RightHeight = @RightHeight 
                                        ,Doctor = @Doctor 
                                        ,UpdateDate = @UpdateDate 
                                        ,UpdataBy = @UpdataBy
                                        ,LeftView = @LeftView 
                                        ,RightView = @RightView 
                                        ,LeftEyecorrect = @LeftEyecorrect 
                                        ,RightEyecorrect = @RightEyecorrect 
                                        ,Fat = @Fat 
                                        ,Water = @Water 
                                        ,Muscle = @Muscle 
                                        ,Skeleton = @Skeleton 
                                        ,Calorie = @Calorie 
                                       WHERE ID=@ID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@ID", MySqlDbType.Int32),
                 new MySqlParameter("@CheckDate", MySqlDbType.Date),
                 new MySqlParameter("@BloodOxygen", MySqlDbType.String, 100),
                 new MySqlParameter("@PulseRate", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@Height", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@Weight", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@BMI", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@LeftPre", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@LeftHeight", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@RightPre", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@RightHeight", MySqlDbType.Decimal, 20),
                 new MySqlParameter("@Doctor", MySqlDbType.String, 100),
                 new MySqlParameter("@UpdateDate", MySqlDbType.Date),
                 new MySqlParameter("@UpdataBy", MySqlDbType.String, 100),
                 new MySqlParameter("@LeftView", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@RightView", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@LeftEyecorrect", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@RightEyecorrect", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@Fat", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@Water", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@Muscle", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@Skeleton", MySqlDbType.Decimal, 20), 
                 new MySqlParameter("@Calorie", MySqlDbType.Decimal, 20)
            };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.CheckDate;
            cmdParms[2].Value = model.BloodOxygen;
            cmdParms[3].Value = model.PulseRate;
            cmdParms[4].Value = model.Height;
            cmdParms[5].Value = model.Weight;
            cmdParms[6].Value = model.BMI;
            cmdParms[7].Value = model.LeftPre;
            cmdParms[8].Value = model.LeftHeight;
            cmdParms[9].Value = model.RightPre;
            cmdParms[10].Value = model.RightHeight;
            cmdParms[11].Value = model.Doctor;
            cmdParms[12].Value = model.UpdateDate;
            cmdParms[13].Value = model.UpdataBy;
            cmdParms[14].Value = model.LeftView;
            cmdParms[15].Value = model.RightView;
            cmdParms[16].Value = model.LeftEyecorrect;
            cmdParms[17].Value = model.RightEyecorrect;
            cmdParms[18].Value = model.Fat;
            cmdParms[19].Value = model.Water;
            cmdParms[20].Value = model.Muscle;
            cmdParms[21].Value = model.Skeleton;
            cmdParms[22].Value = model.Calorie;

            object single = MySQLHelper.ExecuteSql(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 根据身份证及检查日期取得资料
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public DataSet GetList(string idCardNo, string checkDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"SELECT 
                                        HealthHouse.ID
                                        ,HealthHouse.IDCardNo
                                        ,HealthHouse.CheckDate
                                        ,HealthHouse.BloodOxygen
                                        ,HealthHouse.PulseRate
                                        ,HealthHouse.Height
                                        ,HealthHouse.Weight
                                        ,HealthHouse.BMI
                                        ,HealthHouse.LeftPre
                                        ,HealthHouse.LeftHeight
                                        ,HealthHouse.RightPre
                                        ,HealthHouse.RightHeight
                                        ,HealthHouse.Doctor  
                                        ,BaseInfo.CustomerName
                                        ,BaseInfo.Sex
                                        ,BaseInfo.Birthday
                                        ,BaseInfo.Phone 
                                        ,HealthHouse.LeftView         
                                        ,HealthHouse.RightView        
                                        ,HealthHouse.LeftEyecorrect   
                                        ,HealthHouse.RightEyecorrect  
                                        ,HealthHouse.Fat              
                                        ,HealthHouse.Water            
                                        ,HealthHouse.Muscle           
                                        ,HealthHouse.Skeleton         
                                        ,HealthHouse.Calorie                                          
                                    FROM 
                                        ARCHIVE_HEALTH_HOUSE HealthHouse
                                    INNER JOIN ARCHIVE_BASEINFO BaseInfo
                                        ON BaseInfo.IDCardNo=HealthHouse.IDCardNo
                                    WHERE
                                       HealthHouse.IDCardNo=@IDCardNo
                                       AND CheckDate=@CheckDate");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@IDCardNo", idCardNo),
                 new MySqlParameter("@CheckDate", checkDate)
            };

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 根据身份证及检查日期取得资料
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public DataSet GetData(string idCardNo, string checkDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"SELECT 
                                        HealthHouse.ID
                                        ,HealthHouse.IDCardNo
                                        ,HealthHouse.CheckDate
                                        ,HealthHouse.BloodOxygen
                                        ,HealthHouse.PulseRate
                                        ,HealthHouse.Height
                                        ,HealthHouse.Weight
                                        ,HealthHouse.BMI
                                        ,HealthHouse.LeftPre
                                        ,HealthHouse.LeftHeight
                                        ,HealthHouse.RightPre
                                        ,HealthHouse.RightHeight
                                        ,HealthHouse.Doctor
                                        ,HealthHouse.LeftView         
                                        ,HealthHouse.RightView        
                                        ,HealthHouse.LeftEyecorrect   
                                        ,HealthHouse.RightEyecorrect  
                                        ,HealthHouse.Fat              
                                        ,HealthHouse.Water            
                                        ,HealthHouse.Muscle           
                                        ,HealthHouse.Skeleton         
                                        ,HealthHouse.Calorie   
                                        ,Bone.Result
                                        ,Bone.ResultEx
                                        ,Bone.ImgPath
                                        ,Cardiovascular.Result AS CResult
                                        ,Cardiovascular.ResultEx AS CResultEx
                                        ,Cardiovascular.ImgPath AS CImgPath
                                        ,Lung.Result AS LResult
                                        ,Lung.ResultEx AS LResultEx
                                        ,Lung.ImgPath AS LImgPath
                                    FROM 
                                        ARCHIVE_HEALTH_HOUSE HealthHouse
                                    LEFT JOIN HEALTHHOUSE_BMD Bone
                                        ON Bone.PID=HealthHouse.ID
                                    LEFT JOIN HEALTHHOUSE_CARDIOVASCULAR Cardiovascular
                                        ON Cardiovascular.PID=HealthHouse.ID
                                    LEFT JOIN HEALTHHOUSE_LUNG_FUNCTION Lung
                                        ON Lung.PID=HealthHouse.ID
                                    WHERE
                                       HealthHouse.IDCardNo=@IDCardNo
                                       AND HealthHouse.CheckDate=@CheckDate");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@IDCardNo", idCardNo),
                 new MySqlParameter("@CheckDate", checkDate)
            };

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 历史数据 根据身份证取得资料
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public DataSet GetDataInfo(string idCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"SELECT 
                                        HealthHouse.ID
                                        ,HealthHouse.IDCardNo
                                        ,HealthHouse.CheckDate
                                        ,Date_Format(CheckDate,'%Y%m') AS YM
                                        ,HealthHouse.BloodOxygen
                                        ,HealthHouse.PulseRate
                                        ,HealthHouse.Height
                                        ,HealthHouse.Weight
                                        ,HealthHouse.BMI
                                        ,HealthHouse.LeftPre
                                        ,HealthHouse.LeftHeight
                                        ,HealthHouse.RightPre
                                        ,HealthHouse.RightHeight
                                        ,HealthHouse.Doctor  
                                        ,BaseInfo.CustomerName
                                        ,BaseInfo.Sex
                                        ,BaseInfo.Birthday
                                        ,BaseInfo.Phone 
                                        ,HealthHouse.LeftView         
                                        ,HealthHouse.RightView        
                                        ,HealthHouse.LeftEyecorrect   
                                        ,HealthHouse.RightEyecorrect  
                                        ,HealthHouse.Fat              
                                        ,HealthHouse.Water            
                                        ,HealthHouse.Muscle           
                                        ,HealthHouse.Skeleton         
                                        ,HealthHouse.Calorie                                          
                                    FROM 
                                        ARCHIVE_HEALTH_HOUSE HealthHouse
                                    INNER JOIN ARCHIVE_BASEINFO BaseInfo
                                        ON BaseInfo.IDCardNo=HealthHouse.IDCardNo
                                    WHERE
                                        HealthHouse.IDCardNo=@IDCardNo ");

            List<MySqlParameter> cmdParms = new List<MySqlParameter>();

            cmdParms.Add(new MySqlParameter("@IDCardNo", idCardNo));

            return MySQLHelper.Query(builder.ToString(), cmdParms.ToArray());
        }

        /// <summary>
        /// 根据ID取得资料
        /// </summary>
        public DataSet GetDataByID(int ID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"SELECT 
                                        HealthHouse.ID
                                        ,HealthHouse.IDCardNo
                                        ,HealthHouse.CheckDate
                                        ,HealthHouse.BloodOxygen
                                        ,HealthHouse.PulseRate
                                        ,HealthHouse.Height
                                        ,HealthHouse.Weight
                                        ,HealthHouse.BMI
                                        ,HealthHouse.LeftPre
                                        ,HealthHouse.LeftHeight
                                        ,HealthHouse.RightPre
                                        ,HealthHouse.RightHeight
                                        ,HealthHouse.Doctor
                                        ,HealthHouse.LeftView         
                                        ,HealthHouse.RightView        
                                        ,HealthHouse.LeftEyecorrect   
                                        ,HealthHouse.RightEyecorrect  
                                        ,HealthHouse.Fat              
                                        ,HealthHouse.Water            
                                        ,HealthHouse.Muscle           
                                        ,HealthHouse.Skeleton         
                                        ,HealthHouse.Calorie   
                                        ,Bone.Result
                                        ,Bone.ResultEx
                                        ,Bone.ImgPath
                                        ,Cardiovascular.Result AS CResult
                                        ,Cardiovascular.ResultEx AS CResultEx
                                        ,Cardiovascular.ImgPath AS CImgPath
                                        ,Lung.Result AS LResult
                                        ,Lung.ResultEx AS LResultEx
                                        ,Lung.ImgPath AS LImgPath
                                    FROM 
                                        ARCHIVE_HEALTH_HOUSE HealthHouse
                                    LEFT JOIN HEALTHHOUSE_BMD Bone
                                        ON Bone.PID=HealthHouse.ID
                                    LEFT JOIN HEALTHHOUSE_CARDIOVASCULAR Cardiovascular
                                        ON Cardiovascular.PID=HealthHouse.ID
                                    LEFT JOIN HEALTHHOUSE_LUNG_FUNCTION Lung
                                        ON Lung.PID=HealthHouse.ID
                                    WHERE
                                       HealthHouse.ID=@ID");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@ID", ID)
            };

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 获取最新的一笔数据
        /// </summary>
        public DataSet GetMaxData(string idCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"SELECT 
                                        HealthHouse.ID
                                        ,HealthHouse.IDCardNo
                                        ,HealthHouse.CheckDate
                                        ,HealthHouse.BloodOxygen
                                        ,HealthHouse.PulseRate
                                        ,HealthHouse.Height
                                        ,HealthHouse.Weight
                                        ,HealthHouse.BMI
                                        ,HealthHouse.LeftPre
                                        ,HealthHouse.LeftHeight
                                        ,HealthHouse.RightPre
                                        ,HealthHouse.RightHeight
                                        ,HealthHouse.Doctor
                                        ,HealthHouse.LeftView         
                                        ,HealthHouse.RightView        
                                        ,HealthHouse.LeftEyecorrect   
                                        ,HealthHouse.RightEyecorrect  
                                        ,HealthHouse.Fat              
                                        ,HealthHouse.Water            
                                        ,HealthHouse.Muscle           
                                        ,HealthHouse.Skeleton         
                                        ,HealthHouse.Calorie   
                                        ,Bone.Result
                                        ,Bone.ResultEx
                                        ,Bone.ImgPath
                                        ,Cardiovascular.Result AS CResult
                                        ,Cardiovascular.ResultEx AS CResultEx
                                        ,Cardiovascular.ImgPath AS CImgPath
                                        ,Lung.Result AS LResult
                                        ,Lung.ResultEx AS LResultEx
                                        ,Lung.ImgPath AS LImgPath
                                        ,Assist.CHESTX
                                        ,Assist.CHESTXEx
                                        ,Assist.PRO
                                        ,Assist.GLU
                                        ,Assist.KET
                                        ,Assist.BLD
                                        ,Ecg.ECG
                                        ,Ecg.ECGEx
                                        ,PtnTbl.BCHAO
                                        ,PtnTbl.BCHAOEx
                                        ,PtnTbl.BCHAOther
                                        ,PtnTbl.BCHAOtherEx
                                    FROM 
                                        ARCHIVE_HEALTH_HOUSE HealthHouse
                                    LEFT JOIN HEALTHHOUSE_BMD Bone
                                        ON Bone.PID=HealthHouse.ID
                                    LEFT JOIN HEALTHHOUSE_CARDIOVASCULAR Cardiovascular
                                        ON Cardiovascular.PID=HealthHouse.ID
                                    LEFT JOIN HEALTHHOUSE_LUNG_FUNCTION Lung
                                        ON Lung.PID=HealthHouse.ID
                                    LEFT JOIN HEALTHHOUSE_PHYSICAL_ASSIST_CHECK Assist
                                    ON Assist.PID=HealthHouse.ID
                                    LEFT JOIN HEALTHHOUSE_ECG_RESULT Ecg
                                    ON Ecg.PID=HealthHouse.ID
                                    LEFT JOIN HEALTHHOUSE_ULTRASONICB_RESULT PtnTbl
                                    ON PtnTbl.PID=HealthHouse.ID
                                    WHERE
                                       HealthHouse.IDCardNo=@IDCardNo
                                    order by CheckDate DESC LIMIT 0,1  ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@IDCardNo", idCardNo)
            };

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }
        public int GetHouseRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT COUNT(1)");
            builder.Append(" from ARCHIVE_HEALTH_HOUSE  B left join ARCHIVE_BASEINFO T on T.IDCardNo = B.IDCardNo   ");
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
        public DataSet GetHouseListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select B.ID,T.IDCardNo,T.Nation,T.CustomerName,T.Sex,T.Birthday,T.Phone,T.HouseHoldAddress,T.Minority,B.CheckDate,");
            builder.Append("(case T.CreateDate when null then null when '' then null else T.CreateDate end)CreateDate, ");
            builder.Append("(case T.LastUpdateDate when null then null when '' then null else T.LastUpdateDate end ) as LastUpdateDate, ");
            builder.Append("T.PopulationType,T.CreateMenName, B.CheckDate ");
            builder.Append(" from ARCHIVE_HEALTH_HOUSE B left join ARCHIVE_BASEINFO T on T.IDCardNo = B.IDCardNo");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by B." + orderby);
            }
            else
            {
                builder.Append(" order by B.ID desc");
            }

            builder.Append(string.Format(" limit {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }
        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_HEALTH_HOUSE ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
