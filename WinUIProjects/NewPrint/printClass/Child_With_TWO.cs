
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
	public class Child_With_TWO : IGetReport
	{
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Kids/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Kids//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
		{
			get
			{
				return "13一到二岁儿童健康检查记录表.xps";
			}
		}

		public bool hasData()
		{
			if (!string.IsNullOrEmpty(this.CardID))
			{
				DataSet list = new KidsOneToThreeYearOldDAL().GetList(" IDCardNo='" + this.CardID + "'");
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
				return DrawItems.setPage("printXps\\13一到二岁儿童健康检查记录表.xps", list);
			}
			return null;
		}

		public List<ListValue> getList(string MonthType)
		{
            string text="";
            if (MonthType != null)
            {
                if (MonthType == "1")
                {
                    text = "12";
                }
                else if (MonthType == "2")
                {
                    text = "18";
                }
                else if (MonthType == "3")
                {
                    text = "24";
                }
                else if (MonthType == "4")
                {
                    text = "30";
                }
            }

			List<ListValue> list = new List<ListValue>();
			KidsOneToThreeYearOldModel model = this.getModel(MonthType);
			if (model == null)
			{
				return null;
			}
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "sfrq",
				strVal = DrawItems.strToDate(model.FollowupDate)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "tz",
				strVal = DrawItems.objToNumStr(model.Weight)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "sc",
				strVal = DrawItems.objToNumStr(model.Stature, 0)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "ql",
				strVal = DrawItems.objToNumStr(model.BregmaLeft)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "qr",
				strVal = DrawItems.objToNumStr(model.BregmaRight)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "cy",
				strVal = DrawItems.objToNumStr(model.TeethDcnLeft, 0)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "qc",
				strVal = DrawItems.objToNumStr(model.TeethDcnRight, 0)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "xh",
				strVal = DrawItems.objToNumStr(model.HemoglobinValue)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "hw",
				strVal = DrawItems.objToNumStr(model.OutdoorActivities, 1)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "wss",
				strVal = DrawItems.objToNumStr(model.TakingVitaminsd)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "qt",
				strVal = model.Other
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "zzyy",
				strVal = model.ReferralReason
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "wssm",
				strVal = model.AgenciesDepartments
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "xcsf",
				strVal = DrawItems.strToDate(model.NextFollowupDate)
			});
			
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "zdqt",
				strVal = model.GuidanceOther
			});
            list.Add(new ListValue
            {
                strMark = "$" + MonthType + "fy",
                strVal = DrawItems.objToNumStr(model.PneumoniaCounts, 0)
            });
            list.Add(new ListValue
            {
                strMark = "$" + MonthType + "fx",
                strVal = DrawItems.objToNumStr(model.DiarrheaCounts, 0)
            });
            list.Add(new ListValue
            {
                strMark = "$" + MonthType + "ws",
                strVal = DrawItems.objToNumStr(model.TraumaCounts, 0)
            });
            list.Add(new ListValue
            {
                strMark = "$" + MonthType + "hbqt",
                strVal = DrawItems.objToNumStr(model.SickOther, 0)
            });

            list.Add(new ListValue
			{
				strMark = "&" + MonthType + "sfys",
                strVal = string.Format("{0}{1}_Month_{2}_Doc.png", SignPath, model.IDCardNo,text)
			});
            list.Add(new ListValue
            {
                strMark = "&" + MonthType + "qm",
                strVal = string.Format("{0}{1}_Month_{2}.png", SignPath, model.IDCardNo, text)
            });
			list.AddRange(DrawItems.lsCheck(model.Gait, MonthType, "bt", 3));
			list.AddRange(DrawItems.lsCheck(model.EarAppearance, MonthType, "ew", 3));
			list.AddRange(DrawItems.lsCheck(model.Stomach, MonthType, "fb", 3));
			list.AddRange(DrawItems.lsCheck(model.AuxeEstimate, MonthType, "fypg", 3));
			list.AddRange(DrawItems.lsCheck(model.SuspiciousRickets, MonthType, "glb", 3));
			list.AddRange(DrawItems.lsCheck(model.ColourFace, MonthType, "ms", 3));
			list.AddRange(DrawItems.lsCheck(model.Skin, MonthType, "pf", 3));
			list.AddRange(DrawItems.lsCheck(model.Bregma, MonthType, "qx", 3));
			list.AddRange(DrawItems.lsCheck(model.StatureAnalysis, MonthType, "s", 3));
			list.AddRange(DrawItems.lsCheck(model.AmongTwoFollowup, MonthType, "sfhb", 3));
			list.AddRange(DrawItems.lsCheck(model.FourLimb, MonthType, "sz", 3));
			list.AddRange(DrawItems.lsCheck(model.WeightAnalysis, MonthType, "t", 3));
			list.AddRange(DrawItems.lsCheck(model.Listening, MonthType, "tl", 3));
			list.AddRange(DrawItems.lsCheck(model.HeartLung, MonthType, "xf", 3));
			list.AddRange(DrawItems.lsCheck(model.EyeAppearance, MonthType, "yw", 3));
			list.AddRange(DrawItems.lsCheck(model.Guidance, MonthType, "zd", 5));
			list.AddRange(DrawItems.lsCheck(model.ReferralAdvice, MonthType, "zz", 3));
			return list;
		}

		private KidsOneToThreeYearOldModel getModel(string type)
		{
            KidsOneToThreeYearOldDAL kidsOneToThreeYearOldDAL = new KidsOneToThreeYearOldDAL();
            DataSet list = kidsOneToThreeYearOldDAL.GetList("IDCardNo='" + this.CardID + "' and flag=" + type);
			if (list != null && list.Tables.Count > 0 && list.Tables[0].Rows.Count > 0)
			{
                return kidsOneToThreeYearOldDAL.DataRowToModel(list.Tables[0].Rows[0]);
			}
			return null;
		}
	}
}
