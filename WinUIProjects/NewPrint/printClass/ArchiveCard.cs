using ReportPrint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;

namespace printClass
{
	public class ArchiveCard : IGetReport
	{
        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
		{
			get
			{
				return "09居民健康档案信息卡.xps";
			}
		}

		public bool hasData()
		{
			if (!string.IsNullOrEmpty(this.CardID))
			{
                DataSet list = new RecordsCardDAL().GetList(" IDCardNo='" + this.CardID + "'");
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
                RecordsCardModel model2 = new RecordsCardDAL().GetModel(this.CardID);
				if (model2 != null)
				{
					list.Add(new ListValue
					{
						strMark = "$zrys",
						strVal = model2.Doctor
					});
					list.Add(new ListValue
					{
						strMark = "$lxdh1",
						strVal = model2.DoctorPhone
					});
					list.Add(new ListValue
					{
						strMark = "%qtsm",
						strVal = model2.Other
					});
					list.Add(new ListValue
					{
						strMark = "$name",
						strVal = model2.Name
					});
					list.Add(new ListValue
					{
						strMark = "$xb",
						strVal = model2.Sex
					});
					list.Add(new ListValue
					{
						strMark = "$csrq",
						strVal = DrawItems.strToDate(model2.Birthday)
					});
					list.Add(new ListValue
					{
						strMark = "$mxbqk",
                        strVal = model2.ChronicDiseasesOther
					});
					list.Add(new ListValue
					{
						strMark = "%gms",
						strVal = model2.AllergicHistory
					});
					list.Add(new ListValue
					{
						strMark = "$jtzz",
						strVal = model2.HomeAddr
					});
					list.Add(new ListValue
					{
						strMark = "$jtdh",
						strVal = model2.HomePhone
					});
					list.Add(new ListValue
					{
						strMark = "$jjlx",
						strVal = model2.UrgentName
					});
					list.Add(new ListValue
					{
						strMark = "$lxdh3",
						strVal = model2.UrgentPhone
					});
					list.Add(new ListValue
					{
						strMark = "$jdjg",
						strVal = model2.OrgName
					});
					list.Add(new ListValue
					{
						strMark = "$lxdh2",
						strVal = model2.OrgPhone
					});
					list.AddRange(DrawItems.lsCheck(model2.BloodType, "xx", 5));
					list.AddRange(DrawItems.lsCheck(model2.RH, "rh", 3));
					list.AddRange(DrawItems.lsCheck(model2.ChronicDiseases , "mb", 8));
				}
				return DrawItems.setPage("printXps\\09居民健康档案信息卡.xps", list);
			}
			return null;
		}
	}
}
