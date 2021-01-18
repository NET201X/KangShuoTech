
using ReportPrint;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using System;

namespace printClass
{
    public class Medical_Refferral : IGetReport
	{
        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "31双向转诊单.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                DataSet list = new ReferraBaseInfoBLL().GetList("and IDCardNo='" + this.CardID + "'");
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
						strMark = "$recordid",
						strVal = model.RecordID
					},
					new ListValue
					{
						strMark = "$name",
						strVal = model.CustomerName
					},
                    new ListValue
					{
						strMark = "$adress",
						strVal = model.Address
					}
				};
                string strsex = "";
                if (!string.IsNullOrEmpty(model.Sex))
                {
                    if (DrawItems.objToNumStr(model.Sex, 0) == "1")
                    {
                        strsex = "男";
                    }
                    if (DrawItems.objToNumStr(model.Sex, 0) == "2")
                    {
                        strsex = "女";
                    }
                    if (DrawItems.objToNumStr(model.Sex, 0) == "0")
                    {
                        strsex = "未知";
                    }
                    if (DrawItems.objToNumStr(model.Sex, 0) == "9")
                    {
                        strsex = "未说明";
                    }
                }
                list.Add(new ListValue
                {
                    strMark = "$sex",
                    strVal = strsex
                });
                int dage = 0;
                if (model.IDCardNo != null)
                {
                    dage = DateTime.Now.Year - Convert.ToInt32(model.IDCardNo.Substring(6, 4));

                }
                list.Add(new ListValue
                {
                    strMark = "$age",
                    strVal = dage.ToString(),
                });

                ReferraBaseInfoModel Referramodel = new ReferraBaseInfoDAL().GetMaxModel(this.CardID);
                if (Referramodel != null)
                {
                 
                    list.Add(new ListValue
                    {
                        strMark = "$phone",
                        strVal = Referramodel.SickPhone,
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$referdate",
                        strVal = DrawItems.strToDate(Referramodel.IllnessDate, 1)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$hospital",
                        strVal = Referramodel.NewUnitName
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$keshi",
                        strVal = Referramodel.NewDepartName 
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$jzDname",
                        strVal = Referramodel.NewDoctor
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zhuanzname",
                        strVal = Referramodel.RefDoctor
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zhuandate",
                        strVal = DrawItems.strToDate(Referramodel.TranseDate, 1)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$orghospital",
                        strVal = Referramodel.CreateUnitName
                    });
                    list.Add(new ListValue
                    {
                        strMark = "%cbyx",
                        strVal = Referramodel.FirstImpress
                    });
                    list.Add(new ListValue
                    {
                        strMark = "%zyxbs",
                        strVal = Referramodel.TransReason
                    });
                    list.Add(new ListValue
                    {
                        strMark = "%zyjws",
                        strVal = Referramodel.HistoryIllness
                    });
                    list.Add(new ListValue
                    {
                        strMark = "%zyjg",
                        strVal = Referramodel.Retrospectively
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$Doctname",
                        strVal = Referramodel.RefDoctor
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$lxdh",
                        strVal = Referramodel.RefDoctorPhone
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$orgname",
                        strVal = Referramodel.CreateUnitName
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zchuDate",
                        strVal = DrawItems.strToDate(Referramodel.TranseDate, 1)
                    });

                }
                return DrawItems.setPage("printXps\\31双向转诊单.xps", list);
            }
            return null;
        }
	}
}
