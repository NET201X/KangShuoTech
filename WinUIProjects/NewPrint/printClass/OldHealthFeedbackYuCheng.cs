using ReportPrint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.BLL;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

namespace printClass
{
    public class OldHealthFeedbackYuCheng : IGetReport
    {
        string community = ConfigHelper.GetSetNode("community");
        string area = ConfigHelper.GetSetNode("area");
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/" : ConfigurationManager.AppSettings["SignPath"].ToString(); //签名保存路径
        private string PhotoPath = ConfigurationManager.AppSettings["PhotoPath"] == null ? @"photo/" : ConfigurationManager.AppSettings["PhotoPath"].ToString(); //身份证照片路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                if (community == "顾官屯卫生院")
                {
                    return "35老年人健康体检反馈单(顾官屯).xps";
                }
                //else if (community.Equals("聊城东昌府区"))
                //{
                //    return "35老年人健康体检反馈单(道口铺).xps";
                //}
                else if (community.Equals("威海美年大健康"))
                {
                    return "35老年人健康体检反馈单(威海美年大健康).xps";
                }
                if (area.Equals("禹城"))
                {
                    return "35老年人健康体检反馈单(禹城).xps";
                }
                if (area.Equals("乐陵"))
                {
                    return "35老年人健康体检反馈单(乐陵).xps";
                }

