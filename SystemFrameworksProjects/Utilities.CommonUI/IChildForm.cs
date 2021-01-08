namespace KangShuoTech.Utilities.CommonUI
{
    using System;

    public interface IChildForm
    {
        ChildFormStatus CheckErrorInput();
        void InitEveryThing();
        void NotisfyChildStatus();
        bool SaveModelToDB();
        void UpdataToModel();

        bool EveryThingIsOk { get; set; }

        bool HaveToSave { get; set; }

        string SaveDataInfo { get; set; }
    }
}

