namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct valueItem
    {
        public QCTBE_VALUE QCTBE;
        public QCTBF_VALUE QCTBF;
        public QCTBG_VALUE QCTBG;
        public QCTBP_VALUE QCTBP;
        public QCTBPT_VALUE QCTBPT;
        public QCTBT_VALUE QCTBT;
        public QCTBU_VALUE QCTBU;
        public QCTBW_VALUE QCTBM;
        public QCTTF_VALUE QCTTF;
        public QCTUI_VALUE QCTUI;
        public QCTBH_VALUE QCTBH;
        public QCTBS_VALUE QCTBS;
        public QCTBC_VALUE QCTBC;
        public QCTHB_VALUE QCTHB;
        public QCTZQ_VALUE QCTZQ;
        public QCTBP_VALUE FMDBP;
        public QCTBP_VALUE CHITBP;
    }
}

