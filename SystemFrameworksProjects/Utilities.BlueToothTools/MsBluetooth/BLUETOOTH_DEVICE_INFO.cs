
using System.Runtime.InteropServices;
using System;

namespace Utilities.BlueToothTools.MsBluetooth
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BLUETOOTH_DEVICE_INFO
    {
        internal int dwSize;
        public long Address;
        internal uint ulClassofDevice;
        [MarshalAs(UnmanagedType.Bool)]
        internal bool fConnected;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fRemembered;
        [MarshalAs(UnmanagedType.Bool)]
        internal bool fAuthenticated;
        internal NativeMethods.SystemTime stLastSeen;
        internal NativeMethods.SystemTime stLastUsed;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0xf8)]
        public string szName;
        public DateTime LastSeen
        {
            get
            {
                return this.stLastSeen.ToDateTime(DateTimeKind.Utc);
            }
        }
        internal DateTime LastUsed
        {
            get
            {
                return this.stLastUsed.ToDateTime(DateTimeKind.Utc);
            }
        }

        public BLUETOOTH_DEVICE_INFO(long address)
        {
            this.dwSize = 560;
            this.Address = address;
            this.ulClassofDevice = 0;
            this.fConnected = false;
            this.fRemembered = false;
            this.fAuthenticated = false;
            this.stLastSeen = new NativeMethods.SystemTime();
            this.stLastUsed = new NativeMethods.SystemTime();
            this.szName = "";
        }

        public BLUETOOTH_DEVICE_INFO(NativeMethods.BluetoothAddress address)
        {
            if (address == null)
            {
                throw new ArgumentNullException("address");
            }
            this.dwSize = 560;
            this.Address = address.ToInt64();
            this.ulClassofDevice = 0;
            this.fConnected = false;
            this.fRemembered = false;
            this.fAuthenticated = false;
            this.stLastSeen = new NativeMethods.SystemTime();
            this.stLastUsed = new NativeMethods.SystemTime();
            this.szName = "";
        }
    }
}
