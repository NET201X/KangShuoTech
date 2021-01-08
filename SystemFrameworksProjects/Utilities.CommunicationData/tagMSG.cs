namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct tagMSG
    {
        public int hwnd;
        public uint message;
        public int wParam;
        public long lParam;
        public uint time;
        public int pt;
    }
}

