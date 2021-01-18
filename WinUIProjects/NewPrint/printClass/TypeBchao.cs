using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using System.Windows.Forms;
using System.IO;
using ReportPrint;
using System.Configuration;
using System.Drawing;
using KangShuoTech.Utilities.Common;

namespace printClass
{
	public class TypeBchao : IGetReport
	{
        string BChaoReport = ConfigurationManager.AppSettings["BChaoReport"] == null ? @"D:\QCSoft\TypeB" : ConfigurationManager.AppSettings["BChaoReport"].ToString();
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Year/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Year//"; //签名保存路径

        private BindingSource bds;
        string area = ConfigHelper.GetSetNode("area");

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "39B超.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                string bcWhere = string.Format("  AND PTNIDNO='{0}' AND Left(DIAGTM,4)='{1}' order by DIAGTM DESC limit 0,1 ", this.CardID, DateTime.Now.Year.ToString());

                DataSet list = new TypeBBLL().GetByWhere(bcWhere);

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
                string BcWhere = string.Format("  and PTNIDNO='{0}' AND LEFT(DIAGTM,4)='{1}' ORDER BY DIAGTM DESC,ID DESC LIMIT 0,1 ", this.CardID, DateTime.Now.Year.ToString());
                DataSet tbchao = new TypeBBLL().GetByWhere(BcWhere);

                string mId = "";

                if (tbchao != null)
                {
                    DataTable dt = tbchao.Tables[0];

                    if (dt.Rows.Count > 0) mId = dt.Rows[0]["MID"].ToString();
                }

                List<ListValue> list = new List<ListValue>();

                if (!File.Exists(BChaoReport + "\\" + mId + ".jpg"))
                {
                    list.Add(new ListValue
                    {
                        strMark = "&bchao",
                        strVal = ""
                    });
                }
                else 
                {
                    if (area.Equals("平度") || area.Equals("乐陵")||area.Equals("济南")||area.Equals("禹城") || area.Equals("菏泽") || area.Equals("聊城") || area.Equals("泰安"))
                    {
                        //读取文件流
                        FileStream fs = new System.IO.FileStream(BChaoReport + "\\" + mId + ".jpg", FileMode.Open, FileAccess.Read);

                        int byteLength = (int)fs.Length;
                        byte[] fileBytes = new byte[byteLength];
                        fs.Read(fileBytes, 0, byteLength);

                        //文件流关閉,文件解除锁定
                        fs.Close();
                        Image image = Image.FromStream(new MemoryStream(fileBytes));
                        Graphics g = Graphics.FromImage(image);

                        // 加载B超医生签名
                        string signPath = SignPath + "_Doctor17.png";

                        if (File.Exists(signPath))
                        {
                            Image img = Image.FromFile(signPath);

                            // 将医生签名拼接到诊断医生的位置之上
                            g.DrawImage(img, 450, 800, img.Width, img.Height);
                        }
                        fs.Close();
                        image.Save("printtemp\\bchao.png");

                        list.Add(new ListValue
                        {
                            strMark = "&bchao",
                            strVal = "printtemp\\bchao.png"
                        });

                        image.Dispose();
                    }
                    else
                    {
                        list.Add(new ListValue
                        {
                            strMark = "&bchao",
                            strVal = BChaoReport + "\\" + mId + ".jpg"
                        });
                    }
                }

                return DrawItems.setPage("printXps\\39B超.xps", list);
            }

            return null;
        }
	}
}
