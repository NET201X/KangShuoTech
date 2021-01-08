namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct QCTBH_VALUE
    {
        public string ShenGao;
        public string TiZhong;
        public string ZhiShu;
    }
}

