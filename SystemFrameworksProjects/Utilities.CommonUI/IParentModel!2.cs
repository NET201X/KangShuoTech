namespace KangShuoTech.Utilities.CommonUI
{
    using System;

    public interface IParentModel<T, TA>
    {
        bool SaveModel();

        TA Another { get; set; }

        T Model { get; set; }
    }
}

