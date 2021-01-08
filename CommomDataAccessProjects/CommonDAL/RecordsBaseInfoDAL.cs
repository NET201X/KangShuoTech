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
            builder.Append(" FROM tbl_recordsbaseinfo T LEFT JOIN  ");
            builder.Append(" (SELECT a.IDCardNo, a.ID,a.CheckDate,a.doctor FROM tbl_recordscustomerbaseinfo a ");

            if (!strWhere.Contains("B.CheckDate"))
            {
                builder.Append(" WHERE a.CheckDate=(SELECT MAX(c.CheckDate) FROM tbl_recordscustomerbaseinfo c WHERE a.IDCardNo=c.IDCardNo)");
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
            builder.Append("SELECT COUNT(1) FROM tbl_recordsbaseinfo T ");
            builder.Append(" LEFT JOIN (SELECT a.IDCardNo, a.ID,a.CheckDate FROM tbl_recordscustomerbaseinfo a ");
            if (!strWhere.Contains("B.CheckDate"))
            {
                builder.Append(" WHERE  a.CheckDate = (SELECT max(c.CheckDate) FROM tbl_recordscustomerbaseinfo c  WHERE a.IDCardNo = c.IDCardNo )");
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
            builder.Append(" FROM tbl_recordsbaseinfo T LEFT JOIN  ");
            builder.Append(" (SELECT a.IDCardNo, a.ID,a.CheckDate FROM tbl_recordscustomerbaseinfo a ");

            if (!strWhere.Contains("B.CheckDate"))
            {
                builder.Append(" WHERE a.CheckDate = (SELECT MAX(c.CheckDate) FROM tbl_recordscustomerbaseinfo c WHERE a.IDCardNo = c.IDCardNo) ");
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
            builder.Append("SELECT  DISTINCT(TownName) FROM tbl_recordsbaseinfo");
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetUserDt(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT distinct T.CreateMenName,T.ID,T.PopulationType ");
            builder.Append(" FROM tbl_recordsbaseinfo T LEFT JOIN tbl_recordscustomerbaseinfo B ON T.IDCardNo = B.IDCardNo ");
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
            builder.Append("a.*,b.CustomerName AS HouseName FROM tbl_RecordsBaseInfo a ");
            builder.Append("LEFT JOIN tbl_RecordsBaseInfo b ON a.FamilyIDCardNo = b.IDCardNo ");
            builder.Append(" WHERE a.IDCardNo=@IDCardNo");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }

        public int DeleteIDCard(string idCardNo)
        {
            if (BackData == "") BackData = "qcpaddb";

            // 取得数据库中所有表名
            List<string> list = MySQLHelper.GetList("SELECT table_name FROM information_schema.tables WHERE table_schema='" + BackData + "' ORDER BY table_name");
            ArrayList sQLStringList = new ArrayList();

            string[] strArray = new string[] {"tbl_chronicchdbaseinfo", "tbl_chronicchdvisit", "tbl_chronicdiabetesbaseinfo", "tbl_chronicdiabetesinfo",
                "tbl_chronicdiadetesvisit", "tbl_ChronicDrugCondition", "tbl_chronicendemicdiseasebaseinfo", "tbl_chronicendemicdiseasevisit",
                "tbl_chronicfluorideinfo", "tbl_ChronicHypertensionBaseInfo", "tbl_ChronicHypertensionVisit",
                "tbl_chroniciodineinfo", "tbl_chronickashinbeckinfo", "tbl_chronickeshaninfo", "tbl_chroniclungerfirstvisit", "tbl_chroniclungerscreen",
                "tbl_chroniclungervisit", "tbl_chronicmentaldiseasebaseinfo", "tbl_chronicmentaldiseasevisit", "tbl_chronicstrokebaseinfo",
                "tbl_chronicstrokevisit", "tbl_chronictumor", "tbl_clinacalrecievetreatinfo", "tbl_consultationbaseinfo", "tbl_kidsbaseinfo",
                "tbl_kidsnewbornvisit", "tbl_kidsonetothreeyearold", "tbl_kidstcmhmone", "tbl_kidstcmhmonetothree", "tbl_kidstcmhmthreetosix",
                "tbl_kidsthreetosixyearold", "tbl_kidswithinoneyearold", "tbl_oldbaseinfo", "tbl_oldermedicinecn", "tbl_oldermedicineresult",
                "tbl_olderselfcareability", "tbl_olderspecialregist", "tbl_oldervisit", "tbl_oldervisitregist", "tbl_oldmedguide", "tbl_oldpeoplevisit",
                "tbl_recordsassessmentguide", "tbl_recordsassistcheck", "tbl_recordsecg", "tbl_deviceinfo",
                "tbl_recordsfamilyinfo", "tbl_recordseducationactivities", "tbl_recordsenvironment", "tbl_recordsfamilybedhistory",
                "tbl_recordsfamilyhistoryinfo", "tbl_recordsgeneralcondition", "tbl_recordshealthhouse", "tbl_recordshealthquestion",
                "tbl_recordshospitalhistory", "tbl_recordsillnesshistoryinfo", "tbl_recordsindhealthedu", "tbl_recordsinoculationhistory",
                "tbl_recordslifestyle", "tbl_recordsmedication", "tbl_recordsmedicinecn", "tbl_recordsmedicineresult", "tbl_recordsmediphysdist",
                "tbl_recordsphysicalexam", "tbl_recordsselfcareability", "tbl_recordssignature", "tbl_recordsviscerafunction", "tbl_recordsxq",
                "tbl_womengravidabaseinfo", "tbl_womengravidafirstvisit", "tbl_womengravidapostpartum", "tbl_womengravidapostpartum42day",
                "tbl_womengravidapreassistcheck", "tbl_womengravidatwotofivevisit", "tbl_RecordsPersonInfo",  "tbl_HealthRecordsInfo",
                "tbl_RecordsCustomerBaseInfo"
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
            builder.Append(" FROM tbl_RecordsBaseInfo ");
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
            if (BackData == "") BackData = "qcpaddb";

            // 取得数据库中所有表名
            List<string> list = MySQLHelper.GetList("SELECT table_name FROM information_schema.tables WHERE table_schema='" + BackData + "' ORDER BY table_name");
            ArrayList sQLStringList = new ArrayList();

            string[] strArray = new string[] {"tbl_chronicchdbaseinfo", "tbl_chronicchdvisit", "tbl_chronicdiabetesbaseinfo", "tbl_chronicdiabetesinfo",
                "tbl_chronicdiadetesvisit", "tbl_ChronicDrugCondition", "tbl_chronicendemicdiseasebaseinfo", "tbl_chronicendemicdiseasevisit",
                "tbl_chronicfluorideinfo", "tbl_chronichyperinfo", "tbl_ChronicHypertensionBaseInfo", "tbl_ChronicHypertensionVisit",
                "tbl_chroniciodineinfo", "tbl_chronickashinbeckinfo", "tbl_chronickeshaninfo", "tbl_chroniclungerfirstvisit", "tbl_chroniclungerscreen",
                "tbl_chroniclungervisit", "tbl_chronicmentaldiseasebaseinfo", "tbl_chronicmentaldiseasevisit", "tbl_chronicstrokebaseinfo",
                "tbl_chronicstrokevisit", "tbl_chronictumor", "tbl_clinacalrecievetreatinfo", "tbl_consultationbaseinfo", "tbl_kidsbaseinfo",
                "tbl_kidsnewbornvisit", "tbl_kidsonetothreeyearold", "tbl_kidstcmhmone", "tbl_kidstcmhmonetothree", "tbl_kidstcmhmthreetosix",
                "tbl_kidsthreetosixyearold", "tbl_kidswithinoneyearold", "tbl_oldbaseinfo", "tbl_oldermedicinecn", "tbl_oldermedicineresult",
                "tbl_olderselfcareability", "tbl_olderspecialregist", "tbl_oldervisit", "tbl_oldervisitregist", "tbl_oldmedguide", "tbl_oldpeoplevisit",
                "tbl_recordsassessmentguide", "tbl_recordsassistcheck", "tbl_recordsecg", "tbl_deviceinfo",
                "tbl_recordsfamilyinfo", "tbl_recordseducationactivities", "tbl_recordsenvironment", "tbl_recordsfamilybedhistory",
                "tbl_recordsfamilyhistoryinfo", "tbl_recordsgeneralcondition", "tbl_recordshealthhouse", "tbl_recordshealthquestion",
                "tbl_recordshospitalhistory", "tbl_recordsillnesshistoryinfo", "tbl_recordsindhealthedu", "tbl_recordsinoculationhistory",
                "tbl_recordslifestyle", "tbl_recordsmedication", "tbl_recordsmedicinecn", "tbl_recordsmedicineresult", "tbl_recordsmediphysdist",
                "tbl_recordsphysicalexam", "tbl_recordsselfcareability", "tbl_recordssignature", "tbl_recordsviscerafunction", "tbl_recordsxq",
                "tbl_womengravidabaseinfo", "tbl_womengravidafirstvisit", "tbl_womengravidapostpartum", "tbl_womengravidapostpartum42day",
                "tbl_womengravidapreassistcheck", "tbl_womengravidatwotofivevisit", "tbl_RecordsPersonInfo",  "tbl_HealthRecordsInfo",
                "tbl_RecordsCustomerBaseInfo", "tbl_RecordsBaseInfo"
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