                return "35老年人健康体检反馈单.xps";
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
                if (area.Equals("禹城") || area.Equals("乐陵"))
                {
                    list.Add(new ListValue
                    {
                        strMark = "$hjdz",
                        strVal = model.HouseHoldAddress
                    });
                }
                string strOrg = ConfigHelper.GetNode("orgCode").Substring(0, 9);
                string TownID = (strOrg.Length < 9) ? "" : strOrg.Substring(0, 9);
                if (!string.IsNullOrEmpty(TownID))
                {
                    SysOrgTownModel townmodel = new SysOrgTownBLL().GetModel(strOrg);
                    if (townmodel != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$wsy",
                            strVal = townmodel.Name
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$zxwsy",
                            strVal = townmodel.Name
                        });
                    }
                }
                if (community.Equals("聊城东昌府区"))
                {
                    list.Add(new ListValue
                    {
                        strMark = "$xyfw",
                        strVal = "150-90/90-60"
                    });
                }
                else
                {
                    list.Add(new ListValue
                    {
                        strMark = "$xyfw",
                        strVal = "140-90/90-60"
                    });
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

                        /*
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
                        */
                    }

                    RecordsSignatureModel modelsign = new RecordsSignatureBLL().GetModelByOutKey(model2.ID, model2.IDCardNo);
                    if (modelsign != null)
                    {
                        if (modelsign.FeedbackDate.HasValue && model != null)
                        {
                            list.Add(new ListValue
                            {
                                strMark = "&brqz",
                                strVal = SignPath + model.IDCardNo + "_" + Convert.ToDateTime(modelsign.FeedbackDate).ToString("yyyyMMdd") + "_B.png"
                            });
                            list.Add(new ListValue
                            {
                                strMark = "&jsqz",
                                strVal = SignPath + model.IDCardNo + "_" + Convert.ToDateTime(modelsign.FeedbackDate).ToString("yyyyMMdd") + "_J.png"
                            });
                        }
                    }

                    RecordsAssistCheckModel model7 = new RecordsAssistCheckBLL().GetModelByOutKey(model2.ID);

                    if (model7 != null)
                    {
                        string strHB = "", strWBC = "", strPLT = "", strTC = "", strTG = "", strHeiCho = "", strLowCho = "",
                            strFPGL = "", strSGPT = "", strGOT = "", strTBIL = "", strSCR = "", strBUN = "", strUA = "", strFPGLFW = "";

                        #region
                        if (File.Exists(Application.StartupPath + "\\SHValueRange.xml"))
                        {
                            DataSet ds = new DataSet();
                            ds.ReadXml(Application.StartupPath + "\\SHValueRange.xml");
                            DataTable dtSH = ds.Tables[0];

                            if (dtSH.Rows.Count > 0)
                            {
                                string strHBItem = "血红蛋白", strSGPTItem = "血清谷丙转氨酶", strGOTItem = "血清谷草转氨酶",
                                        strSCRItem = "血清肌酐";

                                if (model.Sex == "1")
                                {
                                    strHBItem = "血红蛋白男";
                                    strSGPTItem = "血清谷丙转氨酶男";
                                    strGOTItem = "血清谷草转氨酶男";
                                    strSCRItem = "血清肌酐男";

                                }
                                else if (model.Sex == "2")
                                {
                                    strHBItem = "血红蛋白女";
                                    strSGPTItem = "血清谷丙转氨酶女";
                                    strGOTItem = "血清谷草转氨酶女";
                                    strSCRItem = "血清肌酐女";
                                }


                                DataRow[] dr = dtSH.Select("name='" + strHBItem + "'");
                                DataRow[] dr2 = dtSH.Select("name='血红蛋白'");

                                if (dr.Length > 0)
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$hbg",
                                        strVal = dr[0]["minvalue"].ToString() + "-" + dr[0]["maxvalue"].ToString()
                                    });
                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.HB)) && !string.IsNullOrEmpty(dr[0]["minvalue"].ToString()) && !string.IsNullOrEmpty(dr[0]["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.HB) < Convert.ToDouble(dr[0]["minvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strHB = model7.HB.ToString() + "↓";
                                        }
                                        else if (Convert.ToDouble(model7.HB) > Convert.ToDouble(dr[0]["maxvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strHB = model7.HB.ToString() + "↑";
                                        }
                                        else
                                        {
                                            strHB = model7.HB.ToString();
                                        }

                                    }
                                }
                                else if (dr2.Length > 0)
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$hbg",
                                        strVal = dr2[0]["minvalue"].ToString() + "-" + dr2[0]["maxvalue"].ToString()
                                    });
                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.HB)) && !string.IsNullOrEmpty(dr2[0]["minvalue"].ToString()) && !string.IsNullOrEmpty(dr2[0]["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.HB) < Convert.ToDouble(dr2[0]["minvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strHB = model7.HB.ToString() + "↓";
                                        }
                                        else if (Convert.ToDouble(model7.HB) > Convert.ToDouble(dr2[0]["maxvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strHB = model7.HB.ToString() + "↑";
                                        }
                                        else
                                        {
                                            strHB = model7.HB.ToString();
                                        }
                                    }
                                }




                                dr = dtSH.Select("name='" + strSGPTItem + "'");
                                dr2 = dtSH.Select("name='血清谷丙转氨酶'");

                                if (dr.Length > 0)
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$gbg",
                                        strVal = dr[0]["minvalue"].ToString() + "-" + dr[0]["maxvalue"].ToString()
                                    });
                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.SGPT)) && !string.IsNullOrEmpty(dr[0]["minvalue"].ToString()) && !string.IsNullOrEmpty(dr[0]["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.SGPT) > Convert.ToDouble(dr[0]["maxvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strSGPT = model7.SGPT.ToString() + "↑";
                                        }
                                        else if (Convert.ToDouble(model7.SGPT) < Convert.ToDouble(dr[0]["minvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strSGPT = model7.SGPT.ToString() + "↓";
                                        }
                                        else
                                        {
                                            strSGPT = model7.SGPT.ToString();
                                        }
                                    }
                                }
                                else if (dr2.Length > 0)
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$gbg",
                                        strVal = dr2[0]["minvalue"].ToString() + "-" + dr2[0]["maxvalue"].ToString()
                                    });
                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.SGPT)) && !string.IsNullOrEmpty(dr2[0]["minvalue"].ToString()) && !string.IsNullOrEmpty(dr2[0]["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.SGPT) > Convert.ToDouble(dr2[0]["maxvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strSGPT = model7.SGPT.ToString() + "↑";
                                        }
                                        else if (Convert.ToDouble(model7.SGPT) < Convert.ToDouble(dr2[0]["minvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strSGPT = model7.SGPT.ToString() + "↓";
                                        }
                                        else
                                        {
                                            strSGPT = model7.SGPT.ToString();
                                        }
                                    }
                                }



                                dr = dtSH.Select("name='" + strGOTItem + "'");
                                dr2 = dtSH.Select("name='血清谷草转氨酶'");

                                if (dr.Length > 0)
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$gcg",
                                        strVal = dr[0]["minvalue"].ToString() + "-" + dr[0]["maxvalue"].ToString()
                                    });
                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.GOT)) && !string.IsNullOrEmpty(dr[0]["minvalue"].ToString()) && !string.IsNullOrEmpty(dr[0]["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.GOT) > Convert.ToDouble(dr[0]["maxvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strGOT = model7.GOT.ToString() + "↑";
                                        }
                                        else if (Convert.ToDouble(model7.GOT) < Convert.ToDouble(dr[0]["minvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strGOT = model7.GOT.ToString() + "↓";
                                        }
                                        else
                                        {
                                            strGOT = model7.GOT.ToString();
                                        }
                                    }
                                }
                                else if (dr2.Length > 0)
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$gcg",
                                        strVal = dr2[0]["minvalue"].ToString() + "-" + dr2[0]["maxvalue"].ToString()
                                    });
                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.GOT)) && !string.IsNullOrEmpty(dr2[0]["minvalue"].ToString()) && !string.IsNullOrEmpty(dr2[0]["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.GOT) > Convert.ToDouble(dr2[0]["maxvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strGOT = model7.GOT.ToString() + "↑";
                                        }
                                        else if (Convert.ToDouble(model7.GOT) < Convert.ToDouble(dr2[0]["minvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strGOT = model7.GOT.ToString() + "↓";
                                        }
                                        else
                                        {
                                            strGOT = model7.GOT.ToString();
                                        }
                                    }
                                }



                                dr = dtSH.Select("name='" + strSCRItem + "'");
                                dr2 = dtSH.Select("name='血清肌酐'");

                                if (dr.Length > 0)
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$jgg",
                                        strVal = dr[0]["minvalue"].ToString() + "-" + dr[0]["maxvalue"].ToString()
                                    });
                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.SCR)) && !string.IsNullOrEmpty(dr[0]["minvalue"].ToString()) && !string.IsNullOrEmpty(dr[0]["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.SCR) > Convert.ToDouble(dr[0]["maxvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strSCR = model7.SCR.ToString() + "↑";
                                        }
                                        else if (Convert.ToDouble(model7.SCR) < Convert.ToDouble(dr[0]["minvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strSCR = model7.SCR.ToString() + "↓";
                                        }
                                        else
                                        {
                                            strSCR = model7.SCR.ToString();
                                        }
                                    }
                                }
                                else if (dr2.Length > 0)
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$jgg",
                                        strVal = dr2[0]["minvalue"].ToString() + "-" + dr2[0]["maxvalue"].ToString()
                                    });
                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.SCR)) && !string.IsNullOrEmpty(dr2[0]["minvalue"].ToString()) && !string.IsNullOrEmpty(dr2[0]["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.SCR) > Convert.ToDouble(dr2[0]["maxvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strSCR = model7.SCR.ToString() + "↑";
                                        }
                                        else if (Convert.ToDouble(model7.SCR) < Convert.ToDouble(dr2[0]["minvalue"].ToString()))
                                        {
                                            flagEx = true;
                                            strSCR = model7.SCR.ToString() + "↓";
                                        }
                                        else
                                        {
                                            strSCR = model7.SCR.ToString();
                                        }
                                    }
                                }
                                foreach (DataRow item in dtSH.Rows)
                                {
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
                                        strFPGLFW = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString();


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
                                    if (community.Equals("威海美年大健康"))
                                    {
                                        if (item["name"].ToString() == "血清尿酸") //血清尿酸UA   
                                        {
                                            strUA = model7.UA.ToString();
                                            list.Add(new ListValue
                                            {
                                                strMark = "$nsg",
                                                strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                            });
                                            if (!string.IsNullOrEmpty(Convert.ToString(model7.UA)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                            {
                                                if (Convert.ToDouble(model7.UA) > Convert.ToDouble(item["maxvalue"].ToString()))
                                                {
                                                    flagEx = true;
                                                    strUA = model7.UA.ToString() + "↑";
                                                }
                                                else if (Convert.ToDouble(model7.UA) < Convert.ToDouble(item["minvalue"].ToString()))
                                                {
                                                    flagEx = true;
                                                    strUA = model7.UA.ToString() + "↓";
                                                }

                                            }
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                        if (community.Equals("聊城东昌府区"))
                        {
                            if (!string.IsNullOrEmpty(model.PopulationType) && model.PopulationType.Contains("7"))//糖尿病患者
                            {
                                strFPGL = model7.FPGL.ToString();
                                strFPGLFW = "3.9-7.0";
                                if (!string.IsNullOrEmpty(Convert.ToString(model7.FPGL)))
                                {
                                    if (Convert.ToDouble(model7.FPGL) >= 7.0)
                                    {
                                        flagEx = true;
                                        strFPGL = model7.FPGL.ToString() + "↑";
                                    }
                                    else if (Convert.ToDouble(model7.FPGL) < 3.9)
                                    {
                                        flagEx = true;
                                        strFPGL = model7.FPGL.ToString() + "↓";
                                    }
                                }
                            }
                        }
                        #region
                        list.Add(new ListValue
                        {
                            strMark = "$xtg",
                            strVal = strFPGLFW
                        });
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
                        if (community.Equals("威海美年大健康"))
                        {
                            list.Add(new ListValue   //血清尿酸UA
                            {
                                strMark = "$xqns",
                                strVal = strUA
                            });
                        }
                        list.Add(new ListValue     //血红蛋白
                        {
                            strMark = "$xhdb",
                            strVal = DrawItems.objToNumStr(model7.HB, 2)
                        });
                        list.Add(new ListValue     //白细胞数
                        {
                            strMark = "$bxbs",
                            strVal = DrawItems.objToNumStr(model7.WBC, 2)
                        });
                        list.Add(new ListValue     //血小板PLT
                        {
                            strMark = "$xxb",
                            strVal = DrawItems.objToNumStr(model7.PLT, 2)
                        });
                        list.Add(new ListValue     //总胆固醇（TC）
                        {
                            strMark = "$zdgc",
                            strVal = DrawItems.objToNumStr(model7.TC)
                        });

                        list.Add(new ListValue     //甘油三酯（TG）
                        {
                            strMark = "$gysz",
                            strVal = DrawItems.objToNumStr(model7.TG)
                        });

                        list.Add(new ListValue     //高密度脂蛋白HeiCho
                        {
                            strMark = "$gzdb",
                            strVal = DrawItems.objToNumStr(model7.HeiCho)
                        });
                        list.Add(new ListValue     //低密度脂蛋白LowCho
                        {
                            strMark = "$dzdb",
                            strVal = DrawItems.objToNumStr(model7.LowCho)
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
                        if ((model7.PRO + model7.GLU + model7.KET + model7.BLD).Contains("+"))
                        {
                            flagEx = true;
                        }
                        list.Add(new ListValue    //空腹血糖FPGL
                        {
                            strMark = "$kfxt",
                            strVal = DrawItems.objToNumStr(model7.FPGL, 2)
                        });

                        list.Add(new ListValue    //谷丙转氨酶SGPT
                        {
                            strMark = "$bzam",
                            strVal = DrawItems.objToNumStr(model7.SGPT)
                        });
                        list.Add(new ListValue   //谷草转氨酶GOT
                        {
                            strMark = "$czam",
                            strVal = DrawItems.objToNumStr(model7.GOT)
                        });
                        list.Add(new ListValue   //总胆红素TBIL
                        {
                            strMark = "$zdhs",
                            strVal = DrawItems.objToNumStr(model7.TBIL)
                        });
                        list.Add(new ListValue    //肌酐SCR
                        {
                            strMark = "$jig",
                            strVal = DrawItems.objToNumStr(model7.SCR)
                        });
                        list.Add(new ListValue   //尿素氮BUN
                        {
                            strMark = "$nsd",
                            strVal = DrawItems.objToNumStr(model7.BUN)
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
                        //string strex = "1";
                        //if (flagEx)
                        //{
                        //    strex = "2";
                        //}
                        //list.Add(new ListValue
                        //{
                        //    strMark = "#tjjl",
                        //    strVal = strex
                        //});
                    }

                    RecordsAssessmentGuideModel guidemodel = new RecordsAssessmentGuideDAL().GetModelByOutKey(model2.ID);
                    if (guidemodel != null)
                    {
                        string strException = "";
                        list.Add(new ListValue
                        {
                            strMark = "#tjjl",
                            strVal = guidemodel.IsNormal
                        });

                        //list.Add(new ListValue
                        //{
                        //    strMark = "$Ex1",
                        //    strVal = guidemodel.Exception1
                        //});
                        //list.Add(new ListValue
                        //{
                        //    strMark = "$Ex2",
                        //    strVal = guidemodel.Exception2
                        //});
                        //list.Add(new ListValue
                        //{
                        //    strMark = "$Ex3",
                        //    strVal = guidemodel.Exception3
                        //});
                        //list.Add(new ListValue
                        //{
                        //    strMark = "$Ex4",
                        //    strVal = guidemodel.Exception4
                        //});
                        strException = string.IsNullOrEmpty(guidemodel.Exception1) ? strException : strException + guidemodel.Exception1;
                        strException = string.IsNullOrEmpty(guidemodel.Exception2) ? strException : strException + guidemodel.Exception2;
                        strException = string.IsNullOrEmpty(guidemodel.Exception3) ? strException : strException + guidemodel.Exception3;
                        strException = string.IsNullOrEmpty(guidemodel.Exception4) ? strException : strException + guidemodel.Exception4;
                        if (area.Equals("淄博") && !string.IsNullOrEmpty(guidemodel.IsNormal) && guidemodel.IsNormal == "1")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "%Ex",
                                strVal = "无"
                            });
                        }
                        else
                        {
                            list.Add(new ListValue
                            {
                                strMark = "%Ex",
                                strVal = strException
                            });
                        }

                        if (community.Equals("聊城东昌府区"))
                        {

                            list.Add(new ListValue
                            {
                                strMark = "$jzmb",
                                strVal = DrawItems.objToNumStr(guidemodel.Arm, 0)
                            });
                            list.Add(new ListValue
                            {
                                strMark = "$zxdh",
                                strVal = ConfigHelper.GetSetNode("phone")
                            });
                        }
                        #region 顾官屯卫生院医生建议勾选
                        if (community == "顾官屯卫生院" || community.Equals("聊城东昌府区"))
                        {
                            string strEx = guidemodel.Exception1 + guidemodel.Exception2 + guidemodel.Exception3 + guidemodel.Exception4;
                            if (strEx.Contains("血脂"))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "@71",
                                    strVal = "1"
                                });
                            }
                            if (strEx.Contains("血糖"))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "@72",
                                    strVal = "1"
                                });
                            }
                            if (strEx.Contains("血常规"))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "@73",
                                    strVal = "1"
                                });
                            }
                            if (strEx.Contains("尿常规"))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "@74",
                                    strVal = "1"
                                });
                            }
                            if (strEx.Contains("肝功能"))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "@75",
                                    strVal = "1"
                                });
                            }
                            if (strEx.Contains("肾功能"))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "@76",
                                    strVal = "1"
                                });
                            }
                            if (strEx.Contains("心电图"))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "@81",
                                    strVal = "1"
                                });
                            }
                            if (strEx.Contains("B超"))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "@82",
                                    strVal = "1"
                                });
                            }
                        }
                        #endregion
                    }
                }

                OlderSelfCareabilityModel CareModel = new OlderSelfCareabilityBLL().GetModel(this.CardID);
                if (CareModel != null && community != "顾官屯卫生院") //顾官屯卫生院栏位显示空
                {
                    OlderMedicineResultModel model4 = new OlderMedicineResultBLL().GetModel(this.CardID, CareModel.ID);
                    if (model4 != null)
                    {
                        string strzytz = "";
                        int count = 0;

                        if (!string.IsNullOrEmpty(model4.Mild) && model4.Mild == "1")
                        {
                            strzytz += "平和质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.Faint) && model4.Faint == "1" && count < 3)
                        {
                            strzytz += "气虚质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.Yang) && model4.Yang == "1" && count < 3)
                        {
                            strzytz += "阳虚质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.Yin) && model4.Yin == "1" && count < 3)
                        {
                            strzytz += "阴虚质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.PhlegmDamp) && model4.PhlegmDamp == "1" && count < 3)
                        {
                            strzytz += "痰湿质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.Muggy) && model4.Muggy == "1" && count < 3)
                        {
                            strzytz += "湿热质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.BloodStasis) && model4.BloodStasis == "1" && count < 3)
                        {
                            strzytz += "血瘀质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.QiConstraint) && model4.QiConstraint == "1" && count < 3)
                        {
                            strzytz += "气郁质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.Characteristic) && model4.Characteristic == "1" && count < 3)
                        {
                            strzytz += "特兼质、";
                            count++;
                        }

                        if (!string.IsNullOrEmpty(model4.Mild) && model4.Mild == "2" && !strzytz.Contains("平和质") && count < 3)
                        {
                            strzytz += "平和质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.Faint) && model4.Faint == "2" && !strzytz.Contains("气虚质") && count < 3)
                        {
                            strzytz += "气虚质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.Yang) && model4.Yang == "2" && !strzytz.Contains("阳虚质") && count < 3)
                        {
                            strzytz += "阳虚质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.Yin) && model4.Yin == "2" && !strzytz.Contains("阴虚质") && count < 3)
                        {
                            strzytz += "阴虚质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.PhlegmDamp) && model4.PhlegmDamp == "2" && !strzytz.Contains("痰湿质") && count < 3)
                        {
                            strzytz += "痰湿质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.Muggy) && model4.Muggy == "2" && !strzytz.Contains("湿热质") && count < 3)
                        {
                            strzytz += "湿热质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.BloodStasis) && model4.BloodStasis == "2" && !strzytz.Contains("血瘀质") && count < 3)
                        {
                            strzytz += "血瘀质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.QiConstraint) && model4.QiConstraint == "2" && !strzytz.Contains("气郁质") && count < 3)
                        {
                            strzytz += "气郁质、";
                            count++;
                        }
                        if (!string.IsNullOrEmpty(model4.Characteristic) && model4.Characteristic == "2" && !strzytz.Contains("特兼质") && count < 3)
                        {
                            strzytz += "特兼质、";
                            count++;
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
                if (community.Equals("聊城东昌府区"))
                {
                    list.Add(new ListValue
                    {
                        strMark = "&fkys",
                        strVal = SignPath + "Year\\" + model2.CheckDate.Value.ToString("yyyy-MM-dd") + "\\_Doctor13.png"
                    });
                }
                else
                {
                    list.Add(new ListValue
                    {
                        strMark = "&fkys",
                        strVal = SignPath + "Year\\_Doctor13.png"
                    });
                }

                return DrawItems.setPage("printXps\\" + this.PrintName, list);
            }
            return null;
        }
    }
}