using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using ReportPrint;
using System.Configuration;

namespace printClass
{
    public class Diabetes_Followup : IGetReport
    {
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/DiaVisit/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "DiaVisit//"; //签名保存路径

        public string PrintName
        {
            get
            {
                return "05型糖尿病患者随访服务记录表.xps";
            }
        }

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                DataSet list = new ChronicDiadetesVisitBLL().GetList(" IDCardNo='" + this.CardID + "'");
                if (list != null && list.Tables.Count > 0 && list.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public FixedDocumentSequence getReport()
        {
            List<ListValue> list = null;
            if (!string.IsNullOrEmpty(this.CardID))
            {
                RecordsBaseInfoModel model = new RecordsBaseInfoBLL().GetModel(this.CardID);
                list = new List<ListValue>
				{
					new ListValue
					{
						strMark = "$archiveid",
						strVal = model.RecordID
					},
					new ListValue
					{
						strMark = "$name",
						strVal = model.CustomerName
					}
				};
                int Year = DateTime.Now.Year;

                string strWhere = string.Format("IDCardNo='{0}'order by VisitDate desc limit 0,4 ", this.CardID);
                List<ChronicDiadetesVisitModel> model1 = new ChronicDiadetesVisitBLL().GetModelList(strWhere);
                int count = model1.Count;
                foreach (ChronicDiadetesVisitModel model2 in model1)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$zsx" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.StapleFooddailygTarget)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$sfrq" + count.ToString(),
                        strVal = DrawItems.strToDate(model2.VisitDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xcsfsj" + count.ToString(),
                        strVal = DrawItems.strToDate(model2.NextVisitDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zz" + count.ToString(),
                        strVal = model2.Symptom
                    });
                    list.Add(new ListValue
                    {
                        strMark = "%zzqt" + count.ToString(),
                        strVal = model2.SymptomOther
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xgy" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.Hypertension)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xdy" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.Hypotension)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$tz" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.Weight)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$tzzs" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.BMI)
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#tzzs" + count.ToString(),
                        strVal = Convert.ToString(Convert.ToInt32(model2.DorsalisPedispulse))
                    });

                    list.Add(new ListValue
                    {
                        strMark = "$tzqt" + count.ToString(),
                        strVal = model2.PhysicalSymptomMother
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$rxy" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.DailySmokeNum, 0)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ryj" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.DailyDrinkNum, 0)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ydz" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.SportTimePerWeek, 0)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ydc" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.SportPerMinuteTime, 0)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zs" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.StapleFooddailyg)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#xltz" + count.ToString(),
                        strVal = model2.PsychoAdjustment
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zyxw" + count.ToString(),
                        strVal = model2.ObeyDoctorBehavior
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$kfxt" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.FPG)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xh" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.HbAlc)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$fzrq" + count.ToString(),
                        strVal = DrawItems.strToDate(model2.ExamDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "%fzjcqt" + count.ToString(),
                        strVal = model2.AssistantExam
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#fyyc" + count.ToString(),
                        strVal = model2.MedicationCompliance
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#blfy" + count.ToString(),
                        strVal = model2.Adr
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$fyqt" + count.ToString(),
                        strVal = model2.AdrEx
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#dxtfy" + count.ToString(),
                        strVal = model2.HypoglyceMiarreAction
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#sffl" + count.ToString(),
                        strVal = model2.VisitType
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ydzl" + count.ToString(),
                        strVal = model2.InsulinType
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ydyf" + count.ToString(),
                        strVal = model2.InsulinUsage
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#sffs" + count.ToString(),
                        strVal = model2.VisitWay
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzyy" + count.ToString(),
                        strVal = model2.ReferralReason
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzjg" + count.ToString(),
                        strVal = model2.ReferralOrg
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$tzx" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.TargetWeight)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$tzzsx" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.BMITarget)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$rxyx" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.DailySmokeNumTarget, 0)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ryjx" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.DailyDrinkNumTarget, 0)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ydzx" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.SportTimePerWeekTarget, 0)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ydcx" + count.ToString(),
                        strVal = DrawItems.objToNumStr(model2.SportPerMinuteTimeTarget, 0)
                    });
                    if ((int)model2.DorsalisPedispulse.Value == 2)
                    {
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.DorsalisPedispulseType), "jr" + count.ToString(), 3));
                    }
                    else if ((int)model2.DorsalisPedispulse.Value == 3)
                    {
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.DorsalisPedispulseType), "xs" + count.ToString(), 3));
                    }
                    list.Add(new ListValue
                    {
                        strMark = "#xbcs" + count.ToString(),
                        strVal = model2.NextMeasures
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzlx" + count.ToString(),
                        strVal = model2.ReferralContacts
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zzjg" + count.ToString(),
                        strVal = model2.ReferralResult
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$bz" + count.ToString(),
                        strVal = model2.Remarks
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ydtzzl" + count.ToString(),
                        strVal = model2.InsulinAdjustType
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ydtzyf" + count.ToString(),
                        strVal = model2.InsulinAdjustUsage
                    });
                    //滕州无签字版
                    list.Add(new ListValue
                    {
                        strMark = "$qm" + count.ToString(),
                        strVal = model.CustomerName
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$sfys" + count.ToString(),
                        strVal = model2.VisitDoctor
                    });

                    list.Add(new ListValue
                    {
                        strMark = "&qm" + count.ToString(),
                        strVal = string.Format("{0}{1}_{2}.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model2.VisitDate).ToString("yyyyMMdd"))
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&sfys" + count.ToString(),
                        strVal = string.Format("{0}{1}_{2}_Doc.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model2.VisitDate).ToString("yyyyMMdd"))
                    });
                    List<ChronicDrugConditionModel> modelList = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' and TYPE = '{1}' and OUTKey = '" + model2.ID + "' ", this.CardID, "2"));
                    if (modelList != null && modelList.Count > 0)
                    {
                        list.AddRange(this.getDrug(modelList, count, 0).ToArray());
                    }
                    List<ChronicDrugConditionModel> modelListTZ = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' and TYPE = '{1}' and OUTKey ='" + model2.ID + "' ", this.CardID, "8"));//用药调整类型为8
                    if (modelListTZ != null && modelListTZ.Count > 0)
                    {
                        list.AddRange(this.getDrug(modelListTZ, count, 3).ToArray());
                    }
                    count--;
                }

            }
            return DrawItems.setPage("printXps\\"+this.PrintName, list);
        }
        public List<ListValue> getDrug(List<ChronicDrugConditionModel> drugs, int count, int num)//目前用药情况，num从0开始，用药调整情况，num从3开始
        {
            List<ListValue> list = new List<ListValue>();
            //int num = 0;
            foreach (ChronicDrugConditionModel current in drugs)
            {
                num++;
                list.Add(new ListValue
                {
                    strMark = "$ywmc" + num.ToString() + count.ToString(),
                    strVal = current.Name
                });
                list.Add(new ListValue
                {
                    strMark = "$mc" + num.ToString() + count.ToString(),
                    strVal = current.DosAge
                });

            }
            return list;
        }
    }
}
