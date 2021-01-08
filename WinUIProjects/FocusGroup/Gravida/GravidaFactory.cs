using FocusGroup.Gravida;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup
{
    using Properties;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Drawing;

    internal class GravidaFactory : ChildFormFactory
    {
        public GravidaFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("基本信息", new Image[] { Resources.btnjiben00, Resources.btnjiben01, Resources.btnjiben01 }));
            this.ItemParamters.Add(new ItemParamters("产前随访1", new Image[] { Resources.btnchanqianshuifang0100, Resources.btnchanqianshuifang0101, Resources.btnchanqianshuifang0101 }));
            this.ItemParamters.Add(new ItemParamters("产前随访2", new Image[] { Resources.btnchanqianshuifang0200, Resources.btnchanqianshuifang0201, Resources.btnchanqianshuifang0201 }));
            this.ItemParamters.Add(new ItemParamters("产前随访3", new Image[] { Resources.btnchanqianshuifang0300, Resources.btnchanqianshuifang0301, Resources.btnchanqianshuifang0301 }));
            this.ItemParamters.Add(new ItemParamters("产前随访4", new Image[] { Resources.btnchanqianshuifang0400, Resources.btnchanqianshuifang0401, Resources.btnchanqianshuifang0401 }));
            this.ItemParamters.Add(new ItemParamters("产前随访5", new Image[] { Resources.btnchanqianshuifang0500, Resources.btnchanqianshuifang0501, Resources.btnchanqianshuifang0501 }));
            this.ItemParamters.Add(new ItemParamters("产后访视", new Image[] { Resources.btnchanhoufangshi00, Resources.btnchanhoufangshi01, Resources.btnchanhoufangshi01 }));
            this.ItemParamters.Add(new ItemParamters("产后42天", new Image[] { Resources.btn42jiancha00, Resources.btn42jiancha01, Resources.btn42jiancha01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            GravidaForm iParentFrm = this.MControler.IParentFrm as GravidaForm;
            switch (name)
            {
                case "基本信息":
                {
                    GravidaInfoForm info = new GravidaInfoForm {
                        par_From = iParentFrm
                    };
                    form = info;
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;
                }
                case "产前随访1":
                {
                    GravidaFirstVisitForm visit = new GravidaFirstVisitForm
                    {
                        par_From = iParentFrm
                    };
                    form = visit;
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;
                }
                case "产前随访2":
                form = new GravidaTwoToFiveVisitForm("2");
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

                case "产前随访3":
                    form = new GravidaTwoToFiveVisitForm("3");
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

                case "产前随访4":
                    form = new GravidaTwoToFiveVisitForm("4");
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

                case "产前随访5":
                    form = new GravidaTwoToFiveVisitForm("5");
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

                case "产后访视":
                    form = new AfterKidBirthVisitForm();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;

                case "产后42天":
                    form = new After42DaysVisitForm();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    break;
            }
            (form as Form).Text = name;
            form.HaveToSave = true;
            return form;
        }

        public override List<ItemParamters> ItemParamters { get; set; }

        public override IMDIControler MControler { get; set; }

        public static int ID { get; set; }

        public override string MDIFrmText
        {
            get
            {
                return "孕产妇管理";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}

