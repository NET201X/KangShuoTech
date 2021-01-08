using PrintPlatform.Properties;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrintPlatform
{
    public class TypeBPrintFactory : ChildFormFactory
    {
        public TypeBPrintFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("B超打印", new Image[] { Resources.btnbcao01, Resources.btnbcao01, Resources.btnbcao01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;

            if (str != null)
            {

                if (str == "B超打印")
                {
                    form = new frmTypeBPrint();

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
                return "B超打印";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
