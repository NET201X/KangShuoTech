using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommonUtilities.SQL;
using System;
using System.Data;
using System.Text;
using CommomUtilities.Common;
using System.Collections.Generic;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsCustomerBaseInfoDAL
    {
        RecordsMedicationDAL medicationDAL = new RecordsMedicationDAL();
        RecordsHospitalHistoryDAL hospitalHistoryDAL = new RecordsHospitalHistoryDAL();
        RecordsFamilyBedHistoryDAL familyBedHistoryDAL = new RecordsFamilyBedHistoryDAL();
        RecordsInoculationHistoryDAL inoculationHistoryDAL = new RecordsInoculationHistoryDAL();

        public int Add(RecordsCustomerBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO ARCHIVE_CUSTOMERBASEINFO(");
            builder.Append("CustomerID,IDCardNo,CheckDate,Doctor,Symptom,Other,PhysicalID,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,PhysicalClass,IsDel)");
            builder.Append(" VALUES (");
            builder.Append("@CustomerID,@IDCardNo,@CheckDate,@Doctor,@Symptom,@Other,@PhysicalID,@CreateBy,@CreateDate,@LastUpdateBy,@LastUpdateDate,@PhysicalClass,@IsDel)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@CheckDate", MySqlDbType.Date),
                new MySqlParameter("@Doctor", MySqlDbType.String, 30),
                new MySqlParameter("@Symptom", MySqlDbType.String, 100),
                new MySqlParameter("@Other", MySqlDbType.String, 200),
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreateDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@PhysicalClass", MySqlDbType.String, 10),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1)
            };

            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.CheckDate;
            cmdParms[3].Value = model.Doctor;
            cmdParms[4].Value = model.Symptom;
            cmdParms[5].Value = model.Other;
            cmdParms[6].Value = model.PhysicalID;
            cmdParms[7].Value = model.CreateBy;
            cmdParms[8].Value = model.CreateDate;
            cmdParms[9].Value = model.LastUpdateBy;
            cmdParms[10].Value = model.LastUpdateDate;
            cmdParms[11].Value = model.PhysicalClass;
            cmdParms[12].Value = model.IsDel;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public bool Update(int ID, string barCode)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE ARCHIVE_CUSTOMERBASEINFO SET CustomerID=@CustomerID");
            builder.Append(" WHERE ID=@ID");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@ID", ID),
                new MySqlParameter("@CustomerID", barCode)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet GetVillageList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT DISTINCT(VillageName) FROM ARCHIVE_BASEINFO");
            builder.Append(" WHERE 1=1 ");

            if (!string.IsNullOrEmpty(strWhere)) builder.Append(strWhere);

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 同步时取得年度的最后一次体检资料
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <returns></returns>
        public DataSet GetModelByCheckDate(string IDCardNo, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT ID,CheckDate,IDCardNo,Doctor ");
            builder.Append(" FROM ARCHIVE_CUSTOMERBASEINFO ");
            builder.Append(" WHERE ID=(SELECT ID FROM ARCHIVE_CUSTOMERBASEINFO ");
            builder.Append("    WHERE IDCardNo=@IDCardNo AND LEFT(CheckDate,4)=@CheckDate ORDER BY CheckDate DESC LIMIT 0,1) ");

            if (Convert.ToString(CheckDate).Length > 3) CheckDate = CheckDate.Substring(0, 4);

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", IDCardNo),
                new MySqlParameter("@CheckDate", CheckDate)
            };

            DataSet SET = MySQLHelper.Query(builder.ToString(), cmdParms);

            return SET;
        }

        public DataSet GetModelByWhere(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_CUSTOMERBASEINFO ");

            if (!string.IsNullOrEmpty(strWhere.Trim())) builder.Append(" WHERE 1=1 AND " + strWhere);

            DataSet SET = MySQLHelper.Query(builder.ToString());

            return SET;
        }

        public DataSet GetMaxModel(string IDCardNo, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_CUSTOMERBASEINFO ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            if (CheckDate != "") builder.Append("AND CheckDate=@CheckDate");

            builder.Append(" ORDER BY CheckDate DESC LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@CheckDate", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = CheckDate;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        public DataSet GetBiochemical(string IDCardNo, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_CUSTOMERBASEINFO ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            if (Convert.ToString(CheckDate).Length > 3) CheckDate = CheckDate.Substring(0, 4);
            if (CheckDate != "") builder.Append("AND LEFT(CheckDate,4)=@CheckDate");

            builder.Append(" ORDER BY CheckDate DESC LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@CheckDate", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = CheckDate;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_CUSTOMERBASEINFO ");

            if (strWhere.Trim() != "") builder.Append(" WHERE " + strWhere);

            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetModelByID(int ID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_CUSTOMERBASEINFO ");
            builder.Append(" WHERE ID=@ID");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.String) };
            cmdParms[0].Value = ID;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }

        public int GetCustomerRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT COUNT(1)");
            builder.Append(" FROM ARCHIVE_CUSTOMERBASEINFO  B LEFT JOIN ARCHIVE_BASEINFO T ON T.IDCardNo = B.IDCardNo ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            object single = MySQLHelper.GetSingle(builder.ToString());

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetCustomerListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT B.ID,T.IDCardNo,T.Nation,T.CustomerName,T.Sex,T.Birthday,T.Phone,T.HouseHoldAddress,T.Minority,B.CheckDate,");
            builder.Append("(case T.CreateDate when null then null when '' then null else T.CreateDate end) CreateDate, ");
            builder.Append("(case T.LastUpdateDate when null then null when '' then null else T.LastUpdateDate end ) AS LastUpdateDate, ");
            builder.Append("T.PopulationType,T.CreateMenName, B.CheckDate,current_date()-T.Birthday AS age ");
            builder.Append(" FROM ARCHIVE_CUSTOMERBASEINFO B LEFT JOIN ARCHIVE_BASEINFO T ON T.IDCardNo = B.IDCardNo");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" ORDER BY B." + orderby);
            }
            else
            {
                builder.Append(" ORDER BY B.ID desc");
            }

            builder.Append(string.Format(" LIMIT {0},{1}", startIndex, endIndex));

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 体检问询更新体检
        /// </summary>
        /// <param name="customerBaseInfoModel"></param>
        /// <param name="deciveModel"></param>
        /// <param name="MedicationModel"></param>
        /// <param name="HistoryModel"></param>
        /// <param name="area"></param>
        /// <param name="versionNo"></param>
        /// <returns></returns>
        public bool Update(RecordsCustomerBaseInfoModel customerBaseInfoModel, DataUploadModel deciveModel,
            List<RecordsMedicationModel> MedicationModel, List<History> HistoryModel, string area, string versionNo)
        {
            RecordsGeneralConditionModel generalConditionModel = new RecordsGeneralConditionModel();
            RecordsLifeStyleModel lifeStyleModel = new RecordsLifeStyleModel();
            RecordsAssistCheckModel assistCheckModel = new RecordsAssistCheckModel();
            RecordsHealthQuestionModel healthQuestionModel = new RecordsHealthQuestionModel();
            RecordsVisceraFunctionModel visceraFunctionModel = new RecordsVisceraFunctionModel();
            RecordsPhysicalExamModel physicalExamModel = new RecordsPhysicalExamModel();
            RecordsHospitalHistoryModel hospitalHistoryModel = new RecordsHospitalHistoryModel();
            RecordsFamilyBedHistoryModel familyBedHistoryModel = new RecordsFamilyBedHistoryModel();
            RecordsInoculationHistoryModel inoculationHistoryModel = new RecordsInoculationHistoryModel();

            bool flag = false;
            int successNum = 0;
            StringBuilder sb = new StringBuilder();

            #region 体检主档、用药、住院及免疫接种史

            #region 体检主档

            sb.Append("UPDATE ARCHIVE_CUSTOMERBASEINFO SET ");

            if (StringPlus.toString(customerBaseInfoModel.Symptom) != "")
            {
                sb.Append("Symptom='" + customerBaseInfoModel.Symptom + "',");
            }

            if (StringPlus.toString(customerBaseInfoModel.Other) != "")
            {
                sb.Append("Other='" + customerBaseInfoModel.Other + "',");
            }

            if (sb.ToString() != "UPDATE ARCHIVE_CUSTOMERBASEINFO SET ")
            {
                string upStr = sb.ToString().Substring(0, sb.ToString().Length - 1);
                upStr += " WHERE IDCardNo = '" + deciveModel.IDCardNo + "' AND CheckDate='" + deciveModel.RecordDate + "'";

                successNum = MySQLHelper.ExecuteSql(upStr);
            }

            if (successNum > 0) flag = true;

            sb.Clear();
            successNum = 0;

            #endregion

            #region 用药

            if (MedicationModel != null && MedicationModel.Count > 0)
            {
                medicationDAL.DeleteByOutKey(customerBaseInfoModel.ID);

                foreach (RecordsMedicationModel recordsMedicationModel in MedicationModel)
                {
                    recordsMedicationModel.IDCardNo = deciveModel.IDCardNo;
                    recordsMedicationModel.OutKey = customerBaseInfoModel.ID;

                    if (area.Equals("武汉"))
                    {
                        recordsMedicationModel.Num = recordsMedicationModel.EachNum;    // 用量（日）
                        recordsMedicationModel.UseYear = recordsMedicationModel.UseYearUnit;// 用药时间
                    }

                    if (versionNo.Contains("陕西") || versionNo.Equals("安徽"))
                    {
                        recordsMedicationModel.Frequency = recordsMedicationModel.UseNum;   // 频次
                        recordsMedicationModel.UseNum = recordsMedicationModel.EachNum;     // 单次用量
                        recordsMedicationModel.UseYear = recordsMedicationModel.StartTime;     // 用药年限
                    }
                    else if (versionNo.Contains("山西"))
                    {
                        recordsMedicationModel.StartTime += recordsMedicationModel.UseYearUnit; // 用药年限
                        recordsMedicationModel.UseNumUnit = recordsMedicationModel.Frequency;   // 单次用量单位
                    }
                    else if (versionNo.Contains("河北") || versionNo.Contains("四川") || versionNo.Contains("重庆"))
                    {
                        recordsMedicationModel.UseNumUnit = recordsMedicationModel.Frequency;   // 单次用量单位

                        if (versionNo.Contains("河北") && StringPlus.toString(recordsMedicationModel.Frequency) == "")
                        {
                            recordsMedicationModel.UseNumUnit = recordsMedicationModel.UseDay;   // 单次用量单位
                        }

                        // 四川用量特殊处理 口服 每次1片
                        if (versionNo.Contains("四川")) recordsMedicationModel.UseDay = recordsMedicationModel.EachNum + recordsMedicationModel.Frequency;
                    }

                    medicationDAL.Add(recordsMedicationModel);
                }
            }

            #endregion

            #region 住院及免疫接种史

            DateTime? DateNull = null;

            if (HistoryModel != null)
            {
                int count = 0, count2 = 0, count3 = 0;

                foreach (History item in HistoryModel)
                {
                    if (item.Type == "1")
                    {
                        if (count == 0) hospitalHistoryDAL.DeleteByOutKey(customerBaseInfoModel.ID);

                        hospitalHistoryModel = new RecordsHospitalHistoryModel();
                        hospitalHistoryModel.IDCardNo = deciveModel.IDCardNo;
                        hospitalHistoryModel.InHospitalDate = string.IsNullOrEmpty(item.InDate) ? DateNull : Convert.ToDateTime(item.InDate);
                        hospitalHistoryModel.OutHospitalDate = string.IsNullOrEmpty(item.OutDate) ? DateNull : Convert.ToDateTime(item.OutDate);
                        hospitalHistoryModel.HospitalName = item.Name;
                        hospitalHistoryModel.Reason = item.Reason;
                        hospitalHistoryModel.IllcaseNum = item.IllcaseNum;
                        hospitalHistoryModel.OutKey = customerBaseInfoModel.ID;

                        if (!string.IsNullOrEmpty(item.InDate) && !string.IsNullOrEmpty(item.OutDate) && !string.IsNullOrEmpty(item.IllcaseNum))
                            hospitalHistoryDAL.Add(hospitalHistoryModel);

                        count++;
                    }
                    else if (item.Type == "2")
                    {
                        if (count2 == 0) familyBedHistoryDAL.DeleteByOutKey(customerBaseInfoModel.ID);

                        familyBedHistoryModel = new RecordsFamilyBedHistoryModel();
                        familyBedHistoryModel.IDCardNo = deciveModel.IDCardNo;
                        familyBedHistoryModel.InHospitalDate = string.IsNullOrEmpty(item.InDate) ? DateNull : Convert.ToDateTime(item.InDate);
                        familyBedHistoryModel.OutHospitalDate = string.IsNullOrEmpty(item.OutDate) ? DateNull : Convert.ToDateTime(item.OutDate);
                        familyBedHistoryModel.HospitalName = item.Name;
                        familyBedHistoryModel.Reasons = item.Reason;
                        familyBedHistoryModel.IllcaseNums = item.IllcaseNum;
                        familyBedHistoryModel.OutKey = customerBaseInfoModel.ID;

                        if (!string.IsNullOrEmpty(item.InDate) && !string.IsNullOrEmpty(item.OutDate) && !string.IsNullOrEmpty(item.IllcaseNum))
                            familyBedHistoryDAL.Add(familyBedHistoryModel);

                        count2++;
                    }
                    else if (item.Type == "3")
                    {
                        if (count3 == 0) inoculationHistoryDAL.DeleteByOutKey(customerBaseInfoModel.ID);

                        inoculationHistoryModel = new RecordsInoculationHistoryModel();
                        inoculationHistoryModel.IDCardNo = deciveModel.IDCardNo;
                        inoculationHistoryModel.InoculationDate = string.IsNullOrEmpty(item.InDate) ? DateNull : Convert.ToDateTime(item.InDate);
                        inoculationHistoryModel.PillName = item.Name;
                        inoculationHistoryModel.InoculationHistory = item.InoculationHistory;
                        inoculationHistoryModel.OutKey = customerBaseInfoModel.ID;

                        if (!string.IsNullOrEmpty(item.InDate) && !string.IsNullOrEmpty(item.Name))
                            inoculationHistoryDAL.Add(inoculationHistoryModel);

                        count3++;
                    }
                }
            }

            // 河北乐亭县 住院治疗情况--住院史、家庭病床史默认无 非免疫规划预防接种史默认无
            if ((HistoryModel == null || HistoryModel.Count == 0) && area.Equals("乐亭县"))
            {
                hospitalHistoryDAL.DeleteByOutKey(customerBaseInfoModel.ID);

                hospitalHistoryModel = new RecordsHospitalHistoryModel();
                hospitalHistoryModel.IDCardNo = deciveModel.IDCardNo;
                hospitalHistoryModel.Reason = "无";
                hospitalHistoryModel.OutKey = customerBaseInfoModel.ID;

                hospitalHistoryDAL.Add(hospitalHistoryModel);

                familyBedHistoryDAL.DeleteByOutKey(customerBaseInfoModel.ID);

                familyBedHistoryModel = new RecordsFamilyBedHistoryModel();
                familyBedHistoryModel.IDCardNo = deciveModel.IDCardNo;
                familyBedHistoryModel.Reasons = "无";
                familyBedHistoryModel.OutKey = customerBaseInfoModel.ID;

                familyBedHistoryDAL.Add(familyBedHistoryModel);

                inoculationHistoryDAL.DeleteByOutKey(customerBaseInfoModel.ID);

                inoculationHistoryModel = new RecordsInoculationHistoryModel();
                inoculationHistoryModel.IDCardNo = deciveModel.IDCardNo;
                inoculationHistoryModel.PillName = "无";
                inoculationHistoryModel.OutKey = customerBaseInfoModel.ID;

                inoculationHistoryDAL.Add(inoculationHistoryModel);
            }

            #endregion

            #endregion

            #region 一般情况

            // 一般情况
            generalConditionModel = new RecordsGeneralConditionModel();
            generalConditionModel.OldRecognise = deciveModel.OldRecognise;
            generalConditionModel.OldEmotion = deciveModel.OldEmotion;

            decimal? DecimalNull = null;

            generalConditionModel.InterScore = string.IsNullOrEmpty(deciveModel.InterScore) ? DecimalNull :
                Convert.ToDecimal(deciveModel.InterScore);
            generalConditionModel.GloomyScore = string.IsNullOrEmpty(deciveModel.GloomyScore) ? DecimalNull :
                Convert.ToDecimal(deciveModel.GloomyScore);
            generalConditionModel.OldHealthStaus = deciveModel.OldHealthStaus;
            generalConditionModel.OldSelfCareability = deciveModel.OldSelfCareability;

            sb.Append("UPDATE ARCHIVE_GENERALCONDITION D SET ");

            if (StringPlus.toString(generalConditionModel.OldRecognise) != "")
            {
                sb.Append("OldRecognise='" + generalConditionModel.OldRecognise + "',");
            }
            if (StringPlus.toString(generalConditionModel.OldEmotion) != "")
            {
                sb.Append("OldEmotion='" + generalConditionModel.OldEmotion + "',");
            }
            if (generalConditionModel.InterScore != null)
            {
                sb.Append("InterScore='" + generalConditionModel.InterScore + "',");
            }
            if (generalConditionModel.GloomyScore != null)
            {
                sb.Append("GloomyScore='" + generalConditionModel.GloomyScore + "',");
            }
            if (StringPlus.toString(generalConditionModel.OldHealthStaus) != "")
            {
                sb.Append("OldHealthStaus='" + generalConditionModel.OldHealthStaus + "',");
            }
            if (StringPlus.toString(generalConditionModel.OldSelfCareability) != "")
            {
                sb.Append("OldSelfCareability='" + generalConditionModel.OldSelfCareability + "',");
            }

            if (sb.ToString() != "UPDATE ARCHIVE_GENERALCONDITION D SET ")
            {
                string upStr = sb.ToString().Substring(0, sb.ToString().Length - 1);
                upStr += string.Format(@" WHERE EXISTS
                                    (
                                        SELECT 
                                            ID 
                                        FROM
                                            ARCHIVE_CUSTOMERBASEINFO M
                                        WHERE M.ID = D.OutKey
                                            AND M.IDCardNo = '{0}'
                                            AND M.CheckDate = '{1}'
                                    ) ", deciveModel.IDCardNo, deciveModel.RecordDate);

                successNum = MySQLHelper.ExecuteSql(upStr);
            }

            if (successNum > 0) flag = true;

            sb.Clear();
            successNum = 0;

            #endregion

            #region 生活方式

            lifeStyleModel = new RecordsLifeStyleModel();
            lifeStyleModel.IDCardNo = deciveModel.IDCardNo;
            lifeStyleModel.ExerciseRate = deciveModel.ExerciseRate;//2
            lifeStyleModel.ExerciseExistenseOther = deciveModel.ExerciseExistenseEx;
            lifeStyleModel.ExerciseExistense = deciveModel.ExerciseExistense;//5
            lifeStyleModel.DietaryHabit = deciveModel.DietaryHabit; //6
            lifeStyleModel.SmokeCondition = deciveModel.SmokeCondition;//7
            lifeStyleModel.DrinkRate = deciveModel.DrinkRate;//11
            lifeStyleModel.DrinkThisYear = deciveModel.DrinkThisYear;//15
            lifeStyleModel.DrinkType = deciveModel.DrinkType;//16
            lifeStyleModel.DrinkTypeOther = deciveModel.DrinkTypeEx;
            lifeStyleModel.IsDrinkForbiddon = deciveModel.IsDrinkForbiddon;//13
            decimal decimal1, decimal2, decimal3, decimal4, decimal5, decimal6, decimal7, decimal8;

            sb.Append("UPDATE ARCHIVE_LIFESTYLE D SET ");

            // 锻炼频率 1:每天,2:每周一次以上,3:偶尔,4:不锻炼
            if (StringPlus.toString(lifeStyleModel.ExerciseRate) != "")
            {
                sb.Append("ExerciseRate='" + lifeStyleModel.ExerciseRate + "',");

                // 为不锻炼时，清空锻炼时间及坚持锻炼时间
                if (lifeStyleModel.ExerciseRate == "4")
                {
                    sb.Append("ExerciseTimes=NULL,");
                    sb.Append("ExcisepersistTime=NULL,");
                }
                else
                {
                    // 每次锻炼时间
                    if (decimal.TryParse(deciveModel.ExerciseTimes, out decimal1)) //3
                    {
                        lifeStyleModel.ExerciseTimes = decimal1;
                        sb.Append("ExerciseTimes='" + lifeStyleModel.ExerciseTimes + "',");
                    }
                    else
                    {
                        sb.Append("ExerciseTimes=NULL,");
                    }

                    // 坚持锻炼时间
                    if (decimal.TryParse(deciveModel.ExcisepersistTime, out decimal2)) //4
                    {
                        lifeStyleModel.ExcisepersistTime = decimal2;
                        sb.Append("ExcisepersistTime='" + lifeStyleModel.ExcisepersistTime + "',");
                    }
                    else
                    {
                        sb.Append("ExcisepersistTime=NULL,");
                    }
                }

                sb.Append("ExerciseExistense='" + lifeStyleModel.ExerciseExistense + "',");
                sb.Append("ExerciseExistenseOther='" + lifeStyleModel.ExerciseExistenseOther + "',");
            }

            // 饮食习惯 1:荤素均衡,2:荤食为主,3:素食为主,4:嗜盐,5:嗜油,6:嗜糖
            if (StringPlus.toString(lifeStyleModel.DietaryHabit) != "")
            {
                sb.Append("DietaryHabit='" + lifeStyleModel.DietaryHabit + "',");
            }

            // 吸烟状况 1:从不吸烟,2:已戒烟,3:吸烟
            if (StringPlus.toString(lifeStyleModel.SmokeCondition) != "")
            {
                sb.Append("SmokeCondition='" + lifeStyleModel.SmokeCondition + "',");

                // 为从不吸烟时，清空日吸烟量、戒烟年龄
                if (lifeStyleModel.SmokeCondition == "1")
                {
                    sb.Append("SmokeDayNum=NULL,");
                    sb.Append("SmokeAgeStart=NULL,");
                    sb.Append("SmokeAgeForbiddon=NULL,");
                }
                else
                {
                    // 日吸烟量
                    if (decimal.TryParse(deciveModel.SmokeDayNum, out decimal3)) //8
                    {
                        lifeStyleModel.SmokeDayNum = decimal3;
                        sb.Append("SmokeDayNum='" + lifeStyleModel.SmokeDayNum + "',");
                    }
                    else
                    {
                        sb.Append("SmokeDayNum=NULL,");
                    }

                    // 开始吸烟年龄
                    if (decimal.TryParse(deciveModel.SmokeAgeStart, out decimal4))//9
                    {
                        lifeStyleModel.SmokeAgeStart = decimal4;
                        sb.Append("SmokeAgeStart='" + lifeStyleModel.SmokeAgeStart + "',");
                    }
                    else
                    {
                        sb.Append("SmokeAgeStart=NULL,");
                    }

                    // 戒烟年龄
                    if (decimal.TryParse(deciveModel.SmokeAgeForbiddon, out decimal5)) //10
                    {
                        lifeStyleModel.SmokeAgeForbiddon = decimal5;
                        sb.Append("SmokeAgeForbiddon='" + lifeStyleModel.SmokeAgeForbiddon + "',");
                    }
                    else
                    {
                        sb.Append("SmokeAgeForbiddon=NULL,");
                    }
                }
            }

            // 饮酒频率 1:从不,2:偶尔,3:经常,4:每天
            if (StringPlus.toString(lifeStyleModel.DrinkRate) != "")
            {
                sb.Append("DrinkRate='" + lifeStyleModel.DrinkRate + "',");

                // 为从不时，清空日饮酒量, 是否戒酒, 戒酒年龄, 开始饮酒年龄, 近一年内是否醉酒, 饮酒种类
                if (lifeStyleModel.DrinkRate == "1")
                {
                    sb.Append("DayDrinkVolume=NULL,");
                    sb.Append("IsDrinkForbiddon=NULL,");
                    sb.Append("ForbiddonAge=NULL,");
                    sb.Append("DrinkStartAge=NULL,");
                    sb.Append("DrinkThisYear=NULL,");
                    sb.Append("DrinkType=NULL,");
                    sb.Append("DrinkTypeOther=NULL,");
                }
                else
                {
                    // 日饮酒量
                    if (decimal.TryParse(deciveModel.DayDrinkVolume, out decimal6)) //12
                    {
                        lifeStyleModel.DayDrinkVolume = decimal6;
                        sb.Append("DayDrinkVolume='" + lifeStyleModel.DayDrinkVolume + "',");
                    }
                    else
                    {
                        sb.Append("DayDrinkVolume=NULL,");
                    }

                    // 是否戒酒 1:未戒酒,2:已戒酒 
                    sb.Append("IsDrinkForbiddon='" + lifeStyleModel.IsDrinkForbiddon + "',");

                    // 为未戒酒时，清空戒酒年龄
                    if (StringPlus.toString(lifeStyleModel.IsDrinkForbiddon) == "1")
                    {
                        sb.Append("ForbiddonAge=NULL,");
                    }
                    else
                    {
                        // 戒酒年龄
                        if (decimal.TryParse(deciveModel.IsDrinkForbiddonEx, out decimal8))
                        {
                            lifeStyleModel.ForbiddonAge = decimal8;
                            sb.Append("ForbiddonAge='" + lifeStyleModel.ForbiddonAge + "',");
                        }
                        else
                        {
                            sb.Append("ForbiddonAge=NULL,");
                        }
                    }

                    // 开始饮酒年龄
                    if (decimal.TryParse(deciveModel.DrinkStartAge, out decimal7))//14
                    {
                        lifeStyleModel.DrinkStartAge = decimal7;
                        sb.Append("DrinkStartAge='" + lifeStyleModel.DrinkStartAge + "',");
                    }
                    else
                    {
                        sb.Append("DrinkStartAge=NULL,");
                    }

                    // 近一年内是否醉酒
                    sb.Append("DrinkThisYear='" + lifeStyleModel.DrinkThisYear + "',");
                    sb.Append("DrinkType='" + lifeStyleModel.DrinkType + "',");
                    sb.Append("DrinkTypeOther='" + lifeStyleModel.DrinkTypeOther + "',");
                }
            }

            // 职业病危害
            lifeStyleModel.CareerHarmFactorHistory = deciveModel.CareerHarmFactorHistory;
            lifeStyleModel.WorkType = deciveModel.WorkType;
            lifeStyleModel.Dust = deciveModel.Dust;
            lifeStyleModel.DustProtect = deciveModel.DustProtect;
            lifeStyleModel.Radiogen = deciveModel.Radiogen;
            lifeStyleModel.RadiogenProtect = deciveModel.RadiogenProtect;
            lifeStyleModel.Physical = deciveModel.Physical;
            lifeStyleModel.PhysicalProtect = deciveModel.PhysicalProtect;
            lifeStyleModel.Chem = deciveModel.Chem;
            lifeStyleModel.ChemProtect = deciveModel.ChemProtect;
            lifeStyleModel.Other = deciveModel.Other;
            lifeStyleModel.OtherProtect = deciveModel.OtherProtect;
            lifeStyleModel.DustProtectEx = deciveModel.DustProtectEx;
            lifeStyleModel.RadiogenProtectEx = deciveModel.RadiogenProtectEx;
            lifeStyleModel.PhysicalProtectEx = deciveModel.PhysicalProtectEx;
            lifeStyleModel.ChemProtectEx = deciveModel.ChemProtectEx;
            lifeStyleModel.OtherProtectEx = deciveModel.OtherProtectEx;

            if (StringPlus.toString(lifeStyleModel.CareerHarmFactorHistory) != "")
            {
                sb.Append("CareerHarmFactorHistory='" + lifeStyleModel.CareerHarmFactorHistory + "',");
            }
            if (StringPlus.toString(lifeStyleModel.WorkType) != "")
            {
                sb.Append("WorkType='" + lifeStyleModel.WorkType + "',");
            }
            if (decimal.TryParse(deciveModel.WorkTime, out decimal8))
            {
                lifeStyleModel.WorkTime = decimal8;
                sb.Append("WorkTime='" + lifeStyleModel.WorkTime + "',");
            }
            if (StringPlus.toString(lifeStyleModel.Dust) != "")
            {
                sb.Append("Dust='" + lifeStyleModel.Dust + "',");
            }
            if (StringPlus.toString(lifeStyleModel.DustProtect) != "")
            {
                sb.Append("DustProtect='" + lifeStyleModel.DustProtect + "',");
            }
            if (StringPlus.toString(lifeStyleModel.Radiogen) != "")
            {
                sb.Append("Radiogen='" + lifeStyleModel.Radiogen + "',");
            }
            if (StringPlus.toString(lifeStyleModel.RadiogenProtect) != "")
            {
                sb.Append("RadiogenProtect='" + lifeStyleModel.RadiogenProtect + "',");
            }
            if (StringPlus.toString(lifeStyleModel.Physical) != "")
            {
                sb.Append("Physical='" + lifeStyleModel.Physical + "',");
            }
            if (StringPlus.toString(lifeStyleModel.PhysicalProtect) != "")
            {
                sb.Append("PhysicalProtect='" + lifeStyleModel.PhysicalProtect + "',");
            }
            if (StringPlus.toString(lifeStyleModel.Chem) != "")
            {
                sb.Append("Chem='" + lifeStyleModel.Chem + "',");
            }
            if (StringPlus.toString(lifeStyleModel.ChemProtect) != "")
            {
                sb.Append("ChemProtect='" + lifeStyleModel.ChemProtect + "',");
            }
            if (StringPlus.toString(lifeStyleModel.Other) != "")
            {
                sb.Append("Other='" + lifeStyleModel.Other + "',");
            }
            if (StringPlus.toString(lifeStyleModel.OtherProtect) != "")
            {
                sb.Append("OtherProtect='" + lifeStyleModel.OtherProtect + "',");
            }
            if (StringPlus.toString(lifeStyleModel.DustProtectEx) != "")
            {
                sb.Append("DustProtectEx='" + lifeStyleModel.DustProtectEx + "',");
            }
            if (StringPlus.toString(lifeStyleModel.RadiogenProtectEx) != "")
            {
                sb.Append("RadiogenProtectEx='" + lifeStyleModel.RadiogenProtectEx + "',");
            }
            if (StringPlus.toString(lifeStyleModel.PhysicalProtectEx) != "")
            {
                sb.Append("PhysicalProtectEx='" + lifeStyleModel.PhysicalProtectEx + "',");
            }
            if (StringPlus.toString(lifeStyleModel.ChemProtectEx) != "")
            {
                sb.Append("ChemProtectEx='" + lifeStyleModel.ChemProtectEx + "',");
            }
            if (StringPlus.toString(lifeStyleModel.OtherProtectEx) != "")
            {
                sb.Append("OtherProtectEx='" + lifeStyleModel.OtherProtectEx + "',");
            }

            if (sb.ToString() != "UPDATE ARCHIVE_LIFESTYLE D SET ")
            {
                string upStr = sb.ToString().Substring(0, sb.ToString().Length - 1);

                upStr += string.Format(@" WHERE EXISTS
                                                                (
                                                                    SELECT 
                                                                        ID 
                                                                    FROM
                                                                        ARCHIVE_CUSTOMERBASEINFO M
                                                                    WHERE M.ID = D.OutKey
                                                                        AND M.IDCardNo = '{0}'
                                                                        AND M.CheckDate = '{1}'
                                                                ) ", deciveModel.IDCardNo, deciveModel.RecordDate);

                successNum = MySQLHelper.ExecuteSql(upStr);
            }

            if (successNum > 0) flag = true;

            sb.Clear();
            successNum = 0;

            #endregion

            #region 健康问题

            healthQuestionModel = new RecordsHealthQuestionModel();
            healthQuestionModel.IDCardNo = deciveModel.IDCardNo;
            healthQuestionModel.BrainDis = deciveModel.BrainDis;//34
            healthQuestionModel.RenalDis = deciveModel.RenalDis;//35
            healthQuestionModel.HeartDis = deciveModel.HeartDis;//36
            healthQuestionModel.VesselDis = deciveModel.VesselDis;//37
            healthQuestionModel.EyeDis = deciveModel.EyeDis;//38
            healthQuestionModel.NerveDis = deciveModel.NerveDis;//39
            healthQuestionModel.ElseDis = deciveModel.ElseDis;//40

            if (versionNo.Contains("山东"))
            {
                healthQuestionModel.NerveDis = deciveModel.NerveDis;
                healthQuestionModel.NerveOther = deciveModel.NerveDisEx;
            }
            else
            {
                string[] nerveDis = StringPlus.toString(deciveModel.NerveDis).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string nerveDisEx = deciveModel.NerveDisEx + ";";

                // 如果选项只有1个，并且不等于4，并且异常内容中有值时，则为未发现与有 两个选项的版本
                if (nerveDis.Length == 1 && nerveDis[0] != "4" && nerveDisEx.Length > 1)
                {
                    healthQuestionModel.NerveDis = deciveModel.NerveDis;
                    healthQuestionModel.NerveOther = deciveModel.NerveDisEx;
                }
                else
                {
                    for (int j = 0; j < nerveDis.Length; j++)
                    {
                        switch (nerveDis[j])
                        {
                            case "1":
                                healthQuestionModel.NerveDis = "1";
                                break;
                            case "2":
                                healthQuestionModel.NerveDis = "2";
                                nerveDisEx += "阿尔茨海默病(老年性痴呆);";
                                break;
                            case "3":
                                healthQuestionModel.NerveDis = "2";
                                nerveDisEx += "帕金森病;";
                                break;
                            case "4":
                                healthQuestionModel.NerveDis = "2";
                                break;
                        }
                    }
                }

                healthQuestionModel.NerveOther = nerveDisEx.TrimStart(';').TrimEnd(';');
            }

            if (area.Equals("武威") || versionNo.Contains("山东"))
            {
                healthQuestionModel.ElseOther = deciveModel.ElseDisEx;
                healthQuestionModel.ElseDis = deciveModel.ElseDis;
            }
            else
            {
                string[] elseDis = StringPlus.toString(deciveModel.ElseDis).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string elseDisEx = deciveModel.ElseDisEx + ";";

                if (versionNo.Contains("贵州"))
                {
                    for (int j = 0; j < elseDis.Length; j++)
                    {
                        switch (elseDis[j])
                        {
                            case "1":
                                healthQuestionModel.ElseDis = "1";
                                break;
                            case "2":
                                healthQuestionModel.ElseDis = "2";
                                elseDisEx += "精神分裂症;";
                                break;
                            case "3":
                                healthQuestionModel.ElseDis = "2";
                                elseDisEx += "分裂情感型障碍;";
                                break;
                            case "4":
                                healthQuestionModel.ElseDis = "2";
                                elseDisEx += "偏执型精神病;";
                                break;
                            case "5":
                                healthQuestionModel.ElseDis = "2";
                                elseDisEx += "双相情感障碍;";
                                break;
                            case "6":
                                healthQuestionModel.ElseDis = "2";
                                elseDisEx += "癫痫所致精神障碍;";
                                break;
                            case "7":
                                healthQuestionModel.ElseDis = "2";
                                elseDisEx += "精神发育迟滞办法精神障碍;";
                                break;
                            case "8":
                                healthQuestionModel.ElseDis = "2";
                                elseDisEx += "原发性高血压;";
                                break;
                            case "9":
                                healthQuestionModel.ElseDis = "2";
                                elseDisEx += "Ⅱ型糖尿病;";
                                break;
                            case "10":
                                healthQuestionModel.ElseDis = "2";
                                break;
                        }
                    }
                }
                else if (versionNo.Contains("四川")) // 四川
                {
                    // 如果选项只有1个，并且不等于7，并且异常内容中有值时，则为未发现与有 两个选项的版本
                    if (elseDis.Length == 1 && elseDis[0] != "7" && elseDisEx.Length > 1)
                    {
                        healthQuestionModel.ElseDis = deciveModel.ElseDis;
                        healthQuestionModel.ElseOther = deciveModel.ElseDisEx;
                    }
                    else
                    {
                        for (int j = 0; j < elseDis.Length; j++)
                        {
                            switch (elseDis[j])
                            {
                                case "1":
                                    healthQuestionModel.ElseDis = "1";
                                    break;
                                case "2":
                                    healthQuestionModel.ElseDis = "2";
                                    elseDisEx += "糖尿病;";
                                    break;
                                case "3":
                                    healthQuestionModel.ElseDis = "2";
                                    elseDisEx += "慢性支气管炎;";
                                    break;
                                case "4":
                                    healthQuestionModel.ElseDis = "2";
                                    elseDisEx += "慢性阻塞性肺气肿;";
                                    break;
                                case "5":
                                    healthQuestionModel.ElseDis = "2";
                                    elseDisEx += "恶性肿瘤;";
                                    break;
                                case "6":
                                    healthQuestionModel.ElseDis = "2";
                                    elseDisEx += "老年性关节病;";
                                    break;
                                case "7":
                                    healthQuestionModel.ElseDis = "2";
                                    elseDisEx += "Ⅱ型糖尿病;";
                                    break;
                                case "8":
                                    healthQuestionModel.ElseDis = "2";
                                    elseDisEx += "原发性高血压;";
                                    break;
                                case "9":
                                    healthQuestionModel.ElseDis = "2";
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    // 如果选项只有1个，并且不等于7，并且异常内容中有值时，则为未发现与有 两个选项的版本
                    if (elseDis.Length == 1 && elseDis[0] != "7" && elseDisEx.Length > 1)
                    {
                        healthQuestionModel.ElseDis = deciveModel.ElseDis;
                        healthQuestionModel.ElseOther = deciveModel.ElseDisEx;
                    }
                    else
                    {
                        for (int j = 0; j < elseDis.Length; j++)
                        {
                            switch (elseDis[j])
                            {
                                case "1":
                                    healthQuestionModel.ElseDis = "1";
                                    break;
                                case "2":
                                    healthQuestionModel.ElseDis = "2";
                                    elseDisEx += "糖尿病;";
                                    break;
                                case "3":
                                    healthQuestionModel.ElseDis = "2";
                                    elseDisEx += "慢性支气管炎;";
                                    break;
                                case "4":
                                    healthQuestionModel.ElseDis = "2";
                                    elseDisEx += "慢性阻塞性肺气肿;";
                                    break;
                                case "5":
                                    healthQuestionModel.ElseDis = "2";
                                    elseDisEx += "恶性肿瘤;";
                                    break;
                                case "6":
                                    healthQuestionModel.ElseDis = "2";
                                    elseDisEx += "老年性关节病;";
                                    break;
                                case "7":
                                    healthQuestionModel.ElseDis = "2";
                                    break;
                            }
                        }
                    }
                }

                healthQuestionModel.ElseOther = elseDisEx.TrimStart(';').TrimEnd(';');
            }

            healthQuestionModel.BrainOther = deciveModel.BrainDisEx;
            healthQuestionModel.RenalOther = deciveModel.RenalDisEx;
            healthQuestionModel.HeartOther = deciveModel.HeartDisEx;
            healthQuestionModel.VesselOther = deciveModel.VesselDisEx;
            healthQuestionModel.EyeOther = deciveModel.EyeDisEx;

            sb.Append("UPDATE ARCHIVE_HEALTHQUESTION D SET ");

            if (StringPlus.toString(healthQuestionModel.BrainDis) != "")
            {
                sb.Append("BrainDis='" + healthQuestionModel.BrainDis + "',");
                sb.Append("BrainOther='" + healthQuestionModel.BrainOther + "',");
            }
            if (StringPlus.toString(healthQuestionModel.RenalDis) != "")
            {
                sb.Append("RenalDis='" + healthQuestionModel.RenalDis + "',");
                sb.Append("RenalOther='" + healthQuestionModel.RenalOther + "',");
            }
            if (StringPlus.toString(healthQuestionModel.HeartDis) != "")
            {
                sb.Append("HeartDis='" + healthQuestionModel.HeartDis + "',");
                sb.Append("HeartOther='" + healthQuestionModel.HeartOther + "',");
            }
            if (StringPlus.toString(healthQuestionModel.VesselDis) != "")
            {
                sb.Append("VesselDis='" + healthQuestionModel.VesselDis + "',");
                sb.Append("VesselOther='" + healthQuestionModel.VesselOther + "',");
            }
            if (StringPlus.toString(healthQuestionModel.EyeDis) != "")
            {
                sb.Append("EyeDis='" + healthQuestionModel.EyeDis + "',");
                sb.Append("EyeOther='" + healthQuestionModel.EyeOther + "',");
            }
            if (StringPlus.toString(healthQuestionModel.NerveDis) != "")
            {
                sb.Append("NerveDis='" + healthQuestionModel.NerveDis + "',");
                sb.Append("NerveOther='" + healthQuestionModel.NerveOther + "',");
            }
            if (StringPlus.toString(healthQuestionModel.ElseDis) != "")
            {
                sb.Append("ElseDis='" + healthQuestionModel.ElseDis + "',");
                sb.Append("ElseOther='" + healthQuestionModel.ElseOther + "',");
            }

            if (sb.ToString() != "UPDATE ARCHIVE_HEALTHQUESTION D SET ")
            {
                string upStr = sb.ToString().Substring(0, sb.ToString().Length - 1);

                upStr += string.Format(@" WHERE EXISTS
                                                                (
                                                                    SELECT 
                                                                        ID 
                                                                    FROM
                                                                        ARCHIVE_CUSTOMERBASEINFO M
                                                                    WHERE M.ID = D.OutKey
                                                                        AND M.IDCardNo = '{0}'
                                                                        AND M.CheckDate = '{1}'
                                                                ) ", deciveModel.IDCardNo, deciveModel.RecordDate);

                successNum = MySQLHelper.ExecuteSql(upStr);
            }

            if (successNum > 0) flag = true;

            sb.Clear();
            successNum = 0;

            #endregion

            #region 脏器功能

            //ARCHIVE_VISCERAFUNCTION,Lips,ToothResides,Pharyngeal,LeftView,RightView,LeftEyecorrect,RightEyecorrect,Listen,
            //SportFunction,HypodontiaEx,SaprodontiaEx,DentureEx,12
            visceraFunctionModel = new RecordsVisceraFunctionModel();
            visceraFunctionModel.IDCardNo = deciveModel.IDCardNo;
            visceraFunctionModel.Lips = deciveModel.Lips;//17
            visceraFunctionModel.ToothResides = deciveModel.ToothResides;//18
            visceraFunctionModel.Pharyngeal = deciveModel.Pharyngeal;//19
            visceraFunctionModel.Listen = deciveModel.Listen;//20
            visceraFunctionModel.SportFunction = deciveModel.SportFunction;//21
            visceraFunctionModel.HypodontiaEx = deciveModel.HypodontiaEx;
            visceraFunctionModel.SaprodontiaEx = deciveModel.SaprodontiaEx;
            visceraFunctionModel.DentureEx = deciveModel.DentureEx;

            sb.Append("UPDATE ARCHIVE_VISCERAFUNCTION D SET ");

            if (StringPlus.toString(visceraFunctionModel.Lips) != "")
            {
                sb.Append("Lips='" + visceraFunctionModel.Lips + "',");
            }
            if (StringPlus.toString(visceraFunctionModel.ToothResides) != "")
            {
                sb.Append("ToothResides='" + visceraFunctionModel.ToothResides + "',");

                sb.Append("HypodontiaEx='" + StringPlus.toString(visceraFunctionModel.HypodontiaEx).Replace("\\", "\\\\") + "',"); // 缺齿  
                sb.Append("SaprodontiaEx='" + StringPlus.toString(visceraFunctionModel.SaprodontiaEx).Replace("\\", "\\\\") + "',");// 龋齿
                sb.Append("DentureEx='" + StringPlus.toString(visceraFunctionModel.DentureEx).Replace("\\", "\\\\") + "',");// 义齿(假牙)
            }
            if (StringPlus.toString(visceraFunctionModel.Pharyngeal) != "")
            {
                sb.Append("Pharyngeal='" + visceraFunctionModel.Pharyngeal + "',");
            }
            if (StringPlus.toString(visceraFunctionModel.Listen) != "")
            {
                sb.Append("Listen='" + visceraFunctionModel.Listen + "',");
            }
            if (StringPlus.toString(visceraFunctionModel.SportFunction) != "")
            {
                sb.Append("SportFunction='" + visceraFunctionModel.SportFunction + "',");
            }

            decimal visdim1, visdim2, visdim3, visdim4;
            if (decimal.TryParse(deciveModel.LeftView, out visdim1))
            {
                visceraFunctionModel.LeftView = visdim1;
                sb.Append("LeftView='" + visceraFunctionModel.LeftView + "',");
            }
            if (decimal.TryParse(deciveModel.RightView, out visdim2))
            {
                visceraFunctionModel.RightView = visdim2;
                sb.Append("RightView='" + visceraFunctionModel.RightView + "',");
            }
            if (decimal.TryParse(deciveModel.LeftEyecorrect, out visdim3))
            {
                visceraFunctionModel.LeftEyecorrect = visdim3;
                sb.Append("LeftEyecorrect='" + visceraFunctionModel.LeftEyecorrect + "',");
            }
            if (decimal.TryParse(deciveModel.RightEyecorrect, out visdim4))
            {
                visceraFunctionModel.RightEyecorrect = visdim4;
                sb.Append("RightEyecorrect='" + visceraFunctionModel.RightEyecorrect + "',");
            }

            if (sb.ToString() != "UPDATE ARCHIVE_VISCERAFUNCTION D SET ")
            {
                string upStr = sb.ToString().Substring(0, sb.ToString().Length - 1);

                upStr += string.Format(@" WHERE EXISTS
                                                                (
                                                                    SELECT 
                                                                        ID 
                                                                    FROM
                                                                        ARCHIVE_CUSTOMERBASEINFO M
                                                                    WHERE M.ID = D.OutKey
                                                                        AND M.IDCardNo = '{0}'
                                                                        AND M.CheckDate = '{1}'
                                                                ) ", deciveModel.IDCardNo, deciveModel.RecordDate);

                successNum = MySQLHelper.ExecuteSql(upStr);
            }

            if (successNum > 0) flag = true;

            sb.Clear();
            successNum = 0;

            #endregion

            #region 查体

            physicalExamModel = new RecordsPhysicalExamModel();
            physicalExamModel.IDCardNo = deciveModel.IDCardNo;
            physicalExamModel.BarrelChest = deciveModel.BarrelChest;//22
            physicalExamModel.BreathSounds = deciveModel.BreathSounds;//23
            physicalExamModel.Rale = deciveModel.Rale;//24
            physicalExamModel.HeartRhythm = deciveModel.HeartRhythm;//25
            physicalExamModel.Noise = deciveModel.Noise;//26
            physicalExamModel.PressPain = deciveModel.PressPain;//27
            physicalExamModel.EnclosedMass = deciveModel.EnclosedMass;//28
            physicalExamModel.Liver = deciveModel.Liver;//29
            physicalExamModel.Spleen = deciveModel.Spleen;//30
            physicalExamModel.Voiced = deciveModel.Voiced;//31
            physicalExamModel.Edema = deciveModel.Edema;//32
            physicalExamModel.FootBack = deciveModel.FootBack;//33
            physicalExamModel.RaleEx = deciveModel.RaleEx;
            physicalExamModel.BreathSoundsEx = deciveModel.BreathSoundsEx;
            physicalExamModel.NoiseEx = deciveModel.NoiseEx;
            physicalExamModel.PressPainEx = deciveModel.PressPainEx;
            physicalExamModel.EnclosedMassEx = deciveModel.EnclosedMassEx;
            physicalExamModel.LiverEx = deciveModel.LiverEx;
            physicalExamModel.SpleenEx = deciveModel.SpleenEx;
            physicalExamModel.VoicedEx = deciveModel.VoicedEx;
            physicalExamModel.Hunchback = deciveModel.Hunchback;

            sb.Append("UPDATE ARCHIVE_PHYSICALEXAM D SET ");

            if (StringPlus.toString(physicalExamModel.BarrelChest) != "")
            {
                sb.Append("BarrelChest='" + physicalExamModel.BarrelChest + "',");
            }
            if (StringPlus.toString(physicalExamModel.BreathSounds) != "")
            {
                sb.Append("BreathSounds='" + physicalExamModel.BreathSounds + "',");
                sb.Append("BreathSoundsEx='" + physicalExamModel.BreathSoundsEx + "',");
            }
            if (StringPlus.toString(physicalExamModel.Rale) != "")
            {
                sb.Append("Rale='" + physicalExamModel.Rale + "',");
                sb.Append("RaleEx='" + physicalExamModel.RaleEx + "',");
            }
            if (StringPlus.toString(physicalExamModel.HeartRhythm) != "")
            {
                sb.Append("HeartRhythm='" + physicalExamModel.HeartRhythm + "',");
            }
            if (StringPlus.toString(physicalExamModel.Noise) != "")
            {
                sb.Append("Noise='" + physicalExamModel.Noise + "',");
                sb.Append("NoiseEx='" + physicalExamModel.NoiseEx + "',");
            }
            if (StringPlus.toString(physicalExamModel.PressPain) != "")
            {
                sb.Append("PressPain='" + physicalExamModel.PressPain + "',");
                sb.Append("PressPainEx='" + physicalExamModel.PressPainEx + "',");
            }
            if (StringPlus.toString(physicalExamModel.EnclosedMass) != "")
            {
                sb.Append("EnclosedMass='" + physicalExamModel.EnclosedMass + "',");
                sb.Append("EnclosedMassEx='" + physicalExamModel.EnclosedMassEx + "',");
            }
            if (StringPlus.toString(physicalExamModel.Liver) != "")
            {
                sb.Append("Liver='" + physicalExamModel.Liver + "',");
                sb.Append("LiverEx='" + physicalExamModel.LiverEx + "',");
            }
            if (StringPlus.toString(physicalExamModel.Spleen) != "")
            {
                sb.Append("Spleen='" + physicalExamModel.Spleen + "',");
                sb.Append("SpleenEx='" + physicalExamModel.SpleenEx + "',");
            }
            if (StringPlus.toString(physicalExamModel.Voiced) != "")
            {
                sb.Append("Voiced='" + physicalExamModel.Voiced + "',");
                sb.Append("VoicedEx='" + physicalExamModel.VoicedEx + "',");
            }
            if (StringPlus.toString(physicalExamModel.Edema) != "")
            {
                sb.Append("Edema='" + physicalExamModel.Edema + "',");
            }
            if (StringPlus.toString(physicalExamModel.FootBack) != "")
            {
                sb.Append("FootBack='" + physicalExamModel.FootBack + "',");
            }
            if (StringPlus.toString(physicalExamModel.Hunchback) != "")
            {
                sb.Append("Hunchback='" + physicalExamModel.Hunchback + "',");
            }
            if (sb.ToString() != "UPDATE ARCHIVE_PHYSICALEXAM D SET ")
            {
                string upStr = sb.ToString().Substring(0, sb.ToString().Length - 1);

                upStr += string.Format(@" WHERE EXISTS
                                                                (
                                                                    SELECT 
                                                                        ID 
                                                                    FROM
                                                                        ARCHIVE_CUSTOMERBASEINFO M
                                                                    WHERE M.ID = D.OutKey
                                                                        AND M.IDCardNo = '{0}'
                                                                        AND M.CheckDate = '{1}'
                                                                ) ", deciveModel.IDCardNo, deciveModel.RecordDate);

                successNum = MySQLHelper.ExecuteSql(upStr);
            }

            if (successNum > 0) flag = true;

            #endregion

            return flag;
        }
    }
}