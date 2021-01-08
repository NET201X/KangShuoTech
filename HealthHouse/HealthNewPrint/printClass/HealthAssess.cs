using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.Model;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.BLL;
using ReportPrint;

namespace printClass
{
	public class HealthAssess:IGetReport
	{
        public string CardID
        {
            get;
            set;
        }
        public RecordsBaseInfoModel BaseModel
        {
            get;
            set;
        }
        public string PrintName
        {
            get
            {
                return "43健康小屋评估表.xps";
            }
        }
        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                HealthAssessExamModel modelTem = new HealthAssessExamBLL().GetMaxModel(this.CardID);
                if (modelTem != null)
                {
                    return true;
                }
            }
            return false;
        }
        public FixedDocumentSequence getReport()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                List<ListValue> list = new List<ListValue>();
                BaseModel = new RecordsBaseInfoBLL().GetModel(this.CardID);
                if (BaseModel != null)
                {
                    list.Add(new ListValue
                    { 
                        strMark="$name",
                        strVal=BaseModel.CustomerName
                        
                    } );
                    list.Add(new ListValue
                    {
                        strMark = "$archiveid",
                        strVal = BaseModel.RecordID
                    });
                }
                #region 健康问询
                HealthAssessExamModel model1 = new HealthAssessExamBLL().GetMaxModel(this.CardID);
                if (model1 != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "#jzjb",
                        strVal = model1.FamilyHistory
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#jb",
                        strVal = model1.MedicalHistory
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#yscs",
                        strVal = model1.DietaryHabit
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#ysglx",
                        strVal = model1.DietaryLaw
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ysqt",
                        strVal = model1.DietaryOther
                    });
                  
                    list.Add(new ListValue
                    {
                        strMark = "#dlpl",
                        strVal = model1.ExerciseRate
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$dlsj",
                        strVal = model1.ExerciseTimes.ToString()
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zys",
                        strVal = model1.HospitalHistory
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#fy",
                        strVal = model1.TakingMedicine
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zlnl",
                        strVal = model1.OldSelfCareability
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zldf",
                        strVal = model1.GloomyScore.ToString()
                    });
                    string strtyfs = "";
                    if (!string.IsNullOrEmpty(model1.ExerciseExistense))
                    {
                        foreach (char c in model1.ExerciseExistense)
                        {
                            switch (c)
                            {
                                case '1': strtyfs = strtyfs + "散步；";
                                    break;
                                case '2': strtyfs = strtyfs + "跑步；";
                                    break;
                                case '3': strtyfs = strtyfs + "广场舞；";
                                    break;
                                default: break;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(model1.ExerciseExistenseOther))
                    {
                        strtyfs = strtyfs + model1.ExerciseExistenseOther + "；";
                    }
                    list.Add(new ListValue
                    {
                        strMark = "$dlfs",
                        strVal = strtyfs
                    });
                    #region 体检评估
                    HealthHouseModel model2 = new HealthHouseBLL().GetDataByID(model1.PID);
                    if (model2 != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$tjsj",
                            strVal = DrawItems.strToDate(model2.CheckDate)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$bmi",
                            strVal =model2.BMI.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$gy",
                            strVal = model2.LeftHeight.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$dy",
                            strVal = model2.LeftPre.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ml",
                            strVal = model2.PulseRate.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xy",
                            strVal = model2.BloodOxygen
                        });
                       
                        HealthHouseBCHAOModel BchaoModel = new HealthHouseBCHAOBLL().GetModel(model2.ID);//B超表
                        if (BchaoModel != null)
                        {
                            list.Add(new ListValue
                            {
                                strMark = "#bc",
                                strVal = BchaoModel.BCHAO
                            });
                        }
                        HealthHouseEcgModel EcgModel = new HealthHouseEcgBLL().GetModel(model2.ID);//心电
                        if (EcgModel != null)
                        {
                            list.Add(new ListValue
                            {
                                strMark = "#xd",
                                strVal = EcgModel.ECG
                            });
                        }
                        HHCardiovascularModel VascularModel = new HHCardiovascularBLL().GetData(this.CardID, model2.ID);//心血管
                        if (VascularModel != null)
                        {
                            list.Add(new ListValue
                            {
                                strMark = "#xx",
                                strVal = VascularModel.Result
                            });
                        }
                        HHBoneModel BoneModel = new HHBoneBLL().GetData(this.CardID, model2.ID);//骨密度
                        if (BoneModel != null)
                        {
                            list.Add(new ListValue
                            {
                                strMark = "#gm",
                                strVal = BoneModel.Result
                            });
                        }
                        HHLungModel LungModel = new HHLungBLL().GetData(this.CardID, model2.ID);//肺功能
                        if (LungModel != null)
                        {
                            list.Add(new ListValue
                            {
                                strMark = "#fg",
                                strVal = LungModel.Result
                            });
                        }
                        HealthHousePhysicalAssistCheckModel HHAssistCheck = new HealthHousePhysicalAssistCheckBLL().GetModel(model2.ID);//辅助检查表
                        if (HHAssistCheck != null)
                        {
                            list.Add(new ListValue
                            {
                                strMark = "#xb",
                                strVal = HHAssistCheck.CHESTX
                            });
                            if (!string.IsNullOrEmpty(HHAssistCheck.PRO)
                                && !string.IsNullOrEmpty(HHAssistCheck.GLU)
                                && !string.IsNullOrEmpty(HHAssistCheck.KET)
                                && !string.IsNullOrEmpty(HHAssistCheck.BLD))
                            {
                                if (HHAssistCheck.PRO.Contains("+")
                                   || HHAssistCheck.GLU.Contains("+")
                                    || HHAssistCheck.KET.Contains("+")
                                    || HHAssistCheck.BLD.Contains("+"))
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "#nc",
                                        strVal = "2"
                                    });
                                }
                                else
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "#nc",
                                        strVal = "1"
                                    });
                                }
                            }
                        }
                        HealthHouseMediPhyModel MedModel = new HealthHouseMediPhyBLL().GetModel(model2.ID);//中医体质类型
                        if (MedModel != null)
                        {
                            string strMed = "";
                            if (!string.IsNullOrEmpty(MedModel.Mild))
                            {
                                strMed += "平和质,";
                            }
                            if (!string.IsNullOrEmpty(MedModel.Faint))
                            {
                                strMed += "气虚质,";
                            }
                            if (!string.IsNullOrEmpty(MedModel.Yang))
                            {
                                strMed += "阳虚质,";
                            }
                            if (!string.IsNullOrEmpty(MedModel.Yin))
                            {
                                strMed += "阴虚质,";
                            }
                            if (!string.IsNullOrEmpty(MedModel.PhlegmDamp))
                            {
                                strMed += "痰湿质,";
                            }
                            if (!string.IsNullOrEmpty(MedModel.Muggy))
                            {
                                strMed += "湿热质,";
                            }
                            if (!string.IsNullOrEmpty(MedModel.BloodStasis))
                            {
                                strMed += "血瘀质,";
                            }
                            if (!string.IsNullOrEmpty(MedModel.QiConstraint))
                            {
                                strMed += "气郁质,";
                            }
                            if (!string.IsNullOrEmpty(MedModel.Characteristic))
                            {
                                strMed += "特兼质,";
                            }
                            if (strMed != "")
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "$zytz",
                                    strVal = strMed.Remove(strMed.Length - 1, 1)
                                });
                            }
                        }
                    }

                    #endregion
                    #region 范围值
                    List<HealthOverviewSetModel> SetList = new List<HealthOverviewSetModel>();
                    SetList = new HealthOverviewSetBLL().GetList(" and Type in (1,2,3,4) ");
                    string strBMI = "",strxueya="",strxinlv="",strxueyang="";
                    if (SetList != null)
                    {
                        foreach (HealthOverviewSetModel setmodel in SetList)
                        {
                            if (setmodel.Type == "1")//体质指数
                            {
                                strBMI = setmodel.minValues + "~" + setmodel.maxValues;
                            }
                            else if (setmodel.Type == "2")//血压
                            {
                                strxueya = setmodel.minValues + "~" + setmodel.maxValues;
                            }
                            else if (setmodel.Type == "3")//心率
                            {
                                strxinlv = setmodel.minValues + "~" + setmodel.maxValues;
                            }
                            else if (setmodel.Type == "4")//血氧
                            {
                                strxueyang = setmodel.minValues + "~" + setmodel.maxValues;
                            }
                        }
                    }
                    list.Add(new ListValue
                    {
                        strMark = "$bmifw",
                        strVal = strBMI
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xzfw",
                        strVal = strxueya
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xlfw",
                        strVal = strxinlv
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xyfw",
                        strVal = strxueyang
                    });
                    #endregion
                }
                #endregion
                return DrawItems.setPage("printXps\\" + PrintName, list);
            }
            return null;
        }
	}
}
