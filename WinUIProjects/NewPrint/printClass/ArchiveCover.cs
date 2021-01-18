
using ReportPrint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;
using System.Configuration;
using KangShuoTech.Utilities.Common;
using System.IO;

namespace printClass
{
    public class ArchiveCover : IGetReport
    {
        string PhotoPath = ConfigurationManager.AppSettings["PhotoPath"] == null ? System.Environment.CurrentDirectory + "\\photo" : ConfigurationManager.AppSettings["PhotoPath"].ToString();
        private string PhotosPath = ConfigurationManager.AppSettings["PhotosPath"] == null ? @"D:/QCSoft/photos/" : ConfigurationManager.AppSettings["PhotosPath"].ToString(); //拍照照片路径
        string area = ConfigHelper.GetSetNode("area");

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "01健康档案封面.xps";
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
                List<ListValue> dicVal = new List<ListValue>
                {
                    new ListValue
                    {
                        strMark = "$archiveid",
                        strVal = model.RecordID,
                        strType = "1"
                    },
                    new ListValue
                    {
                        strMark = "$name",
                        strVal = model.CustomerName
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
                        strMark = "$xzjd",
                        strVal = model.TownName
                    },
                    new ListValue
                    {
                        strMark = "$cunweihui",
                        strVal = model.VillageName
                    },
                    new ListValue
                    {
                        strMark = "$jddw",
                        strVal = model.CreateUnitName
                    },
                    new ListValue
                    {
                        strMark = "$jdr",
                        strVal =model.CreateMenName.Replace("\r\n","")
                    },
                    new ListValue
                    {
                        strMark = "$zrys",
                        strVal = model.Doctor
                    },
                    new ListValue
                    {
                        strMark = "$jdrq",
                        strVal = DrawItems.strToDate(model.CreateDate)
                    }
                };

                string path = PhotoPath + "\\" + model.IDCardNo + ".Jpeg";

                if (area.Equals("菏泽"))
                {
                    string path2 = PhotosPath + "Base//" + model.IDCardNo + ".jpg";

                    if (File.Exists(path2))
                    {
                        path = path2;
                    }
                }

                if (File.Exists(path))
                {
                    dicVal.Add(new ListValue
                    {
                        strMark = "&photo",
                        strVal = path
                    });
                }

                return DrawItems.setPage("printXps\\01健康档案封面.xps", dicVal);
            }

            return null;
        }
    }
}
