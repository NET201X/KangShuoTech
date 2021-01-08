namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.Runtime.InteropServices;

    public class ole32
    {
        [DllImport("ole32.dll", CharSet=CharSet.Unicode)]
        public static extern uint StgCreateStorageEx([MarshalAs(UnmanagedType.LPWStr)] string name, int accessMode, int storageFileFormat, int fileBuffering, IntPtr options, IntPtr reserved, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] ref IPropertySetStorage propertySetStorage);
        [DllImport("ole32.dll", CharSet=CharSet.Unicode)]
        public static extern uint StgOpenStorageEx([MarshalAs(UnmanagedType.LPWStr)] string name, int accessMode, int storageFileFormat, int fileBuffering, IntPtr options, IntPtr reserved, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] ref IPropertySetStorage propertySetStorage);

        [StructLayout(LayoutKind.Explicit, CharSet=CharSet.Unicode, Size=12)]
        public struct STGOptions
        {
            [MarshalAs(UnmanagedType.LPWStr), FieldOffset(8)]
            private string pwcsTemplateFile;
            [FieldOffset(2)]
            private ushort reserved;
            [FieldOffset(4)]
            private uint uiSectorSize;
            [FieldOffset(0)]
            private ushort usVersion;
        }
    }
}

