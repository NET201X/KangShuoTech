using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
//using System.Windows.Threading;

namespace FingerPrint
{
    public class CommandProc
    {
        //////////////////////////////////////////////////////////////////////////
        // Member Variable

        // Common Variables
        public bool            m_bIsConnected = false;                 // Default is Not Connected
        public bool            m_bConModeIsUSB = false;                // Default is COM

        // Packet
        public static byte[]          m_pPacketBuffer = new byte[CommonDefine.MAX_DATA_LEN + 10];      // Packet Buffer
        public ushort          m_nCmdCode;

        public static byte[]          m_pPacketBuffer0 = new byte[CommonDefine.MAX_DATA_LEN + 10];      // Packet Buffer

        // Thread
        public bool            m_bCmdDone;

        // Parent Window (MainWindow)
        public MainWindow      m_pMainWindow;

        public static bool g_bDoEvent = false;

        // Image
        public static byte[] g_pImageBuf = new byte[640 * 480];
        public static int g_nImageWidth = 0;
        public static int g_nImageHeight = 0;
        //////////////////////////////////////////////////////////////////////////

        // Do Event
        public static bool g_bCloseApp = false;

        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr handle;
            public uint msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }

//         [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PeekMessage(out NativeMessage message, IntPtr handle, uint filterMin, uint filterMax, uint flags);

        [DllImport("user32.dll")]
        static extern bool TranslateMessage([In] ref NativeMessage lpMsg);

        [DllImport("user32.dll")]
        static extern IntPtr DispatchMessage([In] ref NativeMessage lpmsg);

        public static bool DoEvents()
        {
           // Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate{}));

            Application.DoEvents();
            if (g_bCloseApp)
                return false;
            return true;
//             NativeMessage msg = new NativeMessage();
//             GCHandle handle = GCHandle.Alloc(msg);
//             while (PeekMessage(out msg, IntPtr.Zero, 0, 0, 1))
//             {
//                 TranslateMessage(ref msg);
//                 DispatchMessage(ref msg);
//             }
//             handle.Free();
        }

        public CommandProc(Object p_pMainObj)
        {
            // Get Parent Window
            m_pMainWindow = (MainWindow)p_pMainObj;
            
            // Init Variables
            m_bCmdDone = true;
            g_bCloseApp = false;
        }

        public bool Run_Connect(bool p_bIsUSB, string p_strCOMPort, uint p_nBaudRate)
        {
            if (p_bIsUSB)
            {
                // Open USB
                if (!MainWindow.m_clsUSB.OpenUSB())
                    return false;
            }
            else
            {
                // Open COM Port
                if (!MainWindow.m_clsSerial.OpenPort(p_strCOMPort, p_nBaudRate))
                    return false;
            }

            // Set Variables
            m_bConModeIsUSB = p_bIsUSB;
            m_bIsConnected = true;

            // Return
            return true;
        }

        public bool Run_Disconnect()
        {
            // Check Connection
            if (!m_bIsConnected)
                return false;

            //// Close Device
            //if (m_bConModeIsUSB)
            //{
                // Close USB
                if (!MainWindow.m_clsUSB.CloseUsb())
                    return false;
            //}
            //else
            //{
            //    // Close COM Port
            //    if (!MainWindow.m_clsSerial.ClosePort())
            //        return false;
            //}

            // Init Variables
            m_bIsConnected = false;

            // Return
            return true;
        }

