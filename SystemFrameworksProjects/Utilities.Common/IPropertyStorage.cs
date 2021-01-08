namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000138-0000-0000-C000-000000000046"), ComVisible(true)]
    public interface IPropertyStorage
    {
        int ReadMultiple(uint numProperties, PropSpec[] propertySpecifications, PropVariant[] propertyValues);
        int WriteMultiple(uint numProperties, [MarshalAs(UnmanagedType.Struct)] ref PropSpec propertySpecification, ref PropVariant propertyValues, int propIDNameFirst);
        uint Commit(int commitFlags);
    }
}

