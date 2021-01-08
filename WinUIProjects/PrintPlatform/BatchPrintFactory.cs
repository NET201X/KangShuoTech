using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PrintPlatform.Properties;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.Utilities.Common;

namespace PrintPlatform
{
    public class BatchPrintFactory : ChildFormFactory
    {
        string area = ConfigHelper.GetSetNode("area");

        public BatchPrintFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("批量打印", new Image[] { Resources.btnpiliang00, Resources.btnpiliang01, Resources.btnpiliang01 }));
            this.ItemParamters.Add(new ItemParamters("批量汇出", new Image[] { Resources.btnhuichu00, Resources.btnhuichu01, Resources.btnhuichu01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;

            if (str != null)
            {
                if (str == "批量打印")
                {
                    //if (area.Equals("威海")) form = new BatchPrintFormForWeiHai();
                    //else form = new BatchPrintForm();
                    form = new BatchPrintForm();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else
                {
                    form = new BatchExport();
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
                return "批量打印";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
