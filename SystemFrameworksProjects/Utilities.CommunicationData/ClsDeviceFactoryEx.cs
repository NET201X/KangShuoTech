namespace KangShuoTech.Utilities.CommunicationData
{
    using System;

    internal class ClsDeviceFactoryEx
    {
        public static ClsQCTDeviceEx CreateDevice(ClsCommunicationBlueEx comm, string devicename)
        {
            //Ѫѹ
            if (devicename.StartsWith("CHITBP"))
            {
                return new ClsCHITDEVICEBPEx(comm);
            }

            //����
            if (devicename.StartsWith("QCATF"))
            {
                return new ClsALKDEVICETFEx(comm);
            }

            //Ѫ��
            if (devicename.StartsWith("CHITBG"))
            {
                return new ClsCHITDEVICEBGEx(comm);
            }

            //����
            if (devicename.StartsWith("CHITBM"))
            {
                return new ClsCHITDEVICEBMEx(comm);
            }

            //��Һ����
            if (devicename.StartsWith("EMP-Ui"))
            {
                return new ClsEMPDEVICEUIEx(comm);
            }

            return null;
        }
    }
}

