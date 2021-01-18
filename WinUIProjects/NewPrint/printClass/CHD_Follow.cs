using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using ReportPrint;

namespace printClass
{
	public class CHD_Follow : IGetReport
	{
        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
		{
			get
			{
				return "20冠心病患者随访服务记录表.xps";
			}
		}

		public bool hasData()
		{
			if (!string.IsNullOrEmpty(this.CardID))
			{
				DataSet list = new ChronicChdVisitBLL().GetList(" IDCardNo='" + this.CardID + "'");
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
				ChronicChdVisitModel model2 = new ChronicChdVisitBLL().GetModel(this.CardID);
				if (model2 != null)
				{
					list.Add(new ListValue
					{
						strMark = "#zhzh",
						strVal = model2.Symptom
					});
					list.Add(new ListValue
					{
						strMark = "%zhzhex",
						strVal = model2.SymptomEx
					});
					list.Add(new ListValue
					{
						strMark = "$xy_h",
						strVal = DrawItems.objToNumStr(model2.Systolic, 0)
					});
					list.Add(new ListValue
					{
						strMark = "$xy_l",
						strVal = DrawItems.objToNumStr(model2.Diastolic, 0)
					});
					list.Add(new ListValue
					{
						strMark = "$tzh",
						strVal = DrawItems.objToNumStr(model2.Weight)
					});
					list.Add(new ListValue
					{
						strMark = "$dyxy",
						strVal = string.IsNullOrEmpty(model2.HearVoice) ? "" : ((model2.HearVoice == "1") ? "是" : "否")
					});
					list.Add(new ListValue
					{
						strMark = "$xlsc",
						strVal = string.IsNullOrEmpty(model2.HeartRate) ? "" : ((model2.HeartRate == "1") ? "是" : "否")
					});
					list.Add(new ListValue
					{
						strMark = "$xjb",
						strVal = string.IsNullOrEmpty(model2.Apex) ? "" : ((model2.Apex == "1") ? "是" : "否")
					});
					list.Add(new ListValue
					{
						strMark = "#sffsh",
						strVal = model2.VisitType
					});
					list.Add(new ListValue
					{
						strMark = "$yj",
						strVal = model2.Smoking
					});
					list.Add(new ListValue
					{
						strMark = "$yd",
						strVal = model2.Sports
					});
					list.Add(new ListValue
					{
						strMark = "$sy",
						strVal = model2.Salt
					});
					list.Add(new ListValue
					{
						strMark = "#zyxw",
						strVal = model2.Action
					});
					list.Add(new ListValue
					{
						strMark = "$fzjc",
						strVal = model2.AssistCheck
					});
					list.Add(new ListValue
					{
						strMark = "$xsgy",
						strVal = model2.AfterPill
					});
					list.Add(new ListValue
					{
						strMark = "#fyyc",
						strVal = model2.Compliance
					});
					list.Add(new ListValue
					{
						strMark = "#blfy",
						strVal = model2.Untoward
					});
					list.Add(new ListValue
					{
						strMark = "$blfyqt",
						strVal = model2.UntowardEx
					});
					list.Add(new ListValue
					{
						strMark = "#sffl",
						strVal = model2.FollowType
					});
					list.Add(new ListValue
					{
						strMark = "$zhzhyy",
						strVal = model2.ReferralReason
					});
					list.Add(new ListValue
					{
						strMark = "$zhzhjg",
						strVal = model2.ReferralDepart
					});
					list.Add(new ListValue
					{
						strMark = "$xcsfriq",
						strVal = DrawItems.strToDate(model2.NextVisitDate, 1)
					});
					list.Add(new ListValue
					{
						strMark = "$sfys",
						strVal = model2.VisitDoctor
					});
					list.Add(new ListValue
					{
						strMark = "$sfrq",
						strVal = DrawItems.strToDate(model2.VisitDate, 1)
					});
                    List<ChronicDrugConditionModel> modelList = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' and TYPE = '{1}' and OUTKey = '"+model2.ID+"' ", this.CardID, "4"));
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
                    strMark = "$yw" + num.ToString(),
                    strVal = current.Name
                });
                list.Add(new ListValue
                {
                    strMark = "$ywyf" + num.ToString(),
                    strVal = current.DosAge
                });

            }
            return list;
        }
    }
}
