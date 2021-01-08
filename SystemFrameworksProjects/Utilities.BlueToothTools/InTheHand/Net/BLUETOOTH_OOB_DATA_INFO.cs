using System.Runtime.InteropServices;

namespace Utilities.BlueToothTools.InTheHand.Net.Bluetooth
{
    [StructLayout(LayoutKind.Sequential, Size=0x20)]
    public struct BLUETOOTH_OOB_DATA_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x10)]
        internal byte[] C;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x10)]
        internal byte[] R;
        private void ShutupCompiler()
        {
            this.C = (byte[]) (this.R = null);
        }
    }
}

