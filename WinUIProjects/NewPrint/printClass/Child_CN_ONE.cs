
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
	public class Child_CN_ONE : IGetReport
	{
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Kids/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Kids//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
		{
			get
			{
                //return "21一岁以内儿童中医药健康管理.xps";
                return "6-18月龄儿童中医药健康管理服务记录表.xps";
			}
		}

		public bool hasData()
		{
			if (!string.IsNullOrEmpty(this.CardID))
			{
                DataSet list = new KidsTcmhmOneDAL().GetList(" IDCardNo='" + this.CardID + "'");
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
                KidsTcmhmOneModel modelOne = this.getModel("3");
                if (modelOne != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$1sfrq",
                        strVal = DrawItems.strToDate(modelOne.FollowupDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$1xcsf",
                        strVal = DrawItems.strToDate(modelOne.NextFollowDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$1qt",
                        strVal = DrawItems.objToStr(modelOne.TcmhmOther)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&1sfys",
                        strVal = string.Format("{0}{1}_Mec6_Doc.png", SignPath, this.CardID)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&1jz",
                        strVal = string.Format("{0}{1}_Mec6.png", SignPath, this.CardID)
                    });
                    list.AddRange(DrawItems.lsCheck(modelOne.Tcmhm, "1glfw", 4));
                }

                KidsTcmhmOneToThreeModel modelTwo1 = this.getTwoModel("1");
                if (modelTwo1 != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$2sfrq",
                        strVal = DrawItems.strToDate(modelTwo1.FollowupDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$2xcsf",
                        strVal = DrawItems.strToDate(modelTwo1.NextFollowupDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$2qt",
                        strVal = DrawItems.objToStr(modelTwo1.TcmhmOther)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&2sfys",
                        strVal = string.Format("{0}{1}_Mec12_Doc.png", SignPath, this.CardID)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&2jz",
                        strVal = string.Format("{0}{1}_Mec12.png", SignPath, this.CardID)
                    });
                    list.AddRange(DrawItems.lsCheck(modelTwo1.Tcmhm, "2glfw", 4));
                }
                KidsTcmhmOneToThreeModel modelTwo2 = this.getTwoModel("2");
                if (modelTwo2 != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$3sfrq",
                        strVal = DrawItems.strToDate(modelTwo2.FollowupDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$3xcsf",
                        strVal = DrawItems.strToDate(modelTwo2.NextFollowupDate)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$3qt",
                        strVal = DrawItems.objToStr(modelTwo2.TcmhmOther)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&3sfys",
                        strVal = string.Format("{0}{1}_Mec18_Doc.png", SignPath, this.CardID)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "&3jz",
                        strVal = string.Format("{0}{1}_Mec18.png", SignPath, this.CardID)
                    });
                    list.AddRange(DrawItems.lsCheck(modelTwo2.Tcmhm, "3glfw", 4));
                }

                //for (int i = 1; i < 5; i++)
                //{
                //    List<ListValue> list2 = this.getList(i.ToString());
                //    if (list2 != null)
                //    {
                //        list.AddRange(list2);
                //    }
                //}
                //return DrawItems.setPage("printXps\\21一岁以内儿童中医药健康管理.xps", list);
                return DrawItems.setPage("printXps\\6-18月龄儿童中医药健康管理服务记录表.xps", list);
			}
			return null;
		}

		public List<ListValue> getList(string MonthType)
		{
			List<ListValue> list = new List<ListValue>();
			KidsTcmhmOneModel model = this.getModel(MonthType);
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
				strVal = DrawItems.objToStr(model.FollowDoctor)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "xcsf",
				strVal = DrawItems.strToDate(model.NextFollowDate)
			});
			list.Add(new ListValue
			{
				strMark = "$" + MonthType + "qt",
				strVal = DrawItems.objToStr(model.TcmhmOther)
			});
			list.AddRange(DrawItems.lsCheck(model.Tcmhm, MonthType, "glfw", 4));
			return list;
		}

		private KidsTcmhmOneModel getModel(string type)
		{
            KidsTcmhmOneDAL kidsTcmhmOneDAL = new KidsTcmhmOneDAL();
            DataSet list = kidsTcmhmOneDAL.GetList("IDCardNo='" + this.CardID + "' and FollowupType=" + type);
			if (list != null && list.Tables.Count > 0 && list.Tables[0].Rows.Count > 0)
			{
                return kidsTcmhmOneDAL.DataRowToModel(list.Tables[0].Rows[0]);
			}
			return null;
		}

        private KidsTcmhmOneToThreeModel getTwoModel(string type)
        {
            KidsTcmhmOneToThreeDAL kidsTcmhmOneToThreeDAL = new KidsTcmhmOneToThreeDAL();
            DataSet list = kidsTcmhmOneToThreeDAL.GetList("IDCardNo='" + this.CardID + "' and FollowupType=" + type);
            if (list != null && list.Tables.Count > 0 && list.Tables[0].Rows.Count > 0)
            {
                return kidsTcmhmOneToThreeDAL.DataRowToModel(list.Tables[0].Rows[0]);
            }
            return null;
        }
	}
}
