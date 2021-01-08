using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace FingerPrint
{
    public class CommonDefine
    {
        // Packet Prefix
        public const int    CMD_PREFIX_CODE						= (0xAA55);
        public const int    RCM_PREFIX_CODE						= (0x55AA);
        public const int    CMD_DATA_PREFIX_CODE				= (0xA55A);
        public const int    RCM_DATA_PREFIX_CODE				= (0x5AA5);

        // Command
        public const int    CMD_VERIFY_CODE						= (0x0101);
        public const int    CMD_IDENTIFY_CODE					= (0x0102);
        public const int    CMD_ENROLL_CODE						= (0x0103);
        public const int    CMD_ENROLL_ONETIME_CODE				= (0x0104);
        public const int    CMD_CLEAR_TEMPLATE_CODE				= (0x0105);
        public const int    CMD_CLEAR_ALLTEMPLATE_CODE			= (0x0106);
        public const int    CMD_GET_EMPTY_ID_CODE				= (0x0107);
        public const int    CMD_GET_BROKEN_TEMPLATE_CODE		= (0x0109);
        public const int    CMD_READ_TEMPLATE_CODE				= (0x010A);
        public const int    CMD_WRITE_TEMPLATE_CODE				= (0x010B);
        public const int    CMD_GET_FW_VERSION_CODE				= (0x0112);
        public const int    CMD_FINGER_DETECT_CODE				= (0x0113);
        public const int    CMD_FEATURE_OF_CAPTURED_FP_CODE		= (0x011A);
        public const int    CMD_IDENTIFY_TEMPLATE_WITH_FP_CODE	= (0x011C);
        public const int    CMD_SLED_CTRL_CODE					= (0x0124);
        public const int    CMD_IDENTIFY_FREE_CODE				= (0x0125);
        public const int    CMD_SET_DEVPASS_CODE				= (0x0126);
        public const int    CMD_VERIFY_DEVPASS_CODE				= (0x0127);
        public const int    CMD_GET_ENROLL_COUNT_CODE			= (0x0128);
        public const int    CMD_CHANGE_TEMPLATE_CODE			= (0x0129);
        public const int    CMD_UP_IMAGE_CODE					= (0x012C);
        public const int    CMD_VERIFY_WITH_DOWN_TMPL_CODE		= (0x012D);
        public const int    CMD_IDENTIFY_WITH_DOWN_TMPL_CODE	= (0x012E);
        public const int    CMD_FP_CANCEL_CODE					= (0x0130);
        public const int    CMD_ADJUST_SENSOR_CODE				= (0x0137);
        public const int    CMD_IDENTIFY_WITH_IMAGE_CODE		= (0x0138);
        public const int    CMD_VERIFY_WITH_IMAGE_CODE			= (0x0139);
        public const int    CMD_SET_PARAMETER_CODE				= (0x013A);
        public const int    CMD_EXIT_DEVPASS_CODE				= (0x013B);
        // public const int     CMD_SET_COMMNAD_VALID_FLAG_CODE			= (0x013C);
        // public const int     CMD_GET_COMMNAD_VALID_FLAG_CODE			= (0x013D);
        public const int    CMD_TEST_CONNECTION_CODE			= (0x0150);
        public const int    RCM_INCORRECT_COMMAND_CODE			= (0x0160);
        public const int    CMD_ENTER_ISPMODE_CODE              = (0x0171);

        // Error Code
        public const int    ERR_SUCCESS                         = (0);
        public const int	ERR_FAIL					        = (1);
        public const int	ERR_CONTINUE				        = (2);
        public const int	ERR_VERIFY					        = (0x11);
        public const int	ERR_IDENTIFY				        = (0x12);
        public const int	ERR_TMPL_EMPTY				        = (0x13);
        public const int	ERR_TMPL_NOT_EMPTY			        = (0x14);
        public const int	ERR_ALL_TMPL_EMPTY			        = (0x15);
        public const int	ERR_EMPTY_ID_NOEXIST		        = (0x16);
        public const int	ERR_BROKEN_ID_NOEXIST		        = (0x17);
        public const int	ERR_INVALID_TMPL_DATA		        = (0x18);
        public const int	ERR_DUPLICATION_ID			        = (0x19);
        public const int	ERR_TOO_FAST				        = (0x20);
        public const int	ERR_BAD_QUALITY				        = (0x21);
        public const int	ERR_SMALL_LINES				        = (0x22);
        public const int	ERR_TIME_OUT				        = (0x23);
        public const int	ERR_NOT_AUTHORIZED			        = (0x24);
        public const int	ERR_GENERALIZE				        = (0x30);
        public const int	ERR_COM_TIMEOUT				        = (0x40);
        public const int	ERR_FP_CANCEL				        = (0x41);
        public const int	ERR_INTERNAL				        = (0x50);
        public const int	ERR_MEMORY					        = (0x51);
        public const int	ERR_EXCEPTION				        = (0x52);
        public const int	ERR_INVALID_TMPL_NO			        = (0x60);
        public const int	ERR_INVALID_PARAM			        = (0x70);
        public const int	ERR_NO_RELEASE				        = (0x71);
        public const int	ERR_INVALID_OPERATION_MODE	        = (0x72);
        public const int    ERR_NOT_SET_PWD				        = (0x74);
        public const int	ERR_FP_NOT_DETECTED			        = (0x75);
        public const int	ERR_ADJUST_SENSOR			        = (0x76);

        // Return Value
        public const int	GD_NEED_FIRST_SWEEP			        = (0xFFF1);
        public const int	GD_NEED_SECOND_SWEEP		        = (0xFFF2);
        public const int	GD_NEED_THIRD_SWEEP			        = (0xFFF3);
        public const int	GD_NEED_RELEASE_FINGER		        = (0xFFF4);
        public const int	GD_TEMPLATE_NOT_EMPTY		        = (0x01);
        public const int	GD_TEMPLATE_EMPTY			        = (0x00);
        public const int	GD_DETECT_FINGER			        = (0x01);
        public const int	GD_NO_DETECT_FINGER			        = (0x00);
        public const int    GD_DOWNLOAD_SUCCESS                 = (0xA1);

        // Packet
        public const int    MAX_DATA_LEN                        = (600); /*512*/
        public const int    ST_COM_PACKET_LEN                   = (22);
        public const int    ST_COMMAND_LEN                      = (66);
        public const int    ST_CMDDATA_INDEX                    = (6);
        public const int    ST_RCMDATA_INDEX                    = (8);

        // Communication
        public const int    COMM_TIMEOUT                        = (15000);

        // Mutex
        public const int    MUTEX_TIMEOUT                       = (1500);

        // Time
        public const int	GD_MAX_FP_TIME_OUT			    	= (60);
        public const int	GD_DEFAUT_FP_TIME_OUT		    	= (5);
        public const int    GD_MIN_FP_TIME_OUT                  = (0);

        // Template
        public const int    GD_MAX_RECORD_COUNT                 = (3000);
        public const int    GD_TEMPLATE_SIZE			    	= (570);
        public const int    GD_RECORD_SIZE                      = (GD_TEMPLATE_SIZE);

        // Messages
        public const int	WM_RECEIVE			                = (30000 + 0x05);
        public const int    WM_DISPLAY_PACKET                   = (30000 + 0x06);
        public const int    WM_USER_UPDATE_0                    = (30000 + 0x07);

        // Strings
        public const string MSG_TITLE                           = "FingerPrint";

        // Image
        public const int    GD_IMAGE_RECEIVE_UINT			    = (498);
        public const int    IMAGE_SEND_UNIT                     = (498);
    }

    // Struct
    [StructLayout(LayoutKind.Sequential)]
    public struct ST_COM_PACKET         // 22Byte
    {
        public ushort m_nPrefix;        // 2Byte
        public ushort m_nCmd_Rcm;       // 2Byte
        public ushort m_nDataLen;       // 2Byte
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] m_pCMDData;       // 16Byte
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct ST_COM_PACKET_RET     // 22Byte
    {
        public ushort m_nPrefix;        // 2Byte
        public ushort m_nCmd_Rcm;       // 2Byte
        public ushort m_nDataLen;       // 2Byte
        public ushort m_nRet;           // 2Byte
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
        public byte[] m_pRcmData;       // 14Byte
    }
}
