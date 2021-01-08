
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using KangShuoTech.Utilities.Common;
using Utilities.BlueToothTools.InTheHand.Net.Bluetooth;

namespace Utilities.BlueToothTools.MsBluetooth
{
    public static class NativeMethods
    {
        public const int BLUETOOTH_MAX_NAME_SIZE = 0xf8;

        [DllImport("Bthprops.cpl", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern int BluetoothAuthenticateDevice(IntPtr hwndParent, IntPtr hRadio, ref BluetoothDeviceInfo pbtdi, byte[] pszPasskey, ulong ulPassKeyLength);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern bool BluetoothDisplayDeviceProperties(IntPtr hwndParent, ref BluetoothDeviceInfo pbtdi);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern bool BluetoothEnableDiscovery(IntPtr hRadio, bool fEnabled);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern bool BluetoothEnableIncomingConnections(IntPtr hRadio, bool fEnabled);
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern int BluetoothEnumerateInstalledServices(IntPtr hRadio, ref BluetoothDeviceInfo pbtdi, ref int pcServices, byte[] pGuidServices);
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern bool BluetoothFindDeviceClose(IntPtr hFind);
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern IntPtr BluetoothFindFirstDevice(ref BluetoothDeviceSearchParams pbtsp, ref BLUETOOTH_DEVICE_INFO pbtdi);
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern IntPtr BluetoothFindFirstRadio(ref BluetoothFindRadioParams pbtfrp, out IntPtr phRadio);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern bool BluetoothFindNextDevice(IntPtr hFind, ref BLUETOOTH_DEVICE_INFO pbtdi);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern bool BluetoothFindNextRadio(IntPtr hFind, ref IntPtr phRadio);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern bool BluetoothFindRadioClose(IntPtr hFind);
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern int BluetoothGetDeviceInfo(IntPtr hRadio, ref BluetoothDeviceInfo pbtdi);
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern int BluetoothGetRadioInfo(IntPtr hRadio, ref BluetoothRadioInfo pRadioInfo);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern bool BluetoothIsConnectable(IntPtr hRadio);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern bool BluetoothIsDiscoverable(IntPtr hRadio);
        [DllImport("Bthprops.cpl", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern uint BluetoothRegisterForAuthentication(ref BLUETOOTH_DEVICE_INFO pbtdi, out BluetoothAuthenticationRegistrationHandle phRegHandle, BluetoothAuthenticationCallback pfnCallback, IntPtr pvParam);
        [DllImport("Bthprops.cpl", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern uint BluetoothRegisterForAuthenticationEx(ref BLUETOOTH_DEVICE_INFO pbtdi, out BluetoothAuthenticationRegistrationHandle phRegHandle, BluetoothAuthenticationCallbackEx pfnCallback, IntPtr pvParam);
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern int BluetoothRemoveDevice(byte[] pAddress);
        [DllImport("Bthprops.cpl", CharSet=CharSet.Unicode)]
        public static extern int BluetoothSendAuthenticationResponse(IntPtr hRadio, ref BLUETOOTH_DEVICE_INFO pbtdi, string pszPasskey);
        [DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern int BluetoothSetServiceState(IntPtr hRadio, ref BluetoothDeviceInfo pbtdi, ref Guid pGuidService, int dwServiceFlags);
        [return: MarshalAs(UnmanagedType.Bool)]
        [SuppressUnmanagedCodeSecurity, DllImport("Bthprops.cpl", SetLastError=true)]
        public static extern bool BluetoothUnregisterAuthentication(IntPtr hRegHandle);
        [return: MarshalAs(UnmanagedType.Bool)]
        [SuppressUnmanagedCodeSecurity, DllImport("Bthprops.cpl", SetLastError=true)]
        internal static extern bool BluetoothUnregisterAuthenticationEx(IntPtr hRegHandle);
        [DllImport("Bthprops.cpl", CharSet=CharSet.Unicode)]
        public static extern int BluetoothUpdateDeviceRecord(ref BLUETOOTH_DEVICE_INFO pbtdi);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", SetLastError=true)]
        internal static extern bool CloseHandle(IntPtr handle);
        public static IEnumerable<BLUETOOTH_DEVICE_INFO> GetDeviceInfos(BluetoothDeviceSearchParams searchParams)
        {
            BLUETOOTH_DEVICE_INFO bluetooth_device_info = new BLUETOOTH_DEVICE_INFO();
            IList<BLUETOOTH_DEVICE_INFO> list = new List<BLUETOOTH_DEVICE_INFO>();
            bluetooth_device_info = new BLUETOOTH_DEVICE_INFO {
                dwSize = Marshal.SizeOf(bluetooth_device_info)
            };
            IntPtr hFind = BluetoothFindFirstDevice(ref searchParams, ref bluetooth_device_info);
            HandleError();
            if (hFind != IntPtr.Zero)
            {
                do
                {
                    list.Add(bluetooth_device_info);
                    bluetooth_device_info = new BLUETOOTH_DEVICE_INFO();
                }
                while (BluetoothFindNextDevice(hFind, ref bluetooth_device_info));
                BluetoothFindDeviceClose(hFind);
            }
            return list;
        }

        public static IEnumerable<BLUETOOTH_DEVICE_INFO> GetDeviceInfos(bool returnAuthenticated, bool returnConnected, bool returnRemembered, bool returnUnknown, bool issueInquiry, byte timeoutMultiplier)
        {
            BluetoothDeviceSearchParams @params = new BluetoothDeviceSearchParams();
            @params = new BluetoothDeviceSearchParams {
                returnAuthenticated = returnAuthenticated,
                returnConnected = returnConnected,
                returnRemembered = returnRemembered,
                returnUnknown = returnUnknown,
                issueInquiry = issueInquiry,
                timeoutMultiplier = timeoutMultiplier,
                size = (uint) Marshal.SizeOf(@params)
            };
            return GetDeviceInfos(@params);
        }

        public static IEnumerable<IntPtr> GetRadioHandles(BluetoothFindRadioParams searchParams)
        {
            IList<IntPtr> list = new List<IntPtr>();
            IntPtr zero = IntPtr.Zero;
            IntPtr hFind = BluetoothFindFirstRadio(ref searchParams, out zero);
            if (hFind != IntPtr.Zero)
            {
                do
                {
                    list.Add(zero);
                    zero = IntPtr.Zero;
                }
                while (BluetoothFindNextRadio(hFind, ref zero));
                BluetoothFindRadioClose(hFind);
            }
            return list;
        }

        public static int GetRadioHandlesCount()
        {
            BluetoothFindRadioParams @params;
            IntPtr zero = IntPtr.Zero;
            List<WindowsRadioHandle> list = new List<WindowsRadioHandle>();
            @params.size = 4;

            try
            {
                IntPtr hFind = BluetoothFindFirstRadio(ref @params, out zero);
                if (hFind != IntPtr.Zero)
                {
                    WindowsRadioHandle item = new WindowsRadioHandle(zero);
                    list.Add(item);
                    while (BluetoothFindNextRadio(hFind, ref zero))
                    {
                        WindowsRadioHandle handle2 = new WindowsRadioHandle(zero);
                        list.Add(handle2);
                    }
                    BluetoothFindRadioClose(hFind);
                }
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
            }
            return list.Count;
        }

        public static BluetoothRadioInfo GetRadioInfo(IntPtr radioHandle)
        {
            BluetoothRadioInfo pRadioInfo = new BluetoothRadioInfo();
            HandleResult(BluetoothGetRadioInfo(radioHandle, ref pRadioInfo));
            return pRadioInfo;
        }

        public static IEnumerable<BluetoothRadioInfo> GetRadioInfos(BluetoothFindRadioParams searchParams)
        {
            IList<BluetoothRadioInfo> list = new List<BluetoothRadioInfo>();
            foreach (IntPtr ptr in GetRadioHandles(searchParams))
            {
                list.Add(GetRadioInfo(ptr));
            }
            return list;
        }

        public static IEnumerable<Guid> GetServiceGuids(BluetoothDeviceInfo deviceInfo)
        {
            int pcServices = 0x10;
            byte[] pGuidServices = new byte[pcServices * 0x20];
            HandleResult(BluetoothEnumerateInstalledServices(IntPtr.Zero, ref deviceInfo, ref pcServices, pGuidServices));
            Guid[] guidArray = new Guid[pcServices];
            for (int i = 0; i < pcServices; i++)
            {
                byte[] destinationArray = new byte[0x10];
                Array.Copy(pGuidServices, i * 0x10, destinationArray, 0, 0x10);
                guidArray[i] = new Guid(destinationArray);
            }
            return (IEnumerable<Guid>) guidArray;
        }

        public static void HandleError()
        {
            int result = Marshal.GetLastWin32Error();
            if (result != 0 && result != 259 && result != 1008)
            {
                throw new Win32Exception(result);
            }
        }

        public static void HandleError(int result)
        {
            if (Enum.IsDefined(typeof(BluetoothError), result))
            {
                BluetoothError error = (BluetoothError) result;
                if (error != BluetoothError.BTH_ERROR_SUCCESS)
                {
                    throw new Win32Exception(error.ToString());
                }
            }
            if (result == 0)
            {
                result = Marshal.GetLastWin32Error();
            }
            if (((result != 0) && (result != 0x3f0)) && (result != 0x490))
            {
                throw new Win32Exception(result);
            }
        }

        public static void HandleResult(int result)
        {
            if (!Enum.IsDefined(typeof(BluetoothError), result))
            {
                throw new Win32Exception(result);
            }
            BluetoothError error = (BluetoothError) result;
            if (error != BluetoothError.BTH_ERROR_SUCCESS)
            {
                throw new Win32Exception(result, error.ToString());
            }
        }

        public static void RemoveDevice(BluetoothAddress address)
        {
            HandleError(BluetoothRemoveDevice(address.address));
        }

        [StructLayout(LayoutKind.Sequential)]
        public class BluetoothAddress
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
            public byte[] address;
            public BluetoothAddress()
            {
                this.address = new byte[8];
            }

            public BluetoothAddress(long addressL) : this()
            {
                BitConverter.GetBytes(addressL).CopyTo(this.address, (long) 0L);
            }

            public static bool operator ==(NativeMethods.BluetoothAddress bluetoothAddressA, NativeMethods.BluetoothAddress bluetoothAddressB)
            {
                return bluetoothAddressA.Equals(bluetoothAddressB);
            }

            public static bool operator !=(NativeMethods.BluetoothAddress bluetoothAddressA, NativeMethods.BluetoothAddress bluetoothAddressB)
            {
                return !bluetoothAddressA.Equals(bluetoothAddressB);
            }

            public override string ToString()
            {
                return string.Format("{0}:{1}:{2}:{3}:{4}:{5}", new object[] { this.address[5].ToString("x2"), this.address[4].ToString("x2"), this.address[3].ToString("x2"), this.address[2].ToString("x2"), this.address[1].ToString("x2"), this.address[0].ToString("x2") });
            }

            public override int GetHashCode()
            {
                int num = 0;
                for (int i = 0; i < this.address.Length; i++)
                {
                    num = (num << 2) ^ this.address[i];
                }
                return num;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is NativeMethods.BluetoothAddress))
                {
                    return false;
                }
                NativeMethods.BluetoothAddress address = (NativeMethods.BluetoothAddress) obj;
                if (this.address.Length != address.address.Length)
                {
                    return false;
                }
                for (int i = 0; i < this.address.Length; i++)
                {
                    if (this.address[i] != address.address[i])
                    {
                        return false;
                    }
                }
                return true;
            }

            public long ToInt64()
            {
                return BitConverter.ToInt64(this.address, 0);
            }
        }

        public delegate bool BluetoothAuthenticationCallback(IntPtr pvParam, ref BLUETOOTH_DEVICE_INFO bdi);

        public delegate bool BluetoothAuthenticationCallbackEx(IntPtr pvParam, ref BLUETOOTH_AUTHENTICATION_CALLBACK_PARAMS pAuthCallbackParams);

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto, Pack=1)]
        public struct BluetoothDeviceInfo
        {
            public uint size;
            public uint dummya;
            public NativeMethods.BluetoothAddress address;
            public ushort dummyb;
            public uint classofDevice;
            public bool connected;
            public bool remembered;
            public bool authenticated;
            public NativeMethods.SystemTime lastSeen;
            public NativeMethods.SystemTime lastUsed;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0xf8)]
            public string name;
            public void Initialize()
            {
                this.name = new string('*', 0xf8);
                this.lastSeen = new NativeMethods.SystemTime();
                this.lastUsed = new NativeMethods.SystemTime();
                this.size = (uint) Marshal.SizeOf(this);
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack=4)]
        public struct BluetoothDeviceSearchParams
        {
            public uint size;
            public bool returnAuthenticated;
            public bool returnRemembered;
            public bool returnUnknown;
            public bool returnConnected;
            public bool issueInquiry;
            public byte timeoutMultiplier;
            public IntPtr hRadio;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BluetoothFindRadioParams
        {
            public uint size;
            public void Initialize()
            {
                this.size = (uint) Marshal.SizeOf(this);
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto, Pack=1)]
        public struct BluetoothRadioInfo
        {
            public uint size;
            public NativeMethods.BluetoothAddress address;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0xf8)]
            public string name;
            public uint classofDevice;
            public ushort subversion;
            public ushort manufacturer;
            public void Initialize()
            {
                this.name = new string('*', 0xf8);
                this.address = new NativeMethods.BluetoothAddress();
                this.size = (uint) Marshal.SizeOf(this);
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct SystemTime
        {
            public ushort year;
            public ushort month;
            public ushort dayOfWeek;
            public ushort day;
            public ushort hour;
            public ushort minute;
            public ushort second;
            public ushort milliseconds;
            public DateTime ToDateTime(DateTimeKind kind)
            {
                if ((((this.year == 0) && (this.month == 0)) && ((this.day == 0) && (this.hour == 0))) && ((this.minute == 0) && (this.second == 0)))
                {
                    return DateTime.MinValue;
                }
                return new DateTime(this.year, this.month, this.day, this.hour, this.minute, this.second, this.milliseconds, kind);
            }
        }
    }
}

