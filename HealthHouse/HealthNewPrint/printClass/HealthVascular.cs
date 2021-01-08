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
    public class HealthVascular : IGetReport
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
                return "41心血管.xps";
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
                    if (!File.Exists(Housemodel.CImgPath))
                    {
                        list.Add(new ListValue
                        {
                            strMark = "&xinxueguan",
                            strVal = ""
                        });
                    }
                    else
                    {
                        list.Add(new ListValue
                        {
                            strMark = "&xinxueguan",
                            strVal = Housemodel.CImgPath
                        });
                    }
                }
                return DrawItems.setPage("printXps\\" + PrintName, list);
            }
            return null;
        }
	}
}
