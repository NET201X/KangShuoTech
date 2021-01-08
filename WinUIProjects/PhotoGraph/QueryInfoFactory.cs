using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.Utilities.CommonUI;
using Properties;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoGraph
{
    public class QueryInfoFactory : ChildFormFactory
    {
        public QueryInfoFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("清单查询", new Image[] { Resources.btnqingdanchaxun01, Resources.btnqingdanchaxun01, Resources.btnqingdanchaxun01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
                if (str == "清单查询")
                {
                    form = new PhotoListForm();
                    //(form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
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
                return "清单查询";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
