using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OverView.Properties;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace OverView
{
    public class ListInfoFactory : ChildFormFactory
    {
        public ListInfoFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("工作统计", new Image[] { Resources.btnliebiaotongji00, Resources.btnliebiaotongji01, Resources.btnliebiaotongji01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
                if (str == "工作统计")
                {
                    form = new FrmStatistics();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
            }

            (form as Form).Text = name;
            form.HaveToSave = false;
            return form;
        }

        public override List<ItemParamters> ItemParamters
        {
            get;
            set;
        }

        public override IMDIControler MControler
        {
            get;
            set;
        }

        public override string MDIFrmText
        {
            get
            {
                return "列表统计";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
