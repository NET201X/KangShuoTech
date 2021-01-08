namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct BCResult
    {
        public string friendName;
        public string engshort;
        public string standard;
        public string internation;
        public string tradition;
        public int index;
    }
}

