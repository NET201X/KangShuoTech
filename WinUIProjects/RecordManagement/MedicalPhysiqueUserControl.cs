using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace ArchiveInfo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.IO;
    using System.Data;

    public class UCMedicalPhysique : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private Button btnElderM;
        private Button btnReset;
        private ComboBox cmbkouchun;
        private ComboBox cmbyanbu;
        private IContainer components;
        private GroupBox groupBox4;
        private GroupBox groupBox44;
        private GroupBox groupBox47;
        private GroupBox groupBox48;
        private GroupBox groupBox49;
        private GroupBox groupBox50;
        private GroupBox groupBox51;
        private GroupBox groupBox52;
        private GroupBox groupBox53;
        private GroupBox groupBox54;
        private GroupBox groupBox55;
        private GroupBox groupBox57;
        private GroupBox groupBox58;
        private GroupBox groupBox6;
        private List<InputRangeDec> inputRanges;
        private List<InputRangeStr> inputrange_str = new List<InputRangeStr> ();
        private SimpleBindingManager<RecordsVisceraFunctionModel> bindingManager;
        private Label label152;
        private Label label153;
        private Label label154;
        private Label label155;
        private Label label157;
        private Label label158;
        private Label label159;
        private Label label160;
        private Label label161;
        private Label label162;
        private Label label163;
        private Label label164;
        private Label label165;
        private Label label166;
        private Label label167;
        private Label label168;
        private Label label169;
        private Label label170;
        private Label label171;
        private Label label32;
        private Label label34;
        private Label label9;
        private Physique pinghezhi;
        private Physique qixuzhi;
        private Physique qiyuzhi;
        private RadioButton radjibenpinghe;
        private RadioButton radqingqixu;
        private RadioButton radqingqiyu;
        private RadioButton radqingshire;
        private RadioButton radqingtanshi;
        private RadioButton radqingtejian;
        private RadioButton radqingxueyu;
        private RadioButton radqingyangxu;
        private RadioButton radqingyinxu;
        private RadioButton radshipinghe;
        private RadioButton radshiqixu;
        private RadioButton radshiqiyu;
        private RadioButton radshishire;
        private RadioButton radshitanshi;
        private RadioButton radshitejian;
        private RadioButton radshixueyu;
        private RadioButton radshiyangxu;
        private RadioButton radshiyinxu;
        private RadioButton radtltbj;
        private RadioButton radtltj;
        private RadioButton radydbsl;
        private RadioButton radydsl;
        private Physique shirezhi;
        private Physique tanshizhi;
        private Physique tejianzhi;
        private Physique tingli;
        private TextBox txtjzleft;
        private TextBox txtjzrightsl;
        private TextBox txtleftsl;
        private TextBox txtrightsl;
        private Physique xueyuzhi;
        private Physique yangxuzhi;
        private Physique yinxuzhi;
        private Panel panelTooth;
        private CheckBox ckbzc;
        private CheckBox ckbyc;
        private CheckBox ckbquec;
        private CheckBox ckbquc;
        private TextBox tbQueUpRight;
        private TextBox tbQueDownRight;
        private TextBox tbQueDownLeft;
        private TextBox tbQueUpLeft;
        private TextBox tbQuUpR;
        private TextBox tbYiUpR;
        private TextBox tbQuDownR;
        private TextBox tbYiDownR;
        private TextBox tbQuDownL;
        private TextBox tbYiDownL;
        private TextBox tbQuUpL;
        private TextBox tbYiUpL;
        private Physique yundong;
        private TextBox tbPharyngealEx;
        private TextBox tbLipsEx;
        private CheckBox ckbqit;
        private TextBox tbToothResidesOther;
        private List<CheckBox> wxys = new List<CheckBox>();
        public RecordsMedicineCnModel MedCn;
        public RecordsMedicineResultModel MedResult;
        private int flagfactoryID = 0;//记录页面 PhysicalInfoFactory.ID的初始值
        private DataSet dsRequire;
        public UCMedicalPhysique()
        {
            this.InitializeComponent();
            groupBox4.Location = new Point(159, 11);

            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("LeftView", 10M));
            this.inputRanges.Add(new InputRangeDec("RightView", 10M));
            this.inputRanges.Add(new InputRangeDec("RightEyecorrect", 10M));
            this.inputRanges.Add(new InputRangeDec("LeftEyecorrect", 10M));
            this.wxys.Add(this.ckbzc);
            this.wxys.Add(this.ckbquec);
            this.wxys.Add(this.ckbquc);
            this.wxys.Add(this.ckbyc);
            this.wxys.Add(this.ckbqit);
            this.EveryThingIsOk = false;
        }

        private void bd_Parse(object sender, ConvertEventArgs e)
        {
            decimal num;
            Predicate<InputRangeDec> match = null;
            Binding bd = sender as Binding;
            if (decimal.TryParse(e.Value.ToString(), out num))
            {
                if (match == null)
                {
                    match = c => c.Name == bd.BindingMemberInfo.BindingField;
                }
                InputRangeDec dec = this.inputRanges.Find(match);
                if (dec != null)
                {
                    if (dec.CheckIt(ref num))
                    {
                        bd.Control.BackColor = Color.WhiteSmoke;
                        e.Value = num;
                    }
                    else
                    {
                        bd.Control.BackColor = Color.Salmon;
                    }
                }
            }
            else
            {
                e.Value = null;
            }
        }

        private void btnElderM_Click(object sender, EventArgs e)
        {
            FrmOldMedEX dex = new FrmOldMedEX(this.Model)
            {
                PhysicalInfoFactoryID = this.flagfactoryID,
                phy = this.MediPhys,
                MedCn = this.MedCn,
                MedResult = this.MedResult,
                //generalconditionmodel = this.generalconditionmodel,
                CZBMI = this.CZBMI,
                CZWaistline = this.CZWaistline,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                Text = "中医体质判定",
                MaximizeBox = false,
                MinimizeBox = false,
                ShowIcon = false

            };
            dex.PhysicalItem();
            dex.StartPosition = FormStartPosition.CenterParent;
            if (dex.ShowDialog() == DialogResult.OK)
            {
                this.pinghezhi.Reset(this.MediPhys.Mild);
                this.qixuzhi.Reset(this.MediPhys.Faint);
                this.yangxuzhi.Reset(this.MediPhys.Yang);
                this.yinxuzhi.Reset(this.MediPhys.Yin);
                this.tanshizhi.Reset(this.MediPhys.PhlegmDamp);
                this.shirezhi.Reset(this.MediPhys.Muggy);
                this.xueyuzhi.Reset(this.MediPhys.BloodStasis);
                this.qiyuzhi.Reset(this.MediPhys.QiConstraint);
                this.tejianzhi.Reset(this.MediPhys.Characteristic);
                this.MedCn = dex.MedCn;
                this.MedResult = dex.MedResult;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.pinghezhi.Reset();
            this.qixuzhi.Reset();
            this.yangxuzhi.Reset();
            this.yinxuzhi.Reset();
            this.tanshizhi.Reset();
            this.shirezhi.Reset();
            this.xueyuzhi.Reset();
            this.qiyuzhi.Reset();
            this.tejianzhi.Reset();
        }

        public ChildFormStatus CheckErrorInput()
        {
            if (((this.inputRanges.Count<InputRangeDec>(c => c.ErrorInput) > 0) ? 1 : 0) == 0)
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
            dsRequire = new RequireBLL().GetList("TabName = '健康体检' AND Comment = '脏器功能' ");
            this.flagfactoryID = PhysicalInfoFactory.ID;
            this.MediPhys = new RecordsMediPhysDistBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            this.VisceraFunction = new RecordsVisceraFunctionBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            //this.generalconditionmodel = new RecordsGeneralConditionBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            if (this.MediPhys == null)
            {
                this.MediPhys = new RecordsMediPhysDistModel();
            }
            else
            {
                MedCn = new RecordsMedicineCnBLL().GetModel(this.MediPhys.MedicineID);
                MedResult = new RecordsMedicineResultBLL().GetModel(this.MediPhys.MedicineResultID);
            }
            if (this.VisceraFunction == null)
            {
                this.VisceraFunction = new RecordsVisceraFunctionModel();
            }
            if (PhysicalInfoFactory.falgID == 0)//新增时
            {
                this.PresetValue();
            }
            this.bindingManager = new SimpleBindingManager<RecordsVisceraFunctionModel>(this.inputRanges, this.inputrange_str, this.VisceraFunction);
            this.pinghezhi = new Physique(this.radshipinghe, this.radjibenpinghe, this.MediPhys.Mild);
            this.qixuzhi = new Physique(this.radshiqixu, this.radqingqixu, this.MediPhys.Faint);
            this.yangxuzhi = new Physique(this.radshiyangxu, this.radqingyangxu, this.MediPhys.Yang);
            this.yinxuzhi = new Physique(this.radshiyinxu, this.radqingyinxu, this.MediPhys.Yin);
            this.tanshizhi = new Physique(this.radshitanshi, this.radqingtanshi, this.MediPhys.PhlegmDamp);
            this.shirezhi = new Physique(this.radshishire, this.radqingshire, this.MediPhys.Muggy);
            this.xueyuzhi = new Physique(this.radshixueyu, this.radqingxueyu, this.MediPhys.BloodStasis);
            this.qiyuzhi = new Physique(this.radshiqiyu, this.radqingqiyu, this.MediPhys.QiConstraint);
            this.tejianzhi = new Physique(this.radshitejian, this.radqingtejian, this.MediPhys.Characteristic);
            this.SetComoboxValue(this.cmbkouchun, this.VisceraFunction.Lips);
            this.SetComoboxValue(this.cmbyanbu, this.VisceraFunction.Pharyngeal);
            if (!string.IsNullOrEmpty(this.VisceraFunction.ToothResides))
            {
                string strchilie = this.VisceraFunction.ToothResides;
                char[] chArray = new char[] { ',' };
                foreach (string str4 in strchilie.Split(chArray))
                {
                    int num;
                    if (int.TryParse(str4, out num) && num > 0)
                    {
                        this.wxys[num - 1].Checked = true;
                    }
                }
            }

            if (!string.IsNullOrEmpty(this.VisceraFunction.HypodontiaEx)) //缺齿
            {
                string strHypodontiaEx = this.VisceraFunction.HypodontiaEx;
                char[] separator = new char[] { '#' };
                int num = 0;
                foreach (string str2 in strHypodontiaEx.Split(separator))
                {
                    num++;
                    switch (num)
                    {
                        case 1: this.tbQueUpLeft.Text = str2; break;
                        case 2: this.tbQueUpRight.Text = str2; break;
                        case 3: this.tbQueDownLeft.Text = str2; break;
                        case 4: this.tbQueDownRight.Text = str2; break;
                        default: break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(this.VisceraFunction.SaprodontiaEx)) //龋齿
            {
                string strSaprodontiaEx = this.VisceraFunction.SaprodontiaEx;
                char[] separator = new char[] { '#' };
                int num = 0;
                foreach (string str2 in strSaprodontiaEx.Split(separator))
                {
                    num++;
                    switch (num)
                    {
                        case 1: this.tbQuUpL.Text = str2; break;
                        case 2: this.tbQuUpR.Text = str2; break;
                        case 3: this.tbQuDownL.Text = str2; break;
                        case 4: this.tbQuDownR.Text = str2; break;
                        default: break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(this.VisceraFunction.DentureEx)) //义齿
            {
                string strDentureEx = this.VisceraFunction.DentureEx;
                char[] separator = new char[] { '#' };
                int num = 0;
                foreach (string str2 in strDentureEx.Split(separator))
                {
                    num++;
                    switch (num)
                    {
                        case 1: this.tbYiUpL.Text = str2; break;
                        case 2: this.tbYiUpR.Text = str2; break;
                        case 3: this.tbYiDownL.Text = str2; break;
                        case 4: this.tbYiDownR.Text = str2; break;
                        default: break;
                    }
                }
            }
            this.shili(this.txtleftsl, "LeftView");
            this.shili(this.txtrightsl, "RightView");
            this.shili(this.txtjzleft, "LeftEyecorrect");
            this.shili(this.txtjzrightsl, "RightEyecorrect");
            this.bindingManager.SimpleBinding(this.tbToothResidesOther, "ToothResidesOther", false);
            this.yundong = new Physique("运动", this.radydsl, this.radydbsl, this.VisceraFunction.SportFunction);
            this.tingli = new Physique("听力", this.radtltj, this.radtltbj, this.VisceraFunction.Listen);
            this.btnElderM.Visible = true;
            MustChoose();
            this.EveryThingIsOk = true;
        }
        //默认项设置
        private void PresetValue()
        {
            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = " IsSetValue='是' or IsSetValue='预设上次体检' ";
            DataTable dt = dv.ToTable();
            RecordsVisceraFunctionModel VisceraFunctions = new RecordsVisceraFunctionModel();
            RecordsCustomerBaseInfoModel CustomerBaseInfos = new RecordsCustomerBaseInfoBLL().GetMaxModel(this.Model.IDCardNo);//获取最新一笔体检数据
            if (CustomerBaseInfos != null) VisceraFunctions = new RecordsVisceraFunctionBLL().GetModelByOutKey(CustomerBaseInfos.ID);
            foreach (DataRow item in dt.Rows)
            {
                switch (item["ChinName"].ToString())
                {
                    case "口唇":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.VisceraFunction.Lips = item["ItemValue"].ToString();
                        }
                        else
                        {
                            if (VisceraFunctions == null) return;
                            this.VisceraFunction.Lips = VisceraFunctions.Lips;
                            this.VisceraFunction.LipsEx = VisceraFunctions.LipsEx;
                        }
                        break;
                    case "齿列":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.VisceraFunction.ToothResides = item["ItemValue"].ToString();
                        }
                        else
                        {
                            if (VisceraFunctions == null) return;
                            this.VisceraFunction.ToothResides = VisceraFunctions.ToothResides;
                            this.VisceraFunction.HypodontiaEx = VisceraFunctions.HypodontiaEx;
                            this.VisceraFunction.SaprodontiaEx = VisceraFunctions.SaprodontiaEx;
                            this.VisceraFunction.DentureEx = VisceraFunctions.DentureEx;
                            this.VisceraFunction.ToothResidesOther = VisceraFunctions.ToothResidesOther;
                        }
                        break;
                    case "咽部":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.VisceraFunction.Pharyngeal = item["ItemValue"].ToString();
                        }
                        else
                        {
                            if (VisceraFunctions == null) return;
                            this.VisceraFunction.Pharyngeal = VisceraFunctions.Pharyngeal;
                            this.VisceraFunction.PharyngealEx = VisceraFunctions.PharyngealEx;
                        }
                        break;
                    case "听力":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.VisceraFunction.Listen = item["ItemValue"].ToString();
                        }
                        else
                        {
                            if (VisceraFunctions == null) return;
                            this.VisceraFunction.Listen = VisceraFunctions.Listen;
                        }
                        break;
                    case "运动功能":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.VisceraFunction.SportFunction = item["ItemValue"].ToString();
                        }
                        else
                        {
                            if (VisceraFunctions == null) return;
                            this.VisceraFunction.SportFunction = VisceraFunctions.SportFunction;
                        }
                        break;
                    case "矫正右":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.VisceraFunction.RightEyecorrect = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            if (VisceraFunctions == null) return;
                            this.VisceraFunction.RightEyecorrect = VisceraFunctions.RightEyecorrect;
                        }
                        break;
                    case "矫正左":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.VisceraFunction.LeftEyecorrect = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            if (VisceraFunctions == null) return;
                            this.VisceraFunction.LeftEyecorrect = VisceraFunctions.LeftEyecorrect;
                        }
                        break;
                    case "右眼":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.VisceraFunction.RightView = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                RecordsManageMentModel.RightView = VisceraFunction.RightView;
                            }
                        }
                        else
                        {
                            if (VisceraFunctions == null) return;
                            this.VisceraFunction.RightView = VisceraFunctions.RightView;
                            RecordsManageMentModel.RightView = VisceraFunctions.RightView;
                        }
                        break;
                    case "左眼":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.VisceraFunction.LeftView = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                RecordsManageMentModel.LeftView = VisceraFunction.LeftView;
                            }
                        }
                        else
                        {
                            if (VisceraFunctions == null) return;
                            this.VisceraFunction.LeftView = VisceraFunctions.LeftView;
                            RecordsManageMentModel.LeftView = VisceraFunctions.LeftView;
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
            RecordsVisceraFunctionModel VisceraFunctions = new RecordsVisceraFunctionBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            if (VisceraFunctions == null) VisceraFunctions = new RecordsVisceraFunctionModel();
            foreach (DataRow item in dt.Rows)
            {
                if (item["Isrequired"].ToString() == "1")
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "口唇":
                            if (string.IsNullOrEmpty(Convert.ToString(VisceraFunctions.Lips)))
                            {
                                this.label9.Text = "*口 唇";
                                this.label9.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label9.Text = "口 唇";
                                this.label9.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "齿列":
                            if (string.IsNullOrEmpty(Convert.ToString(VisceraFunctions.ToothResides)))
                            {
                                this.label32.Text = "*齿 列";
                                this.label32.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label32.Text = "齿 列";
                                this.label32.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "咽部":
                            if (string.IsNullOrEmpty(Convert.ToString(VisceraFunctions.Pharyngeal)))
                            {
                                this.label34.Text = "*咽 部";
                                this.label34.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label34.Text = "咽 部";
                                this.label34.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "听力":
                            if (string.IsNullOrEmpty(Convert.ToString(VisceraFunctions.Listen)))
                            {
                                this.label170.Text = "*听 力";
                                this.label170.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label170.Text = "听 力";
                                this.label170.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "运动功能":
                            if (string.IsNullOrEmpty(Convert.ToString(VisceraFunctions.SportFunction)))
                            {
                                this.label171.Text = "*运动功能";
                                this.label171.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label171.Text = "运动功能";
                                this.label171.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "左眼":
                            if (string.IsNullOrEmpty(Convert.ToString(VisceraFunctions.LeftView)))
                            {
                                this.label163.Text = "*左眼";
                                this.label163.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label163.Text = "左眼";
                                this.label163.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "右眼":
                            if (string.IsNullOrEmpty(Convert.ToString(VisceraFunctions.RightView)))
                            {
                                this.label164.Text = "*右眼";
                                this.label164.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label164.Text = "右眼";
                                this.label164.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "矫正左":
                            if (string.IsNullOrEmpty(Convert.ToString(VisceraFunctions.LeftEyecorrect)))
                            {
                                this.label168.Text = "*左";
                                this.label168.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label168.Text = "左";
                                this.label168.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "矫正右":
                            if (string.IsNullOrEmpty(Convert.ToString(VisceraFunctions.RightEyecorrect)))
                            {
                                this.label169.Text = "*右";
                                this.label169.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label169.Text = "右";
                                this.label169.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        default: break;
                    }
                }
            }
        }
        private void InitializeComponent()
        {
            this.groupBox44 = new System.Windows.Forms.GroupBox();
            this.btnElderM = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox55 = new System.Windows.Forms.GroupBox();
            this.radqingqiyu = new System.Windows.Forms.RadioButton();
            this.radshiqiyu = new System.Windows.Forms.RadioButton();
            this.groupBox54 = new System.Windows.Forms.GroupBox();
            this.radqingshire = new System.Windows.Forms.RadioButton();
            this.radshishire = new System.Windows.Forms.RadioButton();
            this.groupBox53 = new System.Windows.Forms.GroupBox();
            this.radqingyinxu = new System.Windows.Forms.RadioButton();
            this.radshiyinxu = new System.Windows.Forms.RadioButton();
            this.groupBox52 = new System.Windows.Forms.GroupBox();
            this.radqingqixu = new System.Windows.Forms.RadioButton();
            this.radshiqixu = new System.Windows.Forms.RadioButton();
            this.groupBox51 = new System.Windows.Forms.GroupBox();
            this.radqingtejian = new System.Windows.Forms.RadioButton();
            this.radshitejian = new System.Windows.Forms.RadioButton();
            this.groupBox50 = new System.Windows.Forms.GroupBox();
            this.radqingxueyu = new System.Windows.Forms.RadioButton();
            this.radshixueyu = new System.Windows.Forms.RadioButton();
            this.groupBox49 = new System.Windows.Forms.GroupBox();
            this.radqingtanshi = new System.Windows.Forms.RadioButton();
            this.radshitanshi = new System.Windows.Forms.RadioButton();
            this.groupBox48 = new System.Windows.Forms.GroupBox();
            this.radqingyangxu = new System.Windows.Forms.RadioButton();
            this.radshiyangxu = new System.Windows.Forms.RadioButton();
            this.groupBox47 = new System.Windows.Forms.GroupBox();
            this.radjibenpinghe = new System.Windows.Forms.RadioButton();
            this.radshipinghe = new System.Windows.Forms.RadioButton();
            this.label161 = new System.Windows.Forms.Label();
            this.label160 = new System.Windows.Forms.Label();
            this.label159 = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.label154 = new System.Windows.Forms.Label();
            this.label153 = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox58 = new System.Windows.Forms.GroupBox();
            this.radtltj = new System.Windows.Forms.RadioButton();
            this.radtltbj = new System.Windows.Forms.RadioButton();
            this.groupBox57 = new System.Windows.Forms.GroupBox();
            this.radydsl = new System.Windows.Forms.RadioButton();
            this.radydbsl = new System.Windows.Forms.RadioButton();
            this.label171 = new System.Windows.Forms.Label();
            this.label170 = new System.Windows.Forms.Label();
            this.txtjzrightsl = new System.Windows.Forms.TextBox();
            this.label169 = new System.Windows.Forms.Label();
            this.txtjzleft = new System.Windows.Forms.TextBox();
            this.label168 = new System.Windows.Forms.Label();
            this.label167 = new System.Windows.Forms.Label();
            this.label166 = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.txtrightsl = new System.Windows.Forms.TextBox();
            this.label164 = new System.Windows.Forms.Label();
            this.txtleftsl = new System.Windows.Forms.TextBox();
            this.label163 = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbPharyngealEx = new System.Windows.Forms.TextBox();
            this.tbLipsEx = new System.Windows.Forms.TextBox();
            this.panelTooth = new System.Windows.Forms.Panel();
            this.tbToothResidesOther = new System.Windows.Forms.TextBox();
            this.tbQuUpR = new System.Windows.Forms.TextBox();
            this.tbYiUpR = new System.Windows.Forms.TextBox();
            this.tbQueUpRight = new System.Windows.Forms.TextBox();
            this.tbQuDownR = new System.Windows.Forms.TextBox();
            this.tbYiDownR = new System.Windows.Forms.TextBox();
            this.tbQueDownRight = new System.Windows.Forms.TextBox();
            this.tbQuDownL = new System.Windows.Forms.TextBox();
            this.tbYiDownL = new System.Windows.Forms.TextBox();
            this.tbQueDownLeft = new System.Windows.Forms.TextBox();
            this.tbQuUpL = new System.Windows.Forms.TextBox();
            this.tbYiUpL = new System.Windows.Forms.TextBox();
            this.tbQueUpLeft = new System.Windows.Forms.TextBox();
            this.ckbyc = new System.Windows.Forms.CheckBox();
            this.ckbquec = new System.Windows.Forms.CheckBox();
            this.ckbqit = new System.Windows.Forms.CheckBox();
            this.ckbquc = new System.Windows.Forms.CheckBox();
            this.cmbyanbu = new System.Windows.Forms.ComboBox();
            this.cmbkouchun = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ckbzc = new System.Windows.Forms.CheckBox();
            this.groupBox44.SuspendLayout();
            this.groupBox55.SuspendLayout();
            this.groupBox54.SuspendLayout();
            this.groupBox53.SuspendLayout();
            this.groupBox52.SuspendLayout();
            this.groupBox51.SuspendLayout();
            this.groupBox50.SuspendLayout();
            this.groupBox49.SuspendLayout();
            this.groupBox48.SuspendLayout();
            this.groupBox47.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox58.SuspendLayout();
            this.groupBox57.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panelTooth.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox44
            // 
            this.groupBox44.Controls.Add(this.btnElderM);
            this.groupBox44.Controls.Add(this.btnReset);
            this.groupBox44.Controls.Add(this.groupBox55);
            this.groupBox44.Controls.Add(this.groupBox54);
            this.groupBox44.Controls.Add(this.groupBox53);
            this.groupBox44.Controls.Add(this.groupBox52);
            this.groupBox44.Controls.Add(this.groupBox51);
            this.groupBox44.Controls.Add(this.groupBox50);
            this.groupBox44.Controls.Add(this.groupBox49);
            this.groupBox44.Controls.Add(this.groupBox48);
            this.groupBox44.Controls.Add(this.groupBox47);
            this.groupBox44.Controls.Add(this.label161);
            this.groupBox44.Controls.Add(this.label160);
            this.groupBox44.Controls.Add(this.label159);
            this.groupBox44.Controls.Add(this.label158);
            this.groupBox44.Controls.Add(this.label157);
            this.groupBox44.Controls.Add(this.label155);
            this.groupBox44.Controls.Add(this.label154);
            this.groupBox44.Controls.Add(this.label153);
            this.groupBox44.Controls.Add(this.label152);
            this.groupBox44.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox44.Location = new System.Drawing.Point(74, 9);
            this.groupBox44.Name = "groupBox44";
            this.groupBox44.Size = new System.Drawing.Size(1330, 284);
            this.groupBox44.TabIndex = 0;
            this.groupBox44.TabStop = false;
            this.groupBox44.Text = "体质辨别*";
            this.groupBox44.Visible = false;
            // 
            // btnElderM
            // 
            this.btnElderM.Location = new System.Drawing.Point(1098, 222);
            this.btnElderM.Name = "btnElderM";
            this.btnElderM.Size = new System.Drawing.Size(116, 51);
            this.btnElderM.TabIndex = 9;
            this.btnElderM.Text = "体质辨识问卷";
            this.btnElderM.UseVisualStyleBackColor = true;
            this.btnElderM.Visible = false;
            this.btnElderM.Click += new System.EventHandler(this.btnElderM_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1220, 222);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 51);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox55
            // 
            this.groupBox55.Controls.Add(this.radqingqiyu);
            this.groupBox55.Controls.Add(this.radshiqiyu);
            this.groupBox55.Location = new System.Drawing.Point(658, 159);
            this.groupBox55.Name = "groupBox55";
            this.groupBox55.Size = new System.Drawing.Size(273, 45);
            this.groupBox55.TabIndex = 8;
            this.groupBox55.TabStop = false;
            // 
            // radqingqiyu
            // 
            this.radqingqiyu.AutoSize = true;
            this.radqingqiyu.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radqingqiyu.Location = new System.Drawing.Point(152, 14);
            this.radqingqiyu.Name = "radqingqiyu";
            this.radqingqiyu.Size = new System.Drawing.Size(111, 30);
            this.radqingqiyu.TabIndex = 9;
            this.radqingqiyu.TabStop = true;
            this.radqingqiyu.Text = "倾向是";
            this.radqingqiyu.UseVisualStyleBackColor = true;
            // 
            // radshiqiyu
            // 
            this.radshiqiyu.AutoSize = true;
            this.radshiqiyu.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radshiqiyu.Location = new System.Drawing.Point(7, 14);
            this.radshiqiyu.Name = "radshiqiyu";
            this.radshiqiyu.Size = new System.Drawing.Size(59, 30);
            this.radshiqiyu.TabIndex = 8;
            this.radshiqiyu.TabStop = true;
            this.radshiqiyu.Text = "是";
            this.radshiqiyu.UseVisualStyleBackColor = true;
            // 
            // groupBox54
            // 
            this.groupBox54.Controls.Add(this.radqingshire);
            this.groupBox54.Controls.Add(this.radshishire);
            this.groupBox54.Location = new System.Drawing.Point(658, 109);
            this.groupBox54.Name = "groupBox54";
            this.groupBox54.Size = new System.Drawing.Size(273, 45);
            this.groupBox54.TabIndex = 7;
            this.groupBox54.TabStop = false;
            // 
            // radqingshire
            // 
            this.radqingshire.AutoSize = true;
            this.radqingshire.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radqingshire.Location = new System.Drawing.Point(152, 14);
            this.radqingshire.Name = "radqingshire";
            this.radqingshire.Size = new System.Drawing.Size(111, 30);
            this.radqingshire.TabIndex = 9;
            this.radqingshire.TabStop = true;
            this.radqingshire.Text = "倾向是";
            this.radqingshire.UseVisualStyleBackColor = true;
            // 
            // radshishire
            // 
            this.radshishire.AutoSize = true;
            this.radshishire.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radshishire.Location = new System.Drawing.Point(7, 14);
            this.radshishire.Name = "radshishire";
            this.radshishire.Size = new System.Drawing.Size(59, 30);
            this.radshishire.TabIndex = 8;
            this.radshishire.TabStop = true;
            this.radshishire.Text = "是";
            this.radshishire.UseVisualStyleBackColor = true;
            // 
            // groupBox53
            // 
            this.groupBox53.Controls.Add(this.radqingyinxu);
            this.groupBox53.Controls.Add(this.radshiyinxu);
            this.groupBox53.Location = new System.Drawing.Point(658, 61);
            this.groupBox53.Name = "groupBox53";
            this.groupBox53.Size = new System.Drawing.Size(273, 45);
            this.groupBox53.TabIndex = 6;
            this.groupBox53.TabStop = false;
            // 
            // radqingyinxu
            // 
            this.radqingyinxu.AutoSize = true;
            this.radqingyinxu.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radqingyinxu.Location = new System.Drawing.Point(152, 14);
            this.radqingyinxu.Name = "radqingyinxu";
            this.radqingyinxu.Size = new System.Drawing.Size(111, 30);
            this.radqingyinxu.TabIndex = 9;
            this.radqingyinxu.TabStop = true;
            this.radqingyinxu.Text = "倾向是";
            this.radqingyinxu.UseVisualStyleBackColor = true;
            // 
            // radshiyinxu
            // 
            this.radshiyinxu.AutoSize = true;
            this.radshiyinxu.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radshiyinxu.Location = new System.Drawing.Point(7, 14);
            this.radshiyinxu.Name = "radshiyinxu";
            this.radshiyinxu.Size = new System.Drawing.Size(59, 30);
            this.radshiyinxu.TabIndex = 8;
            this.radshiyinxu.TabStop = true;
            this.radshiyinxu.Text = "是";
            this.radshiyinxu.UseVisualStyleBackColor = true;
            // 
            // groupBox52
            // 
            this.groupBox52.Controls.Add(this.radqingqixu);
            this.groupBox52.Controls.Add(this.radshiqixu);
            this.groupBox52.Location = new System.Drawing.Point(658, 16);
            this.groupBox52.Name = "groupBox52";
            this.groupBox52.Size = new System.Drawing.Size(273, 45);
            this.groupBox52.TabIndex = 5;
            this.groupBox52.TabStop = false;
            // 
            // radqingqixu
            // 
            this.radqingqixu.AutoSize = true;
            this.radqingqixu.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radqingqixu.Location = new System.Drawing.Point(152, 14);
            this.radqingqixu.Name = "radqingqixu";
            this.radqingqixu.Size = new System.Drawing.Size(111, 30);
            this.radqingqixu.TabIndex = 9;
            this.radqingqixu.TabStop = true;
            this.radqingqixu.Text = "倾向是";
            this.radqingqixu.UseVisualStyleBackColor = true;
            // 
            // radshiqixu
            // 
            this.radshiqixu.AutoSize = true;
            this.radshiqixu.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radshiqixu.Location = new System.Drawing.Point(7, 14);
            this.radshiqixu.Name = "radshiqixu";
            this.radshiqixu.Size = new System.Drawing.Size(59, 30);
            this.radshiqixu.TabIndex = 8;
            this.radshiqixu.TabStop = true;
            this.radshiqixu.Text = "是";
            this.radshiqixu.UseVisualStyleBackColor = true;
            // 
            // groupBox51
            // 
            this.groupBox51.Controls.Add(this.radqingtejian);
            this.groupBox51.Controls.Add(this.radshitejian);
            this.groupBox51.Location = new System.Drawing.Point(121, 208);
            this.groupBox51.Name = "groupBox51";
            this.groupBox51.Size = new System.Drawing.Size(273, 45);
            this.groupBox51.TabIndex = 4;
            this.groupBox51.TabStop = false;
            // 
            // radqingtejian
            // 
            this.radqingtejian.AutoSize = true;
            this.radqingtejian.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radqingtejian.Location = new System.Drawing.Point(152, 14);
            this.radqingtejian.Name = "radqingtejian";
            this.radqingtejian.Size = new System.Drawing.Size(111, 30);
            this.radqingtejian.TabIndex = 9;
            this.radqingtejian.TabStop = true;
            this.radqingtejian.Text = "倾向是";
            this.radqingtejian.UseVisualStyleBackColor = true;
            // 
            // radshitejian
            // 
            this.radshitejian.AutoSize = true;
            this.radshitejian.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radshitejian.Location = new System.Drawing.Point(7, 14);
            this.radshitejian.Name = "radshitejian";
            this.radshitejian.Size = new System.Drawing.Size(59, 30);
            this.radshitejian.TabIndex = 8;
            this.radshitejian.TabStop = true;
            this.radshitejian.Text = "是";
            this.radshitejian.UseVisualStyleBackColor = true;
            // 
            // groupBox50
            // 
            this.groupBox50.Controls.Add(this.radqingxueyu);
            this.groupBox50.Controls.Add(this.radshixueyu);
            this.groupBox50.Location = new System.Drawing.Point(121, 159);
            this.groupBox50.Name = "groupBox50";
            this.groupBox50.Size = new System.Drawing.Size(273, 45);
            this.groupBox50.TabIndex = 3;
            this.groupBox50.TabStop = false;
            // 
            // radqingxueyu
            // 
            this.radqingxueyu.AutoSize = true;
            this.radqingxueyu.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radqingxueyu.Location = new System.Drawing.Point(152, 14);
            this.radqingxueyu.Name = "radqingxueyu";
            this.radqingxueyu.Size = new System.Drawing.Size(111, 30);
            this.radqingxueyu.TabIndex = 9;
            this.radqingxueyu.TabStop = true;
            this.radqingxueyu.Text = "倾向是";
            this.radqingxueyu.UseVisualStyleBackColor = true;
            // 
            // radshixueyu
            // 
            this.radshixueyu.AutoSize = true;
            this.radshixueyu.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radshixueyu.Location = new System.Drawing.Point(7, 14);
            this.radshixueyu.Name = "radshixueyu";
            this.radshixueyu.Size = new System.Drawing.Size(59, 30);
            this.radshixueyu.TabIndex = 8;
            this.radshixueyu.TabStop = true;
            this.radshixueyu.Text = "是";
            this.radshixueyu.UseVisualStyleBackColor = true;
            // 
            // groupBox49
            // 
            this.groupBox49.Controls.Add(this.radqingtanshi);
            this.groupBox49.Controls.Add(this.radshitanshi);
            this.groupBox49.Location = new System.Drawing.Point(121, 109);
            this.groupBox49.Name = "groupBox49";
            this.groupBox49.Size = new System.Drawing.Size(273, 45);
            this.groupBox49.TabIndex = 2;
            this.groupBox49.TabStop = false;
            // 
            // radqingtanshi
            // 
            this.radqingtanshi.AutoSize = true;
            this.radqingtanshi.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radqingtanshi.Location = new System.Drawing.Point(152, 14);
            this.radqingtanshi.Name = "radqingtanshi";
            this.radqingtanshi.Size = new System.Drawing.Size(111, 30);
            this.radqingtanshi.TabIndex = 9;
            this.radqingtanshi.TabStop = true;
            this.radqingtanshi.Text = "倾向是";
            this.radqingtanshi.UseVisualStyleBackColor = true;
            // 
            // radshitanshi
            // 
            this.radshitanshi.AutoSize = true;
            this.radshitanshi.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radshitanshi.Location = new System.Drawing.Point(7, 14);
            this.radshitanshi.Name = "radshitanshi";
            this.radshitanshi.Size = new System.Drawing.Size(59, 30);
            this.radshitanshi.TabIndex = 8;
            this.radshitanshi.TabStop = true;
            this.radshitanshi.Text = "是";
            this.radshitanshi.UseVisualStyleBackColor = true;
            // 
            // groupBox48
            // 
            this.groupBox48.Controls.Add(this.radqingyangxu);
            this.groupBox48.Controls.Add(this.radshiyangxu);
            this.groupBox48.Location = new System.Drawing.Point(121, 67);
            this.groupBox48.Name = "groupBox48";
            this.groupBox48.Size = new System.Drawing.Size(273, 45);
            this.groupBox48.TabIndex = 1;
            this.groupBox48.TabStop = false;
            // 
            // radqingyangxu
            // 
            this.radqingyangxu.AutoSize = true;
            this.radqingyangxu.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radqingyangxu.Location = new System.Drawing.Point(152, 11);
            this.radqingyangxu.Name = "radqingyangxu";
            this.radqingyangxu.Size = new System.Drawing.Size(111, 30);
            this.radqingyangxu.TabIndex = 9;
            this.radqingyangxu.TabStop = true;
            this.radqingyangxu.Text = "倾向是";
            this.radqingyangxu.UseVisualStyleBackColor = true;
            // 
            // radshiyangxu
            // 
            this.radshiyangxu.AutoSize = true;
            this.radshiyangxu.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radshiyangxu.Location = new System.Drawing.Point(7, 11);
            this.radshiyangxu.Name = "radshiyangxu";
            this.radshiyangxu.Size = new System.Drawing.Size(59, 30);
            this.radshiyangxu.TabIndex = 8;
            this.radshiyangxu.TabStop = true;
            this.radshiyangxu.Text = "是";
            this.radshiyangxu.UseVisualStyleBackColor = true;
            // 
            // groupBox47
            // 
            this.groupBox47.Controls.Add(this.radjibenpinghe);
            this.groupBox47.Controls.Add(this.radshipinghe);
            this.groupBox47.Location = new System.Drawing.Point(121, 14);
            this.groupBox47.Name = "groupBox47";
            this.groupBox47.Size = new System.Drawing.Size(273, 45);
            this.groupBox47.TabIndex = 0;
            this.groupBox47.TabStop = false;
            // 
            // radjibenpinghe
            // 
            this.radjibenpinghe.AutoSize = true;
            this.radjibenpinghe.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radjibenpinghe.Location = new System.Drawing.Point(152, 14);
            this.radjibenpinghe.Name = "radjibenpinghe";
            this.radjibenpinghe.Size = new System.Drawing.Size(111, 30);
            this.radjibenpinghe.TabIndex = 0;
            this.radjibenpinghe.TabStop = true;
            this.radjibenpinghe.Text = "基本是";
            this.radjibenpinghe.UseVisualStyleBackColor = true;
            // 
            // radshipinghe
            // 
            this.radshipinghe.AutoSize = true;
            this.radshipinghe.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radshipinghe.Location = new System.Drawing.Point(7, 14);
            this.radshipinghe.Name = "radshipinghe";
            this.radshipinghe.Size = new System.Drawing.Size(59, 30);
            this.radshipinghe.TabIndex = 1;
            this.radshipinghe.TabStop = true;
            this.radshipinghe.Text = "是";
            this.radshipinghe.UseVisualStyleBackColor = true;
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label161.Location = new System.Drawing.Point(27, 224);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(90, 26);
            this.label161.TabIndex = 5;
            this.label161.Text = "特秉质";
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label160.Location = new System.Drawing.Point(567, 173);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(90, 26);
            this.label160.TabIndex = 4;
            this.label160.Text = "气郁质";
            // 
            // label159
            // 
            this.label159.AutoSize = true;
            this.label159.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label159.Location = new System.Drawing.Point(27, 173);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(90, 26);
            this.label159.TabIndex = 3;
            this.label159.Text = "血瘀质";
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label158.Location = new System.Drawing.Point(567, 123);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(90, 26);
            this.label158.TabIndex = 2;
            this.label158.Text = "湿热质";
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label157.Location = new System.Drawing.Point(567, 74);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(90, 26);
            this.label157.TabIndex = 1;
            this.label157.Text = "阴虚质";
            // 
            // label155
            // 
            this.label155.AutoSize = true;
            this.label155.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label155.Location = new System.Drawing.Point(27, 125);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(90, 26);
            this.label155.TabIndex = 0;
            this.label155.Text = "痰湿质";
            // 
            // label154
            // 
            this.label154.AutoSize = true;
            this.label154.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label154.Location = new System.Drawing.Point(27, 75);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(90, 26);
            this.label154.TabIndex = 0;
            this.label154.Text = "阳虚质";
            // 
            // label153
            // 
            this.label153.AutoSize = true;
            this.label153.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label153.Location = new System.Drawing.Point(567, 30);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(90, 26);
            this.label153.TabIndex = 0;
            this.label153.Text = "气虚质";
            // 
            // label152
            // 
            this.label152.AutoSize = true;
            this.label152.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label152.Location = new System.Drawing.Point(27, 28);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(90, 26);
            this.label152.TabIndex = 0;
            this.label152.Text = "平和质";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox58);
            this.groupBox4.Controls.Add(this.groupBox57);
            this.groupBox4.Controls.Add(this.label171);
            this.groupBox4.Controls.Add(this.label170);
            this.groupBox4.Controls.Add(this.txtjzrightsl);
            this.groupBox4.Controls.Add(this.label169);
            this.groupBox4.Controls.Add(this.txtjzleft);
            this.groupBox4.Controls.Add(this.label168);
            this.groupBox4.Controls.Add(this.label167);
            this.groupBox4.Controls.Add(this.label166);
            this.groupBox4.Controls.Add(this.label165);
            this.groupBox4.Controls.Add(this.txtrightsl);
            this.groupBox4.Controls.Add(this.label164);
            this.groupBox4.Controls.Add(this.txtleftsl);
            this.groupBox4.Controls.Add(this.label163);
            this.groupBox4.Controls.Add(this.label162);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(75, 299);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1329, 367);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "脏器功能*";
            // 
            // groupBox58
            // 
            this.groupBox58.Controls.Add(this.radtltj);
            this.groupBox58.Controls.Add(this.radtltbj);
            this.groupBox58.Location = new System.Drawing.Point(139, 300);
            this.groupBox58.Name = "groupBox58";
            this.groupBox58.Size = new System.Drawing.Size(495, 44);
            this.groupBox58.TabIndex = 6;
            this.groupBox58.TabStop = false;
            // 
            // radtltj
            // 
            this.radtltj.AutoSize = true;
            this.radtltj.Location = new System.Drawing.Point(3, 16);
            this.radtltj.Name = "radtltj";
            this.radtltj.Size = new System.Drawing.Size(85, 30);
            this.radtltj.TabIndex = 26;
            this.radtltj.TabStop = true;
            this.radtltj.Text = "听见";
            this.radtltj.UseVisualStyleBackColor = true;
            // 
            // radtltbj
            // 
            this.radtltbj.AutoSize = true;
            this.radtltbj.Location = new System.Drawing.Point(173, 16);
            this.radtltbj.Name = "radtltbj";
            this.radtltbj.Size = new System.Drawing.Size(241, 30);
            this.radtltbj.TabIndex = 27;
            this.radtltbj.TabStop = true;
            this.radtltbj.Text = "听不清或无法听见";
            this.radtltbj.UseVisualStyleBackColor = true;
            // 
            // groupBox57
            // 
            this.groupBox57.Controls.Add(this.radydsl);
            this.groupBox57.Controls.Add(this.radydbsl);
            this.groupBox57.Location = new System.Drawing.Point(139, 248);
            this.groupBox57.Name = "groupBox57";
            this.groupBox57.Size = new System.Drawing.Size(498, 44);
            this.groupBox57.TabIndex = 5;
            this.groupBox57.TabStop = false;
            // 
            // radydsl
            // 
            this.radydsl.AutoSize = true;
            this.radydsl.Location = new System.Drawing.Point(3, 16);
            this.radydsl.Name = "radydsl";
            this.radydsl.Size = new System.Drawing.Size(163, 30);
            this.radydsl.TabIndex = 29;
            this.radydsl.TabStop = true;
            this.radydsl.Text = "可顺利完成";
            this.radydsl.UseVisualStyleBackColor = true;
            // 
            // radydbsl
            // 
            this.radydbsl.AutoSize = true;
            this.radydbsl.Location = new System.Drawing.Point(173, 16);
            this.radydbsl.Name = "radydbsl";
            this.radydbsl.Size = new System.Drawing.Size(397, 30);
            this.radydbsl.TabIndex = 30;
            this.radydbsl.TabStop = true;
            this.radydbsl.Text = "无法独立完成其中任何一个动作";
            this.radydbsl.UseVisualStyleBackColor = true;
            // 
            // label171
            // 
            this.label171.AutoSize = true;
            this.label171.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label171.Location = new System.Drawing.Point(24, 270);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(116, 26);
            this.label171.TabIndex = 28;
            this.label171.Text = "运动功能";
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label170.Location = new System.Drawing.Point(54, 320);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(77, 26);
            this.label170.TabIndex = 25;
            this.label170.Text = "听 力";
            // 
            // txtjzrightsl
            // 
            this.txtjzrightsl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtjzrightsl.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtjzrightsl.Location = new System.Drawing.Point(743, 214);
            this.txtjzrightsl.MaxLength = 4;
            this.txtjzrightsl.Name = "txtjzrightsl";
            this.txtjzrightsl.Size = new System.Drawing.Size(73, 36);
            this.txtjzrightsl.TabIndex = 4;
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.Location = new System.Drawing.Point(705, 220);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(38, 26);
            this.label169.TabIndex = 23;
            this.label169.Text = "右";
            // 
            // txtjzleft
            // 
            this.txtjzleft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtjzleft.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtjzleft.Location = new System.Drawing.Point(612, 215);
            this.txtjzleft.MaxLength = 4;
            this.txtjzleft.Name = "txtjzleft";
            this.txtjzleft.Size = new System.Drawing.Size(73, 36);
            this.txtjzleft.TabIndex = 3;
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Location = new System.Drawing.Point(568, 218);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(38, 26);
            this.label168.TabIndex = 21;
            this.label168.Text = "左";
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(469, 219);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(116, 26);
            this.label167.TabIndex = 20;
            this.label167.Text = "矫正视力";
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Location = new System.Drawing.Point(828, 218);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(25, 26);
            this.label166.TabIndex = 19;
            this.label166.Text = ")";
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Location = new System.Drawing.Point(456, 219);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(25, 26);
            this.label165.TabIndex = 18;
            this.label165.Text = "(";
            // 
            // txtrightsl
            // 
            this.txtrightsl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtrightsl.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtrightsl.Location = new System.Drawing.Point(349, 214);
            this.txtrightsl.MaxLength = 4;
            this.txtrightsl.Name = "txtrightsl";
            this.txtrightsl.Size = new System.Drawing.Size(73, 36);
            this.txtrightsl.TabIndex = 2;
            // 
            // label164
            // 
            this.label164.AutoSize = true;
            this.label164.Location = new System.Drawing.Point(288, 219);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(64, 26);
            this.label164.TabIndex = 16;
            this.label164.Text = "右眼";
            // 
            // txtleftsl
            // 
            this.txtleftsl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtleftsl.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtleftsl.Location = new System.Drawing.Point(193, 214);
            this.txtleftsl.MaxLength = 4;
            this.txtleftsl.Name = "txtleftsl";
            this.txtleftsl.Size = new System.Drawing.Size(73, 36);
            this.txtleftsl.TabIndex = 1;
            // 
            // label163
            // 
            this.label163.AutoSize = true;
            this.label163.Location = new System.Drawing.Point(135, 219);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(64, 26);
            this.label163.TabIndex = 14;
            this.label163.Text = "左眼";
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label162.Location = new System.Drawing.Point(54, 219);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(77, 26);
            this.label162.TabIndex = 13;
            this.label162.Text = "视 力";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbPharyngealEx);
            this.groupBox6.Controls.Add(this.tbLipsEx);
            this.groupBox6.Controls.Add(this.panelTooth);
            this.groupBox6.Controls.Add(this.cmbyanbu);
            this.groupBox6.Controls.Add(this.cmbkouchun);
            this.groupBox6.Controls.Add(this.label34);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.ckbzc);
            this.groupBox6.Location = new System.Drawing.Point(9, 23);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1268, 170);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "口腔";
            // 
            // tbPharyngealEx
            // 
            this.tbPharyngealEx.Location = new System.Drawing.Point(907, 19);
            this.tbPharyngealEx.Name = "tbPharyngealEx";
            this.tbPharyngealEx.ReadOnly = true;
            this.tbPharyngealEx.Size = new System.Drawing.Size(185, 36);
            this.tbPharyngealEx.TabIndex = 3;
            // 
            // tbLipsEx
            // 
            this.tbLipsEx.Location = new System.Drawing.Point(304, 19);
            this.tbLipsEx.Name = "tbLipsEx";
            this.tbLipsEx.ReadOnly = true;
            this.tbLipsEx.Size = new System.Drawing.Size(221, 36);
            this.tbLipsEx.TabIndex = 1;
            // 
            // panelTooth
            // 
            this.panelTooth.Controls.Add(this.tbToothResidesOther);
            this.panelTooth.Controls.Add(this.tbQuUpR);
            this.panelTooth.Controls.Add(this.tbYiUpR);
            this.panelTooth.Controls.Add(this.tbQueUpRight);
            this.panelTooth.Controls.Add(this.tbQuDownR);
            this.panelTooth.Controls.Add(this.tbYiDownR);
            this.panelTooth.Controls.Add(this.tbQueDownRight);
            this.panelTooth.Controls.Add(this.tbQuDownL);
            this.panelTooth.Controls.Add(this.tbYiDownL);
            this.panelTooth.Controls.Add(this.tbQueDownLeft);
            this.panelTooth.Controls.Add(this.tbQuUpL);
            this.panelTooth.Controls.Add(this.tbYiUpL);
            this.panelTooth.Controls.Add(this.tbQueUpLeft);
            this.panelTooth.Controls.Add(this.ckbyc);
            this.panelTooth.Controls.Add(this.ckbquec);
            this.panelTooth.Controls.Add(this.ckbqit);
            this.panelTooth.Controls.Add(this.ckbquc);
            this.panelTooth.Location = new System.Drawing.Point(132, 65);
            this.panelTooth.Name = "panelTooth";
            this.panelTooth.Size = new System.Drawing.Size(1116, 99);
            this.panelTooth.TabIndex = 7;
            // 
            // tbToothResidesOther
            // 
            this.tbToothResidesOther.Location = new System.Drawing.Point(824, 10);
            this.tbToothResidesOther.Name = "tbToothResidesOther";
            this.tbToothResidesOther.ReadOnly = true;
            this.tbToothResidesOther.Size = new System.Drawing.Size(139, 36);
            this.tbToothResidesOther.TabIndex = 16;
            // 
            // tbQuUpR
            // 
            this.tbQuUpR.Location = new System.Drawing.Point(367, 9);
            this.tbQuUpR.Name = "tbQuUpR";
            this.tbQuUpR.ReadOnly = true;
            this.tbQuUpR.Size = new System.Drawing.Size(60, 36);
            this.tbQuUpR.TabIndex = 7;
            this.tbQuUpR.TextChanged += new System.EventHandler(this.tbQuUpR_TextChanged);
            // 
            // tbYiUpR
            // 
            this.tbYiUpR.Location = new System.Drawing.Point(669, 9);
            this.tbYiUpR.Name = "tbYiUpR";
            this.tbYiUpR.ReadOnly = true;
            this.tbYiUpR.Size = new System.Drawing.Size(60, 36);
            this.tbYiUpR.TabIndex = 12;
            this.tbYiUpR.TextChanged += new System.EventHandler(this.tbYiUpR_TextChanged);
            // 
            // tbQueUpRight
            // 
            this.tbQueUpRight.Location = new System.Drawing.Point(144, 9);
            this.tbQueUpRight.Name = "tbQueUpRight";
            this.tbQueUpRight.ReadOnly = true;
            this.tbQueUpRight.Size = new System.Drawing.Size(60, 36);
            this.tbQueUpRight.TabIndex = 2;
            this.tbQueUpRight.TextChanged += new System.EventHandler(this.tbQueUpRight_TextChanged);
            // 
            // tbQuDownR
            // 
            this.tbQuDownR.Location = new System.Drawing.Point(365, 58);
            this.tbQuDownR.Name = "tbQuDownR";
            this.tbQuDownR.ReadOnly = true;
            this.tbQuDownR.Size = new System.Drawing.Size(60, 36);
            this.tbQuDownR.TabIndex = 9;
            this.tbQuDownR.TextChanged += new System.EventHandler(this.tbQuDownR_TextChanged);
            // 
            // tbYiDownR
            // 
            this.tbYiDownR.Location = new System.Drawing.Point(668, 58);
            this.tbYiDownR.Name = "tbYiDownR";
            this.tbYiDownR.ReadOnly = true;
            this.tbYiDownR.Size = new System.Drawing.Size(60, 36);
            this.tbYiDownR.TabIndex = 14;
            this.tbYiDownR.TextChanged += new System.EventHandler(this.tbYiDownR_TextChanged);
            // 
            // tbQueDownRight
            // 
            this.tbQueDownRight.Location = new System.Drawing.Point(144, 58);
            this.tbQueDownRight.Name = "tbQueDownRight";
            this.tbQueDownRight.ReadOnly = true;
            this.tbQueDownRight.Size = new System.Drawing.Size(60, 36);
            this.tbQueDownRight.TabIndex = 4;
            this.tbQueDownRight.TextChanged += new System.EventHandler(this.tbQueDownRight_TextChanged);
            // 
            // tbQuDownL
            // 
            this.tbQuDownL.Location = new System.Drawing.Point(297, 58);
            this.tbQuDownL.Name = "tbQuDownL";
            this.tbQuDownL.ReadOnly = true;
            this.tbQuDownL.Size = new System.Drawing.Size(60, 36);
            this.tbQuDownL.TabIndex = 8;
            this.tbQuDownL.TextChanged += new System.EventHandler(this.tbQuDownL_TextChanged);
            // 
            // tbYiDownL
            // 
            this.tbYiDownL.Location = new System.Drawing.Point(601, 58);
            this.tbYiDownL.Name = "tbYiDownL";
            this.tbYiDownL.ReadOnly = true;
            this.tbYiDownL.Size = new System.Drawing.Size(60, 36);
            this.tbYiDownL.TabIndex = 13;
            this.tbYiDownL.TextChanged += new System.EventHandler(this.tbYiDownL_TextChanged);
            // 
            // tbQueDownLeft
            // 
            this.tbQueDownLeft.Location = new System.Drawing.Point(78, 58);
            this.tbQueDownLeft.Name = "tbQueDownLeft";
            this.tbQueDownLeft.ReadOnly = true;
            this.tbQueDownLeft.Size = new System.Drawing.Size(60, 36);
            this.tbQueDownLeft.TabIndex = 3;
            this.tbQueDownLeft.TextChanged += new System.EventHandler(this.tbQueDownLeft_TextChanged);
            // 
            // tbQuUpL
            // 
            this.tbQuUpL.Location = new System.Drawing.Point(297, 9);
            this.tbQuUpL.Name = "tbQuUpL";
            this.tbQuUpL.ReadOnly = true;
            this.tbQuUpL.Size = new System.Drawing.Size(60, 36);
            this.tbQuUpL.TabIndex = 6;
            this.tbQuUpL.TextChanged += new System.EventHandler(this.tbQuUpL_TextChanged);
            // 
            // tbYiUpL
            // 
            this.tbYiUpL.Location = new System.Drawing.Point(601, 9);
            this.tbYiUpL.Name = "tbYiUpL";
            this.tbYiUpL.ReadOnly = true;
            this.tbYiUpL.Size = new System.Drawing.Size(60, 36);
            this.tbYiUpL.TabIndex = 11;
            this.tbYiUpL.TextChanged += new System.EventHandler(this.tbYiUpL_TextChanged);
            // 
            // tbQueUpLeft
            // 
            this.tbQueUpLeft.Location = new System.Drawing.Point(78, 9);
            this.tbQueUpLeft.Name = "tbQueUpLeft";
            this.tbQueUpLeft.ReadOnly = true;
            this.tbQueUpLeft.Size = new System.Drawing.Size(60, 36);
            this.tbQueUpLeft.TabIndex = 1;
            this.tbQueUpLeft.TextChanged += new System.EventHandler(this.tbQueUpLeft_TextChanged);
            // 
            // ckbyc
            // 
            this.ckbyc.AutoSize = true;
            this.ckbyc.Location = new System.Drawing.Point(471, 15);
            this.ckbyc.Name = "ckbyc";
            this.ckbyc.Size = new System.Drawing.Size(164, 30);
            this.ckbyc.TabIndex = 10;
            this.ckbyc.Text = "义齿(假牙)";
            this.ckbyc.UseVisualStyleBackColor = true;
            this.ckbyc.CheckedChanged += new System.EventHandler(this.ckbyc_CheckedChanged);
            // 
            // ckbquec
            // 
            this.ckbquec.AutoSize = true;
            this.ckbquec.Location = new System.Drawing.Point(4, 17);
            this.ckbquec.Name = "ckbquec";
            this.ckbquec.Size = new System.Drawing.Size(86, 30);
            this.ckbquec.TabIndex = 0;
            this.ckbquec.Text = "缺齿";
            this.ckbquec.UseVisualStyleBackColor = true;
            this.ckbquec.CheckedChanged += new System.EventHandler(this.ckbquec_CheckedChanged);
            // 
            // ckbqit
            // 
            this.ckbqit.AutoSize = true;
            this.ckbqit.Location = new System.Drawing.Point(747, 13);
            this.ckbqit.Name = "ckbqit";
            this.ckbqit.Size = new System.Drawing.Size(86, 30);
            this.ckbqit.TabIndex = 15;
            this.ckbqit.Text = "其他";
            this.ckbqit.UseVisualStyleBackColor = true;
            this.ckbqit.CheckedChanged += new System.EventHandler(this.ckbqit_CheckedChanged);
            // 
            // ckbquc
            // 
            this.ckbquc.AutoSize = true;
            this.ckbquc.Location = new System.Drawing.Point(224, 16);
            this.ckbquc.Name = "ckbquc";
            this.ckbquc.Size = new System.Drawing.Size(86, 30);
            this.ckbquc.TabIndex = 5;
            this.ckbquc.Text = "龋齿";
            this.ckbquc.UseVisualStyleBackColor = true;
            this.ckbquc.CheckedChanged += new System.EventHandler(this.ckbquc_CheckedChanged);
            // 
            // cmbyanbu
            // 
            this.cmbyanbu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyanbu.FormattingEnabled = true;
            this.cmbyanbu.Items.AddRange(new object[] {
            "无充血",
            "充血",
            "淋巴滤泡增生",
            "其他"});
            this.cmbyanbu.Location = new System.Drawing.Point(732, 19);
            this.cmbyanbu.Name = "cmbyanbu";
            this.cmbyanbu.Size = new System.Drawing.Size(158, 33);
            this.cmbyanbu.TabIndex = 2;
            this.cmbyanbu.SelectedValueChanged += new System.EventHandler(this.cmbyanbu_SelectedValueChanged);
            // 
            // cmbkouchun
            // 
            this.cmbkouchun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbkouchun.FormattingEnabled = true;
            this.cmbkouchun.Items.AddRange(new object[] {
            "红润",
            "苍白",
            "发绀",
            "皲裂",
            "疱疹",
            "其他"});
            this.cmbkouchun.Location = new System.Drawing.Point(132, 19);
            this.cmbkouchun.Name = "cmbkouchun";
            this.cmbkouchun.Size = new System.Drawing.Size(158, 33);
            this.cmbkouchun.TabIndex = 0;
            this.cmbkouchun.SelectedValueChanged += new System.EventHandler(this.cmbkouchun_SelectedValueChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(659, 23);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(77, 26);
            this.label34.TabIndex = 17;
            this.label34.Text = "咽 部";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(54, 52);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(77, 26);
            this.label32.TabIndex = 12;
            this.label32.Text = "齿 列";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(54, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 26);
            this.label9.TabIndex = 6;
            this.label9.Text = "口 唇";
            // 
            // ckbzc
            // 
            this.ckbzc.AutoSize = true;
            this.ckbzc.Location = new System.Drawing.Point(45, 80);
            this.ckbzc.Name = "ckbzc";
            this.ckbzc.Size = new System.Drawing.Size(86, 30);
            this.ckbzc.TabIndex = 5;
            this.ckbzc.Text = "正常";
            this.ckbzc.UseVisualStyleBackColor = true;
            this.ckbzc.CheckedChanged += new System.EventHandler(this.ckbzc_CheckedChanged);
            // 
            // UCMedicalPhysique
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.groupBox44);
            this.Controls.Add(this.groupBox4);
            this.Name = "UCMedicalPhysique";
            this.Load += new System.EventHandler(this.UCMedicalPhysique_Load);
            this.VisibleChanged += new System.EventHandler(this.UCMedicalPhysique_VisibleChanged);
            this.groupBox44.ResumeLayout(false);
            this.groupBox44.PerformLayout();
            this.groupBox55.ResumeLayout(false);
            this.groupBox55.PerformLayout();
            this.groupBox54.ResumeLayout(false);
            this.groupBox54.PerformLayout();
            this.groupBox53.ResumeLayout(false);
            this.groupBox53.PerformLayout();
            this.groupBox52.ResumeLayout(false);
            this.groupBox52.PerformLayout();
            this.groupBox51.ResumeLayout(false);
            this.groupBox51.PerformLayout();
            this.groupBox50.ResumeLayout(false);
            this.groupBox50.PerformLayout();
            this.groupBox49.ResumeLayout(false);
            this.groupBox49.PerformLayout();
            this.groupBox48.ResumeLayout(false);
            this.groupBox48.PerformLayout();
            this.groupBox47.ResumeLayout(false);
            this.groupBox47.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox58.ResumeLayout(false);
            this.groupBox58.PerformLayout();
            this.groupBox57.ResumeLayout(false);
            this.groupBox57.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panelTooth.ResumeLayout(false);
            this.panelTooth.PerformLayout();
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {

        }

        private void SaveMedicalPhysiqueAndVisFun()
        {
            if (this.MediPhys != null)
            {
                RecordsMediPhysDistBLL recordsMediPhysDistBll = new RecordsMediPhysDistBLL();
                RecordsMedicineCnBLL MediBll = new RecordsMedicineCnBLL();
                RecordsMedicineResultBLL MediResultBll = new RecordsMedicineResultBLL();
                this.MediPhys.OutKey = PhysicalInfoFactory.ID;
                this.VisceraFunction.OutKey = PhysicalInfoFactory.ID;
                RecordsMediPhysDistModel MediPhyModel = new RecordsMediPhysDistBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
                this.MediPhys.MedicineID = 0;
                this.MediPhys.MedicineResultID = 0;
                if (MediPhyModel == null) //新增
                {
                    if (this.MedCn != null)
                    {
                        this.MediPhys.MedicineID = MediBll.Add(this.MedCn);
                    }

                    if (this.MedResult != null)
                    {
                        this.MediPhys.MedicineResultID = MediResultBll.Add(this.MedResult);
                    }
                    recordsMediPhysDistBll.Add(this.MediPhys);
                }
                else
                {
                    if (this.MedCn != null)
                    {
                        if (MediPhyModel.MedicineID == 0)//中医体质中，无体质辨识问卷
                        {
                            this.MediPhys.MedicineID = MediBll.Add(this.MedCn);
                        }
                        else //中医体质中，有体质辨识问卷
                        {
                            this.MedCn.ID = MediPhyModel.MedicineID;
                            this.MediPhys.MedicineID = MediPhyModel.MedicineID;
                            MediBll.Update(this.MedCn);
                        }
                    }
                    if (this.MedResult != null)
                    {
                        if (MediPhyModel.MedicineResultID == 0)
                        {
                            this.MediPhys.MedicineResultID = MediResultBll.Add(this.MedResult);
                        }
                        else
                        {
                            this.MedResult.ID = MediPhyModel.MedicineResultID;
                            this.MediPhys.MedicineResultID = MediPhyModel.MedicineResultID;
                            MediResultBll.Update(this.MedResult);
                        }
                    }
                    recordsMediPhysDistBll.Update(this.MediPhys);
                }
                RecordsVisceraFunctionBLL recordsVisceraFunctionBll = new RecordsVisceraFunctionBLL();
                if (recordsVisceraFunctionBll.ExistsOutKey(this.VisceraFunction.IDCardNo, PhysicalInfoFactory.ID))
                {
                    recordsVisceraFunctionBll.Update(this.VisceraFunction);
                }
                else
                {
                    recordsVisceraFunctionBll.Add(this.VisceraFunction);
                }
            }
        }

        public bool SaveModelToDB()
        {
            if (PhysicalInfoFactory.ID != -1)
            {
                this.SaveMedicalPhysiqueAndVisFun();
            }
            return true;
        }

        private void SetComoboxValue(ComboBox cbx, string info)
        {
            if (!string.IsNullOrEmpty(info))
            {
                int num;
                if (int.TryParse(info, out num))
                {
                    cbx.SelectedIndex = num - 1;
                }
            }

        }

        private void shili(TextBox tb, string pro)
        {
            Binding binding = new Binding("Text", this.VisceraFunction, pro, true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += new ConvertEventHandler(this.bd_Parse);
            tb.DataBindings.Add(binding);
        }

        private void UCMedicalPhysique_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }

        }

        public void UpdataToModel()
        {
            this.MediPhys.IDCardNo = this.Model.IDCardNo;
            this.MediPhys.Mild = this.pinghezhi.Result;
            this.MediPhys.Faint = this.qixuzhi.Result;
            this.MediPhys.Yang = this.yangxuzhi.Result;
            this.MediPhys.Yin = this.yinxuzhi.Result;
            this.MediPhys.PhlegmDamp = this.tanshizhi.Result;
            this.MediPhys.Muggy = this.shirezhi.Result;
            this.MediPhys.BloodStasis = this.xueyuzhi.Result;
            this.MediPhys.QiConstraint = this.qiyuzhi.Result;
            this.MediPhys.Characteristic = this.tejianzhi.Result;
            this.VisceraFunction.IDCardNo = this.Model.IDCardNo;
            if (this.cmbkouchun.SelectedIndex != -1)
            {
                this.VisceraFunction.Lips = Convert.ToString((int)(this.cmbkouchun.SelectedIndex + 1));
            }
            if (this.cmbyanbu.SelectedIndex != -1)
            {
                this.VisceraFunction.Pharyngeal = Convert.ToString((int)(this.cmbyanbu.SelectedIndex + 1));
            }
            
            // this.VisceraFunction.ToothResides = Convert.ToString((int) (this.cmbchilie.SelectedIndex + 1));
            // this.VisceraFunction.ToothResidesOther = this.txtchilieother.Text;
            string str2 = "";
            for (int k = 0; k < this.wxys.Count; k++)
            {
                if (this.wxys[k].Checked)
                {
                    str2 = str2 + string.Format("{0},", k + 1);
                }
            }
            string strquechi = this.tbQueUpLeft.Text + "#" + this.tbQueUpRight.Text + "#" + this.tbQueDownLeft.Text + "#" + this.tbQueDownRight.Text;
            this.VisceraFunction.HypodontiaEx = strquechi;
            string strquchi = this.tbQuUpL.Text + "#" + this.tbQuUpR.Text + "#" + this.tbQuDownL.Text + "#" + this.tbQuDownR.Text;
            this.VisceraFunction.SaprodontiaEx = strquchi;
            string stryichi = this.tbYiUpL.Text + "#" + this.tbYiUpR.Text + "#" + this.tbYiDownL.Text + "#" + this.tbYiDownR.Text;
            this.VisceraFunction.DentureEx = stryichi;
            this.VisceraFunction.ToothResides = str2.Trim(new char[] { ',' });
            this.VisceraFunction.SportFunction = this.yundong.Result;
            this.VisceraFunction.Listen = this.tingli.Result;
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        private RecordsMediPhysDistModel MediPhys { get; set; }

        public RecordsBaseInfoModel Model { get; set; }
        //RecordsGeneralConditionModel generalconditionmodel { get; set; }

        public string SaveDataInfo { get; set; }

        private RecordsVisceraFunctionModel VisceraFunction { get; set; }

        internal class Physique
        {
            public Physique(RadioButton r1, RadioButton r2, string info)
            {
                this.Rd1 = r1;
                this.Rd2 = r2;
                this.Result = info;
            }

            public Physique(string name, RadioButton r1, RadioButton r2, string info)
            {
                this.Rd1 = r1;
                this.Rd2 = r2;
                this.Name = name;
                this.Result = info;
            }

            public void Reset()
            {
                this.Rd1.Checked = false;
                this.Rd2.Checked = false;
            }

            public void Reset(string val)
            {
                if (!string.IsNullOrEmpty(val))
                {
                    this.Result = val;
                }
                else
                {
                    this.Reset();
                }
            }

            public string Name { get; set; }

            public RadioButton Rd1 { get; set; }

            public RadioButton Rd2 { get; set; }

            public string Result
            {
                get
                {
                    if (this.Rd1.Checked)
                    {
                        return "1";
                    }
                    if (this.Rd2.Checked)
                    {
                        return "2";
                    }
                    return null;
                }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (value == "1")
                        {
                            this.Rd1.Checked = true;
                        }
                        else if (value == "2")
                        {
                            this.Rd2.Checked = true;
                        }
                    }
                    //else if ((this.Name == "运动") || (this.Name == "听力"))
                    //{
                    //    this.Rd1.Checked = true;
                    //}
                }
            }
        }


        private void ckbzc_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbzc.Checked)
            {
                this.tbQuDownL.Clear();
                this.tbQuDownR.Clear();
                this.tbQuUpL.Clear();
                this.tbQuUpR.Clear();
                this.tbQueDownLeft.Clear();
                this.tbQueDownRight.Clear();
                this.tbQueUpLeft.Clear();
                this.tbQueUpRight.Clear();
                this.tbYiDownL.Clear();
                this.tbYiDownR.Clear();
                this.tbYiUpL.Clear();
                this.tbYiUpR.Clear();
                this.tbToothResidesOther.Clear();
                panelTooth.Enabled = false;
                this.ckbquec.Checked = false;
                this.ckbquc.Checked = false;
                this.ckbyc.Checked = false;
                this.ckbqit.Checked = false;
            }
            else
            {
                panelTooth.Enabled = true;
            }
        }

        private void ckbquec_CheckedChanged(object sender, EventArgs e)
        {

            if (this.ckbquec.Checked)
            {
                this.ckbzc.Checked = false;
                this.tbQueUpLeft.ReadOnly = false;
                this.tbQueUpRight.ReadOnly = false;
                this.tbQueDownLeft.ReadOnly = false;
                this.tbQueDownRight.ReadOnly = false;
            }
            else
            {
                this.tbQueUpLeft.Clear();
                this.tbQueUpRight.Clear();
                this.tbQueDownLeft.Clear();
                this.tbQueDownRight.Clear();
            }
        }

        private void ckbquc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbquc.Checked)
            {
                this.ckbzc.Checked = false;
                this.tbQuDownL.ReadOnly = false;
                this.tbQuDownR.ReadOnly = false;
                this.tbQuUpL.ReadOnly = false;
                this.tbQuUpR.ReadOnly = false;
            }
            else
            {
                this.tbQuDownL.Clear();
                this.tbQuDownR.Clear();
                this.tbQuUpL.Clear();
                this.tbQuUpR.Clear();
            }
        }

        private void ckbyc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbyc.Checked)
            {
                this.ckbzc.Checked = false;
                this.tbYiDownL.ReadOnly = false;
                this.tbYiDownR.ReadOnly = false;
                this.tbYiUpL.ReadOnly = false;
                this.tbYiUpR.ReadOnly = false;
            }
            else
            {
                this.tbYiDownL.Clear();
                this.tbYiDownR.Clear();
                this.tbYiUpL.Clear();
                this.tbYiUpR.Clear();
            }
        }
        private void ckbqit_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbqit.Checked)
            {
                this.ckbzc.Checked = false;
                this.tbToothResidesOther.ReadOnly = false;
            }
            else
            {
                this.tbToothResidesOther.Clear();
                this.tbToothResidesOther.ReadOnly = true;
            }
        }
        private void tbQueUpLeft_TextChanged(object sender, EventArgs e)
        {
            if (this.tbQueUpLeft.Text.Contains("#"))
            {
                this.tbQueUpLeft.Clear();
            }
        }

        private void tbQueUpRight_TextChanged(object sender, EventArgs e)
        {
            if (this.tbQueUpRight.Text.Contains("#"))
            {
                this.tbQueUpRight.Clear();
            }
        }

        private void tbQueDownLeft_TextChanged(object sender, EventArgs e)
        {
            if (this.tbQueDownLeft.Text.Contains("#"))
            {
                this.tbQueDownLeft.Clear();
            }
        }

        private void tbQueDownRight_TextChanged(object sender, EventArgs e)
        {
            if (this.tbQueDownRight.Text.Contains("#"))
            {
                this.tbQueDownRight.Clear();
            }
        }

        private void tbQuUpL_TextChanged(object sender, EventArgs e)
        {
            if (this.tbQuUpL.Text.Contains("#"))
            {
                this.tbQuUpL.Clear();
            }
        }

        private void tbQuUpR_TextChanged(object sender, EventArgs e)
        {
            if (this.tbQuUpR.Text.Contains("#"))
            {
                this.tbQuUpR.Clear();
            }
        }

        private void tbQuDownL_TextChanged(object sender, EventArgs e)
        {
            if (this.tbQuDownL.Text.Contains("#"))
            {
                this.tbQuDownL.Clear();
            }
        }

        private void tbQuDownR_TextChanged(object sender, EventArgs e)
        {
            if (this.tbQuDownR.Text.Contains("#"))
            {
                this.tbQuDownR.Clear();
            }
        }

        private void tbYiUpL_TextChanged(object sender, EventArgs e)
        {
            if (this.tbYiUpL.Text.Contains("#"))
            {
                this.tbYiUpL.Clear();
            }
        }

        private void tbYiUpR_TextChanged(object sender, EventArgs e)
        {
            if (this.tbYiUpR.Text.Contains("#"))
            {
                this.tbYiUpR.Clear();
            }
        }

        private void tbYiDownL_TextChanged(object sender, EventArgs e)
        {
            if (this.tbYiDownL.Text.Contains("#"))
            {
                this.tbYiDownL.Clear();
            }
        }

        private void tbYiDownR_TextChanged(object sender, EventArgs e)
        {
            if (this.tbYiDownR.Text.Contains("#"))
            {
                this.tbYiDownR.Clear();
            }
        }
        private void cmbkouchun_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cmbkouchun.Text == "其他")
            {
                this.tbLipsEx.ReadOnly = false;
            }
            else
            {
                this.tbLipsEx.Clear();
                this.tbLipsEx.ReadOnly = true;
            }
        }
        private void cmbyanbu_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cmbyanbu.Text == "其他")
            {
                this.tbPharyngealEx.ReadOnly = false;
            }
            else
            {
                this.tbPharyngealEx.Clear();
                this.tbPharyngealEx.ReadOnly = true;
            }
        }
        public decimal? CZBMI = null; //一般情况中的BMI传值
        public decimal? CZWaistline = null;//一般情况中的腰围传值
        private void UCMedicalPhysique_VisibleChanged(object sender, EventArgs e)
        {
            this.CZBMI = RecordsManageMentModel.BMI;
            this.CZWaistline = RecordsManageMentModel.Waistline;
            RecordsManageMentModel.RightView = VisceraFunction.RightView;
            RecordsManageMentModel.LeftView = VisceraFunction.LeftView;
            RecordsManageMentModel.Listen = this.tingli.Result;
            RecordsManageMentModel.SportFunction = this.yundong.Result;
        }

    }
}

