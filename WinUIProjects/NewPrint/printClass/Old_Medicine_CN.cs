
using ReportPrint;
using System;
using System.Collections.Generic;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.Model;
using System.IO;
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.BLL;
using System.Configuration;

namespace printClass
{
    public class Old_Medicine_CN : IGetReport
    {
        private int OutKey = 0;
        private string area = ConfigHelper.GetSetNode("area");
        private string community = ConfigHelper.GetSetNode("community");
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/" : ConfigurationManager.AppSettings["SignPath"].ToString(); //签名保存路径
        private string FingerPath = ConfigurationManager.AppSettings["FingerPath"] == null ? @"Finger/" : ConfigurationManager.AppSettings["FingerPath"].ToString(); //指纹采集路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                if (area.Equals("济南"))
                {
                    return "24老年人中医体质辨识（济南随访）.xps";
                }
                else if (community.Equals("顾官屯卫生院"))
                {
                    //return "24老年人中医体质辨识（随访）.xps";
                    return "24老年人中医体质辨识(顾官屯随访).xps";
                }
                return "24老年人中医体质辨识（随访）.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                //查看本年度最新的一笔数据
                OlderSelfCareabilityModel olderself = new OlderSelfCareabilityBLL().GetModel(this.CardID);
                if (olderself != null)
                {
                    OlderMedicineCnModel model2 = new OlderMedicineCnBLL().GetModel(this.CardID, olderself.ID);
                    if (model2 != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public FixedDocumentSequence getReport()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
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
                        strMark = "$archiveid",
                        strVal = model.RecordID
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
                        strMark = "$name",
                        strVal = model.CustomerName
                    },
                    new ListValue
                    {
                        strMark = "$phone",
                        strVal = model.Phone
                    }

                };
                OlderSelfCareabilityModel olderself = new OlderSelfCareabilityBLL().GetModel(this.CardID);
                if (olderself != null)
                {
                    this.OutKey = olderself.ID;
                    OlderMedicineCnModel model2 = new OlderMedicineCnBLL().GetModel(this.CardID, this.OutKey);

                    if (model2 != null)
                    {
                        if (community.Equals("顾官屯卫生院"))
                        {
                            if (File.Exists(SignPath + "Year//" + Convert.ToDateTime(model2.RecordDate).ToString("yyyy-MM-dd") + "//" + "_Doctor24.png"))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "&ysqm",
                                    strVal = SignPath + "Year//" + Convert.ToDateTime(model2.RecordDate).ToString("yyyy-MM-dd") + "//" + "_Doctor24.png"
                                });
                            }
                            else
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "&ysqm",
                                    strVal = SignPath + "Year//" + "_Doctor24.png"
                                });
                            }
                            string a = FingerPath + model2.IDCardNo + Convert.ToDateTime(model2.RecordDate).ToString("yyyyMMdd") + "_Finger.png";
                            if (File.Exists(a))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "&zw",
                                    strVal = a
                                });
                            }
                        }
                        else
                        {
                            if (File.Exists(SignPath + "OldVisit//" + model2.IDCardNo + "_" + Convert.ToDateTime(model2.RecordDate).ToString("yyyyMMdd") + "_Asses.png"))
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "&ysqm",
                                    strVal = SignPath + "OldVisit//" + model2.IDCardNo + "_" + Convert.ToDateTime(model2.RecordDate).ToString("yyyyMMdd") + "_Asses.png"
                                });
                            }
                            else
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "&ysqm",
                                    strVal = SignPath + "Year//" + "_Doctor18.png"
                                    //strVal=ysqm
                                });
                            }
                        }
                        list.Add(new ListValue
                        {
                            strMark = "$ysqm",
                            strVal = olderself.FollowUpDoctor
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$tbrq",
                            strVal = DrawItems.strToDate(model2.RecordDate, 1)
                        });
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Coolfood), "pcl", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Defecate), "dbnz", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Defecatedry), "dbgz", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Tongue), "sthn", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Vein), "sxjm", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Energy), "jlcp", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Tired), "rypf", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Breath), "ryqd", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Voice), "shwl", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Emotion), "mmbl", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Spirit), "jsjz", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Alone), "shsl", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Fear), "gdhp", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Weight), "stcz", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Eye), "yjgs", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Abdomen), "fbfd", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Smell), "kkyw", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Thirsty), "kgyz", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.FootHand), "sjfl", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Spot), "msha", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Greasy), "mbyn", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Arms), "ztmm", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Mouth), "pfg", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Scratch), "pfh", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Skin), "qy", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Urticaria), "xmz", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Allergy), "gm", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Snore), "knkn", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Nasal), "bs", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Influenza), "yhgm", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Cold), "bnyh", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Stomach), "wbpl", 5));
                        list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model2.Eczema), "pfsz", 5));
                    }
                    OlderMedicineResultModel model3 = new OlderMedicineResultBLL().GetModel(this.CardID, this.OutKey);
                    if (model3 != null)
                    {
                        list.AddRange(DrawItems.lsCheck(model3.Mild, "tph", 2));
                        list.AddRange(DrawItems.lsCheck(model3.Faint, "tqx", 3));
                        list.AddRange(DrawItems.lsCheck(model3.Yang, "tyxa", 3));
                        list.AddRange(DrawItems.lsCheck(model3.Yin, "tyy", 3));
                        list.AddRange(DrawItems.lsCheck(model3.PhlegmDamp, "tts", 3));
                        list.AddRange(DrawItems.lsCheck(model3.Muggy, "tsr", 3));
                        list.AddRange(DrawItems.lsCheck(model3.BloodStasis, "txy", 3));
                        list.AddRange(DrawItems.lsCheck(model3.QiConstraint, "tqy", 3));
                        list.AddRange(DrawItems.lsCheck(model3.Characteristic, "ttl", 3));
                        list.AddRange(DrawItems.lsCheck(model3.MildAdvising, "tphzd", 6));
                        list.AddRange(DrawItems.lsCheck(model3.FaintAdvising, "tqxzd", 6));
                        list.AddRange(DrawItems.lsCheck(model3.YangAdvising, "tyxzd", 6));
                        list.AddRange(DrawItems.lsCheck(model3.YinAdvising, "tyyzd", 6));
                        list.AddRange(DrawItems.lsCheck(model3.PhlegmdampAdvising, "ttszd", 6));
                        list.AddRange(DrawItems.lsCheck(model3.MuggyAdvising, "tsrzd", 6));
                        list.AddRange(DrawItems.lsCheck(model3.BloodStasisAdvising, "txyzd", 6));
                        list.AddRange(DrawItems.lsCheck(model3.QiconstraintAdvising, "tqyzd", 6));
                        list.AddRange(DrawItems.lsCheck(model3.CharacteristicAdvising, "ttlzd", 6));
                        list.Add(new ListValue
                        {
                            strMark = "$tphdf",
                            strVal = DrawItems.objToNumStr(model3.MildScore)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$tqxdf",
                            strVal = DrawItems.objToNumStr(model3.FaintScore)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$tyxdf",
                            strVal = DrawItems.objToNumStr(model3.YangsCore)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$tyydf",
                            strVal = DrawItems.objToNumStr(model3.YinScore)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ttsdf",
                            strVal = DrawItems.objToNumStr(model3.PhlegmdampScore)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$tsrdf",
                            strVal = DrawItems.objToNumStr(model3.MuggyScore)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$txydf",
                            strVal = DrawItems.objToNumStr(model3.BloodStasisScore)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$tqydf",
                            strVal = DrawItems.objToNumStr(model3.QiConstraintScore)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ttldf",
                            strVal = DrawItems.objToNumStr(model3.CharacteristicScore)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "%tphqt",
                            strVal = model3.MildAdvisingEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "%tqxqt",
                            strVal = model3.FaintAdvisingEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "%tyxqt",
                            strVal = model3.YangadvisingEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "%tyyqt",
                            strVal = model3.YinAdvisingEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "%ttsqt",
                            strVal = model3.PhlegmdampAdvisingEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "%tsrqt",
                            strVal = model3.MuggyAdvisingEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "%txyqt",
                            strVal = model3.BloodStasisAdvisingEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "%tqyqt",
                            strVal = model3.QiconstraintAdvisingEx
                        });
                        list.Add(new ListValue
                        {
                            strMark = "%ttlqt",
                            strVal = model3.CharacteristicAdvisingEx
                        });
                    }
                }
                return DrawItems.setPage("printXps\\" + this.PrintName, list);
            }
            return null;
        }
    }
}
