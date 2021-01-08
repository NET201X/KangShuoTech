using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Utilities.BlueToothTools.MsBluetooth
{
    public class BluetoothAuthenticationRegistrationHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private object m_objectToKeepAlive;
        private object m_objectToKeepAlive2;

        public BluetoothAuthenticationRegistrationHandle() : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            bool flag = NativeMethods.BluetoothUnregisterAuthentication(base.handle);
            Marshal.GetLastWin32Error();
            return flag;
        }

        public void SetObjectToKeepAlive(object objectToKeepAlive, object objectToKeepAlive2)
        {
            this.m_objectToKeepAlive = objectToKeepAlive;
            this.m_objectToKeepAlive2 = objectToKeepAlive2;
        }
    }
}

