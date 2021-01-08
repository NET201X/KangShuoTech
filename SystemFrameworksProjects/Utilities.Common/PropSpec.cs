namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit, CharSet=CharSet.Unicode, Size=8)]
    public struct PropSpec
    {
        [FieldOffset(4)]
        public IntPtr Name_Or_ID;
        [FieldOffset(0)]
        public int ulKind;
    }
}

