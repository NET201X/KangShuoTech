namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct QCTBP_VALUE
    {
        public string GaoYa;
        public string DiYa;
        public string XinLv;
    }
}

