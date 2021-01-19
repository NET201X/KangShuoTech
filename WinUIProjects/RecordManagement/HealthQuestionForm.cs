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
    using System.Windows.Forms;
    using System.Data;
    using System.IO;
    using KangShuoTech.Utilities.Common;

    public class UCHealthQuestion : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<RecordsHealthQuestionModel> bindingManager;
        private CheckBox ckNxg2;
        private CheckBox ckNxg3;
        private CheckBox ckNxg4;
        private CheckBox ckNxg5;
        private CheckBox ckNxg6;
        private CheckBox ckSz1;
        private CheckBox ckSz2;
        private CheckBox ckSz3;
        private CheckBox ckSz4;
        private CheckBox ckSz5;
        private CheckBox ckSz6;
        private CheckBox ckXz1;
        private CheckBox ckXz2;
        private CheckBox ckXz3;
        private CheckBox ckXz4;
        private CheckBox ckXz5;
        private CheckBox ckXz6;
        private CheckBox ckXz10;
        private CheckBox ckYb1;
        private CheckBox ckYb2;
        private CheckBox ckYb3;
        private CheckBox ckYb4;
        private CheckBox ckYb5;
        private IContainer components;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox5;
        private GroupBox groupBox7;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private ManyCheckboxs<RecordsHealthQuestionModel> naoxueguan;        
        private ManyCheckboxs<RecordsHealthQuestionModel> shenzhang;
        private TextBox tbNxgOther;
        private TextBox tbSzOther;
        private TextBox tbXzOther;
        private TextBox tbYbOther;
        private TextBox txtqtxtjby;
        private TextBox txtsjxty;
        private GroupBox v;
        private ManyCheckboxs<RecordsHealthQuestionModel> xinzhang;
        private ManyCheckboxs<RecordsHealthQuestionModel> xueguan;
        private CheckBox ckNxg1;
        private CheckBox ckXz8;
        private CheckBox ckXz7;
        private CheckBox ckXz9;
        private CheckBox ckqita7;
        private CheckBox ckqita1;
        private CheckBox ckqita3;
        private CheckBox ckqita2;
        private CheckBox ckqita5;
        private CheckBox ckshenjing4;
        private CheckBox ckshenjing3;
        private CheckBox ckshenjing1;
        private CheckBox ckshenjing2;
        private CheckBox ckqita4;
        private CheckBox ckqita6;
        private ManyCheckboxs<RecordsHealthQuestionModel> yanbu;
        private ManyCheckboxs<RecordsHealthQuestionModel> shenjing;
        private GroupBox groupBox4;
        private CheckBox ckxzjb7;
        private TextBox tbxzjbqt;
        private CheckBox ckxzjb6;
        private CheckBox ckxzjb5;
        private CheckBox ckxzjb4;
        private CheckBox ckxzjb3;
        private CheckBox ckxzjb2;
        private CheckBox ckxzjb1;
        private GroupBox groupBox6;
        private CheckBox ckxg3;
        private CheckBox ckxg2;
        private CheckBox ckxg4;
        private TextBox tbxgqt;
        private CheckBox ckxg1;
        private ManyCheckboxs<RecordsHealthQuestionModel> qita;
        private DataSet dsRequire;
        private string area = ConfigHelper.GetSetNode("area");
        private ConvertDBCAndSBC common = new ConvertDBCAndSBC();
        private string community = ConfigHelper.GetSetNode("community");

        public UCHealthQuestion()
        {
            this.InitializeComponent();

            this.groupBox4.Visible = false;
            this.groupBox6.Visible = false;
            this.groupBox3.Visible = true;

            this.EveryThingIsOk = false;
        }

        public ChildFormStatus CheckErrorInput()
        {
            if ((!this.naoxueguan.ErrorInput && !this.shenzhang.ErrorInput) && ((!this.xinzhang.ErrorInput && !this.shenjing.ErrorInput) && (!this.yanbu.ErrorInput && !this.qita.ErrorInput)))
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
            dsRequire = new RequireBLL().GetList("TabName = '健康体检' AND Comment = '健康问题' ");
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("BrainOther", 500));
            this.inputrange_str.Add(new InputRangeStr("RenalOther", 500));
            this.inputrange_str.Add(new InputRangeStr("HeartOther", 500));
            this.inputrange_str.Add(new InputRangeStr("VesselOther", 500));
            this.inputrange_str.Add(new InputRangeStr("EyeOther", 500));
            this.inputRanges = new List<InputRangeDec>();
            this.HealthQuestion = new RecordsHealthQuestionBLL().GetModelByOutKey(PhysicalInfoFactory.ID);

            if (this.HealthQuestion == null) this.HealthQuestion = new RecordsHealthQuestionModel();

            if (PhysicalInfoFactory.falgID == 0)
            {
                this.PresetValue();

                if (community == "小孟镇")
                {
                    DataTable dt = new RecordsIllnessHistoryInfoBLL().GetList($" IDCardNo='{this.Model.IDCardNo}'").Tables[0];

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["IllnessName"].ToString() == "3") HealthQuestion.ElseDis = "2";
                            if (dr["IllnessName"].ToString() == "2") HealthQuestion.HeartDis = "7";
                        }
                    }
                }
            }

            this.bindingManager = new SimpleBindingManager<RecordsHealthQuestionModel>(this.inputRanges, this.inputrange_str, this.HealthQuestion);
            this.naoxueguan = new ManyCheckboxs<RecordsHealthQuestionModel>(this.HealthQuestion, 500);
            this.naoxueguan.AddCk(this.ckNxg1, true);
            this.naoxueguan.AddCk(new CheckBox[] { this.ckNxg2, this.ckNxg3, this.ckNxg4, this.ckNxg5 });
            this.naoxueguan.AddCk(this.ckNxg6, this.tbNxgOther);
            this.naoxueguan.BindingProperty("BrainDis", "BrainOther");
            this.shenzhang = new ManyCheckboxs<RecordsHealthQuestionModel>(this.HealthQuestion, 500);
            this.shenzhang.AddCk(this.ckSz1, true);
            this.shenzhang.AddCk(new CheckBox[] { this.ckSz2, this.ckSz3, this.ckSz4, this.ckSz5 });
            this.shenzhang.AddCk(this.ckSz6, this.tbSzOther);
            this.shenzhang.BindingProperty("RenalDis", "RenalOther");
            this.xinzhang = new ManyCheckboxs<RecordsHealthQuestionModel>(this.HealthQuestion, 500);
            this.xinzhang.AddCk(this.ckXz1, true);
            this.xinzhang.AddCk(new CheckBox[] { this.ckXz2, this.ckXz3, this.ckXz4, this.ckXz5, this.ckXz6, this.ckXz7, this.ckXz8, this.ckXz9 });
            this.xinzhang.AddCk(this.ckXz10, this.tbXzOther);
            this.xinzhang.BindingProperty("HeartDis", "HeartOther");
            this.yanbu = new ManyCheckboxs<RecordsHealthQuestionModel>(this.HealthQuestion, 500);
            this.yanbu.AddCk(this.ckYb1, true);
            this.yanbu.AddCk(new CheckBox[] { this.ckYb2, this.ckYb3, this.ckYb4 });
            this.yanbu.AddCk(this.ckYb5, this.tbYbOther);
            this.yanbu.BindingProperty("EyeDis", "EyeOther");
            this.shenjing = new ManyCheckboxs<RecordsHealthQuestionModel>(this.HealthQuestion, 500);
            this.shenjing.AddCk(this.ckshenjing1, true);
            this.shenjing.AddCk(new CheckBox[] { this.ckshenjing2, this.ckshenjing3 });
            this.shenjing.AddCk(this.ckshenjing4, this.txtsjxty);
            this.shenjing.BindingProperty("NerveDis", "NerveOther");
            this.qita = new ManyCheckboxs<RecordsHealthQuestionModel>(this.HealthQuestion, 500);
            this.qita.AddCk(this.ckqita1, true);
            this.qita.AddCk(new CheckBox[] { this.ckqita2, this.ckqita3, this.ckqita4, this.ckqita5, this.ckqita6 });
            this.qita.AddCk(this.ckqita7, this.txtqtxtjby);
            this.qita.BindingProperty("ElseDis", "ElseOther");

            #region 疾病默认
            if (area.Equals("威海"))
            {
                if (!string.IsNullOrEmpty(this.Model.PopulationType))
                {
                    if (this.Model.PopulationType.Contains("6"))//高血压
                    {
                        this.ckXz1.Checked = false;
                        this.ckXz7.Checked = true;
                    }
                    if (this.Model.PopulationType.Contains("7"))//糖尿病
                    {
                        this.ckqita1.Checked = false;
                        this.ckqita2.Checked = true;
                    }
                    if (this.Model.PopulationType.Contains("5"))//重精神病
                    {
                        this.ckqita7.Checked = true;
                        this.ckqita1.Checked = false;
                        if (!common.toString(this.HealthQuestion.ElseOther).Contains("重精神病"))
                        {
                            this.HealthQuestion.ElseOther += "重精神病;";
                        }
                    }
                    if (this.Model.PopulationType.Contains("8"))//冠心病
                    {
                        this.ckqita7.Checked = true;

                        if (!common.toString(this.HealthQuestion.ElseOther).Contains("冠心病"))
                        {
                            this.HealthQuestion.ElseOther += "冠心病;";
                        }
                        this.ckqita1.Checked = false;
                    }
                    if (this.Model.PopulationType.Contains("9"))//脑卒中
                    {
                        this.ckqita7.Checked = true;

                        if (!common.toString(this.HealthQuestion.ElseOther).Contains("脑卒中"))
                        {
                            this.HealthQuestion.ElseOther += "脑卒中;";
                        }
                        this.ckqita1.Checked = false;
                    }
                    if (this.Model.PopulationType.Contains("10"))//肺结核
                    {
                        this.ckqita7.Checked = true;
                        if (!common.toString(this.HealthQuestion.ElseOther).Contains("肺结核"))
                        {
                            this.HealthQuestion.ElseOther += "肺结核;";
                        }
                        this.ckqita1.Checked = false;
                    }
                }
            }
            else
            {
                List<RecordsIllnessHistoryInfoModel> IllnessHistoryInfoTem = new RecordsIllnessHistoryInfoBLL().GetModelList(string.Format(" IDCardNo = '{0}' AND IllnessType='1'", this.Model.IDCardNo));

                if (IllnessHistoryInfoTem.Count > 0)
                {
                    if (IllnessHistoryInfoTem.Exists(c => c.IllnessName == ("2")))//高血压
                    {
                        this.ckXz7.Checked = true;
                        this.ckXz1.Checked = false;
                    }
                    if (IllnessHistoryInfoTem.Exists(c => c.IllnessName == ("3")))//糖尿病
                    {
                        this.ckqita2.Checked = true;
                        this.ckqita1.Checked = false;
                    }
                    if (IllnessHistoryInfoTem.Exists(c => c.IllnessName == ("4")))//冠心病
                    {
                        this.ckXz10.Checked = true;
                        if (!common.toString(this.HealthQuestion.HeartOther).Contains("冠心病"))
                        {
                            this.HealthQuestion.HeartOther += "冠心病;";
                        }
                        this.ckXz1.Checked = false;
                    }

                    if (IllnessHistoryInfoTem.Exists(c => c.IllnessName == ("5")))//慢性阻塞性肺疾病
                    {
                        this.ckqita7.Checked = true;
                        if (!common.toString(this.HealthQuestion.ElseOther).Contains("慢性阻塞性肺疾病"))
                        {
                            this.HealthQuestion.ElseOther += "慢性阻塞性肺疾病;";
                        }
                        this.ckqita1.Checked = false;
                    }
                    if (IllnessHistoryInfoTem.Exists(c => c.IllnessName == ("6")))//恶性肿瘤
                    {
                        this.ckqita7.Checked = true;
                        if (!common.toString(this.HealthQuestion.ElseOther).Contains("恶性肿瘤"))
                        {
                            this.HealthQuestion.ElseOther += "恶性肿瘤:" + IllnessHistoryInfoTem.Find(c => c.IllnessName == ("6")).Therioma;
                        }
                        this.ckqita1.Checked = false;
                    }
                    if (IllnessHistoryInfoTem.Exists(c => c.IllnessName == ("7")))//脑卒中
                    {
                        this.ckqita7.Checked = true;

                        if (!common.toString(this.HealthQuestion.ElseOther).Contains("脑卒中"))
                        {
                            this.HealthQuestion.ElseOther += "脑卒中;";
                        }
                        this.ckqita1.Checked = false;
                    }
                    if (IllnessHistoryInfoTem.Exists(c => c.IllnessName == ("8")))//重精神病
                    {
                        this.ckqita7.Checked = true;
                        this.ckqita1.Checked = false;

                        if (!common.toString(this.HealthQuestion.ElseOther).Contains("重精神病"))
                        {
                            this.HealthQuestion.ElseOther += "重精神病;";
                        }
                    }
                    if (IllnessHistoryInfoTem.Exists(c => c.IllnessName == ("9")))//结核病
                    {
                        this.ckqita7.Checked = true;
                        if (!common.toString(this.HealthQuestion.ElseOther).Contains("结核病"))
                        {
                            this.HealthQuestion.ElseOther += "结核病;";
                        }
                        this.ckqita1.Checked = false;
                    }
                    if (IllnessHistoryInfoTem.Exists(c => c.IllnessName == ("10")))//肝炎
                    {
                        this.ckqita7.Checked = true;

                        if (!common.toString(this.HealthQuestion.ElseOther).Contains("肝炎"))
                        {
                            this.HealthQuestion.ElseOther += "肝炎;";
                        }
                        this.ckqita1.Checked = false;
                    }
                    if (IllnessHistoryInfoTem.Exists(c => c.IllnessName == ("11")))//其他法定传染病
                    {
                        this.ckqita7.Checked = true;
                        if (!common.toString(this.HealthQuestion.ElseOther).Contains("其他法定传染病"))
                        {
                            this.HealthQuestion.ElseOther += "其他法定传染病;";
                        }
                        this.ckqita1.Checked = false;
                    }
                    if (IllnessHistoryInfoTem.Exists(c => c.IllnessName == ("12")))//职业病
                    {
                        this.ckqita7.Checked = true;
                        if (!common.toString(this.HealthQuestion.ElseOther).Contains("职业病"))
                        {
                            this.HealthQuestion.ElseOther += "职业病:" + IllnessHistoryInfoTem.Find(c => c.IllnessName == ("12")).JobIllness + ";";
                        }
                        this.ckqita1.Checked = false;
                    }
                    if (IllnessHistoryInfoTem.Exists(c => c.IllnessName == ("13")))//其他
                    {
                        this.ckqita7.Checked = true;
                        if (!common.toString(this.HealthQuestion.ElseOther).Contains("其他"))
                        {
                            this.HealthQuestion.ElseOther += "其他:" + IllnessHistoryInfoTem.Find(c => c.IllnessName == ("13")).IllnessOther + ";";
                        }
                        this.ckqita1.Checked = false;
                    }
                }
            }
            

            #endregion

            MustChoose();
            this.EveryThingIsOk = true;
        }

        //默认项设置
        private void PresetValue()
        {
            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = " IsSetValue='是' or IsSetValue='预设上次体检' ";
            DataTable dt = dv.ToTable();
            RecordsHealthQuestionModel HealthQuestions = new RecordsHealthQuestionModel();
            RecordsCustomerBaseInfoModel CustomerBaseInfos = new RecordsCustomerBaseInfoBLL().GetMaxModel(this.Model.IDCardNo);//获取最新一笔体检数据
            if (CustomerBaseInfos != null)
            {
                HealthQuestions = new RecordsHealthQuestionBLL().GetModelByOutKey(CustomerBaseInfos.ID);
            }
            foreach (DataRow item in dt.Rows)
            {
                switch (item["ChinName"].ToString())
                {
                    case "肾脏疾病":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.HealthQuestion.RenalDis = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.HealthQuestion.RenalDis = HealthQuestions.RenalDis;
                            this.HealthQuestion.RenalOther = HealthQuestions.RenalOther;
                        }
                        break;
                    case "脑血管疾病":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.HealthQuestion.BrainDis = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.HealthQuestion.BrainDis = HealthQuestions.BrainDis;
                            this.HealthQuestion.BrainOther = HealthQuestions.BrainOther;
                        }
                        break;
                    //case "心脏疾病":
                    //    if (item["IsSetValue"].ToString() == "是")
                    //    {
                    //        this.HealthQuestion.BrainDis = item["ItemValue"].ToString();
                    //    }
                    //    else
                    //    {
                    //        this.HealthQuestion.BrainDis = HealthQuestions.BrainDis;
                    //        this.HealthQuestion.BrainDis = HealthQuestions.BrainDis;
                    //    }
                    //    break;
                    case "心血管疾病":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.HealthQuestion.HeartDis = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.HealthQuestion.HeartDis = HealthQuestions.HeartDis;
                            this.HealthQuestion.HeartOther = HealthQuestions.HeartOther;
                        }
                        break;
                    case "眼部疾病":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.HealthQuestion.EyeDis = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.HealthQuestion.EyeDis = HealthQuestions.EyeDis;
                            this.HealthQuestion.EyeOther = HealthQuestions.EyeOther;
                        }
                        break;
                    case "神经系统疾病":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.HealthQuestion.NerveDis = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.HealthQuestion.NerveDis = HealthQuestions.NerveDis;
                            this.HealthQuestion.NerveOther = HealthQuestions.NerveOther;
                        }
                        break;
                    case "其他系统疾病":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.HealthQuestion.ElseDis = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.HealthQuestion.ElseDis = HealthQuestions.ElseDis;
                            this.HealthQuestion.ElseOther = HealthQuestions.ElseOther;
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
            RecordsHealthQuestionModel HealthQuestions = new RecordsHealthQuestionBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            if (HealthQuestions == null) HealthQuestions = new RecordsHealthQuestionModel();
            foreach (DataRow item in dt.Rows)
            {
                if (item["Isrequired"].ToString() == "1")
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "脑血管疾病":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthQuestions.BrainDis)))
                            {
                                this.groupBox1.Text = "*脑血管疾病";
                                this.groupBox1.ForeColor = System.Drawing.Color.Red;
                                this.ckNxg1.ForeColor = System.Drawing.Color.Black;
                                this.ckNxg2.ForeColor = System.Drawing.Color.Black;
                                this.ckNxg3.ForeColor = System.Drawing.Color.Black;
                                this.ckNxg4.ForeColor = System.Drawing.Color.Black;
                                this.ckNxg5.ForeColor = System.Drawing.Color.Black;
                                this.ckNxg6.ForeColor = System.Drawing.Color.Black;
                                this.tbNxgOther.ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                this.groupBox1.Text = "脑血管疾病";
                                this.groupBox1.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "肾脏疾病":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthQuestions.RenalDis)))
                            {
                                this.groupBox2.Text = "*肾脏疾病";
                                this.groupBox2.ForeColor = System.Drawing.Color.Red;
                                this.ckSz1.ForeColor = System.Drawing.Color.Black;
                                this.ckSz2.ForeColor = System.Drawing.Color.Black;
                                this.ckSz3.ForeColor = System.Drawing.Color.Black;
                                this.ckSz4.ForeColor = System.Drawing.Color.Black;
                                this.ckSz5.ForeColor = System.Drawing.Color.Black;
                                this.ckSz6.ForeColor = System.Drawing.Color.Black;
                                this.tbSzOther.ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                this.groupBox2.Text = "肾脏疾病";
                                this.groupBox2.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "心血管疾病":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthQuestions.HeartDis)))
                            {
                                this.groupBox3.Text = "*心血管疾病";
                                this.groupBox3.ForeColor = System.Drawing.Color.Red;
                                this.ckXz1.ForeColor = System.Drawing.Color.Black;
                                this.ckXz2.ForeColor = System.Drawing.Color.Black;
                                this.ckXz3.ForeColor = System.Drawing.Color.Black;
                                this.ckXz4.ForeColor = System.Drawing.Color.Black;
                                this.ckXz5.ForeColor = System.Drawing.Color.Black;
                                this.ckXz6.ForeColor = System.Drawing.Color.Black;
                                this.ckXz7.ForeColor = System.Drawing.Color.Black;
                                this.ckXz8.ForeColor = System.Drawing.Color.Black;
                                this.ckXz9.ForeColor = System.Drawing.Color.Black;
                                this.ckXz10.ForeColor = System.Drawing.Color.Black;
                                this.tbXzOther.ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                this.groupBox3.Text = "心血管疾病";
                                this.groupBox3.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "眼部疾病":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthQuestions.EyeDis)))
                            {
                                this.groupBox5.Text = "*眼部疾病";
                                this.groupBox5.ForeColor = System.Drawing.Color.Red;
                                this.ckYb1.ForeColor = System.Drawing.Color.Black;
                                this.ckYb2.ForeColor = System.Drawing.Color.Black;
                                this.ckYb3.ForeColor = System.Drawing.Color.Black;
                                this.ckYb4.ForeColor = System.Drawing.Color.Black;
                                this.ckYb5.ForeColor = System.Drawing.Color.Black;
                                this.tbYbOther.ForeColor = System.Drawing.Color.Black;

                            }
                            else
                            {
                                this.groupBox5.Text = "眼部疾病";
                                this.groupBox5.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "神经系统疾病":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthQuestions.NerveDis)))
                            {
                                this.v.Text = "*神经系统其他疾病";
                                this.v.ForeColor = System.Drawing.Color.Red;
                                this.ckshenjing1.ForeColor = System.Drawing.Color.Black;
                                this.ckshenjing2.ForeColor = System.Drawing.Color.Black;
                                this.ckshenjing3.ForeColor = System.Drawing.Color.Black;
                                this.ckshenjing4.ForeColor = System.Drawing.Color.Black;
                                this.txtsjxty.ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                this.v.Text = " 神经系统其他疾病";
                                this.v.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "其他系统疾病":
                            if (string.IsNullOrEmpty(Convert.ToString(HealthQuestions.ElseDis)))
                            {
                                this.groupBox7.Text = "*其他系统疾病";
                                this.groupBox7.ForeColor = System.Drawing.Color.Red;
                                this.ckqita1.ForeColor = System.Drawing.Color.Black;
                                this.ckqita2.ForeColor = System.Drawing.Color.Black;
                                this.ckqita3.ForeColor = System.Drawing.Color.Black;
                                this.ckqita4.ForeColor = System.Drawing.Color.Black;
                                this.ckqita5.ForeColor = System.Drawing.Color.Black;
                                this.ckqita6.ForeColor = System.Drawing.Color.Black;
                                this.ckqita7.ForeColor = System.Drawing.Color.Black;
                                this.txtqtxtjby.ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                this.groupBox7.Text = "其他系统疾病";
                                this.groupBox7.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        default: break;
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ckqita7 = new System.Windows.Forms.CheckBox();
            this.txtqtxtjby = new System.Windows.Forms.TextBox();
            this.ckqita1 = new System.Windows.Forms.CheckBox();
            this.ckqita3 = new System.Windows.Forms.CheckBox();
            this.ckqita2 = new System.Windows.Forms.CheckBox();
            this.ckqita4 = new System.Windows.Forms.CheckBox();
            this.ckqita6 = new System.Windows.Forms.CheckBox();
            this.ckqita5 = new System.Windows.Forms.CheckBox();
            this.v = new System.Windows.Forms.GroupBox();
            this.ckshenjing4 = new System.Windows.Forms.CheckBox();
            this.txtsjxty = new System.Windows.Forms.TextBox();
            this.ckshenjing3 = new System.Windows.Forms.CheckBox();
            this.ckshenjing1 = new System.Windows.Forms.CheckBox();
            this.ckshenjing2 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNxgOther = new System.Windows.Forms.TextBox();
            this.ckNxg6 = new System.Windows.Forms.CheckBox();
            this.ckNxg5 = new System.Windows.Forms.CheckBox();
            this.ckNxg4 = new System.Windows.Forms.CheckBox();
            this.ckNxg3 = new System.Windows.Forms.CheckBox();
            this.ckNxg2 = new System.Windows.Forms.CheckBox();
            this.ckNxg1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbSzOther = new System.Windows.Forms.TextBox();
            this.ckSz6 = new System.Windows.Forms.CheckBox();
            this.ckSz5 = new System.Windows.Forms.CheckBox();
            this.ckSz4 = new System.Windows.Forms.CheckBox();
            this.ckSz3 = new System.Windows.Forms.CheckBox();
            this.ckSz2 = new System.Windows.Forms.CheckBox();
            this.ckSz1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckXz10 = new System.Windows.Forms.CheckBox();
            this.tbXzOther = new System.Windows.Forms.TextBox();
            this.ckXz9 = new System.Windows.Forms.CheckBox();
            this.ckXz8 = new System.Windows.Forms.CheckBox();
            this.ckXz7 = new System.Windows.Forms.CheckBox();
            this.ckXz6 = new System.Windows.Forms.CheckBox();
            this.ckXz5 = new System.Windows.Forms.CheckBox();
            this.ckXz4 = new System.Windows.Forms.CheckBox();
            this.ckXz3 = new System.Windows.Forms.CheckBox();
            this.ckXz2 = new System.Windows.Forms.CheckBox();
            this.ckXz1 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ckYb5 = new System.Windows.Forms.CheckBox();
            this.tbYbOther = new System.Windows.Forms.TextBox();
            this.ckYb4 = new System.Windows.Forms.CheckBox();
            this.ckYb3 = new System.Windows.Forms.CheckBox();
            this.ckYb2 = new System.Windows.Forms.CheckBox();
            this.ckYb1 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckxzjb7 = new System.Windows.Forms.CheckBox();
            this.tbxzjbqt = new System.Windows.Forms.TextBox();
            this.ckxzjb6 = new System.Windows.Forms.CheckBox();
            this.ckxzjb5 = new System.Windows.Forms.CheckBox();
            this.ckxzjb4 = new System.Windows.Forms.CheckBox();
            this.ckxzjb3 = new System.Windows.Forms.CheckBox();
            this.ckxzjb2 = new System.Windows.Forms.CheckBox();
            this.ckxzjb1 = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ckxg3 = new System.Windows.Forms.CheckBox();
            this.ckxg2 = new System.Windows.Forms.CheckBox();
            this.ckxg4 = new System.Windows.Forms.CheckBox();
            this.tbxgqt = new System.Windows.Forms.TextBox();
            this.ckxg1 = new System.Windows.Forms.CheckBox();
            this.groupBox7.SuspendLayout();
            this.v.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ckqita7);
            this.groupBox7.Controls.Add(this.txtqtxtjby);
            this.groupBox7.Controls.Add(this.ckqita1);
            this.groupBox7.Controls.Add(this.ckqita3);
            this.groupBox7.Controls.Add(this.ckqita2);
            this.groupBox7.Controls.Add(this.ckqita4);
            this.groupBox7.Controls.Add(this.ckqita6);
            this.groupBox7.Controls.Add(this.ckqita5);
            this.groupBox7.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox7.Location = new System.Drawing.Point(104, 388);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1349, 113);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "其他系统疾病";
            // 
            // ckqita7
            // 
            this.ckqita7.AutoSize = true;
            this.ckqita7.Location = new System.Drawing.Point(6, 73);
            this.ckqita7.Name = "ckqita7";
            this.ckqita7.Size = new System.Drawing.Size(68, 24);
            this.ckqita7.TabIndex = 4;
            this.ckqita7.Text = "其他";
            this.ckqita7.UseVisualStyleBackColor = true;
            // 
            // txtqtxtjby
            // 
            this.txtqtxtjby.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtqtxtjby.Font = new System.Drawing.Font("宋体", 15F);
            this.txtqtxtjby.Location = new System.Drawing.Point(103, 73);
            this.txtqtxtjby.MaxLength = 100;
            this.txtqtxtjby.Name = "txtqtxtjby";
            this.txtqtxtjby.ReadOnly = true;
            this.txtqtxtjby.Size = new System.Drawing.Size(260, 30);
            this.txtqtxtjby.TabIndex = 4;
            // 
            // ckqita1
            // 
            this.ckqita1.AutoSize = true;
            this.ckqita1.Location = new System.Drawing.Point(6, 29);
            this.ckqita1.Name = "ckqita1";
            this.ckqita1.Size = new System.Drawing.Size(88, 24);
            this.ckqita1.TabIndex = 0;
            this.ckqita1.Text = "未发现";
            this.ckqita1.UseVisualStyleBackColor = true;
            // 
            // ckqita3
            // 
            this.ckqita3.AutoSize = true;
            this.ckqita3.Location = new System.Drawing.Point(313, 29);
            this.ckqita3.Name = "ckqita3";
            this.ckqita3.Size = new System.Drawing.Size(148, 24);
            this.ckqita3.TabIndex = 2;
            this.ckqita3.Text = "慢性支气管炎";
            this.ckqita3.UseVisualStyleBackColor = true;
            // 
            // ckqita2
            // 
            this.ckqita2.AutoSize = true;
            this.ckqita2.Location = new System.Drawing.Point(185, 29);
            this.ckqita2.Name = "ckqita2";
            this.ckqita2.Size = new System.Drawing.Size(88, 24);
            this.ckqita2.TabIndex = 1;
            this.ckqita2.Text = "糖尿病";
            this.ckqita2.UseVisualStyleBackColor = true;
            // 
            // ckqita4
            // 
            this.ckqita4.AutoSize = true;
            this.ckqita4.Location = new System.Drawing.Point(476, 29);
            this.ckqita4.Name = "ckqita4";
            this.ckqita4.Size = new System.Drawing.Size(188, 24);
            this.ckqita4.TabIndex = 3;
            this.ckqita4.Text = "慢性阻塞性肺气肿";
            this.ckqita4.UseVisualStyleBackColor = true;
            // 
            // ckqita6
            // 
            this.ckqita6.AutoSize = true;
            this.ckqita6.Location = new System.Drawing.Point(819, 29);
            this.ckqita6.Name = "ckqita6";
            this.ckqita6.Size = new System.Drawing.Size(168, 24);
            this.ckqita6.TabIndex = 3;
            this.ckqita6.Text = "老年性骨关节病";
            this.ckqita6.UseVisualStyleBackColor = true;
            // 
            // ckqita5
            // 
            this.ckqita5.AutoSize = true;
            this.ckqita5.Location = new System.Drawing.Point(694, 29);
            this.ckqita5.Name = "ckqita5";
            this.ckqita5.Size = new System.Drawing.Size(108, 24);
            this.ckqita5.TabIndex = 3;
            this.ckqita5.Text = "恶性肿瘤";
            this.ckqita5.UseVisualStyleBackColor = true;
            // 
            // v
            // 
            this.v.Controls.Add(this.ckshenjing4);
            this.v.Controls.Add(this.txtsjxty);
            this.v.Controls.Add(this.ckshenjing3);
            this.v.Controls.Add(this.ckshenjing1);
            this.v.Controls.Add(this.ckshenjing2);
            this.v.Font = new System.Drawing.Font("宋体", 15F);
            this.v.Location = new System.Drawing.Point(104, 319);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(1349, 61);
            this.v.TabIndex = 5;
            this.v.TabStop = false;
            this.v.Text = "神经系统其他疾病";
            // 
            // ckshenjing4
            // 
            this.ckshenjing4.AutoSize = true;
            this.ckshenjing4.Location = new System.Drawing.Point(819, 27);
            this.ckshenjing4.Name = "ckshenjing4";
            this.ckshenjing4.Size = new System.Drawing.Size(68, 24);
            this.ckshenjing4.TabIndex = 4;
            this.ckshenjing4.Text = "其他";
            this.ckshenjing4.UseVisualStyleBackColor = true;
            // 
            // txtsjxty
            // 
            this.txtsjxty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtsjxty.Font = new System.Drawing.Font("宋体", 15F);
            this.txtsjxty.Location = new System.Drawing.Point(893, 27);
            this.txtsjxty.MaxLength = 100;
            this.txtsjxty.Name = "txtsjxty";
            this.txtsjxty.ReadOnly = true;
            this.txtsjxty.Size = new System.Drawing.Size(280, 30);
            this.txtsjxty.TabIndex = 4;
            // 
            // ckshenjing3
            // 
            this.ckshenjing3.AutoSize = true;
            this.ckshenjing3.Location = new System.Drawing.Point(634, 27);
            this.ckshenjing3.Name = "ckshenjing3";
            this.ckshenjing3.Size = new System.Drawing.Size(108, 24);
            this.ckshenjing3.TabIndex = 3;
            this.ckshenjing3.Text = "帕金森病";
            this.ckshenjing3.UseVisualStyleBackColor = true;
            // 
            // ckshenjing1
            // 
            this.ckshenjing1.AutoSize = true;
            this.ckshenjing1.Location = new System.Drawing.Point(11, 27);
            this.ckshenjing1.Name = "ckshenjing1";
            this.ckshenjing1.Size = new System.Drawing.Size(88, 24);
            this.ckshenjing1.TabIndex = 0;
            this.ckshenjing1.Text = "未发现";
            this.ckshenjing1.UseVisualStyleBackColor = true;
            // 
            // ckshenjing2
            // 
            this.ckshenjing2.AutoSize = true;
            this.ckshenjing2.Location = new System.Drawing.Point(185, 27);
            this.ckshenjing2.Name = "ckshenjing2";
            this.ckshenjing2.Size = new System.Drawing.Size(288, 24);
            this.ckshenjing2.TabIndex = 1;
            this.ckshenjing2.Text = "阿尔茨海默症（老年性痴呆）";
            this.ckshenjing2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbNxgOther);
            this.groupBox1.Controls.Add(this.ckNxg6);
            this.groupBox1.Controls.Add(this.ckNxg5);
            this.groupBox1.Controls.Add(this.ckNxg4);
            this.groupBox1.Controls.Add(this.ckNxg3);
            this.groupBox1.Controls.Add(this.ckNxg2);
            this.groupBox1.Controls.Add(this.ckNxg1);
            this.groupBox1.Location = new System.Drawing.Point(104, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(709, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "脑血管疾病";
            // 
            // tbNxgOther
            // 
            this.tbNxgOther.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNxgOther.Font = new System.Drawing.Font("宋体", 15F);
            this.tbNxgOther.Location = new System.Drawing.Point(252, 62);
            this.tbNxgOther.MaxLength = 100;
            this.tbNxgOther.Name = "tbNxgOther";
            this.tbNxgOther.ReadOnly = true;
            this.tbNxgOther.Size = new System.Drawing.Size(226, 30);
            this.tbNxgOther.TabIndex = 6;
            // 
            // ckNxg6
            // 
            this.ckNxg6.AutoSize = true;
            this.ckNxg6.Location = new System.Drawing.Point(168, 67);
            this.ckNxg6.Name = "ckNxg6";
            this.ckNxg6.Size = new System.Drawing.Size(68, 24);
            this.ckNxg6.TabIndex = 5;
            this.ckNxg6.Text = "其他";
            this.ckNxg6.UseVisualStyleBackColor = true;
            // 
            // ckNxg5
            // 
            this.ckNxg5.AutoSize = true;
            this.ckNxg5.Location = new System.Drawing.Point(11, 67);
            this.ckNxg5.Name = "ckNxg5";
            this.ckNxg5.Size = new System.Drawing.Size(148, 24);
            this.ckNxg5.TabIndex = 4;
            this.ckNxg5.Text = "短暂性脑缺血";
            this.ckNxg5.UseVisualStyleBackColor = true;
            // 
            // ckNxg4
            // 
            this.ckNxg4.AutoSize = true;
            this.ckNxg4.Location = new System.Drawing.Point(425, 29);
            this.ckNxg4.Name = "ckNxg4";
            this.ckNxg4.Size = new System.Drawing.Size(168, 24);
            this.ckNxg4.TabIndex = 3;
            this.ckNxg4.Text = "蛛网膜下腔出血";
            this.ckNxg4.UseVisualStyleBackColor = true;
            // 
            // ckNxg3
            // 
            this.ckNxg3.AutoSize = true;
            this.ckNxg3.Location = new System.Drawing.Point(313, 29);
            this.ckNxg3.Name = "ckNxg3";
            this.ckNxg3.Size = new System.Drawing.Size(88, 24);
            this.ckNxg3.TabIndex = 2;
            this.ckNxg3.Text = "脑出血";
            this.ckNxg3.UseVisualStyleBackColor = true;
            // 
            // ckNxg2
            // 
            this.ckNxg2.AutoSize = true;
            this.ckNxg2.Location = new System.Drawing.Point(168, 29);
            this.ckNxg2.Name = "ckNxg2";
            this.ckNxg2.Size = new System.Drawing.Size(128, 24);
            this.ckNxg2.TabIndex = 1;
            this.ckNxg2.Text = "缺血性卒中";
            this.ckNxg2.UseVisualStyleBackColor = true;
            // 
            // ckNxg1
            // 
            this.ckNxg1.AutoSize = true;
            this.ckNxg1.Location = new System.Drawing.Point(11, 29);
            this.ckNxg1.Name = "ckNxg1";
            this.ckNxg1.Size = new System.Drawing.Size(88, 24);
            this.ckNxg1.TabIndex = 0;
            this.ckNxg1.Text = "未发现";
            this.ckNxg1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbSzOther);
            this.groupBox2.Controls.Add(this.ckSz6);
            this.groupBox2.Controls.Add(this.ckSz5);
            this.groupBox2.Controls.Add(this.ckSz4);
            this.groupBox2.Controls.Add(this.ckSz3);
            this.groupBox2.Controls.Add(this.ckSz2);
            this.groupBox2.Controls.Add(this.ckSz1);
            this.groupBox2.Location = new System.Drawing.Point(843, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 103);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "肾脏疾病";
            // 
            // tbSzOther
            // 
            this.tbSzOther.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSzOther.Font = new System.Drawing.Font("宋体", 15F);
            this.tbSzOther.Location = new System.Drawing.Point(201, 56);
            this.tbSzOther.MaxLength = 100;
            this.tbSzOther.Name = "tbSzOther";
            this.tbSzOther.ReadOnly = true;
            this.tbSzOther.Size = new System.Drawing.Size(226, 30);
            this.tbSzOther.TabIndex = 6;
            // 
            // ckSz6
            // 
            this.ckSz6.AutoSize = true;
            this.ckSz6.Location = new System.Drawing.Point(127, 64);
            this.ckSz6.Name = "ckSz6";
            this.ckSz6.Size = new System.Drawing.Size(68, 24);
            this.ckSz6.TabIndex = 5;
            this.ckSz6.Text = "其他";
            this.ckSz6.UseVisualStyleBackColor = true;
            // 
            // ckSz5
            // 
            this.ckSz5.AutoSize = true;
            this.ckSz5.Location = new System.Drawing.Point(11, 64);
            this.ckSz5.Name = "ckSz5";
            this.ckSz5.Size = new System.Drawing.Size(108, 24);
            this.ckSz5.TabIndex = 4;
            this.ckSz5.Text = "慢性肾炎";
            this.ckSz5.UseVisualStyleBackColor = true;
            // 
            // ckSz4
            // 
            this.ckSz4.AutoSize = true;
            this.ckSz4.Location = new System.Drawing.Point(406, 26);
            this.ckSz4.Name = "ckSz4";
            this.ckSz4.Size = new System.Drawing.Size(108, 24);
            this.ckSz4.TabIndex = 3;
            this.ckSz4.Text = "急性肾炎";
            this.ckSz4.UseVisualStyleBackColor = true;
            // 
            // ckSz3
            // 
            this.ckSz3.AutoSize = true;
            this.ckSz3.Location = new System.Drawing.Point(267, 26);
            this.ckSz3.Name = "ckSz3";
            this.ckSz3.Size = new System.Drawing.Size(128, 24);
            this.ckSz3.TabIndex = 2;
            this.ckSz3.Text = "肾功能衰竭";
            this.ckSz3.UseVisualStyleBackColor = true;
            // 
            // ckSz2
            // 
            this.ckSz2.AutoSize = true;
            this.ckSz2.Location = new System.Drawing.Point(127, 26);
            this.ckSz2.Name = "ckSz2";
            this.ckSz2.Size = new System.Drawing.Size(128, 24);
            this.ckSz2.TabIndex = 1;
            this.ckSz2.Text = "糖尿病肾病";
            this.ckSz2.UseVisualStyleBackColor = true;
            // 
            // ckSz1
            // 
            this.ckSz1.AutoSize = true;
            this.ckSz1.Location = new System.Drawing.Point(11, 26);
            this.ckSz1.Name = "ckSz1";
            this.ckSz1.Size = new System.Drawing.Size(88, 24);
            this.ckSz1.TabIndex = 0;
            this.ckSz1.Text = "未发现";
            this.ckSz1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckXz10);
            this.groupBox3.Controls.Add(this.tbXzOther);
            this.groupBox3.Controls.Add(this.ckXz9);
            this.groupBox3.Controls.Add(this.ckXz8);
            this.groupBox3.Controls.Add(this.ckXz7);
            this.groupBox3.Controls.Add(this.ckXz6);
            this.groupBox3.Controls.Add(this.ckXz5);
            this.groupBox3.Controls.Add(this.ckXz4);
            this.groupBox3.Controls.Add(this.ckXz3);
            this.groupBox3.Controls.Add(this.ckXz2);
            this.groupBox3.Controls.Add(this.ckXz1);
            this.groupBox3.Location = new System.Drawing.Point(104, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1349, 109);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "心血管疾病";
            // 
            // ckXz10
            // 
            this.ckXz10.AutoSize = true;
            this.ckXz10.Location = new System.Drawing.Point(185, 71);
            this.ckXz10.Name = "ckXz10";
            this.ckXz10.Size = new System.Drawing.Size(68, 24);
            this.ckXz10.TabIndex = 6;
            this.ckXz10.Text = "其他";
            this.ckXz10.UseVisualStyleBackColor = true;
            // 
            // tbXzOther
            // 
            this.tbXzOther.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbXzOther.Font = new System.Drawing.Font("宋体", 15F);
            this.tbXzOther.Location = new System.Drawing.Point(259, 65);
            this.tbXzOther.MaxLength = 100;
            this.tbXzOther.Name = "tbXzOther";
            this.tbXzOther.ReadOnly = true;
            this.tbXzOther.Size = new System.Drawing.Size(300, 30);
            this.tbXzOther.TabIndex = 7;
            // 
            // ckXz9
            // 
            this.ckXz9.AutoSize = true;
            this.ckXz9.Location = new System.Drawing.Point(11, 70);
            this.ckXz9.Name = "ckXz9";
            this.ckXz9.Size = new System.Drawing.Size(168, 24);
            this.ckXz9.TabIndex = 5;
            this.ckXz9.Text = "动脉闭塞性疾病";
            this.ckXz9.UseVisualStyleBackColor = true;
            // 
            // ckXz8
            // 
            this.ckXz8.AutoSize = true;
            this.ckXz8.Location = new System.Drawing.Point(1097, 26);
            this.ckXz8.Name = "ckXz8";
            this.ckXz8.Size = new System.Drawing.Size(128, 24);
            this.ckXz8.TabIndex = 5;
            this.ckXz8.Text = "夹层动脉瘤";
            this.ckXz8.UseVisualStyleBackColor = true;
            // 
            // ckXz7
            // 
            this.ckXz7.AutoSize = true;
            this.ckXz7.Location = new System.Drawing.Point(966, 26);
            this.ckXz7.Name = "ckXz7";
            this.ckXz7.Size = new System.Drawing.Size(88, 24);
            this.ckXz7.TabIndex = 5;
            this.ckXz7.Text = "高血压";
            this.ckXz7.UseVisualStyleBackColor = true;
            // 
            // ckXz6
            // 
            this.ckXz6.AutoSize = true;
            this.ckXz6.Location = new System.Drawing.Point(819, 26);
            this.ckXz6.Name = "ckXz6";
            this.ckXz6.Size = new System.Drawing.Size(128, 24);
            this.ckXz6.TabIndex = 5;
            this.ckXz6.Text = "心前区疼痛";
            this.ckXz6.UseVisualStyleBackColor = true;
            // 
            // ckXz5
            // 
            this.ckXz5.AutoSize = true;
            this.ckXz5.Location = new System.Drawing.Point(634, 26);
            this.ckXz5.Name = "ckXz5";
            this.ckXz5.Size = new System.Drawing.Size(168, 24);
            this.ckXz5.TabIndex = 4;
            this.ckXz5.Text = "充血性心力衰竭";
            this.ckXz5.UseVisualStyleBackColor = true;
            // 
            // ckXz4
            // 
            this.ckXz4.AutoSize = true;
            this.ckXz4.Location = new System.Drawing.Point(433, 26);
            this.ckXz4.Name = "ckXz4";
            this.ckXz4.Size = new System.Drawing.Size(188, 24);
            this.ckXz4.TabIndex = 3;
            this.ckXz4.Text = "冠状动脉血运重建";
            this.ckXz4.UseVisualStyleBackColor = true;
            // 
            // ckXz3
            // 
            this.ckXz3.AutoSize = true;
            this.ckXz3.Location = new System.Drawing.Point(318, 26);
            this.ckXz3.Name = "ckXz3";
            this.ckXz3.Size = new System.Drawing.Size(88, 24);
            this.ckXz3.TabIndex = 2;
            this.ckXz3.Text = "心绞痛";
            this.ckXz3.UseVisualStyleBackColor = true;
            // 
            // ckXz2
            // 
            this.ckXz2.AutoSize = true;
            this.ckXz2.Location = new System.Drawing.Point(185, 26);
            this.ckXz2.Name = "ckXz2";
            this.ckXz2.Size = new System.Drawing.Size(108, 24);
            this.ckXz2.TabIndex = 1;
            this.ckXz2.Text = "心肌梗死";
            this.ckXz2.UseVisualStyleBackColor = true;
            // 
            // ckXz1
            // 
            this.ckXz1.AutoSize = true;
            this.ckXz1.Location = new System.Drawing.Point(11, 26);
            this.ckXz1.Name = "ckXz1";
            this.ckXz1.Size = new System.Drawing.Size(88, 24);
            this.ckXz1.TabIndex = 0;
            this.ckXz1.Text = "未发现";
            this.ckXz1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ckYb5);
            this.groupBox5.Controls.Add(this.tbYbOther);
            this.groupBox5.Controls.Add(this.ckYb4);
            this.groupBox5.Controls.Add(this.ckYb3);
            this.groupBox5.Controls.Add(this.ckYb2);
            this.groupBox5.Controls.Add(this.ckYb1);
            this.groupBox5.Location = new System.Drawing.Point(104, 235);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1349, 61);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "眼部疾病";
            // 
            // ckYb5
            // 
            this.ckYb5.AutoSize = true;
            this.ckYb5.Location = new System.Drawing.Point(819, 26);
            this.ckYb5.Name = "ckYb5";
            this.ckYb5.Size = new System.Drawing.Size(68, 24);
            this.ckYb5.TabIndex = 4;
            this.ckYb5.Text = "其他";
            this.ckYb5.UseVisualStyleBackColor = true;
            // 
            // tbYbOther
            // 
            this.tbYbOther.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbYbOther.Font = new System.Drawing.Font("宋体", 15F);
            this.tbYbOther.Location = new System.Drawing.Point(893, 23);
            this.tbYbOther.MaxLength = 100;
            this.tbYbOther.Name = "tbYbOther";
            this.tbYbOther.ReadOnly = true;
            this.tbYbOther.Size = new System.Drawing.Size(280, 30);
            this.tbYbOther.TabIndex = 5;
            // 
            // ckYb4
            // 
            this.ckYb4.AutoSize = true;
            this.ckYb4.Location = new System.Drawing.Point(634, 26);
            this.ckYb4.Name = "ckYb4";
            this.ckYb4.Size = new System.Drawing.Size(88, 24);
            this.ckYb4.TabIndex = 3;
            this.ckYb4.Text = "白内障";
            this.ckYb4.UseVisualStyleBackColor = true;
            // 
            // ckYb3
            // 
            this.ckYb3.AutoSize = true;
            this.ckYb3.Location = new System.Drawing.Point(433, 26);
            this.ckYb3.Name = "ckYb3";
            this.ckYb3.Size = new System.Drawing.Size(128, 24);
            this.ckYb3.TabIndex = 2;
            this.ckYb3.Text = "视乳头水肿";
            this.ckYb3.UseVisualStyleBackColor = true;
            // 
            // ckYb2
            // 
            this.ckYb2.AutoSize = true;
            this.ckYb2.Location = new System.Drawing.Point(185, 26);
            this.ckYb2.Name = "ckYb2";
            this.ckYb2.Size = new System.Drawing.Size(188, 24);
            this.ckYb2.TabIndex = 1;
            this.ckYb2.Text = "视网膜出血或渗出";
            this.ckYb2.UseVisualStyleBackColor = true;
            // 
            // ckYb1
            // 
            this.ckYb1.AutoSize = true;
            this.ckYb1.Location = new System.Drawing.Point(11, 26);
            this.ckYb1.Name = "ckYb1";
            this.ckYb1.Size = new System.Drawing.Size(88, 24);
            this.ckYb1.TabIndex = 0;
            this.ckYb1.Text = "未发现";
            this.ckYb1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ckxzjb7);
            this.groupBox4.Controls.Add(this.tbxzjbqt);
            this.groupBox4.Controls.Add(this.ckxzjb6);
            this.groupBox4.Controls.Add(this.ckxzjb5);
            this.groupBox4.Controls.Add(this.ckxzjb4);
            this.groupBox4.Controls.Add(this.ckxzjb3);
            this.groupBox4.Controls.Add(this.ckxzjb2);
            this.groupBox4.Controls.Add(this.ckxzjb1);
            this.groupBox4.Location = new System.Drawing.Point(104, 509);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1349, 71);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "心脏疾病";
            // 
            // ckxzjb7
            // 
            this.ckxzjb7.AutoSize = true;
            this.ckxzjb7.Location = new System.Drawing.Point(1041, 29);
            this.ckxzjb7.Name = "ckxzjb7";
            this.ckxzjb7.Size = new System.Drawing.Size(68, 24);
            this.ckxzjb7.TabIndex = 6;
            this.ckxzjb7.Text = "其他";
            this.ckxzjb7.UseVisualStyleBackColor = true;
            // 
            // tbxzjbqt
            // 
            this.tbxzjbqt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbxzjbqt.Font = new System.Drawing.Font("宋体", 15F);
            this.tbxzjbqt.Location = new System.Drawing.Point(1124, 26);
            this.tbxzjbqt.MaxLength = 100;
            this.tbxzjbqt.Name = "tbxzjbqt";
            this.tbxzjbqt.ReadOnly = true;
            this.tbxzjbqt.Size = new System.Drawing.Size(168, 30);
            this.tbxzjbqt.TabIndex = 7;
            // 
            // ckxzjb6
            // 
            this.ckxzjb6.AutoSize = true;
            this.ckxzjb6.Location = new System.Drawing.Point(893, 29);
            this.ckxzjb6.Name = "ckxzjb6";
            this.ckxzjb6.Size = new System.Drawing.Size(128, 24);
            this.ckxzjb6.TabIndex = 5;
            this.ckxzjb6.Text = "心前区疼痛";
            this.ckxzjb6.UseVisualStyleBackColor = true;
            // 
            // ckxzjb5
            // 
            this.ckxzjb5.AutoSize = true;
            this.ckxzjb5.Location = new System.Drawing.Point(694, 29);
            this.ckxzjb5.Name = "ckxzjb5";
            this.ckxzjb5.Size = new System.Drawing.Size(168, 24);
            this.ckxzjb5.TabIndex = 4;
            this.ckxzjb5.Text = "充血性心力衰竭";
            this.ckxzjb5.UseVisualStyleBackColor = true;
            // 
            // ckxzjb4
            // 
            this.ckxzjb4.AutoSize = true;
            this.ckxzjb4.Location = new System.Drawing.Point(476, 29);
            this.ckxzjb4.Name = "ckxzjb4";
            this.ckxzjb4.Size = new System.Drawing.Size(188, 24);
            this.ckxzjb4.TabIndex = 3;
            this.ckxzjb4.Text = "冠状动脉血运重建";
            this.ckxzjb4.UseVisualStyleBackColor = true;
            // 
            // ckxzjb3
            // 
            this.ckxzjb3.AutoSize = true;
            this.ckxzjb3.Location = new System.Drawing.Point(313, 29);
            this.ckxzjb3.Name = "ckxzjb3";
            this.ckxzjb3.Size = new System.Drawing.Size(88, 24);
            this.ckxzjb3.TabIndex = 2;
            this.ckxzjb3.Text = "心绞痛";
            this.ckxzjb3.UseVisualStyleBackColor = true;
            // 
            // ckxzjb2
            // 
            this.ckxzjb2.AutoSize = true;
            this.ckxzjb2.Location = new System.Drawing.Point(185, 29);
            this.ckxzjb2.Name = "ckxzjb2";
            this.ckxzjb2.Size = new System.Drawing.Size(108, 24);
            this.ckxzjb2.TabIndex = 1;
            this.ckxzjb2.Text = "心肌梗死";
            this.ckxzjb2.UseVisualStyleBackColor = true;
            // 
            // ckxzjb1
            // 
            this.ckxzjb1.AutoSize = true;
            this.ckxzjb1.Location = new System.Drawing.Point(11, 26);
            this.ckxzjb1.Name = "ckxzjb1";
            this.ckxzjb1.Size = new System.Drawing.Size(88, 24);
            this.ckxzjb1.TabIndex = 0;
            this.ckxzjb1.Text = "未发现";
            this.ckxzjb1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ckxg3);
            this.groupBox6.Controls.Add(this.ckxg2);
            this.groupBox6.Controls.Add(this.ckxg4);
            this.groupBox6.Controls.Add(this.tbxgqt);
            this.groupBox6.Controls.Add(this.ckxg1);
            this.groupBox6.Location = new System.Drawing.Point(104, 586);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1349, 57);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "血管疾病";
            // 
            // ckxg3
            // 
            this.ckxg3.AutoSize = true;
            this.ckxg3.Location = new System.Drawing.Point(336, 25);
            this.ckxg3.Name = "ckxg3";
            this.ckxg3.Size = new System.Drawing.Size(168, 24);
            this.ckxg3.TabIndex = 9;
            this.ckxg3.Text = "动脉闭塞性疾病";
            this.ckxg3.UseVisualStyleBackColor = true;
            // 
            // ckxg2
            // 
            this.ckxg2.AutoSize = true;
            this.ckxg2.Location = new System.Drawing.Point(185, 25);
            this.ckxg2.Name = "ckxg2";
            this.ckxg2.Size = new System.Drawing.Size(128, 24);
            this.ckxg2.TabIndex = 8;
            this.ckxg2.Text = "夹层动脉瘤";
            this.ckxg2.UseVisualStyleBackColor = true;
            // 
            // ckxg4
            // 
            this.ckxg4.AutoSize = true;
            this.ckxg4.Location = new System.Drawing.Point(525, 25);
            this.ckxg4.Name = "ckxg4";
            this.ckxg4.Size = new System.Drawing.Size(68, 24);
            this.ckxg4.TabIndex = 6;
            this.ckxg4.Text = "其他";
            this.ckxg4.UseVisualStyleBackColor = true;
            // 
            // tbxgqt
            // 
            this.tbxgqt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbxgqt.Font = new System.Drawing.Font("宋体", 15F);
            this.tbxgqt.Location = new System.Drawing.Point(608, 19);
            this.tbxgqt.MaxLength = 100;
            this.tbxgqt.Name = "tbxgqt";
            this.tbxgqt.ReadOnly = true;
            this.tbxgqt.Size = new System.Drawing.Size(446, 30);
            this.tbxgqt.TabIndex = 7;
            // 
            // ckxg1
            // 
            this.ckxg1.AutoSize = true;
            this.ckxg1.Location = new System.Drawing.Point(11, 25);
            this.ckxg1.Name = "ckxg1";
            this.ckxg1.Size = new System.Drawing.Size(88, 24);
            this.ckxg1.TabIndex = 0;
            this.ckxg1.Text = "未发现";
            this.ckxg1.UseVisualStyleBackColor = true;
            // 
            // UCHealthQuestion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.v);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "UCHealthQuestion";
            this.Load += new System.EventHandler(this.UCHealthQuestion_Load);
            this.VisibleChanged += new System.EventHandler(this.UCHealthQuestion_VisibleChanged);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.v.ResumeLayout(false);
            this.v.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {
            throw new NotImplementedException();
        }

        public bool SaveModelToDB()
        {
            if (this.HealthQuestion == null)
            {
                return false;
            }
            if (PhysicalInfoFactory.ID == -1)
            {
                return true;
            }
            RecordsHealthQuestionBLL recordsHealthQuestionBll = new RecordsHealthQuestionBLL();
            this.HealthQuestion.OutKey = PhysicalInfoFactory.ID;
            if (!recordsHealthQuestionBll.ExistsOutKey(this.HealthQuestion.IDCardNo,PhysicalInfoFactory.ID))
            {
                recordsHealthQuestionBll.Add(this.HealthQuestion);
            }
            else
            {
                recordsHealthQuestionBll.Update(this.HealthQuestion);
            }
            return true;
        }

        private void UCHealthQuestion_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        public void UpdataToModel()
        {
            this.HealthQuestion.IDCardNo = this.Model.IDCardNo;
            //this.HealthQuestion.NerveDis = this.shenjing.Choose;
            //this.HealthQuestion.NerveOther = this.shenjing.Choose_EX;
            //this.HealthQuestion.ElseDis = this.qita.Choose;
            //this.HealthQuestion.ElseOther = this.qita.Choose_EX;
        }
    
        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsHealthQuestionModel HealthQuestion { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        private void UCHealthQuestion_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                RecordsManageMentModel.BrainDis = this.HealthQuestion.BrainDis;
                RecordsManageMentModel.RenalDis = this.HealthQuestion.RenalDis;
                RecordsManageMentModel.HeartDis = this.HealthQuestion.HeartDis;
                RecordsManageMentModel.EyeDis = this.HealthQuestion.EyeDis;
                RecordsManageMentModel.NerveDis = this.HealthQuestion.NerveDis;
                RecordsManageMentModel.ElseDis = this.HealthQuestion.ElseDis;
                RecordsManageMentModel.BrainOther = this.HealthQuestion.BrainOther;
                RecordsManageMentModel.RenalOther = this.HealthQuestion.RenalOther;
                RecordsManageMentModel.HeartOther = this.HealthQuestion.HeartOther;
                RecordsManageMentModel.VesselOther = this.HealthQuestion.VesselOther;
                RecordsManageMentModel.EyeOther = this.HealthQuestion.EyeOther;
                RecordsManageMentModel.NerveOther = this.HealthQuestion.NerveOther;
                RecordsManageMentModel.ElseOther = this.HealthQuestion.ElseOther;
            }
           
        }
    }
}