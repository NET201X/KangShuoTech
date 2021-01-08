using FocusGroup.Properties;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup.ChronicDisease
{
   public class DiaFactory : ChildFormFactory
    {
        public DiaFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("基本信息", new Image[] { Resources.btnjiben00, Resources.btnjiben01, Resources.btnjiben01 }));
            this.ItemParamters.Add(new ItemParamters("随访信息", new Image[] { Resources.suifang00, Resources.suifang01, Resources.suifang01 }));
        }
        public DiaFactory(int type)
        {
            this.ItemParamters = new List<ItemParamters>();

            switch (type)
            {
                case 1:
                    this.ItemParamters.Add(new ItemParamters("基本信息", new Image[] { Resources.btnjiben00, Resources.btnjiben01, Resources.btnjiben01 }));
                    break;
                case 2:
                    this.ItemParamters.Add(new ItemParamters("随访信息", new Image[] { Resources.suifang00, Resources.suifang01, Resources.suifang01 }));
                    break;

            }
        }
        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
                if (!(str == "基本信息"))
                {
                    if (str == "随访信息")
                    {
                        form = new DiaVisitForm();
                        (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    }
                }
                else
                {
                    form = new DiaInfoForm();
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
                return "糖尿病管理";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}

