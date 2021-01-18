using System.Collections.Generic;
using KangShuoTech.DataAccessProjects.Model;
using System.Windows.Documents;
using ReportPrint;
using KangShuoTech.DataAccessProjects.BLL;

namespace printClass
{
    public class HealthReport : IGetReport
	{
        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
		{
			get
			{
				return "01健康封面.xps";
			}
		}

        public bool hasData()
        {
            return true;
        }

        public FixedDocumentSequence getReport()
        {
           
            if (!string.IsNullOrEmpty(this.CardID))
            {
                List<ListValue> list = new List<ListValue>();
                RecordsBaseInfoModel model = new RecordsBaseInfoBLL().GetModel(this.CardID);

                if (model.PopulationType.Contains("4"))//老年人
                {
                    list.Add(new ListValue
                    {
                        strMark = "@rq1",
                        strVal = "1"
                    });
                }
                if (model.PopulationType.Contains("6"))//高血压
                {
                    list.Add(new ListValue
                    {
                        strMark = "@rq2",
                        strVal = "1"
                    });
                }
                if (model.PopulationType.Contains("7"))//糖尿病
                {
                    list.Add(new ListValue
                    {
                        strMark = "@rq3",
                        strVal = "1"
                    });
                }
                if (!model.PopulationType.Contains("4") && !model.PopulationType.Contains("6") && !model.PopulationType.Contains("7"))
                {
                    list.Add(new ListValue
                    {
                        strMark = "@rq4",
                        strVal = "1"
                    });
                }
                list.Add(new ListValue
                {
                    strMark = "$name",
                    strVal = model.CustomerName
                });
                list.Add(new ListValue
                {
                    strMark = "$org",
                    strVal = model.CreateUnitName
                });
                list.Add(new ListValue
                {
                    strMark = "$conect",
                    strVal = model.ContactName
                });
                list.Add(new ListValue
                {
                    strMark = "$Phone",
                    strVal = model.Phone
                });
                list.Add(new ListValue
                {
                    strMark = "$town",
                    strVal = model.TownName.Replace("乡", "").Replace("镇", "").Replace("乡镇", "").Replace("街道", "")
                });
                list.Add(new ListValue
                {
                    strMark = "$village",
                    strVal = model.VillageName.Replace("村", "").Replace("社区", "")
                });

                return DrawItems.setPage("printXps\\" + this.PrintName, list);
            }

            return null;
        }
	}
}
