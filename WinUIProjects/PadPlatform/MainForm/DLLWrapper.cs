namespace PadPlatform
{
    using System;
    using System.Runtime.InteropServices;

    public class DLLWrapper
    {
        [DllImport("Kernel32")]
        public static extern int FreeLibrary(int handle);
        public static Delegate GetDelegateFromIntPtr(int address, Type t)
        {
            if (address == 0)
            {
                return null;
            }
            return Marshal.GetDelegateForFunctionPointer(new IntPtr(address), t);
        }

        public static Delegate GetDelegateFromIntPtr(IntPtr address, Type t)
        {
            if (address == IntPtr.Zero)
            {
                return null;
            }
            return Marshal.GetDelegateForFunctionPointer(address, t);
        }

        public static Delegate GetFunctionAddress(int dllModule, string functionName, Type t)
        {
            int procAddress = GetProcAddress(dllModule, functionName);
            if (procAddress == 0)
            {
                return null;
            }
            return Marshal.GetDelegateForFunctionPointer(new IntPtr(procAddress), t);
        }

        [DllImport("Kernel32")]
        public static extern int GetProcAddress(int handle, string funcname);
        [DllImport("Kernel32")]
        public static extern int LoadLibrary(string funcname);
    }
}

