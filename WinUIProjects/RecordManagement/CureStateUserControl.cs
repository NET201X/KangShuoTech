using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace RecordManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.IO;
    using System.Data;
    using System.Runtime.Serialization.Formatters.Binary;
    using KangShuoTech.Utilities.Common;

    public class UCCureState : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private IContainer components;
        private List<DoseUserControl> doses = new List<DoseUserControl>();
        private DoseUserControl doseUC1;
        private DoseUserControl doseUC2;
        private DoseUserControl doseUC3;
        private DoseUserControl doseUC4;
        private DoseUserControl doseUC5;
        private DoseUserControl doseUC6;
        private List<ZhuYuanUserControl> FamZhuyuans;
        private GroupBox groupBox33;
        private GroupBox groupBox35;
        private GroupBox groupBox9;
        private ZhuYuanUserControl homezhuYuan1;
        private ZhuYuanUserControl homezhuYuan2;
        private Label label1;
        private Label label100;
        private Label label101;
        private Label label102;
        private Label label103;
        private Label label104;
        private Label label105;
        private Label label106;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label90;
        private Label label95;
        private Label label96;
        private Label label97;
        private Label label98;
        private List<ZhuYuanUserControl> Perzhuyuans;
        private ZhuYuanUserControl zhuYuan1;
        private LinkLabel linkLabel1;
        private Label label5;
        private ZhuYuanUserControl zhuYuan2;
        private DataSet dsRequire;
        private string community = ConfigHelper.GetSetNode("community");
        private string area = ConfigHelper.GetSetNode("area");

        public UCCureState()
        {
            this.InitializeComponent();
            this.doses.Add(this.doseUC1);
            this.doses.Add(this.doseUC2);
            this.doses.Add(this.doseUC3);
            this.doses.Add(this.doseUC4);
            this.doses.Add(this.doseUC5);
            this.doses.Add(this.doseUC6);
            this.EveryThingIsOk = false;
        }

        public ChildFormStatus CheckErrorInput()
        {
            if (((this.doses.Count<DoseUserControl>(c => c.ErrorInput) <= 0) && (this.Perzhuyuans.Count<ZhuYuanUserControl>(c => c.ErrorInput) <= 0)) && (this.FamZhuyuans.Count<ZhuYuanUserControl>(c => c.ErrorInput) <= 0))
            {
                return ChildFormStatus.NoErrorInput;
            }
            return ChildFormStatus.HasErrorInput;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void InitEveryThing()
        {
            dsRequire = new RequireBLL().GetList("TabName = '健康体检' AND Comment = '治疗情况' ");
            this.HospitalHistory = new RecordsHospitalHistoryBLL().GetModelList(string.Format("IDCardNo = '{0}' and OutKey={1}", this.Model.IDCardNo, PhysicalInfoFactory.ID));
            this.FamilyBedHistoryInfo = new RecordsFamilyBedHistoryBLL().GetModelList(string.Format("IDCardNo = '{0}' and OutKey={1}", this.Model.IDCardNo, PhysicalInfoFactory.ID));
            
            
                this.Medication = new RecordsMedicationBLL().GetModelList(string.Format("IDCardNo = '{0}' and OutKey={1}", this.Model.IDCardNo, PhysicalInfoFactory.ID));
            this.Perzhuyuans = new List<ZhuYuanUserControl> { this.zhuYuan1, this.zhuYuan2 };
            this.FamZhuyuans = new List<ZhuYuanUserControl> { this.homezhuYuan1, this.homezhuYuan2 };
            //新增体检时，从设备中读取的栏位设置为空
            if (PhysicalInfoFactory.falgID == 0)
            {
                if (area.Equals("威海"))
                {
                    this.Medication = new List<RecordsMedicationModel>();
                }
                    this.PresetValue();
                if (community.Equals("平度云山医院")||area.Equals("威海"))//平度云山医院、威海,从高血压，糖尿病随访中获取用药
                {
                    string strYear = DateTime.Now.Year.ToString();
                    string strHypeWhere = string.Format("  Left(FollowUpDate,4)='{0}' and IDCardNo='{1}' order by FollowUpDate desc  ", strYear,this.Model.IDCardNo);
                    List < ChronicHypertensionVisitModel > HyperModellist=  new ChronicHypertensionVisitBLL().GetModelList(strHypeWhere);
                    if (HyperModellist.Count > 0)
                    {
                        List < ChronicDrugConditionModel > DrugConditions= new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' and type = '{1}' and OUTKey = '{2}' ", HyperModellist[0].IDCardNo, "1", HyperModellist[0].ID));
                        foreach(ChronicDrugConditionModel drugmodel in DrugConditions)
                        {
                            RecordsMedicationModel newModel = new RecordsMedicationModel
                            {
                                MedicinalName = drugmodel.Name,
                                UseNum = drugmodel.DosAge,
                                IDCardNo=this.Model.IDCardNo
                            };
                            this.Medication.Add(newModel);
                        }
                    }
                    string strDiaWhere = string.Format(" Left(VisitDate,4)='{0}'and IDCardNo='{1}' order by VisitDate desc  ", strYear,this.Model.IDCardNo);
                    List < ChronicDiadetesVisitModel > DiamodelList= new ChronicDiadetesVisitBLL().GetModelList(strDiaWhere);
                    if (DiamodelList.Count > 0)
                    {
                        List<ChronicDrugConditionModel> DiaDrugConditions = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' and type = '{1}' and OUTKey = '{2}' ", DiamodelList[0].IDCardNo, "2", DiamodelList[0].ID));
                        foreach (ChronicDrugConditionModel drugmodel in DiaDrugConditions)
                        {
                            RecordsMedicationModel newModel = new RecordsMedicationModel
                            {
                                MedicinalName = drugmodel.Name,
                                UseNum = drugmodel.DosAge,
                                IDCardNo = this.Model.IDCardNo
                            };
                            this.Medication.Add(newModel);
                        }
                    }
                }
            }
            for (int i = 0; i < this.HospitalHistory.Count; i++)
            {
                this.Perzhuyuans[i].PerSource = this.HospitalHistory[i];
            }
            for (int j = 0; j < this.FamilyBedHistoryInfo.Count; j++)
            {
                this.FamZhuyuans[j].FamSource = this.FamilyBedHistoryInfo[j];
            }
            if (this.FamilyBedHistoryInfo.Count > 0)
            {
                this.homezhuYuan1.FamSource = this.FamilyBedHistoryInfo[0];
                if (this.FamilyBedHistoryInfo.Count == 2)
                {
                    this.homezhuYuan2.FamSource = this.FamilyBedHistoryInfo[1];
                }
            }

            //读取用药情况
            if (File.Exists(Application.StartupPath + "\\dose.xml"))
            {
                DataSet ds = new DataSet();

                ds.ReadXml(Application.StartupPath + "\\dose.xml");
                DataTable dt_yw = ds.Tables[0];
                doseUC1.setSource(dt_yw);
                doseUC2.setSource(DeepCopy(dt_yw));
                doseUC3.setSource(DeepCopy(dt_yw));
                doseUC4.setSource(DeepCopy(dt_yw));
                doseUC5.setSource(DeepCopy(dt_yw));
                doseUC6.setSource(DeepCopy(dt_yw));
            }

            for (int k = 0; k < this.doses.Count; k++)
            {
                if (k < this.Medication.Count)
                {
                    this.doses[k].Source = this.Medication[k];
                }
                else
                {
                    RecordsMedicationModel recordsMedicationModel = new RecordsMedicationModel
                    {
                        IDCardNo = this.Model.IDCardNo,
                        ModelState = RecordsStateModel.NoValue
                    };
                    this.doses[k].Source = recordsMedicationModel;
                }
            }
            this.EveryThingIsOk = true;
            MustChoose();
        }
        //默认项设置
        private void PresetValue()
        {
            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = " IsSetValue='是' or IsSetValue='预设上次体检' ";
            DataTable dt = dv.ToTable();
            RecordsCustomerBaseInfoModel CustomerBaseInfos = new RecordsCustomerBaseInfoBLL().GetMaxModel(this.Model.IDCardNo);//获取最新一笔体检数据
            List<RecordsHospitalHistoryModel> HospitalHistoryTemp = new List<RecordsHospitalHistoryModel>();
            List<RecordsFamilyBedHistoryModel> FamilyBedHistoryInfoTemp = new List<RecordsFamilyBedHistoryModel>();
            List<RecordsMedicationModel> MedicationTemp = new List<RecordsMedicationModel>();
            if (CustomerBaseInfos != null)
            {
                HospitalHistoryTemp = new RecordsHospitalHistoryBLL().GetModelList(string.Format("IDCardNo = '{0}' and OutKey={1}", this.Model.IDCardNo, CustomerBaseInfos.ID));
                FamilyBedHistoryInfoTemp = new RecordsFamilyBedHistoryBLL().GetModelList(string.Format("IDCardNo = '{0}' and OutKey={1}", this.Model.IDCardNo, CustomerBaseInfos.ID));
                MedicationTemp = new RecordsMedicationBLL().GetModelList(string.Format("IDCardNo = '{0}' and OutKey={1}", this.Model.IDCardNo, CustomerBaseInfos.ID));
            }

            foreach (DataRow item in dt.Rows)
            {
                switch (item["ChinName"].ToString())
                {
                    case "住院史":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                string[] reslist = item["ItemValue"].ToString().Split(';');
                                RecordsHospitalHistoryModel hModel = new RecordsHospitalHistoryModel();
                                hModel.InHospitalDate = Convert.ToDateTime(reslist[0].ToString());
                                hModel.OutHospitalDate = Convert.ToDateTime(reslist[1].ToString());
                                hModel.Reason = reslist[2].ToString();
                                hModel.HospitalName = reslist[3].ToString();
                                hModel.IllcaseNum = reslist[4].ToString();
                                this.HospitalHistory.Add(hModel);
                            }
                        }
                        else
                        {
                            this.HospitalHistory = HospitalHistoryTemp;
                        }
                        break;
                    case "家庭病床史":
                        if (item["IsSetValue"].ToString() == "预设上次体检")
                        {
                            this.FamilyBedHistoryInfo = FamilyBedHistoryInfoTemp;
                        }
                        break;
                    case "用药情况":
                        if (item["IsSetValue"].ToString() == "预设上次体检"&&!community.Equals("平度云山医院"))
                        {
                            this.Medication = MedicationTemp;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        private void MustChoose()
        {
            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = "IsRequired='1' ";
            DataTable dt = dv.ToTable();
            List<RecordsHospitalHistoryModel> HospitalHistoryTemp = new RecordsHospitalHistoryBLL().GetModelList(string.Format("IDCardNo = '{0}' and OutKey={1}", this.Model.IDCardNo, PhysicalInfoFactory.ID));
            List<RecordsFamilyBedHistoryModel> FamilyBedHistoryInfoTemp = new RecordsFamilyBedHistoryBLL().GetModelList(string.Format("IDCardNo = '{0}' and OutKey={1}", this.Model.IDCardNo, PhysicalInfoFactory.ID));
            List<RecordsMedicationModel> MedicationTem = new RecordsMedicationBLL().GetModelList(string.Format("IDCardNo = '{0}' and OutKey={1}", this.Model.IDCardNo, PhysicalInfoFactory.ID));
            foreach (DataRow item in dt.Rows)
            {
                if (item["Isrequired"].ToString() == "1")
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "住院史":
                            if (HospitalHistoryTemp == null || HospitalHistoryTemp.Count == 0)
                            {
                                this.groupBox33.Text = "*住院史";
                                this.groupBox33.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.groupBox33.Text = "住院史";
                                this.groupBox33.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "家庭病床史":
                            if (FamilyBedHistoryInfoTemp == null || FamilyBedHistoryInfoTemp.Count == 0)
                            {
                                this.groupBox35.Text = "*家庭病床史";
                                this.groupBox35.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.groupBox35.Text = "家庭病床史";
                                this.groupBox35.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "用药情况":
                            if (MedicationTem == null || MedicationTem.Count == 0)
                            {
                                this.groupBox9.Text = "*用药情况";
                                this.groupBox9.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.groupBox9.Text = "用药情况";
                                this.groupBox9.ForeColor = System.Drawing.Color.Black;
                            }
                            break;


                        default: break;
                    }
                }
            }
        }
        public T DeepCopy<T>(T mo)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, mo);
            stream.Position = 0;

            return (T)formatter.Deserialize(stream);
        }

        private void InitializeComponent()
        {
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.homezhuYuan2 = new KangShuoTech.Utilities.CommonControl.ZhuYuanUserControl();
            this.label4 = new System.Windows.Forms.Label();
            this.homezhuYuan1 = new KangShuoTech.Utilities.CommonControl.ZhuYuanUserControl();
            this.label98 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.zhuYuan2 = new KangShuoTech.Utilities.CommonControl.ZhuYuanUserControl();
            this.zhuYuan1 = new KangShuoTech.Utilities.CommonControl.ZhuYuanUserControl();
            this.label97 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.doseUC6 = new KangShuoTech.Utilities.CommonControl.DoseUserControl();
            this.doseUC5 = new KangShuoTech.Utilities.CommonControl.DoseUserControl();
            this.doseUC4 = new KangShuoTech.Utilities.CommonControl.DoseUserControl();
            this.doseUC3 = new KangShuoTech.Utilities.CommonControl.DoseUserControl();
            this.doseUC2 = new KangShuoTech.Utilities.CommonControl.DoseUserControl();
            this.doseUC1 = new KangShuoTech.Utilities.CommonControl.DoseUserControl();
            this.label106 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox35.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox35
            // 
            this.groupBox35.Controls.Add(this.label3);
            this.groupBox35.Controls.Add(this.homezhuYuan2);
            this.groupBox35.Controls.Add(this.label4);
            this.groupBox35.Controls.Add(this.homezhuYuan1);
            this.groupBox35.Controls.Add(this.label98);
            this.groupBox35.Controls.Add(this.label100);
            this.groupBox35.Controls.Add(this.label101);
            this.groupBox35.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox35.Location = new System.Drawing.Point(115, 155);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(1298, 140);
            this.groupBox35.TabIndex = 1;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "家庭病床史";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(762, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "(必填*)";
            // 
            // homezhuYuan2
            // 
            this.homezhuYuan2.ErrorInput = false;
            this.homezhuYuan2.Font = new System.Drawing.Font("宋体", 12F);
            this.homezhuYuan2.Location = new System.Drawing.Point(8, 88);
            this.homezhuYuan2.Margin = new System.Windows.Forms.Padding(5);
            this.homezhuYuan2.Name = "homezhuYuan2";
            this.homezhuYuan2.Size = new System.Drawing.Size(1079, 43);
            this.homezhuYuan2.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(632, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "医疗机构名称";
            // 
            // homezhuYuan1
            // 
            this.homezhuYuan1.ErrorInput = false;
            this.homezhuYuan1.Font = new System.Drawing.Font("宋体", 12F);
            this.homezhuYuan1.Location = new System.Drawing.Point(8, 51);
            this.homezhuYuan1.Margin = new System.Windows.Forms.Padding(5);
            this.homezhuYuan1.Name = "homezhuYuan1";
            this.homezhuYuan1.Size = new System.Drawing.Size(1079, 43);
            this.homezhuYuan1.TabIndex = 17;
            this.homezhuYuan1.Load += new System.EventHandler(this.homezhuYuan1_Load);
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(885, 26);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(69, 20);
            this.label98.TabIndex = 0;
            this.label98.Text = "病案号";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(390, 30);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(49, 20);
            this.label100.TabIndex = 0;
            this.label100.Text = "原因";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(28, 26);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(119, 20);
            this.label101.TabIndex = 0;
            this.label101.Text = "建/撤床时间";
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.label2);
            this.groupBox33.Controls.Add(this.zhuYuan2);
            this.groupBox33.Controls.Add(this.zhuYuan1);
            this.groupBox33.Controls.Add(this.label97);
            this.groupBox33.Controls.Add(this.label96);
            this.groupBox33.Controls.Add(this.label95);
            this.groupBox33.Controls.Add(this.label90);
            this.groupBox33.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox33.Location = new System.Drawing.Point(115, 21);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(1298, 128);
            this.groupBox33.TabIndex = 0;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "住院史";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(765, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "(必填*)";
            // 
            // zhuYuan2
            // 
            this.zhuYuan2.ErrorInput = false;
            this.zhuYuan2.Font = new System.Drawing.Font("宋体", 12F);
            this.zhuYuan2.Location = new System.Drawing.Point(7, 80);
            this.zhuYuan2.Margin = new System.Windows.Forms.Padding(5);
            this.zhuYuan2.Name = "zhuYuan2";
            this.zhuYuan2.Size = new System.Drawing.Size(1079, 43);
            this.zhuYuan2.TabIndex = 16;
            // 
            // zhuYuan1
            // 
            this.zhuYuan1.ErrorInput = false;
            this.zhuYuan1.Font = new System.Drawing.Font("宋体", 12F);
            this.zhuYuan1.Location = new System.Drawing.Point(7, 43);
            this.zhuYuan1.Margin = new System.Windows.Forms.Padding(5);
            this.zhuYuan1.Name = "zhuYuan1";
            this.zhuYuan1.Size = new System.Drawing.Size(1079, 43);
            this.zhuYuan1.TabIndex = 15;
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(856, 20);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(69, 20);
            this.label97.TabIndex = 0;
            this.label97.Text = "病案号";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(632, 18);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(129, 20);
            this.label96.TabIndex = 0;
            this.label96.Text = "医疗机构名称";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(390, 22);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(49, 20);
            this.label95.TabIndex = 0;
            this.label95.Text = "原因";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(28, 22);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(119, 20);
            this.label90.TabIndex = 0;
            this.label90.Text = "入/出院时间";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label1);
            this.groupBox9.Controls.Add(this.doseUC6);
            this.groupBox9.Controls.Add(this.doseUC5);
            this.groupBox9.Controls.Add(this.doseUC4);
            this.groupBox9.Controls.Add(this.doseUC3);
            this.groupBox9.Controls.Add(this.doseUC2);
            this.groupBox9.Controls.Add(this.doseUC1);
            this.groupBox9.Controls.Add(this.label106);
            this.groupBox9.Controls.Add(this.label102);
            this.groupBox9.Controls.Add(this.label103);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.label104);
            this.groupBox9.Controls.Add(this.label105);
            this.groupBox9.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox9.Location = new System.Drawing.Point(114, 301);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1299, 294);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "用药情况";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(124, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 51;
            this.label1.Text = "(必填*)";
            // 
            // doseUC6
            // 
            this.doseUC6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doseUC6.Location = new System.Drawing.Point(13, 237);
            this.doseUC6.Margin = new System.Windows.Forms.Padding(14);
            this.doseUC6.Name = "doseUC6";
            this.doseUC6.Size = new System.Drawing.Size(1267, 40);
            this.doseUC6.source = null;
            this.doseUC6.TabIndex = 50;
            // 
            // doseUC5
            // 
            this.doseUC5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doseUC5.Location = new System.Drawing.Point(13, 198);
            this.doseUC5.Margin = new System.Windows.Forms.Padding(10);
            this.doseUC5.Name = "doseUC5";
            this.doseUC5.Size = new System.Drawing.Size(1267, 35);
            this.doseUC5.source = null;
            this.doseUC5.TabIndex = 49;
            // 
            // doseUC4
            // 
            this.doseUC4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doseUC4.Location = new System.Drawing.Point(13, 163);
            this.doseUC4.Margin = new System.Windows.Forms.Padding(8);
            this.doseUC4.Name = "doseUC4";
            this.doseUC4.Size = new System.Drawing.Size(1267, 35);
            this.doseUC4.source = null;
            this.doseUC4.TabIndex = 48;
            // 
            // doseUC3
            // 
            this.doseUC3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doseUC3.Location = new System.Drawing.Point(13, 128);
            this.doseUC3.Margin = new System.Windows.Forms.Padding(8);
            this.doseUC3.Name = "doseUC3";
            this.doseUC3.Size = new System.Drawing.Size(1267, 35);
            this.doseUC3.source = null;
            this.doseUC3.TabIndex = 47;
            // 
            // doseUC2
            // 
            this.doseUC2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doseUC2.Location = new System.Drawing.Point(13, 93);
            this.doseUC2.Margin = new System.Windows.Forms.Padding(6);
            this.doseUC2.Name = "doseUC2";
            this.doseUC2.Size = new System.Drawing.Size(1267, 35);
            this.doseUC2.source = null;
            this.doseUC2.TabIndex = 46;
            // 
            // doseUC1
            // 
            this.doseUC1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doseUC1.Location = new System.Drawing.Point(13, 58);
            this.doseUC1.Margin = new System.Windows.Forms.Padding(5);
            this.doseUC1.Name = "doseUC1";
            this.doseUC1.Size = new System.Drawing.Size(1278, 35);
            this.doseUC1.source = null;
            this.doseUC1.TabIndex = 45;
            this.doseUC1.Load += new System.EventHandler(this.doseUC1_Load);
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label106.Location = new System.Drawing.Point(994, 30);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(299, 20);
            this.label106.TabIndex = 5;
            this.label106.Text = "服药依从性(1规律2间断3不服药)";
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label102.Location = new System.Drawing.Point(858, 31);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(89, 20);
            this.label102.TabIndex = 3;
            this.label102.Text = "用药时间";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label103.Location = new System.Drawing.Point(357, 31);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(49, 20);
            this.label103.TabIndex = 4;
            this.label103.Text = "用量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(718, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "剂型";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label104.Location = new System.Drawing.Point(231, 29);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(49, 20);
            this.label104.TabIndex = 1;
            this.label104.Text = "用法";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label105.Location = new System.Drawing.Point(29, 31);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(89, 20);
            this.label105.TabIndex = 2;
            this.label105.Text = "药物名称";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.Location = new System.Drawing.Point(1309, 626);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(104, 19);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "编辑常用药";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // UCCureState
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1460, 680);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox35);
            this.Controls.Add(this.groupBox33);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "UCCureState";
            this.Load += new System.EventHandler(this.UCCureState_Load);
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            this.groupBox33.ResumeLayout(false);
            this.groupBox33.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void NotisfyChildStatus()
        {
            throw new NotImplementedException();
        }

        private void SaveFamBedHistory()
        {
            RecordsFamilyBedHistoryBLL recordsFamilyBedHistoryBLL = new RecordsFamilyBedHistoryBLL();
            recordsFamilyBedHistoryBLL.DeleteByOutKey(PhysicalInfoFactory.ID);

            if (this.FamilyBedHistoryInfo != null)
            {
                foreach (RecordsFamilyBedHistoryModel recordsFamilyBedHistoryModel in this.FamilyBedHistoryInfo)
                {
                    if (recordsFamilyBedHistoryModel.ModelState != RecordsStateModel.DeleteInDB)
                    {
                        recordsFamilyBedHistoryModel.OutKey = PhysicalInfoFactory.ID;
                        recordsFamilyBedHistoryBLL.Add(recordsFamilyBedHistoryModel);
                    }
                }
            }

        }

        private void SaveHospitalHistory()
        {
            RecordsHospitalHistoryBLL recordsHospitalHistoryBLL = new RecordsHospitalHistoryBLL();
            recordsHospitalHistoryBLL.DeleteByOutKey(PhysicalInfoFactory.ID);

            if (this.HospitalHistory != null)
            {
                for (int i = 0; i < this.HospitalHistory.Count; i++)
                {
                    if (this.HospitalHistory[i].ModelState != RecordsStateModel.DeleteInDB)
                    {
                        this.HospitalHistory[i].OutKey = PhysicalInfoFactory.ID;
                        recordsHospitalHistoryBLL.Add(this.HospitalHistory[i]);
                    }
                }
            }
        }

        private void SaveMedication()
        {
            RecordsMedicationBLL rcordsMedicationBLL = new RecordsMedicationBLL();
            rcordsMedicationBLL.DeleteByOutKey(PhysicalInfoFactory.ID);
            foreach (RecordsMedicationModel recordsMedicationModel in this.Medication)
            {
                if (recordsMedicationModel.ModelState != RecordsStateModel.DeleteInDB)
                {
                    recordsMedicationModel.OutKey = PhysicalInfoFactory.ID;
                    rcordsMedicationBLL.Add(recordsMedicationModel);
                }
            }
        }

        public bool SaveModelToDB()
        {
            if (PhysicalInfoFactory.ID != -1)
            {
                this.SaveHospitalHistory();
                this.SaveFamBedHistory();
                this.SaveMedication();
            }
            return true;
        }

        private void UCCureState_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        public void UpdataToModel()
        {
            for (int i = 0; i < this.Perzhuyuans.Count; i++)
            {
                this.Perzhuyuans[i].UpdatePer(this.Model.IDCardNo);
                if (this.Perzhuyuans[i].PerSource.ModelState == RecordsStateModel.AddToDB)
                {
                    this.HospitalHistory.Add(this.Perzhuyuans[i].PerSource);
                }
            }
            for (int j = 0; j < this.FamZhuyuans.Count; j++)
            {
                this.FamZhuyuans[j].UpdateFam(this.Model.IDCardNo);
                if (this.FamZhuyuans[j].FamSource.ModelState == RecordsStateModel.AddToDB)
                {
                    this.FamilyBedHistoryInfo.Add(this.FamZhuyuans[j].FamSource);
                }
            }
            for (int k = 0; k < this.doses.Count; k++)
            {
                this.doses[k].UpdateSource();
                if (this.doses[k].Source.ModelState == RecordsStateModel.AddToDB)
                {
                    this.Medication.Add(this.doses[k].Source);
                }
            }
        }

        public bool EveryThingIsOk { get; set; }

        public List<RecordsFamilyBedHistoryModel> FamilyBedHistoryInfo { get; set; }

        public bool HaveToSave { get; set; }

        public List<RecordsHospitalHistoryModel> HospitalHistory { get; set; }

        public List<RecordsMedicationModel> Medication { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoseForm f = new DoseForm();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void doseUC1_Load(object sender, EventArgs e)
        {

        }

        private void homezhuYuan1_Load(object sender, EventArgs e)
        {

        }
    }
}

