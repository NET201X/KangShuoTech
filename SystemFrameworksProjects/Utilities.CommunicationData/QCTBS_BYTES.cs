namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct QCTBS_BYTES
    {
        public string DataTime;
        public int Intv;
        public byte[] Values;
    }
}

