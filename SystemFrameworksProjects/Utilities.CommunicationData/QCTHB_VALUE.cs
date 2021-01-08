namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct QCTHB_VALUE
    {
        public string HB;
        public string HTC;
    }
}

