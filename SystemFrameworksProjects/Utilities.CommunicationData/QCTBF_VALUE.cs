namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct QCTBF_VALUE
    {
        public string TiZhong;
        public string ZhiFang;
        public string GuLiang;
        public string JiRou;
        public string NeiZhi;
        public string ZuKang;
        public string BMI;
        public string ShuiFen;
        public string JiChuDaiXie;
    }
}

