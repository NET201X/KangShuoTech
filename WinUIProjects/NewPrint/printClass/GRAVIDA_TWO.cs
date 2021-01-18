
using ReportPrint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;
using System.Configuration;

namespace printClass
{
    public class GRAVIDA_TWO : IGetReport
    {
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Gravida/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Gravida//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "16第2～5次产前随访服务记录表.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                DataSet list = new WomenGravidaTwoToFiveVisitDAL().GetList(" IDCardNo='" + this.CardID + "'");
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
                return DrawItems.setPage("printXps\\16第2～5次产前随访服务记录表.xps", list);
            }
            return null;
        }

        public List<ListValue> getList(string monthType)
        {
            List<ListValue> list = new List<ListValue>();
            WomenGravidaTwoToFiveVisitModel model = this.getModel(monthType);
            if (model == null)
            {
                return null;
            }
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "fw",
                strVal = DrawItems.objToNumStr(model.AbdominalCirumference, 2)
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "gdgd",
                strVal = DrawItems.objToNumStr(model.UteruslowHeight, 1)
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "txl",
                strVal = DrawItems.objToNumStr(model.FHR, 1)
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "xgy",
                strVal = DrawItems.objToNumStr(model.HBloodPressure, 0)
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "xdy",
                strVal = DrawItems.objToNumStr(model.LBloodPressure, 0)
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "xhdb",
                strVal = DrawItems.objToNumStr(model.HB)
            });
            list.Add(new ListValue
            {
                strMark = "%" + monthType + "qtfz",
                strVal = model.AssistanTexam
            });
            list.Add(new ListValue
            {
                strMark = "#" + monthType + "fl",
                strVal = model.Classification
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "fly",
                strVal = model.ClassificationEx
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "zdqt",
                strVal = model.AdvisingOther
            });
            list.Add(new ListValue
            {
                strMark = "#" + monthType + "zd",
                strVal = model.Referral
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "zzyy",
                strVal = model.ReferralReason
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "zzjg",
                strVal = model.ReferralOrg
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "xcrq",
                strVal = DrawItems.strToDate(model.NextFollowupDate)
            });
            //list.Add(new ListValue
            //{
            //    strMark = "$" + MonthType + "sfys",
            //    strVal = model.FollowUpDoctor
            //});
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "ndb",
                strVal = model.PRO
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "sfrq",
                strVal = DrawItems.strToDate(model.FollowupDate)
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "yz",
                strVal = DrawItems.objToNumStr(model.PregancyWeeks, 0)
            });
            list.Add(new ListValue
            {
                strMark = "%" + monthType + "zs",
                strVal = model.ChiefComPlaint
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "tz",
                strVal = DrawItems.objToNumStr(model.Weight)
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "tw",
                strVal = model.FetusPosition
            });
            list.Add(new ListValue
            {
                strMark = "#" + monthType + "sf",
                strVal = model.FollowupWay
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "jgmc",
                strVal = model.PrenatalOrg
            });
            list.Add(new ListValue
            {
                strMark = "#" + monthType + "jc",
                strVal = model.FreeSerumCheck
            });
            //list.Add(new ListValue
            //{
            //    strMark = "@" + MonthType + "jcjg",
            //    strVal = model.SerumCheckResult
            //});
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "lxr",
                strVal = model.ReferralContacts
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "lxfs",
                strVal = model.ReferralContactsTel
            });
            list.Add(new ListValue
            {
                strMark = "#" + monthType + "dw",
                strVal = model.ReferralResult
            });
            list.Add(new ListValue
            {
                strMark = "$" + monthType + "jgmc",
                strVal = model.PrenatalOrg
            });
            list.Add(new ListValue
            {
                strMark = "&" + monthType + "qm",
                strVal = string.Format("{0}{1}_{2}.png", SignPath, model.IDCardNo, "PrenatalS_" + model.Times)
            });
            list.Add(new ListValue
            {
                strMark = "&" + monthType + "sfys",
                strVal = string.Format("{0}{1}_{2}_Doc.png", SignPath, model.IDCardNo, "PrenatalS_" + model.Times)
            });
            list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model.Advising), monthType, "zd", 8));
            list.AddRange(DrawItems.lsCheck(DrawItems.objToStr(model.SerumCheckResult), monthType, "jcjg", 4));
            return list;
        }

        private WomenGravidaTwoToFiveVisitModel getModel(string type)
        {
            string str = (Convert.ToInt32(type) + 1).ToString();
            WomenGravidaTwoToFiveVisitDAL womenGravidaTwoToFiveVisitDAL = new WomenGravidaTwoToFiveVisitDAL();
            DataSet list = womenGravidaTwoToFiveVisitDAL.GetList("IDCardNo='" + this.CardID + "' and times=" + str);
            if (list != null && list.Tables.Count > 0 && list.Tables[0].Rows.Count > 0)
            {
                return womenGravidaTwoToFiveVisitDAL.DataRowToModel(list.Tables[0].Rows[0]);
            }
            return null;
        }
    }
}