        public bool Run_TestConnection()
        {
            bool w_bRet;

            // Make Packet
            InitPacket(CommonDefine.CMD_TEST_CONNECTION_CODE, true);
            AddCheckSum(true);
            
            // Send Packet
            if (m_bConModeIsUSB)
            {
                // USB Send
            }
            else
            {
                // Serial Send
                w_bRet = SendCommand(CommonDefine.CMD_TEST_CONNECTION_CODE);
                if (!w_bRet)
                    return false;
                if (GET_PACKET_RETURN(false) != CommonDefine.ERR_SUCCESS)
                {
                    MessageBox.Show("通讯或连接错误!", "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            // Return
            return true;
        }



        public bool Run_Command_1P(ushort p_nCmd, ushort p_nData)
        {
            bool w_bRet = false;

            // Disable Disconnect Button
           /// m_pMainWindow.btnCI_DisConnect.IsEnabled = false;

            // Assemble Command Packet
            InitPacket(p_nCmd, true);
            SET_PACKET_LEN((ushort)2, false);
            SET_PACKET_CMDDATA(p_nData, 0, false);
            AddCheckSum(true);

            // Display Command Packet
            m_pMainWindow.DisplayCommandPacket();

            // Run Send Thread
            m_nCmdCode = p_nCmd;
            StartSendThread();

            // Return
            return w_bRet;
        }

        public bool Run_Command_NP(ushort p_nCmd)
        {
            bool w_bRet = false;

            // Disable Disconnect Button
           // m_pMainWindow.btnCI_DisConnect.IsEnabled = false;

	        // Assemble command packet
            InitPacket(p_nCmd, true);
	        AddCheckSum( true );
	        
            // Display command information
	        //m_pMainWindow.DisplayCommandPacket();

            // Run Send Thread
            m_nCmdCode = p_nCmd;
	        StartSendThread();

            // Return
	        return w_bRet;
        }

        public bool SendCommand(ushort p_nCmd)
        {
            uint	w_nTimeOut;
	        bool	w_bRet = false;

            // Calculate Time Out
	        if (p_nCmd == CommonDefine.CMD_TEST_CONNECTION_CODE)
		        w_nTimeOut = 1500;
	        else
		        w_nTimeOut = CommonDefine.COMM_TIMEOUT;

            // Send Data
            w_bRet = MainWindow.m_clsSerial.SendData(m_pPacketBuffer, CommonDefine.ST_COM_PACKET_LEN + 2, w_nTimeOut);
            if (!w_bRet)
            {
                MessageBox.Show("错误的命令包", "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Receive Data
            w_bRet = ReceiveAck(p_nCmd, true);

            // Return
            return w_bRet;
        }

        public bool ReceiveAck(ushort p_nCmd, bool p_bCmdData)
        {
            bool w_bRet = false;
            ushort w_nTimeOut = CommonDefine.COMM_TIMEOUT;
            uint[] w_nReadLen = new uint[1];

            // Get TimeOut
            if (p_nCmd == CommonDefine.CMD_VERIFY_CODE ||
                p_nCmd == CommonDefine.CMD_IDENTIFY_CODE ||
		        p_nCmd == CommonDefine.CMD_IDENTIFY_FREE_CODE ||
		        p_nCmd == CommonDefine.CMD_ENROLL_CODE ||
		        p_nCmd == CommonDefine.CMD_ENROLL_ONETIME_CODE ||
		        p_nCmd == CommonDefine.CMD_CHANGE_TEMPLATE_CODE ||
		        p_nCmd == CommonDefine.CMD_FEATURE_OF_CAPTURED_FP_CODE ||
		        p_nCmd == CommonDefine.CMD_IDENTIFY_TEMPLATE_WITH_FP_CODE ||
		        p_nCmd == CommonDefine.CMD_FINGER_DETECT_CODE)
		        w_nTimeOut = CommonDefine.GD_MAX_FP_TIME_OUT * 1000;
	        else if (p_nCmd == CommonDefine.CMD_TEST_CONNECTION_CODE)
		        w_nTimeOut = 1500;

            Array.Clear(m_pPacketBuffer, 0, CommonDefine.MAX_DATA_LEN + 10);

            // Receive Data
            w_bRet = MainWindow.m_clsSerial.ReceiveData(m_pPacketBuffer, CommonDefine.ST_COM_PACKET_LEN + 2, w_nReadLen, w_nTimeOut);
	        if (!w_bRet)
            {
                if (!g_bCloseApp)
                    MessageBox.Show("请检查连接！", "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
	        }

            // Check Receive Data
            if (p_bCmdData)
                w_bRet = CheckReceive(CommonDefine.RCM_PREFIX_CODE, p_nCmd);
            else
                w_bRet = CheckReceive(CommonDefine.RCM_DATA_PREFIX_CODE, p_nCmd);

            // Return
            return w_bRet;
        }

        public bool SendData(ushort p_nCmd, int p_nDataLen, byte[] p_pData)
        {
            int w_nSendedCnt;
            int w_nPacketDataLen = 0;

            for (w_nSendedCnt = 0; w_nSendedCnt < p_nDataLen; w_nSendedCnt += w_nPacketDataLen)
            {
                w_nPacketDataLen = p_nDataLen - w_nSendedCnt;
                if (w_nPacketDataLen > CommonDefine.MAX_DATA_LEN)
                    w_nPacketDataLen = CommonDefine.MAX_DATA_LEN;

                InitPacket(p_nCmd, false);
                SET_PACKET_LEN((ushort)w_nPacketDataLen, false);
                Array.Copy(p_pData, w_nSendedCnt, m_pPacketBuffer, CommonDefine.ST_CMDDATA_INDEX, w_nPacketDataLen);
                AddCheckSum(false);

                if (SendDataPacket(p_nCmd) == false)
                    return false;
            }
            return true;
        }

        public bool ReceiveDataAck(ushort p_nCmd)
        {
            int w_nTimeOut = CommonDefine.COMM_TIMEOUT;

            if (p_nCmd == CommonDefine.CMD_VERIFY_CODE ||
                p_nCmd == CommonDefine.CMD_IDENTIFY_CODE ||
                p_nCmd == CommonDefine.CMD_IDENTIFY_FREE_CODE ||
                p_nCmd == CommonDefine.CMD_ENROLL_CODE ||
                p_nCmd == CommonDefine.CMD_ENROLL_ONETIME_CODE ||
                p_nCmd == CommonDefine.CMD_CHANGE_TEMPLATE_CODE ||
                p_nCmd == CommonDefine.CMD_FEATURE_OF_CAPTURED_FP_CODE ||
                p_nCmd == CommonDefine.CMD_IDENTIFY_TEMPLATE_WITH_FP_CODE)
                w_nTimeOut = CommonDefine.GD_MAX_FP_TIME_OUT * 1000;

            if (!ReadDataN(m_pPacketBuffer, 0, 6, w_nTimeOut))
                return false;

            if (!ReadDataN(m_pPacketBuffer, 6, GET_PACKET_LEN(false) + 2, w_nTimeOut))
                return false;

            return CheckReceive(CommonDefine.RCM_DATA_PREFIX_CODE, p_nCmd);
        }
        
        public bool SendDataPacket(ushort p_nCmd)
        {
	        bool w_bResult = true;

            w_bResult = MainWindow.m_clsSerial.SendData(m_pPacketBuffer, (uint)GET_DATAPACKET_LEN(false) + 2, (uint)CommonDefine.COMM_TIMEOUT);
	        if (!w_bResult)
            {
                MessageBox.Show("命令包错误 !", "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		        return false;
	        }
	        return ReceiveDataAck(p_nCmd);
        }

        public bool ReceiveData(ushort p_nCmd, int p_nDataLen, byte[] p_pData)
        {
            int w_nReceivedCnt;
            int w_nPacketDataLen = 0;

            for (w_nReceivedCnt = 0; w_nReceivedCnt < p_nDataLen; w_nReceivedCnt += w_nPacketDataLen)
            {
                w_nPacketDataLen = p_nDataLen - w_nReceivedCnt;
                if (w_nPacketDataLen > CommonDefine.MAX_DATA_LEN)
                    w_nPacketDataLen = CommonDefine.MAX_DATA_LEN;
                if (ReceiveDataPacket(p_nCmd, (ushort)w_nPacketDataLen) == false)
                    return false;
                Array.Copy(m_pPacketBuffer, CommonDefine.ST_CMDDATA_INDEX + 2, p_pData, w_nReceivedCnt, GET_DATAPACKET_LEN(false) - 2);
            }
            return true;
        }
        
        public bool ReceiveDataPacket(ushort p_nCmd, ushort p_nDataLen)
        {
            return ReceiveDataAck(p_nCmd);
        }
        
        public bool ReadDataN(byte[] p_pData, int p_nStartIndex, int p_nLen, int p_nTimeOut)
        {
            bool w_bResult;
            int w_nRecvLen, w_nTotalRecvLen;
            byte[] w_pTmpBuf = new byte[p_nLen];
            uint[] w_nReadLen = new uint[1];

            w_nRecvLen = p_nLen;
            w_nTotalRecvLen = 0;

            while (w_nTotalRecvLen < p_nLen)
            {
                w_bResult = MainWindow.m_clsSerial.ReceiveData(w_pTmpBuf, (uint)w_nRecvLen, w_nReadLen, (uint)p_nTimeOut);
                if (!w_bResult)
                    return false;

                Array.Copy(w_pTmpBuf, 0, p_pData, p_nStartIndex + w_nTotalRecvLen, w_nReadLen[0]);
                w_nRecvLen = w_nRecvLen - (int)w_nReadLen[0];
                w_nTotalRecvLen = w_nTotalRecvLen + (int)w_nReadLen[0];
            }

            return true;
        }

        public bool CheckReceive(ushort p_nPrefix, ushort p_nCmd)
        {
            ushort w_nCheckSum;
            ushort w_nLen;

            // Check Prefix and Command Code
            if (p_nPrefix != GET_PACKET_PREFIX(false) ||
                p_nCmd != GET_PACKET_COMMAND(false))
                return false;

            // Calculate Length
            if (p_nPrefix == CommonDefine.RCM_PREFIX_CODE)
                w_nLen = CommonDefine.ST_COM_PACKET_LEN;
            else
                w_nLen = GET_DATAPACKET_LEN(false);

            // Get CheckSum
            w_nCheckSum = (ushort)((m_pPacketBuffer[w_nLen + 1] << 8) + m_pPacketBuffer[w_nLen]);

            // Check CheckSum
            if (w_nCheckSum != GetCheckSum(p_nPrefix == CommonDefine.RCM_PREFIX_CODE))
                return false;

            // Return Success
            return true;
        }

        public void InitPacket(ushort p_nCMD, bool p_bCmdData)
        {
            // Clear Buffer
            Array.Clear(m_pPacketBuffer, 0, CommonDefine.MAX_DATA_LEN + 10);

            // Make Packet
            if (p_bCmdData)
                SET_PACKET_PREFIX(CommonDefine.CMD_PREFIX_CODE, false);
            else
                SET_PACKET_PREFIX(CommonDefine.CMD_DATA_PREFIX_CODE, false);
            SET_PACKET_COMMAND(p_nCMD, false);
        }

        public ushort AddCheckSum(bool p_bCmdData)
        {
            ushort w_nRet = 0;
            ushort w_nLen;
            int w_nI;

            // Get Length
            if (p_bCmdData)
                w_nLen = CommonDefine.ST_COM_PACKET_LEN;
            else
                w_nLen = GET_DATAPACKET_LEN(false);

            // Calculate CheckSum
            for (w_nI = 0; w_nI < w_nLen; w_nI++)
                w_nRet += (ushort)m_pPacketBuffer[w_nI];

            // Set CheckSum
            m_pPacketBuffer[w_nLen] = LOBYTE(w_nRet);
            m_pPacketBuffer[w_nLen + 1] = HIBYTE(w_nRet);

            // Return
            return w_nRet;
        }

        public ushort GetCheckSum(bool p_bCmdData)
        {
            ushort w_nRet = 0;
            ushort w_nI;
            ushort w_nLen;

            // Calculate Length
            if (p_bCmdData)
                w_nLen = CommonDefine.ST_COM_PACKET_LEN;
            else
                w_nLen = GET_DATAPACKET_LEN(false);

            // Calculate CheckSum
            for (w_nI = 0; w_nI < w_nLen; w_nI ++)
                w_nRet += (ushort)m_pPacketBuffer[w_nI];

            // Return
            return w_nRet;
        }

        public static byte LOBYTE(ushort p_nValue)
        {
            byte w_nRet;

            // Get Low Byte
            w_nRet = (byte)(p_nValue & 0xff);

            // Return
            return w_nRet;
        }

        public static byte HIBYTE(ushort p_nValue)
        {
            byte w_nRet;

            // Get High Byte
            w_nRet = (byte)(p_nValue >> 8);

            // Return
            return w_nRet;
        }

        public static bool g_bWaitSend = false;
        public static bool g_bSendRet = false;
        public static int g_bWaitUpImg = 0;

        public void StartSendThread()
        {
            Thread w_hSendThread = new Thread(new ThreadStart(SendThread));

            m_bCmdDone = false;

            g_bWaitSend = true;
            w_hSendThread.Start();

            // Process Response
            while (g_bWaitSend)
            {
//                 Thread.Sleep(1);
                if (!DoEvents())
                    return;
            }
            if (g_bSendRet)
                m_pMainWindow.ProcessMessage((uint)CommonDefine.WM_RECEIVE, 1, 0);
            else
                m_pMainWindow.ProcessMessage((uint)CommonDefine.WM_RECEIVE, 0, 0);
        }

        public static void SendThread()
        {
            bool    w_bRet = false;

//          m_pMainWindow
            if (GET_PACKET_PREFIX(false) == CommonDefine.CMD_PREFIX_CODE)
            {
                if (MainWindow.m_clsCmdProc.m_nCmdCode != CommonDefine.CMD_FP_CANCEL_CODE)
                {
                    //if (MainWindow.m_clsCmdProc.m_bConModeIsUSB == false)
                    //    w_bRet = MainWindow.m_clsCmdProc.SendCommand(MainWindow.m_clsCmdProc. m_nCmdCode);
                    //else
                        w_bRet = MainWindow.m_clsUSB.USB_SendPacket(MainWindow.m_clsCmdProc. m_nCmdCode);
                }
                else
                {
                    //if (MainWindow.m_clsCmdProc.m_bConModeIsUSB == false)
                    //    w_bRet = MainWindow.m_clsCmdProc.ReceiveAck(MainWindow.m_clsCmdProc.m_nCmdCode, true);
                    //else
                        w_bRet = MainWindow.m_clsUSB.USB_ReceiveAck(MainWindow.m_clsCmdProc.m_nCmdCode, true);
                }
            }
            else if (GET_PACKET_PREFIX(false) == CommonDefine.CMD_DATA_PREFIX_CODE)
            {
                //if (MainWindow.m_clsCmdProc.m_bConModeIsUSB == false)
                //    w_bRet = MainWindow.m_clsCmdProc.SendDataPacket(MainWindow.m_clsCmdProc.m_nCmdCode);
                //else
                    w_bRet = MainWindow.m_clsUSB.USB_SendDataPacket(MainWindow.m_clsCmdProc.m_nCmdCode);
            }
            else
            {
                if (MainWindow.m_clsCmdProc.m_nCmdCode != CommonDefine.CMD_FEATURE_OF_CAPTURED_FP_CODE)
                {
                    //if (MainWindow.m_clsCmdProc.m_bConModeIsUSB == false)
                    //    w_bRet = MainWindow.m_clsCmdProc.ReceiveAck(MainWindow.m_clsCmdProc.m_nCmdCode, true);
                    //else
                        w_bRet = MainWindow.m_clsUSB.USB_ReceiveAck(MainWindow.m_clsCmdProc.m_nCmdCode, true);
                }
                else
                {
                    //if (MainWindow.m_clsCmdProc.m_bConModeIsUSB == false)
                    //    w_bRet = MainWindow.m_clsCmdProc.ReceiveDataPacket(CommonDefine.CMD_FEATURE_OF_CAPTURED_FP_CODE, CommonDefine.GD_RECORD_SIZE);
                    //else
                        w_bRet = MainWindow.m_clsUSB.USB_ReceiveDataPacket(CommonDefine.CMD_FEATURE_OF_CAPTURED_FP_CODE, CommonDefine.GD_RECORD_SIZE);
                }
            }

            g_bSendRet = w_bRet;
            g_bWaitSend = false;
        }

        public void StartFpCancelThread()
        {
            Thread w_hFpCancelThread = new Thread(new ThreadStart(FpCancelThread));

            w_hFpCancelThread.Start();
           // m_pMainWindow.btnSC_Send.IsEnabled = true;
        }

        public static void FpCancelThread()
        {
            bool    w_bRet = false;
	        ushort	w_nRet = 0;
            int     w_nI;
            uint[] w_nReadLen = new uint[1];

	        //. Init Packet
            Array.Clear(m_pPacketBuffer0, 0, CommonDefine.MAX_DATA_LEN + 10);
            SET_PACKET_PREFIX(CommonDefine.CMD_PREFIX_CODE, true);
            SET_PACKET_COMMAND(CommonDefine.CMD_FP_CANCEL_CODE, true);
 
 	        for (w_nI = 0; w_nI < CommonDefine.ST_COM_PACKET_LEN; w_nI ++)
 		        w_nRet += (ushort)m_pPacketBuffer0[w_nI];
 
            m_pPacketBuffer0[CommonDefine.ST_COM_PACKET_LEN] = LOBYTE(w_nRet);
            m_pPacketBuffer0[CommonDefine.ST_COM_PACKET_LEN + 1] = HIBYTE(w_nRet);
 	
	        //. Send Packet
            //if (MainWindow.m_clsCmdProc.m_bConModeIsUSB == false)
            //{
            //    w_bRet = MainWindow.m_clsSerial.SendData(m_pPacketBuffer0, CommonDefine.ST_COM_PACKET_LEN + 2, CommonDefine.COMM_TIMEOUT);
            //}
            //else
	        {
		        byte[] btCDB = new byte[8];

                Array.Clear(btCDB, 0, 8);
                btCDB[0] = 0xEF; btCDB[1] = 0x11; btCDB[4] = CommonDefine.ST_COM_PACKET_LEN + 2;
                w_bRet = MainWindow.m_clsUSB.USBSCSIWrite(btCDB, 8, m_pPacketBuffer0, CommonDefine.ST_COM_PACKET_LEN + 2, 1000);
	        }

	        if (w_bRet != true)
            {
		        MessageBox.Show("错误的命令包 !", "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		        return;
	        }
	
	        //. Wait while processing cmd exit
            while (MainWindow.m_clsCmdProc.m_bCmdDone == false)
            {
// 		        Thread.Sleep(1);
                if (!DoEvents())
                    return;
	        };

	        //. Receive FP Cancel Receive Packet.
            //if (MainWindow.m_clsCmdProc.m_bConModeIsUSB == false)
            //{
            //    w_bRet = MainWindow.m_clsSerial.ReceiveData(m_pPacketBuffer0, CommonDefine.ST_COM_PACKET_LEN + 2, w_nReadLen, CommonDefine.COMM_TIMEOUT);

            //    if (w_bRet != true)
            //    {
            //        MessageBox.Show("请检查连接 ！", "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            //else
	        {
		        byte[] btCDB = new byte[8];
		        byte[] w_WaitPacket = new byte[24];
		        int[] nLen = new int[1];

                memset(w_WaitPacket, 0xAF, 0, CommonDefine.ST_COM_PACKET_LEN + 2);
		        do
		        {
                    memset(m_pPacketBuffer0, 0, 0, CommonDefine.MAX_DATA_LEN + 10);
			        btCDB[0] = 0xEF; btCDB[1] = 0x12;
                    nLen[0] = CommonDefine.ST_COM_PACKET_LEN + 2;
                    if (!MainWindow.m_clsUSB.USBSCSIRead(btCDB, 8, m_pPacketBuffer0, nLen, 300))
                    {
                        return;
                    }
// 			        Thread.Sleep(100);
                    if (!DoEvents())
                        return;
                } while (memcmp(m_pPacketBuffer0, w_WaitPacket, CommonDefine.ST_COM_PACKET_LEN + 2) == true);
	        }

	        //. Check Packet
	        w_bRet = MainWindow.m_clsCmdProc.CheckReceive(CommonDefine.RCM_PREFIX_CODE, CommonDefine.CMD_FP_CANCEL_CODE);
        }

        public void StartUpImageThread()
        {
            Thread w_hUpImageThread = new Thread(new ThreadStart(UpImageThread));

            m_bCmdDone = false;
           // m_pMainWindow.btnSC_FpCancel.IsEnabled = true;

            g_bWaitUpImg = 1;
           // m_pMainWindow.edtRC_Result.Text = "请按手指";
            w_hUpImageThread.Start();

            // Process Response
            while (g_bWaitUpImg > 0)
            {
//                 Thread.Sleep(1);
                if (!DoEvents())
                    return;

             /*   if (g_bWaitUpImg == 11) // Disable Cancel Button
                   m_pMainWindow.btnSC_FpCancel.IsEnabled = false;
                else if (g_bWaitUpImg == 12) // Uploading Image
                    m_pMainWindow.edtRC_Result.Text = "上传图像中...";*/
            }

            if (g_bWaitUpImg == -1)
                return;

            if (g_bSendRet)
                m_pMainWindow.ProcessMessage((uint)CommonDefine.WM_RECEIVE, 1, 0);
            else
                m_pMainWindow.ProcessMessage((uint)CommonDefine.WM_RECEIVE, 0, 0);
        }

        public static void UpImageThread()
        {
            bool w_blRet = false;
            int w_nImageBufOffset = 0;

            //. Assemble command packet
            MainWindow.m_clsCmdProc.InitPacket(CommonDefine.CMD_UP_IMAGE_CODE, true);
            SET_PACKET_LEN((ushort)0, false);
            MainWindow.m_clsCmdProc.AddCheckSum(true);

            MainWindow.m_clsCmdProc.m_nCmdCode = CommonDefine.CMD_UP_IMAGE_CODE;

            //w_blRet = SendCommand(CMD_UP_IMAGE_CODE);
            w_blRet = MainWindow.m_clsCmdProc.SEND_COMMAND(CommonDefine.CMD_UP_IMAGE_CODE);

            if (w_blRet == false)
            {
                goto l_exit;
            }

            if (GET_PACKET_RETURN(false) != CommonDefine.ERR_SUCCESS)
            {
                goto l_exit;
            }

            g_bWaitUpImg = 11;

            w_nImageBufOffset = 0;
            g_nImageWidth = GET_PACKET_RCMDATA(0, false);
            g_nImageHeight = GET_PACKET_RCMDATA(2, false);

            if (MainWindow.m_clsCmdProc.m_bConModeIsUSB == false)
            {
                while (true)
                {
                    w_blRet = MainWindow.m_clsCmdProc.ReceiveDataPacket(CommonDefine.CMD_UP_IMAGE_CODE, 498);

                    if (w_blRet == false)
                        goto l_exit;
                    else
                    {
                        if (GET_PACKET_RETURN(false) == CommonDefine.ERR_SUCCESS)
                        {
                            if (GET_PACKET_LEN(false) > (CommonDefine.GD_IMAGE_RECEIVE_UINT + 2))
                            {
                                SET_PACKET_RETURN(CommonDefine.ERR_FAIL, false);
                                SET_PACKET_RCMDATA(CommonDefine.ERR_INVALID_PARAM, 0, false);
                                goto l_exit;
                            }
                            else
                            {
                                if (w_nImageBufOffset == 0)
                                {
                                    g_bWaitUpImg = 12;
                                }

                                Array.Copy(m_pPacketBuffer, 8, g_pImageBuf, w_nImageBufOffset, GET_PACKET_LEN(false) - 2);

                                w_nImageBufOffset = w_nImageBufOffset + (GET_PACKET_LEN(false) - 2);

                                if (w_nImageBufOffset == (g_nImageWidth * g_nImageHeight))
                                {
                                    goto l_exit;
                                }
                            }
                        }
                        else
                        {
                            goto l_exit;
                        }
                    }
                }
            }
            else
            {
                w_blRet = MainWindow.m_clsUSB.USB_ReceiveImage(g_pImageBuf, (uint)(g_nImageWidth * g_nImageHeight));
            }

        l_exit:
            g_bWaitUpImg = 0;
            g_bSendRet = w_blRet;
        }

        public bool SEND_COMMAND(ushort p_nCmd)
        {
            if (m_bConModeIsUSB == false)
                return SendCommand(p_nCmd);
            else
                return MainWindow.m_clsUSB.USB_SendPacket(p_nCmd);
        }

        public bool SEND_DATAPACKET(ushort p_nCmd)
        {
            if (m_bConModeIsUSB == false)
                return SendDataPacket(p_nCmd);
            else
                return MainWindow.m_clsUSB.USB_SendDataPacket(p_nCmd);
        }

        public bool RECEIVE_DATAPACKET(ushort p_nCmd, ushort p_nLen)
        {
            if (m_bConModeIsUSB == false)
                return ReceiveDataPacket(p_nCmd, p_nLen);
            else
                return MainWindow.m_clsUSB.USB_ReceiveDataPacket(p_nCmd, p_nLen);
        }

        public static ushort MAKEWORD(byte p_nLoByte, byte p_nHiByte)
        {
            ushort w_nRet;

            w_nRet = (ushort)(((p_nHiByte << 8) & 0xFF00) + (p_nLoByte & 0x00FF));

            return w_nRet;
        }

        public static ushort GET_PACKET_PREFIX(bool p_bCancel)
        {
            ushort w_nRet;

            if (p_bCancel)
                w_nRet = MAKEWORD(m_pPacketBuffer0[0], m_pPacketBuffer0[1]);
            else
                w_nRet = MAKEWORD(m_pPacketBuffer[0], m_pPacketBuffer[1]);

            return w_nRet;
        }

        public static void SET_PACKET_PREFIX(ushort p_nPrefix, bool p_bCancel)
        {
            if (p_bCancel)
            {
                m_pPacketBuffer0[0] = LOBYTE(p_nPrefix);
                m_pPacketBuffer0[1] = HIBYTE(p_nPrefix);
            }
            else
            {
                m_pPacketBuffer[0] = LOBYTE(p_nPrefix);
                m_pPacketBuffer[1] = HIBYTE(p_nPrefix);
            }
        }

        public static ushort GET_PACKET_COMMAND(bool p_bCancel)
        {
            ushort w_nRet;

            if (p_bCancel)
                w_nRet = MAKEWORD(m_pPacketBuffer0[2], m_pPacketBuffer0[3]);
            else
                w_nRet = MAKEWORD(m_pPacketBuffer[2], m_pPacketBuffer[3]);

            return w_nRet;
        }

        public static void SET_PACKET_COMMAND(ushort p_nCmd, bool p_bCancel)
        {
            if (p_bCancel)
            {
                m_pPacketBuffer0[2] = LOBYTE(p_nCmd);
                m_pPacketBuffer0[3] = HIBYTE(p_nCmd);
            }
            else
            {
                m_pPacketBuffer[2] = LOBYTE(p_nCmd);
                m_pPacketBuffer[3] = HIBYTE(p_nCmd);
            }
        }

        public static ushort GET_PACKET_LEN(bool p_bCancel)
        {
            ushort w_nRet;

            if (p_bCancel)
                w_nRet = MAKEWORD(m_pPacketBuffer0[4], m_pPacketBuffer0[5]);
            else
                w_nRet = MAKEWORD(m_pPacketBuffer[4], m_pPacketBuffer[5]);

            return w_nRet;
        }

        public static ushort GET_DATAPACKET_LEN(bool p_bCancel)
        {
            return (ushort)(GET_PACKET_LEN(p_bCancel) + 6);
        }

        public static void SET_PACKET_LEN(ushort p_nLen, bool p_bCancel)
        {
            if (p_bCancel)
            {
                m_pPacketBuffer0[4] = LOBYTE(p_nLen);
                m_pPacketBuffer0[5] = HIBYTE(p_nLen);
            }
            else
            {
                m_pPacketBuffer[4] = LOBYTE(p_nLen);
                m_pPacketBuffer[5] = HIBYTE(p_nLen);
            }
        }

        public static ushort GET_PACKET_RETURN(bool p_bCancel)
        {
            ushort w_nRet;

            if (p_bCancel)
                w_nRet = MAKEWORD(m_pPacketBuffer0[6], m_pPacketBuffer0[7]);
            else
                w_nRet = MAKEWORD(m_pPacketBuffer[6], m_pPacketBuffer[7]);

            return w_nRet;
        }

        public static void SET_PACKET_RETURN(ushort p_nReturn, bool p_bCancel)
        {
            if (p_bCancel)
            {
                m_pPacketBuffer0[6] = LOBYTE(p_nReturn);
                m_pPacketBuffer0[7] = HIBYTE(p_nReturn);
            }
            else
            {
                m_pPacketBuffer[6] = LOBYTE(p_nReturn);
                m_pPacketBuffer[7] = HIBYTE(p_nReturn);
            }
        }

        public static ushort GET_PACKET_CMDDATA(int p_nOffset, bool p_bCancel)
        {
            ushort w_nRet;

            if (p_bCancel)
                w_nRet = MAKEWORD(m_pPacketBuffer0[6 + p_nOffset], m_pPacketBuffer0[7 + p_nOffset]);
            else
                w_nRet = MAKEWORD(m_pPacketBuffer[6 + p_nOffset], m_pPacketBuffer[7 + p_nOffset]);

            return w_nRet;
        }

        public static void SET_PACKET_CMDDATA(ushort p_nValue, int p_nOffset, bool p_bCancel)
        {
            if (p_bCancel)
            {
                m_pPacketBuffer0[6 + p_nOffset] = LOBYTE(p_nValue);
                m_pPacketBuffer0[7 + p_nOffset] = HIBYTE(p_nValue);
            }
            else
            {
                m_pPacketBuffer[6 + p_nOffset] = LOBYTE(p_nValue);
                m_pPacketBuffer[7 + p_nOffset] = HIBYTE(p_nValue);
            }
        }

        public static ushort GET_PACKET_RCMDATA(int p_nOffset, bool p_bCancel)
        {
            ushort w_nRet;

            if (p_bCancel)
                w_nRet = MAKEWORD(m_pPacketBuffer0[8 + p_nOffset], m_pPacketBuffer0[9 + p_nOffset]);
            else
                w_nRet = MAKEWORD(m_pPacketBuffer[8 + p_nOffset], m_pPacketBuffer[9 + p_nOffset]);

            return w_nRet;
        }

        public static void SET_PACKET_RCMDATA(ushort p_nValue, int p_nOffset, bool p_bCancel)
        {
            if (p_bCancel)
            {
                m_pPacketBuffer0[8 + p_nOffset] = LOBYTE(p_nValue);
                m_pPacketBuffer0[9 + p_nOffset] = HIBYTE(p_nValue);
            }
            else
            {
                m_pPacketBuffer[8 + p_nOffset] = LOBYTE(p_nValue);
                m_pPacketBuffer[9 + p_nOffset] = HIBYTE(p_nValue);
            }
        }

        public static bool memcmp(byte[] p_pBuf1, byte[] p_pBuf2, int p_nLen)
        {
            int w_nI;

            for (w_nI = 0; w_nI < p_nLen; w_nI ++)
            {
                if (p_pBuf1[w_nI] != p_pBuf2[w_nI])
                    return false;
            }

            return true;
        }

        public static void memset(byte[] p_pBuf, byte p_nValue, int p_nIndex, int p_nLen)
        {
            int w_nI;

            if (p_nValue == 0)
            {
                Array.Clear(p_pBuf, p_nIndex, p_nLen);
            }
            else
            {
                for (w_nI = 0; w_nI < p_nLen; w_nI ++)
                    p_pBuf[p_nIndex + w_nI] = p_nValue;
            }
        }

        public static void memcpy(byte[] p_pBufDst, byte[] p_pBufSrc, int p_nLen)
        {
            Array.Copy(p_pBufSrc, p_pBufDst, p_nLen);
        }
    }
}
