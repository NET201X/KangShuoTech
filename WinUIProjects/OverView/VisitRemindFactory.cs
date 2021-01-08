using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OverView.Properties;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;
using FocusGroup.ChronicDisease;
using FocusGroup;

namespace OverView
{
    public class VisitRemindFactory : ChildFormFactory
    {
        public VisitRemindFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("10天内应访视", new Image[] { Resources.btnyingfangshi00, Resources.btnyingfangshi01, Resources.btnyingfangshi01 }));
            this.ItemParamters.Add(new ItemParamters("过期10天内访视", new Image[] { Resources.btnguoqifangshi00, Resources.btnguoqifangshi01, Resources.btnguoqifangshi01 }));
            this.ItemParamters.Add(new ItemParamters("从未访视", new Image[] { Resources.btncongweifangshi00, Resources.btncongweifangshi01, Resources.btncongweifangshi01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            PTBFactory.PtbID = 0;

            if (str != null)
            {
                if (str == "10天内应访视")
                {
                    form = new frmTwentyVisit();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "过期10天内访视")
                {
                    form = new frmTenVisit();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "从未访视")
                {
                    form = new frmNeverVisit();
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
                return "访视提醒";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
