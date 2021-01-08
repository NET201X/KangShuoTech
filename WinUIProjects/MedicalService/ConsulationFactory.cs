using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.Utilities.CommonUI;
using System.Drawing;
using MedicalService.Properties;
using KangShuoTech.DataAccessProjects.Model;
using System.Windows.Forms;

namespace MedicalService
{
    public class ConsulationFactory : ChildFormFactory
    {
        public ConsulationFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("会诊", new Image[] { Resources.btnhuizhen00, Resources.btnhuizhen01, Resources.btnhuizhen01}));
        }
        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
                if (str == "会诊")
                {
                    form = new Consulation();
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
