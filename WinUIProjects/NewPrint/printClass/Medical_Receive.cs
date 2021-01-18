
using ReportPrint;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;

namespace printClass
{
    public class Medical_Receive : IGetReport
	{
        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "30接诊记录表.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                DataSet list = new ReceiveTreatBaseInfoBLL().GetList("and IDCardNo='" + this.CardID + "'");
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
						strMark = "$idcard",
						strVal = model.IDCardNo
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
                ReceiveTreatBaseInfoModel receivemodel = new ReceiveTreatBaseInfoBLL().GetMaxModel(this.CardID);
                if (receivemodel != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "%zgzl",
                        strVal = receivemodel.SubjectiveData
                    });
                    list.Add(new ListValue
                    {
                        strMark = "%pinggu",
                        strVal = receivemodel.Assessment
                    });
                    list.Add(new ListValue
                    {
                        strMark = "%kgzl",
                        strVal = receivemodel.ObjectiveData 
                    });
                    list.Add(new ListValue
                    {
                        strMark = "%czjh",
                        strVal = receivemodel.ManagePlane
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$Doctname",
                        strVal = receivemodel.Doctor
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$jiezhenDate",
                        strVal = DrawItems.strToDate(receivemodel.ReceiveDate,1)
                    });
                }
                return DrawItems.setPage("printXps\\30接诊记录表.xps", list);
            }
            return null;
        }
	}
}
