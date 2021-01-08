namespace NetFwTypeLib
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("174A0DDA-E9F9-449D-993B-21AB667CA456"), CompilerGenerated, TypeIdentifier]
    public interface INetFwProfile
    {
        INetFwAuthorizedApplications AuthorizedApplications { [DispId(10)] get; }
        void _VtblGap1_13();
    }
}

