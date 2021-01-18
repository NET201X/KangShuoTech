
using ReportPrint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;
using System.Configuration;

namespace printClass
{
	public class Child_With_THREE : IGetReport
	{
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Kids/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Kids//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
		{
			get
			{
				return "14三到六岁儿童健康检查记录表.xps";
			}
		}

		public bool hasData()
		{
			if (!string.IsNullOrEmpty(this.CardID))
			{
                DataSet list = new KidsThreeToSixYearOldDAL().GetList(" IDCardNo='" + this.CardID + "'");
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
				return DrawItems.setPage("printXps\\14三到六岁儿童健康检查记录表.xps", list);
			}
			return null;
		}

		public List<ListValue> getList(string MonthType)
		{
			List<ListValue> list = new List<ListValue>();
			KidsThreeToSixYearOldModel model = this.getModel(MonthType);
			if (model == null)
			{
				return null;
			}
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "cy",
				strVal = DrawItems.objToNumStr(model.TcnLeft, 0)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "fx",
				strVal = DrawItems.objToNumStr(model.DiarrhoeaFrequen, 0)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "fy",
				strVal = DrawItems.objToNumStr(model.PneumoniaFrequen, 0)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "jcqt",
				strVal = model.Other
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "qc",
				strVal = DrawItems.objToNumStr(model.TdcnRight, 0)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "qt",
				strVal = model.AmongTwoFolloOther
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "sc",
				strVal = DrawItems.objToNumStr(model.Stature)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "sfrq",
				strVal = DrawItems.strToDate(model.VisitDate)
			});
            //list.Add(new ListValue
            //{
            //    strMark = "$" + MonthType + "sfys",
            //    strVal = model.VisitDoctorSign
            //});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "sl",
				strVal = DrawItems.objToNumStr(model.Sight, 1)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "tz",
				strVal = DrawItems.objToNumStr(model.Weight)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "ws",
				strVal = DrawItems.objToNumStr(model.TraumatismFrequen, 0)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "wssm",
				strVal = model.AgenciesDepartments
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "xcsf",
				strVal = DrawItems.strToDate(model.NextVisitDate)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "xhdb",
				strVal = DrawItems.objToNumStr(model.HemoglobinValue)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "zdqt",
				strVal = model.GuidanceOther
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "zzyy",
				strVal = model.ReferralReason
			});
            list.Add(new ListValue
            {
                strMark = "&" + MonthType + "sfys",
                strVal = string.Format("{0}{1}_Year_{2}_Doc.png", SignPath, model.IDCardNo,model.Flag)
            });
            list.Add(new ListValue
            {
                strMark = "&" + MonthType + "qm",
                strVal = string.Format("{0}{1}_Year_{2}.png", SignPath, model.IDCardNo, model.Flag)
            });
			list.AddRange(DrawItems.lsCheck(model.Stomach, MonthType, "fb", 3));
			list.AddRange(DrawItems.lsCheck(model.StatureAnalysis, MonthType, "s", 3));
			list.AddRange(DrawItems.lsCheck(model.AmongTwoFolloNone, MonthType, "sfhb", 3));
			list.AddRange(DrawItems.lsCheck(model.WeightAnalysis, MonthType, "t", 3));
			list.AddRange(DrawItems.lsCheck(model.PhysicalAuxeEvaluat, MonthType, "tg", 5));
			list.AddRange(DrawItems.lsCheck(model.Listening, MonthType, "tl", 3));
			list.AddRange(DrawItems.lsCheck(model.HeartLung, MonthType, "xf", 3));
			list.AddRange(DrawItems.lsCheck(model.Guidance, MonthType, "zd", 5));
			list.AddRange(DrawItems.lsCheck(model.ReferralAdvice, MonthType, "zz", 3));
			return list;
		}

		private KidsThreeToSixYearOldModel getModel(string type)
		{
			string str = (Convert.ToInt32(type) + 2).ToString();
            KidsThreeToSixYearOldDAL kidsThreeToSixYearOldDAL = new KidsThreeToSixYearOldDAL();
            DataSet list = kidsThreeToSixYearOldDAL.GetList("IDCardNo='" + this.CardID + "' and flag=" + str);
			if (list != null && list.Tables.Count > 0 && list.Tables[0].Rows.Count > 0)
			{
                return kidsThreeToSixYearOldDAL.DataRowToModel(list.Tables[0].Rows[0]);
			}
			return null;
		}
	}
}
