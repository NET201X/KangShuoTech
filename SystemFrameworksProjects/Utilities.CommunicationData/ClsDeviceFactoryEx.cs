namespace KangShuoTech.Utilities.CommunicationData
{
    using System;

    internal class ClsDeviceFactoryEx
    {
        public static ClsQCTDeviceEx CreateDevice(ClsCommunicationBlueEx comm, string devicename)
        {
            //ÑªÑ¹
            if (devicename.StartsWith("CHITBP"))
            {
                return new ClsCHITDEVICEBPEx(comm);
            }

            //¶îÎÂ
            if (devicename.StartsWith("QCATF"))
            {
                return new ClsALKDEVICETFEx(comm);
            }

            //ÑªÌÇ
            if (devicename.StartsWith("CHITBG"))
            {
                return new ClsCHITDEVICEBGEx(comm);
            }

            //ÌåÖØ
            if (devicename.StartsWith("CHITBM"))
            {
                return new ClsCHITDEVICEBMEx(comm);
            }

            //ÄòÒº·ÖÎö
            if (devicename.StartsWith("EMP-Ui"))
            {
                return new ClsEMPDEVICEUIEx(comm);
            }

            return null;
        }
    }
}

