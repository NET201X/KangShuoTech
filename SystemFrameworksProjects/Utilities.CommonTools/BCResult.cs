namespace KangShuoTech.Utilities.CommonTools
{
    using System;
    using System.Runtime.CompilerServices;
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
        public decimal d_internation { get; set; }
        public decimal d_traditon { get; set; }
    }
}

