namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.Runtime.InteropServices;

    [ComImport, Guid("0000013A-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
    public interface IPropertySetStorage
    {
        uint Create([In, MarshalAs(UnmanagedType.Struct)] ref Guid rfmtid, [In] IntPtr pclsid, [In] int grfFlags, [In] int grfMode, ref IPropertyStorage propertyStorage);
        int Open([In, MarshalAs(UnmanagedType.Struct)] ref Guid rfmtid, [In] int grfMode, [Out] IPropertyStorage propertyStorage);
    }
}

