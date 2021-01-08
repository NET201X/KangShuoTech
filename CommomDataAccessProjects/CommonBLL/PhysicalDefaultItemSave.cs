using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    /// <summary>
    /// 体检根据默认项自动新增
    /// </summary>
    public class PhysicalDefaultItemSave
    {
        RecordsCustomerBaseInfoBLL CustomerBaseInfoBLL = new RecordsCustomerBaseInfoBLL();
        RecordsLifeStyleBLL LifeStyleBLL = new RecordsLifeStyleBLL();
        RecordsGeneralConditionBLL GeneralConditionBLL = new RecordsGeneralConditionBLL();
        RecordsPhysicalExamBLL PhysicalExamBLL = new RecordsPhysicalExamBLL();
        RecordsAssistCheckBLL AssistCheckBLL = new RecordsAssistCheckBLL();
        RecordsVisceraFunctionBLL VisceraFunctionBLL = new RecordsVisceraFunctionBLL();
        RecordsMediPhysDistBLL MediPhysDistBLL = new RecordsMediPhysDistBLL();
        RecordsHealthQuestionBLL HealthQuestionBLL = new RecordsHealthQuestionBLL();
        RecordsAssessmentGuideBLL AssessmentGuideBLL = new RecordsAssessmentGuideBLL();
        RecordsHospitalHistoryBLL HospitalHistoryBLL = new RecordsHospitalHistoryBLL();
        RecordsFamilyBedHistoryBLL FamilyBedHistoryBLL = new RecordsFamilyBedHistoryBLL();
        RecordsMedicationBLL MedicationBLL = new RecordsMedicationBLL();
        RecordsInoculationHistoryBLL InoculationHistoryBLL = new RecordsInoculationHistoryBLL();

        public void SavePhysical(string IDCardNo, DateTime CheckDate, string VersionNo, string barCode = "")
        {
            try
            {
                DataTable dsRequire = new RequireBLL().GetList("TabName = '健康体检' ").Tables[0];
                DataView dv = dsRequire.DefaultView;

                // 获取最后一次体检数据
                RecordsCustomerBaseInfoModel customerOldModel = CustomerBaseInfoBLL.GetMaxModel(IDCardNo);
                if (customerOldModel == null) customerOldModel = new RecordsCustomerBaseInfoModel();
                RecordsCustomerBaseInfoModel customerNewModel = new RecordsCustomerBaseInfoModel();

                customerNewModel.IDCardNo = IDCardNo;
                customerNewModel.CheckDate = CheckDate;
                customerNewModel.CustomerID = barCode;
                customerNewModel.Doctor = ConfigHelper.GetNode("doctorName");
                customerNewModel.CreateBy = ConfigHelper.GetNodeDec("doctor");
                customerNewModel.CreateDate = DateTime.Now;
                customerNewModel.LastUpdateBy = ConfigHelper.GetNodeDec("doctor");
                customerNewModel.LastUpdateDate = DateTime.Now;

                #region 一般状况

                dv.RowFilter = "Comment='一般状况' AND (IsSetValue='是' OR IsSetValue='预设上次体检') AND OptionName='Symptom' ";
                DataTable dt = dv.ToTable();

                // 栏位名遍历默认项配置
                foreach (DataRow item in dt.Rows)
                {
                    if (item["IsSetValue"].ToString() == "是")
                    {
                        customerNewModel.Symptom = item["ItemValue"].ToString();
                    }
                    else
                    {
                        customerNewModel.Symptom = customerOldModel.Symptom;
                        customerNewModel.Other = customerOldModel.Other;
                    }
                }

                dv.RowFilter = null;
                dv.RowFilter = "Comment='一般状况' AND (IsSetValue='是' OR IsSetValue='预设上次体检') AND OptionName<>'Symptom' ";
                dt = dv.ToTable();
                RecordsGeneralConditionModel gerneralOldModel = GeneralConditionBLL.GetModelByOutKey(customerOldModel.ID);
                RecordsGeneralConditionModel gerneralNewModel = new RecordsGeneralConditionModel();

                gerneralNewModel = EntityAssignment<RecordsGeneralConditionModel>(gerneralOldModel, gerneralNewModel, dt);

                #endregion

                #region 生活方式

                dv.RowFilter = null;
                dv.RowFilter = "Comment='生活方式' AND (IsSetValue='是' OR IsSetValue='预设上次体检') ";
                dt = dv.ToTable();
                RecordsLifeStyleModel lifeStyleOldModel = LifeStyleBLL.GetModelByOutKey(customerOldModel.ID);
                RecordsLifeStyleModel lifeStyleNewModel = new RecordsLifeStyleModel();
                if (lifeStyleOldModel == null) lifeStyleOldModel = new RecordsLifeStyleModel();

                lifeStyleNewModel = EntityAssignment<RecordsLifeStyleModel>(lifeStyleOldModel, lifeStyleNewModel, dt);

                #endregion

                #region 查体信息

                dv.RowFilter = null;
                dv.RowFilter = "Comment='查体信息' AND (IsSetValue='是' OR IsSetValue='预设上次体检') ";
                dt = dv.ToTable();
                RecordsPhysicalExamModel physicalExamOldModel = PhysicalExamBLL.GetModelByOutKey(customerOldModel.ID);
                RecordsPhysicalExamModel physicalExamNewModel = new RecordsPhysicalExamModel();
                if (physicalExamOldModel == null) physicalExamOldModel = new RecordsPhysicalExamModel();

                physicalExamNewModel = EntityAssignment<RecordsPhysicalExamModel>(physicalExamOldModel, physicalExamNewModel, dt);

                #endregion

                #region 辅助检查

                dv.RowFilter = null;
                dv.RowFilter = "Comment='辅助检查' AND (IsSetValue='是' OR IsSetValue='预设上次体检') ";
                dt = dv.ToTable();
                RecordsAssistCheckModel assistCheckOldModel = AssistCheckBLL.GetModelByOutKey(customerOldModel.ID);
                RecordsAssistCheckModel assistCheckNewModel = new RecordsAssistCheckModel();
                if (assistCheckOldModel == null) assistCheckOldModel = new RecordsAssistCheckModel();

                assistCheckNewModel = EntityAssignment<RecordsAssistCheckModel>(assistCheckOldModel, assistCheckNewModel, dt);

                #endregion

                #region 脏器功能

                dv.RowFilter = null;
                dv.RowFilter = "Comment='脏器功能' AND (IsSetValue='是' OR IsSetValue='预设上次体检') ";
                dt = dv.ToTable();
                RecordsVisceraFunctionModel visceraOldModel = VisceraFunctionBLL.GetModelByOutKey(customerOldModel.ID);
                RecordsVisceraFunctionModel visceraNewModel = new RecordsVisceraFunctionModel();
                if (visceraOldModel == null) visceraOldModel = new RecordsVisceraFunctionModel();

                visceraNewModel = EntityAssignment<RecordsVisceraFunctionModel>(visceraOldModel, visceraNewModel, dt);

                #endregion

                #region 中医体质

                RecordsMediPhysDistModel mediPhysDistModel = new RecordsMediPhysDistModel();

                #endregion

                #region 健康评价

                RecordsAssessmentGuideModel assessmentGuideModel = new RecordsAssessmentGuideModel();

                #endregion

                #region 健康问题

                dv.RowFilter = null;
                dv.RowFilter = "Comment='健康问题' AND (IsSetValue='是' OR IsSetValue='预设上次体检') ";
                dt = dv.ToTable();
                RecordsHealthQuestionModel questionOldModel = HealthQuestionBLL.GetModelByOutKey(customerOldModel.ID);
                RecordsHealthQuestionModel questionNewModel = new RecordsHealthQuestionModel();
                if (questionOldModel == null) questionOldModel = new RecordsHealthQuestionModel();

                questionNewModel = EntityAssignment<RecordsHealthQuestionModel>(questionOldModel, questionNewModel, dt);

                #endregion

                #region 住院史、用药情况

                dv.RowFilter = null;
                dv.RowFilter = "Comment='治疗情况' AND (IsSetValue='是' OR IsSetValue='预设上次体检' OR IsSetValue='预设随访用药') ";
                dt = dv.ToTable();

                // 获取list model对象，用来获取最后一次体检数据的值
                List<RecordsHospitalHistoryModel> hospitalHistoryOld = HospitalHistoryBLL.GetModelList(
                    string.Format("IDCardNo='{0}' AND OutKey={1}", IDCardNo, customerOldModel.ID));
                List<RecordsFamilyBedHistoryModel> familyBedHistoryInfoOld = FamilyBedHistoryBLL.GetModelList(
                    string.Format("IDCardNo='{0}' AND OutKey={1}", IDCardNo, customerOldModel.ID));
                List<RecordsMedicationModel> medicationOld = MedicationBLL.GetModelList(
                    string.Format("IDCardNo='{0}' AND OutKey={1}", IDCardNo, customerOldModel.ID));

                if (hospitalHistoryOld == null) hospitalHistoryOld = new List<RecordsHospitalHistoryModel>();
                if (familyBedHistoryInfoOld == null) familyBedHistoryInfoOld = new List<RecordsFamilyBedHistoryModel>();
                if (medicationOld == null) medicationOld = new List<RecordsMedicationModel>();

                #region 随访用药

                List<RecordsMedicationModel> medicationFollowUp = new List<RecordsMedicationModel>();

                // 高血压随访
                ChronicHypertensionVisitModel HyperModel = new ChronicHypertensionVisitBLL().GetMaxModel(IDCardNo, VersionNo);

                if (HyperModel != null)
                {
                    List<ChronicDrugConditionModel> DrugConditions = new ChronicDrugConditionBLL().GetModelList(
                        string.Format(" IDCardNo='{0}' AND Type='{1}' AND OutKey='{2}' ", IDCardNo, "1", HyperModel.ID));

                    foreach (ChronicDrugConditionModel drugModel in DrugConditions)
                    {
                        RecordsMedicationModel newModel = new RecordsMedicationModel
                        {
                            MedicinalName = drugModel.Name,
                            UseNum = drugModel.DosAge,
                            IDCardNo = IDCardNo
                        };

                        medicationFollowUp.Add(newModel);
                    }
                }

                // 糖尿病随访
                ChronicDiadetesVisitModel DiaModel = new ChronicDiadetesVisitBLL().GetMaxModel(IDCardNo);

                if (DiaModel != null)
                {
                    List<ChronicDrugConditionModel> DiaDrugConditions = new ChronicDrugConditionBLL().GetModelList(
                        string.Format(" IDCardNo='{0}' AND Type='{1}' AND OutKey='{2}' ", IDCardNo, "2", DiaModel.ID));

                    foreach (ChronicDrugConditionModel drugModel in DiaDrugConditions)
                    {
                        RecordsMedicationModel newModel = new RecordsMedicationModel
                        {
                            MedicinalName = drugModel.Name,
                            UseNum = drugModel.DosAge,
                            IDCardNo = IDCardNo
                        };

                        medicationFollowUp.Add(newModel);
                    }
                }

                #endregion

                // 用于存储需存档的体检数据
                List<RecordsHospitalHistoryModel> hospitalHistoryNew = new List<RecordsHospitalHistoryModel>();
                List<RecordsFamilyBedHistoryModel> familyBedHistoryInfoNew = new List<RecordsFamilyBedHistoryModel>();
                List<RecordsMedicationModel> medicationNew = new List<RecordsMedicationModel>();

                // 临时存储住院史的默认值
                RecordsHospitalHistoryModel hModel = new RecordsHospitalHistoryModel();

                //通过栏位名，遍历默认项配置
                foreach (DataRow item in dt.Rows)
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "住院史":
                            if (item["IsSetValue"].ToString() == "是")
                            {
                                if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                                {
                                    string[] resList = item["ItemValue"].ToString().Split(';');

                                    if (resList.Length > 4)
                                    {
                                        hModel.InHospitalDate = Convert.ToDateTime(resList[0].ToString());
                                        hModel.OutHospitalDate = Convert.ToDateTime(resList[1].ToString());
                                        hModel.Reason = resList[2].ToString();
                                        hModel.HospitalName = resList[3].ToString();
                                        hModel.IllcaseNum = resList[4].ToString();
                                    }
                                    else if (resList.Length == 1) hModel.Reason = resList[0].ToString();

                                    hospitalHistoryNew.Add(hModel);
                                }
                            }
                            else hospitalHistoryNew = hospitalHistoryOld;
                            break;
                        case "家庭病床史":
                            if (item["IsSetValue"].ToString() == "预设上次体检") familyBedHistoryInfoNew = familyBedHistoryInfoOld;
                            break;
                        case "用药情况":
                            if (item["IsSetValue"].ToString() == "预设上次体检") medicationNew = medicationOld;
                            else if (item["IsSetValue"].ToString() == "预设随访用药") medicationNew = medicationFollowUp;
                            break;
                        default:
                            break;
                    }
                }

                #endregion

                #region 预防接种史

                dv.RowFilter = null;
                dv.RowFilter = "Comment='健康评价' AND (IsSetValue='是' OR IsSetValue='预设上次体检') ";
                dt = dv.ToTable();
                List<RecordsInoculationHistoryModel> inoculationHistoryOld = InoculationHistoryBLL.GetModelList(
                    string.Format("IDCardNo='{0}' AND OutKey={1}", IDCardNo, customerOldModel.ID));
                if (inoculationHistoryOld == null) inoculationHistoryOld = new List<RecordsInoculationHistoryModel>();

                List<RecordsInoculationHistoryModel> inoculationHistoryNew = new List<RecordsInoculationHistoryModel>();

                foreach (DataRow item in dt.Rows)
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "非免疫预防接种史":
                            if (item["IsSetValue"].ToString() == "预设上次体检") inoculationHistoryNew = inoculationHistoryOld;
                            break;
                    }
                }

                #endregion

                #region 保存默认值

                // 体检主档保存
                int id = CustomerBaseInfoBLL.Add(customerNewModel);

                if (id > 0)
                {
                    // 一般状况
                    gerneralNewModel.IDCardNo = IDCardNo;
                    gerneralNewModel.OutKey = id;
                    GeneralConditionBLL.Add(gerneralNewModel, VersionNo);

                    // 生活方式
                    lifeStyleNewModel.IDCardNo = IDCardNo;
                    lifeStyleNewModel.OutKey = id;
                    LifeStyleBLL.Add(lifeStyleNewModel);

                    // 查体信息
                    physicalExamNewModel.IDCardNo = IDCardNo;
                    physicalExamNewModel.OutKey = id;
                    PhysicalExamBLL.Add(physicalExamNewModel);

                    // 辅助检查
                    assistCheckNewModel.IDCardNo = IDCardNo;
                    assistCheckNewModel.OutKey = id;
                    AssistCheckBLL.Add(assistCheckNewModel);

                    // 脏器功能
                    visceraNewModel.IDCardNo = IDCardNo;
                    visceraNewModel.OutKey = id;
                    VisceraFunctionBLL.Add(visceraNewModel);

                    // 中医体质
                    mediPhysDistModel.IDCardNo = IDCardNo;
                    mediPhysDistModel.OutKey = id;
                    MediPhysDistBLL.Add(mediPhysDistModel);

                    // 健康问题
                    questionNewModel.IDCardNo = IDCardNo;
                    questionNewModel.OutKey = id;
                    HealthQuestionBLL.Add(questionNewModel);

                    // 健康评价
                    assessmentGuideModel.IDCardNo = IDCardNo;
                    assessmentGuideModel.OutKey = id;
                    AssessmentGuideBLL.Add(assessmentGuideModel);

                    // 住院史
                    if (hospitalHistoryNew.Count > 0)
                    {
                        foreach (RecordsHospitalHistoryModel recordsInoculationHistoryModel in hospitalHistoryNew)
                        {
                            recordsInoculationHistoryModel.OutKey = id;
                            recordsInoculationHistoryModel.IDCardNo = IDCardNo;
                        }

                        HospitalHistoryBLL.AddList(hospitalHistoryNew);
                    }

                    // 家庭住院史
                    if (familyBedHistoryInfoNew.Count > 0)
                    {
                        foreach (RecordsFamilyBedHistoryModel model in familyBedHistoryInfoNew)
                        {
                            model.OutKey = id;
                            model.IDCardNo = IDCardNo;
                        }

                        FamilyBedHistoryBLL.AddList(familyBedHistoryInfoNew);
                    }

                    // 用药
                    if (medicationNew.Count > 0)
                    {
                        foreach (RecordsMedicationModel model in medicationNew)
                        {
                            model.OutKey = id;
                            model.IDCardNo = IDCardNo;
                        }

                        MedicationBLL.AddList(medicationNew);
                    }

                    // 接种史
                    if (inoculationHistoryNew.Count > 0)
                    {
                        foreach (RecordsInoculationHistoryModel model in inoculationHistoryNew)
                        {
                            model.OutKey = id;
                            model.IDCardNo = IDCardNo;
                        }

                        InoculationHistoryBLL.AddList(inoculationHistoryNew);
                    }
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
    }
}
