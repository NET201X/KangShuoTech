using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QinCSoft.DataAccessProjects.Model;
using QinCSoft.DataAccessProjects.DAL;
using ReportPrint;
using System.Windows.Documents;

namespace printClass
{
    public class Urine : IGetReport
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
                return "33尿液数据表.xps";
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
                RecordsBaseInfoModel model = new RecordsBaseInfoDAL().GetModel(this.CardID);
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
                        strMark="$idcard",
                        strVal=model.IDCardNo
                    }
				};
                RecordsCustomerBaseInfoModel Customermodel = new RecordsCustomerBaseInfoDAL().GetMaxModel(this.CardID);
                if (Customermodel != null)
                {
                    list.Add(new ListValue 
                    {
                        strMark = "$gxrq",
                        strVal=DrawItems.strToDate(Customermodel.LastUpdateDate)
                    });
                    RecordsAssistCheckModel AssistModel = new RecordsAssistCheckDAL().GetModelByOutKey(Customermodel.ID);
                    if (AssistModel != null)
                    {
                        list.Add(new ListValue
                        {
                            strMark = "$bxp",
                            strVal = DrawItems.objToNumStr(AssistModel.WBC, 2)
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ndb",
                            strVal = AssistModel.PRO
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$qx",
                            strVal = AssistModel.BLD
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$tt",
                            strVal = AssistModel.KET
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ptt",
                            strVal = AssistModel.GLU
                        });
                    }
                   
                    
                }
                   return DrawItems.setPage("printXps\\33尿液数据表.xps", list);
            }
         return null;
        }
        
	}
}
