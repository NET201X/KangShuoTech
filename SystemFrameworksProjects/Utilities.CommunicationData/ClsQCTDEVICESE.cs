namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Forms;

    internal class ClsQCTDEVICESE : ClsQCTDevice
    {
        private int m_OnceCount = 200;
        private Thread m_td;
        private bool m_ThreadStopFlag;

        public ClsQCTDEVICESE(ClsCommunication comm)
        {
            base.m_Comm = comm;
            base.m_delay = 0xbb8;
        }

        public override bool ExecClose()
        {
            Thread.Sleep(500);
            base.m_Comm.Send(this.CommandClose);
            return true;
        }

        public override bool ExecQuery()
        {
            ClsResult.ClearQueue();
            this.m_td = new Thread(new ThreadStart(this.GetData));
            this.m_td.IsBackground = true;
            this.m_td.Name = "Thread_Name:赛尔福心电数据交互";
            Trace.WriteLine("================= Thread_Name:赛尔福心电数据交互 =========================");
            this.m_td.Start();
            FormDeviceSE ese = new FormDeviceSE {
                StartPosition = FormStartPosition.CenterScreen
            };
            ese.OnSaveData += new FormDeviceSE.savedata(this.formSE_OnSaveData);
            ese.ShowDialog();
            this.m_ThreadStopFlag = true;
            Thread.Sleep(500);
            if ((this.m_td != null) && this.m_td.IsAlive)
            {
                this.m_td.Abort();
            }
            this.ExecClose();
            ClsResult.ResultFlag = true;
            return true;
        }

        private void formSE_OnSaveData()
        {
            this.m_ThreadStopFlag = true;
            Thread.Sleep(500);
            if (this.m_td != null)
            {
                if (this.m_td.IsAlive)
                {
                    this.m_td.Abort();
                }
                this.ExecClose();
            }
        }

        private void GetData()
        {
            try
            {
                base.ResultData = new byte[this.m_OnceCount];
                base.m_Comm.SetTimeOut(0x2710);
                while (!this.m_ThreadStopFlag)
                {
                    base.ResultData = new byte[this.m_OnceCount];
                    if (base.m_Comm.Recv(ref this.ResultData, this.m_OnceCount) <= 0)
                    {
                        Thread.Sleep(0x3e8);
                    }
                    else
                    {
                        ClsResult.OperatePointSE(base.ResultData, true);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0xff, 8, 0, 2, 0x45, 0x47, 0, 0xff };
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
                return new byte[] { 0x53, 0x4e, 6, 0, 2, 4, 0, 0, 12 };
            }
        }
    }
}

