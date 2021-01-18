using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using ReportPrint;
using System.Configuration;

namespace printClass
{
	public class Stroke_Followup : IGetReport
	{
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/PTBVisit/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "PTBVisit//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
		{
			get
			{
				return "19脑卒中患者随访服务记录表.xps";
			}
		}

		public bool hasData()
		{
			if (!string.IsNullOrEmpty(this.CardID))
			{
                DataSet list = new ChronicStrokeVisitBLL().GetList(" IDCardNo='" + this.CardID + "'");

				if (list != null && list.Tables.Count > 0 && list.Tables[0].Rows.Count > 0)
				{
					return true;
				}
			}

			return false;
		}

		public FixedDocumentSequence getReport()
		{
			List<ListValue> list = null;
			if (!string.IsNullOrEmpty(this.CardID))
			{
                RecordsBaseInfoModel model = new RecordsBaseInfoBLL().GetModel(this.CardID);
				list = new List<ListValue>
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
                ChronicStrokeVisitModel model2 = new ChronicStrokeVisitBLL().GetModel(this.CardID);
				if (model2 != null)
				{
					list.Add(new ListValue
					{
						strMark = "$xyzy",
						strVal = model2.SmokeDrinkAttention
					});
					list.Add(new ListValue
					{
						strMark = "$tzqt",
						strVal = model2.SignOther
					});
					list.Add(new ListValue
					{
						strMark = "$xdy",
						strVal = DrawItems.objToNumStr(model2.Hypotension, 0)
					});
					list.Add(new ListValue
					{
						strMark = "$xgy",
						strVal = DrawItems.objToNumStr(model2.Hypertension, 0)
					});
					list.Add(new ListValue
					{
						strMark = "%zzqt",
						strVal = model2.SymptomOther
					});
					list.Add(new ListValue
					{
						strMark = "#zz",
						strVal = model2.Symptom
					});
					list.Add(new ListValue
					{
						strMark = "$xcsfsj",
						strVal = DrawItems.strToDate(model2.NextFollowupDate)
					});
					list.Add(new ListValue
					{
						strMark = "$sfys",
						strVal = model2.FollowUpDoctor
					});
					list.Add(new ListValue
					{
						strMark = "$sfrq",
						strVal = DrawItems.strToDate(model2.FollowupDate)
					});
					list.Add(new ListValue
					{
						strMark = "%fyhzyw",
						strVal = model2.EatingDrug
					});
					list.Add(new ListValue
					{
						strMark = "#sffs",
						strVal = model2.FollowupWay
					});
					list.Add(new ListValue
					{
						strMark = "$zzjg",
						strVal = model2.ReferralOrg
					});
					list.Add(new ListValue
					{
						strMark = "$zzyy",
						strVal = model2.ReferralReason
					});
					list.Add(new ListValue
					{
						strMark = "#sffl",
						strVal = model2.FollowupType
					});
					list.Add(new ListValue
					{
						strMark = "$ywbly",
						strVal = model2.AdrEx
					});
					list.Add(new ListValue
					{
						strMark = "#ywbl",
						strVal = model2.Adr
					});
					list.Add(new ListValue
					{
						strMark = "#fyyc",
						strVal = model2.MedicationCompliance
					});
					list.Add(new ListValue
					{
						strMark = "%fzjc",
						strVal = model2.AssistantExam
					});
					list.Add(new ListValue
					{
						strMark = "#zyxw",
						strVal = model2.ObeyDoctorBehavio
					});
					list.Add(new ListValue
					{
						strMark = "#xltz",
						strVal = model2.PsychicAdjust
					});
					list.Add(new ListValue
					{
						strMark = "$syzy",
						strVal = model2.EatSaltAttention
					});
					list.Add(new ListValue
					{
						strMark = "$ydzy",
						strVal = model2.SportAttention
					});
					list.Add(new ListValue
					{
						strMark = "$tz",
						strVal = DrawItems.objToNumStr(model2.Weight)
					});
                    list.Add(new ListValue
                    {
                        strMark = "&qm",
                        strVal = string.Format("{0}{1}_{2}.png", SignPath, model2.IDCardNo, Convert.ToDateTime(model2.FollowupDate).ToString("yyyyMMdd"))
                    });
                    List<ChronicDrugConditionModel> modelList = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' and TYPE = '{1}' and OUTKey ='"+model2.ID+"' ", this.CardID, "5"));
                    if (modelList != null && modelList.Count > 0)
                    {
                        list.AddRange(this.getDrug(modelList).ToArray());
                    }
				}
			}
            return DrawItems.setPage("printXps\\"+this.PrintName, list);
		}

        public List<ListValue> getDrug(List<ChronicDrugConditionModel> drugs)
        {
            List<ListValue> list = new List<ListValue>();
            int num = 0;
            foreach (ChronicDrugConditionModel current in drugs)
            {
                num++;
                list.Add(new ListValue
                {
                    strMark = "$ywmc" + num.ToString(),
                    strVal = current.Name
                });
                list.Add(new ListValue
                {
                    strMark = "$mc" + num.ToString(),
                    strVal = current.DosAge
                });

            }
            return list;
        }
	}
}
