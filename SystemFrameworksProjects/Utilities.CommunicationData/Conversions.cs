namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Net;

    internal class Conversions
    {
        public static bool BigEndian = true;
        public static bool ConversionRequired = true;
        public static bool IsDataEncrypted = true;

        public static int GetIntegerFromPacket(byte[] data, int pos, bool ConversionRequired)
        {
            int network = BitConverter.ToInt32(data, pos);
            if (ConversionRequired)
            {
                network = IPAddress.NetworkToHostOrder(network);
            }
            return network;
        }

        public static long GetLongFromPacket(byte[] data, int pos, bool ConversionRequired)
        {
            long network = BitConverter.ToInt64(data, pos);
            if (ConversionRequired)
            {
                network = IPAddress.NetworkToHostOrder(network);
            }
            return network;
        }

        public static short GetShortIntegerFromPacket(byte[] data, int pos, bool ConversionRequired)
        {
            short network = BitConverter.ToInt16(data, pos);
            if (ConversionRequired)
            {
                network = IPAddress.NetworkToHostOrder(network);
            }
            return network;
        }

        public static ushort GetUShortIntegerFromPacket(byte[] data, int pos, bool ConversionRequired)
        {
            ushort num = BitConverter.ToUInt16(data, pos);
            if (ConversionRequired)
            {
                num = (ushort) IPAddress.NetworkToHostOrder((short) num);
            }
            return num;
        }

        public static ushort GetUShortIntegerFromPacket7Bit(byte[] data, int pos, bool ConversionRequired)
        {
            short network = BitConverter.ToInt16(data, pos);
            if (ConversionRequired)
            {
                network = IPAddress.NetworkToHostOrder(network);
            }
            return Convert.ToUInt16((int) (network & 0x7f));
        }

        public static ushort GetUShortIntegerFromPacketEx(byte[] data, int pos, bool ConversionRequired)
        {
            short network = BitConverter.ToInt16(data, pos);
            if (ConversionRequired)
            {
                network = IPAddress.NetworkToHostOrder(network);
            }
            return Convert.ToUInt16((int) (network & 0xff));
        }

        public static string PrintByteArray(byte[] b, int length)
        {
            string str = "";
            for (int i = 0; i < length; i++)
            {
                str = str + b[i].ToString("X2") + " ";
            }
            return str;
        }

        public static void PutIntegerIntoPacket(byte[] data, int pos, int iInteger, bool ConversionRequired)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(!ConversionRequired ? iInteger : IPAddress.HostToNetworkOrder(iInteger)), 0, data, pos, 4);
        }

        public static void PutLongIntoPacket(byte[] data, int pos, long lInteger, bool ConversionRequired)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(!ConversionRequired ? lInteger : IPAddress.HostToNetworkOrder(lInteger)), 0, data, pos, 8);
        }

        public static void PutShortIntegerIntoPacket(byte[] data, int pos, short iInteger, bool ConversionRequired)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(!ConversionRequired ? iInteger : IPAddress.HostToNetworkOrder(iInteger)), 0, data, pos, 2);
        }

        public static void PutStringIntoPacket(byte[] buffer, int pos, string data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                buffer[pos + i] = Convert.ToByte(data[i]);
            }
        }

        public static void PutUShortIntegerIntoPacket(byte[] data, int pos, ushort iInteger, bool ConversionRequired)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(!ConversionRequired ? iInteger : ((ushort) IPAddress.HostToNetworkOrder((short) iInteger))), 0, data, pos, 2);
        }
    }
}

