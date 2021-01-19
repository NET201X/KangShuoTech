using MySql.Data.MySqlClient;
using CommonUtilities.SQL;
using System;
using System.Data;
using System.Text;
using CommomUtilities.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsBaseInfoDAL
    {
        // 数据库名称
        string BackData = ConfigHelper.GetSetNode("BackData");

        /// <summary>
        /// 批量汇出
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere, string orderBy)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT T.IDCardNo,B.CheckDate");
            builder.Append(" FROM ARCHIVE_BASEINFO T LEFT JOIN  ");
            builder.Append(" (SELECT a.IDCardNo, a.ID,a.CheckDate,a.doctor FROM ARCHIVE_CUSTOMERBASEINFO a ");

            if (!strWhere.Contains("B.CheckDate"))
            {
                builder.Append(" WHERE a.CheckDate=(SELECT MAX(c.CheckDate) FROM ARCHIVE_CUSTOMERBASEINFO c WHERE a.IDCardNo=c.IDCardNo)");
            }

            builder.Append(" ) B ON T.IDCardNo=B.IDCardNo");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            if (!string.IsNullOrEmpty(orderBy.Trim()))
            {
                builder.Append(" ORDER BY T." + orderBy);
            }
            else builder.Append(" ORDER BY T.ID DESC");

            return MySQLHelper.Query(builder.ToString());
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT COUNT(1) FROM ARCHIVE_BASEINFO T ");
            builder.Append(" LEFT JOIN (SELECT a.IDCardNo, a.ID,a.CheckDate FROM ARCHIVE_CUSTOMERBASEINFO a ");
            if (!strWhere.Contains("B.CheckDate"))
            {
                builder.Append(" WHERE  a.CheckDate = (SELECT max(c.CheckDate) FROM ARCHIVE_CUSTOMERBASEINFO c  WHERE a.IDCardNo = c.IDCardNo )");
            }

            builder.Append(" ) B ON T.IDCardNo = B.IDCardNo  ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public DataSet GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT T.ID,T.RecordID,T.IDCardNo,T.OrgProvinceID,T.OrgCityID,T.OrgDistrictID,T.OrgTownID,T.OrgVillageID,T.ProvinceID,T.CityID,");
            builder.Append("T.DistrictID,T.TownID,T.VillageID,T.WorkUnit,T.LiveType,T.Nation,T.RH,T.Culture,T.Job,T.MaritalStatus,T.MedicalPayType,");
            builder.Append("T.DrugAllergic,T.Disease,T.DiseasEndition,T.CustomerName,T.Doctor,T.Sex,T.Birthday,T.ContactName,T.ContactPhone,");
            builder.Append("T.BloodType,T.Phone,T.MedicalPayTypeOther,T.DrugAllergicOther,T.DiseaseEx,T.DiseasEnditionEx,T.CustomerID, ");
            builder.Append("T.Address,T.HouseHoldAddress,T.CreateUnit,T.Minority,T.Exposure,T.CreateBy, ");
            builder.Append("(case T.CreateDate when null then null when '' then null else T.CreateDate end)CreateDate,  ");
            builder.Append("T.LastUpdateBy,(case T.LastUpdateDate when null then null when '' then null else T.LastUpdateDate end ) AS LastUpdateDate,");
            builder.Append("T.PopulationType,T.FamilyIDCardNo,T.HouseRelation,T.HouseRealOther,T.Email,T.IsDelete,T.IsUpdate,T.TownName,");
            builder.Append("T.VillageName,T.CreateUnitName,T.CreateMenName, B.CheckDate ,B.ID AS CustomerID");
            builder.Append(" FROM ARCHIVE_BASEINFO T LEFT JOIN  ");
            builder.Append(" (SELECT a.IDCardNo, a.ID,a.CheckDate FROM ARCHIVE_CUSTOMERBASEINFO a ");

            if (!strWhere.Contains("B.CheckDate"))
            {
                builder.Append(" WHERE a.CheckDate = (SELECT MAX(c.CheckDate) FROM ARCHIVE_CUSTOMERBASEINFO c WHERE a.IDCardNo = c.IDCardNo) ");
            }

            builder.Append(" ) B ON T.IDCardNo=B.IDCardNo");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderBy.Trim()))
            {
                builder.Append(" ORDER BY T." + orderBy);
            }
            else
            {
                builder.Append(" ORDER BY T.ID DESC");
            }

            builder.Append(string.Format(" LIMIT {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetTownList()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT  DISTINCT(TownName) FROM ARCHIVE_BASEINFO");
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetUserDt(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT distinct T.CreateMenName,T.ID,T.PopulationType ");
            builder.Append(" FROM ARCHIVE_BASEINFO T LEFT JOIN ARCHIVE_CUSTOMERBASEINFO B ON T.IDCardNo = B.IDCardNo ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            builder.Append(" group by T.CreateMenName ");
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT ");
            builder.Append("a.*,b.CustomerName AS HouseName FROM ARCHIVE_BASEINFO a ");
            builder.Append("LEFT JOIN ARCHIVE_BASEINFO b ON a.FamilyIDCardNo = b.IDCardNo ");
            builder.Append(" WHERE a.IDCardNo=@IDCardNo");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }

        public int DeleteIDCard(string idCardNo)
        {
            if (BackData == "") BackData = "kangshuo_db";

            // 取得数据库中所有表名
            List<string> list = MySQLHelper.GetList("SELECT table_name FROM information_schema.tables WHERE table_schema='" + BackData + "' ORDER BY table_name");
            ArrayList sQLStringList = new ArrayList();

            string[] strArray = new string[] {"CD_CHD_BASEINFO", "CD_CHD_FOLLOWUP", "CD_DIABETES_BASEINFO",
                "CD_DIABETESFOLLOWUP", "CD_DRUGCONDITION",  "CD_HYPERTENSION_BASEINFO", "CD_HYPERTENSIONFOLLOWUP", "CD_PTB_FIRSTVISIT",
                "CD_PTB_VISIT", "CD_MENTALDISEASE_BASEINFO", "CD_MENTALDISEASE_FOLLOWUP", "CD_STROKE_BASEINFO",
                "CD_STROKE_FOLLOWUP", "tbl_chronictumor", "ARCHIVE_RECEPTION_RECORD", "ARCHIVE_CONSULTATION_RECORD", "CHILD_BASEINFO",
                "CHILD_NEWBORN_FOLLOWUP", "CHILD_ONE2THREE_YEAR_OLD", "CHILD_TCMHM_ONE", "CHILD_TCMHM_ONE2THREE", "CHILD_TCMHM_THREE2SIX",
                "CHILD_THREE2SIX_YEAR_OLD", "CHILD_WITHIN_ONE_YEAR_OLD",  "OLD_MEDICINE_CN", "OLD_MEDICINE_RESULT",
                "OLDER_SELFCAREABILITY","ARCHIVE_ASSESSMENTGUIDE", "ARCHIVE_ASSISTCHECK", "ARCHIVE_ECG", "ARCHIVE_DEVICEINFO",
                "ARCHIVE_FAMILY_INFO", "ARCHIVE_EDUCATION_ACTIVITIES", "ARCHIVE_ENVIRONMENT", "ARCHIVE_FAMILYBEDHISTORY",
                "ARCHIVE_FAMILYHISTORYINFO", "ARCHIVE_GENERALCONDITION", "ARCHIVE_HEALTH_HOUSE", "ARCHIVE_HEALTHQUESTION",
                "ARCHIVE_HOSPITALHISTORY", "ARCHIVE_ILLNESSHISTORYINFO", "ARCHIVE_INOCULATIONHISTORY",
                "ARCHIVE_LIFESTYLE", "ARCHIVE_MEDICATION", "ARCHIVE_MEDICINE_CN", "OLD_MEDICINE_RESULT", "ARCHIVE_MEDI_PHYS_DIST",
                "ARCHIVE_PHYSICALEXAM", "ARCHIVE_SELFCAREABILITY", "ARCHIVE_SIGNATURE", "ARCHIVE_VISCERAFUNCTION", "ARCHIVE_BLOODTEST",
                "GRAVIDA_BASEINFO", "GRAVIDA_FIRSTFOLLOWUP", "GRAVIDA_POSTPARTUM", "GRAVIDA_POSTPARTUM_42DAY",
                "GRAVIDA_PRE_ASSISTCHECK", "GRAVIDA_TWO2FIVE_FOLLOWUP", "tbl_RecordsPersonInfo",  "ARCHIVE_BASEINFO_OUT",
                "ARCHIVE_CUSTOMERBASEINFO"
            };

            ArrayList al = new ArrayList(strArray);

            for (int i = strArray.Length - 1; i >= 0; i--)
            {
                string value = strArray[i];

                if (list.Count(p => p == value) <= 0) al.RemoveAt(i);
            }

            foreach (string str2 in list)
            {
                sQLStringList.Add(string.Format("DELETE FROM {0} WHERE IDCardNo IN({1});", str2, idCardNo));
            }

            MySQLHelper.ExecuteSqlTran(sQLStringList);

            return 0;
        }

        /// <summary>
        /// 取得批量删除资料
        /// </summary>
        /// <param name="CreateDateS"></param>
        /// <param name="CreateDateE"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public string GetIDCardNo(string CreateDateS, string CreateDateE, string conn)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT GROUP_CONCAT(DISTINCT IDCardNo) AS IDCardNo  ");
            builder.Append(" FROM ARCHIVE_BASEINFO ");
            builder.Append(" WHERE CreateDate BETWEEN @CreateDateS AND @CreateDateE ");
            
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CreateDateS", CreateDateS),
                new MySqlParameter("@CreateDateE", CreateDateE)
            };

            object obj = MySQLHelper.ExecuteScalar(builder.ToString(), conn, cmdParms);

            return obj != null ? obj.ToString() : "";
        }

        public bool Delete(string CreateDateS, string CreateDateE)
        {
            if (BackData == "") BackData = "kangshuo_db";

            // 取得数据库中所有表名
            List<string> list = MySQLHelper.GetList("SELECT table_name FROM information_schema.tables WHERE table_schema='" + BackData + "' ORDER BY table_name");
            ArrayList sQLStringList = new ArrayList();

            string[] strArray = new string[] {"CD_CHD_BASEINFO", "CD_CHD_FOLLOWUP", "CD_DIABETES_BASEINFO",
                "CD_DIABETESFOLLOWUP", "CD_DRUGCONDITION",  "CD_HYPERTENSION_BASEINFO", "CD_HYPERTENSIONFOLLOWUP","CD_PTB_FIRSTVISIT", 
                "CD_PTB_VISIT", "CD_MENTALDISEASE_BASEINFO", "CD_MENTALDISEASE_FOLLOWUP", "CD_STROKE_BASEINFO",
                "CD_STROKE_FOLLOWUP",  "ARCHIVE_RECEPTION_RECORD", "ARCHIVE_CONSULTATION_RECORD", "CHILD_BASEINFO",
                "CHILD_NEWBORN_FOLLOWUP", "CHILD_ONE2THREE_YEAR_OLD", "CHILD_TCMHM_ONE", "CHILD_TCMHM_ONE2THREE", "CHILD_TCMHM_THREE2SIX",
                "CHILD_THREE2SIX_YEAR_OLD", "CHILD_WITHIN_ONE_YEAR_OLD", "tbl_oldbaseinfo", "OLD_MEDICINE_CN", "OLD_MEDICINE_RESULT",
                "OLDER_SELFCAREABILITY", "ARCHIVE_ASSESSMENTGUIDE", "ARCHIVE_ASSISTCHECK", "ARCHIVE_ECG", "ARCHIVE_DEVICEINFO",
                "ARCHIVE_FAMILY_INFO", "ARCHIVE_EDUCATION_ACTIVITIES", "ARCHIVE_ENVIRONMENT", "ARCHIVE_FAMILYBEDHISTORY",
                "ARCHIVE_FAMILYHISTORYINFO", "ARCHIVE_GENERALCONDITION", "ARCHIVE_HEALTH_HOUSE", "ARCHIVE_HEALTHQUESTION",
                "ARCHIVE_HOSPITALHISTORY", "ARCHIVE_ILLNESSHISTORYINFO", "tbl_recordsindhealthedu", "ARCHIVE_INOCULATIONHISTORY",
                "ARCHIVE_LIFESTYLE", "ARCHIVE_MEDICATION", "ARCHIVE_MEDICINE_CN", "OLD_MEDICINE_RESULT", "ARCHIVE_MEDI_PHYS_DIST",
                "ARCHIVE_PHYSICALEXAM", "ARCHIVE_SELFCAREABILITY", "ARCHIVE_SIGNATURE", "ARCHIVE_VISCERAFUNCTION", "ARCHIVE_BLOODTEST",
                "GRAVIDA_BASEINFO", "GRAVIDA_FIRSTFOLLOWUP", "GRAVIDA_POSTPARTUM", "GRAVIDA_POSTPARTUM_42DAY",
                "GRAVIDA_PRE_ASSISTCHECK", "GRAVIDA_TWO2FIVE_FOLLOWUP",  "ARCHIVE_BASEINFO_OUT",
                "ARCHIVE_CUSTOMERBASEINFO", "ARCHIVE_BASEINFO"
            };

            ArrayList al = new ArrayList(strArray);

            for (int i = strArray.Length - 1; i >= 0; i--)
            {
                string value = strArray[i].ToLower();

                if (list.Count(p => p == value) <= 0) al.RemoveAt(i);
            }

            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();

            string idCardNo = "'" + GetIDCardNo(CreateDateS, CreateDateE, conn).TrimEnd(',').Replace(",", "','") + "'";

            if (idCardNo == "") return false;

            foreach (string str2 in al)
            {
                sQLStringList.Add(string.Format("DELETE FROM {0} WHERE IDCardNo IN({1});", str2, idCardNo));
            }

            try
            {
                MySQLHelper.ExecuteSqlTran(sQLStringList, conn);
            }
            catch (Exception ex)
            {
                string str = "";
                for (int i = 0; i < sQLStringList.Count; i++)
                {
                    str += sQLStringList[i].ToString();
                }

                LogHelper.WriteLog(str);
                LogHelper.WriteLog(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
