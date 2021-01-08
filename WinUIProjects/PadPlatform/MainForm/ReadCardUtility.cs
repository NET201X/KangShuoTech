using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PadPlatform
{
    public class ReadCardUtility
    {
        [DllImport("mtx_32.dll", EntryPoint = "device_open", SetLastError = true,
        CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        // 打开设备
        public static extern int device_open(int nPort, int ulBaud);


        [DllImport("mtx_32.dll", EntryPoint = "device_close", SetLastError = true,
        CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        //说明：    关闭通讯口
        public static extern Int16 device_close(int icdev);


        [DllImport("mtx_32.dll", EntryPoint = "hex_asc", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 hex_asc([MarshalAs(UnmanagedType.LPArray)]byte[] sHex, [MarshalAs(UnmanagedType.LPArray)]byte[] sAsc, ulong ulLength);

        [DllImport("mtx_32.dll", EntryPoint = "asc_hex", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 asc_hex([MarshalAs(UnmanagedType.LPArray)]byte[] sAsc, [MarshalAs(UnmanagedType.LPArray)]byte[] sHex, ulong ulLength);

        //判断设备通信类型
        [DllImport("mtx_32.dll", EntryPoint = "device_gettype", SetLastError = true,
        CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        static extern public Int16 device_gettype(byte[] devicetype);
        //获取设备状态
        [DllImport("mtx_32.dll", EntryPoint = "get_device_status", SetLastError = true,
        CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        static extern public Int16 get_device_status(int icdev, byte[] ndev_status);
        //身份证读卡
        [DllImport("mtx_32.dll", EntryPoint = "IDCard_ReadCard", SetLastError = true,
        CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        static extern public Int16 IDCard_ReadCard(int icdev, [MarshalAs(UnmanagedType.LPArray)]byte[] message);

        //身份证读卡，保存照片
        [DllImport("mtx_32.dll", EntryPoint = "IDCard_ReadCard_Extra", SetLastError = true,
        CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        static extern public Int16 IDCard_ReadCard_Extra(int icdev, [MarshalAs(UnmanagedType.LPArray)]byte[] bmpPath, [MarshalAs(UnmanagedType.LPArray)]byte[] message);

        //根据索引获取身份证数据结构体中该下表所对应的数据
        [DllImport("mtx_32.dll", EntryPoint = "IDCard_GetCardInfo", CallingConvention = CallingConvention.StdCall)]
        static extern public Int16 IDCard_GetCardInfo(int icdev, int index, [MarshalAs(UnmanagedType.LPArray)]byte[] infodata);

        //接触CPU卡
        //上电
        [DllImport("mtx_32.dll", EntryPoint = "sam_slt_reset", SetLastError = true,
            CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 sam_slt_reset(int icdev, Int16 delayTime, byte cardno, out byte atrLen, [MarshalAs(UnmanagedType.LPArray)]byte[] sAtr);

        //下电
        [DllImport("mtx_32.dll", EntryPoint = "sam_slt_powerdown", SetLastError = true,
        CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 sam_slt_powerdown(int icdev, byte cardno);

        //非接触CPU卡
        //上电激活
        [DllImport("mtx_32.dll", EntryPoint = "open_card", SetLastError = true,
        CharSet = CharSet.Auto, ExactSpelling = false,
        CallingConvention = CallingConvention.StdCall)]

        //下电
        public static extern Int16 open_card(int icdev, Int16 delayTime, [MarshalAs(UnmanagedType.LPArray)]byte[] cardType, out byte snrLen, [MarshalAs(UnmanagedType.LPArray)]byte[] snr, out byte AtrLen, [MarshalAs(UnmanagedType.LPArray)]byte[] nAtrLen);
        [DllImport("mtx_32.dll", EntryPoint = "rf_halt", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_halt(int icdev, Int16 delayTime);

        //APDU 命令
        [DllImport("mtx_32.dll", EntryPoint = "card_APDU", SetLastError = true,
            CharSet = CharSet.Auto, ExactSpelling = false,
            CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 card_APDU(int icdev, byte cardNo, int slen, [MarshalAs(UnmanagedType.LPArray)]byte[] scmd, out int rlen, [MarshalAs(UnmanagedType.LPArray)]byte[] rcmd);

        //金融IC卡 读卡
        [DllImport("mtx_32.dll", EntryPoint = "iReadICCardNoAndName", SetLastError = true,
        CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        static extern public int iReadICCardNoAndName(int icdev, int nCardType, [MarshalAs(UnmanagedType.LPArray)]byte[] ICCardNo, [MarshalAs(UnmanagedType.LPArray)]byte[] ICCardName, [MarshalAs(UnmanagedType.LPArray)]byte[] lpErrMsg);
    }
}
