
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
	public class Child_With_NEW : IGetReport
	{
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Kids/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Kids//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
		{
			get
			{
				return "11新生儿家庭访视记录表.xps";
			}
		}

		public bool hasData()
		{
			if (!string.IsNullOrEmpty(this.CardID))
			{
                DataSet list = new KidsNewBornVisitDAL().GetList(" IDCardNo='" + this.CardID + "'");
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
                KidsNewBornVisitModel model2 = new KidsNewBornVisitDAL().GetModel(this.CardID);
				if (model2 != null)
				{
                    //list.Add(new ListValue
                    //{
                    //    strMark = "$sfys",
                    //    strVal = model2.FollowUpDoctorSign
                    //});
					list.Add(new ListValue
					{
						strMark = "#xb",
						strVal = model2.Sex
					});
					list.Add(new ListValue
					{
						strMark = "!csrq",
						strVal = DrawItems.strToDate(model2.Birthday, 2)
					});
					list.Add(new ListValue
					{
						strMark = "$sfzh",
						strVal = model2.IDCardNo
					});
					list.Add(new ListValue
					{
						strMark = "$jtzz",
						strVal = model2.HomeAddr
					});
					list.Add(new ListValue
					{
						strMark = "$fqxm",
						strVal = model2.FatherName
					});
					list.Add(new ListValue
					{
						strMark = "$fqzy",
						strVal = model2.FatherJob
					});
					list.Add(new ListValue
					{
						strMark = "$fqdh",
						strVal = model2.FatherTel
					});
					list.Add(new ListValue
					{
						strMark = "$dbcs",
						strVal = DrawItems.objToNumStr(model2.StoolFrequen, 0)
					});
					list.Add(new ListValue
					{
						strMark = "$tw",
						strVal = DrawItems.objToNumStr(model2.Temperature, 1)
					});
					list.Add(new ListValue
					{
						strMark = "$ml",
						strVal = DrawItems.objToNumStr(model2.PulseRate, 0)
					});
					list.Add(new ListValue
					{
						strMark = "$hxpl",
						strVal = DrawItems.objToNumStr(model2.BreathingRate, 0)
					});
					list.Add(new ListValue
					{
						strMark = "#ms",
						strVal = model2.ColourFace
					});
					list.Add(new ListValue
					{
						strMark = "$msqt",
						strVal = model2.ColourFaceOther
					});
					list.Add(new ListValue
					{
						strMark = "#hd",
						strVal = model2.Jaundice
					});
					list.Add(new ListValue
					{
						strMark = "$qxx",
						strVal = DrawItems.objToNumStr(model2.BregmaLeft, 2)
					});
					list.Add(new ListValue
					{
						strMark = "$qxy",
						strVal = DrawItems.objToNumStr(model2.BregmaRight, 2)
					});
					list.Add(new ListValue
					{
						strMark = "#qx",
						strVal = model2.Bregma
					});
					list.Add(new ListValue
					{
						strMark = "$qxqt",
						strVal = model2.BregmaOther
					});
					list.Add(new ListValue
					{
						strMark = "#yw",
						strVal = model2.EyeAppearance
					});
					list.Add(new ListValue
					{
						strMark = "$ywgqt",
						strVal = model2.EyeAppearanceEx
					});
					list.Add(new ListValue
					{
						strMark = "#zh",
						strVal = model2.LimbsActivity
					});
					list.Add(new ListValue
					{
						strMark = "$hdqt",
						strVal = model2.LimbsActivityEx
					});
					list.Add(new ListValue
					{
						strMark = "#ew",
						strVal = model2.EarAppearance
					});
					list.Add(new ListValue
					{
						strMark = "$ewgqt",
						strVal = model2.EarAppearanceEx
					});
					list.Add(new ListValue
					{
						strMark = "#jb",
						strVal = model2.NeckMass
					});
					list.Add(new ListValue
					{
						strMark = "$jbqt",
						strVal = model2.NeckMassHave
					});
					list.Add(new ListValue
					{
						strMark = "#bw",
						strVal = model2.Nose
					});
					list.Add(new ListValue
					{
						strMark = "$bwgqt",
						strVal = model2.NoseEx
					});
					list.Add(new ListValue
					{
						strMark = "#pf",
						strVal = model2.Skin
					});
					list.Add(new ListValue
					{
						strMark = "$pfqt",
						strVal = model2.SkinOther
					});
					list.Add(new ListValue
					{
						strMark = "#kq",
						strVal = model2.MouthCavity
					});
					list.Add(new ListValue
					{
						strMark = "$kqqt",
						strVal = model2.MouthCavityEx
					});
					list.Add(new ListValue
					{
						strMark = "#gm",
						strVal = model2.Anus
					});
					list.Add(new ListValue
					{
						strMark = "$gmqt",
						strVal = model2.AnusEx
					});
					list.Add(new ListValue
					{
						strMark = "#xf",
						strVal = model2.HeartLungAuscul
					});
					list.Add(new ListValue
					{
						strMark = "$xfqt",
						strVal = model2.HeartLungAusculEx
					});
					list.Add(new ListValue
					{
						strMark = "#sz",
						strVal = model2.Aedea
					});
					list.Add(new ListValue
					{
						strMark = "$szqt",
						strVal = model2.AedeaEx
					});
					list.Add(new ListValue
					{
						strMark = "#fb",
						strVal = model2.AbdominalTouch
					});
					list.Add(new ListValue
					{
						strMark = "$fbqt",
						strVal = model2.AbdominalTouchEx
					});
					list.Add(new ListValue
					{
						strMark = "#jz",
						strVal = model2.Spine
					});
					list.Add(new ListValue
					{
						strMark = "$jzqt",
						strVal = model2.SpineEx
					});
					list.Add(new ListValue
					{
						strMark = "#qd",
						strVal = model2.UmbilicalCord
					});
					list.Add(new ListValue
					{
						strMark = "$qdqt",
						strVal = model2.UmbilicalCordOther
					});
					list.Add(new ListValue
					{
						strMark = "#zz",
						strVal = model2.ReferralAdvice
					});
					list.Add(new ListValue
					{
						strMark = "$zzyy",
						strVal = model2.ReferralReason
					});
					list.Add(new ListValue
					{
						strMark = "$zzks",
						strVal = model2.AgenciesDepartments
					});
					list.Add(new ListValue
					{
						strMark = "#zd",
						strVal = model2.Guidance
					});
					list.Add(new ListValue
					{
						strMark = "$bcsfrq",
						strVal = DrawItems.strToDate(model2.InterviewDate)
					});
					list.Add(new ListValue
					{
						strMark = "$xcsf",
						strVal = model2.NextFollowupPlace
					});
					list.Add(new ListValue
					{
						strMark = "$xdsfrq",
						strVal = DrawItems.strToDate(model2.NextFollowupDate)
					});
				
					list.Add(new ListValue
					{
						strMark = "$mqxm",
						strVal = model2.MotherName
					});
					list.Add(new ListValue
					{
						strMark = "$mqzy",
						strVal = model2.MotherJob
					});
					list.Add(new ListValue
					{
						strMark = "$mqdh",
						strVal = model2.MotherTel
					});
				
					list.Add(new ListValue
					{
						strMark = "$csyz",
						strVal = DrawItems.objToNumStr(model2.GestationalWeek, 0)
					});
					list.Add(new ListValue
					{
						strMark = "#hb",
						strVal = model2.PregnancPreva
					});
					list.Add(new ListValue
					{
						strMark = "$rqhb",
						strVal = model2.PregnancPrevaOther
					});
					list.Add(new ListValue
					{
						strMark = "$zcjg",
						strVal = model2.MidwifOrganizaName
					});
					list.Add(new ListValue
					{
						strMark = "#csqk",
						strVal = model2.BirthInforma
					});
					list.Add(new ListValue
					{
						strMark = "$csqt",
						strVal = model2.BirthInformaOther
					});
					list.Add(new ListValue
					{
						strMark = "#zx",
						strVal = model2.Aasphyxia
					});
					list.Add(new ListValue
					{
						strMark = "#jx",
						strVal = model2.WhetherAbnorma
					});
					list.Add(new ListValue
					{
						strMark = "$jxqt",
						strVal = model2.WhetherAbnormaHave
					});
					list.Add(new ListValue
					{
						strMark = "#tl",
						strVal = model2.HearingScreen
					});
					list.Add(new ListValue
					{
						strMark = "#sc",
						strVal = model2.DiseaseScreen
					});
					list.Add(new ListValue
					{
						strMark = "$scqt",
						strVal = model2.DiseaseScreenOther
					});
					list.Add(new ListValue
					{
						strMark = "$cstz",
						strVal = DrawItems.objToNumStr(model2.BirthWeight)
					});
					list.Add(new ListValue
					{
						strMark = "$mqtz",
						strVal = DrawItems.objToNumStr(model2.PresentWeight)
					});
					list.Add(new ListValue
					{
						strMark = "$cssc",
						strVal = DrawItems.objToNumStr(model2.BirthStature)
					});
					list.Add(new ListValue
					{
						strMark = "#wy",
						strVal = model2.FeedingPattern
					});
					list.Add(new ListValue
					{
						strMark = "$cnl",
						strVal = DrawItems.objToNumStr(model2.NursingQuantity, 0)
					});
					list.Add(new ListValue
					{
						strMark = "$cncs",
						strVal = DrawItems.objToNumStr(model2.InfantFrequen, 0)
					});
					list.Add(new ListValue
					{
						strMark = "#ot",
						strVal = model2.Vomit
					});
					list.Add(new ListValue
					{
						strMark = "#db",
						strVal = model2.Stool
					});
					list.Add(new ListValue
					{
						strMark = "@apg" + model2.Apgar,
						strVal = "1"
					});
                    list.Add(new ListValue
                    {
                        strMark = "$fqid",
                        strVal = model2.FatherID
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$mqid",
                        strVal = model2.MotherID
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#xb",
                        strVal = model2.Chest
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xbqt",
                        strVal = model2.ChestEx
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zdqt",
                        strVal = model2.GuidanceOther
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzjg",
                        strVal = model2.ReferralOrgan
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzlxr",
                        strVal = model2.ReferraContacts
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzlxdh",
                        strVal = model2.ReferralContactsTel
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#zzjg",
                        strVal = model2.ReferralResult
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&sfys",
                        strVal = string.Format("{0}{1}_NewBorn_Doc.png", SignPath, model2.IDCardNo)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&jzqm",
                        strVal = string.Format("{0}{1}_NewBorn.png", SignPath, model2.IDCardNo)
                    });
				}
				return DrawItems.setPage("printXps\\11新生儿家庭访视记录表.xps", list);
			}
			return null;
		}
	}
}
