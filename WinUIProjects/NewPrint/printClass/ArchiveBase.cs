
using ReportPrint;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using System.IO;
using KangShuoTech.Utilities.Common;
using System.Configuration;

namespace printClass
{
    public class ArchiveBase : IGetReport
    {
        string community = ConfigHelper.GetSetNode("community");
        string area = ConfigHelper.GetSetNode("area");
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/" : ConfigurationManager.AppSettings["SignPath"].ToString(); //签名保存路径
        private string FingerPath = ConfigurationManager.AppSettings["FingerPath"] == null ? @"Finger/" : ConfigurationManager.AppSettings["FingerPath"].ToString(); //指纹采集路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "02个人基本信息表.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                DataSet list = new RecordsBaseInfoBLL().GetList("and IDCardNo='" + this.CardID + "'");
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
                string strjob = "";
                if (!string.IsNullOrEmpty(model.Job))
                {
                    strjob = (int.Parse(model.Job) - 1).ToString();
                }
                string strNation = "";
                if (!string.IsNullOrEmpty(model.Nation))
                {
                    switch (model.Nation)
                    {
                        case "1": strNation = "01"; break;
                        case "2": strNation = "99"; break;
                        default: break;
                    }
                }
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
                        strMark = "#sex",
                        strVal = model.Sex
                    },
                    new ListValue
                    {
                        strMark = "!cssj",
                        strVal = DrawItems.strToDate(model.Birthday, 2),
                        strType = "2"
                    },
                    new ListValue
                    {
                        strMark = "$idcard",
                        strVal = model.IDCardNo
                    },
                    new ListValue
                    {
                        strMark = "$gzdw",
                        strVal = model.WorkUnit
                    },
                    new ListValue
                    {
                        strMark = "$brdh",
                        strVal = model.Phone
                    },
                    new ListValue
                    {
                        strMark = "$lxrxm",
                        strVal = model.ContactName
                    },
                    new ListValue
                    {
                        strMark = "$lxrdh",
                        strVal = model.ContactPhone
                    },
                    new ListValue
                    {
                        strMark = "#cz",
                        strVal = model.LiveType
                    },
                    new ListValue
                    {
                        strMark = "$mzqt",
                        strVal = model.Minority
                    },
                    new ListValue
                    {
                        strMark = "#mz",
                        strVal = strNation
                    },
                    new ListValue
                    {
                        strMark = "#rh",
                        strVal =model.RH
                    },
                    new ListValue
                    {
                        strMark = "#xx",
                        strVal = model.BloodType=="5"?"":model.BloodType
                    },

