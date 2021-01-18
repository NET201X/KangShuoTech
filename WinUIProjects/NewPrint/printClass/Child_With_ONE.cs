
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
	public class Child_With_ONE : IGetReport
	{
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Kids/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Kids//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
		{
			get
			{
				return "12一岁以内儿童健康检查记录表.xps";
			}
		}

		public bool hasData()
		{
			if (!string.IsNullOrEmpty(this.CardID))
			{
                DataSet list = new KidsWithinOneYearOldDAL().GetList(" IDCardNo='" + this.CardID + "'");
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
				for (int i = 1; i < 5; i++)
				{
					List<ListValue> list2 = this.getList(i.ToString());
					if (list2 != null)
					{
						list.AddRange(list2);
					}
				}
				return DrawItems.setPage("printXps\\12一岁以内儿童健康检查记录表.xps", list);
			}
			return null;
		}

		public List<ListValue> getList(string MonthType)
		{
			List<ListValue> list = new List<ListValue>();
			string text;
			if (MonthType != null)
			{
				if (MonthType == "1")
				{
					text = "1";
					goto IL_72;
				}
				if (MonthType == "2")
				{
					text = "3";
					goto IL_72;
				}
				if (MonthType == "3")
				{
					text = "6";
					goto IL_72;
				}
				if (MonthType == "4")
				{
					text = "8";
					goto IL_72;
				}
			}
			text = "1";
			IL_72:
			KidsWithinOneYearOldModel model = this.getModel(MonthType);
			if (model == null)
			{
				return null;
			}
			list.Add(new ListValue
			{
				strMark = "$" + text + "sfrq",
				strVal = DrawItems.strToDate(model.VisitDate)
			});
			list.Add(new ListValue
			{
				strMark = "$" + text + "tz",
				strVal = DrawItems.objToNumStr(model.Weight, 2)
			});
			list.Add(new ListValue
			{
				strMark = "$" + text + "sc",
				strVal = DrawItems.objToNumStr(model.Stature, 2)
			});
			list.Add(new ListValue
			{
				strMark = "$" + text + "tw",
				strVal = DrawItems.objToNumStr(model.HeadCircumference, 2)
			});
			list.Add(new ListValue
			{
				strMark = "$" + text + "qx",
				strVal = DrawItems.objToNumStr(model.BregmaLeft, 1)
			});
			list.Add(new ListValue
			{
				strMark = "$" + text + "qy",
				strVal = DrawItems.objToNumStr(model.BregmaRight, 1)
			});
			list.Add(new ListValue
			{
				strMark = "$" + text + "xhdb",
				strVal = DrawItems.objToNumStr(model.HemoglobinValue, 1)
			});
			list.Add(new ListValue
			{
				strMark = "$" + text + "hwhd",
				strVal = DrawItems.objToNumStr(model.OutdoorActivities, 1)
			});
			list.Add(new ListValue
			{
				strMark = "$" + text + "wsdd",
				strVal = DrawItems.objToNumStr(model.TakingVitaminsd, 1)
			});
			list.Add(new ListValue
			{
				strMark = "$" + text + "cy",
				strVal = DrawItems.objToNumStr(model.TeethNum, 0)
			});
			list.Add(new ListValue
			{
				strMark = "$" + text + "zzyy",
				strVal = DrawItems.objToStr(model.ReferralReason)
			});
			list.Add(new ListValue
			{
				strMark = "$" + text + "zzks",
				strVal = DrawItems.objToStr(model.AgenciesDepartments)
			});
			list.Add(new ListValue
			{
				strMark = "$" + text + "xcsf",
				strVal = DrawItems.strToDate(model.NextFollowupDate, 1)
			});
            //list.Add(new ListValue
            //{
            //    strMark = "$" + text + "sfys",
            //    strVal = DrawItems.objToStr(model.FollowUpDoctorSign)
            //});
            list.Add(new ListValue
            {
                strMark = "$" + text + "fy",
                strVal = DrawItems.objToStr(model.PneumoniaCounts)
            });
            list.Add(new ListValue
            {
                strMark = "$" + text + "fx",
                strVal = DrawItems.objToStr(model.DiarrheaCounts)
            });
            list.Add(new ListValue
            {
                strMark = "$" + text + "ws",
                strVal = DrawItems.objToStr(model.TraumaCounts)
            });
            list.Add(new ListValue
            {
                strMark = "$" + text + "qt",
                strVal = model.SickOther
            });
            list.Add(new ListValue
            {
                strMark = "$" + text + "lxr",
                strVal = model.ReferraContacts
            });
            list.Add(new ListValue
            {
                strMark = "$" + text + "lxfs",
                strVal = model.ReferralContactsTel
            });
            list.Add(new ListValue
            {
                strMark = "#" + text + "dw",
                strVal = model.ReferralResult
            });
            list.Add(new ListValue
            {
                strMark = "&" + text + "sfys",
                strVal = string.Format("{0}{1}_Month_{2}_Doc.png", SignPath, model.IDCardNo, text)
            });
            list.Add(new ListValue
            {
                strMark = "&" + text + "qm",
                strVal = string.Format("{0}{1}_Month_{2}.png", SignPath, model.IDCardNo, text)
            });
            if (!string.IsNullOrEmpty(model.WeightAnalysis))
            {
                model.WeightAnalysis = (int.Parse(model.WeightAnalysis) - 1).ToString();
            }
            if (!string.IsNullOrEmpty(model.StatureAnalysis))
            {
                model.StatureAnalysis = (int.Parse(model.StatureAnalysis) - 1).ToString();
            }
			list.AddRange(DrawItems.lsCheck(model.WeightAnalysis, text, "t", 3));
			list.AddRange(DrawItems.lsCheck(model.StatureAnalysis, text, "s", 3));
			list.AddRange(DrawItems.lsCheck(model.ColorFace, text, "ms", 3));
			list.AddRange(DrawItems.lsCheck(model.Skin, text, "pf", 3));
			list.AddRange(DrawItems.lsCheck(model.Bregma, text, "qx", 3));
			list.AddRange(DrawItems.lsCheck(model.NeckMass, text, "jb", 2));
			list.AddRange(DrawItems.lsCheck(model.EyeAppearance, text, "ywg", 2));
			list.AddRange(DrawItems.lsCheck(model.EyeAppearance, text, "ewg", 2));
			list.AddRange(DrawItems.lsCheck(model.Listening, text, "tl", 2));
			list.AddRange(DrawItems.lsCheck(model.OralCavity, text, "kq", 2));
			list.AddRange(DrawItems.lsCheck(model.HeartLung, text, "xf", 2));
			list.AddRange(DrawItems.lsCheck(model.Stomach, text, "fb", 2));
			list.AddRange(DrawItems.lsCheck(model.UmbilicalRegion, text, "qb", 4));
			list.AddRange(DrawItems.lsCheck(model.FourLimb, text, "sz", 4));
			list.AddRange(DrawItems.lsCheck(model.RicketsSympotom, text, "gzz", 4));
			list.AddRange(DrawItems.lsCheck(model.RicketsSign, text, "gtz",7));
			list.AddRange(DrawItems.lsCheck(model.AnusExternalGenita, text, "gw", 2));
			list.AddRange(DrawItems.lsCheck(model.AuxeEstimate, text, "fy", 4));
			list.AddRange(DrawItems.lsCheck(model.AmongTwoFollowup, text, "hb", 2));
			list.AddRange(DrawItems.lsCheck(model.ReferralAdvice, text, "zz", 2));
			list.AddRange(DrawItems.lsCheck(model.Guidance, text, "zd", 5));
            list.AddRange(DrawItems.lsCheck(model.Chest, text, "xb", 2));
            if (model.SickNone== "有")
            {
                list.AddRange(DrawItems.lsCheck("1", text, "hb", 1));
            }
			return list;
		}

		private KidsWithinOneYearOldModel getModel(string type)
		{
            KidsWithinOneYearOldDAL kidsWithinOneYearOldDAL = new KidsWithinOneYearOldDAL();
            DataSet list = kidsWithinOneYearOldDAL.GetList("IDCardNo='" + this.CardID + "' and flag=" + type);
			if (list != null && list.Tables.Count > 0 && list.Tables[0].Rows.Count > 0)
			{
                return kidsWithinOneYearOldDAL.DataRowToModel(list.Tables[0].Rows[0]);
			}
			return null;
		}
	}
}
