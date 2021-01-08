using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace MedicalService
{
    using Properties;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Drawing;

    public class ReferralFactory : ChildFormFactory
    {
        public ReferralFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("双向转诊", new Image[] { Resources.btnzhuanzhen00, Resources.btnzhuanzhen01, Resources.btnzhuanzhen01}));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
                if (str == "双向转诊")
                {
                    form = new Referral();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
               
            }

            (form as Form).Text = name;
            form.HaveToSave =true;
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
