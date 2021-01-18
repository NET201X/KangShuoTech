using System;
using System.Collections.Generic;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.DAL;
using ReportPrint;
using System.Windows.Documents;
using System.Data;
using System.IO;
using System.Windows.Forms;
using KangShuoTech.Utilities.Common;
using System.Text.RegularExpressions;
using KangShuoTech.DataAccessProjects.BLL;
using System.Configuration;

namespace printClass
{
    public class Blood_Urine : IGetReport
    {
        public int XueStart = 13;
        public int num = 1;

        string community = ConfigHelper.GetSetNode("community");
        string area = ConfigHelper.GetSetNode("area");
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Year/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Year//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                if (community.Equals("聊城韩集乡医院"))
                {
                    XueStart = 16;
                    return "33血生化、血常规、尿液数据表(聊城韩集乡医院).xps";
                }
                else if (community.Equals("顾官屯卫生院") || area.Equals("平度") || area.Equals("济南"))
                {
                    return "33血生化、血常规、尿液数据表(顾官屯).xps";
                }
                else if (area.Equals("乐陵") || area.Equals("菏泽") || area.Equals("聊城") || area.Equals("泰安"))
                {
                    //判断签字维护 检查医生的手写体图片是否存在,调用不同模板
                    if (File.Exists(SignPath + "_Doctor22.png"))
                    {
                        //打印-手写体检查医生
                        return "33血生化、血常规、尿液数据表(乐陵).xps";
                    }
                    else
                    {
                        //调用1模板，打印-打印体检查医生
                        return "33血生化、血常规、尿液数据表(乐陵)1.xps";
                    }
                }
                else if (community.Equals("威海美年大健康"))
                {
                    XueStart = 12;
                    return "33血生化、血常规、尿液数据表(威海美年大健康).xps";
                }
                if (area.Equals("禹城"))
                {
                    XueStart = 26;
                    return "33血生化、血常规、尿液数据表(禹城).xps";
                }
                else if (area.Equals("威海"))
                {
                    return "33血生化、血常规、尿液数据表(威海).xps";
                }
                return "33血生化、血常规、尿液数据表.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                string strYear = DateTime.Now.Year.ToString();
                string strPWhere = string.Format("IDCardNo='{0}' AND LEFT(CheckDate ,4)='{1}' ORDER BY CheckDate DESC LIMIT 0,1 ", this.CardID, strYear);

                RecordsCustomerBaseInfoModel CustomerModel = new RecordsCustomerBaseInfoDAL().GetModelByWhere(strPWhere);//获取本年度最新一笔

                if (CustomerModel != null) return true;
            }

            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="dtData">数据值</param>
        /// <param name="dtSH">xml文件内容</param>
        /// <param name="code">字段名</param>
        /// <param name="showFlag">字段有无内容是否打印，true有无内容均打印，false有内容打印</param>
        /// <returns></returns>
        public List<ListValue> CombinData(DataTable dtData, DataTable dtSH, string code, bool showFlag)
        {
            List<ListValue> list = new List<ListValue>();

            foreach (DataRow RowDate in dtData.Rows)
            {
                if (RowDate[code].ToString() != "" || showFlag)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$jcjg" + num.ToString(),
                        strVal = RowDate[code].ToString()
                    });

