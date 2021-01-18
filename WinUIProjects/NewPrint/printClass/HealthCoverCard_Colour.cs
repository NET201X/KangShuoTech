using ReportPrint;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.Model;
using System.IO;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.Utilities.Common;
using System.Configuration;

namespace printClass
{
    public class HealthCoverCard_Colour : IGetReport
    {
        string area = ConfigHelper.GetSetNode("area");
        private string PhotoPath = ConfigurationManager.AppSettings["PhotoPath"] == null ? @"photo/" : ConfigurationManager.AppSettings["PhotoPath"].ToString(); //身份证照片路径
        private string PhotosPath = ConfigurationManager.AppSettings["PhotosPath"] == null ? @"D:/QCSoft/photos/" : ConfigurationManager.AppSettings["PhotosPath"].ToString(); //拍照照片路径

        public string PrintType { get; set; }

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "36居民健康体检表（彩页）.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                DataSet list = new RecordsBaseInfoBLL().GetList(" and IDCardNo='" + this.CardID + "'");
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
                string strsex = "";
                if (model.Sex != null)
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
                List<ListValue> dicVal = new List<ListValue>
                {
                    new ListValue
                    {
                        strMark = "$dahnum",
                        strVal = model.RecordID
                    },
                    new ListValue
                    {
                        strMark = "$xunum",
                        strVal = ""
                    },
                    new ListValue
                    {
                        strMark = "$name",
                        strVal = model.CustomerName
                    },
                    new ListValue
                    {
                        strMark = "$IdCardNo",
                        strVal = model.IDCardNo
                    },
                    new ListValue
                    {
                        strMark = "$sex",
                        strVal = strsex
                    },
                    new ListValue
                    {
                        strMark = "$address",
                        strVal = model.Address
                    },
                    new ListValue
                    {
                        strMark = "$huji",
                        strVal = model.HouseHoldAddress
                    },
                    new ListValue
                    {
                        strMark = "$lianxi",
                        strVal = model.Phone
                    },
                    new ListValue
                    {
                        strMark = "$jdrq",
                        strVal = DrawItems.strToDate(model.CreateDate)
                    }

                };
                string strUnit = "";
                string orgcode = ConfigHelper.GetNode("orgCode");
                string TownCode = (orgcode.Length < 9) ? "" : orgcode.Substring(0, 9);
                if (!string.IsNullOrEmpty(TownCode))
                {
                    SysOrgTownModel TownModel = new SysOrgTownBLL().GetModel(TownCode);
                    strUnit = TownModel.Name;
                }
                dicVal.Add(new ListValue
                {
                    strMark = "$jddw",
                    strVal = strUnit
                });
                RecordsCustomerBaseInfoModel model2 = new RecordsCustomerBaseInfoBLL().GetMaxModel(this.CardID);
                if (model2 != null)
                {
                    dicVal.Add(new ListValue
                    {
                        strMark = "$tjrq",
                        strVal = DrawItems.strToDate(model2.CheckDate, 1)
                    });
                }
                string path = PhotoPath + this.CardID + ".jpeg";

                if (area.Equals("菏泽"))
                {
                    string path2 = PhotosPath+ "Base//" + model.IDCardNo + ".jpg";
                    if (File.Exists(path2))
                    {
                        path = path2;
                    }
                }
                dicVal.Add(new ListValue
                {
                    strMark = "&photo",
                    strVal = path
                });
                return DrawItems.setPage("printXps\\" + PrintName, dicVal);
            }
            return null;
        }
    }
}
