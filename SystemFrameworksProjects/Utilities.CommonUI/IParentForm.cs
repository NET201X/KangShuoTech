namespace KangShuoTech.Utilities.CommonUI
{
    using System;
    using System.Collections.Generic;

    public interface IParentForm
    {
        void ChildStatus(string child, ChildFormStatus status);
        void IShowDialog();
        void SetChildrenButton(List<ItemParamters> items);
        void SetFrmText(string text);
        void ShowChild(IChildForm child);

        Action FrmClose { get; set; }

        CommonUI.IMDIControler IMDIControler { get; set; }
    }
}

