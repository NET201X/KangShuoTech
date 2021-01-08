using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.Utilities.Common;

namespace HealthHouse
{
    /// <summary>
    /// 新增/修改指导信息
    /// </summary>
    public partial class HealthGuideForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private TimeParser timeParser = new TimeParser();
        HealthHouseGuideModel guideModel = new HealthHouseGuideModel(); // 健康指导
        HealthHouseGuideBLL guideBll = new HealthHouseGuideBLL();

        public HealthGuideForm()
        {
            InitializeComponent();

            this.EveryThingIsOk = false;
        }

        private void HealthGuideForm_Load(object sender, EventArgs e)
        {
            InitEveryThing();
        }

        public void InitEveryThing()
        {
            if (HealthGuideFactory.ViewState == "修改")
            {
                // 获取指导信息
                HealthHouseGuideModel guideModel = guideBll.GetHealthGuideByIdCardNo(HealthGuideFactory.ID);

                this.lbName.Text = guideModel.CustomerName;
                this.lbData.Text = guideModel.CheckDate.Value.ToString("yyyy-MM-dd");
                this.lblAge.Text = timeParser.GetAge(guideModel.Birthday);
                this.lblSex.Text = StringPlus.GetSex(guideModel.Sex);
                this.txtSummary.Text = guideModel.Summary;
                this.txtHealthGuid.Text = guideModel.HealthGuid;
                this.txtMedGuid.Text = guideModel.MedGuid;
            }
            else
            {
                // 获取病人是否有健康指导
                HealthHouseModel houseModel = new HealthHouseBLL().GetMaxData(this.Model.IDCardNo);
                RecordsBaseInfoModel baseInfo = new RecordsBaseInfoBLL().GetModel(this.Model.IDCardNo);  // 体检人基本信息

                // 获取体检标准值
                List<HealthOverviewSetModel> SetList = new List<HealthOverviewSetModel>();
                HealthOverviewSetBLL OverViewBll = new HealthOverviewSetBLL();
                SetList = OverViewBll.GetList(" and Type in (1,2,3,4,5,6,7,8,9,10,11)");
                HealthGuideFactory.PID = houseModel.ID; // 新增获取体检ID赋值给指导PID

                if (houseModel != null && baseInfo != null)
                {
                    HealthAssessFactory.ID = houseModel.ID;
                    this.lbName.Text = baseInfo.CustomerName;
                    this.lbData.Text = houseModel.CheckDate.Value.ToString("yyyy-MM-dd");
                    this.lblAge.Text = timeParser.GetAge(baseInfo.Birthday);
                    this.lblSex.Text = StringPlus.GetSex(baseInfo.Sex);

                    #region 体检小结/健康指导

                    if (SetList != null)
                    {
                        foreach (HealthOverviewSetModel hs in SetList)
                        {
                            #region 基本体检

                            if (hs.Type == "1")// 体质指数
                            {
                                // 对比体检数值是否正常
                                int res = Compare(houseModel.BMI.ToString(), hs.maxValues, hs.minValues);

                                if (res == 1 || res == 2)
                                {
                                    // 数据类型 返回偏高、低异常信息
                                    HealthOverviewSetModel model = OverViewBll.GetModel(" and Type=1 ");

                                    if (res == 1) // 偏高
                                    {
                                        txtSummary.Text += "体质指数:偏高\r\n";
                                        if (StringPlus.toString(model.MaxEx).Length > 0) txtHealthGuid.Text += "体质指数:" + model.MaxEx + "\r\n";
                                    }
                                    else if (res == 2) // 偏低
                                    {
                                        txtSummary.Text += "体质指数:偏低\r\n";
                                        if (StringPlus.toString(model.MinEx).Length > 0) txtHealthGuid.Text += "体质指数:" + model.MinEx + "\r\n";
                                    }
                                }
                            }
                            else if (hs.Type == "2")// 血压
                            {
                                string[] Hmax = hs.maxValues.Split('/');
                                string[] Hmin = hs.minValues.Split('/');

                                // 数据类型 返回偏高、低异常信息
                                HealthOverviewSetModel model = OverViewBll.GetModel(" and Type=2 ");

                                if (Hmax.Length == 2)  // 高血范围
                                {
                                    if (Compare(houseModel.LeftHeight.ToString(), Hmax[0], Hmax[1]) == 1)
                                    {
                                        txtSummary.Text += "高血压:偏高\r\n";
                                        if (StringPlus.toString(model.MaxEx).Length > 0) txtHealthGuid.Text += "高血压:" + model.MaxEx + "\r\n";
                                    }
                                }
                                if (Hmin.Length == 2)  // 低压范围
                                {
                                    if (Compare(houseModel.LeftPre.ToString(), Hmin[0], Hmin[1]) == 2)
                                    {
                                        txtSummary.Text += "低血压:偏低\r\n";
                                        if (StringPlus.toString(model.MinEx).Length > 0) txtHealthGuid.Text += "低血压:" + model.MinEx + "\r\n";
                                    }
                                }
                            }
                            else if (hs.Type == "3") // 心率
                            {
                                int res = Compare(houseModel.PulseRate.ToString(), hs.maxValues, hs.minValues);
                                if (res == 1 || res == 2)
                                {
                                    // 数据类型 返回偏高、低异常信息
                                    HealthOverviewSetModel model = OverViewBll.GetModel(" and Type=3 ");

                                    if (res == 1) // 偏高
                                    {
                                        txtSummary.Text += "心率:偏高\r\n";
                                        if (StringPlus.toString(model.MaxEx).Length > 0) txtHealthGuid.Text += "心率:" + model.MaxEx + "\r\n";
                                    }
                                    else if (res == 2) // 偏低
                                    {
                                        txtSummary.Text += "心率:偏低\r\n";
                                        if (StringPlus.toString(model.MinEx).Length > 0) txtHealthGuid.Text += "心率:" + model.MinEx + "\r\n";
                                    }
                                }
                            }
                            else if (hs.Type == "4") // 血氧
                            {
                                int res = Compare(houseModel.BloodOxygen.ToString(), hs.maxValues, hs.minValues);
                                if (res == 1 || res == 2)
                                {
                                    // 数据类型 返回偏高、低异常信息
                                    HealthOverviewSetModel model = OverViewBll.GetModel(" and Type=4 ");

                                    if (res == 1) // 偏高
                                    {
                                        txtSummary.Text += "血氧:偏高\r\n";
                                        if (StringPlus.toString(model.MaxEx).Length > 0) txtHealthGuid.Text += "血氧:" + model.MaxEx + "\r\n";
                                    }
                                    else if (res == 2) // 偏低
                                    {
                                        txtSummary.Text += "血氧:偏低\r\n";
                                        if (StringPlus.toString(model.MinEx).Length > 0) txtHealthGuid.Text += "血氧:" + model.MinEx + "\r\n";
                                    }
                                }
                            }

                            #endregion
                        }

                        #region 辅助检查

                        if (houseModel.CHESTX == "2")
                        {
                            txtSummary.Text += "胸部X线片:异常\r\n ";
                            if (StringPlus.toString(houseModel.CHESTXEx).Length > 0) txtHealthGuid.Text += "胸部X线片:" + houseModel.CHESTXEx + "\r\n";
                        }

                        if (!string.IsNullOrEmpty(houseModel.PRO)
                         && !string.IsNullOrEmpty(houseModel.GLU)
                         && !string.IsNullOrEmpty(houseModel.KET)
                         && !string.IsNullOrEmpty(houseModel.BLD))
                        {
                            if (houseModel.PRO.Contains("+")
                               || houseModel.GLU.Contains("+")
                                || houseModel.KET.Contains("+")
                                || houseModel.BLD.Contains("+"))
                            {
                                // 数据类型 返回偏高、低异常信息
                                HealthOverviewSetModel model = OverViewBll.GetModel(" and Type =11 ");

                                txtSummary.Text += "尿常规:异常\r\n";
                                if (StringPlus.toString(model.Content).Length > 0) txtHealthGuid.Text += "尿常规:" + model.Content + "\r\n";
                            }
                        }

                        #endregion

                        #region 心电/B超/心血管/肺功能/骨密度

                        // 心电
                        if (houseModel.ECG == "2")
                        {
                            txtSummary.Text += "心电:异常\r\n";
                            if (StringPlus.toString(houseModel.ECGEx).Length > 0) txtHealthGuid.Text += "心电:" + houseModel.ECGEx + "\r\n";
                        }

                        // B超
                        if (houseModel.BCHAO == "2")
                        {
                            txtSummary.Text += "B超:异常\r\n";
                            if (StringPlus.toString(houseModel.BCHAOEx).Length > 0) txtHealthGuid.Text += "B超:" + houseModel.BCHAOEx + "\r\n";
                        }
                        // B超其他
                        if (houseModel.BCHAOther == "2")
                        {
                            txtSummary.Text += "B超其他:异常\r\n";
                            if (StringPlus.toString(houseModel.BCHAOtherEx).Length > 0) txtHealthGuid.Text += "B超其他:" + houseModel.BCHAOtherEx + "\r\n";
                        }

                        // 心血管
                        if (houseModel.CResult == "2")
                        {
                            txtSummary.Text += "心血管:异常\r\n";
                            if (StringPlus.toString(houseModel.CResultEx).Length > 0) txtHealthGuid.Text += "心血管:" + houseModel.CResultEx + "\r\n";
                        }

                        // 肺功能
                        if (houseModel.LResult == "2")
                        {
                            txtSummary.Text += "肺功能:异常\r\n";
                            if (StringPlus.toString(houseModel.LResultEx).Length > 0) txtHealthGuid.Text += "肺功能:" + houseModel.LResultEx + "\r\n";
                        }

                        // 骨密度
                        if (houseModel.Result == "2")
                        {
                            txtSummary.Text += "骨密度:异常\r\n";
                            if (StringPlus.toString(houseModel.ResultEx).Length > 0) txtHealthGuid.Text += "骨密度:" + houseModel.ResultEx + "\r\n";
                        }

                        #endregion
                    }

                    #endregion

                    #region 中医健康指导

                    HealthHouseMediPhyModel MedModel = new HealthHouseMediPhyBLL().GetModel(houseModel.ID);//中医体质类型
                    if (MedModel != null)
                    {
                        string strMed = "";
                        if (!string.IsNullOrEmpty(MedModel.Mild))
                        {
                            // 平和质 健康指导
                            HealthOverviewSetModel model = OverViewBll.GetModel(" and Type=12 ");

                            if (model != null && !string.IsNullOrEmpty(model.Content))
                            {
                                strMed += "平和质 \r\n" + model.Content;
                            }
                            else
                            {
                                strMed += "平和质 \r\n";
                            }
                        }
                        if (!string.IsNullOrEmpty(MedModel.Faint))
                        {
                            // 气虚质 健康指导
                            HealthOverviewSetModel model = OverViewBll.GetModel(" and Type=13 ");

                            strMed += "气虚质 \r\n";
                        }
                        if (!string.IsNullOrEmpty(MedModel.Yang))
                        {
                            // 阳虚质 健康指导
                            HealthOverviewSetModel model = OverViewBll.GetModel(" and Type=14 ");

                            strMed += "阳虚质 \r\n";
                        }
                        if (!string.IsNullOrEmpty(MedModel.Yin))
                        {
                            // 阴虚质 健康指导
                            HealthOverviewSetModel model = OverViewBll.GetModel(" and Type=15 ");

                            strMed += "阴虚质 \r\n";
                        }
                        if (!string.IsNullOrEmpty(MedModel.PhlegmDamp))
                        {
                            // 痰湿质 健康指导
                            HealthOverviewSetModel model = OverViewBll.GetModel(" and Type=16 ");

                            strMed += "痰湿质 \r\n";
                        }
                        if (!string.IsNullOrEmpty(MedModel.Muggy))
                        {
                            // 湿热质 健康指导
                            HealthOverviewSetModel model = OverViewBll.GetModel(" and Type=17 ");

                            strMed += "湿热质 \r\n";
                        }
                        if (!string.IsNullOrEmpty(MedModel.BloodStasis))
                        {
                            // 血瘀质 健康指导
                            HealthOverviewSetModel model = OverViewBll.GetModel(" and Type=18 ");

                            strMed += "血瘀质 \r\n";
                        }
                        if (!string.IsNullOrEmpty(MedModel.QiConstraint))
                        {
                            // 气郁质 健康指导
                            HealthOverviewSetModel model = OverViewBll.GetModel(" and Type=19 ");

                            strMed += "气郁质 \r\n";
                        }
                        if (!string.IsNullOrEmpty(MedModel.Characteristic))
                        {
                            // 特兼质 健康指导
                            HealthOverviewSetModel model = OverViewBll.GetModel(" and Type=20 ");

                            strMed += "特兼质 \r\n";
                        }
                        if (strMed != "")
                        {
                            this.txtMedGuid.Text = strMed.Remove(strMed.Length - 1, 1);
                        }
                    }

                    #endregion
                }
                else
                {
                    MessageBox.Show("无体检信息，请先做体检！");
                    return;
                }
            }

            this.EveryThingIsOk = true;
        }

