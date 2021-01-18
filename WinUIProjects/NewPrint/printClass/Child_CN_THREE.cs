
using ReportPrint;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;

namespace printClass
{
	public class Child_CN_THREE : IGetReport
	{
        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
		{
			get
			{
				return "23三到六岁以内儿童中医药健康管理.xps";
			}
		}

		public bool hasData()
		{
			if (!string.IsNullOrEmpty(this.CardID))
			{
                DataSet list = new KidsTcmhmThreeToSixDAL().GetList(" IDCardNo='" + this.CardID + "'");
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
				return DrawItems.setPage("printXps\\23三到六岁以内儿童中医药健康管理.xps", list);
			}
			return null;
		}

		public List<ListValue> getList(string MonthType)
		{
			List<ListValue> list = new List<ListValue>();
			KidsTcmhmThreeToSixModel model = this.getModel(MonthType);
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
				strMark = "$" + MonthType + "sfys",
				strVal = DrawItems.objToStr(model.FollowUpDoctor)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "xcsf",
				strVal = DrawItems.strToDate(model.NextFollowupDate)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "qt",
				strVal = DrawItems.objToStr(model.TcmhmOther)
			});
			list.AddRange(DrawItems.lsCheck(model.Tcmhm, MonthType, "zd", 4));
			return list;
		}

		private KidsTcmhmThreeToSixModel getModel(string type)
		{
            KidsTcmhmThreeToSixDAL kidsTcmhmThreeToSixDAL = new KidsTcmhmThreeToSixDAL();
            DataSet list = kidsTcmhmThreeToSixDAL.GetList("IDCardNo='" + this.CardID + "' and FollowupType=" + type);
			if (list != null && list.Tables.Count > 0 && list.Tables[0].Rows.Count > 0)
			{
                return kidsTcmhmThreeToSixDAL.DataRowToModel(list.Tables[0].Rows[0]);
			}
			return null;
		}
	}
}
