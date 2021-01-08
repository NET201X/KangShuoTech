using System;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup
{
    public class HypForm : MDIParentForm
    {
        public HypForm(string IDCardNo) : base(IDCardNo)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public override bool SaveModel()
        {
            return true;
        }
    }
}

