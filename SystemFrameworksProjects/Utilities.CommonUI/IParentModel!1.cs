namespace KangShuoTech.Utilities.CommonUI
{
    using System;

    public interface IParentModel<T>
    {
        bool SaveModel();

        T Model { get; set; }
    }
}

