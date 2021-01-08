using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup.ChronicDisease
{
    using Properties;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Drawing;

    public class StrokeFactory : ChildFormFactory
    {
        public StrokeFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("患者随访", new Image[] { Resources.suifang00, Resources.suifang01, Resources.suifang01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str;
            if (((str = name) != null) && (str == "患者随访"))
            {
                form = new StrokeVisitForm();
                (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>) this.MControler.IParentFrm).Model;
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
                return "脑卒中管理";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }

        public List<string> Strs_Children { get; set; }
    }
}

