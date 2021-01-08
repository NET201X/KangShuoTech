using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace OverView
{
    using Properties;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Drawing;


    public class OverViewFactory : ChildFormFactory
    {
        public OverViewFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("档案完整率", new Image[] { Resources.btnwanzhenglv00, Resources.btnwanzhenglv01, Resources.btnwanzhenglv01 }));
            this.ItemParamters.Add(new ItemParamters("随访率", new Image[] { Resources.btnsuifanglv00, Resources.btnsuifanglv01, Resources.btnsuifanglv01 }));
            this.ItemParamters.Add(new ItemParamters("建档数列表", new Image[] { Resources.btnjiandangshu00, Resources.btnjiandangshu01, Resources.btnjiandangshu01 }));

        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
                if (str == "档案完整率")
                {
                    form = new frmRecordComplete();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "随访率")
                {
                    form = new frmVisitPercent();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "建档数列表")
                {
                    form = new FrmStatistics();
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
                return "本地查询";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}

