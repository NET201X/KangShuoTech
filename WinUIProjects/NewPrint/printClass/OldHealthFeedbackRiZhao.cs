using ReportPrint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.Utilities.Common;

namespace printClass
{
    public class OldHealthFeedbackRiZhao : IGetReport
    {
        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "35老年人健康体检反馈单(日照街道社区).xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                RecordsBaseInfoModel model = new RecordsBaseInfoBLL().GetModel(this.CardID);

                TimeParser timeParser = new TimeParser();
                string strage = timeParser.GetAge(model.Birthday);
                if (Convert.ToInt32(strage) >= 65)
                {
                    DataSet list = new RecordsCustomerBaseInfoBLL().GetList(" IDCardNo='" + this.CardID + "'");
                    if (list != null && list.Tables.Count > 0 && list.Tables[0].Rows.Count > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public DataTable dtSH = null;

        //判断是数字
        public static bool IsNum(string value)
        {
            return Regex.IsMatch(value, @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$");
        }

        /// <summary>
        /// </summary>
        /// <param name="dtDate">数据值</param>
        /// <param name="dtSH">xml文件内容</param>
        /// <param name="Code">字段名</param>
        /// <param name="showFlag">字段有无内容是否打印，true有无内容均打印，false有内容打印</param>
        /// <returns></returns>
        public List<ListValue> CombinData(DataTable dtDate, DataTable dtSH, string Code, int num)
        {
            List<ListValue> list = new List<ListValue>();
            if (dtDate.Rows.Count < 1)//无数据时，显示范围
            {
                foreach (DataRow dtrow in dtSH.Rows)
                {
                    if (dtrow["code"].ToString() == Code)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$f" + num.ToString(),
                            strVal = dtrow["minvalue"].ToString() + "-" + dtrow["maxvalue"].ToString()
                        });
                    }
                }
            }
            foreach (DataRow RowDate in dtDate.Rows)
            {

                if (RowDate[Code].ToString() != "")
                {
                    list.Add(new ListValue
                    {
                        strMark = "$jg" + num.ToString(),
                        strVal = RowDate[Code].ToString()
                    });
                }
                foreach (DataRow dtrow in dtSH.Rows)
                {
                    if (dtrow["code"].ToString() == Code)
                    {
                        //list.Add(new ListValue
                        //{
                        //    strMark = "$dw" + num.ToString(),
                        //    strVal = dtrow["measurement"].ToString()
                        //});
                        list.Add(new ListValue
                        {
                            strMark = "$f" + num.ToString(),
                            strVal = dtrow["minvalue"].ToString() + "-" + dtrow["maxvalue"].ToString()
                        });
                        if (RowDate[Code].ToString() != "" && IsNum(RowDate[Code].ToString()))
                        {
                            if (Convert.ToDouble(RowDate[Code].ToString()) > Convert.ToDouble(dtrow["maxvalue"].ToString()))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "$t" + num.ToString(),
                                    strVal = "H"
                                });
                            }
                            if (Convert.ToDouble(RowDate[Code].ToString()) < Convert.ToDouble(dtrow["minvalue"].ToString()))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "$t" + num.ToString(),
                                    strVal = "L"
                                });
                            }
                        }
                        break;
                    }

                }
            }

            return list;
        }

        public FixedDocumentSequence getReport()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                bool flagEx = false;
                RecordsBaseInfoModel model = new RecordsBaseInfoBLL().GetModel(this.CardID);
                string strsex = "";
                TimeParser timeParser = new TimeParser();
                string strage = timeParser.GetAge(model.Birthday);

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
                        strMark = "$zxwsy",
                        strVal = model.CreateUnitName
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
                        strMark = "$lxdh",
                        strVal = model.Phone
                    },
                    new ListValue
                    {
                        strMark = "$address",
                        strVal = model.Address
                    }
                };
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
                            strMark = "$tz",
                            strVal = DrawItems.objToNumStr(model3.BMI)
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
                        list.Add(new ListValue
                        {
                            strMark = "$xyd",
                            strVal = DrawItems.objToNumStr(model3.RightPre, 0)
                        });
                        if (!string.IsNullOrEmpty(Convert.ToString(model3.RightHeight)) || !string.IsNullOrEmpty(Convert.ToString(model3.RightPre)))
                        {
                            if (Convert.ToDouble(model3.RightHeight) > 140 || Convert.ToDouble(model3.RightPre) > 90)
                            {
                                flagEx = true;
                            }
                            else if (Convert.ToDouble(model3.RightHeight) < 90 || Convert.ToDouble(model3.RightPre) < 60)
                            {
                                flagEx = true;
                            }
                        }
                    }
                    RecordsAssistCheckModel model7 = new RecordsAssistCheckBLL().GetModelByOutKey(model2.ID);
                    if (model7 != null)
                    {
                        list.Add(new ListValue     //血红蛋白
                        {
                            strMark = "$jg3",
                            strVal = DrawItems.objToNumStr(model7.HB, 2)
                        });
                        list.Add(new ListValue     //白细胞数
                        {
                            strMark = "$jg1",
                            strVal = DrawItems.objToNumStr(model7.WBC, 2)
                        });
                        list.Add(new ListValue     //血小板PLT
                        {
                            strMark = "$jg9",
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

                        #region
                        if (File.Exists(Application.StartupPath + "\\SHValueRange.xml"))
                        {
                            DataSet ds = new DataSet();
                            ds.ReadXml(Application.StartupPath + "\\SHValueRange.xml");
                            dtSH = ds.Tables[0];
                            if (dtSH.Rows.Count > 0)
                            {
                                foreach (DataRow item in dtSH.Rows)
                                {
                                    if (item["name"].ToString() == "血红蛋白") //血红蛋白  
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "$f3",
                                            strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                        });
                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.HB)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.HB) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$t3",
                                                    strVal = "L"
                                                });
                                            }
                                            else if (Convert.ToDouble(model7.HB) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$t3",
                                                    strVal = "H"
                                                });
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "白细胞") //白细胞   
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "$f1",
                                            strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                        });
                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.WBC)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.WBC) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$t1",
                                                    strVal = "L"
                                                });
                                            }
                                            else if (Convert.ToDouble(model7.WBC) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$t1",
                                                    strVal = "H"
                                                });
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "血小板") //血小板PLT
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "$f9",
                                            strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                        });
                                        if (string.IsNullOrEmpty(Convert.ToString(model7.PLT)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.PLT) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$t9",
                                                    strVal = "L"
                                                });
                                            }
                                            else if (Convert.ToDouble(model7.PLT) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$t9",
                                                    strVal = "H"
                                                });
                                            }

                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "总胆固醇") //总胆固醇（TC）
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "$tgg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });
                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.TC)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.TC) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$zdgct",
                                                    strVal = "L"
                                                });
                                            }
                                            else if (Convert.ToDouble(model7.TC) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$zdgct",
                                                    strVal = "H"
                                                });
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "甘油三酯")  //甘油三酯（TG）
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "$tcg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });

                                        if (!string.IsNullOrEmpty(Convert.ToString(model7.TG)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.TG) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$gyszt",
                                                    strVal = "H"
                                                });
                                            }
                                            else if (Convert.ToDouble(model7.TG) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$gyszt",
                                                    strVal = "L"
                                                });
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "血清高密度脂蛋白胆固醇") //高密度脂蛋白HeiCho
                                    {
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
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$gzdbt",
                                                    strVal = "H"
                                                });
                                            }
                                            else if (Convert.ToDouble(model7.HeiCho) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$gzdbt",
                                                    strVal = "L"
                                                });
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "血清低密度脂蛋白胆固醇")  //低密度脂蛋白LowCho
                                    {
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
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$dzdbt",
                                                    strVal = "H"
                                                });
                                            }
                                            else if (Convert.ToDouble(model7.LowCho) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$dzdbt",
                                                    strVal = "L"
                                                });
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == "空腹血糖") //空腹血糖FPGL
                                    {
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
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$kfxtt",
                                                    strVal = "H"
                                                });
                                            }
                                            else if (Convert.ToDouble(model7.FPGL) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$kfxtt",
                                                    strVal = "L"
                                                });
                                            }
                                        }
                                        continue;
                                    }

                                    if (item["name"].ToString() == "总胆红素") //总胆红素TBIL
                                    {
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
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$zdhst",
                                                    strVal = "H"
                                                });
                                            }
                                            else if (Convert.ToDouble(model7.TBIL) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$zdhst",
                                                    strVal = "L"
                                                });
                                            }
                                        }
                                        continue;
                                    }

                                    if (item["name"].ToString() == "血尿素氮") //尿素氮BUN   
                                    {
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
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$nsdt",
                                                    strVal = "H"
                                                });
                                            }
                                            else if (Convert.ToDouble(model7.BUN) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$nsdt",
                                                    strVal = "L"
                                                });
                                            }
                                        }
                                        continue;
                                    }

                                    if (item["name"].ToString() == "中间细胞") //中间细胞
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "$f15",
                                            strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                        });
                                        continue;
                                    }
                                    if (item["name"].ToString() == "中间细胞数百分比") //中间细胞数百分比
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "$f16",
                                            strVal = item["minvalue"].ToString() + "-" + item["maxvalue"].ToString()
                                        });
                                        continue;
                                    }
                                    string strgbg = "血清谷丙转氨酶", strgcg = "血清谷草转氨酶", strjgg = "血清肌酐";
                                    if (strsex == "男")
                                    {
                                        strgbg = "血清谷丙转氨酶(男)";
                                        strgcg = "血清谷草转氨酶(男)";
                                        strjgg = "血清肌酐(男)";
                                    }
                                    else if (strsex == "女")
                                    {
                                        strgbg = "血清谷丙转氨酶(女)";
                                        strgcg = "血清谷草转氨酶(女)";
                                        strjgg = "血清肌酐(女)";
                                    }
                                    if (item["name"].ToString() == strgbg) //谷丙转氨酶SGPT
                                    {
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
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$bzamt",
                                                    strVal = "H"
                                                });
                                            }
                                            else if (Convert.ToDouble(model7.SGPT) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$bzamt",
                                                    strVal = "L"
                                                });
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == strgcg) //谷草转氨酶GOT
                                    {
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
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$czamt",
                                                    strVal = "H"
                                                });
                                            }
                                            else if (Convert.ToDouble(model7.GOT) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$czamt",
                                                    strVal = "L"
                                                });
                                            }
                                        }
                                        continue;
                                    }
                                    if (item["name"].ToString() == strjgg) //肌酐SCR
                                    {
                                        list.Add(new ListValue
                                        {
                                            strMark = "$jgg",
                                            strVal = item["minvalue"].ToString() + " - " + item["maxvalue"].ToString()
                                        });
                                        if (!flagEx && !string.IsNullOrEmpty(Convert.ToString(model7.SCR)) && !string.IsNullOrEmpty(item["minvalue"].ToString()) && !string.IsNullOrEmpty(item["maxvalue"].ToString()))
                                        {
                                            if (Convert.ToDouble(model7.SCR) > Convert.ToDouble(item["maxvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$jigt",
                                                    strVal = "H"
                                                });
                                            }
                                            else if (Convert.ToDouble(model7.SCR) < Convert.ToDouble(item["minvalue"].ToString()))
                                            {
                                                flagEx = true;
                                                list.Add(new ListValue
                                                {
                                                    strMark = "$jigt",
                                                    strVal = "L"
                                                });
                                            }
                                        }
                                        continue;
                                    }

                                }
                            }
                        }
                        #endregion

                        #region  血常规

                        string strYear = model2.CheckDate.Value.Year.ToString();
                        string strWhere = string.Format("IDCardNo='{0}' AND LEFT(TestTime,4)='{1}' ORDER BY TestTime DESC,ID DESC LIMIT 0,1 ", this.CardID, strYear);
                        DataSet BlooDt = new RecordsxqDAL().GetDT(strWhere);

                        list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "RBC", 2));//红细胞数目
                        list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "HCT", 4));//红细胞压积
                        list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "MCV", 5));//平均红细胞体积
                        list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "MCH", 6));//平均红细胞血红蛋白含量
                        list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "MCHC", 7));//平均红细胞血红蛋白浓度
                        list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "RDW_CV", 8));//红细胞分布宽度变异系数
                        list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "MPV", 10));//平均血小板体积
                        list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "PCT", 11));//血小板压积
                        list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "PDW", 12));//血小板分布宽度
                        list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "LYMPH_N", 13));//淋巴细胞数目
                        list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "LYMPH_B", 14));//淋巴细胞百分比

                        list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "NEU_N", 17));//中性粒细胞数目
                        list.AddRange(CombinData(BlooDt.Tables[0], dtSH, "NEU_B", 18));//中性粒细胞百分比

                        //}
                        #endregion

                        #region 
                        //尿液常规
                        string strUWhere = string.Format("IDCardNo='{0}' AND Devicetype=33 AND LEFT(UpdateData,4)='{1}' ORDER BY UpdateData DESC,ID DESC LIMIT 0,1 ", this.CardID, strYear);
                        DataSet UrineDt = new DeviceInfoDAL().GetList(strUWhere);

                        if (UrineDt.Tables.Count > 0)
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

                    OlderSelfCareabilityModel modelC = new OlderSelfCareabilityBLL().GetModel(this.CardID);
                    if (modelC != null)
                    {
                        OlderMedicineResultModel model4 = new OlderMedicineResultBLL().GetModel(this.CardID, modelC.ID);
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
                            string strtzzsjy = "";
                            if (File.Exists(Application.StartupPath + "\\mediphys.xml"))
                            {
                                DataSet ds = new DataSet();
                                ds.ReadXml(Application.StartupPath + "\\mediphys.xml");
                                DataTable dt_tz = ds.Tables[0];
                                if (model4.Mild == "1" || model4.Mild == "2")
                                {
                                    foreach (DataRow item in dt_tz.Rows)
                                    {
                                        if (item["name"].ToString() == "平和质")
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            break;
                                        }
                                    }
                                }
                                if (model4.Faint == "1" || model4.Faint == "2")
                                {
                                    foreach (DataRow item in dt_tz.Rows)
                                    {
                                        if (item["name"].ToString() == "气虚质")
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            break;
                                        }
                                    }
                                }
                                if (model4.Yang == "1" || model4.Yang == "2")
                                {
                                    foreach (DataRow item in dt_tz.Rows)
                                    {
                                        if (item["name"].ToString() == "阳虚质")
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            break;
                                        }
                                    }
                                }
                                if (model4.Yin == "1" || model4.Yin == "2")
                                {
                                    foreach (DataRow item in dt_tz.Rows)
                                    {
                                        if (item["name"].ToString() == "阴虚质")
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            break;
                                        }
                                    }
                                }
                                if (model4.PhlegmDamp == "1" || model4.PhlegmDamp == "2")
                                {
                                    foreach (DataRow item in dt_tz.Rows)
                                    {
                                        if (item["name"].ToString() == "痰湿质")
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            break;
                                        }
                                    }
                                }
                                if (model4.Muggy == "1" || model4.Muggy == "2")
                                {
                                    foreach (DataRow item in dt_tz.Rows)
                                    {
                                        if (item["name"].ToString() == "湿热质")
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            break;
                                        }
                                    }
                                }
                                if (model4.BloodStasis == "1" || model4.BloodStasis == "2")
                                {
                                    foreach (DataRow item in dt_tz.Rows)
                                    {
                                        if (item["name"].ToString() == "血瘀质")
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            break;
                                        }
                                    }
                                }
                                if (model4.QiConstraint == "1" || model4.QiConstraint == "2")
                                {
                                    foreach (DataRow item in dt_tz.Rows)
                                    {
                                        if (item["name"].ToString() == "气郁质")
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            break;
                                        }
                                    }
                                }
                                if (model4.Characteristic == "1" || model4.Characteristic == "2")
                                {
                                    foreach (DataRow item in dt_tz.Rows)
                                    {
                                        if (item["name"].ToString() == "特兼质")
                                        {
                                            strtzzsjy = strtzzsjy + item["jianyi"].ToString();
                                            break;
                                        }
                                    }
                                }
                            }
                            list.Add(new ListValue
                            {
                                strMark = "$jkzd",
                                strVal = strtzzsjy
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
