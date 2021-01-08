namespace KangShuoTech.Utilities.CommunicationData
{
    using System;

    internal abstract class ClsQCTDeviceEx
    {
        protected ClsCommunicationBlueEx m_Comm;
        public int m_delay = 0xbb8;
        protected byte[] ResultData;

        public abstract bool ExecClose(ref byte[] buffName);
        public abstract bool ExecQuery(ref byte[] buffName);

        public abstract byte[] CommandClose { get; }

        public abstract byte[] CommandQuery { get; }

        public abstract byte[] CommandRead { get; }
    }
}

