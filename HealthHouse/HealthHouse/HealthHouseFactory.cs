using KangShuoTech.Utilities.CommonUI;

namespace HealthHouse
{
    using Properties;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Drawing;
    using KangShuoTech.DataAccessProjects.Model;

    internal class HealthHouseFactory : ChildFormFactory
    {
        public HealthHouseFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("一般情况", new Image[] { Resources.normer_png, Resources.normer_png, Resources.normer_png }));
            this.ItemParamters.Add(new ItemParamters("辅助检查", new Image[] { Resources.check, Resources.check, Resources.check }));
            this.ItemParamters.Add(new ItemParamters("中医体质", new Image[] { Resources.medPhy, Resources.medPhy, Resources.medPhy }));
            this.ItemParamters.Add(new ItemParamters("心血管", new Image[] { Resources.心血管, Resources.心血管, Resources.心血管 }));
            this.ItemParamters.Add(new ItemParamters("骨密度", new Image[] { Resources.骨密度, Resources.骨密度, Resources.骨密度 }));
            this.ItemParamters.Add(new ItemParamters("肺功能", new Image[] { Resources.肺功能, Resources.肺功能, Resources.肺功能 }));
            this.ItemParamters.Add(new ItemParamters("心电", new Image[] { Resources.心电, Resources.心电, Resources.心电 }));
            this.ItemParamters.Add(new ItemParamters("B超", new Image[] { Resources.B超, Resources.B超, Resources.B超 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            PhysicalForm iParentFrm = this.MControler.IParentFrm as PhysicalForm;

            if (name == "一般情况")
            {
                form = new HealthHouseForm();
                (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
            }
            else if (name == "辅助检查")
            {
                form = new PhysicalAssistCheck();
                (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
            }
            else if (name == "中医体质")
            {
                form = new HealthMedicalForm();
                (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
            }
            else if (name == "骨密度")
            {
                form = new HealthBoneForm();
                (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
            }
            else if (name == "心血管")
            {
                form = new HealthVascularForm();
                (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
            }
            else if (name == "肺功能")
            {
                form = new HealthLungForm();
                (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
            }
            else if (name == "心电")
            {
                form = new HealthECG();
                (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
            }
            else if (name == "B超")
            {
                form = new HealthBCHAO();
                (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
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

        public static int ID { get; set; }

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
    }
}

