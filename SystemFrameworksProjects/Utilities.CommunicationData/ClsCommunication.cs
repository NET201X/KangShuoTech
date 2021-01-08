namespace KangShuoTech.Utilities.CommunicationData
{
    using System;

    public abstract class ClsCommunication
    {
        public abstract event TransMessageHandle DataExchange;

        protected ClsCommunication()
        {
        }

        public abstract int Disconnect();
        public abstract string GetDeviceName();
        public abstract int Recv(ref byte[] data, int len);
        public abstract int Send(byte[] command);
        public abstract int SetTimeOut(int time);
        public abstract bool StartDeviceListen();
        public abstract bool StartHardListen();
        public abstract bool StopHardListen();
        public abstract bool StopSoftListen();
        public abstract void WriteDataLog();
    }
}

