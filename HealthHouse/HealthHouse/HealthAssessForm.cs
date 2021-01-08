using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.Utilities.Common;

namespace HealthHouse
{
    public partial class HealthAssessForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private HealthHouseBLL healthHouseBLL = new HealthHouseBLL();
        private HealthAssessModel AssessModel { get; set; }

        public HealthAssessForm()
        {
            InitializeComponent();
            SetEmpty();
            this.EveryThingIsOk = false;
        }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        /// <summary>
        /// 将栏位空间清空
        /// </summary>
        private void SetEmpty()
        {
            this.lbBchao.Text = "";
            this.lbBMI.Text = "";
            this.lbBone.Text = "";
            this.lbEcg.Text = "";
            this.lbLung.Text = "";
            this.lbMed.Text = "";
            this.lbniao.Text = "";
            this.lbVascular.Text = "";
            this.lbxinlv.Text = "";
            this.lbXiongBu.Text = "";
            this.lbXueYa.Text = "";
            this.lbxueyang.Text = "";

        }

        /// <summary>
        /// 数据值比较
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

        public void InitEveryThing()
        {
            HealthHouseModel houseModel = new HealthHouseModel();

            if (HealthAssessFactory.ID == 0)//新增时
            {
                houseModel = healthHouseBLL.GetMaxData(this.Model.IDCardNo);
                HealthAssessFactory.ID = houseModel.ID;
            }
            else //查询时
            {
                houseModel = healthHouseBLL.GetDataByID(HealthAssessFactory.ID);
            }

            this.AssessModel = new HealthAssessModel { IDCardNo = this.Model.IDCardNo };
            List<HealthOverviewSetModel> SetList = new List<HealthOverviewSetModel>();
            SetList = new HealthOverviewSetBLL().GetList(" and Type in (1,2,3,4) ");

            if (houseModel != null)
            {
                HealthAssessFactory.ID = houseModel.ID;
                this.AssessModel.PID = houseModel.ID;
                this.AssessModel.CheckDate = houseModel.CheckDate;

                this.lbBMI.Text = houseModel.BMI.ToString();//体质指数
                this.lbXueYa.Text = "收缩压:" + houseModel.LeftHeight.ToString();
                this.lbxinlv.Text = houseModel.PulseRate.ToString();//心率
                this.lbxueyang.Text = houseModel.BloodOxygen.ToString();//血氧

                if (SetList == null)
                {
                    this.AssessModel.BasicTest = "";
                    this.AssessModel.Blood = "";
                    this.AssessModel.PulseRate = "";
                    this.AssessModel.Oxygen = "";
                    this.AssessModel.Urine = "";
                }
                else
                {
                    foreach (HealthOverviewSetModel hs in SetList)
                    {
                        if (hs.Type == "1")//体质指数
                        {
                            this.lbBMI.Text += "  参考范围：" + hs.minValues + " ~ " + hs.maxValues;
                            int res = Compare(houseModel.BMI.ToString(), hs.maxValues, hs.minValues);
                            if (res == 2 || res == 1)
                            {
                                this.lbBMI.ForeColor = Color.Red;
                            }
                        }
                        else if (hs.Type == "2")//血压
                        {
                            string[] Hmax = hs.maxValues.Split('/');
                            string[] Hmin = hs.minValues.Split('/');
                            bool flag = false;

                            if (Hmax.Length == 2)
                            {
                                this.lbXueYa.Text += "  参考范围:" + Hmax[0] + " ~  " + Hmax[1];
                                if (Compare(houseModel.LeftHeight.ToString(), Hmax[0], Hmax[1]) == 1)
                                {
                                    this.lbXueYa.ForeColor = Color.Red;
                                }
                            }
                            this.lbXueYa.Text += "    舒张压:" + houseModel.LeftPre.ToString() + "   ";
                            if (Hmin.Length == 2)
                            {
                                this.lbXueYa.Text += "  参考范围:" + Hmin[0] + " ~  " + Hmin[1];
                                if (Compare(houseModel.LeftPre.ToString(), Hmin[0], Hmin[1]) == 2)
                                {
                                    this.lbXueYa.ForeColor = Color.Red;
                                }
                            }
                        }
                        else if (hs.Type == "3")//心率
                        {
                            this.lbxinlv.Text += "  参考范围:" + hs.maxValues + " ~  " + hs.minValues;
                            int res = Compare(houseModel.PulseRate.ToString(), hs.maxValues, hs.minValues);
                            if (res == 2 || res == 1)
                            {
                                this.lbxinlv.ForeColor = Color.Red;
                            }
                        }
                        else if (hs.Type == "4")//血氧
                        {
                            this.lbxueyang.Text += "  参考范围:" + hs.maxValues + " ~  " + hs.minValues;
                            int res = Compare(houseModel.BloodOxygen.ToString(), hs.maxValues, hs.minValues);

                            if (res == 2 || res == 1)
                            {
                                this.lbxueyang.ForeColor = Color.Red;
                                this.AssessModel.Oxygen = "偏低";
                            }
                        }
                    }
                }
                HealthHousePhysicalAssistCheckModel HHAssistCheck = new HealthHousePhysicalAssistCheckBLL().GetModel(houseModel.ID);//辅助检查表
                if (HHAssistCheck != null)
                {
                    if (HHAssistCheck.CHESTX == "1")
                    {
                        this.lbXiongBu.Text = "正常";
                    }
                    else if (HHAssistCheck.CHESTX == "2")
                    {
                        this.lbXiongBu.ForeColor = Color.Red;
                        this.lbXiongBu.Text = "异常";
                    }
                    if (!string.IsNullOrEmpty(HHAssistCheck.PRO)
                     && !string.IsNullOrEmpty(HHAssistCheck.GLU)
                     && !string.IsNullOrEmpty(HHAssistCheck.KET)
                     && !string.IsNullOrEmpty(HHAssistCheck.BLD))
                    {
                        if (HHAssistCheck.PRO.Contains("+")
                        || HHAssistCheck.GLU.Contains("+")
                         || HHAssistCheck.KET.Contains("+")
                         || HHAssistCheck.BLD.Contains("+"))
                        {
                            this.lbniao.ForeColor = Color.Red;
                            this.lbniao.Text = "异常";
                        }
                        else
                        {
                            this.lbniao.Text = "正常";
                        }
                    }
                }
                HealthHouseBCHAOModel BchaoModel = new HealthHouseBCHAOBLL().GetModel(houseModel.ID);//B超表
                if (BchaoModel != null)
                {
                    if (BchaoModel.BCHAO == "1")
                    {
                        this.lbBchao.Text = "正常";
                    }
                    else if (BchaoModel.BCHAO == "2")
                    {
                        this.lbBchao.ForeColor = Color.Red;
                        this.lbBchao.Text = "异常";
                    }
                }
                HealthHouseEcgModel EcgModel = new HealthHouseEcgBLL().GetModel(houseModel.ID);//心电
                if (EcgModel != null)
                {
                    if (EcgModel.ECG == "1")
                    {
                        this.lbEcg.Text = "正常";
                    }
                    else if (EcgModel.ECG == "2")
                    {
                        this.lbEcg.ForeColor = Color.Red;
                        this.lbEcg.Text = "异常";
                    }
                }
                HHCardiovascularModel VascularModel = new HHCardiovascularBLL().GetData(this.Model.IDCardNo, houseModel.ID);//心血管
                if (VascularModel != null)
                {
                    if (VascularModel.Result == "1")
                    {
                        this.lbVascular.Text = "正常";
                    }
                    else if (VascularModel.Result == "2")
                    {
                        this.lbVascular.ForeColor = Color.Red;
                        this.lbVascular.Text = "异常";
                    }
                }
                HHBoneModel BoneModel = new HHBoneBLL().GetData(this.Model.IDCardNo, houseModel.ID);//骨密度
                if (BoneModel != null)
                {
                    if (BoneModel.Result == "1")
                    {
                        this.lbBone.Text = "正常";
                    }
                    else if (BoneModel.Result == "2")
                    {
                        this.lbBone.ForeColor = Color.Red;
                        this.lbBone.Text = "异常";
                    }
                }
                HHLungModel LungModel = new HHLungBLL().GetData(this.Model.IDCardNo, houseModel.ID);//肺功能
                if (LungModel != null)
                {
                    if (LungModel.Result == "1")
                    {
                        this.lbLung.Text = "正常";
                    }
                    else if (LungModel.Result == "2")
                    {
                        this.lbLung.ForeColor = Color.Red;
                        this.lbLung.Text = "异常";
                    }
                }
                HealthHouseMediPhyModel MedModel = new HealthHouseMediPhyBLL().GetModel(houseModel.ID);//中医体质类型
                if (MedModel != null)
                {
                    string strMed = "";
                    if (!string.IsNullOrEmpty(MedModel.Mild))
                    {
                        strMed += "平和质,";
                    }
                    if (!string.IsNullOrEmpty(MedModel.Faint))
                    {
                        strMed += "气虚质,";
                    }
                    if (!string.IsNullOrEmpty(MedModel.Yang))
                    {
                        strMed += "阳虚质,";
                    }
                    if (!string.IsNullOrEmpty(MedModel.Yin))
                    {
                        strMed += "阴虚质,";
                    }
                    if (!string.IsNullOrEmpty(MedModel.PhlegmDamp))
                    {
                        strMed += "痰湿质,";
                    }
                    if (!string.IsNullOrEmpty(MedModel.Muggy))
                    {
                        strMed += "湿热质,";
                    }
                    if (!string.IsNullOrEmpty(MedModel.BloodStasis))
                    {
                        strMed += "血瘀质,";
                    }
                    if (!string.IsNullOrEmpty(MedModel.QiConstraint))
                    {
                        strMed += "气郁质,";
                    }
                    if (!string.IsNullOrEmpty(MedModel.Characteristic))
                    {
                        strMed += "特兼质,";
                    }
                    if (strMed != "")
                    {
                        this.lbMed.Text = strMed.Remove(strMed.Length - 1, 1);
                    }
                }
            }
            else
            {
                MessageBox.Show("无体检信息，请先做体检！");
                return;
            }
            //SimpleBinding(this.lbBMI, "BasicTest");
            //SimpleBinding(this.lbData, "CheckDate");
            //SimpleBinding(this.lbXueYa, "Blood");
            //SimpleBinding(this.lbBchao, "BSuper");
            //SimpleBinding(this.lbXiongBu, "ChestX");
            //SimpleBinding(this.lbEcg, "ECG");
            //SimpleBinding(this.lbVascular, "Cardiovascular");
            //SimpleBinding(this.lbBone, "Bone");
            //SimpleBinding(this.lbLung, "Lung");
            //SimpleBinding(this.lbMed, "TCMConstitution");
            //SimpleBinding(this.lbxinlv, "PulseRate");
            //SimpleBinding(this.lbxueyang, "Oxygen");
            //SimpleBinding(this.lbniao, "Urine");
            this.EveryThingIsOk = true;
        }

