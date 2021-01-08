using System;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup.Gravida
{
    public class GravidaForm : MDIParentForm
    {
        public WomenGravidaBaseInfoModel GravidaInfo;
        
        public GravidaForm(string idcard) : base(idcard)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
    }
}

