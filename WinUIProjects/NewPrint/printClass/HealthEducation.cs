using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using printClass;
using KangShuoTech.DataAccessProjects.Model;
using System.Windows.Documents;
using System.Data;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.DAL;
using System.IO;
using System.Windows.Forms;
using KangShuoTech.Utilities.Common;

namespace ReportPrint
{
    public class HealthEducation : IGetReport
    {
        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "27个体化健康教育.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                DataSet list = new RecordsCustomerBaseInfoBLL().GetList(" IDCardNo='" + this.CardID + "'");

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
                string strsex = "", strage = "", strdrug = "";
                if (model.Sex != null)
                {
                    if (DrawItems.objToNumStr(model.Sex, 0) == "1")
                    {
                        strsex = "男";
                    }
                    if (DrawItems.objToNumStr(model.Sex, 0) == "2")
                    {
                        strsex = "女";
                    }
                    if (DrawItems.objToNumStr(model.Sex, 0) == "0")
                    {
                        strsex = "未知";
                    }
                    if (DrawItems.objToNumStr(model.Sex, 0) == "9")
                    {
                        strsex = "未说明";
                    }
                }
                TimeParser timeParser = new TimeParser();
                strage = timeParser.GetAge(model.Birthday);
                DateTime dtage;
                decimal dnow = 0, dage = 0;
                if (model.Birthday != null)
                {
                    dtage = Convert.ToDateTime(model.Birthday);
                    dnow = Convert.ToDecimal(DateTime.Today.ToString("yyyyMMdd"));
                    dage = Convert.ToDecimal(dtage.ToString("yyyyMMdd"));
                }
                if (!string.IsNullOrEmpty(model.DrugAllergic))
                {
                    foreach (char c in model.DrugAllergic)
                    {
                        if (c == '1')
                        {
                            strdrug = "无";
                            break;
                        }
                        else if (c == '2')
                        {
                            if (strdrug == "")
                            {
                                strdrug = "青霉素";
                            }
                            else
                            {
                                strdrug = strdrug + "," + "青霉素";
                            }
                        }
                        else if (c == '3')
                        {
                            if (strdrug == "")
                            {
                                strdrug = "磺胺";
                            }
                            else
                            {
                                strdrug = strdrug + "," + "磺胺";
                            }
                        }
                        else if (c == '4')
                        {
                            if (strdrug == "")
                            {
                                strdrug = "链霉素";
                            }
                            else
                            {
                                strdrug = strdrug + "," + "链霉素";
                            }
                        }
                        else if (c == '5')
                        {
                            if (strdrug == "")
                            {
                                strdrug = model.DrugAllergicOther;
                            }
                            else
                            {
                                strdrug = strdrug + "," + model.DrugAllergicOther;
                            }
                        }
                    }
                }
                list = new List<ListValue>
                {
                    new ListValue
                    {
                        strMark = "$name",
                        strVal = model.CustomerName
                    },
                    new ListValue
                    {
                        strMark = "$xb",
                        strVal = strsex
                    },
                    new ListValue
                    {
                        strMark = "$nl",
                        strVal = strage
                    },
                    new ListValue
                    {
                        strMark = "$gms",
                        strVal = strdrug
                    },
                    new ListValue
                    {
                        strMark = "$sfz",
                        strVal = model.IDCardNo
                    },
                    new ListValue
                    {
                        strMark = "$lxfs",
                        strVal = model.ContactPhone
                    },
                    new ListValue
                    {
                        strMark = "$jtzz",
                        strVal = model.Address
                    },
                    new ListValue
                    {
                        strMark = "$lxdh",
                        strVal = model.Phone
                    }
                };
                RecordsCustomerBaseInfoModel modelC = new RecordsCustomerBaseInfoBLL().GetMaxModel(this.CardID);
                if (modelC == null) modelC = new RecordsCustomerBaseInfoModel();

                if (modelC != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$tjrq",
                        strVal = DrawItems.strToDate(modelC.CheckDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zrys",
                        strVal = modelC.Doctor
                    });
                }

