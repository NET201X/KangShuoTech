namespace KangShuoTech.Utilities.CommonUI
{
    using System;
    using System.Collections.Generic;

    public interface IMDIControler
    {
        void Call_Child(object sender, EventArgs e);
        IChildForm CreateChild(string ch);
        bool DoSave();

        Action Close { get; set; }

        ChildFormFactory Factory { get; set; }

        Dictionary<string, IChildForm> IChildrens { get; set; }

        IParentForm IParentFrm { get; set; }

        string SaveDataInfo { get; set; }
    }
}

