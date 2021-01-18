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
    public class HealthFeedback : IGetReport
    {
        string community = ConfigHelper.GetSetNode("community");
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/" : ConfigurationManager.AppSettings["SignPath"].ToString(); //签名保存路径
        private string PhotoPath = ConfigurationManager.AppSettings["PhotoPath"] == null ? @"photo/" : ConfigurationManager.AppSettings["PhotoPath"].ToString(); //身份证照片路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                if (community.Equals("聊城东昌府区"))
                {
                    return "32健康体检反馈单(道口铺).xps";
                }
                else
                {
                    return "32健康体检反馈单.xps";
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
                RecordsBaseInfoModel model = new RecordsBaseInfoBLL().GetModel(this.CardID);
                List<ListValue> list = new List<ListValue>
                {
                    new ListValue
                    {
                        strMark = "$name",
                        strVal = model.CustomerName
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
                    }
                };
                string strOrg = ConfigHelper.GetNode("orgCode").Substring(0, 9);
                string TownID = (strOrg.Length < 9) ? "" : strOrg.Substring(0, 9);
                if (!string.IsNullOrEmpty(TownID))
                {
                    SysOrgTownModel TownModel = new SysOrgTownBLL().GetModel(strOrg);
                    if (TownModel != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$wsy",
                            strVal = TownModel.Name
                        });
                    }
                }
                list.Add(new ListValue
                {
                    strMark = "&photo",
                    strVal = PhotoPath + this.CardID + ".jpeg"
                });
                DataTable dt_tz = new DataTable();

                if (File.Exists(Application.StartupPath + "\\mediphys.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(Application.StartupPath + "\\mediphys.xml");
                    dt_tz = ds.Tables[0];
                }

                string strjkzd = "";

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
                        list.Add(new ListValue
                        {
                            strMark = "$weight",
                            strVal = DrawItems.objToNumStr(model3.Weight)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$BIM",
                            strVal = DrawItems.objToNumStr(model3.BMI)
                        });

                        string strptz = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(model3.BMI)))
                        {
                            if (Convert.ToDouble(model3.BMI) < 18) strptz = "2";
                            else if (Convert.ToDouble(model3.BMI) >= 18 && Convert.ToDouble(model3.BMI) <= 24)
                                strptz = "1";
                            else if (Convert.ToDouble(model3.BMI) > 24 && Convert.ToDouble(model3.BMI) <= 28)
                                strptz = "3";
                            else strptz = "4";

                            if (Convert.ToDouble(model3.BMI) > 24)
                            {
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "偏胖")
                                    {
                                        strjkzd += "体重偏胖:" + item["jianyi"].ToString();
                                        break;
                                    }
                                }
                            }
                            else if (Convert.ToDouble(model3.BMI) < 18)
                            {
                                foreach (DataRow item in dt_tz.Rows)
                                {
                                    if (item["name"].ToString() == "偏瘦")
                                    {
                                        strjkzd += "体重偏瘦:" + item["jianyi"].ToString();
                                        break;
                                    }
                                }
                            }
                        }

                        list.Add(new ListValue
                        {
                            strMark = "#ptz",
                            strVal = strptz
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
                            strMark = "$rg",
                            strVal = DrawItems.objToNumStr(model3.RightHeight, 0)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$rd",
                            strVal = DrawItems.objToNumStr(model3.RightPre, 0)
                        });

                        string strpxy = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(model3.RightHeight)) || !string.IsNullOrEmpty(Convert.ToString(model3.RightPre)))
                        {
                            if (Convert.ToDouble(model3.RightHeight) > 139 || Convert.ToDouble(model3.RightPre) > 89)
                            {
                                DataRow[] dr = dt_tz.Select("name='高血压'");

                                if (dr.Length > 0)
                                {
                                    strjkzd += "血压偏高:" + dr[0]["jianyi"].ToString();
                                }

                                strpxy = "2";
                            }
                            else if (Convert.ToDouble(model3.RightHeight) < 90 || Convert.ToDouble(model3.RightPre) < 60)
                            {
                                DataRow[] dr = dt_tz.Select("name='低血压'");

                                if (dr.Length > 0)
                                {
                                    strjkzd += "血压偏低:" + dr[0]["jianyi"].ToString();
                                }

                                strpxy = "3";
                            }
                            else strpxy = "1";
                        }
                        list.Add(new ListValue
                        {
                            strMark = "#pxy",
                            strVal = strpxy
                        });
                    }

                    //尿液常规
                    string strYear = DateTime.Now.Year.ToString();
                    string strWhere = string.Format("IDCardNo='{0}' AND Devicetype=33 AND LEFT(UpdateData,4)='{1}' ORDER BY UpdateData DESC,ID DESC LIMIT 0,1 ", this.CardID, strYear);
                    DataSet UrineDt = new DeviceInfoDAL().GetList(strWhere);
                    string urineValue9 = "";

                    if (UrineDt.Tables.Count > 0)
                    {
                        foreach (DataRow UrineRow in UrineDt.Tables[0].Rows)
                        {
                            urineValue9 = UrineRow["VALUE9"].ToString();

                            list.Add(new ListValue
                            {
                                strMark = "$nbxb",
                                strVal = urineValue9
                            });
                        }
                    }

                    RecordsAssistCheckModel model7 = new RecordsAssistCheckBLL().GetModelByOutKey(model2.ID);
                    if (model7 != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$xhdb",
                            strVal = DrawItems.objToNumStr(model7.HB, 2)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$bxb",
                            strVal = DrawItems.objToNumStr(model7.WBC, 2)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xxb",
                            strVal = DrawItems.objToNumStr(model7.PLT, 2)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ndb",
                            strVal = model7.PRO
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$nt",
                            strVal = model7.GLU
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ntt",
                            strVal = model7.KET
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$qx",
                            strVal = model7.BLD
                        });

                        string strncgex = "", strncg = "";
                        strncg = model7.PRO + model7.GLU + model7.KET + model7.KET + urineValue9;

                        if (!string.IsNullOrEmpty(strncg))
                        {
                            if (strncg.Contains("+")) strncgex = "2";
                            else strncgex = "1";

                            //尿常规strncgjy中尿蛋白、尿糖、尿酮体、尿潜血
                            if (!string.IsNullOrEmpty(model7.PRO) && model7.PRO.Contains("+"))
                            {
                                DataRow[] dr = dt_tz.Select("name='尿蛋白异常'");

                                if (dr.Length > 0)
                                {
                                    strjkzd += "尿蛋白异常:" + dr[0]["jianyi"].ToString();
                                }
                            }
                            if (!string.IsNullOrEmpty(model7.GLU) && model7.GLU.Contains("+"))
                            {
                                DataRow[] dr = dt_tz.Select("name='尿糖异常'");

                                if (dr.Length > 0)
                                {
                                    strjkzd += "尿糖异常:" + dr[0]["jianyi"].ToString();
                                }
                            }
                            if (!string.IsNullOrEmpty(model7.KET) && model7.KET.Contains("+"))
                            {
                                DataRow[] dr = dt_tz.Select("name='尿酮体异常'");

                                if (dr.Length > 0)
                                {
                                    strjkzd += "尿酮体异常:" + dr[0]["jianyi"].ToString();
                                }
                            }
                            if (!string.IsNullOrEmpty(model7.BLD) && model7.BLD.Contains("+"))
                            {
                                DataRow[] dr = dt_tz.Select("name='尿潜血异常'");

                                if (dr.Length > 0)
                                {
                                    strjkzd += "尿潜血异常:" + dr[0]["jianyi"].ToString();
                                }
                            }
                            if (!string.IsNullOrEmpty(urineValue9) && urineValue9.Contains("+"))
                            {
                                DataRow[] dr = dt_tz.Select("name='尿白细胞异常'");

                                if (dr.Length > 0)
                                {
                                    strjkzd += "尿白细胞异常:" + dr[0]["jianyi"].ToString();
                                }
                            }
                        }

                        list.Add(new ListValue
                        {
                            strMark = "#png",
                            strVal = strncgex
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$kfxt",
                            strVal = DrawItems.objToNumStr(model7.FPGL, 2)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$gbzam",
                            strVal = DrawItems.objToNumStr(model7.SGPT)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$gczam",
                            strVal = DrawItems.objToNumStr(model7.GOT)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$zdhs",
                            strVal = DrawItems.objToNumStr(model7.TBIL)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xqjg",
                            strVal = DrawItems.objToNumStr(model7.SCR)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xnsd",
                            strVal = DrawItems.objToNumStr(model7.BUN)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$zdgc",
                            strVal = DrawItems.objToNumStr(model7.TC)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$gysz",
                            strVal = DrawItems.objToNumStr(model7.TG)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$bgas",
                            strVal = DrawItems.objToNumStr(model7.HCY)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$gzdb",
                            strVal = DrawItems.objToNumStr(model7.HeiCho)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$dzdb",
                            strVal = DrawItems.objToNumStr(model7.LowCho)
                        });
                        string strxdt = "",strECGex = ""; ;
                        if (!string.IsNullOrEmpty(model7.ECG))
                        {
                            if (model7.ECG == "1") strxdt = "正常";
                            else if (model7.ECG == "2") strxdt = "异常";
                            if (model7.ECG == "1")
                            {
                                strxdt = "正常";
                            }
                            else
                            {
                                strxdt = "异常";
                                string[] ecg = model7.ECG.Split(new char[] { ',' });
                                foreach (string c in ecg)
                                {
                                    switch (c)
                                    {
                                        case "1":
                                            break;
                                        case "2":
                                            strECGex += "ST-T改变,";
                                            break;
                                        case "3":
                                            strECGex += "陈旧性心肌梗塞,";
                                            break;
                                        case "4":
                                            strECGex += "窦性心动过速,";
                                            break;
                                        case "5":
                                            strECGex += "窦性心动过缓,";
                                            break;
                                        case "6":
                                            strECGex += "早搏,";
                                            break;
                                        case "7":
                                            strECGex += "房颤,";
                                            break;
                                        case "8":
                                            strECGex += "房室传导阻滞,";
                                            break;
                                        //case "9":
                                        //    strECGex += "其他：";
                                        //    break;
                                        default:
                                            break;
                                    }
                                }
                                strECGex += model7.ECGEx;
                            }
                        }
                        list.Add(new ListValue
                        {
                            strMark = "$xdt",
                            strVal = strxdt
                        });
   
                        list.Add(new ListValue
                        {
                            strMark = "$xdtex",
                            strVal = strECGex
                        });
                        string strBC = "";
                        if (!string.IsNullOrEmpty(model7.BCHAO))
                        {
                            if (model7.BCHAO == "1")
                            {
                                strBC = "正常";
                            }
                            else if (model7.BCHAO == "2")
                            {
                                strBC = "异常";
                            }
                        }
                        list.Add(new ListValue
                        {
                            strMark = "$fbBc",
                            strVal = strBC
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$Bcex",
                            strVal = model7.BCHAOEx
                        });
                    }

                    bool flagxhdb = false, flagbxb = false, flagxxb = false;
                    string strpxcg = "", strpkfxt = "", strpgb = "", strpgc = "", strpzdhs = "", strpjg = "",
                         strpsd = "", strpzdgc = "", strpsz = "", strHCY = "", strpgm="", strpdm="";

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
                                        DataRow[] drHB = dt_tz.Select("name='血红蛋白偏低'");

                                        if (drHB.Length > 0)
                                        {
                                            strjkzd += "血红蛋白偏低:" + drHB[0]["jianyi"].ToString();
                                        }

                                        flagbxb = true;
                                    }
                                    else if (Convert.ToDouble(model7.HB) > Convert.ToDouble(dr[0]["maxvalue"].ToString()))
                                    {
                                        DataRow[] drHB = dt_tz.Select("name='血红蛋白偏高'");

                                        if (drHB.Length > 0)
                                        {
                                            strjkzd += "血红蛋白偏高:" + drHB[0]["jianyi"].ToString();
                                        }

                                        flagbxb = true;
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
                                        DataRow[] drHB = dt_tz.Select("name='血红蛋白偏低'");

                                        if (drHB.Length > 0)
                                        {
                                            strjkzd += "血红蛋白偏低:" + drHB[0]["jianyi"].ToString();
                                        }

                                        flagbxb = true;
                                    }
                                    else if (Convert.ToDouble(model7.HB) > Convert.ToDouble(dr2[0]["maxvalue"].ToString()))
                                    {
                                        DataRow[] drHB = dt_tz.Select("name='血红蛋白偏高'");

                                        if (drHB.Length > 0)
                                        {
                                            strjkzd += "血红蛋白偏高:" + drHB[0]["jianyi"].ToString();
                                        }

                                        flagbxb = true;
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
                                        DataRow[] drSGPT = dt_tz.Select("name='血清谷丙转氨酶异常'");

                                        if (drSGPT.Length > 0)
                                        {
                                            strjkzd += "血清谷丙转氨酶异常:" + drSGPT[0]["jianyi"].ToString();
                                        }

                                        strpgb = "2";
                                    }
                                    else if (Convert.ToDouble(model7.SGPT) < Convert.ToDouble(dr[0]["minvalue"].ToString()))
                                    {
                                        DataRow[] drSGPT = dt_tz.Select("name='血清谷丙转氨酶异常'");

                                        if (drSGPT.Length > 0)
                                        {
                                            strjkzd += "血清谷丙转氨酶异常:" + drSGPT[0]["jianyi"].ToString();
                                        }

                                        strpgb = "3";
                                    }
                                    else strpgb = "1";
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
                                        DataRow[] drSGPT = dt_tz.Select("name='血清谷丙转氨酶异常'");

                                        if (drSGPT.Length > 0)
                                        {
                                            strjkzd += "血清谷丙转氨酶异常:" + drSGPT[0]["jianyi"].ToString();
                                        }

                                        strpgb = "2";
                                    }
                                    else if (Convert.ToDouble(model7.SGPT) < Convert.ToDouble(dr2[0]["minvalue"].ToString()))
                                    {
                                        DataRow[] drSGPT = dt_tz.Select("name='血清谷丙转氨酶异常'");

                                        if (drSGPT.Length > 0)
                                        {
                                            strjkzd += "血清谷丙转氨酶异常:" + drSGPT[0]["jianyi"].ToString();
                                        }

                                        strpgb = "3";
                                    }
                                    else strpgb = "1";
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
                                        DataRow[] drGOT = dt_tz.Select("name='血清谷草转氨酶异常'");

                                        if (drGOT.Length > 0)
                                        {
                                            strjkzd += "血清谷草转氨酶异常:" + drGOT[0]["jianyi"].ToString();
                                        }

                                        strpgc = "2";
                                    }
                                    else if (Convert.ToDouble(model7.GOT) < Convert.ToDouble(dr[0]["minvalue"].ToString()))
                                    {
                                        DataRow[] drGOT = dt_tz.Select("name='血清谷草转氨酶异常'");

                                        if (drGOT.Length > 0)
                                        {
                                            strjkzd += "血清谷草转氨酶异常:" + drGOT[0]["jianyi"].ToString();
                                        }

                                        strpgc = "3";
                                    }
                                    else strpgc = "1";
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
                                        DataRow[] drGOT = dt_tz.Select("name='血清谷草转氨酶异常'");

                                        if (drGOT.Length > 0)
                                        {
                                            strjkzd += "血清谷草转氨酶异常:" + drGOT[0]["jianyi"].ToString();
                                        }

                                        strpgc = "2";
                                    }
                                    else if (Convert.ToDouble(model7.GOT) < Convert.ToDouble(dr2[0]["minvalue"].ToString()))
                                    {
                                        DataRow[] drGOT = dt_tz.Select("name='血清谷草转氨酶异常'");

                                        if (drGOT.Length > 0)
                                        {
                                            strjkzd += "血清谷草转氨酶异常:" + drGOT[0]["jianyi"].ToString();
                                        }

                                        strpgc = "3";
                                    }
                                    else strpgc = "1";
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
                                        DataRow[] drSCR = dt_tz.Select("name='血清肌酐偏高'");

                                        if (drSCR.Length > 0)
                                        {
                                            strjkzd += "血清肌酐偏高:" + drSCR[0]["jianyi"].ToString();
                                        }

                                        strpjg = "2";
                                    }
                                    else if (Convert.ToDouble(model7.SCR) < Convert.ToDouble(dr[0]["minvalue"].ToString()))
                                    {
                                        DataRow[] drSCR = dt_tz.Select("name='血清肌酐偏低'");

                                        if (drSCR.Length > 0)
                                        {
                                            strjkzd += "血清肌酐偏低:" + drSCR[0]["jianyi"].ToString();
                                        }

                                        strpjg = "3";
                                    }
                                    else strpjg = "1";
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
                                        DataRow[] drSCR = dt_tz.Select("name='血清肌酐偏高'");

                                        if (drSCR.Length > 0)
                                        {
                                            strjkzd += "血清肌酐偏高:" + drSCR[0]["jianyi"].ToString();
                                        }

                                        strpjg = "2";
                                    }
                                    else if (Convert.ToDouble(model7.SCR) < Convert.ToDouble(dr2[0]["minvalue"].ToString()))
                                    {
                                        DataRow[] drSCR = dt_tz.Select("name='血清肌酐偏低'");

                                        if (drSCR.Length > 0)
                                        {
                                            strjkzd += "血清肌酐偏低:" + drSCR[0]["jianyi"].ToString();
                                        }

                                        strpjg = "3";
                                    }
                                    else strpjg = "1";
                                }
                            }
                            foreach (DataRow item in dtSH.Rows)
                            {
                                if (item["name"].ToString() == "同型半胱氨酸") //同型半胱氨酸   
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$bgdg",
                                        strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                    });

                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.HCY)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.HCY) > Convert.ToDouble(item["maxvalue"].ToString()))
                                        {
                                            strHCY = "2";
                                        }
                                        else if (Convert.ToDouble(model7.HCY) < Convert.ToDouble(item["minvalue"].ToString()))
                                        {
                                            strHCY = "3";
                                        }
                                        else
                                        {
                                            strHCY = "1";
                                        }
                                    }
                                    continue;
                                }
                                if (item["name"].ToString() == "白细胞") //白细胞   
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$wbcg",
                                        strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                    });
                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.WBC)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.WBC) < Convert.ToDouble(item["minvalue"].ToString()))
                                        {
                                            DataRow[] drWBC = dt_tz.Select("name='白细胞偏低'");

                                            if (drWBC.Length > 0)
                                            {
                                                strjkzd += "白细胞偏低:" + drWBC[0]["jianyi"].ToString();
                                            }

                                            flagxhdb = true;
                                        }
                                        else if (Convert.ToDouble(model7.WBC) > Convert.ToDouble(item["maxvalue"].ToString()))
                                        {
                                            DataRow[] drWBC = dt_tz.Select("name='白细胞偏高'");

                                            if (drWBC.Length > 0)
                                            {
                                                strjkzd += "白细胞偏高:" + drWBC[0]["jianyi"].ToString();
                                            }

                                            flagxhdb = true;
                                        }
                                    }
                                    continue;
                                }
                                if (item["name"].ToString() == "血小板") //血小板PLT
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$xxbg",
                                        strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                    });
                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.PLT)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.PLT) < Convert.ToDouble(item["minvalue"].ToString()))
                                        {
                                            DataRow[] drPLT = dt_tz.Select("name='血小板偏低'");

                                            if (drPLT.Length > 0)
                                            {
                                                strjkzd += "血小板偏低:" + drPLT[0]["jianyi"].ToString();
                                            }

                                            flagxxb = true;
                                        }
                                        else if (Convert.ToDouble(model7.PLT) > Convert.ToDouble(item["maxvalue"].ToString()))
                                        {
                                            DataRow[] drPLT = dt_tz.Select("name='血小板偏高'");

                                            if (drPLT.Length > 0)
                                            {
                                                strjkzd += "血小板偏高:" + drPLT[0]["jianyi"].ToString();
                                            }

                                            flagxxb = true;
                                        }

                                    }
                                    continue;
                                }
                                if (item["name"].ToString() == "空腹血糖") //空腹血糖FPGL
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$xtg",
                                        strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                    });

                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.FPGL)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.FPGL) > Convert.ToDouble(item["maxvalue"].ToString()))
                                        {
                                            DataRow[] drFPGL = dt_tz.Select("name='高血糖'");

                                            if (drFPGL.Length > 0)
                                            {
                                                strjkzd += "血糖偏高:" + drFPGL[0]["jianyi"].ToString();
                                            }

                                            strpkfxt = "2";
                                        }
                                        else if (Convert.ToDouble(model7.FPGL) < Convert.ToDouble(item["minvalue"].ToString()))
                                        {
                                            DataRow[] drFPGL = dt_tz.Select("name='低血糖'");

                                            if (drFPGL.Length > 0)
                                            {
                                                strjkzd += "血糖偏低:" + drFPGL[0]["jianyi"].ToString();
                                            }

                                            strpkfxt = "3";
                                        }
                                        else strpkfxt = "1";
                                    }
                                    continue;
                                }
                                if (item["name"].ToString() == "总胆红素") //总胆红素TBIL
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$zdg",
                                        strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                    });

                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.TBIL)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.TBIL) > Convert.ToDouble(item["maxvalue"].ToString()))
                                        {
                                            DataRow[] drTBIL = dt_tz.Select("name='总胆红素偏高'");

                                            if (drTBIL.Length > 0)
                                            {
                                                strjkzd += "总胆红素偏高:" + drTBIL[0]["jianyi"].ToString();
                                            }

                                            strpzdhs = "2";
                                        }
                                        else if (Convert.ToDouble(model7.TBIL) < Convert.ToDouble(item["minvalue"].ToString()))
                                        {
                                            DataRow[] drTBIL = dt_tz.Select("name='总胆红素偏低'");

                                            if (drTBIL.Length > 0)
                                            {
                                                strjkzd += "总胆红素偏低:" + drTBIL[0]["jianyi"].ToString();
                                            }

                                            strpzdhs = "3";
                                        }
                                        else strpzdhs = "1";
                                    }
                                    continue;
                                }
                                if (item["name"].ToString() == "血尿素氮") //尿素氮BUN   
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$sdg",
                                        strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                    });
                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.BUN)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.BUN) > Convert.ToDouble(item["maxvalue"].ToString()))
                                        {
                                            DataRow[] drBUN = dt_tz.Select("name='血尿素氮偏高'");

                                            if (drBUN.Length > 0)
                                            {
                                                strjkzd += "血尿素氮偏高:" + drBUN[0]["jianyi"].ToString();
                                            }

                                            strpsd = "2"; ;
                                        }
                                        else if (Convert.ToDouble(model7.BUN) < Convert.ToDouble(item["minvalue"].ToString()))
                                        {
                                            DataRow[] drBUN = dt_tz.Select("name='血尿素氮偏低'");

                                            if (drBUN.Length > 0)
                                            {
                                                strjkzd += "血尿素氮偏低:" + drBUN[0]["jianyi"].ToString();
                                            }

                                            strpsd = "3";
                                        }
                                        else strpsd = "1";
                                    }
                                    continue;
                                }
                                if (item["name"].ToString() == "总胆固醇") //总胆固醇（TC）
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$tcg",
                                        strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                    });
                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.TC)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.TC) < Convert.ToDouble(item["minvalue"].ToString()))
                                        {
                                            DataRow[] drTC = dt_tz.Select("name='总胆固醇偏低'");

                                            if (drTC.Length > 0)
                                            {
                                                strjkzd += "总胆固醇偏低:" + drTC[0]["jianyi"].ToString();
                                            }

                                            strpzdgc = "3";
                                        }
                                        else if (Convert.ToDouble(model7.TC) > Convert.ToDouble(item["maxvalue"].ToString()))
                                        {
                                            DataRow[] drTC = dt_tz.Select("name='总胆固醇偏高'");

                                            if (drTC.Length > 0)
                                            {
                                                strjkzd += "总胆固醇偏高:" + drTC[0]["jianyi"].ToString();
                                            }

                                            strpzdgc = "2";
                                        }
                                        else strpzdgc = "1";
                                    }
                                    continue;
                                }
                                if (item["name"].ToString() == "甘油三酯")  //甘油三酯（TG）
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$tgg",
                                        strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                    });

                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.TG)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.TG) > Convert.ToDouble(item["maxvalue"].ToString()))
                                        {
                                            DataRow[] drTG = dt_tz.Select("name='甘油三酯偏高'");

                                            if (drTG.Length > 0)
                                            {
                                                strjkzd += "甘油三酯偏高:" + drTG[0]["jianyi"].ToString();
                                            }

                                            strpsz = "2";
                                        }
                                        else if (Convert.ToDouble(model7.TG) < Convert.ToDouble(item["minvalue"].ToString()))
                                        {
                                            DataRow[] drTG = dt_tz.Select("name='甘油三酯偏低'");

                                            if (drTG.Length > 0)
                                            {
                                                strjkzd += "甘油三酯偏低:" + drTG[0]["jianyi"].ToString();
                                            }

                                            strpsz = "3";
                                        }
                                        else strpsz = "1";
                                    }
                                    continue;
                                }
                                if (item["name"].ToString() == "血清高密度脂蛋白胆固醇")  //血清高密度脂蛋白胆固醇
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$gzg",
                                        strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                    });

                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.HeiCho)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.HeiCho) > Convert.ToDouble(item["maxvalue"].ToString()))
                                        {
                                            strpgm = "2";
                                        }
                                        else if (Convert.ToDouble(model7.HeiCho) < Convert.ToDouble(item["minvalue"].ToString()))
                                        {
                                            strpgm = "3";
                                        }
                                        else strpgm = "1";
                                    }
                                    continue;
                                }
                                if (item["name"].ToString() == "血清低密度脂蛋白胆固醇")  //血清低密度脂蛋白胆固醇
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$dzg",
                                        strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                    });

                                    if (!string.IsNullOrEmpty(Convert.ToString(model7.LowCho)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                    {
                                        if (Convert.ToDouble(model7.LowCho) > Convert.ToDouble(item["maxvalue"].ToString()))
                                        {
                                            strpdm = "2";
                                        }
                                        else if (Convert.ToDouble(model7.LowCho) < Convert.ToDouble(item["minvalue"].ToString()))
                                        {
                                            strpdm = "3";
                                        }
                                        else strpdm = "1";
                                    }
                                    continue;
                                }
                            }
                        }
                    }
                    #endregion

                    if (!string.IsNullOrEmpty(Convert.ToString(model7.HB)) || !string.IsNullOrEmpty(Convert.ToString(model7.WBC)) || !string.IsNullOrEmpty(Convert.ToString(model7.PLT)))
                    {
                        if (flagxxb || flagxhdb || flagbxb) strpxcg = "2";
                        else strpxcg = "1";
                    }
                    list.Add(new ListValue
                    {
                        strMark = "#pxg",
                        strVal = strpxcg
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#pxt",
                        strVal = strpkfxt
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#pgb",
                        strVal = strpgb
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#pgc",
                        strVal = strpgc
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#bgp",
                        strVal = strHCY
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#pdh",
                        strVal = strpzdhs
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#pjg",
                        strVal = strpjg
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#psd",
                        strVal = strpsd
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#pdg",
                        strVal = strpzdgc
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#psz",
                        strVal = strpsz
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#pgm",
                        strVal = strpgm
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#pdm",
                        strVal = strpdm
                    });
                    list.Add(new ListValue
                    {
                        strMark = "%jkjy",
                        strVal = strjkzd
                    });
                    if (community.Equals("聊城东昌府区"))
                    {
                        list.Add(new ListValue
                        {
                            strMark = "&fkys",
                            strVal = SignPath + "Year\\" + model2.CheckDate.Value.ToString("yyyy-MM-dd") + "\\_Doctor13.png"
                        });
                    }
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
    
                    }
                }
     
                return DrawItems.setPage("printXps\\" + PrintName, list);
            }
            return null;
        }
    }
}
