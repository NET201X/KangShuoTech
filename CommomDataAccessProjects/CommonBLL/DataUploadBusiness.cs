using CommomUtilities.Common;
using Newtonsoft.Json;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Net.Sockets;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Xml;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class DataUploadBusiness
    {
        RecordsBaseInfoBLL baseInfoBLL = new RecordsBaseInfoBLL();
        CommonClassBLL commonClass = new CommonClassBLL();
        RecordsGeneralConditionBLL recordsGeneralConditionBLL = new RecordsGeneralConditionBLL();
        DeviceInfoBLL deviceInfoBLL = new DeviceInfoBLL();
        DeviceInfoSqliteBLL deviceInfoSqliteBLL = new DeviceInfoSqliteBLL();
        DataUploadSqliteBLL dataUploadSqliteBLL = new DataUploadSqliteBLL();
        RecordsMedicationSqliteBLL recordsMedicationSqliteBLL = new RecordsMedicationSqliteBLL();
        OldSelfSqlitBLL oldSelfSqlitBLL = new OldSelfSqlitBLL();
        RecordsMedicineResultSqliteBLL recordsMedicineResultSqliteBLL = new RecordsMedicineResultSqliteBLL();
        OldGlolmyAndIntelligenceBLL oldGlolmyAndIntelligenceBLL = new OldGlolmyAndIntelligenceBLL();
        RecordsAssistCheckBLL recordsAssistCheckBLL = new RecordsAssistCheckBLL();
        RecordsCustomerBaseInfoBLL recordsCustomerBaseInfoBLL = new RecordsCustomerBaseInfoBLL();
        RecordsHealthQuestionBLL recordsHealthQuestionBLL = new RecordsHealthQuestionBLL();
        RecordsPhysicalExamBLL recordsPhysicalExamBLL = new RecordsPhysicalExamBLL();
        RecordsVisceraFunctionBLL recordsVisceraFunctionBLL = new RecordsVisceraFunctionBLL();
        AccessClassBLL accessClassBLL = new AccessClassBLL();
        RecordsxqBLL recordsXQBLL = new RecordsxqBLL();
        RecordsEcgBLL recordsEcgBLL = new RecordsEcgBLL();
        OlderSelfCareabilityBLL oldSelfCareBLL = new OlderSelfCareabilityBLL();
        RecordsSelfcareabilityBLL selfCareBLL = new RecordsSelfcareabilityBLL();
        XinJiangSeparationSqliteBLL separationBLL = new XinJiangSeparationSqliteBLL();
        RecordsMedicineResultBLL recordsMedicineResultBLL = new RecordsMedicineResultBLL();
        RecordsMedicineCnBLL recordsMedicineCnBLL = new RecordsMedicineCnBLL();
        OlderMedicineResultBLL oldRecordsMedicineResultBLL = new OlderMedicineResultBLL();
        OlderMedicineCnBLL oldRecordsMedicineCnBLL = new OlderMedicineCnBLL();
        OldMedGuideBLL oldMedGuideBLL = new OldMedGuideBLL();
        RecordsHealthConditionBLL conditionBLL = new RecordsHealthConditionBLL();
        TypeBBLL typeBBLL = new TypeBBLL();
        DataTable dtUpload = new DataTable();
        public string[] postUrl = { };

        #region 同步图片路径

        string strFromPathInfo = "";
        string strToEcgPath = @"D:\QCSoft\ECGPDF"; // 路径中不包含outFile，在同步时固定加上的
        string strToPath = @"D:\QCSoft\心电图";
        string strToTypeBPath = @"D:\QCSoft\TypeB";
        string strToPathInfo2 = @"D:\QCSoft\B超图";
        string strToChestX = @"D:\QCSoft\ChestX";//DR X光保存地址

        // 居民签名
        string strFromSign = ConfigurationManager.AppSettings["OldPNGFrom"] == null ? @"\\QC\Sign" : ConfigurationManager.AppSettings["OldPNGFrom"].ToString();
        string strToSign = @"D:\QCSoft\OldPNG\Sign\";

        // 指纹
        string strFromFinger = ConfigurationManager.AppSettings["FingerPNGFrom"] == null ? @"\\QC\Finger" : ConfigurationManager.AppSettings["FingerPNGFrom"].ToString();
        string strToFinger = @"D:\QCSoft\FingerPNG\Finger\";

        #endregion

        #region Setting变量

        // 版本号 医院名 地区名称 城市 随访医生 左侧或右侧血压或双侧 是否自动计算另一侧血压 下次随访日期
        string versionNo = "", community = "", area = "", city = "", doctor = "", LRType = "", IsAutoCal = "", NextVisitDate = "";

        // 是否新版B超
        public string isNewTypeB = "",DR = "";

        #endregion

        // 心电同步pad类型（1：之前心电；2：新版心电）
        public string ecgType { get; set; }

        public CombinUploadData cud { get; set; }

        public string startDate { get; set; }

        public string endDate { get; set; }

        public RecordsHealthQuestionModel QuestionModel { get; set; }

        // 连接字串
        string SugarSqlite = "", BMSqlite = "", BHSqlite = "", BPSqlite = "", EMPSqlite = "", EMPSqlite2 = "", BiochemicalConn = "", BiochemicalConn2 = "", firebird2 = "", IonConn = "",
            BloodCorpuscleConn = "", BloodCorpuscleConn2 = "", EcgSqlite = "", EcgSqlite2 = "", EcgSqlite3 = "", TypeBConn = "", TypeBConn2 = "", TypeBConn3 = "", MESqlite = "",
            OldSqlite = "", OldSqlite2 = "", QCVsiual = "", SurgicalSqlite = "", SurgicalSqlite2 = "", InternalSqlite = "", InternalSqlite2 = "", MouthSqlite = "", ChestXSqlite = "", ChestXAccess = "", strFromChestX="";

        #region 自定义方法

        public delegate void UpdateProgressBarDelegate(System.Windows.DependencyProperty dp, Object value);

        public Configuration GetConfig()
        {
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = Application.StartupPath + @"\PadPlatform.exe.config";

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            return config;
        }

        public void GetSetting(string path)
        {
            // 版本号
            versionNo = ConfigHelper.GetSetNode("versionNo", path);

            // 医院名
            community = ConfigHelper.GetSetNode("community", path);

            // 地区名称
            area = ConfigHelper.GetSetNode("area", path);

            // 城市
            city = ConfigHelper.GetSetNode("city", path);

            // 随访医生
            doctor = ConfigHelper.GetSetNode("medDoctor", path);

            // 取得设定的左侧或右侧血压或双侧
            LRType = ConfigHelper.GetSetNode("LRType", path) != "" ? ConfigHelper.GetSetNode("LRType", path) : "左侧";

            // 是否新版B超
            isNewTypeB = ConfigHelper.GetSetNode("IsNewTypeB", path);

            //DR同步
            DR = ConfigHelper.GetSetNode("DR", path);

            // 是否自动计算另一侧血压
            IsAutoCal = ConfigHelper.GetSetNode("IsAutoCal", path);

            // 下次随访日期
            NextVisitDate = ConfigHelper.GetSetNode("NextVisitDate", path);
        }

        /// <summary>
        /// 取得连接字串
        /// </summary>
        private void GetConnection()
        {
            Configuration config = GetConfig();

            // 血压连接
            BPSqlite = config.ConnectionStrings.ConnectionStrings["BPsqlite"] == null ? "" : config.ConnectionStrings.ConnectionStrings["BPsqlite"].ToString();

            // 血糖连接
            SugarSqlite = config.ConnectionStrings.ConnectionStrings["SugarSqlite"] == null ? BPSqlite : config.ConnectionStrings.ConnectionStrings["SugarSqlite"].ToString();

            // 体温体重连接
            BMSqlite = config.ConnectionStrings.ConnectionStrings["BMSqlite"] == null ? BPSqlite : config.ConnectionStrings.ConnectionStrings["BMSqlite"].ToString();

            // 身高体重连接
            BHSqlite = config.ConnectionStrings.ConnectionStrings["BHSqlite"] == null ? BPSqlite : config.ConnectionStrings.ConnectionStrings["BHSqlite"].ToString();

            // 尿机连接
            EMPSqlite = config.ConnectionStrings.ConnectionStrings["EMPSqlite"] == null ? BPSqlite : config.ConnectionStrings.ConnectionStrings["EMPSqlite"].ToString();

            // 尿机连接2
            EMPSqlite2 = config.ConnectionStrings.ConnectionStrings["EMPSqlite2"] == null ? "" : config.ConnectionStrings.ConnectionStrings["EMPSqlite2"].ToString();

            // 问询连接
            MESqlite = config.ConnectionStrings.ConnectionStrings["MESqlite"] == null ? BPSqlite : config.ConnectionStrings.ConnectionStrings["MESqlite"].ToString();

            // 中医连接
            OldSqlite = config.ConnectionStrings.ConnectionStrings["OldSqlite"] == null ? BPSqlite : config.ConnectionStrings.ConnectionStrings["OldSqlite"].ToString();

            // 中医连接2(重庆 凤凰镇社区卫生服务中心)
            OldSqlite2 = config.ConnectionStrings.ConnectionStrings["OldSqlite2"] == null ? BPSqlite : config.ConnectionStrings.ConnectionStrings["OldSqlite2"].ToString();

            // 五官连接
            MouthSqlite = config.ConnectionStrings.ConnectionStrings["MouthSqlite"] == null ? BPSqlite : config.ConnectionStrings.ConnectionStrings["MouthSqlite"].ToString();

            // X光连接
            ChestXSqlite = config.ConnectionStrings.ConnectionStrings["ChestXSqlite"] == null ? BPSqlite : config.ConnectionStrings.ConnectionStrings["ChestXSqlite"].ToString();

            // 视力连接
            QCVsiual = config.AppSettings.Settings["QCVsiual"] == null ? "" : config.AppSettings.Settings["QCVsiual"].Value;

            // 离子连接
            IonConn = config.ConnectionStrings.ConnectionStrings["QClizi"] == null ? "" : config.ConnectionStrings.ConnectionStrings["QClizi"].ToString();

            // 安徽X光连接
            ChestXAccess = config.ConnectionStrings.ConnectionStrings["ChestX"] == null ? "" : config.ConnectionStrings.ConnectionStrings["ChestX"].ToString();

            // 外科连接
            SurgicalSqlite = config.ConnectionStrings.ConnectionStrings["SurgicalSqlite"] == null ? BPSqlite : config.ConnectionStrings.ConnectionStrings["SurgicalSqlite"].ToString();
            SurgicalSqlite2 = config.ConnectionStrings.ConnectionStrings["SurgicalSqlite2"] == null ? SurgicalSqlite :
                config.ConnectionStrings.ConnectionStrings["SurgicalSqlite2"].ToString();  // 外科连接2

            // 内科连接
            InternalSqlite = config.ConnectionStrings.ConnectionStrings["InternalSqlite"] == null ? BPSqlite : config.ConnectionStrings.ConnectionStrings["SurgicalSqlite"].ToString();
            InternalSqlite2 = config.ConnectionStrings.ConnectionStrings["InternalSqlite2"] == null ? InternalSqlite :
                config.ConnectionStrings.ConnectionStrings["InternalSqlite2"].ToString();  // 内科连接2

            // 血球连接
            BloodCorpuscleConn = config.ConnectionStrings.ConnectionStrings["QCxueqiu"] == null ? "" : config.ConnectionStrings.ConnectionStrings["QCxueqiu"].ToString();
            BloodCorpuscleConn2 = config.ConnectionStrings.ConnectionStrings["QCxueqiu2"] == null ? BloodCorpuscleConn :
                config.ConnectionStrings.ConnectionStrings["QCxueqiu2"].ToString();  // 血球连接2

            // 生化连接
            BiochemicalConn = config.ConnectionStrings.ConnectionStrings["QCshenghua"].ToString() == null ? "" : config.ConnectionStrings.ConnectionStrings["QCshenghua"].ToString();
            BiochemicalConn2 = config.ConnectionStrings.ConnectionStrings["QCshenghua2"] == null ? BiochemicalConn :
                config.ConnectionStrings.ConnectionStrings["QCshenghua2"].ToString();  // 生化连接2

            // 心电连接
            EcgSqlite = config.ConnectionStrings.ConnectionStrings["sqlite"] == null ? "" : config.ConnectionStrings.ConnectionStrings["sqlite"].ToString();
            EcgSqlite2 = config.ConnectionStrings.ConnectionStrings["sqlite2"] == null ? EcgSqlite :
                config.ConnectionStrings.ConnectionStrings["sqlite2"].ToString();  // 心电连接2
            EcgSqlite3 = config.ConnectionStrings.ConnectionStrings["sqlite3"] == null ? EcgSqlite :
                config.ConnectionStrings.ConnectionStrings["sqlite3"].ToString();  // 心电连接3

            firebird2 = config.ConnectionStrings.ConnectionStrings["firebird2"] == null ? "" :
                config.ConnectionStrings.ConnectionStrings["firebird2"].ToString();  // B超连接2

            // 如果为新版B超
            if (isNewTypeB.Equals("Y"))
            {
                TypeBConn = config.ConnectionStrings.ConnectionStrings["TypeB"] == null ? "" : config.ConnectionStrings.ConnectionStrings["TypeB"].ToString();  // B超连接
                TypeBConn2 = config.ConnectionStrings.ConnectionStrings["TypeB2"] == null ? TypeBConn :
                    config.ConnectionStrings.ConnectionStrings["TypeB2"].ToString();  // B超连接2
                TypeBConn3 = config.ConnectionStrings.ConnectionStrings["TypeB3"] == null ? TypeBConn :
                    config.ConnectionStrings.ConnectionStrings["TypeB3"].ToString();  // B超连接3
            }
            else
            {
                TypeBConn = config.ConnectionStrings.ConnectionStrings["firebird"] == null ? "" : config.ConnectionStrings.ConnectionStrings["firebird"].ToString();  // B超连接
                TypeBConn2 = config.ConnectionStrings.ConnectionStrings["firebird2"] == null ? TypeBConn :
                    config.ConnectionStrings.ConnectionStrings["firebird2"].ToString();  // B超连接2
                TypeBConn3 = config.ConnectionStrings.ConnectionStrings["firebird3"] == null ? TypeBConn :
                    config.ConnectionStrings.ConnectionStrings["firebird3"].ToString();  // B超连接3
            }

            strFromSign = config.AppSettings.Settings["OldPNGFrom"] == null ? @"\\QC\Sign" : config.AppSettings.Settings["OldPNGFrom"].Value;
            strFromFinger = config.AppSettings.Settings["FingerPNGFrom"] == null ? @"\\QC\Finger" : config.AppSettings.Settings["FingerPNGFrom"].Value;
            //DR图片同步路径
            strFromChestX = config.AppSettings.Settings["ChestXBMPFrom"] == null ? @"\\QC\ChestXBMPFrom" : config.AppSettings.Settings["ChestXBMPFrom"].Value;
        }

        /// <summary>
        /// 根据连接字串取得图片路径
        /// </summary>
        /// <param name="appSettingName"></param>
        /// <param name="defaultValue"></param>
        public void GetFromPath(string appSettingName, string defaultValue)
        {
            Configuration config = GetConfig();

            if (isNewTypeB.Equals("Y"))
            {
                appSettingName = config.AppSettings.Settings[appSettingName.Replace("filefrom", "filefromNew")] == null ? appSettingName : appSettingName.Replace("filefrom", "filefromNew");
            }

            strFromPathInfo = config.AppSettings.Settings[appSettingName] != null ? config.AppSettings.Settings[appSettingName].Value : defaultValue;
        }

        /// <summary>
        /// 取得随机数
        /// </summary>
        /// <returns></returns>
        private int GetRandom()
        {
            int n = 0, m = 0;
            Random ran = new Random();
            n = ran.Next(1, 8);

            while (m < n) m = ran.Next(1, 8);

            return m;
        }

        /// <summary>
        /// 将尿仪数据+1、+2改为+、++
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetExNiaoPlus(string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            value = value.Replace("+1", "+").Replace("+2", "++").Replace("+3", "+++").Replace("+4", "++++").Replace("+5", "+++++").
                Replace("+6", "++++++").Replace("+7", "+++++++").Replace("+8", "+++++++++").Replace("1+", "+").Replace("2+", "++").Replace("3+", "+++").
                Replace("4+", "++++").Replace("5+", "+++++").Replace("6+", "++++++").Replace("7+", "+++++++").Replace("8+", "+++++++++");

            if (community == "小孟镇")
            {
                value = value.Replace("+-", "±");
            }
            else if (area.Equals("乐亭县"))
            {
                value = "(" + value + ")";
            }

            return value;
        }

        /// <summary>
        /// 尿机Model赋值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="saveModel"></param>
        /// <param name="dataModel"></param>
        /// <param name="deciveModel"></param>
        public void SetUrineModel(DataRow row, ref RecordsAssistCheckModel saveModel, ref DataModel dataModel, ref DeviceInfoModel deciveModel)
        {
            if (row != null)
            {
                #region 项目赋值

                dataModel.IDCardNo = row["IDCardNo"].ToString();
                dataModel.BarCode = row.Table.Columns.Contains("BarCode") ? row["BarCode"].ToString() : "";
                dataModel.PRO = row["PRO"].ToString().ToUpper().Replace("TRACE", "+");//蛋白质--尿蛋白;
                dataModel.GLU = row["GLU"].ToString();
                dataModel.KET = row["KET"].ToString();
                dataModel.BLD = row["BLD"].ToString();
                dataModel.LEU = row["LEU"].ToString();

                deciveModel.DeviceType = "33";
                deciveModel.DeviceName = "尿液分析";
                deciveModel.IDCardNo = dataModel.IDCardNo;
                deciveModel.BarCode = dataModel.BarCode;
                deciveModel.Value2 = dataModel.BLD;
                deciveModel.Value4 = dataModel.KET;
                deciveModel.Value5 = dataModel.GLU;
                deciveModel.Value6 = dataModel.PRO;
                deciveModel.Value9 = dataModel.LEU;

                DateTime dt = new DateTime();

                if (row.Table.Columns.Contains("TestTime"))
                {
                    if (DateTime.TryParse(row["TestTime"].ToString(), out dt))
                    {
                        dataModel.TestTime = dt;
                    }
                }

                deciveModel.UpdateData = dataModel.TestTime.ToString("yyyy-MM-dd HH:mm:dd");
                dataModel.NIT = row.Table.Columns.Contains("NIT") ? row["NIT"].ToString() : "";//亚硝酸盐 Value8
                dataModel.BIT_U = row.Table.Columns.Contains("BIT_U") ? row["BIT_U"].ToString() : "";//胆红素 Value3
                dataModel.PH = row.Table.Columns.Contains("PH") ? row["PH"].ToString() : "";//PH Value7
                dataModel.SG = row.Table.Columns.Contains("SG") ? row["SG"].ToString() : "";//比重 Value10
                dataModel.ASC_U = row.Table.Columns.Contains("ASC_U") ? row["ASC_U"].ToString() : "";//维生素C Value11
                dataModel.UBG = row.Table.Columns.Contains("UBG") ? row["UBG"].ToString() : "";//尿胆原 Value1

                deciveModel.Value1 = dataModel.UBG;
                deciveModel.Value3 = dataModel.BIT_U;
                deciveModel.Value7 = dataModel.PH;
                deciveModel.Value8 = dataModel.NIT;
                deciveModel.Value10 = dataModel.SG;
                deciveModel.Value11 = dataModel.ASC_U;

                if (area == "济宁" || area.Equals("乐亭县"))
                {
                    deciveModel.Value2 = GetExNiaoPlus(deciveModel.Value2.ToString());//潜血---尿潜血
                    deciveModel.Value4 = GetExNiaoPlus(deciveModel.Value4.ToString());//酮体---尿酮体
                    deciveModel.Value5 = GetExNiaoPlus(deciveModel.Value5.ToString());//葡萄糖--尿糖
                    deciveModel.Value6 = GetExNiaoPlus(deciveModel.Value6.ToString().ToUpper().Replace("TRACE", "+"));//蛋白质--尿蛋白
                }

                deciveModel.Value1 = StringPlus.toString(deciveModel.Value1);
                deciveModel.Value3 = StringPlus.toString(deciveModel.Value3);
                deciveModel.Value7 = StringPlus.toString(deciveModel.Value7);
                deciveModel.Value8 = StringPlus.toString(deciveModel.Value8);
                deciveModel.Value9 = StringPlus.toString(deciveModel.Value9);
                deciveModel.Value10 = StringPlus.toString(deciveModel.Value10);
                deciveModel.Value11 = StringPlus.toString(deciveModel.Value11);
                deciveModel.Value1 = (area.Equals("乐亭县") ? GetExNiaoPlus(deciveModel.Value1.ToString()) : deciveModel.Value1.ToString());
                deciveModel.Value3 = (area.Equals("乐亭县") ? GetExNiaoPlus(deciveModel.Value3.ToString()) : deciveModel.Value3.ToString());
                deciveModel.Value7 = (area.Equals("乐亭县") ? GetExNiaoPlus(deciveModel.Value7.ToString()) : deciveModel.Value7.ToString());
                deciveModel.Value8 = (area.Equals("乐亭县") ? GetExNiaoPlus(deciveModel.Value8.ToString()) : deciveModel.Value8.ToString());
                deciveModel.Value9 = (area.Equals("乐亭县") ? GetExNiaoPlus(deciveModel.Value9.ToString()) : deciveModel.Value9.ToString());
                deciveModel.Value10 = (area.Equals("乐亭县") ? GetExNiaoPlus(deciveModel.Value10.ToString()) : deciveModel.Value10.ToString());
                deciveModel.Value11 = (area.Equals("乐亭县") ? GetExNiaoPlus(deciveModel.Value11.ToString()) : deciveModel.Value11.ToString());

                #endregion
            }
            else
            {
                saveModel.IDCardNo = deciveModel.IDCardNo;

                if (area == "济宁" || area.Equals("乐亭县"))
                {
                    saveModel.BLD = GetExNiaoPlus(deciveModel.Value2.ToString());//潜血---尿潜血
                    saveModel.KET = GetExNiaoPlus(deciveModel.Value4.ToString());//酮体---尿酮体
                    saveModel.GLU = GetExNiaoPlus(deciveModel.Value5.ToString());//葡萄糖--尿糖
                    saveModel.PRO = GetExNiaoPlus(deciveModel.Value6.ToString().ToUpper().Replace("TRACE", "+"));//蛋白质--尿蛋白
                }
                else
                {
                    saveModel.BLD = deciveModel.Value2.ToString();//潜血---尿潜血
                    saveModel.KET = deciveModel.Value4.ToString();//酮体---尿酮体
                    saveModel.GLU = deciveModel.Value5.ToString();//葡萄糖--尿糖
                    saveModel.PRO = deciveModel.Value6.ToString().ToUpper().Replace("TRACE", "+");//蛋白质--尿蛋白
                }

                deciveModel.Value2 = saveModel.BLD;
                deciveModel.Value4 = saveModel.KET;
                deciveModel.Value5 = saveModel.GLU;
                deciveModel.Value6 = saveModel.PRO;
                deciveModel.Value1 = StringPlus.toString(deciveModel.Value1);
                deciveModel.Value3 = StringPlus.toString(deciveModel.Value3);
                deciveModel.Value7 = StringPlus.toString(deciveModel.Value7);
                deciveModel.Value8 = StringPlus.toString(deciveModel.Value8);
                deciveModel.Value9 = StringPlus.toString(deciveModel.Value9);
                deciveModel.Value10 = StringPlus.toString(deciveModel.Value10);
                deciveModel.Value11 = StringPlus.toString(deciveModel.Value11);
            }

            #region 吉林 、江苏、浙江、山东、河北、贵州、陕西、福清惠铭医院 尿其他

            string NiaoQt = "";

            if (versionNo.Contains("吉林") || versionNo.Contains("江苏") || versionNo.Contains("浙江") || versionNo.Contains("山东") ||
                versionNo.Contains("河北") || community.Contains("福清惠铭医院"))
            {
                deciveModel.Value1 = (area.Equals("乐亭县") ? GetExNiaoPlus(deciveModel.Value1.ToString()) : deciveModel.Value1.ToString());
                deciveModel.Value3 = (area.Equals("乐亭县") ? GetExNiaoPlus(deciveModel.Value3.ToString()) : deciveModel.Value3.ToString());
                deciveModel.Value7 = (area.Equals("乐亭县") ? GetExNiaoPlus(deciveModel.Value7.ToString()) : deciveModel.Value7.ToString());
                deciveModel.Value8 = (area.Equals("乐亭县") ? GetExNiaoPlus(deciveModel.Value8.ToString()) : deciveModel.Value8.ToString());
                deciveModel.Value9 = (area.Equals("乐亭县") ? GetExNiaoPlus(deciveModel.Value9.ToString()) : deciveModel.Value9.ToString());
                deciveModel.Value10 = (area.Equals("乐亭县") ? GetExNiaoPlus(deciveModel.Value10.ToString()) : deciveModel.Value10.ToString());
                deciveModel.Value11 = (area.Equals("乐亭县") ? GetExNiaoPlus(deciveModel.Value11.ToString()) : deciveModel.Value11.ToString());

                if (!string.IsNullOrEmpty(deciveModel.Value1) && deciveModel.Value1.Contains("+"))
                {
                    NiaoQt += " 尿胆原:" + deciveModel.Value1.ToString();
                }
                if (!string.IsNullOrEmpty(deciveModel.Value3) && deciveModel.Value3.Contains("+"))
                {
                    NiaoQt += " 胆红素:" + deciveModel.Value3.ToString();
                }
                if (!string.IsNullOrEmpty(deciveModel.Value7) && deciveModel.Value7.Contains("+"))
                {
                    NiaoQt += " PH:" + deciveModel.Value7.ToString();
                }
                if (!string.IsNullOrEmpty(deciveModel.Value8) && deciveModel.Value8.Contains("+"))
                {
                    NiaoQt += " 亚硝酸盐:" + deciveModel.Value8.ToString();
                }
                if (!string.IsNullOrEmpty(deciveModel.Value9) && deciveModel.Value9.Contains("+"))
                {
                    NiaoQt += " 白细胞:" + deciveModel.Value9.ToString();
                }
                if (!string.IsNullOrEmpty(deciveModel.Value10) && deciveModel.Value10.Contains("+"))
                {
                    NiaoQt += " 比重:" + deciveModel.Value10.ToString();
                }
                if (!string.IsNullOrEmpty(deciveModel.Value11) && deciveModel.Value11.Contains("+") && !community.Contains("福清惠铭医院"))
                {
                    NiaoQt += " 维生素C:" + deciveModel.Value11.ToString();
                }

                if (area.Equals("平度"))
                {
                    if (string.IsNullOrEmpty(NiaoQt)) NiaoQt = "-";
                }
            }
            else if (versionNo.Contains("贵州"))
            {
                if (!string.IsNullOrEmpty(deciveModel.Value9) && deciveModel.Value9.Contains("+"))
                {
                    NiaoQt += " 白细胞:" + deciveModel.Value9.ToString();
                }
            }
            else if (versionNo.Contains("陕西"))
            {
                #region  尿其他

                if (!string.IsNullOrEmpty(deciveModel.Value1))
                {
                    NiaoQt = " 尿胆原(" + deciveModel.Value1.ToString() + ")";
                }
                if (!string.IsNullOrEmpty(deciveModel.Value3))
                {
                    NiaoQt += " 胆红素(" + deciveModel.Value3.ToString() + ")";
                }
                if (!string.IsNullOrEmpty(deciveModel.Value7) && deciveModel.Value7.Contains("+"))
                {
                    NiaoQt += " PH(" + deciveModel.Value7.ToString() + ")";
                }
                if (!string.IsNullOrEmpty(deciveModel.Value8) && deciveModel.Value8.Contains("+"))
                {
                    NiaoQt += " 亚硝酸盐(" + deciveModel.Value8.ToString() + ")";
                }
                if (!string.IsNullOrEmpty(deciveModel.Value9) && deciveModel.Value9.Contains("+"))
                {
                    NiaoQt += " 白细胞(" + deciveModel.Value9.ToString() + ")";
                }
                if (!string.IsNullOrEmpty(deciveModel.Value10) && deciveModel.Value10.Contains("+"))
                {
                    NiaoQt += " 比重(" + deciveModel.Value10.ToString() + ")";
                }
                if (!string.IsNullOrEmpty(deciveModel.Value11) && deciveModel.Value11.Contains("+"))
                {
                    NiaoQt += " 维生素C(" + deciveModel.Value11.ToString() + ")";
                }

                #endregion
            }
            else if (area == "龙城")  //广西龙城
            {
                if (!string.IsNullOrEmpty(deciveModel.Value9) && deciveModel.Value9.Contains("+"))
                {
                    NiaoQt += " 白细胞(" + deciveModel.Value9.ToString() + ")";
                }
            }
            else if (area.Equals("梧州市"))  // 广西梧州市
            {
                if (!string.IsNullOrEmpty(deciveModel.Value9))
                {
                    NiaoQt += " 白细胞(" + deciveModel.Value9.ToString() + ")";
                }
            }

            if (area == "济宁")
            {
                saveModel.UrineOther = GetExNiaoPlus(NiaoQt);
                dataModel.UrineOther = GetExNiaoPlus(NiaoQt);
            }
            else
            {
                saveModel.UrineOther = NiaoQt;
                dataModel.UrineOther = NiaoQt;
            }

            #endregion
        }

        /// <summary>
        /// 生化血球Model赋值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="dtSH"></param>
        /// <param name="saveModel"></param>
        /// <param name="dataModel"></param>
        public void SetBloodModel(DataRow row, DataTable dtSH, ref RecordsAssistCheckModel saveModel, ref DataModel dataModel)
        {
            if (row != null)
            {
                #region 项目赋值

                dataModel.IDCardNo = StringPlus.toString(row["IDCardNo"]);
                dataModel.BarCode = row.Table.Columns.Contains("BarCode") ? StringPlus.toString(row["BarCode"]) : "";
                dataModel.HB = StringPlus.toString(row["HB"]);
                dataModel.WBC = StringPlus.toString(row["WBC"]);
                dataModel.PLT = StringPlus.toString(row["PLT"]);
                dataModel.PRO = StringPlus.toString(row["PRO"]).ToUpper().Replace("TRACE", "+");//蛋白质--尿蛋白;;
                dataModel.GLU = StringPlus.toString(row["GLU"]);
                dataModel.KET = StringPlus.toString(row["KET"]);
                dataModel.BLD = StringPlus.toString(row["BLD"]);
                dataModel.FPGL = StringPlus.toString(row["FPGL"]);
                dataModel.ALBUMIN = StringPlus.toString(row["ALBUMIN"]);
                dataModel.HBALC = StringPlus.toString(row["HBALC"]);
                dataModel.SGPT = StringPlus.toString(row["SGPT"]);
                dataModel.GOT = StringPlus.toString(row["GOT"]);
                dataModel.BP = StringPlus.toString(row["BP"]);
                dataModel.TBIL = StringPlus.toString(row["TBIL"]);
                dataModel.CB = StringPlus.toString(row["CB"]);
                dataModel.SCR = StringPlus.toString(row["SCR"]);
                dataModel.BUN = StringPlus.toString(row["BUN"]);
                dataModel.PC = StringPlus.toString(row["PC"]);
                dataModel.HYPE = StringPlus.toString(row["HYPE"]);
                dataModel.TC = StringPlus.toString(row["TC"]);
                dataModel.TG = StringPlus.toString(row["TG"]);
                dataModel.HDL_C = StringPlus.toString(row["HDL_C"]);
                dataModel.LDL_C = StringPlus.toString(row["LDL_C"]);
                dataModel.GT = StringPlus.toString(row["GT"]);

                dataModel.TP = row.Table.Columns.Contains("TP") ? StringPlus.toString(row["TP"]) : "";
                dataModel.GLB = row.Table.Columns.Contains("GLB") ? StringPlus.toString(row["GLB"]) : "";
                dataModel.AG = row.Table.Columns.Contains("AG") ? StringPlus.toString(row["AG"]) : "";
                dataModel.IBIL = row.Table.Columns.Contains("IBIL") ? StringPlus.toString(row["IBIL"]) : "";
                dataModel.UA = row.Table.Columns.Contains("UA") ? StringPlus.toString(row["UA"]) : ""; //尿酸
                dataModel.HCY = row.Table.Columns.Contains("HCY") ? StringPlus.toString(row["HCY"]) : "";
                dataModel.HBSAG = row.Table.Columns.Contains("HBSAG") ? StringPlus.toString(row["HBSAG"]) : "";
                dataModel.HBEAG = row.Table.Columns.Contains("HBEAG") ? StringPlus.toString(row["HBEAG"]) : "";
                dataModel.HBEAB = row.Table.Columns.Contains("HBEAB") ? StringPlus.toString(row["HBEAB"]) : "";
                dataModel.HBCAB = row.Table.Columns.Contains("HBCAB") ? StringPlus.toString(row["HBCAB"]) : "";
                dataModel.HBSAB = row.Table.Columns.Contains("HBSAB") ? StringPlus.toString(row["HBSAB"]) : "";
                dataModel.LEU = row.Table.Columns.Contains("LEU") ? StringPlus.toString(row["LEU"]) : "";  // 尿白细胞
                dataModel.ALP = row.Table.Columns.Contains("ALP") ? row["ALP"].ToString() : "";// 碱性磷酸酶

                DateTime dt = new DateTime();

                if (row.Table.Columns.Contains("TestTime"))
                {
                    if (DateTime.TryParse(row["TestTime"].ToString(), out dt))
                    {
                        dataModel.TestTime = dt;
                    }
                }

                if (row.Table.Columns.Contains("Bloodtype"))
                {
                    string strBlood = StringPlus.toString(row["Bloodtype"]);

                    if (!string.IsNullOrEmpty(strBlood))
                    {
                        switch (strBlood)
                        {
                            case "A型":
                                dataModel.BloodType = "1";
                                break;
                            case "B型":
                                dataModel.BloodType = "2";
                                break;
                            case "O型":
                                dataModel.BloodType = "3";
                                break;
                            case "AB型":
                                dataModel.BloodType = "4";
                                break;
                            default:
                                break;
                        }
                    }
                }

                // 计算空腹血糖
                if (versionNo.Contains("吉林") || versionNo.Contains("新疆"))
                {
                    decimal value = 0;
                    if (decimal.TryParse(dataModel.FPGL, out value))
                    {
                        dataModel.FPGDL = (value * 18).ToString();
                    }
                    else
                    {
                        dataModel.FPGDL = "";
                    }
                }

                #endregion

                #region 血球新增项目34个

                dataModel.NEU_B = row["NEU_B"].ToString();
                dataModel.LYMPH_B = row["LYMPH_B"].ToString();
                dataModel.MON_B = row["MON_B"].ToString();
                dataModel.EOS_B = row["EOS_B"].ToString();
                dataModel.BAS_B = row["BAS_B"].ToString();

                dataModel.NEU_N = row["NEU_N"].ToString();
                dataModel.LYMPH_N = row["LYMPH_N"].ToString();
                dataModel.EOS_N = row["EOS_N"].ToString();
                dataModel.MON_N = row["MON_N"].ToString();
                dataModel.BAS_N = row["BAS_N"].ToString();

                dataModel.RBC = row["RBC"].ToString();
                dataModel.HCT = row["HCT"].ToString();
                dataModel.MCV = row["MCV"].ToString();
                dataModel.MCH = row["MCH"].ToString();
                dataModel.MCHC = row["MCHC"].ToString();

                dataModel.RDW_CV = row["RDW_CV"].ToString();
                dataModel.RDW_SD = row["RDW_SD"].ToString();
                dataModel.MPV = row["MPV"].ToString();
                dataModel.PDW = row["PDW"].ToString();
                dataModel.PCT = row["PCT"].ToString();

                dataModel.MID_B = row.Table.Columns.Contains("MID_B") ? row["MID_B"].ToString() : "";
                dataModel.MID_N = row.Table.Columns.Contains("MID_N") ? row["MID_N"].ToString() : "";
                dataModel.P_LCR = row.Table.Columns.Contains("P_LCR") ? row["P_LCR"].ToString() : "";
                dataModel.P_LCC = row.Table.Columns.Contains("P_LCC") ? row["P_LCC"].ToString() : "";//大血小板数目
                dataModel.CL = row.Table.Columns.Contains("CL") ? row["CL"].ToString() : "";    //氯

                dataModel.CA = row.Table.Columns.Contains("CA") ? row["CA"].ToString() : "";    //钙
                dataModel.ASTALT = row.Table.Columns.Contains("ASTALT") ? row["ASTALT"].ToString() : ""; //草丙比
                dataModel.HLR_B = row.Table.Columns.Contains("HLR_B") ? row["HLR_B"].ToString() : "";    //巨大未成熟细胞百分比
                dataModel.HLR_N = row.Table.Columns.Contains("HLR_N") ? row["HLR_N"].ToString() : "";    //巨大未成熟细胞数目
                dataModel.ALY_B = row.Table.Columns.Contains("ALY_B") ? row["ALY_B"].ToString() : ""; //异常淋巴细胞百分比

                dataModel.ALY_N = row.Table.Columns.Contains("ALY_N") ? row["ALY_N"].ToString() : ""; //异常淋巴细胞数目
                dataModel.NRBC_N = row.Table.Columns.Contains("NRBC_N") ? row["NRBC_N"].ToString() : ""; //有核红细胞数目
                dataModel.NRBC_B = row.Table.Columns.Contains("NRBC_B") ? row["NRBC_B"].ToString() : ""; //有核红细胞百分比
                dataModel.HGB = row.Table.Columns.Contains("HGB") ? row["HGB"].ToString() : ""; //血红蛋白浓度

                #endregion

                #region 血球有异常显示到血常规其他中

                if (community.Contains("福清惠铭医院") || community.Contains("小孟镇"))
                {
                    string BloodOther = "";

                    #region 读取范围值

                    if (dtSH.Rows.Count > 0 && dataModel != null)
                    {
                        foreach (DataRow itemSH in dtSH.Rows)
                        {
                            if (itemSH["name"].ToString() == "中性粒细胞百分比" && !string.IsNullOrEmpty(dataModel.NEU_B))
                            {
                                if (Convert.ToDouble(dataModel.NEU_B) > Convert.ToDouble(itemSH["maxvalue"].ToString()))
                                {
                                    BloodOther += "中性粒细胞百分比偏高;";
                                }
                                else if (Convert.ToDouble(dataModel.NEU_B) < Convert.ToDouble(itemSH["minvalue"].ToString()) && Convert.ToDouble(dataModel.NEU_B) > 0)
                                {
                                    BloodOther += "中性粒细胞百分比偏低;";
                                }
                            }
                            if (itemSH["name"].ToString() == "平均红细胞体积" && !string.IsNullOrEmpty(dataModel.MCV))
                            {
                                if (Convert.ToDouble(dataModel.MCV) > Convert.ToDouble(itemSH["maxvalue"].ToString()))
                                {
                                    BloodOther += "平均红细胞体积偏高;";
                                }
                                else if (Convert.ToDouble(dataModel.MCV) < Convert.ToDouble(itemSH["minvalue"].ToString()) && Convert.ToDouble(dataModel.MCV) > 0)
                                {
                                    BloodOther += "平均红细胞体积偏低;";
                                }
                            }
                            if (itemSH["name"].ToString() == "平均红细胞血红蛋白含量" && !string.IsNullOrEmpty(dataModel.MCH))
                            {
                                if (Convert.ToDouble(dataModel.MCH) > Convert.ToDouble(itemSH["maxvalue"].ToString()))
                                {
                                    BloodOther += "平均红细胞血红蛋白含量偏高;";
                                }
                                else if (Convert.ToDouble(dataModel.MCH) < Convert.ToDouble(itemSH["minvalue"].ToString()) && Convert.ToDouble(dataModel.MCH) > 0)
                                {
                                    BloodOther += "平均红细胞血红蛋白含量偏低;";
                                }
                            }
                            if (itemSH["name"].ToString() == "平均红细胞血红蛋白浓度" && !string.IsNullOrEmpty(dataModel.MCHC))
                            {
                                if (Convert.ToDouble(dataModel.MCHC) > Convert.ToDouble(itemSH["maxvalue"].ToString()))
                                {
                                    BloodOther += "平均红细胞血红蛋白浓度偏高;";
                                }
                                else if (Convert.ToDouble(dataModel.MCHC) < Convert.ToDouble(itemSH["minvalue"].ToString()) && Convert.ToDouble(dataModel.MCHC) > 0)
                                {
                                    BloodOther += "平均红细胞血红蛋白浓度偏低;";
                                }
                            }
                            if (itemSH["name"].ToString() == "单核细胞百分比" && !string.IsNullOrEmpty(dataModel.MON_B))
                            {
                                if (Convert.ToDouble(dataModel.MON_B) > Convert.ToDouble(itemSH["maxvalue"].ToString()))
                                {
                                    BloodOther += "单核细胞百分比偏高;";
                                }
                            }
                            if (itemSH["name"].ToString() == "中性粒细胞数目" && !string.IsNullOrEmpty(dataModel.NEU_N))
                            {
                                if (Convert.ToDouble(dataModel.NEU_N) > Convert.ToDouble(itemSH["maxvalue"].ToString()))
                                {
                                    BloodOther += "中性粒细胞数目偏高;";
                                }
                                else if (Convert.ToDouble(dataModel.NEU_N) < Convert.ToDouble(itemSH["minvalue"].ToString()) && Convert.ToDouble(dataModel.NEU_N) > 0)
                                {
                                    BloodOther += "中性粒细胞数目偏低;";
                                }
                            }
                            if (itemSH["name"].ToString() == "淋巴细胞数目" && !string.IsNullOrEmpty(dataModel.LYMPH_N))
                            {
                                if (Convert.ToDouble(dataModel.LYMPH_N) > Convert.ToDouble(itemSH["maxvalue"].ToString()))
                                {
                                    BloodOther += "淋巴细胞数目偏高;";
                                }
                                else if (Convert.ToDouble(dataModel.LYMPH_N) < Convert.ToDouble(itemSH["minvalue"].ToString()) && Convert.ToDouble(dataModel.LYMPH_N) > 0)
                                {
                                    BloodOther += "淋巴细胞数目偏低;";
                                }
                            }
                            if (itemSH["name"].ToString() == "淋巴细胞百分比" && !string.IsNullOrEmpty(dataModel.LYMPH_B))
                            {
                                if (Convert.ToDouble(dataModel.LYMPH_B) > Convert.ToDouble(itemSH["maxvalue"].ToString()))
                                {
                                    BloodOther += "淋巴细胞百分比偏高;";
                                }
                            }
                            if (itemSH["name"].ToString() == "单核细胞数目" && !string.IsNullOrEmpty(dataModel.MON_N))
                            {
                                if (Convert.ToDouble(dataModel.MON_N) > Convert.ToDouble(itemSH["maxvalue"].ToString()))
                                {
                                    BloodOther += "单核细胞数目偏高;";
                                }
                            }
                            if (itemSH["name"].ToString() == "嗜酸性粒细胞数目" && !string.IsNullOrEmpty(dataModel.EOS_N))
                            {
                                if (Convert.ToDouble(dataModel.EOS_N) > Convert.ToDouble(itemSH["maxvalue"].ToString()))
                                {
                                    BloodOther += "嗜酸性粒细胞数目偏高;";
                                }
                                else if (Convert.ToDouble(dataModel.EOS_N) < Convert.ToDouble(itemSH["minvalue"].ToString()) && Convert.ToDouble(dataModel.EOS_N) > 0)
                                {
                                    BloodOther += "嗜酸性粒细胞数目偏低;";
                                }
                            }
                            if (itemSH["name"].ToString() == "嗜碱性粒细胞数目" && !string.IsNullOrEmpty(dataModel.BAS_N))
                            {
                                if (Convert.ToDouble(dataModel.BAS_N) > Convert.ToDouble(itemSH["maxvalue"].ToString()))
                                {
                                    BloodOther += "嗜碱性粒细胞数目偏高;";
                                }
                                else if (Convert.ToDouble(dataModel.BAS_N) < Convert.ToDouble(itemSH["minvalue"].ToString()) && Convert.ToDouble(dataModel.BAS_N) > 0)
                                {
                                    BloodOther += "嗜碱性粒细胞数目偏低;";
                                }
                            }
                            if (itemSH["name"].ToString() == "红细胞数目" && !string.IsNullOrEmpty(dataModel.RBC))
                            {
                                if (Convert.ToDouble(dataModel.RBC) > Convert.ToDouble(itemSH["maxvalue"].ToString()))
                                {
                                    BloodOther += "红细胞数目偏高;";
                                }
                                else if (Convert.ToDouble(dataModel.RBC) < Convert.ToDouble(itemSH["minvalue"].ToString()) && Convert.ToDouble(dataModel.RBC) > 0)
                                {
                                    BloodOther += "红细胞数目偏低;";
                                }
                            }
                            if (itemSH["name"].ToString() == "红细胞压积" && !string.IsNullOrEmpty(dataModel.HCT))
                            {
                                if (Convert.ToDouble(dataModel.HCT) > Convert.ToDouble(itemSH["maxvalue"].ToString()))
                                {
                                    BloodOther += "红细胞压积偏高;";
                                }
                                else if (Convert.ToDouble(dataModel.HCT) < Convert.ToDouble(itemSH["minvalue"].ToString()) && Convert.ToDouble(dataModel.HCT) > 0)
                                {
                                    BloodOther += "红细胞压积偏低;";
                                }
                            }
                        }
                    }

                    #endregion

                    if (community == "小孟镇")
                    {
                        if (BloodOther.Contains("红细胞数目偏高")) BloodOther = "红细胞数目偏高;";
                        else if (BloodOther.Contains("红细胞数目偏低")) BloodOther = "红细胞数目偏低;";
                    }

                    dataModel.BloodOther = BloodOther;
                }

                #endregion
            }
        }

        /// <summary>
        /// 心电重新拼接图片
        /// </summary>
        /// <param name="path"></param>
        private void ResetImg(string path)
        {
            // 取空白图片
            Image img = Properties.Resources.ECGEmpyt;
            Image image1;

            using (Image imgFrom = Image.FromFile(path))
            {
                Bitmap bmp = new Bitmap(imgFrom.Width, imgFrom.Height, PixelFormat.Format32bppArgb);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.DrawImage(imgFrom, 0, 0);
                }

                Graphics g2 = Graphics.FromImage(bmp);

                // 将空白图片拼接到正常异常处
                g2.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
                g2.DrawImage(img, 1530, 150, img.Width, img.Height);

                image1 = bmp;
            }

            image1.Save(path, ImageFormat.Png);
            image1.Dispose();
            img.Dispose();
        }

        /// <summary>
        /// 拷贝文件夹
        /// </summary>
        /// <param name="strFromPath"></param>
        /// <param name="strToPath"></param>
        /// <param name="ectType">心电类型：1 旧版心电 2 新版心电</param>
        /// <param name="strToPath"></param>
        public void CopyFolder(string strFromPath, string strToPath)
        {
            // 获取时间范围
            int time1 = 0, time2 = 0;

            if (StringPlus.toString(startDate) != "") time1 = Convert.ToInt32(startDate.Replace("-", ""));
            if (StringPlus.toString(endDate) != "") time2 = Convert.ToInt32(endDate.Replace("-", ""));

            //如果源文件夹不存在，则创建或者返回
            if (!Directory.Exists(strFromPath))
            {
                MessageBox.Show(strFromPath + "  共享文件夹不存在。");
                return;
            }
            else
            {
                // 取得要拷贝的文件夹名
                string strFolderName = strFromPath.Substring(strFromPath.LastIndexOf("\\") + 1, strFromPath.Length - strFromPath.LastIndexOf("\\") - 1);

                // 如果目标文件夹中没有源文件夹，则在目标文件夹中创建源文件夹
                if (!Directory.Exists(strToPath + "\\" + strFolderName))
                {
                    Directory.CreateDirectory(strToPath + "\\" + strFolderName);
                }

                DirectoryInfo dir = new DirectoryInfo(strFromPath);

                string fileECG = ecgType == "2" ? "*.png" : "*.pdf";

                FileInfo[] files = dir.GetFiles(fileECG);

                foreach (FileInfo f in files)
                {
                    int fileNumN = 0;

                    if (!int.TryParse(f.Name.Substring(0, 8), out fileNumN)) continue;

                    if (time1 > 0)
                    {
                        if (time1 <= fileNumN && time2 >= fileNumN)
                        {
                            File.Copy(f.FullName, strToPath + "\\" + strFolderName + "\\" + f.Name, true);

                            // 重庆报告不显示正常异常
                            if (versionNo.Contains("重庆"))
                            {
                                ResetImg(strToPath + "\\" + strFolderName + "\\" + f.Name);
                            }

                            Application.DoEvents();
                        }
                    }
                    else
                    {
                        File.Copy(f.FullName, strToPath + "\\" + strFolderName + "\\" + f.Name, true);

                        // 重庆报告不显示正常异常
                        if (versionNo.Contains("重庆"))
                        {
                            ResetImg(strToPath + "\\" + strFolderName + "\\" + f.Name);
                        }

                        Application.DoEvents();
                    }
                }
            }
        }

        /// <summary>
        /// B超重新拼接图片
        /// </summary>
        /// <param name="path"></param>
        public void CopyInfo(string fileFrom, string fileTo, string fileName, bool isNew = false)
        {
            if (!Directory.Exists(fileTo))
            {
                Directory.CreateDirectory(fileTo);
            }

            string fileCopy = fileFrom + (isNew ? "\\" + fileName + ".jpg" : "\\rep.jpg");

            if (File.Exists(fileCopy))
            {
                File.Copy(fileCopy, string.Format("{0}\\{1}.jpg", fileTo, fileName), true);

                // 重庆报告不显示正常异常并且不是新版B超时
                if (versionNo.Contains("重庆") && !isNew)
                {
                    //读取文件流
                    FileStream fs = new System.IO.FileStream(string.Format("{0}\\{1}.jpg", fileTo, fileName), FileMode.Open, FileAccess.Read);

                    int byteLength = (int)fs.Length;
                    byte[] fileBytes = new byte[byteLength];
                    fs.Read(fileBytes, 0, byteLength);

                    //文件流关閉,文件解除锁定
                    fs.Close();
                    Image image = Image.FromStream(new MemoryStream(fileBytes));

                    Graphics g = Graphics.FromImage(image);

                    // 取空白图片
                    Image img = Properties.Resources.TypeBEmpyt;

                    // 将空白图片拼接到正常异常处
                    g.DrawImage(image, 0, 0, image.Width, image.Height);
                    g.DrawImage(img, 156, 888, img.Width, img.Height);

                    fs.Close();
                    image.Save(string.Format("{0}\\{1}.jpg", fileTo, fileName));
                    image.Dispose();
                    img.Dispose();
                }
            }
        }

        /// <summary>
        /// 3.0版本更新进度条
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="i"></param>
        public void SetProgress(object obj, int i)
        {
            UpdateProgressBarDelegate updateProgressBaDelegate = (UpdateProgressBarDelegate)obj;
            Engine engine = new Engine();

            engine.Dispatcher.Invoke(updateProgressBaDelegate, DispatcherPriority.Background, new object[] { System.Windows.Controls.ProgressBar.ValueProperty, Convert.ToDouble(i + 1) });
        }

        /// <summary>
        /// 更新同步执行数据
        /// </summary>
        /// <returns></returns>
        public void SetDataUpload(string dataType, string deviceType)
        {
            try
            {
                Configuration config = GetConfig();

                string file = (config.AppSettings.Settings["SoftPath"] == null ? "D:\\QCSoft" : config.AppSettings.Settings["SoftPath"].Value) + "\\SetDataUpload.csv";

                // 删除记录同步问题的文件
                if (File.Exists(file)) File.Delete(file);

                commonClass.Update("", StringPlus.toString(startDate), StringPlus.toString(endDate), StringPlus.toString(dataType),
                    StringPlus.toString(deviceType), StringPlus.toString(versionNo), StringPlus.toString(isNewTypeB), StringPlus.toString(ecgType), null, null, "", "");
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }

        /// <summary>
        /// 取得同步执行后的数据
        /// </summary>
        /// <returns></returns>
        public string GetDataUpload(string node)
        {
            string total = "";

            try
            {
                DataTable dt = commonClass.GetData("");

                foreach (DataRow row in dt.Rows)
                {
                    total = row[node].ToString();
                }
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }

            return total;
        }

        #endregion

        #region 取得Where条件

        /// <summary>
        /// 血压、身高体重、尿仪、体温体重、血糖设备查询条件
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <param name="dataType"></param>
        /// <param name="deviceType"></param>
        /// <param name="isCheckDate"></param>
        /// <returns></returns>
        public string StrWhere(DateTime dtStart, DateTime dtEnd, string dataType, string deviceType, bool isCheckDate = true)
        {
            string strWhere = "";

            if (isCheckDate)
            {
                startDate = dtStart.ToString("yyyy-MM-dd");
                endDate = dtEnd.ToString("yyyy-MM-dd");

                strWhere = string.Format(" AND DATE(UpdateData) BETWEEN '{0}' AND '{1}' ", startDate, endDate);
            }

            strWhere += string.Format(" AND DATE(UpdateData) IS NOT NULL ");

            if (dataType.Equals("ThermometerWeight")) strWhere += string.Format(" AND (Devicetype = '22' OR Devicetype = '40') ");
            else strWhere += string.Format(" AND Devicetype='{0}' ", deviceType);

            return strWhere;
        }

        /// <summary>
        /// 生化、血球、尿仪、B超、视力、离子、X光扫码 Access数据库查询条件
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <param name="colName">日期栏位名称</param>
        /// <param name="isCheckDate"></param>
        /// <returns></returns>
        public string StrWhereByAccess(DateTime dtStart, DateTime dtEnd, string colName, bool isCheckDate = true)
        {
            string strWhere = "";

            if (isCheckDate)
            {
                startDate = dtStart.ToString("yyyy-MM-dd 00:00:00");
                endDate = dtEnd.ToString("yyyy-MM-dd 23:59:59");

                string startDate2 = dtStart.ToString("yyyy-MM-dd");
                string endDate2 = dtEnd.ToString("yyyy-MM-dd");

                strWhere = string.Format(" AND ({2} BETWEEN #{0}# AND #{1}# ", startDate, endDate, colName);
                strWhere += string.Format(" OR {2} BETWEEN #{0}# AND #{1}#) ", startDate2, endDate2, colName);
            }

            return strWhere;
        }
        /// <summary>
        /// access数据库时间字段为string类型
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <param name="colName"></param>
        /// <param name="isCheckDate"></param>
        /// <returns></returns>
        public string StrWhereByAccessStringDate(DateTime dtStart, DateTime dtEnd, string colName, bool isCheckDate = true)
        {
            string strWhere = "";

            if (isCheckDate)
            {
                startDate = dtStart.ToString("yyyyMMdd 00:00:00");
                endDate = dtEnd.ToString("yyyyMMdd 23:59:59");

                string startDate2 = dtStart.ToString("yyyyMMdd");
                string endDate2 = dtEnd.ToString("yyyyMMdd");

                strWhere = string.Format(" AND ({2} BETWEEN '{0}' AND '{1}' ", startDate, endDate, colName);
                strWhere += string.Format(" OR {2} BETWEEN '{0}' AND '{1}') ", startDate2, endDate2, colName);
            }

            return strWhere;
        }

        /// <summary>
        /// 心电、问询、中医、外科、内科、五官、X光查询条件
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <param name="colName">栏位名称</param>
        /// <param name="isCheckDate"></param>
        /// <returns></returns>
        public string StrWhere(DateTime dtStart, DateTime dtEnd, string colName, bool isCheckDate = true)
        {
            string strWhere = "";

            if (isCheckDate)
            {
                startDate = dtStart.ToString("yyyy-MM-dd");
                endDate = dtEnd.ToString("yyyy-MM-dd");

                if (ecgType == "1") colName = "createTime";

                strWhere = string.Format(" AND DATE({2}) BETWEEN '{0}' AND '{1}' ", startDate, endDate, colName);
            }

            return strWhere;
        }

        #endregion

        #region 取得同步资料笔数

        /// <summary>
        /// 取得血压、身高体重、尿仪、体温体重、血糖同步资料笔数
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="where"></param>
        /// <param name="total"></param>
        /// <param name="DeviceSqliteLs"></param>
        public void GetDataCount(string dataType, string where, ref int total, ref List<DeviceInfoModel> DeviceSqliteLs)
        {
            cud = new CombinUploadData();

            try
            {
                GetConnection();

                // 血糖
                if (dataType == "BloodSugar")
                {
                    DeviceSqliteLs = deviceInfoSqliteBLL.GetMaxModelList(where, SugarSqlite);

                    if (DeviceSqliteLs != null) total = DeviceSqliteLs.Count;
                }
                // 体温体重
                else if (dataType == "ThermometerWeight")
                {
                    DeviceSqliteLs = deviceInfoSqliteBLL.GetMaxModelList(where, BMSqlite);

                    if (DeviceSqliteLs != null) total = DeviceSqliteLs.Count;
                }
                // 身高体重
                else if (dataType == "HeightWeight")
                {
                    DeviceSqliteLs = deviceInfoSqliteBLL.GetMaxModelList(where, BHSqlite);

                    if (DeviceSqliteLs != null) total = DeviceSqliteLs.Count;
                }
                // 血压
                else if (dataType == "BloodPressure")
                {
                    DeviceSqliteLs = deviceInfoSqliteBLL.GetMaxModelList(where, BPSqlite);

                    if (DeviceSqliteLs != null) total = DeviceSqliteLs.Count;
                }
                // 尿仪
                else if (dataType == "UrineDevice")
                {
                    DeviceSqliteLs = deviceInfoSqliteBLL.GetMaxModelList(where, EMPSqlite);

                    if (DeviceSqliteLs != null) total = DeviceSqliteLs.Count;
                }
            }
            catch (Exception ex)
            {
                this.cud.ConbinData(null, "", ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 取得生化、血球、尿仪、B超、重庆B超、安徽X光、视力同步资料笔数
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="where"></param>
        /// <param name="index">第几个心电按钮</param>
        /// <param name="total"></param>
        /// <param name="dtInfo"></param>
        public void GetDataCount(string dataType, string where, int index, ref int total, ref DataTable dtInfo)
        {
            cud = new CombinUploadData();

            try
            {
                GetConnection();

                //随访同步
                if (dataType == "frmFollowDataUpdate")
                {
                    DataSet ds = recordsCustomerBaseInfoBLL.GetList(" 1=1 " + where);

                    if (ds != null) dtInfo = ds.Tables[0];

                    if (dtInfo != null) total = dtInfo.Rows.Count;
                }
                // 尿仪
                else if (dataType == "UrineDevice")
                {
                    DataSet ds = accessClassBLL.GetNJList(where, EMPSqlite2);

                    if (ds != null) dtInfo = ds.Tables[0];

                    if (dtInfo != null) total = dtInfo.Rows.Count;
                }
                // 生化
                else if (dataType == "Biochemical")
                {
                    DataSet ds = new DataSet();

                    if (index == 1) ds = accessClassBLL.GetBiochemicalList(where, BiochemicalConn);
                    else if (index == 2) ds = accessClassBLL.GetBiochemicalList(where, BiochemicalConn2);

                    if (ds != null) dtInfo = ds.Tables[0];

                    if (dtInfo != null) total = dtInfo.Rows.Count;
                }
                // 血球
                else if (dataType == "BloodCorpuscle")
                {
                    DataSet ds = new DataSet();

                    if (index == 1) ds = accessClassBLL.GetBloodCorpuscleList(where, BloodCorpuscleConn);
                    else if (index == 2) ds = accessClassBLL.GetBiochemicalList(where, BloodCorpuscleConn2);

                    if (ds != null) dtInfo = ds.Tables[0];

                    if (dtInfo != null) total = dtInfo.Rows.Count;
                }
                // 安徽X光
                else if (dataType == "ChestXData")
                {
                    DataSet ds = new DataSet();

                    ds = accessClassBLL.GetChestX(where, ChestXAccess);

                    if (ds != null) dtInfo = ds.Tables[0];

                    if (dtInfo != null) total = dtInfo.Rows.Count;
                }
                // B超
                else if (dataType == "TypeBForm")
                {
                    DataSet ds = new DataSet();

                    if (versionNo.Contains("重庆") && index == 2)
                    {
                        ds = accessClassBLL.GetTypeBByChongQing(where, firebird2);
                    }
                    else
                    {
                        // 如果为新版B超
                        if (isNewTypeB.Equals("Y"))
                        {
                            if (index == 1) ds = accessClassBLL.GetTypeBList(where, TypeBConn);
                            else if (index == 2) ds = accessClassBLL.GetTypeBList(where, TypeBConn2);
                            else if (index == 3) ds = accessClassBLL.GetTypeBList(where, TypeBConn3);
                        }
                        else
                        {
                            if (index == 1) ds = typeBBLL.GetPutInfo(startDate, endDate, TypeBConn);
                            else if (index == 2) ds = typeBBLL.GetPutInfo(startDate, endDate, TypeBConn2);
                            else if (index == 3) ds = typeBBLL.GetPutInfo(startDate, endDate, TypeBConn3);
                        }
                    }

                    if (ds != null) dtInfo = ds.Tables[0];

                    if (dtInfo != null) total = dtInfo.Rows.Count;
                }
                // 视力
                else if (dataType == "Vsiual")
                {
                    DataSet ds = new DataSet();

                    ds = accessClassBLL.GetVsiual(where, QCVsiual);

                    if (ds != null) dtInfo = ds.Tables[0];

                    if (dtInfo != null) total = dtInfo.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                this.cud.ConbinData(null, "", ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 取得心电、外科、内科、五官、X光同步资料笔数
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="where"></param>
        /// <param name="index">第几个心电按钮</param>
        /// <param name="total"></param>
        /// <param name="EcgDataModel"></param>
        /// <param name="PhysicalExamModel"></param>
        /// <param name="AssistCheckModel"></param>
        /// <param name="VisceraFunctionModel"></param>
        public void GetDataCount(string dataType, string where, int index, ref int total, ref List<EcgDataModel> EcgDataModel, ref List<RecordsPhysicalExamModel> PhysicalExamModel,
            ref List<RecordsAssistCheckModel> AssistCheckModel, ref List<RecordsVisceraFunctionModel> VisceraFunctionModel)
        {
            cud = new CombinUploadData();

            try
            {
                GetConnection();

                // 心电
                if (dataType == "ECGUpload")
                {
                    if (ecgType == "1") EcgDataModel = dataUploadSqliteBLL.GetFirstECGList(where, EcgSqlite);
                    else
                    {
                        if (index == 1) EcgDataModel = dataUploadSqliteBLL.GetECGList(where, EcgSqlite);
                        else if (index == 2) EcgDataModel = dataUploadSqliteBLL.GetECGList(where, EcgSqlite2);
                        else if (index == 3) EcgDataModel = dataUploadSqliteBLL.GetECGList(where, EcgSqlite3);
                    }

                    if (EcgDataModel != null) total = EcgDataModel.Count;
                }
                // 外科
                else if (dataType == "SurgicalData")
                {
                    if (index == 1) PhysicalExamModel = separationBLL.GetSurgicalList(where, SurgicalSqlite);
                    else if (index == 2) PhysicalExamModel = separationBLL.GetSurgicalList(where, SurgicalSqlite2);

                    if (PhysicalExamModel != null) total = PhysicalExamModel.Count;
                }
                // 内科
                else if (dataType == "InternalMedicineData")
                {
                    if (index == 1) PhysicalExamModel = separationBLL.GetInternalMedicineList(where, InternalSqlite);
                    else if (index == 2) PhysicalExamModel = separationBLL.GetInternalMedicineList(where, InternalSqlite2);

                    if (PhysicalExamModel != null) total = PhysicalExamModel.Count;
                }
                // 五官
                else if (dataType == "MouthData")
                {
                    VisceraFunctionModel = separationBLL.GetModelList(where, MouthSqlite);
                    if (VisceraFunctionModel != null) total = VisceraFunctionModel.Count;
                }
                // X光
                else if (dataType == "ChestXData")
                {
                    AssistCheckModel = separationBLL.GetChestXList(where, ChestXSqlite);
                    if (AssistCheckModel != null) total = AssistCheckModel.Count;
                }
            }
            catch (Exception ex)
            {
                this.cud.ConbinData(null, "", ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 取得问询、中医同步资料笔数
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="where"></param>
        /// <param name="total"></param>
        /// <param name="DeviceSqliteLs">问询</param>
        /// <param name="MedicationSqliteLs">用药</param>
        /// <param name="HistoryModel">住院史、免疫史</param>
        /// <param name="MedicineModel">中医</param>
        /// <param name="OldGloomyModel">抑郁</param>
        /// <param name="OldIntelligenceModel">智力</param>
        /// <param name="HealthConditionModel">健康评估</param>
        /// <param name="route"></param>
        public void GetDataCount(string dataType, string where, ref int total, ref List<DataUploadModel> DeviceSqliteLs, ref List<OldSelfSqliteModel> SelfLs,
            ref List<RecordsMedicationModel> MedicationSqliteLs, ref List<History> HistoryModel, ref List<MedicineModel> MedicineModel, ref List<OldGloomyModel> OldGloomyModel,
            ref List<OldIntelligenceModel> OldIntelligenceModel, ref List<RecordsHealthConditionModel> HealthConditionModel, string route)
        {
            cud = new CombinUploadData();

            try
            {
                GetConnection();

                // 问询
                if (dataType == "MedicalEnquiry")
                {
                    DeviceSqliteLs = dataUploadSqliteBLL.GetMaxModelList(where, MESqlite);

                    // 获取小pad自理能力
                    SelfLs = oldSelfSqlitBLL.GetMaxList(where, MESqlite);

                    if (DeviceSqliteLs != null) total = DeviceSqliteLs.Count;

                    if (SelfLs != null && total < SelfLs.Count) total = SelfLs.Count;

                    // 用药
                    MedicationSqliteLs = recordsMedicationSqliteBLL.GetModelList(where, MESqlite);

                    // 住院 免疫史
                    HistoryModel = dataUploadSqliteBLL.GetHistoryModel(where, MESqlite);
                }
                // 中医
                else if (dataType == "OldHealth")
                {
                    // 若点第二个按钮 获取第2个数据库连接字符串值
                    if (route.Equals("btn2")) OldSqlite = OldSqlite2;

                    MedicineModel = recordsMedicineResultSqliteBLL.GetMaxModelList(where, OldSqlite);

                    where = where.Replace("Medicinecn.", "");

                    // 获取小pad自理能力
                    SelfLs = oldSelfSqlitBLL.GetMaxList(where, OldSqlite);

                    if (MedicineModel != null) total = MedicineModel.Count;

                    if (SelfLs != null && total < SelfLs.Count) total = SelfLs.Count;

                    #region 辽宁抑郁、智力评估

                    if (versionNo.Contains("辽宁"))
                    {
                        // 抑郁评估
                        if (oldGlolmyAndIntelligenceBLL.ExistTable("tbl_oldgloomy", OldSqlite))
                        {
                            OldGloomyModel = oldGlolmyAndIntelligenceBLL.Getoldgloomy(where, OldSqlite);
                        }

                        if (total == 0) total = OldGloomyModel.Count;

                        // 智力评估
                        if (oldGlolmyAndIntelligenceBLL.ExistTable("tbl_oldintelligence", OldSqlite))
                        {
                            OldIntelligenceModel = oldGlolmyAndIntelligenceBLL.GetOldIntelligence(where, OldSqlite);
                        }

                        if (total == 0) total = OldIntelligenceModel.Count;
                    }

                    #endregion

                    if (area.Equals("武汉"))
                    {
                        HealthConditionModel = conditionBLL.GetMaxList(where, OldSqlite);
                    }
                }
            }
            catch (Exception ex)
            {
                this.cud.ConbinData(null, "", ex.ToString());
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// 血糖同步
        /// </summary>
        /// <param name="DeviceSqliteLs"></param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        public void DataUploadBySugar(List<DeviceInfoModel> DeviceSqliteLs, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            RecordsAssistCheckModel saveModel = new RecordsAssistCheckModel();
            DeviceInfoModel deciveModel = new DeviceInfoModel();

            for (int i = 0; i < DeviceSqliteLs.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    deciveModel = DeviceSqliteLs[i];

                    if (string.IsNullOrEmpty(deciveModel.Value1))
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "检测资料为空");
                        continue;
                    }

                    saveModel = new RecordsAssistCheckModel();
                    saveModel.IDCardNo = deciveModel.IDCardNo;
                    saveModel.FPGL = new decimal?(Convert.ToDecimal(deciveModel.Value1));

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(saveModel.IDCardNo, deciveModel.CheckDate);

                    if (baseModel.CheckDate == null)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "没有体检资料");
                        continue;
                    }

                    // 更新Pad成功时 
                    if (recordsAssistCheckBLL.UpdateByMiniSTPad(saveModel, baseModel.CheckDate.ToString()))
                    {
                        count++;

                        if (!deviceInfoBLL.Update(deciveModel)) deviceInfoBLL.Add(deciveModel);  // 更新栏位上传表
                    }
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 体温体重同步
        /// </summary>
        /// <param name="DeviceSqliteLs"></param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        public void DataUploadByWeight(List<DeviceInfoModel> DeviceSqliteLs, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            RecordsGeneralConditionModel saveModel = new RecordsGeneralConditionModel();
            DeviceInfoModel deciveModel = new DeviceInfoModel();

            for (int i = 0; i < DeviceSqliteLs.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    deciveModel = DeviceSqliteLs[i];

                    if (string.IsNullOrEmpty(deciveModel.Value1))
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "检测资料为空");
                        continue;
                    }

                    saveModel = new RecordsGeneralConditionModel();
                    saveModel.IDCardNo = deciveModel.IDCardNo;

                    //十五位身份证判断
                    string idCard = saveModel.IDCardNo;

                    if (idCard == "")
                    {
                        this.cud.ConbinData(null, "", "身份证号为空");
                        continue;
                    }

                    RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                    if (recordModel == null && idCard.Length == 18)
                    {
                        idCard = idCard.Trim().Remove(6, 2).Remove(15);
                    }

                    RecordsGeneralConditionModel generModel = recordsGeneralConditionBLL.GetModelByCheckDate(idCard, deciveModel.CheckDate);

                    if (generModel != null && string.IsNullOrEmpty(generModel.CheckDate))
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "没有体检资料");
                        continue;
                    }

                    deciveModel.IDCardNo = generModel.IDCardNo;

                    switch (deciveModel.DeviceType)
                    {
                        case "22":
                            saveModel.Weight = new decimal?(Convert.ToDecimal(deciveModel.Value1));
                            decimal num, num2;

                            if (generModel != null && (decimal.TryParse(generModel.Height.ToString(), out num) &&
                                decimal.TryParse(saveModel.Weight.ToString(), out num2)) && (num != 0M))
                            {
                                decimal num3 = num / 100M;
                                decimal num4 = num3 * num3;

                                // 计算BMI
                                saveModel.BMI = Convert.ToDecimal((num2 / num4).ToString("0.00"));

                                // 计算腰围
                                string Waistline = (num2 * (decimal)3.3 / num4 + (decimal)5).ToString("0.00");
                                saveModel.Waistline = Convert.ToInt32(Waistline.Remove(Waistline.LastIndexOf('.')));
                            }

                            // 更新Pad成功时
                            if (recordsGeneralConditionBLL.UpdateByMiniTTPad(saveModel, generModel.CheckDate))
                            {
                                count++;
                                if (!deviceInfoBLL.Update(deciveModel)) deviceInfoBLL.Add(deciveModel);//更新栏位上传表
                            }
                            else
                            {
                                RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                                this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "体检数据更新失败");
                            }

                            break;
                        case "40":
                            saveModel.AnimalHeat = new decimal?(Convert.ToDecimal(deciveModel.Value1));

                            // 更新Pad成功时
                            if (recordsGeneralConditionBLL.UpdateByMiniTWPad(saveModel, generModel.CheckDate))
                            {
                                count++;
                                if (!deviceInfoBLL.Update(deciveModel)) deviceInfoBLL.Add(deciveModel);//更新栏位上传表
                            }
                            else
                            {
                                RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                                this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "体检数据更新失败");
                            }

                            break;
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 身高体重同步
        /// </summary>
        /// <param name="DeviceSqliteLs"></param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        public void DataUploadByHeight(List<DeviceInfoModel> DeviceSqliteLs, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            RecordsGeneralConditionModel saveModel = new RecordsGeneralConditionModel();
            RecordsVisceraFunctionModel saveVFModel = new RecordsVisceraFunctionModel();
            DeviceInfoModel deciveModel = new DeviceInfoModel();

            #region 取得小数位设定

            // 取得小数位设定
            DataSet ds = new RequireBLL().GetDecimalData("健康体检", "一般状况", "");
            int heightPlace = 2, weightPlace = 2, BMIPlace = 2, waistlinePlace = 0;  // 身高，体重，BMI，腰围小数位

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (StringPlus.toString(dr["DecimalPlace"]) != "")
                    {
                        if (dr["OptionName"].ToString().ToLower() == "height") heightPlace = int.Parse(dr["DecimalPlace"].ToString());
                        else if (dr["OptionName"].ToString().ToLower() == "weight") weightPlace = int.Parse(dr["DecimalPlace"].ToString());
                        else if (dr["OptionName"].ToString().ToLower() == "bmi") BMIPlace = int.Parse(dr["DecimalPlace"].ToString());
                        else if (dr["OptionName"].ToString().ToLower() == "waistline") waistlinePlace = int.Parse(dr["DecimalPlace"].ToString());
                    }
                }
            }

            #endregion

            for (int i = 0; i < DeviceSqliteLs.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    deciveModel = DeviceSqliteLs[i];

                    if (string.IsNullOrEmpty(deciveModel.Value1) || string.IsNullOrEmpty(deciveModel.Value2) ||
                        string.IsNullOrEmpty(deciveModel.Value3))
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "检测资料为空");
                        continue;
                    }

                    saveModel = new RecordsGeneralConditionModel();
                    saveModel.IDCardNo = deciveModel.IDCardNo;
                    saveVFModel = new RecordsVisceraFunctionModel();
                    saveVFModel.IDCardNo = deciveModel.IDCardNo;

                    //十五位身份证判断
                    string idCard = saveModel.IDCardNo;

                    if (idCard == "")
                    {
                        this.cud.ConbinData(null, "", "身份证号为空");
                        continue;
                    }

                    RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                    if (recordModel == null && idCard.Length == 18)
                    {
                        idCard = idCard.Trim().Remove(6, 2).Remove(15);
                    }

                    saveModel.Height = new decimal?(Convert.ToDecimal(deciveModel.Value1));
                    saveModel.Weight = new decimal?(Convert.ToDecimal(deciveModel.Value2));
                    saveModel.BMI = new decimal?(Convert.ToDecimal(deciveModel.Value3));

                    decimal heigth = Convert.ToDecimal(saveModel.Height);
                    decimal weight = Convert.ToDecimal(saveModel.Weight);

                    if (community.Equals("聊城东昌府区"))
                    {
                        saveModel.Height = Math.Round(heigth, MidpointRounding.AwayFromZero);
                        saveModel.Weight = Math.Round(weight, weightPlace);
                    }
                    else
                    {
                        saveModel.Height = Math.Round(heigth, heightPlace);
                        saveModel.Weight = Math.Round(weight, weightPlace);
                    }

                    // 计算BMI
                    decimal num7 = Convert.ToDecimal(saveModel.Height) / 100M;
                    decimal num8 = num7 * num7;
                    saveModel.BMI = Math.Round(weight / num8, BMIPlace);

                    // 计算腰围
                    decimal num = Convert.ToDecimal(saveModel.Height);
                    decimal num3 = num / 100M;
                    decimal num4 = num3 * num3;

                    // 山西、小龙坎不计算腰围
                    if (!versionNo.Contains("山西") || !community.Equals("小龙坎社区卫生服务中心") || community.Equals("远安县"))
                    {
                        // 计算腰围
                        decimal Waistline = weight * (decimal)3.3 / num4 + (decimal)5;

                        if (StringPlus.toString(deciveModel.Value9) != "") saveModel.Waistline = new decimal?(Math.Round(Convert.ToDecimal(deciveModel.Value9),
                            waistlinePlace));
                        else saveModel.Waistline = Math.Round(Waistline, waistlinePlace);
                    }

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(idCard, deciveModel.CheckDate);

                    if (baseModel.CheckDate == null)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "没有体检资料");
                        continue;
                    }

                    deciveModel.IDCardNo = baseModel.IDCardNo;

                    // 更新 视力表
                    if (versionNo.Contains("山西"))
                    {
                        saveVFModel.IDCardNo = baseModel.IDCardNo;
                        saveVFModel.OutKey = baseModel.ID;

                        if (!string.IsNullOrEmpty(deciveModel.Value4)) saveVFModel.LeftView = Convert.ToDecimal(deciveModel.Value4);
                        if (!string.IsNullOrEmpty(deciveModel.Value6)) saveVFModel.LeftEyecorrect = Convert.ToDecimal(deciveModel.Value6);
                        if (!string.IsNullOrEmpty(deciveModel.Value5)) saveVFModel.RightView = Convert.ToDecimal(deciveModel.Value5);
                        if (!string.IsNullOrEmpty(deciveModel.Value7)) saveVFModel.RightEyecorrect = Convert.ToDecimal(deciveModel.Value7);

                        recordsVisceraFunctionBLL.UpdateVsiual(saveVFModel);
                    }

                    // 更新Pad成功时
                    if (recordsGeneralConditionBLL.UpdateByMiniSTPad(saveModel, baseModel.ID.ToString()))
                    {
                        count++;

                        if (!deviceInfoBLL.Update(deciveModel)) deviceInfoBLL.Add(deciveModel);//更新栏位上传表                    
                    }
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 血压同步
        /// </summary>
        /// <param name="DeviceSqliteLs"></param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        public void DataUploadByPressure(List<DeviceInfoModel> DeviceSqliteLs, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            RecordsGeneralConditionModel saveModel = new RecordsGeneralConditionModel();
            DeviceInfoModel deciveModel = new DeviceInfoModel();

            // 取得奇偶数设定
            List<RequireModel> model = new RequireBLL().GetModel("健康体检", "一般状况", "血压");

            for (int i = 0; i < DeviceSqliteLs.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    deciveModel = DeviceSqliteLs[i];
                    bool isBilateral = false; // 是否为双侧血压
                    int m = GetRandom();

                    if (string.IsNullOrEmpty(deciveModel.Value1) || string.IsNullOrEmpty(deciveModel.Value2) ||
                        string.IsNullOrEmpty(deciveModel.Value3))
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "检测资料为空");
                        continue;
                    }

                    saveModel = new RecordsGeneralConditionModel();
                    saveModel.IDCardNo = deciveModel.IDCardNo;

                    //十五位身份证判断
                    string idCard = saveModel.IDCardNo;

                    if (idCard == "")
                    {
                        this.cud.ConbinData(null, "", "身份证号为空");
                        continue;
                    }

                    RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                    if (recordModel == null && idCard.Length == 18)
                    {
                        idCard = idCard.Trim().Remove(6, 2).Remove(15);
                    }

                    RecordsGeneralConditionModel generModel = recordsGeneralConditionBLL.GetModelByCheckDate(idCard, deciveModel.CheckDate);

                    if (generModel != null && string.IsNullOrEmpty(generModel.CheckDate))
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "没有体检资料");
                        continue;
                    }

                    deciveModel.IDCardNo = generModel.IDCardNo;

                    // 根据设定值判断为左侧血压(L)还是右侧血压(R)还是双侧血压(D)
                    if (LRType.Equals("左侧"))
                    {
                        saveModel.LeftHeight = new decimal?(int.Parse(deciveModel.Value1));
                        saveModel.LeftPre = new decimal?(int.Parse(deciveModel.Value2));
                        saveModel.RightHeight = new decimal?((int.Parse(deciveModel.Value1) + m + 1));
                        saveModel.RightPre = new decimal?((int.Parse(deciveModel.Value2) + m));

                        // 远安或设置不自动生成另一侧血压时
                        if (area.Equals("远安") || IsAutoCal == "N" || IsAutoCal == "否")
                        {
                            saveModel.RightHeight = null;
                            saveModel.RightPre = null;
                        }
                    }
                    else if (LRType.Equals("右侧"))
                    {
                        saveModel.RightHeight = new decimal?(int.Parse(deciveModel.Value1));
                        saveModel.RightPre = new decimal?(int.Parse(deciveModel.Value2));
                        saveModel.LeftHeight = new decimal?((int.Parse(deciveModel.Value1) - m));
                        saveModel.LeftPre = new decimal?((int.Parse(deciveModel.Value2) - m - 1));

                        // 设置不自动生成另一侧血压时
                        if (IsAutoCal == "N" || IsAutoCal == "否")
                        {
                            saveModel.LeftHeight = null;
                            saveModel.LeftPre = null;
                        }
                    }
                    else
                    {
                        #region 双侧血压

                        // 双侧血压时 将结果集List转为DataTable
                        DataTable dt = WebHelper.ToDataTable<DeviceInfoModel>(DeviceSqliteLs);

                        // 双侧血压          
                        DataRow[] dr = dt.Select("IDCardNo='" + deciveModel.IDCardNo + "' AND CheckDate='" +
                            deciveModel.CheckDate + "' AND ISNULL(LRType,'') <> ''");

                        // 如果有两笔资料则为双侧血压
                        if (dr.Length > 1)
                        {
                            if (dr[0]["LRType"].ToString() == "1")//先测左侧血压
                            {
                                saveModel.LeftHeight = new decimal?(int.Parse(dr[0]["Value1"].ToString()));
                                saveModel.LeftPre = new decimal?(int.Parse(dr[0]["Value2"].ToString()));
                                saveModel.RightHeight = new decimal?(int.Parse(dr[1]["Value1"].ToString()));
                                saveModel.RightPre = new decimal?(int.Parse(dr[1]["Value2"].ToString()));
                            }
                            else
                            {
                                saveModel.RightHeight = new decimal?(int.Parse(dr[0]["Value1"].ToString()));
                                saveModel.RightPre = new decimal?(int.Parse(dr[0]["Value2"].ToString()));
                                saveModel.LeftHeight = new decimal?(int.Parse(dr[1]["Value1"].ToString()));
                                saveModel.LeftPre = new decimal?(int.Parse(dr[1]["Value2"].ToString()));
                            }

                            if (versionNo.Contains("山西"))
                            {
                                saveModel.PulseRate = new decimal?(int.Parse(dr[0]["Value3"].ToString()));
                                saveModel.BreathRate = new decimal?(Convert.ToInt32(dr[0]["Value3"].ToString()) / 4);
                            }

                            isBilateral = true;
                        }
                        else
                        {
                            saveModel.LeftHeight = new decimal?(int.Parse(deciveModel.Value1) - m);
                            saveModel.LeftPre = new decimal?(int.Parse(deciveModel.Value2) - m - 1);
                            saveModel.RightHeight = new decimal?(int.Parse(deciveModel.Value1));
                            saveModel.RightPre = new decimal?(int.Parse(deciveModel.Value2));

                            // 设置不自动生成另一侧血压时
                            if (IsAutoCal == "N" || IsAutoCal == "否")
                            {
                                saveModel.LeftHeight = null;
                                saveModel.LeftPre = null;
                            }

                            #region 山西

                            if (versionNo.Contains("山西"))
                            {
                                saveModel.LeftHeight = new decimal?(int.Parse(deciveModel.Value1));
                                saveModel.LeftPre = new decimal?(int.Parse(deciveModel.Value2));
                                saveModel.RightHeight = new decimal?(int.Parse(deciveModel.Value1) + m + 1);
                                saveModel.RightPre = new decimal?(int.Parse(deciveModel.Value2) + m);

                                // 设置不自动生成另一侧血压时
                                if (IsAutoCal == "N" || IsAutoCal == "否")
                                {
                                    saveModel.RightHeight = null;
                                    saveModel.RightPre = null;
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }

                    #region 血压奇偶数

                    // 获取默认项设置中的 是否保留奇偶数
                    if (model != null && model.Count > 0)
                    {
                        foreach (RequireModel item in model)
                        {
                            if (item.ChinName == "左侧低血压")
                            {
                                if (item.IsOdevity == "偶数")
                                {
                                    if (saveModel.LeftPre % 2 != 0) saveModel.LeftPre -= 1;
                                }
                                else if (item.IsOdevity == "奇数")
                                {
                                    if (saveModel.LeftPre % 2 == 0) saveModel.LeftPre -= 1;
                                }
                            }
                            else if (item.ChinName == "左侧高血压")
                            {
                                if (item.IsOdevity == "偶数")
                                {
                                    //保存偶数，判断是否奇数，如果是奇数，那么-1
                                    if (saveModel.LeftHeight % 2 != 0) saveModel.LeftHeight -= 1;
                                }
                                else if (item.IsOdevity == "奇数")
                                {
                                    //保存奇数，判断是否偶数，如果是偶数，那么-1
                                    if (saveModel.LeftHeight % 2 == 0) saveModel.LeftHeight -= 1;
                                }
                            }
                            else if (item.ChinName == "右侧低血压")
                            {
                                if (item.IsOdevity == "偶数")
                                {
                                    if (saveModel.RightPre % 2 != 0) saveModel.RightPre -= 1;
                                }
                                else if (item.IsOdevity == "奇数")
                                {
                                    if (saveModel.RightPre % 2 == 0) saveModel.RightPre -= 1;
                                }
                            }
                            else if (item.ChinName == "右侧高血压")
                            {
                                if (item.IsOdevity == "偶数")
                                {
                                    if (saveModel.RightHeight % 2 != 0) saveModel.RightHeight -= 1;
                                }
                                else if (item.IsOdevity == "奇数")
                                {
                                    if (saveModel.RightHeight % 2 == 0) saveModel.RightHeight -= 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (versionNo.Contains("四川") || community.Equals("安顺") || community.Equals("道真县") || area.Contains("龙城"))
                        {
                            // 取得偶数值
                            if (saveModel.LeftHeight % 2 != 0) saveModel.LeftHeight -= 1;
                            if (saveModel.LeftPre % 2 != 0) saveModel.LeftPre -= 1;
                            if (saveModel.RightHeight % 2 != 0) saveModel.RightHeight -= 1;
                            if (saveModel.RightPre % 2 != 0) saveModel.RightPre -= 1;
                        }
                    }

                    #endregion

                    // 脉率
                    saveModel.PulseRate = new decimal?(int.Parse(deciveModel.Value3));

                    // 呼吸频率
                    saveModel.BreathRate = new decimal?(Convert.ToInt32(deciveModel.Value3) / 4);

                    // 呼吸频率
                    if (saveModel.BreathRate >= 20) saveModel.BreathRate = 20;
                    else if (saveModel.BreathRate <= 16) saveModel.BreathRate = 16;

                    // 更新最后一次体检血压
                    bool updateFlag = recordsGeneralConditionBLL.UpdateByMiniPad(saveModel, generModel.CheckDate);

                    #region 河北血压更新其他系统疾病

                    // 血压>150 血糖>6.1，更新其他系统疾病显示高血压病、糖尿病
                    if (versionNo.Contains("河北"))
                    {
                        QuestionModel = recordsHealthQuestionBLL.GetModelByOutKey(Convert.ToInt32(generModel.OutKey));

                        if (QuestionModel != null)
                        {
                            if ((saveModel.RightHeight != null && saveModel.RightHeight > 150) || (saveModel.LeftHeight != null && saveModel.LeftHeight > 150))
                            {
                                QuestionModel.ElseDis = "2";

                                if (!string.IsNullOrEmpty(QuestionModel.ElseOther))
                                {
                                    if (!QuestionModel.ElseOther.Contains("高血压病")) QuestionModel.ElseOther += ";高血压病";
                                }
                                else QuestionModel.ElseOther += "高血压病";

                                // 更新健康问题
                                recordsHealthQuestionBLL.UpdateOtherDis(QuestionModel, generModel.OutKey.ToString());
                            }
                        }
                    }

                    #endregion

                    // 更新Pad成功时
                    if (updateFlag)
                    {
                        count++;

                        // 更新栏位上传表
                        if (!deviceInfoBLL.Update(deciveModel)) deviceInfoBLL.Add(deciveModel);
                    }
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "体检数据更新失败");
                    }

                    if (isBilateral) i += 1;
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 尿仪同步
        /// </summary>
        /// <param name="DeviceSqliteLs"></param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        public void DataUploadByUrine(List<DeviceInfoModel> DeviceSqliteLs, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            RecordsAssistCheckModel saveModel = new RecordsAssistCheckModel();
            DeviceInfoModel deciveModel = new DeviceInfoModel();
            DataModel dataModel = new DataModel();

            for (int i = 0; i < DeviceSqliteLs.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    deciveModel = DeviceSqliteLs[i];

                    if (string.IsNullOrEmpty(deciveModel.Value1))
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "检测资料为空");
                        continue;
                    }

                    saveModel = new RecordsAssistCheckModel();

                    // 尿机Model赋值
                    SetUrineModel(null, ref saveModel, ref dataModel, ref deciveModel);

                    //十五位身份证判断
                    string idCard = saveModel.IDCardNo;

                    if (idCard == "")
                    {
                        this.cud.ConbinData(null, "", "身份证号为空");
                        continue;
                    }

                    RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                    if (recordModel == null && idCard.Length == 18)
                    {
                        idCard = idCard.Trim().Remove(6, 2).Remove(15);
                    }

                    RecordsGeneralConditionModel generModel = recordsGeneralConditionBLL.GetModelByCheckDate(idCard, deciveModel.CheckDate);

                    if (generModel != null && string.IsNullOrEmpty(generModel.CheckDate))
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "没有体检资料");
                        continue;
                    }

                    deciveModel.IDCardNo = generModel.IDCardNo;

                    // 更新Pad成功时
                    if (recordsAssistCheckBLL.UpdateByMiniPad(saveModel, generModel.CheckDate))
                    {
                        count++;

                        if (!deviceInfoBLL.Update(deciveModel)) deviceInfoBLL.Add(deciveModel);//更新栏位上传表                    
                    }
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 尿仪第二个按钮同步
        /// </summary>
        /// <param name="dtInfo"></param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void DataUploadNJ(DataTable dtInfo, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            Application.DoEvents();
            DataModel model = new DataModel();
            RecordsAssistCheckModel saveModel = new RecordsAssistCheckModel();

            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    DataRow row = dtInfo.Rows[i];
                    model = new DataModel();
                    DeviceInfoModel deciveModel = new DeviceInfoModel();

                    saveModel = new RecordsAssistCheckModel();

                    // 尿机Model赋值
                    SetUrineModel(row, ref saveModel, ref model, ref deciveModel);

                    // 十五位身份证判断
                    string idCard = model.IDCardNo;

                    if (StringPlus.toString(model.BarCode) == "" && StringPlus.toString(idCard) == "")
                    {
                        this.cud.ConbinData(null, model.BarCode + idCard, "条码或身份证号为空");
                        continue;
                    }

                    // 条码同步
                    if (StringPlus.toString(deciveModel.BarCode) != "")
                    {
                        saveModel.BLD = deciveModel.Value2.ToString();//潜血---尿潜血
                        saveModel.KET = deciveModel.Value4.ToString();//酮体---尿酮体
                        saveModel.GLU = deciveModel.Value5.ToString();//葡萄糖--尿糖
                        saveModel.PRO = deciveModel.Value6.ToString().ToUpper().Replace("TRACE", "+");//蛋白质--尿蛋白

                        if (!deviceInfoBLL.UpdateNew(deciveModel)) deviceInfoBLL.AddNew(deciveModel);//更新栏位上传表

                        // 更新Pad成功时
                        if (recordsAssistCheckBLL.Update(saveModel, deciveModel.BarCode))
                        {
                            count++;
                            Application.DoEvents();
                        }
                        else this.cud.ConbinData(null, deciveModel.BarCode, "条码不存在");
                    }
                    else
                    {
                        RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                        if (recordModel == null && idCard.Length == 18)
                        {
                            idCard = idCard.Trim().Remove(6, 2).Remove(15);
                        }

                        RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(idCard, StringPlus.toString(deciveModel.UpdateData));

                        if (baseModel.CheckDate == null)
                        {
                            RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                            this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "没有体检资料");
                            continue;
                        }

                        deciveModel.IDCardNo = baseModel.IDCardNo;

                        // 更新栏位上传表
                        if (!deviceInfoBLL.Update(deciveModel)) deviceInfoBLL.Add(deciveModel);

                        // 更新辅助检查
                        int successNum = recordsAssistCheckBLL.UpdateAssistCheckNJ(model);

                        if (successNum > 0)
                        {
                            count++;
                            Application.DoEvents();
                        }
                        else
                        {
                            RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                            this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "体检数据更新失败");
                        }
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(model.IDCardNo);

                    this.cud.ConbinData(BaseModel, model.IDCardNo + model.BarCode, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 生化血球同步
        /// </summary>
        /// <param name="dtInfo"></param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void DataUploadByBlood(DataTable dtInfo, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            Application.DoEvents();
            DataModel model = new DataModel();
            RecordsAssistCheckModel saveModel = new RecordsAssistCheckModel();

            DataTable dtSH = null;

            if (community.Contains("福清惠铭医院") || community.Contains("小孟镇"))
            {
                if (File.Exists(Application.StartupPath + "\\SHValueRange.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(Application.StartupPath + "\\SHValueRange.xml");
                    dtSH = ds.Tables[0];
                }
            }

            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    DataRow row = dtInfo.Rows[i];
                    model = new DataModel();
                    int successNum = 0;

                    saveModel = new RecordsAssistCheckModel();

                    // 生化Model赋值
                    SetBloodModel(row, dtSH, ref saveModel, ref model);

                    // 十五位身份证判断
                    string idCard = model.IDCardNo;

                    if (StringPlus.toString(model.BarCode) == "" && StringPlus.toString(idCard) == "")
                    {
                        this.cud.ConbinData(null, model.BarCode + idCard, "条码或身份证号为空");
                        continue;
                    }

                    // 条码同步
                    if (StringPlus.toString(model.BarCode) != "")
                    {
                        // 更新血球表，更新不到则新增
                        int result = recordsAssistCheckBLL.UpdateXQNew(model);
                        if (result <= 0 && result != -2) recordsXQBLL.AddRowNew(model);

                        // 更新辅助检查
                        successNum = recordsAssistCheckBLL.UpdateAssistCheckNew(model);

                        // 更新Pad成功时
                        if (successNum > 0)
                        {
                            count++;
                            Application.DoEvents();
                        }
                        else this.cud.ConbinData(null, model.BarCode, "条码不存在");
                    }
                    else
                    {
                        RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                        if (recordModel == null && idCard.Length == 18)
                        {
                            idCard = idCard.Trim().Remove(6, 2).Remove(15);
                        }

                        RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(idCard, model.TestTime.ToString("yyyy-MM-dd"));

                        if (baseModel.CheckDate == null)
                        {
                            RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(model.IDCardNo);

                            this.cud.ConbinData(BaseModel, model.IDCardNo, "没有体检资料");
                            continue;
                        }

                        model.IDCardNo = baseModel.IDCardNo;

                        // 更新血球表，更新不到则新增
                        int result = recordsAssistCheckBLL.UpdateXQ(model);
                        if (result <= 0 && result != -2) recordsXQBLL.AddRow(model);

                        model.PersonID = baseModel.ID.ToString();   // 存储体检OutKey

                        // 更新辅助检查
                        successNum = recordsAssistCheckBLL.UpdateAssistCheck(model);

                        #region 河北血糖大于7更新其他系统疾病

                        // 血糖 > 7,其他系统疾病中显示糖尿病
                        if (versionNo.Contains("河北"))
                        {
                            decimal value = 0;

                            QuestionModel = recordsHealthQuestionBLL.GetModelByOutKey(baseModel.ID);

                            if (QuestionModel != null)
                            {
                                if (decimal.TryParse(model.FPGL, out value) && value > 7)
                                {
                                    QuestionModel.ElseDis = "2";

                                    if (!string.IsNullOrEmpty(QuestionModel.ElseOther))
                                    {
                                        if (!QuestionModel.ElseOther.Contains("糖尿病")) QuestionModel.ElseOther += ";糖尿病";
                                    }
                                    else QuestionModel.ElseOther += "糖尿病";

                                    // 更新健康问题
                                    recordsHealthQuestionBLL.UpdateOtherDis(QuestionModel, baseModel.ID.ToString());
                                }
                            }
                        }

                        #endregion

                        if (successNum > 0)
                        {
                            count++;
                            Application.DoEvents();
                        }
                        else
                        {
                            RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(model.IDCardNo);

                            this.cud.ConbinData(BaseModel, model.IDCardNo, "体检数据更新失败");
                        }
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(model.IDCardNo);

                    this.cud.ConbinData(BaseModel, model.IDCardNo + model.BarCode, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 新疆生化中的身高体重同步
        /// </summary>
        /// <param name="where"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public void DataUploadByHeight(string where, string dataType)
        {
            DataTable dtInfo = new DataTable();

            bool isExist = false;

            if (dataType.Equals("Biochemical")) isExist = accessClassBLL.GetTables("BaseInfo", BiochemicalConn);
            else isExist = accessClassBLL.GetTables("BaseInfo", BloodCorpuscleConn);

            if (isExist)
            {
                DataSet BaseInfo = new DataSet();

                if (dataType.Equals("Biochemical")) BaseInfo = accessClassBLL.GetBaseInfo(where, BiochemicalConn);
                else BaseInfo = accessClassBLL.GetBaseInfo(where, BloodCorpuscleConn);

                if (BaseInfo != null) dtInfo = BaseInfo.Tables[0];

                Application.DoEvents();
                DataModel model = new DataModel();
                RecordsAssistCheckModel saveModel = new RecordsAssistCheckModel();

                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    try
                    {
                        DataRow row = dtInfo.Rows[i];
                        model = new DataModel();

                        model.IDCardNo = row["IDCardNo"].ToString();
                        model.Height = row["Height"].ToString();
                        model.Weight = row["Weight"].ToString();
                        model.BMI = row["BMI"].ToString();
                        model.Waist = row["Waist"].ToString();

                        // 更新辅助检查
                        recordsAssistCheckBLL.UpdateWeight(model);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
        }        

        /// <summary>
        /// 心电同步
        /// </summary>
        /// <param name="EcgDataModel"></param>
        /// <param name="isWeb">是否为网站同步</param>
        /// <param name="functionName">网站同步的图片抓取方法名称</param>
        /// <param name="index">第几个同步按钮</param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void DataUploadByEcg(List<EcgDataModel> EcgDataModel, bool isWeb, string functionName, int index, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            Application.DoEvents();
            EcgDataModel ecgModel = new EcgDataModel();
            RecordsAssistCheckModel saveModel = new RecordsAssistCheckModel();

            // 根据连接字串取得图片路径
            if (index == 1) GetFromPath("ECGFileFrom", @"\\qc\勤成ECG\outFile");
            else if (index == 2) GetFromPath("ECGFileFrom2", @"\\qc\勤成ECG\outFile");
            else if (index == 3) GetFromPath("ECGFileFrom3", @"\\qc\勤成ECG\outFile");

            // 不是网站同步时，抓心电图片
            if (!isWeb) CopyFolder(strFromPathInfo, strToEcgPath);

            for (int i = 0; i < EcgDataModel.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    ecgModel = EcgDataModel[i];

                    //十五位身份证判断
                    string idCard = ecgModel.IDCard;

                    if (idCard == "")
                    {
                        this.cud.ConbinData(null, "", "身份证号为空");
                        continue;
                    }

                    RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                    if (recordModel == null && idCard.Length == 18)
                    {
                        idCard = idCard.Trim().Remove(6, 2).Remove(15);
                    }

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(idCard, ecgModel.ECGDate);

                    if (baseModel.CheckDate == null)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(ecgModel.IDCard);

                        this.cud.ConbinData(BaseModel, ecgModel.IDCard, "没有体检资料");
                        continue;
                    }

                    ecgModel.IDCard = baseModel.IDCardNo;
                    ecgModel.MID = ecgModel.examno;
                    ecgModel.CreateTime = DateTime.Parse(ecgModel.ECGDate);
                    ecgModel.Conclusion = ecgModel.ECGResultEx;
                    string strEcgV = ecgModel.ECGResult;
                    string strEcgEx = "", strEcg = "", strEcgOther = "", heartRate = ecgModel.HeartRate;

                    #region 心电异常内容

                    if (!string.IsNullOrEmpty(ecgModel.ECGResultEx))
                    {
                        if (versionNo.Contains("甘肃") || area.Equals("泸州市"))
                            strEcgEx = ecgModel.ECGResultEx.Replace("窦性心律, ", "").Replace("窦性心律,", "").Replace("窦性心律 ", "").Replace("窦性心律", "").Replace('\n', ';').Replace('\r', ' ').Replace(" ", ";").Replace("\\", "").Replace("'", "");
                        else
                            strEcgEx = ecgModel.ECGResultEx.Replace('\n', ';').Replace('\r', ' ').Replace(" ", ";").Replace("\\", "").Replace("'", "");

                        if (versionNo.Contains("山东") || versionNo.Contains("海南") || area.Equals("仪征"))
                        {
                            string[] exArg = strEcgEx.Split(new char[] { ';' });

                            foreach (string str in exArg)
                            {
                                if (versionNo.Contains("山东") && (string.IsNullOrEmpty(str) || str == "窦性心律")) continue;

                                if (str.Contains("ST-T改变")) strEcg += "2,";
                                else if (str.Contains("心肌梗塞")) strEcg += "3,";
                                else if (str.Contains("心动过速")) strEcg += "4,";
                                else if (str.Contains("心动过缓")) strEcg += "5,";
                                else if (str.Contains("早搏")) strEcg += "6,";
                                else if (str.Contains("房颤")) strEcg += "7,";
                                else if (str.Contains("房室传导阻滞")) strEcg += "8,";
                                else strEcgOther += str + ",";    // 未匹配到选项内容的则放到到其他中
                            }

                            strEcgOther = strEcgOther.TrimEnd(',');

                            // 其他中有内容时，则选项增加其他勾选项
                            if (!string.IsNullOrEmpty(strEcgOther)) strEcg += "9,";

                            strEcg = strEcg.Trim().TrimEnd(',');
                            if (versionNo.Contains("山东"))
                            {
                                if (strEcg == "")
                                {
                                    strEcg = "1";
                                }
                            }
                        }
                        else if (area.Equals("武汉"))
                        {
                            string[] exArg = strEcgEx.Split(new char[] { ';' });

                            foreach (string str in exArg)
                            {
                                if (str.Contains("早搏")) strEcg += "2,";
                                else if (str.Contains("窦性心率过缓")) strEcg += "3,";
                                else if (str.Contains("窦性心率不齐或过速")) strEcg += "4,";
                                else if (str.Contains("ST-T")) strEcg += "5,";
                                else if (str.Contains("传导阻滞")) strEcg += "6,";
                                else if (str.Contains("QRS")) strEcg += "7,";
                                else strEcgOther += str + ",";    // 未匹配到选项内容的则放到到其他中
                            }

                            strEcgOther = strEcgOther.TrimEnd(',');

                            // 其他中有内容时，则选项增加其他勾选项
                            if (!string.IsNullOrEmpty(strEcgOther)) strEcg += "8,";

                            strEcg = strEcg.Trim().TrimEnd(',');
                        }
                        else
                        {
                            strEcgOther = strEcgEx;
                            strEcg = "2";
                        }
                    }

                    #endregion

                    // 更新tbl_RecordsEcg表，先删后增
                    recordsEcgBLL.Delete(ecgModel);
                    recordsEcgBLL.Add(ecgModel);

                    bool flag = false;

                    #region 脉率心率

                    // 更新脉率，心率
                    if (!string.IsNullOrEmpty(heartRate))
                    {
                        // 云南澄江县心率脉率取偶
                        if (city.Equals("澄江县") && Convert.ToInt32(heartRate) % 2 != 0)
                        {
                            heartRate = (Convert.ToInt32(heartRate) + 1).ToString();
                        }

                        // 查体中的心率
                        recordsPhysicalExamBLL.Update(ecgModel.IDCard, baseModel.ID.ToString(), "", heartRate);

                        // 山东、吉林蛟河、磐石、张掖、湖北、云南、甘肃、江西、辽宁、河南尉氏县、贵州道真县更新一般情况中的脉率
                        if (versionNo.Contains("山东") || versionNo.Contains("云南") || versionNo.Contains("吉林") && !area.Equals("磐石") || versionNo.Contains("辽宁") || area.Equals("秀山") ||
                            versionNo.Contains("甘肃") || versionNo.Contains("江西") || city.Equals("尉氏县") || versionNo.Contains("湖北") || versionNo.Contains("贵州") || community.Contains("道真县"))
                        {
                            // 计算呼吸频率
                            string BreathRate = "";

                            // 一般情况中的呼吸频率
                            if (versionNo.Contains("山东")) BreathRate = new decimal(Convert.ToInt32(heartRate) / 4).ToString();
                            if (area.Equals("禹城"))
                                heartRate = "";
                            // 更新一般情况中的脉率
                            recordsGeneralConditionBLL.UpdateByEcg(ecgModel.IDCard, baseModel.ID.ToString(), heartRate, BreathRate);
                        }
                    }

                    #endregion

                    #region 山东更新查体中的心律

                    // 山东更新查体中的心律
                    if (strEcgV.IndexOf("异常心电图") > -1 && (versionNo.IndexOf("山东") > -1 || area.Equals("秀山")))
                    {
                        // ECGResult是异常心电图，而且是山东，ECGResult包含不齐
                        if (!string.IsNullOrEmpty(ecgModel.ECGResultEx))
                        {
                            string heartRhythm = "";

                            if (area.Equals("秀山"))
                            {
                                if (ecgModel.ECGResultEx.IndexOf("心律不齐") > -1) heartRhythm = "2";
                            }
                            else
                            {
                                if (ecgModel.ECGResultEx.IndexOf("房颤") > -1) heartRhythm = "3";
                                else if (ecgModel.ECGResultEx.IndexOf("不齐") > -1) heartRhythm = "2";
                            }

                            if (heartRhythm != "") recordsPhysicalExamBLL.Update(ecgModel.IDCard, baseModel.ID.ToString(), heartRhythm, "");
                        }
                    }

                    #endregion

                    // 新版心电判断是否正常
                    if (strEcgV.IndexOf("正常心电图") > -1)
                    {
                        strEcg = "1";
                        strEcgOther = "";
                    }

                    flag = recordsAssistCheckBLL.UpdateByEcg(ecgModel.IDCard, baseModel.ID.ToString(), strEcg, strEcgEx, "", "");

                    #region 图片处理

                    // 取得要拷贝的文件夹名
                    string strFolderName = strFromPathInfo.Substring(strFromPathInfo.LastIndexOf("\\") + 1,
                        strFromPathInfo.Length - strFromPathInfo.LastIndexOf("\\") - 1);

                    // 选择网站同步时
                    if (isWeb)
                    {
                        string img = ecgModel.Picture.Replace("\"", "");

                        // 如果图片字串不为空白时
                        if (!string.IsNullOrEmpty(img))
                        {
                            WebHelper.SaveBase64StringToImage(img, strToEcgPath + "\\" + strFolderName, ecgModel.examno + ".png", ImageFormat.Png);

                            // 重庆报告不显示正常异常
                            if (versionNo.Contains("重庆"))
                            {
                                ResetImg(strToEcgPath + "\\" + strFolderName + "\\" + ecgModel.examno + ".png");
                            }
                        }
                    }

                    if (area.Equals("南京"))
                    {
                        if (File.Exists(strToEcgPath + "\\" + strFolderName + "\\" + ecgModel.examno + ".png"))
                        {
                            if (!Directory.Exists(strToPath + "\\" + strFolderName)) Directory.CreateDirectory(strToPath + "\\" + strFolderName);

                            File.Copy(strToEcgPath + "\\" + strFolderName + "\\" + ecgModel.examno + ".png",
                                strToPath + "\\" + strFolderName + "\\" + ecgModel.IDCard + ecgModel.Name.Replace("\\", "").Replace("/", "").
                                Replace(":", "").Replace("*", "").Replace("?", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("|", "") + ".png", true);
                        }
                    }

                    #endregion

                    #region 江西、甘谷、福建更新健康问题

                    if (versionNo.Contains("江西") || area.Equals("甘谷") || versionNo.Contains("福建"))
                    {
                        // 更新健康问题
                        this.QuestionModel = recordsHealthQuestionBLL.GetModelByOutKey(baseModel.ID);

                        if (this.QuestionModel != null && strEcg == "2")
                        {
                            this.QuestionModel.HeartOther = strEcgOther;

                            if (!string.IsNullOrEmpty(this.QuestionModel.HeartDis))
                            {
                                if (this.QuestionModel.HeartDis.Contains("1")) this.QuestionModel.HeartDis = "7";
                                else if (!this.QuestionModel.HeartDis.Contains("7")) this.QuestionModel.HeartDis += ",7";
                            }
                            else this.QuestionModel.HeartDis = "7";

                            this.QuestionModel.OutKey = baseModel.ID;

                            recordsHealthQuestionBLL.Update(this.QuestionModel);
                        }
                    }

                    #endregion

                    if (flag) count++;
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(ecgModel.IDCard);

                        this.cud.ConbinData(BaseModel, ecgModel.IDCard, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(ecgModel.IDCard);

                    this.cud.ConbinData(BaseModel, ecgModel.IDCard, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 一代心电同步
        /// </summary>
        /// <param name="EcgDataModel"></param>
        /// <param name="index">第几个同步按钮</param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void DataUploadByFirstEcg(List<EcgDataModel> EcgDataModel, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            Application.DoEvents();
            EcgDataModel ecgModel = new EcgDataModel();
            RecordsAssistCheckModel saveModel = new RecordsAssistCheckModel();

            // 根据连接字串取得图片路径
            GetFromPath("ECGFileFrom", @"\\qc\勤成ECG\outFile");

            // 抓心电图片
            CopyFolder(strFromPathInfo, strToEcgPath);

            for (int i = 0; i < EcgDataModel.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    ecgModel = EcgDataModel[i];

                    //十五位身份证判断
                    string idCard = ecgModel.cardNumber;

                    if (idCard == "")
                    {
                        this.cud.ConbinData(null, "", "身份证号为空");
                        continue;
                    }

                    RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                    if (recordModel == null && idCard.Length == 18)
                    {
                        idCard = idCard.Trim().Remove(6, 2).Remove(15);
                    }

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(idCard, ecgModel.CreateTime.Value.ToString("yyyy-MM-dd"));

                    if (baseModel.CheckDate == null)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(ecgModel.cardNumber);

                        this.cud.ConbinData(BaseModel, ecgModel.cardNumber, "没有体检资料");
                        continue;
                    }

                    ecgModel.cardNumber = baseModel.IDCardNo;
                    ecgModel.IDCard = baseModel.IDCardNo;
                    ecgModel.MID = ecgModel.patientno;
                    ecgModel.CreateTime = (DateTime)(ecgModel.CreateTime);
                    ecgModel.Conclusion = ecgModel.Conclusion;
                    string strEcgEx = "", strEcg = "1";

                    if (!string.IsNullOrEmpty(ecgModel.Conclusion))
                    {
                        strEcgEx = ecgModel.Conclusion.Replace('\n', ';').Replace('\r', ' ').Replace(" ", "").Replace("\\", "").Replace("'", "");
                        strEcg = "2";
                    }

                    // 更新tbl_RecordsEcg表，先删后增
                    recordsEcgBLL.Delete(ecgModel); recordsEcgBLL.Add(ecgModel);

                    bool flag = false;

                    flag = recordsAssistCheckBLL.UpdateByEcg(ecgModel.cardNumber, baseModel.ID.ToString(), strEcg, strEcgEx, "", "");

                    if (flag) count++;
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(ecgModel.cardNumber);

                        this.cud.ConbinData(BaseModel, ecgModel.cardNumber, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(ecgModel.cardNumber);

                    this.cud.ConbinData(BaseModel, ecgModel.cardNumber, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 问询同步
        /// </summary>
        /// <param name="DeviceSqliteLs">问询</param>
        /// <param name="SelfLs">自理能力</param>
        /// <param name="ListRecordsMedication">用药</param>
        /// <param name="ListHistory">住院史、免疫史</param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        /// <param name="configPath">配置文件路径</param>
        public void DataUploadByMedical(List<DataUploadModel> DeviceSqliteLs, List<OldSelfSqliteModel> SelfLs, List<RecordsMedicationModel> ListRecordsMedication,
            List<History> ListHistory, ref int count, ProgressBar progressBar, object obj, string configPath = "")
        {
            cud = new CombinUploadData();

            RecordsCustomerBaseInfoModel customerBaseInfoModel = new RecordsCustomerBaseInfoModel();
            DataUploadModel deciveModel = new DataUploadModel();

            // 同步自理能力
            DataUploadBySelf(SelfLs, configPath);

            for (int i = 0; i < DeviceSqliteLs.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    deciveModel = DeviceSqliteLs[i];

                    //十五位身份证判断
                    string idCard = deciveModel.IDCardNo;

                    if (idCard == "")
                    {
                        this.cud.ConbinData(null, "", "身份证号为空");
                        continue;
                    }

                    RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                    if (recordModel == null && idCard.Length == 18)
                    {
                        idCard = idCard.Trim().Remove(6, 2).Remove(15);
                    }

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(idCard, deciveModel.RecordDate);

                    if (baseModel.CheckDate == null)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "没有体检资料");
                        continue;
                    }

                    List<RecordsMedicationModel> MedicationModel = new List<RecordsMedicationModel>();
                    List<History> HistoryModel = new List<History>();

                    MedicationModel = ListRecordsMedication.FindAll((RecordsMedicationModel r) => r.OutKey == deciveModel.ID);
                    HistoryModel = ListHistory.FindAll((History r) => r.OutKey == deciveModel.ID);

                    customerBaseInfoModel = new RecordsCustomerBaseInfoModel();
                    customerBaseInfoModel.ID = baseModel.ID;
                    customerBaseInfoModel.IDCardNo = deciveModel.IDCardNo;
                    customerBaseInfoModel.Symptom = deciveModel.Symptom;
                    customerBaseInfoModel.Other = deciveModel.SymptomEx;
                    deciveModel.IDCardNo = baseModel.IDCardNo;
                    deciveModel.RecordDate = baseModel.CheckDate.ToString();

                    bool flag = recordsCustomerBaseInfoBLL.Update(customerBaseInfoModel, deciveModel, MedicationModel, HistoryModel, area, versionNo);

                    // 更新Pad成功时 
                    if (flag) count++;
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, deciveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 自理能力同步
        /// </summary>
        /// <param name="SelfLs"></param>
        /// <param name="configPath">配置文件路径</param>
        public void DataUploadBySelf(List<OldSelfSqliteModel> SelfLs, string configPath = "")
        {
            cud = new CombinUploadData();

            OldSelfSqliteModel deciveSelfModel = new OldSelfSqliteModel();
            RecordsSelfcareabilityModel saveSelfModel = new RecordsSelfcareabilityModel();
            OlderSelfCareabilityModel oldSaveSelfModel = new OlderSelfCareabilityModel();
            int nextDateNum = 0;

            if (!string.IsNullOrEmpty(NextVisitDate)) int.TryParse(NextVisitDate, out nextDateNum);

            // 同步自理能力
            if (SelfLs != null)
            {
                for (int i = 0; i < SelfLs.Count; i++)
                {
                    try
                    {
                        deciveSelfModel = SelfLs[i];

                        bool saveSuccess = false;
                        string timeStr = Convert.ToDateTime(deciveSelfModel.RecordDate).ToString("yyyy-MM-dd");

                        RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(deciveSelfModel.IDCardNo);

                        if (recordModel == null) this.cud.ConbinData(recordModel, deciveSelfModel.IDCardNo, "没有基本资料");

                        #region 随访自理能力

                        if (!city.Equals("尉氏县"))
                        {
                            oldSaveSelfModel.IDCardNo = deciveSelfModel.IDCardNo;
                            oldSaveSelfModel.Dine = deciveSelfModel.Dine;
                            oldSaveSelfModel.Groming = deciveSelfModel.Groming;
                            oldSaveSelfModel.Dressing = deciveSelfModel.Dressing;
                            oldSaveSelfModel.Tolet = deciveSelfModel.Tolet;
                            oldSaveSelfModel.Activity = deciveSelfModel.Activity;
                            oldSaveSelfModel.TotalScore = deciveSelfModel.TotalScore;
                            oldSaveSelfModel.FollowUpDate = new DateTime?(DateTime.Parse(deciveSelfModel.RecordDate));

                            if (area.Equals("小龙坎社区卫生服务中心") || versionNo.Contains("山西")) oldSaveSelfModel.FollowUpDoctor = doctor;
                            else oldSaveSelfModel.FollowUpDoctor = recordModel.Doctor;

                            if (nextDateNum == 0)
                                oldSaveSelfModel.NextFollowUpDate = new DateTime?(DateTime.Parse(deciveSelfModel.RecordDate).AddYears(1));
                            else
                                oldSaveSelfModel.NextFollowUpDate = new DateTime?(DateTime.Parse(deciveSelfModel.RecordDate).AddMonths(nextDateNum));
                            oldSaveSelfModel.CreatedDate = new DateTime?(DateTime.Today);
                            oldSaveSelfModel.CreatedBy = ConfigHelper.GetNodeDec("doctor", configPath);
                            oldSaveSelfModel.LastUpDateBy = oldSaveSelfModel.CreatedBy;
                            oldSaveSelfModel.LastUpDateDate = new DateTime?(DateTime.Today);
                            oldSaveSelfModel.NextVisitAim = "低盐饮食，预防高血压";

                            // 修改不到资料则新增
                            if (!oldSelfCareBLL.UpdateByUpload(oldSaveSelfModel))
                            {
                                oldSelfCareBLL.Add(oldSaveSelfModel, versionNo);

                                saveSuccess = true;
                            }
                        }

                        #endregion

                        #region 体检自理能力

                        if (!city.Equals("尉氏县"))
                        {
                            RecordsCustomerBaseInfoModel baseModel = new RecordsCustomerBaseInfoBLL().GetModelByCheckDate(deciveSelfModel.IDCardNo, timeStr);

                            if (baseModel.CheckDate == null) continue;

                            deciveSelfModel.RecordDate = baseModel.CheckDate.Value.ToString("yyyy-MM-dd");

                            saveSelfModel.IDCardNo = deciveSelfModel.IDCardNo;
                            saveSelfModel.Dine = deciveSelfModel.Dine;
                            saveSelfModel.Groming = deciveSelfModel.Groming;
                            saveSelfModel.Dressing = deciveSelfModel.Dressing;
                            saveSelfModel.Tolet = deciveSelfModel.Tolet;
                            saveSelfModel.Activity = deciveSelfModel.Activity;
                            saveSelfModel.TotalScore = deciveSelfModel.TotalScore;
                            saveSelfModel.FollowUpDate = Convert.ToDateTime(deciveSelfModel.RecordDate);
                            saveSelfModel.FollowUpDoctor = baseModel.Doctor;
                            saveSelfModel.OutKey = baseModel.ID.ToString();

                            if (nextDateNum == 0) saveSelfModel.NextFollowUpDate = Convert.ToDateTime(deciveSelfModel.RecordDate).AddYears(1);
                            else saveSelfModel.NextFollowUpDate = Convert.ToDateTime(deciveSelfModel.RecordDate).AddMonths(nextDateNum);

                            saveSelfModel.CreatedDate = new DateTime?(DateTime.Today);
                            saveSelfModel.CreatedBy = ConfigHelper.GetNodeDec("doctor", configPath);
                            saveSelfModel.LastUpDateBy = saveSelfModel.CreatedBy;
                            saveSelfModel.LastUpDateDate = new DateTime?(DateTime.Today);

                            string OldSelfCareability = "";

                            if (saveSelfModel.TotalScore <= 3M) OldSelfCareability = "1";
                            else if ((saveSelfModel.TotalScore >= 4M) && (saveSelfModel.TotalScore <= 8M)) OldSelfCareability = "2";
                            else if ((saveSelfModel.TotalScore >= 9M) && (saveSelfModel.TotalScore <= 18M)) OldSelfCareability = "3";
                            else if (saveSelfModel.TotalScore >= 19M) OldSelfCareability = "4";

                            timeStr = Convert.ToDateTime(deciveSelfModel.RecordDate).ToShortDateString();

                            if (selfCareBLL.UpdateByMiniPad(saveSelfModel, timeStr, OldSelfCareability)) saveSuccess = true;
                            else
                            {
                                int addSelfID = selfCareBLL.Add(saveSelfModel);

                                // 修改体检表
                                if (addSelfID > 0) selfCareBLL.UpdateGeneral(deciveSelfModel.IDCardNo, timeStr, addSelfID, OldSelfCareability);

                                saveSuccess = true;
                            }
                        }

                        #endregion                        

                        // 更新Pad成功时 
                        if (!saveSuccess)
                        {
                            RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveSelfModel.IDCardNo);

                            this.cud.ConbinData(BaseModel, "自理能力:" + deciveSelfModel.IDCardNo, "体检数据更新失败");
                        }
                    }
                    catch (Exception ex)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveSelfModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, "自理能力:" + deciveSelfModel.IDCardNo, ex.ToString());
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 中医同步
        /// </summary>
        /// <param name="DeviceSqliteLs">中医</param>
        /// <param name="SelfLs">自理能力</param>
        /// <param name="GloomyLs">抑郁评估</param>
        /// <param name="IntelligenceLs">智力评估</param>
        /// <param name="HealthConditionLs">健康状况</param>
        /// <param name="count"></param>
        /// <param name="progressBar">2.0进度条</param>
        /// <param name="obj">3.0进度条</param>
        /// <param name="configPath">配置文件路径</param>
        public void DataUploadByOld(List<MedicineModel> DeviceSqliteLs, bool isWeb, List<OldSelfSqliteModel> SelfLs, List<OldGloomyModel> GloomyLs, List<OldIntelligenceModel> IntelligenceLs,
            List<RecordsHealthConditionModel> HealthConditionLs, ref int count, ProgressBar progressBar, object obj, string configPath = "")
        {
            cud = new CombinUploadData();
            int nextDateNum = 0;

            if (!string.IsNullOrEmpty(NextVisitDate)) int.TryParse(NextVisitDate, out nextDateNum);

            RecordsCustomerBaseInfoModel customerBaseInfoModel = new RecordsCustomerBaseInfoModel();
            MedicineModel saveResultModel = new MedicineModel();
            DataTable dtOldCN = new DataTable();

            if (File.Exists(Application.StartupPath + "\\OldCN.xml"))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Application.StartupPath + "\\OldCN.xml");

                dtOldCN = ds.Tables[0];
            }

            // 同步自理能力
            DataUploadBySelf(SelfLs);

            // 同步抑郁评估
            DataUploadByGloomy(GloomyLs);

            // 同步智力评估
            DataUploadByIntelligence(IntelligenceLs);

            // 同步健康状况
            DataUploadByHealth(HealthConditionLs);

            // 吉林共享同步指纹签字图片
            if (versionNo.Contains("吉林") && (area.Equals("") || area.Equals("磐石")))
            {
                if (!isWeb)
                {
                    // 同步签字图片
                    CopyFolder(strFromSign, strToSign);

                    // 同步指纹图片
                    CopyFolder(strFromFinger, strToFinger);
                }
            }

            for (int i = 0; i < DeviceSqliteLs.Count; i++)
            {
                bool saveSuccess = false;

                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    MedicineModel deciveResultModel = DeviceSqliteLs[i];

                    //十五位身份证判断
                    string idCard = deciveResultModel.IDCardNo;

                    if (idCard == "")
                    {
                        this.cud.ConbinData(null, "", "身份证号为空");
                        continue;
                    }

                    RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                    if (recordModel == null && idCard.Length == 18)
                    {
                        idCard = idCard.Trim().Remove(6, 2).Remove(15);
                    }

                    if (area.Equals("小龙坎社区卫生服务中心") || versionNo.Contains("山西")) deciveResultModel.FollowUpDoctor = doctor;
                    else deciveResultModel.FollowUpDoctor = recordModel.Doctor;

                    #region 陕西 每人最多有2种体质 其他体质分数降低 且 是、倾向是改为空   陇川县、河北每人最多有1种体质

                    if (versionNo.Contains("河北") || versionNo.Contains("陕西") || city.Equals("陇川县"))
                    {
                        decimal? max = 0, maxTwo = 0;
                        string maxName = "", maxTwoName = "", tz = "";

                        #region 获取最高分体质(是、倾向是)

                        if ((deciveResultModel.Faint == "1" || deciveResultModel.Faint == "2") && deciveResultModel.FaintScore > max)
                        {
                            max = deciveResultModel.FaintScore;
                            maxName = "FaintScore";
                        }
                        if ((deciveResultModel.Yang == "1" || deciveResultModel.Yang == "2") && deciveResultModel.YangsCore > max)
                        {
                            max = deciveResultModel.YangsCore;
                            maxName = "YangsCore";
                        }
                        if ((deciveResultModel.Yin == "1" || deciveResultModel.Yin == "2") && deciveResultModel.YinScore > max)
                        {
                            max = deciveResultModel.YinScore;
                            maxName = "YinScore";
                        }
                        if ((deciveResultModel.PhlegmDamp == "1" || deciveResultModel.PhlegmDamp == "2") && deciveResultModel.PhlegmdampScore > max)
                        {
                            max = deciveResultModel.PhlegmdampScore;
                            maxName = "PhlegmdampScore";
                        }
                        if ((deciveResultModel.Muggy == "1" || deciveResultModel.Muggy == "2") && deciveResultModel.MuggyScore > max)
                        {
                            max = deciveResultModel.MuggyScore;
                            maxName = "MuggyScore";
                        }
                        if ((deciveResultModel.BloodStasis == "1" || deciveResultModel.BloodStasis == "2") && deciveResultModel.BloodStasisScore > max)
                        {
                            max = deciveResultModel.BloodStasisScore;
                            maxName = "BloodStasisScore";
                        }
                        if ((deciveResultModel.QiConstraint == "1" || deciveResultModel.QiConstraint == "2") && deciveResultModel.QiConstraintScore > max)
                        {
                            max = deciveResultModel.QiConstraintScore;
                            maxName = "QiConstraintScore";
                        }
                        if ((deciveResultModel.Characteristic == "1" || deciveResultModel.Characteristic == "2") && deciveResultModel.CharacteristicScore > max)
                        {
                            max = deciveResultModel.CharacteristicScore;
                            maxName = "CharacteristicScore";
                        }

                        // 河北，如果为其他体质11分以上，去掉平和质的
                        if (versionNo.Contains("河北"))
                        {
                            if (deciveResultModel.Faint == "1" || deciveResultModel.Faint == "2" || deciveResultModel.Yang == "1" || deciveResultModel.Yang == "2" || deciveResultModel.Yin == "1" || deciveResultModel.Yin == "2" ||
                                deciveResultModel.PhlegmDamp == "1" || deciveResultModel.PhlegmDamp == "2" || deciveResultModel.Muggy == "1" || deciveResultModel.Muggy == "2" ||
                                deciveResultModel.BloodStasis == "1" || deciveResultModel.BloodStasis == "2" || deciveResultModel.QiConstraint == "1" || deciveResultModel.QiConstraint == "2" ||
                                deciveResultModel.Characteristic == "1" || deciveResultModel.Characteristic == "2")
                            {
                                deciveResultModel.Mild = null;
                                deciveResultModel.MildScore = 0;
                            }
                        }
                        else
                        {
                            if ((deciveResultModel.Mild == "1" || deciveResultModel.Mild == "2") && deciveResultModel.MildScore > max)
                            {
                                max = deciveResultModel.MildScore;
                                maxName = "MildScore";
                            }
                        }

                        #endregion

                        if (versionNo.Contains("陕西"))
                        {
                            #region 获取第二高分体质

                            if ((deciveResultModel.Mild == "1" || deciveResultModel.Mild == "2") && deciveResultModel.MildScore > maxTwo && maxName != "MildScore")
                            {
                                maxTwo = deciveResultModel.MildScore;
                                maxTwoName = "MildScore";
                                tz = deciveResultModel.Mild;
                            }
                            if ((deciveResultModel.Faint == "1" || deciveResultModel.Faint == "2") && deciveResultModel.FaintScore > maxTwo && maxName != "FaintScore")
                            {
                                maxTwo = deciveResultModel.FaintScore;
                                maxTwoName = "FaintScore";
                                tz = deciveResultModel.Faint;
                            }
                            if ((deciveResultModel.Yang == "1" || deciveResultModel.Yang == "2") && deciveResultModel.YangsCore > maxTwo && maxName != "YangsCore")
                            {
                                maxTwo = deciveResultModel.YangsCore;
                                maxTwoName = "YangsCore";
                                tz = deciveResultModel.Yang;
                            }
                            if ((deciveResultModel.Yin == "1" || deciveResultModel.Yin == "2") && deciveResultModel.YinScore > maxTwo && maxName != "YinScore")
                            {
                                maxTwo = deciveResultModel.YinScore;
                                maxTwoName = "YinScore";
                                tz = deciveResultModel.Yin;
                            }
                            if ((deciveResultModel.PhlegmDamp == "1" || deciveResultModel.PhlegmDamp == "2") && deciveResultModel.PhlegmdampScore > maxTwo && maxName != "PhlegmdampScore")
                            {
                                maxTwo = deciveResultModel.PhlegmdampScore;
                                maxTwoName = "PhlegmdampScore";
                                tz = deciveResultModel.PhlegmDamp;
                            }
                            if ((deciveResultModel.Muggy == "1" || deciveResultModel.Muggy == "2") && deciveResultModel.MuggyScore > maxTwo && maxName != "MuggyScore")
                            {
                                maxTwo = deciveResultModel.MuggyScore;
                                maxTwoName = "MuggyScore";
                                tz = deciveResultModel.Muggy;
                            }
                            if ((deciveResultModel.BloodStasis == "1" || deciveResultModel.BloodStasis == "2") && deciveResultModel.BloodStasisScore > maxTwo && maxName != "BloodStasisScore")
                            {
                                maxTwo = deciveResultModel.BloodStasisScore;
                                maxTwoName = "BloodStasisScore";
                                tz = deciveResultModel.BloodStasis;
                            }
                            if ((deciveResultModel.QiConstraint == "1" || deciveResultModel.QiConstraint == "2") && deciveResultModel.QiConstraintScore > maxTwo && maxName != "QiConstraintScore")
                            {
                                maxTwo = deciveResultModel.QiConstraintScore;
                                maxTwoName = "QiConstraintScore";
                                tz = deciveResultModel.QiConstraint;
                            }
                            if ((deciveResultModel.Characteristic == "1" || deciveResultModel.Characteristic == "2") && deciveResultModel.CharacteristicScore > maxTwo && maxName != "CharacteristicScore")
                            {
                                maxTwo = deciveResultModel.CharacteristicScore;
                                maxTwoName = "CharacteristicScore";
                                tz = deciveResultModel.Characteristic;
                            }

                            #endregion
                        }

                        #region 除最大值 其他都减分到1

                        switch (maxName)
                        {
                            case "MildScore":
                                deciveResultModel.Faint = "";
                                deciveResultModel.Yang = "";
                                deciveResultModel.Yin = "";
                                deciveResultModel.PhlegmDamp = "";
                                deciveResultModel.Muggy = "";
                                deciveResultModel.BloodStasis = "";
                                deciveResultModel.QiConstraint = "";
                                deciveResultModel.Characteristic = "";
                                break;
                            case "FaintScore":
                                deciveResultModel.Yang = "";
                                deciveResultModel.Yin = "";
                                deciveResultModel.PhlegmDamp = "";
                                deciveResultModel.Muggy = "";
                                deciveResultModel.BloodStasis = "";
                                deciveResultModel.QiConstraint = "";
                                deciveResultModel.Characteristic = "";
                                break;
                            case "YangsCore":
                                deciveResultModel.Faint = "";
                                deciveResultModel.Yin = "";
                                deciveResultModel.PhlegmDamp = "";
                                deciveResultModel.Muggy = "";
                                deciveResultModel.BloodStasis = "";
                                deciveResultModel.QiConstraint = "";
                                deciveResultModel.Characteristic = "";
                                break;
                            case "YinScore":
                                deciveResultModel.Faint = "";
                                deciveResultModel.Yang = "";
                                deciveResultModel.PhlegmDamp = "";
                                deciveResultModel.Muggy = "";
                                deciveResultModel.BloodStasis = "";
                                deciveResultModel.QiConstraint = "";
                                deciveResultModel.Characteristic = "";
                                break;
                            case "PhlegmdampScore":
                                deciveResultModel.Faint = "";
                                deciveResultModel.Yang = "";
                                deciveResultModel.Yin = "";
                                deciveResultModel.Muggy = "";
                                deciveResultModel.BloodStasis = "";
                                deciveResultModel.QiConstraint = "";
                                deciveResultModel.Characteristic = "";
                                break;
                            case "MuggyScore":
                                deciveResultModel.Faint = "";
                                deciveResultModel.Yang = "";
                                deciveResultModel.Yin = "";
                                deciveResultModel.PhlegmDamp = "";
                                deciveResultModel.BloodStasis = "";
                                deciveResultModel.QiConstraint = "";
                                deciveResultModel.Characteristic = "";
                                break;
                            case "BloodStasisScore":
                                deciveResultModel.Faint = "";
                                deciveResultModel.Yang = "";
                                deciveResultModel.Yin = "";
                                deciveResultModel.PhlegmDamp = "";
                                deciveResultModel.Muggy = "";
                                deciveResultModel.QiConstraint = "";
                                deciveResultModel.Characteristic = "";
                                break;
                            case "QiConstraintScore":
                                deciveResultModel.Faint = "";
                                deciveResultModel.Yang = "";
                                deciveResultModel.Yin = "";
                                deciveResultModel.PhlegmDamp = "";
                                deciveResultModel.Muggy = "";
                                deciveResultModel.BloodStasis = "";
                                deciveResultModel.Characteristic = "";
                                break;
                            case "CharacteristicScore":
                                deciveResultModel.Faint = "";
                                deciveResultModel.Yang = "";
                                deciveResultModel.Yin = "";
                                deciveResultModel.PhlegmDamp = "";
                                deciveResultModel.Muggy = "";
                                deciveResultModel.BloodStasis = "";
                                deciveResultModel.QiConstraint = "";
                                break;
                        }

                        #endregion

                        if (versionNo.Contains("陕西"))
                        {
                            #region 第二高分 重新赋值分数

                            switch (maxTwoName)
                            {
                                case "MildScore":
                                    deciveResultModel.MildScore = maxTwo;
                                    deciveResultModel.Mild = tz;
                                    break;
                                case "FaintScore":
                                    deciveResultModel.FaintScore = maxTwo;
                                    deciveResultModel.Faint = tz;
                                    break;
                                case "YangsCore":
                                    deciveResultModel.YangsCore = maxTwo;
                                    deciveResultModel.Yang = tz;
                                    break;
                                case "YinScore":
                                    deciveResultModel.YinScore = maxTwo;
                                    deciveResultModel.Yin = tz;
                                    break;
                                case "PhlegmdampScore":
                                    deciveResultModel.PhlegmdampScore = maxTwo;
                                    deciveResultModel.PhlegmDamp = tz;
                                    break;
                                case "MuggyScore":
                                    deciveResultModel.MuggyScore = maxTwo;
                                    deciveResultModel.Muggy = tz;
                                    break;
                                case "BloodStasisScore":
                                    deciveResultModel.BloodStasisScore = maxTwo;
                                    deciveResultModel.BloodStasis = tz;
                                    break;
                                case "QiConstraintScore":
                                    deciveResultModel.QiConstraintScore = maxTwo;
                                    deciveResultModel.QiConstraint = tz;
                                    break;
                                case "CharacteristicScore":
                                    deciveResultModel.CharacteristicScore = maxTwo;
                                    deciveResultModel.Characteristic = tz;
                                    break;
                            }

                            #endregion
                        }
                    }

                    #endregion

                    #region 河北、开封 体质为是 或者倾向是时，指导块除了其他，都勾选上

                    if (versionNo.Contains("河北") || area.Equals("武汉") || area.Equals("开封") || (versionNo.Contains("山东") && !area.Equals("济宁")) || versionNo.Contains("贵州"))
                    {
                        if ((deciveResultModel.Mild == "1" || deciveResultModel.Mild == "2"))
                        {
                            deciveResultModel.MildAdvising = "1,2,3,4,5";
                        }
                        if ((deciveResultModel.Faint == "1" || deciveResultModel.Faint == "2"))
                        {
                            deciveResultModel.FaintAdvising = "1,2,3,4,5";
                        }
                        if ((deciveResultModel.Yang == "1" || deciveResultModel.Yang == "2"))
                        {
                            deciveResultModel.YangAdvising = "1,2,3,4,5";
                        }
                        if ((deciveResultModel.Yin == "1" || deciveResultModel.Yin == "2"))
                        {
                            deciveResultModel.YinAdvising = "1,2,3,4,5";
                        }
                        if ((deciveResultModel.PhlegmDamp == "1" || deciveResultModel.PhlegmDamp == "2"))
                        {
                            deciveResultModel.PhlegmdampAdvising = "1,2,3,4,5";
                        }
                        if ((deciveResultModel.Muggy == "1" || deciveResultModel.Muggy == "2"))
                        {
                            deciveResultModel.MuggyAdvising = "1,2,3,4,5";
                        }
                        if ((deciveResultModel.BloodStasis == "1" || deciveResultModel.BloodStasis == "2"))
                        {
                            deciveResultModel.BloodStasisAdvising = "1,2,3,4,5";
                        }
                        if ((deciveResultModel.QiConstraint == "1" || deciveResultModel.QiConstraint == "2"))
                        {
                            deciveResultModel.QiconstraintAdvising = "1,2,3,4,5";
                        }
                        if ((deciveResultModel.Characteristic == "1" || deciveResultModel.Characteristic == "2"))
                        {
                            deciveResultModel.CharacteristicAdvising = "1,2,3,4,5";
                        }
                    }

                    #endregion

                    #region 随访

                    string selfWhere = string.Format("IDCardNo='{0}' AND FollowUpDate='{1}' ", deciveResultModel.IDCardNo, deciveResultModel.RecordDate);

                    if (versionNo.Contains("3.0"))
                        selfWhere = string.Format("IDCardNo='{0}' AND VisitDate='{1}' ", deciveResultModel.IDCardNo, deciveResultModel.RecordDate);

                    // 同步到随访
                    OlderSelfCareabilityModel oldSelf = oldSelfCareBLL.CheckModel(selfWhere);

                    if (oldSelf == null)
                    {
                        DateTime time;

                        if (nextDateNum == 0) time = Convert.ToDateTime(deciveResultModel.RecordDate).AddYears(1);
                        else time = Convert.ToDateTime(deciveResultModel.RecordDate).AddMonths(nextDateNum);

                        OlderSelfCareabilityModel oldSelfTemp = new OlderSelfCareabilityModel
                        {
                            IDCardNo = idCard,
                            Dine = 0,
                            Groming = 0,
                            Dressing = 0,
                            Tolet = 0,
                            Activity = 0,
                            TotalScore = 0,
                            FollowUpDoctor = recordModel.Doctor,
                            FollowUpDate = Convert.ToDateTime(deciveResultModel.RecordDate),
                            NextFollowUpDate = time,
                            CreatedDate = new DateTime?(DateTime.Today),
                            CreatedBy = ConfigHelper.GetNodeDec("doctor", configPath),
                            LastUpDateBy = ConfigHelper.GetNodeDec("doctor", configPath),
                            LastUpDateDate = new DateTime?(DateTime.Today)
                        };

                        if (area.Equals("小龙坎社区卫生服务中心") || versionNo.Contains("山西")) oldSelfTemp.FollowUpDoctor = doctor;

                        int outKey = oldSelfCareBLL.Add(oldSelfTemp, versionNo);

                        deciveResultModel.OutKey = outKey;
                        deciveResultModel.FollowUpDoctor = oldSelfTemp.FollowUpDoctor;

                        int MedicineID = oldRecordsMedicineCnBLL.Add(deciveResultModel, versionNo);

                        // 新增随访
                        if (MedicineID > 0) saveSuccess = true;

                        // 老年人中医体质辨识Key
                        deciveResultModel.MedicineID = MedicineID;

                        if (oldRecordsMedicineResultBLL.Add(deciveResultModel, versionNo) > 0) saveSuccess = true;
                    }
                    else
                    {
                        deciveResultModel.OutKey = oldSelf.ID;
                        deciveResultModel.FollowUpDoctor = oldSelf.FollowUpDoctor;

                        // 同步到随访
                        OlderMedicineCnModel oldSelfMedicine = oldRecordsMedicineCnBLL.GetModel(oldSelf.ID, deciveResultModel.IDCardNo, deciveResultModel.RecordDate, versionNo);

                        // 修改不到则新增随访
                        if (oldRecordsMedicineCnBLL.Update(deciveResultModel, versionNo)) saveSuccess = true;
                        else
                        {
                            oldSelfMedicine.ID = oldRecordsMedicineCnBLL.Add(deciveResultModel);
                            saveSuccess = true;
                        }

                        // 老年人中医体质辨识Key
                        deciveResultModel.MedicineID = oldSelfMedicine.ID;

                        if (oldRecordsMedicineResultBLL.Update(deciveResultModel, versionNo)) saveSuccess = true;
                        else if (oldRecordsMedicineResultBLL.Add(deciveResultModel) > 0) saveSuccess = true;
                    }

                    #endregion

                    #region 体检

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(idCard, deciveResultModel.RecordDate);

                    if (baseModel.CheckDate != null)
                    {
                        deciveResultModel.RecordDate = baseModel.CheckDate.Value.ToString("yyyy-MM-dd");

                        saveResultModel = new MedicineModel();
                        saveResultModel = deciveResultModel;
                        saveResultModel.CreatedDate = new DateTime?(DateTime.Today);
                        saveResultModel.CreatedBy = ConfigHelper.GetNodeDec("doctor", configPath);
                        saveResultModel.LastUpdateBy = ConfigHelper.GetNodeDec("doctor", configPath);
                        saveResultModel.LastUpdateDate = new DateTime?(DateTime.Today);
                        saveResultModel.EffectAssess = "2";
                        saveResultModel.Satisfy = "1";
                        saveResultModel.OutKey = baseModel.ID;

                        if (area.Equals("小龙坎社区卫生服务中心") || versionNo.Contains("山西")) saveResultModel.FollowUpDoctor = doctor;
                        else saveResultModel.FollowUpDoctor = baseModel.Doctor;

                        #region 云南平和质是倾向是，其他体质有多项是是或倾向是，勾选分数最高一项体质的指导

                        if (versionNo.Contains("云南") && !city.Equals("陇川县"))
                        {
                            // 平和质是倾向是
                            if (deciveResultModel.Mild == "2")
                            {
                                #region 获取最高分体质(是、倾向是)

                                decimal? max = 0;
                                string maxName = "";

                                if ((deciveResultModel.Faint == "1" || deciveResultModel.Faint == "2") && deciveResultModel.FaintScore > max)
                                {
                                    max = deciveResultModel.FaintScore;
                                    maxName = "FaintScore";
                                }
                                if ((deciveResultModel.Yang == "1" || deciveResultModel.Yang == "2") && deciveResultModel.YangsCore > max)
                                {
                                    max = deciveResultModel.YangsCore;
                                    maxName = "YangsCore";
                                }
                                if ((deciveResultModel.Yin == "1" || deciveResultModel.Yin == "2") && deciveResultModel.YinScore > max)
                                {
                                    max = deciveResultModel.YinScore;
                                    maxName = "YinScore";
                                }
                                if ((deciveResultModel.PhlegmDamp == "1" || deciveResultModel.PhlegmDamp == "2") && deciveResultModel.PhlegmdampScore > max)
                                {
                                    max = deciveResultModel.PhlegmdampScore;
                                    maxName = "PhlegmdampScore";
                                }
                                if ((deciveResultModel.Muggy == "1" || deciveResultModel.Muggy == "2") && deciveResultModel.MuggyScore > max)
                                {
                                    max = deciveResultModel.MuggyScore;
                                    maxName = "MuggyScore";
                                }
                                if ((deciveResultModel.BloodStasis == "1" || deciveResultModel.BloodStasis == "2") && deciveResultModel.BloodStasisScore > max)
                                {
                                    max = deciveResultModel.BloodStasisScore;
                                    maxName = "BloodStasisScore";
                                }
                                if ((deciveResultModel.QiConstraint == "1" || deciveResultModel.QiConstraint == "2") && deciveResultModel.QiConstraintScore > max)
                                {
                                    max = deciveResultModel.QiConstraintScore;
                                    maxName = "QiConstraintScore";
                                }
                                if ((deciveResultModel.Characteristic == "1" || deciveResultModel.Characteristic == "2") && deciveResultModel.CharacteristicScore > max)
                                {
                                    max = deciveResultModel.CharacteristicScore;
                                    maxName = "CharacteristicScore";
                                }
                                switch (maxName)
                                {
                                    case "FaintScore":
                                        saveResultModel.MildAdvising = "";
                                        saveResultModel.YangAdvising = "";
                                        saveResultModel.YinAdvising = "";
                                        saveResultModel.PhlegmdampAdvising = "";
                                        saveResultModel.MuggyAdvising = "";
                                        saveResultModel.BloodStasisAdvising = "";
                                        saveResultModel.QiconstraintAdvising = "";
                                        saveResultModel.CharacteristicAdvising = "";
                                        break;
                                    case "YangsCore":
                                        saveResultModel.MildAdvising = "";
                                        saveResultModel.FaintAdvising = "";
                                        saveResultModel.YinAdvising = "";
                                        saveResultModel.PhlegmdampAdvising = "";
                                        saveResultModel.MuggyAdvising = "";
                                        saveResultModel.BloodStasisAdvising = "";
                                        saveResultModel.QiconstraintAdvising = "";
                                        saveResultModel.CharacteristicAdvising = "";
                                        break;
                                    case "YinScore":
                                        saveResultModel.MildAdvising = "";
                                        saveResultModel.FaintAdvising = "";
                                        saveResultModel.YangAdvising = "";
                                        saveResultModel.PhlegmdampAdvising = "";
                                        saveResultModel.MuggyAdvising = "";
                                        saveResultModel.BloodStasisAdvising = "";
                                        saveResultModel.QiconstraintAdvising = "";
                                        saveResultModel.CharacteristicAdvising = "";
                                        break;
                                    case "PhlegmdampScore":
                                        saveResultModel.MildAdvising = "";
                                        saveResultModel.FaintAdvising = "";
                                        saveResultModel.YangAdvising = "";
                                        saveResultModel.YinAdvising = "";
                                        saveResultModel.MuggyAdvising = "";
                                        saveResultModel.BloodStasisAdvising = "";
                                        saveResultModel.QiconstraintAdvising = "";
                                        saveResultModel.CharacteristicAdvising = "";
                                        break;
                                    case "MuggyScore":
                                        saveResultModel.MildAdvising = "";
                                        saveResultModel.FaintAdvising = "";
                                        saveResultModel.YangAdvising = "";
                                        saveResultModel.YinAdvising = "";
                                        saveResultModel.PhlegmdampAdvising = "";
                                        saveResultModel.BloodStasisAdvising = "";
                                        saveResultModel.QiconstraintAdvising = "";
                                        saveResultModel.CharacteristicAdvising = "";
                                        break;
                                    case "BloodStasisScore":
                                        saveResultModel.MildAdvising = "";
                                        saveResultModel.FaintAdvising = "";
                                        saveResultModel.YangAdvising = "";
                                        saveResultModel.YinAdvising = "";
                                        saveResultModel.PhlegmdampAdvising = "";
                                        saveResultModel.MuggyAdvising = "";
                                        saveResultModel.QiconstraintAdvising = "";
                                        saveResultModel.CharacteristicAdvising = "";
                                        break;
                                    case "QiConstraintScore":
                                        saveResultModel.MildAdvising = "";
                                        saveResultModel.FaintAdvising = "";
                                        saveResultModel.YangAdvising = "";
                                        saveResultModel.YinAdvising = "";
                                        saveResultModel.PhlegmdampAdvising = "";
                                        saveResultModel.MuggyAdvising = "";
                                        saveResultModel.BloodStasisAdvising = "";
                                        saveResultModel.CharacteristicAdvising = "";
                                        break;
                                    case "CharacteristicScore":
                                        saveResultModel.MildAdvising = "";
                                        saveResultModel.FaintAdvising = "";
                                        saveResultModel.YangAdvising = "";
                                        saveResultModel.YinAdvising = "";
                                        saveResultModel.PhlegmdampAdvising = "";
                                        saveResultModel.MuggyAdvising = "";
                                        saveResultModel.BloodStasisAdvising = "";
                                        saveResultModel.QiconstraintAdvising = "";
                                        break;
                                }

                                #endregion
                            }
                        }

                        #endregion

                        #region 四川体质有多项是是或倾向是，勾选分数最高一项

                        if (versionNo.Contains("四川"))
                        {
                            #region 获取最高分体质(是、倾向是)

                            decimal? max = 0;
                            string maxName = "";

                            if ((deciveResultModel.Mild == "1" || deciveResultModel.Mild == "2") && deciveResultModel.MildScore > max)
                            {
                                max = deciveResultModel.MildScore;
                                maxName = "MildScore";
                            }
                            if ((deciveResultModel.Faint == "1" || deciveResultModel.Faint == "2") && deciveResultModel.FaintScore > max)
                            {
                                max = deciveResultModel.FaintScore;
                                maxName = "FaintScore";
                            }
                            if ((deciveResultModel.Yang == "1" || deciveResultModel.Yang == "2") && deciveResultModel.YangsCore > max)
                            {
                                max = deciveResultModel.YangsCore;
                                maxName = "YangsCore";
                            }
                            if ((deciveResultModel.Yin == "1" || deciveResultModel.Yin == "2") && deciveResultModel.YinScore > max)
                            {
                                max = deciveResultModel.YinScore;
                                maxName = "YinScore";
                            }
                            if ((deciveResultModel.PhlegmDamp == "1" || deciveResultModel.PhlegmDamp == "2") && deciveResultModel.PhlegmdampScore > max)
                            {
                                max = deciveResultModel.PhlegmdampScore;
                                maxName = "PhlegmdampScore";
                            }
                            if ((deciveResultModel.Muggy == "1" || deciveResultModel.Muggy == "2") && deciveResultModel.MuggyScore > max)
                            {
                                max = deciveResultModel.MuggyScore;
                                maxName = "MuggyScore";
                            }
                            if ((deciveResultModel.BloodStasis == "1" || deciveResultModel.BloodStasis == "2") && deciveResultModel.BloodStasisScore > max)
                            {
                                max = deciveResultModel.BloodStasisScore;
                                maxName = "BloodStasisScore";
                            }
                            if ((deciveResultModel.QiConstraint == "1" || deciveResultModel.QiConstraint == "2") && deciveResultModel.QiConstraintScore > max)
                            {
                                max = deciveResultModel.QiConstraintScore;
                                maxName = "QiConstraintScore";
                            }
                            if ((deciveResultModel.Characteristic == "1" || deciveResultModel.Characteristic == "2") && deciveResultModel.CharacteristicScore > max)
                            {
                                max = deciveResultModel.CharacteristicScore;
                                maxName = "CharacteristicScore";
                            }

                            switch (maxName)
                            {
                                case "MildScore":
                                    saveResultModel.Faint = "";
                                    saveResultModel.Yang = "";
                                    saveResultModel.Yin = "";
                                    saveResultModel.PhlegmDamp = "";
                                    saveResultModel.Muggy = "";
                                    saveResultModel.BloodStasis = "";
                                    saveResultModel.QiConstraint = "";
                                    saveResultModel.Characteristic = "";
                                    break;
                                case "FaintScore":
                                    saveResultModel.Mild = "";
                                    saveResultModel.Yang = "";
                                    saveResultModel.Yin = "";
                                    saveResultModel.PhlegmDamp = "";
                                    saveResultModel.Muggy = "";
                                    saveResultModel.BloodStasis = "";
                                    saveResultModel.QiConstraint = "";
                                    saveResultModel.Characteristic = "";
                                    break;
                                case "YangsCore":
                                    saveResultModel.Mild = "";
                                    saveResultModel.Faint = "";
                                    saveResultModel.Yin = "";
                                    saveResultModel.PhlegmDamp = "";
                                    saveResultModel.Muggy = "";
                                    saveResultModel.BloodStasis = "";
                                    saveResultModel.QiConstraint = "";
                                    saveResultModel.Characteristic = "";
                                    break;
                                case "YinScore":
                                    saveResultModel.Mild = "";
                                    saveResultModel.Faint = "";
                                    saveResultModel.Yang = "";
                                    saveResultModel.PhlegmDamp = "";
                                    saveResultModel.Muggy = "";
                                    saveResultModel.BloodStasis = "";
                                    saveResultModel.QiConstraint = "";
                                    saveResultModel.Characteristic = "";
                                    break;
                                case "PhlegmdampScore":
                                    saveResultModel.Mild = "";
                                    saveResultModel.Faint = "";
                                    saveResultModel.Yang = "";
                                    saveResultModel.Yin = "";
                                    saveResultModel.Muggy = "";
                                    saveResultModel.BloodStasis = "";
                                    saveResultModel.QiConstraint = "";
                                    saveResultModel.Characteristic = "";
                                    break;
                                case "MuggyScore":
                                    saveResultModel.Mild = "";
                                    saveResultModel.Faint = "";
                                    saveResultModel.Yang = "";
                                    saveResultModel.Yin = "";
                                    saveResultModel.PhlegmDamp = "";
                                    saveResultModel.BloodStasis = "";
                                    saveResultModel.QiConstraint = "";
                                    saveResultModel.Characteristic = "";
                                    break;
                                case "BloodStasisScore":
                                    saveResultModel.Mild = "";
                                    saveResultModel.Faint = "";
                                    saveResultModel.Yang = "";
                                    saveResultModel.Yin = "";
                                    saveResultModel.PhlegmDamp = "";
                                    saveResultModel.Muggy = "";
                                    saveResultModel.QiConstraint = "";
                                    saveResultModel.Characteristic = "";
                                    break;
                                case "QiConstraintScore":
                                    saveResultModel.Mild = "";
                                    saveResultModel.Faint = "";
                                    saveResultModel.Yang = "";
                                    saveResultModel.Yin = "";
                                    saveResultModel.PhlegmDamp = "";
                                    saveResultModel.Muggy = "";
                                    saveResultModel.BloodStasis = "";
                                    saveResultModel.Characteristic = "";
                                    break;
                                case "CharacteristicScore":
                                    saveResultModel.Mild = "";
                                    saveResultModel.Faint = "";
                                    saveResultModel.Yang = "";
                                    saveResultModel.Yin = "";
                                    saveResultModel.PhlegmDamp = "";
                                    saveResultModel.Muggy = "";
                                    saveResultModel.BloodStasis = "";
                                    saveResultModel.QiConstraint = "";
                                    break;
                            }

                            #endregion
                        }

                        #endregion

                        int medicineCnKey = 0;

                        // 更新体检 中医体质33项问题 tbl_recordsmedicinecn
                        if (recordsMedicineCnBLL.UpdateByMiniPad(saveResultModel, baseModel.ID.ToString())) saveSuccess = true;
                        else
                        {
                            saveResultModel.RecordID = recordModel.RecordID;

                            // 新增中医体质33项问题
                            medicineCnKey = recordsMedicineCnBLL.Add(saveResultModel);

                            if (medicineCnKey > 0)
                            {
                                // 更新体检中 中医体质辨识Key
                                recordsMedicineCnBLL.UpdateMediphysDist(baseModel.ID.ToString(), medicineCnKey);
                                saveSuccess = true;
                            }
                        }

                        // 更新体检 中医体质结果 tbl_recordsmedicineresult
                        if (recordsMedicineResultBLL.UpdateByMiniPad(saveResultModel, baseModel.ID.ToString()))
                        {
                            // 更新体检中 中医体质辨识结果Key及对应体质
                            recordsMedicineResultBLL.UpdateMediphysDist(saveResultModel, baseModel.ID.ToString());
                            saveSuccess = true;
                        }
                        else
                        {
                            saveResultModel.MedicineID = medicineCnKey;

                            // 新增中医体质结果
                            int addNum = recordsMedicineResultBLL.Add(saveResultModel);

                            if (addNum > 0)
                            {
                                // 更新体检中 中医体质辨识结果Key及对应体质
                                recordsMedicineResultBLL.UpdateMediphysDist(baseModel.ID.ToString(), addNum, saveResultModel);
                                saveSuccess = true;
                            }
                        }
                    }

                    #endregion

                    #region 安徽、陕西、贵州、山西中医指导建议

                    if (versionNo.Contains("安徽") || versionNo.Contains("陕西") || versionNo.Contains("贵州") || versionNo.Contains("山西"))
                    {
                        OldMedGuideModel GuideModeTemp = new OldMedGuideModel();

                        string strTzlx = "";
                        GuideModeTemp.Type = 0;
                        GuideModeTemp.OutKey = Convert.ToInt32(deciveResultModel.OutKey);
                        GuideModeTemp.Doctor = recordModel.Doctor;
                        GuideModeTemp.GuideDate = Convert.ToDateTime(deciveResultModel.RecordDate);
                        GuideModeTemp.IDCardNo = idCard;

                        #region 根据体质对应体质类型及见意

                        if (deciveResultModel.Mild == "1" || deciveResultModel.Mild == "2")
                        {
                            strTzlx = "平和质";
                            GuideModeTemp.IdentifyResult = "1";
                        }
                        else if (deciveResultModel.Faint == "1" || deciveResultModel.Faint == "2")
                        {
                            strTzlx = "气虚质";
                            GuideModeTemp.IdentifyResult = "2";
                        }
                        else if (deciveResultModel.Yang == "1" || deciveResultModel.Yang == "2")
                        {
                            strTzlx = "阳虚质";
                            GuideModeTemp.IdentifyResult = "3";
                        }
                        else if (deciveResultModel.Yin == "1" || deciveResultModel.Yin == "2")
                        {
                            strTzlx = "阴虚质";
                            GuideModeTemp.IdentifyResult = "4";
                        }
                        else if (deciveResultModel.PhlegmDamp == "1" || deciveResultModel.PhlegmDamp == "2")
                        {
                            strTzlx = "痰湿质";
                            GuideModeTemp.IdentifyResult = "5";
                        }
                        else if (deciveResultModel.Muggy == "1" || deciveResultModel.Muggy == "2")
                        {
                            strTzlx = "湿热质";
                            GuideModeTemp.IdentifyResult = "6";
                        }
                        else if (deciveResultModel.BloodStasis == "1" || deciveResultModel.BloodStasis == "2")
                        {
                            strTzlx = "血瘀质";
                            GuideModeTemp.IdentifyResult = "7";
                        }
                        else if (deciveResultModel.QiConstraint == "1" || deciveResultModel.QiConstraint == "2")
                        {
                            strTzlx = "气郁质";
                            GuideModeTemp.IdentifyResult = "8";
                        }
                        else if (deciveResultModel.Characteristic == "1" || deciveResultModel.Characteristic == "2")
                        {
                            strTzlx = "特兼质";
                            GuideModeTemp.IdentifyResult = "9";
                        }

                        if (!string.IsNullOrEmpty(strTzlx))
                        {
                            if (dtOldCN != null)
                            {
                                foreach (DataRow item in dtOldCN.Rows)
                                {
                                    if (item["name"].ToString() == strTzlx)
                                    {
                                        GuideModeTemp.EmotionAdjust = item["qzts"].ToString().Trim();
                                        GuideModeTemp.DietAdjust = item["ysty"].ToString().Trim();
                                        GuideModeTemp.LiveAdjust = item["qjts"].ToString().Trim();
                                        GuideModeTemp.Sport = item["ydbj"].ToString().Trim();
                                        GuideModeTemp.Collateral = item["jlbj"].ToString().Trim();
                                        GuideModeTemp.Attention = item["zysx"].ToString().Trim();
                                        GuideModeTemp.OtherGuide = item["qtzd"].ToString().Trim();
                                        GuideModeTemp.IdentifyDes = item["bsjgms"].ToString().Trim();
                                        break;
                                    }
                                }

                                // 随访修改中医体质意见
                                if (!oldMedGuideBLL.UpdateByUpload(GuideModeTemp))
                                {
                                    // 修改不到则新增
                                    oldMedGuideBLL.Add(GuideModeTemp);
                                }

                                // 体检修改中医体质意见
                                if (versionNo.Contains("安徽") || versionNo.Contains("贵州") || versionNo.Contains("山西"))
                                {
                                    GuideModeTemp.OutKey = baseModel.ID;
                                    GuideModeTemp.Type = 1;

                                    // 体检修改中医体质意见
                                    if (!oldMedGuideBLL.UpdateByUpload(GuideModeTemp))
                                    {
                                        // 修改不到则新增
                                        oldMedGuideBLL.Add(GuideModeTemp);
                                    }
                                }
                            }
                        }

                        #endregion
                    }

                    #endregion

                    #region 同步图片

                    if (versionNo.Contains("吉林") && (area.Equals("") || area.Equals("磐石")))
                    {
                        if (isWeb)
                        {
                            // 同步签字图片
                            string img = deciveResultModel.Sign.Replace("\"", "");

                            // 如果图片字串不为空白时
                            if (!string.IsNullOrEmpty(img))
                            {
                                WebHelper.SaveBase64StringToImage(img, strToSign, idCard + ".png", ImageFormat.Png);
                            }

                            // 同步指纹图片
                            img = deciveResultModel.Finger.Replace("\"", "");

                            // 如果图片字串不为空白时
                            if (!string.IsNullOrEmpty(img))
                            {
                                WebHelper.SaveBase64StringToImage(img, strToFinger, idCard + ".png", ImageFormat.Png);
                            }
                        }
                    }

                    #endregion

                    // 更新Pad成功时 
                    if (saveSuccess) count++;
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(deciveResultModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, deciveResultModel.IDCardNo, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveResultModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, saveResultModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 抑郁评估同步
        /// </summary>
        /// <param name="GloomyLs"></param>
        public void DataUploadByGloomy(List<OldGloomyModel> GloomyLs)
        {
            cud = new CombinUploadData();

            OldGloomyModel oldGloomyModel = new OldGloomyModel();
            RecordsGeneralConditionModel generalConditionModel = new RecordsGeneralConditionModel();

            // 同步抑郁评估
            if (GloomyLs != null)
            {
                for (int i = 0; i < GloomyLs.Count; i++)
                {
                    try
                    {
                        generalConditionModel = new RecordsGeneralConditionModel();
                        oldGloomyModel = GloomyLs[i];

                        RecordsCustomerBaseInfoModel baseModel = new RecordsCustomerBaseInfoBLL().GetModelByCheckDate(oldGloomyModel.IDCardNo, oldGloomyModel.RecordDate);

                        if (baseModel.CheckDate == null) continue;

                        generalConditionModel.IDCardNo = oldGloomyModel.IDCardNo;
                        oldGloomyModel.VisitDate = Convert.ToDateTime(oldGloomyModel.RecordDate);

                        decimal Score = new decimal();
                        string OldHealthStaus = oldGloomyModel.OldHealthStaus;
                        string OldEmotion = "1";

                        if (!string.IsNullOrEmpty(oldGloomyModel.TotalScore) && oldGloomyModel.TotalScore != "0")
                        {
                            //OldEmotion = "2";
                            Score = decimal.Parse(oldGloomyModel.TotalScore);
                        }

                        generalConditionModel.GloomyScore = Score;
                        generalConditionModel.OldEmotion = OldEmotion;
                        generalConditionModel.OldHealthStaus = OldHealthStaus;

                        bool saveSuccess = recordsGeneralConditionBLL.UpdateByGloomy(generalConditionModel, baseModel.ID.ToString());

                        // 抑郁评估分值存储
                        recordsGeneralConditionBLL.Delete(oldGloomyModel.IDCardNo, baseModel.ID.ToString());
                        recordsGeneralConditionBLL.Add(oldGloomyModel, baseModel.ID.ToString());

                        // 更新Pad成功时 
                        if (!saveSuccess)
                        {
                            RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(oldGloomyModel.IDCardNo);

                            this.cud.ConbinData(BaseModel, "抑郁评估:" + oldGloomyModel.IDCardNo, "体检数据更新失败");
                        }
                    }
                    catch (Exception ex)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(oldGloomyModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, "抑郁评估:" + oldGloomyModel.IDCardNo, ex.ToString());
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 智力评估同步
        /// </summary>
        /// <param name="IntelligenceLs"></param>
        public void DataUploadByIntelligence(List<OldIntelligenceModel> IntelligenceLs)
        {
            cud = new CombinUploadData();

            OldIntelligenceModel oldIntelligenceModel = new OldIntelligenceModel();
            RecordsGeneralConditionModel generalConditionModel = new RecordsGeneralConditionModel();

            // 同步智力评估
            if (IntelligenceLs != null)
            {
                for (int i = 0; i < IntelligenceLs.Count; i++)
                {
                    try
                    {
                        generalConditionModel = new RecordsGeneralConditionModel();
                        oldIntelligenceModel = IntelligenceLs[i];

                        RecordsCustomerBaseInfoModel baseModel = new RecordsCustomerBaseInfoBLL().GetModelByCheckDate(oldIntelligenceModel.IDCardNo, oldIntelligenceModel.RecordDate);

                        if (baseModel.CheckDate == null) continue;

                        generalConditionModel.IDCardNo = oldIntelligenceModel.IDCardNo;
                        oldIntelligenceModel.VisitDate = Convert.ToDateTime(oldIntelligenceModel.RecordDate);

                        decimal Score = new decimal();
                        string OldRecognise = "1";

                        if (!string.IsNullOrEmpty(oldIntelligenceModel.TotalScore) && oldIntelligenceModel.TotalScore != "0")
                        {
                            //OldRecognise = "2";
                            Score = decimal.Parse(oldIntelligenceModel.TotalScore);
                        }

                        generalConditionModel.InterScore = Score;
                        generalConditionModel.OldRecognise = OldRecognise;

                        bool saveSuccess = recordsGeneralConditionBLL.UpdateByIntelligence(generalConditionModel, baseModel.ID.ToString());

                        // 智力评估分值存储
                        recordsGeneralConditionBLL.DeleteByOldIntelligence(oldIntelligenceModel.IDCardNo, baseModel.ID.ToString());
                        recordsGeneralConditionBLL.Add(oldIntelligenceModel, baseModel.ID.ToString());

                        // 更新Pad成功时 
                        if (!saveSuccess)
                        {
                            RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(oldIntelligenceModel.IDCardNo);

                            this.cud.ConbinData(BaseModel, "智力评估:" + oldIntelligenceModel.IDCardNo, "体检数据更新失败");
                        }
                    }
                    catch (Exception ex)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(oldIntelligenceModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, "智力评估:" + oldIntelligenceModel.IDCardNo, ex.ToString());
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 健康状况同步
        /// </summary>
        /// <param name="HealthConditionLs"></param>
        public void DataUploadByHealth(List<RecordsHealthConditionModel> HealthConditionLs)
        {
            cud = new CombinUploadData();

            RecordsHealthConditionModel healthConditionModel = new RecordsHealthConditionModel();

            // 同步健康状况 
            if (HealthConditionLs != null)
            {
                for (int i = 0; i < HealthConditionLs.Count; i++)
                {
                    try
                    {
                        healthConditionModel = HealthConditionLs[i];
                        bool saveSuccess = false;

                        RecordsCustomerBaseInfoModel baseModel = new RecordsCustomerBaseInfoBLL().GetModelByCheckDate(healthConditionModel.IDCardNo, healthConditionModel.RecordDate);

                        if (baseModel.CheckDate == null) continue;

                        healthConditionModel.RecordDate = baseModel.CheckDate.Value.ToString("yyyy-MM-dd");

                        // 修改健康状况
                        saveSuccess = conditionBLL.UpdateByMiniPad(healthConditionModel, baseModel.ID.ToString());

                        // 修改不到则新增
                        if (!saveSuccess) saveSuccess = conditionBLL.Add(healthConditionModel, baseModel.ID.ToString());

                        // 更新Pad成功时 
                        if (!saveSuccess)
                        {
                            RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(healthConditionModel.IDCardNo);

                            this.cud.ConbinData(BaseModel, "健康状况:" + healthConditionModel.IDCardNo, "体检数据更新失败");
                        }
                    }
                    catch (Exception ex)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(healthConditionModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, "健康状况:" + healthConditionModel.IDCardNo, ex.ToString());
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 外科同步
        /// </summary>
        /// <param name="DeviceSqliteLs"></param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        public void DataUploadBySurgical(List<RecordsPhysicalExamModel> DeviceSqliteLs, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            RecordsPhysicalExamModel saveModel = new RecordsPhysicalExamModel();

            for (int i = 0; i < DeviceSqliteLs.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    saveModel = DeviceSqliteLs[i];
                    bool isCount = false;// 是否已计数

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(saveModel.IDCardNo, saveModel.RecordDate);

                    if (baseModel.CheckDate == null)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, saveModel.IDCardNo, "没有体检资料");
                        continue;
                    }

                    saveModel.OutKey = baseModel.ID;

                    // 更新查体数据
                    if (separationBLL.UpdateBySurgical(saveModel)) isCount = true;
                    else // 如果更新不到数据则新增
                    {
                        separationBLL.Insert(saveModel);

                        isCount = true;
                    }

                    // 更新脏器数据
                    if (separationBLL.UpdateVisceraBySurgical(saveModel)) isCount = true;
                    else // 如果更新不到数据则新增
                    {
                        separationBLL.InsertVisceraBySurgical(saveModel);

                        isCount = true;
                    }

                    // 更新健康数据
                    if (separationBLL.UpdateHealthBySurgical(saveModel)) isCount = true;
                    else // 如果更新不到数据则新增
                    {
                        separationBLL.InsertHealthBySurgical(saveModel);

                        isCount = true;
                    }

                    // 更新成功时 
                    if (isCount) count++;
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, saveModel.IDCardNo, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, saveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 内科同步
        /// </summary>
        /// <param name="DeviceSqliteLs"></param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        public void DataUploadByInternal(List<RecordsPhysicalExamModel> DeviceSqliteLs, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            RecordsPhysicalExamModel saveModel = new RecordsPhysicalExamModel();

            for (int i = 0; i < DeviceSqliteLs.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    saveModel = DeviceSqliteLs[i];
                    bool isCount = false;// 是否已计数

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(saveModel.IDCardNo, saveModel.RecordDate);

                    if (baseModel.CheckDate == null)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, saveModel.IDCardNo, "没有体检资料");
                        continue;
                    }

                    saveModel.OutKey = baseModel.ID;

                    // 更新查体数据
                    if (separationBLL.UpdateByInternalMedicine(saveModel)) isCount = true;
                    else // 如果更新不到数据则新增
                    {
                        separationBLL.Insert(saveModel);

                        isCount = true;
                    }

                    // 更新成功时 
                    if (isCount) count++;
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, saveModel.IDCardNo, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, saveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 五官同步
        /// </summary>
        /// <param name="DeviceSqliteLs"></param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        public void DataUploadByMouth(List<RecordsVisceraFunctionModel> DeviceSqliteLs, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            RecordsVisceraFunctionModel saveModel = new RecordsVisceraFunctionModel();

            for (int i = 0; i < DeviceSqliteLs.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    saveModel = DeviceSqliteLs[i];
                    bool isCount = false;// 是否已计数

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(saveModel.IDCardNo, saveModel.RecordDate);

                    if (baseModel.CheckDate == null)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, saveModel.IDCardNo, "没有体检资料");
                        continue;
                    }

                    saveModel.OutKey = baseModel.ID;

                    // 更新查体数据
                    if (separationBLL.UpdateByMouth(saveModel)) isCount = true;
                    else // 如果更新不到数据则新增
                    {
                        separationBLL.InsertByMouth(saveModel);

                        isCount = true;
                    }

                    // 更新成功时 
                    if (isCount) count++;
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, saveModel.IDCardNo, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, saveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// X光同步
        /// </summary>
        /// <param name="DeviceSqliteLs"></param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        public void DataUploadByChestX(List<RecordsAssistCheckModel> DeviceSqliteLs, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            RecordsAssistCheckModel saveModel = new RecordsAssistCheckModel();

            for (int i = 0; i < DeviceSqliteLs.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    saveModel = DeviceSqliteLs[i];
                    bool isCount = false;// 是否已计数

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(saveModel.IDCardNo, saveModel.RecordDate);

                    if (baseModel.CheckDate == null)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, saveModel.IDCardNo, "没有体检资料");
                        continue;
                    }

                    saveModel.OutKey = baseModel.ID;

                    // 更新查体数据
                    if (separationBLL.UpdateByChestX(saveModel)) isCount = true;
                    else // 如果更新不到数据则新增
                    {
                        separationBLL.InsertByChestX(saveModel);

                        isCount = true;
                    }

                    // 更新成功时 
                    if (isCount) count++;
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, saveModel.IDCardNo, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, saveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 视力同步
        /// </summary>
        /// <param name="where"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public void DataUploadByVsiual(DataTable dtInfo, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            Application.DoEvents();
            RecordsVisceraFunctionModel saveModel = new RecordsVisceraFunctionModel();

            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    DataRow dr = dtInfo.Rows[i];

                    saveModel = new RecordsVisceraFunctionModel();
                    saveModel.IDCardNo = dr["IDCard"].ToString();

                    // 十五位身份证判断
                    string idCard = dr["IDCard"].ToString();
                    string dtm = DateTime.Parse(dr["AddTime"].ToString()).ToString("yyyy-MM-dd");

                    if (idCard == "")
                    {
                        this.cud.ConbinData(null, "", "身份证号为空");
                        continue;
                    }

                    RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                    if (recordModel == null && idCard.Length == 18)
                    {
                        idCard = idCard.Trim().Remove(6, 2).Remove(15);
                    }

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(idCard, dtm);

                    if (baseModel.CheckDate == null)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(dr["IDCard"].ToString());

                        this.cud.ConbinData(BaseModel, dr["IDCard"].ToString(), "没有体检资料");
                        continue;
                    }

                    saveModel.IDCardNo = baseModel.IDCardNo;
                    saveModel.OutKey = baseModel.ID;

                    if (!string.IsNullOrEmpty(dr["LeftNakedEye"].ToString())) saveModel.LeftView = Convert.ToDecimal(dr["LeftNakedEye"].ToString().Split('|')[1]);
                    if (!string.IsNullOrEmpty(dr["LeftCorrect"].ToString())) saveModel.LeftEyecorrect = Convert.ToDecimal(dr["LeftCorrect"].ToString().Split('|')[1]);
                    if (!string.IsNullOrEmpty(dr["RightNakedEye"].ToString())) saveModel.RightView = Convert.ToDecimal(dr["RightNakedEye"].ToString().Split('|')[1]);
                    if (!string.IsNullOrEmpty(dr["RightCorrect"].ToString())) saveModel.RightEyecorrect = Convert.ToDecimal(dr["RightCorrect"].ToString().Split('|')[1]);

                    bool flag = recordsVisceraFunctionBLL.UpdateVsiual(saveModel);

                    if (flag)
                    {
                        count++;
                        Application.DoEvents();
                    }
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, saveModel.IDCardNo, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, saveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 随访同步
        /// </summary>
        /// <param name="dtInfo"></param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        public void DataUploadByFollow(DataTable dtInfo, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            Application.DoEvents();

            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    DataRow dr = dtInfo.Rows[i];

                    string idCard = dr["IDCardNo"].ToString();
                    int id = int.Parse(dr["ID"].ToString());

                    // 一般状况
                    RecordsGeneralConditionModel generalConditionModel = recordsGeneralConditionBLL.GetModelByOutKey(id);

                    if (generalConditionModel == null) generalConditionModel = new RecordsGeneralConditionModel();

                    ChronicDiadetesVisitModel diabetesModel = new ChronicDiadetesVisitModel();

                    diabetesModel.IDCardNo = idCard;
                    diabetesModel.Hypertension = generalConditionModel.RightHeight;
                    diabetesModel.Hypotension = generalConditionModel.RightPre;
                    diabetesModel.BMI = generalConditionModel.BMI;
                    diabetesModel.Weight = generalConditionModel.Weight;
                    diabetesModel.Height = generalConditionModel.Height;

                    if (diabetesModel.BMI != null)
                    {
                        if (diabetesModel.BMI >= 24) diabetesModel.TargetWeight = diabetesModel.Weight - 5;
                    }

                    // 生活方式
                    RecordsLifeStyleModel lifeModel = new RecordsLifeStyleBLL().GetModelByOutKey(id);

                    if (lifeModel == null) lifeModel = new RecordsLifeStyleModel();

                    if (lifeModel.SmokeCondition == "3")
                    {
                        diabetesModel.DailySmokeNum = lifeModel.SmokeDayNum;
                    }
                    else diabetesModel.DailySmokeNum = 0;

                    if (lifeModel.DrinkRate == "2" || lifeModel.DrinkRate == "3" || lifeModel.DrinkRate == "4")
                    {
                        diabetesModel.DailyDrinkNum = lifeModel.DayDrinkVolume;
                    }
                    else diabetesModel.DailyDrinkNum = 0;

                    diabetesModel.DailySmokeNumTarget = 0;
                    diabetesModel.DailyDrinkNumTarget = 0;
                    diabetesModel.SportTimePerWeekTarget = 7;
                    diabetesModel.SportPerMinuteTimeTarget = 60;

                    // 辅助检查
                    RecordsAssistCheckModel assistCheck = recordsAssistCheckBLL.GetModelByOutKey(id);

                    if (assistCheck == null) assistCheck = new RecordsAssistCheckModel();

                    diabetesModel.FPG = assistCheck.FPGL;
                    diabetesModel.HbAlc = assistCheck.HBALC;

                    if (diabetesModel.FPG >= Convert.ToDecimal(16.7))
                    {
                        diabetesModel.NextMeasures = "4";
                        diabetesModel.VisitType = "2";
                    }
                    else if (diabetesModel.FPG >= 7)
                    {
                        diabetesModel.NextMeasures = "3";
                        diabetesModel.VisitType = "2";
                    }
                    else
                    {
                        diabetesModel.NextMeasures = "1";
                        diabetesModel.VisitType = "1";
                    }

                    // 更新糖尿病随访
                    bool flag = new ChronicDiadetesVisitBLL().UpdateDate(diabetesModel);

                    ChronicHypertensionVisitModel hypertensionModel = new ChronicHypertensionVisitModel();

                    hypertensionModel.Hypertension = generalConditionModel.RightHeight;
                    hypertensionModel.Hypotension = generalConditionModel.RightPre;
                    hypertensionModel.BMI = generalConditionModel.BMI;
                    hypertensionModel.Weight = generalConditionModel.Weight;
                    hypertensionModel.Height = generalConditionModel.Height;

                    if (hypertensionModel.Hypertension >= 180 || hypertensionModel.Hypotension >= 110)
                    {
                        hypertensionModel.NextMeasures = "4";
                        hypertensionModel.FollowUpType = "2";
                    }
                    else if (hypertensionModel.Hypertension >= 140 || hypertensionModel.Hypotension >= 90)
                    {
                        hypertensionModel.NextMeasures = "3";
                        hypertensionModel.FollowUpType = "2";
                    }
                    else
                    {
                        hypertensionModel.NextMeasures = "1";
                        hypertensionModel.FollowUpType = "1";
                    }

                    if (hypertensionModel.BMI != null)
                    {
                        if (hypertensionModel.BMI >= 24)
                        {
                            hypertensionModel.WeightTarGet = hypertensionModel.Weight - 5;
                        }
                    }

                    if (assistCheck.FPGL != null)
                    {
                        hypertensionModel.AssistantExam = $"空腹血糖:{assistCheck.FPGL}mmol/L";
                    }

                    // 查体
                    RecordsPhysicalExamModel physicalModel = new RecordsPhysicalExamBLL().GetModelByOutKey(id);

                    if (physicalModel == null) physicalModel = new RecordsPhysicalExamModel();

                    hypertensionModel.HeartRate = physicalModel.HeartRate;

                    if (lifeModel.SmokeCondition == "3")
                    {
                        hypertensionModel.DailySmokeNum = lifeModel.SmokeDayNum;
                    }
                    else hypertensionModel.DailySmokeNum = 0;

                    if (lifeModel.DrinkRate == "2" || lifeModel.DrinkRate == "3" || lifeModel.DrinkRate == "4")
                    {
                        hypertensionModel.DailyDrinkNum = lifeModel.DayDrinkVolume;
                    }
                    else hypertensionModel.DailyDrinkNum = 0;

                    hypertensionModel.DailySmokeNumTarget = 0;
                    hypertensionModel.DailyDrinkNumTarget = 0;
                    hypertensionModel.SportTimeSperWeekTarget = 7;
                    hypertensionModel.SportPerMinutesTimeTarget = 60;
                    hypertensionModel.IDCardNo = idCard;

                    // 更新高血压随访
                    flag = new ChronicHypertensionVisitBLL().UpdateDate(hypertensionModel, versionNo);

                    if (flag)
                    {
                        count++;
                        Application.DoEvents();
                    }
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(idCard);

                        this.cud.ConbinData(BaseModel, idCard, "没有随访资料");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(dtInfo.Rows[i]["IDCardNo"].ToString());

                    this.cud.ConbinData(BaseModel, dtInfo.Rows[i]["IDCardNo"].ToString(), ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        #region 旧版B超

        /// <summary>
        /// B超同步
        /// </summary>
        /// <param name="dtInfo"></param>
        /// <param name="isWeb">是否为网站同步</param>
        /// <param name="functionName">网站同步的方法名称</param>
        /// <param name="index">第几个同步按钮</param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void DataUploadByTypeB(DataTable dtInfo, bool isWeb, string functionName, int index, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            Application.DoEvents();
            RecordsAssistCheckModel saveModel = new RecordsAssistCheckModel();
            RecordsHealthQuestionModel healthQuestionModel = new RecordsHealthQuestionModel();

            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    DataRow dr = dtInfo.Rows[i];

                    saveModel = new RecordsAssistCheckModel();
                    healthQuestionModel = new RecordsHealthQuestionModel();
                    saveModel.IDCardNo = dr["PTNIDNO"].ToString();

                    // 十五位身份证判断
                    string idCard = dr["PTNIDNO"].ToString();

                    if (idCard == "")
                    {
                        this.cud.ConbinData(null, "", "身份证号为空");
                        continue;
                    }

                    RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                    if (recordModel == null && idCard.Length == 18)
                    {
                        idCard = idCard.Trim().Remove(6, 2).Remove(15);
                    }

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(idCard, dr["DIAGTM"].ToString().Substring(0, 10));

                    if (baseModel.CheckDate == null)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(dr["PTNIDNO"].ToString());

                        this.cud.ConbinData(BaseModel, dr["PTNIDNO"].ToString(), "没有体检资料");
                        continue;
                    }

                    #region 图片处理

                    // 选择网站同步时
                    if (isWeb)
                    {
                        string img = dr["Picture"].ToString().Replace("\"", "");

                        // 如果图片字串不为空白时
                        if (!string.IsNullOrEmpty(img))
                        {
                            WebHelper.SaveBase64StringToImage(img, strToTypeBPath,
                                dr["DIAGTM"].ToString().Substring(0, 10) + "_" + dr["PTNIDNO"].ToString() + ".jpg", ImageFormat.Jpeg);

                            // 重庆报告不显示正常异常
                            if (versionNo.Contains("重庆"))
                            {
                                string fileFrom = String.Format("{0}\\{1}", strFromPathInfo, dr["RECID"]);
                                CopyInfo(fileFrom, strToTypeBPath, string.Format("{0}_{1}", dr["DIAGTM"].ToString().Substring(0, 10), dr["PTNIDNO"].ToString()));
                            }
                        }

                        if (area.Equals("徐州") || area.Equals("南京"))
                        {
                            if (File.Exists(strToTypeBPath + "\\" + dr["DIAGTM"].ToString().Substring(0, 10) + "_" + dr["PTNIDNO"].ToString() + ".jpg"))
                            {
                                if (!Directory.Exists(strToPathInfo2)) Directory.CreateDirectory(strToPathInfo2);

                                File.Copy(strToTypeBPath + "\\" + dr["DIAGTM"].ToString().Substring(0, 10) + "_" + dr["PTNIDNO"].ToString() + ".jpg",
                                    strToPathInfo2 + "\\" + dr["PTNIDNO"].ToString() + "_" + dr["PTNNM"].ToString().Replace("\\", "").Replace("/", "").
                                    Replace(":", "").Replace("*", "").Replace("?", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("|", "") + ".jpg", true);
                            }
                        }
                    }

                    #endregion

                    InPutDB(dr, index, isWeb);

                    saveModel.IDCardNo = baseModel.IDCardNo;
                    saveModel.OutKey = baseModel.ID;
                    healthQuestionModel.IDCardNo = baseModel.IDCardNo;
                    healthQuestionModel.IDCardNo = baseModel.IDCardNo;
                    healthQuestionModel.OutKey = baseModel.ID;

                    string strBcex = dr["DIAG"].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(" ", "");

                    if (versionNo.Contains("甘肃"))
                        strBcex = strBcex.Replace("胆囊未见明显异常。", "").Replace("胰脾未见明显异常。", "").Replace("胰腺及脾脏未见明显异常。", "");

                    if (!string.IsNullOrEmpty(strBcex)) strBcex = strBcex.Replace(";", " ").Replace(",", " ").Replace("。", " ");

                    if (dr["CLNCDIAG"].ToString() == "正常" || dr["CLNCDIAG"].ToString() == "阴性")
                    {
                        saveModel.BCHAO = "1";

                        switch (versionNo)
                        {
                            case "广西":
                            case "重庆":
                            case "河北":
                            case "内蒙古":
                            case "黑龙江":
                            case "哈尔滨":
                                saveModel.BCHAOEx = "肝胆胰脾未见明显异常";
                                break;
                            case "四川":
                                saveModel.BCHAOEx = "肝胆胰脾双肾未见明显异常";
                                break;
                            case "福建":
                            case "云南":
                            case "新疆":
                            case "江苏":
                                saveModel.BCHAOEx = strBcex;
                                break;
                            default:
                                saveModel.BCHAOEx = null;
                                break;
                        }
                    }
                    else if (dr["CLNCDIAG"].ToString() == "异常" || dr["CLNCDIAG"].ToString() == "阳性")
                    {
                        saveModel.BCHAO = "2";
                        saveModel.BCHAOEx = strBcex;

                        #region 武汉

                        if (area.Contains("武汉"))
                        {
                            string strBCHAO = "", strBCHAOEx = "";
                            string strDiag = dr["DIAG"].ToString().Replace('\n', ';').Replace('\r', ';').Replace(" ", ";");
                            string[] diag = strDiag.Split(new char[] { ';' });

                            foreach (string str in diag)
                            {
                                if (str.Contains("脂肪肝")) strBCHAO += "2,";
                                else if (str.Contains("肝囊肿")) strBCHAO += "3,";
                                else if (str.Contains("血吸虫肝")) strBCHAO += "4,";
                                else if (str.Contains("肝血管瘤")) strBCHAO += "5,";
                                else if (str.Contains("胆结石")) strBCHAO += "6,";
                                else if (str.Contains("胆囊炎")) strBCHAO += "7,";
                                else if (str.Contains("胆囊息肉")) strBCHAO += "8,";
                                else if (str.Contains("胆囊切除")) strBCHAO += "9,";
                                else if (str.Contains("肾囊肿")) strBCHAO += "10,";
                                else if (str.Contains("肾结石")) strBCHAO += "11,";
                                else if (str.Contains("肾积水")) strBCHAO += "12,";
                                else if (str.Contains("胰占位病变 ")) strBCHAO += "14,";
                                else strBCHAOEx += str + ",";
                            }

                            strBCHAOEx = strBCHAOEx.TrimEnd(',');

                            // 其他中有内容时，则选项增加其他勾选项
                            if (!string.IsNullOrEmpty(strBCHAOEx)) strBCHAO += "15,";

                            strBCHAO = strBCHAO.Trim().TrimEnd(',');
                            saveModel.BCHAO = strBCHAO;
                            saveModel.BCHAOEx = strBCHAOEx;
                        }

                        #endregion

                        #region 安徽、甘肃、江苏、江西、陕西、新疆地区的，更新健康问题

                        // 健康问题同步
                        if (versionNo.Contains("安徽") || versionNo.Contains("甘肃") || versionNo.Contains("江苏") || versionNo.Contains("江西") || versionNo.Contains("陕西") || versionNo.Contains("新疆") || versionNo.Contains("河北"))
                        {
                            healthQuestionModel = recordsHealthQuestionBLL.GetModelByOutKey(baseModel.ID);

                            if (healthQuestionModel != null)
                            {
                                if (area == "承德")
                                {
                                    if (healthQuestionModel.ElseOther.IndexOf(strBcex) == -1) healthQuestionModel.ElseOther += strBcex;
                                }
                                else healthQuestionModel.ElseOther = strBcex;

                                healthQuestionModel.ElseDis = "2";
                                healthQuestionModel.OutKey = baseModel.ID;

                                #region 甘肃 健康问题 其他系统疾病 选项处理

                                if (versionNo.Contains("甘肃"))
                                {
                                    if (!string.IsNullOrEmpty(healthQuestionModel.ElseDis))
                                    {
                                        if (area.Equals("武威"))
                                        {
                                            if (healthQuestionModel.ElseDis.Contains("1")) healthQuestionModel.ElseDis = "12";
                                            else if (!healthQuestionModel.ElseDis.Contains("12")) healthQuestionModel.ElseDis += ",12";
                                            else healthQuestionModel.ElseDis = "12";
                                        }
                                        else
                                        {
                                            if (healthQuestionModel.ElseDis.Contains("1")) healthQuestionModel.ElseDis = "6";
                                            else if (!healthQuestionModel.ElseDis.Contains("6")) healthQuestionModel.ElseDis += ",6";
                                            else healthQuestionModel.ElseDis = "6";
                                        }
                                    }
                                }

                                #endregion

                                recordsHealthQuestionBLL.Update(healthQuestionModel);
                            }
                        }

                        #endregion
                    }

                    // 辅助检查同步
                    bool flag = recordsAssistCheckBLL.UpdateBC(saveModel);

                    if (flag)
                    {
                        count++;
                        Application.DoEvents();
                    }
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, saveModel.IDCardNo, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, saveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        public void InPutDB(DataRow drInfo, int index, bool isWeb = true)
        {
            // 根据连接字串取得图片路径
            if (index == 1) GetFromPath("filefrom", "\\QC\\cworkccs\\");
            else if (index == 2) GetFromPath("filefrom2", "\\QC\\cworkccs\\");
            else if (index == 3) GetFromPath("filefrom3", "\\QC\\cworkccs\\");

            string dtm = drInfo["DIAGTM"].ToString().Substring(0, 10);

            // 先删后增
            typeBBLL.DelDB(drInfo);
            typeBBLL.InsDB(drInfo);

            if (!isWeb)
            {
                string fileFrom = String.Format("{0}\\{1}", strFromPathInfo, drInfo["RECID"]);

                CopyInfo(fileFrom, strToTypeBPath, string.Format("{0}_{1}", dtm, drInfo["PTNIDNO"]));
            }
        }

        #endregion

        #region 新版B超

        /// <summary>
        /// B超同步
        /// </summary>
        /// <param name="dtInfo"></param>
        /// <param name="isWeb">是否为网站同步</param>
        /// <param name="functionName">网站同步的图片抓取方法名称</param>
        /// <param name="index">第几个同步按钮</param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void DataUploadByTypeBNew(DataTable dtInfo, bool isWeb, string functionName, int index, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            Application.DoEvents();
            RecordsAssistCheckModel saveModel = new RecordsAssistCheckModel();
            RecordsHealthQuestionModel healthQuestionModel = new RecordsHealthQuestionModel();
            RecordsPhysicalExamModel physicalExamModel = new RecordsPhysicalExamModel();

            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    DataRow dr = dtInfo.Rows[i];

                    saveModel = new RecordsAssistCheckModel();
                    healthQuestionModel = new RecordsHealthQuestionModel();
                    physicalExamModel = new RecordsPhysicalExamModel();
                    saveModel.IDCardNo = dr["sfzh"].ToString();

                    // 十五位身份证判断
                    string idCard = dr["sfzh"].ToString();
                    string dtm = DateTime.Parse(dr["jcrq"].ToString()).ToString("yyyy-MM-dd");

                    if (idCard == "")
                    {
                        this.cud.ConbinData(null, "", "身份证号为空");
                        continue;
                    }

                    RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                    if (recordModel == null && idCard.Length == 18)
                    {
                        idCard = idCard.Trim().Remove(6, 2).Remove(15);
                    }

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(idCard, dtm);

                    if (baseModel.CheckDate == null)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(dr["sfzh"].ToString());

                        this.cud.ConbinData(BaseModel, dr["sfzh"].ToString(), "没有体检资料");
                        continue;
                    }

                    #region 图片处理

                    // 选择网站同步时
                    if (isWeb)
                    {
                        string img = dr["Picture"].ToString().Replace("\"", "");

                        // 如果图片字串不为空白时
                        if (!string.IsNullOrEmpty(img))
                        {
                            WebHelper.SaveBase64StringToImage(img, strToTypeBPath, dtm + "_" + dr["sfzh"].ToString() + ".jpg", ImageFormat.Jpeg);
                        }

                        if (area.Equals("徐州") || area.Equals("南京"))
                        {
                            if (File.Exists(strToTypeBPath + "\\" + dtm + "_" + dr["sfzh"].ToString() + ".jpg"))
                            {
                                if (!Directory.Exists(strToPathInfo2)) Directory.CreateDirectory(strToPathInfo2);

                                File.Copy(strToTypeBPath + "\\" + dtm + "_" + dr["sfzh"].ToString() + ".jpg",
                                    strToPathInfo2 + "\\" + dr["sfzh"].ToString() + "_" + dr["xm"].ToString().Replace("\\", "").Replace("/", "").
                                    Replace(":", "").Replace("*", "").Replace("?", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("|", "") + ".jpg", true
                                );
                            }
                        }
                    }

                    #endregion

                    InPutDBNew(dr, index, isWeb);

                    saveModel.IDCardNo = baseModel.IDCardNo;
                    saveModel.OutKey = baseModel.ID;
                    healthQuestionModel.IDCardNo = baseModel.IDCardNo;
                    healthQuestionModel.OutKey = baseModel.ID;
                    physicalExamModel.IDCardNo = baseModel.IDCardNo;
                    physicalExamModel.OutKey = baseModel.ID;

                    // 四川泸州B超结果分成四项
                    if (area.Equals("泸州市"))
                    {
                        #region 沪州市

                        string fbbc = dr["fbbc"].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(" ", ""); // 腹部B超
                        string bcqt = dr["bcqt"].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(" ", ""); // 其他B超
                        string fk = dr["fk"].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(" ", ""); // 妇科B超
                        string ss = dr["ss"].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(" ", ""); // 双肾
                        string illnessOther = ""; // 既往史

                        if (!string.IsNullOrEmpty(fbbc)) fbbc = fbbc.Replace(";", " ").Replace(",", " ").Replace("。", " ");
                        if (!string.IsNullOrEmpty(bcqt)) bcqt = bcqt.Replace(";", " ").Replace(",", " ").Replace("。", " ");
                        if (!string.IsNullOrEmpty(fk)) fk = fk.Replace(";", " ").Replace(",", " ").Replace("。", " ");
                        if (!string.IsNullOrEmpty(ss)) ss = ss.Replace(";", " ").Replace(",", " ").Replace("。", " ");

                        // 腹部B超
                        if (dr["fbbczd"].ToString() == "正常" || dr["fbbczd"].ToString() == "阴性")
                        {
                            saveModel.BCHAO = "1";
                            saveModel.BCHAOEx = fbbc;
                        }
                        else if (dr["fbbczd"].ToString() == "异常" || dr["fbbczd"].ToString() == "阳性")
                        {
                            saveModel.BCHAO = "2";
                            saveModel.BCHAOEx = fbbc;
                            healthQuestionModel.ElseDis = "2";
                            healthQuestionModel.ElseOther += fbbc + ";";
                            illnessOther = fbbc;
                        }

                        // 其他B超
                        if (dr["bcqtzd"].ToString() == "正常" || dr["bcqtzd"].ToString() == "阴性")
                        {
                            saveModel.BCHAOther = "1";
                            saveModel.BCHAOtherEx = bcqt;
                        }
                        else if (dr["bcqtzd"].ToString() == "异常" || dr["bcqtzd"].ToString() == "阳性")
                        {
                            saveModel.BCHAOther = "2";
                            saveModel.BCHAOtherEx = bcqt;
                            healthQuestionModel.ElseDis = "2";
                            healthQuestionModel.ElseOther += bcqt + ";";
                            illnessOther += "。" + bcqt;
                        }

                        // 双肾
                        if (dr["sszd"].ToString() == "正常" || dr["sszd"].ToString() == "阴性")
                        {
                            healthQuestionModel.RenalDis = "6";
                            healthQuestionModel.RenalOther = "双肾B超正常";
                        }
                        else if (dr["sszd"].ToString() == "异常" || dr["sszd"].ToString() == "阳性")
                        {
                            healthQuestionModel.RenalDis = "6";
                            healthQuestionModel.RenalOther = ss;
                            illnessOther += "。" + ss;
                        }

                        // 妇科B超
                        if (dr["fkzd"].ToString() == "正常" || dr["fkzd"].ToString() == "阴性")
                        {
                            physicalExamModel.Other = "妇科B超正常";
                        }
                        else if (dr["fkzd"].ToString() == "异常" || dr["fkzd"].ToString() == "阳性")
                        {
                            physicalExamModel.Other = fk;
                            healthQuestionModel.ElseDis = "2";
                            healthQuestionModel.ElseOther += fk + ";";
                            illnessOther += "。" + fk;
                        }

                        // 更新既往史
                        if (StringPlus.toString(illnessOther) != "") recordsAssistCheckBLL.UpdateIllHistory(saveModel.IDCardNo, illnessOther, baseModel.CheckDate.ToString());

                        if (StringPlus.toString(healthQuestionModel.RenalDis) != "") recordsAssistCheckBLL.UpdateBC(healthQuestionModel);
                        if (StringPlus.toString(healthQuestionModel.ElseDis) != "") recordsAssistCheckBLL.UpdateQT(healthQuestionModel);
                        if (StringPlus.toString(physicalExamModel.Other) != "") recordsAssistCheckBLL.UpdateBC(physicalExamModel);

                        #endregion
                    }
                    // 山东淄博桓台妇幼B超分4项
                    else if (community.Equals("桓台妇幼"))
                    {
                        #region 山东淄博桓台妇幼B超分4项

                        string fbbc = dr["fbbc"].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(" ", ""); // 腹部B超
                        string bcqt = dr["bcqt"].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(" ", ""); // 其他B超 颈动脉 甲状腺
                        string fk = dr["fk"].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(" ", ""); // 妇科B超
                        string ss = dr["ss"].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(" ", ""); // 双肾 男性B超

                        if (!string.IsNullOrEmpty(fbbc)) fbbc = fbbc.Replace(";", " ").Replace(",", " ").Replace("。", " ");
                        if (!string.IsNullOrEmpty(bcqt)) bcqt = bcqt.Replace(";", " ").Replace(",", " ").Replace("。", " ");
                        if (!string.IsNullOrEmpty(fk)) fk = fk.Replace(";", " ").Replace(",", " ").Replace("。", " ");
                        if (!string.IsNullOrEmpty(ss)) ss = ss.Replace(";", " ").Replace(",", " ").Replace("。", " ");

                        // 腹部B超
                        if (dr["fbbczd"].ToString() == "正常" || dr["fbbczd"].ToString() == "阴性")
                        {
                            saveModel.BCHAO = "1";
                            saveModel.BCHAOEx = null;
                        }
                        else if (dr["fbbczd"].ToString() == "异常" || dr["fbbczd"].ToString() == "阳性")
                        {
                            saveModel.BCHAO = "2";
                            saveModel.BCHAOEx = fbbc;
                            healthQuestionModel.ElseDis = "2";
                            healthQuestionModel.ElseOther += fbbc + ";";
                        }

                        // 其他B超 颈动脉 甲状腺
                        if (dr["bcqtzd"].ToString() == "正常" || dr["bcqtzd"].ToString() == "阴性")
                        {
                            saveModel.BCHAOther = "1";
                            saveModel.BCHAOtherEx = "颈动脉检查无异常;甲状腺检查无异常";
                        }
                        else if (dr["bcqtzd"].ToString() == "异常" || dr["bcqtzd"].ToString() == "阳性")
                        {
                            saveModel.BCHAOther = "2";
                            saveModel.BCHAOtherEx = bcqt;
                        }

                        if (dr["xb"].ToString() == "男")
                        {
                            // 双肾 男性B超
                            if (dr["sszd"].ToString() == "正常" || dr["sszd"].ToString() == "阴性")
                            {
                                saveModel.Other = "前列腺检查无异常";
                            }
                            else if (dr["sszd"].ToString() == "异常" || dr["sszd"].ToString() == "阳性")
                            {
                                saveModel.Other = ss;
                            }
                        }
                        else if (dr["xb"].ToString() == "女")
                        {
                            // 妇科B超
                            if (dr["fkzd"].ToString() == "正常" || dr["fkzd"].ToString() == "阴性")
                            {
                                saveModel.Other = "乳腺检查无异常";
                            }
                            else if (dr["fkzd"].ToString() == "异常" || dr["fkzd"].ToString() == "阳性")
                            {
                                saveModel.Other = fk;
                            }
                        }

                        #endregion
                    }
                    // 新疆并且不是兵团时 B超分4项
                    else if (versionNo.Contains("新疆") && !area.Equals("兵团"))
                    {
                        #region 新疆并且不是兵团时 B超分4项

                        string fbbc = dr["fbbc"].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(" ", ""); // 腹部B超
                        string bcqt = dr["bcqt"].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(" ", ""); // 其他B超 女性膀胱
                        string fk = dr["fk"].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(" ", ""); // 乳腺B超
                        string ss = dr["ss"].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(" ", ""); // 前列腺膀胱

                        if (!string.IsNullOrEmpty(fbbc)) fbbc = fbbc.Replace(";", " ").Replace(",", " ").Replace("。", " ");
                        if (!string.IsNullOrEmpty(bcqt)) bcqt = bcqt.Replace(";", " ").Replace(",", " ").Replace("。", " ");
                        if (!string.IsNullOrEmpty(fk)) fk = fk.Replace(";", " ").Replace(",", " ").Replace("。", " ");
                        if (!string.IsNullOrEmpty(ss)) ss = ss.Replace(";", " ").Replace(",", " ").Replace("。", " ");

                        // 腹部B超
                        if (dr["fbbczd"].ToString() == "正常" || dr["fbbczd"].ToString() == "阴性")
                        {
                            saveModel.BCHAO = "1";
                            saveModel.BCHAOEx = null;
                        }
                        else if (dr["fbbczd"].ToString() == "异常" || dr["fbbczd"].ToString() == "阳性")
                        {
                            saveModel.BCHAO = "2";
                            saveModel.BCHAOEx = fbbc;
                        }

                        // 其他B超
                        if (dr["bcqtzd"].ToString() == "正常" || dr["bcqtzd"].ToString() == "阴性")
                        {
                            saveModel.BCHAOther = "1";
                            saveModel.BCHAOtherEx = bcqt;
                        }
                        else if (dr["bcqtzd"].ToString() == "异常" || dr["bcqtzd"].ToString() == "阳性")
                        {
                            saveModel.BCHAOther = "2";
                            saveModel.BCHAOtherEx = bcqt;
                        }

                        // 前列腺膀胱
                        if (dr["sszd"].ToString() == "正常" || dr["sszd"].ToString() == "阴性")
                        {
                            saveModel.ProstBladBChao = "1";
                            saveModel.ProstBladBChaoEx = ss;
                        }
                        else if (dr["sszd"].ToString() == "异常" || dr["sszd"].ToString() == "阳性")
                        {
                            saveModel.ProstBladBChao = "2";
                            saveModel.ProstBladBChaoEx = ss;
                        }

                        // 乳腺B超
                        if (dr["fkzd"].ToString() == "正常" || dr["fkzd"].ToString() == "阴性")
                        {
                            saveModel.BreastBChao = "1";
                            saveModel.BreastBChaoEx = fk;
                        }
                        else if (dr["fkzd"].ToString() == "异常" || dr["fkzd"].ToString() == "阳性")
                        {
                            saveModel.BreastBChao = "2";
                            saveModel.BreastBChaoEx = fk;
                        }

                        #endregion
                    }
                    else
                    {
                        #region 通用B超

                        string strBcEx = dr["jcyj"].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(" ", "");

                        if (versionNo.Contains("甘肃"))
                            strBcEx = strBcEx.Replace("胆囊未见明显异常。", "").Replace("胰脾未见明显异常。", "").Replace("胰腺及脾脏未见明显异常。", "");

                        if (!string.IsNullOrEmpty(strBcEx)) strBcEx = strBcEx.Replace(";", " ").Replace(",", " ").Replace("。", " ");

                        if (dr["lczd"].ToString() == "正常" || dr["lczd"].ToString() == "阴性")
                        {
                            saveModel.BCHAO = "1";

                            switch (versionNo)
                            {
                                case "广西":
                                case "重庆":
                                case "河北":
                                case "内蒙古":
                                case "黑龙江":
                                case "哈尔滨":
                                    saveModel.BCHAOEx = "肝胆胰脾未见明显异常";
                                    break;
                                case "四川":
                                    saveModel.BCHAOEx = "肝胆胰脾双肾未见明显异常";
                                    break;
                                case "福建":
                                case "云南":
                                case "新疆":
                                case "江苏":
                                case "安徽":
                                    saveModel.BCHAOEx = strBcEx;
                                    break;
                                default:
                                    saveModel.BCHAOEx = null;
                                    break;
                            }
                        }
                        else if (dr["lczd"].ToString() == "异常" || dr["lczd"].ToString() == "阳性")
                        {
                            saveModel.BCHAO = "2";
                            saveModel.BCHAOEx = strBcEx;

                            #region 安徽、甘肃、江苏、江西、陕西、河北地区的，更新健康问题

                            // 健康问题同步
                            if (versionNo.Contains("安徽") || versionNo.Contains("甘肃") || versionNo.Contains("江苏") || versionNo.Contains("江西") || versionNo.Contains("陕西") || versionNo.Contains("河北"))
                            {
                                healthQuestionModel = recordsHealthQuestionBLL.GetModelByOutKey(baseModel.ID);

                                if (healthQuestionModel != null)
                                {
                                    if (area == "承德")
                                    {
                                        if (healthQuestionModel.ElseOther.IndexOf(strBcEx) == -1) healthQuestionModel.ElseOther += strBcEx;
                                    }
                                    else healthQuestionModel.ElseOther = strBcEx;

                                    healthQuestionModel.ElseDis = "2";
                                    healthQuestionModel.OutKey = baseModel.ID;

                                    #region 甘肃 健康问题 其他系统疾病 选项处理

                                    if (versionNo.Contains("甘肃"))
                                    {
                                        if (!string.IsNullOrEmpty(healthQuestionModel.ElseDis))
                                        {
                                            if (area.Equals("武威"))
                                            {
                                                if (healthQuestionModel.ElseDis.Contains("1")) healthQuestionModel.ElseDis = "12";
                                                else if (!healthQuestionModel.ElseDis.Contains("12")) healthQuestionModel.ElseDis += ",12";
                                                else healthQuestionModel.ElseDis = "12";
                                            }
                                            else
                                            {
                                                if (healthQuestionModel.ElseDis.Contains("1")) healthQuestionModel.ElseDis = "6";
                                                else if (!healthQuestionModel.ElseDis.Contains("6")) healthQuestionModel.ElseDis += ",6";
                                                else healthQuestionModel.ElseDis = "6";
                                            }
                                        }
                                    }

                                    #endregion

                                    recordsHealthQuestionBLL.Update(healthQuestionModel);
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }

                    // 辅助检查同步
                    bool flag = recordsAssistCheckBLL.UpdateBC(saveModel);

                    if (flag)
                    {
                        count++;
                        Application.DoEvents();
                    }
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, saveModel.IDCardNo, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, saveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        public void InPutDBNew(DataRow drInfo, int index, bool isWeb = true)
        {
            // 根据连接字串取得图片路径
            if (index == 1) GetFromPath("filefrom", @"\\qc\超声影像系统\Data\Picture\");
            else if (index == 2) GetFromPath("filefrom2", @"\\qc\超声影像系统\Data\Picture\");
            else if (index == 3) GetFromPath("filefrom3", @"\\qc\超声影像系统\Data\Picture\");

            string dtm = DateTime.Parse(drInfo["jcrq"].ToString()).ToString("yyyy-MM-dd");

            // 先删后增
            typeBBLL.DeletePtn(drInfo);
            typeBBLL.InsertPtn(drInfo);

            if (!isWeb)
            {
                string fileFrom = string.Format("{0}\\{1}", strFromPathInfo, drInfo["jcbh"]);

                CopyInfo(fileFrom, strToTypeBPath, string.Format("{0}_{1}", dtm, drInfo["sfzh"]), true);
            }
        }

        #endregion

        #region 重庆B超

        /// <summary>
        /// B超同步
        /// </summary>
        /// <param name="dtInfo"></param>
        /// <param name="isWeb">是否为网站同步</param>
        /// <param name="functionName">网站同步的图片抓取方法名称</param>
        /// <param name="index">第几个同步按钮</param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void DataUpload_Access(DataTable dtInfo, bool isWeb, string functionName, int index, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            Application.DoEvents();
            RecordsAssistCheckModel saveModel = new RecordsAssistCheckModel();

            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    DataRow dr = dtInfo.Rows[i];

                    saveModel = new RecordsAssistCheckModel();
                    saveModel.IDCardNo = dr["IDCardNo"].ToString();

                    // 十五位身份证判断
                    string idCard = dr["IDCardNo"].ToString();
                    string dtm = DateTime.Parse(dr["TestTime"].ToString()).ToString("yyyy-MM-dd");

                    if (idCard == "")
                    {
                        this.cud.ConbinData(null, "", "身份证号为空");
                        continue;
                    }

                    RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                    if (recordModel == null && idCard.Length == 18)
                    {
                        idCard = idCard.Trim().Remove(6, 2).Remove(15);
                    }

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(idCard, dtm);

                    if (baseModel.CheckDate == null)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(dr["IDCardNo"].ToString());

                        this.cud.ConbinData(BaseModel, dr["IDCardNo"].ToString(), "没有体检资料");
                        continue;
                    }

                    #region 图片处理

                    // 选择网站同步时
                    if (isWeb)
                    {
                        string img = GetBchaoJpgPostHttp(dr["PicPath"].ToString(), functionName).Replace("\"", "");

                        // 如果图片字串不为空白时
                        if (!string.IsNullOrEmpty(img))
                        {
                            WebHelper.SaveBase64StringToImage(img, strToTypeBPath, dr["PicPath"].ToString() + ".jpg", ImageFormat.Jpeg);
                        }
                    }

                    #endregion

                    InPutDB_Access(dr, index, isWeb);

                    saveModel.IDCardNo = baseModel.IDCardNo;
                    saveModel.OutKey = baseModel.ID;

                    string strModDia = dr["ModDia"].ToString();

                    if (!string.IsNullOrEmpty(strModDia))
                    {
                        if (strModDia.Contains("未见明显异常"))
                        {
                            saveModel.BCHAO = "1";
                            saveModel.BCHAOEx = "";
                        }
                        else
                        {
                            saveModel.BCHAO = "2";
                            saveModel.BCHAOEx = strModDia;
                        }
                    }

                    // 辅助检查同步
                    bool flag = recordsAssistCheckBLL.UpdateBC(saveModel);

                    if (flag)
                    {
                        count++;
                        Application.DoEvents();
                    }
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, saveModel.IDCardNo, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, saveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 重庆从Access数据中获取数据
        /// </summary>
        /// <param name="drInfo"></param>
        /// <param name="filefrom"></param>
        /// <param name="isWeb"></param>
        public void InPutDB_Access(DataRow drInfo, int index, bool isWeb = true)
        {
            // 根据连接字串取得图片路径
            if (index == 2) GetFromPath("filefrom2", @"\\qc\QCSoft\Picture\");

            // 先删后增
            typeBBLL.DeleteByChongQing(drInfo);
            typeBBLL.InsDBByChongQing(drInfo);

            if (!isWeb)
            {
                string fileFrom = String.Format("{0}\\{1}.jpg", strFromPathInfo, drInfo["PicPath"]);

                if (File.Exists(fileFrom))
                {
                    File.Copy(fileFrom, strToTypeBPath + "\\" + drInfo["PicPath"] + ".jpg", true);
                }
            }
        }

        #endregion

        #region 安徽X光同步

        /// <summary>
        /// 安徽X光同步
        /// </summary>
        /// <param name="dtInfo"></param>
        /// <param name="index">第几个同步按钮</param>
        /// <param name="count"></param>
        /// <param name="progressBar"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void DataUploadChestXByAccess(DataTable dtInfo, ref int count, ProgressBar progressBar, object obj)
        {
            cud = new CombinUploadData();
            Application.DoEvents();
            RecordsAssistCheckModel saveModel = new RecordsAssistCheckModel();


            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                if (progressBar != null)
                {
                    // 执行PerformStep()函数
                    progressBar.PerformStep();
                }
                else if (obj != null)
                {
                    SetProgress(obj, i);
                }

                try
                {
                    DataRow dr = dtInfo.Rows[i];
                    bool isCount = false;// 是否已计数

                    saveModel = new RecordsAssistCheckModel();
                    saveModel.IDCardNo = dr["IDCardNo"].ToString();

                    // 十五位身份证判断
                    string idCard = dr["IDCardNo"].ToString();
                    string testTime = dr["TestTime"].ToString().Substring(0, 8);
                    testTime = testTime.Insert(6, "-").Insert(4, "-");

                    if (idCard == "")
                    {
                        this.cud.ConbinData(null, "", "身份证号为空");
                        continue;
                    }

                    RecordsBaseInfoModel recordModel = baseInfoBLL.GetModel(idCard);

                    if (recordModel == null && idCard.Length == 18)
                    {
                        idCard = idCard.Trim().Remove(6, 2).Remove(15);
                    }

                    RecordsCustomerBaseInfoModel baseModel = recordsCustomerBaseInfoBLL.GetModelByCheckDate(idCard, testTime);

                    if (baseModel.CheckDate == null)
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(dr["IDCardNo"].ToString());

                        this.cud.ConbinData(BaseModel, dr["IDCardNo"].ToString(), "没有体检资料");
                        continue;
                    }

                    saveModel.CHESTX = dr["ChestX"].ToString();
                    saveModel.CHESTXEx = dr["ChestXEx"].ToString();
                    saveModel.OutKey = baseModel.ID;
                    #region DR数据更新
                    if (DR.Equals("Y"))
                    {
                        DataModel model = new DataModel();

                        model.IDCardNo = StringPlus.toString(dr["IDCardNo"]);
                        model.PID = StringPlus.toString(dr["PID"]);
                        model.ReportName = StringPlus.toString(dr["ReportName"]);
                        model.PersonName = StringPlus.toString(dr["PersonName"]);
                        model.Sex = StringPlus.toString(dr["Sex"]);
                        model.Age = StringPlus.toString(dr["Age"]);
                        model.BodyPartExamined = StringPlus.toString(dr["BodyPartExamined"]);
                        //model.Procedure = StringPlus.toString(dr["Procedure"]);
                        model.ChestX = StringPlus.toString(dr["ChestX"]);
                        model.ChestXEx = StringPlus.toString(dr["ChestXEx"]);
                        model.Content = StringPlus.toString(dr["Content"]);
                        string DRTestTime = StringPlus.toString(dr["TestTime"]);
                        string datefile = "", ReportName = "";
                        //日期格式转换 && 获取日期子文件名称
                        if (!string.IsNullOrEmpty(DRTestTime))
                        {
                            datefile = StringPlus.toString(dr["TestTime"]).Substring(0, 6);
                            DRTestTime = DRTestTime.Insert(6, "-").Insert(4, "-");
                            model.TestTime = Convert.ToDateTime(DRTestTime);                           
                        }

                        // 更新DR表
                        if (separationBLL.DRUpdateByChestX(model))
                        {
                            
                        }
                        else // 如果更新不到数据则新增
                        {
                            separationBLL.DRInsertByChestX(model);
                        }
                        //子文件名称获取
                        if (model.ReportName != null)
                        {
                            ReportName = model.ReportName;
                        }
                        //复制X光图片 并转为jpg格式                       
                        if (Directory.Exists(strFromChestX + "\\" + datefile + "\\" + ReportName + "\\REPORT"))
                        {
                            foreach (string itemFilePath in Directory.GetFiles(strFromChestX + "\\" + datefile + "\\" + ReportName + "\\REPORT"))
                            {
                                if (!Directory.Exists(strToChestX)) Directory.CreateDirectory(strToChestX);
                                File.Copy(itemFilePath,
                                strToChestX + "\\" + model.IDCardNo + "_" + ReportName.Replace("\\", "").Replace("/", "").
                                Replace(":", "").Replace("*", "").Replace("?", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("|", "") + ".jpg", true);
                            }                          
                        }
                    }
                    #endregion

                    // 更新查体数据
                    if (separationBLL.UpdateByChestX(saveModel)) isCount = true;
                    else // 如果更新不到数据则新增
                    {
                        separationBLL.InsertByChestX(saveModel);

                        isCount = true;
                    }

                    // 更新成功时 
                    if (isCount) count++;
                    else
                    {
                        RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                        this.cud.ConbinData(BaseModel, saveModel.IDCardNo, "体检数据更新失败");
                    }
                }
                catch (Exception ex)
                {
                    RecordsBaseInfoModel BaseModel = baseInfoBLL.GetModel(saveModel.IDCardNo);

                    this.cud.ConbinData(BaseModel, saveModel.IDCardNo, ex.ToString());
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        #endregion

        #region 网站方式同步

        public string GetPostHttp(int startIndex, int endIndex, string deviceType, string functionName, int index = 0)
        {
            string url = "", postDataStr = "";

            if (postUrl.Length > 0)
            {
                url = (postUrl.Length > (index + 1) ? postUrl[index] : postUrl[0]) + "/Login/" + functionName;

                if (deviceType != "") postDataStr = "startDate=" + startDate + "&endDate=" + endDate + "&deviceType=" + deviceType + "" + "&startIndex=" + startIndex + "&endIndex=" + endIndex;
                else postDataStr = "startDate=" + startDate + "&endDate=" + endDate + "&startIndex=" + startIndex + "&endIndex=" + endIndex;

                return WebHelper.PostHttp(url, postDataStr);
            }

            return "";
        }

        /// <summary>
        /// 取得资料笔数
        /// </summary>
        /// <returns></returns>
        public int GetPostHttpCount(string deviceType, string functionName, int index = 0)
        {
            string url = "", postDataStr = "", result = "";

            if (postUrl.Length > 0)
            {
                url = (postUrl.Length > (index + 1) ? postUrl[index] : postUrl[0]) + "/Login/" + functionName;

                if (deviceType != "") postDataStr = "startDate=" + startDate + "&endDate=" + endDate + "&deviceType=" + deviceType + "";
                else postDataStr = "startDate=" + startDate + "&endDate=" + endDate;

                result = WebHelper.PostHttp(url, postDataStr);
            }

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// 取得报告图片
        /// </summary>
        /// <param name="no"></param>
        /// <param name="functionName"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetPngPostHttp(string no, string functionName, int index = 0)
        {
            string url = "", postDataStr = "", result = "";

            if (postUrl.Length > index)
            {
                url = (postUrl.Length > (index + 1) ? postUrl[index] : postUrl[0]) + "/Login/" + functionName;
                postDataStr = "examno=" + no;

                result = WebHelper.PostHttp(url, postDataStr);
            }

            return result;
        }

        /// <summary>
        /// 取得B超报告图片
        /// </summary>
        /// <param name="recId"></param>
        /// <param name="functionName"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetJpgPostHttp(string recId, string functionName, int index = 0)
        {
            string url = "", postDataStr = "", result = "";

            if (postUrl.Length > index)
            {
                url = (postUrl.Length > (index + 1) ? postUrl[index] : postUrl[0]) + "/Login/" + functionName;
                postDataStr = "recId=" + recId;

                result = WebHelper.PostHttp(url, postDataStr);
            }

            return result;
        }

        /// <summary>
        /// 取得签字、指纹图片
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="idCardNo">身份证号</param>
        /// <returns></returns>
        private string GetPngPostHttp(string path, string idCardNo)
        {
            string url = "", postDataStr = "", result = "";

            url = postUrl + "/Login/GetPng";
            postDataStr = "path=" + path + "&idCardNo=" + idCardNo;

            result = WebHelper.PostHttp(url, postDataStr);

            return result;
        }

        /// <summary>
        /// 取得重庆B超报告图片
        /// </summary>
        /// <param name="PicPath"></param>
        /// <param name="functionName"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetBchaoJpgPostHttp(string PicPath, string functionName, int index = 0)
        {
            string url = "", result = "";

            if (postUrl.Length > index)
            {
                url = (postUrl.Length > (index + 1) ? postUrl[index] : postUrl[0]) + "/Login/" + functionName;
                PicPath = "PicPath=" + PicPath;

                result = WebHelper.PostHttp(url, PicPath);
            }

            return result;
        }

        #endregion
    }

    class Engine : DispatcherObject
    {

    }
}