using System.Runtime.InteropServices;

namespace Utilities.BlueToothTools.InTheHand.Net.Bluetooth
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BLUETOOTH_AUTHENTICATE_RESPONSE__OOB_DATA_INFO
    {
        internal long bthAddressRemote;
        internal BluetoothAuthenticationMethod authMethod;
        internal BLUETOOTH_OOB_DATA_INFO oobInfo;
        internal byte negativeResponse;
    }
}

