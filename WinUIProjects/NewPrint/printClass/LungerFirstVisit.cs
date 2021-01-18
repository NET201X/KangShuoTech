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
    public class LungerFirstVisit : IGetReport
    {
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/PTBVisit/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "PTBVisit//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "25肺结核患者第一次入户随访记录表.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                DataSet list = new ChronicLungerFirstVisitBLL().GetList(" IDCardNo='" + this.CardID + "'");

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
                    list.Add(new ListValue
                    {
                        strMark = "$sfrq",
                        strVal = DrawItems.strToDate(model2.FollowupDate)
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#sffs",
                        strVal = model2.FollowupWay
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#hzlx",
                        strVal = model2.PatientType
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#tjqk",
                        strVal = model2.Sputumfungs
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#nyqk",
                        strVal = model2.DrugFast
                    });
                    string strSymptom = "";
                    if (!string.IsNullOrEmpty(model2.Symptom))
                    {
                        foreach (string str in model2.Symptom.Split(new char[] { ',' }))
                        {
                            if (!string.IsNullOrEmpty(str))
                            {
                                strSymptom += (int.Parse(str) - 1).ToString() + ",";
                            }
                        }
                        strSymptom = strSymptom.Remove(strSymptom.Length - 1);
                    }
                    list.Add(new ListValue
                    {
                        strMark = "#zz",
                        strVal = strSymptom
                    });

                    list.Add(new ListValue
                    {
                        strMark = "%zzqt",
                        strVal = model2.SymptomEx
                    });

                    list.Add(new ListValue
                    {
                        strMark = "$hlfa",
                        strVal = model2.ChemotherapyScheme
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#yf",
                        strVal = model2.MedicationCompliance
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#ypjx",
                        strVal = model2.DrugType
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#ddryxz",
                        strVal = model2.Supervisor
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#ddjs",
                        strVal = model2.StandaloneRoom
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#tfqk",
                        strVal = model2.Ventilation
                    });

                    list.Add(new ListValue
                    {
                        strMark = "$xy",
                        strVal = DrawItems.objToNumStr(model2.SmokeDayNum, 0)
                    });

                    list.Add(new ListValue
                    {
                        strMark = "$nxy",
                        strVal = DrawItems.objToNumStr(model2.NextSmokeDayNum, 0)
                    });

                    list.Add(new ListValue
                    {
                        strMark = "$yj",
                        strVal = DrawItems.objToNumStr(model2.DayDrinkVolume, 0)
                    });

                    list.Add(new ListValue
                    {
                        strMark = "$nyj",
                        strVal = DrawItems.objToNumStr(model2.NextDayDrinkVolume, 0)
                    });

                    list.Add(new ListValue
                    {
                        strMark = "$qydd",
                        strVal = model2.MediclineReceivePlace
                    });

                    list.Add(new ListValue
                    {
                        strMark = "$qysj",
                        strVal = DrawItems.strToDate(model2.MediclineReceiveTime)
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#jkjy1",
                        strVal = model2.RecordcardWrite
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#jkjy2",
                        strVal = model2.PharmacyWayDeposit
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#jkjy3",
                        strVal = model2.Therapies
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#jkjy4",
                        strVal = model2.IndisciplineHarm
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#jkjy5",
                        strVal = model2.AdrsHandle
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#jkjy6",
                        strVal = model2.SubsequentVisit
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#jkjy7",
                        strVal = model2.InsistPharmacy
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#jkjy8",
                        strVal = model2.LivingHabit
                    });

                    list.Add(new ListValue
                    {
                        strMark = "#jkjy9",
                        strVal = model2.ChecktouchPerson
                    });

                    list.Add(new ListValue
                    {
                        strMark = "$xcsfsj",
                        strVal = DrawItems.strToDate(model2.NextVisitDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&qm",
                        strVal = string.Format("{0}{1}_{2}.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model2.FollowupDate).ToString("yyyyMMdd"))
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&sfys",
                        strVal = string.Format("{0}{1}_{2}_Doc.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model2.FollowupDate).ToString("yyyyMMdd"))
                    });
                    //滕州无签字版
                    list.Add(new ListValue
                    {
                        strMark = "$qm",
                        strVal = model.CustomerName
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$sfys",
                        strVal = model2.VisitDoctor
                    });
                }
            }

            return DrawItems.setPage("printXps\\25肺结核患者第一次入户随访记录表.xps", list);
        }
    }
}
