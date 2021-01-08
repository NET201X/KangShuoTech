using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using printClass;
using System.Windows.Forms;
using System.IO;
using ReportPrint;

namespace printClass
{
	public class TypeBchao : IGetReport
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
                return "39B超.xps";
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
                    HealthHouseBCHAOModel Bchao = new HealthHouseBCHAOBLL().GetModel(Housemodel.ID);
                    if (Bchao != null)
                    {
                        if (!File.Exists(Bchao.ImgPath))
                        {
                            list.Add(new ListValue
                            {
                                strMark = "&bchao",
                                strVal = ""
                            });
                        }
                        else
                        {
                            list.Add(new ListValue
                            {
                                strMark = "&bchao",
                                strVal = Bchao.ImgPath
                            });
                        }
                    }
                }

                return DrawItems.setPage("printXps\\39B超.xps", list);
            }

            return null;
        }
	}
}
