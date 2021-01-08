using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.Utilities.CommonUI;
using HealthHouse.Properties;
using System.Drawing;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.Model;

namespace HealthHouse
{
    internal class HealthGuideFactory : ChildFormFactory
    {
        public HealthGuideFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("健康指导", new Image[] { Resources.Assess, Resources.Assess, Resources.Assess }));
        }
        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            if (name == "健康指导")
            {
                form = new HealthGuideForm();
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

        public static string IDCardNo { get; set; }
        public static int ID { get; set; }
        public static int PID { get; set; }

        /// <summary>
        /// 指导信息查看 状态
        /// </summary>
        public static string ViewState { get; set; }

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
