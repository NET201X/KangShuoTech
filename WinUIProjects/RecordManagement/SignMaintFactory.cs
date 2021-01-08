using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace RecordManagement
{
    using RecordManagement.Properties;

    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Drawing;

    internal class SignMaintFactory : ChildFormFactory
    {
        public SignMaintFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("签字维护", new Image[] { Resources.btnqianziweihu00, Resources.btnqianiweihu01, Resources.btnqianiweihu01 }));
            
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;

            if (name == "签字维护")
            {
                form = new SignMaint();
                (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
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
                return "签字维护";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}