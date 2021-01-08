namespace NetFwTypeLib
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("B5E64FFA-C2C5-444E-A301-FB5E00018050"), TypeIdentifier, CompilerGenerated]
    public interface INetFwAuthorizedApplication
    {
        string Name { [DispId(1)] get; [DispId(1)] set; }
        string ProcessImageFileName { [DispId(2)] get; [DispId(2)] set; }
        NET_FW_IP_VERSION_ IpVersion { [DispId(3)] get; [DispId(3)] set; }
        NET_FW_SCOPE_ Scope { [DispId(4)] get; [DispId(4)] set; }
        bool Enabled { [DispId(6)] get; [DispId(6)] set; }
        void _VtblGap1_2();
    }
}

