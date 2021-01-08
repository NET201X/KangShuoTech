using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.Utilities.CommonUI;
using System.Drawing;
using KangShuoTech.DataAccessProjects.Model;
using System.Windows.Forms;
using HealthHouse.Properties;

namespace HealthHouse
{
    internal class QueryInfoFactory : ChildFormFactory
    {
        public QueryInfoFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("体检信息", new Image[] { Resources.health, Resources.health, Resources.health }));
            this.ItemParamters.Add(new ItemParamters("健康评估", new Image[] { Resources.Assess, Resources.Assess, Resources.Assess }));
            this.ItemParamters.Add(new ItemParamters("健康指导", new Image[] { Resources.check, Resources.check, Resources.check }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
   
            if (name != null)
            {
                if (name == "体检信息")
                {
                    form = new PhysicalQueryForm();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (name == "健康评估")
                {
                    form = new ExamQueryForm();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (name == "健康指导")
                {
                    form = new GuideQueryForm();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
            }

            (form as Form).Text = name;
            form.HaveToSave = false;
            return form;
        }

        public override List<ItemParamters> ItemParamters { get; set; }

        public override IMDIControler MControler { get; set; }

        public override string MDIFrmText
        {
            get
            {
                return "体检信息";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
