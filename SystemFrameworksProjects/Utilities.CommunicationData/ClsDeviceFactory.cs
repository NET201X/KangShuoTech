namespace KangShuoTech.Utilities.CommunicationData
{
    using System;

    internal class ClsDeviceFactory
    {
        public static ClsQCTDevice CreateDevice(ClsCommunication comm, string devicename, string sex, string age, string height, int m_BFHour, int m_BFMinu)
        {
            //�����ĵ�
            if (devicename.StartsWith("QCTBE"))
            {
                return new ClsQCTDEVICEBE(comm);
            }

            //����ɷ�
            if (devicename.StartsWith("QCTBF"))
            {
                return new ClsQCTDEVICEBF(comm, sex, age, height, m_BFHour, m_BFMinu);
            }

            //Ѫ��
            if (devicename.StartsWith("QCTBG"))
            {
                return new ClsQCTDEVICEBG(comm);
            }

            //Ѫѹ
            if (devicename.StartsWith("QCTBP") && !devicename.StartsWith("QCTBPT"))
            {
                return new ClsQCTDEVICEBP(comm);
            }

            //Ѫѹ
            if (devicename.StartsWith("Fmd"))
            {
                return new ClsFMDDEVICEBP(comm);
            }

            //Ѫѹ
            if (devicename.StartsWith("CHITBP"))
            {
                return new ClsCHITDEVICEBP(comm);
            }

            //Ѫѹ
            if (devicename.StartsWith("QCRBP"))
            {
                return new ClsCHITDEVICEBPR(comm);
            }

            //����
            if (devicename.StartsWith("ALKTF"))
            {
                return new ClsALKDEVICETF(comm);
            }

            //����
            if (devicename.StartsWith("QCATF"))
            {
                return new ClsALKDEVICETF(comm);
            }

            //����
            if (devicename.StartsWith("QCTTF"))
            {
                return new ClsQCTDEVICETF(comm);
            }

            //Ѫ��
            if (devicename.StartsWith("CHITBG"))
            {
                return new ClsCHITDEVICEBG(comm);
            }

            // ������
            if (devicename.StartsWith("CHITBM_N"))
            {
                return new ClsQCTDEVICEBM_N(comm);
            }

            //����
            if (devicename.StartsWith("CHITBM"))
            {
                return new ClsCHITDEVICEBM(comm);
            }

            //����
            if (devicename.StartsWith("QCABM"))
            {
                return new ClsQCTDEVICEBM(comm);
            }

            //��Һ����
            if (devicename.StartsWith("EMPUI"))
            {
                return new ClsEMPDEVICEUI(comm);
            }

            //ѪѹѪ��һ���
            if (devicename.StartsWith("QCTBPT"))
            {
                return new ClsQCTDEVICEBPT(comm);
            }

            //Ѫ��
            if (devicename.StartsWith("QCTBT"))
            {
                return new ClsQCTDEVICEBT(comm);
            }

            //ѪҺ
            if (devicename.StartsWith("QCTBU"))
            {
                return new ClsQCTDEVICEBU(comm);
            }

            //����
            if (devicename.StartsWith("QCTBM"))
            {
                return new ClsQCTDEVICEBW(comm);
            }

            //����
            if (devicename.StartsWith("QCTBM"))
            {
                return new ClsQCTDEVICEBM(comm);
            }

            //����
            if (devicename.StartsWith("QCTTF"))
            {
                return new ClsQCTDEVICETF(comm);
            }

            //��Һ����
            if (devicename.StartsWith("QCTUI"))
            {
                return new ClsQCTDEVICEUI(comm);
            }

            //��Һ����
            if (devicename.StartsWith("QCTUR"))
            {
                return new ClsQCTDEVICEUR(comm);
            }

            //���
            if (devicename.StartsWith("QCTBH"))
            {
                return new ClsQCTDEVICEBH(comm);
            }

            //�ۺ����ݲɼ���
            if (devicename.StartsWith("QCTBC"))
            {
                return new ClsQCTDEVICEBC(comm);
            }

            //:�������ĵ����ݽ���
            if (devicename.StartsWith("QCTSE"))
            {
                return new ClsQCTDEVICESE(comm);
            }

            //Ѫ����
            if (devicename.StartsWith("QCTPA"))
            {
                return new ClsQCTDeviceComBU(comm);
            }

            //Ѫѹ
            if (devicename.StartsWith("HEM"))
            {
                return new ClsQCTDeviceHEM(comm);
            }

            //Ѫ��
            if (devicename.StartsWith("DT-806"))
            {
                return new ClsQCTDeviceDT(comm);
            }

            return null;
        }
    }
}

