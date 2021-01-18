using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using ReportPrint;
using Spire.Doc;
using Spire.Doc.Fields;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Xps.Packaging;

namespace printClass
{
    public class PhyicalReport : IGetReport
    {
        private string community = ConfigHelper.GetSetNode("community");
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Year/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Year//"; //签名保存路径
        private string PhotoPath = ConfigurationManager.AppSettings["PhotoPath"] == null ? System.Environment.CurrentDirectory + "//photo/" : ConfigurationManager.AppSettings["PhotoPath"].ToString(); //身份证照片路径
        string ECGReport = ConfigurationManager.AppSettings["ECGReport"] == null ? @"D:\QCSoft\ECGPDF\outFile" : ConfigurationManager.AppSettings["ECGReport"].ToString();
        string area = ConfigHelper.GetSetNode("area");

        private TimeParser timeParser = new TimeParser();

        public string CardID { get; set; }

        public RecordsBaseInfoModel BaseModel { get; set; }

        public string PrintName
        {
            get
            {
                if (area.Equals("禹城"))
                {
                    return "40体检报告(禹城).xps";
                }
                if (area.Equals("济宁"))
                {
                    return "40体检报告(济宁).xps";
                }
                if (community.Equals("桓台妇幼"))
                {
                    return "40体检报告(桓台妇幼).xps";
                }
                return "40体检报告.xps";
            }
        }

        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                string strWhere = string.Format(" IDCardNo='{0}'AND LEFT(CheckDate,4)='{1}' ORDER BY CheckDate DESC LIMIT 0,1 ", this.CardID, DateTime.Now.Year);
                RecordsCustomerBaseInfoModel model = new RecordsCustomerBaseInfoBLL().GetModelByWhere(strWhere);//获取本年度最新一笔数据
                if (model != null)
                {
                    return true;
                }
            }
            return false;
        }

        private TimeParser TimeP = new TimeParser();
        DataTable dtSH = null;
        DataTable dtMed = null;
        List<string> AbnormalList = new List<string>();

        public FixedDocumentSequence getReport()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                //SaveWord();

                bool reseult = SaveXPS();

                if (reseult)
                {
                    List<ListValue> dicVal = new List<ListValue> { };

                    return DrawItems.setPage("printXps\\" + PrintName, dicVal);
                }

                return null;
            }

            return null;
        }

        public void Replace(Document doc, string strold, object strnew)
        {
            if (strnew == null)
            {
                doc.Replace(strold, "", true, true);
            }
            else
            {
                doc.Replace(strold, strnew.ToString(), true, true);
            }
        }

        public bool SaveXPS()
        {
            if (area.Equals("禹城"))
            {
                if (!File.Exists(Environment.CurrentDirectory + "\\printXps\\40体检报告(禹城).docx"))
                {
                    return false;
                }
            }
            else if (area.Equals("济宁"))
            {
                if (!File.Exists(Environment.CurrentDirectory + "\\printXps\\40体检报告(济宁).docx"))
                {
                    return false;
                }
            }
            else
            {
                if (community == "桓台妇幼")
                {
                    if (!File.Exists(Environment.CurrentDirectory + "\\printXps\\40体检报告(桓台妇幼).docx"))
                    {
                        return false;
                    }
                }
                else
                if (!File.Exists(Environment.CurrentDirectory + "\\printXps\\40体检报告.docx"))
                {
                    return false;
                }
            }
            try
            {
                if (File.Exists("printXps\\40体检报告.xps"))
                {
                    File.Delete("printXps\\40体检报告.xps");
                }
                if (File.Exists("printXps\\" + PrintName))
                {
                    File.Delete("printXps\\" + PrintName);
                }

                AbnormalList = new List<string>();
                string strAdvice = "";
                RecordsBaseInfoModel model = new RecordsBaseInfoBLL().GetModel(this.CardID);
                RecordsCustomerBaseInfoModel model2 = new RecordsCustomerBaseInfoModel();
                RecordsGeneralConditionModel model3 = new RecordsGeneralConditionModel();
                RecordsAssistCheckModel model7 = new RecordsAssistCheckModel();
                RecordsAssessmentGuideModel GuideModel = new RecordsAssessmentGuideModel();
                RecordsHealthQuestionModel HealthQuestionModel = new RecordsHealthQuestionModel();
                string strYear = DateTime.Now.Year.ToString();
                if (model == null) return false;

                string strWhere = string.Format(" IDCardNo='{0}'AND LEFT(CheckDate,4)='{1}' ORDER BY CheckDate DESC LIMIT 0,1 ", this.CardID, DateTime.Now.Year);
                model2 = new RecordsCustomerBaseInfoBLL().GetModelByWhere(strWhere);//获取本年度最新一笔数据
                if (model2 == null) return false;

                strYear = strYear = model2.CheckDate.Value.Year.ToString();
                model3 = new RecordsGeneralConditionDAL().GetModelByOutKey(model2.ID);
                model7 = new RecordsAssistCheckBLL().GetModelByOutKey(model2.ID);
                GuideModel = new RecordsAssessmentGuideDAL().GetModelByOutKey(model2.ID);
                if (area == "乐陵" || area == "济宁" || area == "禹城")
                {
                    HealthQuestionModel = new RecordsHealthQuestionBLL().GetModelByOutKey(model2.ID);
                }

                if (model3 == null) model3 = new RecordsGeneralConditionModel();
                if (model7 == null) model7 = new RecordsAssistCheckModel();
                if (GuideModel == null) GuideModel = new RecordsAssessmentGuideModel();
                Document doc;
                if (area.Equals("禹城"))
                {
                    doc = new Document(Environment.CurrentDirectory + "\\printXps\\40体检报告(禹城).docx");
                }
                else if (area.Equals("济宁"))
                {
                    doc = new Document(Environment.CurrentDirectory + "\\printXps\\40体检报告(济宁).docx");
                }
                else
                {
                    if (community == "桓台妇幼")
                    {
                        doc = new Document(Environment.CurrentDirectory + "\\printXps\\40体检报告(桓台妇幼).docx");
                    }
                    else
                    {
                        doc = new Document(Environment.CurrentDirectory + "\\printXps\\40体检报告.docx");
                    }
                }
                string strUnit = "";
                string orgcode = ConfigHelper.GetNode("orgCode");
                string TownCode = (orgcode.Length < 9) ? "" : orgcode.Substring(0, 9);

                if (!string.IsNullOrEmpty(TownCode))
                {
                    SysOrgTownModel TownModel = new SysOrgTownBLL().GetModel(TownCode);
                    if (TownModel != null)
                    {
                        strUnit = TownModel.Name;
                    }
                }

                Replace(doc, "{Unite}", strUnit);

                if (area.Equals("禹城"))
                {
                    string a = timeParser.GetAge(model.Birthday);//禹城大于65岁
                    if (Convert.ToInt32(a) >= 65 || toString(model.PopulationType).Contains("4"))
                        Replace(doc, "{@rq1}", "√");//老年人
                    else
                        Replace(doc, "{@rq1}", "");//老年人

                    //PopulationType包含6 高血压  健康问题HeartDis 包含7 高血压
                    if (toString(model.PopulationType).Contains("6") || (!string.IsNullOrEmpty(HealthQuestionModel.HeartDis) && HealthQuestionModel.HeartDis.Contains("7")))
                        Replace(doc, "{@rq2}", "√");//高血压
                    else
                        Replace(doc, "{@rq2}", "");//高血压

                    if (toString(model.PopulationType).Contains("7") || (!string.IsNullOrEmpty(HealthQuestionModel.ElseDis) && HealthQuestionModel.ElseDis.Contains("2")))
                        Replace(doc, "{@rq3}", "√");//糖尿病
                    else
                        Replace(doc, "{@rq3}", "");//糖尿病

                }
                else
                {
                    Replace(doc, "{@rq1}", toString(model.PopulationType).Contains("4") ? "√" : "");//老年人
                    Replace(doc, "{@rq2}", toString(model.PopulationType).Contains("6") ? "√" : "");//高血压
                    Replace(doc, "{@rq3}", toString(model.PopulationType).Contains("7") ? "√" : "");//糖尿病

                }
                string strrq4 = "";

                if (!toString(model.PopulationType).Contains("4") && !toString(model.PopulationType).Contains("6") && !toString(model.PopulationType).Contains("7"))
                {
                    strrq4 = "√";
                }
                Replace(doc, "{@rq4}", strrq4);//其他人群
                Replace(doc, "{$town}", toString(model.TownName).Replace("乡", "").Replace("镇", "").Replace("乡镇", "").Replace("街道", ""));
                Replace(doc, "{$village}", toString(model.VillageName).Replace("居委会", "").Replace("村委会", "").Replace("社区", ""));
                Replace(doc, "{$conect}", model2.Doctor);

                if (area == "济宁")
                {
                    Replace(doc, "{$zrysdh}", ConfigHelper.GetNode("doctorPhone"));
                }

                double BMImin = 18;

                if (area == "平度")
                {
                    Replace(doc, "{$RBMI}", "18.5-23.9");
                    BMImin = 18.5;
                }
                else
                {
                    Replace(doc, "{$RBMI}", "18-24");
                }

                if (File.Exists(Application.StartupPath + "\\SHValueRange.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(Application.StartupPath + "\\SHValueRange.xml");
                    dtSH = ds.Tables[0];
                }

                if (File.Exists(Application.StartupPath + "\\mediphys.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(Application.StartupPath + "\\mediphys.xml");
                    dtMed = ds.Tables[0];
                }

                Replace(doc, "{$yydz}", ConfigHelper.GetSetNode("address"));
                Replace(doc, "{$zxdh}", ConfigHelper.GetSetNode("phone"));
                Replace(doc, "{$idcardno}", model.IDCardNo);
                Replace(doc, "{$name}", model.CustomerName);
                Replace(doc, "{$address}", model.Address);
                Replace(doc, "{$phone}", model.Phone);
                Replace(doc, "{$jddw}", model.CreateUnitName);
                Replace(doc, "{$recordid}", model.RecordID);
                Replace(doc, "{$Uphone}", ConfigHelper.GetSetNode("phone"));

                string strage = TimeP.GetAge(model.Birthday);
                string strSex = "";

                if (model.Sex == "1") strSex = "男";
                else if (model.Sex == "2") strSex = "女";

                Replace(doc, "{$sex}", strSex);
                Replace(doc, "{$age}", strage);
                Replace(doc, "{$tjrq}", DrawItems.strToDate(model2.CheckDate));
                Replace(doc, "{$sg}", model3.Height);
                Replace(doc, "{$tz}", model3.Weight);
                Replace(doc, "{$BMI}", model3.BMI);
                Replace(doc, "{$zcxy}", toString(model3.LeftHeight) + "/" + toString(model3.LeftPre));
                Replace(doc, "{$ycxy}", toString(model3.RightHeight) + "/" + toString(model3.RightPre));
                Replace(doc, "{$ml}", model3.PulseRate);
                Replace(doc, "{$arm}", GuideModel.Arm);

                string strBlood = "";

                if (community.Equals("桓台妇幼"))
                {
                    if (!string.IsNullOrEmpty(model7.BloodType))
                    {
                        switch (model.BloodType)
                        {
                            case "1":
                                strBlood = "A型";
                                break;
                            case "2":
                                strBlood = "B型";
                                break;
                            case "3":
                                strBlood = "O型";
                                break;
                            case "4":
                                strBlood = "AB型";
                                break;
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(model.BloodType))
                    {
                        switch (model.BloodType)
                        {
                            case "1":
                                strBlood = "A型";
                                break;
                            case "2":
                                strBlood = "B型";
                                break;
                            case "3":
                                strBlood = "O型";
                                break;
                            case "4":
                                strBlood = "AB型";
                                break;
                        }
                    }
                }

                Replace(doc, "{$xx}", strBlood);

                if (!string.IsNullOrEmpty(Convert.ToString(model3.BMI)))
                {
                    if (Convert.ToDouble(model3.BMI) < BMImin)//偏瘦
                    {
                        AbnormalList.Add("偏瘦");
                    }
                    else if (Convert.ToDouble(model3.BMI) > 24)//偏胖
                    {
                        AbnormalList.Add("偏胖");
                    }
                }

                #region 血压
                string strRightHeight = "", strRightPre = "", strLeftHeight = "", strLeftPre = "";
                strRightHeight = toString(model3.RightHeight);
                strRightPre = toString(model3.RightPre);
                strLeftHeight = toString(model3.LeftHeight);
                strLeftPre = toString(model3.LeftPre);

                string age = timeParser.GetAge(model.Birthday);

                bool oldManFlag = false;
                if (Convert.ToInt32(age) >= 65) oldManFlag = true;
                int BloodPreMax = 140; //收缩压正常人群血压范围值为140 / 90
                int BloodPreMin = 90;//

                int BloodHeightMax = 90;//舒张压正常人群血压范围值90/60
                int BloodHeightMin = 60;

                foreach (DataRow item in dtSH.Rows)
                {
                    if (item["name"].ToString() == "收缩压")
                    {
                        BloodPreMax = int.Parse(item["maxvalue"].ToString());
                        BloodPreMin = int.Parse(item["minvalue"].ToString());
                    }
                    if (item["name"].ToString() == "舒张压")
                    {
                        BloodHeightMax = int.Parse(item["maxvalue"].ToString());
                        BloodHeightMin = int.Parse(item["minvalue"].ToString());
                    }
                }

                if (community.Equals("顾官屯卫生院") || community.Equals("聊城东昌府区") || area.Equals("泰安"))
                {
                    if (oldManFlag)
                    {
                        BloodPreMax = 150;
                    }
                }
                else if (area.Equals("乐陵"))
                {
                    if (oldManFlag)
                    {
                        BloodPreMax = 150;
                    }
                    else if (HealthQuestionModel != null)
                    {
                        if (!string.IsNullOrEmpty(HealthQuestionModel.HeartDis) && HealthQuestionModel.HeartDis.Contains("7"))
                            BloodPreMax = 150;
                    }
                }
                else if (area.Equals("济宁"))
                {
                    if (HealthQuestionModel != null)
                    {
                        if (!string.IsNullOrEmpty(HealthQuestionModel.HeartDis) && HealthQuestionModel.HeartDis.Contains("7"))
                        {
                            if (oldManFlag)
                            {
                                BloodPreMax = 150;
                            }
                        }
                    }
                }

                bool flagxy = false;
                if (!string.IsNullOrEmpty(strRightHeight) && !string.IsNullOrEmpty(strRightPre)) //右侧血压判断
                {
                    if (Convert.ToDouble(strRightHeight) >= BloodPreMax || Convert.ToDouble(strRightPre) >= BloodHeightMax)
                    {
                        AbnormalList.Add("血压高");
                        flagxy = true;
                    }
                    else if (Convert.ToDouble(strRightHeight) < BloodPreMin || Convert.ToDouble(strRightPre) < BloodHeightMin)
                    {
                        AbnormalList.Add("血压低");
                        flagxy = true;
                    }
                }
                if (!flagxy && !string.IsNullOrEmpty(strLeftHeight) && !string.IsNullOrEmpty(strLeftPre)) //左侧血压判断
                {
                    if (Convert.ToDouble(strLeftHeight) >= BloodPreMax || Convert.ToDouble(strLeftPre) >= BloodHeightMax)
                    {
                        AbnormalList.Add("血压高");
                    }
                    else if (Convert.ToDouble(strLeftHeight) < BloodPreMin || Convert.ToDouble(strLeftPre) < BloodHeightMin)
                    {
                        AbnormalList.Add("血压低");
                    }
                }
                #endregion

                string[] strRes = new string[3];
                string strHBItem = "血红蛋白", strSGPTItem = "血清谷丙转氨酶", strGOTItem = "血清谷草转氨酶"
                    , strSCRItem = "血清肌酐";
                if (model.Sex == "1")
                {
                    strSGPTItem = "血清谷丙转氨酶男";
                    strGOTItem = "血清谷草转氨酶男";
                    strHBItem = "血红蛋白男";
                    strSCRItem = "血清肌酐男";
                }
                else if (model.Sex == "2")
                {
                    strSGPTItem = "血清谷丙转氨酶女";
                    strGOTItem = "血清谷草转氨酶女";
                    strHBItem = "血红蛋白女";
                    strSCRItem = "血清肌酐女";
                }

                strRes = ReadRange("空腹血糖", "", model7.FPGL, true);
                Replace(doc, "{$xt}", model7.FPGL);
                Replace(doc, "{$Rxt}", strRes[0]);
                Replace(doc, "{$Cxt}", strRes[1]);
                Replace(doc, "{$Txt}", strRes[2]);

                strRes = ReadRange("血清谷丙转氨酶", strSGPTItem, model7.SGPT, true);
                Replace(doc, "{$gbm}", model7.SGPT);
                Replace(doc, "{$Rgbm}", strRes[0]);
                Replace(doc, "{$Cgbm}", strRes[1]);
                Replace(doc, "{$Tgbm}", strRes[2]);

                strRes = ReadRange("血清谷草转氨酶", strGOTItem, model7.GOT, true);
                Replace(doc, "{$gcm}", model7.GOT);
                Replace(doc, "{$Rgcm}", strRes[0]);
                Replace(doc, "{$Cgcm}", strRes[1]);
                Replace(doc, "{$Tgcm}", strRes[2]);

                strRes = ReadRange("血清肌酐", strSCRItem, model7.SCR, true);
                Replace(doc, "{$xqjg}", model7.SCR);
                Replace(doc, "{$Rxqjg}", strRes[0]);
                Replace(doc, "{$Cxqjg}", strRes[1]);
                Replace(doc, "{$Txqjg}", strRes[2]);

                strRes = ReadRange("总胆红素", "", model7.TBIL, true);
                Replace(doc, "{$zdhs}", model7.TBIL);
                Replace(doc, "{$Rzdhs}", strRes[0]);
                Replace(doc, "{$Czdhs}", strRes[1]);
                Replace(doc, "{$Tzdhs}", strRes[2]);

                //ReadRange("结合胆红素", "", model7.CB);
                //ReadRange("谷氨酰转肽酶", "", model7.GT);

                strRes = ReadRange("血尿素氮", "", model7.BUN, true);
                Replace(doc, "{$xns}", model7.BUN);
                Replace(doc, "{$Rxns}", strRes[0]);
                Replace(doc, "{$Cxns}", strRes[1]);
                Replace(doc, "{$Txns}", strRes[2]);

                strRes = ReadRange("总胆固醇", "", model7.TC, true);
                Replace(doc, "{$dgc}", model7.TC);
                Replace(doc, "{$Rdgc}", strRes[0]);
                Replace(doc, "{$Cdgc}", strRes[1]);
                Replace(doc, "{$Tdgc}", strRes[2]);

                strRes = ReadRange("甘油三酯", "", model7.TG, true);
                Replace(doc, "{$gysz}", model7.TG);
                Replace(doc, "{$Rgysz}", strRes[0]);
                Replace(doc, "{$Cgysz}", strRes[1]);
                Replace(doc, "{$Tgysz}", strRes[2]);

                strRes = ReadRange("血清低密度脂蛋白胆固醇", "", model7.LowCho, true);
                Replace(doc, "{$dmdb}", model7.LowCho);
                Replace(doc, "{$Rdmdb}", strRes[0]);
                Replace(doc, "{$Cdmdb}", strRes[1]);
                Replace(doc, "{$Tdmdb}", strRes[2]);

                strRes = ReadRange("血清高密度脂蛋白胆固醇", "", model7.HeiCho, true);
                Replace(doc, "{$gmdb}", model7.HeiCho);
                Replace(doc, "{$Rgmdb}", strRes[0]);
                Replace(doc, "{$Cgmdb}", strRes[1]);
                Replace(doc, "{$Tgmdb}", strRes[2]);

                strRes = ReadRange("白细胞", "", model7.WBC, true);
                Replace(doc, "{$wbc}", model7.WBC);
                Replace(doc, "{$Rwbc}", strRes[0]);
                Replace(doc, "{$Cwbc}", strRes[1]);
                Replace(doc, "{$Twbc}", strRes[2]);

                strRes = ReadRange("血小板", "", model7.PLT, true);
                Replace(doc, "{$plt}", model7.PLT);
                Replace(doc, "{$Rplt}", strRes[0]);
                Replace(doc, "{$Cplt}", strRes[1]);
                Replace(doc, "{$Tplt}", strRes[2]);

                strRes = ReadRange("血红蛋白", strHBItem, model7.HB, true);
                Replace(doc, "{$hgb}", model7.HB);
                Replace(doc, "{$Rhgb}", strRes[0]);
                Replace(doc, "{$Chgb}", strRes[1]);
                Replace(doc, "{$Thgb}", strRes[2]);

                if (community == "桓台妇幼")
                {
                    strRes = ReadRange("糖化血红蛋白", "", model7.HBALC, true);
                    Replace(doc, "{$thdb}", model7.HBALC);
                    Replace(doc, "{$Rthdb}", strRes[0]);
                    Replace(doc, "{$Cthdb}", strRes[1]);
                    Replace(doc, "{$Tthdb}", strRes[2]);
                }

                if (toString(model7.ECG) != "" && toString(model7.ECG) != "1") AbnormalList.Add("心电异常");
                if (toString(model7.BCHAO) == "2") AbnormalList.Add("B超异常");

                #region 血常规

                string strXcWhere = string.Format("IDCardNo='{0}' AND LEFT(TestTime,4)='{1}' ORDER BY TestTime DESC,ID DESC LIMIT 0,1 ", this.CardID, strYear);
                DataSet BlooDt = new RecordsxqDAL().GetDT(strXcWhere);

                object value = ReadDS(BlooDt, "RBC");
                strRes = ReadRange("红细胞数目", "", value);
                Replace(doc, "{$rbc}", value);
                Replace(doc, "{$Rrbc}", strRes[0]);
                Replace(doc, "{$Crbc}", strRes[1]);
                Replace(doc, "{$Trbc}", strRes[2]);

                value = ReadDS(BlooDt, "HCT");
                strRes = ReadRange("红细胞压积", "", value);
                Replace(doc, "{$hct}", value);
                Replace(doc, "{$Rhct}", strRes[0]);
                Replace(doc, "{$Chct}", strRes[1]);
                Replace(doc, "{$Thct}", strRes[2]);

                value = ReadDS(BlooDt, "MCV");
                strRes = ReadRange("平均红细胞体积", "", value);
                Replace(doc, "{$mcv}", value);
                Replace(doc, "{$Rmcv}", strRes[0]);
                Replace(doc, "{$Cmcv}", strRes[1]);
                Replace(doc, "{$Tmcv}", strRes[2]);

                value = ReadDS(BlooDt, "MCH");
                strRes = ReadRange("平均红细胞血红蛋白含量", "", value);
                Replace(doc, "{$mch}", value);
                Replace(doc, "{$Rmch}", strRes[0]);
                Replace(doc, "{$Cmch}", strRes[1]);
                Replace(doc, "{$Tmch}", strRes[2]);

                value = ReadDS(BlooDt, "MCHC");
                strRes = ReadRange("平均红细胞血红蛋白浓度", "", value);
                Replace(doc, "{$mchc}", value);
                Replace(doc, "{$Rmchc}", strRes[0]);
                Replace(doc, "{$Cmchc}", strRes[1]);
                Replace(doc, "{$Tmchc}", strRes[2]);

                value = ReadDS(BlooDt, "MPV");
                strRes = ReadRange("平均血小板体积", "", value);
                Replace(doc, "{$mpv}", value);
                Replace(doc, "{$Rmpv}", strRes[0]);
                Replace(doc, "{$Cmpv}", strRes[1]);
                Replace(doc, "{$Tmpv}", strRes[2]);

                value = ReadDS(BlooDt, "RDW_SD");
                strRes = ReadRange("红细胞分布宽度标准差", "", value);
                Replace(doc, "{$sd}", value);
                Replace(doc, "{$Rsd}", strRes[0]);
                Replace(doc, "{$Csd}", strRes[1]);
                Replace(doc, "{$Tsd}", strRes[2]);

                value = ReadDS(BlooDt, "RDW_CV");
                strRes = ReadRange("红细胞分布宽度变异系数", "", value);
                Replace(doc, "{$cv}", value);
                Replace(doc, "{$Rcv}", strRes[0]);
                Replace(doc, "{$Ccv}", strRes[1]);
                Replace(doc, "{$Tcv}", strRes[2]);

                value = ReadDS(BlooDt, "PCT");
                strRes = ReadRange("血小板压积", "", value);
                Replace(doc, "{$pct}", value);
                Replace(doc, "{$Rpct}", strRes[0]);
                Replace(doc, "{$Cpct}", strRes[1]);
                Replace(doc, "{$Tpct}", strRes[2]);

                value = ReadDS(BlooDt, "LYMPH_N");
                strRes = ReadRange("淋巴细胞数目", "", value);
                Replace(doc, "{$ws}", value);
                Replace(doc, "{$Rws}", strRes[0]);
                Replace(doc, "{$Cws}", strRes[1]);
                Replace(doc, "{$Tws}", strRes[2]);

                value = ReadDS(BlooDt, "LYMPH_B");
                strRes = ReadRange("淋巴细胞百分比", "", value);
                Replace(doc, "{$ms}", value);
                Replace(doc, "{$Rms}", strRes[0]);
                Replace(doc, "{$Cms}", strRes[1]);
                Replace(doc, "{$Tms}", strRes[2]);
                #endregion

                if (area.Equals("济宁"))
                {
                    #region 一般状况
                    Replace(doc, "{$tw}", model3.AnimalHeat);
                    #region 症状
                    string symptomString = "";
                    if (!string.IsNullOrEmpty(model2.Symptom))
                    {
                        string[] symptomArray = model2.Symptom.Split(',');
                        foreach (string a in symptomArray)
                        {
                            switch (a)
                            {
                                case "1":
                                    symptomString += "无症状";
                                    break;
                                case "2":
                                    symptomString += "头痛,";
                                    break;
                                case "3":
                                    symptomString += "头晕,";
                                    break;
                                case "4":
                                    symptomString += "心悸,";
                                    break;
                                case "5":
                                    symptomString += "胸闷,";
                                    break;
                                case "6":
                                    symptomString += "胸痛,";
                                    break;
                                case "7":
                                    symptomString += "慢性咳嗽,";
                                    break;
                                case "8":
                                    symptomString += "咳痰,";
                                    break;
                                case "9":
                                    symptomString += "呼吸困难,";
                                    break;
                                case "10":
                                    symptomString += "多饮,";
                                    break;
                                case "11":
                                    symptomString += "多尿,";
                                    break;
                                case "12":
                                    symptomString += "体重下降,";
                                    break;
                                case "13":
                                    symptomString += "乏力,";
                                    break;
                                case "14":
                                    symptomString += "关节肿痛,";
                                    break;
                                case "15":
                                    symptomString += "视力模糊,";
                                    break;
                                case "16":
                                    symptomString += "手脚麻木,";
                                    break;
                                case "17":
                                    symptomString += "消瘦,";
                                    break;
                                case "18":
                                    symptomString += "尿痛,";
                                    break;
                                case "19":
                                    symptomString += "便秘,";
                                    break;
                                case "20":
                                    symptomString += "腹泻,";
                                    break;
                                case "21":
                                    symptomString += "恶心呕吐,";
                                    break;
                                case "22":
                                    symptomString += "眼花,";
                                    break;
                                case "23":
                                    symptomString += "耳鸣,";
                                    break;
                                case "24":
                                    symptomString += "乳房胀痛,";
                                    break;
                                case "25":
                                    symptomString += "其他：" + model2.Other;
                                    break;
                            }
                        }
                    }
                    if (symptomString.EndsWith(","))
                    {
                        symptomString = symptomString.Substring(0, symptomString.LastIndexOf(","));
                    }
                    #endregion
                    Replace(doc, "{$zhengzhuang}", symptomString);
                    Replace(doc, "{$ml}", model3.PulseRate);
                    Replace(doc, "{$rgy}", model3.RightHeight);
                    Replace(doc, "{$rdy}", model3.RightPre);
                    Replace(doc, "{$gy}", model3.LeftHeight);
                    Replace(doc, "{$dy}", model3.LeftPre);
                    Replace(doc, "{$hxpl}", model3.BreathRate);
                    Replace(doc, "{$sg}", model3.Height);
                    Replace(doc, "{$tz}", model3.Weight);
                    Replace(doc, "{$yw}", model3.Waistline);
                    Replace(doc, "{$bmi}", model3.BMI);
                    string zlnlpg = "";
                    #region 老年人自理能力
                    if (!string.IsNullOrEmpty(model3.OldSelfCareability))
                    {
                        switch (model3.OldSelfCareability)
                        {
                            case "1":
                                zlnlpg = "可自理(0-3分)";
                                break;
                            case "2":
                                zlnlpg = "轻度依赖(4-8分)";
                                break;
                            case "3":
                                zlnlpg = "中度依赖(9-18分)";
                                break;
                            case "4":
                                zlnlpg = "不能自理(>=19分)";
                                break;
                        }
                    }
                    Replace(doc, "{$zlnlpg}", zlnlpg);
                    #endregion
                    #endregion
                    #region 生活方式
                    RecordsLifeStyleModel lifeModel = new RecordsLifeStyleBLL().GetModelByOutKey(model2.ID);
                    if (lifeModel == null) lifeModel = new RecordsLifeStyleModel();
                    string exerciseRateString = "";
                    if (!string.IsNullOrEmpty(lifeModel.ExerciseRate))
                    {
                        switch (lifeModel.ExerciseRate)
                        {
                            case "1":
                                exerciseRateString = "每天";
                                break;
                            case "2":
                                exerciseRateString = "每周一次以上";
                                break;
                            case "3":
                                exerciseRateString = "偶尔";
                                break;
                            case "4":
                                exerciseRateString = "不锻炼";
                                break;
                        }
                    }
                    Replace(doc, "{$tydlpl}", exerciseRateString);
                    Replace(doc, "{$tydlsj}", lifeModel.ExerciseTimes);
                    Replace(doc, "{$tyjcsj}", lifeModel.ExcisepersistTime);
                    string exerciseExistense = "";
                    if (!string.IsNullOrEmpty(lifeModel.ExerciseExistense))
                    {
                        string[] array = lifeModel.ExerciseExistense.Split(',');
                        foreach (string a in array)
                        {
                            switch (a)
                            {
                                case "1":
                                    exerciseExistense += "散步,";
                                    break;
                                case "2":
                                    exerciseExistense += "跑步,";
                                    break;
                                case "3":
                                    exerciseExistense += "广场舞,";
                                    break;
                                case "4":
                                    exerciseExistense += "其他：" + lifeModel.ExerciseExistenseOther;
                                    break;
                            }
                        }
                        if (exerciseExistense.EndsWith(","))
                        {
                            exerciseExistense = exerciseExistense.Substring(0, exerciseExistense.LastIndexOf(","));
                        }
                    }
                    Replace(doc, "{$tydlfs}", exerciseExistense);

                    string dietaryHabitString = "";
                    if (!string.IsNullOrEmpty(lifeModel.DietaryHabit))
                    {
                        string[] array = lifeModel.DietaryHabit.Split(',');
                        foreach (string a in array)
                        {
                            switch (a)
                            {
                                case "1":
                                    dietaryHabitString += "荤素均衡,";
                                    break;
                                case "2":
                                    dietaryHabitString += "荤食为主,";
                                    break;
                                case "3":
                                    dietaryHabitString += "素食为主,";
                                    break;
                                case "4":
                                    dietaryHabitString += "嗜盐,";
                                    break;
                                case "5":
                                    dietaryHabitString += "嗜油,";
                                    break;
                                case "6":
                                    dietaryHabitString += "嗜糖,";
                                    break;
                            }
                        }
                        if (dietaryHabitString.EndsWith(","))
                        {
                            dietaryHabitString = dietaryHabitString.Substring(0, dietaryHabitString.LastIndexOf(","));
                        }
                    }
                    Replace(doc, "{$ysxg}", dietaryHabitString);

                    string smokeConditionString = "";
                    if (!string.IsNullOrEmpty(lifeModel.SmokeCondition))
                    {
                        switch (lifeModel.SmokeCondition)
                        {
                            case "1":
                                smokeConditionString = "从不吸烟";
                                break;
                            case "2":
                                smokeConditionString = "已戒烟";
                                break;
                            case "3":
                                smokeConditionString = "吸烟";
                                break;
                        }
                    }
                    Replace(doc, "{$xyzk}", smokeConditionString);
                    Replace(doc, "{$rxyl}", lifeModel.SmokeDayNum);
                    Replace(doc, "{$ksxynl}", lifeModel.SmokeAgeStart);
                    Replace(doc, "{$jynl}", lifeModel.SmokeAgeForbiddon);

                    string drinkRateString = "";
                    if (!string.IsNullOrEmpty(lifeModel.DrinkRate))
                    {
                        switch (lifeModel.DrinkRate)
                        {
                            case "1":
                                drinkRateString = "从不";
                                break;
                            case "2":
                                drinkRateString = "偶尔";
                                break;
                            case "3":
                                drinkRateString = "经常";
                                break;
                            case "4":
                                drinkRateString = "每天";
                                break;
                        }
                    }
                    Replace(doc, "{$yjpl}", drinkRateString);
                    Replace(doc, "{$ryjl}", lifeModel.DayDrinkVolume);

                    string isDrinkString = "";
                    if (!string.IsNullOrEmpty(lifeModel.IsDrinkForbiddon))
                    {
                        if (lifeModel.IsDrinkForbiddon == "1")
                        {
                            isDrinkString += "未戒酒";
                        }
                        else if (lifeModel.IsDrinkForbiddon == "2")
                        {
                            isDrinkString += "已戒酒,戒酒年龄:" + lifeModel.ForbiddonAge + "岁";
                        }
                    }

                    Replace(doc, "{$sfjj}", isDrinkString);
                    Replace(doc, "{$ksyjnl}", lifeModel.DrinkStartAge);

                    string sfzj = "";
                    if (lifeModel.DrinkThisYear == "1")
                    {
                        sfzj = "是";
                    }
                    else if (lifeModel.DrinkThisYear == "2")
                    {
                        sfzj = "否";
                    }
                    Replace(doc, "{$sfzj}", sfzj);

                    string drinkTypeString = "";
                    if (!string.IsNullOrEmpty(lifeModel.DrinkType))
                    {
                        string[] array = lifeModel.DrinkType.Split(',');
                        foreach (string a in array)
                        {
                            switch (a)
                            {
                                case "1":
                                    drinkTypeString += "白酒,";
                                    break;
                                case "2":
                                    drinkTypeString += "啤酒,";
                                    break;
                                case "3":
                                    drinkTypeString += "红酒,";
                                    break;
                                case "4":
                                    drinkTypeString += "黄酒,";
                                    break;
                                case "5":
                                    drinkTypeString += "其他:" + lifeModel.DrinkTypeOther;
                                    break;
                            }
                        }
                        if (drinkTypeString.EndsWith(","))
                        {
                            drinkTypeString = drinkTypeString.Substring(0, drinkTypeString.LastIndexOf(","));
                        }
                    }
                    Replace(doc, "{$yjzl}", drinkTypeString);

                    string CareerHarmFactorHistoryString = "";
                    if (!string.IsNullOrEmpty(lifeModel.CareerHarmFactorHistory))
                    {
                        if (lifeModel.CareerHarmFactorHistory == "1")
                        {
                            CareerHarmFactorHistoryString = "无";
                        }
                        else if (lifeModel.CareerHarmFactorHistory == "2")
                        {
                            CareerHarmFactorHistoryString = "有";
                        }
                    }
                    Replace(doc, "{$ywzyb}", CareerHarmFactorHistoryString);
                    Replace(doc, "{$zybgz}", lifeModel.WorkType);
                    Replace(doc, "{$zybsj}", lifeModel.WorkTime);
                    Replace(doc, "{$zybfc}", lifeModel.Dust);
                    Replace(doc, "{$zybfswz}", lifeModel.Radiogen);
                    Replace(doc, "{$zybwlys}", lifeModel.Physical);
                    Replace(doc, "{$zybhxwz}", lifeModel.Chem);
                    Replace(doc, "{$zybqt}", lifeModel.Other);


                    Replace(doc, "{$zybfcfhcs}", GetZYB(lifeModel.DustProtect, lifeModel.DustProtectEx));
                    Replace(doc, "{$zybfswzfhcs}", GetZYB(lifeModel.RadiogenProtect, lifeModel.RadiogenProtectEx));
                    Replace(doc, "{$zybwlyscs}", GetZYB(lifeModel.PhysicalProtect, lifeModel.PhysicalProtectEx));
                    Replace(doc, "{$zybhxwzcs}", GetZYB(lifeModel.ChemProtect, lifeModel.ChemProtectEx));
                    Replace(doc, "{$zybqtcs}", GetZYB(lifeModel.OtherProtect, lifeModel.OtherProtectEx));
                    #endregion
                    #region 脏器功能
                    RecordsVisceraFunctionModel functionModel = new RecordsVisceraFunctionBLL().GetModelByOutKey(model2.ID);
                    if (functionModel == null) functionModel = new RecordsVisceraFunctionModel();
                    string LipsString = "";
                    if (!string.IsNullOrEmpty(functionModel.Lips))
                    {
                        switch (functionModel.Lips)
                        {
                            case "1":
                                LipsString = "红润";
                                break;
                            case "2":
                                LipsString = "苍白";
                                break;
                            case "3":
                                LipsString = "发绀";
                                break;
                            case "4":
                                LipsString = "皲裂";
                                break;
                            case "5":
                                LipsString = "疱疹";
                                break;
                        }
                    }
                    Replace(doc, "{$kqkc}", LipsString);

                    string PharyngealString = "";
                    if (!string.IsNullOrEmpty(functionModel.Pharyngeal))
                    {
                        switch (functionModel.Pharyngeal)
                        {
                            case "1":
                                PharyngealString = "无充血";
                                break;
                            case "2":
                                PharyngealString = "充血";
                                break;
                            case "3":
                                PharyngealString = "淋巴滤泡增生";
                                break;
                        }
                    }
                    Replace(doc, "{$kqyb}", PharyngealString);

                    string clzc = "", clQueChi = "", clQuChi = "", clYiChi = "";

                    if (!string.IsNullOrEmpty(functionModel.ToothResides))
                    {
                        if (functionModel.ToothResides.IndexOf("1") > -1)
                        {
                            clzc = "√";
                        }
                        if (functionModel.ToothResides.IndexOf("2") > -1)
                        {
                            clQueChi = "√";
                        }
                        if (functionModel.ToothResides.IndexOf("3") > -1)
                        {
                            clQuChi = "√";
                        }
                        if (functionModel.ToothResides.IndexOf("4") > -1)
                        {
                            clYiChi = "√";
                        }
                    }
                    Replace(doc, "{@kqzc}", clzc);
                    Replace(doc, "{@kqqc}", clQueChi);
                    Replace(doc, "{@kcquc}", clQuChi);
                    Replace(doc, "{@kqyc}", clYiChi);

                    string quezs = "", queys = "", quezx = "", queyx = "";
                    if (!string.IsNullOrEmpty(functionModel.HypodontiaEx))
                    {
                        string[] a = functionModel.HypodontiaEx.Split('#');
                        quezs = a[0];
                        queys = a[1];
                        quezx = a[2];
                        queyx = a[3];
                    }
                    Replace(doc, "{$quezs}", quezs);
                    Replace(doc, "{$queys}", queys);
                    Replace(doc, "{$quezx}", quezx);
                    Replace(doc, "{$queyx}", queyx);

                    string quzs = "", quys = "", quzx = "", quyx = "";
                    if (!string.IsNullOrEmpty(functionModel.SaprodontiaEx))
                    {
                        string[] a = functionModel.SaprodontiaEx.Split('#');
                        quzs = a[0];
                        quys = a[1];
                        quzx = a[2];
                        quyx = a[3];
                    }
                    Replace(doc, "{$quzs}", quzs);
                    Replace(doc, "{$quys}", quys);
                    Replace(doc, "{$quzx}", quzx);
                    Replace(doc, "{$quyx}", quyx);

                    string yizs = "", yiys = "", yizx = "", yiyx = "";
                    if (!string.IsNullOrEmpty(functionModel.DentureEx))
                    {
                        string[] a = functionModel.DentureEx.Split('#');
                        yizs = a[0];
                        yiys = a[1];
                        yizx = a[2];
                        yiyx = a[3];
                    }
                    Replace(doc, "{$yizs}", yizs);
                    Replace(doc, "{$yiys}", yiys);
                    Replace(doc, "{$yizx}", yizx);
                    Replace(doc, "{$yiyx}", yiyx);

                    Replace(doc, "{$slyy}", functionModel.RightView);
                    Replace(doc, "{$slzy}", functionModel.LeftView);
                    Replace(doc, "{$jzzy}", functionModel.LeftEyecorrect);
                    Replace(doc, "{$jzyy}", functionModel.RightEyecorrect);

                    string ListenString = "";
                    if (!string.IsNullOrEmpty(functionModel.Listen))
                    {
                        if (functionModel.Listen == "1")
                        {
                            ListenString = "听见";
                        }
                        else if (functionModel.Listen == "2")
                        {
                            ListenString = "听不清或无法听见";
                        }
                    }
                    Replace(doc, "{$tgtl}", ListenString);

                    string SportFunctionString = "";
                    if (!string.IsNullOrEmpty(functionModel.SportFunction))
                    {
                        if (functionModel.SportFunction == "1")
                        {
                            SportFunctionString = "可顺利完成";
                        }
                        else if (functionModel.SportFunction == "2")
                        {
                            SportFunctionString = "无法独立完成其中任何一个动作";
                        }
                    }
                    Replace(doc, "{$ydgn}", SportFunctionString);
                    Replace(doc, "{$yiyx}", yiyx);
                    #endregion
                    #region 查体信息
                    RecordsPhysicalExamModel examModel = new RecordsPhysicalExamBLL().GetModelByOutKey(model2.ID);
                    if (examModel == null) examModel = new RecordsPhysicalExamModel();

                    string SkinString = "";
                    if (!string.IsNullOrEmpty(examModel.Skin))
                    {
                        switch (examModel.Skin)
                        {
                            case "1":
                                SkinString = "正常";
                                break;
                            case "2":
                                SkinString = "潮红";
                                break;
                            case "3":
                                SkinString = "苍白";
                                break;
                            case "4":
                                SkinString = "发绀";
                                break;
                            case "5":
                                SkinString = "黄染";
                                break;
                            case "6":
                                SkinString = "色素沉着";
                                break;
                            case "7":
                                SkinString = "其他:" + examModel.SkinEx;
                                break;
                        }
                    }
                    Replace(doc, "{$skin}", SkinString);

                    string SclereString = "";
                    if (!string.IsNullOrEmpty(examModel.Sclere))
                    {
                        switch (examModel.Sclere)
                        {
                            case "1":
                                SclereString = "正常";
                                break;
                            case "2":
                                SclereString = "黄染";
                                break;
                            case "3":
                                SclereString = "充血";
                                break;
                            case "4":
                                SclereString = "其他:" + examModel.SclereEx;
                                break;
                        }
                    }
                    Replace(doc, "{$sclere}", SclereString);

                    string LymphString = "";
                    if (!string.IsNullOrEmpty(examModel.Lymph))
                    {
                        switch (examModel.Lymph)
                        {
                            case "1":
                                LymphString = "未触及";
                                break;
                            case "2":
                                LymphString = "锁骨上";
                                break;
                            case "3":
                                LymphString = "充血";
                                break;
                            case "4":
                                LymphString = "其他:" + examModel.LymphEx;
                                break;
                        }
                    }
                    Replace(doc, "{$lymph}", LymphString);

                    string BarrelChestString = "";
                    if (!string.IsNullOrEmpty(examModel.BarrelChest))
                    {
                        if (examModel.BarrelChest == "1")
                        {
                            BarrelChestString = "否";
                        }
                        else if (examModel.BarrelChest == "2")
                        {
                            BarrelChestString = "是";
                        }

                    }
                    Replace(doc, "{$barrelchest}", BarrelChestString);

                    string BreathSoundsString = "";
                    if (!string.IsNullOrEmpty(examModel.BreathSounds))
                    {
                        if (examModel.BreathSounds == "1")
                        {
                            BreathSoundsString = "正常";
                        }
                        else if (examModel.BreathSounds == "2")
                        {
                            BreathSoundsString = "异常:" + examModel.BreathSoundsEx;
                        }
                    }
                    Replace(doc, "{$breathsounds}", BreathSoundsString);

                    string RaleString = "";
                    if (!string.IsNullOrEmpty(examModel.Rale))
                    {
                        switch (examModel.Rale)
                        {
                            case "1":
                                RaleString = "无";
                                break;
                            case "2":
                                RaleString = "干罗音";
                                break;
                            case "3":
                                RaleString = "湿罗音";
                                break;
                            case "4":
                                RaleString = "其他:" + examModel.RaleEx;
                                break;
                        }
                    }
                    Replace(doc, "{$rale}", RaleString);
                    Replace(doc, "{$heartrate}", examModel.HeartRate);

                    string HeartRhythmString = "";
                    if (!string.IsNullOrEmpty(examModel.HeartRhythm))
                    {
                        switch (examModel.HeartRhythm)
                        {
                            case "1":
                                HeartRhythmString = "齐";
                                break;
                            case "2":
                                HeartRhythmString = "不齐";
                                break;
                            case "3":
                                HeartRhythmString = "绝对不齐";
                                break;
                        }
                    }
                    Replace(doc, "{$xinlv}", HeartRhythmString);

                    Replace(doc, "{$noise}", GetZYB(examModel.Noise, examModel.NoiseEx));
                    Replace(doc, "{$presspain}", GetZYB(examModel.PressPain, examModel.PressPainEx));
                    Replace(doc, "{$enclosedmass}", GetZYB(examModel.EnclosedMass, examModel.EnclosedMassEx));
                    Replace(doc, "{$liver}", GetZYB(examModel.Liver, examModel.LiverEx));
                    Replace(doc, "{$spleen}", GetZYB(examModel.Spleen, examModel.SpleenEx));
                    Replace(doc, "{$voiced}", GetZYB(examModel.Voiced, examModel.VoicedEx));

                    string edemaString = "";
                    if (!string.IsNullOrEmpty(examModel.Edema))
                    {
                        switch (examModel.Edema)
                        {
                            case "1":
                                edemaString = "无";
                                break;
                            case "2":
                                edemaString = "单侧";
                                break;
                            case "3":
                                edemaString = "双侧不对称";
                                break;
                            case "4":
                                edemaString = "双侧对称";
                                break;
                        }
                    }
                    Replace(doc, "{$edema}", edemaString);

                    string FootBackString = "";
                    if (!string.IsNullOrEmpty(examModel.FootBack))
                    {
                        switch (examModel.FootBack)
                        {
                            case "1":
                                FootBackString = "未触及";
                                break;
                            case "2":
                                FootBackString = "触及双侧对称";
                                break;
                            case "3":
                                FootBackString = "触及左侧弱或消失";
                                break;
                            case "4":
                                FootBackString = "触及右侧弱或消失";
                                break;
                        }
                    }
                    Replace(doc, "{$footback}", FootBackString);
                    Replace(doc, "{$ctqt}", examModel.Other);
                    #endregion
                    #region 主要健康问题
                    RecordsHealthQuestionModel quertionModel = new RecordsHealthQuestionBLL().GetModelByOutKey(model2.ID);
                    if (quertionModel == null) quertionModel = new RecordsHealthQuestionModel();
                    string braindisString = "";
                    if (!string.IsNullOrEmpty(quertionModel.BrainDis))
                    {
                        string[] array = quertionModel.BrainDis.Split(',');
                        foreach (string a in array)
                        {
                            switch (a)
                            {
                                case "1":
                                    braindisString += "未发现";
                                    break;
                                case "2":
                                    braindisString += "缺血性卒中,";
                                    break;
                                case "3":
                                    braindisString += "脑出血,";
                                    break;
                                case "4":
                                    braindisString += "蛛网膜下腔出血,";
                                    break;
                                case "5":
                                    braindisString += "短暂性脑缺血发作,";
                                    break;
                                case "6":
                                    braindisString += "其他：" + quertionModel.BrainOther;
                                    break;
                            }
                        }
                        if (braindisString.EndsWith(","))
                        {
                            braindisString = braindisString.Substring(0, braindisString.LastIndexOf(","));
                        }
                    }
                    Replace(doc, "{$braindis}", braindisString);

                    string renaldisString = "";
                    if (!string.IsNullOrEmpty(quertionModel.RenalDis))
                    {
                        string[] array = quertionModel.RenalDis.Split(',');
                        foreach (string a in array)
                        {
                            switch (a)
                            {
                                case "1":
                                    renaldisString += "未发现";
                                    break;
                                case "2":
                                    renaldisString += "糖尿病肾病,";
                                    break;
                                case "3":
                                    renaldisString += "肾功能衰竭,";
                                    break;
                                case "4":
                                    renaldisString += "急性肾炎,";
                                    break;
                                case "5":
                                    renaldisString += "慢性肾炎,";
                                    break;
                                case "6":
                                    renaldisString += "其他：" + quertionModel.RenalOther;
                                    break;
                            }
                        }
                        if (renaldisString.EndsWith(","))
                        {
                            renaldisString = renaldisString.Substring(0, renaldisString.LastIndexOf(","));
                        }
                    }
                    Replace(doc, "{$renaldis}", renaldisString);

                    string heartdisString = "";
                    if (!string.IsNullOrEmpty(quertionModel.HeartDis))
                    {
                        string[] array = quertionModel.HeartDis.Split(',');
                        foreach (string a in array)
                        {
                            switch (a)
                            {
                                case "1":
                                    heartdisString += "未发现";
                                    break;
                                case "2":
                                    heartdisString += "心肌梗死,";
                                    break;
                                case "3":
                                    heartdisString += "心绞痛,";
                                    break;
                                case "4":
                                    heartdisString += "冠状动脉血运重建,";
                                    break;
                                case "5":
                                    heartdisString += "充血性心力衰竭,";
                                    break;
                                case "6":
                                    heartdisString += "心前区疼痛,";
                                    break;
                                case "7":
                                    heartdisString += "高血压,";
                                    break;
                                case "8":
                                    heartdisString += "夹层动脉瘤,";
                                    break;
                                case "9":
                                    heartdisString += "动脉闭塞性疾病,";
                                    break;
                                case "10":
                                    heartdisString += "其他：" + quertionModel.HeartOther;
                                    break;
                            }
                        }
                        if (heartdisString.EndsWith(","))
                        {
                            heartdisString = heartdisString.Substring(0, heartdisString.LastIndexOf(","));
                        }
                    }
                    Replace(doc, "{$heartdis}", heartdisString);

                    string eyedisString = "";
                    if (!string.IsNullOrEmpty(quertionModel.EyeDis))
                    {
                        string[] array = quertionModel.EyeDis.Split(',');
                        foreach (string a in array)
                        {
                            switch (a)
                            {
                                case "1":
                                    eyedisString += "未发现";
                                    break;
                                case "2":
                                    eyedisString += "视网膜出血或渗出,";
                                    break;
                                case "3":
                                    eyedisString += "视乳头水肿,";
                                    break;
                                case "4":
                                    eyedisString += "白内障,";
                                    break;
                                case "5":
                                    eyedisString += "其他：" + quertionModel.EyeOther;
                                    break;
                            }
                        }
                        if (eyedisString.EndsWith(","))
                        {
                            eyedisString = eyedisString.Substring(0, eyedisString.LastIndexOf(","));
                        }
                    }
                    Replace(doc, "{$eyedis}", eyedisString);

                    string NerveDisString = "";
                    if (!string.IsNullOrEmpty(quertionModel.NerveDis))
                    {
                        string[] array = quertionModel.NerveDis.Split(',');
                        foreach (string a in array)
                        {
                            switch (a)
                            {
                                case "1":
                                    NerveDisString += "未发现";
                                    break;
                                case "2":
                                    NerveDisString += "阿尔茨海默症（老年性痴呆）,";
                                    break;
                                case "3":
                                    NerveDisString += "帕金森病,";
                                    break;
                                case "4":
                                    NerveDisString += "其他：" + quertionModel.NerveOther;
                                    break;
                            }
                        }
                        if (NerveDisString.EndsWith(","))
                        {
                            NerveDisString = NerveDisString.Substring(0, NerveDisString.LastIndexOf(","));
                        }
                    }
                    Replace(doc, "{$nervedis}", NerveDisString);


                    string ElseDisString = "";
                    if (!string.IsNullOrEmpty(quertionModel.ElseDis))
                    {
                        string[] array = quertionModel.ElseDis.Split(',');
                        foreach (string a in array)
                        {
                            switch (a)
                            {
                                case "1":
                                    ElseDisString += "未发现";
                                    break;
                                case "2":
                                    ElseDisString += "糖尿病,";
                                    break;
                                case "3":
                                    ElseDisString += "慢性支气管炎,";
                                    break;
                                case "4":
                                    ElseDisString += "慢性阻塞性肺气肿,";
                                    break;
                                case "5":
                                    ElseDisString += "恶性肿瘤,";
                                    break;
                                case "6":
                                    ElseDisString += "老年性关节病,";
                                    break;
                                case "7":
                                    ElseDisString += "其他：" + quertionModel.ElseOther;
                                    break;
                            }
                        }
                        if (ElseDisString.EndsWith(","))
                        {
                            ElseDisString = ElseDisString.Substring(0, ElseDisString.LastIndexOf(","));
                        }
                    }
                    Replace(doc, "{$elsedis}", ElseDisString);
                    #endregion
                    #region 住院史
                    List<RecordsHospitalHistoryModel> historyModel = new RecordsHospitalHistoryBLL().GetModelList(" OutKey='" + model2.ID + "'");
                    if (historyModel == null) historyModel = new List<RecordsHospitalHistoryModel>();

                    if (historyModel.Count == 0)
                    {
                        Replace(doc, "{$zysr1}", "");
                        Replace(doc, "{$zysc1}", "");
                        Replace(doc, "{$zyyy1}", "");
                        Replace(doc, "{$zyjg1}", "");
                        Replace(doc, "{$zyba1}", "");
                        Replace(doc, "{$zysr2}", "");
                        Replace(doc, "{$zysc2}", "");
                        Replace(doc, "{$zyyy2}", "");
                        Replace(doc, "{$zyjg2}", "");
                        Replace(doc, "{$zyba2}", "");
                    }
                    if (historyModel.Count == 1)
                    {
                        Replace(doc, "{$zysr1}", ((DateTime)historyModel[0].InHospitalDate).ToString("yyyy-MM-dd"));
                        Replace(doc, "{$zysc1}", ((DateTime)historyModel[0].OutHospitalDate).ToString("yyyy-MM-dd"));
                        Replace(doc, "{$zyyy1}", historyModel[0].Reason);
                        Replace(doc, "{$zyjg1}", historyModel[0].HospitalName);
                        Replace(doc, "{$zyba1}", historyModel[0].IllcaseNum);
                        Replace(doc, "{$zysr2}", "");
                        Replace(doc, "{$zysc2}", "");
                        Replace(doc, "{$zyyy2}", "");
                        Replace(doc, "{$zyjg2}", "");
                        Replace(doc, "{$zyba2}", "");
                    }
                    if (historyModel.Count == 2)
                    {
                        Replace(doc, "{$zysr1}", ((DateTime)historyModel[0].InHospitalDate).ToString("yyyy-MM-dd"));
                        Replace(doc, "{$zysc1}", ((DateTime)historyModel[0].OutHospitalDate).ToString("yyyy-MM-dd"));
                        Replace(doc, "{$zyyy1}", historyModel[0].Reason);
                        Replace(doc, "{$zyjg1}", historyModel[0].HospitalName);
                        Replace(doc, "{$zyba1}", historyModel[0].IllcaseNum);
                        Replace(doc, "{$zysr2}", ((DateTime)historyModel[1].InHospitalDate).ToString("yyyy-MM-dd"));
                        Replace(doc, "{$zysc2}", ((DateTime)historyModel[1].OutHospitalDate).ToString("yyyy-MM-dd"));
                        Replace(doc, "{$zyyy2}", historyModel[1].Reason);
                        Replace(doc, "{$zyjg2}", historyModel[1].HospitalName);
                        Replace(doc, "{$zyba2}", historyModel[1].IllcaseNum);
                    }
                    #endregion
                    #region 家庭病床史
                    List<RecordsFamilyBedHistoryModel> familyModel = new RecordsFamilyBedHistoryBLL().GetModelList(" OutKey='" + model2.ID + "' ");
                    if (familyModel == null) familyModel = new List<RecordsFamilyBedHistoryModel>();

                    if (familyModel.Count == 0)
                    {
                        Replace(doc, "{$jzbj1}", "");
                        Replace(doc, "{$jzbc1}", "");
                        Replace(doc, "{$jzyy1}", "");
                        Replace(doc, "{$jzjg1}", "");
                        Replace(doc, "{$jzba1}", "");
                        Replace(doc, "{$jzbj2}", "");
                        Replace(doc, "{$jzbc2}", "");
                        Replace(doc, "{$jzyy2}", "");
                        Replace(doc, "{$jzjg2}", "");
                        Replace(doc, "{$jzba2}", "");
                    }
                    if (familyModel.Count == 1)
                    {
                        Replace(doc, "{$jzbj1}", ((DateTime)familyModel[0].InHospitalDate).ToString("yyyy-MM-dd"));
                        Replace(doc, "{$jzbc1}", ((DateTime)familyModel[0].OutHospitalDate).ToString("yyyy-MM-dd"));
                        Replace(doc, "{$jzyy1}", familyModel[0].Reasons);
                        Replace(doc, "{$jzjg1}", familyModel[0].HospitalName);
                        Replace(doc, "{$jzba1}", familyModel[0].IllcaseNums);
                        Replace(doc, "{$jzbj2}", "");
                        Replace(doc, "{$jzbc2}", "");
                        Replace(doc, "{$jzyy2}", "");
                        Replace(doc, "{$jzjg2}", "");
                        Replace(doc, "{$jzba2}", "");
                    }
                    if (familyModel.Count == 2)
                    {
                        Replace(doc, "{$jzbj1}", ((DateTime)familyModel[0].InHospitalDate).ToString("yyyy-MM-dd"));
                        Replace(doc, "{$jzbc1}", ((DateTime)familyModel[0].OutHospitalDate).ToString("yyyy-MM-dd"));
                        Replace(doc, "{$jzyy1}", familyModel[0].Reasons);
                        Replace(doc, "{$jzjg1}", familyModel[0].HospitalName);
                        Replace(doc, "{$jzba1}", familyModel[0].IllcaseNums);
                        Replace(doc, "{$jzbj2}", ((DateTime)familyModel[1].InHospitalDate).ToString("yyyy-MM-dd"));
                        Replace(doc, "{$jzbc2}", ((DateTime)familyModel[1].OutHospitalDate).ToString("yyyy-MM-dd"));
                        Replace(doc, "{$jzyy2}", familyModel[1].Reasons);
                        Replace(doc, "{$jzjg2}", familyModel[1].HospitalName);
                        Replace(doc, "{$jzba2}", familyModel[1].IllcaseNums);
                    }


                    #endregion
                    #region 用药情况
                    List<RecordsMedicationModel> medicationModel = new RecordsMedicationBLL().GetModelList(" OutKey='" + model2.ID + "'");
                    if (medicationModel == null) medicationModel = new List<RecordsMedicationModel>();

                    if (medicationModel.Count == 0)
                    {
                        Replace(doc, "{$yymc1}", "");
                        Replace(doc, "{$yyf1}", "");
                        Replace(doc, "{$yyy1}", "");
                        Replace(doc, "{$ysj1}", "");
                        Replace(doc, "{$fyyc1}", "");

                        Replace(doc, "{$yymc2}", "");
                        Replace(doc, "{$yyf2}", "");
                        Replace(doc, "{$yyy2}", "");
                        Replace(doc, "{$ysj2}", "");
                        Replace(doc, "{$fyyc2}", "");

                        Replace(doc, "{$yymc3}", "");
                        Replace(doc, "{$yyf3}", "");
                        Replace(doc, "{$yyy3}", "");
                        Replace(doc, "{$ysj3}", "");
                        Replace(doc, "{$fyyc3}", "");

                        Replace(doc, "{$yymc4}", "");
                        Replace(doc, "{$yyf4}", "");
                        Replace(doc, "{$yyy4}", "");
                        Replace(doc, "{$ysj4}", "");
                        Replace(doc, "{$fyyc4}", "");

                        Replace(doc, "{$yymc5}", "");
                        Replace(doc, "{$yyf5}", "");
                        Replace(doc, "{$yyy5}", "");
                        Replace(doc, "{$ysj5}", "");
                        Replace(doc, "{$fyyc5}", "");

                        Replace(doc, "{$yymc6}", "");
                        Replace(doc, "{$yyf6}", "");
                        Replace(doc, "{$yyy6}", "");
                        Replace(doc, "{$ysj6}", "");
                        Replace(doc, "{$fyyc6}", "");
                    }
                    else
                    if (medicationModel.Count == 1)
                    {
                        Replace(doc, "{$yymc1}", medicationModel[0].MedicinalName);
                        Replace(doc, "{$yyf1}", medicationModel[0].UseAge);
                        Replace(doc, "{$yyy1}", medicationModel[0].UseNum);
                        //Replace(doc, "{$ysj1}", medicationModel[0].DrugType);
                        Replace(doc, "{$ysj1}", medicationModel[0].StartTime);
                        Replace(doc, "{$fyyc1}", GetPillDependence(medicationModel[0].PillDependence));

                        Replace(doc, "{$yymc2}", "");
                        Replace(doc, "{$yyf2}", "");
                        Replace(doc, "{$yyy2}", "");
                        Replace(doc, "{$ysj2}", "");
                        Replace(doc, "{$fyyc2}", "");

                        Replace(doc, "{$yymc3}", "");
                        Replace(doc, "{$yyf3}", "");
                        Replace(doc, "{$yyy3}", "");
                        Replace(doc, "{$ysj3}", "");
                        Replace(doc, "{$fyyc3}", "");

                        Replace(doc, "{$yymc4}", "");
                        Replace(doc, "{$yyf4}", "");
                        Replace(doc, "{$yyy4}", "");
                        Replace(doc, "{$ysj4}", "");
                        Replace(doc, "{$fyyc4}", "");

                        Replace(doc, "{$yymc5}", "");
                        Replace(doc, "{$yyf5}", "");
                        Replace(doc, "{$yyy5}", "");
                        Replace(doc, "{$ysj5}", "");
                        Replace(doc, "{$fyyc5}", "");

                        Replace(doc, "{$yymc6}", "");
                        Replace(doc, "{$yyf6}", "");
                        Replace(doc, "{$yyy6}", "");
                        Replace(doc, "{$ysj6}", "");
                        Replace(doc, "{$fyyc6}", "");
                    }
                    else
                    if (medicationModel.Count == 2)
                    {
                        Replace(doc, "{$yymc1}", medicationModel[0].MedicinalName);
                        Replace(doc, "{$yyf1}", medicationModel[0].UseAge);
                        Replace(doc, "{$yyy1}", medicationModel[0].UseNum);
                        //Replace(doc, "{$ysj1}", medicationModel[0].DrugType);
                        Replace(doc, "{$ysj1}", medicationModel[0].StartTime);
                        Replace(doc, "{$fyyc1}", GetPillDependence(medicationModel[0].PillDependence));

                        Replace(doc, "{$yymc2}", medicationModel[1].MedicinalName);
                        Replace(doc, "{$yyf2}", medicationModel[1].UseAge);
                        Replace(doc, "{$yyy2}", medicationModel[1].UseNum);
                        //Replace(doc, "{$ysj2}", medicationModel[1].DrugType);
                        Replace(doc, "{$ysj2}", medicationModel[1].StartTime);
                        Replace(doc, "{$fyyc2}", GetPillDependence(medicationModel[1].PillDependence));

                        Replace(doc, "{$yymc3}", "");
                        Replace(doc, "{$yyf3}", "");
                        Replace(doc, "{$yyy3}", "");
                        Replace(doc, "{$ysj3}", "");
                        Replace(doc, "{$fyyc3}", "");

                        Replace(doc, "{$yymc4}", "");
                        Replace(doc, "{$yyf4}", "");
                        Replace(doc, "{$yyy4}", "");
                        Replace(doc, "{$ysj4}", "");
                        Replace(doc, "{$fyyc4}", "");

                        Replace(doc, "{$yymc5}", "");
                        Replace(doc, "{$yyf5}", "");
                        Replace(doc, "{$yyy5}", "");
                        Replace(doc, "{$ysj5}", "");
                        Replace(doc, "{$fyyc5}", "");

                        Replace(doc, "{$yymc6}", "");
                        Replace(doc, "{$yyf6}", "");
                        Replace(doc, "{$yyy6}", "");
                        Replace(doc, "{$ysj6}", "");
                        Replace(doc, "{$fyyc6}", "");
                    }
                    else
                    if (medicationModel.Count == 3)
                    {
                        Replace(doc, "{$yymc1}", medicationModel[0].MedicinalName);
                        Replace(doc, "{$yyf1}", medicationModel[0].UseAge);
                        Replace(doc, "{$yyy1}", medicationModel[0].UseNum);
                        //Replace(doc, "{$ysj1}", medicationModel[0].DrugType);
                        Replace(doc, "{$ysj1}", medicationModel[0].StartTime);
                        Replace(doc, "{$fyyc1}", GetPillDependence(medicationModel[0].PillDependence));

                        Replace(doc, "{$yymc2}", medicationModel[1].MedicinalName);
                        Replace(doc, "{$yyf2}", medicationModel[1].UseAge);
                        Replace(doc, "{$yyy2}", medicationModel[1].UseNum);
                        //Replace(doc, "{$ysj2}", medicationModel[1].DrugType);
                        Replace(doc, "{$ysj2}", medicationModel[1].StartTime);
                        Replace(doc, "{$fyyc2}", GetPillDependence(medicationModel[1].PillDependence));

                        Replace(doc, "{$yymc3}", medicationModel[2].MedicinalName);
                        Replace(doc, "{$yyf3}", medicationModel[2].UseAge);
                        Replace(doc, "{$yyy3}", medicationModel[2].UseNum);
                        //Replace(doc, "{$ysj3}", medicationModel[2].DrugType);
                        Replace(doc, "{$ysj3}", medicationModel[2].StartTime);
                        Replace(doc, "{$fyyc3}", GetPillDependence(medicationModel[2].PillDependence));

                        Replace(doc, "{$yymc4}", "");
                        Replace(doc, "{$yyf4}", "");
                        Replace(doc, "{$yyy4}", "");
                        Replace(doc, "{$ysj4}", "");
                        Replace(doc, "{$fyyc4}", "");

                        Replace(doc, "{$yymc5}", "");
                        Replace(doc, "{$yyf5}", "");
                        Replace(doc, "{$yyy5}", "");
                        Replace(doc, "{$ysj5}", "");
                        Replace(doc, "{$fyyc5}", "");

                        Replace(doc, "{$yymc6}", "");
                        Replace(doc, "{$yyf6}", "");
                        Replace(doc, "{$yyy6}", "");
                        Replace(doc, "{$ysj6}", "");
                        Replace(doc, "{$fyyc6}", "");
                    }
                    else
                    if (medicationModel.Count == 4)
                    {
                        Replace(doc, "{$yymc1}", medicationModel[0].MedicinalName);
                        Replace(doc, "{$yyf1}", medicationModel[0].UseAge);
                        Replace(doc, "{$yyy1}", medicationModel[0].UseNum);
                        //Replace(doc, "{$ysj1}", medicationModel[0].DrugType);
                        Replace(doc, "{$ysj1}", medicationModel[0].StartTime);
                        Replace(doc, "{$fyyc1}", GetPillDependence(medicationModel[0].PillDependence));

                        Replace(doc, "{$yymc2}", medicationModel[1].MedicinalName);
                        Replace(doc, "{$yyf2}", medicationModel[1].UseAge);
                        Replace(doc, "{$yyy2}", medicationModel[1].UseNum);
                        //Replace(doc, "{$ysj2}", medicationModel[1].DrugType);
                        Replace(doc, "{$ysj2}", medicationModel[1].StartTime);
                        Replace(doc, "{$fyyc2}", GetPillDependence(medicationModel[1].PillDependence));

                        Replace(doc, "{$yymc3}", medicationModel[2].MedicinalName);
                        Replace(doc, "{$yyf3}", medicationModel[2].UseAge);
                        Replace(doc, "{$yyy3}", medicationModel[2].UseNum);
                        //Replace(doc, "{$ysj3}", medicationModel[2].DrugType);
                        Replace(doc, "{$ysj3}", medicationModel[2].StartTime);
                        Replace(doc, "{$fyyc3}", GetPillDependence(medicationModel[2].PillDependence));

                        Replace(doc, "{$yymc4}", medicationModel[3].MedicinalName);
                        Replace(doc, "{$yyf4}", medicationModel[3].UseAge);
                        Replace(doc, "{$yyy4}", medicationModel[3].UseNum);
                        //Replace(doc, "{$ysj4}", medicationModel[3].DrugType);
                        Replace(doc, "{$ysj4}", medicationModel[3].StartTime);
                        Replace(doc, "{$fyyc4}", GetPillDependence(medicationModel[3].PillDependence));

                        Replace(doc, "{$yymc5}", "");
                        Replace(doc, "{$yyf5}", "");
                        Replace(doc, "{$yyy5}", "");
                        Replace(doc, "{$ysj5}", "");
                        Replace(doc, "{$fyyc5}", "");

                        Replace(doc, "{$yymc6}", "");
                        Replace(doc, "{$yyf6}", "");
                        Replace(doc, "{$yyy6}", "");
                        Replace(doc, "{$ysj6}", "");
                        Replace(doc, "{$fyyc6}", "");
                    }
                    else
                    if (medicationModel.Count == 5)
                    {
                        Replace(doc, "{$yymc1}", medicationModel[0].MedicinalName);
                        Replace(doc, "{$yyf1}", medicationModel[0].UseAge);
                        Replace(doc, "{$yyy1}", medicationModel[0].UseNum);
                        //Replace(doc, "{$ysj1}", medicationModel[0].DrugType);
                        Replace(doc, "{$ysj1}", medicationModel[0].StartTime);
                        Replace(doc, "{$fyyc1}", GetPillDependence(medicationModel[0].PillDependence));

                        Replace(doc, "{$yymc2}", medicationModel[1].MedicinalName);
                        Replace(doc, "{$yyf2}", medicationModel[1].UseAge);
                        Replace(doc, "{$yyy2}", medicationModel[1].UseNum);
                        //Replace(doc, "{$ysj2}", medicationModel[1].DrugType);
                        Replace(doc, "{$ysj2}", medicationModel[1].StartTime);
                        Replace(doc, "{$fyyc2}", GetPillDependence(medicationModel[1].PillDependence));

                        Replace(doc, "{$yymc3}", medicationModel[2].MedicinalName);
                        Replace(doc, "{$yyf3}", medicationModel[2].UseAge);
                        Replace(doc, "{$yyy3}", medicationModel[2].UseNum);
                        //Replace(doc, "{$ysj3}", medicationModel[2].DrugType);
                        Replace(doc, "{$ysj3}", medicationModel[2].StartTime);
                        Replace(doc, "{$fyyc3}", GetPillDependence(medicationModel[2].PillDependence));

                        Replace(doc, "{$yymc4}", medicationModel[3].MedicinalName);
                        Replace(doc, "{$yyf4}", medicationModel[3].UseAge);
                        Replace(doc, "{$yyy4}", medicationModel[3].UseNum);
                        //Replace(doc, "{$ysj4}", medicationModel[3].DrugType);
                        Replace(doc, "{$ysj4}", medicationModel[3].StartTime);
                        Replace(doc, "{$fyyc4}", GetPillDependence(medicationModel[3].PillDependence));

                        Replace(doc, "{$yymc5}", medicationModel[4].MedicinalName);
                        Replace(doc, "{$yyf5}", medicationModel[4].UseAge);
                        Replace(doc, "{$yyy5}", medicationModel[4].UseNum);
                        //Replace(doc, "{$ysj5}", medicationModel[4].DrugType);
                        Replace(doc, "{$ysj5}", medicationModel[4].StartTime);
                        Replace(doc, "{$fyyc5}", GetPillDependence(medicationModel[4].PillDependence));

                        Replace(doc, "{$yymc6}", "");
                        Replace(doc, "{$yyf6}", "");
                        Replace(doc, "{$yyy6}", "");
                        Replace(doc, "{$ysj6}", "");
                        Replace(doc, "{$fyyc6}", "");
                    }
                    else
                    if (medicationModel.Count == 6)
                    {
                        Replace(doc, "{$yymc1}", medicationModel[0].MedicinalName);
                        Replace(doc, "{$yyf1}", medicationModel[0].UseAge);
                        Replace(doc, "{$yyy1}", medicationModel[0].UseNum);
                        //Replace(doc, "{$ysj1}", medicationModel[0].DrugType);
                        Replace(doc, "{$ysj1}", medicationModel[0].StartTime);
                        Replace(doc, "{$fyyc1}", GetPillDependence(medicationModel[0].PillDependence));

                        Replace(doc, "{$yymc2}", medicationModel[1].MedicinalName);
                        Replace(doc, "{$yyf2}", medicationModel[1].UseAge);
                        Replace(doc, "{$yyy2}", medicationModel[1].UseNum);
                        //Replace(doc, "{$ysj2}", medicationModel[1].DrugType);
                        Replace(doc, "{$ysj2}", medicationModel[1].StartTime);
                        Replace(doc, "{$fyyc2}", GetPillDependence(medicationModel[1].PillDependence));

                        Replace(doc, "{$yymc3}", medicationModel[2].MedicinalName);
                        Replace(doc, "{$yyf3}", medicationModel[2].UseAge);
                        Replace(doc, "{$yyy3}", medicationModel[2].UseNum);
                        //Replace(doc, "{$ysj3}", medicationModel[2].DrugType);
                        Replace(doc, "{$ysj3}", medicationModel[2].StartTime);
                        Replace(doc, "{$fyyc3}", GetPillDependence(medicationModel[2].PillDependence));

                        Replace(doc, "{$yymc4}", medicationModel[3].MedicinalName);
                        Replace(doc, "{$yyf4}", medicationModel[3].UseAge);
                        Replace(doc, "{$yyy4}", medicationModel[3].UseNum);
                        //Replace(doc, "{$ysj4}", medicationModel[3].DrugType);
                        Replace(doc, "{$ysj4}", medicationModel[3].StartTime);
                        Replace(doc, "{$fyyc4}", GetPillDependence(medicationModel[3].PillDependence));

                        Replace(doc, "{$yymc5}", medicationModel[4].MedicinalName);
                        Replace(doc, "{$yyf5}", medicationModel[4].UseAge);
                        Replace(doc, "{$yyy5}", medicationModel[4].UseNum);
                        //Replace(doc, "{$ysj5}", medicationModel[4].DrugType);
                        Replace(doc, "{$ysj5}", medicationModel[4].StartTime);
                        Replace(doc, "{$fyyc5}", GetPillDependence(medicationModel[4].PillDependence));

                        Replace(doc, "{$yymc6}", medicationModel[5].MedicinalName);
                        Replace(doc, "{$yyf6}", medicationModel[5].UseAge);
                        Replace(doc, "{$yyy6}", medicationModel[5].UseNum);
                        //Replace(doc, "{$ysj6}", medicationModel[5].DrugType);
                        Replace(doc, "{$ysj6}", medicationModel[5].StartTime);
                        Replace(doc, "{$fyyc6}", GetPillDependence(medicationModel[5].PillDependence));
                    }
                    #endregion
                    #region 健康评价
                    RecordsAssessmentGuideModel guideModel = new RecordsAssessmentGuideBLL().GetModelByOutKey(model2.ID);
                    if (guideModel == null) guideModel = new RecordsAssessmentGuideModel();

                    string IsNormalString = "";
                    if (!string.IsNullOrEmpty(guideModel.IsNormal))
                    {
                        if (guideModel.IsNormal == "1")
                        {
                            IsNormalString = "体检无异常";
                        }
                        else if (guideModel.IsNormal == "2")
                        {
                            IsNormalString = "体检有异常";
                        }
                    }
                    Replace(doc, "{$jkpj}", IsNormalString);
                    Replace(doc, "{$jkpjyc1}", guideModel.Exception1);
                    Replace(doc, "{$jkpjyc2}", guideModel.Exception2);
                    Replace(doc, "{$jkpjyc3}", guideModel.Exception3);
                    Replace(doc, "{$jkpjyc4}", guideModel.Exception4);

                    string jkzd1 = "", jkzd2 = "", jkzd3 = "", jkzd4 = "";
                    if (!string.IsNullOrEmpty(guideModel.HealthGuide))
                    {
                        if (guideModel.HealthGuide.IndexOf("1") > -1)
                        {
                            jkzd1 = "√";
                        }
                        if (guideModel.HealthGuide.IndexOf("2") > -1)
                        {
                            jkzd2 = "√";
                        }
                        if (guideModel.HealthGuide.IndexOf("3") > -1)
                        {
                            jkzd3 = "√";
                        }
                        if (guideModel.HealthGuide.IndexOf("4") > -1)
                        {
                            jkzd4 = "√";
                        }
                    }
                    Replace(doc, "{@jkzd1}", jkzd1);
                    Replace(doc, "{@jkzd2}", jkzd2);
                    Replace(doc, "{@jkzd3}", jkzd3);
                    Replace(doc, "{@jkzd4}", jkzd4);

                    string wxyskz1 = "", wxyskz2 = "", wxyskz3 = "", wxyskz4 = "", wxyskz5 = "", wxyskz6 = "", wxyskz7 = "";
                    if (!string.IsNullOrEmpty(guideModel.DangerControl))
                    {
                        if (guideModel.DangerControl.IndexOf("1") > -1)
                        {
                            wxyskz1 = "√";
                        }
                        if (guideModel.DangerControl.IndexOf("2") > -1)
                        {
                            wxyskz2 = "√";
                        }
                        if (guideModel.DangerControl.IndexOf("3") > -1)
                        {
                            wxyskz3 = "√";
                        }
                        if (guideModel.DangerControl.IndexOf("4") > -1)
                        {
                            wxyskz4 = "√";
                        }
                        if (guideModel.DangerControl.IndexOf("5") > -1)
                        {
                            wxyskz5 = "√";
                        }
                        if (guideModel.DangerControl.IndexOf("6") > -1)
                        {
                            wxyskz6 = "√";
                        }
                        if (guideModel.DangerControl.IndexOf("7") > -1)
                        {
                            wxyskz7 = "√";
                        }
                    }
                    Replace(doc, "{@wxys1}", wxyskz1);
                    Replace(doc, "{@wxys2}", wxyskz2);
                    Replace(doc, "{@wxys3}", wxyskz3);
                    Replace(doc, "{@wxys4}", wxyskz4);
                    Replace(doc, "{@wxys5}", wxyskz5);
                    Replace(doc, "{@wxys6}", wxyskz6);
                    Replace(doc, "{@wxys7}", wxyskz7);
                    Replace(doc, "{$jtz}", guideModel.Arm);
                    Replace(doc, "{$jyjzjm}", guideModel.VaccineAdvice);
                    Replace(doc, "{$wxyskzqt}", guideModel.Other);
                    #endregion
                    #region 签字和体检日期
                    DateTime checkdate;
                    if (DateTime.TryParse(model2.CheckDate.ToString(), out checkdate))
                    {
                        if (File.Exists(SignPath + checkdate.ToString("yyyy-MM-dd") + "/_Doctor10.png"))
                        {
                            InsertImage(SignPath + checkdate.ToString("yyyy-MM-dd") + "/_Doctor10.png", "{&ysqz}", doc, 80, 30);
                        }
                        else
                        {
                            InsertImage(SignPath + "_Doctor10.png", "{&ysqz}", doc, 80, 30);
                        }
                    }
                    Replace(doc, "{$qzsj}", ((DateTime)(model2.CheckDate)).ToString("yyyy年MM月dd日"));
                    #endregion
                    #region 血压
                    string gxhzdyj = "";
                    foreach (string str in AbnormalList)
                    {
                        string[] strMedRes = new string[2];
                        switch (str)
                        {
                            case "血压高":
                                gxhzdyj += "【高血压】\n";
                                if (!string.IsNullOrEmpty(HealthQuestionModel.HeartDis) && HealthQuestionModel.HeartDis.Contains("7"))
                                {
                                    gxhzdyj += $"正常血压范围值：{GetSH("收缩压", "", "150")[0]}/{GetSH("舒张压", "", "150")[0]}mmHg\n";
                                }
                                else
                                {
                                    gxhzdyj += $"正常血压范围值：{GetSH("收缩压", "", "")[0]}/{GetSH("舒张压", "", "")[0]}mmHg\n";
                                }

                                bool b = false;
                                if (!string.IsNullOrEmpty(strRightHeight) && !string.IsNullOrEmpty(strRightPre)) //右侧血压判断
                                {
                                    if (Convert.ToDouble(strRightHeight) >= BloodPreMax || Convert.ToDouble(strRightPre) >= BloodHeightMax)
                                    {
                                        if (model3.LeftHeight > model3.RightHeight)
                                        {
                                            gxhzdyj += $"高血压：{model3.LeftHeight}/{model3.LeftPre}";
                                        }
                                        else
                                        {
                                            gxhzdyj += $"高血压：{model3.RightHeight}/{model3.RightPre}";
                                        }
                                        b = true;
                                    }
                                }
                                if (!b && !string.IsNullOrEmpty(strLeftHeight) && !string.IsNullOrEmpty(strLeftPre)) //左侧血压判断
                                {
                                    if (Convert.ToDouble(strLeftHeight) >= BloodPreMax || Convert.ToDouble(strLeftPre) >= BloodHeightMax)
                                    {
                                        gxhzdyj += $"高血压：{model3.LeftHeight}/{model3.LeftPre}";
                                    }
                                }
                                if (!string.IsNullOrEmpty(HealthQuestionModel.HeartDis) && HealthQuestionModel.HeartDis.Contains("7"))
                                {
                                    gxhzdyj += "≥150/90mmHg\n";
                                }
                                else
                                {
                                    gxhzdyj += "≥140/90mmHg\n";
                                }
                                gxhzdyj += ReadMed("高血压")[0] + "\n";
                                break;
                            case "血压低":
                                gxhzdyj += "【低血压】\n";
                                gxhzdyj += $"正常血压范围值：{GetSH("收缩压", "", "")[0]}/{GetSH("舒张压", "", "")[0]}mmHg\n";
                                if (!string.IsNullOrEmpty(strRightHeight) && !string.IsNullOrEmpty(strRightPre)) //右侧血压判断
                                {
                                    if (Convert.ToDouble(model3.LeftHeight) < BloodPreMin || Convert.ToDouble(model3.LeftPre) < BloodHeightMin)
                                    {
                                        gxhzdyj += $"低血压：{model3.LeftHeight}/{model3.LeftPre}<=90/60mmHg\n";
                                    }
                                }
                                else
                                if (!string.IsNullOrEmpty(strLeftHeight) && !string.IsNullOrEmpty(strLeftPre)) //左侧血压判断
                                {
                                    if (Convert.ToDouble(strLeftHeight) < BloodPreMin || Convert.ToDouble(strLeftPre) < BloodHeightMin)
                                    {
                                        gxhzdyj += $"低血压：{model3.LeftHeight}/{model3.LeftPre}<=90/60mmHg\n";
                                    }
                                }
                                gxhzdyj += ReadMed("低血压")[0] + "\n";
                                break;
                        }
                    }
                    #endregion
                    #region 体质指数
                    if (!string.IsNullOrEmpty(model3.BMI.ToString()) && model3.BMI >= 24)
                    {
                        gxhzdyj += "【超重或肥胖】\n";
                        gxhzdyj += ReadMed("偏胖")[0] + "\n";
                    }
                    if (!string.IsNullOrEmpty(model3.BMI.ToString()) && model3.BMI <= 18.5M)
                    {
                        gxhzdyj += "【偏瘦】\n";
                        gxhzdyj += ReadMed("偏瘦")[0] + "\n";
                    }
                    #endregion
                    #region 其他系统疾病 其他文本判断
                    if ((!string.IsNullOrEmpty(quertionModel.ElseDis) && quertionModel.ElseDis.Contains("7")))
                    {
                        if (!string.IsNullOrEmpty(quertionModel.ElseOther))
                        {
                            if (quertionModel.ElseOther.IndexOf("高脂血症") > -1)
                            {
                                gxhzdyj += "【高脂血症】\n";
                                gxhzdyj += ReadMed("高脂血症")[0] + "\n";
                            }
                            if (quertionModel.ElseOther.IndexOf("脂肪肝") > -1)
                            {
                                gxhzdyj += "【脂肪肝】\n";
                                gxhzdyj += ReadMed("脂肪肝")[0] + "\n";
                            }
                            if (quertionModel.ElseOther.IndexOf("胆囊结石") > -1)
                            {
                                gxhzdyj += "【胆囊结石】\n";
                                gxhzdyj += ReadMed("胆囊结石")[0] + "\n";
                            }
                            if (quertionModel.ElseOther.IndexOf("冠心病") > -1)
                            {
                                gxhzdyj += "【冠心病】\n";
                                gxhzdyj += ReadMed("冠心病")[0] + "\n";
                            }
                            if (quertionModel.ElseOther.IndexOf("脑卒中") > -1)
                            {
                                gxhzdyj += "【脑卒中】\n";
                                gxhzdyj += ReadMed("脑卒中")[0] + "\n";
                            }
                        }
                    }
                    #endregion
                    #region 腰围
                    if (!string.IsNullOrEmpty(model3.Waistline.ToString()))
                    {
                        if (model.Sex == "2" && Convert.ToDouble(model3.Waistline) >= 85) //判断女士腰围
                        {
                            gxhzdyj += "【中心型肥胖】\n";
                            gxhzdyj += ReadMed("中心型肥胖")[0] + "\n";
                        }
                        else if (model.Sex == "1" && Convert.ToDouble(RecordsManageMentModel.Waistline) >= 90)//判断男士腰围
                        {
                            gxhzdyj += "【中心型肥胖】\n";
                            gxhzdyj += ReadMed("中心型肥胖")[0] + "\n";
                        }
                    }
                    #endregion
                    #region 空腹血糖
                    foreach (DataRow item in dtSH.Rows)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(model7.FPGL)) && item["name"].ToString() == "空腹血糖")
                        {
                            if ((model7.FPGL > Convert.ToDecimal(item["maxvalue"].ToString())) || (!string.IsNullOrEmpty(quertionModel.ElseDis) && quertionModel.ElseDis.Contains("2")))
                            {
                                gxhzdyj += "【糖尿病】\n";
                                gxhzdyj += "空腹血糖正常范围:" + GetSH("空腹血糖", "", "")[0] + "mmol/L\n";
                                gxhzdyj += "空腹血糖受损：6.1--7.0mmol/L\n";
                                gxhzdyj += $"糖尿病：{model7.FPGL}≥7.0mmol/L\n";
                                gxhzdyj += ReadMed("高血糖")[0] + "\n";
                            }
                            else if (Convert.ToDecimal(model7.FPGL) < Convert.ToDecimal(item["minvalue"].ToString()))
                            {
                                string[] Result = GetSH("空腹血糖", "", "");
                                gxhzdyj += "【低血糖】\n";
                                gxhzdyj += "空腹血糖正常范围:" + Result[0] + "mmol/L\n";
                                gxhzdyj += $"糖尿病：{model7.FPGL}小于等于{Result[3]}mmol/L\n";
                                gxhzdyj += ReadMed("低血糖")[0] + "\n";
                            }
                        }
                    }
                    #endregion
                    #region 血常规
                    gxhzdyj += GetXCGex(model.Sex, model7);
                    #endregion
                    #region 肝功能
                    gxhzdyj += GetGGNex(model.Sex, model7);
                    #endregion
                    #region 肾功能
                    gxhzdyj += GetSGNexValue(model.Sex, model7);
                    #endregion
                    #region 血脂
                    gxhzdyj += GetXZex(model7);
                    #endregion

                    Replace(doc, "{$gxhzdyj}", gxhzdyj);
                }

                #region 尿

                string strNiaoWhere = string.Format("IDCardNo='{0}' AND Devicetype=33 AND LEFT(UpdateData,4)='{1}' ORDER BY UpdateData DESC,ID DESC LIMIT 0,1 ", this.CardID, strYear);
                DataSet UrineDt = new DeviceInfoDAL().GetList(strNiaoWhere);

                if (UrineDt.Tables[0].Rows.Count > 0)
                {
                    value = ReadDS(UrineDt, "VALUE6");
                    if (area == "济宁")
                    {
                        value = GetExNiaoPlus(value.ToString());
                    }
                    Replace(doc, "{$ndb}", value);
                    if (toString(value).Contains("+"))
                    {
                        AbnormalList.Add("尿蛋白异常");
                    }

                    value = ReadDS(UrineDt, "VALUE2");
                    if (area == "济宁")
                    {
                        value = GetExNiaoPlus(value.ToString());
                    }
                    Replace(doc, "{$nqx}", value);
                    if (toString(value).Contains("+"))
                    {
                        AbnormalList.Add("尿潜血异常");
                    }



                    value = ReadDS(UrineDt, "VALUE4");
                    if (area == "济宁")
                    {
                        value = GetExNiaoPlus(value.ToString());
                    }
                    Replace(doc, "{$ntt}", value);
                    //if (toString(value).Contains("+"))
                    //{
                    //    AbnormalList.Add("尿酮体异常");
                    //}



                    value = ReadDS(UrineDt, "VALUE5");
                    if (area == "济宁")
                    {
                        value = GetExNiaoPlus(value.ToString());
                    }
                    Replace(doc, "{$nt}", value);
                    if (toString(value).Contains("+"))
                    {
                        AbnormalList.Add("尿糖异常");
                    }


                }
                else
                {
                    if (area == "济宁")
                    {
                        Replace(doc, "{$ndb}", GetExNiaoPlus(model7.PRO));
                    }
                    else
                    {
                        Replace(doc, "{$ndb}", model7.PRO);
                    }
                    if (toString(model7.PRO).Contains("+"))
                    {
                        AbnormalList.Add("尿蛋白异常");
                    }

                    if (area == "济宁")
                    {
                        Replace(doc, "{$ntt}", GetExNiaoPlus(model7.KET));
                    }
                    else
                    {
                        Replace(doc, "{$ntt}", model7.KET);
                    }
                    //if (toString(model7.KET).Contains("+"))
                    //{
                    //    AbnormalList.Add("尿酮体异常");
                    //}

                    if (area == "济宁")
                    {
                        Replace(doc, "{$nt}", GetExNiaoPlus(model7.GLU));
                    }
                    else
                    {
                        Replace(doc, "{$nt}", model7.GLU);
                    }
                    if (toString(model7.GLU).Contains("+"))
                    {
                        AbnormalList.Add("尿糖异常");
                    }


                    if (area == "济宁")
                    {
                        Replace(doc, "{$nqx}", GetExNiaoPlus(model7.BLD));
                    }
                    else
                    {
                        Replace(doc, "{$nqx}", model7.BLD);
                    }
                    if (toString(model7.BLD).Contains("+"))
                    {
                        AbnormalList.Add("尿潜血异常");
                    }
                }

                value = ReadDS(UrineDt, "VALUE9");
                Replace(doc, "{$bxp}", value);
                if (toString(value).Contains("+"))
                {
                    AbnormalList.Add("尿白细胞异常");
                }

                value = ReadDS(UrineDt, "VALUE8");
                Replace(doc, "{$xsy}", value);
                //if (toString(value).Contains("+"))
                //{
                //    AbnormalList.Add("尿硝酸盐异常");
                //}

                value = ReadDS(UrineDt, "VALUE1");
                Replace(doc, "{$ndy}", value);
                //if (toString(value).Contains("+"))
                //{
                //    AbnormalList.Add("尿胆原异常");
                //}

                value = ReadDS(UrineDt, "VALUE7");
                strRes = ReadRange("PH值", "", value);
                Replace(doc, "{$ph}", value);
                Replace(doc, "{$Rph}", strRes[0]);
                Replace(doc, "{$Cph}", strRes[1]);
                Replace(doc, "{$Tph}", strRes[2]);

                value = ReadDS(UrineDt, "VALUE3");
                Replace(doc, "{$dhs}", value);
                //if (toString(value).Contains("+"))
                //{
                //    AbnormalList.Add("尿胆红素异常");
                //}

                value = ReadDS(UrineDt, "VALUE11");
                Replace(doc, "{$vss}", value);
                //if (toString(value).Contains("+"))
                //{
                //    AbnormalList.Add("维生素异常");
                //}

                value = ReadDS(UrineDt, "VALUE10");
                strRes = ReadRange("比重", "", value);
                Replace(doc, "{$nbz}", value);
                Replace(doc, "{$Rnbz}", strRes[0]);
                Replace(doc, "{$Cnbz}", strRes[1]);
                Replace(doc, "{$Tnbz}", strRes[2]);
                #endregion

                #region 医师签名
                RecordsSignatureModel SignModel = new RecordsSignatureBLL().GetModelByOutKey(0, "签字维护");
                if (SignModel != null)
                {
                    Replace(doc, "{$zrys}", SignModel.AssistQtSn);
                }
                else Replace(doc, "{$zrys}", "");
                #endregion

                #region 审核医生
                //if (area.Equals("禹城"))
                {

                    DateTime checkdate;
                    if (DateTime.TryParse(model2.CheckDate.ToString(), out checkdate))
                    {
                        if (File.Exists(SignPath + checkdate.ToString("yyyy-MM-dd") + "/_Doctor6.png"))
                        {
                            InsertImage(SignPath + checkdate.ToString("yyyy-MM-dd") + "/_Doctor6.png", "{&zrys}", doc, 50, 30);
                        }
                        else
                        {
                            InsertImage(SignPath + "_Doctor6.png", "{&zrys}", doc, 50, 30);
                        }
                    }
                }
                #endregion

                #region 照片
                string path = PhotoPath + "\\" + model.IDCardNo + ".Jpeg";
                InsertImage(path, "{&photo}", doc, 75, 90);
                #endregion

                #region B超
                string BcWhere = string.Format("  AND PTNIDNO='{0}' AND LEFT(DIAGTM,4)='{1}' ORDER BY DIAGTM DESC,ID DESC LIMIT 0,1 ", this.CardID, strYear);
                DataSet tbchao = new TypeBBLL().GetByWhere(BcWhere);
                string mId = "";
                if (tbchao != null)
                {
                    DataTable dt = tbchao.Tables[0];

                    if (dt.Rows.Count > 0) mId = dt.Rows[0]["MID"].ToString();
                }
                string BCpath = @"D:\QCSoft\TypeB\" + mId + ".jpg";
                InsertBCImage(BCpath, "{&BC}", doc, 400, 650);
                #endregion

                #region 心电
                string xdWhere = string.Format(" IDCardNo='{0}' AND LEFT(CreateTime,4)='{1}' ORDER BY CreateTime DESC,ID DESC LIMIT 0,1 ", this.CardID, strYear);
                RecordsEcgModel ecgModel = new RecordsEcgBLL().GetModelByWhere(xdWhere);
                if (ecgModel == null) ecgModel = new RecordsEcgModel();
                string Ecgpath = ECGReport + "\\" + ecgModel.MID + ".png";
                InsertECGImage(Ecgpath, "{&XD}", doc, 450, 750, ecgModel);
                #endregion

                #region 中医体质辨识
                string strzytz = "", strzyjy = "";
                string zywhere = string.Format(" IDCardNo='{0}' AND Left(FollowUpDate,4)='{1}' order by FollowUpDate DESC limit 0,1 ", this.CardID, strYear);//获取体检本年度的数据
                OlderSelfCareabilityModel CareModel = new OlderSelfCareabilityBLL().CheckModel(zywhere);
                if (CareModel != null)
                {
                    OlderMedicineResultModel model4 = new OlderMedicineResultBLL().GetModel(this.CardID, CareModel.ID);
                    if (model4 != null)
                    {
                        if (!string.IsNullOrEmpty(model4.Mild))
                        {
                            if (model4.Mild == "1" || model4.Mild == "2")
                                strzytz += "平和质、";
                        }
                        if (!string.IsNullOrEmpty(model4.Faint))
                        {
                            if (model4.Faint == "1" || model4.Faint == "2")
                                strzytz += "气虚质、";
                        }
                        if (!string.IsNullOrEmpty(model4.Yang))
                        {
                            if (model4.Yang == "1" || model4.Yang == "2")
                                strzytz += "阳虚质、";
                        }
                        if (!string.IsNullOrEmpty(model4.Yin))
                        {
                            if (model4.Yin == "1" || model4.Yin == "2")
                                strzytz += "阴虚质、";
                        }
                        if (!string.IsNullOrEmpty(model4.PhlegmDamp))
                        {
                            if (model4.PhlegmDamp == "1" || model4.PhlegmDamp == "2")
                                strzytz += "痰湿质、";
                        }
                        if (!string.IsNullOrEmpty(model4.Muggy))
                        {
                            if (model4.Muggy == "1" || model4.Muggy == "2")
                                strzytz += "湿热质、";
                        }
                        if (!string.IsNullOrEmpty(model4.BloodStasis))
                        {
                            if (model4.BloodStasis == "1" || model4.BloodStasis == "2")
                                strzytz += "血瘀质、";
                        }
                        if (!string.IsNullOrEmpty(model4.QiConstraint))
                        {
                            if (model4.QiConstraint == "1" || model4.QiConstraint == "2")
                                strzytz += "气郁质、";
                        }
                        if (!string.IsNullOrEmpty(model4.Characteristic))
                        {
                            if (model4.Characteristic == "1" || model4.Characteristic == "2")
                                strzytz += "特兼质、";
                        }
                        if (!string.IsNullOrEmpty(strzytz))
                        {
                            strzytz = strzytz.Trim(new char[] { '、' });
                        }
                    }
                }

                string[] strMed = strzytz.Split(new char[] { '、' });
                foreach (string str in strMed)
                {
                    if (string.IsNullOrEmpty(str)) continue;
                    string[] MedRes = ReadMed(str);
                    if (area == "济宁")
                    {
                        strzyjy += str + "\n" + MedRes[0].Replace(" ", "").Trim() + "\n";
                    }
                    else
                    {
                        strzyjy += str + ":" + MedRes[0].Replace("\n", "").Replace("\r", "").Replace(" ", "").Trim() + "\n";
                    }
                }
                Replace(doc, "{$tzlx}", strzytz);
                Replace(doc, "{$tzjy}", strzyjy);
                #endregion

                if (!area.Equals("济宁"))
                {
                    #region 体检异常结果表格
                    if (AbnormalList.Count == 0)
                    {
                        Replace(doc, "{$ycjg}", "无");
                    }
                    else
                    {
                        //查找关键字符串文本
                        Spire.Doc.Section section = doc.Sections[0];
                        Spire.Doc.Documents.TextSelection selection = doc.FindString("{$ycjg}", true, true);
                        //获取关键字符串所在段落的索引
                        Spire.Doc.Fields.TextRange range = selection.GetAsOneRange();
                        Spire.Doc.Documents.Paragraph paragraph = range.OwnerParagraph;
                        Body body = paragraph.OwnerTextBody;
                        int index = body.ChildObjects.IndexOf(paragraph);

                        //添加表格
                        Spire.Doc.Table table = section.AddTable(true);
                        int row = AbnormalList.Count / 3;
                        if (AbnormalList.Count % 3 != 0)
                        {
                            row = row + 1;
                        }
                        table.ResetCells(row, 3);
                        for (int i = 0; i < AbnormalList.Count; i++)
                        {
                            int InsertRow = i / 3;
                            int Col = i % 3;
                            range = table[InsertRow, Col].AddParagraph().AppendText(AbnormalList[i].ToString());

                        }
                        //移除段落，插入表格 
                        body.ChildObjects.Remove(paragraph);
                        body.ChildObjects.Insert(index, table);
                    }
                    #endregion

                    #region 健康指导意见
                    foreach (string str in AbnormalList)
                    {
                        string[] strMedRes = new string[2];
                        switch (str)
                        {
                            case "血压高":
                                strMedRes = ReadMed("高血压");
                                break;
                            case "血压低":
                                strMedRes = ReadMed("低血压");
                                break;
                            case "空腹血糖偏低":
                                strMedRes = ReadMed("低血糖");
                                break;
                            case "空腹血糖偏高":
                                strMedRes = ReadMed("高血糖");
                                break;
                            case "血清谷丙转氨酶偏高":
                                strMedRes = ReadMed("血清谷丙转氨酶异常");
                                break;
                            case "血清谷丙转氨酶偏低":
                                strMedRes = ReadMed("血清谷丙转氨酶异常");
                                break;
                            case "B超异常":
                                strMedRes[0] = "与临床相结合，建议复查";
                                if (!string.IsNullOrEmpty(model7.BCHAOEx))
                                    strMedRes[1] = model7.BCHAOEx;
                                break;
                            case "心电异常":
                                strMedRes[0] = "与临床相结合，建议复查";
                                if (!string.IsNullOrEmpty(model7.ECG))
                                {
                                    if (model7.ECG.Contains("2"))
                                    {
                                        strMedRes[1] += "ST-T改变,";
                                    }
                                    if (model7.ECG.Contains("3"))
                                    {
                                        strMedRes[1] += "陈旧性心肌梗塞,";
                                    }
                                    if (model7.ECG.Contains("4"))
                                    {
                                        strMedRes[1] += "窦性心动过速,";
                                    }
                                    if (model7.ECG.Contains("5"))
                                    {
                                        strMedRes[1] += "窦性心动过缓,";
                                    }
                                    if (model7.ECG.Contains("6"))
                                    {
                                        strMedRes[1] += "早搏,";
                                    }
                                    if (model7.ECG.Contains("7"))
                                    {
                                        strMedRes[1] += "房颤,";
                                    }
                                    if (model7.ECG.Contains("8"))
                                    {
                                        strMedRes[1] += "房室传导阻滞,";
                                    }
                                    if (model7.ECG.Contains("9"))
                                    {
                                        strMedRes[1] += model7.ECGEx;
                                    }
                                }
                                break;
                            default:
                                strMedRes = ReadMed(str);
                                break;

                        }
                        if (strMedRes[0] != null)
                        {
                            strAdvice += "【" + str + "】" + "\n" + "建议  " + strMedRes[0].ToString().Replace("\n", "").Replace("\r", "").Replace(" ", "").Trim() + "\n"; ;
                        }
                        if (strMedRes[1] != null)
                        {
                            strAdvice += "描述  " + strMedRes[1].ToString().Replace("\n", "").Replace("\r", "").Replace(" ", "").Trim() + "\n";
                        }
                    }
                    Replace(doc, "{$jkzjjy}", strAdvice);
                    #endregion
                }

                string saveTemp = Environment.CurrentDirectory + "\\printtemp\\40体检报告" + this.CardID + ".docx";
                string targeXps = Environment.CurrentDirectory + "\\printXps\\" + PrintName;

                doc.SaveToFile(saveTemp, FileFormat.Docx);

                Thread.Sleep(2000);
                TransWord tw = new TransWord();
                bool result = tw.Convert(saveTemp, targeXps, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatXPS);
                File.Delete(saveTemp);

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                DrawItems.WriteLog(ex.ToString());

                return false;
            }
        }

        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        /// <param name="strreplace">替换字段</param>
        /// <param name="doc">替换文档</param>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        public void InsertImage(string imagePath, string strreplace, Document doc, int width, int height)
        {
            try
            {
                Image image = null;

                if (File.Exists(imagePath))
                {
                    image = Image.FromFile(imagePath);
                    //获取第一个section
                    Spire.Doc.Section sec = doc.Sections[0];

                    //查找文档中的指定文本内容
                    Spire.Doc.Documents.TextSelection[] selections = doc.FindAllString(strreplace, true, true);
                    int index = 0;
                    Spire.Doc.Fields.TextRange range = null;
                    //遍历文档，移除文本内容，插入图片
                    foreach (Spire.Doc.Documents.TextSelection selection in selections)
                    {
                        DocPicture pic = new DocPicture(doc);
                        pic.LoadImage(image);
                        pic.Width = width;
                        pic.Height = height;
                        range = selection.GetAsOneRange();
                        index = range.OwnerParagraph.ChildObjects.IndexOf(range);
                        range.OwnerParagraph.ChildObjects.Insert(index, pic);
                        range.OwnerParagraph.ChildObjects.Remove(range);
                    }
                }
                else
                {
                    Replace(doc, strreplace, "");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString() + imagePath);
            }

        }

        /// <summary>
        /// 会产生graphics异常的PixelFormat
        /// </summary>
        private static PixelFormat[] indexedPixelFormats = { PixelFormat.Undefined, PixelFormat.DontCare,
         PixelFormat.Format16bppArgb1555, PixelFormat.Format1bppIndexed, PixelFormat.Format4bppIndexed,
         PixelFormat.Format8bppIndexed
            };
        /// <summary>
        /// 判断图片的PixelFormat 是否在 引发异常的 PixelFormat 之中
        /// </summary>
        /// <param name="imgPixelFormat">原图片的PixelFormat</param>
        /// <returns></returns>
        private static bool IsPixelFormatIndexed(PixelFormat imgPixelFormat)
        {
            foreach (PixelFormat pf in indexedPixelFormats)
            {
                if (pf.Equals(imgPixelFormat)) return true;
            }

            return false;
        }

        /// <summary>
        /// 插入心电图片，组合医生签名
        /// </summary>
        /// <param name="image"></param>
        /// <param name="strreplace"></param>
        /// <param name="doc"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void InsertECGImage(string path, string strreplace, Document doc, int width, int height, RecordsEcgModel ecgModel)
        {
            if (File.Exists(path))
            {
                Graphics g = null;
                //使用
                using (Image img = Image.FromFile(path))
                {
                    //如果原图片是索引像素格式之列的，则需要转换
                    if (IsPixelFormatIndexed(img.PixelFormat))
                    {
                        Bitmap bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
                        using (g = Graphics.FromImage(bmp))
                        {
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                            path = path.Replace(".png", ".jpg");
                            img.Save(path, ImageFormat.Jpeg);
                        }
                    }
                }
                FileStream fs = new System.IO.FileStream(path, FileMode.Open, FileAccess.Read);

                int byteLength = (int)fs.Length;
                byte[] fileBytes = new byte[byteLength];
                fs.Read(fileBytes, 0, byteLength);

                //文件流关閉,文件解除锁定
                fs.Close();
                Image image = Image.FromStream(new MemoryStream(fileBytes));
                g = Graphics.FromImage(image);

                #region 禹城 检查医生取文字版，审核医生取手写版，检查日期取心电createTime
                if (area.Equals("禹城") || area.Equals("平度"))
                {
                    RecordsSignatureModel signModel = new RecordsSignatureBLL().GetModelByOutKey(0, "签字维护");
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
                        Font font = new Font("KaiTi", 30, FontStyle.Bold);
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
                        g.DrawImage(imgrq, 1800, 1950, imgrq.Width, imgrq.Height);
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

                //获取第一个section
                Spire.Doc.Section sec = doc.Sections[0];

                //查找文档中的指定文本内容
                Spire.Doc.Documents.TextSelection[] selections = doc.FindAllString(strreplace, true, true);
                int index = 0;
                Spire.Doc.Fields.TextRange range = null;
                //遍历文档，移除文本内容，插入图片
                foreach (Spire.Doc.Documents.TextSelection selection in selections)
                {
                    DocPicture pic = new DocPicture(doc);
                    pic.LoadImage(image);
                    pic.Width = width;
                    pic.Height = height;
                    range = selection.GetAsOneRange();
                    index = range.OwnerParagraph.ChildObjects.IndexOf(range);
                    range.OwnerParagraph.ChildObjects.Insert(index, pic);
                    range.OwnerParagraph.ChildObjects.Remove(range);
                }
            }
            else
            {
                Replace(doc, strreplace, "");
            }
        }


        public void InsertBCImage(string path, string strreplace, Document doc, int width, int height)
        {
            if (File.Exists(path))
            {
                FileStream fs = new System.IO.FileStream(path, FileMode.Open, FileAccess.Read);

                int byteLength = (int)fs.Length;
                byte[] fileBytes = new byte[byteLength];
                fs.Read(fileBytes, 0, byteLength);

                //文件流关閉,文件解除锁定
                fs.Close();
                Image image = Image.FromStream(new MemoryStream(fileBytes));
                Graphics g = Graphics.FromImage(image);

                // 加载B超医生签名
                string signPath = SignPath + "_Doctor17.png";

                if (community != "桓台妇幼" && community != "铁营卫生院")
                {
                    if (File.Exists(signPath))
                    {
                        Image img = Image.FromFile(signPath);

                        // 将医生签名拼接到诊断医生的位置之上
                        g.DrawImage(img, 450, 800, img.Width, img.Height);
                    }
                    else g.DrawImage(image, 0, 0, image.Width, image.Height);
                }
                else g.DrawImage(image, 0, 0, image.Width, image.Height);

                fs.Close();

                //获取第一个section
                Spire.Doc.Section sec = doc.Sections[0];

                //查找文档中的指定文本内容
                Spire.Doc.Documents.TextSelection[] selections = doc.FindAllString(strreplace, true, true);
                int index = 0;
                Spire.Doc.Fields.TextRange range = null;

                //遍历文档，移除文本内容，插入图片
                foreach (Spire.Doc.Documents.TextSelection selection in selections)
                {
                    DocPicture pic = new DocPicture(doc);
                    pic.LoadImage(image);
                    pic.Width = width;
                    pic.Height = height;
                    range = selection.GetAsOneRange();
                    index = range.OwnerParagraph.ChildObjects.IndexOf(range);
                    range.OwnerParagraph.ChildObjects.Insert(index, pic);
                    range.OwnerParagraph.ChildObjects.Remove(range);
                }
            }
            else
            {
                Replace(doc, strreplace, "");
            }
        }

        public object ReadDS(DataSet ds, string code)
        {
            object Value = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                Value = ds.Tables[0].Rows[0][code];
            }
            return Value;
        }

        /// <summary>
        /// 读取范围值
        /// </summary>
        /// <param name="name">字段名称</param>
        /// <param name="nameSex">区分性别字段名称</param>
        /// <param name="value">体检数值</param>
        /// <param name="flag">体检异常结果是否显示</param>
        /// <returns></returns>
        public string[] ReadRange(string name, string nameSex, object value, bool flag = false)
        {
            string[] Result = new string[3];
            DataRow[] dr = null;
            if (!string.IsNullOrEmpty(nameSex))//区分性别
            {
                dr = dtSH.Select("name='" + nameSex + "'");
            }
            DataRow[] dr2 = dtSH.Select("name='" + name + "'");

            if (dr != null && dr.Length > 0)
            {
                Result[0] = dr[0]["minvalue"].ToString() + "-" + dr[0]["maxvalue"].ToString();
                Result[1] = dr[0]["measurement"].ToString();
                if (toString(value) != "")
                {
                    if (Convert.ToDecimal(value.ToString()) < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        if (flag)
                        {
                            AbnormalList.Add(name + "偏低");
                        }
                        Result[2] = "↓";
                    }
                    else if (Convert.ToDecimal(value.ToString()) > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        if (flag)
                        {
                            AbnormalList.Add(name + "偏高");
                        }
                        Result[2] = "↑";
                    }
                }

            }
            else if (dr2.Length > 0)
            {
                Result[0] = dr2[0]["minvalue"].ToString() + "-" + dr2[0]["maxvalue"].ToString();
                Result[1] = dr2[0]["measurement"].ToString();
                if (toString(value) != "")
                {
                    if (Convert.ToDecimal(value.ToString()) < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        if (flag)
                        {
                            AbnormalList.Add(name + "偏低");
                        }
                        Result[2] = "↓";
                    }
                    else if (Convert.ToDecimal(value.ToString()) > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        if (flag)
                        {
                            AbnormalList.Add(name + "偏高");
                        }
                        Result[2] = "↑";
                    }
                }
            }
            return Result;
        }

        private string[] GetSH(string name, string nameSex, string max)
        {
            string[] Result = new string[4];
            DataRow[] dr = null;
            if (!string.IsNullOrEmpty(nameSex))//区分性别
            {
                dr = dtSH.Select("name='" + nameSex + "'");
            }
            else
            {
                dr = dtSH.Select("name='" + name + "'");
            }

            if (dr != null && dr.Length > 0)
            {
                if (!string.IsNullOrEmpty(max))
                {
                    Result[0] = dr[0]["minvalue"].ToString() + "-" + max;
                    Result[3] = dr[0]["minvalue"].ToString();
                }
                else
                {
                    Result[0] = dr[0]["minvalue"].ToString() + "-" + dr[0]["maxvalue"].ToString();
                }
                Result[1] = dr[0]["measurement"].ToString();

            }
            return Result;
        }

        public string[] ReadMed(string name)
        {
            string[] Result = new string[2];
            DataRow[] dr = dtMed.Select("name='" + name + "'");

            if (dr != null && dr.Length > 0)
            {
                Result[0] = dr[0]["jianyi"].ToString();
                Result[1] = dr[0]["describe"].ToString();
            }
            return Result;
        }

        public DocumentReference AddPage(string fileName)
        {
            DocumentReference newDocRef = new DocumentReference();
            FixedDocument newFd = new FixedDocument();

            XpsDocument xpsDocument = new XpsDocument(fileName, FileAccess.Read);
            FixedDocumentSequence docSeq = xpsDocument.GetFixedDocumentSequence();

            foreach (DocumentReference docRef in docSeq.References)
            {
                FixedDocument fd = docRef.GetDocument(false);

                foreach (PageContent oldPC in fd.Pages)
                {
                    Uri uSource = oldPC.Source;//读取源地址
                    Uri uBase = (oldPC as IUriContext).BaseUri;//读取目标页面地址
                    PageContent newPageContent = new PageContent();
                    newPageContent.GetPageRoot(false);//这个地方应当是把文档解压成一个包放到内存中我们再去读取
                    newPageContent.Source = uSource;
                    (newPageContent as IUriContext).BaseUri = uBase;
                    newFd.Pages.Add(newPageContent);//将新文档追加到新的documentRefences中
                }
            }
            newDocRef.SetDocument(newFd);
            xpsDocument.Close();
            return newDocRef;
        }

        /// <summary>
        /// 字串Null转换为空白
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string toString(object value)
        {
            if (value == null) return "";
            else return value.ToString();
        }

        /// <summary>
        /// 将尿仪数据+1、+2改为+、++
        /// </summary>
        /// <param name="PRO"></param>
        /// <returns></returns>
        private string GetExNiaoPlus(string PRO)
        {
            if (string.IsNullOrEmpty(PRO))
            {
                return "";
            }
            PRO = PRO.Replace("+1", "+").Replace("+2", "++").Replace("+3", "+++").Replace("+4", "++++").Replace("+5", "+++++").Replace("+6", "++++++").Replace("+7", "+++++++").Replace("+8", "+++++++++");
            if (community == "小孟镇")
            {
                PRO = PRO.Replace("+-", "±");
            }
            return PRO;
        }

        public string GetZYB(string value, string valueOther)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value == "1")
                {
                    return "无";
                }
                else if (value == "2")
                {
                    return "有  " + valueOther;
                }
            }
            return "";
        }

        public string GetPillDependence(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value == "1")
                {
                    return "规律";
                }
                if (value == "2")
                {
                    return "间断";
                }
                if (value == "3")
                {
                    return "不服药";
                }
            }
            return "";
        }

        private string GetXCGex(string sex, RecordsAssistCheckModel model)
        {
            string strshxqex = "";
            string strHBItem = "血红蛋白";

            if (sex == "1") strHBItem = "血红蛋白男";
            else if (sex == "2") strHBItem = "血红蛋白女";

            if (!string.IsNullOrEmpty(Convert.ToString(model.HB)))
            {
                DataRow[] dr = dtSH.Select("name='" + strHBItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血红蛋白'");

                if (dr.Length > 0)
                {
                    if (model.HB < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血红蛋白偏低】\n";
                        strshxqex += $"正常血红蛋白范围值：{GetSH("血红蛋白", "", "")[0] + dr[0]["measurement"].ToString()}\n";
                        strshxqex += $"血红蛋白:{model.HB}<{dr[0]["minvalue"].ToString() + dr[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血红蛋白偏低")[0] + "\n";
                    }
                    else if (model.HB > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血红蛋白偏高】\n";
                        strshxqex += $"正常血红蛋白范围值：{GetSH("血红蛋白", "", "")[0] + dr[0]["measurement"].ToString()}\n";
                        strshxqex += $"血红蛋白:{model.HB}>{dr[0]["minvalue"].ToString() + dr[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血红蛋白偏高")[0] + "\n";
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (model.HB < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血红蛋白偏低】\n";
                        strshxqex += $"正常血红蛋白范围值：{GetSH("血红蛋白", "", "")[0] + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += $"血红蛋白:{model.HB}<{dr2[0]["minvalue"].ToString() + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血红蛋白偏低")[0] + "\n";
                    }
                    else if (model.HB > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血红蛋白偏高】\n";
                        strshxqex += $"正常血红蛋白范围值：{GetSH("血红蛋白", "", "")[0] + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += $"血红蛋白{model.HB}>{dr2[0]["maxvalue"].ToString() + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血红蛋白偏高")[0] + "\n";
                    }
                }
            }
            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(model.WBC)) && item["name"].ToString() == "白细胞") //白细胞      ------》血球 范围 4.0-10.0x10^9/L
                {
                    if (model.WBC < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【白细胞偏低】\n";
                        strshxqex += $"正常白细胞范围值：{GetSH("白细胞", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"白细胞:{model.WBC}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("白细胞偏低")[0] + "\n";
                    }
                    else if (model.WBC > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【白细胞偏高】\n";
                        strshxqex += $"正常白细胞范围值：{GetSH("白细胞", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"白细胞:{model.WBC}>{item["maxvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("白细胞偏高")[0] + "\n";
                    }
                    continue;
                }
                if (!string.IsNullOrEmpty(Convert.ToString(model.PLT)) && item["name"].ToString() == "血小板") //血小板      ------》血球 范围100-300x10^9/L
                {
                    if (model.PLT < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血小板偏低】\n";
                        strshxqex += $"正常血小板范围值：{GetSH("血小板", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"血小板:{model.PLT}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血小板偏低")[0] + "\n";
                    }
                    else if (model.PLT > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血小板偏高】\n";
                        strshxqex += $"正常血小板范围值：{GetSH("血小板", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"血小板:{model.PLT}>{item["maxvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血小板偏高")[0] + "\n";
                    }
                    continue;
                }
            }
            return strshxqex.TrimEnd(',');
        }

        private string GetGGNex(string sex, RecordsAssistCheckModel model)
        {
            string strshxqex = "";
            string strSGPTItem = "血清谷丙转氨酶", strGOTItem = "血清谷草转氨酶";

            if (sex == "1")
            {
                strSGPTItem = "血清谷丙转氨酶男";
                strGOTItem = "血清谷草转氨酶男";
            }
            else if (sex == "2")
            {
                strSGPTItem = "血清谷丙转氨酶女";
                strGOTItem = "血清谷草转氨酶女";
            }

            if (!string.IsNullOrEmpty(Convert.ToString(model.SGPT)))
            {
                DataRow[] dr = dtSH.Select("name='" + strSGPTItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血清谷丙转氨酶'");

                if (dr.Length > 0)
                {
                    if (model.SGPT < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清谷丙转氨酶偏低】\n";
                        strshxqex += $"正常血清谷丙转氨酶范围值：{GetSH("血清谷丙转氨酶", "", "")[0] + dr[0]["measurement"].ToString()}\n";
                        strshxqex += $"血清谷丙转氨酶:{model.SGPT}<{dr[0]["minvalue"].ToString() + dr[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清谷丙转氨酶偏低")[0] + "\n";
                    }
                    else if (model.SGPT > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清谷丙转氨酶偏高】\n";
                        strshxqex += $"正常血清谷丙转氨酶范围值：{GetSH("血清谷丙转氨酶", "", "")[0] + dr[0]["measurement"].ToString()}\n";
                        strshxqex += $"血清谷丙转氨酶:{model.SGPT}>{dr[0]["maxvalue"].ToString() + dr[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清谷丙转氨酶偏高")[0] + "\n";
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (model.SGPT < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清谷丙转氨酶偏低】\n";
                        strshxqex += $"正常血清谷丙转氨酶范围值：{GetSH("血清谷丙转氨酶", "", "")[0] + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += $"血清谷丙转氨酶:{model.SGPT}<{dr2[0]["minvalue"].ToString() + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清谷丙转氨酶偏低")[0] + "\n";
                    }
                    else if (model.SGPT > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清谷丙转氨酶偏高】\n";
                        strshxqex += $"正常血清谷丙转氨酶范围值：{GetSH("血清谷丙转氨酶", "", "")[0] + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += $"血清谷丙转氨酶:{model.SGPT}>{dr2[0]["maxvalue"].ToString() + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清谷丙转氨酶偏高")[0] + "\n";
                    }
                }
            }

            if (!string.IsNullOrEmpty(Convert.ToString(model.GOT)))
            {
                DataRow[] dr = dtSH.Select("name='" + strGOTItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血清谷草转氨酶'");

                if (dr.Length > 0)
                {
                    if (model.GOT < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清谷草转氨酶偏低】\n";
                        strshxqex += $"正常血清谷丙转氨酶范围值：{GetSH("血清谷草转氨酶", "", "")[0] + dr[0]["measurement"].ToString()}\n";
                        strshxqex += $"血清谷草转氨酶:{model.GOT}<{dr[0]["minvalue"].ToString() + dr[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清谷草转氨酶偏低")[0] + "\n";
                    }
                    else if (model.GOT > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清谷草转氨酶偏高】\n";
                        strshxqex += $"正常血清谷丙转氨酶范围值：{GetSH("血清谷草转氨酶", "", "")[0] + dr[0]["measurement"].ToString()}\n";
                        strshxqex += $"血清谷草转氨酶:{model.GOT}>{dr[0]["minvalue"].ToString() + dr[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清谷草转氨酶偏高")[0] + "\n";
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (model.GOT < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清谷草转氨酶偏低】\n";
                        strshxqex += $"正常血清谷丙转氨酶范围值：{GetSH("血清谷草转氨酶", "", "")[0] + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += $"血清谷草转氨酶:{model.GOT}<{dr2[0]["minvalue"].ToString() + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清谷草转氨酶偏低")[0] + "\n";
                    }
                    else if (model.GOT > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清谷草转氨酶偏高】\n";
                        strshxqex += $"正常血清谷丙转氨酶范围值：{GetSH("血清谷草转氨酶", "", "")[0] + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += $"血清谷草转氨酶:{model.GOT}>{dr2[0]["minvalue"].ToString() + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清谷草转氨酶偏高")[0] + "\n";
                    }
                }
            }
            foreach (DataRow item in dtSH.Rows)
            {
                string ItemNameGB = "血清谷丙转氨酶";
                string ItemNameGC = "血清谷草转氨酶";
                if (!string.IsNullOrEmpty(Convert.ToString(model.BP)) && item["name"].ToString() == "白蛋白") //白蛋白    ------》生化 范围37-53g/L
                {
                    if (model.BP < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【白蛋白偏低】\n";
                        strshxqex += $"正常白蛋白范围值：{GetSH("白蛋白", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"白蛋白:{model.BP}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("白蛋白偏低")[0] + "\n";
                    }
                    else if (model.BP > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【白蛋白偏高】\n";
                        strshxqex += $"正常白蛋白范围值：{GetSH("白蛋白", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"白蛋白:{model.BP}>{item["maxvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("白蛋白偏高")[0] + "\n";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(model.TBIL)) && item["name"].ToString() == "总胆红素") //总胆红素    ------》生化 范围5.1-19μmol/L
                {
                    if (Convert.ToDouble(model.TBIL) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【总胆红素偏低】\n";
                        strshxqex += $"正常总胆红素范围值：{GetSH("总胆红素", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"总胆红素:{model.TBIL}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("总胆红素偏低")[0] + "\n";
                    }
                    else if (model.TBIL > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【总胆红素偏高】\n";
                        strshxqex += $"正常总胆红素范围值：{GetSH("总胆红素", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"总胆红素:{model.TBIL}>{item["maxvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("总胆红素偏高")[0] + "\n";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(model.CB)) && item["name"].ToString() == "结合胆红素") //结合胆红素    ------》生化 范围1.7-6.8μmol/L
                {
                    if (Convert.ToDouble(model.CB) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【结合胆红素偏低】\n";
                        strshxqex += $"正常结合胆红素范围值：{GetSH("结合胆红素", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"结合胆红素:{model.CB}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("结合胆红素偏低")[0] + "\n";
                    }
                    else if (Convert.ToDouble(model.CB) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【结合胆红素偏高】\n";
                        strshxqex += $"正常结合胆红素范围值：{GetSH("结合胆红素", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"结合胆红素:{model.CB}>{item["maxvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("结合胆红素偏高")[0] + "\n";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(model.GT)) && item["name"].ToString() == "谷氨酰转肽酶") //谷氨酰转肽酶    ------》生化 范围0-50 U/L
                {
                    if (model.GT < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【谷氨酰转肽酶偏低】\n";
                        strshxqex += $"正常谷氨酰转肽酶范围值：{GetSH("谷氨酰转肽酶", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"谷氨酰转肽酶:{model.GT}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("谷氨酰转肽酶偏低")[0] + "\n";
                    }
                    else if (model.GT > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【谷氨酰转肽酶偏高】\n";
                        strshxqex += $"正常谷氨酰转肽酶范围值：{GetSH("谷氨酰转肽酶", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"谷氨酰转肽酶:{model.GT}>{item["maxvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("谷氨酰转肽酶偏高")[0] + "\n";
                    }
                    continue;
                }
            }

            return strshxqex.TrimEnd(',');
        }

        private string GetSGNexValue(string sex, RecordsAssistCheckModel model) //肾功能异常--3个
        {
            string strshxqex = "";
            string strSCRItem = "血清肌酐";

            if (sex == "1")
            {
                strSCRItem = "血清肌酐男";
            }
            else if (sex == "2")
            {
                strSCRItem = "血清肌酐女";
            }

            if (!string.IsNullOrEmpty(Convert.ToString(model.SCR)))
            {
                DataRow[] dr = dtSH.Select("name='" + strSCRItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血清肌酐'");

                if (dr.Length > 0)
                {
                    if (model.SCR < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清肌酐偏低】\n";
                        strshxqex += $"正常血清肌酐范围值：{GetSH("血清肌酐", "", "")[0] + dr[0]["measurement"].ToString()}\n";
                        strshxqex += $"血清肌酐:{model.SCR}<{dr[0]["minvalue"].ToString() + dr[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清肌酐偏低")[0] + "\n";
                    }
                    else if (model.SCR > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清肌酐偏高】\n";
                        strshxqex += $"正常血清肌酐范围值：{GetSH("血清肌酐", "", "")[0] + dr[0]["measurement"].ToString()}\n";
                        strshxqex += $"血清肌酐:{model.SCR}>{dr[0]["maxvalue"].ToString() + dr[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清肌酐偏高")[0] + "\n";
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (model.SCR < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清肌酐偏低】\n";
                        strshxqex += $"正常血清肌酐范围值：{GetSH("血清肌酐", "", "")[0] + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += $"血清肌酐:{model.SCR}<{dr2[0]["minvalue"].ToString() + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清肌酐偏低")[0] + "\n";
                    }
                    else if (model.SCR > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清肌酐偏高】\n";
                        strshxqex += $"正常血清肌酐范围值：{GetSH("血清肌酐", "", "")[0] + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += $"血清肌酐:{model.SCR}>{dr2[0]["maxvalue"].ToString() + dr2[0]["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清肌酐偏高")[0] + "\n";
                    }
                }
            }

            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(model.BUN)) && item["name"].ToString() == "血尿素氮") //血尿素氮    ------》生化 范围1.7-8.3mmol/L
                {
                    if (Convert.ToDouble(model.BUN) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血尿素氮偏低】\n";
                        strshxqex += $"正常血尿素氮范围值：{GetSH("血尿素氮", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"血尿素氮:{model.BUN}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血尿素氮偏低")[0] + "\n";
                    }
                    else if (Convert.ToDouble(model.BUN) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血尿素氮偏高】\n";
                        strshxqex += $"正常血尿素氮范围值：{GetSH("血尿素氮", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"血尿素氮:{model.BUN}>{item["maxvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血尿素氮偏高")[0] + "\n";
                    }
                    continue;
                }

                if (!string.IsNullOrEmpty(Convert.ToString(model.PC)) && item["name"].ToString() == "血钾浓度") //血钾浓度    ------》生化 范围3.5-5.3mmol/L
                {
                    if (Convert.ToDouble(model.PC) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血钾浓度偏低】\n";
                        strshxqex += $"正常血钾浓度范围值：{GetSH("血钾浓度", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"血钾浓度:{model.PC}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血钾浓度偏低")[0] + "\n";
                    }
                    else if (Convert.ToDouble(model.PC) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血钾浓度偏高】\n";
                        strshxqex += $"正常血钾浓度范围值：{GetSH("血钾浓度", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"血钾浓度:{model.PC}>{item["maxvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血钾浓度偏高")[0] + "\n";
                    }
                    continue;
                }

                if (!string.IsNullOrEmpty(Convert.ToString(model.HYPE)) && item["name"].ToString() == "血钠浓度") //血钠浓度    ------》生化 范围3.5-5.3mmol/L
                {
                    if (Convert.ToDouble(model.HYPE) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血钠浓度偏低】\n";
                        strshxqex += $"正常血钠浓度范围值：{GetSH("血钠浓度", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"血钠浓度:{model.HYPE}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血钠浓度偏低")[0] + "\n";
                    }
                    else if (Convert.ToDouble(model.HYPE) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血钠浓度偏高】\n";
                        strshxqex += $"正常血钠浓度范围值：{GetSH("血钠浓度", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"血钠浓度:{model.HYPE}>{item["maxvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血钠浓度偏高")[0] + "\n";
                    }
                    continue;
                }
                //if (!string.IsNullOrEmpty(model.Other) && item["name"].ToString() == "血清尿酸")
                //{
                //    string regex = @"[^\d.\d]";
                //    string value = Regex.Replace(model.Other, regex, "");

                //    if (Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$"))
                //    {
                //        if (Convert.ToDouble(value) < Convert.ToDouble(item["minvalue"].ToString()))
                //        {
                //            strshxqex = strshxqex + "【血清尿酸偏低】\n";
                //            strshxqex += $"正常血清尿酸范围值：{GetSH("血清尿酸", "", "")[0]}\n";
                //            strshxqex += $"血清尿酸:{model.UA}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                //            strshxqex += ReadMed("血清尿酸偏低")[0] + "\n";
                //        }
                //        else if (Convert.ToDouble(value) > Convert.ToDouble(item["maxvalue"].ToString()))
                //        {
                //            strshxqex = strshxqex + "【血清尿酸偏高】\n";
                //            strshxqex += ReadMed("血清尿酸偏高")[0] + "\n";
                //        }
                //    }
                //    continue;
                //}
                //else
                if (!string.IsNullOrEmpty(Convert.ToString(model.UA)) && item["name"].ToString() == "血清尿酸")
                {
                    if (Convert.ToDouble(model.UA) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清尿酸偏低】\n";
                        strshxqex += $"正常血清尿酸范围值：{GetSH("血清尿酸", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"血清尿酸:{model.UA}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清尿酸偏低")[0] + "\n";
                    }
                    else if (Convert.ToDouble(model.UA) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清尿酸偏高】\n";
                        strshxqex += $"正常血清尿酸范围值：{GetSH("血清尿酸", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"血清尿酸:{model.UA}>{item["maxvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清尿酸偏高")[0] + "\n";
                    }
                    continue;
                }
            }

            return strshxqex.TrimEnd(';');
        }

        private string GetXZex(RecordsAssistCheckModel model) //血脂异常--4个
        {
            string strshxqex = "";

            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(model.TC)) && item["name"].ToString() == "总胆固醇") //总胆固醇    ------》生化 范围3.1-6.1mmol/L
                {
                    if (Convert.ToDouble(model.TC) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【总胆固醇偏低】\n";
                        strshxqex += $"正常总胆固醇范围值：{GetSH("总胆固醇", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"总胆固醇:{model.TC}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("总胆固醇偏低")[0] + "\n";
                    }
                    else if (Convert.ToDouble(model.TC) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【总胆固醇偏高】\n";
                        strshxqex += $"正常总胆固醇范围值：{GetSH("总胆固醇", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"总胆固醇:{model.TC}>{item["maxvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("总胆固醇偏高")[0] + "\n";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(model.TG)) && item["name"].ToString() == "甘油三酯") //甘油三酯    ------》生化 范围0.4-1.81mmol/L
                {
                    if (Convert.ToDouble(model.TG) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【甘油三酯偏低】\n";
                        strshxqex += $"正常甘油三酯范围值：{GetSH("甘油三酯", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"甘油三酯:{model.TG}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("甘油三酯偏低")[0] + "\n";
                    }
                    else if (Convert.ToDouble(model.TG) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【甘油三酯偏高】\n";
                        strshxqex += $"正常甘油三酯范围值：{GetSH("甘油三酯", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"甘油三酯:{model.TG}>{item["maxvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("甘油三酯偏高")[0] + "\n";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(model.LowCho)) && item["name"].ToString() == "血清低密度脂蛋白胆固醇") //血清低密度脂蛋白胆固醇    ------》生化 范围0-3.1mmol/L
                {
                    if (Convert.ToDouble(model.LowCho) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清低密度脂蛋白胆固醇偏低】\n";
                        strshxqex += $"正常血清低密度脂蛋白胆固醇范围值：{GetSH("血清低密度脂蛋白胆固醇", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"血清低密度脂蛋白胆固醇:{model.LowCho}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清低密度脂蛋白胆固醇偏低")[0] + "\n";
                    }
                    else if (Convert.ToDouble(model.LowCho) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清低密度脂蛋白胆固醇偏高】\n";
                        strshxqex += $"正常血清低密度脂蛋白胆固醇范围值：{GetSH("血清低密度脂蛋白胆固醇", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"血清低密度脂蛋白胆固醇:{model.LowCho}>{item["maxvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清低密度脂蛋白胆固醇偏高")[0] + "\n";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(model.HeiCho)) && item["name"].ToString() == "血清高密度脂蛋白胆固醇") //血清高密度脂蛋白胆固醇    ------》生化 范围1.07--1.89mmol/L
                {
                    if (Convert.ToDouble(model.HeiCho) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清高密度脂蛋白胆固醇偏低】\n";
                        strshxqex += $"正常血清高密度脂蛋白胆固醇范围值：{GetSH("血清高密度脂蛋白胆固醇", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"血清高密度脂蛋白胆固醇:{model.HeiCho}<{item["minvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清高密度脂蛋白胆固醇偏低")[0] + "\n";
                    }
                    else if (Convert.ToDouble(model.HeiCho) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "【血清高密度脂蛋白胆固醇偏高】\n";
                        strshxqex += $"正常血清高密度脂蛋白胆固醇范围值：{GetSH("血清高密度脂蛋白胆固醇", "", "")[0] + item["measurement"].ToString()}\n";
                        strshxqex += $"血清高密度脂蛋白胆固醇:{model.HeiCho}>{item["maxvalue"].ToString() + item["measurement"].ToString()}\n";
                        strshxqex += ReadMed("血清高密度脂蛋白胆固醇偏高")[0] + "\n";
                    }
                    continue;
                }
            }

            return strshxqex.TrimEnd(',');
        }
    }
}
