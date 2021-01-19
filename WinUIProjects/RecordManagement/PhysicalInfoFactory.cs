using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace ArchiveInfo
{
    using ArchiveInfo.Properties;

    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Drawing;


    public class PhysicalInfoFactory : ChildFormFactory
    {

        public PhysicalInfoFactory()
        {
            this.ItemParamters = new List<ItemParamters>();

            this.ItemParamters.Add(new ItemParamters("一般情况", new Image[] { Resources.btnyibanqingkuang00, Resources.btnyibanqingkuang01, Resources.btnyibanqingkuang01 }));
            this.ItemParamters.Add(new ItemParamters("生活方式", new Image[] { Resources.btnshenghuofangshi00, Resources.btnshenghuofangshi01, Resources.btnshenghuofangshi01 }));
            this.ItemParamters.Add(new ItemParamters("查体信息", new Image[] { Resources.btnchatixinxi00, Resources.btnchatixinxi01, Resources.btnchatixinxi01 }));
            this.ItemParamters.Add(new ItemParamters("辅助检查", new Image[] { Resources.btnfuzhujiancha00, Resources.btnfuzhujiancha01, Resources.btnfuzhujiancha01 }));
            this.ItemParamters.Add(new ItemParamters("脏器功能", new Image[] { Resources.btnzangqigongneng00, Resources.btnzangqigongneng01, Resources.btnzangqigongneng01 }));
            this.ItemParamters.Add(new ItemParamters("健康问题", new Image[] { Resources.btnjiankangwenti00, Resources.btnjiankangwenti01, Resources.btnjiankangwenti01 }));
            this.ItemParamters.Add(new ItemParamters("治疗情况", new Image[] { Resources.btnzhiliaoqingkuang00, Resources.btnyibanqingkuang01, Resources.btnyibanqingkuang01 }));
            this.ItemParamters.Add(new ItemParamters("健康评价", new Image[] { Resources.btnjiankangpingjia00, Resources.btnjiankangpingjia01, Resources.btnjiankangpingjia01 }));
            this.ItemParamters.Add(new ItemParamters("医师签名", new Image[] { Resources.btnyishiqianzi00, Resources.btnyishiqianzi01, Resources.btnyishiqianzi01 }));
        }

        public PhysicalInfoFactory(int type)
        {
            this.ItemParamters = new List<ItemParamters>();

            switch (type)
            {
                case 1:
                    this.ItemParamters.Add(new ItemParamters("一般情况", new Image[] { Resources.btnyibanqingkuang00, Resources.btnyibanqingkuang01, Resources.btnyibanqingkuang01 }));
                    break;
                case 2:
                    this.ItemParamters.Add(new ItemParamters("生活方式", new Image[] { Resources.btnshenghuofangshi00, Resources.btnshenghuofangshi01, Resources.btnshenghuofangshi01 }));
                    break;
                case 3:
                    this.ItemParamters.Add(new ItemParamters("查体信息", new Image[] { Resources.btnchatixinxi00, Resources.btnchatixinxi01, Resources.btnchatixinxi01 }));
                    break;
                case 4:
                    this.ItemParamters.Add(new ItemParamters("辅助检查", new Image[] { Resources.btnfuzhujiancha00, Resources.btnfuzhujiancha01, Resources.btnfuzhujiancha01 }));
                    break;
                case 5:
                    this.ItemParamters.Add(new ItemParamters("脏器功能", new Image[] { Resources.btnzhonghitizhi00, Resources.btnzhonghitizhi01, Resources.btnzhonghitizhi01 }));
                    break;
                case 6:
                    this.ItemParamters.Add(new ItemParamters("健康问题", new Image[] { Resources.btnjiankangwenti00, Resources.btnjiankangwenti01, Resources.btnjiankangwenti01 }));
                    break;
                case 7:
                    this.ItemParamters.Add(new ItemParamters("健康评价", new Image[] { Resources.btnjiankangpingjia00, Resources.btnjiankangpingjia01, Resources.btnjiankangpingjia01 }));
                    break;
                case 8:
                    this.ItemParamters.Add(new ItemParamters("治疗情况", new Image[] { Resources.btnzhiliaoqingkuang00, Resources.btnyibanqingkuang01, Resources.btnyibanqingkuang01 }));
                    break;
            }
        }
        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            PhysicalForm iParentFrm = this.MControler.IParentFrm as PhysicalForm;
            switch (name)
            {
                case "一般情况":
                    form = new NormalStateUserControl(iParentFrm.PhysicalExam);
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

                case "生活方式":
                    form = new UCLifeStyle();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

                case "查体信息":
                    form = new PhysicalExamForm();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

                case "辅助检查":
                    form = new AidExamUserControl();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

                case "脏器功能":
                    form = new UCMedicalPhysique();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

                case "健康问题":
                    form = new UCHealthQuestion();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

                case "治疗情况":
                    form = new UCCureState();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

                case "健康评价":
                    form = new HealthAppraisalUserControl();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;
                case "医师签名":
                    form = new SignFeedBack();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;
                case "高血压调查表":
                    form = new frmHyperSurvey();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

                case "冠心病脑卒中报告卡":
                    form = new frmChdStrokeReport();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

                case "肿瘤报告卡":
                    form = new frmTumorReport();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

            }
            (form as Form).Text = name;
            form.HaveToSave = true;
            return form;
        }

        public override Dictionary<string, IChildForm> GetOneOrMoreForm()
        {
            Dictionary<string, IChildForm> dictionary = new Dictionary<string, IChildForm>();
            foreach (ItemParamters paramters in this.ItemParamters)
            {
                IChildForm form = this.CreateChildForm(paramters.Text);
                form.InitEveryThing();
                dictionary.Add(paramters.Text, form);
            }
            return dictionary;
        }

        public override List<ItemParamters> ItemParamters { get; set; }

        public override IMDIControler MControler { get; set; }

        public override string MDIFrmText
        {
            get
            {
                return "体检档案";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }

        public List<string> Strs_Children { get; set; }
        public static int ID { get; set; }
        public static int falgID { get; set; } //记录页面 PhysicalInfoFactory.ID的初始值,判断首次进入是不是直接点击的新增界面并且日期不是当前日期 falgID =0，如果是当前日期 falgID =1，
        public static bool NewAdd { get; set; } //记录是不是新增页面。不做是不是当前日期判断。
    }
}

