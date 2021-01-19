using Utilities.BlueToothTools.InTheHand.Net.Bluetooth;
using Utilities.BlueToothTools.MsBluetooth;

namespace KangShuo
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.InteropServices;

    internal class BluetoothWin32Authentication : IDisposable
    {
        private Action<string, bool> m_auth_resultCallback;
        private NativeMethods.BluetoothAuthenticationCallback m_callback;
        private NativeMethods.BluetoothAuthenticationCallbackEx m_callbackEx;
        private bool m_hasKB942567 = true;
        private readonly string m_pin;
        private readonly IntPtr m_radioHandle = IntPtr.Zero;
        private BluetoothAuthenticationRegistrationHandle m_regHandle;
        private readonly NativeMethods.BluetoothAddress m_remoteAddress;
        private Action<string, string> m_userCallback;
        public const int NativeErrorDeviceNotConnected = 0x48f;
        public const int NativeErrorNotAuthenticated = 0x4dc;
        public const int NativeErrorSuccess = 0;

        public BluetoothWin32Authentication(Action<string, string> callback, Action<string, bool> auth_result)
        {
            this.m_userCallback = callback;
            this.m_auth_resultCallback = auth_result;
            this.Register(new NativeMethods.BluetoothAddress(0L));
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && (this.m_regHandle != null))
            {
                this.m_regHandle.Dispose();
            }
        }

        private bool NativeCallback(IntPtr param, ref BLUETOOTH_DEVICE_INFO bdi)
        {
            BLUETOOTH_AUTHENTICATION_CALLBACK_PARAMS? pAuthCallbackParams = null;
            return this.NativeCallback(BluetoothAuthenticationMethod.Legacy, param, ref bdi, false, ref pAuthCallbackParams);
        }

        private bool NativeCallback(IntPtr param, ref BLUETOOTH_AUTHENTICATION_CALLBACK_PARAMS pAuthCallbackParams)
        {
            BLUETOOTH_DEVICE_INFO deviceInfo = pAuthCallbackParams.deviceInfo;
            BLUETOOTH_AUTHENTICATION_CALLBACK_PARAMS? nullable = new BLUETOOTH_AUTHENTICATION_CALLBACK_PARAMS?(pAuthCallbackParams);
            this.NativeCallback(pAuthCallbackParams.authenticationMethod, param, ref deviceInfo, true, ref nullable);
            return false;
        }

        private bool NativeCallback(BluetoothAuthenticationMethod method, IntPtr param, ref BLUETOOTH_DEVICE_INFO bdi, bool versionEx, ref BLUETOOTH_AUTHENTICATION_CALLBACK_PARAMS? pAuthCallbackParams)
        {
            int num;
            int num2;
            bool flag = false;
            do
            {
                this.m_userCallback(bdi.szName, bdi.Address.ToString());
                num = NativeMethods.BluetoothSendAuthenticationResponse(this.m_radioHandle, ref bdi, "0000");
                num2 = num;
            }
            while (((num2 != 0) && (num2 != 0x48f)) && ((num2 != 0x4dc) && flag));
            if (num != 0)
            {
                Trace.WriteLine(string.Format(CultureInfo.InvariantCulture, "BluetoothSendAuthenticationResponse failed: {0}=0x{0:X}", new object[] { num }));
            }
            return true;
        }

        private void Register(NativeMethods.BluetoothAddress remoteAddress)
        {
            uint num;
            this.m_callback = new NativeMethods.BluetoothAuthenticationCallback(this.NativeCallback);
            this.m_callbackEx = new NativeMethods.BluetoothAuthenticationCallbackEx(this.NativeCallback);
            BLUETOOTH_DEVICE_INFO pbtdi = new BLUETOOTH_DEVICE_INFO(remoteAddress);
            if (this.m_hasKB942567)
            {
                try
                {
                    num = NativeMethods.BluetoothRegisterForAuthenticationEx(ref pbtdi, out this.m_regHandle, this.m_callbackEx, IntPtr.Zero);
                }
                catch (EntryPointNotFoundException)
                {
                    this.m_hasKB942567 = false;
                    num = NativeMethods.BluetoothRegisterForAuthentication(ref pbtdi, out this.m_regHandle, this.m_callback, IntPtr.Zero);
                }
            }
            else
            {
                num = NativeMethods.BluetoothRegisterForAuthentication(ref pbtdi, out this.m_regHandle, this.m_callback, IntPtr.Zero);
            }
            int error = Marshal.GetLastWin32Error();
            if (num != 0)
            {
                throw new Win32Exception(error);
            }
            this.m_regHandle.SetObjectToKeepAlive(this.m_callback, this.m_callbackEx);
        }
    }
}

