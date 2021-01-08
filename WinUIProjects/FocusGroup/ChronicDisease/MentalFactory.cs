using FocusGroup.ChronicDisease;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup
{
    using FocusGroup.Properties;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Drawing;

   public  class MentalFactory : ChildFormFactory
    {
        public MentalFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("基本信息", new Image[] { Resources.btnjiben00, Resources.btnjiben01, Resources.btnjiben01 }));
            this.ItemParamters.Add(new ItemParamters("随访记录", new Image[] { Resources.suifang00, Resources.suifang01, Resources.suifang01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
                if (!(str == "基本信息"))
                {
                    if (str == "随访记录")
                    {
                        form = new MentalVisitForm();
                        (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    }
                }
                else
                {
                    form = new MentalInfoForm();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
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
                return "重型精神疾病管理";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}

