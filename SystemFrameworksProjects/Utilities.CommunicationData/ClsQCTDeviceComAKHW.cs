using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.IO.Ports;

namespace KangShuoTech.Utilities.CommunicationData
{
    public class ClsQCTDeviceComAKHW
    {
        private int m_lastCount;
        private int m_recvCount;
        private string m_ResultStr = "";
        private SerialPort m_SerialPort;
        private bool m_SingleFlag;
        private Timer timer;

        public ClsQCTDeviceComAKHW(string com)
        {
            try
            {
                this.m_recvCount = 0;
                this.m_lastCount = 0;
                this.m_SerialPort = new SerialPort(com, 0x2580);
                this.timer = new Timer(5000.0);
                this.timer.Elapsed += new ElapsedEventHandler(this.m_timer_Tick);
                this.timer.Start();

                if (!this.m_SerialPort.IsOpen)
                {
                    this.m_SerialPort.Open();
                    this.m_SerialPort.DataReceived += new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                }
            }
            catch (Exception)
            {
            }
        }

        private void m_SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int n = m_SerialPort.BytesToRead;
            byte[] buf = new byte[n];
            byte[] buffer = new byte[9];

            string weight = "";
            string height = "";

            this.m_recvCount++;

            m_SerialPort.Read(buf, 0, n);

            if (n == 9)
            {
                string w1 = buf[1].ToString();
                string h1 = buf[5].ToString();

                if (w1 == "0")
                {
                    w1 = "";
                }

                if (h1 == "0")
                {
                    h1 = "";
                }

                weight = w1 + buf[2].ToString() + buf[3].ToString() + "." + buf[4].ToString();
                height = h1 + buf[6].ToString() + buf[7].ToString() + "." + buf[8].ToString();
            }
            else
            {
                buffer[0] = buf[0];

                for (int i = 1; i < 9; i++)
                {
                    m_SerialPort.Read(buf, 0, n);

                    buffer[i] = buf[0];
                }

                string w1 = buffer[1].ToString();
                string h1 = buffer[5].ToString();

                if (w1 == "0")
                {
                    w1 = "";
                }

                if (h1 == "0")
                {
                    h1 = "";
                }

                weight = w1 + buffer[2].ToString() + buffer[3].ToString() + "." + buffer[4].ToString();
                height = h1 + buffer[6].ToString() + buffer[7].ToString() + "." + buffer[8].ToString();
            }

            ClsResult.DeviceName = "QCTBH";
            ClsResult.DeviceFriendName = "身高体重仪";
            ClsResult.DeviceAddress = "";
            ClsResult.m_UnitList = new List<TYPEANDVALUE>();
            ClsResult.m_UnitList.Clear();
            ClsResult.DeviceValue = new valueItem();
            ClsResult.DeviceValue.QCTBH.ShenGao = height;
            ClsResult.DeviceValue.QCTBH.TiZhong = weight;

            decimal num;
            decimal num2;
            if ((decimal.TryParse(height, out num) && decimal.TryParse(weight, out num2)) && (num != 0M))
            {
                decimal num3 = num / 100M;
                decimal num4 = num3 * num3;
                ClsResult.DeviceValue.QCTBH.ZhiShu = (num2 / num4).ToString(".00");
            }

            this.m_SingleFlag = true;

        }

        private void m_timer_Tick(object sender, EventArgs e)
        {
            if (this.m_recvCount != 0)
            {
                if (this.m_recvCount != this.m_lastCount)
                {
                    this.m_lastCount = this.m_recvCount;
                }
                else
                {
                    this.timer.Stop();
                    ClsResult.ResultFlag = true;
                }
            }
        }

        public void StopRead()
        {
            try
            {
                this.timer.Stop();
                if (this.m_SerialPort.IsOpen)
                {
                    this.m_SerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                    this.m_SerialPort.Close();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
