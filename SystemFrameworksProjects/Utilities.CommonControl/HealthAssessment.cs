using System.Data;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using System.ComponentModel;
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using KangShuoTech.DataAccessProjects.BLL;
using System.Text.RegularExpressions;
using System.Linq;

namespace KangShuoTech.Utilities.CommonControl
{
    public class HealthAssessment
    {
        public RecordsBaseInfoModel Model { get; set; }

        private string strex1, strex2, strex3, strex4, strex5, strex6;
        private string area = ConfigHelper.GetSetNode("area");
        private string community = ConfigHelper.GetSetNode("community");
        private TimeParser timeParser = new TimeParser();
        private ConvertDBCAndSBC common = new ConvertDBCAndSBC();
        private bool flagxyH = false, flagxtH = false, flagxzH = false, flagbmiH = false, oldManFlag = false;//血压，血糖，血脂高
        private int yichang = 0;
        private List<string> xmzQT = new List<string>();

        /// <summary>
        /// 取得异常信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// 
        private string GetStrEx(string str, int num)
        {
            if (community == "小孟镇")
            {
                switch (num)
                {
                    case 1:
                        return strex1 = str;
                    case 2:
                        return strex2 = str;
                    case 3:
                        return strex3 = str;
                    default:
                        return strex4 += str;
                }
            }
            else
            {
                if (str.Contains("症状"))
                {
                    return strex4 += str;
                }
                else if ((str.Contains("血压") && !str.Contains("双侧血压压差较大")) || str.Contains("血糖") || str.Contains("体重") || str.Contains("体质指数") ||
                    str.Contains("中心型肥胖") || str.Contains("腹型肥胖"))
                {
                    return strex1 = str;
                }
                else if (str.Contains("肝功能") || str.Contains("肾功能") || str.Contains("血脂"))
                {
                    return strex2 = str;
                }
                else if (str.Contains("心电") || str.Contains("B超"))
                {
                    return strex3 = str;
                }
                else
                {
                    return strex4 += str;
                }
            }
        }

        private void SetStrEx(string pWriteV, string pCheck)
        {
            if (string.IsNullOrEmpty(pWriteV)) return;

            if (community == "小孟镇")
            {
                switch (yichang)
                {
                    case 1:
                        if (strex1.IndexOf(pCheck) == -1 && strex2.IndexOf(pCheck) == -1 && strex3.IndexOf(pCheck) == -1 && strex4.IndexOf(pCheck) == -1)
                            strex1 = CheckStrEx(strex1, pWriteV, pCheck);
                        break;
                    case 2:
                        if (strex1.IndexOf(pCheck) == -1 && strex2.IndexOf(pCheck) == -1 && strex3.IndexOf(pCheck) == -1 && strex4.IndexOf(pCheck) == -1)
                            strex2 = CheckStrEx(strex2, pWriteV, pCheck);
                        break;
                    case 3:
                        if (strex1.IndexOf(pCheck) == -1 && strex2.IndexOf(pCheck) == -1 && strex3.IndexOf(pCheck) == -1 && strex4.IndexOf(pCheck) == -1)
                            strex3 = CheckStrEx(strex3, pWriteV, pCheck);
                        break;
                    case 4:
                        if (strex1.IndexOf(pCheck) == -1 && strex2.IndexOf(pCheck) == -1 && strex3.IndexOf(pCheck) == -1 && strex4.IndexOf(pCheck) == -1)
                            strex4 = CheckStrEx(strex4, pWriteV, pCheck);
                        break;
                    default:
                        int i = yichang % 4;
                        pWriteV = $"   异常{yichang}:" + pWriteV;
                        switch (i)
                        {
                            case 0:
                                if (strex1.IndexOf(pCheck) == -1 && strex2.IndexOf(pCheck) == -1 && strex3.IndexOf(pCheck) == -1 && strex4.IndexOf(pCheck) == -1)
                                    strex4 = CheckStrEx(strex4, pWriteV, pCheck);
                                break;
                            case 1:
                                if (strex1.IndexOf(pCheck) == -1 && strex2.IndexOf(pCheck) == -1 && strex3.IndexOf(pCheck) == -1 && strex4.IndexOf(pCheck) == -1)
                                    strex1 = CheckStrEx(strex1, pWriteV, pCheck);
                                break;
                            case 2:
                                if (strex1.IndexOf(pCheck) == -1 && strex2.IndexOf(pCheck) == -1 && strex3.IndexOf(pCheck) == -1 && strex4.IndexOf(pCheck) == -1)
                                    strex2 = CheckStrEx(strex2, pWriteV, pCheck);
                                break;
                            case 3:
                                if (strex1.IndexOf(pCheck) == -1 && strex2.IndexOf(pCheck) == -1 && strex3.IndexOf(pCheck) == -1 && strex4.IndexOf(pCheck) == -1)
                                    strex3 = CheckStrEx(strex3, pWriteV, pCheck);
                                break;
                        }
                        break;
                }
            }
            else
            {
                if (pWriteV.Contains("症状"))
                {
                    strex4 = CheckStrEx(strex4, pWriteV, pCheck);
                }
                else if ((pWriteV.Contains("血压") && !pWriteV.Contains("双侧血压压差较大")) || pWriteV.Contains("血糖") || pWriteV.Contains("体重") || pWriteV.Contains("体质指数") ||
                    pWriteV.Contains("中心型肥胖") || pWriteV.Contains("腹型肥胖"))
                {
                    strex1 = CheckStrEx(strex1, pWriteV, pCheck);
                }
                else if (pWriteV.Contains("肝功能") || pWriteV.Contains("肾功能") || pWriteV.Contains("血脂"))
                {
                    strex2 = CheckStrEx(strex2, pWriteV, pCheck);
                }
                else if (pWriteV.Contains("心电") || pWriteV.Contains("B超"))
                {
                    strex3 = CheckStrEx(strex3, pWriteV, pCheck);
                }
                else strex4 = CheckStrEx(strex4, pWriteV, pCheck);
            }
        }

        /// <summary>
        /// 检查异常信息的内容是否已包含现有内容
        /// </summary>
        /// <param name="strex"></param>
        /// <param name="pWriteV"></param>
        /// <param name="pCheckV"></param>
        /// <returns></returns>
        private string CheckStrEx(string strex, string pWriteV, string pCheckV)
        {
            if (string.IsNullOrEmpty(pCheckV))
            {
                return strex;
            }
            if (string.IsNullOrEmpty(strex))
            {
                strex += pWriteV;
            }
            else
            {
                if (!strex.Contains(pCheckV))
                {
                    strex += pWriteV;
                }
            }

            if (strex.Length > 200) strex = strex.Substring(0, 200);

            return strex;
        }

        /// <summary>
        /// 健康评价
        /// </summary>
        /// <param name="AssessmentGuides"></param>
        public RecordsAssessmentGuideModel SetHealthEx(RecordsAssessmentGuideModel AssessmentGuides)
        {
            xmzQT = new List<string>();
            strex1 = ""; strex2 = ""; strex3 = ""; strex4 = ""; strex5 = ""; strex6 = "";
            flagxyH = false; flagxtH = false; flagxzH = false; flagbmiH = false; oldManFlag = false;

            BindingList<string> listex = new BindingList<string>();
            var cc = (new string[] { AssessmentGuides.Exception1, AssessmentGuides.Exception2,
                AssessmentGuides.Exception3, AssessmentGuides.Exception4, AssessmentGuides.Exception5, AssessmentGuides.Exception6 });

            #region 重新计算体质指数
            decimal num;
            decimal num2;
            if (RecordsManageMentModel.Height != null && RecordsManageMentModel.Weight != null)
            {
                num = (decimal)RecordsManageMentModel.Height;
                num2 = (decimal)RecordsManageMentModel.Weight;

                if ((num != 0M))
                {
                    decimal num3 = num / 100M;
                    decimal num4 = num3 * num3;
                    RecordsManageMentModel.BMI= num2 / num4;
                    RecordsManageMentModel.BMI = Math.Round((decimal)RecordsManageMentModel.BMI, 2);
                }
            }
            #endregion

            foreach (var item in cc)
            {
                if (!string.IsNullOrEmpty(item)) listex.Add(item);
            }

            switch (listex.Count)
            {
                case 0: break;
                case 1:
                    GetStrEx(listex[0].ToString(), 1);
                    break;
                case 2:
                    GetStrEx(listex[0].ToString(), 1);
                    GetStrEx(listex[1].ToString(), 2);
                    break;
                case 3:
                    GetStrEx(listex[0].ToString(), 1);
                    GetStrEx(listex[1].ToString(), 2);
                    GetStrEx(listex[2].ToString(), 3);
                    break;
                case 4:
                    GetStrEx(listex[0].ToString(), 1);
                    GetStrEx(listex[1].ToString(), 2);
                    GetStrEx(listex[2].ToString(), 3);
                    GetStrEx(listex[3].ToString(), 4);
                    break;
                case 5:
                    GetStrEx(listex[0].ToString(), 1);
                    GetStrEx(listex[1].ToString(), 2);
                    GetStrEx(listex[2].ToString(), 3);
                    GetStrEx(listex[3].ToString(), 4);
                    GetStrEx(listex[4].ToString(), 5);
                    break;
                case 6:
                    GetStrEx(listex[0].ToString(), 1);
                    GetStrEx(listex[1].ToString(), 2);
                    GetStrEx(listex[2].ToString(), 3);
                    GetStrEx(listex[3].ToString(), 4);
                    GetStrEx(listex[4].ToString(), 5);
                    GetStrEx(listex[5].ToString(), 6);
                    break;
                default: break;
            }

            bool flagxt = false, flagxy = false, flagBMI = false, flagxdt = false, flagBC = false, flagNiao = false, flagzl = false,
                flagHCY = false, flagXCG = false, flagGGN = false, flagSGN = false, flagXZ = false, flagSymptom = false,
                flagFat = false, flagBrain = false, flagRenal = false, flagHeart = false,
                flagEye = false, flagNerve = false, flagElse = false, flagzz = false, flagxybj = false, flagView = false, falgjws = false;
            yichang = 0;
            string pWriteV = "", pCheck = "";
            string age = timeParser.GetAge(this.Model.Birthday);

            if (Convert.ToInt32(age) >= 65) { oldManFlag = true; xmzQT.Add("老年人"); }
            else { xmzQT.Add("非老年人"); }

            DataTable dtSH = null;

            if (File.Exists(Application.StartupPath + "\\SHValueRange.xml"))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Application.StartupPath + "\\SHValueRange.xml");
                dtSH = ds.Tables[0];
            }

            #region 血压

            string strRightHeight = "", strRightPre = "", strLeftHeight = "", strLeftPre = "";

            strRightHeight = toString(RecordsManageMentModel.RightHeight);
            strRightPre = toString(RecordsManageMentModel.RightPre);
            strLeftHeight = toString(RecordsManageMentModel.LeftHeight);
            strLeftPre = toString(RecordsManageMentModel.LeftPre);
            pWriteV = "";
            pCheck = "血压";

            int BloodPreMax = 140; // 收缩压正常人群血压范围值为140 / 90
            int BloodPreMin = 90;//
            int BloodHeightMax = 90;// 舒张压正常人群血压范围值90/60
            int BloodHeightMin = 60;

