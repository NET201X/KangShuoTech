namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Collections.Generic;

    public static class ClsResult
    {
        public static string DeviceAddress = "";
        public static string DeviceFriendName = "";
        public static string DeviceMsg = "";
        public static string DeviceName = "";
        public static valueItem DeviceValue;
        private static Queue<byte[]> m_queue = new Queue<byte[]>();
        public static List<TYPEANDVALUE> m_UnitList;
        public static bool ResultFlag = false;

        public static void ClearQueue()
        {
            m_queue.Clear();
        }

        public static byte[] OperatePointSE(byte[] data, bool inFlag)
        {
            lock (typeof(ClsResult))
            {
                if (inFlag)
                {
                    m_queue.Enqueue(data);
                    return null;
                }
                if (m_queue.Count > 0)
                {
                    return m_queue.Dequeue();
                }
                return null;
            }
        }
    }
}

