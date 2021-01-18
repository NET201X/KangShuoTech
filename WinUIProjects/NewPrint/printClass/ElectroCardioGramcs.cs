using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using printClass;
using System.IO;
using ReportPrint;
using System.Drawing;
using KangShuoTech.Utilities.Common;
using System.Configuration;

namespace printClass
{
    public class ElectroCardioGramcs : IGetReport
    {
        string area = ConfigHelper.GetSetNode("area");
        string community = ConfigHelper.GetSetNode("community");
        string ECGReport = ConfigurationManager.AppSettings["ECGReport"] == null ? @"D:\QCSoft\ECGPDF\outFile" : ConfigurationManager.AppSettings["ECGReport"].ToString();
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Year/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Year//"; //签名保存路径

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                return "38心电图.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                string strWhere = string.Format(" IDCardNo='{0}' AND Left(CreateTime,4)='{1}' order by CreateTime DESC limit 0,1 ", this.CardID, DateTime.Now.Year.ToString());
                DataSet list = new RecordsEcgDAL().GetList(strWhere);

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
                if (File.Exists("printtemp\\ecg.png")) File.Delete("printtemp\\ecg.png");

                string xdWhere = string.Format(" IDCardNo='{0}' AND LEFT(CreateTime,4)='{1}' ORDER BY CreateTime DESC,ID DESC LIMIT 0,1 ", this.CardID, DateTime.Now.Year.ToString());
                RecordsEcgModel ecgModel = new RecordsEcgBLL().GetModelByWhere(xdWhere);

                if (ecgModel == null) ecgModel = new RecordsEcgModel();

                List<ListValue> list = new List<ListValue>();
                string path = ECGReport + "\\" + ecgModel.MID + ".png";

