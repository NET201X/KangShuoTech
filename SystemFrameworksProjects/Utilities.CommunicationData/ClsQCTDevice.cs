namespace KangShuoTech.Utilities.CommunicationData
{
    using System;

    internal abstract class ClsQCTDevice
    {
        protected ClsCommunication m_Comm;
        public int m_delay = 0xbb8;
        protected byte[] ResultData;

        public abstract bool ExecClose();
        public abstract bool ExecQuery();

        public abstract byte[] CommandClose { get; }

        public abstract byte[] CommandQuery { get; }

        public abstract byte[] CommandRead { get; }
    }
}

