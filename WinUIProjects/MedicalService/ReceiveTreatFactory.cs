using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace MedicalService
{
    using Properties;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Drawing;

    internal  class ReceiveTreatFactory : ChildFormFactory
    {
        public ReceiveTreatFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("接诊", new Image[] { Resources.btnjiezhen00, Resources.btnjiezhen01, Resources.btnjiezhen01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
                if (str == "接诊")
                {
                    form = new ReceiveTreat();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
               
            }

            (form as Form).Text = name;
            form.HaveToSave = true;
            return form;
        }

        public override List<ItemParamters> ItemParamters { get; set; }

        public override IMDIControler MControler { get; set; }

        public override string MDIFrmText
        {
            get
            {
                return "医疗服务";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
