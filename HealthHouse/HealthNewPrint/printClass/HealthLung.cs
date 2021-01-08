using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;
using System.Windows.Documents;
using ReportPrint;
using System.IO;

namespace printClass
{
    public class HealthLung : IGetReport
	{
        public string CardID
        {
            get;
            set;
        }
        public RecordsBaseInfoModel BaseModel
        {
            get;
            set;
        }
        public string PrintName
        {
            get
            {
                return "42肺功能.xps";
            }
        }
        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                HealthHouseModel modelTem = new HealthHouseBLL().GetMaxData(this.CardID);
                if (modelTem != null)
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
                List<ListValue> list = new List<ListValue>();
                HealthHouseModel Housemodel = new HealthHouseBLL().GetMaxData(this.CardID);
                if (Housemodel != null)
                {
                    if (!File.Exists(Housemodel.LImgPath))
                    {
                        list.Add(new ListValue
                        {
                            strMark = "&feigongneng",
                            strVal = ""
                        });
                    }
                    else
                    {
                        list.Add(new ListValue
                        {
                            strMark = "&feigongneng",
                            strVal = Housemodel.LImgPath
                        });
                    }
                }
                return DrawItems.setPage("printXps\\" + PrintName, list);
            }
            return null;
        }
	}
}
