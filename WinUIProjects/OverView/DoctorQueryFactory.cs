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
    public class DoctorQueryFactory : ChildFormFactory
    {
        public DoctorQueryFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("医生查询", new Image[] { Resources.btnyishichaxun01, Resources.btnyishichaxun01, Resources.btnyishichaxun01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;

            if (str != null)
            {
                if (str == "医生查询")
                {
                    form = new frmDoctorQuery();
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
                return "医生查询";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