                if (!File.Exists(path))
                {
                    list.Add(new ListValue
                    {
                        strMark = "&ecg",
                        strVal = ""
                    });
                }
                else
                {
                    //读取文件流
                    FileStream fs = new System.IO.FileStream(path, FileMode.Open, FileAccess.Read);

                    int byteLength = (int)fs.Length;
                    byte[] fileBytes = new byte[byteLength];
                    fs.Read(fileBytes, 0, byteLength);

                    //文件流关閉,文件解除锁定
                    fs.Close();
                    Image image = Image.FromStream(new MemoryStream(fileBytes));

                    //if (community.Equals("聊城东昌府区"))
                    //{
                    Graphics g = Graphics.FromImage(image);

                    #region 禹城 检查医生取文字版，审核医生取手写版，检查日期取心电createTime
                    if (area.Equals("禹城"))
                    {
                        RecordsSignatureModel signModel= new RecordsSignatureBLL().GetModelByOutKey(0, "签字维护");
                        if (signModel == null) signModel = new RecordsSignatureModel();

                        // 加载检查医生签名
                        string signPath = SignPath + "_Doctor16.png";

                        if (File.Exists(signPath))
                        {
                            //加载检查日期
                            string imgJianChaKong = SignPath + "_JianChaKongBai.png";
                            string imgJianChaZi = SignPath + "Date//" + CardID + "_imgJianChaZi.png";

                            if (!File.Exists(imgJianChaKong))
                            {
                                //创建一个200*40的空白图
                                Bitmap b1 = new Bitmap(200, 80); //新建位图zdb1
                                Graphics g1 = Graphics.FromImage(b1); //创建版b1的Graphics
                                g1.FillRectangle(Brushes.White, new Rectangle(0, 0, 200, 80)); //把b1涂成红色
                                b1.Save(imgJianChaKong);
                                b1.Dispose();
                            }

                            if (!File.Exists(SignPath + "Date"))
                            {
                                Directory.CreateDirectory(SignPath + "Date");
                            }

                            if (File.Exists(imgJianChaZi))
                            {
                                File.Delete(imgJianChaZi);
                            }

                            Bitmap bitmap = new Bitmap(imgJianChaKong);
                            Graphics gp = Graphics.FromImage(bitmap);
                            Font font = new Font("KaiTi", 40, FontStyle.Bold);
                            SolidBrush sbrush = new SolidBrush(Color.Black);
                            gp.DrawString(signModel.AECGSn, font, sbrush, 10, 2);

                            bitmap.Save(imgJianChaZi);
                            bitmap.Dispose();

                            Image imgrq = Image.FromFile(imgJianChaZi);
                            g.DrawImage(image, 0, 0, image.Width, image.Height);
                            g.DrawImage(imgrq, 300, 1950, imgrq.Width, imgrq.Height);
                        }
                        
                        //加载检查日期
                        string imgKong = SignPath + "_KongBai.png";
                        string imgZi = SignPath + "Date//" + CardID + "_imgZi.png";

                        //绑定检查日期
                        DateTime checkDate;
                        if (DateTime.TryParse(ecgModel.CreateTime.ToString(), out checkDate))
                        {
                            // 加载心电检查医生签名
                            string examinePath = SignPath + "_Doctor16.png";

                            if (File.Exists(SignPath + checkDate.ToString("yyyy-MM-dd") + "//_Doctor16.png"))
                            {
                                Image img = Image.FromFile(SignPath + checkDate.ToString("yyyy-MM-dd") + "//_Doctor16.png");

                                // 将医生签名拼接到检查医生的位置
                                g.DrawImage(image, 0, 0, image.Width, image.Height);
                                g.DrawImage(img, 1300, 1950, img.Width, img.Height);
                            }
                            else
                            {
                                if (File.Exists(examinePath))
                                {
                                    Image img = Image.FromFile(examinePath);

                                    // 将医生签名拼接到检查医生的位置
                                    g.DrawImage(image, 0, 0, image.Width, image.Height);
                                    g.DrawImage(img, 1300, 1950, img.Width, img.Height);
                                }
                            }
                            

                            if (!File.Exists(imgKong))
                            {
                                //创建一个200*40的空白图
                                Bitmap b1 = new Bitmap(200, 40); //新建位图zdb1
                                Graphics g1 = Graphics.FromImage(b1); //创建版b1的Graphics
                                g1.FillRectangle(Brushes.White, new Rectangle(0, 0, 200, 40)); //把b1涂成红色
                                b1.Save(imgKong);
                                b1.Dispose();
                            }

                            if (!File.Exists(SignPath + "Date"))
                            {
                                Directory.CreateDirectory(SignPath + "Date");
                            }

                            if (File.Exists(imgZi))
                            {
                                File.Delete(imgZi);
                            }

                            Bitmap bitmap = new Bitmap(imgKong);
                            Graphics gp = Graphics.FromImage(bitmap);
                            string label = checkDate.ToString("yyyy-MM-dd");
                            Font font = new Font("KaiTi", bitmap.Width / 10, FontStyle.Bold);
                            SolidBrush sbrush = new SolidBrush(Color.Black);
                            gp.DrawString(label, font, sbrush, 10, 2);

                            bitmap.Save(imgZi);
                            bitmap.Dispose();

                            Image imgrq = Image.FromFile(imgZi);
                            g.DrawImage(image, 0, 0, image.Width, image.Height);
                            g.DrawImage(imgrq, 1830, 1950, imgrq.Width, imgrq.Height);
                        }
                        else
                        {
                            // 加载心电检查医生签名
                            string examinePath = SignPath + "_Doctor16.png";

                            if (File.Exists(examinePath))
                            {
                                Image img = Image.FromFile(examinePath);

                                // 将医生签名拼接到检查医生的位置
                                g.DrawImage(image, 0, 0, image.Width, image.Height);
                                g.DrawImage(img, 1300, 1950, img.Width, img.Height);
                            }
                        }
                    }
                    #endregion
                    #region 乐陵
                    else if (area.Equals("乐陵"))
                    {
                        // 加载心电医生签名
                        string signPath = SignPath + "_Doctor16.png";

                        if (File.Exists(signPath))
                        {
                            Image img = Image.FromFile(signPath);

                            // 将医生签名拼接到检查医生的位置
                            g.DrawImage(image, 0, 0, image.Width, image.Height);
                            g.DrawImage(img, 300, 1950, img.Width, img.Height);
                        }

                        // 加载心电检查医生签名
                        string examinePath = SignPath + "_Doctor23.png";

                        if (File.Exists(examinePath))
                        {
                            Image img = Image.FromFile(examinePath);

                            // 将医生签名拼接到检查医生的位置
                            g.DrawImage(image, 0, 0, image.Width, image.Height);
                            g.DrawImage(img, 1300, 1950, img.Width, img.Height);
                        }

                        //加载检查日期
                        RecordsCustomerBaseInfoModel model2 = new RecordsCustomerBaseInfoModel();
                        string strYear = DateTime.Now.Year.ToString();
                        string strWhere = string.Format(" IDCardNo='{0}'AND LEFT(CheckDate,4)='{1}' ORDER BY CheckDate DESC LIMIT 0,1 ", this.CardID, DateTime.Now.Year);

                        string imgKong = SignPath + "_KongBai.png";
                        string imgZi = SignPath + "Date//" + CardID + "_imgZi.png";

                        //获取本年度最新一笔数据
                        model2 = new RecordsCustomerBaseInfoBLL().GetModelByWhere(strWhere);
                        if (model2 != null)
                        {
                            DateTime checkDate;
                            if (DateTime.TryParse(model2.CheckDate.ToString(), out checkDate))
                            {

                                if (!File.Exists(imgKong))
                                {
                                    //创建一个200*40的空白图
                                    Bitmap b1 = new Bitmap(200, 40); //新建位图zdb1
                                    Graphics g1 = Graphics.FromImage(b1); //创建版b1的Graphics
                                    g1.FillRectangle(Brushes.White, new Rectangle(0, 0, 200, 40)); //把b1涂成红色
                                    b1.Save(imgKong);
                                    b1.Dispose();
                                }

                                if (!File.Exists(SignPath + "Date"))
                                {
                                    Directory.CreateDirectory(SignPath + "Date");
                                }

                                if (File.Exists(imgZi))
                                {
                                    File.Delete(imgZi);
                                }

                                Bitmap bitmap = new Bitmap(imgKong);
                                Graphics gp = Graphics.FromImage(bitmap);
                                string label = checkDate.ToString("yyyy-MM-dd");
                                Font font = new Font("KaiTi", bitmap.Width / 10, FontStyle.Bold);
                                SolidBrush sbrush = new SolidBrush(Color.Black);
                                gp.DrawString(label, font, sbrush, 10, 2);

                                bitmap.Save(imgZi);
                                bitmap.Dispose();

                                Image imgrq = Image.FromFile(imgZi);
                                g.DrawImage(image, 0, 0, image.Width, image.Height);
                                g.DrawImage(imgrq, 1770, 1960, imgrq.Width, imgrq.Height);

                            }
                        }
                    }
                    #endregion
                    else
                    {
                        // 加载心电医生签名
                        string signPath = SignPath + "_Doctor16.png";

                        if (File.Exists(signPath))
                        {
                            Image img = Image.FromFile(signPath);

                            // 将医生签名拼接到检查医生的位置
                            g.DrawImage(image, 0, 0, image.Width, image.Height);
                            g.DrawImage(img, 300, 1950, img.Width, img.Height);
                        }
                    }

                    // 旋转图片
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);

                    fs.Close();
                    image.Save("printtemp\\ecg.png");

                    list.Add(new ListValue
                    {
                        strMark = "&ecg",
                        strVal = "printtemp\\ecg.png"
                    });

                    image.Dispose();
                }

                return DrawItems.setPage("printXps\\38心电图.xps", list);
            }

            return null;
        }
    }
}
