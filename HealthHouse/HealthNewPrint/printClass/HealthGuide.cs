using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;
using System.Windows.Documents;
using ReportPrint;
using KangShuoTech.Utilities.Common;

namespace printClass
{
    public class HealthGuide : IGetReport
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
                return "44健康指导表.xps";
            }
        }

        /// <summary>
        /// 判断是否有健康指导信息
        /// </summary>
        /// <returns></returns>
        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                HealthHouseGuideModel modelGuide = new HealthHouseGuideBLL().GetGuideData(this.CardID);

                if (modelGuide != null)
                {
                    return true;
                }
            }

            return false;
        }

        private TimeParser timeParser = new TimeParser();

        public FixedDocumentSequence getReport()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                List<ListValue> list = new List<ListValue>();
                HealthHouseGuideModel modelGuide = new HealthHouseGuideBLL().GetGuideData(this.CardID);

                if (modelGuide != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$name",
                        strVal = modelGuide.CustomerName
                    });

                    list.Add(new ListValue
                    {
                        strMark = "$sex",
                        strVal = StringPlus.GetSex(modelGuide.Sex)
                    });

                    list.Add(new ListValue
                    {
                        strMark = "$age",
                        strVal = timeParser.GetAge(modelGuide.Birthday)
                    });

                    list.Add(new ListValue
                    {
                        strMark = "$date",
                        strVal = modelGuide.CheckDate.ToString().Substring(0,10)
                    });

                    list.Add(new ListValue
                    {
                        strMark = "%summary",
                        strVal = modelGuide.Summary
                    });

                    list.Add(new ListValue
                    {
                        strMark = "%healthGuid",
                        strVal = modelGuide.HealthGuid
                    });

                    list.Add(new ListValue
                    {
                        strMark = "%medGuid",
                        strVal = modelGuide.MedGuid
                    });
                }

                return DrawItems.setPage("printXps\\" + PrintName, list);
            }

            return null;
        }
    }
}
