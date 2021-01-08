namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct QCTBS_VALUE
    {
        public QCTBS_BYTES[] DataValue;
    }
}

