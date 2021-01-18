namespace KangShuoTech.DataAccessProjects.DAL
{
    using Utilities.MySQLHelper;
    using Model;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsBaseInfoDAL
    {
        public int Add(RecordsBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_BASEINFO(");
            builder.Append("RecordID,IDCardNo,OrgProvinceID,OrgCityID,OrgDistrictID,OrgTownID,OrgVillageID,ProvinceID,CityID,DistrictID,TownID,VillageID,WorkUnit,LiveType,Nation,RH,Culture,Job,MaritalStatus,MedicalPayType,DrugAllergic,Disease,DiseasEndition,CustomerName,Doctor,Sex,Birthday,ContactName,ContactPhone,BloodType,Phone,MedicalPayTypeOther,DrugAllergicOther,DiseaseEx,DiseasEnditionEx,CustomerID,Address,HouseHoldAddress,CreateUnit,Minority,Exposure,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,PopulationType,FamilyIDCardNo,HouseRelation,HouseRealOther,Email,IsDelete,IsUpdate,TownName,VillageName,CreateUnitName,CreateMenName,");
            builder.Append("TownMedicalCard,ResidentMedicalCard,PovertyReliefMedicalCard,LiveCondition,FamilyNum,FamilyStructure,HouseName,PreSituation,PreNum,YieldNum,Chemical,Poison,Radial )");
            builder.Append(" values (");
            builder.Append("@RecordID,@IDCardNo,@OrgProvinceID,@OrgCityID,@OrgDistrictID,@OrgTownID,@OrgVillageID,@ProvinceID,@CityID,@DistrictID,@TownID,@VillageID,@WorkUnit,@LiveType,@Nation,@RH,@Culture,@Job,@MaritalStatus,@MedicalPayType,@DrugAllergic,@Disease,@DiseasEndition,@CustomerName,@Doctor,@Sex,@Birthday,@ContactName,@ContactPhone,@BloodType,@Phone,@MedicalPayTypeOther,@DrugAllergicOther,@DiseaseEx,@DiseasEnditionEx,@CustomerID,@Address,@HouseHoldAddress,@CreateUnit,@Minority,@Exposure,@CreateBy,@CreateDate,@LastUpdateBy,@LastUpdateDate,@PopulationType,@FamilyIDCardNo,@HouseRelation,@HouseRealOther,@Email,@IsDelete,@IsUpdate,@TownName,@VillageName,@CreateUnitName,@CreateMenName,");
            builder.Append("@TownMedicalCard,@ResidentMedicalCard,@PovertyReliefMedicalCard,@LiveCondition,@FamilyNum,@FamilyStructure,@HouseName,@PreSituation,@PreNum,@YieldNum,@Chemical,@Poison,@Radial)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@OrgProvinceID", MySqlDbType.Decimal),
                new MySqlParameter("@OrgCityID", MySqlDbType.Decimal), 
                new MySqlParameter("@OrgDistrictID", MySqlDbType.Decimal),
                new MySqlParameter("@OrgTownID", MySqlDbType.Decimal), 
                new MySqlParameter("@OrgVillageID", MySqlDbType.Decimal),
                new MySqlParameter("@ProvinceID", MySqlDbType.Decimal), 
                new MySqlParameter("@CityID", MySqlDbType.Decimal),
                new MySqlParameter("@DistrictID", MySqlDbType.Decimal),
                new MySqlParameter("@TownID", MySqlDbType.Decimal),
                new MySqlParameter("@VillageID", MySqlDbType.Decimal),
                new MySqlParameter("@WorkUnit", MySqlDbType.String, 200),
                new MySqlParameter("@LiveType", MySqlDbType.String, 1),
                new MySqlParameter("@Nation", MySqlDbType.String, 20),
                new MySqlParameter("@RH", MySqlDbType.String, 1), 
                new MySqlParameter("@Culture", MySqlDbType.String, 1),
                new MySqlParameter("@Job", MySqlDbType.String, 1), 
                new MySqlParameter("@MaritalStatus", MySqlDbType.String, 1),
                new MySqlParameter("@MedicalPayType", MySqlDbType.String, 30),
                new MySqlParameter("@DrugAllergic", MySqlDbType.String, 10),
                new MySqlParameter("@Disease", MySqlDbType.String, 1),
                new MySqlParameter("@DiseasEndition", MySqlDbType.String, 30),
                new MySqlParameter("@CustomerName", MySqlDbType.String, 30), 
                new MySqlParameter("@Doctor", MySqlDbType.String, 30), 
                new MySqlParameter("@Sex", MySqlDbType.String, 1),
                new MySqlParameter("@Birthday", MySqlDbType.Date),
                new MySqlParameter("@ContactName", MySqlDbType.String, 30),
                new MySqlParameter("@ContactPhone", MySqlDbType.String, 15), 
                new MySqlParameter("@BloodType", MySqlDbType.String, 1), 
                new MySqlParameter("@Phone", MySqlDbType.String, 15), 
                new MySqlParameter("@MedicalPayTypeOther", MySqlDbType.String, 50), 
                new MySqlParameter("@DrugAllergicOther", MySqlDbType.String, 200), 
                new MySqlParameter("@DiseaseEx", MySqlDbType.String, 200), 
                new MySqlParameter("@DiseasEnditionEx", MySqlDbType.String, 200), 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@Address", MySqlDbType.String, 200), 
                new MySqlParameter("@HouseHoldAddress", MySqlDbType.String, 200),
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@Minority", MySqlDbType.String, 30), 
                new MySqlParameter("@Exposure", MySqlDbType.String, 10), 
                new MySqlParameter("@CreateBy", MySqlDbType.String, 18), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String, 18), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@PopulationType", MySqlDbType.String, 50),
                new MySqlParameter("@FamilyIDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@HouseRelation", MySqlDbType.String, 10), 
                new MySqlParameter("@HouseRealOther", MySqlDbType.String, 20), 
                new MySqlParameter("@Email", MySqlDbType.String, 50),
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1), 
                new MySqlParameter("@IsUpdate", MySqlDbType.String, 1), 
                new MySqlParameter("@TownName", MySqlDbType.String, 32), 
                new MySqlParameter("@VillageName", MySqlDbType.String, 32), 
                new MySqlParameter("@CreateUnitName", MySqlDbType.String, 32), 
                new MySqlParameter("@CreateMenName", MySqlDbType.String, 32),
                new MySqlParameter("@TownMedicalCard", MySqlDbType.String, 50),
                new MySqlParameter("@ResidentMedicalCard", MySqlDbType.String, 50),
                new MySqlParameter("@PovertyReliefMedicalCard", MySqlDbType.String, 50),
                new MySqlParameter("@LiveCondition", MySqlDbType.String, 20),
                new MySqlParameter("@FamilyNum", MySqlDbType.Decimal),
                new MySqlParameter("@FamilyStructure", MySqlDbType.String, 100),
                new MySqlParameter("@HouseName", MySqlDbType.String, 100),
                new MySqlParameter("@PreSituation", MySqlDbType.String, 10),
                new MySqlParameter("@PreNum", MySqlDbType.String, 100),
                new MySqlParameter("@YieldNum", MySqlDbType.String, 100),
                new MySqlParameter("@Chemical", MySqlDbType.String, 100),
                new MySqlParameter("@Poison", MySqlDbType.String, 100),
                new MySqlParameter("@Radial", MySqlDbType.String, 100)
             };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.OrgProvinceID;
            cmdParms[3].Value = model.OrgCityID;
            cmdParms[4].Value = model.OrgDistrictID;
            cmdParms[5].Value = model.OrgTownID;
            cmdParms[6].Value = model.OrgVillageID;
            cmdParms[7].Value = model.ProvinceID;
            cmdParms[8].Value = model.CityID;
            cmdParms[9].Value = model.DistrictID;
            cmdParms[10].Value = model.TownID;
            cmdParms[11].Value = model.VillageID;
            cmdParms[12].Value = model.WorkUnit;
            cmdParms[13].Value = model.LiveType;
            cmdParms[14].Value = model.Nation;
            cmdParms[15].Value = model.RH;
            cmdParms[16].Value = model.Culture;
            cmdParms[17].Value = model.Job;
            cmdParms[18].Value = model.MaritalStatus;
            cmdParms[19].Value = model.MedicalPayType;
            cmdParms[20].Value = model.DrugAllergic;
            cmdParms[21].Value = model.Disease;
            cmdParms[22].Value = model.DiseasEndition;
            cmdParms[23].Value = model.CustomerName;
            cmdParms[24].Value = model.Doctor;
            cmdParms[25].Value = model.Sex;
            cmdParms[26].Value = model.Birthday;
            cmdParms[27].Value = model.ContactName;
            cmdParms[28].Value = model.ContactPhone;
            cmdParms[29].Value = model.BloodType;
            cmdParms[30].Value = model.Phone;
            cmdParms[31].Value = model.MedicalPayTypeOther;
            cmdParms[32].Value = model.DrugAllergicOther;
            cmdParms[33].Value = model.DiseaseEx;
            cmdParms[34].Value = model.DiseasEnditionEx;
            cmdParms[35].Value = model.CustomerID;
            cmdParms[36].Value = model.Address;
            cmdParms[37].Value = model.HouseHoldAddress;
            cmdParms[38].Value = model.CreateUnit;
            cmdParms[39].Value = model.Minority;
            cmdParms[40].Value = model.Exposure;
            cmdParms[41].Value = model.CreateBy;
            cmdParms[42].Value = model.CreateDate;
            cmdParms[43].Value = model.LastUpdateBy;
            cmdParms[44].Value = model.LastUpdateDate;
            cmdParms[45].Value = model.PopulationType;
            cmdParms[46].Value = model.FamilyIDCardNo;
            cmdParms[47].Value = model.HouseRelation;
            cmdParms[48].Value = model.HouseRealOther;
            cmdParms[49].Value = model.Email;
            cmdParms[50].Value = "N";
            cmdParms[51].Value = model.IsUpdate;
            cmdParms[52].Value = model.TownName;
            cmdParms[53].Value = model.VillageName;
            cmdParms[54].Value = model.CreateUnitName;
            cmdParms[55].Value = model.CreateMenName;
            cmdParms[56].Value = model.TownMedicalCard;
            cmdParms[57].Value = model.ResidentMedicalCard;
            cmdParms[58].Value = model.PovertyReliefMedicalCard;
            cmdParms[59].Value = model.LiveCondition;
            cmdParms[60].Value = model.FamilyNum;
            cmdParms[61].Value = model.FamilyStructure;
            cmdParms[62].Value = model.HouseName;
            cmdParms[63].Value = model.PreSituation;
            cmdParms[64].Value = model.PreNum;
            cmdParms[65].Value = model.YieldNum;
            cmdParms[66].Value = model.Chemical;
            cmdParms[67].Value = model.Poison;
            cmdParms[68].Value = model.Radial;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsBaseInfoModel DataRowToModel(DataRow row)
        {
            RecordsBaseInfoModel recordsBaseInfoModel = new RecordsBaseInfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsBaseInfoModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    recordsBaseInfoModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsBaseInfoModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["OrgProvinceID"] != null) && (row["OrgProvinceID"] != DBNull.Value)) && (row["OrgProvinceID"].ToString() != ""))
                {
                    recordsBaseInfoModel.OrgProvinceID = new decimal?(decimal.Parse(row["OrgProvinceID"].ToString()));
                }
                if (((row["OrgCityID"] != null) && (row["OrgCityID"] != DBNull.Value)) && (row["OrgCityID"].ToString() != ""))
                {
                    recordsBaseInfoModel.OrgCityID = new decimal?(decimal.Parse(row["OrgCityID"].ToString()));
                }
                if (((row["OrgDistrictID"] != null) && (row["OrgDistrictID"] != DBNull.Value)) && (row["OrgDistrictID"].ToString() != ""))
                {
                    recordsBaseInfoModel.OrgDistrictID = new decimal?(decimal.Parse(row["OrgDistrictID"].ToString()));
                }
                if (((row["OrgTownID"] != null) && (row["OrgTownID"] != DBNull.Value)) && (row["OrgTownID"].ToString() != ""))
                {
                    recordsBaseInfoModel.OrgTownID = new decimal?(decimal.Parse(row["OrgTownID"].ToString()));
                }
                if (((row["OrgVillageID"] != null) && (row["OrgVillageID"] != DBNull.Value)) && (row["OrgVillageID"].ToString() != ""))
                {
                    recordsBaseInfoModel.OrgVillageID = new decimal?(decimal.Parse(row["OrgVillageID"].ToString()));
                }
                if (((row["ProvinceID"] != null) && (row["ProvinceID"] != DBNull.Value)) && (row["ProvinceID"].ToString() != ""))
                {
                    recordsBaseInfoModel.ProvinceID = new decimal?(decimal.Parse(row["ProvinceID"].ToString()));
                }
                if (((row["CityID"] != null) && (row["CityID"] != DBNull.Value)) && (row["CityID"].ToString() != ""))
                {
                    recordsBaseInfoModel.CityID = new decimal?(decimal.Parse(row["CityID"].ToString()));
                }
                if (((row["DistrictID"] != null) && (row["DistrictID"] != DBNull.Value)) && (row["DistrictID"].ToString() != ""))
                {
                    recordsBaseInfoModel.DistrictID = new decimal?(decimal.Parse(row["DistrictID"].ToString()));
                }
                if (((row["TownID"] != null) && (row["TownID"] != DBNull.Value)) && (row["TownID"].ToString() != ""))
                {
                    recordsBaseInfoModel.TownID = new decimal?(decimal.Parse(row["TownID"].ToString()));
                }
                if (((row["VillageID"] != null) && (row["VillageID"] != DBNull.Value)) && (row["VillageID"].ToString() != ""))
                {
                    recordsBaseInfoModel.VillageID = new decimal?(decimal.Parse(row["VillageID"].ToString()));
                }
                if ((row["WorkUnit"] != null) && (row["WorkUnit"] != DBNull.Value))
                {
                    recordsBaseInfoModel.WorkUnit = row["WorkUnit"].ToString();
                }
                if ((row["LiveType"] != null) && (row["LiveType"] != DBNull.Value))
                {
                    recordsBaseInfoModel.LiveType = row["LiveType"].ToString();
                }
                if ((row["Nation"] != null) && (row["Nation"] != DBNull.Value))
                {
                    recordsBaseInfoModel.Nation = row["Nation"].ToString();
                }
                if ((row["RH"] != null) && (row["RH"] != DBNull.Value))
                {
                    recordsBaseInfoModel.RH = row["RH"].ToString();
                }
                if ((row["Culture"] != null) && (row["Culture"] != DBNull.Value))
                {
                    recordsBaseInfoModel.Culture = row["Culture"].ToString();
                }
                if ((row["Job"] != null) && (row["Job"] != DBNull.Value))
                {
                    recordsBaseInfoModel.Job = row["Job"].ToString();
                }
                if ((row["MaritalStatus"] != null) && (row["MaritalStatus"] != DBNull.Value))
                {
                    recordsBaseInfoModel.MaritalStatus = row["MaritalStatus"].ToString();
                }
                if ((row["MedicalPayType"] != null) && (row["MedicalPayType"] != DBNull.Value))
                {
                    recordsBaseInfoModel.MedicalPayType = row["MedicalPayType"].ToString();
                }
                if ((row["DrugAllergic"] != null) && (row["DrugAllergic"] != DBNull.Value))
                {
                    recordsBaseInfoModel.DrugAllergic = row["DrugAllergic"].ToString();
                }
                if ((row["Disease"] != null) && (row["Disease"] != DBNull.Value))
                {
                    recordsBaseInfoModel.Disease = row["Disease"].ToString();
                }
                if ((row["DiseasEndition"] != null) && (row["DiseasEndition"] != DBNull.Value))
                {
                    recordsBaseInfoModel.DiseasEndition = row["DiseasEndition"].ToString();
                }
                if ((row["CustomerName"] != null) && (row["CustomerName"] != DBNull.Value))
                {
                    recordsBaseInfoModel.CustomerName = row["CustomerName"].ToString();
                }
                if ((row["Doctor"] != null) && (row["Doctor"] != DBNull.Value))
                {
                    recordsBaseInfoModel.Doctor = row["Doctor"].ToString();
                }
                if ((row["Sex"] != null) && (row["Sex"] != DBNull.Value))
                {
                    recordsBaseInfoModel.Sex = row["Sex"].ToString();
                }
                if (((row["Birthday"] != null) && (row["Birthday"] != DBNull.Value)) && (row["Birthday"].ToString() != ""))
                {
                    recordsBaseInfoModel.Birthday = new DateTime?(DateTime.Parse(row["Birthday"].ToString()));
                }
                if ((row["ContactName"] != null) && (row["ContactName"] != DBNull.Value))
                {
                    recordsBaseInfoModel.ContactName = row["ContactName"].ToString();
                }
                if ((row["ContactPhone"] != null) && (row["ContactPhone"] != DBNull.Value))
                {
                    recordsBaseInfoModel.ContactPhone = row["ContactPhone"].ToString();
                }
                if ((row["BloodType"] != null) && (row["BloodType"] != DBNull.Value))
                {
                    recordsBaseInfoModel.BloodType = row["BloodType"].ToString();
                }
                if ((row["Phone"] != null) && (row["Phone"] != DBNull.Value))
                {
                    recordsBaseInfoModel.Phone = row["Phone"].ToString();
                }
                if ((row["MedicalPayTypeOther"] != null) && (row["MedicalPayTypeOther"] != DBNull.Value))
                {
                    recordsBaseInfoModel.MedicalPayTypeOther = row["MedicalPayTypeOther"].ToString();
                }
                if ((row["DrugAllergicOther"] != null) && (row["DrugAllergicOther"] != DBNull.Value))
                {
                    recordsBaseInfoModel.DrugAllergicOther = row["DrugAllergicOther"].ToString();
                }
                if ((row["DiseaseEx"] != null) && (row["DiseaseEx"] != DBNull.Value))
                {
                    recordsBaseInfoModel.DiseaseEx = row["DiseaseEx"].ToString();
                }
                if ((row["DiseasEnditionEx"] != null) && (row["DiseasEnditionEx"] != DBNull.Value))
                {
                    recordsBaseInfoModel.DiseasEnditionEx = row["DiseasEnditionEx"].ToString();
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    recordsBaseInfoModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["Address"] != null) && (row["Address"] != DBNull.Value))
                {
                    recordsBaseInfoModel.Address = row["Address"].ToString();
                }
                if ((row["HouseHoldAddress"] != null) && (row["HouseHoldAddress"] != DBNull.Value))
                {
                    recordsBaseInfoModel.HouseHoldAddress = row["HouseHoldAddress"].ToString();
                }
                if (((row["CreateUnit"] != null) && (row["CreateUnit"] != DBNull.Value)) && (row["CreateUnit"].ToString() != ""))
                {
                    recordsBaseInfoModel.CreateUnit = new decimal?(decimal.Parse(row["CreateUnit"].ToString()));
                }
                if ((row["Minority"] != null) && (row["Minority"] != DBNull.Value))
                {
                    recordsBaseInfoModel.Minority = row["Minority"].ToString();
                }
                if ((row["Exposure"] != null) && (row["Exposure"] != DBNull.Value))
                {
                    recordsBaseInfoModel.Exposure = row["Exposure"].ToString();
                }
                if ((row["CreateBy"] != null) && (row["CreateBy"] != DBNull.Value))
                {
                    recordsBaseInfoModel.CreateBy = row["CreateBy"].ToString();
                }
                if (((row["CreateDate"] != null) && (row["CreateDate"] != DBNull.Value)) && (row["CreateDate"].ToString() != ""))
                {
                    recordsBaseInfoModel.CreateDate = new DateTime?(DateTime.Parse(row["CreateDate"].ToString()));
                }
                if ((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value))
                {
                    recordsBaseInfoModel.LastUpdateBy = row["LastUpdateBy"].ToString();
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    recordsBaseInfoModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["PopulationType"] != null) && (row["PopulationType"] != DBNull.Value))
                {
                    recordsBaseInfoModel.PopulationType = row["PopulationType"].ToString();
                }
                if ((row["FamilyIDCardNo"] != null) && (row["FamilyIDCardNo"] != DBNull.Value))
                {
                    recordsBaseInfoModel.FamilyIDCardNo = row["FamilyIDCardNo"].ToString();
                }
                if ((row["HouseRelation"] != null) && (row["HouseRelation"] != DBNull.Value))
                {
                    recordsBaseInfoModel.HouseRelation = row["HouseRelation"].ToString();
                }
                if ((row["HouseRealOther"] != null) && (row["HouseRealOther"] != DBNull.Value))
                {
                    recordsBaseInfoModel.HouseRealOther = row["HouseRealOther"].ToString();
                }
                if ((row["Email"] != null) && (row["Email"] != DBNull.Value))
                {
                    recordsBaseInfoModel.Email = row["Email"].ToString();
                }
                if ((row["IsDelete"] != null) && (row["IsDelete"] != DBNull.Value))
                {
                    recordsBaseInfoModel.IsDelete = row["IsDelete"].ToString();
                }
                if ((row["IsUpdate"] != null) && (row["IsUpdate"] != DBNull.Value))
                {
                    recordsBaseInfoModel.IsUpdate = row["IsUpdate"].ToString();
                }
                if ((row["TownName"] != null) && (row["TownName"] != DBNull.Value))
                {
                    recordsBaseInfoModel.TownName = row["TownName"].ToString();
                }
                if ((row["VillageName"] != null) && (row["VillageName"] != DBNull.Value))
                {
                    recordsBaseInfoModel.VillageName = row["VillageName"].ToString();
                }
                if ((row["CreateUnitName"] != null) && (row["CreateUnitName"] != DBNull.Value))
                {
                    recordsBaseInfoModel.CreateUnitName = row["CreateUnitName"].ToString();
                }
                if ((row["CreateMenName"] != null) && (row["CreateMenName"] != DBNull.Value))
                {
                    recordsBaseInfoModel.CreateMenName = row["CreateMenName"].ToString();
                }
              
                if ((row["TownMedicalCard"] != null) && (row["TownMedicalCard"] != DBNull.Value))
                {
                    recordsBaseInfoModel.TownMedicalCard = row["TownMedicalCard"].ToString();
                }
                if ((row["ResidentMedicalCard"] != null) && (row["ResidentMedicalCard"] != DBNull.Value))
                {
                    recordsBaseInfoModel.ResidentMedicalCard = row["ResidentMedicalCard"].ToString();
                }
                if ((row["PovertyReliefMedicalCard"] != null) && (row["PovertyReliefMedicalCard"] != DBNull.Value))
                {
                    recordsBaseInfoModel.PovertyReliefMedicalCard = row["PovertyReliefMedicalCard"].ToString();
                }
                if ((row["LiveCondition"] != null) && (row["LiveCondition"] != DBNull.Value))
                {
                    recordsBaseInfoModel.LiveCondition = row["LiveCondition"].ToString();
                }
                if ((row["FamilyStructure"] != null) && (row["FamilyStructure"] != DBNull.Value))
                {
                    recordsBaseInfoModel.FamilyStructure = row["FamilyStructure"].ToString();
                }
                if ((row["HouseName"] != null) && (row["HouseName"] != DBNull.Value))
                {
                    recordsBaseInfoModel.HouseName = row["HouseName"].ToString();
                }
                if (((row["FamilyNum"] != null) && (row["FamilyNum"] != DBNull.Value)) && (row["FamilyNum"].ToString() != ""))
                {
                    recordsBaseInfoModel.FamilyNum = new decimal?(decimal.Parse(row["FamilyNum"].ToString()));
                }
                if ((row["PreSituation"] != null) && (row["PreSituation"] != DBNull.Value))
                {
                    recordsBaseInfoModel.PreSituation = row["PreSituation"].ToString();
                }
                if ((row["PreNum"] != null) && (row["PreNum"] != DBNull.Value))
                {
                    recordsBaseInfoModel.PreNum = row["PreNum"].ToString();
                }
                if ((row["YieldNum"] != null) && (row["YieldNum"] != DBNull.Value))
                {
                    recordsBaseInfoModel.YieldNum = row["YieldNum"].ToString();
                }
                if ((row["Chemical"] != null) && (row["Chemical"] != DBNull.Value))
                {
                    recordsBaseInfoModel.Chemical = row["Chemical"].ToString();
                }
                if ((row["Poison"] != null) && (row["Poison"] != DBNull.Value))
                {
                    recordsBaseInfoModel.Poison = row["Poison"].ToString();
                }
                if ((row["Radial"] != null) && (row["Radial"] != DBNull.Value))
                {
                    recordsBaseInfoModel.Radial = row["Radial"].ToString();
                }
            }
            return recordsBaseInfoModel;
        }

        public int DelTheMan(string idcard)
        {
            // List<string> list = MySQLHelper.GetList("select table_name from information_schema.tables where  table_schema='qcpaddb' order by table_name");
            List<string> list = MySQLHelper.GetList("select table_name from information_schema.tables where  table_schema='qcpaddb'and table_name ='tbl_barcode_day' order by table_name");
            ArrayList sQLStringList = new ArrayList();
            //list.Remove("android_metadata");
            //list.Remove("sqlite_sequence");
            //list.Remove("ARCHIVE_CANTON");
            //string[] strArray = new string[] {"ARCHIVE_CITY", "ARCHIVE_DISTRICT", "ARCHIVE_PROVINCE", 
            //    "ARCHIVE_TOWN", "ARCHIVE_VILLAGE", "SYS_ORG_CITY", "SYS_ORG_DISTRICT", "SYS_ORG_PROVINCE", "SYS_ORG_TOWN", 
            //    "SYS_ORG_VILLAGE", "SYS_USER", "INOCULATION_OTHERPROGRAM" };
            //foreach (string str in strArray)
            //{
            //    list.Remove(str);
            //}
            string[] strArray = new string[] {"CD_CHD_BASEINFO", 
                "CD_CHD_FOLLOWUP", "CD_DIABETES_BASEINFO", "CD_DIABETESFOLLOWUP", "CD_DRUGCONDITION", "CD_HYPERTENSION_BASEINFO", 
                "CD_HYPERTENSIONFOLLOWUP", "CD_PTB_FIRSTVISIT", 
                "CD_PTB_VISIT", "CD_MENTALDISEASE_BASEINFO", "CD_MENTALDISEASE_FOLLOWUP", "CD_STROKE_BASEINFO",
                "CD_STROKE_FOLLOWUP", "ARCHIVE_DEVICEINFO", "CHILD_BASEINFO", "CHILD_NEWBORN_FOLLOWUP", "CHILD_ONE2THREE_YEAR_OLD", "CHILD_TCMHM_ONE",
                "CHILD_TCMHM_ONE2THREE", "CHILD_TCMHM_THREE2SIX", "CHILD_THREE2SIX_YEAR_OLD","CHILD_WITHIN_ONE_YEAR_OLD", "OLD_MEDICINE_CN", "OLD_MEDICINE_RESULT",
                "OLDER_SELFCAREABILITY", "ARCHIVE_ASSESSMENTGUIDE", "ARCHIVE_ASSISTCHECK","ARCHIVE_BASEINFO", "ARCHIVE_CARD", "ARCHIVE_CUSTOMERBASEINFO",
                "ARCHIVE_ECG", "ARCHIVE_EDUCATION_ACTIVITIES", "ARCHIVE_ENVIRONMENT","ARCHIVE_FAMILYBEDHISTORY", "ARCHIVE_FAMILYHISTORYINFO", 
                "ARCHIVE_FAMILY_INFO","ARCHIVE_GENERALCONDITION", "ARCHIVE_HEALTHQUESTION", "ARCHIVE_HOSPITALHISTORY","ARCHIVE_ILLNESSHISTORYINFO",
                "ARCHIVE_INOCULATIONHISTORY", "ARCHIVE_LIFESTYLE", "ARCHIVE_MEDICATION","ARCHIVE_MEDI_PHYS_DIST","ARCHIVE_PHYSICALEXAM",
                "ARCHIVE_VISCERAFUNCTION", "SYS_ERROR_LOG","INOCULATION_CARD", 
                "INOCULATION_PROGRAM","GRAVIDA_BASEINFO", "GRAVIDA_FIRSTFOLLOWUP", "GRAVIDA_POSTPARTUM",
                "GRAVIDA_POSTPARTUM_42DAY", "GRAVIDA_PRE_ASSISTCHECK", "GRAVIDA_TWO2FIVE_FOLLOWUP","SYS_UPLOADED","ARCHIVE_RECEPTION_RECORD",
                "ARCHIVE_CONSULTATION_RECORD","ARCHIVE_REFERRAL","ARCHIVE_SELFCAREABILITY","ARCHIVE_MEDICINE_CN","ARCHIVE_MEDICINE_RESULT","ARCHIVE_BASEINFO_OUT"
            };

            foreach (string str in strArray)
            {
                list.Add(str);
            }

            foreach (string str2 in list)
            {
                sQLStringList.Add(string.Format("delete from {0} where IDCardNo = '{1}'", str2, idcard));
            }

            MySQLHelper.ExecuteSqlTran(sQLStringList);

            return 0;
        }

        public bool Exists(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_BASEINFO");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,RecordID,IDCardNo,OrgProvinceID,OrgCityID,OrgDistrictID,OrgTownID,OrgVillageID,ProvinceID,CityID,DistrictID,TownID,VillageID,WorkUnit,LiveType,Nation,RH,Culture,Job,MaritalStatus,MedicalPayType,DrugAllergic,Disease,DiseasEndition,CustomerName,Doctor,Sex,Birthday,ContactName,ContactPhone,BloodType,Phone,MedicalPayTypeOther,DrugAllergicOther,DiseaseEx,DiseasEnditionEx,CustomerID,Address,HouseHoldAddress,CreateUnit,Minority,Exposure,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,PopulationType,FamilyIDCardNo,HouseRelation,HouseRealOther,Email,IsDelete,IsUpdate,TownName,VillageName,CreateUnitName,CreateMenName,TownMedicalCard,ResidentMedicalCard,PovertyReliefMedicalCard,LiveCondition,FamilyNum,FamilyStructure,HouseName,PreSituation,PreNum,YieldNum,Chemical,Poison,Radial  ");
            builder.Append(" FROM ARCHIVE_BASEINFO ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetList(string strWhere, string orderby)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT T.IDCardNo,B.CheckDate");
            builder.Append(" FROM ARCHIVE_BASEINFO T LEFT JOIN  ");
            builder.Append(" (SELECT a.IDCardNo, a.ID,a.CheckDate FROM ARCHIVE_CUSTOMERBASEINFO a ");

            if (!strWhere.Contains("B.CheckDate"))
            {
                builder.Append(" WHERE a.CheckDate=(SELECT MAX(c.CheckDate) FROM ARCHIVE_CUSTOMERBASEINFO c WHERE a.IDCardNo=c.IDCardNo)");
            }

            builder.Append(" ) B ON T.IDCardNo=B.IDCardNo");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" ORDER BY T." + orderby);
            }
            else builder.Append(" ORDER BY T.ID DESC");

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 本地查询随访率所得表
        /// </summary>
        public DataSet GetVisitPercentDt(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select CreateMenName, concat(format((1-(oldBaseCount-oldCount+oldNoVisitCount)/oldBaseCount)*100,2), '%') AS OldPersent,");
            builder.Append("concat(format((1-(HyperBaseCount-HyperCount+HyperNoVisitCount)/HyperBaseCount)*100,2), '%') AS HyperPersent, ");
            builder.Append("concat(format((1-(DiaBaseCount-DiaCount+DiaNoVisitCount)/DiaBaseCount)*100,2), '%') AS DiaPersent,");
            builder.Append("concat(format((1-(MentalBaseCount-MentalCount+MentalNoVisitCount)/MentalBaseCount)*100,2), '%') AS MentalPersent,");
            builder.Append("concat(format((1-(LungerBaseCount-LungerCount+LungerNoVisitCount)/LungerBaseCount)*100,2), '%') AS LungerPersent,");
            builder.Append("concat(format((1-(StrokeBaseCount-StrokeCount+StrokeNoVisitCount)/StrokeBaseCount)*100,2), '%') AS StrokePersent,");
            builder.Append("concat(format((1-(ChdBaseCount-ChdCount+ChdNoVisitCount)/ChdBaseCount)*100,2), '%') AS ChdPersent ");
            builder.Append("from (select CreateMenName, ");

            builder.Append("(select count(*) from ARCHIVE_BASEINFO where PopulationType like '%4%' and ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName) as oldBaseCount,");
            builder.Append("(select count(*) from OLDER_SELFCAREABILITY inner join ARCHIVE_BASEINFO on OLDER_SELFCAREABILITY.IDCardNo = ARCHIVE_BASEINFO.IDCardNo ");
            builder.Append("where ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName) as oldCount, ");
            builder.Append("(select count(*) from OLDER_SELFCAREABILITY inner join ARCHIVE_BASEINFO on OLDER_SELFCAREABILITY.IDCardNo = ARCHIVE_BASEINFO.IDCardNo ");
            builder.Append("where ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName and NextfollowUpDate < now()) as oldNoVisitCount, ");

            builder.Append("(select count(*) from ARCHIVE_BASEINFO where PopulationType like '%6%' and ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName) as HyperBaseCount, ");
            builder.Append("(select count(*) from CD_HYPERTENSIONFOLLOWUP inner join ARCHIVE_BASEINFO on CD_HYPERTENSIONFOLLOWUP.IDCardNo = ARCHIVE_BASEINFO.IDCardNo ");
            builder.Append("where ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName) as HyperCount, ");
            builder.Append("(select count(*) from CD_HYPERTENSIONFOLLOWUP inner join ARCHIVE_BASEINFO on CD_HYPERTENSIONFOLLOWUP.IDCardNo = ARCHIVE_BASEINFO.IDCardNo ");
            builder.Append("where ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName and NextFollowUpDate < now()) as HyperNoVisitCount, ");

            builder.Append("(select count(*) from ARCHIVE_BASEINFO where PopulationType like '%7%' and ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName) as DiaBaseCount, ");
            builder.Append("(select count(*) from CD_DIABETESFOLLOWUP inner join ARCHIVE_BASEINFO on CD_DIABETESFOLLOWUP.IDCardNo = ARCHIVE_BASEINFO.IDCardNo ");
            builder.Append("where ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName) as DiaCount, ");
            builder.Append("(select count(*) from CD_DIABETESFOLLOWUP inner join ARCHIVE_BASEINFO on CD_DIABETESFOLLOWUP.IDCardNo = ARCHIVE_BASEINFO.IDCardNo ");
            builder.Append("where ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName and NextVisitDate < now()) as DiaNoVisitCount, ");

            builder.Append("(select count(*) from ARCHIVE_BASEINFO where PopulationType like '%5%' and ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName) as MentalBaseCount, ");
            builder.Append("(select count(*) from CD_MENTALDISEASE_FOLLOWUP inner join ARCHIVE_BASEINFO on CD_MENTALDISEASE_FOLLOWUP.IDCardNo = ARCHIVE_BASEINFO.IDCardNo ");
            builder.Append("where ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName) as MentalCount, ");
            builder.Append("(select count(*) from CD_MENTALDISEASE_FOLLOWUP inner join ARCHIVE_BASEINFO on CD_MENTALDISEASE_FOLLOWUP.IDCardNo = ARCHIVE_BASEINFO.IDCardNo ");
            builder.Append("where ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName and NextFollowUpDate < now()) as MentalNoVisitCount, ");

            builder.Append("(select count(*) from ARCHIVE_BASEINFO where PopulationType like '%10%' and ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName) as LungerBaseCount, ");
            builder.Append("(select count(*) from CD_PTB_FIRSTVISIT inner join ARCHIVE_BASEINFO on CD_PTB_FIRSTVISIT.IDCardNo = ARCHIVE_BASEINFO.IDCardNo ");
            builder.Append("where ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName) as LungerCount, ");
            builder.Append("(select count(*) from CD_PTB_FIRSTVISIT inner join ARCHIVE_BASEINFO on CD_PTB_FIRSTVISIT.IDCardNo = ARCHIVE_BASEINFO.IDCardNo ");
            builder.Append("where ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName and NextVisitDate < now()) as LungerNoVisitCount, ");

            builder.Append("(select count(*) from ARCHIVE_BASEINFO where PopulationType like '%9%' and ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName) as StrokeBaseCount, ");
            builder.Append("(select count(*) from CD_STROKE_FOLLOWUP inner join ARCHIVE_BASEINFO on CD_STROKE_FOLLOWUP.IDCardNo = ARCHIVE_BASEINFO.IDCardNo ");
            builder.Append("where ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName) as StrokeCount, ");
            builder.Append("(select count(*) from CD_STROKE_FOLLOWUP inner join ARCHIVE_BASEINFO on CD_STROKE_FOLLOWUP.IDCardNo = ARCHIVE_BASEINFO.IDCardNo ");
            builder.Append("where ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName and NextFollowupDate < now()) as StrokeNoVisitCount, ");

            builder.Append("(select count(*) from ARCHIVE_BASEINFO where PopulationType like '%8%' and ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName) as ChdBaseCount, ");
            builder.Append("(select count(*) from CD_CHD_FOLLOWUP inner join ARCHIVE_BASEINFO on CD_CHD_FOLLOWUP.IDCardNo = ARCHIVE_BASEINFO.IDCardNo  ");
            builder.Append("where ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName) as ChdCount, ");
            builder.Append("(select count(*) from CD_CHD_FOLLOWUP inner join ARCHIVE_BASEINFO on CD_CHD_FOLLOWUP.IDCardNo = ARCHIVE_BASEINFO.IDCardNo  ");
            builder.Append("where ARCHIVE_BASEINFO.CreateMenName = MenName.CreateMenName and NextVisitDate < now()) as ChdNoVisitCount ");

            builder.Append("from (select distinct CreateMenName from ARCHIVE_BASEINFO) as MenName) as visitDetail ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetUserDt(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select distinct T.CreateMenName,T.ID,T.PopulationType ");
            builder.Append(" from ARCHIVE_BASEINFO T left join ARCHIVE_CUSTOMERBASEINFO B on T.IDCardNo = B.IDCardNo ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            builder.Append(" group by T.CreateMenName ");
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetListDt(string strWhere, string orderby)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select T.ID,T.IDCardNo,T.Nation,T.CustomerName,T.Sex,T.Birthday,T.Phone,T.HouseHoldAddress,T.Minority,T.LiveType, B.ID as CustomerID, ");
            builder.Append("(case T.CreateDate when null then null when '' then null else T.CreateDate end)CreateDate, ");
            builder.Append("(case T.LastUpdateDate when null then null when '' then null else T.LastUpdateDate end ) as LastUpdateDate, ");
            builder.Append("T.PopulationType,T.CreateMenName, B.CheckDate,B.ID as PID ");
            builder.Append(" from ARCHIVE_BASEINFO T left join ");
            builder.Append(" (SELECT a.IDCardNo, a.ID,a.CheckDate FROM ARCHIVE_CUSTOMERBASEINFO a ");
            if (!strWhere.Contains("B.CheckDate"))
            {
                builder.Append(" where  a.CheckDate = (select max(c.CheckDate) from ARCHIVE_CUSTOMERBASEINFO c  where a.IDCardNo = c.IDCardNo  )");
            }
            builder.Append(" ) B on T.IDCardNo=B.IDCardNo");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select T.ID,T.RecordID,T.IDCardNo,T.OrgProvinceID,T.OrgCityID,T.OrgDistrictID,T.OrgTownID,T.OrgVillageID,T.ProvinceID,T.CityID,");
            builder.Append("T.DistrictID,T.TownID,T.VillageID,T.WorkUnit,T.LiveType,T.Nation,T.RH,T.Culture,T.Job,T.MaritalStatus,T.MedicalPayType,");
            builder.Append("T.DrugAllergic,T.Disease,T.DiseasEndition,T.CustomerName,T.Doctor,T.Sex,T.Birthday,T.ContactName,T.ContactPhone,");
            builder.Append("T.BloodType,T.Phone,T.MedicalPayTypeOther,T.DrugAllergicOther,T.DiseaseEx,T.DiseasEnditionEx,T.CustomerID, ");
            builder.Append("T.Address,T.HouseHoldAddress,T.CreateUnit,T.Minority,T.Exposure,T.CreateBy, ");
            builder.Append("(case T.CreateDate when null then null when '' then null else T.CreateDate end)CreateDate,  ");
            builder.Append("T.LastUpdateBy,(case T.LastUpdateDate when null then null when '' then null else T.LastUpdateDate end ) as LastUpdateDate,");
            builder.Append("T.PopulationType,T.FamilyIDCardNo,T.HouseRelation,T.HouseRealOther,T.Email,T.IsDelete,T.IsUpdate,T.TownName,");
            builder.Append("T.VillageName,T.CreateUnitName,T.CreateMenName,B.CheckDate ,B.ID as CustomerID");
            builder.Append(" from ARCHIVE_BASEINFO T left join  ");
            builder.Append(" (SELECT a.IDCardNo, a.ID,a.CheckDate FROM ARCHIVE_CUSTOMERBASEINFO a ");
            if (!strWhere.Contains("B.CheckDate"))
            {
                builder.Append(" where  a.CheckDate = (select max(c.CheckDate) from ARCHIVE_CUSTOMERBASEINFO c  where a.IDCardNo = c.IDCardNo  )");
            }
            builder.Append(" ) B on T.IDCardNo=B.IDCardNo");

            //builder.Append("select [ID]\t\t,[RecordID]\t\t,[IDCardNo]\t\t,[OrgProvinceID]\t\t,[OrgCityID]\t\t,[OrgDistrictID]\t\t,[OrgTownID]\t\t,[OrgVillageID]\t\t,[ProvinceID]\t\t,[CityID]\t\t,[DistrictID]\t\t,[TownID]\t\t,[VillageID]\t\t,[WorkUnit]\t\t,[LiveType]\t\t,[Nation]\t\t,[RH]\t\t,[Culture]\t\t,[Job]\t\t,[MaritalStatus]\t\t,[MedicalPayType]\t\t,[DrugAllergic]\t\t,[Disease]\t\t,[DiseasEndition]\t\t,[CustomerName]\t\t,[Doctor]\t\t,[Sex]\t\t,[Birthday]\t\t,[ContactName]\t\t,[ContactPhone]\t\t,[BloodType]\t\t,[Phone]\t\t,[MedicalPayTypeOther]\t\t,[DrugAllergicOther]\t\t,[DiseaseEx]\t\t,[DiseasEnditionEx]\t\t,[CustomerID]\t\t,[Address]\t\t,[HouseHoldAddress]\t\t,[CreateUnit]\t\t,[Minority]\t\t,[Exposure]\t\t,[CreateBy]\t\t,(case CreateDate when null then null when '' then null else CreateDate end)[CreateDate]\t\t,[LastUpdateBy]\t\t,(case LastUpdateDate when null then null when '' then null else LastUpdateDate end ) as [LastUpdateDate]\t\t,[PopulationType]\t\t,[FamilyIDCardNo]\t\t,[HouseRelation]\t\t,[HouseRealOther]\t\t,[Email]\t\t,[IsDelete]\t\t,[IsUpdate]\t\t,[TownName]\t\t,[VillageName]\t\t,[CreateUnitName]\t\t,[CreateMenName] from ARCHIVE_BASEINFO T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }

            builder.Append(string.Format(" limit {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetNoVisitListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            string strDate = DateTime.Now.ToString("yyyy-MM-dd");

            builder.Append("select * from (");
            builder.Append("select ARCHIVE_BASEINFO.ID, ARCHIVE_BASEINFO.CustomerName, ARCHIVE_BASEINFO.IDCardNo, HouseHoldAddress,Birthday,ARCHIVE_BASEINFO.CreateDate,ARCHIVE_BASEINFO.CreateBy,ARCHIVE_BASEINFO.CreateMenName,ARCHIVE_BASEINFO.PopulationType,");
            builder.Append("(select cast(C.NextfollowUpDate as char) from OLDER_SELFCAREABILITY C ");
            builder.Append("where ARCHIVE_BASEINFO.IDCardNo = C.IDCardNo and C.FollowUpDate =(SELECT MAX(C1.FollowUpDate) from OLDER_SELFCAREABILITY C1 where C.IDCardNo=C1.IDCardNO)) as OLDVisit, ");
            builder.Append("(select cast(C.NextFollowUpDate as char) from CD_HYPERTENSIONFOLLOWUP C ");
            builder.Append("where ARCHIVE_BASEINFO.IDCardNo = C.IDCardNo and C.FollowUpDate=(select max(C1.FollowUpDate) from CD_HYPERTENSIONFOLLOWUP C1 where C.IDCardNo=C1.IDCardNO)) as HyperVisit, ");
            builder.Append("(select cast(C.NextVisitDate as char) from CD_DIABETESFOLLOWUP C ");
            builder.Append("where ARCHIVE_BASEINFO.IDCardNo = C.IDCardNo and C.VisitDate=(select max(C1.VisitDate) from CD_DIABETESFOLLOWUP C1 where C.IDCardNo=C1.IDCardNO)) as DiaVisit, ");
            builder.Append("(select cast(C.NextFollowUpDate as char) from CD_MENTALDISEASE_FOLLOWUP C ");
            builder.Append("where ARCHIVE_BASEINFO.IDCardNo = C.IDCardNo and C.FollowUpDate=(select max(C1.FollowUpDate) from CD_MENTALDISEASE_FOLLOWUP C1 where C.IDCardNo=C1.IDCardNO)) as MentalVisit, ");
            builder.Append("(select cast(C.NextVisitDate as char) from CD_PTB_FIRSTVISIT C ");
            builder.Append("where ARCHIVE_BASEINFO.IDCardNo = C.IDCardNo and C.FollowupDate=(select max(C1.FollowupDate) from CD_PTB_FIRSTVISIT C1 where C.IDCardNo=C1.IDCardNO)) as LungerVisit, ");
            builder.Append("(select cast(C.NextFollowupDate as char) from CD_STROKE_FOLLOWUP C ");
            builder.Append("where ARCHIVE_BASEINFO.IDCardNo = C.IDCardNo and C.FollowUpDate=(select max(C1.FollowUpDate) from CD_STROKE_FOLLOWUP C1 where C.IDCardNo=C1.IDCardNO)) as StrokeVisit, ");
            builder.Append("(select cast(C.NextVisitDate as char) from CD_CHD_FOLLOWUP C ");
            builder.Append("where ARCHIVE_BASEINFO.IDCardNo = C.IDCardNo and C.VisitDate=(select max(C1.VisitDate) from CD_CHD_FOLLOWUP C1 where C.IDCardNo=C1.IDCardNO)) as ChdVisit ");
            builder.Append("FROM ARCHIVE_BASEINFO) T ");
            builder.Append("left join (select * from ARCHIVE_CUSTOMERBASEINFO D WHERE D.CheckDate=(select max(D1.CheckDate) from ARCHIVE_CUSTOMERBASEINFO D1 where D.IDCardNo=D1.IDCardNo ) )B on T.IDCardNo = B.IDCardNo ");
            builder.Append("where  ((PopulationType like '%4%' and OLDVisit is null) or (PopulationType like '%5%' and MentalVisit is null) ");
            builder.Append(" or (PopulationType like '%6%' and HyperVisit is null) or (PopulationType like '%7%' and DiaVisit is null) ");
            builder.Append(" or (PopulationType like '%8%' and ChdVisit is null) or (PopulationType like '%9%' and StrokeVisit is null) ");
            builder.Append(" or (PopulationType like '%10%' and LungerVisit is null)) ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }

            builder.Append(string.Format(" limit {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GerenDanganDt(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select a.IDCardNo,a.Address,a.Phone,a.CreateDate,a.Doctor,a.CreateMenName,a.CreateUnitName,a.VillageName,a.TownName, ");
            builder.Append("a.HouseHoldAddress,a.ContactName,a.ContactPhone,a.Disease,a.MedicalPayType,a.DrugAllergic,a.Exposure,a.DiseasEndition,");
            builder.Append("a.Email,a.MedicalPayTypeOther,a.PovertyReliefMedicalCard,a.ResidentMedicalCard,a.TownMedicalCard,a.MaritalStatus,a.job, ");
            builder.Append("a.Culture,a.RH,a.BloodType,a.LiveType,a.WorkUnit,a.Nation,a.FamilyStructure,a.HouseRelation,a.LiveCondition,a.FamilyNum, ");
            builder.Append("a.FamilyIDCardNo,a.HouseName,a.PreSituation,a.PreNum,a.YieldNum,a.Chemical,a.Poison,a.Radial,b.BlowMeasure,b.FuelType,b.DrinkWater,b.Toilet,b.LiveStockRail,b.SignDate ");
            builder.Append(" from ARCHIVE_BASEINFO a LEFT JOIN ARCHIVE_ENVIRONMENT b on a.IDCardNo = b.IDCardNo ");
            builder.Append(" where a.IDCardNo = '" + strWhere + "'");
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet JiankangCheckDt(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select a.ID,a.IDCardNo,a.Symptom,b.AnimalHeat,b.BreathRate,b.Waistline,b.Height,b.PulseRate,b.Weight,b.BMI,b.LeftPre,");
            builder.Append("b.RightPre,b.LeftHeight,b.RightHeight,b.LeftReason,b.RightReason,c.DietaryHabit,c.CareerHarmFactorHistory,c.ExerciseRate,");
            builder.Append("c.SmokeCondition,c.DrinkRate,c.ExerciseExistense,");
            builder.Append("d.Skin,d.Sclere,d.Lymph,d.BarrelChest,d.BreathSounds,d.Rale,d.HeartRate,d.HeartRhythm,d.Noise,d.EnclosedMass,d.Edema,d.FootBack,");
            builder.Append("d.Anus,d.Breast,d.PressPain,d.Liver,d.Spleen,d.Voiced,d.EyeRound,d.Other,d.Vulva,d.Attach,d.Corpus,d.CervixUteri,d.Vagina,");
            builder.Append("e.FPGL,e.Other as Other1,e.CERVIX,e.BCHAOther,e.BCHAO,e.CHESTX,e.HeiCho,e.TG,e.LowCho,e.TC,e.HYPE,e.PC,e.BUN,e.SCR,e.GT,e.TBIL,");
            builder.Append("e.CB,e.BP,e.GOT,e.SGPT,e.ECG,e.RH,e.BloodType,e.HBSAG,e.HBALC,e.FOB,e.UrineOther,e.BLD,e.KET,e.GLU,e.PRO,e.ALBUMIN,");
            builder.Append("e.HCY,e.FPGDL,e.BloodOther,e.PLT,e.WBC,e.HB,f.Lips,f.ToothResides,f.Pharyngeal,f.Listen,f.SportFunction,f.RightEyecorrect,");
            builder.Append("f.LeftEyecorrect,f.RightView,f.LeftView,g.BrainDis,g.RenalDis,g.HeartDis,");
            builder.Append("g.VesselDis,g.EyeDis,g.NerveDis,g.ElseDis,h.IsNormal,h.HealthGuide,h.DangerControl ");
            builder.Append(" from ARCHIVE_CUSTOMERBASEINFO a LEFT JOIN ARCHIVE_GENERALCONDITION b on a.ID = b.OutKey ");
            builder.Append(" LEFT JOIN ARCHIVE_LIFESTYLE c on a.ID = c.OutKey  LEFT JOIN ARCHIVE_PHYSICALEXAM d on a.ID = d.OutKey  ");
            builder.Append(" LEFT JOIN ARCHIVE_ASSISTCHECK e on a.ID = e.OutKey LEFT JOIN ARCHIVE_VISCERAFUNCTION f on a.ID = f.OutKey ");
            builder.Append(" LEFT JOIN ARCHIVE_HEALTHQUESTION g on a.ID = g.OutKey LEFT JOIN ARCHIVE_ASSESSMENTGUIDE h on a.ID = h.OutKey ");
            builder.Append(" where a.IDCardNo = '" + strWhere + "'");
            builder.Append(" order by a.CheckDate DESC LIMIT 0,1 ");
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet DiabetesDt(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select a.ID,a.IDCardNo,a.Symptom,a.Hypertension,a.Hypotension,a.BMI,a.BMITarget,a.DorsalisPedispulse,a.Weight,");
            builder.Append("a.TargetWeight,a.DailySmokeNum,a.DailySmokeNumTarget,a.DailyDrinkNum,a.DailyDrinkNumTarget,a.SportTimePerWeek,");
            builder.Append("a.SportPerMinuteTime,a.SportTimePerWeekTarget,a.SportPerMinuteTimeTarget,a.StapleFooddailyg,a.StapleFooddailygTarget,");
            builder.Append("a.PsychoAdjustment,a.ObeyDoctorBehavior,a.FPG,a.HbAlc,a.ExamDate,a.MedicationCompliance,a.Adr,a.HypoglyceMiarreAction,");
            builder.Append("a.VisitType,a.InsulinType,a.InsulinUsage,a.VisitDate,a.VisitDoctor,a.VisitWay,a.PhysicalSymptomMother,a.Hight,a.RBG,");
            builder.Append("a.PBG,a.DoctorView,a.NextMeasures,a.InsulinAdjustType,a.InsulinAdjustUsage,a.IsReferral,a.Remarks,a.NextVisitDate,");
            builder.Append("b.FamilyHistory,b.DiabetesType,b.DiabetesTime,b.DiabetesWork,b.Insulin,b.InsulinWeight,b.EnalaprilMelete,");
            builder.Append("b.Symptom as Symptom1,b.ManagementGroup,b.CaseSource,b.EndManage ");
            builder.Append("from CD_DIABETESFOLLOWUP a INNER JOIN CD_DIABETES_BASEINFO b on a.IDCardNo = b.IDCardNo ");
            builder.Append(" where a.IDCardNo ='" + strWhere + "' order by a.VisitDate DESC LIMIT 0,1;");

            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet HyperDt(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select a.ID,a.IDCardNo,a.Symptom,a.Hypertension,a.Hypotension,a.Heartrate,a.BMI,a.BMITarGet,a.Weight,a.WeightTarGet,a.DailySmokeNum,");
            builder.Append("a.DailySmokeNumTarget,a.DailyDrinkNum,a.DailyDrinkNumTarget,a.SportPerMinuteTime,a.SportPerMinutesTimeTarget,a.SportTimePerWeek,");
            builder.Append("a.SportTimeSperWeekTarget,a.EatSaltType,a.EatSaltTarget,a.PsyChoadJustMent,a.MedicationCompliance,a.Adr,a.FollowUpDate,");
            builder.Append("a.FollowUpDoctor,a.FollowUpWay,a.Hight,a.PhysicalSympToMother,a.ObeyDoctorBehavior,a.AssistantExam,a.FollowUpType,a.NextMeasures,");
            builder.Append("a.DoctorView,a.IsReferral,a.Remarks,a.NextFollowUpDate,b.FatherHistory,b.Symptom as Symptom1 ,b.Hypotensor,b.ManagementGroup,");
            builder.Append("b.CaseOurce,b.HypertensionComplication ");
            builder.Append("from CD_HYPERTENSIONFOLLOWUP a INNER JOIN CD_HYPERTENSION_BASEINFO b on a.IDCardNo = b.IDCardNo  ");
            builder.Append("where a.IDCardNo ='" + strWhere + "' order by a.FollowUpDate DESC LIMIT 0,1 ");
            return MySQLHelper.Query(builder.ToString());
        }

        public int GetOLDVisitCountTenDay(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextfollowUpDate) from OLDER_SELFCAREABILITY C  ");
            builder.Append(string.Format(" where NextfollowUpDate between '{0}' and '{1}'  ", DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowUpDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo)B INNER JOIN  ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy   ");
            builder.Append(" from ARCHIVE_BASEINFO T   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        public int GetOLDNoVisitCount(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from (");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy,T.PopulationType  ");
            builder.Append(" from ARCHIVE_BASEINFO T ");
            builder.Append("WHERE (T.PopulationType like '%4%')   ");
            if (CheckDate.Trim() != "")
            {
                builder.Append(CheckDate);
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            builder.Append("  )P  LEFT JOIN  ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextfollowUpDate) AS OLDVisit from OLDER_SELFCAREABILITY C  ");
            builder.Append(" GROUP BY C.IDCardNo  )B  ON B.IDCardNo=P.IDCardNo) ");
            builder.Append(" WHERE  (PopulationType like '%4%' and OLDVisit is null) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        public int GetHyperVisitCountTenDay(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextFollowUpDate) from CD_HYPERTENSIONFOLLOWUP C  ");
            builder.Append(string.Format(" where NextfollowUpDate between '{0}' and '{1}'  ", DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowUpDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo)B INNER JOIN  ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy   ");
            builder.Append(" from ARCHIVE_BASEINFO T   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);

        }

        public int GetHyperNoVisitCount(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from (");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy,T.PopulationType  ");
            builder.Append(" from ARCHIVE_BASEINFO T ");
            builder.Append("WHERE (T.PopulationType like '%6%')   ");
            if (CheckDate.Trim() != "")
            {
                builder.Append(CheckDate);
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            builder.Append("  )P  LEFT JOIN  ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextFollowUpDate) AS HyperVisit from CD_HYPERTENSIONFOLLOWUP C  ");
            builder.Append(" GROUP BY C.IDCardNo  )B  ON B.IDCardNo=P.IDCardNo) ");
            builder.Append(" WHERE  (PopulationType like '%6%' and HyperVisit is null) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        public int GetDiaVisitCountTenDay(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextVisitDate) from CD_DIABETESFOLLOWUP C  ");
            builder.Append(string.Format(" where C.NextVisitDate between '{0}' and '{1}' ", DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.VisitDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo)B INNER JOIN  ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy   ");
            builder.Append(" from ARCHIVE_BASEINFO T   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int GetDiaNoVisitCount(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from (");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy,T.PopulationType  ");
            builder.Append(" from ARCHIVE_BASEINFO T ");
            builder.Append("WHERE (T.PopulationType like '%7%')   ");
            if (CheckDate.Trim() != "")
            {
                builder.Append(CheckDate);
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            builder.Append("  )P  LEFT JOIN  ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextVisitDate) AS DiaVisit from CD_DIABETESFOLLOWUP C  ");
            builder.Append(" GROUP BY C.IDCardNo  )B  ON B.IDCardNo=P.IDCardNo) ");
            builder.Append(" WHERE  (PopulationType like '%7%' and DiaVisit is null) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        public int GetMentalVisitCountTenDay(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextfollowUpDate) from CD_MENTALDISEASE_FOLLOWUP C  ");
            builder.Append(string.Format(" where NextFollowUpDate between '{0}' and '{1}'  ", DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowUpDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo)B INNER JOIN  ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy   ");
            builder.Append(" from ARCHIVE_BASEINFO T   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        public int GetMentalNoVisitCount(string strWhere, string CheckDate)
        {
  
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from (");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy,T.PopulationType  ");
            builder.Append(" from ARCHIVE_BASEINFO T ");
            builder.Append("WHERE (T.PopulationType like '%5%')   ");
            if (CheckDate.Trim() != "")
            {
                builder.Append(CheckDate);
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            builder.Append("  )P  LEFT JOIN  ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextFollowUpDate) AS MentalVisit from CD_MENTALDISEASE_FOLLOWUP C  ");
            builder.Append(" GROUP BY C.IDCardNo  )B  ON B.IDCardNo=P.IDCardNo) ");
            builder.Append(" WHERE  (PopulationType like '%5%' and MentalVisit is null) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        public int GetLungerVisitCountTenDay(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextVisitDate) from CD_PTB_FIRSTVISIT C  ");
            builder.Append(string.Format(" where C.NextVisitDate between '{0}' and '{1}'  ", DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowupDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo)B INNER JOIN  ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy   ");
            builder.Append(" from ARCHIVE_BASEINFO T   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        public int GetLungerNoVisitCount(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from (");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy,T.PopulationType  ");
            builder.Append(" from ARCHIVE_BASEINFO T ");
            builder.Append("WHERE (T.PopulationType like '%10%')   ");
            if (CheckDate.Trim() != "")
            {
                builder.Append(CheckDate);
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            builder.Append("  )P  LEFT JOIN  ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextVisitDate) AS LungerVisit from CD_PTB_FIRSTVISIT C  ");
            builder.Append(" GROUP BY C.IDCardNo  )B  ON B.IDCardNo=P.IDCardNo) ");
            builder.Append(" WHERE  (PopulationType like '%10%' and LungerVisit is null) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        public int GetStrokeVisitCountTenDay(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextFollowupDate) from CD_STROKE_FOLLOWUP C  ");
            builder.Append(string.Format(" where C.NextFollowupDate between '{0}' and '{1}' ", DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowupDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo)B INNER JOIN  ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy   ");
            builder.Append(" from ARCHIVE_BASEINFO T   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int GetStrokeNoVisitCount(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from (");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy,T.PopulationType  ");
            builder.Append(" from ARCHIVE_BASEINFO T ");
            builder.Append("WHERE (T.PopulationType like '%9%')   ");
            if (CheckDate.Trim() != "")
            {
                builder.Append(CheckDate);
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            builder.Append("  )P  LEFT JOIN  ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextFollowupDate) AS StrokeVisit from CD_STROKE_FOLLOWUP C  ");
            builder.Append(" GROUP BY C.IDCardNo  )B  ON B.IDCardNo=P.IDCardNo) ");
            builder.Append(" WHERE  (PopulationType like '%9%' and StrokeVisit is null) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        public int GetChdVisitCountTenDay(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextVisitDate) from CD_CHD_FOLLOWUP C  ");
            builder.Append(string.Format(" where C.NextVisitDate between '{0}' and '{1}' ", DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.VisitDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo)B INNER JOIN  ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy   ");
            builder.Append(" from ARCHIVE_BASEINFO T   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int GetChdNoVisitCount(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from (");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy,T.PopulationType  ");
            builder.Append(" from ARCHIVE_BASEINFO T ");
            builder.Append("WHERE (T.PopulationType like '%8%')   ");
            if (CheckDate.Trim() != "")
            {
                builder.Append(CheckDate);
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            builder.Append("  )P  LEFT JOIN  ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextVisitDate) AS ChdVisit from CD_CHD_FOLLOWUP C  ");
            builder.Append(" GROUP BY C.IDCardNo  )B  ON B.IDCardNo=P.IDCardNo) ");
            builder.Append(" WHERE  (PopulationType like '%8%' and ChdVisit is null) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        public DataSet GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT ");
            builder.Append("a.*,b.CustomerName AS HOUSENAME FROM ARCHIVE_BASEINFO a ");
            builder.Append("LEFT JOIN ARCHIVE_BASEINFO b ON a.FamilyIDCardNo = b.IDCardNo ");
            builder.Append(" WHERE a.IDCardNo=@IDCardNo");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM ARCHIVE_BASEINFO T ");
            builder.Append(" left join (SELECT a.IDCardNo, a.ID,a.CheckDate FROM ARCHIVE_CUSTOMERBASEINFO a ");
            if (!strWhere.Contains("B.CheckDate"))
            {
                builder.Append(" where  a.CheckDate = (select max(c.CheckDate) from ARCHIVE_CUSTOMERBASEINFO c  where a.IDCardNo = c.IDCardNo )");
            }

            builder.Append(" ) B on T.IDCardNo = B.IDCardNo  ");
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
        /// 过期10天内访视人数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetVistRecordCountTenDay(string strWhere, string CheckDate, string orderby)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  * from  (");
            builder.Append(" (SELECT D.IDCardNo, group_concat(D.OLDVisit) as OLDVisit,group_concat(D.DiaVisit) as DiaVisit, ");
            builder.Append(" group_concat(D.HyperVisit) as HyperVisit,group_concat(D.MentalVisit) as MentalVisit, group_concat(D.LungerVisit) as LungerVisit,");
            builder.Append(" group_concat(D.StrokeVisit) as StrokeVisit,group_concat(D.ChdVisit) as ChdVisit ");
            builder.Append(" from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextfollowUpDate) AS OLDVisit, NULL as HyperVisit,NULL as DiaVisit,null as MentalVisit,null as LungerVisit,null as StrokeVisit,null as ChdVisit ");
            builder.Append(" from OLDER_SELFCAREABILITY C  ");
            builder.Append(string.Format(" where  C.NextfollowUpDate between '{0}' and '{1}'  ", DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowUpDate " + CheckDate );
            }
            builder.Append(" GROUP BY C.IDCardNo ) ");
            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo, null,MAX(C.NextFollowUpDate) AS HyperVisit,NULL,NULL,null,null ,null ");
            builder.Append(" from CD_HYPERTENSIONFOLLOWUP C  ");
            builder.Append(string.Format(" where  C.NextFollowUpDate between '{0}' and '{1}'  ", DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowUpDate " + CheckDate );
            }
            builder.Append(" GROUP BY C.IDCardNo )  ");
            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,MAX(C.NextVisitDate) AS  DiaVisit,null,null,null,null  ");
            builder.Append(" from CD_DIABETESFOLLOWUP C ");
            builder.Append(string.Format(" where C.NextVisitDate between '{0}' and '{1}' ", DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.VisitDate " + CheckDate );
            }
            builder.Append(" GROUP BY C.IDCardNo )  ");
            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,null, MAX(C.NextFollowUpDate) AS MentalVisit,null,null,null ");
            builder.Append(" from CD_MENTALDISEASE_FOLLOWUP C ");
            builder.Append(string.Format(" where C.NextFollowUpDate between '{0}' and '{1}' ", DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowUpDate " + CheckDate  );
            }
            builder.Append(" GROUP BY C.IDCardNo )  ");
            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,null,null,MAX(C.NextVisitDate) AS LungerVisit,null,null ");
            builder.Append(" from CD_PTB_FIRSTVISIT C ");
            builder.Append(string.Format("where C.NextVisitDate between '{0}' and '{1}' ", DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowupDate " + CheckDate );
            }
            builder.Append(" GROUP BY C.IDCardNo )  ");
            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,null,null,null,MAX(C.NextFollowupDate) AS StrokeVisit,null ");
            builder.Append(" from CD_STROKE_FOLLOWUP C ");
            builder.Append(string.Format("where C.NextFollowupDate between '{0}' and '{1}' ", DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowupDate " + CheckDate );
            }
            builder.Append(" GROUP BY C.IDCardNo )  ");
            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,null,null,null,null,MAX(C.NextVisitDate) AS ChdVisit ");
            builder.Append(" from CD_CHD_FOLLOWUP C  ");
            builder.Append(string.Format("where NextVisitDate between '{0}' and '{1}' ", DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.VisitDate " + CheckDate );
            }
            builder.Append(" GROUP BY C.IDCardNo )  ");
            builder.Append(" )D ");
            builder.Append("where D.IDCardNo is not null GROUP BY D.IDCardNo )B ");
            builder.Append(" INNER JOIN  ");
            builder.Append("(SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy  ");
            builder.Append("from ARCHIVE_BASEINFO T  ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by " + orderby);
            }
            else
            {
                builder.Append(" order by ID desc");
            }
           
            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 从未访视
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetNoVistRecordCount(string strWhere, string CheckDate, string orderby)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("select * from ( ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy,T.PopulationType  ");
            builder.Append(" from ARCHIVE_BASEINFO T ");
            builder.Append("WHERE ((T.PopulationType like '%4%') or (T.PopulationType like '%5%' )  ");
            builder.Append("or (T.PopulationType like '%6%') or ( T.PopulationType like '%7%'  ) ");
            builder.Append("or (T.PopulationType like '%8%') or (T.PopulationType like '%9%') ");
            builder.Append("or (T.PopulationType like '%10%' )) ");
            if (CheckDate.Trim() != "")
            {
                builder.Append(CheckDate);
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            builder.Append("  )P  LEFT JOIN  ");
            builder.Append(" (SELECT D.IDCardNo, group_concat(D.OLDVisit) as OLDVisit,group_concat(D.DiaVisit) as DiaVisit, ");
            builder.Append(" group_concat(D.HyperVisit) as HyperVisit,group_concat(D.MentalVisit) as MentalVisit, group_concat(D.LungerVisit) as LungerVisit,");
            builder.Append(" group_concat(D.StrokeVisit) as StrokeVisit,group_concat(D.ChdVisit) as ChdVisit ");
            builder.Append(" from ( ");
            builder.Append(" ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextfollowUpDate) AS OLDVisit, NULL as HyperVisit,NULL as DiaVisit,null as MentalVisit,null as LungerVisit,null as StrokeVisit,null as ChdVisit ");
            builder.Append(" from OLDER_SELFCAREABILITY C  ");
            builder.Append(" GROUP BY C.IDCardNo ) ");
          
            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo, null,MAX(C.NextFollowUpDate) AS HyperVisit,NULL,NULL,null,null ,null ");
            builder.Append(" from CD_HYPERTENSIONFOLLOWUP C  ");
            builder.Append(" GROUP BY C.IDCardNo ) ");

            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,MAX(C.NextVisitDate) AS  DiaVisit,null,null,null,null  ");
            builder.Append(" from CD_DIABETESFOLLOWUP C ");
            builder.Append(" GROUP BY C.IDCardNo ) ");

            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,null, MAX(C.NextFollowUpDate) AS MentalVisit,null,null,null ");
            builder.Append(" from CD_MENTALDISEASE_FOLLOWUP C ");
            builder.Append(" GROUP BY C.IDCardNo ) ");

            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,null,null,MAX(C.NextVisitDate) AS LungerVisit,null,null ");
            builder.Append(" from CD_PTB_FIRSTVISIT C ");
            builder.Append(" GROUP BY C.IDCardNo ) ");

            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,null,null,null,MAX(C.NextFollowupDate) AS StrokeVisit,null ");
            builder.Append(" from CD_STROKE_FOLLOWUP C ");
            builder.Append(" GROUP BY C.IDCardNo ) ");

            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,null,null,null,null,MAX(C.NextVisitDate) AS ChdVisit ");
            builder.Append(" from CD_CHD_FOLLOWUP C  ");
            builder.Append(" GROUP BY C.IDCardNo ) "); 
            builder.Append(" )D  where D.IDCardNo is not null GROUP BY D.IDCardNo ");
            builder.Append(" )B on B.IDCardNo=P.IDCardNo ) ");

            builder.Append("where  ((PopulationType like '%4%' and OLDVisit is null) or (PopulationType like '%5%' and MentalVisit is null) ");
            builder.Append(" or (PopulationType like '%6%' and HyperVisit is null) or (PopulationType like '%7%' and DiaVisit is null) ");
            builder.Append(" or (PopulationType like '%8%' and ChdVisit is null) or (PopulationType like '%9%' and StrokeVisit is null) ");
            builder.Append(" or (PopulationType like '%10%'and LungerVisit is null)) ");

           
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by " + orderby);
            }
            else
            {
                builder.Append(" order by ID desc");
            }

            return MySQLHelper.Query(builder.ToString());

        }

        /// <summary>
        /// 10天内应访视人数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetTenVisitRecordCount(string strWhere, string CheckDate, string orderby)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  * from  (");
            builder.Append(" (SELECT D.IDCardNo, group_concat(D.OLDVisit) as OLDVisit,group_concat(D.DiaVisit) as DiaVisit, ");
            builder.Append(" group_concat(D.HyperVisit) as HyperVisit,group_concat(D.MentalVisit) as MentalVisit, group_concat(D.LungerVisit) as LungerVisit,");
            builder.Append(" group_concat(D.StrokeVisit) as StrokeVisit,group_concat(D.ChdVisit) as ChdVisit ");
            builder.Append(" from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextfollowUpDate) AS OLDVisit, NULL as HyperVisit,NULL as DiaVisit,null as MentalVisit,null as LungerVisit,null as StrokeVisit,null as ChdVisit ");
            builder.Append(" from OLDER_SELFCAREABILITY C  ");
            builder.Append(string.Format(" where  C.NextfollowUpDate between '{0}' and '{1}'  ", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowUpDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo ) ");
            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo, null,MAX(C.NextFollowUpDate) AS HyperVisit,NULL,NULL,null,null ,null ");
            builder.Append(" from CD_HYPERTENSIONFOLLOWUP C  ");
            builder.Append(string.Format(" where  C.NextFollowUpDate between '{0}' and '{1}'  ", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowUpDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo )  ");
            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,MAX(C.NextVisitDate) AS  DiaVisit,null,null,null,null  ");
            builder.Append(" from CD_DIABETESFOLLOWUP C ");
            builder.Append(string.Format(" where C.NextVisitDate between '{0}' and '{1}' ", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.VisitDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo )  ");
            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,null, MAX(C.NextFollowUpDate) AS MentalVisit,null,null,null ");
            builder.Append(" from CD_MENTALDISEASE_FOLLOWUP C ");
            builder.Append(string.Format(" where C.NextFollowUpDate between '{0}' and '{1}' ", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowUpDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo )  ");
            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,null,null,MAX(C.NextVisitDate) AS LungerVisit,null,null ");
            builder.Append(" from CD_PTB_FIRSTVISIT C ");
            builder.Append(string.Format("where C.NextVisitDate between '{0}' and '{1}' ", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowupDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo )  ");
            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,null,null,null,MAX(C.NextFollowupDate) AS StrokeVisit,null ");
            builder.Append(" from CD_STROKE_FOLLOWUP C ");
            builder.Append(string.Format("where C.NextFollowupDate between '{0}' and '{1}' ", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowupDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo )  ");
            builder.Append(" UNION ");
            builder.Append(" (select C.IDCardNo,null,null,null,null,null,null,MAX(C.NextVisitDate) AS ChdVisit ");
            builder.Append(" from CD_CHD_FOLLOWUP C  ");
            builder.Append(string.Format("where NextVisitDate between '{0}' and '{1}' ", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.VisitDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo )  ");
            builder.Append(" )D ");
            builder.Append("where D.IDCardNo is not null GROUP BY D.IDCardNo )B ");
            builder.Append(" INNER JOIN  ");
            builder.Append("(SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy  ");
            builder.Append("from ARCHIVE_BASEINFO T  ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by " + orderby);
            }
            else
            {
                builder.Append(" order by ID desc");
            }

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 老年人10天内应访视人数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetTenOLDVisitCount(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextfollowUpDate) from OLDER_SELFCAREABILITY C  ");
            builder.Append(string.Format(" where NextfollowUpDate between '{0}' and '{1}'  ", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowUpDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo)B INNER JOIN  ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy   ");
            builder.Append(" from ARCHIVE_BASEINFO T   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 高血压10天内应访视人数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetTenHyperVisitCount(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextfollowUpDate) from CD_HYPERTENSIONFOLLOWUP C  ");
            builder.Append(string.Format(" where NextfollowUpDate between '{0}' and '{1}'  ", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowUpDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo)B INNER JOIN  ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy   ");
            builder.Append(" from ARCHIVE_BASEINFO T   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 糖尿病10天内应访视人数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetTenDiaVisitCount(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextVisitDate) from CD_DIABETESFOLLOWUP C  ");
            builder.Append(string.Format(" where NextVisitDate between '{0}' and '{1}'  ", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.VisitDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo)B INNER JOIN  ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy   ");
            builder.Append(" from ARCHIVE_BASEINFO T   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 精神疾病10天应内访视人数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetTenMentalVisitCount(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextfollowUpDate) from CD_MENTALDISEASE_FOLLOWUP C  ");
            builder.Append(string.Format(" where NextfollowUpDate between '{0}' and '{1}'  ", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowUpDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo)B INNER JOIN  ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy   ");
            builder.Append(" from ARCHIVE_BASEINFO T   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 肺结核10天内应访视人数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetTenLungerVisitCount(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextVisitDate) from CD_PTB_FIRSTVISIT C  ");
            builder.Append(string.Format(" where NextVisitDate between '{0}' and '{1}'  ", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowUpDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo)B INNER JOIN  ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy   ");
            builder.Append(" from ARCHIVE_BASEINFO T   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 脑卒中10天内应访视人数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetTenStrokeVisitCount(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextfollowUpDate) from CD_STROKE_FOLLOWUP C  ");
            builder.Append(string.Format(" where NextfollowUpDate between '{0}' and '{1}'  ", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.FollowUpDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo)B INNER JOIN  ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy   ");
            builder.Append(" from ARCHIVE_BASEINFO T   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 冠心病10天内应访视人数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetTenChdVisitCount(string strWhere, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from ( ");
            builder.Append(" (select C.IDCardNo, MAX(C.NextVisitDate) from CD_CHD_FOLLOWUP C  ");
            builder.Append(string.Format(" where NextVisitDate between '{0}' and '{1}'  ", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(CheckDate))
            {
                builder.Append(" and C.VisitDate " + CheckDate);
            }
            builder.Append(" GROUP BY C.IDCardNo)B INNER JOIN  ");
            builder.Append(" (SELECT T.ID, T.CustomerName, T.IDCardNo, T.HouseHoldAddress,T.Birthday,T.CreateDate,T.CreateMenName,T.CreateBy   ");
            builder.Append(" from ARCHIVE_BASEINFO T   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append("  )P ");
            builder.Append(" on B.IDCardNo=P.IDCardNo ) ");

            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }

            return Convert.ToInt32(single);
        }

        public bool Update(RecordsBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_BASEINFO set ");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("OrgProvinceID=@OrgProvinceID,");
            builder.Append("OrgCityID=@OrgCityID,");
            builder.Append("OrgDistrictID=@OrgDistrictID,");
            builder.Append("OrgTownID=@OrgTownID,");
            builder.Append("OrgVillageID=@OrgVillageID,");
            builder.Append("ProvinceID=@ProvinceID,");
            builder.Append("CityID=@CityID,");
            builder.Append("DistrictID=@DistrictID,");
            builder.Append("TownID=@TownID,");
            builder.Append("VillageID=@VillageID,");
            builder.Append("WorkUnit=@WorkUnit,");
            builder.Append("LiveType=@LiveType,");
            builder.Append("Nation=@Nation,");
            builder.Append("RH=@RH,");
            builder.Append("Culture=@Culture,");
            builder.Append("Job=@Job,");
            builder.Append("MaritalStatus=@MaritalStatus,");
            builder.Append("MedicalPayType=@MedicalPayType,");
            builder.Append("DrugAllergic=@DrugAllergic,");
            builder.Append("Disease=@Disease,");
            builder.Append("DiseasEndition=@DiseasEndition,");
            builder.Append("CustomerName=@CustomerName,");
            builder.Append("Doctor=@Doctor,");
            builder.Append("Sex=@Sex,");
            builder.Append("Birthday=@Birthday,");
            builder.Append("ContactName=@ContactName,");
            builder.Append("ContactPhone=@ContactPhone,");
            builder.Append("BloodType=@BloodType,");
            builder.Append("Phone=@Phone,");
            builder.Append("MedicalPayTypeOther=@MedicalPayTypeOther,");
            builder.Append("DrugAllergicOther=@DrugAllergicOther,");
            builder.Append("DiseaseEx=@DiseaseEx,");
            builder.Append("DiseasEnditionEx=@DiseasEnditionEx,");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("Address=@Address,");
            builder.Append("HouseHoldAddress=@HouseHoldAddress,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("Minority=@Minority,");
            builder.Append("Exposure=@Exposure,");
            builder.Append("CreateBy=@CreateBy,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("PopulationType=@PopulationType,");
            builder.Append("FamilyIDCardNo=@FamilyIDCardNo,");
            builder.Append("HouseRelation=@HouseRelation,");
            builder.Append("HouseRealOther=@HouseRealOther,");
            builder.Append("Email=@Email,");
            builder.Append("IsDelete=@IsDelete,");
            builder.Append("IsUpdate=@IsUpdate,");
            builder.Append("TownName=@TownName,");
            builder.Append("VillageName=@VillageName,");
            builder.Append("CreateUnitName=@CreateUnitName,");
            builder.Append("CreateMenName=@CreateMenName,");
            builder.Append("TownMedicalCard=@TownMedicalCard,");
            builder.Append("ResidentMedicalCard=@ResidentMedicalCard,");
            builder.Append("PovertyReliefMedicalCard=@PovertyReliefMedicalCard,");
            builder.Append("LiveCondition=@LiveCondition, ");
            builder.Append("FamilyNum=@FamilyNum,");
            builder.Append("FamilyStructure=@FamilyStructure, ");
            builder.Append("HouseName=@HouseName, ");
            builder.Append("PreSituation=@PreSituation, ");
            builder.Append("PreNum=@PreNum, ");
            builder.Append("YieldNum=@YieldNum, ");
            builder.Append("Chemical=@Chemical, ");
            builder.Append("Poison=@Poison, ");
            builder.Append("Radial=@Radial ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@OrgProvinceID", MySqlDbType.Decimal),
                new MySqlParameter("@OrgCityID", MySqlDbType.Decimal), 
                new MySqlParameter("@OrgDistrictID", MySqlDbType.Decimal),
                new MySqlParameter("@OrgTownID", MySqlDbType.Decimal), 
                new MySqlParameter("@OrgVillageID", MySqlDbType.Decimal),
                new MySqlParameter("@ProvinceID", MySqlDbType.Decimal),
                new MySqlParameter("@CityID", MySqlDbType.Decimal),
                new MySqlParameter("@DistrictID", MySqlDbType.Decimal),
                new MySqlParameter("@TownID", MySqlDbType.Decimal),
                new MySqlParameter("@VillageID", MySqlDbType.Decimal),
                new MySqlParameter("@WorkUnit", MySqlDbType.String, 200),
                new MySqlParameter("@LiveType", MySqlDbType.String, 1), 
                new MySqlParameter("@Nation", MySqlDbType.String, 20), 
                new MySqlParameter("@RH", MySqlDbType.String, 1), 
                new MySqlParameter("@Culture", MySqlDbType.String, 1),
                new MySqlParameter("@Job", MySqlDbType.String, 1),
                new MySqlParameter("@MaritalStatus", MySqlDbType.String, 1), 
                new MySqlParameter("@MedicalPayType", MySqlDbType.String, 30),
                new MySqlParameter("@DrugAllergic", MySqlDbType.String, 10),
                new MySqlParameter("@Disease", MySqlDbType.String, 1), 
                new MySqlParameter("@DiseasEndition", MySqlDbType.String, 30),
                new MySqlParameter("@CustomerName", MySqlDbType.String, 30),
                new MySqlParameter("@Doctor", MySqlDbType.String, 30), 
                new MySqlParameter("@Sex", MySqlDbType.String, 1), 
                new MySqlParameter("@Birthday", MySqlDbType.Date),
                new MySqlParameter("@ContactName", MySqlDbType.String, 30),
                new MySqlParameter("@ContactPhone", MySqlDbType.String, 15),
                new MySqlParameter("@BloodType", MySqlDbType.String, 1),
                new MySqlParameter("@Phone", MySqlDbType.String, 15),
                new MySqlParameter("@MedicalPayTypeOther", MySqlDbType.String, 50), 
                new MySqlParameter("@DrugAllergicOther", MySqlDbType.String, 200), 
                new MySqlParameter("@DiseaseEx", MySqlDbType.String, 200),
                new MySqlParameter("@DiseasEnditionEx", MySqlDbType.String, 200),
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@Address", MySqlDbType.String, 200),
                new MySqlParameter("@HouseHoldAddress", MySqlDbType.String, 200), 
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@Minority", MySqlDbType.String, 30), 
                new MySqlParameter("@Exposure", MySqlDbType.String, 10),
                new MySqlParameter("@CreateBy", MySqlDbType.String, 18), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String, 18),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@PopulationType", MySqlDbType.String, 50), 
                new MySqlParameter("@FamilyIDCardNo", MySqlDbType.String,21), 
                new MySqlParameter("@HouseRelation", MySqlDbType.String, 10), 
                new MySqlParameter("@HouseRealOther", MySqlDbType.String, 20), 
                new MySqlParameter("@Email", MySqlDbType.String, 50),
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1), 
                new MySqlParameter("@IsUpdate", MySqlDbType.String, 1), 
                new MySqlParameter("@TownName", MySqlDbType.String, 32), 
                new MySqlParameter("@VillageName", MySqlDbType.String, 32),
                new MySqlParameter("@CreateUnitName", MySqlDbType.String, 32), 
                new MySqlParameter("@CreateMenName", MySqlDbType.String, 32),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8),
                new MySqlParameter("@TownMedicalCard", MySqlDbType.String, 50),
                new MySqlParameter("@ResidentMedicalCard", MySqlDbType.String, 50),
                new MySqlParameter("@PovertyReliefMedicalCard", MySqlDbType.String, 50),
                new MySqlParameter("@LiveCondition", MySqlDbType.String, 20),
                new MySqlParameter("@FamilyNum", MySqlDbType.Decimal),
                new MySqlParameter("@FamilyStructure", MySqlDbType.String, 100),
                new MySqlParameter("@HouseName", MySqlDbType.String, 100),
                new MySqlParameter("@PreSituation", MySqlDbType.String, 10),
                new MySqlParameter("@PreNum", MySqlDbType.String, 100),
                new MySqlParameter("@YieldNum", MySqlDbType.String, 100),
                new MySqlParameter("@Chemical", MySqlDbType.String, 100),
                new MySqlParameter("@Poison", MySqlDbType.String, 100),
                new MySqlParameter("@Radial", MySqlDbType.String, 100)

             };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.OrgProvinceID;
            cmdParms[3].Value = model.OrgCityID;
            cmdParms[4].Value = model.OrgDistrictID;
            cmdParms[5].Value = model.OrgTownID;
            cmdParms[6].Value = model.OrgVillageID;
            cmdParms[7].Value = model.ProvinceID;
            cmdParms[8].Value = model.CityID;
            cmdParms[9].Value = model.DistrictID;
            cmdParms[10].Value = model.TownID;
            cmdParms[11].Value = model.VillageID;
            cmdParms[12].Value = model.WorkUnit;
            cmdParms[13].Value = model.LiveType;
            cmdParms[14].Value = model.Nation;
            cmdParms[15].Value = model.RH;
            cmdParms[16].Value = model.Culture;
            cmdParms[17].Value = model.Job;
            cmdParms[18].Value = model.MaritalStatus;
            cmdParms[19].Value = model.MedicalPayType;
            cmdParms[20].Value = model.DrugAllergic;
            cmdParms[21].Value = model.Disease;
            cmdParms[22].Value = model.DiseasEndition;
            cmdParms[23].Value = model.CustomerName;
            cmdParms[24].Value = model.Doctor;
            cmdParms[25].Value = model.Sex;
            cmdParms[26].Value = model.Birthday;
            cmdParms[27].Value = model.ContactName;
            cmdParms[28].Value = model.ContactPhone;
            cmdParms[29].Value = model.BloodType;
            cmdParms[30].Value = model.Phone;
            cmdParms[31].Value = model.MedicalPayTypeOther;
            cmdParms[32].Value = model.DrugAllergicOther;
            cmdParms[33].Value = model.DiseaseEx;
            cmdParms[34].Value = model.DiseasEnditionEx;
            cmdParms[35].Value = model.CustomerID;
            cmdParms[36].Value = model.Address;
            cmdParms[37].Value = model.HouseHoldAddress;
            cmdParms[38].Value = model.CreateUnit;
            cmdParms[39].Value = model.Minority;
            cmdParms[40].Value = model.Exposure;
            cmdParms[41].Value = model.CreateBy;
            cmdParms[42].Value = model.CreateDate;
            cmdParms[43].Value = model.LastUpdateBy;
            cmdParms[44].Value = model.LastUpdateDate;
            cmdParms[45].Value = model.PopulationType;
            cmdParms[46].Value = model.FamilyIDCardNo;
            cmdParms[47].Value = model.HouseRelation;
            cmdParms[48].Value = model.HouseRealOther;
            cmdParms[49].Value = model.Email;
            cmdParms[50].Value = model.IsDelete;
            cmdParms[51].Value = model.IsUpdate;
            cmdParms[52].Value = model.TownName;
            cmdParms[53].Value = model.VillageName;
            cmdParms[54].Value = model.CreateUnitName;
            cmdParms[55].Value = model.CreateMenName;
            cmdParms[56].Value = model.ID;
            cmdParms[57].Value = model.TownMedicalCard;
            cmdParms[58].Value = model.ResidentMedicalCard;
            cmdParms[59].Value = model.PovertyReliefMedicalCard;
            cmdParms[60].Value = model.LiveCondition;
            cmdParms[61].Value = model.FamilyNum;
            cmdParms[62].Value = model.FamilyStructure;
            cmdParms[63].Value = model.HouseName;
            cmdParms[64].Value = model.PreSituation;
            cmdParms[65].Value = model.PreNum;
            cmdParms[66].Value = model.YieldNum;
            cmdParms[67].Value = model.Chemical;
            cmdParms[68].Value = model.Poison;
            cmdParms[69].Value = model.Radial;


            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet dtbaseinfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select IDCardNo FROM ARCHIVE_BASEINFO");
            return MySQLHelper.Query(builder.ToString());
        }

        public int UpdateIDCard(string Oldidcard, string Newidcard)
        {
            List<string> list = new List<string>();
            ArrayList sQLStringList = new ArrayList();

            string[] strArray = new string[] { "CD_CHD_BASEINFO", 
                "CD_CHD_FOLLOWUP", "CD_DIABETES_BASEINFO", "CD_DIABETESFOLLOWUP", "CD_DRUGCONDITION", "CD_HYPERTENSION_BASEINFO", 
                "CD_HYPERTENSIONFOLLOWUP", "CD_PTB_FIRSTVISIT", 
                "CD_PTB_VISIT", "CD_MENTALDISEASE_BASEINFO", "CD_MENTALDISEASE_FOLLOWUP", "CD_STROKE_BASEINFO",
                "CD_STROKE_FOLLOWUP", "ARCHIVE_DEVICEINFO", "CHILD_BASEINFO", "CHILD_NEWBORN_FOLLOWUP", "CHILD_ONE2THREE_YEAR_OLD", "CHILD_TCMHM_ONE",
                "CHILD_TCMHM_ONE2THREE", "CHILD_TCMHM_THREE2SIX", "CHILD_THREE2SIX_YEAR_OLD","CHILD_WITHIN_ONE_YEAR_OLD", "OLD_MEDICINE_CN", "OLD_MEDICINE_RESULT",
                "OLDER_SELFCAREABILITY", "ARCHIVE_ASSESSMENTGUIDE", "ARCHIVE_ASSISTCHECK","ARCHIVE_BASEINFO", "ARCHIVE_CARD", "ARCHIVE_CUSTOMERBASEINFO",
                "ARCHIVE_ECG", "ARCHIVE_EDUCATION_ACTIVITIES", "ARCHIVE_ENVIRONMENT","ARCHIVE_FAMILYBEDHISTORY", "ARCHIVE_FAMILYHISTORYINFO", 
                "ARCHIVE_FAMILY_INFO","ARCHIVE_GENERALCONDITION", "ARCHIVE_HEALTHQUESTION", "ARCHIVE_HOSPITALHISTORY","ARCHIVE_ILLNESSHISTORYINFO",
                "ARCHIVE_INOCULATIONHISTORY", "ARCHIVE_LIFESTYLE", "ARCHIVE_MEDICATION","ARCHIVE_MEDI_PHYS_DIST","ARCHIVE_PHYSICALEXAM",
                "ARCHIVE_VISCERAFUNCTION", "SYS_ERROR_LOG","INOCULATION_CARD", 
                "INOCULATION_PROGRAM","GRAVIDA_BASEINFO", "GRAVIDA_FIRSTFOLLOWUP", "GRAVIDA_POSTPARTUM",
                "GRAVIDA_POSTPARTUM_42DAY", "GRAVIDA_PRE_ASSISTCHECK", "GRAVIDA_TWO2FIVE_FOLLOWUP","SYS_UPLOADED","ARCHIVE_RECEPTION_RECORD",
                "ARCHIVE_CONSULTATION_RECORD","ARCHIVE_REFERRAL"
            };

            foreach (string str in strArray)
            {
                list.Add(str);
            }

            foreach (string str2 in list)
            {
                sQLStringList.Add(string.Format("update {0} set IDCardNo='{1}' where IDCardNo = '{2}'", str2, Newidcard, Oldidcard));
            }

            MySQLHelper.ExecuteSqlTran(sQLStringList);

            return 0;
        }

        public void UpdatePhysicalClass(string idcard,string PhysicalClass) {
            MySQLHelper.ExecuteSql("update ARCHIVE_BASEINFO set PhysicalClass='"+ PhysicalClass + "' where idcardno='"+idcard+"'");
        }
        #region 漏项查询

        /// <summary>
        /// 个人资料漏项查询
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetData(string strCol, string strWhere, string orderBy, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("SELECT * FROM( ");
            builder.AppendFormat("SELECT Base.IDCardNo,Base.Nation,Base.CustomerName,Base.Sex,Base.Minority, ");
            builder.AppendFormat("DATE_FORMAT(Base.Birthday,'%Y-%m-%d') AS Birthday,Base.Phone ");
            builder.AppendFormat("{0}", strCol);
            builder.AppendFormat(" FROM ARCHIVE_BASEINFO Base ");
            builder.AppendFormat(" LEFT JOIN ");
            builder.AppendFormat(" (SELECT IDCardNo,CheckDate,Doctor FROM ARCHIVE_CUSTOMERBASEINFO Customer ");
            builder.AppendFormat("    WHERE CheckDate=(");
            builder.AppendFormat("        SELECT MAX(CheckDate) FROM ARCHIVE_CUSTOMERBASEINFO");
            builder.AppendFormat("        WHERE IDCardNo=Customer.IDCardNo");
            builder.AppendFormat("    )");
            builder.AppendFormat(" ) Customer ON Base.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_ENVIRONMENT Environment ");
            builder.AppendFormat(" ON Environment.IDCardNo=Base.IDCardNo ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_ILLNESSHISTORYINFO Ill ");
            builder.AppendFormat(" ON Ill.IDCardNo=Base.IDCardNo AND IllnessType='1' ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_FAMILYHISTORYINFO Family ");
            builder.AppendFormat(" ON Family.IDCardNo=Base.IDCardNo ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY Base.IDCardNo");

            if (!string.IsNullOrEmpty(orderBy.Trim()))
            {
                builder.Append(" ORDER BY Base." + orderBy);
            }
            else
            {
                builder.Append(" ORDER BY Base.ID DESC");
            }

            builder.AppendFormat(") AS DATAS");
            builder.AppendFormat(" WHERE BaseInfoCount>0 OR RecordInfoCount>0 OR HealthInfoCount>0");
            builder.AppendFormat(" LIMIT {0},{1}", startIndex, endIndex);

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 个人资料漏项查询清单笔数
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetDataCount(string strCol, string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("SELECT COUNT(0) FROM( ");
            builder.AppendFormat("SELECT Base.IDCardNo");
            builder.AppendFormat("{0}", strCol);
            builder.AppendFormat(" FROM ARCHIVE_BASEINFO Base ");
            builder.AppendFormat(" LEFT JOIN ");
            builder.AppendFormat(" (SELECT IDCardNo,CheckDate,Doctor FROM ARCHIVE_CUSTOMERBASEINFO Customer ");
            builder.AppendFormat("    WHERE CheckDate=(");
            builder.AppendFormat("        SELECT MAX(CheckDate) FROM ARCHIVE_CUSTOMERBASEINFO");
            builder.AppendFormat("        WHERE IDCardNo=Customer.IDCardNo");
            builder.AppendFormat("    )");
            builder.AppendFormat(" ) Customer ON Base.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_ENVIRONMENT Environment ");
            builder.AppendFormat(" ON Environment.IDCardNo=Base.IDCardNo ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_ILLNESSHISTORYINFO Ill ");
            builder.AppendFormat(" ON Ill.IDCardNo=Base.IDCardNo AND IllnessType='1' ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_FAMILYHISTORYINFO Family ");
            builder.AppendFormat(" ON Family.IDCardNo=Base.IDCardNo ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY Base.IDCardNo");
            builder.Append(") AS DATAS");
            builder.Append(" WHERE BaseInfoCount>0 OR RecordInfoCount>0 OR HealthInfoCount>0");

            object single = MySQLHelper.GetSingle(builder.ToString());

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 体检资料漏项查询
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetHealthData(string strCol, string strWhere, string orderBy, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("SELECT * FROM( ");
            builder.AppendFormat("SELECT Base.IDCardNo,Base.Nation,Base.CustomerName,Base.Sex,Base.Minority, ");
            builder.AppendFormat("DATE_FORMAT(Base.Birthday,'%Y-%m-%d') AS Birthday,Base.Phone, ");
            builder.AppendFormat("DATE_FORMAT(Customer.CheckDate,'%Y-%m-%d') AS CheckDate,Customer.ID AS CustomerID ");
            builder.AppendFormat("{0}", strCol);
            builder.AppendFormat(" FROM ARCHIVE_BASEINFO Base ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_CUSTOMERBASEINFO Customer ");
            builder.AppendFormat(" ON Base.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_GENERALCONDITION General ");
            builder.AppendFormat(" ON General.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=General.OutKey ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_LIFESTYLE Life ");
            builder.AppendFormat(" ON Life.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=Life.OutKey ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_VISCERAFUNCTION Function ");
            builder.AppendFormat(" ON Function.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=Function.OutKey ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_PHYSICALEXAM Physical ");
            builder.AppendFormat(" ON Physical.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=Physical.OutKey ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_ASSISTCHECK Checks ");
            builder.AppendFormat(" ON Checks.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=Checks.OutKey ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_HEALTHQUESTION Health ");
            builder.AppendFormat(" ON Health.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=Health.OutKey ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_ASSESSMENTGUIDE Assess ");
            builder.AppendFormat(" ON Assess.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=Assess.OutKey ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_INOCULATIONHISTORY Inocula ");
            builder.AppendFormat(" ON Inocula.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=Inocula.OutKey ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY Base.IDCardNo,Customer.CheckDate");

            if (!string.IsNullOrEmpty(orderBy.Trim()))
            {
                builder.Append(" ORDER BY Base." + orderBy);
            }
            else
            {
                builder.Append(" ORDER BY Base.ID DESC");
            }

            builder.AppendFormat(") AS DATAS");
            builder.AppendFormat(" WHERE NormalCount>0 OR LifeCount>0 OR PhysicalCount>0");
            builder.AppendFormat(" OR CheckCount>0 OR FunctionCount>0 OR AssessCount>0 or HealthCount>0");
            builder.AppendFormat(" LIMIT {0},{1}", startIndex, endIndex);

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 体检资料漏项查询清单笔数
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetHealthCount(string strCol, string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("SELECT COUNT(*) FROM( ");
            builder.AppendFormat("SELECT Base.IDCardNo ");
            builder.AppendFormat("{0}", strCol);
            builder.AppendFormat(" FROM ARCHIVE_BASEINFO Base ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_CUSTOMERBASEINFO Customer ");
            builder.AppendFormat(" ON Base.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_GENERALCONDITION General ");
            builder.AppendFormat(" ON General.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=General.OutKey ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_LIFESTYLE Life ");
            builder.AppendFormat(" ON Life.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=Life.OutKey ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_VISCERAFUNCTION Function ");
            builder.AppendFormat(" ON Function.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=Function.OutKey ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_PHYSICALEXAM Physical ");
            builder.AppendFormat(" ON Physical.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=Physical.OutKey ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_ASSISTCHECK Checks ");
            builder.AppendFormat(" ON Checks.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=Checks.OutKey ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_HEALTHQUESTION Health ");
            builder.AppendFormat(" ON Health.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=Health.OutKey ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_ASSESSMENTGUIDE Assess ");
            builder.AppendFormat(" ON Assess.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=Assess.OutKey ");
            builder.AppendFormat(" LEFT JOIN ARCHIVE_INOCULATIONHISTORY Inocula ");
            builder.AppendFormat(" ON Inocula.IDCardNo=Customer.IDCardNo ");
            builder.AppendFormat(" AND Customer.ID=Inocula.OutKey ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.AppendFormat(" GROUP BY Base.IDCardNo,Customer.CheckDate");
            builder.AppendFormat(") AS DATAS");
            builder.AppendFormat(" WHERE NormalCount>0 OR LifeCount>0 OR PhysicalCount>0");
            builder.AppendFormat(" OR CheckCount>0 OR FunctionCount>0 OR AssessCount>0 OR HealthCount > 0");

            object single = MySQLHelper.GetSingle(builder.ToString());

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 老年随访漏项查询
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetOldData(string strCol, string strWhere, string orderBy, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("SELECT * FROM( ");
            builder.AppendFormat("SELECT Base.IDCardNo,Base.Nation,Base.CustomerName,Base.Sex,Base.Minority, ");
            builder.AppendFormat("DATE_FORMAT(Base.Birthday,'%Y-%m-%d') AS Birthday,Base.Phone, ");
            builder.AppendFormat("DATE_FORMAT(Older.FollowUpDate,'%Y-%m-%d') AS FollowUpDate ");
            builder.AppendFormat("{0}", strCol);
            builder.AppendFormat(" FROM ARCHIVE_BASEINFO Base ");
            builder.AppendFormat(" LEFT JOIN OLDER_SELFCAREABILITY Older");
            builder.AppendFormat(" ON Base.IDCardNo=Older.IDCardNo ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY Base.IDCardNo");

            if (!string.IsNullOrEmpty(orderBy.Trim()))
            {
                builder.Append(" ORDER BY Base." + orderBy);
            }
            else
            {
                builder.Append(" ORDER BY Base.ID DESC");
            }

            builder.AppendFormat(") AS DATAS");
            builder.AppendFormat(" WHERE BaseCount>0");
            builder.AppendFormat(" LIMIT {0},{1}", startIndex, endIndex);

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 老年随访漏项查询清单笔数
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetOldDataCount(string strCol, string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("SELECT COUNT(0) FROM( ");
            builder.AppendFormat("SELECT Base.IDCardNo");
            builder.AppendFormat("{0}", strCol);
            builder.AppendFormat(" FROM ARCHIVE_BASEINFO Base ");
            builder.AppendFormat(" LEFT JOIN OLDER_SELFCAREABILITY Older");
            builder.AppendFormat(" ON Base.IDCardNo=Older.IDCardNo ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY Base.IDCardNo");
            builder.Append(") AS DATAS");
            builder.Append(" WHERE BaseCount>0");

            object single = MySQLHelper.GetSingle(builder.ToString());

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 高血压随访漏项查询
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetHyperData(string strCol, string strWhere, string orderBy, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("SELECT * FROM( ");
            builder.AppendFormat("SELECT Base.IDCardNo,Base.Nation,Base.CustomerName,Base.Sex,Base.Minority, ");
            builder.AppendFormat("DATE_FORMAT(Base.Birthday,'%Y-%m-%d') AS Birthday,Base.Phone, ");
            builder.AppendFormat("DATE_FORMAT(Visit.FollowUpDate,'%Y-%m-%d') AS FollowUpDate ");
            builder.AppendFormat("{0}", strCol);
            builder.AppendFormat(" FROM ARCHIVE_BASEINFO Base ");
            builder.AppendFormat(" LEFT JOIN CD_HYPERTENSION_BASEINFO HyperBase");
            builder.AppendFormat(" ON Base.IDCardNo=HyperBase.IDCardNo ");
            builder.AppendFormat(" LEFT JOIN CD_HYPERTENSIONFOLLOWUP Visit");
            builder.AppendFormat(" ON Base.IDCardNo=Visit.IDCardNo ");
            builder.AppendFormat(" LEFT JOIN CD_DRUGCONDITION Conditions");
            builder.AppendFormat(" ON Base.IDCardNo=Conditions.IDCardNo ");
            builder.AppendFormat(" AND Conditions.Type=1 ");
            builder.AppendFormat(" AND Visit.ID=Conditions.OutKey ");
            builder.AppendFormat(" LEFT JOIN CD_DRUGCONDITION ConditionChange");
            builder.AppendFormat(" ON Base.IDCardNo=ConditionChange.IDCardNo ");
            builder.AppendFormat(" AND ConditionChange.Type=7 ");
            builder.AppendFormat(" AND Visit.ID=ConditionChange.OutKey ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY Base.IDCardNo");

            if (!string.IsNullOrEmpty(orderBy.Trim()))
            {
                builder.Append(" ORDER BY Base." + orderBy);
            }
            else
            {
                builder.Append(" ORDER BY Base.ID DESC");
            }

            builder.AppendFormat(") AS DATAS");
            builder.AppendFormat(" WHERE BaseCount>0 AND VisitCount>0");
            builder.AppendFormat(" LIMIT {0},{1}", startIndex, endIndex);

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 高血压随访漏项查询清单笔数
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetHyperDataCount(string strCol, string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("SELECT COUNT(0) FROM( ");
            builder.AppendFormat("SELECT Base.IDCardNo");
            builder.AppendFormat("{0}", strCol);
            builder.AppendFormat(" FROM ARCHIVE_BASEINFO Base ");
            builder.AppendFormat(" LEFT JOIN CD_HYPERTENSION_BASEINFO HyperBase");
            builder.AppendFormat(" ON Base.IDCardNo=HyperBase.IDCardNo ");
            builder.AppendFormat(" LEFT JOIN CD_HYPERTENSIONFOLLOWUP Visit");
            builder.AppendFormat(" ON Base.IDCardNo=Visit.IDCardNo ");
            builder.AppendFormat(" LEFT JOIN CD_DRUGCONDITION Conditions");
            builder.AppendFormat(" ON Base.IDCardNo=Conditions.IDCardNo ");
            builder.AppendFormat(" AND Conditions.Type=1 ");
            builder.AppendFormat(" AND Visit.ID=Conditions.OutKey ");
            builder.AppendFormat(" LEFT JOIN CD_DRUGCONDITION ConditionChange");
            builder.AppendFormat(" ON Base.IDCardNo=ConditionChange.IDCardNo ");
            builder.AppendFormat(" AND ConditionChange.Type=7 ");
            builder.AppendFormat(" AND Visit.ID=ConditionChange.OutKey ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY Base.IDCardNo");
            builder.Append(") AS DATAS");
            builder.Append(" WHERE BaseCount>0 AND VisitCount>0");

            object single = MySQLHelper.GetSingle(builder.ToString());

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 糖尿病随访漏项查询
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetDiabeteData(string strCol, string strWhere, string orderBy, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("SELECT * FROM( ");
            builder.AppendFormat("SELECT Base.IDCardNo,Base.Nation,Base.CustomerName,Base.Sex,Base.Minority, ");
            builder.AppendFormat("DATE_FORMAT(Base.Birthday,'%Y-%m-%d') AS Birthday,Base.Phone, ");
            builder.AppendFormat("DATE_FORMAT(Visit.VisitDate,'%Y-%m-%d') AS VisitDate ");
            builder.AppendFormat("{0}", strCol);
            builder.AppendFormat(" FROM ARCHIVE_BASEINFO Base ");
            builder.AppendFormat(" LEFT JOIN CD_DIABETES_BASEINFO DiabeteBase");
            builder.AppendFormat(" ON Base.IDCardNo=DiabeteBase.IDCardNo ");
            builder.AppendFormat(" LEFT JOIN CD_DIABETESFOLLOWUP Visit");
            builder.AppendFormat(" ON Base.IDCardNo=Visit.IDCardNo ");
            builder.AppendFormat(" LEFT JOIN CD_DRUGCONDITION Conditions");
            builder.AppendFormat(" ON Base.IDCardNo=Conditions.IDCardNo ");
            builder.AppendFormat(" AND Conditions.Type=2 ");
            builder.AppendFormat(" AND Visit.ID=Conditions.OutKey ");
            builder.AppendFormat(" LEFT JOIN CD_DRUGCONDITION ConditionChange");
            builder.AppendFormat(" ON Base.IDCardNo=ConditionChange.IDCardNo ");
            builder.AppendFormat(" AND ConditionChange.Type=8 ");
            builder.AppendFormat(" AND Visit.ID=ConditionChange.OutKey ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY Base.IDCardNo");

            if (!string.IsNullOrEmpty(orderBy.Trim()))
            {
                builder.Append(" ORDER BY Base." + orderBy);
            }
            else
            {
                builder.Append(" ORDER BY Base.ID DESC");
            }

            builder.AppendFormat(") AS DATAS");
            builder.AppendFormat(" WHERE BaseCount>0 AND VisitCount>0");
            builder.AppendFormat(" LIMIT {0},{1}", startIndex, endIndex);

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 糖尿病随访漏项查询清单笔数
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetDiabeteDataCount(string strCol, string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("SELECT COUNT(0) FROM( ");
            builder.AppendFormat("SELECT Base.IDCardNo");
            builder.AppendFormat("{0}", strCol);
            builder.AppendFormat(" FROM ARCHIVE_BASEINFO Base ");
            builder.AppendFormat(" LEFT JOIN CD_DIABETES_BASEINFO DiabeteBase");
            builder.AppendFormat(" ON Base.IDCardNo=DiabeteBase.IDCardNo ");
            builder.AppendFormat(" LEFT JOIN CD_DIABETESFOLLOWUP Visit");
            builder.AppendFormat(" ON Base.IDCardNo=Visit.IDCardNo ");
            builder.AppendFormat(" LEFT JOIN CD_DRUGCONDITION Conditions");
            builder.AppendFormat(" ON Base.IDCardNo=Conditions.IDCardNo ");
            builder.AppendFormat(" AND Conditions.Type=2 ");
            builder.AppendFormat(" AND Visit.ID=Conditions.OutKey ");
            builder.AppendFormat(" LEFT JOIN CD_DRUGCONDITION ConditionChange");
            builder.AppendFormat(" ON Base.IDCardNo=ConditionChange.IDCardNo ");
            builder.AppendFormat(" AND ConditionChange.Type=8 ");
            builder.AppendFormat(" AND Visit.ID=ConditionChange.OutKey ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY Base.IDCardNo");
            builder.Append(") AS DATAS");
            builder.Append(" WHERE BaseCount>0 AND VisitCount>0");

            object single = MySQLHelper.GetSingle(builder.ToString());

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        #endregion
    }
}