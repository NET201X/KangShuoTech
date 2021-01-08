namespace KangShuoTech.Utilities.CommunicationData
{
    using System;

    internal class ClsDeviceFactory
    {
        public static ClsQCTDevice CreateDevice(ClsCommunication comm, string devicename, string sex, string age, string height, int m_BFHour, int m_BFMinu)
        {
            //单导心电
            if (devicename.StartsWith("QCTBE"))
            {
                return new ClsQCTDEVICEBE(comm);
            }

            //人体成分
            if (devicename.StartsWith("QCTBF"))
            {
                return new ClsQCTDEVICEBF(comm, sex, age, height, m_BFHour, m_BFMinu);
            }

            //血糖
            if (devicename.StartsWith("QCTBG"))
            {
                return new ClsQCTDEVICEBG(comm);
            }

            //血压
            if (devicename.StartsWith("QCTBP") && !devicename.StartsWith("QCTBPT"))
            {
                return new ClsQCTDEVICEBP(comm);
            }

            //血压
            if (devicename.StartsWith("Fmd"))
            {
                return new ClsFMDDEVICEBP(comm);
            }

            //血压
            if (devicename.StartsWith("CHITBP"))
            {
                return new ClsCHITDEVICEBP(comm);
            }

            //血压
            if (devicename.StartsWith("QCRBP"))
            {
                return new ClsCHITDEVICEBPR(comm);
            }

            //额温
            if (devicename.StartsWith("ALKTF"))
            {
                return new ClsALKDEVICETF(comm);
            }

            //额温
            if (devicename.StartsWith("QCATF"))
            {
                return new ClsALKDEVICETF(comm);
            }

            //额温
            if (devicename.StartsWith("QCTTF"))
            {
                return new ClsQCTDEVICETF(comm);
            }

            //血糖
            if (devicename.StartsWith("CHITBG"))
            {
                return new ClsCHITDEVICEBG(comm);
            }

            // 新体重
            if (devicename.StartsWith("CHITBM_N"))
            {
                return new ClsQCTDEVICEBM_N(comm);
            }

            //体重
            if (devicename.StartsWith("CHITBM"))
            {
                return new ClsCHITDEVICEBM(comm);
            }

            //体重
            if (devicename.StartsWith("QCABM"))
            {
                return new ClsQCTDEVICEBM(comm);
            }

            //尿液分析
            if (devicename.StartsWith("EMPUI"))
            {
                return new ClsEMPDEVICEUI(comm);
            }

            //血压血氧一体机
            if (devicename.StartsWith("QCTBPT"))
            {
                return new ClsQCTDEVICEBPT(comm);
            }

            //血氧
            if (devicename.StartsWith("QCTBT"))
            {
                return new ClsQCTDEVICEBT(comm);
            }

            //血液
            if (devicename.StartsWith("QCTBU"))
            {
                return new ClsQCTDEVICEBU(comm);
            }

            //体重
            if (devicename.StartsWith("QCTBM"))
            {
                return new ClsQCTDEVICEBW(comm);
            }

            //体重
            if (devicename.StartsWith("QCTBM"))
            {
                return new ClsQCTDEVICEBM(comm);
            }

            //体温
            if (devicename.StartsWith("QCTTF"))
            {
                return new ClsQCTDEVICETF(comm);
            }

            //尿液分析
            if (devicename.StartsWith("QCTUI"))
            {
                return new ClsQCTDEVICEUI(comm);
            }

            //尿液分析
            if (devicename.StartsWith("QCTUR"))
            {
                return new ClsQCTDEVICEUR(comm);
            }

            //身高
            if (devicename.StartsWith("QCTBH"))
            {
                return new ClsQCTDEVICEBH(comm);
            }

            //综合数据采集仪
            if (devicename.StartsWith("QCTBC"))
            {
                return new ClsQCTDEVICEBC(comm);
            }

            //:赛尔福心电数据交互
            if (devicename.StartsWith("QCTSE"))
            {
                return new ClsQCTDEVICESE(comm);
            }

            //血生化
            if (devicename.StartsWith("QCTPA"))
            {
                return new ClsQCTDeviceComBU(comm);
            }

            //血压
            if (devicename.StartsWith("HEM"))
            {
                return new ClsQCTDeviceHEM(comm);
            }

            //血氧
            if (devicename.StartsWith("DT-806"))
            {
                return new ClsQCTDeviceDT(comm);
            }

            return null;
        }
    }
}

