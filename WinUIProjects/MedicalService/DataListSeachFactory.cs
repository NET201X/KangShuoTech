using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace MedicalService
{
    using Properties;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Drawing;

    public class DataListSeachFactory : ChildFormFactory
    {
        public DataListSeachFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("接诊记录", new Image[] { Resources.btnjiezhen00, Resources.btnjiezhen01, Resources.btnjiezhen01 }));
            this.ItemParamters.Add(new ItemParamters("会诊记录", new Image[] { Resources.btnhuizhen00, Resources.btnhuizhen01, Resources.btnhuizhen01 }));
            this.ItemParamters.Add(new ItemParamters("转诊记录", new Image[] { Resources.btnzhuanzhen00, Resources.btnzhuanzhen01, Resources.btnzhuanzhen01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
                if (str == "接诊记录")
                {
                    form = new DataListSearch("接诊记录");
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "会诊记录")
                {
                    form = new DataListSearch("会诊记录");
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "转诊记录")
                {
                    form = new DataListSearch("转诊记录");
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
                return "医疗服务";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
