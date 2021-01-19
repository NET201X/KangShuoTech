using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using KangShuoTech.CommomDataAccessProjects.CommonBLL;
using CommomUtilities.Common;
using System.Threading;
using System.IO.Ports;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace DataUpload
{
    public partial class DataUploadUI : Form
    {
        List<DeviceInfoModel> deviceSqliteLs = new List<DeviceInfoModel>(); // 血压、身高体重、体温体重、尿仪、血糖
        List<EcgDataModel> ecgDataModel = new List<EcgDataModel>(); // 心电
        List<DataModel> dataModel = new List<DataModel>(); // 生化血球实体类
        List<BTypeModel> bTypeModel = new List<BTypeModel>(); // B超
        List<NewBTypeModel> newBTypeModel = new List<NewBTypeModel>();  // 新版B超
        List<DataUploadModel> dataUploadModel = new List<DataUploadModel>();  // 体检问询
        List<RecordsMedicationModel> medicationSqliteLs = new List<RecordsMedicationModel>(); // 用药
        List<History> historyModel = new List<History>();   // 住院史、免疫史
        List<OldSelfSqliteModel> selfLs = new List<OldSelfSqliteModel>(); // 自理能力
        List<OldGloomyModel> gloomyLs = new List<OldGloomyModel>();// 抑郁评估
        List<OldIntelligenceModel> intelligenceLs = new List<OldIntelligenceModel>();//智力评估 
        List<MedicineModel> medicineModel = new List<MedicineModel>(); // 中医
        List<RecordsHealthConditionModel> conditionList = new List<RecordsHealthConditionModel>(); // 健康状况
        List<RecordsPhysicalExamModel> surgicalModel = new List<RecordsPhysicalExamModel>(); // 外科、内科
        List<RecordsAssistCheckModel> chestXModel = new List<RecordsAssistCheckModel>(); // X光
        List<RecordsVisceraFunctionModel> mouthModel = new List<RecordsVisceraFunctionModel>(); // 五官
        List<VisionInfoModel> visionInfoList = new List<VisionInfoModel>(); // 视力
        DeviceInfoBLL deviceInfoBLL = new DeviceInfoBLL();
        RecordsAssistCheckBLL recordsAssistCheckBll = new RecordsAssistCheckBLL();
        DataUploadBusiness dataUploadBusiness = new DataUploadBusiness();
        DataTable dtInfo = new DataTable();
        DataTable dtUpload = new DataTable();
        string deviceType = "", type = "", protocol = "", pIp = "", pPort = "", ifShengHua = "";
        private SerialPort comm = new SerialPort();
        Socket socketSend;
        bool endFlag = true;
        int uploadCount = 0;
        Configuration config;

        #region Setting变量

        // 日期区间前推天数
        string addDay = ConfigHelper.GetSetNode("addDay");

        // 版本号
        string versionNo = ConfigHelper.GetSetNode("versionNo");

        // 地区名称
        string area = ConfigHelper.GetSetNode("area");

        // 医院名
        string community = ConfigHelper.GetSetNode("community");

        // 生化按钮数
        string BioCount = ConfigHelper.GetSetNode("BioCount");

        // 血球按钮数
        string BloodCount = ConfigHelper.GetSetNode("BloodCount");

        // 是否新版B超
        string isNewTypeB = ConfigHelper.GetSetNode("IsNewTypeB");

        // B超按钮数
        string TypeBCount = ConfigHelper.GetSetNode("TypeBCount");

        // 心电按钮数
        string EcgCount = ConfigHelper.GetSetNode("EcgCount");

        // 尿机按钮数
        string UrineDeviceCount = ConfigHelper.GetSetNode("UrineDeviceCount");

        // 中医体质
        string MediphyCount = ConfigHelper.GetSetNode("MediphyCount");

        //DR同步
        string DR = ConfigHelper.GetSetNode("DR");

        #endregion

        public string WindowTitle { get; set; }

        public string DataType { get; set; }

        public DataUploadUI()
        {
            InitializeComponent();

            dataUploadBusiness.GetSetting("");
        }

        private void DataUploadUI_Load(object sender, EventArgs e)
        {
            #region 加载预设值

            addDay = addDay == "" ? "0" : addDay;

            if (File.Exists(Application.StartupPath + @"\DataUploadManger.xml"))
            {
                DataSet dsResult = new DataSet();

                dsResult.ReadXml(Application.StartupPath + @"\DataUploadManger.xml");

                dtUpload = dsResult.Tables[0];
                DataView dv = dtUpload.DefaultView;
                dv.RowFilter = "Category='" + DataType + "'";

                dtUpload = dv.ToTable();

                if (dtUpload.Rows.Count > 0)
                {
                    dataUploadBusiness.postUrl = dtUpload.Rows[0]["Website"].ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    string type = dtUpload.Rows[0]["Type"].ToString();

                    // 选项预设
                    if (type == "共享")
                    {
                        this.rbShared.Checked = true;
                        this.rbWebsite.Checked = false;
                    }
                    else
                    {
                        this.rbShared.Checked = false;
                        this.rbWebsite.Checked = true;
                    }
                }
            }

            DateTime dtNow = DateTime.Now;

            this.dtpStart.Value = dtNow.AddDays(-Convert.ToInt32(addDay));
            this.dtpEnd.Value = dtNow;

            #endregion

            this.Text = WindowTitle;

            pictureBoxDataUpload.Top = progressBar1.Top;
            progressBar1.Top = panTotal.Top;
            panTotal.Top = panDeviceType.Top;
            this.Height = 282;

            config = dataUploadBusiness.GetConfig();

            // 尿仪
            if (DataType.Equals("UrineDevice"))
            {
                chkNewUrine.Visible = true;
                pictureBoxDataUpload2.Top -= 30;
                pictureBoxDataUpload3.Top -= 30;
                deviceType = "33";

                #region 根据按钮设置显示按钮

                if (UrineDeviceCount.Equals("2"))
                {
                    pictureBoxDataUpload2.Visible = true;
                    this.Height = 372;

                    //else if (UrineDeviceCount.Equals("3"))
                    //{
                    //    pictureBoxDataUpload3.Visible = true;
                    //    this.Height = 468;
                    //}
                }
                else
                {
                    if (versionNo.Contains("甘肃"))
                    {
                        pictureBoxDataUpload2.Visible = true;
                        this.Height = 372;
                    }
                }

                #endregion
            }
            // 血糖
            else if (DataType.Equals("BloodSugar")) deviceType = "24";
            // 体温体重
            else if (DataType.Equals("ThermometerWeight")) deviceType = "22";
            // 身高体重
            else if (DataType.Equals("HeightWeight")) deviceType = "39";
            // 血压
            else if (DataType.Equals("BloodPressure")) deviceType = "20";
            // 心电
            else if (DataType.Equals("ECGUpload"))
            {
                panTotal.Top = 127;
                progressBar1.Top = 158;
                pictureBoxDataUpload.Top = 187;
                panDeviceType.Visible = true;
                rbOne.Text = "一代心电";
                rbTwo.Text = "二代心电";
                rbTwo.Checked = true;
                this.Height = 308;

                #region 根据按钮设置显示按钮

                if (EcgCount.Equals("2"))
                {
                    pictureBoxDataUpload2.Visible = true;
                    this.Height = 405;
                }
                else if (EcgCount.Equals("3"))
                {
                    pictureBoxDataUpload2.Visible = true;
                    pictureBoxDataUpload3.Visible = true;
                    this.Height = 497;
                }
                else
                {
                    if (versionNo.Contains("新疆"))
                    {
                        pictureBoxDataUpload2.Visible = true;
                        pictureBoxDataUpload3.Visible = true;
                        this.Height = 497;
                    }
                }

                #endregion
            }
            // B超
            else if (DataType.Equals("TypeBForm"))
            {
                panTotal.Top = 127;
                progressBar1.Top = 158;
                pictureBoxDataUpload.Top = 187;
                panDeviceType.Visible = true;
                rbOne.Text = "一代B超";
                rbTwo.Text = "二代B超";
                this.Height = 308;

                rbTwo.Checked = isNewTypeB.Equals("Y");

                #region 根据按钮设置显示按钮

                if (TypeBCount.Equals("2"))
                {
                    pictureBoxDataUpload2.Visible = true;
                    this.Height = 405;
                }
                else if (TypeBCount.Equals("3"))
                {
                    pictureBoxDataUpload2.Visible = true;
                    pictureBoxDataUpload3.Visible = true;
                    this.Height = 497;
                }
                else
                {
                    if (versionNo.Contains("新疆"))
                    {
                        pictureBoxDataUpload2.Visible = true;
                        pictureBoxDataUpload3.Visible = true;
                        this.Height = 497;
                    }
                    else if (versionNo.Contains("重庆"))
                    {
                        pictureBoxDataUpload2.Visible = true;
                        this.Height = 405;
                    }
                }

                #endregion
            }
            // 中医
            else if (DataType.Equals("OldHealth"))
            {
                if (MediphyCount.Equals("2"))
                {
                    pictureBoxDataUpload2.Visible = true;
                    pictureBoxDataUpload2.Top -= 30;
                    this.Height = 372;
                }
            }
            // 生化
            else if (DataType.Equals("Biochemical"))
            {
                rbSocket.Visible = true;
                pictureBoxDataUpload2.Top -= 30;
                pictureBoxDataUpload3.Top -= 30;
                type = "0";

                // 是否是为生化同步
                if (config.AppSettings.Settings.AllKeys.Contains("IFshenghua"))
                {
                    ifShengHua = config.AppSettings.Settings["IFshenghua"].Value;
                }

                #region 根据按钮设置显示按钮

                if (BioCount.Equals("2"))
                {
                    pictureBoxDataUpload2.Visible = true;
                    this.Height = 372;
                }
                else
                {
                    if (versionNo.Contains("重庆") || versionNo.Contains("吉林") || versionNo.Contains("广西") || versionNo.Contains("河北") || versionNo.Contains("贵州") ||
                        versionNo.Contains("山西") || versionNo.Contains("新疆") || versionNo.Contains("云南") || area.Equals("连云港") || area.Equals("南京") || versionNo.Contains("山东"))
                    {
                        pictureBoxDataUpload2.Visible = true;
                        this.Height = 372;
                    }
                }

                #endregion
            }
            // 血球
            else if (DataType.Equals("BloodCorpuscle"))
            {
                rbSocket.Visible = true;
                pictureBoxDataUpload2.Top -= 30;
                pictureBoxDataUpload3.Top -= 30;
                type = "1";

                #region 根据按钮设置显示按钮

                if (BloodCount.Equals("2"))
                {
                    pictureBoxDataUpload2.Visible = true;
                    this.Height = 372;
                }
                else
                {
                    if (versionNo.Contains("福建") || versionNo.Contains("广西") || versionNo.Contains("山西") ||
                        versionNo.Contains("新疆") || versionNo.Contains("云南") || area.Equals("连云港") || area.Equals("南京") || versionNo.Contains("河北"))
                    {
                        pictureBoxDataUpload2.Visible = true;
                        this.Height = 372;
                    }
                }

                #endregion
            }
            // 外科
            else if (DataType.Equals("SurgicalData"))
            {
                pictureBoxDataUpload2.Top -= 30;
                pictureBoxDataUpload2.Visible = true;
                this.Height = 375;
            }
            // 内科
            else if (DataType.Equals("InternalMedicineData"))
            {
                pictureBoxDataUpload2.Top -= 30;
                pictureBoxDataUpload2.Visible = true;
                this.Height = 375;
            }
            // 随访  隐藏共享、网站同步
            else if (DataType.Equals("frmFollowDataUpdate"))
            {
                label3.Visible = false;
                panel1.Visible = false;
                panTotal.Location = new Point(3, 50);
                pictureBoxDataUpload.Location = new Point(3, 100);
                progressBar1.Location = new Point(3, 80);
                this.Height = 225;
            }
        }

        /// <summary>
        /// 数据同步第二个按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxDataUpload2_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0, total = 0;
                pictureBoxDataUpload2.Enabled = false;
                labCountnum.Text = "数据统计中，请稍后...";
                this.labUploadnum.Text = "0";

                string where = dataUploadBusiness.StrWhereByAccess(dtpStart.Value.Date, dtpEnd.Value.Date, "TestTime", ckbCheckDate.Checked);

                // 写入xml文件，用于分离式Windows Service读取
                dataUploadBusiness.SetDataUpload(DataType, deviceType);

                #region 取得资料笔数

                // 选择共享方式同步时
                if (rbShared.Checked)
                {
                    #region 共享

                    // 尿仪
                    if (DataType.Equals("UrineDevice")) dataUploadBusiness.GetDataCount(DataType, where, 2, ref total, ref dtInfo);
                    // 心电
                    else if (DataType.Equals("ECGUpload"))
                    {
                        if (rbOne.Checked) dataUploadBusiness.ecgType = "1";
                        else if (rbTwo.Checked) dataUploadBusiness.ecgType = "2";

                        where = dataUploadBusiness.StrWhere(dtpStart.Value.Date, dtpEnd.Value.Date, "ECGDate", ckbCheckDate.Checked);

                        dataUploadBusiness.GetDataCount(DataType, where, 2, ref total, ref ecgDataModel, ref surgicalModel, ref chestXModel, ref mouthModel);
                    }
                    // 生化
                    else if (DataType.Equals("Biochemical"))
                    {
                        if (ifShengHua == "Y") dataUploadBusiness.GetDataCount(DataType, where, 2, ref total, ref dtInfo);
                        else dataUploadBusiness.GetDataCount("UrineDevice", where, 2, ref total, ref dtInfo);
                    }
                    // B超
                    else if (DataType.Equals("TypeBForm"))
                    {
                        if (versionNo.Contains("重庆"))
                        {
                            dataUploadBusiness.GetDataCount(DataType, where, 2, ref total, ref dtInfo);
                        }
                        else
                        {
                            // 如果为新版B超
                            if (isNewTypeB.Equals("Y") || rbTwo.Checked)
                            {
                                dataUploadBusiness.isNewTypeB = "Y";

                                where = dataUploadBusiness.StrWhereByAccess(dtpStart.Value.Date, dtpEnd.Value.Date, "jcrq", ckbCheckDate.Checked);

                                dataUploadBusiness.GetDataCount(DataType, where, 2, ref total, ref dtInfo);
                            }
                            else
                            {
                                dataUploadBusiness.isNewTypeB = "N";

                                dataUploadBusiness.GetDataCount(DataType, "", 2, ref total, ref dtInfo);
                            }
                        }
                    }
                    // 外科、内科
                    else if (DataType.Equals("SurgicalData") || DataType.Equals("InternalMedicineData"))
                    {
                        where = dataUploadBusiness.StrWhere(dtpStart.Value.Date, dtpEnd.Value.Date, "RecordDate", ckbCheckDate.Checked);

                        dataUploadBusiness.GetDataCount(DataType, where, 2, ref total, ref ecgDataModel, ref surgicalModel, ref chestXModel, ref mouthModel);
                    }
                    // 血球
                    else if (DataType.Equals("BloodCorpuscle")) dataUploadBusiness.GetDataCount(DataType, where, 2, ref total, ref dtInfo);
                    // 中医
                    else if (DataType.Equals("OldHealth"))
                    {
                        where = dataUploadBusiness.StrWhere(dtpStart.Value.Date, dtpEnd.Value.Date, "Medicinecn.RecordDate", ckbCheckDate.Checked);

                        dataUploadBusiness.GetDataCount(DataType, where, ref total, ref dataUploadModel, ref selfLs, ref medicationSqliteLs,
                            ref historyModel, ref medicineModel, ref gloomyLs, ref intelligenceLs, ref conditionList, "btn2");
                    }

                    #endregion
                }
                else
                {
                    #region 网站 

                    dataUploadBusiness.cud = new CombinUploadData();

                    // 写入xml文件，用于分离式Windows Service读取
                    dataUploadBusiness.SetDataUpload(DataType + "2", deviceType);

                    total = DoSomeThing("Total");

                    Thread.Sleep(1000);

                    #endregion
                }

                #endregion

                if (total == 0)
                {
                    MessageBox.Show("查无资料！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    labCountnum.Text = "0";
                    pictureBoxDataUpload2.Enabled = true;
                    return;
                }

                this.labCountnum.Text = total.ToString();
                this.progressBar1.Visible = true;
                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = total;
                this.progressBar1.BackColor = Color.Green;
                this.progressBar1.Step = 1;

                Application.DoEvents();

                // 选择共享方式同步时
                if (rbShared.Checked)
                {
                    #region 共享同步

                    // 尿仪
                    if (DataType.Equals("UrineDevice"))
                    {
                        dataUploadBusiness.DataUploadNJ(dtInfo, ref count, progressBar1, null);
                    }
                    // 心电
                    else if (DataType.Equals("ECGUpload"))
                    {
                        if (rbOne.Checked) dataUploadBusiness.ecgType = "1";
                        else if (rbTwo.Checked) dataUploadBusiness.ecgType = "2";

                        dataUploadBusiness.DataUploadByEcg(ecgDataModel, this.rbWebsite.Checked, "GetECGPng", 2, ref count, progressBar1, null);
                    }
                    // B超
                    else if (DataType.Equals("TypeBForm"))
                    {
                        if (versionNo.Contains("重庆"))
                        {
                            dataUploadBusiness.DataUpload_Access(dtInfo, this.rbWebsite.Checked, "GetBChaoJpg", 2, ref count, progressBar1, null);
                        }
                        else
                        {
                            // 如果为新版B超
                            if (isNewTypeB.Equals("Y") || rbTwo.Checked) dataUploadBusiness.DataUploadByTypeBNew(dtInfo, this.rbWebsite.Checked, "GetBTypeJpg", 2, ref count, progressBar1, null);
                            else dataUploadBusiness.DataUploadByTypeB(dtInfo, this.rbWebsite.Checked, "GetBTypeJpg", 2, ref count, progressBar1, null);
                        }
                    }
                    // 生化
                    else if (DataType.Equals("Biochemical"))
                    {
                        if (ifShengHua == "Y") dataUploadBusiness.DataUploadByBlood(dtInfo, ref count, progressBar1, null);
                        else dataUploadBusiness.DataUploadNJ(dtInfo, ref count, progressBar1, null);
                    }
                    // 血球
                    else if (DataType.Equals("BloodCorpuscle"))
                    {
                        dataUploadBusiness.DataUploadByBlood(dtInfo, ref count, progressBar1, null);
                    }
                    // 外科
                    else if (DataType.Equals("SurgicalData"))
                    {
                        dataUploadBusiness.DataUploadBySurgical(surgicalModel, ref count, progressBar1, null);
                    }
                    // 内科
                    else if (DataType.Equals("InternalMedicineData"))
                    {
                        dataUploadBusiness.DataUploadByInternal(surgicalModel, ref count, progressBar1, null);
                    }
                    // 中医
                    else if (DataType.Equals("OldHealth"))
                    {
                        dataUploadBusiness.DataUploadByOld(medicineModel, this.rbWebsite.Checked, selfLs, gloomyLs, intelligenceLs, conditionList, ref count, progressBar1, null);
                    }

                    #endregion
                }
                else
                {
                    #region 网站同步

                    for (int i = 0; i < total; i++)
                    {
                        Thread.Sleep(50);

                        progressBar1.PerformStep();

                        Application.DoEvents();
                    }

                    Thread.Sleep(100);

                    count = DoSomeThing("Count");

                    // 读取异常内容
                    ReadLog(dataUploadBusiness.cud.dtData);

                    #endregion
                }

                Thread.Sleep(100);

                MessageBox.Show("成功匹配：" + count + "条数据！", "提示");

                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = 0;
                this.progressBar1.Visible = false;
                this.pictureBoxDataUpload2.Enabled = true;
                this.labUploadnum.Text = count.ToString();

                Application.DoEvents();

                if (dataUploadBusiness.cud.dtData.Rows.Count > 0)
                {
                    UploadData ud = new UploadData { dtData = dataUploadBusiness.cud.dtData };
                    ud.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = 0;
                this.progressBar1.Visible = false;
                this.pictureBoxDataUpload2.Enabled = true;
                labCountnum.Text = "异常...";

                if (dataUploadBusiness.cud.dtData.Rows.Count > 0)
                {
                    UploadData ud = new UploadData { dtData = dataUploadBusiness.cud.dtData };
                    ud.ShowDialog();
                }

                LogHelper.WriteLog(ex.ToString());
            }
        }

        /// <summary>
        /// 数据同步第三个按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxDataUpload3_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0, total = 0;
                pictureBoxDataUpload3.Enabled = false;
                labCountnum.Text = "数据统计中，请稍后...";

                string where = dataUploadBusiness.StrWhere(dtpStart.Value.Date, dtpEnd.Value.Date, "ECGDate", ckbCheckDate.Checked);

                // 写入xml文件，用于分离式Windows Service读取
                dataUploadBusiness.SetDataUpload(DataType, deviceType);

                #region 取得资料笔数

                // 选择共享方式同步时
                if (rbShared.Checked)
                {
                    #region 共享

                    // 心电
                    if (DataType.Equals("ECGUpload"))
                    {
                        if (rbOne.Checked) dataUploadBusiness.ecgType = "1";
                        else if (rbTwo.Checked) dataUploadBusiness.ecgType = "2";

                        dataUploadBusiness.GetDataCount(DataType, where, 3, ref total, ref ecgDataModel, ref surgicalModel, ref chestXModel, ref mouthModel);
                    }
                    // B超
                    else if (DataType.Equals("TypeBForm"))
                    {
                        // 如果为新版B超
                        if (isNewTypeB.Equals("Y") || rbTwo.Checked)
                        {
                            dataUploadBusiness.isNewTypeB = "Y";

                            where = dataUploadBusiness.StrWhereByAccess(dtpStart.Value.Date, dtpEnd.Value.Date, "jcrq", ckbCheckDate.Checked);

                            dataUploadBusiness.GetDataCount(DataType, where, 3, ref total, ref dtInfo);
                        }
                        else
                        {
                            dataUploadBusiness.isNewTypeB = "N";

                            dataUploadBusiness.GetDataCount(DataType, "", 3, ref total, ref dtInfo);
                        }
                    }

                    #endregion
                }
                else
                {
                    #region 网站

                    dataUploadBusiness.cud = new CombinUploadData();

                    // 写入xml文件，用于分离式Windows Service读取
                    dataUploadBusiness.SetDataUpload(DataType + "3", deviceType);

                    total = DoSomeThing("Total");

                    Thread.Sleep(1000);

                    #endregion
                }

                #endregion

                if (total == 0)
                {
                    MessageBox.Show("查无资料！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    labCountnum.Text = "0";
                    pictureBoxDataUpload3.Enabled = true;
                    return;
                }

                this.labCountnum.Text = total.ToString();
                this.progressBar1.Visible = true;
                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = total;
                this.progressBar1.BackColor = Color.Green;
                this.progressBar1.Step = 1;

                Application.DoEvents();

                // 选择共享方式同步时
                if (rbShared.Checked)
                {
                    #region 共享同步

                    // 心电
                    if (DataType.Equals("ECGUpload"))
                    {
                        dataUploadBusiness.DataUploadByEcg(ecgDataModel, this.rbWebsite.Checked, "GetECGPng", 3, ref count, progressBar1, null);
                    }
                    // B超
                    else if (DataType.Equals("TypeBForm"))
                    {
                        // 如果为新版B超
                        if (isNewTypeB.Equals("Y") || rbTwo.Checked) dataUploadBusiness.DataUploadByTypeBNew(dtInfo, this.rbWebsite.Checked, "GetBTypeJpg", 3, ref count, progressBar1, null);
                        else dataUploadBusiness.DataUploadByTypeB(dtInfo, this.rbWebsite.Checked, "GetBTypeJpg", 3, ref count, progressBar1, null);
                    }

                    #endregion
                }
                else
                {
                    #region 网站同步

                    for (int i = 0; i < total; i++)
                    {
                        Thread.Sleep(50);

                        progressBar1.PerformStep();

                        Application.DoEvents();
                    }

                    Thread.Sleep(100);

                    count = DoSomeThing("Count");

                    // 读取异常内容
                    ReadLog(dataUploadBusiness.cud.dtData);

                    #endregion
                }

                Thread.Sleep(100);

                MessageBox.Show("成功匹配：" + count + "条数据！", "提示");

                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = 0;
                this.progressBar1.Visible = false;

                this.pictureBoxDataUpload3.Enabled = true;
                this.labUploadnum.Text = count.ToString();

                Application.DoEvents();

                if (dataUploadBusiness.cud.dtData.Rows.Count > 0)
                {
                    UploadData ud = new UploadData { dtData = dataUploadBusiness.cud.dtData };
                    ud.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = 0;
                this.progressBar1.Visible = false;
                this.pictureBoxDataUpload3.Enabled = true;
                labCountnum.Text = "异常...";

                if (dataUploadBusiness.cud.dtData.Rows.Count > 0)
                {
                    UploadData ud = new UploadData { dtData = dataUploadBusiness.cud.dtData };
                    ud.ShowDialog();
                }
                LogHelper.WriteLog(ex.ToString());
            }
        }

        private void chkNewUrine_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNewUrine.Checked)
            {
                ckbCheckDate.Enabled = false;
                datePn.Enabled = false;
                panel1.Enabled = false;
                panDeviceType.Enabled = false;
            }
            else
            {
                ckbCheckDate.Enabled = true;
                datePn.Enabled = true;
                panel1.Enabled = true;
                panDeviceType.Enabled = true;
            }
        }

        private void ckbCheckDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbCheckDate.Checked)
            {
                this.dtpStart.Enabled = true;
                this.dtpEnd.Enabled = true;
            }
            else
            {
                this.dtpStart.Enabled = false;
                this.dtpEnd.Enabled = false;
            }
        }

        /// <summary>
        /// 网络同步读取数据判断分离式上Windows Services是否有执行返回数据
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int DoSomeThing(string node)
        {
            int value = 0, whileCount = 0;

            while (whileCount < 60)
            {
                whileCount++;

                string result = dataUploadBusiness.GetDataUpload(node);

                if (result != "")
                {
                    value = int.Parse(result);
                    whileCount = 61;
                }
                else Thread.Sleep(2000);

                Application.DoEvents();
            }

            return value;
        }

        /// <summary>
        /// 网络同步完成读取Log文件显示未同步人员清单
        /// </summary>
        /// <param name="dt"></param>
        private void ReadLog(DataTable dt)
        {
            string fileName = "D:\\QCSoft\\SetDataUpload.csv";

            if (System.IO.File.Exists(fileName))
            {
                StreamReader sr = new StreamReader(fileName, Encoding.Default);
                string line = "";

                // 标示是否是读取的第一行
                bool isFirst = true;

                // 记录每行记录中的各字段内容
                string[] aryLine = null;

                while ((line = sr.ReadLine()) != null)
                {
                    if (isFirst) isFirst = false;
                    else
                    {
                        aryLine = line.Split(',');

                        DataRow dr = dt.NewRow();

                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            dr[j] = aryLine[j].Replace("\"", "");
                        }

                        dt.Rows.Add(dr);
                    }
                }

                sr.Close();
            }
        }

        #region 新尿机--调整时也需要同步调整DataUploadUI项目中的内容

        string str = "";

        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] readBuffer = new byte[comm.ReadBufferSize];

                while (readBuffer.Length < 325)
                {
                    readBuffer = new byte[comm.ReadBufferSize];
                }

                comm.Read(readBuffer, 0, readBuffer.Length);

                str += System.Text.Encoding.ASCII.GetString(readBuffer);

                Thread.Sleep(2000);

                if (comm.BytesToRead == 0) DataUploadNew();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void DataUploadNew()
        {
            DeviceInfoModel deciveModel = new DeviceInfoModel();
            RecordsAssistCheckModel saveModel = new RecordsAssistCheckModel();
            DataModel dataModel = new DataModel();
            CombinUploadData cud = new CombinUploadData();
            string code = "";

            try
            {
                byte[] STX = new byte[] { 0x02 };   // 开始符
                byte[] EXT = new byte[] { 0x03 };   // 结束符
                byte[] NUL = new byte[] { 0x00 };   // 空格符
                string start = System.Text.Encoding.ASCII.GetString(STX);
                string end = System.Text.Encoding.ASCII.GetString(EXT);
                string empty = System.Text.Encoding.ASCII.GetString(NUL);

                string[] value = str.Replace(empty, "").Split(new String[] { end }, StringSplitOptions.RemoveEmptyEntries);

                this.Invoke((EventHandler)(delegate
                {
                    if (value.Length == 0)
                    {
                        MessageBox.Show("查无资料！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        labCountnum.Text = "0";
                        pictureBoxDataUpload.Enabled = true;
                        return;
                    }

                    this.labCountnum.Text = value.Length.ToString();
                    this.progressBar1.Visible = true;
                    this.progressBar1.Minimum = 0;
                    this.progressBar1.Maximum = value.Length;
                    this.progressBar1.BackColor = Color.Green;
                }));

                BackgroundWorker dgWorker = new BackgroundWorker();
                List<miniPadModel> dicUpOK = new List<miniPadModel>();

                deciveModel = new DeviceInfoModel();
                saveModel = new RecordsAssistCheckModel();

                dgWorker.DoWork += (senderdg, edg) =>
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        string value2 = value[i].Replace(start, "");

                        string[] empValue = value2.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                        if (empValue.Length > 13)
                        {
                            deciveModel.DeviceName = "新尿液分析";
                            deciveModel.DeviceType = "33";
                            deciveModel.UpdateData = empValue[0].Substring(5, 16);  //  日期
                            deciveModel.Codes = empValue[1].Substring(5).Replace(" ", "");  //  尿机ID
                            deciveModel.BarCode = empValue[2].Substring(5).Replace(" ", "");  //  条码号
                            deciveModel.IDCardNo = empValue[3].Substring(5).Replace(" ", "");  //  身份证号

                            deciveModel.Value9 = empValue[4].Substring(5, 2).Replace(" ", "");  //  尿白细胞 LEU
                            deciveModel.Value4 = empValue[5].Substring(5, 2).Replace(" ", "");           //  尿酮体 KET
                            deciveModel.Value8 = empValue[6].Substring(5, 2).Replace(" ", "");          //  亚硝酸盐 NIT
                            deciveModel.Value1 = empValue[7].Substring(5, 2).Replace(" ", "");         //  尿胆原 URO
                            deciveModel.Value6 = empValue[8].Substring(5, 2).Replace(" ", "");      // 尿蛋白 PRO
                            deciveModel.Value3 = empValue[9].Substring(5, 2).Replace(" ", "");      //  胆红素 BIL
                            deciveModel.Value5 = empValue[10].Substring(5, 2).Replace(" ", "");      // 尿糖 GLU
                            deciveModel.Value10 = empValue[11].Substring(5).Replace(" ", "");              // 比重 SG
                            deciveModel.Value2 = empValue[12].Substring(5, 2).Replace(" ", "");             // 尿潜血 BLD
                            deciveModel.Value7 = empValue[13].Substring(5).Replace(" ", "");                  //  酸碱度 PH
                            deciveModel.Value11 = empValue[14].Substring(5, 2).Replace(" ", "");          //  抗坏血酸 VC

                            code = string.IsNullOrEmpty(deciveModel.BarCode) ? deciveModel.IDCardNo : deciveModel.BarCode;

                            // 尿机Model赋值
                            dataUploadBusiness.SetUrineModel(null, ref saveModel, ref dataModel, ref deciveModel);

                            // 更新栏位上传表
                            if (!deviceInfoBLL.UpdateNew(deciveModel)) deviceInfoBLL.AddNew(deciveModel);

                            // 更新Pad成功时
                            if (recordsAssistCheckBll.Update(saveModel, deciveModel.BarCode))
                            {
                                dicUpOK.Add(new miniPadModel() { IDCardNo = deciveModel.IDCardNo, CheckDate = deciveModel.UpdateData });

                                dgWorker.ReportProgress(dicUpOK.Count);
                            }
                            else
                            {
                                RecordsBaseInfoModel BaseModel = new RecordsBaseInfoBLL().GetModel(code);
                                cud.ConbinData(BaseModel, code, "资料不存在");
                            }
                        }
                    }
                };

                dgWorker.ProgressChanged += (senderdg, edg) =>
                {
                    this.Invoke((EventHandler)(delegate
                    {
                        progressBar1.Value = edg.ProgressPercentage;
                    }));
                };

                dgWorker.RunWorkerCompleted += (senderdg, edg) =>
                {
                    MessageBox.Show("成功匹配：" + dicUpOK.Count + "条数据！", "提示");

                    this.Invoke((EventHandler)(delegate
                    {
                        progressBar1.Visible = false;
                        pictureBoxDataUpload.Enabled = true;
                        this.labUploadnum.Text = dicUpOK.Count.ToString();

                        if (cud.dtData.Rows.Count > 0)
                        {
                            UploadData ud = new UploadData { dtData = cud.dtData };
                            ud.ShowDialog();
                        }
                    }));
                };

                dgWorker.WorkerReportsProgress = true;
                dgWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                cud.ConbinData(null, code, ex.ToString());
                MessageBox.Show(ex.ToString());
            }

            StopRead();
        }

        public void StopRead()
        {
            try
            {
                if (this.comm != null)
                {
                    this.comm.DataReceived -= new SerialDataReceivedEventHandler(this.comm_DataReceived);

                    if (this.comm.IsOpen)
                    {
                        this.comm.Close();
                    }

                    this.comm.Dispose();
                    this.comm = null;
                }

            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 设置设备名称等其他信息
        /// </summary>
        /// <param name="str"></param>
        private void setText(string str, Label lb)
        {
            Action<string, Label> setLb = new Action<string, Label>(setText);
            if (lb.InvokeRequired)
            {
                lb.Invoke(setLb, new object[] { str, lb });
            }
            else
            {
                lb.Text = str;
            }
        }

        #endregion

        #region Socket通讯--调整时也需要同步调整DataUploadUI项目中的内容

        /// <summary>
        /// 通信方式勾选时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbSocket_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSocket.Checked)
            {
                UploadTypeForm uf = new UploadTypeForm { Type = type };

                if (uf.ShowDialog() == DialogResult.OK)
                {
                    protocol = uf.Protocol;
                    pIp = uf.IP;
                    pPort = uf.Port;
                }
            }
        }

        /// <summary>
        /// 通过网络通信获取数据
        /// </summary>
        public void GetDataBySocket()
        {
            try
            {
                pictureBoxDataUpload.Enabled = false;
                labCountnum.Text = "数据统计中，请稍后...";
                this.labUploadnum.Text = "0";

                uploadCount = 0;
                this.endFlag = true;
                Application.DoEvents();

                string IP = config.AppSettings.Settings[pIp].Value;
                string port = config.AppSettings.Settings[pPort].Value;

                pictureBoxDataUpload.Enabled = true;

                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(IP);
                IPEndPoint point = new IPEndPoint(ip, int.Parse(port));
                socketSend.ReceiveTimeout = 5000;
                socketSend.Connect(point);

                string msg = "{\"Type\":\"" + type + "\",\"StartDate\":\"" + dataUploadBusiness.startDate + "\",\"EndDate\":\"" + dataUploadBusiness.endDate + "\"}";
                byte[] buffer = new byte[1024 * 1024 * 3];

                buffer = Encoding.UTF8.GetBytes(msg);
                socketSend.Send(buffer);

                // 开启新的线程，不停的接收服务器发来的消息
                Thread c_thread = new Thread(Received);
                c_thread.IsBackground = true;
                c_thread.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("IP或者端口号错误...");
            }
        }

        private void pictureBoxDataUpload_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0, total = 0;
                pictureBoxDataUpload.Enabled = false;
                labCountnum.Text = "数据统计中，请稍后...";

                #region 新尿机开启端口

                // 新尿机
                if (chkNewUrine.Checked)
                {
                    str = "";

                    if (comm == null || !this.comm.IsOpen)
                    {
                        comm = new SerialPort();

                        comm.PortName = config.AppSettings.Settings["EMPUI"].Value;
                        comm.BaudRate = 9600;

                        try
                        {
                            this.comm.Open();
                            this.comm.DataReceived += new SerialDataReceivedEventHandler(this.comm_DataReceived);

                            Thread.Sleep(200);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("设备连接失败！" + ex.ToString(), "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    return;
                }

                #endregion

                string where = dataUploadBusiness.StrWhere(dtpStart.Value.Date, dtpEnd.Value.Date, DataType, deviceType, ckbCheckDate.Checked);

                #region 取得资料笔数

                // 随访同步
                if (DataType.Equals("frmFollowDataUpdate"))
                {
                    where = dataUploadBusiness.StrWhere(dtpStart.Value.Date, dtpEnd.Value.Date, "CheckDate", ckbCheckDate.Checked);

                    dataUploadBusiness.GetDataCount(DataType, where, 1, ref total, ref dtInfo);
                }
                else
                {
                    // 选择共享方式同步时
                    if (rbShared.Checked)
                    {
                        #region 共享

                        // 生化、血球
                        if (DataType.Equals("Biochemical") || DataType.Equals("BloodCorpuscle"))
                        {
                            where = dataUploadBusiness.StrWhereByAccess(dtpStart.Value.Date, dtpEnd.Value.Date, "TestTime", ckbCheckDate.Checked);

                            dataUploadBusiness.GetDataCount(DataType, where, 1, ref total, ref dtInfo);
                        }
                        // 问询
                        else if (DataType.Equals("MedicalEnquiry"))
                        {
                            where = dataUploadBusiness.StrWhere(dtpStart.Value.Date, dtpEnd.Value.Date, "RecordDate", ckbCheckDate.Checked);

                            dataUploadBusiness.GetDataCount(DataType, where, ref total, ref dataUploadModel, ref selfLs, ref medicationSqliteLs,
                                ref historyModel, ref medicineModel, ref gloomyLs, ref intelligenceLs, ref conditionList, "");
                        }
                        // 中医
                        else if (DataType.Equals("OldHealth"))
                        {
                            where = dataUploadBusiness.StrWhere(dtpStart.Value.Date, dtpEnd.Value.Date, "Medicinecn.RecordDate", ckbCheckDate.Checked);

                            dataUploadBusiness.GetDataCount(DataType, where, ref total, ref dataUploadModel, ref selfLs, ref medicationSqliteLs,
                                ref historyModel, ref medicineModel, ref gloomyLs, ref intelligenceLs, ref conditionList, "btn1");
                        }
                        // 心电
                        else if (DataType.Equals("ECGUpload"))
                        {
                            if (rbOne.Checked) dataUploadBusiness.ecgType = "1";
                            else if (rbTwo.Checked) dataUploadBusiness.ecgType = "2";

                            where = dataUploadBusiness.StrWhere(dtpStart.Value.Date, dtpEnd.Value.Date, "ECGDate", ckbCheckDate.Checked);

                            dataUploadBusiness.GetDataCount(DataType, where, 1, ref total, ref ecgDataModel, ref surgicalModel, ref chestXModel, ref mouthModel);
                        }
                        // B超
                        else if (DataType.Equals("TypeBForm"))
                        {
                            // 如果为新版B超
                            if (isNewTypeB.Equals("Y") || rbTwo.Checked)
                            {
                                dataUploadBusiness.isNewTypeB = "Y";

                                where = dataUploadBusiness.StrWhereByAccess(dtpStart.Value.Date, dtpEnd.Value.Date, "jcrq", ckbCheckDate.Checked);

                                dataUploadBusiness.GetDataCount(DataType, where, 1, ref total, ref dtInfo);
                            }
                            else
                            {
                                dataUploadBusiness.isNewTypeB = "N";

                                dataUploadBusiness.GetDataCount(DataType, "", 1, ref total, ref dtInfo);
                            }
                        }
                        // 外科、内科、五官、X光
                        else if (DataType.Equals("SurgicalData") || DataType.Equals("InternalMedicineData") || DataType.Equals("MouthData") || DataType.Equals("ChestXData"))
                        {
                            // 安徽X光
                            if (versionNo.Contains("安徽") || DR.Equals("Y") && DataType.Equals("ChestXData"))
                            {
                                where = dataUploadBusiness.StrWhereByAccessStringDate(dtpStart.Value.Date, dtpEnd.Value.Date, "mid(TestTime,1,8)", ckbCheckDate.Checked);

                                dataUploadBusiness.GetDataCount(DataType, where, 1, ref total, ref dtInfo);
                            }
                            else
                            {
                                where = dataUploadBusiness.StrWhere(dtpStart.Value.Date, dtpEnd.Value.Date, "RecordDate", ckbCheckDate.Checked);

                                dataUploadBusiness.GetDataCount(DataType, where, 1, ref total, ref ecgDataModel, ref surgicalModel, ref chestXModel, ref mouthModel);
                            }
                        }
                        // 视力
                        else if (DataType.Equals("Vsiual"))
                        {
                            where = dataUploadBusiness.StrWhereByAccess(dtpStart.Value.Date, dtpEnd.Value.Date, "AddTime", ckbCheckDate.Checked);

                            dataUploadBusiness.GetDataCount(DataType, where, 1, ref total, ref dtInfo);
                        }
                        // 血压、身高体重、尿仪、体温体重、血糖
                        else dataUploadBusiness.GetDataCount(DataType, where, ref total, ref deviceSqliteLs);

                        #endregion
                    }
                    // 如果为通信方式时
                    else if (rbSocket.Checked)
                    {
                        #region 通信

                        if (config.AppSettings.Settings.AllKeys.Contains(protocol))
                        {
                            string checkType = config.AppSettings.Settings[protocol].Value;

                            if (checkType == "Y") GetDataBySocket();
                        }
                        else
                        {
                            MessageBox.Show("请先配置Socket通信的地址！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            labCountnum.Text = "0";
                            pictureBoxDataUpload.Enabled = true;
                            return;
                        }

                        #endregion
                    }
                    else
                    {
                        #region 网站

                        dataUploadBusiness.cud = new CombinUploadData();

                        // 写入xml文件，用于分离式Windows Service读取
                        dataUploadBusiness.SetDataUpload(DataType, deviceType);

                        total = DoSomeThing("Total");

                        Thread.Sleep(1000);

                        #endregion
                    }
                }

                #endregion

                if (total == 0)
                {
                    MessageBox.Show("查无资料！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    labCountnum.Text = "0";
                    pictureBoxDataUpload.Enabled = true;
                    return;
                }

                this.labCountnum.Text = total.ToString();
                this.progressBar1.Visible = true;
                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = total;
                this.progressBar1.BackColor = Color.Green;
                this.progressBar1.Step = 1;

                Application.DoEvents();

                // 随访同步
                if (DataType.Equals("frmFollowDataUpdate"))
                {
                    dataUploadBusiness.DataUploadByFollow(dtInfo, ref count, progressBar1, null);
                }
                else
                {
                    // 选择共享方式同步时
                    if (rbShared.Checked)
                    {
                        #region 共享同步

                        // 尿仪
                        if (DataType.Equals("UrineDevice"))
                        {
                            dataUploadBusiness.DataUploadByUrine(deviceSqliteLs, ref count, progressBar1, null);
                        }
                        // 血糖
                        else if (DataType.Equals("BloodSugar"))
                        {
                            dataUploadBusiness.DataUploadBySugar(deviceSqliteLs, ref count, progressBar1, null);
                        }
                        // 体温体重
                        else if (DataType.Equals("ThermometerWeight"))
                        {
                            dataUploadBusiness.DataUploadByWeight(deviceSqliteLs, ref count, progressBar1, null);
                        }
                        // 身高体重
                        else if (DataType.Equals("HeightWeight"))
                        {
                            dataUploadBusiness.DataUploadByHeight(deviceSqliteLs, ref count, progressBar1, null);
                        }
                        // 血压
                        else if (DataType.Equals("BloodPressure"))
                        {
                            dataUploadBusiness.DataUploadByPressure(deviceSqliteLs, ref count, progressBar1, null);
                        }
                        // 问询
                        else if (DataType.Equals("MedicalEnquiry"))
                        {
                            dataUploadBusiness.DataUploadByMedical(dataUploadModel, selfLs, medicationSqliteLs, historyModel, ref count, progressBar1, null);
                        }
                        // 中医
                        else if (DataType.Equals("OldHealth"))
                        {
                            dataUploadBusiness.DataUploadByOld(medicineModel, this.rbWebsite.Checked, selfLs, gloomyLs, intelligenceLs, conditionList, ref count, progressBar1, null);
                        }
                        // 心电
                        else if (DataType.Equals("ECGUpload"))
                        {
                            // 一代心电
                            if (rbOne.Checked) dataUploadBusiness.DataUploadByFirstEcg(ecgDataModel, ref count, progressBar1, null);
                            else dataUploadBusiness.DataUploadByEcg(ecgDataModel, this.rbWebsite.Checked, "GetECGPng", 1, ref count, progressBar1, null);
                        }
                        // B超
                        else if (DataType.Equals("TypeBForm"))
                        {
                            // 如果为新版B超
                            if (isNewTypeB.Equals("Y") || rbTwo.Checked) dataUploadBusiness.DataUploadByTypeBNew(dtInfo, this.rbWebsite.Checked, "GetBTypeJpg", 1, ref count, progressBar1, null);
                            else dataUploadBusiness.DataUploadByTypeB(dtInfo, this.rbWebsite.Checked, "GetBTypeJpg", 1, ref count, progressBar1, null);
                        }
                        // 生化、血球
                        else if (DataType.Equals("Biochemical") || DataType.Equals("BloodCorpuscle"))
                        {
                            // 新疆同步身高体重
                            if (versionNo.Contains("新疆")) dataUploadBusiness.DataUploadByHeight(where, DataType);

                            dataUploadBusiness.DataUploadByBlood(dtInfo, ref count, progressBar1, null);
                        }
                        // 外科
                        else if (DataType.Equals("SurgicalData"))
                        {
                            dataUploadBusiness.DataUploadBySurgical(surgicalModel, ref count, progressBar1, null);
                        }
                        // 内科
                        else if (DataType.Equals("InternalMedicineData"))
                        {
                            dataUploadBusiness.DataUploadByInternal(surgicalModel, ref count, progressBar1, null);
                        }
                        // 五官
                        else if (DataType.Equals("MouthData"))
                        {
                            dataUploadBusiness.DataUploadByMouth(mouthModel, ref count, progressBar1, null);
                        }
                        // X光
                        else if (DataType.Equals("ChestXData"))
                        {
                            // 安徽X光
                            if (versionNo.Contains("安徽") || DR.Equals("Y")) dataUploadBusiness.DataUploadChestXByAccess(dtInfo, ref count, progressBar1, null);
                            else dataUploadBusiness.DataUploadByChestX(chestXModel, ref count, progressBar1, null);
                        }
                        // 视力
                        else if (DataType.Equals("Vsiual"))
                        {
                            dataUploadBusiness.DataUploadByVsiual(dtInfo, ref count, progressBar1, null);
                        }

                        #endregion
                    }
                    else
                    {
                        #region 网站同步

                        for (int i = 0; i < total; i++)
                        {
                            Thread.Sleep(50);

                            progressBar1.PerformStep();

                            Application.DoEvents();
                        }

                        Thread.Sleep(100);

                        count = DoSomeThing("Count");

                        // 读取异常内容
                        ReadLog(dataUploadBusiness.cud.dtData);

                        #endregion
                    }
                }

                Thread.Sleep(100);

                MessageBox.Show("成功匹配：" + count + "条数据！", "提示");
                this.labUploadnum.Text = count.ToString();
                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = 0;
                this.progressBar1.Visible = false;
                this.pictureBoxDataUpload.Enabled = true;

                Application.DoEvents();

                if (dataUploadBusiness.cud.dtData.Rows.Count > 0)
                {
                    UploadData ud = new UploadData { dtData = dataUploadBusiness.cud.dtData };
                    ud.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = 0;
                this.progressBar1.Visible = false;
                this.pictureBoxDataUpload.Enabled = true;
                labCountnum.Text = "异常...";

                if (dataUploadBusiness.cud.dtData.Rows.Count > 0)
                {
                    UploadData ud = new UploadData { dtData = dataUploadBusiness.cud.dtData };
                    ud.ShowDialog();
                }

                LogHelper.WriteLog(ex.ToString());
            }
        }

        private void ControlTextRefresh(Control ctr, string text)
        {
            Action<Control, string> method = new Action<Control, string>(this.ControlTextRefresh);

            if (ctr.InvokeRequired)
            {
                ctr.Invoke(method, new object[] { ctr, text });
            }
            else
            {
                ctr.Text = text;
                Application.DoEvents();
            }
        }

        /// <summary>
        /// 滚动条设置
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="value"></param>
        /// <param name="visibleflag"></param>
        private void ProcessBarRefresh(ProgressBar bar, int value, bool visibleflag)
        {
            Action<ProgressBar, int, bool> method = new Action<ProgressBar, int, bool>(this.ProcessBarRefresh);

            if (bar.InvokeRequired)
            {
                bar.Invoke(method, new object[] { bar, value, visibleflag });
            }
            else
            {
                if (visibleflag)
                {
                    bar.Visible = true;
                    bar.Minimum = 0;
                    bar.Maximum = value;
                    bar.BackColor = Color.Green;
                }
                else bar.Visible = false;
            }
        }

        /// <summary>
        /// 滚动条数据值设置
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="value"></param>
        private void ProcessBarValueRefresh(ProgressBar bar, int value)
        {
            Action<ProgressBar, int> method = new Action<ProgressBar, int>(this.ProcessBarValueRefresh);

            if (bar.InvokeRequired)
            {
                bar.Invoke(method, new object[] { bar, value });
            }
            else
            {
                bar.Value = value;
                Application.DoEvents();
            }
        }

        public bool UpdateData(string data)
        {
            JsonClass jClass = new JsonHelper().DeserializeJsonToObject<JsonClass>(data);
            DataModel model = jClass.Data;
            CombinUploadData cud = new CombinUploadData();

            if (jClass.Message.ToUpper() == "CONNECTFAIL") //数据查询失败
            {
                MessageBox.Show("读取数据失败...");
                return false;
            }
            else if (jClass.Message.ToUpper() == "CONNECTOK") //数据查询成功
            {
                this.ControlTextRefresh(this.labCountnum, jClass.Status);
                this.ProcessBarRefresh(this.progressBar1, int.Parse(jClass.Status) + 5, true);
                return true;
            }
            else if (jClass.Message.ToUpper() == "OVER") //数据传送完毕
            {
                socketSend.Close();

                this.ProcessBarRefresh(this.progressBar1, int.Parse(jClass.Status), false);
                DialogResult dr = MessageBox.Show("成功匹配：" + uploadCount + "条数据！", "提示");

                if (dr == DialogResult.OK)
                {
                    if (cud.dtData.Rows.Count > 0)
                    {
                        UploadData ud = new UploadData { dtData = cud.dtData };
                        ud.ShowDialog();
                    }
                    return false;
                }
            }

            if (model == null) return true;

            if (recordsAssistCheckBll.UpdateXQ(model) <= 0) new RecordsxqBLL().AddRow(model);

            int successNum = recordsAssistCheckBll.UpdateAssistCheck(model);

            if (successNum > 0)
            {
                uploadCount++;
                this.ControlTextRefresh(this.labUploadnum, uploadCount.ToString());
                this.ProcessBarValueRefresh(this.progressBar1, uploadCount);
                Application.DoEvents();
            }
            else
            {
                RecordsBaseInfoModel BaseModel = new RecordsBaseInfoBLL().GetModel(model.IDCardNo);

                cud.ConbinData(BaseModel, model.IDCardNo, "体检数据更新失败");
            }

            return true;
        }

        /// <summary>
        /// 接收服务端返回的消息
        /// </summary>
        public void Received()
        {
            Application.DoEvents();
            byte[] newBuffer = new byte[] { };//大小可变的缓存器

            while (endFlag)
            {
                try
                {
                    int receivedLength;
                    byte[] buffer = new byte[1024 * 1024 * 3];
                    MessageProtocol msgXY = new MessageProtocol();

                    //实际接收到的有效字节数
                    receivedLength = socketSend.Receive(buffer);

                    string s = Encoding.UTF8.GetString(buffer);
                    newBuffer = MessageProtocol.ToArray(newBuffer, 0, newBuffer.Length, buffer, 0, receivedLength);

                    if (newBuffer.Length < 6) continue;
                    else
                    {
                        msgXY = MessageProtocol.FromBytes(newBuffer);

                        int firstFlag = msgXY.XieYiFirstFlag;
                        int secondFlag = msgXY.XieYiSecondFlag;
                        int msgContentLength = msgXY.MessageContentLength;

                        while ((newBuffer.Length - 6) >= msgContentLength)
                        {
                            msgXY = MessageProtocol.FromBytes(newBuffer);

                            string data = Encoding.UTF8.GetString(msgXY.MessageContent);

                            endFlag = UpdateData(data);
                            newBuffer = msgXY.DuoYvBytes;
                            msgContentLength = msgXY.MessageContentLength;

                            if (newBuffer == null)
                            {
                                newBuffer = new byte[] { };
                                break;
                            }

                            if (newBuffer.Length >= 6)
                            {
                                msgXY = MessageProtocol.FromBytes(newBuffer);
                                firstFlag = msgXY.XieYiFirstFlag;
                                secondFlag = msgXY.XieYiSecondFlag;
                                msgContentLength = msgXY.MessageContentLength;
                                continue;
                            }
                            else break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion
    }
}