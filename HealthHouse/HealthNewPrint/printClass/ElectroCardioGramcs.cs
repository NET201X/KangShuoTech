using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using printClass;
using System.IO;
using ReportPrint;

namespace printClass
{
	public class ElectroCardioGramcs : IGetReport
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
                return "38心电图.xps";
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
                    HealthHouseEcgModel ecgModel = new HealthHouseEcgBLL().GetModel(Housemodel.ID);
                    if (ecgModel != null)
                    {
                        if (!File.Exists(ecgModel.ImgPath))
                        {
                            list.Add(new ListValue
                            {
                                strMark = "&ecg",
                                strVal = ""
                            });
                        }
                        else
                        {
                            list.Add(new ListValue
                            {
                                strMark = "&ecg",
                                strVal = ecgModel.ImgPath
                            });
                        }
                    }
                }
                return DrawItems.setPage("printXps\\38心电图.xps", list); 
            }
                
            return null;
        }          
	}
}
