using System.Runtime.InteropServices;

namespace Utilities.BlueToothTools.InTheHand.Net.Bluetooth
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BLUETOOTH_AUTHENTICATE_RESPONSE__PIN_INFO
    {
        internal long bthAddressRemote;
        internal BluetoothAuthenticationMethod authMethod;
        internal BLUETOOTH_PIN_INFO pinInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=12)]
        private byte[] _padding;
        internal byte negativeResponse;
    }
}

