using System.Globalization;

namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;

    internal class ClsQCTDEVICEBT : ClsQCTDevice
    {
        public ClsQCTDEVICEBT(ClsCommunication comm)
        {
            base.m_Comm = comm;
            base.m_delay = 0x1388;
        }

        public override bool ExecClose()
        {
            Thread.Sleep(300);
            base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(300);
            base.m_Comm.Send(this.CommandClose);
            return true;
        }

        public override bool ExecQuery()
        {
            base.ResultData = new byte[100];
            int num = 0;
            string str = "";
            string str2 = "";
            string str3 = "";
           
            base.m_Comm.SetTimeOut(0x2710);

            base.m_Comm.Send(this.CommandRead);
            //Thread.Sleep(500);
            num = base.m_Comm.Recv(ref this.ResultData, 100);

            Thread.Sleep(200);
            //base.m_Comm.Send(this.CommandClose);
            //Thread.Sleep(200);
            //base.m_Comm.Send(this.CommandClose);

            if (num != 100)
            {
                return false;
            }

            string str4 = ResultData[91].ToString("X");
            string str5 = ResultData[90].ToString("X");

            ClsResult.DeviceName = "QCTBT";
            ClsResult.DeviceFriendName = "血氧";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();
            ClsResult.DeviceValue.QCTBT.XueYang = str4;
            ClsResult.DeviceValue.QCTBT.MaiLv = str5;
            ClsResult.ResultFlag = true;
            return true;
        }

        public void WriteDataLog(string data)
        {
            string path = Application.StartupPath + @"\DataLog.txt";
            data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss  ") + data + "\r\n";
            data = data + "\r\n===========================================\r\n";
            try
            {
                FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                if (stream.Length > 0x249f0L)
                {
                    stream.Close();
                    File.Delete(path);
                    stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                    stream.Flush();
                    stream.Close();
                }
                stream.Close();
                StreamWriter writer = File.AppendText(path);
                writer.Write(data);
                writer.Flush();
                writer.Close();
                data = "";
            }
            catch (Exception)
            {
                MessageBox.Show("写入日志文件出错,请截下此错误出现的图片" + data);
            }
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0x7D, 0x81, 0xAE, 0xFF, 0xFF, 0x80, 0x80, 0x80, 0x80 };
            }
        }

        public override byte[] CommandQuery
        {
            get
            {
                byte[] buffer = new byte[1];
                buffer.Initialize();
                return buffer;
            }
        }

        public override byte[] CommandRead
        {
            get
            {
                return new byte[] { byte.Parse("7D", NumberStyles.HexNumber), byte.Parse("81", NumberStyles.HexNumber), byte.Parse("A6", NumberStyles.HexNumber), 
                    byte.Parse("FF", NumberStyles.HexNumber), byte.Parse("FF", NumberStyles.HexNumber), 
                    byte.Parse("80", NumberStyles.HexNumber), byte.Parse("80", NumberStyles.HexNumber), byte.Parse("80", NumberStyles.HexNumber), byte.Parse("80", NumberStyles.HexNumber) };
            }
        }
    }
}

