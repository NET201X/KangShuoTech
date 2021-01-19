using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace ArchiveInfo
{
    using Properties;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Drawing;

    internal class FamilyFactory : ChildFormFactory
    {
        public FamilyFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            //this.ItemParamters.Add(new ItemParamters("基本信息", new Image[] { Resources.baseInfo, Resources.baseInfo, Resources.baseInfo_Er }));
            this.ItemParamters.Add(new ItemParamters("基本信息", new Image[] { Resources.btnjiben00, Resources.btnjiben01, Resources.btnjiben01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str;
            if (((str = name) != null) && (str == "基本信息"))
            {
                form = new FamilyInfoForm();
                (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>) this.MControler.IParentFrm).Model;
            }
            (form as Form).Text = name;
            form.HaveToSave = true;
            return form;
        }

        public override Dictionary<string, IChildForm> GetOneOrMoreForm()
        {
            return new Dictionary<string, IChildForm>();
        }

        public override List<ItemParamters> ItemParamters { get; set; }

        public override IMDIControler MControler { get; set; }

        public override string MDIFrmText
        {
            get
            {
                return "家庭档案";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}

