namespace NetFwTypeLib
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, TypeIdentifier, CompilerGenerated, Guid("F7898AF5-CAC4-4632-A2EC-DA06E5111AF2")]
    public interface INetFwMgr
    {
        INetFwPolicy LocalPolicy { [DispId(1)] get; }
    }
}

