namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct QCTUI_VALUE
    {
        public string URO_NiaoDanYuan;
        public string BLD_QianXue;
        public string BIL_DanHongSu;
        public string KET_TongTi;
        public string LEU_BaiXiBao;
        public string GLU_PuTaoTang;
        public string PRO_DanBaiZhi;
        public string PH;
        public string NIT_XiaoSuanYan;
        public string SG_BiZhong;
        public string VC;
        public string BarCode;
    }
}

