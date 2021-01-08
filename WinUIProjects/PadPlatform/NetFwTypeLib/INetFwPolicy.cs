namespace NetFwTypeLib
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, CompilerGenerated, Guid("D46D2478-9AC9-4008-9DC7-5563CE5536CC"), TypeIdentifier]
    public interface INetFwPolicy
    {
        INetFwProfile CurrentProfile { [DispId(1)] get; }
    }
}

