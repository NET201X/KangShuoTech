using System.Runtime.InteropServices;

namespace Utilities.BlueToothTools.InTheHand.Net.Bluetooth
{
    [StructLayout(LayoutKind.Sequential, Size=20)]
    internal struct BLUETOOTH_PIN_INFO
    {
        internal const int BTH_MAX_PIN_SIZE = 0x10;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x10)]
        internal byte[] pin;
        internal int pinLength;
    }
}

