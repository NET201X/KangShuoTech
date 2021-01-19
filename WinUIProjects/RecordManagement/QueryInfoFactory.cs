using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.Utilities.CommonUI;
using ArchiveInfo.Properties;
using System.Drawing;
using KangShuoTech.DataAccessProjects.Model;
using System.Windows.Forms;

namespace ArchiveInfo
{
    internal class QueryInfoFactory : ChildFormFactory
    {
        public QueryInfoFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("个人档案", new Image[] { Resources.btngerenxinxi00, Resources.btngerenxinxi01, Resources.btngerenxinxi01 }));
            this.ItemParamters.Add(new ItemParamters("家庭信息", new Image[] { Resources.btnjiatingxinxi00, Resources.btnjiatingxinxi01, Resources.btnjiatingxinxi01 }));
            this.ItemParamters.Add(new ItemParamters("体检信息", new Image[] { Resources.btntijianxinxi00, Resources.btntijianxinxi01, Resources.btntijianxinxi01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
                if (str == "个人档案")
                {
                    form = new RecordQueryForm();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "家庭信息")
                {
                    form = new FamilyListQueryForm();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "体检信息")
                {
                    form = new PhysicalQueryForm();
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
                return "个人档案";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
