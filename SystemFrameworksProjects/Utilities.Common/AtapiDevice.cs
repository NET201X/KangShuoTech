namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public class AtapiDevice
    {
        private const uint CREATE_NEW = 1;
        private const uint DFP_GET_VERSION = 0x74080;
        private const uint DFP_RECEIVE_DRIVE_DATA = 0x7c088;
        private const uint DFP_SEND_DRIVE_COMMAND = 0x7c084;
        private const uint FILE_SHARE_READ = 1;
        private const uint FILE_SHARE_WRITE = 2;
        private const uint GENERIC_READ = 0x80000000;
        private const uint GENERIC_WRITE = 0x40000000;
        private const uint OPEN_EXISTING = 3;

        private static void ChangeByteOrder(byte[] charArray)
        {
            for (int i = 0; i < charArray.Length; i += 2)
            {
                byte num2 = charArray[i];
                charArray[i] = charArray[i + 1];
                charArray[i + 1] = num2;
            }
        }

        [DllImport("kernel32.dll", SetLastError=true)]
        private static extern int CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll", SetLastError=true)]
        private static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);
        [DllImport("kernel32.dll")]
        private static extern int DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, IntPtr lpInBuffer, uint nInBufferSize, ref GetVersionOutParams lpOutBuffer, uint nOutBufferSize, ref uint lpBytesReturned, [Out] IntPtr lpOverlapped);
        [DllImport("kernel32.dll")]
        private static extern int DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, ref SendCmdInParams lpInBuffer, uint nInBufferSize, ref SendCmdOutParams lpOutBuffer, uint nOutBufferSize, ref uint lpBytesReturned, [Out] IntPtr lpOverlapped);
        private static HardDiskInfo GetHardDiskInfo(IdSector phdinfo)
        {
            HardDiskInfo info = new HardDiskInfo();
            ChangeByteOrder(phdinfo.sModelNumber);
            info.ModuleNumber = Encoding.ASCII.GetString(phdinfo.sModelNumber).Trim();
            ChangeByteOrder(phdinfo.sFirmwareRev);
            info.Firmware = Encoding.ASCII.GetString(phdinfo.sFirmwareRev).Trim();
            ChangeByteOrder(phdinfo.sSerialNumber);
            info.SerialNumber = Encoding.ASCII.GetString(phdinfo.sSerialNumber).Trim();
            info.Capacity = (phdinfo.ulTotalAddressableSectors / 2) / 0x400;
            return info;
        }

        public static HardDiskInfo GetHddInfo(byte driveIndex)
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32S:
                    throw new NotSupportedException("Win32s is not supported.");

                case PlatformID.Win32Windows:
                    return GetHddInfo9x(driveIndex);

                case PlatformID.Win32NT:
                    return GetHddInfoNT(driveIndex);

                case PlatformID.WinCE:
                    throw new NotSupportedException("WinCE is not supported.");
            }
            throw new NotSupportedException("Unknown Platform.");
        }

        private static HardDiskInfo GetHddInfo9x(byte driveIndex)
        {
            GetVersionOutParams lpOutBuffer = new GetVersionOutParams();
            SendCmdInParams lpInBuffer = new SendCmdInParams();
            SendCmdOutParams params3 = new SendCmdOutParams();
            uint lpBytesReturned = 0;
            IntPtr hDevice = CreateFile(@"\\.\Smartvsd", 0, 0, IntPtr.Zero, 1, 0, IntPtr.Zero);
            if (hDevice == IntPtr.Zero)
            {
                throw new Exception("Open smartvsd.vxd failed.");
            }
            if (DeviceIoControl(hDevice, 0x74080, IntPtr.Zero, 0, ref lpOutBuffer, (uint) Marshal.SizeOf(lpOutBuffer), ref lpBytesReturned, IntPtr.Zero) == 0)
            {
                CloseHandle(hDevice);
                throw new Exception("DeviceIoControl failed:DFP_GET_VERSION");
            }
            if ((lpOutBuffer.fCapabilities & 1) == 0)
            {
                CloseHandle(hDevice);
                throw new Exception("Error: IDE identify command not supported.");
            }
            lpInBuffer.irDriveRegs.bDriveHeadReg = ((driveIndex & 1) == 0) ? ((byte) 160) : ((byte) 0xb0);
            if (0L != (lpOutBuffer.fCapabilities & (((int) 0x10) >> driveIndex)))
            {
                CloseHandle(hDevice);
                throw new Exception(string.Format("Drive {0} is a ATAPI device, we don't detect it", driveIndex + 1));
            }
            lpInBuffer.irDriveRegs.bCommandReg = 0xec;
            lpInBuffer.bDriveNumber = driveIndex;
            lpInBuffer.irDriveRegs.bSectorCountReg = 1;
            lpInBuffer.irDriveRegs.bSectorNumberReg = 1;
            lpInBuffer.cBufferSize = 0x200;
            if (DeviceIoControl(hDevice, 0x7c088, ref lpInBuffer, (uint) Marshal.SizeOf(lpInBuffer), ref params3, (uint) Marshal.SizeOf(params3), ref lpBytesReturned, IntPtr.Zero) == 0)
            {
                CloseHandle(hDevice);
                throw new Exception("DeviceIoControl failed: DFP_RECEIVE_DRIVE_DATA");
            }
            CloseHandle(hDevice);
            return GetHardDiskInfo(params3.bBuffer);
        }

        private static HardDiskInfo GetHddInfoNT(byte driveIndex)
        {
            GetVersionOutParams lpOutBuffer = new GetVersionOutParams();
            SendCmdInParams lpInBuffer = new SendCmdInParams();
            SendCmdOutParams params3 = new SendCmdOutParams();
            uint lpBytesReturned = 0;
            IntPtr hDevice = CreateFile(string.Format(@"\\.\PhysicalDrive{0}", driveIndex), 0xc0000000, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
            if (hDevice == IntPtr.Zero)
            {
                throw new Exception("CreateFile faild.");
            }
            if (DeviceIoControl(hDevice, 0x74080, IntPtr.Zero, 0, ref lpOutBuffer, (uint) Marshal.SizeOf(lpOutBuffer), ref lpBytesReturned, IntPtr.Zero) == 0)
            {
                CloseHandle(hDevice);
                throw new Exception(string.Format("Drive {0} may not exists.", driveIndex + 1));
            }
            if ((lpOutBuffer.fCapabilities & 1) == 0)
            {
                CloseHandle(hDevice);
                throw new Exception("Error: IDE identify command not supported.");
            }
            lpInBuffer.irDriveRegs.bDriveHeadReg = ((driveIndex & 1) == 0) ? ((byte) 160) : ((byte) 0xb0);
            if (0L != (lpOutBuffer.fCapabilities & (((int) 0x10) >> driveIndex)))
            {
                CloseHandle(hDevice);
                throw new Exception(string.Format("Drive {0} is a ATAPI device, we don't detect it.", driveIndex + 1));
            }
            lpInBuffer.irDriveRegs.bCommandReg = 0xec;
            lpInBuffer.bDriveNumber = driveIndex;
            lpInBuffer.irDriveRegs.bSectorCountReg = 1;
            lpInBuffer.irDriveRegs.bSectorNumberReg = 1;
            lpInBuffer.cBufferSize = 0x200;
            if (DeviceIoControl(hDevice, 0x7c088, ref lpInBuffer, (uint) Marshal.SizeOf(lpInBuffer), ref params3, (uint) Marshal.SizeOf(params3), ref lpBytesReturned, IntPtr.Zero) == 0)
            {
                CloseHandle(hDevice);
                throw new Exception("DeviceIoControl failed: DFP_RECEIVE_DRIVE_DATA");
            }
            CloseHandle(hDevice);
            return GetHardDiskInfo(params3.bBuffer);
        }
    }
}

