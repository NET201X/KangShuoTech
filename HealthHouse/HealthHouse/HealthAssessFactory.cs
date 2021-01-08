using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthHouse.Properties;
using KangShuoTech.Utilities.CommonUI;
using System.Drawing;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.Model;

namespace HealthHouse
{
    internal class HealthAssessFactory : ChildFormFactory
    {
        public HealthAssessFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("健康问询", new Image[] { Resources.健康问询, Resources.健康问询, Resources.健康问询 }));
            this.ItemParamters.Add(new ItemParamters("健康评估", new Image[] { Resources.Assess, Resources.Assess, Resources.Assess }));
            
        }
        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            if (name == "健康评估")
            {
                form = new HealthAssessForm();
                (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
            }
            else if (name == "健康问询")
            {
                form = new HealthAssessExamenForm();
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
                return "健康评估";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
