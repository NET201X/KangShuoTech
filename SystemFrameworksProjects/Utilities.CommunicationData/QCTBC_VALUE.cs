namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct QCTBC_VALUE
    {
        public string HP_YouMen;
        public string Xiongwei;
        public string Yaowei;
        public string Tunwei;
        public string Height;
        public string AllData;
        public string DataType;
        public string ChildType;
        public string BarCode;
    }
}

