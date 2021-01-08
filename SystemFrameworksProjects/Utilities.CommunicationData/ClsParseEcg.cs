namespace KangShuoTech.Utilities.CommunicationData
{
    using System;

    internal class ClsParseEcg
    {
        private byte[] m_result;

        public ClsParseEcg(byte[] result)
        {
            this.m_result = result;
        }
    }
}

