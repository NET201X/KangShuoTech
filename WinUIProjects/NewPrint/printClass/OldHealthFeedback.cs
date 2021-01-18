using ReportPrint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.BLL;
using System.IO;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.DAL;
using System.Configuration;

namespace printClass
{
    public class OldHealthFeedback : IGetReport
    {
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Year/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Year//"; //签名保存路径
        private string PhotoPath = ConfigurationManager.AppSettings["PhotoPath"] == null ? @"photo/" : ConfigurationManager.AppSettings["PhotoPath"].ToString(); //身份证照片路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                string area = ConfigHelper.GetSetNode("area");
                if (area == "淄博")
                {
                    return "35老年人健康体检反馈单(淄博).xps";
                }
                else
                {
                    return "35老年人健康体检反馈单.xps";
                }
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
            if (!string.IsNullOrEmpty(this.CardID))
            {
                bool flagEx = false;
                RecordsBaseInfoModel model = new RecordsBaseInfoBLL().GetModel(this.CardID);
                string strage = "", strsex = "";
                TimeParser timeParser = new TimeParser();
                strage = timeParser.GetAge(model.Birthday);

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
                List<ListValue> list = new List<ListValue>
                {
                    new ListValue
                    {
                        strMark = "$name",
                        strVal = model.CustomerName
                    },
                    new ListValue
                    {
                        strMark = "$age",
                        strVal = strage
                    },
                    new ListValue
                    {
                        strMark = "$sex",
                        strVal = strsex
                    },
                    new ListValue
                    {
                        strMark = "$fkys",
                        strVal = model.Doctor
                    },
                    new ListValue
                    {
                        strMark = "$zhen",
                        strVal = model.TownName
                    },
                    new ListValue
                    {
                        strMark = "$cun",
                        strVal = model.VillageName
                    },
                    new ListValue
                    {
                        strMark = "$cardid",
                        strVal = model.IDCardNo
                    },
                    new ListValue
                    {
                        strMark = "$archiveid",
                        strVal = model.RecordID
                    },
                    new ListValue
                    {
                        strMark = "$address",
                        strVal = model.Address
                    }
                };

                string phone = ConfigHelper.GetSetNode("phone");

                list.Add(new ListValue
                {
                    strMark = "$zxdh",
                    strVal = phone
                });
                string strOrg = ConfigHelper.GetNode("orgCode").Substring(0, 9);
                string TownID = (strOrg.Length < 9) ? "" : strOrg.Substring(0, 9);
                if (!string.IsNullOrEmpty(TownID))
                {
                    SysOrgTownModel townmodel = new SysOrgTownBLL().GetModel(strOrg);
                    if (townmodel != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "^wsy",
                            strVal = townmodel.Name
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$zxwsy",
                            strVal = townmodel.Name
                        });
                    }
                }
                RecordsCustomerBaseInfoModel model2 = new RecordsCustomerBaseInfoBLL().GetMaxModel(this.CardID);
                if (model2 != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$tjsj",
                        strVal = DrawItems.strToDate(model2.CheckDate, 1)
                    });
                    RecordsGeneralConditionModel model3 = new RecordsGeneralConditionDAL().GetModelByOutKey(model2.ID);
                    if (model3 != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$height",
                            strVal = DrawItems.objToNumStr(model3.Height)
                        });
                        string strBMI = model3.BMI.ToString();
                        if (model3.BMI > 24)
                        {
                            strBMI += "↑";
                        }
                        else if (model3.BMI < 18)
                        {
                            strBMI += "↓";
                        }
                        list.Add(new ListValue
                        {
                            strMark = "$tzzs",
                            strVal = strBMI
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$weight",
                            strVal = DrawItems.objToNumStr(model3.Weight)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ml",
                            strVal = DrawItems.objToNumStr(model3.PulseRate)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xyg",
                            strVal = DrawItems.objToNumStr(model3.RightHeight, 0)
                        });
                        string strxyd = DrawItems.objToNumStr(model3.RightPre, 0);
                        if (!string.IsNullOrEmpty(Convert.ToString(model3.RightHeight)) || !string.IsNullOrEmpty(Convert.ToString(model3.RightPre)))
                        {
                            if (Convert.ToDouble(model3.RightHeight) > 140 || Convert.ToDouble(model3.RightPre) > 90)
                            {
                                flagEx = true;
                                strxyd += "↑";
                            }
                            else if (Convert.ToDouble(model3.RightHeight) < 90 || Convert.ToDouble(model3.RightPre) < 60)
                            {
                                flagEx = true;
                                strxyd += "↓";
                            }
                        }
                        list.Add(new ListValue
                        {
                            strMark = "$xyd",
                            strVal = strxyd
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
                    }

                    //尿液常规
                    string strYear = DateTime.Now.Year.ToString();                    
                    string strWhere = string.Format("IDCardNo='{0}' AND Devicetype=33 AND LEFT(UpdateData,4)='{1}' ORDER BY UpdateData DESC,ID DESC LIMIT 0,1 ", this.CardID, strYear);
                    DataSet UrineDt = new DeviceInfoDAL().GetList(strWhere);

                    if (UrineDt.Tables.Count > 0)
                    {
                        foreach (DataRow UrineRow in UrineDt.Tables[0].Rows)
                        {
                            // 白细胞
                            list.Add(new ListValue
                            {
                                strMark = "$nbxb",
                                strVal = UrineRow["VALUE9"].ToString()
                            });

                            // 亚硝酸盐
                            list.Add(new ListValue
                            {
                                strMark = "$sy",
                                strVal = UrineRow["VALUE8"].ToString()
                            });

                            // 尿胆原
                            list.Add(new ListValue
                            {
                                strMark = "$ndy",
                                strVal = UrineRow["VALUE1"].ToString()
                            });

                            // 胆红素
                            list.Add(new ListValue
                            {
                                strMark = "$dhs",
                                strVal = UrineRow["VALUE3"].ToString()
                            });

                            // 维生素C
                            list.Add(new ListValue
                            {
                                strMark = "$vc",
                                strVal = UrineRow["VALUE11"].ToString()
                            });

                            // PH值
                            list.Add(new ListValue
                            {
                                strMark = "$ph",
                                strVal = UrineRow["VALUE7"].ToString()
                            });

                            // 比重
                            list.Add(new ListValue
                            {
                                strMark = "$bz",
                                strVal = UrineRow["VALUE10"].ToString()
                            });
                        }
                    }

                    RecordsAssistCheckModel model7 = new RecordsAssistCheckBLL().GetModelByOutKey(model2.ID);

                    if (model7 != null)
                    {
                        string strHB = "", strWBC = "", strPLT = "", strTC = "", strTG = "", strHeiCho = "", strLowCho = "",
                            strFPGL = "", strSGPT = "", strGOT = "", strTBIL = "", strSCR = "", strBUN = "", strHCY = "";

                        #region
                        if (File.Exists(Application.StartupPath + "\\SHValueRange.xml"))
                        {
                            DataSet ds = new DataSet();
                            ds.ReadXml(Application.StartupPath + "\\SHValueRange.xml");
                            DataTable dtSH = ds.Tables[0];
                            if (dtSH.Rows.Count > 0)
                            {
                                foreach (DataRow item in dtSH.Rows)
                                {
                                    if (item["name"].ToString() == "血红蛋白") //血红蛋白  
                                    {
                                        strHB = model7.HB.ToString();
                                        list.Add(new ListValue
                                        {
                                            strMark = "$hbg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });
                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.HB)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.HB) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strHB = model7.HB.ToString() + "↓";
                                            }
                                            else if (Convert.ToDouble(model7.HB) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strHB = model7.HB.ToString() + "↑";
                                            }

                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "白细胞") //白细胞   
                                    {
                                        strWBC = model7.WBC.ToString();
                                        list.Add(new ListValue
                                        {
                                            strMark = "$wbcg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });
                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.WBC)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.WBC) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strWBC = model7.WBC.ToString() + "↓";
                                            }
                                            else if (Convert.ToDouble(model7.WBC) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strWBC = model7.WBC.ToString() + "↑";
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "血小板") //血小板PLT
                                    {
                                        strPLT = model7.PLT.ToString();
                                        list.Add(new ListValue
                                        {
                                            strMark = "$xxbg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });
                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.PLT)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.PLT) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strPLT = model7.PLT.ToString() + "↓";
                                            }
                                            else if (Convert.ToDouble(model7.PLT) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strPLT = model7.PLT.ToString() + "↑";
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "总胆固醇") //总胆固醇（TC）
                                    {
                                        strTC = model7.TC.ToString();
                                        list.Add(new ListValue
                                        {
                                            strMark = "$tcg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });
                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.TC)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.TC) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strTC = model7.TC.ToString() + "↓";
                                            }
                                            else if (Convert.ToDouble(model7.TC) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strTC = model7.TC.ToString() + "↑";
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "甘油三酯")  //甘油三酯（TG）
                                    {
                                        strTG = model7.TG.ToString();
                                        list.Add(new ListValue
                                        {
                                            strMark = "$tgg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });

                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.TG)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.TG) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strTG = model7.TG.ToString() + "↑";
                                            }
                                            else if (Convert.ToDouble(model7.TG) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strTG = model7.TG.ToString() + "↓";
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "血清高密度脂蛋白胆固醇") //高密度脂蛋白HeiCho
                                    {
                                        strHeiCho = model7.HeiCho.ToString();
                                        list.Add(new ListValue
                                        {
                                            strMark = "$gzg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });

                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.HeiCho)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.HeiCho) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strHeiCho = model7.HeiCho.ToString() + "↑";
                                            }
                                            else if (Convert.ToDouble(model7.HeiCho) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strHeiCho = model7.HeiCho.ToString() + "↓";
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "血清低密度脂蛋白胆固醇")  //低密度脂蛋白LowCho
                                    {
                                        strLowCho = model7.LowCho.ToString();
                                        list.Add(new ListValue
                                        {
                                            strMark = "$dzg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });

                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.LowCho)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.LowCho) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strLowCho = model7.LowCho.ToString() + "↑";
                                            }
                                            else if (Convert.ToDouble(model7.LowCho) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strLowCho = model7.LowCho.ToString() + "↓";
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "空腹血糖") //空腹血糖FPGL
                                    {
                                        strFPGL = model7.FPGL.ToString();
                                        list.Add(new ListValue
                                        {
                                            strMark = "$xtg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });

                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.FPGL)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.FPGL) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strFPGL = model7.FPGL.ToString() + "↑";
                                            }
                                            else if (Convert.ToDouble(model7.FPGL) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strFPGL = model7.FPGL.ToString() + "↓";
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "血清谷丙转氨酶") //谷丙转氨酶SGPT
                                    {
                                        strSGPT = model7.SGPT.ToString();
                                        list.Add(new ListValue
                                        {
                                            strMark = "$gbg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });

                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.SGPT)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.SGPT) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strSGPT = model7.SGPT.ToString() + "↑";
                                            }
                                            else if (Convert.ToDouble(model7.SGPT) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strSGPT = model7.SGPT.ToString() + "↓";
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "血清谷草转氨酶") //谷草转氨酶GOT
                                    {
                                        strGOT = model7.GOT.ToString();
                                        list.Add(new ListValue
                                        {
                                            strMark = "$gcg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });

                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.GOT)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.GOT) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strGOT = model7.GOT.ToString() + "↑";
                                            }
                                            else if (Convert.ToDouble(model7.GOT) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strGOT = model7.GOT.ToString() + "↓";
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "同型半胱氨酸") //同型半胱氨酸
                                    {
                                        strHCY = model7.HCY.ToString();
                                        list.Add(new ListValue
                                        {
                                            strMark = "$bgdg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });

                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.HCY)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.HCY) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strHCY = model7.HCY.ToString() + "↑";
                                            }
                                            else if (Convert.ToDouble(model7.HCY) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strHCY = model7.HCY.ToString() + "↓";
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "总胆红素") //总胆红素TBIL
                                    {
                                        strTBIL = model7.TBIL.ToString();
                                        list.Add(new ListValue
                                        {
                                            strMark = "$zdg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });

                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.TBIL)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.TBIL) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strTBIL = model7.TBIL.ToString() + "↑";
                                            }
                                            else if (Convert.ToDouble(model7.TBIL) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strTBIL = model7.TBIL.ToString() + "↓";
                                            }

                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "血清肌酐") //肌酐SCR
                                    {
                                        strSCR = model7.SCR.ToString();
                                        list.Add(new ListValue
                                        {
                                            strMark = "$jgg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });
                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.SCR)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.SCR) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strSCR = model7.SCR.ToString() + "↑";
                                            }
                                            else if (Convert.ToDouble(model7.SCR) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strSCR = model7.SCR.ToString() + "↓";
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "血尿素氮") //尿素氮BUN   
                                    {
                                        strBUN = model7.BUN.ToString();
                                        list.Add(new ListValue
                                        {
                                            strMark = "$sdg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });
                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.BUN)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.BUN) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strBUN = model7.BUN.ToString() + "↑";
                                            }
                                            else if (Convert.ToDouble(model7.BUN) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                strBUN = model7.BUN.ToString() + "↓";
                                            }

                                        }
                                        continue;
                                    }
                                }
                            }
                        }
                        #endregion

                        #region

                        list.Add(new ListValue     //血红蛋白
                        {
                            strMark = "$xhdb",
                            strVal = strHB
                        });
                        list.Add(new ListValue     //白细胞数
                        {
                            strMark = "$bxbs",
                            strVal = strWBC
                        });
                        list.Add(new ListValue     //血小板PLT
                        {
                            strMark = "$xxb",
                            strVal = strPLT
                        });
                        list.Add(new ListValue     //总胆固醇（TC）
                        {
                            strMark = "$zdgc",
                            strVal = strTC
                        });

                        list.Add(new ListValue     //甘油三酯（TG）
                        {
                            strMark = "$gysz",
                            strVal = strTG
                        });

                        list.Add(new ListValue     //高密度脂蛋白HeiCho
                        {
                            strMark = "$gzdb",
                            strVal = strHeiCho
                        });
                        list.Add(new ListValue     //低密度脂蛋白LowCho
                        {
                            strMark = "$dzdb",
                            strVal = strLowCho
                        });

                        list.Add(new ListValue     //尿蛋白PRO
                        {
                            strMark = "$ncdb",
                            strVal = model7.PRO
                        });
                        list.Add(new ListValue     //尿糖GLU
                        {
                            strMark = "$ncnt",
                            strVal = model7.GLU
                        });
                        list.Add(new ListValue     //尿酮体KET
                        {
                            strMark = "$nctt",
                            strVal = model7.KET
                        });
                        list.Add(new ListValue     //尿潜血BLD
                        {
                            strMark = "$ncqx",
                            strVal = model7.BLD
                        });
                        list.Add(new ListValue     // 尿常规其他
                        {
                            strMark = "%nqt",
                            strVal = model7.UrineOther
                        });
                        if ((model7.PRO + model7.GLU + model7.KET + model7.BLD + model7.UrineOther).Contains("+"))
                        {
                            flagEx = true;
                        }
                        list.Add(new ListValue    //空腹血糖FPGL
                        {
                            strMark = "$kfxt",
                            strVal = strFPGL
                        });

                        list.Add(new ListValue    //谷丙转氨酶SGPT
                        {
                            strMark = "$bzam",
                            strVal = strSGPT
                        });
                        list.Add(new ListValue   //谷草转氨酶GOT
                        {
                            strMark = "$czam",
                            strVal = strGOT
                        });
                        list.Add(new ListValue   //总胆红素TBIL
                        {
                            strMark = "$zdhs",
                            strVal = strTBIL
                        });
                        list.Add(new ListValue    //肌酐SCR
                        {
                            strMark = "$jig",
                            strVal = strSCR
                        });
                        list.Add(new ListValue   //尿素氮BUN
                        {
                            strMark = "$nsd",
                            strVal = strBUN
                        });
                        #endregion

                        string strECG = "", strECGex = "";
                        if (!string.IsNullOrEmpty(model7.ECG))
                        {
                            string[] ecg = model7.ECG.Split(new char[] { ',' });
                            foreach (string c in ecg)
                            {
                                switch (c)
                                {
                                    case "1":
                                        strECG = "1";
                                        break;
                                    case "2":
                                        strECG = "2";
                                        strECGex += "ST-T改变,";
                                        break;
                                    case "3":
                                        strECG = "2";
                                        strECGex += "陈旧性心肌梗塞,";
                                        break;
                                    case "4":
                                        strECG = "2";
                                        strECGex += "窦性心动过速,";
                                        break;
                                    case "5":
                                        strECG = "2";
                                        strECGex += "窦性心动过缓,";
                                        break;
                                    case "6":
                                        strECG = "2";
                                        strECGex += "早搏,";
                                        break;
                                    case "7":
                                        strECG = "2";
                                        strECGex += "房颤,";
                                        break;
                                    case "8":
                                        strECG = "2";
                                        strECGex += "房室传导阻滞,";
                                        break;
                                    case "9":
                                        strECG = "2";
                                        break;
                                }
                            }
                        }
                        list.Add(new ListValue
                        {
                            strMark = "#xdt",
                            strVal = strECG
                        });

                        if (!string.IsNullOrEmpty(model7.ECGEx))
                        {
                            strECGex += "其他:" + model7.ECGEx.Replace('\n', ';').Replace('\r', ' ').Replace(" ", "");
                        }
                        list.Add(new ListValue
                        {
                            strMark = "$xdtex",
                            strVal = strECGex
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#bc",
                            strVal = model7.BCHAO
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$BCex",
                            strVal = model7.BCHAOEx
                        });
                        string strex = "1";
                        if (flagEx)
                        {
                            strex = "2";
                        }
                        list.Add(new ListValue
                        {
                            strMark = "#tjjl",
                            strVal = strex
                        });
                    }

                    RecordsAssessmentGuideModel guidemodel = new RecordsAssessmentGuideDAL().GetModelByOutKey(model2.ID);
                    if (guidemodel != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "#tjjl",
                            strVal = guidemodel.IsNormal
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$Ex1",
                            strVal = guidemodel.Exception1
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$Ex2",
                            strVal = guidemodel.Exception2
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$Ex3",
                            strVal = guidemodel.Exception3
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$Ex4",
                            strVal = guidemodel.Exception4
                        });
                    }


                }
                //int Count = 0;
                OlderSelfCareabilityModel CareModel = new OlderSelfCareabilityBLL().GetModel(this.CardID);
                if (CareModel != null)
                {
                    OlderMedicineResultModel model4 = new OlderMedicineResultBLL().GetModel(this.CardID, CareModel.ID);
                    if (model4 != null)
                    {
                        string strzytz = "";
                        if (!string.IsNullOrEmpty(model4.Mild) && (model4.Mild == "1" || model4.Mild == "2"))
                        {
                            strzytz += "平和质、";

                        }
                        if (!string.IsNullOrEmpty(model4.Faint) && (model4.Faint == "1" || model4.Faint == "2"))
                        {
                            strzytz += "气虚质、";

                        }
                        if (!string.IsNullOrEmpty(model4.Yang) && (model4.Yang == "1" || model4.Yang == "2"))
                        {
                            strzytz += "阳虚质、";

                        }
                        if (!string.IsNullOrEmpty(model4.Yin) && (model4.Yin == "1" || model4.Yin == "2"))
                        {

                            strzytz += "阴虚质、";
                        }
                        if (!string.IsNullOrEmpty(model4.PhlegmDamp) && (model4.PhlegmDamp == "1" || model4.PhlegmDamp == "2"))
                        {
                            strzytz += "痰湿质、";
                        }
                        if (!string.IsNullOrEmpty(model4.Muggy) && (model4.Muggy == "1" || model4.Muggy == "2"))
                        {

                            strzytz += "湿热质、";
                        }
                        if (!string.IsNullOrEmpty(model4.BloodStasis) && (model4.BloodStasis == "1" || model4.BloodStasis == "2"))
                        {
                            strzytz += "血瘀质、";
                        }
                        if (!string.IsNullOrEmpty(model4.QiConstraint) && (model4.QiConstraint == "1" || model4.QiConstraint == "2"))
                        {
                            strzytz += "气郁质、";
                        }
                        if (!string.IsNullOrEmpty(model4.Characteristic) && (model4.Characteristic == "1" || model4.Characteristic == "2"))
                        {
                            strzytz += "特兼质、";
                        }
                        if (!string.IsNullOrEmpty(strzytz))
                        {
                            strzytz = strzytz.Trim(new char[] { '、' });
                        }
                        list.Add(new ListValue
                        {
                            strMark = "$zytz",
                            strVal = strzytz
                        });
                    }
                }
                list.Add(new ListValue
                {
                    strMark = "&photo",
                    strVal = PhotoPath + this.CardID + ".jpeg"
                });
                list.Add(new ListValue
                {
                    strMark = "&fkys",
                    strVal = SignPath + "_Doctor13.png"
                });
                return DrawItems.setPage("printXps\\" + this.PrintName, list);
            }
            return null;
        }
    }
}
