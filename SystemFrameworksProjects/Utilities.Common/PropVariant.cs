namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit, Size=0x10)]
    public struct PropVariant
    {
        [FieldOffset(8)]
        public byte byteValue;
        [FieldOffset(8)]
        public long longValue;
        [FieldOffset(8)]
        public IntPtr pointerValue;
        [FieldOffset(0)]
        public short variantType;

        public void FromObject(object obj)
        {
            if (obj.GetType() == typeof(string))
            {
                this.variantType = 0x1f;
                this.pointerValue = Marshal.StringToHGlobalUni((string) obj);
            }
        }
    }
}

