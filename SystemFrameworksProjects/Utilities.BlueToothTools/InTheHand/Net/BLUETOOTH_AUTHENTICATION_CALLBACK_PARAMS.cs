using Utilities.BlueToothTools.MsBluetooth;
using System.Runtime.InteropServices;

namespace Utilities.BlueToothTools.InTheHand.Net.Bluetooth
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BLUETOOTH_AUTHENTICATION_CALLBACK_PARAMS
    {
        public BLUETOOTH_DEVICE_INFO deviceInfo;
        public BluetoothAuthenticationMethod authenticationMethod;
        public BluetoothIoCapability ioCapability;
        public BluetoothAuthenticationRequirements authenticationRequirements;
        public uint Numeric_Value_Passkey;

        private void ShutupCompiler()
        {
            this.deviceInfo = new BLUETOOTH_DEVICE_INFO();
            this.authenticationMethod = BluetoothAuthenticationMethod.Legacy;
            this.ioCapability = BluetoothIoCapability.Undefined;
            this.authenticationRequirements = BluetoothAuthenticationRequirements.MITMProtectionNotDefined;
            this.Numeric_Value_Passkey = 0;
        }
    }
}

