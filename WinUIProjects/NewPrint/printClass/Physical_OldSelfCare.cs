using System;
using System.Collections.Generic;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.DAL;
using System.Windows.Documents;
using ReportPrint;
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.BLL;
using System.Configuration;

namespace printClass
{
    public class Physical_OldSelfCare : IGetReport
	{
        string area = ConfigHelper.GetSetNode("area");
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Year/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Year//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
		{
			get
			{
                if (area.Equals("禹城") || area.Equals("乐陵"))
                {
                    return "10老年人生活自理能力评估表（禹城）.xps";
                }
                else
                {
                    return "10老年人生活自理能力评估表（体检）.xps";
                }
               
			}
		}

		public bool hasData()
		{
			if (!string.IsNullOrEmpty(this.CardID))
			{
                RecordsCustomerBaseInfoModel CustomerModel = new RecordsCustomerBaseInfoDAL().GetMaxModel(this.CardID);
                if (CustomerModel != null)
                {
                    RecordsGeneralConditionModel GeneralModel = new RecordsGeneralConditionDAL().GetModelByOutKey(CustomerModel.ID);
                    if (GeneralModel.SelfID != 0)
                    {
                        return true;
                    }
                }
			}
			return false;
		}

		public FixedDocumentSequence getReport()
		{
			if (!string.IsNullOrEmpty(this.CardID))
			{
                RecordsBaseInfoModel model = new RecordsBaseInfoBLL().GetModel(this.CardID);
                string strage = "";
                DateTime dtage;
                decimal dnow = 0, dage = 0;
                if (model.Birthday != null)
                {
                    dtage = Convert.ToDateTime(model.Birthday);
                    dnow = Convert.ToDecimal(DateTime.Today.ToString("yyyyMMdd"));
                    dage = Convert.ToDecimal(dtage.ToString("yyyyMMdd"));
                    strage = Convert.ToString(dnow - dage).ToString();
                    switch (strage.Length)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4: strage = "0"; break;
                        case 5: strage = strage.Substring(0, 1); break;
                        case 6: strage = strage.Substring(0, 2); break;
                        case 7: strage = strage.Substring(0, 3); break;
                        default: break;

                    }
                }
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
					},
                    new ListValue
					{
						strMark = "$age",
						strVal = strage
					}
				};
                RecordsCustomerBaseInfoModel CustomerModel = new RecordsCustomerBaseInfoDAL().GetMaxModel(this.CardID);
                if (CustomerModel != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$pgrq",
                        strVal = DrawItems.strToDate(CustomerModel.CheckDate, 1)
                    });

                    RecordsGeneralConditionModel GeneralModel = new RecordsGeneralConditionDAL().GetModelByOutKey(CustomerModel.ID);
                    if (GeneralModel != null&&GeneralModel.SelfID!=0)
                    {
                        RecordsSelfcareabilityModel model2 = new RecordsSelfcareabilityBLL().GetModelID(GeneralModel.SelfID);
				        if (model2 != null)
				        {
					        list.Add(new ListValue
					        {
						        strMark = "$hd",
                                strVal = DrawItems.objToNum(model2.Activity, 0)
					        });
					       
					        list.Add(new ListValue
					        {
						        strMark = "$rc",
                                strVal = DrawItems.objToNum(model2.Tolet, 0)
					        });
                            if (model2.Dressing == 2m)
                            {
                                model2.Dressing = new decimal?(0m);
                            }
					        list.Add(new ListValue
					        {
						        strMark = "$cy",
                                strVal = DrawItems.objToNum(model2.Dressing, 0)
					        });
					        list.Add(new ListValue
					        {
						        strMark = "$sx",
                                strVal = DrawItems.objToNum(model2.Groming, 0)
					        });
					        if (model2.Dine == 2m)
					        {
						        model2.Dine = new decimal?(0m);
					        }
					        list.Add(new ListValue
					        {
						        strMark = "$jc",
                                strVal = DrawItems.objToNum(model2.Dine, 0)
					        });
					        list.Add(new ListValue
					        {
						        strMark = "$zf",
						        strVal = DrawItems.objToNumStr(model2.TotalScore, 2)
					        });
                            //一般情况签名
                            list.Add(new ListValue
                            {
                                strMark = "&pjysqm",
                                strVal = SignPath + "_Doctor1.png"
                            });
				        }
                    }
                }
                return DrawItems.setPage("printXps\\"+this.PrintName, list);
			}
			return null;
		}

		public void SaveReport(string Filename)
		{
			throw new NotImplementedException();
		}
	}
}
