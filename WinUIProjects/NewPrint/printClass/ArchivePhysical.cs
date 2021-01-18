
using ReportPrint;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using System;
using System.IO;
using KangShuoTech.Utilities.Common;
using System.Configuration;

namespace printClass
{
    public class ArchivePhysical : IGetReport
    {
        string community = ConfigHelper.GetSetNode("community");
        string area = ConfigHelper.GetSetNode("area");
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/" : ConfigurationManager.AppSettings["SignPath"].ToString(); //签名保存路径
        private string SignPathYear = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Year/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Year//"; //签名保存路径
        private string FingerPath = ConfigurationManager.AppSettings["FingerPath"] == null ? @"Finger/" : ConfigurationManager.AppSettings["FingerPath"].ToString(); //指纹采集路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                if (community.Equals("聊城东昌府区"))
                {
                    return "03健康体检表(道口铺镇卫生院).xps";
                }
                return "03健康体检表.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                DataSet list = new RecordsCustomerBaseInfoDAL().GetList(" IDCardNo='" + this.CardID + "'");
                if (list != null && list.Tables.Count > 0 && list.Tables[0].Rows.Count > 0)
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
                RecordsBaseInfoModel model = new RecordsBaseInfoBLL().GetModel(this.CardID);
                string strage = "", strXuex = "", strRH = "";

                TimeParser timeParser = new TimeParser();
                strage = timeParser.GetAge(model.Birthday);

                int format = 2;

                List<ListValue> list = new List<ListValue>
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

                RecordsCustomerBaseInfoModel model2 = new RecordsCustomerBaseInfoDAL().GetMaxModel(this.CardID);
                if (model2 != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$tjsj",
                        strVal = DrawItems.strToDate(model2.CheckDate, 1)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zrys",
                        strVal = model2.Doctor
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzqt",
                        strVal = model2.Other
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zz",
                        strVal = model2.Symptom
                    });

