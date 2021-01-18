
using ReportPrint;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;
using System.Configuration;

namespace printClass
{
	public class GRAVIDA_FRIST : IGetReport
	{
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Gravida/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Gravida//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
		{
			get
			{
				return "15第一次产前随访服务记录表.xps";
			}
		}

		public bool hasData()
		{
			if (!string.IsNullOrEmpty(this.CardID))
			{
				DataSet list = new WomenGravidaFirstVisitDAL().GetList(" IDCardNo='" + this.CardID + "'");
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
						strMark = "$archiveid",
						strVal = model.RecordID
					},
					new ListValue
					{
						strMark = "$name",
						strVal = model.CustomerName
					}
				};
				WomenGravidaFirstVisitModel model2 = new WomenGravidaFirstVisitDAL().GetModel(this.CardID);
				if (model2 != null)
				{
					list.Add(new ListValue
					{
						strMark = "$ylc",
						strVal = model2.AbortionInfo
					});
                    list.Add(new ListValue
                    {
                        strMark = "$ylcr",
                        strVal = model2.ArtificialAbortion
                    });
					list.Add(new ListValue
					{
						strMark = "$yst",
						strVal = model2.Deadfetus
					});
					list.Add(new ListValue
					{
						strMark = "$ysc",
						strVal = model2.StillBirthInfo
					});
					list.Add(new ListValue
					{
						strMark = "$ysw",
						strVal = model2.NewBornDead
					});
					list.Add(new ListValue
					{
						strMark = "$yqx",
						strVal = model2.NewBornDefect
					});
					list.Add(new ListValue
					{
						strMark = "$sg",
						strVal = DrawItems.objToNumStr(model2.Height, 2)
					});
					list.Add(new ListValue
					{
						strMark = "$tz",
						strVal = DrawItems.objToNumStr(model2.Weight)
					});
					list.Add(new ListValue
					{
						strMark = "$tzzs",
						strVal = DrawItems.objToNumStr(model2.Bmi)
					});
					list.Add(new ListValue
					{
						strMark = "$xgy",
						strVal = DrawItems.objToNumStr(model2.HBloodpressure)
					});
					list.Add(new ListValue
					{
						strMark = "$xdy",
						strVal = DrawItems.objToNumStr(model2.LBloodpressure)
					});
					list.Add(new ListValue
					{
						strMark = "#t",
						strVal = model2.Heart
					});
					list.Add(new ListValue
					{
						strMark = "$tzxz",
						strVal = model2.Heartex
					});
					list.Add(new ListValue
					{
						strMark = "#f",
						strVal = model2.Lung
					});
					list.Add(new ListValue
					{
						strMark = "$tzfb",
						strVal = model2.Lungex
					});
					list.Add(new ListValue
					{
						strMark = "#w",
						strVal = model2.Vulva
					});
					list.Add(new ListValue
					{
						strMark = "$wy",
						strVal = model2.VulvaEx
					});
					list.Add(new ListValue
					{
						strMark = "#y",
						strVal = model2.Vagina
					});
					list.Add(new ListValue
					{
						strMark = "$fkyd",
						strVal = model2.VaginaEx
					});
					list.Add(new ListValue
					{
						strMark = "#g",
						strVal = model2.CervixuTeri
					});
					list.Add(new ListValue
					{
						strMark = "$gj",
						strVal = model2.CervixuTeriex
					});
					list.Add(new ListValue
					{
						strMark = "#z",
						strVal = model2.Corpus
					});
					list.Add(new ListValue
					{
						strMark = "$fkzg",
						strVal = model2.CorpusEx
					});
					list.Add(new ListValue
					{
						strMark = "#j",
						strVal = model2.Attach
					});
					list.Add(new ListValue
					{
						strMark = "$fj",
						strVal = model2.AttachEx
					});
					list.Add(new ListValue
					{
						strMark = "#ztpg",
						strVal = model2.OverAlassessMent
					});
					list.Add(new ListValue
					{
						strMark = "$ztpjyc",
						strVal = model2.OverAlassessmentEx
					});
					list.Add(new ListValue
					{
						strMark = "#bjzd",
						strVal = model2.HealthZhiDao
					});
					list.Add(new ListValue
					{
						strMark = "$zdqt",
						strVal = model2.HealthZhiDaoOthers
					});
					list.Add(new ListValue
					{
						strMark = "#zz",
						strVal = model2.Referral
					});
					list.Add(new ListValue
					{
						strMark = "$zzyy",
						strVal = model2.ReferralReason
					});
					list.Add(new ListValue
					{
						strMark = "$zzjg",
						strVal = model2.ReferralOrg
					});
                    list.Add(new ListValue
                    {
                        strMark = "$zzlxr",
                        strVal = model2.ReferralContacts
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzlxfs",
                        strVal = model2.ReferralContactsTel
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zzjg",
                        strVal = model2.ReferralResult
                    });
					list.Add(new ListValue
					{
						strMark = "$xcsfrq",
						strVal = DrawItems.strToDate(model2.NextfollowupDate)
					});
                    //list.Add(new ListValue
                    //{
                    //    strMark = "$sfys",
                    //    strVal = model2.FollowUpDoctor
                    //});
					list.Add(new ListValue
					{
						strMark = "$fksqt",
						strVal = model2.GynecologyHistoryEx
					});
					list.Add(new ListValue
					{
						strMark = "$tbrq",
						strVal = DrawItems.strToDate(model2.RecordDate)
					});
					list.Add(new ListValue
					{
						strMark = "$tbyz",
						strVal = DrawItems.objToNumStr(model2.PregancyWeeks, 0)
					});
					list.Add(new ListValue
					{
						strMark = "$yfnl",
						strVal = DrawItems.objToNumStr(model2.CustomerAge, 0)
					});
					list.Add(new ListValue
					{
						strMark = "$zfxm",
						strVal = model2.HusbandName
					});
					list.Add(new ListValue
					{
						strMark = "$tzfnl",
						strVal = DrawItems.objToNumStr(model2.HusbandAge, 0)
					});
					list.Add(new ListValue
					{
						strMark = "$zfdh",
						strVal = model2.HusbandPhone
					});
					list.Add(new ListValue
					{
						strMark = "$yc",
						strVal = DrawItems.objToNumStr(model2.PregancyCount, 0)
					});
					list.Add(new ListValue
					{
						strMark = "$ydcc",
						strVal = DrawItems.objToNumStr(model2.NatrualChildBirthCount, 0)
					});
					list.Add(new ListValue
					{
						strMark = "$pgcc",
						strVal = DrawItems.objToNumStr(model2.CaeSareanCount, 0)
					});
					if (model2.LastMenStruation == "0")
					{
						list.Add(new ListValue
						{
							strMark = "$mcyj",
							strVal = "不详"
						});
					}
					else
					{
						list.Add(new ListValue
						{
							strMark = "$mcyj",
							strVal = DrawItems.strToDate(model2.LastMenStruationDate)
						});
					}
					list.Add(new ListValue
					{
						strMark = "$ycc",
						strVal = DrawItems.strToDate(model2.ExpectedDueDate)
					});
					list.Add(new ListValue
					{
						strMark = "#jws",
						strVal = model2.CustomerHistory
					});
					list.Add(new ListValue
					{
						strMark = "$jwsqt",
						strVal = model2.CustomerHistoryEx
					});
					list.Add(new ListValue
					{
						strMark = "#jzs",
						strVal = model2.FamilyHistory
					});
					list.Add(new ListValue
					{
						strMark = "$jzsqt",
						strVal = model2.FamilyHistoryEx
					});
					list.Add(new ListValue
					{
						strMark = "#grs",
						strVal = model2.PersonalHistory
					});
					list.Add(new ListValue
					{
						strMark = "$grsqt",
						strVal = model2.PersonalHistoryEx
					});
					list.Add(new ListValue
					{
						strMark = "#fks",
						strVal = model2.GyNecoloGyHistory
					});
                    list.Add(new ListValue
                    {
                        strMark = "$jcjg",
                        strVal = model2.BooksInstitution
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#jcqk",
                        strVal = model2.BooksInfo
                    });
				}
				WomenGravidaPreAssistCheckModel model3 = new WomenGravidaPreAssistCheckDAL().GetModel(this.CardID);
				if (model3 != null)
				{
					list.Add(new ListValue
					{
						strMark = "$xhdb",
						strVal = DrawItems.objToNumStr(model3.HB)
					});
					list.Add(new ListValue
					{
						strMark = "$xbxb",
						strVal = DrawItems.objToNumStr(model3.WBC)
					});
					list.Add(new ListValue
					{
						strMark = "$xxb",
						strVal = DrawItems.objToNumStr(model3.PlT)
					});
					list.Add(new ListValue
					{
						strMark = "$xcqt",
						strVal = model3.BloodOther
					});
					list.Add(new ListValue
					{
						strMark = "$ndb",
						strVal = model3.PRO
					});
					list.Add(new ListValue
					{
						strMark = "$nt",
						strVal = model3.GLU
					});
					list.Add(new ListValue
					{
						strMark = "$ntt",
						strVal = model3.KET
					});
					list.Add(new ListValue
					{
						strMark = "$nqx",
						strVal = model3.BLD
					});
					list.Add(new ListValue
					{
						strMark = "$nqt",
						strVal = model3.UrineOthers
					});
					string bLOODTYPE;
					string strVal;
					if ((bLOODTYPE = model3.BloodType) != null)
					{
						if (bLOODTYPE == "1")
						{
							strVal = "A型";
							goto IL_BBF;
						}
						if (bLOODTYPE == "2")
						{
							strVal = "B型";
							goto IL_BBF;
						}
						if (bLOODTYPE == "3")
						{
                            strVal = "O型";
							goto IL_BBF;
						}
						if (bLOODTYPE == "4")
						{
                            strVal = "AB型";
							goto IL_BBF;
						}
						if (bLOODTYPE == "5")
						{
							strVal = "不详";
							goto IL_BBF;
						}
					}
					strVal = "";
					IL_BBF:
					list.Add(new ListValue
					{
						strMark = "$abo",
						strVal = strVal
					});
					if (model3.RH == "1")
					{
						list.Add(new ListValue
						{
							strMark = "$rh",
							strVal = "阴性"
						});
					}
					else
					{
                        if (model3.RH == "2")
                        {
                            list.Add(new ListValue
                            {
                                strMark = "$rh",
                                strVal = "阳性"
                            });
                        }
                        else
                        {
                            if (model3.RH == "3")
                            {
                                list.Add(new ListValue
                                {
                                    strMark = "$rh",
                                    strVal = "不详"
                                });
                            }
                        }
					}

					list.Add(new ListValue
					{
						strMark = "$xt",
						strVal = DrawItems.objToNumStr(model3.FPGL)
					});
					list.Add(new ListValue
					{
						strMark = "$ggb",
						strVal = DrawItems.objToNumStr(model3.SGPT)
					});
					list.Add(new ListValue
					{
						strMark = "$ggc",
						strVal = DrawItems.objToNumStr(model3.GOT)
					});
					list.Add(new ListValue
					{
						strMark = "$gdb",
						strVal = DrawItems.objToNumStr(model3.BP)
					});
					list.Add(new ListValue
					{
						strMark = "$gdh",
						strVal = DrawItems.objToNumStr(model3.TBIL)
					});
					list.Add(new ListValue
					{
						strMark = "$gjh",
						strVal = DrawItems.objToNumStr(model3.CB)
					});
					list.Add(new ListValue
					{
						strMark = "$sxq",
						strVal = DrawItems.objToNumStr(model3.SCR)
					});
					list.Add(new ListValue
					{
						strMark = "$sxn",
						strVal = DrawItems.objToNumStr(model3.BUN)
					});
					list.Add(new ListValue
					{
						strMark = "#ydfm",
						strVal = model3.VaginalSecretions
					});
					list.Add(new ListValue
					{
						strMark = "$ydqt",
						strVal = model3.VaginalSecretionSothers
					});
					list.Add(new ListValue
					{
						strMark = "#ydqj",
						strVal = model3.VaginalCleaess
					});
					list.Add(new ListValue
					{
						strMark = "$ygby",
						strVal = model3.HBSAG
					});
					list.Add(new ListValue
					{
						strMark = "$xtt",
						strVal = model3.HBSAB
					});
					list.Add(new ListValue
					{
						strMark = "$ygey",
						strVal = model3.HBEAG
					});
					list.Add(new ListValue
					{
						strMark = "$xet",
						strVal = model3.HBEAB
					});
					list.Add(new ListValue
					{
						strMark = "$yght",
						strVal = model3.HBCAB
					});
					list.Add(new ListValue
					{
						strMark = "#mdxq",
						strVal = model3.LUES
					});
					list.Add(new ListValue
					{
						strMark = "#hiv",
						strVal = model3.HIV
					});
					list.Add(new ListValue
					{
						strMark = "$bc",
						strVal = model3.BCHAO
					});
                    list.Add(new ListValue
                    {
                        strMark = "$fzqt",
                        strVal = model3.AssistOther
                    });
				}
                list.Add(new ListValue
                {
                    strMark = "&qm",
                    strVal = string.Format("{0}{1}_{2}.png", SignPath, model.IDCardNo, "PrenatalS_1")
                });
                list.Add(new ListValue
                {
                    strMark = "&sfys",
                    strVal = string.Format("{0}{1}_{2}_Doc.png", SignPath, model.IDCardNo, "PrenatalS_1")
                });
				return DrawItems.setPage("printXps\\15第一次产前随访服务记录表.xps", list);
			}
			return null;
		}
	}
}
