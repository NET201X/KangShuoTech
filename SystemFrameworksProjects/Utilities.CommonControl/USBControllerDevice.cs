namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct USBControllerDevice
    {
        public string Antecedent;
        public string Dependent;
    }
}