                    RecordsGeneralConditionModel model3 = new RecordsGeneralConditionDAL().GetModelByOutKey(model2.ID);
                    if (model3 != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$tw",
                            strVal = DrawItems.objToNumStr(model3.AnimalHeat, format)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ml",
                            strVal = DrawItems.objToNumStr(model3.PulseRate, 0)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$hxpl",
                            strVal = DrawItems.objToNumStr(model3.BreathRate, 0)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$gy",
                            strVal = DrawItems.objToNumStr(model3.LeftHeight, 0)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$dy",
                            strVal = DrawItems.objToNumStr(model3.LeftPre, 0)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$rgy",
                            strVal = DrawItems.objToNumStr(model3.RightHeight, 0)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$rdy",
                            strVal = DrawItems.objToNumStr(model3.RightPre, 0)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sg",
                            strVal = DrawItems.objToNumStr(model3.Height, 1)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$tz",
                            strVal = DrawItems.objToNumStr(model3.Weight, 1)
                        });
                        if (area == "乐陵")
                        {
                            if(model3.Waistline!=null)
                                list.Add(new ListValue
                                {
                                    strMark = "$yw",
                                    strVal = Convert.ToInt32(model3.Waistline).ToString()
                                });
                        }
                        else
                        list.Add(new ListValue
                        {
                            strMark = "$yw",
                            strVal = DrawItems.objToNumStr(model3.Waistline, 1)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$bmi",
                            strVal = DrawItems.objToNumStr(model3.BMI)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#lnpg",
                            strVal = model3.OldHealthStaus
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#lnpf",
                            strVal = model3.OldSelfCareability
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$lnrzzf",
                            strVal = DrawItems.objToNumStr(model3.InterScore, format)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#lnrz",
                            strVal = model3.OldRecognise
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$lnqgzf",
                            strVal = DrawItems.objToNumStr(model3.GloomyScore, format)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#lnqg",
                            strVal = model3.OldEmotion
                        });
                    }

                    RecordsLifeStyleModel model4 = new RecordsLifeStyleBLL().GetModelByOutKey(model2.ID);
                    string strtyfs = "";
                    if (model4 != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$yjqt",
                            strVal = model4.DrinkTypeOther
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xyl",
                            strVal = DrawItems.objToNumStr(model4.SmokeDayNum, format)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xynl",
                            strVal = DrawItems.objToNumStr(model4.SmokeAgeStart, 0)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$jynl",
                            strVal = DrawItems.objToNumStr(model4.SmokeAgeForbiddon, 0)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#typl",
                            strVal = model4.ExerciseRate
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$tysj",
                            strVal = DrawItems.objToNumStr(model4.ExerciseTimes, 0)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#ysxg",
                            strVal = model4.DietaryHabit
                        });
                        if (!string.IsNullOrEmpty(model4.ExerciseExistense))
                        {
                            foreach (char c in model4.ExerciseExistense)
                            {
                                switch (c)
                                {
                                    case '1':
                                        strtyfs = strtyfs + "散步；";
                                        break;
                                    case '2':
                                        strtyfs = strtyfs + "跑步；";
                                        break;
                                    case '3':
                                        strtyfs = strtyfs + "广场舞；";
                                        break;
                                    default: break;
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(model4.ExerciseExistenseOther))
                        {
                            strtyfs = strtyfs + model4.ExerciseExistenseOther + "；";
                        }

                        list.Add(new ListValue
                        {
                            strMark = "$tyfs",
                            strVal = strtyfs
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$tyn",
                            strVal = DrawItems.objToNumStr(model4.ExcisepersistTime, format)
                        });
                        if (!string.IsNullOrEmpty(model4.SmokeCondition))
                        {
                            list.Add(new ListValue
                            {
                                strMark = "#xyqk",
                                strVal = model4.SmokeCondition
                            });
                        }
                        list.Add(new ListValue
                        {
                            strMark = "#yjpl",
                            strVal = model4.DrinkRate
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$yjl",
                            strVal = DrawItems.objToNumStr(model4.DayDrinkVolume, format)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#yjjj",
                            strVal = model4.IsDrinkForbiddon
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$jjnl",
                            strVal = DrawItems.objToNumStr(model4.ForbiddonAge, 0)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$yjnl",
                            strVal = DrawItems.objToNumStr(model4.DrinkStartAge, 0)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#yjzj",
                            strVal = model4.DrinkThisYear
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#yjzl",
                            strVal = model4.DrinkType
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zyfc",
                            strVal = model4.Dust
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$zfcqt",
                            strVal = model4.DustProtectEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#zyg",
                            strVal = model4.CareerHarmFactorHistory
                        });
                        if (!string.IsNullOrEmpty(model4.CareerHarmFactorHistory) && model4.CareerHarmFactorHistory == "2")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "#zyf",
                                strVal = model4.DustProtect
                            });
                            list.Add(new ListValue
                            {
                                strMark = "#zyx",
                                strVal = model4.RadiogenProtect
                            });
                            list.Add(new ListValue
                            {
                                strMark = "#zyp",
                                strVal = model4.PhysicalProtect
                            });
                            list.Add(new ListValue
                            {
                                strMark = "#zyh",
                                strVal = model4.ChemProtect
                            });
                            list.Add(new ListValue
                            {
                                strMark = "#zyq",
                                strVal = model4.OtherProtect
                            });
                        }
                        list.Add(new ListValue
                        {
                            strMark = "$zyfs",
                            strVal = model4.Radiogen
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$zfsqt",
                            strVal = model4.RadiogenProtectEx
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zywl",
                            strVal = model4.Physical
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$zwlqt",
                            strVal = model4.PhysicalProtectEx
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zyhx",
                            strVal = model4.Chem
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zhxqt",
                            strVal = model4.ChemProtectEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$zyqt",
                            strVal = model4.Other
                        });

                        list.Add(new ListValue
                        {
                            strMark = "$zqqt",
                            strVal = model4.OtherProtectEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$zygz",
                            strVal = model4.WorkType
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$cysj",
                            strVal = DrawItems.objToNumStr(model4.WorkTime, 0)
                        });
                    }
                    RecordsVisceraFunctionModel model5 = new RecordsVisceraFunctionDAL().GetModelByOutKey(model2.ID);
                    if (model5 != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$lsl",
                            strVal = DrawItems.objToNumStr(model5.LeftView, 1)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#zqtl",
                            strVal = model5.Listen
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$rsl",
                            strVal = DrawItems.objToNumStr(model5.RightView, 1)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#zqyd",
                            strVal = model5.SportFunction
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$lslj",
                            strVal = DrawItems.objToNumStr(model5.LeftEyecorrect, 1)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#kqyb",
                            strVal = model5.Pharyngeal
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#kqcl",
                            strVal = model5.ToothResides
                        });
                        if (!string.IsNullOrEmpty(model5.ToothResides))
                        {
                            char[] array = new char[] { ',' };
                            foreach (string str in model5.ToothResides.Split(array))
                            {
                                int num2;
                                if (int.TryParse(str, out num2))
                                {
                                    switch (num2)
                                    {
                                        case 1: break;
                                        case 2:
                                            if (!string.IsNullOrEmpty(model5.HypodontiaEx))
                                            {
                                                //if (model5.HypodontiaEx.Contains("全口"))
                                                //{
                                                //    list.AddRange(DrawItems.lsCheck("1", "qqk", 3));
                                                //}
                                                //else
                                                //{
                                                char[] separator = new char[] { '#' };
                                                int num = 0;
                                                foreach (string str2 in model5.HypodontiaEx.Split(separator))
                                                {
                                                    num++;
                                                    switch (num)
                                                    {
                                                        case 1:
                                                            list.Add(new ListValue
                                                            {
                                                                strMark = "$quezs",
                                                                strVal = str2
                                                            }); break;
                                                        case 2:
                                                            list.Add(new ListValue
                                                            {
                                                                strMark = "$queys",
                                                                strVal = str2
                                                            }); break;
                                                        case 3:
                                                            list.Add(new ListValue
                                                            {
                                                                strMark = "$quezx",
                                                                strVal = str2
                                                            }); break;

                                                        case 4:
                                                            list.Add(new ListValue
                                                            {
                                                                strMark = "$queyx",
                                                                strVal = str2
                                                            }); break;
                                                        default: break;
                                                    }
                                                }
                                                //}
                                            }
                                            break;
                                        case 3:
                                            if (!string.IsNullOrEmpty(model5.SaprodontiaEx))
                                            {
                                                //if (model5.SaprodontiaEx.Contains("全口"))
                                                //{
                                                //    list.AddRange(DrawItems.lsCheck("2", "qqk", 3));
                                                //}
                                                //else
                                                //{
                                                char[] separator = new char[] { '#' };
                                                int num = 0;
                                                foreach (string str2 in model5.SaprodontiaEx.Split(separator))
                                                {
                                                    num++;
                                                    switch (num)
                                                    {
                                                        case 1:
                                                            list.Add(new ListValue
                                                            {
                                                                strMark = "$juczs",
                                                                strVal = str2
                                                            }); break;
                                                        case 2:
                                                            list.Add(new ListValue
                                                            {
                                                                strMark = "$jucys",
                                                                strVal = str2
                                                            }); break;
                                                        case 3:
                                                            list.Add(new ListValue
                                                            {
                                                                strMark = "$juczx",
                                                                strVal = str2
                                                            }); break;
                                                        case 4:
                                                            list.Add(new ListValue
                                                            {
                                                                strMark = "$jucyx",
                                                                strVal = str2
                                                            }); break;
                                                        default: break;
                                                    }
                                                }
                                                //}
                                            }
                                            break;
                                        case 4:
                                            if (!string.IsNullOrEmpty(model5.DentureEx))
                                            {
                                                if (model5.DentureEx.Contains("全口"))
                                                {
                                                    list.AddRange(DrawItems.lsCheck("3", "qqk", 3));
                                                }
                                                else
                                                {
                                                    char[] separator = new char[] { '#' };
                                                    int num = 0;
                                                    foreach (string str2 in model5.DentureEx.Split(separator))
                                                    {
                                                        num++;
                                                        switch (num)
                                                        {
                                                            case 1:
                                                                list.Add(new ListValue
                                                                {
                                                                    strMark = "$yiczs",
                                                                    strVal = str2
                                                                }); break;
                                                            case 2:
                                                                list.Add(new ListValue
                                                                {
                                                                    strMark = "$yicys",
                                                                    strVal = str2
                                                                }); break;
                                                            case 3:
                                                                list.Add(new ListValue
                                                                {
                                                                    strMark = "$yiczx",
                                                                    strVal = str2
                                                                }); break;
                                                            case 4:
                                                                list.Add(new ListValue
                                                                {
                                                                    strMark = "$yicyx",
                                                                    strVal = str2
                                                                }); break;
                                                            default: break;
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        default: break;
                                    }
                                }
                            }
                        }

                        list.Add(new ListValue
                        {
                            strMark = "$rslj",
                            strVal = DrawItems.objToNumStr(model5.RightEyecorrect, 1)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#kqkc",
                            strVal = model5.Lips
                        });
                    }
                    RecordsPhysicalExamModel model6 = new RecordsPhysicalExamDAL().GetModelByOutKey(model2.ID);
                    if (model6 != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$ctydqt",
                            strVal = model6.EyeRoundEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#ctyd",
                            strVal = model6.EyeRound
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#ctpf",
                            strVal = model6.Skin
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#ctgm",
                            strVal = model6.Sclere
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#ctlbj",
                            strVal = model6.Lymph
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#ctft",
                            strVal = model6.BarrelChest
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#ctfh",
                            strVal = model6.BreathSounds
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#ctfl",
                            strVal = model6.Rale
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ctxlcs",
                            strVal = model6.HeartRate
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#xzxl",
                            strVal = model6.HeartRhythm
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#xzzy",
                            strVal = model6.Noise
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#fbbk",
                            strVal = model6.EnclosedMass
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#xzsz",
                            strVal = model6.Edema
                        });
                        if(!string.IsNullOrEmpty(model6.FootBack)&&model6.FootBack!="0")
                        list.Add(new ListValue
                        {
                            strMark = "#zmd",
                            strVal = model6.FootBack
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#gmzj",
                            strVal = model6.Anus
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#rx",
                            strVal = model6.Breast
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#fkwy",
                            strVal = model6.Vulva
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#fkyd",
                            strVal = model6.Vagina
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#fkgj",
                            strVal = model6.CervixUteri
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#fkgt",
                            strVal = model6.Corpus
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#fkfj",
                            strVal = model6.Attach
                        });
                        list.Add(new ListValue
                        {
                            strMark = "%ctqt",
                            strVal = model6.Other
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#fbyt",
                            strVal = model6.PressPain
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#fbgd",
                            strVal = model6.Liver
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#fbpd",
                            strVal = model6.Spleen
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#fbhy",
                            strVal = model6.Voiced
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ctpfqt",
                            strVal = model6.SkinEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ctgmqt",
                            strVal = model6.SclereEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ctlbqt",
                            strVal = model6.LymphEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$rxq",
                            strVal = model6.BreastEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$gmzjqt",
                            strVal = model6.AnusEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ctfhqt",
                            strVal = model6.BreathSoundsEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ctflqt",
                            strVal = model6.RaleEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ctzyqt",
                            strVal = model6.NoiseEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$fkgjyc",
                            strVal = model6.CervixUteriEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$fkgtyc",
                            strVal = model6.CorpusEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$fkfjyc",
                            strVal = model6.AttachEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$fkwyyc",
                            strVal = model6.VulvaEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$fkydyc",
                            strVal = model6.VaginaEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$fbytqt",
                            strVal = model6.PressPainEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$fbgdqt",
                            strVal = model6.LiverEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$fbpdqt",
                            strVal = model6.SpleenEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$fbhyqt",
                            strVal = model6.VoicedEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$fbbkqt",
                            strVal = model6.EnclosedMassEx
                        });
                    }
                    RecordsAssistCheckModel model7 = new RecordsAssistCheckBLL().GetModelByOutKey(model2.ID);
                    if (model7 != null)
                    {
                        string xx = model7.BloodType;
                        if (string.IsNullOrEmpty(xx))
                        {
                            xx = model.BloodType;
                        }
                        if (!string.IsNullOrEmpty(xx))
                        {
                            switch (xx)
                            {
                                case "1": strXuex = "A型"; break;
                                case "2": strXuex = "B型"; break;
                                case "3": strXuex = "O型"; break;
                                case "4": strXuex = "AB型"; break;
                                default: break;
                            }
                        }
                        if (!string.IsNullOrEmpty(model7.RH))
                        {
                            switch (model7.RH)
                            {
                                case "1": strRH = "否"; break;
                                case "2": strRH = "是"; break;
                                case "3": strRH = "不详"; break;
                                default: break;
                            }
                        }
                        list.Add(new ListValue
                        {
                            strMark = "$xuex",
                            strVal = strXuex
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$RH",
                            strVal = strRH
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#xbx",
                            strVal = model7.CHESTX
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#bc",
                            strVal = model7.BCHAO
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#bcqt",
                            strVal = model7.BCHAOther
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xcqt",
                            strVal = model7.BloodOther
                        });
                        if (area.Equals("济宁"))
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$ncqt",
                                strVal = GetExNiaoPlus(model7.UrineOther)
                            });
                        }
                        else
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$ncqt",
                                strVal = model7.UrineOther
                            });
                        }
                        list.Add(new ListValue
                        {
                            strMark = "$fzjcqt",
                            strVal = model7.Other
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#gjtp",
                            strVal = model7.CERVIX
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xdyc",
                            strVal = model7.ECGEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xbxyc",
                            strVal = model7.CHESTXEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$bcyc",
                            strVal = model7.BCHAOEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$bcqtyc",
                            strVal = model7.BCHAOtherEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$gjtpyc",
                            strVal = model7.CERVIXEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$kfxt2",
                            strVal = model7.FPGDL.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$kfxt",
                            strVal = model7.FPGL.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xcdb",
                            strVal = model7.HB.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xcbx",
                            strVal = model7.WBC.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xcxb",
                            strVal = model7.PLT.ToString()
                        });
                        if (area.Equals("济宁"))
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$ncdb",
                                strVal = GetExNiaoPlus(model7.PRO)
                            });
                            list.Add(new ListValue
                            {
                                strMark = "$ncnt",
                                strVal = GetExNiaoPlus(model7.GLU)
                            });
                            list.Add(new ListValue
                            {
                                strMark = "$nctt",
                                strVal = GetExNiaoPlus(model7.KET)
                            });
                            list.Add(new ListValue
                            {
                                strMark = "$ncqx",
                                strVal = GetExNiaoPlus(model7.BLD)
                            });
                        }
                        else
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$ncdb",
                                strVal = model7.PRO
                            });
                            list.Add(new ListValue
                            {
                                strMark = "$ncnt",
                                strVal = model7.GLU
                            });
                            list.Add(new ListValue
                            {
                                strMark = "$nctt",
                                strVal = model7.KET
                            });
                            list.Add(new ListValue
                            {
                                strMark = "$ncqx",
                                strVal = model7.BLD
                            });
                        }

                        list.Add(new ListValue
                        {
                            strMark = "#xdt",
                            strVal = model7.ECG
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$HCY",
                            strVal = model7.HCY.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$nwdb",
                            strVal = model7.ALBUMIN.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#dbqx",
                            strVal = model7.FOB
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$thhdb",
                            strVal = model7.HBALC.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#ygbm",
                            strVal = model7.HBSAG
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xzgm",
                            strVal = model7.HeiCho.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xzdm",
                            strVal = model7.LowCho.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xzgy",
                            strVal = model7.TG.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xzzd",
                            strVal = model7.TC.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sgxn",
                            strVal = model7.HYPE.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sgxj",
                            strVal = model7.PC.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sgsd",
                            strVal = model7.BUN.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sgxq",
                            strVal = model7.SCR.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ggjh",
                            strVal = model7.CB.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ggzd",
                            strVal = model7.TBIL.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ggbz",
                            strVal = model7.SGPT.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ggxq",
                            strVal = model7.GOT.ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ggbd",
                            strVal = model7.BP.ToString()
                        });
                    }
                    RecordsMediPhysDistModel model8 = new RecordsMediPhysDistDAL().GetModelByOutKey(model2.ID);
                    if (model8 != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "#zyxy",
                            strVal = model8.BloodStasis
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#zyqy",
                            strVal = model8.QiConstraint
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#zysr",
                            strVal = model8.Muggy
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#zyts",
                            strVal = model8.PhlegmDamp
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#zydz",
                            strVal = model8.Yin
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#zyyx",
                            strVal = model8.Yang
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#zyqx",
                            strVal = model8.Faint
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#zyph",
                            strVal = model8.Mild
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#zytb",
                            strVal = model8.Characteristic
                        });
                    }
                    RecordsHealthQuestionModel model9 = new RecordsHealthQuestionDAL().GetModelByOutKey(model2.ID);
                    if (model9 != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "#sjxt",
                            strVal = model9.NerveDis
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#qtxt",
                            strVal = model9.ElseDis
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#ybjb",
                            strVal = model9.EyeDis
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#xzb",
                            strVal = model9.HeartDis
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#szb",
                            strVal = model9.RenalDis
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#nxg",
                            strVal = model9.BrainDis
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$nxgyc",
                            strVal = model9.BrainOther
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$szbyc",
                            strVal = model9.RenalOther
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xzbyc",
                            strVal = model9.HeartOther
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ybbqt",
                            strVal = model9.EyeOther
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sjxtqt",
                            strVal = model9.NerveOther
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$qtxtjb",
                            strVal = model9.ElseOther
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#xgj",
                            strVal = model9.VesselDis
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xgbqt",
                            strVal = model9.VesselOther
                        });
                    }
                    DataSet list2 = new RecordsHospitalHistoryDAL().GetList(string.Format(" IDCardNo='{0}' and OutKey={1}", this.CardID, model2.ID));
                    if (list2 != null && list2.Tables.Count > 0)
                    {
                        list.AddRange(this.getHospitalHistory(list2.Tables[0]));
                    }
                    DataSet list3 = new RecordsFamilyBedHistoryBLL().GetList(string.Format(" IDCardNo='{0}' and OutKey={1}", this.CardID, model2.ID));
                    if (list3 != null && list3.Tables.Count > 0)
                    {
                        list.AddRange(this.getFamilyBedHistory(list3.Tables[0]));
                    }
                    DataSet list4 = new RecordsMedicationDAL().GetList(string.Format(" IDCardNo='{0}' and OutKey={1}", this.CardID, model2.ID));
                    if (list4 != null && list4.Tables.Count > 0)
                    {
                        list.AddRange(this.getMedication(list4.Tables[0]));
                    }
                    DataSet list5 = new RecordsInoculationHistoryDAL().GetList(string.Format(" IDCardNo='{0}' and OutKey={1}", this.CardID, model2.ID));
                    if (list5 != null && list5.Tables.Count > 0)
                    {
                        list.AddRange(this.getInoculationHistory(list5.Tables[0]));
                    }
                    RecordsAssessmentGuideModel model10 = new RecordsAssessmentGuideDAL().GetModelByOutKey(model2.ID);
                    if (model10 != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "#jkpj",
                            strVal = model10.IsNormal
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$wxjyqt",
                            strVal = model10.Other
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#jkzd",
                            strVal = model10.HealthGuide
                        });

                        list.Add(new ListValue
                        {
                            strMark = "#jkzd",
                            strVal = model10.HealthGuide
                        });

                        string arm = "";
                        if (!string.IsNullOrEmpty(model10.Arm))
                        {
                            arm = model10.Arm + "KG";
                        }
                        list.Add(new ListValue
                        {
                            strMark = "$wxjtz",
                            strVal = arm
                        });
                        list.Add(new ListValue
                        {
                            strMark = "%jkpjyc4",
                            strVal = model10.Exception4
                        });
                        list.Add(new ListValue
                        {
                            strMark = "%jkpjyc3",
                            strVal = model10.Exception3
                        });
                        list.Add(new ListValue
                        {
                            strMark = "%jkpjyc2",
                            strVal = model10.Exception2
                        });
                        // 聊城东昌府区
                        list.Add(new ListValue
                        {
                            strMark = "%jkpjyc5",
                            strVal = model10.Exception5
                        });
                        list.Add(new ListValue
                        {
                            strMark = "%jkpjyc6",
                            strVal = model10.Exception6
                        });
                        if (area.Equals("淄博") && !string.IsNullOrEmpty(model10.IsNormal) && model10.IsNormal == "1")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "%jkpjyc1",
                                strVal = "无"
                            });
                        }
                        else
                        {
                            list.Add(new ListValue
                            {
                                strMark = "%jkpjyc1",
                                strVal = model10.Exception1
                            });
                        }
                        list.Add(new ListValue
                        {
                            strMark = "#wxkz",
                            strVal = model10.DangerControl
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$wxjyym",
                            strVal = model10.VaccineAdvice
                        });
                    }
                    
                    if (!area.Equals("菏泽") && !area.Equals("济宁") && !area.Equals("聊城") && !area.Equals("泰安"))
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$fksj",
                            strVal = DrawItems.strToDate(model2.CheckDate.Value.AddDays(3), 1)
                        });
                    }

                    RecordsSignatureModel modelSign = new RecordsSignatureBLL().GetModelByOutKey(model2.ID, model2.IDCardNo);

                    if (modelSign != null)
                    {
                        if (modelSign.FeedbackDate.HasValue && model != null)
                        {
                            list.Add(new ListValue
                            {
                                strMark = "&jssg",
                                strVal = SignPath + model.IDCardNo + "_" + Convert.ToDateTime(model2.CheckDate).ToString("yyyyMMdd") + "_J.png"
                            });

                            // 菏泽，济宁，聊城，泰安 反馈时间取医生签名中的反馈时间
                            if (area.Equals("菏泽") || area.Equals("济宁") || area.Equals("聊城") || area.Equals("泰安"))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "$fksj",
                                    strVal = DrawItems.strToDate(modelSign.FeedbackDate, 1)
                                });
                            }

                            #region 医师签名、家属签名、指纹

                            // 聊城东昌府区
                            if (this.community.Equals("聊城东昌府区") || area.Equals("禹城") || area.Equals("泰安") || area.Equals("菏泽") || area.Equals("肥城"))
                            {
                                // 看体检日期下签名是否存在
                                if (model2 != null && model2.CheckDate.HasValue)
                                {
                                    if (File.Exists(SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor.png"))
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "&zhengzqm",
                                            strVal = SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor.png"
                                        });
                                    }
                                    else
                                    {
                                        // 体检日期中不存在签名 就取外层签名
                                        list.Add(new ListValue
                                        {
                                            strMark = "&zhengzqm",
                                            strVal = SignPathYear + "_Doctor.png"
                                        });
                                    }

                                    if (File.Exists(SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor1.png"))
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "&ybqkqm",
                                            strVal = SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor1.png"
                                        });
                                    }
                                    else
                                    {
                                        // 体检日期中不存在签名 就取外层签名
                                        list.Add(new ListValue
                                        {
                                            strMark = "&ybqkqm",
                                            strVal = SignPathYear + "_Doctor1.png"
                                        });
                                    }

                                    if (File.Exists(SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor3.png"))
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "&shfsqm",
                                            strVal = SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor3.png"
                                        });
                                    }
                                    else
                                    {
                                        // 体检日期中不存在签名 就取外层签名
                                        list.Add(new ListValue
                                        {
                                            strMark = "&shfsqm",
                                            strVal = SignPathYear + "_Doctor3.png"
                                        });
                                    }

                                    if (File.Exists(SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor4.png"))
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "&zqgnqm",
                                            strVal = SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor4.png"
                                        });
                                    }
                                    else
                                    {
                                        // 体检日期中不存在签名 就取外层签名
                                        list.Add(new ListValue
                                        {
                                            strMark = "&zqgnqm",
                                            strVal = SignPathYear + "_Doctor4.png"
                                        });
                                    }

                                    if (File.Exists(SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor5.png"))
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "&ctqm",
                                            strVal = SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor5.png"
                                        });
                                    }
                                    else
                                    {
                                        // 体检日期中不存在签名 就取外层签名
                                        list.Add(new ListValue
                                        {
                                            strMark = "&ctqm",
                                            strVal = SignPathYear + "_Doctor5.png"
                                        });
                                    }

                                    if (File.Exists(SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor6.png"))
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "&fzjcqm",
                                            strVal = SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor6.png"
                                        });
                                    }
                                    else
                                    {
                                        // 体检日期中不存在签名 就取外层签名
                                        list.Add(new ListValue
                                        {
                                            strMark = "&fzjcqm",
                                            strVal = SignPathYear + "_Doctor6.png"
                                        });
                                    }

                                    if (File.Exists(SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor7.png"))
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "&xcwtqm",
                                            strVal = SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor7.png"
                                        });
                                    }
                                    else
                                    {
                                        // 体检日期中不存在签名 就取外层签名
                                        list.Add(new ListValue
                                        {
                                            strMark = "&xcwtqm",
                                            strVal = SignPathYear + "_Doctor7.png"
                                        });
                                    }

                                    if (File.Exists(SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor8.png"))
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "&zyzlqm",
                                            strVal = SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor8.png"
                                        });
                                    }
                                    else
                                    {
                                        // 体检日期中不存在签名 就取外层签名
                                        list.Add(new ListValue
                                        {
                                            strMark = "&zyzlqm",
                                            strVal = SignPathYear + "_Doctor8.png"
                                        });
                                    }

                                    if (File.Exists(SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor9.png"))
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "&yyqkqm",
                                            strVal = SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor9.png"
                                        });
                                    }
                                    else
                                    {
                                        // 体检日期中不存在签名 就取外层签名
                                        list.Add(new ListValue
                                        {
                                            strMark = "&yyqkqm",
                                            strVal = SignPathYear + "_Doctor9.png"
                                        });
                                    }

                                    if (File.Exists(SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor10.png"))
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "&jkpjqm",
                                            strVal = SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor10.png"
                                        });
                                    }
                                    else
                                    {
                                        // 体检日期中不存在签名 就取外层签名
                                        list.Add(new ListValue
                                        {
                                            strMark = "&jkpjqm",
                                            strVal = SignPathYear + "_Doctor10.png"
                                        });
                                    }

                                    if (File.Exists(SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor11.png"))
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "&jkzdqm",
                                            strVal = SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor11.png"
                                        });
                                    }
                                    else
                                    {
                                        // 体检日期中不存在签名 就取外层签名
                                        list.Add(new ListValue
                                        {
                                            strMark = "&jkzdqm",
                                            strVal = SignPathYear + "_Doctor11.png"
                                        });
                                    }

                                    if (File.Exists(SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor16.png"))
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "&xdtqm",
                                            strVal = SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor16.png"
                                        });
                                    }
                                    else
                                    {
                                        // 体检日期中不存在签名 就取外层签名
                                        list.Add(new ListValue
                                        {
                                            strMark = "&xdtqm",
                                            strVal = SignPathYear + "_Doctor16.png"
                                        });
                                    }

                                    if (File.Exists(SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor17.png"))
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "&fbbcqm",
                                            strVal = SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor17.png"
                                        });
                                    }
                                    else
                                    {
                                        // 体检日期中不存在签名 就取外层签名
                                        list.Add(new ListValue
                                        {
                                            strMark = "&fbbcqm",
                                            strVal = SignPathYear + "_Doctor17.png"
                                        });
                                    }

                                    if (File.Exists(SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor19.png"))
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "&qttqm",
                                            strVal = SignPathYear + Convert.ToDateTime(model2.CheckDate).ToString("yyyy-MM-dd") + "//_Doctor19.png"
                                        });
                                    }
                                    else
                                    {
                                        // 体检日期中不存在签名 就取外层签名
                                        list.Add(new ListValue
                                        {
                                            strMark = "&qttqm",
                                            strVal = SignPathYear + "_Doctor19.png"
                                        });
                                    }
                                }
                                else
                                {
                                    // 体检日期中不存在签名 就取外层签名
                                    list.Add(new ListValue
                                    {
                                        strMark = "&zhengzqm",
                                        strVal = SignPathYear + "_Doctor.png"
                                    });
                                    list.Add(new ListValue
                                    {
                                        strMark = "&ybqkqm",
                                        strVal = SignPathYear + "_Doctor1.png"
                                    });
                                    list.Add(new ListValue
                                    {
                                        strMark = "&shfsqm",
                                        strVal = SignPathYear + "_Doctor3.png"
                                    });
                                    list.Add(new ListValue
                                    {
                                        strMark = "&zqgnqm",
                                        strVal = SignPathYear + "_Doctor4.png"
                                    });
                                    list.Add(new ListValue
                                    {
                                        strMark = "&ctqm",
                                        strVal = SignPathYear + "_Doctor5.png"
                                    });
                                    list.Add(new ListValue
                                    {
                                        strMark = "&fzjcqm",
                                        strVal = SignPathYear + "_Doctor6.png"
                                    });
                                    list.Add(new ListValue
                                    {
                                        strMark = "&xcwtqm",
                                        strVal = SignPathYear + "_Doctor7.png"
                                    });
                                    list.Add(new ListValue
                                    {
                                        strMark = "&zyzlqm",
                                        strVal = SignPathYear + "_Doctor8.png"
                                    });
                                    list.Add(new ListValue
                                    {
                                        strMark = "&yyqkqm",
                                        strVal = SignPathYear + "_Doctor9.png"
                                    });
                                    list.Add(new ListValue
                                    {
                                        strMark = "&jkpjqm",
                                        strVal = SignPathYear + "_Doctor10.png"
                                    });
                                    list.Add(new ListValue
                                    {
                                        strMark = "&jkzdqm",
                                        strVal = SignPathYear + "_Doctor11.png"
                                    });
                                    list.Add(new ListValue
                                    {
                                        strMark = "&xdtqm",
                                        strVal = SignPathYear + "_Doctor16.png"
                                    });
                                    list.Add(new ListValue
                                    {
                                        strMark = "&fbbcqm",
                                        strVal = SignPathYear + "_Doctor17.png"
                                    });
                                    list.Add(new ListValue
                                    {
                                        strMark = "&qttqm",
                                        strVal = SignPathYear + "_Doctor19.png"
                                    });
                                }
                            }
                            else
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "&zhengzqm",
                                    strVal = SignPathYear + "_Doctor.png"
                                });
                                list.Add(new ListValue
                                {
                                    strMark = "&ybqkqm",
                                    strVal = SignPathYear + "_Doctor1.png"
                                });
                                list.Add(new ListValue
                                {
                                    strMark = "&shfsqm",
                                    strVal = SignPathYear + "_Doctor3.png"
                                });
                                list.Add(new ListValue
                                {
                                    strMark = "&zqgnqm",
                                    strVal = SignPathYear + "_Doctor4.png"
                                });
                                list.Add(new ListValue
                                {
                                    strMark = "&ctqm",
                                    strVal = SignPathYear + "_Doctor5.png"
                                });
                                list.Add(new ListValue
                                {
                                    strMark = "&fzjcqm",
                                    strVal = SignPathYear + "_Doctor6.png"
                                });
                                list.Add(new ListValue
                                {
                                    strMark = "&xcwtqm",
                                    strVal = SignPathYear + "_Doctor7.png"
                                });
                                list.Add(new ListValue
                                {
                                    strMark = "&zyzlqm",
                                    strVal = SignPathYear + "_Doctor8.png"
                                });
                                list.Add(new ListValue
                                {
                                    strMark = "&yyqkqm",
                                    strVal = SignPathYear + "_Doctor9.png"
                                });
                                list.Add(new ListValue
                                {
                                    strMark = "&jkpjqm",
                                    strVal = SignPathYear + "_Doctor10.png"
                                });
                                list.Add(new ListValue
                                {
                                    strMark = "&jkzdqm",
                                    strVal = SignPathYear + "_Doctor11.png"
                                });
                                list.Add(new ListValue
                                {
                                    strMark = "&xdtqm",
                                    strVal = SignPathYear + "_Doctor16.png"
                                });
                                list.Add(new ListValue
                                {
                                    strMark = "&fbbcqm",
                                    strVal = SignPathYear + "_Doctor17.png"
                                });
                                list.Add(new ListValue
                                {
                                    strMark = "&qttqm",
                                    strVal = SignPathYear + "_Doctor19.png"
                                });
                            }

                            #endregion

                            if (this.community.Equals("聊城东昌府区") || area.Equals("菏泽") || area.Equals("泰安") || area.Equals("肥城"))
                            {
                                //本人签名
                                if (File.Exists(SignPath + model.IDCardNo + "_" + Convert.ToDateTime(model2.CheckDate).ToString("yyyyMMdd") + "_B.png"))
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "&brsg",
                                        strVal = SignPath + model.IDCardNo + "_" + Convert.ToDateTime(model2.CheckDate).ToString("yyyyMMdd") + "_B.png"
                                    });
                                }

                                string date = DrawItems.strToDate(model2.CheckDate, 5);
                                if (File.Exists(FingerPath + model.IDCardNo + date + "_Finger.png"))
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "&zwqz",
                                        strVal = FingerPath + model.IDCardNo + date + "_Finger.png"
                                    });
                                }
                            }
                            else
                            {
                                //本人签名
                                if (File.Exists(SignPath + model.IDCardNo + "_" + Convert.ToDateTime(model2.CheckDate).ToString("yyyyMMdd") + "_B.png"))
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "&brsg",
                                        strVal = SignPath + model.IDCardNo + "_" + Convert.ToDateTime(model2.CheckDate).ToString("yyyyMMdd") + "_B.png"
                                    });
                                }
                                else
                                {
                                    string date = DrawItems.strToDate(model2.CheckDate, 5);

                                    list.Add(new ListValue
                                    {
                                        strMark = "&brsg",
                                        strVal = FingerPath + model.IDCardNo + date + "_Finger.png"
                                    });
                                }
                            }

                            //反馈人签字
                            if (File.Exists(SignPath + model.IDCardNo + "_" + Convert.ToDateTime(model2.CheckDate).ToString("yyyyMMdd") + "_F.png"))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "&fkrsg",
                                    strVal = SignPath + model.IDCardNo + "_" + Convert.ToDateTime(model2.CheckDate).ToString("yyyyMMdd") + "_F.png"
                                });
                            }
                            else
                            {
                                string strPath13 = SignPathYear + "_Doctor13.png";

                                if (area.Equals("菏泽") || community.Equals("聊城东昌府区") || area.Equals("禹城") || area.Equals("泰安") || area.Equals("肥城"))
                                {
                                    string date = model2.CheckDate.Value.ToString("yyyy-MM-dd");
                                    string path = string.Format("{0}{1}//_Doctor13.png", SignPathYear, date);
                                    if (area.Equals("禹城"))//禹城判断体检日期下是否有反馈人签字，没有取公用的
                                    {
                                        if (!File.Exists(path))
                                        {
                                            path= string.Format("{0}/_Doctor13.png", SignPathYear);
                                        }
                                    }

                                    strPath13 = path;
                                }

                                list.Add(new ListValue
                                {
                                    strMark = "&fkrsg",
                                    strVal = strPath13
                                });
                            }

                            if (this.community.Equals("顾官屯卫生院"))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "&fzjcqm2",
                                    strVal = SignPathYear + "_Doctor6.png"
                                });
                            }
                            if (area.EndsWith("菏泽"))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "&fzjcqm2",
                                    strVal = SignPathYear + "_Doctor21.png"
                                });
                                list.Add(new ListValue
                                {
                                    strMark = "&fzjcqm3",
                                    strVal = SignPathYear + "_Doctor21.png"
                                });
                            }
                        }
                    }
                }

                return DrawItems.setPage("printXps\\" + PrintName, list);
            }

            return null;
        }

        public List<ListValue> getHospitalHistory(DataTable dt)
        {
            List<ListValue> list = new List<ListValue>();
            for (int i = 0; i < 2; i++)
            {
                if (i < dt.Rows.Count)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$zysr" + (i + 1).ToString(),
                        strVal = DrawItems.strToDate(dt.Rows[i]["InHospitalDate"], 1)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zysc" + (i + 1).ToString(),
                        strVal = DrawItems.strToDate(dt.Rows[i]["OutHospitalDate"], 1)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zyyy" + (i + 1).ToString(),
                        strVal = DrawItems.objToStr(dt.Rows[i]["reason"])
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zyjg" + (i + 1).ToString(),
                        strVal = DrawItems.objToStr(dt.Rows[i]["hospitalname"])
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zyba" + (i + 1).ToString(),
                        strVal = DrawItems.objToStr(dt.Rows[i]["illcasenum"])
                    });
                }
            }
            return list;
        }

        public List<ListValue> getFamilyBedHistory(DataTable dt)
        {
            List<ListValue> list = new List<ListValue>();
            for (int i = 0; i < 2; i++)
            {
                if (i < dt.Rows.Count)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$jzbj" + (i + 1).ToString(),
                        strVal = DrawItems.strToDate(dt.Rows[i]["InHospitalDate"], 1)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$jzbc" + (i + 1).ToString(),
                        strVal = DrawItems.strToDate(dt.Rows[i]["outhospitaldate"], 1)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$jzyy" + (i + 1).ToString(),
                        strVal = DrawItems.objToStr(dt.Rows[i]["reasons"])
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$jzjg" + (i + 1).ToString(),
                        strVal = DrawItems.objToStr(dt.Rows[i]["hospitalname"])
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$jzba" + (i + 1).ToString(),
                        strVal = DrawItems.objToStr(dt.Rows[i]["illcasenums"])
                    });
                }
            }
            return list;
        }

        public List<ListValue> getMedication(DataTable dt)
        {
            List<ListValue> list = new List<ListValue>();
            for (int i = 0; i < 6; i++)
            {
                if (i < dt.Rows.Count)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$yymc" + (i + 1).ToString(),
                        strVal = DrawItems.objToStr(dt.Rows[i]["MEDICINALNAME"])
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$yyf" + (i + 1).ToString(),
                        strVal = DrawItems.objToStr(dt.Rows[i]["USEAGE"])
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$yyy" + (i + 1).ToString(),
                        strVal = DrawItems.objToStr(dt.Rows[i]["USENUM"])
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ysj" + (i + 1).ToString(),
                        strVal = DrawItems.objToStr(dt.Rows[i]["STARTTIME"])
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$fyyc" + (i + 1).ToString(),
                        strVal = DrawItems.objToStr(dt.Rows[i]["PILLDEPENDENCE"])
                    });
                }
            }
            return list;
        }

        private List<ListValue> getInoculationHistory(DataTable dt)
        {
            List<ListValue> list = new List<ListValue>();
            for (int i = 0; i < 3; i++)
            {
                if (i < dt.Rows.Count)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$fmmc" + (i + 1).ToString(),
                        strVal = DrawItems.objToStr(dt.Rows[i]["PILLNAME"])
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$fmrq" + (i + 1).ToString(),
                        strVal = DrawItems.strToDate(dt.Rows[i]["INOCULATIONDATE"], 1)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$fmjg" + (i + 1).ToString(),
                        strVal = DrawItems.objToStr(dt.Rows[i]["INOCULATIONHISTORY"])
                    });
                }
            }
            return list;
        }

        /// <summary>
        /// 将尿仪数据+1、+2改为+、++
        /// </summary>
        /// <param name="PRO"></param>
        /// <returns></returns>
        private string GetExNiaoPlus(string PRO)
        {
            if (string.IsNullOrEmpty(PRO))
            {
                return "";
            }
            PRO = PRO.Replace("+1", "+").Replace("+2", "++").Replace("+3", "+++").Replace("+4", "++++").Replace("+5", "+++++").Replace("+6", "++++++").Replace("+7", "+++++++").Replace("+8", "+++++++++");
            if (community == "小孟镇")
            {
                PRO = PRO.Replace("+-", "±");
            }
            return PRO;
        }
    }
}