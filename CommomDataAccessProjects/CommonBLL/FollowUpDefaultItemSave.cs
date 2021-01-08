using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    /// <summary>
    /// 随访根据默认项自动新增
    /// </summary>
    public class FollowUpDefaultItemSave
    {
        OlderSelfCareabilityBLL OldSelfBLL = new OlderSelfCareabilityBLL();
        OlderMedicineCnBLL OldMedicineCnBLL = new OlderMedicineCnBLL();
        OlderMedicineResultBLL OldMedicineResultBLL = new OlderMedicineResultBLL();
        ChronicHypertensionVisitBLL HypertensionVisitBLL = new ChronicHypertensionVisitBLL();
        ChronicDiadetesVisitBLL DiadetesVisitBLL = new ChronicDiadetesVisitBLL();
        ChronicLungerFirstVisitBLL LungerVisitBLL = new ChronicLungerFirstVisitBLL();
        ChronicMentalDiseaseBaseInfoBLL MentalDiseaseBaseBLL = new ChronicMentalDiseaseBaseInfoBLL();
        ChronicMentalDiseaseVisitBLL MentalDiseaseVisitBLL = new ChronicMentalDiseaseVisitBLL();
        ChronicStrokeVisitBLL StrokeVisitBLL = new ChronicStrokeVisitBLL();
        ChronicChdVisitBLL ChdVisitBLL = new ChronicChdVisitBLL();
        OldMedGuideBLL OldMedGuideBLL = new OldMedGuideBLL();
        ChronicDrugConditionBLL DrugConditionGuideBLL = new ChronicDrugConditionBLL();

        DataTable dsRequire = new DataTable();

        public void SaveFollowUp(string IDCardNo, DateTime CheckDate, string PopulationType, string VersionNo, RecordsBaseInfoModel Model, RecordsCustomerBaseInfoModel CustomerModel)
        {
            try
            {
                dsRequire = new RequireBLL().GetList("TabName LIKE '%随访' ").Tables[0];

                // 4：老年人
                if (PopulationType.Contains("4")) SaveOld(IDCardNo, CheckDate, VersionNo);

                // 5：重精神病
                if (PopulationType.Contains("5")) SaveMental(IDCardNo, CheckDate, VersionNo, Model);

                // 6：高血压
                if (PopulationType.Contains("6")) SaveHypertension(IDCardNo, CheckDate, VersionNo, Model, CustomerModel);

                // 7：糖尿病
                if (PopulationType.Contains("7")) SaveDiadetes(IDCardNo, CheckDate, VersionNo, Model, CustomerModel);

                // 8：冠心病
                if (PopulationType.Contains("8")) SaveChd(IDCardNo, CheckDate, VersionNo, Model);

                // 9：脑卒中
                if (PopulationType.Contains("9")) SaveStroke(IDCardNo, CheckDate, VersionNo, Model);

                // 10：肺结核
                if (PopulationType.Contains("10")) SaveLunger(IDCardNo, CheckDate, VersionNo, Model);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 老年人
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <param name="VersionNo"></param>
        public void SaveOld(string IDCardNo, DateTime CheckDate, string VersionNo)
        {
            try
            {
                DataView dv = dsRequire.DefaultView;

                // 获取最后一次随访数据
                OlderSelfCareabilityModel oldSelfOldModel = OldSelfBLL.GetMaxModel(IDCardNo, "");
                if (oldSelfOldModel == null) oldSelfOldModel = new OlderSelfCareabilityModel();
                OlderSelfCareabilityModel oldSelfNewModel = new OlderSelfCareabilityModel();

                #region 自理能力

                dv.RowFilter = null;
                dv.RowFilter = "TabName='老年人随访' AND Comment='健康评估' AND (IsSetValue='是' OR IsSetValue='预设上次随访') ";
                DataTable dt = dv.ToTable();

                oldSelfNewModel = EntityAssignment<OlderSelfCareabilityModel>(oldSelfOldModel, oldSelfNewModel, dt);

                oldSelfNewModel.IDCardNo = IDCardNo;
                oldSelfNewModel.FollowUpDate = CheckDate;
                oldSelfNewModel.FollowUpDoctor = ConfigHelper.GetNode("doctorName");
                oldSelfNewModel.NextFollowUpDate = CheckDate.AddMonths(3);
                oldSelfNewModel.CreatedBy = ConfigHelper.GetNodeDec("doctor");
                oldSelfNewModel.CreatedDate = DateTime.Now;
                oldSelfNewModel.LastUpDateBy = ConfigHelper.GetNodeDec("doctor");
                oldSelfNewModel.LastUpDateDate = DateTime.Now;

                #endregion

                #region 中医体质及体质结果

                MedicineModel oldMedicineOldModel = new MedicineModel();

                // 如果为3.0版本，则中医与自理能力都是独立功能，获取最后一次随访数据
                if (VersionNo.Contains("3.0")) oldMedicineOldModel = OldMedicineCnBLL.GetAllModel(IDCardNo);
                else oldMedicineOldModel = OldMedicineCnBLL.GetModelByKey(oldSelfOldModel.ID);

                MedicineModel oldMedicineNewModel = new MedicineModel();
                if (oldMedicineOldModel == null) oldMedicineOldModel = new MedicineModel();

                // 中医体质预设上次随访内容
                oldMedicineNewModel = EntityAssignment<MedicineModel>(oldMedicineOldModel, oldMedicineNewModel);

                #endregion

                #region 保存默认值

                // 自理能力存档
                int id = OldSelfBLL.Add(oldSelfNewModel, VersionNo);

                if (id > 0)
                {
                    // 中医体质
                    oldMedicineNewModel.IDCardNo = IDCardNo;
                    oldMedicineNewModel.OutKey = id;
                    oldMedicineNewModel.RecordDate = CheckDate.ToString("yyyy-MM-dd");
                    oldMedicineNewModel.FollowUpDoctor = ConfigHelper.GetNode("doctorName");
                    oldMedicineNewModel.NextFollowUpDate = CheckDate.AddMonths(3);
                    oldMedicineNewModel.CreatedBy = ConfigHelper.GetNodeDec("doctor");
                    oldMedicineNewModel.CreatedDate = DateTime.Now;
                    oldMedicineNewModel.LastUpdateBy = ConfigHelper.GetNodeDec("doctor");
                    oldMedicineNewModel.LastUpdateDate = DateTime.Now;

                    int medicineID = OldMedicineCnBLL.Add(oldMedicineNewModel, VersionNo);

                    // 中医体质结果
                    oldMedicineNewModel.MedicineID = medicineID;
                    OldMedicineResultBLL.Add(oldMedicineNewModel, VersionNo);

                    // 中医指导建议
                    OldMedGuideModel GuideModeTemp = new OldMedGuideModel();

                    string strTzlx = "";
                    GuideModeTemp.Type = 0;
                    GuideModeTemp.OutKey = Convert.ToInt32(id);
                    GuideModeTemp.Doctor = ConfigHelper.GetNode("doctorName");
                    GuideModeTemp.GuideDate = CheckDate;
                    GuideModeTemp.IDCardNo = IDCardNo;

                    #region 根据体质对应体质类型及见意

                    if (oldMedicineNewModel.Mild == "1" || oldMedicineNewModel.Mild == "2")
                    {
                        strTzlx = "平和质";
                        GuideModeTemp.IdentifyResult = "1";
                    }
                    else if (oldMedicineNewModel.Faint == "1" || oldMedicineNewModel.Faint == "2")
                    {
                        strTzlx = "气虚质";
                        GuideModeTemp.IdentifyResult = "2";
                    }
                    else if (oldMedicineNewModel.Yang == "1" || oldMedicineNewModel.Yang == "2")
                    {
                        strTzlx = "阳虚质";
                        GuideModeTemp.IdentifyResult = "3";
                    }
                    else if (oldMedicineNewModel.Yin == "1" || oldMedicineNewModel.Yin == "2")
                    {
                        strTzlx = "阴虚质";
                        GuideModeTemp.IdentifyResult = "4";
                    }
                    else if (oldMedicineNewModel.PhlegmDamp == "1" || oldMedicineNewModel.PhlegmDamp == "2")
                    {
                        strTzlx = "痰湿质";
                        GuideModeTemp.IdentifyResult = "5";
                    }
                    else if (oldMedicineNewModel.Muggy == "1" || oldMedicineNewModel.Muggy == "2")
                    {
                        strTzlx = "湿热质";
                        GuideModeTemp.IdentifyResult = "6";
                    }
                    else if (oldMedicineNewModel.BloodStasis == "1" || oldMedicineNewModel.BloodStasis == "2")
                    {
                        strTzlx = "血瘀质";
                        GuideModeTemp.IdentifyResult = "7";
                    }
                    else if (oldMedicineNewModel.QiConstraint == "1" || oldMedicineNewModel.QiConstraint == "2")
                    {
                        strTzlx = "气郁质";
                        GuideModeTemp.IdentifyResult = "8";
                    }
                    else if (oldMedicineNewModel.Characteristic == "1" || oldMedicineNewModel.Characteristic == "2")
                    {
                        strTzlx = "特兼质";
                        GuideModeTemp.IdentifyResult = "9";
                    }

                    DataTable dtOldCN = new DataTable();

                    if (File.Exists(Application.StartupPath + "\\OldCN.xml"))
                    {
                        DataSet ds = new DataSet();
                        ds.ReadXml(Application.StartupPath + "\\OldCN.xml");

                        dtOldCN = ds.Tables[0];
                    }

                    if (!string.IsNullOrEmpty(strTzlx) && dtOldCN != null)
                    {
                        foreach (DataRow item in dtOldCN.Rows)
                        {
                            if (item["name"].ToString() == strTzlx)
                            {
                                GuideModeTemp.EmotionAdjust = item["qzts"].ToString().Trim();
                                GuideModeTemp.DietAdjust = item["ysty"].ToString().Trim();
                                GuideModeTemp.LiveAdjust = item["qjts"].ToString().Trim();
                                GuideModeTemp.Sport = item["ydbj"].ToString().Trim();
                                GuideModeTemp.Collateral = item["jlbj"].ToString().Trim();
                                GuideModeTemp.Attention = item["zysx"].ToString().Trim();
                                GuideModeTemp.OtherGuide = item["qtzd"].ToString().Trim();
                                GuideModeTemp.IdentifyDes = item["bsjgms"].ToString().Trim();
                                break;
                            }
                        }

                        // 随访修改中医体质意见
                        if (!OldMedGuideBLL.UpdateByUpload(GuideModeTemp))
                        {
                            // 修改不到则新增
                            OldMedGuideBLL.Add(GuideModeTemp);
                        }
                    }

                    #endregion
                }

                #endregion
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 高血压
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <param name="VersionNo"></param>
        /// <param name="Model"></param>
        public void SaveHypertension(string IDCardNo, DateTime CheckDate, string VersionNo, RecordsBaseInfoModel Model, RecordsCustomerBaseInfoModel CustomerModel)
        {
            try
            {
                DataView dv = dsRequire.DefaultView;

                // 获取最后一次随访数据
                ChronicHypertensionVisitModel hypertensionOldModel = HypertensionVisitBLL.GetMaxModel(IDCardNo, VersionNo);
                if (hypertensionOldModel == null) hypertensionOldModel = new ChronicHypertensionVisitModel();
                ChronicHypertensionVisitModel hypertensionNewModel = new ChronicHypertensionVisitModel();

                // 取得体检一般情况资料
                RecordsGeneralConditionModel conditionModel = new RecordsGeneralConditionBLL().GetModelByOutKey(CustomerModel.ID);

                // 取得体检生活方式资料
                RecordsLifeStyleModel lifeModel = new RecordsLifeStyleBLL().GetModelByOutKey(CustomerModel.ID);
                if (lifeModel == null) lifeModel = new RecordsLifeStyleModel();

                // 取得体检查体资料
                RecordsPhysicalExamModel physicalModel = new RecordsPhysicalExamBLL().GetModelByOutKey(CustomerModel.ID);
                if (physicalModel == null) physicalModel = new RecordsPhysicalExamModel();

                #region 高血压基本信息

                dv.RowFilter = null;
                dv.RowFilter = "TabName='高血压随访' AND Comment='高血压基本信息' AND (IsSetValue='是' OR IsSetValue='预设上次随访') ";
                DataTable dt = dv.ToTable();

                // 是否有基本信息
                int count = HypertensionVisitBLL.GetDataCount(IDCardNo);

                if (count < 1)
                {
                    // 新增高血压基本信息
                    ChronicHypertensionBaseInfoModel baseModel = new ChronicHypertensionBaseInfoModel()
                    {
                        IDCardNo = IDCardNo,
                        RecordID = Model.RecordID,
                        CreatedBy = ConfigHelper.GetNodeDec("doctor"),
                        CreatedDate = DateTime.Now,
                        LastUpdateBy = ConfigHelper.GetNodeDec("doctor"),
                        LastUpdateDate = DateTime.Now
                    };

                    baseModel = EntityAssignment<ChronicHypertensionBaseInfoModel>(baseModel, baseModel, dt);

                    HypertensionVisitBLL.Add(baseModel, VersionNo);
                }

                #endregion

                #region 随访信息

                dv.RowFilter = null;
                dv.RowFilter = "TabName='高血压随访' AND Comment='高血压随访信息' AND (IsSetValue='是' OR IsSetValue='预设上次随访') AND ChinName<>'用药情况' ";
                dt = dv.ToTable();

                hypertensionNewModel = EntityAssignment<ChronicHypertensionVisitModel>(hypertensionOldModel, hypertensionNewModel, dt);

                hypertensionNewModel.IDCardNo = IDCardNo;
                hypertensionNewModel.RecordID = Model.RecordID;
                hypertensionNewModel.CustomerName = StringPlus.toString(hypertensionNewModel.CustomerName) == "" ? Model.CustomerName : hypertensionNewModel.CustomerName;
                hypertensionNewModel.Hypertension = conditionModel.LeftHeight;
                hypertensionNewModel.Hypotension = conditionModel.LeftPre;
                hypertensionNewModel.Weight = conditionModel.Weight;
                hypertensionNewModel.Height = conditionModel.Height;
                hypertensionNewModel.BMI = conditionModel.BMI;
                hypertensionNewModel.HeartRate = physicalModel.HeartRate;
                hypertensionNewModel.DailySmokeNum = lifeModel.SmokeDayNum;
                hypertensionNewModel.DailyDrinkNum = lifeModel.DayDrinkVolume;
                hypertensionNewModel.FollowUpDate = CheckDate;
                hypertensionNewModel.NextFollowUpDate = CheckDate.AddMonths(3);
                hypertensionNewModel.FollowUpDoctor = ConfigHelper.GetNode("doctorName");
                hypertensionNewModel.CreatedBy = ConfigHelper.GetNode("doctor");
                hypertensionNewModel.CreatedDate = DateTime.Now;
                hypertensionNewModel.LastUpdateBy = ConfigHelper.GetNode("doctor");
                hypertensionNewModel.LastUpdateDate = DateTime.Now;

                #endregion

                #region 保存默认值

                if (VersionNo.Contains("3.0"))
                {
                    hypertensionNewModel.FollowUpType = hypertensionNewModel.VisitType;
                    hypertensionNewModel.FollowUpWay = hypertensionNewModel.VisitWay;
                }

                // 随访信息存档
                int id = HypertensionVisitBLL.Add(hypertensionNewModel, VersionNo);

                #endregion

                // 保存用药
                SaveMedication(IDCardNo, "1", id);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 糖尿病
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <param name="VersionNo"></param>
        /// <param name="Model"></param>
        public void SaveDiadetes(string IDCardNo, DateTime CheckDate, string VersionNo, RecordsBaseInfoModel Model, RecordsCustomerBaseInfoModel CustomerModel)
        {
            try
            {
                DataView dv = dsRequire.DefaultView;

                // 获取最后一次随访数据
                ChronicDiadetesVisitModel diadetesOldModel = DiadetesVisitBLL.GetMaxModel(IDCardNo);
                if (diadetesOldModel == null) diadetesOldModel = new ChronicDiadetesVisitModel();
                ChronicDiadetesVisitModel diadetesNewModel = new ChronicDiadetesVisitModel();

                // 取得体检一般情况资料
                RecordsGeneralConditionModel conditionModel = new RecordsGeneralConditionBLL().GetModelByOutKey(CustomerModel.ID);

                // 取得体检生活方式资料
                RecordsLifeStyleModel lifeModel = new RecordsLifeStyleBLL().GetModelByOutKey(CustomerModel.ID);
                if (lifeModel == null) lifeModel = new RecordsLifeStyleModel();

                // 取得体检查体资料
                RecordsPhysicalExamModel physicalModel = new RecordsPhysicalExamBLL().GetModelByOutKey(CustomerModel.ID);
                if (physicalModel == null) physicalModel = new RecordsPhysicalExamModel();

                // 取得体检辅助检查资料
                RecordsAssistCheckModel checkModel = new RecordsAssistCheckBLL().GetModelByOutKey(CustomerModel.ID);

                #region 糖尿病基本信息

                dv.RowFilter = null;
                dv.RowFilter = "TabName='糖尿病随访' AND Comment='糖尿病基本信息' AND (IsSetValue='是' OR IsSetValue='预设上次随访') ";
                DataTable dt = dv.ToTable();

                // 是否有基本信息
                int count = DiadetesVisitBLL.GetBaseDataCount(IDCardNo);

                if (count < 1)
                {
                    // 新增糖尿病基本信息
                    ChronicDiabetesBaseInfoModel baseModel = new ChronicDiabetesBaseInfoModel()
                    {
                        IDCardNo = IDCardNo,
                        RecordID = Model.RecordID,
                        CreateBy = ConfigHelper.GetNodeDec("doctor"),
                        CreateDate = DateTime.Now,
                        LastUpdateBy = ConfigHelper.GetNodeDec("doctor"),
                        LastUpdateDate = DateTime.Now
                    };

                    baseModel = EntityAssignment<ChronicDiabetesBaseInfoModel>(baseModel, baseModel, dt);

                    DiadetesVisitBLL.Add(baseModel, VersionNo);
                }

                #endregion

                #region 随访信息

                dv.RowFilter = null;
                dv.RowFilter = "TabName='糖尿病随访' AND Comment='糖尿病随访信息' AND (IsSetValue='是' OR IsSetValue='预设上次随访') AND ChinName<>'用药情况'  ";
                dt = dv.ToTable();

                diadetesNewModel = EntityAssignment<ChronicDiadetesVisitModel>(diadetesOldModel, diadetesNewModel, dt);

                diadetesNewModel.IDCardNo = IDCardNo;
                diadetesNewModel.RecordID = Model.RecordID;
                diadetesNewModel.CustomerName = StringPlus.toString(diadetesNewModel.CustomerName) == "" ? Model.CustomerName : diadetesNewModel.CustomerName;
                diadetesNewModel.Hypertension = conditionModel.LeftHeight;
                diadetesNewModel.Hypotension = conditionModel.LeftPre;
                diadetesNewModel.Weight = conditionModel.Weight;
                diadetesNewModel.Height = conditionModel.Height;
                diadetesNewModel.BMI = conditionModel.BMI;
                diadetesNewModel.DorsalisPedispulse = StringPlus.toString(physicalModel.FootBack) != "" ? (int.Parse(physicalModel.FootBack) - 1).ToString() : null;
                diadetesNewModel.DailySmokeNum = lifeModel.SmokeDayNum;
                diadetesNewModel.DailyDrinkNum = lifeModel.DayDrinkVolume;
                diadetesNewModel.FPG = checkModel.FPGL;
                diadetesNewModel.HbAlc = checkModel.HBALC;
                diadetesNewModel.VisitDate = CheckDate;
                diadetesNewModel.NextVisitDate = CheckDate.AddMonths(3);
                diadetesNewModel.VisitDoctor = ConfigHelper.GetNode("doctorName");
                diadetesNewModel.CreateBy = ConfigHelper.GetNode("doctor");
                diadetesNewModel.CreateDate = DateTime.Now;
                diadetesNewModel.LastUpdateBy = ConfigHelper.GetNode("doctor");
                diadetesNewModel.LastUpdateDate = DateTime.Now;

                #endregion

                #region 保存默认值

                // 随访信息存档
                int id = DiadetesVisitBLL.Add(diadetesNewModel, VersionNo);

                #endregion

                // 保存用药
                SaveMedication(IDCardNo, "2", id);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 精神疾病
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <param name="VersionNo"></param>
        /// <param name="Model"></param>
        public void SaveMental(string IDCardNo, DateTime CheckDate, string VersionNo, RecordsBaseInfoModel Model)
        {
            try
            {
                // 获取最后一次随访数据
                ChronicMentalDiseaseVisitModel mentalOldModel = MentalDiseaseVisitBLL.GetMaxModel(IDCardNo, VersionNo);
                if (mentalOldModel == null) mentalOldModel = new ChronicMentalDiseaseVisitModel();
                ChronicMentalDiseaseVisitModel mentalNewModel = new ChronicMentalDiseaseVisitModel();

                #region 精神疾病基本信息

                // 是否有基本信息
                int count = MentalDiseaseBaseBLL.GetDataCount(IDCardNo);

                if (count < 1)
                {
                    // 新增精神疾病基本信息
                    ChronicMentalDiseaseBaseInfoModel baseModel = new ChronicMentalDiseaseBaseInfoModel()
                    {
                        IDCardNo = IDCardNo,
                        RecordID = Model.RecordID,
                        CreatedBy = ConfigHelper.GetNodeDec("doctor"),
                        CreatedDate = DateTime.Now,
                        LastUpdateBy = ConfigHelper.GetNodeDec("doctor"),
                        LastUpDateDate = DateTime.Now
                    };

                    MentalDiseaseBaseBLL.Add(baseModel);
                }

                #endregion

                #region 随访信息

                mentalNewModel = EntityAssignment<ChronicMentalDiseaseVisitModel>(mentalOldModel, mentalNewModel);

                mentalNewModel.IDCardNo = IDCardNo;
                mentalNewModel.RecordID = Model.RecordID;
                mentalNewModel.FollowUpDate = CheckDate;
                mentalNewModel.NextFollowUpDate = CheckDate.AddMonths(3);
                mentalNewModel.FollowUpDoctor = ConfigHelper.GetNode("doctorName");
                mentalNewModel.CreatedBy = ConfigHelper.GetNodeDec("doctor");
                mentalNewModel.CreatedDate = DateTime.Now;
                mentalNewModel.LastUpdateBy = ConfigHelper.GetNodeDec("doctor");
                mentalNewModel.LastUpdateDate = DateTime.Now;

                #endregion

                #region 保存默认值

                if (VersionNo.Contains("3.0")) mentalNewModel.FollowUpType = mentalNewModel.VisitType;

                // 随访信息存档
                int id = MentalDiseaseVisitBLL.Add(mentalNewModel, VersionNo);

                #endregion
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 冠心病
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <param name="VersionNo"></param>
        /// <param name="Model"></param>
        public void SaveChd(string IDCardNo, DateTime CheckDate, string VersionNo, RecordsBaseInfoModel Model)
        {
            try
            {
                // 获取最后一次随访数据
                ChronicChdVisitModel chdOldModel = ChdVisitBLL.GetMaxModel(IDCardNo);
                if (chdOldModel == null) chdOldModel = new ChronicChdVisitModel();
                ChronicChdVisitModel chdNewModel = new ChronicChdVisitModel();

                #region 冠心病基本信息

                // 是否有基本信息
                int count = ChdVisitBLL.GetBaseDataCount(IDCardNo);

                if (count < 1)
                {
                    // 新增冠心病基本信息
                    ChronicChdBaseInfoModel baseModel = new ChronicChdBaseInfoModel()
                    {
                        IDCardNo = IDCardNo,
                        RecordID = Model.RecordID,
                        CreateBy = ConfigHelper.GetNodeDec("doctor"),
                        CreateDate = DateTime.Now,
                        LastUpdateBy = ConfigHelper.GetNodeDec("doctor"),
                        LastUpdateDate = DateTime.Now
                    };

                    ChdVisitBLL.Add(baseModel, VersionNo);
                }

                #endregion

                #region 随访信息

                chdNewModel = EntityAssignment<ChronicChdVisitModel>(chdOldModel, chdNewModel);

                chdNewModel.IDCardNo = IDCardNo;
                chdNewModel.RecordID = Model.RecordID;
                chdNewModel.VisitDate = CheckDate;
                chdNewModel.NextVisitDate = CheckDate.AddMonths(3);
                chdNewModel.VisitDoctor = ConfigHelper.GetNode("doctorName");
                chdNewModel.CreateBy = ConfigHelper.GetNodeDec("doctor");
                chdNewModel.CreateDate = DateTime.Now;
                chdNewModel.LastUpDateBy = ConfigHelper.GetNodeDec("doctor");
                chdNewModel.LastUpDateDate = DateTime.Now;

                #endregion

                #region 保存默认值

                // 随访信息存档
                int id = ChdVisitBLL.Add(chdNewModel, VersionNo);

                #endregion
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 脑卒中
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <param name="VersionNo"></param>
        /// <param name="Model"></param>
        public void SaveStroke(string IDCardNo, DateTime CheckDate, string VersionNo, RecordsBaseInfoModel Model)
        {
            try
            {
                // 获取最后一次随访数据
                ChronicStrokeVisitModel strokeOldModel = StrokeVisitBLL.GetMaxModel(IDCardNo, VersionNo);
                if (strokeOldModel == null) strokeOldModel = new ChronicStrokeVisitModel();
                ChronicStrokeVisitModel strokeNewModel = new ChronicStrokeVisitModel();

                #region 脑卒中基本信息

                // 是否有基本信息
                int count = StrokeVisitBLL.GetDataCount(IDCardNo);

                if (count < 1)
                {
                    // 新增脑卒中基本信息
                    ChronicStrokeBaseInfoModel baseModel = new ChronicStrokeBaseInfoModel()
                    {
                        IDCardNo = IDCardNo,
                        RecordID = Model.RecordID,
                        CreatedBy = ConfigHelper.GetNodeDec("doctor"),
                        CreatedDate = DateTime.Now,
                        LastUpdateBy = ConfigHelper.GetNodeDec("doctor"),
                        LastUpdateDate = DateTime.Now
                    };

                    StrokeVisitBLL.Add(baseModel);
                }

                #endregion

                #region 随访信息

                strokeNewModel = EntityAssignment<ChronicStrokeVisitModel>(strokeOldModel, strokeNewModel);

                strokeNewModel.IDCardNo = IDCardNo;
                strokeNewModel.RecordID = Model.RecordID;
                strokeNewModel.FollowupDate = CheckDate;
                strokeNewModel.NextFollowupDate = CheckDate.AddMonths(3);
                strokeNewModel.FollowUpDoctor = ConfigHelper.GetNode("doctorName");
                strokeNewModel.CreatedBy = ConfigHelper.GetNodeDec("doctor");
                strokeNewModel.CreatedDate = DateTime.Now;
                strokeNewModel.LastUpdateBy = ConfigHelper.GetNodeDec("doctor");
                strokeNewModel.LastUpdateDate = DateTime.Now;

                #endregion

                #region 保存默认值

                if (VersionNo.Contains("3.0"))
                {
                    strokeNewModel.FollowupType = strokeNewModel.VisitType;
                    strokeNewModel.FollowupWay = strokeNewModel.VisitWay;
                }

                // 随访信息存档
                int id = StrokeVisitBLL.Add(strokeNewModel, VersionNo);

                #endregion
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 肺结核
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <param name="VersionNo"></param>
        /// <param name="Model"></param>
        public void SaveLunger(string IDCardNo, DateTime CheckDate, string VersionNo, RecordsBaseInfoModel Model)
        {
            try
            {
                // 取得第一次随访信息
                ChronicLungerFirstVisitModel lungerFirstOldModel = LungerVisitBLL.GetFirstMaxModel(IDCardNo, VersionNo);
                int outKey = 0;

                if (lungerFirstOldModel == null)
                {
                    // 新增第一次入户随访
                    ChronicLungerFirstVisitModel baseModel = new ChronicLungerFirstVisitModel()
                    {
                        IDCardNo = IDCardNo,
                        RecordID = Model.RecordID,
                        CustomerName = Model.CustomerName,
                        FollowupDate = CheckDate,
                        VisitDoctor = ConfigHelper.GetNode("doctorName"),
                        EstimateDoctor = ConfigHelper.GetNode("doctorName"),
                        NextVisitDate = CheckDate.AddMonths(3),
                        CreatedBy = ConfigHelper.GetNode("doctor"),
                        CreatedDate = DateTime.Now,
                        LastUpdateBy = ConfigHelper.GetNode("doctor"),
                        LastUpdateDate = DateTime.Now,
                    };

                    LungerVisitBLL.Add(baseModel, VersionNo);
                }
                else
                {
                    #region 随访信息

                    // 获取最后一次随访数据
                    ChronicLungerVisitModel lungerVisitOldModel = LungerVisitBLL.GetMaxModel(IDCardNo, VersionNo);

                    ChronicLungerVisitModel lungerVisitNewModel = new ChronicLungerVisitModel();

                    if (lungerVisitOldModel == null)
                    {
                        outKey = lungerFirstOldModel.ID;

                        lungerVisitOldModel = new ChronicLungerVisitModel();
                    }

                    // 肺结核随访信息预设上次随访内容
                    lungerVisitNewModel = EntityAssignment<ChronicLungerVisitModel>(lungerVisitOldModel, lungerVisitNewModel);

                    lungerVisitNewModel.IDCardNo = IDCardNo;
                    lungerVisitNewModel.RecordID = Model.RecordID;
                    lungerVisitNewModel.CustomerName = StringPlus.toString(lungerVisitNewModel.CustomerName) == "" ? Model.CustomerName : lungerVisitNewModel.CustomerName;
                    lungerVisitNewModel.OutKey = lungerVisitNewModel.OutKey > 0 ? lungerVisitNewModel.OutKey : outKey;
                    lungerVisitNewModel.FollowupDate = CheckDate;
                    lungerVisitNewModel.VisitDoctor = ConfigHelper.GetNode("doctorName");
                    lungerVisitNewModel.EstimateDoctor = ConfigHelper.GetNode("doctorName");
                    lungerVisitNewModel.NextVisitDate = CheckDate.AddMonths(3);
                    lungerVisitNewModel.CreatedBy = ConfigHelper.GetNode("doctor");
                    lungerVisitNewModel.CreatedDate = DateTime.Now;
                    lungerVisitNewModel.LastUpdateBy = ConfigHelper.GetNode("doctor");
                    lungerVisitNewModel.LastUpdateDate = DateTime.Now;

                    if (VersionNo.Contains("3.0")) lungerVisitNewModel.FollowupWay = lungerVisitNewModel.VisitWay;

                    LungerVisitBLL.Add(lungerVisitNewModel, VersionNo);

                    #endregion
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 存储用药
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="type">1.高血压  2.糖尿病</param>
        /// <param name="outKeyN">新增随访Key</param>
        public void SaveMedication(string IDCardNo, string type, int outKeyN)
        {
            // 预设体检用药
            List<RecordsMedicationModel> medicationModel = new RecordsMedicationBLL().GetModelList(string.Format("IDCardNo='{0}' ", IDCardNo));

            if (medicationModel == null) medicationModel = new List<RecordsMedicationModel>();

            // 用于存储需存档的体检数据
            List<ChronicDrugConditionModel> conditionModel = new List<ChronicDrugConditionModel>();

            for (int i = 0; i < medicationModel.Count; i++)
            {
                if (type == "2" && i > 2) break;
                else if (type == "1" && i > 3) break;

                ChronicDrugConditionModel drugConditionModel = new ChronicDrugConditionModel();

                drugConditionModel.IDCardNo = medicationModel[i].IDCardNo;
                drugConditionModel.Type = type;
                drugConditionModel.OutKey = outKeyN;
                drugConditionModel.Name = medicationModel[i].MedicinalName;

                if (medicationModel[i].Frequency == "2" || medicationModel[i].Frequency == "每日一次")    // 每日一次
                {
                    drugConditionModel.DailyTime = "1";
                }
                else if (medicationModel[i].Frequency == "3" || medicationModel[i].Frequency == "每日两次")  // 每日两次
                {
                    drugConditionModel.DailyTime = "2";
                }
                else if (medicationModel[i].Frequency == "4" || medicationModel[i].Frequency == "每日三次")    // 每日三次
                {
                    drugConditionModel.DailyTime = "3";
                }
                else if (medicationModel[i].Frequency == "5" || medicationModel[i].Frequency == "每日四次")    // 每日四次
                {
                    drugConditionModel.DailyTime = "4";
                }

                drugConditionModel.DrugType = medicationModel[i].DrugType;
                drugConditionModel.EveryTimeMg = medicationModel[i].UseNum;

                if (medicationModel[i].UseDay == "2") // 克
                {
                    drugConditionModel.EveryTimeMg += "克";
                }
                else if (medicationModel[i].UseDay == "3") // 毫克
                {
                    drugConditionModel.EveryTimeMg += "毫克";
                }
                else if (medicationModel[i].UseDay == "4") // 毫升
                {
                    drugConditionModel.EveryTimeMg += "毫升";
                }
                else if (medicationModel[i].UseDay == "5") // 国际单位
                {
                    drugConditionModel.EveryTimeMg += "国际单位";
                }
                else if (medicationModel[i].UseDay == "6") // 片
                {
                    drugConditionModel.EveryTimeMg += "片";
                }
                else if (medicationModel[i].UseDay == "7") // 粒
                {
                    drugConditionModel.EveryTimeMg += "粒";
                }
                else if (medicationModel[i].UseDay == "8") // 滴
                {
                    drugConditionModel.EveryTimeMg += "滴";
                }
                else if (medicationModel[i].UseDay == "9") // 包
                {
                    drugConditionModel.EveryTimeMg += "包";
                }
                else if (medicationModel[i].UseDay == "10") // 支
                {
                    drugConditionModel.EveryTimeMg += "支";
                }

                DrugConditionGuideBLL.Add(drugConditionModel);
            }
        }

        /// <summary>
        /// 根据默认项设置映射Mode实体取对应的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldModel"></param>
        /// <param name="newModel"></param>
        /// <param name="dtRequire"></param>
        /// <returns></returns>
        private T EntityAssignment<T>(T oldModel, T newModel, DataTable dtRequire)
        {
            try
            {
                Type typeOld = oldModel.GetType();
                Type typeNew = newModel.GetType();

                foreach (DataRow item in dtRequire.Rows)
                {
                    PropertyInfo piOld = typeOld.GetProperty(item["OptionName"].ToString());
                    PropertyInfo piNew = typeNew.GetProperty(item["OptionName"].ToString());
                    string value = "";

                    if (item["IsSetValue"].ToString() == "是") value = item["ItemValue"].ToString();
                    else value = StringPlus.toString(piOld.GetValue(oldModel, null));

                    if (piOld != null && value != "")
                    {
                        if (piOld.PropertyType == typeof(string))
                        {
                            piNew.SetValue(newModel, value.ToString(), null);
                        }
                        else if (piOld.PropertyType == typeof(int) || piOld.PropertyType == typeof(int?))
                        {
                            piNew.SetValue(newModel, int.Parse(value.ToString()), null);
                        }
                        else if (piOld.PropertyType == typeof(DateTime?) || piOld.PropertyType == typeof(DateTime))
                        {
                            piNew.SetValue(newModel, DateTime.Parse(value.ToString()), null);
                        }
                        else if (piOld.PropertyType == typeof(float?) || piOld.PropertyType == typeof(float))
                        {
                            piNew.SetValue(newModel, float.Parse(value.ToString()), null);
                        }
                        else if (piOld.PropertyType == typeof(double?) || piOld.PropertyType == typeof(double))
                        {
                            piNew.SetValue(newModel, double.Parse(value.ToString()), null);
                        }
                        else if (piOld.PropertyType == typeof(decimal?) || piOld.PropertyType == typeof(decimal))
                        {
                            piNew.SetValue(newModel, decimal.Parse(value.ToString()), null);
                        }
                        else
                        {
                            piNew.SetValue(newModel, value, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
                throw ex;
            }

            return newModel;
        }

        /// <summary>
        /// 根据默认项设置映射Mode实体取对应的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldModel"></param>
        /// <param name="newModel"></param>
        /// <returns></returns>
        private T EntityAssignment<T>(T oldModel, T newModel)
        {
            try
            {
                Type typeOld = oldModel.GetType();
                Type typeNew = newModel.GetType();
                PropertyInfo[] myPropertyInfo = typeOld.GetProperties();

                for (int i = 0; i < myPropertyInfo.Length; i++)
                {
                    PropertyInfo piOld = myPropertyInfo[i];
                    PropertyInfo piNew = typeNew.GetProperties()[i];
                    string value = StringPlus.toString(piOld.GetValue(oldModel, null));

                    if (piOld != null && value != "")
                    {
                        if (piOld.PropertyType == typeof(string))
                        {
                            piNew.SetValue(newModel, value.ToString(), null);
                        }
                        else if (piOld.PropertyType == typeof(int) || piOld.PropertyType == typeof(int?))
                        {
                            piNew.SetValue(newModel, int.Parse(value.ToString()), null);
                        }
                        else if (piOld.PropertyType == typeof(DateTime?) || piOld.PropertyType == typeof(DateTime))
                        {
                            piNew.SetValue(newModel, DateTime.Parse(value.ToString()), null);
                        }
                        else if (piOld.PropertyType == typeof(float?) || piOld.PropertyType == typeof(float))
                        {
                            piNew.SetValue(newModel, float.Parse(value.ToString()), null);
                        }
                        else if (piOld.PropertyType == typeof(double?) || piOld.PropertyType == typeof(double))
                        {
                            piNew.SetValue(newModel, double.Parse(value.ToString()), null);
                        }
                        else if (piOld.PropertyType == typeof(decimal?) || piOld.PropertyType == typeof(decimal))
                        {
                            piNew.SetValue(newModel, decimal.Parse(value.ToString()), null);
                        }
                        else
                        {
                            piNew.SetValue(newModel, value, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
                throw ex;
            }

            return newModel;
        }
    }
}
