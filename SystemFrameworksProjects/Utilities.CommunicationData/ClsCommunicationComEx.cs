namespace KangShuoTech.Utilities.CommunicationData
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;

    public class ClsCommunicationComEx
    {
        private List<ClsQCTDeviceComAKBG> m_ClsAKBG;
        private List<ClsQCTDeviceComAKBU> m_ClsAKBU;
        private List<ClsQCTDeviceComAKHB> m_ClsAKHB;
        private List<ClsQCTDeviceComAKHW> m_ClsAKHW;
        private List<ClsQCTDeviceComBG> m_ClsBG;
        private List<ClsQCTDeviceComBP> m_ClsBP;
        private List<ClsQCTDeviceComBS> m_ClsBT;
        private List<ClsQCTDeviceComBU> m_ClsBU;
        private List<ClsQCTDeviceYueHaoBG> m_ClsYueHaoBG;
        private ClsQCTDeviceComZQ m_ClsZQ;
        public volatile string[] m_coms;
        private Thread m_td;
        private bool m_TdFlag = true;

        public ClsCommunicationComEx()
        {
            this.startEnum();
        }

        public void DisposeEx()
        {
            this.stopEnum();
            this.StopBLProcess();
            if ((this.m_ClsBU != null) && (this.m_ClsBU.Count > 0))
            {
                foreach (ClsQCTDeviceComBU mbu in this.m_ClsBU)
                {
                    mbu.StopRead();
                }
                this.m_ClsBU.Clear();
            }
            if ((this.m_ClsBG != null) && (this.m_ClsBG.Count > 0))
            {
                foreach (ClsQCTDeviceComBG mbg in this.m_ClsBG)
                {
                    mbg.StopRead();
                }
                this.m_ClsBG.Clear();
            }
            if ((this.m_ClsAKBG != null) && (this.m_ClsAKBG.Count > 0))
            {
                foreach (ClsQCTDeviceComAKBG makbg in this.m_ClsAKBG)
                {
                    makbg.StopRead();
                }
                this.m_ClsAKBG.Clear();
            }
            if ((this.m_ClsAKBU != null) && (this.m_ClsAKBU.Count > 0))
            {
                foreach (ClsQCTDeviceComAKBU makbu in this.m_ClsAKBU)
                {
                    makbu.StopRead();
                }
                this.m_ClsAKBU.Clear();
            }
            if ((this.m_ClsBP != null) && (this.m_ClsBP.Count > 0))
            {
                foreach (ClsQCTDeviceComBP mbp in this.m_ClsBP)
                {
                    mbp.StopRead();
                }
                this.m_ClsBP.Clear();
            }
            if ((this.m_ClsBT != null) && (this.m_ClsBT.Count > 0))
            {
                foreach (ClsQCTDeviceComBS mbs in this.m_ClsBT)
                {
                    mbs.StopRead();
                }
            }
            if ((this.m_ClsYueHaoBG != null) && (this.m_ClsYueHaoBG.Count > 0))
            {
                foreach (ClsQCTDeviceYueHaoBG obg in this.m_ClsYueHaoBG)
                {
                    obg.StopRead();
                }
            }
        }

        private void EnumComs()
        {
            while (this.m_TdFlag)
            {
                //this.m_coms = ClsStaticFunc.GetAllCom();
                Thread.Sleep(0x3e8);
            }
        }

        private void startEnum()
        {
            this.m_TdFlag = true;
            this.m_td = new Thread(new ThreadStart(this.EnumComs));
            this.m_td.Name = "串口枚举线程";
            this.m_td.IsBackground = true;
            this.m_td.Start();
        }

        public void StartRead(string devicename)
        {
            switch (devicename)
            {
                case "QCTCOMBU":
                    this.StartReadComBU();
                    return;

                case "QCTCOMBG":
                    this.StartReadComBG();
                    return;

                case "QCTAKBG":
                    this.StartReadAKBG();
                    return;

                case "QCTAKBU":
                    this.StartReadAKBU();
                    return;

                case "QCTAKHW":
                    this.StartReadAKHW();
                    return;

                case "QCTBL":
                    this.StartReadBL();
                    return;

                case "QCTBP":
                    this.StartReadComBP();
                    return;

                case "QCTBS":
                    this.StartReadComBS();
                    return;

                case "QCTYUEHAOBG":
                    this.StartReadYueHaoBG();
                    return;

                case "QCTCOMAKHB":
                    this.StartReadAKHB();
                    return;

                case "QCTZQ":
                    this.StartReadComZQ();
                    return;
            }
        }

        public void StartReadAKBG()
        {
            this.stopEnum();
            this.m_ClsAKBG = new List<ClsQCTDeviceComAKBG>();
            foreach (string str in this.m_coms)
            {
                this.m_ClsAKBG.Add(new ClsQCTDeviceComAKBG(str));
            }
        }

        public void StartReadAKBU()
        {
            this.stopEnum();
            this.m_ClsAKBU = new List<ClsQCTDeviceComAKBU>();
            foreach (string str in this.m_coms)
            {
                this.m_ClsAKBU.Add(new ClsQCTDeviceComAKBU(str));
            }
        }

        public void StartReadAKHW()
        {
            this.stopEnum();
            this.m_ClsAKHW = new List<ClsQCTDeviceComAKHW>();
            foreach (string str in this.m_coms)
            {
                this.m_ClsAKHW.Add(new ClsQCTDeviceComAKHW(str));
            }
        }

        public void StartReadAKHB()
        {
            this.stopEnum();
            this.m_ClsAKHB = new List<ClsQCTDeviceComAKHB>();
            foreach (string str in this.m_coms)
            {
                this.m_ClsAKHB.Add(new ClsQCTDeviceComAKHB(str));
            }
        }

        public bool StartReadBL()
        {
            this.stopEnum();
            foreach (Process process in Process.GetProcessesByName("Lung.exe"))
            {
                process.Kill();
            }
            if (!File.Exists(Application.StartupPath + @"\Lung.exe"))
            {
                return false;
            }
            Process.Start(Application.StartupPath + @"\Lung.exe", "1");
            return true;
        }

        public void StartReadComBG()
        {
            this.stopEnum();
            this.m_ClsBG = new List<ClsQCTDeviceComBG>();
            foreach (string str in this.m_coms)
            {
                this.m_ClsBG.Add(new ClsQCTDeviceComBG(str));
            }
        }

        public void StartReadComBP()
        {
            this.stopEnum();
            this.m_ClsBP = new List<ClsQCTDeviceComBP>();
            foreach (string str in this.m_coms)
            {
                this.m_ClsBP.Add(new ClsQCTDeviceComBP(str));
            }
        }

        public void StartReadComBS()
        {
            this.stopEnum();
            this.m_ClsBT = new List<ClsQCTDeviceComBS>();
            foreach (string str in this.m_coms)
            {
                this.m_ClsBT.Add(new ClsQCTDeviceComBS(str));
            }
        }

        public void StartReadComBU()
        {
            this.stopEnum();
            this.m_ClsBU = new List<ClsQCTDeviceComBU>();
            foreach (string str in this.m_coms)
            {
                this.m_ClsBU.Add(new ClsQCTDeviceComBU(str));
            }
        }

        public bool StartReadComZQ()
        {
            this.stopEnum();
            this.m_ClsZQ = new ClsQCTDeviceComZQ();
            this.m_ClsZQ.StopRead();
            return this.m_ClsZQ.startRead();
        }

        public void StartReadYueHaoBG()
        {
            this.stopEnum();
            this.m_ClsYueHaoBG = new List<ClsQCTDeviceYueHaoBG>();
            foreach (string str in this.m_coms)
            {
                this.m_ClsYueHaoBG.Add(new ClsQCTDeviceYueHaoBG(str));
            }
        }

        private void StopBLProcess()
        {
            foreach (Process process in Process.GetProcessesByName("Lung.exe"))
            {
                process.Kill();
            }
        }

        private void stopEnum()
        {
            this.m_TdFlag = false;
            while (this.m_td.IsAlive)
            {
                Thread.Sleep(0x3e8);
            }
        }

        public void StopRead(string devicename)
        {
            switch (devicename)
            {
                case "QCTCOMBU":
                    this.StopReadComBU();
                    return;

                case "QCTCOMBG":
                    this.StopReadComBG();
                    return;

                case "QCTAKBG":
                    this.StopReadAKBG();
                    return;

                case "QCTAKBU":
                    this.StopReadAKBU();
                    return;

                case "QCTAKHW":
                    this.StopReadComHW();
                    return;

                case "QCTBL":
                    this.StopBLProcess();
                    return;

                case "QCTBP":
                    this.StopReadComBP();
                    return;

                case "QCTBS":
                    this.StopReadComBS();
                    return;

                case "QCTYUEHAOBG":
                    this.StopReadYueHaoBG();
                    return;

                case "QCTCOMAKHB":
                    this.StopReadAKHB();
                    return;

                case "QCTZQ":
                    this.StopReadZQ();
                    return;
            }
        }

        private void StopReadAKBG()
        {
            if (this.m_ClsAKBG.Count > 0)
            {
                foreach (ClsQCTDeviceComAKBG makbg in this.m_ClsAKBG)
                {
                    makbg.StopRead();
                }
                this.m_ClsAKBG.Clear();
            }
            this.startEnum();
        }

        private void StopReadAKBU()
        {
            if (this.m_ClsAKBU.Count > 0)
            {
                foreach (ClsQCTDeviceComAKBU makbu in this.m_ClsAKBU)
                {
                    makbu.StopRead();
                }
                this.m_ClsAKBU.Clear();
            }
            this.startEnum();
        }

        private void StopReadAKHB()
        {
            if (this.m_ClsAKHB.Count > 0)
            {
                foreach (ClsQCTDeviceComAKHB makhb in this.m_ClsAKHB)
                {
                    makhb.StopRead();
                }
                this.m_ClsAKHB.Clear();
            }
            this.startEnum();
        }

        private void StopReadComBG()
        {
            if (this.m_ClsBG.Count > 0)
            {
                foreach (ClsQCTDeviceComBG mbg in this.m_ClsBG)
                {
                    mbg.StopRead();
                }
                this.m_ClsBG.Clear();
            }
            this.startEnum();
        }

        private void StopReadComBP()
        {
            if (this.m_ClsBP.Count > 0)
            {
                foreach (ClsQCTDeviceComBP mbp in this.m_ClsBP)
                {
                    mbp.StopRead();
                }
                this.m_ClsBP.Clear();
            }
            this.startEnum();
        }

        private void StopReadComBS()
        {
            if (this.m_ClsBT.Count > 0)
            {
                foreach (ClsQCTDeviceComBS mbs in this.m_ClsBT)
                {
                    mbs.StopRead();
                }
                this.m_ClsBT.Clear();
            }
            this.startEnum();
        }

        private void StopReadComBU()
        {
            if (this.m_ClsBU.Count > 0)
            {
                foreach (ClsQCTDeviceComBU mbu in this.m_ClsBU)
                {
                    mbu.StopRead();
                }
                this.m_ClsBU.Clear();
            }
            this.startEnum();
        }

        private void StopReadComHW()
        {
            if (this.m_ClsAKHW.Count > 0)
            {
                foreach (ClsQCTDeviceComAKHW mhw in this.m_ClsAKHW)
                {
                    mhw.StopRead();
                }
                this.m_ClsAKHW.Clear();
            }
            this.startEnum();
        }

        private void StopReadYueHaoBG()
        {
            if (this.m_ClsYueHaoBG.Count > 0)
            {
                foreach (ClsQCTDeviceYueHaoBG obg in this.m_ClsYueHaoBG)
                {
                    obg.StopRead();
                }
                this.m_ClsYueHaoBG.Clear();
            }
            this.startEnum();
        }

        private void StopReadZQ()
        {
            if (this.m_ClsZQ != null)
            {
                this.m_ClsZQ.StopRead();
            }
        }
    }
}

