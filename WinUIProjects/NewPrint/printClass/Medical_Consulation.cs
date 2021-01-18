
using ReportPrint;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;

namespace printClass
{
    public class Medical_Consulation : IGetReport
	{
        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "29会诊记录表.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                DataSet list = new ConsulationBaseInfoBLL().GetList("and IDCardNo='" + this.CardID + "'");
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
						strMark = "$name",
						strVal = model.CustomerName,
					},
                    new ListValue
                    {
                        strMark = "$idcard",
						strVal = model.IDCardNo,
                    },
                     new ListValue
                    {
                        strMark = "$adress",
						strVal = model.Address,
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
                ConsulationBaseInfoModel model1 = new ConsulationBaseInfoBLL().GetMaxModel(this.CardID);
                if(model1!=null)
                {

                   list.Add(new ListValue
                   {
                     strMark = "%hzreson",
				     strVal = model1.Reason,
                   });
                   list.Add(new ListValue
                   {
                      strMark = "$Doctname",
					  strVal = model1.ResponsibilityDoctor,
                   });
                   list.Add(new ListValue
                   {
                       strMark = "%hzview",
					  strVal = model1.View,
                   });
                   list.Add(new ListValue
                   {
                      strMark = "$huizhenDate",
						strVal = model1.ConsultationDate.ToString(),
                    });
               
                 DataSet consulateDate = new ConsulationDoctorsBLL().GetList(" OutKey='" + model1.ID + "'");

                if (consulateDate != null && consulateDate.Tables.Count > 0)
                {
                    DataTable dataTable = consulateDate.Tables[0];
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$yljg" + (i + 1).ToString(),
                            strVal = DrawItems.objToStr(dataTable.Rows[i]["ConsultationUnitName"]),

                        });
                        list.Add(new ListValue
                        {
                            strMark = "$hzys" + (i + 1).ToString() + "1",
                            strVal = DrawItems.objToStr(dataTable.Rows[i]["ConsultationDoctor1"]),

                        });
                        list.Add(new ListValue
                        {
                            strMark = "$hzys" + (i + 1).ToString() + "2",
                            strVal = DrawItems.objToStr(dataTable.Rows[i]["ConsultationDoctor2"]),
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$hzys" + (i + 1).ToString() + "3",
                            strVal = DrawItems.objToStr(dataTable.Rows[i]["ConsultationDoctor3"]),
                        });
                    }
                }
                }
              

               

                return DrawItems.setPage("printXps\\29会诊记录表.xps", list);
            }
            return null;
        }
	}
}
