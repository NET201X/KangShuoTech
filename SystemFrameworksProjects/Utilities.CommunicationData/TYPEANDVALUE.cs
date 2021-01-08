namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct TYPEANDVALUE
    {
        public string ChildType;
        public string Value;
    }
}