                    new ListValue
                    {
                        strMark = "#whcd",
                        strVal = model.Culture=="10"?"":model.Culture
                    },
                    new ListValue
                    {
                        strMark = "#zy",
                        strVal = strjob
                    },
                    new ListValue
                    {
                        strMark = "#hy",
                        strVal = model.MaritalStatus
                    },
                    new ListValue
                    {
                        strMark = "#ylzf",
                        strVal = model.MedicalPayType
                    },
                    new ListValue
                    {
                        strMark = "$ylzfqt",
                        strVal = model.MedicalPayTypeOther
                    },
                    new ListValue
                    {
                        strMark = "#ywgm",
                        strVal = model.DrugAllergic
                    },
                    new ListValue
                    {
                        strMark = "$ywgmqt",
                        strVal = model.DrugAllergicOther
                    },
                    new ListValue
                    {
                        strMark = "#bls",
                        strVal = model.Exposure
                    },
                    new ListValue
                    {
                        strMark = "#cj",
                        strVal = model.DiseasEndition
                    },
                    new ListValue
                    {
                        strMark = "$cjqt",
                        strVal = model.DiseasEnditionEx
                    },
                    new ListValue
                    {
                        strMark = "#ycb",
                        strVal = model.Disease
                    },
                    new ListValue
                    {
                        strMark = "$ycbqt",
                        strVal = model.DiseaseEx
                    },
                    new ListValue
                    {
                        strMark = "$hzxm",
                        strVal = model.HouseName
                    },
                    new ListValue
                    {
                        strMark = "#zzqk",
                        strVal = model.LiveCondition
                    },
                    new ListValue
                    {
                        strMark = "$kh1",
                        strVal = model.TownMedicalCard
                    },
                    new ListValue
                    {
                        strMark = "$kh2",
                        strVal = model.ResidentMedicalCard
                    },
                    new ListValue
                    {
                        strMark = "$kh3",
                        strVal = model.PovertyReliefMedicalCard
                    },
                    new ListValue
                    {
                        strMark = "$hzidcard",
                        strVal = model.FamilyIDCardNo
                    },
                    new ListValue
                    {
                        strMark = "$jtrs",
                        strVal = DrawItems.objToStr(model.FamilyNum)
                    },
                    new ListValue
                    {
                        strMark = "%jtjg",
                        strVal =model.FamilyStructure
                    }

                };
                RecordsFamilyHistoryInfoModel model2 = new RecordsFamilyHistoryInfoDAL().GetModel(this.CardID);
                if (model2 != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "#jzfq",
                        strVal = model2.FatherHistory
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$fqqt",
                        strVal = model2.FatherHistoryOther
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#jzmq",
                        strVal = model2.MotherHistory
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$mqqt",
                        strVal = model2.MotherHistoryOther
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#jzxd",
                        strVal = model2.BrotherSisterHistory
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xdqt",
                        strVal = model2.BrotherSisterHistoryOther
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#jzzv",
                        strVal = model2.ChildrenHistory
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zvqt",
                        strVal = model2.ChildrenHistoryOther
                    });
                }
                DataSet list2 = new RecordsIllnessHistoryInfoDAL().GetList(" IDCardNo='" + this.CardID + "' and illnesstype='2'");
                if (list2 != null && list2.Tables.Count > 0)
                {
                    DataTable dataTable = list2.Tables[0];
                    if (dataTable.Rows.Count > 0)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "#ssx",
                            strVal = "2"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ss1",
                            strVal = DrawItems.objToStr(dataTable.Rows[0]["illnessnameother"])
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sssj1",
                            strVal = DrawItems.strToDate(dataTable.Rows[0]["diagnosetime"], 3)
                        });
                    }
                    if (dataTable.Rows.Count > 1)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$ss2",
                            strVal = DrawItems.objToStr(dataTable.Rows[1]["illnessnameother"])
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sssj2",
                            strVal = DrawItems.strToDate(dataTable.Rows[1]["diagnosetime"], 3)
                        });
                    }
                    if (dataTable.Rows.Count == 0)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "#ssx",
                            strVal = "1"
                        });
                    }
                }
                else
                {
                    list.Add(new ListValue
                    {
                        strMark = "#ssx",
                        strVal = "1"
                    });
                }
                list2 = new RecordsIllnessHistoryInfoDAL().GetList(" IDCardNo='" + this.CardID + "' and illnesstype='3'");
                if (list2 != null && list2.Tables.Count > 0)
                {
                    DataTable dataTable2 = list2.Tables[0];
                    if (dataTable2.Rows.Count > 0)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "#wsx",
                            strVal = "2"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ws1",
                            strVal = DrawItems.objToStr(dataTable2.Rows[0]["illnessnameother"])
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$wssj1",
                            strVal = DrawItems.strToDate(dataTable2.Rows[0]["diagnosetime"], 3)
                        });
                    }
                    if (dataTable2.Rows.Count > 1)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$ws2",
                            strVal = DrawItems.objToStr(dataTable2.Rows[1]["illnessnameother"])
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$wssj2",
                            strVal = DrawItems.strToDate(dataTable2.Rows[1]["diagnosetime"], 3)
                        });
                    }
                    if (dataTable2.Rows.Count == 0)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "#wsx",
                            strVal = "1"
                        });
                    }
                }
                else
                {
                    list.Add(new ListValue
                    {
                        strMark = "#wsx",
                        strVal = "1"
                    });
                }
                list2 = new RecordsIllnessHistoryInfoDAL().GetList(" IDCardNo='" + this.CardID + "' and illnesstype='4'");
                if (list2 != null && list2.Tables.Count > 0)
                {
                    DataTable dataTable3 = list2.Tables[0];
                    if (dataTable3.Rows.Count > 0)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "#sxw",
                            strVal = "2"
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sx1",
                            strVal = DrawItems.objToStr(dataTable3.Rows[0]["illnessnameother"])
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sxsj1",
                            strVal = DrawItems.strToDate(dataTable3.Rows[0]["diagnosetime"], 3)
                        });
                    }
                    if (dataTable3.Rows.Count > 1)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$sx2",
                            strVal = DrawItems.objToStr(dataTable3.Rows[1]["illnessnameother"])
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$sxsj2",
                            strVal = DrawItems.strToDate(dataTable3.Rows[1]["diagnosetime"], 3)
                        });
                    }
                    if (dataTable3.Rows.Count == 0)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "#sxw",
                            strVal = "1"
                        });
                    }
                }
                else
                {
                    list.Add(new ListValue
                    {
                        strMark = "#sxw",
                        strVal = "1"
                    });
                }
                list2 = new RecordsIllnessHistoryInfoDAL().GetList(" IDCardNo='" + this.CardID + "' and illnesstype='1'");
                if (list2 != null && list2.Tables.Count > 0)
                {
                    if (list2.Tables[0].Rows.Count > 0)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "#ssx",
                            strVal = "2"
                        });
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        List<ListValue> jws = this.getJws(i, list2.Tables[0]);
                        if (jws != null)
                        {
                            list.AddRange(jws);
                        }
                    }
                }
                else
                {
                    list.Add(new ListValue
                    {
                        strMark = "#ssx",
                        strVal = "1"
                    });
                }
                RecordsEnvironmentModel model3 = new RecordsEnvironmentDAL().GetModel(this.CardID);
                if (model3 != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "#cf",
                        strVal = model3.BlowMeasure
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#rl",
                        strVal = model3.FuelType
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#ys",
                        strVal = model3.DrinkWater
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#cs",
                        strVal = model3.Toilet
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#qc",
                        strVal = model3.LiveStockRail
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$qmriq",
                        strVal = DrawItems.strToDate(model3.SignDate)
                    });
                }

                list.Add(new ListValue
                {
                    strMark = "&qzj",
                    strVal = SignPath + model.IDCardNo + "_J.png"
                });

                if (community.Equals("聊城东昌府区") || area.Equals("菏泽"))
                {
                    if (File.Exists(SignPath + model.IDCardNo + "_B.png"))
                    {
                        list.Add(new ListValue
                        {
                            strMark = "&qzb",
                            strVal = SignPath + model.IDCardNo + "_B.png"
                        });
                    }
                    if (File.Exists(FingerPath + model.IDCardNo + "_Finger.png"))
                    {
                        list.Add(new ListValue
                        {
                            strMark = "&zwqz",
                            strVal = FingerPath + model.IDCardNo + "_Finger.png"
                        });
                    }
                }
                else
                {
                    if (File.Exists(SignPath + model.IDCardNo + "_B.png"))
                    {
                        list.Add(new ListValue
                        {
                            strMark = "&qzb",
                            strVal = SignPath + model.IDCardNo + "_B.png"
                        });
                    }
                    else if (File.Exists(FingerPath + model.IDCardNo + "_Finger.png"))
                    {
                        list.Add(new ListValue
                        {
                            strMark = "&qzb",
                            strVal = FingerPath + model.IDCardNo + "_Finger.png"
                        });
                    }
                }

                return DrawItems.setPage("printXps\\" + this.PrintName, list);
            }
            return null;
        }

        public List<ListValue> getJws(int i, DataTable dt)
        {
            if (dt.Rows.Count < i + 1)
            {
                return null;
            }
            List<ListValue> list = new List<ListValue>();
            string str = (i + 1).ToString();
            list.Add(new ListValue
            {
                strMark = "#jb" + str,
                strVal = DrawItems.objToStr(dt.Rows[i]["illnessname"])
            });
            list.Add(new ListValue
            {
                strMark = "$qj" + str,
                strVal = DrawItems.strToDate(dt.Rows[i]["diagnosetime"], 3)
            });
            if (!string.IsNullOrEmpty(DrawItems.objToStr(dt.Rows[i]["therioma"])))
            {
                list.Add(new ListValue
                {
                    strMark = "$exzl",
                    strVal = DrawItems.objToStr(dt.Rows[i]["therioma"])
                });
            }
            if (!string.IsNullOrEmpty(DrawItems.objToStr(dt.Rows[i]["jobillness"])))
            {
                list.Add(new ListValue
                {
                    strMark = "$zyb",
                    strVal = DrawItems.objToStr(dt.Rows[i]["jobillness"])
                });
            }
            if (!string.IsNullOrEmpty(DrawItems.objToStr(dt.Rows[i]["illnessother"])))
            {
                list.Add(new ListValue
                {
                    strMark = "$jwsqt",
                    strVal = DrawItems.objToStr(dt.Rows[i]["illnessother"])
                });
            }
            return list;
        }
    }
}