        /// 保存
        /// </summary>
        /// <returns></returns>
        public bool SaveModelToDB()
        {
            // 查看体检人是否有健康指导
            if (guideBll.ExistsPID(this.Model.IDCardNo, HealthGuideFactory.PID))
            {
                guideModel.ID = HealthGuideFactory.ID;
                guideModel.Summary = txtSummary.Text;
                guideModel.HealthGuid = txtHealthGuid.Text;
                guideModel.MedGuid = txtMedGuid.Text;
                guideModel.UpdateBy = ConfigHelper.GetNode("doctorName");
                guideModel.UpdateDate = new DateTime?(DateTime.Today);
                guideBll.Update(guideModel);
            }
            else
            {
                guideModel = new HealthHouseGuideModel();
                guideModel.PID = HealthGuideFactory.PID;
                guideModel.IDCardNo = this.Model.IDCardNo;
                guideModel.Summary = txtSummary.Text;
                guideModel.HealthGuid = txtHealthGuid.Text;
                guideModel.MedGuid = txtMedGuid.Text;
                guideModel.CreateBy = ConfigHelper.GetNode("doctorName");
                guideModel.CreateDate = new DateTime?(DateTime.Today);
                guideBll.Insert(guideModel);
            }

            return true;
        }

        /// <summary>
        /// 体检数据值比较
        /// </summary>
        /// <param name="strdate">体检数据</param>
        /// <param name="max">最大值</param>
        /// <param name="min">最小值</param>
        /// <returns>-1:数据为空，0：正常，1:比最大值大，2：比最小值小</returns>
        public int Compare(string strdate, string max, string min)
        {
            if (string.IsNullOrEmpty(strdate))
            {
                return -1;
            }
            if (string.IsNullOrEmpty(max) && string.IsNullOrEmpty(min))
            {
                return -1;
            }
            if (!string.IsNullOrEmpty(max))
            {
                if (Convert.ToDouble(strdate) > Convert.ToDouble(max))
                {
                    return 1;
                }
            }
            if (!string.IsNullOrEmpty(min))
            {
                if (Convert.ToDouble(strdate) < Convert.ToDouble(min))
                {
                    return 2;
                }
            }

            return 0;
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        public void NotisfyChildStatus()
        {
        }

        public void UpdataToModel()
        {

        }
    }
}