        private void SimpleBinding(Label lb, string srcMember)
        {
            lb.ImeMode = ImeMode.Disable;
            Binding binding = new Binding("Text", this.AssessModel, srcMember, true, DataSourceUpdateMode.OnPropertyChanged);
            lb.DataBindings.Add(binding);

        }

        public bool SaveModelToDB()
        {

            //HealthAssessBLL AssessBll = new HealthAssessBLL();
            //HealthAssessModel AssessTem = AssessBll.GetModel(this.AssessModel.PID);
            //if (AssessTem!=null)
            //{
            //    this.AssessModel.ID = AssessTem.ID;
            //    AssessBll.Update(this.AssessModel);
            //}
            //else
            //{
            //    AssessBll.Add(this.AssessModel);
            //}
            return true;
        }

        public void NotisfyChildStatus()
        {
        }

        public void UpdataToModel()
        {
            this.AssessModel.CreateDate = this.Model.CreateDate;
            this.AssessModel.CreateBy = this.Model.CreateBy;
            this.AssessModel.UpdataBy = ConfigHelper.GetNode("doctorName");
            this.AssessModel.UpdateDate = new DateTime?(DateTime.Today);
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        private void HealthAssessForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void lkSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HealthAssessSetExForm hf = new HealthAssessSetExForm();
            hf.ShowDialog();
        }

        private void lkHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HistoryData his = new HistoryData(this.Model);
            his.ShowDialog();
        }
    }
}
