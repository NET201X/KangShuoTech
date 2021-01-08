namespace KangShuoTech.Utilities.Common
{
    using System;

    public enum STGM
    {
        CONVERT = 0x20000,
        CREATE = 0x1000,
        DELETEONRELEASE = 0x4000000,
        DIRECT = 0,
        DIRECT_SWMR = 0x400000,
        FAILIFTHERE = 0,
        NOSCRATCH = 0x100000,
        NOSNAPSHOT = 0x200000,
        PRIORITY = 0x40000,
        READ = 0,
        READWRITE = 2,
        SHARE_DENY_NONE = 0x40,
        SHARE_DENY_READ = 0x30,
        SHARE_DENY_WRITE = 0x20,
        SHARE_EXCLUSIVE = 0x10,
        SIMPLE = 0x8000000,
        TRANSACTED = 0x10000,
        WRITE = 1
    }
}

