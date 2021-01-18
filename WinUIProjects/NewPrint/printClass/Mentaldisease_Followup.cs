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
    public class Mentaldisease_Followup : IGetReport
    {
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/MentalVisit/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "MentalVisit//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "08重性精神疾病患者随访服务记录表.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                DataSet list = new ChronicMentalDiseaseVisitBLL().GetList(" IDCardNo='" + this.CardID + "'");
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
                ChronicMentalDiseaseVisitModel model2 = new ChronicMentalDiseaseVisitBLL().GetModel(this.CardID);
                if (model2 != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$xcsfsj",
                        strVal = DrawItems.strToDate(model2.NextFollowUpDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$sfrq",
                        strVal = DrawItems.strToDate(model2.FollowUpDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#wxx",
                        strVal = model2.Fatalness
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zqty",
                        strVal = model2.PresentSymptom
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzqt",
                        strVal = model2.PresentSymptoOther
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zznl",
                        strVal = model2.Insight
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#smqk",
                        strVal = model2.SleepQuality
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#ysqk",
                        strVal = model2.Diet
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#grsh",
                        strVal = model2.PersonalCare
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#jwld",
                        strVal = model2.Housework
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#scld",
                        strVal = model2.ProductLaborWork
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#xxnl",
                        strVal = model2.LearningAbility
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#shrj",
                        strVal = model2.SocialInterIntera
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$qdzs",
                        strVal = DrawItems.objToNumStr(model2.MildTroubleFrequen, 0)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zs",
                        strVal = DrawItems.objToNumStr(model2.CreateDistuFrequen, 0)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zh",
                        strVal = DrawItems.objToNumStr(model2.CauseAccidFrequen, 0)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zsh",
                        strVal = DrawItems.objToNumStr(model2.AutolesionFrequen, 0)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zsws",
                        strVal = DrawItems.objToNumStr(model2.AttemptSuicFrequen, 0)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$qtwh",
                        strVal = DrawItems.objToNumStr(model2.OtherDangerFrequen, 0)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "@hbyxw",
                        strVal = (model2.AttemptSuicideNone != "有") ? "1" : ""
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#gsqk",
                        strVal = model2.LockCondition
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zyqk",
                        strVal = model2.HospitalizatiStatus
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zycy",
                        strVal = DrawItems.strToDate(model2.LastLeaveHospTime)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#syjc",
                        strVal = model2.LaborExaminati
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$syjcy",
                        strVal = model2.LaborExaminatiHave
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#fyyc",
                        strVal = model2.MedicatioCompliance
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#blfy",
                        strVal = model2.AdnerDruReact
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$blqt",
                        strVal = model2.AdverDruReactHave
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zlxg",
                        strVal = model2.TreatmentEffect
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zz",
                        strVal = model2.WhetherReferral
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzyy",
                        strVal = model2.ReferralReason
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzks",
                        strVal = model2.ReferralAgencDepar
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#kfcs",
                        strVal = model2.RehabiliMeasu
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$kfqt",
                        strVal = model2.RehabiliMeasuOther
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#sffl",
                        strVal = model2.FollowupClassificat
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$swrq",
                        strVal = DrawItems.strToDate(model2.DeathDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#qtjb",
                        strVal = model2.IllReason
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#swqt",
                        strVal = model2.DeathReason
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#sfyy",
                        strVal = model2.NoVisitReason
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#sffs",
                        strVal = model2.FollowUpType
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#lxbm",
                        strVal = model2.JointPartFlag
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$gadlr",
                        strVal = model2.PoliceAgent
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$sqdlr",
                        strVal = model2.CommunityAgent
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$gadh",
                        strVal = model2.PoliceAgentTel
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$sqdh",
                        strVal = model2.CommunityAgentTel
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zzcg",
                        strVal = model2.ReferralResult
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzjg",
                        strVal = model2.ReferralOrgan
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzlxr",
                        strVal = model2.ReferraContacts
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzlxdh",
                        strVal = model2.ReferralContactsTel
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#jskys",
                        strVal = model2.ContactSpecialist
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$jsys",
                        strVal = model2.SpecialistName
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$jsysdh",
                        strVal = model2.SpecialistTel
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$czjg",
                        strVal = model2.DisposalResult
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&qm",
                        strVal = string.Format("{0}{1}_{2}.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model2.FollowUpDate).ToString("yyyyMMdd"))
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&yfys",
                        strVal = string.Format("{0}{1}_{2}_Doc.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model2.FollowUpDate).ToString("yyyyMMdd"))
                    });
                    //滕州无签字版
                    list.Add(new ListValue
                    {
                        strMark = "$qm",
                        strVal = model.CustomerName
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$yfys",
                        strVal = model2.FollowUpDoctor
                    });
                    List<ChronicDrugConditionModel> modelList = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' and TYPE = '{1}' and OUTKey = '" + model2.ID + "' ", this.CardID, "3"));
                    if (modelList != null && modelList.Count > 0)
                    {
                        list.AddRange(this.getDrug(modelList, 0).ToArray());
                    }
                    List<ChronicDrugConditionModel> YYZDmodelList = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' and TYPE = '{1}' and OUTKey = '" + model2.ID + "' ", this.CardID, "6"));//调整用药情况
                    if (YYZDmodelList != null && YYZDmodelList.Count > 0)
                    {
                        list.AddRange(this.getDrug(YYZDmodelList, 3).ToArray());
                    }
                }
            }
            return DrawItems.setPage("printXps\\" + this.PrintName, list);
        }
        public List<ListValue> getDrug(List<ChronicDrugConditionModel> drugs, int num)
        {
            List<ListValue> list = new List<ListValue>();
            foreach (ChronicDrugConditionModel current in drugs)
            {
                num++;
                list.Add(new ListValue
                {
                    strMark = "$ywmc" + num.ToString(),
                    strVal = current.Name
                });
                list.Add(new ListValue
                {
                    strMark = "$mc" + num.ToString(),
                    strVal = current.DosAge
                });
            }
            return list;
        }

    }
}
