using Microsoft.Win32.SafeHandles;
using System;

namespace Utilities.BlueToothTools.MsBluetooth
{
    public class WindowsRadioHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal WindowsRadioHandle(bool ownsHandle) : base(ownsHandle)
        {
        }

        internal WindowsRadioHandle(IntPtr handle) : base(true)
        {
            base.SetHandle(handle);
        }

        protected override bool ReleaseHandle()
        {
            return NativeMethods.CloseHandle(base.handle);
        }
    }
}

