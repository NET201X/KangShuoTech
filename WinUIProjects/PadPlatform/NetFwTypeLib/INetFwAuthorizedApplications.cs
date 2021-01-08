namespace NetFwTypeLib
{
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, TypeIdentifier, CompilerGenerated, Guid("644EFD52-CCF9-486C-97A2-39F352570B30")]
    public interface INetFwAuthorizedApplications : IEnumerable
    {
        void _VtblGap1_1();
        [DispId(2)]
        void Add([In, MarshalAs(UnmanagedType.Interface)] INetFwAuthorizedApplication app);
    }
}

