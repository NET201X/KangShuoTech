using System;
using System.Collections.Generic;
using printClass;
using KangShuoTech.DataAccessProjects.Model;
using System.Data;
using KangShuoTech.DataAccessProjects.BLL;
using System.Windows.Documents;
using System.Configuration;

namespace ReportPrint
{
    public class ChronicLungerVisit : IGetReport
    {
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/PTBVisit/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "PTBVisit//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "26肺结核患者随访服务记录表.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                DataSet list = new ChronicLungerVisitBLL().GetList(" IDCardNo='" + this.CardID + "'");

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

                ChronicLungerFirstVisitModel model2 = new ChronicLungerFirstVisitBLL().GetModel(this.CardID);
                if (model2 != null)
                {
                    ChronicLungerVisitModel model1 = new ChronicLungerVisitBLL().GetModelByOutKey(model2.ID, "1");

                    if (model1 != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$sfrq1",
                            strVal = DrawItems.strToDate(model1.FollowupDate)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$m1",
                            strVal = DrawItems.objToNumStr(model1.CureMonth, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#ddryxz1",
                            strVal = model1.Supervisor
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#sffs1",
                            strVal = model1.FollowupWay
                        });

                        string strSymptom1 = "";
                        if (!string.IsNullOrEmpty(model1.Symptom))
                        {
                            foreach (string str in model1.Symptom.Split(new char[] { ',' }))
                            {
                                if (!string.IsNullOrEmpty(str))
                                {
                                    strSymptom1 += (int.Parse(str) - 1).ToString() + ",";
                                }
                            }
                            strSymptom1 = strSymptom1.Remove(strSymptom1.Length - 1);
                        }
                        list.Add(new ListValue
                        {
                            strMark = "#zz1",
                            strVal = strSymptom1
                        });

                        list.Add(new ListValue
                        {
                            strMark = "%zzqt1",
                            strVal = model1.SymptomEx
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$y1",
                            strVal = DrawItems.objToNumStr(model1.SmokeDayNum, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$ny1",
                            strVal = DrawItems.objToNumStr(model1.NextSmokeDayNum, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$j1",
                            strVal = DrawItems.objToNumStr(model1.DayDrinkVolume, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$nj1",
                            strVal = DrawItems.objToNumStr(model1.NextDayDrinkVolume, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "%hlfa1",
                            strVal = model1.ChemotherapyScheme
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#yf1",
                            strVal = model1.MedicationCompliance
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#ypjx1",
                            strVal = model1.DrugType
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$lfycs1",
                            strVal = DrawItems.objToNumStr(model1.OmissiveTimes, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#ywfy1",
                            strVal = model1.Adr
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$fy1",
                            strVal = model1.AdrEx
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#bfz1",
                            strVal = model1.Complication
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$hbz1",
                            strVal = model1.ComplicationEx
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zzkb1",
                            strVal = model1.ReferralOrg
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zzyy1",
                            strVal = model1.ReferralReason
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zzjg1",
                            strVal = model1.ReferralResult
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$clyj1",
                            strVal = model1.HandleView
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$xcsfsj1",
                            strVal = DrawItems.strToDate(model1.NextVisitDate)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$sfys1",
                            strVal = model1.VisitDoctor
                        });
                        list.Add(new ListValue
                        {
                            strMark = "&qm1",
                            strVal = string.Format("{0}{1}_1_{2}.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model1.FollowupDate).ToString("yyyyMMdd"))
                        });
                        list.Add(new ListValue
                        {
                            strMark = "&sfys1",
                            strVal = string.Format("{0}{1}_1_{2}_Doc.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model1.FollowupDate).ToString("yyyyMMdd"))
                        });
                        //滕州无签字版
                        list.Add(new ListValue
                        {
                            strMark = "$qm1",
                            strVal = model.CustomerName
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sfys1",
                            strVal = model2.VisitDoctor
                        });
                    }

                    model1 = new ChronicLungerVisitBLL().GetModelByOutKey(model2.ID, "2");

                    if (model1 != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$sfrq2",
                            strVal = DrawItems.strToDate(model1.FollowupDate)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$m2",
                            strVal = DrawItems.objToNumStr(model1.CureMonth, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#ddryxz2",
                            strVal = model1.Supervisor
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#sffs2",
                            strVal = model1.FollowupWay
                        });

                        string strSymptom2 = "";
                        if (!string.IsNullOrEmpty(model1.Symptom))
                        {
                            foreach (string str in model1.Symptom.Split(new char[] { ',' }))
                            {
                                if (!string.IsNullOrEmpty(str))
                                {
                                    strSymptom2 += (int.Parse(str) - 1).ToString() + ",";
                                }
                            }
                            strSymptom2 = strSymptom2.Remove(strSymptom2.Length - 1);
                        }
                        list.Add(new ListValue
                        {
                            strMark = "#zz2",
                            strVal = strSymptom2
                        });

                        list.Add(new ListValue
                        {
                            strMark = "%zzqt2",
                            strVal = model1.SymptomEx
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$y2",
                            strVal = DrawItems.objToNumStr(model1.SmokeDayNum, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$ny2",
                            strVal = DrawItems.objToNumStr(model1.NextSmokeDayNum, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$j2",
                            strVal = DrawItems.objToNumStr(model1.DayDrinkVolume, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$nj2",
                            strVal = DrawItems.objToNumStr(model1.NextDayDrinkVolume, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "%hlfa2",
                            strVal = model1.ChemotherapyScheme
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#yf2",
                            strVal = model1.MedicationCompliance
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#ypjx2",
                            strVal = model1.DrugType
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$lfycs2",
                            strVal = DrawItems.objToNumStr(model1.OmissiveTimes, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#ywfy2",
                            strVal = model1.Adr
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$fy2",
                            strVal = model1.AdrEx
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#bfz2",
                            strVal = model1.Complication
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$hbz2",
                            strVal = model1.ComplicationEx
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zzkb2",
                            strVal = model1.ReferralOrg
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zzyy2",
                            strVal = model1.ReferralReason
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zzjg2",
                            strVal = model1.ReferralResult
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$clyj2",
                            strVal = model1.HandleView
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$xcsfsj2",
                            strVal = DrawItems.strToDate(model1.NextVisitDate)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$sfys2",
                            strVal = model1.VisitDoctor
                        });
                        list.Add(new ListValue
                        {
                            strMark = "&qm2",
                            strVal = string.Format("{0}{1}_2_{2}.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model1.FollowupDate).ToString("yyyyMMdd"))
                        });
                        list.Add(new ListValue
                        {
                            strMark = "&sfys2",
                            strVal = string.Format("{0}{1}_2_{2}_Doc.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model1.FollowupDate).ToString("yyyyMMdd"))
                        });
                        //滕州无签字版
                        list.Add(new ListValue
                        {
                            strMark = "$qm2",
                            strVal = model.CustomerName
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sfys2",
                            strVal = model2.VisitDoctor
                        });
                    }

                    model1 = new ChronicLungerVisitBLL().GetModelByOutKey(model2.ID, "3");

                    if (model1 != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$sfrq3",
                            strVal = DrawItems.strToDate(model1.FollowupDate)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$m3",
                            strVal = DrawItems.objToNumStr(model1.CureMonth, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#ddryxz3",
                            strVal = model1.Supervisor
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#sffs3",
                            strVal = model1.FollowupWay
                        });

                        string strSymptom3 = "";
                        if (!string.IsNullOrEmpty(model1.Symptom))
                        {
                            foreach (string str in model1.Symptom.Split(new char[] { ',' }))
                            {
                                if (!string.IsNullOrEmpty(str))
                                {
                                    strSymptom3 += (int.Parse(str) - 1).ToString() + ",";
                                }
                            }
                            strSymptom3 = strSymptom3.Remove(strSymptom3.Length - 1);
                        }
                        list.Add(new ListValue
                        {
                            strMark = "#zz3",
                            strVal = strSymptom3
                        });

                        list.Add(new ListValue
                        {
                            strMark = "%zzqt3",
                            strVal = model1.SymptomEx
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$y3",
                            strVal = DrawItems.objToNumStr(model1.SmokeDayNum, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$ny3",
                            strVal = DrawItems.objToNumStr(model1.NextSmokeDayNum, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$j3",
                            strVal = DrawItems.objToNumStr(model1.DayDrinkVolume, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$nj3",
                            strVal = DrawItems.objToNumStr(model1.NextDayDrinkVolume, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "%hlfa3",
                            strVal = model1.ChemotherapyScheme
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#yf3",
                            strVal = model1.MedicationCompliance
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#ypjx3",
                            strVal = model1.DrugType
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$lfycs3",
                            strVal = DrawItems.objToNumStr(model1.OmissiveTimes, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#ywfy3",
                            strVal = model1.Adr
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$fy3",
                            strVal = model1.AdrEx
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#bfz3",
                            strVal = model1.Complication
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$hbz3",
                            strVal = model1.ComplicationEx
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zzkb3",
                            strVal = model1.ReferralOrg
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zzyy3",
                            strVal = model1.ReferralReason
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zzjg3",
                            strVal = model1.ReferralResult
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$clyj3",
                            strVal = model1.HandleView
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$xcsfsj3",
                            strVal = DrawItems.strToDate(model1.NextVisitDate)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$sfys3",
                            strVal = model1.VisitDoctor
                        });
                        list.Add(new ListValue
                        {
                            strMark = "&qm3",
                            strVal = string.Format("{0}{1}_3_{2}.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model1.FollowupDate).ToString("yyyyMMdd"))
                        });
                        list.Add(new ListValue
                        {
                            strMark = "&sfys3",
                            strVal = string.Format("{0}{1}_3_{2}_Doc.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model1.FollowupDate).ToString("yyyyMMdd"))
                        });
                        //滕州无签字版
                        list.Add(new ListValue
                        {
                            strMark = "$qm3",
                            strVal = model.CustomerName
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sfys3",
                            strVal = model2.VisitDoctor
                        });
                    }
                    model1 = new ChronicLungerVisitBLL().GetModelByOutKey(model2.ID, "4");

                    if (model1 != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$sfrq4",
                            strVal = DrawItems.strToDate(model1.FollowupDate)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$m4",
                            strVal = DrawItems.objToNumStr(model1.CureMonth, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#ddryxz4",
                            strVal = model1.Supervisor
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#sffs4",
                            strVal = model1.FollowupWay
                        });

                        string strSymptom4 = "";
                        if (!string.IsNullOrEmpty(model1.Symptom))
                        {
                            foreach (string str in model1.Symptom.Split(new char[] { ',' }))
                            {
                                if (!string.IsNullOrEmpty(str))
                                {
                                    strSymptom4 += (int.Parse(str) - 1).ToString() + ",";
                                }
                            }
                            strSymptom4 = strSymptom4.Remove(strSymptom4.Length - 1);
                        }
                        list.Add(new ListValue
                        {
                            strMark = "#zz4",
                            strVal = strSymptom4
                        });

                        list.Add(new ListValue
                        {
                            strMark = "%zzqt4",
                            strVal = model1.SymptomEx
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$y4",
                            strVal = DrawItems.objToNumStr(model1.SmokeDayNum, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$ny4",
                            strVal = DrawItems.objToNumStr(model1.NextSmokeDayNum, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$j4",
                            strVal = DrawItems.objToNumStr(model1.DayDrinkVolume, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$nj4",
                            strVal = DrawItems.objToNumStr(model1.NextDayDrinkVolume, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "%hlfa4",
                            strVal = model1.ChemotherapyScheme
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#yf4",
                            strVal = model1.MedicationCompliance
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#ypjx4",
                            strVal = model1.DrugType
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$lfycs4",
                            strVal = DrawItems.objToNumStr(model1.OmissiveTimes, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#ywfy4",
                            strVal = model1.Adr
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$fy4",
                            strVal = model1.AdrEx
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#bfz4",
                            strVal = model1.Complication
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$hbz4",
                            strVal = model1.ComplicationEx
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zzkb4",
                            strVal = model1.ReferralOrg
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zzyy4",
                            strVal = model1.ReferralReason
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zzjg4",
                            strVal = model1.ReferralResult
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$clyj4",
                            strVal = model1.HandleView
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$xcsfsj4",
                            strVal = DrawItems.strToDate(model1.NextVisitDate)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$sfys4",
                            strVal = model1.VisitDoctor
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$cxtzsj",
                            strVal = DrawItems.strToDate(model1.StopCureDate)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#tzyi",
                            strVal = model1.StopCureReason
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$yfscs",
                            strVal = DrawItems.objToNumStr(model1.ShouldVisitTimes, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$sjfscs",
                            strVal = DrawItems.objToNumStr(model1.VisitTimes, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$yfcs",
                            strVal = DrawItems.objToNumStr(model1.ShouldPharmacyTimes, 0)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$sfcs",
                            strVal = DrawItems.objToNumStr(model1.PharmacyTimes, 0)
                        });


                        list.Add(new ListValue
                        {
                            strMark = "$fyl",
                            strVal = DrawItems.objToNumStr(model1.PharmacyRate, 2)
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$pgys1",
                            strVal = model1.EstimateDoctor
                        });
                        list.Add(new ListValue
                        {
                            strMark = "&qm4",
                            strVal = string.Format("{0}{1}_4_{2}.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model1.FollowupDate).ToString("yyyyMMdd"))
                        });
                        list.Add(new ListValue
                        {
                            strMark = "&sfys4",
                            strVal = string.Format("{0}{1}_4_{2}_Doc.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model1.FollowupDate).ToString("yyyyMMdd"))
                        });
                        //滕州无签字版
                        list.Add(new ListValue
                        {
                            strMark = "$qm4",
                            strVal = model.CustomerName
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sfys4",
                            strVal = model2.VisitDoctor
                        });
                    }
                }
            }

            return DrawItems.setPage("printXps\\26肺结核患者随访服务记录表.xps", list);
        }
    }
}
