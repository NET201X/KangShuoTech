
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
	public class GRAVIDA_Postpartum : IGetReport
	{
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Gravida/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Gravida//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
		{
			get
			{
				return "17产后访视记录表.xps";
			}
		}

		public bool hasData()
		{
			if (!string.IsNullOrEmpty(this.CardID))
			{
				DataSet list = new WomenGravidaPostpartumDAL().GetList(" IDCardNo='" + this.CardID + "'");
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
				WomenGravidaPostpartumModel model2 = new WomenGravidaPostpartumDAL().GetModel(this.CardID);
				if (model2 != null)
				{
					list.Add(new ListValue
					{
						strMark = "$sfrq",
						strVal = DrawItems.strToDate(model2.FollowupDate)
					});
					list.Add(new ListValue
					{
						strMark = "$tw",
						strVal = DrawItems.objToNumStr(model2.Tem, 1)
					});
					list.Add(new ListValue
					{
						strMark = "%ybjk",
						strVal = model2.HealthCondition
					});
					list.Add(new ListValue
					{
						strMark = "%ybxl",
						strVal = model2.Mentalcondition
					});
					list.Add(new ListValue
					{
						strMark = "$xgy",
						strVal = DrawItems.objToNumStr(model2.HBbloodPressure, 0)
					});
					list.Add(new ListValue
					{
						strMark = "$xdy",
						strVal = DrawItems.objToNumStr(model2.LBloodPressure, 0)
					});
					list.Add(new ListValue
					{
						strMark = "#rf",
						strVal = model2.Breast
					});
					list.Add(new ListValue
					{
						strMark = "$rfyc",
						strVal = model2.BreastEx
					});
					list.Add(new ListValue
					{
						strMark = "#el",
						strVal = model2.Lochia
					});
					list.Add(new ListValue
					{
						strMark = "$elyc",
						strVal = model2.LochiaEx
					});
					list.Add(new ListValue
					{
						strMark = "#zg",
						strVal = model2.Uterus
					});
					list.Add(new ListValue
					{
						strMark = "$zgyc",
						strVal = model2.UterusEx
					});
					list.Add(new ListValue
					{
						strMark = "#sk",
						strVal = model2.Wound
					});
					list.Add(new ListValue
					{
						strMark = "$skyc",
						strVal = model2.WoundEx
					});
					list.Add(new ListValue
					{
						strMark = "%qt",
						strVal = model2.Other
					});
					list.Add(new ListValue
					{
						strMark = "#fl",
						strVal = model2.Classification
					});
					list.Add(new ListValue
					{
						strMark = "$flyc",
						strVal = model2.ClassificationEx
					});
					list.Add(new ListValue
					{
						strMark = "#zd",
						strVal = model2.Advising
					});
					list.Add(new ListValue
					{
						strMark = "$zdqt",
						strVal = model2.AdvisingOther
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
						strMark = "$xcsfrq",
						strVal = DrawItems.strToDate(model2.NextFollowupDate)
					});
                    //list.Add(new ListValue
                    //{
                    //    strMark = "$sfysqm",
                    //    strVal = model2.FollowupDoctor
                    //});
                    list.Add(new ListValue
                    {
                        strMark = "$fmrq",
                        strVal = DrawItems.strToDate(model2.DeliveryDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$cyrq",
                        strVal = DrawItems.strToDate(model2.LeaveHospitalDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zzlxr",
                        strVal =model2.ReferralContacts
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
                        strMark = "&qm",
                        strVal = string.Format("{0}{1}_{2}.png", SignPath, model2.IDCardNo, "PostpartumS")
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&sfysqm",
                        strVal = string.Format("{0}{1}_{2}_Doc.png", SignPath, model2.IDCardNo, "PostpartumS")
                    });
				}
				return DrawItems.setPage("printXps\\17产后访视记录表.xps", list);
			}
			return null;
		}
	}
}
