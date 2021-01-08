﻿namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    internal struct DriverStatus
    {
        public byte bDriverError;
        public byte bIDEStatus;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
        public byte[] bReserved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
        public uint[] dwReserved;
    }
}