            foreach (DataRow item in dtSH.Rows)
            {
                if (item["name"].ToString() == "收缩压")
                {
                    BloodPreMax = int.Parse(item["maxvalue"].ToString());
                    BloodPreMin = int.Parse(item["minvalue"].ToString());
                }
                else if (item["name"].ToString() == "舒张压")
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
                if (oldManFlag) BloodPreMax = 150;
                else if (!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7"))
                {
                    BloodPreMax = 150;
                }
            }
            else if (area.Equals("济宁"))
            {
                if (!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7"))
                {
                    if (oldManFlag) BloodPreMax = 150;
                }
            }
            else if (area.Equals("平度"))
            {
                BloodPreMax = 150;

                // 未患有高血压，血压值大于等于140/90mmhg要在健康评价栏评价为“血压偏高”
                if (!(!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7")))
                {
                    //有高血压同时有糖尿病的，才是140/90，其他的都是150/90 。 也就是说单纯有高血压和单纯有糖尿病的也是150/90
                    //if (!string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis.Contains("2"))
                    //{
                    BloodPreMax = 140;
                    //}
                }
            }

            // 右侧血压判断
            if (!string.IsNullOrEmpty(strRightHeight) && !string.IsNullOrEmpty(strRightPre))
            {
                if (Convert.ToDouble(strRightHeight) >= BloodPreMax || Convert.ToDouble(strRightPre) >= BloodHeightMax)
                {
                    if (area.Equals("菏泽"))
                    {
                        pWriteV = "血压偏高，血压为" + strRightHeight + "/" + strRightPre + " mmHg;";
                    }
                    else if (area.Equals("威海"))
                    {
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7"))
                        {
                            pWriteV = "血压控制不满意;";
                        }
                        else pWriteV = "血压升高;";
                    }
                    else if (area.Equals("平度"))
                    {
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7"))
                        {
                            pWriteV = "血压偏高;";
                        }
                        else pWriteV = "血压偏高;";
                    }
                    else if (area.Equals("滕州"))
                    {
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7"))
                        {
                            pWriteV = "高血压，血压控制不满意;";
                        }
                        else
                        {
                            pWriteV = "血压偏高，血压为" + strRightHeight + "/" + strRightPre + " mmHg;";
                        }
                    }
                    else if (area.Equals("济宁"))
                    {
                        if (!string.IsNullOrEmpty(strLeftHeight))
                        {
                            if (Convert.ToDouble(strLeftHeight) > Convert.ToDouble(strRightHeight))
                            {
                                if (community == "小孟镇")
                                {
                                    yichang++;
                                    xmzQT.Add("血压高");
                                }
                                pWriteV = "血压高：" + strLeftHeight + "/" + strLeftPre + " mmHg;";
                            }
                            else
                            {
                                if (community == "小孟镇")
                                {
                                    yichang++;
                                    xmzQT.Add("血压高");
                                }
                                pWriteV = "血压高：" + strRightHeight + "/" + strRightPre + " mmHg;";
                            }
                        }
                        else
                        {
                            if (community == "小孟镇")
                            {
                                yichang++;
                                xmzQT.Add("血压高");
                            }
                            pWriteV = "血压高：" + strRightHeight + "/" + strRightPre + " mmHg;";
                        }
                    }
                    else if (community.Equals("聊城东昌府区")) pWriteV = "血压异常;";
                    else if (community.Equals("顾官屯卫生院"))
                    {
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7"))
                        {
                            pWriteV = "血压控制不满意;";
                        }
                        else pWriteV = "血压异常:血压偏高;";
                    }
                    else pWriteV = "血压高;";

                    flagxy = true;
                    flagxyH = true;
                }
                else if (Convert.ToDouble(strRightHeight) < BloodPreMin || Convert.ToDouble(strRightPre) < BloodHeightMin)
                {
                    if (community != "小孟镇")
                    {
                        if (area.Equals("滕州") || area.Equals("乐陵") || area.Equals("菏泽"))
                        {
                            pWriteV = "血压偏低，血压为" + strRightHeight + "/" + strRightPre + " mmHg;";
                        }
                        else if (area.Equals("济宁"))
                        {
                            pWriteV = "血压低:" + strRightHeight + "/" + strRightPre + " mmHg;";
                        }
                        else if (community.Equals("聊城东昌府区")) pWriteV = "血压异常;";
                        else if (community.Equals("顾官屯卫生院")) pWriteV = "血压异常:血压偏低;";
                        else pWriteV = "血压低;";

                        flagxy = true;
                    }
                }
            }

            // 左侧血压判断
            if (!flagxy && !string.IsNullOrEmpty(strLeftHeight) && !string.IsNullOrEmpty(strLeftPre))
            {
                if (Convert.ToDouble(strLeftHeight) >= BloodPreMax || Convert.ToDouble(strLeftPre) >= BloodHeightMax)
                {
                    if (area.Equals("菏泽"))
                    {
                        pWriteV = "血压偏高，血压为" + strLeftHeight + "/" + strLeftPre + " mmHg;";
                    }
                    else if (area.Equals("威海"))
                    {
                        // 慢病人群高血压，显示血压控制不满意
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7"))
                        {
                            pWriteV = "血压控制不满意;";
                        }
                        else pWriteV = "血压升高;";
                    }
                    else if (area.Equals("平度"))
                    {
                        //慢病人群高血压，显示高血压:血压高
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7"))
                        {
                            pWriteV = "血压偏高;";
                        }
                        else pWriteV = "血压偏高;";
                    }
                    else if (area.Equals("滕州"))
                    {
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7"))
                        {
                            pWriteV = "高血压，血压控制不满意;";
                        }
                        else
                        {
                            pWriteV = "血压偏高，血压为" + strRightHeight + "/" + strRightPre + " mmHg;";
                        }
                    }
                    else if (area.Equals("济宁"))
                    {
                        if (community == "小孟镇")
                        {
                            yichang++; xmzQT.Add("血压高");
                        }
                        pWriteV = "血压高:" + strLeftHeight + "/" + strLeftPre + " mmHg;";
                    }
                    else if (community.Equals("聊城东昌府区")) pWriteV = "血压异常;";
                    else if (community.Equals("顾官屯卫生院"))
                    {
                        // 慢病人群高血压，显示血压控制不满意
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7"))
                        {
                            pWriteV = "血压控制不满意;";
                        }
                        else pWriteV = "血压异常:血压偏高;";
                    }
                    else pWriteV = "血压高;";

                    flagxy = true;
                    flagxyH = true;
                }
                else if (Convert.ToDouble(strLeftHeight) < BloodPreMin || Convert.ToDouble(strLeftPre) < BloodHeightMin)
                {
                    if (community != "小孟镇")
                    {
                        if (area.Equals("滕州") || area.Equals("乐陵") || area.Equals("菏泽"))
                        {
                            pWriteV = "血压偏低，血压为" + strLeftHeight + "/" + strLeftPre + " mmHg;";
                        }
                        else if (area.Equals("济宁"))
                        {
                            pWriteV = "血压低:" + strLeftHeight + "/" + strLeftPre + " mmHg;";
                        }
                        else if (community.Equals("聊城东昌府区")) pWriteV = "血压异常;";
                        else if (community.Equals("顾官屯卫生院")) pWriteV = "血压异常:血压偏低;";
                        else pWriteV = "血压低;";

                        flagxy = true;
                    }
                }
            }

            SetStrEx(pWriteV, pCheck);

            #endregion

            #region 禹城、乐陵 双侧血压压差相差＞=20个单位

            if (area.Equals("禹城") || area.Equals("乐陵"))
            {
                pWriteV = "";
                pCheck = "双侧血压压差较大";

                if (!string.IsNullOrEmpty(strRightHeight) && !string.IsNullOrEmpty(strRightPre)
                    && !string.IsNullOrEmpty(strLeftHeight) && !string.IsNullOrEmpty(strLeftPre))
                {
                    if (Math.Abs(Convert.ToDouble(strRightHeight) - Convert.ToDouble(strLeftHeight)) >= 20
                        || Math.Abs(Convert.ToDouble(strRightPre) - Convert.ToDouble(strLeftPre)) >= 20)
                    {
                        flagxybj = true;
                        pWriteV = "双侧血压压差较大;";
                    }
                }

                SetStrEx(pWriteV, pCheck);
            }

            #endregion

            #region 血糖

            if (!string.IsNullOrEmpty(toString(RecordsManageMentModel.FPGL)))
            {
                pWriteV = "";
                pCheck = "血糖";

                if (area.Equals("乐陵"))
                {
                    #region 乐陵

                    double XTmax = 7;
                    double PTmax = 6.1;

                    // 糖尿病患者
                    if (!string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis.Contains("2"))
                    {
                        if (Convert.ToDouble(RecordsManageMentModel.FPGL) >= XTmax)
                        {
                            pWriteV = "血糖高;";
                            flagxt = true;
                            flagxtH = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(RecordsManageMentModel.FPGL) >= PTmax)
                        {
                            pWriteV = "血糖高;";
                            flagxt = true;
                            flagxtH = true;
                        }
                    }
                    #endregion
                }
                else if (area.Equals("平度"))
                {
                    #region 平度

                    double XTmax = 7;
                    double PTmax = 6.1;

                    if (!string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis.Contains("2"))
                    {
                        if (Convert.ToDouble(RecordsManageMentModel.FPGL) >= XTmax)
                        {
                            pWriteV = "血糖偏高;";
                            flagxt = flagxtH = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(RecordsManageMentModel.FPGL) >= PTmax)
                        {
                            pWriteV = "血糖偏高，空腹血糖为" + RecordsManageMentModel.FPGL + " mmol/L;";
                            flagxt = flagxtH = true;
                        }
                    }
                    #endregion
                }
                else if (area.Equals("菏泽"))
                {
                    #region 菏泽

                    double XTmax = 7;
                    double PTmax = 6.1;

                    DataRow[] dr = dtSH.Select("name='空腹血糖'");

                    if (!string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis.Contains("2"))
                    {
                        if (Convert.ToDouble(RecordsManageMentModel.FPGL) >= XTmax)
                        {
                            pWriteV = "空腹血糖高:" + RecordsManageMentModel.FPGL + " mmol/L;";
                            flagxt = flagxtH = true;
                        }
                        else if (dr.Length > 0 && Convert.ToDecimal(RecordsManageMentModel.FPGL) < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                        {
                            pWriteV = "空腹血糖低:" + RecordsManageMentModel.FPGL + " mmol/L;";
                            flagxt = flagxtH = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(RecordsManageMentModel.FPGL) >= PTmax)
                        {
                            pWriteV = "空腹血糖高:" + RecordsManageMentModel.FPGL + " mmol/L;";
                            flagxt = flagxtH = true;
                        }
                        else if (dr.Length > 0 && Convert.ToDecimal(RecordsManageMentModel.FPGL) < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                        {
                            pWriteV = "空腹血糖低:" + RecordsManageMentModel.FPGL + " mmol/L;";
                            flagxt = flagxtH = true;
                        }
                    }
                    #endregion
                }
                else if (area.Equals("济宁") || area.Equals("聊城"))
                {
                    #region 济宁、聊城

                    double XTmax = 7;
                    double PTmax = 6.1;

                    // 糖尿病患者
                    if (!string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis.Contains("2"))
                    {
                        if (Convert.ToDouble(RecordsManageMentModel.FPGL) >= XTmax)
                        {
                            if (community == "小孟镇")
                            {
                                yichang++;
                                xmzQT.Add("血糖高");
                            }

                            pWriteV = "血糖高:" + RecordsManageMentModel.FPGL + " mmol/L";
                            flagxt = flagxtH = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(RecordsManageMentModel.FPGL) >= PTmax)
                        {
                            if (community == "小孟镇")
                            {
                                yichang++;
                                xmzQT.Add("血糖高");
                            }

                            pWriteV = "血糖高:" + RecordsManageMentModel.FPGL + " mmol/L;";
                            flagxt = flagxtH = true;
                        }
                    }
                    #endregion
                }
                else
                {
                    foreach (DataRow item in dtSH.Rows)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.FPGL)) && item["name"].ToString() == "空腹血糖")
                        {
                            if (community.Equals("顾官屯卫生院"))
                            {
                                #region 顾官屯卫生院

                                double XTmax = 6.11;

                                //血糖值超过6.1表示血糖异常
                                if (Convert.ToDouble(RecordsManageMentModel.FPGL) >= XTmax)
                                {
                                    //糖尿病血糖值超过7，显示血糖控制不满意
                                    if (!string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis.Contains("2") && RecordsManageMentModel.FPGL >= 7)
                                    {
                                        pWriteV = "血糖控制不满意;";
                                    }
                                    else
                                    {
                                        pWriteV = "血糖异常:血糖偏高;";
                                    }

                                    flagxt = true;
                                    flagxtH = true;
                                }
                                //小于2.8为低血糖
                                else if (Convert.ToDouble(RecordsManageMentModel.FPGL) < 2.8)
                                {
                                    pWriteV = "血糖异常:血糖偏低;";
                                    flagxt = true;
                                }
                                #endregion
                            }
                            else if (area.Equals("威海"))
                            {
                                #region 威海血糖
                                if (Convert.ToDecimal(RecordsManageMentModel.FPGL) > Convert.ToDecimal(item["maxvalue"].ToString()))
                                {
                                    if (!string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis.Contains("2"))
                                    {
                                        pWriteV = "血糖控制不满意;";
                                    }
                                    else
                                    {
                                        pWriteV = "血糖升高;";
                                    }

                                    flagxt = true;
                                    flagxtH = true;
                                }
                                else if (Convert.ToDecimal(RecordsManageMentModel.FPGL) < Convert.ToDecimal(item["minvalue"].ToString()))
                                {
                                    pWriteV = "血糖低;";
                                    flagxt = true;
                                }
                                #endregion
                            }
                            else if (area.Equals("平度"))
                            {
                                if (Convert.ToDecimal(RecordsManageMentModel.FPGL) < Convert.ToDecimal(item["minvalue"].ToString()))
                                {
                                    pWriteV = "血糖偏低;";
                                    flagxt = true;
                                }
                            }
                            else if (area.Equals("滕州"))
                            {
                                #region 滕州
                                if (Convert.ToDecimal(RecordsManageMentModel.FPGL) > Convert.ToDecimal(item["maxvalue"].ToString()))
                                {
                                    if (!string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis.Contains("2"))
                                    {
                                        pWriteV = "糖尿病，血糖控制不满意;";
                                    }
                                    else
                                    {
                                        pWriteV = "血糖高;";
                                    }
                                    flagxt = true;
                                    flagxtH = true;
                                }
                                else if (Convert.ToDecimal(RecordsManageMentModel.FPGL) < Convert.ToDecimal(item["minvalue"].ToString()))
                                {
                                    pWriteV = "血糖低;";
                                    flagxt = true;
                                }
                                #endregion
                            }
                            else
                            {
                                if (Convert.ToDecimal(RecordsManageMentModel.FPGL) > Convert.ToDecimal(item["maxvalue"].ToString()))
                                {
                                    pWriteV = "血糖高;";
                                    flagxt = flagxtH = true;
                                }
                                else if (Convert.ToDecimal(RecordsManageMentModel.FPGL) < Convert.ToDecimal(item["minvalue"].ToString()))
                                {
                                    pWriteV = "血糖低;";
                                    flagxt = flagxtH = true;
                                }
                            }
                        }
                    }
                }

                SetStrEx(pWriteV, pCheck);
            }

            #endregion

            #region 体质指数

            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.BMI)))
            {
                pWriteV = "";
                pCheck = "体质指数";

                int arm = Convert.ToInt32(24 * RecordsManageMentModel.Height * RecordsManageMentModel.Height / 10000);

                if (community.Equals("聊城东昌府区"))
                {
                    #region 聊城东昌府区

                    if (Convert.ToDouble(RecordsManageMentModel.BMI) < 18)
                    {
                        pWriteV = "偏瘦，体质指数为" + RecordsManageMentModel.BMI + "kg/㎡;";
                        flagBMI = true;
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BMI) >= 24 && Convert.ToDouble(RecordsManageMentModel.BMI) < 28)
                    {
                        pWriteV = "超重，体质指数为" + RecordsManageMentModel.BMI + "kg/㎡;";
                        flagBMI = true;
                        AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 3);
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BMI) >= 28)
                    {
                        pWriteV = "肥胖，体质指数为" + RecordsManageMentModel.BMI + "kg/㎡;";
                        flagBMI = true;
                        AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 3);
                    }

                    #endregion
                }
                else if (area.Equals("滕州"))
                {
                    #region 滕州

                    if (Convert.ToDouble(RecordsManageMentModel.BMI) < 18)
                    {
                        pWriteV = "偏瘦，体质指数为" + RecordsManageMentModel.BMI + "kg/㎡;";
                        flagBMI = true;
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BMI) > 24 && Convert.ToDouble(RecordsManageMentModel.BMI) <= 28)
                    {
                        pWriteV = "超重，体质指数为" + RecordsManageMentModel.BMI + "kg/㎡;";
                        flagBMI = true;
                        flagbmiH = true;

                        // 超重减体重2kg以内
                        if (RecordsManageMentModel.Weight - arm > 2)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 2);
                        }
                        else AssessmentGuides.Arm = arm.ToString("0.00");
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BMI) >= 28)
                    {
                        pWriteV = "肥胖，体质指数为" + RecordsManageMentModel.BMI + "kg/㎡;";
                        flagBMI = true;
                        flagbmiH = true;

                        // 超重减体重2kg以内
                        if (RecordsManageMentModel.Weight - arm > 2)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 2);
                        }
                        else AssessmentGuides.Arm = arm.ToString("0.00");
                    }

                    #endregion
                }
                else if (community.Equals("顾官屯卫生院") || area.Equals("泰安"))
                {
                    #region 顾官屯卫生院、泰安

                    if (Convert.ToDouble(RecordsManageMentModel.BMI) >= 24 && Convert.ToDouble(RecordsManageMentModel.BMI) < 28)
                    {
                        pWriteV = "超重;";
                        pCheck = "超重;";
                        flagBMI = true;
                        flagbmiH = true;

                        // 超重减体重2kg以内
                        if (RecordsManageMentModel.Weight - arm > 2)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 2);
                        }
                        else AssessmentGuides.Arm = arm.ToString("0.00");
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BMI) >= 28)
                    {
                        pWriteV = "肥胖;";
                        pCheck = "肥胖;";
                        flagBMI = true;
                        flagbmiH = true;

                        // 超重减体重2kg以内
                        if (RecordsManageMentModel.Weight - arm > 2)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 2);
                        }
                        else AssessmentGuides.Arm = arm.ToString("0.00");
                    }

                    #endregion
                }
                else if (area.Equals("平度"))
                {
                    #region 平度

                    pCheck = "体质指数";

                    if (Convert.ToDouble(RecordsManageMentModel.BMI) < 18.5)
                    {
                        pWriteV = "体质指数异常:偏瘦;";
                        flagBMI = true;
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BMI) >= 24 && Convert.ToDouble(RecordsManageMentModel.BMI) < 28)
                    {
                        pWriteV = "体质指数异常:超重;";
                        flagBMI = true;
                        flagbmiH = true;

                        // 超重减体重2-3kg
                        if (RecordsManageMentModel.Weight - arm > 3)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 3);
                        }
                        else if (RecordsManageMentModel.Weight - arm < 2)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 2);
                        }
                        else AssessmentGuides.Arm = arm.ToString("0.00");
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BMI) >= 28)
                    {
                        pWriteV = "体质指数异常:肥胖;";
                        flagBMI = true;
                        flagbmiH = true;

                        // 肥胖减体重3-5kg
                        if (RecordsManageMentModel.Weight - arm > 5)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 5);
                        }
                        else if (RecordsManageMentModel.Weight - arm < 3)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 3);
                        }
                        else AssessmentGuides.Arm = arm.ToString("0.00");
                    }

                    #endregion
                }
                else if (area.Equals("菏泽"))
                {
                    #region 菏泽

                    pCheck = "体重";

                    if (Convert.ToDouble(RecordsManageMentModel.BMI) < 18)
                    {
                        pWriteV = "体重偏瘦:BMI=" + RecordsManageMentModel.BMI + "kg/m2;";
                        flagBMI = true;
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BMI) > 24 && Convert.ToDouble(RecordsManageMentModel.BMI) <= 28)
                    {
                        pWriteV = "体重超重:BMI=" + RecordsManageMentModel.BMI + "kg/m2;";
                        flagBMI = true;
                        flagbmiH = true;

                        // 超重减体重2-3kg
                        if (RecordsManageMentModel.Weight - arm > 3)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 3);
                        }
                        else if (RecordsManageMentModel.Weight - arm < 2)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 2);
                        }
                        else AssessmentGuides.Arm = arm.ToString("0.00");
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BMI) > 28)
                    {
                        pWriteV = "体重肥胖:BMI=" + RecordsManageMentModel.BMI + "kg/m2;"; ;
                        flagBMI = true;
                        flagbmiH = true;

                        // 肥胖减体重3-5kg
                        if (RecordsManageMentModel.Weight - arm > 5)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 5);
                        }
                        else if (RecordsManageMentModel.Weight - arm < 3)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 3);
                        }
                        else AssessmentGuides.Arm = arm.ToString("0.00");
                    }

                    #endregion
                }
                else if (area.Equals("济宁"))
                {
                    #region 济宁

                    pCheck = "体重";

                    if (Convert.ToDouble(RecordsManageMentModel.BMI) >= 24 && Convert.ToDouble(RecordsManageMentModel.BMI) < 28)
                    {
                        pWriteV = "体重超重:BMI=" + RecordsManageMentModel.BMI + "kg/m2;";
                        AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 5);

                        if (community == "小孟镇")
                        {
                            yichang++;
                            pCheck = "超重";
                            pWriteV = "超重:" + RecordsManageMentModel.BMI + "kg/m2;";
                        }

                        flagBMI = true;
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BMI) >= 28)
                    {
                        pWriteV = "体重肥胖:BMI=" + RecordsManageMentModel.BMI + "kg/m2;";
                        AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 8);

                        if (community == "小孟镇")
                        {
                            yichang++;
                            pCheck = "肥胖";
                            pWriteV = "肥胖:" + RecordsManageMentModel.BMI + "kg/m2;";
                        }

                        flagBMI = true;
                    }

                    #endregion
                }
                else if (area.Equals("乐陵"))
                {
                    #region 乐陵

                    pCheck = "体重";

                    if (Convert.ToDouble(RecordsManageMentModel.BMI) < 18)
                    {
                        pWriteV = "体重偏瘦;";
                        flagBMI = true;
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BMI) > 24 && Convert.ToDouble(RecordsManageMentModel.BMI) < 28)
                    {
                        pWriteV = "体重超重;";
                        flagBMI = true;
                        flagbmiH = true;

                        // 超重减体重2-3kg
                        if (RecordsManageMentModel.Weight - arm > 3)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 3);
                        }
                        else if (RecordsManageMentModel.Weight - arm < 2)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 2);
                        }
                        else AssessmentGuides.Arm = arm.ToString("0.00");
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BMI) >= 28)
                    {
                        pWriteV = "体重肥胖;";
                        flagBMI = true;
                        flagbmiH = true;

                        // 肥胖减体重3-5kg
                        if (RecordsManageMentModel.Weight - arm > 5)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 5);
                        }
                        else if (RecordsManageMentModel.Weight - arm < 3)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 3);
                        }
                        else AssessmentGuides.Arm = arm.ToString("0.00");
                    }

                    #endregion
                }
                else
                {
                    #region 其他地区

                    pCheck = "体重";

                    if (Convert.ToDouble(RecordsManageMentModel.BMI) < 18)
                    {
                        pWriteV = "体重偏瘦;";
                        flagBMI = true;
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BMI) > 24 && Convert.ToDouble(RecordsManageMentModel.BMI) <= 28)
                    {
                        pWriteV = "体重超重;";
                        flagBMI = true;
                        flagbmiH = true;

                        // 超重减体重2-3kg
                        if (RecordsManageMentModel.Weight - arm > 3)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 3);
                        }
                        else if (RecordsManageMentModel.Weight - arm < 2)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 2);
                        }
                        else AssessmentGuides.Arm = arm.ToString("0.00");
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BMI) > 28)
                    {
                        pWriteV = "体重肥胖;";
                        flagBMI = true;
                        flagbmiH = true;

                        // 肥胖减体重3-5kg
                        if (RecordsManageMentModel.Weight - arm > 5)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 5);
                        }
                        else if (RecordsManageMentModel.Weight - arm < 3)
                        {
                            AssessmentGuides.Arm = Convert.ToString(RecordsManageMentModel.Weight - 3);
                        }
                        else AssessmentGuides.Arm = arm.ToString("0.00");
                    }

                    #endregion
                }

                SetStrEx(pWriteV, pCheck);
            }

            #endregion

            #region 腰围

            if (!string.IsNullOrEmpty(Model.Sex) && !string.IsNullOrEmpty(common.toString(RecordsManageMentModel.Waistline)))
            {
                pWriteV = "";

                if (community.Equals("聊城东昌府区") || area.Equals("济宁"))
                {
                    pCheck = "腹型肥胖";

                    if (Model.Sex == "2" && Convert.ToDouble(RecordsManageMentModel.Waistline) >= 85) //判断女士腰围
                    {
                        if (community == "小孟镇")
                        {
                            yichang++;
                            pWriteV = "(腰围" + RecordsManageMentModel.Waistline + "cm);";
                        }
                        pWriteV = "腹型肥胖,腰围为" + RecordsManageMentModel.Waistline + "cm;";
                        flagFat = true;
                    }
                    else if (Model.Sex == "1" && Convert.ToDouble(RecordsManageMentModel.Waistline) >= 90)//判断男士腰围
                    {
                        if (community == "小孟镇")
                        {
                            yichang++;
                            pWriteV = "(腰围" + RecordsManageMentModel.Waistline + "cm);";
                        }
                        pWriteV = "腹型肥胖,腰围为" + RecordsManageMentModel.Waistline + "cm;";
                        flagFat = true;
                    }
                }
                else if (area.Equals("滕州"))
                {
                    pCheck = "中心型肥胖";

                    if (Model.Sex == "2" && Convert.ToDouble(RecordsManageMentModel.Waistline) >= 85) //判断女士腰围
                    {
                        pWriteV = "中心型肥胖:" + RecordsManageMentModel.Waistline + "cm;";
                        flagFat = true;
                    }
                    else if (Model.Sex == "1" && Convert.ToDouble(RecordsManageMentModel.Waistline) >= 90)//判断男士腰围
                    {
                        pWriteV = "中心型肥胖:" + RecordsManageMentModel.Waistline + "cm;";
                        flagFat = true;
                    }
                }
                else if (area.Equals("菏泽"))
                {
                    #region 菏泽腰围

                    pCheck = "中心型肥胖";

                    if (Model.Sex == "2" && Convert.ToDouble(RecordsManageMentModel.Waistline) >= 85) //判断女士腰围
                    {
                        pWriteV = "中心型肥胖:腰围=" + RecordsManageMentModel.Waistline + "cm;";
                        flagFat = true;
                    }
                    else if (Model.Sex == "1" && Convert.ToDouble(RecordsManageMentModel.Waistline) >= 90)//判断男士腰围
                    {
                        pWriteV = "中心型肥胖:腰围=" + RecordsManageMentModel.Waistline + "cm;";
                        flagFat = true;
                    }

                    #endregion
                }
                else if (area.Equals("泰安"))
                {
                    pCheck = "腹型肥胖";

                    if (Model.Sex == "2" && Convert.ToDouble(RecordsManageMentModel.Waistline) >= 85) //判断女士腰围
                    {
                        pWriteV = "腹型肥胖;";
                        flagFat = true;
                    }
                    else if (Model.Sex == "1" && Convert.ToDouble(RecordsManageMentModel.Waistline) >= 90)//判断男士腰围
                    {
                        pWriteV = "腹型肥胖;";
                        flagFat = true;
                    }
                }
                else
                {
                    pCheck = "中心型肥胖";

                    if (Model.Sex == "2" && Convert.ToDouble(RecordsManageMentModel.Waistline) >= 85) //判断女士腰围
                    {
                        pWriteV = "中心型肥胖;";
                        flagFat = true;
                    }
                    else if (Model.Sex == "1" && Convert.ToDouble(RecordsManageMentModel.Waistline) >= 90)//判断男士腰围
                    {
                        pWriteV = "中心型肥胖;";
                        flagFat = true;
                    }
                }

                if (flagFat) SetStrEx(pWriteV, pCheck);
            }

            #endregion

            #region 心电

            if (!string.IsNullOrEmpty(RecordsManageMentModel.ECG))
            {
                pWriteV = "";
                pCheck = "心电";

                if (RecordsManageMentModel.ECG.Contains("9") || RecordsManageMentModel.ECG.Contains("2") ||
                    RecordsManageMentModel.ECG.Contains("3") || RecordsManageMentModel.ECG.Contains("4") ||
                    RecordsManageMentModel.ECG.Contains("5") || RecordsManageMentModel.ECG.Contains("6") ||
                    RecordsManageMentModel.ECG.Contains("7") || RecordsManageMentModel.ECG.Contains("8"))
                {
                    if (community == "小孟镇")
                    {
                        yichang++;
                        string ecgex = toString(RecordsManageMentModel.ECGEx);
                        if (string.IsNullOrEmpty(ecgex))
                        {
                            pWriteV = $"心电图";
                        }
                        else
                        {
                            pWriteV = $"心电图:{ecgex}";
                        }
                    }
                    else if (area.Equals("齐河") || area.Equals("威海") || community.Equals("聊城东昌府区") || community.Equals("顾官屯卫生院"))
                    {
                        pWriteV = "心电图异常;";
                    }
                    else
                    {
                        pWriteV = "心电图异常:" + toString(RecordsManageMentModel.ECGEx).TrimEnd(';') + ";";
                    }

                    flagxdt = true;
                }

                //strex3 = CheckStrEx(strex3, pWriteV, pCheck);
                SetStrEx(pWriteV, pCheck);
            }

            #endregion

            #region B超

            if (!string.IsNullOrEmpty(toString(RecordsManageMentModel.BCHAO)))
            {
                pWriteV = "";
                pCheck = "B超";
                if (RecordsManageMentModel.BCHAO == "2")
                {
                    if (community == "小孟镇")
                    {
                        yichang++;
                        string bchaoex = toString(RecordsManageMentModel.BCHAOEx);
                        if (string.IsNullOrEmpty(bchaoex))
                        {
                            pWriteV = $"B超";
                        }
                        else
                        {
                            pWriteV = $"B超:{RecordsManageMentModel.BCHAOEx}";
                        }
                    }
                    else
                    if (area.Equals("齐河") || community.Equals("顾官屯卫生院"))
                    {
                        pWriteV = "B超异常;";
                    }
                    else if (area.Equals("泰安"))
                    {
                        pWriteV = "腹部B超异常:" + toString(RecordsManageMentModel.BCHAOEx).TrimEnd(';') + ";";
                    }
                    else
                    {
                        pWriteV = "B超异常:" + toString(RecordsManageMentModel.BCHAOEx).TrimEnd(';') + ";";
                    }
                    flagBC = true;
                }

                //strex3 = CheckStrEx(strex3, pWriteV, pCheck);
                SetStrEx(pWriteV, pCheck);
            }

            #endregion

            if (dtSH.Rows.Count > 0)
            {
                #region 血常规
                string strXCGex = "";
                if (area.Equals("菏泽") || area.Equals("滕州") || area.Equals("济宁"))
                {
                    if (community == "小孟镇")
                    {
                        GetXCGexValueByXMZ(dtSH);
                    }
                    else
                    {
                        strXCGex = this.GetXCGexValue(dtSH);//血常规异常
                    }
                }
                else
                {
                    strXCGex = this.GetXCGex(dtSH);//血常规异常
                }
                if (!string.IsNullOrEmpty(strXCGex))
                {
                    pWriteV = "";
                    pCheck = "血常规异常";
                    if (area.Equals("齐河") || area.Equals("威海") || community.Equals("聊城东昌府区") || area.Equals("泰安"))
                    {
                        pWriteV = "血常规异常;";
                    }
                    else
                    {
                        pWriteV = "血常规异常:" + strXCGex + ";";
                    }

                    flagXCG = true;
                    //strex1 = CheckStrEx(strex1, pWriteV, pCheck);
                    SetStrEx(pWriteV, pCheck);
                }
                #endregion

                #region 肝功能
                string strGGNex = "";//肝功能异常
                if (area.Equals("菏泽") || area.Equals("滕州") || area.Equals("济宁"))
                {
                    if (community == "小孟镇")
                    {
                        GetGGNexValueByXMZ(dtSH);
                    }
                    else
                    {
                        strGGNex = this.GetGGNexValue(dtSH);
                    }
                }
                else
                {
                    strGGNex = this.GetGGNex(dtSH);
                }
                if (!string.IsNullOrEmpty(strGGNex))
                {
                    pWriteV = "";
                    pCheck = "肝功能异常";
                    if (area.Equals("齐河") || area.Equals("威海") || community.Equals("聊城东昌府区"))
                    {
                        pWriteV = "肝功能异常;";
                    }
                    else if (area.Equals("泰安"))
                    {
                        pWriteV = "肝功能异常:" + strGGNex.Replace("↓", "偏低").Replace("↑", "偏高") + ";";
                    }
                    else
                    {
                        pWriteV = "肝功能异常:" + strGGNex + ";";
                    }
                    flagGGN = true;
                    //strex2 = CheckStrEx(strex2, pWriteV, pCheck);
                    SetStrEx(pWriteV, pCheck);
                }
                #endregion

                #region 肾功能
                string strSGNex = "";//肾功能异常
                if (area.Equals("菏泽") || area.Equals("滕州") || area.Equals("济宁"))
                {
                    if (community == "小孟镇")
                    {
                        GetSGNexValueByXMZ(dtSH);
                    }
                    else
                    {
                        strSGNex = this.GetSGNexValue(dtSH);
                    }
                }
                else
                {
                    strSGNex = this.GetSGNex(dtSH);
                }
                if (!string.IsNullOrEmpty(strSGNex))
                {
                    pWriteV = "";
                    pCheck = "肾功能异常";
                    if (area.Equals("齐河") || area.Equals("威海") || community.Equals("聊城东昌府区"))
                    {
                        pWriteV = "肾功能异常;";
                    }
                    else if (area.Equals("泰安"))
                    {
                        pWriteV = "肾功能异常:" + strSGNex.Replace("↓", "偏低").Replace("↑", "偏高") + ";";
                    }
                    else
                    {
                        pWriteV = "肾功能异常:" + strSGNex + ";";
                    }
                    flagSGN = true;
                    //strex2 = CheckStrEx(strex2, pWriteV, pCheck);
                    SetStrEx(pWriteV, pCheck);
                }
                #endregion

                #region 血脂

                string strXZex = "";//血脂异常

                if (area.Equals("菏泽") || area.Equals("滕州") || area.Equals("济宁"))
                {
                    if (community == "小孟镇") GetXZexValueByXMZ(dtSH);
                    else strXZex = this.GetXZexValue(dtSH);
                }
                else strXZex = this.GetXZex(dtSH);

                if (!string.IsNullOrEmpty(strXZex))
                {
                    pWriteV = "";
                    pCheck = "血脂异常";

                    if (area.Equals("齐河") || area.Equals("威海") || community.Equals("聊城东昌府区"))
                    {
                        pWriteV = "血脂异常;";
                    }
                    else if (area.Equals("泰安"))
                    {
                        pWriteV = "血脂异常:" + strXZex.Replace("↓", "偏低").Replace("↑", "偏高") + ";";
                    }
                    else pWriteV = "血脂异常:" + strXZex + ";";

                    flagXZ = true;
                    flagxzH = true;

                    SetStrEx(pWriteV, pCheck);
                }

                #endregion
            }

            #region 尿常规
            string strNiao = community.Equals("顾官屯卫生院") ? this.GetExNiaoGGT() : this.GetExNiao();

            if (!string.IsNullOrEmpty(strNiao))
            {
                pWriteV = "";
                pCheck = "尿常规异常";
                if (area.Equals("威海") || community.Equals("聊城东昌府区") || area.Equals("泰安"))
                {
                    pWriteV = "尿常规异常;";
                }
                else
                {
                    if (area.Equals("济宁"))
                    {
                        if (community == "小孟镇")
                        {
                            yichang++;
                            pWriteV = "尿常规:" + GetExNiaoPlus(strNiao) + ";";
                        }
                        else
                        {
                            pWriteV = "尿常规异常:" + GetExNiaoPlus(strNiao) + ";";
                        }
                    }
                    else
                    {
                        pWriteV = "尿常规异常:" + strNiao + ";";
                    }
                }

                flagNiao = true;
                //strex4 = CheckStrEx(strex4, pWriteV, pCheck);
                SetStrEx(pWriteV, pCheck);
            }
            #endregion

            #region 自理能力

            string strSelf = this.GetSelf();

            if (!string.IsNullOrEmpty(strSelf))
            {
                pWriteV = "自理能力:" + strSelf + ";";
                pCheck = "自理能力";

                if (community == "小孟镇")
                {
                    yichang++;
                    pWriteV = "老年人生活自理能力自我评估(" + strSelf + ");";
                }

                flagzl = true;
                SetStrEx(pWriteV, pCheck);
            }

            #endregion

            #region 症状

            if (area.Equals("菏泽") || area.Equals("乐陵") || area.Equals("济宁"))
            {
                string strSymptom = this.GetSymptom();

                if (!string.IsNullOrEmpty(strSymptom))
                {
                    pWriteV = "症状:" + strSymptom + ";";
                    pCheck = "症状";

                    if (community == "小孟镇") yichang++;

                    flagzz = true;
                    //strex4 = CheckStrEx(strex4, pWriteV, pCheck);
                    SetStrEx(pWriteV, pCheck);
                }
            }

            #endregion

            #region 视力

            if (area.Equals("济宁"))
            {
                int sl = 5;
                if (community == "小孟镇") sl = 4;

                if (!string.IsNullOrEmpty(RecordsManageMentModel.LeftView.ToString()) && RecordsManageMentModel.LeftView < sl)
                {
                    pWriteV = $"视力差：左眼视力:{RecordsManageMentModel.LeftView};";
                    pCheck = "视力";
                    flagView = true;
                }

                if (!string.IsNullOrEmpty(RecordsManageMentModel.RightView.ToString()) && RecordsManageMentModel.RightView < sl)
                {
                    if (flagView)
                    {
                        pWriteV = pWriteV.Replace(";", "");
                        pWriteV += $"、右眼视力:{RecordsManageMentModel.RightView};";
                    }
                    else pWriteV = $"视力差：右眼视力:{RecordsManageMentModel.RightView};";

                    pCheck = "视力";
                    flagView = true;
                }

                if (flagView)
                {
                    if (community == "小孟镇") { yichang++; pWriteV = "视力低"; }
                    SetStrEx(pWriteV, pCheck);
                }
            }

            #endregion  

            #region 健康问题-其他系统疾病

            if (area.Equals("禹城"))
            {
                if (!string.IsNullOrEmpty(RecordsManageMentModel.ElseOther) && RecordsManageMentModel.ElseOther.IndexOf("精神") > -1)
                {
                    pWriteV = "精神异常;";
                    pCheck = "精神";
                    SetStrEx(pWriteV, pCheck);
                    flagElse = true;
                }
            }

            #endregion

            #region 新加疾病

            if (area.Equals("禹城"))
            {
                List<RecordsIllnessHistoryInfoModel> IllnessHistoryInfoModelList = new RecordsIllnessHistoryInfoBLL().GetModelList(" IDCardNo='" + Model.IDCardNo + "' AND DiagnoseTime LIKE '" + (DateTime.Now.Year - 1) + "%'");

                if (IllnessHistoryInfoModelList != null && IllnessHistoryInfoModelList.Count > 0)
                {
                    pWriteV = "";
                    pCheck = DateTime.Now.Date.Year - 1 + "年:";

                    foreach (RecordsIllnessHistoryInfoModel mm in IllnessHistoryInfoModelList)
                    {
                        switch (mm.IllnessName)
                        {
                            case "2":
                                pWriteV += "高血压;";
                                break;
                            case "3":
                                pWriteV += "糖尿病;";
                                break;
                            case "4":
                                pWriteV += "冠心病;";
                                break;
                            case "5":
                                pWriteV += "慢性阻塞性肺疾病;";
                                break;
                            case "6":
                                if (string.IsNullOrEmpty(mm.Therioma)) pWriteV += "恶性肿瘤;";
                                else pWriteV += "恶性肿瘤(" + mm.Therioma + ");";
                                break;
                            case "7":
                                pWriteV += "脑卒中;";
                                break;
                            case "8":
                                pWriteV += "重性精神疾病;";
                                break;
                            case "9":
                                pWriteV += "结核病;";
                                break;
                            case "10":
                                pWriteV += "肝炎;";
                                break;
                            case "11":
                                pWriteV += "其他法定传染病;";
                                break;
                            case "12":
                                if (string.IsNullOrEmpty(mm.JobIllness)) pWriteV += "职业病;";
                                else pWriteV += "职业病(" + mm.JobIllness + ");";
                                break;
                            case "13":
                                if (string.IsNullOrEmpty(mm.IllnessOther)) pWriteV += "其他;";
                                else pWriteV += "其他(" + mm.IllnessOther + ");";
                                break;
                        }
                    }

                    if (!string.IsNullOrEmpty(pWriteV)) pWriteV = pCheck + pWriteV;

                    SetStrEx(pWriteV, pCheck);
                    falgjws = true;
                }
            }

            #endregion

            #region 济宁-小孟镇

            if (community == "小孟镇")
            {
                double d = 0d;
                if (double.TryParse(RecordsManageMentModel.HeartRate, out d))
                {
                    if (d > 100)
                    {
                        yichang++;
                        SetStrEx($"心率过速:{RecordsManageMentModel.HeartRate}次/分钟", "心率");
                        xmzQT.Add("转诊");
                    }
                    else if (d < 40)
                    {
                        yichang++;
                        SetStrEx($"心率过慢:{RecordsManageMentModel.HeartRate}次/分钟", "心率");
                        xmzQT.Add("转诊");
                    }
                }
                if (RecordsManageMentModel.Noise == "2")
                {
                    yichang++;
                    SetStrEx($"心脏听诊:杂音", "心脏听诊");
                    xmzQT.Add("转诊");
                }
                if (RecordsManageMentModel.Edema == "2")
                {
                    yichang++;
                    SetStrEx($"下肢水肿:单侧", "下肢水肿");
                    xmzQT.Add("转诊");
                }
                else if (RecordsManageMentModel.Edema == "3")
                {
                    yichang++;
                    SetStrEx($"下肢水肿:双侧不对称", "下肢水肿");
                    xmzQT.Add("转诊");
                }
                else if (RecordsManageMentModel.Edema == "4")
                {
                    yichang++;
                    SetStrEx($"下肢水肿:双侧对称", "下肢水肿");
                    xmzQT.Add("转诊");
                }
                if (RecordsManageMentModel.Listen == "2")
                {
                    yichang++;
                    SetStrEx($"听力:听不清或听不见", "听力");
                    xmzQT.Add("转诊");
                }
                if (RecordsManageMentModel.SportFunction == "2")
                {
                    yichang++;
                    SetStrEx($"运动功能:无法独立完成其中任何一个动作", "运动功能");
                    xmzQT.Add("转诊");
                }
            }

            #endregion

            if (flagBMI || flagxdt || flagxt || flagxy || flagBC || flagXCG || flagNiao || flagXCG || flagGGN || flagSGN || flagXZ || flagzl ||
                flagFat || flagSymptom || flagBrain || flagRenal || flagHeart || flagEye || flagNerve || flagElse || flagHCY || flagzz || flagxybj || flagView || falgjws)
            {
                AssessmentGuides.IsNormal = "2";
            }

            BindingList<string> listexlst = new BindingList<string>();
            var cclst = (new string[] { strex1, strex2, strex3, strex4, strex5, strex6 });

            foreach (var item in cclst)
            {
                if (!string.IsNullOrEmpty(item)) listexlst.Add(item);
            }

            switch (listexlst.Count)
            {
                case 0: break;
                case 1:
                    AssessmentGuides.Exception1 = listexlst[0].ToString();
                    AssessmentGuides.Exception2 = "";
                    AssessmentGuides.Exception3 = "";
                    AssessmentGuides.Exception4 = "";
                    AssessmentGuides.IsNormal = "2";
                    break;
                case 2:
                    AssessmentGuides.Exception1 = listexlst[0].ToString();
                    AssessmentGuides.Exception2 = listexlst[1].ToString();
                    AssessmentGuides.Exception3 = "";
                    AssessmentGuides.Exception4 = "";
                    AssessmentGuides.IsNormal = "2";
                    break;
                case 3:
                    AssessmentGuides.Exception1 = listexlst[0].ToString();
                    AssessmentGuides.Exception2 = listexlst[1].ToString();
                    AssessmentGuides.Exception3 = listexlst[2].ToString();
                    AssessmentGuides.Exception4 = "";
                    AssessmentGuides.IsNormal = "2";
                    break;
                case 4:
                    AssessmentGuides.Exception1 = listexlst[0].ToString();
                    AssessmentGuides.Exception2 = listexlst[1].ToString();
                    AssessmentGuides.Exception3 = listexlst[2].ToString();
                    AssessmentGuides.Exception4 = listexlst[3].ToString();
                    AssessmentGuides.IsNormal = "2";
                    break;
                case 5:
                    AssessmentGuides.Exception1 = listexlst[0].ToString();
                    AssessmentGuides.Exception2 = listexlst[1].ToString();
                    AssessmentGuides.Exception3 = listexlst[2].ToString();
                    AssessmentGuides.Exception4 = listexlst[3].ToString();
                    AssessmentGuides.Exception5 = listexlst[4].ToString();
                    AssessmentGuides.IsNormal = "2";
                    break;
                case 6:
                    AssessmentGuides.Exception1 = listexlst[0].ToString();
                    AssessmentGuides.Exception2 = listexlst[1].ToString();
                    AssessmentGuides.Exception3 = listexlst[2].ToString();
                    AssessmentGuides.Exception4 = listexlst[3].ToString();
                    AssessmentGuides.Exception5 = listexlst[4].ToString();
                    AssessmentGuides.Exception6 = listexlst[5].ToString();
                    AssessmentGuides.IsNormal = "2";
                    break;
                default: break;
            }

            return AssessmentGuides;
        }

        /// <summary>
        /// 危险因素控制
        /// </summary>
        public RecordsAssessmentGuideModel SetDangerous(RecordsAssessmentGuideModel AssessmentGuides)
        {
            #region 健康指导
            if (area.Equals("威海"))
            {
                if (toString(AssessmentGuides.IsNormal) == "2")
                {
                    AssessmentGuides.HealthGuide = "2," + AssessmentGuides.HealthGuide;
                }
            }
            else
            {
                AssessmentGuides.HealthGuide = "2," + AssessmentGuides.HealthGuide;
            }

            string strOther = "";
            switch (area)
            {
                case "乐陵":
                case "禹城":
                case "威海":
                    #region 禹城、威海

                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.HeartOther) ? RecordsManageMentModel.HeartOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.RenalOther) ? RecordsManageMentModel.RenalOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.BrainOther) ? RecordsManageMentModel.BrainOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.EyeOther) ? RecordsManageMentModel.EyeOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.NerveOther) ? RecordsManageMentModel.NerveOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.ElseOther) ? RecordsManageMentModel.ElseOther : "";
                    // 现存健康问题有高血压、糖尿病、冠心病、缺血性卒中、重性精神疾病时则纳入慢性病管理
                    if ((!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7") ||
                        !string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis.Contains("2") ||
                        !string.IsNullOrEmpty(RecordsManageMentModel.BrainDis) && RecordsManageMentModel.BrainDis.Contains("2") ||
                         strOther.Contains("冠心病") || strOther.Contains("精神") || strOther.Contains("肺结核") ||
                         strOther.Contains("脑卒中")))
                    {
                        if (!common.toString(AssessmentGuides.HealthGuide).Contains("1"))
                        {
                            AssessmentGuides.HealthGuide += ",1";
                        }
                        if (!common.toString(AssessmentGuides.HealthGuide).Contains("4"))
                        {
                            AssessmentGuides.HealthGuide += ",4";
                        }
                    }
                    break;
                #endregion
                case "平度":
                    #region 平度
                    // 现存健康问题有高血压或糖尿病,心血管疾病其他中包含冠心病时则纳入慢性病管理
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.HeartOther) ? RecordsManageMentModel.HeartOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.RenalOther) ? RecordsManageMentModel.RenalOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.BrainOther) ? RecordsManageMentModel.BrainOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.EyeOther) ? RecordsManageMentModel.EyeOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.NerveOther) ? RecordsManageMentModel.NerveOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.ElseOther) ? RecordsManageMentModel.ElseOther : "";
                    if ((!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7") ||
                       !string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis.Contains("2") ||
                       !string.IsNullOrEmpty(RecordsManageMentModel.BrainDis) && RecordsManageMentModel.BrainDis.Contains("2") ||
                        strOther.Contains("冠心病") || strOther.Contains("精神") ||
                        strOther.Contains("脑卒中")))
                    {
                        if (!common.toString(AssessmentGuides.HealthGuide).Contains("1"))
                        {
                            AssessmentGuides.HealthGuide += ",1";
                        }
                    }
                    if (!string.IsNullOrEmpty(RecordsManageMentModel.FPGL.ToString()))
                    {
                        if (Convert.ToDecimal(RecordsManageMentModel.FPGL) >= 16.7m)
                        {
                            if (!common.toString(AssessmentGuides.HealthGuide).Contains("1"))
                            {
                                AssessmentGuides.HealthGuide += ",3";
                            }
                        }
                    }
                    break;
                #endregion
                case "菏泽":
                    #region 菏泽
                    AssessmentGuides.HealthGuide = "2,4";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.HeartOther) ? RecordsManageMentModel.HeartOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.RenalOther) ? RecordsManageMentModel.RenalOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.BrainOther) ? RecordsManageMentModel.BrainOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.EyeOther) ? RecordsManageMentModel.EyeOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.NerveOther) ? RecordsManageMentModel.NerveOther : "";
                    strOther += !string.IsNullOrEmpty(RecordsManageMentModel.ElseOther) ? RecordsManageMentModel.ElseOther : "";
                    // 现存健康问题有高血压、糖尿病、冠心病、缺血性卒中、重性精神疾病时则纳入慢性病管理
                    if ((!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7") ||
                        !string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis.Contains("2") ||
                        !string.IsNullOrEmpty(RecordsManageMentModel.BrainDis) && RecordsManageMentModel.BrainDis.Contains("2") ||
                         strOther.Contains("冠心病") || strOther.Contains("重性精神疾病") || strOther.Contains("肺结核") ||
                         strOther.Contains("脑卒中")))
                    {
                        if (!common.toString(AssessmentGuides.HealthGuide).Contains("1"))
                        {
                            AssessmentGuides.HealthGuide += ",1";
                        }
                    }
                    #endregion
                    break;
                case "济宁":
                    #region 济宁
                    if ((
                        (!string.IsNullOrEmpty(RecordsManageMentModel.BrainDis) && RecordsManageMentModel.BrainDis != "1")
                        || (!string.IsNullOrEmpty(RecordsManageMentModel.RenalDis) && RecordsManageMentModel.RenalDis != "1")
                        || (!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis != "1")
                        || (!string.IsNullOrEmpty(RecordsManageMentModel.EyeDis) && RecordsManageMentModel.EyeDis != "1")
                        || (!string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis != "1")
                        || (!string.IsNullOrEmpty(RecordsManageMentModel.NerveDis) && RecordsManageMentModel.NerveDis != "1")
                        ))
                    {
                        if (!common.toString(AssessmentGuides.HealthGuide).Contains("1"))
                        {
                            AssessmentGuides.HealthGuide += "1,";
                        }
                    }
                    //如果这个人在症状有症状或者B超中出现肝囊肿、肾囊肿、多发性结石、肝区阴影或者心电图出现T波倒置、陈旧性或心肌梗塞需要勾选建议转诊
                    if (!string.IsNullOrEmpty(RecordsManageMentModel.Symptom))
                    {
                        if (RecordsManageMentModel.Symptom != "1")
                        {
                            if (!common.toString(AssessmentGuides.HealthGuide).Contains("3"))
                            {
                                AssessmentGuides.HealthGuide += "3,";
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(RecordsManageMentModel.BCHAOEx))
                    {
                        if (RecordsManageMentModel.BCHAOEx.IndexOf("肝囊肿") > -1 || RecordsManageMentModel.BCHAOEx.IndexOf("肾囊肿") > -1 || RecordsManageMentModel.BCHAOEx.IndexOf("多发性结石") > -1 || RecordsManageMentModel.BCHAOEx.IndexOf("肝区阴影") > -1)
                        {
                            if (!common.toString(AssessmentGuides.HealthGuide).Contains("3"))
                            {
                                AssessmentGuides.HealthGuide += "3,";
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(RecordsManageMentModel.ECGEx))
                    {
                        if (RecordsManageMentModel.ECGEx.IndexOf("T波倒置") > -1 || RecordsManageMentModel.ECGEx.IndexOf("陈旧性") > -1 || RecordsManageMentModel.ECGEx.IndexOf("心肌梗塞") > -1)
                        {
                            if (!common.toString(AssessmentGuides.HealthGuide).Contains("3"))
                            {
                                AssessmentGuides.HealthGuide += "3,";
                            }
                        }
                    }
                    if (community == "小孟镇")
                    {
                        if (xmzQT.Contains("转诊"))
                        {
                            if (!common.toString(AssessmentGuides.HealthGuide).Contains("3"))
                            {
                                AssessmentGuides.HealthGuide += "3,";
                            }
                        }
                    }
                    #endregion
                    break;
                default:
                    // 现存健康问题有高血压或糖尿病时则纳入慢性病管理
                    if ((!string.IsNullOrEmpty(RecordsManageMentModel.HeartDis) && RecordsManageMentModel.HeartDis.Contains("7") ||
                        !string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis.Contains("2")) &&
                        !common.toString(AssessmentGuides.HealthGuide).Contains("1"))
                    {
                        AssessmentGuides.HealthGuide += ",1";
                    }

                    break;
            }
            // 左右血压都判断 建议转诊
            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.LeftHeight)) &&
                !string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.LeftPre)))
            {
                if (!string.IsNullOrEmpty(AssessmentGuides.HealthGuide))
                {
                    if (!AssessmentGuides.HealthGuide.Contains("3") &&
                        ((Convert.ToDouble(RecordsManageMentModel.LeftHeight) >= 180 ||
                        Convert.ToDouble(RecordsManageMentModel.LeftPre) >= 110)))
                    {
                        AssessmentGuides.HealthGuide += ",3";
                    }
                    if (area.Equals("平度"))
                    {
                        if (!AssessmentGuides.HealthGuide.Contains("3") && ((Convert.ToDouble(RecordsManageMentModel.LeftHeight) <= 90 ||
                                              Convert.ToDouble(RecordsManageMentModel.LeftPre) <= 60)))
                        {
                            AssessmentGuides.HealthGuide += ",3";
                        }
                    }
                }
                else if (string.IsNullOrEmpty(AssessmentGuides.HealthGuide))
                {
                    if (Convert.ToDouble(RecordsManageMentModel.LeftHeight) >= 180 ||
                        Convert.ToDouble(RecordsManageMentModel.LeftPre) >= 110)
                    {
                        AssessmentGuides.HealthGuide = "3";
                    }
                    if (area.Equals("平度"))
                    {
                        if (Convert.ToDouble(RecordsManageMentModel.LeftHeight) <= 90 ||
                       Convert.ToDouble(RecordsManageMentModel.LeftPre) <= 60)
                        {
                            AssessmentGuides.HealthGuide = "3";
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.RightHeight)) &&
                !string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.RightPre)))
            {
                if (!string.IsNullOrEmpty(AssessmentGuides.HealthGuide))
                {
                    if (!AssessmentGuides.HealthGuide.Contains("3") &&
                        ((Convert.ToDouble(RecordsManageMentModel.RightHeight) >= 180 ||
                        Convert.ToDouble(RecordsManageMentModel.RightPre) >= 110)))
                    {
                        AssessmentGuides.HealthGuide += ",3";
                    }
                    if (area.Equals("平度"))
                    {
                        if (!AssessmentGuides.HealthGuide.Contains("3") &&
                       ((Convert.ToDouble(RecordsManageMentModel.RightHeight) <= 90 ||
                       Convert.ToDouble(RecordsManageMentModel.RightPre) <= 60)))
                        {
                            AssessmentGuides.HealthGuide += ",3";
                        }
                    }
                }
                else if (string.IsNullOrEmpty(AssessmentGuides.HealthGuide))
                {
                    if (Convert.ToDouble(RecordsManageMentModel.RightHeight) >= 180 ||
                        Convert.ToDouble(RecordsManageMentModel.RightPre) >= 110)
                    {
                        AssessmentGuides.HealthGuide = "3";
                    }
                    if (area.Equals("平度"))
                    {
                        if (Convert.ToDouble(RecordsManageMentModel.RightHeight) <= 90 ||
                       Convert.ToDouble(RecordsManageMentModel.RightPre) <= 60)
                        {
                            AssessmentGuides.HealthGuide = "3";
                        }
                    }
                }
            }
            // 血糖 建议转诊
            double maxFPGL = 16.7;
            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.FPGL)))
            {
                if (area.Equals("威海"))//威海血糖建议转诊的最高值为17.9
                {
                    maxFPGL = 17.9;
                }
                else if (area.Equals("平度"))
                {
                    maxFPGL = 17.6;
                }
                if (!string.IsNullOrEmpty(AssessmentGuides.HealthGuide) && !AssessmentGuides.HealthGuide.Contains("3"))
                {
                    if (Convert.ToDouble(RecordsManageMentModel.FPGL) >= maxFPGL)
                    {
                        AssessmentGuides.HealthGuide += ",3";
                    }
                }
                else if (string.IsNullOrEmpty(AssessmentGuides.HealthGuide))
                {
                    if (Convert.ToDouble(RecordsManageMentModel.FPGL) >= maxFPGL)
                    {
                        AssessmentGuides.HealthGuide = "3";
                    }
                }
                #region 菏泽 威海 血糖小于等于3.9mmol/L也必须选择建议转诊
                if (area.Equals("菏泽") || area.Equals("威海") || area.Equals("平度"))
                {
                    if (!string.IsNullOrEmpty(AssessmentGuides.HealthGuide) && !AssessmentGuides.HealthGuide.Contains("3"))
                    {
                        if (Convert.ToDouble(RecordsManageMentModel.FPGL) <= 3.9)
                        {
                            AssessmentGuides.HealthGuide += ",3";
                        }
                    }
                    else if (string.IsNullOrEmpty(AssessmentGuides.HealthGuide))
                    {
                        if (Convert.ToDouble(RecordsManageMentModel.FPGL) <= 3.9)
                        {
                            AssessmentGuides.HealthGuide = "3";
                        }
                    }
                }
                #endregion
            }

            #endregion

            #region 危险因素控制
            if (string.IsNullOrEmpty(Convert.ToString(AssessmentGuides.DangerControl)))
            {
                switch (this.community)
                {
                    case "顾官屯卫生院":
                        #region
                        AssessmentGuides.DangerControl = "6,7,";
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.DietaryHabit)) //饮食习惯含有2，4，5，6其中一种，饮食勾选
                        {
                            if (common.toString(RecordsManageMentModel.DietaryHabit).Contains("2") ||
                                common.toString(RecordsManageMentModel.DietaryHabit).Contains("4") ||
                                common.toString(RecordsManageMentModel.DietaryHabit).Contains("5") ||
                                common.toString(RecordsManageMentModel.DietaryHabit).Contains("6"))
                            {
                                if (!AssessmentGuides.DangerControl.Contains("3"))
                                {
                                    AssessmentGuides.DangerControl += "3,";
                                }
                            }
                        }
                        //每天锻炼30分钟以上，后面就不勾选锻炼。偶尔或者每周一次，后面勾选锻炼
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.ExerciseRate) && (common.toString(RecordsManageMentModel.ExerciseRate) != "1" ||
                            (common.toString(RecordsManageMentModel.ExerciseRate) == "1" && (string.IsNullOrEmpty(RecordsManageMentModel.ExerciseTimes) || Convert.ToDouble(RecordsManageMentModel.ExerciseTimes) < 30))))
                        {
                            if (!AssessmentGuides.DangerControl.Contains("4"))
                            {
                                AssessmentGuides.DangerControl += "4,";
                            }
                        }
                        #endregion
                        break;
                    case "聊城东昌府区":
                        AssessmentGuides.DangerControl = "";
                        break;
                    default:
                        if (area.Equals("平度"))
                        {
                            if (oldManFlag)
                            {
                                AssessmentGuides.DangerControl = "6,7,";
                                break;
                            }
                        }
                        AssessmentGuides.DangerControl = "3,4,6,7,";
                        break;
                }

                #region 禹城、乐陵
                if (area.Equals("禹城") || area.Equals("乐陵"))
                {
                    AssessmentGuides.DangerControl = "6,7,";
                    if (!string.IsNullOrEmpty(AssessmentGuides.Other))
                    {
                        AssessmentGuides.Other = AssessmentGuides.Other.Replace("低盐低脂", "").Replace("低糖", "").Replace("饮食，预防骨质疏松，防跌倒", "");
                    }
                    if (!string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis.Contains("2"))//糖尿病患者
                    {
                        AssessmentGuides.Other += "低盐低脂低糖饮食，预防骨质疏松，防跌倒。";
                    }
                    else
                    {
                        AssessmentGuides.Other += "低盐低脂饮食，预防骨质疏松，防跌倒。";
                    }
                    if (!string.IsNullOrEmpty(RecordsManageMentModel.DietaryHabit)) //饮食习惯含有2，4，5，6其中一种，饮食勾选
                    {
                        if (common.toString(RecordsManageMentModel.DietaryHabit).Contains("2") ||
                            common.toString(RecordsManageMentModel.DietaryHabit).Contains("4") ||
                            common.toString(RecordsManageMentModel.DietaryHabit).Contains("5") ||
                            common.toString(RecordsManageMentModel.DietaryHabit).Contains("6"))
                        {
                            if (!AssessmentGuides.DangerControl.Contains("3"))
                            {
                                AssessmentGuides.DangerControl += "3,";
                            }
                        }
                    }

                    //锻炼频率非每天时，勾选锻炼
                    if (!string.IsNullOrEmpty(RecordsManageMentModel.ExerciseRate) && common.toString(RecordsManageMentModel.ExerciseRate) != "1")
                    {
                        if (!AssessmentGuides.DangerControl.Contains("4"))
                        {
                            AssessmentGuides.DangerControl += "4,";
                        }
                    }
                }
                #endregion
                #region 聊城东昌府区
                else if (community.Equals("聊城东昌府区"))
                {
                    //饮食习惯中包含荤食为主、嗜油、健康问题中为糖尿病患者，勾选饮食
                    if (common.toString(RecordsManageMentModel.DietaryHabit).Contains("2")
                        || common.toString(RecordsManageMentModel.DietaryHabit).Contains("5")
                        || common.toString(RecordsManageMentModel.ElseDis).Contains("2")
                        || common.toString(RecordsManageMentModel.HeartDis).Contains("7")
                        )
                    {
                        if (!common.toString(AssessmentGuides.DangerControl).Contains("3"))
                        {
                            AssessmentGuides.DangerControl += "3,";
                        }
                    }
                    if (oldManFlag)//65岁老年人
                    {
                        if (!common.toString(AssessmentGuides.Other).Contains("预防骨质疏松，防跌倒"))
                        {
                            AssessmentGuides.Other += "预防骨质疏松，防跌倒!";
                            if (!common.toString(AssessmentGuides.DangerControl).Contains("7"))
                            {
                                AssessmentGuides.DangerControl += "7,";
                            }
                        }
                    }
                }
                #endregion
                #region 威海
                else if (area.Equals("威海"))
                {
                    #region 威海饮食与锻炼的勾选情况
                    AssessmentGuides.DangerControl = "6,7,";
                    if (!string.IsNullOrEmpty(RecordsManageMentModel.DietaryHabit)) //饮食习惯含有2，4，5，6其中一种，饮食勾选
                    {
                        if (common.toString(RecordsManageMentModel.DietaryHabit) != "1")
                        {
                            if (!AssessmentGuides.DangerControl.Contains("3"))
                            {
                                AssessmentGuides.DangerControl += "3,";
                            }
                        }
                    }
                    //每天锻炼60分钟以上，后面就不勾选锻炼。偶尔或者每周一次，后面勾选锻炼
                    if (!string.IsNullOrEmpty(RecordsManageMentModel.ExerciseRate) && (common.toString(RecordsManageMentModel.ExerciseRate) != "1" ||
                        (common.toString(RecordsManageMentModel.ExerciseRate) == "1" && (string.IsNullOrEmpty(RecordsManageMentModel.ExerciseTimes) || Convert.ToDouble(RecordsManageMentModel.ExerciseTimes) < 60))))
                    {
                        if (!AssessmentGuides.DangerControl.Contains("4"))
                        {
                            AssessmentGuides.DangerControl += "4,";
                        }
                    }
                    #endregion
                    string strOthers = "";
                    if (!string.IsNullOrEmpty(AssessmentGuides.Other))
                    {
                        AssessmentGuides.Other = AssessmentGuides.Other.Replace("低脂", "").Replace("低糖", "").Replace("低盐饮食,每天＜6克盐，防骨质疏松，防跌倒。", "");//建议清空，重新生成
                    }
                    if (common.toString(RecordsManageMentModel.ElseDis).Contains("2"))
                    {
                        strOthers += "低糖";
                    }
                    if (flagxzH || flagbmiH)//血脂异常
                    {
                        strOthers += "低脂";
                    }
                    if (!string.IsNullOrEmpty(strOthers))
                    {
                        AssessmentGuides.Other += strOthers + "低盐饮食,每天＜6克盐，防骨质疏松，防跌倒。";
                    }
                    else
                    {
                        AssessmentGuides.Other += "低盐饮食,每天＜6克盐，防骨质疏松，防跌倒。";
                    }
                }
                #endregion
                #region 济宁
                else if (area.Equals("济宁"))
                {
                    if (oldManFlag)
                    {
                        //老年人3饮食、4锻炼、6建议接种疫苗7其他每个人必须勾选
                        AssessmentGuides.DangerControl = "3,4,6,7,";

                        if (!common.toString(AssessmentGuides.Other).Contains("预防骨质疏松防跌倒，防意外伤害，保持心情舒畅"))
                        {
                            AssessmentGuides.Other += "预防骨质疏松防跌倒，防意外伤害，保持心情舒畅;";
                        }
                    }
                    // 不是老年人3饮食、4锻炼必选。
                    else AssessmentGuides.DangerControl = "3,4,";

                    if (!string.IsNullOrEmpty(RecordsManageMentModel.ElseDis) && RecordsManageMentModel.ElseDis.Contains("2"))
                    {
                        if (!string.IsNullOrEmpty(toString(RecordsManageMentModel.FPGL)))
                        {
                            if (RecordsManageMentModel.FPGL >= 7)
                            {
                                if (!common.toString(AssessmentGuides.Other).Contains("控制主食"))
                                {
                                    AssessmentGuides.Other += "控制主食;";
                                }
                            }
                        }
                    }

                    if (community == "小孟镇")
                    {
                        if (xmzQT.Contains("老年人") && xmzQT.Contains("血压高"))
                        {
                            AssessmentGuides.Other = "骨质疏松预防、防跌倒、低脂低盐饮食;";
                        }
                        if (xmzQT.Contains("血糖高") && xmzQT.Contains("老年人") && xmzQT.Contains("血压高"))
                        {
                            AssessmentGuides.Other = "骨质疏松预防、防跌倒、低脂低盐饮食、控制主食;";
                        }
                        if (xmzQT.Contains("老年人") && xmzQT.Contains("血压高"))
                        {
                            AssessmentGuides.Other = "骨质疏松预防、防跌倒、低脂低盐饮食;";
                        }
                        if (xmzQT.Contains("老年人") && xmzQT.Contains("血压高") && xmzQT.Contains("血糖高"))
                        {
                            AssessmentGuides.Other = "骨质疏松预防、防跌倒、低脂低盐饮食、控制主食;";
                        }
                        if (xmzQT.Contains("非老年人") && xmzQT.Contains("血压高"))
                        {
                            AssessmentGuides.Other = "低脂低盐饮食;";
                        }
                        if (xmzQT.Contains("血糖高") && xmzQT.Contains("非老年人") && xmzQT.Contains("血压高"))
                        {
                            AssessmentGuides.Other = "低脂低盐饮食、控制主食;";
                        }
                        if (xmzQT.Contains("非老年人") && xmzQT.Contains("血压高"))
                        {
                            AssessmentGuides.Other = "低脂低盐饮食;";
                        }
                        if (xmzQT.Contains("非老年人") && xmzQT.Contains("血压高") && xmzQT.Contains("血糖高"))
                        {
                            AssessmentGuides.Other = "低脂低盐饮食、控制主食;";
                        }

                        //if (xmzQT.Contains("腹型肥胖"))
                        //{
                        //    if (string.IsNullOrEmpty(AssessmentGuides.Other))
                        //        AssessmentGuides.Other = "减腰围;";
                        //    else AssessmentGuides.Other = "减腰围、" + AssessmentGuides.Other;
                        //}

                        if (!string.IsNullOrEmpty(AssessmentGuides.Other) && AssessmentGuides.DangerControl.IndexOf("7") == -1)
                        {
                            AssessmentGuides.DangerControl += "7,";
                        }
                    }
                }
                #endregion
                else
                {
                    #region 平度饮食、锻炼、饮酒、吸烟
                    if (area.Equals("平度"))
                    {
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.DietaryHabit)) //饮食习惯含有2，4，5，6其中一种，饮食勾选
                        {
                            if (!common.toString(RecordsManageMentModel.DietaryHabit).Contains("1"))
                            {
                                if (!AssessmentGuides.DangerControl.Contains("3"))
                                {
                                    AssessmentGuides.DangerControl += "3,";
                                }
                            }
                        }
                        // 1 不锻炼，危险控制因素要勾选锻炼
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.ExerciseRate) && (common.toString(RecordsManageMentModel.ExerciseRate) == "4"))
                        {
                            if (!AssessmentGuides.DangerControl.Contains("4"))
                            {
                                AssessmentGuides.DangerControl += "4,";
                            }
                        }
                        // 3 饮酒，要勾选健康饮酒  
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.DrinkRate) && (common.toString(RecordsManageMentModel.DrinkRate) != "1"))
                        {
                            if (!AssessmentGuides.DangerControl.Contains("2"))
                            {
                                AssessmentGuides.DangerControl += "2,";
                            }
                        }
                        //4 吸烟，要勾选戒烟
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.SmokeCondition) && (common.toString(RecordsManageMentModel.SmokeCondition) == "3"))
                        {
                            if (!AssessmentGuides.DangerControl.Contains("1"))
                            {
                                AssessmentGuides.DangerControl += "1,";
                            }
                        }
                    }
                    #endregion
                    else if (area.Equals("滕州"))
                    {
                        #region 滕州 饮食勾选情况
                        AssessmentGuides.DangerControl = "4,6,7,";
                        if (!string.IsNullOrEmpty(RecordsManageMentModel.DietaryHabit)) //饮食习惯勾选1荤素均衡、3素食为主其中一个或同时存在，在危险因素控制中不要勾选饮食
                        {
                            if (!common.toString(RecordsManageMentModel.DietaryHabit).Contains("1") &&
                                !common.toString(RecordsManageMentModel.DietaryHabit).Contains("3"))

                            {
                                if (!AssessmentGuides.DangerControl.Contains("3"))
                                {
                                    AssessmentGuides.DangerControl += "3,";
                                }
                            }
                        }
                        #endregion
                    }

                    string strOthers = "";

                    if (!string.IsNullOrEmpty(AssessmentGuides.Other))
                    {
                        AssessmentGuides.Other = AssessmentGuides.Other.Replace("低盐", "").Replace("低脂", "").Replace("低糖", "").Replace("饮食，防骨质疏松，防跌倒。", "");//建议清空，重新生成
                    }

                    if (flagxyH) strOthers = "低盐"; //血压高
                    if (flagxzH) strOthers += "低脂"; //血脂异常
                    if (flagxtH) strOthers += "低糖";//血糖异常

                    if (!string.IsNullOrEmpty(strOthers))
                    {
                        AssessmentGuides.Other += strOthers + "饮食，防骨质疏松，防跌倒。";
                    }
                    else
                    {
                        AssessmentGuides.Other += "低盐低脂低糖饮食，防骨质疏松，防跌倒。";
                    }
                }

                if (AssessmentGuides.DangerControl.Contains("6"))
                {
                    AssessmentGuides.VaccineAdvice = "流感疫苗、23价肺炎链球菌疫苗";
                }

                if (Model.Sex == "2" && Convert.ToDouble(RecordsManageMentModel.Waistline) >= 85) //判断女士腰围
                {
                    if (area.Equals("威海"))
                    {
                        if (!toString(AssessmentGuides.DangerControl).Contains("8"))
                        {
                            AssessmentGuides.DangerControl = "8," + AssessmentGuides.DangerControl;
                        }
                        if (RecordsManageMentModel.Waistline - 85 >= 5)
                        {
                            AssessmentGuides.WaistlineArm = (RecordsManageMentModel.Waistline - 5).ToString();
                        }
                        else if (RecordsManageMentModel.Waistline - 85 > 0) AssessmentGuides.WaistlineArm = "85";
                    }
                    else
                    {
                        if (!common.toString(AssessmentGuides.DangerControl).Contains("7"))
                        {
                            AssessmentGuides.DangerControl = "7," + AssessmentGuides.DangerControl;
                        }

                        if (!common.toString(AssessmentGuides.Other).Contains("减腰围"))
                        {
                            if (this.area == "禹城" || area.Equals("乐陵"))
                            {
                                if (RecordsManageMentModel.Waistline - 85 >= 5)
                                {
                                    AssessmentGuides.Other = "减腰围目标值" + (RecordsManageMentModel.Waistline - 5).ToString() + "cm。" + AssessmentGuides.Other;
                                }
                                else if (RecordsManageMentModel.Waistline - 85 > 0)
                                {
                                    AssessmentGuides.Other = "减腰围目标值85cm。" + AssessmentGuides.Other;
                                }
                                else
                                {
                                    AssessmentGuides.Other = "减腰围。" + AssessmentGuides.Other;
                                }
                            }
                            else if (area.Equals("菏泽") || area.Equals("乐陵"))
                            {
                                if (RecordsManageMentModel.Waistline >= 100)
                                {
                                    AssessmentGuides.Other = "减腰围至" + (RecordsManageMentModel.Waistline - 10).ToString() + "cm。" + AssessmentGuides.Other;
                                }
                                else if (RecordsManageMentModel.Waistline >= 90)
                                {
                                    AssessmentGuides.Other = "减腰围至" + (RecordsManageMentModel.Waistline - 5).ToString() + "cm。" + AssessmentGuides.Other;
                                }
                                else AssessmentGuides.Other = "减腰围至84cm。" + AssessmentGuides.Other;
                            }
                            else AssessmentGuides.Other = "减腰围。" + AssessmentGuides.Other;
                        }
                    }
                }
                else if (Model.Sex == "1" && Convert.ToDouble(RecordsManageMentModel.Waistline) >= 90)//判断男士腰围
                {
                    if (area.Equals("威海"))
                    {
                        if (!toString(AssessmentGuides.DangerControl).Contains("8"))
                        {
                            AssessmentGuides.DangerControl = "8," + AssessmentGuides.DangerControl;
                        }
                        if (RecordsManageMentModel.Waistline - 90 >= 5)
                        {
                            AssessmentGuides.WaistlineArm = (RecordsManageMentModel.Waistline - 5).ToString();
                        }
                        else if (RecordsManageMentModel.Waistline - 90 > 0) AssessmentGuides.WaistlineArm = "90";
                    }
                    else
                    {
                        if (!common.toString(AssessmentGuides.DangerControl).Contains("7"))
                        {
                            AssessmentGuides.DangerControl = "7," + AssessmentGuides.DangerControl;
                        }

                        if (!common.toString(AssessmentGuides.Other).Contains("减腰围"))
                        {
                            if (this.area == "禹城" || area.Equals("乐陵"))
                            {
                                if (RecordsManageMentModel.Waistline - 90 >= 5)
                                {
                                    AssessmentGuides.Other = "减腰围目标值" + (RecordsManageMentModel.Waistline - 5).ToString() + "cm。" + AssessmentGuides.Other;
                                }
                                else if (RecordsManageMentModel.Waistline - 90 > 0)
                                {
                                    AssessmentGuides.Other = "减腰围目标值90cm。" + AssessmentGuides.Other;
                                }
                                else AssessmentGuides.Other = "减腰围。" + AssessmentGuides.Other;
                            }
                            else if (area.Equals("菏泽") || area.Equals("乐陵"))
                            {
                                if (RecordsManageMentModel.Waistline >= 100)
                                {
                                    AssessmentGuides.Other = "减腰围至" + (RecordsManageMentModel.Waistline - 10).ToString() + "cm。" + AssessmentGuides.Other;
                                }
                                else if (RecordsManageMentModel.Waistline >= 95)
                                {
                                    AssessmentGuides.Other = "减腰围至" + (RecordsManageMentModel.Waistline - 5).ToString() + "cm。" + AssessmentGuides.Other;
                                }
                                else AssessmentGuides.Other = "减腰围至89cm。" + AssessmentGuides.Other;
                            }
                            else AssessmentGuides.Other = "减腰围。" + AssessmentGuides.Other;
                        }
                    }
                }
            }

            #endregion

            //超重时，默认值设置
            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.BMI)))
            {
                if (Convert.ToDouble(RecordsManageMentModel.BMI) > 24)
                {
                    if (!common.toString(AssessmentGuides.DangerControl).Contains("5"))
                    {
                        AssessmentGuides.DangerControl = "5," + AssessmentGuides.DangerControl;
                    }
                }
            }

            // 饮酒，默认值设置
            if (community.Equals("聊城东昌府区") || community.Equals("顾官屯卫生院"))//聊城东昌府区，戒酒的情况下不勾选健康饮酒
            {
                if (common.toString(RecordsManageMentModel.DrinkRate) != "1" && common.toString(RecordsManageMentModel.DrinkRate) != "")
                {
                    if (common.toString(RecordsManageMentModel.IsDrinkForbiddon) != "2")
                    {
                        if (!common.toString(AssessmentGuides.DangerControl).Contains("2"))
                        {
                            AssessmentGuides.DangerControl = "2," + AssessmentGuides.DangerControl;
                        }
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(RecordsManageMentModel.DrinkRate) && RecordsManageMentModel.DrinkRate != "1")
                {
                    if (!common.toString(AssessmentGuides.DangerControl).Contains("2"))
                    {
                        AssessmentGuides.DangerControl = "2," + AssessmentGuides.DangerControl;
                    }
                }
            }

            // 吸烟，默认值设置
            if (!string.IsNullOrEmpty(RecordsManageMentModel.SmokeCondition) && RecordsManageMentModel.SmokeCondition == "3")
            {
                if (!common.toString(AssessmentGuides.DangerControl).Contains("1"))
                {
                    AssessmentGuides.DangerControl = "1," + AssessmentGuides.DangerControl;
                }
            }

            // 如果锻炼就不用勾选，不锻炼勾选
            if (community.Equals("聊城东昌府区"))
            {
                if (!string.IsNullOrEmpty(RecordsManageMentModel.ExerciseRate) && common.toString(RecordsManageMentModel.ExerciseRate) == "4")
                {
                    if (!AssessmentGuides.DangerControl.Contains("4")) AssessmentGuides.DangerControl += "4,";
                }
            }

            // 健康指导，危险因素去重排序
            if (!string.IsNullOrEmpty(AssessmentGuides.HealthGuide))
            {
                string[] healthGuide = AssessmentGuides.HealthGuide.TrimStart(',').TrimEnd(',').Split(',').Distinct().ToArray();
                healthGuide = healthGuide.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                Array.Sort(healthGuide);
                AssessmentGuides.HealthGuide = string.Join(",", healthGuide);
            }

            if (!string.IsNullOrEmpty(AssessmentGuides.DangerControl))
            {
                string[] Danger = AssessmentGuides.DangerControl.TrimStart(',').TrimEnd(',').Split(',').Distinct().ToArray();
                Danger = Danger.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                Array.Sort(Danger);
                AssessmentGuides.DangerControl = string.Join(",", Danger);
            }

            return AssessmentGuides;
        }

        /// <summary>
        /// 尿常规异常
        /// </summary>
        /// <returns></returns>
        private string GetExNiaoGGT()
        {
            string NiaoQt = "";

            if (!string.IsNullOrEmpty(RecordsManageMentModel.PRO) && RecordsManageMentModel.PRO.Contains("+"))
            {
                NiaoQt += "尿蛋白异常、";
            }
            if (!string.IsNullOrEmpty(RecordsManageMentModel.GLU) && RecordsManageMentModel.GLU.Contains("+"))
            {
                NiaoQt += "尿糖异常、";
            }
            if (!string.IsNullOrEmpty(RecordsManageMentModel.KET) && RecordsManageMentModel.KET.Contains("+"))
            {
                NiaoQt += "尿酮体异常、";
            }
            if (!string.IsNullOrEmpty(RecordsManageMentModel.BLD) && RecordsManageMentModel.BLD.Contains("+"))
            {
                NiaoQt += "尿潜血异常、";
            }
            if (!string.IsNullOrEmpty(RecordsManageMentModel.UrineOther))
            {
                NiaoQt += RecordsManageMentModel.UrineOther + "、";
            }

            return NiaoQt.TrimEnd('、');
        }

        /// <summary>
        /// 尿常规异常
        /// </summary>
        /// <returns></returns>
        private string GetExNiao()
        {
            string NiaoQt = "";

            if (!string.IsNullOrEmpty(RecordsManageMentModel.PRO) && (RecordsManageMentModel.PRO.Contains("+") || RecordsManageMentModel.PRO.Contains("±")))
            {
                if (area.Equals("济宁"))
                {
                    NiaoQt += "尿蛋白:" + GetExNiaoPlus(RecordsManageMentModel.PRO) + "、";
                }
                else
                {
                    NiaoQt += "尿蛋白:" + RecordsManageMentModel.PRO + "、";
                }
            }
            if (!string.IsNullOrEmpty(RecordsManageMentModel.GLU) && (RecordsManageMentModel.GLU.Contains("+") || RecordsManageMentModel.GLU.Contains("±")))
            {
                if (area.Equals("济宁"))
                {
                    NiaoQt += "尿糖:" + GetExNiaoPlus(RecordsManageMentModel.GLU) + "、";
                }
                else
                {
                    NiaoQt += "尿糖:" + RecordsManageMentModel.GLU + "、";
                }
            }
            if (!string.IsNullOrEmpty(RecordsManageMentModel.KET) && (RecordsManageMentModel.KET.Contains("+") || RecordsManageMentModel.KET.Contains("±")))
            {
                if (area.Equals("济宁"))
                {
                    NiaoQt += "尿酮体:" + GetExNiaoPlus(RecordsManageMentModel.KET) + "、";
                }
                else
                {
                    NiaoQt += "尿酮体:" + RecordsManageMentModel.KET + "、";
                }
            }
            if (!string.IsNullOrEmpty(RecordsManageMentModel.BLD) && (RecordsManageMentModel.BLD.Contains("+") || RecordsManageMentModel.BLD.Contains("±")))
            {
                if (area.Equals("济宁"))
                {
                    NiaoQt += "尿潜血:" + GetExNiaoPlus(RecordsManageMentModel.BLD) + "、";
                }
                else
                {
                    NiaoQt += "尿潜血:" + RecordsManageMentModel.BLD + "、";
                }
            }
            if (!string.IsNullOrEmpty(RecordsManageMentModel.UrineOther) && RecordsManageMentModel.UrineOther.Contains("+"))
            {
                NiaoQt += RecordsManageMentModel.UrineOther + "、";
            }

            return NiaoQt.TrimEnd('、');
        }

        /// <summary>
        /// 将尿仪数据+1、+2改为+、++
        /// </summary>
        /// <param name="PRO"></param>
        /// <returns></returns>
        private string GetExNiaoPlus(string PRO)
        {
            if (string.IsNullOrEmpty(PRO)) return "";

            PRO = PRO.Replace("+1", "+").Replace("+2", "++").Replace("+3", "+++").Replace("+4", "++++").Replace("+5", "+++++").Replace("+6", "++++++").Replace("+7", "+++++++").Replace("+8", "+++++++++");

            if (community == "小孟镇") PRO = PRO.Replace("+-", "±");

            return PRO;
        }

        /// <summary>
        /// 血常规异常 --3个
        /// </summary>
        /// <param name="dtSH"></param>
        /// <returns></returns>
        private string GetXCGex(DataTable dtSH)
        {
            string strshxqex = "";
            string strHBItem = "血红蛋白";

            if (Model.Sex == "1") strHBItem = "血红蛋白男";
            else if (Model.Sex == "2") strHBItem = "血红蛋白女";

            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.HB)))
            {
                DataRow[] dr = dtSH.Select("name='" + strHBItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血红蛋白'");

                if (dr.Length > 0)
                {
                    if (RecordsManageMentModel.HB < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        //strshxqex = strshxqex + "血红蛋白:" + RecordsManageMentModel.HB + dr[0]["measurement"].ToString() + " ↓;";
                        strshxqex = strshxqex + "血红蛋白↓,";
                    }
                    else if (RecordsManageMentModel.HB > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        //strshxqex = strshxqex + "血红蛋白:" + RecordsManageMentModel.HB + dr[0]["measurement"].ToString() + " ↑;";
                        strshxqex = strshxqex + "血红蛋白↑,";
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (RecordsManageMentModel.HB < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        //strshxqex = strshxqex + "血红蛋白:" + RecordsManageMentModel.HB + dr2[0]["measurement"].ToString() + " ↓;";
                        strshxqex = strshxqex + "血红蛋白↓,";
                    }
                    else if (RecordsManageMentModel.HB > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        //strshxqex = strshxqex + "血红蛋白:" + RecordsManageMentModel.HB + dr2[0]["measurement"].ToString() + " ↑;";
                        strshxqex = strshxqex + "血红蛋白↑,";
                    }
                }
            }
            #region 乐陵白细胞、血小板男女区分
            if (area == "乐陵")
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.WBC)))
                {
                    if (Model.Sex == "1") strHBItem = "白细胞男";
                    else if (Model.Sex == "2") strHBItem = "白细胞女";

                    DataRow[] dr = dtSH.Select("name='" + strHBItem + "'");
                    DataRow[] dr2 = dtSH.Select("name='白细胞'");

                    if (dr.Length > 0)
                    {
                        if (RecordsManageMentModel.WBC < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "白细胞↓,";
                        }
                        else if (RecordsManageMentModel.WBC > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "白细胞↑,";
                        }
                    }
                    else if (dr2.Length > 0)
                    {
                        if (RecordsManageMentModel.WBC < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "白细胞↓,";
                        }
                        else if (RecordsManageMentModel.WBC > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "白细胞↑,";
                        }
                    }
                }
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.PLT)))
                {
                    if (Model.Sex == "1") strHBItem = "血小板男";
                    else if (Model.Sex == "2") strHBItem = "血小板女";

                    DataRow[] dr = dtSH.Select("name='" + strHBItem + "'");
                    DataRow[] dr2 = dtSH.Select("name='血小板'");

                    if (dr.Length > 0)
                    {
                        if (RecordsManageMentModel.PLT < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血小板↓,";
                        }
                        else if (RecordsManageMentModel.PLT > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血小板↑,";
                        }
                    }
                    else if (dr2.Length > 0)
                    {
                        if (RecordsManageMentModel.PLT < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血小板↓,";
                        }
                        else if (RecordsManageMentModel.PLT > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血小板↑,";
                        }
                    }
                }
                return strshxqex.TrimEnd(',');
            }
            #endregion

            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.WBC)) && item["name"].ToString() == "白细胞") //白细胞      ------》血球 范围 4.0-10.0x10^9/L
                {
                    if (RecordsManageMentModel.WBC < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "白细胞↓,";
                    }
                    else if (RecordsManageMentModel.WBC > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "白细胞↑,";
                    }
                    continue;
                }
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.PLT)) && item["name"].ToString() == "血小板") //血小板      ------》血球 范围100-300x10^9/L
                {
                    if (RecordsManageMentModel.PLT < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血小板↓,";
                    }
                    else if (RecordsManageMentModel.PLT > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血小板↑,";
                    }
                    continue;
                }
            }
            return strshxqex.TrimEnd(',');
        }

        private string GetXCGexValue(DataTable dtSH)
        {
            string strshxqex = "";
            string strHBItem = "血红蛋白";

            if (Model.Sex == "1") strHBItem = "血红蛋白男";
            else if (Model.Sex == "2") strHBItem = "血红蛋白女";

            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.HB)))
            {
                DataRow[] dr = dtSH.Select("name='" + strHBItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血红蛋白'");

                if (dr.Length > 0)
                {
                    if (RecordsManageMentModel.HB < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血红蛋白:" + RecordsManageMentModel.HB + dr[0]["measurement"].ToString() + " ↓;";

                    }
                    else if (RecordsManageMentModel.HB > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血红蛋白:" + RecordsManageMentModel.HB + dr[0]["measurement"].ToString() + " ↑;";

                    }
                }
                else if (dr2.Length > 0)
                {
                    if (RecordsManageMentModel.HB < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血红蛋白:" + RecordsManageMentModel.HB + dr2[0]["measurement"].ToString() + " ↓;";

                    }
                    else if (RecordsManageMentModel.HB > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血红蛋白:" + RecordsManageMentModel.HB + dr2[0]["measurement"].ToString() + " ↑;";
                    }
                }
            }
            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.WBC)) && item["name"].ToString() == "白细胞") //白细胞      ------》血球 范围 4.0-10.0x10^9/L
                {
                    if (RecordsManageMentModel.WBC < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "白细胞:" + RecordsManageMentModel.WBC + item["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "白细胞↓,";
                    }
                    else if (RecordsManageMentModel.WBC > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "白细胞:" + RecordsManageMentModel.WBC + item["measurement"].ToString() + " ↑;";
                    }
                    continue;
                }
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.PLT)) && item["name"].ToString() == "血小板") //血小板      ------》血球 范围100-300x10^9/L
                {
                    if (RecordsManageMentModel.PLT < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血小板:" + RecordsManageMentModel.PLT + item["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "血小板↓,";
                    }
                    else if (RecordsManageMentModel.PLT > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血小板:" + RecordsManageMentModel.PLT + item["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "血小板↑,";
                    }
                    continue;
                }
            }
            return strshxqex.TrimEnd(';');
        }

        private void GetXCGexValueByXMZ(DataTable dtSH)
        {
            string strHBItem = "血红蛋白";
            string xcg = "血常规:";
            if (Model.Sex == "1") strHBItem = "血红蛋白男";
            else if (Model.Sex == "2") strHBItem = "血红蛋白女";

            string RBC = "";

            // 血液细胞检测报告
            string strYear = DateTime.Now.Year.ToString();
            string strWhere = string.Format("IDCardNo='{0}' AND LEFT(TestTime ,4)='{1}' ORDER BY TestTime DESC,ID DESC LIMIT 0,1 ", this.Model.IDCardNo, strYear);
            DataSet BlooDt = new RecordsxqBLL().GetDT(strWhere);

            if (BlooDt.Tables.Count > 0 && BlooDt.Tables[0].Rows.Count > 0) RBC = BlooDt.Tables[0].Rows[0]["RBC"].ToString();

            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.HB)))
            {
                DataRow[] dr = dtSH.Select("name='" + strHBItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血红蛋白'");

                if (dr.Length > 0)
                {
                    if (RecordsManageMentModel.HB < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        xcg += "血红蛋白低:" + RecordsManageMentModel.HB + dr[0]["measurement"].ToString() + "、";
                    }
                    else if (RecordsManageMentModel.HB > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        xcg += "血红蛋白高:" + RecordsManageMentModel.HB + dr[0]["measurement"].ToString() + "、";
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (RecordsManageMentModel.HB < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        xcg += "血红蛋白低:" + RecordsManageMentModel.HB + dr2[0]["measurement"].ToString() + "、";
                    }
                    else if (RecordsManageMentModel.HB > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        xcg += "血红蛋白高:" + RecordsManageMentModel.HB + dr2[0]["measurement"].ToString() + "、";
                    }
                }
            }

            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.WBC)) && item["name"].ToString() == "白细胞") //白细胞      ------》血球 范围 4.0-10.0x10^9/L
                {
                    if (RecordsManageMentModel.WBC < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        xcg += "白细胞低:" + RecordsManageMentModel.WBC + item["measurement"].ToString() + "、";
                    }
                    else if (RecordsManageMentModel.WBC > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        xcg += "白细胞高:" + RecordsManageMentModel.WBC + item["measurement"].ToString() + "、";
                    }
                    continue;
                }
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.PLT)) && item["name"].ToString() == "血小板") //血小板      ------》血球 范围100-300x10^9/L
                {
                    if (RecordsManageMentModel.PLT < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        xcg += "血小板低: " + RecordsManageMentModel.PLT + item["measurement"].ToString() + "、";
                    }
                    else if (RecordsManageMentModel.PLT > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        xcg += "血小板高: " + RecordsManageMentModel.PLT + item["measurement"].ToString() + "、";
                    }
                    continue;
                }
                if (!string.IsNullOrEmpty(RBC) && item["name"].ToString() == "红细胞数目")
                {
                    if (Convert.ToDouble(RBC) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        xcg += "红细胞数目低: " + RBC + item["measurement"].ToString() + "、";
                    }
                    else if (Convert.ToDouble(RBC) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        xcg += "红细胞数目高: " + RBC + item["measurement"].ToString() + "、";
                    }
                    continue;
                }
            }

            if (xcg != "血常规:")
            {
                yichang++;
                SetStrEx(xcg.Substring(0, xcg.Length - 1), "血常规");
            }
        }

        /// <summary>
        /// 肝功能异常 -- 6个
        /// </summary>
        /// <param name="dtSH"></param>
        /// <returns></returns>
        private string GetGGNex(DataTable dtSH)
        {
            string strshxqex = "";
            string strSGPTItem = "血清谷丙转氨酶", strGOTItem = "血清谷草转氨酶";

            if (Model.Sex == "1")
            {
                strSGPTItem = "血清谷丙转氨酶男";
                strGOTItem = "血清谷草转氨酶男";
            }
            else if (Model.Sex == "2")
            {
                strSGPTItem = "血清谷丙转氨酶女";
                strGOTItem = "血清谷草转氨酶女";
            }

            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.SGPT)))
            {
                DataRow[] dr = dtSH.Select("name='" + strSGPTItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血清谷丙转氨酶'");

                if (dr.Length > 0)
                {
                    if (RecordsManageMentModel.SGPT < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷丙转氨酶↓,";
                    }
                    else if (RecordsManageMentModel.SGPT > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷丙转氨酶↑,";
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (RecordsManageMentModel.SGPT < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷丙转氨酶↓,";
                    }
                    else if (RecordsManageMentModel.SGPT > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷丙转氨酶↑,";
                    }
                }
            }

            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.GOT)))
            {
                DataRow[] dr = dtSH.Select("name='" + strGOTItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血清谷草转氨酶'");

                if (dr.Length > 0)
                {
                    if (RecordsManageMentModel.GOT < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷草转氨酶↓,";
                    }
                    else if (RecordsManageMentModel.GOT > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷草转氨酶↑,";
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (RecordsManageMentModel.GOT < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷草转氨酶↓,";
                    }
                    else if (RecordsManageMentModel.GOT > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷草转氨酶↑,";
                    }
                }
            }

            #region 乐陵白蛋白、总胆红素、结合胆红素区分男女
            if (area == "乐陵")
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.BP)))
                {

                    if (Model.Sex == "1")
                    {
                        strSGPTItem = "白蛋白男";
                    }
                    else if (Model.Sex == "2")
                    {
                        strSGPTItem = "白蛋白女";
                    }
                    DataRow[] dr = dtSH.Select("name='" + strSGPTItem + "'");
                    DataRow[] dr2 = dtSH.Select("name='白蛋白'");

                    if (dr.Length > 0)
                    {
                        if (RecordsManageMentModel.BP < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "白蛋白↓,";
                        }
                        else if (RecordsManageMentModel.BP > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "白蛋白↑,";
                        }
                    }
                    else if (dr2.Length > 0)
                    {
                        if (RecordsManageMentModel.BP < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "白蛋白↓,";
                        }
                        else if (RecordsManageMentModel.BP > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "白蛋白↑,";
                        }
                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.TBIL)))
                {
                    if (Model.Sex == "1")
                    {
                        strSGPTItem = "总胆红素男";
                    }
                    else if (Model.Sex == "2")
                    {
                        strSGPTItem = "总胆红素女";
                    }
                    DataRow[] dr = dtSH.Select("name='" + strSGPTItem + "'");
                    DataRow[] dr2 = dtSH.Select("name='总胆红素'");

                    if (dr.Length > 0)
                    {
                        if (RecordsManageMentModel.TBIL < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "总胆红素↓,";
                        }
                        else if (RecordsManageMentModel.TBIL > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "总胆红素↑,";
                        }
                    }
                    else if (dr2.Length > 0)
                    {
                        if (RecordsManageMentModel.TBIL < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "总胆红素↓,";
                        }
                        else if (RecordsManageMentModel.TBIL > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "总胆红素↑,";
                        }
                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.CB)))
                {
                    if (Model.Sex == "1")
                    {
                        strSGPTItem = "结合胆红素男";
                    }
                    else if (Model.Sex == "2")
                    {
                        strSGPTItem = "结合胆红素女";
                    }
                    DataRow[] dr = dtSH.Select("name='" + strSGPTItem + "'");
                    DataRow[] dr2 = dtSH.Select("name='结合胆红素'");

                    if (dr.Length > 0)
                    {
                        if (RecordsManageMentModel.CB < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "结合胆红素↓,";
                        }
                        else if (RecordsManageMentModel.CB > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "结合胆红素↑,";
                        }
                    }
                    else if (dr2.Length > 0)
                    {
                        if (RecordsManageMentModel.CB < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "结合胆红素↓,";
                        }
                        else if (RecordsManageMentModel.CB > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "结合胆红素↑,";
                        }
                    }
                }
                return strshxqex.TrimEnd(',');
            }
            #endregion 
            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.BP)) && item["name"].ToString() == "白蛋白") //白蛋白    ------》生化 范围37-53g/L
                {
                    if (RecordsManageMentModel.BP < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "白蛋白↓,";
                    }
                    else if (RecordsManageMentModel.BP > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "白蛋白↑,";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.TBIL)) && item["name"].ToString() == "总胆红素") //总胆红素    ------》生化 范围5.1-19μmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.TBIL) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "总胆红素↓,";
                    }
                    else if (RecordsManageMentModel.TBIL > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "总胆红素↑,";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.CB)) && item["name"].ToString() == "结合胆红素") //结合胆红素    ------》生化 范围1.7-6.8μmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.CB) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "结合胆红素↓,";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.CB) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "结合胆红素↑,";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.GT)) && item["name"].ToString() == "谷氨酰转肽酶") //谷氨酰转肽酶    ------》生化 范围0-50 U/L
                {
                    if (RecordsManageMentModel.GT < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "谷氨酰转肽酶↓,";
                    }
                    else if (RecordsManageMentModel.GT > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "谷氨酰转肽酶↑,";
                    }
                    continue;
                }
            }

            return strshxqex.TrimEnd(',');
        }

        private string GetGGNexValue(DataTable dtSH)
        {
            string strshxqex = "";
            string strSGPTItem = "血清谷丙转氨酶", strGOTItem = "血清谷草转氨酶";

            if (Model.Sex == "1")
            {
                strSGPTItem = "血清谷丙转氨酶男";
                strGOTItem = "血清谷草转氨酶男";
            }
            else if (Model.Sex == "2")
            {
                strSGPTItem = "血清谷丙转氨酶女";
                strGOTItem = "血清谷草转氨酶女";
            }

            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.SGPT)))
            {
                DataRow[] dr = dtSH.Select("name='" + strSGPTItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血清谷丙转氨酶'");

                if (dr.Length > 0)
                {
                    if (RecordsManageMentModel.SGPT < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷丙转氨酶:" + RecordsManageMentModel.SGPT + dr[0]["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "血清谷丙转氨酶↓,";
                    }
                    else if (RecordsManageMentModel.SGPT > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷丙转氨酶:" + RecordsManageMentModel.SGPT + dr[0]["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "血清谷丙转氨酶↑,";
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (RecordsManageMentModel.SGPT < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷丙转氨酶:" + RecordsManageMentModel.SGPT + dr2[0]["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "血清谷丙转氨酶↓,";
                    }
                    else if (RecordsManageMentModel.SGPT > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷丙转氨酶:" + RecordsManageMentModel.SGPT + dr2[0]["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "血清谷丙转氨酶↑,";
                    }
                }
            }

            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.GOT)))
            {
                DataRow[] dr = dtSH.Select("name='" + strGOTItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血清谷草转氨酶'");

                if (dr.Length > 0)
                {
                    if (RecordsManageMentModel.GOT < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷草转氨酶:" + RecordsManageMentModel.GOT + dr[0]["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "血清谷草转氨酶↓,";
                    }
                    else if (RecordsManageMentModel.GOT > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷草转氨酶:" + RecordsManageMentModel.GOT + dr[0]["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "血清谷草转氨酶↑,";
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (RecordsManageMentModel.GOT < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷草转氨酶:" + RecordsManageMentModel.GOT + dr2[0]["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "血清谷草转氨酶↓,";
                    }
                    else if (RecordsManageMentModel.GOT > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清谷草转氨酶:" + RecordsManageMentModel.GOT + dr2[0]["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "血清谷草转氨酶↑,";
                    }
                }
            }
            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.BP)) && item["name"].ToString() == "白蛋白") //白蛋白    ------》生化 范围37-53g/L
                {
                    if (RecordsManageMentModel.BP < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "白蛋白:" + RecordsManageMentModel.BP + item["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "白蛋白↓,";
                    }
                    else if (RecordsManageMentModel.BP > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "白蛋白:" + RecordsManageMentModel.BP + item["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "白蛋白↑,";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.TBIL)) && item["name"].ToString() == "总胆红素") //总胆红素    ------》生化 范围5.1-19μmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.TBIL) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "总胆红素:" + RecordsManageMentModel.TBIL + item["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "总胆红素↓,";
                    }
                    else if (RecordsManageMentModel.TBIL > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "总胆红素:" + RecordsManageMentModel.TBIL + item["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "总胆红素↑,";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.CB)) && item["name"].ToString() == "结合胆红素") //结合胆红素    ------》生化 范围1.7-6.8μmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.CB) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "结合胆红素:" + RecordsManageMentModel.CB + item["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "结合胆红素↓,";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.CB) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "结合胆红素:" + RecordsManageMentModel.CB + item["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "结合胆红素↑,";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.GT)) && item["name"].ToString() == "谷氨酰转肽酶") //谷氨酰转肽酶    ------》生化 范围0-50 U/L
                {
                    if (RecordsManageMentModel.GT < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "谷氨酰转肽酶:" + RecordsManageMentModel.GT + item["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "谷氨酰转肽酶↓,";
                    }
                    else if (RecordsManageMentModel.GT > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "谷氨酰转肽酶:" + RecordsManageMentModel.GT + item["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "谷氨酰转肽酶↑,";
                    }
                    continue;
                }
            }

            return strshxqex.TrimEnd(';');
        }

        /// <summary>
        /// 小孟镇
        /// </summary>
        /// <param name="dtSH"></param>
        /// <returns></returns>
        private void GetGGNexValueByXMZ(DataTable dtSH)
        {
            string strSGPTItem = "血清谷丙转氨酶", strGOTItem = "血清谷草转氨酶";

            if (Model.Sex == "1")
            {
                strSGPTItem = "血清谷丙转氨酶男";
                strGOTItem = "血清谷草转氨酶男";
            }
            else if (Model.Sex == "2")
            {
                strSGPTItem = "血清谷丙转氨酶女";
                strGOTItem = "血清谷草转氨酶女";
            }

            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.SGPT)))
            {
                DataRow[] dr = dtSH.Select("name='" + strSGPTItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血清谷丙转氨酶'");

                if (dr.Length > 0)
                {
                    if (RecordsManageMentModel.SGPT < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血清谷丙转氨酶低:" + RecordsManageMentModel.SGPT + dr[0]["measurement"].ToString() + ";", "血清谷丙转氨酶");
                    }
                    else if (RecordsManageMentModel.SGPT > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血清谷丙转氨酶高:" + RecordsManageMentModel.SGPT + dr[0]["measurement"].ToString() + ";", "血清谷丙转氨酶");
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (RecordsManageMentModel.SGPT < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血清谷丙转氨酶低:" + RecordsManageMentModel.SGPT + dr2[0]["measurement"].ToString() + ";", "血清谷丙转氨酶");
                    }
                    else if (RecordsManageMentModel.SGPT > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血清谷丙转氨酶高:" + RecordsManageMentModel.SGPT + dr2[0]["measurement"].ToString() + ";", "血清谷丙转氨酶");
                    }
                }
            }

            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.GOT)))
            {
                DataRow[] dr = dtSH.Select("name='" + strGOTItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血清谷草转氨酶'");

                if (dr.Length > 0)
                {
                    if (RecordsManageMentModel.GOT < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血清谷草转氨酶低:" + RecordsManageMentModel.GOT + dr[0]["measurement"].ToString() + ";", "血清谷草转氨酶");
                    }
                    else if (RecordsManageMentModel.GOT > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血清谷草转氨酶高:" + RecordsManageMentModel.GOT + dr[0]["measurement"].ToString() + ";", "血清谷草转氨酶");
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (RecordsManageMentModel.GOT < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血清谷草转氨酶低:" + RecordsManageMentModel.GOT + dr2[0]["measurement"].ToString() + ";", "血清谷草转氨酶");
                    }
                    else if (RecordsManageMentModel.GOT > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血清谷草转氨酶高:" + RecordsManageMentModel.GOT + dr2[0]["measurement"].ToString() + ";", "血清谷草转氨酶");
                    }
                }
            }

            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.BP)) && item["name"].ToString() == "白蛋白") //白蛋白    ------》生化 范围37-53g/L
                {
                    if (RecordsManageMentModel.BP < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("白蛋白低:" + RecordsManageMentModel.BP + item["measurement"].ToString() + ";", "白蛋白");
                    }
                    else if (RecordsManageMentModel.BP > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("白蛋白高:" + RecordsManageMentModel.BP + item["measurement"].ToString() + ";", "白蛋白");
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.TBIL)) && item["name"].ToString() == "总胆红素") //总胆红素    ------》生化 范围5.1-19μmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.TBIL) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("总胆红素低:" + RecordsManageMentModel.TBIL + item["measurement"].ToString() + ";", "总胆红素");
                    }
                    else if (RecordsManageMentModel.TBIL > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("总胆红素高:" + RecordsManageMentModel.TBIL + item["measurement"].ToString() + ";", "总胆红素");
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.CB)) && item["name"].ToString() == "结合胆红素") //结合胆红素    ------》生化 范围1.7-6.8μmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.CB) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("结合胆红素低:" + RecordsManageMentModel.CB + item["measurement"].ToString() + ";", "结合胆红素");
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.CB) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("结合胆红素高:" + RecordsManageMentModel.CB + item["measurement"].ToString() + ";", "结合胆红素");
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.GT)) && item["name"].ToString() == "谷氨酰转肽酶") //谷氨酰转肽酶    ------》生化 范围0-50 U/L
                {
                    if (RecordsManageMentModel.GT < Convert.ToDecimal(item["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("谷氨酰转肽酶低:" + RecordsManageMentModel.GT + item["measurement"].ToString() + ";", "谷氨酰转肽酶");
                    }
                    else if (RecordsManageMentModel.GT > Convert.ToDecimal(item["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("谷氨酰转肽酶高:" + RecordsManageMentModel.GT + item["measurement"].ToString() + ";", "谷氨酰转肽酶");
                    }
                    continue;
                }
            }
        }

        /// <summary>
        /// 肾功能异常--3个
        /// </summary>
        /// <param name="dtSH"></param>
        /// <returns></returns>
        private string GetSGNex(DataTable dtSH) //肾功能异常--3个
        {
            string strshxqex = "";
            string strSCRItem = "血清肌酐";

            if (Model.Sex == "1")
            {
                strSCRItem = "血清肌酐男";
            }
            else if (Model.Sex == "2")
            {
                strSCRItem = "血清肌酐女";
            }

            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.SCR)))
            {
                DataRow[] dr = dtSH.Select("name='" + strSCRItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血清肌酐'");

                if (dr.Length > 0)
                {
                    if (RecordsManageMentModel.SCR < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清肌酐↓,";
                    }
                    else if (RecordsManageMentModel.SCR > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清肌酐↑,";
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (RecordsManageMentModel.SCR < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清肌酐↓,";
                    }
                    else if (RecordsManageMentModel.SCR > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清肌酐↑,";
                    }
                }
            }

            #region 乐陵 血尿素氮、血清尿酸区分男女
            if (area == "乐陵")
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.BUN)))
                {
                    if (Model.Sex == "1")
                    {
                        strSCRItem = "血尿素氮男";
                    }
                    else if (Model.Sex == "2")
                    {
                        strSCRItem = "血尿素氮女";
                    }

                    DataRow[] dr = dtSH.Select("name='" + strSCRItem + "'");
                    DataRow[] dr2 = dtSH.Select("name='血尿素氮'");

                    if (dr.Length > 0)
                    {
                        if (RecordsManageMentModel.BUN < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血尿素氮↓,";
                        }
                        else if (RecordsManageMentModel.BUN > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血尿素氮↑,";
                        }
                    }
                    else if (dr2.Length > 0)
                    {
                        if (RecordsManageMentModel.BUN < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血尿素氮↓,";
                        }
                        else if (RecordsManageMentModel.BUN > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血尿素氮↑,";
                        }
                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.UA)))
                {
                    if (Model.Sex == "1")
                    {
                        strSCRItem = "血清尿酸男";
                    }
                    else if (Model.Sex == "2")
                    {
                        strSCRItem = "血清尿酸女";
                    }

                    DataRow[] dr = dtSH.Select("name='" + strSCRItem + "'");
                    DataRow[] dr2 = dtSH.Select("name='血清尿酸'");

                    if (dr.Length > 0)
                    {
                        if (Convert.ToDecimal(RecordsManageMentModel.UA) < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血清尿酸↓,";
                        }
                        else if (Convert.ToDecimal(RecordsManageMentModel.UA) > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血清尿酸↑,";
                        }
                    }
                    else if (dr2.Length > 0)
                    {
                        if (Convert.ToDecimal(RecordsManageMentModel.UA) < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血清尿酸↓,";
                        }
                        else if (Convert.ToDecimal(RecordsManageMentModel.UA) > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血清尿酸↑,";
                        }
                    }
                }
                return strshxqex.TrimEnd(',');
            }
            #endregion

            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.BUN)) && item["name"].ToString() == "血尿素氮") //血尿素氮    ------》生化 范围1.7-8.3mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.BUN) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血尿素氮↓,";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BUN) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血尿素氮↑,";
                    }
                    continue;
                }


                if (!string.IsNullOrEmpty(RecordsManageMentModel.Other) && item["name"].ToString() == "血清尿酸")
                {
                    string regex = @"[^\d.\d]";
                    string value = Regex.Replace(RecordsManageMentModel.Other, regex, "");

                    if (Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$"))
                    {
                        if (Convert.ToDouble(value) < Convert.ToDouble(item["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + RecordsManageMentModel.Other + " ↓,";
                        }
                        else if (Convert.ToDouble(value) > Convert.ToDouble(item["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + RecordsManageMentModel.Other + " ↑,";
                        }
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.UA)) && item["name"].ToString() == "血清尿酸")
                {
                    if (Convert.ToDouble(RecordsManageMentModel.UA) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清尿酸↓,";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.UA) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清尿酸↑,";
                    }
                    continue;
                }
            }

            return strshxqex.TrimEnd(',');
        }

        private string GetSGNexValue(DataTable dtSH) //肾功能异常--3个
        {
            string strshxqex = "";
            string strSCRItem = "血清肌酐";

            if (Model.Sex == "1")
            {
                strSCRItem = "血清肌酐男";
            }
            else if (Model.Sex == "2")
            {
                strSCRItem = "血清肌酐女";
            }

            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.SCR)))
            {
                DataRow[] dr = dtSH.Select("name='" + strSCRItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血清肌酐'");

                if (dr.Length > 0)
                {
                    if (RecordsManageMentModel.SCR < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清肌酐:" + RecordsManageMentModel.SCR + dr[0]["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "血清肌酐↓,";
                    }
                    else if (RecordsManageMentModel.SCR > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清肌酐:" + RecordsManageMentModel.SCR + dr[0]["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "血清肌酐↑,";
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (RecordsManageMentModel.SCR < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清肌酐:" + RecordsManageMentModel.SCR + dr2[0]["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "血清肌酐↓,";
                    }
                    else if (RecordsManageMentModel.SCR > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清肌酐:" + RecordsManageMentModel.SCR + dr2[0]["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "血清肌酐↑,";
                    }
                }
            }

            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.BUN)) && item["name"].ToString() == "血尿素氮") //血尿素氮    ------》生化 范围1.7-8.3mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.BUN) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血尿素氮:" + RecordsManageMentModel.BUN + item["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "血尿素氮↓,";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BUN) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血尿素氮:" + RecordsManageMentModel.BUN + item["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "血尿素氮↑,";
                    }
                    continue;
                }

                if (area.Equals("济宁"))
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.PC)) && item["name"].ToString() == "血钾浓度") //血钾浓度    ------》生化 范围3.5-5.3mmol/L
                    {
                        if (Convert.ToDouble(RecordsManageMentModel.PC) < Convert.ToDouble(item["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血钾浓度:" + RecordsManageMentModel.PC + item["measurement"].ToString() + " ↓;";
                            //strshxqex = strshxqex + "血钾浓度↓,";
                        }
                        else if (Convert.ToDouble(RecordsManageMentModel.PC) > Convert.ToDouble(item["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血钾浓度:" + RecordsManageMentModel.PC + item["measurement"].ToString() + " ↑;";
                            //strshxqex = strshxqex + "血钾浓度↑,";
                        }
                        continue;
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.HYPE)) && item["name"].ToString() == "血钠浓度") //血钠浓度    ------》生化 范围3.5-5.3mmol/L
                    {
                        if (Convert.ToDouble(RecordsManageMentModel.HYPE) < Convert.ToDouble(item["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血钠浓度:" + RecordsManageMentModel.HYPE + item["measurement"].ToString() + " ↓;";
                            //strshxqex = strshxqex + "血钠浓度↓,";
                        }
                        else if (Convert.ToDouble(RecordsManageMentModel.HYPE) > Convert.ToDouble(item["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血钠浓度:" + RecordsManageMentModel.HYPE + item["measurement"].ToString() + " ↑;";
                            //strshxqex = strshxqex + "血钠浓度↑,";
                        }
                        continue;
                    }
                }

                if (!string.IsNullOrEmpty(RecordsManageMentModel.Other) && item["name"].ToString() == "血清尿酸")
                {
                    string regex = @"[^\d.\d]";
                    string value = Regex.Replace(RecordsManageMentModel.Other, regex, "");

                    if (Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$"))
                    {
                        if (Convert.ToDouble(value) < Convert.ToDouble(item["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + RecordsManageMentModel.Other + " ↓,";
                        }
                        else if (Convert.ToDouble(value) > Convert.ToDouble(item["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + RecordsManageMentModel.Other + " ↑,";
                        }
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.UA)) && item["name"].ToString() == "血清尿酸")
                {
                    if (Convert.ToDouble(RecordsManageMentModel.UA) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清尿酸:" + RecordsManageMentModel.UA + item["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "血清尿酸↓,";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.UA) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清尿酸:" + RecordsManageMentModel.UA + item["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "血清尿酸↑,";
                    }
                    continue;
                }
            }

            return strshxqex.TrimEnd(';');
        }

        private void GetSGNexValueByXMZ(DataTable dtSH) //肾功能异常--3个
        {
            string strSCRItem = "血清肌酐";

            if (Model.Sex == "1")
            {
                strSCRItem = "血清肌酐男";
            }
            else if (Model.Sex == "2")
            {
                strSCRItem = "血清肌酐女";
            }

            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.SCR)))
            {
                DataRow[] dr = dtSH.Select("name='" + strSCRItem + "'");
                DataRow[] dr2 = dtSH.Select("name='血清肌酐'");

                if (dr.Length > 0)
                {
                    if (RecordsManageMentModel.SCR < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血清肌酐低:" + RecordsManageMentModel.SCR + dr[0]["measurement"].ToString() + ";", "血清肌酐");
                    }
                    else if (RecordsManageMentModel.SCR > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血清肌酐高:" + RecordsManageMentModel.SCR + dr[0]["measurement"].ToString() + ";", "血清肌酐");
                    }
                }
                else if (dr2.Length > 0)
                {
                    if (RecordsManageMentModel.SCR < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血清肌酐低:" + RecordsManageMentModel.SCR + dr2[0]["measurement"].ToString() + ";", "血清肌酐");
                    }
                    else if (RecordsManageMentModel.SCR > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血清肌酐高:" + RecordsManageMentModel.SCR + dr2[0]["measurement"].ToString() + ";", "血清肌酐");
                    }
                }
            }

            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.BUN)) && item["name"].ToString() == "血尿素氮") //血尿素氮    ------》生化 范围1.7-8.3mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.BUN) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血尿素氮低:" + RecordsManageMentModel.BUN + item["measurement"].ToString() + ";", "血尿素氮");
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.BUN) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血尿素氮高:" + RecordsManageMentModel.BUN + item["measurement"].ToString() + ";", "血尿素氮");
                    }
                    continue;
                }

                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.PC)) && item["name"].ToString() == "血钾浓度") //血钾浓度    ------》生化 范围3.5-5.3mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.PC) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血钾浓度低:" + RecordsManageMentModel.PC + item["measurement"].ToString() + ";", "血钾浓度");
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.PC) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血钾浓度高:" + RecordsManageMentModel.PC + item["measurement"].ToString() + ";", "血钾浓度");
                    }
                    continue;
                }

                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.HYPE)) && item["name"].ToString() == "血钠浓度") //血钠浓度    ------》生化 范围3.5-5.3mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.HYPE) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血钠浓度低:" + RecordsManageMentModel.HYPE + item["measurement"].ToString() + ";", "血钠浓度");
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.HYPE) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血钠浓度高:" + RecordsManageMentModel.HYPE + item["measurement"].ToString() + ";", "血钠浓度");
                    }
                    continue;
                }

                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.UA)) && item["name"].ToString() == "血清尿酸")
                {
                    if (Convert.ToDouble(RecordsManageMentModel.UA) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血清尿酸低:" + RecordsManageMentModel.UA + item["measurement"].ToString() + ";", "血清尿酸");
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.UA) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("血清尿酸高:" + RecordsManageMentModel.UA + item["measurement"].ToString() + ";", "血清尿酸");
                    }
                    continue;
                }
            }
        }

        /// <summary>
        /// 血脂异常--4个
        /// </summary>
        /// <param name="dtSH"></param>
        /// <returns></returns>
        private string GetXZex(DataTable dtSH) //血脂异常--4个
        {
            string strshxqex = "";

            #region 乐陵 血尿素氮、血清尿酸区分男女
            if (area == "乐陵")
            {
                string strSCRItem = "";
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.TC)))
                {
                    if (Model.Sex == "1")
                    {
                        strSCRItem = "总胆固醇男";
                    }
                    else if (Model.Sex == "2")
                    {
                        strSCRItem = "总胆固醇女";
                    }

                    DataRow[] dr = dtSH.Select("name='" + strSCRItem + "'");
                    DataRow[] dr2 = dtSH.Select("name='总胆固醇'");

                    if (dr.Length > 0)
                    {
                        if (RecordsManageMentModel.TC < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "总胆固醇↓,";
                        }
                        else if (RecordsManageMentModel.TC > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "总胆固醇↑,";
                        }
                    }
                    else if (dr2.Length > 0)
                    {
                        if (RecordsManageMentModel.TC < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "总胆固醇↓,";
                        }
                        else if (RecordsManageMentModel.TC > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "总胆固醇↑,";
                        }
                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.TG)))
                {
                    if (Model.Sex == "1")
                    {
                        strSCRItem = "甘油三酯男";
                    }
                    else if (Model.Sex == "2")
                    {
                        strSCRItem = "甘油三酯女";
                    }

                    DataRow[] dr = dtSH.Select("name='" + strSCRItem + "'");
                    DataRow[] dr2 = dtSH.Select("name='甘油三酯'");

                    if (dr.Length > 0)
                    {
                        if (Convert.ToDecimal(RecordsManageMentModel.TG) < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "甘油三酯↓,";
                        }
                        else if (Convert.ToDecimal(RecordsManageMentModel.TG) > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "甘油三酯↑,";
                        }
                    }
                    else if (dr2.Length > 0)
                    {
                        if (Convert.ToDecimal(RecordsManageMentModel.TG) < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "甘油三酯↓,";
                        }
                        else if (Convert.ToDecimal(RecordsManageMentModel.TG) > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "甘油三酯↑,";
                        }
                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.LowCho)))
                {
                    if (Model.Sex == "1")
                    {
                        strSCRItem = "血清低密度脂蛋白胆固醇男";
                    }
                    else if (Model.Sex == "2")
                    {
                        strSCRItem = "血清低密度脂蛋白胆固醇女";
                    }

                    DataRow[] dr = dtSH.Select("name='" + strSCRItem + "'");
                    DataRow[] dr2 = dtSH.Select("name='血清低密度脂蛋白胆固醇'");

                    if (dr.Length > 0)
                    {
                        if (Convert.ToDecimal(RecordsManageMentModel.LowCho) < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血清低密度脂蛋白胆固醇↓,";
                        }
                        else if (Convert.ToDecimal(RecordsManageMentModel.LowCho) > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血清低密度脂蛋白胆固醇↑,";
                        }
                    }
                    else if (dr2.Length > 0)
                    {
                        if (Convert.ToDecimal(RecordsManageMentModel.LowCho) < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血清低密度脂蛋白胆固醇↓,";
                        }
                        else if (Convert.ToDecimal(RecordsManageMentModel.LowCho) > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血清低密度脂蛋白胆固醇↑,";
                        }
                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.HeiCho)))
                {
                    if (Model.Sex == "1")
                    {
                        strSCRItem = "血清高密度脂蛋白胆固醇男";
                    }
                    else if (Model.Sex == "2")
                    {
                        strSCRItem = "血清高密度脂蛋白胆固醇女";
                    }

                    DataRow[] dr = dtSH.Select("name='" + strSCRItem + "'");
                    DataRow[] dr2 = dtSH.Select("name='血清高密度脂蛋白胆固醇'");

                    if (dr.Length > 0)
                    {
                        if (Convert.ToDecimal(RecordsManageMentModel.HeiCho) < Convert.ToDecimal(dr[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血清高密度脂蛋白胆固醇↓,";
                        }
                        else if (Convert.ToDecimal(RecordsManageMentModel.HeiCho) > Convert.ToDecimal(dr[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血清高密度脂蛋白胆固醇↑,";
                        }
                    }
                    else if (dr2.Length > 0)
                    {
                        if (Convert.ToDecimal(RecordsManageMentModel.HeiCho) < Convert.ToDecimal(dr2[0]["minvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血清高密度脂蛋白胆固醇↓,";
                        }
                        else if (Convert.ToDecimal(RecordsManageMentModel.HeiCho) > Convert.ToDecimal(dr2[0]["maxvalue"].ToString()))
                        {
                            strshxqex = strshxqex + "血清高密度脂蛋白胆固醇↑,";
                        }
                    }
                }
                return strshxqex.TrimEnd(',');
            }
            #endregion

            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.TC)) && item["name"].ToString() == "总胆固醇") //总胆固醇    ------》生化 范围3.1-6.1mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.TC) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "总胆固醇↓,";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.TC) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "总胆固醇↑,";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.TG)) && item["name"].ToString() == "甘油三酯") //甘油三酯    ------》生化 范围0.4-1.81mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.TG) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "甘油三酯↓,";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.TG) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "甘油三酯↑,";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.LowCho)) && item["name"].ToString() == "血清低密度脂蛋白胆固醇") //血清低密度脂蛋白胆固醇    ------》生化 范围0-3.1mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.LowCho) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清低密度脂蛋白胆固醇↓,";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.LowCho) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清低密度脂蛋白胆固醇↑,";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.HeiCho)) && item["name"].ToString() == "血清高密度脂蛋白胆固醇") //血清高密度脂蛋白胆固醇    ------》生化 范围1.07--1.89mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.HeiCho) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清高密度脂蛋白胆固醇↓,";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.HeiCho) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清高密度脂蛋白胆固醇↑,";
                    }
                    continue;
                }
            }

            return strshxqex.TrimEnd(',');
        }

        private string GetXZexValue(DataTable dtSH) //血脂异常--4个
        {
            string strshxqex = "";

            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.TC)) && item["name"].ToString() == "总胆固醇") //总胆固醇    ------》生化 范围3.1-6.1mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.TC) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "总胆固醇:" + RecordsManageMentModel.TC + item["measurement"].ToString() + " ↓;";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.TC) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "总胆固醇:" + RecordsManageMentModel.TC + item["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "总胆固醇↑,";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.TG)) && item["name"].ToString() == "甘油三酯") //甘油三酯    ------》生化 范围0.4-1.81mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.TG) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "甘油三酯:" + RecordsManageMentModel.TG + item["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "甘油三酯↓,";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.TG) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "甘油三酯:" + RecordsManageMentModel.TG + item["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "甘油三酯↑,";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.LowCho)) && item["name"].ToString() == "血清低密度脂蛋白胆固醇") //血清低密度脂蛋白胆固醇    ------》生化 范围0-3.1mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.LowCho) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清低密度脂蛋白胆固醇:" + RecordsManageMentModel.LowCho + item["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "血清低密度脂蛋白胆固醇↓,";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.LowCho) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清低密度脂蛋白胆固醇:" + RecordsManageMentModel.LowCho + item["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "血清低密度脂蛋白胆固醇↑,";
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.HeiCho)) && item["name"].ToString() == "血清高密度脂蛋白胆固醇") //血清高密度脂蛋白胆固醇    ------》生化 范围1.07--1.89mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.HeiCho) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清高密度脂蛋白胆固醇:" + RecordsManageMentModel.HeiCho + item["measurement"].ToString() + " ↓;";
                        //strshxqex = strshxqex + "血清高密度脂蛋白胆固醇↓,";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.HeiCho) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "血清高密度脂蛋白胆固醇:" + RecordsManageMentModel.HeiCho + item["measurement"].ToString() + " ↑;";
                        //strshxqex = strshxqex + "血清高密度脂蛋白胆固醇↑,";
                    }
                    continue;
                }
            }

            return strshxqex.TrimEnd(';');
        }

        /// <summary>
        /// 小孟镇 血脂异常
        /// </summary>
        /// <param name="dtSH"></param>
        /// <returns></returns>
        private void GetXZexValueByXMZ(DataTable dtSH) //血脂异常--4个
        {
            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.TC)) && item["name"].ToString() == "总胆固醇") //总胆固醇    ------》生化 范围3.1-6.1mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.TC) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("总胆固醇低:" + RecordsManageMentModel.TC + item["measurement"].ToString() + ";", "总胆固醇");
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.TC) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("总胆固醇高:" + RecordsManageMentModel.TC + item["measurement"].ToString() + ";", "总胆固醇");
                    }
                    continue;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.TG)) && item["name"].ToString() == "甘油三酯") //甘油三酯    ------》生化 范围0.4-1.81mmol/L
                {
                    if (Convert.ToDouble(RecordsManageMentModel.TG) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("甘油三酯低:" + RecordsManageMentModel.TG + item["measurement"].ToString() + ";", "甘油三酯");
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.TG) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        yichang++;
                        SetStrEx("甘油三酯高:" + RecordsManageMentModel.TG + item["measurement"].ToString() + ";", "甘油三酯");
                    }
                    continue;
                }
                //else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.LowCho)) && item["name"].ToString() == "血清低密度脂蛋白胆固醇") //血清低密度脂蛋白胆固醇    ------》生化 范围0-3.1mmol/L
                //{
                //    //if (Convert.ToDouble(RecordsManageMentModel.LowCho) < Convert.ToDouble(item["minvalue"].ToString()))
                //    //{
                //    //    yichang++;
                //    //    SetStrEx("血清低密度脂蛋白胆固醇低:" + RecordsManageMentModel.LowCho + item["measurement"].ToString() + ";", "血清低密度脂蛋白胆固醇");
                //    //}
                //    //else
                //    if (Convert.ToDouble(RecordsManageMentModel.LowCho) > Convert.ToDouble(item["maxvalue"].ToString()))
                //    {
                //        yichang++;
                //        SetStrEx("血清低密度脂蛋白胆固醇高:" + RecordsManageMentModel.LowCho + item["measurement"].ToString() + ";", "血清低密度脂蛋白胆固醇");
                //    }
                //    continue;
                //}
                //else if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.HeiCho)) && item["name"].ToString() == "血清高密度脂蛋白胆固醇") //血清高密度脂蛋白胆固醇    ------》生化 范围1.07--1.89mmol/L
                //{
                //    if (Convert.ToDouble(RecordsManageMentModel.HeiCho) < Convert.ToDouble(item["minvalue"].ToString()))
                //    {
                //        yichang++;
                //        SetStrEx("血清高密度脂蛋白胆固醇低:" + RecordsManageMentModel.HeiCho + item["measurement"].ToString() + ";", "血清高密度脂蛋白胆固醇");
                //    }
                //    //else if (Convert.ToDouble(RecordsManageMentModel.HeiCho) > Convert.ToDouble(item["maxvalue"].ToString()))
                //    //{
                //    //    yichang++;
                //    //    SetStrEx("血清高密度脂蛋白胆固醇高:" + RecordsManageMentModel.HeiCho + item["measurement"].ToString() + ";", "血清高密度脂蛋白胆固醇");
                //    //}
                //    continue;
                //}
            }
        }

        /// <summary>
        /// 同型半胱氨酸
        /// </summary>
        /// <param name="dtSH"></param>
        /// <returns></returns>
        private string GetHCYex(DataTable dtSH)
        {
            string strshxqex = "";

            foreach (DataRow item in dtSH.Rows)
            {
                if (!string.IsNullOrEmpty(toString(RecordsManageMentModel.HCY)) && item["name"].ToString() == "同型半胱氨酸")
                {
                    if (Convert.ToDouble(RecordsManageMentModel.HCY) < Convert.ToDouble(item["minvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "同型半胱氨酸:" + RecordsManageMentModel.HCY + item["measurement"].ToString() + " ↓;";
                    }
                    else if (Convert.ToDouble(RecordsManageMentModel.HCY) > Convert.ToDouble(item["maxvalue"].ToString()))
                    {
                        strshxqex = strshxqex + "同型半胱氨酸:" + RecordsManageMentModel.HCY + item["measurement"].ToString() + " ↑;";
                    }
                    continue;
                }
            }

            return strshxqex;
        }

        /// <summary>
        /// 老年人自理能力
        /// </summary>
        /// <returns></returns>
        public string GetSelf()
        {
            string strSelf = "";

            if (!string.IsNullOrEmpty(RecordsManageMentModel.OldSelfCareability))
            {
                switch (RecordsManageMentModel.OldSelfCareability)
                {
                    case "2":
                        strSelf = "轻度依赖";
                        break;
                    case "3":
                        strSelf = "中度依赖";
                        break;
                    case "4":
                        strSelf = "不能自理";
                        break;
                    default:
                        break;
                }
            }
            return strSelf;
        }

        public string GetSymptom()
        {
            string strSym = "";
            if (!string.IsNullOrEmpty(RecordsManageMentModel.Symptom))
            {
                char[] chArray2 = new char[] { ',' };
                string[] array = RecordsManageMentModel.Symptom.Split(chArray2);
                foreach (string c in array)
                {
                    switch (c)
                    {
                        case "2":
                            strSym += "头痛,";
                            break;
                        case "3":
                            strSym += "头晕,";
                            break;
                        case "4":
                            strSym += "心悸,";
                            break;
                        case "5":
                            strSym += "胸闷,";
                            break;
                        case "6":
                            strSym += "胸痛,";
                            break;
                        case "7":
                            strSym += "慢性咳嗽,";
                            break;
                        case "8":
                            strSym += "咳痰,";
                            break;
                        case "9":
                            strSym += "呼吸困难,";
                            break;
                        case "10":
                            strSym += "多饮,";
                            break;
                        case "11":
                            strSym += "多尿,";
                            break;
                        case "12":
                            strSym += "体重下降,";
                            break;
                        case "13":
                            strSym += "乏力,";
                            break;
                        case "14":
                            strSym += "关节肿痛,";
                            break;
                        case "15":
                            strSym += "视力模糊,";
                            break;
                        case "16":
                            strSym += "手脚麻木,";
                            break;
                        case "17":
                            strSym += "尿急,";
                            break;
                        case "18":
                            strSym += "尿痛,";
                            break;
                        case "19":
                            strSym += "便秘,";
                            break;
                        case "20":
                            strSym += "腹泻,";
                            break;
                        case "21":
                            strSym += "恶心呕吐,";
                            break;
                        case "22":
                            strSym += "眼花,";
                            break;
                        case "23":
                            strSym += "耳鸣,";
                            break;
                        case "24":
                            strSym += "乳房胀痛,";
                            break;
                        case "25":
                            if (!string.IsNullOrEmpty(RecordsManageMentModel.SymptomOther))
                            {
                                strSym += "其他:" + RecordsManageMentModel.SymptomOther + ",";
                            }
                            else
                            {
                                strSym += "其他,";
                            }
                            break;
                        default: break;
                    }
                }


            }
            return strSym.TrimEnd(',');
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
    }
}