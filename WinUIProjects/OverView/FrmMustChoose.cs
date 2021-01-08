using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace OverView
{
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Management;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public partial class FrmMustChoose : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private int currentPage;
        private int totalPages;
        private int totalCount;
        private int pageCount = 0x12;
        private BindingSource bds;
        private DataTable dt_user;
        private DataTable dtTmp;

        public FrmMustChoose()
        {
            InitializeComponent();
            this.dgvData.AutoGenerateColumns = false;
            this.EveryThingIsOk = false;
            this.HaveToSave = false;
        }

        private void btnFront_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 0)
            {
                this.lbPages.Text = string.Format("{0}/{1}页", --this.currentPage + 1, this.totalPages);

                DataTable dtTemp = dtTmp.Clone();
                int nextV = (this.currentPage+1) * this.pageCount;

                for (int i = (this.currentPage) * this.pageCount; i < nextV; i++)
                {
                    dtTemp.ImportRow(dtTmp.Rows[i]);
                }
                this.bds.DataSource = dtTemp;
                this.dgvData.DataSource = this.bds;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.currentPage < (this.totalPages - 1))
            {
                this.lbPages.Text = string.Format("{0}/{1}页", ++this.currentPage + 1, this.totalPages);
              
                DataSet ds = new RecordsBaseInfoBLL().GetListByPage(this.GetWhere(), "", this.currentPage * this.pageCount, this.pageCount);

                DataTable dtTemp = dtTmp.Clone();  
                int nextV =( this.currentPage+1) * this.pageCount;
                if (nextV>this.totalCount)
                {
                    nextV = this.totalCount;
                }
                for (int i = this.currentPage  * this.pageCount; i < nextV; i++)
                {
                    dtTemp.ImportRow(dtTmp.Rows[i]);
                }

                this.bds.DataSource = dtTemp;
                this.dgvData.DataSource = this.bds;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.btnQuery.Text == "重置条件")
            {
                this.groupBox1.Enabled = true;
                this.btnQuery.Text = "查询";
                txtIdNum.Text = "";
                tbAddr.Text = "";
                dtpSt.Text = "";
                dtpEd.Text = "";
                dtpCreatedDateSt.Text = "";
                dtpCreatedDateEd.Text = "";
            }
            else if (this.ckBirthday.Checked && (this.dtpSt.Value.Date > this.dtpEd.Value.Date))
            {
                MessageBox.Show(" 出生日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.ckxCreatedDate.Checked && (this.dtpCreatedDateSt.Value.Date > this.dtpCreatedDateEd.Value.Date))
            {
                MessageBox.Show(" 建档日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                string where = this.GetWhere();
                RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
                DataSet ds =  archive_baseinfo.GetListDT (where, "");
                DataTable dtF = new DataTable();
                if (ds.Tables.Count > 0)
                {
                    this.TransDs(ds);
                    dtF = ds.Tables[0];
                    dtTmp = SetDate(dtF);
                    //this.bds.DataSource = dtTmp;
                    //this.dgvData.DataSource = this.bds;
                }

                this.totalCount = dtTmp.Rows.Count;
                this.totalPages = (this.totalCount <= this.pageCount) ? 1 : ((this.totalCount / this.pageCount) + (((this.totalCount % this.pageCount) > 0) ? 1 : 0));
                this.currentPage = 0;
                this.lbTotalCount.Text = string.Format("共计{0}条", this.totalCount.ToString());
                this.lbPages.Text = string.Format("{0}/{1}页", this.currentPage + 1, this.totalPages);
                if (ds.Tables.Count > 0)
                {
                    DataTable dtTemp = dtTmp.Clone();
                    int nextV = (this.currentPage + 1) * this.pageCount;
                    if (nextV > this.totalCount)
                    {
                        nextV = this.totalCount;
                    }
                    for (int i = (this.currentPage) * this.pageCount; i < nextV; i++)
                    {
                        dtTemp.ImportRow(dtTmp.Rows[i]);
                    }
                    this.bds.DataSource = dtTemp;
                    this.dgvData.DataSource = this.bds;
                }
                this.groupBox1.Enabled = false;
                this.btnQuery.Text = "重置条件";
            }
        }
        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        private void ckBirthday_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpSt.Enabled = this.ckBirthday.Checked;
            this.dtpEd.Enabled = this.ckBirthday.Checked;
        }

        private void ckxCreatedDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpCreatedDateSt.Enabled = this.ckxCreatedDate.Checked;
            this.dtpCreatedDateEd.Enabled = this.ckxCreatedDate.Checked;
        }

        private string GetWhere()
        {
            string input = this.txtIdNum.Text.Trim();
            string str2 = "";
            if (input != "")
            {
                str2 = !Regex.IsMatch(input, "^[0-9]*$") ? string.Format(" and CustomerName like '%{0}%'", input) : ("and IDCardNo LIKE '%" + input + "%'");
            }
            if (!string.IsNullOrEmpty(this.tbAddr.Text.Trim()))
            {
                str2 = str2 + string.Format(" and HouseHoldAddress LIKE '%{0}%' ", this.tbAddr.Text.Trim());
            }
            if (this.ckBirthday.Checked)
            {
               // str2 = !(this.dtpSt.Value.Date == this.dtpEd.Value.Date) ? (str2 + string.Format(" and Birthday between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"))) : (str2 + string.Format(" and Birthday between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpSt.Value.Date.AddDays(1.0).ToString("yyyy-MM-dd")));
                str2 = str2 + string.Format(" and Birthday between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.ckxCreatedDate.Checked)
            {
               // str2 = !(this.dtpCreatedDateSt.Value.Date == this.dtpCreatedDateEd.Value.Date) ? (str2 + string.Format(" and CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"))) : (str2 + string.Format(" and CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateSt.Value.Date.AddDays(1.0).ToString("yyyy-MM-dd")));
                str2 = str2 + string.Format(" and CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            DataRowView selectedItem = this.cbxUser.SelectedItem as DataRowView;
            if (selectedItem == null)
            {
                return str2;
            }
            DataRow row = selectedItem.Row;
            if (row["ID"].ToString() == "-1")
            {
                return str2;
            }
            return (str2 + " and CreateBy = " + row["ID"].ToString() + " ");
        }

        private void FrmMustChoose_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        public void InitEveryThing()
        {
            this.findModels = new List<RecordsBaseInfoModel>();
            this.bds = new BindingSource();
            string node = ConfigHelper.GetNode("orgCode");
            if (node.Length == 12)
            {
                this.dt_user = new SysUserBLL().GetList(" VillageID = " + new SysOrgVillangBLL().GetModel(node).ID).Tables[0];
            }
            else if (node.Length == 9)
            {
                this.dt_user = new SysUserBLL().GetList(" TownID = " + new SysOrgTownBLL().GetModel(node).ID).Tables[0];
            }
            else if (node.Length == 6)
            {
                this.dt_user = new SysOrgDistrictBLL().GetList(" DistrictID = " + new SysOrgDistrictBLL().GetModel(node).ID).Tables[0];
            }
            DataRow row = this.dt_user.NewRow();
            row.ItemArray = new object[] { -1, "ph", "不限" };
            this.dt_user.Rows.InsertAt(row, 0);
            this.cbxUser.ValueMember = "ID";
            this.cbxUser.DisplayMember = "USERNAME";
            this.cbxUser.DataSource = this.dt_user;
            this.EveryThingIsOk = true;
        }

        private DataTable SetDate(DataTable dt)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "MustChoose <> ''";

            return dv.ToTable(true);
        }

        private void TransDs(DataSet ds)
        {
            ds.Tables[0].Columns.Add("MustChoose");
            string mustchoosenode = ConfigHelper.GetMustChooseNode("mustchoose");
            if (string.IsNullOrEmpty(mustchoosenode))
            {
                mustchoosenode = "0000000000000000000000000000000000000000000000000";
                ConfigHelper.WriteNode("mustchoose", "0000000000000000000000000000000000000000000000000");
            }
            char[] chrArray = mustchoosenode.ToCharArray();
            RecordsCustomerBaseInfoBLL CustomerBaseBll = new RecordsCustomerBaseInfoBLL();
            RecordsGeneralConditionBLL GeneralConditionBll = new RecordsGeneralConditionBLL();
            RecordsLifeStyleBLL LifeStyleBll = new RecordsLifeStyleBLL();
            RecordsPhysicalExamBLL PhysicalExamBll = new RecordsPhysicalExamBLL();
            RecordsAssistCheckBLL AssistCheckBll = new RecordsAssistCheckBLL();
            RecordsVisceraFunctionBLL VisceraFunctionBll = new RecordsVisceraFunctionBLL();
            RecordsHealthQuestionBLL HealthQuestionBll = new RecordsHealthQuestionBLL();
            RecordsAssessmentGuideBLL AssessmentGuideBll = new RecordsAssessmentGuideBLL();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string str = "";
                row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
                DataTable CustomerBaseInfoDt = CustomerBaseBll.GetList(string.Format("IDCardNo = '{0}'", row["IDCardNo"])).Tables[0];
                DataTable GeneralConditionDt = GeneralConditionBll.GetList(string.Format("IDCardNo = '{0}'", row["IDCardNo"])).Tables[0];
                if (CustomerBaseInfoDt.Rows.Count > 0 || GeneralConditionDt.Rows.Count > 0)
                {
                    str = str + "一般状况:";
                    if (CustomerBaseInfoDt.Rows.Count > 0)
                    {
                        DataRow CustomerBaseInforow = CustomerBaseInfoDt.Rows[0];
                        if (chrArray[0] == '1' && string.IsNullOrEmpty(CustomerBaseInforow["Symptom"].ToString()))
                        {
                            str = str + "症状、";
                        }
                    }
                    if (GeneralConditionDt.Rows.Count > 0)
                    {
                        DataRow GeneralConditionrow = GeneralConditionDt.Rows[0];
                        if (chrArray[1] == '1' && string.IsNullOrEmpty(GeneralConditionrow["AnimalHeat"].ToString()))
                        {
                            str = str + "体温、";
                        }
                        if (chrArray[2] == '1' && string.IsNullOrEmpty(GeneralConditionrow["BreathRate"].ToString()))
                        {
                            str = str + "呼吸频率、";
                        }
                        if (chrArray[3] == '1' && string.IsNullOrEmpty(GeneralConditionrow["Waistline"].ToString()))
                        {
                            str = str + "腰围、";
                        }
                        if (chrArray[4] == '1' && string.IsNullOrEmpty(GeneralConditionrow["Height"].ToString()))
                        {
                            str = str + "身高、";
                        }
                        if (chrArray[5] == '1' && string.IsNullOrEmpty(GeneralConditionrow["PulseRate"].ToString()))
                        {
                            str = str + "脉率、";
                        }
                        if (chrArray[6] == '1' && string.IsNullOrEmpty(GeneralConditionrow["Weight"].ToString()))
                        {
                            str = str + "体重、";
                        }
                        if (chrArray[7] == '1' && string.IsNullOrEmpty(GeneralConditionrow["BMI"].ToString()))
                        {
                            str = str + "体质指数、";
                        }
                        if (chrArray[8] == '1' && string.IsNullOrEmpty(GeneralConditionrow["LeftPre"].ToString()))
                        {
                            str = str + "左侧低血压、";
                        }
                        if (chrArray[9] == '1' && string.IsNullOrEmpty(GeneralConditionrow["RightPre"].ToString()))
                        {
                            str = str + "右侧低血压、";
                        }
                        if (chrArray[10] == '1' && string.IsNullOrEmpty(GeneralConditionrow["LeftHeight"].ToString()))
                        {
                            str = str + "左侧高血压、";
                        }
                        if (chrArray[11] == '1' && string.IsNullOrEmpty(GeneralConditionrow["RightHeight"].ToString()))
                        {
                            str = str + "右侧高血压、";
                        }

                        if (str.Length > 2)
                        {
                            if (str == "一般状况:")
                            {
                                str = "";
                            }
                            else
                            {
                                str = str.Substring(0, str.Length - 1) + "，";

                            }
                        }
                    }
                }

                string strlife = "";
                DataTable LifeStyleDt = LifeStyleBll.GetList(string.Format("IDCardNo = '{0}'", row["IDCardNo"])).Tables[0];
                if (LifeStyleDt.Rows.Count > 0)
                {
                    strlife = strlife + "生活方式:";
                    DataRow LifeStylerow = LifeStyleDt.Rows[0];
                    if (chrArray[12] == '1' && string.IsNullOrEmpty(LifeStylerow["DietaryHabit"].ToString()))
                    {
                        strlife = strlife + "饮食习惯、";
                    }
                    if (chrArray[13] == '1' && string.IsNullOrEmpty(LifeStylerow["CareerHarmFactorHistory"].ToString()))
                    {
                        strlife = strlife + "职业病危害因素接触史、";
                    }
                }
                if (strlife.Length > 2)
                {
                    if (strlife == "生活方式:")
                    {
                        strlife = "";
                    }
                    else
                    {
                        str = str + strlife.Substring(0, strlife.Length - 1) + "，";
                    }
                }

                string strphysicalexam = "";
                DataTable PhysicalExamDt = PhysicalExamBll.GetList(string.Format("IDCardNo = '{0}'", row["IDCardNo"])).Tables[0];
                if (PhysicalExamDt.Rows.Count > 0)
                {
                    strphysicalexam = strphysicalexam + "查体信息:";
                    DataRow PhysicalExamrow = PhysicalExamDt.Rows[0];
                    if (chrArray[14] == '1' && string.IsNullOrEmpty(PhysicalExamrow["Skin"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "皮肤、";
                    }
                    if (chrArray[15] == '1' && string.IsNullOrEmpty(PhysicalExamrow["Sclere"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "巩膜、";
                    }
                    if (chrArray[16] == '1' && string.IsNullOrEmpty(PhysicalExamrow["Lymph"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "淋巴结、";
                    }
                    if (chrArray[17] == '1' && string.IsNullOrEmpty(PhysicalExamrow["BarrelChest"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "桶状胸、";
                    }
                    if (chrArray[18] == '1' && string.IsNullOrEmpty(PhysicalExamrow["BreathSounds"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "呼吸音、";
                    }
                    if (chrArray[19] == '1' && string.IsNullOrEmpty(PhysicalExamrow["Rale"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "罗音、";
                    }
                    if (chrArray[20] == '1' && string.IsNullOrEmpty(PhysicalExamrow["HeartRate"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "心率、";
                    }
                    if (chrArray[21] == '1' && string.IsNullOrEmpty(PhysicalExamrow["HeartRhythm"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "心律、";
                    }
                    if (chrArray[22] == '1' && string.IsNullOrEmpty(PhysicalExamrow["Noise"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "杂音、";
                    }
                    if (chrArray[23] == '1' && string.IsNullOrEmpty(PhysicalExamrow["EnclosedMass"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "包块、";
                    }
                    if (chrArray[24] == '1' && string.IsNullOrEmpty(PhysicalExamrow["Edema"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "下肢水肿、";
                    }
                    if (chrArray[25] == '1' && string.IsNullOrEmpty(PhysicalExamrow["FootBack"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "足背动脉搏动、";
                    }
                    if (chrArray[26] == '1' && string.IsNullOrEmpty(PhysicalExamrow["Anus"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "肛门指诊、";
                    }
                    if (chrArray[27] == '1' && string.IsNullOrEmpty(PhysicalExamrow["Breast"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "乳腺、";
                    }
                    if (chrArray[28] == '1' && string.IsNullOrEmpty(PhysicalExamrow["PressPain"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "压痛、";
                    }
                    if (chrArray[29] == '1' && string.IsNullOrEmpty(PhysicalExamrow["Liver"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "肝大、";
                    }
                    if (chrArray[30] == '1' && string.IsNullOrEmpty(PhysicalExamrow["Spleen"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "脾大、";
                    }
                    if (chrArray[31] == '1' && string.IsNullOrEmpty(PhysicalExamrow["Voiced"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "移动性浊音、";
                    }
                    if (chrArray[32] == '1' && string.IsNullOrEmpty(PhysicalExamrow["EyeRound"].ToString()))
                    {
                        strphysicalexam = strphysicalexam + "眼底、";
                    }
                }
                if (strphysicalexam.Length > 2)
                {
                    if (strphysicalexam == "查体信息:")
                    {
                        strphysicalexam = "";
                    }
                    else
                    {
                        str = str + strphysicalexam.Substring(0, strphysicalexam.Length - 1) + "，";
                    }
                }

                string strAssistCheck = "";
                DataTable AssistCheckDt = AssistCheckBll.GetList(string.Format("IDCardNo = '{0}'", row["IDCardNo"])).Tables[0];
                if (AssistCheckDt.Rows.Count > 0)
                {
                    strAssistCheck = strAssistCheck + "辅助检查:";
                    DataRow AssistCheckrow = AssistCheckDt.Rows[0];
                    if (chrArray[33] == '1' && string.IsNullOrEmpty(AssistCheckrow["FPGL"].ToString()))
                    {
                        strAssistCheck = strAssistCheck + "空腹血糖DL、";
                    }
                }
                if (strAssistCheck.Length > 2)
                {
                    if (strAssistCheck == "辅助检查:")
                    {
                        strAssistCheck = "";
                    }
                    else
                    {
                        str = str + strAssistCheck.Substring(0, strAssistCheck.Length - 1) + "，";
                    }
                }

                string strVisceraFunction = "";
                DataTable VisceraFunctionDt = VisceraFunctionBll.GetList(string.Format("IDCardNo = '{0}'", row["IDCardNo"])).Tables[0];
                if (VisceraFunctionDt.Rows.Count > 0)
                {
                    strVisceraFunction = strVisceraFunction + "脏器功能:";
                    DataRow VisceraFunctionrow = VisceraFunctionDt.Rows[0];
                    if (chrArray[34] == '1' && string.IsNullOrEmpty(VisceraFunctionrow["Lips"].ToString()))
                    {
                        strAssistCheck = strAssistCheck + "口唇、";
                    }
                    if (chrArray[35] == '1' && string.IsNullOrEmpty(VisceraFunctionrow["ToothResides"].ToString()))
                    {
                        strAssistCheck = strAssistCheck + "齿列、";
                    }
                    if (chrArray[36] == '1' && string.IsNullOrEmpty(VisceraFunctionrow["Pharyngeal"].ToString()))
                    {
                        strAssistCheck = strAssistCheck + "咽部、";
                    }
                    if (chrArray[37] == '1' && string.IsNullOrEmpty(VisceraFunctionrow["Listen"].ToString()))
                    {
                        strAssistCheck = strAssistCheck + "听力、";
                    }
                    if (chrArray[38] == '1' && string.IsNullOrEmpty(VisceraFunctionrow["SportFunction"].ToString()))
                    {
                        strAssistCheck = strAssistCheck + "运动功能、";
                    }
                }
                if (strVisceraFunction.Length > 2)
                {
                    if (strVisceraFunction == "脏器功能:")
                    {
                        strVisceraFunction = "";
                    }
                    else
                    {
                        str = str + strVisceraFunction.Substring(0, strVisceraFunction.Length - 1) + "，";
                    }
                }

                string strHealthQuestion = "";
                DataTable HealthQuestionDt = HealthQuestionBll.GetList(string.Format("IDCardNo = '{0}'", row["IDCardNo"])).Tables[0];
                if (HealthQuestionDt.Rows.Count > 0)
                {
                    strHealthQuestion = strHealthQuestion + "健康问题:";
                    DataRow HealthQuestionrow = HealthQuestionDt.Rows[0];
                    if (chrArray[39] == '1' && string.IsNullOrEmpty(HealthQuestionrow["BrainDis"].ToString()))
                    {
                        strHealthQuestion = strHealthQuestion + "脑血管疾病、";
                    }
                    if (chrArray[40] == '1' && string.IsNullOrEmpty(HealthQuestionrow["RenalDis"].ToString()))
                    {
                        strHealthQuestion = strHealthQuestion + "肾脏疾病、";
                    }
                    if (chrArray[41] == '1' && string.IsNullOrEmpty(HealthQuestionrow["HeartDis"].ToString()))
                    {
                        strHealthQuestion = strHealthQuestion + "心脏疾病、";
                    }
                    if (chrArray[42] == '1' && string.IsNullOrEmpty(HealthQuestionrow["VesselDis"].ToString()))
                    {
                        strHealthQuestion = strHealthQuestion + "血管疾病、";
                    }
                    if (chrArray[43] == '1' && string.IsNullOrEmpty(HealthQuestionrow["EyeDis"].ToString()))
                    {
                        strHealthQuestion = strHealthQuestion + "眼部疾病、";
                    }
                    if (chrArray[44] == '1' && string.IsNullOrEmpty(HealthQuestionrow["NerveDis"].ToString()))
                    {
                        strHealthQuestion = strHealthQuestion + "神经系统疾病、";
                    }
                    if (chrArray[45] == '1' && string.IsNullOrEmpty(HealthQuestionrow["ElseDis"].ToString()))
                    {
                        strHealthQuestion = strHealthQuestion + "其他系统疾病、";
                    }
                }
                if (strHealthQuestion.Length > 2)
                {
                    if (strHealthQuestion == "健康问题:")
                    {
                        strHealthQuestion = "";
                    }
                    else
                    {
                        str = str + strHealthQuestion.Substring(0, strHealthQuestion.Length - 1) + "，";
                    }
                }

                string strAssessmentGuide = "";
                DataTable AssessmentGuideDt = AssessmentGuideBll.GetList(string.Format("IDCardNo = '{0}'", row["IDCardNo"])).Tables[0];
                if (AssessmentGuideDt.Rows.Count > 0)
                {
                    strAssessmentGuide = strAssessmentGuide + "健康评价:";
                    DataRow AssessmentGuiderow = AssessmentGuideDt.Rows[0];
                    if (chrArray[46] == '1' && string.IsNullOrEmpty(AssessmentGuiderow["IsNormal"].ToString()))
                    {
                        strAssessmentGuide = strAssessmentGuide + "是否正常1:体检无异常2:有异常、";
                    }
                    if (chrArray[47] == '1' && string.IsNullOrEmpty(AssessmentGuiderow["HealthGuide"].ToString()))
                    {
                        strAssessmentGuide = strAssessmentGuide + "健康指导、";
                    }
                    if (chrArray[48] == '1' && string.IsNullOrEmpty(AssessmentGuiderow["DangerControl"].ToString()))
                    {
                        strAssessmentGuide = strAssessmentGuide + "危险因素控制、";
                    }
                }
                if (strAssessmentGuide.Length > 2)
                {
                    if (strAssessmentGuide == "健康评价:")
                    {
                        strAssessmentGuide = "";
                    }
                    else
                    {
                        str = str + strAssessmentGuide.Substring(0, strAssessmentGuide.Length - 1) + "，";
                    }
                }
                if (str.Length > 0)
                {
                    str = str.Substring(0, str.Length - 1);
                }

                row["MustChoose"] = str;
            }
        }

        public void NotisfyChildStatus()
        {

        }

        public bool SaveModelToDB()
        {
            return true;
        }

        public void UpdataToModel()
        {

        }

        public bool EveryThingIsOk { get; set; }

        private List<RecordsBaseInfoModel> findModels { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

    }
}
