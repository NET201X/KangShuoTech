using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;
using ReportPrint;
using System.Configuration;

namespace printClass
{
    public class Mentaldisease_Baseinfo : IGetReport
    {
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/MentalVisit/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "MentalVisit//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "07重性精神疾病患者个人信息补充表.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                DataSet list = new ChronicMentalDiseaseBaseInfoBLL().GetList(" IDCardNo='" + this.CardID + "'");
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

                ChronicMentalDiseaseBaseInfoModel model2 = new ChronicMentalDiseaseBaseInfoModel();
                model2 = new ChronicMentalDiseaseBaseInfoBLL().GetModel(this.CardID);

                if (model2 != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "#gsqk",
                        strVal = model2.LockInfo
                    });
                    list.Add(new ListValue
                    {
                        strMark = "%zjzl",
                        strVal = model2.SpecialistProposal
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$tbrq",
                        strVal = DrawItems.strToDate(model2.FillformTime)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$sczlsj",
                        strVal = DrawItems.strToDate(model2.FirstTreatmenTTime)
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
                        strMark = "$qtwx",
                        strVal = DrawItems.objToNumStr(model2.OtherDangerFrequen, 0)
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
                    //list.Add(new ListValue
                    //{
                    //    strMark = "@hbyxw",
                    //    strVal = (model2.AttemptSuicideNone != "有") ? "1" : ""
                    //});
                    list.Add(new ListValue
                    {
                        strMark = "$jhrxm",
                        strVal = model2.GuardianName
                    });
                    string strhzgx = "";
                    switch (Convert.ToInt32(model2.Ralation))
                    {
                        case 1:
                            strhzgx = "户主";
                            break;
                        case 2:
                            strhzgx = "配偶";
                            break;
                        case 3:
                            strhzgx = "父亲";
                            break;
                        case 4:
                            strhzgx = "母亲";
                            break;
                        case 5:
                            strhzgx = "兄弟";
                            break;
                        case 6:
                            strhzgx = "姐妹";
                            break;
                        case 7:
                            strhzgx = "儿子";
                            break;
                        case 8:
                            strhzgx = "女儿";
                            break;
                        case 9:
                            strhzgx = "儿媳";
                            break;
                        case 10:
                            strhzgx = "女婿";
                            break;
                        case 11:
                            strhzgx = "孙子";
                            break;
                        case 12:
                            strhzgx = "孙女";
                            break;
                        case 13:
                            strhzgx = "外孙";
                            break;
                        case 14:
                            strhzgx = "外孙女";
                            break;
                        case 15:
                            strhzgx = "其他";
                            break;
                        default: break;
                    }
                    list.Add(new ListValue
                    {
                        strMark = "$hzgx",
                        strVal = strhzgx
                    });

                    list.Add(new ListValue
                    {
                        strMark = "$jhzz",
                        strVal = model2.GuradianAddr
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$jhdh",
                        strVal = model2.GuradianPhone
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ccfb",
                        strVal = DrawItems.strToDate(model2.FirstTime)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zqty",
                        strVal = model2.AgreeManagement
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zqqz",
                        strVal = model2.AgreeSignature
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$qzsj",
                        strVal = DrawItems.strToDate(model2.AgreeTime)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zz",
                        strVal = model2.Symptom
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzqt",
                        strVal = model2.SymptomOther
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#jwmz",
                        strVal = model2.OutPatien
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zycs",
                        strVal = DrawItems.objToNumStr(model2.HospitalCount, 0)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$mqzd",
                        strVal = model2.DiagnosisInfo
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$qzyy",
                        strVal = model2.DiagnosisHospital
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$qzrq",
                        strVal = DrawItems.strToDate(model2.DiagnosisTime)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zjzl",
                        strVal = model2.LastCure
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$lxr",
                        strVal = model2.VillageContacts + " / " + model2.VillageTel
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#jjzk",
                        strVal = model2.Economy
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#hzzy",
                        strVal = model2.Professional
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#hb",
                        strVal = model2.HouseType
                    });
                    string strwxxw = "";
                    if (!string.IsNullOrEmpty(model2.AttemptSuicFrequen.ToString()) && model2.MildTroubleFrequen != 0)
                    {
                        strwxxw += "1,";
                    }
                    if (!string.IsNullOrEmpty(model2.CreateDistuFrequen.ToString()) && model2.CreateDistuFrequen != 0)
                    {
                        strwxxw += "2,";
                    }
                    if (!string.IsNullOrEmpty(model2.CauseAccidFrequen.ToString()) && model2.CauseAccidFrequen != 0)
                    {
                        strwxxw += "3,";
                    }
                    if (!string.IsNullOrEmpty(model2.AttemptSuicideNone.ToString()) && model2.OtherDangerFrequen != 0)
                    {
                        strwxxw += "4,";
                    }
                    if (!string.IsNullOrEmpty(model2.AutolesionFrequen.ToString()) && model2.AutolesionFrequen != 0)
                    {
                        strwxxw += "5,";
                    }
                    if (!string.IsNullOrEmpty(model2.AttemptSuicFrequen.ToString()) && model2.AttemptSuicFrequen != 0)
                    {
                        strwxxw += "6,";
                    }

                    list.Add(new ListValue
                    {
                        strMark = "#wxxw",
                        strVal = string.IsNullOrEmpty(strwxxw) ? "7" : strwxxw.Substring(0, strwxxw.Length - 1)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&qm",
                        strVal = string.Format("{0}{1}_{2}.png", SignPath, model2.IDCardNo, "BaseInfo")
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&ysqz",
                        strVal = string.Format("{0}{1}_{2}_Doc.png", SignPath, model2.IDCardNo, "BaseInfo")
                    });

                    //滕州无签字版
                    list.Add(new ListValue
                    {
                        strMark = "$qm",
                        strVal = model.CustomerName
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ysqz",
                        strVal = model2.DoctorMark
                    });

                }


            }
            return DrawItems.setPage("printXps\\07重性精神疾病患者个人信息补充表.xps", list);
        }
    }
}
