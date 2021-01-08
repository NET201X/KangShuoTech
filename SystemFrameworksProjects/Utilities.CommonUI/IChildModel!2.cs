namespace KangShuoTech.Utilities.CommonUI
{
    using System;

    public interface IChildModel<T1, T2>
    {
        T1 T1Model { get; set; }

        T2 T2Model { get; set; }
    }
}

