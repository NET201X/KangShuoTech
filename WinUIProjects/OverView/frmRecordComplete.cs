using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
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
    using FocusGroup.ChronicDisease;
    public partial class frmRecordComplete : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private int currentPage;
        private int totalPages;
        private int totalCount;
        private int pageCount = 10;
        private BindingSource bds;
        private DataTable dt_user;
        private DataTable dtTmp;
        private RequireBLL RequireBLL = new RequireBLL();
        private DataTable requirebasedt;
        private DataTable requireilldt;
        private DataTable requireenvironmentdt;
        private DataTable requireGerneralDt;
        private DataTable requireLifeDt;
        private DataTable requirePhysicalDt;
        private DataTable requireCheckDt;
        private DataTable requireFunctionDt;
        private DataTable requireHealthDt;
        private DataTable requireAssessmentDt;
        private DataTable requireolddt;
        private DataTable requirehyperbasedt;
        private DataTable requirehypervisitdt;
        private DataTable requirediabasedt;
        private DataTable requirediavisitdt;
        private RecordsCustomerBaseInfoBLL CustomerBaseInfoBLL = new RecordsCustomerBaseInfoBLL();
        private RecordsGeneralConditionBLL GeneralConditionBLL = new RecordsGeneralConditionBLL();
        private RecordsLifeStyleBLL LifeStyleBLL = new RecordsLifeStyleBLL();
        private RecordsPhysicalExamBLL PhysicalExamBLL = new RecordsPhysicalExamBLL();
        private RecordsAssistCheckBLL AssistCheckBLL = new RecordsAssistCheckBLL();
        private RecordsVisceraFunctionBLL VisceraFunctionBLL = new RecordsVisceraFunctionBLL();
        private RecordsHealthQuestionBLL HealthQuestionBLL = new RecordsHealthQuestionBLL();
        private RecordsAssessmentGuideBLL AssessmentGuideBLL = new RecordsAssessmentGuideBLL();
        private int Sumbaseinfo;//个人档案必须总数
        private int Sumphysical;//健康体检必须总数
        private int Sumold;//老年人必须总数
        private int Sumhyper;//高血压随访必须总数
        private int Sumdia;//糖尿病随访必须总数
        public frmRecordComplete()
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
                int nextV = (this.currentPage + 1) * this.pageCount;

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
                int nextV = (this.currentPage + 1) * this.pageCount;
                if (nextV > this.totalCount)
                {
                    nextV = this.totalCount;
                }
                for (int i = this.currentPage * this.pageCount; i < nextV; i++)
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
            else if (this.ckCheckDate.Checked && (this.dtpSt.Value.Date > this.dtpEd.Value.Date))
            {
                MessageBox.Show(" 体检日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.ckxCreatedDate.Checked && (this.dtpCreatedDateSt.Value.Date > this.dtpCreatedDateEd.Value.Date))
            {
                MessageBox.Show(" 建档日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                string where = this.GetWhere();
                this.btnQuery.Enabled = false;
                if (string.IsNullOrEmpty(where))
                {
                    MessageBox.Show("请选择查询条件！", "查询条件", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.btnQuery.Enabled = true;
                }
                else
                {
                    RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
                    DataSet ds = archive_baseinfo.GetListDT(where, "");
                    if (ds.Tables.Count > 0)
                    {
                        dtTmp = this.TransDs(ds);
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
                    this.btnQuery.Enabled = true;
                    this.btnQuery.Text = "重置条件";
                }
            }
        }

        private void frmRecordComplete_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                requirebasedt = RequireBLL.GetList(" TabName = '个人档案' and Isrequired = '1' ").Tables[0];
                requireGerneralDt = RequireBLL.GetList(" TabName = '健康体检'and Isrequired = '1' ").Tables[0];
                requireolddt = RequireBLL.GetList(" TabName = '老年人随访' and Isrequired = '1'  ").Tables[0];
                requirehyperbasedt = RequireBLL.GetList(" TabName = '高血压随访' and Isrequired = '1' ").Tables[0];
                requirediabasedt = RequireBLL.GetList(" TabName = '糖尿病随访' and Isrequired = '1' ").Tables[0];

                Sumbaseinfo = requirebasedt.Rows.Count;
                Sumphysical = requireGerneralDt.Rows.Count;
                Sumold = requireolddt.Rows.Count;
                Sumhyper = requirehyperbasedt.Rows.Count;
                Sumdia = requirediabasedt.Rows.Count;

                this.InitEveryThing();
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        public void InitEveryThing()
        {
            this.findModels = new List<RecordsBaseInfoModel>();
            this.bds = new BindingSource();
            this.dt_user = new RecordsBaseInfoBLL().GetUserDt("").Tables[0];
            if (this.dt_user.Rows.Count > 0)
            {
                DataRow row = this.dt_user.NewRow();
                row.ItemArray = new object[] { "不限", 0, "" };
                this.dt_user.Rows.InsertAt(row, 0);
                this.cbxUser.ValueMember = "ID";
                this.cbxUser.DisplayMember = "CreateMenName";
                this.cbxUser.DataSource = this.dt_user;
            }
            this.EveryThingIsOk = true;
        }
        private DataTable SetDate(DataTable dt)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Sum != 0 ";
            return dv.ToTable(true);
        }

        private void ckCheckDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpSt.Enabled = this.ckCheckDate.Checked;
            this.dtpEd.Enabled = this.ckCheckDate.Checked;
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
                str2 = !Regex.IsMatch(input, "^[0-9]*$") ? string.Format(" and T.CustomerName like '%{0}%'", input) : ("and T.IDCardNo LIKE '%" + input + "%'");
            }
            if (!string.IsNullOrEmpty(this.tbAddr.Text.Trim()))
            {
                str2 = str2 + string.Format(" and T.HouseHoldAddress LIKE '%{0}%' ", this.tbAddr.Text.Trim());
            }
            if (this.ckCheckDate.Checked)
            {
                str2 = str2 + string.Format(" and B.CheckDate between '{0}' and '{1}' ", this.dtpSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.ckxCreatedDate.Checked)
            {
                str2 = str2 + string.Format(" and T.CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
            }
            if (this.cbxUser.Text != "不限")
            {
                str2 = str2 + string.Format(" and T.CreateMenName = '{0}' ", this.cbxUser.Text.ToString()); ;
            }
          
            return str2;
        }

        private DataTable TransDs(DataSet ds)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("CustomerName");
            dt.Columns.Add("Sex");
            dt.Columns.Add("IDCardNo");
            dt.Columns.Add("Nation");
            dt.Columns.Add("baseinforate");//个人档案
            dt.Columns.Add("physicalexamrate");//健康体检
            dt.Columns.Add("oldmenrate");//老年人完整率
            dt.Columns.Add("hyperrate"); //高血压随访
            dt.Columns.Add("diadetesrate"); //糖尿病随访
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string baseinforate = "", physicalexamrate = "", hyperrate = "", oldmenrate = "", diadetesrate = "";
                double baseinfocount = 0, physicalexamcount = 0, hypercount = 0, oldmencount = 0, diadetescount = 0;
                row["Sex"] = !(row["Sex"].ToString() == "1") ? "女" : "男";
                baseinforate = GetBaseinforate(row["IDCardNo"].ToString());
                physicalexamrate = GetPhysicalexamrate(row["IDCardNo"].ToString());
                oldmenrate = GetOldmenrate(row["IDCardNo"].ToString());
                hyperrate = GetHyperrate(row["IDCardNo"].ToString());
                diadetesrate = GetDiadetesrate(row["IDCardNo"].ToString());
                DataRow dr = dt.NewRow();
                dr["CustomerName"] = row["CustomerName"].ToString().Trim();
                dr["Sex"] = row["Sex"].ToString().Trim();
                dr["IDCardNo"] = row["IDCardNo"].ToString().Trim();
                dr["Nation"] = !(row["Nation"].ToString() == "1") ? row["MINORITY"] : "汉";
                dr["baseinforate"] =baseinforate;
                dr["physicalexamrate"] = physicalexamrate ;
                dr["oldmenrate"] = oldmenrate;
                dr["hyperrate"] = hyperrate;
                dr["diadetesrate"] =diadetesrate ;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private string GetBaseinforate(string str) //个人档案完整率
        {
            string baseinforate = "";
            double baseinfocount = 0;
            if (this.Sumbaseinfo != 0)
            {
                DataTable GetBaseinforate = new RecordsBaseInfoBLL().GerenDanganDt(str).Tables[0];
                if (GetBaseinforate.Rows.Count > 0)
                {
                    DataRow danganrow = GetBaseinforate.Rows[0];
                    foreach (DataRow item in requirebasedt.Rows)
                    {
                        switch (item["ChinName"].ToString())
                        {
                            case "现住址":
                                if (!string.IsNullOrEmpty(danganrow["Address"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "联系电话":
                                if (!string.IsNullOrEmpty(danganrow["Phone"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "户籍地址":
                                if (!string.IsNullOrEmpty(danganrow["HouseHoldAddress"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "乡镇(街道名称)":
                                if (!string.IsNullOrEmpty(danganrow["TownName"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "村(居委会名称)":
                                if (!string.IsNullOrEmpty(danganrow["VillageName"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "建档单位":
                                if (!string.IsNullOrEmpty(danganrow["CreateUnitName"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;

                            case "建档人":
                                if (!string.IsNullOrEmpty(danganrow["CreateMenName"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "责任医生":
                                if (!string.IsNullOrEmpty(danganrow["Doctor"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "建档日期":
                                if (!string.IsNullOrEmpty(danganrow["CreateDate"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "建档编号":
                                if (!string.IsNullOrEmpty(danganrow["RecordID"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                        
                            case "联系人姓名":
                                if (!string.IsNullOrEmpty(danganrow["ContactName"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "联系人电话":
                                if (!string.IsNullOrEmpty(danganrow["ContactPhone"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "遗传病史":
                                if (!string.IsNullOrEmpty(danganrow["Disease"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "支付方式":
                                if (!string.IsNullOrEmpty(danganrow["MedicalPayType"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "药物过敏史":
                                if (!string.IsNullOrEmpty(danganrow["DrugAllergic"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "暴露史":
                                if (!string.IsNullOrEmpty(danganrow["Exposure"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "残疾情况":
                                if (!string.IsNullOrEmpty(danganrow["DiseasEndition"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "户主姓名":
                                if (!string.IsNullOrEmpty(danganrow["HouseName"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "户主编号":
                                if (!string.IsNullOrEmpty(danganrow["FamilyIDCardNo"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "与户主关系":
                                if (!string.IsNullOrEmpty(danganrow["HouseRelation"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "民族":
                                if (!string.IsNullOrEmpty(danganrow["Nation"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "户籍住址":
                                if (!string.IsNullOrEmpty(danganrow["HouseHoldAddress"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "工作单位":
                                if (!string.IsNullOrEmpty(danganrow["WorkUnit"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "本人电话":
                                if (!string.IsNullOrEmpty(danganrow["Phone"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "常住类型":
                                if (!string.IsNullOrEmpty(danganrow["LiveType"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "血型":
                                if (!string.IsNullOrEmpty(danganrow["BloodType"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "RH阴性":
                                if (!string.IsNullOrEmpty(danganrow["RH"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "文化程度":
                                if (!string.IsNullOrEmpty(danganrow["Culture"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "职业":
                                if (!string.IsNullOrEmpty(danganrow["Job"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "婚姻情况":
                                if (!string.IsNullOrEmpty(danganrow["MaritalStatus"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "责任医生1":
                                if (!string.IsNullOrEmpty(danganrow["Doctor"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "邮箱":
                                if (!string.IsNullOrEmpty(danganrow["Email"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;

                            case "家族史":
                                RecordsFamilyHistoryInfoModel FamilyHistoryInfos = new RecordsFamilyHistoryInfoBLL().GetModel(str);
                                if (FamilyHistoryInfos != null)
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "疾病":
                                List<RecordsIllnessHistoryInfoModel> IllnessHistoryInfo1 = new RecordsIllnessHistoryInfoBLL().GetModelList(string.Format(" IDCardNo = '{0}' AND IllnessType = '{1}' ", str, 1));
                                if (IllnessHistoryInfo1.Count > 0)
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "厨房排风设施":
                                if (!string.IsNullOrEmpty(danganrow["BlowMeasure"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "燃料类型":
                                if (!string.IsNullOrEmpty(danganrow["FuelType"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "饮水":
                                if (!string.IsNullOrEmpty(danganrow["DrinkWater"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "厕所":
                                if (!string.IsNullOrEmpty(danganrow["Toilet"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;
                            case "禽兽类":
                                if (!string.IsNullOrEmpty(danganrow["LiveStockRail"].ToString()))
                                {
                                    baseinfocount++;
                                }
                                break;

                            default: break;
                        }
                    }
                }

                baseinforate = (baseinfocount / this.Sumbaseinfo).ToString("0.00%");
            }
            return baseinforate;
        }
        private string GetPhysicalexamrate(string str) //健康体检完整率
        {
            string physicalexamrate = "";
            double physicalexamcount = 0;

            if (this.Sumphysical != 0)
            {
                DataTable GetPhysicalexamdt = new RecordsBaseInfoBLL().JiankangCheckDt(str).Tables[0];
                RecordsBaseInfoModel basemodel = new RecordsBaseInfoBLL().GetModel(str);
                bool flagsex = false;
                if (basemodel != null && basemodel.Sex == "2")
                {
                    flagsex = true;
                }
                if (GetPhysicalexamdt.Rows.Count > 0)
                {
                    DataRow Physicalexamrow = GetPhysicalexamdt.Rows[0];
                    foreach (DataRow item in requireGerneralDt.Rows)
                    {
                        switch (item["ChinName"].ToString())
                        {
                            case "症状":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Symptom"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "体温":
                                if (!string.IsNullOrEmpty(Physicalexamrow["AnimalHeat"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;

                            case "呼吸频率":
                                if (!string.IsNullOrEmpty(Physicalexamrow["BreathRate"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "腰围":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Waistline"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "身高":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Height"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "脉率":
                                if (!string.IsNullOrEmpty(Physicalexamrow["PulseRate"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "体重":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Weight"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "体质指数":
                                if (!string.IsNullOrEmpty(Physicalexamrow["BMI"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "左侧低血压":
                                if (!string.IsNullOrEmpty(Physicalexamrow["LeftPre"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "右侧低血压":
                                if (!string.IsNullOrEmpty(Physicalexamrow["RightPre"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "左侧高血压":
                                if (!string.IsNullOrEmpty(Physicalexamrow["LeftHeight"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "右侧高血压":
                                if (!string.IsNullOrEmpty(Physicalexamrow["RightHeight"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "左侧原因":
                                if (!string.IsNullOrEmpty(Convert.ToString(Physicalexamrow["LeftReason"])))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "右侧原因":
                                if (!string.IsNullOrEmpty(Convert.ToString(Physicalexamrow["RightReason"])))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "饮食习惯":
                                if (!string.IsNullOrEmpty(Physicalexamrow["DietaryHabit"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "职业病危害因素接触史":
                                if (!string.IsNullOrEmpty(Physicalexamrow["CareerHarmFactorHistory"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "锻炼频率":
                                if (!string.IsNullOrEmpty(Convert.ToString(Physicalexamrow["ExerciseRate"])))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "吸烟状况":
                                if (!string.IsNullOrEmpty(Convert.ToString(Physicalexamrow["SmokeCondition"])))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "饮酒频率":
                                if (!string.IsNullOrEmpty(Convert.ToString(Physicalexamrow["DrinkRate"])))
                                {
                                    physicalexamcount++;
                                }
                                break;

                            case "锻炼方式":
                                if (!string.IsNullOrEmpty(Convert.ToString(Physicalexamrow["ExerciseExistense"])))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "皮肤":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Skin"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "巩膜":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Sclere"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "淋巴结":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Lymph"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "桶状胸":
                                if (!string.IsNullOrEmpty(Physicalexamrow["BarrelChest"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "呼吸音":
                                if (!string.IsNullOrEmpty(Physicalexamrow["BreathSounds"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "罗音":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Rale"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "心率":
                                if (!string.IsNullOrEmpty(Physicalexamrow["HeartRate"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "心律":
                                if (!string.IsNullOrEmpty(Physicalexamrow["HeartRhythm"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "杂音":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Noise"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "包块":
                                if (!string.IsNullOrEmpty(Physicalexamrow["EnclosedMass"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "下肢水肿":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Edema"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "足背动脉搏动":
                                if (!string.IsNullOrEmpty(Physicalexamrow["FootBack"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "肛门指诊":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Anus"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "乳腺":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Breast"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "压痛":
                                if (!string.IsNullOrEmpty(Physicalexamrow["PressPain"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "肝大":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Liver"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "脾大":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Spleen"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "移动性浊音":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Voiced"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "眼底":
                                if (!string.IsNullOrEmpty(Physicalexamrow["EyeRound"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "其他":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Other"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "外阴":
                                if (flagsex) //性别是女
                                {
                                    if (!string.IsNullOrEmpty(Physicalexamrow["Vulva"].ToString()))
                                    {
                                        physicalexamcount++;
                                    }
                                }
                                else
                                {
                                    this.Sumphysical--;
                                }
                                break;
                            case "附件":
                                if (flagsex) //性别是女
                                {
                                    if (!string.IsNullOrEmpty(Physicalexamrow["Attach"].ToString()))
                                    {
                                        physicalexamcount++;
                                    }
                                }
                                else
                                {
                                    this.Sumphysical--;
                                }
                                break;
                            case "宫体":
                                if (flagsex) //性别是女
                                {
                                    if (!string.IsNullOrEmpty(Physicalexamrow["Corpus"].ToString()))
                                    {
                                        physicalexamcount++;
                                    }
                                }
                                else
                                {
                                    this.Sumphysical--;
                                }
                                break;
                            case "宫颈":
                                if (flagsex) //性别是女
                                {
                                    if (!string.IsNullOrEmpty(Physicalexamrow["CervixUteri"].ToString()))
                                    {
                                        physicalexamcount++;
                                    }
                                }
                                else
                                {
                                    this.Sumphysical--;
                                }
                                break;
                            case "阴道":
                                if (flagsex) //性别是女
                                {
                                    if (!string.IsNullOrEmpty(Physicalexamrow["Vagina"].ToString()))
                                    {
                                        physicalexamcount++;
                                    }
                                }
                                else
                                {
                                    this.Sumphysical--;
                                }
                                break;
                            case "空腹血糖DL":
                                if (!string.IsNullOrEmpty(Physicalexamrow["FPGL"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "其他1":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Other1"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "宫颈涂片":
                                if (flagsex) //性别是女
                                {
                                    if (!string.IsNullOrEmpty(Physicalexamrow["CERVIX"].ToString()))
                                    {
                                        physicalexamcount++;
                                    }
                                }
                                else
                                {
                                    this.Sumphysical--;
                                }
                                break;
                            case "腹部B超":
                                if (!string.IsNullOrEmpty(Physicalexamrow["BCHAO"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "胸部X线片":
                                if (!string.IsNullOrEmpty(Physicalexamrow["CHESTX"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "血清高密度脂蛋白胆固醇":
                                if (!string.IsNullOrEmpty(Physicalexamrow["HeiCho"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "甘油三酯":
                                if (!string.IsNullOrEmpty(Physicalexamrow["TG"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "血清低密度脂蛋白胆固醇":
                                if (!string.IsNullOrEmpty(Physicalexamrow["LowCho"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "总胆固醇":
                                if (!string.IsNullOrEmpty(Physicalexamrow["TC"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "血钠浓度":
                                if (!string.IsNullOrEmpty(Physicalexamrow["HYPE"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "血钾浓度":
                                if (!string.IsNullOrEmpty(Physicalexamrow["PC"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "血尿素氮":
                                if (!string.IsNullOrEmpty(Physicalexamrow["BUN"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "血清肌酐":
                                if (!string.IsNullOrEmpty(Physicalexamrow["SCR"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "r-谷氨酰转肽酶":
                                if (!string.IsNullOrEmpty(Physicalexamrow["GT"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "总胆红素":
                                if (!string.IsNullOrEmpty(Physicalexamrow["TBIL"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "结合胆红素":
                                if (!string.IsNullOrEmpty(Physicalexamrow["CB"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "白蛋白":
                                if (!string.IsNullOrEmpty(Physicalexamrow["BP"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "血清谷草转氨酶":
                                if (!string.IsNullOrEmpty(Physicalexamrow["GOT"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "血清谷丙转氨酶":
                                if (!string.IsNullOrEmpty(Physicalexamrow["SGPT"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "心电图":
                                if (!string.IsNullOrEmpty(Physicalexamrow["ECG"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;

                            case "乙型肝炎表面抗原":
                                if (!string.IsNullOrEmpty(Physicalexamrow["HBSAG"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "糖化血红蛋白":
                                if (!string.IsNullOrEmpty(Physicalexamrow["HBALC"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "大便潜血":
                                if (!string.IsNullOrEmpty(Physicalexamrow["FOB"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "尿常规其他":
                                if (!string.IsNullOrEmpty(Physicalexamrow["UrineOther"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "尿潜血":
                                if (!string.IsNullOrEmpty(Physicalexamrow["BLD"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "尿酮体":
                                if (!string.IsNullOrEmpty(Physicalexamrow["KET"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "尿糖":
                                if (!string.IsNullOrEmpty(Physicalexamrow["GLU"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "尿蛋白":
                                if (!string.IsNullOrEmpty(Physicalexamrow["PRO"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "尿微量白蛋白":
                                if (!string.IsNullOrEmpty(Physicalexamrow["ALBUMIN"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;

                            case "血常规其他":
                                if (!string.IsNullOrEmpty(Physicalexamrow["BloodOther"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "血小板":
                                if (!string.IsNullOrEmpty(Physicalexamrow["PLT"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "白细胞":
                                if (!string.IsNullOrEmpty(Physicalexamrow["WBC"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "血红蛋白":
                                if (!string.IsNullOrEmpty(Physicalexamrow["HB"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "餐后2H血糖":
                                if (!string.IsNullOrEmpty(Physicalexamrow["FPGDL"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "口唇":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Lips"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "齿列":
                                if (!string.IsNullOrEmpty(Physicalexamrow["ToothResides"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "咽部":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Pharyngeal"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "听力":
                                if (!string.IsNullOrEmpty(Physicalexamrow["Listen"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;

                            case "运动功能":
                                if (!string.IsNullOrEmpty(Physicalexamrow["SportFunction"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "矫正右":
                                if (!string.IsNullOrEmpty(Physicalexamrow["RightEyecorrect"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "矫正左":
                                if (!string.IsNullOrEmpty(Physicalexamrow["LeftEyecorrect"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "右眼":
                                if (!string.IsNullOrEmpty(Physicalexamrow["RightView"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "左眼":
                                if (!string.IsNullOrEmpty(Physicalexamrow["LeftView"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "脑血管疾病":
                                if (!string.IsNullOrEmpty(Physicalexamrow["BrainDis"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "肾脏疾病":
                                if (!string.IsNullOrEmpty(Physicalexamrow["RenalDis"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "心脏疾病":
                                if (!string.IsNullOrEmpty(Physicalexamrow["HeartDis"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "血管疾病":
                                if (!string.IsNullOrEmpty(Physicalexamrow["VesselDis"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "眼部疾病":
                                if (!string.IsNullOrEmpty(Physicalexamrow["EyeDis"].ToString()))
                                {
                                    physicalexamcount++;

                                }
                                break;
                            case "神经系统疾病":
                                if (!string.IsNullOrEmpty(Physicalexamrow["NerveDis"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "其他系统疾病":
                                if (!string.IsNullOrEmpty(Physicalexamrow["ElseDis"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "是否正常1:体检无异常2:有异常":
                                if (!string.IsNullOrEmpty(Physicalexamrow["IsNormal"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "健康指导":
                                if (!string.IsNullOrEmpty(Physicalexamrow["HealthGuide"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "危险因素控制":
                                if (!string.IsNullOrEmpty(Physicalexamrow["DangerControl"].ToString()))
                                {
                                    physicalexamcount++;
                                }
                                break;
                            case "非免疫预防接种史":
                                List<RecordsInoculationHistoryModel> InoculationHistorys = new RecordsInoculationHistoryBLL().GetModelList(string.Format("IDCardNo = '{0}' and OutKey={1}", str, Physicalexamrow["ID"].ToString()));
                                if (InoculationHistorys.Count > 0)
                                {
                                    physicalexamcount++;
                                }
                                break;
                            default: break;
                        }
                    }
                }
                physicalexamrate = (physicalexamcount / this.Sumphysical).ToString("0.00%");
            }
            return physicalexamrate;
        }
        private string GetOldmenrate(string str) //老年人随访完整率
        {
            string oldmenrate = "";
            double  oldmencount = 0;
            if (this.Sumold != 0)
            {
                DataTable olderdt = new OlderSelfCareabilityBLL().GetList(string.Format("IDCardNo = '{0}'", str)).Tables[0];
                DataTable oldtype = new RecordsBaseInfoBLL().GetList(string.Format(" and IDCardNo = '{0}' and PopulationType like '%4%' ", str)).Tables[0];
                if (olderdt.Rows.Count > 0)
                {
                    DataRow rows = olderdt.Rows[0];
                    foreach (DataRow item in requireolddt.Rows)
                    {
                        switch (item["ChinName"].ToString())
                        {
                            case "进餐":
                                if (!string.IsNullOrEmpty(rows["Dine"].ToString()))
                                {
                                    oldmencount++;
                                }
                                break;
                            case "梳洗":
                                if (!string.IsNullOrEmpty(rows["Groming"].ToString()))
                                {
                                    oldmencount++;
                                }
                                break;
                            case "穿衣":
                                if (!string.IsNullOrEmpty(rows["Dressing"].ToString()))
                                {
                                    oldmencount++;
                                }
                                break;
                            case "如厕":
                                if (!string.IsNullOrEmpty(rows["Tolet"].ToString()))
                                {
                                    oldmencount++;
                                }
                                break;
                            case "活动":
                                if (!string.IsNullOrEmpty(rows["Activity"].ToString()))
                                {
                                    oldmencount++;
                                }
                                break;
                            case "随访医生":
                                if (!string.IsNullOrEmpty(rows["FollowUpDoctor"].ToString()))
                                {
                                    oldmencount++;
                                }
                                break;
                            case "总得分":
                                if (!string.IsNullOrEmpty(rows["TotalScore"].ToString()))
                                {
                                    oldmencount++;
                                }
                                break;
                            case "随访日期":
                                if (!string.IsNullOrEmpty(rows["FollowUpDate"].ToString()))
                                {
                                    oldmencount++;
                                }
                                break;
                            case "下次随访日期":
                                if (!string.IsNullOrEmpty(rows["NextfollowUpDate"].ToString()))
                                {
                                    oldmencount++;
                                }
                                break;
                            case "下次随访目标":
                                if (!string.IsNullOrEmpty(rows["NextVisitAim"].ToString()))
                                {
                                    oldmencount++;
                                }
                                break;
                            default: break;
                        }
                    }
                }
                if (oldtype.Rows.Count > 0)
                {
                    oldmenrate = (oldmencount / this.Sumold).ToString("0.00%");
                }
            }
            return oldmenrate;
        }
        private string GetHyperrate(string str) //高血压随访完整率
        {
            string hyperrate = "";
            double hypercount = 0;
            if (this.Sumhyper != 0)
            {
                DataTable drugdt = new ChronicDrugConditionBLL().GetList("IDCardNo ='" + str + "' and Type = '1' ").Tables[0];
                DataTable Hyperdt = new RecordsBaseInfoBLL().HyperDt(str).Tables[0];
                DataTable hypertype = new RecordsBaseInfoBLL().GetList(string.Format(" and IDCardNo = '{0}' and PopulationType like '%6%' ", str)).Tables[0];
                if (Hyperdt.Rows.Count > 0)
                {
                    DataRow row = Hyperdt.Rows[0];
                    foreach (DataRow item in requirehyperbasedt.Rows)
                    {
                        switch (item["ChinName"].ToString())
                        {
                            case "家族史":
                                if (!string.IsNullOrEmpty(row["FatherHistory"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "目前症状":
                                if (!string.IsNullOrEmpty(row["Symptom1"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "是否使用降压药":
                                if (!string.IsNullOrEmpty(row["Hypotensor"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "管理组别":
                                if (!string.IsNullOrEmpty(row["ManagementGroup"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "病历来源":
                                if (!string.IsNullOrEmpty(row["CaseOurce"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "高血压并发症情况":
                                if (!string.IsNullOrEmpty(row["HypertensionComplication"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "症状":
                                if (!string.IsNullOrEmpty(row["Symptom"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "血压":
                                if (!(string.IsNullOrEmpty(row["Hypertension"].ToString()) && string.IsNullOrEmpty(row["Hypotension"].ToString())))
                                {
                                    hypercount++;
                                }
                                break;
                            case "心率":
                                if (!string.IsNullOrEmpty(row["Heartrate"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "体质指数":
                                if (!string.IsNullOrEmpty(row["BMI"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "体质指数下次随访目标":
                                if (!string.IsNullOrEmpty(row["BMITarGet"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "体重":
                                if (!string.IsNullOrEmpty(row["Weight"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "体重下次随访目标":
                                if (!string.IsNullOrEmpty(row["WeightTarGet"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "日吸烟量":
                                if (!string.IsNullOrEmpty(row["DailySmokeNum"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "日吸烟量下次随访目标":
                                if (!string.IsNullOrEmpty(row["DailySmokeNumTarget"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "日饮酒量":
                                if (!string.IsNullOrEmpty(row["DailyDrinkNum"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "饮酒量下次随访目标":
                                if (!string.IsNullOrEmpty(row["DailyDrinkNumTarget"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "运动":
                                if (!(string.IsNullOrEmpty(row["SportTimePerWeek"].ToString()) && string.IsNullOrEmpty(row["SportPerMinuteTime"].ToString())))
                                {
                                    hypercount++;
                                }
                                break;
                            case "运动下次随访目标":
                                if (!(string.IsNullOrEmpty(row["SportPerMinutesTimeTarget"].ToString()) && string.IsNullOrEmpty(row["SportTimeSperWeekTarget"].ToString())))
                                {
                                    hypercount++;
                                }
                                break;
                            case "摄盐情况":
                                if (!string.IsNullOrEmpty(row["EatSaltType"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "摄盐情况下次随访目标":
                                if (!string.IsNullOrEmpty(row["EatSaltTarGet"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "心里调整":
                                if (!string.IsNullOrEmpty(row["PsyChoadJustMent"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "服药依从性":
                                if (!string.IsNullOrEmpty(row["MedicationCompliance"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "药物不良反应":
                                if (!string.IsNullOrEmpty(row["Adr"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "用药情况":
                                if (drugdt.Rows.Count > 0)
                                {
                                    hypercount++;
                                }
                                break;
                            case "随访日期":
                                if (!string.IsNullOrEmpty(row["FollowUpDate"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "随访医生":
                                if (!string.IsNullOrEmpty(row["FollowUpDoctor"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "随访方式":
                                if (!string.IsNullOrEmpty(row["FollowUpWay"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "身高":
                                if (!string.IsNullOrEmpty(row["Hight"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "体征其他":
                                if (!string.IsNullOrEmpty(row["PhysicalSympToMother"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "遵医行为":
                                if (!string.IsNullOrEmpty(row["ObeyDoctorBehavior"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "辅助检查":
                                if (!string.IsNullOrEmpty(row["AssistantExam"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "此次随访分类":
                                if (!string.IsNullOrEmpty(row["FollowUpType"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                       
                            case "此次随访医生建议":
                                if (!string.IsNullOrEmpty(row["DoctorView"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "转诊情况":
                                if (!string.IsNullOrEmpty(row["IsReferral"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            case "下次随访日期":
                                if (!string.IsNullOrEmpty(row["NextFollowUpDate"].ToString()))
                                {
                                    hypercount++;
                                }
                                break;
                            default: break;
                        }
                    }
                }
                if (hypertype.Rows.Count > 0)
                {
                    hyperrate = (hypercount / this.Sumhyper).ToString("0.00%");
                }
            }
            return hyperrate;
        }
        private string GetDiadetesrate(string str) //糖尿病随访完整率
        {
            string diadetesrate = "";
            double diadetescount = 0;
            if (this.Sumdia != 0)
            {
                DataTable drugdt = new ChronicDrugConditionBLL().GetList(" IDCardNo = '" + str + "' and Type = '2' ").Tables[0];
                DataTable Diadetesdt = new RecordsBaseInfoBLL().DiabetesDt(str).Tables[0];
                DataTable diatype = new RecordsBaseInfoBLL().GetList(string.Format(" and IDCardNo = '{0}' and PopulationType like '%7%' ", str)).Tables[0];
                if (Diadetesdt.Rows.Count > 0)
                {
                    DataRow row = Diadetesdt.Rows[0];
                    foreach (DataRow item in requirediabasedt.Rows)
                    {
                        switch (item["ChinName"].ToString())
                        {
                            case "家族史":
                                if (!string.IsNullOrEmpty(row["FamilyHistory"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "糖尿病类型":
                                if (!string.IsNullOrEmpty(row["DiabetesType"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "确诊时间":
                                if (!string.IsNullOrEmpty(row["DiabetesTime"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "确诊单位":
                                if (!string.IsNullOrEmpty(row["DiabetesWork"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "是否使用胰岛素":
                                if (!string.IsNullOrEmpty(row["Insulin"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "胰岛素用量":
                                if (!string.IsNullOrEmpty(row["InsulinWeight"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "是否使用口服降糖药":
                                if (!string.IsNullOrEmpty(row["EnalaprilMelete"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "目前症状":
                                if (!string.IsNullOrEmpty(row["Symptom1"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "管理组别":
                                if (!string.IsNullOrEmpty(row["ManagementGroup"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "病例来源":
                                if (!string.IsNullOrEmpty(row["CaseSource"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "是否终止管理":
                                if (!string.IsNullOrEmpty(row["EndManage"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "症状":
                                if (!string.IsNullOrEmpty(row["Symptom"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "血压":
                                if (!(string.IsNullOrEmpty(row["Hypertension"].ToString()) && string.IsNullOrEmpty(row["Hypotension"].ToString())))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "体质指数":
                                if (!string.IsNullOrEmpty(row["BMI"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "体质指数下次随访目标":
                                if (!string.IsNullOrEmpty(row["BMITarget"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "足背动脉搏动":
                                if (!string.IsNullOrEmpty(row["DorsalisPedispulse"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "体重":
                                if (!string.IsNullOrEmpty(row["Weight"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "体重下次随访目标":
                                if (!string.IsNullOrEmpty(row["TargetWeight"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "日吸烟量":
                                if (!string.IsNullOrEmpty(row["DailySmokeNum"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;

                            case "日吸烟量下次随访目标":
                                if (!string.IsNullOrEmpty(row["DailySmokeNumTarget"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "日饮酒量":
                                if (!string.IsNullOrEmpty(row["DailyDrinkNum"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "日饮酒量下次随访目标":
                                if (!string.IsNullOrEmpty(row["DailyDrinkNumTarget"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "运动":
                                if (!(string.IsNullOrEmpty(row["SportTimePerWeek"].ToString()) && string.IsNullOrEmpty(row["SportPerMinuteTime"].ToString())))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "运动下次随访目标":
                                if (!(string.IsNullOrEmpty(row["SportPerMinuteTimeTarget"].ToString()) && string.IsNullOrEmpty(row["SportTimePerWeekTarget"].ToString())))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "主食":
                                if (!string.IsNullOrEmpty(row["StapleFooddailyg"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "主食下次随访目标":
                                if (!string.IsNullOrEmpty(row["StapleFooddailygTarget"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "心里调整":
                                if (!string.IsNullOrEmpty(row["PsychoAdjustment"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "遵医行为":
                                if (!string.IsNullOrEmpty(row["ObeyDoctorBehavior"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "空腹血糖值":
                                if (!string.IsNullOrEmpty(row["FPG"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "糖化血红蛋白":
                                if (!string.IsNullOrEmpty(row["HbAlc"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "检查日期":
                                if (!string.IsNullOrEmpty(row["ExamDate"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "服药依从性":
                                if (!string.IsNullOrEmpty(row["MedicationCompliance"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "药物不良反应":
                                if (!string.IsNullOrEmpty(row["Adr"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "低血糖反应":
                                if (!string.IsNullOrEmpty(row["HypoglyceMiarreAction"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "随访分类":
                                if (!string.IsNullOrEmpty(row["VisitType"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;

                            case "胰岛素种类":
                                if (!string.IsNullOrEmpty(row["InsulinType"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "用法与用量":
                                if (!string.IsNullOrEmpty(row["InsulinUsage"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "用药情况":
                                if (drugdt.Rows.Count > 0)
                                {
                                    diadetescount++;
                                }
                                break;
                            case "随访日期":
                                if (!string.IsNullOrEmpty(row["VisitDate"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "随访医生":
                                if (!string.IsNullOrEmpty(row["VisitDoctor"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "随访方式":
                                if (!string.IsNullOrEmpty(row["VisitWay"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "体征其他":
                                if (!string.IsNullOrEmpty(row["PhysicalSymptomMother"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "身高":
                                if (!string.IsNullOrEmpty(row["Hight"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "随机血糖":
                                if (!string.IsNullOrEmpty(row["RBG"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "餐后2小时血糖":
                                if (!string.IsNullOrEmpty(row["PBG"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "此次随访医生建议":
                                if (!string.IsNullOrEmpty(row["DoctorView"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "转诊情况":
                                if (!string.IsNullOrEmpty(row["IsReferral"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            case "下次随访日期":
                                if (!string.IsNullOrEmpty(row["NextVisitDate"].ToString()))
                                {
                                    diadetescount++;
                                }
                                break;
                            default: break;
                        }
                    }
                }

                if (diatype.Rows.Count > 0)
                {
                    diadetesrate = (diadetescount / this.Sumdia).ToString("0.00%");
                }
            }
            return diadetesrate;
        }
        public bool SaveModelToDB()
        {
            return true;
        }

        public void NotisfyChildStatus()
        {

        }

        public void UpdataToModel()
        {

        }
        public bool EveryThingIsOk { get; set; }
        private List<RecordsBaseInfoModel> findModels { get; set; }
        public bool HaveToSave { get; set; }
        public RecordsBaseInfoModel Model { get; set; }
        public string SaveDataInfo { get; set; }
        public List<RecordsIllnessHistoryInfoModel> IllnessHistoryInfo { get; set; }
        public RecordsCustomerBaseInfoModel CustomerBaseInfo { get; set; }
        RecordsGeneralConditionModel GerneralCondition { get; set; }
        RecordsLifeStyleModel LifeStyle { get; set; }
        RecordsPhysicalExamModel PhysicalExam { get; set; }
        RecordsAssistCheckModel AssistCheck { get; set; }
        RecordsVisceraFunctionModel VisceraFunction { get; set; }
        RecordsHealthQuestionModel HealthQuestion { get; set; }
        RecordsAssessmentGuideModel AssessmentGuides { get; set; }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
