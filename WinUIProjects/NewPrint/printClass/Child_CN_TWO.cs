
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
	public class Child_CN_TWO : IGetReport
	{
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Kids/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Kids//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
		{
			get
			{
                //return "22一到二岁以内儿童中医药健康管理.xps";
                return "24-36月龄儿童中医药健康管理.xps";
			}
		}

		public bool hasData()
		{
			if (!string.IsNullOrEmpty(this.CardID))
			{
                DataSet list = new KidsTcmhmOneToThreeDAL().GetList(" IDCardNo='" + this.CardID + "'");
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
                KidsTcmhmOneToThreeModel modelTwo2 = this.getModel("3");
                if (modelTwo2 != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$1sfrq",
                        strVal = DrawItems.strToDate(modelTwo2.FollowupDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$1xcsf",
                        strVal = DrawItems.strToDate(modelTwo2.NextFollowupDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$1qt",
                        strVal = DrawItems.objToStr(modelTwo2.TcmhmOther)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&1sfys",
                        strVal = string.Format("{0}{1}_Mec24_Doc.png", SignPath, this.CardID)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&1jz",
                        strVal = string.Format("{0}{1}_Mec24.png", SignPath, this.CardID)
                    });
                    list.AddRange(DrawItems.lsCheck(modelTwo2.Tcmhm, "1zd", 4));
                }
                KidsTcmhmOneToThreeModel modelTwo3 = this.getModel("4");
                if (modelTwo3 != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$2sfrq",
                        strVal = DrawItems.strToDate(modelTwo3.FollowupDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$2xcsf",
                        strVal = DrawItems.strToDate(modelTwo3.NextFollowupDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$2qt",
                        strVal = DrawItems.objToStr(modelTwo3.TcmhmOther)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&2sfys",
                        strVal = string.Format("{0}{1}_Mec30_Doc.png", SignPath, this.CardID)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&2jz",
                        strVal = string.Format("{0}{1}_Mec30.png", SignPath, this.CardID)
                    });
                    list.AddRange(DrawItems.lsCheck(modelTwo3.Tcmhm, "2zd", 4));
                }
                KidsTcmhmThreeToSixModel modelThree = this.getModelThree("1");
                if (modelThree != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$3sfrq",
                        strVal = DrawItems.strToDate(modelThree.FollowupDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$3xcsf",
                        strVal = DrawItems.strToDate(modelThree.NextFollowupDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$3qt",
                        strVal = DrawItems.objToStr(modelThree.TcmhmOther)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&3sfys",
                        strVal = string.Format("{0}{1}_Mec36_Doc.png", SignPath, this.CardID)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&3jz",
                        strVal = string.Format("{0}{1}_Mec36.png", SignPath, this.CardID)
                    });
                    list.AddRange(DrawItems.lsCheck(modelThree.Tcmhm, "3zd", 4));
                }
                //for (int i = 1; i < 5; i++)
                //{
                //    List<ListValue> list2 = this.getList(i.ToString());
                //    if (list2 != null)
                //    {
                //        list.AddRange(list2);
                //    }
                //}
                return DrawItems.setPage("printXps\\24-36月龄儿童中医药健康管理.xps", list);
			}
			return null;
		}

		public List<ListValue> getList(string MonthType)
		{
			List<ListValue> list = new List<ListValue>();
			KidsTcmhmOneToThreeModel  model = this.getModel(MonthType);
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

		private KidsTcmhmOneToThreeModel getModel(string type)
		{
            KidsTcmhmOneToThreeDAL kidsTcmhmOneToThreeDAL = new KidsTcmhmOneToThreeDAL();
            DataSet list = kidsTcmhmOneToThreeDAL.GetList("IDCardNo='" + this.CardID + "' and FollowupType=" + type);
			if (list != null && list.Tables.Count > 0 && list.Tables[0].Rows.Count > 0)
			{
                return kidsTcmhmOneToThreeDAL.DataRowToModel(list.Tables[0].Rows[0]);
			}
			return null;
		}

        private KidsTcmhmThreeToSixModel getModelThree(string type)
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
