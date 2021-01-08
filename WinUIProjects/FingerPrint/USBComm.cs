using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace FingerPrint
{
    public class USBComm
    {
        // Parent Window (MainWindow)
        private MainWindow m_pMainWindow;

        private SafeFileHandle m_hHandle;

        private const uint SMART_SEND_DRIVE_COMMAND = 0x07c084;
        private const uint SMART_EXECUTE_OFF_LINE_IMMEDIATE = 0xD4;
        private const uint LAB_LOW = 1;
        private const uint LAB_MID = 0x4F;
        private const uint LAB_HEIGHT = 0xC2;
        private const uint COMMAND = 0xB0;

        private const uint FileAccessGenericRead = 0x80000000;
        private const uint FileAccessGenericWrite = 0x40000000;
        private const uint FileShareWrite = 0x2;
        private const uint FileShareRead = 0x1;
        private const uint CreationDispositionOpenExisting = 0x3;

        private const uint DRIVE_UNKNOWN = 0;
        private const uint DRIVE_NO_ROOT_DIR = 1;
        private const uint DRIVE_REMOVABLE = 2;
        private const uint DRIVE_FIXED = 3;
        private const uint DRIVE_REMOTE = 4;
        private const uint DRIVE_CDROM = 5;
        private const uint DRIVE_RAMDISK = 6;

        private const uint SCSI_TIMEOUT = 300;
        private const uint ONCE_UP_IMAGE_UINT = 60000;

        private const uint IOCTL_SCSI_BASE = 4;
        private const uint METHOD_BUFFERED = 0;
        private const uint FILE_READ_ACCESS = 1;
        private const uint FILE_WRITE_ACCESS = 2;
        private uint IOCTL_SCSI_PASS_THROUGH_DIRECT = CTL_CODE(IOCTL_SCSI_BASE, 0x0405, METHOD_BUFFERED, FILE_READ_ACCESS | FILE_WRITE_ACCESS);

        [StructLayout(LayoutKind.Sequential)]
        internal struct IDEREGS
        {
            public byte bFeaturesReg;
            public byte bSectorCountReg;
            public byte bSectorNumberReg;
            public byte bCylLowReg;
            public byte bCylMidReg;
            public byte bCylHighReg;
            public byte bDriveHeadReg;
            public byte bCommandReg;
            public byte bReserved;
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct DRIVERSTATUS
        {
            public byte bDriverError;
            public byte bIDEError;
            public byte[] bReserved;
            public ulong[] dwReserved;
        }


        [StructLayout(LayoutKind.Sequential)]
        internal struct SENDCMDOUTPARAMS
        {
            public ulong cBufferSize;
            public DRIVERSTATUS DriverStatus;
            public byte[] bBuffer;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SENDCMDINPARAMS
        {
            public ulong cBufferSize;
            public IDEREGS irDriveRegs;
            public byte bDriveNumber;
            public byte[] bReserved;
            public ulong[] dwReserved;
            public byte[] bBuffer;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class ScsiPassThroughDirect
        {
            /// <summary>The size of the item passed to DeviceIoControl</summary>
            public ushort Length;

            /// <summary>The status of the SCSI command</summary>
            public byte ScsiStatus;

            /// <summary>The SCSI bus</summary>
            public byte PathId;

            /// <summary>The SCSI target</summary>
            public byte TargetId;

            /// <summary>The SCSI lun</summary>
            public byte Lun;

            /// <summary>The number of bytes in the CDB field</summary>
            public byte CdbLength;

            /// <summary>How long the sense info structure is</summary>
            public byte SenseInfoLength;

            /// <summary>Usually set to SCSI_IOCTL_DATA_IN</summary>
            public byte DataIn;

            /// <summary>How many bytes to transfer</summary>
            public UInt32 DataTransferLength;

            /// <summary>How long to wait before timing out</summary>
            public UInt32 TimeOutValue;

            /// <summary>The offset of the data buffer area returned</summary>
            public IntPtr DataBuffer; // UInt32 does not work on 64-bit

            /// <summary>The offset of the sense info returned</summary>
            public UInt32 SenseInfoOffset;

            /// <summary>The command code to send to the robot</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Cdb;

            public ScsiPassThroughDirect(byte target, byte bus, byte lun, byte cdbLen, UInt32 dataTransferLength)
            {
                Length = (ushort) Marshal.SizeOf(typeof(ScsiPassThroughDirect));
                ScsiStatus = 0;
                PathId = bus;
                TargetId = target;
                Lun = lun;
                CdbLength = cdbLen;
                SenseInfoLength = 0;
                DataIn = 1;    // SCSI_IOCTL_DATA_IN
                DataTransferLength = dataTransferLength;
                TimeOutValue = 3000;
                SenseInfoOffset = (uint)Marshal.OffsetOf(typeof(ScsiPassThroughDirectWithBuffers), "ucSenseBuf");
                Cdb = new byte[16] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class ScsiPassThroughDirectWithBuffers
        {
            /// <summary>The SPT we're wrapping</summary>
            public ScsiPassThroughDirect spt;

            /// <summary>Used to align the size of the structure</summary>
            public UInt32 Filler;

            /// <summary>The buffer to write sense info into</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] ucSenseBuf;

            /// <summary>
            /// Constructor for the command to send to the robot
            /// </summary>
            /// <param name="target">The SCSI target</param>
            /// <param name="bus">The SCSI bus</param>
            /// <param name="lun">The SCSI lun</param>
            /// <param name="cdbLen">The length of the CDB to be sent</param>
            /// <param name="dataTransferLength">The length to use</param>
            public ScsiPassThroughDirectWithBuffers(byte target, byte bus, byte lun, byte cdbLen, UInt32 dataTransferLength)
            {
                spt = new ScsiPassThroughDirect(target, bus, lun, cdbLen, dataTransferLength);
                Filler = 0;
                ucSenseBuf = new byte[32];
            }
        }

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern SafeFileHandle CreateFile(
            string fileName,
            uint fileAccess,
            uint fileShare,
            IntPtr securityAttributes,
            uint creationDisposition,
            uint flags,
            IntPtr template);

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern bool DeviceIoControl(
            SafeFileHandle device,
            uint controlCode,
             IntPtr inBuffer,
            uint inBufferSize,
             IntPtr outBuffer,
            uint outBufferSize,
            ref uint bytesReturned,
            IntPtr overlapped);

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint GetDriveType(
            string lpRootPathName);

        public static uint CTL_CODE(uint DeviceType, uint Function, uint Method, uint Access)
        {
            uint w_nRet;

            w_nRet = ((DeviceType & 0xFF) << 16) | ((Access & 0xFF) << 14) | ((Function & 0xFFFF) << 2) | (Method & 0xFF);
            return w_nRet;
        }

        public USBComm(Object p_pMainObj)
        {
            // Get Parent Window
            m_pMainWindow = (MainWindow)p_pMainObj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool OpenUSB()
        {
	        int w_nDriver;
            uint w_nType;

            for (w_nDriver = 'C'; w_nDriver <= 'Z'; w_nDriver ++)
	        {
                w_nType = GetDriveType(String.Format("{0}:", Char.ToString((char)(w_nDriver))));
		        if(w_nType == DRIVE_REMOVABLE || w_nType == DRIVE_CDROM)
		        {
			        m_hHandle = CreateFile(String.Format("\\\\.\\{0}:", Char.ToString((char)(w_nDriver))),
                        FileAccessGenericWrite | FileAccessGenericRead,
                        FileShareRead | FileShareWrite,
				        IntPtr.Zero,
                        CreationDispositionOpenExisting,
				        0,
                        IntPtr.Zero);

                    if (m_hHandle.IsInvalid)
                        continue;
                    
			        MainWindow.m_clsCmdProc.InitPacket(CommonDefine.CMD_TEST_CONNECTION_CODE, true);
                    MainWindow.m_clsCmdProc.AddCheckSum(true);
			        if(USB_SendPacket(CommonDefine.CMD_TEST_CONNECTION_CODE) == true)
				        return true;
		        }
	        }

            return false;
        }

        public bool CloseUsb()
        {
            if (m_hHandle.IsInvalid)
                return true;

            m_hHandle.Close();
            return true;
        }

        public bool USB_SendPacket(ushort p_wCMD)
        {
	        byte[]	btCDB = new byte[8];

            CommandProc.memset(btCDB, 0, 0, 8);
            btCDB[0] = 0xEF; btCDB[1] = 0x11; btCDB[4] = CommonDefine.ST_COM_PACKET_LEN + 2;
            if (!USBSCSIWrite(btCDB, 8, CommandProc.m_pPacketBuffer, CommonDefine.ST_COM_PACKET_LEN + 2, SCSI_TIMEOUT))
		        return false;

	        return USB_ReceiveAck(p_wCMD, true);
        }

        public bool USB_ReceiveAck(ushort p_wCMD, bool p_bCmdData)
        {
	        byte[]	btCDB = new byte[8];
	        byte[]	w_WaitPacket = new byte[24];
	        int[] nLen = new int[1];
	        int	w_dwTimeOut = (int)SCSI_TIMEOUT;

	        if (p_wCMD == CommonDefine.CMD_VERIFY_CODE ||
                p_wCMD == CommonDefine.CMD_IDENTIFY_CODE ||
                p_wCMD == CommonDefine.CMD_IDENTIFY_FREE_CODE ||
                p_wCMD == CommonDefine.CMD_ENROLL_CODE ||
                p_wCMD == CommonDefine.CMD_ENROLL_ONETIME_CODE)
                w_dwTimeOut = (CommonDefine.GD_MAX_FP_TIME_OUT + 1) * (1000);

            CommandProc.memset(w_WaitPacket, 0xAF, 0, CommonDefine.ST_COM_PACKET_LEN + 2);
            CommandProc.memset(btCDB, 0, 0, 8);

	        do 
	        {
                CommandProc.memset(CommandProc.m_pPacketBuffer, 0, 0, CommonDefine.MAX_DATA_LEN + 10);
		        btCDB[0] = 0xEF; btCDB[1] = 0x12;
                nLen[0] = CommonDefine.ST_COM_PACKET_LEN + 2;
                if (!USBSCSIRead(btCDB, 8, CommandProc.m_pPacketBuffer, nLen, (uint)w_dwTimeOut))
			        return false;
		        Thread.Sleep(100);
                if (!CommandProc.DoEvents())
                    return false;
            } while (CommandProc.memcmp(CommandProc.m_pPacketBuffer, w_WaitPacket, CommonDefine.ST_COM_PACKET_LEN + 2) == true);

            if (p_bCmdData)
                return MainWindow.m_clsCmdProc.CheckReceive(CommonDefine.RCM_PREFIX_CODE, p_wCMD);
            else
                return MainWindow.m_clsCmdProc.CheckReceive(CommonDefine.RCM_DATA_PREFIX_CODE, p_wCMD);
        }

        bool USB_ReceiveDataAck(ushort p_wCMD)
        {
	        byte[] btCDB = new byte[8];
	        int[] nLen = new int[1];
	        int	w_dwTimeOut = CommonDefine.COMM_TIMEOUT;
	        byte[] w_WaitPacket = new byte[8];
            byte[] w_pTmpBuf;
	
	        if (p_wCMD == CommonDefine.CMD_VERIFY_CODE ||
                p_wCMD == CommonDefine.CMD_IDENTIFY_CODE ||
                p_wCMD == CommonDefine.CMD_IDENTIFY_FREE_CODE ||
                p_wCMD == CommonDefine.CMD_ENROLL_CODE ||
                p_wCMD == CommonDefine.CMD_ENROLL_ONETIME_CODE)
                w_dwTimeOut = (CommonDefine.GD_MAX_FP_TIME_OUT + 1) * (1000);
	
	        CommandProc.memset(w_WaitPacket, 0xAF, 0, 8);
            CommandProc.memset(btCDB, 0, 0, 8);

	        do
	        {
		        btCDB[0] = 0xEF; btCDB[1] = 0x15;
		        nLen[0] = 6;
		        if (!USBSCSIRead(btCDB, 8, CommandProc.m_pPacketBuffer, nLen, (uint)w_dwTimeOut))
			        return false;
		        Thread.Sleep(100);
                if (!CommandProc.DoEvents())
                    return false;
	        } while (CommandProc.memcmp(CommandProc.m_pPacketBuffer, w_WaitPacket, 6) == true);

            nLen[0] = CommandProc.GET_PACKET_LEN(false) + 2;
            w_pTmpBuf = new byte[nLen[0] + 10];
	        do 
	        {
                Array.Copy(CommandProc.m_pPacketBuffer, 6, w_pTmpBuf, 0, nLen[0]);
		        if (!USB_ReceiveRawData(w_pTmpBuf, (uint)nLen[0]))
			        return false;
                Array.Copy(w_pTmpBuf, 0, CommandProc.m_pPacketBuffer, 6, nLen[0]);
		        Thread.Sleep(5);
                if (!CommandProc.DoEvents())
                    return false;
	        } while (CommandProc.memcmp(CommandProc.m_pPacketBuffer, w_WaitPacket, 4) == true);

            return MainWindow.m_clsCmdProc.CheckReceive(CommonDefine.RCM_DATA_PREFIX_CODE, p_wCMD);
        }

        public bool USB_SendDataPacket(ushort p_wCMD)
        {
	        byte[] btCDB = new byte[8];
            short w_wLen = (short)(CommandProc.GET_DATAPACKET_LEN(false) + 2);

            CommandProc.memset(btCDB, 0, 0, 8);
	        btCDB[0] = 0xEF; btCDB[1] = 0x13;
	        btCDB[4] = (byte)(w_wLen & 0xFF); btCDB[5] = (byte)(w_wLen >> 8);
            if (!USBSCSIWrite(btCDB, 8, CommandProc.m_pPacketBuffer, (uint)(CommandProc.GET_DATAPACKET_LEN(false) + 2), SCSI_TIMEOUT))
		        return false;
	
	        return USB_ReceiveDataAck(p_wCMD);
        }

        public bool USB_ReceiveDataPacket(ushort p_wCMD, ushort p_wDataLen)
        {
            return USB_ReceiveDataAck(p_wCMD);
        }

        public bool USB_ReceiveRawData(byte[] p_pBuffer, uint p_dwDataLen)
        {
            int[] w_nDataCnt = new int[1];
	        byte[] btCDB = new byte[8];

            w_nDataCnt[0] = (int)p_dwDataLen;
            CommandProc.memset(btCDB, 0, 0, 8);
	        btCDB[0] = 0xEF; btCDB[1] = 0x14;
	        if (!USBSCSIRead(btCDB, 8, p_pBuffer, w_nDataCnt, SCSI_TIMEOUT))
		        return false;

	        return true;
        }

        public bool USB_ReceiveImage(byte[] p_pBuffer, uint p_dwDataLen)
        {
	        byte[] btCDB = new byte[8];
	        byte[] w_WaitPacket = new byte[8];
	        int[] w_nDataCnt = new int[1];
	        int[] w_nSentLen = new int[1];
            byte[] w_pTmpBuf = new byte[ONCE_UP_IMAGE_UINT];
	        int w_nI;
	
	        CommandProc.memset(w_WaitPacket, 0xAF, 0, 8);
	
	        if (p_dwDataLen == 208 * 288 || p_dwDataLen == 242 * 266 || p_dwDataLen == 202 * 258 || p_dwDataLen == 256 * 288)
	        {
		        w_nDataCnt[0] = (int)p_dwDataLen;
		        w_nI = 0;
                CommandProc.memset(btCDB, 0, 0, 8);
		        while (w_nDataCnt[0] > ONCE_UP_IMAGE_UINT)
		        {
			        btCDB[0] = 0xEF; btCDB[1] = 0x16; btCDB[2] = (byte)w_nI;
			        w_nSentLen[0] = (int)ONCE_UP_IMAGE_UINT;
			        if (!USBSCSIRead(btCDB, 8, w_pTmpBuf, w_nSentLen, SCSI_TIMEOUT))
				        return false;
			        w_nDataCnt[0] -= (int)ONCE_UP_IMAGE_UINT;
                    Array.Copy(w_pTmpBuf, 0, p_pBuffer, w_nI * ONCE_UP_IMAGE_UINT, ONCE_UP_IMAGE_UINT);
			        w_nI ++;
		        }
		        btCDB[0] = 0xEF; btCDB[1] = 0x16; btCDB[2] = (byte)w_nI;
		        if (!USBSCSIRead(btCDB, 8, w_pTmpBuf, w_nDataCnt, SCSI_TIMEOUT))
			        return false;
                Array.Copy(w_pTmpBuf, 0, p_pBuffer, w_nI * ONCE_UP_IMAGE_UINT, w_nDataCnt[0]);
	        }
	
	        return true;
        }

        public bool USB_DownImage(byte[] pBuf, int nBufLen)
        {
	        byte[] tPCCmd = new byte[6];
	        int w_nDataCnt;
	        byte[] w_pImgBuf = new byte[ONCE_UP_IMAGE_UINT];
	        int		w_nI;

            if(m_hHandle.IsInvalid)
		        return false;

	        w_nDataCnt = nBufLen;
	        w_nI = 0;
	
	        while (w_nDataCnt > ONCE_UP_IMAGE_UINT)
	        {
		        tPCCmd[0] = 0xEF;
		        tPCCmd[1] = 0x17;
		        tPCCmd[3] = (byte)w_nI;
		        tPCCmd[4] = CommandProc.LOBYTE((ushort)(ONCE_UP_IMAGE_UINT & 0xFFFF));
                tPCCmd[5] = CommandProc.HIBYTE((ushort)(ONCE_UP_IMAGE_UINT & 0xFFFF));

                Array.Copy(pBuf, w_nI * ONCE_UP_IMAGE_UINT, w_pImgBuf, 0, ONCE_UP_IMAGE_UINT);

		        if (!USBSCSIWrite(tPCCmd, 6, w_pImgBuf, ONCE_UP_IMAGE_UINT, SCSI_TIMEOUT))
			        return false;

		        w_nDataCnt -= (int)ONCE_UP_IMAGE_UINT;
		        w_nI ++;
	        }

	        tPCCmd[0] = 0xEF;
	        tPCCmd[1] = 0x17;
	        tPCCmd[3] = (byte)w_nI;
	        tPCCmd[4] = CommandProc.LOBYTE((ushort)(w_nDataCnt & 0xFFFF));
            tPCCmd[5] = CommandProc.HIBYTE((ushort)(w_nDataCnt & 0xFFFF));

            Array.Copy(pBuf, w_nI * ONCE_UP_IMAGE_UINT, w_pImgBuf, 0, w_nDataCnt);

	        if (!USBSCSIWrite(tPCCmd, 6, w_pImgBuf, (uint)w_nDataCnt, SCSI_TIMEOUT))
		        return false;
	
	        return true;
        }

        public bool USBSCSIRead(byte[] pCDB, int nCDBLen, byte[] pData, int[] nLength, uint nTimeOut)
        {
            try
            {
                bool status = false;

                ScsiPassThroughDirectWithBuffers sptdwb;
                int length = 0;
                uint TransLen;
                uint BytesReturned = 0;
                IntPtr w_pBuf;
                IntPtr w_pData;

                length = nLength[0];

                if (m_hHandle.IsInvalid)
                    return false;

                TransLen = (uint)nLength[0];

                w_pData = Marshal.AllocHGlobal(nLength[0] + 10);
                Marshal.Copy(pData, 0, w_pData, nLength[0]);
                sptdwb = new ScsiPassThroughDirectWithBuffers(1, 0, 0, 6/*CDB6GENERIC_LENGTH*/, TransLen);
                sptdwb.spt.DataIn = 1; //SCSI_IOCTL_DATA_IN
                sptdwb.spt.TimeOutValue = nTimeOut;
                sptdwb.spt.DataBuffer = w_pData;
                Array.Copy(pCDB, sptdwb.spt.Cdb, nCDBLen);

                length = Marshal.SizeOf(sptdwb);
                BytesReturned = (uint)nLength[0];

                w_pBuf = Marshal.AllocHGlobal(length);
                Marshal.StructureToPtr(sptdwb, w_pBuf, false);

                status = DeviceIoControl(m_hHandle,
                    IOCTL_SCSI_PASS_THROUGH_DIRECT,
                    w_pBuf,
                    (uint)length,
                    w_pBuf,
                    (uint)length,
                    ref BytesReturned,
                    IntPtr.Zero);

                Marshal.PtrToStructure(w_pBuf, sptdwb);
                nLength[0] = (int)sptdwb.spt.DataTransferLength;
                if (status == false)
                {
                    length = Marshal.GetLastWin32Error();
                }
                Marshal.Copy(sptdwb.spt.DataBuffer, pData, 0, nLength[0]);
                Marshal.FreeHGlobal(w_pBuf);
                Marshal.FreeHGlobal(w_pData);
                return status;
            }
            catch
            {
                return false;
            }
        }

        public bool USBSCSIWrite(byte[] pCDB, int nCDBLen, byte[] pData, uint nLength, uint nTimeOut)
        {
            try
            {
                bool status = false;

                ScsiPassThroughDirectWithBuffers sptdwb;
                int length = 0;
                uint TransLen;
                uint returned = 0;
                IntPtr w_pBuf;
                IntPtr w_pData;

                if (m_hHandle.IsInvalid)
                    return false;
                TransLen = nLength;

                w_pData = Marshal.AllocHGlobal((int)nLength);
                Marshal.Copy(pData, 0, w_pData, (int)nLength);
                sptdwb = new ScsiPassThroughDirectWithBuffers(1, 0, 0, 6/*CDB6GENERIC_LENGTH*/, TransLen);
                sptdwb.spt.DataIn = 0; //SCSI_IOCTL_DATA_OUT
                sptdwb.spt.TimeOutValue = nTimeOut;
                sptdwb.spt.DataBuffer = w_pData;

                Array.Copy(pCDB, sptdwb.spt.Cdb, nCDBLen);
                length = Marshal.SizeOf(sptdwb);

                w_pBuf = Marshal.AllocHGlobal(length);
                Marshal.StructureToPtr(sptdwb, w_pBuf, false);
                status = DeviceIoControl(m_hHandle,
                    IOCTL_SCSI_PASS_THROUGH_DIRECT,
                    w_pBuf,
                    (uint)length,
                    w_pBuf,
                    (uint)length,
                    ref returned,
                    IntPtr.Zero);
                Marshal.PtrToStructure(w_pBuf, sptdwb);
                if (status == false)
                {
                    length = Marshal.GetLastWin32Error();
                }
                Marshal.FreeHGlobal(w_pBuf);
                Marshal.FreeHGlobal(w_pData);
                return status;
            }
            catch {
                return false;
            }
        }
    }
}
