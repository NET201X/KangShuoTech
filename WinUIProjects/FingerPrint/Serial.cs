using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace FingerPrint
{
    public class SerialCom
    {
        private System.IO.Ports.SerialPort m_comPort;

        public SerialCom()
        {

        }

        public List<string> GetAllPorts()
        {
            List<String> allPorts = new List<String>();
            foreach (String portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                allPorts.Add(portName);
            }
            return allPorts;
        }

        public bool OpenPort(string p_strPort, uint p_nBaudrate)
        {
            m_comPort = new System.IO.Ports.SerialPort(p_strPort, (int)p_nBaudrate);
            if (m_comPort.IsOpen == false)
            {
                try
                {
                    // Open COM Port
                    m_comPort.Open();
                }
                catch (Exception)
                {
                    // Can't open COM Port
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool ClosePort()
        {
            // Close COM Port
            if (m_comPort.IsOpen == false)
                return false;

            m_comPort.Close();

            return true;
        }

        public bool SendData(byte[] p_pDataBuf, uint p_nDataLen, uint p_nTimeOut)
        {            
            // Buffer Init
            m_comPort.DiscardInBuffer();
            m_comPort.DiscardOutBuffer();

            // Send
            m_comPort.WriteTimeout = (int)p_nTimeOut;
            m_comPort.Write(p_pDataBuf, 0, (int)p_nDataLen);

            // Return
            return true;
        }

        public bool ReceiveData(byte[] p_pDataBuf, uint p_nDataLen, uint[] p_nReadLen, uint p_nTimeOut)
        {
            // Wait For ACK
            CommTimer w_tmrComm = new CommTimer();
            bool w_bRet = false;

            w_tmrComm.Start(p_nTimeOut);
            while ((m_comPort.BytesToRead < p_nDataLen) && (w_tmrComm.timedout == false))
            {
//                 System.Threading.Thread.Sleep(1);
                if (!CommandProc.DoEvents())
                    return false;
            }

            // Receive
            if (m_comPort.BytesToRead > 0)
            {
                m_comPort.ReadTimeout = (int)p_nTimeOut;
                p_nReadLen[0] = (uint)m_comPort.Read(p_pDataBuf, 0, (int)p_nDataLen);
                if (p_nReadLen[0] <= 0)
                {
                    w_bRet = false;
                }
                else
                {
                    w_bRet = true;
                }
            }
            else
            {
                w_bRet = false;
            }

            // Release
            w_tmrComm.tmrComm.Dispose();
//             m_comPort.DiscardInBuffer();
            m_comPort.DiscardOutBuffer();

            // Return
            return w_bRet;
        }
    }

    public class CommTimer
    {
        public  Timer tmrComm = new Timer();
        public bool timedout = false;
        public CommTimer()
        {
            timedout = false;
            tmrComm.AutoReset = false;
            tmrComm.Enabled = false;
            tmrComm.Interval = 1000; //default to 1 second
            tmrComm.Elapsed += new ElapsedEventHandler(OnTimedCommEvent);
        }
 
        public void OnTimedCommEvent(object source, ElapsedEventArgs e)
        {
            timedout = true;
            tmrComm.Stop();
        }
 
        public void Start(double timeoutperiod)
        {
            tmrComm.Interval = timeoutperiod;             //time to time out in milliseconds
            tmrComm.Stop();
            timedout = false;
            tmrComm.Start();
        }
    }
}