                OlderSelfCareabilityModel modelS = new OlderSelfCareabilityBLL().GetModel(this.CardID);
                if (modelS != null)
                {
                    OlderMedicineResultModel modelM = new OlderMedicineResultBLL().GetModel(this.CardID, modelS.ID);
                    string strqxy = "", strqtz = "", strtzzsjy = "";
                    int number = 1, count = 0;

                    if (modelM != null)
                    {
                        if (modelM.Mild == "1" && count < 3)
                        {
                            if (strqtz == "")
                            {
                                strqtz = "平和质";
                            }
                            else
                            {
                                strqtz = strqtz + "," + "平和质";
                            }
                            count++;
                        }
                        if (modelM.Faint == "1" && count < 3)
                        {
                            if (strqtz == "")
                            {
                                strqtz = "气虚质";
                            }
                            else
                            {
                                strqtz = strqtz + "," + "气虚质";
                            }
                            count++;
                        }
                        if (modelM.Yang == "1" && count < 3)
                        {
                            if (strqtz == "")
                            {
                                strqtz = "阳虚质";
                            }
                            else
                            {
                                strqtz = strqtz + "," + "阳虚质";
                            }
                            count++;
                        }
                        if (modelM.Yin == "1" && count < 3)
                        {
                            if (strqtz == "")
                            {
                                strqtz = "阴虚质";
                            }
                            else
                            {
                                strqtz = strqtz + "," + "阴虚质";
                            }
                            count++;
                        }
                        if (modelM.PhlegmDamp == "1" && count < 3)
                        {
                            if (strqtz == "")
                            {
                                strqtz = "痰湿质";
                            }
                            else
                            {
                                strqtz = strqtz + "," + "痰湿质";
                            }
                            count++;
                        }
                        if (modelM.Muggy == "1" && count < 3)
                        {
                            if (strqtz == "")
                            {
                                strqtz = "湿热质";
                            }
                            else
                            {
                                strqtz = strqtz + "," + "湿热质";
                            }
                            count++;
                        }
                        if (modelM.BloodStasis == "1" && count < 3)
                        {
                            if (strqtz == "")
                            {
                                strqtz = "血瘀质";
                            }
                            else
                            {
                                strqtz = strqtz + "," + "血瘀质";
                            }
                            count++;
                        }
                        if (modelM.QiConstraint == "1" && count < 3)
                        {
                            if (strqtz == "")
                            {
                                strqtz = "气郁质";
                            }
                            else
                            {
                                strqtz = strqtz + "," + "气郁质";
                            }
                            count++;
                        }

                        if (modelM.Characteristic == "1" && count < 3)
                        {
                            if (strqtz == "")
                            {
                                strqtz = "特兼质";
                            }
                            else
                            {
                                strqtz = strqtz + "," + "特兼质";
                            }
                        }

                        count = 0;

                        if (modelM.Mild == "2" && count < 3)
                        {
                            if (strqxy == "")
                            {
                                strqxy = "平和质";
                            }
                            else
                            {
                                strqxy = strqxy + "," + "平和质";
                            }
                            count++;
                        }
                        if (modelM.Faint == "2" && count < 3)
                        {
                            if (strqxy == "")
                            {
                                strqxy = "气虚质";
                            }
                            else
                            {
                                strqxy = strqxy + "," + "气虚质";
                            }
                            count++;
                        }

                        if (modelM.Yang == "2" && count < 3)
                        {
                            if (strqxy == "")
                            {
                                strqxy = "阳虚质";
                            }
                            else
                            {
                                strqxy = strqxy + "," + "阳虚质";
                            }
                            count++;
                        }
                        if (modelM.Yin == "2" && count < 3)
                        {
                            if (strqxy == "")
                            {
                                strqxy = "阴虚质";
                            }
                            else
                            {
                                strqxy = strqxy + "," + "阴虚质";
                            }
                            count++;
                        }
                        if (modelM.PhlegmDamp == "2" && count < 3)
                        {
                            if (strqxy == "")
                            {
                                strqxy = "痰湿质";
                            }
                            else
                            {
                                strqxy = strqxy + "," + "痰湿质";
                            }
                            count++;
                        }
                        if (modelM.Muggy == "2" && count < 3)
                        {
                            if (strqxy == "")
                            {
                                strqxy = "湿热质";
                            }
                            else
                            {
                                strqxy = strqxy + "," + "湿热质";
                            }
                            count++;
                        }
                        if (modelM.BloodStasis == "2" && count < 3)
                        {
                            if (strqxy == "")
                            {
                                strqxy = "血瘀质";
                            }
                            else
                            {
                                strqxy = strqxy + "," + "血瘀质";
                            }
                            count++;
                        }
                        if (modelM.QiConstraint == "2" && count < 3)
                        {
                            if (strqxy == "")
                            {
                                strqxy = "气郁质";
                            }
                            else
                            {
                                strqxy = strqxy + "," + "气郁质";
                            }
                            count++;
                        }
                        if (modelM.Characteristic == "2" && count < 3)
                        {
                            if (strqxy == "")
                            {
                                strqxy = "特兼质";
                            }
                            else
                            {
                                strqxy = strqxy + "," + "特兼质";
                            }
                            count++;
                        }

                        if (File.Exists(Application.StartupPath + "\\mediphys.xml"))
                        {
                            DataSet ds = new DataSet();
                            ds.ReadXml(Application.StartupPath + "\\mediphys.xml");
                            DataTable dt_tz = ds.Tables[0];
                            if (modelM.Mild == "1" || modelM.Mild == "2")
                            {
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "平和质")
                                    {
                                        if (number < 6)
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            number++;
                                        }
                                        else
                                        {
                                            strtzzsjy = strtzzsjy;
                                            number++;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (modelM.Faint == "1" || modelM.Faint == "2")
                            {
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "气虚质")
                                    {
                                        if (number < 6)
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            number++;
                                        }
                                        else
                                        {
                                            strtzzsjy = strtzzsjy;
                                            number++;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (modelM.Yang == "1" || modelM.Yang == "2")
                            {
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "阳虚质")
                                    {
                                        if (number < 6)
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            number++;
                                        }
                                        else
                                        {
                                            strtzzsjy = strtzzsjy;
                                            number++;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (modelM.Yin == "1" || modelM.Yin == "2")
                            {
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "阴虚质")
                                    {
                                        if (number < 6)
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            number++;
                                        }
                                        else
                                        {
                                            strtzzsjy = strtzzsjy;
                                            number++;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (modelM.PhlegmDamp == "1" || modelM.PhlegmDamp == "2")
                            {
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "痰湿质")
                                    {
                                        if (number < 6)
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            number++;
                                        }
                                        else
                                        {
                                            strtzzsjy = strtzzsjy;
                                            number++;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (modelM.Muggy == "1" || modelM.Muggy == "2")
                            {
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "湿热质")
                                    {
                                        if (number < 6)
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            number++;
                                        }
                                        else
                                        {
                                            strtzzsjy = strtzzsjy;
                                            number++;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (modelM.BloodStasis == "1" || modelM.BloodStasis == "2")
                            {
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "血瘀质")
                                    {
                                        if (number < 6)
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            number++;
                                        }
                                        else
                                        {
                                            strtzzsjy = strtzzsjy;
                                            number++;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (modelM.QiConstraint == "1" || modelM.QiConstraint == "2")
                            {
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "气郁质")
                                    {
                                        if (number < 6)
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            number++;
                                        }
                                        else
                                        {
                                            strtzzsjy = strtzzsjy;
                                            number++;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (modelM.Characteristic == "1" || modelM.Characteristic == "2")
                            {
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "特兼质")
                                    {
                                        if (number < 6)
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            number++;
                                        }
                                        else
                                        {
                                            strtzzsjy = strtzzsjy;
                                            number++;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    list.Add(new ListValue
                    {
                        strMark = "$qxy",
                        strVal = strqxy
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$tz",
                        strVal = strqtz
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$tzzsjy",
                        strVal = strtzzsjy
                    });
                }

                RecordsGeneralConditionModel modelG = new RecordsGeneralConditionBLL().GetModelByOutKey(modelC.ID);
                string strpsjy = "", strxxjy = "";

                if (modelG != null)
                {
                    if (File.Exists(Application.StartupPath + "\\mediphys.xml"))
                    {
                        DataSet ds = new DataSet();
                        ds.ReadXml(Application.StartupPath + "\\mediphys.xml");
                        DataTable dt_tz = ds.Tables[0];
                        if (!string.IsNullOrEmpty(Convert.ToString(modelG.BMI)))
                        {
                            if (Convert.ToDouble(modelG.BMI) > 24.99)
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "$stjc",
                                    strVal = "偏胖"
                                });
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "偏胖")
                                    {
                                        strpsjy = item["jianyi"].ToString();
                                        break;
                                    }
                                }
                            }
                            else if ((Convert.ToDouble(modelG.BMI) < 18.5) && (Convert.ToDouble(modelG.BMI) > 0))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "$stjc",
                                    strVal = "偏瘦"
                                });
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "偏瘦")
                                    {
                                        strpsjy = item["jianyi"].ToString();
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "$stjc",
                                    strVal = "正常"
                                });
                                strpsjy = "正常";
                            }
                        }
                        if (Convert.ToDouble(modelG.LeftHeight) >= 140 || modelG.LeftPre >= 90)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "高血压")
                                {
                                    strxxjy = strxxjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        else if ((modelG.LeftHeight < 90 && modelG.LeftHeight > 0) || (0 < modelG.LeftPre && modelG.LeftPre < 60))
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "低血压")
                                {
                                    strxxjy = strxxjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                    }

                    list.Add(new ListValue
                    {
                        strMark = "$tzzs",
                        strVal = Convert.ToString(modelG.BMI)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ssy",
                        strVal = Convert.ToString(modelG.LeftHeight)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$szy",
                        strVal = Convert.ToString(modelG.LeftPre)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$psjy",
                        strVal = strpsjy
                    });
                }
                RecordsPhysicalExamModel modelP = new RecordsPhysicalExamBLL().GetModelByOutKey(modelC.ID);
                if (modelP != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$xl",
                        strVal = modelP.HeartRate
                    });
                }
                RecordsAssistCheckModel modelA = new RecordsAssistCheckBLL().GetModelByOutKey(modelC.ID);
                string strxcgjy = "", strncgjy = "", strnwlbdbjy = "", strdbqxjy = "", strtzhxhdbjy = "";
                string stryxgybmkyjy = "", strggnjy = "", strsgnjy = "", strxzjy = "", stragemonth = "";
                if (modelA != null)
                {
                    if (File.Exists(Application.StartupPath + "\\mediphys.xml"))
                    {
                        DataSet ds = new DataSet();
                        ds.ReadXml(Application.StartupPath + "\\mediphys.xml");
                        DataTable dt_tz = ds.Tables[0];
                        if (!string.IsNullOrEmpty(Convert.ToString(modelA.FPGL)))
                        {
                            if (Convert.ToDouble(modelA.FPGL) > 6.1)
                            {
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "高血糖")
                                    {
                                        strxxjy = strxxjy + item["jianyi"].ToString();
                                        break;
                                    }
                                }
                            }
                            else if (Convert.ToDouble(modelA.FPGL) < 3.9 && Convert.ToDouble(modelA.FPGL) > 0)
                            {
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "低血糖")
                                    {
                                        strxxjy = strxxjy + item["jianyi"].ToString();
                                        break;
                                    }
                                }
                            }
                        }
                        //以后血常规、尿常规、大便潜血、糖化血红蛋白、乙型肝炎表面抗原、肝功能、肾功能、血脂获取
                        bool resultold = false, resultkids = false, resultyoung = false;
                        if (model.Birthday != null)
                        {
                            //DateTime dtage = Convert.ToDateTime(model.Birthday);
                            //decimal dnow = Convert.ToDecimal(DateTime.Today.ToString("yyyyMMdd"));
                            //decimal dage = Convert.ToDecimal(dtage.ToString("yyyyMMdd"));
                            //strage = Convert.ToString(dnow - dage).Substring(0, 2);
                            if (Convert.ToInt32(strage) > 14) //成人年龄（年龄>14岁）
                            {
                                if (strsex == "男")
                                {
                                    //血常规中血红蛋白（成人男）
                                    if (modelA.HB > 160)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "血红蛋白偏高")
                                            {
                                                strxcgjy = strxcgjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    else if (modelA.HB < 120)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "血红蛋白偏低")
                                            {
                                                strxcgjy = strxcgjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    //肾功能中血清肌酐（成人男）
                                    if (modelA.SCR > 106)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "血清肌酐偏高")
                                            {
                                                strsgnjy = strsgnjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    else if (modelA.SCR < 54)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "血清肌酐偏低")
                                            {
                                                strsgnjy = strsgnjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (strsex == "女")
                                {
                                    //血常规中血红蛋白（成人女）
                                    if (modelA.HB > 150)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "血红蛋白偏高")
                                            {
                                                strxcgjy = strxcgjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    else if (modelA.HB < 110)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "血红蛋白偏低")
                                            {
                                                strxcgjy = strxcgjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    //肾功能中血清肌酐（成人女）
                                    if (modelA.SCR > 97)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "血清肌酐偏高")
                                            {
                                                strsgnjy = strsgnjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    else if (modelA.SCR < 44)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "血清肌酐偏低")
                                            {
                                                strsgnjy = strsgnjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                }
                                //血常规中白细胞（成人）
                                if (modelA.WBC > 10)
                                {
                                    foreach (DataRow item in dt_tz.Rows)
                                    {
                                        if (item["name"].ToString() == "白细胞偏高")
                                        {
                                            strxcgjy = strxcgjy + item["jianyi"].ToString();
                                            break;
                                        }
                                    }
                                }
                                else if (modelA.WBC < 4)
                                {
                                    foreach (DataRow item in dt_tz.Rows)
                                    {
                                        if (item["name"].ToString() == "白细胞偏低")
                                        {
                                            strxcgjy = strxcgjy + item["jianyi"].ToString();
                                            break;
                                        }
                                    }
                                }
                                //肝功能中白蛋白（14~18岁）
                                if (Convert.ToInt32(strage) < 18)
                                {
                                    if (modelA.BP > 54)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "白蛋白偏高")
                                            {
                                                strggnjy = strggnjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    else if (modelA.BP < 38)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "白蛋白偏低")
                                            {
                                                strggnjy = strggnjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (Convert.ToInt32(strage) > 60)
                                {
                                    if (modelA.BP > 48)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "白蛋白偏高")
                                            {
                                                strggnjy = strggnjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    else if (modelA.BP < 34)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "白蛋白偏低")
                                            {
                                                strggnjy = strggnjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                }
                                else //(18~60岁)
                                {
                                    if (modelA.BP > 50)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "白蛋白偏高")
                                            {
                                                strggnjy = strggnjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    else if (modelA.BP < 35)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "白蛋白偏低")
                                            {
                                                strggnjy = strggnjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else  //未成年（年龄<14岁）
                            {
                                if ((dnow - dage) < 32) //新生儿年龄(<32天)
                                {
                                    //血常规中血红蛋白（新生儿）
                                    if (modelA.HB > 200)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "血红蛋白偏高")
                                            {
                                                strxcgjy = strxcgjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    else if (modelA.HB < 170)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "血红蛋白偏低")
                                            {
                                                strxcgjy = strxcgjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    //血常规中白细胞（新生儿）
                                    if (modelA.WBC > 20)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "白细胞偏高")
                                            {
                                                strxcgjy = strxcgjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    else if (modelA.WBC < 15)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "白细胞偏低")
                                            {
                                                strxcgjy = strxcgjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                }
                                else   //青少年（儿童）年龄
                                {
                                    //血常规中血红蛋白
                                    if (modelA.HB > 160)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "血红蛋白偏高")
                                            {
                                                strxcgjy = strxcgjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    else if (modelA.HB < 110)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "血红蛋白偏低")
                                            {
                                                strxcgjy = strxcgjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    //血常规中白细胞
                                    if (modelA.WBC > 12)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "白细胞偏高")
                                            {
                                                strxcgjy = strxcgjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    else if (modelA.WBC < 5)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "白细胞偏低")
                                            {
                                                strxcgjy = strxcgjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    //肝功能中白蛋白（新生儿（0~14岁））
                                    if (modelA.BP > 44)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "白蛋白偏高")
                                            {
                                                strggnjy = strggnjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    else if (modelA.BP < 28)
                                    {
                                        foreach (DataRow item in dt_tz.Rows)
                                        {
                                            if (item["name"].ToString() == "白蛋白偏低")
                                            {
                                                strggnjy = strggnjy + item["jianyi"].ToString();
                                                break;
                                            }
                                        }
                                    }

                                }
                                //肾功能中血清肌酐（未成年） 
                                if (Convert.ToDouble(modelA.SCR) > 69.7)
                                {
                                    foreach (DataRow item in dt_tz.Rows)
                                    {
                                        if (item["name"].ToString() == "血清肌酐偏高")
                                        {
                                            strsgnjy = strsgnjy + item["jianyi"].ToString();
                                            break;
                                        }
                                    }
                                }
                                else if (Convert.ToDouble(modelA.SCR) < 24.9)
                                {
                                    foreach (DataRow item in dt_tz.Rows)
                                    {
                                        if (item["name"].ToString() == "血清肌酐偏低")
                                        {
                                            strsgnjy = strsgnjy + item["jianyi"].ToString();
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        //不分年龄阶段
                        //血常规中血小板
                        if (modelA.PLT < 100)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "血小板偏低")
                                {
                                    strxcgjy = strxcgjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        //尿常规strncgjy中尿蛋白、尿糖、尿酮体、尿潜血
                        if (modelA.PRO != "-")
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "尿蛋白异常")
                                {
                                    strncgjy = strncgjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        if (modelA.GLU != "-")
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "尿糖异常")
                                {
                                    strncgjy = strncgjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        if (modelA.KET != "-")
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "尿酮体异常")
                                {
                                    strncgjy = strncgjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        if (modelA.BLD != "-")
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "尿潜血异常")
                                {
                                    strncgjy = strncgjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        //尿微量白蛋白strnwlbdbjy
                        if (modelA.ALBUMIN > 417)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "尿微量白蛋白偏高")
                                {
                                    strncgjy = strncgjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        //大便潜血strdbqxjy
                        if (modelA.FOB == "2") //阳性异常
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "大便潜血异常")
                                {
                                    strdbqxjy = strdbqxjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        else if (modelA.FOB == "1") //阴性异常
                        {
                            strdbqxjy = "正常；";
                        }
                        //糖转化血红蛋白strtzhxhdbjy
                        if (modelA.HBALC > 4 && 6 >= modelA.HBALC)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "糖化血红蛋白正常")
                                {
                                    strtzhxhdbjy = strtzhxhdbjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        else if (modelA.HBALC > 6 && 7 >= modelA.HBALC)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "糖化血红蛋白理想")
                                {
                                    strtzhxhdbjy = strtzhxhdbjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        else if (modelA.HBALC > 7 && 8 >= modelA.HBALC)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "糖化血红蛋白一般")
                                {
                                    strtzhxhdbjy = strtzhxhdbjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        else if (modelA.HBALC > 8 && 9 >= modelA.HBALC)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "糖化血红蛋白不理想")
                                {
                                    strtzhxhdbjy = strtzhxhdbjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        else if (modelA.HBALC > 9)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "糖化血红蛋白很差")
                                {
                                    strtzhxhdbjy = strtzhxhdbjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            strtzhxhdbjy = "糖化血红蛋白控制不正常；";
                        }
                        //乙型肝炎表面抗原stryxgybmkyjy
                        if (modelA.HBSAG == "2")
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "乙型肝炎表面抗原异常")
                                {
                                    stryxgybmkyjy = stryxgybmkyjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        else if (modelA.HBSAG == "1")
                        {
                            stryxgybmkyjy = "正常；";
                        }
                        //肝功能strggnjy中血清谷丙转氨酶、血清谷草转氨酶、白蛋白、总胆红素、综合胆红素。 
                        if (modelA.SGPT > 40 || modelA.SGPT < 0)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "血清谷丙转氨酶异常")
                                {
                                    strggnjy = strggnjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        if (modelA.GOT > 40 || modelA.GOT < 0)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "血清谷草转氨酶异常")
                                {
                                    strggnjy = strggnjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        if (Convert.ToDouble(modelA.TBIL) > 17.1)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "总胆红素偏高")
                                {
                                    strggnjy = strggnjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        if (modelA.CB > 7)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "综合胆红素偏高")
                                {
                                    strggnjy = strggnjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        else if (modelA.CB < 0)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "综合胆红素偏低")
                                {
                                    strggnjy = strggnjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        //肾功能strsgnjy中血清肌酐、血尿素氮、血钾浓度、血钠浓度
                        if (Convert.ToDouble(modelA.BUN) > 7.14)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "血尿素氮偏高")
                                {
                                    strsgnjy = strsgnjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        else if (Convert.ToDouble(modelA.BUN) < 2.86)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "血尿素氮偏低")
                                {
                                    strsgnjy = strsgnjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }

                        if (Convert.ToDouble(modelA.PC) > 5.3)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "血钾浓度偏高")
                                {
                                    strsgnjy = strsgnjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        else if (Convert.ToDouble(modelA.PC) < 3.5)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "血钾浓度偏低")
                                {
                                    strsgnjy = strsgnjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }

                        if (modelA.HYPE > 145)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "血钠浓度偏高")
                                {
                                    strsgnjy = strsgnjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        else if (modelA.HYPE < 135)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "血钠浓度偏低")
                                {
                                    strsgnjy = strsgnjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }

                        //血脂strxzjy中总胆固醇、甘油三酯、血清低密度脂蛋白胆固醇、血清高密度脂蛋白胆固醇
                        if (Convert.ToDouble(modelA.TC) > 5.2)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "总胆固醇偏高")
                                {
                                    strxzjy = strxzjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        else if (Convert.ToDouble(modelA.TC) < 3)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "总胆固醇偏低")
                                {
                                    strxzjy = strxzjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        if (Convert.ToDouble(modelA.TG) >= 1.7)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "甘油三酯偏高")
                                {
                                    strxzjy = strxzjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        if (Convert.ToDouble(modelA.LowCho) > 3.1)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "血清低密度脂蛋白胆固醇偏高")
                                {
                                    strxzjy = strxzjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        else if (Convert.ToDouble(modelA.LowCho) < 2.7)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "血清低密度脂蛋白胆固醇偏低")
                                {
                                    strxzjy = strxzjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                        if (Convert.ToDouble(modelA.HeiCho) < 0.91)
                        {
                            foreach (DataRow item in dt_tz.Rows)
                            {
                                if (item["name"].ToString() == "血清高密度脂蛋白胆固醇偏低")
                                {
                                    strxzjy = strxzjy + item["jianyi"].ToString();
                                    break;
                                }
                            }
                        }
                    }
                    list.Add(new ListValue
                    {
                        strMark = "$xt",
                        strVal = Convert.ToString(modelA.FPGL)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xhdb",
                        strVal = Convert.ToString(modelA.HB)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$bxb",
                        strVal = Convert.ToString(modelA.WBC)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xxb",
                        strVal = Convert.ToString(modelA.PLT)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ndb",
                        strVal = modelA.PRO
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$nt",
                        strVal = modelA.GLU
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ntt",
                        strVal = modelA.KET
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$nqx",
                        strVal = modelA.BLD
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$nwlbdb",
                        strVal = Convert.ToString(modelA.ALBUMIN)
                    });
                    string dbqxstr = "";
                    if (modelA.FOB == "1")
                    {
                        dbqxstr = "阴性";
                    }
                    else if (modelA.FOB == "2")
                    {
                        dbqxstr = "阳性";
                    }
                    list.Add(new ListValue
                    {
                        strMark = "$dbqx",
                        strVal = dbqxstr
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$thxhdb",
                        strVal = Convert.ToString(modelA.HBALC)
                    });
                    string yxgybmkystr = "";
                    if (modelA.HBSAG == "1")
                    {
                        yxgybmkystr = "阴性";
                    }
                    else if (modelA.HBSAG == "2")
                    {
                        yxgybmkystr = "阳性";
                    }
                    list.Add(new ListValue
                    {
                        strMark = "$yxgybmky",
                        strVal = yxgybmkystr
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xqgbzam",
                        strVal = Convert.ToString(modelA.SGPT)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xqgczam",
                        strVal = Convert.ToString(modelA.GOT)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$bdb",
                        strVal = Convert.ToString(modelA.BP)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zdhs",
                        strVal = Convert.ToString(modelA.TBIL)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zhdhs",
                        strVal = Convert.ToString(modelA.CB)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xqjg",
                        strVal = Convert.ToString(modelA.SCR)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xnsd",
                        strVal = Convert.ToString(modelA.BUN)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xjnd",
                        strVal = Convert.ToString(modelA.PC)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xnnd",
                        strVal = Convert.ToString(modelA.HYPE)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zdgc",
                        strVal = Convert.ToString(modelA.TC)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$gysz",
                        strVal = Convert.ToString(modelA.TG)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xqdmdzdbdgc",
                        strVal = Convert.ToString(modelA.LowCho)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xqgmdzdbdgc",
                        strVal = Convert.ToString(modelA.HeiCho)
                    });
                }
                if (strxxjy != "")
                {
                    list.Add(new ListValue
                    {
                        strMark = "$xxjy",
                        strVal = strxxjy
                    });
                }
                list.Add(new ListValue
                {
                    strMark = "$xcgjy",
                    strVal = strxcgjy
                });
                list.Add(new ListValue
                {
                    strMark = "$ncgjy",
                    strVal = strncgjy
                });
                list.Add(new ListValue
                {
                    strMark = "$nwlbdbjy",
                    strVal = strnwlbdbjy
                });
                list.Add(new ListValue
                {
                    strMark = "$dbqxjy",
                    strVal = strdbqxjy
                });
                list.Add(new ListValue
                {
                    strMark = "$tzhxhdbjy",
                    strVal = strtzhxhdbjy
                });
                list.Add(new ListValue
                {
                    strMark = "$yxgybmkyjy",
                    strVal = stryxgybmkyjy
                });
                list.Add(new ListValue
                {
                    strMark = "$ggnjy",
                    strVal = strggnjy
                });
                list.Add(new ListValue
                {
                    strMark = "$sgnjy",
                    strVal = strsgnjy
                });
                list.Add(new ListValue
                {
                    strMark = "$xzjy",
                    strVal = strxzjy
                });
            }
            DataTable dtI1 = new RecordsIllnessHistoryInfoBLL().Getdt(this.CardID, "1").Tables[0];
            DataTable dtI2 = new RecordsIllnessHistoryInfoBLL().Getdt(this.CardID, "2").Tables[0];
            DataTable dtI3 = new RecordsIllnessHistoryInfoBLL().Getdt(this.CardID, "3").Tables[0];
            DataTable dtI4 = new RecordsIllnessHistoryInfoBLL().Getdt(this.CardID, "4").Tables[0];
            string strill = "";
            if (dtI2.Rows.Count > 0)
            {
                if (strill == "")
                {
                    strill = "手术";
                }
                else
                {
                    strill = strill + "," + "手术";
                }
            }
            if (dtI3.Rows.Count > 0)
            {
                if (strill == "")
                {
                    strill = "外伤";
                }
                else
                {
                    strill = strill + "," + "外伤";
                }
            }
            if (dtI4.Rows.Count > 0)
            {
                if (strill == "")
                {
                    strill = "输血";
                }
                else
                {
                    strill = strill + "," + "输血";
                }
            }
            if (dtI1.Rows.Count > 0)
            {
                if (strill == "")
                {
                    strill = "疾病：";
                }
                else
                {
                    strill = strill + "," + "疾病：";
                }
                for (int i = 0; i < dtI1.Rows.Count; i++)
                {
                    string str = dtI1.Rows[i][4].ToString();
                    if (str == "2")
                    {
                        strill = strill + "高血压" + "、";
                    }
                    else if (str == "3")
                    {
                        strill = strill + "糖尿病" + "、";
                    }
                    else if (str == "4")
                    {
                        strill = strill + "冠心病" + "、";
                    }
                    else if (str == "5")
                    {
                        strill = strill + "慢性阻塞性肺疾病" + "、";
                    }
                    else if (str == "6")
                    {
                        strill = strill + "恶性肿瘤" + "、";
                    }
                    else if (str == "7")
                    {
                        strill = strill + "脑卒中" + "、";
                    }
                    else if (str == "8")
                    {
                        strill = strill + "重性精神疾病" + "、";
                    }
                    else if (str == "9")
                    {
                        strill = strill + "结核病" + "、";
                    }
                    else if (str == "10")
                    {
                        strill = strill + "肝炎" + "、";
                    }
                    else if (str == "11")
                    {
                        strill = strill + "其他法定传染病" + "、";
                    }
                    else if (str == "12")
                    {
                        strill = strill + "职业病" + "、";
                    }
                    else if (str == "13")
                    {
                        strill = strill + dtI1.Rows[i][6].ToString() + "、";
                    }
                }
            }

            list.Add(new ListValue
            {
                strMark = "$jbs",
                strVal = strill
            });

            return DrawItems.setPage("printXps\\27个体化健康教育.xps", list);
        }
    }
}