                    foreach (DataRow dtrow in dtSH.Rows)
                    {
                        if (dtrow["code"].ToString() == code)
                        {

                            list.Add(new ListValue
                            {
                                strMark = "$xmmc" + num.ToString(),
                                strVal = dtrow["name"].ToString()
                            });
                            list.Add(new ListValue
                            {
                                strMark = "$dw" + num.ToString(),
                                strVal = dtrow["measurement"].ToString()
                            });
                            if (code.Equals("HB"))
                            {
                                if (GetList(dtSH, list, "血红蛋白", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("WBC"))
                            {
                                if (GetList(dtSH, list, "白细胞", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("PLT"))
                            {
                                if (GetList(dtSH, list, "血小板", RowDate[code].ToString()))
                                    break;
                            }

                            else if (code.Equals("SGPT"))
                            {
                                if (GetList(dtSH, list, "血清谷丙转氨酶", RowDate[code].ToString()))
                                    break;
                            }
                            else if (code.Equals("GOT"))
                            {
                                if (GetList(dtSH, list, "血清谷草转氨酶", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("BP"))
                            {
                                if (GetList(dtSH, list, "白蛋白", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("CB"))
                            {
                                if (GetList(dtSH, list, "结合胆红素", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("TBIL"))
                            {
                                if (GetList(dtSH, list, "总胆红素", RowDate[code].ToString()))
                                    break;
                            }
                            else if (code.Equals("SCR"))
                            {
                                if (GetList(dtSH, list, "血清肌酐", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("BUN"))
                            {
                                if (GetList(dtSH, list, "血尿素氮", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("TC"))
                            {
                                if (GetList(dtSH, list, "总胆固醇", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("TG"))
                            {
                                if (GetList(dtSH, list, "甘油三酯", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("LowCho"))
                            {
                                if (GetList(dtSH, list, "血清低密度脂蛋白胆固醇", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("HeiCho"))
                            {
                                if (GetList(dtSH, list, "血清高密度脂蛋白胆固醇", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("UA"))
                            {
                                if (GetList(dtSH, list, "尿酸", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("GT"))
                            {
                                if (GetList(dtSH, list, "谷氨酰氨基转肽酶", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("TP"))
                            {
                                if (GetList(dtSH, list, "总蛋白", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("GLB"))
                            {
                                if (GetList(dtSH, list, "球蛋白", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            if (code.Equals("AG"))
                            {
                                if (GetList(dtSH, list, "白球比", RowDate[code].ToString()))
                                    break;
                            }
                            else
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "$fw" + num.ToString(),
                                    strVal = dtrow["minvalue"].ToString() + "-" + dtrow["maxvalue"].ToString()
                                });
                            }
                            if (RowDate[code].ToString() != "" && IsNum(RowDate[code].ToString()))
                            {
                                if (Convert.ToDouble(RowDate[code].ToString()) > Convert.ToDouble(dtrow["maxvalue"].ToString()))
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$ts" + num.ToString(),
                                        strVal = "↑"
                                    });
                                }
                                if (Convert.ToDouble(RowDate[code].ToString()) < Convert.ToDouble(dtrow["minvalue"].ToString()))
                                {
                                    list.Add(new ListValue
                                    {
                                        strMark = "$ts" + num.ToString(),
                                        strVal = "↓"
                                    });
                                }
                            }
                            break;
                        }

                    }
                    num++;
                }
            }
            return list;
        }

        public bool GetList(DataTable dtSH, List<ListValue> list, string codeName, string codeValue)
        {
            string strHBItem = codeName;
            if (model.Sex == "1")
            {
                strHBItem = $"{codeName}男";
            }
            else if (model.Sex == "2")
            {
                strHBItem = $"{codeName}女";
            }
            DataRow[] dr = dtSH.Select("name='" + strHBItem + "'");
            DataRow[] dr2 = dtSH.Select($"name='{codeName}'");
            if (dr.Length > 0)
            {
                list.Add(new ListValue
                {
                    strMark = "$fw" + num.ToString(),
                    strVal = dr[0]["minvalue"].ToString() + "-" + dr[0]["maxvalue"].ToString()
                });
                if (!string.IsNullOrEmpty(codeValue) && IsNum(codeValue))
                {
                    if (Convert.ToDouble(codeValue) > Convert.ToDouble(dr[0]["maxvalue"].ToString()))
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$ts" + num.ToString(),
                            strVal = "↑"
                        });
                    }
                    if (Convert.ToDouble(codeValue) < Convert.ToDouble(dr[0]["minvalue"].ToString()))
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$ts" + num.ToString(),
                            strVal = "↓"
                        });
                    }
                }
                return true;
            }
            else if (dr2.Length > 0)
            {
                list.Add(new ListValue
                {
                    strMark = "$fw" + num.ToString(),
                    strVal = dr2[0]["minvalue"].ToString() + "-" + dr2[0]["maxvalue"].ToString()
                });
                if (!string.IsNullOrEmpty(codeValue) && IsNum(codeValue))
                {
                    if (Convert.ToDouble(codeValue) > Convert.ToDouble(dr2[0]["maxvalue"].ToString()))
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$ts" + num.ToString(),
                            strVal = "↑"
                        });
                    }
                    if (Convert.ToDouble(codeValue) < Convert.ToDouble(dr2[0]["minvalue"].ToString()))
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$ts" + num.ToString(),
                            strVal = "↓"
                        });
                    }
                }
                return true;
            }
            return false;

        }

        //判断是数字
        public static bool IsNum(string value)
        {
            return Regex.IsMatch(value, @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$");
        }

        public RecordsBaseInfoModel model { get; set; }

        public FixedDocumentSequence getReport()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                this.model = new RecordsBaseInfoBLL().GetModel(this.CardID);
                string strsex = "", strage = "";

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
                    },
                    new ListValue
                    {
                        strMark="$idcard",
                        strVal=model.IDCardNo
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
                    }
                };

                string strUnit = "";
                string orgcode = ConfigHelper.GetNode("orgCode");
                string TownCode = (orgcode.Length < 9) ? "" : orgcode.Substring(0, 9);

                if (!string.IsNullOrEmpty(TownCode))
                {
                    SysOrgTownModel TownModel = new SysOrgTownBLL().GetModel(TownCode);
                    strUnit = TownModel.Name;
                }

                list.Add(new ListValue
                {
                    strMark = "^Unit",
                    strVal = strUnit
                });

                string strYear = DateTime.Now.Year.ToString();
                string strPWhere = string.Format("IDCardNo='{0}' and LEFT(CheckDate ,4)='{1}' ORDER BY CheckDate DESC LIMIT 0,1 ", this.CardID, strYear);
                RecordsCustomerBaseInfoModel model2 = new RecordsCustomerBaseInfoDAL().GetModelByWhere(strPWhere);//获取本年度最新一笔
                DataSet AssistDateSet = new DataSet();

                if (model2 != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$tjrq",
                        strVal = DrawItems.strToDate(model2.CheckDate, 1)
                    });

                    AssistDateSet = new RecordsAssistCheckDAL().GetList("OutKey=" + model2.ID);

                    strYear = Convert.ToDateTime(model2.CheckDate).ToString("yyyy");
                }
                else
                {
                    list.Add(new ListValue
                    {
                        strMark = "$tjrq",
                        strVal = DrawItems.strToDate(DateTime.Now.Date, 1)
                    });
                }

                DataTable dtSH = null;
                if (File.Exists(Application.StartupPath + "\\SHValueRange.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(Application.StartupPath + "\\SHValueRange.xml");
                    dtSH = ds.Tables[0];
                }

                // 血常规数据 
                if (AssistDateSet.Tables.Count > 0)
                {
                    string strXuex = "";
                    switch (AssistDateSet.Tables[0].Rows[0]["BloodType"].ToString())
                    {
                        case "1": strXuex = "A型"; break;
                        case "2": strXuex = "B型"; break;
                        case "3": strXuex = "O型"; break;
                        case "4": strXuex = "AB型"; break;
                        default: break;
                    }

                    list.Add(new ListValue
                    {
                        strMark = "$xx",
                        strVal = strXuex
                    });

                    #region 禹城乙肝五项

                    if (area == "禹城")
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$xmmc" + num.ToString(),
                            strVal = "乙肝表面抗原"
                        });
                        if (AssistDateSet.Tables[0].Rows[0]["HBSAG"].ToString() == "1")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "-"
                            });
                        }
                        else if (AssistDateSet.Tables[0].Rows[0]["HBSAG"].ToString() == "2")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "+"
                            });
                        }
                        else if (AssistDateSet.Tables[0].Rows[0]["HBSAG"].ToString() == "3")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "+-"
                            });
                        }
                        num++;

                        list.Add(new ListValue
                        {
                            strMark = "$xmmc" + num.ToString(),
                            strVal = "乙肝表面抗体"
                        });
                        if (AssistDateSet.Tables[0].Rows[0]["HBSAB"].ToString() == "1")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "-"
                            });
                        }
                        else if (AssistDateSet.Tables[0].Rows[0]["HBSAB"].ToString() == "2")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "+"
                            });
                        }
                        else if (AssistDateSet.Tables[0].Rows[0]["HBSAB"].ToString() == "3")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "+-"
                            });
                        }
                        num++;

                        list.Add(new ListValue
                        {
                            strMark = "$xmmc" + num.ToString(),
                            strVal = "乙肝e抗原"
                        });
                        if (AssistDateSet.Tables[0].Rows[0]["HBEAG"].ToString() == "1")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "-"
                            });
                        }
                        else if (AssistDateSet.Tables[0].Rows[0]["HBEAG"].ToString() == "2")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "+"
                            });
                        }
                        else if (AssistDateSet.Tables[0].Rows[0]["HBEAG"].ToString() == "3")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "+-"
                            });
                        }
                        num++;

                        list.Add(new ListValue
                        {
                            strMark = "$xmmc" + num.ToString(),
                            strVal = "乙肝e抗体"
                        });
                        if (AssistDateSet.Tables[0].Rows[0]["HBEAB"].ToString() == "1")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "-"
                            });
                        }
                        else if (AssistDateSet.Tables[0].Rows[0]["HBEAB"].ToString() == "2")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "+"
                            });
                        }
                        else if (AssistDateSet.Tables[0].Rows[0]["HBEAB"].ToString() == "3")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "+-"
                            });
                        }
                        num++;

                        list.Add(new ListValue
                        {
                            strMark = "$xmmc" + num.ToString(),
                            strVal = "乙肝核心抗体"
                        });
                        if (AssistDateSet.Tables[0].Rows[0]["HBCAB"].ToString() == "1")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "-"
                            });
                        }
                        else if (AssistDateSet.Tables[0].Rows[0]["HBCAB"].ToString() == "2")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "+"
                            });
                        }
                        else if (AssistDateSet.Tables[0].Rows[0]["HBCAB"].ToString() == "3")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcjg" + num.ToString(),
                                strVal = "+-"
                            });
                        }
                        num++;
                    }

                    #endregion

                    // 生化常规数据
                    if (community.Equals("聊城韩集乡医院"))
                    {
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "TP", true));//总蛋白
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "GLB", true));//球蛋白
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "AG", true));//白球比
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "CB", true));//直接胆红素 
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "IBIL", true));//间接胆红素
                    }

                    if (area.Equals("禹城"))
                    {
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "FPGL", true));//空腹血糖
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "TC", true));//总胆固醇
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "TG", true));//甘油三脂
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "HeiCho", true));//高密度脂蛋白
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "LowCho", true));//低密度脂蛋白
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "TP", true));//总蛋白
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "GLB", true));//球蛋白
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "BP", true));//白蛋白
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "AG", true));//白球比
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "GOT", true));//血清谷草氨酸
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "SGPT", true));//血清谷丙氨酸
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "GT", true));//谷氨酰氨基转肽酶
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "TBIL", true));//总胆红素
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "SCR", true));//血清肌酐
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "BUN", true));//血尿素氮
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "UA", true));//尿酸

                        XueStart = 26;
                    }
                    else if (area.Equals("乐陵"))
                    {
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "BP", true));//白蛋白
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "CB", true));//结合胆红素
                    }

                    if (!area.Equals("禹城"))
                    {
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "TBIL", true));//总胆红素
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "GOT", true));//血清谷草氨酸
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "SGPT", true));//血清谷丙氨酸
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "TC", true));//总胆固醇
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "TG", true));//甘油三脂
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "LowCho", true));//低密度脂蛋白
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "HeiCho", true));//高密度脂蛋白
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "SCR", true));//血清肌酐
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "BUN", true));//血尿素氮
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "FPGL", true));//空腹血糖
                    }

                    if (community.Equals("威海美年大健康"))
                    {
                        list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "UA", false));//血清尿酸
                        XueStart = 12;
                    }
                }

                // 血常规
                num = XueStart;

                list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "HB", false));//血红蛋白
                list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "PLT", false));//血小板
                list.AddRange(CombinData(AssistDateSet.Tables[0], dtSH, "WBC", false));//白细胞

                //血液细胞检测报告
                string strWhere = string.Format("IDCardNo='{0}' AND LEFT(TestTime ,4)='{1}' ORDER BY TestTime DESC,ID DESC LIMIT 0,1 ", this.CardID, strYear);
                DataSet BlooDt = new RecordsxqDAL().GetDT(strWhere);

                if (BlooDt.Tables.Count > 0)
                {
                    //血液细胞数据
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "NEU_B", false));//中性粒细胞百分比
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "LYMPH_B", false));//淋巴细胞百分比
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "MON_B", false));//单核细胞百分比
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "EOS_B", false));//嗜酸性粒细胞百分比
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "BAS_B", false));//嗜碱性粒细胞百分比
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "NEU_N", false));//中性粒细胞数目
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "LYMPH_N", false));//淋巴细胞数目
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "MON_N", false));//单核细胞数目
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "EOS_N", false));//嗜酸性粒细胞数目
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "BAS_N", false));//嗜碱性粒细胞数目
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "RBC", false));//红细胞数目
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "HCT", false));//红细胞压积
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "MCV", false));//平均红细胞体积
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "MCH", false));//平均红细胞血红蛋白含量
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "MCHC", false));//平均红细胞血红蛋白浓度
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "RDW_CV", false));//红细胞分布宽度变异系数
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "RDW_SD", false));//红细胞分布宽度标准差
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "MPV", false));//平均血小板体积
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "PDW", false));//血小板分布宽度
                    list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "PCT", false));//血小板压积
                }

                //尿液常规
                string strUWhere = string.Format("IDCardNo='{0}' AND Devicetype=33 AND LEFT(UpdateData,4)='{1}' ORDER BY UpdateData DESC,ID DESC LIMIT 0,1 ", this.CardID, strYear);
                DataSet UrineDt = new DeviceInfoDAL().GetList(strUWhere);

                if (UrineDt != null && UrineDt.Tables.Count > 0 && UrineDt.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow UrineRow in UrineDt.Tables[0].Rows)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$bxp",
                            strVal = UrineRow["VALUE9"].ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$bxpf",
                            strVal = UrineRow["VALUE9"].ToString().Contains("+") ? "阳性" : "阴性"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$yxs",
                            strVal = UrineRow["VALUE8"].ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$yxsf",
                            strVal = UrineRow["VALUE8"].ToString().Contains("+") ? "阳性" : "阴性"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$nny",
                            strVal = UrineRow["VALUE1"].ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$nnyf",
                            strVal = UrineRow["VALUE1"].ToString().Contains("+") ? "阳性" : "阴性"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$dbz",
                            strVal = UrineRow["VALUE6"].ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$dbzf",
                            strVal = UrineRow["VALUE6"].ToString().Contains("+") ? "阳性" : "阴性"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$qx",
                            strVal = UrineRow["VALUE2"].ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$qxf",
                            strVal = UrineRow["VALUE2"].ToString().Contains("+") ? "阳性" : "阴性"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$phz",
                            strVal = UrineRow["VALUE7"].ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$tt",
                            strVal = UrineRow["VALUE4"].ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ttf",
                            strVal = UrineRow["VALUE4"].ToString().Contains("+") ? "阳性" : "阴性"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$dhs",
                            strVal = UrineRow["VALUE3"].ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$dhsf",
                            strVal = UrineRow["VALUE3"].ToString().Contains("+") ? "阳性" : "阴性"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ptt",
                            strVal = UrineRow["VALUE5"].ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$pttf",
                            strVal = UrineRow["VALUE5"].ToString().Contains("+") ? "阳性" : "阴性"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$vss",
                            strVal = UrineRow["VALUE11"].ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$vssf",
                            strVal = UrineRow["VALUE11"].ToString().Contains("+") ? "阳性" : "阴性"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$bz",
                            strVal = UrineRow["VALUE10"].ToString()
                        });
                        foreach (DataRow dtrow in dtSH.Rows)
                        {
                            if (dtrow["code"].ToString() == "SG")
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "$bzf",
                                    strVal = dtrow["minvalue"].ToString() + "-" + dtrow["maxvalue"].ToString()
                                });
                            }
                            if (dtrow["code"].ToString() == "PH")
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "$phf",
                                    strVal = dtrow["minvalue"].ToString() + "-" + dtrow["maxvalue"].ToString()
                                });
                            }
                        }
                    }
                }
                else
                {
                    if (AssistDateSet.Tables.Count > 0)//
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$dbz",
                            strVal = AssistDateSet.Tables[0].Rows[0]["PRO"].ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$dbzf",
                            strVal = AssistDateSet.Tables[0].Rows[0]["PRO"].ToString().Contains("+") ? "阳性" : "阴性"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ptt",
                            strVal = AssistDateSet.Tables[0].Rows[0]["GLU"].ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$pttf",
                            strVal = AssistDateSet.Tables[0].Rows[0]["GLU"].ToString().Contains("+") ? "阳性" : "阴性"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$tt",
                            strVal = AssistDateSet.Tables[0].Rows[0]["KET"].ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ttf",
                            strVal = AssistDateSet.Tables[0].Rows[0]["KET"].ToString().Contains("+") ? "阳性" : "阴性"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$qx",
                            strVal = AssistDateSet.Tables[0].Rows[0]["BLD"].ToString()
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$qxf",
                            strVal = AssistDateSet.Tables[0].Rows[0]["BLD"].ToString().Contains("+") ? "阳性" : "阴性"
                        });
                    }
                }
                list.Add(new ListValue
                {
                    strMark = "&q1",
                    strVal = SignPath + "_Doctor6.png"
                });
                if (area.Equals("平度") || area.Equals("济南") || area.Equals("禹城"))
                {
                    list.Add(new ListValue
                    {
                        strMark = "&q2",
                        strVal = SignPath + "_Doctor6.png"
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&q3",
                        strVal = SignPath + "_Doctor6.png"
                    });
                }
                else if (area.Equals("乐陵") || area.Equals("菏泽") || area.Equals("聊城") || area.Equals("泰安"))
                {
                    list.Add(new ListValue
                    {
                        strMark = "&q2",
                        strVal = SignPath + "_Doctor6.png"
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&q3",
                        strVal = SignPath + "_Doctor6.png"
                    });
                    if (File.Exists(SignPath + "_Doctor22.png"))
                    {
                        list.Add(new ListValue
                        {
                            strMark = "&q4",
                            strVal = SignPath + "_Doctor22.png"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "&q5",
                            strVal = SignPath + "_Doctor22.png"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "&q6",
                            strVal = SignPath + "_Doctor22.png"
                        });
                    }
                    else
                    {
                        RecordsSignatureModel signModel = new RecordsSignatureBLL().GetModel("签字维护");
                        if (signModel != null)
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$jcys1",
                                strVal = signModel.ExamineDoctor
                            });
                            list.Add(new ListValue
                            {
                                strMark = "$jcys2",
                                strVal = signModel.ExamineDoctor
                            });
                            list.Add(new ListValue
                            {
                                strMark = "$jcys3",
                                strVal = signModel.ExamineDoctor
                            });
                        }
                    }
                }

                return DrawItems.setPage("printXps\\" + this.PrintName, list);
            }

            return null;
        }
    }
}
