using System.Runtime.InteropServices;

namespace Utilities.BlueToothTools.InTheHand.Net.Bluetooth
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BLUETOOTH_AUTHENTICATE_RESPONSE__NUMERIC_COMPARISON_PASSKEY_INFO
    {
        internal long bthAddressRemote;
        internal BluetoothAuthenticationMethod authMethod;
        internal uint numericComp_passkey;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x1c)]
        private byte[] _padding;
        internal byte negativeResponse;
    }
}

